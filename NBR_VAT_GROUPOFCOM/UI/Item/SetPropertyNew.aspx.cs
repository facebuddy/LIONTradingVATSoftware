using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class SetPropertyNew : Page, IRequiresSessionState
    {



        private SetItemPropertyBLL objPropertyBLL = new SetItemPropertyBLL();

      
      

        public SetPropertyNew()
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.clearAllControlsValue();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            if (this.Validation())
            {
                SET_PROPERTY_DAO sETPROPERTYDAO = new SET_PROPERTY_DAO();
                sETPROPERTYDAO = this.getInsertValues(sETPROPERTYDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (this.objPropertyBLL.GetDeletedProperty(Convert.ToInt32(this.drpDetailCode.SelectedValue.ToString()), this.txtPropertyName.Text, this.txtPropertyCode.Text).Rows.Count > 0)
                    {
                        this.modalPopupForDeletedIProperty.Show();
                        return;
                    }
                    if (this.objPropertyBLL.InsertProperty(sETPROPERTYDAO) <= 0)
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.msgBox.AddMessage("Item Property Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                    this.clearAllControlsValue();
                    return;
                }
                sETPROPERTYDAO.PropertyID = Convert.ToInt32(this.gvProperty.SelectedDataKey["PROPERTY_ID"]);
                sETPROPERTYDAO.UserIdUpdate = 1;
                if (!this.objPropertyBLL.updateProperty(sETPROPERTYDAO))
                {
                    this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.msgBox.AddMessage("Property information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                    this.setAddMode();
                    this.clearAllControlsValue();
                }
                this.clearAllControlsValue();
                this.showDataInGridView();
            }
        }

        protected void btnShowHideData_Click(object sender, EventArgs e)
        {
            this.showDataInGridView();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            SET_PROPERTY_DAO sETPROPERTYDAO = new SET_PROPERTY_DAO();
            DataTable deletedProperty = this.objPropertyBLL.GetDeletedProperty(Convert.ToInt32(this.drpDetailCode.SelectedValue.ToString()), this.txtPropertyName.Text, this.txtPropertyCode.Text);
            int num = Convert.ToInt32(deletedProperty.Rows[0]["PROPERTY_ID"].ToString());
            if (this.objPropertyBLL.updateDeletedProperty(sETPROPERTYDAO, num))
            {
                this.msgBox.AddMessage("Deleted Item Added Successfully Saved.", MsgBoxs.enmMessageType.Success);
                this.clearAllControlsValue();
                this.showDataInGridView();
            }
        }

        private void clearAllControlsValue()
        {
            this.setAddMode();
            this.lblMessage.Text = "";
            this.txtPropertyCode.Text = "";
            this.txtPropertyName.Text = "";
            this.txtQuantity.Text = "";
            this.drpDetailCode.ClearSelection();
        }

        protected void drpDetailCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.showDataInGridView();
        }

        protected void drpMasterCode_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpPropertyFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fillPropertyTypeDropDownList();
        }

        private void fillPropertyTypeDropDownList()
        {
            BLL.Utility.FillPropertyTypeDropDownList(this.drpDetailCode, Convert.ToInt16(AllConstraint.PropertyTypeM));
        }

        private SET_PROPERTY_DAO getInsertValues(SET_PROPERTY_DAO objPropertyDAO)
        {
            objPropertyDAO.UserIdInsert = 1;
            objPropertyDAO.PropertyName = BLL.Utility.ReplaceQuotes(this.txtPropertyName.Text.Trim());
            objPropertyDAO.PropertyCode = BLL.Utility.ReplaceQuotes(this.txtPropertyCode.Text.Trim());
            objPropertyDAO.PropertyIdD = Convert.ToInt32(this.drpDetailCode.SelectedValue);
            objPropertyDAO.PropertyIdM = AllConstraint.PropertyTypeM;
            objPropertyDAO.Quantity = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text.ToString()) : new decimal(0));
            return objPropertyDAO;
        }

        protected void gvProperty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell item = e.Row.Cells[0];
                if (e.Row.RowState != DataControlRowState.Normal)
                {
                    DataControlRowState rowState = e.Row.RowState;
                }
            }
        }

        protected void gvUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SET_PROPERTY_DAO sETPROPERTYDAO = new SET_PROPERTY_DAO()
            {
                PropertyID = Convert.ToInt32(this.gvProperty.DataKeys[e.RowIndex].Value.ToString()),
                UserIdUpdate = 1
            };
            if (!this.objPropertyBLL.deleteProperty(sETPROPERTYDAO))
            {
                this.msgBox.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
            }
            else
            {
                this.msgBox.AddMessage("Selected information Successfully Deleted.", MsgBoxs.enmMessageType.Success);
                this.showDataInGridView();
            }
            this.clearAllControlsValue();
            this.showDataInGridView();
        }

        protected void gvUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.gvProperty.SelectedDataKey["PROPERTY_ID"]);
            DataSet propertyByPropertyID = this.objPropertyBLL.getPropertyByPropertyID(num);
            if (propertyByPropertyID != null)
            {
                this.txtPropertyCode.Text = propertyByPropertyID.Tables[0].Rows[0]["PROPERTY_CODE"].ToString();
                this.txtPropertyName.Text = propertyByPropertyID.Tables[0].Rows[0]["PROPERTY_NAME"].ToString();
                this.drpDetailCode.SelectedValue = propertyByPropertyID.Tables[0].Rows[0]["PROPERTY_TYPE_D"].ToString();
                this.txtQuantity.Text = propertyByPropertyID.Tables[0].Rows[0]["quantity"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        protected void lnkOpening_click(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.fillPropertyTypeDropDownList();
                try
                {
                    if (base.Request.QueryString["propTypeId"] != null)
                    {
                        this.drpDetailCode.SelectedValue = base.Request.QueryString["propTypeId"].ToString();
                        this.lnkOpening.Visible = true;
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
            }
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnCancel.Text = "Cancel";
        }

        private void showDataInGridView(DataSet ds)
        {
            this.gvProperty.DataSource = ds;
            this.gvProperty.DataBind();
        }

        public void showDataInGridView()
        {
            if (this.drpDetailCode.SelectedValue == "0")
            {
                DataSet allProperty = this.objPropertyBLL.GetAllProperty();
                this.gvProperty.DataSource = allProperty;
                this.gvProperty.DataBind();
                return;
            }
            int propertyTypeM = AllConstraint.PropertyTypeM;
            int num = Convert.ToInt32(this.drpDetailCode.SelectedValue);
            DataSet allPropertyByMasterID = this.objPropertyBLL.GetAllPropertyByMasterID(propertyTypeM, num);
            this.gvProperty.DataSource = allPropertyByMasterID;
            this.gvProperty.DataBind();
        }

        private bool Validation()
        {
            if (this.txtPropertyName.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Property name is mandatory.", MsgBoxs.enmMessageType.Attention);
                this.txtPropertyName.Focus();
                return false;
            }
            if (this.txtPropertyCode.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Property Code is mandatory.", MsgBoxs.enmMessageType.Attention);
                this.txtPropertyCode.Focus();
                return false;
            }
            if (this.drpDetailCode.SelectedValue == "6" && this.txtQuantity.Text == "")
            {
                this.msgBox.AddMessage("Please insert quantity.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpDetailCode.SelectedValue != "0")
            {
                return true;
            }
            this.msgBox.AddMessage("Please Select Property Type.", MsgBoxs.enmMessageType.Attention);
            return false;
        }
    }
}