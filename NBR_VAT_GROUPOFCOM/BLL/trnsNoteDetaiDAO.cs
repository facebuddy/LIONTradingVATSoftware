using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsNoteDetaiDAO
    {
        private short noteId;

        private short rowNo;

        private short challanId;

        private short itemId;

        private short propertyId1;

        private short propertyId2;

        private short propertyId3;

        private short propertyId4;

        private short propertyId5;

        private short unitId;

        private double quantity;

        private double actualPrice;

        private double rbtOtherTax;

        private double rbtVat;

        private double clnOtherTax;

        private double clnVat;

        private double difOtherTax;

        private double difVat;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        private short partyId;

        private string creditNoteNo;

        private DateTime startDate;

        private DateTime finishDate;

        private string orgName;

        private string orgAddress;

        private string orgBIN;

        private string orgTelephone;

        private string orgFax;

        public double ActualPrice
        {
            get
            {
                return this.actualPrice;
            }
            set
            {
                this.actualPrice = value;
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

        public double ClnOtherTax
        {
            get
            {
                return this.clnOtherTax;
            }
            set
            {
                this.clnOtherTax = value;
            }
        }

        public double ClnVat
        {
            get
            {
                return this.clnVat;
            }
            set
            {
                this.clnVat = value;
            }
        }

        public string CreditNoteNo
        {
            get
            {
                return this.creditNoteNo;
            }
            set
            {
                this.creditNoteNo = value;
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

        public double DifOtherTax
        {
            get
            {
                return this.difOtherTax;
            }
            set
            {
                this.difOtherTax = value;
            }
        }

        public double DifVat
        {
            get
            {
                return this.difVat;
            }
            set
            {
                this.difVat = value;
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

        public string OrgFax
        {
            get
            {
                return this.orgFax;
            }
            set
            {
                this.orgFax = value;
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

        public short PropertyId1
        {
            get
            {
                return this.propertyId1;
            }
            set
            {
                this.propertyId1 = value;
            }
        }

        public short PropertyId2
        {
            get
            {
                return this.propertyId2;
            }
            set
            {
                this.propertyId2 = value;
            }
        }

        public short PropertyId3
        {
            get
            {
                return this.propertyId3;
            }
            set
            {
                this.propertyId3 = value;
            }
        }

        public short PropertyId4
        {
            get
            {
                return this.propertyId4;
            }
            set
            {
                this.propertyId4 = value;
            }
        }

        public short PropertyId5
        {
            get
            {
                return this.propertyId5;
            }
            set
            {
                this.propertyId5 = value;
            }
        }

        public double Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public double RbtOtherTax
        {
            get
            {
                return this.rbtOtherTax;
            }
            set
            {
                this.rbtOtherTax = value;
            }
        }

        public double RbtVat
        {
            get
            {
                return this.rbtVat;
            }
            set
            {
                this.rbtVat = value;
            }
        }

        public short RowNo
        {
            get
            {
                return this.rowNo;
            }
            set
            {
                this.rowNo = value;
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

        public short UnitId
        {
            get
            {
                return this.unitId;
            }
            set
            {
                this.unitId = value;
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

        public trnsNoteDetaiDAO()
        {
        }
    }
}
