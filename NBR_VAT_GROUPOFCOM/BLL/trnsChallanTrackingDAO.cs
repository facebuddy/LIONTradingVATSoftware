using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsChallanTrackingDAO
    {
        private short challanId;

        private short partyId;

        private decimal trAmount;

        private bool isVat;

        private bool isSd;

        private string challanNo;

        public short ChallanId
        {
            get
            {
                return this.challanId;
            }
            set
            {
                this.challanId = value;
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

        public bool IsSd
        {
            get
            {
                return this.isSd;
            }
            set
            {
                this.isSd = value;
            }
        }

        public bool IsVat
        {
            get
            {
                return this.isVat;
            }
            set
            {
                this.isVat = value;
            }
        }

        public short PartyId
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

        public decimal TrAmount
        {
            get
            {
                return this.trAmount;
            }
            set
            {
                this.trAmount = value;
            }
        }

        public trnsChallanTrackingDAO()
        {
        }
    }
}