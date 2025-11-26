using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CSVXMLBLL
    {
        private DBUtility db = new DBUtility();

        public CSVXMLBLL()
        {
        }

        public DataTable GetAdjustmentVatSd(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct \r\n\t                    COALESCE((select COALESCE(vat_closing_balance,0) from vat_sd_closing where type_closing='V' and isVATSDadjustment=true and vat_closing_balance!=0 limit 1),0) AS vat_closing_balance,\r\n\t                    COALESCE((select COALESCE(sd_closing_balance,0) from vat_sd_closing where type_closing='S' and isVATSDadjustment=true and sd_closing_balance!=0  limit 1),0) AS sd_closing_balance \r\n\t                    from vat_sd_closing where organization_id=", organizationId, " \r\n                        and  CAST(date_closing as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(date_closing as DATE) <= to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetAllDataByPartyForMushok11(DateTime fDate, DateTime tDate, int PartyID, string ChallanNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                if (PartyID > 0)
                {
                    str = string.Concat(str, " and tp.Party_id = ", PartyID);
                }
                if (!string.IsNullOrEmpty(ChallanNo))
                {
                    str = string.Concat(str, " and tsm.challan_no='", ChallanNo, "'");
                }
                string[] strArrays = new string[] { " SELECT tp.party_name Customer_name, coalesce(tp.party_address::varchar(250),'--') Customer_Address, coalesce(tp.party_tin::varchar(150),'--') Customer_TIN, \r\n                            coalesce(tsm.ultimate_destination::varchar(150),'--') Goods_Services_Shipping_Address, \r\n                            acd.code_name Vehicle_Type, tsm.challan_no Challan_No, to_char(tsm.date_challan,'dd-MON-yyyy') Challan_Date, to_char(tsm.date_challan::Time, 'HH24:MI') Challan_Time, \r\n                            to_char(tsm.date_goods_delivery,'dd-MON-yyyy') Goods_Unload_Date,to_char(tsm.date_goods_delivery::Time, 'HH24:MI') Goods_Unload_Time, tsm.vehicle_no Vehicle_No, row_number() over (order by i.item_name nulls last) as Sl_No,\r\n                            i.item_name Goods_Services_Name, \r\n                            tsd.Quantity Quantity, tsd.actual_price unit_Price, tsd.Sd SD_Amount,(tsd.Quantity*tsd.actual_price+tsd.Sd) total_price_sd, tsd.Vat VAT_Amount,\r\n                            (tsd.Quantity*tsd.actual_price+tsd.Sd+tsd.Vat) total_price_sd_vat,\r\n\r\n                            to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),1,2)))||' '||substr(to_char(date_challan, 'dd/yyyy/MONTH'),9)||' '||to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),7,4))) TextDate,\r\n                            to_text(int2(substr(to_char(date_challan, 'HH24:mi'),1,2)))||' HOUR '||to_text(int2(substr(to_char(date_challan, 'hh:mi'),4,2)))||' MINUTE' TextTime, (acd.code_name||'  '||tsm.vehicle_no) Vehicle \r\n                        FROM trns_sale_master tsm \r\n                        inner join trns_sale_detail tsd on tsm.Challan_id=tsd.Challan_id\r\n                        inner join trns_party tp on tsm.Party_id = tp.Party_id\r\n                        left join app_code_detail acd on tsm.vehicle_type_m = acd.code_id_m AND tsm.vehicle_type_d=acd.code_id_d\r\n                        inner join item i on tsd.Item_id = i.Item_id\r\n                        WHERE tsm.challan_type='S'\r\n                        and tsm.Is_deleted=false \r\n                        and tsm.date_challan>= to_date('", fDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy') \r\n                        and tsm.date_challan<= to_date('", tDate.ToString("dd/MM/yyyy"), "','MM/dd/yyyy') \r\n                        ", str, " \r\n                        order by tsm.date_challan " };
                string str1 = string.Concat(strArrays);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getATDataPart6(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(sum(d.at),0) as at from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id=m.challan_id\r\n                        where m.challan_type='P' and m.purchase_type='I' AND m.organization_id=", organizationId, " \r\n                        and CAST(d.ait_refund_date as DATE) >= to_date('", fDate, "', 'dd/MM/yyyy')\r\n                      AND CAST(d.ait_refund_date as DATE) <= to_date('", tDate, "', 'dd/MM/yyyy') " };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetClosingVatSd(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct\r\n\t                    COALESCE((select COALESCE(closing_balance,0) from vat_sd_closing where type_closing='V' and isVATSDadjustment=false limit 1),0) AS vat_closing_balance,\r\n\t                    COALESCE((select COALESCE(closing_balance,0) from vat_sd_closing where type_closing='S' and isVATSDadjustment=false limit 1),0) AS sd_closing_balance \r\n\t                    from vat_sd_closing where organization_id=", organizationId, " and  CAST(date_closing as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(date_closing as DATE) <= to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetCustomerFor11()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select distinct tsm.party_id, tp.party_name \r\n                            from trns_sale_master as tsm\r\n                            inner join trns_party as tp on tsm.party_id = tp.party_id\r\n                            where tp.is_deleted = false\r\n                            and tsm.is_deleted = false");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getDetails27(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select m.other_note_no note_no, to_char(m.date_note, 'dd/MM/yyyy') as date_note,d.oa_subject,d.vat_amount rent,d.actual_price VAT,d.no_of_days,case when d.reason_drcr!=8 then d.interest_pct end interest_pct,\r\n            case when d.reason_drcr!=8 then d.interest_amount end interest_amount,case when d.particulars is not null and d.particulars!='' then d.particulars else d.oa_description end particulars,oa_case_no\r\n            from trns_note_master m\r\n            inner join trns_note_detail d on m.note_id = d.note_id\r\n            where m.note_type = 'D' AND m.organization_id = ", organizationId, " AND (case when m.application_submit_date is null then CAST(m.date_note as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.date_note as DATE) <= to_date('", tDate, "','dd/MM/yyyy') else CAST(m.application_submit_date as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.application_submit_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy') end ) and d.status='O'" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getDetails33(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select m.other_note_no note_no, to_char(m.date_note, 'dd/MM/yyyy') as date_note,d.oa_subject,d.oa_case_no,d.vat_amount rent,d.actual_price VAT,d.no_of_days,case when d.reason_drcr!=8 then d.interest_pct end interest_pct,\r\n            d.interest_amount,case when d.particulars is not null and d.particulars!='' then d.particulars else d.oa_description end particulars,oa_case_no\r\n            from trns_note_master m\r\n            inner join trns_note_detail d on m.note_id = d.note_id\r\n            where m.note_type = 'C' AND m.organization_id = ", organizationId, " AND (case when m.application_submit_date is null then CAST(m.date_note as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.date_note as DATE) <= to_date('", tDate, "','dd/MM/yyyy') else CAST(m.application_submit_date as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.application_submit_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy') end )  and d.status='O'" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getEconomicSpecification(int orgId)
        {
            string str = string.Concat("select * from economic_activity_specification\r\n                        where organization_id=", orgId, " and is_other=true");
            return this.db.GetDataTable(str);
        }

        public DataTable getFixedVatInfo(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select coalesce(sum(d.Quantity*d.actual_price),0) as price, coalesce(sum(d.Vat),0) as Vat, coalesce(sum(d.sd),0) as sd, \r\n                            d.is_inexplicit_export as deemed_export, d.is_exempted, m.trans_type,d.real_property\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false  and d.approver_stage='F'  \r\n                            AND d.is_fixed_vat=true AND m.organization_id=", organizationId, "\r\n                            group by d.is_inexplicit_export,d.is_exempted,m.trans_type,d.real_property " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getItemType(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select product_type,item_type from item where item_id=", itemId);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetMonthClosingAdjustmentSd(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct credit_amount,debit_amount \t                    \r\n\t                    from month_closing_history where organization_id=", organizationId, " and note_no=57 \r\n                       and CAST(closing_date_1st as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(closing_date_2nd as DATE) < to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetMonthClosingAdjustmentVat(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct credit_amount,debit_amount \t                    \r\n\t                    from month_closing_history where organization_id=", organizationId, " and note_no=56 \r\n                        and CAST(closing_date_1st as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(closing_date_2nd as DATE) < to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetMonthClosingAdjustmentVatnote54(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct credit_amount,debit_amount \t                    \r\n\t                    from month_closing_history where organization_id=", organizationId, " and note_no=54 \r\n                        and CAST(closing_date_1st as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(closing_date_2nd as DATE) < to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetMonthClosingAdjustmentVatnote55(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct credit_amount,debit_amount \t                    \r\n\t                    from month_closing_history where organization_id=", organizationId, " and note_no=55 \r\n                        and CAST(closing_date_1st as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(closing_date_2nd as DATE) < to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetMonthClosingSd(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct credit_amount,debit_amount \t                    \r\n\t                    from month_closing_history where organization_id=", organizationId, " and note_no=66 and\r\n                        CAST(closing_date_1st as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(closing_date_2nd as DATE) < to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetMonthClosingVat(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct credit_amount,debit_amount \t                    \r\n\t                    from month_closing_history where organization_id=", organizationId, " and note_no=65 and\r\n                        CAST(closing_date_1st as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(closing_date_2nd as DATE) < to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getMRPInfo5(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select coalesce(sum(d.quantity*d.actual_price),0) as price, coalesce(sum(d.Vat),0) as Vat, coalesce(sum(d.sd),0) as sd, \r\n                            d.is_inexplicit_export as deemed_export, d.is_exempted, m.trans_type,d.real_property\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false \r\n                            AND d.is_fixed_vat = false  and d.approver_stage='F'  \r\n                            AND d.is_mrp = true AND m.organization_id=", organizationId, "\r\n                            group by d.is_inexplicit_export,d.is_exempted,m.trans_type,d.real_property " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getNIDAuthorizePerson(int orgId)
        {
            string str = string.Concat("select * from authorize_person_info\r\n                        where organization_id=", orgId, " ");
            return this.db.GetDataTable(str);
        }

        public DataTable getNote19Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n                           d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        inner join trns_party tp on tp.party_id=m.party_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')\r\n                        AND d.is_deleted = false AND m.purchase_type='L' And m.challan_type='P' \r\n                        AND d.is_rebatable = false and d.approver_stage='F'  \r\n                        AND m.organization_id=", organizationId, " and tp.reg_type=4\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getNote20Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n                           d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        inner join trns_party tp on tp.party_id=m.party_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')\r\n                        AND d.is_deleted = false AND m.purchase_type='L' And m.challan_type='P'\r\n                        AND d.is_rebatable = false and d.approver_stage='F'  \r\n                        AND m.organization_id=", organizationId, " and tp.reg_type=5\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getNote21Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n                           d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        inner join trns_party tp on tp.party_id=m.party_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')\r\n                        AND d.is_deleted = false AND m.purchase_type='L' \r\n                        AND d.is_rebatable = false AND m.challan_type='P' and d.is_exempted=false and tp.reg_type!=5 and d.approver_stage='F'  \r\n             and d.purchase_vat>0              AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getNote22Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n                           d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')\r\n                        AND d.is_deleted = false AND m.purchase_type='I' and d.is_exempted=false\r\n                        AND d.is_rebatable = false AND m.challan_type='P' and d.approver_stage='F'  \r\n                        AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetNote42(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(SUM(coalesce(d.interest_amount,0)),0) as amount from trns_note_detail d\r\n                            inner join trns_note_master m on d.note_id=m.note_id\r\n                            where d.reason_drcr = 6 and m.organization_id = ", organizationId, " and CAST(m.date_insert as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_insert as DATE) <= to_date('", tDate, "','dd/MM/yyyy') AND m.is_other_adj = true" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetNote43(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(SUM(coalesce(d.interest_amount,0)),0) as amount from trns_note_detail d\r\n                            inner join trns_note_master m on d.note_id=m.note_id\r\n                            where d.reason_drcr = 7 and m.organization_id = ", organizationId, " and CAST(m.date_insert as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_insert as DATE) <= to_date('", tDate, "','dd/MM/yyyy') AND m.is_other_adj = true" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetNote48(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                string[] strArrays = new string[] { "select coalesce(SUM(coalesce(d.health_surcharge,0)),0) as amount from trns_sale_detail d                            \r\n                            where CAST(d.date_insert as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(d.date_insert as DATE) <= to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(strArrays);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getNote8Data(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select \r\n                         coalesce(SUM(d.quantity),0) quantity\r\n                       , coalesce(SUM(d.actual_price*d.quantity),0) as price\r\n                        ,coalesce(SUM(d.sd),0) purchase_sd\r\n                        ,coalesce(SUM(d.vat),0) purchase_vat\r\n                        from trns_sale_detail  as d\r\n                        inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id \t\t\r\n\t\t                inner join item_category ic on i.sub_category_id=ic.category_id\r\n                        where CAST(m.date_challan as DATE) >=  to_date('", fDate, "','dd/MM/yyyy')\r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')  \r\n                        AND d.is_deleted = false AND m.organization_id = ", organizationId, "  \r\n                        AND m.sale_type in ('W','R','T','P') and d.approver_stage='F'  \r\n                        AND d.vat_rate!=15" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getNote8SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,d.item_id,d.vat_rate,d.sd_rate, ic.category_name,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,\r\n                        i.hs_code, (case when d.item_serials<>'' THEN CONCAT(i.item_name,'(',d.item_serials,')') ELSE i.item_name END) AS item_name,  --i.item_name,\r\n                        d.quantity, (d.actual_price*d.quantity) as price,d.sd sd,d.vat vat,\r\n                         --d.remarks \r\n                       Concat((fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))) ,'%',' VAT') remarks ,(select unit_name from item_unit where unit_id=d.unit_id) as unit_name\r\n\t\t\t            from trns_sale_detail  as d\r\n                        inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id \t\t\r\n\t\t            \tinner join item_category ic on i.sub_category_id=ic.category_id\r\n                        where CAST(m.date_challan as DATE) >=  to_date('", fDate, "','dd/MM/yyyy')\r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')  \r\n                        AND d.is_deleted = false AND m.organization_id = ", organizationId, " \r\n                        AND m.sale_type in ('W','R','T','P') AND d.vat_rate!=15" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getOrganizationCommissionarateCode(string orgName)
        {
            string str = string.Concat("select o.organization_name, comm_code\r\n                        from org_registration_info o\r\n                        inner join vat_commissionerate v on o.commissionarate_id=v.comm_id\r\n                        where o.organization_name='", orgName, "' ");
            return this.db.GetDataTable(str);
        }

        public DataTable getOrganizationName(string orgName)
        {
            string str = string.Concat("select * from org_registration_info o                    \r\n                        where o.organization_name='", orgName, "' ");
            return this.db.GetDataTable(str);
        }

        public DataTable getPart4DataForExemptedImport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'  \r\n                        AND d.is_deleted = false AND m.purchase_type='I' AND d.is_exempted=true AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPart4DataForExemptedLocal(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m\r\n                        on d.challan_id = m.challan_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'  \r\n                        AND d.is_deleted = false AND m.purchase_type='L' AND d.is_exempted=true AND d.is_mrp=false AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPart4DataForFixedLocal(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { " select cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                              case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m  on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id \r\n                        where((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) ) and d.is_current_month_rebate=true And m.challan_type='P' and d.is_rebatable=true and d.approver_stage='F'  \r\n                        AND d.is_deleted = false AND m.purchase_type='L' AND d.is_fixed_vat=true AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct,i.vat_rebate,d.purchase_vat" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPrarombikJer(int itemId, string fromDate)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(sum(d.quantity),0) as quantity, coalesce(sum(d.sale_unit_price*d.quantity),0) as price from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id=d.challan_id\r\n                        where d.item_id=", itemId, " AND CAST(m.date_challan as DATE)<=to_date('", fromDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getSaleExempted(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select coalesce(sum(d.Quantity*d.actual_price),0) as price, coalesce(sum(d.Vat),0) as Vat, coalesce(sum(d.sd),0) as sd, \r\n                            d.is_inexplicit_export as deemed_export, d.is_exempted, m.trans_type,d.real_property\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false AND m.organization_id=", organizationId, "\r\n                            AND d.is_exempted=true  and d.approver_stage='F'  AND d.is_fixed_vat=false--অব্যাহতিপ্রাপ্ত পণ্য/সেবা\r\n                            group by d.is_inexplicit_export,d.is_exempted,m.trans_type,d.real_property " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getSubFormCha_Note30(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY pd.ait_refund_date) AS sl_no\r\n                      , pm.challan_no,to_char(pm.date_challan,'dd-MON-yyyy') as date_challan,pm.port_code custom_house\r\n                     -- ,(select apd.code_name from app_code_detail apd inner join trns_purchase_master m on apd.code_id_d= m.prt_code and apd.code_id_m= 38 and m.challan_id= pm.challan_id) as custom_house\r\n                      ,pd.at price,CONCAT((select distinct (fngetbanglaamount(cast(tax_value as decimal(18,2)))) from item_tax_values where tax_id =8 and item_id=pd.item_id and is_tran_import=true and tax_value!=0 and is_current=true),'%',' ','AT') as remarks\r\n                      from trns_purchase_detail pd\r\n                      inner join trns_purchase_master pm on pd.challan_id=pm.challan_id\r\n                      where pm.challan_type= 'P' and pm.purchase_type= 'I' AND pm.organization_id=", organizationId, " AND pd.at > 0 AND CAST(pd.ait_refund_date as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                      AND CAST(pd.ait_refund_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy') order by pd.ait_refund_date desc" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getSubformData26(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                string str1 = "";
                object[] objArray = new object[] { "select note_no,note_date,party_name,party_address,party_bin,quantity,note_price,note_vat,note_sd,issue_Time,unit_price,unit_name,totalSD_VAT,\r\n                          challan_quantity, challan_price, challan_vat,challan_sd,return_reason,phone,fax,vehicle_no,code_name\r\n                            ,challan_challan_no,challan_challan_date\r\n                            ,other_deduct,total_w_VAT\r\n                        from (\r\n                        select tnm.note_no, to_char(tnm.date_note,'dd/MM/yyyy') note_date ,to_char(tnm.date_insert::Time, 'HH12:MI') issue_Time, tp.party_name, tp.party_address, tp.party_bin\r\n                        --,i.item_name\r\n\r\n                        ,tnm.vehicle_no ,acd.code_name\r\n\r\n                        ,tnd.quantity\r\n                        ,tnd.total_price note_price,tnd.unit_price,itmunit.unit_name unit_name,tnd.other_deduct other_deduct,\r\n                        tnd.return_vat note_vat, tnd.return_sd note_sd, tpd.purchase_vat challan_vat,tpd.purchase_sd challan_sd,total_vat totalSD_VAT,tnd.vs_total_price total_w_VAT, tnd.return_reason, ori.ba_phone as phone, ori.ba_fax as fax,\r\n                      tpd.quantity challan_quantity,tpm.challan_no as challan_challan_no, to_char(tpm.date_challan,'dd/MM/yyyy') as challan_challan_date,((tpd.purchase_unit_price*tpd.quantity)+tpd.purchase_sd+tpd.purchase_vat) challan_price\r\n                      \r\n                        from trns_note_master as tnm\r\n                        inner join trns_note_detail as tnd on tnm.note_id = tnd.note_id\r\n                        inner join trns_party as tp on tp.party_id = tnm.party_id\r\n                        inner join item as i on tnd.item_id = i.item_id\r\n                        inner join item_unit itmunit on itmunit.unit_id=tnd.unit_id\r\n                       inner join trns_purchase_detail as tpd on tnd.challan_id_purchase = tpd.challan_id and tnd.item_id = tpd.item_id ", str1, "\r\n                       inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        LEFT OUTER JOIN app_code_detail acd ON tnm.vehicle_type_m=acd.code_id_m AND tnm.vehicle_type_d=acd.code_id_d\r\n                        inner join org_registration_info as ori on ori.organization_id = tnm.organization_id\r\n                        where cast(tnm.date_note as Date)>=to_date('", fDate, "','dd/MM/yyyy') and cast(tnm.date_note as Date)<=to_date('", tDate, "','dd/MM/yyyy') and tnm.is_deleted = false and tnm.note_type = 'D'\r\n                        and tnm.organization_id=", organizationId, " ", str, " and tnd.is_rebatable=true)mqmm" };
                string str2 = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getSubformData31(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                string str1 = "";
                object[] objArray = new object[] { "select distinct note_no, note_date, party_name, party_address, party_bin, item_name, quantity, note_price, note_vat, note_sd, issue_Time, unit_price, unit_name, totalSD_VAT,\r\n                         challan_price, challan_quantity,challan_vat, challan_sd, return_reason, phone, fax\r\n                        --,sale_challan_no, sale_challan_date\r\n                        ,other_deduct, total_w_VAT\r\n                        ,challan_challan_no, challan_challan_date,vehicle_no Vehicle_No,code_name,orderDate\r\n                        from(\r\n                        select tnm.note_no, to_char(tnm.date_note, 'dd/MM/yyyy') note_date, to_char(tnm.date_insert::Time, 'HH12:MI') issue_Time, tp.party_name, tp.party_address, tp.party_bin\r\n                        --,i.item_name\r\n\r\n                        ,(i.item_name \r\n                        || ' ' || (CASE WHEN tnd.property_id1 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t            where a.property_id1=tnd.property_id1 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id2 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t            where a.property_id2=tnd.property_id2 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id3 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id3=tnd.property_id3 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id4 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id4=tnd.property_id4 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id5 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id5=tnd.property_id5 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            ) AS item_name\r\n\r\n                        ,tnd.quantity, tnd.total_price note_price,\r\n                        tnd.return_vat note_vat, tnd.unit_price, itmunit.unit_name unit_name, tnd.return_sd note_sd\r\n                       ,tsd.vat challan_vat, tsd.sd challan_sd,tsd.quantity challan_quantity,((tsd.quantity * tsd.actual_price)+tsd.sd+tsd.vat) challan_price                       \r\n                        ,tnd.return_reason, ori.ba_phone as phone, ori.ba_fax as fax,\r\n                        tsm.challan_no as challan_challan_no, to_char(tsm.date_challan, 'dd/MM/yyyy') as challan_challan_date, \r\n                        tnd.other_deduct, tnd.total_vat totalSD_VAT, tnd.vs_total_price total_w_VAT\r\n                        ,tsm.challan_no as sale_challan_no, to_char(tsm.date_challan, 'dd/MM/yyyy') as sale_challan_date,tnm.vehicle_no Vehicle_No,acd.code_name,tnm.date_note orderDate                     \r\n                        from trns_note_master as tnm\r\n                        inner join trns_note_detail as tnd on tnm.note_id = tnd.note_id\r\n                        inner join trns_party as tp on tp.party_id = tnm.party_id\r\n                        inner join item as i on tnd.item_id = i.item_id                       \r\n                        inner join item_unit itmunit on itmunit.unit_id = tnd.unit_id\r\n                        inner join trns_sale_detail as tsd on tnd.challan_id_sale = tsd.challan_id and tnd.item_id = tsd.item_id ", str1, "\r\n                        inner join trns_sale_master as tsm on tsd.challan_id = tsm.challan_id\r\n                        LEFT OUTER JOIN app_code_detail acd ON tnm.vehicle_type_m=acd.code_id_m AND tnm.vehicle_type_d=acd.code_id_d\r\n                        inner join org_registration_info as ori on ori.organization_id = tnm.organization_id\r\n\r\n\r\n                        where cast(tnm.date_note as Date)>=to_date('", fDate, "','dd/MM/yyyy') and cast(tnm.date_note as Date)<=to_date('", tDate, "','dd/MM/yyyy')  and tnm.is_deleted = false and tnm.note_type = 'C'\r\n                        and tnm.organization_id=", organizationId, " ", str, ")mqmm order by orderDate" };
                string str2 = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getSubFormKa_Note12(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no\r\n                        ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,\r\n                        i.hs_code,i.item_name,d.total_price,d.total_price as price,d.purchase_sd as sd,d.purchase_vat as vat,'exempted local' as remarks \r\n                        ,m.challan_id\r\n                        from trns_purchase_detail  as d\r\n                        inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'\r\n                        AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.is_exempted =true AND m.purchase_type = 'L'" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getSubFormKa_Note13(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no\r\n                        ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details, m.challan_no, to_char(m.bl_date,'dd/MM/yyyy') date_challan, m.port_code, m.no_of_item, m.cpc, d.assesment_amount,\r\n                        i.hs_code,i.item_name,d.total_price,d.total_price as price,d.purchase_sd as sd,d.purchase_vat as vat, d.at,'exempted Imported' as remarksgetVatReturnPart3DataRow2SubReport \r\n                        ,m.challan_id,'Exempted' as remarks\r\n                        from trns_purchase_detail  as d\r\n                        inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'\r\n                        AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.is_exempted =true AND m.purchase_type = 'I'" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable GetUtpadon5(int itemId, string fromDate, string to_date)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(sum(d.quantity),0) as quantity, coalesce(sum(d.sale_unit_price*d.quantity),0) as price from trns_purchase_master m\r\n                        inner join trns_purchase_detail d on m.challan_id=d.challan_id\r\n                        where d.item_id=", itemId, " AND CAST(m.date_challan as DATE)<=to_date('", fromDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public decimal getVatReturnNote29(string fDate, string tDate, int organizationId)
        {
            decimal num = new decimal(0);
            try
            {
                object[] objArray = new object[] { "select Sum(vds_amount) as total_rcv_vds from trns_sale_vds_detail where is_rcv_vds = true and organization_id=", organizationId, "\r\n             AND CAST(rcv_vds_date AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n             AND CAST(rcv_vds_date AS DATE) <=  to_date('", tDate, "','dd/MM/yyyy') " };
                string str = string.Concat(objArray);
                DataTable dataTable = this.db.GetDataTable(str);
                if (dataTable.Rows.Count > 0 && !string.IsNullOrEmpty(dataTable.Rows[0]["total_rcv_vds"].ToString()))
                {
                    num = Convert.ToDecimal(dataTable.Rows[0]["total_rcv_vds"]);
                }
            }
            catch (Exception exception)
            {
            }
            return num;
        }

        public DataTable getVatReturnNote29SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY tsm.challan_id) AS sl_no, tsvd.sale_challan_no as challan_no, tsvd.vds_certificate_no vds_cert_issued_no,to_char(tsvd.vds_certificate_date,'dd/MM/yyyy') AS vds_cert_issued_date,\r\n                        tsvd.vds_amount as vat, coalesce(tsvd.payment_amount-tsvd.vds_amount,0) AS price1, to_char(tsm.date_challan,'dd/MM/yyyy') as date_challan, '' AS remarks,\r\n                        tsvd.account_code, tp.party_bin, tp.party_name, tp.party_address,\r\n                        tsvd.tax_depo_serial_no as tax_deposit_serial_no,\r\n                        to_char(tsvd.tax_depo_date,'dd/MM/yyyy') as tax_deposit_date\r\n                        from trns_sale_vds_detail tsvd\r\n                        inner join trns_sale_master as tsm on tsvd.sale_challan_id = tsm.challan_id\r\n                        inner join trns_party as tp on tsm.party_id=tp.party_id\r\n                        where CAST(tsvd.rcv_vds_date as DATE) >= to_date('", fDate, "', 'dd/MM/yyyy') \r\n                        AND CAST(tsvd.rcv_vds_date as DATE) <= to_date('", tDate, "', 'dd/MM/yyyy') \r\n                        AND tsvd.is_deleted = false AND tsvd.organization_id=", organizationId, " AND tsvd.is_rcv_vds=true \r\n                        AND tsvd.vds_certificate_no IS NOT NULL and tsvd.vds_amount!=0\r\n\t\t\t\t\t\torder by tsvd.rcv_vds_date;" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3Data(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select coalesce(sum(d.Quantity*d.actual_price),0) as price, coalesce(sum(d.Vat),0) as Vat, coalesce(sum(d.sd),0) as sd, \r\n                            d.is_inexplicit_export as deemed_export, d.is_exempted, m.trans_type,d.real_property\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false  \r\n                            AND d.is_zero_rate=true  AND m.trans_type= 'E' and d.approver_stage='F'  \r\n                            AND m.organization_id=", organizationId, "\r\n                            group by d.is_inexplicit_export,d.is_exempted,m.trans_type,d.real_property " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3DataAdorsho(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select coalesce(sum(d.Quantity*d.actual_price),0) as price, coalesce(sum(d.Vat),0) as Vat, coalesce(sum(d.sd),0) as sd, \r\n                            d.is_inexplicit_export as deemed_export, d.is_exempted, m.trans_type,d.real_property\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.vat_rate= 15 and d.approver_stage='F'   and d.is_exempted=false AND d.is_mrp=false and d.is_zero_rate=false\r\n                            group by d.is_inexplicit_export,d.is_exempted,m.trans_type,d.real_property " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3DataAdorshoHarBatito(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select coalesce(sum(d.Quantity*d.actual_price),0) as price, coalesce(sum(d.Vat),0) as Vat, coalesce(sum(d.sd),0) as sd, \r\n                            d.is_inexplicit_export as deemed_export, d.is_exempted, m.trans_type,d.real_property\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false  AND d.vat_rate !=15 and d.approver_stage='F'  \r\n                            AND m.sale_type='S' AND d.is_truncated=true --condition suggested for note7 done by sabbir 25/2/20 [by ruhul vai 25/2/20]\r\n                            AND d.is_exempted = false AND d.is_fixed_vat=false AND m.organization_id=", organizationId, "\r\n                            group by d.is_inexplicit_export,d.is_exempted,m.trans_type,d.real_property " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3DataRow1SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,d.item_id,d.vat_rate,d.sd_rate, Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) details,i.hs_code,i.item_name,\r\n                          m.export_bill_no,to_char(m.date_export,'dd/MM/yyyy') as date_challan , acd.code_short_name port_code, m.no_of_item, m.cpc,'0' as at,\r\n                            d.Quantity*d.actual_price as price,d.Quantity*d.actual_price assesment_amount ,d.sd,d.vat,'0 Rate direct export' as remarks from trns_sale_detail as d\r\n                            inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n\t\t\t                inner join item as i on i.item_id =d.item_id\r\n                            left join app_code_detail acd on acd.code_id_d = port_code_id and acd.code_id_m =38\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')  and d.approver_stage='F'\r\n                            AND d.is_zero_rate=true AND m.organization_id = ", organizationId, " AND m.trans_type= 'E' AND d.is_deleted = false AND d.is_inexplicit_export=false" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3DataRow2SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no, d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,i.item_name, \r\n                            m.challan_no, to_char(m.date_challan,'dd/MM/yyyy') date_challan,  acd.code_short_name port_code_id, m.no_of_item, m.cpc,\r\n                            d.Quantity*d.actual_price as price,d.Quantity*d.actual_price assesment_amount ,d.sd,d.vat,'Zero Rate deemed export' as remarks\r\n                             from trns_sale_detail as d\r\n                            inner join trns_sale_master as m\r\n                            on d.challan_id = m.challan_id\r\n\t\t\t                inner join item as i on i.item_id =d.item_id\r\n                            left join app_code_detail acd on acd.code_id_d = port_code_id and acd.code_id_m =38\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')  and d.approver_stage='F'\r\n                            AND m.trans_type= 'E'  AND d.is_zero_rate=true AND d.is_inexplicit_export=true AND m.organization_id=", organizationId, "  AND d.is_deleted = false " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3DataRow3SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select  ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,\r\n                            i.item_name,d.Quantity*d.actual_price as price,d.sd,d.vat,'Exempted item/Service' as remarks from trns_sale_detail as d\r\n                            inner join trns_sale_master as m\r\n                            on d.challan_id = m.challan_id\r\n                            inner join item as i on i.item_id =d.item_id\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')  and d.approver_stage='F'\r\n                            AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.is_fixed_vat=false and d.is_exempted=true " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3DataRow5SubReport(string fDate, string tDate, int organizationId)
        {
            return this.db.GetDataTable(" ");
        }

        public DataTable getVatReturnPart3DataRow6SubReport(DateTime fDate, DateTime tDate, int organizationId)
        {
            return this.db.GetDataTable(" ");
        }

        public DataTable getVatReturnPart3DataRow7SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) As details\r\n                           ,i.hs_code, (case when d.item_serials<>'' THEN CONCAT(i.item_name,'(',d.item_serials,')') ELSE i.item_name END) AS item_name,  d.Quantity*d.actual_price  as price, d.sd sd, d.vat vat,Concat((fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))) ,'%',' VAT') remarks\r\n                            from trns_sale_detail as d\r\n                            inner join trns_sale_master as m\r\n                            on d.challan_id = m.challan_id\r\n                            inner join item as i on i.item_id =d.item_id\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false AND m.organization_id=", organizationId, "  AND d.vat_rate !=15  and d.approver_stage='F'\r\n                            AND m.sale_type = 'S' AND d.is_truncated = true--condition suggested for note7 done by sabbir 25 / 2 / 20[by ruhul vai 25 / 2 / 20] \r\n                            AND d.is_exempted=false and d.is_fixed_vat=false" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3DataRow8SubReport(DateTime fDate, DateTime tDate)
        {
            return this.db.GetDataTable("  ");
        }

        public DataTable getVatReturnPart3DataSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select  ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,\r\n                            i.item_name,d.quantity*d.actual_price as price,d.sd,d.vat,Concat('১৫% VAT',' ',d.remarks) as remarks from trns_sale_detail as d\r\n                            inner join trns_sale_master as m  on d.challan_id = m.challan_id\r\n                            inner join item as i on i.item_id =d.item_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy')  and d.approver_stage='F'\r\n                            AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.vat_rate= 15 and d.is_exempted=false AND d.is_mrp=false and d.is_zero_rate=false" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart3SubReport5(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select  ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,\r\n                            i.item_name,d.quantity*d.actual_price as price,d.sd,d.vat,'' as remarks from trns_sale_detail as d\r\n                            inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                            inner join item as i on i.item_id =d.item_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy')  and d.approver_stage='F'\r\n                            AND d.is_deleted = false AND m.organization_id=", organizationId, " and d.is_exempted=false AND d.is_mrp=true AND d.is_mrp=true" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart4Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                             case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id \r\n                       where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) ) and d.is_current_month_rebate=true\r\n                        AND d.is_deleted = false AND m.purchase_type='L'    and d.approver_stage='F'                      \r\n                       AND m.organization_id=", organizationId, " AND d.vat_rate != 15 AND m.challan_type='P' \r\n                     AND d.is_fixed_vat=false AND d.is_rebatable=true AND d.is_exempted=false     group by  d.is_exempted, m.purchase_type,d.real_property,zero_rate,i.vat_rebate,d.purchase_vat" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart4DataAdorshoImport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select --cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                           m.challan_no, cast(coalesce((d.purchase_unit_price*d.quantity),0)-coalesce(d.purchase_sd,0) as decimal(18,2)) price,                \r\n                         --cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end),0) as decimal(18,2)) Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                            ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m  on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id\r\n                        where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) ) and d.is_current_month_rebate=true\r\n                        AND d.is_deleted = false And m.challan_type='P'\r\n                        AND d.vat_rate=15--Adorsho\r\n                        AND m.purchase_type='I'--Import \r\n                       AND d.is_rebatable=true AND d.is_fixed_vat=false  and d.approver_stage='F'  \r\n                       AND d.is_truncated=false and d.is_exempted =false\r\n                       AND d.is_mrp=false AND m.organization_id=", organizationId, "\r\n                       group by m.challan_no,d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct,d.purchase_sd,d.purchase_unit_price,d.quantity" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart4DataAdorshoLocal(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select --cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end),0) as decimal(18,2)) Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate,sum(d.purchase_sd) AS purchase_sd\r\n                              ,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m  on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id\r\n                        where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) ) and d.is_current_month_rebate=true\r\n                        AND d.is_deleted = false And m.challan_type='P' and d.approver_stage='F'  \r\n                        AND d.vat_rate=15 AND d.is_mrp=false AND m.organization_id=", organizationId, "\r\n                        AND m.purchase_type='L' AND d.is_fixed_vat=false and d.is_rebatable =true  --local\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart4DataImport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price),0) as decimal(18,2)) price, \r\n                              case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m  on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id \r\n                        where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) ) and d.is_current_month_rebate=true\r\n                        AND d.is_deleted = false AND m.purchase_type='I' AND d.vat_rate!=15 AND d.is_exempted=false AND d.is_rebatable=true and d.approver_stage='F'  \r\n                        AND d.is_fixed_vat=false AND d.is_truncated=true AND m.challan_type='P' AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct,i.vat_rebate,d.purchase_vat" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart4DataNotregisteredSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,\r\n                            \r\n                              i.item_name  ,cast(coalesce(d.Quantity*d.purchase_unit_price,0) as decimal(18,2)) price, \r\n                              cast(coalesce(d.purchase_vat,0) as decimal(18,2)) vat,cast(coalesce(d.purchase_sd,0) as decimal(18,2)) sd,\r\n                             'অনিবন্ধিত প্রতিষ্ঠান হইতে(স্থানীয় ক্রয়)' remarks                                 \r\n                              from trns_purchase_detail d\r\n                              inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                              inner join item as i on i.item_id =d.item_id\r\n                              inner join trns_party tp on tp.party_id=m.party_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false AND m.purchase_type='L' And m.challan_type='P' and d.approver_stage='F'\r\n                            AND d.is_rebatable = false AND m.organization_id=", organizationId, " and tp.reg_type=5" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataRow10SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,d.item_id,d.vat_rate,d.sd_rate, Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,i.item_name,\r\n                            d.Quantity*d.purchase_unit_price as price,d.purchase_sd as sd,d.purchase_vat as vat,'Zero rate Local purchase' as remarks from trns_purchase_detail as d\r\n                            inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n\t\t\t                inner join item as i on i.item_id =d.item_id\r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'\r\n                            AND d.zero_rate=true AND m.organization_id=", organizationId, " AND m.purchase_type= 'L' AND d.is_exempted=false AND d.is_deleted = false AND d.is_fixed_vat=false AND d.is_truncated=false" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataRow11SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,d.item_id,d.vat_rate,d.sd_rate, Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,i.item_name, \r\n                   m.challan_no, to_char(m.bl_date,'dd/MM/yyyy') date_challan,m.port_code, m.no_of_item, m.cpc, d.assesment_amount,\r\n\r\n                            d.Quantity*d.purchase_unit_price as price,d.purchase_sd as sd,d.purchase_vat as vat, d.at,'Zero rate imported' as remarks from trns_purchase_detail as d\r\n                            inner join trns_purchase_master as m  on d.challan_id = m.challan_id\r\n\t\t\t                inner join item as i on i.item_id =d.item_id                            \r\n                            where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'\r\n                            AND d.zero_rate=true AND m.purchase_type= 'I' AND m.organization_id=", organizationId, " AND d.vat_rate!=15 AND d.is_exempted=false AND d.is_rebatable=true AND d.is_deleted = false AND d.is_fixed_vat=false AND d.is_truncated=false" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataRow14DataSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,\r\n                        i.hs_code,i.item_name,d.total_price price,d.purchase_sd sd,case when i.vat_rebate!=0 then (d.purchase_vat*i.vat_rebate/100) else d.purchase_vat end vat,case when i.vat_rebate!=0 then concat(i.vat_rebate,'% rebatable ') else '১৫% VAT স্থানীয় ক্রয় ' end remarks\r\n                         from trns_purchase_detail  as d\r\n                        inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) ) and d.is_current_month_rebate=true\r\n                        AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.vat_rate= 15 \r\n                        AND d.is_mrp = false AND m.purchase_type = 'L' and m.challan_type='P' AND d.is_rebatable=true AND d.is_fixed_vat=false  and d.approver_stage='F'\r\n  " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataRow15DataSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no,d.item_id,d.vat_rate,d.sd_rate,  m.challan_no,  to_char(m.bl_date,'dd/MM/yyyy') date_challan, m.port_code, m.no_of_item, m.cpc, d.assesment_amount, case when i.item_specification!='' then Concat(i.item_name,',',i.item_specification,',',i.brand_name) else Concat(i.item_name,i.item_specification,',',i.brand_name) end as details,\r\n                        i.hs_code,i.item_name,\r\n                        --(d.actual_price*d.quantity) as total_price,\r\n                        cast(coalesce((d.purchase_unit_price*d.quantity),0) as decimal(18,2)) as price,d.purchase_sd sd,case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end vat,d.at,case when i.vat_rebate!=0 then concat(i.vat_rebate,'% rebatable ') else '১৫% VAT-আমদানি ' end remarks from trns_purchase_detail  as d\r\n                        inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id \r\n                        where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) )\r\n                        AND d.is_deleted = false  and d.approver_stage='F'\r\n                        AND d.vat_rate= 15 AND d.is_mrp = false AND m.purchase_type = 'I' and m.challan_type='P' AND d.is_rebatable=true AND d.is_fixed_vat=false and d.is_exempted = false  and d.is_current_month_rebate=true\r\n                        AND d.is_truncated=false AND m.organization_id=", organizationId };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataRow16DataSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,\r\n                        i.hs_code,i.item_name,d.total_price price,d.purchase_sd sd,case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end vat,\r\n--'reduce item/service local purchase' as remarks \r\ncase when i.vat_rebate!=0 then concat(i.vat_rebate,'% rebatable ') else  Concat((fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))) ,'%',' VAT') end remarks \r\nfrom trns_purchase_detail  as d\r\n                        inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) )\r\n                        AND d.is_deleted = false AND m.purchase_type='L' and d.approver_stage='F'  and d.is_current_month_rebate=true                      \r\n                       AND m.organization_id=", organizationId, " AND d.vat_rate != 15 AND m.challan_type='P' AND d.is_fixed_vat=false AND d.is_rebatable=true AND d.is_exempted=false" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataRow17DataSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,  m.challan_no,to_char(m.bl_date,'dd/MM/yyyy') date_challan, m.port_code, m.no_of_item, m.cpc, d.assesment_amount,\r\n                        i.hs_code,i.item_name,(d.purchase_unit_price*d.quantity) as price,d.purchase_sd sd,case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end vat,d.at,case when i.vat_rebate!=0 then concat(i.vat_rebate,'% rebatable ') else 'reduce item/service imported' end remarks from trns_purchase_detail  as d\r\n                        inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) )\r\n                        AND d.is_deleted = false AND m.organization_id=", organizationId, " \r\n                        AND d.vat_rate != 15 AND m.purchase_type = 'I' AND m.challan_type='P' and d.approver_stage='F'  and d.is_current_month_rebate=true\r\n                        AND d.is_exempted=false AND d.is_fixed_vat=false AND d.is_rebatable=true " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,\r\n                            \r\n                              i.item_name  ,cast(coalesce(d.Quantity*d.purchase_unit_price,0) as decimal(18,2)) price, \r\n                              cast(coalesce(d.purchase_vat,0) as decimal(18,2)) vat,cast(coalesce(d.purchase_sd,0) as decimal(18,2)) sd, case \r\n                               when d.is_exempted=true then Concat('অব্যাহতিপ্রাপ্ত পণ্য/সেবা')\r\n                               when d.is_fixed_vat=true then Concat('সুনির্দিষ্ট কর এর পণ্য/সেবা')\r\n                              else Concat((fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))) ,'%',' VAT') \r\n                               end                               \r\n                               remarks\r\n                              from trns_purchase_detail d\r\n                              inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                              inner join item as i on i.item_id =d.item_id\r\n                              inner join trns_party tp on tp.party_id=m.party_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy') \r\n                           and d.is_exempted=false AND d.is_deleted = false AND m.purchase_type='L' AND m.challan_type='P'\r\n                            AND d.is_rebatable = false AND m.organization_id=", organizationId, " and tp.reg_type!=5 and vat>0" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataSubReport(DateTime fDate, DateTime tDate)
        {
            object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m\r\n                        on d.challan_id = m.challan_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','MM/dd/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','MM/dd/yyyy')\r\n                        AND d.is_deleted = false \r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart4DataturnoverSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,\r\n                            \r\n                              i.item_name  ,cast(coalesce(d.Quantity*d.purchase_unit_price,0) as decimal(18,2)) price, \r\n                              cast(coalesce(d.purchase_vat,0) as decimal(18,2)) vat,cast(coalesce(d.purchase_sd,0) as decimal(18,2)) sd,\r\n                             'টাৰ্ণওভার প্রতিষ্ঠান হইতে(স্থানীয় ক্রয়)' remarks                                 \r\n                              from trns_purchase_detail d\r\n                              inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                              inner join item as i on i.item_id =d.item_id\r\n                              inner join trns_party tp on tp.party_id=m.party_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy') \r\n                            AND d.is_deleted = false AND m.purchase_type='L' And m.challan_type='P' and d.approver_stage='F'\r\n                            AND d.is_rebatable = false AND m.organization_id=", organizationId, " and tp.reg_type=4" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart5Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(vds_amount),0) as decimal(18,2)) as vds,\r\n                        (select cast(coalesce(sum(tpd.purchase_vat),0) as decimal(18,2)) rebatable_amount\r\n                            from trns_purchase_detail as tpd\r\n                            inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                            left join credit_transac_history cth on cth.challan_id=tpm.challan_id\r\n                            where tpd.is_rebatable = true \r\n                            and tpm.payment_method = '1' \r\n                            and (tpd.Quantity* tpd.purchase_unit_price+tpd.purchase_vat+tpd.purchase_sd) >100000 AND tpm.organization_id=", organizationId, "\r\n                            and CAST(tpm.date_challan AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')  \r\n                            and CAST(tpm.date_challan AS DATE)<= to_date('", tDate, "','dd/MM/yyyy')  and (tpm.is_vat_paid=true or cth.tr_challan_status is not null)\r\n                        ),\r\n                        (select  cast(coalesce(sum(return_vat+return_sd),0) as decimal(18,2)) return_amount\r\n                            from trns_note_detail inner join trns_note_master on trns_note_detail.note_id=trns_note_master.note_id\r\n                            where trns_note_detail.Status = 'P' AND trns_note_master.organization_id=", organizationId, "\r\n                            and CAST(trns_note_master.date_note AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')  \r\n                            and CAST(trns_note_master.date_note AS DATE)<= to_date('", tDate, "','dd/MM/yyyy') \r\n                        ),\r\n                        (select cast(coalesce(sum(total_price),0) as decimal(18,2)) \r\n                            from trns_note_detail as tnd\r\n                            inner join trns_note_master as tnm  on tnd.note_id = tnm.note_id\r\n                            where CAST(tnm.date_note AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')  \r\n                            and CAST(tnm.date_note AS DATE) <= to_date('", tDate, "','dd/MM/yyyy')  \r\n                            and tnm.note_type = 'D' and tnd.Status = 'O' AND tnm.organization_id=", organizationId, "\r\n                         ) as other_tax,\r\n                        --added below part on 17-Nov-2019\r\n                        (select cast(coalesce(sum(cth.proportion_vds),0) as decimal(18,2))\r\n                        --cast(coalesce(sum(d.vds_amount),0) as decimal(18,2))\r\n                        from trns_purchase_master m \r\n                        inner join trns_purchase_detail d on m.challan_id=d.challan_id \r\n                         left join credit_transac_history cth on cth.challan_id=m.challan_id \r\n                        where  m.organization_id = ", organizationId, "\r\n                        AND CAST(m.date_challan AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n                        AND CAST(m.date_challan AS DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                         AND (d.is_source_tax_deduct = true and (m.is_payment_finished=true and m.is_vat_paid=true) or cth.tr_challan_status is not null)) AS vds_amount,\r\n                     (select \r\n                        --cast(coalesce(sum(cth.proportion_vds),0) as decimal(18,2))\r\n                        cast(coalesce(sum(d.vds_amount),0) as decimal(18,2))\r\n                         from trns_purchase_master m \r\n                        inner join trns_purchase_detail d on m.challan_id=d.challan_id                         \r\n                        where  m.organization_id = ", organizationId, "\r\n                        AND CAST(m.date_challan AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n                        AND CAST(m.date_challan AS DATE) <=  to_date('", tDate, "','dd/MM/yyyy')\r\n                        AND d.is_source_tax_deduct = true and m.is_payment_finished=true and m.is_vat_paid=true and m.credit_amount=0) AS vds_amount1,\r\n                        (select coalesce(SUM(ttd.amount),0) from trns_treasury_detail ttd\r\n                        inner join trns_treasury_challan ttc on  ttc.challan_id=ttd.tr_challan_id\r\n                        where ttc.organization_id = ", organizationId, "\r\n                        AND CAST(ttd.vds_certificate_date AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n                        AND CAST(ttd.vds_certificate_date AS DATE) <=  to_date('", tDate, "','dd/MM/yyyy')\r\n                        and ttd.vds_certificate_no is not null) TotalVDS\r\n\r\n                         from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on m.challan_id=d.challan_id  \r\n                        where CAST(m.date_challan AS DATE) >= to_date('", fDate, "','dd/MM/yyyy')  \r\n                        and CAST(m.date_challan AS DATE)<= to_date('", tDate, "','dd/MM/yyyy')  \r\n                        AND d.is_deleted = false" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart5Data26(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(sum(coalesce(d.return_vat,0)),0) as vat from trns_note_master m \r\n\t\t\t        inner join trns_note_detail d on m.note_id=d.note_id\r\n                    where m.note_type='D' AND m.organization_id = ", organizationId, " AND CAST(m.date_note as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_note as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and d.is_rebatable=true" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart5Data27(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(SUM(actual_price),0) as price from trns_note_master m \r\n            inner join trns_note_detail d on m.note_id=d.note_id\r\n            where m.note_type='D' AND  m.organization_id=", organizationId, " AND (case when m.application_submit_date is null then CAST(m.date_note as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.date_note as DATE) <= to_date('", tDate, "','dd/MM/yyyy') else CAST(m.application_submit_date as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.application_submit_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy') end )  and d.status='O'" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart5Data33(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(SUM(actual_price),0) as price from trns_note_master m \r\n            inner join trns_note_detail d on m.note_id=d.note_id\r\n            where m.note_type='C' AND d.type_p='C' AND m.organization_id=", organizationId, " AND (case when m.application_submit_date is null then CAST(m.date_note as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.date_note as DATE) <= to_date('", tDate, "','dd/MM/yyyy') else CAST(m.application_submit_date as DATE) >= to_date('", fDate, "','dd/MM/yyyy')\r\n            AND CAST(m.application_submit_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy') end )  and d.status='O'" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart5DataRow24SubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "Select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no, p.party_bin,p.party_name,p.party_address\r\n                        ,d.vds_certificate_no\r\n                        ,'' AS vds_cert_issued_date\r\n                        ,(select tr_challan_no from trns_treasury_challan where challan_numbers=m.challan_no limit 1) as tax_deposit_serial_no\r\n                        ,(select TO_CHAR(date_challan :: DATE, 'dd-Mon-yy') from trns_treasury_challan where challan_numbers=m.challan_no limit 1) as tax_deposit_date\r\n                        ,(d.Quantity*d.actual_price) as price,d.Vat,m.challan_no,m.date_challan,d.remarks\r\n                        --,(select code_no from trns_treasury_challan where challan_numbers=m.challan_no) as account_code \r\n                       ,d.account_code account_code,m.challan_no\r\n                        from trns_sale_detail as d\r\n                        inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n\t\t\t            inner join trns_party as p on m.party_id=p.party_id\r\n                        where CAST(d.vds_certificate_date as DATE) >= to_date('", fDate, "', 'dd/MM/yyyy') \r\n                        AND CAST(d.vds_certificate_date as DATE) <= to_date('", tDate, "', 'dd/MM/yyyy') \r\n                        AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.is_source_tax_deduct=true \r\n                        AND d.vds_certificate_no IS NOT NULL AND m.is_payment_finished=true" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatReturnPart6Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(tsd.vds_amount),0) as decimal(18,2)) as vds_amount,\r\n                        (select cast(coalesce(sum(tnd.return_vat),0) as decimal(18,2)) as return_vat \r\n                            from trns_note_detail as tnd \r\n                            inner join trns_note_master as tnm on tnd.note_id = tnm.note_id  \r\n                            where tnm.note_type = 'C' AND tnm.organization_id=", organizationId, "\r\n                            and  CAST(tnd.date_insert AS DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            and CAST(tnd.date_insert AS DATE) <= to_date('", tDate, "','dd/MM/yyyy') ),\r\n                        (select cast(coalesce(sum(tnd.return_sd),0) as decimal(18,2)) as return_sd \r\n                            from trns_note_detail as tnd \r\n                            inner join trns_note_master as tnm on tnd.note_id = tnm.note_id  \r\n                            where tnm.note_type = 'C' AND tnm.organization_id=", organizationId, " \r\n                            and  CAST(tnd.date_insert AS DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            and CAST(tnd.date_insert AS DATE) <= to_date('", tDate, "','dd/MM/yyyy')\r\n                        ),\r\n                        (select cast(coalesce(sum(total_price),0) as decimal(18,2)) from trns_note_detail as tnd\r\n                            inner join trns_note_master as tnm\r\n                            on tnd.note_id = tnm.note_id\r\n                            where CAST(tnd.date_insert AS DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            and CAST(tnd.date_insert AS DATE) <= to_date('", tDate, "','dd/MM/yyyy')\r\n                            and tnm.note_type = 'C' AND tnm.organization_id=", organizationId, " \r\n                            and tnd.Status = 'O'\r\n                        ) as other_tax,\r\n                        --on 30-July-2019 mohi uddin\r\n                        (select  cast(coalesce(sum(return_vat+return_sd),0) as decimal(18,2)) return_amount\r\n                            from trns_note_detail tnd inner join trns_note_master as tnm on tnd.note_id = tnm.note_id\r\n                            where tnd.Status = 'S' AND tnm.organization_id=", organizationId, "\r\n                            and CAST(tnd.date_insert AS DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            and CAST(tnd.date_insert AS DATE)<= to_date('", tDate, "','dd/MM/yyyy')\r\n                        ),\r\n                --31-July-2019 mohi uddin\r\n                (\r\n\t\t\t    select cast(coalesce(sum(tnd.vat),0) as decimal(18,2)) \r\n                            from trns_sale_detail as tnd \r\n                            inner join trns_sale_master as tnm on tnd.challan_id = tnm.challan_id  \r\n                            where tnd.is_source_tax_deduct = true AND tnm.is_payment_finished=true AND tnm.organization_id=", organizationId, " \r\n                            and  CAST(tnd.vds_certificate_date AS DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            and CAST(tnd.vds_certificate_date AS DATE) <= to_date('", tDate, "','dd/MM/yyyy') and tnd.vds_certificate_no is not null\r\n\r\n                        ) AS VDS_AMT\r\n                        from trns_sale_detail as tsd\r\n                        where tsd.is_source_tax_deduct = true \r\n                        and CAST(tsd.vds_certificate_date AS DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        and CAST(tsd.vds_certificate_date AS DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                        AND tsd.is_deleted = false and tsd.vds_certificate_no is not null" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart6Data32(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(sum(coalesce(d.return_vat,0)),0) as vat from trns_note_master m \r\n\t\t\t        inner join trns_note_detail d on m.note_id=d.note_id\r\n                    where m.note_type='C' AND m.organization_id=", organizationId, " AND cast(m.date_note as Date)>=to_date('", fDate, "','dd/MM/yyyy') and cast(m.date_note as Date)<=to_date('", tDate, "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart6DataRow29SubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no, p.party_bin,p.party_name,p.party_address\r\n                       ,ttd.vds_certificate_no vds_cert_issued_no,ttc.tr_challan_no tax_deposit_serial_no,TO_CHAR(ttc.date_challan :: DATE, 'dd/MM/yyyy') tax_deposit_date,code_no account_code\r\n                       ,TO_CHAR(ttd.vds_certificate_date :: DATE, 'dd/MM/yyyy') AS vds_cert_issued_date\r\n                       ,coalesce(case when  m.credit_amount=0 then CAST(coalesce(d.quantity,0)*coalesce(d.purchase_unit_price,0) + coalesce(d.purchase_sd,0) as decimal(18,2)) \r\n                        when m.credit_amount!=0 and (m.bank_amount !=0 or m.cash_amount!=0) then  (m.bank_amount+m.cash_amount)\r\n                        when m.credit_amount!=0 and (m.bank_amount =0 and m.cash_amount=0) then CAST((cth.payment_amount-cth.proportion_vds) as decimal(18,2)) end,0) price1\r\n                       , CONCAT (TO_CHAR(CAST(coalesce(d.quantity,0)*coalesce(d.purchase_unit_price,0)as decimal(18,2)), '9,99,99,999.99'),'(',case when  m.credit_amount=0 then TO_CHAR(CAST(coalesce(d.quantity,0)*coalesce(d.purchase_unit_price,0)as decimal(18,2)), '9,99,99,999.99') else TO_CHAR(CAST(cth.payment_amount as decimal(18,2)), '9,99,99,999.99') end,')'  )price\r\n                        ,coalesce(d.quantity,0)*coalesce(d.purchase_unit_price,0) actual_price                      \r\n                        ,case when  cth.proportion_vds is null then d.purchase_vat else cth.proportion_vds end Vat,m.challan_no,to_char(m.date_challan,'dd/MM/yyyy') date_challan\r\n                        \r\n                        ,CONCAT(CAST(d.vat_rate as decimal(18,1)),'%',' ','VDS',' ',case when  cth.tr_challan_status is not null then 'Partially TR Challan Paid' end) remarks\r\n                        from trns_purchase_master as m\r\n                        inner join trns_purchase_detail as d on m.challan_id = d.challan_id \r\n                        inner join item as i on i.item_id = d.item_id\r\n                        inner join trns_party p  on p.party_id = m.party_id\r\n                        inner join trns_treasury_detail ttd on  m.challan_id=ttd.purchase_challan_id\r\n                        inner join trns_treasury_challan ttc on  ttd.tr_challan_id = ttc.challan_id\r\n                        left join credit_transac_history cth on cth.scroll_id=ttd.scroll_id\r\n                        where CAST(ttd.vds_certificate_date  as DATE) >= to_date('", fDate, "', 'dd/MM/yyyy')\r\n                        AND CAST(ttd.vds_certificate_date  as DATE) <= to_date('", tDate, "', 'dd/MM/yyyy') \r\n                        AND d.is_deleted = false AND m.organization_id=", organizationId, "\r\n                        AND d.is_deleted = false AND ttd.vds_certificate_no is not null\r\n                       order by ttd.vds_certificate_date\r\n                        --AND d.is_source_tax_deduct=true AND ( m.is_payment_finished=true and m.is_vat_paid=true) or tr_challan_status is not null " };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart7Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(tpd.at),0) as decimal(18,2)) as at\r\n                        from trns_purchase_master as tpm\r\n                        inner join trns_purchase_detail as tpd  on tpd.challan_id = tpm.challan_id\r\n                        where tpm.bl_no <> '' AND tpm.organization_id=", organizationId, "\r\n                        and CAST(tpm.date_challan as DATE ) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        and CAST(tpm.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy') \r\n                        AND tpd.is_deleted = false \r\n                        and ait_refund_status = true" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart7Data39(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(sum(coalesce(d.return_sd,0)),0) as sd from trns_note_master m \r\n\t\t\t        inner join trns_note_detail d on m.note_id=d.note_id\r\n                    where m.note_type='D' AND m.organization_id=", organizationId, " and CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') AND m.is_other_adj = false" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart7Data40(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select coalesce(sum(coalesce(d.return_sd,0)),0) as sd from trns_note_master m \r\n\t\t\t        inner join trns_note_detail d on m.note_id=d.note_id\r\n                    where m.note_type='C' AND m.organization_id=", organizationId, " AND CAST(d.date_insert as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(d.date_insert as DATE) <= to_date('", tDate, "','dd/MM/yyyy') AND m.is_other_adj = false" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart852Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan                \r\n            where chalan_type_d = 1 AND trns_treasury_challan.organization_id = ", organizationId, " and  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end ) group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart852DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan \r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=1 AND trns_treasury_challan.organization_id=", organizationId, " \r\n                         and (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n                        group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name ,trns_treasury_challan.code_no,sb.bank_name,sb.bank_code,sbb.branch_code" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart853Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 4 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )  group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart853DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=4 AND organization_id=", organizationId, " and  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n             group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart854Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 5 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )  group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart854DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=5 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n                  group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart855Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 6 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )  group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart855DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan \r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=6 AND trns_treasury_challan.organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                         CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n                          group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code ,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart856Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where (chalan_type_d = 2 or chalan_type_d=3) AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )  group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart856DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where (chalan_type_d=2 or chalan_type_d=3) AND trns_treasury_challan.organization_id=", organizationId, " and  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                          CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end ) \r\n                          group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code ,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart857Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 7 AND organization_id=", organizationId, " and  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end ) group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart857DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=7 AND trns_treasury_challan.organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                          CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n                          group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart858Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 8 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end ) group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart858DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=8 AND trns_treasury_challan.organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n                   group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,set_bank_branch.branch_name ,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart859Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 9 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )  group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart859DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=9 AND trns_treasury_challan.organization_id=", organizationId, " and  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                          CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n                          group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code ,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart860Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 10 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end ) group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart860DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=10 AND trns_treasury_challan.organization_id=", organizationId, " and  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                          CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end )\r\n                          group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code ,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart861Data(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select code_no,SUM(amount) amount from trns_treasury_challan where chalan_type_d = 11 AND organization_id=", organizationId, " AND  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                        CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end ) group by code_no" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPart861DataSubReport(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY challan_id) AS sl_no ,tr_challan_no,to_char(date_challan,'dd/MM/yyyy') date_challan,\r\n                            remarks,code_no, sum(amount) amount,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code from trns_treasury_challan\r\n                          inner join set_bank_branch sbb on trns_treasury_challan.branch_id=sbb.branch_id\r\n                          inner join set_bank sb on sbb.bank_id= sbb.bank_id \r\n                          where chalan_type_d=11 AND trns_treasury_challan.organization_id=", organizationId, " and  (case when trns_treasury_challan.application_submit_date is null then CAST(trns_treasury_challan.date_challan AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.date_challan AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') else\r\n                          CAST(trns_treasury_challan.application_submit_date AS DATE)>=to_date('", fDate, "','dd/MM/yyyy') and CAST(trns_treasury_challan.application_submit_date AS DATE)<=to_date('", tDate, "','dd/MM/yyyy') end ) \r\n                          group by trns_treasury_challan.challan_id, trns_treasury_challan.tr_challan_no,trns_treasury_challan.date_challan,sbb.branch_name,sb.bank_name,sb.bank_code,sbb.branch_code ,trns_treasury_challan.code_no,set_bank.bank_name" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnPartImport4DataSubReport(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,i.hs_code,\r\n                             m.challan_no,to_char(m.bl_date,'dd/MM/yyyy') as date_challan, m.port_code, m.no_of_item, m.cpc, d.assesment_amount, d.at,\r\n                             i.item_id, i.item_name  ,cast(coalesce(d.Quantity*d.purchase_unit_price,0) as decimal(18,2)) price, \r\n                              cast(coalesce(d.purchase_vat,0) as decimal(18,2)) vat,cast(coalesce(d.purchase_sd,0) as decimal(18,2)) sd, case \r\n                               when d.is_exempted=true then Concat('অব্যাহতিপ্রাপ্ত পণ্য/সেবা')\r\n                               when d.is_fixed_vat=true then Concat('সুনির্দিষ্ট কর এর পণ্য/সেবা')\r\n                              else Concat((fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))) ,'%',' VAT') \r\n                               end                               \r\n                               remarks\r\n                              from trns_purchase_detail d\r\n                              inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                              inner join item as i on i.item_id =d.item_id\r\n                            where CAST(m.date_challan as DATE)>= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(m.date_challan as DATE)<= to_date('", tDate, "','dd/MM/yyyy') \r\n                           and d.is_exempted=false AND d.is_deleted = false AND m.purchase_type='I' AND m.challan_type='P'\r\n                            AND d.is_rebatable = false AND m.organization_id=", organizationId, " " };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getVatSubFormNote18(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,\r\n                        i.hs_code,i.item_name,d.quantity,d.total_price price,d.purchase_sd sd, case when i.vat_rebate!=0 then d.purchase_vat*i.vat_rebate/100 else d.purchase_vat end vat\r\n                        ,case when i.vat_rebate!=0 then concat(i.vat_rebate,'% rebatable ') else CONCAT('Tk.',(fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))),' Per Unit') end remarks\r\n                        ,(select unit_name from item_unit where unit_id=d.unit_id) as unit_name\r\n\t\t\t            from trns_purchase_detail  as d\r\n                        inner join trns_purchase_master as m on d.challan_id = m.challan_id\r\n                        inner join item_unit as u on d.unit_id =u.unit_id\r\n                        inner join item as i on i.item_id =d.item_id where ((CAST(m.date_challan  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) or (CAST(m.rebate_date  as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(m.rebate_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy')) )   and d.approver_stage='F'  and d.is_current_month_rebate=true\r\n                       AND d.is_rebatable = true AND d.is_deleted = false AND m.organization_id=", organizationId, " AND m.purchase_type = 'L' AND m.challan_type='P' AND d.is_fixed_vat=true" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatSubFormNote6(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "   select ROW_NUMBER() OVER(ORDER BY m.challan_id) AS sl_no ,d.item_id,d.vat_rate,d.sd_rate,Concat(i.item_name,' ',i.item_specification,' ',i.brand_name) as details,\r\n                        i.hs_code,i.item_name,d.quantity, (d.actual_price*d.quantity) as price,d.sd sd,d.vat vat,CONCAT('Tk.',(fngetbanglaamount(CAST(d.vat_rate as numeric(18,2)))),' Per Unit') remarks\r\n                        ,(select unit_name from item_unit where unit_id=d.unit_id) as unit_name\r\n\t\t\t            from trns_sale_detail  as d\r\n                        inner join trns_sale_master as m on d.challan_id = m.challan_id\r\n                        inner join item as i on i.item_id =d.item_id where CAST(m.date_challan as DATE) >=  to_date('", fDate, "','dd/MM/yyyy')\r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy')   and d.approver_stage='F'\r\n                        AND d.is_deleted = false AND m.organization_id=", organizationId, " AND d.is_fixed_vat=true" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getZeroRateNote10(string fDate, string tDate, int organizationId)
        {
            object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m  on d.challan_id = m.challan_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'  \r\n                        AND d.is_deleted = false AND m.purchase_type='L' AND d.is_exempted=false and d.is_fixed_vat=false AND d.is_truncated=false AND d.zero_rate=true AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
            string str = string.Concat(objArray);
            return this.db.GetDataTable(str);
        }

        public DataTable getZeroRateNote11(string fDate, string tDate, int organizationId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select cast(coalesce(sum(d.Quantity*d.purchase_unit_price-d.vds_amount),0) as decimal(18,2)) price, \r\n                              cast(coalesce(sum(d.purchase_vat),0) as decimal(18,2)) Vat, \r\n\t                          d.is_exempted, m.purchase_type,d.real_property,zero_rate\r\n                              ,sum(d.purchase_sd) AS purchase_sd,sum(d.cd) as cd,sum(d.rd) as rd\r\n                        from trns_purchase_detail d\r\n                        inner join trns_purchase_master m on d.challan_id = m.challan_id\r\n                        where CAST(m.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy')    \r\n                        AND CAST(m.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') And m.challan_type='P' and d.approver_stage='F'  \r\n                        AND d.is_deleted = false AND m.purchase_type='I' AND d.vat_rate!=15 AND d.is_exempted=false and d.is_fixed_vat=false AND d.is_rebatable=true  AND  d.is_truncated=false AND d.zero_rate=true AND m.organization_id=", organizationId, "\r\n                        group by d.is_exempted,m.purchase_type,d.real_property,zero_rate,is_source_tax_deduct" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }
    }
}