using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class ClosingVatSd : Page, IRequiresSessionState
    {


       


        private Set_DesignationDao set_designationDao = new Set_DesignationDao();

        private Set_DesignationBLL set_designationBLL = new Set_DesignationBLL();

        private Set_VatSdClosingDao set_VatSdClosingDao = new Set_VatSdClosingDao();

        private Set_VatSdClosingBLL set_VatSdClosingBLL = new Set_VatSdClosingBLL();


      

        public ClosingVatSd()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.btnShow.Text = "Show List";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validations())
            {
                this.set_VatSdClosingDao = new Set_VatSdClosingDao();
                this.set_VatSdClosingDao = this.insertVatSdClosing(this.set_VatSdClosingDao);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.set_VatSdClosingBLL.InsertVatSdClosing(this.set_VatSdClosingDao))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.ClearForm();
                        this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.RefreshGridView();
                    }
                }
                if (this.btnSave.Text == "Update")
                {
                    int num = Convert.ToInt16(this.gvvatsdClosing.SelectedDataKey["vat_sd_closing_id"]);
                    if (this.set_VatSdClosingBLL.UpdateVatSdClosing(this.set_VatSdClosingDao, num))
                    {
                        this.ClearForm();
                        this.msgBox.AddMessage("Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
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
            try
            {
                if (this.btnShow.Text != "Show List")
                {
                    this.gvvatsdClosing.Visible = false;
                    this.btnShow.Text = "Show List";
                    this.ClearForm();
                }
                else
                {
                    this.gvvatsdClosing.SelectedIndex = -1;
                    this.gvvatsdClosing.Visible = true;
                    this.btnShow.Text = "Hide List";
                    this.RefreshGridView();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void ClearForm()
        {
            try
            {
                this.drpType.SelectedIndex = -1;
                this.txtAdjustPct.Text = string.Empty;
                this.txtClosingBalance.Text = string.Empty;
                this.txtAdjustAmount.Text = string.Empty;
                this.txtRemarks.Text = string.Empty;
                this.txtClosingDate.Text = string.Empty;
                this.gvvatsdClosing.DataSource = null;
                this.gvvatsdClosing.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void gvvatsdClosing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvvatsdClosing.PageIndex = e.NewPageIndex;
            this.gvvatsdClosing.DataBind();
            this.RefreshGridView();
        }

        protected void gvvatsdClosing_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void gvvatsdClosing_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt16(this.gvvatsdClosing.SelectedDataKey["vat_sd_closing_id"]);
                DataSet vatSdClosing = this.set_VatSdClosingBLL.getVatSdClosing(num);
                if (vatSdClosing != null)
                {
                    this.drpType.SelectedValue = vatSdClosing.Tables[0].Rows[0]["type_closing"].ToString().Trim();
                    this.txtClosingBalance.Text = vatSdClosing.Tables[0].Rows[0]["closing_balance"].ToString().Trim();
                    this.txtAdjustAmount.Text = vatSdClosing.Tables[0].Rows[0]["adjust_amount"].ToString().Trim();
                    this.txtRemarks.Text = vatSdClosing.Tables[0].Rows[0]["remarks"].ToString().Trim();
                    this.txtClosingDate.Text = vatSdClosing.Tables[0].Rows[0]["date_closing"].ToString().Trim();
                    this.txtAdjustPct.Text = vatSdClosing.Tables[0].Rows[0]["adjust_pct"].ToString().Trim();
                    this.btnSave.Text = "Update";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private Set_VatSdClosingDao insertVatSdClosing(Set_VatSdClosingDao objVatSdClosing)
        {
            Set_VatSdClosingDao setVatSdClosingDao;
            try
            {
                if (this.Validations())
                {
                    objVatSdClosing.typeClosing = this.drpType.SelectedValue.Trim();
                    objVatSdClosing.closingBalance = (!string.IsNullOrEmpty(this.txtClosingBalance.Text) ? Convert.ToDecimal(this.txtClosingBalance.Text.Trim()) : new decimal(0));
                    objVatSdClosing.adjustAmount = (!string.IsNullOrEmpty(this.txtAdjustAmount.Text) ? Convert.ToDecimal(this.txtAdjustAmount.Text.Trim()) : new decimal(0));
                    objVatSdClosing.Remarks = (!string.IsNullOrEmpty(this.txtRemarks.Text) ? this.txtRemarks.Text.Trim() : "");
                    objVatSdClosing.Is_deleted = false;
                    objVatSdClosing.Date_closing = DateTime.ParseExact(this.txtClosingDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objVatSdClosing.adjustPct = (!string.IsNullOrEmpty(this.txtAdjustPct.Text) ? Convert.ToDecimal(this.txtAdjustPct.Text.Trim()) : new decimal(0));
                }
                setVatSdClosingDao = objVatSdClosing;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return setVatSdClosingDao;
        }

        private void LoadDepartment()
        {
            DataTable dataTable = new DataTable();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            bool isPostBack = base.IsPostBack;
        }

        private void RefreshGridView()
        {
            try
            {
                DataTable vatSdClosingDataForGv = this.set_VatSdClosingBLL.getVatSdClosingDataForGv();
                this.gvvatsdClosing.DataSource = vatSdClosingDataForGv;
                this.gvvatsdClosing.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtAdjustAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                if (!string.IsNullOrEmpty(this.txtClosingBalance.Text))
                {
                    num = Convert.ToDecimal(this.txtClosingBalance.Text.Trim());
                }
                if (!string.IsNullOrEmpty(this.txtAdjustAmount.Text))
                {
                    num2 = Convert.ToDecimal(this.txtAdjustAmount.Text.Trim());
                }
                num1 = (num2 * new decimal(100)) / num;
                this.txtAdjustPct.Text = num1.ToString("N");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtAdjustPct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                if (!string.IsNullOrEmpty(this.txtClosingBalance.Text))
                {
                    num = Convert.ToDecimal(this.txtClosingBalance.Text.Trim());
                }
                if (!string.IsNullOrEmpty(this.txtAdjustPct.Text))
                {
                    num1 = Convert.ToDecimal(this.txtAdjustPct.Text.Trim());
                }
                num2 = (num1 * num) / new decimal(100);
                this.txtAdjustAmount.Text = num2.ToString("N");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private bool Validations()
        {
            if (this.drpType.SelectedValue == "Sl")
            {
                this.msgBox.AddMessage("Select Type.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.txtClosingBalance.Text.Length == 0 || this.txtClosingBalance.Text == "")
            {
                this.msgBox.AddMessage("Please provide closing balance.", MsgBoxs.enmMessageType.Info);
                this.txtClosingBalance.Focus();
                return false;
            }
            if (this.txtClosingDate.Text.Length != 0)
            {
                return true;
            }
            this.msgBox.AddMessage("Please fill Closing Date.", MsgBoxs.enmMessageType.Info);
            this.txtClosingDate.Focus();
            return false;
        }
    }
}