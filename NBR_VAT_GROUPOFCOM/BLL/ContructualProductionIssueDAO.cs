using System;
using System.Runtime.CompilerServices;


namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class ContructualProductionIssueDAO
    {
        private char purchaseType;

        private int lot_no;

        private int production_issue_lot_id;

        private int production_id;

        private short row_no;

        private int item_id;

        private short property_id1;

        private short property_id2;

        private short property_id3;

        private short property_id4;

        private short property_id5;

        private string property_Text1;

        private string property_Text2;

        private string property_Text3;

        private string property_Text4;

        private string property_Text5;

        private int unit_id;

        private decimal quantity;

        private bool is_deleted;

        private DateTime date_insert;

        private DateTime date_update;

        private short user_id_insert;

        private short user_id_update;

        private int rowNo;

        private string remark;

        private string categoryName;

        private string subCategoryName;

        private string itemName;

        private string unitName;

        private string totunitName;

        private string batch_no;

        private char status;

        private long detailID;

        private double saleUnitPrice;

        private double saleVatablePrice;

        private double saleVat;

        private double saleSD;

        private short spReturn;

        private decimal preQuantity;

        private DateTime mfgDate;

        private DateTime expiryDate;

        public int additionalInfoId
        {
            get;
            set;
        }

        public string Batch_no
        {
            get
            {
                return this.batch_no;
            }
            set
            {
                this.batch_no = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
            }
        }

        public DateTime Date_insert
        {
            get
            {
                return this.date_insert;
            }
            set
            {
                this.date_insert = value;
            }
        }

        public DateTime Date_update
        {
            get
            {
                return this.date_update;
            }
            set
            {
                this.date_update = value;
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

        public DateTime ExpiryDate
        {
            get
            {
                return this.expiryDate;
            }
            set
            {
                this.expiryDate = value;
            }
        }

        public bool Is_deleted
        {
            get
            {
                return this.is_deleted;
            }
            set
            {
                this.is_deleted = value;
            }
        }

        public int Item_id
        {
            get
            {
                return this.item_id;
            }
            set
            {
                this.item_id = value;
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

        public int Lot_no
        {
            get
            {
                return this.lot_no;
            }
            set
            {
                this.lot_no = value;
            }
        }

        public DateTime MfgDate
        {
            get
            {
                return this.mfgDate;
            }
            set
            {
                this.mfgDate = value;
            }
        }

        public decimal PreQuantity
        {
            get
            {
                return this.preQuantity;
            }
            set
            {
                this.preQuantity = value;
            }
        }

        public decimal Price
        {
            get;
            set;
        }

        public string PriceValue
        {
            get;
            set;
        }

        public int Production_id
        {
            get
            {
                return this.production_id;
            }
            set
            {
                this.production_id = value;
            }
        }

        public int Production_issue_lot_id
        {
            get
            {
                return this.production_issue_lot_id;
            }
            set
            {
                this.production_issue_lot_id = value;
            }
        }

        public decimal ProductionPrice
        {
            get;
            set;
        }

        public decimal ProductionQuantity
        {
            get;
            set;
        }

        public short Property_id1
        {
            get
            {
                return this.property_id1;
            }
            set
            {
                this.property_id1 = value;
            }
        }

        public short Property_id2
        {
            get
            {
                return this.property_id2;
            }
            set
            {
                this.property_id2 = value;
            }
        }

        public short Property_id3
        {
            get
            {
                return this.property_id3;
            }
            set
            {
                this.property_id3 = value;
            }
        }

        public short Property_id4
        {
            get
            {
                return this.property_id4;
            }
            set
            {
                this.property_id4 = value;
            }
        }

        public short Property_id5
        {
            get
            {
                return this.property_id5;
            }
            set
            {
                this.property_id5 = value;
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

        public double PurchaseSD
        {
            get;
            set;
        }

        public char PurchaseType
        {
            get
            {
                return this.purchaseType;
            }
            set
            {
                this.purchaseType = value;
            }
        }

        public double PurchaseUnitPrice
        {
            get;
            set;
        }

        public double PurchaseVat
        {
            get;
            set;
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

        public short Row_no
        {
            get
            {
                return this.row_no;
            }
            set
            {
                this.row_no = value;
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

        public double SaleSD
        {
            get
            {
                return this.saleSD;
            }
            set
            {
                this.saleSD = value;
            }
        }

        public double SaleUnitPrice
        {
            get
            {
                return this.saleUnitPrice;
            }
            set
            {
                this.saleUnitPrice = value;
            }
        }

        public double SaleUnitPriceAct
        {
            get;
            set;
        }

        public double SaleVat
        {
            get
            {
                return this.saleVat;
            }
            set
            {
                this.saleVat = value;
            }
        }

        public double SaleVatablePrice
        {
            get
            {
                return this.saleVatablePrice;
            }
            set
            {
                this.saleVatablePrice = value;
            }
        }

        public double SDRate
        {
            get;
            set;
        }

        public short SpReturn
        {
            get
            {
                return this.spReturn;
            }
            set
            {
                this.spReturn = value;
            }
        }

        public char Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public string SubCategoryName
        {
            get
            {
                return this.subCategoryName;
            }
            set
            {
                this.subCategoryName = value;
            }
        }

        public double TotalPrice
        {
            get;
            set;
        }

        public string TotUnitName
        {
            get
            {
                return this.totunitName;
            }
            set
            {
                this.totunitName = value;
            }
        }

        public int Unit_id
        {
            get
            {
                return this.unit_id;
            }
            set
            {
                this.unit_id = value;
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

        public short User_id_insert
        {
            get
            {
                return this.user_id_insert;
            }
            set
            {
                this.user_id_insert = value;
            }
        }

        public short User_id_update
        {
            get
            {
                return this.user_id_update;
            }
            set
            {
                this.user_id_update = value;
            }
        }

        public double VatRate
        {
            get;
            set;
        }

        public ContructualProductionIssueDAO()
        {
        }
    }
}
