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
    public partial class SubForm_Gha_Note_18s : Page, IRequiresSessionState
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

        public SubForm_Gha_Note_18s()
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
                DataTable vatSubFormNote18 = this.dbBLL.getVatSubFormNote18(str1, str2, num9);
                if (vatSubFormNote18 != null && vatSubFormNote18.Rows.Count > 0)
                {
                    for (int i = 0; i < vatSubFormNote18.Rows.Count; i++)
                    {
                        num6 = Convert.ToDecimal(vatSubFormNote18.Rows[i]["quantity"]);
                        Utilities.formatFraction(num6);
                        num = Convert.ToDecimal(vatSubFormNote18.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(vatSubFormNote18.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(vatSubFormNote18.Rows[i]["vat"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '> ");
                        int num10 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num10.ToString()), "</td>");
                        str = string.Concat(str, "<td>", vatSubFormNote18.Rows[i]["details"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatSubFormNote18.Rows[i]["hs_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatSubFormNote18.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num8))), "</td>");
                        str = string.Concat(str, "<td>", vatSubFormNote18.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num7 += num6;
                        num4 += num1;
                        num5 += num2;
                        num3 += num;
                        Utilities.formatFraction(num7);
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num8))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num8))), "</td>");
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