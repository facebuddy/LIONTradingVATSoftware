using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class VatReturnDAO
    {
        private long reportId;

        private long orgId;

        private int cgNo;

        private string vatTerm;

        private bool rules64;

        private bool rules66;

        private bool rules67;

        private bool pastTaxPeriod;

        private DateTime insertDate;

        private double deemedExportN1;

        private double directExportN2;

        private double exemptSupplyN3;

        private double typicalSupplyAmountN4;

        private double typicalSupplyVatN4;

        private double typicalSupplySDN4;

        private double bLSupplyAmountN5;

        private double bLSupplyVatN5;

        private double totalVatP3N6;

        private double exemptLocalPurchaseN7;

        private double exemptPurchaseImportN8;

        private double standardLocalPurchaseAmountN9;

        private double standardLocalPurchaseVatN9;

        private double standardPurchaseImportAmountN10;

        private double standardPurchaseImportVatN10;

        private double bLPurchaseAmountN11;

        private double bLPurchaseVatN11;

        private double totalVatP4N12;

        private double increaseVDSAmountN13;

        private double nonBankingAmountN14;

        private double changePurchaseAmountN15;

        private double increaseOtherAdjusmentN16;

        private double totalIncreaseAdjusmentN17;

        private double decreaseVDSAmountN18;

        private double changeSaleAmountN19;

        private double decreaseSDAmountN20;

        private double decreaseOtherAdjusmentN21;

        private double totalDecreaseAdjusmentN22;

        private double totalVatSDN23;

        private double mushok18N24;

        private double decreaseAmountN25;

        private double advanceTaxN26;

        private double negativeAmountN27;

        private double exciseDutyP7N28;

        private double surechargeP7N29;

        private double totalVatN30;

        private double exciseDutyP8N31;

        private double surechargeP8N32;

        private bool carryForwordN33;

        private bool cashBackN33;

        private double refundAmountN33;

        private string dutyOfficerName;

        private string dutyOfficerDesignation;

        private DateTime reportEntryDate;

        private string dutyOfficerMobile;

        private string dutyOfficerEmail;

        private string year;

        public double AdvanceTaxN26
        {
            get
            {
                return this.advanceTaxN26;
            }
            set
            {
                this.advanceTaxN26 = value;
            }
        }

        public double BLPurchaseAmountN11
        {
            get
            {
                return this.bLPurchaseAmountN11;
            }
            set
            {
                this.bLPurchaseAmountN11 = value;
            }
        }

        public double BLPurchaseVatN11
        {
            get
            {
                return this.bLPurchaseVatN11;
            }
            set
            {
                this.bLPurchaseVatN11 = value;
            }
        }

        public double BLSupplyAmountN5
        {
            get
            {
                return this.bLSupplyAmountN5;
            }
            set
            {
                this.bLSupplyAmountN5 = value;
            }
        }

        public double BLSupplyVatN5
        {
            get
            {
                return this.bLSupplyVatN5;
            }
            set
            {
                this.bLSupplyVatN5 = value;
            }
        }

        public bool CarryForwordN33
        {
            get
            {
                return this.carryForwordN33;
            }
            set
            {
                this.carryForwordN33 = value;
            }
        }

        public bool CashBackN33
        {
            get
            {
                return this.cashBackN33;
            }
            set
            {
                this.cashBackN33 = value;
            }
        }

        public int CgNo
        {
            get
            {
                return this.cgNo;
            }
            set
            {
                this.cgNo = value;
            }
        }

        public double ChangePurchaseAmountN15
        {
            get
            {
                return this.changePurchaseAmountN15;
            }
            set
            {
                this.changePurchaseAmountN15 = value;
            }
        }

        public double ChangeSaleAmountN19
        {
            get
            {
                return this.changeSaleAmountN19;
            }
            set
            {
                this.changeSaleAmountN19 = value;
            }
        }

        public double DecreaseAmountN25
        {
            get
            {
                return this.decreaseAmountN25;
            }
            set
            {
                this.decreaseAmountN25 = value;
            }
        }

        public double DecreaseOtherAdjusmentN21
        {
            get
            {
                return this.decreaseOtherAdjusmentN21;
            }
            set
            {
                this.decreaseOtherAdjusmentN21 = value;
            }
        }

        public double DecreaseSDAmountN20
        {
            get
            {
                return this.decreaseSDAmountN20;
            }
            set
            {
                this.decreaseSDAmountN20 = value;
            }
        }

        public double DecreaseVDSAmountN18
        {
            get
            {
                return this.decreaseVDSAmountN18;
            }
            set
            {
                this.decreaseVDSAmountN18 = value;
            }
        }

        public double DeemedExportN1
        {
            get
            {
                return this.deemedExportN1;
            }
            set
            {
                this.deemedExportN1 = value;
            }
        }

        public double DirectExportN2
        {
            get
            {
                return this.directExportN2;
            }
            set
            {
                this.directExportN2 = value;
            }
        }

        public string DutyOfficerDesignation
        {
            get
            {
                return this.dutyOfficerDesignation;
            }
            set
            {
                this.dutyOfficerDesignation = value;
            }
        }

        public string DutyOfficerEmail
        {
            get
            {
                return this.dutyOfficerEmail;
            }
            set
            {
                this.dutyOfficerEmail = value;
            }
        }

        public string DutyOfficerMobile
        {
            get
            {
                return this.dutyOfficerMobile;
            }
            set
            {
                this.dutyOfficerMobile = value;
            }
        }

        public string DutyOfficerName
        {
            get
            {
                return this.dutyOfficerName;
            }
            set
            {
                this.dutyOfficerName = value;
            }
        }

        public double ExciseDutyP7N28
        {
            get
            {
                return this.exciseDutyP7N28;
            }
            set
            {
                this.exciseDutyP7N28 = value;
            }
        }

        public double ExciseDutyP8N31
        {
            get
            {
                return this.exciseDutyP8N31;
            }
            set
            {
                this.exciseDutyP8N31 = value;
            }
        }

        public double ExemptLocalPurchaseN7
        {
            get
            {
                return this.exemptLocalPurchaseN7;
            }
            set
            {
                this.exemptLocalPurchaseN7 = value;
            }
        }

        public double ExemptPurchaseImportN8
        {
            get
            {
                return this.exemptPurchaseImportN8;
            }
            set
            {
                this.exemptPurchaseImportN8 = value;
            }
        }

        public double ExemptSupplyN3
        {
            get
            {
                return this.exemptSupplyN3;
            }
            set
            {
                this.exemptSupplyN3 = value;
            }
        }

        public double IncreaseOtherAdjusmentN16
        {
            get
            {
                return this.increaseOtherAdjusmentN16;
            }
            set
            {
                this.increaseOtherAdjusmentN16 = value;
            }
        }

        public double IncreaseVDSAmountN13
        {
            get
            {
                return this.increaseVDSAmountN13;
            }
            set
            {
                this.increaseVDSAmountN13 = value;
            }
        }

        public DateTime InsertDate
        {
            get
            {
                return this.insertDate;
            }
            set
            {
                this.insertDate = value;
            }
        }

        public double Mushok18N24
        {
            get
            {
                return this.mushok18N24;
            }
            set
            {
                this.mushok18N24 = value;
            }
        }

        public double NegativeAmountN27
        {
            get
            {
                return this.negativeAmountN27;
            }
            set
            {
                this.negativeAmountN27 = value;
            }
        }

        public double NonBankingAmountN14
        {
            get
            {
                return this.nonBankingAmountN14;
            }
            set
            {
                this.nonBankingAmountN14 = value;
            }
        }

        public long OrgId
        {
            get
            {
                return this.orgId;
            }
            set
            {
                this.orgId = value;
            }
        }

        public bool PastTaxPeriod
        {
            get
            {
                return this.pastTaxPeriod;
            }
            set
            {
                this.pastTaxPeriod = value;
            }
        }

        public double RefundAmountN33
        {
            get
            {
                return this.refundAmountN33;
            }
            set
            {
                this.refundAmountN33 = value;
            }
        }

        public DateTime ReportEntryDate
        {
            get
            {
                return this.reportEntryDate;
            }
            set
            {
                this.reportEntryDate = value;
            }
        }

        public long ReportId
        {
            get
            {
                return this.reportId;
            }
            set
            {
                this.reportId = value;
            }
        }

        public bool Rules64
        {
            get
            {
                return this.rules64;
            }
            set
            {
                this.rules64 = value;
            }
        }

        public bool Rules66
        {
            get
            {
                return this.rules66;
            }
            set
            {
                this.rules66 = value;
            }
        }

        public bool Rules67
        {
            get
            {
                return this.rules67;
            }
            set
            {
                this.rules67 = value;
            }
        }

        public double StandardLocalPurchaseAmountN9
        {
            get
            {
                return this.standardLocalPurchaseAmountN9;
            }
            set
            {
                this.standardLocalPurchaseAmountN9 = value;
            }
        }

        public double StandardLocalPurchaseVatN9
        {
            get
            {
                return this.standardLocalPurchaseVatN9;
            }
            set
            {
                this.standardLocalPurchaseVatN9 = value;
            }
        }

        public double StandardPurchaseImportAmountN10
        {
            get
            {
                return this.standardPurchaseImportAmountN10;
            }
            set
            {
                this.standardPurchaseImportAmountN10 = value;
            }
        }

        public double StandardPurchaseImportVatN10
        {
            get
            {
                return this.standardPurchaseImportVatN10;
            }
            set
            {
                this.standardPurchaseImportVatN10 = value;
            }
        }

        public double SurechargeP7N29
        {
            get
            {
                return this.surechargeP7N29;
            }
            set
            {
                this.surechargeP7N29 = value;
            }
        }

        public double SurechargeP8N32
        {
            get
            {
                return this.surechargeP8N32;
            }
            set
            {
                this.surechargeP8N32 = value;
            }
        }

        public double TotalDecreaseAdjusmentN22
        {
            get
            {
                return this.totalDecreaseAdjusmentN22;
            }
            set
            {
                this.totalDecreaseAdjusmentN22 = value;
            }
        }

        public double TotalIncreaseAdjusmentN17
        {
            get
            {
                return this.totalIncreaseAdjusmentN17;
            }
            set
            {
                this.totalIncreaseAdjusmentN17 = value;
            }
        }

        public double TotalVatN30
        {
            get
            {
                return this.totalVatN30;
            }
            set
            {
                this.totalVatN30 = value;
            }
        }

        public double TotalVatP3N6
        {
            get
            {
                return this.totalVatP3N6;
            }
            set
            {
                this.totalVatP3N6 = value;
            }
        }

        public double TotalVatP4N12
        {
            get
            {
                return this.totalVatP4N12;
            }
            set
            {
                this.totalVatP4N12 = value;
            }
        }

        public double TotalVatSDN23
        {
            get
            {
                return this.totalVatSDN23;
            }
            set
            {
                this.totalVatSDN23 = value;
            }
        }

        public double TypicalSupplyAmountN4
        {
            get
            {
                return this.typicalSupplyAmountN4;
            }
            set
            {
                this.typicalSupplyAmountN4 = value;
            }
        }

        public double TypicalSupplySDN4
        {
            get
            {
                return this.typicalSupplySDN4;
            }
            set
            {
                this.typicalSupplySDN4 = value;
            }
        }

        public double TypicalSupplyVatN4
        {
            get
            {
                return this.typicalSupplyVatN4;
            }
            set
            {
                this.typicalSupplyVatN4 = value;
            }
        }

        public string VatTerm
        {
            get
            {
                return this.vatTerm;
            }
            set
            {
                this.vatTerm = value;
            }
        }

        public string Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }

        public VatReturnDAO()
        {
        }
    }
}