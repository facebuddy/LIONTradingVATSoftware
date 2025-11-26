using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class OrgBankAccountBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public OrgBankAccountBLL()
        {
        }

        public DataSet CheckOrgBankAccount(OrgBankAccountDAO objOBADAO)
        {
            object[] objArray = new object[] { "select * from org_bank_account where is_deleted=true and organization_id=", objOBADAO.intOrganizationId, " and bank_branch_id =", objOBADAO.intBankBranchId, " and account_no='", objOBADAO.strAccountNo, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "OrgBankAccount");
        }

        public bool deleteOrgBankAccount(int intAccountId)
        {
            string str = string.Concat("UPDATE org_bank_account set Is_deleted='true' WHERE account_id = '", intAccountId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public bool enableDeletedOrgBankAccount(OrgBankAccountDAO objOBADAO)
        {
            objOBADAO.AccountId = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('org_bank_account_id_seq')"));
            object[] objArray = new object[] { "update org_bank_account set is_deleted = false where is_deleted=true and organization_id=", objOBADAO.intOrganizationId, " and bank_branch_id =", objOBADAO.intBankBranchId, " and account_no='", objOBADAO.strAccountNo, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getAllOrgBankAccount()
        {
            return this.DBUtil.GetDataSet("Select account_id,oba.Organization_id,ori.organization_name, sbb.bank_id, sb.bank_name, sb.short_name, bank_branch_id,sbb.branch_name, account_no, account_name \r\n                            from org_bank_account oba left outer join\r\n                            org_registration_info ori on ori.Organization_id=oba.Organization_id inner join\r\n                            set_bank_branch sbb on sbb.branch_id=oba.bank_branch_id inner join\r\n                            set_bank sb on sb.bank_id=sbb.bank_id\r\n                            where oba.Is_deleted=false order by sb.bank_name,sbb.branch_name, account_no", "OrgBankAccount");
        }

        public DataSet getAllOrgBankAccountByAccountId(int intAccountId)
        {
            string str = string.Concat("Select oba.*,sb.bank_id bankId from org_bank_account oba left outer join\r\n                            set_bank_branch sbb on sbb.branch_id=oba.bank_branch_id inner join\r\n                            set_bank sb on sb.bank_id=sbb.bank_id where account_id='", intAccountId, "'");
            return this.DBUtil.GetDataSet(str, "OrgBankAccount");
        }

        public bool InsertOrgBankAccount(OrgBankAccountDAO objOBADAO)
        {
            objOBADAO.AccountId = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('org_bank_account_id_seq')"));
            object[] accountId = new object[] { "INSERT INTO org_bank_account (account_id,Organization_id,bank_branch_id,account_no,account_name) VALUES   (", objOBADAO.AccountId, ",'", objOBADAO.intOrganizationId, "','", objOBADAO.intBankBranchId, "','", objOBADAO.strAccountNo, "','", objOBADAO.strAccountName, "')" };
            string str = string.Concat(accountId);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateOrgBankAccount(OrgBankAccountDAO objOBADAO)
        {
            object[] objArray = new object[] { " UPDATE org_bank_account SET Organization_id = '", objOBADAO.intOrganizationId, "',bank_branch_id = '", objOBADAO.intBankBranchId, "',account_no='", objOBADAO.strAccountNo, "', account_name='", objOBADAO.strAccountName, "' WHERE account_id = '", objOBADAO.intAccountId, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}

