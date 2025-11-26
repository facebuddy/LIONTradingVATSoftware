using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AddUserBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public AddUserBLL()
        {
        }

        public DataSet CheckExistUser(string Usr)
        {
            string str = string.Concat("select upper(login_id) login_id from admn_employee where login_id = '", Usr, "' AND is_deleted = false");
            return this.DBUtil.GetDataSet(str, "admn_employee");
        }

        public DataSet CheckExistUserToInsert(string Usr)
        {
            string str = string.Concat("select upper(login_id) login_id from admn_employee where login_id = '", Usr, "' and is_deleted=false ");
            return this.DBUtil.GetDataSet(str, "admn_employee");
        }

        public bool CPwd(int uId, string newPss)
        {
            object[] objArray = new object[] { "update admn_employee set login_password = '", newPss, "', user_status='O' where employee_id = ", uId };
            string str = string.Concat(objArray);
            return this.connDB.ExecuteDML(str);
        }

        public bool ExecuteDMLWithOnlyQuery(string strSql)
        {
            return this.DBUtil.ExecuteDMLWithOnlyQuery(strSql);
        }

        public DataTable GetAllMasterOrganization()
        {
            return this.DBUtil.GetDataTable("select * from org_group_management");
        }

        public DataTable GetBranchInformation(int organization_id)
        {
            string str = string.Concat("select org_branch_reg_id,branch_unit_name,organization_id from org_branch_reg_info where is_deleted = false and organization_id = ", organization_id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetDepartment()
        {
            return this.DBUtil.GetDataTable("select * from admn_department WHERE is_deleted = false");
        }

        public DataTable GetDesignation()
        {
            return this.DBUtil.GetDataTable("select * from admn_designation WHERE is_deleted = false");
        }

        public DataTable GetDesignationByDeptId(int Department_id)
        {
            string str = string.Concat("select * from admn_designation WHERE is_deleted = false and department_id=", Department_id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetMasterOrganization()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select * from org_group_management ogm\r\n         inner join org_registration_info o on o.master_organization_id= ogm.master_organization_id\r\n         WHERE is_deleted = false and organization_id = ", num, " ORDER BY organization_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetNoEmployeeByorgId(int orgId)
        {
            string str = string.Concat("select count(employee_id) emp  from admn_employee WHERE is_deleted = false and user_level!=1 and organization_id=", orgId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetNoUserByorgId(int orgId)
        {
            string str = string.Concat("\r\nselect DISTINCT master_organization_id,master_organization_name,user_no from org_group_management WHERE master_organization_id=", orgId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetOrganization()
        {
            string empty = string.Empty;
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            empty = (num != 0 ? string.Concat("select DISTINCT organization_id,organization_name from org_registration_info WHERE is_deleted = false and organization_id = ", num, " ORDER BY organization_name") : "select DISTINCT organization_id,organization_name from org_registration_info WHERE is_deleted = false  ORDER BY organization_name");
            return this.DBUtil.GetDataTable(empty);
        }

        public DataTable GetOrganizationMultiBINSigleAdmin()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["MASTER_ORGANIZATION_ID"]);
            string str = string.Concat("select DISTINCT organization_id,organization_name from org_registration_info WHERE is_deleted = false and master_organization_id = ", num, " ORDER BY organization_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet GetTableForGrid()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select * from\r\n                    (\r\n                    select AE.employee_id,AE.login_id,AE.employee_name,AE.department_id,AD.department_name,AE.designation_id,DE.designation_name,\r\n                    AE.user_level,\r\n\r\n                    CASE \r\n                    WHEN AE.user_level = 1 THEN 'Admin'\r\n                    WHEN AE.user_level = 2 THEN 'Manager User'\r\n                    ELSE 'Normal User'\r\n                    END user_level_status\r\n                    ,AE.emplyee_status,\r\n                    CASE\r\n                    WHEN AE.emplyee_status = 1 THEN 'Active'\r\n                    ELSE 'InActive'\r\n                    END emplyee_status_detail\r\n                     from admn_employee AS AE\r\n                    LEFT JOIN admn_department AS AD ON AE.department_id = AD.department_id\r\n                    LEFT JOIN admn_designation AS DE ON AE.designation_id = DE.designation_id WHERE AE.is_deleted = false and ae.organization_id=", num, "\r\n                    )A WHERE  user_level <> 99 ORDER BY employee_id DESC");
            return this.DBUtil.GetDataSet(str, "admn_employee");
        }

        public DataSet GetTableForGridwithempid(int emp_id)
        {
            string str = string.Concat("select * from (\r\n\t            select AE.employee_id,AE.mobile_no,AE.email,AE.org_branch_reg_id,AE.is_system_user,AE.employee_name,AE.organization_id,\r\n\t            CASE \r\n\t            WHEN is_system_user = true  then 'Yes'\r\n\t            else 'No'\r\n\t            END is_system_user_status,\r\n                CASE \r\n\t            WHEN is_system_user = true  then '1'\r\n\t            else '2'\r\n\t            END is_system_user_count,\r\n\t            AE.login_id,AE.login_password,\r\n                    AE.department_id,AD.department_name,\r\n                    AE.designation_id,DE.designation_name,\r\n\t            AE.user_level,\r\n\t            CASE \r\n\t            WHEN AE.user_level = 1 THEN 'Admin'\r\n\t            ELSE 'Normal User'\r\n\t            END user_level_status\r\n\t            ,AE.emplyee_status,\r\n\t            CASE\r\n\t            WHEN AE.emplyee_status = 1 THEN 'Active'\r\n\t            ELSE 'InActive'\r\n\t            END emplyee_status_detail,\r\n\t            AE.date_join,AE.date_retirement,AE.employee_address,AE.employee_nid,AE.employee_image\r\n\t    \r\n\t            from admn_employee AS AE\r\n\t            LEFT JOIN admn_department AS AD ON AE.department_id = AD.department_id\r\n\t            LEFT JOIN admn_designation AS DE ON AE.designation_id = DE.designation_id\r\n\t            )A  WHERE employee_id = ", emp_id, " ORDER BY employee_id DESC");
            return this.DBUtil.GetDataSet(str, "admn_employee");
        }

        public DataSet GetTableID()
        {
            return this.DBUtil.GetDataSet("select employee_id from admn_employee order by employee_id DESC limit 1", "admn_employee");
        }

        public bool InsertUserLog(UserLogDAO objUserLogDAO)
        {
            object[] userId = new object[] { "INSERT INTO user_log_trail (user_id, ip_address, login_logout_time, status, pc_name) VALUES   ( ", objUserLogDAO.user_id, ",'", objUserLogDAO.ip_address, "','", objUserLogDAO.login_logout_time, "', '", objUserLogDAO.status, "', '", objUserLogDAO.pc_name, "')" };
            string str = string.Concat(userId);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertUserLogAttempt(UserAttemptDAO objUserLogDAO)
        {
            object[] userPassword = new object[] { "INSERT INTO user_log_attempt (user_password, date_attempt, ip_address, pc_name, reaseon_for_attempt_failure) VALUES   ( ", objUserLogDAO.user_password, ",'", objUserLogDAO.date_attempt, "','", objUserLogDAO.ip_address, "', '", objUserLogDAO.pc_name, "', '", objUserLogDAO.reaseon_for_attempt_failure, "')" };
            string str = string.Concat(userPassword);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertUserTaskLog(int userId, DateTime taskDate, string pageName, string menuName, string ipAddress, string pcName)
        {
            object[] objArray = new object[] { "INSERT INTO user_task_log (user_id, task_date, page_name, menu_name, ip_address, pc_name) VALUES   ( ", userId, ",'", taskDate, "','", pageName, "', '", menuName, "', '", ipAddress, "', '", pcName, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}
