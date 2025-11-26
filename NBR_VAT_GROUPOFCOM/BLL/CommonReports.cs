using System;
using System.Data;


namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CommonReports
    {
        private DBUtility DBUtil = new DBUtility();

        public CommonReports()
        {
        }

        public DataSet GetDesignationInfo(int id)
        {
            string str = string.Concat("select AE.employee_name,AD.designation_name from admn_employee AS AE \r\n                        LEFT JOIN admn_designation AS AD \r\n                        ON AE.designation_id = AD.designation_id\r\n                        WHERE AE.employee_id = ", id);
            return this.DBUtil.GetDataSet(str, "Designation");
        }

        public DataTable GetRejectionEntries()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 25) AND Is_deleted = false ORDER BY code_id_d");
        }

        public DataSet OrgRegistrationInfoTable(int id)
        {
            string str = string.Concat("select * from org_registration_info where organization_id IN(select organization_id from admn_employee where employee_id = ", id, ")");
            return this.DBUtil.GetDataSet(str, "org_reg_info");
        }
    }
}



