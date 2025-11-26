using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class ItemOpeningInfo : Page, IRequiresSessionState
    {
      

      



     

        private AddItemBLL addItemBLL = new AddItemBLL();

        public Dictionary<string, bool> partyNameList = new Dictionary<string, bool>();

        public ArrayList objectPropertyNameList = new ArrayList();

        public ArrayList tableDataList = new ArrayList();

        public ArrayList tableNameList = new ArrayList();

        public ArrayList validationList = new ArrayList();

        public short status = 1;

        public bool checkStatus;

        private SaleBLL objSBLL = new SaleBLL();

        private AddItemBLL objAddItemsBll = new AddItemBLL();

      

        public ItemOpeningInfo()
        {
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            this.setAddModeForCategory();
            this.clearCategoryControlValue();
            modalPopupForAddCategory.Show();
        }

        protected void btnAddItems_Click(object sender, EventArgs e)
        {
            this.setPropetiesTextLevel();
            this.clearItemControlData();
            this.setAddModeForAddItem();
            if (this.hnCategoryID.Value != "")
            {
                try
                {
                    int num = Convert.ToInt32(this.hnCategoryID.Value);
                    if (Convert.ToInt16(this.hnCategoryLevel.Value) != 1)
                    {
                        this.cddItemCategory.SelectedValue=(this.hnParentID.Value);
                        this.cddItemSubCategory.SelectedValue=(num.ToString());
                    }
                    else
                    {
                        this.cddItemCategory.SelectedValue=(num.ToString());
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
                this.drpItemCategory.Enabled = false;
            }
            this.modalPopupForAddItem.Show();
        }

        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {
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
                        ReallySimpleLog.WriteLog(exception);
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
                    ReallySimpleLog.WriteLog(exception1);
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
                    ReallySimpleLog.WriteLog(exception2);
                }
            }
            this.modalPopupForSubCategory.Show();
        }

        protected void btnEditCategory_Click(object sender, EventArgs e)
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

        protected void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemCategoryDAO setItemCategoryDAO = new SetItemCategoryDAO();
                setItemCategoryDAO = this.fillCategoryProperties(setItemCategoryDAO);
                if (this.btnSaveCategory.Text == "Save")
                {
                    if (!addItemBLL.InsertItemCategory(setItemCategoryDAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        this.modalPopupForAddCategory.Show();
                        return;
                    }
                    this.clearCategoryControlValue();
                    TreeLoad.LoadProblemTree(this.tvwCategory);
                    this.setButtonsForFirstTime();
                    this.msgBox.AddMessage("Item Category Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                setItemCategoryDAO.UserIdUpdate = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
                setItemCategoryDAO.CategoryID = Convert.ToInt32(this.hnCategoryID.Value);
                if (addItemBLL.UpdateItemCategory(setItemCategoryDAO))
                {
                    this.clearCategoryControlValue();
                    this.setAddModeForCategory();
                    TreeLoad.LoadProblemTree(this.tvwCategory);
                    this.setButtonsForFirstTime();
                    this.msgBox.AddMessage("Item Category Successfully Updated.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            if (this.ItemValidation())
            {
                SetItemDAO setItemDAO = new SetItemDAO();
                setItemDAO = this.fillItemProperties(setItemDAO);
                if (this.btnSave.Text == "Save")
                {
                    if (addItemBLL.InsertItem(setItemDAO) <= 0)
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.clearItemControlData();
                    this.showItemDataInGridView();
                    this.msgBox.AddMessage("Item information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                try
                {
                    setItemDAO.ItemID = Convert.ToInt32(this.hnItemID.Value);
                    setItemDAO.UserIdUpdate = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                    if (!addItemBLL.updateItem(setItemDAO))
                    {
                        this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.clearItemControlData();
                        this.showItemDataInGridView();
                        this.setAddModeForAddItem();
                        this.msgBox.AddMessage("Item information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
            }
        }

        protected void btnSaveOpeningBalance_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                int num = 0;
                decimal num1 = new decimal(0);
                ArrayList arrayLists = new ArrayList();
                List<SetItemDAO> setItemDAOs = new List<SetItemDAO>();
                SetItemDAO setItemDAO = new SetItemDAO();
                if (this.gvItem.Rows.Count > 0)
                {
                    for (int i = 1; i <= this.gvItem.Rows.Count; i++)
                    {
                        GridViewRow item = this.gvItem.Rows[this.gvItem.SelectedIndex + i];
                        TextBox textBox = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtQuantity");
                        double num2 = (textBox.Text.Trim().Length > 0 ? Convert.ToDouble(textBox.Text.Trim()) : 0);
                        TextBox textBox1 = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtUnitPrice");
                        double num3 = (textBox1.Text.Trim().Length > 0 ? Convert.ToDouble(textBox1.Text.Trim()) : 0);
                        TextBox textBox2 = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtValue");
                        double num4 = (textBox2.Text.Trim().Length > 0 ? Convert.ToDouble(textBox2.Text.Trim()) : 0);
                        TextBox textBox3 = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtdate");
                        string str = (textBox3.Text.Trim().Length > 0 ? textBox3.Text.Trim() : DateTime.Today.ToString("dd/MM/yyyy"));
                        CheckBox checkBox = (CheckBox)this.gvItem.Rows[item.RowIndex].FindControl("chkExcel");
                        setItemDAO.ItemID = Convert.ToInt16(this.gvItem.DataKeys[item.RowIndex].Values["ItemID"]);
                        setItemDAO.UnitID = Convert.ToInt16(this.gvItem.Rows[i - 1].Cells[0].Text.Trim());
                        if (!checkBox.Checked)
                        {
                            setItemDAO.chkStatus = false;
                        }
                        else
                        {
                            setItemDAO.chkStatus = true;
                        }
                        string empty = string.Empty;
                        DropDownList dropDownList = (DropDownList)this.gvItem.Rows[item.RowIndex].FindControl("drpPurchaseType");
                        string text = dropDownList.SelectedItem.Text;
                        if (text != "Local")
                        {
                            empty = (text != "Finished Product Production" ? "I" : "F");
                        }
                        else
                        {
                            empty = "L";
                        }
                        setItemDAO.ItmQty = num2;
                        setItemDAO.unitPrice = num3;
                        setItemDAO.ItmVl = num4;
                        setItemDAO.Opening_bal_date = DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        short num5 = Convert.ToInt16(this.gvItem.DataKeys[item.RowIndex].Values["ItemID"]);
                        DataTable dataTable = new DataTable();
                        dataTable = this.objAddItemsBll.GetItemBoolean(num5);
                        if (dataTable.Rows.Count > 0)
                        {
                            setItemDAO.Mrp = Convert.ToBoolean(dataTable.Rows[0]["is_mrp"]);
                            setItemDAO.Tarrif = Convert.ToBoolean(dataTable.Rows[0]["is_tarrif"]);
                            setItemDAO.ZeroRate = Convert.ToBoolean(dataTable.Rows[0]["is_zero_rate"]);
                            setItemDAO.Truncated = Convert.ToBoolean(dataTable.Rows[0]["is_truncated"]);
                            setItemDAO.IsVDS = Convert.ToBoolean(dataTable.Rows[0]["is_vds"]);
                            setItemDAO.Rebatable = Convert.ToBoolean(dataTable.Rows[0]["is_rebatable"]);
                            setItemDAO.Exempted = Convert.ToBoolean(dataTable.Rows[0]["is_exempted"]);
                        }
                        DataSet openingItemInfo = this.objAddItemsBll.GetOpeningItemInfo(num5);
                        if (openingItemInfo.Tables[0].Rows.Count > 0)
                        {
                            DataSet challanID = this.objAddItemsBll.GetChallanID(num5);
                            if (challanID.Tables[0].Rows.Count > 0)
                            {
                                num = Convert.ToInt32(challanID.Tables[0].Rows[0]["challan_id"].ToString());
                                num1 = Convert.ToDecimal(challanID.Tables[0].Rows[0]["quantity"].ToString());
                            }
                            setItemDAO.OpnID = Convert.ToInt16(openingItemInfo.Tables[0].Rows[0]["opn_id"].ToString());
                            if (!setItemDAO.chkStatus)
                            {
                                flag = this.objAddItemsBll.UpdateItemBalance(setItemDAO, num, empty);
                            }
                            else if (num1 == new decimal(0))
                            {
                                arrayLists = (ArrayList)this.Session["ProductionRcv_EXCEL"];
                                if (arrayLists == null || arrayLists.Count == 0)
                                {
                                    this.msgBox.AddMessage("Insert Additional Property.", MsgBoxs.enmMessageType.Error);
                                    return;
                                }
                                else if (arrayLists.Count <= 0 || (double)arrayLists.Count == setItemDAO.ItmQty)
                                {
                                    flag = this.objAddItemsBll.UpdateItemBalanceWithAdtnProperty(setItemDAO, num, empty, arrayLists);
                                }
                                else
                                {
                                    this.msgBox.AddMessage("Quantity and No of Additional Property are not equal", MsgBoxs.enmMessageType.Attention);
                                    textBox.Focus();
                                    return;
                                }
                            }
                            else if (this.objAddItemsBll.GetSaleItemInfo(num5).Tables[0].Rows.Count < 1)
                            {
                                this.objAddItemsBll.UpdateItemBalanceWithAdtnPropertyN(setItemDAO, num, empty, arrayLists);
                                flag = this.objAddItemsBll.UpdateItemBalanceWithAdtnProperty(setItemDAO, num, empty, arrayLists);
                            }
                        }
                        else if (!setItemDAO.chkStatus)
                        {
                            flag = this.objAddItemsBll.InsertItemBalance(setItemDAO, empty);
                        }
                        else
                        {
                            arrayLists = (ArrayList)this.Session["ProductionRcv_EXCEL"];
                            if (arrayLists.Count > 0)
                            {
                                if ((double)arrayLists.Count != setItemDAO.ItmQty)
                                {
                                    this.msgBox.AddMessage("Quantity and No of Additional Property are not equal", MsgBoxs.enmMessageType.Attention);
                                    textBox.Focus();
                                    return;
                                }
                            }
                            else if (arrayLists.Count == 0 && (double)arrayLists.Count != setItemDAO.ItmQty)
                            {
                                this.msgBox.AddMessage("Insert Additional Property.", MsgBoxs.enmMessageType.Attention);
                                return;
                            }
                            flag = this.objAddItemsBll.InsertItemBalanceWithExcelAdtnProperty(setItemDAO, empty, arrayLists);
                        }
                    }
                }
                if (flag)
                {
                    this.Session["checkStatus"] = "";
                    for (int j = 1; j <= this.gvItem.Rows.Count; j++)
                    {
                        GridViewRow gridViewRow = this.gvItem.Rows[this.gvItem.SelectedIndex + j];
                        CheckBox checkBox1 = (CheckBox)this.gvItem.Rows[gridViewRow.RowIndex].FindControl("chkExcel");
                        checkBox1.Checked = false;
                    }
                    this.gvExcelFile.DataSource = null;
                    this.gvExcelFile.DataBind();
                    this.Session["ProductionRcv_EXCEL"] = new ArrayList();
                    this.part_e.Visible = false;
                    this.msgBox.AddMessage("Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "Itm_openingInfo.aspx", "btnSaveOpeningBalance_Click", fileLineNumber);
            }
        }

        protected void btnSaveSubCategory_Click(object sender, EventArgs e)
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
                        setItemCategoryDAO.CategoryID = Convert.ToInt32(this.hnCategoryID.Value);
                        setItemCategoryDAO.UserIdUpdate = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
                        if (addItemBLL.UpdateSubCategory(setItemCategoryDAO))
                        {
                            TreeLoad.LoadProblemTree(this.tvwCategory);
                            this.setButtonsForFirstTime();
                            this.clearSubCategoryControlsValue();
                            this.setAddModeForSubCategory();
                            this.msgBox.AddMessage("Sub category information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    int num = addItemBLL.InsertItemSubCategory(setItemCategoryDAO);
                    if (num <= 0)
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    TreeLoad.LoadProblemTree(this.tvwCategory);
                    this.setButtonsForFirstTime();
                    this.clearSubCategoryControlsValue();
                    this.msgBox.AddMessage("Item sub category Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    if (base.Request.QueryString["TypeId"] != null)
                    {
                        HttpResponse response = base.Response;
                        object[] parentID = new object[] { "Opening.aspx?catId=", setItemCategoryDAO.ParentID, ":", num };
                        response.Redirect(string.Concat(parentID));
                        return;
                    }
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Session["ProductionRcv_EXCEL"] = new ArrayList();
                Dictionary<string, bool> strs = new Dictionary<string, bool>();
                ArrayList arrayLists = new ArrayList();
                this.tableNameList = new ArrayList();
                this.objectPropertyNameList = new ArrayList();
                this.validationList = new ArrayList();
                this.gvExcelFile.DataSource = null;
                this.gvExcelFile.DataBind();
                string stringCellValue = "";
                string str = "";
                string str1 = "";
                string str2 = "PurchaseAdditional";
                string lower = Path.GetExtension(this.FileUpload1.FileName).ToLower();
                if (string.IsNullOrEmpty(lower))
                {
                    this.msgBox.AddMessage(" File Path not Found! Please Choose Your File. ", MsgBoxs.enmMessageType.Attention);
                    return;
                }
                else
                {
                    HttpServerUtility server = base.Server;
                    DateTime now = DateTime.Now;
                    str1 = server.MapPath(string.Concat("~/CSV/productionrcvImport_", now.ToString("ddMMyyyy_HHmmssFFF"), lower));
                    this.FileUpload1.SaveAs(str1);
                    this.Label29.Text = string.Concat(this.FileUpload1.FileName, "'s Data showing into the GridView");
                    try
                    {
                        HSSFWorkbook hSSFWorkbook = null;
                        ISheet sheet = null;
                        hSSFWorkbook = new HSSFWorkbook(new FileStream(str1, FileMode.Open, FileAccess.Read))
                        {
                            MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK
                        };
                        for (int i = 0; i < hSSFWorkbook.NumberOfSheets; i++)
                        {
                            ISheet sheetAt = hSSFWorkbook.GetSheetAt(i);
                            if (str2.ToUpper().Equals(sheetAt.SheetName.ToUpper()))
                            {
                                sheet = sheetAt;
                            }
                        }
                        ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                        IRow row = sheet.GetRow(1);
                        IRow rows = sheet.GetRow(0);
                        for (int j = 1; j <= row.LastCellNum; j++)
                        {
                            ICell cell = rows.GetCell(j - 1);
                            ICell cell1 = row.GetCell(j - 1);
                            stringCellValue = cell.StringCellValue;
                            str = cell1.StringCellValue;
                            if (contructualProductionIssueDAO.GetType().GetProperty(stringCellValue) != null && !string.IsNullOrEmpty(str))
                            {
                                this.objectPropertyNameList.Add(stringCellValue);
                                this.tableNameList.Add(str);
                                strs.Add(stringCellValue, false);
                                if (this.gvExcelFile.Columns.Count != 6)
                                {
                                    BoundField boundField = new BoundField()
                                    {
                                        HeaderText = str,
                                        DataField = stringCellValue
                                    };
                                    this.gvExcelFile.Columns.Add(boundField);
                                }
                            }
                        }
                        int lastRowNum = sheet.LastRowNum;
                        for (int k = 2; k <= lastRowNum; k++)
                        {
                            IRow row1 = sheet.GetRow(k);
                            if (sheet.GetRow(k) != null && sheet.GetRow(k).Cells.Count > 0)
                            {
                                if (this.objectPropertyNameList.Count > sheet.GetRow(k).Cells.Count)
                                {
                                    for (int l = 0; l < this.objectPropertyNameList.Count; l++)
                                    {
                                        if (l != row1.GetCell(l).ColumnIndex)
                                        {
                                            row1.CreateCell(l);
                                        }
                                    }
                                }
                                bool flag = true;
                                for (int m = 0; m < this.objectPropertyNameList.Count; m++)
                                {
                                    ICell cell2 = row1.GetCell(m, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                                    if (row1.GetCell(m) != null && cell2.CellType != CellType.Blank)
                                    {
                                        flag = false;
                                    }
                                }
                                if (flag)
                                {
                                    break;
                                }
                                Dictionary<string, bool> strs1 = new Dictionary<string, bool>();
                                foreach (string key in strs.Keys)
                                {
                                    strs1.Add(key, strs[key]);
                                }
                                contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                                int num = -1;
                                foreach (string str3 in this.objectPropertyNameList)
                                {
                                    num++;
                                    if (contructualProductionIssueDAO.GetType().GetProperty(str3).PropertyType.Name == "Boolean")
                                    {
                                        row1.GetCell(num).SetCellType(CellType.Boolean);
                                        bool booleanCellValue = false;
                                        if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                        {
                                            booleanCellValue = row1.GetCell(num).BooleanCellValue;
                                        }
                                        contructualProductionIssueDAO.GetType().GetProperty(str3).SetValue(contructualProductionIssueDAO, booleanCellValue, null);
                                    }
                                    else if (contructualProductionIssueDAO.GetType().GetProperty(str3).PropertyType.Name == "Int16")
                                    {
                                        short num1 = 0;
                                        if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                        {
                                            num1 = Convert.ToInt16(row1.GetCell(num));
                                        }
                                        contructualProductionIssueDAO.GetType().GetProperty(str3).SetValue(contructualProductionIssueDAO, num1, null);
                                    }
                                    else if (contructualProductionIssueDAO.GetType().GetProperty(str3).PropertyType.Name == "Decimal")
                                    {
                                        decimal num2 = new decimal(0);
                                        row1.GetCell(num).SetCellType(CellType.Numeric);
                                        if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                        {
                                            num2 = Convert.ToDecimal(row1.GetCell(num).NumericCellValue);
                                        }
                                        contructualProductionIssueDAO.GetType().GetProperty(str3).SetValue(contructualProductionIssueDAO, num2, null);
                                    }
                                    else if (contructualProductionIssueDAO.GetType().GetProperty(str3).PropertyType.Name != "Double")
                                    {
                                        string empty = string.Empty;
                                        row1.GetCell(num).SetCellType(CellType.String);
                                        if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                        {
                                            empty = row1.GetCell(num).StringCellValue.Trim();
                                        }
                                        contructualProductionIssueDAO.GetType().GetProperty(str3).SetValue(contructualProductionIssueDAO, empty, null);
                                    }
                                    else
                                    {
                                        double num3 = 0;
                                        row1.GetCell(num).SetCellType(CellType.Numeric);
                                        if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                        {
                                            num3 = Convert.ToDouble(row1.GetCell(num).NumericCellValue);
                                        }
                                        contructualProductionIssueDAO.GetType().GetProperty(str3).SetValue(contructualProductionIssueDAO, num3, null);
                                    }
                                }
                                contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
                                contructualProductionIssueDAO.RowNo = Convert.ToInt16(this.validationList.Count);
                                contructualProductionIssueDAO.Item_id = Convert.ToInt16(this.Session["itemId"]);
                                contructualProductionIssueDAO.Property_id1 = Convert.ToInt16(this.hfProperty1.Value);
                                contructualProductionIssueDAO.Property_id2 = Convert.ToInt16(this.hfProperty2.Value);
                                contructualProductionIssueDAO.Property_id3 = Convert.ToInt16(this.hfProperty3.Value);
                                contructualProductionIssueDAO.Property_id4 = Convert.ToInt16(this.hfProperty4.Value);
                                contructualProductionIssueDAO.Property_id5 = Convert.ToInt16(this.hfProperty5.Value);
                                arrayLists.Add(contructualProductionIssueDAO);
                                this.validationList.Add(strs1);
                            }
                            Utilities.KillExcelFileProcess();
                        }
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        Utilities.KillExcelFileProcess();
                        this.msgBox.AddMessage(exception.Message, MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                    this.gvExcelFile.DataSource = arrayLists;
                    this.gvExcelFile.DataBind();
                    this.Session["ProductionRcv_EXCEL"] = arrayLists;
                }
            }
            catch (Exception exception3)
            {
                Exception exception2 = exception3;
                Utilities.KillExcelFileProcess();
                BLL.Utility.InsertErrorTrack(exception2.Message, "Purchase_challan_11", "btnUpload_Click");
            }
            Utilities.KillExcelFileProcess();
        }

        protected void ChckedChanged(object sender, EventArgs e)
        {
            if (this.gvItem.Rows.Count > 0)
            {
                for (int i = 1; i <= this.gvItem.Rows.Count; i++)
                {
                    GridViewRow item = this.gvItem.Rows[this.gvItem.SelectedIndex + i];
                    CheckBox checkBox = (CheckBox)this.gvItem.Rows[item.RowIndex].FindControl("chkExcel");
                    int num = Convert.ToInt16(this.gvItem.DataKeys[item.RowIndex].Values["ItemID"]);
                    if (checkBox.Checked)
                    {
                        if (num == 0)
                        {
                            this.checkStatus = false;
                            checkBox.Checked = false;
                            this.msgBox.AddMessage("Please Select Item Name first.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        this.EnableOrDisablePropertyForItemforExcel(num);
                        this.Session["itemId"] = num;
                        this.Session["checkStatus"] = true;
                        if (!(this.hfProperty1.Value == "0") || !(this.hfProperty2.Value == "0") || !(this.hfProperty3.Value == "0") || !(this.hfProperty4.Value == "0") || !(this.hfProperty5.Value == "0"))
                        {
                            this.part_e.Visible = true;
                            return;
                        }
                        checkBox.Checked = false;
                        this.msgBox.AddMessage("No Additional Property Exist.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.part_e.Visible = false;
                }
            }
        }

        private void clearCategoryControlValue()
        {
            this.txtCategoryName.Text = "";
            this.txtDescription.Text = "";
        }

        private void clearItemControlData()
        {
            this.txtItemName.Text = "";
            this.txtSpecification.Text = "";
            this.txtHSHeading.Text = "";
            this.txtHSSuffix.Text = "";
            this.chkProOne.Checked = false;
            this.chkProTwo.Checked = false;
            this.chkProThree.Checked = false;
            this.chkProFour.Checked = false;
            this.chkProFive.Checked = false;
            this.chkIsSupplierRequired.Checked = false;
            this.chkIsExpiryDtRequired.Checked = false;
            this.chkIsExempted.Checked = false;
            this.chkIsRebatable.Checked = false;
            this.drpVATRebate.SelectedValue = "0";
        }

        private void clearSubCategoryControlsValue()
        {
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

        protected void drpTypeofMsnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                short num = Convert.ToInt16(this.drpTypeofMsnt.SelectedValue);
                DataTable mesurmentIUnit = addItemBLL.getMesurmentIUnit(num);
                this.drpUnit.DataSource = mesurmentIUnit;
                this.drpUnit.DataTextField = mesurmentIUnit.Columns["UNIT_NAME"].ToString();
                this.drpUnit.DataValueField = mesurmentIUnit.Columns["UNIT_ID"].ToString();
                this.drpUnit.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpUnit.Items.Insert(0, listItem);
                this.modalPopupForAddItem.Show();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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

        private void EnableOrDisablePropertyForItemforExcel(int itemId)
        {
            if (itemId != 0)
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(itemId);
                if (itemRequiredProperty.Rows.Count > 0)
                {
                    this.hfProperty1.Value = itemRequiredProperty.Rows[0]["property_id1"].ToString();
                    this.hfProperty2.Value = itemRequiredProperty.Rows[0]["property_id2"].ToString();
                    this.hfProperty3.Value = itemRequiredProperty.Rows[0]["property_id3"].ToString();
                    this.hfProperty4.Value = itemRequiredProperty.Rows[0]["property_id4"].ToString();
                    this.hfProperty5.Value = itemRequiredProperty.Rows[0]["property_id5"].ToString();
                    short num = 0;
                    short num1 = 0;
                    short num2 = 0;
                    short num3 = 0;
                    short num4 = 0;
                    DataTable appCodeDetailName = null;
                    num = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id1"]);
                    num1 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id2"]);
                    num2 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id3"]);
                    num3 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id4"]);
                    num4 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id5"]);
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop1.Visible = true;
                        this.prop1.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num1);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop2.Visible = true;
                        this.prop2.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num2);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop3.Visible = true;
                        this.prop3.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num3);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop4.Visible = true;
                        this.prop4.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num4);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop5.Visible = true;
                        this.prop5.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                }
            }
        }

        private SetItemCategoryDAO fillCategoryProperties(SetItemCategoryDAO objCategoryDAO)
        {
            objCategoryDAO.CategoryName = Utilities.ReplaceQuotes(this.txtCategoryName.Text.Trim());
            objCategoryDAO.Description = Utilities.ReplaceQuotes(this.txtDescription.Text.Trim());
            objCategoryDAO.CategoryLevel = 1;
            objCategoryDAO.UserIdInsert = 1;
            return objCategoryDAO;
        }

        private SetItemDAO fillItemProperties(SetItemDAO objItemDao)
        {
            if (!string.IsNullOrEmpty(this.drpItemCategory.SelectedValue))
            {
                objItemDao.CategoryID = Convert.ToInt32(this.drpItemCategory.SelectedValue);
                objItemDao.ParentID = 0;
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
            objItemDao.IsVDS = this.chkIsVDS.Checked;
            objItemDao.Exempted = this.chkIsExempted.Checked;
            objItemDao.Rebatable = this.chkIsRebatable.Checked;
            objItemDao.UserIdInsert = 1;
            objItemDao.MesurementIDM = AllConstraint.measurementTypeMasterId;
            if (!string.IsNullOrEmpty(this.drpTypeofMsnt.SelectedValue))
            {
                objItemDao.MesurementIDD = Convert.ToInt16(this.drpTypeofMsnt.SelectedValue);
            }
            if (!string.IsNullOrEmpty(this.drpUnit.SelectedValue))
            {
                objItemDao.UnitID = Convert.ToInt16(this.drpUnit.SelectedValue);
            }
            objItemDao.HsHeading = Utilities.ReplaceQuotes(this.txtHSHeading.Text.Trim());
            objItemDao.HsSuffix = Utilities.ReplaceQuotes(this.txtHSSuffix.Text.Trim());
            objItemDao.HsCode = string.Concat(objItemDao.HsHeading, objItemDao.HsSuffix);
            objItemDao.VatRebate = 0;
            if (this.rdItem.Checked)
            {
                objItemDao.ItemType = 'I';
                objItemDao.ProductType = Convert.ToChar(this.drpProductType.SelectedValue);
            }
            else if (this.rdService.Checked)
            {
                objItemDao.ItemType = 'S';
                objItemDao.ProductType = 'F';
            }
            else if (this.rdUtility.Checked)
            {
                objItemDao.ItemType = 'U';
                objItemDao.VatRebate = Convert.ToDouble(this.drpVATRebate.SelectedValue);
                objItemDao.ProductType = 'R';
            }
            objItemDao.SKU = (!string.IsNullOrEmpty(this.txtSKUCode.Text) ? this.txtSKUCode.Text.Trim() : string.Empty);
            objItemDao.brandName = Utilities.ReplaceQuotes(this.txtBrandName.Text.Trim());
            return objItemDao;
        }

        public static CheckBoxList FillItemPropertyDropDownList(CheckBoxList drpItemPorperty)
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
            return drpItemPorperty;
        }

        private SetItemCategoryDAO fillSubCategoryProperties(SetItemCategoryDAO objSubCategoryDAO)
        {
            objSubCategoryDAO.CategoryName = Utilities.ReplaceQuotes(this.txtSubCategory.Text.Trim());
            objSubCategoryDAO.Description = Utilities.ReplaceQuotes(this.txtSubDesc.Text.Trim());
            objSubCategoryDAO.UserIdInsert = 1;
            objSubCategoryDAO.CategoryLevel = 2;
            objSubCategoryDAO.ParentID = Convert.ToInt32(this.drpCategory.SelectedValue);
            return objSubCategoryDAO;
        }

        private List<int> GetItemProperty()
        {
            SetItemDAO setItemDAO = new SetItemDAO();
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

        protected void gvExcelFile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvItem_PreRender(object sender, EventArgs e)
        {
            try
            {
                this.gvItem.UseAccessibleHeader = true;
                this.gvItem.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch
            {
            }
        }

        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell item = e.Row.Cells[1];
                if (e.Row.RowState != DataControlRowState.Normal)
                {
                    DataControlRowState rowState = e.Row.RowState;
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
                    DataTable receiveInfoOfItem = addItemBLL.GetReceiveInfoOfItem(num);
                    if (receiveInfoOfItem != null && receiveInfoOfItem.Rows.Count > 0)
                    {
                        this.msgBox.AddMessage("Fail to delete. Transaction exists.", MsgBoxs.enmMessageType.Error);
                    }
                    else if (!addItemBLL.deleteItem(num))
                    {
                        this.msgBox.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage("Successfully Deleted.", MsgBoxs.enmMessageType.Success);
                        this.showItemDataInGridView();
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                        this.cddItemCategory.SelectedValue=(itemInfoByItemID.Tables[0].Rows[0]["PARENT_ID"].ToString());
                        this.cddItemSubCategory.SelectedValue=(itemInfoByItemID.Tables[0].Rows[0]["CATEGORY_ID"].ToString());
                    }
                    else
                    {
                        this.cddItemCategory.SelectedValue=(itemInfoByItemID.Tables[0].Rows[0]["CATEGORY_ID"].ToString());
                    }
                    this.drpTypeofMsnt.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["MSRMT_TYPE_ID"].ToString();
                    this.drpTypeofMsnt_SelectedIndexChanged(null, null);
                    this.drpUnit.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["UNIT_ID"].ToString();
                    this.txtItemName.Text = itemInfoByItemID.Tables[0].Rows[0]["ITEM_NAME"].ToString();
                    this.txtSpecification.Text = itemInfoByItemID.Tables[0].Rows[0]["ITEM_SPECIFICATION"].ToString();
                    this.txtHSHeading.Text = itemInfoByItemID.Tables[0].Rows[0]["hs_code_heading"].ToString();
                    this.txtHSSuffix.Text = itemInfoByItemID.Tables[0].Rows[0]["hs_code_suffix"].ToString();
                    this.txtSKUCode.Text = itemInfoByItemID.Tables[0].Rows[0]["ITEM_SKU"].ToString();
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
                    this.drpVATRebate.SelectedValue = "0";
                    if (itemInfoByItemID.Tables[0].Rows[0]["item_type"] == null)
                    {
                        this.rdItem.Checked = true;
                    }
                    else if (itemInfoByItemID.Tables[0].Rows[0]["item_type"].ToString() == "I")
                    {
                        this.rdItem.Checked = true;
                        this.drpProductType.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["product_type"].ToString();
                    }
                    else if (itemInfoByItemID.Tables[0].Rows[0]["item_type"].ToString() == "S")
                    {
                        this.rdService.Checked = true;
                    }
                    else if (itemInfoByItemID.Tables[0].Rows[0]["item_type"].ToString() != "U")
                    {
                        this.rdItem.Checked = true;
                    }
                    else
                    {
                        this.rdUtility.Checked = true;
                        this.drpVATRebate.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["vat_rebate"].ToString();
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["SUPPLIER_REQUIRED"] != null)
                    {
                        this.chkIsSupplierRequired.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["SUPPLIER_REQUIRED"]);
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["expiry_date_required"] != null)
                    {
                        this.chkIsExpiryDtRequired.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["expiry_date_required"]);
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["is_exempted"] != null)
                    {
                        this.chkIsExempted.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_exempted"]);
                    }
                    if (itemInfoByItemID.Tables[0].Rows[0]["is_rebatable"] != null)
                    {
                        this.chkIsRebatable.Checked = Convert.ToBoolean(itemInfoByItemID.Tables[0].Rows[0]["is_rebatable"]);
                    }
                    this.setUpdateModeForAddItem();
                    this.modalPopupForAddItem.Show();
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
            }
            catch (Exception exception1)
            {
                ReallySimpleLog.WriteLog(exception1);
            }
        }

        private bool ItemValidation()
        {
            bool flag;
            AddItemBLL addItemBLL = new AddItemBLL();
            if (!this.rdService.Checked)
            {
                if (this.drpItemCategory.SelectedValue.ToString() == "")
                {
                    this.drpItemCategory.Focus();
                    return false;
                }
                if (this.drpTypeofMsnt.SelectedValue.ToString() == "")
                {
                    this.drpTypeofMsnt.Focus();
                    return false;
                }
                if (this.drpUnit.SelectedValue.ToString() == "")
                {
                    this.drpUnit.Focus();
                    return false;
                }
                if (this.txtItemName.Text.Trim().Length < 1)
                {
                    this.txtItemName.Focus();
                    return false;
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
                    this.msgBox.AddMessage("This item name already exsist.", MsgBoxs.enmMessageType.Error);
                    this.txtItemName.Focus();
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
                    if (!addItemBLL.checkForDuplicateItemNameInUpdate(num1, Convert.ToInt32(this.hnItemID.Value), this.txtItemName.Text.Trim()))
                    {
                        return true;
                    }
                    else
                    {
                        this.msgBox.AddMessage("This subcategory name already exsist.", MsgBoxs.enmMessageType.Error);
                        this.txtItemName.Focus();
                        flag = false;
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    return true;
                }
                return flag;
            }
            return true;
        }

        protected void lnkOpening_click(object sender, EventArgs e)
        {
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
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.part_e.Visible = false;
                this.Session["Opening_EXCEL"] = new ArrayList();
                this.tvwCategory.ForeColor = Color.Black;
                TreeLoad.LoadProblemTree(this.tvwCategory);
                ItemOpeningInfo.FillItemPropertyDropDownList(this.drpItemProperty);
                this.loadMesurmentType();
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
                    DataTable mesurmentTypeService = addItemBLL.getMesurmentTypeService();
                    this.drpTypeofMsnt.DataSource = mesurmentTypeService;
                    this.drpTypeofMsnt.DataTextField = mesurmentTypeService.Columns["CODE_NAME"].ToString();
                    this.drpTypeofMsnt.DataValueField = mesurmentTypeService.Columns["CODE_ID_D"].ToString();
                    this.drpTypeofMsnt.DataBind();
                    DataTable mesurmentIUnitService = addItemBLL.getMesurmentIUnitService();
                    this.drpUnit.DataSource = mesurmentIUnitService;
                    this.drpUnit.DataTextField = mesurmentIUnitService.Columns["UNIT_NAME"].ToString();
                    this.drpUnit.DataValueField = mesurmentIUnitService.Columns["UNIT_ID"].ToString();
                    this.drpUnit.DataBind();
                }
                else if (this.rdItem.Checked)
                {
                    this.loadMesurmentType();
                    this.drpUnit.Items.Clear();
                    ListItem listItem = new ListItem("--- Select ---", "-99");
                    this.drpUnit.Items.Insert(0, listItem);
                }
                else if (this.rdUtility.Checked)
                {
                    this.loadMesurmentType();
                    this.drpUnit.Items.Clear();
                    ListItem listItem1 = new ListItem("--- Select ---", "-99");
                    this.drpUnit.Items.Insert(0, listItem1);
                }
                this.modalPopupForAddItem.Show();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void setAddModeForAddItem()
        {
            this.btnSave.Text = "Save";
        }

        private void setAddModeForCategory()
        {
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
        }

        private void setUpdateModeForSubCategory()
        {
            this.btnAddSubCategory.Text = "Edit Sub Category";
            this.btnSaveSubCategory.Text = "Update";
        }

        private void showItemDataInGridView()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            if (this.hnCategoryID.Value != "")
            {
                int num = Convert.ToInt32(this.hnCategoryID.Value);
                DataSet dataSet = new DataSet();
                dataSet = addItemBLL.getAllItemByCategoryIdForOpeningBalance(num);
                if (dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count != 0)
                {
                    this.gvItem.DataSource = dataSet;
                    this.gvItem.DataBind();
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        string str = dataSet.Tables[0].Rows[i]["purchase_type"].ToString();
                        ((DropDownList)this.gvItem.Rows[i].FindControl("drpPurchaseType")).SelectedValue = str;
                    }
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
            }
            this.displayTotalRecordsFound();
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
                        this.msgBox.AddMessage("This subcategory name already exsist.", MsgBoxs.enmMessageType.Error);
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
                        this.msgBox.AddMessage("This subcategory name already exsist.", MsgBoxs.enmMessageType.Error);
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
            AddItemBLL addItemBLL = new AddItemBLL();
            this.lblTotalRow.Text = "";
            int num = Convert.ToInt32(this.tvwCategory.SelectedNode.Value);
            this.hnCategoryID.Value = this.tvwCategory.SelectedNode.Value;
            this.enableDisableButton(addItemBLL.checkItemCategoryForIsLeaf(num));
            this.showItemDataInGridView();
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            TextBox textBox1 = (TextBox)((GridViewRow)textBox.NamingContainer).FindControl("txtdate");
            for (int i = 1; i <= this.gvItem.Rows.Count; i++)
            {
                GridViewRow item = this.gvItem.Rows[this.gvItem.SelectedIndex + i];
                ((TextBox)this.gvItem.Rows[this.gvItem.SelectedIndex + i].FindControl("txtdate")).Text = textBox1.Text;
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (this.gvItem.Rows.Count > 0)
            {
                for (int i = 1; i <= this.gvItem.Rows.Count; i++)
                {
                    GridViewRow item = this.gvItem.Rows[this.gvItem.SelectedIndex + i];
                    TextBox textBox = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtQuantity");
                    double num = (textBox.Text.Trim().Length > 0 ? Convert.ToDouble(textBox.Text.Trim()) : 0);
                    TextBox textBox1 = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtUnitPrice");
                    double num1 = (textBox1.Text.Trim().Length > 0 ? Convert.ToDouble(textBox1.Text.Trim()) : 0);
                    TextBox str = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtValue");
                    str.Text = (num * num1).ToString();
                }
            }
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (this.gvItem.Rows.Count > 0)
            {
                for (int i = 1; i <= this.gvItem.Rows.Count; i++)
                {
                    GridViewRow item = this.gvItem.Rows[this.gvItem.SelectedIndex + i];
                    TextBox textBox = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtQuantity");
                    double num = (textBox.Text.Trim().Length > 0 ? Convert.ToDouble(textBox.Text.Trim()) : 0);
                    TextBox textBox1 = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtUnitPrice");
                    double num1 = (textBox1.Text.Trim().Length > 0 ? Convert.ToDouble(textBox1.Text.Trim()) : 0);
                    TextBox str = (TextBox)this.gvItem.Rows[item.RowIndex].FindControl("txtValue");
                    str.Text = (num * num1).ToString();
                }
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
                this.msgBox.AddMessage("This category name already exsist.", MsgBoxs.enmMessageType.Error);
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
                        this.msgBox.AddMessage("This category name already exsist.", MsgBoxs.enmMessageType.Error);
                        this.txtCategoryName.Focus();
                        flag = false;
                    }
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    return true;
                }
                return flag;
            }
            return true;
        }

        private class OpeningBalance
        {
            public string hs_code
            {
                get;
                set;
            }

            public string ITEM_NAME
            {
                get;
                set;
            }

            public decimal item_qty
            {
                get;
                set;
            }

            public decimal item_value
            {
                get;
                set;
            }

            public int ItemId
            {
                get;
                set;
            }

            public string opening_balance_date
            {
                get;
                set;
            }

            public string PurchaseType
            {
                get;
                set;
            }

            public int UNIT_ID
            {
                get;
                set;
            }

            public string UNIT_NAME
            {
                get;
                set;
            }

            public OpeningBalance()
            {
            }
        }
    }
}