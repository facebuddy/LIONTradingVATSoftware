using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Set_DesignationBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public Set_DesignationBLL()
        {
        }

        public bool deleteDesignation(int designationId)
        {
            string str = string.Concat("UPDATE admn_designation SET Is_deleted=true WHERE designation_id = '", designationId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable GetDepartment()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select department_id, department_name \r\n                            from admn_department \r\n                            where is_deleted = false \r\n                            order by department_name");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataSet getDesignation(int designationId)
        {
            string str = string.Concat(" select * from admn_designation  where designation_id = '", designationId, "'");
            return this.DBUtil.GetDataSet(str, "Designation");
        }

        public DataTable getDesignationDataForGv()
        {
            return this.DBUtil.GetDataTable("select * from admn_designation where is_deleted = false order by designation_name");
        }

        public bool InsertDesignation(Set_DesignationDao objDesignation)
        {
            objDesignation.DesgID = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('admn_designation_id_seq')"));
            object[] desgID = new object[] { "INSERT INTO admn_designation(designation_id,designation_name, designation_short_name,department_id, is_deleted, date_insert,organization_id) VALUES   (", objDesignation.DesgID, ", '", objDesignation.Designation_name, "','", objDesignation.Designation_short_name, "',", objDesignation.DepartmentID, ",'", objDesignation.Is_deleted, "',to_timestamp('", null, null, null, null };
            desgID[11] = objDesignation.Date.ToString("MM/dd/yyyy HH:mm");
            desgID[12] = "','MM/dd/yyyy HH24:MI'),";
            desgID[13] = objDesignation.Organization_id;
            desgID[14] = ")";
            string str = string.Concat(desgID);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable IsExistDesignationName(string designation)
        {
            string str = string.Concat("select designation_name from admn_designation WHERE UPPER(designation_name) = '", designation, "' AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDesignationNameForUpdate(string designationName, int designationID)
        {
            object[] objArray = new object[] { "select designation_name from admn_designation WHERE UPPER(designation_name) = '", designationName, "' AND is_deleted = false AND designation_id <> ", designationID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDesignationShortName(string designationShortName)
        {
            string str = string.Concat("select designation_short_name from admn_designation WHERE UPPER(designation_short_name) = '", designationShortName, "' AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDesignationShortNameForUpdate(string designationShortName, int designationID)
        {
            object[] objArray = new object[] { "select designation_short_name from admn_designation WHERE UPPER(designation_short_name) = '", designationShortName, "' AND is_deleted = false AND designation_id <> ", designationID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public bool UpdateDesignation(Set_DesignationDao objDesignation, int designationID)
        {
            object[] designationName = new object[] { "UPDATE admn_designation SET  designation_name= '", objDesignation.Designation_name, "',\r\n                                department_id = ", objDesignation.DepartmentID, ", \r\n                                designation_short_name= '", objDesignation.Designation_short_name, "',\r\n                                organization_id=", objDesignation.Organization_id, " ,is_deleted = '", objDesignation.Is_deleted, "',\r\n                                date_insert = to_timestamp('", null, null, null };
            designationName[11] = objDesignation.Date.ToString("MM/dd/yyyy HH:mm");
            designationName[12] = "','MM/dd/yyyy HH24:MI') \r\n                                WHERE designation_id = ";
            designationName[13] = designationID;
            string str = string.Concat(designationName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}