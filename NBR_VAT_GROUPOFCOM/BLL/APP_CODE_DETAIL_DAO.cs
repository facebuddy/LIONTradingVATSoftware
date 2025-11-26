using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class APP_CODE_DETAIL_DAO
    {
        private int intCodeIDm;

        private int intCodeIDd;

        private string strCodeName = string.Empty;

        private string strCodeShortName;

        private DateTime dtCodeDate;

        private DateTime dtCodeDate2nd;

        private double intCodeValue1st;

        private double intCodeValue2nd;

        private string strCodeString1st;

        private string strCodeString2nd;

        private short intIsDeleted;

        private short mCodeType;

        public DateTime CodeDate1st
        {
            get
            {
                return this.dtCodeDate;
            }
            set
            {
                this.dtCodeDate = value;
            }
        }

        public DateTime CodeDate2nd
        {
            get
            {
                return this.dtCodeDate2nd;
            }
            set
            {
                this.dtCodeDate2nd = value;
            }
        }

        public int CodeIDD
        {
            get
            {
                return this.intCodeIDd;
            }
            set
            {
                this.intCodeIDd = value;
            }
        }

        public int CodeIDM
        {
            get
            {
                return this.intCodeIDm;
            }
            set
            {
                this.intCodeIDm = value;
            }
        }

        public string CodeName
        {
            get
            {
                return this.strCodeName;
            }
            set
            {
                this.strCodeName = value;
            }
        }

        public string CodeShortName
        {
            get
            {
                return this.strCodeShortName;
            }
            set
            {
                this.strCodeShortName = value;
            }
        }

        public string CodeString1st
        {
            get
            {
                return this.strCodeString1st;
            }
            set
            {
                this.strCodeString1st = value;
            }
        }

        public string CodeString2nd
        {
            get
            {
                return this.strCodeString2nd;
            }
            set
            {
                this.strCodeString2nd = value;
            }
        }

        public double CodeValue1st
        {
            get
            {
                return this.intCodeValue1st;
            }
            set
            {
                this.intCodeValue1st = value;
            }
        }

        public double CodeValue2nd
        {
            get
            {
                return this.intCodeValue2nd;
            }
            set
            {
                this.intCodeValue2nd = value;
            }
        }

        public short IsDeleted
        {
            get
            {
                return this.intIsDeleted;
            }
            set
            {
                this.intIsDeleted = value;
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

        public APP_CODE_DETAIL_DAO()
        {
        }
    }
}