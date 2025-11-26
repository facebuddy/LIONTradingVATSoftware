using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class trnsTreasuryChallanBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public trnsTreasuryChallanBLL()
        {
        }

        public bool deleteChallanDeposit(int intChallanId)
        {
            string str = string.Concat("UPDATE trns_treasury_challan SET Is_deleted=true WHERE Challan_id = '", intChallanId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable getAITReturnReportData()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("SELECT  Challan_id,challan_no,Vat,sale_price,date_challan ,party_name,party_id\r\n                        FROM\r\n                        (\r\n                        select tp.Party_id,sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan\r\n                        --,sum(Sd.Vat) as Vat\r\n                        ,sum(Sd.ait) as Vat\r\n                        --, sum((Sd.actual_price+Sd.Vat+Sd.Sd)) as sale_price\r\n                        , sum(((Sd.quantity*Sd.purchase_unit_price)+Sd.purchase_vat+Sd.purchase_sd)) as sale_price\r\n                        , tp.party_name from trns_purchase_master as sm\r\n                         join trns_purchase_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                         join trns_party as tp on tp.Party_id=sm.Party_id \r\n                         WHERE Sd.ait>0 = true and sm.organization_id=", num, "\r\n                         group by sm.Challan_id,tp.party_name ,tp.Party_id\r\n                         having --sum(Sd.Vat)>0 \r\n                         sum(Sd.ait)>0\r\n                         and sm.Is_deleted=false and is_vat_paid=false \r\n                        )A order by Challan_id desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getChallanDataById(int intChallanId)
        {
            string str = string.Concat("select ttc.*, sbb.branch_id branchId, sb.bank_id BankId, ori.organization_name orName, ori.business_address orAddress, acd.code_name from trns_treasury_challan ttc\r\n        inner join set_bank_branch sbb on ttc.branch_id=sbb.branch_id\r\n        inner join set_bank sb on sbb.bank_id=sb.bank_id \r\n        inner join org_registration_info ori on ttc.Organization_id=ori.Organization_id \r\n        inner join app_code_detail acd on ttc.chalan_type_m=acd.code_id_m and ttc.chalan_type_d=acd.code_id_d\r\n        where ttc.Is_deleted=false and Challan_id='", intChallanId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getChallanDataForgv()
        {
            return this.DBUtil.GetDataTable("select ttc.*, sbb.branch_name brName, sb.bank_name bName, ori.organization_name orName, ori.business_address orAddress, acd.code_name ChallanType from trns_treasury_challan ttc\r\n        inner join set_bank_branch sbb on ttc.branch_id=sbb.branch_id\r\n        inner join set_bank sb on sbb.bank_id=sb.bank_id \r\n        inner join org_registration_info ori on ttc.Organization_id=ori.Organization_id \r\n        inner join app_code_detail acd on ttc.chalan_type_m=acd.code_id_m and ttc.chalan_type_d=acd.code_id_d\r\n        where ttc.Is_deleted=false");
        }

        public DataTable getChallanForAIT()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "  select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.AIT) as Vat, sum(((Sd.actual_price*quantity)+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name,sm.party_id from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on cth.challan_id=sm.challan_id\r\n                       \r\n                        group by cth.payment_amount,cth.tr_challan_status_ait,sm.Challan_id,tp.party_name,sd.approver_stage='F'  having sum(Sd.AIT)>0 and sm.Is_deleted=false  and sd.approver_stage='F' \r\n                         and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0) and (is_vat_paid=false or cth.tr_challan_status_ait is null) AND sm.organization_id =", num, "\r\n                        union\r\n                         select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.AIT) as Vat, \r\n                         sum(((Sd.actual_price*quantity)+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name,sm.party_id \r\n                         from trns_purchase_master as sm\r\n                        join trns_purchase_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on cth.challan_id=sm.challan_id\r\n                        group by cth.payment_amount,cth.tr_challan_status_ait,sm.Challan_id,tp.party_name,sd.approver_stage='F'  having sum(Sd.AIT)>0 and sm.Is_deleted=false and sd.approver_stage='F' \r\n                         and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0) and (is_vat_paid=false or cth.tr_challan_status_ait is null) AND sm.organization_id =", num, " order by sm.date_challan desc" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanForAIT(DateTime fromDate, DateTime toDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] str = new object[] { "  select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.AIT) as Vat, sum(((Sd.actual_price*quantity)+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name,sm.party_id from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on cth.challan_id=sm.challan_id\r\n                       \r\n                        group by cth.payment_amount,cth.tr_challan_status_ait,sm.Challan_id,tp.party_name having sum(Sd.AIT)>0 and sm.Is_deleted=false \r\n                        and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0) and (is_vat_paid=false or cth.tr_challan_status_ait is null) AND sm.organization_id =", num, " AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        union\r\n                         select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.AIT) as Vat, \r\n                         sum(((Sd.actual_price*quantity)+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name,sm.party_id \r\n                         from trns_purchase_master as sm\r\n                        join trns_purchase_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on cth.challan_id=sm.challan_id\r\n                        group by cth.payment_amount,cth.tr_challan_status_ait,sm.Challan_id,tp.party_name having sum(Sd.AIT)>0 and sm.Is_deleted=false\r\n                         and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0) and (is_vat_paid=false or cth.tr_challan_status_ait is null) AND sm.organization_id =", num, " AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')" };
                string str1 = string.Concat(str);
                dataTable = this.DBUtil.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanForHealthCharge()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.health_surcharge) as Vat, sum(((Sd.actual_price*quantity)+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name,sm.party_id from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on  cth.Challan_id=sm.Challan_id\r\n                        group by cth.payment_amount,sm.Challan_id,tp.party_name having sum(Sd.health_surcharge)>0 and sm.Is_deleted=false and is_vat_paid=false  and sd.approver_stage='F' \r\n                        and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0) \r\n                        AND sm.organization_id = ", num, " order by sm.date_challan desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanForNonSale()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat(" select tnm.note_id challan_id,tnm.note_no challan_no,To_Char(tnm.date_note, 'dd/MM/yyyy') as date_challan,\r\n                        case when tnm.note_no='otheradjustment' then SUM(tnd.vat_amount) else SUM(tnd.total_price) end sale_price,\r\n                      case when tnm.note_no='otheradjustment' then SUM(tnd.interest_amount) else SUM(tnd.total_vat) end as Vat,\r\n                        --sum(tnd.total_vat) as Vat, SUM(tnd.total_price) as sale_price,\r\n                         tp.party_name,tnm.party_id\r\n                          from trns_note_master as tnm\r\n                        join trns_note_detail as tnd on tnm.note_id=tnd.note_id                        \r\n                        join trns_party as tp on tp.Party_id=tnm.Party_id\r\n                        \r\n                        \r\n                        group by tnm.note_id,tp.party_name having \r\n                        sum(tnd.vat_amount)>0  and \r\n                        is_vat_paid=false\r\n                        \r\n                        AND tnm.organization_id = ", num, " order by tnm.note_id desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanForSD()
        {
            DataTable dataTable = new DataTable();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            try
            {
                string str = string.Concat("select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.sd) as vat, sum((Sd.actual_price+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name, tp.party_id from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on  cth.Challan_id=sm.Challan_id\r\n                        group by cth.payment_amount,sm.Challan_id,tp.party_name, tp.party_id having sum(Sd.sd)>0 and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0) and sm.Is_deleted=false  and sd.approver_stage='F' and is_sd_paid=false AND sm.organization_id = ", num, " order by sm.date_challan desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanForSD(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            try
            {
                object[] str = new object[] { "select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.sd) as vat, sum((Sd.actual_price+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name, tp.party_id from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on  cth.Challan_id=sm.Challan_id\r\n                        group by cth.payment_amount,sm.Challan_id,tp.party_name, tp.party_id having sum(Sd.sd)>0 and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0) and sm.Is_deleted=false and is_sd_paid=false AND sm.organization_id = ", num, " AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') " };
                string str1 = string.Concat(str);
                dataTable = this.DBUtil.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanForVat()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.Vat) as Vat, sum(((Sd.actual_price*quantity)+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name,sm.party_id from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id                       \r\n                        group by sm.Challan_id,tp.party_name,sd.approver_stage having sum(Sd.Vat)>0 and sm.Is_deleted=false and is_vat_paid=false and sd.approver_stage='F' \r\n                        AND sm.organization_id = ", num, " order by sm.date_challan desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getChallanForVat(DateTime fromDate, DateTime toDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] str = new object[] { "select sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan,sum(Sd.Vat) as Vat, sum(((Sd.actual_price*quantity)+Sd.Vat+Sd.Sd)) as sale_price, tp.party_name,sm.party_id from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join credit_transac_history cth on  cth.Challan_id=sm.Challan_id\r\n                        group by cth.payment_amount,sm.Challan_id,tp.party_name having sum(Sd.Vat)>0 and sm.Is_deleted=false and is_vat_paid=false\r\n                        and ((sm.cash_amount+sm.bank_amount)>0\r\n                        or cth.payment_amount>0)\r\n                        AND sm.organization_id = ", num, " AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') " };
                string str1 = string.Concat(str);
                dataTable = this.DBUtil.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet getChallanInfoByOrgId(short OrgId)
        {
            string str = string.Concat("select *, challan_no||'//'||date_challan challanId from trns_treasury_challan where Is_deleted=false and Organization_id=", OrgId);
            return this.DBUtil.GetDataSet(str, "TChallanByOrg");
        }

        public DataTable getChallanType()
        {
            return this.DBUtil.GetDataTable("select * from app_code_detail where code_id_m='9' and Is_deleted=false");
        }

        public DataTable getChallanTypeWithOrderBy()
        {
            return this.DBUtil.GetDataTable("select * from app_code_detail where code_id_m='9' and Is_deleted=false order by code_id_d  ");
        }

        public DataTable getCircleCodeForAccount(int circle_id)
        {
            string str = string.Concat("select comm_code from  vat_commissionerate where police_station_id = ", circle_id, " AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getLastChallan_id()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select Challan_id from trns_treasury_challan order by Challan_id desc Limit 1");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getMaxScrollID(int ChallanId)
        {
            string str = string.Concat("select count(scroll_id) noscroll_id\r\n                              from credit_transac_history\r\n                              where challan_id=", ChallanId, " and payment_amount!=0 ");
            return this.DBUtil.GetDataTable(str);
        }

        public short getOrgId()
        {
            return Convert.ToInt16(this.DBUtil.GetSingleValue("select nextval('organization_id_seq')"));
        }

        public DataTable getpaidScrollID(int ChallanId)
        {
            string str = string.Concat("select count(scroll_id) noscroll_id\r\n                              from credit_transac_history\r\n                              where challan_id=", ChallanId, " and  tr_challan_status='partial' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPaymentBreakdown(string challanNo, int challanId)
        {
            DataTable dataTable = new DataTable();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            try
            {
                object[] objArray = new object[] { "select ROW_NUMBER () OVER (ORDER BY scroll_id) index_id,challan_id,case when tr_challan_status is null then '-' else 'partially TR Challan Paid' end status, \r\n                             scroll_id,challan_no,coalesce(proportion_vds,0) AS proportion_vds, coalesce(proportion_ait,0) AS proportion_ait,\r\n                            coalesce(payment_amount,0)  AS amount_for_vds\r\n\t                        from credit_transac_history where challan_no= '", challanNo, "' and challan_id = ", challanId, " and payment_amount!=0 and organization_id = ", num };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getPaymentBreakdownAIT(string challanNo)
        {
            DataTable dataTable = new DataTable();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            try
            {
                object[] objArray = new object[] { "select challan_id,case when tr_challan_status_ait is null then '-' else 'partially TR Challan Paid' end status, scroll_id,challan_no,coalesce(proportion_vds,0) AS proportion_vds, coalesce(proportion_ait,0) AS proportion_ait,coalesce(payment_amount,0)  AS amount_for_vds\r\n\t                        from credit_transac_history where challan_no= '", challanNo, "' and organization_id = ", num };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getPaymentFinish(int ChallanId)
        {
            string str = string.Concat("select is_payment_finished from trns_purchase_master where challan_id=", ChallanId, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPoliceStationId2_1(int orgId)
        {
            string str = string.Concat("select thana_id from  org_reg_address where organization_id=", orgId, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getTRChallan()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select distinct challan_id,tr_challan_no from trns_treasury_challan where tr_challan_no!='' and organization_id=", num);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getTrChallanHavingParties()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select tcpt.party_id, tp.party_name from trns_tr_challan_party_tracking tcpt\r\n                        inner join trns_party tp on tcpt.party_id=tp.party_id\r\n                        inner join trns_treasury_challan ttc on tcpt.challan_id=ttc.challan_id\r\n                        where ttc.organization_id=", num);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getTRChallanIdForAnnexure(int challan_id)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select challan_id from trns_treasury_challan where challan_id='", challan_id, "'");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getTRChallanInfoForAnnexure(int challanId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select t.track_id,p.party_name,t.challan_no,t.tr_amount\r\n                                   from trns_tr_challan_party_tracking t\r\n                                   inner join trns_party p on t.party_id = p.party_id\r\n                                   where t.challan_id = ", challanId);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnReportData()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("SELECT distinct Challan_id,challan_no,Vat,sale_price,date_challan ,party_name,party_id\r\n                \r\n                        FROM\r\n                        (                                   \r\n                        select distinct  tp.Party_id,sm.Challan_id,sm.challan_no,To_Char(sm.date_challan, 'dd/MM/yyyy') as date_challan\r\n                        --,sum(Sd.Vat) as Vat\r\n                        ,sum(Sd.purchase_vat) as Vat\r\n                        --, sum((Sd.actual_price+Sd.Vat+Sd.Sd)) as sale_price\r\n                         , sum(((Sd.quantity*sd.purchase_unit_price)+Sd.purchase_vat+Sd.purchase_sd)) as sale_price\r\n                        , tp.party_name from trns_purchase_master as sm\r\n                         join trns_purchase_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                         join trns_party as tp on tp.Party_id=sm.Party_id \r\n                         --left join credit_transac_history cth on cth.challan_id=Sd.Challan_id\r\n                         WHERE Sd.is_source_tax_deduct = true and sm.organization_id=", num, "  and sd.approver_stage='F'\r\n                        group by sm.Challan_id,tp.party_name ,tp.Party_id\r\n                        --cth.payment_amount,\r\n                         having --sum(Sd.Vat)>0 \r\n                         sum(Sd.purchase_vat)>0\r\n                      and (sm.cash_amount+sm.bank_amount>0 or creditpay_status=true)\r\n                          --and ((sm.cash_amount+sm.bank_amount)>0\r\n                       -- or cth.payment_amount>0)\r\n                         and sm.Is_deleted=false and is_vat_paid=false \r\n                        )A order by Challan_id desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getVatReturnReportDataOLD()
        {
            return this.DBUtil.GetDataTable("select vat_term as challan_no, total_vat_n30 as Vat, To_Char(date_insert,'dd/mm/yyyy') as sale_price,refund_amount_n33 as date_challan,vat_report_year as party_name \r\n                            from vat_return where is_vat_paid = false");
        }

        public bool InsertChallanDeposit(trnsTreasuryChallanDAO objTrnsTreasuryChallanDAO)
        {
            object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d) VALUES   ( '", objTrnsTreasuryChallanDAO.ChallanNo, "','", objTrnsTreasuryChallanDAO.DateChallan, "', '", objTrnsTreasuryChallanDAO.BranchId, "', '", objTrnsTreasuryChallanDAO.CodeNo, "', '", objTrnsTreasuryChallanDAO.BearerNameAddress, "', '", objTrnsTreasuryChallanDAO.OrganizationId, "', '", objTrnsTreasuryChallanDAO.DepositDescription, "', '", objTrnsTreasuryChallanDAO.InstrumentDescription, "', '", objTrnsTreasuryChallanDAO.UserIdInsert, "', '", objTrnsTreasuryChallanDAO.Designation, "', '", objTrnsTreasuryChallanDAO.Unit, "', '", objTrnsTreasuryChallanDAO.Amount, "', '", objTrnsTreasuryChallanDAO.InstrumentType, "', '", objTrnsTreasuryChallanDAO.ChallanTypem, "', '", objTrnsTreasuryChallanDAO.ChallanTyped, "')" };
            string str = string.Concat(challanNo);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertTreasuryChallanData(ArrayList arrDetailDAO, ArrayList arrPartyChallan)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('tr_challan_id_seq')"));
            HttpContext.Current.Session["challanIdAnnexere"] = num;
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsTreasuryChallanDAO _trnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();
                _trnsTreasuryChallanDAO = (trnsTreasuryChallanDAO)arrDetailDAO[i];
                string str = "";
                string str1 = "";
                for (int j = 0; j < _trnsTreasuryChallanDAO.Challan_numbers.Count; j++)
                {
                    if (j != 0)
                    {
                        str = string.Concat(str, ",", _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, ",'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                    else
                    {
                        str = string.Concat(str, _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, "'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                }
                object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_id,challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d,challan_numbers, org_address) \r\n                VALUES(", num, ", '", _trnsTreasuryChallanDAO.ChallanNo, "', to_timestamp('", _trnsTreasuryChallanDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", _trnsTreasuryChallanDAO.BranchId, "', '", _trnsTreasuryChallanDAO.CodeNo, "', '", _trnsTreasuryChallanDAO.BearerNameAddress, "', '", _trnsTreasuryChallanDAO.OrganizationId, "', \r\n            '", _trnsTreasuryChallanDAO.DepositDescription, "', '", _trnsTreasuryChallanDAO.InstrumentDescription, "', ", _trnsTreasuryChallanDAO.UserIdInsert, ", '", _trnsTreasuryChallanDAO.Designation, "', '", _trnsTreasuryChallanDAO.Unit, "', '", _trnsTreasuryChallanDAO.Amount, "', \r\n            '", _trnsTreasuryChallanDAO.InstrumentType, "', ", _trnsTreasuryChallanDAO.ChallanTypem, ",'", _trnsTreasuryChallanDAO.ChallanTyped, "','", str, "','", _trnsTreasuryChallanDAO.OrgAddress, "')" };
                arrayLists.Add(string.Concat(challanNo));
                if (str1 != "")
                {
                    arrayLists.Add(string.Concat("update trns_sale_master set is_vat_paid=true where challan_no in(", str1, ")"));
                }
            }
            arrayLists = this.Inserttrns_tr_challan_party_tracking(arrayLists, arrPartyChallan, num);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool InsertTreasuryChallanDataForHealthCharge(ArrayList arrDetailDAO, ArrayList arrDetailDAOTd)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('tr_challan_id_seq')"));
            HttpContext.Current.Session["challanIdAnnexere"] = num;
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsTreasuryChallanDAO _trnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();
                _trnsTreasuryChallanDAO = (trnsTreasuryChallanDAO)arrDetailDAO[i];
                string str = "";
                string str1 = "";
                for (int j = 0; j < _trnsTreasuryChallanDAO.Challan_numbers.Count; j++)
                {
                    if (j != 0)
                    {
                        str = string.Concat(str, ",", _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, ",'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                    else
                    {
                        str = string.Concat(str, _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, "'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                }
                object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_id,challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d,challan_numbers,org_address,application_submit_date) \r\n                VALUES(", num, ", '", _trnsTreasuryChallanDAO.ChallanNo, "', to_timestamp('", _trnsTreasuryChallanDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", _trnsTreasuryChallanDAO.BranchId, "', '", _trnsTreasuryChallanDAO.CodeNo, "', '", _trnsTreasuryChallanDAO.BearerNameAddress, "', '", _trnsTreasuryChallanDAO.OrganizationId, "', \r\n            '", _trnsTreasuryChallanDAO.DepositDescription, "', '", _trnsTreasuryChallanDAO.InstrumentDescription, "', ", _trnsTreasuryChallanDAO.UserIdInsert, ", '", _trnsTreasuryChallanDAO.Designation, "', '", _trnsTreasuryChallanDAO.Unit, "', '", _trnsTreasuryChallanDAO.Amount, "', \r\n            '", _trnsTreasuryChallanDAO.InstrumentType, "', ", _trnsTreasuryChallanDAO.ChallanTypem, ",'", _trnsTreasuryChallanDAO.ChallanTyped, "','", str, "','", _trnsTreasuryChallanDAO.OrgAddress, "',to_timestamp('", _trnsTreasuryChallanDAO.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI')))" };
                arrayLists.Add(string.Concat(challanNo));
                if (str1 != "")
                {
                    arrayLists.Add(string.Concat("update trns_sale_master set is_sd_paid = true where challan_id in (", str1, ")"));
                }
            }
            arrayLists = this.Inserttrns_tr_challan_party_tracking(arrayLists, arrDetailDAOTd, num);
            arrayLists = this.Inserttrns_tr_challan_detail(arrayLists, arrDetailDAOTd, num);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool InsertTreasuryChallanDataForNote(ArrayList arrDetailDAO, ArrayList arrDetailDAOTd)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('tr_challan_id_seq')"));
            HttpContext.Current.Session["challanIdAnnexere"] = num;
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsTreasuryChallanDAO _trnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();
                _trnsTreasuryChallanDAO = (trnsTreasuryChallanDAO)arrDetailDAO[i];
                string str = "";
                string str1 = "";
                for (int j = 0; j < _trnsTreasuryChallanDAO.Challan_numbers.Count; j++)
                {
                    if (j != 0)
                    {
                        str = string.Concat(str, ",", _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, ",'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                    else
                    {
                        str = string.Concat(str, _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, "'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                }
                object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_id,challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d,challan_numbers,org_address,application_submit_date) \r\n                VALUES(", num, ", '", _trnsTreasuryChallanDAO.ChallanNo, "', to_timestamp('", _trnsTreasuryChallanDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", _trnsTreasuryChallanDAO.BranchId, "', '", _trnsTreasuryChallanDAO.CodeNo, "', '", _trnsTreasuryChallanDAO.BearerNameAddress, "', '", _trnsTreasuryChallanDAO.OrganizationId, "', \r\n            '", _trnsTreasuryChallanDAO.DepositDescription, "', '", _trnsTreasuryChallanDAO.InstrumentDescription, "', ", _trnsTreasuryChallanDAO.UserIdInsert, ", '", _trnsTreasuryChallanDAO.Designation, "', '", _trnsTreasuryChallanDAO.Unit, "', '", _trnsTreasuryChallanDAO.Amount, "', \r\n            '", _trnsTreasuryChallanDAO.InstrumentType, "', ", _trnsTreasuryChallanDAO.ChallanTypem, ",'", _trnsTreasuryChallanDAO.ChallanTyped, "','", str, "','", _trnsTreasuryChallanDAO.OrgAddress, "',to_timestamp('", _trnsTreasuryChallanDAO.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(challanNo));
                if (str1 != "")
                {
                    arrayLists.Add(string.Concat("update trns_note_master set is_vat_paid=true where note_id in(", str1, ")"));
                }
            }
            arrayLists = this.Inserttrns_tr_challan_party_tracking(arrayLists, arrDetailDAOTd, num);
            arrayLists = this.Inserttrns_tr_challan_detail(arrayLists, arrDetailDAOTd, num);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool InsertTreasuryChallanDataForPurchase(ArrayList arrDetailDAO, string isPayment, ArrayList arrDetailDAOTd, Dictionary<int, bool> isTR)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('tr_challan_id_seq')"));
            HttpContext.Current.Session["challanIdAnnexere"] = num;
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsTreasuryChallanDAO _trnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();
                _trnsTreasuryChallanDAO = (trnsTreasuryChallanDAO)arrDetailDAO[i];
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                for (int j = 0; j < _trnsTreasuryChallanDAO.Challan_numbers.Count; j++)
                {
                    if (j != 0)
                    {
                        str = string.Concat(str, ",", _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, ",'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                    else
                    {
                        str = string.Concat(str, _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, "'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                }
                for (int k = 0; k < _trnsTreasuryChallanDAO.ScrollId.Count; k++)
                {
                    if (k != 0)
                    {
                        str2 = string.Concat(str2, ",", _trnsTreasuryChallanDAO.ScrollId[k]);
                        str3 = string.Concat(str3, ",'", _trnsTreasuryChallanDAO.ScrollId[k], "'");
                    }
                    else
                    {
                        str2 = string.Concat(str2, _trnsTreasuryChallanDAO.ScrollId[k]);
                        str3 = string.Concat(str3, "'", _trnsTreasuryChallanDAO.ScrollId[k], "'");
                    }
                }
                object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_id,challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d,challan_numbers,org_address,application_submit_date) \r\n                VALUES(", num, ", '", _trnsTreasuryChallanDAO.ChallanNo, "', to_timestamp('", _trnsTreasuryChallanDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", _trnsTreasuryChallanDAO.BranchId, "', '", _trnsTreasuryChallanDAO.CodeNo, "', '", _trnsTreasuryChallanDAO.BearerNameAddress, "', '", _trnsTreasuryChallanDAO.OrganizationId, "', \r\n            '", _trnsTreasuryChallanDAO.DepositDescription, "', '", _trnsTreasuryChallanDAO.InstrumentDescription, "', ", _trnsTreasuryChallanDAO.UserIdInsert, ", '", _trnsTreasuryChallanDAO.Designation, "', '", _trnsTreasuryChallanDAO.Unit, "', '", _trnsTreasuryChallanDAO.Amount, "', \r\n            '", _trnsTreasuryChallanDAO.InstrumentType, "', ", _trnsTreasuryChallanDAO.ChallanTypem, ",'", _trnsTreasuryChallanDAO.ChallanTyped, "','", str, "','", _trnsTreasuryChallanDAO.OrgAddress, "',to_timestamp('", _trnsTreasuryChallanDAO.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(challanNo));
                if (str3 != "")
                {
                    arrayLists.Add(string.Concat("update credit_transac_history set tr_challan_status='partial' where scroll_id in(", str3, ")"));
                }
                foreach (KeyValuePair<int, bool> keyValuePair in isTR)
                {
                    if (!(str1 != "") || !_trnsTreasuryChallanDAO.isPayment || !keyValuePair.Value)
                    {
                        continue;
                    }
                    object[] value = new object[] { "update trns_purchase_master set is_vat_paid=", keyValuePair.Value, " where challan_id in(", keyValuePair.Key, ")" };
                    arrayLists.Add(string.Concat(value));
                }
            }
            arrayLists = this.Inserttrns_tr_challan_party_tracking(arrayLists, arrDetailDAOTd, num);
            arrayLists = this.Inserttrns_tr_challan_detail(arrayLists, arrDetailDAOTd, num);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool InsertTreasuryChallanDataForPurchaseAIT(ArrayList arrDetailDAO, string isPayment, ArrayList arrDetailDAOTd)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('tr_challan_id_seq')"));
            HttpContext.Current.Session["challanIdAnnexere"] = num;
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsTreasuryChallanDAO _trnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();
                _trnsTreasuryChallanDAO = (trnsTreasuryChallanDAO)arrDetailDAO[i];
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                for (int j = 0; j < _trnsTreasuryChallanDAO.Challan_numbers.Count; j++)
                {
                    if (j != 0)
                    {
                        str = string.Concat(str, ",", _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, ",'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                    else
                    {
                        str = string.Concat(str, _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, "'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                }
                for (int k = 0; k < _trnsTreasuryChallanDAO.ScrollId.Count; k++)
                {
                    if (k != 0)
                    {
                        str2 = string.Concat(str2, ",", _trnsTreasuryChallanDAO.ScrollId[k]);
                        str3 = string.Concat(str3, ",'", _trnsTreasuryChallanDAO.ScrollId[k], "'");
                    }
                    else
                    {
                        str2 = string.Concat(str2, _trnsTreasuryChallanDAO.ScrollId[k]);
                        str3 = string.Concat(str3, "'", _trnsTreasuryChallanDAO.ScrollId[k], "'");
                    }
                }
                object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_id,challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d,challan_numbers,org_address,application_submit_date) \r\n                VALUES(", num, ", '", _trnsTreasuryChallanDAO.ChallanNo, "', to_timestamp('", _trnsTreasuryChallanDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", _trnsTreasuryChallanDAO.BranchId, "', '", _trnsTreasuryChallanDAO.CodeNo, "', '", _trnsTreasuryChallanDAO.BearerNameAddress, "', '", _trnsTreasuryChallanDAO.OrganizationId, "', \r\n            '", _trnsTreasuryChallanDAO.DepositDescription, "', '", _trnsTreasuryChallanDAO.InstrumentDescription, "', ", _trnsTreasuryChallanDAO.UserIdInsert, ", '", _trnsTreasuryChallanDAO.Designation, "', '", _trnsTreasuryChallanDAO.Unit, "', '", _trnsTreasuryChallanDAO.Amount, "', \r\n            '", _trnsTreasuryChallanDAO.InstrumentType, "', ", _trnsTreasuryChallanDAO.ChallanTypem, ",'", _trnsTreasuryChallanDAO.ChallanTyped, "','", str, "','", _trnsTreasuryChallanDAO.OrgAddress, "',to_timestamp('", _trnsTreasuryChallanDAO.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI')))" };
                arrayLists.Add(string.Concat(challanNo));
                if (str3 != "")
                {
                    arrayLists.Add(string.Concat("update credit_transac_history set tr_challan_status_ait='partial' where scroll_id in(", str3, ")"));
                    if (str1 != "" && isPayment == "True")
                    {
                        arrayLists.Add(string.Concat("update trns_purchase_master set is_vat_paid=true where challan_no in(", str1, ")"));
                    }
                }
                else if (str1 != "")
                {
                    arrayLists.Add(string.Concat("update trns_purchase_master set is_vat_paid=true where challan_id in(", str1, ")"));
                }
            }
            arrayLists = this.Inserttrns_tr_challan_party_tracking(arrayLists, arrDetailDAOTd, num);
            arrayLists = this.Inserttrns_tr_challan_detail(arrayLists, arrDetailDAOTd, num);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool InsertTreasuryChallanDataForSD(ArrayList arrDetailDAO, ArrayList arrDetailDAOTd)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('tr_challan_id_seq')"));
            HttpContext.Current.Session["challanIdAnnexere"] = num;
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsTreasuryChallanDAO _trnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();
                _trnsTreasuryChallanDAO = (trnsTreasuryChallanDAO)arrDetailDAO[i];
                string str = "";
                string str1 = "";
                for (int j = 0; j < _trnsTreasuryChallanDAO.Challan_numbers.Count; j++)
                {
                    if (j != 0)
                    {
                        str = string.Concat(str, ",", _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, ",'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                    else
                    {
                        str = string.Concat(str, _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, "'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                }
                object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_id,challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d,challan_numbers,org_address,application_submit_date) \r\n                VALUES(", num, ", '", _trnsTreasuryChallanDAO.ChallanNo, "', to_timestamp('", _trnsTreasuryChallanDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", _trnsTreasuryChallanDAO.BranchId, "', '", _trnsTreasuryChallanDAO.CodeNo, "', '", _trnsTreasuryChallanDAO.BearerNameAddress, "', '", _trnsTreasuryChallanDAO.OrganizationId, "', \r\n            '", _trnsTreasuryChallanDAO.DepositDescription, "', '", _trnsTreasuryChallanDAO.InstrumentDescription, "', ", _trnsTreasuryChallanDAO.UserIdInsert, ", '", _trnsTreasuryChallanDAO.Designation, "', '", _trnsTreasuryChallanDAO.Unit, "', '", _trnsTreasuryChallanDAO.Amount, "', \r\n            '", _trnsTreasuryChallanDAO.InstrumentType, "', ", _trnsTreasuryChallanDAO.ChallanTypem, ",'", _trnsTreasuryChallanDAO.ChallanTyped, "','", str, "','", _trnsTreasuryChallanDAO.OrgAddress, "',to_timestamp('", _trnsTreasuryChallanDAO.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(challanNo));
                if (str1 != "")
                {
                    arrayLists.Add(string.Concat("update trns_sale_master set is_sd_paid = true where challan_no in(", str1, ")"));
                }
            }
            arrayLists = this.Inserttrns_tr_challan_party_tracking(arrayLists, arrDetailDAOTd, num);
            arrayLists = this.Inserttrns_tr_challan_detail(arrayLists, arrDetailDAOTd, num);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool InsertTreasuryChallanDataTR(ArrayList arrDetailDAO, ArrayList arrDetailDAOTd)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('tr_challan_id_seq')"));
            HttpContext.Current.Session["challanIdAnnexere"] = num;
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsTreasuryChallanDAO _trnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();
                _trnsTreasuryChallanDAO = (trnsTreasuryChallanDAO)arrDetailDAO[i];
                string str = "";
                string str1 = "";
                for (int j = 0; j < _trnsTreasuryChallanDAO.Challan_numbers.Count; j++)
                {
                    if (j != 0)
                    {
                        str = string.Concat(str, ",", _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, ",'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                    else
                    {
                        str = string.Concat(str, _trnsTreasuryChallanDAO.Challan_numbers[j]);
                        str1 = string.Concat(str1, "'", _trnsTreasuryChallanDAO.Challan_numbers[j], "'");
                    }
                }
                object[] challanNo = new object[] { "INSERT INTO trns_treasury_challan (challan_id,challan_no, date_challan, branch_id, code_no, bearer_name_address, Organization_id, \r\n                                deposit_description, instrument_description, User_id_insert, designation, Unit, Amount, instrument_type, chalan_type_m, chalan_type_d,challan_numbers, org_address,application_submit_date) \r\n                VALUES(", num, ", '", _trnsTreasuryChallanDAO.ChallanNo, "', to_timestamp('", _trnsTreasuryChallanDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", _trnsTreasuryChallanDAO.BranchId, "', '", _trnsTreasuryChallanDAO.CodeNo, "', '", _trnsTreasuryChallanDAO.BearerNameAddress, "', '", _trnsTreasuryChallanDAO.OrganizationId, "', \r\n            '", _trnsTreasuryChallanDAO.DepositDescription, "', '", _trnsTreasuryChallanDAO.InstrumentDescription, "', ", _trnsTreasuryChallanDAO.UserIdInsert, ", '", _trnsTreasuryChallanDAO.Designation, "', '", _trnsTreasuryChallanDAO.Unit, "', '", _trnsTreasuryChallanDAO.Amount, "', \r\n            '", _trnsTreasuryChallanDAO.InstrumentType, "', ", _trnsTreasuryChallanDAO.ChallanTypem, ",'", _trnsTreasuryChallanDAO.ChallanTyped, "','", str, "','", _trnsTreasuryChallanDAO.OrgAddress, "',to_timestamp('", _trnsTreasuryChallanDAO.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(challanNo));
                if (str1 != "")
                {
                    arrayLists.Add(string.Concat("update trns_sale_master set is_vat_paid=true where challan_id in(", str1, ")"));
                }
            }
            arrayLists = this.Inserttrns_tr_challan_party_tracking(arrayLists, arrDetailDAOTd, num);
            arrayLists = this.Inserttrns_tr_challan_detail(arrayLists, arrDetailDAOTd, num);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        private ArrayList Inserttrns_tr_challan_detail(ArrayList arrDetailList, ArrayList arrDetailDAOTd, int challan_id)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDetailDAOTd.Count; i++)
            {
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('trns_treasury_detail_id_seq')"));
                trnsTreasuryChallanDAODetail _trnsTreasuryChallanDAODetail = new trnsTreasuryChallanDAODetail();
                _trnsTreasuryChallanDAODetail = (trnsTreasuryChallanDAODetail)arrDetailDAOTd[i];
                object[] challanId = new object[] { "insert into trns_treasury_detail(trns_treasury_detail_id,tr_challan_id, purchase_challan_id, purchase_challan_no,amount,scroll_id) values (", num, ",", challan_id, " ,", _trnsTreasuryChallanDAODetail.Purchase_challan_id, ",'", _trnsTreasuryChallanDAODetail.purchaseChallanNo, "',", _trnsTreasuryChallanDAODetail.Amount, ",", _trnsTreasuryChallanDAODetail.Scroll_Id, ")" };
                arrDetailList.Add(string.Concat(challanId));
            }
            return arrDetailList;
        }

        private ArrayList Inserttrns_tr_challan_party_tracking(ArrayList arrDetailList, ArrayList arrPartyChallan, int challan_id)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrPartyChallan.Count; i++)
            {
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('track_id_seq')"));
                trnsTreasuryChallanDAODetail _trnsTreasuryChallanDAODetail = new trnsTreasuryChallanDAODetail();
               // _trnsTreasuryChallanDAODetail = (trnsTreasuryChallanDAODetail)arrPartyChallan[i];
                object[] challanId = new object[] { "insert into trns_tr_challan_party_tracking(track_id,challan_id, party_id, tr_amount, is_vat, is_sd, challan_no) values (", num, ",", challan_id, " ,", _trnsTreasuryChallanDAODetail.Party_Id, ",", _trnsTreasuryChallanDAODetail.Amount, ",", _trnsTreasuryChallanDAODetail.Is_VAT, ",", _trnsTreasuryChallanDAODetail.Is_SD, ",'", _trnsTreasuryChallanDAODetail.purchaseChallanNo, "')" };
                arrDetailList.Add(string.Concat(challanId));
            }
            return arrDetailList;
        }

        public DataTable showAllChallan()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select ttc.challan_no,(COALESCE(ttc.Amount,0)||COALESCE(ttc.instrument_type,'')) as vat_amount_unit,acd.code_name , COALESCE(ttc.challan_numbers,'No Challan') as challan_numbers,ttc.tr_challan_no,ttc.challan_id AS Challan_id,tr_challan_image\r\n                            from trns_treasury_challan as ttc \r\n                            join app_code_detail as acd on acd.code_id_d=ttc.chalan_type_d and acd.code_id_m=9\r\n                            where ttc.Is_deleted=false and acd.Is_deleted=false order by ttc.Challan_id desc");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable showAllChallanbyChallanId(int challan_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select ttc.challan_no,(COALESCE(ttc.Amount,0)||COALESCE(ttc.instrument_type,'')) as vat_amount_unit,acd.code_name , COALESCE(ttc.challan_numbers,'No Challan') as challan_numbers,ttc.tr_challan_no,ttc.challan_id AS Challan_id,tr_challan_image\r\n                            from trns_treasury_challan as ttc \r\n                            join app_code_detail as acd on acd.code_id_d=ttc.chalan_type_d and acd.code_id_m=9\r\n                            where ttc.Is_deleted=false and acd.Is_deleted=false and ttc.challan_id=", challan_id, " order by ttc.Challan_id desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable showChallan()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select ttc.challan_no,(COALESCE(ttc.Amount,0)||COALESCE(ttc.instrument_type,'')) as vat_amount_unit,acd.code_name , COALESCE(ttc.challan_numbers,'No Challan') as challan_numbers,ttc.tr_challan_no,ttc.challan_id,tr_challan_image\r\n                            from trns_treasury_challan as ttc \r\n                            join app_code_detail as acd on acd.code_id_d=ttc.chalan_type_d and acd.code_id_m=9\r\n                            where ttc.tr_challan_no='' and ttc.Is_deleted=false and acd.Is_deleted=false order by ttc.Challan_id desc");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable showTRChallan(int challan_id, string fromdate, string todate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] challanId = new object[] { "select ttc.bearer_name_address,ttc.org_address as bearer_name_designation,COALESCE(acd.code_name,'')||','||ttc.code_no|| ','||COALESCE(ttc.deposit_description,'')as deposit_description ,\r\n                    COALESCE(ttc.instrument_type,'')||','||COALESCE(ttc.instrument_description,'') as instrument_description,ttc.Amount,'00' as poisa,'' as challan_drawer,ttc.code_no,set_bank_branch.branch_name, \r\n                    --sd.district_name,\r\n                    to_char(ttc.date_challan,'dd/MM/yyyy') date_challan,ttc.tr_challan_image\r\n                    from trns_treasury_challan as ttc\r\n                    join org_registration_info as ori on ori.Organization_id=ttc.Organization_id\r\n                    inner join org_reg_address ora on ora.organization_id=ori.organization_id\r\n                    join app_code_detail as acd on acd.code_id_d=ttc.chalan_type_d and acd.code_id_m=9\r\n                    inner join set_bank_branch on ttc.branch_id=set_bank_branch.branch_id\r\n\t\t            --inner join set_upazila su on set_bank_branch.upazila_id=su.upazila_id\r\n\t\t            --inner join set_district sd on sd.district_id=su.district_id\r\n                    where ttc.challan_id='", challan_id, "' and CAST(date_challan AS DATE) >=to_date('", fromdate, "','dd/MM/yyyy') and CAST(date_challan AS DATE)<=to_date('", todate, "','dd/MM/yyyy') " };
                string str = string.Concat(challanId);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable showTRChallanFormByChallanNO(string challan_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] challanId = new object[] { "select ttc.bearer_name_address,ttc.org_address as bearer_name_designation,COALESCE(acd.code_name,'')||','||ttc.code_no|| ','||COALESCE(ttc.deposit_description,'')as deposit_description ,\r\n                    COALESCE(ttc.instrument_type,'')||','||COALESCE(ttc.instrument_description,'') as instrument_description,ttc.Amount,'00' as poisa,'' as challan_drawer,ttc.code_no  \r\n                    ,(select ' '|| branch_name || ' ' from set_bank_branch bb inner join set_bank b on bb.bank_id = b.bank_id where bb.branch_id=ttc.branch_id) bank_branch_name,\r\n                    (select sd.district_name from set_bank_branch bb inner join set_bank b on bb.bank_id = b.bank_id inner join set_upazila su on bb.upazila_id=su.upazila_id inner join set_district sd on sd.district_id=su.district_id where bb.branch_id=ttc.branch_id) district_name,\r\n                    ttc.challan_numbers,To_CHAR(ttc.date_challan,'dd/MM/yyyy') date_challan\r\n                    from trns_treasury_challan as ttc\r\n                    join org_registration_info as ori on ori.Organization_id=ttc.Organization_id\r\n                    inner join org_reg_address ora on ora.organization_id=ori.organization_id\r\n                    join app_code_detail as acd on acd.code_id_d=ttc.chalan_type_d and acd.code_id_m=9\r\n                    where ttc.Challan_id='", challan_id, "' AND ttc.organization_id = ", Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]) };
                string str = string.Concat(challanId);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public bool updateTRchallanByID(string trChallanNo, int challan_id, string image)
        {
            bool flag = false;
            try
            {
                object[] objArray = new object[] { "update trns_treasury_challan set tr_challan_no='", trChallanNo, "', tr_challan_image='", image, "' where challan_id=", challan_id, " and Is_deleted=false" };
                string str = string.Concat(objArray);
                flag = this.DBUtil.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }
    }
}

