using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class APP_CODE_MASTER_DAO
    {
        private int mCodeID;

        private string mCodeDescription;

        private string mCodeName;

        private short mCodeType;

        private short isDeleted;

        public short IsDeleted
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

        public string MCodeDescription
        {
            get
            {
                return this.mCodeDescription;
            }
            set
            {
                this.mCodeDescription = value;
            }
        }

        public int MCodeID
        {
            get
            {
                return this.mCodeID;
            }
            set
            {
                this.mCodeID = value;
            }
        }

        public string MCodeName
        {
            get
            {
                return this.mCodeName;
            }
            set
            {
                this.mCodeName = value;
            }
        }

        public short MCodeType
        {
            get
            {
                return this.mCodeType;
            }
            set
            {
                this.mCodeType = value;
            }
        }

        public APP_CODE_MASTER_DAO()
        {
        }
    }
}


