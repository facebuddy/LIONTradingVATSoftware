using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class wsKGCVATApi : WebService
    {
        private DBUtility db = new DBUtility();

        public wsKGCVATApi()
        {
        }

        private DataTable getNewDataTableWithBalance(DataTable dtCurrentAccount)
        {
            decimal num = new decimal(0);
            for (int i = 0; i < dtCurrentAccount.Rows.Count; i++)
            {
                decimal num1 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["treasury_deposit"]);
                decimal num2 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["exempt_amount"]);
                decimal num3 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["pay_amount"]);
                decimal num4 = (num1 + num2) - num3;
                short num5 = Convert.ToInt16(dtCurrentAccount.Rows[i]["balance_action"]);
                if (i != 0)
                {
                    if (num5 != 1)
                    {
                        num += num4;
                    }
                    else
                    {
                        num += num4;
                    }
                    dtCurrentAccount.Rows[i]["balance_amount"] = num;
                }
                else
                {
                    num = Convert.ToDecimal(dtCurrentAccount.Rows[0]["balance_amount"]);
                }
            }
            return dtCurrentAccount;
        }

        private DataTable Vat_11(DateTime fDate, DateTime tDate, int partyID)
        {
            DataTable dataTable = new DataTable();
            string str = "";
            try
            {
                if (partyID > 0)
                {
                    str = string.Concat(str, " and tp.Party_id = ", partyID);
                }
                string[] strArrays = new string[] { "SELECT tp.party_name Customer_name, coalesce(tp.party_address::varchar(250),'--') Customer_Address, coalesce(tp.party_tin::varchar(150),'--') Customer_TIN, \r\n                            coalesce(tsm.ultimate_destination::varchar(150),'--') Goods_Services_Shipping_Address, \r\n                            acd.code_name Vehicle_Type, tsm.challan_no Challan_No, to_char(tsm.date_challan,'dd-MON-yyyy') Challan_Date, to_char(tsm.date_challan::Time, 'HH24:MI') Challan_Time, \r\n                            to_char(tsm.date_goods_delivery,'dd-MON-yyyy') Goods_Unload_Date,to_char(tsm.date_goods_delivery::Time, 'HH24:MI') Goods_Unload_Time, tsm.vehicle_no Vehicle_No, row_number() over (order by i.item_name nulls last) as Sl_No,\r\n                            i.item_name Goods_Services_Name, \r\n                            tsd.Quantity Quantity, tsd.actual_price unit_Price, tsd.Sd SD_Amount,(tsd.Quantity*tsd.actual_price+tsd.Sd) total_price_sd, tsd.Vat VAT_Amount,\r\n                            (tsd.Quantity*tsd.actual_price+tsd.Sd+tsd.Vat) total_price_sd_vat,\r\n\r\n                           -- to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),1,2)))||' '||substr(to_char(date_challan, 'dd/yyyy/MONTH'),9)||' '||to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),7,4))) TextDate,\r\n                           -- to_text(int2(substr(to_char(date_challan, 'HH24:mi'),1,2)))||' HOUR '||to_text(int2(substr(to_char(date_challan, 'hh:mi'),4,2)))||' MINUTE' TextTime, \r\n                            (acd.code_name||'  '||tsm.vehicle_no) Vehicle \r\n                        FROM trns_sale_master tsm \r\n                        inner join trns_sale_detail tsd on tsm.Challan_id=tsd.Challan_id\r\n                        inner join trns_party tp on tsm.Party_id = tp.Party_id\r\n                        left join app_code_detail acd on tsm.vehicle_type_m = acd.code_id_m AND tsm.vehicle_type_d=acd.code_id_d\r\n                        inner join item i on tsd.Item_id = i.Item_id\r\n                        WHERE tsm.challan_type='S'\r\n                        and tsm.Is_deleted=false \r\n                        and tsm.date_challan>= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                        and tsm.date_challan<= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ", str, "  \r\n                        order by tsm.date_challan" };
                string str1 = string.Concat(strArrays);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        private DataTable Vat_18(DateTime fromDate, DateTime toDate)
        {
            int num = 0;
            DataTable dataTable = new DataTable();
            try
            {
                object[] str = new object[] { "select to_char(Date(d.date_challan),'dd-MON-yyyy') date_challan,d.trns_desc,d.challan_no,d.tresury_deposit treasury_deposit,d.exempt_amount,d.pay_amount,d.others,d.balance_amount,d.balance_action from (\r\n            /*B/F*/\r\n            select to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') date_challan,'B/F' trns_desc,'' challan_no,0 tresury_deposit,0 exempt_amount,0 pay_amount,0 others,sum(d.exempt_amount-d.payment_amount) balance_amount,0 balance_action , '' Remarks\r\n            from ( \r\n/*\r\nselect sum(tpd.Sd+tpd.Vat) exempt_amount,0 payment_amount from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id  \r\n            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P'\r\n            and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') --and tpm.Organization_id = ", num, "\r\n            and ((tpm.purchase_type = 'L' and (tpd.is_source_tax_deduct = false or tpd.is_exempted = false)) or\r\n            (tpm.purchase_type = 'I' and (tpd.is_source_tax_deduct = true or tpd.is_exempted = true)))\r\n            union all\r\n            select coalesce(sum(ttc.Amount),0) exempt_amount,0 payment_amount from trns_treasury_challan ttc\r\n            where ttc.Is_deleted = false and ttc.chalan_type_m = 9 and ttc.chalan_type_d = 1 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') --and ttc.Organization_id = ", num, "\r\n            union all\r\n            select sum(tnd.rbt_vat-tnd.dif_vat) exempt_amount,0 payment_amount from trns_note_detail tnd\r\n            inner join trns_note_master tnm on tnm.note_id = tnd.note_id\r\n            where tnm.Is_deleted = false and tnd.Is_deleted = false and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tnm.note_type = 'D' --and tnm.Organization_id = ", num, "\r\n            union all\r\n            select 0 exempt_amount,sum(tsd.Vat) payment_amount from trns_sale_detail tsd \r\n            inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id\r\n            where tsm.Is_deleted = false and tsd.Is_deleted = false and tsm.challan_type = 'S' and tsm.trans_type in ('L','E') --and tsm.Organization_id = ", num, "\r\n            and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            union all\r\n            select 0 exempt_amount, sum(tpd.Sd+tpd.Vat) payment_amount\r\n            from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id \r\n            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P' and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and ((tpm.purchase_type = 'L' and (tpd.is_source_tax_deduct = true or tpd.is_exempted = true) ) or\r\n            (tpm.purchase_type = 'I' and (tpd.is_source_tax_deduct = false or tpd.is_exempted = false))) --and tpm.Organization_id = ", num, "\r\n            union all\r\n            select 0 exempt_amount,sum(tnd.rbt_vat-tnd.dif_vat) payment_amount\r\n            from trns_note_detail tnd\r\n            inner join trns_note_master tnm on tnm.note_id = tnd.note_id\r\n            where tnm.Is_deleted = false and tnd.Is_deleted = false and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tnm.note_type = 'C' --and tnm.Organization_id = ", num, "\r\n            */\r\n\r\n\r\n /*1  sale_sd + sale_vat*/\r\n\r\n select 0 exempt_amount, sum(tsd.Sd) + sum(tsd.Vat) payment_amount\r\n  from trns_sale_detail tsd\r\n            inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id\r\n            where tsm.challan_type = 'S' and tsm.Is_deleted = false \r\n             and Date(date_challan) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and tsd.is_source_tax_deduct = false and tsd.is_exempted = false and (tsd.Sd >0 or tsd.Vat > 0) and tsm.trans_type = 'L'\r\n            --and tsm.Organization_id = ", num, " \r\n\r\n/*16 treasury_deposit*/\r\n            union all\r\n            select \r\n           coalesce(sum(ttc.Amount),0) exempt_amount,  0 payment_amount\r\n            from trns_treasury_challan ttc\r\n            where ttc.Is_deleted = false  and ttc.date_challan < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and ttc.chalan_type_d = 1 --and ttc.Organization_id = ", num, " \r\n\r\n            union all\r\n             /*5 other_adj*/\r\n            select 0 exempt_amount, coalesce(sum(d.other_adj) ,0) payment_amount \r\n            from ( \r\n           \r\n            select coalesce(sum(tsd.Vat),0) other_adj\r\n            from trns_sale_detail tsd\r\n            inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id and tsm.Is_deleted = false\r\n            where tsm.challan_type = 'S' and Date(tsm.date_challan) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and tsd.is_source_tax_deduct = true  --and tsm.Organization_id = ", num, "\r\n            union all\r\n            select coalesce(sum(tnd.dif_other_tax+tnd.dif_vat),0) other_adj \r\n            from trns_note_detail tnd \r\n            inner join trns_note_master tnm on tnm.note_id = tnd.note_id and tnm.Is_deleted = false\r\n            where tnm.date_note < to_date('01/02/2013','dd/MM/yyyy') and tnm.note_type = 'D'  --and tnm.Organization_id = ", num, "\r\n            union all\r\n            select coalesce(ttc.Amount,0) other_adj from trns_treasury_challan ttc\r\n            where ttc.Is_deleted = false and ttc.chalan_type_d in (2,3,4,5,6,7) and \r\n            ttc.date_challan < to_date('01/02/2013','dd/MM/yyyy') --and ttc.Organization_id = ", num, " \r\n union all\r\n select \r\n            case when tpd.is_rebatable = true then sum(tpd.Vat)+ sum(tpd.Sd) else 0 end  other_adj\r\n            from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id and tpm.Is_deleted = false\r\n            inner join Item i on i.Item_id = tpd.Item_id\r\n            where tpm.challan_type = 'P' and tpm.date_challan < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and tpm.purchase_type = 'L' AND tpd.is_exempted = false --and tpm.Organization_id = ", num, "  \r\n            and i.item_type in ( 'S','U') and tpd.is_rebatable = true\r\n            group by tpd.is_rebatable\r\n)d\r\n\r\n\r\n /*12 other_adj_purchase*/\r\n            union all\r\n            select \r\n           coalesce(sum(tpd.Atv),0) exempt_amount, 0 payment_amount\r\n            from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id and tpm.Is_deleted = false\r\n            where tpm.challan_type = 'P' and tpm.date_challan < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and tpm.purchase_type = 'I' --and tpm.Organization_id = ", num, " \r\n            \r\n union all\r\n            select \r\n           sum(tnd.rbt_vat)+ sum(tnd.rbt_other_tax) exempt_amount, 0 payment_amount\r\n            from trns_note_detail tnd \r\n            inner join trns_note_master tnm on tnm.note_id = tnd.note_id and tnm.Is_deleted = false\r\n            where tnm.date_note < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tnm.note_type = 'C'  --and tnm.Organization_id = ", num, " \r\n            \r\n union all\r\n             \r\n\t    select \r\n           sum(-tpd.Sd)+ sum(-tpd.Vat) exempt_amount, 0 payment_amount\r\n            from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id and tpm.Is_deleted = false\r\n            where tpm.challan_type = 'P'  and tpm.date_challan < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and  tpd.is_exempted = false and tpd.is_source_tax_deduct = true --and tpm.Organization_id = ", num, "  \r\n            group by tpd.is_rebatable\r\n\r\n \r\n/*7 rebatable_tax*/\r\n union all\r\n            select \r\n            case when tpd.is_rebatable = true then sum(tpd.Vat)+ sum(tpd.Sd) else 0 end exempt_amount, 0 payment_amount\r\n            from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id and tpm.Is_deleted = false\r\n            inner join Item i on i.Item_id = tpd.Item_id\r\n            where tpm.challan_type = 'P'  and tpm.date_challan < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and tpm.purchase_type = 'L' AND tpd.is_exempted = false --and tpm.Organization_id = ", num, " \r\n            and i.item_type = 'I'\r\n            group by tpd.is_rebatable\r\n             union all\r\n            select \r\n           coalesce(sum(tpd.Sd+tpd.Vat),0)*( coalesce(sum(i.vat_rebate),0) /100)  exempt_amount, 0 payment_amount\r\n             from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id and tpm.Is_deleted = false\r\n            inner join Item i on i.Item_id = tpd.Item_id\r\n            where tpm.challan_type = 'P' and tpm.date_challan < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and tpm.purchase_type = 'L' AND tpd.is_exempted = false --and tpm.Organization_id = ", num, " \r\n            and i.item_type in ('S', 'U') AND tpd.is_rebatable = true \r\n\r\n             /*8 rebatable_tax_import*/\r\n            union all\r\n            select \r\n            case when tpd.is_rebatable = true then sum(tpd.Vat)+ sum(tpd.Sd) else 0 end exempt_amount, 0 payment_amount\r\n            from trns_purchase_detail tpd\r\n            inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id and tpm.Is_deleted = false\r\n            where tpm.challan_type = 'P' and tpm.date_challan < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and tpm.purchase_type = 'I' AND tpd.is_exempted = false --and tpm.Organization_id = ", num, "  \r\n            group by tpd.is_rebatable\r\n\r\n            /*9 rebate_on_export*/\r\n\t        union all\r\n\t   \r\n           select \r\n           sum(tsd.Vat)+ sum(tsd.Sd) exempt_amount , 0 payment_amount     \r\n            from trns_sale_detail tsd\r\n            inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id\r\n            where tsm.challan_type = 'S' and tsm.Is_deleted = false \r\n            and Date(date_challan) < to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n             and tsd.is_source_tax_deduct = false and tsd.is_exempted = false \r\n             and   tsm.trans_type = 'E'\r\n            --and tsm.Organization_id = ", num, "\r\n\r\n\r\n)d\r\n            union all\r\n            /*SALE-LOCAL*/\r\n            select tsm.date_challan,'Sale (Local)' trns_desc,tsm.challan_no,0 tresury_deposit,0 exempt_amount,sum(tsd.Sd) +sum(tsd.Vat) pay_amount,0 others,0 balance_amount,1 balance_action, tsm.Remarks\r\n            from trns_sale_detail tsd \r\n            inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id\r\n            where tsm.Is_deleted = false and tsd.Is_deleted = false and tsm.challan_type = 'S' and tsm.trans_type = 'L' \r\n            and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND tsd.is_source_tax_deduct = false \r\n            --and tsm.Organization_id = ", num, "\r\n            group by tsm.date_challan,tsm.challan_no, tsm.Remarks\r\n             HAVING sum(tsd.Sd) + sum(tsd.Vat) > 0 \r\n\r\nunion all\r\n            /*VDS Adjustment*/\r\n            select tsm.date_challan,'VDS Adjustment' trns_desc,tsm.challan_no,0 tresury_deposit,0 exempt_amount,0 pay_amount,sum(tsd.Sd) +sum(tsd.Vat) others,0 balance_amount,1 balance_action, tsm.Remarks\r\n            from trns_sale_detail tsd \r\n            inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id\r\n            where tsm.Is_deleted = false and tsd.Is_deleted = false and tsm.challan_type = 'S' and tsm.trans_type = 'L' \r\n            and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND tsd.is_source_tax_deduct = true \r\n            --and tsm.Organization_id = ", num, "\r\n            group by tsm.date_challan,tsm.challan_no, tsm.Remarks\r\n             HAVING sum(tsd.Sd) + sum(tsd.Vat) > 0 \r\n\r\n            --union all\r\n            /*SALE-LOCAL -- VDS*/\r\n           -- select tsm.date_challan,'VDS' trns_desc,tsm.challan_no,sum(tsd.Sd) +sum(tsd.Vat) tresury_deposit,0 exempt_amount,0 pay_amount,0 others,0 balance_amount,1 balance_action, tsm.Remarks\r\n           -- from trns_sale_detail tsd \r\n            --inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id\r\n           -- where tsm.Is_deleted = false and tsd.Is_deleted = false and tsm.challan_type = 'S' and tsm.trans_type = 'L' \r\n           -- and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND tsd.is_source_tax_deduct = true \r\n            --and tsm.Organization_id = ", num, "\r\n           -- group by tsm.date_challan,tsm.challan_no, tsm.Remarks\r\n           --  HAVING sum(tsd.Sd) + sum(tsd.Vat) > 0 \r\n\r\n\r\n            /*SALE-EXPORT*/ -- Deducted By Ruhul Bhai\r\n            union all\r\n            select tsm.date_challan,'Sale (Export)' trns_desc,tsm.challan_no,0 tresury_deposit,0 exempt_amount,sum(tsd.Sd) +sum(tsd.Vat) pay_amount,0 others,0 balance_amount,1 balance_action, tsm.Remarks\r\n            from trns_sale_detail tsd \r\n            inner join trns_sale_master tsm on tsm.Challan_id = tsd.Challan_id\r\n            where tsm.Is_deleted = false and tsd.Is_deleted = false and tsm.challan_type = 'S' and tsm.trans_type = 'E' \r\n            and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tsm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tsd.is_source_tax_deduct = TRUE \r\n            --and tsm.Organization_id = ", num, "\r\n            group by tsm.date_challan,tsm.challan_no, tsm.Remarks\r\n            /*PURCHASE-LOCAL*/\r\n            /*union all\r\n            select tpm.date_challan,'Purchase (Local)' trns_desc,tpm.challan_no,0 tresury_deposit,\r\n            case tpd.is_rebatable when true then sum(tpd.Sd+tpd.Vat) else 0 end exempt_amount,sum(tpd.Sd+tpd.Vat) pay_amount,0 balance_amount,0 balance_action, tpm.Remarks\r\n            from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id \r\n             inner join Item i on i.Item_id = tpd.Item_id\r\n            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P' and tpm.purchase_type = 'L' --and tpm.Organization_id = ", num, "\r\n            and (tpd.is_source_tax_deduct = false or tpd.is_exempted = false ) and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and i.item_type in ( 'I') \r\n            group by tpm.date_challan,tpm.challan_no,tpd.is_rebatable, tpm.Remarks*/\r\n--union all\r\n\r\n\r\n /*New Comment Out For New Logic*/\r\n--            select tpm.date_challan,'Purchase (Local)' trns_desc,tpm.challan_no,0 tresury_deposit,coalesce(sum(tpd.Sd+tpd.Vat),0)*( coalesce(sum(i.vat_rebate),0) /100) exempt_amount,sum(tpd.Sd+tpd.Vat) pay_amount,0 others,0 balance_amount,0 balance_action, tpm.Remarks\r\n--            from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id \r\n--             inner join Item i on i.Item_id = tpd.Item_id\r\n--            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P' and tpm.purchase_type = 'L' and tpm.Organization_id = ", num, "\r\n--            and (tpd.is_source_tax_deduct = false or tpd.is_exempted = false ) and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n--            and i.item_type in ( 'U', 'S')\r\n--            group by tpm.date_challan,tpm.challan_no, tpm.Remarks\r\n--            /*PURCHASE-LOCAL-EXEMP*/\r\n--            union all\r\n--            select tpm.date_challan,'Purchase(Local)' trns_desc,tpm.challan_no,0 tresury_deposit, sum(tpd.Sd+tpd.Vat) exempt_amount,0 pay_amount,0 others,0 balance_amount,1 balance_action, tpm.Remarks\r\n--            from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id \r\n--            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P' and tpm.purchase_type = 'L' and tpm.Organization_id = ", num, "\r\n--            and (/*tpd.is_source_tax_deduct = true or*/ tpd.is_exempted = true ) and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n--            group by tpm.date_challan,tpm.challan_no, tpm.Remarks\r\n--having  sum(tpd.Sd+tpd.Vat) > 0\r\n            /*PURCHASE-IMPORT*/\r\n           /* union all\r\n            select tpm.date_challan,'Purchase (Import)' trns_desc,tpm.challan_no,0 tresury_deposit, \r\n            case tpd.is_rebatable when true then sum(tpd.Sd+tpd.Vat) else 0 end exempt_amount,sum(tpd.Sd+tpd.Vat) pay_amount,0 balance_amount,1 balance_action, tpm.Remarks\r\n            from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id \r\n             inner join Item i on i.Item_id = tpd.Item_id\r\n            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P' and tpm.purchase_type = 'I' --and tpm.Organization_id = ", num, "\r\n            and (tpd.is_source_tax_deduct = false or tpd.is_exempted = false ) and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            group by tpm.date_challan,tpm.challan_no,tpd.is_rebatable, tpm.Remarks*/\r\n\r\nunion all\r\n            select tpm.date_challan,'Purchase (Local)' trns_desc,tpm.challan_no,0 tresury_deposit,\r\n             sum(tpd.Sd+tpd.Vat)  exempt_amount,0 pay_amount,0 others,0 balance_amount,0 balance_action, tpm.Remarks\r\n            from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id \r\n             inner join Item i on i.Item_id = tpd.Item_id\r\n            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P' and tpm.purchase_type = 'L' --and tpm.Organization_id = ", num, "\r\n            and (tpd.is_source_tax_deduct = false or tpd.is_exempted = false ) and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >=  to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            and i.item_type in ( 'I') and tpd.is_rebatable = true\r\n            group by tpm.date_challan,tpm.challan_no,tpd.is_rebatable, tpm.Remarks\r\n\r\n            /*PURCHASE-IMPORT-EXEMP*/\r\n            union all\r\n            select tpm.date_challan,'Purchase (Import)' trns_desc,tpm.challan_no,0 tresury_deposit, sum(tpd.Sd+tpd.Vat) exempt_amount,0 pay_amount,0 others,0 balance_amount,0 balance_action, tpm.Remarks\r\n            from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpm.Challan_id = tpd.Challan_id \r\n            where tpm.Is_deleted = false and tpd.Is_deleted = false and tpm.challan_type = 'P' and tpm.purchase_type = 'I' --and tpm.Organization_id = ", num, "\r\n            and (tpd.is_source_tax_deduct = true or tpd.is_exempted = true or tpd.is_REBATABLE= true ) and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n            group by tpm.date_challan,tpm.challan_no, tpm.Remarks\r\n            /*TREASURY DEPOSIT*/ --(2,4,5,8)\r\n            union all\r\n            select ttc.date_challan,'Treasury Deposit(' || aD.code_name || ')' AS trns_desc,\r\n            CASE\r\n            WHEN ttc.tr_challan_no = '' then ttc.challan_no\r\n    \t\telse ttc.tr_challan_no\r\n\t    \tEND challan_no,\r\n            sum(ttc.Amount) tresury_deposit,0 exempt_amount,0 pay_amount,0 others,0 balance_amount,0 balance_action, ttc.Remarks\r\n            from trns_treasury_challan ttc\r\n            LEFT JOIN app_code_detail aD ON ttc.chalan_type_m = aD.code_id_m AND ttc.chalan_type_d = aD.code_id_d \r\n            where ttc.Is_deleted = false and ttc.chalan_type_m = 9  and ttc.chalan_type_d = 8\r\n            --and ttc.chalan_type_d = 1 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            --and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            \r\n            --and ttc.Organization_id = ", num, "\r\n            group by ttc.date_challan,ttc.challan_no, ttc.Remarks,ttc.tr_challan_no,aD.code_name\r\n\r\nunion all\r\n            select ttc.date_challan,'Treasury Deposit(' || aD.code_name || ')' AS trns_desc,\r\n            CASE\r\n            WHEN ttc.tr_challan_no = '' then ttc.challan_no\r\n    \t\telse ttc.tr_challan_no\r\n\t    \tEND challan_no,\r\n            0 tresury_deposit,0 exempt_amount,0 pay_amount,sum(ttc.Amount) others,0 balance_amount,0 balance_action, ttc.Remarks\r\n            from trns_treasury_challan ttc\r\n            LEFT JOIN app_code_detail aD ON ttc.chalan_type_m = aD.code_id_m AND ttc.chalan_type_d = aD.code_id_d \r\n            where ttc.Is_deleted = false and ttc.chalan_type_m = 9 and ttc.chalan_type_d = 5\r\n            --and ttc.chalan_type_d = 1 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            --and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            \r\n            --and ttc.Organization_id = ", num, "\r\n            group by ttc.date_challan,ttc.challan_no, ttc.Remarks,ttc.tr_challan_no,aD.code_name\r\n\r\n\r\nunion all\r\n            select ttc.date_challan,'Treasury Deposit(' || aD.code_name || ')' AS trns_desc,\r\n            CASE\r\n            WHEN ttc.tr_challan_no = '' then ttc.challan_no\r\n    \t\telse ttc.tr_challan_no\r\n\t    \tEND challan_no,\r\n            sum(ttc.Amount) tresury_deposit,0 exempt_amount,0 pay_amount,0 others,0 balance_amount,0 balance_action, ttc.Remarks\r\n            from trns_treasury_challan ttc\r\n            LEFT JOIN app_code_detail aD ON ttc.chalan_type_m = aD.code_id_m AND ttc.chalan_type_d = aD.code_id_d \r\n            where ttc.Is_deleted = false and ttc.chalan_type_m = 9 and ttc.chalan_type_d = 4\r\n            --and ttc.chalan_type_d = 1 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            --and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            \r\n            --and ttc.Organization_id = ", num, "\r\n            group by ttc.date_challan,ttc.challan_no, ttc.Remarks,ttc.tr_challan_no,aD.code_name\r\n\r\n\r\nunion all\r\n            select ttc.date_challan,'Treasury Deposit(' || aD.code_name || ')' AS trns_desc,\r\n            CASE\r\n            WHEN ttc.tr_challan_no = '' then ttc.challan_no\r\n    \t\telse ttc.tr_challan_no\r\n\t    \tEND challan_no,\r\n            sum(ttc.Amount) tresury_deposit,0 exempt_amount,0 pay_amount,0 others,0 balance_amount,0 balance_action, ttc.Remarks\r\n            from trns_treasury_challan ttc\r\n            LEFT JOIN app_code_detail aD ON ttc.chalan_type_m = aD.code_id_m AND ttc.chalan_type_d = aD.code_id_d \r\n            where ttc.Is_deleted = false and ttc.chalan_type_m = 9 and ttc.chalan_type_d = 2\r\n            --and ttc.chalan_type_d = 1 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            --and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            \r\n            --and ttc.Organization_id = ", num, "\r\n            group by ttc.date_challan,ttc.challan_no, ttc.Remarks,ttc.tr_challan_no,aD.code_name\r\n\r\nunion all\r\n            select ttc.date_challan,'Treasury Deposit(' || aD.code_name || ')' AS trns_desc,\r\n            CASE\r\n            WHEN ttc.tr_challan_no = '' then ttc.challan_no\r\n    \t\telse ttc.tr_challan_no\r\n\t    \tEND challan_no,\r\n            sum(ttc.Amount) tresury_deposit,0 exempt_amount,0 pay_amount,0 others,0 balance_amount,0 balance_action, ttc.Remarks\r\n            from trns_treasury_challan ttc\r\n            LEFT JOIN app_code_detail aD ON ttc.chalan_type_m = aD.code_id_m AND ttc.chalan_type_d = aD.code_id_d \r\n            where ttc.Is_deleted = false and ttc.chalan_type_m = 9 and ttc.chalan_type_d = 6\r\n            --and ttc.chalan_type_d = 1 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            --and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            \r\n            --and ttc.Organization_id = ", num, "\r\n            group by ttc.date_challan,ttc.challan_no, ttc.Remarks,ttc.tr_challan_no,aD.code_name\r\n\r\nunion all\r\n            select ttc.date_challan,'Treasury Deposit(' || aD.code_name || ')' AS trns_desc,\r\n            CASE\r\n            WHEN ttc.tr_challan_no = '' then ttc.challan_no\r\n    \t\telse ttc.tr_challan_no\r\n\t    \tEND challan_no,\r\n            sum(ttc.Amount) tresury_deposit,0 exempt_amount,0 pay_amount,0 others,0 balance_amount,0 balance_action, ttc.Remarks\r\n            from trns_treasury_challan ttc\r\n            LEFT JOIN app_code_detail aD ON ttc.chalan_type_m = aD.code_id_m AND ttc.chalan_type_d = aD.code_id_d \r\n            where ttc.Is_deleted = false and ttc.chalan_type_m = 9 and ttc.chalan_type_d = 1\r\n            --and ttc.chalan_type_d = 1 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            --and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy') \r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            \r\n            --and ttc.Organization_id = ", num, "\r\n            group by ttc.date_challan,ttc.challan_no, ttc.Remarks,ttc.tr_challan_no,aD.code_name\r\n\r\n\r\n             /*FINE*/\r\n            --union all\r\n            --select ttc.date_challan,'Fine' trns_desc,ttc.challan_no,0 tresury_deposit,0 exempt_amount,sum(ttc.Amount) pay_amount,0 others,0 balance_amount,0 balance_action, ttc.Remarks\r\n            --from trns_treasury_challan ttc\r\n            --where ttc.Is_deleted = false and ttc.chalan_type_m = 9 and ttc.chalan_type_d = 3 and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(ttc.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') --and ttc.Organization_id = ", num, "\r\n            --group by ttc.date_challan,ttc.challan_no, ttc.Remarks\r\n/*SALE RETURN D/N*/\r\n            --union all\r\n            --select tnm.date_note date_challan,'Sale Return(D/N)' trns_desc,tnm.note_no challan_no,0 tresury_deposit,sum(tnd.rbt_vat-tnd.dif_vat)+ sum(tnd.rbt_other_tax) exempt_amount,0 pay_amount,0 balance_amount,0 balance_action, '' Remarks\r\n            --from trns_note_detail tnd inner join trns_note_master tnm on tnm.note_id = tnd.note_id\r\n            --where tnm.Is_deleted = false and tnd.Is_deleted = false and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tnm.note_type = 'D' --and tnm.Organization_id = ", num, "\r\n            --group by tnm.date_note,tnm.note_no\r\n            /*SALE_RETURN C/N*/\r\n            --union all\r\n            --select tnm.date_note date_challan,'Sale Return(C/N)' trns_desc,tnm.note_no challan_no,0 tresury_deposit,sum(tnd.rbt_vat-tnd.dif_vat)+ sum(tnd.rbt_other_tax) exempt_amount,0 pay_amount,0 balance_amount,1 balance_action, '' Remarks\r\n            --from trns_note_detail tnd inner join trns_note_master tnm on tnm.note_id = tnd.note_id\r\n            --where tnm.Is_deleted = false and tnd.Is_deleted = false and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tnm.note_type = 'C' --and tnm.Organization_id = ", num, "\r\n            --group by tnm.date_note,tnm.note_no ) d order by d.date_challan,d.trns_desc\r\n            --------------------------------------------------------------------------\r\nunion all\r\n            select tnm.date_note date_challan,'Sale Return(C/N)' trns_desc,tnm.note_no challan_no,\r\n            0 tresury_deposit,0 exempt_amount,0 pay_amount,tnd.return_vat + tnd.return_sd others,0 balance_amount,0 balance_action, '' Remarks\r\n            from trns_note_detail tnd inner join trns_note_master tnm on tnm.note_id = tnd.note_id\r\n            where tnm.Is_deleted = false and tnd.Is_deleted = false and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and TO_DATE(TO_CHAR(tnm.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and tnm.note_type = 'C' --and tnm.Organization_id = ", num, "\r\n            group by tnm.date_note,tnm.note_no,tnd.return_vat,tnd.return_sd \r\n             HAVING sum(tnd.return_vat) + sum(tnd.return_sd) > 0 ) d order by d.date_challan,d.trns_desc " };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public void KGCVATMushok11(string From_Date, string To_Date, string Customer_ID)
        {
            DataTable dataTable = new DataTable();
            int num = 0;
            List<wsKGCVATApi.VatMushok11> vatMushok11s = new List<wsKGCVATApi.VatMushok11>();
            try
            {
                if (!string.IsNullOrEmpty(Customer_ID) && Convert.ToInt32(Customer_ID) > 0)
                {
                    num = Convert.ToInt32(Customer_ID);
                }
                DateTime dateTime = DateTime.ParseExact(From_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(To_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dataTable = this.Vat_11(dateTime, dateTime1, num);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        wsKGCVATApi.VatMushok11 vatMushok11 = new wsKGCVATApi.VatMushok11()
                        {
                            SerialNo = Convert.ToInt32(dataTable.Rows[i]["Sl_No"].ToString()),
                            ChallanNo = dataTable.Rows[i]["Challan_No"].ToString(),
                            ChallanDate = dataTable.Rows[i]["Challan_Date"].ToString(),
                            ChallanTime = dataTable.Rows[i]["Challan_Time"].ToString(),
                            ItemName = dataTable.Rows[i]["Goods_Services_Name"].ToString(),
                            CustomerName = dataTable.Rows[i]["Customer_name"].ToString(),
                            CustomerAddress = dataTable.Rows[i]["Customer_Address"].ToString(),
                            CustomerBIN = dataTable.Rows[i]["Customer_TIN"].ToString(),
                            DeliveryAddress = dataTable.Rows[i]["Goods_Services_Shipping_Address"].ToString(),
                            VehicleType = dataTable.Rows[i]["Vehicle_Type"].ToString(),
                            VehicleNo = dataTable.Rows[i]["Vehicle_No"].ToString(),
                            Vehicle = dataTable.Rows[i]["Vehicle"].ToString(),
                            GoodsUnloadDate = dataTable.Rows[i]["Goods_Unload_Date"].ToString(),
                            GoodsUnloadTime = dataTable.Rows[i]["Goods_Unload_Time"].ToString(),
                            Quantity = Convert.ToDecimal(dataTable.Rows[i]["Quantity"].ToString()),
                            UnitPrice = Convert.ToDecimal(dataTable.Rows[i]["unit_Price"].ToString()),
                            SD = Convert.ToDecimal(dataTable.Rows[i]["SD_Amount"].ToString()),
                            TotalPriceWithSD = Convert.ToDecimal(dataTable.Rows[i]["total_price_sd"].ToString()),
                            VAT = Convert.ToDecimal(dataTable.Rows[i]["VAT_Amount"].ToString()),
                            TotalPriceWithVatSd = Convert.ToDecimal(dataTable.Rows[i]["total_price_sd_vat"].ToString())
                        };
                        vatMushok11s.Add(vatMushok11);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            base.Context.Response.Write(javaScriptSerializer.Serialize(vatMushok11s));
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public void KGCVATMushok18(string From_Date, string To_Date)
        {
            DataTable dataTable = new DataTable();
            List<wsKGCVATApi.VatMushok18> vatMushok18s = new List<wsKGCVATApi.VatMushok18>();
            try
            {
                DateTime dateTime = DateTime.ParseExact(From_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(To_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dataTable = this.Vat_18(dateTime, dateTime1);
                dataTable = this.getNewDataTableWithBalance(dataTable);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        wsKGCVATApi.VatMushok18 vatMushok18 = new wsKGCVATApi.VatMushok18()
                        {
                            ChallanNo = dataTable.Rows[i]["challan_no"].ToString(),
                            ChallanDate = dataTable.Rows[i]["date_challan"].ToString(),
                            TransDescription = dataTable.Rows[i]["trns_desc"].ToString(),
                            TreasuryDeposit = Convert.ToDecimal(dataTable.Rows[i]["treasury_deposit"].ToString()),
                            ExamptAmount = Convert.ToDecimal(dataTable.Rows[i]["exempt_amount"].ToString()),
                            PayAmount = Convert.ToDecimal(dataTable.Rows[i]["pay_amount"].ToString()),
                            Others = Convert.ToDecimal(dataTable.Rows[i]["others"].ToString()),
                            Balance = Convert.ToDecimal(dataTable.Rows[i]["balance_amount"].ToString()),
                            BalanceAction = Convert.ToInt32(dataTable.Rows[i]["balance_action"].ToString())
                        };
                        vatMushok18s.Add(vatMushok18);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            base.Context.Response.Write(javaScriptSerializer.Serialize(vatMushok18s));
        }

        public class VatMushok11
        {
            public string ChallanDate
            {
                get;
                set;
            }

            public string ChallanNo
            {
                get;
                set;
            }

            public string ChallanTime
            {
                get;
                set;
            }

            public string CustomerAddress
            {
                get;
                set;
            }

            public string CustomerBIN
            {
                get;
                set;
            }

            public string CustomerName
            {
                get;
                set;
            }

            public string DeliveryAddress
            {
                get;
                set;
            }

            public string GoodsUnloadDate
            {
                get;
                set;
            }

            public string GoodsUnloadTime
            {
                get;
                set;
            }

            public string ItemName
            {
                get;
                set;
            }

            public decimal Quantity
            {
                get;
                set;
            }

            public decimal SD
            {
                get;
                set;
            }

            public int SerialNo
            {
                get;
                set;
            }

            public decimal TotalPriceWithSD
            {
                get;
                set;
            }

            public decimal TotalPriceWithVatSd
            {
                get;
                set;
            }

            public decimal UnitPrice
            {
                get;
                set;
            }

            public decimal VAT
            {
                get;
                set;
            }

            public string Vehicle
            {
                get;
                set;
            }

            public string VehicleNo
            {
                get;
                set;
            }

            public string VehicleType
            {
                get;
                set;
            }

            public VatMushok11()
            {
            }
        }

        public class VatMushok18
        {
            public decimal Balance
            {
                get;
                set;
            }

            public int BalanceAction
            {
                get;
                set;
            }

            public string ChallanDate
            {
                get;
                set;
            }

            public string ChallanNo
            {
                get;
                set;
            }

            public decimal ExamptAmount
            {
                get;
                set;
            }

            public decimal Others
            {
                get;
                set;
            }

            public decimal PayAmount
            {
                get;
                set;
            }

            public string TransDescription
            {
                get;
                set;
            }

            public decimal TreasuryDeposit
            {
                get;
                set;
            }

            public VatMushok18()
            {
            }
        }
    }
}