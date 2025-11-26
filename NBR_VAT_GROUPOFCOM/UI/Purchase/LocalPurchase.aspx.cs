using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Purchase
{
    public partial class LocalPurchase : Page, IRequiresSessionState
    {

        private Collection<DropDownList> drpPropertyCollection = new Collection<DropDownList>();

        private Collection<Label> lblPropertyCollection = new Collection<Label>();

        private PurchaseDetailDAO objDetailDAO;

        private ItemBLL bll = new ItemBLL();

        private AddItemBLL dbLL = new AddItemBLL();

        private WorkOrderBLL dbBLL = new WorkOrderBLL();

        private OrgRegistrationInfoDAO orgRegInfo = new OrgRegistrationInfoDAO();

        private UserPermissionBLL permissionBLL = new UserPermissionBLL();

        private SaleBLL objBLL = new SaleBLL();

        private CSVXMLBLL dbBLLLL = new CSVXMLBLL();

        public ArrayList objectPropertyNameList = new ArrayList();

        public ArrayList tableDataList = new ArrayList();

        public ArrayList tableNameList = new ArrayList();

        public ArrayList validationList = new ArrayList();

        public short status = 1;

        private string color;

        private string size;

        private string grade;

        private string company;

        private string specification;
        public LocalPurchase()
        {
        }

        private void AddApproveDetailDataInGrid()
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LISTA"];
                this.gvApprvItem.DataSource = item;
                this.gvApprvItem.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void AddDetailDataInGrid()
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"];
                this.gvItem.DataSource = item;
                this.gvItem.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnAdd.Text == "Add Item")
                {
                    if (this.Validation())
                    {
                        this.fillDetailProperties();
                        this.AddDetailDataInGrid();
                        this.GetTotalSaleValue();
                        this.ClearDetailControlsValue();
                        this.ClearCheckBox();
                    }
                }
                else if (this.Validation())
                {
                    this.fillDetailProperties();
                    this.AddDetailDataInGrid();
                    this.GetTotalSaleValue();
                    this.ClearDetailControlsValue();
                    this.ClearCheckBox();
                    this.setDetaiAddMode();
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "Purchase_Challan_6.3", "btnAddItem_Click");
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            try
            {
                base.Response.Redirect("~/UI/Others/PartySetup.aspx");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearDetailControlsValue();
            this.Session["PURCHASE_DETAIL_LIST"] = new ArrayList();
            this.gvItem.DataSource = null;
            this.gvItem.DataBind();
            this.lblMessage.Text = "";
            this.txtTotalPurchasePrice.Text = "";
            this.setDetaiAddMode();
        }

        protected void btnGRNVoucherSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.MasterValidation())
                {
                    ChallanBLL challanBLL = new ChallanBLL();
                    PurchaseMasterDAO purchaseMasterDAO = new PurchaseMasterDAO();
                    purchaseMasterDAO = this.GetInserMasterValues(purchaseMasterDAO);
                    if (purchaseMasterDAO != null)
                    {
                        ArrayList arrayLists = new ArrayList();
                        arrayLists = this.LoadDetailsData();
                        if (arrayLists == null || arrayLists.Count == 0)
                        {
                            this.gvVoucher.DataSource = null;
                            this.gvVoucher.DataBind();
                            this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else
                        {
                            string str = this.ddlGRNNo.SelectedValue.ToString();
                            string str1 = this.ddlVoucher.SelectedValue.ToString();
                            if (!this.dbBLL.InsertVoucherData(purchaseMasterDAO, arrayLists, str, str1))
                            {
                                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                            else
                            {
                                this.msgBox.AddMessage("Purchase Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                this.ClearVoucherValue();
                            }
                        }
                    }
                    else
                    {
                        this.msgBox.AddMessage("Please insert master data properly.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnRefreshChallan_Click(object sender, EventArgs e)
        {
            this.ClearAllControlsValue();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int currentMonth = DateTime.Now.Month;
                int monthId = Convert.ToDateTime(txtChallanDate.Text).Month;
                //if (currentMonth != monthId)
                //{
                //    string msg = "Transaction Not Allowed for this Date!";
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + msg + "')", true);
                //    return;
                //}
                // string message = "Success data not allowed";
                //// ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + message + "')", true);
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + message + "')", true);
                // return;



                AddItemBLL addItemBLL = new AddItemBLL();


                //  ScriptManager.RegisterStartupScript(UI.UserControls, Control.GetType, "Script", "swal('" + Title + "','" + Message + "','error');", true);

                this.lblMessage.Text = "";
                if (this.MasterValidation())
                {
                    ChallanBLL challanBLL = new ChallanBLL();
                    PurchaseMasterDAO purchaseMasterDAO = new PurchaseMasterDAO();
                    purchaseMasterDAO = this.GetInserMasterValues(purchaseMasterDAO);
                    if (purchaseMasterDAO != null)
                    {
                        ArrayList arrayLists = new ArrayList();
                        ArrayList item = new ArrayList();
                        item = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"];

                        //foreach (PurchaseDetailDAO items in item)
                        //{
                        //    int itemid =Convert.ToInt32(items.ItemID);



                        //    //  Boolean pricestatus = false;
                        //    Boolean pricestatus = true;

                        //    DataTable itemIsPriceDeclarable = addItemBLL.getItemIsPriceDeclare(items.ItemID);

                        //    //if (itemIsPriceDeclarable.Rows.Count > 0)
                        //    //{
                        //    //    pricestatus = Convert.ToBoolean(itemIsPriceDeclarable.Rows[0]["is_price_declaration"]);
                        //    //}

                        //    //if (pricestatus == true)
                        //    //{
                        //    //    DataTable itemIsPriceDeclarNew = addItemBLL.getItemIsPriceDeclareNew(items.ItemID);

                        //    //    if (itemIsPriceDeclarNew.Rows.Count <= 0)
                        //    //    {

                        //    //        items.PurchaseVAT = 0;
                        //    //        items.Rebatable = "No";
                        //    //        items.IsRebatable = false;
                        //    //       // items.Checked = false;


                        //    //        //  string msg = "Price not declared!";
                        //    //        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + msg + "')", true);
                        //    //        // return;
                        //    //    }
                        //    //}

                        //}

                        if (item == null || item.Count == 0)
                        {
                            this.gvItem.DataSource = null;
                            this.gvItem.DataBind();
                            this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else
                        {
                            bool flag = false;
                            if (this.btnSave.Text == LocalPurchase.enmBtnText.Save.ToString())
                            {
                                if (!this.chkExcel.Checked)
                                {
                                    flag = challanBLL.InsertPurchaseData(purchaseMasterDAO, item);
                                }
                                else
                                {
                                    arrayLists = (ArrayList)this.Session["ProductionRcv_EXCEL"];
                                    flag = challanBLL.InsertPurchaseDatawithadditional(purchaseMasterDAO, item, arrayLists);
                                }
                                if (!flag)
                                {
                                    this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                                }
                                else
                                {
                                  //  this.msgBox.AddMessage("Purchase Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                    string smg = "Purchase Information Successfully Saved.";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('"+smg+"')", true);
                                    this.itemId.Text = "";
                                    this.ClearAllControlsValue();
                                    this.ClearCheckBox();
                                    this.VATLastUpdatedBalance();
                                    this.SDLastUpdatedBalance();
                                    this.insertBalance();
                                }
                            }
                        }
                    }
                    else
                    {
                        // this.msgBox.AddMessage("Please insert master data properly.", MsgBoxs.enmMessageType.Error);
                        string smg = "Please insert master data properly.";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + smg + "')", true);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "Purchase_Challan_6.3", "btnSave_Click");
            }
        }

        protected void btnShowDataByVoucher_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string selectedValue = this.ddlGRNNo.SelectedValue;
                string str = this.ddlVoucher.SelectedValue;
                if (selectedValue != "-1" || str != "-1")
                {
                    dataTable = this.dbBLL.GetAllDataByVoucher(selectedValue, str);
                    this.gvVoucher.DataSource = dataTable;
                    this.gvVoucher.DataBind();
                }
                else
                {
                    this.msgBox.AddMessage(" Please Select Any GRN No OR Voucher No ", MsgBoxs.enmMessageType.Attention);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnUpdateTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = "";
                string str = "";
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"];
                if (arrayLists == null || arrayLists.Count == 0)
                {
                    this.gvItem.DataSource = null;
                    this.gvItem.DataBind();
                    this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    int num = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ChallanID"]);
                    ChallanBLL challanBLL = new ChallanBLL();
                    DataTable approverStage = challanBLL.GetApproverStage();
                    if (approverStage.Rows.Count > 0)
                    {
                        DataTable purchaseApproveStage = challanBLL.getPurchaseApproveStage(num);
                        if (purchaseApproveStage.Rows.Count > 0)
                        {
                            int count = approverStage.Rows.Count;
                            int num1 = Convert.ToInt32(purchaseApproveStage.Rows[0]["approver_stage"]);
                            int num2 = count - num1;
                            str = (num2 != 1 ? num2.ToString() : "F");
                        }
                    }
                    if (!challanBLL.UpdatePurchaseData(str, arrayLists, num))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage("Purchase Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.itemId.Text = "";
                        this.ClearAllControlsValue();
                        this.ClearCheckBox();
                        this.VATLastUpdatedBalance();
                        this.SDLastUpdatedBalance();
                        this.insertBalance();
                        this.LoadPurchaseData();
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "Purchase_Challan_6.3", "btnSave_Click");
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
                                contructualProductionIssueDAO.Item_id = Convert.ToInt16(this.itemId.Text);
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
                 BLL.Utility.InsertErrorTrack(exception2.Message, "LocalPurchase", "btnUpload_Click");
            }
            Utilities.KillExcelFileProcess();
        }

        private void CalculatePriceReverse()
        {
            try
            {
                if (this.txtQuantity.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0 && this.lblTotalPurchasePrc.Text.Length > 0 && Convert.ToDouble(this.lblTotalPurchasePrc.Text) > 0)
                {
                    double num = Convert.ToDouble(this.txtQuantity.Text);
                    double num1 = Convert.ToDouble(this.lblTotalPurchasePrc.Text);
                    double num2 = 0;
                    double num3 = 0;
                    double num4 = 0;
                    double num5 = 0;
                    if ((this.lblPurchaseSD.Text == "" || Convert.ToDouble(this.lblPurchaseSD.Text) == 0) && (this.lblPurchaseVAT.Text == "" || Convert.ToDouble(this.lblPurchaseVAT.Text) == 0))
                    {
                        this.lblTotalSD.Text = "0";
                        this.lblTotalVAT.Text = "0";
                        this.lblTotalPrice.Text = this.lblTotalPurchasePrc.Text;
                        this.txtPurchaseUnitPrice.Text = (num1 / num).ToString("#0.##");
                    }
                    else
                    {
                        num2 = (this.lblPurchaseVAT.Text.Length > 0 || Convert.ToDouble(this.lblPurchaseVAT.Text) > 0 ? Convert.ToDouble(this.lblPurchaseVAT.Text) * num1 / (100 + Convert.ToDouble(this.lblPurchaseVAT.Text)) : 0);
                        num4 = num1 - num2;
                        num3 = (this.lblPurchaseSD.Text.Length > 0 || Convert.ToDouble(this.lblPurchaseSD.Text) > 0 ? Convert.ToDouble(this.lblPurchaseSD.Text) * num4 / (100 + Convert.ToDouble(this.lblPurchaseSD.Text)) : 0);
                        num5 = num4 - num3;
                        this.lblTotalSD.Text = num3.ToString("N2");
                        this.lblTotalVAT.Text = num2.ToString("N2");
                        this.lblTotalPrice.Text = num5.ToString("N2");
                        this.txtPurchaseUnitPrice.Text = (num5 / num).ToString("N2");
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ChckedChanged(object sender, EventArgs e)
        {
            if (!this.chkExcel.Checked)
            {
                this.part_e.Visible = false;
                return;
            }
            if (this.itemId.Text == "")
            {
                this.chkExcel.Checked = false;
                this.msgBox.AddMessage("Please Select Item Name first.", MsgBoxs.enmMessageType.Error);
                return;
            }
            this.EnableOrDisablePropertyForItemforExcel();
            if (!(this.hfProperty1.Value == "0") || !(this.hfProperty2.Value == "0") || !(this.hfProperty3.Value == "0") || !(this.hfProperty4.Value == "0") || !(this.hfProperty5.Value == "0"))
            {
                this.part_e.Visible = true;
                this.part_b.Visible = false;
                return;
            }
            this.chkExcel.Checked = false;
            this.msgBox.AddMessage("No Additional Property Exist.", MsgBoxs.enmMessageType.Error);
        }

        protected void chkDeemedExport_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void chkExcelImport_OnCheckedChanged(object sender, EventArgs e)
        {
            this.part_e.Visible = true;
            this.part_v.Visible = false;
            this.Session["SALES_EXCEL_SHEET"] = new ArrayList();
        }

        protected void chkExempted_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void chkInexplicitExport_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void chkManualInput_OnCheckedChanged(object sender, EventArgs e)
        {
            this.part_a.Visible = true;
            this.part_b.Visible = true;
            this.part_c.Visible = true;
            this.part_d.Visible = true;
            this.part_e.Visible = false;
            this.gvExcelFile.Visible = false;
            this.part_v.Visible = false;
            this.Session["SALES_EXCEL_SHEET"] = new ArrayList();
        }

        protected void chkSaleValue_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.GETSalePart();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void chkTaxDeducted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkTaxDeducted.Checked)
                {
                    this.txtvdsamount.Text = this.txtPurchaseVAT.Text.ToString();
                    this.partVDS.Visible = true;
                }
                else
                {
                    this.txtvdsamount.Text = "";
                    this.partVDS.Visible = false;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void chkVoucherNo_CheckedChanged(object sender, EventArgs e)
        {
            this.part_a.Visible = false;
            this.part_b.Visible = false;
            this.part_c.Visible = false;
            this.part_d.Visible = false;
            this.part_e.Visible = false;
            this.part_v.Visible = true;
            this.Session["PURCHASE_DETAIL_LIST_MQMM2"] = new ArrayList();
        }

        protected void chkZeroRate_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ClearAllControlsValue()
        {
            try
            {
                this.gvExcelFile.DataSource = null;
                this.gvExcelFile.DataBind();
                this.Session["ProductionRcv_EXCEL"] = new ArrayList();
                this.chkExcel.Checked = false;
                this.part_e.Visible = false;
                this.txtTotalPurchasePrice.Text = "";
                this.GetPartyInfo();
                this.txtChallanNo.Text = "";
                this.txtChallanDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy hh:mm:ss tt");
                this.drpParty.SelectedValue = "-99";
                this.drpRegType.SelectedValue = "0";
                this.txtPartyBIN.Text = "";
                this.txtAddress.Text = "";
                this.txtDestination.Text = "";
                this.drpVehicleType.SelectedValue = "-99";
                this.drpCategory.SelectedValue = "-99";
                this.drpSubCategory.SelectedValue = "-99";
                this.txtVehicleNo.Text = "";
                this.lblMessage.Text = "";
                this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                this.btnAddParty.Text = "New";
                this.drpParty.Enabled = true;
                this.drpProperty1.Visible = false;
                this.drpProperty2.Visible = false;
                this.drpProperty3.Visible = false;
                this.drpProperty4.Visible = false;
                this.drpProperty5.Visible = false;
                this.chkExempted.Checked = false;
                this.chkInexplicitExport.Checked = false;
                this.chkRebatable.Checked = false;
                this.chkTaxDeducted.Checked = false;
                this.chkTaxDeducted.Attributes["style"] = "color:black;";
                this.chkIsFixed.Checked = false;
                this.chkIsFixed.Attributes["style"] = "color:black;";
                this.chkMrp.Checked = false;
                this.chkMrp.Attributes["style"] = "color:black;";
                this.productName.Text = "";
                this.lblPurchaseVAT.Text = "";
                this.lblPurchaseSD.Text = "";
                this.lblProperty1.Visible = false;
                this.lblProperty2.Visible = false;
                this.lblProperty3.Visible = false;
                this.lblProperty4.Visible = false;
                this.lblProperty5.Visible = false;
                this.chkZeroRate.Checked = false;
                this.chkZeroRate.Attributes["style"] = "color:black;";
                this.txtScrollNo.Text = "";
                this.drpType.SelectedIndex = 1;
                this.ClearDetailControlsValue();
                this.drpCategory.SelectedValue = "-99";
                this.Session["PURCHASE_DETAIL_LIST"] = new ArrayList();
                this.gvItem.DataSource = null;
                this.gvItem.DataBind();
                this.chkCash.Checked = false;
                this.chkCredit.Checked = false;
                this.chkCheque.Checked = false;
                this.chkRocket.Checked = false;
                this.chkBkash.Checked = false;
                this.chkTT.Checked = false;
                this.chkEFT.Checked = false;
                this.CheDebitCard.Checked = false;
                this.chkPayOrder.Checked = false;
                this.ChkOther.Checked = false;
                this.txtCashAmount.Text = "";
                this.txtCreditAmount.Text = "";
                this.txtChequeAmount.Text = "";
                this.txtRocketAmount.Text = "";
                this.txtbKashAmount.Text = "";
                this.txtTPTAmount.Text = "";
                this.txtEFTAmount.Text = "";
                this.txtDebitCartAmount.Text = "";
                this.txtPayOrderAmount.Text = "";
                this.txtOthersAmount.Text = "";
                this.drpSubCategory.Items.Clear();
                this.drpItem.Items.Clear();
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("-- Select --", "-99");
                this.LoadItems();
                this.drpItem.Items.Insert(0, listItem1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void ClearAllControlsValuemqmm()
        {
            this.GetPartyInfo();
            this.txtChallanNo.Text = string.Empty;
            this.txtChallanDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy hh:mm:ss tt");
            this.drpParty.SelectedValue = "-99";
            this.txtPartyBIN.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtDestination.Text = string.Empty;
            this.drpVehicleType.SelectedValue = "-99";
            this.txtVehicleNo.Text = string.Empty;
            this.lblMessage.Text = string.Empty;
            this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
            this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
            this.btnAddParty.Text = "New";
            this.drpParty.Enabled = true;
            this.productName.Text = string.Empty;
            this.txtScrollNo.Text = string.Empty;
            this.drpType.SelectedIndex = 0;
            this.Session["PURCHASE_DETAIL_LIST_MQMM"] = new ArrayList();
            this.gvExcelFile.DataSource = null;
            this.gvExcelFile.DataBind();
        }

        private void ClearCheckBox()
        {
            this.chkRebateCurrent.Checked = false;
            this.chkReusable.Checked = false;
            this.chkExempted.Checked = false;
            this.chkExempted.Attributes["style"] = "color:black;";
            this.chkReduce.Checked = false;
            this.chkReduce.Attributes["style"] = "color:black;";
            this.chkInexplicitExport.Checked = false;
            this.chkInexplicitExport.Attributes["style"] = "color:black;";
            this.chkRebatable.Checked = false;
            this.chkRebatable.Attributes["style"] = "color:black;";
            this.chkTaxDeducted.Checked = false;
            this.chkTaxDeducted.Attributes["style"] = "color:black;";
            this.chkIsFixed.Checked = false;
            this.chkIsFixed.Attributes["style"] = "color:black;";
            this.chkMrp.Checked = false;
            this.chkMrp.Attributes["style"] = "color:black;";
            this.chkZeroRate.Checked = false;
            this.chkZeroRate.Attributes["style"] = "color:black;";
        }

        private void ClearDetailControlsValue()
        {
            this.lblPriceDiff.Text = "";
            this.Label25.Text = "%";
            this.lblfxdVT.Text = "";
            this.drpItem.SelectedValue = "-99";
            this.lblSku.Text = "";
            for (int i = 0; i < this.drpPropertyCollection.Count; i++)
            {
                this.drpPropertyCollection[i].SelectedIndex = 0;
                this.drpPropertyCollection[i].Enabled = false;
            }
            this.txtQuantity.Text = "";
            this.lblPurchaseUnitPrice.Text = "0.00";
            this.txtPurchaseUnitPrice.Text = "";
            this.txtPurchaseVAT.Text = "";
            this.txtPurchaseSD.Text = "";
            this.txtSaleUnitPrice.Text = "";
            this.txtSaleVatablePrice.Text = "";
            this.txtSaleVat.Text = "";
            this.txtSaleSD.Text = "";
            this.lblSaleVat.Text = "";
            this.chkTaxDeducted.Checked = false;
            this.chkDeemedExport.Checked = false;
            this.chkExempted.Checked = false;
            this.chkRebatable.Checked = false;
            this.chkZeroRate.Checked = false;
            this.chkIsFixed.Checked = false;
            this.lblHSCode.Text = ".";
            this.lblTotalPrice.Text = "0.00";
            this.lblTotalSD.Text = "0.00";
            this.lblTotalVAT.Text = "0.00";
            this.lblTotalPurchasePrc.Text = "";
            this.hdUnitID.Value = "";
            this.hdPriceID.Value = "";
            this.remarks2.Text = "";
            this.hdIsExempted.Value = "0";
            this.txtPriceIncludingVat.Text = "";
            this.lblPurchaseVAT.Text = string.Empty;
            this.lblPurchaseSD.Text = string.Empty;
            this.lblSaleSD.Text = string.Empty;
            this.chkSaleValue.Checked = false;
            this.GETSalePart();
            this.chkDeemedExport.Attributes["style"] = "color:black;";
            this.chkZeroRate.Attributes["style"] = "color:black;";
            this.chkIsFixed.Attributes["style"] = "color:black;";
            this.chkRebatable.Attributes["style"] = "color:black;";
            this.chkExempted.Attributes["style"] = "color:black;";
            this.drpProperty1.Visible = false;
            this.drpProperty2.Visible = false;
            this.drpProperty3.Visible = false;
            this.drpProperty4.Visible = false;
            this.drpProperty5.Visible = false;
            this.lblProperty1.Visible = false;
            this.lblProperty2.Visible = false;
            this.lblProperty3.Visible = false;
            this.lblProperty4.Visible = false;
            this.lblProperty5.Visible = false;
            this.drpProperty1.Items.Clear();
            this.drpProperty2.Items.Clear();
            this.drpProperty3.Items.Clear();
            this.drpProperty4.Items.Clear();
            this.drpProperty5.Items.Clear();
            this.drpCategory.SelectedValue = "-99";
            this.drpSubCategory.SelectedValue = "-99";
            this.lblvdstx.Visible = false;
            this.txtvdsamount.Visible = false;
            this.txtTotalPrice.Text = "";
            this.lblCValue.Text = "";
            this.lblUID.Text = "";
            this.lblUnitCode.Text = "";
            this.drpUnit.SelectedValue = "-99";
            this.txtPurchaseAIT.Text = "";
            this.lblPurchaseAIT.Text = "";
        }

        private void ClearVoucherValue()
        {
            this.ddlGRNNo.SelectedValue = "-1";
            this.ddlVoucher.SelectedValue = "-1";
            this.GetPartyInfo();
            this.txtChallanNo.Text = "";
            this.txtChallanDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.drpParty.SelectedValue = "-99";
            this.txtPartyBIN.Text = "";
            this.txtAddress.Text = "";
            this.txtDestination.Text = "";
            this.drpVehicleType.SelectedValue = "-99";
            this.txtVehicleNo.Text = "";
            this.lblMessage.Text = "";
            this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
            this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
            this.btnAddParty.Text = "New";
            this.drpParty.Enabled = true;
            this.txtScrollNo.Text = "";
            this.drpType.SelectedIndex = 0;
            this.gvVoucher.DataSource = null;
            this.gvVoucher.DataBind();
        }

        protected void ddlGRNNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string selectedValue = this.ddlGRNNo.SelectedValue;
                dataTable = this.dbBLL.GetVoucherNoByGRNNo(selectedValue);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.ddlVoucher.SelectedValue = dataTable.Rows[0]["vouchar_no"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ddlVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string selectedValue = this.ddlVoucher.SelectedValue;
                dataTable = this.dbBLL.GetGRNNoByVoucherNo(selectedValue);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.ddlGRNNo.SelectedValue = dataTable.Rows[0]["grn_no"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpBranchName.SelectedValue == "-99")
            {
                this.lblBranchAddress.Text = string.Empty;
                return;
            }
            this.GetBranchAddress();
            this.GetBranchBIN();
        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadSubCategory();
                this.LoadItemsByCatgSubCatg();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpChDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpChDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpDlDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpDlDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblPriceDiff.Text = "";
            this.gvExcelFile.DataSource = null;
            this.gvExcelFile.DataBind();
            this.Session["ProductionRcv_EXCEL"] = new ArrayList();
            this.chkExcel.Checked = false;
            this.part_e.Visible = false;
            this.lblfxdVT.Text = "";
            this.Label25.Text = "%";
            this.lblPurchaseVAT.Text = "";
            this.chkRebateCurrent.Checked = false;
            this.txtQuantity.Text = "";
            this.txtTotalPrice.Text = "";
            this.txtPriceIncludingVat.Text = "";
            this.txtPurchaseSD.Text = "";
            this.txtPurchaseVAT.Text = "";
            this.txtSaleUnitPrice.Text = "";
            this.txtSaleSD.Text = "";
            this.txtSaleVat.Text = "";
            this.txtvdsamount.Text = "";
            this.remarks2.Text = "";
            this.ClearCheckBox();
            this.chkIsFixed.Attributes["style"] = "color:black;";
            this.chkZeroRate.Attributes["style"] = "color:black;";
            this.EnableOrDisablePropertyForItem();
            Int32 num = 0;
            if (this.drpItem.SelectedValue != "-99")
            {
                string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                if (strArrays != null && strArrays.Count<string>() > 0)
                {
                    this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 2];
                }
                num = Convert.ToInt32(this.drpItem.SelectedValue);
                this.itemId.Text = num.ToString();
                DataTable item = (DataTable)this.Session["ITEM_INFO"];
                DataRow[] dataRowArray = item.Select(string.Concat("item_id = ", num));
                DataRow dataRow = dataRowArray[0];
                if (dataRow != null)
                {
                    this.lblProductType.Text = dataRow["PRODUCT_TYPE"].ToString();
                    this.lblSku.Text = dataRow["item_sku"].ToString();
                }
                AddItemBLL addItemBLL = new AddItemBLL();
                int num1 = 0;
                num1 = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable reusable = addItemBLL.getReusable(num1);
                if (reusable.Rows.Count > 0)
                {
                    this.chkReusable.Checked = Convert.ToBoolean(reusable.Rows[0]["is_reusable"]);
                }
                DataTable truncated = addItemBLL.getTruncated(num1);
                if (truncated.Rows.Count > 0)
                {
                    this.HiddenIsTruncated.Value = null;
                    if (!Convert.ToBoolean(truncated.Rows[0]["is_truncated"]))
                    {
                        this.HiddenIsTruncated.Value = null;
                        this.chkReduce.Checked = false;
                    }
                    else
                    {
                        this.HiddenIsTruncated.Value = "is_truncated";
                        this.chkReduce.Checked = true;
                        this.chkReduce.Attributes["style"] = "color:Green;";
                    }
                }
                num1 = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num1);




                



                if (itemIsTeriff.Rows.Count <= 0)
                {
                    this.chkIsFixed.Checked = false;
                }

                Boolean pricestatus = false;

              //  DataTable itemIsPriceDeclarable = addItemBLL.getItemIsPriceDeclare(num1);

                //if (itemIsPriceDeclarable.Rows.Count > 0)
                //{
                //    pricestatus = Convert.ToBoolean(itemIsPriceDeclarable.Rows[0]["is_price_declaration"]);
                //}

                if(false)
                {
                  //  DataTable itemIsPriceDeclarNew = addItemBLL.getItemIsPriceDeclareNew(num1);

                    //if (itemIsPriceDeclarNew.Rows.Count <= 0)
                    //{
                    //    string msg = "Price not declared!";
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + msg + "')", true);
                    //   // return;
                    //}
                }

               




                else if (Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                {
                    this.chkIsFixed.Checked = true;
                    this.chkIsFixed.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsMRP = addItemBLL.getItemIsMRP(num1);
                if (itemIsMRP.Rows.Count <= 0)
                {
                    this.chkMrp.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsMRP.Rows[0]["is_mrp"]))
                {
                    this.chkMrp.Checked = true;
                    this.chkMrp.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsZeroRate = addItemBLL.getItemIsZeroRate(num1);
                if (itemIsZeroRate.Rows.Count <= 0)
                {
                    this.chkZeroRate.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsZeroRate.Rows[0]["is_zero_rate"]))
                {
                    this.chkZeroRate.Checked = true;
                    this.chkZeroRate.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsRebatable = addItemBLL.getItemIsRebatable(num1);
                if (itemIsRebatable.Rows.Count <= 0)
                {
                    this.chkRebateCurrent.Checked = false;
                    this.chkRebatable.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsRebatable.Rows[0]["is_rebatable"]))
                {
                    this.chkRebateCurrent.Checked = true;
                    this.chkRebatable.Checked = true;
                    this.chkRebatable.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsExempted = addItemBLL.GetItemIsExempted(num1);
                if (itemIsExempted.Rows.Count <= 0)
                {
                    this.chkExempted.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsExempted.Rows[0]["is_exempted"]))
                {
                    this.chkExempted.Checked = true;
                    this.chkExempted.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsVds = addItemBLL.GetItemIsVds(num1);
                if (itemIsVds.Rows.Count <= 0)
                {
                    this.chkTaxDeducted.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsVds.Rows[0]["is_vds"]))
                {
                    this.chkTaxDeducted.Checked = true;
                    this.chkTaxDeducted.Attributes["style"] = "color:Green;";
                    this.partVDS.Visible = true;
                }
            }
            this.GetPriceInfo();
        }

        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpParty.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpParty.SelectedValue);
                    DataTable item = (DataTable)this.Session["PARTY_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("Party_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.txtPartyBIN.Text = dataRow["party_bin"].ToString();
                        this.txtAddress.Text = dataRow["party_address"].ToString();
                        this.txtDestination.Text = dataRow["ultimate_destination"].ToString();
                        this.partyVDS.Text = dataRow["is_vds_deduct"].ToString();
                        this.txtNationalId.Text = dataRow["national_id_no"].ToString();
                        DataTable partyInfo = this.orgRegInfo.GetPartyInfo(num);
                        this.txtBusinessInfo.Text = partyInfo.Rows[0]["business_info"].ToString();
                        this.txtAreaOfMfg.Text = partyInfo.Rows[0]["area_of_mfg"].ToString();
                        string empty = string.Empty;
                        if (partyInfo.Rows[0]["major_area_of_ecn_activity"].ToString() != "")
                        {
                            int num1 = 0;
                            DataTable economicInfo = this.orgRegInfo.GetEconomicInfo(partyInfo.Rows[0]["major_area_of_ecn_activity"].ToString());
                            for (int i = 0; i < economicInfo.Rows.Count; i++)
                            {
                                if (num1 != 0)
                                {
                                    empty = string.Concat(empty, ",", economicInfo.Rows[i]["code_name"].ToString());
                                }
                                else
                                {
                                    empty = economicInfo.Rows[i]["code_name"].ToString();
                                    num1++;
                                }
                            }
                        }
                        this.txtMajorEcoActivity.Text = empty;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpProp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetPriceInfo(1);
        }

        protected void drpProp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetPriceInfo(2);
        }

        protected void drpProp3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetPriceInfo(3);
        }

        protected void drpProp4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetPriceInfo(4);
        }

        protected void drpProp5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetPriceInfo(5);
        }

        protected void drpProperty1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpProperty2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpProperty3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpProperty4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpProperty5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpRegType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPartyInfoRegistrationWise(Convert.ToInt16(this.drpRegType.SelectedValue.Trim()));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadCategory();
                this.LoadItemsByCatgSubCatg();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                double num = 0;
                string str = "";
                int num1 = Convert.ToInt32(this.drpUnit.SelectedValue);
                DataTable unitConversionData = addItemBLL.getUnitConversionData(num1);
                if (unitConversionData.Rows.Count <= 0)
                {
                    this.lblCValue.Text = "0.00";
                    this.lblUID.Text = num1.ToString();
                }
                else
                {
                    num = Convert.ToDouble(unitConversionData.Rows[0]["value_to"]);
                    this.lblCValue.Text = num.ToString();
                    int num2 = Convert.ToInt32(unitConversionData.Rows[0]["unit_id"]);
                    this.lblUID.Text = num2.ToString();
                    str = unitConversionData.Rows[0]["unit_code"].ToString();
                    this.lblUnitCode.Text = str;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ReallySimpleLog.WriteLog(exception);
                throw exception;
            }
        }

        private void EnableOrDisablePropertyForItem()
        {
            if (!string.IsNullOrEmpty(this.drpItem.SelectedValue))
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = 0;
                if (this.drpItem.SelectedValue == "-99")
                {
                    this.chkRebatable.Checked = false;
                }
                else
                {
                    num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(num);
                    this.hdUnitID.Value = itemRequiredProperty.Rows[0]["unit_id"].ToString();
                    this.hdItemType.Value = itemRequiredProperty.Rows[0]["item_type"].ToString();
                    HiddenField str = this.hdProp1;
                    int num1 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop1_required"]);
                    str.Value = num1.ToString();
                    HiddenField hiddenField = this.hdProp2;
                    int num2 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop2_required"]);
                    hiddenField.Value = num2.ToString();
                    HiddenField str1 = this.hdProp3;
                    int num3 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop3_required"]);
                    str1.Value = num3.ToString();
                    HiddenField hiddenField1 = this.hdProp4;
                    int num4 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop4_required"]);
                    hiddenField1.Value = num4.ToString();
                    HiddenField str2 = this.hdProp5;
                    int num5 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop5_required"]);
                    str2.Value = num5.ToString();
                    this.GetUnitName(Convert.ToInt32(this.hdUnitID.Value));
                    Convert.ToBoolean(itemRequiredProperty.Rows[0]["is_vds"]);
                    if (Convert.ToBoolean(this.orgVDS.Text) && Convert.ToBoolean(this.partyVDS.Text))
                    {
                        if (!Convert.ToBoolean(itemRequiredProperty.Rows[0]["is_vds"]))
                        {
                            this.chkTaxDeducted.Checked = false;
                            this.lblvdstx.Visible = false;
                            this.txtvdsamount.Visible = false;
                        }
                        else
                        {
                            this.chkTaxDeducted.Checked = true;
                            this.lblvdstx.Visible = true;
                            this.chkTaxDeducted.Attributes["style"] = "color:red;";
                            this.txtvdsamount.Visible = true;
                        }
                    }
                    else if (Convert.ToBoolean(this.orgVDS.Text) && !Convert.ToBoolean(this.partyVDS.Text))
                    {
                        if (!Convert.ToBoolean(itemRequiredProperty.Rows[0]["is_vds"]))
                        {
                            this.lblvdstx.Visible = true;
                            this.txtvdsamount.Visible = true;
                        }
                        else
                        {
                            this.chkTaxDeducted.Checked = true;
                            this.lblvdstx.Visible = true;
                            this.chkTaxDeducted.Attributes["style"] = "color:green;";
                            this.txtvdsamount.Visible = true;
                        }
                    }
                    string str3 = itemRequiredProperty.Rows[0]["is_deemedexport"].ToString();
                    HiddenField hiddenField2 = this.hdIsExempted;
                    short num6 = Convert.ToInt16(itemRequiredProperty.Rows[0]["is_exempted"]);
                    hiddenField2.Value = num6.ToString();
                    if (str3 != "")
                    {
                        HiddenField hiddenField3 = this.hdDeemedExport;
                        short num7 = Convert.ToInt16(itemRequiredProperty.Rows[0]["is_deemedexport"]);
                        hiddenField3.Value = num7.ToString();
                    }
                    else
                    {
                        this.hdDeemedExport.Value = Convert.ToInt16("0").ToString();
                    }
                    if (itemRequiredProperty.Rows[0]["zero_rate"].ToString() != "")
                    {
                        HiddenField str4 = this.hdZerorate;
                        short num8 = Convert.ToInt16(itemRequiredProperty.Rows[0]["zero_rate"]);
                        str4.Value = num8.ToString();
                    }
                    else
                    {
                        this.hdZerorate.Value = Convert.ToInt16("0").ToString();
                    }
                    if (itemRequiredProperty.Rows[0]["is_rebatable"].ToString() != "")
                    {
                        HiddenField hiddenField4 = this.hdrebatable;
                        short num9 = Convert.ToInt16(itemRequiredProperty.Rows[0]["is_rebatable"]);
                        hiddenField4.Value = num9.ToString();
                    }
                    else
                    {
                        this.hdrebatable.Value = Convert.ToInt16("0").ToString();
                    }
                    short num10 = 0;
                    short num11 = 0;
                    short num12 = 0;
                    short num13 = 0;
                    short num14 = 0;
                    DataTable appCodeDetailName = null;
                    num10 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id1"]);
                    num11 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id2"]);
                    num12 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id3"]);
                    num13 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id4"]);
                    num14 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id5"]);
                    DataTable itemProperty = addItemBLL.getItemProperty(num10);
                    if (itemProperty == null)
                    {
                        this.drpProperty1.Visible = false;
                        this.lblProperty1.Visible = false;
                    }
                    else if (itemProperty.Rows.Count <= 0)
                    {
                        this.drpProperty1.Visible = false;
                        this.lblProperty1.Visible = false;
                    }
                    else
                    {
                        this.drpProperty1.DataSource = itemProperty;
                        this.drpProperty1.DataTextField = itemProperty.Columns["property_name"].ToString();
                        this.drpProperty1.DataValueField = itemProperty.Columns["property_id"].ToString();
                        this.drpProperty1.DataBind();
                        ListItem listItem = new ListItem("---Select---", "-99");
                        this.drpProperty1.Items.Insert(0, listItem);
                        this.drpProperty1.Visible = true;
                        this.lblProperty1.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num10);
                        this.lblProperty1.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable = addItemBLL.getItemProperty(num11);
                    if (dataTable == null)
                    {
                        this.drpProperty2.Visible = false;
                        this.lblProperty2.Visible = false;
                    }
                    else if (dataTable.Rows.Count <= 0)
                    {
                        this.drpProperty2.Visible = false;
                        this.lblProperty2.Visible = false;
                    }
                    else
                    {
                        this.drpProperty2.DataSource = dataTable;
                        this.drpProperty2.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProperty2.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProperty2.DataBind();
                        ListItem listItem1 = new ListItem("---Select---", "-99");
                        this.drpProperty2.Items.Insert(0, listItem1);
                        this.drpProperty2.Visible = true;
                        this.lblProperty2.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num11);
                        this.lblProperty2.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty1 = addItemBLL.getItemProperty(num12);
                    if (itemProperty1 == null)
                    {
                        this.drpProperty3.Visible = false;
                        this.lblProperty3.Visible = false;
                    }
                    else if (itemProperty1.Rows.Count <= 0)
                    {
                        this.drpProperty3.Visible = false;
                        this.lblProperty3.Visible = false;
                    }
                    else
                    {
                        this.drpProperty3.DataSource = itemProperty1;
                        this.drpProperty3.DataTextField = itemProperty1.Columns["property_name"].ToString();
                        this.drpProperty3.DataValueField = itemProperty1.Columns["property_id"].ToString();
                        this.drpProperty3.DataBind();
                        ListItem listItem2 = new ListItem("---Select---", "-99");
                        this.drpProperty3.Items.Insert(0, listItem2);
                        this.drpProperty3.Visible = true;
                        this.lblProperty3.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num12);
                        this.lblProperty3.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable1 = addItemBLL.getItemProperty(num13);
                    if (dataTable1 == null)
                    {
                        this.drpProperty4.Visible = false;
                        this.lblProperty4.Visible = false;
                    }
                    else if (dataTable1.Rows.Count <= 0)
                    {
                        this.drpProperty4.Visible = false;
                        this.lblProperty4.Visible = false;
                    }
                    else
                    {
                        this.drpProperty4.DataSource = dataTable1;
                        this.drpProperty4.DataTextField = dataTable1.Columns["property_name"].ToString();
                        this.drpProperty4.DataValueField = dataTable1.Columns["property_id"].ToString();
                        this.drpProperty4.DataBind();
                        ListItem listItem3 = new ListItem("---Select---", "-99");
                        this.drpProperty4.Items.Insert(0, listItem3);
                        this.drpProperty4.Visible = true;
                        this.lblProperty4.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num13);
                        this.lblProperty4.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty2 = addItemBLL.getItemProperty(num14);
                    if (itemProperty2 == null)
                    {
                        this.drpProperty5.Visible = false;
                        this.lblProperty5.Visible = false;
                    }
                    else if (itemProperty2.Rows.Count <= 0)
                    {
                        this.drpProperty5.Visible = false;
                        this.lblProperty5.Visible = false;
                    }
                    else
                    {
                        this.drpProperty5.DataSource = itemProperty2;
                        this.drpProperty5.DataTextField = itemProperty2.Columns["property_name"].ToString();
                        this.drpProperty5.DataValueField = itemProperty2.Columns["property_id"].ToString();
                        this.drpProperty5.DataBind();
                        ListItem listItem4 = new ListItem("---Select---", "-99");
                        this.drpProperty5.Items.Insert(0, listItem4);
                        this.drpProperty5.Visible = true;
                        this.lblProperty5.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num14);
                        this.lblProperty5.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    if (this.hdDeemedExport.Value != "1")
                    {
                        this.chkDeemedExport.Checked = false;
                    }
                    else
                    {
                        this.chkDeemedExport.Checked = true;
                        this.chkDeemedExport.Enabled = true;
                        this.chkDeemedExport.Attributes["style"] = "color:red;";
                    }
                    if (this.hdZerorate.Value != "1")
                    {
                        this.chkZeroRate.Checked = false;
                    }
                    else
                    {
                        this.chkZeroRate.Checked = true;
                        this.chkZeroRate.Enabled = true;
                        this.chkZeroRate.Attributes["style"] = "color:red;";
                    }
                    if (this.hdrebatable.Value != "1")
                    {
                        this.chkRebateCurrent.Checked = false;
                        this.chkRebatable.Checked = false;
                    }
                    else
                    {
                        this.chkRebateCurrent.Checked = true;
                        this.chkRebatable.Checked = true;
                        this.chkRebatable.Enabled = true;
                        this.chkRebatable.Attributes["style"] = "color:red;";
                    }
                    if (this.hdIsExempted.Value != "1")
                    {
                        this.chkExempted.Checked = false;
                    }
                    else
                    {
                        this.chkExempted.Checked = true;
                        this.chkExempted.Enabled = true;
                        this.chkExempted.Attributes["style"] = "color:red;";
                    }
                    if (itemRequiredProperty.Rows[0]["sub_category_id"] == null)
                    {
                        this.drpCategory.SelectedValue = "-99";
                        this.drpSubCategory.SelectedValue = "-99";
                    }
                    else if (itemRequiredProperty.Rows[0]["category_id"].ToString() == "")
                    {
                        this.drpCategory.SelectedValue = itemRequiredProperty.Rows[0]["sub_category_id"].ToString();
                        this.drpSubCategory.Items.Clear();
                        ListItem listItem5 = new ListItem("-- Select --", "-99");
                        this.drpSubCategory.Items.Insert(0, listItem5);
                        this.drpSubCategory.Enabled = false;
                    }
                    else if (Convert.ToInt16(itemRequiredProperty.Rows[0]["category_id"]) > 0)
                    {
                        this.drpCategory.SelectedValue = itemRequiredProperty.Rows[0]["category_id"].ToString();
                        this.LoadSubCategory();
                        this.drpSubCategory.SelectedValue = itemRequiredProperty.Rows[0]["sub_category_id"].ToString();
                    }
                }
                this.txtPurchaseUnitPrice.Text = "";
                this.lblPurchaseUnitPrice.Text = "0.00";
                this.chkZeroRate.Checked = false;
                int num15 = 0;
                num15 = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable itemIsZeroRate = addItemBLL.getItemIsZeroRate(num15);
                if (itemIsZeroRate.Rows.Count > 0 && Convert.ToBoolean(itemIsZeroRate.Rows[0]["is_zero_rate"]))
                {
                    this.chkZeroRate.Checked = true;
                    this.chkZeroRate.Attributes["style"] = "color:Green;";
                }
            }
        }

        private void EnableOrDisablePropertyForItemforExcel()
        {
            if (!string.IsNullOrEmpty(this.drpItem.SelectedValue) || this.itemId.Text != "")
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = 0;
                if (this.itemId.Text != "")
                {
                    num = Convert.ToInt32(this.itemId.Text);
                    DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(num);
                    this.hfProperty1.Value = itemRequiredProperty.Rows[0]["property_id1"].ToString();
                    this.hfProperty2.Value = itemRequiredProperty.Rows[0]["property_id2"].ToString();
                    this.hfProperty3.Value = itemRequiredProperty.Rows[0]["property_id3"].ToString();
                    this.hfProperty4.Value = itemRequiredProperty.Rows[0]["property_id4"].ToString();
                    this.hfProperty5.Value = itemRequiredProperty.Rows[0]["property_id5"].ToString();
                    short num1 = 0;
                    short num2 = 0;
                    short num3 = 0;
                    short num4 = 0;
                    short num5 = 0;
                    DataTable appCodeDetailName = null;
                    num1 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id1"]);
                    num2 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id2"]);
                    num3 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id3"]);
                    num4 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id4"]);
                    num5 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id5"]);
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num1);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop1.Visible = true;
                        this.prop1.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num2);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop2.Visible = true;
                        this.prop2.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num3);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop3.Visible = true;
                        this.prop3.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num4);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop4.Visible = true;
                        this.prop4.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num5);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        this.prop5.Visible = true;
                        this.prop5.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                }
            }
        }

        private void EnableOrDisablePropertyForItemGridEdit()
        {
            if (!string.IsNullOrEmpty(this.drpItem.SelectedValue))
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = 0;
                if (this.drpItem.SelectedValue == "-99")
                {
                    this.chkRebatable.Checked = false;
                }
                else
                {
                    num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(num);
                    this.hdUnitID.Value = itemRequiredProperty.Rows[0]["unit_id"].ToString();
                    this.hdItemType.Value = itemRequiredProperty.Rows[0]["item_type"].ToString();
                    HiddenField str = this.hdProp1;
                    int num1 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop1_required"]);
                    str.Value = num1.ToString();
                    HiddenField hiddenField = this.hdProp2;
                    int num2 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop2_required"]);
                    hiddenField.Value = num2.ToString();
                    HiddenField str1 = this.hdProp3;
                    int num3 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop3_required"]);
                    str1.Value = num3.ToString();
                    HiddenField hiddenField1 = this.hdProp4;
                    int num4 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop4_required"]);
                    hiddenField1.Value = num4.ToString();
                    HiddenField str2 = this.hdProp5;
                    int num5 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop5_required"]);
                    str2.Value = num5.ToString();
                    this.GetUnitName(Convert.ToInt32(this.hdUnitID.Value));
                    Convert.ToBoolean(itemRequiredProperty.Rows[0]["is_vds"]);
                    if (Convert.ToBoolean(this.orgVDS.Text) && Convert.ToBoolean(this.partyVDS.Text))
                    {
                        if (!Convert.ToBoolean(itemRequiredProperty.Rows[0]["is_vds"]))
                        {
                            this.chkTaxDeducted.Checked = false;
                            this.lblvdstx.Visible = false;
                            this.txtvdsamount.Visible = false;
                        }
                        else
                        {
                            this.chkTaxDeducted.Checked = true;
                            this.lblvdstx.Visible = true;
                            this.chkTaxDeducted.Attributes["style"] = "color:red;";
                            this.txtvdsamount.Visible = true;
                        }
                    }
                    else if (Convert.ToBoolean(this.orgVDS.Text) && !Convert.ToBoolean(this.partyVDS.Text))
                    {
                        if (!Convert.ToBoolean(itemRequiredProperty.Rows[0]["is_vds"]))
                        {
                            this.lblvdstx.Visible = true;
                            this.txtvdsamount.Visible = true;
                        }
                        else
                        {
                            this.chkTaxDeducted.Checked = true;
                            this.lblvdstx.Visible = true;
                            this.chkTaxDeducted.Attributes["style"] = "color:green;";
                            this.txtvdsamount.Visible = true;
                        }
                    }
                    string str3 = itemRequiredProperty.Rows[0]["is_deemedexport"].ToString();
                    HiddenField hiddenField2 = this.hdIsExempted;
                    short num6 = Convert.ToInt16(itemRequiredProperty.Rows[0]["is_exempted"]);
                    hiddenField2.Value = num6.ToString();
                    if (str3 != "")
                    {
                        HiddenField hiddenField3 = this.hdDeemedExport;
                        short num7 = Convert.ToInt16(itemRequiredProperty.Rows[0]["is_deemedexport"]);
                        hiddenField3.Value = num7.ToString();
                    }
                    else
                    {
                        this.hdDeemedExport.Value = Convert.ToInt16("0").ToString();
                    }
                    if (itemRequiredProperty.Rows[0]["zero_rate"].ToString() != "")
                    {
                        HiddenField str4 = this.hdZerorate;
                        short num8 = Convert.ToInt16(itemRequiredProperty.Rows[0]["zero_rate"]);
                        str4.Value = num8.ToString();
                    }
                    else
                    {
                        this.hdZerorate.Value = Convert.ToInt16("0").ToString();
                    }
                    if (itemRequiredProperty.Rows[0]["is_rebatable"].ToString() != "")
                    {
                        HiddenField hiddenField4 = this.hdrebatable;
                        short num9 = Convert.ToInt16(itemRequiredProperty.Rows[0]["is_rebatable"]);
                        hiddenField4.Value = num9.ToString();
                    }
                    else
                    {
                        this.hdrebatable.Value = Convert.ToInt16("0").ToString();
                    }
                    short num10 = 0;
                    short num11 = 0;
                    short num12 = 0;
                    short num13 = 0;
                    short num14 = 0;
                    DataTable appCodeDetailName = null;
                    num10 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id1"]);
                    num11 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id2"]);
                    num12 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id3"]);
                    num13 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id4"]);
                    num14 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id5"]);
                    DataTable itemProperty = addItemBLL.getItemProperty(num10);
                    if (itemProperty == null)
                    {
                        this.drpProperty1.Visible = false;
                        this.lblProperty1.Visible = false;
                    }
                    else if (itemProperty.Rows.Count <= 0)
                    {
                        this.drpProperty1.Visible = false;
                        this.lblProperty1.Visible = false;
                    }
                    else
                    {
                        this.drpProperty1.DataSource = itemProperty;
                        this.drpProperty1.DataTextField = itemProperty.Columns["property_name"].ToString();
                        this.drpProperty1.DataValueField = itemProperty.Columns["property_id"].ToString();
                        this.drpProperty1.DataBind();
                        this.drpProperty1.SelectedValue = this.gvItem.Rows[0].Cells[4].Text.Trim();
                        this.drpProperty1.Visible = true;
                        this.lblProperty1.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num10);
                        this.lblProperty1.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable = addItemBLL.getItemProperty(num11);
                    if (dataTable == null)
                    {
                        this.drpProperty2.Visible = false;
                        this.lblProperty2.Visible = false;
                    }
                    else if (dataTable.Rows.Count <= 0)
                    {
                        this.drpProperty2.Visible = false;
                        this.lblProperty2.Visible = false;
                    }
                    else
                    {
                        this.drpProperty2.DataSource = dataTable;
                        this.drpProperty2.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProperty2.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProperty2.DataBind();
                        this.drpProperty2.SelectedValue = this.gvItem.Rows[0].Cells[5].Text.Trim();
                        this.drpProperty2.Visible = true;
                        this.lblProperty2.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num11);
                        this.lblProperty2.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty1 = addItemBLL.getItemProperty(num12);
                    if (itemProperty1 == null)
                    {
                        this.drpProperty3.Visible = false;
                        this.lblProperty3.Visible = false;
                    }
                    else if (itemProperty1.Rows.Count <= 0)
                    {
                        this.drpProperty3.Visible = false;
                        this.lblProperty3.Visible = false;
                    }
                    else
                    {
                        this.drpProperty3.DataSource = itemProperty1;
                        this.drpProperty3.DataTextField = itemProperty1.Columns["property_name"].ToString();
                        this.drpProperty3.DataValueField = itemProperty1.Columns["property_id"].ToString();
                        this.drpProperty3.DataBind();
                        this.drpProperty3.SelectedValue = this.gvItem.Rows[0].Cells[6].Text.Trim();
                        this.drpProperty3.Visible = true;
                        this.lblProperty3.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num12);
                        this.lblProperty3.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable1 = addItemBLL.getItemProperty(num13);
                    if (dataTable1 == null)
                    {
                        this.drpProperty4.Visible = false;
                        this.lblProperty4.Visible = false;
                    }
                    else if (dataTable1.Rows.Count <= 0)
                    {
                        this.drpProperty4.Visible = false;
                        this.lblProperty4.Visible = false;
                    }
                    else
                    {
                        this.drpProperty4.DataSource = dataTable1;
                        this.drpProperty4.DataTextField = dataTable1.Columns["property_name"].ToString();
                        this.drpProperty4.DataValueField = dataTable1.Columns["property_id"].ToString();
                        this.drpProperty4.DataBind();
                        this.drpProperty4.SelectedValue = this.gvItem.Rows[0].Cells[7].Text.Trim();
                        this.drpProperty4.Visible = true;
                        this.lblProperty4.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num13);
                        this.lblProperty4.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty2 = addItemBLL.getItemProperty(num14);
                    if (itemProperty2 == null)
                    {
                        this.drpProperty5.Visible = false;
                        this.lblProperty5.Visible = false;
                    }
                    else if (itemProperty2.Rows.Count <= 0)
                    {
                        this.drpProperty5.Visible = false;
                        this.lblProperty5.Visible = false;
                    }
                    else
                    {
                        this.drpProperty5.DataSource = itemProperty2;
                        this.drpProperty5.DataTextField = itemProperty2.Columns["property_name"].ToString();
                        this.drpProperty5.DataValueField = itemProperty2.Columns["property_id"].ToString();
                        this.drpProperty5.DataBind();
                        this.drpProperty5.SelectedValue = this.gvItem.Rows[0].Cells[8].Text.Trim();
                        this.drpProperty5.Visible = true;
                        this.lblProperty5.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num14);
                        this.lblProperty5.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    if (this.hdDeemedExport.Value != "1")
                    {
                        this.chkDeemedExport.Checked = false;
                    }
                    else
                    {
                        this.chkDeemedExport.Checked = true;
                        this.chkDeemedExport.Enabled = true;
                        this.chkDeemedExport.Attributes["style"] = "color:red;";
                    }
                    if (this.hdZerorate.Value != "1")
                    {
                        this.chkZeroRate.Checked = false;
                    }
                    else
                    {
                        this.chkZeroRate.Checked = true;
                        this.chkZeroRate.Enabled = true;
                        this.chkZeroRate.Attributes["style"] = "color:red;";
                    }
                    if (this.hdrebatable.Value != "1")
                    {
                        this.chkRebateCurrent.Checked = false;
                        this.chkRebatable.Checked = false;
                    }
                    else
                    {
                        this.chkRebateCurrent.Checked = true;
                        this.chkRebatable.Checked = true;
                        this.chkRebatable.Enabled = true;
                        this.chkRebatable.Attributes["style"] = "color:red;";
                    }
                    if (this.hdIsExempted.Value != "1")
                    {
                        this.chkExempted.Checked = false;
                    }
                    else
                    {
                        this.chkExempted.Checked = true;
                        this.chkExempted.Enabled = true;
                        this.chkExempted.Attributes["style"] = "color:red;";
                    }
                    if (itemRequiredProperty.Rows[0]["sub_category_id"] == null)
                    {
                        this.drpCategory.SelectedValue = "-99";
                        this.drpSubCategory.SelectedValue = "-99";
                    }
                    else if (itemRequiredProperty.Rows[0]["category_id"].ToString() == "")
                    {
                        this.drpCategory.SelectedValue = itemRequiredProperty.Rows[0]["sub_category_id"].ToString();
                        this.drpSubCategory.Items.Clear();
                        ListItem listItem = new ListItem("-- Select --", "-99");
                        this.drpSubCategory.Items.Insert(0, listItem);
                        this.drpSubCategory.Enabled = false;
                    }
                    else if (Convert.ToInt16(itemRequiredProperty.Rows[0]["category_id"]) > 0)
                    {
                        this.drpCategory.SelectedValue = itemRequiredProperty.Rows[0]["category_id"].ToString();
                        this.LoadSubCategory();
                        this.drpSubCategory.SelectedValue = itemRequiredProperty.Rows[0]["sub_category_id"].ToString();
                    }
                }
                this.txtPurchaseUnitPrice.Text = "";
                this.lblPurchaseUnitPrice.Text = "0.00";
                this.chkZeroRate.Checked = false;
                int num15 = 0;
                num15 = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable itemIsZeroRate = addItemBLL.getItemIsZeroRate(num15);
                if (itemIsZeroRate.Rows.Count > 0 && Convert.ToBoolean(itemIsZeroRate.Rows[0]["is_zero_rate"]))
                {
                    this.chkZeroRate.Checked = true;
                    this.chkZeroRate.Attributes["style"] = "color:Green;";
                }
            }
        }

        protected void FileUpload1_DataBinding(object sender, EventArgs e)
        {
            string fileName = this.FileUpload1.FileName;
        }

        private void fillDetailProperties()
        {
            ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            try
            {
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO()
                {
                    PurchaseType = 'L'
                };
                if (this.drpCategory.SelectedValue != "-99" && this.drpCategory.SelectedValue != "")
                {
                    purchaseDetailDAO.CatID = Convert.ToInt32(this.drpCategory.SelectedValue);
                    purchaseDetailDAO.CategoryName = this.drpCategory.SelectedItem.ToString();
                }
                if (this.drpSubCategory.SelectedValue != "-99" && this.drpSubCategory.SelectedValue != "")
                {
                    purchaseDetailDAO.SubCatID = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                    purchaseDetailDAO.SubCategoryName = this.drpSubCategory.SelectedItem.ToString();
                }
                if (this.drpItem.SelectedValue != "-99" && this.drpItem.SelectedValue != "")
                {
                    purchaseDetailDAO.ItemID = Convert.ToInt32(this.drpItem.SelectedValue);
                    purchaseDetailDAO.ItemName = this.drpItem.SelectedItem.ToString();
                }
                if (this.drpProperty1.SelectedValue != "-99" && this.drpProperty1.SelectedValue != "")
                {
                    purchaseDetailDAO.IntProperty1 = Convert.ToInt32(this.drpProperty1.SelectedValue);
                    purchaseDetailDAO.Property1 = this.drpProperty1.SelectedItem.ToString();
                }
                if (this.drpProperty2.SelectedValue != "-99" && this.drpProperty2.SelectedValue != "")
                {
                    purchaseDetailDAO.IntProperty2 = Convert.ToInt32(this.drpProperty2.SelectedValue);
                    purchaseDetailDAO.Property2 = this.drpProperty2.SelectedItem.ToString();
                }
                if (this.drpProperty3.SelectedValue != "-99" && this.drpProperty3.SelectedValue != "")
                {
                    purchaseDetailDAO.IntProperty3 = Convert.ToInt32(this.drpProperty3.SelectedValue);
                    purchaseDetailDAO.Property3 = this.drpProperty3.SelectedItem.ToString();
                }
                if (this.drpProperty4.SelectedValue != "-99" && this.drpProperty4.SelectedValue != "")
                {
                    purchaseDetailDAO.IntProperty4 = Convert.ToInt32(this.drpProperty4.SelectedValue);
                    purchaseDetailDAO.Property4 = this.drpProperty4.SelectedItem.ToString();
                }
                if (this.drpProperty5.SelectedValue != "-99" && this.drpProperty5.SelectedValue != "")
                {
                    purchaseDetailDAO.IntProperty5 = Convert.ToInt32(this.drpProperty5.SelectedValue);
                    purchaseDetailDAO.Property5 = this.drpProperty5.SelectedItem.ToString();
                }
                if (!(this.drpProperty1.SelectedValue != "-99") || !(this.drpProperty1.SelectedValue != ""))
                {
                    purchaseDetailDAO.PropertyID1 = 0;
                }
                else
                {
                    purchaseDetailDAO.PropertyID1 = Convert.ToInt32(this.drpProperty1.SelectedValue);
                }
                if (!(this.drpProperty2.SelectedValue != "-99") || !(this.drpProperty2.SelectedValue != ""))
                {
                    purchaseDetailDAO.PropertyID2 = 0;
                }
                else
                {
                    purchaseDetailDAO.PropertyID2 = Convert.ToInt32(this.drpProperty2.SelectedValue);
                }
                if (!(this.drpProperty3.SelectedValue != "-99") || !(this.drpProperty3.SelectedValue != ""))
                {
                    purchaseDetailDAO.PropertyID3 = 0;
                }
                else
                {
                    purchaseDetailDAO.PropertyID3 = Convert.ToInt32(this.drpProperty3.SelectedValue);
                }
                if (!(this.drpProperty4.SelectedValue != "-99") || !(this.drpProperty4.SelectedValue != ""))
                {
                    purchaseDetailDAO.PropertyID4 = 0;
                }
                else
                {
                    purchaseDetailDAO.PropertyID4 = Convert.ToInt32(this.drpProperty4.SelectedValue);
                }
                if (!(this.drpProperty5.SelectedValue != "-99") || !(this.drpProperty5.SelectedValue != ""))
                {
                    purchaseDetailDAO.PropertyID5 = 0;
                }
                else
                {
                    purchaseDetailDAO.PropertyID5 = Convert.ToInt32(this.drpProperty5.SelectedValue);
                }
                if (!(this.lblCValue.Text != string.Empty) || !(this.lblCValue.Text != "0.00"))
                {
                    purchaseDetailDAO.Quantity = Convert.ToDouble(this.txtQuantity.Text);
                    purchaseDetailDAO.TempQuantity = Convert.ToDouble(this.txtQuantity.Text.Trim());
                    purchaseDetailDAO.UnitID = Convert.ToInt32(this.hdUnitID.Value);
                    purchaseDetailDAO.UnitName = this.drpUnit.SelectedItem.ToString();
                    purchaseDetailDAO.PurchaseUnitPrice = Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    purchaseDetailDAO.UnitPriceBDT = Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    purchaseDetailDAO.TempUnitPrice = Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    purchaseDetailDAO.TempUnitCode = this.drpUnit.SelectedItem.ToString();
                }
                else
                {
                    purchaseDetailDAO.Quantity = Convert.ToDouble(this.txtQuantity.Text.Trim()) * Convert.ToDouble(this.lblCValue.Text.Trim());
                    purchaseDetailDAO.TempQuantity = Convert.ToDouble(this.txtQuantity.Text.Trim());
                    purchaseDetailDAO.UnitID = Convert.ToInt32(this.lblUID.Text);
                    purchaseDetailDAO.PurchaseUnitPrice = Convert.ToDouble(this.txtPurchaseUnitPrice.Text) / Convert.ToDouble(this.lblCValue.Text.Trim());
                    purchaseDetailDAO.UnitPriceBDT = Convert.ToDouble(this.txtPurchaseUnitPrice.Text) / Convert.ToDouble(this.lblCValue.Text.Trim());
                    purchaseDetailDAO.TempUnitPrice = Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    purchaseDetailDAO.UnitName = this.lblUnitCode.Text;
                    purchaseDetailDAO.TempUnitCode = this.drpUnit.SelectedItem.ToString();
                }
                purchaseDetailDAO.PurchaseVAT = (this.txtPurchaseVAT.Text != "" ? Convert.ToDouble(this.txtPurchaseVAT.Text) : 0);
                purchaseDetailDAO.PurchaseSD = (this.txtPurchaseSD.Text != "" ? Convert.ToDouble(this.txtPurchaseSD.Text) : 0);
                purchaseDetailDAO.AIT_Amount = (this.txtPurchaseAIT.Text != "" ? Convert.ToDouble(this.txtPurchaseAIT.Text) : 0);
                if (this.txtSaleUnitPrice.Text.Trim() == "")
                {
                    purchaseDetailDAO.SaleUnitPrice = 0;
                    purchaseDetailDAO.UnitSalePriceBDT = 0;
                }
                else if (!(this.lblCValue.Text != string.Empty) || !(this.lblCValue.Text != "0.00"))
                {
                    purchaseDetailDAO.SaleUnitPrice = Convert.ToDouble(this.txtSaleUnitPrice.Text.Trim());
                    purchaseDetailDAO.UnitSalePriceBDT = Convert.ToDouble(this.txtSaleUnitPrice.Text);
                }
                else
                {
                    purchaseDetailDAO.SaleUnitPrice = Convert.ToDouble(this.txtSaleUnitPrice.Text.Trim()) / Convert.ToDouble(this.lblCValue.Text.Trim());
                    purchaseDetailDAO.UnitSalePriceBDT = Convert.ToDouble(this.txtSaleUnitPrice.Text) / Convert.ToDouble(this.lblCValue.Text.Trim());
                }
                if (this.txtSaleVat.Text.Trim() != "")
                {
                    purchaseDetailDAO.SaleVAT = Convert.ToDouble(this.txtSaleVat.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.SaleVAT = 0;
                }
                if (this.txtSaleSD.Text.Trim() != "")
                {
                    purchaseDetailDAO.SaleSD = Convert.ToDouble(this.txtSaleSD.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.SaleSD = 0;
                }
                if (this.txtSaleVatablePrice.Text.Trim() != "")
                {
                    purchaseDetailDAO.SaleVatablePrice = Convert.ToDouble(this.txtSaleVatablePrice.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.SaleVatablePrice = 0;
                }
                if (this.txtvdsamount.Text.Trim() != "")
                {
                    purchaseDetailDAO.VDSAmount = Convert.ToDouble(this.txtvdsamount.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.VDSAmount = 0;
                }
                if (this.lblProductType.Text != "W")
                {
                    purchaseDetailDAO.RealProperty = '0';
                }
                else
                {
                    purchaseDetailDAO.RealProperty = Convert.ToChar(this.lblProductType.Text);
                }
                purchaseDetailDAO.VAT = Convert.ToDouble(this.lblTotalVAT.Text);
                purchaseDetailDAO.IsSrcTAXDeduct = this.chkTaxDeducted.Checked;
                purchaseDetailDAO.IsCurrentMonthRebate = this.chkRebateCurrent.Checked;
                purchaseDetailDAO.UserIdInsert = Convert.ToInt16(this.Session["employee_id"]);
                purchaseDetailDAO.TotalPrice = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text);
                purchaseDetailDAO.TotalPurchasePrice = Convert.ToDouble(this.lblTotalPurchasePrc.Text);
                if (this.hdPriceID.Value != "")
                {
                    purchaseDetailDAO.PriceId = Convert.ToInt16(this.hdPriceID.Value);
                }
                purchaseDetailDAO.SDRate = Convert.ToDouble(this.lblPurchaseSD.Text);
                purchaseDetailDAO.VATRate = Convert.ToDouble(this.lblPurchaseVAT.Text);
                purchaseDetailDAO.ItemType = this.hdItemType.Value;
                purchaseDetailDAO.RemarksDetail =  BLL.Utility.ReplaceQuotes(this.remarks2.Text);
                purchaseDetailDAO.IsRebatable = this.chkRebatable.Checked;
                purchaseDetailDAO.IsExempted = Convert.ToBoolean(Convert.ToInt16(this.hdIsExempted.Value));
                purchaseDetailDAO.IsDeemedExport = Convert.ToBoolean(Convert.ToInt16(this.hdDeemedExport.Value));
                purchaseDetailDAO.HSCode = this.lblHSCode.Text;
                if (!this.chkTaxDeducted.Checked)
                {
                    purchaseDetailDAO.SrcTAXDeduct = "No";
                }
                else
                {
                    purchaseDetailDAO.SrcTAXDeduct = "Yes";
                }
                if (!Convert.ToBoolean(Convert.ToInt16(this.hdIsExempted.Value)))
                {
                    purchaseDetailDAO.Exempted = "No";
                }
                else
                {
                    purchaseDetailDAO.Exempted = "Yes";
                }
                if (!Convert.ToBoolean(Convert.ToInt16(this.hdDeemedExport.Value)))
                {
                    purchaseDetailDAO.DeemedExport = "No";
                }
                else
                {
                    purchaseDetailDAO.DeemedExport = "Yes";
                }
                if (!this.chkRebatable.Checked)
                {
                    purchaseDetailDAO.Rebatable = "No";
                }
                else
                {
                    purchaseDetailDAO.Rebatable = "Yes";
                }

                DateTime currentDate = DateTime.Now;
                DateTime comDate = Convert.ToDateTime(txtrefChallanDate.Text);

                var month = currentDate - comDate;
                if (month.Days > 150)
                {
                    purchaseDetailDAO.PurchaseVAT = 0;
                    purchaseDetailDAO.Rebatable = "No";
                    purchaseDetailDAO.IsRebatable = false;
                    chkRebatable.Checked = false;
                }
                if (!this.chkIsFixed.Checked)
                {
                    purchaseDetailDAO.IsFixed = false;
                    purchaseDetailDAO.Fixed = "No";
                }
                else
                {
                    purchaseDetailDAO.IsFixed = true;
                    purchaseDetailDAO.Fixed = "Yes";
                }
                if (this.HiddenIsTruncated.Value != "is_truncated")
                {
                    purchaseDetailDAO.Truncated = "No";
                    purchaseDetailDAO.IsTruncated = false;
                }
                else
                {
                    purchaseDetailDAO.IsTruncated = true;
                    purchaseDetailDAO.Truncated = "Yes";
                }
                if (!this.chkZeroRate.Checked)
                {
                    purchaseDetailDAO.ZeroRate = "No";
                    purchaseDetailDAO.IsZeroRate = false;
                }
                else
                {
                    purchaseDetailDAO.IsZeroRate = true;
                    purchaseDetailDAO.ZeroRate = "Yes";
                }
                if (!this.chkMrp.Checked)
                {
                    purchaseDetailDAO.Mrp = "No";
                    purchaseDetailDAO.IsMrp = false;
                }
                else
                {
                    purchaseDetailDAO.IsMrp = true;
                    purchaseDetailDAO.Mrp = "Yes";
                }
                if ((new ChallanBLL()).GetApproverStage().Rows.Count < 1)
                {
                    purchaseDetailDAO.ApproveStage = "F";
                    this.ClientButton.Enabled = true;
                }
                else
                {
                    string approveStage = this.getApproveStage();
                    if (approveStage != "")
                    {
                        purchaseDetailDAO.ApproveStage = approveStage;
                    }
                    else
                    {
                        purchaseDetailDAO.ApproveStage = "1";
                    }
                    if (approveStage != "F")
                    {
                        this.ClientButton.Enabled = false;
                    }
                    else
                    {
                        this.ClientButton.Enabled = true;
                    }
                }
                if (this.btnAdd.Text.Trim() != LocalPurchase.enmBtnText.Update.ToString())
                {
                    purchaseDetailDAO.RowNo = num;
                    item.Add(purchaseDetailDAO);
                }
                else
                {
                    purchaseDetailDAO.RowNo = Convert.ToInt16(this.ViewState["selctedRowNo"]);
                    if (purchaseDetailDAO.RowNo > 0)
                    {
                        int rowNo = purchaseDetailDAO.RowNo - 1;
                        if (this.gvItem.Rows.Count > 0)
                        {
                            item.RemoveAt(rowNo);
                        }
                        item.Insert(rowNo, purchaseDetailDAO);
                        this.setDetaiAddMode();
                        this.ViewState["selctedRowNo"] = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                item = null;
            }
            this.Session["PURCHASE_DETAIL_LIST"] = item;
        }

        public DataTable formatDataTableForEconomicActivity(DataTable partiesInDt)
        {
            OrgRegistrationInfoDAO orgRegistrationInfoDAO = new OrgRegistrationInfoDAO();
            DataTable economicPrcActivity = orgRegistrationInfoDAO.GetEconomicPrcActivity();
            DataTable allParties = orgRegistrationInfoDAO.GetAllParties();
            List<string> strs = new List<string>();
            if (partiesInDt != null && partiesInDt.Rows.Count > 0)
            {
                foreach (DataRow row in partiesInDt.Rows)
                {
                    strs.Add(row["party_id"].ToString());
                }
            }
            foreach (DataRow dataRow in allParties.Rows)
            {
                if (strs.Contains(dataRow["party_id"].ToString()))
                {
                    continue;
                }
                string[] activityShortName = this.getActivityShortName(economicPrcActivity, dataRow["major_area_of_ecn_activity"].ToString());
                string lower = this.drpRegType.SelectedItem.Text.ToLower();
                string str = lower;
                if (lower == null)
                {
                    continue;
                }
                if (str == "procurement provider")
                {
                    if (!activityShortName.Contains<string>("procurement_provider"))
                    {
                        continue;
                    }
                    partiesInDt.Rows.Add(dataRow.ItemArray);
                }
                else if (str == "trader")
                {
                    if (!activityShortName.Contains<string>("trader"))
                    {
                        continue;
                    }
                    partiesInDt.Rows.Add(dataRow.ItemArray);
                }
            }
            partiesInDt.DefaultView.Sort = "party_name";
            partiesInDt = partiesInDt.DefaultView.ToTable();
            return partiesInDt;
        }

        public string[] getActivityShortName(DataTable dt, string activities)
        {
            List<string> strs = new List<string>();
            string[] strArrays = activities.Split(new char[] { ',' });
            foreach (DataRow row in dt.Rows)
            {
                string str = row["code_id_d"].ToString();
                string[] strArrays1 = strArrays;
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    if (strArrays1[i].Equals(str))
                    {
                        strs.Add(row["code_short_name"].ToString().ToLower());
                    }
                }
            }
            return strs.ToArray();
        }

        private string getApproveStage()
        {
            string str = "";
            if (this.gvApprvItem.Rows.Count > 0 && this.gvApprvItem.SelectedValue != null)
            {
                int num = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ChallanID"]);
                ChallanBLL challanBLL = new ChallanBLL();
                DataTable approverStage = challanBLL.GetApproverStage();
                if (approverStage.Rows.Count > 0)
                {
                    DataTable purchaseApproveStage = challanBLL.getPurchaseApproveStage(num);
                    if (purchaseApproveStage.Rows.Count > 0)
                    {
                        int count = approverStage.Rows.Count;
                        int num1 = Convert.ToInt32(purchaseApproveStage.Rows[0]["approver_stage"]);
                        int num2 = count - num1;
                        if (num2 != 1)
                        {
                            str = num2.ToString();
                        }
                        else
                        {
                            str = "F";
                            this.ClientButton.Enabled = true;
                        }
                    }
                }
            }
            return str;
        }

        private string getApproveStagebyChallanId(int ChallanID)
        {
            string str = "";
            ChallanBLL challanBLL = new ChallanBLL();
            DataTable approverStage = challanBLL.GetApproverStage();
            if (approverStage.Rows.Count > 0)
            {
                DataTable purchaseApproveStage = challanBLL.getPurchaseApproveStage(ChallanID);
                if (purchaseApproveStage.Rows.Count > 0)
                {
                    int count = approverStage.Rows.Count;
                    int num = Convert.ToInt32(purchaseApproveStage.Rows[0]["approver_stage"]);
                    int num1 = count - num;
                    if (num1 != 1)
                    {
                        str = num1.ToString();
                    }
                    else
                    {
                        str = "F";
                        this.ClientButton.Enabled = true;
                    }
                }
            }
            return str;
        }

        private void GetBranchAddress()
        {
            if (this.Session["ORGBRANCHID"] != null)
            {
                OrgRegistrationInfoDAO orgRegistrationInfoDAO = new OrgRegistrationInfoDAO();
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                DataTable oRGorBranch = orgRegistrationInfoDAO.GetORGorBranch(num);
                if (oRGorBranch != null && oRGorBranch.Rows.Count > 0)
                {
                    oRGorBranch.Rows[0]["branch_unit_name"].ToString();
                    this.lblBranchAddress.Text = oRGorBranch.Rows[0]["org_branch_address"].ToString();
                    return;
                }
                this.lblBranchAddress.Text = string.Empty;
            }
        }

        private void GetBranchBIN()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                if (num == 1 || num == 2 || num == 3)
                {
                    if (num1 == 0)
                    {
                        return;
                    }
                    DataTable branchBIN = challanBLL.GetBranchBIN(num2);
                    if (branchBIN != null && branchBIN.Rows.Count > 0)
                    {
                        this.lblBranchBin.Text = branchBIN.Rows[0]["branch_unit_bin"].ToString();
                        return;
                    }
                    this.lblBranchBin.Text = string.Empty;
                }
            }
        }

        private void GetBranchInformation()
        {
            this.drpBranchName.Items.Clear();
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                Convert.ToInt32(this.Session["empId"].ToString());
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                if (num2 <= 0)
                {
                    num2 = 0;
                }
                if (num == 3)
                {
                    this.drpBranchName.Enabled = false;
                    if (num1 != 0)
                    {
                        DataTable selectedBusinessUnitBranchInfo = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                        if (selectedBusinessUnitBranchInfo != null && selectedBusinessUnitBranchInfo.Rows.Count > 0)
                        {
                            this.drpBranchName.DataSource = selectedBusinessUnitBranchInfo;
                            this.drpBranchName.DataTextField = selectedBusinessUnitBranchInfo.Columns["branch_unit_name"].ToString();
                            this.drpBranchName.DataValueField = selectedBusinessUnitBranchInfo.Columns["org_branch_reg_id"].ToString();
                            this.drpBranchName.DataBind();
                        }
                    }
                    else
                    {
                        ListItem listItem = new ListItem("Head Office", "0");
                        this.drpBranchName.Items.Insert(0, listItem);
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
                if (num == 2 || num == 1)
                {
                    this.drpBranchName.Enabled = true;
                    DataTable dataTable = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpBranchName.DataSource = dataTable;
                        this.drpBranchName.DataTextField = dataTable.Columns["branch_unit_name"].ToString();
                        this.drpBranchName.DataValueField = dataTable.Columns["org_branch_reg_id"].ToString();
                        this.drpBranchName.DataBind();
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
            }
        }

        private int GetColumnIndexByName(GridView grid, string name)
        {
            int num;
            IEnumerator enumerator = grid.Columns.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DataControlField current = (DataControlField)enumerator.Current;
                    if (current.HeaderText.ToLower().Trim() != name.ToLower().Trim())
                    {
                        continue;
                    }
                    num = grid.Columns.IndexOf(current);
                    return num;
                }
                return -1;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            return num;
        }

        private void GetGRNVoucher()
        {
            DataTable dataTable = new DataTable();
            DataTable voucherNo = new DataTable();
            try
            {
                dataTable = this.dbBLL.GetGRNNo();
                voucherNo = this.dbBLL.GetVoucherNo();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.ddlGRNNo.DataSource = dataTable;
                    this.ddlGRNNo.DataTextField = dataTable.Columns["grn_no"].ToString();
                    this.ddlGRNNo.DataValueField = dataTable.Columns["grn_no"].ToString();
                    this.ddlGRNNo.DataBind();
                }
                if (voucherNo != null && voucherNo.Rows.Count > 0)
                {
                    this.ddlVoucher.DataSource = voucherNo;
                    this.ddlVoucher.DataTextField = voucherNo.Columns["vouchar_no"].ToString();
                    this.ddlVoucher.DataValueField = voucherNo.Columns["vouchar_no"].ToString();
                    this.ddlVoucher.DataBind();
                }
                this.ddlGRNNo.Items.Insert(0, new ListItem("---Select GRN No---", "-1"));
                this.ddlVoucher.Items.Insert(0, new ListItem("---Select Voucher No---", "-1"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private PurchaseMasterDAO GetInserMasterValues(PurchaseMasterDAO objMDAO)
        {
            try
            {
                objMDAO.OrganizatioID = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
                objMDAO.Org_branch_reg_id = (!string.IsNullOrEmpty(this.drpBranchName.SelectedValue) ? Convert.ToInt32(this.drpBranchName.SelectedValue.ToString()) : 0);
                objMDAO.ChallanType = 'P';
                objMDAO.ChallanNo =  BLL.Utility.ReplaceQuotes(this.txtChallanNo.Text);
                objMDAO.PurchaseType = 'L';
                if (this.drpType.SelectedIndex == 0)
                {
                    objMDAO.Type = 'S';
                }
                else if (this.drpType.SelectedIndex == 1)
                {
                    objMDAO.Type = 'G';
                }
                objMDAO.AggrementNo = (!string.IsNullOrEmpty(this.txtAgreement.Text) ? this.txtAgreement.Text : "");
                if (!string.IsNullOrEmpty(this.txtrefChallanDate.Text.Trim()))
                {
                    string[] strArrays = new string[] { this.txtrefChallanDate.Text.Trim(), " ", this.drpRefChDtHr.SelectedItem.Text, ":", this.drpRefChDtMin.SelectedItem.Text };
                    objMDAO.RefChallanDate = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                   // objMDAO.RefChallanDate = objMDAO.RefChallanDate.new
                }
                if (!string.IsNullOrEmpty(this.txtChallanDate.Text.Trim()))
                {
                    string[] strArrays1 = new string[] { this.txtChallanDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                    objMDAO.ChallanDate = DateTime.ParseExact(string.Concat(strArrays1), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                objMDAO.ScrollNo =  BLL.Utility.ReplaceQuotes(this.txtScrollNo.Text);
                objMDAO.VehicleTypeM = 7;
                objMDAO.VehicleTypeD = Convert.ToInt16(this.drpVehicleType.SelectedValue);
                objMDAO.VehicleNo =  BLL.Utility.ReplaceQuotes(this.txtVehicleNo.Text);
                objMDAO.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                if (!this.drpParty.Enabled)
                {
                    objMDAO.IsNewParty = true;
                    objMDAO.PartAddress =  BLL.Utility.ReplaceQuotes(this.txtAddress.Text);
                    objMDAO.PartyTIN =  BLL.Utility.ReplaceQuotes(this.txtPartyBIN.Text);
                }
                else
                {
                    objMDAO.PartyID = Convert.ToInt16(this.drpParty.SelectedValue);
                    objMDAO.IsNewParty = false;
                }
                objMDAO.UltimateDestination =  BLL.Utility.ReplaceQuotes(this.txtDestination.Text);
                objMDAO.Remarks =  BLL.Utility.ReplaceQuotes(this.txtRemarks.Text);
                objMDAO.PaymentInfo = this.txt_transaction_id.Text;
                (new AddItemBLL()).getPaymentMethod();
                if (this.chkCash.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO = objMDAO;
                    purchaseMasterDAO.PaymentMethodP = string.Concat(purchaseMasterDAO.PaymentMethodP, "1,");
                }
                if (this.chkBkash.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO1 = objMDAO;
                    purchaseMasterDAO1.PaymentMethodP = string.Concat(purchaseMasterDAO1.PaymentMethodP, "8,");
                }
                if (this.chkRocket.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO2 = objMDAO;
                    purchaseMasterDAO2.PaymentMethodP = string.Concat(purchaseMasterDAO2.PaymentMethodP, "12,");
                }
                if (this.chkCheque.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO3 = objMDAO;
                    purchaseMasterDAO3.PaymentMethodP = string.Concat(purchaseMasterDAO3.PaymentMethodP, "2,");
                }
                if (this.chkTT.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO4 = objMDAO;
                    purchaseMasterDAO4.PaymentMethodP = string.Concat(purchaseMasterDAO4.PaymentMethodP, "14,");
                }
                if (this.chkEFT.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO5 = objMDAO;
                    purchaseMasterDAO5.PaymentMethodP = string.Concat(purchaseMasterDAO5.PaymentMethodP, "11,");
                }
                if (this.CheDebitCard.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO6 = objMDAO;
                    purchaseMasterDAO6.PaymentMethodP = string.Concat(purchaseMasterDAO6.PaymentMethodP, "7,");
                }
                if (this.chkPayOrder.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO7 = objMDAO;
                    purchaseMasterDAO7.PaymentMethodP = string.Concat(purchaseMasterDAO7.PaymentMethodP, "5,");
                }
                if (this.chkCredit.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO8 = objMDAO;
                    purchaseMasterDAO8.PaymentMethodP = string.Concat(purchaseMasterDAO8.PaymentMethodP, "3,");
                }
                if (this.chkCash.Checked && this.txtCashAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO cashAmount = objMDAO;
                    cashAmount.CashAmount = cashAmount.CashAmount + Convert.ToDouble(this.txtCashAmount.Text.Trim());
                }
                if (this.chkBkash.Checked && this.txtbKashAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO cashAmount1 = objMDAO;
                    cashAmount1.CashAmount = cashAmount1.CashAmount + Convert.ToDouble(this.txtbKashAmount.Text.Trim());
                }
                if (this.chkRocket.Checked && this.txtRocketAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO cashAmount2 = objMDAO;
                    cashAmount2.CashAmount = cashAmount2.CashAmount + Convert.ToDouble(this.txtRocketAmount.Text.Trim());
                }
                if (this.chkCheque.Checked && this.txtChequeAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO bankAmount = objMDAO;
                    bankAmount.BankAmount = bankAmount.BankAmount + Convert.ToDouble(this.txtChequeAmount.Text.Trim());
                }
                if (this.chkTT.Checked && this.txtTPTAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO bankAmount1 = objMDAO;
                    bankAmount1.BankAmount = bankAmount1.BankAmount + Convert.ToDouble(this.txtTPTAmount.Text.Trim());
                }

                if (this.ChkOther.Checked && this.txtOthersAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO bankAmount1 = objMDAO;
                    bankAmount1.BankAmount = bankAmount1.BankAmount + Convert.ToDouble(this.txtOthersAmount.Text.Trim());
                }



                if (this.chkEFT.Checked && this.txtEFTAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO bankAmount2 = objMDAO;
                    bankAmount2.BankAmount = bankAmount2.BankAmount + Convert.ToDouble(this.txtEFTAmount.Text.Trim());
                }
                if (this.CheDebitCard.Checked && this.txtDebitCartAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO bankAmount3 = objMDAO;
                    bankAmount3.BankAmount = bankAmount3.BankAmount + Convert.ToDouble(this.txtDebitCartAmount.Text.Trim());
                }
                if (this.chkPayOrder.Checked && this.txtPayOrderAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO bankAmount4 = objMDAO;
                    bankAmount4.BankAmount = bankAmount4.BankAmount + Convert.ToDouble(this.txtPayOrderAmount.Text.Trim());
                }
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                double num9 = 0;
                double num10 = 0;
                double num11 = 0;
                num2 = (this.txtCashAmount.Text == "" ? 0 : Convert.ToDouble(this.txtCashAmount.Text.Trim()));
                num3 = (this.txtChequeAmount.Text == "" ? 0 : Convert.ToDouble(this.txtChequeAmount.Text.Trim()));
                num4 = (this.txtbKashAmount.Text == "" ? 0 : Convert.ToDouble(this.txtbKashAmount.Text.Trim()));
                num5 = (this.txtEFTAmount.Text == "" ? 0 : Convert.ToDouble(this.txtEFTAmount.Text.Trim()));
                num6 = (this.txtOthersAmount.Text == "" ? 0 : Convert.ToDouble(this.txtOthersAmount.Text.Trim()));
                num7 = (this.txtPayOrderAmount.Text == "" ? 0 : Convert.ToDouble(this.txtPayOrderAmount.Text.Trim()));
                num8 = (this.txtRocketAmount.Text == "" ? 0 : Convert.ToDouble(this.txtRocketAmount.Text.Trim()));
                num9 = (this.txtTPTAmount.Text == "" ? 0 : Convert.ToDouble(this.txtTPTAmount.Text.Trim()));
                num10 = (this.txtDebitCartAmount.Text == "" ? 0 : Convert.ToDouble(this.txtDebitCartAmount.Text.Trim()));
                num11 = num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9 + num10;
                if (this.gvItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItem.Rows.Count; i++)
                    {
                        num += Convert.ToDouble(this.gvItem.Rows[i].Cells[16].Text.Trim());
                    }
                    if (num11 < num)
                    {
                        num1 = num - num11;
                    }
                }
                PurchaseMasterDAO creditAmount = objMDAO;
                creditAmount.CreditAmount = creditAmount.CreditAmount + num1;
                if (objMDAO.PaymentMethodP == null)
                {
                    objMDAO.PaymentMethod = "3";
                }
                else
                {
                    string paymentMethodP = objMDAO.PaymentMethodP;
                    char[] chrArray = new char[] { ',' };
                    objMDAO.PaymentMethod = paymentMethodP.TrimEnd(chrArray);
                }
                double cashAmount3 = 0;
                double bankAmount5 = 0;
                double num12 = 0;
                cashAmount3 = objMDAO.CashAmount;
                bankAmount5 = objMDAO.BankAmount;
                num12 = (this.txtTotalPurchasePrice.Text == "" ? 0 : Convert.ToDouble(this.txtTotalPurchasePrice.Text.Trim()));
                if (num12 != cashAmount3 + bankAmount5)
                {
                    objMDAO.IsPaymentFinished = false;
                }
                else
                {
                    objMDAO.IsPaymentFinished = true;
                }
                objMDAO.Subject = (this.ddlGRNNo.SelectedValue != "-1" ? this.ddlGRNNo.SelectedItem.ToString() : string.Empty);
                objMDAO.CChallanNo = (this.ddlVoucher.SelectedValue != "-1" ? this.ddlVoucher.SelectedItem.ToString() : string.Empty);
                objMDAO.proportionVAT = Convert.ToDouble(this.txtTotalVAT.Text) * (objMDAO.CashAmount + objMDAO.BankAmount) / Convert.ToDouble(this.txtTotalPurchasePrice.Text);
                objMDAO.priceWithoutVDS = Convert.ToDouble(this.txtTotalPurchasePrice.Text) - Convert.ToDouble(this.txtTotalVAT.Text) * (objMDAO.CashAmount + objMDAO.BankAmount + objMDAO.CreditAmount) / Convert.ToDouble(this.txtTotalPurchasePrice.Text);
                objMDAO.proportionAIT = Convert.ToDouble(this.txtTotalAIT.Text) * (objMDAO.CashAmount + objMDAO.BankAmount) / Convert.ToDouble(this.txtTotalPurchasePrice.Text);
                if (this.txtCashAmount.Text == "" && this.txtChequeAmount.Text == "" && this.txtbKashAmount.Text == "" && this.txtEFTAmount.Text == "" && this.txtPayOrderAmount.Text == "" && this.txtCreditAmount.Text == "" && this.txtRocketAmount.Text == "" && this.txtTPTAmount.Text == "" && this.txtDebitCartAmount.Text == "" && this.txtOthersAmount.Text == "" || this.txtCashAmount.Text == "" && this.txtChequeAmount.Text == "0" && this.txtbKashAmount.Text == "0" && this.txtEFTAmount.Text == "0" && this.txtPayOrderAmount.Text == "0" && this.txtCreditAmount.Text == "0" && this.txtRocketAmount.Text == "" && this.txtTPTAmount.Text == "0" && this.txtDebitCartAmount.Text == "0" && this.txtOthersAmount.Text == "0")
                {
                    objMDAO.CreditAmount = Convert.ToDouble(this.txtTotalPurchasePrice.Text);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                objMDAO = null;
            }
            return objMDAO;
        }

        private void GetInsertExcelMasterValues()
        {
            try
            {
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["Purchase_EXCEL"];
                ArrayList item = (ArrayList)this.Session["Purchase_Master_LIST"] ?? new ArrayList();
                foreach (PurchaseDetailDAO arrayList in arrayLists)
                {
                    PurchaseMasterDAO purchaseMasterDAO = new PurchaseMasterDAO()
                    {
                        OrganizatioID = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString()),
                        Org_branch_reg_id = (!string.IsNullOrEmpty(this.drpBranchName.SelectedValue) ? Convert.ToInt32(this.drpBranchName.SelectedValue.ToString()) : 0),
                        ChallanType = 'P',
                        ChallanNo = arrayList.Challan_No,
                        PurchaseType = 'L',
                        AggrementNo = (!string.IsNullOrEmpty(this.txtAgreement.Text) ? this.txtAgreement.Text : "")
                    };
                    if (!string.IsNullOrEmpty(this.txtChallanDate.Text.Trim()))
                    {
                        purchaseMasterDAO.ChallanDate = Convert.ToDateTime(arrayList.Challan_Date);
                    }
                    purchaseMasterDAO.ScrollNo =  BLL.Utility.ReplaceQuotes(this.txtScrollNo.Text);
                    purchaseMasterDAO.VehicleTypeM = 7;
                    purchaseMasterDAO.VehicleTypeD = Convert.ToInt16(this.drpVehicleType.SelectedValue);
                    purchaseMasterDAO.VehicleNo =  BLL.Utility.ReplaceQuotes(this.txtVehicleNo.Text);
                    purchaseMasterDAO.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                    DataTable party = this.objBLL.GetParty(arrayList.Party_Name.ToUpper());
                    if (party.Rows.Count > 0)
                    {
                        purchaseMasterDAO.PartyID = Convert.ToInt16(party.Rows[0]["party_id"]);
                        purchaseMasterDAO.IsNewParty = false;
                    }
                    purchaseMasterDAO.UltimateDestination =  BLL.Utility.ReplaceQuotes(this.txtDestination.Text);
                    purchaseMasterDAO.Remarks =  BLL.Utility.ReplaceQuotes(this.txtRemarks.Text);
                    purchaseMasterDAO.PaymentInfo = this.txt_transaction_id.Text;
                    purchaseMasterDAO.Subject = (this.ddlGRNNo.SelectedValue != "-1" ? this.ddlGRNNo.SelectedItem.ToString() : string.Empty);
                    purchaseMasterDAO.CChallanNo = (this.ddlVoucher.SelectedValue != "-1" ? this.ddlVoucher.SelectedItem.ToString() : string.Empty);
                    purchaseMasterDAO.CreditAmount = arrayList.CreditAmount;
                    purchaseMasterDAO.CashAmount = arrayList.CashAmount;
                    purchaseMasterDAO.IsPaymentFinished = arrayList.IsPaymentFinished;
                    item.Add(purchaseMasterDAO);
                }
                this.Session["Purchase_Master_LIST"] = item;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private DataTable getNewDataTableWithBalance(DataTable dtCurrentAccount)
        {
            decimal num = new decimal(0);
            for (int i = 0; i < dtCurrentAccount.Rows.Count; i++)
            {
                decimal num1 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["treasury_deposit"]);
                decimal num2 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["exempt_amount"]);
                decimal num3 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["others"]);
                decimal num4 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["pay_amount"]);
                decimal num5 = (num1 + num2) - num4;
                short num6 = Convert.ToInt16(dtCurrentAccount.Rows[i]["balance_action"]);
                if (i != 0)
                {
                    if (num6 != 1)
                    {
                        num = (num + num3) + num5;
                    }
                    else
                    {
                        num += num5;
                        if (num3 > new decimal(0))
                        {
                            num -= num3;
                        }
                    }
                    dtCurrentAccount.Rows[i]["balance_amount"] = num.ToString("0.00");
                }
                else
                {
                    num = Convert.ToDecimal(dtCurrentAccount.Rows[0]["balance_amount"]);
                }
            }
            return dtCurrentAccount;
        }

        private void GetPartyInfo()
        {
            this.drpParty.Items.Clear();
            DataTable allPartyInfoForLocalPurchase = (new ChallanBLL()).GetAllPartyInfoForLocalPurchase();
            if (allPartyInfoForLocalPurchase != null && allPartyInfoForLocalPurchase.Rows.Count > 0)
            {
                this.drpParty.DataSource = allPartyInfoForLocalPurchase;
                this.drpParty.DataTextField = allPartyInfoForLocalPurchase.Columns["party_name"].ToString();
                this.drpParty.DataValueField = allPartyInfoForLocalPurchase.Columns["Party_id"].ToString();
                this.drpParty.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpParty.Items.Insert(0, listItem);
            this.Session["PARTY_INFO"] = allPartyInfoForLocalPurchase;
        }

        private void GetPartyInfoRegistrationWise(int regTypeId)
        {
            this.drpParty.Items.Clear();
            ChallanBLL challanBLL = new ChallanBLL();
            if (regTypeId == 0)
            {
                this.GetPartyInfo();
                return;
            }
            DataTable allPartyInfoRegistrationWise = challanBLL.GetAllPartyInfoRegistrationWise(regTypeId);
            allPartyInfoRegistrationWise = this.formatDataTableForEconomicActivity(allPartyInfoRegistrationWise);
            if (allPartyInfoRegistrationWise != null && allPartyInfoRegistrationWise.Rows.Count > 0)
            {
                this.drpParty.DataSource = allPartyInfoRegistrationWise;
                this.drpParty.DataTextField = allPartyInfoRegistrationWise.Columns["party_name"].ToString();
                this.drpParty.DataValueField = allPartyInfoRegistrationWise.Columns["Party_id"].ToString();
                this.drpParty.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpParty.Items.Insert(0, listItem);
        }

        private void GetPriceInfo(int propertyTypeID)
        {
            try
            {
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                bool flag = false;
                for (int i = 0; i < 5; i++)
                {
                    if (i != propertyTypeID - 1)
                    {
                        if (!this.drpPropertyCollection[i].Visible || !this.drpPropertyCollection[i].Enabled || !(this.drpPropertyCollection[i].SelectedValue == "-99"))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (this.drpPropertyCollection[j].Visible && this.drpPropertyCollection[j].Enabled)
                        {
                        }
                    }
                    purchaseDetailDAO.ItemID = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable priceInfoOfItem = (new ChallanBLL()).GetPriceInfoOfItem(purchaseDetailDAO);
                    if (priceInfoOfItem == null || priceInfoOfItem.Rows.Count <= 0)
                    {
                        this.txtPurchaseUnitPrice.Text = "0.00";
                        this.lblPurchaseUnitPrice.Text = "0.00";
                        this.lblPurchaseSD.Text = "0.00";
                        this.lblPurchaseVAT.Text = "0.00";
                    }
                    else
                    {
                        this.lblPurchaseUnitPrice.Text = priceInfoOfItem.Rows[0]["unit_price"].ToString();
                        this.txtPurchaseUnitPrice.Text = priceInfoOfItem.Rows[0]["unit_price"].ToString();
                        this.lblPurchaseSD.Text = priceInfoOfItem.Rows[0]["sd_amount"].ToString();
                        this.lblPurchaseVAT.Text = priceInfoOfItem.Rows[0]["VAT"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void GetPriceInfo()
        {
            try
            {
                SaleDetailDAO saleDetailDAO = new SaleDetailDAO()
                {
                    ItemID = Convert.ToInt32(this.drpItem.SelectedValue)
                };
                if (saleDetailDAO.ItemID != -99)
                {
                    SaleBLL saleBLL = new SaleBLL();
                    DataTable priceInfoOfItemForLocalPurchase = saleBLL.GetPriceInfoOfItemForLocalPurchase(saleDetailDAO);
                    DataTable priceInfoOfItemFrSale = saleBLL.GetPriceInfoOfItemFrSale(saleDetailDAO);
                    string str = "";
                    if (priceInfoOfItemForLocalPurchase != null && priceInfoOfItemForLocalPurchase.Rows.Count > 0)
                    {
                        str = priceInfoOfItemForLocalPurchase.Rows[0]["per"].ToString();
                    }
                    if (this.drpRegType.SelectedValue == "7")
                    {
                        this.lblPurchaseVAT.Text = "7.5";
                        if (priceInfoOfItemForLocalPurchase == null || priceInfoOfItemForLocalPurchase.Rows.Count <= 0)
                        {
                            this.lblPurchaseAIT.Text = "0.00";
                        }
                        else
                        {
                            this.lblPurchaseAIT.Text = priceInfoOfItemForLocalPurchase.Rows[0]["AIT_RATE"].ToString();
                        }
                    }
                    else if (this.drpRegType.SelectedValue != "8")
                    {
                        if (priceInfoOfItemForLocalPurchase != null)
                        {
                            if (priceInfoOfItemForLocalPurchase.Rows.Count <= 0)
                            {
                                this.lblPurchaseUnitPrice.Text = "0.00";
                                this.lblPurchaseSD.Text = "0.00";
                                this.lblPurchaseVAT.Text = "0.00";
                                this.lblPurchaseAIT.Text = "0.00";
                                this.hdPriceID.Value = "";
                            }
                            else if (str != "1")
                            {
                                this.lblPurchaseSD.Text = priceInfoOfItemForLocalPurchase.Rows[0]["SD_RATE"].ToString();
                                this.lblPurchaseVAT.Text = priceInfoOfItemForLocalPurchase.Rows[0]["VAT_RATE"].ToString();
                                this.lblPurchaseAIT.Text = priceInfoOfItemForLocalPurchase.Rows[0]["AIT_RATE"].ToString();
                                this.hdPriceID.Value = priceInfoOfItemForLocalPurchase.Rows[0]["price_id"].ToString();
                                if (Convert.ToDecimal(priceInfoOfItemForLocalPurchase.Rows[0]["VAT_RATE"]) == new decimal(15))
                                {
                                    this.chkRebatable.Checked = true;
                                }
                            }
                            else
                            {
                                this.txtPurchaseVAT.Text = priceInfoOfItemForLocalPurchase.Rows[0]["VAT_RATE"].ToString();
                                this.lblfxdVT.Text = "Tk. ";
                                this.lblPurchaseVAT.Text = priceInfoOfItemForLocalPurchase.Rows[0]["VAT_RATE"].ToString();
                                this.Label25.Text = " Per Unit.";
                            }
                        }
                        if (priceInfoOfItemFrSale == null || priceInfoOfItemFrSale.Rows.Count <= 0)
                        {
                            this.lblSaleVat.Text = "0.00";
                            this.lblSaleSD.Text = "0.00";
                            this.lbelAIT.Text = "0.00";
                        }
                        else
                        {
                            this.lblSaleVat.Text = priceInfoOfItemFrSale.Rows[0]["VAT_RATE"].ToString();
                            this.lblSaleSD.Text = priceInfoOfItemFrSale.Rows[0]["SD_RATE"].ToString();
                            this.lbelAIT.Text = priceInfoOfItemFrSale.Rows[0]["AIT_RATE"].ToString();
                        }
                    }
                    else
                    {
                        this.lblPurchaseVAT.Text = "5";
                        if (priceInfoOfItemForLocalPurchase == null || priceInfoOfItemForLocalPurchase.Rows.Count <= 0)
                        {
                            this.lblPurchaseAIT.Text = "0.00";
                        }
                        else
                        {
                            this.lblPurchaseAIT.Text = priceInfoOfItemForLocalPurchase.Rows[0]["AIT_RATE"].ToString();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getProductInfo()
        {
            string str = MQMM.ParseText(this.productName.Text.Trim());
            DataTable productInfo = (new SaleBLL()).getProductInfo(str);
            if (productInfo.Rows == null)
            {
                this.drpItem.SelectedValue = "-99";
                return;
            }
            this.drpItem.SelectedValue = productInfo.Rows[0]["item_id"].ToString();
            this.EnableOrDisablePropertyForItem();
            if (this.drpItem.SelectedValue != "-99")
            {
                string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                if (strArrays != null && strArrays.Count<string>() > 0)
                {
                    this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 2];
                }
            }
            this.GetPriceInfo();
        }

        private void GetPropertyWiseAvailStock()
        {
            try
            {
                short num = 0;
                short num1 = 0;
                short num2 = 0;
                short num3 = 0;
                short num4 = 0;
                string empty = string.Empty;
                SaleBLL saleBLL = new SaleBLL();
                string str = "";
                string str1 = "";
                DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", null);
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                short num5 = 0;
                string str2 = "";
                if (this.drpProperty1.SelectedValue != "-99" && this.drpProperty1.SelectedValue != "")
                {
                    num = Convert.ToInt16(this.drpProperty1.SelectedValue);
                }
                if (this.drpProperty2.SelectedValue != "-99" && this.drpProperty2.SelectedValue != "")
                {
                    num1 = Convert.ToInt16(this.drpProperty2.SelectedValue);
                }
                if (this.drpProperty3.SelectedValue != "-99" && this.drpProperty3.SelectedValue != "")
                {
                    num2 = Convert.ToInt16(this.drpProperty3.SelectedValue);
                }
                if (this.drpProperty4.SelectedValue != "-99" && this.drpProperty4.SelectedValue != "")
                {
                    num3 = Convert.ToInt16(this.drpProperty4.SelectedValue);
                }
                if (this.drpProperty5.SelectedValue != "-99" && this.drpProperty5.SelectedValue != "")
                {
                    num4 = Convert.ToInt16(this.drpProperty5.SelectedValue);
                }
                if (this.drpItem.SelectedValue != "-99")
                {
                    if (num > 0)
                    {
                        empty = string.Concat(" AND property_id1 = ", num);
                    }
                    if (num1 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id2 = ", num1);
                    }
                    if (num2 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id3 = ", num2);
                    }
                    if (num3 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id4 = ", num3);
                    }
                    if (num4 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id5 = ", num4);
                    }
                    str = this.drpItem.SelectedItem.ToString();
                    str2 = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays = str2.Split(new char[] { '.' });
                    num5 = Convert.ToInt16(strArrays[0]);
                    if (str.Contains("Local"))
                    {
                        str1 = "L";
                    }
                    if (str.Contains("Import"))
                    {
                        str1 = "I";
                    }
                    if (str.Contains("Production"))
                    {
                        str1 = "F";
                    }
                    dataTable = saleBLL.GetStockPropertyWise(num5, str1, dateTime, num, num1, num2, num3, num4, empty);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.lblAvailStock.Text = (dataTable.Rows[0]["item_type"].ToString() == "I" ? dataTable.Rows[0]["availStock"].ToString() : "0");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void GETSalePart()
        {
            if (this.chkSaleValue.Checked)
            {
                this.lblSaleUnitPrice.Visible = true;
                this.txtSaleUnitPrice.Visible = true;
                this.lblSaleVatablePrice.Visible = true;
                this.txtSaleVatablePrice.Visible = true;
                this.lblSalesVat.Visible = true;
                this.txtSaleVat.Visible = true;
                this.lblSaleVat.Visible = true;
                this.lblVatPercent.Visible = true;
                this.lblSalesSD.Visible = true;
                this.txtSaleSD.Visible = true;
                this.lblSaleSD.Visible = true;
                this.lblSDPercent.Visible = true;
                this.lblAIT.Visible = true;
                this.txtAIT.Visible = true;
                this.lbelAIT.Visible = true;
                this.lblAITPct.Visible = true;
                return;
            }
            this.lblSaleUnitPrice.Visible = false;
            this.txtSaleUnitPrice.Visible = false;
            this.lblSaleVatablePrice.Visible = false;
            this.txtSaleVatablePrice.Visible = false;
            this.lblSalesVat.Visible = false;
            this.txtSaleVat.Visible = false;
            this.lblSaleVat.Visible = false;
            this.lblVatPercent.Visible = false;
            this.lblSalesSD.Visible = false;
            this.txtSaleSD.Visible = false;
            this.lblSaleSD.Visible = false;
            this.lblSDPercent.Visible = false;
            this.lblAIT.Visible = false;
            this.txtAIT.Visible = false;
            this.lbelAIT.Visible = false;
            this.lblAITPct.Visible = false;
        }

        private void GetTotalPurchasePrice()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                ChallanBLL challanBLL = new ChallanBLL();
                int num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                if (this.txtQuantity.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0 && this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                {
                    if (this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                    {
                        num3 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                        num2 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    }
                    if (this.lblPurchaseSD.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseSD.Text) <= 0 || num3 <= 0)
                    {
                        this.lblTotalSD.Text = "0.00";
                        this.txtPurchaseSD.Text = "0.00";
                    }
                    else
                    {
                        Label str = this.lblTotalSD;
                        double num5 = num3 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        str.Text = num5.ToString("0.00");
                        TextBox textBox = this.txtPurchaseSD;
                        double num6 = num3 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        textBox.Text = num6.ToString("0.00");
                    }
                    if (this.lblPurchaseAIT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseAIT.Text) <= 0 || num3 <= 0)
                    {
                        this.txtPurchaseAIT.Text = "0.00";
                    }
                    else
                    {
                        TextBox str1 = this.txtPurchaseAIT;
                        double num7 = num3 * (Convert.ToDouble(this.lblPurchaseAIT.Text) / 100);
                        str1.Text = num7.ToString("0.00");
                    }
                    if (this.lblPurchaseVAT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseVAT.Text) <= 0 || num3 <= 0)
                    {
                        decimal num8 = new decimal(0);
                        decimal num9 = new decimal(0);
                        decimal num10 = new decimal(0);
                        decimal num11 = new decimal(0);
                        num = Convert.ToInt32(this.drpItem.SelectedValue);
                        DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num);
                        if (itemIsTeriff.Rows.Count > 0 && Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                        {
                            DataTable itemVatAmountForLocalPurchase = addItemBLL.getItemVatAmountForLocalPurchase(num);
                            if (itemVatAmountForLocalPurchase.Rows.Count > 0)
                            {
                                num10 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["tax_value"]);
                                num8 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["per"]);
                                num9 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                num11 = (num10 * num9) / num8;
                            }
                        }
                        if (num10 <= new decimal(0))
                        {
                            this.txtPurchaseVAT.Text = "0.00";
                        }
                        else
                        {
                            this.txtPurchaseVAT.Text = num11.ToString();
                            this.lblTotalVAT.Text = num11.ToString();
                        }
                    }
                    else if (this.lblProductType.Text == "W")
                    {
                        Label label = this.lblTotalVAT;
                        double num12 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                        label.Text = num12.ToString("0.00");
                        TextBox textBox1 = this.txtPurchaseVAT;
                        double num13 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                        textBox1.Text = num13.ToString("0.00");
                    }
                    else
                    {
                        Label label1 = this.lblTotalVAT;
                        double num14 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                        label1.Text = num14.ToString("0.00");
                        TextBox str2 = this.txtPurchaseVAT;
                        double num15 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                        str2.Text = num15.ToString("0.00");
                    }
                    Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                    if (!this.chkTaxDeducted.Checked || num2 <= 10000)
                    {
                        this.vdsAmount.Text = "0.00";
                        this.txtvdsamount.Text = "0.00";
                        this.chkTaxDeducted.Checked = false;
                        this.lblvdstx.Visible = false;
                        this.txtvdsamount.Visible = false;
                    }
                    else
                    {
                        this.vdsAmount.Text = this.txtPurchaseVAT.Text.ToString();
                        this.txtvdsamount.Text = this.txtPurchaseVAT.Text.ToString();
                    }
                    num1 = Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                    Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim());
                    double num16 = Convert.ToDouble(this.lblPurchaseVAT.Text) / 100;
                    num4 = Convert.ToDouble(this.txtQuantity.Text.Trim()) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim());
                    Convert.ToDouble(this.txtPurchaseVAT.Text);
                    Convert.ToDouble(this.txtPurchaseSD.Text);
                    this.txtTotalPrice.Text = num3.ToString("0.00");
                    this.lblTotalPrice.Text = num3.ToString("N2");
                    Label label2 = this.lblTotalPurchasePrc;
                    double num17 = num3 + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                    label2.Text = num17.ToString("N2");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void GetTotalPurchasePriceIncldingVatChange()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                ChallanBLL challanBLL = new ChallanBLL();
                int num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                if (this.txtQuantity.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0 && this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                {
                    if (this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                    {
                        num3 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                        num2 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    }
                    if (this.lblPurchaseSD.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseSD.Text) <= 0 || num3 <= 0)
                    {
                        this.lblTotalSD.Text = "0.00";
                        this.txtPurchaseSD.Text = "0.00";
                    }
                    else
                    {
                        Label str = this.lblTotalSD;
                        double num5 = num3 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        str.Text = num5.ToString("N2");
                        TextBox textBox = this.txtPurchaseSD;
                        double num6 = num3 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        textBox.Text = num6.ToString("0.00");
                    }
                    if (this.lblPurchaseVAT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseVAT.Text) <= 0 || num3 <= 0)
                    {
                        decimal num7 = new decimal(0);
                        decimal num8 = new decimal(0);
                        decimal num9 = new decimal(0);
                        decimal num10 = new decimal(0);
                        num = Convert.ToInt32(this.drpItem.SelectedValue);
                        DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num);
                        if (itemIsTeriff.Rows.Count > 0 && Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                        {
                            DataTable itemVatAmountForLocalPurchase = addItemBLL.getItemVatAmountForLocalPurchase(num);
                            if (itemVatAmountForLocalPurchase.Rows.Count > 0)
                            {
                                num9 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["tax_value"]);
                                num7 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["per"]);
                                num8 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                num10 = (num9 * num8) / num7;
                            }
                        }
                        if (num9 <= new decimal(0))
                        {
                            this.txtPurchaseVAT.Text = "0.00";
                        }
                        else
                        {
                            this.txtPurchaseVAT.Text = num10.ToString();
                            this.lblTotalVAT.Text = num10.ToString("N2");
                        }
                    }
                    else if (this.lblProductType.Text == "W")
                    {
                        Label label = this.lblTotalVAT;
                        double num11 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                        label.Text = num11.ToString("N2");
                        TextBox str1 = this.txtPurchaseVAT;
                        double num12 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                        str1.Text = num12.ToString("0.00");
                    }
                    else
                    {
                        Label label1 = this.lblTotalVAT;
                        double num13 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                        label1.Text = num13.ToString("N2");
                        TextBox textBox1 = this.txtPurchaseVAT;
                        double num14 = (num3 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                        textBox1.Text = num14.ToString("0.00");
                    }
                    Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                    DataTable itemIsVds = addItemBLL.GetItemIsVds(num);
                    if (itemIsVds.Rows.Count <= 0)
                    {
                        this.chkTaxDeducted.Checked = false;
                    }
                    else if (Convert.ToBoolean(itemIsVds.Rows[0]["is_vds"]))
                    {
                        this.chkTaxDeducted.Checked = true;
                        this.chkTaxDeducted.Attributes["style"] = "color:Green;";
                        this.partVDS.Visible = true;
                    }
                    if (!this.chkTaxDeducted.Checked || num2 <= 10000)
                    {
                        this.vdsAmount.Text = "0.00";
                        this.txtvdsamount.Text = "0.00";
                        this.chkTaxDeducted.Checked = false;
                        this.lblvdstx.Visible = false;
                        this.txtvdsamount.Visible = false;
                    }
                    else
                    {
                        this.vdsAmount.Text = this.txtPurchaseVAT.Text.ToString();
                        this.txtvdsamount.Text = this.txtPurchaseVAT.Text.ToString();
                    }
                    num1 = (!(this.txtPurchaseUnitPrice.Text != "") || !(this.lblPurchaseSD.Text != "") ? 0 : Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100));
                    if (this.txtPurchaseUnitPrice.Text != "" && this.lblPurchaseSD.Text != "")
                    {
                        Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim());
                        double num15 = Convert.ToDouble(this.lblPurchaseVAT.Text) / 100;
                    }
                    num4 = Convert.ToDouble(this.txtQuantity.Text.Trim()) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim());
                    Convert.ToDouble(this.txtPurchaseVAT.Text);
                    Convert.ToDouble(this.txtPurchaseSD.Text);
                    double num16 = Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    this.txtPurchaseUnitPrice.Text = num16.ToString("0.00");
                    this.lblTotalPrice.Text = num3.ToString("N2");
                    this.txtTotalPrice.Text = num3.ToString("0.00");
                    Label str2 = this.lblTotalPurchasePrc;
                    double num17 = num3 + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                    str2.Text = num17.ToString("N2");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void GetTotalPurchasePriceQtyChange()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                ChallanBLL challanBLL = new ChallanBLL();
                int num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                double num5 = 0;
                bool flag = false;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                double num9 = 0;
                double num10 = 0;
                num6 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                num7 = (this.lblPurchaseVAT.Text != "" ? Convert.ToDouble(this.lblPurchaseVAT.Text.Trim()) : 0);
                if (this.Label25.Text == " Per Unit.")
                {
                    num8 = num6 * num7;
                    this.txtPurchaseVAT.Text = num8.ToString("N2");
                    num9 = num6 * (this.txtPurchaseUnitPrice.Text != "" ? Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) : 0);
                    this.txtTotalPrice.Text = num9.ToString("N2");
                    num10 = num9 + num8;
                    this.txtPriceIncludingVat.Text = num10.ToString("N2");
                    this.lblTotalPrice.Text = num9.ToString("N2");
                    this.lblTotalVAT.Text = num8.ToString("N2");
                    this.lblTotalSD.Text = ((this.txtPurchaseSD.Text != "" ? Convert.ToDouble(this.txtPurchaseSD.Text.Trim()) : 0)).ToString("N2");
                    this.lblTotalPurchasePrc.Text = this.txtPriceIncludingVat.Text.Trim();
                }
                else if (this.txtQuantity.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0 && this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                {
                    if (this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                    {
                        num4 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                        num3 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    }
                    if (this.lblPurchaseSD.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseSD.Text) <= 0 || num4 <= 0)
                    {
                        this.lblTotalSD.Text = "0.00";
                        this.txtPurchaseSD.Text = "0.00";
                    }
                    else
                    {
                        Label str = this.lblTotalSD;
                        double num11 = num4 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        str.Text = num11.ToString("N2");
                        TextBox textBox = this.txtPurchaseSD;
                        double num12 = num4 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        textBox.Text = num12.ToString("0.00");
                    }
                    if (this.lblPurchaseAIT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseAIT.Text) <= 0 || num4 <= 0)
                    {
                        this.txtPurchaseAIT.Text = "0.00";
                    }
                    else
                    {
                        TextBox str1 = this.txtPurchaseAIT;
                        double num13 = num4 * (Convert.ToDouble(this.lblPurchaseAIT.Text) / 100);
                        str1.Text = num13.ToString("0.00");
                    }
                    if (this.lblPurchaseVAT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseVAT.Text) <= 0 || num4 <= 0)
                    {
                        decimal num14 = new decimal(0);
                        decimal num15 = new decimal(0);
                        decimal num16 = new decimal(0);
                        decimal num17 = new decimal(0);
                        num = Convert.ToInt32(this.drpItem.SelectedValue);
                        DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num);
                        if (itemIsTeriff.Rows.Count > 0)
                        {
                            flag = Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]);
                            if (flag)
                            {
                                DataTable itemVatAmountForLocalPurchase = addItemBLL.getItemVatAmountForLocalPurchase(num);
                                if (itemVatAmountForLocalPurchase.Rows.Count > 0)
                                {
                                    num16 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["tax_value"]);
                                    num14 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["per"]);
                                    num15 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                    num17 = (num16 * num15) / num14;
                                }
                            }
                        }
                        if (num16 <= new decimal(0))
                        {
                            this.txtPurchaseVAT.Text = "0.00";
                        }
                        else
                        {
                            this.txtPurchaseVAT.Text = num17.ToString();
                            this.lblTotalVAT.Text = num17.ToString("N2");
                        }
                    }
                    else if (this.lblProductType.Text == "W")
                    {
                        Label label = this.lblTotalVAT;
                        double num18 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                        label.Text = num18.ToString("N2");
                        TextBox textBox1 = this.txtPurchaseVAT;
                        double num19 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                        textBox1.Text = num19.ToString("0.00");
                    }
                    else
                    {
                        Label label1 = this.lblTotalVAT;
                        double num20 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                        label1.Text = num20.ToString("N2");
                        TextBox str2 = this.txtPurchaseVAT;
                        double num21 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                        str2.Text = num21.ToString("0.00");
                    }
                    Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                    num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable itemIsVds = addItemBLL.GetItemIsVds(num);
                    if (itemIsVds.Rows.Count <= 0)
                    {
                        this.chkTaxDeducted.Checked = false;
                    }
                    else if (Convert.ToBoolean(itemIsVds.Rows[0]["is_vds"]))
                    {
                        this.chkTaxDeducted.Checked = true;
                        this.chkTaxDeducted.Attributes["style"] = "color:Green;";
                        this.partVDS.Visible = true;
                    }
                    if (!this.chkTaxDeducted.Checked || num3 <= 10000)
                    {
                        this.vdsAmount.Text = "0.00";
                        this.txtvdsamount.Text = "0.00";
                        this.chkTaxDeducted.Checked = false;
                        this.partVDS.Visible = false;
                    }
                    else
                    {
                        this.partVDS.Visible = true;
                        this.vdsAmount.Text = this.txtPurchaseVAT.Text.ToString();
                        this.txtvdsamount.Text = this.txtPurchaseVAT.Text.ToString();
                    }
                    num2 = (!(this.txtPurchaseUnitPrice.Text != "") || !(this.lblPurchaseSD.Text != "") ? 0 : Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100));
                    num1 = (!(this.txtPurchaseUnitPrice.Text != "") || !(this.lblPurchaseSD.Text != "") ? 0 : (Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) + num2) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100));
                    num5 = Convert.ToDouble(this.txtQuantity.Text.Trim()) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim());
                    Convert.ToDouble(this.txtPurchaseVAT.Text);
                    Convert.ToDouble(this.txtPurchaseSD.Text);
                    this.lblTotalPrice.Text = num4.ToString("N2");
                    this.txtTotalPrice.Text = num4.ToString();
                    Label label2 = this.lblTotalPurchasePrc;
                    double num22 = num4 + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                    label2.Text = num22.ToString("N2");
                    double num23 = 0;
                    double num24 = 0;
                    double num25 = 0;
                    double num26 = 0;
                    double num27 = 0;
                    double num28 = 0;
                    double num29 = 0;
                    num23 = (this.txtQuantity.Text == "" ? 0 : Convert.ToDouble(this.txtQuantity.Text.Trim()));
                    num24 = (this.txtPurchaseUnitPrice.Text == "" ? 0 : Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()));
                    num27 = num1 * num23;
                    num28 = num2 * num23;
                    num25 = num23 * num24;
                    if (!flag)
                    {
                        num26 = num25 + num28 + num27;
                    }
                    else if (flag)
                    {
                        num29 = Convert.ToDouble(this.txtPurchaseVAT.Text.Trim());
                        num26 = num25 + num29;
                    }
                    this.txtPriceIncludingVat.Text = num26.ToString("0.00");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void GetTotalPurchasePriceUnitPriceChange()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                ChallanBLL challanBLL = new ChallanBLL();
                int num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                double num5 = 0;
                bool flag = false;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                double num9 = 0;
                double num10 = 0;
                if (this.Label25.Text == " Per Unit.")
                {
                    num6 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 1);
                    num7 = (this.txtPurchaseUnitPrice.Text != "" ? Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) : 0);
                    num10 = (this.txtPurchaseVAT.Text != "" ? Convert.ToDouble(this.txtPurchaseVAT.Text.Trim()) : 0);
                    num8 = num7 * num6;
                    this.txtTotalPrice.Text = num8.ToString("N2");
                    num9 = num8 + num10;
                    this.txtPriceIncludingVat.Text = num9.ToString("N2");
                    this.lblTotalPrice.Text = num8.ToString("N2");
                    this.lblTotalVAT.Text = this.txtPurchaseVAT.Text.Trim();
                    this.lblTotalSD.Text = ((this.txtPurchaseSD.Text != "" ? Convert.ToDouble(this.txtPurchaseSD.Text.Trim()) : 0)).ToString("N2");
                    this.lblTotalPurchasePrc.Text = this.txtPriceIncludingVat.Text.Trim();
                }
                else if (this.txtQuantity.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0 && this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                {
                    if (this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                    {
                        num4 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                        num3 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    }
                    if (this.lblPurchaseSD.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseSD.Text) <= 0 || num4 <= 0)
                    {
                        this.lblTotalSD.Text = "0.00";
                        this.txtPurchaseSD.Text = "0.00";
                    }
                    else
                    {
                        Label str = this.lblTotalSD;
                        double num11 = num4 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        str.Text = num11.ToString("N2");
                        TextBox textBox = this.txtPurchaseSD;
                        double num12 = num4 * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        textBox.Text = num12.ToString("0.00");
                    }
                    if (this.lblPurchaseAIT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseAIT.Text) <= 0 || num4 <= 0)
                    {
                        this.txtPurchaseAIT.Text = "0.00";
                    }
                    else
                    {
                        TextBox str1 = this.txtPurchaseAIT;
                        double num13 = num4 * (Convert.ToDouble(this.lblPurchaseAIT.Text) / 100);
                        str1.Text = num13.ToString("0.00");
                    }
                    if (this.lblPurchaseVAT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseVAT.Text) <= 0 || num4 <= 0)
                    {
                        decimal num14 = new decimal(0);
                        decimal num15 = new decimal(0);
                        decimal num16 = new decimal(0);
                        decimal num17 = new decimal(0);
                        num = Convert.ToInt32(this.drpItem.SelectedValue);
                        DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num);
                        if (itemIsTeriff.Rows.Count > 0)
                        {
                            flag = Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]);
                            if (flag)
                            {
                                DataTable itemVatAmountForLocalPurchase = addItemBLL.getItemVatAmountForLocalPurchase(num);
                                if (itemVatAmountForLocalPurchase.Rows.Count > 0)
                                {
                                    num16 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["tax_value"]);
                                    num14 = Convert.ToDecimal(itemVatAmountForLocalPurchase.Rows[0]["per"]);
                                    num15 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                    num17 = (num16 * num15) / num14;
                                }
                            }
                        }
                        if (num16 <= new decimal(0))
                        {
                            this.txtPurchaseVAT.Text = "0.00";
                        }
                        else
                        {
                            this.txtPurchaseVAT.Text = num17.ToString();
                            this.lblTotalVAT.Text = num17.ToString("N2");
                        }
                    }
                    else if (this.Label25.Text != " Per Unit.")
                    {
                        if (this.lblProductType.Text == "W")
                        {
                            Label label = this.lblTotalVAT;
                            double num18 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                            label.Text = num18.ToString("N2");
                            TextBox textBox1 = this.txtPurchaseVAT;
                            double num19 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                            textBox1.Text = num19.ToString("0.00");
                        }
                        else
                        {
                            Label label1 = this.lblTotalVAT;
                            double num20 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                            label1.Text = num20.ToString("N2");
                            TextBox str2 = this.txtPurchaseVAT;
                            double num21 = (num4 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                            str2.Text = num21.ToString("0.00");
                        }
                    }
                    Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                    num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable itemIsVds = addItemBLL.GetItemIsVds(num);
                    if (itemIsVds.Rows.Count <= 0)
                    {
                        this.chkTaxDeducted.Checked = false;
                    }
                    else if (Convert.ToBoolean(itemIsVds.Rows[0]["is_vds"]))
                    {
                        this.chkTaxDeducted.Checked = true;
                        this.chkTaxDeducted.Attributes["style"] = "color:Green;";
                        this.partVDS.Visible = true;
                    }
                    if (!this.chkTaxDeducted.Checked || num3 <= 10000)
                    {
                        this.vdsAmount.Text = "0.00";
                        this.txtvdsamount.Text = "0.00";
                        this.chkTaxDeducted.Checked = false;
                        this.partVDS.Visible = false;
                    }
                    else
                    {
                        this.partVDS.Visible = true;
                        this.vdsAmount.Text = this.txtPurchaseVAT.Text.ToString();
                        this.txtvdsamount.Text = this.txtPurchaseVAT.Text.ToString();
                    }
                    num2 = (!(this.txtPurchaseUnitPrice.Text != "") || !(this.lblPurchaseSD.Text != "") ? 0 : Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100));
                    num1 = (!(this.txtPurchaseUnitPrice.Text != "") || !(this.lblPurchaseSD.Text != "") ? 0 : (Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) + num2) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100));
                    num5 = Convert.ToDouble(this.txtQuantity.Text.Trim()) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim());
                    Convert.ToDouble(this.txtPurchaseVAT.Text);
                    Convert.ToDouble(this.txtPurchaseSD.Text);
                    this.lblTotalPrice.Text = num4.ToString("N2");
                    this.txtTotalPrice.Text = num4.ToString();
                    Label label2 = this.lblTotalPurchasePrc;
                    double num22 = num4 + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                    label2.Text = num22.ToString("N2");
                    double num23 = 0;
                    double num24 = 0;
                    double num25 = 0;
                    double num26 = 0;
                    double num27 = 0;
                    double num28 = 0;
                    double num29 = 0;
                    num23 = (this.txtQuantity.Text == "" ? 0 : Convert.ToDouble(this.txtQuantity.Text.Trim()));
                    num24 = (this.txtPurchaseUnitPrice.Text == "" ? 0 : Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()));
                    num27 = num1 * num23;
                    num28 = num2 * num23;
                    num25 = num23 * num24;
                    if (flag)
                    {
                        num29 = Convert.ToDouble(this.txtPurchaseVAT.Text.Trim());
                        num26 = num25 + num29;
                    }
                    else
                    {
                        num26 = num25 + num28 + num27;
                    }
                    this.txtPriceIncludingVat.Text = num26.ToString("0.00");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void GetTotalSaleValue()
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                if (this.gvItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItem.Rows.Count; i++)
                    {
                        num += Convert.ToDecimal(this.gvItem.Rows[i].Cells[16].Text.Trim());
                        num2 += Convert.ToDecimal(this.gvItem.Rows[i].Cells[15].Text.Trim());
                        num1 += Convert.ToDecimal(this.gvItem.Rows[i].Cells[14].Text.Trim());
                    }
                }
                this.txtTotalPurchasePrice.Text = num.ToString();
                this.txtTotalAIT.Text = num2.ToString();
                this.txtTotalVAT.Text = num1.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void GetUnitName(int unitID)
        {
            DataTable allUnitByUnitID = (new AddItemBLL()).getAllUnitByUnitID(unitID);
            if (allUnitByUnitID.Rows.Count > 0)
            {
                this.drpUnit.DataSource = allUnitByUnitID;
                this.drpUnit.DataTextField = allUnitByUnitID.Columns["unit_code"].ToString();
                this.drpUnit.DataValueField = allUnitByUnitID.Columns["unit_id"].ToString();
                this.drpUnit.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpUnit.Items.Insert(0, listItem);
                this.drpUnit.SelectedValue = unitID.ToString();
            }
        }

        protected void gvApprvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ItemID"]);
                int num1 = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ChallanID"]);
                this.ViewState["selctedRowNo"] = 1;
                ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LISTA"];
                int num2 = 0;
                while (num2 < item.Count)
                {
                    PurchaseDetailDAO purchaseDetailDAO = (PurchaseDetailDAO)item[num2];
                    if (purchaseDetailDAO.ItemID != num || purchaseDetailDAO.ChallanID != num1)
                    {
                        num2++;
                    }
                    else
                    {
                        this.ShowDetailDataForEdit(purchaseDetailDAO);
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvExcelFile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvItem_PreRender(object sender, EventArgs e)
        {
        }

        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                ((ImageButton)e.Row.Cells[31].Controls[0]).Attributes["onclick"] = "if(!confirm('Do you want to delete?'))return   false;";
            }
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"];
                item.RemoveAt(e.RowIndex);
                this.Session["PURCHASE_DETAIL_LIST"] = item;
                this.AddDetailDataInGrid();
                this.GetTotalSaleValue();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                short num = Convert.ToInt16(this.gvItem.SelectedDataKey["RowNo"]);
                this.ViewState["selctedRowNo"] = num;
                ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"];
                int num1 = 0;
                while (num1 < item.Count)
                {
                    PurchaseDetailDAO purchaseDetailDAO = (PurchaseDetailDAO)item[num1];
                    if (purchaseDetailDAO.RowNo != num)
                    {
                        num1++;
                    }
                    else
                    {
                        this.ShowDetailDataForEdit(purchaseDetailDAO);
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvVoucher_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
        }

        private void insertBalance()
        {
            CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
            string str = this.Session["ORGANIZATION_ID"].ToString();
            string str1 = this.Session["VAT_LAST_AMOUNT"].ToString();
            string str2 = this.Session["SD_LAST_AMOUNT"].ToString();
            string str3 = this.Session["EMPLOYEE_ID"].ToString();
            DateTime now = DateTime.Now;
            DateTime formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY(now.ToString("dd/MM/yyyy"));
            currentAccountBLL.InsertBalance(Convert.ToInt32(str), Convert.ToDecimal(str1), Convert.ToDecimal(str2), Convert.ToInt32(str3), formattedDateMMDDYYYY);
            this.Session["VAT_LAST_AMOUNT"] = null;
            this.Session["SD_LAST_AMOUNT"] = null;
        }

        private void LoadCategory()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (this.drpSubCategory.SelectedValue != "" && this.drpSubCategory.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                    dataTable = this.dbLL.GetCategoryBySubCategoryID(num);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpCategory.SelectedValue = dataTable.Rows[0]["category_id"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        private ArrayList LoadDetailsData()
        {
            ArrayList arrayLists = new ArrayList();
            try
            {
                if (this.gvVoucher.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvVoucher.Rows.Count; i++)
                    {
                        HiddenField hiddenField = (HiddenField)this.gvVoucher.Rows[i].FindControl("ItemID");
                        HiddenField hiddenField1 = (HiddenField)this.gvVoucher.Rows[i].FindControl("UnitID");
                        Label label = (Label)this.gvVoucher.Rows[i].FindControl("ItemName");
                        Label label1 = (Label)this.gvVoucher.Rows[i].FindControl("UnitName");
                        TextBox textBox = (TextBox)this.gvVoucher.Rows[i].FindControl("txtgvQuantity");
                        TextBox textBox1 = (TextBox)this.gvVoucher.Rows[i].FindControl("txtgvPrevRate");
                        TextBox textBox2 = (TextBox)this.gvVoucher.Rows[i].FindControl("txtgvCurrentRate");
                        TextBox textBox3 = (TextBox)this.gvVoucher.Rows[i].FindControl("txtgvDisAmount");
                        TextBox textBox4 = (TextBox)this.gvVoucher.Rows[i].FindControl("txtgvTax");
                        TextBox textBox5 = (TextBox)this.gvVoucher.Rows[i].FindControl("txtgvAmount");
                        TextBox textBox6 = (TextBox)this.gvVoucher.Rows[i].FindControl("txtgvDifference");
                        PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO()
                        {
                            RowNo = Convert.ToInt16(i + 1),
                            ItemID = Convert.ToInt32(hiddenField.Value),
                            ItemName = label.Text.ToString(),
                            UnitID = Convert.ToInt32(hiddenField1.Value),
                            UnitName = label1.Text.ToString(),
                            Quantity = Convert.ToDouble(textBox.Text.ToString()),
                            UnitPriceBDT = Convert.ToDouble(textBox1.Text.ToString()),
                            PurchaseUnitPrice = Convert.ToDouble(textBox2.Text.ToString()),
                            Discount = Convert.ToDouble(textBox3.Text.ToString()),
                            PurchaseVAT = Convert.ToDouble(textBox4.Text.ToString()),
                            Total_Price = Convert.ToDouble(textBox5.Text.ToString()),
                            UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]),
                            Difference = textBox6.Text.ToString()
                        };
                        arrayLists.Add(purchaseDetailDAO);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return arrayLists;
        }

        private void LoadHours()
        {
            this.drpChDtHr.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
                this.drpRefChDtHr.Items.Add(i.ToString("00"));
            }
        }

        private void LoadItems()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO();
                if (this.drpCategory.SelectedValue == "ALL" && this.drpSubCategory.SelectedValue == "-99")
                {
                    setItemDAO.CategoryID = 0;
                }
                else if (this.drpCategory.SelectedValue != "ALL" && this.drpSubCategory.SelectedValue == "-99")
                {
                    setItemDAO.CategoryID = Convert.ToInt32(this.drpCategory.SelectedValue);
                }
                else if (this.drpCategory.SelectedValue != "ALL" && this.drpSubCategory.SelectedValue != "-99")
                {
                    setItemDAO.SubCatgID = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                }
                setItemDAO.CatagoryTyp = this.drpType.SelectedValue;
                DataTable allItemByCategoryOrSubCat = addItemBLL.GetAllItemByCategoryOrSubCat(setItemDAO);
                this.drpItem.DataSource = allItemByCategoryOrSubCat;
                this.drpItem.DataTextField = allItemByCategoryOrSubCat.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = allItemByCategoryOrSubCat.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                this.Session["ITEM_INFO"] = allItemByCategoryOrSubCat;
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpItem.Items.Insert(0, listItem);
                for (int i = 0; i < this.drpPropertyCollection.Count; i++)
                {
                    this.drpPropertyCollection[i].SelectedIndex = 0;
                    this.drpPropertyCollection[i].Enabled = false;
                }
                this.txtPurchaseUnitPrice.Text = "";
                this.lblPurchaseUnitPrice.Text = "0.00";
                this.lblPurchaseSD.Text = "0.00";
                this.lblPurchaseVAT.Text = "0.00";
                this.lblPurchaseAIT.Text = "0.00";
                this.drpItem.Focus();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadItemsByCatgSubCatg()
        {
            try
            {
                this.drpItem.Items.Clear();
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO()
                {
                    CategoryID = (Convert.ToInt32(this.drpCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpCategory.SelectedValue) : 0),
                    SubCatgID = (Convert.ToInt32(this.drpSubCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpSubCategory.SelectedValue) : 0)
                };
                DataTable allItemByCategoryOrSubCat = addItemBLL.GetAllItemByCategoryOrSubCat(setItemDAO);
                if (allItemByCategoryOrSubCat != null && allItemByCategoryOrSubCat.Rows.Count > 0)
                {
                    this.drpItem.DataSource = allItemByCategoryOrSubCat;
                    this.drpItem.DataTextField = allItemByCategoryOrSubCat.Columns["ITEM_NAME"].ToString();
                    this.drpItem.DataValueField = allItemByCategoryOrSubCat.Columns["ITEM_ID"].ToString();
                    this.drpItem.DataBind();
                }
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadMinutes()
        {
            this.drpChDtMin.Items.Add("00");
            for (int i = 1; i <= 59; i++)
            {
                this.drpChDtMin.Items.Add(i.ToString("00"));
                this.drpRefChDtMin.Items.Add(i.ToString("00"));
            }
        }

        private void LoadPurchaseData()
        {
            DataTable dataTable = new DataTable();
            ChallanBLL challanBLL = new ChallanBLL();
            int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
            if (challanBLL.GetApproverStage().Rows.Count >= 1)
            {
                this.btnUpdateTransaction.Visible = true;
                ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LISTA"] ?? new ArrayList();
                DataTable purchase = this.objBLL.getPurchase();
                if (purchase.Rows.Count > 0)
                {
                    for (int i = 0; i < purchase.Rows.Count; i++)
                    {
                        PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO()
                        {
                            ChallanID = Convert.ToInt32(purchase.Rows[i]["challan_id"])
                        };
                        string approveStagebyChallanId = this.getApproveStagebyChallanId(purchaseDetailDAO.ChallanID);
                        dataTable = (approveStagebyChallanId != "F" ? challanBLL.GetApproverStagebyEmployeeId(num, approveStagebyChallanId) : challanBLL.GetApproverStagebyEmployeeId(num, "4"));
                        if (dataTable.Rows.Count >= 1)
                        {
                            purchaseDetailDAO.ItemID = Convert.ToInt32(purchase.Rows[i]["item_id"]);
                            purchaseDetailDAO.ItemName = purchase.Rows[i]["item_name"].ToString();
                            purchaseDetailDAO.Quantity = Convert.ToDouble(purchase.Rows[i]["quantity"]);
                            purchaseDetailDAO.TempQuantity = Convert.ToDouble(purchase.Rows[i]["quantity"]);
                            purchaseDetailDAO.UnitID = Convert.ToInt32(purchase.Rows[i]["unit_id"]);
                            purchaseDetailDAO.PurchaseUnitPrice = Convert.ToDouble(purchase.Rows[i]["purchase_unit_price"]);
                            purchaseDetailDAO.UnitPriceBDT = Convert.ToDouble(purchase.Rows[i]["purchase_unit_price"]);
                            purchaseDetailDAO.TempUnitPrice = Convert.ToDouble(purchase.Rows[i]["purchase_unit_price"]);
                            purchaseDetailDAO.PurchaseVAT = Convert.ToDouble(purchase.Rows[i]["purchase_vat"]);
                            purchaseDetailDAO.PurchaseSD = Convert.ToDouble(purchase.Rows[i]["purchase_sd"]);
                            purchaseDetailDAO.AIT_Amount = Convert.ToDouble(purchase.Rows[i]["ait"]);
                            purchaseDetailDAO.SaleUnitPrice = Convert.ToDouble(purchase.Rows[i]["sale_unit_price"]);
                            purchaseDetailDAO.UnitSalePriceBDT = Convert.ToDouble(purchase.Rows[i]["sale_unit_price"]);
                            purchaseDetailDAO.SaleVAT = Convert.ToDouble(purchase.Rows[i]["sale_vat"]);
                            purchaseDetailDAO.SaleSD = Convert.ToDouble(purchase.Rows[i]["sale_sd"]);
                            purchaseDetailDAO.SaleVatablePrice = Convert.ToDouble(purchase.Rows[i]["sale_vatable_price"]);
                            purchaseDetailDAO.VDSAmount = Convert.ToDouble(purchase.Rows[i]["vds_amount"]);
                            purchaseDetailDAO.VAT = Convert.ToDouble(purchase.Rows[i]["purchase_vat"]);
                            purchaseDetailDAO.IsSrcTAXDeduct = Convert.ToBoolean(purchase.Rows[i]["is_source_tax_deduct"]);
                            purchaseDetailDAO.IsCurrentMonthRebate = Convert.ToBoolean(purchase.Rows[i]["is_current_month_rebate"]);
                            purchaseDetailDAO.UserIdInsert = Convert.ToInt16(this.Session["employee_id"]);
                            purchaseDetailDAO.TotalPrice = Convert.ToDouble(purchase.Rows[i]["quantity"]) * Convert.ToDouble(purchase.Rows[i]["purchase_unit_price"]) + Convert.ToDouble(purchase.Rows[i]["purchase_sd"]);
                            purchaseDetailDAO.TotalPurchasePrice = purchaseDetailDAO.TotalPrice + purchaseDetailDAO.VAT;
                            if (this.hdPriceID.Value != "")
                            {
                                purchaseDetailDAO.PriceId = Convert.ToInt16(this.hdPriceID.Value);
                            }
                            purchaseDetailDAO.SDRate = Convert.ToDouble(purchase.Rows[i]["sd_rate"]);
                            purchaseDetailDAO.VATRate = Convert.ToDouble(purchase.Rows[i]["vat_rate"]);
                            purchaseDetailDAO.RemarksDetail = purchase.Rows[i]["remarks"].ToString();
                            purchaseDetailDAO.IsRebatable = Convert.ToBoolean(purchase.Rows[i]["is_rebatable"]);
                            purchaseDetailDAO.IsExempted = Convert.ToBoolean(purchase.Rows[i]["is_exempted"]);
                            purchaseDetailDAO.IsDeemedExport = Convert.ToBoolean(purchase.Rows[i]["is_deemedexport"]);
                            if (!Convert.ToBoolean(purchase.Rows[i]["is_source_tax_deduct"]))
                            {
                                purchaseDetailDAO.SrcTAXDeduct = "No";
                            }
                            else
                            {
                                purchaseDetailDAO.SrcTAXDeduct = "Yes";
                            }
                            if (!Convert.ToBoolean(purchase.Rows[i]["is_exempted"]))
                            {
                                purchaseDetailDAO.Exempted = "No";
                            }
                            else
                            {
                                purchaseDetailDAO.Exempted = "Yes";
                            }
                            if (!Convert.ToBoolean(purchase.Rows[i]["is_deemedexport"]))
                            {
                                purchaseDetailDAO.DeemedExport = "No";
                            }
                            else
                            {
                                purchaseDetailDAO.DeemedExport = "Yes";
                            }
                            if (!Convert.ToBoolean(purchase.Rows[i]["is_rebatable"]))
                            {
                                purchaseDetailDAO.Rebatable = "No";
                            }
                            else
                            {
                                purchaseDetailDAO.Rebatable = "Yes";
                            }
                            if (!this.chkIsFixed.Checked)
                            {
                                purchaseDetailDAO.IsFixed = false;
                                purchaseDetailDAO.Fixed = "No";
                            }
                            else
                            {
                                purchaseDetailDAO.IsFixed = true;
                                purchaseDetailDAO.Fixed = "Yes";
                            }
                            if (this.HiddenIsTruncated.Value != "is_truncated")
                            {
                                purchaseDetailDAO.Truncated = "No";
                                purchaseDetailDAO.IsTruncated = false;
                            }
                            else
                            {
                                purchaseDetailDAO.IsTruncated = true;
                                purchaseDetailDAO.Truncated = "Yes";
                            }
                            if (!this.chkZeroRate.Checked)
                            {
                                purchaseDetailDAO.ZeroRate = "No";
                                purchaseDetailDAO.IsZeroRate = false;
                            }
                            else
                            {
                                purchaseDetailDAO.IsZeroRate = true;
                                purchaseDetailDAO.ZeroRate = "Yes";
                            }
                            if (!this.chkMrp.Checked)
                            {
                                purchaseDetailDAO.Mrp = "No";
                                purchaseDetailDAO.IsMrp = false;
                            }
                            else
                            {
                                purchaseDetailDAO.IsMrp = true;
                                purchaseDetailDAO.Mrp = "Yes";
                            }
                            item.Add(purchaseDetailDAO);
                        }
                    }
                }
                this.Session["PURCHASE_DETAIL_LISTA"] = item;
                this.AddApproveDetailDataInGrid();
            }
        }

        private void LoadRelatedProperties()
        {
            if (!string.IsNullOrEmpty(this.drpItem.SelectedValue))
            {
                Convert.ToInt32(this.drpItem.SelectedValue);
                ListItem listItem = new ListItem("-- Select --", "-99");
            }
        }

        private void LoadSubCategory()
        {
            try
            {
                this.drpSubCategory.DataSource = null;
                this.drpSubCategory.Items.Clear();
                this.drpSubCategory.Enabled = true;
                if (this.drpCategory.SelectedValue != "" && this.drpCategory.SelectedValue != "-99")
                {
                    UtilityK.fillSubCategoryByCatDropDownList(this.drpCategory, this.drpSubCategory);
                    if (this.drpSubCategory.Items.Count != 0)
                    {
                        this.drpSubCategory.Focus();
                    }
                    else
                    {
                        this.drpSubCategory.Enabled = false;
                        this.drpItem.Focus();
                    }
                }
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
            }
        }

        private bool MasterValidation()
        {
            if (this.drpRegType.SelectedValue == "0")
            {
               // this.msgBox.AddMessage("Registration type must be selected", MsgBoxs.enmMessageType.Attention);
               // return false;

                string smg = "Registration type must be selected!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + smg + "')", true);
                return false;


            }
            if (this.drpParty.Enabled && this.drpParty.SelectedValue == "-99")
            {
                // this.msgBox.AddMessage("Please select a party", MsgBoxs.enmMessageType.Attention);
                // return false;
                string smg = "Please select a party!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + smg + "')", true);
                return false;
            }
            if (this.txtChallanNo.Text.Length == 0)
            {
                // this.msgBox.AddMessage("Please insert challan no.", MsgBoxs.enmMessageType.Attention);
                // this.txtChallanNo.Focus();
                // return false;

                this.txtChallanNo.Focus();
                string smg = "Please insert challan no.!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + smg + "')", true);
                return false;

            }
            if (this.txtChallanDate.Text.Length == 0)
            {
                return false;
            }

            Boolean paymnetflag = false;
            if (this.chkCash.Checked && this.txtCashAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }
            if (this.chkBkash.Checked && this.txtbKashAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }
            if (this.chkRocket.Checked && this.txtRocketAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }
            if (this.chkCheque.Checked && this.txtChequeAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }
            if (this.chkTT.Checked && this.txtTPTAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }
            if (this.chkEFT.Checked && this.txtEFTAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }
            if (this.CheDebitCard.Checked && this.txtDebitCartAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }
            if (this.chkPayOrder.Checked && this.txtPayOrderAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }

            if (this.ChkOther.Checked && this.txtOthersAmount.Text.Trim() != "")
            {
                paymnetflag = true;
            }

            if (paymnetflag==false)
            {
               // this.msgBox.AddMessage("Please Payment First.", MsgBoxs.enmMessageType.Attention);


                string smg = "Please Payment First.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "erroralert('" + smg + "')", true);
               // return false;


                this.txtChallanNo.Focus();
                return false;
            }
            else
            {
                return true;
            }










            //this.lblMessage.Text = "Insert Challan Date.";
            //this.txtChallanDate.Focus();
            return false;
        }

        protected void OKButton_Click(object sender, EventArgs e)
        {
            if (this.chkCheque.Checked && this.txt_transaction_id.Text == "")
            {
                this.lbl_transaction_id.Attributes.Add("style", "display:block");
                this.txt_transaction_id.Attributes.Add("style", "display:block");
                this.mpe.Show();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            try
            {
                if (!base.IsPostBack)
                {
                    this.btnUpdateTransaction.Visible = false;
                    this.Page.Form.Attributes.Add("enctype", "multipart/form-data");
                    this.Session["PURCHASE_DETAIL_LIST"] = new ArrayList();
                    this.Session["PURCHASE_DETAIL_LIST_MQMM"] = new ArrayList();
                    this.Session["PARTY_INFO"] = new DataTable();
                    this.Session["ITEM_INFO"] = new DataTable();
                    this.Session["Purchase_EXCEL"] = new ArrayList();
                    this.Session["Purchase_Master_LIST"] = new ArrayList();
                    this.part_a.Visible = true;
                    this.part_b.Visible = true;
                    this.part_c.Visible = true;
                    this.part_d.Visible = true;
                    this.part_e.Visible = false;
                    this.part_v.Visible = false;
                    this.partVDS.Visible = false;
                    this.Session["PURCHASE_DETAIL_LISTA"] = new ArrayList();
                    this.LoadPurchaseData();
                    this.lblOrgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    TextBox str = this.txtChallanDate;
                    DateTime now = DateTime.UtcNow.AddHours(+6);
                    str.Text = now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    TextBox textBox = this.txtrefChallanDate;
                    DateTime dateTime = DateTime.UtcNow.AddHours(+6);
                    textBox.Text = dateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SetSystemUsedProperties();
                    this.lblOrgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                    UtilityK.fillVehicleTypeDropDownList(this.drpVehicleType);
                    this.GetPartyInfo();
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    ListItem listItem1 = new ListItem("-- Select --", "-99");
                    this.drpVehicleType.Items.Insert(0, listItem1);
                    ListItem listItem2 = new ListItem("-- Select --", "-99");
                    this.drpCategory.Items.Insert(0, listItem2);
                    this.drpSubCategory.Items.Insert(0, listItem1);
                    ListItem listItem3 = new ListItem("-- Select --", "-99");
                    this.drpItem.Items.Insert(0, listItem3);
                    ListItem listItem4 = new ListItem("-- Select --", "-99");
                    this.LoadHours();
                    this.LoadMinutes();
                    this.LoadItems();
                    this.orgVDS.Text = this.Session["VAT_DEDUCT"].ToString();
                    this.drpRefChDtHr.SelectedValue = DateTime.UtcNow.AddHours(+6).Hour.ToString("00");
                    this.drpRefChDtMin.SelectedValue = DateTime.UtcNow.AddHours(+6).Minute.ToString("00");
                    this.drpChDtHr.SelectedValue = DateTime.UtcNow.AddHours(+6).Hour.ToString("00");
                    this.drpChDtMin.SelectedValue = DateTime.UtcNow.AddHours(+6).Minute.ToString("00");
                    this.GetBranchInformation();
                    this.GetGRNVoucher();
                    base.Request.RawUrl.ToString();
                    string str1 = this.Session["ORGANIZATION_ID"].ToString();
                    string str2 = this.Session["ORGBRANCHID"].ToString();
                    DataTable dataTable = this.permissionBLL.CheckPaymentMethodPermision(str1, str2, "/UI/Purchase/LocalPurchase.aspx");
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.showPermittedPaymentMethods(dataTable);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void Part()
        {
            if (this.chkSaleValue.Checked)
            {
                this.lblSaleUnitPrice.Visible = true;
                this.txtSaleUnitPrice.Visible = true;
                this.lblSaleVatablePrice.Visible = true;
                this.txtSaleVatablePrice.Visible = true;
                this.lblSalesVat.Visible = true;
                this.txtSaleVat.Visible = true;
                this.lblSaleVat.Visible = true;
                this.lblVatPercent.Visible = true;
                this.lblSalesSD.Visible = true;
                this.txtSaleSD.Visible = true;
                this.lblSaleSD.Visible = true;
                this.lblSDPercent.Visible = true;
                this.lblAIT.Visible = true;
                this.txtAIT.Visible = true;
                this.lbelAIT.Visible = true;
                this.lblAITPct.Visible = true;
                return;
            }
            this.lblSaleUnitPrice.Visible = false;
            this.txtSaleUnitPrice.Visible = false;
            this.lblSaleVatablePrice.Visible = false;
            this.txtSaleVatablePrice.Visible = false;
            this.lblSalesVat.Visible = false;
            this.txtSaleVat.Visible = false;
            this.lblSaleVat.Visible = false;
            this.lblVatPercent.Visible = false;
            this.lblSalesSD.Visible = false;
            this.txtSaleSD.Visible = false;
            this.lblSaleSD.Visible = false;
            this.lblSDPercent.Visible = false;
            this.lblAIT.Visible = false;
            this.txtAIT.Visible = false;
            this.lbelAIT.Visible = false;
            this.lblAITPct.Visible = false;
        }

        protected void payment_CheckedChanged(object sender, EventArgs e)
        {
            this.mpe.Show();
            if (!this.chkBkash.Checked && !this.chkRocket.Checked && !this.chkPayOrder.Checked && !this.chkCheque.Checked && !this.chkTT.Checked && !this.chkEFT.Checked && !this.CheDebitCard.Checked)
            {
                bool @checked = this.ChkOther.Checked;
            }
        }

        protected void productName_TextChanged(object sender, EventArgs e)
        {
            this.getProductInfo();
        }

        private void SDLastUpdatedBalance()
        {
            CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
            decimal num = new decimal(0);
            DateTime today = DateTime.Today;
            DateTime formattedDateMMDDYYYY = DateTime.Today;
            string str = this.Session["ORGANIZATION_ID"].ToString();
            today =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
            formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
            DataTable currentAccount18ReportBySearchSD = currentAccountBLL.GetCurrentAccount18ReportBySearchSD(today, formattedDateMMDDYYYY, Convert.ToInt16(str));
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("date_challan");
            dataTable.Columns.Add("trns_desc");
            dataTable.Columns.Add("challan_no");
            dataTable.Columns.Add("treasury_deposit");
            dataTable.Columns.Add("exempt_amount");
            dataTable.Columns.Add("others", typeof(decimal));
            dataTable.Columns.Add("pay_amount", typeof(decimal));
            dataTable.Columns.Add("balance_amount", typeof(decimal));
            dataTable.Columns.Add("balance_action");
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                dataTable = currentAccount18ReportBySearchSD;
                dataTable = this.getNewDataTableWithBalance(dataTable);
            }
            else
            {
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "date_challan ASC";
                dataTable = this.getNewDataTableWithBalance(defaultView.ToTable());
            }
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                DataTable dataTable1 = new DataTable();
                dataTable1.Columns.Add("date_challan");
                dataTable1.Columns.Add("trns_desc");
                dataTable1.Columns.Add("challan_no");
                dataTable1.Columns.Add("treasury_deposit");
                dataTable1.Columns.Add("exempt_amount");
                dataTable1.Columns.Add("others", typeof(decimal));
                dataTable1.Columns.Add("pay_amount", typeof(decimal));
                dataTable1.Columns.Add("balance_amount", typeof(decimal));
                dataTable1.Columns.Add("balance_action");
                DataRow item = dataTable.Rows[dataTable.Rows.Count - 1];
                if (item != null)
                {
                    dataTable1.ImportRow(item);
                    num = new decimal(0);
                    if (dataTable1.Rows[0]["balance_amount"] != null)
                    {
                        num = Convert.ToDecimal(dataTable1.Rows[0]["balance_amount"].ToString());
                        this.Session["SD_LAST_AMOUNT"] = num.ToString("0.00");
                    }
                }
            }
        }

        private void SetAddMode()
        {
            this.btnSave.Text = LocalPurchase.enmBtnText.Save.ToString();
        }

        private void setDetaiAddMode()
        {
            this.btnAdd.Text = "Add Item";
        }

        private void setDetailUpdateMode()
        {
            this.btnAdd.Text = LocalPurchase.enmBtnText.Update.ToString();
        }

        private void setMainAddMode()
        {
            this.btnSave.Text = LocalPurchase.enmBtnText.Save.ToString();
            this.btnClear.Text = LocalPurchase.enmBtnText.Clear.ToString();
        }

        private void setMainUpdateMode()
        {
            this.btnSave.Text = LocalPurchase.enmBtnText.Update.ToString();
            this.btnClear.Text = LocalPurchase.enmBtnText.Cancel.ToString();
        }

        private void SetSystemUsedProperties()
        {
            try
            {
                SetItemPropertyBLL setItemPropertyBLL = new SetItemPropertyBLL();
                DataTable dataTable = new DataTable();
                dataTable = setItemPropertyBLL.GetSystemUsedProperty();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dataTable.Rows[i]["IS_USED_BY_SYSTEM"]) != 1)
                        {
                            this.lblPropertyCollection[i].Visible = false;
                            this.drpPropertyCollection[i].Visible = false;
                        }
                        else
                        {
                            this.lblPropertyCollection[i].Text = string.Concat(dataTable.Rows[i]["PROPERTY_TYPE_NAME"].ToString(), ":");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void ShowDetailDataForEdit(PurchaseDetailDAO objDetailDAO)
        {
            if (objDetailDAO.CatID > 0)
            {
                this.drpCategory.SelectedValue = objDetailDAO.CatID.ToString();
            }
            this.LoadSubCategory();
            if (objDetailDAO.SubCatID <= 0)
            {
                this.drpSubCategory.SelectedValue = "-99";
            }
            else
            {
                this.drpSubCategory.SelectedValue = objDetailDAO.SubCatID.ToString();
            }
            this.LoadItems();
            this.drpItem.SelectedValue = objDetailDAO.ItemID.ToString();
            this.lblHSCode.Text = objDetailDAO.HSCode;
            this.EnableOrDisablePropertyForItemGridEdit();
            this.txtQuantity.Text = objDetailDAO.Quantity.ToString();
            this.drpUnit.SelectedValue = objDetailDAO.UnitID.ToString();
            this.lblUID.Text = objDetailDAO.UnitID.ToString();
            this.txtPurchaseUnitPrice.Text = objDetailDAO.PurchaseUnitPrice.ToString();
            this.lblTotalSD.Text = objDetailDAO.SD.ToString();
            this.lblTotalVAT.Text = objDetailDAO.VAT.ToString();
            this.txtPurchaseVAT.Text = objDetailDAO.PurchaseVAT.ToString();
            this.txtPurchaseSD.Text = objDetailDAO.PurchaseSD.ToString();
            this.txtTotalPrice.Text = objDetailDAO.TotalPrice.ToString();
            this.txtPriceIncludingVat.Text = objDetailDAO.TotalPurchasePrice.ToString();
            Label str = this.lblTotalPrice;
            double quantity = objDetailDAO.Quantity * objDetailDAO.UnitPriceBDT;
            str.Text = quantity.ToString("N2");
            this.lblPurchaseVAT.Text = objDetailDAO.VATRate.ToString("N2");
            this.lblTotalPurchasePrc.Text = objDetailDAO.TotalPrice.ToString("N2");
            this.chkTaxDeducted.Checked = objDetailDAO.IsSrcTAXDeduct;
            this.hdItemType.Value = objDetailDAO.ItemType;
            this.chkRebatable.Checked = objDetailDAO.IsRebatable;
            HiddenField hiddenField = this.hdIsExempted;
            short num = Convert.ToInt16(objDetailDAO.IsExempted);
            hiddenField.Value = num.ToString();
            this.setDetailUpdateMode();
        }

        private void showPermittedPaymentMethods(DataTable permissions)
        {
            for (int i = 0; i < permissions.Rows.Count; i++)
            {
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Cash")
                {
                    this.chkCash.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Credit")
                {
                    this.chkCredit.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Cheque")
                {
                    this.chkCheque.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Rocket")
                {
                    this.chkRocket.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "bKash")
                {
                    this.chkBkash.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Credit Card" || permissions.Rows[i]["payment_method_name"].ToString() == "Debit Card")
                {
                    this.CheDebitCard.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Pay Order")
                {
                    this.chkPayOrder.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Electronic Fund Transfer")
                {
                    this.chkEFT.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Telephone Transfer")
                {
                    this.chkTT.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Other")
                {
                    this.ChkOther.Visible = true;
                }
            }
        }

        protected void txtChallanDate_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtDeliveryDate_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtPriceIncludingVat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                if (this.Label25.Text != " Per Unit.")
                {
                    num1 = Convert.ToDouble(this.lblPurchaseVAT.Text.Trim());
                    num = Convert.ToDouble(this.lblPurchaseSD.Text.Trim());
                    if (this.txtQuantity.Text != string.Empty)
                    {
                        num6 = Convert.ToDouble(this.txtQuantity.Text.Trim());
                    }
                    else
                    {
                        this.txtQuantity.Text = 1.ToString();
                        num6 = 1;
                    }
                    if (num1 > 0)
                    {
                        num2 = Convert.ToDouble(this.txtPriceIncludingVat.Text.Trim());
                        num3 = num2 * num1 / (num1 + 100);
                        num5 = num2 - num3;
                        if (num > 0)
                        {
                            num4 = num5 * num / (num + 100);
                        }
                        this.txtPurchaseVAT.Text = num3.ToString("0.00");
                        this.txtPurchaseSD.Text = num4.ToString("0.00");
                        if (num6 != 0)
                        {
                            num7 = num2 * 100 * 100 / ((100 + num1) * (100 + num));
                            this.txtTotalPrice.Text = num7.ToString("0.00");
                            this.txtPurchaseUnitPrice.Text = (num7 / num6).ToString();
                        }
                    }
                    this.GetTotalPurchasePriceIncldingVatChange();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetTotalPurchasePriceQtyChange();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtSaleUnitPrice_TextChanged(object sender, EventArgs e)
        {
            double num;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            try
            {
                num = (this.txtSaleUnitPrice.Text.Length <= 0 || Convert.ToDouble(this.txtSaleUnitPrice.Text) <= 0 ? 0 : Convert.ToDouble(this.txtSaleUnitPrice.Text));
                if (this.txtSaleSD.Text == "" || Convert.ToDouble(this.txtSaleUnitPrice.Text) == 0)
                {
                    this.txtSaleSD.Text = "0.00";
                }
                double num4 = 1 * num;
                num2 = Convert.ToDouble(this.lblSaleSD.Text);
                double num5 = num4 * num2 / 100;
                this.txtSaleSD.Text = num5.ToString("0.00");
                num1 = Convert.ToDouble(this.lblSaleVat.Text);
                num3 = (num4 + num5) * num1 / 100;
                this.txtSaleVat.Text = num3.ToString("0.00");
                double num6 = 0;
                num6 = Convert.ToDouble(this.lbelAIT.Text);
                TextBox str = this.txtAIT;
                double num7 = num6 * num / 100;
                str.Text = num7.ToString("0.00");
                double num8 = num4 + num3 + num5;
                this.txtSaleVatablePrice.Text = num8.ToString("0.00");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void txtTotalPurchsPrc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalculatePriceReverse();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblPriceDiff.Text = "";
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                int num3 = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable purchaseUnitPrice = this.objBLL.getPurchaseUnitPrice(num3);
                if (purchaseUnitPrice.Rows.Count <= 0)
                {
                    this.lblPriceDiff.Text = "";
                }
                else
                {
                    num1 = Convert.ToDecimal(this.txtPurchaseUnitPrice.Text);
                    num = Convert.ToDecimal(purchaseUnitPrice.Rows[0]["purchase_unit_price"]);
                    num2 = ((num1 - num) * new decimal(100)) / num;
                   // this.msgBox.AddMessage(string.Concat("Unit Price Difference is ", num2.ToString("0.00"), "%"), MsgBoxs.enmMessageType.Attention);
                }
                this.GetTotalPurchasePriceUnitPriceChange();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtVatablePrice_TextChanged(object sender, EventArgs e)
        {
        }

        private bool Validation()
        {
            if (this.txtQuantity.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Quantity is mandatory", MsgBoxs.enmMessageType.Attention);
                this.txtQuantity.Focus();
                return false;
            }
            if (!this.chkReusable.Checked && (this.txtPurchaseUnitPrice.Text.Trim().Length < 1 || Convert.ToDouble(this.txtPurchaseUnitPrice.Text) <= 0))
            {
                this.msgBox.AddMessage("Unit Price is mandatory", MsgBoxs.enmMessageType.Attention);
                this.txtPurchaseUnitPrice.Focus();
                return false;
            }
            if (this.chkReusable.Checked && this.txtPurchaseUnitPrice.Text == "")
            {
                this.msgBox.AddMessage("Unit Price must be 0.", MsgBoxs.enmMessageType.Attention);
                this.txtPurchaseUnitPrice.Focus();
                return false;
            }
            if (this.drpItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select an item.", MsgBoxs.enmMessageType.Attention);
                this.drpItem.Focus();
                return false;
            }
            if (!this.chkExcel.Checked)
            {
                if (this.drpProperty1.Visible && this.drpProperty1.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty1.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (this.drpProperty2.Visible && this.drpProperty2.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty2.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (this.drpProperty3.Visible && this.drpProperty3.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty3.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (this.drpProperty4.Visible && this.drpProperty4.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty4.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (this.drpProperty5.Visible && this.drpProperty5.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty5.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    return false;
                }
            }
            ArrayList item = (ArrayList)this.Session["ProductionRcv_EXCEL"];
            if (item == null || item.Count <= 0 || item.Count == Convert.ToInt16(this.txtQuantity.Text))
            {
                return true;
            }
            this.msgBox.AddMessage("Quantity and No of Additional Property are not equal", MsgBoxs.enmMessageType.Attention);
            this.txtQuantity.Focus();
            return false;
        }

        private void VATLastUpdatedBalance()
        {
            CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
            decimal num = new decimal(0);
            DateTime today = DateTime.Today;
            DateTime formattedDateMMDDYYYY = DateTime.Today;
            string str = this.Session["ORGANIZATION_ID"].ToString();
            today =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
            formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
            DataTable currentAccount18ReportBySearchVAT = currentAccountBLL.GetCurrentAccount18ReportBySearchVAT(today, formattedDateMMDDYYYY, Convert.ToInt16(str));
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("date_challan");
            dataTable.Columns.Add("trns_desc");
            dataTable.Columns.Add("challan_no");
            dataTable.Columns.Add("treasury_deposit");
            dataTable.Columns.Add("exempt_amount");
            dataTable.Columns.Add("others", typeof(decimal));
            dataTable.Columns.Add("pay_amount", typeof(decimal));
            dataTable.Columns.Add("balance_amount", typeof(decimal));
            dataTable.Columns.Add("balance_action");
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                dataTable = currentAccount18ReportBySearchVAT;
                dataTable = this.getNewDataTableWithBalance(dataTable);
            }
            else
            {
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "date_challan ASC";
                dataTable = this.getNewDataTableWithBalance(defaultView.ToTable());
            }
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                DataTable dataTable1 = new DataTable();
                dataTable1.Columns.Add("date_challan");
                dataTable1.Columns.Add("trns_desc");
                dataTable1.Columns.Add("challan_no");
                dataTable1.Columns.Add("treasury_deposit");
                dataTable1.Columns.Add("exempt_amount");
                dataTable1.Columns.Add("others", typeof(decimal));
                dataTable1.Columns.Add("pay_amount", typeof(decimal));
                dataTable1.Columns.Add("balance_amount", typeof(decimal));
                dataTable1.Columns.Add("balance_action");
                DataRow item = dataTable.Rows[dataTable.Rows.Count - 1];
                if (item != null)
                {
                    dataTable1.ImportRow(item);
                    num = new decimal(0);
                    if (dataTable1.Rows[0]["balance_amount"] != null)
                    {
                        num = Convert.ToDecimal(dataTable1.Rows[0]["balance_amount"].ToString());
                        this.Session["VAT_LAST_AMOUNT"] = num.ToString("0.00");
                    }
                }
            }
        }

        private enum enmBtnText
        {
            Save,
            Update,
            Cancel,
            Clear
        }

        public static class WrittenNumerics
        {
            private readonly static string[] ones;

            private readonly static string[] teens;

            private readonly static string[] tens;

            private readonly static string[] thousandsGroups;

            static WrittenNumerics()
            {
                string[] strArrays = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
                LocalPurchase.WrittenNumerics.ones = strArrays;
                string[] strArrays1 = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                LocalPurchase.WrittenNumerics.teens = strArrays1;
                string[] strArrays2 = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                LocalPurchase.WrittenNumerics.tens = strArrays2;
                string[] strArrays3 = new string[] { "", " Thousand", " Million", " Billion" };
                LocalPurchase.WrittenNumerics.thousandsGroups = strArrays3;
            }

            public static string DateToWritten(DateTime date)
            {
                return string.Format("{0} {1} {2}", LocalPurchase.WrittenNumerics.IntegerToWritten(date.Day), date.ToString("MMMM"), LocalPurchase.WrittenNumerics.IntegerToWritten(date.Year));
            }

            private static string FriendlyInteger(int n, string leftDigits, int thousands)
            {
                if (n == 0)
                {
                    return leftDigits;
                }
                string str = leftDigits;
                if (str.Length > 0)
                {
                    str = string.Concat(str, " ");
                }
                if (n < 10)
                {
                    str = string.Concat(str, LocalPurchase.WrittenNumerics.ones[n]);
                }
                else if (n < 20)
                {
                    str = string.Concat(str, LocalPurchase.WrittenNumerics.teens[n - 10]);
                }
                else if (n >= 100)
                {
                    str = (n >= 1000 ? string.Concat(str, LocalPurchase.WrittenNumerics.FriendlyInteger(n % 1000, LocalPurchase.WrittenNumerics.FriendlyInteger(n / 1000, "", thousands + 1), 0)) : string.Concat(str, LocalPurchase.WrittenNumerics.FriendlyInteger(n % 100, string.Concat(LocalPurchase.WrittenNumerics.ones[n / 100], " Hundred"), 0)));
                }
                else
                {
                    str = string.Concat(str, LocalPurchase.WrittenNumerics.FriendlyInteger(n % 10, LocalPurchase.WrittenNumerics.tens[n / 10 - 2], 0));
                }
                return string.Concat(str, LocalPurchase.WrittenNumerics.thousandsGroups[thousands]);
            }

            public static string IntegerToWritten(int n)
            {
                if (n == 0)
                {
                    return "Zero";
                }
                if (n >= 0)
                {
                    return LocalPurchase.WrittenNumerics.FriendlyInteger(n, "", 0);
                }
                return string.Concat("Negative ", LocalPurchase.WrittenNumerics.IntegerToWritten(-n));
            }
        }
    }
}