using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsBandrollRcvMaster
    {
        private short challanId;

        private short organizationId;

        private DateTime dateReceive;

        private string receiveChallanNo;

        private short treasuryChallanId;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

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

        public DateTime DateInsert
        {
            get
            {
                return this.dateInsert;
            }
            set
            {
                this.dateInsert = value;
            }
        }

        public DateTime DateReceive
        {
            get
            {
                return this.dateReceive;
            }
            set
            {
                this.dateReceive = value;
            }
        }

        public DateTime DateUpdate
        {
            get
            {
                return this.dateUpdate;
            }
            set
            {
                this.dateUpdate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this.isDeleted;
            }
            set
            {
                this.isDeleted = value;
            }
        }

        public short OrganizationId
        {
            get
            {
                return this.organizationId;
            }
            set
            {
                this.organizationId = value;
            }
        }

        public string ReceiveChallanNo
        {
            get
            {
                return this.receiveChallanNo;
            }
            set
            {
                this.receiveChallanNo = value;
            }
        }

        public short TreasuryChallanId
        {
            get
            {
                return this.treasuryChallanId;
            }
            set
            {
                this.treasuryChallanId = value;
            }
        }

        public short UserIdInsert
        {
            get
            {
                return this.userIdInsert;
            }
            set
            {
                this.userIdInsert = value;
            }
        }

        public short UserIdUpdate
        {
            get
            {
                return this.userIdUpdate;
            }
            set
            {
                this.userIdUpdate = value;
            }
        }

        public trnsBandrollRcvMaster()
        {
        }
    }
}