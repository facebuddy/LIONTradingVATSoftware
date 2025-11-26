using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsProductionDetailDAO
    {
        private int productionId;

        private int rowNo;

        private int itemId;

        private short propertyId1;

        private short propertyId2;

        private short propertyId3;

        private short propertyId4;

        private short propertyId5;

        private int unitId;

        private int quantity;

        private double unitPrice;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        public DateTime DateInsert
        {
            get
            {
                return this.dateInsert;
            }
            set
            {
                this.dateInsert = value;
            }
        }

        public DateTime DateUpdate
        {
            get
            {
                return this.dateUpdate;
            }
            set
            {
                this.dateUpdate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this.isDeleted;
            }
            set
            {
                this.isDeleted = value;
            }
        }

        public int ItemId
        {
            get
            {
                return this.itemId;
            }
            set
            {
                this.itemId = value;
            }
        }

        public int ProductionId
        {
            get
            {
                return this.productionId;
            }
            set
            {
                this.productionId = value;
            }
        }

        public short PropertyId1
        {
            get
            {
                return this.propertyId1;
            }
            set
            {
                this.propertyId1 = value;
            }
        }

        public short PropertyId2
        {
            get
            {
                return this.propertyId2;
            }
            set
            {
                this.propertyId2 = value;
            }
        }

        public short PropertyId3
        {
            get
            {
                return this.propertyId3;
            }
            set
            {
                this.propertyId3 = value;
            }
        }

        public short PropertyId4
        {
            get
            {
                return this.propertyId4;
            }
            set
            {
                this.propertyId4 = value;
            }
        }

        public short PropertyId5
        {
            get
            {
                return this.propertyId5;
            }
            set
            {
                this.propertyId5 = value;
            }
        }

        public int Quantity
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

        public int RowNo
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

        public int UnitId
        {
            get
            {
                return this.unitId;
            }
            set
            {
                this.unitId = value;
            }
        }

        public double UnitPrice
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

        public short UserIdInsert
        {
            get
            {
                return this.userIdInsert;
            }
            set
            {
                this.userIdInsert = value;
            }
        }

        public short UserIdUpdate
        {
            get
            {
                return this.userIdUpdate;
            }
            set
            {
                this.userIdUpdate = value;
            }
        }

        public trnsProductionDetailDAO()
        {
        }
    }
}
