using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class DepartmentSetup : Page, IRequiresSessionState
    {

        private Set_DepartmentDao set_departmentDao = new Set_DepartmentDao();

        private Set_DepartmentBLL set_departmentBLL = new Set_DepartmentBLL();

    

        protected global_asax ApplicationInstance
        {
            get
            {
                return (global_asax)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public DepartmentSetup()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.btnShowCommissionerateList.Text = "Show List";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validations())
            {
                this.set_departmentDao = new Set_DepartmentDao();
                this.set_departmentDao = this.insertDepartment(this.set_departmentDao);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.set_departmentBLL.InsertDepartment(this.set_departmentDao))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.ClearForm();
                        this.msgBox.AddMessage("Department Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.RefreshGridView();
                    }
                }
                if (this.btnSave.Text == "Update")
                {
                    int num = Convert.ToInt16(this.dgvDepartment.SelectedDataKey["department_id"]);
                    if (this.set_departmentBLL.UpdateDepartment(this.set_departmentDao, num))
                    {
                        this.ClearForm();
                        this.msgBox.AddMessage("Department Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        this.RefreshGridView();
                        this.btnSave.Text = "Save";
                        return;
                    }
                    this.msgBox.AddMessage("Fail to Update.",MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShowCommissionerateList_Click(object sender, EventArgs e)
        {
            if (this.btnShowCommissionerateList.Text != "Show List")
            {
                this.dgvDepartment.Visible = false;
                this.btnShowCommissionerateList.Text = "Show List";
                this.ClearForm();
                return;
            }
            this.dgvDepartment.SelectedIndex = -1;
            this.dgvDepartment.Visible = true;
            this.btnShowCommissionerateList.Text = "Hide List";
            this.RefreshGridView();
        }

        private void ClearForm()
        {
            this.txtDepartmentName.Text = string.Empty;
            this.txtShortName.Text = string.Empty;
            this.dgvDepartment.DataSource = null;
            this.dgvDepartment.DataBind();
            this.dgvDepartment.SelectedIndex = -1;
        }

        protected void dgvDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvDepartment.PageIndex = e.NewPageIndex;
            this.dgvDepartment.DataBind();
            this.RefreshGridView();
        }

        protected void dgvDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.set_departmentBLL = new Set_DepartmentBLL();
                int num = Convert.ToInt32(this.dgvDepartment.DataKeys[e.RowIndex].Value.ToString());
                if (!this.set_departmentBLL.deleteDesignation(num))
                {
                    this.msgBox.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.msgBox.AddMessage("Successfully Deleted.", MsgBoxs.enmMessageType.Success);
                    this.RefreshGridView();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void dgvDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(this.dgvDepartment.SelectedDataKey["department_id"]);
            DataSet designation = this.set_departmentBLL.getDesignation(num);
            if (designation != null)
            {
                this.txtDepartmentName.Text = designation.Tables[0].Rows[0]["department_name"].ToString().Trim();
                this.txtShortName.Text = designation.Tables[0].Rows[0]["department_short_name"].ToString().Trim();
                this.btnSave.Text = "Update";
            }
        }

        private Set_DepartmentDao insertDepartment(Set_DepartmentDao objDepartmentDAO)
        {
            objDepartmentDAO.Organization_id = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            objDepartmentDAO.Department_name = this.txtDepartmentName.Text.ToString();
            objDepartmentDAO.Department_short_name = this.txtShortName.Text.ToString();
            objDepartmentDAO.Is_deleted = false;
            objDepartmentDAO.Date_insert = DateTime.Now.ToString();
            return objDepartmentDAO;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
        }

        private void RefreshGridView()
        {
            DataTable departmentDataForGv = this.set_departmentBLL.getDepartmentDataForGv();
            this.dgvDepartment.DataSource = departmentDataForGv;
            this.dgvDepartment.DataBind();
        }

        private bool Validations()
        {
            if (this.txtDepartmentName.Text.Length == 0)
            {
                this.txtDepartmentName.Focus();
                this.msgBox.AddMessage("Please fill Department Name.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.txtShortName.Text.Length == 0)
            {
                this.txtShortName.Focus();
                this.msgBox.AddMessage("Please fill Department Short Name.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.btnSave.Text == "Update")
            {
                int num = Convert.ToInt16(this.dgvDepartment.SelectedDataKey["department_id"]);
                if (this.set_departmentBLL.IsExistDepartmentNameForUpdate(this.txtDepartmentName.Text.ToUpper().ToString(), num).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Department Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
                if (this.set_departmentBLL.IsExistDepartmentShortNameForUpdate(this.txtShortName.Text.ToUpper().ToString(), num).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Department Short Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
            }
            if (this.btnSave.Text == "Save")
            {
                if (this.set_departmentBLL.IsExistDepartmentName(this.txtDepartmentName.Text.ToUpper().ToString()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Department Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
                if (this.set_departmentBLL.IsExistDepartmentShortName(this.txtShortName.Text.ToUpper().ToString()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Department Short Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
            }
            return true;
        }

    }
}