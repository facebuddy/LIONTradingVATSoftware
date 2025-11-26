using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TransProductionMasterDAO
    {
        private int productionId;

        private int organizationId;

        private char materialType;

        private DateTime dateProduction;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        private string challanBatchNo;

        private short auditSeqNo;

        private short auditUserId;

        private DateTime auditDate;

        private DateTime productionYear;

        private int cgChallanBatchNo;

        private string discardReason;

        public DateTime AuditDate
        {
            get
            {
                return this.auditDate;
            }
            set
            {
                this.auditDate = value;
            }
        }

        public short AuditSeqNo
        {
            get
            {
                return this.auditSeqNo;
            }
            set
            {
                this.auditSeqNo = value;
            }
        }

        public short AuditUserId
        {
            get
            {
                return this.auditUserId;
            }
            set
            {
                this.auditUserId = value;
            }
        }

        public int CgChallanBatchNo
        {
            get
            {
                return this.cgChallanBatchNo;
            }
            set
            {
                this.cgChallanBatchNo = value;
            }
        }

        public string ChallanBatchNo
        {
            get
            {
                return this.challanBatchNo;
            }
            set
            {
                this.challanBatchNo = value;
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

        public string DiscardReason
        {
            get
            {
                return this.discardReason;
            }
            set
            {
                this.discardReason = value;
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

        public DateTime ProductionDate
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

        public int ProductionId
        {
            get
            {
                return this.productionId;
            }
            set
            {
                this.productionId = value;
            }
        }

        public DateTime ProductTionYear
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

        public TransProductionMasterDAO()
        {
        }
    }
}