using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PriceDeclaretionBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public PriceDeclaretionBLL()
        {
        }

        public DataTable findRowProducts(string priceDeclerationNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select pri.*,i.category_id from price_raw_item as pri\r\n                            join price_item as pi on pi.price_id=pri.price_id \r\n                            join Item as i on i.Item_id= pri.Item_id\r\n                            join item_category as ic on ic.category_id=i.category_id\r\n                            where pi.price_declaration_no='", priceDeclerationNo, "'");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable geAdditionalPropertybyItemwithDate(long itemId, DateTime fDate, DateTime tDate, string branchIds)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where status in('I','L','F') and item_id=", itemId, "\r\n                 and organization_id=", num, " and org_branch_id in(", branchIds, ") and CAST(date_challan AS DATE) >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(date_challan AS DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                    \r\n                    \t " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }
        public DataTable geAdditionalPropertybySaleChallanIDAfterCreditNote(long itemId, int saleId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where (sale_id=", saleId,") and item_id=", itemId, " and organization_id=", num, " order by additional_info_id " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybyAgreement(int itemId, string agreementNo)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where  item_id=", itemId, " and organization_id=", num1, " and org_branch_id=", num, " " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybyItemID(int itemId, string status)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where status='", status, "' and item_id=", itemId, " and organization_id=", num1, " and org_branch_id=", num, " " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybyItemwithDate(int itemId, DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where status in('I','L','F') and item_id=", itemId, "\r\n                 and organization_id=", num1, " and org_branch_id=", num, " and CAST(date_challan AS DATE) >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND CAST(date_challan AS DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n                    \r\n                    \t " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybyPurchaseChallanID(int challanId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where  purchase_challan_id=", challanId, " and organization_id=", num1, " and org_branch_id=", num, " " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybySaleChallanID(int itemId, int saleId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where sale_id=", saleId, " and item_id=", itemId, " and organization_id=", num1, " and org_branch_id=", num, " " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybySaleID(int saleId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where sale_id=", saleId, "  and organization_id=", num1, " and org_branch_id=", num, " " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybySaleInformation(int challanId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select ((tsd.quantity*tsd.actual_price)+tsd.vat+tsd.sd)valuecons,(tsd.quantity*tsd.actual_price) pricevalue,case when is_source_tax_deduct=true then tsd.vat else 0 end vds,\r\n                                iu.unit_code,tsm.challan_no,tsd.quantity,tsd.vat,tsd.sd,tsd.actual_price,tpra.property_id1_value,tpra.property_id2_value,tpra.property_id1,tpra.property_id2,i.item_name, to_char(tsm.date_challan,'dd/MM/yyyy') date_challan,tp.party_name,\r\n                                case when tpra.sale_id is null then '-' else 'sold' end status,\r\n                                case when (tsm.payment_method='' or tsm.payment_method='0' or tsm.payment_method is null ) then 'Not applicable' else tsm.payment_method end payment\r\n                                from trns_production_rcv_additional tpra\r\n                                left join trns_sale_detail tsd on tsd.challan_id= tpra.sale_id \r\n                                left join trns_sale_master tsm on tsd.challan_id = tsm.challan_id\r\n                                left join item_unit iu on iu.unit_id= tsd.unit_id\r\n                                left join item i on i.item_id= tsd.item_id\r\n                                left join trns_party tp on tp.party_id= tsm.party_id\r\n                                left join set_payment_method  spm on CAST(tsm.payment_method as int)=spm.payment_method_id\r\n                                where tpra.purchase_challan_id =", challanId, " and tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, " " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable geAdditionalPropertybySearch(string searchName, int itemId, string type, int transferId, int saleId, int purchaseId)
        {
            string str = "";
            if (itemId != 0)
            {
                str = string.Concat(str, "and item_id = ", itemId);
            }
            if (type != "")
            {
                str = string.Concat(str, " and status='", type, "'");
            }
            if (transferId != 0)
            {
                str = string.Concat(str, " and receive_id = ", transferId);
            }
            if (saleId != 0)
            {
                str = string.Concat(str, " and sale_id = ", saleId);
            }
            if (purchaseId != 0)
            {
                str = string.Concat(str, " and purchase_challan_id = ", purchaseId);
            }
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional\r\n                                   where (upper(property_id1_value) LIKE '%", searchName, "%' or upper(property_id2_value) LIKE '%", searchName, "%' or upper(property_id3_value) LIKE '%", searchName, "%' or upper(property_id4_value) LIKE '%", searchName, "%' or upper(property_id5_value) LIKE '%", searchName, "%' ) and organization_id=", num1, " and org_branch_id=", num, " ", str, " " };
            string str1 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable geAdditionalPropertybytransferID(int itemId, string status, int challanId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select * from trns_production_rcv_additional where receive_id=", challanId, " and status='", status, "' and item_id=", itemId, " and organization_id=", num1, " and org_branch_id=", num, " " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable get_priceitemForMasterData(int price_id)
        {
            string str = string.Concat("select * from price_item WHERE price_id = ", price_id, " AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable get1stAddition(int price_id)
        {
            string str = string.Concat("select SUM(item_value) item_value,Coalesce(SUM(value_addtn_pct),0) value_addtn_pct from price_value_addition_area WHERE price_id = ", price_id, " AND value_adtn_item_m = 8");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable get2ndAddition(int price_id)
        {
            string str = string.Concat("select SUM(item_value) item_value from price_value_addition_area WHERE price_id = ", price_id, " AND value_adtn_item_m = 14");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getAllItems()
        {
            return this.DBUtil.GetDataTable("select\r\n                        i.item_id, i.item_name, i.hs_code,\r\n                        ic.category_id, ic.category_name,\r\n                        iu.unit_id, iu.unit_name\r\n                        from item i\r\n                        inner join item_category ic on ic.category_id = i.sub_category_id\r\n                        inner join item_unit iu on iu.unit_id = i.unit_id\r\n                        where i.is_deleted = false and i.item_type = 'I' and i.product_type = 'R'\r\n                        order by i.item_name");
        }

        public DataSet getAllNBRValueAdditionArea(int intPriceId)
        {
            string str = string.Concat("select price_id,row_no,value_adtn_item_m, value_adtn_item_d, acd.code_name, item_value,cnfrmd_item_value \r\nfrom price_value_addition_area pvaa \r\nleft outer join app_code_detail acd on pvaa.value_adtn_item_d  =acd.code_id_d and acd.code_id_m=8\r\nwhere price_id='", intPriceId, "' and pvaa.Is_deleted=false ");
            return this.DBUtil.GetDataSet(str, "tblGetAllNBRValueAdditionArea");
        }

        public DataSet getAllPriceDeclaration()
        {
            return this.DBUtil.GetDataSet("select price_id, pi.Organization_id,ori.organization_name,price_declaration_no,price_declaration_year,pi.Item_id,i.item_name,i.hs_code,wholesale_prc_sd_vat,cg_declaration_no,\r\ncg_declaration_no||'/'||i.hs_code||'/'||price_declaration_year CGNO \r\nfrom price_item pi left outer join\r\norg_registration_info ori on ori.Organization_id= pi.Organization_id inner join\r\nItem i on i.Item_id=pi.Item_id where pi.Is_deleted=false", "tblGetAllPriceDeclaration");
        }

        public DataSet getAllPriceDeclarationBySearch(int item_id)
        {
            string str = string.Concat("select price_declaration_no, to_char(date_effective, 'dd/MM/yyyy') date_effective, price_id, pi.Organization_id,price_declaration_year,pi.Item_id,\r\n                        i.item_name,ic.category_name,i.hs_code,coalesce(wholesale_prc_sd_vat,0) wholesale_prc_sd_vat ,coalesce(retail_prc_sd_vat,0) retail_prc_sd_vat,cg_declaration_no\r\n                        from price_item pi left outer join\r\n                        org_registration_info ori on ori.Organization_id= pi.Organization_id inner join\r\n                        Item i on i.Item_id=pi.Item_id \r\n                        join item_category ic on ic.category_id=i.sub_category_id\r\n                        where pi.Is_deleted=false and i.item_id='", item_id, "' and pi.price_declaration_no!='No' order by pi.Date_insert desc");
            return this.DBUtil.GetDataSet(str, "tblGetAllPriceDeclaration");
        }

        public DataSet getAllPriceDeclarationByType(int intType)
        {
            string str = string.Concat("select price_declaration_no, to_char(date_effective, 'dd/MM/yyyy') date_effective, price_id, pi.Organization_id,price_declaration_year,pi.Item_id,\r\n                        i.item_name,ic.category_name,i.hs_code,coalesce(wholesale_prc_sd_vat,0) wholesale_prc_sd_vat ,coalesce(retail_prc_sd_vat,0) retail_prc_sd_vat,cg_declaration_no\r\n                        from price_item pi left outer join\r\n                        org_registration_info ori on ori.Organization_id= pi.Organization_id inner join\r\n                        Item i on i.Item_id=pi.Item_id \r\n                        join item_category ic on ic.category_id=i.sub_category_id\r\n                        where pi.Is_deleted=false and Type='", intType, "' order by pi.Date_insert desc");
            return this.DBUtil.GetDataSet(str, "tblGetAllPriceDeclaration");
        }

        public DataTable getAllRawItem()
        {
            return this.DBUtil.GetDataTable("select Item_id,item_name||'--'||hs_code item_name from Item where Is_deleted=false AND item_type = 'I' AND product_type = 'R' order by item_name");
        }

        public DataSet getAllUnauthorizedPriceDeclarationNo()
        {
            return this.DBUtil.GetDataSet("Select price_id,price_declaration_no from price_item where Is_deleted=false and is_nbr_confirmed=false order by price_declaration_no", "PDNO");
        }

        public DataSet getAllUnauthorizedPriceDeclarationNoByType(int intType)
        {
            string str = string.Concat("Select price_id,price_declaration_no from price_item where Is_deleted=false and is_nbr_confirmed=false and Type='", intType, "' order by price_declaration_no");
            return this.DBUtil.GetDataSet(str, "PDNO");
        }

        public DataTable getAllUnits()
        {
            return this.DBUtil.GetDataTable("select unit_id, unit_name, unit_code, measurement_id_m, measurement_id_d\r\n                        from item_unit where is_deleted = false");
        }

        public DataSet getAllValueAdditionArea()
        {
            return this.DBUtil.GetDataSet("select code_id_d,code_name,vStatus from principal_value_addition_detail where Is_deleted='false' and code_id_m=8 order by code_id_d", "tblGetAllValueAdditionArea");
        }

        public DataSet getAllValueAdditionAreaForLoad()
        {
            return this.DBUtil.GetDataSet("select code_id_d,code_name,vStatus from principal_value_addition_detail where Is_deleted='false' and code_id_m=8 order by code_id_d", "tblGetAllValueAdditionArea");
        }

        public DataSet getAllValueAdditionAreaForSetup()
        {
            return this.DBUtil.GetDataSet("select code_id_d,code_name from app_code_detail where Is_deleted='false' and code_id_m=8 order by code_id_d", "tblGetAllValueAdditionArea");
        }

        public DataSet getAllValueAdditionNotItemArea()
        {
            return this.DBUtil.GetDataSet("select code_id_d,code_name,vStatus from principal_value_addition_detail where Is_deleted='false' and code_id_m=14 order by code_id_d", "tblGetAllValueAdditionArea");
        }

        public DataSet getAllValueAdditionNotItemAreaForLoad()
        {
            return this.DBUtil.GetDataSet("select code_id_d,code_name,vStatus from principal_value_addition_detail where Is_deleted='false' and code_id_m=14 order by code_id_d", "tblGetAllValueAdditionArea");
        }

        public DataSet getAllValueAdditionNotItemAreaForSetUp()
        {
            return this.DBUtil.GetDataSet("select code_id_d,code_name from app_code_detail where Is_deleted='false' and code_id_m=14 order by code_id_d", "tblGetAllValueAdditionArea");
        }

        public DataTable GetCategoryWithItem(int item_id)
        {
            DataTable dataTable = new DataTable();
            string str = string.Concat("select IC.category_id,IC.category_name,IC.parent_id,IC.category_level,I.item_id,I.sub_category_id,I.item_name from item_category AS IC\r\n            LEFT JOIN item AS I\r\n            ON IC.category_id = I.sub_category_id\r\n            WHERE  IC.is_deleted = false AND I.is_deleted = false AND item_id = ", item_id);
            DataTable dataTable1 = this.DBUtil.GetDataTable(str);
            if (dataTable1 != null && dataTable1.Rows.Count > 0)
            {
                string str1 = dataTable1.Rows[0]["parent_id"].ToString();
                string str2 = string.Concat("select * from item_category where category_id = ", Convert.ToInt16(str1), " AND category_level = 1 AND is_deleted = false");
                dataTable = this.DBUtil.GetDataTable(str2);
            }
            return dataTable;
        }

        public int GetChallanId(string challanNo)
        {
            int num = 0;
            try
            {
                object singleValue = this.DBUtil.GetSingleValue(string.Concat("select challan_id from trns_purchase_master where challan_no='", challanNo, "'"));
                num = Convert.ToInt32(singleValue);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return num;
        }

        public DataTable getGrossTotal(int price_id)
        {
            string str = string.Concat("select SUM(quantity_total) quantity_total  from price_raw_item WHERE price_id = ", price_id, " AND is_deleted = false ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getHealthChargebyItemID(int itemId)
        {
            string str = string.Concat("select health_surcharge from item_tax_values where Is_deleted=false and item_id=", itemId, " and health_surcharge!=0 ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable gethsCodebyItemID(int itemId)
        {
            string str = string.Concat("select hs_code from item where Is_deleted=false and item_id=", itemId, "  ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getItemDetail(int intItemId)
        {
            object[] objArray = new object[] { "select Item_id, item_name,hs_code, sum(Sd)Sd, sum(Vat)Vat from (\r\nselect i.*,itv.tax_value SD,0 VAT from Item i inner join item_tax_values itv on itv.Item_id= i.Item_id and (itv.tax_id='", (short)3, "')\r\n                        where itv.is_current = true and i.Is_deleted='false' and itv.is_tran_sale=true and i.Item_id='", intItemId, "'\r\nunion all\r\n\r\nselect i.*,0 SD, itv.tax_value VAT from Item i inner join item_tax_values itv on itv.Item_id= i.Item_id and (itv.tax_id='", (short)4, "')\r\n                        where itv.is_current = true and i.Is_deleted='false' and itv.is_tran_sale=true and i.Item_id='", intItemId, "') d group by Item_id,Item_name,hs_code" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "itemDetail");
        }

        public DataTable getItemPrice(string strDeclarationType)
        {
            return this.DBUtil.GetDataTable("select price_id,pi.Item_id, i.item_name||' - ' || i.hs_code || '-' || price_declaration_no  item_name,\r\nprice_declaration_no||'/'|| price_declaration_year price_declaration_number\r\nfrom price_item pi inner join Item i on pi.Item_id=i.Item_id\r\nwhere pi.Is_deleted=false and is_nbr_confirmed=false AND upper(price_declaration_no) <> 'NO' order by i.item_name,pi.Date_insert desc");
        }

        public DataTable getItemPriceNumber(int intPriceId)
        {
            string str = string.Concat("select price_declaration_no||'/'|| price_declaration_year price_declaration_number,price_declaration_year as year,price_declaration_no\r\nfrom price_item pi  where pi.Is_deleted=false and is_nbr_confirmed=false and price_id='", intPriceId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getItemPriceWithDate(string strDeclarationType)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select price_id,pi.Item_id, i.item_name||' - ' || i.hs_code || '-' || price_declaration_no || '-' || to_char(date_effective,'dd-MON-yyyy') item_name,\r\n        price_declaration_no||'/'|| price_declaration_year price_declaration_number\r\n        from price_item pi inner join Item i on pi.Item_id=i.Item_id\r\n        where pi.Is_deleted=false and is_nbr_confirmed=false AND upper(price_declaration_no) <> 'NO' and pi.organization_id=", num, " order by i.item_name,pi.Date_insert desc");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getItemPriceWithDateFilter(string strDeclarationType, DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] str = new object[] { "select price_id,pi.Item_id, i.item_name||' - ' || i.hs_code || '-' || price_declaration_no || '-' || to_char(date_effective,'dd-MON-yyyy') item_name,date_effective,\r\n        price_declaration_no||'/'|| price_declaration_year price_declaration_number\r\n        from price_item pi inner join Item i on pi.Item_id=i.Item_id\r\n        where pi.Is_deleted=false and is_nbr_confirmed=false AND upper(price_declaration_no) <> 'NO' and pi.organization_id=", num, " and CAST(date_effective as DATE) >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') and CAST(date_effective as DATE) <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')order by i.item_name,pi.Date_insert desc" };
            string str1 = string.Concat(str);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataSet getItemVatSdDetail(int intItemId)
        {
            object[] objArray = new object[] { "select Item_id, item_name,hs_code, sum(Sd)Sd, sum(Vat)Vat,PER from (\r\n        select i.*,itv.tax_value SD,0 VAT,itv.PER from Item i inner join item_tax_values itv on itv.Item_id= i.Item_id and (itv.tax_id='", (short)3, "')\r\n                                where itv.is_current = true and i.Is_deleted='false' and itv.is_tran_sale=true and i.Item_id='", intItemId, "'\r\n        union all\r\n\r\n        select i.*,0 SD, itv.tax_value VAT,itv.PER from Item i inner join item_tax_values itv on itv.Item_id= i.Item_id and (itv.tax_id='", (short)4, "')\r\n                        where itv.is_current = true and i.Is_deleted='false' and itv.is_tran_sale=true and i.Item_id='", intItemId, "'\r\n                        union all\r\n\r\n       select i.*,0 SD, V.tax_value VAT,V.PER from Item i inner join item_tax_values V on V.Item_id= i.Item_id and (V.tax_id='99')\r\n\t\t       \r\n\t\t        WHERE V.ITEM_ID = '", intItemId, "' AND V.TAX_ID = 99  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE AND V.PER='1'\r\n\t\t        GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE ,i.item_id\r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM \r\n\t\t        ITEM_TAX_VALUES \r\n\t\t        WHERE ITEM_ID = '", intItemId, "' AND TAX_ID = 99  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_sale=true)   ) d \r\n                       group by Item_id,Item_name,hs_code,PER" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "itemDetail");
        }

        public DataTable getNitUse(int price_id)
        {
            string str = string.Concat("select SUM(Quantity) Quantity from price_raw_item WHERE price_id = ", price_id, " AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getprice_raw_item_ForCostSheet(int price_id, string reference)
        {
            string str = "";
            str = (reference != "-99" ? string.Concat("select distinct PR.row_no,PR.price_id,PR.item_id,I.item_name,PR.unit_id,PR.quantity_total,U.unit_code,PR.wastageparcent,PR.wastage_quantity,PR.Quantity,\r\n                            PR.challanprice,PR.challan_quantity,PR.productionquantity,\r\n                            PR.txtquantityprice,PR.reference,PM.purchase_type,coalesce(PD.purchase_unit_price,0) purchase_unit_price,coalesce(PD.cd,0) cd,coalesce(PD.rd,0) rd,coalesce(PD.other_cost,0) other_cost\r\n                            from price_raw_item AS PR\r\n                            inner JOIN item AS I ON PR.item_id = I.item_id\r\n                            inner JOIN item_unit AS U ON PR.unit_id = U.unit_id\r\n\t\t\t                inner JOIN trns_purchase_detail PD on PD.item_id=PR.item_id and PD.challan_id=cast(PR.reference as numeric)\r\n\t\t\t                inner JOIN trns_purchase_master PM on PM.challan_id = PD.challan_id\r\n                            WHERE PR.price_id = ", price_id, "  AND PR.set_status!='P' order by PR.row_no") : string.Concat("select distinct PR.price_id,PR.item_id,I.item_name,PR.unit_id,PR.quantity_total,U.unit_code,PR.wastageparcent,PR.wastage_quantity,PR.Quantity,\r\n                                PR.challanprice,PR.challan_quantity,PR.productionquantity,\r\n                                PR.txtquantityprice,PR.reference,PM.purchase_type,coalesce(PD.purchase_unit_price,0) purchase_unit_price,coalesce(PD.cd,0) cd,coalesce(PD.rd,0) rd,coalesce(PD.other_cost,0) other_cost from price_raw_item AS PR\r\n                                LEFT JOIN item AS I ON PR.item_id = I.item_id\r\n                                LEFT JOIN item_unit AS U ON PR.unit_id = U.unit_id\r\n                                LEFT JOIN trns_purchase_detail PD on PD.item_id=PR.item_id\r\n                                LEFT JOIN trns_purchase_master PM on PM.challan_id = PD.challan_id\r\n                                WHERE PR.price_id = ", price_id, "  AND PR.set_status!='P'"));
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getprice_raw_item_ForCostSheet_Import(int itemId, int challanId)
        {
            return this.DBUtil.GetDataTable("select pd.cd,pd.rd,pd.other_cost,pd.document_processing_fee \r\n                         from trns_purchase_master pm\r\n                         inner join trns_purchase_detail pd on pm.challan_id=pm.challan_id\r\n                         where pd.item_id=33 and pm.challan_id=80 and pd.challan_id=80");
        }

        public DataSet getPriceByDeclarationId(int intPriceID)
        {
            object[] objArray = new object[] { "select price_id, price_declaration_no,sum(prpsd_actl_prc)prpsd_actl_prc,sum(cnfrmd_actl_prc_sd)cnfrmd_actl_prc_sd,sum(cnfrmd_sd_amount)cnfrmd_sd_amount,\r\nsum(cnfrmd_actl_prc_vat)cnfrmd_actl_prc_vat,sum(cnfrmd_wholesale_prc)cnfrmd_wholesale_prc,sum(cnfrmd_retail_prc)cnfrmd_retail_prc,\r\n\r\nsum(item_value)item_value,  sum(prpsd_actl_prc)-sum(item_value) actual_price from (\r\n\r\nSelect price_id,price_declaration_no,prpsd_actl_prc,cnfrmd_actl_prc_sd,cnfrmd_sd_amount,cnfrmd_actl_prc_vat,cnfrmd_wholesale_prc,cnfrmd_retail_prc , 0 item_value\r\nfrom price_item \r\nwhere Is_deleted=false and is_nbr_confirmed=false and price_id='", intPriceID, "' \r\nunion all\r\nselect pvaa.price_id, pi.price_declaration_no,0 prpsd_actl_prc,0 cnfrmd_actl_prc_sd, 0 cnfrmd_sd_amount,0 cnfrmd_actl_prc_vat,0 cnfrmd_wholesale_prc,0 cnfrmd_retail_prc, item_value \r\nfrom price_value_addition_area pvaa inner join price_item pi on pvaa.price_id=pi.price_id \r\nwhere pvaa.price_id='", intPriceID, "') d group by price_id,price_declaration_no" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "PDNO");
        }

        public DataSet getPricedecalredItemsByOrg(short orgId)
        {
            string str = string.Concat("select distinct pi.Item_id ItemId,i.item_name,i.item_name||' # '||i.hs_code ItemName\r\n        from price_item pi left outer join\r\n        org_registration_info ori on ori.Organization_id= pi.Organization_id inner join\r\n        Item i on i.Item_id=pi.Item_id where pi.Is_deleted=false and pi.Organization_id=", orgId, " \r\n        order by i.item_name");
            return this.DBUtil.GetDataSet(str, "WholesalePriceByOrgAndItem");
        }

        public DataTable getPriceDecItem()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select distinct pi.Item_id, i.item_name item_name\r\n        from price_item pi inner join Item i on pi.Item_id=i.Item_id\r\n        where pi.Is_deleted=false and is_nbr_confirmed=false AND upper(price_declaration_no) <> 'NO' and pi.organization_id=", num, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPriceDecNpbyItemId(int itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] objArray = new object[] { "select price_id,price_declaration_no,\r\n        price_declaration_no||'/'|| price_declaration_year price_declaration_number\r\n        from price_item pi inner join Item i on pi.Item_id=i.Item_id\r\n        where pi.Is_deleted=false and is_nbr_confirmed=false AND upper(price_declaration_no) <> 'NO' and pi.organization_id=", num, " and pi.item_id=", itemID, " order by i.item_name,pi.Date_insert desc" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public int GetPriceID()
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(this.DBUtil.GetSingleValue("select coalesce(max(price_id),0) from price_item"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return num;
        }

        public DataTable getPriceRawItemForGridCount(int price_id)
        {
            string str = string.Concat("select * from price_raw_item WHERE price_id = ", price_id, " AND is_deleted = false AND set_status!='P' order by row_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPriceRawItemId(int price_id)
        {
            string str = string.Concat("select item_id,price_id from price_raw_item WHERE price_id = ", price_id, " AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public string getPrinterName(string code)
        {
            string str = string.Concat("select code_name from app_code_detail where code_short_name = '", code, "'");
            DataTable dataTable = this.DBUtil.GetDataTable(str);
            if (dataTable.Rows.Count <= 0)
            {
                return "";
            }
            return dataTable.Rows[0][0].ToString();
        }

        public DataTable getPrpQuantitybyItemID(int itemId)
        {
            string str = string.Concat("select property_quantity from trns_sale_detail where  item_id=", itemId, " and property_quantity!=0  ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getReference(int price_id)
        {
            string str = string.Concat("select PR.reference from price_raw_item AS PR  WHERE PR.price_id =", price_id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetReportStatus(int id)
        {
            string str = string.Concat("select is_printed from report_table where id = ", id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetSubCategory()
        {
            return this.DBUtil.GetDataTable("select IC.category_id,IC.category_name,IC.parent_id,IC.category_level,I.item_id,I.sub_category_id,I.item_name from item_category AS IC\r\n            LEFT JOIN item AS I\r\n            ON IC.category_id = I.sub_category_id\r\n            WHERE  IC.is_deleted = false AND I.is_deleted = false");
        }

        public DataTable GetSubCategoryWithItem(int item_id)
        {
            string str = string.Concat("select IC.category_id,IC.category_name,IC.parent_id,IC.category_level,I.item_id,I.sub_category_id,I.item_name from item_category AS IC\r\n            LEFT JOIN item AS I\r\n            ON IC.category_id = I.sub_category_id\r\n            WHERE  IC.is_deleted = false AND I.is_deleted = false AND item_id = ", item_id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet GetSubCategoryWithItemWithParam(int item_id)
        {
            string str = string.Concat("select IC.category_id,IC.category_name,IC.parent_id,IC.category_level,I.item_id,I.sub_category_id,I.item_name from item_category AS IC\r\n            LEFT JOIN item AS I\r\n            ON IC.category_id = I.sub_category_id\r\n            WHERE  IC.is_deleted = false AND I.is_deleted = false AND item_id = ", item_id);
            return this.DBUtil.GetDataSet(str, "tavle");
        }

        public DataTable getTotalPrice(int price_id)
        {
            string str = string.Concat("select total_price FROM price_item WHERE price_id = ", price_id, " AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getTotalQuantityPrice(int price_id)
        {
            string str = string.Concat("select SUM(txtquantityprice) txtquantityprice from  price_raw_item WHERE price_id = ", price_id, " AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetTotalValueAddPct(int intPriceId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select coalesce(sum(pvaa.value_addtn_pct),0) value_addtn_pct \r\n                            from price_value_addition_area pvaa \r\n                            where pvaa.value_adtn_item_m=8 and pvaa.price_id=", intPriceId);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getTotalWastageQueantity(int price_id)
        {
            string str = string.Concat("select SUM(wastage_quantity) wastage_quantity from price_raw_item WHERE price_id = ", price_id, " AND is_deleted = false ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetTotatValuesALL(int price_id)
        {
            string str = string.Concat("SELECT SUM(quantity_total)quantity_total_sum,SUM(wastageparcent)wastage_parcent_sum,\r\n                            SUM(wastage_quantity) wastage_quantity_sum,SUM(Quantity) quantity_sum,\r\n                            SUM(challanprice) challanprice_sum,SUM(challan_quantity) challan_quantity_sum,\r\n                            SUM(productionquantity) production_quantity_sum,SUM(txtquantityprice) txtquantity_price_sum\r\n\r\n                            FROM (\r\n\t\t\t                select PR.price_id,PR.item_id,PR.unit_id,\r\n\t\t\t                I.item_name,PR.quantity_total,\r\n\t\t\t                U.unit_code,PR.wastageparcent,PR.wastage_quantity,PR.Quantity,\r\n                            PR.challanprice,PR.challan_quantity,PR.productionquantity,\r\n                            PR.txtquantityprice,PR.reference\r\n\r\n\r\n                            from price_raw_item AS PR\r\n                            LEFT JOIN item AS I ON PR.item_id = I.item_id\r\n                            LEFT JOIN item_unit AS U ON PR.unit_id = U.unit_id\r\n                            WHERE PR.price_id = ", price_id, " )A ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getTradePrice(int intItemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("\r\n                    select tax_value_id,tax_value from item_tax_values\r\n                    where is_deleted=false AND is_current=true AND is_trade_price=true AND item_id=", intItemId);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getUnit()
        {
            return this.DBUtil.GetDataTable("select distinct * from item_unit where Is_deleted=false  order by unit_name ");
        }

        public DataTable getValueAdddition(string priceDeclerationNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select pva.* from price_value_addition_area as pva\r\n                            join price_item as pi on pi.price_id=pva.price_id\r\n                            where pva.value_adtn_item_m='8' and pi.price_declaration_no='", priceDeclerationNo, "'");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getValueAddditionNonItem(string priceDeclerationNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select pva.* from price_value_addition_area as pva\r\n                            join price_item as pi on pi.price_id=pva.price_id\r\n                            where pva.value_adtn_item_m='14' and pi.price_declaration_no='", priceDeclerationNo, "'");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getValueAdded(int price_id)
        {
            string str = string.Concat("select AC.code_name item_name,'-' AS quantity_total,'-' AS unit_code,'-' AS wastageparcent,'-' AS wastage_quantity,'-' AS Quantity,'-' AS challanprice,\r\n'-' AS challan_quantity,'-' AS productionquantity,PV.item_value txtquantityprice from price_value_addition_area AS PV\r\nLEFT JOIN app_code_detail AS AC\r\nON PV.value_adtn_item_m = AC.code_id_m AND PV.value_adtn_item_d =  AC.code_id_d  \r\nWHERE PV.price_id = ", price_id, " ORDER BY  PV.value_adtn_item_m,PV.value_adtn_item_d");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getValueAdditionItem(int price_id, int value_adtn_item_d)
        {
            object[] priceId = new object[] { "select item_value,coalesce(value_addtn_pct,0)value_addtn_pct from price_value_addition_area WHERE value_adtn_item_m = 8 AND price_id = ", price_id, "  AND is_deleted = false AND value_adtn_item_d = ", value_adtn_item_d };
            string str = string.Concat(priceId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getValueAdditionNonItem(int price_id, int value_adtn_item_d)
        {
            object[] priceId = new object[] { "select item_value from price_value_addition_area WHERE value_adtn_item_m = 14 AND price_id = ", price_id, "  AND is_deleted = false AND value_adtn_item_d = ", value_adtn_item_d };
            string str = string.Concat(priceId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getValueDeclaretionNumber()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select price_id,price_declaration_no from price_item WHERE is_deleted = false AND upper(price_declaration_no) <> 'NO' and organization_id=", num, " order by price_declaration_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetValueFromScriept(int fUnit, int sUnit)
        {
            object[] objArray = new object[] { "select COALESCE(value_to, 0 ) convert_value  from item_unit_conversion WHERE unit_id_from = ", fUnit, " AND unit_id_to = ", sUnit, " AND is_deleted = false " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetValueFromScrieptSec(int fUnit, int sUnit)
        {
            object[] objArray = new object[] { "select COALESCE(value_to, 0 ) convert_value  from item_unit_conversion WHERE unit_id_from = ", sUnit, " AND unit_id_to = ", fUnit, " AND is_deleted = false " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getWholesalePriceByOrgAndItem(short OrgId, short ItemId)
        {
            object[] itemId = new object[] { "select price_id, pi.Date_insert, pi.Organization_id,ori.organization_name,pi.Item_id,i.item_name,wholesale_prc_sd_vat\r\n        from price_item pi left outer join\r\n        org_registration_info ori on ori.Organization_id= pi.Organization_id inner join\r\n        Item i on i.Item_id=pi.Item_id where pi.Is_deleted=false and i.Item_id=", ItemId, " and pi.Organization_id=", OrgId, " \r\n        order by pi.Date_insert desc" };
            string str = string.Concat(itemId);
            return this.DBUtil.GetDataSet(str, "WholesalePriceByOrgAndItem");
        }

        public bool InsertPD(PriceDeclaretionDAO objPDDAO)
        {
            bool flag = false;
            try
            {
                object[] objArray = new object[] { "INSERT INTO price_item (price_id,org_branch_reg_id,Organization_id,property_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id, \r\n                               crnt_actl_prc_sd, prpsd_actl_prc_sd, sd_amount,\r\n          crnt_actl_prc_vat,prpsd_actl_prc_vat,wholesale_prc_sd_vat,retail_prc_sd_vat,User_id_insert,cg_declaration_no,\r\n          cnfrmd_actl_prc_sd,cnfrmd_sd_amount,cnfrmd_actl_prc_vat,cnfrmd_wholesale_prc,cnfrmd_retail_prc,prpsd_actl_prc,Type,total_Price,agreement_no,trade_price_value,trade_price_value_pct,production_quantity,health_surcharge,stick_quantity ) VALUES   ('", objPDDAO.intPriceID, "',", objPDDAO.BranchID, ",'", objPDDAO.intOrganizationID, "','", objPDDAO.property_id, "','", objPDDAO.strPriceDeclaretionNo, "','", objPDDAO.intPriceDeclaretionYear, "',to_date('", objPDDAO.dtActiveDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy'),'", objPDDAO.intItemId, "','", objPDDAO.intUnitId, "','", objPDDAO.decCurrentSDChargablePrice, "','", objPDDAO.decProposedSDChargablePric, "','", objPDDAO.decSD, "','", objPDDAO.decCurrentVATChargablePrice, "','", objPDDAO.decProposedVATChargabelPrice, "','", objPDDAO.decWholeSalePrice, "','", objPDDAO.decRetailPrice, "','", objPDDAO.intUserIdInsert, "',(select coalesce(max(cg_declaration_no),0)+1 row_number from price_item where price_declaration_year='", objPDDAO.intPriceDeclaretionYear, "' and Item_id='", objPDDAO.intItemId, "'),'", objPDDAO.decNBRSDChargablePrice, "','", objPDDAO.decNBRSD, "','", objPDDAO.decNBRVATChargablePrice, "','", objPDDAO.decNBRWholeSalePrice, "','", objPDDAO.decNBRRetailPrice, "','", objPDDAO.decProposedActualPrice, "','", objPDDAO.intDeclarationType, "','", objPDDAO.Total_Price, "','", objPDDAO.AgreementNo, "',", objPDDAO.Trade_price_value, ",", objPDDAO.TradePricePct, ",", objPDDAO.ProductQuantity, ",", objPDDAO.HealthCharge, ",", objPDDAO.StickQuantity, ")" };
                string str = string.Concat(objArray);
                flag = this.DBUtil.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }

        public bool InsertPD_1KA(PriceDeclaretionDAO objPDDAO)
        {
            object[] objArray = new object[] { "INSERT INTO price_item (price_id,Organization_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id, \r\nUser_id_insert,cg_declaration_no,Type,Remarks)\r\n    VALUES  ('", objPDDAO.intPriceID, "','", objPDDAO.intOrganizationID, "','", objPDDAO.strPriceDeclaretionNo, "','", objPDDAO.intPriceDeclaretionYear, "','", objPDDAO.dtActiveDate, "','", objPDDAO.intItemId, "','", objPDDAO.intUnitId, "','", objPDDAO.intUserIdInsert, "',(select coalesce(max(cg_declaration_no),0)+1 row_number from price_item where price_declaration_year='", objPDDAO.intPriceDeclaretionYear, "' and Item_id='", objPDDAO.intItemId, "'),'", objPDDAO.intDeclarationType, "','", objPDDAO.strRemarks, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertPDN(PriceDeclaretionDAO objPDDAO, ArrayList arrPriceDetail, ArrayList arrValueAddtn, int intUserIdInsert, ArrayList arrValueNonAddtn)
        {
            ArrayList arrayLists = new ArrayList();
            bool flag = false;
            try
            {
                object[] objArray = new object[] { "INSERT INTO price_item (price_id,org_branch_reg_id,Organization_id,property_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id, \r\n                               crnt_actl_prc_sd, prpsd_actl_prc_sd, sd_amount,\r\n          crnt_actl_prc_vat,prpsd_actl_prc_vat,wholesale_prc_sd_vat,retail_prc_sd_vat,User_id_insert,cg_declaration_no,\r\n          cnfrmd_actl_prc_sd,cnfrmd_sd_amount,cnfrmd_actl_prc_vat,cnfrmd_wholesale_prc,cnfrmd_retail_prc,prpsd_actl_prc,Type,total_Price,agreement_no,trade_price_value,trade_price_value_pct,production_quantity,health_surcharge,stick_quantity ) VALUES   ('", objPDDAO.intPriceID, "',", objPDDAO.BranchID, ",'", objPDDAO.intOrganizationID, "','", objPDDAO.property_id, "','", objPDDAO.strPriceDeclaretionNo, "','", objPDDAO.intPriceDeclaretionYear, "',to_date('", objPDDAO.dtActiveDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy'),'", objPDDAO.intItemId, "','", objPDDAO.intUnitId, "','", objPDDAO.decCurrentSDChargablePrice, "','", objPDDAO.decProposedSDChargablePric, "','", objPDDAO.decSD, "','", objPDDAO.decCurrentVATChargablePrice, "','", objPDDAO.decProposedVATChargabelPrice, "','", objPDDAO.decWholeSalePrice, "','", objPDDAO.decRetailPrice, "','", objPDDAO.intUserIdInsert, "',(select coalesce(max(cg_declaration_no),0)+1 row_number from price_item where price_declaration_year='", objPDDAO.intPriceDeclaretionYear, "' and Item_id='", objPDDAO.intItemId, "'),'", objPDDAO.decNBRSDChargablePrice, "','", objPDDAO.decNBRSD, "','", objPDDAO.decNBRVATChargablePrice, "','", objPDDAO.decNBRWholeSalePrice, "','", objPDDAO.decNBRRetailPrice, "','", objPDDAO.decProposedActualPrice, "','", objPDDAO.intDeclarationType, "','", objPDDAO.Total_Price, "','", objPDDAO.AgreementNo, "',", objPDDAO.Trade_price_value, ",", objPDDAO.TradePricePct, ",", objPDDAO.ProductQuantity, ",", objPDDAO.HealthCharge, ",", objPDDAO.StickQuantity, ")" };
                arrayLists.Add(string.Concat(objArray));
                arrayLists = this.InsertRowProductItemN(arrayLists, arrPriceDetail);
                arrayLists = this.InsertPDValueAddN(arrayLists, arrValueAddtn, intUserIdInsert);
                arrayLists = this.InsertPDValueAddNonItemN(arrayLists, arrValueNonAddtn, intUserIdInsert);
                flag = this.DBUtil.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }

        public bool InsertPDRaw(int intPriceId, int intItemId, int intUnitId, decimal decQty, decimal decWQty, decimal decUnitPrice, int intUserIdInsert)
        {
            object[] objArray = new object[] { "INSERT INTO price_raw_item(price_id,row_no,Item_id,unit_id,Quantity,wastage_quantity,unit_price,User_id_insert) VALUES   ('", intPriceId, "',(select coalesce(max(row_no),0)+1 row_number from price_raw_item where price_id='", intPriceId, "'), '", intItemId, "','", intUnitId, "','", decQty, "','", decWQty, "','", decUnitPrice, "','", intUserIdInsert, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertPDValueAdd(int intPriceId, int intValueAdditionItemD, decimal decItemValue, int intUserIdInsert, decimal decItemValuePct)
        {
            object[] objArray = new object[] { "INSERT INTO price_value_addition_area(price_id,row_no,value_adtn_item_m,value_adtn_item_d,item_value,User_id_insert,cnfrmd_item_value,value_addtn_pct) VALUES   ('", intPriceId, "',(select coalesce(max(row_no),0)+1 row_number from price_value_addition_area where price_id='", intPriceId, "'), '8','", intValueAdditionItemD, "','", decItemValue, "','", intUserIdInsert, "','", decItemValue, "','", decItemValuePct, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertPDValueAdd(int intPriceId, int intValueAdditionItemD, decimal decItemValue, int intUserIdInsert, decimal wastagePct, decimal netValueAdditionItemD)
        {
            object[] objArray = new object[] { "INSERT INTO price_value_addition_area(price_id,row_no,value_adtn_item_m,value_adtn_item_d,item_value,User_id_insert,cnfrmd_item_value,wastage_value_pct,net_item_value) VALUES   ('", intPriceId, "',(select coalesce(max(row_no),0)+1 row_number from price_value_addition_area where price_id='", intPriceId, "'), '8','", intValueAdditionItemD, "','", decItemValue, "','", intUserIdInsert, "','", decItemValue, "','", wastagePct, "','", netValueAdditionItemD, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public ArrayList InsertPDValueAddN(ArrayList insertQuery, ArrayList arrValueAddtn, int intUserIdInsert)
        {
            for (int i = 0; i < arrValueAddtn.Count; i++)
            {
                PriceDeclaretionDAOVlueAdditional item = (PriceDeclaretionDAOVlueAdditional)arrValueAddtn[i];
                if (item.decItemValue > new decimal(0))
                {
                    object[] objArray = new object[] { "INSERT INTO price_value_addition_area(price_id,row_no,value_adtn_item_m,value_adtn_item_d,item_value,User_id_insert,cnfrmd_item_value,value_addtn_pct) VALUES   ('", item.intPriceId, "',(select coalesce(max(row_no),0)+1 row_number from price_value_addition_area where price_id='", item.intPriceId, "'), '8','", item.intValueAdditionItemD, "','", item.decItemValue, "','", intUserIdInsert, "','", item.decItemValue, "','", item.decItemValuePct, "')" };
                    insertQuery.Add(string.Concat(objArray));
                }
            }
            return insertQuery;
        }

        public bool InsertPDValueAddNonItem(int intPriceId, int intValueAdditionItemD, decimal decItemValue, int intUserIdInsert)
        {
            object[] objArray = new object[] { "INSERT INTO price_value_addition_area(price_id,row_no,value_adtn_item_m,value_adtn_item_d,item_value,User_id_insert,cnfrmd_item_value) VALUES   ('", intPriceId, "',(select coalesce(max(row_no),0)+1 row_number from price_value_addition_area where price_id='", intPriceId, "'), '14','", intValueAdditionItemD, "','", decItemValue, "','", intUserIdInsert, "','", decItemValue, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public ArrayList InsertPDValueAddNonItemN(ArrayList insertQuery, ArrayList arrValueNonAddtn, int intUserIdInsert)
        {
            for (int i = 0; i < arrValueNonAddtn.Count; i++)
            {
                PriceDeclaretionDAONonVlueAdditional item = (PriceDeclaretionDAONonVlueAdditional)arrValueNonAddtn[i];
                if (item.decItemValuenon > new decimal(0))
                {
                    object[] objArray = new object[] { "INSERT INTO price_value_addition_area(price_id,row_no,value_adtn_item_m,value_adtn_item_d,item_value,User_id_insert,cnfrmd_item_value) VALUES   ('", item.intPriceIdnon, "',(select coalesce(max(row_no),0)+1 row_number from price_value_addition_area where price_id='", item.intPriceIdnon, "'), '14','", item.intValueAdditionItemDnon, "','", item.decItemValuenon, "','", intUserIdInsert, "','", item.decItemValuenon, "')" };
                    insertQuery.Add(string.Concat(objArray));
                }
            }
            return insertQuery;
        }

        public bool InsertRowProductItem(ArrayList arrRowProductPriceLit)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrRowProductPriceLit.Count; i++)
            {
                PriceRowItemDAO item = (PriceRowItemDAO)arrRowProductPriceLit[i];
                object[] priceId = new object[] { "INSERT INTO price_raw_item(price_id,row_no,Item_id,unit_id,unit_id_sec,Quantity,wastage_quantity,User_id_insert,quantity_total,wastageparcent,challanprice,challan_quantity ,productionquantity,txtQuantityPrice,reference,remarks) VALUES   ('", item.PriceId, "',(select coalesce(max(row_no),0)+1 row_number from price_raw_item where price_id='", item.PriceId, "'), '", item.ItemId, "','", item.UnitId, "','", item.UnitIdSec, "','", item.Quantity, "','", item.WastageQuantity, "','", item.UserIdInsert, "','", item.TxtQuantityTotal, "','", item.TxtWastageParcent, "','", item.TxtChallanPrice, "','", item.TxtChallanQuantity, "','", item.TxtProductionQuantity, "','", item.TxtQuantity, "','", item.TxtReference, "','", item.TextRemarks, "')" };
                arrayLists.Add(string.Concat(priceId));
            }
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public ArrayList InsertRowProductItemN(ArrayList arrQuery, ArrayList arrRowProductPriceLit)
        {
            for (int i = 0; i < arrRowProductPriceLit.Count; i++)
            {
                //PriceRowItemDAO item = (PriceRowItemDAO)arrRowProductPriceLit[i];
                try
                {
                    PriceRowItemDAO item = (PriceRowItemDAO)arrRowProductPriceLit[i];
                    var itemr = (PriceRowItemDAO)arrRowProductPriceLit[i];

                    object[] priceId = new object[] { "INSERT INTO price_raw_item(price_id,row_no,Item_id,unit_id,unit_id_sec,Quantity,wastage_quantity,User_id_insert,quantity_total,wastageparcent,challanprice,challan_quantity ,productionquantity,txtQuantityPrice,reference,remarks,set_status) VALUES   ('", item.PriceId, "',(select coalesce(max(row_no),0)+1 row_number from price_raw_item where price_id='", item.PriceId, "'), '", item.ItemId, "','", item.UnitId, "','", item.UnitIdSec, "','", item.Quantity, "','", item.WastageQuantity, "','", item.UserIdInsert, "','", item.TxtQuantityTotal, "','", item.TxtWastageParcent, "','", item.TxtChallanPrice, "','", item.TxtChallanQuantity, "','", item.TxtProductionQuantity, "','", item.TxtQuantity, "','", item.TxtReference, "','", item.TextRemarks, "','", item.Set_status, "')" };
                    arrQuery.Add(string.Concat(priceId));
                }
                catch(Exception EX)
                {

                }
              
             
            }
            return arrQuery;
        }

        public bool InsertWOItem(ArrayList arrRowProductPriceLit)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrRowProductPriceLit.Count; i++)
            {
                WorkOrderItemsDAO item = (WorkOrderItemsDAO)arrRowProductPriceLit[i];
                object[] priceID = new object[] { "INSERT INTO price_raw_item(price_id,row_no,Item_id,unit_id,Quantity,User_id_insert,unit_price,discount_price, tax) \r\n                                VALUES (", item.PriceID, ",", item.RowNo, ",", item.ItemID, ",\r\n                                            ", item.UnitID, ",", item.Quantity, ",", item.UserIDInsert, ",\r\n                                            ", item.UnitPrice, ",", item.Discount, ",", item.Tax, ")" };
                arrayLists.Add(string.Concat(priceID));
            }
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool InsertWOTempMaster(WorkOrderDAO objWODAO)
        {
            bool flag = false;
            try
            {
                object[] priceID = new object[] { "INSERT INTO price_item (price_id,org_branch_reg_id,Organization_id, price_declaration_no, price_declaration_year,\r\n                                    date_effective,User_id_insert) \r\n                                VALUES(", objWODAO.PriceID, ",", objWODAO.OrgBranchID, ",", objWODAO.OrganizationID, ",'", objWODAO.TemplateNO, "',\r\n                                        ", objWODAO.TemplateYear, ",'", objWODAO.EffectiveDate, "',", objWODAO.UserIdInsert, ")" };
                string str = string.Concat(priceID);
                flag = this.DBUtil.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }

        public int intItemUnitId(int intItemId)
        {
            string str = string.Concat("select unit_id from Item where Item_id='", intItemId, "'");
            return Convert.ToInt32(this.DBUtil.GetSingleValue(str));
        }

        public int intPDId()
        {
            return Convert.ToInt32(this.DBUtil.GetSingleValue("select nextval('price_id_seq')"));
        }

        public int intTaxValueByItemPrice(int intPriceId)
        {
            string str = string.Concat("Select  case when itv.tax_value>0 then itv.tax_value else 0 end tax_value\r\nfrom price_item pi left outer join item_tax_values itv on pi.Item_id=itv.Item_id and itv.tax_id=3\r\nwhere pi.Is_deleted=false and is_nbr_confirmed=false and price_id='", intPriceId, "'");
            return Convert.ToInt32(this.DBUtil.GetSingleValue(str));
        }

        public DataTable IsExistDeclaretion(string declaretion_No)
        {
            string str = string.Concat("select * from  price_item where price_declaration_no = '", declaretion_No, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistValueAddition(int PriceId, int value_adtn_item_d, int intValueAdditionItemM)
        {
            object[] priceId = new object[] { "select * from  price_value_addition_area where price_id = ", PriceId, " and value_adtn_item_d=", value_adtn_item_d, " and value_adtn_item_m=", intValueAdditionItemM };
            string str = string.Concat(priceId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable lastpricebyItem(int itemID)
        {
            object[] objArray = new object[] { "select quantity,purchase_unit_price,unit_id from trns_purchase_detail where item_id=", itemID, " and challan_id=(select max(challan_id) from trns_purchase_detail where item_id=", itemID, "  and quantity!=0 and purchase_unit_price!=0)" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable rptPriceDeclaration(int intPriceId)
        {
            object[] objArray = new object[] { "select pi.price_id, '1' Sl_No_1,i.hs_code HS_Code_2,i.item_name Goods_Name_3,pi.Item_id Item_id,i.item_specification Goods_Description_31,iu.unit_code Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        ''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_Code,\r\n                        '' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        pi.crnt_actl_prc_sd Price_With_SD_Present_10,pi.prpsd_actl_prc_sd Price_With_SD_Applied_11,pi.sd_amount SD_On_Applied_Price_12,pi.crnt_actl_prc_vat VAT_Applicable_Price_Present_13,\r\n                        pi.prpsd_actl_prc_vat VAT_Applicable_Price_Applied_14,pi.wholesale_prc_sd_vat Sale_Price_With_DutyNTax_Wholesale_15,pi.retail_prc_sd_vat Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                        ,pi.production_quantity,coalesce(pi.health_surcharge,0),pi.stick_quantity\r\n                        from price_item pi left outer join\r\n                        Item i on pi.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pi.price_id=", intPriceId, " \r\n\r\n              union all\r\n\r\n                        select pri.price_id,'' Sl_No_1,'' HS_Code_2,''Goods_Name_3,pri.Item_id Item_id,'' Goods_Description_31,'' Sale_Unit_4,i.item_name Raw_Materials_Name_5,\r\n                        i.item_specification Ra_Meterials_Description_51,pri.Quantity Raw_Meterials_Quantity_6,iu.unit_code Unit_Code,\r\n                        '('||pri.wastage_quantity||' '||iu.unit_code||')' Raw_Meterials_Depriciation_61,\r\n                        pri.txtquantityprice Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,pri.wastage_quantity wastage_quantity \r\n                        ,0 production_quantity,0 health_surcharge,0 stick_quantity\r\n                        from price_raw_item pri left outer join\r\n                        Item i on pri.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pri.price_id=", intPriceId, " and pri.set_status!='P'\r\n                union all\r\n\t\t\t            select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,acd.code_name Raw_Materials_Name_5,\r\n                        '' Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_code,'' Raw_Meterials_Depriciation_61,pvaa.item_value Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                        ,0 production_quantity,0 health_surcharge,0 stick_quantity\r\n                         from price_value_addition_area pvaa \r\n                        left outer join\r\n                        app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=14\r\n                        where pvaa.value_adtn_item_m=14 and pvaa.price_id=", intPriceId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable rptPriceDeclarationComp(int intPriceId)
        {
            string str = string.Concat("\r\n                        select pri.price_id,pri.Item_id Item_id,i.item_name Raw_Materials_Name_5,\r\n                        pri.Quantity netuse,quantity_total gross ,pri.unit_id_sec,iu.unit_code Unit_Code,\r\n                        '('||pri.wastage_quantity||' '||iu.unit_code||')' Raw_Meterials_Depriciation_61,\r\n                        pri.txtquantityprice Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,pri.wastage_quantity wastage_quantity \r\n                        ,0 production_quantity,0 health_surcharge,0 stick_quantity,pri.wastageparcent\r\n                        from price_raw_item pri left outer join\r\n                        Item i on pri.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pri.price_id=", intPriceId, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet rptPriceDeclarationForCrystal(int intPriceId)
        {
            object[] objArray = new object[] { "select pi.price_id, '1' Sl_No_1,i.hs_code HS_Code_2,i.item_name Goods_Name_3,pi.Item_id Item_id,i.item_specification Goods_Description_31,iu.unit_code Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        ''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        pi.crnt_actl_prc_sd Price_With_SD_Present_10,pi.prpsd_actl_prc_sd Price_With_SD_Applied_11,pi.sd_amount SD_On_Applied_Price_12,pi.crnt_actl_prc_vat VAT_Applicable_Price_Present_13,\r\n                        pi.prpsd_actl_prc_vat VAT_Applicable_Price_Applied_14,pi.wholesale_prc_sd_vat Sale_Price_With_DutyNTax_Wholesale_15,pi.retail_prc_sd_vat Sale_Price_With_DutyNTax_Retail_Price_16\r\n                        from price_item pi left outer join\r\n                        Item i on pi.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pi.price_id=", intPriceId, " \r\n\r\n              union all\r\n\r\n                        select pri.price_id,'' Sl_No_1,'' HS_Code_2,''Goods_Name_3,pri.Item_id Item_id,'' Goods_Description_31,'' Sale_Unit_4,i.item_name Raw_Materials_Name_5,\r\n                        i.item_specification Raw_Meterials_Description_51,pri.Quantity Raw_Meterials_Quantity_6,'('||pri.wastage_quantity||' '||iu.unit_code||')' Raw_Meterials_Depriciation_61,pri.txtquantityprice Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16\r\n                        from price_raw_item pri left outer join\r\n                        Item i on pri.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pri.price_id=", intPriceId, "\r\nunion all\r\n\t\t\t            select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,acd.code_name Raw_Materials_Name_5,\r\n                        '' Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Raw_Meterials_Depriciation_61,pvaa.item_value Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16\r\n                        from price_value_addition_area pvaa \r\n                        left outer join\r\n                        app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=14\r\n                        where pvaa.value_adtn_item_m=14 and pvaa.price_id=", intPriceId, "\r\n\r\n                         union all\r\n\r\n                         select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        ''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,acd.code_name Value_Add_8,\r\n                        pvaa.item_value Value_Added_Per_Unit_9,\r\n                        0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16\r\n                        from price_value_addition_area pvaa \r\n                        left outer join\r\n                        app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=8\r\n                        where pvaa.value_adtn_item_m=8 and pvaa.price_id=", intPriceId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "Table");
        }

        public DataTable rptPriceDeclarationFourPointThree(int intPriceId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select pi.price_id, '1' Sl_No_1,i.hs_code HS_Code_2,i.item_name Goods_Name_3,pi.Item_id Item_id,i.item_specification Goods_Description_31,iu.unit_code Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        ''Raw_Meterials_Description_51,'' Raw_Meterials_Quantity_6,'0' Raw_Meterials_Quantity_6N,'' Unit_Code,\r\n                        '' Raw_Meterials_Depriciation_61,0 Raw_Meterials_Depriciation_61N,0 Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        ROUND(pi.crnt_actl_prc_sd,4) Price_With_SD_Present_10, ROUND(pi.prpsd_actl_prc_sd,4) Price_With_SD_Applied_11, ROUND(pi.sd_amount,4) SD_On_Applied_Price_12, ROUND(pi.crnt_actl_prc_vat,4) VAT_Applicable_Price_Present_13,\r\n                         ROUND(pi.prpsd_actl_prc_vat,4) VAT_Applicable_Price_Applied_14, ROUND(pi.wholesale_prc_sd_vat,4) Sale_Price_With_DutyNTax_Wholesale_15, ROUND(pi.retail_prc_sd_vat,4) Sale_Price_With_DutyNTax_Retail_Price_16\r\n                         ,'' wastage_quantity ,'0' wastage_quantityN\r\n                        ,0 AS wastageparcent\r\n                        ,'' AS reference,'' as remarks ,0 AS quantity,'' date_insert, '' as quantity_total,'0' as quantity_totalN,to_char(pi.date_effective, 'DD/MM/YYYY') as effective_date\r\n                        from price_item pi left outer join\r\n                        Item i on pi.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pi.price_id=", intPriceId, " \r\n\r\n                        union all\r\n\r\n                        (select pri.price_id,'' Sl_No_1,'' HS_Code_2,''Goods_Name_3,pri.Item_id Item_id,'' Goods_Description_31,'' Sale_Unit_4,i.item_name Raw_Materials_Name_5,\r\n                        i.item_specification Ra_Meterials_Description_51, ( '('||(select unit_code from item_unit where unit_id=pri.unit_id_sec)||')') Raw_Meterials_Quantity_6, ROUND(pri.Quantity,4) Raw_Meterials_Quantity_6N,iu.unit_code Unit_Code,\r\n                        '('||pri.wastage_quantity||' '||iu.unit_code||')' Raw_Meterials_Depriciation_61,pri.wastage_quantity Raw_Meterials_Depriciation_61N,\r\n                         ROUND(pri.txtquantityprice,4) Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,\r\n                        ('('||(select unit_code from item_unit where unit_id=pri.unit_id_sec)||')') wastage_quantity  \r\n                        ,ROUND(pri.wastage_quantity,4) wastage_quantityN\r\n                        , ROUND(pri.wastageparcent,4) AS wastageparcent\r\n                        ,pri.reference AS reference,pri.remarks\r\n                        , ROUND(pri.quantity,4) quantity\r\n                        ,to_char(pri.date_insert, 'DD/MM/YYYY') date_insert \r\n                        , ('('||(select unit_code from item_unit where unit_id=pri.unit_id_sec)||')') quantity_total\r\n                         , ROUND(pri.quantity_total,4) quantity_totalN,null effective_date\r\n                        from price_raw_item pri left outer join\r\n                        Item i on pri.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id  \r\n                        where pri.price_id=", intPriceId, " AND pri.set_status!='P' order by pri.row_no)\r\n                        union all\r\n\t\t\t           (select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,acd.code_name Raw_Materials_Name_5,\r\n                        '' Raw_Meterials_Description_51,'' Raw_Meterials_Quantity_6,'0' Raw_Meterials_Quantity_6N,'' Unit_code,'' Raw_Meterials_Depriciation_61,0 Raw_Meterials_Depriciation_61N,ROUND(coalesce(pvaa.item_value,0),4) Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,'' wastage_quantity,'0' wastage_quantityN\r\n                        ,0 AS wastageparcent\r\n                        ,'' AS reference,'' as remarks\r\n                        ,0 AS quantity\r\n                        ,'' date_insert\r\n                        ,'' as quantity_total,'0' as quantity_totalN,null effective_date\r\n                        from price_value_addition_area pvaa \r\n                        left outer join\r\n                        app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=14\r\n                        where pvaa.value_adtn_item_m=14 and pvaa.price_id=", intPriceId, " order by pvaa.value_adtn_item_d)" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable rptPriceDeclarationFourPointThreeKhat(int intPriceId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                            ''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_code,'' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,acd.code_name Value_Add_8,\r\n                            ROUND(pvaa.item_value,4) Value_Added_Per_Unit_9,\r\n                            0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                            0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                            ,0 AS wastageparcent\r\n                            ,'' AS reference\r\n                            from price_value_addition_area pvaa \r\n                            left outer join\r\n                            app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=8\r\n                            where pvaa.value_adtn_item_m=8 and pvaa.price_id=", intPriceId, " order by pvaa.value_adtn_item_d");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable rptPriceDeclarationOtherComp(int intPriceId)
        {
            string str = string.Concat("  select ad.code_id_d,ad.code_name,item_value from price_value_addition_area  pvaa \r\n                           inner join app_code_detail ad on ad.code_id_d=value_adtn_item_d and ad.code_id_m=value_adtn_item_m\r\n                           where  value_adtn_item_m=14 and pvaa.price_id= ", intPriceId, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable rptPriceDeclarationTobacco(int intPriceId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "(select pvaa.price_id,acd.code_name Value_Add_8,\r\n                            ROUND(pvaa.item_value,4) Value_Added_Per_Unit_9,0 charge\r\n                            from price_value_addition_area pvaa \r\n                            left outer join\r\n                            app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=8\r\n                            where pvaa.value_adtn_item_m=8 and pvaa.price_id=", intPriceId, " \r\n                           order by pvaa.value_adtn_item_d)\r\n\r\n\r\n                            union all\r\n\r\n                            select pi.price_id, 'সম্পূরক শুল্ক',                        \r\n                    0  Value_Added_Per_Unit_9,   pi.sd_amount charge\r\n                       \r\n                        from price_item pi \r\n                        where pi.price_id=", intPriceId, "\r\n                         union all\r\n\r\n                            select pi.price_id, 'মূসক',                        \r\n                        0  Value_Added_Per_Unit_9, pi.crnt_actl_prc_vat charge\r\n                       \r\n                        from price_item pi \r\n                        where pi.price_id=", intPriceId, "\r\n                        union all\r\n\r\n                            select pi.price_id, ' সার চার্জ (স্বাস্থ্য উন্নয়ন)',                        \r\n                      0  Value_Added_Per_Unit_9,  coalesce(pi.health_surcharge,0) charge\r\n                       \r\n                        from price_item pi \r\n                        where pi.price_id=", intPriceId, " " };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataSet rptPriceDeclarationTradersForm1Ga(int intPriceId)
        {
            object[] objArray = new object[] { "select '1' _1, pi.price_id,pi.Item_id,i.hs_code _2,i.item_name _3,i.item_specification _3_1,pi.unit_id, iu.unit_name _4, '' _5, '' _5_1,''_6, 0 _7\r\n                        from price_item pi inner join Item i on pi.Item_id=i.Item_id inner join item_unit iu on pi.unit_id=iu.unit_id where pi.price_id='", intPriceId, "'\r\n                        union all\r\n                        (select '' _1, pri.price_id,pri.Item_id,'' _2,'' _3,''  _3_1,pri.unit_id,'' _4,i.item_name _5,i.item_specification _5_1,\r\n                        pri.Quantity ||' ' || iu.unit_name ||' ('|| pri.wastage_quantity ||')' _6,pri.unit_price _7\r\n                        from price_raw_item pri inner join Item i on pri.Item_id=i.Item_id  inner join item_unit iu on pri.unit_id=iu.unit_id\r\n                        where pri.price_id='", intPriceId, "' order by row_no)" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "Form1Ga");
        }

        public DataSet rptPriceDeclarationTradersForm1Kha(int intPriceId)
        {
            string str = string.Concat("select '1'_1,pi.price_id,pi.Item_id,i.hs_code _2,i.item_name _3,i.item_specification _31,tpd.actual_price _4,sum(item_value)_5,prpsd_actl_prc_sd _6_7,sd_amount _8,\r\n                            prpsd_actl_prc_vat _9_10,wholesale_prc_sd_vat _11_12 from price_item pi inner join\r\n                            Item i on pi.Item_id=i.Item_id inner join\r\n                            trns_purchase_detail tpd on pi.Challan_id=tpd.Challan_id and pi.Item_id=tpd.Item_id inner join\r\n                            price_value_addition_area pvaa on pi.price_id=pvaa.price_id\r\n                            where pi.Is_deleted=false and declaration_type='T' and pi.price_id='", intPriceId, "'\r\n                            group by pi.price_id,pi.Item_id,i.hs_code,i.item_name,i.item_specification,tpd.actual_price,prpsd_actl_prc_sd,sd_amount,\r\n                            prpsd_actl_prc_vat,wholesale_prc_sd_vat");
            return this.DBUtil.GetDataSet(str, "Form1Kha");
        }

        public DataTable rptPriceDeclarationValueaddComp(int intPriceId)
        {
            string str = string.Concat("  select ad.code_id_d,ad.code_name,item_value from price_value_addition_area  pvaa \r\n                           inner join app_code_detail ad on ad.code_id_d=value_adtn_item_d and ad.code_id_m=value_adtn_item_m\r\n                           where  value_adtn_item_m=8 and pvaa.price_id= ", intPriceId, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable serachRawMaterialByDeclarationNO(string priceDeclerationNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select pi.*,itv.tax_value,ic.category_id from price_item as pi\r\n                            join item_tax_values as itv on itv.Item_id=pi.Item_id\r\n                            join Item as i on i.Item_id=pi.Item_id\r\n                            join item_category as ic on ic.category_id=i.category_id\r\n                             where pi.price_declaration_no='", priceDeclerationNo, "'");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public string strItemUnitName(int intItemId)
        {
            string str = string.Concat("select iu.unit_name from Item i left outer join item_unit iu on iu.unit_id=i.unit_id where Item_id='", intItemId, "'");
            return Convert.ToString(this.DBUtil.GetSingleValue(str));
        }

        public bool UpdatePD(PriceDeclaretionDAO objPDDAO)
        {
            bool flag = false;
            try
            {
                object[] branchID = new object[] { "UPDATE  price_item set org_branch_reg_id=", objPDDAO.BranchID, ",Organization_id='", objPDDAO.intOrganizationID, "',price_declaration_year= '", objPDDAO.intPriceDeclaretionYear, "', date_effective= to_date('", objPDDAO.dtActiveDate.ToString("dd/MM/yyyy"), "', 'dd/MM/yyyy'), Item_id= '", objPDDAO.intItemId, "',unit_id= '", objPDDAO.intUnitId, "', crnt_actl_prc_sd= '", objPDDAO.decCurrentSDChargablePrice, "', prpsd_actl_prc_sd= '", objPDDAO.decProposedSDChargablePric, "', sd_amount= '", objPDDAO.decSD, "',crnt_actl_prc_vat='", objPDDAO.decCurrentVATChargablePrice, "',prpsd_actl_prc_vat='", objPDDAO.decProposedVATChargabelPrice, "',wholesale_prc_sd_vat='", objPDDAO.decWholeSalePrice, "',retail_prc_sd_vat='", objPDDAO.decRetailPrice, "',User_id_insert='", objPDDAO.intUserIdInsert, "',cnfrmd_actl_prc_sd='", objPDDAO.decNBRSDChargablePrice, "',cnfrmd_sd_amount='", objPDDAO.decNBRSD, "',cnfrmd_actl_prc_vat='", objPDDAO.decNBRVATChargablePrice, "',cnfrmd_wholesale_prc='", objPDDAO.decNBRWholeSalePrice, "',cnfrmd_retail_prc='", objPDDAO.decNBRRetailPrice, "',prpsd_actl_prc='", objPDDAO.decProposedActualPrice, "',Type='", objPDDAO.intDeclarationType, "',total_Price='", objPDDAO.Total_Price, "',agreement_no='", objPDDAO.AgreementNo, "',trade_price_value=", objPDDAO.Trade_price_value, ",trade_price_value_pct=", objPDDAO.TradePricePct, ",production_quantity=", objPDDAO.ProductQuantity, " where price_id=", objPDDAO.intPriceID };
                string str = string.Concat(branchID);
                flag = this.DBUtil.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }

        public bool updatePDValueAdd(int intPriceId, decimal decConfirmedValue, int intUserIdUpdate)
        {
            object[] objArray = new object[] { "UPDATE price_value_addition_area SET cnfrmd_item_value='", decConfirmedValue, "',Date_update=now(),User_id_update='", intUserIdUpdate, "' where price_id='", intPriceId, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdatePDValueAdd(int intPriceId, int intValueAdditionItemD, decimal decItemValue, int intUserIdInsert, decimal wastagePct, decimal netValueAdditionItemD)
        {
            object[] objArray = new object[] { "UPDATE  price_value_addition_area set item_value='", decItemValue, "',User_id_insert='", intUserIdInsert, "',cnfrmd_item_value='", decItemValue, "',wastage_value_pct='", wastagePct, "',net_item_value='", netValueAdditionItemD, "' where value_adtn_item_d='", intValueAdditionItemD, "' and price_id='", intPriceId, "' " };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdatePDValueAddtn(int intPriceId, int intValueAdditionItemD, decimal decItemValue, int intUserIdInsert, int intValueAdditionItemM, decimal decItemValuePct)
        {
            object[] objArray = new object[] { "UPDATE  price_value_addition_area set item_value='", decItemValue, "',User_id_insert='", intUserIdInsert, "',cnfrmd_item_value='", decItemValue, "',value_addtn_pct=", decItemValuePct, " where value_adtn_item_m='", intValueAdditionItemM, "' and value_adtn_item_d='", intValueAdditionItemD, "' and price_id='", intPriceId, "' " };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updatePrice(int intPriceId, decimal decNBRSDChargablePrice, decimal decNBRSD, decimal decNBRVATChargablePrice, decimal decNBRWholeSalePrice, decimal decNBRRetailPrice, DateTime dtNBRDate, decimal decNBRActualPrice)
        {
            object[] objArray = new object[] { " UPDATE price_item SET cnfrmd_actl_prc_sd = '", decNBRSDChargablePrice, "',cnfrmd_sd_amount = '", decNBRSD, "',cnfrmd_actl_prc_vat='", decNBRVATChargablePrice, "', cnfrmd_wholesale_prc='", decNBRWholeSalePrice, "',cnfrmd_retail_prc='", decNBRRetailPrice, "',confirmation_date='", dtNBRDate, "',cnfrmd_actl_prc='", decNBRActualPrice, "' WHERE price_id = '", intPriceId, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateReportStatus(int id, bool is_printed)
        {
            object[] isPrinted = new object[] { "update report_table set is_printed = ", is_printed, " where id = ", id };
            string str = string.Concat(isPrinted);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateRowProductItem(ArrayList arrRowProductPriceLit, Dictionary<string, string> dict)
        {
            string empty = string.Empty;
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrRowProductPriceLit.Count; i++)
            {
                PriceRowItemDAO item = (PriceRowItemDAO)arrRowProductPriceLit[i];
                if (item.Row_no_insert == 0)
                {
                    object[] itemId = new object[] { "UPDATE price_raw_item set \r\n                Item_id='", item.ItemId, "',unit_id = '", item.UnitId, "',unit_id_sec = '", item.UnitIdSec, "',Quantity = '", item.Quantity, "',wastage_quantity = '", item.WastageQuantity, "',quantity_total = '", item.TxtQuantityTotal, "',wastageparcent = '", item.TxtWastageParcent, "',challanprice = '", item.TxtChallanPrice, "',challan_quantity = '", item.TxtChallanQuantity, "',productionquantity = '", item.TxtProductionQuantity, "',txtQuantityPrice = '", item.TxtQuantity, "',reference = '", item.TxtReference, "',remarks = '", item.TextRemarks, "' where price_id=", item.PriceId, " and row_no=", item.Row_no };
                    empty = string.Concat(itemId);
                }
                else
                {
                    object[] priceId = new object[] { "INSERT INTO price_raw_item(price_id,row_no,Item_id,unit_id,unit_id_sec,Quantity,wastage_quantity,User_id_insert,quantity_total,wastageparcent,challanprice,challan_quantity ,productionquantity,txtQuantityPrice,reference,remarks) VALUES   ('", item.PriceId, "',", item.Row_no_insert, ", '", item.ItemId, "','", item.UnitId, "','", item.UnitIdSec, "','", item.Quantity, "','", item.WastageQuantity, "','", item.UserIdInsert, "','", item.TxtQuantityTotal, "','", item.TxtWastageParcent, "','", item.TxtChallanPrice, "','", item.TxtChallanQuantity, "','", item.TxtProductionQuantity, "','", item.TxtQuantity, "','", item.TxtReference, "','", item.TextRemarks, "')" };
                    empty = string.Concat(priceId);
                }
                arrayLists.Add(empty);
            }
            if (dict.Count > 0)
            {
                foreach (KeyValuePair<string, string> keyValuePair in dict)
                {
                    arrayLists.Add(string.Concat("Delete from price_raw_item where item_id = ", keyValuePair.Key, " and price_id= ", keyValuePair.Value));
                }
            }
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }
    }
}