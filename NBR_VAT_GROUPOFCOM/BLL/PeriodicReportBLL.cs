using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PeriodicReportBLL
    {
        private DBUtility db = new DBUtility();

        public PeriodicReportBLL()
        {
        }

        public DataTable GetAllAggrementNoForPurchase()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select aggrement_no from trns_purchase_master where aggrement_no is not null AND organization_id = ", num, " order by challan_id desc");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }





        public DataTable GetSalesPeriodicReportData(long CID, long ItemID)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            if (ItemID > (long)0)
            {
                object obj = empty;
                object[] itemID = new object[] { obj, " and tsd.item_id = ", ItemID, " " };
                empty = string.Concat(itemID);
            }
            try
            {
                object[] cID = new object[] { "select TO_CHAR(tsm.date_challan,'dd-MON-yyyy') vouchar_date, tp.party_id supplier_id,tp.party_name supplier_name,\r\n                         tsm.challan_no,tsd.item_id\r\n                         --,i.item_name,\r\n\r\n                       ,(i.item_name \r\n\t\t\t\t\t    || ' ' || (CASE WHEN tsd.property_id1 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t\t\t    where a.property_id1=tsd.property_id1 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id2 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t\t\t    where a.property_id2=tsd.property_id2 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id3 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t\t    where a.property_id3=tsd.property_id3 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id4 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t\t    where a.property_id4=tsd.property_id4 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id5 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t\t    where a.property_id5=tsd.property_id5 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    ) AS item_name,(i.item_sku) as item_sku /*zahid 09-08-22*/\r\n\r\n                               ,case when installment_status=false then  tsd.quantity else 0 end quantity,tsd.actual_price unit_price,tsd.is_fixed_vat,\r\n                               tsd.vat,tsd.vat_rate,tsd.sd,tsm.aggrement_no,\r\n                               case when tsd.sd>0\r\n\t\t\t\t\t            then(select tax_value from item_tax_values where tax_id=3 and is_deleted=false and is_tran_sale=true and item_id=tsd.item_id)\r\n\t\t\t\t\t            else 0 end sd_rate, \r\n                               --CAST((tsd.quantity*tsd.actual_price+tsd.sd+tsd.vat) as double precision) as value,\r\n                               CAST((tsd.quantity*tsd.actual_price) as double precision) as value,\r\n                               (select sum(CAST((m.quantity*m.actual_price+m.sd+m.vat) as double precision)) from trns_sale_detail m where m.challan_id = ", CID, ")  total,iu.unit_code,tsd.additional_property\r\n                               from trns_sale_master tsm\r\n                               inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               inner join item_unit iu on i.unit_id=iu.unit_id\r\n                               where tsm.challan_id = ", CID, empty };
                string str = string.Concat(cID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }



        public DataTable GetPeriodicSalesChallanNo(DateTime fDate, DateTime tDate, int SupplierID, long ItemID, string branchIds, string AggrementNO, int regTypId, int economicId, decimal sdRate, decimal vatRate, string transType, string itemType, int catId, int subcatId, int property_type, int property_id)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string empty = string.Empty;
            string str = "";
            DataTable dataTable = new DataTable();
            try
            {
                if (fDate > DateTime.MinValue && tDate > DateTime.MinValue)
                {
                    string str1 = empty;
                    string[] strArrays = new string[] { str1, " and CAST(tsm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tsm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
                    empty = string.Concat(strArrays);
                }
                if (property_type > 0)
                {
                    str = string.Format("ip.property_type_d={0} and", property_type);
                }
                if (property_id > 0)
                {
                    str = string.Concat(str, string.Format(" ip.property_id={0} and", property_id));
                }
                if (SupplierID > 0)
                {
                    object obj = empty;
                    object[] supplierID = new object[] { obj, " and tsm.party_id = ", SupplierID, " " };
                    empty = string.Concat(supplierID);
                }
                if (ItemID > (long)0)
                {
                    object obj1 = empty;
                    object[] itemID = new object[] { obj1, " and tsd.item_id = ", ItemID, " " };
                    empty = string.Concat(itemID);
                }
                if (AggrementNO != "-1")
                {
                    empty = string.Concat(empty, " and tsm.aggrement_no = '", AggrementNO, "'");
                }
                if (regTypId != 0)
                {
                    empty = string.Concat(empty, " and tp.reg_type=", regTypId);
                }
                if (economicId != 0)
                {
                    object obj2 = empty;
                    object[] objArray = new object[] { obj2, " and tp.major_area_of_ecn_activity='", economicId, "' " };
                    empty = string.Concat(objArray);
                }
                if (vatRate != new decimal(0))
                {
                    empty = string.Concat(empty, " and tsd.vat_rate=", vatRate);
                }
                if (sdRate != new decimal(0))
                {
                    object obj3 = empty;
                    object[] objArray1 = new object[] { obj3, " and itv.tax_value=", sdRate, " AND itv.is_tran_sale=true" };
                    empty = string.Concat(objArray1);
                }
                if (transType != "-1")
                {
                    empty = string.Concat(empty, " and tsm.trans_type='", transType, "' ");
                }
                if (itemType != "-1")
                {
                    if (itemType != "G")
                    {
                        empty = (itemType != "B" ? string.Concat(empty, " AND i.item_type<>'I' ") : string.Concat(empty, " AND (i.item_type='I' OR i.item_type='S') "));
                    }
                    else
                    {
                        empty = string.Concat(empty, " AND i.item_type='I' ");
                    }
                }
                if (catId != 0)
                {
                    empty = string.Concat(empty, " and ic.parent_id=", catId);
                }
                if (subcatId != 0)
                {
                    empty = string.Concat(empty, " and ic.category_id=", subcatId);
                }
                object[] objArray2 = new object[] { "select distinct tsm.challan_id, tsm.challan_no\r\n                                from trns_sale_master tsm\r\n                                inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                                inner join trns_party tp on tsm.party_id = tp.party_id\r\n                                inner join item i on tsd.item_id = i.item_id\r\n                                left join item_tax_values itv on itv.item_id = i.item_id\r\n                                inner join item_category ic on ic.category_id = i.sub_category_id and ic.parent_id!=0\r\n                                left join item_property ip on tsd.property_id1=ip.property_id or tsd.property_id2=ip.property_id or tsd.property_id3=ip.property_id  or tsd.property_id4=ip.property_id or tsd.property_id5=ip.property_id \r\n                                left join APP_CODE_DETAIL acd on acd.code_id_d=ip.property_type_d   \r\n                                where {0} tsm.organization_id=", num, " and tsm.org_branch_reg_id in(", branchIds, ")  AND tsm.is_deleted = false ", empty, " order by tsm.challan_id" };
                string str2 = string.Format(string.Concat(objArray2), str);
                dataTable = this.db.GetDataTable(str2);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }








        public DataTable GetAllAggrementNoForSale()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] objArray = new object[] { "select distinct aggrement_no from trns_sale_master where aggrement_no is not null AND organization_id = ", num, " and org_branch_reg_id=", num1, " " };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllCustomerForSale()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct tsm.party_id, tp.party_name\r\n                                from trns_sale_master tsm\r\n                                inner join trns_party tp on tsm.party_id = tp.party_id\r\n                                where tsm.is_deleted = false AND tsm.organization_id = ", Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]));
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllItemCategoryForPurchase()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select distinct ic.category_id, ic.category_name--, isc.category_name,i.item_name \r\n                                from item_category ic\r\n                                inner join item_category isc on ic.category_id = isc.parent_id\r\n                                inner join item i on isc.category_id = i.sub_category_id\r\n                                inner join trns_purchase_detail tpd on i.item_id = tpd.item_id where tpd.is_deleted = false and (i.organization_id=", num, " or i.is_for_all_bss_unit=true)");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllItemForPurchase()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                string str = string.Concat("select distinct tpd.item_id, i.item_name\r\n                                from trns_purchase_detail tpd\r\n                                inner join item i on tpd.item_id = i.item_id\r\n                                where tpd.is_deleted = false AND (i.organization_id = ", num, "  or i.is_for_all_bss_unit=true)");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllItemForSale()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct tsd.item_id, i.item_name\r\n                                from trns_sale_detail tsd\r\n                                inner join item i on tsd.item_id = i.item_id\r\n                                where tsd.is_deleted = false AND (i.organization_id = ", num, "  or i.is_for_all_bss_unit=true)");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllItemForSaleByType(string selectedValue)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                str = (selectedValue != "G" ? "AND i.item_type<>'I' " : "AND i.item_type='I' ");
                object[] objArray = new object[] { "select distinct tsd.item_id, i.item_name\r\n                                from trns_sale_detail tsd\r\n                                inner join item i on tsd.item_id = i.item_id\r\n                                where tsd.is_deleted = false AND (i.organization_id = ", num, "  or i.is_for_all_bss_unit=true)", str };
                string str1 = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllPurchaseDetail(DateTime fromDate, DateTime toDate, int challan_id)
        {
            object[] challanId = new object[] { "select to_char(sm.date_challan,'dd-MON-yyyy') date_challan,p.party_name,sm.challan_no,i.item_name,sd.quantity,sd.purchase_unit_price, cast(sd.total_price as double precision) total_price\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND SD.challan_id = ", challan_id, "AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            ORDER BY sd.challan_id" };
            string str = string.Concat(challanId);
            return this.db.GetDataTable(str);
        }

        public DataTable GetAllPurchaseDetailTotal(DateTime fromDate, DateTime toDate, int challan_id)
        {
            object[] challanId = new object[] { " select CAST(SUM(sd.total_price) AS double precision) total\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND SD.challan_id = ", challan_id, " AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n           " };
            string str = string.Concat(challanId);
            return this.db.GetDataTable(str);
        }

        public DataTable GetAllPurchaseFromMaster(DateTime fromDate, DateTime toDate)
        {
            string[] str = new string[] { "select challan_id,date_challan from trns_purchase_master WHERE  is_deleted= false AND payment_method <> '0'   AND TO_DATE(TO_CHAR(date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            ORDER BY challan_id" };
            string str1 = string.Concat(str);
            return this.db.GetDataTable(str1);
        }

        public DataTable GetAllPurchaseFullTotal(DateTime fromDate, DateTime toDate)
        {
            string[] str = new string[] { " select CAST(SUM(sd.total_price) AS double precision) fulltotal\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND sm.payment_method <> '0' AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n           " };
            string str1 = string.Concat(str);
            return this.db.GetDataTable(str1);
        }

        public DataTable GetAllPurchasePeriodicChallanNo(DateTime fDate, DateTime tDate)
        {
            string empty = string.Empty;
            string str = empty;
            string[] strArrays = new string[] { str, " and CAST(tpm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tpm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
            empty = string.Concat(strArrays);
            DataTable dataTable = new DataTable();
            try
            {
                string str1 = string.Concat("select distinct tpm.challan_id, tpm.challan_no\r\n                                from trns_purchase_master tpm\r\n                                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                inner join item i on tpd.item_id = i.item_id\r\n                                inner join item_category ic on ic.category_id = i.sub_category_id and ic.parent_id!=0\r\n                                where  TPM.is_trns_accepted=true AND tpm.is_deleted = false  and tpd.approver_stage='F' and tpm.purchase_type != 'F' ", empty, " order by tpm.challan_id");
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllSupplierForPurchase()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct tpm.party_id, tp.party_name\r\n                                from trns_purchase_master tpm\r\n                                inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                where tpm.purchase_type != 'F' AND tpm.organization_id = ", num, " and tpm.is_deleted = false");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetCategoryWisePurchaseReport(DateTime fDate, DateTime tDate, int ItemCategoryID)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                if (fDate > DateTime.MinValue && tDate > DateTime.MinValue)
                {
                    object obj = empty;
                    object[] objArray = new object[] { obj, " and tpm.date_challan >= to_date('", fDate, "','dd/MM/yyyy') and tpm.date_challan <= to_date('", tDate, "','dd/MM/yyyy')" };
                    empty = string.Concat(objArray);
                }
                if (ItemCategoryID > 0)
                {
                    object obj1 = empty;
                    object[] itemCategoryID = new object[] { obj1, " and tpd.item_id = ", ItemCategoryID, " " };
                    empty = string.Concat(itemCategoryID);
                }
                string str = string.Concat("select distinct tpm.challan_id, tpm.challan_no\r\n                                from trns_purchase_master tpm\r\n                                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                inner join item i on tpd.item_id = i.item_id\r\n                                where tpm.is_deleted = false and tpm.purchase_type != 'F' ", empty, " order by tpm.challan_id");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetMonthSeries()
        {
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            return this.db.GetDataTable(" SELECT to_char(GENERATE_SERIES\r\n       (\r\n           (DATE '2020-01-01'),\r\n           (DATE '2020-12-31'),\r\n           interval '1 MONTH'\r\n       )::DATE,'MONTH') mon");
        }

        public DataTable getPaymentMethodName(int methodID)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                empty = string.Concat("select payment_method_name from set_payment_method  where payment_method_id=", methodID);
                dataTable = this.db.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPeriodicSalesChallanNo(DateTime fDate, DateTime tDate, int SupplierID, int ItemID, string AggrementNO, int regTypId, int economicId, decimal sdRate, decimal vatRate, string transType, string itemType, int catId, int subcatId, int propertyId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                if (fDate > DateTime.MinValue && tDate > DateTime.MinValue)
                {
                    string str = empty;
                    string[] strArrays = new string[] { str, " and CAST(tsm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tsm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
                    empty = string.Concat(strArrays);
                }
                if (propertyId > 0)
                {
                    object obj = empty;
                    object[] objArray = new object[] { obj, " and (tsd.property_id1 = ", propertyId, " or tsd.property_id2 = ", propertyId, " or tsd.property_id3 = ", propertyId, " or tsd.property_id4 = ", propertyId, " or tsd.property_id5 = ", propertyId, ") " };
                    empty = string.Concat(objArray);
                }
                if (SupplierID > 0)
                {
                    object obj1 = empty;
                    object[] supplierID = new object[] { obj1, " and tsm.party_id = ", SupplierID, " " };
                    empty = string.Concat(supplierID);
                }
                if (ItemID > 0)
                {
                    object obj2 = empty;
                    object[] itemID = new object[] { obj2, " and tsd.item_id = ", ItemID, " " };
                    empty = string.Concat(itemID);
                }
                if (AggrementNO != "-1")
                {
                    empty = string.Concat(empty, " and tsm.aggrement_no = '", AggrementNO, "'");
                }
                if (regTypId != 0)
                {
                    empty = string.Concat(empty, " and tp.reg_type=", regTypId);
                }
                if (economicId != 0)
                {
                    object obj3 = empty;
                    object[] objArray1 = new object[] { obj3, " and tp.major_area_of_ecn_activity='", economicId, "' " };
                    empty = string.Concat(objArray1);
                }
                if (vatRate != new decimal(0))
                {
                    empty = string.Concat(empty, " and tsd.vat_rate=", vatRate);
                }
                if (sdRate != new decimal(0))
                {
                    object obj4 = empty;
                    object[] objArray2 = new object[] { obj4, " and itv.tax_value=", sdRate, " AND itv.is_tran_sale=true" };
                    empty = string.Concat(objArray2);
                }
                if (transType != "-1")
                {
                    empty = string.Concat(empty, " and tsm.trans_type='", transType, "' ");
                }
                if (itemType != "-1")
                {
                    if (itemType != "G")
                    {
                        empty = (itemType != "B" ? string.Concat(empty, " AND i.item_type<>'I' ") : string.Concat(empty, " AND (i.item_type='I' OR i.item_type='S') "));
                    }
                    else
                    {
                        empty = string.Concat(empty, " AND i.item_type='I' ");
                    }
                }
                if (catId != 0)
                {
                    empty = string.Concat(empty, " and ic.parent_id=", catId);
                }
                if (subcatId != 0)
                {
                    empty = string.Concat(empty, " and ic.category_id=", subcatId);
                }
                object[] objArray3 = new object[] { "select distinct tsm.challan_id, tsm.challan_no\r\n                                from trns_sale_master tsm\r\n                                inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                                inner join trns_party tp on tsm.party_id = tp.party_id\r\n                                inner join item i on tsd.item_id = i.item_id\r\n                                left join item_tax_values itv on itv.item_id = i.item_id\r\n                                inner join item_category ic on ic.category_id = i.sub_category_id and ic.parent_id!=0\r\n                               where tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, "  and tsd.approver_stage='F' AND tsm.is_deleted = false ", empty, " order by tsm.challan_id" };
                string str1 = string.Concat(objArray3);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPurchaseComparativeReportData(DateTime fDate, DateTime tDate, string month, int itemId)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            string str = "";
            try
            {
                string str1 = "";
                string str2 = "";
                if (itemId != -99)
                {
                    str1 = ",i.item_name,i.hs_code";
                    str2 = string.Concat(" and i.item_id=", itemId);
                }
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                if (month != "-99")
                {
                    object[] objArray = new object[] { " select to_char(DATE_TRUNC('month',m.Date_CHALLAN),'MONTH') mon, \r\n\t                        sum(d.quantity* d.purchase_unit_price) price,\r\n\t                        sum(d.purchase_sd) sd,\r\n\t                        sum(d.purchase_vat) vat,\r\n\t                        (Coalesce(sum(d.quantity* d.purchase_unit_price),0)+ Coalesce(sum(d.purchase_sd),0)+ Coalesce(sum(d.purchase_vat),0)) total  ", str1, "                        \r\n                            from trns_purchase_master m                           \r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id  \r\n                            where m.organization_id=", num1, " and m.org_branch_reg_id=", num, " \r\n                            and CAST(m.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(m.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')", str2, "\r\n                             GROUP BY DATE_TRUNC('month',m.Date_CHALLAN) ", str1, " \r\n                             order by DATE_TRUNC('month',m.Date_CHALLAN)" };
                    str = string.Concat(objArray);
                }
                else
                {
                    object[] objArray1 = new object[] { " Select * from month_name mnth      \r\n                            left join (select to_char(DATE_TRUNC('month',m.Date_CHALLAN),'MONTH') mon, \r\n\t                        sum(d.quantity* d.purchase_unit_price) price,\r\n\t                        sum(d.purchase_sd) sd,\r\n\t                        sum(d.purchase_vat) vat,\r\n\t                        (Coalesce(sum(d.quantity* d.purchase_unit_price),0)+ Coalesce(sum(d.purchase_sd),0)+ Coalesce(sum(d.purchase_vat),0)) total ", str1, "                        \r\n                            from trns_purchase_master m                           \r\n                            inner join trns_purchase_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id  \r\n                            where m.organization_id=", num1, " and m.org_branch_reg_id=", num, " ", str2, " and d.approver_stage='F'\r\n                            and CAST(m.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(m.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                             GROUP BY DATE_TRUNC('month',m.Date_CHALLAN)", str1, " \r\n                             order by DATE_TRUNC('month',m.Date_CHALLAN)) rs on rs.mon = mnth.mon" };
                    str = string.Concat(objArray1);
                }
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPurchaseDailyDetailReportData(DateTime fDate)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select date(tsm.date_challan) date_challan,tsm.date_challan challanTime,tp.party_name,tsm.challan_no,i.hs_code,i.item_name,tsd.quantity ,tsd.actual_price,tsd.actual_price*tsd.quantity price,\r\n                               tsd.purchase_vat,tsd.purchase_sd,tsm.purchase_type,iu.unit_code                              \r\n                               from trns_purchase_master tsm\r\n                               inner join trns_purchase_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               inner join item_unit iu on i.unit_id=iu.unit_id\r\n                               where tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, " and tsm.challan_type='P' and tsd.approver_stage='F'\r\n                               and CAST(tsm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tsm.date_challan as DATE) <= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPurchaseDailyReportData(DateTime fDate, DateTime tDate)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select date(tsm.date_challan) date_challan, sum(tsd.quantity) quantity,sum(tsd.actual_price*tsd.quantity) price,\r\n                               sum(tsd.vat) vat                              \r\n                               from trns_purchase_master tsm\r\n                               inner join trns_purchase_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               inner join item_unit iu on i.unit_id=iu.unit_id\r\n                               where tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, " and tsm.challan_type='P'\r\n                               and CAST(tsm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tsm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                               group by date(tsm.date_challan)\r\n                               order by date(tsm.date_challan)" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPurchasePeriodicChallanNo(DateTime fDate, DateTime tDate, int SupplierID, int ItemID, string AggrementNO, string TaxType, string PurchaseType, int regTypId, int economicId, decimal vatRate, decimal sdRate, int catId, int subcatId)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                if (fDate > DateTime.MinValue && tDate > DateTime.MinValue)
                {
                    string str = empty;
                    string[] strArrays = new string[] { str, " and CAST(tpm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tpm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
                    empty = string.Concat(strArrays);
                }
                if (SupplierID > 0)
                {
                    object obj = empty;
                    object[] supplierID = new object[] { obj, " and tpm.party_id = ", SupplierID, " " };
                    empty = string.Concat(supplierID);
                }
                if (ItemID > 0)
                {
                    object obj1 = empty;
                    object[] itemID = new object[] { obj1, " and tpd.item_id = ", ItemID, " " };
                    empty = string.Concat(itemID);
                }
                if (AggrementNO != "-1")
                {
                    empty = string.Concat(empty, " and tpm.aggrement_no = '", AggrementNO, "'");
                }
                if (PurchaseType != "-1")
                {
                    empty = string.Concat(empty, " and tpm.purchase_type = '", PurchaseType, "'");
                }
                if (TaxType != "-1")
                {
                    empty = string.Concat(empty, " and tpd.", TaxType, "> 0");
                }
                if (regTypId != 0)
                {
                    empty = string.Concat(empty, " and tp.reg_type=", regTypId);
                }
                if (economicId != 0)
                {
                    object obj2 = empty;
                    object[] objArray = new object[] { obj2, " and tp.major_area_of_ecn_activity='", economicId, "' " };
                    empty = string.Concat(objArray);
                }
                if (vatRate != new decimal(0))
                {
                    empty = string.Concat(empty, " and tpd.vat_rate=", vatRate);
                }
                if (sdRate != new decimal(0))
                {
                    empty = string.Concat(empty, " and tpd.sd_rate=", sdRate);
                }
                if (catId != 0)
                {
                    empty = string.Concat(empty, " and ic.parent_id=", catId);
                }
                if (subcatId != 0)
                {
                    empty = string.Concat(empty, " and ic.category_id=", subcatId);
                }
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray1 = new object[] { "select distinct tpm.challan_id, tpm.challan_no\r\n                                from trns_purchase_master tpm\r\n                                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                inner join item i on tpd.item_id = i.item_id\r\n                                inner join item_category ic on ic.category_id = i.sub_category_id and ic.parent_id!=0\r\n                                where  tpm.organization_id=", num1, "  and TPM.is_trns_accepted=true and  tpm.org_branch_reg_id=", num, " AND tpm.is_deleted = false  and tpd.approver_stage='F' and tpm.purchase_type != 'F' ", empty, " order by tpm.challan_id" };
                string str1 = string.Concat(objArray1);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPurchasePeriodicChallanNoanddetails(DateTime fDate, DateTime tDate, int Client_vendor_id, int Client_challan_id, int Client_item_id, string client_purchase_type)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                if (fDate > DateTime.MinValue && tDate > DateTime.MinValue)
                {
                    string str = empty;
                    string[] strArrays = new string[] { str, " and CAST(tpm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tpm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
                    empty = string.Concat(strArrays);
                }
                if (Client_item_id > 0)
                {
                    object obj = empty;
                    object[] clientItemId = new object[] { obj, " and tpd.item_id = ", Client_item_id, " " };
                    empty = string.Concat(clientItemId);
                }
                if (Client_vendor_id > 0)
                {
                    object obj1 = empty;
                    object[] clientVendorId = new object[] { obj1, " and tpm.party_id = ", Client_vendor_id, " " };
                    empty = string.Concat(clientVendorId);
                }
                if (client_purchase_type != "-1")
                {
                    empty = string.Concat(empty, " and tpm.purchase_type = '", client_purchase_type, "'");
                }
                if (Client_challan_id > 0)
                {
                    object obj2 = empty;
                    object[] clientChallanId = new object[] { obj2, " and tpm.challan_id = '", Client_challan_id, "'" };
                    empty = string.Concat(clientChallanId);
                }
                Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str1 = string.Concat("select tpm.challan_id, tpm.date_challan, tpm.challan_no,tp.party_name,i.item_name,i.item_sku,tpd.available_qnt,tpd.purchase_unit_price,tpd.purchase_vat,tpd.purchase_sd,tpd.vds_amount,tpd.ait,tpd.total_price\r\n                                from trns_purchase_master tpm\r\n                                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                inner join item i on tpd.item_id = i.item_id\r\n                                inner join item_category ic on ic.category_id = i.sub_category_id and ic.parent_id!=0\r\n                                where  TPM.is_trns_accepted=true and tpm.is_deleted = false and tpm.purchase_type != 'F' ", empty, " order by tpm.challan_id");
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetPurchasePeriodicReportData(long CID, int ItemID, string TaxType)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            if (ItemID > 0)
            {
                object obj = empty;
                object[] itemID = new object[] { obj, " and tpd.item_id = ", ItemID, " " };
                empty = string.Concat(itemID);
            }
            if (TaxType != "-1")
            {
                empty = string.Concat(empty, " and tpd.", TaxType, "> 0");
            }
            try
            {
                object[] cID = new object[] { "select case when tpm.purchase_type ='I' then to_char(tpm.bl_date, 'dd-MON-yyyy') else  to_char(tpm.ref_challan_date, 'dd-MON-yyyy') end date_challan, TO_CHAR(tpm.date_challan,'dd-MON-yyyy') vouchar_date, tp.party_id supplier_id,tp.party_name supplier_name,tpd.unit_id,iu.unit_code unit_name,\r\n                                   tpm.challan_no,tpd.item_id\r\n                                    --,i.item_name\r\n\r\n                                    ,(i.item_name \r\n\t\t\t\t                    || ' ' || (CASE WHEN tpd.property_id1 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t\t                    inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t\t                    inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t\t                    where a.property_id1=tpd.property_id1 and a.challan_id = ", CID, " LIMIT 1) ELSE '' END)\r\n\t\t\t\t                    || ' ' ||\r\n\t\t\t\t                    (CASE WHEN tpd.property_id2 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t\t                    inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t\t                    inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t\t                    where a.property_id2=tpd.property_id2 and a.challan_id = ", CID, " LIMIT 1) ELSE '' END)\r\n\t\t\t\t                    || ' ' ||\r\n\t\t\t\t                    (CASE WHEN tpd.property_id3 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t\t                    inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t\t                    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t                    where a.property_id3=tpd.property_id3 and a.challan_id = ", CID, " LIMIT 1) ELSE '' END)\r\n\t\t\t\t                    || ' ' ||\r\n\t\t\t\t                    (CASE WHEN tpd.property_id4 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t\t                    inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t\t                    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t                    where a.property_id4=tpd.property_id4 and a.challan_id = ", CID, " LIMIT 1) ELSE '' END)\r\n\t\t\t\t                    || ' ' ||\r\n\t\t\t\t                    (CASE WHEN tpd.property_id5 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\t\t                    inner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\t\t                    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t                    where a.property_id5=tpd.property_id5 and a.challan_id = ", CID, " LIMIT 1) ELSE '' END)\r\n\t\t\t\t                    ) AS item_name, (i.item_sku) as item_sku /*zahid1 09-08-22*/\r\n\r\n                                  ,tpm.challan_id,tpd.assesment_amount ,tpd.quantity,tpd.purchase_unit_price unit_price,CAST((tpd.quantity*tpd.purchase_unit_price) as double precision) as value,\r\n                                   (select sum(CAST(((m.quantity*m.purchase_unit_price)+m.sd+m.vat) as double precision)) from trns_purchase_detail m where m.challan_id = ", CID, ")  total,\r\n                                   tpd.purchase_vat vat, tpd.purchase_sd sd, tpd.ait, tpd.vds_amount vds, tpd.cd, tpd.rd, tpd.at\r\n                                   ,case when (tpm.payment_method='' or tpm.payment_method='0' or tpm.payment_method is null ) then 'Not applicable'\r\n\t\t\t\t\t\t           else tpm.payment_method end payment\r\n                                   \r\n                                   from trns_purchase_master tpm\r\n                                   inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                   inner join trns_party tp on tpm.party_id = tp.party_id\r\n                                   inner join item i on tpd.item_id = i.item_id\r\n                                   inner join item_unit iu on tpd.unit_id=iu.unit_id\r\n                                   left join set_payment_method  spm on CAST(tpm.payment_method as int)=spm.payment_method_id\r\n                                   where tpm.challan_id = ", CID, empty, " and tpm.challan_type='P'" };
                string str = string.Concat(cID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSaleComparativeReportData(DateTime fDate, DateTime tDate, string month, int itemId)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            string str = "";
            string str1 = "";
            string str2 = "";
            if (itemId != -99 && itemId != 0)
            {
                str1 = ",i.item_name,i.hs_code";
                str2 = string.Concat(" and i.item_id=", itemId);
            }
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                if (month != "-99")
                {
                    object[] objArray = new object[] { " select to_char(DATE_TRUNC('month',m.Date_CHALLAN),'MONTH') mon, \r\n\t                        sum(d.quantity* d.actual_price) price,\r\n\t                        sum(d.sd) sd,\r\n\t                        sum(d.vat) vat,\r\n\t                        (Coalesce(sum(d.quantity* d.actual_price),0)+ Coalesce(sum(d.sd),0)+ Coalesce(sum(d.vat),0)) total   ", str1, "                       \r\n                            from trns_sale_master m                           \r\n                            inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id  \r\n                            where m.organization_id=", num1, " and m.org_branch_reg_id=", num, " \r\n                            and CAST(m.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(m.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') ", str2, "\r\n                             GROUP BY DATE_TRUNC('month',m.Date_CHALLAN) ", str1, " \r\n                             order by DATE_TRUNC('month',m.Date_CHALLAN)" };
                    str = string.Concat(objArray);
                }
                else
                {
                    object[] objArray1 = new object[] { " Select * from month_name mnth      \r\n                            left join ( select to_char(DATE_TRUNC('month',m.Date_CHALLAN),'MONTH') mon, \r\n\t                        sum(d.quantity* d.actual_price) price,\r\n\t                        sum(d.sd) sd,\r\n\t                        sum(d.vat) vat,\r\n\t                        (Coalesce(sum(d.quantity* d.actual_price),0)+ Coalesce(sum(d.sd),0)+ Coalesce(sum(d.vat),0)) total  ", str1, "                        \r\n                            from trns_sale_master m                           \r\n                            inner join trns_sale_detail d on d.Challan_id = m.Challan_id\r\n                            inner join Item i on i.item_id = d.item_id  \r\n                            where m.organization_id=", num1, " and m.org_branch_reg_id=", num, "  and d.approver_stage='F'\r\n                            and CAST(m.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(m.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') ", str2, "\r\n                             GROUP BY DATE_TRUNC('month',m.Date_CHALLAN)", str1, " \r\n                             order by DATE_TRUNC('month',m.Date_CHALLAN)) rs on rs.mon = mnth.mon" };
                    str = string.Concat(objArray1);
                }
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSalesDailyDetailReportData(DateTime fDate)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select date(tsm.date_challan) date_challan,tsm.date_challan challanTime,tp.party_name,tsm.challan_no,i.hs_code,i.item_name,  case when installment_status=false then  tsd.quantity else 0 end quantity,tsd.actual_price,tsd.actual_price*tsd.quantity price,\r\n                               tsd.vat,tsd.sd, iu.unit_code,tsm.trans_type                             \r\n                               from trns_sale_master tsm\r\n                               inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               inner join item_unit iu on i.unit_id=iu.unit_id\r\n                               where tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, "  and tsd.approver_stage='F'\r\n                               and CAST(tsm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tsm.date_challan as DATE) <= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSalesDailyReportData(DateTime fDate, DateTime tDate)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select date(tsm.date_challan) date_challan,  \r\n                               --case when installment_status=false then  sum(tsd.quantity) else 0 end quantity,\r\n                               sum(tsd.actual_price*tsd.quantity) price,\r\n                               sum(tsd.vat) vat                              \r\n                               from trns_sale_master tsm\r\n                               inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               inner join item_unit iu on i.unit_id=iu.unit_id\r\n                               where tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, " \r\n                               and CAST(tsm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tsm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')\r\n                               group by date(tsm.date_challan)\r\n                               --,installment_status\r\n                               order by date(tsm.date_challan)" };
                string str1 = string.Concat(str);
                dataTable = this.db.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSalesMonthlyDetailReportData(DateTime fDate, DateTime tDate, int itemId)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            string str = "";
            string str1 = "";
            if (itemId != -99 && itemId != 0)
            {
                str = ",i.item_name,i.hs_code";
                str1 = string.Concat(" and i.item_id=", itemId);
            }
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select date(tsm.date_challan) date_challan,tsm.date_challan challanTime,tp.party_name,tsm.challan_no,i.hs_code,i.item_name,  case when installment_status=false then  tsd.quantity else 0 end quantity,tsd.actual_price,tsd.actual_price*tsd.quantity price,\r\n                               tsd.vat,tsd.sd, iu.unit_code,tsm.trans_type    ", str, "                         \r\n                               from trns_sale_master tsm\r\n                               inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               inner join item_unit iu on i.unit_id=iu.unit_id\r\n                               where tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, "  and tsd.approver_stage='F'", str1, "\r\n                               and CAST(tsm.date_challan as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(tsm.date_challan as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') ORDER BY tsm.date_challan" };
                string str2 = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str2);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSalesPeriodicChallanNo(DateTime fDate, DateTime tDate, int SupplierID, int ItemID, string AggrementNO, int regTypId, int economicId, decimal sdRate, decimal vatRate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                if (fDate > DateTime.MinValue && tDate > DateTime.MinValue)
                {
                    object obj = empty;
                    object[] objArray = new object[] { obj, " and tsm.date_challan >= to_date('", fDate, "','dd/MM/yyyy') and tsm.date_challan <= to_date('", tDate, "','dd/MM/yyyy')" };
                    empty = string.Concat(objArray);
                }
                if (SupplierID > 0)
                {
                    object obj1 = empty;
                    object[] supplierID = new object[] { obj1, " and tsm.party_id = ", SupplierID, " " };
                    empty = string.Concat(supplierID);
                }
                if (ItemID > 0)
                {
                    object obj2 = empty;
                    object[] itemID = new object[] { obj2, " and tsd.item_id = ", ItemID, " " };
                    empty = string.Concat(itemID);
                }
                if (AggrementNO != "-1")
                {
                    empty = string.Concat(empty, " and tsm.aggrement_no = '", AggrementNO, "'");
                }
                if (regTypId != 0)
                {
                    empty = string.Concat(empty, " and tp.reg_type=", regTypId);
                }
                if (economicId != 0)
                {
                    object obj3 = empty;
                    object[] objArray1 = new object[] { obj3, " and tp.major_area_of_ecn_activity='", economicId, "' " };
                    empty = string.Concat(objArray1);
                }
                if (vatRate != new decimal(0))
                {
                    empty = string.Concat(empty, " and tsd.vat_rate=", vatRate);
                }
                if (sdRate != new decimal(0))
                {
                    object obj4 = empty;
                    object[] objArray2 = new object[] { obj4, " and itv.tax_value=", sdRate, " AND itv.is_tran_sale=true" };
                    empty = string.Concat(objArray2);
                }
                object[] objArray3 = new object[] { "select distinct tsm.challan_id, tsm.challan_no\r\n                                from trns_sale_master tsm\r\n                                inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                                inner join trns_party tp on tsm.party_id = tp.party_id\r\n                                inner join item i on tsd.item_id = i.item_id\r\n                                 inner join item_tax_values itv on itv.item_id = i.item_id\r\n                                where tsm.organization_id=", num, "  AND tsm.is_deleted = false ", empty, " order by tsm.challan_id" };
                string str = string.Concat(objArray3);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSalesPeriodicReportData(long CID, int ItemID)
        {
            string empty = string.Empty;
            DataTable dataTable = new DataTable();
            if (ItemID > 0)
            {
                object obj = empty;
                object[] itemID = new object[] { obj, " and tsd.item_id = ", ItemID, " " };
                empty = string.Concat(itemID);
            }
            try
            {
                object[] cID = new object[] { "select TO_CHAR(tsm.date_challan,'dd-MON-yyyy') vouchar_date, tp.party_id supplier_id,tp.party_name supplier_name,\r\n                         tsm.challan_no,tsd.item_id\r\n                         --,i.item_name,\r\n\r\n                       ,(i.item_name \r\n\t\t\t\t\t    || ' ' || (CASE WHEN tsd.property_id1 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t\t\t    where a.property_id1=tsd.property_id1 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id2 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t\t\t    where a.property_id2=tsd.property_id2 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id3 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t\t    where a.property_id3=tsd.property_id3 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id4 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t\t    where a.property_id4=tsd.property_id4 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    || ' ' ||\r\n\t\t\t\t\t    (CASE WHEN tsd.property_id5 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t\t\t    inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t\t\t    inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t\t\t    where a.property_id5=tsd.property_id5 and b.challan_id = ", CID, " limit 1) ELSE '' END)\r\n\t\t\t\t\t    ) AS item_name,(i.item_sku) as item_sku /*zahid 09-08-22*/\r\n\r\n                               ,case when installment_status=false then  tsd.quantity else 0 end quantity,tsd.actual_price unit_price,tsd.is_fixed_vat,\r\n                               tsd.vat,tsd.vat_rate,tsd.sd,tsm.aggrement_no,\r\n                               case when tsd.sd>0\r\n\t\t\t\t\t            then(select tax_value from item_tax_values where tax_id=3 and is_deleted=false and is_tran_sale=true and item_id=tsd.item_id)\r\n\t\t\t\t\t            else 0 end sd_rate, \r\n                               --CAST((tsd.quantity*tsd.actual_price+tsd.sd+tsd.vat) as double precision) as value,\r\n                               CAST((tsd.quantity*tsd.actual_price) as double precision) as value,\r\n                               (select sum(CAST((m.quantity*m.actual_price+m.sd+m.vat) as double precision)) from trns_sale_detail m where m.challan_id = ", CID, ")  total,iu.unit_code,tsd.additional_property\r\n                               from trns_sale_master tsm\r\n                               inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                               inner join trns_party tp on tsm.party_id = tp.party_id\r\n                               inner join item i on tsd.item_id = i.item_id\r\n                               inner join item_unit iu on i.unit_id=iu.unit_id\r\n                               where tsm.challan_id = ", CID, empty };
                string str = string.Concat(cID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }
    }
}