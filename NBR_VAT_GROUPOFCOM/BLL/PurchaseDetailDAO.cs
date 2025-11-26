using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PurchaseDetailDAO
    {
        private char chPurchaseType = 'L';

        private int intChallanID;

        private int intDetailID;

        private int intRowNo;

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

        private double dblQuantity;

        private double dblUnitPrice;

        private bool isWar;

        private string isWarStr = "No";

        private double dblUnitSalePrice;

        private double UnitSalePrice;

        private double dblPurchaseSD;

        private double dblSaleSD;

        private double dblPurchaseVAT;

        private double dblSaleVAT;

        private double dblPurchaseUnitPrice;

        private double dblSaleUnitPrice;

        private double dblSaleVatablePrice;

        private double dblTotalPurchasePrice;

        private bool blIsDeemedExport;

        private int intProperty1;

        private int intProperty2;

        private int intProperty3;

        private int intProperty4;

        private int intProperty5;

        private string deemedExport;

        private double dblTotalPrice;

        private double dblTotalPricet;

        private double dblSD;

        private double dblVAT;

        private bool blIsSrcTAXDeduct;

        private short shIsDeleted;

        private short shUserIdInsert;

        private short shUserIdUpdate;

        private string categoryName;

        private string subCategoryName;

        private string itemName;

        private string strProperty1;

        private string strProperty2;

        private string strProperty3;

        private string strProperty4;

        private string strProperty5;

        private string strUnitName;

        private string serialNo;

        private string pLotNo;

        private string batchNo;

        private DateTime mfgDate;

        private double dblCD;

        private double dblRD;

        private double dblAIT;

        private double dblATV;

        private double dblTTI;

        private short priceID;

        private double dblSDRate;

        private double dblVATRate;

        private string itemType;

        private string strRemarks;

        private bool blIsRebatable;

        private bool isTruncated;

        private bool blIsExempted;

        private bool isfixed;

        private bool ismrp;

        private bool iszeroRate;

        private string strHSCode;

        private double unitPriceTotal;

        private double othersPrice;

        private double documentProcessingFee;

        private double pSI;

        private double cNFVat;

        private double cNFCommission;

        private double vDSAmount;

        private double tempQuantity;

        private double tempUnitPrice;

        private string tempUnitCode;

        private double aT;

        private string tempSerialNo;

        private string tempLotNo;

        private string tempBatchNo;

        private DateTime tempMfgDate;

        private string itemHsCode;

        private double usedItemPrice;

        private double importTax;

        private DateTime dateUpdte;

        private char realProperty;

        private string rebatable;

        private string truncated;

        private string exempted;

        private string ifixed;

        private string mrp;

        private string zeroRate;

        private string srcTAXDeduct;

        public string AggrementNo
        {
            get;
            set;
        }

        public double AIT
        {
            get;
            set;
        }

        public double AIT_Amount
        {
            get;
            set;
        }

        public double AIT_Rate
        {
            get;
            set;
        }

        public string AITStatus
        {
            get;
            set;
        }

        public string ApproveStage
        {
            get;
            set;
        }

        public double AssesValue
        {
            get;
            set;
        }

        public double AT
        {
            get;
            set;
        }

        public double AT_Amount
        {
            get;
            set;
        }

        public string AT_Status
        {
            get;
            set;
        }

        public double ATV
        {
            get;
            set;
        }

        public double ATV_Amount
        {
            get;
            set;
        }

        public string ATVStatus
        {
            get;
            set;
        }

        public int BankBranchId
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

        public string BLDate
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

        public double CD
        {
            get;
            set;
        }

        public double CD_Amount
        {
            get;
            set;
        }

        public string CDStatus
        {
            get;
            set;
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

        public double CnF_Income_Tax
        {
            get;
            set;
        }

        public double CnF_Vat
        {
            get;
            set;
        }

        public double CnFCommission
        {
            get
            {
                return this.cNFCommission;
            }
            set
            {
                this.cNFCommission = value;
            }
        }

        public double CnFVat
        {
            get
            {
                return this.cNFVat;
            }
            set
            {
                this.cNFVat = value;
            }
        }

        public string Color
        {
            get;
            set;
        }

        public double Commission
        {
            get;
            set;
        }

        public string Company
        {
            get;
            set;
        }

        public double Cost
        {
            get;
            set;
        }

        public double CreditAmount
        {
            get;
            set;
        }

        public double CSF
        {
            get;
            set;
        }

        public DateTime DateUpdte
        {
            get
            {
                return this.dateUpdte;
            }
            set
            {
                this.dateUpdte = value;
            }
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

        public string Difference
        {
            get;
            set;
        }

        public double Discount
        {
            get;
            set;
        }

        public double Document_Processing_Fee
        {
            get;
            set;
        }

        public double DocumentProcessingFee
        {
            get
            {
                return this.documentProcessingFee;
            }
            set
            {
                this.documentProcessingFee = value;
            }
        }

        public decimal exchangeRate
        {
            get;
            set;
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

        public string Grade
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

        public double ImportTax
        {
            get
            {
                return this.importTax;
            }
            set
            {
                this.importTax = value;
            }
        }

        public double ImportValue
        {
            get;
            set;
        }

        public double InsuranceAmount
        {
            get;
            set;
        }

        public int IntProperty1
        {
            get;
            set;
        }

        public int IntProperty2
        {
            get;
            set;
        }

        public int IntProperty3
        {
            get;
            set;
        }

        public int IntProperty4
        {
            get;
            set;
        }

        public int IntProperty5
        {
            get;
            set;
        }

        public bool IsCurrentMonthRebate
        {
            get;
            set;
        }

        public bool IsDeemedExport
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

        public bool IsWar
        {
            get
            {
                return this.isWar;
            }
            set
            {
                this.isWar = value;
            }
        }

        public string IsWarStr
        {
            get
            {
                return this.isWarStr;
            }
            set
            {
                this.isWarStr = value;
            }
        }

        public bool IsZeroRate
        {
            get
            {
                return this.iszeroRate;
            }
            set
            {
                this.iszeroRate = value;
            }
        }

        public string Item
        {
            get;
            set;
        }

        public string ItemHsCode
        {
            get
            {
                return this.itemHsCode;
            }
            set
            {
                this.itemHsCode = value;
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

        public bool ItemStatus
        {
            get;
            set;
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

        public double LCAmount
        {
            get;
            set;
        }

        public string LCForeignCurrency
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

        public double Other_Cost
        {
            get;
            set;
        }

        public double OthersPrice
        {
            get
            {
                return this.othersPrice;
            }
            set
            {
                this.othersPrice = value;
            }
        }

        public bool P1Status
        {
            get;
            set;
        }

        public bool P2Status
        {
            get;
            set;
        }

        public bool P3Status
        {
            get;
            set;
        }

        public bool P4Status
        {
            get;
            set;
        }

        public bool P5Status
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

        public string PLotNo
        {
            get
            {
                return this.pLotNo;
            }
            set
            {
                this.pLotNo = value;
            }
        }

        public string PortCode
        {
            get;
            set;
        }

        public string PortFrom
        {
            get;
            set;
        }

        public short PriceId
        {
            get
            {
                return this.priceID;
            }
            set
            {
                this.priceID = value;
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

        public double PSI
        {
            get
            {
                return this.pSI;
            }
            set
            {
                this.pSI = value;
            }
        }

        public double PurchasePrice
        {
            get;
            set;
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
                return this.chPurchaseType;
            }
            set
            {
                this.chPurchaseType = value;
            }
        }

        public double PurchaseUnitPrice
        {
            get;
            set;
        }

        public double PurchaseVAT
        {
            get;
            set;
        }

        public double Quantity
        {
            get
            {
                return this.dblQuantity;
            }
            set
            {
                this.dblQuantity = value;
            }
        }

        public decimal QuantityExcel
        {
            get;
            set;
        }

        public double RD
        {
            get;
            set;
        }

        public double RD_Amount
        {
            get;
            set;
        }

        public string RDStatus
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

        public string RefChallanDate
        {
            get;
            set;
        }

        public double RefundPrice
        {
            get;
            set;
        }

        public string ReleaseOrderNo
        {
            get;
            set;
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
            get;
            set;
        }

        public double SaleSD
        {
            get;
            set;
        }

        public double SaleUnitPrice
        {
            get;
            set;
        }

        public double SaleVAT
        {
            get;
            set;
        }

        public double SaleVatablePrice
        {
            get;
            set;
        }

        public string ScrollNo
        {
            get;
            set;
        }

        public double SD
        {
            get;
            set;
        }

        public double SD_Amount
        {
            get;
            set;
        }

        public double SDRate
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

        public string SDStatus
        {
            get;
            set;
        }

        public string SerialNo
        {
            get
            {
                return this.serialNo;
            }
            set
            {
                this.serialNo = value;
            }
        }

        public string ShipmentDate
        {
            get;
            set;
        }

        public string Size
        {
            get;
            set;
        }

        public string Specification
        {
            get;
            set;
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

        public string TaxPaymentDate
        {
            get;
            set;
        }

        public string TempBatchNo
        {
            get
            {
                return this.tempBatchNo;
            }
            set
            {
                this.tempBatchNo = value;
            }
        }

        public string TempLotNo
        {
            get
            {
                return this.tempLotNo;
            }
            set
            {
                this.tempLotNo = value;
            }
        }

        public DateTime TempMfgDate
        {
            get
            {
                return this.tempMfgDate;
            }
            set
            {
                this.tempMfgDate = value;
            }
        }

        public double TempQuantity
        {
            get
            {
                return this.tempQuantity;
            }
            set
            {
                this.tempQuantity = value;
            }
        }

        public string TempSerialNo
        {
            get
            {
                return this.tempSerialNo;
            }
            set
            {
                this.tempSerialNo = value;
            }
        }

        public string TempUnitCode
        {
            get
            {
                return this.tempUnitCode;
            }
            set
            {
                this.tempUnitCode = value;
            }
        }

        public double TempUnitPrice
        {
            get
            {
                return this.tempUnitPrice;
            }
            set
            {
                this.tempUnitPrice = value;
            }
        }

        public double Total_Price
        {
            get;
            set;
        }

        public double Total_Tax
        {
            get;
            set;
        }

        public double TotalPrice
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

        public double TotalPricet
        {
            get
            {
                return this.dblTotalPricet;
            }
            set
            {
                this.dblTotalPricet = value;
            }
        }

        public double TotalPurchasePrice
        {
            get;
            set;
        }

        public double TotalTax
        {
            get;
            set;
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

        public double TTI
        {
            get;
            set;
        }

        public double TTI_Amount
        {
            get;
            set;
        }

        public string TTIStatus
        {
            get;
            set;
        }

        public string UltimateDestination
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public double Unit_Price
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

        public double UnitPriceBDT
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

        public double UnitPriceTotal
        {
            get
            {
                return this.unitPriceTotal;
            }
            set
            {
                this.unitPriceTotal = value;
            }
        }

        public double UnitSalePriceBDT
        {
            get
            {
                return this.dblUnitSalePrice;
            }
            set
            {
                this.dblUnitSalePrice = value;
            }
        }

        public double UsedItemPrice
        {
            get
            {
                return this.usedItemPrice;
            }
            set
            {
                this.usedItemPrice = value;
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

        public double VAT
        {
            get;
            set;
        }

        public double VAT_Amount
        {
            get;
            set;
        }

        public double VATRate
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

        public string VATStatus
        {
            get;
            set;
        }

        public double VDSAmount
        {
            get
            {
                return this.vDSAmount;
            }
            set
            {
                this.vDSAmount = value;
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

        public PurchaseDetailDAO()
        {
        }
    }
}