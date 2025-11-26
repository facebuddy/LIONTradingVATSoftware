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
    public partial class Bank_Branch_Setups : Page, IRequiresSessionState
    {
        private SetBankBranchBLL objSBBBLL = new SetBankBranchBLL();

        private SetBankBranchDAO objSBBDAO = new SetBankBranchDAO();


     

        public Bank_Branch_Setups()
        {
        }

        protected void btnBranchList_Click(object sender, EventArgs e)
        {
            if (this.btnBranchList.Text == "Show Branch List")
            {
                this.clearFrom();
                this.btnBranchList.Text = "Hide Branch List";
                this.showDataInGridView();
                this.dgvBankBranch.Visible = true;
                return;
            }
            if (this.btnBranchList.Text == "Hide Branch List")
            {
                this.btnBranchList.Text = "Show Branch List";
                this.dgvBankBranch.Visible = false;
                this.setAddMode();
                this.clearFrom();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SetBankBranchDAO setBankBranchDAO = new SetBankBranchDAO();
            if (this.Validation())
            {
                setBankBranchDAO = this.insertBranch(setBankBranchDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.objSBBBLL.InsertBranch(setBankBranchDAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.clearFrom();
                    this.msgBox.AddMessage("Bank Branch Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                setBankBranchDAO.BranchId = Convert.ToInt16(this.dgvBankBranch.SelectedDataKey["branch_id"]);
                Convert.ToInt16(this.dgvBankBranch.SelectedDataKey["branch_id"]);
                if (this.objSBBBLL.updateBranch(setBankBranchDAO))
                {
                    this.msgBox.AddMessage("Bank Branch Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                    this.setAddMode();
                    this.clearFrom();
                    return;
                }
                this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
            }
        }

        private void clearFrom()
        {
            this.txtBranchName.Text = "";
            this.txtAddress.Text = "";
            this.txtPhone.Text = "";
            this.txtPhone2.Text = "";
            this.txtEmail.Text = "";
            Utility.fillAllBank(this.ddlBank);
            ListItem listItem = new ListItem("---SELECT---", "-99");
            this.ddlBank.Items.Insert(0, listItem);
            Utility.fillUpazillaNameDropdownList(this.ddlUpazila);
            if (this.ddlUpazila.Items.Count > 0)
            {
                Utility.fillUnionWardByUpazila(this.ddlUnionWard, Convert.ToInt32(this.ddlUpazila.SelectedItem.Value.ToString()));
            }
            this.btnSave.Text = "Save";
            this.setAddMode();
            this.showDataInGridView();
        }

        protected void ddlUpazila_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.fillUnionWardByUpazila(this.ddlUnionWard, Convert.ToInt32(this.ddlUpazila.SelectedItem.Value.ToString()));
        }

        protected void dgvBankBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvBankBranch.PageIndex = e.NewPageIndex;
            this.showDataInGridView();
        }

        protected void dgvBankBranch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.objSBBBLL = new SetBankBranchBLL();
                int num = Convert.ToInt32(this.dgvBankBranch.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objSBBBLL.deleteBank(num))
                {
                    this.msgBox.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.msgBox.AddMessage("Successfully Deleted.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void dgvBankBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvBankBranch.SelectedDataKey["branch_id"]);
            DataSet branch = this.objSBBBLL.getBranch(num);
            if (branch != null)
            {
                this.txtBranchName.Text = branch.Tables[0].Rows[0]["branch_name"].ToString();
                this.txtAddress.Text = branch.Tables[0].Rows[0]["branch_address"].ToString();
                this.txtPhone.Text = branch.Tables[0].Rows[0]["phone_one"].ToString();
                this.txtPhone2.Text = branch.Tables[0].Rows[0]["phone_two"].ToString();
                this.txtEmail.Text = branch.Tables[0].Rows[0]["branch_email"].ToString();
                Utility.fillAllBank(this.ddlBank);
                ListItem listItem = new ListItem("---SELECT---", "-99");
                this.ddlBank.Items.Insert(0, listItem);
                this.ddlBank.SelectedValue = branch.Tables[0].Rows[0]["bank_id"].ToString();
                Utility.fillUpazillaNameDropdownList(this.ddlUpazila);
                this.ddlUpazila.SelectedValue = branch.Tables[0].Rows[0]["upazila_id"].ToString();
                if (this.ddlUpazila.Items.Count > 0)
                {
                    Utility.fillUnionWardByUpazila(this.ddlUnionWard, Convert.ToInt32(this.ddlUpazila.SelectedItem.Value.ToString()));
                    this.ddlUnionWard.SelectedValue = branch.Tables[0].Rows[0]["union_id"].ToString();
                }
                this.btnSave.Text = "Update";
            }
        }

        private SetBankBranchDAO insertBranch(SetBankBranchDAO objBranchDAO)
        {
            objBranchDAO.BranchName = (!string.IsNullOrEmpty(this.txtBranchName.Text) ? this.txtBranchName.Text.Trim() : "NA");
            objBranchDAO.BankId = Convert.ToInt32(this.ddlBank.SelectedItem.Value.ToString());
            objBranchDAO.UpazilaId = Convert.ToInt32(this.ddlUpazila.SelectedItem.Value.ToString());
            objBranchDAO.UnionWardId = Convert.ToInt32(this.ddlUnionWard.SelectedItem.Value.ToString());
            objBranchDAO.Address = (!string.IsNullOrEmpty(this.txtAddress.Text) ? this.txtAddress.Text.Trim() : "NA");
            objBranchDAO.Phone = (!string.IsNullOrEmpty(this.txtPhone.Text) ? this.txtPhone.Text.Trim() : "NA");
            objBranchDAO.Phone2 = (!string.IsNullOrEmpty(this.txtPhone2.Text) ? this.txtPhone2.Text.Trim() : "NA");
            objBranchDAO.Email = (!string.IsNullOrEmpty(this.txtEmail.Text) ? this.txtEmail.Text.Trim() : "NA");
            objBranchDAO.BranchCode = (!string.IsNullOrEmpty(this.txtBranchCode.Text) ? this.txtBranchCode.Text.Trim() : "NA");
            return objBranchDAO;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Utility.fillAllBank(this.ddlBank);
                ListItem listItem = new ListItem("---SELECT---", "-99");
                this.ddlBank.Items.Insert(0, listItem);
                Utility.fillUpazillaNameDropdownList(this.ddlUpazila);
                if (this.ddlUpazila.Items.Count > 0)
                {
                    Utility.fillUnionWardByUpazila(this.ddlUnionWard, Convert.ToInt32(this.ddlUpazila.SelectedItem.Value.ToString()));
                }
            }
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        private void showDataInGridView(DataSet ds)
        {
            this.dgvBankBranch.DataSource = ds;
            this.dgvBankBranch.DataBind();
        }

        public void showDataInGridView()
        {
            DataSet allBranch = this.objSBBBLL.getAllBranch();
            this.dgvBankBranch.DataSource = allBranch;
            this.dgvBankBranch.DataBind();
        }

        private bool Validation()
        {
            if (this.txtBranchName.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Enter Branch Name", MsgBoxs.enmMessageType.Attention);
                this.txtBranchName.Focus();
                return false;
            }
            if (this.ddlBank.SelectedValue.ToString() == "-99")
            {
                this.msgBox.AddMessage("Select Bank", MsgBoxs.enmMessageType.Attention);
                this.ddlBank.Focus();
                return false;
            }
            if (this.ddlUpazila.SelectedValue.ToString() == "0")
            {
                this.msgBox.AddMessage("Select Upazila", MsgBoxs.enmMessageType.Attention);
                this.ddlUpazila.Focus();
                return false;
            }
            if (this.ddlUnionWard.SelectedValue.ToString() == "0")
            {
                this.msgBox.AddMessage("Select Union/Word", MsgBoxs.enmMessageType.Attention);
                this.ddlUnionWard.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtAddress.Text))
            {
                this.msgBox.AddMessage("Enetr Branch Address", MsgBoxs.enmMessageType.Attention);
                this.txtAddress.Focus();
                return false;
            }
            if (this.txtBranchCode.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Enter Branch Code", MsgBoxs.enmMessageType.Attention);
                this.txtBranchCode.Focus();
                return false;
            }
            if (this.btnSave.Text == "Save")
            {
                int num = Convert.ToInt32(this.ddlBank.SelectedValue);
                int num1 = Convert.ToInt32(this.ddlUnionWard.SelectedValue);
                DataTable dataTable = this.objSBBBLL.dtGetBankBranchByBankandUnionId(num, num1);
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (this.txtBranchName.Text == dataTable.Rows[i]["branch_name"].ToString())
                        {
                            this.msgBox.AddMessage("Duplicate Branch Name", MsgBoxs.enmMessageType.Attention);
                            this.txtBranchName.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}