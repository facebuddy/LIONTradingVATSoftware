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
    public partial class PurchaseAccountSixOneMushak : Page, IRequiresSessionState   
    {
       
        private trnsPurchaseMasterBLL objPMBLL = new trnsPurchaseMasterBLL();

        private AccountingBookBLL objProPrice = new AccountingBookBLL();

        private ExcelUtility excelUtility = new ExcelUtility();

        private bool notRawMt;

    

        public PurchaseAccountSixOneMushak()
        {
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string str = "Purchse_account_Book_Form16_N";
            HSSFWorkbook hSSFWorkbook = new HSSFWorkbook();
            ISheet sheet = hSSFWorkbook.CreateSheet(str);
            HSSFCellStyle hSSFCellStyle = this.excelUtility.headerBorderStyle(hSSFWorkbook);
            this.GenerateHeader(hSSFWorkbook, sheet, hSSFCellStyle);
            this.showReport("excel", sheet, hSSFCellStyle, hSSFWorkbook);
            this.excelUtility.downloadExcel(hSSFWorkbook, sheet, base.Response, str);
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Purchase16_drpProductType.SelectedValue != "R")
                {
                    this.notRawMt = true;
                }
                this.showReport("html", null, null, null);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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
            IRow rows3 = sheet.CreateRow(6);
            IRow rows4 = sheet.CreateRow(7);
            this.excelUtility.CreateCell(rows, 0, "পণ্য/ সেবার উপকরণ ক্রয়", headerStyle);
            this.excelUtility.CreateCell(rows1, 0, "ক্রমিক সংখ্যা", headerStyle);
            this.excelUtility.CreateCell(rows1, 1, "তারিখ", headerStyle);
            this.excelUtility.CreateCell(rows1, 2, "মজুদ উপকরণের প্রারম্ভিক জের", headerStyle);
            this.excelUtility.CreateCell(rows1, 4, "ক্রয়কৃত উপকরণ", headerStyle);
            this.excelUtility.CreateCell(rows1, 18, "উপকরণের প্রান্তিক জের", headerStyle);
            this.excelUtility.CreateCell(rows1, 20, "মন্তব্য", headerStyle);
            this.excelUtility.CreateCell(rows2, 2, "পরিমাণ (একক)", headerStyle);
            this.excelUtility.CreateCell(rows2, 3, "মূল্য (সকল প্রকার কর ব্যতীত)", headerStyle);
            this.excelUtility.CreateCell(rows2, 4, "চালানপত্র / বিল অব এন্ট্রি নম্বর", headerStyle);
            this.excelUtility.CreateCell(rows2, 5, "তারিখ", headerStyle);
            this.excelUtility.CreateCell(rows2, 6, "বিক্রেতা/সরবরাহকারী", headerStyle);
            this.excelUtility.CreateCell(rows2, 9, "বিবরণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 10, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 11, "মূল্য (সকল প্রকার কর ব্যতীত)", headerStyle);
            this.excelUtility.CreateCell(rows2, 12, "সম্পূরক শুল্ক (যদি থাকে)", headerStyle);
            this.excelUtility.CreateCell(rows2, 13, "মূসক", headerStyle);
            this.excelUtility.CreateCell(rows2, 14, "মোট উপকরণের পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 16, "পণ্য প্রস্তুতকরণ / উৎপাদনে ব্যবহার", headerStyle);
            this.excelUtility.CreateCell(rows2, 18, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows2, 19, "মূল্য (সকল প্রকার কর ব্যতীত)", headerStyle);
            this.excelUtility.CreateCell(rows3, 6, "নাম", headerStyle);
            this.excelUtility.CreateCell(rows3, 7, "ঠিকানা", headerStyle);
            this.excelUtility.CreateCell(rows3, 8, "নিবন্ধন /তালিকাভুক্তি/ জাতীয় পরিচয়পত্র নং", headerStyle);
            this.excelUtility.CreateCell(rows3, 14, "পরিমাণ", headerStyle);
            this.excelUtility.CreateCell(rows3, 15, "মূল্য", headerStyle);
            this.excelUtility.CreateCell(rows3, 16, "পরিমাণ (একক)", headerStyle);
            this.excelUtility.CreateCell(rows3, 17, "মূল্য (সকল প্রকার কর ব্যতীত)", headerStyle);
            for (int i = 0; i <= 20; i++)
            {
                int num = i + 1;
                this.excelUtility.CreateCell(rows4, i, string.Concat("(", num, ")"), headerStyle);
            }
            this.excelUtility.MergeCell(workbook, sheet, 0, 1, 0, 20);
            this.excelUtility.MergeCell(workbook, sheet, 2, 6, 0, 0);
            this.excelUtility.MergeCell(workbook, sheet, 2, 6, 1, 1);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 2, 3);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 4, 17);
            this.excelUtility.MergeCell(workbook, sheet, 2, 3, 18, 19);
            this.excelUtility.MergeCell(workbook, sheet, 2, 6, 20, 20);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 2, 2);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 3, 3);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 4, 4);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 5, 5);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 9, 9);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 10, 10);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 11, 11);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 12, 12);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 13, 13);
            this.excelUtility.MergeCell(workbook, sheet, 4, 5, 6, 8);
            this.excelUtility.MergeCell(workbook, sheet, 4, 5, 14, 15);
            this.excelUtility.MergeCell(workbook, sheet, 4, 5, 16, 17);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 18, 18);
            this.excelUtility.MergeCell(workbook, sheet, 4, 6, 19, 19);
        }

        private void GetDataExcel(string displayHtml, DataTable dt, int i, string SEarly_quantity, string unitCodeOp, decimal early_Price, int precision, string currentDate, string pQuantity, string unitAll, string pPrice, string pSD, string pVAT, string Ssurplus_quantity, decimal surplus_price, string Ssurplus_Proquantity, string proQuantity, decimal totalProPrice, decimal surplus_proprice, ISheet sheet, HSSFCellStyle headerStyle, int rowIndex)
        {
            object item;
            object obj;
            object item1;
            IRow rows = sheet.CreateRow(rowIndex);
            this.excelUtility.CreateCell(rows, 0, string.Concat(i + 1), headerStyle);
            ExcelUtility excelUtility = this.excelUtility;
            IRow rows1 = rows;
            DateTime dateTime = Convert.ToDateTime(dt.Rows[i]["challan_date"]);
            excelUtility.CreateCell(rows1, 1, dateTime.ToString("dd/MM/yyyy") ?? "", headerStyle);
            if (SEarly_quantity != "0")
            {
                ExcelUtility excelUtility1 = this.excelUtility;
                object[] sEarlyQuantity = new object[] { SEarly_quantity, " ", '(', unitCodeOp, ')' };
                excelUtility1.CreateCell(rows, 2, string.Concat(sEarlyQuantity), headerStyle);
            }
            else
            {
                this.excelUtility.CreateCell(rows, 2, "--", headerStyle);
            }
            this.excelUtility.CreateCell(rows, 3, Utilities.RoundUpToWithString(early_Price, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 4, string.Concat(dt.Rows[i]["challan_no"]), headerStyle);
            this.excelUtility.CreateCell(rows, 5, currentDate ?? "", headerStyle);
            ExcelUtility excelUtility2 = this.excelUtility;
            IRow rows2 = rows;
            if (!string.IsNullOrEmpty(dt.Rows[i]["party_name"].ToString()))
            {
                item = dt.Rows[i]["party_name"];
            }
            else
            {
                item = "NA";
            }
            excelUtility2.CreateCell(rows2, 6, string.Concat(item), headerStyle);
            ExcelUtility excelUtility3 = this.excelUtility;
            IRow rows3 = rows;
            if (!string.IsNullOrEmpty(dt.Rows[i]["party_address"].ToString()))
            {
                obj = dt.Rows[i]["party_address"];
            }
            else
            {
                obj = "NA";
            }
            excelUtility3.CreateCell(rows3, 7, string.Concat(obj), headerStyle);
            ExcelUtility excelUtility4 = this.excelUtility;
            IRow rows4 = rows;
            if (!string.IsNullOrEmpty(dt.Rows[i]["party_bin"].ToString()))
            {
                item1 = dt.Rows[i]["party_bin"];
            }
            else
            {
                item1 = "NA";
            }
            excelUtility4.CreateCell(rows4, 8, string.Concat(item1), headerStyle);
            this.excelUtility.CreateCell(rows, 9, string.Concat(dt.Rows[i]["item_name"]), headerStyle);
            if (pQuantity != "0")
            {
                ExcelUtility excelUtility5 = this.excelUtility;
                object[] objArray = new object[] { pQuantity, '(', unitAll, ')' };
                excelUtility5.CreateCell(rows, 10, string.Concat(objArray), headerStyle);
            }
            else
            {
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                this.excelUtility.CreateCell(rows, 10, "--", headerStyle);
            }
            this.excelUtility.CreateCell(rows, 11, pPrice ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 12, pSD ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 13, pVAT ?? "", headerStyle);
            ExcelUtility excelUtility6 = this.excelUtility;
            object[] ssurplusQuantity = new object[] { Ssurplus_quantity, '(', unitAll, ')' };
            excelUtility6.CreateCell(rows, 14, string.Concat(ssurplusQuantity), headerStyle);
            this.excelUtility.CreateCell(rows, 15, Utilities.RoundUpToWithString(surplus_price, precision) ?? "", headerStyle);
            ExcelUtility excelUtility7 = this.excelUtility;
            object[] objArray1 = new object[] { proQuantity, '(', unitAll, ')' };
            excelUtility7.CreateCell(rows, 16, string.Concat(objArray1), headerStyle);
            this.excelUtility.CreateCell(rows, 17, Utilities.RoundUpToWithString(totalProPrice, precision) ?? "", headerStyle);
            ExcelUtility excelUtility8 = this.excelUtility;
            object[] ssurplusProquantity = new object[] { Ssurplus_Proquantity, '(', unitAll, ')' };
            excelUtility8.CreateCell(rows, 18, string.Concat(ssurplusProquantity), headerStyle);
            this.excelUtility.CreateCell(rows, 19, Utilities.RoundUpToWithString(surplus_proprice, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 20, string.Concat(dt.Rows[i]["remarks"]), headerStyle);
        }

        private void GetDataExcelIfIZ(string displayHtml, int i, string opbld, string SEarly_quantity, string unitCodeOp, decimal early_Price, int precision, string unitAll, ISheet sheet, HSSFCellStyle headerStyle)
        {
            IRow rows = sheet.CreateRow(8);
            this.excelUtility.CreateCell(rows, 0, string.Concat(" ", i, " "), headerStyle);
            this.excelUtility.CreateCell(rows, 1, opbld, headerStyle);
            ExcelUtility excelUtility = this.excelUtility;
            object[] sEarlyQuantity = new object[] { SEarly_quantity, " ", '(', unitCodeOp, ')' };
            excelUtility.CreateCell(rows, 2, string.Concat(sEarlyQuantity), headerStyle);
            this.excelUtility.CreateCell(rows, 3, Utilities.RoundUpToWithString(early_Price, precision) ?? "", headerStyle);
            for (int num = 4; num <= 17; num++)
            {
                this.excelUtility.CreateCell(rows, num, "--", headerStyle);
            }
            ExcelUtility excelUtility1 = this.excelUtility;
            object[] objArray = new object[] { SEarly_quantity, '(', unitAll, ')' };
            excelUtility1.CreateCell(rows, 18, string.Concat(objArray), headerStyle);
            this.excelUtility.CreateCell(rows, 19, Utilities.RoundUpToWithString(early_Price, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 20, "--", headerStyle);
        }

        private string GetDataHtml(string displayHtml, DataTable dt, int i, string SEarly_quantity, string unitCodeOp, decimal early_Price, int precision, string currentDate, string pQuantity, string unitAll, string pPrice, string pSD, string pVAT, string Ssurplus_quantity, decimal surplus_price, string Ssurplus_Proquantity, string proQuantity, decimal totalProPrice, decimal surplus_proprice, bool design)
        {
            if (design)
            {
                displayHtml = string.Concat(displayHtml, "<tr>");
                object obj = displayHtml;
                object[] objArray = new object[] { obj, "<td style='text-align: center;'>", i + 1, "</td>" };
                displayHtml = string.Concat(objArray);
                DateTime dateTime = Convert.ToDateTime(dt.Rows[i]["challan_date"]);
                displayHtml = string.Concat(displayHtml, "<td>", dateTime.ToString("dd/MM/yyyy"), "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                object obj1 = displayHtml;
                object[] item = new object[] { obj1, "<td>", dt.Rows[i]["challan_no"], "</td>" };
                displayHtml = string.Concat(item);
                displayHtml = string.Concat(displayHtml, "<td>", currentDate, "</td>");
                object obj2 = displayHtml;
                object[] item1 = new object[] { obj2, "<td style='text-align: left;'>", dt.Rows[i]["party_name"], "</td>" };
                displayHtml = string.Concat(item1);
                object obj3 = displayHtml;
                object[] objArray1 = new object[] { obj3, "<td style='text-align: left;'>", dt.Rows[i]["party_address"], "</td>" };
                displayHtml = string.Concat(objArray1);
                object obj4 = displayHtml;
                object[] item2 = new object[] { obj4, "<td style='text-align: left;'>", dt.Rows[i]["party_bin"], "</td>" };
                displayHtml = string.Concat(item2);
                object obj5 = displayHtml;
                object[] objArray2 = new object[] { obj5, "<td style='text-align: left;'>", dt.Rows[i]["item_name"], "</td>" };
                displayHtml = string.Concat(objArray2);
                if (pQuantity != "0")
                {
                    object obj6 = displayHtml;
                    object[] objArray3 = new object[] { obj6, "<td style='text-align: right;'>", pQuantity, '(', unitAll, ')', "</td>" };
                    displayHtml = string.Concat(objArray3);
                }
                else
                {
                    displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                }
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", pPrice, "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", pSD, "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", pVAT, "</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
                object obj7 = displayHtml;
                object[] item3 = new object[] { obj7, "<td>", dt.Rows[i]["remarks"], "</td>" };
                displayHtml = string.Concat(item3);
                displayHtml = string.Concat(displayHtml, "</tr>");
                return displayHtml;
            }
            displayHtml = string.Concat(displayHtml, "<tr>");
            object obj8 = displayHtml;
            object[] objArray4 = new object[] { obj8, "<td style='text-align: center;'>", i + 1, "</td>" };
            displayHtml = string.Concat(objArray4);
            DateTime dateTime1 = Convert.ToDateTime(dt.Rows[i]["challan_date"]);
            displayHtml = string.Concat(displayHtml, "<td>", dateTime1.ToString("dd/MM/yyyy"), "</td>");
            if (SEarly_quantity != "0")
            {
                object obj9 = displayHtml;
                object[] sEarlyQuantity = new object[] { obj9, "<td style='text-align: right;'>", SEarly_quantity, " ", '(', unitCodeOp, ')', " </td>" };
                displayHtml = string.Concat(sEarlyQuantity);
            }
            else
            {
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
            }
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(early_Price, precision), "</td>");
            object obj10 = displayHtml;
            object[] item4 = new object[] { obj10, "<td>", dt.Rows[i]["challan_no"], "</td>" };
            displayHtml = string.Concat(item4);
            displayHtml = string.Concat(displayHtml, "<td>", currentDate, "</td>");
            object obj11 = displayHtml;
            object[] item5 = new object[] { obj11, "<td style='text-align: left;'>", dt.Rows[i]["party_name"], "</td>" };
            displayHtml = string.Concat(item5);
            object obj12 = displayHtml;
            object[] objArray5 = new object[] { obj12, "<td style='text-align: left;'>", dt.Rows[i]["party_address"], "</td>" };
            displayHtml = string.Concat(objArray5);
            object obj13 = displayHtml;
            object[] item6 = new object[] { obj13, "<td style='text-align: left;'>", dt.Rows[i]["party_bin"], "</td>" };
            displayHtml = string.Concat(item6);
            object obj14 = displayHtml;
            object[] objArray6 = new object[] { obj14, "<td style='text-align: left;'>", dt.Rows[i]["item_name"], "</td>" };
            displayHtml = string.Concat(objArray6);
            if (pQuantity != "0")
            {
                object obj15 = displayHtml;
                object[] objArray7 = new object[] { obj15, "<td style='text-align: right;'>", pQuantity, '(', unitAll, ')', "</td>" };
                displayHtml = string.Concat(objArray7);
            }
            else
            {
                displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>-- </td>");
            }
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", pPrice, "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", pSD, "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", pVAT, "</td>");
            object obj16 = displayHtml;
            object[] ssurplusQuantity = new object[] { obj16, "<td style='text-align: right;'>", Ssurplus_quantity, '(', unitAll, ')', "</td>" };
            displayHtml = string.Concat(ssurplusQuantity);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(surplus_price, precision), "</td>");
            object obj17 = displayHtml;
            object[] objArray8 = new object[] { obj17, "<td style='text-align: right;'>", proQuantity, '(', unitAll, ')', "</td>" };
            displayHtml = string.Concat(objArray8);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", totalProPrice.ToString("N2"), "</td>");
            object obj18 = displayHtml;
            object[] ssurplusProquantity = new object[] { obj18, "<td style='text-align: right;'>", Ssurplus_Proquantity, '(', unitAll, ')', "</td>" };
            displayHtml = string.Concat(ssurplusProquantity);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(surplus_proprice, precision), "</td>");
            object obj19 = displayHtml;
            object[] item7 = new object[] { obj19, "<td>", dt.Rows[i]["remarks"], "</td>" };
            displayHtml = string.Concat(item7);
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private string GetDataHtmlIfIZ(string displayHtml, string opbld, string SEarly_quantity, string unitCodeOp, decimal early_Price, int precision, string unitAll, bool design)
        {
            if (design)
            {
                return null;
            }
            displayHtml = string.Concat(displayHtml, "<tr>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: center;'> 0 </td>");
            displayHtml = string.Concat(displayHtml, "<td>", opbld, "</td>");
            object obj = displayHtml;
            object[] sEarlyQuantity = new object[] { obj, "<td style='text-align: right;'>", SEarly_quantity, '(', unitCodeOp, ')', "</td>" };
            displayHtml = string.Concat(sEarlyQuantity);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(early_Price, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td>--</td>");
            displayHtml = string.Concat(displayHtml, "<td>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--<td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: left;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'> --  </td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            object obj1 = displayHtml;
            object[] objArray = new object[] { obj1, "<td style='text-align: right;'>", SEarly_quantity, '(', unitAll, ')', "</td>" };
            displayHtml = string.Concat(objArray);
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(early_Price, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;'>--</td>");
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private void GetTotalExcel(string displayHtml, int rowIndex, decimal TotalPurchasePrice, decimal TotalPurchaseSD, decimal TotalPurchaseVAT, int precision, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            IRow rows = sheet.CreateRow(rowIndex);
            this.excelUtility.CreateCell(rows, 0, "মোট", headerStyle);
            this.excelUtility.CreateCell(rows, 11, Utilities.RoundUpToWithString(TotalPurchasePrice, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 12, Utilities.RoundUpToWithString(TotalPurchaseSD, precision) ?? "", headerStyle);
            this.excelUtility.CreateCell(rows, 13, Utilities.RoundUpToWithString(TotalPurchaseVAT, precision) ?? "", headerStyle);
            this.excelUtility.MergeCell(workbook, sheet, rowIndex, rowIndex, 0, 10);
            this.excelUtility.MergeCell(workbook, sheet, rowIndex, rowIndex, 14, 20);
        }

        private string GetTotalHtml(string displayHtml, decimal TotalPurchasePrice, decimal TotalPurchaseSD, decimal TotalPurchaseVAT, int precision)
        {
            displayHtml = string.Concat(displayHtml, "<tr>");
            displayHtml = string.Concat(displayHtml, "<td colspan='11' style='text-align: right;padding:5px; font-weight:bold;'>মোট :</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(TotalPurchasePrice, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(TotalPurchaseSD, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(TotalPurchaseVAT, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: center;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: center;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: center;'></td>");
            displayHtml = string.Concat(displayHtml, "<td style='text-align: center;'></td>");
            displayHtml = string.Concat(displayHtml, "<td></td>");
            displayHtml = string.Concat(displayHtml, "<td></td>");
            displayHtml = string.Concat(displayHtml, "<td></td>");
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private void Load_product()
        {
            string selectedValue = "";
            AddItemBLL addItemBLL = new AddItemBLL();
            if (this.Purchase16_drpProductType.SelectedValue != "")
            {
                selectedValue = this.Purchase16_drpProductType.SelectedValue;
            }
            DataTable allItemByProductType = addItemBLL.GetAllItemByProductType(selectedValue);
            this.ddlItem.DataSource = allItemByProductType;
            this.ddlItem.DataTextField = allItemByProductType.Columns["ITEM_NAME"].ToString();
            this.ddlItem.DataValueField = allItemByProductType.Columns["ITEM_ID"].ToString();
            this.ddlItem.DataBind();
            this.Session["ITEM_INFO"] = allItemByProductType;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                ListItem listItem = new ListItem("----Select----", "-99");
                this.ddlItem.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("Raw Material", "R");
                this.Purchase16_drpProductType.Items.Insert(0, listItem1);
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

        private void showReport()
        {
            DateTime dateTime;
            object obj;
            object[] item;
            DateTime dateTime1;
            object item1;
            object obj1;
            object item2;
            SaleBLL saleBLL = new SaleBLL();
            AccountingBookBLL accountingBookBLL = new AccountingBookBLL();
            DataTable dataTable = new DataTable();
            DataTable purchaseUnitId = new DataTable();
            DataTable productionUnitId = new DataTable();
            DataTable dataTable1 = new DataTable();
            DataTable earlyAvailableStockNew = new DataTable();
            DataTable dataTable2 = new DataTable();
            DataTable itemLotInfo = new DataTable();
            try
            {
                int num = Convert.ToInt32(this.ddlItem.SelectedValue);
                int num1 = 0;
                int num2 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                DateTime dateTime2 = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime3 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str = dateTime2.AddDays(-1).ToString("dd/MM/yyyy");
                DateTime dateTime4 = dateTime2.AddDays(-1);
                dateTime4.ToString("yyyy-MM-dd");
                dateTime4.ToString("dd/MM/yyyy");
                AddItemBLL addItemBLL = new AddItemBLL();
                decimal earlyTotalItem = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                int num6 = 0;
                int num7 = 0;
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                int num10 = 0;
                dataTable = this.objPMBLL.PurchaseAccountingBook(dateTime2, dateTime3, num, num1);
                string str1 = "";
                string str2 = "";
                string str3 = "";
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                string str4 = "";
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                string str5 = "#.##";
                decimal num16 = new decimal(0);
                string withString = "";
                string withString1 = "";
                decimal num17 = new decimal(0);
                string str6 = "";
                decimal num18 = new decimal(0);
                string str7 = "";
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                decimal num21 = new decimal(0);
                decimal num22 = new decimal(0);
                string str8 = "#.##";
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
                string str9 = "";
                string str10 = "";
                string str11 = "0";
                string empty = string.Empty;
                purchaseUnitId = this.objPMBLL.GetPurchase_unitId(dateTime2, dateTime3, num, num1);
                itemLotInfo = this.objPMBLL.GetItemLotInfo(num);
                if (itemLotInfo.Rows.Count < 1)
                {
                    itemLotInfo = this.objPMBLL.GetItemlastLotInfo(num);
                }
                if (purchaseUnitId.Rows.Count > 0)
                {
                    num7 = Convert.ToInt16(purchaseUnitId.Rows[0]["unit_id"].ToString());
                    purchaseUnitId.Rows[0]["unit_code"].ToString();
                }
                DataTable unitByItemId = addItemBLL.getIUnitByItemId(num);
                if (unitByItemId.Rows.Count > 0)
                {
                    str1 = Convert.ToString(unitByItemId.Rows[0]["unit_code"]);
                }
                if (dataTable.Rows.Count <= 0)
                {
                    AddItemBLL addItemBLL1 = new AddItemBLL();
                    DataTable dataTable3 = new DataTable();
                    earlyAvailableStockNew = this.objPMBLL.GetEarlyAvailableStockNew(dateTime2, dateTime3, num);
                    DataTable earlyAvailableStockPrevDate = this.objPMBLL.GetEarlyAvailableStockPrevDate(dateTime2, dateTime3, num);
                    if (earlyAvailableStockNew.Rows.Count > 0)
                    {
                        earlyTotalItem = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_qty"]);
                        dateTime1 = Convert.ToDateTime(earlyAvailableStockNew.Rows[0]["opening_balance_date"]);
                        str2 = dateTime1.ToString("dd/MM/yyyy");
                        dateTime = DateTime.ParseExact(str2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        str = dateTime.ToString("dd/MM/yyyy");
                        num3 = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_value"]);
                        if (dateTime < dateTime2)
                        {
                            earlyTotalItem = (earlyTotalItem + this.objPMBLL.GetEarlyTotalItem(num, dateTime, dateTime2)) - this.objPMBLL.GetEarlytotalProdution(num, dateTime, dateTime2);
                        }
                    }
                    if (earlyAvailableStockPrevDate.Rows.Count > 0)
                    {
                        num4 = Convert.ToDecimal(earlyAvailableStockPrevDate.Rows[0]["prarombik_jer_poriman_3"]);
                        num5 = Convert.ToDecimal(earlyAvailableStockPrevDate.Rows[0]["prarombik_jer_mullo_4"]);
                    }
                    num11 = earlyTotalItem + num4;
                    num14 = num3 + num5;
                    str11 = Utilities.formatFraction(num11);
                    str3 = string.Concat(str3, "<tr>");
                    str3 = string.Concat(str3, "<td style='text-align: center;'> 1 </td>");
                    str3 = string.Concat(str3, "<td>", str, "</td>");
                    obj = str3;
                    item = new object[] { obj, "<td style='text-align: right;'>", str11, '(', str1, ')', "</td>" };
                    str3 = string.Concat(item);
                    str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num14, num2), "</td>");
                    str3 = string.Concat(str3, "<td>--</td>");
                    str3 = string.Concat(str3, "<td>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: left;'>--<td>");
                    str3 = string.Concat(str3, "<td style='text-align: left;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: left;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: left;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    obj = str3;
                    item = new object[] { obj, "<td style='text-align: right;'>", str11, '(', str1, ')', "</td>" };
                    str3 = string.Concat(item);
                    str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num14, num2), "</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                    str3 = string.Concat(str3, "</tr>");
                    this.lblPurchaseBookRow.Text = str3;
                }
                else
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        num10 = Convert.ToInt32(dataTable.Rows[i]["production_id"]);
                        empty = dataTable.Rows[0]["unit_code"].ToString();
                        productionUnitId = this.objPMBLL.GetProduction_unitId(dateTime2, dateTime3, num, num1, num10);
                        if (i <= 0)
                        {
                            earlyAvailableStockNew = this.objPMBLL.GetEarlyAvailableStockNew(dateTime2, dateTime3, num);
                            DataTable earlyAvailableStockPrevDate1 = this.objPMBLL.GetEarlyAvailableStockPrevDate(dateTime2, dateTime3, num);
                            if (earlyAvailableStockNew.Rows.Count > 0)
                            {
                                earlyTotalItem = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_qty"]);
                                dateTime1 = Convert.ToDateTime(earlyAvailableStockNew.Rows[0]["opening_balance_date"]);
                                str2 = dateTime1.ToString("dd/MM/yyyy");
                                dateTime = DateTime.ParseExact(str2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                str = dateTime.ToString("dd/MM/yyyy");
                                num3 = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_value"]);
                                if (dateTime < dateTime2)
                                {
                                    earlyTotalItem = (earlyTotalItem + this.objPMBLL.GetEarlyTotalItem(num, dateTime, dateTime2)) - this.objPMBLL.GetEarlytotalProdution(num, dateTime, dateTime2);
                                }
                            }
                            if (earlyAvailableStockPrevDate1.Rows.Count > 0)
                            {
                                num4 = Convert.ToDecimal(earlyAvailableStockPrevDate1.Rows[0]["prarombik_jer_poriman_3"]);
                                num5 = Convert.ToDecimal(earlyAvailableStockPrevDate1.Rows[0]["prarombik_jer_mullo_4"]);
                            }
                            num11 = earlyTotalItem + num4;
                            num14 = num3 + num5;
                            str11 = Utilities.formatFraction(num11);
                            str3 = string.Concat(str3, "<tr>");
                            str3 = string.Concat(str3, "<td style='text-align: center;'> 0 </td>");
                            str3 = string.Concat(str3, "<td>", str, "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str11, '(', str1, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num14, num2), "</td>");
                            str3 = string.Concat(str3, "<td>--</td>");
                            str3 = string.Concat(str3, "<td>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: left;'>--<td>");
                            str3 = string.Concat(str3, "<td style='text-align: left;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: left;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: left;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'> --  </td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str11, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num14, num2), "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>--</td>");
                            str3 = string.Concat(str3, "</tr>");
                            if (dataTable.Rows[i]["status"].ToString() == "P")
                            {
                                num15 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                str5 = Utilities.formatFraction(num15);
                                num27 = new decimal(0);
                                num22 = new decimal(0);
                                str8 = "--";
                                dataTable.Rows[i]["date"].ToString();
                                dataTable.Rows[i]["prdDate"].ToString();
                                num22 = Convert.ToDecimal(dataTable.Rows[i]["production_Qty"]);
                                num24 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num23 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                num26 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num25 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                Convert.ToInt16(dataTable.Rows[i]["unit_id"]);
                                if (productionUnitId.Rows.Count > 0)
                                {
                                    num6 = Convert.ToInt16(productionUnitId.Rows[0]["unit_id"].ToString());
                                    productionUnitId.Rows[0]["unit_code"].ToString();
                                }
                                DataTable value = addItemBLL.GetValue(num6, num7);
                                if (value.Rows.Count > 0)
                                {
                                    num8 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                                }
                                if (num8 > new decimal(0))
                                {
                                    num22 /= num8;
                                }
                                if (num8 == new decimal(0))
                                {
                                    DataTable valueSec = addItemBLL.GetValueSec(num6, num7);
                                    if (valueSec.Rows.Count > 0 && num9 > new decimal(0))
                                    {
                                        num9 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                                        num22 *= num8;
                                    }
                                }
                                num33 = (Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) != new decimal(0) ? Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) : accountingBookBLL.getTotalProPrice(itemLotInfo, num22));
                                str8 = Utilities.formatFraction(num22);
                                num16 = Convert.ToDecimal(dataTable.Rows[i]["price"]);
                                num19 += num16;
                                withString = Utilities.RoundUpToWithString(num16, num2);
                                num29 = (num24 != new decimal(0) || num26 != new decimal(0) ? num11 - (num24 + num26) : num11 + num15);
                                str9 = Utilities.formatFraction(num29);
                                num31 = (num24 != new decimal(0) || num26 != new decimal(0) ? num14 - (num23 + num25) : num16 + num14);
                                num30 = num29 - num22;
                                str10 = Utilities.formatFraction(num30);
                                num17 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                num20 += num17;
                                str6 = (num17 > new decimal(0) ? Utilities.RoundUpToWithString(num17, num2) : "--");
                                num18 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                num21 += num18;
                                str7 = (num18 > new decimal(0) ? Utilities.RoundUpToWithString(num18, num2) : "--");
                                withString1 = Utilities.RoundUpToWithString(num14, num2);
                                num32 = num31 - num33;
                            }
                            num12 = num11 + num15;
                            string.Concat(dataTable.Rows[i]["party_name"].ToString(), ", ", dataTable.Rows[i]["party_bin"].ToString());
                            str4 = dataTable.Rows[i]["date"].ToString();
                            str3 = string.Concat(str3, "<tr>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: center;'>", i + 1, "</td>" };
                            str3 = string.Concat(item);
                            dateTime1 = Convert.ToDateTime(dataTable.Rows[i]["challan_date"]);
                            str3 = string.Concat(str3, "<td>", dateTime1.ToString("dd/MM/yyyy"), "</td>");
                            if (str11 != "0")
                            {
                                obj = str3;
                                item = new object[] { obj, "<td style='text-align: right;'>", str11, " ", '(', str1, ')', " </td>" };
                                str3 = string.Concat(item);
                            }
                            else
                            {
                                str3 = string.Concat(str3, "<td style='text-align: right;'>-- </td>");
                            }
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", withString1, "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td>", dataTable.Rows[i]["challan_no"], "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td>", str4, "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", dataTable.Rows[i]["party_name"], "</td>" };
                            str3 = string.Concat(item);
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", dataTable.Rows[i]["party_address"], "</td>" };
                            str3 = string.Concat(item);
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", dataTable.Rows[i]["party_bin"], "</td>" };
                            str3 = string.Concat(item);
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", dataTable.Rows[i]["item_name"], "</td>" };
                            str3 = string.Concat(item);
                            if (str5 != "0")
                            {
                                obj = str3;
                                item = new object[] { obj, "<td style='text-align: right;'>", str5, '(', empty, ')', "</td>" };
                                str3 = string.Concat(item);
                            }
                            else
                            {
                                str3 = string.Concat(str3, "<td style='text-align: right;'>-- </td>");
                            }
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", withString, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", str7, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", str6, "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str9, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num31, num2), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str8, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", num33.ToString("N2"), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str10, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num32, num2), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td>", dataTable.Rows[i]["remarks"], "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "</tr>");
                            this.lblPurchaseBookRow.Text = str3;
                            num11 = Convert.ToDecimal(str10);
                            str11 = Utilities.formatFraction(num11);
                            num14 = num32;
                        }
                        else
                        {
                            if (dataTable.Rows[i]["status"].ToString() == "P")
                            {
                                num15 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                str5 = Utilities.formatFraction(num15);
                                num27 = new decimal(0);
                                num22 = new decimal(0);
                                str8 = "--";
                                dataTable.Rows[i]["date"].ToString();
                                dataTable.Rows[i]["prdDate"].ToString();
                                num22 = Convert.ToDecimal(dataTable.Rows[i]["production_Qty"]);
                                num24 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num23 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                num26 = Convert.ToDecimal(dataTable.Rows[i]["debit_quantity"]);
                                num25 = Convert.ToDecimal(dataTable.Rows[i]["debit_price"]);
                                Convert.ToInt32(dataTable.Rows[i]["unit_id"]);
                                if (productionUnitId.Rows.Count > 0)
                                {
                                    num6 = Convert.ToInt32(productionUnitId.Rows[0]["unit_id"].ToString());
                                    productionUnitId.Rows[0]["unit_code"].ToString();
                                }
                                num33 = (Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) != new decimal(0) ? Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) : accountingBookBLL.getTotalProPrice(itemLotInfo, num22));
                                str8 = Utilities.formatFraction(num22);
                                num16 = Convert.ToDecimal(dataTable.Rows[i]["price"]);
                                num19 += num16;
                                withString = Utilities.RoundUpToWithString(num16, num2);
                                num28.ToString("N2");
                                num29 = (num24 != new decimal(0) || num26 != new decimal(0) ? num11 - (num24 + num26) : num11 + num15);
                                num31 = (num24 != new decimal(0) || num26 != new decimal(0) ? num14 - (num23 + num25) : num16 + num14);
                                str9 = Utilities.formatFraction(num29);
                                num30 = num29 - num22;
                                str10 = Utilities.formatFraction(num30);
                                num17 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                num20 += num17;
                                str6 = (num17 > new decimal(0) ? Utilities.RoundUpToWithString(num17, num2) : "--");
                                num18 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                num21 += num18;
                                str7 = (num18 > new decimal(0) ? Utilities.RoundUpToWithString(num18, num2) : "--");
                                num32 = num31 - num33;
                            }
                            num12 = num13 + num15;
                            string.Concat(dataTable.Rows[i]["party_name"].ToString(), ", ", dataTable.Rows[i]["party_bin"].ToString());
                            str4 = dataTable.Rows[i]["date"].ToString();
                            str3 = string.Concat(str3, "<tr>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: center;'>", i + 1, "</td>" };
                            str3 = string.Concat(item);
                            dateTime1 = Convert.ToDateTime(dataTable.Rows[i]["challan_date"]);
                            str3 = string.Concat(str3, "<td>", dateTime1.ToString("dd/MM/yyyy"), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str11, " ", '(', str1, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num14, num2), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td>", dataTable.Rows[i]["challan_no"], "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td>", str4, "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", null, null };
                            object[] objArray = item;
                            if (!string.IsNullOrEmpty(dataTable.Rows[i]["party_name"].ToString()))
                            {
                                item1 = dataTable.Rows[i]["party_name"];
                            }
                            else
                            {
                                item1 = "NA";
                            }
                            objArray[2] = item1;
                            item[3] = "</td>";
                            str3 = string.Concat(item);
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", null, null };
                            object[] objArray1 = item;
                            if (!string.IsNullOrEmpty(dataTable.Rows[i]["party_address"].ToString()))
                            {
                                obj1 = dataTable.Rows[i]["party_address"];
                            }
                            else
                            {
                                obj1 = "NA";
                            }
                            objArray1[2] = obj1;
                            item[3] = "</td>";
                            str3 = string.Concat(item);
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", null, null };
                            object[] objArray2 = item;
                            if (!string.IsNullOrEmpty(dataTable.Rows[i]["party_bin"].ToString()))
                            {
                                item2 = dataTable.Rows[i]["party_bin"];
                            }
                            else
                            {
                                item2 = "NA";
                            }
                            objArray2[2] = item2;
                            item[3] = "</td>";
                            str3 = string.Concat(item);
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: left;'>", dataTable.Rows[i]["item_name"], "</td>" };
                            str3 = string.Concat(item);
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str5, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", withString, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", str7, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", str6, "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str9, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num31, num2), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str8, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num33, num2), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td style='text-align: right;'>", str10, '(', empty, ')', "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num32, num2), "</td>");
                            obj = str3;
                            item = new object[] { obj, "<td>", dataTable.Rows[i]["remarks"], "</td>" };
                            str3 = string.Concat(item);
                            str3 = string.Concat(str3, "</tr>");
                            this.lblPurchaseBookRow.Text = str3;
                            num11 = num30;
                            str11 = Utilities.formatFraction(num11);
                            num14 = num32;
                        }
                    }
                    str3 = string.Concat(str3, "<tr>");
                    str3 = string.Concat(str3, "<td colspan='11' style='text-align: right;padding:5px; font-weight:bold;'>মোট :</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(num19, num2), "</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(num21, num2), "</td>");
                    str3 = string.Concat(str3, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(num20, num2), "</td>");
                    str3 = string.Concat(str3, "<td style='text-align: center;'></td>");
                    str3 = string.Concat(str3, "<td style='text-align: center;'></td>");
                    str3 = string.Concat(str3, "<td style='text-align: center;'></td>");
                    str3 = string.Concat(str3, "<td style='text-align: center;'></td>");
                    str3 = string.Concat(str3, "<td></td>");
                    str3 = string.Concat(str3, "<td></td>");
                    str3 = string.Concat(str3, "<td></td>");
                    str3 = string.Concat(str3, "</tr>");
                    this.lblPurchaseBookRow.Text = str3;
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void showReport(string reportFormat, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            DateTime dateTime;
            DateTime dateTime1;
            SaleBLL saleBLL = new SaleBLL();
            AccountingBookBLL accountingBookBLL = new AccountingBookBLL();
            DataTable dataTable = new DataTable();
            DataTable purchaseUnitId = new DataTable();
            DataTable productionUnitId = new DataTable();
            DataTable dataTable1 = new DataTable();
            DataTable earlyAvailableStockNew = new DataTable();
            DataTable dataTable2 = new DataTable();
            DataTable itemLotInfo = new DataTable();
            try
            {
                int num = Convert.ToInt32(this.ddlItem.SelectedValue);
                int num1 = 0;
                int num2 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                AddItemBLL addItemBLL = new AddItemBLL();
                decimal earlyTotalItem = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                int num6 = 0;
                int num7 = 0;
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                int num10 = 0;
                string str = "";
                string str1 = "";
                string dataHtmlIfIZ = "";
                decimal num11 = new decimal(0);
                decimal num12 = new decimal(0);
                decimal num13 = new decimal(0);
                string str2 = "";
                decimal num14 = new decimal(0);
                decimal num15 = new decimal(0);
                string str3 = "#.##";
                decimal num16 = new decimal(0);
                string withString = "";
                decimal num17 = new decimal(0);
                string str4 = "";
                decimal num18 = new decimal(0);
                string str5 = "";
                decimal num19 = new decimal(0);
                decimal num20 = new decimal(0);
                decimal num21 = new decimal(0);
                decimal num22 = new decimal(0);
                string str6 = "#.##";
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
                string str7 = "";
                string str8 = "";
                string str9 = "0";
                string empty = string.Empty;
                int num34 = 8;
                DateTime dateTime2 = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime3 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str10 = dateTime2.AddDays(-1).ToString("dd/MM/yyyy");
                DateTime dateTime4 = dateTime2.AddDays(-1);
                dateTime4.ToString("yyyy-MM-dd");
                dateTime4.ToString("dd/MM/yyyy");
                dataTable = this.objPMBLL.PurchaseAccountingBook(dateTime2, dateTime3, num, num1);
                purchaseUnitId = this.objPMBLL.GetPurchase_unitId(dateTime2, dateTime3, num, num1);
                itemLotInfo = this.objPMBLL.GetItemLotInfo(num);
                if (itemLotInfo.Rows.Count < 1)
                {
                    itemLotInfo = this.objPMBLL.GetItemlastLotInfo(num);
                }
                if (purchaseUnitId.Rows.Count > 0)
                {
                    num7 = Convert.ToInt16(purchaseUnitId.Rows[0]["unit_id"].ToString());
                    purchaseUnitId.Rows[0]["unit_code"].ToString();
                }
                DataTable unitByItemId = addItemBLL.getIUnitByItemId(num);
                if (unitByItemId.Rows.Count > 0)
                {
                    str = Convert.ToString(unitByItemId.Rows[0]["unit_code"]);
                }
                if (dataTable.Rows.Count <= 0)
                {
                    AddItemBLL addItemBLL1 = new AddItemBLL();
                    DataTable dataTable3 = new DataTable();
                    earlyAvailableStockNew = this.objPMBLL.GetEarlyAvailableStockNew(dateTime2, dateTime3, num);
                    DataTable earlyAvailableStockPrevDate = this.objPMBLL.GetEarlyAvailableStockPrevDate(dateTime2, dateTime3, num);
                    if (earlyAvailableStockNew.Rows.Count > 0)
                    {
                        earlyTotalItem = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_qty"]);
                        dateTime1 = Convert.ToDateTime(earlyAvailableStockNew.Rows[0]["opening_balance_date"]);
                        str1 = dateTime1.ToString("dd/MM/yyyy");
                        dateTime = DateTime.ParseExact(str1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        str10 = dateTime.ToString("dd/MM/yyyy");
                        num3 = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_value"]);
                        if (dateTime < dateTime2)
                        {
                            earlyTotalItem = (earlyTotalItem + this.objPMBLL.GetEarlyTotalItem(num, dateTime, dateTime2)) - this.objPMBLL.GetEarlytotalProdution(num, dateTime, dateTime2);
                        }
                    }
                    if (earlyAvailableStockPrevDate.Rows.Count > 0)
                    {
                        num4 = Convert.ToDecimal(earlyAvailableStockPrevDate.Rows[0]["prarombik_jer_poriman_3"]);
                        num5 = Convert.ToDecimal(earlyAvailableStockPrevDate.Rows[0]["prarombik_jer_mullo_4"]);
                    }
                    num11 = earlyTotalItem + num4;
                    num14 = num3 + num5;
                    str9 = Utilities.formatFraction(num11);
                    empty = str;
                    if (reportFormat == "html")
                    {
                        dataHtmlIfIZ = this.GetDataHtmlIfIZ(dataHtmlIfIZ, str10, str9, str, num14, num2, empty, this.notRawMt);
                    }
                    if (reportFormat == "excel")
                    {
                        this.GetDataExcelIfIZ(dataHtmlIfIZ, 0, str10, str9, str, num14, num2, empty, sheet, headerStyle);
                    }
                    this.lblPurchaseBookRow.Text = dataHtmlIfIZ;
                }
                else
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        num10 = Convert.ToInt32(dataTable.Rows[i]["production_id"]);
                        empty = dataTable.Rows[0]["unit_code"].ToString();
                        productionUnitId = this.objPMBLL.GetProduction_unitId(dateTime2, dateTime3, num, num1, num10);
                        if (i <= 0)
                        {
                            earlyAvailableStockNew = this.objPMBLL.GetEarlyAvailableStockNew(dateTime2, dateTime3, num);
                            DataTable earlyAvailableStockPrevDate1 = this.objPMBLL.GetEarlyAvailableStockPrevDate(dateTime2, dateTime3, num);
                            if (earlyAvailableStockNew.Rows.Count > 0)
                            {
                                earlyTotalItem = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_qty"]);
                                dateTime1 = Convert.ToDateTime(earlyAvailableStockNew.Rows[0]["opening_balance_date"]);
                                str1 = dateTime1.ToString("dd/MM/yyyy");
                                dateTime = DateTime.ParseExact(str1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                str10 = dateTime.ToString("dd/MM/yyyy");
                                num3 = Convert.ToDecimal(earlyAvailableStockNew.Rows[0]["item_value"]);
                                if (dateTime < dateTime2)
                                {
                                    earlyTotalItem = (earlyTotalItem + this.objPMBLL.GetEarlyTotalItem(num, dateTime, dateTime2)) - this.objPMBLL.GetEarlytotalProdution(num, dateTime, dateTime2);
                                }
                            }
                            if (earlyAvailableStockPrevDate1.Rows.Count > 0)
                            {
                                num4 = Convert.ToDecimal(earlyAvailableStockPrevDate1.Rows[0]["prarombik_jer_poriman_3"]);
                                num5 = Convert.ToDecimal(earlyAvailableStockPrevDate1.Rows[0]["prarombik_jer_mullo_4"]);
                            }
                            num11 = earlyTotalItem + num4;
                            num14 = num3 + num5;
                            str9 = Utilities.formatFraction(num11);
                            if (reportFormat == "html")
                            {
                                dataHtmlIfIZ = this.GetDataHtmlIfIZ(dataHtmlIfIZ, str10, str9, str, num14, num2, empty, this.notRawMt);
                            }
                            if (reportFormat == "excel")
                            {
                                this.GetDataExcelIfIZ(dataHtmlIfIZ, i, str10, str9, str, num14, num2, empty, sheet, headerStyle);
                            }
                            if (dataTable.Rows[i]["status"].ToString() == "P")
                            {
                                num15 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                str3 = Utilities.formatFraction(num15);
                                num27 = new decimal(0);
                                num22 = new decimal(0);
                                str6 = "--";
                                dataTable.Rows[i]["date"].ToString();
                                dataTable.Rows[i]["prdDate"].ToString();
                                num22 = Convert.ToDecimal(dataTable.Rows[i]["production_Qty"]);
                                num24 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num23 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                num26 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num25 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                Convert.ToInt16(dataTable.Rows[i]["unit_id"]);
                                if (productionUnitId.Rows.Count > 0)
                                {
                                    num6 = Convert.ToInt16(productionUnitId.Rows[0]["unit_id"].ToString());
                                    productionUnitId.Rows[0]["unit_code"].ToString();
                                }
                                DataTable value = addItemBLL.GetValue(num6, num7);
                                if (value.Rows.Count > 0)
                                {
                                    num8 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                                }
                                if (num8 > new decimal(0))
                                {
                                    num22 /= num8;
                                }
                                if (num8 == new decimal(0))
                                {
                                    DataTable valueSec = addItemBLL.GetValueSec(num6, num7);
                                    if (valueSec.Rows.Count > 0 && num9 > new decimal(0))
                                    {
                                        num9 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                                        num22 *= num8;
                                    }
                                }
                                num33 = (Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) != new decimal(0) ? Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) : accountingBookBLL.getTotalProPrice(itemLotInfo, num22));
                                str6 = Utilities.formatFraction(num22);
                                num16 = Convert.ToDecimal(dataTable.Rows[i]["price"]);
                                num19 += num16;
                                withString = Utilities.RoundUpToWithString(num16, num2);
                                num29 = (num24 != new decimal(0) || num26 != new decimal(0) ? num11 - (num24 + num26) : num11 + num15);
                                str7 = Utilities.formatFraction(num29);
                                num31 = (num24 != new decimal(0) || num26 != new decimal(0) ? num14 - (num23 + num25) : num16 + num14);
                                num30 = num29 - num22;
                                str8 = Utilities.formatFraction(num30);
                                num17 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                num20 += num17;
                                str4 = (num17 > new decimal(0) ? Utilities.RoundUpToWithString(num17, num2) : "--");
                                num18 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                num21 += num18;
                                str5 = (num18 > new decimal(0) ? Utilities.RoundUpToWithString(num18, num2) : "--");
                                num32 = num31 - num33;
                            }
                            num12 = num11 + num15;
                            string.Concat(dataTable.Rows[i]["party_name"].ToString(), ", ", dataTable.Rows[i]["party_bin"].ToString());
                            str2 = dataTable.Rows[i]["date"].ToString();
                            if (reportFormat == "html")
                            {
                                dataHtmlIfIZ = this.GetDataHtml(dataHtmlIfIZ, dataTable, i, str9, str, num14, num2, str2, str3, empty, withString, str5, str4, str7, num31, str8, str6, num33, num32, this.notRawMt);
                            }
                            if (reportFormat == "excel")
                            {
                                num34 = num34 + i + 1;
                                this.GetDataExcel(dataHtmlIfIZ, dataTable, i, str9, str, num14, num2, str2, str3, empty, withString, str5, str4, str7, num31, str8, str6, num33, num32, sheet, headerStyle, num34);
                            }
                            this.lblPurchaseBookRow.Text = dataHtmlIfIZ;
                            num11 = Convert.ToDecimal(str8);
                            str9 = Utilities.formatFraction(num11);
                            num14 = num32;
                        }
                        else
                        {
                            if (dataTable.Rows[i]["status"].ToString() == "P")
                            {
                                num15 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                str3 = Utilities.formatFraction(num15);
                                num27 = new decimal(0);
                                num22 = new decimal(0);
                                str6 = "--";
                                dataTable.Rows[i]["date"].ToString();
                                dataTable.Rows[i]["prdDate"].ToString();
                                num22 = Convert.ToDecimal(dataTable.Rows[i]["production_Qty"]);
                                num24 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num23 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                num26 = Convert.ToDecimal(dataTable.Rows[i]["debit_quantity"]);
                                num25 = Convert.ToDecimal(dataTable.Rows[i]["debit_price"]);
                                Convert.ToInt32(dataTable.Rows[i]["unit_id"]);
                                if (productionUnitId.Rows.Count > 0)
                                {
                                    num6 = Convert.ToInt32(productionUnitId.Rows[0]["unit_id"].ToString());
                                    productionUnitId.Rows[0]["unit_code"].ToString();
                                }
                                num33 = (Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) != new decimal(0) ? Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]) : accountingBookBLL.getTotalProPrice(itemLotInfo, num22));
                                str6 = Utilities.formatFraction(num22);
                                num16 = Convert.ToDecimal(dataTable.Rows[i]["price"]);
                                num19 += num16;
                                withString = Utilities.RoundUpToWithString(num16, num2);
                                num28.ToString("N2");
                                num29 = (num24 != new decimal(0) || num26 != new decimal(0) ? num11 - (num24 + num26) : num11 + num15);
                                num31 = (num24 != new decimal(0) || num26 != new decimal(0) ? num14 - (num23 + num25) : num16 + num14);
                                str7 = Utilities.formatFraction(num29);
                                num30 = num29 - num22;
                                str8 = Utilities.formatFraction(num30);
                                num17 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                num20 += num17;
                                str4 = (num17 > new decimal(0) ? Utilities.RoundUpToWithString(num17, num2) : "--");
                                num18 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                num21 += num18;
                                str5 = (num18 > new decimal(0) ? Utilities.RoundUpToWithString(num18, num2) : "--");
                                num32 = num31 - num33;
                            }
                            num12 = num13 + num15;
                            string.Concat(dataTable.Rows[i]["party_name"].ToString(), ", ", dataTable.Rows[i]["party_bin"].ToString());
                            str2 = dataTable.Rows[i]["date"].ToString();
                            if (reportFormat == "html")
                            {
                                dataHtmlIfIZ = this.GetDataHtml(dataHtmlIfIZ, dataTable, i, str9, str, num14, num2, str2, str3, empty, withString, str5, str4, str7, num31, str8, str6, num33, num32, this.notRawMt);
                                this.lblPurchaseBookRow.Text = dataHtmlIfIZ;
                            }
                            if (reportFormat == "excel")
                            {
                                num34++;
                                this.GetDataExcel(dataHtmlIfIZ, dataTable, i, str9, str, num14, num2, str2, str3, empty, withString, str5, str4, str7, num31, str8, str6, num33, num32, sheet, headerStyle, num34);
                            }
                            num11 = num30;
                            str9 = Utilities.formatFraction(num11);
                            num14 = num32;
                        }
                    }
                    if (reportFormat == "html")
                    {
                        dataHtmlIfIZ = this.GetTotalHtml(dataHtmlIfIZ, num19, num21, num20, num2);
                        this.lblPurchaseBookRow.Text = dataHtmlIfIZ;
                    }
                    if (reportFormat == "excel")
                    {
                        num34++;
                        this.GetTotalExcel(dataHtmlIfIZ, num34, num19, num21, num20, num2, sheet, headerStyle, workbook);
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }
    }
}