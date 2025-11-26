using System;
using System.Runtime.CompilerServices;


namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class SaleGiftDetailDAON
    {
        private int intChallanID;

        private DateTime dtChallanDate;

        private int intRowNo;

        private string itemName;

        private int intItemID;

        private string itemIDWithType;

        private string giftWithItemName;

        private int giftWithItemID;

        private string unitName;

        private int intUnitID;

        private decimal quantity;

        private decimal itemPrice;

        private decimal discnt_vat;

        private decimal discnt_vat_rate;

        private decimal discnt_sd;

        private decimal discnt_sd_rate;

        private int intOrganizationId;

        private int intOrgBranchId;

        private int shUserIdInsert;

        private string remarks;

        public int catID
        {
            get;
            set;
        }

        public DateTime ChallanDate
        {
            get
            {
                return this.dtChallanDate;
            }
            set
            {
                this.dtChallanDate = value;
            }
        }

        public int ChallanID
        {
            get
            {
                return this.intChallanID;
            }
            set
            {
                this.intChallanID = value;
            }
        }

        public DateTime ConsumableChallanDate
        {
            get;
            set;
        }

        public decimal DiscountSD
        {
            get
            {
                return this.discnt_sd;
            }
            set
            {
                this.discnt_sd = value;
            }
        }

        public decimal DiscountSDRate
        {
            get
            {
                return this.discnt_sd_rate;
            }
            set
            {
                this.discnt_sd_rate = value;
            }
        }

        public decimal DiscountVat
        {
            get
            {
                return this.discnt_vat;
            }
            set
            {
                this.discnt_vat = value;
            }
        }

        public decimal DiscountVatRate
        {
            get
            {
                return this.discnt_vat_rate;
            }
            set
            {
                this.discnt_vat_rate = value;
            }
        }

        public int GiftParentItemID
        {
            get
            {
                return this.giftWithItemID;
            }
            set
            {
                this.giftWithItemID = value;
            }
        }

        public decimal GiftQuantity
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

        public string GiftWithItemName
        {
            get
            {
                return this.giftWithItemName;
            }
            set
            {
                this.giftWithItemName = value;
            }
        }

        public int ItemID
        {
            get
            {
                return this.intItemID;
            }
            set
            {
                this.intItemID = value;
            }
        }

        public string ItemID2
        {
            get;
            set;
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

        public decimal ItemPriceBDT
        {
            get
            {
                return this.itemPrice;
            }
            set
            {
                this.itemPrice = value;
            }
        }

        public string ItemWithTypeID
        {
            get
            {
                return this.itemIDWithType;
            }
            set
            {
                this.itemIDWithType = value;
            }
        }

        public int OrganizationID
        {
            get
            {
                return this.intOrganizationId;
            }
            set
            {
                this.intOrganizationId = value;
            }
        }

        public int OrgBranchID
        {
            get
            {
                return this.intOrgBranchId;
            }
            set
            {
                this.intOrgBranchId = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this.remarks;
            }
            set
            {
                this.remarks = value;
            }
        }

        public int RowNo
        {
            get
            {
                return this.intRowNo;
            }
            set
            {
                this.intRowNo = value;
            }
        }

        public int subcatID
        {
            get;
            set;
        }

        public string TypeP
        {
            get;
            set;
        }

        public int UnitId
        {
            get
            {
                return this.intUnitID;
            }
            set
            {
                this.intUnitID = value;
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

        public int UserIdInsert
        {
            get
            {
                return this.shUserIdInsert;
            }
            set
            {
                this.shUserIdInsert = value;
            }
        }

        public SaleGiftDetailDAON()
        {
        }
    }
}

