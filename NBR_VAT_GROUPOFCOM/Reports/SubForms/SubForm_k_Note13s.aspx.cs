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
    public partial class SubForm_k_Note13s : Page, IRequiresSessionState
    {

        private VATReturnBLL objVatReturn = new VATReturnBLL();

        private CSVXMLBLL dbBLL = new CSVXMLBLL();

      

        public SubForm_k_Note13s()
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
                DataTable subFormKaNote13 = this.dbBLL.getSubFormKa_Note13(str1, str2, num9);
                if (subFormKaNote13 != null && subFormKaNote13.Rows.Count > 0)
                {
                    for (int i = 0; i < subFormKaNote13.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(subFormKaNote13.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(subFormKaNote13.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(subFormKaNote13.Rows[i]["vat"]);
                        num4 = Convert.ToDecimal(subFormKaNote13.Rows[i]["at"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num10 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num10.ToString()), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["date_challan"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["port_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["no_of_item"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["cpc"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["details"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["hs_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["assesment_amount"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num8))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num8))), "</td>");
                        str = string.Concat(str, "<td>", subFormKaNote13.Rows[i]["remarks"].ToString(), "</td>");
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