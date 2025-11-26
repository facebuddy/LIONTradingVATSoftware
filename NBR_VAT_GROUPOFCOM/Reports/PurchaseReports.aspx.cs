using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class PurchaseReports : Page, IRequiresSessionState
    {
       

        private PeriodicReportBLL pbll = new PeriodicReportBLL();

        private OrgRegistrationInfoDAO orgRegInfo = new OrgRegistrationInfoDAO();

        private trnsPurchaseMasterBLL objtrnsSaleMasterBLL = new trnsPurchaseMasterBLL();

        private AddItemBLL dbLL = new AddItemBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

        private AddItemBLL dbBLL = new AddItemBLL();

        private ExcelUtility excelUtility = new ExcelUtility();

      

        public PurchaseReports()
        {
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Periodic Purchase Report";
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
            try
            {
                DataTable allItemForPurchase = this.pbll.GetAllItemForPurchase();
                DataTable purchaseSkuNo = this.objtrnsSaleMasterBLL.GetPurchaseSkuNo();
                if (purchaseSkuNo != null && purchaseSkuNo.Rows.Count > 0)
                {
                    this.ddlSKU.DataSource = purchaseSkuNo;
                    this.ddlSKU.DataTextField = purchaseSkuNo.Columns["item_sku"].ToString();
                    this.ddlSKU.DataValueField = purchaseSkuNo.Columns["item_id"].ToString();
                    this.ddlSKU.DataBind();
                }
                this.ddlSKU.Items.Insert(0, new ListItem("---SELECT---", "-1"));
                if (allItemForPurchase != null && allItemForPurchase.Rows.Count > 0)
                {
                    this.ddlItem.DataSource = allItemForPurchase;
                    this.ddlItem.DataTextField = allItemForPurchase.Columns["item_name"].ToString();
                    this.ddlItem.DataValueField = allItemForPurchase.Columns["item_id"].ToString();
                    this.ddlItem.DataBind();
                }
                DataTable allSupplierForPurchase = this.pbll.GetAllSupplierForPurchase();
                if (allSupplierForPurchase != null && allSupplierForPurchase.Rows.Count > 0)
                {
                    this.ddlSupplier.DataSource = allSupplierForPurchase;
                    this.ddlSupplier.DataTextField = allSupplierForPurchase.Columns["party_name"].ToString();
                    this.ddlSupplier.DataValueField = allSupplierForPurchase.Columns["party_id"].ToString();
                    this.ddlSupplier.DataBind();
                }
                DataTable allAggrementNoForPurchase = this.pbll.GetAllAggrementNoForPurchase();
                if (allAggrementNoForPurchase != null && allAggrementNoForPurchase.Rows.Count > 0)
                {
                    this.ddlAggrementNo.DataSource = allAggrementNoForPurchase;
                    this.ddlAggrementNo.DataTextField = allAggrementNoForPurchase.Columns["aggrement_no"].ToString();
                    this.ddlAggrementNo.DataValueField = allAggrementNoForPurchase.Columns["aggrement_no"].ToString();
                    this.ddlAggrementNo.DataBind();
                }
                this.ddlItem.Items.Insert(0, new ListItem("---Select Item---", "-1"));
                this.ddlSupplier.Items.Insert(0, new ListItem("---Select Supplier---", "-1"));
                this.ddlAggrementNo.Items.Insert(0, new ListItem("---Select Aggrement No---", "-1"));
                this.purchase.Items.Insert(0, new ListItem("---Select Transaction Type---", "-1"));
                this.purchase.Items.Insert(1, new ListItem("Local", "L"));
                this.purchase.Items.Insert(2, new ListItem("Import", "I"));
                this.tax.Items.Insert(0, new ListItem("---Select Tax Type---", "-1"));
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
            this.excelUtility.CreateCell(rows, 0, "Periodic Purchase Report", headerStyle);
            this.excelUtility.CreateCell(rows1, 0, "Tax Type", headerStyle);
            this.excelUtility.CreateCell(rows1, 1, "Voucher Date", headerStyle);
            this.excelUtility.CreateCell(rows1, 2, "Vendor/Supplier Name", headerStyle);
            this.excelUtility.CreateCell(rows1, 3, "Challan No", headerStyle);
            this.excelUtility.CreateCell(rows1, 4, "Challan Date", headerStyle);
            this.excelUtility.CreateCell(rows1, 5, "Item", headerStyle);
            this.excelUtility.CreateCell(rows1, 6, "SKU", headerStyle);
            this.excelUtility.CreateCell(rows1, 7, "Quantity", headerStyle);
            this.excelUtility.CreateCell(rows1, 8, "Unit", headerStyle);
            this.excelUtility.CreateCell(rows1, 9, "Unit Price", headerStyle);
            this.excelUtility.CreateCell(rows1, 10, "VAT", headerStyle);
            this.excelUtility.CreateCell(rows1, 11, "SD", headerStyle);
            this.excelUtility.CreateCell(rows1, 12, "VDS", headerStyle);
            this.excelUtility.CreateCell(rows1, 13, "AIT", headerStyle);
            this.excelUtility.CreateCell(rows1, 14, "Asses Value", headerStyle);
            this.excelUtility.CreateCell(rows1, 15, "CD", headerStyle);
            this.excelUtility.CreateCell(rows1, 16, "RD", headerStyle);
            this.excelUtility.CreateCell(rows1, 17, "AT", headerStyle);
            this.excelUtility.CreateCell(rows1, 18, "Value", headerStyle);
            this.excelUtility.CreateCell(rows1, 19, "Value(consolidated)", headerStyle);
            this.excelUtility.CreateCell(rows1, 20, "Payment Method", headerStyle);
            this.excelUtility.MergeCell(workbook, sheet, 0, 1, 0, 20);
        }

        private void GetDataExcel(int rowIndex, string displayHtml, int j, DataTable dt, string dateChallan, string dateInvChallan, string partyname, string challan_No, string sQuantity, string item, string unit_name, decimal unitprice, decimal vat, decimal sd, decimal vds, decimal at, decimal ait, decimal cd, decimal rd, decimal assesvalue, decimal value, decimal ConValue, int challanId, string TaxType1, string methodNames, ISheet sheet, HSSFCellStyle headerStyle, string Item_sku)
        {
            try
            {
                int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                IRow rows = sheet.CreateRow(rowIndex);
                this.excelUtility.CreateCell(rows, 0, TaxType1 ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 1, dateChallan ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 2, partyname ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 3, challan_No ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 4, challan_No ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 5, item ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 6, Item_sku ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 7, sQuantity ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 8, unit_name ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 9, Utilities.RoundUpToWithString(unitprice, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 10, Utilities.RoundUpToWithString(vat, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 11, Utilities.RoundUpToWithString(sd, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 12, Utilities.RoundUpToWithString(vds, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 13, Utilities.RoundUpToWithString(ait, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 14, Utilities.RoundUpToWithString(assesvalue, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 15, Utilities.RoundUpToWithString(cd, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 16, Utilities.RoundUpToWithString(rd, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 17, Utilities.RoundUpToWithString(at, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 18, Utilities.RoundUpToWithString(value, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 19, Utilities.RoundUpToWithString(ConValue, num) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 20, methodNames ?? "", headerStyle);
                if (this.purchase.SelectedItem.Value == "L")
                {
                    sheet.SetColumnHidden(14, true);
                    sheet.SetColumnHidden(15, true);
                    sheet.SetColumnHidden(16, true);
                    sheet.SetColumnHidden(17, true);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private string GetDataHtml(string displayHtml, int j, DataTable dt, string dateChallan, string dateInvChallan, string partyname, string challan_No, string sQuantity, string item, string unit_name, decimal unitprice, decimal vat, decimal sd, decimal vds, decimal at, decimal ait, decimal cd, decimal rd, decimal assesvalue, decimal value, decimal ConValue, int challanId, string TaxType1, string methodNames, string itemSKU)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            int count = dt.Rows.Count;
            displayHtml = string.Concat(displayHtml, "<tr style = 'background-color: White'>");
            if (j == 0)
            {
                object obj = displayHtml;
                object[] taxType1 = new object[] { obj, "<td rowspan = '", count, "' class='style10' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", TaxType1, "</td>" };
                displayHtml = string.Concat(taxType1);
                object obj1 = displayHtml;
                object[] objArray = new object[] { obj1, "<td rowspan = '", count, "' class='style10' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", dateChallan, "</td>" };
                displayHtml = string.Concat(objArray);
                object obj2 = displayHtml;
                object[] objArray1 = new object[] { obj2, "<td rowspan = '", count, "' class='style11' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", partyname, "</td>" };
                displayHtml = string.Concat(objArray1);
                object obj3 = displayHtml;
                object[] objArray2 = new object[] { obj3, "<td rowspan = '", count, "' class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px;'><a href='#PopupContent_", challanId, "' data-toggle='modal' data-target='#PopupContent_", challanId, "'>", challan_No, "</a></td>" };
                displayHtml = string.Concat(objArray2);
            }
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", dateInvChallan, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", item, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", itemSKU, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", sQuantity, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", unit_name, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(unitprice, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(vat, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(sd, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(vds, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(ait, num), "</td>");
            if (this.purchase.SelectedItem.Value == "I" || this.purchase.SelectedItem.Value == "-1")
            {
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(assesvalue, num), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(cd, num), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(rd, num), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(at, num), "</td>");
            }
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(value, num), "</td>");
            if (j == 0)
            {
                object obj4 = displayHtml;
                object[] withString = new object[] { obj4, "<td rowspan = '", count, "' class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(ConValue, num), "</td>" };
                displayHtml = string.Concat(withString);
            }
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", methodNames.Trim(), "</td>");
            return displayHtml;
        }

        private void GetTotalExcel(string displayHtml, int rowIndex, decimal vatT, decimal sdT, decimal vdsT, decimal aitT, decimal cdT, decimal rdT, decimal atT, decimal Total1, decimal Total2, int precision, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            IRow rows = sheet.CreateRow(rowIndex);
            this.excelUtility.CreateCell(rows, 0, "Total", headerStyle);
            this.excelUtility.CreateCell(rows, 10, Utilities.RoundUpToWithString(vatT, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 11, Utilities.RoundUpToWithString(sdT, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 12, Utilities.RoundUpToWithString(vdsT, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 13, Utilities.RoundUpToWithString(aitT, precision) ?? "", headerStyle);
            if (this.purchase.SelectedItem.Value == "I" || this.purchase.SelectedItem.Value == "-1")
            {
                this.excelUtility.CreateCell(rows, 14, "", headerStyle);
                this.excelUtility.CreateCell(rows, 15, Utilities.RoundUpToWithString(cdT, precision) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 16, Utilities.RoundUpToWithString(rdT, precision) ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 17, Utilities.RoundUpToWithString(atT, precision) ?? "", headerStyle);
            }
            this.excelUtility.CreateCell(rows, 18, Utilities.RoundUpToWithString(Total1, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 19, Utilities.RoundUpToWithString(Total2, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 20, "", headerStyle);
            this.excelUtility.MergeCell(workbook, sheet, rowIndex, rowIndex, 0, 9);
        }

        private string GetTotalHtml(string displayHtml, decimal vatT, decimal sdT, decimal vdsT, decimal aitT, decimal cdT, decimal rdT, decimal atT, decimal Total1, decimal Total2, int precision)
        {
            displayHtml = string.Concat(displayHtml, "<tr style = 'background-color: White'>");
            displayHtml = string.Concat(displayHtml, "<td colspan='10' class='style11' style='width: 10% ;border-style:solid;border-width:1px;text-align:right; padding-right: 15px; font-weight:bold'>Total</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(vatT, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(sdT, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(vdsT, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(aitT, precision), " </td>");
            if (this.purchase.SelectedItem.Value == "I" || this.purchase.SelectedItem.Value == "-1")
            {
                displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'></td>");
                displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(cdT, precision), " </td>");
                displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(rdT, precision), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(atT, precision), "</td>");
            }
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(Total1, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(Total2, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        protected void gvAddtnProperty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        private string loadAdditionalPropertyData(int challanId)
        {
            string str = "";
            DataTable appCodeDetailName = null;
            AddItemBLL addItemBLL = new AddItemBLL();
            GridView gridView = new GridView();
            short num = 0;
            short num1 = 0;
            short num2 = 0;
            short num3 = 0;
            short num4 = 0;
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            DataTable dataTable = this.objPDBll.geAdditionalPropertybyPurchaseChallanID(challanId);
            if (dataTable.Rows.Count <= 0)
            {
                str = string.Concat("<div id='PopupContent_", challanId, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>'Not Found'</div></div></div></div>");
            }
            else
            {
                num = Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
                num1 = Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
                num2 = Convert.ToInt16(dataTable.Rows[0]["property_id3"]);
                num3 = Convert.ToInt16(dataTable.Rows[0]["property_id4"]);
                num4 = Convert.ToInt16(dataTable.Rows[0]["property_id5"]);
                ArrayList arrayLists = new ArrayList();
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField = new BoundField();
                    str1 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str1);
                    boundField.HeaderText = str1;
                    boundField.DataField = "Property1_Text";
                    gridView.Columns.Add(boundField);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num1);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField1 = new BoundField();
                    str2 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str2);
                    boundField1.HeaderText = str2;
                    boundField1.DataField = "Property2_Text";
                    gridView.Columns.Add(boundField1);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num2);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField2 = new BoundField();
                    str3 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str3);
                    boundField2.HeaderText = str3;
                    boundField2.DataField = "Property3_Text";
                    gridView.Columns.Add(boundField2);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num3);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField3 = new BoundField();
                    str4 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str4);
                    boundField3.HeaderText = str4;
                    boundField3.DataField = "Property4_Text";
                    gridView.Columns.Add(boundField3);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num4);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField4 = new BoundField();
                    str5 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str5);
                    boundField4.HeaderText = str5;
                    boundField4.DataField = "Property5_Text";
                    gridView.Columns.Add(boundField4);
                }
                string[] strArrays = new string[] { "<thead style='text-align: center'><tr style='text-align: center'> </tr><tr><th  style='text-align: center;'>", str1, "</th><th>", str2, "</th><th>", str3, "</th><th>", str4, "</th><th>", str5, "</th></tr></thead>" };
                empty2 = string.Concat(strArrays);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO()
                    {
                        additionalInfoId = Convert.ToInt32(dataTable.Rows[i]["additional_info_id"]),
                        Item_id = Convert.ToInt32(dataTable.Rows[i]["item_id"])
                    };
                    if (dataTable.Rows[i]["property_id1_value"].ToString() != "")
                    {
                        contructualProductionIssueDAO.Property1_Text = dataTable.Rows[i]["property_id1_value"].ToString();
                    }
                    if (dataTable.Rows[i]["property_id2_value"].ToString() != "")
                    {
                        contructualProductionIssueDAO.Property2_Text = dataTable.Rows[i]["property_id2_value"].ToString();
                    }
                    if (dataTable.Rows[i]["property_id3_value"].ToString() != "")
                    {
                        contructualProductionIssueDAO.Property3_Text = dataTable.Rows[i]["property_id3_value"].ToString();
                    }
                    if (dataTable.Rows[i]["property_id4_value"].ToString() != "")
                    {
                        contructualProductionIssueDAO.Property4_Text = dataTable.Rows[i]["property_id4_value"].ToString();
                    }
                    if (dataTable.Rows[i]["property_id5_value"].ToString() != "")
                    {
                        contructualProductionIssueDAO.Property5_Text = dataTable.Rows[i]["property_id5_value"].ToString();
                    }
                    string str6 = empty1;
                    string[] property1Text = new string[] { str6, "<tbody><tr><td  style='text-align: center;padding:5px'>", contructualProductionIssueDAO.Property1_Text, "</td><td  style='text-align:right;padding:5px'>", contructualProductionIssueDAO.Property2_Text, "</td><td  style='text-align:right;padding:5px'>", contructualProductionIssueDAO.Property3_Text, "</td><td  style='text-align:right;padding:5px'>", contructualProductionIssueDAO.Property4_Text, "</td><td  style='text-align:right;padding:5px'>", contructualProductionIssueDAO.Property5_Text, "</td></tr></tbody>" };
                    empty1 = string.Concat(property1Text);
                    empty = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty2, empty1, "</table>");
                    arrayLists.Add(contructualProductionIssueDAO);
                }
                gridView.DataSource = arrayLists;
                gridView.DataBind();
                object[] objArray = new object[] { "<div id='PopupContent_", challanId, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", empty, "</div></div></div></div>" };
                str = string.Concat(objArray);
            }
            return str;
        }

        private void LoadCategory()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (this.drpSubCategory.SelectedValue != "" && this.drpSubCategory.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                    dataTable = this.dbBLL.GetCategoryBySubCategoryID(num);
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
                this.ddlItem.Items.Clear();
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO()
                {
                    CategoryID = (Convert.ToInt32(this.drpCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpCategory.SelectedValue) : 0),
                    SubCatgID = (Convert.ToInt32(this.drpSubCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpSubCategory.SelectedValue) : 0)
                };
                DataTable allItemForPurchasebyCatgSubCatg = addItemBLL.GetAllItemForPurchasebyCatgSubCatg(setItemDAO);
                this.ddlItem.DataSource = allItemForPurchasebyCatgSubCatg;
                this.ddlItem.DataTextField = allItemForPurchasebyCatgSubCatg.Columns["ITEM_NAME"].ToString();
                this.ddlItem.DataValueField = allItemForPurchasebyCatgSubCatg.Columns["ITEM_ID"].ToString();
                this.ddlItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.ddlItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
            }
        }

        protected void SelectedPurchaseType_Changed(object sender, EventArgs e)
        {
            if (this.purchase.SelectedValue == "L")
            {
                this.tax.Items.Clear();
                this.tax.Items.Insert(0, new ListItem("---Select Tax Type---", "-1"));
                this.tax.Items.Insert(1, new ListItem("VAT", "purchase_vat"));
                this.tax.Items.Insert(2, new ListItem("SD", "purchase_sd"));
                this.tax.Items.Insert(3, new ListItem("AIT", "ait"));
                this.tax.Items.Insert(4, new ListItem("VDS", "vds_amount"));
            }
            if (this.purchase.SelectedValue == "I")
            {
                this.tax.Items.Clear();
                this.tax.Items.Insert(0, new ListItem("---Select Tax Type---", "-1"));
                this.tax.Items.Insert(1, new ListItem("VAT", "purchase_vat"));
                this.tax.Items.Insert(2, new ListItem("SD", "purchase_sd"));
                this.tax.Items.Insert(3, new ListItem("AIT", "ait"));
                this.tax.Items.Insert(4, new ListItem("VDS", "vds_amount"));
                this.tax.Items.Insert(5, new ListItem("CD", "cd"));
                this.tax.Items.Insert(6, new ListItem("RD", "rd"));
                this.tax.Items.Insert(7, new ListItem("AT", "at"));
            }
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
            char[] chrArray;
            DateTime minValue = DateTime.MinValue;
            DateTime dateTime = DateTime.MinValue;
            int num = 0;
            int num1 = 0;
            string empty = string.Empty;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            string value = string.Empty;
            string str = string.Empty;
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            int num11 = 0;
            int num12 = 0;
            decimal num13 = new decimal(0);
            decimal num14 = new decimal(0);
            int num15 = 2;
            int num16 = 0;
            int num17 = 0;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            decimal num18 = new decimal(0);
            decimal num19 = new decimal(0);
            decimal num20 = new decimal(0);
            decimal num21 = new decimal(0);
            decimal num22 = new decimal(0);
            decimal num23 = new decimal(0);
            decimal num24 = new decimal(0);
            decimal num25 = new decimal(0);
            decimal num26 = new decimal(0);
            string str3 = string.Empty;
            string str4 = "";
            decimal num27 = new decimal(0);
            decimal num28 = new decimal(0);
            decimal num29 = new decimal(0);
            string str5 = "ALL";
            string str6 = "";
            if (this.dtpFromDate.Text.Trim().Length > 0)
            {
                minValue = DateTime.ParseExact(this.dtpFromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (this.dtpToDate.Text.Trim().Length > 0)
            {
                dateTime = DateTime.ParseExact(this.dtpToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            int num30 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            num = (Convert.ToInt32(this.ddlSupplier.SelectedItem.Value) > 0 ? Convert.ToInt32(this.ddlSupplier.SelectedItem.Value) : 0);
            num1 = (Convert.ToInt32(this.ddlItem.SelectedItem.Value) > 0 ? Convert.ToInt32(this.ddlItem.SelectedItem.Value) : 0);
            empty = this.ddlAggrementNo.SelectedItem.Value;
            num16 = (Convert.ToInt32(this.drpRegType.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpRegType.SelectedItem.Value) : 0);
            num17 = (Convert.ToInt32(this.drpTypeofBusiness.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpTypeofBusiness.SelectedItem.Value) : 0);
            num13 = (!string.IsNullOrEmpty(this.txtVATRate.Text) ? Convert.ToDecimal(this.txtVATRate.Text) : new decimal(0));
            num14 = (!string.IsNullOrEmpty(this.txtSDRate.Text) ? Convert.ToDecimal(this.txtSDRate.Text) : new decimal(0));
            num11 = (Convert.ToInt32(this.drpCategory.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpCategory.SelectedItem.Value) : 0);
            num12 = (Convert.ToInt32(this.drpSubCategory.SelectedItem.Value) > 0 ? Convert.ToInt32(this.drpSubCategory.SelectedItem.Value) : 0);
            this.lblHeaderShow.Text = string.Empty;
            this.lblleisureShow.Text = string.Empty;
            string dataHtml = "";
            value = this.tax.SelectedItem.Value;
            str = this.purchase.SelectedItem.Value;
            DataTable purchasePeriodicChallanNo = this.pbll.GetPurchasePeriodicChallanNo(minValue, dateTime, num, num1, empty, value, str, num16, num17, num13, num14, num11, num12);
            decimal num31 = Convert.ToDecimal(this.ddlSKU.SelectedValue);
            if (purchasePeriodicChallanNo != null && purchasePeriodicChallanNo.Rows.Count > 0)
            {
                string empty4 = string.Empty;
                int num32 = 0;
                string str7 = "";
                if (str == "L")
                {
                    this.header2.Visible = false;
                    this.header1.Visible = true;
                    if (this.purchase.SelectedValue != "-1")
                    {
                        this.purchaseTypelbl.Visible = true;
                        this.purchaseTypelbl.Text = string.Concat("Purchase Type: ", this.purchase.SelectedItem.ToString(), "     ");
                    }
                    if (this.ddlSupplier.SelectedValue != "-1")
                    {
                        this.vendorlbl.Visible = true;
                        this.vendorlbl.Text = string.Concat("Vendor/Supplier: ", this.ddlSupplier.SelectedItem.ToString(), "     ");
                    }
                    this.fromdatelbl.Visible = true;
                    this.todatelbl.Visible = true;
                    this.fromdatelbl.Text = string.Concat("From Date:", this.dtpFromDate.Text, "     ");
                    this.todatelbl.Text = string.Concat("To Date:", this.dtpToDate.Text, "     ");
                }
                else if (str == "I" || str == "-1")
                {
                    this.header1.Visible = false;
                    this.header2.Visible = true;
                    if (this.purchase.SelectedValue != "-1")
                    {
                        this.purchaseTypelbl.Visible = true;
                        this.purchaseTypelbl.Text = string.Concat("Purchase Type: ", this.purchase.SelectedItem.ToString(), "     ");
                    }
                    if (this.ddlSupplier.SelectedValue != "-1")
                    {
                        this.vendorlbl.Visible = true;
                        this.vendorlbl.Text = string.Concat("Vendor/Supplier: ", this.ddlSupplier.SelectedItem.ToString(), "     ");
                    }
                    this.fromdatelbl.Visible = true;
                    this.todatelbl.Visible = true;
                    this.fromdatelbl.Text = string.Concat("From Date:", this.dtpFromDate.Text, "     ");
                    this.todatelbl.Text = string.Concat("To Date:", this.dtpToDate.Text, "     ");
                }
                if (value != "-1")
                {
                    if (value == "purchase_vat")
                    {
                        str5 = "VAT";
                    }
                    else if (value == "purchase_sd")
                    {
                        str5 = "SD";
                    }
                }
                for (int i = 0; i < purchasePeriodicChallanNo.Rows.Count; i++)
                {
                    long num33 = Convert.ToInt64(purchasePeriodicChallanNo.Rows[i]["challan_id"].ToString());
                    DataTable purchasePeriodicReportData = this.pbll.GetPurchasePeriodicReportData(num33, num1, value);
                    int count = purchasePeriodicReportData.Rows.Count;
                    for (int j = 0; j < purchasePeriodicReportData.Rows.Count; j++)
                    {
                        if (num31 == Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["item_id"]))
                        {
                            string empty5 = string.Empty;
                            num32 = Convert.ToInt32(purchasePeriodicReportData.Rows[j]["challan_id"]);
                            empty4 = this.loadAdditionalPropertyData(num32);
                            HtmlGenericControl popupContainer = this.PopupContainer;
                            popupContainer.InnerHtml = string.Concat(popupContainer.InnerHtml, empty4);
                            empty1 = purchasePeriodicReportData.Rows[j]["vouchar_date"].ToString();
                            str1 = purchasePeriodicReportData.Rows[j]["date_challan"].ToString();
                            empty2 = purchasePeriodicReportData.Rows[j]["supplier_name"].ToString();
                            str2 = purchasePeriodicReportData.Rows[j]["challan_no"].ToString();
                            empty3 = purchasePeriodicReportData.Rows[j]["item_name"].ToString();
                            str7 = purchasePeriodicReportData.Rows[j]["item_sku"].ToString();
                            num18 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["quantity"].ToString());
                            str4 = Utilities.formatFraction(num18);
                            num19 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["unit_price"].ToString());
                            num20 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["value"].ToString());
                            str6 = purchasePeriodicReportData.Rows[j]["unit_name"].ToString();
                            num22 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vat"].ToString());
                            num23 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["sd"].ToString());
                            num24 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vds"].ToString());
                            num25 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["ait"].ToString());
                            str3 = purchasePeriodicReportData.Rows[j]["payment"].ToString();
                            if (!(str3 != "''") || !(str3 != "Not applicable"))
                            {
                                empty5 = str3;
                            }
                            else
                            {
                                chrArray = new char[] { ',' };
                                int[] array = str3.Split(chrArray).Select<string, int>(new Func<string, int>(int.Parse)).ToArray<int>();
                                for (int k = 0; k < (int)array.Length; k++)
                                {
                                    DataTable paymentMethodName = this.pbll.getPaymentMethodName(array[k]);
                                    if (paymentMethodName.Rows.Count > 0)
                                    {
                                        empty5 = (k != (int)array.Length - 1 ? string.Concat(empty5, paymentMethodName.Rows[0]["payment_method_name"], ",") : string.Concat(empty5, paymentMethodName.Rows[0]["payment_method_name"]));
                                    }
                                }
                            }
                            num21 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["total"].ToString());
                            if (reportFormat == "html")
                            {
                                dataHtml = this.GetDataHtml(dataHtml, j, purchasePeriodicReportData, empty1, str1, empty2, str2, str4, empty3, str6, num19, num22, num23, num24, num29, num25, num27, num28, num26, num20, num21, num32, str5, empty5, str7);
                            }
                            if (reportFormat == "excel")
                            {
                                num15 = num15 + j + 1;
                                this.GetDataExcel(num15, dataHtml, j, purchasePeriodicReportData, empty1, str1, empty2, str2, str4, empty3, str6, num19, num22, num23, num24, num29, num25, num27, num28, num26, num20, num21, num32, str5, empty5, sheet, headerStyle, str7);
                            }
                            if (str == "I" || str == "-1")
                            {
                                num2 += num20;
                                num3 += num21;
                                num4 += num22;
                                num5 += num23;
                                num6 += num24;
                                num7 += num25;
                                num8 += num27;
                                num9 += num28;
                                num10 += num29;
                            }
                            else
                            {
                                num2 += num20;
                                if (j == 0)
                                {
                                    num3 += num20;
                                }
                                num4 += num22;
                                num5 += num23;
                                num6 += num24;
                                num7 += num25;
                            }
                        }
                        else if (num31 == new decimal(-1))
                        {
                            string empty6 = string.Empty;
                            num32 = Convert.ToInt32(purchasePeriodicReportData.Rows[j]["challan_id"]);
                            empty4 = this.loadAdditionalPropertyData(num32);
                            HtmlGenericControl htmlGenericControl = this.PopupContainer;
                            htmlGenericControl.InnerHtml = string.Concat(htmlGenericControl.InnerHtml, empty4);
                            empty1 = purchasePeriodicReportData.Rows[j]["vouchar_date"].ToString();
                            str1 = purchasePeriodicReportData.Rows[j]["date_challan"].ToString();
                            empty2 = purchasePeriodicReportData.Rows[j]["supplier_name"].ToString();
                            str2 = purchasePeriodicReportData.Rows[j]["challan_no"].ToString();
                            empty3 = purchasePeriodicReportData.Rows[j]["item_name"].ToString();
                            str7 = purchasePeriodicReportData.Rows[j]["item_sku"].ToString();
                            num18 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["quantity"].ToString());
                            str4 = Utilities.formatFraction(num18);
                            num19 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["unit_price"].ToString());
                            num20 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["value"].ToString());
                            str6 = purchasePeriodicReportData.Rows[j]["unit_name"].ToString();
                            num22 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vat"].ToString());
                            num23 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["sd"].ToString());
                            num24 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vds"].ToString());
                            num25 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["ait"].ToString());
                            str3 = purchasePeriodicReportData.Rows[j]["payment"].ToString();
                            if (!(str3 != "''") || !(str3 != "Not applicable"))
                            {
                                empty6 = str3;
                            }
                            else
                            {
                                chrArray = new char[] { ',' };
                                int[] numArray = str3.Split(chrArray).Select<string, int>(new Func<string, int>(int.Parse)).ToArray<int>();
                                for (int l = 0; l < (int)numArray.Length; l++)
                                {
                                    DataTable dataTable = this.pbll.getPaymentMethodName(numArray[l]);
                                    if (dataTable.Rows.Count > 0)
                                    {
                                        empty6 = (l != (int)numArray.Length - 1 ? string.Concat(empty6, dataTable.Rows[0]["payment_method_name"], ",") : string.Concat(empty6, dataTable.Rows[0]["payment_method_name"]));
                                    }
                                }
                            }
                            num21 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["total"].ToString());
                            if (reportFormat == "html")
                            {
                                dataHtml = this.GetDataHtml(dataHtml, j, purchasePeriodicReportData, empty1, str1, empty2, str2, str4, empty3, str6, num19, num22, num23, num24, num29, num25, num27, num28, num26, num20, num21, num32, str5, empty6, str7);
                            }
                            if (reportFormat == "excel")
                            {
                                num15 = num15 + j + 1;
                                this.GetDataExcel(num15, dataHtml, j, purchasePeriodicReportData, empty1, str1, empty2, str2, str4, empty3, str6, num19, num22, num23, num24, num29, num25, num27, num28, num26, num20, num21, num32, str5, empty6, sheet, headerStyle, str7);
                            }
                            if (str == "I" || str == "-1")
                            {
                                num2 += num20;
                                num3 += num21;
                                num4 += num22;
                                num5 += num23;
                                num6 += num24;
                                num7 += num25;
                                num8 += num27;
                                num9 += num28;
                                num10 += num29;
                            }
                            else
                            {
                                num2 += num20;
                                if (j == 0)
                                {
                                    num3 += num20;
                                }
                                num4 += num22;
                                num5 += num23;
                                num6 += num24;
                                num7 += num25;
                            }
                        }
                    }
                }
                if (reportFormat == "html")
                {
                    dataHtml = this.GetTotalHtml(dataHtml, num4, num5, num6, num7, num8, num9, num10, num2, num3, num30);
                }
                if (reportFormat == "excel")
                {
                    num15++;
                    this.GetTotalExcel(dataHtml, num15, num4, num5, num6, num7, num8, num9, num10, num2, num3, num30, sheet, headerStyle, workbook);
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