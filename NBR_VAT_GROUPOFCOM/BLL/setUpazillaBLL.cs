using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class setUpazillaBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public setUpazillaBLL()
        {
        }

        public DataTable getAllUpazilaData()
        {
            return this.DBUtil.GetDataTable("select upazila_id, upazila_name, district_id from set_upazila where Is_deleted=false order by upazila_name");
        }
    }
}
