using System;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Import_AIT_RefundBLL
    {
        private DBUtility connDB = new DBUtility();

        public Import_AIT_RefundBLL()
        {
        }

        public DataTable getAllDataByDate(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] str = new object[] { "select tpd.challan_id, tpd.row_no as RowNo,tpd.item_id, tpm.bl_no as boeno, i.item_name as item,iu.unit_code as Unit,tpd.Quantity, tpd.purchase_unit_price as unit_price, tpd.purchase_vat as Vat,tpd.psi,tpd.cnf_vat,tpd.cnf_commission, \r\n                        tpd.purchase_sd as sd, tpd.cd, tpd.rd, tpd.atv, tpd.tti, tpd.ait,tpd.other_cost,tpd.at,c.abbr_name as country,\r\n                        tpd.document_processing_fee as document_fee, (tpd.Quantity*tpd.purchase_unit_price) as sub_total,\r\n                        (tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd+tpd.cd+tpd.rd+tpd.atv+tpd.tti+tpd.ait+tpd.other_cost+tpd.document_processing_fee+tpd.psi+tpd.cnf_vat+tpd.cnf_commission+tpd.at) as total,\r\n                        tpm.tax_payment_date\r\n                        from trns_purchase_detail tpd\r\n                        inner join item i\r\n                        on tpd.item_id = i.item_id\r\n                        inner join item_unit iu\r\n                        on iu.unit_id = tpd.unit_id\r\n                        inner join trns_purchase_master tpm\r\n                        on tpd.challan_id = tpm.challan_id\r\n                        left join set_country c\r\n                        on tpm.country_of_origin = c.country_id\r\n                        where CAST(tpm.date_challan AS DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tpm.date_challan AS DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                        and tpm.challan_type = 'P' and tpm.purchase_type = 'I' AND tpd.ait_refund_status = false and tpm.organization_id=", num, " " };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getAllValueByblNo(string blNo)
        {
            string str = string.Concat(" select tpm.date_challan::Date bl_date, tpm.release_order_no, tpm.release_order_date::Date, c.country_name,tpm.tax_payment_date\r\n                        from trns_purchase_master tpm\r\n                        left join set_country c\r\n                        on tpm.country_of_origin = c.country_id\r\n                        where tpm.bl_no = '", blNo, "'");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetBillEntreNoDrp(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] str = new object[] { "select DISTINCT tpm.bl_no as boeno\r\n                        from trns_purchase_detail tpd\r\n                        inner join item i\r\n                        on tpd.item_id = i.item_id\r\n                        inner join item_unit iu\r\n                        on iu.unit_id = tpd.unit_id\r\n                        inner join trns_purchase_master tpm\r\n                        on tpd.challan_id = tpm.challan_id\r\n                        left join set_country c\r\n                        on tpm.country_of_origin = c.country_id\r\n                        where CAST(tpm.date_challan AS DATE) >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(tpm.date_challan AS DATE) <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                       and tpm.challan_type='P' and tpm.purchase_type='I' AND tpd.ait_refund_status = false and tpm.organization_id=", num };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getBillofEntryNo()
        {
            return this.connDB.GetDataTable(" select tpm.bl_no, tpm.bl_date, tpm.release_order_no, tpm.release_order_date, c.country_name\r\n                        from trns_purchase_master tpm\r\n                        left join set_country c\r\n                        on tpm.country_of_origin = c.country_id\r\n                        order by tpm.bl_no");
        }

        public DataTable getEmployeeDesignation(short eid)
        {
            string str = string.Concat("select * from admn_designation where designation_id = ", eid, " AND is_deleted = false");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getGridData(string billNo)
        {
            string str = string.Concat("select tpd.challan_id,tpd.row_no as RowNo, tpm.bl_no as boeno,tpd.item_id, i.item_name as item,iu.unit_code as Unit,tpd.Quantity, tpd.purchase_unit_price as unit_price, tpd.purchase_vat as Vat,tpd.psi,tpd.cnf_vat,tpd.cnf_commission, \r\n                        tpd.purchase_sd as sd, tpd.cd, tpd.rd, tpd.atv, tpd.tti, tpd.ait,tpd.other_cost,tpd.at,c.abbr_name as country,\r\n                        tpd.document_processing_fee as document_fee, (tpd.Quantity*tpd.purchase_unit_price) as sub_total,\r\n                        (tpd.Quantity*tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd+tpd.cd+tpd.rd+tpd.atv+tpd.tti+tpd.ait+tpd.other_cost+tpd.document_processing_fee+tpd.psi+tpd.cnf_vat+tpd.cnf_commission+tpd.at) as total\r\n                        from trns_purchase_detail tpd\r\n                        inner join item i\r\n                        on tpd.item_id = i.item_id\r\n                        inner join item_unit iu\r\n                        on iu.unit_id = tpd.unit_id\r\n                        inner join trns_purchase_master tpm\r\n                        on tpd.challan_id = tpm.challan_id\r\n                        left join set_country c\r\n                        on tpm.country_of_origin = c.country_id\r\n                        where tpm.bl_no = '", billNo, "'");
            return this.connDB.GetDataTable(str);
        }
    }
}

