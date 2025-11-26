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
    public partial class PriceDeclarationInformations : Page, IRequiresSessionState
    {
      


        private AccountingBookBLL objACBLL = new AccountingBookBLL();

        private string Format = "dd/MM/yyyy";

        private CultureInfo provider = CultureInfo.InvariantCulture;

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

        public PriceDeclarationInformations()
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
            decimal num3 = new decimal(0);
            try
            {
                int num4 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                DataTable priceDeclarationData = this.objACBLL.GetPriceDeclarationData(fDate, tDate);
                if (priceDeclarationData.Rows.Count <= 0)
                {
                    this.lblReportHtml.Text = str;
                    this.msgBox.AddMessage(" Data Not Found ",MsgBoxs.enmMessageType.Attention);
                }
                else
                {
                    for (int i = 0; i < priceDeclarationData.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(priceDeclarationData.Rows[i]["rm_price"]);
                        num1 = Convert.ToDecimal(priceDeclarationData.Rows[i]["others_value"]);
                        num2 = Convert.ToDecimal(priceDeclarationData.Rows[i]["proposed_amount"]);
                        num3 = Convert.ToDecimal(priceDeclarationData.Rows[i]["confirmed_price"]);
                        str = string.Concat(str, "<tr>");
                        object obj = str;
                        object[] objArray = new object[] { obj, "<td style='text-align:center'>", i + 1, "</td>" };
                        str = string.Concat(objArray);
                        str = string.Concat(str, "<td>", priceDeclarationData.Rows[i]["pd_submit_date"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", priceDeclarationData.Rows[i]["pd_approve_date"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", priceDeclarationData.Rows[i]["item"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", priceDeclarationData.Rows[i]["sale_unit"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right; padding-right:5px'>", Utilities.RoundUpToWithString(num, num4), "</td>");
                        str = string.Concat(str, "<td style='text-align:right; padding-right:5px'>", Utilities.RoundUpToWithString(num1, num4), "</td>");
                        str = string.Concat(str, "<td style='text-align:center'>", priceDeclarationData.Rows[i]["vat"].ToString(), "%</td>");
                        str = string.Concat(str, "<td style='text-align:right; padding-right:5px'>", Utilities.RoundUpToWithString(num2, num4), "</td>");
                        str = string.Concat(str, "<td style='text-align:right; padding-right:5px'>", Utilities.RoundUpToWithString(num3, num4), "</td>");
                        str = string.Concat(str, "<td style='text-align:center'>N/A</td>");
                        str = string.Concat(str, "</tr>");
                        this.lblReportHtml.Text = str;
                    }
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