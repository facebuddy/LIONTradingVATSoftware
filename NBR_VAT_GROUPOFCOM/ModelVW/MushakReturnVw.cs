using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.ModelVW
{
    public class MushakReturnVw
    {
        public int id { get; set;}
        public string kreata_name { get; set; }
        public string address_a { get; set; }
        public string bin { get; set; }
        public string invoice_no { get; set; }
        public string return_date { get; set; }
        public string return_invoice_no { get; set; }
        public int sale_qty { get; set; }
        public int return_qty { get; set; }
        public decimal sales_netamount { get; set; }
        public decimal return_netamount { get; set; }
        public decimal sales_vatamount { get; set; }
        public decimal return_vatamount { get; set;}
    }
}