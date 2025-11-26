using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class OrgBankAccountDAO
    {
        private int IntRowNo;

        private int accountId;

        private int Bank_Id;

        private string Bank_name;

        private string Organization_name;

        private int OrganizationId;

        private string Account_type;

        private int Account_type_id;

        private string BankBranch;

        private int BankBranchId;

        private string AccountNo;

        private string AccountName;

        private string Branch;

        private bool Is_deletd;

        private int intDataSourceId;

        public string account_type
        {
            get
            {
                return this.account_type;
            }
            set
            {
                this.account_type = value;
            }
        }

        public int account_type_id
        {
            get
            {
                return this.account_type_id;
            }
            set
            {
                this.account_type_id = value;
            }
        }

        public int AccountId
        {
            get
            {
                return this.accountId;
            }
            set
            {
                this.accountId = value;
            }
        }

        public int bank_Id
        {
            get
            {
                return this.bank_Id;
            }
            set
            {
                this.bank_Id = value;
            }
        }

        public string bank_name
        {
            get
            {
                return this.bank_name;
            }
            set
            {
                this.bank_name = value;
            }
        }

        public string bankBranch
        {
            get
            {
                return this.bankBranch;
            }
            set
            {
                this.bankBranch = value;
            }
        }

        public string branch
        {
            get
            {
                return this.branch;
            }
            set
            {
                this.branch = value;
            }
        }

        public int DataSourceId
        {
            get
            {
                return this.intDataSourceId;
            }
            set
            {
                this.intDataSourceId = value;
            }
        }

        public int intAccountId
        {
            get
            {
                return this.AccountId;
            }
            set
            {
                this.AccountId = value;
            }
        }

        public int intBankBranchId
        {
            get
            {
                return this.BankBranchId;
            }
            set
            {
                this.BankBranchId = value;
            }
        }

        public int intOrganizationId
        {
            get
            {
                return this.OrganizationId;
            }
            set
            {
                this.OrganizationId = value;
            }
        }

        public int intRowNo
        {
            get
            {
                return this.intRowNo;
            }
            set
            {
                this.intRowNo = value;
            }
        }

        public bool is_deletd
        {
            get
            {
                return this.is_deletd;
            }
            set
            {
                this.is_deletd = value;
            }
        }

        public string organization_name
        {
            get
            {
                return this.organization_name;
            }
            set
            {
                this.organization_name = value;
            }
        }

        public string strAccountName
        {
            get
            {
                return this.AccountName;
            }
            set
            {
                this.AccountName = value;
            }
        }

        public string strAccountNo
        {
            get
            {
                return this.AccountNo;
            }
            set
            {
                this.AccountNo = value;
            }
        }

        public OrgBankAccountDAO()
        {
        }
    }
}
