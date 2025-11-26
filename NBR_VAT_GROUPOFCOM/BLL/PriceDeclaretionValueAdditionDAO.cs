using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class PriceDeclaretionValueAdditionDAO
    {
        private int priceID;

        private int valueAdditionD;

        private decimal itemValue;

        private int userIDInsert;

        public decimal decItemValue
        {
            get
            {
                return this.itemValue;
            }
            set
            {
                this.itemValue = value;
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

        public int intValueAdditionD
        {
            get
            {
                return this.valueAdditionD;
            }
            set
            {
                this.valueAdditionD = value;
            }
        }

        public int RowNo
        {
            get;
            set;
        }

        public string valueAddition
        {
            get;
            set;
        }

        public PriceDeclaretionValueAdditionDAO()
        {
        }
    }
}
