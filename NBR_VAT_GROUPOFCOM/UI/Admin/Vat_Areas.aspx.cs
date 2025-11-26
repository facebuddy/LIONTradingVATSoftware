using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class Vat_Areas : Page, IRequiresSessionState
    {
       

  

        private vatAreaDAO objVatAreaDAO = new vatAreaDAO();

        private vatAreaBLL objVatAreaBLL = new vatAreaBLL();

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

        public Vat_Areas()
        {
        }

        private bool AreaValidation()
        {
            if (this.drpCommName.SelectedValue == "-99")
            {
                this.drpCommName.Focus();
                this.msgBox.AddMessage("Select Commissonerate Name.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpDivisionName.SelectedValue == "-99")
            {
                this.drpDivisionName.Focus();
                this.msgBox.AddMessage("Select Division Name.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpCircleName.SelectedValue == "")
            {
                this.drpCircleName.Focus();
                this.msgBox.AddMessage("Select Circle Name.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtAreaName.Text.Trim().Length < 1)
            {
                this.txtAreaName.Focus();
                this.msgBox.AddMessage("Enter Area Name.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtAreaAddress.Text.Trim().Length < 1)
            {
                this.txtAreaAddress.Focus();
                this.msgBox.AddMessage("Enter Address.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtAreaCode.Text.Trim().Length < 1)
            {
                this.txtAreaCode.Focus();
                this.msgBox.AddMessage("Enter Area Code.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtAreaPhone.Text.Trim().Length < 1)
            {
                this.txtAreaPhone.Focus();
                this.msgBox.AddMessage("Enter Phone.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpUpazillaName.SelectedValue == "-99")
            {
                this.drpUpazillaName.Focus();
                this.msgBox.AddMessage("Select Upazilla Name.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpUnionWardName.SelectedValue != "")
            {
                return true;
            }
            this.drpUnionWardName.Focus();
            this.msgBox.AddMessage("Select Union/Ward Name.", MsgBoxs.enmMessageType.Attention);
            return false;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.objVatAreaDAO = new vatAreaDAO();
                if (this.AreaValidation())
                {
                    this.objVatAreaDAO = this.insertArea(this.objVatAreaDAO);
                    if (this.btnSave.Text != "Save")
                    {
                        this.objVatAreaDAO.AreaId = Convert.ToInt16(this.dgvVatArea.SelectedDataKey["area_id"]);
                        if (!this.objVatAreaBLL.UpdateArea(this.objVatAreaDAO))
                        {
                            this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("VAT Area Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                            this.setAddMode();
                            this.clearFrom();
                            this.RefreshGridView();
                        }
                    }
                    else if (!this.objVatAreaBLL.InsertArea(this.objVatAreaDAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.clearFrom();
                        this.msgBox.AddMessage("Commissionerate Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                Utility.InsertErrorTrackNew(exception.Message, "VAT_Area", "btnSave_Click", fileLineNumber);
            }
        }

        protected void btnShowAreaList_Click(object sender, EventArgs e)
        {
            if (this.btnShowAreaList.Text != "Show Area List")
            {
                this.dgvVatArea.Visible = false;
                this.btnShowAreaList.Text = "Show Area List";
                return;
            }
            this.dgvVatArea.Visible = true;
            this.btnShowAreaList.Text = "Hide Area List";
            this.RefreshGridView();
        }

        private void clearFrom()
        {
            try
            {
                OrganizaitonInfo.fillAllVATCommissionerate(this.drpCommName);
                if (this.drpCommName.Items.Count > 0)
                {
                    int num = Convert.ToInt32(this.drpCommName.SelectedItem.Value);
                    OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, num);
                    if (this.drpDivisionName.Items.Count > 0)
                    {
                        OrganizaitonInfo.fillAllVATCirleByDivisionID(this.drpCircleName, Convert.ToInt32(this.drpDivisionName.SelectedItem.Value.ToString()));
                    }
                }
                this.txtAreaName.Text = "";
                this.txtAreaAddress.Text = "";
                this.txtAreaCode.Text = "";
                this.txtAreaPhone.Text = "";
                this.drpUpazillaName.SelectedValue = "0";
                this.drpUnionWardName.SelectedValue = "0";
                this.drpCircleName.SelectedValue = "0";
                this.btnSave.Text = "Save";
                this.setAddMode();
                this.RefreshGridView();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                Utility.InsertErrorTrackNew(exception.Message, "VAT_Area", "clearFrom", fileLineNumber);
            }
        }

        protected void dgvVatArea_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvVatArea.PageIndex = e.NewPageIndex;
            this.RefreshGridView();
        }

        protected void dgvVatArea_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.objVatAreaBLL = new vatAreaBLL();
                int num = Convert.ToInt32(this.dgvVatArea.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objVatAreaBLL.deleteArea(num))
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

        protected void dgvVatArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvVatArea.SelectedDataKey["area_id"]);
            DataSet area = this.objVatAreaBLL.getArea(num);
            if (area != null)
            {
                this.drpCommName.SelectedValue = area.Tables[0].Rows[0]["comm_id"].ToString();
                int num1 = Convert.ToInt32(this.drpCommName.SelectedItem.Value);
                OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, num1);
                this.drpDivisionName.SelectedValue = area.Tables[0].Rows[0]["division_id"].ToString();
                int num2 = Convert.ToInt32(this.drpDivisionName.SelectedItem.Value);
                OrganizaitonInfo.fillAllVATCirleByDivisionID(this.drpCircleName, num2);
                this.drpCircleName.SelectedValue = area.Tables[0].Rows[0]["circle_id"].ToString();
                this.txtAreaName.Text = area.Tables[0].Rows[0]["area_name"].ToString();
                this.txtAreaAddress.Text = area.Tables[0].Rows[0]["address"].ToString();
                this.txtAreaCode.Text = area.Tables[0].Rows[0]["area_code"].ToString();
                this.txtAreaPhone.Text = area.Tables[0].Rows[0]["phone_no"].ToString();
                this.drpUpazillaName.SelectedValue = area.Tables[0].Rows[0]["upazila_id"].ToString();
                int num3 = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
                Util.fillUnionWardByUpazila(this.drpUnionWardName, num3);
                this.drpUnionWardName.SelectedValue = area.Tables[0].Rows[0]["union_ward_id"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        protected void drpCommName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpCommName.SelectedItem.Value);
            OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, num);
            if (this.drpDivisionName.Items.Count > 0)
            {
                OrganizaitonInfo.fillAllVATCirleByDivisionID(this.drpCircleName, Convert.ToInt32(this.drpDivisionName.SelectedItem.Value.ToString()));
            }
        }

        protected void drpDivisionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpDivisionName.SelectedItem.Value);
            OrganizaitonInfo.fillAllVATCirleByDivisionID(this.drpCircleName, num);
        }

        protected void drpUpazillaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpUpazillaName.SelectedItem.Value);
            Util.fillUnionWardByUpazila(this.drpUnionWardName, num);
        }

        private vatAreaDAO insertArea(vatAreaDAO objVatAreaDAO)
        {
            objVatAreaDAO.CircleId = Convert.ToInt16(this.drpCircleName.SelectedValue);
            objVatAreaDAO.AreaName = this.txtAreaName.Text.Trim();
            objVatAreaDAO.AreaCode = this.txtAreaCode.Text.Trim();
            objVatAreaDAO.Address = this.txtAreaAddress.Text.Trim();
            objVatAreaDAO.PhoneNo = this.txtAreaPhone.Text.Trim();
            objVatAreaDAO.UpazillaId = Convert.ToInt16(this.drpUpazillaName.SelectedValue);
            objVatAreaDAO.UnionWardId = Convert.ToInt16(this.drpUnionWardName.SelectedValue);
            return objVatAreaDAO;
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
                    int num = Convert.ToInt32(this.drpCommName.SelectedItem.Value);
                    OrganizaitonInfo.fillVATDivisionByVATCommissionerate(this.drpDivisionName, num);
                    if (this.drpDivisionName.Items.Count > 0)
                    {
                        OrganizaitonInfo.fillAllVATCirleByDivisionID(this.drpCircleName, Convert.ToInt32(this.drpDivisionName.SelectedItem.Value.ToString()));
                    }
                }
                this.RefreshGridView();
            }
        }

        private void RefreshGridView()
        {
            DataTable areaDataForGv = this.objVatAreaBLL.getAreaDataForGv();
            this.dgvVatArea.DataSource = areaDataForGv;
            this.dgvVatArea.DataBind();
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }
    }
}