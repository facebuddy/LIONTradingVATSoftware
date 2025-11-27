using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class PeriodicStockReportsNew : Page, IRequiresSessionState
    {
        private DBUtility db = new DBUtility();

        private WorkOrderBLL dbBLL = new WorkOrderBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

        private ExcelUtility excelUtility = new ExcelUtility();

        private void LogException(Exception exception, string context)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Concat("Context: ", context));
            stringBuilder.AppendLine(string.Concat("Message: ", exception.Message));
            if (exception.InnerException != null)
            {
                stringBuilder.AppendLine(string.Concat("Inner: ", exception.InnerException.Message));
            }
            stringBuilder.AppendLine(string.Concat("StackTrace: ", exception.StackTrace));
            string logDetails = stringBuilder.ToString();
            Console.Error.WriteLine(logDetails);
            ReallySimpleLog.WriteLog(logDetails);
        }
        public PeriodicStockReportsNew()
        {
        }


        public DataTable GetPurchaseInformationByItemId(DateTime fDate, DateTime tDate, int Item_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                object[] itemId = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpd.item_id,i.item_name,tpd.quantity,(tpd.quantity*tpd.purchase_unit_price) price,\r\n                       purchase_vat,purchase_sd,\r\n                       case when  tpm.challan_type='P' then 'Purchase' \r\n                       when tpm.challan_type='O' then 'Opening Balance'\r\n                       when tpm.challan_type='T' then 'Transfer Receive'\r\n                       when tpm.challan_type='D' then 'Debit' end remarks \r\n                       from trns_purchase_master tpm\r\n                       inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                       inner join item i on tpd.item_id = i.item_id\r\n                       where i.item_id=", Item_id, " and tpm.organization_id=", num1, " and tpm.org_branch_reg_id=", num, " and tpm.is_trns_accepted=true  and tpd.approver_stage='F'\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpd.quantity !=0 and tpm.challan_type in ('P','D','O','T')" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                this.LogException(exception, "GetPurchaseInformationByItemId (single branch)");
            }
            return dataTable;
        }


        public DataTable GetPurchaseInformationByItemId(DateTime fDate, DateTime tDate, long Item_id, string branchIds)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                object[] itemId = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpd.item_id,i.item_name,tpd.quantity,(tpd.quantity*tpd.purchase_unit_price) price,\r\n                       purchase_vat,purchase_sd,\r\n                       case when  tpm.challan_type='P' then 'Purchase' \r\n                       when tpm.challan_type='O' then 'Opening Balance'\r\n                       when tpm.challan_type='T' then 'Transfer Receive'\r\n                       when tpm.challan_type='D' then 'Debit' end remarks \r\n                       from trns_purchase_master tpm\r\n                       inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                       inner join item i on tpd.item_id = i.item_id\r\n                       where i.item_id=", Item_id, " and tpm.organization_id=", num, " and tpm.org_branch_reg_id in(", branchIds, ") and tpm.is_trns_accepted=true  and tpm.approver_stage='F'\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                       and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpd.quantity !=0 and tpm.challan_type in ('P','D','O','T')" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                this.LogException(exception, "GetPurchaseInformationByItemId (multiple branches)");
            }
            return dataTable;
        }



        public DataTable GetSaleInformationByItemId(DateTime fDate, DateTime tDate, long Item_id, string branchIds)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                object[] itemId = new object[] { "select to_char(tpm.date_challan,'dd-MON-yyyy') date_challan,tpd.item_id,i.item_name,case when installment_status=false then tpd.quantity else 0 end quantity,(tpd.quantity*tpd.actual_price) price,\r\n                      vat,sd ,CASE WHEN tpm.CHALLAN_TYPE='D' THEN 'Dispose' ELSE 'Sale' END as remarks, tpm.date_challan orderDate\r\n                from trns_sale_master tpm\r\n                inner join trns_sale_detail tpd on tpm.challan_id = tpd.challan_id\r\n                inner join item i on tpd.item_id = i.item_id\r\n                where i.item_id=", Item_id, "  and  tpm.organization_id=", num, " and tpm.org_branch_reg_id in(", branchIds, ") and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and to_date(to_char(tpm.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tpm.approver_stage='F'\r\n                \r\n                union ALL\r\n\r\n                select to_char(tnm.date_note,'dd-MON-yyyy') date_challan,tnd.item_id,i.item_name,tnd.quantity,(tnd.quantity*tnd.actual_price) price,\r\n                tnd.return_vat,tnd.return_sd ,'Credit' remarks , tnm.date_note orderDate\r\n                from trns_note_master tnm\r\n                inner join trns_note_detail tnd on tnm.note_id = tnd.note_id\r\n                inner join item i on tnd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and tnm.organization_id=", num, " and tnm.org_branch_reg_id in(", branchIds, ") and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and to_date(to_char(tnm.date_note,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tnd.status!='O' and tnm.note_type='C'\r\n           \r\n                union ALL\r\n\r\n                 select to_char(tnm.issues_date,'dd-MON-yyyy') date_challan,tnd.item_id,i.item_name,tnd.quantity,(tnd.quantity*tnd.unit_price) price,\r\n                tnd.vat_amount,tnd.sd_amount ,'Transfer Receive' remarks , tnm.issues_date orderDate\r\n                from trns_transfer_master tnm\r\n                inner join trns_transfer_detail tnd on tnm.transfer_id = tnd.transfer_id\r\n                inner join item i on tnd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and tnm.organization_id=", num, " and tnm.issuing_branch_id in(", branchIds, ") \r\n                and cast(tnm.issues_date as date) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and cast(tnm.issues_date as date) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and tnm.transfer_status = 'I'\r\n                \r\n                union ALL\r\n\r\n                select to_char(gd.date_consumable_challan ,'dd-MON-yyyy') date_challan,gd.item_id,i.item_name,gd.quantity,gd.price,\r\n                gd.discounted_vat vat_amount,gd.discounted_sd sd_amount ,case when gd.remarks='' then 'Gift' else gd.remarks end remarks, gd.date_consumable_challan orderDate\r\n                from gift_items_detail gd               \r\n                inner join item i on gd.item_id = i.item_id\r\n                where i.item_id=", Item_id, " and gd.organization_id=", num, " and gd.org_branch_id in(", branchIds, ")  \r\n                and cast(gd.date_consumable_challan as date) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                and cast(gd.date_consumable_challan as date) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n\r\n                order by orderDate desc" };
                string str = string.Concat(itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                this.LogException(exception, "GetSaleInformationByItemId");
            }
            return dataTable;
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
                this.LogException(exception, "btnExportToExcel_Click");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.showReport("html", null, null, null);
            }
            catch (Exception exception)
            {
                this.LogException(exception, "btnSearch_Click");
            }
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
            string str = this.Session["ORGANIZATION_NAME"] as string ?? string.Empty;
            string str1 = this.Session["ORGANIZATION_BIN"] as string ?? string.Empty;
            string str2 = this.Session["OrgBranch_Name"] as string ?? string.Empty;
            string str3 = this.Session["OrgBranch_Address"] as string ?? string.Empty;
            DateTime dateTime = DateTime.ParseExact(this.txtFDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string str4 = dateTime.ToString("dd-MMM-yyyy");
            string str5 = dateTime1.ToString("dd-MMM-yyyy");
            string[] strArrays = new string[] { "Periodic Stock Report \n", str, "\nBIN:", str1, "\nBranch Name:", str2, "\nBranch Address:", str3, "\nPeriod:", str4, " To ", str5 };
            string str6 = string.Concat(strArrays);
            this.excelUtility.CreateCell(rows, 0, str6, headerStyle);
            this.excelUtility.CreateCell(rows1, 0, "S/N", headerStyle);
            this.excelUtility.CreateCell(rows1, 1, "Item Name", headerStyle);
            this.excelUtility.CreateCell(rows1, 2, "Unit", headerStyle);
            this.excelUtility.CreateCell(rows1, 3, "Opening Balance", headerStyle);
            this.excelUtility.CreateCell(rows1, 5, "Purchase", headerStyle);
            this.excelUtility.CreateCell(rows1, 9, "Production", headerStyle);
            this.excelUtility.CreateCell(rows1, 13, "Sale/Transfer", headerStyle);
            this.excelUtility.CreateCell(rows1, 17, "Closing Balance", headerStyle);
            this.excelUtility.CreateCell(rows1, 19, "Weight-wise Balance", headerStyle);
            this.excelUtility.CreateCell(rows2, 3, "Quantity", headerStyle);
            this.excelUtility.CreateCell(rows2, 4, "Value", headerStyle);
            this.excelUtility.CreateCell(rows2, 5, "Quantity", headerStyle);
            this.excelUtility.CreateCell(rows2, 6, "Value", headerStyle);
            this.excelUtility.CreateCell(rows2, 7, "Supplementary Duty", headerStyle);
            this.excelUtility.CreateCell(rows2, 8, "VAT", headerStyle);
            this.excelUtility.CreateCell(rows2, 9, "Quantity", headerStyle);
            this.excelUtility.CreateCell(rows2, 10, "Value", headerStyle);
            this.excelUtility.CreateCell(rows2, 11, "Supplementary Duty", headerStyle);
            this.excelUtility.CreateCell(rows2, 12, "VAT", headerStyle);
            this.excelUtility.CreateCell(rows2, 13, "Quantity", headerStyle);
            this.excelUtility.CreateCell(rows2, 14, "Value", headerStyle);
            this.excelUtility.CreateCell(rows2, 15, "Supplementary Duty", headerStyle);
            this.excelUtility.CreateCell(rows2, 16, "VAT", headerStyle);
            this.excelUtility.CreateCell(rows2, 17, "Quantity", headerStyle);
            this.excelUtility.CreateCell(rows2, 18, "Value", headerStyle);
            this.excelUtility.CreateCell(rows2, 19, "Quantity", headerStyle);
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

        private void GetDataExcel(int rowIndex, string displayHTML, int i, DataTable dt, decimal PreQuantity, long item_iddt, string sPreQuantity, decimal PrePrice, decimal PurQuantity, string sPurQuantity, decimal PurPrice, decimal PurSD, decimal PurVat, decimal ProductionQuantity, string sProductionQuantity, decimal ProductionPrice, decimal ProductionSD, decimal ProductionVat, decimal SaleQuantity, string sSaleQuantity, decimal SalePrice, decimal SaleSD, decimal SaleVat, decimal ExtQuantity, string sExtQuantity, decimal ExtPrice, decimal weightQuantity, ISheet sheet, HSSFCellStyle headerStyle)
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
                        this.excelUtility.CreateCell(rows, 4, Utilities.RoundUpToWithString(PrePrice, num) ?? "", headerStyle);
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

        private decimal ParseDecimalSafe(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }

            if (decimal.TryParse(value, out result))
            {
                return result;
            }

            return new decimal(0);
        }

        private string GetDataHtml(string displayHTML, int i, DataTable dt, decimal PreQuantity, long item_iddt, string sPreQty, decimal PrePrice, decimal PurQuantity, string sPurQty, decimal PurPrice, decimal PurSD, decimal PurVat, decimal ProductionQuantity, string sProductionQty, decimal ProductionPrice, decimal ProductionSD, decimal ProductionVat, decimal SaleQuantity, string sSaleQty, decimal SalePrice, decimal SaleSD, decimal SaleVat, decimal ExtQuantity, string sExtQty, decimal ExtPrice, decimal weightQuantity)
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
            decimal num1 = this.ParseDecimalSafe(sPreQty);
            decimal num2 = this.ParseDecimalSafe(sPurQty);
            decimal num3 = this.ParseDecimalSafe(sProductionQty);
            decimal num4 = this.ParseDecimalSafe(sSaleQty);
            decimal num5 = this.ParseDecimalSafe(sExtQty);
            if (this.chk1.Checked)
            {
                this.col1.Visible = true;
                this.col11.Visible = true;
                this.col12.Visible = true;
                if (PreQuantity != new decimal(0))
                {
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num1, num), "</td>");
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(PrePrice, num), "</td>");
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
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num2, num), "</td>");
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
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num3, num), "</td>");
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
                    displayHTML = string.Concat(displayHTML, "<td style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num4, num), "</td>");
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
                    object[] itemIddt1 = new object[] { obj16, "<td style='text-align:right;padding:5px'><a href='#PopupContent1_", item_iddt, "' data-toggle='modal' data-target='#PopupContent1_", item_iddt, "'>", Utilities.RoundUpToWithString(num5, num), "</a></td>" };
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

        private ArrayList GetRawMaterialValue(DateTime date, long itemId, string branchIds)
        {
            ArrayList arrayLists = new ArrayList();
            DataTable dataTable = new DataTable();
            trnsPurchaseMasterBLL _trnsPurchaseMasterBLL = new trnsPurchaseMasterBLL();
            DateTime dateTime = DateTime.ParseExact(this.txtFDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            if (this.drpProductType.SelectedValue == "R")
            {
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                dataTable = _trnsPurchaseMasterBLL.PurchaseAccountingBookPrevious(date, itemId, branchIds);
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DateTime dateTime2 = Convert.ToDateTime(dataTable.Rows[i]["challan_date"]);
                        if (i <= 0)
                        {
                            decimal num7 = new decimal(0);
                            decimal num8 = new decimal(0);
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
                            string str = "0";
                            DataTable earlyAvailableStocOpening = _trnsPurchaseMasterBLL.GetEarlyAvailableStocOpening(date.AddDays(-1), itemId, branchIds);
                            if (earlyAvailableStocOpening.Rows.Count > 0)
                            {
                                num7 = Convert.ToDecimal(earlyAvailableStocOpening.Rows[0]["item_qty"]);
                                num8 = Convert.ToDecimal(earlyAvailableStocOpening.Rows[0]["item_value"]);
                            }
                            num3 = num7;
                            num4 = num8;
                            if (dataTable.Rows[i]["status"].ToString() == "P")
                            {
                                decimal num26 = (num3 == new decimal(0) ? num4 : num4 / num3);
                                num9 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                num9.ToString();
                                decimal num27 = new decimal(0);
                                num27 = Convert.ToDecimal(dataTable.Rows[i]["production_Qty"]);
                                num10 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num11 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                num12 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num13 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                if (Convert.ToDecimal(dataTable.Rows[i]["quantity"]) != new decimal(0))
                                {
                                    num14 = Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]);
                                    if (dateTime2 >= dateTime && dateTime2 <= dateTime1)
                                    {
                                        string withString = "0";
                                        withString = Utilities.RoundUpToWithString(num14, num);
                                        num2 += Convert.ToDecimal(withString);
                                    }
                                }
                                else
                                {
                                    num14 = num26 * num27;
                                    if (dateTime2 >= dateTime && dateTime2 <= dateTime1)
                                    {
                                        string withString1 = "0";
                                        withString1 = Utilities.RoundUpToWithString(num14, num);
                                        num2 += Convert.ToDecimal(withString1);
                                    }
                                }
                                num27.ToString();
                                num15 = Convert.ToDecimal(dataTable.Rows[i]["price"]);
                                if (dataTable.Rows[i]["remarks"].ToString().Trim() != "Debit")
                                {
                                    num16 += num15;
                                }
                                num15.ToString();
                                num17 = (num10 != new decimal(0) || num12 != new decimal(0) ? num3 - (num10 + num12) : num3 + num9);
                                num17.ToString();
                                num18 = (num10 != new decimal(0) || num12 != new decimal(0) ? num4 - (num11 + num13) : num15 + num4);
                                num19 = num17 - num27;
                                str = num19.ToString();
                                num20 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                num21 += num20;
                                num22 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                num23 += num22;
                                num24 = num18 - num14;
                                num25 = num3 + num9;
                                num3 = Convert.ToDecimal(str);
                                num4 = num24;
                            }
                        }
                        else
                        {
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
                            decimal num45 = new decimal(0);
                            if (dataTable.Rows[i]["status"].ToString() == "P")
                            {
                                decimal num46 = (num3 == new decimal(0) ? num4 : num4 / num3);
                                num28 = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                                num28.ToString();
                                num45 = Convert.ToDecimal(dataTable.Rows[i]["production_Qty"]);
                                num29 = Convert.ToDecimal(dataTable.Rows[i]["dispose_quantity"]);
                                num30 = Convert.ToDecimal(dataTable.Rows[i]["dispose_price"]);
                                num31 = Convert.ToDecimal(dataTable.Rows[i]["debit_quantity"]);
                                num32 = Convert.ToDecimal(dataTable.Rows[i]["debit_price"]);
                                if (Convert.ToDecimal(dataTable.Rows[i]["quantity"]) != new decimal(0))
                                {
                                    num33 = Convert.ToDecimal(dataTable.Rows[i]["purchase_unit_price"]);
                                    if (dateTime2 >= dateTime && dateTime2 <= dateTime1)
                                    {
                                        string str1 = "0";
                                        str1 = Utilities.RoundUpToWithString(num33, num);
                                        num2 += Convert.ToDecimal(str1);
                                    }
                                }
                                else
                                {
                                    num33 = num46 * num45;
                                    if (dateTime2 >= dateTime && dateTime2 <= dateTime1)
                                    {
                                        string withString2 = "0";
                                        withString2 = Utilities.RoundUpToWithString(num33, num);
                                        num2 += Convert.ToDecimal(withString2);
                                    }
                                }
                                num45.ToString();
                                num34 = Convert.ToDecimal(dataTable.Rows[i]["price"]);
                                if (!dataTable.Rows[i]["Remarks"].ToString().Equals("Direct Sale"))
                                {
                                    if (dataTable.Rows[i]["remarks"].ToString().Trim() != "Debit")
                                    {
                                        num35 += num34;
                                    }
                                    num34.ToString();
                                }
                                else
                                {
                                    num35 -= num34;
                                    num34.ToString();
                                }
                                if ((num29 != new decimal(0) || num31 != new decimal(0)) && !dataTable.Rows[i]["Remarks"].ToString().Equals("Credit"))
                                {
                                    num36 = num3 - (num29 + num31);
                                }
                                else if (!dataTable.Rows[i]["Remarks"].ToString().Equals("Credit"))
                                {
                                    num36 = (!dataTable.Rows[i]["Remarks"].ToString().Equals("Direct Sale") ? num3 + num28 : num3 - num28);
                                }
                                else
                                {
                                    num36 = num3 + num31;
                                }
                                if ((num29 != new decimal(0) || num31 != new decimal(0)) && !dataTable.Rows[i]["Remarks"].ToString().Equals("Credit"))
                                {
                                    num37 = num4 - (num30 + num32);
                                }
                                else if (!dataTable.Rows[i]["Remarks"].ToString().Equals("Credit"))
                                {
                                    num37 = (!dataTable.Rows[i]["Remarks"].ToString().Equals("Direct Sale") ? num34 + num4 : num4 - num34);
                                }
                                else
                                {
                                    num37 = num4 + num32;
                                }
                                num36.ToString();
                                num38 = num36 - num45;
                                num38.ToString();
                                num39 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                                num40 += num39;
                                num41 = Convert.ToDecimal(dataTable.Rows[i]["sd"]);
                                num42 += num41;
                                num43 = num37 - num33;
                            }
                            num44 = num5 + num28;
                            num3 = num38;
                            num4 = num43;
                        }
                    }
                }
                num1 = num3;
                num2 = num4;
            }
            arrayLists.Add(num1);
            arrayLists.Add(num2);
            return arrayLists;
        }

        private string loadAdditionalPropertyData(long itemId, string branchIds)
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
            DataTable dataTable = this.objPDBll.geAdditionalPropertybyItemwithDate(itemId, dateTime, dateTime1, branchIds);
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
                ListItem listItem = new ListItem("-- SELECT --", "-999");
                ListItem listItem1 = new ListItem("All", "-99");
                this.drpItem.Items.Insert(0, listItem1);
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private string loadPurchaseData(long item_iddt, string branchIds)
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
            decimal num13 = new decimal(0);
            decimal num14 = new decimal(0);
            int num15 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            DateTime dateTime = DateTime.ParseExact(this.txtFDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataTable purchaseInformationByItemId = this.dbBLL.GetPurchaseInformationByItemId(dateTime, dateTime1, item_iddt, branchIds);
            DataTable saleInformationByItemId = this.dbBLL.GetSaleInformationByItemId(dateTime, dateTime1, item_iddt, branchIds);
            decimal num16 = new decimal(0);
            if (this.drpProductType.SelectedValue == "R")
            {
                DataTable itemLotInfo = _trnsPurchaseMasterBLL.GetItemLotInfo(item_iddt);
                if (itemLotInfo.Rows.Count < 1)
                {
                    itemLotInfo = _trnsPurchaseMasterBLL.GetItemlastLotInfo(item_iddt);
                }
                DataTable productionInformationByItemId = this.dbBLL.GetProductionInformationByItemId(dateTime, dateTime1, item_iddt, branchIds);
                if (productionInformationByItemId.Rows.Count > 0)
                {
                    empty5 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'>উৎপাদন হিসাব </th></tr><tr><th  style='text-align: center;'>তারিখ</th><th>পরিমাণ</th><th>মূল্য</th><th>সম্পূরক শুল্ক</th><th>মূসক</th><th>মন্তব্য</th></tr></thead>";
                    for (int i = 0; i < productionInformationByItemId.Rows.Count; i++)
                    {
                        productionInformationByItemId.Rows[i]["item_name"].ToString();
                        num = Convert.ToDecimal(productionInformationByItemId.Rows[i]["quantity"]);
                        num12 = (Convert.ToDecimal(productionInformationByItemId.Rows[i]["unit_price"]) != new decimal(0) ? Convert.ToDecimal(productionInformationByItemId.Rows[i]["unit_price"]) : accountingBookBLL.getTotalProPrice(itemLotInfo, num));
                        num16 += num12;
                        str7 = Utilities.formatFraction(num);
                        num2 = Convert.ToDecimal(productionInformationByItemId.Rows[i]["purchase_vat"]);
                        num3 = Convert.ToDecimal(productionInformationByItemId.Rows[i]["purchase_sd"]);
                        str6 = productionInformationByItemId.Rows[i]["remarks"].ToString();
                        this.production.Text = num16.ToString();
                        this.productionsd.Text = num3.ToString();
                        this.productionVAT.Text = num2.ToString();
                        string str12 = str5;
                        string[] strArrays = new string[] { str12, "<tbody><tr><td  style='text-align: center;padding:5px'>", productionInformationByItemId.Rows[i]["date_production"].ToString(), "</td><td  style='text-align:right;padding:5px'>", str7, "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num12, num15), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num3, num15), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num2, num15), "</td><td>", str6, "</td></tr></tbody>" };
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
                        DataTable taxRateByItemId = this.dbBLL.GetTaxRateByItemId(item_iddt);
                        if (taxRateByItemId.Rows.Count > 0)
                        {
                            num13 = Convert.ToDecimal(taxRateByItemId.Rows[0]["Vat"]);
                            num14 = Convert.ToDecimal(taxRateByItemId.Rows[0]["Sd"]);
                        }
                        finishProductProductionInformationByItemId.Rows[j]["item_name"].ToString();
                        num = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["quantity"]);
                        num12 = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["price"]);
                        num16 += num12;
                        str7 = Utilities.formatFraction(num);
                        num1 = Convert.ToDecimal(finishProductProductionInformationByItemId.Rows[j]["price"]);
                        num3 = (num1 * num14) / new decimal(100);
                        num2 = ((num1 + num3) * num13) / new decimal(100);
                        str6 = finishProductProductionInformationByItemId.Rows[j]["remarks"].ToString();
                        this.production.Text = num16.ToString();
                        this.productionsd.Text = num3.ToString();
                        this.productionVAT.Text = num2.ToString();
                        string str13 = str5;
                        string[] strArrays1 = new string[] { str13, "<tbody><tr><td  style='text-align: center;padding:5px'>", finishProductProductionInformationByItemId.Rows[j]["date_challan"].ToString(), "</td><td  style='text-align:right;padding:5px'>", str7, "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num1, num15), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num3, num15), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num2, num15), "</td><td>", str6, "</td></tr></tbody>" };
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
                    string[] strArrays2 = new string[] { str14, "<tbody><tr><td  style='text-align: center;padding:5px'>", purchaseInformationByItemId.Rows[k]["date_challan"].ToString(), "</td><td  style='text-align: right;padding:5px'>", str10, "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num5, num15), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num7, num15), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num6, num15), "</td><td>", str8, "</td></tr></tbody>" };
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
                    string[] strArrays3 = new string[] { str15, "<tbody><tr><td  style='text-align: center;padding:5px'>", saleInformationByItemId.Rows[l]["date_challan"].ToString(), "</td><td  style='text-align: right;padding:5px'>", str11, "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num9, num15), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num11, num15), "</td><td  style='text-align: right;padding:5px'>", Utilities.RoundUpToWithString(num10, num15), "</td><td>", str9, "</td></tr></tbody>" };
                    str2 = string.Concat(strArrays3);
                    empty7 = string.Concat("<table border='1' style='width: 100%; border-collapse: collapse; border: 1px solid #000000'>", empty3, str2, "</table>");
                }
            }
            object[] itemIddt = new object[] { "<div id='PopupContent_", item_iddt, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content' id='modalContent_", item_iddt, "'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><button type='button' onclick='printModalContent(\"modalContent_", item_iddt, "\");' style='float: left; margin-right: 10px;'>Print</button><h4 class='modal-title'></h4></div><div class='modal-body'>", empty8, "</div><div class='modal-body'>", empty7, "</div><div class='modal-body'>", str4, "</div></div></div></div>" };
            return string.Concat(string.Concat(itemIddt), "<script>function printModalContent(modalId) {  var modalContent = document.getElementById(modalId).cloneNode(true);  var buttons = modalContent.getElementsByTagName('button');  while (buttons.length > 0) { buttons[0].parentNode.removeChild(buttons[0]); }  var iframe = document.createElement('iframe');  iframe.style.position = 'absolute';  iframe.style.width = '0px';  iframe.style.height = '0px';  document.body.appendChild(iframe);  var iframeDoc = iframe.contentWindow.document;  iframeDoc.open();  iframeDoc.write('<html><head><title>Print</title></head><body>');  iframeDoc.write(modalContent.innerHTML);  iframeDoc.write('</body></html>');  iframeDoc.close();  iframe.contentWindow.focus();  iframe.contentWindow.print();  document.body.removeChild(iframe);}</script>");
        }

        private void OrgBranchList()
        {
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
                DataTable dataTable = productTransferBLL.fillOrgBranch();
                if (dataTable != null)
                {
                    this.drpBranch.DataSource = dataTable;
                    this.drpBranch.DataTextField = dataTable.Columns["branch_unit_name"].ToString();
                    this.drpBranch.DataValueField = dataTable.Columns["org_branch_reg_id"].ToString();
                    this.drpBranch.DataBind();
                }
                ListItem listItem = new ListItem("All", "-99");
                this.drpBranch.Items.Insert(0, listItem);
                this.drpBranch.SelectedValue = num.ToString();
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
                this.orgId.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.OrgBin.Text = this.Session["ORGANIZATION_BIN"].ToString();
                //this.OrgBranchName.Text = this.Session["OrgBranch_Name"].ToString();
               // this.OrgBranchAddress.Text = this.Session["OrgBranch_Address"].ToString();
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
                this.OrgBranchList();
            }
            ScriptManager current = ScriptManager.GetCurrent(this.Page);
            current.RegisterPostBackControl(this.btnExportToExcel);
            current.RegisterPostBackControl(this.btnSearch);
            current.AsyncPostBackTimeout = 3600;
        }

        private void showReport(string reportFormat, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            try
            {
                UserBLL userBLL = new UserBLL();
                AccountingBookBLL accountingBookBLL = new AccountingBookBLL();
                trnsPurchaseMasterBLL _trnsPurchaseMasterBLL = new trnsPurchaseMasterBLL();
                this.PopupContainer.InnerHtml = "";
                if (string.IsNullOrEmpty(this.txtFDate.Text) || string.IsNullOrEmpty(this.txtToDate.Text))
                {
                    this.msgBox.AddMessage(" Please insert From Date and To Date Properly ", (MsgBoxs.enmMessageType)2);
                }
                else if (this.drpProductType.SelectedValue == "")
                {
                    this.msgBox.AddMessage(" Please Select Item Type", (MsgBoxs.enmMessageType)2);
                }
                else if (this.drpItem.SelectedValue == "-999")
                {
                    this.msgBox.AddMessage(" Please Select Item", (MsgBoxs.enmMessageType)2);
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
                    long num8 = Convert.ToInt64(this.drpItem.SelectedValue);
                    string selectedValue = this.drpProductType.SelectedValue;
                    string selectedValue1 = "";
                    int num9 = 0;
                    if (this.drpBranch.SelectedValue != "-99")
                    {
                        selectedValue1 = this.drpBranch.SelectedValue;
                        num9 = Convert.ToInt32(this.drpBranch.SelectedValue);
                    }
                    else
                    {
                        List<string> strs = new List<string>();
                        foreach (ListItem item in this.drpBranch.Items)
                        {
                            if (item.Value == "-99")
                            {
                                continue;
                            }
                            strs.Add(item.Value);
                        }
                        selectedValue1 = string.Join(",", strs);
                    }
                    if (num9 <= 0)
                    {
                       // this.OrgBranchName.Text = "All";
                        //this.OrgBranchAddress.Text = "";
                    }
                    else
                    {
                        int num10 = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
                        DataTable businessInformation = userBLL.GetBusinessInformation(num10, num9);
                        //this.OrgBranchName.Text = businessInformation.Rows[0]["branch_unit_name"].ToString();
                        //this.OrgBranchAddress.Text = businessInformation.Rows[0]["org_branch_address"].ToString();
                    }
                    dataTable = this.dbBLL.GetPreodicStockReportData(dateTime, dateTime1, num8, selectedValue1, selectedValue);
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
                        this.msgBox.AddMessage("No Record Found.", (MsgBoxs.enmMessageType)2);
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
                        this.msgBox.AddMessage("No Record Found.", (MsgBoxs.enmMessageType)2);
                    }
                    else
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            this.production.Text = "";
                            this.productionsd.Text = "";
                            this.productionVAT.Text = "";
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
                            decimal num30 = new decimal(0);
                            string str1 = "";
                            string str2 = "";
                            string str3 = "";
                            string str4 = "";
                            string str5 = "";
                            decimal num31 = new decimal(0);
                            decimal num32 = new decimal(0);
                            decimal num33 = new decimal(0);
                            decimal num34 = new decimal(0);
                            decimal num35 = new decimal(0);
                            decimal num36 = new decimal(0);
                            decimal openingQuantity = new decimal(0);
                            decimal openingAmount = new decimal(0);
                            decimal closingQuantity = new decimal(0);
                            decimal closingAmount = new decimal(0);
                            long num37 = Convert.ToInt64(dataTable.Rows[i]["item_id"].ToString());
                            DataTable lastPurchaseUnitId = _trnsPurchaseMasterBLL.GetLastPurchase_unitId(dateTime, dateTime1, num37, num9);
                            if (lastPurchaseUnitId.Rows.Count > 0)
                            {
                                num35 = Convert.ToDecimal(lastPurchaseUnitId.Rows[0]["purchase_unit_price"]);
                            }
                            if (this.drpProductType.SelectedValue == "R")
                            {
                                ArrayList arrayLists = new ArrayList();
                                ArrayList rawMaterialValue = new ArrayList();
                                arrayLists = this.GetRawMaterialValue(dateTime.AddDays(-1), num37, selectedValue1);
                                openingQuantity = Convert.ToDecimal(arrayLists[0]);
                                openingAmount = Convert.ToDecimal(arrayLists[1]);
                                rawMaterialValue = this.GetRawMaterialValue(dateTime1, num37, selectedValue1);
                                closingQuantity = Convert.ToDecimal(rawMaterialValue[0]);
                                closingAmount = Convert.ToDecimal(rawMaterialValue[1]);
                            }
                            empty1 = this.loadAdditionalPropertyData(num37, selectedValue1);
                            HtmlGenericControl popupContainer1 = this.PopupContainer1;
                            popupContainer1.InnerHtml = string.Concat(popupContainer1.InnerHtml, empty1);
                            str = this.loadPurchaseData(num37, selectedValue1);
                            HtmlGenericControl popupContainer = this.PopupContainer;
                            popupContainer.InnerHtml = string.Concat(popupContainer.InnerHtml, str);
                            num10 = (openingQuantity > new decimal(0) ? openingQuantity : Convert.ToDecimal(dataTable.Rows[i]["openpurqnt"]) + Convert.ToDecimal(dataTable.Rows[i]["preQuantity"]));
                            str1 = Utilities.formatFraction(num10);
                            if (num10 == new decimal(0))
                            {
                                num11 = new decimal(0);
                            }
                            else if (this.drpProductType.SelectedValue == "R")
                            {
                                num11 = (openingAmount != new decimal(0) ? openingAmount : Convert.ToDecimal(dataTable.Rows[i]["openpuramount"]) + Convert.ToDecimal(dataTable.Rows[i]["preQntAmount"]));
                            }
                            else if (this.drpProductType.SelectedValue == "C")
                            {
                                DataTable dataTable1 = accountingBookBLL.LastProductionAccountingBook(dateTime, num37, num9);
                                DataTable dataTable2 = accountingBookBLL.LastProductionAccountingBook(dateTime1, num37, num9);
                                if (dataTable1.Rows.Count > 0)
                                {
                                    num33 = Convert.ToDecimal(dataTable1.Rows[0]["unit_price"]);
                                }
                                if (dataTable2.Rows.Count > 0)
                                {
                                    num34 = Convert.ToDecimal(dataTable2.Rows[0]["unit_price"]);
                                }
                                num11 = (num33 != new decimal(0) ? num33 * num10 : Convert.ToDecimal(dataTable.Rows[i]["openpuramount"]) + Convert.ToDecimal(dataTable.Rows[i]["preQntAmount"]));
                            }
                            else if (this.drpProductType.SelectedValue == "F")
                            {
                                num11 = (num35 != new decimal(0) ? num35 * num10 : Convert.ToDecimal(dataTable.Rows[i]["openpuramount"]) + Convert.ToDecimal(dataTable.Rows[i]["preQntAmount"]));
                            }
                            else if (this.drpProductType.SelectedValue != "E")
                            {
                                num11 = Convert.ToDecimal(dataTable.Rows[i]["openpuramount"]) + Convert.ToDecimal(dataTable.Rows[i]["preQntAmount"]);
                            }
                            else
                            {
                                num11 = (num35 != new decimal(0) ? num35 * num10 : Convert.ToDecimal(dataTable.Rows[i]["openpuramount"]) + Convert.ToDecimal(dataTable.Rows[i]["preQntAmount"]));
                            }
                            num14 = Convert.ToDecimal(dataTable.Rows[i]["purqnt"].ToString());
                            num17 = Convert.ToDecimal(dataTable.Rows[i]["puramount"].ToString());
                            if (this.drpProductType.SelectedValue == "R" && (num10 + num14) > new decimal(0))
                            {
                                decimal num38 = (num11 + num17) / (num10 + num14);
                            }
                            str2 = Utilities.formatFraction(num14);
                            num15 = Convert.ToDecimal(dataTable.Rows[i]["purvat"].ToString());
                            num16 = Convert.ToDecimal(dataTable.Rows[i]["pursd"].ToString());
                            num28 = Convert.ToDecimal(dataTable.Rows[i]["proq"].ToString());
                            num30 = Convert.ToDecimal(dataTable.Rows[i]["prot"].ToString());
                            num20 = Convert.ToDecimal(dataTable.Rows[i]["productionqnt"].ToString()) + num28;
                            str3 = Utilities.formatFraction(num20);
                            num18 = Convert.ToDecimal(dataTable.Rows[i]["productionqnt"].ToString());
                            num19 = Convert.ToDecimal(dataTable.Rows[i]["productionpuramount"].ToString());
                            num24 = Convert.ToDecimal(dataTable.Rows[i]["salqnt"].ToString());
                            str4 = Utilities.formatFraction(num24);
                            num25 = Convert.ToDecimal(dataTable.Rows[i]["salamount"].ToString());
                            num26 = Convert.ToDecimal(dataTable.Rows[i]["salvat"].ToString());
                            num27 = Convert.ToDecimal(dataTable.Rows[i]["salsd"].ToString());
                            if (this.drpProductType.SelectedValue == "R")
                            {
                                decimal num39 = (num10 + num14) - (num24 + num28);
                                if (num39 > new decimal(0))
                                {
                                    decimal num40 = num32 / num39;
                                }

                                num23 = num30;
                            }
                            if (this.drpProductType.SelectedValue == "C")
                            {
                                num23 = num19;
                            }
                            if (this.drpProductType.SelectedValue == "R")
                            {
                                num12 = (closingQuantity > new decimal(0) ? closingQuantity : (num10 + num14) - (num24 + num28));
                                if (num12 <= new decimal(0))
                                {
                                    num12 = new decimal(0);
                                    str5 = Utilities.formatFraction(num12);
                                    num13 = new decimal(0);
                                }
                                else
                                {
                                    str5 = Utilities.formatFraction(num12);
                                    decimal totalQuantity = num10 + num14;
                                    decimal averageRate = (totalQuantity > new decimal(0) ? (num11 + num17) / totalQuantity : new decimal(0));
                                    if (closingAmount > new decimal(0))
                                    {
                                        num13 = closingAmount;
                                    }
                                    else if (averageRate > new decimal(0))
                                    {
                                        num13 = averageRate * num12;
                                    }
                                    else
                                    {
                                        num13 = Math.Max(new decimal(0), (num11 + num17) - (num25 + num23));
                                    }
                                }
                            }
                            else if (this.drpProductType.SelectedValue == "C")
                            {
                                num12 = ((num10 + num14) + num18) - num24;
                                str5 = Utilities.formatFraction(num12);
                                num13 = (num34 != new decimal(0) ? num34 * num12 : ((num11 + num17) + num23) - num25);
                            }
                            else if (this.drpProductType.SelectedValue != "F")
                            {
                                num12 = ((num10 + num14) + num18) - num24;
                                str5 = Utilities.formatFraction(num12);
                                num13 = ((num11 + num17) + num19) - num25;
                            }
                            else
                            {
                                num12 = ((num10 + num14) + num18) - num24;
                                str5 = Utilities.formatFraction(num12);
                                num13 = (num35 <= new decimal(0) ? num12 * (num17 == new decimal(0) || num14 == new decimal(0) ? new decimal(0) : num17 / num14) : num12 * num35);
                            }
                            if (reportFormat == "html")
                            {
                                empty = this.GetDataHtml(empty, i, dataTable, num10, num37, str1, num11, num14, str2, num17, num16, num15, num20, str3, num23, num22, num21, num24, str4, num25, num27, num26, num12, str5, num13, num29);
                            }
                            int num41 = 3;
                            if (reportFormat == "excel")
                            {
                                num41 = num41 + i + 1;
                                this.GetDataExcel(num41, empty, i, dataTable, num10, num37, str1, num11, num14, str2, num17, num16, num15, num20, str3, num23, num22, num21, num24, str4, num25, num27, num26, num12, str5, num13, num29, sheet, headerStyle);
                            }
                            num += num11;
                            num1 += num17;
                            num3 += num15;
                            num2 += num16;
                            num5 = num5 + num25 + num30;
                            num7 += num26;
                            num6 += num27;
                            num4 += num13;
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

        private decimal TotalProductionAmountByDateRange()
        {
            DateTime.ParseExact(this.txtFDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return new decimal(0);
        }


    }
}