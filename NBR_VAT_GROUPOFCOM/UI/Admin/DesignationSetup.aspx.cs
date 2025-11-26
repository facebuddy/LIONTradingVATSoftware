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
    public partial class DesignationSetup : Page, IRequiresSessionState
    {
        private Set_DesignationDao set_designationDao = new Set_DesignationDao();

        private Set_DesignationBLL set_designationBLL = new Set_DesignationBLL();




        public DesignationSetup()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.btnShow.Text = "Show List";
            this.btnSave.Text = "Save";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validations())
            {
                this.set_designationDao = new Set_DesignationDao();
                this.set_designationDao = this.insertDesignation(this.set_designationDao);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.set_designationBLL.InsertDesignation(this.set_designationDao))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.ClearForm();
                        this.msgBox.AddMessage("Designation Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.RefreshGridView();
                    }
                }
                if (this.btnSave.Text == "Update")
                {
                    int num = Convert.ToInt16(this.dgvDesignation.SelectedDataKey["designation_id"]);
                    if (this.set_designationBLL.UpdateDesignation(this.set_designationDao, num))
                    {
                        this.ClearForm();
                        this.msgBox.AddMessage("Designation Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        this.RefreshGridView();
                        this.btnSave.Text = "Save";
                        return;
                    }
                    this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (this.btnShow.Text != "Show List")
            {
                this.dgvDesignation.Visible = false;
                this.btnShow.Text = "Show List";
                this.ClearForm();
                return;
            }
            this.dgvDesignation.SelectedIndex = -1;
            this.dgvDesignation.Visible = true;
            this.btnShow.Text = "Hide List";
            this.RefreshGridView();
        }

        private void ClearForm()
        {
            this.ddlDepartment.SelectedValue = "-1";
            this.txtDesignationName.Text = string.Empty;
            this.txtDesignationShortName.Text = string.Empty;
            this.dgvDesignation.DataSource = null;
            this.dgvDesignation.DataBind();
            this.dgvDesignation.SelectedIndex = -1;
        }

        protected void dgvDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvDesignation.PageIndex = e.NewPageIndex;
            this.dgvDesignation.DataBind();
            this.RefreshGridView();
        }

        protected void dgvDesignation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.set_designationBLL = new Set_DesignationBLL();
                int num = Convert.ToInt32(this.dgvDesignation.DataKeys[e.RowIndex].Value.ToString());
                if (!this.set_designationBLL.deleteDesignation(num))
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

        protected void dgvDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(this.dgvDesignation.SelectedDataKey["designation_id"]);
            DataSet designation = this.set_designationBLL.getDesignation(num);
            if (designation != null)
            {
                this.txtDesignationName.Text = designation.Tables[0].Rows[0]["designation_name"].ToString().Trim();
                this.txtDesignationShortName.Text = designation.Tables[0].Rows[0]["designation_short_name"].ToString().Trim();
                this.ddlDepartment.SelectedValue = (Convert.ToInt16(designation.Tables[0].Rows[0]["department_id"]) > 0 ? designation.Tables[0].Rows[0]["department_id"].ToString() : "1");
                this.btnSave.Text = "Update";
            }
        }

        private Set_DesignationDao insertDesignation(Set_DesignationDao objDesignation)
        {
            short num;
            objDesignation.Organization_id = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            Set_DesignationDao setDesignationDao = objDesignation;
            if (Convert.ToInt16(this.ddlDepartment.SelectedValue) > 0)
            {
                num = Convert.ToInt16(this.ddlDepartment.SelectedValue);
            }
            else
            {
                num = 0;
            }
            setDesignationDao.DepartmentID = num;
            objDesignation.Designation_name = this.txtDesignationName.Text.ToString().Trim();
            objDesignation.Designation_short_name = this.txtDesignationShortName.Text.ToString().Trim();
            objDesignation.Is_deleted = false;
            objDesignation.Date = DateTime.Now;
            return objDesignation;
        }

        private void LoadDepartment()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.set_designationBLL.GetDepartment();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.ddlDepartment.DataSource = dataTable;
                    this.ddlDepartment.DataTextField = dataTable.Columns["department_name"].ToString();
                    this.ddlDepartment.DataValueField = dataTable.Columns["department_id"].ToString();
                    this.ddlDepartment.DataBind();
                }
                this.ddlDepartment.Items.Insert(0, new ListItem("---SELECT---", "-1"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.LoadDepartment();
            }
        }

        private void RefreshGridView()
        {
            DataTable designationDataForGv = this.set_designationBLL.getDesignationDataForGv();
            this.dgvDesignation.DataSource = designationDataForGv;
            this.dgvDesignation.DataBind();
        }

        private bool Validations()
        {
            if (this.txtDesignationName.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please fill Designation Name.", MsgBoxs.enmMessageType.Info);
                this.txtDesignationName.Focus();
                return false;
            }
            if (this.txtDesignationShortName.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please fill Designation Short Name.", MsgBoxs.enmMessageType.Info);
                this.txtDesignationShortName.Focus();
                return false;
            }
            if (this.ddlDepartment.SelectedValue == "-1")
            {
                this.msgBox.AddMessage("Please Select Department", MsgBoxs.enmMessageType.Info);
                this.ddlDepartment.Focus();
                return false;
            }
            if (this.btnSave.Text == "Update")
            {
                int num = Convert.ToInt16(this.dgvDesignation.SelectedDataKey["designation_id"]);
                if (this.set_designationBLL.IsExistDesignationNameForUpdate(this.txtDesignationName.Text.ToUpper().ToString().Trim(), num).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Designation Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
                if (this.set_designationBLL.IsExistDesignationShortNameForUpdate(this.txtDesignationShortName.Text.ToUpper().ToString().Trim(), num).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Designation Short Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
            }
            if (this.btnSave.Text == "Save")
            {
                if (this.set_designationBLL.IsExistDesignationName(this.txtDesignationName.Text.ToUpper().ToString().Trim()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Designation Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
                if (this.set_designationBLL.IsExistDesignationShortName(this.txtDesignationShortName.Text.ToUpper().ToString().Trim()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Same Designation Short Name already exist.", MsgBoxs.enmMessageType.Info);
                    return false;
                }
            }
            return true;
        }
    }
}