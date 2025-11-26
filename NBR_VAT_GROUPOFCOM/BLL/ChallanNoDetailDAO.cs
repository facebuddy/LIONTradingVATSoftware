using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{


    public class ChallanNoDetailDAO
    {
        private int intChallanBookID;

        private int intPageNo;

        private string strChallanNo;

        private bool blIsUsed;

        private short intChallanType;

        private int branchID;

        public int BranchID
        {
            get
            {
                return this.branchID;
            }
            set
            {
                this.branchID = value;
            }
        }

        public int ChallanBookID
        {
            get
            {
                return this.intChallanBookID;
            }
            set
            {
                this.intChallanBookID = value;
            }
        }

        public string ChallanNo
        {
            get
            {
                return this.strChallanNo;
            }
            set
            {
                this.strChallanNo = value;
            }
        }

        public short ChallanType
        {
            get
            {
                return this.intChallanType;
            }
            set
            {
                this.intChallanType = value;
            }
        }

        public bool IsUsed
        {
            get
            {
                return this.blIsUsed;
            }
            set
            {
                this.blIsUsed = value;
            }
        }

        public int PageNo
        {
            get
            {
                return this.intPageNo;
            }
            set
            {
                this.intPageNo = value;
            }
        }

        public ChallanNoDetailDAO()
        {
        }
    }
}