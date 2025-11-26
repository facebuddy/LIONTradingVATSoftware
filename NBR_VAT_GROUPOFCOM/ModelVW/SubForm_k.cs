using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.ModelVW
{
    public class SubForm_k
    {
        public int Id { get; set; }
        public string prduct_description { get; set; }
        public string prduct_name { get; set; }
        public string sh_code { get; set; }
        public decimal netamount { get; set; }
        public decimal vat_amount { get; set; }
        public string sampurakShulka { get; set; }
        public string vat { get; set; }

    }
}