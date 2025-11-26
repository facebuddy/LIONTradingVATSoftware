using System;
using System.Data;
using System.Web;
using System.Web.SessionState;



namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AdjustmentVoucherBLL
    {
        private  DBUtility DBUtil = new DBUtility();

        public AdjustmentVoucherBLL()
        {
        }

        public bool ExecuteDMLWithOnlyQuery(string strSql)
        {
            return this.DBUtil.ExecuteDMLWithOnlyQuery(strSql);
        }

        public DataTable GetAitPct(int itemId)
        {
            string str = string.Concat("select tax_value from item_tax_values where tax_id=5 and  item_id = ", itemId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAitPercentage(int itemId, string transactionType)
        {
            string str = "";
            if (transactionType == "L")
            {
                str = "and is_tran_local = true";
            }
            else if (transactionType == "I")
            {
                str = "and is_tran_import = true";
            }
            else if (transactionType == "S")
            {
                str = "and is_tran_sale = true";
            }
            else if (transactionType == "T")
            {
                str = "and is_trade_price = true";
            }
            string str1 = string.Concat("select tax_value from item_tax_values where tax_id=5 and  item_id = ", itemId, str);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetAitSale(int itemId)
        {
            string str = string.Concat("select tax_value from item_tax_values where is_tran_sale=true and tax_id=5 and  item_id = ", itemId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllCreditTransacWithDropdown(string fromDate, string toDate, int partyID)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "\r\n                        select to_char(SM.date_challan,'DD/MM/YYYY') date, SM.challan_id,SM.organization_id,SM.challan_no,SM.date_challan,\r\n                        SM.party_id,P.party_name, SM.total_bill_amount total,\r\n\t\t                        case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id \r\n\t\t                        order by h.scroll_id desc limit 1) is null \r\n\t\t\t\t                        then (SM.total_bill_amount-(SM.cash_amount+SM.bank_amount))\r\n\t\t                        else \r\n\t\t\t                           (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id order by h.scroll_id desc limit 1) end balance_due,\r\n                        coalesce((select Sum(VAT) from trns_sale_detail where is_source_tax_deduct=true AND challan_id=SM.challan_id),0) vds,\r\n                        SUM(SD.quantity * SD.actual_price) baseprice ,SUM((SD.quantity * SD.actual_price) + SD.sd) vatablePrice,coalesce((select coalesce(h.amount_without_vds,0) from credit_transac_history h where h.challan_id=SM.challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1  ),0) amount_without_vds\r\n                        --,(select Sum(VAT) from trns_sale_detail where challan_id=SM.challan_id) vat\r\n                        from trns_sale_master AS SM\r\n \r\n                        LEFT JOIN trns_party AS P ON SM.party_id = P.party_id\r\n                        LEFT JOIN trns_sale_detail AS SD ON SM.challan_id = SD.challan_id\r\n                        where sd.approver_stage='F' and CAST(SM.date_challan AS DATE) >= to_date('", fromDate, "', 'dd/MM/yyyy')  and CAST(SM.date_challan AS DATE) <= to_date('", toDate, "', 'dd/MM/yyyy')   AND SM.party_id = ", partyID, " AND SM.organization_id=", num, "\r\n                        AND SM.is_payment_finished = false group by Date,SM.challan_id,SM.organization_id,SM.challan_no,SM.date_challan,SM.party_id,P.party_name \r\n                        UNION ALL\r\n\r\n                        select  \r\n                        to_char(tpb.date_challan,'DD/MM/YYYY') as date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name,\r\n\t\t\t            tpb.credit_amount as total,  \r\n\t\t\t            case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  1 order by h.scroll_id desc limit 1) is null \r\n\t\t            \t                then tpb.credit_amount\r\n\t\t\t            else (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  1 order by h.scroll_id desc limit 1)\r\n\t\t\t                        end balance_due,\r\n\t\t\t            0 AS vds, tpb.credit_amount as baseprice, tpb.credit_amount as vatable_price,0 amount_without_vds\r\n\t\t\t\t    from trns_party_balance AS tpb\r\n\t\t\t            LEFT JOIN trns_party AS P  ON tpb.party_id = P.party_id\r\n                        where CAST(tpb.date_challan AS DATE) >= to_date('", fromDate, "', 'dd/MM/yyyy')  and CAST(tpb.date_challan AS DATE) <= to_date('", toDate, "', 'dd/MM/yyyy') AND tpb.credit_amount > 0  AND tpb.party_id = ", partyID, "  AND tpb.organization_id = ", num, "  AND tpb.is_payment_finished = false and tpb.challan_type = 'R'\r\n                                    group by Date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name\r\n                        order by date_challan desc" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllCreditTransacWithDropdownPurchase(string fromDate, string toDate, int partyID)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "\r\n                        select  \r\n                        --COALESCE(SD.vds_amount,0) vat,\r\n                        to_char(SM.date_challan,'DD/MM/YYYY') as Date,SM.challan_id,SM.organization_id\r\n                        --,I.item_name\r\n                        ,SM.challan_no,SM.date_challan,SM.party_id,P.party_name\r\n                        --,SM.payment_method,\r\n                        --SD.sd_rate,SD.Vat,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price\r\n                        ,SUM(SD.total_price) vatable_price,\r\n                        case when SUM(SD.vds_amount)>0 \r\n\t\t\t\t            then SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_sd)+SUM(SD.purchase_vat)\r\n\t\t\t\t        else\r\n                            SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_vat)+SUM(SD.purchase_sd) \r\n\t\t\t                end Total  \r\n                        ,case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id order by h.scroll_id desc limit 1) is null AND SUM(SD.vds_amount)>0\r\n\t\t            \t       then \r\n\t\t\t                (SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_sd)+SUM(SD.purchase_vat))-(SM.cash_amount+SM.bank_amount) \r\n                        when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id order by h.scroll_id desc limit 1) is null\r\n\t\t            \t    then \r\n\t\t\t                (SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_vat)+SUM(SD.purchase_sd))-(SM.cash_amount+SM.bank_amount)\r\n\t\t\t            else \r\n\t\t\t            (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id order by h.scroll_id desc limit 1)\r\n\t\t\t            end balance_due,SUM(SD.vds_amount) vds,'current' AS status,coalesce((select coalesce(h.amount_without_vds,0) from credit_transac_history h where h.challan_id=SM.challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1  ),0) amount_without_vds\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P   ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I ON SD.item_id = I.item_id\r\n                        where sd.approver_stage='F' and CAST(SM.date_challan AS DATE) >= to_date('", fromDate, "','dd/MM/yyyy')  and CAST(SM.date_challan AS DATE) <= to_date('", toDate, "','dd/MM/yyyy') AND SM.credit_amount > 0 AND SM.party_id=", partyID, " AND SM.organization_id=", num, "\r\n                         AND is_payment_finished = false group by Date,SM.challan_id,SM.organization_id,SM.challan_no,SM.date_challan,SM.party_id,P.party_name \r\n                        \r\n\t\t\t            UNION ALL\r\n\r\n\t\t\t            select  \r\n                        to_char(tpb.date_challan,'DD/MM/YYYY') as Date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name,\r\n\t\t\t            tpb.credit_amount as vatable_price, tpb.credit_amount as total, \r\n\t\t\t            case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  ", num, " order by h.scroll_id desc limit 1) is null \r\n\t\t            \t                then tpb.credit_amount\r\n\t\t\t            else (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  ", num, " order by h.scroll_id desc limit 1)\r\n\t\t\t                        end balance_due,\r\n\t\t\t            0 AS vds, 'current' AS status,0 amount_without_vds from trns_party_balance AS tpb\r\n\t\t\t            LEFT JOIN trns_party AS P  ON tpb.party_id = P.party_id\r\n\t\t\t            where CAST(tpb.date_challan AS DATE) >= to_date('", fromDate, "','dd/MM/yyyy')  and CAST(tpb.date_challan AS DATE) <= to_date('", toDate, "','dd/MM/yyyy') AND tpb.credit_amount > 0 AND tpb.party_id=", partyID, " AND tpb.organization_id = ", num, "  AND tpb.is_payment_finished = false and tpb.challan_type='P'\r\n                                    group by Date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name\r\n                        order by date_challan desc" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllCreditTransacWithDropdownPurchaseOLD(string fromDate, string toDate, int partyID)
        {
            object[] objArray = new object[] { "SELECT * FROM (\r\n        select A.*,B.current_balance,COALESCE(B.balance_due,Total) balance_due,B.payment_date,B.date_insert,COALESCE(b.payment_status,0) payment_status from \r\n\t                (\r\n                            select COALESCE(SD.vds_amount,0) vat,to_char(SM.date_challan,'DD/MM/YYYY') as Date,SM.challan_id,SM.organization_id,I.item_name,SM.challan_no,SM.date_challan,SM.party_id,P.party_name,SM.payment_method,\r\n                        SD.sd_rate,SD.Vat,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price,SD.total_price vatable_price,\r\n                        SD.Quantity * SD.purchase_unit_price AS Total from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.date_challan >= '", DateTime.ParseExact(fromDate, "dd/MM/yyyy", null), "'  and SM.date_challan <= '", DateTime.ParseExact(toDate, "dd/MM/yyyy", null), "' AND SM.party_id = ", partyID, " AND SM.payment_method = '13'" };
            string str = string.Concat(string.Concat(objArray), " \r\n        )A LEFT JOIN ( SELECT * FROM \r\n(\r\nselect * from \r\n(\r\n\tSELECT challan_no,max(scroll_id) as scroll_id,count(challan_no) count\r\n\tFROM credit_transac_history GROUP BY challan_no\r\n)A\r\nLEFT JOIN ( SELECT scroll_id,challan_id,challan_no,current_balance,balance_due,payment_date,date_insert,payment_status,status  \r\n\tFROM credit_transac_history ) B\r\n\tON\r\n\tA.scroll_id = B.scroll_id\r\n)C WHERE status = 'P'\r\n         )B  ON A.challan_id = B.challan_id \r\n)z where payment_status <> 1");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllCreditTransacWithoutDropdown(string fromDate, string toDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { "\r\n                        select to_char(SM.date_challan,'DD/MM/YYYY') date, SM.challan_id,SM.organization_id,SM.challan_no,SM.date_challan, SM.party_id,P.party_name, SM.total_bill_amount total,\r\n\t\t                case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id \r\n\t\t                order by h.scroll_id desc limit 1) is null \r\n\t\t\t\t                then (SM.total_bill_amount-(SM.cash_amount+SM.bank_amount))\r\n\t\t                else \r\n\t\t\t                   (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id order by h.scroll_id desc limit 1) end balance_due,\r\n                       coalesce( (select Sum(VAT) from trns_sale_detail where is_source_tax_deduct=true AND challan_id=SM.challan_id),0) vds,\r\n                        SUM(SD.quantity * SD.actual_price) baseprice ,SUM((SD.quantity * SD.actual_price) + SD.sd) vatablePrice,coalesce((select coalesce(h.amount_without_vds,0) from credit_transac_history h where h.challan_id=SM.challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1  ),0) amount_without_vds\r\n                        --,(select Sum(VAT) from trns_sale_detail where challan_id=SM.challan_id) vat\r\n                        \r\n                        from trns_sale_master AS SM \r\n                        LEFT JOIN trns_party AS P ON SM.party_id = P.party_id\r\n                        LEFT JOIN trns_sale_detail AS SD ON SM.challan_id = SD.challan_id\r\n                        where sd.approver_stage='F' and CAST(SM.date_challan AS DATE) >= to_date('", fromDate, "', 'dd/MM/yyyy')  and CAST(SM.date_challan AS DATE) <= to_date('", toDate, "', 'dd/MM/yyyy') AND SM.organization_id = ", num, " AND SM.is_payment_finished = false \r\n                        group by Date,SM.challan_id,SM.organization_id,SM.challan_no,SM.date_challan,SM.party_id,P.party_name\r\n                        UNION ALL\r\n\r\n                        select  \r\n                        to_char(tpb.date_challan,'DD/MM/YYYY') as date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name,\r\n\t\t\t            tpb.credit_amount as total,  \r\n\t\t\t            case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  1 order by h.scroll_id desc limit 1) is null \r\n\t\t            \t                then tpb.credit_amount\r\n\t\t\t            else (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  1 order by h.scroll_id desc limit 1)\r\n\t\t\t                        end balance_due,\r\n\t\t\t            0 AS vds, tpb.credit_amount as baseprice, tpb.credit_amount as vatable_price,0 amount_without_vds\r\n\t\t\t\t    from trns_party_balance AS tpb\r\n\t\t\t            LEFT JOIN trns_party AS P  ON tpb.party_id = P.party_id\r\n                        where CAST(tpb.date_challan AS DATE) >= to_date('", fromDate, "', 'dd/MM/yyyy')  and CAST(tpb.date_challan AS DATE) <= to_date('", toDate, "', 'dd/MM/yyyy') AND tpb.credit_amount > 0 AND tpb.organization_id = ", num, "  AND tpb.is_payment_finished = false and tpb.challan_type = 'R'\r\n                                    group by Date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name\r\n                        order by date_challan desc" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllCreditTransacWithoutDropdownOLD(string fromDate, string toDate)
        {
            object[] objArray = new object[] { "\r\nselect * from (\r\n                    select A.*,B.current_balance,COALESCE(B.balance_due,Total) balance_due,B.payment_date,B.date_insert,COALESCE(b.payment_status,0) payment_status from \r\n\t                (\r\n                        select COALESCE(SD.vat,0) vat,to_char(SM.date_challan,'DD/MM/YYYY') as Date,SM.challan_id,SM.organization_id,I.item_name,SM.challan_no,SM.date_challan,SM.party_id,P.party_name,SM.payment_method,\r\n                        SD.sd,SD.Vat,SD.Quantity,SD.actual_price,SD.Quantity * SD.actual_price + SD.sd + SD.Vat AS Total from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.date_challan >= '", DateTime.ParseExact(fromDate, "dd/MM/yyyy", null), "'  and SM.date_challan <= '", DateTime.ParseExact(toDate, "dd/MM/yyyy", null), "' AND SM.payment_method = '13'" };
            string str = string.Concat(string.Concat(objArray), " \r\n        )A LEFT JOIN ( \r\n            SELECT * FROM \r\n        (\r\n            select * from (\r\n\t            SELECT challan_no,max(scroll_id) as scroll_id,count(challan_no) count\r\n\t            FROM credit_transac_history GROUP BY challan_no\r\n        )A\r\n                LEFT JOIN ( SELECT payment_status,scroll_id,challan_id,challan_no,current_balance,balance_due,payment_date,date_insert,payment_status \r\n\t            FROM credit_transac_history ) B\r\n\t            ON\r\n\t            A.scroll_id = B.scroll_id\r\n        )C WHERE status = 'S' \r\n         )B  ON A.challan_id = B.challan_id\r\n)Z where payment_status <> 1");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllCreditTransacWithoutDropdownPurchase(string fromDate, string toDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { "\r\n                        select  \r\n                        --COALESCE(SD.vds_amount,0) vat,\r\n                        to_char(SM.date_challan,'DD/MM/YYYY') as Date,SM.challan_id,SM.organization_id\r\n                        --,I.item_name\r\n                        ,SM.challan_no,SM.date_challan,SM.party_id,P.party_name\r\n                        --,SM.payment_method,\r\n                        --SD.sd_rate,SD.Vat,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price\r\n                        ,SUM(SD.total_price) vatable_price,\r\n                        case when SUM(SD.vds_amount)>0 \r\n\t\t\t\t            then SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_sd)+SUM(SD.purchase_vat)\r\n\t\t\t\t        else\r\n                            SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_vat)+SUM(SD.purchase_sd) \r\n\t\t\t                end Total \r\n                        ,case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1) is null AND SUM(SD.vds_amount)>0\r\n\t\t            \t    then \r\n\t\t\t                (SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_sd))+SUM(SD.purchase_vat)-(SM.cash_amount+SM.bank_amount)\r\n                        when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1) is null \r\n\t\t            \t    then \r\n\t\t\t                (SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_vat)+SUM(SD.purchase_sd))-(SM.cash_amount+SM.bank_amount) \r\n\t\t\t            else \r\n\t\t\t            (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1)\r\n\t\t\t            end balance_due,SUM(SD.vds_amount) vds,'current' AS status,coalesce((select coalesce(h.amount_without_vds,0) from credit_transac_history h where h.challan_id=SM.challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1  ),0) amount_without_vds\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P  ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I ON SD.item_id = I.item_id\r\n                        where sd.approver_stage='F' and CAST(SM.date_challan AS DATE) >= to_date('", fromDate, "','dd/MM/yyyy')  and CAST(SM.date_challan AS DATE) <= to_date('", toDate, "','dd/MM/yyyy') AND SM.credit_amount > 0 AND SM.organization_id = ", num, " AND is_payment_finished = false group by Date,SM.challan_id,SM.organization_id,SM.challan_no,SM.date_challan,SM.party_id,P.party_name \r\n\r\n                        UNION ALL\r\n                        select  \r\n                        to_char(SM.date_challan,'DD/MM/YYYY') as Date,SM.prev_challan_id AS challan_id,SM.organization_id\r\n                        ,SM.challan_no,SM.date_challan,SM.party_id,P.party_name\r\n                        ,SUM(SD.total_price) vatable_price,\r\n                        case when SUM(SD.vds_amount)>0 \r\n\t\t\t\t            then SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_sd)+SUM(SD.purchase_vat)\r\n\t\t\t\t        else\r\n                            SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_vat)+SUM(SD.purchase_sd) \r\n\t\t\t                end Total \r\n                        ,case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.prev_challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1) is null AND SUM(SD.vds_amount)>0\r\n\t\t            \t    then \r\n\t\t\t                (SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_sd))+SUM(SD.purchase_vat)-(SM.cash_amount+SM.bank_amount)\r\n                        when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.prev_challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1) is null \r\n\t\t            \t    then \r\n\t\t\t                (SUM(SD.Quantity * SD.purchase_unit_price)+SUM(SD.purchase_vat)+SUM(SD.purchase_sd))-(SM.cash_amount+SM.bank_amount) \r\n\t\t\t            else \r\n\t\t\t            (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=SM.prev_challan_id AND h.organization_id = ", num, " order by h.scroll_id desc limit 1)\r\n\t\t\t            end balance_due,SUM(SD.vds_amount) vds,'Previous' AS status,0 amount_without_vds \r\n                        from prev_trns_purchase_master AS SM\r\n                        LEFT JOIN prev_trns_purchase_detail AS SD ON SM.prev_challan_id = SD.prev_challan_id\r\n                        LEFT JOIN trns_party AS P  ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I ON SD.item_id = I.item_id\r\n                        where CAST(SM.date_challan AS DATE) >= to_date('", fromDate, "','dd/MM/yyyy')  and CAST(SM.date_challan AS DATE) <= to_date('", toDate, "','dd/MM/yyyy') AND SM.credit_amount > 0 AND SM.organization_id = ", num, " AND is_payment_finished = false \r\n                        group by Date,SM.prev_challan_id,SM.organization_id,SM.challan_no,SM.date_challan,SM.party_id,P.party_name\r\n                        \r\n\t\t\t            UNION ALL\r\n\r\n\t\t\t            select  \r\n                        to_char(tpb.date_challan,'DD/MM/YYYY') as Date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name,\r\n\t\t\t            tpb.credit_amount as vatable_price, tpb.credit_amount as total, \r\n\t\t\t            case when (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  ", num, " order by h.scroll_id desc limit 1) is null \r\n\t\t            \t                then tpb.credit_amount\r\n\t\t\t            else (select coalesce(h.balance_due,0) from credit_transac_history h where h.challan_id=tpb.challan_id AND h.organization_id =  ", num, " order by h.scroll_id desc limit 1)\r\n\t\t\t                        end balance_due,\r\n\t\t\t            0 AS vds, 'current' AS status, 0 amount_without_vds  from trns_party_balance AS tpb\r\n\t\t\t            LEFT JOIN trns_party AS P  ON tpb.party_id = P.party_id\r\n\t\t\t            where CAST(tpb.date_challan AS DATE) >= to_date('", fromDate, "','dd/MM/yyyy')  and CAST(tpb.date_challan AS DATE) <= to_date('", toDate, "','dd/MM/yyyy') AND tpb.credit_amount > 0 AND tpb.organization_id = ", num, "  AND tpb.is_payment_finished = false and tpb.challan_type='P'\r\n                                    group by Date,tpb.challan_id,tpb.organization_id,tpb.challan_no,tpb.date_challan,tpb.party_id,P.party_name\r\n                        order by date_challan desc" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllCreditTransacWithoutDropdownPurchaseOLD(string fromDate, string toDate)
        {
            object[] objArray = new object[] { "\r\nSELECT * FROM (\r\n                            select A.*,B.current_balance,COALESCE(B.balance_due,Total) balance_due,B.payment_date,B.date_insert,COALESCE(b.payment_status,0) payment_status from\r\n\t                (\r\n                        select  COALESCE(SD.vds_amount,0) vat,to_char(SM.date_challan,'DD/MM/YYYY') as Date,SM.challan_id,SM.organization_id,I.item_name,SM.challan_no,SM.date_challan,SM.party_id,P.party_name,SM.payment_method,\r\n                        SD.sd_rate,SD.Vat,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price,SD.total_price vatable_price,\r\n                        SD.Quantity * SD.purchase_unit_price  AS Total from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.date_challan >= '", DateTime.ParseExact(fromDate, "dd/MM/yyyy", null), "'  and SM.date_challan <= '", DateTime.ParseExact(toDate, "dd/MM/yyyy", null), "' AND SM.payment_method = '13'" };
            string str = string.Concat(string.Concat(objArray), " \r\n        )A LEFT JOIN ( SELECT * FROM \r\n(\r\nselect * from \r\n(\r\n\tSELECT challan_no,max(scroll_id) as scroll_id,count(challan_no) count\r\n\tFROM credit_transac_history GROUP BY challan_no\r\n)A\r\nLEFT JOIN ( SELECT payment_status,scroll_id,challan_id,challan_no,current_balance,balance_due,payment_date,date_insert,payment_status\r\n\tFROM credit_transac_history ) B\r\n\tON\r\n\tA.scroll_id = B.scroll_id\r\n)C WHERE status = 'P'\r\n         )B  ON A.challan_id = B.challan_id \r\n)z where payment_status <> 1");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetDebitReturn(int challanNo)
        {
            string str = string.Concat("select COALESCE(Sum(quantity*actual_price),0) as ret_vatable_price, COALESCE(SUM(total_price),0) as ret_total_price, COALESCE(SUM(total_vat),0) ret_vat \r\n        from trns_note_detail where challan_id_purchase =", challanNo);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetInstallmentbyChallanId(int challanID)
        {
            string str = string.Concat("  select *,i.item_name,tpd.quantity from installment_scheduler isc \r\n                                inner join trns_sale_master tpm on isc.challan_id=tpm.challan_id\r\n                                inner join trns_sale_detail tpd on tpd.challan_id=tpm.challan_id\r\n                                inner join item i on i.item_id=tpd.item_id where isc.challan_id = ", challanID, " and isc.is_paid=false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPartyInfobyPartyId(int partyID)
        {
            string str = string.Concat("  select * from trns_party \r\n                                where party_id = ", partyID, " and is_deleted=false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchasePeriodicReport(int challanId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select TO_CHAR(tpm.date_challan,'dd-MON-yyyy') vouchar_date, tp.party_id supplier_id,tp.party_name supplier_name,\r\n                                   tpm.challan_no,tpd.item_id\r\n                                    ,(i.item_name \r\n                                    || ' ' || (CASE WHEN tpd.property_id1 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t                        inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t                        inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t                        where a.property_id1=tpd.property_id1 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                        || ' ' ||\r\n\t\t\t                        (CASE WHEN tpd.property_id2 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t                        inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t                        inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t                        where a.property_id2=tpd.property_id2 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                        || ' ' ||\r\n\t\t\t                        (CASE WHEN tpd.property_id3 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t                        inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t                        inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t                        where a.property_id3=tpd.property_id3 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                        || ' ' ||\r\n\t\t\t                        (CASE WHEN tpd.property_id4 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t                        inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t                        inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t                        where a.property_id4=tpd.property_id4 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                        || ' ' ||\r\n\t\t\t                        (CASE WHEN tpd.property_id5 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t                        inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t                        inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t                        where a.property_id5=tpd.property_id5 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                        ) AS item_name\r\n\r\n                                   ,tpd.quantity,tpd.purchase_unit_price unit_price,CAST((tpd.quantity*tpd.purchase_unit_price) as double precision) as value,\r\n                                   case when tpd.vds_amount>0 \r\n\t\t\t\t                    then (select sum(CAST((m.quantity*m.purchase_unit_price+m.purchase_sd) as double precision)) from trns_purchase_detail m where m.challan_id =", challanId, ")\r\n\t\t\t\t                    else\r\n                                   (select sum(CAST((m.quantity*m.purchase_unit_price+m.purchase_sd+m.purchase_vat) as double precision)) from trns_purchase_detail m where m.challan_id = ", challanId, ") end total,\r\n                                    tpd.purchase_vat vat, tpd.purchase_sd sd\r\n                                   from trns_purchase_master tpm\r\n                                   inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                   inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                   inner join item i on tpd.item_id = i.item_id\r\n                                   where tpm.challan_id = ", challanId, "\r\n\r\n\r\n                                   UNION ALL\r\n                                   select TO_CHAR(tpm.date_challan, 'dd-MON-yyyy') vouchar_date, tp.party_id supplier_id, tp.party_name supplier_name,\r\n                                   tpm.challan_no,tpd.item_id\r\n                                    ,(i.item_name\r\n                                    || ' ' || (CASE WHEN tpd.property_id1 > 0 THEN(select c.property_name from prev_trns_purchase_detail a\r\n                                    inner join prev_trns_purchase_master b on a.prev_challan_id = b.prev_challan_id\r\n                                    inner join item_property c on a.property_id1 = c.property_id\r\n                                    where a.property_id1 = tpd.property_id1 and b.prev_challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n                                    || ' ' ||\r\n                                    (CASE WHEN tpd.property_id2 > 0 THEN(select c.property_name from prev_trns_purchase_detail a\r\n                                    inner join prev_trns_purchase_master b on a.prev_challan_id = b.prev_challan_id\r\n                                    inner join item_property c on a.property_id2 = c.property_id\r\n                                    where a.property_id2 = tpd.property_id2 and b.prev_challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n                                    || ' ' ||\r\n                                    (CASE WHEN tpd.property_id3 > 0 THEN(select c.property_name from prev_trns_purchase_detail a\r\n                                    inner join prev_trns_purchase_master b on a.prev_challan_id = b.prev_challan_id\r\n                                    inner join item_property c on a.property_id3 = c.property_id                                                     \r\n                                    where a.property_id3 = tpd.property_id3 and b.prev_challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n                                    || ' ' ||\r\n                                    (CASE WHEN tpd.property_id4 > 0 THEN(select c.property_name from prev_trns_purchase_detail a\r\n                                    inner  join prev_trns_purchase_master b on a.prev_challan_id = b.prev_challan_id\r\n                                    inner join item_property c on a.property_id3 = c.property_id\r\n                                    where a.property_id4 = tpd.property_id4 and b.prev_challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n                                    || ' ' ||\r\n                                    (CASE WHEN tpd.property_id5 > 0 THEN(select c.property_name from prev_trns_purchase_detail a\r\n                                    inner join prev_trns_purchase_master b on a.prev_challan_id = b.prev_challan_id\r\n                                    inner join item_property c on a.property_id3 = c.property_id                                                          \r\n                                    where a.property_id5 = tpd.property_id5 and b.prev_challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                        ) AS item_name\r\n\r\n                                   ,tpd.quantity,tpd.purchase_unit_price unit_price, CAST((tpd.quantity * tpd.purchase_unit_price) as double precision) as value,\r\n                                   case when tpd.vds_amount>0 \r\n\t\t\t\t                        then (select sum(CAST((m.quantity * m.purchase_unit_price + m.purchase_sd) as double precision)) from prev_trns_purchase_detail m where m.prev_challan_id = 1) \r\n\t\t\t\t                        else (select sum(CAST((m.quantity * m.purchase_unit_price + m.purchase_sd + m.purchase_vat) as double precision)) from prev_trns_purchase_detail m where m.prev_challan_id = 1) end total,\r\n                                    tpd.purchase_vat vat, tpd.purchase_sd sd\r\n                                   from prev_trns_purchase_master tpm\r\n                                   inner join prev_trns_purchase_detail tpd on tpm.prev_challan_id = tpd.prev_challan_id\r\n                                   inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                   inner join item i on tpd.item_id = i.item_id\r\n                                   where tpm.prev_challan_id =  ", challanId };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPurchasePeriodicReportData(int challanId)
        {
            object[] objArray = new object[] { "select TO_CHAR(tpm.date_challan,'dd-MON-yyyy') vouchar_date, tp.party_id supplier_id,tp.party_name supplier_name,\r\n                                   tpm.challan_no,tpd.item_id,i.item_name,\r\n                                   tpd.quantity,tpd.purchase_unit_price unit_price,CAST((tpd.quantity*tpd.purchase_unit_price) as double precision) as value,\r\n                                   (select sum(CAST((m.quantity*m.purchase_unit_price) as double precision)) from trns_purchase_detail m where m.challan_id = ", challanId, ")  total,\r\n                                    tpd.purchase_vat vat, tpd.purchase_sd sd\r\n                                   from trns_purchase_master tpm\r\n                                   inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                   inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                   inner join item i on tpd.item_id = i.item_id\r\n                                   where tpm.challan_id = ", challanId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetSalesPeriodicReportData(int challanId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select TO_CHAR(tsm.date_challan,'dd-MON-yyyy') vouchar_date, tp.party_id supplier_id,tp.party_name supplier_name,\r\n                               tsm.challan_no,tsd.item_id\r\n                               --,i.item_name\r\n\r\n                                ,(i.item_name \r\n                                || ' ' || (CASE WHEN tsd.property_id1 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t                    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t                    inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t                    where a.property_id1=tsd.property_id1 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                    || ' ' ||\r\n\t\t\t                    (CASE WHEN tsd.property_id2 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t                    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t                    inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t                    where a.property_id2=tsd.property_id2 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                    || ' ' ||\r\n\t\t\t                    (CASE WHEN tsd.property_id3 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t                    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t                    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t                    where a.property_id3=tsd.property_id3 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                    || ' ' ||\r\n\t\t\t                    (CASE WHEN tsd.property_id4 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t                    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t                    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t                    where a.property_id4=tsd.property_id4 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                    || ' ' ||\r\n\t\t\t                    (CASE WHEN tsd.property_id5 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t                    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t                    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t                    where a.property_id5=tsd.property_id5 and b.challan_id = ", challanId, " LIMIT 1) ELSE '' END)\r\n\t\t\t                    ) AS item_name\r\n\r\n                               ,tsd.quantity,tsd.actual_price unit_price,CAST((tsd.quantity*tsd.actual_price) as double precision) as value,\r\n                               (select sum(CAST((m.quantity*m.actual_price+m.sd+m.vat) as double precision)) from trns_sale_detail m where m.challan_id = ", challanId, ")  total,tsd.vat vat,tsd.sd sd\r\n                               from trns_sale_master tsm\r\n                               inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               where tsm.challan_id = ", challanId };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetTransectionByChallanId(string tableName, int challanId)
        {
            string str = "";
            string str1 = tableName;
            string str2 = str1;
            if (str1 != null)
            {
                if (str2 == "purchase_master")
                {
                    str = string.Concat("select * from trns_purchase_master where challan_id = ", challanId);
                }
                else if (str2 == "purchase_detail")
                {
                    str = string.Concat("select * from trns_purchase_detail where challan_id = ", challanId);
                }
                else if (str2 == "sale_master")
                {
                    str = string.Concat("select * from trns_sale_master where challan_id = ", challanId);
                }
                else if (str2 == "sale_detail")
                {
                    str = string.Concat("select * from trns_sale_detail where challan_id = ", challanId);
                }
            }
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetVDS(int itemId, int challanID)
        {
            object[] objArray = new object[] { "select purchase_vat,vat_rate from trns_purchase_detail where item_id = ", itemId, " and challan_id=", challanID, " and vat_rate!=15" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetVDSAmount(int itemId, int challanID)
        {
            object[] objArray = new object[] { "select coalesce(sum(purchase_vat-(select COALESCE(SUM(total_vat),0) from trns_note_detail where challan_id_purchase=", challanID, ")),0) as purchase_vat,\r\n       coalesce(sum(vds_amount-(select COALESCE(SUM(total_vat),0) from trns_note_detail where challan_id_purchase=", challanID, ")),0) as vds_amount \r\n        from trns_purchase_detail where challan_id=", challanID, " and vds_amount>0" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }
    }
}

