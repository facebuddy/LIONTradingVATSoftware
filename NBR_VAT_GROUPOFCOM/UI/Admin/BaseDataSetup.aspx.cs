using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class BaseDataSetup : Page, IRequiresSessionState
    {
      

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

        public BaseDataSetup()
        {
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.LoadCodeType();
            this.ClearAllControlsValue();
            this.gvBaseData.DataSource = null;
            this.gvBaseData.DataBind();
            this.SetAddMode();
            this.ControlEnableDisable();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = "";
                if (this.Validation())
                {
                    CodeBLL codeBLL = new CodeBLL();
                    APP_CODE_DETAIL_DAO aPPCODEDETAILDAO = new APP_CODE_DETAIL_DAO();
                    aPPCODEDETAILDAO = this.GetInserValues(aPPCODEDETAILDAO);
                    if (!(this.btnSave.Text == BaseDataSetup.enmBtnText.Save.ToString()) || !(this.hdCodeType.Value != 2.ToString()) || !(this.hdCodeType.Value != 6.ToString()))
                    {
                        bool flag = false;
                        aPPCODEDETAILDAO.CodeIDD = Convert.ToInt32(this.gvBaseData.SelectedRow.Cells[1].Text);
                        flag = (this.hdCodeType.Value == 2.ToString() || this.hdCodeType.Value == 3.ToString() ? codeBLL.UpdateBaseCodeValue(aPPCODEDETAILDAO) : codeBLL.UpdateBaseData(aPPCODEDETAILDAO));
                        if (!flag)
                        {
                            this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage(string.Concat(this.drpCodeType.SelectedItem.Text, " Information Successfully Updated."), MsgBoxs.enmMessageType.Success);
                            this.SetAddMode();
                            this.ClearAllControlsValue();
                            this.ShowDataInGridView(false);
                        }
                    }
                    else if (!codeBLL.InsertBaseData(aPPCODEDETAILDAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage(string.Concat(this.drpCodeType.SelectedItem.Text, " Information Successfully Saved."), MsgBoxs.enmMessageType.Success);
                        this.ClearAllControlsValue();
                        this.ShowDataInGridView(false);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.ShowDataInGridView(true);
        }

        private void ClearAllControlsValue()
        {
            this.txtCodeName.Text = "";
            this.txtCodeShortName.Text = "";
            this.txtCodeValue.Text = "";
            this.txtCodeValue2nd.Text = "";
            this.txtCodeDate.Text = "";
            this.txtCodeDate2nd.Text = "";
            this.hdCodeIdD.Value = "0";
        }

        private void ControlEnableDisable()
        {
            this.drpParent.Items.Clear();
            this.drpParent.Enabled = false;
            this.txtCodeValue.Enabled = false;
            this.txtCodeValue2nd.Enabled = false;
            this.txtCodeDate.Enabled = false;
            this.txtCodeDate2nd.Enabled = false;
            this.txtCodeName.Enabled = true;
            this.txtCodeShortName.Enabled = true;
            if ((this.hdCodeType.Value == 1.ToString() || this.hdCodeType.Value == 5.ToString()) && this.hdCodeType.Value == 5.ToString())
            {
                this.drpParent.Enabled = true;
                this.LoadParentData();
            }
            if (this.hdCodeType.Value == 3.ToString())
            {
                this.txtCodeValue.Enabled = true;
                this.txtCodeValue2nd.Enabled = true;
                this.txtCodeName.Enabled = false;
                this.txtCodeShortName.Enabled = false;
            }
            if (this.hdCodeType.Value == 2.ToString())
            {
                this.txtCodeValue.Enabled = true;
                this.txtCodeName.Enabled = false;
                this.txtCodeShortName.Enabled = false;
                return;
            }
            if (this.hdCodeType.Value == 5.ToString())
            {
                this.drpParent.Enabled = true;
                this.LoadParentData();
                return;
            }
            if (this.hdCodeType.Value == 6.ToString())
            {
                this.txtCodeValue.Enabled = true;
                this.txtCodeValue2nd.Enabled = true;
                this.txtCodeDate.Enabled = true;
                this.txtCodeDate2nd.Enabled = true;
                return;
            }
            this.drpParent.Items.Clear();
            this.drpParent.Enabled = false;
            this.txtCodeValue.Enabled = false;
            this.txtCodeValue2nd.Enabled = false;
            this.txtCodeDate.Enabled = false;
            this.txtCodeDate2nd.Enabled = false;
            this.txtCodeName.Enabled = true;
            this.txtCodeShortName.Enabled = true;
        }

        protected void drpCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.drpCodeType.SelectedValue) && !(this.drpCodeType.SelectedValue == "-99"))
                {
                    DataTable item = (DataTable)this.Session["dtMasterCode"];
                    short num = Convert.ToInt16(this.drpCodeType.SelectedValue);
                    short num1 = 0;
                    if (item == null || item.Rows.Count <= 0)
                    {
                        this.hdCodeType.Value = "";
                    }
                    else
                    {
                        num1 = Convert.ToInt16(item.Select(string.Concat("code_id_m = ", num))[0]["CODE_TYPE"]);
                        this.hdCodeType.Value = num1.ToString();
                    }
                    this.ControlEnableDisable();
                    this.SetAddMode();
                    this.gvBaseData.DataSource = null;
                    this.gvBaseData.DataBind();
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void drpParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtCodeName.Text = "";
                this.txtCodeShortName.Text = "";
                this.ShowDataInGridView(false);
            }
            catch (Exception exception)
            {
            }
        }

        private APP_CODE_DETAIL_DAO GetInserValues(APP_CODE_DETAIL_DAO objDetailDAO)
        {
            APP_CODE_DETAIL_DAO aPPCODEDETAILDAO;
            try
            {
                if (this.hdCodeType.Value != "")
                {
                    objDetailDAO.MCodeType = Convert.ToInt16(this.hdCodeType.Value);
                }
                objDetailDAO.CodeIDM = Convert.ToInt32(this.drpCodeType.SelectedValue);
                objDetailDAO.CodeName = Convert.ToString(this.txtCodeName.Text.ToString());
                objDetailDAO.CodeShortName = this.txtCodeShortName.Text.ToString();
                if (this.hdCodeType.Value != 5.ToString())
                {
                    objDetailDAO.CodeValue1st = 0;
                    objDetailDAO.CodeValue2nd = 0;
                }
                else
                {
                    objDetailDAO.CodeValue1st = Convert.ToDouble(this.hdParentMCodeID.Value);
                    objDetailDAO.CodeValue2nd = Convert.ToDouble(this.drpParent.SelectedValue);
                }
                if (this.txtCodeValue.Text != "")
                {
                    objDetailDAO.CodeValue1st = Convert.ToDouble(this.txtCodeValue.Text);
                }
                if (this.txtCodeValue2nd.Text != "")
                {
                    objDetailDAO.CodeValue2nd = Convert.ToDouble(this.txtCodeValue2nd.Text);
                }
                if (this.txtCodeDate.Text != "")
                {
                    objDetailDAO.CodeDate1st = Utility.GetStandardDateFrom_ddMMyyyy(this.txtCodeDate.Text.Trim());
                }
                if (this.txtCodeDate2nd.Text != "")
                {
                    objDetailDAO.CodeDate2nd = Utility.GetStandardDateFrom_ddMMyyyy(this.txtCodeDate2nd.Text.Trim());
                }
                aPPCODEDETAILDAO = objDetailDAO;
            }
            catch (Exception exception)
            {
                aPPCODEDETAILDAO = objDetailDAO;
            }
            return aPPCODEDETAILDAO;
        }

        protected void gvBaseData_PreRender(object sender, EventArgs e)
        {
        }

        protected void gvBaseData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TableCell item = e.Row.Cells[0];
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        ((LinkButton)e.Row.Cells[0].Controls[0]).Attributes["onclick"] = "if(!confirm('Are you sure you want to delete?'))return   false;";
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void gvBaseData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(this.drpCodeType.SelectedValue);
                int num1 = Convert.ToInt16(this.gvBaseData.Rows[e.RowIndex].Cells[1].Text.Trim().ToString());
                CodeBLL codeBLL = new CodeBLL();
                DataTable dataFromItem = codeBLL.GetDataFromItem(num1, num);
                DataTable dataFromItemProRelation = codeBLL.GetDataFromItemProRelation(num1, num);
                DataTable dataFromItemProperty = codeBLL.GetDataFromItemProperty(num1, num);
                DataTable dataFromItemUnit = codeBLL.GetDataFromItemUnit(num1, num);
                DataTable dataFromItemUnitConversion = codeBLL.GetDataFromItemUnitConversion(num1, num);
                DataTable dataFromOrgRegInfo = codeBLL.GetDataFromOrgRegInfo(num1, num);
                DataTable dataFromPriceValueAdditionArea = codeBLL.GetDataFromPriceValueAdditionArea(num1, num);
                DataTable dataFromPrchaseMaster = codeBLL.GetDataFromPrchaseMaster(num1, num);
                DataTable dataFromSaleMaster = codeBLL.GetDataFromSaleMaster(num1, num);
                if (dataFromItem.Rows.Count >= 1 || dataFromItemProRelation.Rows.Count >= 1 || dataFromItemProperty.Rows.Count >= 1 || dataFromItemUnit.Rows.Count >= 1 || dataFromItemUnitConversion.Rows.Count >= 1 || dataFromOrgRegInfo.Rows.Count >= 1 || dataFromPriceValueAdditionArea.Rows.Count >= 1 || dataFromPrchaseMaster.Rows.Count >= 1 || dataFromSaleMaster.Rows.Count >= 1)
                {
                    this.msgBox.AddMessage("Fail to delete.This Base Data exists in other transaction.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    APP_CODE_DETAIL_DAO aPPCODEDETAILDAO = new APP_CODE_DETAIL_DAO()
                    {
                        CodeIDM = Convert.ToInt32(this.drpCodeType.SelectedValue),
                        CodeIDD = num1
                    };
                    if (!codeBLL.DeleteBaseData(aPPCODEDETAILDAO))
                    {
                        this.msgBox.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage("Information Successfully Deleted.", MsgBoxs.enmMessageType.Success);
                        this.ShowDataInGridView(true);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void gvBaseData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ClearAllControlsValue();
                this.drpCodeType.SelectedValue = this.gvBaseData.SelectedDataKey["CODE_ID_M"].ToString();
                this.txtCodeName.Text = this.gvBaseData.SelectedRow.Cells[2].Text;
                this.txtCodeShortName.Text = this.gvBaseData.SelectedRow.Cells[3].Text;
                this.hdCodeIdD.Value = this.gvBaseData.SelectedDataKey["CODE_ID_D"].ToString();
                if (this.hdCodeType.Value != 6.ToString())
                {
                    this.txtCodeValue.Text = "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.gvBaseData.SelectedDataKey["CODE_VALUE_1ST"].ToString()))
                    {
                        TextBox str = this.txtCodeValue;
                        double num = Convert.ToDouble(this.gvBaseData.SelectedDataKey["CODE_VALUE_1ST"]);
                        str.Text = num.ToString("##.##");
                    }
                    if (!string.IsNullOrEmpty(this.gvBaseData.SelectedDataKey["CODE_VALUE_2ND"].ToString()))
                    {
                        TextBox textBox = this.txtCodeValue2nd;
                        double num1 = Convert.ToDouble(this.gvBaseData.SelectedDataKey["CODE_VALUE_2ND"]);
                        textBox.Text = num1.ToString("##.##");
                    }
                    if (!string.IsNullOrEmpty(this.gvBaseData.SelectedDataKey["CODE_DATE_1ST"].ToString()))
                    {
                        this.txtCodeDate.Text = this.gvBaseData.SelectedDataKey["CODE_DATE_1ST"].ToString();
                    }
                    if (!string.IsNullOrEmpty(this.gvBaseData.SelectedDataKey["CODE_DATE_2ND"].ToString()))
                    {
                        this.txtCodeDate2nd.Text = this.gvBaseData.SelectedDataKey["CODE_DATE_2ND"].ToString();
                    }
                }
                this.SetUpdateMode();
            }
            catch (Exception exception)
            {
            }
        }

        private void LoadCodeType()
        {
            try
            {
                DataTable systemMasterCode = (new CodeBLL()).GetSystemMasterCode();
                this.drpCodeType.DataSource = systemMasterCode;
                this.drpCodeType.DataTextField = systemMasterCode.Columns["CODE_NAME_m"].ToString();
                this.drpCodeType.DataValueField = systemMasterCode.Columns["CODE_ID_m"].ToString();
                this.drpCodeType.DataBind();
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpCodeType.Items.Insert(0, listItem);
                this.drpCodeType.SelectedValue = "-99";
                this.hdCodeType.Value = "";
                this.Session["dtMasterCode"] = systemMasterCode;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadParentData()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.LoadCodeType();
                this.ControlEnableDisable();
            }
        }

        private void SetAddMode()
        {
            this.btnSave.Text = BaseDataSetup.enmBtnText.Save.ToString();
            this.btnClear.Text = BaseDataSetup.enmBtnText.Clear.ToString();
        }

        private void SetUpdateMode()
        {
            this.btnSave.Text = BaseDataSetup.enmBtnText.Update.ToString();
            this.btnClear.Text = BaseDataSetup.enmBtnText.Cancel.ToString();
        }

        private void ShowDataInGridView(bool showMsg)
        {
            try
            {
                CodeBLL codeBLL = new CodeBLL();
                DataTable detailCodeByMasterId = codeBLL.GetDetailCodeByMasterId(this.GetInserValues(new APP_CODE_DETAIL_DAO()));
                if (this.hdCodeType.Value == 3.ToString())
                {
                    if (detailCodeByMasterId != null && detailCodeByMasterId.Rows.Count > 0)
                    {
                        TextBox str = this.txtCodeValue;
                        double num = Convert.ToDouble(detailCodeByMasterId.Rows[0]["CODE_VALUE_1ST"]);
                        str.Text = num.ToString("##.##");
                        TextBox textBox = this.txtCodeValue2nd;
                        double num1 = Convert.ToDouble(detailCodeByMasterId.Rows[0]["CODE_VALUE_2ND"]);
                        textBox.Text = num1.ToString("##.##");
                        this.hdCodeIdD.Value = detailCodeByMasterId.Rows[0]["CODE_ID_D"].ToString();
                    }
                    this.SetUpdateMode();
                }
                else if (this.hdCodeType.Value != 2.ToString())
                {
                    this.txtCodeValue.Text = "";
                    this.txtCodeValue2nd.Text = "";
                }
                else
                {
                    if (detailCodeByMasterId != null && detailCodeByMasterId.Rows.Count > 0)
                    {
                        TextBox str1 = this.txtCodeValue;
                        double num2 = Convert.ToDouble(detailCodeByMasterId.Rows[0]["CODE_VALUE_1ST"]);
                        str1.Text = num2.ToString("##.##");
                        this.hdCodeIdD.Value = detailCodeByMasterId.Rows[0]["CODE_ID_D"].ToString();
                    }
                    this.SetUpdateMode();
                }
                if (this.drpCodeType.SelectedValue == "-99")
                {
                    this.gvBaseData.DataSource = null;
                    this.gvBaseData.DataBind();
                }
                else
                {
                    this.hdCodeIdD.Value = detailCodeByMasterId.Rows[0]["CODE_ID_D"].ToString();
                    this.gvBaseData.DataSource = detailCodeByMasterId;
                    this.gvBaseData.DataBind();
                    this.SetAddMode();
                }
                if (showMsg && (this.hdCodeType.Value == 1.ToString() || this.hdCodeType.Value == 5.ToString()) && (detailCodeByMasterId == null || detailCodeByMasterId.Rows.Count == 0))
                {
                    this.msgBox.AddMessage("No Record Found.", MsgBoxs.enmMessageType.Info);
                }
            }
            catch (Exception exception)
            {
            }
        }

        private bool Validation()
        {
            if (this.hdCodeType.Value == 2.ToString() && this.txtCodeValue.Text.Trim() == "")
            {
                this.msgBox.AddMessage("Please insert code value.", MsgBoxs.enmMessageType.Error);
                this.txtCodeValue.Focus();
                return false;
            }
            if (this.hdCodeType.Value == 3.ToString() && (this.txtCodeValue.Text.Trim() == "" || this.txtCodeValue2nd.Text.Trim() == ""))
            {
                this.msgBox.AddMessage("Please insert code value.", MsgBoxs.enmMessageType.Error);
                this.txtCodeValue.Focus();
                return false;
            }
            if (this.txtCodeName.Text == "")
            {
                this.msgBox.AddMessage("Please insert Data Description.", MsgBoxs.enmMessageType.Error);
                return false;
            }
            if (this.txtCodeShortName.Text != "")
            {
                return true;
            }
            this.msgBox.AddMessage("Please insert Data Short Description.", MsgBoxs.enmMessageType.Error);
            return false;
        }

        private enum enmBtnText
        {
            Save,
            Update,
            Cancel,
            Clear
        }
    }
}