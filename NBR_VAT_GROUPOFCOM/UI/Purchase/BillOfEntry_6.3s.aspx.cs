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
    public partial class BillOfEntry_6__3s : Page, IRequiresSessionState
    {

        private Collection<DropDownList> drpPropertyCollection = new Collection<DropDownList>();

        private Collection<Label> lblPropertyCollection = new Collection<Label>();

        private PurchaseDetailDAO objDetailDAO;

        private ItemBLL bll = new ItemBLL();

        private UserPermissionBLL permissionBLL = new UserPermissionBLL();

        public ArrayList objectPropertyNameList = new ArrayList();

        public ArrayList tableDataList = new ArrayList();

        public ArrayList tableNameList = new ArrayList();

        public ArrayList validationList = new ArrayList();

        public short status = 1;

        private SaleBLL objSBLL = new SaleBLL();

        private ChallanBLL objBLL = new ChallanBLL();

        private AddItemBLL dbLL = new AddItemBLL();

        private SetBankBLL objSetBankBLL = new SetBankBLL();

      
      //  protected MsgBoxs MsgBoxs;

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

        //public BillOfEntry_6_3s()
        //{
        //}

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
            ArrayList item = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"];
            this.gvItem.DataSource = item;
            this.gvItem.DataBind();
        }

        private void AddTempData()
        {
            ArrayList item = (ArrayList)this.Session["TEMP"];
            this.gvItem.DataSource = item;
            this.gvItem.DataBind();
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                string empty = string.Empty;
                if (this.Validation())
                {
                    if (this.chkRebatable.Checked)
                    {
                        this.fillDetailProperties();
                        this.AddDetailDataInGrid();
                        this.ClearDetailControlsValue();
                        this.productName.Focus();
                    }
                    else if (this.chkrbt.Text != "Yes")
                    {
                        this.fillDetailProperties();
                        this.AddDetailDataInGrid();
                        this.ClearDetailControlsValue();
                        this.productName.Focus();
                    }
                    else
                    {
                        this.lblRebatable.Attributes["style"] = "color:red; font-weight:bold;";
                        this.chkRebatable.Checked = true;
                        this.fillDetailProperties();
                        this.AddDetailDataInGrid();
                        this.ClearDetailControlsValue();
                    }
                    this.GetTotalSaleValue();
                    this.ClearCheckBox();
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "BillOfEntry_6.3", "btnAddItem_Click");
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPartyName.Visible)
                {
                    this.btnAddParty.Text = "New";
                    this.drpParty.Enabled = true;
                    this.txtPartyName.Visible = false;
                }
                else
                {
                    base.Response.Redirect("~/UI/Others/PartySetup.aspx");
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearDetailControlsValue();
            this.lblMessage.Text = "";
            this.setDetaiAddMode();
            this.txtTotalImportPrice.Text = "";
            ArrayList arrayLists = new ArrayList();
            this.Session["Bill_of_Entry_DETAIL_LIST"] = arrayLists;
            this.gvItem.DataSource = null;
            this.gvItem.DataBind();
        }

        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
        }

        protected void btnRefreshChallan_Click(object sender, EventArgs e)
        {
            this.RefreshForm();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            if (this.btnReport.Text != "Show Report")
            {
                this.boePrint.Visible = false;
                this.btnReport.Text = "Show Report";
                this.btnPrint.Visible = false;
                return;
            }
            this.showReportData();
            this.boePrint.Visible = true;
            this.btnReport.Text = "Hide Report";
            this.btnPrint.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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
                        item = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"];
                        if (item == null || item.Count == 0)
                        {
                            this.gvItem.DataSource = null;
                            this.gvItem.DataBind();
                            this.MsgBoxs.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else
                        {
                            bool flag = false;
                            if (this.btnSave.Text == enmBtnText.Save.ToString())
                            {
                                if (!this.chkExcel.Checked)
                                {
                                    flag = challanBLL.InsertBLEntryData(purchaseMasterDAO, item);
                                }
                                else
                                {
                                    arrayLists = (ArrayList)this.Session["ProductionRcv_EXCEL"];
                                    flag = challanBLL.InsertBLEntryDatawithAdditionalInfo(purchaseMasterDAO, item, arrayLists);
                                }
                                if (!flag)
                                {
                                    this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                                }
                                else
                                {
                                    if (purchaseMasterDAO.ChallanType == 'P')
                                    {
                                        this.MsgBoxs.AddMessage("Bill of Entry Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                    }
                                    this.itemId.Text = "";
                                    this.ClearAllControlsValue();
                                }
                            }
                        }
                    }
                    else
                    {
                        this.MsgBoxs.AddMessage("Please insert master data properly.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "Bill", "btnSave_Click");
            }
        }

        protected void btnUpdateTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = "";
                string str = "";
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"];
                if (arrayLists == null || arrayLists.Count == 0)
                {
                    this.gvItem.DataSource = null;
                    this.gvItem.DataBind();
                    this.MsgBoxs.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
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
                    if (!challanBLL.UpdateImportData(str, arrayLists, num))
                    {
                        this.MsgBoxs.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.MsgBoxs.AddMessage("Bill of Entry Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.itemId.Text = "";
                        this.ClearAllControlsValue();
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
                    this.MsgBoxs.AddMessage(" File Path not Found! Please Choose Your File. ", MsgBoxs.enmMessageType.Attention);
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
                        this.MsgBoxs.AddMessage(exception.Message, MsgBoxs.enmMessageType.Attention);
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

        private void CalculateTaxValues()
        {
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            if (this.drpItem.SelectedValue != "-99")
            {
                short num = Convert.ToInt16(this.drpItem.SelectedValue);
                DataTable itemUnitByItemId = (new ItemBLL()).getItemUnitByItemId(num);
                if (itemUnitByItemId != null)
                {
                    this.hfItemUnit.Value = itemUnitByItemId.Rows[0]["unit_code"].ToString();
                    flag = Convert.ToBoolean(itemUnitByItemId.Rows[0]["is_vds"].ToString());
                    flag1 = Convert.ToBoolean(itemUnitByItemId.Rows[0]["is_rebatable"].ToString());
                    flag2 = Convert.ToBoolean(itemUnitByItemId.Rows[0]["is_exempted"].ToString());
                    if (!flag)
                    {
                        this.lblvds.Visible = false;
                        this.chkTaxDeducted.Visible = false;
                        this.lblvdstx.Visible = false;
                        this.txtvdsamount.Visible = false;
                        this.lblvds.Attributes["style"] = "color:black;";
                    }
                    else
                    {
                        this.lblvds.Visible = true;
                        this.chkTaxDeducted.Visible = true;
                        this.chkTaxDeducted.Checked = true;
                        this.lblvdstx.Visible = true;
                        this.txtvdsamount.Visible = true;
                        this.lblvds.Attributes["style"] = "color:red;";
                    }
                    if (!flag1)
                    {
                        this.lblRebatable.Attributes["style"] = "color:black;";
                        this.chkRebatable.Checked = false;
                    }
                    else
                    {
                        this.lblRebatable.Attributes["style"] = "color:red;";
                        this.chkRebatable.Checked = true;
                    }
                    if (!flag2)
                    {
                        this.lblExempted.Visible = false;
                        this.chkExempted.Visible = false;
                        this.chkExempted.Checked = false;
                        this.lblExempted.Attributes["style"] = "color:black;";
                    }
                    else
                    {
                        this.lblExempted.Visible = true;
                        this.chkExempted.Visible = true;
                        this.chkExempted.Checked = true;
                        this.lblExempted.Attributes["style"] = "color:red;";
                    }
                }
                ItemTaxValueBLL itemTaxValueBLL = new ItemTaxValueBLL();
                DataTable taxValuesByItemIdAndTaxIdForImport = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 1);
                if (taxValuesByItemIdAndTaxIdForImport.Rows.Count == 0)
                {
                    this.chkCD.Checked = false;
                    this.lblCD.Text = "0.00";
                    this.cd.Attributes["style"] = "color:black;";
                    this.lblVCD.Visible = false;
                    this.txtCD.Visible = false;
                }
                else if (taxValuesByItemIdAndTaxIdForImport.Rows[0]["is_fixed_cd"].ToString() != "True")
                {
                    this.chkCD.Checked = true;
                    this.cd.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblCD.Text = taxValuesByItemIdAndTaxIdForImport.Rows[0]["tax_value"].ToString();
                    this.lblVCD.Visible = true;
                    this.txtCD.Visible = true;
                }
                else
                {
                    this.chkCD.Checked = true;
                    this.cd.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblCD.Text = taxValuesByItemIdAndTaxIdForImport.Rows[0]["tax_value"].ToString();
                    this.lblVCD.Visible = true;
                    this.txtCD.Visible = true;
                    this.lblFxdCD.Visible = true;
                    this.lblFxdCD.Text = "Fixed CD";
                    this.Label86.Visible = false;
                }
                DataTable dataTable = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 2);
                if (dataTable.Rows.Count == 0)
                {
                    this.chkRD.Checked = false;
                    this.lblRD.Text = "0.00";
                    this.rd.Attributes["style"] = "color:black;";
                    this.lblVRD.Visible = false;
                    this.txtRD.Visible = false;
                }
                else
                {
                    this.chkRD.Checked = true;
                    this.rd.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblRD.Text = dataTable.Rows[0]["tax_value"].ToString();
                    this.lblVRD.Visible = true;
                    this.txtRD.Visible = true;
                }
                DataTable taxValuesByItemIdAndTaxIdForImport1 = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 3);
                if (taxValuesByItemIdAndTaxIdForImport1.Rows.Count == 0)
                {
                    this.chkSD.Checked = false;
                    this.lblSD.Text = "0.00";
                    this.sd.Attributes["style"] = "color:black;";
                    this.lblVSD.Visible = false;
                    this.txtSD.Visible = false;
                }
                else
                {
                    this.chkSD.Checked = true;
                    this.sd.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblSD.Text = taxValuesByItemIdAndTaxIdForImport1.Rows[0]["tax_value"].ToString();
                    this.lblVSD.Visible = true;
                    this.txtSD.Visible = true;
                }
                DataTable dataTable1 = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 8);
                if (dataTable1.Rows.Count <= 0)
                {
                    this.chkAT.Checked = false;
                    this.lblAT.Text = "0.00";
                    this.AT.Attributes["style"] = "color:black;";
                    this.lblVaAT.Visible = false;
                    this.txtAT.Visible = false;
                }
                else
                {
                    this.chkAT.Checked = true;
                    this.AT.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblAT.Text = dataTable1.Rows[0]["tax_value"].ToString();
                    this.lblVaAT.Visible = true;
                    this.txtAT.Visible = true;
                }
                DataTable taxValuesByItemIdAndTaxIdForImport2 = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 5);
                if (taxValuesByItemIdAndTaxIdForImport2.Rows.Count == 0)
                {
                    this.chkAIT.Checked = false;
                    this.lblAIT.Text = "0.00";
                    this.ait.Attributes["style"] = "color:black;";
                    this.lblVAIT.Visible = false;
                    this.txtAIT.Visible = false;
                }
                else
                {
                    this.chkAIT.Checked = true;
                    this.ait.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblAIT.Text = taxValuesByItemIdAndTaxIdForImport2.Rows[0]["tax_value"].ToString();
                    this.lblVAIT.Visible = true;
                    this.txtAIT.Visible = true;
                }
                DataTable dataTable2 = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 6);
                if (dataTable2.Rows.Count == 0)
                {
                    this.chkATV.Checked = false;
                    this.lblATV.Text = "0.00";
                    this.atv.Attributes["style"] = "color:black;";
                    this.lblVATV.Visible = false;
                    this.txtATV.Visible = false;
                }
                else
                {
                    this.chkATV.Checked = true;
                    this.atv.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblATV.Text = dataTable2.Rows[0]["tax_value"].ToString();
                    this.lblVATV.Visible = true;
                    this.txtATV.Visible = true;
                }
                DataTable taxValuesByItemIdAndTaxIdForImport3 = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 7);
                if (taxValuesByItemIdAndTaxIdForImport3.Rows.Count == 0)
                {
                    this.chkTTI.Checked = false;
                    this.lblTTI.Text = "0.00";
                    this.tti.Attributes["style"] = "color:black;";
                    this.lblVTTI.Visible = false;
                    this.txtTTI.Visible = false;
                }
                else
                {
                    this.chkTTI.Checked = true;
                    this.tti.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblTTI.Text = taxValuesByItemIdAndTaxIdForImport3.Rows[0]["tax_value"].ToString();
                    this.lblVTTI.Visible = true;
                    this.txtTTI.Visible = true;
                }
                DataTable dataTable3 = itemTaxValueBLL.getTaxValuesByItemIdAndTaxIdForImport(num, 4);
                if (dataTable3.Rows.Count == 0)
                {
                    this.chkVAT.Checked = false;
                    this.lblVAT.Text = "0.00";
                    this.vat.Attributes["style"] = "color:black;";
                    this.lblVVAT.Visible = false;
                    this.txtVAT.Visible = false;
                }
                else
                {
                    this.chkVAT.Checked = true;
                    this.vat.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblVAT.Text = dataTable3.Rows[0]["tax_value"].ToString();
                    this.lblVVAT.Visible = true;
                    this.txtVAT.Visible = true;
                }
                AddItemBLL addItemBLL = new AddItemBLL();
                int num1 = 0;
                num1 = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num1);
                if (itemIsTeriff.Rows.Count != 0 && Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                {
                    DataTable itemVatAmountForImport = addItemBLL.getItemVatAmountForImport(num1);
                    int count = itemVatAmountForImport.Rows.Count;
                    this.chkIsFixed.Checked = true;
                    this.chkIsFixed.Attributes["style"] = "color:Green; font-weight:bold;";
                    this.chkVAT.Checked = true;
                    this.vat.Attributes["style"] = "color:red; font-weight:bold;";
                    this.lblVAT.Text = "0";
                    this.lblVVAT.Visible = true;
                    this.txtVAT.Visible = true;
                }
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
                this.MsgBoxs.AddMessage("Please Select Item Name first.", MsgBoxs.enmMessageType.Error);
                return;
            }
            this.EnableOrDisablePropertyForItemforExcel();
            if (!(this.hfProperty1.Value == "0") || !(this.hfProperty2.Value == "0") || !(this.hfProperty3.Value == "0") || !(this.hfProperty4.Value == "0") || !(this.hfProperty5.Value == "0"))
            {
                this.part_e.Visible = true;
                this.propertyDIV.Visible = false;
                return;
            }
            this.chkExcel.Checked = false;
            this.MsgBoxs.AddMessage("No Additional Property Exist.", MsgBoxs.enmMessageType.Error);
        }

        protected void chkAIT_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkAnnx_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkAT_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkATV_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkCD_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkExcelImport_OnCheckedChanged(object sender, EventArgs e)
        {
            this.part_e.Visible = true;
        }

        protected void chkManualInput_OnCheckedChanged(object sender, EventArgs e)
        {
            this.part_a.Visible = true;
            this.part_b.Visible = true;
            this.part_c.Visible = true;
            this.part_e.Visible = false;
        }

        protected void chkRD_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkSD_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkTaxDeducted_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void chkTTI_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkUnitPrice_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        protected void chkVAT_CheckedChanged(object sender, EventArgs e)
        {
            this.InsertTaxValues();
        }

        private void ClearAllControlsforExcel()
        {
            this.txtChallanNo.Text = string.Empty;
            this.dtpLCDate.Text = string.Empty;
            this.drpPortCode.SelectedValue = "0";
            this.txtPortFrom.Text = string.Empty;
            this.txtLCNo.Text = string.Empty;
            this.chkIsWar.Checked = false;
            this.drpBank.SelectedValue = "0";
            this.drpBankBranch.SelectedValue = "0";
            this.txtLCAmount.Text = string.Empty;
            this.txtForeignAmount.Text = string.Empty;
            this.drpCurrencyUnit.SelectedValue = "0";
            this.txtInsuranceNo.Text = string.Empty;
            this.txtInsuranceAmount.Text = string.Empty;
            this.drpDlDtHr.SelectedItem.Text = "1";
            this.drpDlDtMin.SelectedItem.Text = "1";
            this.drpChDtHr.SelectedItem.Text = "1";
            this.drpChDtMin.SelectedItem.Text = "1";
            this.txtShipmentDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.txtDeliveryDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.convertShipmentDateTime();
            this.convertDeliveryDateTime();
            this.drpParty.SelectedValue = "-99";
            this.drpCountry.SelectedValue = "0";
            this.txtAddress.Text = string.Empty;
            this.txtDestination.Text = string.Empty;
            this.txtPartyName.Text = string.Empty;
            this.lblMessage.Text = string.Empty;
            this.Session["PARTY_INFO"] = new DataTable();
            this.gvExcelFile.DataSource = null;
            this.gvExcelFile.DataBind();
            this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
            this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
        }

        private void ClearAllControlsValue()
        {
            this.gvExcelFile.DataSource = null;
            this.gvExcelFile.DataBind();
            this.Session["ProductionRcv_EXCEL"] = new ArrayList();
            this.chkExcel.Checked = false;
            this.part_e.Visible = false;
            this.txtChallanNo.Text = "";
            this.dtpLCDate.Text = "";
            this.txtPortFrom.Text = "";
            this.txtLCNo.Text = "";
            this.chkIsWar.Checked = false;
            this.drpBank.SelectedValue = "0";
            this.drpBankBranch.SelectedValue = "0";
            this.txtLCAmount.Text = "";
            this.txtForeignAmount.Text = "";
            this.drpCurrencyUnit.SelectedValue = "0";
            this.txtInsuranceNo.Text = "";
            this.txtInsuranceAmount.Text = "";
            this.drpDlDtHr.SelectedItem.Text = "1";
            this.drpDlDtMin.SelectedItem.Text = "1";
            this.txtShipmentDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.txtDeliveryDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.convertShipmentDateTime();
            this.convertDeliveryDateTime();
            this.drpParty.SelectedValue = "-99";
            this.drpCountry.SelectedValue = "0";
            this.txtAddress.Text = "";
            this.txtDestination.Text = "";
            this.txtPartyName.Text = "";
            this.lblMessage.Text = "";
            this.txtExchangeRate.Text = "";
            this.txtReleaseOrderNo.Text = "";
            this.ClearDetailControlsValue();
            this.drpCategory.SelectedValue = "-99";
            this.drpItem.SelectedValue = "-99";
            this.Session["Bill_of_Entry_DETAIL_LIST"] = new ArrayList();
            this.Session["PARTY_INFO"] = new DataTable();
            this.txtTaxPayDate.Text = "";
            this.txtTotalImportPrice.Text = "";
            this.gvItem.DataSource = null;
            this.gvItem.DataBind();
            this.drpItem.SelectedValue = "-99";
            this.drpSubCategory.Items.Clear();
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpSubCategory.Items.Insert(0, listItem);
            ListItem listItem1 = new ListItem("-- Select --", "-99");
            this.chkRebatable.Checked = false;
            this.chkTaxDeducted.Checked = false;
            this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
            this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
            this.chkCash.Checked = false;
            this.chkCheque.Checked = false;
            this.chkRocket.Checked = false;
            this.chkBkash.Checked = false;
            this.chkTT.Checked = false;
            this.chkEFT.Checked = false;
            this.CheDebitCard.Checked = false;
            this.chkPayOrder.Checked = false;
            this.ChkOther.Checked = false;
            this.chkDeferred.Checked = false;
            this.chkAtSight.Checked = false;
            this.txtCashAmount.Text = "";
            this.txtChequeAmount.Text = "";
            this.txtRocketAmount.Text = "";
            this.txtbKashAmount.Text = "";
            this.txtTPTAmount.Text = "";
            this.txtEFTAmount.Text = "";
            this.txtDebitCartAmount.Text = "";
            this.txtPayOrderAmount.Text = "";
            this.txtOthersAmount.Text = "";
            this.txtDeferredAmount.Text = "";
            this.txtAtSightAmount.Text = "";
        }

        private void ClearCheckBox()
        {
            this.chkExempted.Checked = false;
            this.chkExempted.Attributes["style"] = "color:black;";
            this.chkRebatable.Checked = false;
            this.chkRebatable.Attributes["style"] = "color:black;";
            this.chkTaxDeducted.Checked = false;
            this.chkTaxDeducted.Attributes["style"] = "color:black;";
            this.chkIsFixed.Checked = false;
            this.chkIsFixed.Attributes["style"] = "color:black;";
            this.chkZeroRate.Checked = false;
            this.chkZeroRate.Attributes["style"] = "color:black;";
            this.chkCD.Checked = false;
            this.chkCD.Attributes["style"] = "color:black";
            this.chkRD.Checked = false;
            this.chkRD.Attributes["style"] = "color:black";
            this.chkSD.Checked = false;
            this.chkSD.Attributes["style"] = "color:black";
            this.chkVAT.Checked = false;
            this.chkVAT.Attributes["style"] = "color:black";
            this.chkAT.Checked = false;
            this.chkAT.Attributes["style"] = "color:black";
            this.chkAIT.Checked = false;
            this.chkAIT.Attributes["style"] = "color:black";
            this.chkRebatable.Checked = false;
            this.chkRebatable.Attributes["style"] = "color:black";
            this.chkIsWar.Checked = false;
            this.chkIsWar.Attributes["style"] = "color:black";
        }

        private void ClearDetailControlsValue()
        {
            this.drpItem.SelectedValue = "-99";
            this.lblSku.Text = "";
            for (int i = 0; i < this.drpPropertyCollection.Count; i++)
            {
                this.drpPropertyCollection[i].SelectedIndex = 0;
                this.drpPropertyCollection[i].Enabled = false;
            }
            this.chkRebateCurrent.Checked = true;
            this.lblFxdCD.Text = "";
            this.productName.Text = "";
            this.txtQuantity.Text = "";
            this.txtUnitPrice.Text = "";
            this.lblUnit.Text = "";
            this.lblCD.Text = "";
            this.lblRD.Text = "";
            this.lblSD.Text = "";
            this.lblAIT.Text = "";
            this.lblATV.Text = "";
            this.lblTTI.Text = "";
            this.lblVAT.Text = "";
            this.lblAT.Text = "";
            this.txtUnitPriceTotal.Text = "0.00";
            this.txtCD.Text = "";
            this.txtRD.Text = "";
            this.txtSD.Text = "";
            this.txtAIT.Text = "";
            this.txtATV.Text = "";
            this.txtTTI.Text = "";
            this.txtVAT.Text = "";
            this.txtAT.Text = "";
            this.lblHSCode.Text = ".";
            this.lblTotal.Text = "";
            this.lblMessage.Text = "";
            this.chkTaxDeducted.Checked = false;
            this.chkRebatable.Checked = false;
            this.chkZeroRate.Checked = false;
            this.chkZeroRate.Attributes["style"] = "color:black;";
            this.chkIsFixed.Checked = false;
            this.chkIsFixed.Attributes["style"] = "color:black;";
            this.chkCD.Checked = false;
            this.chkRD.Checked = false;
            this.chkVAT.Checked = false;
            this.chkSD.Checked = false;
            this.chkAIT.Checked = false;
            this.chkATV.Checked = false;
            this.chkTTI.Checked = false;
            this.chkAT.Checked = false;
            this.vat.Attributes["style"] = "color:black;";
            this.sd.Attributes["style"] = "color:black;";
            this.cd.Attributes["style"] = "color:black;";
            this.ait.Attributes["style"] = "color:black;";
            this.tti.Attributes["style"] = "color:black;";
            this.atv.Attributes["style"] = "color:black;";
            this.rd.Attributes["style"] = "color:black;";
            this.AT.Attributes["style"] = "color:black;";
            this.lblRebatable.Attributes["style"] = "color:black;";
            this.txtDPFee.Text = "";
            this.txtOCost.Text = "";
            this.txtCommission.Text = "";
            this.txtCSF.Text = "";
            this.lblProperty1.Visible = false;
            this.drpProperty1.Visible = false;
            this.lblProperty2.Visible = false;
            this.drpProperty2.Visible = false;
            this.lblProperty3.Visible = false;
            this.drpProperty3.Visible = false;
            this.lblProperty4.Visible = false;
            this.drpProperty4.Visible = false;
            this.lblProperty5.Visible = false;
            this.drpProperty5.Visible = false;
            this.drpProperty1.Items.Clear();
            this.drpProperty2.Items.Clear();
            this.drpProperty3.Items.Clear();
            this.drpProperty4.Items.Clear();
            this.drpProperty5.Items.Clear();
            UtilityK.fillItemCategoryDropDownList(this.drpCategory);
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpCategory.Items.Insert(0, listItem);
            this.drpSubCategory.Items.Clear();
            ListItem listItem1 = new ListItem("-- Select --", "-99");
            this.drpSubCategory.Items.Insert(0, listItem1);
            this.txtDPFee.Text = "";
            this.singleRemarks.Text = "";
            this.txtOCost.Text = "";
            this.txtPSI.Text = "";
            this.txtCnFVat.Text = "";
            this.txtCnfCommission.Text = "";
            this.propertyDIV.Visible = false;
            this.lblvdstx.Visible = false;
            this.txtvdsamount.Visible = false;
            this.txtTotalTax.Text = string.Empty;
            this.txtImportValue.Text = "0.00";
            this.lblTotalCost.Text = "";
            this.lblPurchaseUnitPrice1.Text = "";
            this.lblRefund.Text = "";
        }

        private void ClearItemChangeValue()
        {
            this.productName.Text = "";
            this.txtQuantity.Text = "";
            this.txtUnitPrice.Text = "";
            this.lblUnit.Text = "";
            this.lblCD.Text = "";
            this.lblRD.Text = "";
            this.lblSD.Text = "";
            this.lblAIT.Text = "";
            this.lblATV.Text = "";
            this.lblTTI.Text = "";
            this.lblVAT.Text = "";
            this.txtUnitPriceTotal.Text = "0.00";
            this.txtCD.Text = "";
            this.txtRD.Text = "";
            this.txtSD.Text = "";
            this.txtAIT.Text = "";
            this.txtATV.Text = "";
            this.txtTTI.Text = "";
            this.txtVAT.Text = "";
            this.txtAT.Text = "";
            this.lblHSCode.Text = ".";
            this.lblTotal.Text = "";
            this.lblMessage.Text = "";
            this.chkTaxDeducted.Checked = false;
            this.chkRebatable.Checked = false;
            this.chkZeroRate.Checked = false;
            this.chkZeroRate.Attributes["style"] = "color:black;";
            this.chkIsFixed.Checked = false;
            this.chkIsFixed.Attributes["style"] = "color:black;";
            this.chkCD.Checked = false;
            this.chkRD.Checked = false;
            this.chkVAT.Checked = false;
            this.chkSD.Checked = false;
            this.chkAIT.Checked = false;
            this.chkATV.Checked = false;
            this.chkTTI.Checked = false;
            this.chkAT.Checked = false;
            this.vat.Attributes["style"] = "color:black;";
            this.sd.Attributes["style"] = "color:black;";
            this.cd.Attributes["style"] = "color:black;";
            this.ait.Attributes["style"] = "color:black;";
            this.tti.Attributes["style"] = "color:black;";
            this.atv.Attributes["style"] = "color:black;";
            this.rd.Attributes["style"] = "color:black;";
            this.AT.Attributes["style"] = "color:black;";
            this.lblRebatable.Attributes["style"] = "color:black;";
            this.txtDPFee.Text = "";
            this.txtOCost.Text = "";
            this.lblProperty1.Visible = false;
            this.drpProperty1.Visible = false;
            this.lblProperty2.Visible = false;
            this.drpProperty2.Visible = false;
            this.lblProperty3.Visible = false;
            this.drpProperty3.Visible = false;
            this.lblProperty4.Visible = false;
            this.drpProperty4.Visible = false;
            this.lblProperty5.Visible = false;
            this.drpProperty5.Visible = false;
            UtilityK.fillItemCategoryDropDownList(this.drpCategory);
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpCategory.Items.Insert(0, listItem);
            this.drpSubCategory.Items.Clear();
            ListItem listItem1 = new ListItem("-- Select --", "-99");
            this.drpSubCategory.Items.Insert(0, listItem1);
            this.txtDPFee.Text = "";
            this.singleRemarks.Text = "";
            this.txtOCost.Text = "";
            this.txtPSI.Text = "";
            this.txtCnFVat.Text = "";
            this.txtCnfCommission.Text = "";
            this.propertyDIV.Visible = false;
            this.lblvdstx.Visible = false;
            this.txtvdsamount.Visible = false;
            this.txtTotalTax.Text = string.Empty;
            this.txtImportValue.Text = "0.00";
            this.lblTotalCost.Text = "";
            this.lblPurchaseUnitPrice.Text = "";
            this.lblRefund.Text = "";
        }

        private void convertDeliveryDateTime()
        {
            this.lblDelivery.Text = "";
            Label label = this.lblDelivery;
            string[] str = new string[6];
            DateTime standardDateFromDdMMyyyy =   BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtDeliveryDate.Text.Trim());
            str[0] = standardDateFromDdMMyyyy.ToString("dd MMMMM yyyy");
            str[1] = "  ";
            str[2] = Util.NumberToWords(Convert.ToInt16(this.drpDlDtHr.SelectedItem.Text));
            str[3] = " hour  ";
            str[4] = Util.NumberToWords(Convert.ToInt16(this.drpDlDtMin.SelectedItem.Text));
            str[5] = " min ";
            label.Text = string.Concat(str);
        }

        private void convertShipmentDateTime()
        {
            this.lblShipment.Text = "";
            Label label = this.lblShipment;
            string[] str = new string[6];
            DateTime standardDateFromDdMMyyyy =  BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtShipmentDate.Text.Trim());
            str[0] = standardDateFromDdMMyyyy.ToString("dd MMMMM yyyy");
            str[1] = "  ";
            str[2] = Util.NumberToWords(Convert.ToInt16(this.drpChDtHr.SelectedItem.Text));
            str[3] = " hour ";
            str[4] = Util.NumberToWords(Convert.ToInt16(this.drpChDtMin.SelectedItem.Text));
            str[5] = " min ";
            label.Text = string.Concat(str);
        }

        protected void drpBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpBank.SelectedValue.ToString() != "0")
            {
                Util.fillBankBranch(this.drpBankBranch, Convert.ToInt16(this.drpBank.SelectedValue));
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
                this.LoadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpChDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.convertShipmentDateTime();
        }

        protected void drpChDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.convertShipmentDateTime();
        }

        protected void drpDlDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.convertDeliveryDateTime();
        }

        protected void drpDlDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.convertDeliveryDateTime();
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gvExcelFile.DataSource = null;
            this.gvExcelFile.DataBind();
            this.Session["ProductionRcv_EXCEL"] = new ArrayList();
            this.chkExcel.Checked = false;
            this.part_e.Visible = false;
            this.ClearItemChangeValue();
            this.ClearCheckBox();
            this.showCatSubCat();
            this.CalculateTaxValues();
            if (this.drpItem.SelectedValue == "-99")
            {
                this.lblHSCode.Text = "";
            }
            else
            {
                string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                if (strArrays != null && strArrays.Count<string>() > 0)
                {
                    this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 2];
                }
                if (this.txtQuantity.Text.Count<char>() > 0 && this.txtUnitPrice.Text.Count<char>() > 0)
                {
                    TextBox str = this.txtUnitPriceTotal;
                    double num = Convert.ToDouble(this.txtUnitPrice.Text) * Convert.ToDouble(this.txtQuantity.Text);
                    str.Text = num.ToString();
                    this.InsertTaxValues();
                }
                AddItemBLL addItemBLL = new AddItemBLL();
                int num1 = 0;
                num1 = Convert.ToInt32(this.drpItem.SelectedValue);
                this.itemId.Text = num1.ToString();
                DataTable truncated = addItemBLL.getTruncated(num1);
                if (truncated.Rows.Count > 0)
                {
                    this.HiddenIsTruncated.Value = null;
                    if (!Convert.ToBoolean(truncated.Rows[0]["is_truncated"]))
                    {
                        this.HiddenIsTruncated.Value = null;
                    }
                    else
                    {
                        this.HiddenIsTruncated.Value = "is_truncated";
                    }
                }
                this.chkZeroRate.Checked = false;
                DataTable itemIsZeroRate = addItemBLL.getItemIsZeroRate(num1);
                if (itemIsZeroRate.Rows.Count > 0 && Convert.ToBoolean(itemIsZeroRate.Rows[0]["is_zero_rate"]))
                {
                    this.chkZeroRate.Checked = true;
                    this.chkZeroRate.Attributes["style"] = "color:Green;";
                    return;
                }
            }
        }

        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpParty.SelectedValue != "0")
                {
                    trnsPurchaseMasterBLL _trnsPurchaseMasterBLL = new trnsPurchaseMasterBLL();
                    DataTable partyInfobyPartyId = _trnsPurchaseMasterBLL.getPartyInfobyPartyId(Convert.ToInt16(this.drpParty.SelectedValue));
                    if (partyInfobyPartyId.Rows[0]["country_id"].ToString() != "")
                    {
                        this.drpCountry.SelectedValue = partyInfobyPartyId.Rows[0]["country_id"].ToString();
                    }
                    if (partyInfobyPartyId.Rows[0]["party_address"].ToString() != "")
                    {
                        this.txtAddress.Text = partyInfobyPartyId.Rows[0]["party_address"].ToString();
                    }
                    if (partyInfobyPartyId.Rows[0]["ultimate_destination"].ToString() != "")
                    {
                        this.txtDestination.Text = partyInfobyPartyId.Rows[0]["ultimate_destination"].ToString();
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

        protected void drpServGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
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

        private void EnableOrDisablePropertyForItem()
        {
            if (!string.IsNullOrEmpty(this.drpItem.SelectedValue))
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = 0;
                if (this.drpItem.SelectedValue != "-99")
                {
                    num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(num);
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
                    short num6 = 0;
                    short num7 = 0;
                    short num8 = 0;
                    short num9 = 0;
                    short num10 = 0;
                    DataTable appCodeDetailName = null;
                    num6 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id1"]);
                    num7 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id2"]);
                    num8 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id3"]);
                    num9 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id4"]);
                    num10 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id5"]);
                    DataTable itemProperty = addItemBLL.getItemProperty(num6);
                    if (itemProperty == null)
                    {
                        this.lblProperty1.Visible = false;
                        this.drpProperty1.Visible = false;
                    }
                    else if (itemProperty.Rows.Count <= 0)
                    {
                        this.lblProperty1.Visible = false;
                        this.drpProperty1.Visible = false;
                    }
                    else
                    {
                        this.drpProperty1.DataSource = itemProperty;
                        this.drpProperty1.DataTextField = itemProperty.Columns["property_name"].ToString();
                        this.drpProperty1.DataValueField = itemProperty.Columns["property_id"].ToString();
                        this.drpProperty1.DataBind();
                        ListItem listItem = new ListItem("---Select---", "-99");
                        this.drpProperty1.Items.Insert(0, listItem);
                        this.propertyDIV.Visible = true;
                        this.lblProperty1.Visible = true;
                        this.drpProperty1.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num6);
                        this.lblProperty1.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable = addItemBLL.getItemProperty(num7);
                    if (dataTable == null)
                    {
                        this.lblProperty2.Visible = false;
                        this.drpProperty2.Visible = false;
                    }
                    else if (dataTable.Rows.Count <= 0)
                    {
                        this.lblProperty2.Visible = false;
                        this.drpProperty2.Visible = false;
                    }
                    else
                    {
                        this.drpProperty2.DataSource = dataTable;
                        this.drpProperty2.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProperty2.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProperty2.DataBind();
                        ListItem listItem1 = new ListItem("---Select---", "-99");
                        this.drpProperty2.Items.Insert(0, listItem1);
                        this.propertyDIV.Visible = true;
                        this.lblProperty2.Visible = true;
                        this.drpProperty2.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num7);
                        this.lblProperty2.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty1 = addItemBLL.getItemProperty(num8);
                    if (itemProperty1 == null)
                    {
                        this.lblProperty3.Visible = false;
                        this.drpProperty3.Visible = false;
                    }
                    else if (itemProperty1.Rows.Count <= 0)
                    {
                        this.lblProperty3.Visible = false;
                        this.drpProperty3.Visible = false;
                    }
                    else
                    {
                        this.drpProperty3.DataSource = itemProperty1;
                        this.drpProperty3.DataTextField = itemProperty1.Columns["property_name"].ToString();
                        this.drpProperty3.DataValueField = itemProperty1.Columns["property_id"].ToString();
                        this.drpProperty3.DataBind();
                        ListItem listItem2 = new ListItem("---Select---", "-99");
                        this.drpProperty3.Items.Insert(0, listItem2);
                        this.propertyDIV.Visible = true;
                        this.lblProperty3.Visible = true;
                        this.drpProperty3.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num8);
                        this.lblProperty3.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable1 = addItemBLL.getItemProperty(num9);
                    if (dataTable1 == null)
                    {
                        this.lblProperty4.Visible = false;
                        this.drpProperty4.Visible = false;
                    }
                    else if (dataTable1.Rows.Count <= 0)
                    {
                        this.lblProperty4.Visible = false;
                        this.drpProperty4.Visible = false;
                    }
                    else
                    {
                        this.drpProperty4.DataSource = dataTable1;
                        this.drpProperty4.DataTextField = dataTable1.Columns["property_name"].ToString();
                        this.drpProperty4.DataValueField = dataTable1.Columns["property_id"].ToString();
                        this.drpProperty4.DataBind();
                        ListItem listItem3 = new ListItem("---Select---", "-99");
                        this.drpProperty4.Items.Insert(0, listItem3);
                        this.propertyDIV.Visible = true;
                        this.lblProperty4.Visible = true;
                        this.drpProperty4.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num9);
                        this.lblProperty4.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty2 = addItemBLL.getItemProperty(num10);
                    if (itemProperty2 != null)
                    {
                        if (itemProperty2.Rows.Count <= 0)
                        {
                            this.lblProperty5.Visible = false;
                            this.drpProperty5.Visible = false;
                            return;
                        }
                        this.drpProperty5.DataSource = itemProperty2;
                        this.drpProperty5.DataTextField = itemProperty2.Columns["property_name"].ToString();
                        this.drpProperty5.DataValueField = itemProperty2.Columns["property_id"].ToString();
                        this.drpProperty5.DataBind();
                        ListItem listItem4 = new ListItem("---Select---", "-99");
                        this.drpProperty5.Items.Insert(0, listItem4);
                        this.propertyDIV.Visible = true;
                        this.lblProperty5.Visible = true;
                        this.drpProperty5.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num10);
                        this.lblProperty5.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                        return;
                    }
                    this.lblProperty5.Visible = false;
                    this.drpProperty5.Visible = false;
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

        private void fillDetailProperties()
        {
            ArrayList item = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            try
            {
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO()
                {
                    PurchaseType = 'I'
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
                if (this.drpProperty1.Visible && this.drpProperty1.SelectedValue != "-99")
                {
                    purchaseDetailDAO.PropertyID1 = Convert.ToInt32(this.drpProperty1.SelectedValue);
                    purchaseDetailDAO.Property1 = this.drpProperty1.SelectedItem.ToString();
                }
                if (this.drpProperty2.Visible && this.drpProperty2.SelectedValue != "-99")
                {
                    purchaseDetailDAO.PropertyID2 = Convert.ToInt32(this.drpProperty2.SelectedValue);
                    purchaseDetailDAO.Property2 = this.drpProperty2.SelectedItem.ToString();
                }
                if (this.drpProperty3.Visible && this.drpProperty3.SelectedValue != "-99")
                {
                    purchaseDetailDAO.PropertyID3 = Convert.ToInt32(this.drpProperty3.SelectedValue);
                    purchaseDetailDAO.Property3 = this.drpProperty3.SelectedItem.ToString();
                }
                if (this.drpProperty4.Visible && this.drpProperty4.SelectedValue != "-99")
                {
                    purchaseDetailDAO.PropertyID4 = Convert.ToInt32(this.drpProperty4.SelectedValue);
                    purchaseDetailDAO.Property4 = this.drpProperty4.SelectedItem.ToString();
                }
                if (this.drpProperty5.Visible && this.drpProperty5.SelectedValue != "-99")
                {
                    purchaseDetailDAO.PropertyID5 = Convert.ToInt32(this.drpProperty5.SelectedValue);
                    purchaseDetailDAO.Property5 = this.drpProperty5.SelectedItem.ToString();
                }
                purchaseDetailDAO.RemarksDetail =  BLL.Utility.ReplaceQuotes(this.singleRemarks.Text);
                purchaseDetailDAO.RealProperty = '0';
                purchaseDetailDAO.Quantity = Convert.ToDouble(this.txtQuantity.Text);
                if (this.lblUnitId.Text != "" && this.lblUnit.Text != "")
                {
                    purchaseDetailDAO.UnitID = Convert.ToInt32(this.lblUnitId.Text);
                    purchaseDetailDAO.UnitName = this.lblUnit.Text.ToString();
                }
                purchaseDetailDAO.AssesValue = Convert.ToDouble(this.txtUnitPriceTotal.Text);
                purchaseDetailDAO.UnitPriceBDT = Convert.ToDouble(this.txtUnitPrice.Text);
                purchaseDetailDAO.PurchaseUnitPrice = Convert.ToDouble(this.lblPurchaseUnitPrice.Text) / Convert.ToDouble(this.txtQuantity.Text);
                if (!this.chkRebatable.Checked)
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
                if (this.txtSD.Text != "")
                {
                    purchaseDetailDAO.SD = Convert.ToDouble(this.txtSD.Text);
                    purchaseDetailDAO.PurchaseSD = Convert.ToDouble(this.txtSD.Text);
                }
                else
                {
                    purchaseDetailDAO.SD = 0;
                }
                if (this.txtVAT.Text != "")
                {
                    purchaseDetailDAO.VAT = Convert.ToDouble(this.txtVAT.Text);
                    purchaseDetailDAO.PurchaseVAT = Convert.ToDouble(this.txtVAT.Text);
                }
                else
                {
                    purchaseDetailDAO.VAT = 0;
                }
                if (this.txtCD.Text != "")
                {
                    purchaseDetailDAO.CD = Convert.ToDouble(this.txtCD.Text);
                    purchaseDetailDAO.CD_Amount = Convert.ToDouble(this.txtCD.Text);
                }
                else
                {
                    purchaseDetailDAO.CD = 0;
                    purchaseDetailDAO.CD_Amount = 0;
                }
                if (this.txtAT.Text != "")
                {
                    purchaseDetailDAO.AT = Convert.ToDouble(this.txtAT.Text);
                    purchaseDetailDAO.AT_Amount = Convert.ToDouble(this.txtAT.Text);
                }
                else
                {
                    purchaseDetailDAO.AT = 0;
                    purchaseDetailDAO.AT_Amount = 0;
                }
                if (this.txtRD.Text != "")
                {
                    purchaseDetailDAO.RD = Convert.ToDouble(this.txtRD.Text);
                    purchaseDetailDAO.RD_Amount = Convert.ToDouble(this.txtRD.Text);
                }
                else
                {
                    purchaseDetailDAO.RD = 0;
                    purchaseDetailDAO.RD_Amount = 0;
                }
                if (this.txtAIT.Text != "")
                {
                    purchaseDetailDAO.AIT = Convert.ToDouble(this.txtAIT.Text);
                    purchaseDetailDAO.AIT_Amount = Convert.ToDouble(this.txtAIT.Text);
                }
                else
                {
                    purchaseDetailDAO.AIT = 0;
                    purchaseDetailDAO.AIT_Amount = 0;
                }
                if (this.txtTTI.Text != "")
                {
                    purchaseDetailDAO.TTI = Convert.ToDouble(this.txtTTI.Text);
                    purchaseDetailDAO.TTI_Amount = Convert.ToDouble(this.txtTTI.Text);
                }
                else
                {
                    purchaseDetailDAO.TTI = 0;
                    purchaseDetailDAO.TTI_Amount = 0;
                }
                if (this.txtDPFee.Text != "")
                {
                    purchaseDetailDAO.DocumentProcessingFee = Convert.ToDouble(this.txtDPFee.Text);
                }
                else
                {
                    purchaseDetailDAO.DocumentProcessingFee = 0;
                }
                if (this.txtOCost.Text != "")
                {
                    purchaseDetailDAO.OthersPrice = Convert.ToDouble(this.txtOCost.Text);
                }
                else
                {
                    purchaseDetailDAO.OthersPrice = 0;
                }
                if (this.txtCnFVat.Text != "")
                {
                    purchaseDetailDAO.CnFVat = Convert.ToDouble(this.txtCnFVat.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.CnFVat = 0;
                }
                if (this.txtPSI.Text != "")
                {
                    purchaseDetailDAO.PSI = Convert.ToDouble(this.txtPSI.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.PSI = 0;
                }
                if (this.txtCnfCommission.Text != "")
                {
                    purchaseDetailDAO.CnFCommission = Convert.ToDouble(this.txtCnfCommission.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.CnFCommission = 0;
                }
                if (this.txtCommission.Text != "")
                {
                    purchaseDetailDAO.Commission = Convert.ToDouble(this.txtCommission.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.Commission = 0;
                }
                if (this.txtCSF.Text != "")
                {
                    purchaseDetailDAO.CSF = Convert.ToDouble(this.txtCSF.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.CSF = 0;
                }
                if (this.txtvdsamount.Text != "")
                {
                    purchaseDetailDAO.VDSAmount = Convert.ToDouble(this.txtvdsamount.Text.Trim());
                }
                else
                {
                    purchaseDetailDAO.VDSAmount = 0;
                }
                purchaseDetailDAO.UnitPriceTotal = Convert.ToDouble(this.txtUnitPriceTotal.Text);
                purchaseDetailDAO.IsWar = this.chkIsWar.Checked;
                if (this.chkIsWar.Checked)
                {
                    purchaseDetailDAO.IsWarStr = "Yes";
                }
                purchaseDetailDAO.VATRate = Convert.ToDouble(this.lblVAT.Text.Trim());
                purchaseDetailDAO.TotalPrice = Convert.ToDouble(this.txtUnitPriceTotal.Text) + purchaseDetailDAO.SD + purchaseDetailDAO.VAT + purchaseDetailDAO.CD + purchaseDetailDAO.RD + purchaseDetailDAO.DocumentProcessingFee + purchaseDetailDAO.OthersPrice + purchaseDetailDAO.PSI + purchaseDetailDAO.CnFCommission;
                purchaseDetailDAO.TotalPricet = Convert.ToDouble(this.lblPurchaseUnitPrice.Text);
                purchaseDetailDAO.Cost = (!string.IsNullOrEmpty(this.lblTotalCost.Text) ? Convert.ToDouble(string.Join("", this.lblTotalCost.Text.Split(new char[0]).Skip<string>(1))) : 0);
                purchaseDetailDAO.RefundPrice = (!string.IsNullOrEmpty(this.lblRefund.Text) ? Convert.ToDouble(string.Join("", this.lblRefund.Text.Split(new char[0]).Skip<string>(1))) : 0);
                purchaseDetailDAO.TotalTax = (!string.IsNullOrEmpty(this.txtTotalTax.Text) ? Convert.ToDouble(string.Join("", this.txtTotalTax.Text.Split(new char[0]).Skip<string>(1))) : 0);
                purchaseDetailDAO.ImportValue = Convert.ToDouble(this.txtImportValue.Text);
                purchaseDetailDAO.IsSrcTAXDeduct = this.chkTaxDeducted.Checked;
                purchaseDetailDAO.UserIdInsert = 1;
                purchaseDetailDAO.IsRebatable = this.chkRebatable.Checked;
                purchaseDetailDAO.IsExempted = this.chkExempted.Checked;
                purchaseDetailDAO.IsCurrentMonthRebate = this.chkRebateCurrent.Checked;
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
                if (this.btnAdd.Text.Trim() !=enmBtnText.Update.ToString())
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
            this.Session["Bill_of_Entry_DETAIL_LIST"] = item;
        }

        private DropDownList fillPortCode(DropDownList drpPortCode)
        {
            DataTable dataTable = (new ChallanBLL()).GetportInfo();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                drpPortCode.DataSource = dataTable;
                drpPortCode.DataTextField = dataTable.Columns["code_short_name"].ToString();
                drpPortCode.DataValueField = dataTable.Columns["code_id_d"].ToString();
                drpPortCode.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            drpPortCode.Items.Insert(0, listItem);
            return drpPortCode;
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
                        DataTable branchInformation = challanBLL.GetBranchInformation(num2, num1);
                        if (branchInformation != null && branchInformation.Rows.Count > 0)
                        {
                            this.drpBranchName.DataSource = branchInformation;
                            this.drpBranchName.DataTextField = branchInformation.Columns["branch_unit_name"].ToString();
                            this.drpBranchName.DataValueField = branchInformation.Columns["org_branch_reg_id"].ToString();
                            this.drpBranchName.DataBind();
                        }
                    }
                    else
                    {
                        ListItem listItem = new ListItem("Head Office", "0");
                        this.drpBranchName.Items.Insert(1, listItem);
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
                if (num == 2 || num == 1)
                {
                    this.drpBranchName.Enabled = true;
                    DataTable selectedBusinessUnitBranchInfo = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                    if (selectedBusinessUnitBranchInfo != null && selectedBusinessUnitBranchInfo.Rows.Count > 0)
                    {
                        this.drpBranchName.DataSource = selectedBusinessUnitBranchInfo;
                        this.drpBranchName.DataTextField = selectedBusinessUnitBranchInfo.Columns["branch_unit_name"].ToString();
                        this.drpBranchName.DataValueField = selectedBusinessUnitBranchInfo.Columns["org_branch_reg_id"].ToString();
                        this.drpBranchName.DataBind();
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
            }
        }

        private void GetChallanDtInWords()
        {
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

        private void GetCPCCode()
        {
            DataTable cPCCodeforBOE = this.objBLL.GetCPCCodeforBOE();
            if (cPCCodeforBOE != null && cPCCodeforBOE.Rows.Count > 0)
            {
                this.drpCPC.DataSource = cPCCodeforBOE;
                this.drpCPC.DataTextField = cPCCodeforBOE.Columns["cpc_code"].ToString();
                this.drpCPC.DataValueField = cPCCodeforBOE.Columns["cpc_code_id"].ToString();
                this.drpCPC.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpCPC.Items.Insert(0, listItem);
        }

        private PurchaseMasterDAO GetInserMasterValues(PurchaseMasterDAO objMDAO)
        {
            try
            {
                objMDAO.Org_branch_reg_id = Convert.ToInt32(this.drpBranchName.SelectedValue.ToString());
                objMDAO.ChallanType = 'P';
                objMDAO.PurchaseType = 'I';
                if (!string.IsNullOrEmpty(this.txtChallanDate.Text.Trim()))
                {
                    objMDAO.ChallanDate =  BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtChallanDate.Text.Trim());
                }
                if (!string.IsNullOrEmpty(this.txtDeliveryDate.Text.Trim()))
                {
                    objMDAO.DeliveryDate =  BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtDeliveryDate.Text.Trim());
                }
                objMDAO.UserIdInsert = 1;
                if (!this.drpParty.Enabled)
                {
                    objMDAO.IsNewParty = true;
                    objMDAO.TransPartyName =  BLL.Utility.ReplaceQuotes(this.txtPartyName.Text);
                    objMDAO.PartAddress =  BLL.Utility.ReplaceQuotes(this.txtAddress.Text);
                }
                else
                {
                    objMDAO.PartyID = Convert.ToInt16(this.drpParty.SelectedValue);
                    objMDAO.IsNewParty = false;
                }
                objMDAO.CPC = this.drpCPC.SelectedItem.ToString();
                objMDAO.UltimateDestination =  BLL.Utility.ReplaceQuotes(this.txtDestination.Text);
                objMDAO.OrganizatioID = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                objMDAO.LCNo = this.txtLCNo.Text;
                objMDAO.LCDate = Convert.ToDateTime( BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.dtpLCDate.Text.Trim()));
                objMDAO.LCAmount = Convert.ToDouble(this.txtLCAmount.Text.Trim());
                objMDAO.BLNo = this.txtChallanNo.Text.Trim();
                objMDAO.ChallanNo = this.txtChallanNo.Text.Trim();
                objMDAO.BLDate = Convert.ToDateTime( BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.dtpBillOfEntryDate.Text.Trim()));
                objMDAO.PortCode = this.drpPortCode.SelectedItem.Text;
                objMDAO.PortFrom = this.txtPortFrom.Text;
                objMDAO.BankBranchId = Convert.ToInt16(this.drpBankBranch.SelectedValue);
                objMDAO.LCForeignAmount = (!string.IsNullOrEmpty(this.txtForeignAmount.Text.Trim()) ? Convert.ToDouble(this.txtForeignAmount.Text) : 0);
                objMDAO.InsuranceNo = this.txtInsuranceNo.Text;
                objMDAO.InsuranceAmount = Convert.ToDouble(this.txtInsuranceAmount.Text);
                objMDAO.LCForeingnCurrencyUnit = Convert.ToInt16(this.drpCurrencyUnit.SelectedValue);
                objMDAO.LCForeignCurrency = this.drpCurrencyUnit.SelectedItem.ToString();
                objMDAO.Remarks = this.txtMasterRemark.Text;
                objMDAO.BankName = this.drpBank.SelectedItem.ToString();
                objMDAO.BankId = Convert.ToInt16(this.drpBank.SelectedValue);
                objMDAO.ReleaseOrderNo = this.txtReleaseOrderNo.Text;
                objMDAO.ReleaseOrderDate = Convert.ToDateTime( BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtReleaseOrderDate.Text.Trim()));
                objMDAO.ShipmentDate = Convert.ToDateTime( BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtShipmentDate.Text.Trim()));
                objMDAO.PaymentInfo = this.txt_transaction_id.Text;
                objMDAO.SupplierName = this.drpParty.SelectedItem.ToString();
                objMDAO.SupplierCounty = this.drpCountry.SelectedItem.ToString();
                objMDAO.CountryId = Convert.ToInt16(this.drpCountry.SelectedValue);
                objMDAO.SupplierAddress = this.txtAddress.Text;
                objMDAO.TaxPaymentDate = Convert.ToDateTime( BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtTaxPayDate.Text.Trim()));
                if (this.txtNoofItem.Text == "")
                {
                    objMDAO.NoOfItem = 0;
                }
                else
                {
                    objMDAO.NoOfItem = Convert.ToInt32(this.txtNoofItem.Text.Trim());
                }
                if (this.txtTotalPack.Text == "")
                {
                    objMDAO.TotalPack = 0;
                }
                else
                {
                    objMDAO.TotalPack = Convert.ToInt32(this.txtTotalPack.Text.Trim());
                }
                objMDAO.PrtCode = Convert.ToInt32(this.drpPortCode.SelectedValue.Trim());
                if (this.txtExchangeRate.Text == "")
                {
                    objMDAO.ExhRate = 0;
                }
                else
                {
                    objMDAO.ExhRate = Convert.ToDouble(this.txtExchangeRate.Text.Trim());
                }
                objMDAO.PaymentInfo = this.txt_transaction_id.Text;
                objMDAO.PaymentMethodP = "";
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
                if (this.chkAtSight.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO3 = objMDAO;
                    purchaseMasterDAO3.PaymentMethodP = string.Concat(purchaseMasterDAO3.PaymentMethodP, "10,");
                }
                if (this.chkCheque.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO4 = objMDAO;
                    purchaseMasterDAO4.PaymentMethodP = string.Concat(purchaseMasterDAO4.PaymentMethodP, "2,");
                }
                if (this.chkTT.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO5 = objMDAO;
                    purchaseMasterDAO5.PaymentMethodP = string.Concat(purchaseMasterDAO5.PaymentMethodP, "14,");
                }
                if (this.chkEFT.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO6 = objMDAO;
                    purchaseMasterDAO6.PaymentMethodP = string.Concat(purchaseMasterDAO6.PaymentMethodP, "11,");
                }
                if (this.CheDebitCard.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO7 = objMDAO;
                    purchaseMasterDAO7.PaymentMethodP = string.Concat(purchaseMasterDAO7.PaymentMethodP, "7,");
                }
                if (this.chkPayOrder.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO8 = objMDAO;
                    purchaseMasterDAO8.PaymentMethodP = string.Concat(purchaseMasterDAO8.PaymentMethodP, "5,");
                }
                if (this.chkDeferred.Checked)
                {
                    PurchaseMasterDAO purchaseMasterDAO9 = objMDAO;
                    purchaseMasterDAO9.PaymentMethodP = string.Concat(purchaseMasterDAO9.PaymentMethodP, "9,");
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
                if (this.chkAtSight.Checked && this.txtAtSightAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO cashAmount3 = objMDAO;
                    cashAmount3.CashAmount = cashAmount3.CashAmount + Convert.ToDouble(this.txtAtSightAmount.Text.Trim());
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
                if (this.chkDeferred.Checked && this.txtDeferredAmount.Text.Trim() != "")
                {
                    PurchaseMasterDAO bankAmount5 = objMDAO;
                    bankAmount5.BankAmount = bankAmount5.BankAmount + Convert.ToDouble(this.txtDeferredAmount.Text.Trim());
                }
                string paymentMethodP = objMDAO.PaymentMethodP;
                char[] chrArray = new char[] { ',' };
                objMDAO.PaymentMethod = paymentMethodP.TrimEnd(chrArray);
                if (this.txtCashAmount.Text == "" && this.txtChequeAmount.Text == "" && this.txtAtSightAmount.Text == "" && this.txtbKashAmount.Text == "" && this.txtEFTAmount.Text == "" && this.txtPayOrderAmount.Text == "" && this.txtDeferredAmount.Text == "" && this.txtRocketAmount.Text == "" && this.txtTPTAmount.Text == "" && this.txtDebitCartAmount.Text == "" && this.txtOthersAmount.Text == "" || this.txtCashAmount.Text == "" && this.txtChequeAmount.Text == "0" && this.txtbKashAmount.Text == "0" && this.txtEFTAmount.Text == "0" && this.txtPayOrderAmount.Text == "0" && this.txtDeferredAmount.Text == "0" && this.txtRocketAmount.Text == "" && this.txtTPTAmount.Text == "0" && this.txtDebitCartAmount.Text == "0" && this.txtOthersAmount.Text == "0" && this.txtAtSightAmount.Text == "0")
                {
                    objMDAO.CashAmount = Convert.ToDouble(this.txtTotalImportPrice.Text);
                    objMDAO.PaymentMethod = "10";
                }
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                num = objMDAO.CashAmount;
                num1 = objMDAO.BankAmount;
                num2 = (this.txtTotalImportPrice.Text == "" ? 0 : Convert.ToDouble(this.txtTotalImportPrice.Text.Trim()));
                if (num2 != num + num1)
                {
                    objMDAO.IsPaymentFinished = false;
                }
                else
                {
                    objMDAO.IsPaymentFinished = true;
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
                        Org_branch_reg_id = Convert.ToInt32(this.drpBranchName.SelectedValue.ToString()),
                        ChallanType = 'P',
                        PurchaseType = 'I',
                        UserIdInsert = 1,
                        ChallanDate = Convert.ToDateTime(arrayList.Challan_Date)
                    };
                    DataTable party = this.objSBLL.GetParty(arrayList.Party_Name.ToUpper());
                    if (party.Rows.Count > 0)
                    {
                        purchaseMasterDAO.PartyID = Convert.ToInt16(party.Rows[0]["party_id"]);
                        purchaseMasterDAO.IsNewParty = false;
                    }
                    purchaseMasterDAO.UltimateDestination =  BLL.Utility.ReplaceQuotes(this.txtDestination.Text);
                    purchaseMasterDAO.OrganizatioID = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                    purchaseMasterDAO.LCNo = this.txtLCNo.Text;
                    purchaseMasterDAO.LCDate = Convert.ToDateTime( BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.dtpLCDate.Text.Trim()));
                    purchaseMasterDAO.LCAmount = arrayList.LCAmount;
                    purchaseMasterDAO.ChallanNo = arrayList.Challan_No;
                    purchaseMasterDAO.PortCode = arrayList.PortCode;
                    purchaseMasterDAO.PortFrom = arrayList.PortFrom;
                    purchaseMasterDAO.InsuranceAmount = arrayList.InsuranceAmount;
                    purchaseMasterDAO.LCForeignCurrency = arrayList.LCForeignCurrency;
                    purchaseMasterDAO.Remarks = arrayList.RemarksDetail;
                    purchaseMasterDAO.BranchName = arrayList.BranchName;
                    DataTable currencyIdbyCurrency = this.objBLL.GetCurrencyIdbyCurrency(arrayList.LCForeignCurrency.ToUpper());
                    if (currencyIdbyCurrency.Rows.Count > 0)
                    {
                        purchaseMasterDAO.LCForeingnCurrencyUnit = Convert.ToInt16(currencyIdbyCurrency.Rows[0]["currency_id"]);
                    }
                    DataTable branchBankbyBranchName = this.objSetBankBLL.GetBranchBankbyBranchName(arrayList.BranchName.ToUpper());
                    if (branchBankbyBranchName.Rows.Count > 0)
                    {
                        purchaseMasterDAO.BankId = Convert.ToInt16(branchBankbyBranchName.Rows[0]["bank_id"]);
                        purchaseMasterDAO.BankBranchId = Convert.ToInt16(branchBankbyBranchName.Rows[0]["branch_id"]);
                    }
                    purchaseMasterDAO.BankName = arrayList.BankName;
                    purchaseMasterDAO.ReleaseOrderNo = arrayList.ReleaseOrderNo;
                    purchaseMasterDAO.ReleaseOrderDate = Convert.ToDateTime( BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtReleaseOrderDate.Text.Trim()));
                    purchaseMasterDAO.ShipmentDate = Convert.ToDateTime(arrayList.ShipmentDate);
                    purchaseMasterDAO.SupplierName = arrayList.Party_Name;
                    purchaseMasterDAO.TaxPaymentDate = Convert.ToDateTime(arrayList.TaxPaymentDate);
                    if (this.txtNoofItem.Text == "")
                    {
                        purchaseMasterDAO.NoOfItem = 0;
                    }
                    else
                    {
                        purchaseMasterDAO.NoOfItem = Convert.ToInt32(this.txtNoofItem.Text.Trim());
                    }
                    if (this.txtTotalPack.Text == "")
                    {
                        purchaseMasterDAO.TotalPack = 0;
                    }
                    else
                    {
                        purchaseMasterDAO.TotalPack = Convert.ToInt32(this.txtTotalPack.Text.Trim());
                    }
                    purchaseMasterDAO.PrtCode = Convert.ToInt32(this.drpPortCode.SelectedValue.Trim());
                    if (this.txtExchangeRate.Text == "")
                    {
                        purchaseMasterDAO.ExhRate = 0;
                    }
                    else
                    {
                        purchaseMasterDAO.ExhRate = Convert.ToDouble(this.txtExchangeRate.Text.Trim());
                    }
                    purchaseMasterDAO.PaymentInfo = this.txt_transaction_id.Text;
                    purchaseMasterDAO.PaymentMethodP = "";
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

        private void GetPartyInfo()
        {
            DataTable organizationWisePartyForImport = (new TransPartyBLL()).getOrganizationWisePartyForImport();
            if (organizationWisePartyForImport != null && organizationWisePartyForImport.Rows.Count > 0)
            {
                this.drpParty.DataSource = organizationWisePartyForImport;
                this.drpParty.DataTextField = organizationWisePartyForImport.Columns["party_name"].ToString();
                this.drpParty.DataValueField = organizationWisePartyForImport.Columns["party_id"].ToString();
                this.drpParty.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpParty.Items.Insert(0, listItem);
            this.Session["PARTY_INFO"] = organizationWisePartyForImport;
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
                        this.txtUnitPrice.Text = "0.00";
                        this.lblCD.Text = "0.00";
                        this.lblRD.Text = "0.00";
                    }
                    else
                    {
                        this.txtUnitPrice.Text = priceInfoOfItem.Rows[0]["unit_price"].ToString();
                        this.lblCD.Text = priceInfoOfItem.Rows[0]["sd_amount"].ToString();
                        this.lblRD.Text = priceInfoOfItem.Rows[0]["VAT"].ToString();
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
            SaleBLL saleBLL = new SaleBLL();
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            DateTime standardDateFromDdMMyyyy =  BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.dtpBillOfEntryDate.Text.Trim());
            DataTable productDetailInfo = saleBLL.getProductDetailInfo(str, standardDateFromDdMMyyyy);
            if (productDetailInfo.Rows != null)
            {
                this.lblUnit.Text = productDetailInfo.Rows[0]["unit_code"].ToString();
                this.lblUnitId.Text = productDetailInfo.Rows[0]["unit_id"].ToString();
                this.lblProductType.Text = productDetailInfo.Rows[0]["item_type"].ToString();
                if (productDetailInfo.Rows[0]["item_type"].ToString() != "I")
                {
                    this.lblAvailableQuantity.Text = "0";
                }
                else
                {
                    this.lblAvailableQuantity.Text = productDetailInfo.Rows[0]["availStock"].ToString();
                }
                if (productDetailInfo.Rows[0]["parent_id"] == null || Convert.ToInt16(productDetailInfo.Rows[0]["parent_id"]) <= 0)
                {
                    this.drpCategory.SelectedValue = productDetailInfo.Rows[0]["sub_category_id"].ToString();
                    this.drpSubCategory.Items.Clear();
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    this.drpSubCategory.Items.Insert(0, listItem);
                    this.drpSubCategory.Enabled = false;
                }
                else
                {
                    this.drpCategory.SelectedValue = productDetailInfo.Rows[0]["parent_id"].ToString();
                    this.LoadSubCategory();
                    this.drpSubCategory.SelectedValue = productDetailInfo.Rows[0]["sub_category_id"].ToString();
                    this.drpItem.SelectedValue = productDetailInfo.Rows[0]["Item_id"].ToString();
                    string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                    if (strArrays != null && strArrays.Count<string>() > 0)
                    {
                        this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 2];
                    }
                    this.EnableOrDisablePropertyForItem();
                    this.CalculateTaxValues();
                    if (this.txtQuantity.Text.Count<char>() > 0 && this.txtUnitPrice.Text.Count<char>() > 0)
                    {
                        TextBox textBox = this.txtUnitPriceTotal;
                        double num = Convert.ToDouble(this.txtUnitPrice.Text) * Convert.ToDouble(this.txtQuantity.Text);
                        textBox.Text = num.ToString();
                        this.InsertTaxValues();
                        return;
                    }
                }
            }
        }

        private void GetTotalSaleValue()
        {
            try
            {
                decimal num = new decimal(0);
                if (this.gvItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItem.Rows.Count; i++)
                    {
                        num += Convert.ToDecimal(this.gvItem.Rows[i].Cells[32].Text.Trim());
                    }
                }
                this.txtTotalImportPrice.Text = num.ToString("0.0000");
                this.txtLCAmount.Text = num.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
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
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"];
                item.RemoveAt(e.RowIndex);
                this.Session["Bill_of_Entry_DETAIL_LIST"] = item;
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
                ArrayList item = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"];
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

        private void InsertAssessTaxValuesAssessedChanged()
        {
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            double num4 = 0;
            double num5 = 0;
            if (this.txtImportValue.Text != "" || this.txtImportValue.Text == "0.00")
            {
                num2 = Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim());
                num3 = num2 / 1.0201;
                this.txtImportValue.Text = num3.ToString("0.00");
                if (this.txtQuantity.Text == "")
                {
                    this.txtQuantity.Text = "1";
                    num4 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                    num5 = Convert.ToDouble(this.txtQuantity.Text.Trim());
                    this.txtUnitPrice.Text = (num4 / num5).ToString("N");
                }
                else
                {
                    num4 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                    num5 = Convert.ToDouble(this.txtQuantity.Text.Trim());
                    this.txtUnitPrice.Text = (num4 / num5).ToString("N");
                }
            }
            else
            {
                num2 = Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim());
                num3 = num2 / 1.0201;
                this.txtImportValue.Text = num3.ToString("0.00");
                if (this.txtQuantity.Text != "")
                {
                    num4 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                    num5 = Convert.ToDouble(this.txtQuantity.Text.Trim());
                    this.txtUnitPrice.Text = (num4 / num5).ToString("N");
                }
                else
                {
                    this.txtQuantity.Text = "1";
                    num4 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                    num5 = Convert.ToDouble(this.txtQuantity.Text.Trim());
                    this.txtUnitPrice.Text = (num4 / num5).ToString("N");
                }
            }
            Convert.ToDouble(this.txtImportValue.Text.Trim());
            double num6 = 0;
            double num7 = 0;
            double num8 = 0;
            double num9 = 0;
            double num10 = 0;
            double num11 = 0;
            double num12 = 0;
            double num13 = 0;
            double num14 = 0;
            double num15 = 0;
            double num16 = 0;
            double num17 = 0;
            double num18 = 0;
            double num19 = 0;
            double num20 = 0;
            double num21 = 0;
            double num22 = 0;
            num8 = (this.lblCD.Text != "" ? Convert.ToDouble(this.lblCD.Text.Trim()) : 0);
            num10 = (this.lblRD.Text != "" ? Convert.ToDouble(this.lblRD.Text.Trim()) : 0);
            num11 = (this.lblSD.Text != "" ? Convert.ToDouble(this.lblSD.Text.Trim()) : 0);
            num12 = (this.lblAIT.Text != "" ? Convert.ToDouble(this.lblAIT.Text.Trim()) : 0);
            num20 = (this.lblAT.Text != "" ? Convert.ToDouble(this.lblAT.Text.Trim()) : 0);
            num21 = (this.lblVAT.Text != "" ? Convert.ToDouble(this.lblVAT.Text.Trim()) : 0);
            num7 = (this.txtUnitPriceTotal.Text != "" ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0);
            num22 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
            if (this.chkCD.Checked)
            {
                num6 = (this.lblFxdCD.Text != "Fixed CD" ? num7 * num8 / 100 : num22 * num8);
                this.txtCD.Text = num6.ToString("N");
            }
            if (this.chkRD.Checked)
            {
                num9 = num7 * num10 / 100;
                this.txtRD.Text = num9.ToString("N");
            }
            if (this.chkSD.Checked)
            {
                num13 = (num7 + num6 + num9) * num11 / 100;
                this.txtSD.Text = num13.ToString("N");
            }
            if (this.chkAIT.Checked)
            {
                num14 = num7 * num12 / 100;
                this.txtAIT.Text = num14.ToString("N");
            }
            if (this.chkATV.Checked)
            {
                num15 = ((num7 + num6 + num13 + num9) * 26.67 / 100 + (num7 + num6 + num13 + num9)) * Convert.ToDouble(this.lblATV.Text) / 100;
                this.txtATV.Text = num15.ToString();
            }
            if (this.txtInsuranceAmount.Text.Count<char>() > 0)
            {
                if (this.chkTTI.Checked)
                {
                    num16 = (num7 + Convert.ToDouble(this.txtInsuranceAmount.Text)) * Convert.ToDouble(this.lblTTI.Text) / 100;
                }
                this.txtTTI.Text = num16.ToString("N");
            }
            if (this.chkVAT.Checked)
            {
                num17 = (num7 + num6 + num9 + num13) * num21 / 100;
                this.txtVAT.Text = num17.ToString("N");
            }
            if (this.chkAT.Checked)
            {
                num18 = (num7 + num6 + num9 + num13) * num20 / 100;
                this.txtAT.Text = num18.ToString("N");
            }
            if (this.chkTaxDeducted.Checked)
            {
                num19 = num17 / 3;
            }
            this.txtvdsamount.Text = num19.ToString("0.00");
            num = (double)(num7 + num6 + num9 + num13 + num18 + num14 + num15 + num16 + num17);
            num1 = (double)(num6 + num9 + num13 + num17 + num18 + num14 + num15 + num16);
            this.lblTotal.Text = string.Concat("Tk. ", num.ToString("N2"));
            this.txtTotalTax.Text = string.Concat("Tk. ", num1.ToString("N2"));
            double num23 = 0;
            double num24 = 0;
            double num25 = 0;
            double num26 = 0;
            double num27 = 0;
            double num28 = 0;
            num24 = (this.txtDPFee.Text != "" ? Convert.ToDouble(this.txtDPFee.Text.Trim()) : 0);
            num25 = (this.txtOCost.Text != "" ? Convert.ToDouble(this.txtOCost.Text.Trim()) : 0);
            num26 = (this.txtPSI.Text != "" ? Convert.ToDouble(this.txtPSI.Text.Trim()) : 0);
            num27 = (this.txtCnFVat.Text != "" ? Convert.ToDouble(this.txtCnFVat.Text.Trim()) : 0);
            num28 = (this.txtCnfCommission.Text != "" ? Convert.ToDouble(this.txtCnfCommission.Text.Trim()) : 0);
            num23 = num7 + num6 + num9 + num13 + num17 + num24 + num25 + num26 + num27 + num28;
            this.lblTotalCost.Text = string.Concat("Tk. ", num23.ToString("N2"));
            double num29 = num7 + num6 + num9 + num13;
            this.lblPurchaseUnitPrice.Text = num29.ToString("N2");
            double num30 = num7 + num6 + num9 + num13;
            this.lblPurchaseUnitPrice1.Text = string.Concat("Tk. ", num30.ToString("N2"));
        }

        private void InsertTaxValues()
        {
            double num = 0.0;
            if (this.txtQuantity.Text != "" && this.txtImportValue.Text != "")
            {
                double num2 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                double num3 = Convert.ToDouble(this.txtQuantity.Text.Trim());
                this.txtUnitPrice.Text = (num2 / num3).ToString();
            }
            else
            {
                this.txtUnitPrice.Text = "";
            }
            if (this.drpItem.SelectedValue != "-99")
            {
                Convert.ToInt16(this.drpItem.SelectedValue);
                new ItemBLL();
                new ItemTaxValueBLL();
                if (this.txtQuantity.Text != "")
                {
                    if (this.txtUnitPrice.Text != "")
                    {
                        Convert.ToDouble(this.txtQuantity.Text);
                        Convert.ToDouble(this.txtUnitPrice.Text);
                        double num2 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                        if (this.txtImportValue.Text != "")
                        {
                            num2 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                            double num4 = num2 * 0.01;
                            double num5 = num2 + num4;
                            double num6 = num5 * 0.01;
                            num = num5 + num6;
                            this.txtUnitPriceTotal.Text = num.ToString("0.00");
                        }
                    }
                }
                else if (this.txtImportValue.Text != "")
                {
                    Convert.ToDouble(this.txtImportValue.Text.Trim());
                    double num2 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                    double num4 = num2 * 0.01;
                    double num5 = num2 + num4;
                    double num6 = num5 * 0.01;
                    num = num5 + num6;
                    this.txtUnitPriceTotal.Text = num.ToString("0.00");
                }
                double num7 = 0.0;
                if (this.chkCD.Checked && Convert.ToDecimal(this.lblCD.Text.Trim()) > 0m)
                {
                    num7 = ((this.txtUnitPriceTotal.Text != "") ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0.0);
                }
                double num8 = (this.txtQuantity.Text != "") ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0.0;
                double num9;
                if (this.lblFxdCD.Text == "Fixed CD")
                {
                    num9 = num8 * Convert.ToDouble(this.lblCD.Text.Trim());
                }
                else
                {
                    num9 = num7 * Convert.ToDouble(this.lblCD.Text.Trim()) / 100.0;
                }
                this.txtCD.Text = num9.ToString();
                double num10 = 0.0;
                if (this.chkRD.Checked && Convert.ToDecimal(this.lblRD.Text.Trim()) > 0m)
                {
                    num10 = ((this.txtUnitPriceTotal.Text != "") ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0.0);
                }
                double num11 = num10 * Convert.ToDouble(this.lblRD.Text.Trim()) / 100.0;
                this.txtRD.Text = num11.ToString();
                double num12 = 0.0;
                if (this.chkSD.Checked)
                {
                    num12 = (num + num9 + num11) * Convert.ToDouble(this.lblSD.Text) / 100.0;
                }
                this.txtSD.Text = num12.ToString();
                double num13 = 0.0;
                if (this.chkATV.Checked)
                {
                    num13 = ((num + num9 + num12 + num11) * 26.67 / 100.0 + (num + num9 + num12 + num11)) * Convert.ToDouble(this.lblATV.Text) / 100.0;
                }
                this.txtATV.Text = num13.ToString();
                double num14 = 0.0;
                if (this.txtInsuranceAmount.Text.Count<char>() > 0)
                {
                    if (this.chkTTI.Checked)
                    {
                        num14 = (num + Convert.ToDouble(this.txtInsuranceAmount.Text)) * Convert.ToDouble(this.lblTTI.Text) / 100.0;
                    }
                    this.txtTTI.Text = num14.ToString();
                }
                double num15 = 0.0;
                if (this.chkVAT.Checked && Convert.ToDecimal(this.lblVAT.Text.Trim()) > 0m)
                {
                    num15 = (((this.txtUnitPriceTotal.Text != "") ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0.0) + ((this.txtCD.Text != "") ? Convert.ToDouble(this.txtCD.Text.Trim()) : 0.0) + ((this.txtRD.Text != "") ? Convert.ToDouble(this.txtRD.Text.Trim()) : 0.0) + num12) * ((this.lblVAT.Text != "") ? Convert.ToDouble(this.lblVAT.Text) : 0.0) / 100.0;
                }
                this.txtVAT.Text = num15.ToString();
                double num16 = 0.0;
                if (this.chkAT.Checked && Convert.ToDecimal(this.lblAT.Text.Trim()) > 0m)
                {
                    num16 = (((this.txtUnitPriceTotal.Text != "") ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0.0) + ((this.txtCD.Text != "") ? Convert.ToDouble(this.txtCD.Text.Trim()) : 0.0) + ((this.txtRD.Text != "") ? Convert.ToDouble(this.txtRD.Text.Trim()) : 0.0) + num12) * ((this.lblAT.Text != "") ? Convert.ToDouble(this.lblAT.Text) : 0.0) / 100.0;
                }
                this.txtAT.Text = num16.ToString();
                double num17 = 0.0;
                if (this.chkAIT.Checked && Convert.ToDecimal(this.lblAIT.Text.Trim()) > 0m)
                {
                    num17 = ((this.txtUnitPriceTotal.Text != "") ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0.0);
                }
                double num18 = num17 * Convert.ToDouble(this.lblAIT.Text) / 100.0;
                this.txtAIT.Text = num18.ToString();
                AddItemBLL addItemBLL = new AddItemBLL();
                decimal d = 0m;
                decimal num19 = 0m;
                int num20 = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num20);
                if (itemIsTeriff.Rows.Count > 0)
                {
                    bool flag = Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]);
                    if (flag)
                    {
                        DataTable itemVatAmountForImport = addItemBLL.getItemVatAmountForImport(num20);
                        if (itemVatAmountForImport.Rows.Count > 0)
                        {
                            d = Convert.ToDecimal(itemVatAmountForImport.Rows[0]["tax_value"]);
                            decimal d2 = Convert.ToDecimal(itemVatAmountForImport.Rows[0]["per"]);
                            decimal d3 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                            num19 = d * d3 / d2;
                        }
                    }
                    if (d > 0m)
                    {
                        this.txtVAT.Text = num19.ToString();
                    }
                }
                double num21 = 0.0;
                if (this.chkTaxDeducted.Checked)
                {
                    num21 = num15;
                }
                this.txtvdsamount.Text = num21.ToString("0.00");
                double num22 = 0.0;
                if (this.txtOCost.Text != "")
                {
                    num22 = Convert.ToDouble(this.txtOCost.Text);
                }
                double num23 = 0.0;
                if (this.txtDPFee.Text != "")
                {
                    num23 = Convert.ToDouble(this.txtDPFee.Text);
                }
                double num24 = 0.0;
                if (this.txtPSI.Text != "")
                {
                    num24 = Convert.ToDouble(this.txtPSI.Text);
                }
                double num25 = 0.0;
                if (this.txtCnFVat.Text != "")
                {
                    num25 = Convert.ToDouble(this.txtCnFVat.Text);
                }
                double num26 = 0.0;
                if (this.txtCnfCommission.Text != "")
                {
                    num26 = Convert.ToDouble(this.txtCnfCommission.Text);
                }
                double num27 = ((this.txtUnitPriceTotal.Text != "") ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0.0) + num9 + num11 + num12 + num15 + num16 + num18 + num23 + num22 + num25 + num26;
                double num28 = num9 + num11 + num12 + num15;
                this.lblTotal.Text = "Tk. " + num27.ToString("N2");
                this.txtTotalTax.Text = "Tk. " + num28.ToString("N2");
                double num29 = ((this.txtUnitPriceTotal.Text != "") ? Convert.ToDouble(this.txtUnitPriceTotal.Text.Trim()) : 0.0) + num9 + num11 + num12 + num15 + num23 + num22 + num24 + num26;
                this.lblTotalCost.Text = "Tk. " + num29.ToString("N2");
                double num30 = num16 + num18 + num25;
                this.lblRefund.Text = "Tk. " + num30.ToString("N2");
                this.lblPurchaseUnitPrice.Text = (num + num9 + num11 + num12).ToString("N2");
                this.lblPurchaseUnitPrice1.Text = "Tk. " + (num + num9 + num11 + num12).ToString("N2");
                return;
            }
            if (this.txtImportValue.Text != "")
            {
                Convert.ToDouble(this.txtImportValue.Text.Trim());
                double num2 = Convert.ToDouble(this.txtImportValue.Text.Trim());
                double num4 = num2 * 0.01;
                double num5 = num2 + num4;
                double num6 = num5 * 0.01;
                num = num5 + num6;
                this.txtUnitPriceTotal.Text = num.ToString("0.00");
            }
        }

        private void LoadHours()
    {
        this.drpChDtHr.Items.Add("00");
        this.drpDlDtHr.Items.Add("00");
        this.drpShipDtHr.Items.Add("00");
        this.drpRefChDtHr.Items.Add("00");
        for (int i = 1; i <= 23; i++)
        {
            this.drpChDtHr.Items.Add(i.ToString());
            this.drpDlDtHr.Items.Add(i.ToString());
            this.drpShipDtHr.Items.Add(i.ToString());
            this.drpRefChDtHr.Items.Add(i.ToString());
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
                setItemDAO.CategoryID = Convert.ToInt32(this.drpSubCategory.SelectedValue);
            }
            DataTable allItemByCategoryOrSubCat = addItemBLL.GetAllItemByCategoryOrSubCat(setItemDAO);
            this.drpItem.DataSource = allItemByCategoryOrSubCat;
            this.drpItem.DataTextField = allItemByCategoryOrSubCat.Columns["ITEM_NAME"].ToString();
            this.drpItem.DataValueField = allItemByCategoryOrSubCat.Columns["ITEM_ID"].ToString();
            this.drpItem.DataBind();
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpItem.Items.Insert(0, listItem);
            for (int i = 0; i < this.drpPropertyCollection.Count; i++)
            {
                this.drpPropertyCollection[i].SelectedIndex = 0;
                this.drpPropertyCollection[i].Enabled = false;
            }
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }

    private void LoadMinutes()
    {
        this.drpChDtMin.Items.Add("00");
        this.drpDlDtMin.Items.Add("00");
        this.drpShipDtMin.Items.Add("00");
        this.drpRefChDtMin.Items.Add("00");
        for (int i = 1; i <= 59; i++)
        {
            this.drpChDtMin.Items.Add(i.ToString());
            this.drpDlDtMin.Items.Add(i.ToString());
            this.drpShipDtMin.Items.Add(i.ToString());
            this.drpRefChDtMin.Items.Add(i.ToString());
        }
    }

    private void LoadPurchaseData()
    {
        SaleBLL saleBLL = new SaleBLL();
        DataTable dataTable = new DataTable();
        ChallanBLL challanBLL = new ChallanBLL();
        int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
        if (challanBLL.GetApproverStage().Rows.Count >= 1)
        {
            this.btnUpdateTransaction.Visible = true;
            ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LISTA"] ?? new ArrayList();
            DataTable import = saleBLL.getImport();
            if (import.Rows.Count > 0)
            {
                for (int i = 0; i < import.Rows.Count; i++)
                {
                    PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO()
                    {
                        ChallanID = Convert.ToInt32(import.Rows[i]["challan_id"])
                    };
                    string approveStagebyChallanId = this.getApproveStagebyChallanId(purchaseDetailDAO.ChallanID);
                    dataTable = (approveStagebyChallanId != "F" ? challanBLL.GetApproverStagebyEmployeeId(num, approveStagebyChallanId) : challanBLL.GetApproverStagebyEmployeeId(num, "4"));
                    if (dataTable.Rows.Count >= 1)
                    {
                        purchaseDetailDAO.ItemID = Convert.ToInt32(import.Rows[i]["item_id"]);
                        purchaseDetailDAO.ItemName = import.Rows[i]["item_name"].ToString();
                        purchaseDetailDAO.Quantity = Convert.ToDouble(import.Rows[i]["quantity"]);
                        purchaseDetailDAO.TempQuantity = Convert.ToDouble(import.Rows[i]["quantity"]);
                        purchaseDetailDAO.UnitID = Convert.ToInt32(import.Rows[i]["unit_id"]);
                        purchaseDetailDAO.PurchaseUnitPrice = Convert.ToDouble(import.Rows[i]["purchase_unit_price"]);
                        purchaseDetailDAO.UnitPriceBDT = Convert.ToDouble(import.Rows[i]["purchase_unit_price"]);
                        purchaseDetailDAO.UnitPriceTotal = Convert.ToDouble(import.Rows[i]["assesment_amount"]);
                        purchaseDetailDAO.TempUnitPrice = Convert.ToDouble(import.Rows[i]["purchase_unit_price"]);
                        purchaseDetailDAO.UnitName = import.Rows[i]["unit_code"].ToString();
                        purchaseDetailDAO.PurchaseVAT = Convert.ToDouble(import.Rows[i]["purchase_vat"]);
                        purchaseDetailDAO.PurchaseSD = Convert.ToDouble(import.Rows[i]["purchase_sd"]);
                        purchaseDetailDAO.AIT_Amount = Convert.ToDouble(import.Rows[i]["ait"]);
                        purchaseDetailDAO.SaleUnitPrice = Convert.ToDouble(import.Rows[i]["sale_unit_price"]);
                        purchaseDetailDAO.UnitSalePriceBDT = Convert.ToDouble(import.Rows[i]["sale_unit_price"]);
                        purchaseDetailDAO.SaleVAT = Convert.ToDouble(import.Rows[i]["sale_vat"]);
                        purchaseDetailDAO.SaleSD = Convert.ToDouble(import.Rows[i]["sale_sd"]);
                        purchaseDetailDAO.SaleVatablePrice = Convert.ToDouble(import.Rows[i]["sale_vatable_price"]);
                        purchaseDetailDAO.VDSAmount = Convert.ToDouble(import.Rows[i]["vds_amount"]);
                        purchaseDetailDAO.DocumentProcessingFee = Convert.ToDouble(import.Rows[i]["document_processing_fee"]);
                        purchaseDetailDAO.CnFVat = Convert.ToDouble(import.Rows[i]["cnf_vat"]);
                        purchaseDetailDAO.PSI = Convert.ToDouble(import.Rows[i]["psi"]);
                        purchaseDetailDAO.CnFCommission = Convert.ToDouble(import.Rows[i]["cnf_commission"]);
                        purchaseDetailDAO.VDSAmount = Convert.ToDouble(import.Rows[i]["vds_amount"]);
                        purchaseDetailDAO.VAT = Convert.ToDouble(import.Rows[i]["purchase_vat"]);
                        purchaseDetailDAO.IsSrcTAXDeduct = Convert.ToBoolean(import.Rows[i]["is_source_tax_deduct"]);
                        purchaseDetailDAO.IsCurrentMonthRebate = Convert.ToBoolean(import.Rows[i]["is_current_month_rebate"]);
                        purchaseDetailDAO.UserIdInsert = Convert.ToInt16(this.Session["employee_id"]);
                        purchaseDetailDAO.TotalPrice = Convert.ToDouble(import.Rows[i]["quantity"]) * Convert.ToDouble(import.Rows[i]["purchase_unit_price"]) + Convert.ToDouble(import.Rows[i]["purchase_sd"]);
                        purchaseDetailDAO.TotalPurchasePrice = purchaseDetailDAO.TotalPrice + purchaseDetailDAO.VAT;
                        purchaseDetailDAO.SDRate = Convert.ToDouble(import.Rows[i]["sd_rate"]);
                        purchaseDetailDAO.VATRate = Convert.ToDouble(import.Rows[i]["vat_rate"]);
                        purchaseDetailDAO.RemarksDetail = import.Rows[i]["remarks"].ToString();
                        purchaseDetailDAO.IsRebatable = Convert.ToBoolean(import.Rows[i]["is_rebatable"]);
                        purchaseDetailDAO.IsExempted = Convert.ToBoolean(import.Rows[i]["is_exempted"]);
                        purchaseDetailDAO.IsDeemedExport = Convert.ToBoolean(import.Rows[i]["is_deemedexport"]);
                        if (!Convert.ToBoolean(import.Rows[i]["is_source_tax_deduct"]))
                        {
                            purchaseDetailDAO.SrcTAXDeduct = "No";
                        }
                        else
                        {
                            purchaseDetailDAO.SrcTAXDeduct = "Yes";
                        }
                        if (!Convert.ToBoolean(import.Rows[i]["is_exempted"]))
                        {
                            purchaseDetailDAO.Exempted = "No";
                        }
                        else
                        {
                            purchaseDetailDAO.Exempted = "Yes";
                        }
                        if (!Convert.ToBoolean(import.Rows[i]["is_deemedexport"]))
                        {
                            purchaseDetailDAO.DeemedExport = "No";
                        }
                        else
                        {
                            purchaseDetailDAO.DeemedExport = "Yes";
                        }
                        if (!Convert.ToBoolean(import.Rows[i]["is_rebatable"]))
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
                        item.Add(purchaseDetailDAO);
                    }
                }
            }
            this.Session["PURCHASE_DETAIL_LISTA"] = item;
            this.AddApproveDetailDataInGrid();
        }
    }

    private void LoadSubCategory()
    {
        try
        {
            if (!(this.drpCategory.SelectedValue != "") || !(this.drpCategory.SelectedValue != "-99"))
            {
                this.drpSubCategory.DataSource = null;
                this.drpSubCategory.Items.Clear();
            }
            else
            {
                UtilityK.fillSubCategoryByCatDropDownList(this.drpCategory, this.drpSubCategory);
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
        if (this.txtChallanNo.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Bill of Entry No.", MsgBoxs.enmMessageType.Attention);
            this.txtChallanNo.Focus();
            return false;
        }
        if (this.txtShipmentDate.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Challan Date.", MsgBoxs.enmMessageType.Attention);
            this.txtShipmentDate.Focus();
            return false;
        }
        if (this.txtLCAmount.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert LC Amount.", MsgBoxs.enmMessageType.Attention);
            this.txtLCAmount.Focus();
            return false;
        }
        if (this.txtReleaseOrderNo.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Release Order No.", MsgBoxs.enmMessageType.Attention);
            this.txtReleaseOrderNo.Focus();
            return false;
        }
        if (this.txtReleaseOrderDate.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Release Order Date.", MsgBoxs.enmMessageType.Attention);
            this.txtReleaseOrderDate.Focus();
            return false;
        }
        if (this.drpParty.Enabled && this.drpParty.SelectedValue == "-99")
        {
            this.MsgBoxs.AddMessage("Select a Supplier Name.", MsgBoxs.enmMessageType.Attention);
            this.drpParty.Focus();
            return false;
        }
        if (this.txtTaxPayDate.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Tax Payment Date.", MsgBoxs.enmMessageType.Attention);
            this.txtTaxPayDate.Focus();
            return false;
        }
        if (this.txtExchangeRate.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Exchange Rate.", MsgBoxs.enmMessageType.Attention);
            this.txtExchangeRate.Focus();
            return false;
        }
        if (this.txtForeignAmount.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert LC Value.", MsgBoxs.enmMessageType.Attention);
            this.txtForeignAmount.Focus();
            return false;
        }
        if (this.drpCurrencyUnit.SelectedValue == "0")
        {
            this.MsgBoxs.AddMessage("Select Foreign Currency.", MsgBoxs.enmMessageType.Attention);
            this.drpCurrencyUnit.Focus();
            return false;
        }
        if (this.drpBank.SelectedValue == "0")
        {
            this.MsgBoxs.AddMessage("Select Bank.", MsgBoxs.enmMessageType.Attention);
            this.drpBank.Focus();
            return false;
        }
        if (this.drpBankBranch.SelectedValue == "0")
        {
            this.MsgBoxs.AddMessage("Select Branch.", MsgBoxs.enmMessageType.Attention);
            this.drpBankBranch.Focus();
            return false;
        }
        if (this.drpCPC.SelectedValue == "-99")
        {
            this.MsgBoxs.AddMessage("Select CPC.", MsgBoxs.enmMessageType.Attention);
            this.drpBankBranch.Focus();
            return false;
        }
        if (this.txtInsuranceAmount.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Insurance Amount.", MsgBoxs.enmMessageType.Attention);
            this.txtForeignAmount.Focus();
            return false;
        }
        if (this.txtInsuranceNo.Text.Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Insurance Number.", MsgBoxs.enmMessageType.Attention);
            this.txtForeignAmount.Focus();
            return false;
        }
        if (!this.drpParty.Enabled && this.txtPartyName.Text.Trim().Length == 0)
        {
            this.MsgBoxs.AddMessage("Insert Supplier Name.", MsgBoxs.enmMessageType.Attention);
            this.txtPartyName.Focus();
            return false;
        }
        ArrayList arrayLists = new ArrayList();
        arrayLists = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"];
        if (arrayLists != null && arrayLists.Count != 0)
        {
            return true;
        }
        this.gvItem.DataSource = null;
        this.gvItem.DataBind();
        this.MsgBoxs.AddMessage("Please Add Item First.", MsgBoxs.enmMessageType.Error);
        return false;
    }

    public static string NumberToWords(int number)
    {
        if (number == 0)
        {
            return "zero";
        }
        if (number < 0)
        {
            return string.Concat("minus ", NumberToWords(Math.Abs(number)));
        }
        string str = "";
        if (number / 1000000 > 0)
        {
            str = string.Concat(str, NumberToWords(number / 1000000), " million ");
            number %= 1000000;
        }
        if (number / 1000 > 0)
        {
            str = string.Concat(str, NumberToWords(number / 1000), " thousand ");
            number %= 1000;
        }
        if (number / 100 > 0)
        {
            str = string.Concat(str, NumberToWords(number / 100), " hundred ");
            number %= 100;
        }
        if (number > 0)
        {
            if (str != "")
            {
                str = string.Concat(str, "and ");
            }
            string[] strArrays = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] strArrays1 = strArrays;
            string[] strArrays2 = new string[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] strArrays3 = strArrays2;
            if (number >= 20)
            {
                str = string.Concat(str, strArrays3[number / 10]);
                if (number % 10 > 0)
                {
                    str = string.Concat(str, "-", strArrays1[number % 10]);
                }
            }
            else
            {
                str = string.Concat(str, strArrays1[number]);
            }
        }
        return str;
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
                this.Session["PURCHASE_DETAIL_LISTA"] = new ArrayList();
                this.Page.Form.Attributes.Add("enctype", "multipart/form-data");
                this.fillPortCode(this.drpPortCode);
                Util.fillBank(this.drpBank);
                Util.fillCurrencyUnit(this.drpCurrencyUnit);
                TextBox str = this.txtChallanDate;
                DateTime now = DateTime.Now;
                str.Text = now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                this.LoadHours();
                this.LoadMinutes();
                this.LoadPurchaseData();
                this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                this.drpShipDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpShipDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                this.drpDlDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpDlDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                this.drpRefChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpRefChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                this.lblOrgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.lblOrgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.lblOrgTIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                Util.fillPartyName(this.drpParty);
                Util.fillCountry(this.drpCountry);
                this.chkRebateCurrent.Checked = true;
                this.Session["Bill_of_entry_DETAIL_LIST"] = new ArrayList();
                this.Session["PARTY_INFO"] = new DataTable();
                this.Session["IMPORT_DETAIL_LIST"] = new ArrayList();
                this.Session["Purchase_Master_LIST"] = new ArrayList();
                this.Session["Purchase_EXCEL"] = new ArrayList();
                this.dtpBillOfEntryDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.txtShipmentDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.convertShipmentDateTime();
                this.txtDeliveryDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.convertDeliveryDateTime();
                this.SetSystemUsedProperties();
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                this.GetPartyInfo();
                this.GetCPCCode();
                this.dtpLCDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.txtReleaseOrderDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("-- Select --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem1);
                this.LoadItems();
                ListItem listItem2 = new ListItem("-- Select --", "-99");
                this.GetBranchInformation();
                this.part_a.Visible = true;
                this.part_b.Visible = true;
                this.part_c.Visible = true;
                this.part_e.Visible = false;
                base.Request.RawUrl.ToString();
                string str1 = this.Session["ORGANIZATION_ID"].ToString();
                string str2 = this.Session["ORGBRANCHID"].ToString();
                DataTable dataTable = this.permissionBLL.CheckPaymentMethodPermision(str1, str2, "/UI/Purchase/BillOfEntry_6.3.aspx");
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

    protected void payment_CheckedChanged(object sender, EventArgs e)
    {
        this.mpe.Show();
    }

    protected void productName_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.getProductInfo();
            this.EnableOrDisablePropertyForItem();
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }

    private void RefreshForm()
    {
        this.ClearDetailControlsValue();
        this.lblOrgTIN.Text = "";
        this.lblOrgAddress.Text = "";
        this.dtpBillOfEntryDate.Text = "";
        this.drpDlDtHr.SelectedItem.Text = "1";
        this.drpDlDtMin.SelectedItem.Text = "1";
        this.drpChDtHr.SelectedItem.Text = "1";
        this.drpChDtMin.SelectedItem.Text = "1";
        this.txtShipmentDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
        this.txtDeliveryDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
        this.convertShipmentDateTime();
        this.convertDeliveryDateTime();
        this.drpCategory.SelectedValue = "-99";
        this.drpItem.SelectedValue = "-99";
        this.Session["Bill_of_Entry_DETAIL_LIST"] = new DataSet();
        this.gvItem.DataSource = null;
        this.gvItem.DataBind();
    }

    private void SetAddMode()
    {
        this.btnSave.Text = enmBtnText.Save.ToString();
    }

    private void setDetaiAddMode()
    {
        this.btnAdd.Text = "Add Item";
    }

    private void setDetailUpdateMode()
    {
        this.btnAdd.Text = enmBtnText.Update.ToString();
    }

    private void setMainAddMode()
    {
        this.btnSave.Text = enmBtnText.Save.ToString();
        this.btnClear.Text = enmBtnText.Clear.ToString();
    }

    private void setMainUpdateMode()
    {
        this.btnSave.Text = enmBtnText.Update.ToString();
        this.btnClear.Text = enmBtnText.Cancel.ToString();
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

    private void showCatSubCat()
    {
        SaleBLL saleBLL = new SaleBLL();
        try
        {
            int num = Convert.ToInt32(this.drpItem.SelectedValue);
            DataTable catSubCat = saleBLL.getCatSubCat(num);
            ListItem listItem = new ListItem("---Select---", "-99");
            if (catSubCat != null)
            {
                this.drpCategory.DataSource = catSubCat;
                this.drpCategory.DataTextField = catSubCat.Columns["category_name"].ToString();
                this.drpCategory.DataValueField = catSubCat.Columns["sub_category_id"].ToString();
                this.drpCategory.DataBind();
                this.drpSubCategory.DataSource = catSubCat;
                this.drpSubCategory.DataTextField = catSubCat.Columns["sub_category_name"].ToString();
                this.drpSubCategory.DataValueField = catSubCat.Columns["sub_category_id"].ToString();
                this.drpSubCategory.DataBind();
                this.lblUnit.Text = catSubCat.Rows[0]["unit_code"].ToString();
                this.lblUnitId.Text = catSubCat.Rows[0]["unit_id"].ToString();
                this.lblProductType.Text = catSubCat.Rows[0]["item_type"].ToString();
                this.lblSku.Text = catSubCat.Rows[0]["item_sku"].ToString();
            }
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }

    private void ShowDetailDataForEdit(PurchaseDetailDAO objDetailDAO)
    {
        this.LoadItems();
        this.drpItem.SelectedValue = objDetailDAO.ItemID.ToString();
        if (this.drpItem.SelectedValue == "-99")
        {
            this.lblHSCode.Text = "";
        }
        else
        {
            string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
            if (strArrays != null && strArrays.Count<string>() > 0)
            {
                this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 2];
            }
            if (this.txtQuantity.Text.Count<char>() > 0 && this.txtUnitPrice.Text.Count<char>() > 0)
            {
                TextBox str = this.txtUnitPriceTotal;
                double num = Convert.ToDouble(this.txtUnitPrice.Text) * Convert.ToDouble(this.txtQuantity.Text);
                str.Text = num.ToString();
                this.InsertTaxValues();
            }
            AddItemBLL addItemBLL = new AddItemBLL();
            int num1 = 0;
            num1 = Convert.ToInt32(this.drpItem.SelectedValue);
            DataTable truncated = addItemBLL.getTruncated(num1);
            if (truncated.Rows.Count > 0)
            {
                this.HiddenIsTruncated.Value = null;
                if (!Convert.ToBoolean(truncated.Rows[0]["is_truncated"]))
                {
                    this.HiddenIsTruncated.Value = null;
                }
                else
                {
                    this.HiddenIsTruncated.Value = "is_truncated";
                }
            }
            this.chkZeroRate.Checked = false;
            DataTable itemIsZeroRate = addItemBLL.getItemIsZeroRate(num1);
            if (itemIsZeroRate.Rows.Count > 0 && Convert.ToBoolean(itemIsZeroRate.Rows[0]["is_zero_rate"]))
            {
                this.chkZeroRate.Checked = true;
                this.chkZeroRate.Attributes["style"] = "color:Green;";
            }
            this.showCatSubCat();
            this.CalculateTaxValues();
            this.EnableOrDisablePropertyForItem();
        }
        this.txtQuantity.Text = objDetailDAO.Quantity.ToString();
        this.lblUnit.Text = objDetailDAO.UnitName;
        this.hdUnitID.Value = objDetailDAO.UnitID.ToString();
        this.txtUnitPrice.Text = objDetailDAO.UnitPriceBDT.ToString();
        this.txtSD.Text = objDetailDAO.SD.ToString();
        this.txtVAT.Text = objDetailDAO.VAT.ToString();
        this.txtCD.Text = objDetailDAO.CD.ToString();
        this.txtRD.Text = objDetailDAO.RD.ToString();
        this.txtAIT.Text = objDetailDAO.AIT.ToString();
        this.txtATV.Text = objDetailDAO.ATV.ToString();
        this.txtTTI.Text = objDetailDAO.TTI.ToString();
        this.txtAT.Text = objDetailDAO.AT.ToString();
        this.txtUnitPriceTotal.Text = objDetailDAO.UnitPriceTotal.ToString();
        this.txtImportValue.Text = objDetailDAO.ImportValue.ToString();
        this.txtDPFee.Text = objDetailDAO.DocumentProcessingFee.ToString();
        this.txtOCost.Text = objDetailDAO.OthersPrice.ToString();
        this.txtCnFVat.Text = objDetailDAO.CnFVat.ToString();
        this.txtPSI.Text = objDetailDAO.PSI.ToString();
        this.txtCnfCommission.Text = objDetailDAO.CnFCommission.ToString();
        this.txtCommission.Text = objDetailDAO.Commission.ToString();
        this.txtCSF.Text = objDetailDAO.CSF.ToString();
        this.txtvdsamount.Text = objDetailDAO.VDSAmount.ToString();
        Label label = this.lblTotal;
        double totalPrice = objDetailDAO.TotalPrice;
        label.Text = string.Concat("Tk. ", totalPrice.ToString());
        Label label1 = this.txtTotalTax;
        double totalTax = objDetailDAO.TotalTax;
        label1.Text = string.Concat("Tk. ", totalTax.ToString());
        Label label2 = this.lblTotalCost;
        double cost = objDetailDAO.Cost;
        label2.Text = string.Concat("Tk. ", cost.ToString());
        Label label3 = this.lblRefund;
        double refundPrice = objDetailDAO.RefundPrice;
        label3.Text = string.Concat("Tk. ", refundPrice.ToString());
        Label label4 = this.lblPurchaseUnitPrice1;
        double totalPricet = objDetailDAO.TotalPricet;
        label4.Text = string.Concat("Tk. ", totalPricet.ToString());
        this.singleRemarks.Text = objDetailDAO.RemarksDetail.ToString();
        this.chkIsWar.Checked = objDetailDAO.IsWar;
        this.chkTaxDeducted.Checked = objDetailDAO.IsSrcTAXDeduct;
        this.chkRebatable.Checked = objDetailDAO.IsRebatable;
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
            if (permissions.Rows[i]["payment_method_name"].ToString() == "Deferred")
            {
                this.chkDeferred.Visible = true;
            }
            if (permissions.Rows[i]["payment_method_name"].ToString() == "At Sight")
            {
                this.chkAtSight.Visible = true;
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

    private void showReportData()
    {
        PurchaseMasterDAO purchaseMasterDAO = new PurchaseMasterDAO();
        try
        {
            purchaseMasterDAO = this.GetInserMasterValues(purchaseMasterDAO);
            this.lblChallanNo.Text = purchaseMasterDAO.ChallanNo;
            this.lblBoENo.Text = purchaseMasterDAO.BLNo;
            this.lblBoEDate.Text = purchaseMasterDAO.BLDate.ToShortDateString();
            this.lblLCNo.Text = purchaseMasterDAO.LCNo;
            this.lblLCDate.Text = purchaseMasterDAO.LCDate.ToShortDateString();
            this.lblLCAmount.Text = purchaseMasterDAO.LCAmount.ToString();
            Label label = this.lblLCValue;
            double lCForeignAmount = purchaseMasterDAO.LCForeignAmount;
            label.Text = string.Concat(lCForeignAmount.ToString(), " ", purchaseMasterDAO.LCForeignCurrency);
            this.lblShippmentDate.Text = purchaseMasterDAO.ShipmentDate.ToShortDateString();
            this.lblReleaseOrderNo.Text = purchaseMasterDAO.ReleaseOrderNo.ToString();
            this.lblReleaseOrderDate.Text = purchaseMasterDAO.ReleaseOrderDate.ToShortDateString();
            this.lblSupplierName.Text = purchaseMasterDAO.SupplierName;
            this.lblSupplierCountry.Text = purchaseMasterDAO.SupplierCounty;
            ArrayList item = (ArrayList)this.Session["Bill_of_Entry_DETAIL_LIST"];
            if (item != null)
            {
                string str = "";
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                for (int i = 0; i < item.Count; i++)
                {
                    purchaseDetailDAO = (PurchaseDetailDAO)item[i];
                    str = string.Concat(str, "<tr>");
                    object obj = str;
                    object[] objArray = new object[] { obj, "<td style='width:5%;text-align:center;border:1px solid gray'>", i + 1, "</td>" };
                    str = string.Concat(objArray);
                    str = string.Concat(str, "<td style='width:15%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.ItemName, "</td>");
                    object obj1 = str;
                    object[] quantity = new object[] { obj1, "<td style='width:5%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.Quantity, "</td>" };
                    str = string.Concat(quantity);
                    str = string.Concat(str, "<td style='width:2%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.UnitName, "</td>");
                    object obj2 = str;
                    object[] unitPriceBDT = new object[] { obj2, "<td style='width:15%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.UnitPriceBDT, "</td>" };
                    str = string.Concat(unitPriceBDT);
                    object obj3 = str;
                    object[] cD = new object[] { obj3, "<td style='width:5%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.CD, "</td>" };
                    str = string.Concat(cD);
                    object obj4 = str;
                    object[] rD = new object[] { obj4, "<td style='width:5%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.RD, "</td>" };
                    str = string.Concat(rD);
                    object obj5 = str;
                    object[] sD = new object[] { obj5, "<td style='width:5%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.SD, "</td>" };
                    str = string.Concat(sD);
                    object obj6 = str;
                    object[] vAT = new object[] { obj6, "<td style='width:5%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.VAT, "</td>" };
                    str = string.Concat(vAT);
                    object obj7 = str;
                    object[] aTV = new object[] { obj7, "<td style='width:2%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.ATV, "</td>" };
                    str = string.Concat(aTV);
                    object obj8 = str;
                    object[] tTI = new object[] { obj8, "<td style='width:2%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.TTI, "</td>" };
                    str = string.Concat(tTI);
                    object obj9 = str;
                    object[] aIT = new object[] { obj9, "<td style='width:2%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.AIT, "</td>" };
                    str = string.Concat(aIT);
                    object obj10 = str;
                    object[] othersPrice = new object[] { obj10, "<td style='width:5%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.OthersPrice, "</td>" };
                    str = string.Concat(othersPrice);
                    object obj11 = str;
                    object[] documentProcessingFee = new object[] { obj11, "<td style='width:5%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.DocumentProcessingFee, "</td>" };
                    str = string.Concat(documentProcessingFee);
                    object obj12 = str;
                    object[] unitPriceTotal = new object[] { obj12, "<td style='width:10%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.UnitPriceTotal, "</td>" };
                    str = string.Concat(unitPriceTotal);
                    object obj13 = str;
                    object[] totalPrice = new object[] { obj13, "<td style='width:15%;text-align:left;border:1px solid gray'>", purchaseDetailDAO.TotalPrice, "</td>" };
                    str = string.Concat(totalPrice);
                    str = string.Concat(str, "</tr>");
                    this.lblBillofEntryReport.Text = str;
                }
            }
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }

    protected void txtChallanDate_TextChanged(object sender, EventArgs e)
    {
        this.convertShipmentDateTime();
    }

    protected void txtCnfCommissiont_textChanged(object sender, EventArgs e)
    {
        this.InsertTaxValues();
    }

    protected void txtCnFVat_textChanged(object sender, EventArgs e)
    {
        this.InsertTaxValues();
    }

    protected void txtDeliveryDate_TextChanged(object sender, EventArgs e)
    {
        this.convertDeliveryDateTime();
    }

    protected void txtDPFee_textChanged(object sender, EventArgs e)
    {
        this.InsertTaxValues();
    }

    protected void txtExchangeRate_Click(object sender, EventArgs e)
    {
        decimal num = new decimal(0);
        decimal num1 = (!string.IsNullOrEmpty(this.txtLCAmount.Text.ToString()) ? Convert.ToDecimal(this.txtLCAmount.Text) : new decimal(0));
        if (num1 <= new decimal(0))
        {
            this.txtForeignAmount.Text = "";
            return;
        }
        num = num1 / Convert.ToDecimal(this.txtExchangeRate.Text);
        this.txtForeignAmount.Text = num.ToString();
    }

    protected void txtImportValue_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.InsertTaxValues();
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }

    protected void txtLCAmount_Click(object sender, EventArgs e)
    {
        decimal num = new decimal(0);
        decimal num1 = (!string.IsNullOrEmpty(this.txtExchangeRate.Text.ToString()) ? Convert.ToDecimal(this.txtExchangeRate.Text) : new decimal(1));
        if (num1 == new decimal(0))
        {
            this.MsgBoxs.AddMessage("Exchange rate can't be 0.", MsgBoxs.enmMessageType.Attention);
        }
        if (num1 <= new decimal(1))
        {
            this.txtForeignAmount.Text = "";
            return;
        }
        num = Convert.ToDecimal(this.txtLCAmount.Text) / num1;
        this.txtForeignAmount.Text = num.ToString();
    }

    protected void txtOCost_textChanged(object sender, EventArgs e)
    {
        this.InsertTaxValues();
    }

    protected void txtPSI_textChanged(object sender, EventArgs e)
    {
        this.InsertTaxValues();
    }

    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        double num = 0;
        if (!(this.drpItem.SelectedValue != "-99") || this.txtUnitPrice.Text.Count<char>() <= 0)
        {
            if (this.drpItem.SelectedValue != "-99" && this.txtImportValue.Text.Count<char>() > 0)
            {
                this.InsertTaxValues();
                return;
            }
            this.InsertTaxValues();
            return;
        }
        num = Convert.ToDouble(this.txtUnitPrice.Text);
        this.txtImportValue.Text = (num * (!string.IsNullOrEmpty(this.txtQuantity.Text.ToString()) ? Convert.ToDouble(this.txtQuantity.Text) : 0)).ToString();
        this.InsertTaxValues();
    }

    protected void txtTotalPrice_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.InsertAssessTaxValuesAssessedChanged();
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }

    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
    {
        double num = 0;
        double num1 = 0;
        if (this.drpItem.SelectedValue != "-99" && this.txtUnitPrice.Text.Count<char>() > 0)
        {
            num = Convert.ToDouble(this.txtUnitPrice.Text);
            num1 = Convert.ToDouble(this.txtQuantity.Text);
            this.txtImportValue.Text = (num * num1).ToString();
            this.InsertTaxValues();
        }
    }

    private bool Validation()
    {
        if (this.drpItem.SelectedValue == "-99")
        {
            this.MsgBoxs.AddMessage("Select an Item.", MsgBoxs.enmMessageType.Error);
            this.drpItem.Focus();
            return false;
        }
        if (this.txtQuantity.Text.Trim().Length < 1)
        {
            this.MsgBoxs.AddMessage("Enter Quantity", MsgBoxs.enmMessageType.Error);
            this.txtQuantity.Focus();
            return false;
        }
        if (this.txtUnitPrice.Text.Trim().Length < 1)
        {
            this.MsgBoxs.AddMessage("Enter Unit Price", MsgBoxs.enmMessageType.Error);
            this.txtUnitPrice.Focus();
            return false;
        }
        if (this.chkTTI.Checked && this.txtInsuranceAmount.Text.Count<char>() < 1)
        {
            this.lblMessage.Text = "Insurance Amount  is mandatory. ";
            this.txtInsuranceAmount.Focus();
            return false;
        }
        if (!this.chkExcel.Checked)
        {
            if (this.drpProperty1.Visible && this.drpProperty1.SelectedValue == "-99")
            {
                this.MsgBoxs.AddMessage(string.Concat("Please select ", this.lblProperty1.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty2.Visible && this.drpProperty2.SelectedValue == "-99")
            {
                this.MsgBoxs.AddMessage(string.Concat("Please select ", this.lblProperty2.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty3.Visible && this.drpProperty3.SelectedValue == "-99")
            {
                this.MsgBoxs.AddMessage(string.Concat("Please select ", this.lblProperty3.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty4.Visible && this.drpProperty4.SelectedValue == "-99")
            {
                this.MsgBoxs.AddMessage(string.Concat("Please select ", this.lblProperty4.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty5.Visible && this.drpProperty5.SelectedValue == "-99")
            {
                this.MsgBoxs.AddMessage(string.Concat("Please select ", this.lblProperty5.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
        }
        ArrayList item = (ArrayList)this.Session["ProductionRcv_EXCEL"];
        if (item == null || item.Count <= 0 || item.Count == Convert.ToInt16(this.txtQuantity.Text))
        {
            return true;
        }
        this.MsgBoxs.AddMessage("Quantity and No of Additional Property are not equal", MsgBoxs.enmMessageType.Attention);
        this.txtQuantity.Focus();
        return false;
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
            WrittenNumerics.ones = strArrays;
            string[] strArrays1 = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            WrittenNumerics.teens = strArrays1;
            string[] strArrays2 = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            WrittenNumerics.tens = strArrays2;
            string[] strArrays3 = new string[] { "", " Thousand", " Million", " Billion" };
            WrittenNumerics.thousandsGroups = strArrays3;
        }

        public static string DateToWritten(DateTime date)
        {
            return string.Format("{0} {1} {2}", WrittenNumerics.IntegerToWritten(date.Day), date.ToString("MMMM"), WrittenNumerics.IntegerToWritten(date.Year));
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
                str = string.Concat(str, WrittenNumerics.ones[n]);
            }
            else if (n < 20)
            {
                str = string.Concat(str, WrittenNumerics.teens[n - 10]);
            }
            else if (n >= 100)
            {
                str = (n >= 1000 ? string.Concat(str, WrittenNumerics.FriendlyInteger(n % 1000, WrittenNumerics.FriendlyInteger(n / 1000, "", thousands + 1), 0)) : string.Concat(str, WrittenNumerics.FriendlyInteger(n % 100, string.Concat(WrittenNumerics.ones[n / 100], " Hundred"), 0)));
            }
            else
            {
                str = string.Concat(str, WrittenNumerics.FriendlyInteger(n % 10, WrittenNumerics.tens[n / 10 - 2], 0));
            }
            return string.Concat(str, WrittenNumerics.thousandsGroups[thousands]);
        }

        public static string IntegerToWritten(int n)
        {
            if (n == 0)
            {
                return "Zero";
            }
            if (n >= 0)
            {
                return WrittenNumerics.FriendlyInteger(n, "", 0);
            }
            return string.Concat("Negative ", WrittenNumerics.IntegerToWritten(-n));
        }
    }

        
    }
}