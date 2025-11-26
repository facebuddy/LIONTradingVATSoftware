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
    public partial class SubForm_CHs : System.Web.UI.Page
    {
        private VATReturnBLL objVatReturn = new VATReturnBLL();

        private CSVXMLBLL dbBLL = new CSVXMLBLL();

        protected Label lblReportHtml;

        protected LinkButton btnPrint;

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

        public SubForm_CHs()
        {
        }

        private void LoadReport()
        {
            try
            {
                string str = "";
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                int num2 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num3 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                DataTable subFormChaNote30 = this.dbBLL.getSubFormCha_Note30(str1, str2, num3);
                if (subFormChaNote30 != null && subFormChaNote30.Rows.Count > 0)
                {
                    for (int i = 0; i < subFormChaNote30.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(subFormChaNote30.Rows[i]["price"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num4 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num4.ToString()), "</td>");
                        str = string.Concat(str, "<td>", subFormChaNote30.Rows[i]["challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormChaNote30.Rows[i]["date_challan"].ToString(), "</td>");
                        str = (subFormChaNote30.Rows[i]["custom_house"].ToString() != "-- Select --" ? string.Concat(str, "<td>", subFormChaNote30.Rows[i]["custom_house"].ToString(), "</td>") : string.Concat(str, "<td></td>"));
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num2))), "</td>");
                        str = string.Concat(str, "<td>", subFormChaNote30.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num1 += num;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num2))), "</td>");
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