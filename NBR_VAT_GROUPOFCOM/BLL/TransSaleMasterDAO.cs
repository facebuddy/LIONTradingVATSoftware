using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class TransSaleMasterDAO
    {
        private int challanId;

        private int organizationId;

        private string challanNo;

        private int cgchallanNo;

        private DateTime challanyear;

        private char challanType;

        private DateTime challanDate;

        private short userIdInsert;

        public int CgChallanNo
        {
            get
            {
                return this.cgchallanNo;
            }
            set
            {
                this.cgchallanNo = value;
            }
        }

        public DateTime ChallanDate
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

        public int ChallanID
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

        public char ChallanType
        {
            get
            {
                return this.challanType;
            }
            set
            {
                this.challanType = value;
            }
        }

        public DateTime ChallanYear
        {
            get
            {
                return this.challanyear;
            }
            set
            {
                this.challanyear = value;
            }
        }

        public int OrganizationId
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

        public TransSaleMasterDAO()
        {
        }
    }
}

