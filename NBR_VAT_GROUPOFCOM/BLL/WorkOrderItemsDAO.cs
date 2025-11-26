using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class WorkOrderItemsDAO
    {
        public int CategoryID
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

        public int UnitID
        {
            get;
            set;
        }

        public decimal UnitPrice
        {
            get;
            set;
        }

        public int UserIDInsert
        {
            get;
            set;
        }

        public WorkOrderItemsDAO()
        {
        }
    }
}