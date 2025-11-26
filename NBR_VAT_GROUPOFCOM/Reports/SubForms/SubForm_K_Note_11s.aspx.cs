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
    public partial class SubForm_K_Note_11s : Page, IRequiresSessionState
    {
        private VATReturnBLL objVatReturn = new VATReturnBLL();

        private CSVXMLBLL dbBLL = new CSVXMLBLL();

        protected LinkButton btnPrint;

        protected Label lblReportHtml;

        protected HtmlGenericControl reportMain;

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

        public SubForm_K_Note_11s()
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
                DataTable vatReturnPart4DataRow11SubReport = this.dbBLL.getVatReturnPart4DataRow11SubReport(str1, str2, num9);
                if (vatReturnPart4DataRow11SubReport != null && vatReturnPart4DataRow11SubReport.Rows.Count > 0)
                {
                    for (int i = 0; i < vatReturnPart4DataRow11SubReport.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(vatReturnPart4DataRow11SubReport.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(vatReturnPart4DataRow11SubReport.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(vatReturnPart4DataRow11SubReport.Rows[i]["vat"]);
                        num4 = Convert.ToDecimal(vatReturnPart4DataRow11SubReport.Rows[i]["at"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num10 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num10.ToString()), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["date_challan"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["port_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["no_of_item"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["cpc"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["details"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["hs_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(Convert.ToDecimal(vatReturnPart4DataRow11SubReport.Rows[i]["assesment_amount"]), num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num8))), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow11SubReport.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num6 += num1;
                        num7 += num2;
                        num3 += num;
                        num5 += num4;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='10' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num8))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num6, num8))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num7, num8))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num8))), "</td>");
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