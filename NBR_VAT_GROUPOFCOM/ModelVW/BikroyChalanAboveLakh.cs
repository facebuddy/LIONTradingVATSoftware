using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.ModelVW
{
    public class BikroyChalanAboveLakh
    {
        public int Id { get; set; }
        public string tracking_no { get; set; }
        public string chalan_date { get; set; }
        public string bikreta { get; set; }
        public string address { get; set; }
        public string vat_reg_no { get; set; }
        public string prduct_description { get; set; }
        public string item_name { get; set; }
        public string sh_code { get; set; }
        public decimal price { get; set; }
        public decimal sd { get; set; }
        public decimal vat { get; set; }
    }
}