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
    public partial class Vat_Division_News : Page, IRequiresSessionState
    {
        private vatDivisiojnDAO objVatDivisionDAO = new vatDivisiojnDAO();

        private vatDivisionBLL objVatDivisionBLL = new vatDivisionBLL();

     

        public Vat_Division_News()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.objVatDivisionDAO = new vatDivisiojnDAO();
            if (this.DivisionValidation())
            {
                this.objVatDivisionDAO = this.insertDivision(this.objVatDivisionDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.objVatDivisionBLL.InsertDivision(this.objVatDivisionDAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.clearFrom();
                        this.msgBox.AddMessage("Commissionerate Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    }
                }
                if (this.btnSave.Text == "Update")
                {
                    int num = Convert.ToInt16(this.dgvVatDivision.SelectedDataKey["division_id"]);
                    if (this.objVatDivisionBLL.UpdateDivision(this.objVatDivisionDAO, num))
                    {
                        this.clearFrom();
                        this.msgBox.AddMessage("Commissionerate Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        return;
                    }
                    this.msgBox.AddMessage("Successfully Updated.", MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShowDivisionList_Click(object sender, EventArgs e)
        {
            if (this.btnShowDivisionList.Text != "Show Division List")
            {
                this.dgvVatDivision.Visible = false;
                this.btnShowDivisionList.Text = "Show Division List";
                this.clearFrom();
                return;
            }
            this.dgvVatDivision.SelectedIndex = -1;
            this.dgvVatDivision.Visible = true;
            this.btnShowDivisionList.Text = "Hide Division List";
            this.RefreshGridView();
        }

        private void clearFrom()
        {
            Util.fillUpazillaNameDropdownList(this.drpUpazillaName);
            OrganizaitonInfo.fillAllVATCommissionerate(this.drpCommName);
            this.txtDivisionName.Text = "";
            this.txtDivisionAddress.Text = "";
            this.txtDivisionCode.Text = "";
            this.txtDivisionPhone.Text = "";
            this.drpUpazillaName.SelectedValue = "0";
            this.drpUnionWardName.SelectedValue = "0";
            this.btnSave.Text = "Save";
            this.setAddMode();
            this.RefreshGridView();
        }

        protected void dgvVatDivision_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.objVatDivisionBLL = new vatDivisionBLL();
                int num = Convert.ToInt32(this.dgvVatDivision.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objVatDivisionBLL.deleteDivision(num))
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

        protected void dgvVatDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvVatDivision.SelectedDataKey["division_id"]);
            DataSet division = this.objVatDivisionBLL.getDivision(num);
            if (division != null)
            {
                OrganizaitonInfo.fillAllVATCommissionerate(this.drpCommName);
                this.drpCommName.SelectedValue = division.Tables[0].Rows[0]["comm_id"].ToString();
                this.txtDivisionName.Text = division.Tables[0].Rows[0]["division_name"].ToString();
                this.txtDivisionAddress.Text = division.Tables[0].Rows[0]["address"].ToString();
                this.txtDivisionCode.Text = division.Tables[0].Rows[0]["division_code"].ToString();
                this.txtDivisionPhone.Text = division.Tables[0].Rows[0]["phone_no"].ToString();
                this.drpUpazillaName.SelectedValue = division.Tables[0].Rows[0]["upazila_id"].ToString();
                int num1 = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
                Util.fillUnionWardByUpazila(this.drpUnionWardName, num1);
                this.drpUnionWardName.SelectedValue = division.Tables[0].Rows[0]["union_ward_id"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        private bool DivisionValidation()
        {
            if (this.drpCommName.SelectedValue == 0.ToString())
            {
                this.drpCommName.Focus();
                return false;
            }
            if (this.txtDivisionName.Text.Trim().Length < 1)
            {
                this.txtDivisionName.Focus();
                return false;
            }
            if (this.txtDivisionAddress.Text.Trim().Length < 1)
            {
                this.txtDivisionAddress.Focus();
                return false;
            }
            if (this.txtDivisionCode.Text.Trim().Length < 1)
            {
                this.txtDivisionCode.Focus();
                return false;
            }
            if (this.txtDivisionPhone.Text.Trim().Length >= 1)
            {
                return true;
            }
            this.txtDivisionPhone.Focus();
            return false;
        }

        protected void drpUnionWardName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpUpazillaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
            Util.fillUnionWardByUpazila(this.drpUnionWardName, num);
        }

        private vatDivisiojnDAO insertDivision(vatDivisiojnDAO objVatDivisionDAO)
        {
            short num;
            short num1;
            objVatDivisionDAO.ComId = Convert.ToInt16(this.drpCommName.SelectedValue);
            objVatDivisionDAO.DivisionName = this.txtDivisionName.Text.Trim();
            objVatDivisionDAO.DivisionCode = this.txtDivisionCode.Text.Trim();
            objVatDivisionDAO.Address = this.txtDivisionAddress.Text.Trim();
            objVatDivisionDAO.PhoneNo = this.txtDivisionPhone.Text.Trim();
            vatDivisiojnDAO _vatDivisiojnDAO = objVatDivisionDAO;
            if (Convert.ToInt16(this.drpUpazillaName.SelectedValue) > 0)
            {
                num = Convert.ToInt16(this.drpUpazillaName.SelectedValue);
            }
            else
            {
                num = 0;
            }
            _vatDivisiojnDAO.UpazillaId = num;
            vatDivisiojnDAO _vatDivisiojnDAO1 = objVatDivisionDAO;
            if (!string.IsNullOrEmpty(this.drpUnionWardName.SelectedValue))
            {
                num1 = Convert.ToInt16(this.drpUnionWardName.SelectedValue);
            }
            else
            {
                num1 = 0;
            }
            _vatDivisiojnDAO1.UnionWardId = num1;
            return objVatDivisionDAO;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Util.fillUpazillaNameDropdownList(this.drpUpazillaName);
                OrganizaitonInfo.fillAllVATCommissionerate(this.drpCommName);
            }
        }

        private void RefreshGridView()
        {
            DataTable divisionDataForGv = this.objVatDivisionBLL.getDivisionDataForGv();
            this.dgvVatDivision.DataSource = divisionDataForGv;
            this.dgvVatDivision.DataBind();
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        private vatDivisiojnDAO UpdateDivision(vatDivisiojnDAO objVatDivisionDAO)
        {
            objVatDivisionDAO.ComId = Convert.ToInt16(this.drpCommName.SelectedValue);
            objVatDivisionDAO.DivisionName = this.txtDivisionName.Text.Trim();
            objVatDivisionDAO.DivisionCode = this.txtDivisionCode.Text.Trim();
            objVatDivisionDAO.Address = this.txtDivisionAddress.Text.Trim();
            objVatDivisionDAO.PhoneNo = this.txtDivisionPhone.Text.Trim();
            objVatDivisionDAO.UpazillaId = Convert.ToInt16(this.drpUpazillaName.SelectedValue);
            objVatDivisionDAO.UnionWardId = Convert.ToInt16(this.drpUnionWardName.SelectedValue);
            return objVatDivisionDAO;
        }
    }
}