using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PriceDeclaretionRawDAO
    {
        private int priceID;

        private int itemID;

        private int unitID;

        private int unitIDSecond;

        private decimal quantity;

        private decimal wastageQuantity;

        private decimal unitPrice;

        private int userIDInsert;

        public decimal decQuantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public decimal decUnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }

        public decimal decWastageQuantity
        {
            get
            {
                return this.wastageQuantity;
            }
            set
            {
                this.wastageQuantity = value;
            }
        }

        public int intItemId
        {
            get
            {
                return this.itemID;
            }
            set
            {
                this.itemID = value;
            }
        }

        public int intPriceID
        {
            get
            {
                return this.priceID;
            }
            set
            {
                this.priceID = value;
            }
        }

        public int intUnitId
        {
            get
            {
                return this.unitIDSecond;
            }
            set
            {
                this.unitIDSecond = value;
            }
        }

        public int intUserIdInsert
        {
            get
            {
                return this.userIDInsert;
            }
            set
            {
                this.userIDInsert = value;
            }
        }

        public PriceDeclaretionRawDAO()
        {
        }
    }
}