using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class Commissionerates : System.Web.UI.Page
    {
        private vatcommissionerateDAO objVatCommissionerateDAO = new vatcommissionerateDAO();

        private vatcommissionerateBLL objVatCommissionerateBLL = new vatcommissionerateBLL();

      

        public Commissionerates()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.objVatCommissionerateDAO = new vatcommissionerateDAO();
            if (this.CommissionerateValidation())
            {
                this.objVatCommissionerateDAO = this.insertCommissionerate(this.objVatCommissionerateDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.objVatCommissionerateBLL.InsertCommissionerate(this.objVatCommissionerateDAO))
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
                    int num = Convert.ToInt16(this.dgvVatCommissonerate.SelectedDataKey["comm_id"]);
                    if (this.objVatCommissionerateBLL.UpdateCommissionerate(this.objVatCommissionerateDAO, num))
                    {
                        this.clearFrom();
                        this.msgBox.AddMessage("Commissionerate Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        return;
                    }
                    this.msgBox.AddMessage("Successfully Updated.", MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShowCommissionerateList_Click(object sender, EventArgs e)
        {
            if (this.btnShowCommissionerateList.Text != "Show List")
            {
                this.dgvVatCommissonerate.Visible = false;
                this.btnShowCommissionerateList.Text = "Show List";
                this.clearFrom();
                return;
            }
            this.dgvVatCommissonerate.SelectedIndex = -1;
            this.dgvVatCommissonerate.Visible = true;
            this.btnShowCommissionerateList.Text = "Hide List";
            this.RefreshGridView();
        }

        private void clearFrom()
        {
            this.txtCommName.Text = "";
            this.txtComAdd.Text = "";
            this.txtCommCode.Text = "";
            this.txtComPhone.Text = "";
            this.drpUpazillaName.SelectedValue = "0";
            this.drpUnionWardName.SelectedValue = "0";
            this.drpThana.SelectedValue = "0";
            this.btnSave.Text = "Save";
            this.setAddMode();
            this.RefreshGridView();
        }

        private bool CommissionerateValidation()
        {
            if (this.txtCommName.Text.Trim().Length < 1)
            {
                this.txtCommName.Focus();
                return false;
            }
            if (this.txtCommCode.Text.Trim().Length < 1)
            {
                this.txtCommCode.Focus();
                return false;
            }
            if (this.txtComAdd.Text.Trim().Length < 1)
            {
                this.txtComAdd.Focus();
                return false;
            }
            if (this.btnSave.Text == "Save")
            {
                if (this.objVatCommissionerateBLL.GetAllCommName(this.txtCommName.Text.ToString()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Commissionerate Name already exist in the system.", MsgBoxs.enmMessageType.Info);
                    this.txtCommName.Focus();
                    return false;
                }
                if (this.objVatCommissionerateBLL.GetAllCommName(this.txtCommCode.Text.ToString()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Commissionerate Code already exist in the system.", MsgBoxs.enmMessageType.Info);
                    this.txtCommCode.Focus();
                    return false;
                }
            }
            return true;
        }

        protected void dgvVatCommissonerate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.objVatCommissionerateBLL = new vatcommissionerateBLL();
                int num = Convert.ToInt32(this.dgvVatCommissonerate.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objVatCommissionerateBLL.deleteCommissionerate(num))
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

        protected void dgvVatCommissonerate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvVatCommissonerate.SelectedDataKey["comm_id"]);
            DataSet commissionerate = this.objVatCommissionerateBLL.getCommissionerate(num);
            if (commissionerate != null && commissionerate.Tables.Count > 0)
            {
                this.txtCommName.Text = commissionerate.Tables[0].Rows[0]["comm_name"].ToString();
                this.txtComAdd.Text = commissionerate.Tables[0].Rows[0]["address"].ToString();
                this.txtCommCode.Text = commissionerate.Tables[0].Rows[0]["comm_code"].ToString();
                this.txtComPhone.Text = commissionerate.Tables[0].Rows[0]["phone_no"].ToString();
                if (commissionerate.Tables[0].Rows[0]["upazila_id"].ToString() != "")
                {
                    this.drpUpazillaName.SelectedValue = commissionerate.Tables[0].Rows[0]["upazila_id"].ToString();
                }
                else
                {
                    this.drpUpazillaName.SelectedValue = "0";
                }
                int num1 = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
                Util.fillUnionWardByUpazila(this.drpUnionWardName, num1);
                if (commissionerate.Tables[0].Rows[0]["union_ward_id"].ToString() != "")
                {
                    this.drpUnionWardName.SelectedValue = commissionerate.Tables[0].Rows[0]["union_ward_id"].ToString();
                }
                else
                {
                    this.drpUnionWardName.SelectedValue = "0";
                }
                int num2 = Convert.ToInt32(this.drpUnionWardName.SelectedItem.Value);
                Util.fillPoliceStationByUnionward(this.drpThana, num2);
                if (commissionerate.Tables[0].Rows[0]["police_station_id"].ToString() != "")
                {
                    this.drpThana.SelectedValue = commissionerate.Tables[0].Rows[0]["police_station_id"].ToString();
                }
                else
                {
                    this.drpThana.SelectedValue = "0";
                }
                this.btnSave.Text = "Update";
            }
        }

        protected void drpUnionWardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpUnionWardName.SelectedItem.Value);
            Util.fillPoliceStationByUnionward(this.drpThana, num);
        }

        protected void drpUpazillaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
            Util.fillUnionWardByUpazila(this.drpUnionWardName, num);
        }

        private vatcommissionerateDAO insertCommissionerate(vatcommissionerateDAO objvatcommissionerateDAO)
        {
            short num;
            short num1;
            short num2;
            objvatcommissionerateDAO.ComName = this.txtCommName.Text.Trim();
            this.objVatCommissionerateDAO.ComCode = this.txtCommCode.Text.Trim();
            objvatcommissionerateDAO.Address = this.txtComAdd.Text.Trim();
            objvatcommissionerateDAO.PhoneNo = this.txtComPhone.Text.Trim();
            vatcommissionerateDAO _vatcommissionerateDAO = objvatcommissionerateDAO;
            if (Convert.ToInt16(this.drpUpazillaName.SelectedValue) > 0)
            {
                num = Convert.ToInt16(this.drpUpazillaName.SelectedValue);
            }
            else
            {
                num = 0;
            }
            _vatcommissionerateDAO.UpazillaId = num;
            vatcommissionerateDAO _vatcommissionerateDAO1 = objvatcommissionerateDAO;
            if (!string.IsNullOrEmpty(this.drpUnionWardName.SelectedValue))
            {
                num1 = Convert.ToInt16(this.drpUnionWardName.SelectedValue);
            }
            else
            {
                num1 = 0;
            }
            _vatcommissionerateDAO1.UnionWardId = num1;
            vatcommissionerateDAO _vatcommissionerateDAO2 = objvatcommissionerateDAO;
            if (!string.IsNullOrEmpty(this.drpThana.SelectedValue))
            {
                num2 = Convert.ToInt16(this.drpThana.SelectedValue);
            }
            else
            {
                num2 = 0;
            }
            _vatcommissionerateDAO2.PoliceStationId = num2;
            return objvatcommissionerateDAO;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Util.fillUpazillaNameDropdownList(this.drpUpazillaName);
            }
        }

        private void RefreshGridView()
        {
            DataTable commissionerateDataForGv = this.objVatCommissionerateBLL.getCommissionerateDataForGv();
            this.dgvVatCommissonerate.DataSource = commissionerateDataForGv;
            this.dgvVatCommissonerate.DataBind();
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }
    }
}