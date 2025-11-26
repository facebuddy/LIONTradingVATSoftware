using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.IO;
using System.Web;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ExcelUtility
    {
        public ExcelUtility()
        {
        }

        public void CreateCell(IRow CurrentRow, int CellIndex, string Value, HSSFCellStyle Style)
        {
            ICell style = CurrentRow.CreateCell(CellIndex);
            style.SetCellValue(Value);
            style.CellStyle = Style;
            style.CellStyle.WrapText = true;
        }

        public void downloadExcel(HSSFWorkbook workbook, ISheet sheet, HttpResponse Response, string fileName)
        {
            int lastCellNum = sheet.GetRow(0).LastCellNum;
            for (int i = 0; i <= lastCellNum; i++)
            {
                sheet.AutoSizeColumn(i);
                GC.Collect();
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    Response.Clear();
                    workbook.Write(memoryStream);
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    object[] objArray = new object[] { "attachment;filename=", fileName, " ", DateTime.Now, ".xls" };
                    Response.AddHeader("Content-Disposition", string.Format(string.Concat(objArray), new object[0]));
                    Response.BinaryWrite(memoryStream.ToArray());
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.SuppressContent = true;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception exception)
                {
                }
            }
        }

        public HSSFCellStyle headerBorderStyle(HSSFWorkbook workbook)
        {
            HSSFCellStyle hSSFCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            hSSFCellStyle.BorderLeft = BorderStyle.Thin;
            hSSFCellStyle.BorderTop = BorderStyle.Thin;
            hSSFCellStyle.BorderRight = BorderStyle.Thin;
            hSSFCellStyle.BorderBottom = BorderStyle.Medium;
            hSSFCellStyle.VerticalAlignment = VerticalAlignment.Center;
            hSSFCellStyle.Alignment = HorizontalAlignment.Center;
            return hSSFCellStyle;
        }

        public void MergeCell(HSSFWorkbook workbook, ISheet sheet, int startRowIdx, int endRowIdx, int startColIdx, int endColIdx)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(startRowIdx, endRowIdx, startColIdx, endColIdx);
            sheet.AddMergedRegion(cellRangeAddress);
            RegionUtil.SetBorderBottom(2, cellRangeAddress, sheet, workbook);
            RegionUtil.SetBorderLeft(2, cellRangeAddress, sheet, workbook);
            RegionUtil.SetBorderRight(2, cellRangeAddress, sheet, workbook);
            RegionUtil.SetBorderTop(2, cellRangeAddress, sheet, workbook);
        }
    }
}