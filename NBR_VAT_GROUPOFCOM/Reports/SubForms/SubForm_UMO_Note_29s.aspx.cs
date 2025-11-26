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
    public partial class SubForm_UMO_Note_29s : Page, IRequiresSessionState
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

        public SubForm_UMO_Note_29s()
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
                int num4 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num5 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                DataTable vatReturnNote29SubReport = this.dbBLL.getVatReturnNote29SubReport(str1, str2, num5);
                if (vatReturnNote29SubReport != null && vatReturnNote29SubReport.Rows.Count > 0)
                {
                    for (int i = 0; i < vatReturnNote29SubReport.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(vatReturnNote29SubReport.Rows[i]["price1"]);
                        num1 = Convert.ToDecimal(vatReturnNote29SubReport.Rows[i]["Vat"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num6 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num6.ToString()), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["party_bin"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["party_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["party_address"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num4))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num4))), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["date_challan"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["vds_cert_issued_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["vds_cert_issued_date"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["account_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["tax_deposit_serial_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["tax_deposit_date"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnNote29SubReport.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num3 += num1;
                        num2 += num;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num4))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num4))), "</td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<td></td>");
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
                this.LoadReport();
            }
        }
    }
}