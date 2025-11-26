using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class WOGoodsDAO
    {
        public decimal AvailableStock
        {
            get;
            set;
        }

        public decimal Discount
        {
            get;
            set;
        }

        public int ItemID
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }

        public int PriceID
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public int RowNo
        {
            get;
            set;
        }

        public decimal Tax
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public int UnitID
        {
            get;
            set;
        }

        public string UnitName
        {
            get;
            set;
        }

        public decimal UnitPrice
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public WOGoodsDAO()
        {
        }
    }
}