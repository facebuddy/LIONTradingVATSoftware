using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class bankInfo
    {
        private int account_id;

        private int bank_Id;

        private int branch_Id;

        private string bank_name;

        private string BankBranch;

        private string AccountNo;

        private string AccountName;

        public int Account_id
        {
            get
            {
                return this.account_id;
            }
            set
            {
                this.account_id = value;
            }
        }

        public int Bank_id
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

        public string Bank_name
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
                return this.BankBranch;
            }
            set
            {
                this.BankBranch = value;
            }
        }

        public int branch_id
        {
            get
            {
                return this.branch_Id;
            }
            set
            {
                this.branch_Id = value;
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

        public bankInfo()
        {
        }
    }
}
