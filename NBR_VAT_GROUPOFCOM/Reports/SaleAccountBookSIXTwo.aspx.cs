using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
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
    public partial class SaleAccountBookSIXTwo : Page, IRequiresSessionState
    {
       

        private AccountingBookBLL objAccountingBook = new AccountingBookBLL();

        private trnsSaleMasterBLL saleUnit = new trnsSaleMasterBLL();

        private trnsPurchaseMasterBLL productionUnit = new trnsPurchaseMasterBLL();

        private string unitCode = string.Empty;

        private string productionUnitCode = string.Empty;

        private ExcelUtility excelUtility = new ExcelUtility();

        private bool notRawMt;

      

        public SaleAccountBookSIXTwo()
        {
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string str = "Sales_Account_Book_Form17_N";
            HSSFWorkbook hSSFWorkbook = new HSSFWorkbook();
            ISheet sheet = hSSFWorkbook.CreateSheet(str);
            int num = 6;
            HSSFCellStyle hSSFCellStyle = this.excelUtility.headerBorderStyle(hSSFWorkbook);
            this.GenerateHeader(hSSFWorkbook, sheet, hSSFCellStyle);
            this.ReportGenerate("excel", sheet, hSSFCellStyle, hSSFWorkbook, num);
            this.excelUtility.downloadExcel(hSSFWorkbook, sheet, base.Response, str);
        }

        protected void drpProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Load_product();
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
            IRow rows2 = sheet.CreateRow(4);
            IRow rows3 = sheet.CreateRow(5);
            this.excelUtility.CreateCell(rows, 0, "পণ্য/ সেবার বিক্রয়", headerStyle);
            this.excelUtility.CreateCell(rows1, 0, "ক্রমিক সংখ্যা", headerStyle);
            this.excelUtility.CreateCell(rows1, 1, "তারিখ", headerStyle);
            this.excelUtility.CreateCell(rows1, 2, "উৎপাদিত পণ্যের প্রারম্ভিক জের", headerStyle);
            this.excelUtility.CreateCell(rows1, 4, "উৎপাদন", headerStyle);
            this.excelUtility.CreateCell(rows1, 6, "মোট উৎপাদিত পণ্য/সেবা", headerStyle);
            this.excelUtility.CreateCell(rows1, 8, "ক্রেতা/ সরবরাহগ্রহীতা", headerStyle);
            this.excelUtility.CreateCell(rows1, 11, "চালানপত্রের বিবরণ", headerStyle);
            this.excelUtility.CreateCell(rows1, 13, "বিক্রিত/সরবরাহকৃত পণ্যের বিবরণ", headerStyle);
            this.excelUtility.CreateCell(rows1, 18, "পণ্যের প্রান্তিক জের", headerStyle);
            this.excelUtility.CreateCell(rows1, 20, "মন্তব্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 2, "পরিমাণ (একক)", headerStyle);
            this.excelUtility.CreateCell(rows2, 3, "মূল্য (সকল প্রকার কর ব্যতীত)", headerStyle);
            this.excelUtility.CreateCell(rows2, 4, "পরিমাণ (একক)", headerStyle);
            this.excelUtility.CreateCell(rows2, 5, "মূল্য (সকল প্রকার কর ব্যতিত)", headerStyle);
            this.excelUtility.CreateCell(rows2, 6, "পরিমাণ (একক)", headerStyle);
            this.excelUtility.CreateCell(rows2, 7, "মূল্য (সকল প্রকার কর ব্যতীত)", headerStyle);
            this.excelUtility.CreateCell(rows2, 8, "নাম", headerStyle);
            this.excelUtility.CreateCell(rows2, 9, "ঠিকানা", headerStyle);
            this.excelUtility.CreateCell(rows2, 10, "নিবন্ধন /তালিকাভুক্তি/ জাতীয় পরিচয়পত্র নং", headerStyle);
            this.excelUtility.CreateCell(rows2, 11, "নম্বর", headerStyle);
            this.excelUtility.CreateCell(rows2, 12, "তারিখ", headerStyle);
            this.excelUtility.CreateCell(rows2, 13, "বিবরণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 14, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 15, "করযোগ্য মূল্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 16, "সম্পূরক শুল্ক(যদি থাকে)", headerStyle);
            this.excelUtility.CreateCell(rows2, 17, "মুসক", headerStyle);
            this.excelUtility.CreateCell(rows2, 18, "পরিমাণ (একক)", headerStyle);
            this.excelUtility.CreateCell(rows2, 19, "মূল্য (সকল প্রকার কর ব্যতিত)", headerStyle);
            for (int i = 0; i <= 20; i++)
            {
                int num = i + 1;
                this.excelUtility.CreateCell(rows3, i, string.Concat("(", num, ")"), headerStyle);
            }
            this.excelUtility.MergeCell(workbook, sheet, 0, 1, 0, 20);
            this.excelUtility.MergeCell(workbook, sheet, 2, 4, 0, 0);
            this.excelUtility.MergeCell(workbook, sheet, 2, 4, 1, 1);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 2, 3);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 4, 5);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 6, 7);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 8, 10);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 11, 12);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 13, 17);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 18, 19);
            this.excelUtility.MergeCell(workbook, sheet, 2, 4, 20, 20);
        }

        private void GetDataExcelIfIGZ(string displayHtml, DataTable dt, int i, string currentDate, decimal prarombikJerQty, decimal prarombikJerValue, decimal column5, decimal column6, decimal result, decimal result8, decimal sQuantity, decimal sPrice, decimal sSD, decimal sVAT, decimal prantikJerQty, decimal prantikJerValue, int precision, string productionUnitCode, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook, int rowIndex)
        {
            IRow rows = sheet.CreateRow(rowIndex);
            this.excelUtility.CreateCell(rows, 0, string.Concat(i + 1), headerStyle);
            string str = (string.IsNullOrEmpty(productionUnitCode) ? "PACK" : productionUnitCode);
            string str1 = (string.IsNullOrEmpty(currentDate) ? dt.Rows[i]["challan_date"].ToString() : currentDate);
            displayHtml = string.Concat(displayHtml, "<td>", str1, "</td>");
            this.excelUtility.CreateCell(rows, 1, str1, headerStyle);
            ExcelUtility excelUtility = this.excelUtility;
            object[] objArray = new object[] { prarombikJerQty, "(", str, ")" };
            excelUtility.CreateCell(rows, 2, string.Concat(objArray), headerStyle);
            this.excelUtility.CreateCell(rows, 3, Utilities.RoundUpToWithString(prarombikJerValue, precision), headerStyle);
            this.excelUtility.CreateCell(rows, 4, string.Concat(Utilities.formatFraction(column5), "(", str, ")"), headerStyle);
            this.excelUtility.CreateCell(rows, 5, Utilities.RoundUpToWithString(column6, precision), headerStyle);
            this.excelUtility.CreateCell(rows, 6, string.Concat(Utilities.formatFraction(result), " (", str, ")"), headerStyle);
            this.excelUtility.CreateCell(rows, 7, Utilities.RoundUpToWithString(result8, precision), headerStyle);
            this.excelUtility.CreateCell(rows, 8, string.Concat(dt.Rows[i]["party_name"]), headerStyle);
            this.excelUtility.CreateCell(rows, 9, string.Concat(dt.Rows[i]["party_address"]), headerStyle);
            if (dt.Rows[i]["reg_type"].ToString() != "5")
            {
                this.excelUtility.CreateCell(rows, 10, string.Concat(dt.Rows[i]["party_bin"]), headerStyle);
            }
            else
            {
                this.excelUtility.CreateCell(rows, 10, string.Concat(dt.Rows[i]["national_id_no"]), headerStyle);
            }
            this.excelUtility.CreateCell(rows, 11, string.Concat(dt.Rows[i]["challan_no"]), headerStyle);
            this.excelUtility.CreateCell(rows, 12, currentDate ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 13, string.Concat(dt.Rows[i]["item_name"]), headerStyle);
            this.excelUtility.CreateCell(rows, 14, string.Concat(Utilities.formatFraction(sQuantity), "(", str, ")"), headerStyle);
            this.excelUtility.CreateCell(rows, 15, Utilities.RoundUpToWithString(sPrice, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 16, Utilities.RoundUpToWithString(sSD, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 17, Utilities.RoundUpToWithString(sVAT, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 18, string.Concat(Utilities.formatFraction(prantikJerQty), "(", str, ")"), headerStyle);
            this.excelUtility.CreateCell(rows, 19, Utilities.RoundUpToWithString(prantikJerValue, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 20, string.Concat(dt.Rows[i]["remarks"]), headerStyle);
        }

        private void GetDataExcelIFZ(string displayHtml, int i, string currentDate, decimal prarombikJerQty, decimal prarombikJerValue, string productionUnitCode, int precision, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook, int rowIndex)
        {
            IRow rows = sheet.CreateRow(rowIndex);
            this.excelUtility.CreateCell(rows, 0, string.Concat(i), headerStyle);
            this.excelUtility.CreateCell(rows, 1, currentDate ?? "", headerStyle);
            ExcelUtility excelUtility = this.excelUtility;
            object[] objArray = new object[] { prarombikJerQty, '(', productionUnitCode, ')' };
            excelUtility.CreateCell(rows, 2, string.Concat(objArray), headerStyle);
            this.excelUtility.CreateCell(rows, 3, Utilities.RoundUpToWithString(prarombikJerValue, precision) ?? "", headerStyle);
            for (int num = 4; num <= 17; num++)
            {
                this.excelUtility.CreateCell(rows, num, "--", headerStyle);
            }
            ExcelUtility excelUtility1 = this.excelUtility;
            object[] objArray1 = new object[] { prarombikJerQty, '(', productionUnitCode, ')' };
            excelUtility1.CreateCell(rows, 18, string.Concat(objArray1), headerStyle);
            this.excelUtility.CreateCell(rows, 19, Utilities.RoundUpToWithString(prarombikJerValue, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 20, "--", headerStyle);
        }

        private string GetDataHtmlIfIGZ(string displayHtml, DataTable dt, int i, string currentDate, decimal prarombikJerQty, decimal prarombikJerValue, decimal column5, decimal column6, decimal result, decimal result8, decimal sQuantity, decimal sPrice, decimal sSD, decimal sVAT, decimal prantikJerQty, decimal prantikJerValue, int precision, string productionUnitCode, bool design)
        {
            if (design)
            {
                string str = (string.IsNullOrEmpty(productionUnitCode) ? "PACK" : productionUnitCode);
                displayHtml = string.Concat(displayHtml, "<tr>");
                object obj = displayHtml;
                object[] objArray = new object[] { obj, "<td style='text-align: center;'>", i + 1, "</td>" };
                displayHtml = string.Concat(objArray);
                displayHtml = string.Concat(displayHtml, "<td>", (string.IsNullOrEmpty(currentDate) ? dt.Rows[i]["challan_date"].ToString() : currentDate), "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                object obj1 = displayHtml;
                object[] item = new object[] { obj1, "<td>", dt.Rows[i]["challan_no"], "</td>" };
                displayHtml = string.Concat(item);
                displayHtml = string.Concat(displayHtml, "<td>", currentDate, "</td>");
                object obj2 = displayHtml;
                object[] item1 = new object[] { obj2, "<td style='text-align: left;'>", dt.Rows[i]["item_name"], "</td>" };
                displayHtml = string.Concat(item1);
                string str1 = displayHtml;
                string[] strArrays = new string[] { str1, "<td style='text-align: right;'>", Utilities.formatFraction(sQuantity), "(", str, ")</td>" };
                displayHtml = string.Concat(strArrays);
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(sPrice, precision), "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(sSD, precision), "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(sVAT, precision), "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                object obj3 = displayHtml;
                object[] objArray1 = new object[] { obj3, "<td>", dt.Rows[i]["remarks"], "</td>" };
                displayHtml = string.Concat(objArray1);
                displayHtml = string.Concat(displayHtml, "</tr>");
                return displayHtml;
            }
            string str2 = (string.IsNullOrEmpty(productionUnitCode) ? "PACK" : productionUnitCode);
            displayHtml = string.Concat(displayHtml, "<tr>");
            object obj4 = displayHtml;
            object[] objArray2 = new object[] { obj4, "<td style='text-align: center;'>", i + 1, "</td>" };
            displayHtml = string.Concat(objArray2);
            displayHtml = string.Concat(displayHtml, "<td>", (string.IsNullOrEmpty(currentDate) ? dt.Rows[i]["challan_date"].ToString() : currentDate), "</td>");
            string str3 = displayHtml;
            string[] withString = new string[] { str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(prarombikJerQty, precision), "(", str2, ")</td>" };
            displayHtml = string.Concat(withString);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(prarombikJerValue, precision), "</td>");
            string str4 = displayHtml;
            string[] strArrays1 = new string[] { str4, "<td style='text-align: right;'>", Utilities.formatFraction(column5), "(", str2, ")</td>" };
            displayHtml = string.Concat(strArrays1);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(column6, precision), "</td>");
            string str5 = displayHtml;
            string[] strArrays2 = new string[] { str5, "<td style='text-align: right;'>", Utilities.formatFraction(result), " (", str2, ")</td>" };
            displayHtml = string.Concat(strArrays2);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(result8, precision), "</td>");
            object obj5 = displayHtml;
            object[] item2 = new object[] { obj5, "<td style='text-align: left;'>", dt.Rows[i]["party_name"], "</td>" };
            displayHtml = string.Concat(item2);
            object obj6 = displayHtml;
            object[] item3 = new object[] { obj6, "<td style='text-align: left;'>", dt.Rows[i]["party_address"], "</td>" };
            displayHtml = string.Concat(item3);
            if (dt.Rows[i]["reg_type"].ToString() != "5")
            {
                object obj7 = displayHtml;
                object[] objArray3 = new object[] { obj7, "<td style='text-align: left;'>", dt.Rows[i]["party_bin"], "</td>" };
                displayHtml = string.Concat(objArray3);
            }
            else
            {
                object obj8 = displayHtml;
                object[] item4 = new object[] { obj8, "<td style='text-align: left;'>", dt.Rows[i]["national_id_no"], "</td>" };
                displayHtml = string.Concat(item4);
            }
            object obj9 = displayHtml;
            object[] objArray4 = new object[] { obj9, "<td>", dt.Rows[i]["challan_no"], "</td>" };
            displayHtml = string.Concat(objArray4);
            displayHtml = string.Concat(displayHtml, "<td>", currentDate, "</td>");
            object obj10 = displayHtml;
            object[] item5 = new object[] { obj10, "<td style='text-align: left;'>", dt.Rows[i]["item_name"], "</td>" };
            displayHtml = string.Concat(item5);
            string str6 = displayHtml;
            string[] strArrays3 = new string[] { str6, "<td style='text-align: right;'>", Utilities.formatFraction(sQuantity), "(", str2, ")</td>" };
            displayHtml = string.Concat(strArrays3);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(sPrice, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(sSD, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(sVAT, precision), "</td>");
            string str7 = displayHtml;
            string[] strArrays4 = new string[] { str7, "<td style='text-align: right;'>", Utilities.formatFraction(prantikJerQty), "(", str2, ")</td>" };
            displayHtml = string.Concat(strArrays4);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(prantikJerValue, precision), "</td>");
            object obj11 = displayHtml;
            object[] objArray5 = new object[] { obj11, "<td>", dt.Rows[i]["remarks"], "</td>" };
            displayHtml = string.Concat(objArray5);
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private string GetDataHtmlIFZ(string displayHtml, string currentDate, decimal prarombikJerQty, decimal prarombikJerValue, string productionUnitCode, int precision, bool design)
        {
            if (design)
            {
                return null;
            }
            displayHtml = string.Concat(displayHtml, "<tr>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: center;'> 0 </td>");
            displayHtml = string.Concat(displayHtml, "<td>", currentDate, "</td>");
            object obj = displayHtml;
            object[] objArray = new object[] { obj, "<td style='text-align: right;'>", prarombikJerQty, '(', productionUnitCode, ')', "</td>" };
            displayHtml = string.Concat(objArray);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(prarombikJerValue, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td>--</td>");
            displayHtml = string.Concat(displayHtml, "<td>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--<td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            object obj1 = displayHtml;
            object[] objArray1 = new object[] { obj1, "<td style='text-align: right;'>", prarombikJerQty, '(', productionUnitCode, ')', "</td>" };
            displayHtml = string.Concat(objArray1);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(prarombikJerValue, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private void GetTotalExcel(string displayHtml, decimal pTotalQuantity, decimal pTotalPrice, decimal ptTotalQuantity, decimal ptTotalPrice, decimal slTotalQuantity, decimal slTotalPrice, decimal sTotalSD, decimal sTotalVat, decimal sTotalQuantity, decimal sTotalPrice, int precision, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook, int rowIndex)
        {
            IRow rows = sheet.CreateRow(rowIndex);
            this.excelUtility.CreateCell(rows, 0, "মোট", headerStyle);
            this.excelUtility.CreateCell(rows, 4, Utilities.RoundUpToWithString(pTotalQuantity, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 5, Utilities.RoundUpToWithString(pTotalPrice, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 6, Utilities.RoundUpToWithString(ptTotalQuantity, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 7, Utilities.RoundUpToWithString(ptTotalPrice, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 14, Utilities.RoundUpToWithString(slTotalQuantity, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 15, Utilities.RoundUpToWithString(slTotalPrice, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 16, Utilities.RoundUpToWithString(sTotalSD, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 17, Utilities.RoundUpToWithString(sTotalVat, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 18, Utilities.RoundUpToWithString(sTotalQuantity, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 19, Utilities.RoundUpToWithString(sTotalPrice, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 20, "", headerStyle);
            this.excelUtility.MergeCell(workbook, sheet, rowIndex, rowIndex, 0, 3);
            this.excelUtility.MergeCell(workbook, sheet, rowIndex, rowIndex, 8, 13);
        }

        private string GetTotalHtml(string displayHtml, decimal pTotalQuantity, decimal pTotalPrice, decimal ptTotalQuantity, decimal ptTotalPrice, decimal slTotalQuantity, decimal slTotalPrice, decimal sTotalSD, decimal sTotalVat, decimal sTotalQuantity, decimal sTotalPrice, int precision)
        {
            displayHtml = string.Concat(displayHtml, "<tr>");
            displayHtml = string.Concat(displayHtml, "<td colspan='8' style='text-align: right;padding:5px; font-weight:bold;'>মোট :</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(slTotalQuantity, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(slTotalPrice, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(sTotalSD, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(sTotalVat, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: center;'></td>");
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private void Load_product()
        {
            string selectedValue = "";
            AddItemBLL addItemBLL = new AddItemBLL();
            if (this.Purchase17_drpProductType.SelectedValue != "")
            {
                selectedValue = this.Purchase17_drpProductType.SelectedValue;
            }
            DataTable allItemByProductType = addItemBLL.GetAllItemByProductType(selectedValue);
            this.ddlItem.DataSource = allItemByProductType;
            this.ddlItem.DataTextField = allItemByProductType.Columns["ITEM_NAME"].ToString();
            this.ddlItem.DataValueField = allItemByProductType.Columns["ITEM_ID"].ToString();
            this.ddlItem.DataBind();
            this.Session["ITEM_INFO"] = allItemByProductType;
        }

        private void LoadItem()
        {
            try
            {
                DataTable saleAllItem62 = this.objAccountingBook.GetSaleAllItem62();
                if (saleAllItem62.Rows.Count > 0)
                {
                    this.ddlItem.DataSource = saleAllItem62;
                    this.ddlItem.DataTextField = saleAllItem62.Columns["item_name"].ToString();
                    this.ddlItem.DataValueField = saleAllItem62.Columns["item_id"].ToString();
                    this.ddlItem.DataBind();
                    ListItem listItem = new ListItem("ALL", "-99");
                    this.ddlItem.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                ListItem listItem = new ListItem("----Select----", "-99");
                this.ddlItem.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("Finished Product (Production)", "C");
                this.Purchase17_drpProductType.Items.Insert(0, listItem1);
                this.Load_product();
                this.dtpDateFrom.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["employee_name"].ToString();
                this.TaxOrganizationName.Text = (this.Session["ORGANIZATION_NAME"] != null ? this.Session["ORGANIZATION_NAME"].ToString() : "n/a");
                this.TaxOrganizationAddress.Text = (this.Session["ORGANIZATION_ADDRESS"] != null ? this.Session["ORGANIZATION_ADDRESS"].ToString() : "n/a");
                string str = this.Session["ORGANIZATION_BIN"].ToString();
                string str1 = "";
                for (int i = 0; i < str.Length; i++)
                {
                    object obj = str1;
                    object[] objArray = new object[] { obj, "<input type='text' value = '", str[i], "' runat='server' style='width:25px; text-align:center;border:1px solid #000'>" };
                    str1 = string.Concat(objArray);
                    this.TaxOrganizationBIN.Text = str1;
                }
            }
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnExportToExcel);
        }

        private void ReportGenerate(string reportFormat, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook, int dataRow)
        {
            PriceDeclaretionBLL priceDeclaretionBLL = new PriceDeclaretionBLL();
            DataTable dataTable = new DataTable();
            DataTable pSAvgValue = new DataTable();
            int num = 0;
            decimal num1 = new decimal(0);
            DataTable dataTable1 = new DataTable();
            DataTable purchaseUnitId = new DataTable();
            CSVXMLBLL cSVXMLBLL = new CSVXMLBLL();
            try
            {
                if (this.dtpDateFrom.Text.ToString() != null && this.dtpDateTo.Text.ToString() != null)
                {
                    int num2 = 0;
                    DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string empty = string.Empty;
                    empty = this.dtpDateFrom.Text.ToString();
                    DateTime dateTime2 = dateTime.AddDays(-1);
                    string str = dateTime2.ToString("yyyy-MM-dd");
                    dateTime2.ToString("dd-MM-yyyy");
                    if (this.ddlItem.SelectedValue != "-99")
                    {
                        num = Convert.ToInt32(this.ddlItem.SelectedValue);
                    }
                    int num3 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                    dataTable = this.objAccountingBook.SalesAccountingBook(dateTime, dateTime1, num, num2);
                    DataTable openingBalanceStock = this.objAccountingBook.GetOpeningBalanceStock(num, dateTime, dateTime1);
                    pSAvgValue = this.objAccountingBook.GetPSAvgValue(num);
                    num1 = (pSAvgValue.Rows[0]["purchase_unit_price"] != null ? Convert.ToDecimal(pSAvgValue.Rows[0]["purchase_unit_price"]) : new decimal(0));
                    this.saleUnit.GetSales_unitId(dateTime, dateTime1, num, num2);
                    purchaseUnitId = this.productionUnit.GetPurchase_unitId(dateTime, dateTime1, num, num2);
                    if (purchaseUnitId != null && purchaseUnitId.Rows.Count > 0 && this.unitCode == "")
                    {
                        this.unitCode = purchaseUnitId.Rows[0]["unit_code"].ToString();
                    }
                    string dataHtmlIFZ = "";
                    string str1 = "";
                    int num4 = dataRow;
                    if (dataTable == null || dataTable.Rows.Count <= 0)
                    {
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        decimal num7 = new decimal(0);
                        decimal num8 = new decimal(0);
                        decimal num9 = new decimal(0);
                        decimal num10 = new decimal(0);
                        decimal num11 = new decimal(0);
                        decimal num12 = new decimal(0);
                        decimal num13 = new decimal(0);
                        decimal num14 = new decimal(0);
                        decimal earlyAvailableStockForSale = new decimal(0);
                        decimal num15 = new decimal(0);
                        decimal num16 = new decimal(0);
                        earlyAvailableStockForSale = this.objAccountingBook.GetEarlyAvailableStockForSale(str, num);
                        DataTable earlyAvailableStockUnitForSale = this.objAccountingBook.GetEarlyAvailableStockUnitForSale(str, num);
                        if (earlyAvailableStockForSale != new decimal(0))
                        {
                            num15 = earlyAvailableStockForSale;
                            num16 = Convert.ToDecimal(earlyAvailableStockForSale) * num1;
                            str1 = this.dtpDateFrom.Text.ToString();
                            if (earlyAvailableStockUnitForSale.Rows.Count > 0)
                            {
                                this.unitCode = earlyAvailableStockUnitForSale.Rows[0]["unit_code"].ToString();
                            }
                        }
                        else if (openingBalanceStock.Rows.Count > 0)
                        {
                            num15 = Convert.ToDecimal(openingBalanceStock.Rows[0]["item_qty"]);
                            num16 = Convert.ToDecimal(openingBalanceStock.Rows[0]["item_value"]);
                            str1 = openingBalanceStock.Rows[0]["opening_balance_date"].ToString();
                            num16 = Convert.ToDecimal(openingBalanceStock.Rows[0]["item_value"]);
                            this.unitCode = openingBalanceStock.Rows[0]["unit_code"].ToString();
                        }
                        if (reportFormat == "html")
                        {
                            dataHtmlIFZ = this.GetDataHtmlIFZ(dataHtmlIFZ, str1, num15, num16, this.unitCode, num3, this.notRawMt);
                        }
                        if (reportFormat == "excel")
                        {
                            this.GetDataExcelIFZ(dataHtmlIFZ, 0, str1, num15, num16, this.unitCode, num3, sheet, headerStyle, workbook, num4);
                        }
                        num7 = num16;
                        num8 = num15;
                        if (reportFormat == "html")
                        {
                            dataHtmlIFZ = this.GetTotalHtml(dataHtmlIFZ, num10, num9, num12, num11, num14, num13, num5, num6, num8, num7, num3);
                        }
                        if (reportFormat == "excel")
                        {
                            num4++;
                            this.GetTotalExcel(dataHtmlIFZ, num10, num9, num12, num11, num14, num13, num5, num6, num8, num7, num3, sheet, headerStyle, workbook, num4);
                        }
                        if (!(earlyAvailableStockForSale == new decimal(0)) || openingBalanceStock.Rows.Count != 0)
                        {
                            this.lblReportView.Text = dataHtmlIFZ;
                        }
                        else
                        {
                            this.lblReportView.Text = "";
                        }
                    }
                    else
                    {
                        this.productionUnitCode = dataTable.Rows[0]["unit_code"].ToString();
                        this.unitCode = dataTable.Rows[0]["unit_code"].ToString();
                        DataTable dataTable2 = priceDeclaretionBLL.gethsCodebyItemID(num);
                        decimal earlyAvailableStockForSale1 = new decimal(0);
                        decimal num17 = new decimal(0);
                        decimal num18 = new decimal(0);
                        decimal num19 = new decimal(0);
                        decimal num20 = new decimal(0);
                        string str2 = "";
                        decimal num21 = new decimal(0);
                        decimal num22 = new decimal(0);
                        decimal num23 = new decimal(0);
                        decimal num24 = new decimal(0);
                        decimal num25 = new decimal(0);
                        decimal num26 = new decimal(0);
                        decimal num27 = new decimal(0);
                        decimal num28 = new decimal(0);
                        decimal num29 = new decimal(0);
                        decimal num30 = new decimal(0);
                        decimal num31 = new decimal(0);
                        decimal num32 = new decimal(0);
                        decimal num33 = new decimal(0);
                        decimal num34 = new decimal(0);
                        decimal num35 = new decimal(0);
                        decimal num36 = new decimal(0);
                        decimal num37 = new decimal(0);
                        decimal num38 = new decimal(0);
                        decimal num39 = new decimal(0);
                        decimal num40 = new decimal(0);
                        decimal num41 = new decimal(0);
                        decimal num42 = new decimal(0);
                        decimal num43 = new decimal(0);
                        decimal num44 = new decimal(0);
                        decimal num45 = new decimal(1);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            if (dataTable2.Rows.Count > 0)
                            {
                                if (dataTable2.Rows[0]["hs_code"].ToString() == "2402.20.00" || dataTable2.Rows[0]["hs_code"].ToString() == "2402.90.00" || dataTable2.Rows[0]["hs_code"].ToString() == "2403.99.00")
                                {
                                    DataTable prpQuantitybyItemID = priceDeclaretionBLL.getPrpQuantitybyItemID(num);
                                    if (prpQuantitybyItemID.Rows.Count > 0)
                                    {
                                        num45 = Convert.ToDecimal(prpQuantitybyItemID.Rows[0]["property_quantity"].ToString());
                                    }
                                    if (i <= 0)
                                    {
                                        earlyAvailableStockForSale1 = this.objAccountingBook.GetEarlyAvailableStockForSale(str, num) / num45;
                                        num21 = Convert.ToDecimal(earlyAvailableStockForSale1) * num1;
                                        str2 = dataTable.Rows[i]["status"].ToString();
                                        if (str2 == "P")
                                        {
                                            num17 = Convert.ToInt32(dataTable.Rows[i]["quantity"]);
                                            num23 = Convert.ToInt32(dataTable.Rows[i]["unit_price"]);
                                            num19 = new decimal(0);
                                            num41 = new decimal(0);
                                            num26 = new decimal(0);
                                            num36 = new decimal(0);
                                            num39 = new decimal(0);
                                            num44 = new decimal(0);
                                            num22 = num17 * num23;
                                            num42 = earlyAvailableStockForSale1 + num17;
                                            num43 = num22 + num21;
                                            num38 = new decimal(0);
                                            num35 = new decimal(0);
                                        }
                                        if (str2 == "S")
                                        {
                                            num17 = new decimal(0);
                                            num23 = new decimal(0);
                                            num19 = Convert.ToInt32(dataTable.Rows[i]["QuantityAct"]);
                                            num41 = num19;
                                            num44 = Convert.ToInt32(dataTable.Rows[i]["unit_price"]);
                                            num25 = num19 * num44;
                                            num26 = num25;
                                            num22 = new decimal(0);
                                            num42 = (earlyAvailableStockForSale1 > new decimal(0) ? earlyAvailableStockForSale1 - num19 : num19 - earlyAvailableStockForSale1);
                                            num38 = Convert.ToInt32(dataTable.Rows[i]["sd"]);
                                            num39 = num38;
                                            num40 += num38;
                                            num35 = Convert.ToInt32(dataTable.Rows[i]["vat"]);
                                            num36 = num35;
                                            num37 += num35;
                                            num43 = (num21 > new decimal(0) ? num21 - num25 : num25 - num21);
                                        }
                                        cSVXMLBLL.GetPrarombikJer(num, empty);
                                        decimal num46 = new decimal(0);
                                        decimal num47 = new decimal(0);
                                        decimal num48 = new decimal(0);
                                        decimal num49 = new decimal(0);
                                        decimal num50 = new decimal(0);
                                        decimal num51 = new decimal(0);
                                        decimal num52 = new decimal(0);
                                        decimal num53 = new decimal(0);
                                        num50 = Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"]) / num45;
                                        num46 = earlyAvailableStockForSale1;
                                        num47 = num21;
                                        str1 = dataTable.Rows[i]["challan_date"].ToString();
                                        if (reportFormat == "html")
                                        {
                                            dataHtmlIFZ = this.GetDataHtmlIFZ(dataHtmlIFZ, str1, num46, num47, this.productionUnitCode, num3, this.notRawMt);
                                        }
                                        if (reportFormat == "excel")
                                        {
                                            this.GetDataExcelIFZ(dataHtmlIFZ, i, str1, num46, num47, this.productionUnitCode, num3, sheet, headerStyle, workbook, num4);
                                        }
                                        if (dataTable.Rows[i]["item_type"].ToString() != "S")
                                        {
                                            num48 = (num46 + Convert.ToDecimal(num50)) - Convert.ToDecimal(num41);
                                        }
                                        num49 = (dataTable.Rows[i]["challan_type"].ToString() != "O" ? (num47 + Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"])) - Convert.ToDecimal(num26) : (num47 + Convert.ToDecimal(dataTable.Rows[i]["unit_price"])) - Convert.ToDecimal(num26));
                                        num51 = (dataTable.Rows[i]["challan_type"].ToString() != "O" ? Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]) : Convert.ToDecimal(dataTable.Rows[i]["unit_price"]));
                                        num52 = Convert.ToDecimal(num46) + num50;
                                        num53 = num47 + num51;
                                        if (reportFormat == "html")
                                        {
                                            dataHtmlIFZ = this.GetDataHtmlIfIGZ(dataHtmlIFZ, dataTable, i, str1, num46, num47, num50, num51, num52, num53, num41, num26, num39, num36, num48, num49, num3, this.productionUnitCode, this.notRawMt);
                                        }
                                        if (reportFormat == "excel")
                                        {
                                            num4 = num4 + i + 1;
                                            this.GetDataExcelIfIGZ(dataHtmlIFZ, dataTable, i, str1, num46, num47, num50, num51, num52, num53, num41, num26, num39, num36, num48, num49, num3, this.productionUnitCode, sheet, headerStyle, workbook, num4);
                                        }
                                        num30 += num50;
                                        num29 += Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]);
                                        num32 += num52;
                                        num31 += num53;
                                        num34 += num41;
                                        num33 += num26;
                                        this.hiddenPrantikJerQty.Value = num48.ToString();
                                        this.hiddenPrantikJerValue.Value = num49.ToString();
                                        num28 = num48;
                                        num27 = num49;
                                        this.lblReportView.Text = dataHtmlIFZ;
                                        earlyAvailableStockForSale1 = num42;
                                        num21 = num43;
                                    }
                                    else
                                    {
                                        decimal num54 = new decimal(0);
                                        decimal num55 = new decimal(0);
                                        decimal num56 = new decimal(0);
                                        decimal num57 = new decimal(0);
                                        decimal num58 = new decimal(0);
                                        decimal num59 = new decimal(0);
                                        decimal num60 = new decimal(0);
                                        decimal num61 = new decimal(0);
                                        str2 = dataTable.Rows[i]["status"].ToString();
                                        if (str2 == "P")
                                        {
                                            num17 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                            num23 = Convert.ToInt32(dataTable.Rows[i]["unit_price"]);
                                            num19 = new decimal(0);
                                            num41 = new decimal(0);
                                            num26 = new decimal(0);
                                            num36 = new decimal(0);
                                            num39 = new decimal(0);
                                            num44 = new decimal(0);
                                            num22 = num17 * num23;
                                            num42 = earlyAvailableStockForSale1 + num17;
                                            num43 = num22 + num21;
                                            num38 = new decimal(0);
                                            num35 = new decimal(0);
                                        }
                                        if (str2 == "S")
                                        {
                                            num17 = new decimal(0);
                                            num23 = new decimal(0);
                                            num19 = Convert.ToDecimal(dataTable.Rows[i]["QuantityAct"]);
                                            num24 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                            num41 = num19;
                                            num44 = Convert.ToDecimal(dataTable.Rows[i]["unit_price"]);
                                            num25 = num24 * num44;
                                            num26 = num25;
                                            num22 = new decimal(0);
                                            num42 = (earlyAvailableStockForSale1 > new decimal(0) ? earlyAvailableStockForSale1 - num19 : num19 - earlyAvailableStockForSale1);
                                            num38 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                            num39 = num38;
                                            num40 += num38;
                                            num35 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                            num36 = num35;
                                            num37 += num35;
                                            num43 = (num21 > new decimal(0) ? num21 - num25 : num25 - num21);
                                            DataTable prarombikJer = cSVXMLBLL.GetPrarombikJer(num, empty);
                                            cSVXMLBLL.GetPrarombikJer(num, empty);
                                            if (prarombikJer.Rows.Count > 0)
                                            {
                                                num54 = Convert.ToDecimal(this.hiddenPrantikJerQty.Value);
                                                num55 = Convert.ToDecimal(this.hiddenPrantikJerValue.Value);
                                                if (dataTable.Rows[i]["item_type"].ToString() != "S")
                                                {
                                                    num56 = (num54 + Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"])) - Convert.ToDecimal(num41);
                                                }
                                                num57 = (num55 + Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"])) - Convert.ToDecimal(num26);
                                            }
                                        }
                                        num18 = num20 + num17;
                                        string.Concat(dataTable.Rows[i]["party_name"].ToString(), ", ", dataTable.Rows[i]["party_bin"].ToString());
                                        str1 = dataTable.Rows[i]["challan_date"].ToString();
                                        if (this.hiddenPrantikJerQty.Value != "")
                                        {
                                            num54 = Convert.ToDecimal(this.hiddenPrantikJerQty.Value);
                                        }
                                        if (this.hiddenPrantikJerValue.Value != "")
                                        {
                                            num55 = Convert.ToDecimal(this.hiddenPrantikJerValue.Value);
                                        }
                                        num58 = Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"].ToString());
                                        num59 = Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]);
                                        num60 = Convert.ToDecimal(num54) + Convert.ToDecimal(num58);
                                        num61 = num55 + num59;
                                        if (reportFormat == "html")
                                        {
                                            dataHtmlIFZ = this.GetDataHtmlIfIGZ(dataHtmlIFZ, dataTable, i, str1, num54, num55, num58, num59, num60, num61, num41, num26, num39, num36, num56, num57, num3, this.productionUnitCode, this.notRawMt);
                                        }
                                        if (reportFormat == "excel")
                                        {
                                            num4++;
                                            this.GetDataExcelIfIGZ(dataHtmlIFZ, dataTable, i, str1, num54, num55, num58, num59, num60, num61, num41, num26, num39, num36, num56, num57, num3, this.productionUnitCode, sheet, headerStyle, workbook, num4);
                                        }
                                        num30 += num58;
                                        num29 += num59;
                                        num32 += num60;
                                        num31 += num61;
                                        this.hiddenPrantikJerQty.Value = "";
                                        this.hiddenPrantikJerValue.Value = "";
                                        num34 += num41;
                                        num33 += num26;
                                        this.hiddenPrantikJerQty.Value = num56.ToString();
                                        this.hiddenPrantikJerValue.Value = num57.ToString();
                                        this.lblReportView.Text = dataHtmlIFZ;
                                        earlyAvailableStockForSale1 = num42;
                                        num21 = num43;
                                        num28 = num56;
                                        num27 = num57;
                                    }
                                }
                                else if (i <= 0)
                                {
                                    decimal num62 = new decimal(0);
                                    decimal num63 = new decimal(0);
                                    decimal num64 = new decimal(0);
                                    earlyAvailableStockForSale1 = this.objAccountingBook.GetEarlyAvailableStockForSale(str, num);
                                    if (earlyAvailableStockForSale1 != new decimal(0))
                                    {
                                        num64 = earlyAvailableStockForSale1;
                                        num21 = Convert.ToDecimal(earlyAvailableStockForSale1) * num1;
                                        str1 = dataTable.Rows[i]["challan_date"].ToString();
                                    }
                                    else if (openingBalanceStock.Rows.Count > 0)
                                    {
                                        num62 = Convert.ToDecimal(openingBalanceStock.Rows[0]["item_qty"]);
                                        num63 = Convert.ToDecimal(openingBalanceStock.Rows[0]["item_value"]);
                                        str1 = openingBalanceStock.Rows[0]["opening_balance_date"].ToString();
                                        num64 = num62;
                                        num21 = num63;
                                    }
                                    str2 = dataTable.Rows[i]["status"].ToString();
                                    if (str2 == "P")
                                    {
                                        num17 = Convert.ToInt32(dataTable.Rows[i]["quantity"]);
                                        num23 = Convert.ToInt32(dataTable.Rows[i]["unit_price"]);
                                        num19 = new decimal(0);
                                        num41 = new decimal(0);
                                        num26 = new decimal(0);
                                        num36 = new decimal(0);
                                        num39 = new decimal(0);
                                        num44 = new decimal(0);
                                        num22 = num17 * num23;
                                        num42 = earlyAvailableStockForSale1 + num17;
                                        num43 = num22 + num21;
                                        num38 = new decimal(0);
                                        num35 = new decimal(0);
                                    }
                                    num17 = new decimal(0);
                                    num23 = new decimal(0);
                                    num19 = Convert.ToInt32(dataTable.Rows[i]["quantity"]);
                                    num41 = num19;
                                    num44 = Convert.ToDecimal(dataTable.Rows[i]["unit_price"]);
                                    num25 = num19 * num44;
                                    num26 = num25;
                                    num22 = new decimal(0);
                                    num42 = (earlyAvailableStockForSale1 > new decimal(0) ? earlyAvailableStockForSale1 - num19 : num19 - earlyAvailableStockForSale1);
                                    num38 = Convert.ToInt32(dataTable.Rows[i]["sd"]);
                                    num39 = num38;
                                    num40 += num38;
                                    num35 = Convert.ToInt32(dataTable.Rows[i]["vat"]);
                                    num36 = num35;
                                    num37 += num35;
                                    num43 = (num21 > new decimal(0) ? num21 - num25 : num25 - num21);
                                    cSVXMLBLL.GetPrarombikJer(num, empty);
                                    decimal num65 = new decimal(0);
                                    decimal num66 = new decimal(0);
                                    decimal num67 = new decimal(0);
                                    decimal num68 = new decimal(0);
                                    decimal num69 = new decimal(0);
                                    decimal num70 = new decimal(0);
                                    decimal num71 = new decimal(0);
                                    decimal num72 = new decimal(0);
                                    num65 = num64;
                                    num66 = num21;
                                    if (num65 != new decimal(0))
                                    {
                                        if (reportFormat == "html")
                                        {
                                            dataHtmlIFZ = this.GetDataHtmlIFZ(dataHtmlIFZ, str1, num65, num66, this.productionUnitCode, num3, this.notRawMt);
                                        }
                                        if (reportFormat == "excel")
                                        {
                                            this.GetDataExcelIFZ(dataHtmlIFZ, i, str1, num65, num66, this.productionUnitCode, num3, sheet, headerStyle, workbook, num4);
                                        }
                                    }
                                    if (dataTable.Rows[i]["item_type"].ToString() != "S" && (dataTable.Rows[i]["status"].ToString() == "S" || dataTable.Rows[i]["status"].ToString() == "G"))
                                    {
                                        num67 = (num65 + Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"])) - Convert.ToDecimal(num41);
                                        num68 = (num66 + Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"])) - Convert.ToDecimal(num26);
                                    }
                                    else if (dataTable.Rows[i]["item_type"].ToString() != "S" && dataTable.Rows[i]["status"].ToString() == "S")
                                    {
                                        num67 = (num65 + Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"])) - Convert.ToDecimal(num41);
                                    }
                                    else if (dataTable.Rows[i]["product_type"].ToString() == "F" && dataTable.Rows[i]["status"].ToString() == "G")
                                    {
                                        num67 = Convert.ToDecimal(num41);
                                        num68 = Convert.ToDecimal(dataTable.Rows[i]["unit_price"]);
                                    }
                                    if (dataTable.Rows[i]["status"].ToString() == "S")
                                    {
                                        num68 = (dataTable.Rows[i]["challan_type"].ToString() != "O" ? (num66 + Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"])) - Convert.ToDecimal(num26) : (num66 + Convert.ToDecimal(dataTable.Rows[i]["unit_price"])) - Convert.ToDecimal(num26));
                                    }
                                    num69 = Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"].ToString());
                                    num70 = (dataTable.Rows[i]["challan_type"].ToString() != "O" ? Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]) : Convert.ToDecimal(dataTable.Rows[i]["unit_price"]));
                                    num71 = num65 + num69;
                                    num72 = num66 + num70;
                                    if (reportFormat == "html")
                                    {
                                        dataHtmlIFZ = this.GetDataHtmlIfIGZ(dataHtmlIFZ, dataTable, i, str1, num65, num66, num69, num70, num71, num72, num41, num26, num39, num36, num67, num68, num3, this.productionUnitCode, this.notRawMt);
                                    }
                                    if (reportFormat == "excel")
                                    {
                                        num4 = num4 + i + 1;
                                        this.GetDataExcelIfIGZ(dataHtmlIFZ, dataTable, i, str1, num65, num66, num69, num70, num71, num72, num41, num26, num39, num36, num67, num68, num3, this.productionUnitCode, sheet, headerStyle, workbook, num4);
                                    }
                                    num30 += num69;
                                    num29 += Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]);
                                    num32 += num71;
                                    num31 += num72;
                                    num34 += num41;
                                    num33 += num26;
                                    this.hiddenPrantikJerQty.Value = num67.ToString();
                                    this.hiddenPrantikJerValue.Value = num68.ToString();
                                    num28 = num67;
                                    num27 = num68;
                                    this.lblReportView.Text = dataHtmlIFZ;
                                    earlyAvailableStockForSale1 = num42;
                                    num21 = num43;
                                }
                                else
                                {
                                    decimal num73 = new decimal(0);
                                    decimal num74 = new decimal(0);
                                    decimal num75 = new decimal(0);
                                    decimal num76 = new decimal(0);
                                    decimal num77 = new decimal(0);
                                    decimal num78 = new decimal(0);
                                    decimal num79 = new decimal(0);
                                    decimal num80 = new decimal(0);
                                    str2 = dataTable.Rows[i]["status"].ToString();
                                    if (str2 == "P")
                                    {
                                        num17 = Convert.ToInt32(dataTable.Rows[i]["quantity"]);
                                        num23 = Convert.ToInt32(dataTable.Rows[i]["unit_price"]);
                                        num19 = new decimal(0);
                                        num41 = new decimal(0);
                                        num26 = new decimal(0);
                                        num36 = new decimal(0);
                                        num39 = new decimal(0);
                                        num44 = new decimal(0);
                                        num22 = num17 * num23;
                                        num42 = earlyAvailableStockForSale1 + num17;
                                        num43 = num22 + num21;
                                        num38 = new decimal(0);
                                        num35 = new decimal(0);
                                    }
                                    num17 = new decimal(0);
                                    num23 = new decimal(0);
                                    num19 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                    num41 = num19;
                                    num44 = Convert.ToDecimal(dataTable.Rows[i]["unit_price"]);
                                    num25 = num19 * num44;
                                    num26 = num25;
                                    num22 = new decimal(0);
                                    num42 = (earlyAvailableStockForSale1 > new decimal(0) ? earlyAvailableStockForSale1 - num19 : num19 - earlyAvailableStockForSale1);
                                    num38 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                    num39 = num38;
                                    num40 += num38;
                                    num35 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                    num36 = num35;
                                    num37 += num35;
                                    num43 = (num21 > new decimal(0) ? num21 - num25 : num25 - num21);
                                    DataTable prarombikJer1 = cSVXMLBLL.GetPrarombikJer(num, empty);
                                    cSVXMLBLL.GetPrarombikJer(num, empty);
                                    if (prarombikJer1.Rows.Count > 0)
                                    {
                                        num73 = Convert.ToDecimal(this.hiddenPrantikJerQty.Value);
                                        num74 = Convert.ToDecimal(this.hiddenPrantikJerValue.Value);
                                        if (dataTable.Rows[i]["item_type"].ToString() != "S" && (dataTable.Rows[i]["status"].ToString() == "S" || dataTable.Rows[i]["status"].ToString() == "G"))
                                        {
                                            num75 = (num73 + Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"])) - Convert.ToDecimal(num41);
                                            num76 = (num74 + Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"])) - Convert.ToDecimal(num26);
                                        }
                                        else if (!(dataTable.Rows[i]["product_type"].ToString() == "F") || !(dataTable.Rows[i]["status"].ToString() == "G"))
                                        {
                                            num76 = (num74 + Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"])) - Convert.ToDecimal(num26);
                                        }
                                        else
                                        {
                                            num75 = Convert.ToDecimal(num41);
                                            num76 = Convert.ToDecimal(dataTable.Rows[i]["unit_price"]);
                                        }
                                    }
                                    num18 = num20 + num17;
                                    string.Concat(dataTable.Rows[i]["party_name"].ToString(), ", ", dataTable.Rows[i]["party_bin"].ToString());
                                    str1 = dataTable.Rows[i]["challan_date"].ToString();
                                    if (this.hiddenPrantikJerQty.Value != "")
                                    {
                                        num73 = Convert.ToDecimal(this.hiddenPrantikJerQty.Value);
                                    }
                                    if (this.hiddenPrantikJerValue.Value != "")
                                    {
                                        num74 = Convert.ToDecimal(this.hiddenPrantikJerValue.Value);
                                    }
                                    num77 = Convert.ToDecimal(dataTable.Rows[i]["utpadon_poriman"].ToString());
                                    num78 = Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]);
                                    num79 = Convert.ToDecimal(num73) + Convert.ToDecimal(num77);
                                    num80 = num74 + Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]);
                                    if (reportFormat == "html")
                                    {
                                        dataHtmlIFZ = this.GetDataHtmlIfIGZ(dataHtmlIFZ, dataTable, i, str1, num73, num74, num77, num78, num79, num80, num41, num26, num39, num36, num75, num76, num3, this.productionUnitCode, this.notRawMt);
                                    }
                                    if (reportFormat == "excel")
                                    {
                                        num4++;
                                        this.GetDataExcelIfIGZ(dataHtmlIFZ, dataTable, i, str1, num73, num74, num77, num78, num79, num80, num41, num26, num39, num36, num75, num76, num3, this.productionUnitCode, sheet, headerStyle, workbook, num4);
                                    }
                                    num30 += num77;
                                    num29 += Convert.ToDecimal(dataTable.Rows[i]["kor_batito_mullo"]);
                                    num32 += num79;
                                    num31 += num80;
                                    this.hiddenPrantikJerQty.Value = "";
                                    this.hiddenPrantikJerValue.Value = "";
                                    num34 += num41;
                                    num33 += num26;
                                    this.hiddenPrantikJerQty.Value = num75.ToString();
                                    this.hiddenPrantikJerValue.Value = num76.ToString();
                                    this.lblReportView.Text = dataHtmlIFZ;
                                    earlyAvailableStockForSale1 = num42;
                                    num21 = num43;
                                    num28 = num75;
                                    num27 = num76;
                                }
                            }
                        }
                        if (reportFormat == "html")
                        {
                            dataHtmlIFZ = this.GetTotalHtml(dataHtmlIFZ, num30, num29, num32, num31, num34, num33, num40, num37, num28, num27, num3);
                        }
                        if (reportFormat == "excel")
                        {
                            num4++;
                            this.GetTotalExcel(dataHtmlIFZ, num30, num29, num32, num31, num34, num33, num40, num37, num28, num27, num3, sheet, headerStyle, workbook, num4);
                        }
                        this.lblReportView.Text = dataHtmlIFZ;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Purchase17_drpProductType.SelectedValue != "C")
                {
                    this.notRawMt = true;
                }
                this.ReportGenerate("html", null, null, null, 0);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}