using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Quantity
    {
        private int itemID;

        private long availQantity;

        private string ingredentName;

        private int unitID;

        private short rowNo;

        public long AvailQantity
        {
            get
            {
                return this.availQantity;
            }
            set
            {
                this.availQantity = value;
            }
        }

        public string IngredentName
        {
            get
            {
                return this.ingredentName;
            }
            set
            {
                this.ingredentName = value;
            }
        }

        public int ItemID
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

        public short RowNo
        {
            get
            {
                return this.rowNo;
            }
            set
            {
                this.rowNo = value;
            }
        }

        public int UnitID
        {
            get
            {
                return this.unitID;
            }
            set
            {
                this.unitID = value;
            }
        }

        public Quantity()
        {
        }
    }
}