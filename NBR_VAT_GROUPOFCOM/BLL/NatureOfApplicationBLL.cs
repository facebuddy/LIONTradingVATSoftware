using System;
using System.Collections;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class NatureOfApplicationBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public NatureOfApplicationBLL()
        {
        }

        public void ExecuteDMLWithOnlyQuery(string strSql)
        {
            this.DBUtil.ExecuteDMLWithOnlyQuery(strSql);
        }

        public DataSet GetBranchRegTableID()
        {
            return this.DBUtil.GetDataSet("select * from org_branch_reg_info WHERE is_deleted = false ORDER BY org_branch_reg_id desc limit 1", "branch_reg");
        }

        public DataSet GetNatureOfApplicationTableID()
        {
            return this.DBUtil.GetDataSet("select nature_of_application_id from nature_of_application order by nature_of_application_id DESC LIMIT 1;", "all_address");
        }

        public bool InsertPurchaseData(NatureOfApplicationDao objMDAO, ArrayList arrDeailDAO, int id, bool test)
        {
            return false;
        }
    }
}