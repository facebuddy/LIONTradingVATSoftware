using System;
using System.Collections;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrgBankAccountNewDAO
    {
        private int intRowNo;

        private short accountId;

        private short bank_Id;

        private string bank_name;

        private string organization_name;

        private int organizationId;

        private string account_type;

        private int account_type_id;

        private string bankBranch;

        private int bankBranchId;

        private string accountNo;

        private string accountName;

        private string branch;

        private int branchID;

        private bool is_deletd;

        private bool is_vat_registration;

        private bool is_branch_registration;

        public string Account_type
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

        public int Account_type_id
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

        public short AccountId
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

        public string AccountName
        {
            get
            {
                return this.accountName;
            }
            set
            {
                this.accountName = value;
            }
        }

        public string AccountNo
        {
            get
            {
                return this.accountNo;
            }
            set
            {
                this.accountNo = value;
            }
        }

        public short Bank_Id
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

        public string BankBranch
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

        public int BankBranchId
        {
            get
            {
                return this.bankBranchId;
            }
            set
            {
                this.bankBranchId = value;
            }
        }

        public string Branch
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

        public int IntRowNo
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

        public bool Is_branch_registration
        {
            get
            {
                return this.is_branch_registration;
            }
            set
            {
                this.is_branch_registration = value;
            }
        }

        public bool Is_deletd
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

        public bool Is_vat_registration
        {
            get
            {
                return this.is_vat_registration;
            }
            set
            {
                this.is_vat_registration = value;
            }
        }

        public string Organization_name
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

        public OrgBankAccountNewDAO()
        {
        }

        public bool SaveBankInformation(ArrayList list, int org_id)
        {
            ArrayList arrayLists = new ArrayList();
            DBUtility dBUtility = new DBUtility();
            int num = 0;
            if (HttpContext.Current.Session["BRANCH_INFO_ID"] != null)
            {
                num = Convert.ToInt32(HttpContext.Current.Session["BRANCH_INFO_ID"].ToString());
            }
            for (int i = 0; i < list.Count; i++)
            {
                OrgBankAccountNewDAO orgBankAccountNewDAO = new OrgBankAccountNewDAO();
                orgBankAccountNewDAO = (OrgBankAccountNewDAO)list[i];
                object obj = "INSERT INTO org_bank_account(account_id,Organization_id,bank_id,bank_branch_id,account_no,account_name,account_type_id,Is_deleted,is_vat_registration,is_branch_registration,org_branch_reg_id)";
                object[] orgId = new object[] { obj, " Values(nextval('org_bank_account_id_seq'),", org_id, ",", orgBankAccountNewDAO.bank_Id, ",", orgBankAccountNewDAO.bankBranchId, ",'", orgBankAccountNewDAO.accountNo, "','", orgBankAccountNewDAO.accountName, "', ", orgBankAccountNewDAO.account_type_id, ",", this.Is_deletd, ",", this.is_vat_registration, ",", this.is_branch_registration, ",", num, " )" };
                arrayLists.Add(string.Concat(orgId));
            }
            return dBUtility.ExecuteBatchDML(arrayLists);
        }
    }
}