using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class VatReturnCSV
    {
        private string organizationName;

        private string organizationBin;

        private string vatTerm;

        private bool rules64;

        private bool rules66;

        private bool rules67;

        private bool pastTaxPeriod;

        private DateTime insertDate;

        private string strInsertDate;

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

        private double zeroLocalPurchaseN9;

        private double zeroPurchaseImportN10;

        private double standardLocalPurchaseAmountN11;

        private double standardLocalPurchaseVatN11;

        private double standardPurchaseImportAmountN12;

        private double standardPurchaseImportVatN12;

        private double bLPurchaseAmountN13;

        private double bLPurchaseVatN13;

        private double totalVatP4N14;

        private double increaseVDSAmountN15;

        private double nonBankingAmountN16;

        private double changePurchaseAmountN17;

        private double increaseOtherAdjusmentN18;

        private double totalIncreaseAdjusmentN19;

        private double decreaseVDSAmountN20;

        private double changeSaleAmountN21;

        private double decreaseSDAmountN22;

        private double decreaseOtherAdjusmentN23;

        private double totalDecreaseAdjusmentN24;

        private double totalVatSDN25;

        private double mushok18N26;

        private double decreaseAmountN27;

        private double advanceTaxN28;

        private double negativeAmountN29;

        private double exciseDutyP7N30;

        private double surechargeP7N31;

        private double totalVatN32;

        private double exciseDutyP8N33;

        private double surechargeP8N34;

        private bool carryForwordN35;

        private bool cashBackN35;

        private double refundAmountN35;

        private string dutyOfficerName;

        private string dutyOfficerDesignation;

        private DateTime reportEntryDate;

        private string dutyOfficerMobile;

        private string dutyOfficerEmail;

        private string strReportEntryDate;

        public double AdvanceTaxN28
        {
            get
            {
                return this.advanceTaxN28;
            }
            set
            {
                this.advanceTaxN28 = value;
            }
        }

        public double BLPurchaseAmountN13
        {
            get
            {
                return this.bLPurchaseAmountN13;
            }
            set
            {
                this.bLPurchaseAmountN13 = value;
            }
        }

        public double BLPurchaseVatN13
        {
            get
            {
                return this.bLPurchaseVatN13;
            }
            set
            {
                this.bLPurchaseVatN13 = value;
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

        public bool CarryForwordN35
        {
            get
            {
                return this.carryForwordN35;
            }
            set
            {
                this.carryForwordN35 = value;
            }
        }

        public bool CashBackN35
        {
            get
            {
                return this.cashBackN35;
            }
            set
            {
                this.cashBackN35 = value;
            }
        }

        public double ChangePurchaseAmountN17
        {
            get
            {
                return this.changePurchaseAmountN17;
            }
            set
            {
                this.changePurchaseAmountN17 = value;
            }
        }

        public double ChangeSaleAmountN21
        {
            get
            {
                return this.changeSaleAmountN21;
            }
            set
            {
                this.changeSaleAmountN21 = value;
            }
        }

        public double DecreaseAmountN27
        {
            get
            {
                return this.decreaseAmountN27;
            }
            set
            {
                this.decreaseAmountN27 = value;
            }
        }

        public double DecreaseOtherAdjusmentN23
        {
            get
            {
                return this.decreaseOtherAdjusmentN23;
            }
            set
            {
                this.decreaseOtherAdjusmentN23 = value;
            }
        }

        public double DecreaseSDAmountN22
        {
            get
            {
                return this.decreaseSDAmountN22;
            }
            set
            {
                this.decreaseSDAmountN22 = value;
            }
        }

        public double DecreaseVDSAmountN20
        {
            get
            {
                return this.decreaseVDSAmountN20;
            }
            set
            {
                this.decreaseVDSAmountN20 = value;
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

        public double ExciseDutyP7N30
        {
            get
            {
                return this.exciseDutyP7N30;
            }
            set
            {
                this.exciseDutyP7N30 = value;
            }
        }

        public double ExciseDutyP8N33
        {
            get
            {
                return this.exciseDutyP8N33;
            }
            set
            {
                this.exciseDutyP8N33 = value;
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

        public double IncreaseOtherAdjusmentN18
        {
            get
            {
                return this.increaseOtherAdjusmentN18;
            }
            set
            {
                this.increaseOtherAdjusmentN18 = value;
            }
        }

        public double IncreaseVDSAmountN15
        {
            get
            {
                return this.increaseVDSAmountN15;
            }
            set
            {
                this.increaseVDSAmountN15 = value;
            }
        }

        public double Mushok18N26
        {
            get
            {
                return this.mushok18N26;
            }
            set
            {
                this.mushok18N26 = value;
            }
        }

        public double NegativeAmountN29
        {
            get
            {
                return this.negativeAmountN29;
            }
            set
            {
                this.negativeAmountN29 = value;
            }
        }

        public double NonBankingAmountN16
        {
            get
            {
                return this.nonBankingAmountN16;
            }
            set
            {
                this.nonBankingAmountN16 = value;
            }
        }

        public string OrganizationBin
        {
            get
            {
                return this.organizationBin;
            }
            set
            {
                this.organizationBin = value;
            }
        }

        public string OrganizationName
        {
            get
            {
                return this.organizationName;
            }
            set
            {
                this.organizationName = value;
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

        public double RefundAmountN35
        {
            get
            {
                return this.refundAmountN35;
            }
            set
            {
                this.refundAmountN35 = value;
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

        public double StandardLocalPurchaseAmountN11
        {
            get
            {
                return this.standardLocalPurchaseAmountN11;
            }
            set
            {
                this.standardLocalPurchaseAmountN11 = value;
            }
        }

        public double StandardLocalPurchaseVatN11
        {
            get
            {
                return this.standardLocalPurchaseVatN11;
            }
            set
            {
                this.standardLocalPurchaseVatN11 = value;
            }
        }

        public double StandardPurchaseImportAmountN12
        {
            get
            {
                return this.standardPurchaseImportAmountN12;
            }
            set
            {
                this.standardPurchaseImportAmountN12 = value;
            }
        }

        public double StandardPurchaseImportVatN12
        {
            get
            {
                return this.standardPurchaseImportVatN12;
            }
            set
            {
                this.standardPurchaseImportVatN12 = value;
            }
        }

        public string StrInsertDate
        {
            get
            {
                return this.strInsertDate;
            }
            set
            {
                this.strInsertDate = value;
            }
        }

        public string StrReportEntryDate
        {
            get
            {
                return this.strReportEntryDate;
            }
            set
            {
                this.strReportEntryDate = value;
            }
        }

        public double SurechargeP7N31
        {
            get
            {
                return this.surechargeP7N31;
            }
            set
            {
                this.surechargeP7N31 = value;
            }
        }

        public double SurechargeP8N34
        {
            get
            {
                return this.surechargeP8N34;
            }
            set
            {
                this.surechargeP8N34 = value;
            }
        }

        public double TotalDecreaseAdjusmentN24
        {
            get
            {
                return this.totalDecreaseAdjusmentN24;
            }
            set
            {
                this.totalDecreaseAdjusmentN24 = value;
            }
        }

        public double TotalIncreaseAdjusmentN19
        {
            get
            {
                return this.totalIncreaseAdjusmentN19;
            }
            set
            {
                this.totalIncreaseAdjusmentN19 = value;
            }
        }

        public double TotalVatN32
        {
            get
            {
                return this.totalVatN32;
            }
            set
            {
                this.totalVatN32 = value;
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

        public double TotalVatP4N14
        {
            get
            {
                return this.totalVatP4N14;
            }
            set
            {
                this.totalVatP4N14 = value;
            }
        }

        public double TotalVatSDN25
        {
            get
            {
                return this.totalVatSDN25;
            }
            set
            {
                this.totalVatSDN25 = value;
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

        public double ZeroLocalPurchaseN9
        {
            get
            {
                return this.zeroLocalPurchaseN9;
            }
            set
            {
                this.zeroLocalPurchaseN9 = value;
            }
        }

        public double ZeroPurchaseImportN10
        {
            get
            {
                return this.zeroPurchaseImportN10;
            }
            set
            {
                this.zeroPurchaseImportN10 = value;
            }
        }

        public VatReturnCSV()
        {
        }

        public static VatReturnCSV FromCsv(string csvLine)
        {
            string[] strArrays = csvLine.Split(new char[] { ',' });
            VatReturnCSV vatReturnCSV = new VatReturnCSV()
            {
                organizationName = strArrays[0],
                organizationBin = strArrays[1],
                vatTerm = strArrays[2],
                rules64 = Convert.ToBoolean(strArrays[3]),
                rules66 = Convert.ToBoolean(strArrays[4]),
                rules67 = Convert.ToBoolean(strArrays[5]),
                pastTaxPeriod = Convert.ToBoolean(strArrays[6]),
                strInsertDate = strArrays[7],
                deemedExportN1 = Convert.ToDouble(strArrays[8]),
                directExportN2 = Convert.ToDouble(strArrays[9]),
                exemptSupplyN3 = Convert.ToDouble(strArrays[10]),
                typicalSupplyAmountN4 = Convert.ToDouble(strArrays[11]),
                typicalSupplyVatN4 = Convert.ToDouble(strArrays[12]),
                typicalSupplySDN4 = Convert.ToDouble(strArrays[13]),
                bLSupplyAmountN5 = Convert.ToDouble(strArrays[14]),
                bLSupplyVatN5 = Convert.ToDouble(strArrays[15]),
                totalVatP3N6 = Convert.ToDouble(strArrays[16]),
                exemptLocalPurchaseN7 = Convert.ToDouble(strArrays[17]),
                exemptPurchaseImportN8 = Convert.ToDouble(strArrays[18]),
                zeroLocalPurchaseN9 = Convert.ToDouble(strArrays[19]),
                zeroPurchaseImportN10 = Convert.ToDouble(strArrays[20]),
                standardLocalPurchaseAmountN11 = Convert.ToDouble(strArrays[21]),
                standardLocalPurchaseVatN11 = Convert.ToDouble(strArrays[22]),
                standardPurchaseImportAmountN12 = Convert.ToDouble(strArrays[23]),
                standardPurchaseImportVatN12 = Convert.ToDouble(strArrays[24]),
                bLPurchaseAmountN13 = Convert.ToDouble(strArrays[25]),
                bLPurchaseVatN13 = Convert.ToDouble(strArrays[26]),
                totalVatP4N14 = Convert.ToDouble(strArrays[27]),
                increaseVDSAmountN15 = Convert.ToDouble(strArrays[28]),
                nonBankingAmountN16 = Convert.ToDouble(strArrays[29]),
                changePurchaseAmountN17 = Convert.ToDouble(strArrays[30]),
                increaseOtherAdjusmentN18 = Convert.ToDouble(strArrays[31]),
                totalIncreaseAdjusmentN19 = Convert.ToDouble(strArrays[32]),
                decreaseVDSAmountN20 = Convert.ToDouble(strArrays[33]),
                changeSaleAmountN21 = Convert.ToDouble(strArrays[34]),
                decreaseSDAmountN22 = Convert.ToDouble(strArrays[35]),
                decreaseOtherAdjusmentN23 = Convert.ToDouble(strArrays[36]),
                totalDecreaseAdjusmentN24 = Convert.ToDouble(strArrays[37]),
                totalVatSDN25 = Convert.ToDouble(strArrays[38]),
                mushok18N26 = Convert.ToDouble(strArrays[39]),
                decreaseAmountN27 = Convert.ToDouble(strArrays[40]),
                advanceTaxN28 = Convert.ToDouble(strArrays[41]),
                negativeAmountN29 = Convert.ToDouble(strArrays[42]),
                exciseDutyP7N30 = Convert.ToDouble(strArrays[43]),
                surechargeP7N31 = Convert.ToDouble(strArrays[44]),
                totalVatN32 = Convert.ToDouble(strArrays[45]),
                exciseDutyP8N33 = Convert.ToDouble(strArrays[46]),
                surechargeP8N34 = Convert.ToDouble(strArrays[47]),
                carryForwordN35 = Convert.ToBoolean(strArrays[48]),
                cashBackN35 = Convert.ToBoolean(strArrays[49]),
                refundAmountN35 = Convert.ToDouble(strArrays[50]),
                dutyOfficerName = strArrays[51],
                dutyOfficerDesignation = strArrays[52],
                strReportEntryDate = strArrays[53],
                dutyOfficerMobile = strArrays[54],
                dutyOfficerEmail = strArrays[55]
            };
            return vatReturnCSV;
        }
    }
}