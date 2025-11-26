using AjaxControlToolkit;
using ASP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using NBR_VAT_GROUPOFCOM.UserControls;
using NBR_VAT_GROUPOFCOM.BLL;

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class SetItems : Page, IRequiresSessionState
    {
       
        private AddItemBLL objAddItemsBll = new AddItemBLL();

        private string enableObj = "";

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

        public SetItems()
        {
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            this.loadCategory();
            this.setAddModeForCategory();
            this.clearCategoryControlValue();
            this.modalPopupForAddCategory.Show();
        }

        protected void btnAddItems_Click(object sender, EventArgs e)
        {
            this.loadItem();
            this.setPropetiesTextLevel();
            this.clearItemControlData();
            this.setAddModeForAddItem();
            if (this.hnCategoryID.Value == "")
            {
                try
                {
                    int num = Convert.ToInt32(this.drpItemCategory.SelectedValue);
                    short num1 = 0;
                    if (this.hnCategoryLevel.Value != "")
                    {
                        num1 = Convert.ToInt16(this.hnCategoryLevel.Value);
                    }
                    if (num1 != 1)
                    {
                        this.cddItemCategory.SelectedValue = this.hnParentID.Value;
                        this.cddItemSubCategory.SelectedValue = num.ToString();
                    }
                    else
                    {
                        this.cddItemCategory.SelectedValue = num.ToString();
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    StackTrace stackTrace = new StackTrace(exception, true);
                    StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                    int fileLineNumber = frame.GetFileLineNumber();
                    BLL.Utility.InsertErrorTrackNew(exception.Message, "SetItem.aspx", "btnAddItems_Click", fileLineNumber);
                }
                this.drpItemCategory.Enabled = false;
            }
            else
            {
                try
                {
                    int num2 = Convert.ToInt32(this.hnCategoryID.Value);
                    short num3 = 0;
                    if (this.hnCategoryLevel.Value != "")
                    {
                        num3 = Convert.ToInt16(this.hnCategoryLevel.Value);
                    }
                    if (num3 != 1)
                    {
                        this.cddItemCategory.SelectedValue = this.hnParentID.Value;
                        this.cddItemSubCategory.SelectedValue = num2.ToString();
                    }
                    else
                    {
                        this.cddItemCategory.SelectedValue = num2.ToString();
                    }
                }
                catch (Exception exception3)
                {
                    Exception exception2 = exception3;
                    StackTrace stackTrace1 = new StackTrace(exception2, true);
                    StackFrame stackFrame = stackTrace1.GetFrame(stackTrace1.FrameCount - 1);
                    int fileLineNumber1 = stackFrame.GetFileLineNumber();
                   NBR_VAT_GROUPOFCOM.BLL.Utility.InsertErrorTrackNew(exception2.Message, "SetItem.aspx", "btnAddItems_Click", fileLineNumber1);
                }
                this.drpItemCategory.Enabled = false;
            }
            this.modalPopupForAddItem.Show();
            DataTable sKUCode = this.objAddItemsBll.GetSKU_Code();
            if (sKUCode.Rows.Count <= 0)
            {
                this.txtSKUCode.Text = "1";
                return;
            }
            TextBox str = this.txtSKUCode;
            long num4 = Convert.ToInt64(sKUCode.Rows[0]["sku_code"]) + (long)1;
            str.Text = num4.ToString();
        }

        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            this.loadSubCategory();
            this.clearSubCategoryControlValue();
            this.setAddModeForSubCategory();
            AddItemBLL addItemBLL = new AddItemBLL();
          BLL.Utility.fillItemCategoryDropDownListForAddSubItem(this.drpCategory);
            if (this.btnAddSubCategory.Text == "Edit Sub Category")
            {
                if (this.hnParentID.Value != "")
                {
                    try
                    {
                        this.drpCategory.SelectedValue = this.hnParentID.Value;
                    }
                    catch (Exception exception)
                    {
                           BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "btnAddSubCategory_Click");
                    }
                }
                int num = Convert.ToInt32(this.hnCategoryID.Value);
                DataSet categoryInfoByCategoryID = addItemBLL.GetCategoryInfoByCategoryID(num);
                try
                {
                    this.drpCategory.SelectedValue = categoryInfoByCategoryID.Tables[0].Rows[0]["PARENT_ID"].ToString();
                    this.txtSubCategory.Text = categoryInfoByCategoryID.Tables[0].Rows[0]["CATEGORY_NAME"].ToString();
                    this.txtSubDesc.Text = categoryInfoByCategoryID.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                }
                catch (Exception exception1)
                {
                       BLL.Utility.InsertErrorTrack(exception1.Message, "SetItem.aspx", "btnAddSubCategory_Click");
                }
            }
            else if (this.hnCategoryID.Value != "")
            {
                try
                {
                    int num1 = Convert.ToInt32(this.hnCategoryID.Value);
                    this.drpCategory.SelectedValue = num1.ToString();
                }
                catch (Exception exception2)
                {
                       BLL.Utility.InsertErrorTrack(exception2.Message, "SetItem.aspx", "btnAddSubCategory_Click");
                }
            }
            this.modalPopupForSubCategory.Show();
        }

        protected void btnCancelToSaveInvoice(object sender, EventArgs e)
        {
            this.Session["enableObj"] = "";
            this.mpeYesNoModal.Hide();
        }

        protected void btndeleteCategory_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.txtcatgID.Text);
            if (this.objAddItemsBll.getSubcategoryByCategoryId(num).Rows.Count >= 1)
            {
                this.MsgBoxs.AddMessage("Fail to delete.Sub Category exists of this Category.", MsgBoxs.enmMessageType.Error);
                return;
            }
            if (this.objAddItemsBll.DeleteItemCategory(num))
            {
                TreeLoad.LoadProblemTree(this.tvwCategory);
                this.MsgBoxs.AddMessage("Item Category Successfully Deleted.", MsgBoxs.enmMessageType.Success);
            }
        }

        protected void btndeleteSubCategory_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.txtSubCategoryId.Text);
            if (this.objAddItemsBll.getItemByCatSubCatId(num).Rows.Count >= 1)
            {
                this.MsgBoxs.AddMessage("Fail to delete.Item exists of this Sub Category.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForSubCategory.Show();
                return;
            }
            if (this.objAddItemsBll.DeleteItemSubCategory(num))
            {
                TreeLoad.LoadProblemTree(this.tvwCategory);
                this.MsgBoxs.AddMessage("Item Sub Category Successfully Deleted.", MsgBoxs.enmMessageType.Success);
            }
        }

        protected void btnEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                if (this.hnCategoryID.Value != "")
                {
                    int num = Convert.ToInt32(this.hnCategoryID.Value);
                    DataSet categoryInfoByCategoryID = addItemBLL.GetCategoryInfoByCategoryID(num);
                    if (categoryInfoByCategoryID != null && categoryInfoByCategoryID.Tables[0].Rows.Count > 0)
                    {
                        this.txtCategoryName.Text = categoryInfoByCategoryID.Tables[0].Rows[0]["CATEGORY_NAME"].ToString();
                        this.txtDescription.Text = categoryInfoByCategoryID.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                        this.setUpdateModeForCategory();
                        this.modalPopupForAddCategory.Show();
                    }
                }
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "btnEditCategory_Click");
            }
        }

        protected void btnNoToReloadTaxrate(object sender, EventArgs e)
        {
        }

        protected void btnOkToReload(object sender, EventArgs e)
        {
            if (this.Session["enableObj"].ToString() == "I")
            {
                SetItemDAO setItemDAO = this.fillItemProperties(new SetItemDAO());
                if (!this.objAddItemsBll.enableDeletedItem(setItemDAO))
                {
                    this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    return;
                }
                this.mpeYesNoModal.Hide();
                this.Session["enableObj"] = "";
                this.clearItemControlData();
                this.showItemDataInGridView();
                this.MsgBoxs.AddMessage("Item information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                return;
            }
            if (this.Session["enableObj"].ToString() == "C")
            {
                SetItemCategoryDAO setItemCategoryDAO = this.fillCategoryProperties(new SetItemCategoryDAO());
                if (!this.objAddItemsBll.enableDeletedCategory(setItemCategoryDAO))
                {
                    this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    this.modalPopupForAddCategory.Show();
                    return;
                }
                this.mpeYesNoModal.Hide();
                this.Session["enableObj"] = "";
                this.clearCategoryControlValue();
                TreeLoad.LoadProblemTree(this.tvwCategory);
                this.setButtonsForFirstTime();
                this.MsgBoxs.AddMessage("Item Category Successfully Saved.", MsgBoxs.enmMessageType.Success);
                return;
            }
            if (this.Session["enableObj"].ToString() == "SC")
            {
                SetItemCategoryDAO setItemCategoryDAO1 = this.fillSubCategoryProperties(new SetItemCategoryDAO());
                if (this.objAddItemsBll.enableDeletedSubCategory(setItemCategoryDAO1))
                {
                    this.mpeYesNoModal.Hide();
                    this.Session["enableObj"] = "";
                    TreeLoad.LoadProblemTree(this.tvwCategory);
                    this.setButtonsForFirstTime();
                    this.clearSubCategoryControlsValue();
                    this.MsgBoxs.AddMessage("Item sub category Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void btnOkToReloadTaxrate(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(this.Session["itemId"]);
            base.Response.Redirect(string.Concat("Item_Tax_Values_NewUpdate.aspx?itemId=", num));
        }

        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validation())
                {
                    AddItemBLL addItemBLL = new AddItemBLL();
                    SetItemCategoryDAO setItemCategoryDAO = new SetItemCategoryDAO();
                    setItemCategoryDAO = this.fillCategoryProperties(setItemCategoryDAO);
                    if (this.btnSaveCategory.Text != "Save")
                    {
                        setItemCategoryDAO.UserIdUpdate = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
                        setItemCategoryDAO.CategoryID = Convert.ToInt32(this.txtcatgID.Text);
                        if (!addItemBLL.UpdateItemCategory(setItemCategoryDAO))
                        {
                            this.MsgBoxs.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.clearCategoryControlValue();
                            this.setAddModeForCategory();
                            TreeLoad.LoadProblemTree(this.tvwCategory);
                            this.setButtonsForFirstTime();
                            this.MsgBoxs.AddMessage("Item Category Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        }
                    }
                    else if (addItemBLL.checkIfCategoryExists(setItemCategoryDAO))
                    {
                        this.Session["enableObj"] = "C";
                        this.mpeYesNoModal.Show();
                    }
                    else if (!addItemBLL.InsertItemCategory(setItemCategoryDAO))
                    {
                        this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        this.modalPopupForAddCategory.Show();
                    }
                    else
                    {
                        this.clearCategoryControlValue();
                        TreeLoad.LoadProblemTree(this.tvwCategory);
                        this.setButtonsForFirstTime();
                        this.MsgBoxs.AddMessage("Item Category Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "btnSaveCategory_Click");
            }
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ItemValidation())
                {
                    string empty = string.Empty;
                    SetItemDAO setItemDAO = new SetItemDAO();
                    setItemDAO = this.fillItemProperties(setItemDAO);
                    this.Session["itemInfo"] = setItemDAO;
                    if (this.btnSave.Text != "Save")
                    {
                        try
                        {
                            if (this.txtSearchItmId.Text != "")
                            {
                                setItemDAO.ItemID = Convert.ToInt32(this.txtSearchItmId.Text);
                            }
                            else
                            {
                                setItemDAO.ItemID = Convert.ToInt32(this.hnItemID.Value);
                            }
                            setItemDAO.UserIdUpdate = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                            if (!this.objAddItemsBll.updateItem(setItemDAO))
                            {
                                this.MsgBoxs.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                            }
                            else
                            {
                                this.clearItemControlData();
                                this.showItemDataInGridView();
                                this.setAddModeForAddItem();
                                this.MsgBoxs.AddMessage("Item information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                            }
                        }
                        catch (Exception exception)
                        {
                            ReallySimpleLog.WriteLog(exception);
                        }
                    }
                    else
                    {
                        DataSet dataSet = this.objAddItemsBll.CheckDeletedItem(setItemDAO);
                        if (this.objAddItemsBll.CheckExistingItem(setItemDAO).Tables[0].Rows.Count > 0)
                        {
                            this.MsgBoxs.AddMessage("This item already exists for this subcategory. Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            this.Session["enableObj"] = "I";
                            this.mpeYesNoModal.Show();
                        }
                        else
                        {
                            int num = this.objAddItemsBll.InsertItem(setItemDAO);
                            if (num <= 0)
                            {
                                this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                            else
                            {
                                this.clearItemControlData();
                                this.showItemDataInGridView();
                                this.mpeTaxPanel.Show();
                                this.lblMessageTax.Text = " Item Informations Save Successfully";
                                this.Session["itemId"] = num;
                            }
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                Exception exception1 = exception2;
                StackTrace stackTrace = new StackTrace(exception1, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                   BLL.Utility.InsertErrorTrackNew(exception1.Message, "SetItem.aspx", "btnSaveItem_Click", fileLineNumber);
            }
        }

        protected void btnSaveSubCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.subValidation())
                {
                    AddItemBLL addItemBLL = new AddItemBLL();
                    SetItemCategoryDAO setItemCategoryDAO = new SetItemCategoryDAO();
                    setItemCategoryDAO = this.fillSubCategoryProperties(setItemCategoryDAO);
                    if (this.btnSaveSubCategory.Text != "Save")
                    {
                        try
                        {
                            setItemCategoryDAO.CategoryID = Convert.ToInt32(this.txtSubCategoryId.Text);
                            setItemCategoryDAO.UserIdUpdate = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
                            if (addItemBLL.UpdateSubCategory(setItemCategoryDAO))
                            {
                                TreeLoad.LoadProblemTree(this.tvwCategory);
                                this.setButtonsForFirstTime();
                                this.clearSubCategoryControlsValue();
                                this.setAddModeForSubCategory();
                                this.MsgBoxs.AddMessage("Sub category information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                            }
                        }
                        catch
                        {
                        }
                    }
                    else if (addItemBLL.checkIfSubCategoryExists(setItemCategoryDAO))
                    {
                        this.Session["enableObj"] = "SC";
                        this.mpeYesNoModal.Show();
                    }
                    else if (!addItemBLL.InsertSubCategory(setItemCategoryDAO))
                    {
                        this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        TreeLoad.LoadProblemTree(this.tvwCategory);
                        this.setButtonsForFirstTime();
                        this.clearSubCategoryControlsValue();
                        this.MsgBoxs.AddMessage("Item sub category Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    }
                }
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "btnSaveSubCategory_Click");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string text = this.txtSKUCode.Text;
            this.setPropetiesTextLevel();
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                string str = this.drpSearchItem.SelectedItem.ToString();
                DataSet itemInfoByItem = addItemBLL.getItemInfoByItem(str);
                try
                {
                    if (itemInfoByItem.Tables[0].Rows.Count <= 0)
                    {
                        this.setPropetiesTextLevel();
                        this.clearItemControlData();
                        this.setAddModeForAddItem();
                        this.modalPopupForAddItem.Show();
                        this.MsgBoxs.AddMessage("No Item Found.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        if (itemInfoByItem.Tables[0].Rows[0]["PARENT_ID"].ToString() != "0")
                        {
                            this.cddItemCategory.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["PARENT_ID"].ToString();
                            this.cddItemSubCategory.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["CATEGORY_ID"].ToString();
                        }
                        else
                        {
                            this.cddItemCategory.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["CATEGORY_ID"].ToString();
                        }
                        this.txtSearchItmId.Text = itemInfoByItem.Tables[0].Rows[0]["ITEM_ID"].ToString();
                        this.drpTypeofMsnt.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["MSRMT_TYPE_ID"].ToString();
                        this.drpTypeofMsnt_SelectedIndexChanged(null, null);
                        this.drpUnit.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["UNIT_ID"].ToString();
                        this.txtItemName.Text = itemInfoByItem.Tables[0].Rows[0]["ITEM_NAME"].ToString();
                        this.txtBrandName.Text = itemInfoByItem.Tables[0].Rows[0]["brand_name"].ToString();
                        this.txtSpecification.Text = itemInfoByItem.Tables[0].Rows[0]["ITEM_SPECIFICATION"].ToString();
                        this.txtHSHeading.Text = itemInfoByItem.Tables[0].Rows[0]["hs_code_heading"].ToString();
                        this.txtHSSuffix.Text = itemInfoByItem.Tables[0].Rows[0]["hs_code_suffix"].ToString();
                        this.txtSKUCode.Text = itemInfoByItem.Tables[0].Rows[0]["ITEM_SKU"].ToString();
                        this.txtModelNo.Text = itemInfoByItem.Tables[0].Rows[0]["model_no"].ToString();
                        if (Convert.ToDecimal(itemInfoByItem.Tables[0].Rows[0]["weight"]) == new decimal(0))
                        {
                            this.txtWeight.Text = "";
                        }
                        else
                        {
                            this.txtWeight.Text = Utilities.formatFraction(Convert.ToDecimal(itemInfoByItem.Tables[0].Rows[0]["weight"]));
                        }
                        this.drpWeightUnit.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["weight_unit_id"].ToString();
                        if (itemInfoByItem.Tables[0].Rows[0]["PROP1_REQUIRED"] != null)
                        {
                            this.chkProOne.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["PROP1_REQUIRED"]);
                        }
                        if (itemInfoByItem.Tables[0].Rows[0]["PROP2_REQUIRED"] != null)
                        {
                            this.chkProTwo.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["PROP2_REQUIRED"]);
                        }
                        if (itemInfoByItem.Tables[0].Rows[0]["PROP3_REQUIRED"] != null)
                        {
                            this.chkProThree.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["PROP3_REQUIRED"]);
                        }
                        if (itemInfoByItem.Tables[0].Rows[0]["PROP4_REQUIRED"] != null)
                        {
                            this.chkProFour.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["PROP4_REQUIRED"]);
                        }
                        if (itemInfoByItem.Tables[0].Rows[0]["PROP5_REQUIRED"] != null)
                        {
                            this.chkProFive.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["PROP5_REQUIRED"]);
                        }
                        this.drpVATRebate.SelectedValue = "0";
                        if (itemInfoByItem.Tables[0].Rows[0]["item_type"] == null)
                        {
                            this.rdItem.Checked = true;
                        }
                        else if (itemInfoByItem.Tables[0].Rows[0]["item_type"].ToString() == "I")
                        {
                            this.rdItem.Checked = true;
                            this.drpProductType.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["product_type"].ToString();
                        }
                        else if (itemInfoByItem.Tables[0].Rows[0]["item_type"].ToString() != "S")
                        {
                            if (itemInfoByItem.Tables[0].Rows[0]["item_type"].ToString() != "U")
                            {
                                this.rdItem.Checked = true;
                            }
                            else
                            {
                                this.rdUtility.Checked = true;
                                this.drpVATRebate.SelectedValue = itemInfoByItem.Tables[0].Rows[0]["vat_rebate"].ToString();
                            }
                        }
                        else if (itemInfoByItem.Tables[0].Rows[0]["product_type"].ToString() == "C")
                        {
                            this.rdService.Checked = true;
                            this.drpServiceType.SelectedValue = "1";
                        }
                        else if (itemInfoByItem.Tables[0].Rows[0]["product_type"].ToString() != "R")
                        {
                            this.rdService.Checked = true;
                            this.drpServiceType.SelectedValue = "2";
                        }
                        else
                        {
                            this.rdService.Checked = true;
                            this.drpServiceType.SelectedValue = "3";
                        }
                        if (itemInfoByItem.Tables[0].Rows[0]["SUPPLIER_REQUIRED"] != null)
                        {
                            this.chkIsSupplierRequired.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["SUPPLIER_REQUIRED"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_truncated"])
                        {
                            this.chkIsTruncated.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_truncated"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_tarrif"])
                        {
                            this.chkIsTarrif.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_tarrif"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_zero_rate"])
                        {
                            this.chkZeroRate.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_zero_rate"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["expiry_date_required"])
                        {
                            this.chkIsExpiryDtRequired.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["expiry_date_required"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_exempted"])
                        {
                            this.chkIsExempted.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_exempted"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_rebatable"])
                        {
                            this.chkIsRebatable.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_rebatable"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_mrp"])
                        {
                            this.chkMrp.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_mrp"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_vds"])
                        {
                            this.chkIsVDS.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_vds"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_for_all_bss_unit"])
                        {
                            this.chkIsAllBssUnit.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_for_all_bss_unit"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_price_declaration"])
                        {
                            this.chkIsPriceDec.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_price_declaration"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_healthcare_surcharge"])
                        {
                            this.chkIsHCS.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_healthcare_surcharge"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_item_set"])
                        {
                            this.chkItemSet.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_item_set"]);
                        }
                        if ((bool)itemInfoByItem.Tables[0].Rows[0]["is_reusable"])
                        {
                            this.chkItemSet.Checked = Convert.ToBoolean(itemInfoByItem.Tables[0].Rows[0]["is_reusable"]);
                        }
                        this.setUpdateModeForAddItem();
                        this.modalPopupForAddItem.Show();
                    }
                }
                catch (Exception exception)
                {
                       BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "btnSearch_Click");
                }
            }
            catch (Exception exception1)
            {
                   BLL.Utility.InsertErrorTrack(exception1.Message, "SetItem.aspx", "btnSearch_Click");
            }
            this.txtSKUCode.Text = text;
        }

        protected void btnSearchCategory_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                string str = this.drpSearchCategory.SelectedItem.ToString();
                DataSet categoryInfoByCategory = addItemBLL.GetCategoryInfoByCategory(str);
                if (categoryInfoByCategory == null || categoryInfoByCategory.Tables[0].Rows.Count <= 0)
                {
                    this.setAddModeForCategory();
                    this.clearCategoryControlValue();
                    this.modalPopupForAddCategory.Show();
                    this.MsgBoxs.AddMessage("No Category Found.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.txtcatgID.Text = categoryInfoByCategory.Tables[0].Rows[0]["CATEGORY_ID"].ToString();
                    this.txtCategoryName.Text = categoryInfoByCategory.Tables[0].Rows[0]["CATEGORY_NAME"].ToString();
                    this.txtDescription.Text = categoryInfoByCategory.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                    this.setUpdateModeForCategory();
                    this.modalPopupForAddCategory.Show();
                }
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "btnSearchCategory_Click");
            }
        }

        protected void btnSearchSubcatg_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                   BLL.Utility.fillItemCategoryDropDownListForAddSubItem(this.drpCategory);
                int num = Convert.ToInt32(this.drpSearchSubcatg.SelectedValue);
                DataSet subCategoryInfoByCategory = addItemBLL.GetSubCategoryInfoByCategory(num);
                if (subCategoryInfoByCategory == null || subCategoryInfoByCategory.Tables[0].Rows.Count <= 0)
                {
                    this.setAddModeForSubCategory();
                    this.clearSubCategoryControlValue();
                    this.modalPopupForSubCategory.Show();
                    this.MsgBoxs.AddMessage("No Sub Category Found.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.drpCategory.SelectedValue = subCategoryInfoByCategory.Tables[0].Rows[0]["PARENT_ID"].ToString();
                    this.txtSubCategory.Text = subCategoryInfoByCategory.Tables[0].Rows[0]["CATEGORY_NAME"].ToString();
                    this.txtSubCategoryId.Text = subCategoryInfoByCategory.Tables[0].Rows[0]["CATEGORY_ID"].ToString();
                    this.txtSubDesc.Text = subCategoryInfoByCategory.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                    this.setpdateModeForSubCategory();
                    this.modalPopupForSubCategory.Show();
                }
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "btnSearchSubcatg_Click");
            }
        }

        private void clearCategoryControlValue()
        {
            this.drpSearchCategory.SelectedValue = "-99";
            this.txtCategoryName.Text = "";
            this.txtDescription.Text = "";
        }

        private void clearItemControlData()
        {
            try
            {
                this.drpWeightUnit.SelectedValue = "-99";
                this.txtWeight.Text = "";
                this.drpServiceType.SelectedValue = "";
                this.drpProductType.SelectedValue = "";
                this.txtBrandName.Text = "";
                this.txtSKUCode.Text = "";
                this.drpSearchItem.SelectedValue = "-99";
                this.drpTypeofMsnt.SelectedValue = "-99";
                this.drpUnit.Items.Clear();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpUnit.Items.Insert(0, listItem);
                this.txtItemName.Text = "";
                this.txtSpecification.Text = "";
                this.txtHSHeading.Text = "";
                this.txtHSSuffix.Text = "";
                this.drpItemProperty.ClearSelection();
                this.chkProOne.Checked = false;
                this.chkProTwo.Checked = false;
                this.chkProThree.Checked = false;
                this.chkProFour.Checked = false;
                this.chkProFive.Checked = false;
                this.chkIsSupplierRequired.Checked = false;
                this.chkIsExpiryDtRequired.Checked = false;
                this.chkIsExempted.Checked = false;
                this.chkIsRebatable.Checked = false;
                this.chkIsTruncated.Checked = false;
                this.chkIsTarrif.Checked = false;
                this.chkZeroRate.Checked = false;
                this.drpVATRebate.SelectedValue = "0";
                this.chkReusable.Checked = false;
                this.chkIsRebatable.Checked = false;
                this.chkIsVDS.Checked = false;
                this.chkIsAllBssUnit.Checked = false;
                this.chkIsPriceDec.Checked = false;
                this.chkIsHCS.Checked = false;
                this.chkItemSet.Checked = false;
                this.rdItem.Checked = true;
                this.rdService.Checked = false;
                this.rdUtility.Checked = false;
                this.chkIsRebatable.Checked = false;
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "clearItemControlData");
            }
        }

        private void clearSubCategoryControlsValue()
        {
            this.txtSubCategory.Text = "";
            this.txtSubDesc.Text = "";
        }

        private void clearSubCategoryControlValue()
        {
            this.drpSearchCategory.SelectedValue = "-99";
            this.txtSubCategory.Text = "";
            this.txtSubDesc.Text = "";
        }

        private void displayTotalRecordsFound()
        {
            if (this.gvItem.Rows.Count <= 0)
            {
                this.lblTotalRow.Text = "";
            }
            else if (this.gvItem.Rows[0].Cells[0].Text != "No Item(s) Found")
            {
                int count = this.gvItem.Rows.Count;
                this.lblTotalRow.Text = string.Concat("Total ", count, " record(s) found.");
                return;
            }
        }

        protected void drpProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpProductType.SelectedValue == "S")
            {
                this.drpTypeofMsnt.SelectedValue = "15";
                this.LoadUnit();
            }
            this.modalPopupForAddItem.Show();
        }

        protected void drpTypeofMsnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadUnit();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpUnit.Items.Insert(0, listItem);
                this.modalPopupForAddItem.Show();
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "drpTypeofMsnt_SelectedIndexChanged");
            }
        }

        private void enableDisableButton(DataSet ds)
        {
            short num = Convert.ToInt16(ds.Tables[0].Rows[0]["CATEGORY_LEVEL"]);
            this.hnCategoryLevel.Value = num.ToString();
            this.hnParentID.Value = ds.Tables[0].Rows[0]["PARENT_ID"].ToString();
            short num1 = Convert.ToInt16(ds.Tables[0].Rows[0]["IS_LEAF"]);
            string str = ds.Tables[0].Rows[0]["category_type"].ToString();
            if (str == "P")
            {
                this.btnAddCategory.Enabled = true;
                this.btnEditCategory.Enabled = false;
                this.btnAddSubCategory.Enabled = false;
                this.btnAddItems.Enabled = false;
                return;
            }
            if (num == 1)
            {
                if (str == "L")
                {
                    this.btnEditCategory.Enabled = false;
                }
                this.setAddModeForSubCategory();
                if (num1 == 0)
                {
                    this.btnAddCategory.Enabled = true;
                    this.btnAddSubCategory.Enabled = true;
                    this.btnAddItems.Enabled = true;
                    return;
                }
                if (num1 == 1)
                {
                    this.btnAddCategory.Enabled = true;
                    this.btnAddSubCategory.Enabled = true;
                    this.btnAddItems.Enabled = false;
                    return;
                }
                if (num1 == 2)
                {
                    this.btnAddCategory.Enabled = true;
                    this.btnAddSubCategory.Enabled = false;
                    this.btnAddItems.Enabled = true;
                    return;
                }
            }
            else if (num == 2)
            {
                this.btnEditCategory.Enabled = false;
                this.setUpdateModeForSubCategory();
                if (num1 == 0)
                {
                    this.btnAddCategory.Enabled = false;
                    this.btnAddSubCategory.Enabled = true;
                    this.btnAddItems.Enabled = true;
                    return;
                }
                if (num1 == 2)
                {
                    this.btnAddCategory.Enabled = false;
                    this.btnAddSubCategory.Enabled = true;
                    this.btnAddItems.Enabled = true;
                }
            }
        }

        private SetItemCategoryDAO fillCategoryProperties(SetItemCategoryDAO objCategoryDAO)
        {
            objCategoryDAO.Organization_id = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            objCategoryDAO.CategoryName = Utilities.ReplaceQuotes(this.txtCategoryName.Text.Trim());
            objCategoryDAO.Description = Utilities.ReplaceQuotes(this.txtDescription.Text.Trim());
            objCategoryDAO.CategoryLevel = 1;
            objCategoryDAO.UserIdInsert = 1;
            return objCategoryDAO;
        }

        private SetItemDAO fillItemProperties(SetItemDAO objItemDao)
        {
            try
            {
                objItemDao.Organization_id = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                if (!string.IsNullOrEmpty(this.drpItemCategory.SelectedValue))
                {
                    objItemDao.CategoryID = Convert.ToInt32(this.drpItemCategory.SelectedValue);
                    objItemDao.MainCategoryID = Convert.ToInt32(this.drpItemCategory.SelectedValue);
                    objItemDao.ParentID = Convert.ToInt32(this.drpItemCategory.SelectedValue);
                }
                if (!string.IsNullOrEmpty(this.drpItemSubCategory.SelectedValue))
                {
                    objItemDao.CategoryID = Convert.ToInt32(this.drpItemSubCategory.SelectedValue);
                }
                objItemDao.ItemName = Utilities.ReplaceQuotes(this.txtItemName.Text.Trim());
                objItemDao.ItemSpecification = Utilities.ReplaceQuotes(this.txtSpecification.Text.Trim());
                List<int> itemProperty = this.GetItemProperty();
                for (int i = 0; i < itemProperty.Count; i++)
                {
                    if (i == 0)
                    {
                        objItemDao.Prop1Required = Convert.ToBoolean(itemProperty[i]);
                    }
                    else if (i == 1)
                    {
                        objItemDao.Prop2Required = Convert.ToBoolean(itemProperty[i]);
                    }
                    else if (i == 2)
                    {
                        objItemDao.Prop3Required = Convert.ToBoolean(itemProperty[i]);
                    }
                    else if (i == 3)
                    {
                        objItemDao.Prop4Required = Convert.ToBoolean(itemProperty[i]);
                    }
                    else if (i == 4)
                    {
                        objItemDao.Prop5Required = Convert.ToBoolean(itemProperty[i]);
                    }
                }
                if (this.chkIsSupplierRequired.Checked)
                {
                    objItemDao.SupplierRequired = true;
                }
                if (this.chkIsExpiryDtRequired.Checked)
                {
                    objItemDao.ExpiryDateRequired = true;
                }
            Label0:
                foreach (ListItem item in this.drpItemProperty.Items)
                {
                    if (!item.Selected)
                    {
                        continue;
                    }
                    int num = 1;
                    while (num <= 1)
                    {
                        if (objItemDao.propertyId1 == 0)
                        {
                            objItemDao.propertyId1 = Convert.ToInt16(item.Value);
                            goto Label0;
                        }
                        else if (objItemDao.propertyId2 == 0)
                        {
                            objItemDao.propertyId2 = Convert.ToInt16(item.Value);
                            goto Label0;
                        }
                        else if (objItemDao.propertyId3 == 0)
                        {
                            objItemDao.propertyId3 = Convert.ToInt16(item.Value);
                            goto Label0;
                        }
                        else if (objItemDao.propertyId4 == 0)
                        {
                            objItemDao.propertyId4 = Convert.ToInt16(item.Value);
                            goto Label0;
                        }
                        else if (objItemDao.propertyId5 != 0)
                        {
                            num++;
                        }
                        else
                        {
                            objItemDao.propertyId5 = Convert.ToInt16(item.Value);
                            goto Label0;
                        }
                    }
                }
                objItemDao.IsVDS = this.chkIsVDS.Checked;
                objItemDao.Truncated = this.chkIsTruncated.Checked;
                objItemDao.Tarrif = this.chkIsTarrif.Checked;
                objItemDao.ZeroRate = this.chkZeroRate.Checked;
                objItemDao.Exempted = this.chkIsExempted.Checked;
                objItemDao.Rebatable = this.chkIsRebatable.Checked;
                objItemDao.Mrp = this.chkMrp.Checked;
                objItemDao.ModelNo = this.txtModelNo.Text.Trim();
                objItemDao.IsAllBssUnt = this.chkIsAllBssUnit.Checked;
                objItemDao.IsPriceDec = this.chkIsPriceDec.Checked;
                objItemDao.IsHCS = this.chkIsHCS.Checked;
                objItemDao.IsSetItem = this.chkItemSet.Checked;
                objItemDao.IsReusable = this.chkReusable.Checked;
                objItemDao.UserIdInsert = 1;
                objItemDao.Weight = (!string.IsNullOrEmpty(this.txtWeight.Text) ? Convert.ToDecimal(this.txtWeight.Text) : new decimal(0));
                objItemDao.MesurementIDM = AllConstraint.measurementTypeMasterId;
                if (!string.IsNullOrEmpty(this.drpTypeofMsnt.SelectedValue))
                {
                    objItemDao.MesurementIDD = Convert.ToInt16(this.drpTypeofMsnt.SelectedValue);
                }
                if (!string.IsNullOrEmpty(this.drpUnit.SelectedValue))
                {
                    objItemDao.UnitID = Convert.ToInt16(this.drpUnit.SelectedValue);
                }
                if (this.drpUnit.SelectedValue != "-99")
                {
                    objItemDao.weightUnitID = Convert.ToInt16(this.drpWeightUnit.SelectedValue);
                }
                objItemDao.HsHeading = Utilities.ReplacedotQuotes(this.txtHSHeading.Text.Trim());
                objItemDao.HsSuffix = Utilities.ReplaceQuotes(this.txtHSSuffix.Text.Trim());
                objItemDao.HsCode = string.Concat(objItemDao.HsHeading, '.', objItemDao.HsSuffix);
                objItemDao.VatRebate = 0;
                if (this.rdItem.Checked)
                {
                    objItemDao.ItemType = 'I';
                    objItemDao.ProductType = Convert.ToChar(this.drpProductType.SelectedValue);
                }
                else if (!this.rdService.Checked)
                {
                    if (this.rdUtility.Checked)
                    {
                        objItemDao.ItemType = 'U';
                        objItemDao.ProductType = 'R';
                    }
                }
                else if (this.drpServiceType.SelectedValue == "1")
                {
                    objItemDao.ItemType = 'S';
                    objItemDao.ProductType = 'C';
                }
                else if (this.drpServiceType.SelectedValue != "3")
                {
                    objItemDao.ItemType = 'S';
                    objItemDao.ProductType = 'F';
                }
                else
                {
                    objItemDao.ItemType = 'S';
                    objItemDao.ProductType = 'R';
                }
                objItemDao.VatRebate = Convert.ToDouble(this.drpVATRebate.SelectedValue);
                objItemDao.SKU = (!string.IsNullOrEmpty(this.txtSKUCode.Text) ? this.txtSKUCode.Text.Trim() : string.Empty);
                objItemDao.brandName = Utilities.ReplaceQuotes(this.txtBrandName.Text.Trim());
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                   BLL.Utility.InsertErrorTrackNew(exception.Message, "SetItem.aspx", "fillItemProperties", fileLineNumber);
            }
            return objItemDao;
        }

        public static CheckBoxList FillItemPropertyDropDownList(CheckBoxList drpItemPorperty)
        {
            try
            {
                SetItemPropertyBLL setItemPropertyBLL = new SetItemPropertyBLL();
                DataTable itemPropertybyMasterID = setItemPropertyBLL.GetItemPropertybyMasterID(Convert.ToInt16(AllConstraint.PropertyTypeM));
                if (itemPropertybyMasterID.Rows.Count <= 0)
                {
                    drpItemPorperty.Items.Clear();
                }
                else
                {
                    drpItemPorperty.DataSource = itemPropertybyMasterID;
                    drpItemPorperty.DataTextField = itemPropertybyMasterID.Columns["CODE_NAME"].ToString();
                    drpItemPorperty.DataValueField = itemPropertybyMasterID.Columns["CODE_ID_D"].ToString();
                    drpItemPorperty.DataBind();
                }
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "FillItemPropertyDropDownList");
            }
            return drpItemPorperty;
        }

        private SetItemCategoryDAO fillSubCategoryProperties(SetItemCategoryDAO objSubCategoryDAO)
        {
            objSubCategoryDAO.Organization_id = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            objSubCategoryDAO.CategoryName = Utilities.ReplaceQuotes(this.txtSubCategory.Text.Trim());
            objSubCategoryDAO.Description = Utilities.ReplaceQuotes(this.txtSubDesc.Text.Trim());
            objSubCategoryDAO.UserIdInsert = 1;
            objSubCategoryDAO.CategoryLevel = 2;
            objSubCategoryDAO.ParentID = Convert.ToInt32(this.drpCategory.SelectedValue);
            return objSubCategoryDAO;
        }

        private List<int> GetItemProperty()
        {
            List<int> nums = new List<int>();
            foreach (ListItem item in this.drpItemProperty.Items)
            {
                if (!item.Selected)
                {
                    nums.Add(0);
                }
                else
                {
                    nums.Add(1);
                }
            }
            return nums;
        }

        protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvItem.PageIndex = e.NewPageIndex;
            this.showItemDataInGridView();
        }

        protected void gvItem_PreRender(object sender, EventArgs e)
        {
            try
            {
                this.gvItem.UseAccessibleHeader = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                   BLL.Utility.InsertErrorTrackNew(exception.Message, "SetItem.aspx", "gvItem_PreRender", fileLineNumber);
            }
        }

        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell item = e.Row.Cells[1];
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((ImageButton)e.Row.Cells[1].Controls[0]).Attributes["onclick"] = "if(!confirm('Are you sure you want to delete?'))return   false;";
                }
            }
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (this.btnAddItems.Enabled)
                {
                    AddItemBLL addItemBLL = new AddItemBLL();
                    int num = Convert.ToInt32(this.gvItem.DataKeys[e.RowIndex].Value.ToString());
                    DataTable itemFromPurchaseDetail = addItemBLL.GetItemFromPurchaseDetail(num);
                    DataTable itemFromSalesDetail = addItemBLL.GetItemFromSalesDetail(num);
                    DataTable itemFromPriceRowItem = addItemBLL.GetItemFromPriceRowItem(num);
                    if (itemFromPurchaseDetail != null && itemFromPurchaseDetail.Rows.Count > 0 || itemFromSalesDetail != null && itemFromSalesDetail.Rows.Count > 0 || itemFromPriceRowItem != null && itemFromPriceRowItem.Rows.Count > 0)
                    {
                        this.MsgBoxs.AddMessage("Fail to delete. Transaction exists.", MsgBoxs.enmMessageType.Error);
                    }
                    else if (!addItemBLL.deleteItem(num))
                    {
                        this.MsgBoxs.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.MsgBoxs.AddMessage("Successfully Deleted.", MsgBoxs.enmMessageType.Success);
                        this.showItemDataInGridView();
                    }
                }
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "gvItem_RowDeleting");
            }
        }

        protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.clearItemControlData();
            if (!this.btnAddItems.Enabled)
            {
                return;
            }
            this.setPropetiesTextLevel();
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = Convert.ToInt32(this.gvItem.SelectedDataKey["ITEM_ID"]);
                this.hnItemID.Value = num.ToString();
                DataSet itemInfoByItemID = addItemBLL.getItemInfoByItemID(num);
                try
                {
                    if (itemInfoByItemID.Tables[0].Rows[0]["PARENT_ID"].ToString() != "0")
                    {
                        this.cddItemCategory.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["PARENT_ID"].ToString();
                        this.cddItemSubCategory.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["CATEGORY_ID"].ToString();
                    }
                    else
                    {
                        this.cddItemCategory.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["CATEGORY_ID"].ToString();
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["weight_unit_id"].ToString() != "")
                    {
                        this.drpWeightUnit.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["weight_unit_id"].ToString();
                    }
                    this.drpTypeofMsnt.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["MSRMT_TYPE_ID"].ToString();
                    this.drpTypeofMsnt_SelectedIndexChanged(null, null);
                    this.drpUnit.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["UNIT_ID"].ToString();
                    this.txtItemName.Text = itemInfoByItemID.Tables[0].Rows[0]["ITEM_NAME"].ToString();
                    this.txtBrandName.Text = itemInfoByItemID.Tables[0].Rows[0]["brand_name"].ToString();
                    this.txtSpecification.Text = itemInfoByItemID.Tables[0].Rows[0]["ITEM_SPECIFICATION"].ToString();
                    this.txtHSHeading.Text = itemInfoByItemID.Tables[0].Rows[0]["hs_code_heading"].ToString();
                    this.txtHSSuffix.Text = itemInfoByItemID.Tables[0].Rows[0]["hs_code_suffix"].ToString();
                    this.txtSKUCode.Text = itemInfoByItemID.Tables[0].Rows[0]["ITEM_SKU"].ToString();
                    this.txtModelNo.Text = itemInfoByItemID.Tables[0].Rows[0]["model_no"].ToString();
                    if (Convert.ToDecimal(itemInfoByItemID.Tables[0].Rows[0]["weight"]) != new decimal(0))
                    {
                        this.txtWeight.Text = Utilities.formatFraction(Convert.ToDecimal(itemInfoByItemID.Tables[0].Rows[0]["weight"])).ToString();
                    }
                    else
                    {
                        this.txtWeight.Text = "";
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["PROP1_REQUIRED"] != null)
                    {
                        this.chkProOne.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["PROP1_REQUIRED"]);
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["PROP2_REQUIRED"] != null)
                    {
                        this.chkProTwo.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["PROP2_REQUIRED"]);
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["PROP3_REQUIRED"] != null)
                    {
                        this.chkProThree.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["PROP3_REQUIRED"]);
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["PROP4_REQUIRED"] != null)
                    {
                        this.chkProFour.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["PROP4_REQUIRED"]);
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["PROP5_REQUIRED"] != null)
                    {
                        this.chkProFive.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["PROP5_REQUIRED"]);
                    }
                    foreach (ListItem item in this.drpItemProperty.Items)
                    {
                        if (Convert.ToInt16(itemInfoByItemID.Tables[0].Rows[0]["property_id1"]) == Convert.ToInt16(item.Value))
                        {
                            item.Selected = true;
                        }
                        if (Convert.ToInt16(itemInfoByItemID.Tables[0].Rows[0]["property_id2"]) == Convert.ToInt16(item.Value))
                        {
                            item.Selected = true;
                        }
                        if (Convert.ToInt16(itemInfoByItemID.Tables[0].Rows[0]["property_id3"]) == Convert.ToInt16(item.Value))
                        {
                            item.Selected = true;
                        }
                        if (Convert.ToInt16(itemInfoByItemID.Tables[0].Rows[0]["property_id4"]) == Convert.ToInt16(item.Value))
                        {
                            item.Selected = true;
                        }
                        if (Convert.ToInt16(itemInfoByItemID.Tables[0].Rows[0]["property_id5"]) != Convert.ToInt16(item.Value))
                        {
                            continue;
                        }
                        item.Selected = true;
                    }
                    this.drpVATRebate.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["vat_rebate"].ToString();
                    if (itemInfoByItemID.Tables[0].Rows[0]["item_type"] == null)
                    {
                        this.rdItem.Checked = true;
                    }
                    else if (itemInfoByItemID.Tables[0].Rows[0]["item_type"].ToString() == "I")
                    {
                        this.rdService.Checked = false;
                        this.rdItem.Checked = true;
                        this.drpProductType.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["product_type"].ToString();
                    }
                    else if (itemInfoByItemID.Tables[0].Rows[0]["item_type"].ToString() != "S")
                    {
                        if (itemInfoByItemID.Tables[0].Rows[0]["item_type"].ToString() != "U")
                        {
                            this.rdItem.Checked = true;
                        }
                        else
                        {
                            this.rdUtility.Checked = true;
                            this.drpVATRebate.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["vat_rebate"].ToString();
                        }
                    }
                    else if (itemInfoByItemID.Tables[0].Rows[0]["product_type"].ToString() == "C")
                    {
                        this.rdItem.Checked = false;
                        this.rdService.Checked = true;
                        this.drpServiceType.SelectedValue = "1";
                        this.drpServiceType.Enabled = true;
                    }
                    else if (itemInfoByItemID.Tables[0].Rows[0]["product_type"].ToString() != "R")
                    {
                        this.rdItem.Checked = false;
                        this.rdService.Checked = true;
                        this.drpServiceType.SelectedValue = "2";
                        this.drpServiceType.Enabled = true;
                    }
                    else
                    {
                        this.rdItem.Checked = false;
                        this.rdService.Checked = true;
                        this.drpServiceType.SelectedValue = "3";
                        this.drpServiceType.Enabled = true;
                    }
                    this.chkIsSupplierRequired.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["SUPPLIER_REQUIRED"]);
                    this.chkIsTruncated.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_truncated"]);
                    this.chkIsTarrif.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_tarrif"]);
                    this.chkZeroRate.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_zero_rate"]);
                    this.chkIsExpiryDtRequired.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["expiry_date_required"]);
                    this.chkIsExempted.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_exempted"]);
                    this.chkIsRebatable.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_rebatable"]);
                    this.chkMrp.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_mrp"]);
                    this.chkIsVDS.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_vds"]);
                    this.chkIsAllBssUnit.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_for_all_bss_unit"]);
                    this.chkIsPriceDec.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_price_declaration"]);
                    this.chkIsHCS.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_healthcare_surcharge"]);
                    this.chkItemSet.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_item_set"]);
                    this.chkReusable.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_reusable"]);
                    this.setUpdateModeForAddItem();
                    this.modalPopupForAddItem.Show();
                }
                catch (Exception exception)
                {
                       BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "gvItem_SelectedIndexChanged");
                }
            }
            catch (Exception exception1)
            {
                   BLL.Utility.InsertErrorTrack(exception1.Message, "SetItem.aspx", "gvItem_SelectedIndexChanged");
            }
        }

        private bool ItemValidation()
        {
            bool flag;
            AddItemBLL addItemBLL = new AddItemBLL();
            if (this.drpItemCategory.SelectedValue == "" || this.drpItemCategory.SelectedValue == "-99")
            {
                this.drpItemCategory.Focus();
                this.MsgBoxs.AddMessage("Please select Category.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (this.drpItemSubCategory.SelectedValue == "" || this.drpItemSubCategory.SelectedValue == "-99")
            {
                this.drpItemSubCategory.Focus();
                this.MsgBoxs.AddMessage("Please select Sub Category.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (this.txtItemName.Text.Trim().Length < 1)
            {
                this.txtItemName.Focus();
                this.MsgBoxs.AddMessage("Please Enter Item Name.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (this.txtHSHeading.Text.Trim().Length < 1)
            {
                this.txtHSHeading.Focus();
                this.MsgBoxs.AddMessage("Please Enter HS Code Heading.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (this.txtHSSuffix.Text.Trim().Length < 1)
            {
                this.txtHSSuffix.Focus();
                this.MsgBoxs.AddMessage("Please Enter  HS Code Suffix.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtSKUCode.Text))
            {
                this.MsgBoxs.AddMessage("Please type item code", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (!this.rdService.Checked && !this.rdItem.Checked && !this.rdUtility.Checked)
            {
                this.MsgBoxs.AddMessage("Please choose Product type.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (this.rdItem.Checked && this.drpProductType.SelectedValue == "")
            {
                this.MsgBoxs.AddMessage("Please choose Item type.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (this.rdService.Checked && this.drpServiceType.SelectedValue != "1" && this.drpServiceType.SelectedValue != "2" && this.drpServiceType.SelectedValue != "3")
            {
                this.MsgBoxs.AddMessage("Please choose Service type.", MsgBoxs.enmMessageType.Error);
                this.modalPopupForAddItem.Show();
                return false;
            }
            if (!this.rdService.Checked)
            {
                if (this.drpItemCategory.SelectedValue == "")
                {
                    this.drpItemCategory.Focus();
                    this.MsgBoxs.AddMessage("Please select category", MsgBoxs.enmMessageType.Error);
                    this.modalPopupForAddItem.Show();
                    return false;
                }
                if (this.drpProductType.SelectedValue != "S")
                {
                    if (this.drpTypeofMsnt.SelectedValue == "" || this.drpTypeofMsnt.SelectedValue == "-99")
                    {
                        this.drpTypeofMsnt.Focus();
                        this.MsgBoxs.AddMessage("Please select measurement type", MsgBoxs.enmMessageType.Error);
                        this.modalPopupForAddItem.Show();
                        return false;
                    }
                    if (this.drpUnit.SelectedValue == "" || this.drpUnit.SelectedValue == "-99")
                    {
                        this.drpUnit.Focus();
                        this.MsgBoxs.AddMessage("Please select unit", MsgBoxs.enmMessageType.Error);
                        this.modalPopupForAddItem.Show();
                        return false;
                    }
                }
            }
            if (this.btnSave.Text == "Save")
            {
                int num = Convert.ToInt32(this.drpItemCategory.SelectedValue);
                if (!string.IsNullOrEmpty(this.drpItemSubCategory.SelectedValue))
                {
                    num = Convert.ToInt32(this.drpItemSubCategory.SelectedValue);
                }
                if (addItemBLL.checkForDuplicateItemName(num, this.txtItemName.Text.Trim(), this.txtSpecification.Text.Trim()))
                {
                    this.MsgBoxs.AddMessage("This item name already exsist.", MsgBoxs.enmMessageType.Error);
                    this.txtItemName.Focus();
                    return false;
                }
                if (addItemBLL.checkForDuplicateItemSKU(this.txtSKUCode.Text.Trim()))
                {
                    this.MsgBoxs.AddMessage("This SKU/Pro. Code already exsist.", MsgBoxs.enmMessageType.Error);
                    this.txtItemName.Focus();
                    this.modalPopupForAddItem.Show();
                    return false;
                }
            }
            if (this.btnSave.Text.Trim() == "Update")
            {
                try
                {
                    int num1 = Convert.ToInt32(this.drpItemCategory.SelectedValue);
                    if (!string.IsNullOrEmpty(this.drpItemSubCategory.SelectedValue))
                    {
                        num1 = Convert.ToInt32(this.drpItemSubCategory.SelectedValue);
                    }
                    int num2 = Convert.ToInt32(this.hnItemID.Value);
                    if (addItemBLL.checkForDuplicateItemNameInUpdate(num1, num2, this.txtItemName.Text.Trim()))
                    {
                        this.MsgBoxs.AddMessage("This subcategory name already exsist.", MsgBoxs.enmMessageType.Error);
                        this.txtItemName.Focus();
                        flag = false;
                    }
                    else if (!addItemBLL.checkForDuplicateItemSKUinUpdate(this.txtSKUCode.Text.Trim(), num2))
                    {
                        return true;
                    }
                    else
                    {
                        this.MsgBoxs.AddMessage("This SKU/Pro. Code already exsist.", MsgBoxs.enmMessageType.Error);
                        this.txtItemName.Focus();
                        this.modalPopupForAddItem.Show();
                        flag = false;
                    }
                }
                catch (Exception exception)
                {
                       BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "ItemValidation");
                    return true;
                }
                return flag;
            }
            return true;
        }

        protected void lnkOpening_click(object sender, EventArgs e)
        {
        }

        private void loadCategory()
        {
            try
            {
                DataTable allCategory = this.objAddItemsBll.GetAllCategory();
                this.drpSearchCategory.DataSource = allCategory;
                this.drpSearchCategory.DataTextField = allCategory.Columns["category_name"].ToString();
                this.drpSearchCategory.DataValueField = allCategory.Columns["category_id"].ToString();
                this.drpSearchCategory.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpSearchCategory.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadItem()
        {
            try
            {
                DataTable allItem = this.objAddItemsBll.GetAllItem();
                this.drpSearchItem.DataSource = allItem;
                this.drpSearchItem.DataTextField = allItem.Columns["item_name"].ToString();
                this.drpSearchItem.DataValueField = allItem.Columns["item_id"].ToString();
                this.drpSearchItem.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpSearchItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadMesurmentType()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                DataTable mesurmentType = addItemBLL.getMesurmentType();
                this.drpTypeofMsnt.DataSource = mesurmentType;
                this.drpTypeofMsnt.DataTextField = mesurmentType.Columns["CODE_NAME"].ToString();
                this.drpTypeofMsnt.DataValueField = mesurmentType.Columns["CODE_ID_D"].ToString();
                this.drpTypeofMsnt.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpTypeofMsnt.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "loadMesurmentType");
            }
        }

        private void loadSubCategory()
        {
            try
            {
                DataTable allSubCategory = this.objAddItemsBll.GetAllSubCategory();
                this.drpSearchSubcatg.DataSource = allSubCategory;
                this.drpSearchSubcatg.DataTextField = allSubCategory.Columns["category_name"].ToString();
                this.drpSearchSubcatg.DataValueField = allSubCategory.Columns["category_id"].ToString();
                this.drpSearchSubcatg.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpSearchSubcatg.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadUnit()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            short num = Convert.ToInt16(this.drpTypeofMsnt.SelectedValue);
            DataTable mesurmentIUnit = addItemBLL.getMesurmentIUnit(num);
            this.drpUnit.DataSource = mesurmentIUnit;
            this.drpUnit.DataTextField = mesurmentIUnit.Columns["UNIT_NAME"].ToString();
            this.drpUnit.DataValueField = mesurmentIUnit.Columns["UNIT_ID"].ToString();
            this.drpUnit.DataBind();
        }

        private void loadWeightUnit()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                DataTable allUnit = addItemBLL.getAllUnit();
                this.drpWeightUnit.DataSource = allUnit;
                this.drpWeightUnit.DataTextField = allUnit.Columns["unit_code"].ToString();
                this.drpWeightUnit.DataValueField = allUnit.Columns["UNIT_ID"].ToString();
                this.drpWeightUnit.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpWeightUnit.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "loadWeightUnit");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.tvwCategory.ForeColor = Color.Black;
                TreeLoad.LoadProblemTree(this.tvwCategory);
                SetItems.FillItemPropertyDropDownList(this.drpItemProperty);
                this.loadMesurmentType();
                this.drpServiceType.Enabled = false;
                try
                {
                    if (base.Request.QueryString["TypeId"] != null)
                    {
                        this.lnkOpening.Visible = true;
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
                this.loadWeightUnit();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpUnit.Items.Insert(0, listItem);
            }
        }

        protected void rdService_CheckedChanged(object sender, EventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                if (this.rdService.Checked)
                {
                    this.drpProductType.Enabled = false;
                    this.drpServiceType.Enabled = true;
                    this.drpProductType.SelectedValue = "";
                }
                else if (this.rdItem.Checked)
                {
                    this.drpProductType.Enabled = true;
                    this.drpServiceType.Enabled = false;
                    this.drpServiceType.SelectedValue = "";
                    this.loadMesurmentType();
                    this.drpUnit.Items.Clear();
                    ListItem listItem = new ListItem("--- Select ---", "-99");
                    this.drpUnit.Items.Insert(0, listItem);
                }
                else if (this.rdUtility.Checked)
                {
                    this.drpProductType.Enabled = false;
                    this.drpServiceType.Enabled = false;
                    this.loadMesurmentType();
                    this.drpUnit.Items.Clear();
                    ListItem listItem1 = new ListItem("--- Select ---", "-99");
                    this.drpUnit.Items.Insert(0, listItem1);
                }
                this.modalPopupForAddItem.Show();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                   BLL.Utility.InsertErrorTrackNew(exception.Message, "SetItem.aspx", "rdService_CheckedChanged", fileLineNumber);
            }
        }

        private void setAddModeForAddItem()
        {
            this.btnSave.Text = "Save";
        }

        private void setAddModeForCategory()
        {
            this.btnSaveCategory.Text = "Save";
            this.hnCategoryID.Value = "";
        }

        private void setAddModeForSubCategory()
        {
            this.btnAddSubCategory.Text = "Add Sub Category";
            this.btnSaveSubCategory.Text = "Save";
            this.clearSubCategoryControlsValue();
        }

        private void setButtonsForFirstTime()
        {
            this.btnAddCategory.Enabled = true;
            this.btnAddSubCategory.Enabled = true;
            this.btnAddItems.Enabled = true;
        }

        private void setpdateModeForSubCategory()
        {
            this.btndeleteSubCategory.Visible = true;
            this.btnSaveSubCategory.Text = "Update";
        }

        private void setPropetiesTextLevel()
        {
            DataSet allPropertyNameForItem = (new AddItemBLL()).getAllPropertyNameForItem();
            for (int i = 0; i < allPropertyNameForItem.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {
                    this.chkProOne.Text = string.Concat(allPropertyNameForItem.Tables[0].Rows[i]["CODE_NAME"].ToString(), " Required");
                }
                else if (i == 1)
                {
                    this.chkProTwo.Text = string.Concat(allPropertyNameForItem.Tables[0].Rows[i]["CODE_NAME"].ToString(), " Required");
                }
                else if (i == 2)
                {
                    this.chkProThree.Text = string.Concat(allPropertyNameForItem.Tables[0].Rows[i]["CODE_NAME"].ToString(), " Required");
                }
                else if (i == 3)
                {
                    this.chkProFour.Text = string.Concat(allPropertyNameForItem.Tables[0].Rows[i]["CODE_NAME"].ToString(), " Required");
                }
                else if (i == 4)
                {
                    this.chkProFive.Text = string.Concat(allPropertyNameForItem.Tables[0].Rows[i]["CODE_NAME"].ToString(), " Required");
                }
            }
            if (this.chkProOne.Text == "")
            {
                this.chkProOne.Visible = false;
            }
            if (this.chkProTwo.Text == "")
            {
                this.chkProTwo.Visible = false;
            }
            if (this.chkProThree.Text == "")
            {
                this.chkProThree.Visible = false;
            }
            if (this.chkProFour.Text == "")
            {
                this.chkProFour.Visible = false;
            }
            if (this.chkProFive.Text == "")
            {
                this.chkProFive.Visible = false;
            }
        }

        private void setUpdateModeForAddItem()
        {
            this.btnSave.Text = "Update";
        }

        private void setUpdateModeForCategory()
        {
            this.btnSaveCategory.Text = "Update";
            this.btndelete.Visible = true;
        }

        private void setUpdateModeForSubCategory()
        {
            this.btnAddSubCategory.Text = "Edit Sub Category";
            this.btnSaveSubCategory.Text = "Update";
        }

        private void showItemDataInGridView()
        {
            try
            {
                int num = 0;
                AddItemBLL addItemBLL = new AddItemBLL();
                num = (this.hnCategoryID.Value == "" ? Convert.ToInt32(this.drpItemSubCategory.SelectedValue) : Convert.ToInt32(this.hnCategoryID.Value));
                DataSet dataSet = new DataSet();
                dataSet = addItemBLL.getAllItemByCategoryId(num);
                if (dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count != 0)
                {
                    this.gvItem.DataSource = dataSet;
                    this.gvItem.DataBind();
                }
                else
                {
                    dataSet.Tables[0].Rows.Add(dataSet.Tables[0].NewRow());
                    this.gvItem.DataSource = dataSet;
                    this.gvItem.DataBind();
                    int count = this.gvItem.Rows[0].Cells.Count;
                    this.gvItem.Rows[0].Cells.Clear();
                    this.gvItem.Rows[0].Cells.Add(new TableCell());
                    this.gvItem.Rows[0].Cells[0].ColumnSpan = count;
                    this.gvItem.Rows[0].Cells[0].Text = "No Item(s) Found";
                    this.gvItem.Rows[0].EnableViewState = false;
                    this.gvItem.Rows[0].Cells[0].EnableViewState = false;
                }
                this.displayTotalRecordsFound();
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "showItemDataInGridView");
            }
        }

        private bool subValidation()
        {
            bool flag;
            if (this.txtSubCategory.Text.Trim().Length < 1)
            {
                this.txtSubCategory.Focus();
                return false;
            }
            if (this.btnSaveSubCategory.Text.Trim() == "Save")
            {
                try
                {
                    if ((new AddItemBLL()).checkForDuplicateSubCategoryName(Convert.ToInt32(this.drpCategory.SelectedValue), this.txtSubCategory.Text.Trim()))
                    {
                        this.MsgBoxs.AddMessage("This subcategory name already exsist.", MsgBoxs.enmMessageType.Error);
                        this.txtSubCategory.Focus();
                        flag = false;
                        return flag;
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
            }
            if (this.btnSaveSubCategory.Text.Trim() == "Update")
            {
                try
                {
                    if ((new AddItemBLL()).checkForDuplicateSubCategoryNameInUpdate(Convert.ToInt32(this.drpCategory.SelectedValue), Convert.ToInt32(this.hnCategoryID.Value), this.txtSubCategory.Text.Trim()))
                    {
                        this.MsgBoxs.AddMessage("This subcategory name already exsist.", MsgBoxs.enmMessageType.Error);
                        this.txtSubCategory.Focus();
                        flag = false;
                        return flag;
                    }
                }
                catch (Exception exception1)
                {
                }
            }
            return true;
        }

        protected void tvwCategory_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                this.lblTotalRow.Text = "";
                int num = Convert.ToInt32(this.tvwCategory.SelectedNode.Value);
                this.hnCategoryID.Value = this.tvwCategory.SelectedNode.Value;
                this.enableDisableButton(addItemBLL.checkItemCategoryForIsLeaf(num));
                this.showItemDataInGridView();
            }
            catch (Exception exception)
            {
                   BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "tvwCategory_SelectedNodeChanged");
            }
        }

        private bool Validation()
        {
            bool flag;
            AddItemBLL addItemBLL = new AddItemBLL();
            if (this.txtCategoryName.Text.Trim().Length < 1)
            {
                this.txtCategoryName.Focus();
                return false;
            }
            if (this.btnSaveCategory.Text == "Save" && addItemBLL.checkForDuplicateCategoryName(this.txtCategoryName.Text.Trim()))
            {
                this.MsgBoxs.AddMessage("This category name already exsist.", MsgBoxs.enmMessageType.Error);
                this.txtCategoryName.Focus();
                return false;
            }
            if (this.btnSaveCategory.Text == "Update")
            {
                try
                {
                    if (!addItemBLL.checkForDuplicateCategoryNameInUpdate(Convert.ToInt32(this.hnCategoryID.Value), this.txtCategoryName.Text.Trim()))
                    {
                        return true;
                    }
                    else
                    {
                        this.MsgBoxs.AddMessage("This category name already exsist.", MsgBoxs.enmMessageType.Error);
                        this.txtCategoryName.Focus();
                        flag = false;
                    }
                }
                catch (Exception exception)
                {
                       BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "Validation");
                    return true;
                }
                return flag;
            }
            return true;
        }
    }
}