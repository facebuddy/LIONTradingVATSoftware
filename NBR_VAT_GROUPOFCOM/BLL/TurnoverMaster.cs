using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TurnoverMaster
    {
        private int tmID;

        private string challanNo;

        private string challanDate;

        private string partyName;

        private string partyAddress;

        private string partyBin;

        private string listedPersonName;

        private string listedPersonBIN;

        private string challanIssueAddress;

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

        public string ChallanIssueAddress
        {
            get
            {
                return this.challanIssueAddress;
            }
            set
            {
                this.challanIssueAddress = value;
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

        public string ListedPersonBIN
        {
            get
            {
                return this.listedPersonBIN;
            }
            set
            {
                this.listedPersonBIN = value;
            }
        }

        public string ListedPersonName
        {
            get
            {
                return this.listedPersonName;
            }
            set
            {
                this.listedPersonName = value;
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

        public string PartyBin
        {
            get
            {
                return this.partyBin;
            }
            set
            {
                this.partyBin = value;
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

        public int TmID
        {
            get
            {
                return this.tmID;
            }
            set
            {
                this.tmID = value;
            }
        }

        public TurnoverMaster()
        {
        }
    }
}