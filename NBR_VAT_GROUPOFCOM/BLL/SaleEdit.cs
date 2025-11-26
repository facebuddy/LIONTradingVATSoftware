using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SaleEdit
    {
        private short rowNo;

        private short partyID;

        private string partyName;

        private string partyAddress;

        private string partyBIN;

        private string challanNO;

        private string challanDate;

        private string ultimateDestination;

        private string trnsType;

        private string saleType;

        private string type;

        private string vehecalType;

        private string vehecalNo;

        private int itemID;

        private string itemName;

        private string hSCode;

        private double quantity;

        private double usedquantity;

        private int unitID;

        private string unitName;

        private bool isVDS;

        private bool isExempted;

        private bool isRebatable;

        private bool isZeroRate;

        private short userID;

        private double sUnitPrice;

        private double sVatablePrice;

        private double sVat;

        private double sSD;

        private double vDSAmount;

        private long detailID;

        private string productType;

        private DateTime updateDate;

        private long challanID;

        public string ChallanDate
        {
            get
            {
                return this.challanDate;
            }
            set
            {
                this.challanDate = value;
            }
        }

        public long ChallanID
        {
            get
            {
                return this.challanID;
            }
            set
            {
                this.challanID = value;
            }
        }

        public string ChallanNO
        {
            get
            {
                return this.challanNO;
            }
            set
            {
                this.challanNO = value;
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

        public string HSCode
        {
            get
            {
                return this.hSCode;
            }
            set
            {
                this.hSCode = value;
            }
        }

        public bool IsExempted
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

        public bool IsRebatable
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

        public bool IsZeroRate
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

        public int ItemID
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

        public string PartyAddress
        {
            get
            {
                return this.partyAddress;
            }
            set
            {
                this.partyAddress = value;
            }
        }

        public string PartyBIN
        {
            get
            {
                return this.partyBIN;
            }
            set
            {
                this.partyBIN = value;
            }
        }

        public short PartyID
        {
            get
            {
                return this.partyID;
            }
            set
            {
                this.partyID = value;
            }
        }

        public string PartyName
        {
            get
            {
                return this.partyName;
            }
            set
            {
                this.partyName = value;
            }
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

        public double Quantity
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

        public string SaleType
        {
            get
            {
                return this.saleType;
            }
            set
            {
                this.saleType = value;
            }
        }

        public double SSD
        {
            get
            {
                return this.sSD;
            }
            set
            {
                this.sSD = value;
            }
        }

        public double SUnitPrice
        {
            get
            {
                return this.sUnitPrice;
            }
            set
            {
                this.sUnitPrice = value;
            }
        }

        public double SVat
        {
            get
            {
                return this.sVat;
            }
            set
            {
                this.sVat = value;
            }
        }

        public double SVatablePrice
        {
            get
            {
                return this.sVatablePrice;
            }
            set
            {
                this.sVatablePrice = value;
            }
        }

        public string TrnsType
        {
            get
            {
                return this.trnsType;
            }
            set
            {
                this.trnsType = value;
            }
        }

        public string Type
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

        public string UltimateDestination
        {
            get
            {
                return this.ultimateDestination;
            }
            set
            {
                this.ultimateDestination = value;
            }
        }

        public int UnitID
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

        public DateTime UpdateDate
        {
            get
            {
                return this.updateDate;
            }
            set
            {
                this.updateDate = value;
            }
        }

        public double UsedQuantity
        {
            get
            {
                return this.usedquantity;
            }
            set
            {
                this.usedquantity = value;
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

        public string VehecalNo
        {
            get
            {
                return this.vehecalNo;
            }
            set
            {
                this.vehecalNo = value;
            }
        }

        public string VehecalType
        {
            get
            {
                return this.vehecalType;
            }
            set
            {
                this.vehecalType = value;
            }
        }

        public SaleEdit()
        {
        }
    }
}
