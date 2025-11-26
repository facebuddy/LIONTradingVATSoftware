using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ProductTransferMaster
    {
        private string orgName;

        private string orgAddress;

        private string orgBIN;

        private string providerName;

        private string providerAddress;

        private string providerBIN;

        private string receipentName;

        private string receipentAddress;

        private string receipentBIN;

        private string challanNo;

        private DateTime issueDate;

        private string issueTime;

        private string newBranchName;

        private string newBranchAddress;

        private string newBranchBIN;

        private short providerBranchID;

        private short receipentBranchID;

        private short organizationID;

        private short userID;

        private char materialType;

        private char transferStatus;

        private short auditID;

        private int partyID;

        private bool isNewParty;

        private long transferID;

        private short transferYear;

        private short challanBookId;

        private short challanPageNo;

        private string receiveScrollNo;

        private string date;

        private string time;

        private int shVehicleTypeM;

        private int shVehicleTypeD;

        private string strVehicleNo;

        private string strVehicleName;

        public short AuditID
        {
            get
            {
                return this.auditID;
            }
            set
            {
                this.auditID = value;
            }
        }

        public short ChallanBookId
        {
            get
            {
                return this.challanBookId;
            }
            set
            {
                this.challanBookId = value;
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

        public short ChallanPageNo
        {
            get
            {
                return this.challanPageNo;
            }
            set
            {
                this.challanPageNo = value;
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public bool IsNewParty
        {
            get
            {
                return this.isNewParty;
            }
            set
            {
                this.isNewParty = value;
            }
        }

        public DateTime IssueDate
        {
            get
            {
                return this.issueDate;
            }
            set
            {
                this.issueDate = value;
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

        public string NewBranchAddress
        {
            get
            {
                return this.newBranchAddress;
            }
            set
            {
                this.newBranchAddress = value;
            }
        }

        public string NewBranchBIN
        {
            get
            {
                return this.newBranchBIN;
            }
            set
            {
                this.newBranchBIN = value;
            }
        }

        public string NewBranchName
        {
            get
            {
                return this.newBranchName;
            }
            set
            {
                this.newBranchName = value;
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

        public int PartyID
        {
            get
            {
                return this.partyID;
            }
            set
            {
                this.partyID = value;
            }
        }

        public string ProviderAddress
        {
            get
            {
                return this.providerAddress;
            }
            set
            {
                this.providerAddress = value;
            }
        }

        public string ProviderBIN
        {
            get
            {
                return this.providerBIN;
            }
            set
            {
                this.providerBIN = value;
            }
        }

        public short ProviderBranchID
        {
            get
            {
                return this.providerBranchID;
            }
            set
            {
                this.providerBranchID = value;
            }
        }

        public string ProviderName
        {
            get
            {
                return this.providerName;
            }
            set
            {
                this.providerName = value;
            }
        }

        public string ReceipentAddress
        {
            get
            {
                return this.receipentAddress;
            }
            set
            {
                this.receipentAddress = value;
            }
        }

        public string ReceipentBIN
        {
            get
            {
                return this.receipentBIN;
            }
            set
            {
                this.receipentBIN = value;
            }
        }

        public short ReceipentBranchID
        {
            get
            {
                return this.receipentBranchID;
            }
            set
            {
                this.receipentBranchID = value;
            }
        }

        public string ReceipentName
        {
            get
            {
                return this.receipentName;
            }
            set
            {
                this.receipentName = value;
            }
        }

        public string ReceiveScrollNo
        {
            get
            {
                return this.receiveScrollNo;
            }
            set
            {
                this.receiveScrollNo = value;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public long TransferID
        {
            get
            {
                return this.transferID;
            }
            set
            {
                this.transferID = value;
            }
        }

        public char TransferStatus
        {
            get
            {
                return this.transferStatus;
            }
            set
            {
                this.transferStatus = value;
            }
        }

        public short TransferYear
        {
            get
            {
                return this.transferYear;
            }
            set
            {
                this.transferYear = value;
            }
        }

        public short UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public string VehicleNo
        {
            get
            {
                return this.strVehicleNo;
            }
            set
            {
                this.strVehicleNo = value;
            }
        }

        public int VehicleTypeD
        {
            get
            {
                return this.shVehicleTypeD;
            }
            set
            {
                this.shVehicleTypeD = value;
            }
        }

        public int VehicleTypeM
        {
            get
            {
                return this.shVehicleTypeM;
            }
            set
            {
                this.shVehicleTypeM = value;
            }
        }

        public string VehicleTypeName
        {
            get
            {
                return this.strVehicleName;
            }
            set
            {
                this.strVehicleName = value;
            }
        }

        public ProductTransferMaster()
        {
        }
    }
}