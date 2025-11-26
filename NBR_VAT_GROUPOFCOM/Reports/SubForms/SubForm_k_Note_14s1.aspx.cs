using ASP;
using NBR_VAT_GROUPOFCOM.Api;
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
    public partial class SubForm_k_Note_14s1 : System.Web.UI.Page
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

        public SubForm_k_Note_14s1()
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
                int num6 = Convert.ToInt32(HttpContext.Current.Session["precision"].ToString());
                int num7 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = HttpContext.Current.Session["fDateSub"].ToString();
                string str2 = HttpContext.Current.Session["tDateSub"].ToString();


                string start_date = Convert.ToDateTime(HttpContext.Current.Session["fDateSubs"]).ToString("yyyy-MM-dd");
                string end_date = Convert.ToDateTime(HttpContext.Current.Session["tDateSubs"]).ToString("yyyy-MM-dd");
               // var purchaseList = MushakAPI.SubForm_k_Note_14(start_date, end_date);


                DataTable vatReturnPart4DataRow14DataSubReport = this.dbBLL.getVatReturnPart4DataRow14DataSubReport(str1, str2, num7);
                int j = 0;
                if (vatReturnPart4DataRow14DataSubReport != null && vatReturnPart4DataRow14DataSubReport.Rows.Count > 0)
                {
                    for (int i = 0; i < vatReturnPart4DataRow14DataSubReport.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(vatReturnPart4DataRow14DataSubReport.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(vatReturnPart4DataRow14DataSubReport.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(vatReturnPart4DataRow14DataSubReport.Rows[i]["vat"]);
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                        int num8 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num8.ToString()), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow14DataSubReport.Rows[i]["details"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow14DataSubReport.Rows[i]["hs_code"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow14DataSubReport.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num6))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num6))), "</td>");
                        str = string.Concat(str, "<td>", vatReturnPart4DataRow14DataSubReport.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num4 += num1;
                        num5 += num2;
                        num3 += num;
                        j =j+ 1;
                    }


                 




                }

                //if (purchaseList != null)
                //{
                //    foreach(var item in purchaseList)
                //    {
                //        num = item.price;
                //        num1 = Convert.ToDecimal(item.sd);
                //        num2 = Convert.ToDecimal(item.vat);
                //        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                //        j = j + 1;
                //        int num8 = j;
                //        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num8.ToString()), "</td>");
                //        str = string.Concat(str, "<td>", item.item_name.ToString(), "</td>");
                //        str = string.Concat(str, "<td>", item.hs_code, "</td>");
                //        str = string.Concat(str, "<td>", item.item_name, "</td>");
                //        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num6))), "</td>");
                //        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num6))), "</td>");
                //        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num6))), "</td>");
                //        str = string.Concat(str, "<td>", item.remarks, "</td>");
                //        str = string.Concat(str, "</tr>");
                //        num4 += num1;
                //        num5 += num2;
                //        num3 += num;
                //    }
                 

                //}
                str = string.Concat(str, "<tr style='border:2px solid black;'>");
                str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num6))), "</td>");
                str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num6))), "</td>");
                str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num6))), "</td>");
                str = string.Concat(str, "<td></td>");
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
         
                this.LoadReport();
            
        }
    }
}