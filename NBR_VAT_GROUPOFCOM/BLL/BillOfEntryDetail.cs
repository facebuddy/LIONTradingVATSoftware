using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class BillOfEntryDetail
    {
        private short rowNo;

        private string challanNo;

        private string challanDate;

        private long itemID;

        private string itemName;

        private int unitID;

        private string unitName;

        private double quantity;

        private bool isVDS;

        private bool isExempted;

        private bool isRebatable;

        private bool isZeroRate;

        private double vDSAmount;

        private double unitPrice;

        private double vAT;

        private double sD;

        private double cD;

        private double rD;

        private double aIT;

        private double aTV;

        private double tTI;

        private double aT;

        private double pSI;

        private double cNFVat;

        private double cNFCommission;

        private double vatablePrice;

        private double documentPF;

        private long detailID;

        private string productType;

        private double otherCost;

        private double assessValue;

        private bool isWar;

        private string isWarStr;

        private double totalPrice;

        private int userID;

        private DateTime updateDate;

        private long challanID;

        public double AIT
        {
            get
            {
                return this.aIT;
            }
            set
            {
                this.aIT = value;
            }
        }

        public double AssessValue
        {
            get
            {
                return this.assessValue;
            }
            set
            {
                this.assessValue = value;
            }
        }

        public double AT
        {
            get
            {
                return this.aT;
            }
            set
            {
                this.aT = value;
            }
        }

        public double ATV
        {
            get
            {
                return this.aTV;
            }
            set
            {
                this.aTV = value;
            }
        }

        public double CD
        {
            get
            {
                return this.cD;
            }
            set
            {
                this.cD = value;
            }
        }

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

        public string ChallanNo
        {
            get
            {
                return this.challanNo;
            }
            set
            {
                this.challanNo = value;
            }
        }

        public double CNFCommission
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

        public double CNFVat
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

        public double DocumentPF
        {
            get
            {
                return this.documentPF;
            }
            set
            {
                this.documentPF = value;
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
                return this.isZeroRate;
            }
            set
            {
                this.isZeroRate = value;
            }
        }

        public long ItemID
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

        public double OtherCost
        {
            get
            {
                return this.otherCost;
            }
            set
            {
                this.otherCost = value;
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

        public double RD
        {
            get
            {
                return this.rD;
            }
            set
            {
                this.rD = value;
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

        public double SD
        {
            get
            {
                return this.sD;
            }
            set
            {
                this.sD = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }
            set
            {
                this.totalPrice = value;
            }
        }

        public double TTI
        {
            get
            {
                return this.tTI;
            }
            set
            {
                this.tTI = value;
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

        public double UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
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

        public int UserID
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

        public double VAT
        {
            get
            {
                return this.vAT;
            }
            set
            {
                this.vAT = value;
            }
        }

        public double VatablePrice
        {
            get
            {
                return this.vatablePrice;
            }
            set
            {
                this.vatablePrice = value;
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

        public BillOfEntryDetail()
        {
        }
    }
}