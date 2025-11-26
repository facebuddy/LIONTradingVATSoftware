using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.Model
{
    public class InvoiceVw
    {
        public int id { get; set; }
        public string invoice_no { get; set; }
        public decimal total_netamount { get; set; }
        public DateTime sales_date { get; set; }
        public decimal total_vat { get; set; }
        public string company_name { get; set; }
    }
}