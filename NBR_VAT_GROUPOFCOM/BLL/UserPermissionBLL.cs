using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UserPermissionBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public UserPermissionBLL()
        {
        }

        public DataSet CheckAdminUser(int id)
        {
            string str = "";
            str = string.Concat("select * from admn_employee where employee_id= ", id);
            return this.DBUtil.GetDataSet(str, "Permission");
        }

        public DataTable CheckPaymentMethodPermision(string orgId, string branchId, string url)
        {
            url.Substring(10);
            string str = "";
            string[] strArrays = new string[] { "select * from payment_method_permission pmp\r\n        left join admin_user_menu as asu on asu.menu_id=pmp.menu_id\r\n        left join set_payment_method as spm on pmp.payment_method_id=spm.payment_method_id\r\n        where asu.url Like '%", url, "' and pmp.org_id=", orgId, " and pmp.org_branch_id=", branchId, " and pmp.is_deleted=false" };
            str = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet CheckPaymentMethodPermission(int orgId, int orgBranchId, int menuId, int paymentMehtodId)
        {
            DataSet dataSet = new DataSet();
            DBUtility dBUtility = new DBUtility();
            object[] objArray = new object[] { "select * from payment_method_permission where payment_method_id=", paymentMehtodId, " and org_id=", orgId, " and org_branch_id=", orgBranchId, " and menu_id=", menuId };
            return dBUtility.GetDataSet(string.Concat(objArray), "Permission");
        }

        public DataSet CheckUserAuthentication(int id, string url)
        {
            url.Substring(10);
            string str = "";
            object[] objArray = new object[] { "select P.menu_id,P.user_id,UM.menu_id,UM.url,UM.title,E.login_id  from admin_user_menu_permission AS P\r\n                        LEFT JOIN admin_user_menu UM\r\n                        ON P.menu_id = UM.menu_id \r\n                        LEFT JOIN admn_employee AS E\r\n                        ON P.user_id = E.employee_id\r\n                        WHERE P.user_id = ", id, " AND UM.url = '", url, "'" };
            str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "Permission");
        }

        public DataSet CheckUserPermission(UserPermissionDAO objEntity)
        {
            DataSet dataSet = new DataSet();
            DBUtility dBUtility = new DBUtility();
            object[] employeeId = new object[] { "SELECT * FROM admin_user_menu_permission WHERE USER_ID = ", objEntity.employee_id, " AND MENU_ID = '", objEntity.PermissionKey, "'" };
            return dBUtility.GetDataSet(string.Concat(employeeId), "Permission");
        }

        public DataTable GetAllSubform()
        {
            return this.DBUtil.GetDataTable("Select menu_id from admin_user_menu where parent_id=75");
        }

        public DataTable GetAllUser(string employeeName)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            if (HttpContext.Current.Session["LOGIN_ID"].ToString() == "root")
            {
                string str = string.Concat("select * from\r\n                (\r\n                select AE.employee_id,upper(AE.employee_name) AS employee_name,AE.login_id,AD.designation_name,DD.department_name,AE.is_deleted from admn_employee AS AE\r\n                LEFT JOIN admn_designation AS AD\r\n                ON AE.designation_id = AD.designation_id\r\n                LEFT JOIN admn_department AS DD\r\n                ON AE.department_id = DD.department_id  \r\n                )A WHERE  is_deleted = false AND employee_name like '%", employeeName, "%' ");
                return this.DBUtil.GetDataTable(str);
            }
            object[] objArray = new object[] { "select * from\r\n                (\r\n                select AE.employee_id,upper(AE.employee_name) AS employee_name,AE.login_id,AD.designation_name,DD.department_name,AE.is_deleted from admn_employee AS AE\r\n                LEFT JOIN admn_designation AS AD\r\n                ON AE.designation_id = AD.designation_id\r\n                LEFT JOIN admn_department AS DD\r\n                ON AE.department_id = DD.department_id WHERE  AE.organization_id = ", num, "\r\n                )A WHERE  is_deleted = false AND employee_name like '%", employeeName, "%'" };
            string str1 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataSet getPayMenuPermission(string strParent)
        {
            DataSet dataSet = new DataSet();
            DBUtility dBUtility = new DBUtility();
            string str = "";
            string str1 = "";
            if (strParent == "")
            {
                str1 = string.Concat(str1, " WHERE menu_id=46 and is_enable = true ");
                str = string.Concat("SELECT * FROM admin_user_menu ", str1, " ORDER BY admin_user_menu.ordinal_position");
                dataSet = dBUtility.GetDataSet(str, "Permission");
            }
            else if (strParent == "46")
            {
                str1 = string.Concat(str1, " WHERE menu_id in (47,48,49,58,59,140) and is_enable = true ");
                str = string.Concat("SELECT * FROM admin_user_menu ", str1, " ORDER BY admin_user_menu.ordinal_position");
                dataSet = dBUtility.GetDataSet(str, "Permission");
            }
            else if (strParent == "47" || strParent == "48" || strParent == "49" || strParent == "58" || strParent == "59" || strParent == "140")
            {
                dataSet = dBUtility.GetDataSet("select payment_method_id,remarks,insert_by, payment_method_name from set_payment_method;", "Permission");
            }
            return dataSet;
        }

        public DataSet getUserByUserID(int EmployeeId)
        {
            string str = "";
            if (EmployeeId != 0)
            {
                str = string.Concat(str, " and emp.employee_id=", EmployeeId);
            }
            string str1 = string.Concat("select emp.employee_id,employee_name,\r\n                        emp.login_id,emp.user_level,emp.emplyee_status,\r\n                        case when emp.emplyee_status=1 then 'Active' when emp.emplyee_status=0 then 'Inactive' end is_active,\r\n                        d.designation_name\r\n                        from admn_employee AS emp\r\n                        left join admn_designation d on emp.designation_id=d.designation_id where emp.is_deleted = false  ", str, " order by employee_name");
            return this.connDB.GetDataSet(str1, "ds");
        }

        public DataSet getUserPermission(string strParent)
        {
            DataSet dataSet = new DataSet();
            DBUtility dBUtility = new DBUtility();
            string str = "";
            string str1 = "";
            str1 = (strParent != "" ? string.Concat(str1, " WHERE parent_id = '", strParent, "' and is_enable = true ") : string.Concat(str1, " WHERE parent_id = 0 and is_enable = true "));
            str = string.Concat("SELECT * FROM admin_user_menu ", str1, " ORDER BY admin_user_menu.ordinal_position");
            return dBUtility.GetDataSet(str, "Permission");
        }

        public void SaveOrgPaymentMethodPermision(int orgId, int orgBranchId, ArrayList arrPermit)
        {
            DBUtility dBUtility = new DBUtility();
            ArrayList arrayLists = new ArrayList();
            object[] objArray = new object[] { "Delete from payment_method_permission where org_id=", orgId, " and org_branch_id=", orgBranchId, " " };
            arrayLists.Add(string.Concat(objArray));
            foreach (PaymentMethodPermissionDao paymentMethodPermissionDao in arrPermit)
            {
                object[] objArray1 = new object[] { "INSERT INTO PAYMENT_METHOD_PERMISSION(PAYMENT_METHOD_ID, ORG_ID, ORG_BRANCH_ID,MENU_ID,IS_DELETED) VALUES(", paymentMethodPermissionDao.paymentMetodId, ",", paymentMethodPermissionDao.organizationId, ",", paymentMethodPermissionDao.branchId, ",", paymentMethodPermissionDao.menuId, ", FALSE)" };
                arrayLists.Add(string.Concat(objArray1));
            }
            dBUtility.ExecuteBatchDML(arrayLists);
        }

        public void SaveUserPermision(UserPermissionDAO objEntity, ArrayList arrPermit, DataTable dtsubForm)
        {
            string str = "";
            DBUtility dBUtility = new DBUtility();
            ArrayList arrayLists = new ArrayList();
            int i = 0;
            arrayLists.Add(string.Concat("DELETE FROM  admin_user_menu_permission WHERE USER_ID = ", objEntity.employee_id));
            if (arrPermit.Count >= 1)
            {
                short num = 1;
                for (i = 0; i < arrPermit.Count; i++)
                {
                    if (arrPermit[i].ToString() == "1")
                    {
                        num = 0;
                    }
                    if (arrPermit[i].ToString() == "44")
                    {
                        int num1 = 158;
                        object[] employeeId = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num1, "')" };
                        arrayLists.Add(string.Concat(employeeId));
                    }
                    if (arrPermit[i].ToString() == "144")
                    {
                        int num2 = 145;
                        object[] objArray = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num2, "')" };
                        arrayLists.Add(string.Concat(objArray));
                    }
                    if (arrPermit[i].ToString() == "36")
                    {
                        int num3 = 152;
                        object[] employeeId1 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num3, "')" };
                        arrayLists.Add(string.Concat(employeeId1));
                    }
                    if (arrPermit[i].ToString() == "47")
                    {
                        int num4 = 153;
                        object[] objArray1 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num4, "')" };
                        arrayLists.Add(string.Concat(objArray1));
                    }
                    if (arrPermit[i].ToString() == "37")
                    {
                        int num5 = 154;
                        object[] employeeId2 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num5, "')" };
                        arrayLists.Add(string.Concat(employeeId2));
                    }
                    if (arrPermit[i].ToString() == "48")
                    {
                        int num6 = 155;
                        object[] objArray2 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num6, "')" };
                        arrayLists.Add(string.Concat(objArray2));
                    }
                    if (arrPermit[i].ToString() == "58")
                    {
                        int num7 = 146;
                        object[] employeeId3 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num7, "')" };
                        arrayLists.Add(string.Concat(employeeId3));
                        str = string.Concat("INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",156)");
                        arrayLists.Add(str);
                        str = string.Concat("INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",160)");
                        arrayLists.Add(str);
                    }
                    if (arrPermit[i].ToString() == "32")
                    {
                        int num8 = 147;
                        object[] objArray3 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num8, "')" };
                        arrayLists.Add(string.Concat(objArray3));
                    }
                    if (arrPermit[i].ToString() == "75")
                    {
                        int num9 = 0;
                        for (int j = 0; j < dtsubForm.Rows.Count; j++)
                        {
                            num9 = Convert.ToInt16(dtsubForm.Rows[j]["menu_id"]);
                            object[] employeeId4 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", num9, "')" };
                            arrayLists.Add(string.Concat(employeeId4));
                        }
                    }
                    object[] objArray4 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", arrPermit[i].ToString(), "')" };
                    arrayLists.Add(string.Concat(objArray4));
                }
                if (num == 1)
                {
                    object[] employeeId5 = new object[] { "INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'", arrPermit[i].ToString(), "')" };
                    arrayLists.Add(string.Concat(employeeId5));
                }
            }
            else
            {
                str = string.Concat("INSERT INTO admin_user_menu_permission(USER_ID,MENU_ID) VALUES( ", objEntity.employee_id, ",'1' )");
                arrayLists.Add(str);
            }
            dBUtility.ExecuteBatchDML(arrayLists);
        }
    }
}