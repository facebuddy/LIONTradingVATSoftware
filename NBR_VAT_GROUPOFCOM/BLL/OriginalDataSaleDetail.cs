using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OriginalDataSaleDetail
    {
        public decimal actual_price
        {
            get;
            set;
        }

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

        public DateTime date_insert
        {
            get;
            set;
        }

        public int item_id
        {
            get;
            set;
        }

        public decimal quantity
        {
            get;
            set;
        }

        public int row_no
        {
            get;
            set;
        }

        public decimal? sd
        {
            get;
            set;
        }

        public decimal? vat
        {
            get;
            set;
        }

        public decimal? vds_amount
        {
            get;
            set;
        }

        public OriginalDataSaleDetail()
        {
        }
    }
}