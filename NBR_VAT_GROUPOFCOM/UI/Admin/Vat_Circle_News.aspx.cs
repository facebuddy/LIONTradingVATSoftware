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
    public partial class Vat_Circle_News : Page, IRequiresSessionState
    {
     

        private vatCircleDAO objVatCircleDAO = new vatCircleDAO();

        private vatCircleBLL objVatCircleBLL = new vatCircleBLL();

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

        public Vat_Circle_News()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.objVatCircleDAO = new vatCircleDAO();
            if (this.CircleValidation())
            {
                this.objVatCircleDAO = this.insertCircle(this.objVatCircleDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.objVatCircleBLL.InsertDivision(this.objVatCircleDAO))
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
                    int num = Convert.ToInt16(this.dgvVatCircle.SelectedDataKey["circle_id"]);
                    if (this.objVatCircleBLL.UpdateDivision(this.objVatCircleDAO, num))
                    {
                        this.clearFrom();
                        this.msgBox.AddMessage("Commissionerate Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        return;
                    }
                    this.msgBox.AddMessage("Successfully Updated.", MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShowCircleList_Click(object sender, EventArgs e)
        {
            if (this.btnShowCircleList.Text != "Show Circle List")
            {
                this.dgvVatCircle.Visible = false;
                this.btnShowCircleList.Text = "Show Circle List";
                this.clearFrom();
                return;
            }
            this.dgvVatCircle.SelectedIndex = -1;
            this.dgvVatCircle.Visible = true;
            this.btnShowCircleList.Text = "Hide Circle List";
            this.RefreshGridView();
        }

        private bool CircleValidation()
        {
            if (this.drpCommName.SelectedValue == 0.ToString())
            {
                this.drpCommName.Focus();
                return false;
            }
            if (this.drpDivisionName.SelectedValue == "-99".ToString())
            {
                this.drpDivisionName.Focus();
                return false;
            }
            if (this.txtCircleName.Text.Trim().Length < 1)
            {
                this.txtCircleName.Focus();
                return false;
            }
            if (this.txtCircleAddress.Text.Trim().Length < 1)
            {
                this.txtCircleAddress.Focus();
                return false;
            }
            if (this.txtCircleCode.Text.Trim().Length < 1)
            {
                this.txtCircleCode.Focus();
                return false;
            }
            if (this.txtCirclePhone.Text.Trim().Length < 1)
            {
                this.txtCirclePhone.Focus();
                return false;
            }
            if (this.drpUpazillaName.SelectedValue == 0.ToString())
            {
                this.drpUpazillaName.Focus();
                return false;
            }
            if (this.drpUnionWardName.SelectedValue != 0.ToString())
            {
                return true;
            }
            this.drpUnionWardName.Focus();
            return false;
        }

        private void clearFrom()
        {
            OrganizaitonInfo.fillAllVATCommissionerate(this.drpCommName);
            if (this.drpCommName.Items.Count > 0)
            {
                OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, Convert.ToInt32(this.drpCommName.SelectedItem.Value.ToString()));
            }
            this.txtCircleName.Text = "";
            this.txtCircleAddress.Text = "";
            this.txtCircleCode.Text = "";
            this.txtCirclePhone.Text = "";
            this.drpUpazillaName.SelectedValue = "0";
            this.drpUnionWardName.SelectedValue = "0";
            this.txtJurisdiction.Text = string.Empty;
            this.btnSave.Text = "Save";
            this.setAddMode();
            this.RefreshGridView();
        }

        protected void dgvVatCircle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.objVatCircleBLL = new vatCircleBLL();
                int num = Convert.ToInt32(this.dgvVatCircle.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objVatCircleBLL.deleteCircle(num))
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

        protected void dgvVatCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvVatCircle.SelectedDataKey["circle_id"]);
            DataSet circle = this.objVatCircleBLL.getCircle(num);
            if (circle != null && circle.Tables.Count > 0)
            {
                this.drpCommName.SelectedValue = circle.Tables[0].Rows[0]["comm_id"].ToString();
                int num1 = Convert.ToInt32(this.drpCommName.SelectedItem.Value);
                OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, num1);
                this.drpDivisionName.SelectedValue = circle.Tables[0].Rows[0]["division_id"].ToString();
                this.txtCircleName.Text = circle.Tables[0].Rows[0]["circle_name"].ToString();
                this.txtCircleAddress.Text = circle.Tables[0].Rows[0]["address"].ToString();
                this.txtCircleCode.Text = circle.Tables[0].Rows[0]["circle_code"].ToString();
                this.txtCirclePhone.Text = circle.Tables[0].Rows[0]["phone_no"].ToString();
                if (circle.Tables[0].Rows[0]["upazila_id"].ToString() != "")
                {
                    this.drpUpazillaName.SelectedValue = circle.Tables[0].Rows[0]["upazila_id"].ToString();
                }
                else
                {
                    this.drpUpazillaName.SelectedValue = "0";
                }
                int num2 = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
                Util.fillUnionWardByUpazila(this.drpUnionWardName, num2);
                this.drpUnionWardName.SelectedValue = circle.Tables[0].Rows[0]["union_ward_id"].ToString();
                this.txtJurisdiction.Text = circle.Tables[0].Rows[0]["jurisdiction"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        protected void drpCommName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpCommName.SelectedItem.Value);
            OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, num);
        }

        protected void drpUnionWardName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpUpazillaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
            Util.fillUnionWardByUpazila(this.drpUnionWardName, num);
        }

        private vatCircleDAO insertCircle(vatCircleDAO objVatCircleDAO)
        {
            objVatCircleDAO.Comm_id = Convert.ToInt16(this.drpCommName.SelectedValue);
            objVatCircleDAO.DivisionId = Convert.ToInt16(this.drpDivisionName.SelectedValue);
            objVatCircleDAO.CircleName = this.txtCircleName.Text.Trim();
            objVatCircleDAO.CircleCode = this.txtCircleCode.Text.Trim();
            objVatCircleDAO.Address = this.txtCircleAddress.Text.Trim();
            objVatCircleDAO.PhoneNo = this.txtCirclePhone.Text.Trim();
            objVatCircleDAO.UpazillaId = Convert.ToInt16(this.drpUpazillaName.SelectedValue);
            objVatCircleDAO.UnionWardId = Convert.ToInt16(this.drpUnionWardName.SelectedValue);
            objVatCircleDAO.Jurisdiction = this.txtJurisdiction.Text.ToString();
            return objVatCircleDAO;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Util.fillUpazillaNameDropdownList(this.drpUpazillaName);
                OrganizaitonInfo.fillAllVATCommissionerate(this.drpCommName);
                if (this.drpCommName.Items.Count > 0)
                {
                    OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, Convert.ToInt32(this.drpCommName.SelectedItem.Value.ToString()));
                }
            }
        }

        private void RefreshGridView()
        {
            DataTable circleDataForGv = this.objVatCircleBLL.getCircleDataForGv();
            this.dgvVatCircle.DataSource = circleDataForGv;
            this.dgvVatCircle.DataBind();
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }
    }
}