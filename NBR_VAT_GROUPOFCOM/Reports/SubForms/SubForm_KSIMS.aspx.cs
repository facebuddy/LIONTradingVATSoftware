using ASP;
using NBR_VAT_GROUPOFCOM.Api;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.ModelVW;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.Reports.SubForms
{
    public partial class SubForm_KSIMS : Page, IRequiresSessionState
    {
        protected LinkButton btnPrint;

        protected Label lblReportHtml;

        protected HtmlGenericControl reportMain;

        private NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL objVatReturn = new NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL();

        private NBR_VAT_GROUPOFCOM.BLL.CSVXMLBLL dbBLL = new NBR_VAT_GROUPOFCOM.BLL.CSVXMLBLL();

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

        public SubForm_KSIMS()
        {
        }




        public void LoadMukhak(string start_date, string end_date)
        {


            var salesList = MushakAPI.LoadMukhak(start_date, end_date);



            try
            {
                string str = "";
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
              int num6 = 2;
                int num7 = 98;
               // string str1 = HttpContext.Current.Session["fDateSub"].ToString();
               // string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                //  DataTable vatReturnPart3DataSubReport = this.dbBLL.getVatReturnPart3DataSubReport(str1, str2, num7);
                int i = 0;
                if (salesList != null)
                {
                    foreach (var item in salesList)
                    {
                        item.vat = "15% Vat";
                        num = Convert.ToDecimal(item.netamount);
                        num1 = Convert.ToDecimal(0);
                        num2 = Convert.ToDecimal(item.vat_amount);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num8 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num8.ToString()), "</td>");
                        str = string.Concat(str, "<td>", item.prduct_description.ToString(), "</td>");
                        str = string.Concat(str, "<td>", item.sh_code, "</td>");
                        str = string.Concat(str, "<td>", item.sh_code, "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(NBR_VAT_GROUPOFCOM.BLL.Utilities.RoundUpToWithString(num, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num6))), "</td>");
                        str = string.Concat(str, "<td>", item.vat.ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num4 += num1;
                        num5 += num2;
                        num3 += num;
                        i = i + 1;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num6))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num6))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num6))), "</td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<tr>");
                    this.lblReportHtmlSIMS.Text = str;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }







            //  List<SalesDetailView> salesObjectList = new List<SalesDetailView>();
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
                int num6 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num7 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();
                DataTable vatReturnPart3DataSubReport = this.dbBLL.getVatReturnPart3DataSubReport(str1, str2, num7);
                if (vatReturnPart3DataSubReport != null && vatReturnPart3DataSubReport.Rows.Count > 0)
                {
                    for (int i = 0; i < vatReturnPart3DataSubReport.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(vatReturnPart3DataSubReport.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(vatReturnPart3DataSubReport.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(vatReturnPart3DataSubReport.Rows[i]["vat"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num8 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num8.ToString()), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataSubReport.Rows[i]["details"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataSubReport.Rows[i]["hs_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataSubReport.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num6))), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart3DataSubReport.Rows[i]["remarks"].ToString(), "</td>");
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
                    this.lblReportHtmlSIMS.Text = str;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string startDate = Request.QueryString["start_date"];

            string endDate = Request.QueryString["end_date"];

            LoadMukhak(startDate, endDate);
        }
    }
}