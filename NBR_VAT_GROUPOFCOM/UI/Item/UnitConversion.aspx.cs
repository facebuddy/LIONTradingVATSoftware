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

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class UnitConversion : Page, IRequiresSessionState
    
    {
   

        private UnitBLL objUnitBLL = new UnitBLL();

      


        public UnitConversion()
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
                SET_UNIT_CONVERSION_DAO sETUNITCONVERSIONDAO = new SET_UNIT_CONVERSION_DAO();
                sETUNITCONVERSIONDAO = this.getInsertValues(sETUNITCONVERSIONDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (!this.objUnitBLL.InsertUnitConversion(sETUNITCONVERSIONDAO))
                    {
                        this.msgBox.AddMessage("This unit conversion already exsist! Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.msgBox.AddMessage("Item unit conversion infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                    this.clearAllControlsValue();
                    return;
                }
                sETUNITCONVERSIONDAO.measurementIDM = Convert.ToInt16(this.gvUnit.SelectedDataKey["UNIT_ID_FROM"]);
                Convert.ToDateTime(this.gvUnit.SelectedDataKey["DATE_INSERT"]);
                sETUNITCONVERSIONDAO.ConversionId = Convert.ToInt32(this.gvUnit.SelectedDataKey["CONVERSION_ID"]);
                if (this.objUnitBLL.updateUnitConvertion(sETUNITCONVERSIONDAO))
                {
                    this.msgBox.AddMessage("Unit information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                    this.showDataInGridView();
                    this.setAddMode();
                    this.clearAllControlsValue();
                    return;
                }
                this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void btnShowHideData_Click(object sender, EventArgs e)
        {
            this.msgBox.Visible = false;
            this.showDataInGridView();
        }

        private void clearAllControlsValue()
        {
            this.setAddMode();
            this.txtValueFrom.Text = "1";
            this.txtValueTo.Text = "";
            Utility.fillDetailCode(this.drpDetailCode, AllConstraint.measurementTypeMasterId);
            Utility.fillUnit(this.drpUnitFrom, Convert.ToInt32(this.drpDetailCode.SelectedValue));
            Utility.fillUnitTo(this.drpUnitTo, Convert.ToInt32(this.drpDetailCode.SelectedValue), Convert.ToInt32(this.drpUnitFrom.SelectedValue));
        }

        protected void drpDetailCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.fillUnit(this.drpUnitFrom, Convert.ToInt32(this.drpDetailCode.SelectedValue));
            int num = (!string.IsNullOrEmpty(this.drpDetailCode.SelectedValue) ? Convert.ToInt32(this.drpDetailCode.SelectedValue) : 0);
            Utility.fillUnitTo(this.drpUnitTo, num, (!string.IsNullOrEmpty(this.drpUnitFrom.SelectedValue) ? Convert.ToInt32(this.drpUnitFrom.SelectedValue) : 0));
            this.showDataInGridView();
        }

        protected void drpUnitFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.fillUnitTo(this.drpUnitTo, Convert.ToInt32(this.drpDetailCode.SelectedValue), Convert.ToInt32(this.drpUnitFrom.SelectedValue));
        }

        private SET_UNIT_CONVERSION_DAO getInsertValues(SET_UNIT_CONVERSION_DAO objUnitConversionDAO)
        {
            objUnitConversionDAO.measurementIDM = Convert.ToInt16(AllConstraint.measurementTypeMasterId);
            objUnitConversionDAO.measurementIDD = Convert.ToInt16(this.drpDetailCode.SelectedValue);
            objUnitConversionDAO.UnitIdFrom = Convert.ToInt16(this.drpUnitFrom.SelectedValue);
            objUnitConversionDAO.ValueFrom = 1;
            objUnitConversionDAO.UnitIdTo = Convert.ToInt16(this.drpUnitTo.SelectedValue);
            objUnitConversionDAO.ValueTo = Convert.ToDouble(this.txtValueTo.Text);
            objUnitConversionDAO.ConversionType = 'G';
            return objUnitConversionDAO;
        }

        protected void gvProperty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell item = e.Row.Cells[0];
            }
        }

        protected void gvUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void gvUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.gvUnit.SelectedDataKey["MEASUREMENT_ID_D"]);
            int num1 = Convert.ToInt32(this.gvUnit.SelectedDataKey["CONVERSION_ID"]);
            DataSet unitConversionByConversionID = this.objUnitBLL.getUnitConversionByConversionID(num, num1);
            if (unitConversionByConversionID != null)
            {
                this.drpDetailCode.SelectedValue = unitConversionByConversionID.Tables[0].Rows[0]["MEASUREMENT_ID_D"].ToString();
                Utility.fillUnit(this.drpUnitFrom, Convert.ToInt32(this.drpDetailCode.SelectedValue));
                this.drpUnitFrom.SelectedValue = unitConversionByConversionID.Tables[0].Rows[0]["UNIT_ID_FROM"].ToString();
                Utility.fillUnitTo(this.drpUnitTo, Convert.ToInt32(this.drpDetailCode.SelectedValue), Convert.ToInt32(this.drpUnitFrom.SelectedValue));
                this.drpUnitTo.SelectedValue = unitConversionByConversionID.Tables[0].Rows[0]["UNIT_ID_TO"].ToString();
                this.txtValueFrom.Text = "1";
                this.txtValueTo.Text = unitConversionByConversionID.Tables[0].Rows[0]["VALUE_TO"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Utility.fillDetailCode(this.drpDetailCode, AllConstraint.measurementTypeMasterId);
                Utility.fillUnit(this.drpUnitFrom, Convert.ToInt32(this.drpDetailCode.SelectedValue));
                int num = (!string.IsNullOrEmpty(this.drpDetailCode.SelectedValue) ? Convert.ToInt32(this.drpDetailCode.SelectedValue) : 0);
                Utility.fillUnitTo(this.drpUnitTo, num, (!string.IsNullOrEmpty(this.drpUnitFrom.SelectedValue) ? Convert.ToInt32(this.drpUnitFrom.SelectedValue) : 0));
            }
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnCancel.Text = "Cancel";
        }

        private void showDataInGridView(DataSet ds)
        {
            this.gvUnit.DataSource = ds;
            this.gvUnit.DataBind();
        }

        public void showDataInGridView()
        {
            DataSet allUnitConversion = this.objUnitBLL.GetAllUnitConversion(Convert.ToInt32(this.drpDetailCode.SelectedValue));
            this.gvUnit.DataSource = allUnitConversion;
            this.gvUnit.DataBind();
        }

        private bool Validation()
        {
            if (this.txtValueFrom.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Value From can not be Empty", MsgBoxs.enmMessageType.Attention);
                this.txtValueFrom.Focus();
                return false;
            }
            if (this.txtValueTo.Text.Trim().Length >= 1)
            {
                return true;
            }
            this.lblMessage.Text = "Value To  is mandatory. ";
            this.txtValueTo.Focus();
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