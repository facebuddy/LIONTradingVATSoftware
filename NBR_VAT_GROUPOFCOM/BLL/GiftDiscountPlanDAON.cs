using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class GiftDiscountPlanDAON
    {
        private DateTime plannedDate;

        private int promoID;

        private string prntItemName;

        private int prntItemID;

        private string prntItemUnitName;

        private int prntItemUnitID;

        private decimal minPrntItemQnt;

        private string giftItemName;

        private int giftItemID;

        private string giftItemCode;

        private string giftItemUnitName;

        private int giftItemUnitID;

        private decimal giftQuantity;

        private decimal discountPrcntg;

        private decimal discountAmt;

        private decimal minSaleAmount;

        private string remarks;

        private DateTime dateFrom;

        private DateTime dateTo;

        private bool isOnItem;

        private bool isOnSale;

        private int intOrganizationId;

        private int intOrgBranchId;

        private int shUserIdInsert;

        public DateTime DateFrom
        {
            get
            {
                return this.dateFrom;
            }
            set
            {
                this.dateFrom = value;
            }
        }

        public DateTime DatePlanned
        {
            get
            {
                return this.plannedDate;
            }
            set
            {
                this.plannedDate = value;
            }
        }

        public DateTime DateTo
        {
            get
            {
                return this.dateTo;
            }
            set
            {
                this.dateTo = value;
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                return this.discountAmt;
            }
            set
            {
                this.discountAmt = value;
            }
        }

        public decimal DiscountPrcntg
        {
            get
            {
                return this.discountPrcntg;
            }
            set
            {
                this.discountPrcntg = value;
            }
        }

        public string GiftItemCode
        {
            get
            {
                return this.giftItemCode;
            }
            set
            {
                this.giftItemCode = value;
            }
        }

        public int GiftItemID
        {
            get
            {
                return this.giftItemID;
            }
            set
            {
                this.giftItemID = value;
            }
        }

        public string GiftItemName
        {
            get
            {
                return this.giftItemName;
            }
            set
            {
                this.giftItemName = value;
            }
        }

        public int GiftItemUnitID
        {
            get
            {
                return this.giftItemUnitID;
            }
            set
            {
                this.giftItemUnitID = value;
            }
        }

        public string GiftItemUnitName
        {
            get
            {
                return this.giftItemUnitName;
            }
            set
            {
                this.giftItemUnitName = value;
            }
        }

        public decimal GiftQuantity
        {
            get
            {
                return this.giftQuantity;
            }
            set
            {
                this.giftQuantity = value;
            }
        }

        public bool IsOnItemPromo
        {
            get
            {
                return this.isOnItem;
            }
            set
            {
                this.isOnItem = value;
            }
        }

        public bool IsOnSalePromo
        {
            get
            {
                return this.isOnSale;
            }
            set
            {
                this.isOnSale = value;
            }
        }

        public decimal MinSaleAmount
        {
            get
            {
                return this.minSaleAmount;
            }
            set
            {
                this.minSaleAmount = value;
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

        public int ParentItemID
        {
            get
            {
                return this.prntItemID;
            }
            set
            {
                this.prntItemID = value;
            }
        }

        public string ParentItemName
        {
            get
            {
                return this.prntItemName;
            }
            set
            {
                this.prntItemName = value;
            }
        }

        public decimal PrntItemMinQnt
        {
            get
            {
                return this.minPrntItemQnt;
            }
            set
            {
                this.minPrntItemQnt = value;
            }
        }

        public int PrntItemUnitID
        {
            get
            {
                return this.prntItemUnitID;
            }
            set
            {
                this.prntItemUnitID = value;
            }
        }

        public string PrntItemUnitName
        {
            get
            {
                return this.prntItemUnitName;
            }
            set
            {
                this.prntItemUnitName = value;
            }
        }

        public int PromoID
        {
            get
            {
                return this.promoID;
            }
            set
            {
                this.promoID = value;
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

        public GiftDiscountPlanDAON()
        {
        }
    }
}