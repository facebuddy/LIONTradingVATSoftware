using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ChallanNoMasterDAO
    {
        private int intChallanBookID;

        private string strChallanBookNo;

        private int intPageFrom;

        private int intPageTo;

        private short intChallanType;

        private short intChallanYear;

        private short intOrganizationID;

        private short intUserIdInsert;

        private short branchID;

        private bool isApplicableAllBrnch;

        public short BranchID
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

        public string ChallanBookNo
        {
            get
            {
                return this.strChallanBookNo;
            }
            set
            {
                this.strChallanBookNo = value;
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

        public short ChallanYear
        {
            get
            {
                return this.intChallanYear;
            }
            set
            {
                this.intChallanYear = value;
            }
        }

        public short currentChallanYear
        {
            get;
            set;
        }

        public bool IsApplicableAllBrnch
        {
            get
            {
                return this.isApplicableAllBrnch;
            }
            set
            {
                this.isApplicableAllBrnch = value;
            }
        }

        public short OrganizationID
        {
            get
            {
                return this.intOrganizationID;
            }
            set
            {
                this.intOrganizationID = value;
            }
        }

        public int PageFrom
        {
            get
            {
                return this.intPageFrom;
            }
            set
            {
                this.intPageFrom = value;
            }
        }

        public int PageTo
        {
            get
            {
                return this.intPageTo;
            }
            set
            {
                this.intPageTo = value;
            }
        }

        public short UserIdInsert
        {
            get
            {
                return this.intUserIdInsert;
            }
            set
            {
                this.intUserIdInsert = value;
            }
        }

        public ChallanNoMasterDAO()
        {
        }
    }
}