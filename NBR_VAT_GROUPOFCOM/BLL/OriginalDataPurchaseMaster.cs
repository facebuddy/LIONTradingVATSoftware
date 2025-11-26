using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OriginalDataPurchaseMaster
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

        public DateTime date_challan
        {
            get;
            set;
        }

        public string ip_address
        {
            get;
            set;
        }

        public bool is_deleted
        {
            get;
            set;
        }

        public bool is_vat_paid
        {
            get;
            set;
        }

        public decimal lc_amount
        {
            get;
            set;
        }

        public string lc_date
        {
            get;
            set;
        }

        public string lc_no
        {
            get;
            set;
        }

        public int? payment_method
        {
            get;
            set;
        }

        public string purchase_type
        {
            get;
            set;
        }

        public string updated_cols
        {
            get;
            set;
        }

        public OriginalDataPurchaseMaster()
        {
        }
    }
}