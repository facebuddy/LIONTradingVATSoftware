using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SaleMasterDAON
    {
        private int intChallanID;

        private int intChallanBookID;

        private int intChallanPageNo;

        private short shOrganizatioID;

        private char chChallanType = 'S';

        private char chSaleType = 'W';

        private char strTransactionType = 'L';

        private DateTime dtChallanDate;

        private DateTime dtDeliveryDate;

        private string strUltimateDestination;

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

        private double cashamount;

        private double bankamount;

        private double creditamount;

        private bool ispaymentfinished;

        private double totalBillAmount;

        private double totalVat;

        private double totalVds;

        private double totalAit;

        private double paidVat;

        private double paidVds;

        private double paidAit;

        private short shPartyID;

        private bool blIsNewParty;

        private string strTransPartyName;

        private string strPartyTIN;

        private string strPartAddress;

        private short shComGenChallanNo;

        private string strDispPurChlnNo;

        private string strDispSaleChlnNo;

        private DateTime dtExportDate;

        private string strExportBillNo;

        private short shBankID;

        private short shBranchID;

        private string strRemarks;

        private int intPurchaseChallanId;

        private int intChallanPageDiscardReason_m;

        private int intChallanPageDiscardReason_d;

        private string orgName;

        private string orgBin;

        private string orgAddress;

        private string challanTime;

        private string date;

        private int org_branch_reg_id;

        private string paymentMethodP;

        public decimal discountm;

        public decimal discount_pctm;

        private string payment_information;

        private string strPaymentMethod;

        public string AggrementNo
        {
            get;
            set;
        }

        public string approvalRefNo
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

        public short BankID
        {
            get
            {
                return this.shBankID;
            }
            set
            {
                this.shBankID = value;
            }
        }

        public short BranchID
        {
            get
            {
                return this.shBranchID;
            }
            set
            {
                this.shBranchID = value;
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

        public int ChallanBookID
        {
            get
            {
                return this.intChallanBookID;
            }
            set
            {
                this.intChallanBookID = value;
            }
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

        public int ChallanPageDiscardReason_d
        {
            get
            {
                return this.intChallanPageDiscardReason_d;
            }
            set
            {
                this.intChallanPageDiscardReason_d = value;
            }
        }

        public int ChallanPageDiscardReason_m
        {
            get
            {
                return this.intChallanPageDiscardReason_m;
            }
            set
            {
                this.intChallanPageDiscardReason_m = value;
            }
        }

        public int ChallanPageNo
        {
            get
            {
                return this.intChallanPageNo;
            }
            set
            {
                this.intChallanPageNo = value;
            }
        }

        public string ChallanTime
        {
            get
            {
                return this.challanTime;
            }
            set
            {
                this.challanTime = value;
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

        public short ComGenChallanNo
        {
            get
            {
                return this.shComGenChallanNo;
            }
            set
            {
                this.shComGenChallanNo = value;
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

        public decimal currentBalance
        {
            get;
            set;
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string DeleveryDateTime
        {
            get;
            set;
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

        public decimal Discount_pctm
        {
            get
            {
                return this.discount_pctm;
            }
            set
            {
                this.discount_pctm = value;
            }
        }

        public decimal Discountm
        {
            get
            {
                return this.discountm;
            }
            set
            {
                this.discountm = value;
            }
        }

        public string DispPurChlnNo
        {
            get
            {
                return this.strDispPurChlnNo;
            }
            set
            {
                this.strDispPurChlnNo = value;
            }
        }

        public string DispSaleChlnNo
        {
            get
            {
                return this.strDispSaleChlnNo;
            }
            set
            {
                this.strDispSaleChlnNo = value;
            }
        }

        public decimal downPaymment
        {
            get;
            set;
        }

        public decimal dueBalance
        {
            get;
            set;
        }

        public string ExportBillNo
        {
            get
            {
                return this.strChallanNo;
            }
            set
            {
                this.strExportBillNo = value;
            }
        }

        public DateTime ExportDate
        {
            get
            {
                return this.dtExportDate;
            }
            set
            {
                this.dtExportDate = value;
            }
        }

        public string Invoice_No
        {
            get;
            set;
        }

        public string isApproved
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

        public bool isFinalSaved
        {
            get;
            set;
        }

        public bool Isinstallment
        {
            get;
            set;
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

        public int noofItem
        {
            get;
            set;
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

        public string OrgAddress
        {
            get
            {
                return this.orgAddress;
            }
            set
            {
                this.orgAddress = value;
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

        public string OrgBin
        {
            get
            {
                return this.orgBin;
            }
            set
            {
                this.orgBin = value;
            }
        }

        public string OrgName
        {
            get
            {
                return this.orgName;
            }
            set
            {
                this.orgName = value;
            }
        }

        public double PaidAit
        {
            get
            {
                return this.paidAit;
            }
            set
            {
                this.paidAit = value;
            }
        }

        public double PaidVat
        {
            get
            {
                return this.paidVat;
            }
            set
            {
                this.paidVat = value;
            }
        }

        public double PaidVds
        {
            get
            {
                return this.paidVds;
            }
            set
            {
                this.paidVds = value;
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

        public string PartyNID
        {
            get;
            set;
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

        public int portcodeId
        {
            get;
            set;
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

        public int PurchaseChallanId
        {
            get
            {
                return this.intPurchaseChallanId;
            }
            set
            {
                this.intPurchaseChallanId = value;
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

        public char SalesProductType
        {
            get;
            set;
        }

        public char SaleType
        {
            get
            {
                return this.chSaleType;
            }
            set
            {
                this.chSaleType = value;
            }
        }

        public decimal sdPaid
        {
            get;
            set;
        }

        public decimal ServiceCharge
        {
            get;
            set;
        }

        public double TotalAit
        {
            get
            {
                return this.totalAit;
            }
            set
            {
                this.totalAit = value;
            }
        }

        public double TotalBillAmount
        {
            get
            {
                return this.totalBillAmount;
            }
            set
            {
                this.totalBillAmount = value;
            }
        }

        public int totalPack
        {
            get;
            set;
        }

        public double TotalVat
        {
            get
            {
                return this.totalVat;
            }
            set
            {
                this.totalVat = value;
            }
        }

        public double TotalVds
        {
            get
            {
                return this.totalVds;
            }
            set
            {
                this.totalVds = value;
            }
        }

        public char TransactionType
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

        public decimal vatPaid
        {
            get;
            set;
        }

        public string Vehicle
        {
            get;
            set;
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

        public SaleMasterDAON()
        {
        }
    }
}