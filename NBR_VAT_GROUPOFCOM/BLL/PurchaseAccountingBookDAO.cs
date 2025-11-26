using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class PurchaseAccountingBookDAO
    {
        private short serialNo;

        private string date;

        private double previousAmount;

        private string challanNo;

        private string importDate;

        private string salerName;

        private string salerBIN;

        private int quantity;

        private double totalAmount;

        private double usedAmount;

        private double endAmount;

        private string remark;

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

        public double EndAmount
        {
            get
            {
                return this.endAmount;
            }
            set
            {
                this.endAmount = value;
            }
        }

        public string ImportDate
        {
            get
            {
                return this.importDate;
            }
            set
            {
                this.importDate = value;
            }
        }

        public double PreviousAmount
        {
            get
            {
                return this.previousAmount;
            }
            set
            {
                this.previousAmount = value;
            }
        }

        public int Quantity
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

        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
            }
        }

        public string SalerBIN
        {
            get
            {
                return this.salerBIN;
            }
            set
            {
                this.salerBIN = value;
            }
        }

        public string SalerName
        {
            get
            {
                return this.salerName;
            }
            set
            {
                this.salerName = value;
            }
        }

        public short SerialNo
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

        public double UsedAmount
        {
            get
            {
                return this.usedAmount;
            }
            set
            {
                this.usedAmount = value;
            }
        }

        public PurchaseAccountingBookDAO()
        {
        }
    }
}

