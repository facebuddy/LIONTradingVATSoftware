using ASP;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using NBR_VAT_GROUPOFCOM.BLL;
namespace NBR_VAT_GROUPOFCOM.Reports.SubForms
{
    public partial class SubForm_K_Note_3s : Page, IRequiresSessionState
    {
      
        private VATReturnBLL objVatReturn = new VATReturnBLL();

        private CSVXMLBLL dbBLL = new CSVXMLBLL();

       
        public SubForm_K_Note_3s()
        {
        }

        private void LoadReport()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                int num6 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num7 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                DataTable vatReturnPart3DataRow3SubReport = this.dbBLL.getVatReturnPart3DataRow3SubReport(str1, str2, num7);
                if (vatReturnPart3DataRow3SubReport != null && vatReturnPart3DataRow3SubReport.Rows.Count > 0)
                {
                    for (int i = 0; i < vatReturnPart3DataRow3SubReport.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(vatReturnPart3DataRow3SubReport.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(vatReturnPart3DataRow3SubReport.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(vatReturnPart3DataRow3SubReport.Rows[i]["vat"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num8 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num8.ToString()), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataRow3SubReport.Rows[i]["details"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataRow3SubReport.Rows[i]["hs_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataRow3SubReport.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num6))), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataRow3SubReport.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num4 += num1;
                        num5 += num2;
                        num3 += num;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num6))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num6))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num6))), "</td>");
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
            bool isPostBack = base.IsPostBack;
            this.LoadReport();
        }
    }
}