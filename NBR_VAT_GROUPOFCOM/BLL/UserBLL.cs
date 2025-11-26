using Npgsql;
using System;
using System.Data;
using System.Data.Common;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UserBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public UserBLL()
        {
        }

        public DataTable getActiveLicenseInfo()
        {
            return this.DBUtil.GetDataTable(" SELECT * FROM admin_license_info where is_deleted=false AND is_active = true ");
        }

        public DataTable getActiveLicenseInfoNotExpire()
        {
            return this.DBUtil.GetDataTable(" SELECT * FROM admin_license_info where is_deleted=false AND is_active = true and now() <= activation_date + (INTERVAL '1 month' * service_pack) ");
        }


        public DataTable GetBusinessInformation(int organizationId, int ORGBRANCHID)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select o.organization_id,o.Organization_name,obri.branch_unit_name,obri.org_branch_address ,o.registration_no BIN_NO, o.business_address,ora.operation_address address ,o.circle_id\r\n                             from org_registration_info o\r\n                             inner join org_reg_address ora on o.Organization_id = ora.Organization_id  \r\n                             inner join org_branch_reg_info obri on obri.Organization_id= o.Organization_id\r\n                             where o.organization_id=", organizationId, " and obri.org_branch_reg_id=", ORGBRANCHID };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetBusinessInformation(int organizationId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select o.organization_id,o.Organization_name, o.registration_no BIN_NO, o.business_address,ora.operation_address address ,o.circle_id \r\n                             from org_registration_info o\r\n                             inner join org_reg_address ora on o.Organization_id = ora.Organization_id  \r\n                             where o.organization_id=", organizationId);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getBusinessUnit()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.DBUtil.GetDataTable("select business_unit_id,business_unit_name,schema_name from business_unit");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getBusinessUnitNew()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.DBUtil.GetDataTable("select organization_id,organization_name from org_registration_info");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetEmployeewiseBranchAccess(int userId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select distinct a.organization_id,a.org_branch_reg_id,b.branch_unit_name,business_unit_status  \r\n                                from bss_unit_branch_acc_control a\r\n                                inner join org_branch_reg_info b on a.organization_id=b.organization_id and a.org_branch_reg_id=b.org_branch_reg_id\r\n                                where a.employee_id=", userId, "  and a.is_deleted = false order by a.org_branch_reg_id");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetOrganizationAccess(int organizationId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select distinct b.organization_id, b.organization_name from bss_unit_branch_acc_control c inner join org_registration_info b on c.organization_id= b.organization_id where employee_id = ", organizationId, "  and c.is_deleted = false");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetOrganizationBranchAccess(int userId, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct a.org_branch_reg_id,b.branch_unit_name\r\n                                from bss_unit_branch_acc_control a\r\n                                inner join org_branch_reg_info b on a.organization_id=b.organization_id and a.org_branch_reg_id=b.org_branch_reg_id\r\n                                where a.employee_id=", userId, " and a.organization_id=", organizationId, " order by a.org_branch_reg_id" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getPasswordbyUserId(string strUserId)
        {
            string str = string.Concat("Select login_password from admn_employee where  UPPER(login_id) = '", strUserId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getUserID(string strUserId, string strPassword)
        {
            DataTable dataTable;
            try
            {
                string[] strArrays = new string[] { " SELECT e.*, o.Organization_name,o.master_organization_id, o.registration_no BIN_NO, o.is_vat_deduct,\r\n                                  ora.operation_address address ,o.circle_id\r\n                             FROM admn_employee e \r\n                             left outer join org_registration_info o \r\n                             on o.Organization_id = e.Organization_id\r\n                             left join org_reg_address ora on o.Organization_id = ora.Organization_id  \r\n                             left join org_group_management ogm on o.master_organization_id= ogm.master_organization_id                      \r\n                             where e.Is_deleted = false\r\n                            and UPPER(e.login_id) = '", strUserId, "' and e.login_password='", strPassword, "' order by address desc" };
                string str = string.Concat(strArrays);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getUserIDActive(string strUserId, string strPassword)
        {
            string[] strArrays = new string[] { " SELECT * FROM admn_employee \r\n                where Is_deleted=false and UPPER(login_id) = '", strUserId, "' and login_password='", strPassword, "' AND emplyee_status = 1" };
            string str = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str);
        }

        public bool getUserIDBool(string strUserId, string strPassword)
        {
            string[] strArrays = new string[] { " SELECT e.*, o.Organization_name, o.registration_no BIN_NO, o.business_address FROM admn_employee e \r\n                left outer join org_registration_info o on o.Organization_id = e.Organization_id\r\n                where e.Is_deleted=false and e.login_id='", strUserId, "' and e.login_password='", strPassword, "'" };
            string str = string.Concat(strArrays);
            return this.DBUtil.ExecuteDMLWithOnlyQueryNotlog(str);
        }

        public bool updateBusinessStatus(int userId, int orgId, int branchId)
        {
            object[] objArray = new object[] { " update bss_unit_branch_acc_control set business_unit_status=false where organization_id=", orgId, " and employee_id=", userId, " and org_branch_reg_id=", branchId, " and is_deleted = false" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateBusinessStatusActive(int userId, int orgId, int branchId)
        {
            object[] objArray = new object[] { " update bss_unit_branch_acc_control set business_unit_status=true where organization_id=", orgId, " and employee_id=", userId, " and org_branch_reg_id=", branchId, " and is_deleted = false" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateLicenseInfo(int day, int concurrent_user, int service_pack, string license_key)
        {
            bool flag;
            string str = "UPDATE admin_license_info set  activation_date=activation_date + (INTERVAL '1 day' *  @extendDay) , concurrent_user=@concurrent_user , service_pack=@service_pack   where license_key=@license_key";
            try
            {
                try
                {
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, DBUtility.getDBConnection());
                    npgsqlCommand.Parameters.AddWithValue("@extendDay", day);
                    npgsqlCommand.Parameters.AddWithValue("@is_active", true);
                    npgsqlCommand.Parameters.AddWithValue("@concurrent_user", concurrent_user);
                    npgsqlCommand.Parameters.AddWithValue("@license_key", license_key);
                    npgsqlCommand.Parameters.AddWithValue("@service_pack", service_pack);
                    if (npgsqlCommand.ExecuteNonQuery() == 1)
                    {
                        flag = true;
                        return flag;
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
                return false;
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }
    }
}