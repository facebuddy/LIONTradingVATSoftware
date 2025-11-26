using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class WastemanagementDAO
    {
        private int wasteMngdetailId;

        private int itemId;

        private string itemName;

        private int usedqUnit;

        private int unit;

        private string unitName;

        private string totUnitName;

        private decimal usedQuantity;

        private decimal quantity;

        private decimal finishpQuantity;

        private decimal receivedQuantiy;

        private decimal wasteQuantity;

        private string remakrs;

        private string reason;

        private int challanId;

        private decimal purchasequantity;

        private decimal price;

        private decimal purchaseprice;

        private decimal vat;

        private DateTime expireDate;

        private DateTime challanDate;

        public DateTime ChallanDate
        {
            get
            {
                return this.challanDate;
            }
            set
            {
                this.challanDate = value;
            }
        }

        public int ChallanId
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

        public DateTime ExpireDate
        {
            get
            {
                return this.expireDate;
            }
            set
            {
                this.expireDate = value;
            }
        }

        public decimal FinishpQuantity
        {
            get
            {
                return this.finishpQuantity;
            }
            set
            {
                this.finishpQuantity = value;
            }
        }

        public int Item_id
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

        public decimal PreQuantity
        {
            get
            {
                return this.usedQuantity;
            }
            set
            {
                this.usedQuantity = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public decimal Purchaseprice
        {
            get
            {
                return this.purchaseprice;
            }
            set
            {
                this.purchaseprice = value;
            }
        }

        public decimal Purchasequantity
        {
            get
            {
                return this.purchasequantity;
            }
            set
            {
                this.purchasequantity = value;
            }
        }

        public decimal Quantity
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

        public string Reason
        {
            get
            {
                return this.reason;
            }
            set
            {
                this.reason = value;
            }
        }

        public decimal ReceivedQuantiy
        {
            get
            {
                return this.receivedQuantiy;
            }
            set
            {
                this.receivedQuantiy = value;
            }
        }

        public string Remark
        {
            get
            {
                return this.remakrs;
            }
            set
            {
                this.remakrs = value;
            }
        }

        public string TotUnitName
        {
            get
            {
                return this.totUnitName;
            }
            set
            {
                this.totUnitName = value;
            }
        }

        public int Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public string UnitName
        {
            get
            {
                return this.unitName;
            }
            set
            {
                this.unitName = value;
            }
        }

        public int UsedqUnit
        {
            get
            {
                return this.usedqUnit;
            }
            set
            {
                this.usedqUnit = value;
            }
        }

        public decimal Vat
        {
            get
            {
                return this.vat;
            }
            set
            {
                this.vat = value;
            }
        }

        public int WasteMngdetailId
        {
            get
            {
                return this.wasteMngdetailId;
            }
            set
            {
                this.wasteMngdetailId = value;
            }
        }

        public decimal WasteQuantity
        {
            get
            {
                return this.wasteQuantity;
            }
            set
            {
                this.wasteQuantity = value;
            }
        }

        public WastemanagementDAO()
        {
        }
    }
}