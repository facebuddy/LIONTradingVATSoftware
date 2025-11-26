using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.ModelVW
{
    public class VatSixOneObj
    {
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public int opening_balance { get; set; }
        public List<VatSixOne> vatList { get; set; }
    }
}