using System;
using System.Data;
using System.Runtime.CompilerServices;



namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AddUserDAO
    {
        private AddUserBLL addUserBll = new AddUserBLL();

        private DBUtility dbutl = new DBUtility();

        private short employee_id;

        private string employee_name;

        private bool is_system_user = true;

        private string login_id;

        private string login_password;

        private short organization_id;

        private short branch_id;

        private short department_id;

        private short designation_id;

        private short user_level;

        private short emplyee_status;

        private DateTime date_insert = DateTime.Now;

        private DateTime date_update = DateTime.Now;

        private bool is_deleted;

        private string mobile_no;

        private string email;

        public string Address
        {
            get;
            set;
        }

        public short Branch_id
        {
            get
            {
                return this.branch_id;
            }
            set
            {
                this.branch_id = value;
            }
        }

        public DateTime Date_insert
        {
            get
            {
                return this.date_insert;
            }
            set
            {
                this.date_insert = value;
            }
        }

        private DateTime Date_update
        {
            get
            {
                return this.date_update;
            }
            set
            {
                this.date_update = value;
            }
        }

        public DateTime DateJoining
        {
            get;
            set;
        }

        public DateTime DateRetirement
        {
            get;
            set;
        }

        public short Department_id
        {
            get
            {
                return this.department_id;
            }
            set
            {
                this.department_id = value;
            }
        }

        public short Designation_id
        {
            get
            {
                return this.designation_id;
            }
            set
            {
                this.designation_id = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public short Employee_id
        {
            get
            {
                return this.employee_id;
            }
            set
            {
                this.employee_id = value;
            }
        }

        public string Employee_name
        {
            get
            {
                return this.employee_name;
            }
            set
            {
                this.employee_name = value;
            }
        }

        public short Emplyee_status
        {
            get
            {
                return this.emplyee_status;
            }
            set
            {
                this.emplyee_status = value;
            }
        }

        public string Image
        {
            get;
            set;
        }

        public bool Is_deleted
        {
            get
            {
                return this.is_deleted;
            }
            set
            {
                this.is_deleted = value;
            }
        }

        public bool Is_system_user
        {
            get
            {
                return this.is_system_user;
            }
            set
            {
                this.is_system_user = value;
            }
        }

        public string Login_id
        {
            get
            {
                return this.login_id;
            }
            set
            {
                this.login_id = value;
            }
        }

        public string Login_password
        {
            get
            {
                return this.login_password;
            }
            set
            {
                this.login_password = value;
            }
        }

        public string Mobile_no
        {
            get
            {
                return this.mobile_no;
            }
            set
            {
                this.mobile_no = value;
            }
        }

        public string NID
        {
            get;
            set;
        }

        public short Organization_id
        {
            get
            {
                return this.organization_id;
            }
            set
            {
                this.organization_id = value;
            }
        }

        public short User_level
        {
            get
            {
                return this.user_level;
            }
            set
            {
                this.user_level = value;
            }
        }

        public string user_status
        {
            get;
            set;
        }

        public AddUserDAO()
        {
        }

        public DataSet CheckExistUser(string Usr)
        {
            return this.addUserBll.CheckExistUser(Usr);
        }

        public DataSet CheckExistUserToInsert(string Usr)
        {
            return this.addUserBll.CheckExistUserToInsert(Usr);
        }

        public DataSet CheckUserPermissionInMenuPermission(int emp_id)
        {
            string str = string.Concat("select * from admin_user_menu_permission where user_id = ", emp_id, " AND is_deleted = false AND menu_id <> 1");
            return this.dbutl.GetDataSet(str, "admin_user_menu_permission");
        }

        public bool DeleteAddUser(int emp_id)
        {
            string str = string.Concat("UPDATE admn_employee SET is_deleted = true WHERE employee_id = ", emp_id);
            string str1 = string.Concat("DELETE  from admin_user_menu_permission where user_id = ", emp_id);
            this.addUserBll.ExecuteDMLWithOnlyQuery(str1);
            return this.addUserBll.ExecuteDMLWithOnlyQuery(str);
        }

        public DataTable GetBranchInformation(int organization_id)
        {
            return this.addUserBll.GetBranchInformation(organization_id);
        }

        public DataTable GetDepartment()
        {
            return this.addUserBll.GetDepartment();
        }

        public DataTable GetDesignation()
        {
            return this.addUserBll.GetDesignation();
        }

        public DataTable GetNoOfUserByorgId(int orgId)
        {
            return this.addUserBll.GetNoUserByorgId(orgId);
        }

        public DataTable GetOrganization()
        {
            return this.addUserBll.GetOrganization();
        }

        public DataSet GetTableForGrid()
        {
            return this.addUserBll.GetTableForGrid();
        }

        public DataSet GetTableForGridwithempid(int empid)
        {
            return this.addUserBll.GetTableForGridwithempid(empid);
        }

        public bool SaveAddUser()
        {
            DataSet tableID = this.addUserBll.GetTableID();
            if (tableID.Tables[0].Rows.Count <= 0)
            {
                this.employee_id = 1;
            }
            else
            {
                int num = Convert.ToInt16(tableID.Tables[0].Rows[0]["employee_id"].ToString());
                this.employee_id = Convert.ToInt16(num + 1);
            }
            if (this.DateRetirement > DateTime.MinValue)
            {
                string str = "INSERT INTO admn_employee(employee_id,employee_name,is_system_user,login_id,login_password,organization_id,department_id,designation_id,user_level,emplyee_status,date_join,date_retirement,date_insert,is_deleted,mobile_no,email,org_branch_reg_id, user_status,employee_address,employee_nid,employee_image) ";
                object[] employeeId = new object[] { " Values(", this.employee_id, ",'", this.employee_name, "',", this.is_system_user, ",'", this.login_id, "','", this.login_password, "',\r\n            ", this.organization_id, ",", this.department_id, ",", this.designation_id, ",", this.user_level, ",", this.emplyee_status, ",\r\n            to_timestamp('", this.DateJoining.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n            to_timestamp('", this.DateRetirement.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n            to_timestamp('", this.date_insert.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),", this.is_deleted, ",'", this.mobile_no, "','", this.email, "',", this.branch_id, ", '", this.user_status, "', '", this.Address, "' , '", this.NID, "', '", this.Image, "')" };
                string str1 = string.Concat(str, string.Concat(employeeId));
                return this.addUserBll.ExecuteDMLWithOnlyQuery(str1);
            }
            string str2 = "INSERT INTO admn_employee(employee_id,employee_name,is_system_user,login_id,login_password,organization_id,department_id,\r\n            designation_id,user_level,emplyee_status,date_join,date_retirement,date_insert,is_deleted,mobile_no,email,org_branch_reg_id, user_status,employee_address,employee_nid,employee_image) ";
            object[] objArray = new object[] { " Values(", this.employee_id, ",'", this.employee_name, "',", this.is_system_user, ",'", this.login_id, "','", this.login_password, "',\r\n            ", this.organization_id, ",", this.department_id, ",", this.designation_id, ",", this.user_level, ",", this.emplyee_status, ",\r\n             to_timestamp('", this.DateJoining.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n            to_timestamp('", this.DateRetirement.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n           to_timestamp('", this.date_insert.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),", this.is_deleted, ",'", this.mobile_no, "','", this.email, "' ,", this.branch_id, ", '", this.user_status, "', '", this.Address, "' , '", this.NID, "', '", this.Image, "')" };
            string str3 = string.Concat(str2, string.Concat(objArray));
            return this.addUserBll.ExecuteDMLWithOnlyQuery(str3);
        }

        public bool UpdateAddUser(int emp_id)
        {
            if (this.DateRetirement > DateTime.MinValue)
            {
                object[] employeeName = new object[] { "UPDATE admn_employee SET employee_name = '", this.employee_name, "',is_system_user = ", this.is_system_user, ",login_id = '", this.login_id, "',\r\n            login_password = '", this.Login_password, "',organization_id = ", this.organization_id, ",department_id = ", this.department_id, ",\r\n            designation_id = ", this.designation_id, ",user_level = ", this.user_level, ",emplyee_status = ", this.emplyee_status, ",\r\n            date_join = to_timestamp('", this.DateJoining.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n            date_retirement = to_timestamp('", this.DateRetirement.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n            date_update = to_timestamp('", this.date_update.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),mobile_no = '", this.mobile_no, "',email = '", this.email, "',org_branch_reg_id = ", this.branch_id, "  , employee_address='", this.Address, "' , employee_nid='", this.NID, "', employee_image='", this.Image, "'\r\n            WHERE employee_id = ", emp_id };
                string str = string.Concat(employeeName);
                return this.addUserBll.ExecuteDMLWithOnlyQuery(str);
            }
            object[] objArray = new object[] { "UPDATE admn_employee SET employee_name = '", this.employee_name, "',is_system_user = ", this.is_system_user, ",login_id = '", this.login_id, "',\r\n            login_password = '", this.Login_password, "',organization_id = ", this.organization_id, ",department_id = ", this.department_id, ",\r\n            designation_id = ", this.designation_id, ",user_level = ", this.user_level, ",emplyee_status = ", this.emplyee_status, ",\r\n            date_join = to_timestamp('", this.DateJoining.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n            date_retirement = to_timestamp('", this.DateRetirement.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n            date_update = to_timestamp('", this.date_update.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), mobile_no = '", this.mobile_no, "',email = '", this.email, "',org_branch_reg_id = ", this.branch_id, "  , employee_address='", this.Address, "' , employee_nid='", this.NID, "', employee_image='", this.Image, "'  WHERE employee_id = ", emp_id };
            string str1 = string.Concat(objArray);
            return this.addUserBll.ExecuteDMLWithOnlyQuery(str1);
        }
    }
}

