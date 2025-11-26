using AjaxControlToolkit;
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
    public partial class Add_Org_Bank_Accounts : Page, IRequiresSessionState
    {
        private OrgBankAccountBLL objOBABLL = new OrgBankAccountBLL();

        private OrgBankAccountDAO objOBADAO = new OrgBankAccountDAO();

      

        public Add_Org_Bank_Accounts()
        {
        }

        protected void btnCancelToSaveInvoice(object sender, EventArgs e)
        {
            this.mpeYesNoModal.Hide();
        }

        protected void btnOkToReload(object sender, EventArgs e)
        {
            this.objOBADAO = this.insertBankAccount(this.objOBADAO);
            if (!this.objOBABLL.enableDeletedOrgBankAccount(this.objOBADAO))
            {
                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                return;
            }
            this.mpeYesNoModal.Hide();
            this.showDataInGridView();
            this.clearFrom();
            this.msgBox.AddMessage("Bank Account Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                this.objOBADAO = this.insertBankAccount(this.objOBADAO);
                if (this.btnSave.Text == "Save")
                {
                    if (this.objOBABLL.CheckOrgBankAccount(this.objOBADAO).Tables[0].Rows.Count > 0)
                    {
                        this.mpeYesNoModal.Show();
                        return;
                    }
                    if (!this.objOBABLL.InsertOrgBankAccount(this.objOBADAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.showDataInGridView();
                    this.clearFrom();
                    this.msgBox.AddMessage("Bank Account Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                this.objOBADAO.intAccountId = Convert.ToInt32(this.dgvOrgBankAccount.SelectedDataKey["account_id"]);
                Convert.ToInt32(this.dgvOrgBankAccount.SelectedDataKey["account_id"]);
                if (this.objOBABLL.updateOrgBankAccount(this.objOBADAO))
                {
                    this.msgBox.AddMessage("Bank Account Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                    this.setAddMode();
                    this.clearFrom();
                    return;
                }
                this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void btnShowList_Click(object sender, EventArgs e)
        {
            if (this.btnShowList.Text == "Show Account List")
            {
                this.clearFrom();
                this.btnShowList.Text = "Hide Account List";
                this.showDataInGridView();
                this.dgvOrgBankAccount.Visible = true;
                return;
            }
            if (this.btnShowList.Text == "Hide Account List")
            {
                this.btnShowList.Text = "Show Account List";
                this.dgvOrgBankAccount.Visible = false;
                this.setAddMode();
                this.clearFrom();
            }
        }

        private void clearFrom()
        {
            this.btnSave.Text = "Save";
            this.setAddMode();
            this.txtAccountNo.Text = "";
            this.txtAccountName.Text = "";
            OrganizaitonInfo.fillAllOrganizaiton(this.ddlOrganization);
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.ddlOrganization.Items.Insert(0, listItem);
            BLL.Utility.fillAllBank(this.ddlBank);
            ListItem listItem1 = new ListItem("-- SELECT --", "-99");
            this.ddlBank.Items.Insert(0, listItem1);
            if (this.ddlBank.Items.Count > 0)
            {
                BLL.Utility.fillAllBankBranchByBankID(this.ddlBankBranch, Convert.ToInt32(this.ddlBank.SelectedValue.ToString()));
                ListItem listItem2 = new ListItem("-- SELECT --", "-99");
                this.ddlBankBranch.Items.Insert(0, listItem2);
            }
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.Utility.fillAllBankBranchByBankID(this.ddlBankBranch, Convert.ToInt32(this.ddlBank.SelectedValue.ToString()));
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.ddlBankBranch.Items.Insert(0, listItem);
        }

        protected void dgvOrgBankAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void dgvOrgBankAccount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton imageButton = control as ImageButton;
                        if (imageButton == null || !(imageButton.CommandName == "Delete"))
                        {
                            continue;
                        }
                        imageButton.OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
                    }
                }
            }
        }

        protected void dgvOrgBankAccount_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(this.dgvOrgBankAccount.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objOBABLL.deleteOrgBankAccount(num))
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

        protected void dgvOrgBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvOrgBankAccount.SelectedDataKey["account_id"]);
            DataSet allOrgBankAccountByAccountId = this.objOBABLL.getAllOrgBankAccountByAccountId(num);
            if (allOrgBankAccountByAccountId != null)
            {
                this.txtAccountNo.Text = allOrgBankAccountByAccountId.Tables[0].Rows[0]["account_no"].ToString();
                this.txtAccountName.Text = allOrgBankAccountByAccountId.Tables[0].Rows[0]["account_name"].ToString();
                this.ddlOrganization.SelectedValue = allOrgBankAccountByAccountId.Tables[0].Rows[0]["organization_id"].ToString();
                this.ddlBank.SelectedValue = allOrgBankAccountByAccountId.Tables[0].Rows[0]["bankId"].ToString();
                BLL.Utility.fillAllBankBranchByBankID(this.ddlBankBranch, Convert.ToInt32(this.ddlBank.SelectedValue.ToString()));
                this.ddlBankBranch.SelectedValue = allOrgBankAccountByAccountId.Tables[0].Rows[0]["bank_branch_id"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        private OrgBankAccountDAO insertBankAccount(OrgBankAccountDAO objOrgBankAccountDAO)
        {
            objOrgBankAccountDAO.intOrganizationId = Convert.ToInt32(this.ddlOrganization.SelectedValue.ToString());
            objOrgBankAccountDAO.intBankBranchId = Convert.ToInt32(this.ddlBankBranch.SelectedValue.ToString());
            objOrgBankAccountDAO.strAccountNo = BLL.Utility.ReplaceQuotes(this.txtAccountNo.Text.Trim());
            objOrgBankAccountDAO.strAccountName = BLL.Utility.ReplaceQuotes(this.txtAccountName.Text.Trim());
            return objOrgBankAccountDAO;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                OrganizaitonInfo.fillAllOrganizaiton(this.ddlOrganization);
                this.ddlOrganization.SelectedValue = this.Session["ORGANIZATION_ID"].ToString();
                BLL.Utility.fillAllBank(this.ddlBank);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.ddlBank.Items.Insert(0, listItem);
                if (this.ddlBank.Items.Count > 0)
                {
                    BLL.Utility.fillAllBankBranchByBankID(this.ddlBankBranch, Convert.ToInt32(this.ddlBank.SelectedValue.ToString()));
                    ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                    this.ddlBankBranch.Items.Insert(0, listItem1);
                }
                this.showDataInGridView();
            }
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        private void showDataInGridView(DataSet ds)
        {
            this.dgvOrgBankAccount.DataSource = ds;
            this.dgvOrgBankAccount.DataBind();
        }

        public void showDataInGridView()
        {
            DataSet allOrgBankAccount = this.objOBABLL.getAllOrgBankAccount();
            this.dgvOrgBankAccount.DataSource = allOrgBankAccount;
            this.dgvOrgBankAccount.DataBind();
        }

        private bool Validation()
        {
            if (this.ddlOrganization.SelectedValue.ToString() == "-99")
            {
                this.ddlOrganization.Focus();
                return false;
            }
            if (this.ddlBank.SelectedValue.ToString() == "-99")
            {
                this.ddlBank.Focus();
                return false;
            }
            if (this.ddlBankBranch.SelectedValue.ToString() == "-99")
            {
                this.ddlBankBranch.Focus();
                return false;
            }
            if (this.txtAccountNo.Text.Length >= 1)
            {
                return true;
            }
            this.txtAccountNo.Focus();
            return false;
        }
    }
}