using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetDivsionBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetDivsionBLL()
        {
        }

        public DataTable getDivisionData()
        {
            return this.DBUtil.GetDataTable("SELECT * from set_division where Is_deleted=false order by division_name");
        }
    }
}