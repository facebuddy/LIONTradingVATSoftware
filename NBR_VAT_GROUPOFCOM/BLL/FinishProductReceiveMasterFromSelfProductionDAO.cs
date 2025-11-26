using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class FinishProductReceiveMasterFromSelfProductionDAO
    {
        private short organizationID;

        private int branchID;

        private string branchName;

        private string challanNO;

        private DateTime challanDate;

        private long finishProductID;

        private string finishProduct;

        private short productionYear;

        private DateTime dateProduction;

        private char materialType;

        private short audit_user_id;

        private short user_id_insert;

        private char status;

        private int production_id;

        private string scrollNO;

        private char purchaseType;

        private int challanID;

        private string orgName;

        private string orgBIN;

        private string orgAddress;

        private string branchBIN;

        private string issueTime;

        public short Audit_user_id
        {
            get
            {
                return this.audit_user_id;
            }
            set
            {
                this.audit_user_id = value;
            }
        }

        public string BranchBIN
        {
            get
            {
                return this.branchBIN;
            }
            set
            {
                this.branchBIN = value;
            }
        }

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

        public string BranchName
        {
            get
            {
                return this.branchName;
            }
            set
            {
                this.branchName = value;
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

        public DateTime DateProduction
        {
            get
            {
                return this.dateProduction;
            }
            set
            {
                this.dateProduction = value;
            }
        }

        public string FinishProduct
        {
            get
            {
                return this.finishProduct;
            }
            set
            {
                this.finishProduct = value;
            }
        }

        public long FinishProductID
        {
            get
            {
                return this.finishProductID;
            }
            set
            {
                this.finishProductID = value;
            }
        }

        public string IssueTime
        {
            get
            {
                return this.issueTime;
            }
            set
            {
                this.issueTime = value;
            }
        }

        public char MaterialType
        {
            get
            {
                return this.materialType;
            }
            set
            {
                this.materialType = value;
            }
        }

        public string OrgAddress
        {
            get
            {
                return this.orgAddress;
            }
            set
            {
                this.orgAddress = value;
            }
        }

        public short OrganizationID
        {
            get
            {
                return this.organizationID;
            }
            set
            {
                this.organizationID = value;
            }
        }

        public string OrgBIN
        {
            get
            {
                return this.orgBIN;
            }
            set
            {
                this.orgBIN = value;
            }
        }

        public string OrgName
        {
            get
            {
                return this.orgName;
            }
            set
            {
                this.orgName = value;
            }
        }

        public int Production_id
        {
            get
            {
                return this.production_id;
            }
            set
            {
                this.production_id = value;
            }
        }

        public short ProductionYear
        {
            get
            {
                return this.productionYear;
            }
            set
            {
                this.productionYear = value;
            }
        }

        public char PurchaseType
        {
            get
            {
                return this.purchaseType;
            }
            set
            {
                this.purchaseType = value;
            }
        }

        public string ScrollNO
        {
            get
            {
                return this.scrollNO;
            }
            set
            {
                this.scrollNO = value;
            }
        }

        public char Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public short User_id_insert
        {
            get
            {
                return this.user_id_insert;
            }
            set
            {
                this.user_id_insert = value;
            }
        }

        public FinishProductReceiveMasterFromSelfProductionDAO()
        {
        }
    }
}