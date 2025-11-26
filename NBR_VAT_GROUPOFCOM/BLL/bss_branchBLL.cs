using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class bss_branchBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public bss_branchBLL()
        {
        }

        public int bssCntroller(int bssbranchContId)
        {
            int num = 0;
            string str = string.Concat("select ae.user_level from bss_unit_branch_acc_control bubac\r\n                            inner join admn_employee ae on bubac.employee_id=ae.employee_id\r\n                            where bubac.bss_brnch_cont_id=", bssbranchContId);
            DataTable dataTable = this.DBUtil.GetDataTable(str);
            if (dataTable.Rows.Count > 0 && dataTable != null)
            {
                num = Convert.ToInt32(dataTable.Rows[0]["user_level"]);
            }
            return num;
        }

        public bool CheckBranchData(ArrayList arrDeailDAObranch)
        {
            bool flag = false;
            string str = "";
            int num = 0;
            while (num < arrDeailDAObranch.Count)
            {
                Bss_Branch_ControlDAO bssBranchControlDAO = new Bss_Branch_ControlDAO();
                bssBranchControlDAO = (Bss_Branch_ControlDAO)arrDeailDAObranch[num];
                object[] organizationId = new object[] { "select * from bss_unit_branch_acc_control where organization_id=", bssBranchControlDAO.Organization_id, " and org_branch_reg_id=", bssBranchControlDAO.Org_branch_reg_id, " and employee_id=", bssBranchControlDAO.Employee_id, " and is_deleted=false" };
                str = string.Concat(organizationId);
                DataTable dataTable = this.DBUtil.GetDataTable(str);
                if (dataTable.Rows.Count <= 0 || dataTable == null)
                {
                    num++;
                }
                else
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool deleteBusinessControlAccess(int bssbranchContId)
        {
            string str = string.Concat("Update bss_unit_branch_acc_control set is_deleted = true where bss_brnch_cont_id=", bssbranchContId);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable GetBranch(int OrgId)
        {
            string str = string.Concat("SELECT * FROM org_branch_reg_info WHERE organization_id=", OrgId, " and Is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetEmployee()
        {
            string empty = string.Empty;
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            empty = (num != 0 ? string.Concat("SELECT * FROM admn_employee WHERE Is_deleted = false and organization_id=", num) : "SELECT * FROM admn_employee WHERE Is_deleted = false");
            return this.DBUtil.GetDataTable(empty);
        }

        public DataTable GetEmployeebyBranchId()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "SELECT distinct e.employee_id,e.employee_name FROM admn_employee e\r\n            inner join bss_unit_branch_acc_control b on b.employee_id = e.employee_id\r\n            WHERE e.Is_deleted = false and b.organization_id=", num, " and b.org_branch_reg_id = ", num1 };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetEmployeeMultiBINSingleAdmin()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["MASTER_ORGANIZATION_ID"]);
            string str = string.Concat("SELECT * FROM admn_employee e\r\n            inner join org_registration_info o on o.organization_id = e.organization_id\r\n            WHERE e.Is_deleted = false and o.master_organization_id=", num);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetOrganization()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM org_registration_info WHERE Is_deleted = false");
        }

        public DataTable GetTableForGrid()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select buc.bss_brnch_cont_id,buc.org_branch_reg_id Org_branch_reg_id,buc.remarks Remarks,ori.organization_name Org_name,ademp.employee_name Employee_name,orgbr.branch_unit_name Org_branch_name from bss_unit_branch_acc_control buc\r\n                            inner join org_registration_info ori on buc.organization_id=ori.organization_id\r\n                            inner join admn_employee ademp on buc.employee_id=ademp.employee_id\r\n                            inner join org_branch_reg_info orgbr on buc.org_branch_reg_id=orgbr.org_branch_reg_id where buc.is_deleted=false and orgbr.organization_id=", num, " order by buc.bss_brnch_cont_id desc");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetTableForGridByBranchId(int bss_brnch_cont_id)
        {
            string str = string.Concat("select buc.org_branch_reg_id,buc.remarks Remarks,ori.organization_id,ori.organization_name Org_name,ademp.employee_id,ademp.employee_name Employee_name,orgbr.branch_unit_name Org_branch_name from bss_unit_branch_acc_control buc\r\n                            inner join org_registration_info ori on buc.organization_id=ori.organization_id\r\n                            inner join admn_employee ademp on buc.employee_id=ademp.employee_id\r\n                            inner join org_branch_reg_info orgbr on buc.org_branch_reg_id=orgbr.org_branch_reg_id where buc.bss_brnch_cont_id=", bss_brnch_cont_id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetTableForGridMultiBINSingleAdmin()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["MASTER_ORGANIZATION_ID"]);
            string str = string.Concat("select buc.bss_brnch_cont_id,buc.org_branch_reg_id Org_branch_reg_id,buc.remarks Remarks,ori.organization_name Org_name,ademp.employee_name Employee_name,orgbr.branch_unit_name Org_branch_name from bss_unit_branch_acc_control buc\r\n                            inner join org_registration_info ori on buc.organization_id=ori.organization_id\r\n                            inner join admn_employee ademp on buc.employee_id=ademp.employee_id\r\n                            inner join org_branch_reg_info orgbr on buc.org_branch_reg_id=orgbr.org_branch_reg_id where buc.is_deleted=false and ori.master_organization_id=", num, " order by buc.bss_brnch_cont_id desc");
            return this.DBUtil.GetDataTable(str);
        }

        public bool InsertApproverStageData(ArrayList arrDeailDAObranch)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAObranch.Count; i++)
            {
                Approver_Stage approverStage = new Approver_Stage();
                approverStage = (Approver_Stage)arrDeailDAObranch[i];
                Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('bss_brnch_cont_id_seq')"));
                object[] approverStageNo = new object[] { "insert into approver_stage_setting(approver_stage_no,organization_id, org_branch_id,employee_id,user_id_insert) values (", approverStage.ApproverStageNo, ",", approverStage.Organization_id, ",", approverStage.Org_branch_reg_id, ",", approverStage.Employee_id, ",'", approverStage.User_id_insert, "')" };
                arrayLists.Add(string.Concat(approverStageNo));
            }
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertBranchData(ArrayList arrDeailDAObranch)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAObranch.Count; i++)
            {
                Bss_Branch_ControlDAO bssBranchControlDAO = new Bss_Branch_ControlDAO();
                bssBranchControlDAO = (Bss_Branch_ControlDAO)arrDeailDAObranch[i];
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('bss_brnch_cont_id_seq')"));
                object[] organizationId = new object[] { "insert into bss_unit_branch_acc_control(bss_brnch_cont_id,organization_id, org_branch_reg_id,employee_id,remarks) values (", num, ",", bssBranchControlDAO.Organization_id, ",", bssBranchControlDAO.Org_branch_reg_id, ",", bssBranchControlDAO.Employee_id, ",'", bssBranchControlDAO.Remarks, "')" };
                arrayLists.Add(string.Concat(organizationId));
            }
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool UpdateBusinessControlAccess(Bss_Branch_ControlDAO objMDAO)
        {
            object[] organizationId = new object[] { "Update bss_unit_branch_acc_control set organization_id=", objMDAO.Organization_id, ", \r\n                    org_branch_reg_id=", objMDAO.Org_branch_reg_id, ",\r\n                    employee_id=", objMDAO.Employee_id, ",\r\n                    remarks='", objMDAO.Remarks, "'\r\n                 where bss_brnch_cont_id=", objMDAO.BSS_brnch_cont_id };
            string str = string.Concat(organizationId);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}