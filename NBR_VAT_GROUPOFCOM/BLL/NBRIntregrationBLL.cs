using System;
using System.Collections;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class NBRIntregrationBLL
    {
        private DBUtility db = new DBUtility();

        public NBRIntregrationBLL()
        {
        }

        public DataTable GetAllChallanForAudit(short ID, DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                if (ID == 1)
                {
                    string[] str = new string[] { "select ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        cast(coalesce(sum(d.quantity*d.purchase_unit_price),0) as decimal(20,2)) total_amount,\r\n                        cast(sum(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti) as decimal(20,2)) total_tax,\r\n                        cast(sum(d.quantity*d.purchase_unit_price) as decimal(20,2)) + cast(sum(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti) as decimal(20,2)) Grand_total\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.purchase_type in ('L','I')\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and d.s_p_return = 0\r\n                        group by m.challan_id, m.challan_no, m.date_challan, p.party_id, p.party_name\r\n                        order by m.challan_id" };
                    empty = string.Concat(str);
                }
                else if (ID == 2)
                {
                    string[] strArrays = new string[] { "select distinct ROW_NUMBER() over (order by m.challan_id) RowNo,  m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                            cast(coalesce(sum(d.quantity*d.actual_price),0) as decimal(20,2)) total_amount,\r\n                            cast(sum(d.vat+d.sd) as decimal(20,2)) total_tax,\r\n                            cast(sum(d.quantity*d.actual_price) as decimal(20,2)) + cast(sum(d.vat+d.sd) as decimal(20,2)) Grand_total\r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            inner join trns_party p on m.party_id = p.party_id\r\n                            where  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.is_deleted = false\r\n                            group by m.challan_id, m.challan_no, m.date_challan, p.party_id, p.party_name\r\n                            order by m.challan_id" };
                    empty = string.Concat(strArrays);
                }
                else if (ID == 3)
                {
                    string[] str1 = new string[] { "select distinct ROW_NUMBER() over (order by m.note_id) RowNo,  m.note_id challan_id, m.note_no challan_no, to_char(m.date_note,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                            cast(coalesce(sum(d.quantity*d.actual_price),0) as decimal(20,2)) total_amount,\r\n                            cast(sum(d.return_vat+d.return_sd) as decimal(20,2)) total_tax,\r\n                            cast(sum(d.quantity*d.actual_price) as decimal(20,2)) + cast(sum(d.return_vat+d.return_sd) as decimal(20,2)) Grand_total\r\n                            from trns_note_master m\r\n                            inner join trns_note_detail d on m.note_id = d.note_id\r\n                            inner join trns_party p on m.party_id = p.party_id\r\n                            where m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.is_deleted = false\r\n                            and m.note_type = 'D'\r\n                            group by m.note_id, m.note_no, m.date_note, p.party_id, p.party_name\r\n                            order by m.note_id" };
                    empty = string.Concat(str1);
                }
                else if (ID == 4)
                {
                    string[] strArrays1 = new string[] { "select distinct  ROW_NUMBER() over (order by m.note_id) RowNo,  m.note_id challan_id, m.note_no challan_no, to_char(m.date_note,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                            cast(coalesce(sum(d.quantity*d.actual_price),0) as decimal(20,2)) total_amount,\r\n                            cast(sum(d.return_vat+d.return_sd) as decimal(20,2)) total_tax,\r\n                            cast(sum(d.quantity*d.actual_price) as decimal(20,2)) + cast(sum(d.return_vat+d.return_sd) as decimal(20,2)) Grand_total\r\n                            from trns_note_master m\r\n                            inner join trns_note_detail d on m.note_id = d.note_id\r\n                            inner join trns_party p on m.party_id = p.party_id\r\n                            where m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.is_deleted = false\r\n                            and m.note_type = 'C'\r\n                            group by m.note_id, m.note_no, m.date_note, p.party_id, p.party_name\r\n                            order by m.note_id" };
                    empty = string.Concat(strArrays1);
                }
                else if (ID == 5)
                {
                    string[] str2 = new string[] { "select distinct ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        cast(coalesce(sum(d.quantity*d.purchase_unit_price),0) as decimal(20,2)) total_amount,\r\n                        cast(sum(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti) as decimal(20,2)) total_tax,\r\n                        cast(sum(d.quantity*d.purchase_unit_price) as decimal(20,2)) + cast(sum(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti) as decimal(20,2)) Grand_total\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.purchase_type in ('L','I')\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and d.s_p_return = 0\r\n                        and d.is_source_tax_deduct = true\r\n                        group by m.challan_id, m.challan_no, m.date_challan, p.party_id, p.party_name\r\n                        order by m.challan_id" };
                    empty = string.Concat(str2);
                }
                else if (ID == 6)
                {
                    string[] strArrays2 = new string[] { "select distinct ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                            cast(coalesce(sum(d.quantity*d.actual_price),0) as decimal(20,2)) total_amount,\r\n                            cast(sum(d.vat+d.sd) as decimal(20,2)) total_tax,\r\n                            cast(sum(d.quantity*d.actual_price) as decimal(20,2)) + cast(sum(d.vat+d.sd) as decimal(20,2)) Grand_total\r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            inner join trns_party p on m.party_id = p.party_id\r\n                            where  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and m.is_deleted = false\r\n                            and d.is_source_tax_deduct = true\r\n                            group by m.challan_id, m.challan_no, m.date_challan, p.party_id, p.party_name\r\n                            order by m.challan_id" };
                    empty = string.Concat(strArrays2);
                }
                else if (ID == 7)
                {
                    string[] str3 = new string[] { "select distinct ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        cast(coalesce(sum(d.quantity*d.purchase_unit_price),0) as decimal(20,2)) total_amount,\r\n                        cast(sum(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti) as decimal(20,2)) total_tax,\r\n                        cast(sum(d.quantity*d.purchase_unit_price) as decimal(20,2)) + cast(sum(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti) as decimal(20,2)) Grand_total\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.purchase_type in ('L','I')\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and d.s_p_return = 0\r\n                        and d.is_rebatable = true\r\n                        group by m.challan_id, m.challan_no, m.date_challan, p.party_id, p.party_name\r\n                        order by m.challan_id" };
                    empty = string.Concat(str3);
                }
                else if (ID == 8)
                {
                    string[] strArrays3 = new string[] { "select ROW_NUMBER() over (order by challan_id) RowNo, m.challan_id,m.challan_no,m.code_no,to_char(m.date_challan,'dd-MON-yyyy') challan_date ,m.amount ||' '||m.instrument_type amount, \r\n                        d.code_name,m.instrument_description,m.bearer_name_address,m.deposit_description,m.designation\r\n                        from trns_treasury_challan m\r\n                        inner join app_code_detail d on m.chalan_type_m = d.code_id_m and m.chalan_type_d = d.code_id_d\r\n                        where m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false" };
                    empty = string.Concat(strArrays3);
                }
                dataTable = this.db.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetAllItemChallanForAudit(short ID, int ItemID, DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                if (ID == 1)
                {
                    object[] itemID = new object[] { "select ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        d.quantity, d.purchase_unit_price unit_price, d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti tax\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.purchase_type in ('L','I')\r\n                        and d.item_id = ", ItemID, "\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and d.s_p_return = 0\r\n                        order by m.challan_id" };
                    empty = string.Concat(itemID);
                }
                else if (ID == 2)
                {
                    object[] objArray = new object[] { "select ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        d.quantity, d.actual_price unit_price, d.vat+d.sd tax\r\n                        from trns_sale_master m\r\n                        inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where  d.item_id = ", ItemID, "\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        order by m.challan_id" };
                    empty = string.Concat(objArray);
                }
                else if (ID == 3)
                {
                    object[] itemID1 = new object[] { "select ROW_NUMBER() over (order by m.note_id) RowNo, m.note_id challan_id, m.note_no challan_no, to_char(m.date_note,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        d.quantity, d.actual_price unit_price, d.return_vat+d.return_sd tax\r\n                        from trns_note_master m\r\n                        inner join trns_note_detail d on m.note_id = d.note_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where  d.item_id = ", ItemID, "\r\n                        and m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and m.note_type = 'D'\r\n                        order by m.note_id" };
                    empty = string.Concat(itemID1);
                }
                else if (ID == 4)
                {
                    object[] objArray1 = new object[] { "select ROW_NUMBER() over (order by m.note_id) RowNo, m.note_id challan_id, m.note_no challan_no, to_char(m.date_note,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        d.quantity, d.actual_price unit_price, d.return_vat+d.return_sd tax\r\n                        from trns_note_master m\r\n                        inner join trns_note_detail d on m.note_id = d.note_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where  d.item_id = ", ItemID, "\r\n                        and m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and m.note_type = 'C'\r\n                        order by m.note_id" };
                    empty = string.Concat(objArray1);
                }
                else if (ID == 5)
                {
                    object[] itemID2 = new object[] { "select ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        d.quantity, d.purchase_unit_price unit_price, d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti tax\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.purchase_type in ('L','I')\r\n                        and d.item_id = ", ItemID, "\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and d.s_p_return = 0\r\n                        and d.is_source_tax_deduct = true\r\n                        order by m.challan_id" };
                    empty = string.Concat(itemID2);
                }
                else if (ID == 6)
                {
                    object[] objArray2 = new object[] { "select ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        d.quantity, d.actual_price unit_price, d.vat+d.sd tax\r\n                        from trns_sale_master m\r\n                        inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where  d.item_id = ", ItemID, "\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and d.is_source_tax_deduct = true\r\n                        order by m.challan_id" };
                    empty = string.Concat(objArray2);
                }
                else if (ID == 7)
                {
                    object[] itemID3 = new object[] { "select ROW_NUMBER() over (order by m.challan_id) RowNo, m.challan_id, m.challan_no, to_char(m.date_challan,'dd-MON-yyyy') challan_date, p.party_id, p.party_name,\r\n                        d.quantity, d.purchase_unit_price unit_price, d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti tax\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.purchase_type in ('L','I')\r\n                        and d.item_id = ", ItemID, "\r\n                        and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        and m.is_deleted = false\r\n                        and d.s_p_return = 0\r\n                        and d.is_rebatable = true\r\n                        order by m.challan_id" };
                    empty = string.Concat(itemID3);
                }
                dataTable = this.db.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetAuditTrailData(DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] str = new string[] { "select id,to_char(tstamp,'dd-MON-yyyy HH12:MI:SS') modified_date,\r\n                            tabname modified_table, operation, old_val original_data,new_val modified_data\r\n                            from logging.t_history\r\n                            where tstamp >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and tstamp <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            order by tabname" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetAuditTrailData(DateTime fDate, DateTime tDate, string table)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] str = new string[] { "select id,to_char(tstamp,'dd-MON-yyyy HH12:MI:SS') modified_date,\r\n                            tabname modified_table, operation, old_val original_data,new_val modified_data,client_addr,array_to_string(updated_cols, ',') updated_cols\r\n                            from logging.t_history\r\n                            where cast(tstamp as date) >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and cast(tstamp as date) <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and tabname = '", table, "'\r\n                            order by tabname" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetAuditTrailLogReportData(DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] str = new string[] { "select audit_part,to_char(audit_date,'dd-Mon-yyyy') audit_date,\r\n                            to_char(vm_start_date,'dd-Mon-yyyy') ||' To '|| to_char(vm_end_date,'dd-Mon-yyyy') audit_date_range,\r\n                            vat_month ||'/'||vat_year vat_month_year,challan_no,auditor_name,authority_designation,\r\n                            auditor_comment\r\n                            from nbr_audit_log\r\n                            where audit_date >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            and audit_date <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                            order by audit_part" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetChallanDetailsForAudit(short ID, long ChallanID)
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                if (ID == 1)
                {
                    empty = string.Concat("select ROW_NUMBER() over (order by d.challan_id) RowNo,m.challan_no, i.item_id, i.item_name, u.unit_id, u.unit_code, d.quantity, cast(coalesce(d.purchase_unit_price,0) as decimal(18,2)) unit_price,\r\n                        cast(coalesce(d.quantity*d.purchase_unit_price,0) as decimal(18,2)) total,\r\n                        cast(coalesce(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti,0) as decimal(18,2)) tax,\r\n                        cast(coalesce(d.quantity*d.purchase_unit_price,0) as decimal(18,2))+cast(coalesce(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti,0) as decimal(18,2)) grand_total\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join item i on d.item_id = i.item_id\r\n                        inner join item_unit u on d.unit_id = u.unit_id\r\n                        where d.challan_id = ", ChallanID, "\r\n                        order by item_id");
                }
                else if (ID == 2)
                {
                    empty = string.Concat("select ROW_NUMBER() over (order by d.challan_id) RowNo,m.challan_no, i.item_id, i.item_name, u.unit_id, u.unit_code, d.quantity, cast(coalesce(d.actual_price,0) as decimal(18,2)) unit_price,\r\n                        cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2)) total,\r\n                        cast(coalesce(d.vat+d.sd,0) as decimal(18,2)) tax,\r\n                        cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2))+ cast(coalesce(d.vat+d.sd,0) as decimal(18,2)) grand_total\r\n                        from trns_sale_master m\r\n                        inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                        inner join item i on d.item_id = i.item_id\r\n                        inner join item_unit u on d.unit_id = u.unit_id\r\n                        where d.challan_id = ", ChallanID, "\r\n                        order by item_id");
                }
                else if (ID == 3)
                {
                    empty = string.Concat("select ROW_NUMBER() over (order by m.note_id) RowNo, m.note_no challan_no, i.item_id, i.item_name, u.unit_id, u.unit_code, d.quantity, cast(coalesce(d.actual_price,0) as decimal(18,2)) unit_price,\r\n                        cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2)) total,\r\n                        cast(coalesce(d.return_vat+d.return_sd,0) as decimal(18,2)) tax,\r\n                        cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2))+ cast(coalesce(d.return_vat+d.return_sd,0) as decimal(18,2)) grand_total\r\n                        from trns_note_master m\r\n                        inner join trns_note_detail d on m.note_id = d.note_id\r\n                        inner join item i on d.item_id = i.item_id\r\n                        inner join item_unit u on d.unit_id = u.unit_id\r\n                        where d.note_id = ", ChallanID, "\r\n                        and m.note_type = 'D'\r\n                        order by item_id");
                }
                else if (ID == 4)
                {
                    empty = string.Concat("select ROW_NUMBER() over (order by m.note_id) RowNo, m.note_no challan_no, i.item_id, i.item_name, u.unit_id, u.unit_code, d.quantity, cast(coalesce(d.actual_price,0) as decimal(18,2)) unit_price,\r\n                        cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2)) total,\r\n                        cast(coalesce(d.return_vat+d.return_sd,0) as decimal(18,2)) tax,\r\n                        cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2))+ cast(coalesce(d.return_vat+d.return_sd,0) as decimal(18,2)) grand_total\r\n                        from trns_note_master m\r\n                        inner join trns_note_detail d on m.note_id = d.note_id\r\n                        inner join item i on d.item_id = i.item_id\r\n                        inner join item_unit u on d.unit_id = u.unit_id\r\n                        where d.note_id = ", ChallanID, "\r\n                        and m.note_type = 'C'\r\n                        order by item_id");
                }
                else if (ID == 5)
                {
                    empty = string.Concat("select ROW_NUMBER() over (order by d.challan_id) RowNo,m.challan_no, i.item_id, i.item_name, u.unit_id, u.unit_code, d.quantity, cast(coalesce(d.purchase_unit_price,0) as decimal(18,2)) unit_price,\r\n                        cast(coalesce(d.quantity*d.purchase_unit_price,0) as decimal(18,2)) total,\r\n                        cast(coalesce(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti,0) as decimal(18,2)) tax,\r\n                        cast(coalesce(d.quantity*d.purchase_unit_price,0) as decimal(18,2))+cast(coalesce(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti,0) as decimal(18,2)) grand_total\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join item i on d.item_id = i.item_id\r\n                        inner join item_unit u on d.unit_id = u.unit_id\r\n                        where d.challan_id = ", ChallanID, "\r\n                        and d.is_source_tax_deduct = true\r\n                        order by item_id");
                }
                else if (ID == 6)
                {
                    empty = string.Concat("select ROW_NUMBER() over (order by d.challan_id) RowNo,m.challan_no, i.item_id, i.item_name, u.unit_id, u.unit_code, d.quantity, cast(coalesce(d.actual_price,0) as decimal(18,2)) unit_price,\r\n                            cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2)) total,\r\n                            cast(coalesce(d.vat+d.sd,0) as decimal(18,2)) tax,\r\n                            cast(coalesce(d.quantity*d.actual_price,0) as decimal(18,2))+ cast(coalesce(d.vat+d.sd,0) as decimal(18,2)) grand_total\r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            inner join item i on d.item_id = i.item_id\r\n                            inner join item_unit u on d.unit_id = u.unit_id\r\n                            where d.challan_id = ", ChallanID, "\r\n                            and d.is_source_tax_deduct = true\r\n                            order by item_id");
                }
                else if (ID == 7)
                {
                    empty = string.Concat("select ROW_NUMBER() over (order by d.challan_id) RowNo,m.challan_no, i.item_id, i.item_name, u.unit_id, u.unit_code, d.quantity, cast(coalesce(d.purchase_unit_price,0) as decimal(18,2)) unit_price,\r\n                        cast(coalesce(d.quantity*d.purchase_unit_price,0) as decimal(18,2)) total,\r\n                        cast(coalesce(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti,0) as decimal(18,2)) tax,\r\n                        cast(coalesce(d.quantity*d.purchase_unit_price,0) as decimal(18,2))+cast(coalesce(d.purchase_vat+d.purchase_sd+d.cd+d.rd+d.ait+d.atv+d.tti,0) as decimal(18,2)) grand_total\r\n                        from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                        inner join item i on d.item_id = i.item_id\r\n                        inner join item_unit u on d.unit_id = u.unit_id\r\n                        where d.challan_id = ", ChallanID, "\r\n                        and d.is_rebatable = true\r\n                        order by item_id");
                }
                dataTable = this.db.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public decimal GetDirectSaleQuantity(int IID, string fDate, string tDate)
        {
            decimal num = new decimal(0);
            try
            {
                object[] objArray = new object[] { "\r\n                            select coalesce(sum(d.quantity),0) sale\r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            where m.challan_type = 'S'\r\n                            and m.date_challan >= to_date('", fDate, "','dd/MM/yyyy')\r\n                            and m.date_challan <= to_date('", tDate, "','dd/MM/yyyy')\r\n                            and m.is_deleted = false\r\n                            and d.item_id = ", IID, " " };
                string str = string.Concat(objArray);
                num = Convert.ToDecimal(this.db.GetSingleValue(str));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return num;
        }

        public decimal GetEarlyAvailableStock(string toDate, int itemID, int branchID)
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
            object[] objArray = new object[] { "\r\n                    select distinct\r\n                    ((select case when sum(d.Quantity) is null then 0 else sum(d.Quantity) end  \r\n                    from trns_purchase_detail as d\r\n                    inner join trns_purchase_master as m \r\n                    on d.challan_id = m.challan_id\r\n                    where d.date_insert >='2010-01-01' \r\n                    AND m.date_challan <= to_date('", toDate, "','dd/MM/yyyy') ", str, " ", str1, ")\r\n\t                                            +\r\n                    (select SUM(item_qty) from opening_balance where item_id=", itemID, ")\r\n                                                -\r\n                    ((select case when sum(d.Quantity) is null then 0 else sum(d.Quantity) end  \r\n                    from trns_sale_detail as d \r\n                    inner join trns_sale_master as m\r\n                    on d.challan_id = m.challan_id\r\n                    where d.date_insert >='2010-01-01' AND m.date_challan <=to_date('", toDate, "','dd/MM/yyyy') ", str, " ", str1, ")\r\n                                                + \r\n                     (select case when sum(d.Quantity) is null then 0 else sum(d.Quantity) end \r\n                     from trns_production_detail as d\r\n                     inner join trns_production_master as m\r\n                     on d.production_id = m.production_id\r\n                     where d.date_insert >='2010-01-01' AND m.date_production <=to_date('", toDate, "','dd/MM/yyyy')  and d.status in('I','S') ", str, " ", str1, "))\r\n                                                -\r\n                    (select case when sum(d.Quantity) is null then 0 else sum(d.Quantity) end \r\n                     from trns_transfer_detail as d\r\n                     inner join trns_transfer_master as m\r\n                     on d.transfer_id = m.transfer_id\r\n                     where d.date_insert >='2010-01-01' AND d.date_insert <= to_date('", toDate, "', 'dd/MM/yyyy')  and m.transfer_status = 'I' ", str, " ", str1, ")\r\n\r\n                    ) as earlyAvailableStock\r\n                    from trns_purchase_detail" };
            string str2 = string.Concat(objArray);
            return Convert.ToDecimal(this.db.GetSingleValue(str2));
        }

        public long GetEarlyAvailableStockAccounting(string toDate, int itemID, int branchID)
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
            return Convert.ToInt64(this.db.GetSingleValue(str2));
        }

        public long GetEarlyAvailableStockForSale(string toDate, int itemID)
        {
            string str = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND item_id = ", itemID);
            }
            string[] strArrays = new string[] { "select distinct\r\n                        ((select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_purchase_detail where date_insert >='2010-01-01' AND date_insert <= '", toDate, "' ", str, ")\r\n                            -\r\n                        ((select case when sum(Quantity) is null then 0 else sum(Quantity) end  from trns_sale_detail where date_insert >='2010-01-01' AND date_insert <= '", toDate, "' ", str, ")\r\n                            + \r\n                        (select case when sum(Quantity) is null then 0 else sum(Quantity) end from trns_production_detail where date_insert >='2010-01-01' AND date_insert <= '", toDate, "' and status = 'R' ", str, "))) as earlyAvailableStock\r\n                        from trns_purchase_detail" };
            string str1 = string.Concat(strArrays);
            return Convert.ToInt64(this.db.GetSingleValue(str1));
        }

        public DataTable GetFinishedProductInfo(int finishedItemId, string fromDate)
        {
            DataTable dataTable;
            try
            {
                DataTable dataTable1 = new DataTable();
                string str = "";
                object[] objArray = new object[] { " --opening balance\r\n\t\t       select '", fromDate, "' as transaction_date,ob.item_qty as opening_balance,'' as unit_code, 0 as utpadito_ponner_poriman,0 as mot_utpadon\r\n\t\t       ,0 as bikroyer_poriman,0 as prantik_jer,'opening_balance' as transaction_type\r\n\t\t       from opening_balance ob where ob.item_id=", finishedItemId, "\r\n\t\t       union all\r\n                --production(From purchase table for finished product)\r\n                       select to_char(m.date_challan,'dd/MM/YYYY') as transaction_date,0 as opening_balance,i.unit_code,d.quantity as utpadito_ponner_poriman,0 as mot_utpadon,0 as bikroyer_poriman,0 as prantik_jer\r\n                       ,'production' as transaction_type\r\n                       from trns_purchase_detail d\r\n                       inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                       inner join item_unit i on d.unit_id = i.unit_id\r\n                       where m.purchase_type = 'F' and d.item_id = ", finishedItemId, "\r\n                      --Sale\r\n                      union all\r\n                      select to_char(m.date_challan,'dd/MM/YYYY') as transaction_date,0 as opening_balance,i.unit_code,0 as utpadito_ponner_poriman,0 as mot_utpadon,d.quantity as bikroyer_poriman,0 as prantik_jer\r\n                      ,'sale' as transaction_type\r\n                      from trns_sale_detail d\r\n                      inner join trns_sale_master m on d.challan_id = m.challan_id\r\n                      inner join item_unit i on d.unit_id = i.unit_id\r\n                      where d.item_id = ", finishedItemId };
                str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetItemForAudit(short ID, DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                if (ID == 1)
                {
                    string[] str = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_purchase_master m\r\n                                inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where m.purchase_type in ('L','I')\r\n                                and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                and d.s_p_return = 0\r\n                                order by d.item_id" };
                    empty = string.Concat(str);
                }
                else if (ID == 2)
                {
                    string[] strArrays = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_sale_master m\r\n                                inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                order by d.item_id" };
                    empty = string.Concat(strArrays);
                }
                else if (ID == 3)
                {
                    string[] str1 = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_note_master m\r\n                                inner join trns_note_detail d on m.note_id = d.note_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                and m.note_type = 'D'\r\n                                order by d.item_id" };
                    empty = string.Concat(str1);
                }
                else if (ID == 4)
                {
                    string[] strArrays1 = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_note_master m\r\n                                inner join trns_note_detail d on m.note_id = d.note_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where  m.date_note >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_note <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                and m.note_type = 'C'\r\n                                order by d.item_id" };
                    empty = string.Concat(strArrays1);
                }
                else if (ID == 5)
                {
                    string[] str2 = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_purchase_master m\r\n                                inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where m.purchase_type in ('L','I')\r\n                                and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                and d.s_p_return = 0\r\n                                and d.is_source_tax_deduct = true\r\n                                order by d.item_id" };
                    empty = string.Concat(str2);
                }
                else if (ID == 6)
                {
                    string[] strArrays2 = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_sale_master m\r\n                                inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                and d.is_source_tax_deduct = true\r\n                                order by d.item_id" };
                    empty = string.Concat(strArrays2);
                }
                else if (ID == 7)
                {
                    string[] str3 = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_purchase_master m\r\n                                inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where m.purchase_type in ('L','I')\r\n                                and m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                and d.s_p_return = 0\r\n                                and d.is_rebatable = true\r\n                                order by d.item_id" };
                    empty = string.Concat(str3);
                }
                dataTable = this.db.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetItemForAuditAccounting(short ID, DateTime fDate, DateTime tDate)
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                if (ID == 1)
                {
                    string[] str = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_purchase_master m\r\n                                inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                order by d.item_id" };
                    empty = string.Concat(str);
                }
                else if (ID == 2)
                {
                    string[] strArrays = new string[] { "select distinct  d.item_id, i.item_name\r\n                                from trns_sale_master m\r\n                                inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                                inner join item i on d.item_id = i.item_id\r\n                                where  m.date_challan >= to_date('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.date_challan <= to_date('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                                and m.is_deleted = false\r\n                                order by d.item_id" };
                    empty = string.Concat(strArrays);
                }
                dataTable = this.db.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public string GetPaymentType(int? id)
        {
            string empty = string.Empty;
            try
            {
                if (!id.HasValue)
                {
                    empty = "NA";
                }
                else
                {
                    string str = string.Concat("select code_name from app_code_detail where code_id_m = 11 and is_deleted = false and code_id_d = ", id);
                    object singleValue = this.db.GetSingleValue(str);
                    empty = (singleValue == null ? "NA" : Convert.ToString(singleValue));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return empty;
        }

        public DataTable GetProducedProduct()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select distinct  d.item_id,i.item_name\r\n                            from trns_purchase_master m\r\n                            inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                            inner join item i on d.item_id = i.item_id\r\n                            where m.challan_type = 'C'\r\n                            and m.is_deleted = false\r\n                            order by item_id");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetProductSaleQuantity(int IID, string fDate, string tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select max(purchase) produce,max(sale) sale\r\n                            from(\r\n\r\n                            select  sum(d.quantity) purchase, 0 sale\r\n                            from trns_purchase_master m\r\n                            inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                            where m.challan_type = 'C'\r\n                            and m.date_challan >= to_date('", fDate, "','dd/MM/yyyy')\r\n                            and m.date_challan <= to_date('", tDate, "','dd/MM/yyyy')\r\n                            and m.is_deleted = false\r\n                            and d.item_id = ", IID, "\r\n                            union all\r\n\r\n                            select 0 purchase, sum(d.quantity) sale\r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            where m.challan_type = 'S'\r\n                            and m.date_challan >= to_date('", fDate, "','dd/MM/yyyy')\r\n                            and m.date_challan <= to_date('", tDate, "','dd/MM/yyyy')\r\n                            and m.is_deleted = false\r\n                            and d.item_id = ", IID, "\r\n                            )mqmm" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetPSAvgValue(int itemID)
        {
            object[] objArray = new object[] { "\r\n                    select max(purchase_unit_price) purchase_unit_price,max(vat_rate) vat_rate,max(sd_rate) sd_rate, max(sale_unit_price) sale_unit_price\r\n                    from\r\n                    (\r\n                    select case when SUM(quantity)!=0 then  SUM(quantity*purchase_unit_price)/SUM(quantity) else 0 end purchase_unit_price, 0  sale_unit_price, vat_rate,sd_rate\r\n                    from trns_purchase_detail where item_id = ", itemID, " group by vat_rate,sd_rate\r\n\r\n                    UNION ALL \r\n\r\n                      select 0 purchase_unit_price,case when SUM(quantity)!=0 then SUM(quantity*actual_price)/SUM(quantity) else 0 end sale_unit_price,0 vat_rate, 0 sd_rate\r\n                    from trns_sale_detail where item_id = ", itemID, "\r\n\r\n                    )muktadir " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public string GetPurchaseChallanNumber(long id)
        {
            string empty = string.Empty;
            try
            {
                string str = string.Concat("select challan_no from trns_purchase_master where challan_id = ", id, " and is_deleted = false");
                object singleValue = this.db.GetSingleValue(str);
                empty = (singleValue == null ? "NA" : Convert.ToString(singleValue));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return empty;
        }

        public DataTable GetQuantityToMadePerProduct(int fgpID, int priceID)
        {
            DataTable dataTable = new DataTable();
            string str = "";
            try
            {
                if (priceID > 0)
                {
                    str = string.Concat(" and pi.price_id = ", priceID);
                }
                object[] objArray = new object[] { "select distinct ROW_NUMBER() OVER(ORDER BY pri.price_id) AS sl_no, pri.quantity_total as Quantity, i.item_name,i.item_id,ui.unit_code,ui.unit_id,ct.category_name sub_ctg_name,\r\n\t\t                        ctp.category_name ctg_name\r\n                                 --,coalesce(pri.txtquantityprice/pri.quantity,0) unit_price_old \r\n                                --,(select tax_value sd_rate from item_tax_values where item_id = tpd.item_id and tax_id = 3 and is_deleted = false)\r\n\t\t                        --,(select tax_value vat_rate from item_tax_values where item_id = tpd.item_id and tax_id = 4 and is_deleted = false)\r\n                                --coalesce(tpd.vat_rate,0) vat_rate,coalesce(tpd.sd_rate,0) sd_rate,\r\n\t\t                        ,(select purchase_unit_price from trns_purchase_detail where item_id = i.item_id order by date_insert desc limit 1) unit_price\r\n                                --,(select iu.unit_code from item_unit iu inner join trns_purchase_detail pd on pd.unit_id=iu.unit_id where pd.item_id=i.item_id order by pd.challan_id desc limit 1 ) as PurchaseUnit\r\n                                ,(select u.unit_code from item_unit u inner join price_raw_item pr on u.unit_id=pr.unit_id_sec where pr.item_id=i.item_id limit 1) production_unit\r\n                                ,(select u.unit_id from item_unit u inner join price_raw_item pr on u.unit_id=pr.unit_id_sec where pr.item_id=i.item_id limit 1) production_unit_id\r\n                               ,coalesce(pri.wastageparcent,0) wastageparcent\r\n                               ,pri.wastage_quantity\r\n                            from price_raw_item as pri\r\n                            inner join price_item as pi on pri.price_id = pi.price_id\r\n                            inner join item as i on pri.item_id = i.item_id\r\n                            left join item_unit as ui on ui.unit_id = pri.unit_id\r\n                            left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n\t\t\t                left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n\t\t\t                left join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                            where pi.item_id = ", fgpID, " ", str, " and pi.price_declaration_no <> 'No' and pi.is_deleted = false order by i.item_id" };
                string str1 = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetQuantityToMadePerProductReconcil(int fgpID, int priceID)
        {
            DataTable dataTable = new DataTable();
            string str = "";
            try
            {
                if (priceID > 0)
                {
                    str = string.Concat(" and pi.price_id = ", priceID);
                }
                object[] objArray = new object[] { "select distinct ROW_NUMBER() OVER(ORDER BY pri.price_id) AS sl_no, pri.quantity_total as Quantity, i.item_name,i.item_id,ui.unit_code,ui.unit_id,pri.unit_id_sec,ct.category_name sub_ctg_name,\r\n\t\t                        ctp.category_name ctg_name\r\n\t\t                        --,coalesce(pri.txtquantityprice/pri.quantity,0) unit_price_old \r\n                                --,(select tax_value sd_rate from item_tax_values where item_id = tpd.item_id and tax_id = 3 and is_deleted = false)\r\n\t\t                        --,(select tax_value vat_rate from item_tax_values where item_id = tpd.item_id and tax_id = 4 and is_deleted = false)\r\n                                --coalesce(tpd.vat_rate,0) vat_rate,coalesce(tpd.sd_rate,0) sd_rate,\r\n\t\t                        ,(select purchase_unit_price from trns_purchase_detail where item_id = i.item_id order by date_insert desc limit 1) unit_price\r\n                               ,(select ui.unit_code from trns_purchase_detail tpd\r\n\t\t\t\t                  inner join item_unit as ui on tpd.unit_id=ui.unit_id\r\n                                  where item_id = i.item_id order by tpd.date_insert desc limit 1\r\n\t\t\t\t                  ) purchase_unit\r\n                                ,(select ui.unit_id from trns_purchase_detail tpd\r\n\t\t\t\t                  inner join item_unit as ui on tpd.unit_id=ui.unit_id\r\n                                  where item_id = i.item_id order by tpd.date_insert desc limit 1\r\n\t\t\t\t                  ) purchase_unit_id\r\n                                --,(select iu.unit_code from item_unit iu inner join trns_purchase_detail pd on pd.unit_id=iu.unit_id where pd.item_id=i.item_id order by pd.challan_id desc limit 1 ) as PurchaseUnit\r\n                                ,(select u.unit_code from item_unit u inner join price_raw_item pr on u.unit_id=pr.unit_id_sec where pr.item_id=i.item_id limit 1) production_unit\r\n                                ,(select u.unit_id from item_unit u inner join price_raw_item pr on u.unit_id=pr.unit_id_sec where pr.item_id=i.item_id limit 1) production_unit_id\r\n                               ,coalesce(pri.wastageparcent,0) wastageparcent\r\n                               ,pri.wastage_quantity\r\n                            from price_raw_item as pri\r\n                            inner join price_item as pi on pri.price_id = pi.price_id\r\n                            inner join item as i on pri.item_id = i.item_id\r\n                            left join item_unit as ui on ui.unit_id = pri.unit_id_sec\r\n                            left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n\t\t\t    left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n\t\t\t    --left join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                            where pi.item_id = ", fgpID, " ", str, " and pi.price_declaration_no <> 'No' and pi.is_deleted = false order by i.item_id" };
                string str1 = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public string GetSaleChallanNumber(long id)
        {
            string empty = string.Empty;
            try
            {
                string str = string.Concat("select challan_no from trns_sale_master where challan_id = ", id, " and is_deleted = false");
                object singleValue = this.db.GetSingleValue(str);
                empty = (singleValue == null ? "NA" : Convert.ToString(singleValue));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return empty;
        }

        public decimal GetStockinVatMonth(string fDate, string tDate, int itemID, int branchID)
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
            string[] strArrays = new string[] { "\r\n                    select distinct\r\n                    ((select coalesce(sum(d.Quantity),0)  \r\n                    from trns_purchase_detail as d\r\n                    inner join trns_purchase_master as m \r\n                    on d.challan_id = m.challan_id\r\n                    where m.date_challan >=to_date('", fDate, "','dd/MM/yyyy') \r\n                    AND m.date_challan <= to_date('", tDate, "','dd/MM/yyyy') ", str, " ", str1, ")\r\n                                                -\r\n                    (select coalesce(sum(d.Quantity),0)\r\n                     from trns_transfer_detail as d\r\n                     inner join trns_transfer_master as m\r\n                     on d.transfer_id = m.transfer_id\r\n                     where d.date_insert >=to_date('", fDate, "','dd/MM/yyyy')\r\n                     AND d.date_insert <= to_date('", tDate, "','dd/MM/yyyy') and m.transfer_status = 'I' ", str, " ", str1, ")\r\n\r\n                    ) as earlyAvailableStock\r\n                    from trns_purchase_detail" };
            string str2 = string.Concat(strArrays);
            return Convert.ToDecimal(this.db.GetSingleValue(str2));
        }

        public bool InsertAccountingBookAuditLog(NBRAccountingBook objNAB)
        {
            bool flag = false;
            try
            {
                object[] auditorName = new object[] { "INSERT INTO nbr_audit_log(auditor_name, audit_part, audit_date, vat_month, vat_year,vm_start_date, vm_end_date, challan_no, auditor_comment,authority_designation,item_id)\r\n       VALUES ('", objNAB.AuditorName, "', '", objNAB.AuditPart, "', to_timestamp('", objNAB.AuditorDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), \r\n                '", objNAB.VatMonth, "', ", objNAB.VatYear, ",to_timestamp('", objNAB.VMStartDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                to_timestamp('", objNAB.VMSEndDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", objNAB.ChallanNo, "', '", objNAB.AuditorComment, "','", objNAB.AuditorDesignation, "',", objNAB.itemtId, ");" };
                string str = string.Concat(auditorName);
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }

        public DataTable PurchaseAccountingBook(DateTime fromDate, DateTime toDate, int itemID, int branchID)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            if (branchID <= 0)
            {
                string[] strArrays = new string[] { "select 'P' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, Quantity,\r\n\t           d.quantity*d.purchase_unit_price price, d.purchase_sd sd, d.purchase_vat vat,               \r\n                                --case when d.s_p_return = 3 then d.quantity*d.sale_unit_price else d.quantity*d.purchase_unit_price end  price,\r\n\t                            --case when d.s_p_return = 3 then d.sale_sd else d.purchase_sd end sd,\r\n\t                            --case when d.s_p_return = 3 then d.sale_vat else d.purchase_vat end vat,\r\n                             m.Remarks,\r\n                            tp.party_name , tp.party_bin ,d.Date_insert,tp.party_address,i.item_name \r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                            where m.date_challan >=TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_challan <=TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') ", str, "   AND d.Is_deleted = false \r\n\r\n                       \r\n   UNION ALL\r\n\r\n                \r\n                select 'S' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, Quantity ,\r\n                d.quantity*d.actual_price as price, d.sd sd, d.vat vat,\r\n                             case when m.challan_type = 'D' then 'Dispose Data' else m.Remarks end Remarks,\r\n                            tp.party_name , tp.party_bin ,d.Date_insert,tp.party_address ,i.item_name\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i  on i.item_id = d.item_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                           where m.date_challan >= TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_challan <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') ", str, "  AND d.Is_deleted = false\r\n\r\n    UNION ALL\r\n\r\n               select 'Pr' status,m.org_branch_reg_id, m.challan_batch_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, \r\n               d.quantity Quantity ,d.quantity*d.unit_price price,0 sd, 0 vat,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert,tp.party_address,i.item_name \r\n                            from trns_production_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_production_detail d\r\n                            on d.Production_id = m.Production_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_production >= TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_production <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                           ", str, " AND m.trns_status in ('I','S')  AND d.Is_deleted = false  \r\n                  --order by Date\r\n\r\nUNION ALL\r\n\r\n         select 'T' status,m.receiving_branch_id as org_branch_reg_id, m.challan_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, \r\n          Quantity ,0 price,0 sd, 0 vat,\r\n                            d.Remarks , obri.branch_unit_name , obri.branch_unit_bin ,d.Date_insert,'' party_address,i.item_name \r\n                            from trns_transfer_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_transfer_detail d\r\n                            on d.transfer_id = m.transfer_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                           -- inner join trns_party tp\r\n                            inner join org_branch_reg_info as obri\r\n                            on obri.org_branch_reg_id = m.receiving_branch_id\r\n                            where m.date_insert >= TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_insert <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                           ", str, "   AND m.transfer_status='I'  AND d.Is_deleted = false \r\n                  order by Date_insert" };
                str1 = string.Concat(strArrays);
            }
            else
            {
                object[] objArray = new object[] { "select 'P' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, Quantity,\r\n\t                  d.quantity*d.purchase_unit_price price, d.purchase_sd sd, d.purchase_vat vat,             \r\n                                --case when d.s_p_return = 3 then d.quantity*d.sale_unit_price else d.quantity*d.purchase_unit_price end  price,\r\n\t                            --case when d.s_p_return = 3 then d.sale_sd else d.purchase_sd end sd,\r\n\t                            --case when d.s_p_return = 3 then d.sale_vat else d.purchase_vat end vat,\r\n                            m.Remarks,\r\n                            tp.party_name , tp.party_bin ,d.Date_insert,tp.party_address,i.item_name \r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            left join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_challan >=TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_challan <=TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') ", str, "   AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, " \r\n\r\n                       \r\n   UNION ALL\r\n\r\n                \r\n                select 'S' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, Quantity ,\r\n                d.quantity*d.actual_price as price, d.sd sd, d.vat vat,\r\n                            case when m.challan_type = 'D' then 'Dispose Data' else m.Remarks end Remarks,\r\n                            tp.party_name , tp.party_bin ,d.Date_insert,tp.party_address ,i.item_name\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d\r\n                            on d.Challan_id = m.Challan_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            left join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                           where m.date_challan >= TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_challan <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') ", str, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n\r\n    UNION ALL\r\n\r\n               select 'Pr' status,m.org_branch_reg_id, m.challan_batch_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, \r\n                Quantity ,d.quantity*d.unit_price price,0 sd, 0 vat,\r\n                            m.Remarks , tp.party_name , tp.party_bin ,d.Date_insert,tp.party_address,i.item_name \r\n                            from trns_production_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_production_detail d\r\n                            on d.Production_id = m.Production_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                            inner join trns_party tp\r\n                            on tp.party_id = m.party_id\r\n                            where m.date_production >= TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_production <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                           ", str, " AND m.trns_status='I'  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, " \r\n                  --order by Date\r\n\r\nUNION ALL\r\n\r\n         select 'T' status,m.receiving_branch_id as org_branch_reg_id, m.challan_no as challan_no, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, \r\n          Quantity ,0 price,0 sd, 0 vat,\r\n                            d.Remarks , obri.branch_unit_name , obri.branch_unit_bin ,d.Date_insert,'' party_address,i.item_name \r\n                            from trns_transfer_master m\r\n                            inner join org_registration_info o\r\n                            on m.Organization_id = o.Organization_id\r\n                            inner join trns_transfer_detail d\r\n                            on d.transfer_id = m.transfer_id\r\n                            inner join Item i\r\n                            on i.item_id = d.item_id\r\n                           -- inner join trns_party tp\r\n                            inner join org_branch_reg_info as obri\r\n                            on obri.org_branch_reg_id = m.receiving_branch_id\r\n                            where m.date_insert >= TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_insert <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                           ", str, "   AND m.transfer_status='I'  AND d.Is_deleted = false and m.receiving_branch_id=", branchID, "\r\n                  order by Date_insert" };
                str1 = string.Concat(objArray);
            }
            return this.db.GetDataTable(str1);
        }

        public DataTable SalesAccountingBook(DateTime fDate, DateTime tDate, int itemId, int branchID)
        {
            string str = "";
            string.Concat(" AND org_branch_reg_id = ", branchID);
            if (branchID <= 0)
            {
                object[] objArray = new object[] { "select 'S' status,m.org_branch_reg_id, m.challan_no, to_char(m.date_challan,'dd/MM/yyyy') challan_date , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, Quantity ,\r\n                        i.item_name,d.vat,d.sd,\r\n                            case when m.challan_type = 'D' then 'Dispose Data' else m.Remarks end Remarks , \r\n                            tp.party_name ,  tp.party_address ,d.Date_insert ,tp.party_bin ,d.actual_price as unit_price, 0 vat_rate, 0 sd_rate\r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                           where m.date_challan >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND m.date_challan <= TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND d.item_id =", itemId, "  AND d.Is_deleted = false \r\n                UNION ALL\r\n\r\n                   select 'P' status,m.org_branch_reg_id, m.challan_no , to_char(m.date_challan,'dd/MM/yyyy') challan_date, o.organization_name , o.registration_no , to_char(d.Date_insert,'dd/MM/yyyy') as Date, Quantity,\r\n                    i.item_name,d.purchase_vat,d.purchase_sd,d.Remarks , tp.party_name  ,tp.party_address ,d.Date_insert, tp.party_bin ,d.purchase_unit_price as unit_price,d.vat_rate,d.sd_rate\r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join trns_party tp on tp.party_id = m.party_id\r\n                            where m.date_challan >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND m.date_challan <=TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND d.item_id =", itemId, "  AND d.Is_deleted = false \r\n\r\n                            order by Date_insert" };
                str = string.Concat(objArray);
            }
            else
            {
                object[] str1 = new object[] { "select 'S' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity ,\r\n                           case when m.challan_type = 'D' then 'Dispose Data' else m.Remarks end Remarks , \r\n                            tp.party_name , tp.party_bin,d.Date_insert,d.actual_price as unit_price, 0 vat_rate, 0 sd_rate \r\n                            from trns_sale_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            left join trns_party tp on tp.party_id = m.party_id\r\n                           where m.date_challan >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND m.date_challan <= TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND d.item_id =", itemId, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n                UNION ALL\r\n\r\n                        select 'P' status,m.org_branch_reg_id, m.challan_no , o.organization_name , o.registration_no , to_char(d.Date_insert,'dd-MM-yyyy') as Date, Quantity,\r\n                            d.Remarks , tp.party_name , tp.party_bin,d.Date_insert,d.purchase_unit_price as unit_price,d.vat_rate,d.sd_rate \r\n                            from trns_purchase_master m\r\n                            inner join org_registration_info o on m.Organization_id = o.Organization_id\r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id\r\n                            inner join trns_party tp on tp.party_id = m.party_id\r\n                            where m.date_challan >=TO_DATE('", fDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND m.date_challan <=TO_DATE('", tDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND d.item_id =", itemId, "  AND d.Is_deleted = false AND m.org_branch_reg_id = ", branchID, "\r\n\r\n                            order by Date_insert" };
                str = string.Concat(str1);
            }
            return this.db.GetDataTable(str);
        }

        public bool SaveAllChallanAudit(short ID, DataTable dt, string name, string comment, NBRAccountingBook objNAB)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            try
            {
                if (ID == 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        object[] objArray = new object[] { "update trns_purchase_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", Convert.ToInt64(dt.Rows[i]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray));
                    }
                }
                else if (ID == 2)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        object[] objArray1 = new object[] { "update trns_sale_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", Convert.ToInt64(dt.Rows[j]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray1));
                    }
                }
                else if (ID == 3)
                {
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        object[] objArray2 = new object[] { "update trns_note_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where note_id = ", Convert.ToInt64(dt.Rows[k]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray2));
                    }
                }
                else if (ID == 4)
                {
                    for (int l = 0; l < dt.Rows.Count; l++)
                    {
                        object[] objArray3 = new object[] { "update trns_note_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where note_id = ", Convert.ToInt64(dt.Rows[l]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray3));
                    }
                }
                else if (ID == 5)
                {
                    for (int m = 0; m < dt.Rows.Count; m++)
                    {
                        object[] objArray4 = new object[] { "update trns_purchase_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", Convert.ToInt64(dt.Rows[m]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray4));
                    }
                }
                else if (ID == 6)
                {
                    for (int n = 0; n < dt.Rows.Count; n++)
                    {
                        object[] objArray5 = new object[] { "update trns_sale_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", Convert.ToInt64(dt.Rows[n]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray5));
                    }
                }
                else if (ID == 7)
                {
                    for (int o = 0; o < dt.Rows.Count; o++)
                    {
                        object[] objArray6 = new object[] { "update trns_purchase_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", Convert.ToInt64(dt.Rows[o]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray6));
                    }
                }
                else if (ID == 8)
                {
                    for (int p = 0; p < dt.Rows.Count; p++)
                    {
                        object[] objArray7 = new object[] { "update trns_treasury_challan\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", Convert.ToInt64(dt.Rows[p]["challan_id"]) };
                        arrayLists.Add(string.Concat(objArray7));
                    }
                }
                object[] auditorName = new object[] { "INSERT INTO nbr_audit_log(auditor_name, audit_part, audit_date, vat_month, vat_year,vm_start_date, vm_end_date, challan_no, auditor_comment,authority_designation)\r\n       VALUES ('", objNAB.AuditorName, "', '", objNAB.AuditPart, "', to_timestamp('", objNAB.AuditorDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), \r\n                '", objNAB.VatMonth, "', ", objNAB.VatYear, ",to_timestamp('", objNAB.VMStartDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                to_timestamp('", objNAB.VMSEndDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", objNAB.ChallanNo, "', '", objNAB.AuditorComment, "','", objNAB.AuditorDesignation, "')" };
                arrayLists.Add(string.Concat(auditorName));
                flag = this.db.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }

        public bool SaveSingleChallanAudit(short ID, long ChalanID, string name, string comment, NBRAccountingBook objNAB)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            try
            {
                if (ID == 1)
                {
                    object[] objArray = new object[] { "update trns_purchase_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", ChalanID };
                    arrayLists.Add(string.Concat(objArray));
                }
                else if (ID == 2)
                {
                    object[] objArray1 = new object[] { "update trns_sale_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", ChalanID, " " };
                    arrayLists.Add(string.Concat(objArray1));
                }
                else if (ID == 3)
                {
                    object[] objArray2 = new object[] { "update trns_note_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where note_id = ", ChalanID, " " };
                    arrayLists.Add(string.Concat(objArray2));
                }
                else if (ID == 4)
                {
                    object[] objArray3 = new object[] { "update trns_note_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where note_id = ", ChalanID, " " };
                    arrayLists.Add(string.Concat(objArray3));
                }
                else if (ID == 5)
                {
                    object[] objArray4 = new object[] { "update trns_purchase_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", ChalanID };
                    arrayLists.Add(string.Concat(objArray4));
                }
                else if (ID == 6)
                {
                    object[] objArray5 = new object[] { "update trns_sale_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", ChalanID, " " };
                    arrayLists.Add(string.Concat(objArray5));
                }
                else if (ID == 7)
                {
                    object[] objArray6 = new object[] { "update trns_purchase_master\r\n                        set nbr_auth_name = '", name, "', nbr_auth_comment = '", comment, "', audit_date = now(), isAudited = true\r\n                        where challan_id = ", ChalanID };
                    arrayLists.Add(string.Concat(objArray6));
                }
                object[] auditorName = new object[] { "INSERT INTO nbr_audit_log(auditor_name, audit_part, audit_date, vat_month, vat_year,vm_start_date, vm_end_date, challan_no, auditor_comment,authority_designation)\r\n       VALUES ('", objNAB.AuditorName, "', '", objNAB.AuditPart, "', to_timestamp('", objNAB.AuditorDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), \r\n                '", objNAB.VatMonth, "', ", objNAB.VatYear, ",to_timestamp('", objNAB.VMStartDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                to_timestamp('", objNAB.VMSEndDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", objNAB.ChallanNo, "', '", objNAB.AuditorComment, "','", objNAB.AuditorDesignation, "')" };
                arrayLists.Add(string.Concat(auditorName));
                flag = this.db.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }
    }
}
