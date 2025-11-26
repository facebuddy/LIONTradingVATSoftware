using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AlllAddressBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public AlllAddressBLL()
        {
        }

        public bool ExecuteDMLWithOnlyQuery(string strSql)
        {
            return this.DBUtil.ExecuteDMLWithOnlyQuery(strSql);
        }

        public DataSet GetAllAddressTableID()
        {
            return this.DBUtil.GetDataSet("select address_table_id from all_address order by address_table_id DESC LIMIT 1", "all_address");
        }
    }
}
