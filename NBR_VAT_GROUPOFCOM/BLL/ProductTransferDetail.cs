using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ProductTransferDetail
    {
        private short rowNo;

        private int property1;

        private int property2;

        private int property3;

        private int property4;

        private int property5;

        private string property_Text1;

        private string property_Text2;

        private string property_Text3;

        private string property_Text4;

        private string property_Text5;

        private char type;

        private string category;

        private string subCategory;

        private string item;

        private int quantity;

        private string unit;

        private string remark;

        private int itemId;

        private short unitID;

        private short userID;

        private long detailID;

        private bool isFullReceive;

        private bool isMrp;

        private bool isTarrif;

        private bool isZeroRate;

        private bool isTruncated;

        private bool isVDS;

        private bool isRebatable;

        private bool isExempted;

        private char chPurchaseType = 'L';

        public string BrandName
        {
            get;
            set;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public long DetailID
        {
            get
            {
                return this.detailID;
            }
            set
            {
                this.detailID = value;
            }
        }

        public bool Exempted
        {
            get
            {
                return this.isExempted;
            }
            set
            {
                this.isExempted = value;
            }
        }

        public bool IsFullReceive
        {
            get
            {
                return this.isFullReceive;
            }
            set
            {
                this.isFullReceive = value;
            }
        }

        public bool IsVDS
        {
            get
            {
                return this.isVDS;
            }
            set
            {
                this.isVDS = value;
            }
        }

        public string Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
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

        public bool Mrp
        {
            get
            {
                return this.isMrp;
            }
            set
            {
                this.isMrp = value;
            }
        }

        public int Property1
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

        public string Property1_Text
        {
            get
            {
                return this.property_Text1;
            }
            set
            {
                this.property_Text1 = value;
            }
        }

        public string Property11
        {
            get;
            set;
        }

        public int Property2
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

        public string Property2_Text
        {
            get
            {
                return this.property_Text2;
            }
            set
            {
                this.property_Text2 = value;
            }
        }

        public string Property22
        {
            get;
            set;
        }

        public int Property3
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

        public string Property3_Text
        {
            get
            {
                return this.property_Text3;
            }
            set
            {
                this.property_Text3 = value;
            }
        }

        public string Property33
        {
            get;
            set;
        }

        public int Property4
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

        public string Property4_Text
        {
            get
            {
                return this.property_Text4;
            }
            set
            {
                this.property_Text4 = value;
            }
        }

        public string Property44
        {
            get;
            set;
        }

        public int Property5
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

        public string Property5_Text
        {
            get
            {
                return this.property_Text5;
            }
            set
            {
                this.property_Text5 = value;
            }
        }

        public string Property55
        {
            get;
            set;
        }

        public char PurchaseType
        {
            get
            {
                return this.chPurchaseType;
            }
            set
            {
                this.chPurchaseType = value;
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

        public bool Rebatable
        {
            get
            {
                return this.isRebatable;
            }
            set
            {
                this.isRebatable = value;
            }
        }

        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
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

        public decimal sd_amount
        {
            get;
            set;
        }

        public decimal sd_rate
        {
            get;
            set;
        }

        public string SubCategory
        {
            get
            {
                return this.subCategory;
            }
            set
            {
                this.subCategory = value;
            }
        }

        public bool Tarrif
        {
            get
            {
                return this.isTarrif;
            }
            set
            {
                this.isTarrif = value;
            }
        }

        public bool Truncated
        {
            get
            {
                return this.isTruncated;
            }
            set
            {
                this.isTruncated = value;
            }
        }

        public char Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string Unit
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

        public decimal unit_price
        {
            get;
            set;
        }

        public short UnitID
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

        public short UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public decimal vat_amount
        {
            get;
            set;
        }

        public decimal vat_rate
        {
            get;
            set;
        }

        public bool ZeroRate
        {
            get
            {
                return this.isZeroRate;
            }
            set
            {
                this.isZeroRate = value;
            }
        }

        public ProductTransferDetail()
        {
        }
    }
}