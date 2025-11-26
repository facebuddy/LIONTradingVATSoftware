using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsSaleMasterDAO
    {
        private short challanId;

        private short organizationId;

        private string challanNo;

        private short cgChallanNo;

        private int challanYear;

        private string challanType = "D";

        private string saleType = "W";

        private string transType = "L";

        private DateTime dateChallan;

        private DateTime dateGoodsDelivery;

        private short partyId;

        private string ultimateDestination;

        private short vehicleTypeM;

        private short vehicleTypeD;

        private string vehicleNo;

        private short auditSeqNo;

        private short auditUserId;

        private DateTime auditDate;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        private DateTime dateExport;

        private string exportBillNo;

        private short bankId;

        private short branchId;

        private string remarks;

        private DateTime startDate;

        private DateTime finishDate;

        private string orgName;

        private string orgAddress;

        private string orgBIN;

        private string orgAreaCode;

        private string orgTelephone;

        private string orgBusinessActivity;

        private short itemId;

        private int intChallanBookID;

        private int intChallanPageNo;

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

        public short BankId
        {
            get
            {
                return this.bankId;
            }
            set
            {
                this.bankId = value;
            }
        }

        public short BranchId
        {
            get
            {
                return this.branchId;
            }
            set
            {
                this.branchId = value;
            }
        }

        public short CgChallanNo
        {
            get
            {
                return this.cgChallanNo;
            }
            set
            {
                this.cgChallanNo = value;
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

        public int ChallanPageNo
        {
            get
            {
                return this.intChallanPageNo;
            }
            set
            {
                this.intChallanPageNo = value;
            }
        }

        public string ChallanType
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

        public int ChallanYear
        {
            get
            {
                return this.challanYear;
            }
            set
            {
                this.challanYear = value;
            }
        }

        public DateTime DateChallan
        {
            get
            {
                return this.dateChallan;
            }
            set
            {
                this.dateChallan = value;
            }
        }

        public DateTime DateExport
        {
            get
            {
                return this.dateExport;
            }
            set
            {
                this.dateExport = value;
            }
        }

        public DateTime DateGoodsDelivery
        {
            get
            {
                return this.dateGoodsDelivery;
            }
            set
            {
                this.dateGoodsDelivery = value;
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

        public short DisposeIDD
        {
            get;
            set;
        }

        public short DisposeIDM
        {
            get;
            set;
        }

        public string ExportBillNo
        {
            get
            {
                return this.exportBillNo;
            }
            set
            {
                this.exportBillNo = value;
            }
        }

        public DateTime FinishDate
        {
            get
            {
                return this.finishDate;
            }
            set
            {
                this.finishDate = value;
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

        public short ItemId
        {
            get
            {
                return this.itemId;
            }
            set
            {
                this.itemId = value;
            }
        }

        public int MNo
        {
            get;
            set;
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

        public string OrgAreaCode
        {
            get
            {
                return this.orgAreaCode;
            }
            set
            {
                this.orgAreaCode = value;
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

        public string OrgBusinessActivity
        {
            get
            {
                return this.orgBusinessActivity;
            }
            set
            {
                this.orgBusinessActivity = value;
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

        public string OrgTelephone
        {
            get
            {
                return this.orgTelephone;
            }
            set
            {
                this.orgTelephone = value;
            }
        }

        public short PartyId
        {
            get
            {
                return this.partyId;
            }
            set
            {
                this.partyId = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this.remarks;
            }
            set
            {
                this.remarks = value;
            }
        }

        public string SaleType
        {
            get
            {
                return this.saleType;
            }
            set
            {
                this.saleType = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }

        public string TransType
        {
            get
            {
                return this.transType;
            }
            set
            {
                this.transType = value;
            }
        }

        public string UltimateDestination
        {
            get
            {
                return this.ultimateDestination;
            }
            set
            {
                this.ultimateDestination = value;
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

        public string VehicleNo
        {
            get
            {
                return this.vehicleNo;
            }
            set
            {
                this.vehicleNo = value;
            }
        }

        public short VehicleTypeD
        {
            get
            {
                return this.vehicleTypeD;
            }
            set
            {
                this.vehicleTypeD = value;
            }
        }

        public short VehicleTypeM
        {
            get
            {
                return this.vehicleTypeM;
            }
            set
            {
                this.vehicleTypeM = value;
            }
        }

        public trnsSaleMasterDAO()
        {
        }
    }
}