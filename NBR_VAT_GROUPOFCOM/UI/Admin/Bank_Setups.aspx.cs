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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class Bank_Setups : Page, IRequiresSessionState
    {
    

        private SetBankBLL objSBBLL = new SetBankBLL();

        private SetBankDAO objSBDAO = new SetBankDAO();

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

        public Bank_Setups()
        {
        }

        private bool bankValidation()
        {
            if (string.IsNullOrEmpty(this.txtBankName.Text.ToString()))
            {
                this.msgBox.AddMessage("Enter Bank Name", MsgBoxs.enmMessageType.Attention);
                this.txtBankName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtAddress.Text.ToString()))
            {
                this.msgBox.AddMessage("Enter Bank Address", MsgBoxs.enmMessageType.Attention);
                this.txtAddress.Focus();
                return false;
            }
            if (this.txtPhone.Text.Length > 0)
            {
                if (!this.txtPhone.Text.StartsWith("+880"))
                {
                    this.msgBox.AddMessage("You need to start with your phone no +880", MsgBoxs.enmMessageType.Error);
                    this.txtPhone.Focus();
                    return false;
                }
                if (this.txtPhone.Text.Length != 14)
                {
                    this.msgBox.AddMessage("You should insert a valid (11 digit) phone number after +88", MsgBoxs.enmMessageType.Error);
                    this.txtPhone.Focus();
                    return false;
                }
            }
            if (this.txtPhone2.Text.Length > 0)
            {
                if (!this.txtPhone2.Text.StartsWith("+880"))
                {
                    this.msgBox.AddMessage("You need to start with your phone no +880", MsgBoxs.enmMessageType.Error);
                    this.txtPhone2.Focus();
                    return false;
                }
                if (this.txtPhone2.Text.Length != 14)
                {
                    this.msgBox.AddMessage("You should insert a valid (11 digit) phone number after +88", MsgBoxs.enmMessageType.Error);
                    this.txtPhone2.Focus();
                    return false;
                }
            }
            return true;
        }

        protected void btnCancelToSaveInvoice(object sender, EventArgs e)
        {
            this.mpeYesNoModal.Hide();
        }

        protected void btnOkToReload(object sender, EventArgs e)
        {
            this.objSBDAO = this.insertBank(this.objSBDAO);
            if (!this.objSBBLL.enableDeletedBank(this.objSBDAO))
            {
                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                return;
            }
            this.mpeYesNoModal.Hide();
            this.clearFrom();
            this.msgBox.AddMessage("Bank Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SetBankDAO setBankDAO = new SetBankDAO();
            if (this.bankValidation())
            {
                setBankDAO = this.insertBank(setBankDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (this.objSBBLL.CheckBank(setBankDAO).Tables[0].Rows.Count > 0)
                    {
                        this.mpeYesNoModal.Show();
                        return;
                    }
                    if (!this.objSBBLL.InsertBank(setBankDAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.clearFrom();
                    this.msgBox.AddMessage("Bank Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                setBankDAO.BankID = Convert.ToInt16(this.dgvBank.SelectedDataKey["bank_id"]);
                Convert.ToInt16(this.dgvBank.SelectedDataKey["bank_id"]);
                if (this.objSBBLL.updateBank(setBankDAO))
                {
                    this.msgBox.AddMessage("Bank Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                    this.setAddMode();
                    this.clearFrom();
                    return;
                }
                this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.loadGridViewByBankId(Convert.ToInt32(this.drpBank.SelectedValue));
        }

        protected void btnShowBankList_Click(object sender, EventArgs e)
        {
            if (this.btnShowBankList.Text == "Show Bank List")
            {
                this.clearFrom();
                this.btnShowBankList.Text = "Hide Bank List";
                this.showDataInGridView();
                this.dgvBank.Visible = true;
                return;
            }
            if (this.btnShowBankList.Text == "Hide Bank List")
            {
                this.btnShowBankList.Text = "Show Bank List";
                this.dgvBank.Visible = false;
                this.setAddMode();
                this.clearFrom();
            }
        }

        private void clearFrom()
        {
            this.txtBankName.Text = "";
            this.txtBankCode.Text = "";
            this.txtShortName.Text = "";
            this.txtAddress.Text = "";
            this.txtPhone.Text = "";
            this.txtPhone2.Text = "";
            this.txtEmail.Text = "";
            this.txtUrl.Text = "";
            this.btnSave.Text = "Save";
            this.setAddMode();
            this.showDataInGridView();
        }

        protected void dgvBank_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvBank.PageIndex = e.NewPageIndex;
            this.showDataInGridView();
        }

        protected void dgvBank_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void dgvBank_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.objSBBLL = new SetBankBLL();
                int num = Convert.ToInt32(this.dgvBank.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objSBBLL.deleteBank(num))
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

        protected void dgvBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvBank.SelectedDataKey["bank_id"]);
            DataSet bank = this.objSBBLL.getBank(num);
            if (bank != null)
            {
                this.txtBankName.Text = bank.Tables[0].Rows[0]["bank_name"].ToString();
                this.txtShortName.Text = bank.Tables[0].Rows[0]["short_name"].ToString();
                this.txtBankCode.Text = bank.Tables[0].Rows[0]["bank_code"].ToString();
                this.txtAddress.Text = bank.Tables[0].Rows[0]["bank_address"].ToString();
                this.txtPhone.Text = bank.Tables[0].Rows[0]["phone_one"].ToString();
                this.txtPhone2.Text = bank.Tables[0].Rows[0]["phone_two"].ToString();
                this.txtEmail.Text = bank.Tables[0].Rows[0]["bank_email"].ToString();
                this.txtUrl.Text = bank.Tables[0].Rows[0]["web_address"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        private void GetBankInfo()
        {
            try
            {
                this.drpBank.Items.Clear();
                DataTable allBank = this.objSBBLL.GetAllBank();
                if (allBank != null && allBank.Rows.Count > 0)
                {
                    this.drpBank.DataSource = allBank;
                    this.drpBank.DataTextField = allBank.Columns["bank_name"].ToString();
                    this.drpBank.DataValueField = allBank.Columns["bank_id"].ToString();
                    this.drpBank.DataBind();
                }
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpBank.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "Bank_Setups.aspx", "GetBankInfo");
            }
        }

        private SetBankDAO insertBank(SetBankDAO objBankDAO)
        {
            objBankDAO.BankName = (!string.IsNullOrEmpty(this.txtBankName.Text.ToString()) ? this.txtBankName.Text.ToString() : "NA");
            objBankDAO.ShortName = (!string.IsNullOrEmpty(this.txtShortName.Text.ToString()) ? this.txtShortName.Text.ToString() : "NA");
            objBankDAO.BankCode = (!string.IsNullOrEmpty(this.txtBankCode.Text.ToString()) ? this.txtBankCode.Text.ToString() : "NA");
            objBankDAO.Phone1 = (!string.IsNullOrEmpty(this.txtPhone.Text.ToString()) ? this.txtPhone.Text.ToString() : "NA");
            objBankDAO.Phone2 = (!string.IsNullOrEmpty(this.txtPhone2.Text.ToString()) ? this.txtPhone2.Text.ToString() : "NA");
            objBankDAO.Email = (!string.IsNullOrEmpty(this.txtEmail.Text.ToString()) ? this.txtEmail.Text.ToString() : "NA");
            objBankDAO.Web = (!string.IsNullOrEmpty(this.txtUrl.Text.ToString()) ? this.txtUrl.Text.ToString() : "NA");
            objBankDAO.Address = (!string.IsNullOrEmpty(this.txtAddress.Text.ToString()) ? this.txtAddress.Text.ToString() : "NA");
            return objBankDAO;
        }

        private void loadGridViewByBankId(int bankId)
        {
            DataTable bank = this.objSBBLL.GetBank(bankId);
            this.dgvBank.DataSource = bank;
            this.dgvBank.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.GetBankInfo();
            }
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        private void showDataInGridView(DataSet ds)
        {
            this.dgvBank.DataSource = ds;
            this.dgvBank.DataBind();
        }

        public void showDataInGridView()
        {
            DataSet allBank = this.objSBBLL.getAllBank();
            this.dgvBank.DataSource = allBank;
            this.dgvBank.DataBind();
        }
    }
}