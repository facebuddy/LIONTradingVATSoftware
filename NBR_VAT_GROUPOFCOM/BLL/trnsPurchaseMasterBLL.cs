using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class trnsPurchaseMasterBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility db = new DBUtility();

        public trnsPurchaseMasterBLL()
        {
        }

        public DataTable GetLastPurchase_unitId(DateTime fromDate, DateTime toDate, long itemID, int branchID)
        {
            string str = "";
            string str1 = "";
            if (itemID > (long)0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            string[] strArrays = new string[] { "select d.unit_id,ui.unit_code,m.date_challan,d.quantity,d.lot_no,d.purchase_unit_price from trns_purchase_detail d \r\n                          inner join trns_purchase_master m on d.Challan_id = m.Challan_id                         \r\n                          inner join Item i on i.item_id = d.item_id\r\n                          inner join  item_unit ui on ui.unit_id=d.unit_id              \r\n                          where m.date_challan <=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') ", str, "   AND d.Is_deleted = false  order by m.date_challan desc" };
            str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public long GetEarlyAvailableStock(string toDate, int itemID, int branchID)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = ", itemID);
            }
            if (branchID > 0)
            {
                str1 = string.Concat("AND m.org_branch_reg_id=", branchID);
            }
            string[] strArrays = new string[] { "\r\n                    select distinct\r\n                    ((select case when sum(d.Quantity) is null then 0 else sum(d.Quantity) end  \r\n                    from trns_purchase_detail as d\r\n                    inner join trns_purchase_master as m \r\n                    on d.challan_id = m.challan_id\r\n                    where d.date_insert >='2010-01-01' AND d.date_insert <= '", toDate, "' ", str, " ", str1, ")\r\n                                                -\r\n                    ((select case when sum(d.Quantity) is null then 0 else sum(d.Quantity) end  \r\n                    from trns_sale_detail as d \r\n                    inner join trns_sale_master as m\r\n                    on d.challan_id = m.challan_id\r\n                    where d.date_insert >='2010-01-01' AND d.date_insert <= '", toDate, "' ", str, " ", str1, ")\r\n                                                + \r\n                     (select case when sum(Quantity) is null then 0 else sum(Quantity) end \r\n                     from trns_production_detail as d\r\n                     inner join trns_production_master as m\r\n                     on d.production_id = m.production_id\r\n                     where d.date_insert >='2010-01-01' AND d.date_insert <= '", toDate, "' and d.status in('I','S') ", str, " ", str1, "))\r\n                                                -\r\n                    (select case when sum(d.Quantity) is null then 0 else sum(d.Quantity) end \r\n                     from trns_transfer_detail as d\r\n                     inner join trns_transfer_master as m\r\n                     on d.transfer_id = m.transfer_id\r\n                     where d.date_insert >='2010-01-01' AND d.date_insert <= '", toDate, "' and m.transfer_status = 'I' ", str, " ", str1, ")\r\n\r\n                    ) as earlyAvailableStock\r\n                    from trns_purchase_detail" };
            string str2 = string.Concat(strArrays);
            return Convert.ToInt64(this.DBUtil.GetSingleValue(str2));
        }

        public decimal GetEarlyAvailableStock621(string fromDate, int itemID, int branchID)
        {
            if (itemID > 0)
            {
                string.Concat(" AND d.item_id = ", itemID);
            }
            if (branchID > 0)
            {
                string.Concat("AND m.org_branch_reg_id=", branchID);
            }
            object[] objArray = new object[] { "select distinct\r\n                    (\r\n\t\t    --purchase\r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  \r\n                    from trns_purchase_detail as d\r\n                    inner join trns_purchase_master as m \r\n                    on d.challan_id = m.challan_id\r\n                    where  CAST(m.date_challan AS DATE) <= to_date('", fromDate, "','dd/MM/yyyy') AND d.item_id = ", itemID, ")\r\n                   \r\n                    -\r\n                    --sale\r\n                    ((select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_sale_detail as d inner join trns_sale_master as m\r\n                                   \r\n                    on d.challan_id = m.challan_id\r\n                    where CAST(m.date_challan AS DATE) <= to_date('", fromDate, "','dd/MM/yyyy') AND d.item_id = ", itemID, " ) \r\n                      \r\n                    + \r\n                    --Debit\r\n                    (\r\n\t\t     select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t     where CAST(m.date_note AS DATE) <= to_date('", fromDate, "','dd/MM/yyyy') AND m.note_type='D' AND d.item_id=", itemID, "\r\n                    )\r\n                    +\r\n                    --Transfer\r\n                    (\r\n\t\t     select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t     where CAST(m.issues_date AS DATE) <= to_date('", fromDate, "','dd/MM/yyyy') AND m.transfer_status = 'I' AND d.item_id=", itemID, "\r\n                    ))\r\n                    +\r\n                    --credit\r\n                    (\r\n\t\t\t select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t     where CAST(m.date_note AS DATE) <= to_date('", fromDate, "','dd/MM/yyyy') AND m.note_type='C' AND d.item_id=", itemID, "\r\n                    )\r\n                                   \r\n\r\n                    ) as earlyAvailableStock\r\n                    from trns_purchase_detail" };
            string str = string.Concat(objArray);
            return Convert.ToDecimal(this.db.GetSingleValue(str));
        }

        public DataTable GetEarlyAvailableStockNew(DateTime fDate, DateTime tDate, int itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select item_qty ,item_value,opening_balance_date from opening_balance where item_id=", itemID, "  AND  organization_id= ", num, " AND org_branch_reg_id = ", num1, " and CAST(opening_balance_date AS DATE)>= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')  and CAST(opening_balance_date AS DATE)<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetEarlyAvailableStockPrevDate(DateTime fromDate, DateTime toDate, int itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] str = new object[] { "\r\n                    select distinct '-' as serial_1,'-' as date_2,\r\n                    (\r\n\t\t           --purchase\r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_purchase_detail as d inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                    where  CAST(m.date_challan AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, "  and d.approver_stage='F' and challan_type not in ('D','Cr') AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, ")\r\n                    -\r\n                    --sale\r\n                    ((select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_sale_detail as d inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                     where CAST(m.date_challan AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, "  and d.approver_stage='F' AND  m.organization_id= ", num, "  AND M.org_branch_reg_id = ", num1, ")     \r\n                    + \r\n                    --Debit\r\n                    (\r\n\t\t             select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t             where CAST(m.date_note AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='D' AND d.item_id=", itemID, " AND  m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n                    --Transfer Issue\r\n                    (\r\n\t\t            select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t            where CAST(m.issues_date AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'I' AND d.item_id=", itemID, " AND m.organization_id= ", num, " AND  m.organization_id= ", num, "\r\n                    )+\r\n                     (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_production_detail as d inner join trns_production_master as m on d.production_id = m.production_id\r\n                    where  CAST(m.date_production AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, " AND m.organization_id= ", num, "  and m.trns_status='R' AND M.org_branch_reg_id = ", num1, ")\r\n\r\n                  --gift\r\n                    +\r\n                     (select coalesce(sum(gd.quantity),0) from gift_items_detail gd  where  CAST(gd.date_consumable_challan  AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and gd.item_id= ", itemID, "  AND organization_id=", num, "  AND \r\n                     org_branch_id=", num1, " AND gd.is_deleted=false))\r\n                    +\r\n                    --credit\r\n                    (\r\n\t                select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t            where CAST(m.date_note AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='C' AND d.item_id=", itemID, " AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n\t\t            --Transfer Receive\r\n\t\t            (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t             where CAST(m.issues_date AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'R' AND d.item_id=", itemID, " AND m.organization_id= ", num, " AND M.receiving_branch_id = ", num1, ")                        \r\n                    ) as prarombik_jer_poriman_3\r\n                    ,\r\n                    (\r\n\t\t           --purchase\r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.purchase_unit_price) end from trns_purchase_detail as d inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                    where  CAST(m.date_challan AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, " and d.approver_stage='F' and challan_type not in ('D','Cr') AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, ")\r\n                    -\r\n                    --sale\r\n                    ((select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.actual_price) end from trns_sale_detail as d inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                     where CAST(m.date_challan AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, " and d.approver_stage='F' AND  m.organization_id= ", num, "  AND M.org_branch_reg_id = ", num1, ")     \r\n                    + \r\n                    --Debit\r\n                    (\r\n\t\t             select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.actual_price) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t             where CAST(m.date_note AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='D' AND d.item_id=", itemID, " AND  m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n                    --Transfer Issue\r\n                    (\r\n\t\t            select case when sum(d.quantity) is null then 0 else 0 end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t            where CAST(m.issues_date AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'I' AND d.item_id=", itemID, " AND m.organization_id= ", num, "  AND M.issuing_branch_id = ", num1, "\r\n                    )\r\n                     +\r\n                   \r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity*(select purchase_unit_price from trns_purchase_detail pd where pd.item_id= ", itemID, " limit 1)) end from trns_production_detail as d inner join trns_production_master as m on d.production_id = m.production_id\r\n                    where  CAST(m.date_production AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, " AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "  and m.trns_status='R')\r\n                    )\r\n                    +\r\n                    --credit\r\n                    (\r\n\t                select case when sum(d.quantity) is null then 0 else sum(d.quantity*d.actual_price) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t            where CAST(m.date_note AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='C' AND d.item_id=", itemID, " AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "\r\n                    )\r\n                    +\r\n\t\t            --Transfer Receive\r\n\t\t            (select case when sum(d.quantity) is null then 0 else 0 end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t             where CAST(m.issues_date AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'R' AND d.item_id=", itemID, " AND m.organization_id= ", num, " AND M.receiving_branch_id = ", num1, ")                        \r\n                    ) as prarombik_jer_mullo_4\r\n\t                ,iu.unit_code\r\n                              \r\n                   from trns_purchase_detail\r\n                   inner join item_unit iu on iu.unit_id=trns_purchase_detail.unit_id where trns_purchase_detail.item_id=", itemID };
            string str1 = string.Concat(str);
            return this.DBUtil.GetDataTable(str1);
        }

        public long GetEarlyTotalItem(int itemID, DateTime balanceDate, DateTime fdate)
        {
            object[] objArray = new object[] { "select COALESCE(SUM(quantity),0)  from trns_purchase_detail \r\n                        where item_id =", itemID, "  Date_insert >= TO_DATE('", balanceDate, "','dd/MM/yyyy') AND Date_insert <= To_Date('", fdate, "','dd/MM/yyyy')" };
            string str = string.Concat(objArray);
            return Convert.ToInt64(this.DBUtil.GetSingleValue(str));
        }

        public long GetEarlytotalProdution(int itemID, DateTime balanceDate, DateTime fdate)
        {
            object[] objArray = new object[] { "select COALESCE(SUM(quantity),0) from trns_production_detail \r\n                        where item_id =", itemID, " Date_insert >= TO_DATE('", balanceDate, "','dd/MM/yyyy') AND Date_insert <= To_Date('", fdate, "','dd/MM/yyyy')" };
            string str = string.Concat(objArray);
            return Convert.ToInt64(this.DBUtil.GetSingleValue(str));
        }

        public DataSet getItemInfoForStock(short challanId, short itemId)
        {
            object[] objArray = new object[] { "SELECT tpd.Quantity, tpd.purchase_unit_price actual_price, tpd.Vat, tpd.detail_id, \r\n                tpd.lot_no LotNo, iu.unit_id UnitId, iu.unit_code uname,coalesce(tpd.vat_rate,0) vat_rate,coalesce(tpd.sd_rate,0) sd_rate \r\n        FROM trns_purchase_detail tpd \r\n        INNER JOIN item_unit iu on tpd.unit_id=iu.unit_id\r\n        WHERE tpd.Is_deleted=false and tpd.Challan_id=", challanId, " and tpd.Item_id=", itemId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "ItemStockInfo");
        }

        public DataTable GetItemlastLotInfo(long itemID)
        {
            if (itemID > 0)
            {
                string.Concat("item_id = '", itemID, "'");
            }
            string str = string.Concat("select unit_id,quantity,available_qnt,lot_no,lot_no_status,purchase_unit_price\r\n                     from trns_purchase_detail where item_id=", itemID, " ORDER BY lot_no desc");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetEarlyAvailableStocOpening(DateTime fDate, long itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select item_qty ,item_value,opening_balance_date from opening_balance where item_id=", itemID, "  AND  organization_id= ", num, " AND org_branch_reg_id = ", num1, " and CAST(opening_balance_date AS DATE)<= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        //public DataTable PurchaseAccountingBookPrevious(DateTime fromDate, long itemID, string branchIds)
        //{
        //    string str = "";
        //    string str1 = "";
        //    if (itemID > (long)0)
        //    {
        //        str = string.Concat(" AND d.item_id = '", itemID, "'");
        //    }
        //    int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
        //    object[] objArray = new object[] { "select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no, o.organization_name , o.registration_no ,case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy') else  to_char(m.ref_challan_date, 'dd/MM/yyyy') end  as Date, d.Quantity,\r\n\t           d.lot_no,m.Date_CHALLAN challan_date, d.quantity* d.purchase_unit_price price, d.purchase_sd sd, d.purchase_vat vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                                0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,d.Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                                tp.party_address,i.item_name,iu.unit_code\r\n                                from trns_purchase_master m\r\n                                inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                                inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                                inner join Item i on i.item_id = d.item_id \r\n                                inner join item_unit iu on iu.unit_id=i.unit_id                   \r\n                                left join trns_party tp on tp.party_id = m.party_id\r\n                                where cast (m.date_challan as Date) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                                ", str, "    AND d.Is_deleted = false and m.approver_stage='F' and m.challan_type='P' AND m.organization_id= ", num, " AND M.org_branch_reg_id in(", branchIds, ")\r\n \r\n                  UNION ALL\r\n                            select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no , '--' organization_name ,'--' registration_no ,case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy') else  to_char(m.Date_CHALLAN, 'dd/MM/yyyy') end  as Date, d.Quantity,\r\n\t                        d.lot_no,m.Date_CHALLAN challan_date, d.quantity* d.purchase_unit_price price, d.purchase_sd sd, d.purchase_vat vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,d.Quantity debit_quantity, d.quantity* d.purchase_unit_price debit_price,\r\n                            0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,'Debit' Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                            tp.party_address,i.item_name,iu.unit_code\r\n                            from trns_purchase_master m                           \r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id=i.unit_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                            where cast (m.date_challan as Date) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                             ", str, "    AND d.Is_deleted = false and m.challan_type ='D'  and m.approver_stage='F' AND m.organization_id= ", num, " AND M.org_branch_reg_id in(", branchIds, ")\r\n\r\n          UNION ALL\r\n                            select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no , '--' organization_name ,'--' registration_no ,case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy') else  to_char(m.Date_CHALLAN, 'dd/MM/yyyy') end  as Date, d.Quantity,\r\n\t                        d.lot_no,m.Date_CHALLAN challan_date, d.quantity* d.purchase_unit_price price, d.purchase_sd sd, d.purchase_vat vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,d.Quantity debit_quantity, d.quantity* d.purchase_unit_price debit_price,\r\n                            0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,'Credit' Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                            tp.party_address,i.item_name,iu.unit_code\r\n                            from trns_purchase_master m                           \r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id=i.unit_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                            where cast (m.date_challan as Date) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                             ", str, "    AND d.Is_deleted = false and m.challan_type ='Cr'  and m.approver_stage='F' AND m.organization_id= ", num, " AND M.org_branch_reg_id in(", branchIds, ")\r\n\r\n                 UNION ALL\r\n                             select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no,'--' organization_name ,'--' registration_no ,  to_char(m.Date_CHALLAN, 'dd/MM/yyyy') as Date, d.Quantity,\r\n                             0 lot_no,m.Date_CHALLAN challan_date,d.quantity* d.current_price  price, 0 sd, 0 vat,d.quantity dispose_quantity,d.quantity* d.current_price dispose_price, d.sd dispose_sd, d.vat dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                             0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,(select code_name from app_code_detail where m.challan_page_discard_reason_m=code_id_m and m.challan_page_discard_reason_d=code_id_d)as Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                             tp.party_address,i.item_name,iu.unit_code\r\n                             from trns_sale_master m\r\n                             inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                             inner join Item i on i.item_id = d.item_id\r\n                             inner join item_unit iu on iu.unit_id=i.unit_id\r\n                             left join trns_party tp on tp.party_id = m.party_id\r\n                             where cast (m.date_challan as Date) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                            ", str, "    AND d.Is_deleted = false  and m.approver_stage='F' and m.challan_type='D' AND m.organization_id= ", num, " AND M.org_branch_reg_id in(", branchIds, ")\r\n\r\nUNION ALL\r\n                             select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no,'--' organization_name ,'--' registration_no ,  to_char(m.Date_CHALLAN, 'dd/MM/yyyy') as Date, d.Quantity,\r\n                             0 lot_no,m.Date_CHALLAN challan_date,d.quantity* d.actual_price  price,  d.sd, d.vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                             0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,'Direct Sale' as Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                             tp.party_address,i.item_name,iu.unit_code\r\n                             from trns_sale_master m\r\n                             inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                             inner join Item i on i.item_id = d.item_id\r\n                             inner join item_unit iu on iu.unit_id=i.unit_id\r\n                             left join trns_party tp on tp.party_id = m.party_id\r\n                             where cast (m.date_challan as Date) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                            ", str, "    AND d.Is_deleted = false  and m.approver_stage='F' and m.challan_type='S' AND m.organization_id= ", num, " AND M.org_branch_reg_id in(", branchIds, ")\r\n\r\n\r\n                UNION ALL\r\n                            (select 'P' status,d.production_id,0 org_branch_reg_id, '--' challan_no,'--' organization_name ,'--' registration_no , to_char(m.Date_Production, 'dd/MM/yyyy') as Date,0 Quantity,0 lot_no,m.Date_Production challan_date,\r\n\t                        0 price,0 sd, 0 vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n\t                        COALESCE(d.Quantity, '0') as production_Qty,\t          \r\n\t       \t               -- (select purchase_unit_price from trns_purchase_detail pd where pd.item_id= ", itemID, " limit 1) \r\n                            d.unit_price purchase_unit_price, d.unit_id,\r\n\t                        to_char(d.date_insert, 'dd/MM/yyyy') as prdDate,\r\n                            '--' Remarks,'--' party_name ,'--' party_bin ,d.Date_insert, '--'party_address,'--'item_name,iu.unit_code\r\n                            from trns_production_detail d              \r\n                            inner join trns_production_master m on d.production_id = m.production_id     \r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id=i.unit_id\r\n                            where cast (m.Date_Production as Date) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                                         ", str, "  AND d.Is_deleted = false AND d.status = 'R' AND m.organization_id= ", num, " AND M.org_branch_reg_id in(", branchIds, ") order by m.Date_Production) \r\n             UNION ALL\r\n                             \r\n                            (select 'P' status,0 production_id,0 org_branch_reg_id, '--' challan_no,'--' organization_name ,'--' registration_no , to_char(d.date_consumable_challan, 'dd/MM/yyyy') as Date,0 Quantity,0 lot_no,d.date_consumable_challan challan_date,\r\n\t                        0 price,0 sd, 0 vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n\t                        COALESCE(d.Quantity, '0') as production_Qty,\t          \r\n\t       \t               -- (select purchase_unit_price from trns_purchase_detail pd where pd.item_id= 2702 limit 1) \r\n                            d.price/d.quantity purchase_unit_price, d.unit_id,\r\n\t                        to_char(d.date_insert, 'dd/MM/yyyy') as prdDate,\r\n                            d.remarks Remarks,'--' party_name ,'--' party_bin ,d.Date_insert, '--'party_address,'--'item_name,iu.unit_code\r\n                            from gift_items_detail d   \r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id=i.unit_id\r\n                            where cast (d.date_consumable_challan as Date) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                            ", str, "  AND d.Is_deleted = false AND d.organization_id= ", num, " AND d.org_branch_id in(", branchIds, "))\r\n\r\n            union All \r\n                            select 'P' status,0 production_id,m.receiving_branch_id, m.challan_no As challan_no, o.organization_name , o.registration_no ,\r\n                            to_char(issues_date, 'dd/MM/yyyy')  as Date, d.Quantity,\r\n\t                          0 lot_no,m.issues_date challan_date, d.quantity* d.unit_price price, coalesce(d.sd_amount,0) sd, coalesce(d.vat_amount,0) vat,0 dispose_quantity,0 dispose_price, \r\n\t                         0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                                0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,d.Remarks,\r\n                                branch_unit_name party_name ,ob.branch_unit_bin party_bin ,d.Date_insert,\r\n                                ob.org_branch_address party_address,i.item_name,iu.unit_code\r\n                                from trns_transfer_master m\r\n                                inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                                inner join org_branch_reg_info ob on m.receiving_branch_id = ob.org_branch_reg_id\r\n                                inner join trns_transfer_detail d on d.transfer_id = m.transfer_id\r\n                                inner join Item i on i.item_id = d.item_id \r\n                                inner join item_unit iu on iu.unit_id=i.unit_id                   \r\n                                \r\n                                 where  m.transfer_status='R' ", str, " AND m.organization_id= ", num, " AND m.receiving_branch_id in(", branchIds, ")\r\n                            and CAST(m.issues_date AS DATE) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n\r\n\r\n            union All \r\n                            select 'P' status,0 production_id,m.issuing_branch_id, m.challan_no As challan_no, o.organization_name , o.registration_no ,\r\n                                to_char(issues_date, 'dd/MM/yyyy')  as Date, 0 Quantity,\r\n\t                           0 lot_no,m.issues_date challan_date, 0 price, 0 sd, 0 vat,0 dispose_quantity,0 dispose_price, \r\n\t                         0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                               d.Quantity production_Qty,d.quantity* d.unit_price price ,0 unit_id,'--' prdDate,d.Remarks,\r\n                                branch_unit_name party_name ,ob.branch_unit_bin party_bin ,d.Date_insert,\r\n                                ob.org_branch_address party_address,i.item_name,iu.unit_code\r\n                                from trns_transfer_master m\r\n                                inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                                inner join org_branch_reg_info ob on m.issuing_branch_id = ob.org_branch_reg_id\r\n                                inner join trns_transfer_detail d on d.transfer_id = m.transfer_id\r\n                                inner join Item i on i.item_id = d.item_id \r\n                                inner join item_unit iu on iu.unit_id=i.unit_id                   \r\n                                \r\n                                 where m.transfer_status='I' ", str, " AND m.organization_id= ", num, " AND m.issuing_branch_id in(", branchIds, ")\r\n                            and CAST(m.issues_date AS DATE) <= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n\r\n                            order by challan_date" };
        //    str1 = string.Concat(objArray);
        //    return this.DBUtil.GetDataTable(str1);
        //}


        public DataTable PurchaseAccountingBookPrevious(DateTime fromDate, long itemID, string branchIds)
        {
            string query;
            string itemFilter = "";

            if (itemID > 0)
            {
                // item_id numeric, তাই কোটেশন ছাড়াই ব্যবহার করা নিরাপদ
                itemFilter = $" AND d.item_id = {itemID}";
            }

            int orgId = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            string dateStr = fromDate.ToString("dd/MM/yyyy");

            query = $@"
select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no, 
       o.organization_name , o.registration_no ,
       case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy') 
            else to_char(m.ref_challan_date, 'dd/MM/yyyy') end as Date,
       d.Quantity,
       d.lot_no,
       m.date_challan challan_date,
       d.quantity * d.purchase_unit_price price,
       d.purchase_sd sd,
       d.purchase_vat vat,
       0 dispose_quantity,
       0 dispose_price,
       0 dispose_sd,
       0 dispose_sd_vat,
       0 debit_quantity,
       0 debit_price,
       0 production_Qty,
       0 purchase_unit_price,
       0 unit_id,
       '--' prdDate,
       d.Remarks,
       tp.party_name,
       tp.party_bin,
       d.date_insert,
       tp.party_address,
       i.item_name,
       iu.unit_code
from trns_purchase_master m
inner join org_registration_info o on m.organization_id = o.organization_id
inner join trns_purchase_detail d on d.challan_id = m.challan_id
inner join item i on i.item_id = d.item_id
inner join item_unit iu on iu.unit_id = i.unit_id
left  join trns_party tp on tp.party_id = m.party_id
where cast(m.date_challan as date) <= to_date('{dateStr}', 'dd/MM/yyyy')
      {itemFilter}
      AND d.is_deleted = false 
      and m.challan_type = 'P'
      AND m.organization_id = {orgId}
      AND m.org_branch_reg_id in ({branchIds})

UNION ALL

select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no, 
       '--' organization_name ,'--' registration_no ,
       case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy')
            else to_char(m.date_challan, 'dd/MM/yyyy') end as Date,
       d.Quantity,
       d.lot_no,
       m.date_challan challan_date,
       d.quantity * d.purchase_unit_price price,
       d.purchase_sd sd,
       d.purchase_vat vat,
       0 dispose_quantity,
       0 dispose_price,
       0 dispose_sd,
       0 dispose_sd_vat,
       d.quantity debit_quantity,
       d.quantity * d.purchase_unit_price debit_price,
       0 production_Qty,
       0 purchase_unit_price,
       0 unit_id,
       '--' prdDate,
       'Debit' Remarks,
       tp.party_name,
       tp.party_bin,
       d.date_insert,
       tp.party_address,
       i.item_name,
       iu.unit_code
from trns_purchase_master m
inner join trns_purchase_detail d on d.challan_id = m.challan_id
inner join item i on i.item_id = d.item_id
inner join item_unit iu on iu.unit_id = i.unit_id
left  join trns_party tp on tp.party_id = m.party_id
where cast(m.date_challan as date) <= to_date('{dateStr}', 'dd/MM/yyyy')
      {itemFilter}
      AND d.is_deleted = false 
      and m.challan_type = 'D'
      AND m.organization_id = {orgId}
      AND m.org_branch_reg_id in ({branchIds})

UNION ALL

select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no, 
       '--' organization_name ,'--' registration_no ,
       case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy')
            else to_char(m.date_challan, 'dd/MM/yyyy') end as Date,
       d.Quantity,
       d.lot_no,
       m.date_challan challan_date,
       d.quantity * d.purchase_unit_price price,
       d.purchase_sd sd,
       d.purchase_vat vat,
       0 dispose_quantity,
       0 dispose_price,
       0 dispose_sd,
       0 dispose_sd_vat,
       d.quantity debit_quantity,
       d.quantity * d.purchase_unit_price debit_price,
       0 production_Qty,
       0 purchase_unit_price,
       0 unit_id,
       '--' prdDate,
       'Credit' Remarks,
       tp.party_name,
       tp.party_bin,
       d.date_insert,
       tp.party_address,
       i.item_name,
       iu.unit_code
from trns_purchase_master m
inner join trns_purchase_detail d on d.challan_id = m.challan_id
inner join item i on i.item_id = d.item_id
inner join item_unit iu on iu.unit_id = i.unit_id
left  join trns_party tp on tp.party_id = m.party_id
where cast(m.date_challan as date) <= to_date('{dateStr}', 'dd/MM/yyyy')
      {itemFilter}
      AND d.is_deleted = false 
      and m.challan_type = 'Cr'
      AND m.organization_id = {orgId}
      AND m.org_branch_reg_id in ({branchIds})

UNION ALL

select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no,
       '--' organization_name ,'--' registration_no,
       to_char(m.date_challan, 'dd/MM/yyyy') as Date,
       d.Quantity,
       0 lot_no,
       m.date_challan challan_date,
       d.quantity * d.current_price price,
       0 sd,
       0 vat,
       d.quantity dispose_quantity,
       d.quantity * d.current_price dispose_price,
       d.sd dispose_sd,
       d.vat dispose_sd_vat,
       0 debit_quantity,
       0 debit_price,
       0 production_Qty,
       0 purchase_unit_price,
       0 unit_id,
       '--' prdDate,
       (select code_name 
        from app_code_detail 
        where m.challan_page_discard_reason_m = code_id_m 
          and m.challan_page_discard_reason_d = code_id_d) as Remarks,
       tp.party_name,
       tp.party_bin,
       d.date_insert,
       tp.party_address,
       i.item_name,
       iu.unit_code
from trns_sale_master m
inner join trns_sale_detail d on d.challan_id = m.challan_id
inner join item i on i.item_id = d.item_id
inner join item_unit iu on iu.unit_id = i.unit_id
left  join trns_party tp on tp.party_id = m.party_id
where cast(m.date_challan as date) <= to_date('{dateStr}', 'dd/MM/yyyy')
      {itemFilter}
      AND d.is_deleted = false  
      and m.challan_type = 'D'
      AND m.organization_id = {orgId}
      AND m.org_branch_reg_id in ({branchIds})

UNION ALL

select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no,
       '--' organization_name ,'--' registration_no,
       to_char(m.date_challan, 'dd/MM/yyyy') as Date,
       d.Quantity,
       0 lot_no,
       m.date_challan challan_date,
       d.quantity * d.actual_price price,
       d.sd,
       d.vat,
       0 dispose_quantity,
       0 dispose_price,
       0 dispose_sd,
       0 dispose_sd_vat,
       0 debit_quantity,
       0 debit_price,
       0 production_Qty,
       0 purchase_unit_price,
       0 unit_id,
       '--' prdDate,
       'Direct Sale' as Remarks,
       tp.party_name,
       tp.party_bin,
       d.date_insert,
       tp.party_address,
       i.item_name,
       iu.unit_code
from trns_sale_master m
inner join trns_sale_detail d on d.challan_id = m.challan_id
inner join item i on i.item_id = d.item_id
inner join item_unit iu on iu.unit_id = i.unit_id
left  join trns_party tp on tp.party_id = m.party_id
where cast(m.date_challan as date) <= to_date('{dateStr}', 'dd/MM/yyyy')
      {itemFilter}
      AND d.is_deleted = false  
      and m.challan_type = 'S'
      AND m.organization_id = {orgId}
      AND m.org_branch_reg_id in ({branchIds})

UNION ALL

(
    select 'P' status,d.production_id,0 org_branch_reg_id, '--' challan_no,
           '--' organization_name ,'--' registration_no,
           to_char(m.date_production, 'dd/MM/yyyy') as Date,
           0 Quantity,
           0 lot_no,
           m.date_production challan_date,
           0 price,
           0 sd,
           0 vat,
           0 dispose_quantity,
           0 dispose_price,
           0 dispose_sd,
           0 dispose_sd_vat,
           0 debit_quantity,
           0 debit_price,
           COALESCE(d.quantity, 0) as production_Qty,
           d.unit_price purchase_unit_price,
           d.unit_id,
           to_char(d.date_insert, 'dd/MM/yyyy') as prdDate,
           '--' Remarks,
           '--' party_name,
           '--' party_bin,
           d.date_insert,
           '--' party_address,
           '--' item_name,
           iu.unit_code
    from trns_production_detail d
    inner join trns_production_master m on d.production_id = m.production_id
    inner join item i on i.item_id = d.item_id
    inner join item_unit iu on iu.unit_id = i.unit_id
    where cast(m.date_production as date) <= to_date('{dateStr}', 'dd/MM/yyyy')
          {itemFilter}
          AND d.is_deleted = false 
          AND d.status = 'R'
          AND m.organization_id = {orgId}
          AND m.org_branch_reg_id in ({branchIds})
    order by m.date_production
)

UNION ALL

(
    select 'P' status,0 production_id,0 org_branch_reg_id, '--' challan_no,
           '--' organization_name ,'--' registration_no,
           to_char(d.date_consumable_challan, 'dd/MM/yyyy') as Date,
           0 Quantity,
           0 lot_no,
           d.date_consumable_challan challan_date,
           0 price,
           0 sd,
           0 vat,
           0 dispose_quantity,
           0 dispose_price,
           0 dispose_sd,
           0 dispose_sd_vat,
           0 debit_quantity,
           0 debit_price,
           COALESCE(d.quantity, 0) as production_Qty,
           d.price / d.quantity purchase_unit_price,
           d.unit_id,
           to_char(d.date_insert, 'dd/MM/yyyy') as prdDate,
           d.remarks Remarks,
           '--' party_name,
           '--' party_bin,
           d.date_insert,
           '--' party_address,
           '--' item_name,
           iu.unit_code
    from gift_items_detail d
    inner join item i on i.item_id = d.item_id
    inner join item_unit iu on iu.unit_id = i.unit_id
    where cast(d.date_consumable_challan as date) <= to_date('{dateStr}', 'dd/MM/yyyy')
          {itemFilter}
          AND d.is_deleted = false 
          AND d.organization_id = {orgId}
          AND d.org_branch_id in ({branchIds})
)

UNION ALL

select 'P' status,0 production_id,m.receiving_branch_id, m.challan_no As challan_no,
       o.organization_name , o.registration_no,
       to_char(m.issues_date, 'dd/MM/yyyy') as Date,
       d.Quantity,
       0 lot_no,
       m.issues_date challan_date,
       d.quantity * d.unit_price price,
       coalesce(d.sd_amount,0) sd,
       coalesce(d.vat_amount,0) vat,
       0 dispose_quantity,
       0 dispose_price,
       0 dispose_sd,
       0 dispose_sd_vat,
       0 debit_quantity,
       0 debit_price,
       0 production_Qty,
       0 purchase_unit_price,
       0 unit_id,
       '--' prdDate,
       d.Remarks,
       ob.branch_unit_name party_name,
       ob.branch_unit_bin party_bin,
       d.date_insert,
       ob.org_branch_address party_address,
       i.item_name,
       iu.unit_code
from trns_transfer_master m
inner join org_registration_info o  on m.organization_id   = o.organization_id
inner join org_branch_reg_info ob   on m.receiving_branch_id = ob.org_branch_reg_id
inner join trns_transfer_detail d   on d.transfer_id       = m.transfer_id
inner join item i                   on i.item_id           = d.item_id
inner join item_unit iu             on iu.unit_id          = i.unit_id
where m.transfer_status = 'R'
      {itemFilter}
      AND m.organization_id = {orgId}
      AND m.receiving_branch_id in ({branchIds})
      and cast(m.issues_date as date) <= to_date('{dateStr}', 'dd/MM/yyyy')

UNION ALL

select 'P' status,0 production_id,m.issuing_branch_id, m.challan_no As challan_no,
       o.organization_name , o.registration_no,
       to_char(m.issues_date, 'dd/MM/yyyy') as Date,
       0 Quantity,
       0 lot_no,
       m.issues_date challan_date,
       0 price,
       0 sd,
       0 vat,
       0 dispose_quantity,
       0 dispose_price,
       0 dispose_sd,
       0 dispose_sd_vat,
       0 debit_quantity,
       0 debit_price,
       d.quantity production_Qty,
       d.quantity * d.unit_price price,
       0 unit_id,
       '--' prdDate,
       d.Remarks,
       ob.branch_unit_name party_name,
       ob.branch_unit_bin party_bin,
       d.date_insert,
       ob.org_branch_address party_address,
       i.item_name,
       iu.unit_code
from trns_transfer_master m
inner join org_registration_info o  on m.organization_id   = o.organization_id
inner join org_branch_reg_info ob   on m.issuing_branch_id = ob.org_branch_reg_id
inner join trns_transfer_detail d   on d.transfer_id       = m.transfer_id
inner join item i                   on i.item_id           = d.item_id
inner join item_unit iu             on iu.unit_id          = i.unit_id
where m.transfer_status = 'I'
      {itemFilter}
      AND m.organization_id = {orgId}
      AND m.issuing_branch_id in ({branchIds})
      and cast(m.issues_date as date) <= to_date('{dateStr}', 'dd/MM/yyyy')

order by challan_date";

            return this.DBUtil.GetDataTable(query);
        }



        public DataTable GetItemLotInfo(long itemID)
        {
            if (itemID > 0)
            {
                string.Concat("item_id = '", itemID, "'");
            }
            string str = string.Concat("select unit_id,quantity,available_qnt,lot_no,lot_no_status,purchase_unit_price from trns_purchase_detail where lot_no_status='false' AND item_id=", itemID, " ORDER BY lot_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetItemType(int itemID)
        {
            string str = string.Concat("select item_type from item  \r\n                        where item_id=", itemID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetOpeningBalanceStock(int itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select item_qty ,item_value,opening_balance_date from opening_balance where item_id=", itemID, " and organization_id=", num, " and org_branch_reg_id=", num1 };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyInfobyPartyId(short partyId)
        {
            string str = string.Concat("Select * from trns_party where Is_deleted=false and Party_id='", partyId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetProduction_unitId(DateTime fromDate, DateTime toDate, int itemID, int branchID, int production_id)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            object[] objArray = new object[] { "select  d.unit_id unit_id,d.quantity, iu.unit_code\r\n                from trns_production_detail d             \r\n                inner join trns_production_master m on d.production_id = m.production_id\r\n                --inner join trns_purchase_detail pd on pd.item_id = d.item_id           \r\n                inner join Item i on i.item_id = d.item_id \r\n                inner join item_unit iu on iu.unit_id=d.unit_id             \r\n               where d.Date_insert >= TO_DATE('", fromDate.ToString("MM/dd/yyy"), "', 'MM/dd/yyyy') AND d.Date_insert <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')\r\n                             ", str, "  AND d.production_id=", production_id, " AND d.Is_deleted = false AND d.status = 'I'\r\n\r\n                   order by d.Date_insert" };
            str1 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetPSAvgValue(int itemID)
        {
            object[] objArray = new object[] { "\r\n                    select max(purchase_unit_price) purchase_unit_price,max(vat_rate) vat_rate,max(sd_rate) sd_rate, max(sale_unit_price) sale_unit_price\r\n                    from\r\n                    (\r\n                    select SUM(quantity*purchase_unit_price)/SUM(quantity) purchase_unit_price, 0  sale_unit_price, vat_rate,sd_rate\r\n                    from trns_purchase_detail where item_id = ", itemID, " group by vat_rate,sd_rate\r\n\r\n                    UNION ALL \r\n\r\n                    select 0 purchase_unit_price, SUM(quantity*actual_price)/SUM(quantity) sale_unit_price,0 vat_rate, 0 sd_rate\r\n                    from trns_sale_detail where item_id = ", itemID, "\r\n\r\n                    )muktadir " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchase_unitId(DateTime fromDate, DateTime toDate, int itemID, int branchID)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            string[] strArrays = new string[] { "select d.unit_id,ui.unit_code,d.quantity,d.lot_no,d.purchase_unit_price from trns_purchase_detail d \r\n                          inner join trns_purchase_master m on d.Challan_id = m.Challan_id                         \r\n                          inner join Item i on i.item_id = d.item_id\r\n                          inner join  item_unit ui on ui.unit_id=d.unit_id              \r\n                          where m.date_challan >=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.date_challan <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') ", str, "   AND d.Is_deleted = false  order by lot_no" };
            str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetPurchaseAccountReportData(short ItemID, DateTime fromDate, DateTime toDate)
        {
            string str = "";
            string str1 = "";
            if (ItemID >= 0)
            {
                str = string.Concat("AND PD.ITEM_ID =", ItemID);
                str1 = string.Concat("AND SD.ITEM_ID =", ItemID);
            }
            else
            {
                str = "";
                str1 = "";
            }
            string[] strArrays = new string[] { "SELECT  D.TRANS_TYPE, D.CHALLAN_ID,D.CHALLAN_NO,D.DATE_CHALLAN, D.ITEM_ID, D.ITEM_NAME,D.UNIT_ID,\r\nD.OPENING_STOCK OPENING_STOCK, D.TOTAL_OPENING_PRICE TOTAL_OPENING_PRICE,\r\n/*case when d.Quantity>0 then to_char(D.QUANTITY,'9999')||' '||IU.UNIT_NAME else '' end*/ d.QUANTITY, iu.UNIT_CODE,\r\nD.UNIT_PRICE, D.TOTAL_PRICE,  D.SALE_QTY, D.TOTAL_SALE_PRICE,\r\nD.TOTAL_SD, D.TOTAL_VAT, (D.TOTAL_PURCHASE_PRICE-(D.SALE_QTY*D.UNIT_PRICE)) as TOTAL_PURCHASE_PRICE ,\r\nD.PARTY_NAME, D.PARTY_TIN, D.PARTY_ADDRESS\r\n\r\nFROM (\r\n--------------OPENING\r\n\r\nSELECT 'O' TRANS_TYPE, 0 CHALLAN_ID, '' CHALLAN_NO, to_date('01/01/1000','MM/dd/yyyy') DATE_CHALLAN, O.ITEM_ID, O.ITEM_NAME, O.UNIT_ID,\r\nSUM(O.QUANTITY) OPENING_STOCK, SUM(O.TOTAL_PRICE) TOTAL_OPENING_PRICE,\r\n0 QUANTITY, MAX(O.UNIT_PRICE) UNIT_PRICE, 0 TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n0 TOTAL_SD,0 TOTAL_VAT, 0 TOTAL_PURCHASE_PRICE,\r\n '' PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS  \r\n \r\n FROM (\r\n-----OPENING PURCHASE\r\n\r\nSELECT   to_char(pm.date_challan,'dd-Mon-yyyy')date_challan, PD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID, \r\n(PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE)+(PD.SD)+(PD.VAT) TOTAL_PRICE, \r\n(PD.SD) TOTAL_SD, (PD.VAT) TOTAL_VAT\r\nFROM TRNS_PURCHASE_DETAIL PD \r\nINNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\nINNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\nWHERE TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') < TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND \r\nPM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P', 'F') ", str, "\r\n\r\n/*\r\nUNION ALL\r\n\r\n----OPENING PRODUCTION\r\n\r\nSELECT  to_char(Date_production,'dd-Mon-yyyy') date_challan, PD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,\r\n(PD.QUANTITY) QUANTITY, PD.UNIT_PRICE, (PD.QUANTITY * PD.unit_price) TOTAL_PRICE, \r\n0 TOTAL_SD, 0 TOTAL_VAT\r\nFROM TRNS_PRODUCTION_DETAIL PD \r\nINNER JOIN TRNS_PRODUCTION_MASTER PM ON PM.Production_id = PD.Production_id\r\nINNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\nWHERE TO_DATE(TO_CHAR(PM.Date_production, 'MM/dd/yyyy'), 'MM/dd/yyyy') < TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND \r\nPM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.Material_type = 'R' \r\n", str, "\r\n*/\r\n\r\nUNION ALL\r\n\r\n----OPENING SALE\r\n\r\nSELECT to_char(sm.date_challan,'dd-Mon-yyyy')date_challan, SD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,\r\nSUM(-SD.QUANTITY) QUANTITY, MAX(SD.ACTUAL_PRICE) UNIT_PRICE, SUM(-SD.QUANTITY * SD.nbr_confirm_price) TOTAL_PRICE, \r\nSUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\nFROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\nleft outer join TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\nINNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\nWHERE SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S', 'R', 'D') ", str1, "\r\nAND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') < TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\nGROUP BY SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME, PR.party_name, PR.PARTY_BIN, PR.PARTY_ADDRESS,I.UNIT_ID\r\n\r\n\r\n) O\r\nGROUP BY  O.ITEM_ID, O.ITEM_NAME,O.UNIT_ID\r\n\r\n----------END OF OPENING\r\n\r\nUNION ALL\r\n\r\n-----PURCHASE\r\n\r\nSELECT  D.TRANS_TYPE, D.CHALLAN_ID, D.CHALLAN_NO, D.DATE_CHALLAN , D.ITEM_ID, D.ITEM_NAME, D.UNIT_ID,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\nSUM(D.QUANTITY) QUANTITY, SUM(D.UNIT_PRICE) UNIT_PRICE, SUM(D.TOTAL_PRICE) TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\nSUM(D.TOTAL_SD) TOTAL_SD, SUM(D.TOTAL_VAT) TOTAL_VAT, SUM(D.TOTAL_PURCHASE_PRICE)  TOTAL_PURCHASE_PRICE,\r\n D.PARTY_NAME, D.PARTY_TIN, D.PARTY_ADDRESS  \r\nFROM (\r\n\r\n\r\nSELECT pm.challan_type TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN , PD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n(PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n(PD.SD) TOTAL_SD, (PD.VAT) TOTAL_VAT,\r\n ((PD.QUANTITY * PD.ACTUAL_PRICE) + (PD.SD) + (PD.VAT)  + (PD.CD) + (PD.RD) + (PD.AIT)+(PD.ATV)+ (PD.TTI)) TOTAL_PURCHASE_PRICE,\r\n tp.party_name PARTY_NAME, tp.party_Bin PARTY_TIN, tp.party_address PARTY_ADDRESS  \r\nFROM TRNS_PURCHASE_DETAIL PD \r\nINNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\nINNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID left outer join\r\ntrns_party tp on tp.Party_id=pm.Party_id\r\nWHERE TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\nAND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\nPM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P', 'F') \r\n", str, " AND PD.is_source_tax_deduct = FALSE\r\n\r\nUNION ALL\r\n\r\nSELECT pm.challan_type TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN , PD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n(PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n(PD.SD) TOTAL_SD, (PD.VAT) TOTAL_VAT,\r\n ((PD.QUANTITY * PD.ACTUAL_PRICE) /* - (PD.SD) - (PD.VAT) */ + (PD.CD) + (PD.RD) + (PD.AIT)+(PD.ATV)+ (PD.TTI)) TOTAL_PURCHASE_PRICE,\r\n tp.party_name PARTY_NAME, tp.party_Bin PARTY_TIN, tp.party_address PARTY_ADDRESS  \r\nFROM TRNS_PURCHASE_DETAIL PD \r\nINNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\nINNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID left outer join\r\ntrns_party tp on tp.Party_id=pm.Party_id\r\nWHERE TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\nAND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\nPM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P', 'F') \r\n", str, " AND PD.is_source_tax_deduct = TRUE\r\n\r\n\r\n) D GROUP BY  D.TRANS_TYPE, D.CHALLAN_ID, D.CHALLAN_NO, D.DATE_CHALLAN , D.ITEM_ID, D.ITEM_NAME, D.UNIT_ID, D.PARTY_NAME, D.PARTY_TIN, D.PARTY_ADDRESS  \r\n\r\n\r\nUNION ALL\r\n\r\n----FINISHED GOODS PRODUCTION\r\n\r\n/*\r\nSELECT 'P' TRANS_TYPE, PM.Production_id CHALLAN_ID, PM.Challan_batch_no CHALLAN_NO, PM.Date_production DATE_CHALLAN, PD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n(PD.QUANTITY) QUANTITY, PD.UNIT_PRICE, (PD.QUANTITY * PD.unit_price) TOTAL_PRICE, 0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n0 TOTAL_SD, 0 TOTAL_VAT,\r\n '' SALE_PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS  \r\nFROM TRNS_PRODUCTION_DETAIL PD \r\nINNER JOIN TRNS_PRODUCTION_MASTER PM ON PM.Production_id = PD.Production_id\r\nINNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\nWHERE TO_DATE(TO_CHAR(PM.Date_production, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\nAND TO_DATE(TO_CHAR(PM.Date_production, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\nPM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.Material_type in ( 'P')  \r\n", str, "\r\nUnion ALL\r\n\r\nSELECT 'F' TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN, PD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n(PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n(PD.SD) TOTAL_SD, (PD.VAT) TOTAL_VAT,\r\n tp.party_name PARTY_NAME, tp.party_Bin PARTY_TIN, tp.party_address PARTY_ADDRESS  \r\nFROM TRNS_PURCHASE_DETAIL PD \r\nINNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\nINNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID left outer join\r\ntrns_party tp on tp.Party_id=pm.Party_id\r\nWHERE TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\nAND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\nPM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ('F') \r\n", str, "\r\n\r\nUNION ALL\r\n*/\r\n----SALE\r\n\r\nSELECT sm.challan_type TRANS_TYPE, SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,0 OPENING_STOCK,0 TOTAL_OPENING_PRICE,\r\n0 QUANTITY, MAX(SD.ACTUAL_PRICE) UNIT_PRICE, 0 TOTAL_PRICE, SUM(SD.QUANTITY) SALE_QTY, SUM(SD.QUANTITY * SD.nbr_confirm_price) TOTAL_SALE_PRICE,\r\nSUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT, 0 TOTAL_PURCHASE_PRICE,\r\n PARTY_NAME, '' PARTY_TIN, PR.PARTY_ADDRESS PARTY_ADDRESS\r\nFROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\nleft outer join TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\nINNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\nWHERE SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S', 'R', 'D') ", str1, "\r\nAND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\nAND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\nGROUP BY sm.challan_type,SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME, PR.party_name, PR.PARTY_BIN, PR.PARTY_ADDRESS, I.UNIT_ID\r\n/*\r\nUNION ALL\r\n\r\n----RAW MATERIAL CONSUMPTION\r\n\r\nSELECT 'R' TRANS_TYPE, SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN , SD.ITEM_ID, I.ITEM_NAME, I.UNIT_ID,0 OPENING_STOCK,0 TOTAL_OPENING_PRICE,\r\n0 QUANTITY, MAX(SD.ACTUAL_PRICE) UNIT_PRICE, 0 TOTAL_PRICE, SUM(SD.QUANTITY) SALE_QTY, SUM(SD.QUANTITY * SD.nbr_confirm_price) TOTAL_SALE_PRICE,\r\nSUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT,\r\n'' PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS\r\nFROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\nleft outer JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\nINNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\nWHERE SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ('R') ", str1, "\r\nAND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\nAND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\nGROUP BY SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME, PR.party_name, PR.PARTY_BIN, PR.PARTY_ADDRESS, I.UNIT_ID\r\n*/\r\n) D INNER JOIN Item_unit iu on iu.unit_id=d.unit_id\r\n\r\nORDER BY D.DATE_CHALLAN" };
            string str2 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str2);
        }

        public DataTable GetPurchaseInfo(int itemID)
        {
            string str = string.Concat("select * from trns_purchase_detail tpd \r\n                        inner join trns_purchase_master tpm on tpd.challan_id=tpm.challan_id\r\n                        where item_id=", itemID, " and tpm.challan_type='P' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPurchaseInfobyLCNo(short LCNo)
        {
            string str = string.Concat("select * from trns_purchase_master where Is_deleted=false and lc_no='", LCNo, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchasePrice(DateTime fromDate, DateTime toDate, int itemID, int branchID)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            string[] strArrays = new string[] { " select avg(d.purchase_unit_price) purchase_unit_price from trns_purchase_detail d \r\n                          inner join trns_purchase_master m on d.Challan_id = m.Challan_id                         \r\n                          inner join Item i on i.item_id = d.item_id\r\n                          inner join  item_unit ui on ui.unit_id=d.unit_id             \r\n                          where m.date_challan >=TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_challan <=TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') ", str, "   AND d.Is_deleted = false" };
            str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetPurchaseSkuNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select distinct i.item_id, i.item_name, i.item_sku\r\n                        from trns_purchase_master tsm  /*zahid 09-08-22*/\r\n                        inner join trns_purchase_detail tsd on tsm.challan_id = tsd.challan_id /*zahid 09-08-22*/\r\n                        inner join item i on tsd.item_id = i.item_id where tsm.organization_id = ", num);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable PurchaseAccountingBook(DateTime fromDate, DateTime toDate, int itemID, int branchID)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no, o.organization_name , o.registration_no ,case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy') else  to_char(m.ref_challan_date, 'dd/MM/yyyy') end  as Date, d.Quantity,\r\n\t           d.lot_no,m.Date_CHALLAN challan_date, d.quantity* d.purchase_unit_price price, d.purchase_sd sd, d.purchase_vat vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                                0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,d.Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                                tp.party_address,i.item_name,iu.unit_code\r\n                                from trns_purchase_master m\r\n                                inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                                inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                                inner join Item i on i.item_id = d.item_id \r\n                                inner join item_unit iu on iu.unit_id=i.unit_id                   \r\n                                left join trns_party tp on tp.party_id = m.party_id\r\n                                where cast (m.date_challan as Date) >= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND cast (m.date_challan as Date) <= TO_DATE('", toDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                                ", str, "    AND d.Is_deleted = false and d.approver_stage='F' and m.challan_type='P' AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "\r\n \r\n                  UNION ALL\r\n                            select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no , '--' organization_name ,'--' registration_no ,case when m.purchase_type ='I' then to_char(m.bl_date, 'dd/MM/yyyy') else  to_char(m.Date_CHALLAN, 'dd/MM/yyyy') end  as Date, d.Quantity,\r\n\t                        d.lot_no,m.Date_CHALLAN challan_date, d.quantity* d.purchase_unit_price price, d.purchase_sd sd, d.purchase_vat vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,d.Quantity debit_quantity, d.quantity* d.purchase_unit_price debit_price,\r\n                            0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,'Debit' Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                            tp.party_address,i.item_name,iu.unit_code\r\n                            from trns_purchase_master m                           \r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id=i.unit_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                            where cast (m.date_challan as Date) >= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND cast (m.date_challan as Date) <= TO_DATE('", toDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                             ", str, "    AND d.Is_deleted = false and m.challan_type ='D'  and d.approver_stage='F' AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "\r\n\r\n         \r\n                 UNION ALL\r\n                             select 'P' status,0 production_id,m.org_branch_reg_id, m.challan_no As challan_no,'--' organization_name ,'--' registration_no ,  to_char(m.Date_CHALLAN, 'dd/MM/yyyy') as Date, d.Quantity,\r\n                             0 lot_no,m.Date_CHALLAN challan_date,d.quantity* d.current_price  price, 0 sd, 0 vat,d.quantity dispose_quantity,d.quantity* d.current_price dispose_price, d.sd dispose_sd, d.vat dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                             0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,'Dispose' Remarks,tp.party_name , tp.party_bin ,d.Date_insert,\r\n                             tp.party_address,i.item_name,iu.unit_code\r\n                             from trns_sale_master m                           \r\n                             inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                             inner join Item i on i.item_id = d.item_id\r\n                             inner join item_unit iu on iu.unit_id=i.unit_id\r\n                             left join trns_party tp on tp.party_id = m.party_id\r\n                             where cast (m.date_challan as Date) >= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND cast (m.date_challan as Date) <= TO_DATE('", toDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                            ", str, "    AND d.Is_deleted = false  and d.approver_stage='F' and m.challan_type='D' AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, "\r\n\r\n                UNION ALL\r\n                            (select 'P' status,d.production_id,0 org_branch_reg_id, '--' challan_no,'--' organization_name ,'--' registration_no , to_char(m.Date_Production, 'dd/MM/yyyy') as Date,0 Quantity,0 lot_no,m.Date_Production challan_date,\r\n\t                        0 price,0 sd, 0 vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n\t                        COALESCE(d.Quantity, '0') as production_Qty,\t          \r\n\t       \t               -- (select purchase_unit_price from trns_purchase_detail pd where pd.item_id= ", itemID, " limit 1) \r\n                            d.unit_price purchase_unit_price, d.unit_id,\r\n\t                        to_char(d.date_insert, 'dd/MM/yyyy') as prdDate,\r\n                            '--' Remarks,'--' party_name ,'--' party_bin ,d.Date_insert, '--'party_address,'--'item_name,iu.unit_code\r\n                            from trns_production_detail d              \r\n                            inner join trns_production_master m on d.production_id = m.production_id     \r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id=i.unit_id\r\n                            where cast (m.Date_Production as Date) >= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND cast (m.Date_Production as Date) <= TO_DATE('", toDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                                         ", str, "  AND d.Is_deleted = false AND d.status = 'R' AND m.organization_id= ", num, " AND M.org_branch_reg_id = ", num1, " order by m.Date_Production) \r\n UNION ALL\r\n                             \r\n                            (select 'P' status,0 production_id,0 org_branch_reg_id, '--' challan_no,'--' organization_name ,'--' registration_no , to_char(d.date_consumable_challan, 'dd/MM/yyyy') as Date,0 Quantity,0 lot_no,d.date_consumable_challan challan_date,\r\n\t                        0 price,0 sd, 0 vat,0 dispose_quantity,0 dispose_price, 0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n\t                        COALESCE(d.Quantity, '0') as production_Qty,\t          \r\n\t       \t               -- (select purchase_unit_price from trns_purchase_detail pd where pd.item_id= 2702 limit 1) \r\n                            d.price/d.quantity purchase_unit_price, d.unit_id,\r\n\t                        to_char(d.date_insert, 'dd/MM/yyyy') as prdDate,\r\n                            '--' Remarks,'--' party_name ,'--' party_bin ,d.Date_insert, '--'party_address,'--'item_name,iu.unit_code\r\n                            from gift_items_detail d   \r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id=i.unit_id\r\n                            where cast (d.date_consumable_challan as Date) >= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND cast (d.date_consumable_challan as Date) <= TO_DATE('", toDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n                            ", str, "  AND d.Is_deleted = false AND d.organization_id= ", num, " AND d.org_branch_id = ", num1, ")\r\nunion All \r\nselect 'P' status,0 production_id,m.receiving_branch_id, m.challan_no As challan_no, o.organization_name , o.registration_no ,\r\nto_char(issues_date, 'dd/MM/yyyy')  as Date, d.Quantity,\r\n\t           0 lot_no,m.issues_date challan_date, d.quantity* d.unit_price price, coalesce(d.sd_amount,0) sd, coalesce(d.vat_amount,0) vat,0 dispose_quantity,0 dispose_price, \r\n\t           0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                                0 production_Qty,0 purchase_unit_price,0 unit_id,'--' prdDate,d.Remarks,\r\n                                branch_unit_name party_name ,ob.branch_unit_bin party_bin ,d.Date_insert,\r\n                                ob.org_branch_address party_address,i.item_name,iu.unit_code\r\n                                from trns_transfer_master m\r\n                                inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                                inner join org_branch_reg_info ob on m.receiving_branch_id = ob.org_branch_reg_id\r\n                                inner join trns_transfer_detail d on d.transfer_id = m.transfer_id\r\n                                inner join Item i on i.item_id = d.item_id \r\n                                inner join item_unit iu on iu.unit_id=i.unit_id                   \r\n                                \r\n                                 where  m.transfer_status='R' ", str, " AND m.organization_id= ", num, " AND m.receiving_branch_id =  ", num1, "\r\n                     and CAST(m.issues_date AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND CAST(m.issues_date AS DATE) <=  TO_DATE('", toDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n\r\n\r\nunion All \r\nselect 'P' status,0 production_id,m.issuing_branch_id, m.challan_no As challan_no, o.organization_name , o.registration_no ,\r\nto_char(issues_date, 'dd/MM/yyyy')  as Date, 0 Quantity,\r\n\t           0 lot_no,m.issues_date challan_date, 0 price, 0 sd, 0 vat,0 dispose_quantity,0 dispose_price, \r\n\t           0 dispose_sd, 0 dispose_sd_vat,0 debit_quantity,0 debit_price,\r\n                               d.Quantity production_Qty,d.quantity* d.unit_price price ,0 unit_id,'--' prdDate,d.Remarks,\r\n                                branch_unit_name party_name ,ob.branch_unit_bin party_bin ,d.Date_insert,\r\n                                ob.org_branch_address party_address,i.item_name,iu.unit_code\r\n                                from trns_transfer_master m\r\n                                inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                                inner join org_branch_reg_info ob on m.issuing_branch_id = ob.org_branch_reg_id\r\n                                inner join trns_transfer_detail d on d.transfer_id = m.transfer_id\r\n                                inner join Item i on i.item_id = d.item_id \r\n                                inner join item_unit iu on iu.unit_id=i.unit_id                   \r\n                                \r\n                                 where m.transfer_status='I' ", str, " AND m.organization_id= ", num, " AND m.issuing_branch_id = ", num1, "\r\n                     and CAST(m.issues_date AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy') AND CAST(m.issues_date AS DATE) <=  TO_DATE('", toDate.ToString("dd/MM/yyy"), "', 'dd/MM/yyy')\r\n\r\n                            order by challan_date" };
            str1 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable PurchaseNSale621(DateTime fromDate, DateTime toDate, int itemID, int branchID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["empId"].ToString());
            Convert.ToInt32(HttpContext.Current.Session["USER_LEVEL"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            DataTable branchInformation621 = (new ChallanBLL()).GetBranchInformation621(num2, num, num1);
            int num3 = 0;
            if (branchInformation621 != null && branchInformation621.Rows.Count > 0)
            {
                num3 = Convert.ToInt32(branchInformation621.Rows[0]["org_branch_reg_id"].ToString());
            }
            int num4 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] str = new object[] { "\r\n                    select distinct '-' as serial_1,'-' as date_2,\r\n                    (\r\n\t\t           --purchase\r\n                    (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_purchase_detail as d inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                    where  CAST(m.date_challan AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, "  AND m.organization_id= ", num4, " AND m.org_branch_reg_id = ", num3, " and d.approver_stage='F' and m.challan_type not in('O','T','D','Cr')  and M.is_trns_accepted=true)\r\n                    -\r\n                    --sale\r\n                    ((select case when sum(d.quantity) is null then 0 else sum(d.quantity) end from trns_sale_detail as d inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                     where CAST(m.date_challan AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND d.item_id = ", itemID, " AND  m.organization_id= ", num4, " AND m.org_branch_reg_id = ", num3, "  and d.approver_stage='F' and d.type_p!='S')     \r\n                    + \r\n                    --Debit\r\n                    (\r\n\t\t             select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t             where CAST(m.date_note AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='D' AND d.item_id=", itemID, " AND  m.organization_id= ", num4, " AND m.org_branch_reg_id = ", num3, "\r\n                    )\r\n                    +\r\n                    --Transfer Issue\r\n                    (\r\n\t\t            select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t            where CAST(m.issues_date AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'I' AND d.item_id=", itemID, " AND m.organization_id= ", num4, " AND  m.organization_id= ", num4, " AND m.issuing_branch_id = ", num3, "\r\n                    ))\r\n                    +\r\n                    --credit\r\n                    (\r\n\t                select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_note_master m inner join trns_note_detail d on m.note_id=d.note_id\r\n\t\t            where CAST(m.date_note AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.note_type='C' AND d.item_id=", itemID, " AND m.organization_id= ", num4, " AND m.org_branch_reg_id = ", num3, "\r\n                    )\r\n                    +\r\n\t\t            --Transfer Receive\r\n\t\t            (select case when sum(d.quantity) is null then 0 else sum(d.quantity) end  from trns_transfer_master m inner join trns_transfer_detail d on m.transfer_id = d.transfer_id\r\n\t\t             where CAST(m.issues_date AS DATE) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND m.transfer_status = 'R' AND d.item_id=", itemID, " AND m.organization_id= ", num4, " AND m.receiving_branch_id = ", num3, ")                        \r\n                    ) as prarombik_jer_poriman_3\r\n                    , 0 as prarombik_jer_mullo_4\r\n\t                ,0 as poriman_5,0 as mullo_6,0 as poriman_7, 0 as mullo_8 \r\n\t                ,'-' as name_9\r\n\t                ,'-' as address_10\r\n\t                ,'-' as national_id_11\r\n\t                ,'-' as challan_no_12,'-' as date_challan_13\r\n                    ,'-' as biboron_14,0 as poriman_15,0 as korjoggo_mullo_16, 0 as sompurok_sulko_17,0 as mushok_18\r\n\t                ,'-' as name_19,'-' as address_20,'-' as national_id_no_21,'-' as challan_no_22,'-' as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25,'-' as montobbo_26, 1 as ord\r\n                    ,CAST(to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AS DATE) as date_insert,'-' type_p,iu.unit_code,false as status\r\n                              \r\n                   from trns_purchase_detail\r\n                   inner join item_unit iu on iu.unit_id=trns_purchase_detail.unit_id where trns_purchase_detail.item_id=", itemID, "\r\n                    UNION\r\n                    select \r\n\t                --purchase part\r\n\t                '-' as serial_1,to_char(pm.date_challan, 'dd/MM/yyyy') as date_2,0 as prarombik_jer_poriman_3,0 as prarombik_jer_mullo_4\r\n\t                ,pd.quantity as poriman_5,\r\n                    --pd.total_price as mullo_6\r\n                     pd.quantity*pd.purchase_unit_price mullo_6,0 as poriman_7, pd.total_price as mullo_8 \r\n\t                ,(select party_name from trns_party where party_id=pm.party_id) as name_9\r\n\t                ,(select party_address from trns_party where party_id=pm.party_id) as address_10\r\n\t                ,(select case when party_bin!='' then party_bin else national_id_no end from trns_party where party_id=pm.party_id) as national_id_11\r\n\t                ,pm.challan_no as challan_no_12,case when pm.purchase_type ='I' then to_char(pm.bl_date, 'dd/MM/yyyy') else  to_char(pm.ref_challan_date, 'dd/MM/yyyy') end  as  date_challan_13\r\n\t                --sale part\r\n\t                ,'-' as biboron_14,0 as poriman_15,0 as korjoggo_mullo_16, 0 as sompurok_sulko_17,0 as mushok_18\r\n\t                ,'-' as name_19,'-' as address_20,'-' as national_id_no_21,'-' as challan_no_22,'-' as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25,case when i.vat_rebate!=0 then concat(i.vat_rebate,'% rebatable ') else  pd.remarks end as montobbo_26, 2 as ord\r\n                    ,pd.date_insert AS date_insert,'-' type_p,iu.unit_code,false as status\r\n\t                from trns_purchase_master pm\r\n\t                inner join trns_purchase_detail pd on pm.challan_id=pd.challan_id\r\n                    inner join item i on i.item_id = pd.item_id\r\n                     inner join item_unit iu on iu.unit_id=pd.unit_id\r\n\t                where pd.item_id=", itemID, "  and pd.approver_stage='F' AND pm.challan_type='P' AND pm.organization_id= ", num4, " AND pm.org_branch_reg_id=", num3, "  and PM.is_trns_accepted=true\r\n                    and CAST(pm.date_challan AS DATE) >=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(pm.date_challan AS DATE) <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n\t                UNION\r\n\t                select \r\n\t                --sale part\r\n\t                '-' as serial_1,'-' as date_2,0 as prarombik_jer_poriman_3,0 as prarombik_jer_mullo_4\r\n\t                ,0 as poriman_5,0 as mullo_6,0 as poriman_7, 0 as mullo_8 \r\n\t                ,'-' as name_9,'-' as address_10,'-' as national_id_11\r\n\t                ,'-' challan_no_12,'-' as date_challan_13\r\n\t                --sale part\r\n\t                , (case when sd.item_serials<>'' THEN CONCAT(i.item_name,'(',sd.item_serials,')') ELSE i.item_name END) AS biboron_14 --i.item_name as biboron_14,\r\n                    ,case when sd.installment_status=false then sd.quantity else 0 end as poriman_15,(sd.actual_price*sd.quantity) as korjoggo_mullo_16\r\n\t                , sd.sd as sompurok_sulko_17,sd.vat as mushok_18\r\n\t                ,(select party_name from trns_party where party_id=sm.party_id) as name_19\r\n\t                ,(select party_address from trns_party where party_id=sm.party_id) as address_20\r\n\t                ,(select case when party_bin!='' then party_bin else national_id_no end from trns_party where party_id=sm.party_id)  as national_id_no_21\r\n\t                ,sm.challan_no as challan_no_22,to_char(sm.date_challan, 'dd/MM/yyyy') as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25,sd.remarks as montobbo_26, 3 as ord\r\n                    ,sd.date_insert as date_insert,sd.type_p,iu.unit_code,sd.installment_status as status\r\n\t                from trns_sale_master sm\r\n\t                inner join trns_sale_detail sd on sm.challan_id=sd.challan_id\r\n\t                inner join item i on sd.item_id=i.item_id\r\n                    inner join item_unit iu on iu.unit_id=sd.unit_id\r\n\t                where sd.item_id=", itemID, "  and sd.approver_stage='F' AND sm.organization_id= ", num4, " AND sm.org_branch_reg_id=", num3, "\r\n                    and CAST(sm.date_challan AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(sm.date_challan AS DATE) <= TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                    \r\n                    \t\r\n\t\t\t\t\t\t\t\t\t\r\n\t                --gift sale part ADDED BY SABBIR \t\r\n\t\t\t\t\tUNION\r\n\r\n\t                select '-' as serial_1,'-' as date_2,0 as prarombik_jer_poriman_3,0 as prarombik_jer_mullo_4\r\n\t                ,0 as poriman_5,0 as mullo_6,0 as poriman_7, 0 as mullo_8 \r\n\t                ,'-' as name_9,'-' as address_10,'-' as national_id_11\r\n\t                ,'-' challan_no_12,'-' as date_challan_13\r\n\t                --sale part\r\n\t                , i.item_name ||'(Gift)' as biboron_14,\r\n\t\t\t\t\tgid.quantity as poriman_15,gid.price as korjoggo_mullo_16\r\n\t                , discounted_sd as sompurok_sulko_17,discounted_vat as mushok_18\r\n\t\t\t\t\t,'-' as name_19\r\n\t                ,'-' as address_20\r\n\t                ,'-'  as national_id_no_21\r\n\t\t\t\t\t,'-' as challan_no_22,to_char(gid.date_consumable_challan, 'dd/MM/yyyy') as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25,gid.remarks as montobbo_26, 3 as ord\r\n                    ,gid.date_insert as date_insert,'L' as type_p,iu.unit_code,false as status\r\n\t \t\t    \t from gift_items_detail gid\r\n\t\t\t\t\t--inner join trns_sale_master tsm on gid.challan_id=tsm.challan_id\r\n                    --inner join trns_party tp on tsm.party_id=tp.party_id\r\n                    inner join item i on gid.item_id=i.item_id\r\n                    inner join item_unit iu on gid.unit_id=iu.unit_id\r\n                    where  gid.item_id=", itemID, " AND gid.organization_id= ", num4, "  and gid.org_branch_id=", num3, "\r\n                    and CAST(gid.date_consumable_challan AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(gid.date_consumable_challan AS DATE) <= TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n\r\n\r\n                    UNION\r\n                    --purchase return--Debit Note\r\n                    select \r\n\t                --purchase part\r\n\t                 '-' as serial_1,'-' as date_2,0 as prarombik_jer_poriman_3,0 as prarombik_jer_mullo_4\r\n\t                ,0 as poriman_5,0 as mullo_6,0 as poriman_7, 0 as mullo_8 \r\n\t                ,'-' as name_9,'-' as address_10,'-' as national_id_11\r\n\t                ,'-' challan_no_12,'-' as date_challan_13\r\n\t                --sale part\r\n\t                ,i.item_name as biboron_14,pd.quantity as poriman_15,(pd.actual_price*pd.quantity) as korjoggo_mullo_16\r\n\t                , pd.return_sd as sompurok_sulko_17,pd.return_vat as mushok_18\r\n\t                ,(select party_name from trns_party where party_id=pm.party_id) as name_19\r\n\t                ,(select party_address from trns_party where party_id=pm.party_id) as address_20\r\n\t                ,(select case when party_bin!='' then party_bin else national_id_no end from trns_party where party_id=pm.party_id)  as national_id_no_21\r\n\t                ,pm.note_no as challan_no_22,to_char(pm.date_note, 'dd/MM/yyyy') as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25,pd.return_reason as montobbo_26, 4 as ord\r\n                    ,pd.date_insert as date_insert,'-' type_p,iu.unit_code,false as status\r\n\t                from trns_note_master pm\r\n\t                inner join trns_note_detail pd on pm.note_id=pd.note_id\r\n\t                inner join item i on pd.item_id=i.item_id\r\n                    inner join item_unit iu on iu.unit_id=pd.unit_id\r\n\t                where pd.item_id=", itemID, " and pm.note_type='D' AND pm.organization_id= ", num4, " AND pm.org_branch_reg_id = ", num3, "\r\n                    and CAST(pm.date_note AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(pm.date_note AS DATE) <= TO_DATE('", toDate.ToString("dd/MM/yyyy"), "', 'dd/MM/yyyy')\r\n\r\n\t\t        \tUNION\r\n                    --Sale return--Credit Note\r\n                       select \r\n\t                --purchase part\r\n\t                 '-' as serial_1,to_char(pm.date_note, 'dd/MM/yyyy') as date_2,0 as prarombik_jer_poriman_3,0 as prarombik_jer_mullo_4\r\n\t                ,pd.quantity as poriman_5,pd.quantity*pd.actual_price as mullo_6,0 as poriman_7, pd.total_price as mullo_8 \r\n\t                ,(select party_name from trns_party where party_id=pm.party_id) as name_9\r\n\t                ,(select party_address from trns_party where party_id=pm.party_id) as address_10\r\n\t                ,(select case when party_bin is not null then party_bin else national_id_no end from trns_party where party_id=pm.party_id) as national_id_11\r\n\t                ,pm.note_no as challan_no_12,to_char(pm.date_note,'dd/MM/yyyy') as date_challan_13\r\n\t                --sale part\r\n\t                 ,'-' as biboron_14,0 as poriman_15,0 as korjoggo_mullo_16, 0 as sompurok_sulko_17,0 as mushok_18\r\n\t                ,'-' as name_19,'-' as address_20,'-' as national_id_no_21,'-' as challan_no_22,'-' as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25, pd.return_reason as montobbo_26, 5 as ord\r\n                    ,pd.date_insert as date_insert,'Cr' type_p,iu.unit_code,false as status\r\n\t                from trns_note_master pm\r\n\t                inner join trns_note_detail pd on pm.note_id=pd.note_id\r\n\t                inner join item i on pd.item_id=i.item_id\r\n                    inner join item_unit iu on iu.unit_id=pd.unit_id\r\n\t                where pd.item_id=", itemID, " and pm.note_type='C' AND pm.organization_id= ", num4, " AND pm.org_branch_reg_id = ", num3, "\r\n                    and CAST(pm.date_note AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(pm.date_note AS DATE) <= TO_DATE('", toDate.ToString("dd/MM/yyyy"), "', 'dd/MM/yyyy')\r\n\r\n                    UNION\r\n                    --Mushok 6.5--Transfer Issue\r\n                    select \r\n\t                --purchase part\r\n\t                '-' as serial_1,'-' as date_2,0 as prarombik_jer_poriman_3,0 as prarombik_jer_mullo_4\r\n\t                ,0 as poriman_5,0 as mullo_6,0 as poriman_7, 0 as mullo_8 \r\n\t                ,'-' as name_9,'-' as address_10,'-' as national_id_11\r\n\t                ,'-' challan_no_12,'-' as date_challan_13\r\n\t                --sale part\r\n\t                ,i.item_name as biboron_14,td.quantity as poriman_15,0 as korjoggo_mullo_16\r\n\t                , 0 as sompurok_sulko_17,0 as mushok_18\r\n\t                ,(select branch_unit_name from org_branch_reg_info where org_branch_reg_id=tm.receiving_branch_id and organization_id=tm.organization_id) as name_19\r\n\t                ,(select org_branch_address from org_branch_reg_info where org_branch_reg_id=tm.receiving_branch_id and organization_id=tm.organization_id) as address_20\r\n\t                ,(select registration_no from org_registration_info where organization_id=tm.organization_id) as national_id_no_21\r\n\t                ,tm.challan_no as challan_no_22,to_char(tm.issues_date, 'dd/MM/yyyy') as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25,'Transfer Issue' as montobbo_26, 6 as ord\r\n                    ,td.date_insert as date_insert,'-' type_p,iu.unit_code,false as status\r\n                     from trns_transfer_master tm\r\n                     inner join trns_transfer_detail td on tm.transfer_id=td.transfer_id\r\n                     inner join item i on td.item_id=i.item_id\r\n                     inner join item_unit iu on iu.unit_id=td.unit_id\r\n                     where td.item_id=", itemID, " and tm.transfer_status='I' AND tm.organization_id= ", num4, " AND tm.issuing_branch_id = ", num3, "\r\n                     and CAST(tm.issues_date AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tm.issues_date AS DATE) <= TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n\r\n                     UNION\r\n                     --Mushok 6.5--Transfer Receive\r\n                     select \r\n                    --purchase part\r\n                    '-' as serial_1,'-' as date_2,0 as prarombik_jer_poriman_3,0 as prarombik_jer_mullo_4 \r\n                    ,td.quantity as poriman_5,0 as mullo_6,0 as poriman_7, 0 as mullo_8 \r\n\t                ,(select branch_unit_name from org_branch_reg_info where org_branch_reg_id=tm.issuing_branch_id and organization_id=tm.organization_id) as name_9\r\n\t                ,(select org_branch_address from org_branch_reg_info where org_branch_reg_id=tm.issuing_branch_id and organization_id=tm.organization_id) as address_10\r\n\t                ,(select registration_no from org_registration_info where organization_id=tm.organization_id) as national_id_11\r\n\t                ,tm.challan_no as challan_no_12,to_char(tm.issues_date,'dd/MM/yyyy') as date_challan_13\r\n\t                  --sale part\r\n\t                ,'-' as biboron_14,0 as poriman_15,0 as korjoggo_mullo_16, 0 as sompurok_sulko_17,0 as mushok_18\r\n\t                ,'-' as name_19,'-' as address_20,'-' as national_id_no_21,'-' as challan_no_22,'-' as challan_date_23\r\n\t                ,'-' as prantik_jer_poriman_24,'-' prantik_jer_mullo_25,'-' as montobbo_26, 7 as ord\r\n                    ,td.date_insert as date_insert,'-' type_p,iu.unit_code,false as status\r\n\t\t        \tfrom trns_transfer_master tm\r\n                    inner join trns_transfer_detail td on tm.transfer_id=td.transfer_id\r\n                    inner join item i on td.item_id=i.item_id\r\n                    inner join item_unit iu on iu.unit_id=td.unit_id\r\n                    where td.item_id=", itemID, " and tm.transfer_status='R' AND tm.organization_id= ", num4, " AND tm.receiving_branch_id = ", num3, "\r\n                    and CAST(tm.issues_date AS DATE) >= TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tm.issues_date AS DATE) <= TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')   order by date_insert\r\n                    , korjoggo_mullo_16 DESC    --this order of korjoggo_mullo_16 is done to serialize among main sale and gift sale in same trnsaction " };
            string str1 = string.Concat(str);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataSet rptStockDeclaration(trnsSaleMasterDAO objtrnsSaleMasterDAO)
        {
            DateTime startDate = objtrnsSaleMasterDAO.StartDate;
            DateTime dateTime = objtrnsSaleMasterDAO.StartDate.AddMonths(-1);
            string str = objtrnsSaleMasterDAO.StartDate.Date.ToString("dd/MM/yyyy");
            object[] orgName = new object[] { "select '", objtrnsSaleMasterDAO.OrgName, "' OrgName1, '", objtrnsSaleMasterDAO.OrgAddress, "' OrgAddress, '", objtrnsSaleMasterDAO.OrgBIN, "' OrgBIN, '", objtrnsSaleMasterDAO.OrgTelephone, "' OrgTelephone, '", objtrnsSaleMasterDAO.OrgAreaCode, "' OrgArea, '", objtrnsSaleMasterDAO.OrgBusinessActivity, "' OrgBusinessActivity, \r\n        '", str, "' Declaration_Date,f.idescrip Goods_Description_2, sum(f.stockprice) Stock_Price_4, sum(stock) Stock_Amount_3,\r\n\t    ((Avg_monthly_stock_price(f.Item, ", objtrnsSaleMasterDAO.OrganizationId, ", '", startDate, "')+Avg_monthly_stock_price(f.Item, ", objtrnsSaleMasterDAO.OrganizationId, ", '", dateTime, "'))/2)\r\n\t    Avg_Price_of_Stock_5  from \r\n        (select t.ides idescrip, t.itemid Item, t.lotno, sum(t.price) PurchasePrice, sum(t.purchase) p, sum(t.sale) s, ((sum(t.price)/sum(t.purchase))*(sum(t.purchase)-sum(t.sale))) StockPrice, sum(t.purchase)-sum(t.sale) stock from \r\n        (select i.item_name||E'\\r\\n'||i.hs_code ides, d.Item_id ItemId, (d.Quantity*(d.actual_price*d.Quantity)+d.Sd+d.Vat) price, d.lot_no lotno, d.detail_id DetailId, sum(d.Quantity) purchase, 0 sale from trns_purchase_master m inner join\r\n        trns_purchase_detail d on m.Challan_id=m.Challan_id inner join \r\n        Item i on d.Item_id=i.Item_id where m.Organization_id=", objtrnsSaleMasterDAO.OrganizationId, "\r\n        group by i.item_name||E'\\r\\n'||i.hs_code, d.Item_id, (d.Quantity*(d.actual_price*d.Quantity)+d.Sd+d.Vat), d.lot_no, d.detail_id \r\n        union all\r\n        select i.item_name||E'\\r\\n'||i.hs_code idescription, d.Item_id ItemId, 0 price, d.lot_no lotno, d.detail_id DetailId, 0 purchase, sum(d.Quantity) sale from trns_sale_master m inner join\r\n        trns_sale_detail d on m.Challan_id=m.Challan_id inner join\r\n        Item i on d.Item_id=i.Item_id where m.Organization_id=", objtrnsSaleMasterDAO.OrganizationId, "\r\n        group by i.item_name||E'\\r\\n'||i.hs_code, d.Item_id, d.lot_no, d.detail_id) t\r\n        group by t.ides, t.itemid, t.lotno\r\n        having sum(t.purchase)-sum(t.sale)>0\r\n        order by t.ides) f\r\n        group by f.idescrip,f.Item order by f.idescrip" };
            string str1 = string.Concat(orgName);
            return this.DBUtil.GetDataSet(str1, "Stock_Declaration_rpt");
        }
    }
}
