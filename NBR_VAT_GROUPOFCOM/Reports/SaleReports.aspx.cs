using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class SaleReports : Page, IRequiresSessionState
    {
        private PeriodicReportBLL dbBLL = new PeriodicReportBLL();

        private OrgRegistrationInfoDAO orgRegInfo = new OrgRegistrationInfoDAO();

        private trnsSaleMasterBLL objtrnsSaleMasterBLL = new trnsSaleMasterBLL();

        private AddItemBLL dbLL = new AddItemBLL();

        private ExcelUtility excelUtility = new ExcelUtility();

      
        public SaleReports()
        {
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Periodic Sale Report";
                HSSFWorkbook hSSFWorkbook = new HSSFWorkbook();
                ISheet sheet = hSSFWorkbook.CreateSheet(str);
                HSSFCellStyle hSSFCellStyle = this.excelUtility.headerBorderStyle(hSSFWorkbook);
                this.GenerateHeader(hSSFWorkbook, sheet, hSSFCellStyle);
                this.showReport("excel", sheet, hSSFCellStyle, hSSFWorkbook);
                this.excelUtility.downloadExcel(hSSFWorkbook, sheet, base.Response, str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.showCatSubCat();
                this.LoadProperty();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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

        private void FillDropdown()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.objtrnsSaleMasterBLL.GetSkuNo();
                DataTable allItemForSale = this.dbBLL.GetAllItemForSale();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.ddlSKU.DataSource = dataTable;
                    this.ddlSKU.DataTextField = dataTable.Columns["item_sku"].ToString();
                    this.ddlSKU.DataValueField = dataTable.Columns["item_id"].ToString();
                    this.ddlSKU.DataBind();
                }
                this.ddlSKU.Items.Insert(0, new ListItem("---SELECT---", "-1"));
                if (allItemForSale != null && allItemForSale.Rows.Count > 0)
                {
                    this.ddlItem.DataSource = allItemForSale;
                    this.ddlItem.DataTextField = allItemForSale.Columns["item_name"].ToString();
                    this.ddlItem.DataValueField = allItemForSale.Columns["item_id"].ToString();
                    this.ddlItem.DataBind();
                }
                DataTable allCustomerForSale = this.dbBLL.GetAllCustomerForSale();
                if (allCustomerForSale != null && allCustomerForSale.Rows.Count > 0)
                {
                    this.ddlSupplier.DataSource = allCustomerForSale;
                    this.ddlSupplier.DataTextField = allCustomerForSale.Columns["party_name"].ToString();
                    this.ddlSupplier.DataValueField = allCustomerForSale.Columns["party_id"].ToString();
                    this.ddlSupplier.DataBind();
                }
                DataTable allAggrementNoForSale = this.dbBLL.GetAllAggrementNoForSale();
                if (allAggrementNoForSale != null && allAggrementNoForSale.Rows.Count > 0)
                {
                    this.ddlAggrementNo.DataSource = allAggrementNoForSale;
                    this.ddlAggrementNo.DataTextField = allAggrementNoForSale.Columns["aggrement_no"].ToString();
                    this.ddlAggrementNo.DataValueField = allAggrementNoForSale.Columns["aggrement_no"].ToString();
                    this.ddlAggrementNo.DataBind();
                }
                this.ddlItem.Items.Insert(0, new ListItem("---Select Item---", "-1"));
                this.ddlSupplier.Items.Insert(0, new ListItem("---Select Customer---", "-1"));
                this.ddlAggrementNo.Items.Insert(0, new ListItem("---Select Aggrement No---", "-1"));
                this.drpSaleType.Items.Insert(0, new ListItem("---Select Transaction Type---", "-1"));
                this.drpSaleType.Items.Insert(1, new ListItem("Local Sale", "L"));
                this.drpSaleType.Items.Insert(2, new ListItem("Export Sale", "E"));
                this.drpItemCategory.Items.Insert(0, new ListItem("---Select Item Category---", "-1"));
                this.drpItemCategory.Items.Insert(1, new ListItem("Goods", "G"));
                this.drpItemCategory.Items.Insert(2, new ListItem("Service", "S"));
                this.drpItemCategory.Items.Insert(3, new ListItem("Both", "B"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void GenerateHeader(HSSFWorkbook workbook, ISheet sheet, HSSFCellStyle headerStyle)
        {
            IRow rows = sheet.CreateRow(0);
            IRow rows1 = sheet.CreateRow(2);
            this.excelUtility.CreateCell(rows, 0, "Periodic Sale Report", headerStyle);
            this.excelUtility.CreateCell(rows1, 0, "Voucher Date", headerStyle);
            this.excelUtility.CreateCell(rows1, 1, "Party Name", headerStyle);
            this.excelUtility.CreateCell(rows1, 2, "Challan No", headerStyle);
            this.excelUtility.CreateCell(rows1, 3, "Agreement No", headerStyle);
            this.excelUtility.CreateCell(rows1, 4, "Item", headerStyle);
            this.excelUtility.CreateCell(rows1, 5, "Quantity", headerStyle);
            this.excelUtility.CreateCell(rows1, 6, "Unit Price", headerStyle);
            this.excelUtility.CreateCell(rows1, 7, "VAT", headerStyle);
            this.excelUtility.CreateCell(rows1, 8, "SD", headerStyle);
            this.excelUtility.CreateCell(rows1, 9, "Value", headerStyle);
            this.excelUtility.CreateCell(rows1, 10, "Value(consolidated)", headerStyle);
            this.excelUtility.MergeCell(workbook, sheet, 0, 1, 0, 10);
        }

        private void GetDataExcel(int rowIndex, string displayHtml, int j, DataTable dt, string dateChallan, string partyname, string challan_No, string sQuantity, string item, string unitCode, decimal unitprice, string vatAndRate, string sdAndRate, decimal value, decimal ConValue, ISheet sheet, HSSFCellStyle headerStyle, string Item_sku, string addtnProp, string prop)
        {
            try
            {
                int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                IRow rows = sheet.CreateRow(rowIndex);
                this.excelUtility.CreateCell(rows, 0, dateChallan ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 1, partyname ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 2, challan_No ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 3, dt.Rows[j]["aggrement_no"].ToString() ?? "", headerStyle);
                ExcelUtility excelUtility = this.excelUtility;
                string[] strArrays = new string[] { item, " ", addtnProp, " ", null };
                string str = prop.Trim();
                char[] chrArray = new char[] { ',' };
                strArrays[4] = str.TrimEnd(chrArray);
                excelUtility.CreateCell(rows, 4, string.Concat(strArrays), headerStyle);
                this.excelUtility.CreateCell(rows, 5, string.Concat(sQuantity, "(", unitCode, ")"), headerStyle);
                this.excelUtility.CreateCell(rows, 6, Utilities.RoundUpToWithString(unitprice, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 7, vatAndRate ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 8, sdAndRate ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 9, Utilities.RoundUpToWithString(value, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 10, Utilities.RoundUpToWithString(ConValue, num) ?? "", headerStyle);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private string GetDataHtml(string displayHtml, int j, DataTable dt, string dateChallan, string partyname, string challan_No, string sQuantity, string item, string unitCode, decimal unitprice, string vatAndRate, string sdAndRate, decimal value, decimal ConValue, string itemSKU, string addtnProp, string prop)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            int count = dt.Rows.Count;
            displayHtml = string.Concat(displayHtml, "<tr style = 'background-color: White'>");
            if (j == 0)
            {
                object obj = displayHtml;
                object[] objArray = new object[] { obj, "<td rowspan = '", count, "' class='style10' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", dateChallan, "</td>" };
                displayHtml = string.Concat(objArray);
                object obj1 = displayHtml;
                object[] objArray1 = new object[] { obj1, "<td rowspan = '", count, "' class='style11' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", partyname, "</td>" };
                displayHtml = string.Concat(objArray1);
                object obj2 = displayHtml;
                object[] challanNo = new object[] { obj2, "<td rowspan = '", count, "' class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px;'>", challan_No, "</td>" };
                displayHtml = string.Concat(challanNo);
                object obj3 = displayHtml;
                object[] str = new object[] { obj3, "<td rowspan = '", count, "' class='style11' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", dt.Rows[j]["aggrement_no"].ToString(), "</td>" };
                displayHtml = string.Concat(str);
            }
            string str1 = displayHtml;
            string[] strArrays = new string[] { str1, "<td class='style13' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", item, addtnProp, " ", null, null };
            string str2 = prop.Trim();
            char[] chrArray = new char[] { ',' };
            strArrays[5] = str2.TrimEnd(chrArray);
            strArrays[6] = "</td>";
            displayHtml = string.Concat(strArrays);
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", itemSKU, "</td>");
            if (sQuantity != "0")
            {
                string str3 = displayHtml;
                string[] strArrays1 = new string[] { str3, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", sQuantity, "(", unitCode, ")</td>" };
                displayHtml = string.Concat(strArrays1);
            }
            else
            {
                displayHtml = string.Concat(displayHtml, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>-</td>");
            }
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(unitprice, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", vatAndRate, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", sdAndRate, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(value, num), "</td>");
            if (j == 0)
            {
                object obj4 = displayHtml;
                object[] withString = new object[] { obj4, "<td rowspan = '", count, "' class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(ConValue, num), "</td>" };
                displayHtml = string.Concat(withString);
            }
            return displayHtml;
        }

        private void GetTotalExcel(string displayHtml, int rowIndex, decimal Total1, decimal Total2, int precision, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            IRow rows = sheet.CreateRow(rowIndex);
            this.excelUtility.CreateCell(rows, 0, "Total", headerStyle);
            this.excelUtility.CreateCell(rows, 9, Utilities.RoundUpToWithString(Total1, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 10, Utilities.RoundUpToWithString(Total2, precision) ?? "", headerStyle);
            this.excelUtility.MergeCell(workbook, sheet, rowIndex, rowIndex, 0, 8);
        }

        private string GetTotalHtml(string displayHtml, decimal Total1, decimal Total2, int precision)
        {
            displayHtml = string.Concat(displayHtml, "<tr style = 'background-color: White'>");
            displayHtml = string.Concat(displayHtml, "<td colspan='10' class='style11' style='width: 10% ;border-style:solid;border-width:1px;text-align:right; padding-right: 15px; font-weight:bold'>Total</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(Total1, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(Total2, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private void LoadCategory()
        {
            try
            {
                DataTable dataTable = new DataTable();
                AddItemBLL addItemBLL = new AddItemBLL();
                if (this.drpSubCategory.SelectedValue != "" && this.drpSubCategory.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                    dataTable = addItemBLL.GetCategoryBySubCategoryID(num);
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

        private void LoadItemsByCatgSubCatg()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO()
                {
                    CategoryID = (Convert.ToInt32(this.drpCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpCategory.SelectedValue) : 0),
                    SubCatgID = (Convert.ToInt32(this.drpSubCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpSubCategory.SelectedValue) : 0)
                };
                DataTable allItemForSalebyCatgSubCatg = addItemBLL.GetAllItemForSalebyCatgSubCatg(setItemDAO);
                this.ddlItem.DataSource = allItemForSalebyCatgSubCatg;
                this.ddlItem.DataTextField = allItemForSalebyCatgSubCatg.Columns["ITEM_NAME"].ToString();
                this.ddlItem.DataValueField = allItemForSalebyCatgSubCatg.Columns["ITEM_ID"].ToString();
                this.ddlItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.ddlItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadProperty()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (this.ddlItem.SelectedValue != "" && this.ddlItem.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.ddlItem.SelectedValue);
                    dataTable = this.dbLL.GetPropertybyItemID(num);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpProperty.DataSource = dataTable;
                        this.drpProperty.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProperty.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProperty.DataBind();
                    }
                }
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpProperty.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
            }
        }

        private void LoadPropertyF()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (this.ddlItem.SelectedValue != "" && this.ddlItem.SelectedValue != "-99")
                {
                    Convert.ToInt32(this.ddlItem.SelectedValue);
                    dataTable = this.dbLL.GetProperty();
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpProperty.DataSource = dataTable;
                        this.drpProperty.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProperty.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProperty.DataBind();
                    }
                }
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpProperty.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
            }
        }

        private void LoadSubCategory()
        {
            try
            {
                DataTable dataTable = new DataTable();
                AddItemBLL addItemBLL = new AddItemBLL();
                if (this.drpCategory.SelectedValue != "" && this.drpCategory.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpCategory.SelectedValue);
                    dataTable = addItemBLL.getSubcategoryByCategoryId(num);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpSubCategory.DataSource = dataTable;
                        this.drpSubCategory.DataTextField = dataTable.Columns["category_NAME"].ToString();
                        this.drpSubCategory.DataValueField = dataTable.Columns["category_id"].ToString();
                        this.drpSubCategory.DataBind();
                    }
                }
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
            }
        }

        private void LoadTypeOfBusinessOrganization()
        {
            DataTable economicPrcActivity = this.orgRegInfo.GetEconomicPrcActivity();
            if (economicPrcActivity != null && economicPrcActivity.Rows.Count > 0)
            {
                this.drpTypeofBusiness.DataSource = economicPrcActivity;
                this.drpTypeofBusiness.DataTextField = economicPrcActivity.Columns["code_name"].ToString();
                this.drpTypeofBusiness.DataValueField = economicPrcActivity.Columns["code_id_d"].ToString();
                this.drpTypeofBusiness.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpTypeofBusiness.Items.Insert(0, listItem);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.dtpFromDate.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.FillDropdown();
                this.LoadTypeOfBusinessOrganization();
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                UtilityK.fillItemSubCategoryDropDownList(this.drpSubCategory);
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                this.drpSubCategory.Items.Insert(0, listItem);
                this.LoadPropertyF();
            }
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnExportToExcel);
        }

        protected void SelectedItemCategoryType_Changed(object sender, EventArgs e)
        {
            if (this.drpItemCategory.SelectedValue == "G")
            {
                this.ddlItem.Items.Clear();
                DataTable allItemForSaleByType = this.dbBLL.GetAllItemForSaleByType(this.drpItemCategory.SelectedValue);
                if (allItemForSaleByType != null && allItemForSaleByType.Rows.Count > 0)
                {
                    this.ddlItem.DataSource = allItemForSaleByType;
                    this.ddlItem.DataTextField = allItemForSaleByType.Columns["item_name"].ToString();
                    this.ddlItem.DataValueField = allItemForSaleByType.Columns["item_id"].ToString();
                    this.ddlItem.DataBind();
                }
                this.ddlItem.Items.Insert(0, new ListItem("---Select Item---", "-1"));
            }
            if (this.drpItemCategory.SelectedValue != "S")
            {
                this.ddlItem.Items.Clear();
                DataTable allItemForSale = this.dbBLL.GetAllItemForSale();
                if (allItemForSale != null && allItemForSale.Rows.Count > 0)
                {
                    this.ddlItem.DataSource = allItemForSale;
                    this.ddlItem.DataTextField = allItemForSale.Columns["item_name"].ToString();
                    this.ddlItem.DataValueField = allItemForSale.Columns["item_id"].ToString();
                    this.ddlItem.DataBind();
                }
                this.ddlItem.Items.Insert(0, new ListItem("---Select Item---", "-1"));
                return;
            }
            this.ddlItem.Items.Clear();
            DataTable dataTable = this.dbBLL.GetAllItemForSaleByType(this.drpItemCategory.SelectedValue);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                this.ddlItem.DataSource = dataTable;
                this.ddlItem.DataTextField = dataTable.Columns["item_name"].ToString();
                this.ddlItem.DataValueField = dataTable.Columns["item_id"].ToString();
                this.ddlItem.DataBind();
            }
            this.ddlItem.Items.Insert(0, new ListItem("---Select Item---", "-1"));
        }

        protected void showBTN_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                this.showReport("html", null, null, null);
            }
        }

        private void showCatSubCat()
        {
            try
            {
                SaleBLL saleBLL = new SaleBLL();
                string selectedValue = this.ddlItem.SelectedValue;
                string[] strArrays = selectedValue.Split(new char[] { '.' });
                int num = Convert.ToInt32(strArrays[0]);
                DataTable catSubCat = saleBLL.getCatSubCat(num);
                if (catSubCat != null)
                {
                    this.drpCategory.SelectedValue = catSubCat.Rows[0]["category_id"].ToString();
                    this.drpSubCategory.SelectedValue = catSubCat.Rows[0]["sub_category_id"].ToString();
                }
                DateTime date = DateTime.Now.Date;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void showReport(string reportFormat, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            DateTime minValue = DateTime.MinValue;
            DateTime dateTime = DateTime.MinValue;
            int num = 0;
            int num1 = 0;
            string empty = string.Empty;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            if (this.dtpFromDate.Text.Trim().Length > 0)
            {
                minValue = DateTime.ParseExact(this.dtpFromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (this.dtpToDate.Text.Trim().Length > 0)
            {
                dateTime = DateTime.ParseExact(this.dtpToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            num = (Convert.ToInt32(this.ddlSupplier.SelectedItem.Value) > 0 ? Convert.ToInt32(this.ddlSupplier.SelectedItem.Value) : 0);
            num1 = (Convert.ToInt32(this.ddlItem.SelectedItem.Value) > 0 ? Convert.ToInt32(this.ddlItem.SelectedItem.Value) : 0);
            empty = this.ddlAggrementNo.SelectedItem.Value;
            num6 = (Convert.ToInt32(this.drpRegType.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpRegType.SelectedItem.Value) : 0);
            num7 = (Convert.ToInt32(this.drpTypeofBusiness.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpTypeofBusiness.SelectedItem.Value) : 0);
            num4 = (!string.IsNullOrEmpty(this.txtVATRate.Text) ? Convert.ToDecimal(this.txtVATRate.Text) : new decimal(0));
            num5 = (!string.IsNullOrEmpty(this.txtSDRate.Text) ? Convert.ToDecimal(this.txtSDRate.Text) : new decimal(0));
            num8 = (Convert.ToInt32(this.drpCategory.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpCategory.SelectedItem.Value) : 0);
            num9 = (Convert.ToInt32(this.drpSubCategory.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpSubCategory.SelectedItem.Value) : 0);
            this.lblHeaderShow.Text = string.Empty;
            this.lblleisureShow.Text = string.Empty;
            string dataHtml = "";
            decimal num11 = Convert.ToDecimal(this.ddlSKU.SelectedValue);
            int num12 = 3;
            DataTable periodicSalesChallanNo = this.dbBLL.GetPeriodicSalesChallanNo(minValue, dateTime, num, num1, empty, num6, num7, num5, num4, this.drpSaleType.SelectedValue, this.drpItemCategory.SelectedValue, num8, num9, num10);
            int num13 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            if (periodicSalesChallanNo != null && periodicSalesChallanNo.Rows.Count > 0)
            {
                string str = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                string str2 = "";
                string str3 = "";
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string str4 = "";
                decimal num16 = new decimal(0);
                decimal num17 = new decimal(0);
                string str5 = "";
                string str6 = "";
                PriceDeclaretionBLL priceDeclaretionBLL = new PriceDeclaretionBLL();
                for (int i = 0; i < periodicSalesChallanNo.Rows.Count; i++)
                {
                    int num18 = Convert.ToInt32(periodicSalesChallanNo.Rows[i]["challan_id"].ToString());
                    DataTable salesPeriodicReportData = this.dbBLL.GetSalesPeriodicReportData((long)num18, num1);
                    int count = salesPeriodicReportData.Rows.Count;
                    for (int j = 0; j < salesPeriodicReportData.Rows.Count; j++)
                    {
                        str6 = salesPeriodicReportData.Rows[j]["additional_property"].ToString();
                        string str7 = "";
                        DataTable dataTable = priceDeclaretionBLL.geAdditionalPropertybySaleChallanID(num1, num18);
                        if (dataTable.Rows.Count > 0)
                        {
                            for (int k = 0; k < dataTable.Rows.Count; k++)
                            {
                                if (dataTable.Rows[k]["property_id1_value"].ToString() != "")
                                {
                                    str7 = string.Concat(str7, dataTable.Rows[k]["property_id1_value"].ToString());
                                }
                                if (dataTable.Rows[k]["property_id2_value"].ToString() != "")
                                {
                                    str7 = string.Concat(str7, ",", dataTable.Rows[k]["property_id2_value"].ToString());
                                }
                                if (dataTable.Rows[k]["property_id3_value"].ToString() != "")
                                {
                                    str7 = string.Concat(str7, ",", dataTable.Rows[k]["property_id3_value"].ToString());
                                }
                                if (dataTable.Rows[k]["property_id4_value"].ToString() != "")
                                {
                                    str7 = string.Concat(str7, ",", dataTable.Rows[k]["property_id4_value"].ToString());
                                }
                                if (dataTable.Rows[k]["property_id5_value"].ToString() != "")
                                {
                                    str7 = string.Concat(str7, ",", dataTable.Rows[k]["property_id5_value"].ToString());
                                }
                            }
                        }
                        if (num11 == Convert.ToDecimal(salesPeriodicReportData.Rows[j]["item_id"]))
                        {
                            str = salesPeriodicReportData.Rows[j]["vouchar_date"].ToString();
                            empty1 = salesPeriodicReportData.Rows[j]["supplier_name"].ToString();
                            str1 = salesPeriodicReportData.Rows[j]["challan_no"].ToString();
                            empty2 = salesPeriodicReportData.Rows[j]["item_name"].ToString();
                            str5 = salesPeriodicReportData.Rows[j]["item_sku"].ToString();
                            num14 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["quantity"]);
                            str2 = Utilities.formatFraction(num14);
                            num15 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["unit_price"].ToString());
                            num16 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["value"].ToString());
                            str3 = salesPeriodicReportData.Rows[j]["unit_code"].ToString();
                            str4 = salesPeriodicReportData.Rows[j]["is_fixed_vat"].ToString();
                            if (Convert.ToDecimal(salesPeriodicReportData.Rows[j]["vat"].ToString()) > new decimal(0))
                            {
                                empty3 = (str4 != "False" ? string.Concat(Utilities.RoundUpToWithString(Convert.ToDecimal(salesPeriodicReportData.Rows[j]["vat"]), num13), "(Tk.", salesPeriodicReportData.Rows[j]["vat_rate"].ToString(), "Per Unit.)") : string.Concat(Utilities.RoundUpToWithString(Convert.ToDecimal(salesPeriodicReportData.Rows[j]["vat"]), num13), "(", salesPeriodicReportData.Rows[j]["vat_rate"].ToString(), "%)"));
                            }
                            if (Convert.ToDecimal(salesPeriodicReportData.Rows[j]["sd"].ToString()) > new decimal(0))
                            {
                                empty4 = Utilities.RoundUpToWithString(Convert.ToDecimal(salesPeriodicReportData.Rows[j]["sd"]), num13).ToString();
                            }
                            num17 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["total"].ToString());
                            if (reportFormat == "html")
                            {
                                dataHtml = this.GetDataHtml(dataHtml, j, salesPeriodicReportData, str, empty1, str1, str2, empty2, str3, num15, empty3, empty4, num16, num17, str5, str6, str7);
                            }
                            if (reportFormat == "excel")
                            {
                                num12 = num12 + j + 1;
                                this.GetDataExcel(num12, dataHtml, j, salesPeriodicReportData, str, empty1, str1, str2, empty2, str3, num15, empty3, empty4, num16, num17, sheet, headerStyle, str5, str6, str7);
                            }
                            num2 += num16;
                            num3 += num17;
                        }
                        else if (num11 == new decimal(-1))
                        {
                            str = salesPeriodicReportData.Rows[j]["vouchar_date"].ToString();
                            empty1 = salesPeriodicReportData.Rows[j]["supplier_name"].ToString();
                            str1 = salesPeriodicReportData.Rows[j]["challan_no"].ToString();
                            empty2 = salesPeriodicReportData.Rows[j]["item_name"].ToString();
                            str5 = salesPeriodicReportData.Rows[j]["item_sku"].ToString();
                            num14 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["quantity"]);
                            str2 = Utilities.formatFraction(num14);
                            num15 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["unit_price"].ToString());
                            num16 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["value"].ToString());
                            str3 = salesPeriodicReportData.Rows[j]["unit_code"].ToString();
                            str4 = salesPeriodicReportData.Rows[j]["is_fixed_vat"].ToString();
                            if (Convert.ToDecimal(salesPeriodicReportData.Rows[j]["vat"].ToString()) > new decimal(0))
                            {
                                empty3 = (str4 != "False" ? string.Concat(Utilities.RoundUpToWithString(Convert.ToDecimal(salesPeriodicReportData.Rows[j]["vat"]), num13), "(Tk.", salesPeriodicReportData.Rows[j]["vat_rate"].ToString(), "Per Unit.)") : string.Concat(Utilities.RoundUpToWithString(Convert.ToDecimal(salesPeriodicReportData.Rows[j]["vat"]), num13), "(", salesPeriodicReportData.Rows[j]["vat_rate"].ToString(), "%)"));
                            }
                            if (Convert.ToDecimal(salesPeriodicReportData.Rows[j]["sd"].ToString()) > new decimal(0))
                            {
                                empty4 = Utilities.RoundUpToWithString(Convert.ToDecimal(salesPeriodicReportData.Rows[j]["sd"]), num13).ToString();
                            }
                            num17 = Convert.ToDecimal(salesPeriodicReportData.Rows[j]["total"].ToString());
                            if (reportFormat == "html")
                            {
                                dataHtml = this.GetDataHtml(dataHtml, j, salesPeriodicReportData, str, empty1, str1, str2, empty2, str3, num15, empty3, empty4, num16, num17, str5, str6, str7);
                            }
                            if (reportFormat == "excel")
                            {
                                num12 = num12 + j + 1;
                                this.GetDataExcel(num12, dataHtml, j, salesPeriodicReportData, str, empty1, str1, str2, empty2, str3, num15, empty3, empty4, num16, num17, sheet, headerStyle, str5, str6, str7);
                            }
                            num2 += num16;
                            num3 += num17;
                        }
                    }
                }
                if (reportFormat == "html")
                {
                    dataHtml = this.GetTotalHtml(dataHtml, num2, num3, num13);
                }
                if (reportFormat == "excel")
                {
                    num12++;
                    this.GetTotalExcel(dataHtml, num12, num2, num3, num13, sheet, headerStyle, workbook);
                }
                this.lblleisureShow.Text = dataHtml;
            }
        }

        private bool Validation()
        {
            if (this.dtpFromDate.Text.Length < 10 || this.dtpFromDate.Text.Length > 10)
            {
                this.msgBox.AddMessage("Please enter from date correctly.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.dtpToDate.Text.Length >= 10 && this.dtpToDate.Text.Length >= 10)
            {
                return true;
            }
            this.msgBox.AddMessage("Please enter to date correctly.", MsgBoxs.enmMessageType.Info);
            return false;
        }
    }
}