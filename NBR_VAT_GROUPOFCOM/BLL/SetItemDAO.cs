using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class SetItemDAO
    {
        private int intopn_id;

        private int intItemID;

        private double itemQty;

        private double itemValue;

        private int intCenterID;

        private int intCategoryID;

        private int mainintCategoryID;

        private int intCatCenterID;

        private int intParentID;

        private string strItemName;

        private string strItemSpecification;

        private string strItemCode;

        private short intUnitID;

        private string purchasetype;

        private short intUnitCenterID;

        private bool srtProp1Required;

        private bool srtProp2Required;

        private bool srtProp3Required;

        private bool srtProp4Required;

        private bool srtProp5Required;

        private int intUserIdInsert;

        private int intUserIdUpdate;

        private short intIsDeleted;

        private float fltShockAlertQty;

        private float fltReOrderQty;

        private int intLevelCode;

        private int srtMesurementIDM;

        private int srtMesurementIDD;

        private bool srtSupplierRequired;

        private bool srtExpiryDateRequired;

        private int intUserInsertCenterID;

        private int intUserUpdateCenterID;

        private char chItemType = 'I';

        private int intItemIDCommon;

        private short shAccountID;

        private short synchronized;

        private DateTime dateSynchronized;

        private string synchronizeMode;

        private short dataSourceId;

        private short reportingCode;

        private string hsHeading;

        private string hsSuffix;

        private string hsCode;

        private string modelno;

        private bool isTruncated;

        private bool isTarrif;

        private bool isZeroRate;

        private bool isMrp;

        private bool isExempted;

        private bool isAllBssUnt;

        private bool isPriceDec;

        private bool isHCS;

        private double dbVatRebate;

        private bool isRebatable;

        private char chProductType = 'R';

        private bool isVDS;

        private string strbrandName;

        private DateTime opening_balance_date;

        private short property_id1;

        private short property_id2;

        private short property_id3;

        private short property_id4;

        private short property_id5;

        private string propertyId1Name;

        private string propertyId2Name;

        private string propertyId3Name;

        private string propertyId4Name;

        private string propertyId5Name;

        private string category;

        private string sub_category;

        private string measurement_type;

        private string unit;

        private string item_type;

        private string product_type;

        private string catagoryTyp;

        private int organization_id;

        public short AccountID
        {
            get
            {
                return this.shAccountID;
            }
            set
            {
                this.shAccountID = value;
            }
        }

        public string brandName
        {
            get
            {
                return this.strbrandName;
            }
            set
            {
                this.strbrandName = value;
            }
        }

        public string CatagoryTyp
        {
            get
            {
                return this.catagoryTyp;
            }
            set
            {
                this.catagoryTyp = value;
            }
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

        public int CategoryCenterID
        {
            get
            {
                return this.intCatCenterID;
            }
            set
            {
                this.intCatCenterID = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return this.intCategoryID;
            }
            set
            {
                this.intCategoryID = value;
            }
        }

        public int CenterID
        {
            get
            {
                return this.intCenterID;
            }
            set
            {
                this.intCenterID = value;
            }
        }

        public bool chkStatus
        {
            get;
            set;
        }

        public short DataSourceId
        {
            get
            {
                return this.dataSourceId;
            }
            set
            {
                this.dataSourceId = value;
            }
        }

        public DateTime DateSynchronized
        {
            get
            {
                return this.dateSynchronized;
            }
            set
            {
                this.dateSynchronized = value;
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

        public bool ExpiryDateRequired
        {
            get
            {
                return this.srtExpiryDateRequired;
            }
            set
            {
                this.srtExpiryDateRequired = value;
            }
        }

        public string HsCode
        {
            get
            {
                return this.hsCode;
            }
            set
            {
                this.hsCode = value;
            }
        }

        public string HsHeading
        {
            get
            {
                return this.hsHeading;
            }
            set
            {
                this.hsHeading = value;
            }
        }

        public string HsSuffix
        {
            get
            {
                return this.hsSuffix;
            }
            set
            {
                this.hsSuffix = value;
            }
        }

        public bool IsAllBssUnt
        {
            get
            {
                return this.isAllBssUnt;
            }
            set
            {
                this.isAllBssUnt = value;
            }
        }

        public short IsDeleted
        {
            get
            {
                return this.intIsDeleted;
            }
            set
            {
                this.intIsDeleted = value;
            }
        }

        public bool IsHCS
        {
            get
            {
                return this.isHCS;
            }
            set
            {
                this.isHCS = value;
            }
        }

        public bool IsPriceDec
        {
            get
            {
                return this.isPriceDec;
            }
            set
            {
                this.isPriceDec = value;
            }
        }

        public bool IsReusable
        {
            get;
            set;
        }

        public bool IsSetItem
        {
            get;
            set;
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

        public string Item_type
        {
            get
            {
                return this.item_type;
            }
            set
            {
                this.item_type = value;
            }
        }

        public string ItemCode
        {
            get
            {
                return this.strItemCode;
            }
            set
            {
                this.strItemCode = value;
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

        public int ItemIDCommon
        {
            get
            {
                return this.intItemIDCommon;
            }
            set
            {
                this.intItemIDCommon = value;
            }
        }

        public string ItemName
        {
            get
            {
                return this.strItemName;
            }
            set
            {
                this.strItemName = value;
            }
        }

        public string ItemSpecification
        {
            get
            {
                return this.strItemSpecification;
            }
            set
            {
                this.strItemSpecification = value;
            }
        }

        public char ItemType
        {
            get
            {
                return this.chItemType;
            }
            set
            {
                this.chItemType = value;
            }
        }

        public double ItmQty
        {
            get
            {
                return this.itemQty;
            }
            set
            {
                this.itemQty = value;
            }
        }

        public double ItmVl
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

        public int LevelCode
        {
            get
            {
                return this.intLevelCode;
            }
            set
            {
                this.intLevelCode = value;
            }
        }

        public int MainCategoryID
        {
            get
            {
                return this.mainintCategoryID;
            }
            set
            {
                this.mainintCategoryID = value;
            }
        }

        public string Measurement_type
        {
            get
            {
                return this.measurement_type;
            }
            set
            {
                this.measurement_type = value;
            }
        }

        public int MesurementIDD
        {
            get
            {
                return this.srtMesurementIDD;
            }
            set
            {
                this.srtMesurementIDD = value;
            }
        }

        public int MesurementIDM
        {
            get
            {
                return this.srtMesurementIDM;
            }
            set
            {
                this.srtMesurementIDM = value;
            }
        }

        public string ModelNo
        {
            get
            {
                return this.modelno;
            }
            set
            {
                this.modelno = value;
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

        public DateTime Opening_bal_date
        {
            get
            {
                return this.opening_balance_date;
            }
            set
            {
                this.opening_balance_date = value;
            }
        }

        public string Openingbalance_date
        {
            get;
            set;
        }

        public int OpnID
        {
            get
            {
                return this.intopn_id;
            }
            set
            {
                this.intopn_id = value;
            }
        }

        public int Organization_id
        {
            get
            {
                return this.organization_id;
            }
            set
            {
                this.organization_id = value;
            }
        }

        public int ParentID
        {
            get
            {
                return this.intParentID;
            }
            set
            {
                this.intParentID = value;
            }
        }

        public string Product_type
        {
            get
            {
                return this.product_type;
            }
            set
            {
                this.product_type = value;
            }
        }

        public char ProductType
        {
            get
            {
                return this.chProductType;
            }
            set
            {
                this.chProductType = value;
            }
        }

        public bool Prop1Required
        {
            get
            {
                return this.srtProp1Required;
            }
            set
            {
                this.srtProp1Required = value;
            }
        }

        public bool Prop2Required
        {
            get
            {
                return this.srtProp2Required;
            }
            set
            {
                this.srtProp2Required = value;
            }
        }

        public bool Prop3Required
        {
            get
            {
                return this.srtProp3Required;
            }
            set
            {
                this.srtProp3Required = value;
            }
        }

        public bool Prop4Required
        {
            get
            {
                return this.srtProp4Required;
            }
            set
            {
                this.srtProp4Required = value;
            }
        }

        public bool Prop5Required
        {
            get
            {
                return this.srtProp5Required;
            }
            set
            {
                this.srtProp5Required = value;
            }
        }

        public short propertyId1
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

        public short propertyId2
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

        public short propertyId3
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

        public short propertyId4
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

        public short propertyId5
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

        public string propertyName1
        {
            get
            {
                return this.propertyId1Name;
            }
            set
            {
                this.propertyId1Name = value;
            }
        }

        public string propertyName2
        {
            get
            {
                return this.propertyId2Name;
            }
            set
            {
                this.propertyId2Name = value;
            }
        }

        public string propertyName3
        {
            get
            {
                return this.propertyId3Name;
            }
            set
            {
                this.propertyId3Name = value;
            }
        }

        public string propertyName4
        {
            get
            {
                return this.propertyId4Name;
            }
            set
            {
                this.propertyId4Name = value;
            }
        }

        public string propertyName5
        {
            get
            {
                return this.propertyId5Name;
            }
            set
            {
                this.propertyId5Name = value;
            }
        }

        public string PurchaseType
        {
            get
            {
                return this.purchasetype;
            }
            set
            {
                this.purchasetype = value;
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

        public float ReOrderQty
        {
            get
            {
                return this.fltReOrderQty;
            }
            set
            {
                this.fltReOrderQty = value;
            }
        }

        public short ReportingCode
        {
            get
            {
                return this.reportingCode;
            }
            set
            {
                this.reportingCode = value;
            }
        }

        public int RowNo
        {
            get;
            set;
        }

        public string SKU
        {
            get;
            set;
        }

        public float StockAlertQty
        {
            get
            {
                return this.fltShockAlertQty;
            }
            set
            {
                this.fltShockAlertQty = value;
            }
        }

        public string Sub_category
        {
            get
            {
                return this.sub_category;
            }
            set
            {
                this.sub_category = value;
            }
        }

        public int SubCatgID
        {
            get;
            set;
        }

        public bool SupplierRequired
        {
            get
            {
                return this.srtSupplierRequired;
            }
            set
            {
                this.srtSupplierRequired = value;
            }
        }

        public short Synchronized
        {
            get
            {
                return this.synchronized;
            }
            set
            {
                this.synchronized = value;
            }
        }

        public string SynchronizedMode
        {
            get
            {
                return this.synchronizeMode;
            }
            set
            {
                this.synchronizeMode = value;
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

        public short UnitCenterID
        {
            get
            {
                return this.intUnitCenterID;
            }
            set
            {
                this.intUnitCenterID = value;
            }
        }

        public short UnitID
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

        public double unitPrice
        {
            get;
            set;
        }

        public int UserIdInsert
        {
            get
            {
                return this.intUserIdInsert;
            }
            set
            {
                this.intUserIdInsert = value;
            }
        }

        public int UserIdUpdate
        {
            get
            {
                return this.intUserIdUpdate;
            }
            set
            {
                this.intUserIdUpdate = value;
            }
        }

        public int UserInsertCenterID
        {
            get
            {
                return this.intUserInsertCenterID;
            }
            set
            {
                this.intUserInsertCenterID = value;
            }
        }

        public int UserUpdateCenterID
        {
            get
            {
                return this.intUserUpdateCenterID;
            }
            set
            {
                this.intUserUpdateCenterID = value;
            }
        }

        public double VatRebate
        {
            get
            {
                return this.dbVatRebate;
            }
            set
            {
                this.dbVatRebate = value;
            }
        }

        public decimal Weight
        {
            get;
            set;
        }

        public int weightUnitID
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

        public SetItemDAO()
        {
        }
    }
}


