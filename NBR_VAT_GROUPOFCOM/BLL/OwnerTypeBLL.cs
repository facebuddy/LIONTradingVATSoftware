using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OwnerTypeBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public OwnerTypeBLL()
        {
        }

        public DataTable GetOwnerType()
        {
            return this.DBUtil.GetDataTable("SELECT code_id_d,code_name FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 24) AND Is_deleted = false ORDER BY code_name;");
        }

        public DataSet GetOwnerTypeTableID()
        {
            return this.DBUtil.GetDataSet("select owner_type_table_id from owner_type order by owner_type_table_id DESC LIMIT 1;", "owner_type");
        }
    }
}