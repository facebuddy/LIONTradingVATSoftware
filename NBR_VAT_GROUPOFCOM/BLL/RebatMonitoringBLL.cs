using System;
using System.Data;
using System.Web;
using System.Web.SessionState;




namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class RebatMonitoringBLL
    {
        private DBUtility connDB = new DBUtility();

        public RebatMonitoringBLL()
        {
        }

        public DataTable GetAllIngridienceof15VAT(string fDate, string tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select distinct i.Item_id,i.item_name||'--'||i.hs_code item_name from Item i                            \r\n                            inner join trns_purchase_detail tpd on tpd.item_id = i.item_id\r\n                            inner join trns_purchase_master tpm on tpd.challan_id = tpm.challan_id\r\n                            where CAST(tpm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(tpm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and i.Is_deleted=false AND i.item_type IN('I','S') \r\n                            AND i.product_type IN('R') and (i.organization_id=", num, " or i.is_for_all_bss_unit=true)\r\n                            and tpd.vat_rate=15" };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanNobyItemId(int ItemId)
        {
            string str = string.Concat("Select tm.challan_id , tm.challan_no from trns_purchase_master tm  inner join trns_purchase_detail tp on tm.challan_id=tp.challan_id where tp.item_id=", ItemId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getImportedHistory(DateTime fDate, DateTime tDate, long partyId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = "";
            if (partyId > (long)0)
            {
                str = string.Concat("AND tpm.party_id = ", partyId);
            }
            object[] objArray = new object[] { "select tpd.challan_id as RowId, tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,\r\n                        sum(tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd+tpd.cd+tpd.rd+tpd.ait+tpd.atv+tpd.tti) as total_price,\r\n                        sum(tpd.purchase_vat) as Vat, sum(tpd.purchase_sd) as sd,sum(tpd.cd) as cd,\r\n                        sum(tpd.rd) as rd,sum(tpd.ait) as ait,sum(tpd.atv) as atv, sum(tpd.tti) as tti,\r\n                        case when tpd.is_rebatable = true then 'Yes' else 'No' end is_rebatable,\r\n                        tp.party_name as party\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp on tpm.party_id = tp.party_id\r\n                            where tpm.purchase_type = 'I'  and tpd.is_rebatable = true  and tpm.challan_type='P' and tpd.is_exempted = false and CAST(tpm.date_challan AS DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tpm.date_challan AS DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                           ", str, " and tpd.challan_id <> '-999' and tpd.is_deleted = false AND tpm.organization_id = ", num, "  group by tpm.challan_no,tpm.date_challan,tp.party_name,tpd.is_rebatable,tpd.challan_id order by tpm.date_challan" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetImportHistory(string challanNo)
        {
            string str = string.Concat("select tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,i.item_name as item,\r\n                            tpd.Quantity,tpd.purchase_unit_price as unit_price, tpd.purchase_vat as Vat, tpd.purchase_sd as sd,tpd.cd,\r\n                            tpd.rd,tpd.ait,tpd.atv, tpd.tti,\r\n                            case when tpd.is_rebatable = true then 'Yes' else 'No' end is_rebatable,\r\n                            tp.party_name as party,tpd.row_no as RowId\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd\r\n                            on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i\r\n                            on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp\r\n                            on tpm.party_id = tp.party_id\r\n                            where tpd.challan_id = (select challan_id from trns_purchase_master where challan_no = '", challanNo, "') and tpd.is_deleted = false");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getImportHistoryVDS(string fDate, string tDate, long partyId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = "";
                if (partyId > (long)0)
                {
                    str = string.Concat("AND tpm.party_id = ", partyId);
                }
                object[] objArray = new object[] { "select tpd.challan_id as RowId, tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,\r\n                        sum(tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd+tpd.cd+tpd.rd+tpd.ait+tpd.atv+tpd.tti) as total_price,sum(tpd.Quantity*tpd.purchase_unit_price) amount,\r\n                        sum(tpd.purchase_vat) as Vat, sum(tpd.purchase_sd) as sd,sum(tpd.cd) as cd,\r\n                        sum(tpd.rd) as rd,sum(tpd.ait) as ait,sum(tpd.atv) as atv, sum(tpd.tti) as tti,\r\n                        case when tpd.is_source_tax_deduct = true then 'Yes' else 'No' end is_vds,\r\n                        tp.party_name as party\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd  on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp  on tpm.party_id = tp.party_id\r\n                            where tpm.purchase_type = 'I' and tpd.is_exempted = false and tpd.date_insert >= '", fDate, "' and tpd.date_insert <= '", tDate, "' \r\n                           ", str, " and tpd.challan_id <> '-999' and tpd.is_deleted = false AND tpm.organization_id = ", num, "  AND tpd.is_source_tax_deduct=true  group by tpm.challan_no,tpm.date_challan,tp.party_name,tpd.is_source_tax_deduct,tpd.challan_id order by tpm.date_challan" };
                string str1 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetImportHistoryVDS(string challanNo)
        {
            DataTable dataTable;
            try
            {
                string[] strArrays = new string[] { "select tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,i.item_name as item,\r\n                            tpd.Quantity,tpd.purchase_unit_price as unit_price, tpd.purchase_vat as Vat, tpd.purchase_sd as sd,tpd.cd,\r\n                            tpd.rd,tpd.ait,tpd.atv, tpd.tti,\r\n                            case when tpd.is_source_tax_deduct = true then 'Yes' else 'No' end is_vds,\r\n                            tp.party_name as party,tpd.row_no as RowId\r\n                            ,(select tc.tr_challan_no from trns_tr_challan_party_tracking tr inner join trns_treasury_challan tc on tr.challan_id=tc.challan_id where tr.challan_no = '", challanNo, "' limit 1) as tr_challan_no\r\n                            ,(select tc.date_challan from trns_tr_challan_party_tracking tr inner join trns_treasury_challan tc on tr.challan_id=tc.challan_id where tr.challan_no = '", challanNo, "' limit 1) as tr_challan_date\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp on tpm.party_id = tp.party_id\r\n                            where tpd.challan_id = (select challan_id from trns_purchase_master where challan_no = '", challanNo, "') and tpd.is_deleted = false" };
                string str = string.Concat(strArrays);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getImportRebateHistory(DateTime fDate, DateTime tDate, long partyId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = "";
            if (partyId > (long)0)
            {
                str = string.Concat("AND tpm.party_id = ", partyId);
            }
            object[] objArray = new object[] { "select tpd.challan_id as RowId, tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,\r\n                        sum(tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd+tpd.cd+tpd.rd+tpd.ait+tpd.atv+tpd.tti) as total_price,\r\n                        sum(tpd.purchase_vat) as Vat, sum(tpd.purchase_sd) as sd,sum(tpd.cd) as cd,\r\n                        sum(tpd.rd) as rd,sum(tpd.ait) as ait,sum(tpd.atv) as atv, sum(tpd.tti) as tti,\r\n                        case when tpd.is_rebatable = true then 'Yes' else 'No' end is_rebatable,\r\n                        tp.party_name as party\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp on tpm.party_id = tp.party_id\r\n                            where tpm.purchase_type = 'I' and tpd.is_rebatable = true and tpm.challan_type='P' and tpd.is_exempted = false and CAST(tpm.date_challan AS DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tpm.date_challan AS DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                           ", str, " and tpd.challan_id <> '-999' and tpd.is_deleted = false   and tpd.is_current_month_rebate=false  and tpd.approver_stage='F' AND tpm.organization_id = ", num, "  group by tpm.challan_no,tpm.date_challan,tp.party_name,tpd.is_rebatable,tpd.challan_id order by tpm.date_challan" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getLocalPurchasedHistory(DateTime fDate, DateTime tDate, long partyId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = "";
            if (partyId > (long)0)
            {
                str = string.Concat("AND tpm.party_id = ", partyId);
            }
            object[] objArray = new object[] { "select  tpd.challan_id as RowId, tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,\r\n                            sum(tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd) as total_price,\r\n                            sum(tpd.purchase_vat) as Vat, sum(tpd.purchase_sd) as sd, \r\n                            case when tpd.is_rebatable = true then 'Yes' else 'No' end is_rebatable,\r\n                            tp.party_name as party\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp  on tpm.party_id = tp.party_id\r\n                            where tpm.purchase_type = 'L'  and tpd.is_rebatable = true and tpm.challan_type='P' and CAST(tpm.date_challan AS DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tpm.date_challan AS DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                            ", str, " and tpd.challan_id <> '-999' and tpd.is_deleted = false AND tpm.organization_id = ", num, " group by tpm.challan_no,tpm.date_challan, tpd.is_rebatable,tp.party_name,tpd.challan_id order by tpm.date_challan" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getLocalPurchasedRebateHistory(DateTime fDate, DateTime tDate, long partyId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = "";
            if (partyId > (long)0)
            {
                str = string.Concat("AND tpm.party_id = ", partyId);
            }
            object[] objArray = new object[] { "select  tpd.challan_id as RowId, tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,\r\n                            sum(tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd) as total_price,\r\n                            sum(tpd.purchase_vat) as Vat, sum(tpd.purchase_sd) as sd, \r\n                            case when tpd.is_rebatable = true then 'Yes' else 'No' end is_rebatable,\r\n                            tp.party_name as party\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp  on tpm.party_id = tp.party_id\r\n                            where tpm.purchase_type = 'L'  and tpd.is_rebatable = true and tpm.challan_type='P' and CAST(tpm.date_challan AS DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tpm.date_challan AS DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                            ", str, " and tpd.challan_id <> '-999' and tpd.is_deleted = false  and tpd.is_current_month_rebate=false  and tpd.approver_stage='F' AND tpm.organization_id = ", num, " group by tpm.challan_no,tpm.date_challan, tpd.is_rebatable,tp.party_name,tpd.challan_id order by tpm.date_challan" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetLocalPurchaseHistory(int challanId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd/MM/yyyy') as challan_date,i.item_name as item,\r\n                            tpd.Quantity,tpd.purchase_unit_price as unit_price, tpd.purchase_vat as Vat, tpd.purchase_sd as sd,\r\n                            case when tpd.is_rebatable = true then 'Yes' else 'No' end is_rebatable,\r\n                            tp.party_name as party,tpd.row_no as RowId\r\n                            ,tpd.total_price AS price\r\n                            ,(tpd.total_price+tpd.purchase_vat+tpd.purchase_sd) AS price_total\r\n                            , case when tpd.is_rebatable = true then tpd.purchase_vat else 0 end rebatable_amount\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd  on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i  on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp  on tpm.party_id = tp.party_id\r\n                            where tpd.challan_id = ", challanId, " and tpd.is_deleted = false");
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getLocalPurchaseHistoryVDS(string fDate, string tDate, long partyId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = "";
                if (partyId > (long)0)
                {
                    str = string.Concat("AND tpm.party_id = ", partyId);
                }
                object[] objArray = new object[] { "select  tpd.challan_id as RowId, tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,\r\n                            sum(tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd) as total_price,sum(tpd.Quantity*tpd.purchase_unit_price) amount,\r\n                            sum(tpd.purchase_vat) as Vat, sum(tpd.purchase_sd) as sd, \r\n                            case when tpd.is_source_tax_deduct = true then 'Yes' else 'No' end is_vds,\r\n                            tp.party_name as party\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp on tpm.party_id = tp.party_id\r\n                            where tpm.purchase_type = 'L' and tpd.date_insert >= '", fDate, "' and tpd.date_insert <= '", tDate, "' \r\n                            ", str, " and tpd.challan_id <> '-999' and tpd.is_deleted = false AND tpm.organization_id = ", num, " AND tpd.is_source_tax_deduct = true group by tpm.challan_no,tpm.date_challan, tpd.is_source_tax_deduct,tp.party_name,tpd.challan_id order by tpm.date_challan" };
                string str1 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetLocalPurchaseHistoryVDS(string challanNo)
        {
            string[] strArrays = new string[] { "select tpm.challan_no as challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date,i.item_name as item,\r\n                            tpd.Quantity,tpd.purchase_unit_price as unit_price, tpd.purchase_vat as Vat, tpd.purchase_sd as sd,\r\n                            case when tpd.is_source_tax_deduct = true then 'Yes' else 'No' end is_vds,case when cth.tr_challan_status is not null then  'TR Challan Paid(partially)'  \r\n                            when tpm.is_vat_paid=true then 'TR Challan Paid' else '-' end payment,\r\n                            tp.party_name as party,tpd.row_no as RowId\r\n                            ,(select tc.tr_challan_no from trns_tr_challan_party_tracking tr inner join trns_treasury_challan tc on tr.challan_id=tc.challan_id where tr.challan_no = '", challanNo, "' limit 1) as tr_challan_no\r\n                            ,(select tc.date_challan from trns_tr_challan_party_tracking tr inner join trns_treasury_challan tc on tr.challan_id=tc.challan_id where tr.challan_no = '", challanNo, "' limit 1) as tr_challan_date\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd  on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join trns_party as tp on tpm.party_id = tp.party_id\r\n                           left join credit_transac_history cth on cth.challan_id=tpd.challan_id\r\n                            where tpd.challan_id = (select challan_id from trns_purchase_master where challan_no = '", challanNo, "' limit 1) and tpd.is_deleted = false" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getNBRParty()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.connDB.GetDataTable("select distinct tp.party_id, tp.party_name\r\n                            from trns_party as tp                           \r\n                            where tp.separator = 2 AND tp.party_name = 'National Board of Revenue'");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPartyByftDate(DateTime fDate, DateTime tDate)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select distinct tp.party_id, tp.party_name\r\n                            from trns_party as tp\r\n                            inner join trns_purchase_master as tpm\r\n                            on tp.party_id = tpm.party_id\r\n                            where CAST(tpm.date_challan AS DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tpm.date_challan AS DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tp.separator = 1 AND tp.organization_id = ", num };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPaymentHistory(string challanNo)
        {
            DataTable dataTable;
            try
            {
                string[] strArrays = new string[] { "select challan_no,TO_CHAR(date_insert,'dd/MM/yyyy') AS payment_date,cash_amount,bank_amount,credit_amount \r\n                            from trns_purchase_master where challan_id=(select challan_id from trns_purchase_master where challan_no = '", challanNo, "')\r\n                            UNION ALL\r\n                            select challan_no,TO_CHAR(payment_date,'dd/MM/yyyy') AS payment_date,cash_amount,bank_amount,balance_due as credit_amount \r\n                            from credit_transac_history where challan_id = (select challan_id from trns_purchase_master where challan_no = '", challanNo, "')" };
                string str = string.Concat(strArrays);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetSaleItemWithout15VAT(string fDate, string tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select distinct i.Item_id,i.item_name||'--'||i.hs_code item_name from Item i                            \r\n                            inner join trns_sale_detail tsd on tsd.item_id = i.item_id\r\n                            inner join trns_sale_master tsm on tsd.challan_id = tsm.challan_id\r\n                            where CAST(tsm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(tsm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and i.Is_deleted=false AND i.item_type IN('I','S') \r\n                            AND i.product_type IN('C') and (i.organization_id=", num, " or i.is_for_all_bss_unit=true)\r\n                            and tsd.vat_rate!=15" };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }
    }
}




