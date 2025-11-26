using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrgBranchRegistrationInfoBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public OrgBranchRegistrationInfoBLL()
        {
        }

        public DataSet CheckUniqueKeyForBankInfo(int orgID, int bbranchID, string baccNo)
        {
            object[] objArray = new object[] { "select * FROM org_bank_account WHERE organization_id = ", orgID, " AND  bank_branch_id = ", bbranchID, " AND account_no = '", baccNo, "' " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "all_address");
        }

        public bool ExecuteDMLWithOnlyQuery(string strSql)
        {
            return this.DBUtil.ExecuteDMLWithOnlyQuery(strSql);
        }

        public DataSet OrgBranchRegistrationInfoTableID()
        {
            return this.DBUtil.GetDataSet("select org_branch_reg_id from org_branch_reg_info order by org_branch_reg_id DESC LIMIT 1;", "org_branch_reg_info");
        }
    }
}