using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class AvobeTwoLacBLL
    {
        private DBUtility conDB = new DBUtility();

        public AvobeTwoLacBLL()
        {
        }

        public DataTable getLocalPurchaseData(string fDate, string tDate, string challanNo)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = "";
            if (challanNo != "")
            {
                str = string.Concat("AND challan_no = '", challanNo, "'");
            }
            object[] objArray = new object[] { " select \r\n                          tpm.date_challan date_insert\r\n                         --,tpd.total_price\r\n                         ,SUM(tpd.total_price) AS total_price\r\n                         ,tpm.challan_no\r\n                          --,i.item_name\r\n                          ,case when tp.reg_type!='5' then tp.party_bin else tp.national_id_no end party_bin,tp.party_name,tp.party_address\r\n                          ,case when tpm.purchase_type = 'L' then 'Local' --tpm.transaction_type\r\n                          when tpm.purchase_type = 'I' then 'Import' end purchase_type\r\n                          ,case when tpm.payment_method = '1' then 'Cash'\r\n                          when tpm.payment_method = '2' then 'Check'\r\n                               when tpm.payment_method = '3' then 'Pay Order' \r\n                               when tpm.payment_method = '8' then 'bKash'\r\n                               when tpm.payment_method = '10' then 'Rocket'\r\n                               when tpm.payment_method = '5' then 'TT'\r\n                               when tpm.payment_method = '9' then 'EFT'\r\n                               when tpm.payment_method = '6' then 'Debit Card'\r\n                               when tpm.payment_method = '12' then 'TR'\r\n                               when tpm.payment_method = '11' then 'Other'\r\n                               when tpm.payment_method = '13' then 'Credit' end payment_method\r\n                          from trns_purchase_detail tpd\r\n                          inner join trns_purchase_master tpm on tpd.challan_id = tpm.challan_id\r\n                          inner join trns_party tp  on tpm.party_id = tp.party_id\r\n                          inner join item i  on tpd.item_id = i.item_id\r\n                          where tpm.date_challan > to_date('", fDate, "','dd/MM/yyyy') and tpm.date_challan < to_date('", tDate, "','dd/MM/yyyy') and tpd.approver_stage='F'\r\n                          and tpd.total_price > 200000 ", str, " and tpm.organization_id=", num, " AND tpm.challan_type = 'P'  and tpm.purchase_type='L'\r\n                          GROUP BY tpm.date_challan\r\n                 ,tpm.challan_no\r\n                 ,tp.reg_type,tp.party_bin,tp.national_id_no\r\n                          ,tpm.purchase_type\r\n ,tpm.payment_method\r\n                 ,tp.party_name,tp.party_address\r\n                          order by tpm.date_challan desc" };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getLocalSaleData(string fDate, string tDate, string challanNo)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = "";
            if (challanNo != "")
            {
                str = string.Concat("AND challan_no = '", challanNo, "'");
            }
            object[] objArray = new object[] { " select \r\n                          --tsd.date_insert, \r\n                          tsm.date_challan date_insert,tsm.challan_no\r\n                          --,i.item_name\r\n                          ,case when tp.reg_type!='5' then tp.party_bin else tp.national_id_no end party_bin,tp.party_name,tp.party_address\r\n                          --,(tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) as total_price,\r\n                          --,SUM(tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) as total_price\r\n                         ,SUM(tsd.Quantity*tsd.actual_price) as total_price\r\n                          ,case when tsm.trans_type = 'L' then 'Local' --tpm.transaction_type\r\n                          when tsm.trans_type = 'E' then 'Export' end sale_type\r\n                          ,case when tsm.payment_method = '1' then 'Cash'\r\n                          when tsm.payment_method = '2' then 'Check'\r\n                                when tsm.payment_method = '3' then 'Pay Order' \r\n                                when tsm.payment_method = '8' then 'bKash'\r\n                                when tsm.payment_method = '10' then 'Rocket'\r\n                                when tsm.payment_method = '5' then 'TT'\r\n                                when tsm.payment_method = '9' then 'EFT'\r\n                                when tsm.payment_method = '6' then 'Debit Card'\r\n                                when tsm.payment_method = '12' then 'TR'\r\n                                when tsm.payment_method = '11' then 'Other'\r\n                                when tsm.payment_method = '13' then 'Credit' end payment_method\r\n                          from trns_sale_detail tsd\r\n                          inner join trns_sale_master tsm on tsd.challan_id = tsm.challan_id\r\n                          inner join trns_party tp on tsm.party_id = tp.party_id\r\n                          inner join item i on tsd.item_id = i.item_id\r\n                          where tsm.date_challan >= to_date('", fDate, "','dd/MM/yyyy') and tsm.date_challan < to_date('", tDate, "','dd/MM/yyyy')\r\n                          --tsd.date_insert >= to_date('", fDate, "','dd/MM/yyyy') and tsd.date_insert < to_date('", tDate, "','dd/MM/yyyy') \r\n                          --and (tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) > 200000  and tsd.approver_stage='F'\r\n                          ", str, " and tsm.organization_id=", num, " AND tsm.trans_type = 'L'  \r\n                          GROUP BY\r\n                          tsm.date_challan,tsm.challan_no,tp.national_id_no\r\n                          ,tp.reg_type,tp.party_bin\r\n                          ,tsm.trans_type\r\n                          ,tsm.payment_method\r\n                          ,tp.party_name,tp.party_address\r\n                          HAVING SUM(tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) > 200000\r\n                          order by tsm.date_challan desc" };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getPurchaseData(string fDate, string tDate, string challanNo)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = "";
            if (challanNo != "")
            {
                str = string.Concat("AND challan_no = '", challanNo, "'");
            }
            object[] objArray = new object[] { " select \r\n                          tpm.date_challan date_insert\r\n                         --,tpd.total_price\r\n                         ,SUM(tpd.total_price) AS total_price\r\n                         ,tpm.challan_no\r\n                          --,i.item_name\r\n                          ,case when tp.reg_type!='5' then tp.party_bin else tp.national_id_no end party_bin,tp.party_name,tp.party_address\r\n                          ,case when tpm.purchase_type = 'L' then 'Local' --tpm.transaction_type\r\n                          when tpm.purchase_type = 'I' then 'Import' end purchase_type\r\n                          ,case when tpm.payment_method = '1' then 'Cash'\r\n                          when tpm.payment_method = '2' then 'Check'\r\n                               when tpm.payment_method = '3' then 'Pay Order' \r\n                               when tpm.payment_method = '8' then 'bKash'\r\n                               when tpm.payment_method = '10' then 'Rocket'\r\n                               when tpm.payment_method = '5' then 'TT'\r\n                               when tpm.payment_method = '9' then 'EFT'\r\n                               when tpm.payment_method = '6' then 'Debit Card'\r\n                               when tpm.payment_method = '12' then 'TR'\r\n                               when tpm.payment_method = '11' then 'Other'\r\n                               when tpm.payment_method = '13' then 'Credit' end payment_method\r\n                          from trns_purchase_detail tpd\r\n                          inner join trns_purchase_master tpm on tpd.challan_id = tpm.challan_id\r\n                          inner join trns_party tp  on tpm.party_id = tp.party_id\r\n                          inner join item i  on tpd.item_id = i.item_id\r\n                          where tpm.date_challan > to_date('", fDate, "','dd/MM/yyyy') and tpm.date_challan < to_date('", tDate, "','dd/MM/yyyy')\r\n                          and tpd.total_price > 200000 ", str, " and tpm.organization_id=", num, " AND tpm.challan_type = 'P'\r\n                          GROUP BY tpm.date_challan\r\n                 ,tpm.challan_no\r\n                 ,tp.reg_type,tp.party_bin,tp.national_id_no\r\n                          ,tpm.purchase_type\r\n ,tpm.payment_method\r\n                 ,tp.party_name,tp.party_address\r\n                          order by tpm.date_challan desc" };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getSaleData(string fDate, string tDate, string challanNo)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = "";
            if (challanNo != "")
            {
                str = string.Concat("AND challan_no = '", challanNo, "'");
            }
            object[] objArray = new object[] { " select \r\n                          --tsd.date_insert, \r\n                          tsm.date_challan date_insert,tsm.challan_no\r\n                          --,i.item_name\r\n                          ,case when tp.reg_type!='5' then tp.party_bin else tp.national_id_no end party_bin,tp.party_name,tp.party_address\r\n                          --,(tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) as total_price,\r\n                          ,SUM(tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) as total_price\r\n                          ,case when tsm.trans_type = 'L' then 'Local' --tpm.transaction_type\r\n                          when tsm.trans_type = 'E' then 'Export' end sale_type\r\n                          ,case when tsm.payment_method = '1' then 'Cash'\r\n                          when tsm.payment_method = '2' then 'Check'\r\n                                when tsm.payment_method = '3' then 'Pay Order' \r\n                                when tsm.payment_method = '8' then 'bKash'\r\n                                when tsm.payment_method = '10' then 'Rocket'\r\n                                when tsm.payment_method = '5' then 'TT'\r\n                                when tsm.payment_method = '9' then 'EFT'\r\n                                when tsm.payment_method = '6' then 'Debit Card'\r\n                                when tsm.payment_method = '12' then 'TR'\r\n                                when tsm.payment_method = '11' then 'Other'\r\n                                when tsm.payment_method = '13' then 'Credit' end payment_method\r\n                          from trns_sale_detail tsd\r\n                          inner join trns_sale_master tsm on tsd.challan_id = tsm.challan_id\r\n                          inner join trns_party tp on tsm.party_id = tp.party_id\r\n                          inner join item i on tsd.item_id = i.item_id\r\n                          where tsm.date_challan >= to_date('", fDate, "','dd/MM/yyyy') and tsm.date_challan < to_date('", tDate, "','dd/MM/yyyy')\r\n                          --tsd.date_insert >= to_date('", fDate, "','dd/MM/yyyy') and tsd.date_insert < to_date('", tDate, "','dd/MM/yyyy') \r\n                          --and (tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) > 200000 \r\n                          ", str, " and tsm.organization_id=", num, " \r\n                          GROUP BY\r\n                          tsm.date_challan,tsm.challan_no,tp.national_id_no\r\n                          ,tp.reg_type,tp.party_bin\r\n                          ,tsm.trans_type\r\n                          ,tsm.payment_method\r\n                          ,tp.party_name,tp.party_address\r\n                          HAVING SUM(tsd.Quantity*tsd.actual_price+tsd.Vat+tsd.sd) > 200000\r\n                          order by tsm.date_challan desc" };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataTable(str1);
        }
    }
}