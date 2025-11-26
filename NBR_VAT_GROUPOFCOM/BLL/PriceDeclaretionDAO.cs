using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PriceDeclaretionDAO
    {
        private int priceID;

        private int organizationID;

        private string priceDeclaretionNo;

        private int priceDeclaretionYear;

        private DateTime activeDate;

        private int itemID;

        private int unitID;

        private decimal currentSDChargablePrice;

        private decimal proposedSDChargablePrice;

        private decimal SD;

        private decimal currentVATChargablePrice;

        private decimal proposedVATChargablePrice;

        private decimal wholeSalePrice;

        private decimal retailPrice;

        private int userIDInsert;

        private decimal nbrSDChargablePrice;

        private decimal nbrSD;

        private decimal tradePricePct;

        private decimal tradePriceValue;

        private decimal nbrVATChargablePrice;

        private decimal nbrWholeSalePrice;

        private decimal nbrRetailPrice;

        private int CGN;

        private int productQuantity;

        private decimal proposedActualPrice;

        private DateTime nbrDate;

        private decimal nbrActualPrice;

        private int DeclarationType;

        private string Remarks;

        private decimal total_Price;

        private int branchID;

        private string agreementNo;

        private decimal trade_price_value;

        public string AgreementNo
        {
            get
            {
                return this.agreementNo;
            }
            set
            {
                this.agreementNo = value;
            }
        }

        public int BranchID
        {
            get
            {
                return this.branchID;
            }
            set
            {
                this.branchID = value;
            }
        }

        public decimal decCurrentSDChargablePrice
        {
            get
            {
                return this.currentSDChargablePrice;
            }
            set
            {
                this.currentSDChargablePrice = value;
            }
        }

        public decimal decCurrentVATChargablePrice
        {
            get
            {
                return this.currentVATChargablePrice;
            }
            set
            {
                this.currentVATChargablePrice = value;
            }
        }

        public decimal decNBRActualPrice
        {
            get
            {
                return this.nbrActualPrice;
            }
            set
            {
                this.nbrActualPrice = value;
            }
        }

        public decimal decNBRRetailPrice
        {
            get
            {
                return this.nbrRetailPrice;
            }
            set
            {
                this.nbrRetailPrice = value;
            }
        }

        public decimal decNBRSD
        {
            get
            {
                return this.nbrSD;
            }
            set
            {
                this.nbrSD = value;
            }
        }

        public decimal decNBRSDChargablePrice
        {
            get
            {
                return this.nbrSDChargablePrice;
            }
            set
            {
                this.nbrSDChargablePrice = value;
            }
        }

        public decimal decNBRVATChargablePrice
        {
            get
            {
                return this.nbrVATChargablePrice;
            }
            set
            {
                this.nbrVATChargablePrice = value;
            }
        }

        public decimal decNBRWholeSalePrice
        {
            get
            {
                return this.nbrWholeSalePrice;
            }
            set
            {
                this.nbrWholeSalePrice = value;
            }
        }

        public decimal decProposedActualPrice
        {
            get
            {
                return this.proposedActualPrice;
            }
            set
            {
                this.proposedActualPrice = value;
            }
        }

        public decimal decProposedSDChargablePric
        {
            get
            {
                return this.proposedSDChargablePrice;
            }
            set
            {
                this.proposedSDChargablePrice = value;
            }
        }

        public decimal decProposedVATChargabelPrice
        {
            get
            {
                return this.proposedVATChargablePrice;
            }
            set
            {
                this.proposedVATChargablePrice = value;
            }
        }

        public decimal decRetailPrice
        {
            get
            {
                return this.retailPrice;
            }
            set
            {
                this.retailPrice = value;
            }
        }

        public decimal decSD
        {
            get
            {
                return this.SD;
            }
            set
            {
                this.SD = value;
            }
        }

        public decimal decWholeSalePrice
        {
            get
            {
                return this.wholeSalePrice;
            }
            set
            {
                this.wholeSalePrice = value;
            }
        }

        public DateTime dtActiveDate
        {
            get
            {
                return this.activeDate;
            }
            set
            {
                this.activeDate = value;
            }
        }

        public DateTime dtNBRDate
        {
            get
            {
                return this.nbrDate;
            }
            set
            {
                this.nbrDate = value;
            }
        }

        public decimal HealthCharge
        {
            get;
            set;
        }

        public int intCGN
        {
            get
            {
                return this.CGN;
            }
            set
            {
                this.CGN = value;
            }
        }

        public int intDeclarationType
        {
            get
            {
                return this.DeclarationType;
            }
            set
            {
                this.DeclarationType = value;
            }
        }

        public int intItemId
        {
            get
            {
                return this.itemID;
            }
            set
            {
                this.itemID = value;
            }
        }

        public int intOrganizationID
        {
            get
            {
                return this.organizationID;
            }
            set
            {
                this.organizationID = value;
            }
        }

        public int intPriceDeclaretionYear
        {
            get
            {
                return this.priceDeclaretionYear;
            }
            set
            {
                this.priceDeclaretionYear = value;
            }
        }

        public int intPriceID
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

        public int intUnitId
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

        public int intUnitIdSecond
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

        public int intUserIdInsert
        {
            get
            {
                return this.userIDInsert;
            }
            set
            {
                this.userIDInsert = value;
            }
        }

        public int ProductQuantity
        {
            get
            {
                return this.productQuantity;
            }
            set
            {
                this.productQuantity = value;
            }
        }

        public int property_id
        {
            get;
            set;
        }

        public decimal sdrate
        {
            get;
            set;
        }

        public decimal StickQuantity
        {
            get;
            set;
        }

        public string strPriceDeclaretionNo
        {
            get
            {
                return this.priceDeclaretionNo;
            }
            set
            {
                this.priceDeclaretionNo = value;
            }
        }

        public string strRemarks
        {
            get
            {
                return this.Remarks;
            }
            set
            {
                this.Remarks = value;
            }
        }

        public decimal Total_Price
        {
            get
            {
                return this.total_Price;
            }
            set
            {
                this.total_Price = value;
            }
        }

        public decimal TotalAmount
        {
            get;
            set;
        }

        public decimal TotalOtherAmount
        {
            get;
            set;
        }

        public decimal TotalValueAdditionAmount
        {
            get;
            set;
        }

        public decimal Trade_price_value
        {
            get
            {
                return this.trade_price_value;
            }
            set
            {
                this.trade_price_value = value;
            }
        }

        public decimal TradePricePct
        {
            get
            {
                return this.tradePricePct;
            }
            set
            {
                this.tradePricePct = value;
            }
        }

        public decimal TradePriceValue
        {
            get
            {
                return this.tradePriceValue;
            }
            set
            {
                this.tradePriceValue = value;
            }
        }

        public decimal vatrate
        {
            get;
            set;
        }

        public PriceDeclaretionDAO()
        {
        }
    }
}