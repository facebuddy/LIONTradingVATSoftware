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
    public partial class MasterDataSetup : Page, IRequiresSessionState
    {
     

        private CodeBLL codebll = new CodeBLL();

        private APP_CODE_MASTER_DAO masterdao = new APP_CODE_MASTER_DAO();

     
      

        public MasterDataSetup()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ClearControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validations())
            {
                this.masterdao = new APP_CODE_MASTER_DAO();
                this.masterdao = this.InsertMasterData(this.masterdao);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.codebll.InsertAppcodeMaster(this.masterdao))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage("Information :saved successfully.", MsgBoxs.enmMessageType.Success);
                        this.ClearControl();
                        this.GetAppCodeMaster();
                    }
                }
                if (this.btnSave.Text == "Update")
                {
                    int num = Convert.ToInt16(this.dgvMasterData.SelectedDataKey["code_id_m"]);
                    if (this.codebll.UpdateAppcodeMaster(this.masterdao, num))
                    {
                        this.msgBox.AddMessage("Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        this.ClearControl();
                        this.GetAppCodeMaster();
                        this.btnSave.Text = "Save";
                        return;
                    }
                    this.msgBox.AddMessage("Successfully Updated.", MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShowCommissionerateList_Click(object sender, EventArgs e)
        {
            this.dgvMasterData.SelectedIndex = -1;
            if (this.btnShowCommissionerateList.Text == "Show List")
            {
                this.dgvMasterData.Visible = true;
                this.btnShowCommissionerateList.Text = "Hide List";
                this.GetAppCodeMaster();
                return;
            }
            this.dgvMasterData.DataSource = null;
            this.dgvMasterData.DataBind();
            this.dgvMasterData.Visible = false;
            this.btnShowCommissionerateList.Text = "Show List";
        }

        private void ClearControl()
        {
            this.txtCodeDescription.Text = string.Empty;
            this.txtCodeName.Text = string.Empty;
            this.dgvMasterData.DataSource = null;
            this.dgvMasterData.DataBind();
        }

        protected void dgvMasterData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvMasterData.PageIndex = e.NewPageIndex;
            this.dgvMasterData.DataBind();
            this.GetAppCodeMaster();
        }

        protected void dgvMasterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(this.dgvMasterData.SelectedDataKey["code_id_m"]);
            DataSet masterGridClick = this.codebll.getMasterGridClick(num);
            if (masterGridClick != null)
            {
                this.txtCodeName.Text = masterGridClick.Tables[0].Rows[0]["code_name_m"].ToString().Trim();
                this.txtCodeDescription.Text = masterGridClick.Tables[0].Rows[0]["code_description"].ToString().Trim();
                this.txtOrder.Text = masterGridClick.Tables[0].Rows[0]["code_type"].ToString().Trim();
                this.btnSave.Text = "Update";
            }
        }

        private void GetAppCodeMaster()
        {
            DataTable appCodeMaster = this.codebll.GetAppCodeMaster();
            if (appCodeMaster.Rows.Count > 0)
            {
                this.dgvMasterData.SelectedIndex = -1;
                this.dgvMasterData.DataSource = appCodeMaster;
                this.dgvMasterData.DataBind();
            }
        }

        private APP_CODE_MASTER_DAO InsertMasterData(APP_CODE_MASTER_DAO obj)
        {
            obj.MCodeName = this.txtCodeName.Text.Trim().ToString();
            obj.MCodeDescription = this.txtCodeDescription.Text.Trim().ToString();
            obj.MCodeType = Convert.ToInt16(this.txtOrder.Text.Trim().ToString());
            obj.IsDeleted = Convert.ToInt16(0);
            return obj;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isPostBack = base.IsPostBack;
        }

        private bool Validations()
        {
            if (this.txtCodeName.Text.Length == 0)
            {
                this.msgBox.AddMessage("Data Name needed.", MsgBoxs.enmMessageType.Attention);
                this.txtCodeName.Focus();
                return false;
            }
            if (this.txtOrder.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please fill code type.", MsgBoxs.enmMessageType.Error);
                this.txtOrder.Focus();
                return false;
            }
            if (this.btnSave.Text == "Save")
            {
                if (this.codebll.getIsExistNameSave(this.txtCodeName.Text.ToString().Trim().ToUpper()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Data Name already exist in the system.", MsgBoxs.enmMessageType.Attention);
                    this.txtCodeName.Focus();
                    return false;
                }
                if (this.codebll.getIsExistDescriptionSave(this.txtCodeDescription.Text.ToString().Trim().ToUpper()).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Data Description already exist in the system.", MsgBoxs.enmMessageType.Attention);
                    this.txtCodeName.Focus();
                    return false;
                }
            }
            if (this.btnSave.Text == "Update")
            {
                int num = Convert.ToInt16(this.dgvMasterData.SelectedDataKey["code_id_m"]);
                if (this.codebll.getIsExistNameUpdate(this.txtCodeName.Text.ToString().Trim().ToUpper(), num).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Data Name already exist in the system.", MsgBoxs.enmMessageType.Attention);
                    this.txtCodeName.Focus();
                    return false;
                }
                if (this.codebll.getIsExistDescriptionUpdate(this.txtCodeDescription.Text.ToString().Trim().ToUpper(), num).Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Data Description already exist in the system.", MsgBoxs.enmMessageType.Attention);
                    this.txtCodeName.Focus();
                    return false;
                }
            }
            return true;
        }
    }
}