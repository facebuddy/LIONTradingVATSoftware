using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class ApproverSetups : Page, IRequiresSessionState
    {
      
        private AddUserBLL objuserBll = new AddUserBLL();

        private bss_branchBLL objbranch = new bss_branchBLL();

      

        public ApproverSetups()
        {
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.LoadGridApproverStage();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList arrayLists = new ArrayList();
            arrayLists = (ArrayList)this.Session["approver_stage"];
            if (!this.objbranch.InsertApproverStageData(arrayLists))
            {
                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                return;
            }
            this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
            this.gvApprover.DataSource = null;
            this.gvApprover.DataBind();
            this.Session["approver_stage"] = new ArrayList();
            this.drpApprove.SelectedValue = "0";
            this.drpUser.SelectedValue = "-99";
        }

        protected void gvApprover_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        private void LoadEmployee()
        {
            DataTable dataTable = new DataTable();
            dataTable = this.objbranch.GetEmployeebyBranchId();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                this.drpUser.DataSource = dataTable;
                this.drpUser.DataTextField = dataTable.Columns["employee_name"].ToString();
                this.drpUser.DataValueField = dataTable.Columns["employee_id"].ToString();
                this.drpUser.DataBind();
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpUser.Items.Insert(0, listItem);
        }

        private void LoadGridApproverStage()
        {
            Approver_Stage approverStage = new Approver_Stage();
            ArrayList item = (ArrayList)this.Session["approver_stage"] ?? new ArrayList();
            approverStage.Employee_name = this.drpUser.SelectedItem.ToString();
            approverStage.Employee_id = Convert.ToInt16(this.drpUser.SelectedValue.ToString());
            approverStage.Org_name = this.Session["ORGANIZATION_NAME"].ToString();
            approverStage.Organization_id = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
            approverStage.Org_branch_reg_id = Convert.ToInt16(this.Session["ORGBRANCHID"].ToString());
            approverStage.ApproverStage = this.drpApprove.SelectedItem.ToString();
            approverStage.ApproverStageNo = Convert.ToInt16(this.drpApprove.SelectedValue);
            approverStage.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
            item.Add(approverStage);
            this.Session["approver_stage"] = item;
            this.gvApprover.DataSource = item;
            this.gvApprover.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Session["approver_stage"] = new ArrayList();
                this.LoadEmployee();
            }
        }
    }
}