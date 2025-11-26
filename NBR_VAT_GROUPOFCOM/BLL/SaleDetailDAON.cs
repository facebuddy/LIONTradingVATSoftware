using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SaleDetailDAON
    {
        private string dId;

        private string strHSCode;

        private int intChallanID;

        private int intDetailID;

        private int intRowNo;

        private int intSaleRowNo;

        private int intLotNo;

        private int intCatID;

        private int intSubCatID;

        private int intItemID;

        private int intPropertyID1;

        private int intPropertyID2;

        private int intPropertyID3;

        private int intPropertyID4;

        private int intPropertyID5;

        private int intUnitID;

        private decimal dblQuantity;

        private decimal dblUnitPrice;

        private decimal dblTotalPrice;

        private decimal dblTotalSalePrice;

        private decimal dblSD;

        private decimal dblVAT;

        private decimal dblAIT;

        private decimal dblSDRate;

        private decimal dblVATRate;

        private bool blIsSrcTAXDeduct;

        private bool isfixed;

        private bool isTruncated;

        private short shIsDeleted;

        private short shUserIdInsert;

        private short shUserIdUpdate;

        private string categoryName;

        private string subCategoryName;

        private string itemName;

        private string specification;

        private string strProperty1;

        private string strProperty2;

        private string strProperty3;

        private string strProperty4;

        private string strProperty5;

        private string strUnitName;

        private string batchNo;

        private bool blIsExempted;

        private bool blIsRebatable;

        private bool blZeroRate;

        private bool ismrp;

        private bool blInexplicitExport;

        private short shPriceId;

        private decimal dblNBRPrice;

        private short shDisposalReasonM;

        private short shDisposalReasonD;

        private double dblAvailStock;

        private string itemType;

        private string strTransactionType;

        private string strSaleType;

        private bool vDS;

        private decimal dVAT;

        private char realProperty;

        private decimal vds_Amount;

        private string typeP;

        private string productType;

        private decimal dbvatRate;

        private decimal saleQuantity;

        private int saleUnitID;

        private string saleUnitName;

        public string itemSerials;

        private string prpStk;

        private decimal dSD;

        private decimal dUnitPrice;

        private string rebatable;

        private string truncated;

        private string exempted;

        private string ifixed;

        private string mrp;

        private string zeroRate;

        private string srcTAXDeduct;

        private string deemedExport;

        private string strRemarks;

        private string perqty;

        public string addtnProperty
        {
            get;
            set;
        }

        public string AggrementNo
        {
            get;
            set;
        }

        public decimal AIT
        {
            get
            {
                return this.dblAIT;
            }
            set
            {
                this.dblAIT = value;
            }
        }

        public decimal AITRate
        {
            get;
            set;
        }

        public string ApproveStage
        {
            get;
            set;
        }

        public double AvailStock
        {
            get
            {
                return this.dblAvailStock;
            }
            set
            {
                this.dblAvailStock = value;
            }
        }

        public double BankAmount
        {
            get;
            set;
        }

        public int BankID
        {
            get;
            set;
        }

        public string BankName
        {
            get;
            set;
        }

        public string BatchNo
        {
            get
            {
                return this.batchNo;
            }
            set
            {
                this.batchNo = value;
            }
        }

        public int BranchID
        {
            get;
            set;
        }

        public string BranchName
        {
            get;
            set;
        }

        public double CashAmount
        {
            get;
            set;
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

        public string categoryType
        {
            get;
            set;
        }

        public int CatID
        {
            get
            {
                return this.intCatID;
            }
            set
            {
                this.intCatID = value;
            }
        }

        public string Challan_Date
        {
            get;
            set;
        }

        public string Challan_No
        {
            get;
            set;
        }

        public string Challan_Time
        {
            get;
            set;
        }

        public int challanID
        {
            get;
            set;
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

        public double CreditAmount
        {
            get;
            set;
        }

        public string DeemedExport
        {
            get;
            set;
        }

        public int DetailID
        {
            get
            {
                return this.intDetailID;
            }
            set
            {
                this.intDetailID = value;
            }
        }

        public decimal discount
        {
            get;
            set;
        }

        public decimal Discount
        {
            get
            {
                return this.discount;
            }
            set
            {
                this.discount = value;
            }
        }

        public decimal discount_pct
        {
            get;
            set;
        }

        public decimal Discount_pct
        {
            get
            {
                return this.discount_pct;
            }
            set
            {
                this.discount_pct = value;
            }
        }

        public short DisposalReasonD
        {
            get
            {
                return this.shDisposalReasonD;
            }
            set
            {
                this.shDisposalReasonD = value;
            }
        }

        public short DisposalReasonM
        {
            get
            {
                return this.shDisposalReasonM;
            }
            set
            {
                this.shDisposalReasonM = value;
            }
        }

        public decimal DSD
        {
            get
            {
                return this.dSD;
            }
            set
            {
                this.dSD = value;
            }
        }

        public decimal DUnitPrice
        {
            get
            {
                return this.dUnitPrice;
            }
            set
            {
                this.dUnitPrice = value;
            }
        }

        public decimal DVAT
        {
            get
            {
                return this.dVAT;
            }
            set
            {
                this.dVAT = value;
            }
        }

        public string Exempted
        {
            get
            {
                return this.exempted;
            }
            set
            {
                this.exempted = value;
            }
        }

        public string ExportBillNo
        {
            get;
            set;
        }

        public string ExportDate
        {
            get;
            set;
        }

        public string Fixed
        {
            get
            {
                return this.ifixed;
            }
            set
            {
                this.ifixed = value;
            }
        }

        public decimal HealthCharge
        {
            get;
            set;
        }

        public string HS_Code
        {
            get;
            set;
        }

        public string HSCode
        {
            get
            {
                return this.strHSCode;
            }
            set
            {
                this.strHSCode = value;
            }
        }

        public string id
        {
            get
            {
                return this.dId;
            }
            set
            {
                this.dId = value;
            }
        }

        public bool installmentStatus
        {
            get;
            set;
        }

        public string instStatus
        {
            get;
            set;
        }

        public string Invoice_No
        {
            get;
            set;
        }

        public short IsDeleted
        {
            get
            {
                return this.shIsDeleted;
            }
            set
            {
                this.shIsDeleted = value;
            }
        }

        public bool IsExempted
        {
            get
            {
                return this.blIsExempted;
            }
            set
            {
                this.blIsExempted = value;
            }
        }

        public bool IsFixed
        {
            get
            {
                return this.isfixed;
            }
            set
            {
                this.isfixed = value;
            }
        }

        public bool isInexplicitExport
        {
            get
            {
                return this.blInexplicitExport;
            }
            set
            {
                this.blInexplicitExport = value;
            }
        }

        public bool IsMrp
        {
            get
            {
                return this.ismrp;
            }
            set
            {
                this.ismrp = value;
            }
        }

        public bool IsPaymentFinished
        {
            get;
            set;
        }

        public bool IsRebatable
        {
            get
            {
                return this.blIsRebatable;
            }
            set
            {
                this.blIsRebatable = value;
            }
        }

        public bool IsSrcTAXDeduct
        {
            get
            {
                return this.blIsSrcTAXDeduct;
            }
            set
            {
                this.blIsSrcTAXDeduct = value;
            }
        }

        public bool IsTruncated
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

        public bool IsZeroRate
        {
            get
            {
                return this.blZeroRate;
            }
            set
            {
                this.blZeroRate = value;
            }
        }

        public string Item_Name
        {
            get;
            set;
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

        public bool itemIsExempted
        {
            get;
            set;
        }

        public bool itemIszeroRate
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

        public string ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }

        public int IUnitID
        {
            get;
            set;
        }

        public string IUnitName
        {
            get;
            set;
        }

        public int LotNo
        {
            get
            {
                return this.intLotNo;
            }
            set
            {
                this.intLotNo = value;
            }
        }

        public string Mrp
        {
            get
            {
                return this.mrp;
            }
            set
            {
                this.mrp = value;
            }
        }

        public decimal NBRPrice
        {
            get
            {
                return this.dblNBRPrice;
            }
            set
            {
                this.dblNBRPrice = value;
            }
        }

        public decimal net_bill
        {
            get;
            set;
        }

        public decimal Net_bill
        {
            get
            {
                return this.net_bill;
            }
            set
            {
                this.net_bill = value;
            }
        }

        public decimal PaidAmount
        {
            get;
            set;
        }

        public string Party_Name
        {
            get;
            set;
        }

        public int partyID
        {
            get;
            set;
        }

        public string Payment_Type
        {
            get;
            set;
        }

        public string Perqty
        {
            get
            {
                return this.perqty;
            }
            set
            {
                this.perqty = value;
            }
        }

        public decimal Price
        {
            get;
            set;
        }

        public short PriceId
        {
            get
            {
                return this.shPriceId;
            }
            set
            {
                this.shPriceId = value;
            }
        }

        public decimal Priceincluding_VAT
        {
            get;
            set;
        }

        public string ProductType
        {
            get
            {
                return this.productType;
            }
            set
            {
                this.productType = value;
            }
        }

        public string Property1
        {
            get
            {
                return this.strProperty1;
            }
            set
            {
                this.strProperty1 = value;
            }
        }

        public string Property2
        {
            get
            {
                return this.strProperty2;
            }
            set
            {
                this.strProperty2 = value;
            }
        }

        public string Property3
        {
            get
            {
                return this.strProperty3;
            }
            set
            {
                this.strProperty3 = value;
            }
        }

        public string Property4
        {
            get
            {
                return this.strProperty4;
            }
            set
            {
                this.strProperty4 = value;
            }
        }

        public string Property5
        {
            get
            {
                return this.strProperty5;
            }
            set
            {
                this.strProperty5 = value;
            }
        }

        public int PropertyID1
        {
            get
            {
                return this.intPropertyID1;
            }
            set
            {
                this.intPropertyID1 = value;
            }
        }

        public int PropertyID2
        {
            get
            {
                return this.intPropertyID2;
            }
            set
            {
                this.intPropertyID2 = value;
            }
        }

        public int PropertyID3
        {
            get
            {
                return this.intPropertyID3;
            }
            set
            {
                this.intPropertyID3 = value;
            }
        }

        public int PropertyID4
        {
            get
            {
                return this.intPropertyID4;
            }
            set
            {
                this.intPropertyID4 = value;
            }
        }

        public int PropertyID5
        {
            get
            {
                return this.intPropertyID5;
            }
            set
            {
                this.intPropertyID5 = value;
            }
        }

        public string PropStk
        {
            get
            {
                return this.prpStk;
            }
            set
            {
                this.prpStk = value;
            }
        }

        public decimal Quantity
        {
            get;
            set;
        }

        public char RealProperty
        {
            get
            {
                return this.realProperty;
            }
            set
            {
                this.realProperty = value;
            }
        }

        public string Rebatable
        {
            get
            {
                return this.rebatable;
            }
            set
            {
                this.rebatable = value;
            }
        }

        public string Remarks
        {
            get;
            set;
        }

        public string RemarksDetail
        {
            get
            {
                return this.strRemarks;
            }
            set
            {
                this.strRemarks = value;
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

        public decimal SaleQuantity
        {
            get
            {
                return this.saleQuantity;
            }
            set
            {
                this.saleQuantity = value;
            }
        }

        public int SaleRowNo
        {
            get
            {
                return this.intSaleRowNo;
            }
            set
            {
                this.intSaleRowNo = value;
            }
        }

        public string SaleType
        {
            get
            {
                return this.strSaleType;
            }
            set
            {
                this.strSaleType = value;
            }
        }

        public int SaleUnitID
        {
            get
            {
                return this.saleUnitID;
            }
            set
            {
                this.saleUnitID = value;
            }
        }

        public string SaleUnitName
        {
            get
            {
                return this.saleUnitName;
            }
            set
            {
                this.saleUnitName = value;
            }
        }

        public int scheduleId
        {
            get;
            set;
        }

        public decimal SD
        {
            get
            {
                return this.dblSD;
            }
            set
            {
                this.dblSD = value;
            }
        }

        public decimal SD_Amount
        {
            get;
            set;
        }

        public decimal SD_Rate
        {
            get;
            set;
        }

        public decimal SDRate
        {
            get
            {
                return this.dblSDRate;
            }
            set
            {
                this.dblSDRate = value;
            }
        }

        public string Specification
        {
            get
            {
                return this.specification;
            }
            set
            {
                this.specification = value;
            }
        }

        public string SrcTAXDeduct
        {
            get
            {
                return this.srcTAXDeduct;
            }
            set
            {
                this.srcTAXDeduct = value;
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

        public int SubCatID
        {
            get
            {
                return this.intSubCatID;
            }
            set
            {
                this.intSubCatID = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return this.dblTotalPrice;
            }
            set
            {
                this.dblTotalPrice = value;
            }
        }

        public decimal TotalPricegrid
        {
            get;
            set;
        }

        public decimal TotalSalePrice
        {
            get
            {
                return this.dblTotalSalePrice;
            }
            set
            {
                this.dblTotalSalePrice = value;
            }
        }

        public string Transaction_Type
        {
            get;
            set;
        }

        public string TransactionType
        {
            get
            {
                return this.strTransactionType;
            }
            set
            {
                this.strTransactionType = value;
            }
        }

        public string Truncated
        {
            get
            {
                return this.truncated;
            }
            set
            {
                this.truncated = value;
            }
        }

        public string TypeP
        {
            get
            {
                return this.typeP;
            }
            set
            {
                this.typeP = value;
            }
        }

        public string Unit
        {
            get;
            set;
        }

        public string Unit_Name
        {
            get;
            set;
        }

        public decimal Unit_Price
        {
            get;
            set;
        }

        public int UnitID
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
                return this.strUnitName;
            }
            set
            {
                this.strUnitName = value;
            }
        }

        public decimal UnitPrice
        {
            get;
            set;
        }

        public decimal UnitPriceBDT
        {
            get
            {
                return this.dblUnitPrice;
            }
            set
            {
                this.dblUnitPrice = value;
            }
        }

        public short UserIdInsert
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

        public short UserIdUpdate
        {
            get
            {
                return this.shUserIdUpdate;
            }
            set
            {
                this.shUserIdUpdate = value;
            }
        }

        public decimal VAT
        {
            get
            {
                return this.dblVAT;
            }
            set
            {
                this.dblVAT = value;
            }
        }

        public decimal VAT_Amount
        {
            get;
            set;
        }

        public decimal VAT_Rate
        {
            get;
            set;
        }

        public decimal VATRate
        {
            get
            {
                return this.dblVATRate;
            }
            set
            {
                this.dblVATRate = value;
            }
        }

        public bool VDS
        {
            get
            {
                return this.vDS;
            }
            set
            {
                this.vDS = value;
            }
        }

        public decimal Vds_Amount
        {
            get
            {
                return this.vds_Amount;
            }
            set
            {
                this.vds_Amount = value;
            }
        }

        public string ZeroRate
        {
            get
            {
                return this.zeroRate;
            }
            set
            {
                this.zeroRate = value;
            }
        }

        public SaleDetailDAON()
        {
        }
    }

}

