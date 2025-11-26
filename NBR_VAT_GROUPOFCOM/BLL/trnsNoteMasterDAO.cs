using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsNoteMasterDAO
    {
        private short noteId;

        private int intChallanBookID;

        private int intChallanPageNo;

        private short organizationId;

        private string noteType = "D";

        private DateTime dateNote;

        private short noteYear;

        private string noteNo;

        private short cgNoteNo;

        private short partyId;

        private short vehicleTypem;

        private short vehicleTyped;

        private string vehicleNo;

        private string reason;

        private short auditSeqNo;

        private short auditUserId;

        private DateTime auditDate;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        private int intChallanPageDiscardReason_m;

        private int intChallanPageDiscardReason_d;

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

        public short CgNoteNo
        {
            get
            {
                return this.cgNoteNo;
            }
            set
            {
                this.cgNoteNo = value;
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

        public int ChallanPageDiscardReason_d
        {
            get
            {
                return this.intChallanPageDiscardReason_d;
            }
            set
            {
                this.intChallanPageDiscardReason_d = value;
            }
        }

        public int ChallanPageDiscardReason_m
        {
            get
            {
                return this.intChallanPageDiscardReason_m;
            }
            set
            {
                this.intChallanPageDiscardReason_m = value;
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

        public short NoteId
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

        public string NoteNo
        {
            get
            {
                return this.noteNo;
            }
            set
            {
                this.noteNo = value;
            }
        }

        public string NoteType
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

        public short NoteYear
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

        public string Reason
        {
            get
            {
                return this.reason;
            }
            set
            {
                this.reason = value;
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

        public short VehicleTyped
        {
            get
            {
                return this.vehicleTyped;
            }
            set
            {
                this.vehicleTyped = value;
            }
        }

        public short VehicleTypem
        {
            get
            {
                return this.vehicleTypem;
            }
            set
            {
                this.vehicleTypem = value;
            }
        }

        public trnsNoteMasterDAO()
        {
        }
    }
}