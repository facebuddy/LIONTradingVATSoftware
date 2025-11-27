using System;
using System.Data;
using System.Web;
using System.Web.SessionState;


namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class AccountingBookBLL
    {
        private DBUtility connDB = new DBUtility();

        private PurchaseAccountingBookDAO objPAB = new PurchaseAccountingBookDAO();

        public AccountingBookBLL()
        {
        }



        public DataTable LastProductionAccountingBook(DateTime fDate, long itemId, int branchID)
        {
            string str = "";
            string.Concat(" AND org_branch_reg_id = ", branchID);
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
            object[] objArray = new object[] { "select distinct 'S' status,m.trns_status challan_type,m.org_branch_reg_id, m.batch_no challan_no, \r\n                            to_char(m.date_production,'dd/MM/yyyy') challan_date ,m.date_production clDate, o.organization_name , o.registration_no ,\r\n                            to_char(d.Date_insert,'dd/MM/yyyy') as Date, 0 AS Quantity,m.production_quantity as utpadon_poriman,0 QuantityAct,\r\n                            i.item_name,0 vat,0 sd,i.item_type,    i.product_type,                        \r\n                            m.Remarks  Remarks , \r\n                            tp.party_name ,  tp.party_address ,d.Date_insert ,tp.party_bin ,\r\n                            m.unit_price as unit_price,(m.unit_price*m.quantity) as kor_batito_mullo, 0 vat_rate, 0 sd_rate\r\n                            ,tp.reg_type,tp.national_id_no,0 property_quantity,iu.unit_code\r\n                            from trns_production_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_production_detail d on d.production_id = m.production_id\r\n                            inner join Item i on i.item_id = m.finish_product_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                            inner join item_unit iu on iu.unit_id = m.production_unit\r\n                            where m.trns_status='R' and  cast(m.date_production as DATE) <=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND m.finish_product_id =", itemId, " AND m.organization_id= ", num4, " AND m.org_branch_reg_id = ", num3, "  AND d.Is_deleted = false  order by m.date_production desc" };
            str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }


        public DataTable GetAllFinishProduct()
        {
            return this.connDB.GetDataTable("select distinct i.item_id, i.item_name\r\n                            from trns_purchase_detail as tpd\r\n                            inner join item as i  on i.item_id = tpd.item_id\r\n                            where tpd.is_deleted = false and i.product_type = 'C'");
        }

        public DataTable GetAllFinishProductByDate(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] str = new object[] { "select distinct i.item_id, i.item_name\r\n                        from trns_purchase_master as m \r\n                        inner join trns_purchase_detail as d on m.challan_id = d.challan_id\r\n                        inner join item as i on i.item_id = d.item_id\r\n                        where m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                                and  d.is_deleted = false and i.product_type = 'C' AND m.organization_id = ", num, " and m.org_branch_reg_id=", num1, "\r\n                        order by item_id" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getAllIngredients()
        {
            return this.connDB.GetDataTable("select distinct i.item_id, i.item_name\r\n                            from trns_purchase_detail as tpd\r\n                            inner join item as i  on i.item_id = tpd.item_id\r\n                            where tpd.is_deleted = false and i.product_type = 'R'");
        }

        public DataTable GetAllIngredientsByDate(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] str = new object[] { "select distinct i.item_id, i.item_name\r\n                        from trns_purchase_master as m \r\n                        inner join trns_purchase_detail as d on m.challan_id = d.challan_id\r\n                        inner join item as i on i.item_id = d.item_id\r\n                        where m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                                and  d.is_deleted = false and i.product_type = 'R' AND m.organization_id = ", num, " and m.org_branch_reg_id=", num1, "\r\n                        order by item_id" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetAllRebatableData(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] str = new object[] { "select tpm.challan_no ||', '|| to_char(tpm.date_challan,'dd/MM/yyyy') challan_no_date, string_agg(i.item_name,', ') item,\r\n                           sum(tpd.quantity) quantity, sum(tpd.purchase_vat) rebat_amount, string_agg(tpd.remarks,',') remark\r\n                    from trns_purchase_master as tpm\r\n                    inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                    inner join item as i on tpd.item_id = i.item_id\r\n                    where tpm.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tpm.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and\r\n                          tpm.is_deleted = false and tpd.is_rebatable = true AND tpm.organization_id = ", num, " and tpm.org_branch_reg_id=", num1, "\r\n                    group by 1, tpm.date_challan\r\n                    order by tpm.date_challan" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetAllRevenue(string fDate, string tDate)
        {
            string[] strArrays = new string[] { "select \tcast(sum(pre_amount) as decimal (10,2)) pre_amount, cast(sum(imp_amount) as decimal (10,2)) imp_amount, \r\n\tcast(sum(loc_amount) as decimal (10,2)) loc_amount, cast(sum(adj_amount) as decimal (10,2)) adj_amount,\r\n        cast((sum(imp_amount)+sum(loc_amount)+sum(adj_amount)) as decimal (10,2)) rebat_total,\r\n\tcast(sum(pay_vat) as decimal (10,2)) pay_vat, \r\n\tcast(sum(pay_adj) as decimal (10,2)) pay_adj,\r\n\tcast((sum(pay_vat)+sum(pay_adj)) as decimal (10,2)) payable_total,\r\n\tcast(sum(tc_amount) as decimal (10,2)) tc_amount,\r\n\tcast(((sum(imp_amount)+sum(loc_amount)+sum(adj_amount)+sum(tc_amount))-(sum(pay_vat)+sum(pay_adj))) as decimal (10,2)) last_balance\r\nfrom\r\n(\r\nselect initial_balance pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom vat_return where date_insert >= to_date('08/01/2017','MM/dd/yyyy') and date_insert <= to_date('08/31/2017','MM/dd/yyyy')\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, sum(d.purchase_vat) imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_purchase_detail d\r\ninner join trns_purchase_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate, "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n       and m.purchase_type = 'I' and d.s_p_return = 0 and d.is_rebatable = true\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, sum(purchase_vat) loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_purchase_detail d\r\ninner join trns_purchase_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate, "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n       and m.purchase_type = 'L' and d.is_rebatable = true and d.s_p_return = 0 and m.is_deleted = false\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, sum(cast(total_vat as decimal (10,2))) adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom\r\n (\r\n\tselect coalesce(sum(d.total_vat),0)-\r\n\t\t((\r\n\t\t\tselect coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate, "','MM/dd/yyyy') and m.date_note <= to_date('", tDate, "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false \r\n\t\t)+\r\n\t\t( \tselect coalesce(sum(d.purchase_vat),0)\r\n\t\t\tfrom\r\n\t\t\ttrns_purchase_detail d\r\n\t\t\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\t\t\twhere  m.date_challan >= to_date('", fDate, "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n\t\t\tand m.purchase_type = 'L' and d.s_p_return = 1 and m.is_deleted = false\r\n\t\t\t)\r\n\t\t      ) total_vat\r\n\tfrom trns_note_detail d\r\n\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\twhere  m.date_note >= to_date('", fDate, "','MM/dd/yyyy') and m.date_note <= to_date('", tDate, "','MM/dd/yyyy')\r\n\tand d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n )muktadir\r\n\r\n/*select 0 pre_amount, 0 imp_amount, 0 loc_amount, sum(cast(total_vat as decimal (10,2))) adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom\r\n (\r\nselect coalesce(sum(d.total_vat),0)-(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\ninner join trns_note_master as m on m.note_id = d.note_id\r\nwhere  m.date_note >= to_date('", fDate, "','MM/dd/yyyy') and m.date_note <= to_date('", tDate, "','MM/dd/yyyy')\r\n      and d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false ) total_vat\r\nfrom trns_note_detail d\r\ninner join trns_note_master as m on m.note_id = d.note_id\r\nwhere  m.date_note >= to_date('", fDate, "','MM/dd/yyyy') and m.date_note <= to_date('", tDate, "','MM/dd/yyyy')\r\n      and d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n )muktadir*/\r\n\r\n\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, sum(d.vat) pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_sale_detail d\r\ninner join trns_sale_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate, "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n       and m.is_deleted = false\r\n       \r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, sum(cast(purchase_vat as decimal (10,2))) pay_adj, 0 tc_amount\r\nfrom\r\n(\r\nselect coalesce(sum(d.purchase_vat),0)-(\r\n\t\t(select sum(d.purchase_vat) from\r\n\t\t\ttrns_purchase_detail d\r\n\t\t\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\t\t\twhere  m.date_challan >= to_date('", fDate, "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n\t\t\tand m.purchase_type = 'L' and d.s_p_return = 2 and m.is_deleted = false\r\n\t\t)\r\n\t\t+\r\n\t\t(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate, "','MM/dd/yyyy') and m.date_note <= to_date('", tDate, "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d <> 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n\r\n\t\t)\r\n\t\t-\r\n\t\t(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate, "','MM/dd/yyyy') and m.date_note <= to_date('", tDate, "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d <> 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false\r\n\r\n\t\t)\r\n\r\n\t\t) purchase_vat\r\nfrom\r\n\ttrns_purchase_detail d\r\n\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\twhere  m.date_challan >= to_date('", fDate, "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n\tand m.purchase_type = 'L' and d.s_p_return = 1 and m.is_deleted = false\r\n)muktadir\r\n\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, sum(tc.amount) tc_amount\r\nfrom trns_treasury_challan tc\r\nwhere tc.date_challan >= to_date('", fDate, "','MM/dd/yyyy') and tc.date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n       and tc.is_deleted = false\r\n\r\n\r\n       \r\n)muktadir" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetAllRevenuePre(DateTime fDate, DateTime tDate)
        {
            string[] str = new string[] { "select \tcast(sum(pre_amount) as decimal (10,2)) pre_amount, cast(sum(imp_amount) as decimal (10,2)) imp_amount, \r\n\tcast(sum(loc_amount) as decimal (10,2)) loc_amount, cast(sum(adj_amount) as decimal (10,2)) adj_amount,\r\n        cast((sum(imp_amount)+sum(loc_amount)+sum(adj_amount)) as decimal (10,2)) rebat_total,\r\n\tcast(sum(pay_vat) as decimal (10,2)) pay_vat, \r\n\tcast(sum(pay_adj) as decimal (10,2)) pay_adj,\r\n\tcast((sum(pay_vat)+sum(pay_adj)) as decimal (10,2)) payable_total,\r\n\tcast(sum(tc_amount) as decimal (10,2)) tc_amount,\r\n\tcast(((sum(imp_amount)+sum(loc_amount)+sum(adj_amount)+sum(tc_amount))-(sum(pay_vat)+sum(pay_adj))) as decimal (10,2)) last_balance\r\nfrom\r\n(\r\nselect initial_balance pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom vat_return where date_insert >= to_date('08/01/2017','MM/dd/yyyy') and date_insert <= to_date('08/31/2017','MM/dd/yyyy')\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, sum(d.purchase_vat) imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_purchase_detail d\r\ninner join trns_purchase_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and m.purchase_type = 'I' and d.s_p_return = 0 and d.is_rebatable = true\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, sum(purchase_vat) loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_purchase_detail d\r\ninner join trns_purchase_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and m.purchase_type = 'L' and d.is_rebatable = true and d.s_p_return = 0 and m.is_deleted = false\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, sum(cast(total_vat as decimal (10,2))) adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom\r\n (\r\n\tselect coalesce(sum(d.total_vat),0)-\r\n\t\t((\r\n\t\t\tselect coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false \r\n\t\t)+\r\n\t\t( \tselect coalesce(sum(d.purchase_vat),0)\r\n\t\t\tfrom\r\n\t\t\ttrns_purchase_detail d\r\n\t\t\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\t\t\twhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand m.purchase_type = 'L' and d.s_p_return = 1 and m.is_deleted = false\r\n\t\t\t)\r\n\t\t      ) total_vat\r\n\tfrom trns_note_detail d\r\n\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\tand d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n )muktadir\r\n\r\n/*select 0 pre_amount, 0 imp_amount, 0 loc_amount, sum(cast(total_vat as decimal (10,2))) adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom\r\n (\r\nselect coalesce(sum(d.total_vat),0)-(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\ninner join trns_note_master as m on m.note_id = d.note_id\r\nwhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false ) total_vat\r\nfrom trns_note_detail d\r\ninner join trns_note_master as m on m.note_id = d.note_id\r\nwhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n )muktadir*/\r\n\r\n\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, sum(d.vat) pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_sale_detail d\r\ninner join trns_sale_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and m.is_deleted = false\r\n       \r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, sum(cast(purchase_vat as decimal (10,2))) pay_adj, 0 tc_amount\r\nfrom\r\n(\r\nselect coalesce(sum(d.purchase_vat),0)-(\r\n\t\t(select sum(d.purchase_vat) from\r\n\t\t\ttrns_purchase_detail d\r\n\t\t\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\t\t\twhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand m.purchase_type = 'L' and d.s_p_return = 2 and m.is_deleted = false\r\n\t\t)\r\n\t\t+\r\n\t\t(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d <> 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n\r\n\t\t)\r\n\t\t-\r\n\t\t(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d <> 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false\r\n\r\n\t\t)\r\n\r\n\t\t) purchase_vat\r\nfrom\r\n\ttrns_purchase_detail d\r\n\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\twhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\tand m.purchase_type = 'L' and d.s_p_return = 1 and m.is_deleted = false\r\n)muktadir\r\n\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, sum(tc.amount) tc_amount\r\nfrom trns_treasury_challan tc\r\nwhere tc.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tc.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and tc.is_deleted = false\r\n\r\n\r\n       \r\n)muktadir" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetAllRevenueSingle(DateTime fDate, DateTime tDate)
        {
            string[] str = new string[] { "select \tcast(sum(pre_amount) as decimal (10,2)) pre_amount, cast(sum(imp_amount) as decimal (10,2)) imp_amount, \r\n\tcast(sum(loc_amount) as decimal (10,2)) loc_amount, cast(sum(adj_amount) as decimal (10,2)) adj_amount,\r\n        cast((sum(imp_amount)+sum(loc_amount)+sum(adj_amount)) as decimal (10,2)) rebat_total,\r\n\tcast(sum(pay_vat) as decimal (10,2)) pay_vat, \r\n\tcast(sum(pay_adj) as decimal (10,2)) pay_adj,\r\n\tcast((sum(pay_vat)+sum(pay_adj)) as decimal (10,2)) payable_total,\r\n\tcast(sum(tc_amount) as decimal (10,2)) tc_amount,\r\n\tcast(((sum(imp_amount)+sum(loc_amount)+sum(adj_amount)+sum(tc_amount))-(sum(pay_vat)+sum(pay_adj))) as decimal (10,2)) last_balance\r\nfrom\r\n(\r\nselect initial_balance pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom vat_return where date_insert >= to_date('08/01/2017','MM/dd/yyyy') and date_insert <= to_date('08/31/2017','MM/dd/yyyy')\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, sum(d.purchase_vat) imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_purchase_detail d\r\ninner join trns_purchase_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and m.purchase_type = 'I' and d.s_p_return = 0 and d.is_rebatable = true\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, sum(purchase_vat) loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_purchase_detail d\r\ninner join trns_purchase_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and m.purchase_type = 'L' and d.is_rebatable = true and d.s_p_return = 0 and m.is_deleted = false\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, sum(cast(total_vat as decimal (10,2))) adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom\r\n (\r\n\tselect coalesce(sum(d.total_vat),0)-\r\n\t\t((\r\n\t\t\tselect coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false \r\n\t\t)+\r\n\t\t( \tselect coalesce(sum(d.purchase_vat),0)\r\n\t\t\tfrom\r\n\t\t\ttrns_purchase_detail d\r\n\t\t\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\t\t\twhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand m.purchase_type = 'L' and d.s_p_return = 1 and m.is_deleted = false\r\n\t\t\t)\r\n\t\t      ) total_vat\r\n\tfrom trns_note_detail d\r\n\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\tand d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n )muktadir\r\n\r\n/*select 0 pre_amount, 0 imp_amount, 0 loc_amount, sum(cast(total_vat as decimal (10,2))) adj_amount, 0 pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom\r\n (\r\nselect coalesce(sum(d.total_vat),0)-(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\ninner join trns_note_master as m on m.note_id = d.note_id\r\nwhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false ) total_vat\r\nfrom trns_note_detail d\r\ninner join trns_note_master as m on m.note_id = d.note_id\r\nwhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and d.code_id_d = 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n )muktadir*/\r\n\r\n\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, sum(d.vat) pay_vat, 0 pay_adj, 0 tc_amount\r\nfrom trns_sale_detail d\r\ninner join trns_sale_master as m on m.challan_id = d.challan_id\r\nwhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and m.is_deleted = false\r\n       \r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, sum(cast(purchase_vat as decimal (10,2))) pay_adj, 0 tc_amount\r\nfrom\r\n(\r\nselect coalesce(sum(d.purchase_vat),0)-(\r\n\t\t(select sum(d.purchase_vat) from\r\n\t\t\ttrns_purchase_detail d\r\n\t\t\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\t\t\twhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand m.purchase_type = 'L' and d.s_p_return = 2 and m.is_deleted = false\r\n\t\t)\r\n\t\t+\r\n\t\t(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d <> 4 and d.code_id_m = 31 and m.note_type = 'C' and m.is_deleted = false\r\n\r\n\t\t)\r\n\t\t-\r\n\t\t(select coalesce(sum(d.total_vat),0) from trns_note_detail d\r\n\t\t\tinner join trns_note_master as m on m.note_id = d.note_id\r\n\t\t\twhere  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\t\t\tand d.code_id_d <> 4 and d.code_id_m = 31 and m.note_type = 'D' and m.is_deleted = false\r\n\r\n\t\t)\r\n\r\n\t\t) purchase_vat\r\nfrom\r\n\ttrns_purchase_detail d\r\n\tinner join trns_purchase_master as m on m.challan_id = d.challan_id\r\n\twhere  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n\tand m.purchase_type = 'L' and d.s_p_return = 1 and m.is_deleted = false\r\n)muktadir\r\n\r\n\r\nunion all\r\n\r\nselect 0 pre_amount, 0 imp_amount, 0 loc_amount, 0 adj_amount, 0 pay_vat, 0 pay_adj, sum(tc.amount) tc_amount\r\nfrom trns_treasury_challan tc\r\nwhere tc.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tc.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n       and tc.is_deleted = false\r\n\r\n\r\n       \r\n)muktadir" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetAllVDSItem()
        {
            return this.connDB.GetDataTable("select distinct i.item_id, i.item_name\r\n                        from trns_purchase_detail as tpd\r\n                        inner join item as i  on i.item_id = tpd.item_id\r\n                        where tpd.is_deleted = false and i.is_vds = true");
        }

        public DataTable GetAllVDSItemByDate(DateTime fDate, DateTime tDate, int status)
        {
            string str = HttpContext.Current.Session["ORGANIZATION_ID"].ToString();
            string empty = string.Empty;
            if (status == 1)
            {
                string[] strArrays = new string[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,m.challan_no, to_char(m.date_challan,'dd-Mon-yyyy') date_challan,\r\n                        p.party_name,i.item_name ||' - '|| i.hs_code_suffix item, case when  m.credit_amount=0 then CAST(coalesce(d.quantity,0)*coalesce(d.purchase_unit_price,0)as decimal(18,2)) \r\n                        when m.credit_amount!=0 and (m.bank_amount !=0 or m.cash_amount!=0) then  (m.bank_amount+m.cash_amount)\r\n                        when m.credit_amount!=0 and (m.bank_amount =0 and m.cash_amount=0) then CAST(cth.payment_amount as decimal(18,2)) end item_amount,ttd.amount vds_amount, CAST(d.vat_rate as decimal(18,1)) percent,\r\n                        ttd.vds_certificate_no vds_cert_issued_no\r\n                       ,TO_CHAR(ttd.vds_certificate_date :: DATE, 'dd-Mon-yyyy') AS vds_cert_issued_date\r\n                       ,To_Char(ttc.date_challan, 'dd-Mon-yyyy') trdate_challan,ttc.tr_challan_no challan_numbers, \r\n                        ttd.amount amount,CONCAT(CAST(d.vat_rate as decimal(18,1)),'%',' ','VDS',' ',case when  cth.tr_challan_status is not null then 'Partially TR Challan Paid' end) remarks                   \r\n                        from trns_purchase_master as m\r\n                        inner join trns_purchase_detail as d on m.challan_id = d.challan_id \r\n                        inner join item as i on i.item_id = d.item_id\r\n                        inner join trns_party p  on p.party_id = m.party_id\r\n                        inner join trns_treasury_detail ttd on  m.challan_id=ttd.purchase_challan_id\r\n                        inner join trns_treasury_challan ttc on  ttd.tr_challan_id = ttc.challan_id\r\n                        left join credit_transac_history cth on cth.scroll_id=ttd.scroll_id\r\n                        where CAST(ttd.vds_certificate_date as DATE) >=  to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND CAST(ttd.vds_certificate_date as DATE) <=  to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND d.is_deleted = false AND m.organization_id=", str, "\r\n                        AND ttd.vds_certificate_no is not null order by ttd.vds_certificate_date" };
                empty = string.Concat(strArrays);
            }
            if (status == 2)
            {
                string[] str1 = new string[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,m.challan_no, to_char(m.date_challan,'dd-Mon-yyyy') date_challan,\r\n                       p.party_name,i.item_name ||' - '|| i.hs_code_suffix item, case when  m.credit_amount=0 then CAST(coalesce(d.quantity,0)*coalesce(d.purchase_unit_price,0)as decimal(18,2)) \r\n                        when m.credit_amount!=0 and (m.bank_amount !=0 or m.cash_amount!=0) then  (m.bank_amount+m.cash_amount)\r\n                        when m.credit_amount!=0 and (m.bank_amount =0 and m.cash_amount=0) then CAST(cth.payment_amount as decimal(18,2)) end item_amount,\r\n                       --ttd.amount vds_amount,\r\n                        d.vds_amount,CAST(d.vat_rate as decimal(18,1)) percent,\r\n                        ttd.vds_certificate_no vds_cert_issued_no\r\n                       ,TO_CHAR(ttd.vds_certificate_date :: DATE, 'dd-Mon-yyyy') AS vds_cert_issued_date\r\n                       ,To_Char(ttc.date_challan, 'dd-Mon-yyyy') trdate_challan,ttc.tr_challan_no challan_numbers, ttd.amount amount,CONCAT(CAST(d.vat_rate as decimal(18,1)),'%',' ','VDS',' ',case when  cth.tr_challan_status is not null then 'Partially TR Challan Paid' end) remarks                   \r\n                        from trns_purchase_master as m\r\n                        inner join trns_purchase_detail as d on m.challan_id = d.challan_id \r\n                        inner join item as i on i.item_id = d.item_id\r\n                        inner join trns_party p  on p.party_id = m.party_id\r\n                        left join trns_treasury_detail ttd on  m.challan_id=ttd.purchase_challan_id\r\n                        left join trns_treasury_challan ttc on  ttd.tr_challan_id = ttc.challan_id\r\n                        left join credit_transac_history cth on cth.scroll_id=ttd.scroll_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND d.is_deleted = false AND m.organization_id=", str, "\r\n                        AND ttd.vds_certificate_no is null and d.is_source_tax_deduct=true" };
                empty = string.Concat(str1);
            }
            if (status == 3)
            {
                string[] strArrays1 = new string[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,m.challan_no, to_char(m.date_challan,'dd-Mon-yyyy') date_challan,\r\n                       p.party_name,i.item_name ||' - '|| i.hs_code_suffix item, case when  m.credit_amount=0 then CAST(coalesce(d.quantity,0)*coalesce(d.purchase_unit_price,0)as decimal(18,2)) \r\n                        when m.credit_amount!=0 and (m.bank_amount !=0 or m.cash_amount!=0) then  (m.bank_amount+m.cash_amount)\r\n                        when m.credit_amount!=0 and (m.bank_amount =0 and m.cash_amount=0) then CAST(cth.payment_amount as decimal(18,2)) end item_amount,ttd.amount vds_amount, CAST(d.vat_rate as decimal(18,1)) percent,\r\n                        ttd.vds_certificate_no vds_cert_issued_no\r\n                       ,TO_CHAR(ttd.vds_certificate_date :: DATE, 'dd-Mon-yyyy') AS vds_cert_issued_date\r\n                       ,To_Char(ttc.date_challan, 'dd-Mon-yyyy') trdate_challan,ttc.tr_challan_no challan_numbers, ttd.amount amount,CONCAT(CAST(d.vat_rate as decimal(18,1)),'%',' ','VDS',' ',case when  cth.tr_challan_status is not null then 'Partially TR Challan Paid' end) remarks                   \r\n                        from trns_purchase_master as m\r\n                        inner join trns_purchase_detail as d on m.challan_id = d.challan_id \r\n                        inner join item as i on i.item_id = d.item_id\r\n                        inner join trns_party p  on p.party_id = m.party_id\r\n                        inner join trns_treasury_detail ttd on  m.challan_id=ttd.purchase_challan_id\r\n                        inner join trns_treasury_challan ttc on  ttd.tr_challan_id = ttc.challan_id\r\n                        left join credit_transac_history cth on cth.scroll_id=ttd.scroll_id\r\n                        where CAST(ttc.date_challan as DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND CAST(ttc.date_challan as DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND d.is_deleted = false AND m.organization_id=", str, "\r\n                        AND d.is_source_tax_deduct=true" };
                empty = string.Concat(strArrays1);
            }
            if (status == 4)
            {
                string[] str2 = new string[] { "select (case when tpm.vds_cert_issued_no is not null then To_Char(tpm.vds_cert_issued_date, 'dd-Mon-yyyy') else '' end ) vds_cert_issued_date, \r\n                            To_Char(cth.payment_date, 'dd-Mon-yyyy') payment_date ,tpm.vds_cert_issued_no,\r\n                            tp.party_name,tpm.challan_no,To_Char(tpm.date_challan, 'dd-Mon-yyyy') date_challan,i.item_name ||' - '|| i.hs_code_suffix item, coalesce(sum(tpd.quantity*tpd.purchase_unit_price),0) item_amount,\r\n                            coalesce(sum(tpd.purchase_vat),0) purchase_vat, coalesce(sum(tpd.vds_amount),0) vds_amount, \r\n                            0 amount, --tpd.remarks, \r\n                           CAST(tpd.vat_rate as decimal(18,1)) percent, '' remarks \r\n                            ,To_Char(tc.date_challan, 'dd-Mon-yyyy') trdate_challan,tc.challan_numbers challan_numbers\r\n                            from trns_purchase_master tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i  on i.item_id = tpd.item_id\r\n                           left join trns_treasury_challan tc on tpm.challan_no = tc.challan_numbers\r\n                            inner join trns_party tp on tp.party_id=tpm.party_id       \r\n                            left join credit_transac_history cth on  tpm.challan_id = cth.challan_id   \r\n                            where CAST(tpm.date_challan as DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND CAST(tpm.date_challan as DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                            and tpd.is_deleted = false and tpd.is_source_tax_deduct = true and tpm.organization_id=", str, "\r\n                            group by tpd.vat_rate,tpm.vds_cert_issued_date,cth.payment_date ,tpm.vds_cert_issued_no,tpm.date_challan,tpm.challan_no,tp.party_name,i.item_name,i.hs_code_suffix,tpm.Is_deleted,is_vat_paid\r\n                            ,tc.date_challan,tc.challan_numbers \r\n                             having --sum(Sd.Vat)>0 \r\n                             sum(tpd.purchase_vat)>0\r\n                             and tpm.Is_deleted=false and is_vat_paid=false" };
                empty = string.Concat(str2);
            }
            if (status == -99)
            {
                string[] strArrays2 = new string[] { "select (case when ttd.vds_certificate_no is not null then To_Char(ttd.vds_certificate_date, 'dd-Mon-yyyy') else '' end ) vds_cert_issued_date, To_Char(cth.payment_date, 'dd-Mon-yyyy') payment_date,cth.payment_date orderDate,\r\nttd.vds_certificate_no vds_cert_issued_no,tp.party_name,tpm.challan_no,To_Char(tpm.date_challan, 'dd-Mon-yyyy') date_challan,i.item_name ||' - '|| i.hs_code_suffix item, coalesce(sum(tpd.quantity*tpd.purchase_unit_price),0) item_amount,\r\n                        coalesce(sum(tpd.purchase_vat),0) purchase_vat, coalesce(sum(tpd.vds_amount),0) vds_amount, coalesce(sum(tc.amount),0) amount, --tpd.remarks, \r\n                       CAST(tpd.vat_rate as decimal(18,1)) percent, '' remarks \r\n                        ,To_Char(tc.date_challan, 'dd-Mon-yyyy') trdate_challan,tc.challan_numbers\r\n                            from trns_purchase_master tpm\r\n                            inner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i  on i.item_id = tpd.item_id\r\n                        left join trns_treasury_detail ttd on  tpm.challan_id=ttd.purchase_challan_id\r\n                        left join trns_treasury_challan tc on  ttd.tr_challan_id = tc.challan_id\r\n                           -- left join trns_treasury_challan tc on tpm.challan_no = tc.challan_numbers\r\n                            inner join trns_party tp on tp.party_id=tpm.party_id \r\n                            left join credit_transac_history cth on  tpm.challan_id = cth.challan_id             \r\n                            where CAST(tpm.date_challan as DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND CAST(tpm.date_challan as DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                            and tpd.is_deleted = false and tpd.is_source_tax_deduct = true and tpm.organization_id=", str, "\r\n                          group by tpd.vat_rate,ttd.vds_certificate_date,cth.payment_date ,ttd.vds_certificate_no,tpm.date_challan,tpm.challan_no,tp.party_name,i.item_name,i.hs_code_suffix,tc.date_challan,tc.challan_numbers \r\n               union all\r\n                      (select '' vds_cert_issued_date,To_Char(cth.payment_date, 'dd-Mon-yyyy') payment_date,cth.payment_date orderDate,'' vds_cert_issued_no,tp.party_name,tpm.challan_no,To_Char(tpm.date_challan, 'dd-Mon-yyyy') date_challan,i.item_name ||' - '|| i.hs_code_suffix item, coalesce(sum(tpd.quantity*tpd.actual_price),0) item_amount,\r\n                       coalesce(sum(tpd.vat),0) vat, coalesce(sum(case when tpd.vds_amount = 0 or tpd.vds_amount is null then tpd.vat else tpd.vds_amount end),0) vds_amount, \r\n                       coalesce(sum(tc.amount),0) amount, --tpd.remarks, \r\n                       CAST(tpd.vat_rate as decimal(18,1)) percent,\r\n                      '' remarks ,To_Char(tc.date_challan, 'dd-Mon-yyyy') trdate_challan,tc.challan_numbers\r\n                            from trns_sale_master tpm\r\n                            inner join trns_sale_detail as tpd on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i  on i.item_id = tpd.item_id\r\n                            left join trns_treasury_challan tc on tpm.challan_no = tc.challan_numbers\r\n                            inner join trns_party tp on tp.party_id=tpm.party_id\r\n                            left join credit_transac_history cth on  tpm.challan_id = cth.challan_id \r\n                            where CAST(tpm.date_challan as DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        AND CAST(tpm.date_challan as DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                            and tpd.is_deleted = false and tpd.is_source_tax_deduct = true and tpm.organization_id=", str, "\r\n                             group by tpd.vat_rate,cth.payment_date ,vds_cert_issued_no,tpm.date_challan,tpm.challan_no,tp.party_name,i.item_name,i.hs_code_suffix,tc.date_challan,tc.challan_numbers order by tpm.date_challan) order by orderDate" };
                empty = string.Concat(strArrays2);
            }
            return this.connDB.GetDataTable(empty);
        }

        public DataTable getCSVDataForPurchaseBookReport(string fromDate, string toDate)
        {
            string[] strArrays = new string[] { "  select m.challan_no, coalesce(o.organization_name,'')||' '|| coalesce(o.registration_no,'') Org_BIN, d.Date_insert ::timestamp::Date, (d.purchase_vat+d.purchase_sd) Amount, CASE WHEN d.Remarks='' THEN 'N/A' ELSE d.Remarks END, NOW() ::timestamp::Date Date\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND d.Is_deleted = false" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getCSVDataForPurchaseBookReportByItemId(string fromDate, string toDate, int itemId)
        {
            object[] objArray = new object[] { "  select m.challan_no, coalesce(o.organization_name,'')||' '|| coalesce(o.registration_no,'') Org_BIN, d.Date_insert ::timestamp::Date, (d.purchase_vat+d.purchase_sd) Amount, CASE WHEN d.Remarks='' THEN 'N/A' ELSE d.Remarks END, NOW() ::timestamp::Date Date\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND Item_id = '", itemId, "' AND d.Is_deleted = false" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getCSVDataForSaleBookReport(string fromDate, string toDate)
        {
            string[] strArrays = new string[] { " select m.challan_no, coalesce(o.organization_name,'')||' '|| coalesce(o.registration_no,'') Org_BIN, d.Date_insert ::timestamp::Date, (d.Vat+d.Sd) Amount, NOW() ::timestamp::Date Date\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND d.Is_deleted = false" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getCSVDataForSaleBookReportByProductID(string fromDate, string toDate, int itemId)
        {
            object[] objArray = new object[] { " select m.challan_no, coalesce(o.organization_name,'')||','|| coalesce(o.registration_no,'') Org_BIN, d.Date_insert ::timestamp::Date, (d.Vat+d.Sd) Amount, NOW() ::timestamp::Date Date\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND Item_id = '", itemId, "'  AND d.Is_deleted = false" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getDataForPurchaseBookReport(string fromDate, string toDate)
        {
            string[] strArrays = new string[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, (d.purchase_vat+d.purchase_sd) Amount, d.Remarks, NOW() ::timestamp::Date Date\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND d.Is_deleted = false" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataForPurchaseBookReport(string fromDate, string toDate, int itemID, char purchaseType, int branchID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND i.item_id = '", itemID, "'");
            }
            if (purchaseType != 'A')
            {
                str1 = string.Concat(" AND m.purchase_type = '", purchaseType, "'");
            }
            if (branchID <= 0)
            {
                string[] strArrays = new string[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, d.Quantity as purchase_quantity,\r\n                            d.Remarks, tp.party_name, tp.party_bin\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "'", str, " ", str1, " AND d.Is_deleted = false order by date_insert" };
                str2 = string.Concat(strArrays);
            }
            else
            {
                object[] objArray = new object[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, d.Quantity as purchase_quantity,\r\n                            d.Remarks, tp.party_name, tp.party_bin\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "'", str, " ", str1, " AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, " order by date_insert" };
                str2 = string.Concat(objArray);
            }
            return this.connDB.GetDataTable(str2);
        }

        public DataTable GetDataForPurchaseBookReport2(string fromDate, string toDate, int itemID, char purchaseType, string partyName, string challanNo, int branchID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            if (purchaseType != 'A')
            {
                str1 = string.Concat(" AND m.purchase_type = '", purchaseType, "'");
            }
            if (partyName != "")
            {
                str3 = string.Concat("AND tp.party_name = '", partyName, "'");
            }
            if (challanNo != "")
            {
                string.Concat("AND tp.party_name = '", partyName, "'");
            }
            if (branchID <= 0)
            {
                string[] strArrays = new string[] { "select 'P' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin ,d.Date_insert\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <='", toDate, "' ", str, " ", str3, " ", str1, "  AND d.Is_deleted = false \r\n\r\n                       \r\n   UNION ALL\r\n\r\n                select 'S' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >= '", fromDate, "' AND m.date_challan <= '", toDate, "' ", str, " ", str3, "  AND d.Is_deleted = false\r\n\r\n    UNION ALL\r\n\r\n                select 'Pr' status,m.org_branch_reg_id, m.challan_batch_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert\r\n                            from trns_production_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_production_detail d\r\n                            on d.Production_id = m.Production_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_production >= '", fromDate, "' AND m.date_production <= '", toDate, "' \r\n                           ", str, " ", str3, " AND m.trns_status='I'  AND d.Is_deleted = false  \r\n                  --order by Date\r\n\r\nUNION ALL\r\n\r\n          select 'T' status,m.receiving_branch_id as org_branch_reg_id, m.challan_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            d.Remarks , obri.branch_unit_name , obri.branch_unit_bin ,d.Date_insert\r\n                            from trns_transfer_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_transfer_detail d\r\n                            on d.transfer_id = m.transfer_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                           -- inner join trns_party tp\r\n                            inner join org_branch_reg_info as obri\r\n                            on obri.org_branch_reg_id = m.receiving_branch_id\r\n                            where m.date_insert >= '", fromDate, "' AND m.date_insert <= '", toDate, "' \r\n                           ", str, "   AND m.transfer_status='I'  AND d.Is_deleted = false \r\n                  order by Date_insert" };
                str2 = string.Concat(strArrays);
            }
            else
            {
                object[] objArray = new object[] { "select 'P' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin,d.Date_insert \r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <='", toDate, "' ", str, " ", str1, " ", str3, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n\r\n                       \r\n   UNION ALL\r\n\r\n                    select 'S' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >= '", fromDate, "' AND m.date_challan <= '", toDate, "' ", str, " ", str3, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n\r\n    UNION ALL\r\n\r\n                    select 'Pr' status,m.org_branch_reg_id, m.challan_batch_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert\r\n                            from trns_production_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_production_detail d\r\n                            on d.Production_id = m.Production_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_production >= '", fromDate, "' AND m.date_production <= '", toDate, "' \r\n                           ", str, "  ", str3, " AND m.trns_status='I'  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n                  --order by Date\r\n\r\nUNION ALL\r\n\r\n          select 'T' status,m.receiving_branch_id as org_branch_reg_id, m.challan_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            d.Remarks , obri.branch_unit_name , obri.branch_unit_bin ,d.Date_insert\r\n                            from trns_transfer_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_transfer_detail d\r\n                            on d.transfer_id = m.transfer_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                           -- inner join trns_party tp\r\n                            inner join org_branch_reg_info as obri\r\n                            on obri.org_branch_reg_id = m.receiving_branch_id\r\n                            where m.date_insert >= '", fromDate, "' AND m.date_insert <= '", toDate, "'\r\n                           ", str, "   AND m.transfer_status='I'  AND d.Is_deleted = false and m.receiving_branch_id=", branchID, "\r\n                  order by Date_insert" };
                str2 = string.Concat(objArray);
            }
            return this.connDB.GetDataTable(str2);
        }

        public DataTable getDataForPurchaseBookReportByItemId(string fromDate, string toDate, int itemId)
        {
            object[] objArray = new object[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, (d.purchase_vat+d.purchase_sd) Amount, d.Remarks, NOW() ::timestamp::Date Date\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND Item_id = '", itemId, "' AND d.Is_deleted = false" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getDataForPurchaseBookReportByItemId(string fromDate, string toDate, int id, string chaNo, string bin, string partyName, string purchaseType, string td)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            if (id > 0)
            {
                str = string.Concat(" AND i.item_id = '", id, "'");
                str1 = string.Concat(" AND item_id = '", id, "'");
            }
            if (chaNo != "")
            {
                str2 = string.Concat(" AND m.challan_no = '", chaNo, "'");
            }
            if (bin != "")
            {
                str3 = string.Concat(" AND tp.party_bin = '", bin, "'");
            }
            if (partyName != "")
            {
                str4 = string.Concat(" AND tp.party_name = '", partyName, "'");
            }
            if (purchaseType != "")
            {
                str5 = string.Concat(" AND m.purchase_type = '", purchaseType, "'");
            }
            object[] objArray = new object[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date,d.Quantity crrQuantity,\r\n                            --(select sum(Quantity)  from trns_purchase_detail where date_insert >='", fromDate, "' AND date_insert <= '", toDate, "' and item_id='", id, "') crrQuantity,\r\n                            d.Remarks, NOW() ::timestamp::Date Date,tp.party_name, tp.party_bin,\r\n                            ((select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_purchase_detail where date_insert >='2010-01-01' AND date_insert <= '", td, "'", str1, ")\r\n                                    -\r\n                            (select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_sale_detail where date_insert >='2010-01-01' AND date_insert <= '", td, "'", str1, "))  PreQuantity\r\n                            --(select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_sale_detail where date_insert >='", fromDate, "' AND date_insert <= '", toDate, "'", str1, ") usedQuantity\r\n                            --(select case when Quantity is null then 0 else Quantity end  from trns_sale_detail where date_insert >='", fromDate, "' AND date_insert <= '", toDate, "'", str1, ") usedQuantity\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "'", str, " ", str2, " ", str3, " ", str4, " ", str5, " AND d.Is_deleted = false" };
            string str6 = string.Concat(objArray);
            return this.connDB.GetDataTable(str6);
        }

        public DataTable getDataForSaleBookReport(string fromDate, string toDate)
        {
            string[] strArrays = new string[] { " select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, (d.Vat+d.Sd) Amount, NOW() ::timestamp::Date Date\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND d.Is_deleted = false" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataForSaleBookReport(string fromDate, string toDate, int itemID, string purchaseType)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND i.item_id = '", itemID, "'");
            }
            if (purchaseType != "")
            {
                str1 = string.Concat(" AND m.purchase_type = '", purchaseType, "'");
            }
            string[] strArrays = new string[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, d.Quantity as purchase_quantity,\r\n                            d.Remarks, tp.party_name, tp.party_bin\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "'", str, " ", str1, " AND d.Is_deleted = false order by date_insert" };
            string str2 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str2);
        }

        public DataTable GetDataForSaleBookReport2(string fromDate, string toDate, int itemID)
        {
            string str = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND i.item_id = '", itemID, "'");
            }
            string[] strArrays = new string[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, d.Quantity as purchase_quantity,\r\n                            d.Remarks, tp.party_name, tp.party_bin\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "'", str, " AND d.Is_deleted = false order by date_insert" };
            string str1 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetDataForSaleBookReport2Sale(string fromDate, string toDate, int itemID)
        {
            string str = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND i.item_id = '", itemID, "'");
            }
            string[] strArrays = new string[] { "  select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, d.Quantity as sale_quantity,\r\n                            m.Remarks, tp.party_name, tp.party_bin\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "'", str, " AND d.Is_deleted = false order by date_insert" };
            string str1 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getDataForSaleBookReportByProductID(string fromDate, string toDate, int itemId)
        {
            object[] objArray = new object[] { " select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, (d.Vat+d.Sd) Amount, NOW() ::timestamp::Date Date\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "' AND Item_id = '", itemId, "'  AND d.Is_deleted = false" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataForSalesAccountingBook(string fDate, string tDate, int itemId, int branchID)
        {
            string str = "";
            string.Concat(" AND org_branch_reg_id = ", branchID);
            if (branchID <= 0)
            {
                object[] objArray = new object[] { "select 'S' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.item_id =", itemId, "  AND d.Is_deleted = false \r\n                UNION ALL\r\n\r\n                        select 'P' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin ,d.Date_insert\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fDate, "' AND m.date_challan <='", tDate, "' AND d.item_id =", itemId, "  AND d.Is_deleted = false \r\n\r\n                            order by Date_insert" };
                str = string.Concat(objArray);
            }
            else
            {
                object[] objArray1 = new object[] { "select 'S' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin,d.Date_insert \r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.item_id =", itemId, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n                UNION ALL\r\n\r\n                        select 'P' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin,d.Date_insert \r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fDate, "' AND m.date_challan <='", tDate, "' AND d.item_id =", itemId, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n\r\n                            order by Date_insert" };
                str = string.Concat(objArray1);
            }
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataForSalesRepportAll(string fDate, string tDate, int branchID)
        {
            string str = "";
            string.Concat(" AND org_branch_reg_id = ", branchID);
            if (branchID <= 0)
            {
                string[] strArrays = new string[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert,\r\n                            case when m.trans_type='L' then 'Local'\r\n                                 when m.trans_type='E' then 'Export' end trans_type,\r\n                            d.vat, d.sd, d.actual_price,i.item_name\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.Is_deleted = false  order by Date_insert" };
                str = string.Concat(strArrays);
            }
            else
            {
                object[] objArray = new object[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, d.Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin,d.Date_insert,\r\n                            case when m.trans_type='L' then 'Local'\r\n                                 when m.trans_type='E' then 'Export' end trans_type,\r\n                            d.vat, d.sd, d.actual_price,i.item_name \r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n               \r\n                            order by Date_insert" };
                str = string.Concat(objArray);
            }
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataForSalesRepportSingle(string fDate, string tDate, int itemId, int branchID)
        {
            string str = "";
            string.Concat(" AND org_branch_reg_id = ", branchID);
            if (branchID <= 0)
            {
                object[] objArray = new object[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert,\r\n                            case when m.trans_type='L' then 'Local'\r\n                                 when m.trans_type='E' then 'Export' end trans_type,\r\n                            d.vat, d.sd, d.actual_price\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.item_id =", itemId, "  AND d.Is_deleted = false \r\n                \r\n                            order by Date_insert" };
                str = string.Concat(objArray);
            }
            else
            {
                object[] objArray1 = new object[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, d.Quantity ,\r\n                            m.Remarks , tp.party_name , tp.party_bin,d.Date_insert,\r\n                            case when m.trans_type='L' then 'Local'\r\n                                 when m.trans_type='E' then 'Export' end trans_type,\r\n                            d.vat, d.sd, d.actual_price \r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.item_id =", itemId, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n               \r\n                            order by Date_insert" };
                str = string.Concat(objArray1);
            }
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDetailData(DateTime fDate, DateTime tDate, int itemID)
        {
            object[] objArray = new object[] { "select item_name, sum(pre_quantity) pre_quantity, sum(pre_amount) pre_amount ,sum(imp_quantity) imp_quantity,sum(imp_amount) imp_amount, \r\n       sum(bin_quantity) bin_quantity, sum(bin_amount) bin_amount, sum(nobin_quantity) nobin_quantity, sum(nobin_amount) nobin_amount,\r\n        (sum(pre_quantity)+sum(imp_quantity)+sum(bin_quantity)+sum(nobin_quantity)) total_quantity,\r\n        (sum(pre_amount)+sum(imp_amount)+sum(bin_amount)+sum(nobin_amount)) total_amount,\r\n        sum(pro_quantity) pro_quantity,sum(pro_amount) pro_amount,\r\n        ((sum(pre_quantity)+sum(imp_quantity)+sum(bin_quantity)+sum(nobin_quantity))-sum(pro_quantity)) last_quantity,\r\n        ((sum(pre_amount)+sum(imp_amount)+sum(bin_amount)+sum(nobin_amount))-sum(pro_amount)) last_amount\r\nfrom\r\n(\r\nselect (select item_name from item where item_id = ", itemID, ") item_name, SUM(quantity) as pre_quantity, SUM(quantity*(select purchase_unit_price from trns_purchase_detail where item_id = ", itemID, " order by item_id desc limit 1)) as pre_amount, 0 imp_quantity, 0 imp_amount,0 bin_quantity, 0 bin_amount,\r\n       0 nobin_quantity, 0 nobin_amount,0 pro_quantity, 0 pro_amount\r\n\tfrom\r\n\t(\r\n\tselect SUM(d.quantity) \r\n\t        - \r\n\t        ((select coalesce(sum(d.Quantity),0)\r\n                    from trns_production_detail as d\r\n                     inner join trns_production_master as m\r\n                     on d.production_id = m.production_id\r\n                     where d.date_insert >=to_date('01/01/1991','MM/dd/yyyy') AND d.date_insert <= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.status in('I','S') and d.item_id = ", itemID, ")\r\n                +\r\n                (select coalesce(sum(d.Quantity),0)  \r\n                    from trns_sale_detail as d \r\n                    inner join trns_sale_master as m\r\n                    on d.challan_id = m.challan_id\r\n                    where d.date_insert >=to_date('01/01/1991','MM/dd/yyyy') AND d.date_insert <= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.item_id = ", itemID, ")\r\n\t\t+\r\n\t\t(select coalesce(sum(d.Quantity),0) \r\n                     from trns_transfer_detail as d\r\n                     inner join trns_transfer_master as m\r\n                     on d.transfer_id = m.transfer_id\r\n                     where d.date_insert >=to_date('01/01/1991','MM/dd/yyyy') AND d.date_insert <= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.transfer_status = 'I' and d.item_id = ", itemID, " )\r\n                    ) quantity\r\n\t\r\n\t from trns_purchase_master as m\r\n\t inner join trns_purchase_detail as d on m.challan_id = d.challan_id\r\n\t where m.date_challan >= to_date('01/01/1991','MM/dd/yyyy') and m.date_challan <= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.item_id = ", itemID, "\r\n\t \r\n         \r\n\t)trns_purchase_detail\r\n\t \r\n\r\nUNION ALL\r\n\r\nselect i.item_name, 0 pre_quantity, 0 pre_amount, SUM(tpd.quantity) as imp_quantity, SUM(tpd.quantity*tpd.purchase_unit_price) as imp_amount,0 bin_quantity, 0 bin_amount,\r\n        0 nobin_quantity, 0 nobin_amount,0 pro_quantity, 0 pro_amount\r\nfrom trns_purchase_master as tpm\r\ninner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\ninner join item as i on i.item_id = tpd.item_id\r\nwhere tpm.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tpm.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and tpd.item_id = ", itemID, " and tpm.purchase_type = 'I'\r\ngroup by i.item_name\r\n\r\nUNION ALL\r\n\r\nselect i.item_name, 0 pre_quantity, 0 pre_amount,0 imp_quantity, 0 imp_amount,  SUM(tpd.quantity) as bin_quantity, SUM(tpd.quantity*tpd.purchase_unit_price) as bin_amount,\r\n        0 nobin_quantity, 0 nobin_amount,0 pro_quantity, 0 pro_amount\r\nfrom trns_purchase_master as tpm\r\ninner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\ninner join item as i on i.item_id = tpd.item_id\r\ninner join trns_party as tp on tp.party_id = tpm.party_id\r\nwhere tpm.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tpm.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and tpd.item_id = ", itemID, " and tpm.purchase_type = 'L' and tp.party_bin <> ''\r\ngroup by i.item_name\r\n\r\nUNION ALL\r\n\r\nselect i.item_name, 0 pre_quantity, 0 pre_amount,0 imp_quantity, 0 imp_amount,0 bin_quantity, 0 bin_amount,  \r\n       SUM(tpd.quantity) as nobin_quantity, SUM(tpd.quantity*tpd.purchase_unit_price) as nobin_amount,0 pro_quantity, 0 pro_amount\r\nfrom trns_purchase_master as tpm\r\ninner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\ninner join item as i on i.item_id = tpd.item_id\r\ninner join trns_party as tp on tp.party_id = tpm.party_id\r\nwhere tpm.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tpm.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and tpd.item_id = ", itemID, " and tpm.purchase_type = 'L' and tp.party_bin = ''\r\ngroup by i.item_name\r\n\r\nUNION ALL\r\n\r\nselect i.item_name, 0 pre_quantity, 0 pre_amount,0 imp_quantity, 0 imp_amount,0 bin_quantity, 0 bin_amount,0 nobin_quantity, 0 nobin_amount,   \r\n       SUM(tpd.quantity) as pro_quantity, SUM(tpd.quantity*(select purchase_unit_price from trns_purchase_detail where item_id = ", itemID, " order by item_id desc limit 1)) as pro_amount\r\nfrom trns_production_master as tpm\r\ninner join trns_production_detail as tpd on tpm.production_id = tpd.production_id\r\ninner join item as i on i.item_id = tpd.item_id\r\nwhere tpm.date_production >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tpm.date_production <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and tpd.item_id = ", itemID, " and tpm.material_type = 'I'\r\ngroup by i.item_name\r\n\r\n)muktadir group by item_name" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDetailDataForFinishProduct(DateTime fDate, DateTime tDate, int itemID)
        {
            object[] objArray = new object[] { "select item_name,sum(pre_quantity) pre_quantity,sum(pre_amount) pre_amount,sum(pro_quantity) pro_quantity,sum(pro_amount) pro_amount,\r\n       (sum(pre_quantity)+sum(pro_quantity)) total_quantity, (sum(pre_amount)+sum(pro_amount)) total_amount,\r\n       sum(sale_quantity) sale_quantity, sum(sale_amount) sale_amount,\r\n       ((sum(pre_quantity)+sum(pro_quantity))-sum(sale_quantity)) last_quantity,\r\n       ((sum(pre_amount)+sum(pro_amount))- sum(sale_amount)) last_amount\r\nfrom\r\n(\r\nselect (select item_name from item where item_id = ", itemID, ") item_name, SUM(quantity) as pre_quantity, \r\n\tSUM(quantity*(select purchase_unit_price from trns_purchase_detail where item_id = ", itemID, " order by item_id desc limit 1)) as pre_amount,\r\n\t0 pro_quantity, 0 pro_amount, 0 sale_quantity, 0 sale_amount\r\n\tfrom\r\n\t(\r\n\tselect SUM(d.quantity) \r\n\t        - \r\n\t        ((select coalesce(sum(d.Quantity),0)  \r\n                    from trns_sale_detail as d \r\n                    inner join trns_sale_master as m\r\n                    on d.challan_id = m.challan_id\r\n                    where d.date_insert >=to_date('01/01/1991','dd/MM/yyyy') AND d.date_insert <= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.item_id = ", itemID, ")\r\n\t\t+\r\n\t\t(select coalesce(sum(d.Quantity),0) \r\n                     from trns_transfer_detail as d\r\n                     inner join trns_transfer_master as m\r\n                     on d.transfer_id = m.transfer_id\r\n                     where d.date_insert >=to_date('01/01/1991','dd/MM/yyyy') AND d.date_insert <= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and m.transfer_status = 'I' and d.item_id = ", itemID, " )\r\n                    ) quantity\r\n\t\r\n\t from trns_purchase_master as m\r\n\t inner join trns_purchase_detail as d on m.challan_id = d.challan_id\r\n\t where m.date_challan >= to_date('01/01/1991','dd/MM/yyyy') and m.date_challan <= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.item_id = ", itemID, "\r\n\t \r\n         \r\n\t)trns_purchase_detail\r\n\r\nUNION ALL\r\n\r\nselect i.item_name, 0 pre_quantity, 0 pre_amount, SUM(tpd.quantity) as pro_quantity, SUM(tpd.quantity*tpd.purchase_unit_price) as pro_amount,\r\n\t0 sale_quantity, 0 sale_amount\r\nfrom trns_purchase_master as tpm\r\ninner join trns_purchase_detail as tpd on tpm.challan_id = tpd.challan_id\r\ninner join item as i on i.item_id = tpd.item_id\r\nwhere tpm.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tpm.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and tpd.item_id = ", itemID, " and tpm.purchase_type = 'F' and tpm.challan_type = 'C'\r\ngroup by i.item_name\r\n\r\nUNION ALL\r\n\r\nselect i.item_name, 0 pre_quantity, 0 pre_amount,0 pro_quantity, 0 pro_amount,\r\n       SUM(tsd.quantity) as sale_quantity, SUM(tsd.quantity*tsd.actual_price) as sale_amount\r\nfrom trns_sale_master as tsm\r\ninner join trns_sale_detail as tsd on tsm.challan_id = tsd.challan_id\r\ninner join item as i on i.item_id = tsd.item_id\r\ninner join trns_party as tp on tp.party_id = tsm.party_id\r\nwhere tsm.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and tsm.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n      and tsd.item_id = ", itemID, " and tsd.type_p='F'\r\ngroup by i.item_name\r\n\r\n)muktadir group by item_name" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
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
            return Convert.ToInt64(this.connDB.GetSingleValue(str2));
        }

        public long GetEarlyAvailableStockForSale(string toDate, int itemID)
        {
            if (itemID > 0)
            {
                string.Concat(" AND item_id = ", itemID);
            }
            object[] objArray = new object[] { " select distinct\r\n                        ((select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_purchase_detail d inner join trns_purchase_master m on d.challan_id=m.challan_id where CAST(m.date_challan as DATE) <= '", toDate, "'  AND item_id = ", itemID, " and d.approver_stage='F')\r\n                            -\r\n                       ( (select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_sale_detail d inner join trns_sale_master m on d.challan_id=m.challan_id  where CAST(m.date_challan as DATE) <= '", toDate, "'  AND item_id =", itemID, " and d.approver_stage='F')\r\n                         \r\n                            +\r\n                       (select  coalesce(sum(Quantity),0)   from gift_items_detail   where CAST(date_challan as DATE) <= '", toDate, "'  AND item_id =", itemID, ")\r\n\r\n                       )\r\n                       ) as earlyAvailableStock\r\n                        from trns_purchase_detail" };
            string str = string.Concat(objArray);
            return Convert.ToInt64(this.connDB.GetSingleValue(str));
        }

        public DataTable GetEarlyAvailableStockUnitForSale(string toDate, int itemID)
        {
            if (itemID > 0)
            {
                string.Concat(" AND item_id = ", itemID);
            }
            object[] objArray = new object[] { "select iu.unit_code from trns_purchase_detail d\r\n                            inner join trns_purchase_master m on d.challan_id=m.challan_id\r\n                            inner join item i on d.item_id = i.item_id\r\n                            inner join item_unit iu on iu.unit_id = i.unit_id\r\n                            where CAST(m.date_challan as DATE) <= '", toDate, "'  AND i.item_id = ", itemID };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetOpeningBalanceStock(int itemID, DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select op.item_qty ,op.item_value,to_char(op.opening_balance_date,'dd/MM/yyyy') opening_balance_date,iu.unit_code from opening_balance op\r\n                     inner join item_unit iu on op.unit_id=iu.unit_id\r\n                     where item_id=", itemID, " and organization_id=", num, " and org_branch_reg_id=", num1, " and cast (opening_balance_date as Date) >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and cast (opening_balance_date as Date) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPriceDeclarationData(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] str = new object[] { "select to_char(pi.date_insert,'dd-Mon-yyyy') pd_submit_date,to_char(pi.date_effective,'dd-Mon-yyyy') pd_approve_date,\r\n               i.item_name ||'-'|| i.hs_code_suffix item,iu.unit_name sale_unit, \r\n               (select coalesce(sum(p.txtquantityprice),0) rm_price from price_raw_item p where p.price_id = pi.price_id and p.is_deleted = false ),\r\n               case when pi.prpsd_actl_prc_vat = 0 then (pi.prpsd_actl_prc+pi.sd_amount+pi.crnt_actl_prc_vat) else (pi.prpsd_actl_prc_vat+pi.crnt_actl_prc_vat) end proposed_amount,\r\n               (select coalesce(sum(paa.cnfrmd_item_value),0) others_value from price_value_addition_area as paa where paa.price_id = pi.price_id and paa.is_deleted = false),\r\n               (select coalesce(tax_value,0) vat from item_tax_values where item_id = pi.item_id and tax_id = 4 and is_deleted = false and tax_value!=0 and is_tran_sale=true),\r\n               pi.cnfrmd_actl_prc_vat confirmed_price\r\n       \r\n        from price_item as pi\r\n        inner join item as i on pi.item_id = i.item_id\r\n        inner join item_unit as iu on pi.unit_id = iu.unit_id\r\n        where pi.date_insert >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and pi.date_insert <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n       and pi.price_declaration_no <> 'No' and pi.is_deleted = false  AND pi.organization_id = ", num, " and pi.org_branch_reg_id=", num1, "\r\n        order by pi.date_insert" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetPSAvgValue(int itemID)
        {
            object[] objArray = new object[] { "\r\n                    select max(purchase_unit_price) purchase_unit_price,max(vat_rate) vat_rate,max(sd_rate) sd_rate, max(sale_unit_price) sale_unit_price\r\n                    from\r\n                    (\r\n                    select case when SUM(quantity)=0 then 0\r\n\t\telse SUM(quantity*purchase_unit_price)/SUM(quantity) end purchase_unit_price, 0  sale_unit_price, vat_rate,sd_rate\r\n                    from trns_purchase_detail where item_id = ", itemID, " group by vat_rate,sd_rate\r\n\r\n                    UNION ALL \r\n\r\n                    select 0 purchase_unit_price, SUM(quantity*actual_price)/SUM(quantity) sale_unit_price,0 vat_rate, 0 sd_rate\r\n                    from trns_sale_detail where item_id = ", itemID, "\r\n\r\n                    )muktadir " };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPurchaseBookReportforMIS(string fromDate, string toDate, int itemID, char purchaseType, string partyName, string challanNo, int branchID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            if (purchaseType != 'A')
            {
                str1 = string.Concat(" AND m.purchase_type = '", purchaseType, "'");
            }
            if (partyName != "")
            {
                str3 = string.Concat("AND tp.party_name = '", partyName, "'");
            }
            if (challanNo != "")
            {
                string.Concat("AND tp.party_name = '", partyName, "'");
            }
            if (branchID <= 0)
            {
                string[] strArrays = new string[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin,d.Date_insert,d.purchase_unit_price, d.purchase_vat, d.purchase_sd,m.scroll_no, \r\n                            case when m.purchase_type = 'L' then 'Local'\r\n                                 when m.purchase_type = 'I' then 'Import' end purchase_type \r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <='", toDate, "' AND d.Is_deleted = false AND s_p_return = 0 ", str, " ", str1, " ", str3, " order by Date_insert " };
                str2 = string.Concat(strArrays);
            }
            else
            {
                object[] objArray = new object[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin,d.Date_insert,d.purchase_unit_price, d.purchase_vat, d.purchase_sd,m.scroll_no,\r\n                            case when m.purchase_type = 'L' then 'Local'\r\n                                 when m.purchase_type = 'I' then 'Import' end purchase_type \r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <='", toDate, "' AND d.Is_deleted = false AND s_p_return = 0 ", str, " ", str1, " ", str3, " AND m.org_branch_reg_id = ", branchID, " order by Date_insert " };
                str2 = string.Concat(objArray);
            }
            return this.connDB.GetDataTable(str2);
        }

        public DataTable GetPurchaseBookReportforMISAll(string fromDate, string toDate, int branchID)
        {
            string str = "";
            if (branchID <= 0)
            {
                string[] strArrays = new string[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin,d.Date_insert,d.purchase_unit_price, d.purchase_vat, d.purchase_sd,m.scroll_no, \r\n                            case when m.purchase_type = 'L' then 'Local'\r\n                                 when m.purchase_type = 'I' then 'Import' end purchase_type ,i.item_name\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <='", toDate, "' AND d.Is_deleted = false AND s_p_return = 0  order by Date_insert " };
                str = string.Concat(strArrays);
            }
            else
            {
                object[] objArray = new object[] { "select m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin,d.Date_insert,d.purchase_unit_price, d.purchase_vat, d.purchase_sd,m.scroll_no,\r\n                            case when m.purchase_type = 'L' then 'Local'\r\n                                 when m.purchase_type = 'I' then 'Import' end purchase_type ,i.item_name\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <='", toDate, "' AND d.Is_deleted = false AND s_p_return = 0  AND m.org_branch_reg_id = ", branchID, " order by Date_insert " };
                str = string.Concat(objArray);
            }
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPurchaseData(DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] str = new string[] { "select cast(coalesce(sum(d.quantity*d.purchase_unit_price),0) as decimal(20,2)) purchase_amount, \r\n                               m.challan_no ||'# '||to_char(m.date_challan,'dd-MON-yyyy') purchase_challan_date,m.challan_id\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        where m.is_deleted = false\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <=  to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        group by m.challan_no,m.date_challan,m.challan_id\r\n                        order by m.challan_id" };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetPurchaseDataByChallanID(long ChallanID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select m.challan_id,m.challan_no, i.item_name, iu.unit_code,d.quantity, d.purchase_unit_price unit_price,\r\n                            d.quantity*d.purchase_unit_price total_price, coalesce(d.purchase_vat,0) vat, coalesce(d.purchase_sd,0) sd,\r\n                            ((d.quantity*d.purchase_unit_price)+coalesce(d.purchase_vat,0)+coalesce(d.purchase_sd,0)) grand_total,\r\n                            to_char(m.date_challan,'dd/MM/yyyy') date_challan \r\n                            from trns_purchase_master m\r\n                            inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                            inner join item i on d.item_id = i.item_id\r\n                            inner join item_unit iu on d.unit_id = iu.unit_id\r\n                            where m.challan_id = ", ChallanID, " and m.is_deleted = false");
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getPurchaseDataByDate(string fromDate, string toDate)
        {
            string[] strArrays = new string[] { "select distinct i.item_name,i.Item_id\r\n                         from trns_purchase_detail d\r\n                         inner join Item i\r\n                         on d.Item_id = i.Item_id\r\n                         where d.date_insert >='", fromDate, "' AND d.date_insert <= '", toDate, "' \r\n\r\n                         union\r\n\r\n                         select distinct i.item_name,i.Item_id\r\n                         from trns_production_detail d\r\n                         inner join Item i\r\n                         on d.Item_id = i.Item_id\r\n                         where d.date_insert >='", fromDate, "' AND d.date_insert <= '", toDate, "'\r\n\r\n                         union \r\n\r\n                         select distinct i.item_name,i.Item_id\r\n                         from trns_transfer_detail d\r\n                         inner join Item i\r\n                         on d.Item_id = i.Item_id\r\n                         where d.date_insert >='", fromDate, "' AND d.date_insert <= '", toDate, "' order by item_name" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPurchaseDetailByFTDate(string fDate, string tDate, int itemId)
        {
            object[] objArray = new object[] { "select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, d.Quantity ,\r\n                            m.Remarks, tp.party_name, tp.party_bin\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.item_id = ", itemId, " AND d.Is_deleted = false order by date_insert" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPurchaseHistoryDate(string fDate, string tDate, int itemId)
        {
            object[] objArray = new object[] { "select to_char(date_insert,'yyyy-MM-dd') as date_insert from trns_purchase_detail where date_insert>='", fDate, "' AND date_insert<='", tDate, "' AND item_id = ", itemId, " order by date_insert" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetSaleAllItem()
        {
            return this.connDB.GetDataTable("select distinct i.item_name, i.item_id from item as i --inner join trns_sale_detail as m on m.item_id = i.item_id");
        }

        public DataTable GetSaleAllItem2()
        {
            return this.connDB.GetDataTable("select distinct i.item_name, i.item_id from item as i inner join trns_sale_detail as m on m.item_id = i.item_id order by i.item_name");
        }

        public DataTable GetSaleAllItem62()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { "select distinct item_name, item_id from\r\n                            (select distinct i.item_name, i.item_id from item as i\r\n                        inner join trns_purchase_detail d on d.item_id = i.item_id\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        where (m.Purchase_type = 'F' OR m.challan_type in ('C','O') ) and i.product_type='C'  and i.organization_id=", num, "\r\n                        union all\r\n                            select distinct item_name ,ii.Item_id from Item ii\r\n                            inner join gift_items_detail gid on gid.item_id = ii.item_id\r\n                            where ii.Is_deleted = false  and gid.organization_id=", num, ") a" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetSaleAllItemForReport62()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select distinct i.item_name, i.item_id from item as i\r\n                        inner join trns_purchase_detail d on d.item_id = i.item_id\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        where m.Purchase_type = 'F' OR m.challan_type = 'C' AND m.organization_id =", num, "\r\n                        --order by i.item_name\r\n\r\n                        union all\r\n                        select distinct i.item_name, i.item_id from item as i\r\n                        inner join trns_sale_detail sd on sd.item_id = i.item_id\r\n                        inner join trns_sale_master sm on sd.challan_id = sm.challan_id\r\n                        where i.item_type = 'S' AND sm.organization_id = ", num };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetSaleData(DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] str = new string[] { "select cast(coalesce(sum(d.quantity*d.actual_price),0) as decimal(20,2)) sale_amount,\r\n                               m.challan_no ||'# '||to_char(m.date_challan,'dd-MON-yyyy') sale_challan_date,m.challan_id\r\n                        from trns_sale_master m\r\n                        inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                        where m.is_deleted = false\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <=  to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        group by m.challan_no,m.date_challan,m.challan_id\r\n                        order by m.challan_id" };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetSaleDataByChallanID(long ChallanID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select m.challan_id,m.challan_no, i.item_name, iu.unit_code,d.quantity, d.actual_price unit_price,\r\n                                d.quantity*d.actual_price total_price, coalesce(d.vat,0) vat, coalesce(d.sd,0) sd,\r\n                                ((d.quantity*d.actual_price)+coalesce(d.vat,0)+coalesce(d.sd,0)) grand_total,\r\n                                to_char(m.date_challan,'dd/MM/yyyy') date_challan \r\n                                from trns_sale_master m\r\n                                inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                inner join item_unit iu on d.unit_id = iu.unit_id\r\n                                where m.challan_id = ", ChallanID, " and m.is_deleted = false");
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getSaleDataByDate(string fromDate, string toDate)
        {
            string[] strArrays = new string[] { "select distinct i.item_name,i.Item_id\r\n                           from trns_sale_detail d\r\n                           inner join Item i\r\n                           on d.Item_id = i.Item_id\r\n                           where d.date_insert >='", fromDate, "' AND d.date_insert <= '", toDate, "' and d.type_p <> 'F'\r\n\r\n                        union \r\n\r\n                         select distinct i.item_name,i.Item_id\r\n                         from trns_purchase_detail d\r\n                         inner join Item i\r\n                         on d.Item_id = i.Item_id\r\n                         inner join trns_purchase_master as m\r\n                         on m.challan_id = d.challan_id\r\n                         where m.challan_type='C' and purchase_type='F'" };
            string str = string.Concat(strArrays);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getSaleDataForSaleBookReport(string fromDate, string toDate, int itemId, string challanNo, string partyName, char trnsType, string bin, string pD)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            if (itemId > 0)
            {
                str = string.Concat(" AND i.item_id = '", itemId, "'");
                str1 = string.Concat(" AND item_id = '", itemId, "'");
            }
            if (challanNo != "")
            {
                str2 = string.Concat(" AND m.challan_no = '", challanNo, "'");
            }
            if (bin != "")
            {
                str3 = string.Concat(" AND tp.party_bin = '", bin, "'");
            }
            if (partyName != "")
            {
                str4 = string.Concat(" AND tp.party_name = '", partyName, "'");
            }
            str5 = string.Concat(" AND m.trans_type = '", trnsType, "'");
            string[] strArrays = new string[] { " select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, NOW() ::timestamp::Date Date, d.Quantity crrQuantity,\r\n                            m.Remarks, tp.party_name, tp.party_bin,\r\n                            (select sum(Quantity)  from trns_sale_detail where date_insert >='2010-01-01' AND date_insert <= '", pD, "'", str1, ")PreQuantity\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fromDate, "' AND m.date_challan <= '", toDate, "'", str, " ", str2, " ", str3, " ", str4, " ", str5, " AND d.Is_deleted = false" };
            string str6 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str6);
        }

        public DataTable GetSaleDetailByFTDate(string fDate, string tDate, int itemId)
        {
            object[] objArray = new object[] { "select m.challan_no, o.organization_name, o.registration_no, d.Date_insert ::timestamp::Date, d.Quantity ,\r\n                            m.Remarks, tp.party_name, tp.party_bin\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >='", fDate, "' AND m.date_challan <= '", tDate, "' AND d.item_id = ", itemId, " AND d.Is_deleted = false order by date_insert" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetSaleHistoryDate(string fDate, string tDate, int itemId)
        {
            object[] objArray = new object[] { "select to_char(date_insert,'yyyy-MM-dd') as date_insert from trns_sale_detail where date_insert>='", fDate, "' AND date_insert<='", tDate, "' AND item_id = ", itemId, " order by date_insert" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public long GetSaleQuantityByftDate(string fDate, string tDate, int itemId)
        {
            object[] objArray = new object[] { "select distinct\r\n                        ((select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_sale_detail where date_insert >='", fDate, "' AND date_insert <= '", tDate, "' \r\n                        and item_id = ", itemId, ")\r\n                        +(select case when sum(Quantity) is null then 0 else sum(Quantity) end from trns_production_detail where date_insert >='", fDate, "' AND date_insert <= '", tDate, "' \r\n                        and status = 'R' and item_id = ", itemId, " )) as  sale_quantity\r\n                        from trns_production_detail \r\n                        where is_deleted = false" };
            string str = string.Concat(objArray);
            return Convert.ToInt64(this.connDB.GetSingleValue(str));
        }

        public long GetSaleQuantityForSABByftDate(string fDate, string tDate, int itemId)
        {
            object[] objArray = new object[] { "select distinct\r\n                        ((select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_sale_detail where date_insert >='", fDate, "' AND date_insert <= '", tDate, "' \r\n                        and item_id = ", itemId, ")\r\n                        +(select case when sum(Quantity) is null then 0 else sum(Quantity) end from trns_production_detail where date_insert >='", fDate, "' AND date_insert <= '", tDate, "' \r\n                        and status = 'R' and item_id = ", itemId, " )) as  sale_quantity\r\n                        from trns_production_detail \r\n                        where is_deleted = false" };
            string str = string.Concat(objArray);
            return Convert.ToInt64(this.connDB.GetSingleValue(str));
        }

        public DataTable GetSaleQuantitywise(DateTime fDate, DateTime tDate, int itemId)
        {
            string str = "";
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            if (itemId != -99)
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) As detail\r\n                         , iu.unit_code ,i.hs_code, (case when d.item_serials<>'' THEN CONCAT(i.item_name,'(',d.item_serials,')') ELSE i.item_name END) AS item_name,d.Quantity,i.weight,  d.Quantity*d.actual_price  as price, d.sd sd, d.vat vat,Concat((fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))) ,'%',' VAT') remarks\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m\r\n                            on d.challan_id = m.challan_id\r\n                            inner join item as i on i.item_id =d.item_id\r\n                            inner join item_unit as iu on iu.unit_id =i.weight_unit_id\r\n                            where cast(m.date_challan as DATE) >=TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                            AND cast(m.date_challan as DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "', 'dd/MM/yyyy')\r\n                            AND d.is_deleted = false AND m.organization_id=", num, "   \r\n                            AND m.sale_type = 'S' and d.item_id=", itemId };
                str = string.Concat(objArray);
            }
            else
            {
                object[] str1 = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) As detail\r\n                         , iu.unit_code ,i.hs_code, (case when d.item_serials<>'' THEN CONCAT(i.item_name,'(',d.item_serials,')') ELSE i.item_name END) AS item_name,d.Quantity,i.weight,  d.Quantity*d.actual_price  as price, d.sd sd, d.vat vat,Concat((fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))) ,'%',' VAT') remarks\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m\r\n                            on d.challan_id = m.challan_id\r\n                            inner join item as i on i.item_id =d.item_id\r\n                            inner join item_unit as iu on iu.unit_id =i.weight_unit_id\r\n                            where cast(m.date_challan as DATE) >=TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                            AND cast(m.date_challan as DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "', 'dd/MM/yyyy')\r\n                            AND d.is_deleted = false AND m.organization_id=", num, "   \r\n                            AND m.sale_type = 'S'  and d.approver_stage='F'" };
                str = string.Concat(str1);
            }
            return this.connDB.GetDataTable(str);
        }

        public decimal getTotalProPrice(DataTable lotList, decimal req_amount)
        {
            decimal reqAmount = req_amount;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            int num3 = 0;
            while (num3 < lotList.Rows.Count)
            {
                num1 = Convert.ToDecimal(lotList.Rows[num3]["quantity"]);
                num2 = Convert.ToDecimal(lotList.Rows[num3]["purchase_unit_price"]);
                if (reqAmount <= new decimal(0))
                {
                    break;
                }
                if (req_amount > num1)
                {
                    if (reqAmount > num1)
                    {
                        num = num + (reqAmount * num2);
                        reqAmount -= num1;
                    }
                    else if (reqAmount <= num1)
                    {
                        num = num + (reqAmount * num2);
                        reqAmount -= reqAmount;
                    }
                    num3++;
                }
                else
                {
                    num = num + (req_amount * num2);
                    break;
                }
            }
            return num;
        }

        public DataTable getUnit(int itemID)
        {
            string str = string.Concat("select distinct iu.unit_id, iu.unit_code,iu.unit_name\r\n                            from item_unit as iu\r\n                            left join item as i\r\n                            on i.unit_id = iu.unit_id\r\n                            where i.item_id = ", itemID);
            return this.connDB.GetDataTable(str);
        }

        public int getUsedQuantity(string fDate, string tDate, int itemId)
        {
            object[] objArray = new object[] { " select case when  sum(Quantity) is null then 0 else sum(Quantity) end usedQuantity from trns_sale_detail\r\n            where date_insert >='", fDate, "' AND date_insert <= '", tDate, "' AND item_id = '", itemId, "' AND Is_deleted = false " };
            string str = string.Concat(objArray);
            return Convert.ToInt32(this.connDB.GetSingleValue(str));
        }

        public DataTable SalesAccountingBook(DateTime fDate, DateTime tDate, int itemId, int branchID)
        {
            string str = "";
            string.Concat(" AND org_branch_reg_id = ", branchID);
            object[] objArray = new object[] { "Select * from (\r\n                        (select distinct 'S' status,m.trns_status challan_type,m.org_branch_reg_id, m.batch_no challan_no, \r\n                            to_char(m.date_production,'dd/MM/yyyy') challan_date ,m.date_production clDate, o.organization_name , o.registration_no ,\r\n                            to_char(d.Date_insert,'dd/MM/yyyy') as Date, 0 AS Quantity,m.production_quantity as utpadon_poriman,0 QuantityAct,\r\n                            i.item_name,0 vat,0 sd,i.item_type,    i.product_type,                        \r\n                            m.Remarks  Remarks , \r\n                            tp.party_name ,  tp.party_address ,d.Date_insert ,tp.party_bin ,\r\n                            m.unit_price as unit_price,(m.unit_price*m.quantity) as kor_batito_mullo, 0 vat_rate, 0 sd_rate\r\n                            ,tp.reg_type,tp.national_id_no,0 property_quantity,iu.unit_code\r\n                            from trns_production_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_production_detail d on d.production_id = m.production_id\r\n                            inner join Item i on i.item_id = m.finish_product_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                            inner join item_unit iu on iu.unit_id = m.production_unit\r\n                            where m.trns_status='R' and  cast(m.date_production as DATE) >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND cast( m.date_production as DATE) <= TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND m.finish_product_id =", itemId, "  AND d.Is_deleted = false  order by m.date_production)\r\n                            UNION ALL\r\n                            select 'S' status,'S' challan_type,m.org_branch_reg_id, m.challan_no, to_char(m.date_challan,'dd/MM/yyyy') challan_date ,m.date_challan clDate, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, d.sale_Quantity,0 as utpadon_poriman,d.sale_Quantity QuantityAct,\r\n                            i.item_name,d.vat,d.sd,i.item_type,i.product_type, \r\n                            case when m.challan_type = 'D' then 'Dispose Data' else m.Remarks end Remarks , \r\n                            tp.party_name ,  tp.party_address ,d.Date_insert ,tp.party_bin ,d.actual_price as unit_price,0 as kor_batito_mullo, 0 vat_rate, 0 sd_rate\r\n                            ,tp.reg_type,tp.national_id_no,coalesce(property_quantity,0),iu.unit_code\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id = d.sale_unit\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                           where cast(m.date_challan as DATE) >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND cast(m.date_challan as DATE) <= TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND d.item_id =", itemId, "  AND d.Is_deleted = false  and d.approver_stage='F'\r\n                           \r\nUNION ALL\r\nselect 'G' status,'' challan_type,tsm.org_branch_reg_id, tsm.challan_no, to_char(m.date_challan,'dd/MM/yyyy') challan_date ,m.date_challan clDate, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, d.sale_Quantity,0 as utpadon_poriman,m.Quantity QuantityAct,\r\n                            i.item_name,d.vat,d.sd,i.item_type,i.product_type, \r\n                            case when tsm.challan_type = 'D' then 'Dispose Data' else m.Remarks end Remarks , \r\n                            tp.party_name ,  tp.party_address ,d.Date_insert ,tp.party_bin ,(m.price/m.quantity) as unit_price,0 as kor_batito_mullo, 0 vat_rate, 0 sd_rate\r\n                            ,tp.reg_type,tp.national_id_no,coalesce(property_quantity,0),iu.unit_code\r\n                            from gift_items_detail m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_master tsm on m.Challan_id = tsm.Challan_id\r\n                            inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = m.item_id\r\n                            inner join item_unit iu on iu.unit_id = d.sale_unit\r\n                            left join trns_party tp on tp.party_id = tsm.party_id\r\n                           where cast(m.date_challan as DATE) >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND cast(m.date_challan as DATE) <= TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND m.item_id =", itemId, "  AND d.Is_deleted = false \r\n\r\n\r\nUNION ALL\r\n                            select 'S' status,'' challan_type,m.org_branch_reg_id, m.note_no challan_no, to_char(m.date_note,'dd/MM/yyyy') challan_date ,m.date_note clDate, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, \r\n                           0 quantity ,d.credit_Quantity as utpadon_poriman,d.quantity QuantityAct,\r\n                            i.item_name,d.return_vat,d.return_sd,i.item_type,i.product_type, \r\n                           -- case when m.challan_type = 'D' then 'Dispose Data' else m.Remarks end Remarks , \r\n                           d.return_reason Remarks , \r\n                            tp.party_name ,  tp.party_address ,d.Date_insert ,tp.party_bin ,d.actual_price as unit_price,d.credit_Quantity*d.actual_price as kor_batito_mullo, 0 vat_rate, 0 sd_rate\r\n                            ,tp.reg_type,tp.national_id_no,0 property_quantity,iu.unit_code\r\n                            from trns_note_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_note_detail d on d.note_id = m.note_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join item_unit iu on iu.unit_id = d.credit_unit\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                            where cast(m.date_note as DATE) >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND cast(m.date_note as DATE) <= TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND d.item_id =", itemId, "  AND d.Is_deleted = false AND note_type='C'\r\n                           ) a\r\n\r\n                        order by clDate, challan_type" };
            str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }
    }
}