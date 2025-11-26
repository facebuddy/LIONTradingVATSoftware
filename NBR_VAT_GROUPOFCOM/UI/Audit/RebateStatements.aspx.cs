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
    public partial class RebateStatements : Page, IRequiresSessionState
    {
        private AccountingBookBLL objACBLL = new AccountingBookBLL();

        private string Format = "dd/MM/yyyy";

        private CultureInfo provider = CultureInfo.InvariantCulture;

       

      


 
        public RebateStatements()
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
            try
            {
                int num1 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                DataTable allRebatableData = this.objACBLL.GetAllRebatableData(fDate, tDate);
                if (allRebatableData.Rows.Count <= 0)
                {
                    this.lblReportHtml.Text = str;
                    this.msgBox.AddMessage(" Data Not Found ", MsgBoxs.enmMessageType.Attention);
                }
                else
                {
                    for (int i = 0; i < allRebatableData.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(allRebatableData.Rows[i]["rebat_amount"]);
                        str = string.Concat(str, "<tr>");
                        object obj = str;
                        object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                        str = string.Concat(objArray);
                        str = string.Concat(str, "<td>", allRebatableData.Rows[i]["challan_no_date"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", allRebatableData.Rows[i]["item"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(allRebatableData.Rows[i]["quantity"])), "</td>");
                        str = string.Concat(str, "<td></td>");
                        str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num, num1), "</td>");
                        str = string.Concat(str, "<td>", allRebatableData.Rows[i]["remark"].ToString(), "</td>");
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