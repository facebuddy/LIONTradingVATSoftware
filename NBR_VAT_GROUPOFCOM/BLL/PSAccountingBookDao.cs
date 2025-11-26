using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PSAccountingBookDao
    {
        public long PChallanID
        {
            get;
            set;
        }

        public decimal PurchaseAmount
        {
            get;
            set;
        }

        public string PurchaseDateChallan
        {
            get;
            set;
        }

        public int RowNo
        {
            get;
            set;
        }

        public decimal SaleAmount
        {
            get;
            set;
        }

        public string SaleDateChallan
        {
            get;
            set;
        }

        public long SChallanID
        {
            get;
            set;
        }

        public PSAccountingBookDao()
        {
        }
    }
}