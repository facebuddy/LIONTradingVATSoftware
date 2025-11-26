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
    public partial class Details_Note_33s : Page, IRequiresSessionState
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

        public Details_Note_33s()
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
                int num3 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num4 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                DataTable details33 = this.dbBLL.getDetails33(str1, str2, num4);
                if (details33 != null && details33.Rows.Count > 0)
                {
                    for (int i = 0; i < details33.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(details33.Rows[i]["rent"]);
                        num2 = Convert.ToDecimal(details33.Rows[i]["VAT"]);
                        if (details33.Rows[i]["interest_pct"].ToString() != "")
                        {
                            Convert.ToDecimal(details33.Rows[i]["interest_pct"]);
                        }
                        if (details33.Rows[i]["interest_amount"].ToString() != "")
                        {
                            Convert.ToDecimal(details33.Rows[i]["interest_amount"]);
                        }
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num5 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", num5.ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:center;'>", details33.Rows[i]["note_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", details33.Rows[i]["date_note"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num3))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num3))), "</td>");
                        string str3 = str;
                        string[] strArrays = new string[] { str3, "<td>", details33.Rows[i]["oa_case_no"].ToString(), "  ", details33.Rows[i]["particulars"].ToString(), "</td>" };
                        str = string.Concat(strArrays);
                        str = string.Concat(str, "</tr>");
                        num1 += num2;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num3))), "</td>");
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