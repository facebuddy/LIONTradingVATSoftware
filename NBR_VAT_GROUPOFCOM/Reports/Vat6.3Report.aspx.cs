using NBR_VAT_GROUPOFCOM.Api;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class Vat6__3Report : System.Web.UI.Page
    {
        private VATReturnBLL objVatReturn = new VATReturnBLL();

        private CSVXMLBLL dbBLL = new CSVXMLBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           // LoadReport();
        }

        private void LoadReport(List<InvoiceVw> list)
        {
            try
            {
                string str = "";
                int i = 0;
                foreach(var item in list)
                    {
                      
                        str = string.Concat(str, "<tr style='border: 2px solid; '>");
                         i = i + 1;
                        str = string.Concat(str, "<td  style='text-align:center;'>", i.ToString(), "</td>");
                        str = string.Concat(str, "<td class='id' style='text-align:center;'>", item.invoice_no , "</td>");
                        str = string.Concat(str, "<td>", item.sales_date.ToString("dd-MM-yyyy h:mm tt"), "</td>");
                        str = string.Concat(str, "<td style='text-align:left;'>", item.company_name, "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", item.total_netamount, "</td>");
                        string str3 = str;
                        string[] strArrays = new string[] { str3, "<td><button type='button' class='btn'>Print</button></td>" };
                        str = string.Concat(strArrays);
                        str = string.Concat(str, "</tr>");
                      
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='4' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", 5, "</td>");
                    str = string.Concat(str, "<tr>");
                    this.lblReportHtml.Text = str;
                
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            string dt1 = dtpDateFrom.Text;
            string dt2 = dtpDateTo.Text;

            var invoiceList = MushakAPI.getInvoceList(dt1, dt2);

            LoadReport(invoiceList);
        }
    }
}