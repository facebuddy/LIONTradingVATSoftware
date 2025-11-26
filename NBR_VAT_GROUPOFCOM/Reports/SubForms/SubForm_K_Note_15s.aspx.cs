using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports.SubForms
{
    public partial class SubForm_K_Note_15s : Page, IRequiresSessionState
    {
        protected LinkButton btnPrint;

        protected Label lblReportHtml;

        protected HtmlGenericControl reportMain;

        private VATReturnBLL objVatReturn = new VATReturnBLL();

        private CSVXMLBLL dbBLL = new CSVXMLBLL();

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

        public SubForm_K_Note_15s()
        {
        }

        private void LoadReport()
        {
            try
            {
                string str = "";
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                int num8 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num9 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                DataTable vatReturnPart4DataRow15DataSubReport = this.dbBLL.getVatReturnPart4DataRow15DataSubReport(str1, str2, num9);
                if (vatReturnPart4DataRow15DataSubReport != null && vatReturnPart4DataRow15DataSubReport.Rows.Count > 0)
                {
                    for (int i = 0; i < vatReturnPart4DataRow15DataSubReport.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(vatReturnPart4DataRow15DataSubReport.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(vatReturnPart4DataRow15DataSubReport.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(vatReturnPart4DataRow15DataSubReport.Rows[i]["vat"]);
                        num3 = Convert.ToDecimal(vatReturnPart4DataRow15DataSubReport.Rows[i]["at"]);
                        str = string.Concat(str, "<tr  style='border: 2px solid; '>");
                        int num10 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num10.ToString()), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["date_challan"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["port_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["no_of_item"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["cpc"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["details"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["hs_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["assesment_amount"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num8))), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow15DataSubReport.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num5 += num1;
                        num6 += num2;
                        num4 += num;
                        num7 += num3;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='10' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num8))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num8))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num6, num8))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num7, num8))), "</td>");
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
                this.LoadReport();
            }
        }
    }
}