using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class DebitNoteMasterDAO
    {
        private int noteId;

        private string recipientName;

        private string recipientAddress;

        private string recipientBin;

        private string recipientDate;

        private string recipientTime;

        private string providerName;

        private string providerAddress;

        private string providerBin;

        private string providerDate;

        private string providerTime;

        private string creditNotNumber;

        private string discardReasion;

        private string mainChallanNo;

        private string type;

        private string decreaseType;

        private short orgId;

        private char noteType;

        private short userId;

        private short partyId;

        private int noteYear;

        private string vehicalType;

        private DateTime dateNote;

        private short challanBookId;

        private short challanPageNumber;

        private int branchID;

        private long challan_id;

        private string materialType;

        private string itemType;

        private DateTime challanDate;

        private short userID;

        private bool is_other_adj;

        private int shVehicleTypeM;

        private int shVehicleTypeD;

        private string strVehicleNo;

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

        public long Challan_id
        {
            get
            {
                return this.challan_id;
            }
            set
            {
                this.challan_id = value;
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

        public short ChallanPageNumber
        {
            get
            {
                return this.challanPageNumber;
            }
            set
            {
                this.challanPageNumber = value;
            }
        }

        public string CreditNotNumber
        {
            get
            {
                return this.creditNotNumber;
            }
            set
            {
                this.creditNotNumber = value;
            }
        }

        public DateTime DateNote
        {
            get
            {
                return this.dateNote;
            }
            set
            {
                this.dateNote = value;
            }
        }

        public string DecreaseType
        {
            get
            {
                return this.decreaseType;
            }
            set
            {
                this.decreaseType = value;
            }
        }

        public string DiscardReasion
        {
            get
            {
                return this.discardReasion;
            }
            set
            {
                this.discardReasion = value;
            }
        }

        public bool IsOtherAdj
        {
            get
            {
                return this.is_other_adj;
            }
            set
            {
                this.is_other_adj = value;
            }
        }

        public string ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }

        public string MainChallanNo
        {
            get
            {
                return this.mainChallanNo;
            }
            set
            {
                this.mainChallanNo = value;
            }
        }

        public string MaterialType
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

        public int NoteId
        {
            get
            {
                return this.noteId;
            }
            set
            {
                this.noteId = value;
            }
        }

        public char NoteType
        {
            get
            {
                return this.noteType;
            }
            set
            {
                this.noteType = value;
            }
        }

        public int NoteYear
        {
            get
            {
                return this.noteYear;
            }
            set
            {
                this.noteYear = value;
            }
        }

        public short OrgId
        {
            get
            {
                return this.orgId;
            }
            set
            {
                this.orgId = value;
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

        public string ProviderBin
        {
            get
            {
                return this.providerBin;
            }
            set
            {
                this.providerBin = value;
            }
        }

        public string ProviderDate
        {
            get
            {
                return this.providerDate;
            }
            set
            {
                this.providerDate = value;
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

        public string ProviderTime
        {
            get
            {
                return this.providerTime;
            }
            set
            {
                this.providerTime = value;
            }
        }

        public string RecipientAddress
        {
            get
            {
                return this.recipientAddress;
            }
            set
            {
                this.recipientAddress = value;
            }
        }

        public string RecipientBin
        {
            get
            {
                return this.recipientBin;
            }
            set
            {
                this.recipientBin = value;
            }
        }

        public string RecipientDate
        {
            get
            {
                return this.recipientDate;
            }
            set
            {
                this.recipientDate = value;
            }
        }

        public string RecipientName
        {
            get
            {
                return this.recipientName;
            }
            set
            {
                this.recipientName = value;
            }
        }

        public string RecipientTime
        {
            get
            {
                return this.recipientTime;
            }
            set
            {
                this.recipientTime = value;
            }
        }

        public DateTime submisionDate
        {
            get;
            set;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public short UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
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

        public string VehicalType
        {
            get
            {
                return this.vehicalType;
            }
            set
            {
                this.vehicalType = value;
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

        public DebitNoteMasterDAO()
        {
        }
    }
}