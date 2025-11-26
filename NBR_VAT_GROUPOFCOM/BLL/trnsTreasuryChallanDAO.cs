using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsTreasuryChallanDAO
    {
        private short challanId;

        private string challanNo;

        private DateTime dateChallan;

        private string strDate;

        private short branchId;

        private short bankId;

        private string codeNo;

        private string bearerNameAddress;

        private short organizationId;

        private string depositDescription;

        private string instrumentDescription;

        private double unitPrice;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        private string designation;

        private double unit;

        private double amount;

        private string instrumentType;

        private short challanTypem;

        private short challanTyped;

        private string orgAddress;

        private string orgName;

        private string bankName;

        private string branchName;

        private string challanType;

        private DateTime startDate;

        private DateTime finishDate;

        private List<string> challan_numbers;

        private List<string> scrollId;

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
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

        public string BankName
        {
            get
            {
                return this.bankName;
            }
            set
            {
                this.bankName = value;
            }
        }

        public string BearerNameAddress
        {
            get
            {
                return this.bearerNameAddress;
            }
            set
            {
                this.bearerNameAddress = value;
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

        public List<string> Challan_numbers
        {
            get
            {
                return this.challan_numbers;
            }
            set
            {
                this.challan_numbers = value;
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

        public short ChallanTyped
        {
            get
            {
                return this.challanTyped;
            }
            set
            {
                this.challanTyped = value;
            }
        }

        public short ChallanTypem
        {
            get
            {
                return this.challanTypem;
            }
            set
            {
                this.challanTypem = value;
            }
        }

        public string CodeNo
        {
            get
            {
                return this.codeNo;
            }
            set
            {
                this.codeNo = value;
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

        public string DepositDescription
        {
            get
            {
                return this.depositDescription;
            }
            set
            {
                this.depositDescription = value;
            }
        }

        public string Designation
        {
            get
            {
                return this.designation;
            }
            set
            {
                this.designation = value;
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

        public string InstrumentDescription
        {
            get
            {
                return this.instrumentDescription;
            }
            set
            {
                this.instrumentDescription = value;
            }
        }

        public string InstrumentType
        {
            get
            {
                return this.instrumentType;
            }
            set
            {
                this.instrumentType = value;
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

        public bool isPayment
        {
            get;
            set;
        }

        public bool isTR
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

        public short orgId
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

        public List<string> ScrollId
        {
            get
            {
                return this.scrollId;
            }
            set
            {
                this.scrollId = value;
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

        public string StrDate
        {
            get
            {
                return this.strDate;
            }
            set
            {
                this.strDate = value;
            }
        }

        public DateTime submisionDate
        {
            get;
            set;
        }

        public double Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
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

        public trnsTreasuryChallanDAO()
        {
        }
    }
}