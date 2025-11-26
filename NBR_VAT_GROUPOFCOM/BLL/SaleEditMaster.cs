using System;



namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SaleEditMaster
    {
        private bool isNewParty;

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

        private short vehicleIDD;

        private short vehicleIDM;

        private string vehecalNo;

        private short userID;

        private DateTime updateDate;

        private DateTime dateChallan;

        private long challanID;

        private string remarks;

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

        public DateTime DateChallan
        {
            get
            {
                return this.dateChallan;
            }
            set
            {
                this.dateChallan = value;
            }
        }

        public bool IsNewParty
        {
            get
            {
                return this.isNewParty;
            }
            set
            {
                this.isNewParty = value;
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

        public string Remarks
        {
            get
            {
                return this.remarks;
            }
            set
            {
                this.remarks = value;
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

        public short VehicleIDD
        {
            get
            {
                return this.vehicleIDD;
            }
            set
            {
                this.vehicleIDD = value;
            }
        }

        public short VehicleIDM
        {
            get
            {
                return this.vehicleIDM;
            }
            set
            {
                this.vehicleIDM = value;
            }
        }

        public SaleEditMaster()
        {
        }
    }
}
