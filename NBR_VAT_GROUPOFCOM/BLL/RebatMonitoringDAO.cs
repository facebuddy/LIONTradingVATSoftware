using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class RebatMonitoringDAO
    {
        private long rowID;

        private string challanNo;

        private string challanDate;

        private double totalAmount;

        private double amount;

        private double vat;

        private double sD;

        private double aIT;

        private double aTV;

        private double cD;

        private double rD;

        private double tTI;

        private string isRebatable;

        private string partyName;

        private int partyId;

        private string isVDS;

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

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
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

        public string IsRebatable
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

        public string IsVDS
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

        public int PartyId
        {
            get
            {
                return this.partyId;
            }
            set
            {
                this.partyId = value;
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

        public long RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
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

        public double TotalAmount
        {
            get
            {
                return this.totalAmount;
            }
            set
            {
                this.totalAmount = value;
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

        public double Vat
        {
            get
            {
                return this.vat;
            }
            set
            {
                this.vat = value;
            }
        }

        public RebatMonitoringDAO()
        {
        }
    }
}