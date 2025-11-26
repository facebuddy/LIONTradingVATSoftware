using ASP;
using NBR_VAT_GROUPOFCOM.Api;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports.SubForms
{
    public partial class Subform_Note_31s : Page, IRequiresSessionState
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

        public Subform_Note_31s()
        {
        }

        private void loadSubReport()
        {
            try
            {
                string str3 = HttpContext.Current.Session["fDateSubs"].ToString();
                string str4 = HttpContext.Current.Session["tDateSubs"].ToString();
                string start_date = Convert.ToDateTime(str3).ToString("yyyy-MM-dd");
                string end_date = Convert.ToDateTime(str4).ToString("yyyy-MM-dd");
                var returnList = MushakAPI.Subform_Note_31API(start_date, end_date);


                DataTable dataTable = new DataTable();
                ArrayList arrayLists = new ArrayList();
                string str = "";
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                int num3 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num4 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                dataTable = this.dbBLL.getSubformData31(str1, str2, num4);
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        decimal num7 = new decimal(0);
                        num5 = Convert.ToDecimal(dataTable.Rows[i]["note_price"]);
                        num6 = Convert.ToDecimal(dataTable.Rows[i]["note_vat"]);
                        num7 = Convert.ToDecimal(dataTable.Rows[i]["note_sd"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num8 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", num8.ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:center;'>", dataTable.Rows[i]["note_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", dataTable.Rows[i]["note_date"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:center;'>", dataTable.Rows[i]["challan_challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", dataTable.Rows[i]["challan_challan_date"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num3))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["quantity"])))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num6, num3))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num7, num3))), "</td>");
                        str = string.Concat(str, "<td>", dataTable.Rows[i]["return_reason"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num += num5;
                        num2 += num6;
                        num1 += num7;
                    }


                }





                int j = 0;
                if (returnList != null)
                {
                    foreach (var item in returnList)
                    {
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        decimal num7 = new decimal(0);
                        num5 = Convert.ToDecimal(item.netamount);
                        num6 = Convert.ToDecimal(item.vat_amount);
                        num7 = Convert.ToDecimal(0);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        j = j + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", j, "</td>");
                        str = string.Concat(str, "<td style='text-align:center;'>", item.return_invoice_no, "</td>");
                        str = string.Concat(str, "<td>", item.return_date, "</td>");
                        str = string.Concat(str, "<td style='text-align:center;'>", item.ref_invoice_no, "</td>");
                        str = string.Concat(str, "<td>", item.return_date, "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num3))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.formatFraction(Convert.ToDecimal(item.return_qty)))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num6, num3))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num7, num3))), "</td>");
                        str = string.Concat(str, "<td>", item.remarks, "</td>");
                        str = string.Concat(str, "</tr>");
                        num += num5;
                        num2 += num6;
                        num1 += num7;
                    }
                }



                str = string.Concat(str, "<tr style='border:2px solid black;'>");
                str = string.Concat(str, "<td colspan='5' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num3))), "</td>");
                str = string.Concat(str, "<td></td>");
                str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num3))), "</td>");
                str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num3))), "</td>");
                str = string.Concat(str, "<tr>");
                this.lblReportHtml.Text = str;



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
                this.loadSubReport();
            }
        }
    }
}