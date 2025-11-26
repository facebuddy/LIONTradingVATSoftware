using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class ContructualProductionIssueMasterDAO
    {
        private int production_id;

        private short organization_id;

        private string challan_batch_no;

        private short cg_challan_batch_no;

        private short production_year;

        private char material_type;

        private short audit_seq_no;

        private short audit_user_id;

        private DateTime audit_date;

        private string remarks;

        private bool is_deleted;

        private DateTime date_insert;

        private DateTime date_update;

        private short user_id_insert;

        private short user_id_update;

        private bool isNewParty;

        private string partyName;

        private string partyAddress;

        private string partyBIN;

        private int party_id;

        private short discard_reason;

        private int challanBookId;

        private int challanPageNo;

        private DateTime date_production;

        private string orgName;

        private string orgBIN;

        private string challanIssueAddress;

        private string challanNo;

        private DateTime issueDate;

        private string issueTime;

        private char status;

        private string scrollNo;

        private long finishProductID;

        private int branchID;

        private int challanID;

        private char purchaseType;

        private string batch_no;

        private DateTime mfgDate;

        private DateTime expiryDate;

        public DateTime Audit_date
        {
            get
            {
                return this.audit_date;
            }
            set
            {
                this.audit_date = value;
            }
        }

        public short Audit_seq_no
        {
            get
            {
                return this.audit_seq_no;
            }
            set
            {
                this.audit_seq_no = value;
            }
        }

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

        public string Batch_no
        {
            get
            {
                return this.batch_no;
            }
            set
            {
                this.batch_no = value;
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

        public short Cg_challan_batch_no
        {
            get
            {
                return this.cg_challan_batch_no;
            }
            set
            {
                this.cg_challan_batch_no = value;
            }
        }

        public string Challan_batch_no
        {
            get
            {
                return this.challan_batch_no;
            }
            set
            {
                this.challan_batch_no = value;
            }
        }

        public int ChallanBookId
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

        public string ChallanIssueAddress
        {
            get
            {
                return this.challanIssueAddress;
            }
            set
            {
                this.challanIssueAddress = value;
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
                return this.challanPageNo;
            }
            set
            {
                this.challanPageNo = value;
            }
        }

        public DateTime Date_insert
        {
            get
            {
                return this.date_insert;
            }
            set
            {
                this.date_insert = value;
            }
        }

        public DateTime Date_production
        {
            get
            {
                return this.date_production;
            }
            set
            {
                this.date_production = value;
            }
        }

        public DateTime Date_update
        {
            get
            {
                return this.date_update;
            }
            set
            {
                this.date_update = value;
            }
        }

        public string DeliveryDate
        {
            get;
            set;
        }

        public string DeliveryTime
        {
            get;
            set;
        }

        public short Discard_reason
        {
            get
            {
                return this.discard_reason;
            }
            set
            {
                this.discard_reason = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return this.expiryDate;
            }
            set
            {
                this.expiryDate = value;
            }
        }

        public string FinishProduct
        {
            get;
            set;
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

        public bool Is_deleted
        {
            get
            {
                return this.is_deleted;
            }
            set
            {
                this.is_deleted = value;
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

        public char Material_type
        {
            get
            {
                return this.material_type;
            }
            set
            {
                this.material_type = value;
            }
        }

        public DateTime MfgDate
        {
            get
            {
                return this.mfgDate;
            }
            set
            {
                this.mfgDate = value;
            }
        }

        public string OrgAddress
        {
            get;
            set;
        }

        public short Organization_id
        {
            get
            {
                return this.organization_id;
            }
            set
            {
                this.organization_id = value;
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

        public int Party_id
        {
            get
            {
                return this.party_id;
            }
            set
            {
                this.party_id = value;
            }
        }

        public string PartyAddress
        {
            get
            {
                return this.partyAddress;
            }
            set
            {
                this.partyAddress = value;
            }
        }

        public string PartyBIN
        {
            get
            {
                return this.partyBIN;
            }
            set
            {
                this.partyBIN = value;
            }
        }

        public string PartyName
        {
            get
            {
                return this.partyName;
            }
            set
            {
                this.partyName = value;
            }
        }

        public int PorvidedChallanNo
        {
            get;
            set;
        }

        public int price_id
        {
            get
            {
                return this.PriceDecNo;
            }
            set
            {
                this.PriceDecNo = value;
            }
        }

        public int PriceDecNo
        {
            get;
            set;
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

        public decimal Production_Quantity
        {
            get;
            set;
        }

        public decimal Production_Sale_Unit_Price
        {
            get;
            set;
        }

        public int Production_Unit
        {
            get;
            set;
        }

        public short Production_year
        {
            get
            {
                return this.production_year;
            }
            set
            {
                this.production_year = value;
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

        public int quantity
        {
            get;
            set;
        }

        public int Quantity
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

        public string ScrollNo
        {
            get
            {
                return this.scrollNo;
            }
            set
            {
                this.scrollNo = value;
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

        public short User_id_update
        {
            get
            {
                return this.user_id_update;
            }
            set
            {
                this.user_id_update = value;
            }
        }

        public string VehicleNo
        {
            get;
            set;
        }

        public string VehicleType
        {
            get;
            set;
        }

        public ContructualProductionIssueMasterDAO()
        {
        }
    }
}

