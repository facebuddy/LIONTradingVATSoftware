using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsBandrollUsageDetailsDAO
    {
        private short challanId;

        private short rowNo;

        private short rcvChallanId;

        private short bandrollId;

        private string bandrollDetail;

        private double quantity;

        private double unitPrice;

        private short itemId;

        private string itemName;

        private short property1;

        private short property2;

        private short property3;

        private short property4;

        private short property5;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        public string BandrollDetail
        {
            get
            {
                return this.bandrollDetail;
            }
            set
            {
                this.bandrollDetail = value;
            }
        }

        public short BandrollId
        {
            get
            {
                return this.bandrollId;
            }
            set
            {
                this.bandrollId = value;
            }
        }

        public short ChallanId
        {
            get
            {
                return this.challanId;
            }
            set
            {
                this.challanId = value;
            }
        }

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

        public short ItemId
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

        public string ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        public short Property1
        {
            get
            {
                return this.property1;
            }
            set
            {
                this.property1 = value;
            }
        }

        public short Property2
        {
            get
            {
                return this.property2;
            }
            set
            {
                this.property2 = value;
            }
        }

        public short Property3
        {
            get
            {
                return this.property3;
            }
            set
            {
                this.property3 = value;
            }
        }

        public short Property4
        {
            get
            {
                return this.property4;
            }
            set
            {
                this.property4 = value;
            }
        }

        public short Property5
        {
            get
            {
                return this.property5;
            }
            set
            {
                this.property5 = value;
            }
        }

        public double Quantity
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

        public short RcvChallanId
        {
            get
            {
                return this.rcvChallanId;
            }
            set
            {
                this.rcvChallanId = value;
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

        public trnsBandrollUsageDetailsDAO()
        {
        }
    }
}