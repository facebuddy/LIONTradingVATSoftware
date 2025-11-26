using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Audit
{
    public partial class VDSStatements : Page, IRequiresSessionState
    {
     


        private AccountingBookBLL objACBLL = new AccountingBookBLL();

        private string Format = "dd/MM/yyyy";

        private CultureInfo provider = CultureInfo.InvariantCulture;

        private VATReturnBLL objBLL = new VATReturnBLL();

        protected global_asax ApplicationInstance
        {
            get
            {
                return (global_asax)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public VDSStatements()
        {
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fromDate.Text) || string.IsNullOrEmpty(this.toDate.Text))
            {
                this.msgBox.AddMessage(" Enter from date and to date ", MsgBoxs.enmMessageType.Attention);
                return;
            }
            this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            this.lblUser.Text = this.Session["employee_name"].ToString();
            DateTime dateTime = DateTime.ParseExact(this.fromDate.Text.ToString(), this.Format, this.provider);
            DateTime dateTime1 = DateTime.ParseExact(this.toDate.Text.ToString(), this.Format, this.provider);
            DateTime dateTime2 = dateTime1.AddDays(1);
            this.lfDate.Text = dateTime.ToString("dd-MMM-yyyy");
            this.ltDate.Text = dateTime1.ToString("dd-MMM-yyyy");
            this.loadReport(dateTime, dateTime2);
            this.btnPrint.Visible = true;
        }

        private void loadReport(DateTime fDate, DateTime tDate)
        {
            string str = "";
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            int num3 = -99;
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            try
            {
                int num7 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                num3 = Convert.ToInt16(this.drpVDSstatus.SelectedValue);
                DataTable allVDSItemByDate = this.objACBLL.GetAllVDSItemByDate(fDate, tDate, num3);
                if (allVDSItemByDate.Rows.Count <= 0)
                {
                    this.lblReportHtml.Text = str;
                    this.msgBox.AddMessage(" Data Not Found ", MsgBoxs.enmMessageType.Attention);
                }
                else
                {
                    for (int i = 0; i < allVDSItemByDate.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(allVDSItemByDate.Rows[i]["item_amount"]);
                        num1 = Convert.ToDecimal(allVDSItemByDate.Rows[i]["percent"]);
                        num2 = Convert.ToDecimal(allVDSItemByDate.Rows[i]["vds_amount"]);
                        str = string.Concat(str, "<tr>");
                        object obj = str;
                        object[] objArray = new object[] { obj, "<td style='text-align:left'>", i + 1, "</td>" };
                        str = string.Concat(objArray);
                        str = string.Concat(str, "<td text-align:left;padding-center:5px>", allVDSItemByDate.Rows[i]["challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td text-align:right;padding-center:5px>", allVDSItemByDate.Rows[i]["date_challan"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", allVDSItemByDate.Rows[i]["party_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", allVDSItemByDate.Rows[i]["item"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num, num7), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num1, num7), "%</td>");
                        str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num2, num7), "</td>");
                        str = string.Concat(str, "<td style='text-align:left;padding-right:5px'>", allVDSItemByDate.Rows[i]["vds_cert_issued_no"].ToString(), "</td>");
                        str = (allVDSItemByDate.Rows[i]["vds_cert_issued_no"].ToString() == "" ? string.Concat(str, "<td style='text-align:right;padding-right:5px'></td>") : string.Concat(str, "<td style='text-align:center;padding-right:5px'>", allVDSItemByDate.Rows[i]["vds_cert_issued_date"].ToString(), "</td>"));
                        str = (allVDSItemByDate.Rows[i]["vds_cert_issued_date"].ToString() == "" ? string.Concat(str, "<td style='text-align:right;padding-right:5px'></td>") : string.Concat(str, "<td style='text-align:center;padding-right:5px'>", allVDSItemByDate.Rows[i]["vds_cert_issued_date"].ToString(), "</td>"));
                        if (allVDSItemByDate.Rows[i]["amount"].ToString() != "")
                        {
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(allVDSItemByDate.Rows[i]["amount"]), num7), "</td>");
                            num6 += Convert.ToDecimal(allVDSItemByDate.Rows[i]["amount"]);
                        }
                        else
                        {
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'></td>");
                        }
                        str = string.Concat(str, "<td style='text-align:left;padding-right:5px'>", allVDSItemByDate.Rows[i]["challan_numbers"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:center;padding-right:5px'>", allVDSItemByDate.Rows[i]["trdate_challan"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", allVDSItemByDate.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num4 += num;
                        num5 += num2;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='5' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.RoundUpToWithString(num4, num7), "</td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.RoundUpToWithString(num5, num7), "</td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.RoundUpToWithString(num6, num7), "</td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<tr>");
                    this.lblReportHtml.Text = str;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.fromDate.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.toDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
    }
}