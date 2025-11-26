using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PurchaseMasterDAO
    {
        private int intChallanID;

        private short shOrganizatioID;

        private int noOfItem;

        private int totalPack;

        private int prtCode;

        private double exhRate;

        private char chChallanType = 'P';

        private char chPurchaseType = 'L';

        private char chTransactionType = 'B';

        private char chType = 'G';

        private DateTime dtChallanDate;

        private DateTime dtDeliveryDate;

        private string strUltimateDestination;

        private string strScrollNo;

        private string strBankName;

        private string strBranchName;

        private short shVehicleTypeM;

        private short shVehicleTypeD;

        private string strVehicleNo;

        private short shIsDeleted;

        private short shUserIdInsert;

        private short shUserIdUpdate;

        private short shAuditSeqNo;

        private short shAuditUserID;

        private DateTime dtAuditDate;

        private string strChallanNo;

        private short shPartyID;

        private bool blIsNewParty;

        private string strTransPartyName;

        private string strPartyTIN;

        private string strPartAddress;

        private string strInsuranceNo;

        private string strLCNo;

        private DateTime dtLCDate;

        private double dblLCAmount;

        private string strBLNo;

        private DateTime dtBLDate;

        private string strPortCode;

        private int strPrtCode;

        private string strPortFrom;

        private string strPortTo;

        private short shBankBranchId;

        private double shLCForeignAmount;

        private double dblInsuranceAmount;

        private short strLCForeingnCurrencyUnit;

        private string strRemarks;

        private DateTime dtStartDate;

        private DateTime dtFinishDate;

        private string payment_information;

        private string strPaymentMethod;

        private double cashamount;

        private double bankamount;

        private double creditamount;

        private bool ispaymentfinished;

        private short bankId;

        private string releaseOrderNo;

        private DateTime shipmentDate;

        private string supplierName;

        private string supplierAddress;

        private string supplierCounty;

        private string lCForeignCurrency;

        private short countryId;

        private DateTime taxPaymentDate;

        private int org_branch_reg_id;

        private string paymentMethodP;

        private DateTime releaseOrderDate;

        public string AggrementNo
        {
            get;
            set;
        }

        public string ApproveStage
        {
            get;
            set;
        }

        public DateTime AuditDate
        {
            get
            {
                return this.dtAuditDate;
            }
            set
            {
                this.dtAuditDate = value;
            }
        }

        public short AuditSeqNo
        {
            get
            {
                return this.shAuditSeqNo;
            }
            set
            {
                this.shAuditSeqNo = value;
            }
        }

        public short AuditUserID
        {
            get
            {
                return this.shAuditUserID;
            }
            set
            {
                this.shAuditUserID = value;
            }
        }

        public double BankAmount
        {
            get
            {
                return this.bankamount;
            }
            set
            {
                this.bankamount = value;
            }
        }

        public short BankBranchId
        {
            get
            {
                return this.shBankBranchId;
            }
            set
            {
                this.shBankBranchId = value;
            }
        }

        public short BankId
        {
            get
            {
                return this.bankId;
            }
            set
            {
                this.bankId = value;
            }
        }

        public string BankName
        {
            get
            {
                return this.strBankName;
            }
            set
            {
                this.strBankName = value;
            }
        }

        public DateTime BLDate
        {
            get
            {
                return this.dtBLDate;
            }
            set
            {
                this.dtBLDate = value;
            }
        }

        public string BLNo
        {
            get
            {
                return this.strBLNo;
            }
            set
            {
                this.strBLNo = value;
            }
        }

        public string BranchName
        {
            get
            {
                return this.strBranchName;
            }
            set
            {
                this.strBranchName = value;
            }
        }

        public double CashAmount
        {
            get
            {
                return this.cashamount;
            }
            set
            {
                this.cashamount = value;
            }
        }

        public string CChallanNo
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

        public string ChallanNo
        {
            get
            {
                return this.strChallanNo;
            }
            set
            {
                this.strChallanNo = value;
            }
        }

        public char ChallanType
        {
            get
            {
                return this.chChallanType;
            }
            set
            {
                this.chChallanType = value;
            }
        }

        public short CountryId
        {
            get
            {
                return this.countryId;
            }
            set
            {
                this.countryId = value;
            }
        }

        public string CPC
        {
            get;
            set;
        }

        public double CreditAmount
        {
            get
            {
                return this.creditamount;
            }
            set
            {
                this.creditamount = value;
            }
        }

        public DateTime DeliveryDate
        {
            get
            {
                return this.dtDeliveryDate;
            }
            set
            {
                this.dtDeliveryDate = value;
            }
        }

        public double ExhRate
        {
            get
            {
                return this.exhRate;
            }
            set
            {
                this.exhRate = value;
            }
        }

        public DateTime FinishDate
        {
            get
            {
                return this.dtFinishDate;
            }
            set
            {
                this.dtFinishDate = value;
            }
        }

        public double InsuranceAmount
        {
            get
            {
                return this.dblInsuranceAmount;
            }
            set
            {
                this.dblInsuranceAmount = value;
            }
        }

        public string InsuranceNo
        {
            get
            {
                return this.strInsuranceNo;
            }
            set
            {
                this.strInsuranceNo = value;
            }
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

        public bool IsNewParty
        {
            get
            {
                return this.blIsNewParty;
            }
            set
            {
                this.blIsNewParty = value;
            }
        }

        public bool IsPaymentFinished
        {
            get
            {
                return this.ispaymentfinished;
            }
            set
            {
                this.ispaymentfinished = value;
            }
        }

        public double LCAmount
        {
            get
            {
                return this.dblLCAmount;
            }
            set
            {
                this.dblLCAmount = value;
            }
        }

        public DateTime LCDate
        {
            get
            {
                return this.dtLCDate;
            }
            set
            {
                this.dtLCDate = value;
            }
        }

        public double LCForeignAmount
        {
            get
            {
                return this.shLCForeignAmount;
            }
            set
            {
                this.shLCForeignAmount = value;
            }
        }

        public string LCForeignCurrency
        {
            get
            {
                return this.lCForeignCurrency;
            }
            set
            {
                this.lCForeignCurrency = value;
            }
        }

        public short LCForeingnCurrencyUnit
        {
            get
            {
                return this.strLCForeingnCurrencyUnit;
            }
            set
            {
                this.strLCForeingnCurrencyUnit = value;
            }
        }

        public string LCNo
        {
            get
            {
                return this.strLCNo;
            }
            set
            {
                this.strLCNo = value;
            }
        }

        public int NoOfItem
        {
            get
            {
                return this.noOfItem;
            }
            set
            {
                this.noOfItem = value;
            }
        }

        public int Org_branch_reg_id
        {
            get
            {
                return this.org_branch_reg_id;
            }
            set
            {
                this.org_branch_reg_id = value;
            }
        }

        public short OrganizatioID
        {
            get
            {
                return this.shOrganizatioID;
            }
            set
            {
                this.shOrganizatioID = value;
            }
        }

        public string PartAddress
        {
            get
            {
                return this.strPartAddress;
            }
            set
            {
                this.strPartAddress = value;
            }
        }

        public short PartyID
        {
            get
            {
                return this.shPartyID;
            }
            set
            {
                this.shPartyID = value;
            }
        }

        public string PartyTIN
        {
            get
            {
                return this.strPartyTIN;
            }
            set
            {
                this.strPartyTIN = value;
            }
        }

        public string PaymentInfo
        {
            get
            {
                return this.payment_information;
            }
            set
            {
                this.payment_information = value;
            }
        }

        public string PaymentMethod
        {
            get
            {
                return this.strPaymentMethod;
            }
            set
            {
                this.strPaymentMethod = value;
            }
        }

        public string PaymentMethodP
        {
            get
            {
                return this.paymentMethodP;
            }
            set
            {
                this.paymentMethodP = value;
            }
        }

        public string PortCode
        {
            get
            {
                return this.strPortCode;
            }
            set
            {
                this.strPortCode = value;
            }
        }

        public string PortFrom
        {
            get
            {
                return this.strPortFrom;
            }
            set
            {
                this.strPortFrom = value;
            }
        }

        public string PortTo
        {
            get
            {
                return this.strPortTo;
            }
            set
            {
                this.strPortTo = value;
            }
        }

        public double priceWithoutVDS
        {
            get;
            set;
        }

        public double proportionAIT
        {
            get;
            set;
        }

        public double proportionVAT
        {
            get;
            set;
        }

        public int PrtCode
        {
            get
            {
                return this.prtCode;
            }
            set
            {
                this.prtCode = value;
            }
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

        public DateTime RefChallanDate
        {
            get;
            set;
        }

        public DateTime ReleaseOrderDate
        {
            get
            {
                return this.releaseOrderDate;
            }
            set
            {
                this.releaseOrderDate = value;
            }
        }

        public string ReleaseOrderNo
        {
            get
            {
                return this.releaseOrderNo;
            }
            set
            {
                this.releaseOrderNo = value;
            }
        }

        public string Remarks
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

        public string ScrollNo
        {
            get
            {
                return this.strScrollNo;
            }
            set
            {
                this.strScrollNo = value;
            }
        }

        public DateTime ShipmentDate
        {
            get
            {
                return this.shipmentDate;
            }
            set
            {
                this.shipmentDate = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.dtStartDate;
            }
            set
            {
                this.dtStartDate = value;
            }
        }

        public string Subject
        {
            get;
            set;
        }

        public string SupplierAddress
        {
            get
            {
                return this.supplierAddress;
            }
            set
            {
                this.supplierAddress = value;
            }
        }

        public string SupplierCounty
        {
            get
            {
                return this.supplierCounty;
            }
            set
            {
                this.supplierCounty = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return this.supplierName;
            }
            set
            {
                this.supplierName = value;
            }
        }

        public DateTime TaxPaymentDate
        {
            get
            {
                return this.taxPaymentDate;
            }
            set
            {
                this.taxPaymentDate = value;
            }
        }

        public int TotalPack
        {
            get
            {
                return this.totalPack;
            }
            set
            {
                this.totalPack = value;
            }
        }

        public char TransactionType
        {
            get
            {
                return this.chTransactionType;
            }
            set
            {
                this.chTransactionType = value;
            }
        }

        public string TransPartyName
        {
            get
            {
                return this.strTransPartyName;
            }
            set
            {
                this.strTransPartyName = value;
            }
        }

        public char Type
        {
            get
            {
                return this.chType;
            }
            set
            {
                this.chType = value;
            }
        }

        public string UltimateDestination
        {
            get
            {
                return this.strUltimateDestination;
            }
            set
            {
                this.strUltimateDestination = value;
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

        public string VehicleNo
        {
            get
            {
                return this.strVehicleNo;
            }
            set
            {
                this.strVehicleNo = value;
            }
        }

        public short VehicleTypeD
        {
            get
            {
                return this.shVehicleTypeD;
            }
            set
            {
                this.shVehicleTypeD = value;
            }
        }

        public short VehicleTypeM
        {
            get
            {
                return this.shVehicleTypeM;
            }
            set
            {
                this.shVehicleTypeM = value;
            }
        }

        public PurchaseMasterDAO()
        {
        }
    }
}