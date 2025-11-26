using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.Model
{
    public class RawMaterialIssueMasterForSelfProductionDAO
    {
        private short organizationID;

        private int branchID;

        private string branchName;

        private string requisitionNO;

        private string requisitionDate;

        private long finishProductID;

        private string finishProduct;

        private short productionYear;

        private DateTime dateProduction;

        private char materialType;

        private short audit_user_id;

        private short user_id_insert;

        private char status;

        private int production_id;

        private string requisitorName;

        private string orgName;

        private string orgAddress;

        private string orgBIN;

        private string requisitionTime;

        private string branchBIN;

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

        public string RequisitionDate
        {
            get
            {
                return this.requisitionDate;
            }
            set
            {
                this.requisitionDate = value;
            }
        }

        public string RequisitionNO
        {
            get
            {
                return this.requisitionNO;
            }
            set
            {
                this.requisitionNO = value;
            }
        }

        public string RequisitionTime
        {
            get
            {
                return this.requisitionTime;
            }
            set
            {
                this.requisitionTime = value;
            }
        }

        public string RequisitorName
        {
            get
            {
                return this.requisitorName;
            }
            set
            {
                this.requisitorName = value;
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

        public RawMaterialIssueMasterForSelfProductionDAO()
        {
        }
    
    }
}