using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.ModelVW
{
    public class SalesChalanAboveLakh
    {
        public int Id { get; set; }
        public string invoice_no { get; set; }
        public string kreta_name { get; set; }
        public string issue_date { get; set; }
        public decimal price { get; set; }
        public string address { get; set; }
        public string vat_reg_no { get; set; }
    }
}