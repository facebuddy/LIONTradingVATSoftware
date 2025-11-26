using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class PrincipalInput
    {
        public decimal? Cost
        {
            get;
            set;
        }

        public decimal? GrossUsages
        {
            get;
            set;
        }

        public int GrossUsagesUnit
        {
            get;
            set;
        }

        public int? ItemId
        {
            get;
            set;
        }

        public decimal? NeatUsages
        {
            get;
            set;
        }

        public decimal? NumberOfProduction
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public int? RowNo
        {
            get;
            set;
        }

        public decimal? ShipmentCost
        {
            get;
            set;
        }

        public decimal? ShipmentQuantity
        {
            get;
            set;
        }

        public int? ShipmentReference
        {
            get;
            set;
        }

        public decimal? Stock
        {
            get;
            set;
        }

        public int? StockUnit
        {
            get;
            set;
        }

        public int? SubCategoryId
        {
            get;
            set;
        }

        public decimal? Wastage
        {
            get;
            set;
        }

        public decimal? WastagePercent
        {
            get;
            set;
        }

        public PrincipalInput()
        {
        }
    }
}