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
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class PeriodicStockReports : Page, IRequiresSessionState
    {


        private WorkOrderBLL dbBLL = new WorkOrderBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

        private ExcelUtility excelUtility = new ExcelUtility();
        public PeriodicStockReports()
        {
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "PeriodicStockReport";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.showReport("html", null, null, null);
        }

        protected void drpProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            if (this.drpProductType.SelectedValue == "R")
            {
                this.chk1.Checked = true;
                this.chk2.Checked = true;
                this.chk3.Checked = true;
                this.chk5.Checked = true;
                this.chk4.Checked = false;
                return;
            }
            if (this.drpProductType.SelectedValue == "F")
            {
                this.chk1.Checked = true;
                this.chk2.Checked = true;
                this.chk4.Checked = true;
                this.chk5.Checked = true;
                this.chk3.Checked = false;
                return;
            }
            if (this.drpProductType.SelectedValue == "C")
            {
                this.chk1.Checked = true;
                this.chk3.Checked = true;
                this.chk4.Checked = true;
                this.chk5.Checked = true;
                this.chk2.Checked = false;
                return;
            }
            this.chk1.Checked = true;
            this.chk3.Checked = true;
            this.chk4.Checked = true;
            this.chk5.Checked = true;
            this.chk2.Checked = true;
        }

        private void GenerateHeader(HSSFWorkbook workbook, ISheet sheet, HSSFCellStyle headerStyle)
        {
            IRow rows = sheet.CreateRow(0);
            IRow rows1 = sheet.CreateRow(2);
            IRow rows2 = sheet.CreateRow(3);
            sheet.CreateRow(4);
            this.excelUtility.CreateCell(rows, 0, "পণ্য/ সেবার উপকরণ ক্রয়", headerStyle);
            this.excelUtility.CreateCell(rows1, 0, "ক্র:নং", headerStyle);
            this.excelUtility.CreateCell(rows1, 1, "তারিখ", headerStyle);
            this.excelUtility.CreateCell(rows1, 2, "একক", headerStyle);
            this.excelUtility.CreateCell(rows1, 3, "মজুদ উপকরণের প্রারম্ভিক জের", headerStyle);
            this.excelUtility.CreateCell(rows1, 5, "ক্রয় হিসাব", headerStyle);
            this.excelUtility.CreateCell(rows1, 9, "উৎপাদন হিসাব", headerStyle);
            this.excelUtility.CreateCell(rows1, 13, "বিক্রয় হিসাব/স্থানান্তর", headerStyle);
            this.excelUtility.CreateCell(rows1, 17, "প্রান্তিক জের", headerStyle);
            this.excelUtility.CreateCell(rows1, 19, "প্রান্তিক জের", headerStyle);
            this.excelUtility.CreateCell(rows2, 3, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 4, "মূল্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 5, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 6, "মূল্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 7, "সম্পূরক শুল্ক", headerStyle);
            this.excelUtility.CreateCell(rows2, 8, "মূসক", headerStyle);
            this.excelUtility.CreateCell(rows2, 9, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 10, "মূল্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 11, "সম্পূরক শুল্ক", headerStyle);
            this.excelUtility.CreateCell(rows2, 12, "মূসক", headerStyle);
            this.excelUtility.CreateCell(rows2, 13, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 14, "মূল্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 15, "সম্পূরক শুল্ক", headerStyle);
            this.excelUtility.CreateCell(rows2, 16, "মূসক", headerStyle);
            this.excelUtility.CreateCell(rows2, 17, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 18, "মূল্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 19, "পরিমাণ", headerStyle);
            this.excelUtility.MergeCell(workbook, sheet, 0, 1, 0, 19);
            this.excelUtility.MergeCell(workbook, sheet, 2, 2, 3, 4);
            this.excelUtility.MergeCell(workbook, sheet, 2, 2, 5, 8);
            this.excelUtility.MergeCell(workbook, sheet, 2, 2, 9, 12);
            this.excelUtility.MergeCell(workbook, sheet, 2, 2, 13, 16);
            this.excelUtility.MergeCell(workbook, sheet, 2, 2, 17, 18);
            this.excelUtility.MergeCell(workbook, sheet, 2, 2, 19, 19);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 0, 0);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 1, 1);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 2, 2);
            if (!this.chk1.Checked)
            {
                sheet.SetColumnHidden(3, true);
                sheet.SetColumnHidden(4, true);
            }
            if (!this.chk2.Checked)
            {
                sheet.SetColumnHidden(5, true);
                sheet.SetColumnHidden(6, true);
                sheet.SetColumnHidden(7, true);
                sheet.SetColumnHidden(8, true);
            }
            if (!this.chk3.Checked)
            {
                sheet.SetColumnHidden(9, true);
                sheet.SetColumnHidden(10, true);
                sheet.SetColumnHidden(11, true);
                sheet.SetColumnHidden(12, true);
            }
            if (!this.chk4.Checked)
            {
                sheet.SetColumnHidden(13, true);
                sheet.SetColumnHidden(14, true);
                sheet.SetColumnHidden(15, true);
                sheet.SetColumnHidden(16, true);
            }
            if (!this.chk5.Checked)
            {
                sheet.SetColumnHidden(17, true);
                sheet.SetColumnHidden(18, true);
            }
            if (!this.chk6.Checked)
            {
                sheet.SetColumnHidden(19, true);
            }
        }

        private void GetDataExcel(int rowIndex, string displayHTML, int i, DataTable dt, decimal PreQuantity, int item_iddt, string sPreQuantity, decimal PrePrice, decimal PurQuantity, string sPurQuantity, decimal PurPrice, decimal PurSD, decimal PurVat, decimal ProductionQuantity, string sProductionQuantity, decimal ProductionPrice, decimal ProductionSD, decimal ProductionVat, decimal SaleQuantity, string sSaleQuantity, decimal SalePrice, decimal SaleSD, decimal SaleVat, decimal ExtQuantity, string sExtQuantity, decimal ExtPrice, decimal weightQuantity, ISheet sheet, HSSFCellStyle headerStyle)
        {
            try
            {
                int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                IRow rows = sheet.CreateRow(rowIndex);
                this.excelUtility.CreateCell(rows, 0, string.Concat(i + 1), headerStyle);
                this.excelUtility.CreateCell(rows, 1, dt.Rows[i]["item"].ToString() ?? "", headerStyle);
                this.excelUtility.CreateCell(rows, 2, dt.Rows[i]["unit"].ToString() ?? "", headerStyle);
                if (this.chk1.Checked)
                {
                    if (PreQuantity != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 3, sPreQuantity ?? "", headerStyle);
                        // this.excelUtility.CreateCell(rows, 4, Utilities.RoundUpToWithString(PrePrice, num) ?? "", headerStyle);
                        this.excelUtility.CreateCell(rows, 4,"-", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 3, "-", headerStyle);
                        this.excelUtility.CreateCell(rows, 4, "-", headerStyle);
                    }
                }
                if (this.chk2.Checked)
                {
                    if (PurQuantity != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 5, sPurQuantity ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 5, "-", headerStyle);
                    }
                    if (PurPrice != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 6, Utilities.RoundUpToWithString(PurPrice, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 6, "-", headerStyle);
                    }
                    if (PurSD != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 7, Utilities.RoundUpToWithString(PurSD, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 7, "-", headerStyle);
                    }
                    if (PurVat != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 8, Utilities.RoundUpToWithString(PurVat, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 8, "-", headerStyle);
                    }
                }
                if (this.chk3.Checked)
                {
                    if (ProductionQuantity != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 9, sProductionQuantity ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 9, "-", headerStyle);
                    }
                    if (ProductionPrice != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 10, Utilities.RoundUpToWithString(ProductionPrice, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 10, "-", headerStyle);
                    }
                    if (ProductionSD != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 11, Utilities.RoundUpToWithString(ProductionSD, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 11, "-", headerStyle);
                    }
                    if (ProductionVat != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 12, Utilities.RoundUpToWithString(ProductionVat, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 12, "-", headerStyle);
                    }
                }
                if (this.chk4.Checked)
                {
                    if (SaleQuantity != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 13, sSaleQuantity ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 13, "-", headerStyle);
                    }
                    if (SalePrice != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 14, Utilities.RoundUpToWithString(SalePrice, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 14, "-", headerStyle);
                    }
                    if (SaleSD != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 15, Utilities.RoundUpToWithString(SaleSD, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 15, "-", headerStyle);
                    }
                    if (SaleVat != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 16, Utilities.RoundUpToWithString(SaleVat, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 16, "-", headerStyle);
                    }
                }
                if (this.chk5.Checked)
                {
                    if (ExtQuantity != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 17, sExtQuantity ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 17, "-", headerStyle);
                    }
                    if (ExtPrice != new decimal(0))
                    {
                        this.excelUtility.CreateCell(rows, 18, Utilities.RoundUpToWithString(ExtPrice, num) ?? "", headerStyle);
                    }
                    else
                    {
                        this.excelUtility.CreateCell(rows, 18, "-", headerStyle);
                    }
                }
            if (this.chk6.Checked)
            {
                weightQuantity = ExtQuantity * Convert.ToDecimal(dt.Rows[i]["weight"].ToString());
                if (weightQuantity != new decimal(0))
                {
                    this.excelUtility.CreateCell(rows, 19, string.Concat(Utilities.RoundUpToWithString(weightQuantity, num), " (", dt.Rows[i]["unit_codei"].ToString(), ")"), headerStyle);
                }
                else
                {
                    this.excelUtility.CreateCell(rows, 19, "-", headerStyle);
                }
            }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private string GetDataHtml(string displayHTML, int i, DataTable dt, decimal PreQuantity, int item_iddt, string sPreQuantity, decimal PrePrice, decimal PurQuantity, string sPurQuantity, decimal PurPrice, decimal PurSD, decimal PurVat, decimal ProductionQuantity, string sProductionQuantity, decimal ProductionPrice, decimal ProductionSD, decimal ProductionVat, decimal SaleQuantity, string sSaleQuantity, decimal SalePrice, decimal SaleSD, decimal SaleVat, decimal ExtQuantity, string sExtQuantity, decimal ExtPrice, decimal weightQuantity)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            displayHTML = string.Concat(displayHTML, "<tr>");
            object obj = displayHTML;
            object[] objArray = new object[] { obj, "<td style='text-align:left;padding:5px'>", i + 1, "</td>" };
            displayHTML = string.Concat(objArray);
            object obj1 = displayHTML;
            object[] itemIddt = new object[] { obj1, "<td style='text-align:left;padding:5px'><a href='#PopupContent_", item_iddt, "' data-toggle='modal' data-target='#PopupContent_", item_iddt, "'>", dt.Rows[i]["item"].ToString(), "</a></td>" };
            displayHTML = string.Concat(itemIddt);
            displayHTML = string.Concat(displayHTML, "<td style='text-align:left;padding:5px'>", dt.Rows[i]["unit"].ToString(), "</td>");
            if (this.chk1.Checked)
            {
                this.col1.Visible = true;
                this.col11.Visible = true;
                this.col12.Visible = true;
                if (PreQuantity != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", sPreQuantity, "</td>");
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", "-", "</td>");
                }
                else
                {
                    object obj2 = displayHTML;
                    object[] objArray1 = new object[] { obj2, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray1);
                    object obj3 = displayHTML;
                    object[] objArray2 = new object[] { obj3, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray2);
                }
            }
            if (this.chk2.Checked)
            {
                this.col2.Visible = true;
                this.col21.Visible = true;
                this.col22.Visible = true;
                this.col23.Visible = true;
                this.col24.Visible = true;
                if (!this.chk1.Checked)
                {
                    this.col1.Visible = false;
                    this.col11.Visible = false;
                    this.col12.Visible = false;
                }
                if (PurQuantity != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", sPurQuantity, "</td>");
                }
                else
                {
                    object obj4 = displayHTML;
                    object[] objArray3 = new object[] { obj4, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray3);
                }
                if (PurPrice != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(PurPrice, num), "</td>");
                }
                else
                {
                    object obj5 = displayHTML;
                    object[] objArray4 = new object[] { obj5, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray4);
                }
                if (PurSD != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(PurSD, num), "</td>");
                }
                else
                {
                    object obj6 = displayHTML;
                    object[] objArray5 = new object[] { obj6, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray5);
                }
                if (PurVat != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(PurVat, num), "</td>");
                }
                else
                {
                    object obj7 = displayHTML;
                    object[] objArray6 = new object[] { obj7, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray6);
                }
            }
            if (this.chk3.Checked)
            {
                this.col3.Visible = true;
                this.col31.Visible = true;
                this.col32.Visible = true;
                this.col33.Visible = true;
                this.col34.Visible = true;
                if (!this.chk1.Checked)
                {
                    this.col1.Visible = false;
                    this.col11.Visible = false;
                    this.col12.Visible = false;
                }
                if (!this.chk2.Checked)
                {
                    this.col2.Visible = false;
                    this.col21.Visible = false;
                    this.col22.Visible = false;
                    this.col23.Visible = false;
                    this.col24.Visible = false;
                }
                if (ProductionQuantity != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", sProductionQuantity, "</td>");
                }
                else
                {
                    object obj8 = displayHTML;
                    object[] objArray7 = new object[] { obj8, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray7);
                }
                if (ProductionPrice != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(ProductionPrice, num), "</td>");
                }
                else
                {
                    object obj9 = displayHTML;
                    object[] objArray8 = new object[] { obj9, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray8);
                }
                if (ProductionSD != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(ProductionSD, num), "</td>");
                }
                else
                {
                    object obj10 = displayHTML;
                    object[] objArray9 = new object[] { obj10, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray9);
                }
                if (ProductionVat != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(ProductionVat, num), "</td>");
                }
                else
                {
                    object obj11 = displayHTML;
                    object[] objArray10 = new object[] { obj11, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray10);
                }
            }
            if (this.chk4.Checked)
            {
                this.col4.Visible = true;
                this.col41.Visible = true;
                this.col42.Visible = true;
                this.col43.Visible = true;
                this.col44.Visible = true;
                if (!this.chk1.Checked)
                {
                    this.col1.Visible = false;
                    this.col11.Visible = false;
                    this.col12.Visible = false;
                }
                if (!this.chk2.Checked)
                {
                    this.col2.Visible = false;
                    this.col21.Visible = false;
                    this.col22.Visible = false;
                    this.col23.Visible = false;
                    this.col24.Visible = false;
                }
                if (!this.chk3.Checked)
                {
                    this.col3.Visible = false;
                    this.col31.Visible = false;
                    this.col32.Visible = false;
                    this.col33.Visible = false;
                    this.col34.Visible = false;
                }
                if (SaleQuantity != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", sSaleQuantity, "</td>");
                }
                else
                {
                    object obj12 = displayHTML;
                    object[] objArray11 = new object[] { obj12, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray11);
                }
                if (SalePrice != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(SalePrice, num), "</td>");
                }
                else
                {
                    object obj13 = displayHTML;
                    object[] objArray12 = new object[] { obj13, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray12);
                }
                if (SaleSD != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(SaleSD, num), "</td>");
                }
                else
                {
                    object obj14 = displayHTML;
                    object[] objArray13 = new object[] { obj14, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray13);
                }
                if (SaleVat != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(SaleVat, num), "</td>");
                }
                else
                {
                    object obj15 = displayHTML;
                    object[] objArray14 = new object[] { obj15, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray14);
                }
            }
            if (this.chk5.Checked)
            {
                this.col5.Visible = true;
                this.col51.Visible = true;
                this.col52.Visible = true;
                if (!this.chk1.Checked)
                {
                    this.col1.Visible = false;
                    this.col11.Visible = false;
                    this.col12.Visible = false;
                }
                if (!this.chk2.Checked)
                {
                    this.col2.Visible = false;
                    this.col21.Visible = false;
                    this.col22.Visible = false;
                    this.col23.Visible = false;
                    this.col24.Visible = false;
                }
                if (!this.chk3.Checked)
                {
                    this.col3.Visible = false;
                    this.col31.Visible = false;
                    this.col32.Visible = false;
                    this.col33.Visible = false;
                    this.col34.Visible = false;
                }
                if (!this.chk4.Checked)
                {
                    this.col4.Visible = false;
                    this.col41.Visible = false;
                    this.col42.Visible = false;
                    this.col43.Visible = false;
                    this.col44.Visible = false;
                }
                if (ExtQuantity != new decimal(0))
                {
                    object obj16 = displayHTML;
                    object[] itemIddt1 = new object[] { obj16, "<td style='text-align:left;padding:5px'><a href='#PopupContent1_", item_iddt, "' data-toggle='modal' data-target='#PopupContent1_", item_iddt, "'>", sExtQuantity, "</a></td>" };
                    displayHTML = string.Concat(itemIddt1);
                }
                else
                {
                    object obj17 = displayHTML;
                    object[] objArray15 = new object[] { obj17, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray15);
                }
                if (ExtPrice != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(ExtPrice, num), "</td>");
                }
                else
                {
                    object obj18 = displayHTML;
                    object[] objArray16 = new object[] { obj18, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray16);
                }
            }
            if (this.chk6.Checked)
            {
                this.col6.Visible = true;
                this.col53.Visible = true;
                weightQuantity = ExtQuantity * Convert.ToDecimal(dt.Rows[i]["weight"].ToString());
                if (!this.chk1.Checked)
                {
                    this.col1.Visible = false;
                    this.col11.Visible = false;
                    this.col12.Visible = false;
                }
                if (!this.chk2.Checked)
                {
                    this.col2.Visible = false;
                    this.col21.Visible = false;
                    this.col22.Visible = false;
                    this.col23.Visible = false;
                    this.col24.Visible = false;
                }
                if (!this.chk3.Checked)
                {
                    this.col3.Visible = false;
                    this.col31.Visible = false;
                    this.col32.Visible = false;
                    this.col33.Visible = false;
                    this.col34.Visible = false;
                }
                if (!this.chk4.Checked)
                {
                    this.col4.Visible = false;
                    this.col41.Visible = false;
                    this.col42.Visible = false;
                    this.col43.Visible = false;
                    this.col44.Visible = false;
                }
                if (!this.chk5.Checked)
                {
                    this.col5.Visible = false;
                    this.col51.Visible = false;
                    this.col52.Visible = false;
                    this.col53.Visible = false;
                }
                if (weightQuantity != new decimal(0))
                {
                    string str = displayHTML;
                    string[] withString = new string[] { str, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(weightQuantity, num), " (", dt.Rows[i]["unit_codei"].ToString(), ") </td>" };
                    displayHTML = string.Concat(withString);
                }
                else
                {
                    object obj19 = displayHTML;
                    object[] objArray17 = new object[] { obj19, "<td style='text-align:right;padding:5px'>", '-', "</td>" };
                    displayHTML = string.Concat(objArray17);
                }
            }
            if (!this.chk1.Checked && !this.chk2.Checked && !this.chk3.Checked && !this.chk4.Checked && !this.chk5.Checked)
            {
                this.col1.Visible = false;
                this.col11.Visible = false;
                this.col12.Visible = false;
                this.col2.Visible = false;
                this.col21.Visible = false;
                this.col22.Visible = false;
                this.col23.Visible = false;
                this.col24.Visible = false;
                this.col3.Visible = false;
                this.col31.Visible = false;
                this.col32.Visible = false;
                this.col33.Visible = false;
                this.col34.Visible = false;
                this.col4.Visible = false;
                this.col41.Visible = false;
                this.col42.Visible = false;
                this.col43.Visible = false;
                this.col44.Visible = false;
                this.col5.Visible = false;
                this.col51.Visible = false;
                this.col52.Visible = false;
                this.col6.Visible = false;
                this.col53.Visible = false;
            }
            displayHTML = string.Concat(displayHTML, "</tr>");
            return displayHTML;
        }

        private string loadAdditionalPropertyData(int itemId)
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
            DateTime dateTime = DateTime.ParseExact(this.txtFDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataTable dataTable = this.objPDBll.geAdditionalPropertybyItemwithDate(itemId, dateTime, dateTime1);
            if (dataTable.Rows.Count <= 0)
            {
                str = string.Concat("<div id='PopupContent1_", itemId, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>'Not Found'</div></div></div></div>");
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
                object[] objArray = new object[] { "<div id='PopupContent1_", itemId, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", empty, "</div></div></div></div>" };
                str = string.Concat(objArray);
            }
            return str;
        }

        private void LoadItems()
        {
            try
            {
                string selectedValue = "";
                AddItemBLL addItemBLL = new AddItemBLL();
                if (this.drpProductType.SelectedValue != "")
                {
                    selectedValue = this.drpProductType.SelectedValue;
                }
                DataTable allItemByProductType = addItemBLL.GetAllItemByProductType(selectedValue);
                this.drpItem.DataSource = allItemByProductType;
                this.drpItem.DataTextField = allItemByProductType.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = allItemByProductType.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                this.Session["ITEM_INFO"] = allItemByProductType;
                ListItem listItem = new ListItem("-- Select --", "-999");
                ListItem listItem1 = new ListItem("All", "-99");
                this.drpItem.Items.Insert(0, listItem1);
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private string loadPurchaseData(int item_iddt)
        {
            AccountingBookBLL accountingBookBLL = new AccountingBookBLL();
            trnsPurchaseMasterBLL _trnsPurchaseMasterBLL = new trnsPurchaseMasterBLL();
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            string str6 = "";
            string str7 = "";
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            string empty7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            decimal num12 = new decimal(0);
            int num13 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            DateTime dateTime = DateTime.ParseExact(this.txtFDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataTable purchaseInformationByItemId = this.dbBLL.GetPurchaseInformationByItemId(dateTime, dateTime1, item_iddt);
            DataTable saleInformationByItemId = this.dbBLL.GetSaleInformationByItemId(dateTime, dateTime1, item_iddt);
            decimal num14 = new decimal(0);
            if (this.drpProductType.SelectedValue == "R")
            {
                DataTable itemLotInfo = _trnsPurchaseMasterBLL.GetItemLotInfo(item_iddt);
                if (itemLotInfo.Rows.Count < 1)
                {
                    itemLotInfo = _trnsPurchaseMasterBLL.GetItemlastLotInfo(item_iddt);
                }
                DataTable productionInformationByItemId = this.dbBLL.GetProductionInformationByItemId(dateTime, dateTime1, item_iddt);
                if (productionInformationByItemId.Rows.Count > 0)
                {
                    empty5 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'>উৎপাদন হিসাব </th></tr><tr><th  style='text-align: center;'>তারিখ</th><th>পরিমাণ</th><th>মূল্য</th><th>সম্পূরক শুল্ক</th><th>মূসক</th><th>মন্তব্য</th></tr></thead>";
                    for (int i = 0; i < productionInformationByItemId.Rows.Count; i++)
                    {
                        productionInformationByItemId.Rows[i]["item_name"].ToString();
                        num = Convert.ToDecimal(productionInformationByItemId.Rows[i]["quantity"]);
                        num12 = (Convert.ToDecimal(productionInformationByItemId.Rows[i]["unit_price"]) != new decimal(0) ? Convert.ToDecimal(productionInformationByItemId.Rows[i]["unit_price"]) : accountingBookBLL.getTotalProPrice(itemLotInfo, num));
                        num14 += num12;
                        this.production.Text = num14.ToString();
                        str7 = Utilities.formatFraction(num);
                        num2 = Convert.ToDecimal(productionInformationByItemId.Rows[i]["purchase_vat"]);
                        num3 = Convert.ToDecimal(productionInformationByItemId.Rows[i]["purchase_sd"]);
                        str6 = productionInformationByItemId.Rows[i]["remarks"].ToString();
                        string str12 = str5;
                        string[] strArrays = new string[] { str12, "<tbody><tr><td  style='text-align: center;padding:5px'>", productionInformationByItemId.Rows[i]["date_production"].ToString(), "</td><td  style='text-align:right;padding:5px'>", str7, "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num12, num13), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num3, num13), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num2, num13), "</td><td>", str6, "</td></tr></tbody>" };
                        str5 = string.Concat(strArrays);
                        str4 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty5, str5, "</table>");
                    }
                }
            }
            if (this.drpProductType.SelectedValue == "C")
            {
                DataTable finishProductProductionInformationByItemId = this.dbBLL.GetFinishProductProductionInformationByItemId(dateTime, dateTime1, item_iddt);
                if (finishProductProductionInformationByItemId.Rows.Count > 0)
                {
                    empty5 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'>উৎপাদন হিসাব </th></tr><tr><th  style='text-align: center;'>তারিখ</th><th>পরিমাণ</th><th>মূল্য</th><th>সম্পূরক শুল্ক</th><th>মূসক</th><th>মন্তব্য</th></tr></thead>";
                    for (int j = 0; j < finishProductProductionInformationByItemId.Rows.Count; j++)
                    {
                        finishProductProductionInformationByItemId.Rows[j]["item_name"].ToString();
                        num = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["quantity"]);
                        num12 = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["price"]);
                        num14 += num12;
                        this.production.Text = num14.ToString();
                        str7 = Utilities.formatFraction(num);
                        num1 = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["price"]);
                        num2 = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["purchase_vat"]);
                        num3 = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["purchase_sd"]);
                        str6 = finishProductProductionInformationByItemId.Rows[j]["remarks"].ToString();
                        string str13 = str5;
                        string[] strArrays1 = new string[] { str13, "<tbody><tr><td  style='text-align: center;padding:5px'>", finishProductProductionInformationByItemId.Rows[j]["date_challan"].ToString(), "</td><td  style='text-align:right;padding:5px'>", str7, "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num1, num13), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num3, num13), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num2, num13), "</td><td>", str6, "</td></tr></tbody>" };
                        str5 = string.Concat(strArrays1);
                        str4 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty5, str5, "</table>");
                    }
                }
            }
            if (purchaseInformationByItemId.Rows.Count > 0)
            {
                empty1 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'>ক্রয় হিসাব </th></tr><tr><th  style='text-align: center;'>তারিখ</th><th>পরিমাণ</th><th>মূল্য</th><th>সম্পূরক শুল্ক</th><th>মূসক</th><th>মন্তব্য</th></tr></thead>";
                for (int k = 0; k < purchaseInformationByItemId.Rows.Count; k++)
                {
                    purchaseInformationByItemId.Rows[k]["item_name"].ToString();
                    num4 = Convert.ToDecimal(purchaseInformationByItemId.Rows[k]["quantity"]);
                    str10 = Utilities.formatFraction(num4);
                    num5 = Convert.ToDecimal(purchaseInformationByItemId.Rows[k]["price"]);
                    num6 = Convert.ToDecimal(purchaseInformationByItemId.Rows[k]["purchase_vat"]);
                    num7 = Convert.ToDecimal(purchaseInformationByItemId.Rows[k]["purchase_sd"]);
                    str8 = purchaseInformationByItemId.Rows[k]["remarks"].ToString();
                    string str14 = str;
                    string[] strArrays2 = new string[] { str14, "<tbody><tr><td  style='text-align: center;padding:5px'>", purchaseInformationByItemId.Rows[k]["date_challan"].ToString(), "</td><td  style='text-align: right;padding:5px'>", str10, "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num5, num13), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num7, num13), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num6, num13), "</td><td>", str8, "</td></tr></tbody>" };
                    str = string.Concat(strArrays2);
                    empty8 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty1, str, "</table>");
                }
            }
            if (saleInformationByItemId.Rows.Count > 0)
            {
                empty3 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'>বিক্রয়/স্থানান্তর হিসাব </th></tr><tr><th  style='text-align: center;'>তারিখ</th><th>পরিমাণ</th><th>মূল্য</th><th>সম্পূরক শুল্ক</th><th>মূসক</th><th>মন্তব্য</th></tr></thead>";
                for (int l = 0; l < saleInformationByItemId.Rows.Count; l++)
                {
                    saleInformationByItemId.Rows[l]["item_name"].ToString();
                    num8 = Convert.ToDecimal(saleInformationByItemId.Rows[l]["quantity"]);
                    str11 = Utilities.formatFraction(num8);
                    if (str11 == "0")
                    {
                        str11 = "-";
                    }
                    num9 = Convert.ToDecimal(saleInformationByItemId.Rows[l]["price"]);
                    num10 = Convert.ToDecimal(saleInformationByItemId.Rows[l]["vat"]);
                    num11 = Convert.ToDecimal(saleInformationByItemId.Rows[l]["sd"]);
                    str9 = saleInformationByItemId.Rows[l]["remarks"].ToString();
                    string str15 = str2;
                    string[] strArrays3 = new string[] { str15, "<tbody><tr><td  style='text-align: center;padding:5px'>", saleInformationByItemId.Rows[l]["date_challan"].ToString(), "</td><td  style='text-align: right;padding:5px'>", str11, "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num9, num13), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num11, num13), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num10, num13), "</td><td>", str9, "</td></tr></tbody>" };
                    str2 = string.Concat(strArrays3);
                    empty7 = string.Concat("<table border='1' style='width: 100%; border-collapse: collapse; border: 1px solid #000000'>", empty3, str2, "</table>");
                }
            }
            object[] itemIddt = new object[] { "<div id='PopupContent_", item_iddt, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", empty8, "</div><div class='modal-body'>", empty7, "</div><div class='modal-body'>", str4, "</div></div></div></div>" };
            return string.Concat(itemIddt);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.orgId.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.txtFDate.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.btnPrint.Visible = false;
                this.chk1.Checked = true;
                this.chk2.Checked = true;
                this.chk3.Checked = true;
                this.chk4.Checked = true;
                this.chk5.Checked = true;
                this.col6.Visible = false;
                this.col53.Visible = false;
            }
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnExportToExcel);
        }

        private void showReport(string reportFormat, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            try
            {
                this.PopupContainer.InnerHtml = "";
                if (string.IsNullOrEmpty(this.txtFDate.Text) || string.IsNullOrEmpty(this.txtToDate.Text))
                {
                    this.msgBox.AddMessage(" Please insert From Date and To Date Properly ", MsgBoxs.enmMessageType.Attention);
                }
                else if (this.drpProductType.SelectedValue == "")
                {
                    this.msgBox.AddMessage(" Please Select Item Type", MsgBoxs.enmMessageType.Attention);
                }
                else if (this.drpItem.SelectedValue == "-999")
                {
                    this.msgBox.AddMessage(" Please Select Item", MsgBoxs.enmMessageType.Attention);
                }
                else
                {
                    DateTime dateTime = DateTime.ParseExact(this.txtFDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateTime1 = DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.lblFromDate.Text = dateTime.ToString("dd-MMM-yyyy");
                    this.lblToDate.Text = dateTime1.ToString("dd-MMM-yyyy");
                    this.col1.Visible = false;
                    this.col11.Visible = false;
                    this.col12.Visible = false;
                    this.col2.Visible = false;
                    this.col21.Visible = false;
                    this.col22.Visible = false;
                    this.col23.Visible = false;
                    this.col24.Visible = false;
                    this.col3.Visible = false;
                    this.col31.Visible = false;
                    this.col32.Visible = false;
                    this.col33.Visible = false;
                    this.col34.Visible = false;
                    this.col4.Visible = false;
                    this.col41.Visible = false;
                    this.col42.Visible = false;
                    this.col43.Visible = false;
                    this.col44.Visible = false;
                    this.col5.Visible = false;
                    this.col51.Visible = false;
                    this.col52.Visible = false;
                    this.col6.Visible = false;
                    this.col53.Visible = false;
                    DataTable dataTable = new DataTable();
                    string empty = string.Empty;
                    decimal num = new decimal(0);
                    decimal num1 = new decimal(0);
                    decimal num2 = new decimal(0);
                    decimal num3 = new decimal(0);
                    decimal num4 = new decimal(0);
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    string str = string.Empty;
                    string empty1 = string.Empty;
                    if (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text))
                    {
                        Convert.ToInt16(this.precisionTxtBox.Text);
                    }
                    int num8 = Convert.ToInt32(this.drpItem.SelectedValue);
                    string selectedValue = this.drpProductType.SelectedValue;
                    dataTable = this.dbBLL.GetPreodicStockReportData(dateTime, dateTime1, num8, selectedValue);
                    if (dataTable == null)
                    {
                        this.col1.Visible = true;
                        this.col11.Visible = true;
                        this.col12.Visible = true;
                        this.col2.Visible = true;
                        this.col21.Visible = true;
                        this.col22.Visible = true;
                        this.col23.Visible = true;
                        this.col24.Visible = true;
                        this.col3.Visible = true;
                        this.col31.Visible = true;
                        this.col32.Visible = true;
                        this.col33.Visible = true;
                        this.col34.Visible = true;
                        this.col4.Visible = true;
                        this.col41.Visible = true;
                        this.col42.Visible = true;
                        this.col43.Visible = true;
                        this.col44.Visible = true;
                        this.col5.Visible = true;
                        this.col51.Visible = true;
                        this.col52.Visible = true;
                        this.col6.Visible = true;
                        this.col53.Visible = true;
                        this.lblReportData.Text = empty;
                        this.PopupContainer.InnerHtml = "";
                        this.msgBox.AddMessage("No Record Found.", MsgBoxs.enmMessageType.Attention);
                    }
                    else if (dataTable.Rows.Count <= 0)
                    {
                        this.col1.Visible = true;
                        this.col11.Visible = true;
                        this.col12.Visible = true;
                        this.col2.Visible = true;
                        this.col21.Visible = true;
                        this.col22.Visible = true;
                        this.col23.Visible = true;
                        this.col24.Visible = true;
                        this.col3.Visible = true;
                        this.col31.Visible = true;
                        this.col32.Visible = true;
                        this.col33.Visible = true;
                        this.col34.Visible = true;
                        this.col4.Visible = true;
                        this.col41.Visible = true;
                        this.col42.Visible = true;
                        this.col43.Visible = true;
                        this.col44.Visible = true;
                        this.col5.Visible = true;
                        this.col51.Visible = true;
                        this.col52.Visible = true;
                        this.col6.Visible = true;
                        this.col53.Visible = true;
                        this.lblReportData.Text = empty;
                        this.PopupContainer.InnerHtml = "";
                        this.msgBox.AddMessage("No Record Found.", MsgBoxs.enmMessageType.Attention);
                    }
                    else
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            this.production.Text = "";
                            decimal num9 = new decimal(0);
                            decimal num10 = new decimal(0);
                            decimal num11 = new decimal(0);
                            decimal num12 = new decimal(0);
                            decimal num13 = new decimal(0);
                            decimal num14 = new decimal(0);
                            decimal num15 = new decimal(0);
                            decimal num16 = new decimal(0);
                            decimal num17 = new decimal(0);
                            decimal num18 = new decimal(0);
                            decimal num19 = new decimal(0);
                            decimal num20 = new decimal(0);
                            decimal num21 = new decimal(0);
                            decimal num22 = new decimal(0);
                            decimal num23 = new decimal(0);
                            decimal num24 = new decimal(0);
                            decimal num25 = new decimal(0);
                            decimal num26 = new decimal(0);
                            decimal num27 = new decimal(0);
                            decimal num28 = new decimal(0);
                            decimal num29 = new decimal(0);
                            string str1 = "";
                            string str2 = "";
                            string str3 = "";
                            string str4 = "";
                            string str5 = "";
                            int num30 = Convert.ToInt32(dataTable.Rows[i]["item_id"].ToString());
                            empty1 = this.loadAdditionalPropertyData(num30);
                            HtmlGenericControl popupContainer1 = this.PopupContainer1;
                            popupContainer1.InnerHtml = string.Concat(popupContainer1.InnerHtml, empty1);
                            str = this.loadPurchaseData(num30);
                            HtmlGenericControl popupContainer = this.PopupContainer;
                            popupContainer.InnerHtml = string.Concat(popupContainer.InnerHtml, str);
                            num9 = Convert.ToDecimal(dataTable.Rows[i]["openpurqnt"]) + Convert.ToDecimal(dataTable.Rows[i]["preQuantity"]);
                            str1 = Utilities.formatFraction(num9);
                            num10 = (num9 != new decimal(0) ? Convert.ToDecimal(dataTable.Rows[i]["openpuramount"]) + Convert.ToDecimal(dataTable.Rows[i]["preQntAmount"]) : new decimal(0));
                            num13 = Convert.ToDecimal(dataTable.Rows[i]["purqnt"].ToString());
                            str2 = Utilities.formatFraction(num13);
                            num16 = Convert.ToDecimal(dataTable.Rows[i]["puramount"].ToString());
                            num14 = Convert.ToDecimal(dataTable.Rows[i]["purvat"].ToString());
                            num15 = Convert.ToDecimal(dataTable.Rows[i]["pursd"].ToString());
                            num27 = Convert.ToDecimal(dataTable.Rows[i]["proq"].ToString());
                            num29 = Convert.ToDecimal(dataTable.Rows[i]["prot"].ToString());
                            num19 = Convert.ToDecimal(dataTable.Rows[i]["productionqnt"].ToString()) + num27;
                            str3 = Utilities.formatFraction(num19);
                            if (this.production.Text != "")
                            {
                                num22 = Convert.ToDecimal(this.production.Text);
                            }
                            num17 = Convert.ToDecimal(dataTable.Rows[i]["productionqnt"].ToString());
                            num18 = Convert.ToDecimal(dataTable.Rows[i]["productionpuramount"].ToString());
                            num20 = Convert.ToDecimal(dataTable.Rows[i]["productionpurvat"].ToString());
                            num21 = Convert.ToDecimal(dataTable.Rows[i]["productionpursd"].ToString());
                            num23 = Convert.ToDecimal(dataTable.Rows[i]["salqnt"].ToString());
                            str4 = Utilities.formatFraction(num23);
                            num24 = Convert.ToDecimal(dataTable.Rows[i]["salamount"].ToString());
                            num25 = Convert.ToDecimal(dataTable.Rows[i]["salvat"].ToString());
                             num26 = Convert.ToDecimal(dataTable.Rows[i]["salsd"].ToString());
                            num10 = 0;
                          //  num26= Convert.ToDecimal(dataTable.Rows[i]["salqnt"].ToString());
                            if (this.drpProductType.SelectedValue != "R")
                            {
                                decimal unitPrice = 0;
                                num11 = ((num9 + num13) + num17) - num23;
                                str5 = Utilities.formatFraction(num11);
                                try
                                {
                                    unitPrice = num16 / num13;
                                    num12 = num11 * (num16 / num13);
                                }
                                catch
                                {
                                    num12 = 0;
                                }
                                num10 = 0;


                            }
                            else
                            {
                                num11 = (num9 + num13) - (num23 + num27);
                                str5 = Utilities.formatFraction(num11);
                              //  num12 = (num10 + num16) - (num24 + num22);
                            }
                            if (reportFormat == "html")
                            {
                                empty = this.GetDataHtml(empty, i, dataTable, num9, num30, str1, num10, num13, str2, num16, num15, num14, num19, str3, num22, num21, num20, num23, str4, num24, num26, num25, num11, str5, num12, num28);
                            }
                            int num31 = 3;
                            if (reportFormat == "excel")
                            {
                                num31 = num31 + i + 1;
                                this.GetDataExcel(num31, empty, i, dataTable, num9, num30, str1, num10, num13, str2, num16, num15, num14, num19, str3, num22, num21, num20, num23, str4, num24, num26, num25, num11, str5, num12, num28, sheet, headerStyle);
                            }
                            num += num10;
                            num1 += num16;
                            num3 += num14;
                            num2 += num15;
                            num5 = num5 + num24 + num29;
                            num7 += num25;
                            num6 += num26;
                            num4 += num12;
                            this.lblReportData.Text = empty;
                        }
                    }
                    this.btnPrint.Visible = true;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}