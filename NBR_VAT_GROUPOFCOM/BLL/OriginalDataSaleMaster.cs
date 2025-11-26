using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OriginalDataSaleMaster
    {
        public long challan_id
        {
            get;
            set;
        }

        public string challan_no
        {
            get;
            set;
        }

        public int? challan_year
        {
            get;
            set;
        }

        public DateTime date_challan
        {
            get;
            set;
        }

        public bool? is_dado
        {
            get;
            set;
        }

        public bool? is_deleted
        {
            get;
            set;
        }

        public bool? is_sd_paid
        {
            get;
            set;
        }

        public bool? is_vat_paid
        {
            get;
            set;
        }

        public bool isaudited
        {
            get;
            set;
        }

        public int? payment_method
        {
            get;
            set;
        }

        public string trans_type
        {
            get;
            set;
        }

        public OriginalDataSaleMaster()
        {
        }
    }
}