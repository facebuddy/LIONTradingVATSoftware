using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Set_DepartmentBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public Set_DepartmentBLL()
        {
        }

        public bool deleteDesignation(int intDepartmentId)
        {
            string str = string.Concat("UPDATE admn_department SET Is_deleted=true WHERE department_id = '", intDepartmentId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable getDepartmentDataForGv()
        {
            return this.DBUtil.GetDataTable("select * from admn_department where is_deleted = false order by department_name");
        }

        public DataSet getDesignation(int intDepartmentId)
        {
            string str = string.Concat(" select * from admn_department\r\n                 where department_id = '", intDepartmentId, "'");
            return this.DBUtil.GetDataSet(str, "Department");
        }

        public bool InsertDepartment(Set_DepartmentDao objDepartment)
        {
            objDepartment.DeptID = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('admn_department_id_seq')"));
            object[] deptID = new object[] { "INSERT INTO admn_department(department_id,department_name, department_short_name, is_deleted, date_insert,organization_id) VALUES   (", objDepartment.DeptID, ", '", objDepartment.Department_name, "','", objDepartment.Department_short_name, "','", objDepartment.Is_deleted, "','", objDepartment.Date_insert, "',", objDepartment.Organization_id, ")" };
            string str = string.Concat(deptID);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable IsExistDepartmentName(string departmentName)
        {
            string str = string.Concat("select department_name from admn_department WHERE UPPER(department_name) = '", departmentName, "' AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDepartmentNameForUpdate(string departmentName, int departmentID)
        {
            object[] objArray = new object[] { "select department_name from admn_department WHERE UPPER(department_name) = '", departmentName, "' AND is_deleted = false AND department_id <> ", departmentID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDepartmentShortName(string departmentShortName)
        {
            string str = string.Concat("select department_short_name from admn_department WHERE UPPER(department_short_name) = '", departmentShortName, "' AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDepartmentShortNameForUpdate(string departmentShortName, int departmentID)
        {
            object[] objArray = new object[] { "select department_short_name from admn_department WHERE UPPER(department_short_name) = '", departmentShortName, "' AND is_deleted = false AND department_id <> ", departmentID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public bool UpdateDepartment(Set_DepartmentDao objDepartmentDAO, int departmentID)
        {
            object[] departmentName = new object[] { "UPDATE admn_department SET  department_name= '", objDepartmentDAO.Department_name, "', department_short_name= '", objDepartmentDAO.Department_short_name, "',is_deleted = '", objDepartmentDAO.Is_deleted, "', organization_id=", objDepartmentDAO.Organization_id, "  WHERE department_id = ", departmentID };
            string str = string.Concat(departmentName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}