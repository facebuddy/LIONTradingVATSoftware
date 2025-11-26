using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AddItemBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility conDB = new DBUtility();

        public AddItemBLL()
        {
        }






        public DataTable GetPropertybyproertyId(long itemID, int propertytype)
        {
            DataTable dataTable = new DataTable();
            string str = "";
            try
            {
                string str1 = string.Concat("select  DISTINCT ip.property_id,ip.* FROM item_property  ip\r\n                            inner join  trns_sale_detail tsd on tsd.property_id1=ip.property_id or tsd.property_id2=ip.property_id or tsd.property_id3=ip.property_id  or tsd.property_id4=ip.property_id or tsd.property_id5=ip.property_id \r\n                            where {0} ip.property_type_d=", propertytype);
                if (itemID != (long)-1)
                {
                    str = string.Format(" tsd.item_id={0} and ", itemID);
                }
                dataTable = this.conDB.GetDataTable(string.Format(str1, str));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }




        public DataTable getItemInvoicePrint(string itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select invoiceno from invoiceprint where invoiceno='" + itemId + "'");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }
        private ArrayList AddMainDeailInsertAdditionalInfo(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID, DateTime ChallanDate, string purchaseType)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                contructualProductionIssueDAO.additionalInfoId = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('additional_info_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_production_rcv_additional(\r\n                                additional_info_id, purchase_challan_id, item_id,status, property_id1, property_id2, property_id3, \r\n                                property_id4, property_id5, property_id1_value, property_id2_value, property_id3_value, \r\n                                property_id4_value, property_id5_value,  User_id_insert,organization_id,org_branch_id,date_challan)\r\n    VALUES (", contructualProductionIssueDAO.additionalInfoId, ", ", ChallanID, ", ", contructualProductionIssueDAO.Item_id, ",  '", purchaseType, "', ", contructualProductionIssueDAO.Property_id1, ", ", contructualProductionIssueDAO.Property_id2, ", ", contructualProductionIssueDAO.Property_id3, ", ", contructualProductionIssueDAO.Property_id4, ",\r\n              ", contructualProductionIssueDAO.Property_id5, ", '", contructualProductionIssueDAO.Property1_Text, "',' ", contructualProductionIssueDAO.Property2_Text, "', ' ", contructualProductionIssueDAO.Property3_Text, "', '", contructualProductionIssueDAO.Property4_Text, "','", contructualProductionIssueDAO.Property5_Text, "',", contructualProductionIssueDAO.User_id_insert, ", ", num, ",", num1, ",to_timestamp('", ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        public DataSet CheckDeletedItem(SetItemDAO objItemDAO)
        {
            object[] categoryID = new object[] { "select * FROM ITEM where is_deleted=true and SUB_CATEGORY_ID=", objItemDAO.CategoryID, " and ITEM_NAME =upper('", objItemDAO.ItemName, "') and ITEM_SPECIFICATION='", objItemDAO.ItemSpecification, "'" };
            string str = string.Concat(categoryID);
            return this.DBUtil.GetDataSet(str, "Item");
        }

        public DataSet CheckExistingItem(SetItemDAO objItemDAO)
        {
            object[] categoryID = new object[] { "select * FROM ITEM where is_deleted=false and SUB_CATEGORY_ID=", objItemDAO.CategoryID, " and ITEM_NAME =upper('", objItemDAO.ItemName, "') " };
            string str = string.Concat(categoryID);
            return this.DBUtil.GetDataSet(str, "Item");
        }

        public bool checkForDuplicateCategoryName(string categoryName)
        {
            string str = string.Concat("SELECT COUNT(CATEGORY_ID) FROM ITEM_CATEGORY WHERE LOWER(CATEGORY_NAME) = LOWER('", categoryName, "') and is_deleted=false and parent_id=0");
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkForDuplicateCategoryNameInUpdate(int categoryID, string categoryName)
        {
            object[] objArray = new object[] { "SELECT COUNT(CATEGORY_ID) FROM ITEM_CATEGORY WHERE LOWER(CATEGORY_NAME) = LOWER('", categoryName, "') AND CATEGORY_ID <> ", categoryID, " and is_deleted = false" };
            string str = string.Concat(objArray);
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkForDuplicateItemName(int categoryID, string itemName, string specification)
        {
            object[] objArray = new object[] { "SELECT COUNT(ITEM_ID) FROM ITEM WHERE CATEGORY_ID = '", categoryID, "' AND LOWER(ITEM_NAME) = LOWER('", itemName, "') AND IS_DELETED = false" };
            string str = string.Concat(objArray);
            if (specification != "")
            {
                object[] objArray1 = new object[] { "SELECT COUNT(ITEM_ID) FROM ITEM WHERE CATEGORY_ID = '", categoryID, "' AND LOWER(ITEM_NAME) = LOWER('", itemName, "') AND LOWER(ITEM_SPECIFICATION) = LOWER('", specification, "') AND IS_DELETED = false" };
                str = string.Concat(objArray1);
            }
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkForDuplicateItemNameInUpdate(int categoryID, int itemID, string itemName)
        {
            object[] objArray = new object[] { "SELECT COUNT(ITEM_ID) FROM ITEM WHERE CATEGORY_ID = '", categoryID, "' AND LOWER(ITEM_NAME) = LOWER('", itemName, "') AND ITEM_ID <> ", itemID, " AND IS_DELETED = false" };
            string str = string.Concat(objArray);
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkForDuplicateItemSKU(string sku)
        {
            string str = string.Concat("SELECT COUNT(ITEM_ID) FROM ITEM WHERE LOWER(item_sku) = LOWER('", sku, "') AND IS_DELETED = false");
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkForDuplicateItemSKUinUpdate(string sku, int item_id)
        {
            object[] objArray = new object[] { "SELECT COUNT(ITEM_ID) FROM ITEM WHERE LOWER(item_sku) = LOWER('", sku, "') AND IS_DELETED = false and item_id!=", item_id };
            string str = string.Concat(objArray);
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkForDuplicateSubCategoryName(int parentID, string subCategoryName)
        {
            object[] objArray = new object[] { "SELECT COUNT(CATEGORY_ID) FROM ITEM_CATEGORY WHERE PARENT_ID = '", parentID, "' AND LOWER(CATEGORY_NAME) = LOWER('", subCategoryName, "') and is_deleted=false" };
            string str = string.Concat(objArray);
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkForDuplicateSubCategoryNameInUpdate(int parentID, int categoryID, string subCategoryName)
        {
            object[] objArray = new object[] { "SELECT COUNT(CATEGORY_ID) FROM ITEM_CATEGORY WHERE PARENT_ID = '", parentID, "' AND LOWER(CATEGORY_NAME) = LOWER('", subCategoryName, "') AND CATEGORY_ID <> ", categoryID, " and is_deleted = false" };
            string str = string.Concat(objArray);
            short num = Convert.ToInt16(this.conDB.GetSingleValue(str));
            bool flag = false;
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkIfCategoryExists(SetItemCategoryDAO objCategory)
        {
            bool flag = false;
            string str = string.Concat("select * from item_category where category_name= upper('", objCategory.CategoryName, "') and parent_id=0 and is_deleted=true");
            DataTable dataTable = this.conDB.GetDataTable(str);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool checkIfSubCategoryExists(SetItemCategoryDAO objSubCategory)
        {
            bool flag = false;
            object[] categoryName = new object[] { "select * from item_category where category_name= upper('", objSubCategory.CategoryName, "') and parent_id=", objSubCategory.ParentID, " and is_deleted=true" };
            string str = string.Concat(categoryName);
            DataTable dataTable = this.conDB.GetDataTable(str);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        public DataSet checkItemCategoryForIsLeaf(int categoryID)
        {
            string str = string.Concat("SELECT PARENT_ID,CATEGORY_LEVEL,IS_LEAF, category_type FROM ITEM_CATEGORY WHERE CATEGORY_ID = '", categoryID, "'");
            return this.conDB.GetDataSet(str, "IS_LEAF");
        }

        public bool deleteItem(int itemID)
        {
            string str = string.Concat("UPDATE ITEM SET IS_DELETED = true WHERE ITEM_ID = '", itemID, "' ");
            return this.conDB.ExecuteDML(str);
        }

        public bool DeleteItemCategory(int catgoryId)
        {
            string str = string.Concat("UPDATE item_category set is_deleted=true where category_id = ", catgoryId, " and parent_id=0");
            return this.conDB.ExecuteDML(str);
        }

        public bool DeleteItemSubCategory(int subcatgoryId)
        {
            string str = string.Concat("UPDATE item_category set is_deleted=true where category_id = ", subcatgoryId, " ");
            return this.conDB.ExecuteDML(str);
        }

        public bool deletePromo(int promoID)
        {
            string str = string.Concat("UPDATE gift_discount_plan SET IS_DELETED = true WHERE entry_ID = ", promoID, " ");
            return this.conDB.ExecuteDML(str);
        }

        public bool enableDeletedCategory(SetItemCategoryDAO objCategory)
        {
            string str = string.Concat("UPDATE item_category SET is_deleted=false where category_name= upper('", objCategory.CategoryName, "') and parent_id=0 and is_deleted=true");
            return this.conDB.ExecuteDML(str);
        }

        public bool enableDeletedItem(SetItemDAO objItemDAO)
        {
            object[] categoryID = new object[] { "update ITEM set is_deleted = false where is_deleted=true and SUB_CATEGORY_ID=", objItemDAO.CategoryID, " and ITEM_NAME =upper('", objItemDAO.ItemName, "') and ITEM_SPECIFICATION='", objItemDAO.ItemSpecification, "'" };
            string str = string.Concat(categoryID);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool enableDeletedSubCategory(SetItemCategoryDAO objSubCategory)
        {
            object[] categoryName = new object[] { "UPDATE item_category SET is_deleted=false where category_name= upper('", objSubCategory.CategoryName, "') and parent_id=", objSubCategory.ParentID, " and is_deleted=true" };
            string str = string.Concat(categoryName);
            return this.conDB.ExecuteDML(str);
        }

        public DataTable GetallBandrollreceiveQuantity(int item_id, int challanId)
        {
            object[] itemId = new object[] { "select coalesce(quantity,0) quantity from trns_bandroll_rcv_d d inner join trns_bandroll_rcv_m  m on d.challan_id=m.challan_id  where d.item_id=", item_id, " and   m.provided_challan_id=", challanId };
            string str = string.Concat(itemId);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetallBandrollRegister(int designId, int bandrollId)
        {
            object[] objArray = new object[] { "select distinct d.quantity reg_quantity,d.unit_price price,\r\n                  to_char(m.date_receive,'dd/MM/yyyy') receive_date,pm.quantity prd_quantity, '' remarks\r\n                from trns_bandroll_rcv_m m\r\n                inner join trns_bandroll_rcv_d d on m.challan_id=d.challan_id\r\n                inner join trns_production_detail pd on ( d.property_id3= pd.property_id1 or  d.property_id3=  pd.property_id2 or  d.property_id3= pd.property_id3 \r\n                or  d.property_id3= pd.property_id4 or  d.property_id3=  pd.property_id5)  and (d.property_id5=pd.property_id1 or d.property_id5=pd.property_id2 or \r\n                d.property_id5=pd.property_id3 or d.property_id5=pd.property_id4 or d.property_id5=pd.property_id5)\r\n                inner join trns_production_master pm on pd.production_id =pm.production_id\r\n                where pm.trns_status='R' and d.property_id3=", bandrollId, " and  d.property_id5=", designId, " " };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetallBandrollrequisitionChallan(int challanId)
        {
            string str = string.Concat("select * from trns_bandroll_uses_d  where challan_id=", challanId);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetAllCategory()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.conDB.GetDataTable("select distinct ic.category_id, ic.category_name \r\n                            from item_category ic\r\n                            left join item_category isc on ic.category_id = isc.parent_id\r\n                            left join item i on isc.category_id = i.sub_category_id  \r\n                            where ic.parent_id = 0 and ic.is_deleted=false");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet getAllCategoryForAddSubCategory()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY \r\n            WHERE CATEGORY_LEVEL = 1 AND IS_LEAF <> 2 AND IS_DELETED = false\r\n            and (organization_id=", num, " or is_for_all_bss_unit) ORDER BY CATEGORY_NAME ");
            return this.conDB.GetDataSet(str, "CATEGORY_ITEM");
        }

        public DataTable GetAllCategoryforDLL()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.conDB.GetDataTable("select distinct ic.category_id, ic.category_name \r\n                            from item_category ic\r\n                            left join item_category isc on ic.category_id = isc.parent_id\r\n                            left join item i on isc.category_id = i.sub_category_id  \r\n                            where ic.parent_id = 0 and i.product_type = 'R'");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getAllFieldByItemId(int itemID)
        {
            string str = string.Concat("SELECT distinct u.UNIT_ID , u.unit_name, u.unit_code, i.item_type, ct.category_id sub_category_id,ct.category_name sub_category_name,ctp.category_id,ctp.category_name,i.product_type\r\n                         FROM ITEM i \r\n                         left join trns_purchase_detail tpd on tpd.Item_id = i.Item_id\r\n                         left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n                         left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n                         left outer join ITEM_unit u on u.unit_id = i.unit_id WHERE I.ITEM_ID = ", itemID);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetAllInventoryItemByCategoryOrSubCat(SetItemDAO objItemDAO)
        {
            string str = "";
            if (objItemDAO.CategoryID != 0)
            {
                object[] categoryID = new object[] { " AND (I.CATEGORY_ID = ", objItemDAO.CategoryID, " OR CT.PARENT_ID = ", objItemDAO.CategoryID, ")" };
                str = string.Concat(categoryID);
            }
            string str1 = string.Concat("SELECT DISTINCT I.ITEM_ID, CASE coalesce(I.ITEM_SPECIFICATION,'null') WHEN 'null' THEN I.ITEM_NAME \r\n            WHEN '' THEN I.ITEM_NAME ELSE (I.ITEM_NAME||'-'|| I.ITEM_SPECIFICATION) END ITEM_NAME\r\n            FROM ITEM I inner JOIN ITEM_CATEGORY CT ON I.CATEGORY_ID = CT.CATEGORY_ID\r\n            WHERE I.IS_DELETED = false and CT.category_type = 'I'  ", str, " ORDER BY ITEM_NAME");
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str1);
        }

        public DataSet getAllInventoryItemCategory()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false  AND CATEGORY_TYPE IN ('I') ORDER BY CATEGORY_NAME ", "CATEGORY");
        }

        public DataTable getAllISubCategory(int CategoryId)
        {
            string str = "";
            str = (CategoryId != 0 ? string.Concat("select category_id,category_name,parent_id from item_category WHERE parent_ID = ", CategoryId, " AND is_deleted = false") : string.Concat("select category_id,category_name,parent_id from item_category WHERE parent_ID <> ", CategoryId, " AND is_deleted = false"));
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetAllItem()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["master_organization_id"]);
            object[] objArray = new object[] { "SELECT DISTINCT I.ITEM_ID, I.ITEM_NAME\r\n                        FROM ITEM I \r\n                        inner join org_registration_info o on o.organization_id=i.organization_id\r\n                        WHERE I.IS_DELETED = false and (I.organization_id=", num, " or is_for_all_bss_unit=true) and o.master_organization_id=", num1 };
            string str = string.Concat(objArray);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str);
        }

        public DataTable getAllItemByCategory(int CategoryId)
        {
            string str = "";
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] categoryId = new object[] { "select I.* from Item I LEFT OUTER JOIN ITEM_CATEGORY C ON C.CATEGORY_ID = I.SUB_CATEGORY_ID\r\n                where i.organization_id = ", num, " and (I.sub_category_id='", CategoryId, "' OR C.PARENT_ID = ", CategoryId, ") AND I.Is_deleted=false AND i.is_exempted = false order by item_name" };
            str = string.Concat(categoryId);
            return this.conDB.GetDataTable(str);
        }

        public DataTable getAllItemByCategoryForTaxRate()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = "";
                str = string.Concat("select I.* from Item I LEFT OUTER JOIN ITEM_CATEGORY C ON C.CATEGORY_ID = I.SUB_CATEGORY_ID\r\n                where  I.Is_deleted=false AND (I.organization_id = ", num, " OR I.is_for_all_bss_unit=true)  order by item_name");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataSet getAllItemByCategoryId(int categoryID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["master_organization_id"]);
            object[] objArray = new object[] { " SELECT distinct I.ITEM_ID,I.ITEM_NAME,C.CATEGORY_ID,C.CATEGORY_NAME,I.ITEM_SPECIFICATION,U.UNIT_NAME\r\n            --case I.PROP1_REQUIRED WHEN TRUE then 'Size' else 'N/A' END PROP1_REQUIRED,\r\n            --case I.PROP2_REQUIRED when TRUE then 'Color' else 'N/A' END PROP2_REQUIRED,\r\n            --case I.PROP3_REQUIRED when TRUE then 'Grade' else 'N/A' END PROP3_REQUIRED,\r\n            --case I.PROP4_REQUIRED when TRUE then 'Box' else 'N/A' END PROP4_REQUIRED,\r\n            --case I.PROP5_REQUIRED when TRUE then 'Specification' else 'N/A' END PROP5_REQUIRED\r\n            ,(select code_name from app_code_detail where code_id_m=5 and code_id_d=I.property_id1) AS PROP1_REQUIRED\r\n            ,(select code_name from app_code_detail where code_id_m=5 and code_id_d=I.property_id2) AS PROP2_REQUIRED\r\n            ,(select code_name from app_code_detail where code_id_m=5 and code_id_d=I.property_id3) AS PROP3_REQUIRED\r\n            ,(select code_name from app_code_detail where code_id_m=5 and code_id_d=I.property_id4) AS PROP4_REQUIRED\r\n            ,(select code_name from app_code_detail where code_id_m=5 and code_id_d=I.property_id5) AS PROP5_REQUIRED\r\n            ,I.ITEM_CODE,I.LEVEL_CODE, i.hs_code_heading, i.hs_code_suffix, i.hs_code, \r\n            AD.CODE_NAME  FROM ITEM I,ITEM_CATEGORY C,ITEM_UNIT U,APP_CODE_DETAIL AD ,org_registration_info o            \r\n            WHERE I.SUB_CATEGORY_ID = C.CATEGORY_ID  AND I.UNIT_ID = U.UNIT_ID  \r\n            AND I.MEASUREMENT_ID_M = AD.CODE_ID_M AND I.MEASUREMENT_ID_D = AD.CODE_ID_D \r\n            AND C.CATEGORY_ID = '", categoryID, "' AND (I.organization_id=", num, " OR I.is_for_all_bss_unit=true) AND I.IS_DELETED = false and o.master_organization_id=", num1, "\r\n            ORDER BY I.ITEM_ID" };
            string str = string.Concat(objArray);
            return this.conDB.GetDataSet(str, "ITEM");
        }

        public DataSet getAllItemByCategoryIdForOpeningBalance(int categoryID)
        {
            string str = DateTime.Now.ToString("dd/MM/yyyy");
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { " SELECT \r\n distinct\r\n --(select  tpm.purchase_type from trns_purchase_master tpm inner join trns_purchase_detail tpd on tpd.challan_id=tpm.challan_id where tpd.item_id=i.item_id and tpm.challan_type='O' limit 1),\r\nI.ITEM_ID AS ItemID,I.ITEM_NAME,C.CATEGORY_ID,C.CATEGORY_NAME,I.ITEM_SPECIFICATION,U.UNIT_NAME,U.UNIT_ID, case I.PROP1_REQUIRED WHEN TRUE then 'Size' else 'N/A' END PROP1_REQUIRED\r\n , case I.PROP2_REQUIRED when TRUE then 'Color' else 'N/A' END PROP2_REQUIRED, case I.PROP3_REQUIRED when TRUE then 'Grade' else 'N/A' END PROP3_REQUIRED\r\n , case I.PROP4_REQUIRED when TRUE then 'Company' else 'N/A' END PROP4_REQUIRED, case I.PROP5_REQUIRED when TRUE then 'Specification' else 'N/A' END PROP5_REQUIRED\r\n , I.ITEM_CODE,I.LEVEL_CODE, i.hs_code_heading, i.hs_code_suffix, i.hs_code--,  AD.CODE_NAME\r\n--,ol.item_qty,ol.item_value  \r\n--,COALESCE(ol.item_qty,0) item_qty,COALESCE(ol.item_value,0) item_value,case when to_Char(ol.opening_balance_date,'dd/MM/yyyy') is null then '", str, "' else to_Char(ol.opening_balance_date,'dd/MM/yyyy')\r\n--end   opening_balance_date\r\n,case when  exists(select COALESCE(item_value,0) from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1) then\r\nCOALESCE((select COALESCE(item_value,0) from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1),0)  else 0 end item_value\r\n,case when  exists(select COALESCE(item_qty,0) from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1) then\r\nCOALESCE((select COALESCE(item_qty,0) from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1),0)  else 0 end item_qty\r\n,case when  exists(select COALESCE(unit_price,0) from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1) then\r\nCOALESCE((select COALESCE(unit_price,0) from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1),0)  else 0 end unit_price\r\n\r\n,case when  exists(select opening_balance_date from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1) then\r\n(select to_Char(opening_balance_date,'dd/MM/yyyy') from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1)  else '", str, "' end opening_balance_date\r\n,case when  exists(select purchase_type from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1) then\r\n(select purchase_type from opening_balance where organization_id=", num, " and org_branch_reg_id=", num1, " and item_id=i.item_id limit 1)  else '' end purchase_type\r\n\r\n FROM ITEM I\r\n inner join ITEM_CATEGORY C ON I.SUB_CATEGORY_ID = C.CATEGORY_ID\r\n inner join ITEM_UNIT U ON I.UNIT_ID = U.UNIT_ID\r\n inner join APP_CODE_DETAIL AD ON I.MEASUREMENT_ID_M = AD.CODE_ID_M\r\n inner join APP_CODE_DETAIL AD1 ON I.MEASUREMENT_ID_D = AD1.CODE_ID_D\r\n --LEFT join opening_balance ol ON I.item_id = ol.item_id\r\n --inner join trns_purchase_detail tpd on tpd.item_id=ol.item_id\r\n --inner join trns_purchase_master tpm on tpd.challan_id=tpm.challan_id\r\n WHERE C.CATEGORY_ID = ", categoryID, " AND I.IS_DELETED = false  AND (i.organization_id=", num, " or i.is_for_all_bss_unit=true)\r\n --and ol.org_branch_reg_id=", num1, " \r\n  ORDER BY I.ITEM_ID" };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataSet(str1, "ITEM");
        }

        public DataTable GetAllItemByCategoryOrSubCat(SetItemDAO objItemDAO)
        {
            string str = "";
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            if (objItemDAO.CategoryID > 0)
            {
                object[] categoryID = new object[] { " AND (I.SUB_CATEGORY_ID = ", objItemDAO.CategoryID, " OR CT.PARENT_ID = ", objItemDAO.CategoryID, ")" };
                str = string.Concat(categoryID);
            }
            if (objItemDAO.CatagoryTyp == "Goods")
            {
                str = " AND I.ITEM_TYPE='I' ";
            }
            if (objItemDAO.CatagoryTyp == "Service")
            {
                str = " AND I.ITEM_TYPE='S' ";
            }
            if (objItemDAO.CatagoryTyp == "Both")
            {
                str = " AND (I.ITEM_TYPE='S'  OR I.ITEM_TYPE='I') ";
            }
            object[] objArray = new object[] { "SELECT DISTINCT I.ITEM_ID, I.PRODUCT_TYPE,i.item_sku , CASE coalesce(I.ITEM_SPECIFICATION,'null') WHEN 'null' THEN I.ITEM_NAME||'-'||i.item_sku \r\n            WHEN '' THEN I.ITEM_NAME||'-'||i.hs_code||'-'||i.item_sku ELSE (I.ITEM_NAME||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku) END ITEM_NAME\r\n            FROM ITEM I LEFT OUTER JOIN ITEM_CATEGORY CT ON I.SUB_CATEGORY_ID = CT.CATEGORY_ID\r\n            WHERE (I.ORGANIZATION_ID =", num, " OR I.is_for_all_bss_unit=true) AND I.product_type!='C' and I.IS_DELETED = false  ", str, " ORDER BY ITEM_NAME" };
            string str1 = string.Concat(objArray);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getAllItemByCategoryWithoutFilter()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = "";
            str = string.Concat("select I.* from Item I LEFT OUTER JOIN ITEM_CATEGORY C ON C.CATEGORY_ID = I.SUB_CATEGORY_ID\r\n                where  I.Is_deleted=false AND i.is_exempted = false and (i.organization_id=", num, " or i.is_for_all_bss_unit=true) order by item_name");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetAllItemByCatSubCat(SetItemDAO objItemDAO)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            if (objItemDAO.CategoryID > 0)
            {
                object[] categoryID = new object[] { " AND (ic.category_id = ", objItemDAO.CategoryID, " OR CT.PARENT_ID = ", objItemDAO.CategoryID, ")" };
                string.Concat(categoryID);
            }
            string empty = string.Empty;
            if (objItemDAO.CatagoryTyp == "B")
            {
                object[] objArray = new object[] { "SELECT  I.PRODUCT_TYPE, tpd.purchase_type,\r\n                        --CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                        --    when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                        --    when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                        CASE when tpd.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku\r\n                            when tpd.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku \r\n                            when tpd.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku END ITEM_NAME,\r\n\r\n                            --case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            --when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            --when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                            case when tpd.purchase_type = 'L' then i.item_id+.1\r\n                            when tpd.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpd.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n                            , i.order_by,i.item_sku,i.item_specification,i.unit_id\r\n\r\n                        FROM ITEM as i \r\n                        inner JOIN ITEM_CATEGORY as ic ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner  join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  AND tpm.organization_id = ", num, " and tpd.quantity!=0           \r\n                      \r\n                       union\r\n\t\t               select I.PRODUCT_TYPE,'' AS purchase_type, i.item_name ||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku ,i.item_id,order_by,i.item_sku,i.item_specification,i.unit_id\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE='W' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)\r\n                        --ORDER BY item_name\r\n                       union\r\n                  select I.PRODUCT_TYPE, '' AS purchase_type,\r\n                        CASE when i.item_type = 'S' then i.item_name ||'-'||'Service'||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku end ITEM_NAME,\r\n                        case when i.item_type = 'S' then i.item_id end ITEM_ID,order_by,i.item_sku,i.item_specification,i.unit_id\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.item_type='S' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)" };
                empty = string.Concat(objArray);
            }
            if (objItemDAO.CatagoryTyp == "G")
            {
                object[] objArray1 = new object[] { "SELECT  I.PRODUCT_TYPE, tpd.purchase_type,\r\n\r\n                        CASE when tpd.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku\r\n                            when tpd.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code ||'-'||i.item_sku\r\n                            when tpd.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku END ITEM_NAME,\r\n                            case when tpd.purchase_type = 'L' then i.item_id+.1\r\n                            when tpd.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpd.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n                            , i.order_by,i.item_sku,i.item_specification\r\n\r\n                        FROM ITEM as i \r\n                        inner JOIN ITEM_CATEGORY as ic ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner  join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  AND tpm.organization_id = ", num, "  and tpd.quantity!=0       \r\n                      \r\n                       union\r\n\t\t               select I.PRODUCT_TYPE,'' AS purchase_type, i.item_name ||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku ,i.item_id,order_by,i.item_sku,i.item_specification\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE='W' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)\r\n                        ORDER BY item_name" };
                empty = string.Concat(objArray1);
            }
            if (objItemDAO.CatagoryTyp == "S")
            {
                object[] objArray2 = new object[] { "select I.PRODUCT_TYPE, \r\n                        CASE when i.item_type = 'S' then i.item_name ||'-'||'Service'||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku end ITEM_NAME,\r\n                        case when i.item_type = 'S' then i.item_id end ITEM_ID,order_by,i.item_sku,i.item_specification\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.item_type='S' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)\r\n\r\n                       union\r\n                 select I.PRODUCT_TYPE, i.item_name ||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku ,i.item_id,order_by,i.item_sku,i.item_specification\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE='W' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)\r\n                        ORDER BY item_name" };
                empty = string.Concat(objArray2);
            }
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(empty);
        }

        public DataSet getAllItemByFilter(string strItemId)
        {
            string str = "";
            str = string.Concat("select item_name,branch_name,order_by from item \r\n            where i.Is_deleted=false ", strItemId, " true order by order_by ");
            return this.conDB.GetDataSet(str, "Item");
        }

        public DataTable GetAllItemByProdType(SetItemDAO objItemDAO, string productType)
        {
            string str = "";
            if (objItemDAO.CategoryID > 0)
            {
                object[] categoryID = new object[] { " AND (I.SUB_CATEGORY_ID = ", objItemDAO.CategoryID, " OR CT.PARENT_ID = ", objItemDAO.CategoryID, ")" };
                str = string.Concat(categoryID);
            }
            string[] strArrays = new string[] { "SELECT DISTINCT I.ITEM_ID, CASE coalesce(I.ITEM_SPECIFICATION,'null') WHEN 'null' THEN I.ITEM_NAME \r\n            WHEN '' THEN I.ITEM_NAME||'-'||i.hs_code ELSE (I.ITEM_NAME||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code) END ITEM_NAME\r\n            FROM ITEM I LEFT OUTER JOIN ITEM_CATEGORY CT ON I.SUB_CATEGORY_ID = CT.CATEGORY_ID\r\n\r\n            WHERE I.IS_DELETED = false and I.PRODUCT_TYPE = '", productType, "' AND I.ITEM_TYPE = 'I' ", str, " ORDER BY ITEM_NAME" };
            string str1 = string.Concat(strArrays);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetAllItemByProductType(string type)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] objArray = new object[] { "SELECT DISTINCT I.ITEM_ID, I.ITEM_NAME\r\n                        FROM ITEM I \r\n                         WHERE I.IS_DELETED = false and product_type='", type, "'and (I.organization_id=", num, " or is_for_all_bss_unit=true)" };
            string str = string.Concat(objArray);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str);
        }

        public DataSet getAllItemCategory()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false  AND CATEGORY_TYPE IN ( 'I', 'S', 'U') ORDER BY CATEGORY_NAME ", "CATEGORY");
        }

        public DataSet getAllItemCategoryWithLAB()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false AND CATEGORY_TYPE IN ('I', 'P', 'L')  ORDER BY CATEGORY_NAME ", "CATEGORY");
        }

        public DataTable GetAllItemForPurchasebyCatgSubCatg(SetItemDAO objItemDAO)
        {
            string str = "";
            if (objItemDAO.CategoryID > 0 && objItemDAO.SubCatgID <= 0)
            {
                str = string.Concat(" AND ic.category_id = ", objItemDAO.CategoryID);
            }
            else if (objItemDAO.CategoryID > 0 && objItemDAO.SubCatgID > 0)
            {
                str = string.Concat(" AND isc.category_id = ", objItemDAO.SubCatgID);
            }
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select distinct i.item_id, i.item_name\r\n                                from item i                               \r\n                                inner JOIN ITEM_CATEGORY as isc ON i.SUB_CATEGORY_ID = isc.category_id\r\n                                inner join ITEM_CATEGORY as ic ON isc.parent_id = ic.category_id\r\n                                where i.is_deleted = false AND (i.organization_id = ", num, "  or i.is_for_all_bss_unit=true) ", str };
                string str1 = string.Concat(objArray);
                dataTable = this.conDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllItemForSalebyCatgSubCatg(SetItemDAO objItemDAO)
        {
            string str = "";
            if (objItemDAO.CategoryID > 0 && objItemDAO.SubCatgID <= 0)
            {
                str = string.Concat(" AND ic.category_id = ", objItemDAO.CategoryID);
            }
            else if (objItemDAO.CategoryID > 0 && objItemDAO.SubCatgID > 0)
            {
                str = string.Concat(" AND isc.category_id = ", objItemDAO.SubCatgID);
            }
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select distinct tsd.item_id, i.item_name\r\n                                from trns_sale_detail tsd\r\n                                inner join item i on tsd.item_id = i.item_id\r\n                                inner JOIN ITEM_CATEGORY as isc ON i.SUB_CATEGORY_ID = isc.category_id\r\n                                inner join ITEM_CATEGORY as ic ON isc.parent_id = ic.category_id\r\n                                where tsd.is_deleted = false AND (i.organization_id = ", num, "  or i.is_for_all_bss_unit=true) ", str };
                string str1 = string.Concat(objArray);
                dataTable = this.conDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getAllItems()
        {
            return this.conDB.GetDataTable("select\r\n                        i.item_id, i.item_name, i.hs_code,\r\n                        ic.category_id, ic.category_name,\r\n                        iu.unit_id, iu.unit_name\r\n                        from item i\r\n                        inner join item_category ic on ic.category_id = i.sub_category_id\r\n                        inner join item_unit iu on iu.unit_id = i.unit_id\r\n                        where i.is_deleted = false");
        }

        public DataSet getAllItemSubCategory()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            string str = string.Concat("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE (CATEGORY_LEVEL = 2 OR (CATEGORY_LEVEL = 1 AND IS_LEAF = 2)) and organization_id=", num, "  AND IS_DELETED = false  ORDER BY CATEGORY_NAME ");
            return this.conDB.GetDataSet(str, "CATEGORY");
        }

        public DataSet getAllPropertyNameForItem()
        {
            string str = string.Concat("SELECT CODE_ID_D,CODE_NAME FROM APP_CODE_DETAIL WHERE CODE_ID_M = '", AllConstraint.PropertyTypeM, "' AND CODE_VALUE_1ST = 1 ORDER BY CODE_ID_D ");
            return this.conDB.GetDataSet(str, "PROPERTY");
        }

        public DataTable GetAllSubCategory()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.conDB.GetDataTable("select distinct ic.category_id, ic.category_name \r\n                            from item_category ic\r\n                            left join item_category isc on ic.category_id = isc.parent_id\r\n                            left join item i on isc.category_id = i.sub_category_id  \r\n                            where ic.parent_id != 0 and ic.is_deleted=false");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getAllUnit()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.conDB.GetDataTable("select unit_id, unit_name, unit_code from item_unit where is_deleted = false");
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ReallySimpleLog.WriteLog(exception);
                throw exception;
            }
            return dataTable;
        }

        public DataTable getAllUnitByUnitID(int unitID)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select unit_id, unit_name, unit_code from item_unit\r\n                                where measurement_id_d = (select measurement_id_d from item_unit where unit_id = ", unitID, ")");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ReallySimpleLog.WriteLog(exception);
                throw exception;
            }
            return dataTable;
        }

        public DataTable getAllUnitByUnitName(string unitName)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select unit_id, unit_name, unit_code from item_unit\r\n                           where Upper(unit_name) ='", unitName, "'");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ReallySimpleLog.WriteLog(exception);
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetAppCodeDetailName(short dtlId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select code_name from app_code_detail where code_id_m=5 and code_id_d = ", dtlId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getAvailStock(int ItemID, DateTime saleDate)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] str = new object[] { " SELECT coalesce((\r\n            ( \r\n           \r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.approver_stage='F'\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " and M.is_trns_accepted=true AND M.ORG_BRANCH_REG_ID =", num1, "  and M.CHALLAN_TYPE in ('P', 'F', 'R','C','O'))\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n            -\r\n             ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND M.trns_status = 'I' ))\r\n           -\r\n            ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and D.installment_status=false  and d.approver_stage='F'\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "   \r\n            and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n          -\r\n          ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          \r\n           --transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false)\r\n\r\n            ----- deduct gift items from stock while saling by sabbir 24/2/21\r\n\t\t\t-\r\n\t\t\t(select coalesce(sum(quantity),0) from gift_items_detail where item_id= ", ItemID, " AND organization_id=", num, " AND \r\n            org_branch_id=", num1, " AND is_deleted=false)\r\n\r\n           +\r\n            --transfer receive will be added(If receive from transfer then purchase table CHALLAN_TYPE = T)\r\n           (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n           AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false)\r\n\r\n          ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable  FROM ITEM i \r\n\t      left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n          inner join item_category ic on ic.category_id = i.sub_category_id\r\n          WHERE I.ITEM_ID = ", ItemID, "  " };
                string str1 = string.Concat(str);
                dataTable = this.conDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAvgPricebyItemID(int itemID)
        {
            string str = string.Concat(" select avg(d.quantity) quantity,avg(d.quantity*d.purchase_unit_price) total_price,d.unit_id from trns_purchase_master m \r\n                        inner join trns_purchase_detail d on m.challan_id =d.challan_id  \r\n                            where d.item_id = '", itemID, "'  group by d.unit_id");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetBandrollrequisitionChallan()
        {
            return this.conDB.GetDataTable("select challan_id,challan_no from trns_bandroll_uses_m  ORDER BY challan_id");
        }

        public DataTable getBatchNo(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select batch_no from trns_production_master where finish_product_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public List<Category> getCategory()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            List<Category> categories = new List<Category>();
            DataTable dataTable = this.conDB.GetDataTable(string.Concat("select distinct ic.parent_id from item_category as ic inner join item as i on ic.category_id = i.sub_category_id where  i.organization_id=", num, " and ic.is_deleted = false"));
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    int num1 = Convert.ToInt32(dataTable.Rows[i]["parent_id"].ToString());
                    DataTable dataTable1 = this.conDB.GetDataTable(string.Concat("select distinct ic.category_name, ic.category_id from item_category as ic inner join item as i on ic.category_id = ", num1, " and ic.is_deleted = false"));
                    Category category = new Category()
                    {
                        CatName = dataTable1.Rows[0]["category_name"].ToString(),
                        CatID = Convert.ToInt32(dataTable1.Rows[0]["category_id"].ToString())
                    };
                    categories.Add(category);
                }
            }
            return categories;
        }

        public DataTable getCategoryByItemType(string type)
        {
            string str = string.Concat("SELECT distinct CATEGORY_ID,CATEGORY_NAME from item_category as ic inner join item as i on ic.category_id = i.sub_category_id where  ic.IS_DELETED = false and i.product_type = '", type, "' ORDER BY CATEGORY_NAME ");
            return this.conDB.GetDataTable(str);
        }

        public DataSet getCategoryByProductType(string productType)
        {
            string[] strArrays = new string[] { "SELECT D.CATEGORY_ID, D.CATEGORY_NAME FROM (\r\n                        SELECT DISTINCT C.CATEGORY_ID, C.CATEGORY_NAME\r\n                        FROM ITEM I INNER JOIN ITEM_CATEGORY C ON C.CATEGORY_ID = I.SUB_CATEGORY_ID \r\n                         WHERE I.PRODUCT_TYPE = '", productType, "' AND I.ITEM_TYPE = 'I' AND I.IS_DELETED = false\r\n                         AND C.CATEGORY_LEVEL = 1 AND C.is_leaf = 2\r\n                        UNION ALL\r\n                         SELECT DISTINCT  C.CATEGORY_ID, C.CATEGORY_NAME\r\n                        FROM ITEM I INNER JOIN ITEM_CATEGORY SC ON SC.CATEGORY_ID = I.SUB_CATEGORY_ID \r\n                        INNER JOIN ITEM_CATEGORY C ON C.CATEGORY_ID = SC.PARENT_ID\r\n                        AND C.CATEGORY_LEVEL = 1 AND C.is_leaf = 1 AND I.IS_DELETED = false\r\n                         WHERE I.PRODUCT_TYPE = '", productType, "' AND I.ITEM_TYPE = 'I')\r\n                          D ORDER BY D.CATEGORY_NAME" };
            string str = string.Concat(strArrays);
            return this.conDB.GetDataSet(str, "CATEGORY");
        }

        public DataTable GetCategoryBySubCategoryID(int SubCatgID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] subCatgID = new object[] { "select ic.category_id, ic.category_name \r\n                            from item_category ic\r\n                             inner join item_category isc on ic.category_id = isc.parent_id\r\n                            where ic.is_deleted = false and ic.organization_id=", num, " and isc.category_id = ", SubCatgID };
                string str = string.Concat(subCatgID);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataSet getCategoryByType(string catType)
        {
            string str = string.Concat("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false  AND CATEGORY_TYPE = '", catType, "' ORDER BY CATEGORY_NAME ");
            return this.conDB.GetDataSet(str, "CATEGORY");
        }

        public DataTable GetCategoryIdbyCategory(string CategoryName)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct ic.category_id, ic.category_name \r\n                            from item_category ic                             \r\n                            where ic.parent_id = 0 and ic.is_deleted=false and upper(category_name)='", CategoryName, "'");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet GetCategoryInfoByCategory(string categoryID)
        {
            string str = string.Concat("SELECT * FROM ITEM_CATEGORY WHERE LOWER(CATEGORY_NAME) LIKE LOWER('", categoryID, "%') AND IS_DELETED = false and parent_id=0");
            return this.conDB.GetDataSet(str, "DATA");
        }

        public DataSet GetCategoryInfoByCategoryID(int categoryID)
        {
            string str = string.Concat("SELECT * FROM ITEM_CATEGORY WHERE CATEGORY_ID = '", categoryID, "' AND IS_DELETED = false");
            return this.conDB.GetDataSet(str, "DATA");
        }

        public DataTable GetChallan_id(short itemId)
        {
            string str = string.Concat("select pd.challan_id  from trns_purchase_detail pd inner join trns_purchase_master pm on pm.challan_id=pd.challan_id\r\n            where ITEM_ID=", itemId, " and pm.challan_type='O' ");
            return this.conDB.GetDataTable(str);
        }

        public DataSet GetChallanID(int itemId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select tpd.challan_id,tpd.quantity from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpd.challan_id=tpm.challan_id  where ITEM_ID=", itemId, " and tpm.organization_id=", num, " and tpm.org_branch_reg_id=", num1, " and tpm.challan_type='O'" };
            string str = string.Concat(objArray);
            return this.conDB.GetDataSet(str, "DATA");
        }

        public DataTable GetChallanIdItem(int itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { " select tpm.challan_id,tpm.challan_no  \r\n                          from trns_purchase_detail tpd \r\n                          inner join trns_purchase_master tpm on tpd.challan_id=tpm.challan_id\r\n                          where tpd.item_id=", itemID, " AND tpm.organization_id = ", num, " and tpd.quantity!=0" };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable getFinishGoodsByCategoryId(int CategoryId)
        {
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            string str1 = string.Concat(" select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code||'-'||i.item_sku) END item_name\r\n                               from Item i\r\n                               left outer join item_category ic\r\n                               on i.sub_category_id = ic.category_id\r\n                               inner join trns_purchase_detail as d\r\n                               on d.item_id = i.item_id\r\n                               where i.Is_deleted = false and i.product_type = 'P' ", str, " ORDER BY item_name");
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetFinishGoodsProduct()
        {
            return this.conDB.GetDataTable("select DISTINCT item_id,item_name from item where Is_deleted = false and product_type = 'C' ORDER BY item_name");
        }

        public DataTable getFinishGoodsProductByCategoryId(int CategoryId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = "";
                if (CategoryId > 0)
                {
                    object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                    str = string.Concat(categoryId);
                }
                object[] objArray = new object[] { "SELECT I.PRODUCT_TYPE, tpd.purchase_type,       \r\n                                  CASE when tpd.purchase_type = 'L' then i.item_name || '-' || 'Local' || '-' || I.ITEM_SPECIFICATION || '-' || i.hs_code\r\n                            when tpd.purchase_type = 'I' then i.item_name || '-' || 'Import' || '-' || I.ITEM_SPECIFICATION || '-' || i.hs_code\r\n                            when tpd.purchase_type = 'F' then i.item_name || '-' || 'Production' || '-' || I.ITEM_SPECIFICATION || '-' || i.hs_code||'-'||i.item_sku END ITEM_NAME,\r\n                            i.item_id,i.product_type   , i.order_by,i.item_sku,i.item_specification\r\n\r\n                        FROM ITEM as i\r\n                        inner JOIN ITEM_CATEGORY as ic ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false and tpd.purchase_type!= '' AND tpm.organization_id = ", num, " ", str, "\r\n                        union\r\n                       select I.PRODUCT_TYPE,'' AS purchase_type, i.item_name || '-' || i.ITEM_SPECIFICATION || '-' || i.hs_code ,i.item_id,i.product_type,order_by,i.item_sku,i.item_specification\r\n                              from item as i\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE = 'W' AND(i.organization_id = ", num, " OR i.is_for_all_bss_unit = true)\r\n                        ORDER BY item_name" };
                string str1 = string.Concat(objArray);
                dataTable = this.conDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetFinishGoodsProductByCategoryIdNew(int CategoryId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                if (CategoryId > 0)
                {
                    object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                    string.Concat(categoryId);
                }
                object[] objArray = new object[] { "SELECT I.PRODUCT_TYPE, tpd.purchase_type,\r\n                        --CASE when tpm.purchase_type = 'L' then i.item_name || '-' || 'Local' || '-' || I.ITEM_SPECIFICATION || '-' || i.hs_code\r\n                        --    when tpm.purchase_type = 'I' then i.item_name || '-' || 'Import' || '-' || I.ITEM_SPECIFICATION || '-' || i.hs_code\r\n                        --    when tpm.purchase_type = 'F' then i.item_name || '-' || 'Production' || '-' || I.ITEM_SPECIFICATION || '-' || i.hs_code END ITEM_NAME,\r\n\r\n                        CASE when tpd.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku\r\n                            when tpd.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku \r\n                            when tpd.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code||'-'||i.item_sku END ITEM_NAME,\r\n\r\n                              case when tpd.purchase_type = 'L' then i.item_id + .1\r\n                            when tpd.purchase_type = 'I' then i.item_id + .2\r\n                            when tpd.purchase_type = 'F' then i.item_id + .3 end ITEM_ID\r\n\r\n                            --i.item_id\r\n                            ,i.product_type \r\n                              , i.order_by,i.item_sku,i.item_specification\r\n\r\n                        FROM ITEM as i\r\n                        inner JOIN ITEM_CATEGORY as ic ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  AND tpm.organization_id = ", num, "\r\n                        union\r\n                       select I.PRODUCT_TYPE,'' AS purchase_type, i.item_name || '-' || i.ITEM_SPECIFICATION || '-' || i.hs_code||'-'||i.item_sku ,i.item_id,i.product_type,order_by,i.item_sku,i.item_specification\r\n                              from item as i\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE = 'W' AND(i.organization_id = ", num, " OR i.is_for_all_bss_unit = true)\r\n                        ORDER BY item_name" };
                string str = string.Concat(objArray);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getFinishGoodsProductByCategoryIdPrChallan(int CategoryId, string prChallan)
        {
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            string[] strArrays = new string[] { "select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name,pm.price_id\r\n                               from Item i\r\n                               --inner join trns_production_detail pd on i.item_id=pd.item_id\r\n                               inner join trns_production_master pm on i.item_id=pm.finish_product_id\r\n                               left outer join item_category ic on i.sub_category_id = ic.category_id\r\n                               where i.Is_deleted = false and pm.challan_batch_no='", prChallan, "' \r\n                               and i.product_type = 'C'  and pm.trns_status='I'", str, " ORDER BY item_name" };
            string str1 = string.Concat(strArrays);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getFinishGoodsProductByCategoryIdPriceDecId(int CategoryId, int prChallan)
        {
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            object[] objArray = new object[] { "select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name,ic.category_id subcategory_id,ic.category_name subcategory_name\r\n                             ,ctp.category_id,ctp.category_name\r\n                               from Item i\r\n                               --inner join trns_production_detail pd on i.item_id=pd.item_id\r\n                               inner join price_item pm on i.item_id=pm.item_id\r\n                               left outer join item_category ic on i.sub_category_id = ic.category_id\r\n                               left join ITEM_category ctp on ctp.category_id = ic.parent_id\r\n                               where i.Is_deleted = false and pm.price_id=", prChallan, " \r\n                               and i.product_type = 'C' ", str, " ORDER BY item_name" };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetFinishGoodsProduction()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select DISTINCT item_id,item_name from item where Is_deleted = false and product_type = 'C' and is_price_declaration=true and organization_id = ", num, "  ORDER BY item_name");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetFinishGoodsProductionBiriCigarate()
        {
            return this.conDB.GetDataTable("select * from item  where (hs_code='2402.20.00' Or hs_code='2402.90.00') And Is_deleted = false ORDER BY item_name");
        }

        public DataTable GetFinishProductByPartyID(int partyID)
        {
            string str = string.Concat("select distinct i.product_type,i.item_id, \r\n                            CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name\r\n                        from trns_production_master as tpm\r\n                        inner join item as i\r\n                        on i.item_id = tpm.finish_product_id\r\n                        where tpm.party_id = ", partyID, " and  tpm.trns_status = 'I'");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetFinishProductForSelfByPartyID(int partyID)
        {
            string str = string.Concat("select distinct i.product_type,i.item_id, \r\n                            CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name\r\n                        from trns_production_master as tpm\r\n                        inner join item as i\r\n                        on i.item_id = tpm.finish_product_id\r\n                        where tpm.party_id = ", partyID, " and  tpm.trns_status = 'S'");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetFinishProductSelfProduct()
        {
            return this.conDB.GetDataTable("select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name\r\n                        from item as i\r\n                        inner join trns_production_master as m\r\n                        on i.item_id = m.finish_product_id\r\n                        where m.material_type='I' AND m.trns_status='S'");
        }

        public DataTable getGiftDiscountPromos(DateTime presentDay)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] str = new object[] { "select gdf.parent_item_id, ip.item_name parent_item_name, gdf.parent_item_unit, iup.unit_code parent_unit_code, gdf.gift_item_id,  gdf.gift_item_code,\r\n                    ig.item_name gift_item_name, gdf.gift_unit_id, iug.unit_code gift_unit_code, gdf.parent_item_qnt, gdf.gift_qnt, gdf.discount_percentage, gdf.discount_amount,\r\n                    gdf.is_on_item_gift, gdf.is_on_sale_gift, gdf.date_from, gdf.date_to, gdf.remarks\r\n                    from gift_discount_plan gdf\r\n                    left join item ip on gdf.parent_item_id=ip.item_id \r\n                    left join item ig on gdf.gift_item_id=ig.item_id\r\n                    left join item_unit iup on gdf.parent_item_unit = iup.unit_id\r\n                    left join item_unit iug on gdf.gift_unit_id = iug.unit_id\r\n                    where TO_DATE('", presentDay.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')>=gdf.date_from AND TO_DATE('", presentDay.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy') <= gdf.date_to\r\n                    And gdf.organization_id=", num, " AND gdf.Is_deleted = false " };
            string str1 = string.Concat(str);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getGiftDiscountPromos()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select gdf.entry_id,gdf.parent_item_id, ip.item_name parent_item_name, gdf.parent_item_unit, \r\n                        iup.unit_code parent_unit_code, gdf.gift_item_id, ig.item_name gift_item_name, gdf.gift_item_code, gdf.gift_unit_id, \r\n                        iug.unit_code gift_unit_code, gdf.parent_item_qnt, gdf.gift_qnt, gdf.discount_percentage, gdf.min_sale_amount,\r\n                        gdf.discount_amount, gdf.is_on_item_gift, gdf.is_on_sale_gift,\r\n                        case when  gdf.is_on_sale_gift=true then 'ON SALE'\r\n                        else 'ON ITEM'\r\n                        end promo_type,\r\n                        gdf.date_from, gdf.date_to, gdf.remarks\r\n                        from gift_discount_plan gdf\r\n                        left join item ip on gdf.parent_item_id=ip.item_id \r\n                        left join item ig on gdf.gift_item_id=ig.item_id\r\n                        left join item_unit iup on gdf.parent_item_unit = iup.unit_id\r\n                        left join item_unit iug on gdf.gift_unit_id = iug.unit_id\r\n                        where gdf.organization_id=", num, " AND gdf.Is_deleted = false \r\n\t\t\t\t\t\torder by gdf.date_planned DESC");
            return this.conDB.GetDataTable(str);
        }

        public DataTable getGiftDiscountPromosById(int id)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { "select gdf.entry_id,gdf.parent_item_id, ip.item_name parent_item_name, gdf.parent_item_unit, \r\n                        iup.unit_code parent_unit_code, gdf.gift_item_id, ig.item_name gift_item_name, gdf.gift_unit_id,  gdf.gift_item_code,\r\n                        iug.unit_code gift_unit_code, gdf.parent_item_qnt, gdf.gift_qnt, gdf.discount_percentage, gdf.min_sale_amount,\r\n                        gdf.discount_amount, gdf.is_on_item_gift, gdf.is_on_sale_gift,\r\n                        case when  gdf.is_on_sale_gift=true then 'ON SALE'\r\n                        else 'ON ITEM'\r\n                        end promo_type,\r\n                        gdf.date_from, gdf.date_to, gdf.remarks,ip.sub_category_id,ic.parent_id\r\n                        from gift_discount_plan gdf\r\n                        left join item ip on gdf.parent_item_id=ip.item_id \r\n                        left join item ig on gdf.gift_item_id=ig.item_id\r\n                        left join item_unit iup on gdf.parent_item_unit = iup.unit_id\r\n                        left join item_unit iug on gdf.gift_unit_id = iug.unit_id\r\n                        left join item_category ic on ic.category_id=ip.sub_category_id \r\n                        where gdf.organization_id=", num, " AND gdf.entry_id=", id, " AND gdf.Is_deleted = false " };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetGoodItems()
        {
            string empty = string.Empty;
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { "SELECT  I.PRODUCT_TYPE, tpm.purchase_type,\r\n                        --CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                        --    when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                        --    when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                        CASE when tpd.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpd.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpd.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            --case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            --when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            --when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                            case when tpd.purchase_type = 'L' then i.item_id+.1\r\n                            when tpd.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpd.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n                            , i.order_by,i.item_sku,i.item_specification\r\n\r\n                        FROM ITEM as i \r\n                        inner JOIN ITEM_CATEGORY as ic ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner  join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  AND tpm.organization_id = ", num, "         \r\n                      \r\n                       union\r\n\t\t               select I.PRODUCT_TYPE,'' AS purchase_type, i.item_name ||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code ,i.item_id,order_by,i.item_sku,i.item_specification\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE='W' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)\r\n                        ORDER BY item_name" };
            empty = string.Concat(objArray);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(empty);
        }

        public DataTable getGoodsByCategoryId(int CategoryId)
        {
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            string str1 = string.Concat(" select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code||'-'||i.item_sku) END item_name\r\n                               from Item i\r\n                               left join item_category ic\r\n                               on i.sub_category_id = ic.category_id\r\n                               inner join trns_purchase_detail as d\r\n                               on d.item_id = i.item_id\r\n                               where i.Is_deleted = false and i.product_type = 'F' ", str, " ORDER BY item_name");
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetHsCodeByItemID(long itemID)
        {
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            string str = string.Concat("select hs_code from item  where item_id=", itemID, " And Is_deleted = false");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetIngredienceByFinishProductID(int item_id, int priceID)
        {
            string str = "";
            if (item_id > 0 && priceID == 0)
            {
                str = string.Concat(" where pri.price_id = (select price_id from price_item where item_id = ", item_id, " order by date_effective desc limit 1)");
            }
            if (priceID > 0 && item_id == 0)
            {
                str = string.Concat(" where pri.price_id = ", priceID);
            }
            if (item_id > 0 && priceID > 0)
            {
                str = string.Concat(" where pri.price_id = ", priceID);
            }
            string str1 = string.Concat("select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name\r\n                            from item as i\r\n                            inner join price_raw_item as pri\r\n                            on i.item_id = pri.item_id ", str);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getIngredientsByCategoryId(int CategoryId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            object[] objArray = new object[] { " select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code||'-'||i.item_sku) END item_name\r\n                               from Item i\r\n                               left join item_category ic\r\n                               on i.sub_category_id = ic.category_id\r\n                               inner join trns_purchase_detail as d\r\n                               on d.item_id = i.item_id\r\n                               where i.Is_deleted = false and i.product_type = 'R' ", str, " and i.organization_id = ", num, " ORDER BY item_name" };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataTable(str1);
        }

        public DataSet getInventoryCategoryForAddSubCategory()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1 AND IS_LEAF <> 2 AND IS_DELETED = false AND (category_type = 'I' or category_type = 'L') ORDER BY CATEGORY_NAME ", "CATEGORY_ITEM");
        }

        public DataTable GetItemBoolean(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select is_mrp,is_tarrif,is_zero_rate,is_truncated,is_vds,is_rebatable,is_exempted from ITEM where item_id = ", itemId, " and is_deleted=false;");
                DataTable dataTable1 = new DataTable();
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getItemByCategoryId(int CategoryId)
        {
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            string str1 = string.Concat(" select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name\r\n                               from Item i\r\n                               left outer join item_category ic\r\n                               on i.sub_category_id = ic.category_id\r\n                               where i.Is_deleted = false ", str, " ORDER BY item_name");
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetItemByCategoryMM(int CatID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select i.item_id, i.item_name\r\n                            from item_category as ic\r\n                            inner join item_category icc on ic.category_id = icc.parent_id\r\n                            inner join item i on icc.category_id = i.sub_category_id\r\n                            where i.is_deleted = false and ic.category_id = ", CatID);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetItemByCatgSubCatgmqmm(SetItemDAO objItemDAO)
        {
            string str = "";
            if (objItemDAO.CategoryID > 0 && objItemDAO.SubCatgID <= 0)
            {
                str = string.Concat(" AND ic.category_id = ", objItemDAO.CategoryID);
            }
            else if (objItemDAO.CategoryID > 0 && objItemDAO.SubCatgID > 0)
            {
                str = string.Concat(" AND isc.category_id = ", objItemDAO.SubCatgID);
            }
            string[] strArrays = new string[] { "SELECT  I.PRODUCT_TYPE, \r\n                        CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID, i.order_by,i.item_sku,I.ITEM_SPECIFICATION\r\n\r\n                        FROM ITEM as i \r\n                        inner JOIN ITEM_CATEGORY as isc ON i.SUB_CATEGORY_ID = isc.category_id\r\n                        inner join ITEM_CATEGORY as ic ON isc.parent_id = ic.category_id\r\n                        inner  join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  ", str, " \r\n        \r\n         union\r\n\r\n                    select I.PRODUCT_TYPE, \r\n                        CASE when i.item_type = 'S' then i.item_name ||'-'||'Service'||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code end ITEM_NAME,\r\n                        case when i.item_type = 'S' then i.item_id end ITEM_ID,i.order_by,i.item_sku,I.ITEM_SPECIFICATION\r\n                        from item as i\r\n                        inner JOIN ITEM_CATEGORY as isc ON i.SUB_CATEGORY_ID = isc.category_id\r\n                        inner join ITEM_CATEGORY as ic ON isc.parent_id = ic.category_id\r\n                        WHERE I.IS_DELETED = false and i.item_type='S' ", str, " \r\n         union\r\n\t\t            select I.PRODUCT_TYPE, i.item_name ||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code ,i.item_id,i.order_by,i.item_sku,I.ITEM_SPECIFICATION\r\n                        from item as i\r\n                        inner JOIN ITEM_CATEGORY as isc ON i.SUB_CATEGORY_ID = isc.category_id\r\n                        inner join ITEM_CATEGORY as ic ON isc.parent_id = ic.category_id\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE='W' ", str, " \r\n                        ORDER BY order_by" };
            string str1 = string.Concat(strArrays);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getItemByCatSubCatId(int subCategoryId)
        {
            string str = "";
            if (subCategoryId > 0)
            {
                str = string.Concat(" AND (i.sub_category_id = ", subCategoryId, ")");
            }
            string str1 = string.Concat(" select DISTINCT i.Item_id, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name\r\n                               from Item i\r\n                               left outer join item_category ic\r\n                               on i.sub_category_id = ic.category_id\r\n                               where i.Is_deleted = false ", str, " and ic.is_deleted=false  ORDER BY item_name");
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetItemBySearch(short itemID, string itemType)
        {
            object[] objArray = new object[] { "SELECT DISTINCT I.PRODUCT_TYPE, \r\n                        CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                        FROM ITEM as i \r\n                        inner JOIN ITEM_CATEGORY as ic \r\n                        ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner  join trns_purchase_detail as tpd\r\n                        on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm\r\n                        on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  AND tpd.item_id = ", itemID, " AND tpm.purchase_type = '", itemType, "'" };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable getItemBySubCategoryandItemId(int subCategoryId, int itemId)
        {
            object[] objArray = new object[] { " select I.* from Item I \r\n                          inner JOIN ITEM_CATEGORY C ON C.CATEGORY_ID = I.SUB_CATEGORY_ID                          \r\n                          where   c.CATEGORY_id=", subCategoryId, " AND I.Is_deleted=false and i.item_id=", itemId };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetItemChallaNo(int itemID)
        {
            string str = string.Concat(" select m.challan_id,m.challan_no from trns_purchase_master m \r\n                           inner join trns_purchase_detail d on m.challan_id = d.challan_id\r\n                            where d.item_id = '", itemID, "' and d.quantity!=0 and m.challan_type in ('P','O')");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetItemDynamicProperty(int no)
        {
            string str = string.Concat("select property_name,property_id from item_property where property_type_m = 5 and property_type_d = '", no, "'");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetItemFromPriceRowItem(int itemID)
        {
            string str = string.Concat("select * from price_raw_item where item_id =", itemID);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetItemFromPurchaseDetail(int itemID)
        {
            string str = string.Concat("select * from trns_production_detail where item_id =", itemID);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetItemFromSalesDetail(int itemID)
        {
            string str = string.Concat("select * from trns_sale_detail where item_id =", itemID);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str);
        }

        public DataSet getItemInfoByItem(string item)
        {
            string str = string.Concat(" SELECT I.ITEM_ID,I.ITEM_NAME,I.brand_name,I.ITEM_CODE,C.CATEGORY_ID,C.CATEGORY_NAME,I.ITEM_SPECIFICATION,U.UNIT_ID,U.UNIT_NAME,I.PROP1_REQUIRED,I.PROP2_REQUIRED,I.PROP3_REQUIRED,I.PROP4_REQUIRED,I.PROP5_REQUIRED,  i.hs_code_heading, i.hs_code_suffix,I.ITEM_CODE,I.LEVEL_CODE,I.SUPPLIER_REQUIRED, I.expiry_date_required, i.is_truncated,i.is_tarrif, i.is_exempted,i.is_zero_rate,i.is_rebatable,i.is_mrp,i.is_vds,i.model_no,i.item_type,i.product_type, i.vat_rebate,i.is_reusable,i.is_for_all_bss_unit,is_item_set,is_healthcare_surcharge,is_price_declaration,  AD.CODE_NAME MSRMT_TYPE_D,AD.CODE_ID_D MSRMT_TYPE_ID,C.PARENT_ID, I.ITEM_SKU, I.weight, I.weight_unit_id FROM ITEM I,ITEM_CATEGORY C,ITEM_UNIT U,APP_CODE_DETAIL AD  WHERE I.SUB_CATEGORY_ID = C.CATEGORY_ID  AND I.UNIT_ID = U.UNIT_ID    AND I.MEASUREMENT_ID_M = AD.CODE_ID_M AND I.MEASUREMENT_ID_D = AD.CODE_ID_D  AND LOWER(I.ITEM_NAME) Like  LOWER('", item, "%')");
            return this.conDB.GetDataSet(str, "ITEM");
        }

        public DataSet getItemInfoByItemID(int itemID)
        {
            string str = string.Concat(" SELECT i.is_item_set,I.is_healthcare_surcharge,I.is_price_declaration,I.ITEM_ID,I.ITEM_NAME,I.brand_name,I.ITEM_CODE,C.CATEGORY_ID,C.CATEGORY_NAME,I.ITEM_SPECIFICATION,U.UNIT_ID,U.UNIT_NAME,I.PROP1_REQUIRED,I.PROP2_REQUIRED,I.PROP3_REQUIRED,I.PROP4_REQUIRED,I.PROP5_REQUIRED,  i.hs_code_heading, i.hs_code_suffix,I.ITEM_CODE,I.LEVEL_CODE,I.SUPPLIER_REQUIRED, I.expiry_date_required, i.is_truncated,i.is_tarrif, i.is_exempted,i.is_zero_rate,i.is_rebatable,i.is_mrp,i.is_vds,i.model_no,i.item_type,i.product_type, i.vat_rebate,i.is_for_all_bss_unit,i.is_reusable,coalesce(i.property_id1,0) property_id1,coalesce(i.property_id2,0) property_id2,coalesce(i.property_id3,0) property_id3,coalesce(i.property_id4,0) property_id4,coalesce(i.property_id5,0) property_id5, AD.CODE_NAME MSRMT_TYPE_D,AD.CODE_ID_D MSRMT_TYPE_ID,C.PARENT_ID, I.ITEM_SKU,I.weight,I.weight_unit_id FROM ITEM I,ITEM_CATEGORY C,ITEM_UNIT U,APP_CODE_DETAIL AD  WHERE I.SUB_CATEGORY_ID = C.CATEGORY_ID  AND I.UNIT_ID = U.UNIT_ID    AND I.MEASUREMENT_ID_M = AD.CODE_ID_M AND I.MEASUREMENT_ID_D = AD.CODE_ID_D  AND I.ITEM_ID = '", itemID, "'");
            return this.conDB.GetDataSet(str, "ITEM");
        }

        public DataTable GetItemInfobyItemId(int ItemId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string empty = string.Empty;
            object[] itemId = new object[] { "SELECT  I.PRODUCT_TYPE, tpm.purchase_type,                       \r\n                        CASE when tpd.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpd.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpd.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n                            case when tpd.purchase_type = 'L' then i.item_id+.1\r\n                            when tpd.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpd.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n                            , i.order_by,i.item_sku,i.item_specification,i.hs_code\r\n                        FROM ITEM as i \r\n                        inner JOIN ITEM_CATEGORY as ic ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner  join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  AND tpm.organization_id = ", num, "  and i.item_id=", ItemId, "      \r\n                      \r\n                       union\r\n\t\t               select I.PRODUCT_TYPE,'' AS purchase_type, i.item_name ||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code ,i.item_id,order_by,i.item_sku,i.item_specification,i.hs_code\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.item_id=", ItemId, " and i.PRODUCT_TYPE='W' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)\r\n                        --ORDER BY item_name\r\n                       union\r\n                      select I.PRODUCT_TYPE, '' AS purchase_type,\r\n                        CASE when i.item_type = 'S' then i.item_name ||'-'||'Service'||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code end ITEM_NAME,\r\n                        case when i.item_type = 'S' then i.item_id end ITEM_ID,order_by,i.item_sku,i.item_specification,i.hs_code\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.item_type='S' and i.item_id=", ItemId, " AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit=true)" };
            empty = string.Concat(itemId);
            return this.conDB.GetDataTable(empty);
        }

        public DataTable GetItemIsExempted(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_exempted from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetItemIsFixedVat(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_tarrif from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemIsMRP(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_mrp from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemIsRebatable(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_rebatable from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemIsTeriff(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_tarrif from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetItemIsVds(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_vds from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemIsZeroRate(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_zero_rate from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemLevel()
        {
            return this.conDB.GetDataTable("select code_id_d,code_name from app_code_detail where code_id_m=50");
        }

        public DataTable getItemProperty(int no)
        {
            string str = string.Concat("select property_name,property_id from item_property where property_type_m = 5 and property_type_d = '", no, "'");
            return this.conDB.GetDataTable(str);
        }

        public DataSet getItemPropertyValues(short propertyTypeD)
        {
            object[] propertyTypeM = new object[] { "SELECT PROPERTY_ID,PROPERTY_NAME,PROPERTY_CODE FROM ITEM_PROPERTY WHERE IS_DELETED = false AND PROPERTY_TYPE_M = ", AllConstraint.PropertyTypeM, " AND PROPERTY_TYPE_D = '", propertyTypeD, "' AND IS_DELETED = false " };
            string str = string.Concat(propertyTypeM);
            return this.conDB.GetDataSet(str, "ITEM_PRO");
        }

        public DataTable getItemRequiredProperty(int itemID)
        {
            string str = string.Concat("SELECT i.PROP1_REQUIRED,i.PROP2_REQUIRED,i.PROP3_REQUIRED,i.PROP4_REQUIRED,i.PROP5_REQUIRED,i.SUPPLIER_REQUIRED,i.expiry_date_required,i.is_vds, \r\n                         u.MEASUREMENT_ID_D, u.UNIT_ID , u.unit_name, u.unit_code, i.item_type, I.is_exempted, ct.category_id sub_category_id,ct.category_name sub_category_name,ctp.category_id,ctp.category_name,\r\n                         case when tpd.is_rebatable is null then false else tpd.is_rebatable end is_rebatable, \r\n                         case when tpd.is_source_tax_deduct is null then false else tpd.is_source_tax_deduct end is_source_tax_deduct, \r\n                         case when tpd.zero_rate is null then false else tpd.zero_rate end zero_rate,\r\n                         case when tpd.is_deemedexport is null then false else tpd.is_deemedexport end is_deemedexport\r\n                        ,coalesce(i.property_id1,0) property_id1,coalesce(i.property_id2,0) property_id2,coalesce(i.property_id3,0) property_id3,coalesce(i.property_id4,0) property_id4,coalesce(i.property_id5,0) property_id5\r\n                         FROM ITEM i \r\n                         left join trns_purchase_detail tpd on tpd.Item_id = i.Item_id\r\n                         left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n                         left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n                         left outer join ITEM_unit u on u.unit_id = i.unit_id WHERE I.ITEM_ID = ", itemID);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetItemSetItemID(int itemID)
        {
            string str = string.Concat(" select *,i.item_name,iu.unit_code from set_itemset si\r\n                          inner join item i on i.item_id=si.item_id\r\n                          inner join item_unit iu on iu.unit_id=si.unit_id\r\n                             where set_item_id = '", itemID, "' ");
            return this.conDB.GetDataTable(str);
        }

        public DataTable getItemVatAmount(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,tax_value_id,tax_id,tax_value,per from item_tax_values where item_id=", itemId, " and is_last_insert=true and is_deleted=false");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemVatAmountForImport(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,tax_value_id,tax_id,tax_value,per from item_tax_values where item_id=", itemId, " and is_last_insert=true and is_deleted=false AND is_tran_import=true");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemVatAmountForLocalPurchase(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,tax_value_id,tax_id,tax_value,per from item_tax_values where item_id=", itemId, " and is_last_insert=true and is_deleted=false AND is_tran_local = true");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getItemVatAmountForSale(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,tax_value_id,tax_id,tax_value,per from item_tax_values where item_id=", itemId, " and is_last_insert=true and is_deleted=false AND is_tran_sale = true");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getIUnitByItemId(int itemID)
        {
            string str = string.Concat("SELECT ITEM_UNIT.UNIT_ID,ITEM_UNIT.UNIT_NAME,ITEM_UNIT.UNIT_CODE FROM ITEM_UNIT \r\n                    inner join item on item.unit_id=ITEM_UNIT.unit_id WHERE item.item_id = ", itemID, " AND ITEM_UNIT.IS_DELETED = false");
            return this.conDB.GetDataTable(str);
        }

        public DataSet getLABItemCategory()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false  AND CATEGORY_TYPE = 'L'  ORDER BY CATEGORY_NAME ", "CATEGORY");
        }

        public DataTable GetLastChallanPricebyItemID(int itemID)
        {
            object[] objArray = new object[] { " select d.quantity,(d.quantity*d.purchase_unit_price) total_price,d.unit_id from trns_purchase_master m \r\n                        inner join trns_purchase_detail d on m.challan_id =d.challan_id  \r\n                        where d.item_id = ", itemID, " and d.challan_id = (select max(challan_id) from trns_purchase_detail where item_id = ", itemID, " and quantity!=0)" };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable getMedicineByCategoryId(int CategoryId)
        {
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            string str1 = string.Concat(" select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code||'-'||i.item_sku) END item_name\r\n                               from Item i\r\n                               left join item_category ic\r\n                               on i.sub_category_id = ic.category_id\r\n                               inner join trns_purchase_detail as d\r\n                               on d.item_id = i.item_id\r\n                               where i.Is_deleted = false and i.product_type = 'M' ", str, " ORDER BY item_name");
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getMesurmentIUnit(int msrID)
        {
            string str = string.Concat("SELECT UNIT_ID,UNIT_NAME FROM ITEM_UNIT WHERE MEASUREMENT_ID_D = ", msrID, " AND IS_DELETED = false ORDER BY UNIT_ID ");
            return this.conDB.GetDataTable(str);
        }

        public DataTable getMesurmentIUnitService()
        {
            return this.conDB.GetDataTable("SELECT UNIT_ID,UNIT_NAME FROM ITEM_UNIT WHERE MEASUREMENT_ID_D = 6 AND IS_DELETED = false ORDER BY UNIT_NAME ");
        }

        public DataTable getMesurmentType()
        {
            return this.conDB.GetDataTable("SELECT CODE_ID_D,CODE_NAME FROM APP_CODE_DETAIL WHERE CODE_ID_M = 4 AND IS_DELETED = false ORDER BY CODE_ID_D");
        }

        public DataTable getMesurmentTypeService()
        {
            return this.conDB.GetDataTable("SELECT CODE_ID_D,CODE_NAME FROM APP_CODE_DETAIL WHERE CODE_ID_M = 4 and code_id_d = 6 AND IS_DELETED = false ORDER BY CODE_NAME ");
        }

        public DataTable getOnItemPromos(DateTime presentDay, int itemId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] str = new object[] { "select gdf.parent_item_id, ip.item_name parent_item_name, gdf.parent_item_unit, iup.unit_code parent_unit_code, gdf.gift_item_id, \r\n                    ig.item_name gift_item_name,  gdf.gift_item_code, gdf.gift_unit_id, iug.unit_code gift_unit_code, gdf.parent_item_qnt, gdf.gift_qnt, gdf.discount_percentage, gdf.discount_amount,\r\n                    gdf.is_on_item_gift, gdf.is_on_sale_gift, gdf.date_from, gdf.date_to, gdf.remarks\r\n                    from gift_discount_plan gdf\r\n                    left join item ip on gdf.parent_item_id=ip.item_id \r\n                    left join item ig on gdf.gift_item_id=ig.item_id\r\n                    left join item_unit iup on gdf.parent_item_unit = iup.unit_id\r\n                    left join item_unit iug on gdf.gift_unit_id = iug.unit_id\r\n                    where TO_DATE('", presentDay.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')>=gdf.date_from AND TO_DATE('", presentDay.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy') <= gdf.date_to\r\n                    And gdf.parent_item_id= ", itemId, " AND gdf.is_on_item_gift=true AND gdf.organization_id=", num, " AND gdf.Is_deleted = false " };
            string str1 = string.Concat(str);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getOnSalePromos(DateTime presentDay)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] str = new object[] { "select gdf.parent_item_id, ip.item_name parent_item_name, gdf.parent_item_unit, iup.unit_code parent_unit_code, gdf.gift_item_id, \r\n                    ig.item_name gift_item_name, gdf.gift_unit_id, iug.unit_code gift_unit_code, gdf.parent_item_qnt, gdf.gift_qnt, gdf.discount_percentage, gdf.discount_amount,\r\n                    gdf.is_on_item_gift, gdf.is_on_sale_gift, gdf.date_from, gdf.date_to, gdf.remarks\r\n                    from gift_discount_plan gdf\r\n                    left join item ip on gdf.parent_item_id=ip.item_id \r\n                    left join item ig on gdf.gift_item_id=ig.item_id\r\n                    left join item_unit iup on gdf.parent_item_unit = iup.unit_id\r\n                    left join item_unit iug on gdf.gift_unit_id = iug.unit_id\r\n                    where TO_DATE('", presentDay.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')>=gdf.date_from AND TO_DATE('", presentDay.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy') <= gdf.date_to\r\n                    And gdf.is_on_sale_gift=true AND gdf.organization_id=", num, " AND gdf.Is_deleted = false " };
            string str1 = string.Concat(str);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable getopeningBlByPropertyId(int designId, int bandrollId)
        {
            return this.conDB.GetDataTable("select distinct item_qty from opening_balance obl\r\n                        inner join item i on i.item_id=obl.item_id\r\n                        inner join item_property ip on ip.property_type_d = i.property_id1 or ip.property_type_d = i.property_id2 or \r\n                        ip.property_type_d = i.property_id3 or ip.property_type_d = i.property_id4 or ip.property_type_d = i.property_id5\r\n                        inner join trns_bandroll_rcv_d d on d.property_id3= ip.property_id  or d.property_id5=ip.property_id");
        }

        public DataTable GetOpeningInfobyItem(int itemId)
        {
            string str = string.Concat("select item_qty from OPENING_BALANCE where ITEM_ID=", itemId, " and item_qty!=0 ");
            return this.conDB.GetDataTable(str);
        }

        public DataSet GetOpeningItemInfo(int itemId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select * from OPENING_BALANCE where ITEM_ID=", itemId, " and organization_id=", num, " and org_branch_reg_id=", num1, " " };
            string str = string.Concat(objArray);
            return this.conDB.GetDataSet(str, "DATA");
        }

        public DataSet getOrgWiseAllItemCategory()
        {
            DataSet dataSet;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
                string str = string.Concat("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false \r\n                AND CATEGORY_TYPE IN ( 'I', 'S', 'U') and organization_id=", num, " ORDER BY CATEGORY_NAME ");
                dataSet = this.conDB.GetDataSet(str, "CATEGORY");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataSet;
        }

        public DataTable getParentId()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.conDB.GetDataTable("SELECT parent_id FROM item WHERE CODE_ID_M = 4 AND IS_DELETED = false ORDER BY CODE_ID_D");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPaymentMethod()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.conDB.GetDataTable("select payment_method_id,payment_method_name from set_payment_method");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataSet getPIItemCategory()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false  AND CATEGORY_TYPE in ('P', 'L') ORDER BY CATEGORY_NAME ", "CATEGORY");
        }

        public DataTable GetPricebyChallan(int challanID)
        {
            string str = string.Concat(" select quantity,purchase_unit_price from trns_purchase_detail where challan_id=", challanID, " ");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetPriceDeclarationNo()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select price_id, price_declaration_no\r\n                                from price_item \r\n                                where price_declaration_no <> 'No' and is_deleted = false and item_id is not null AND organization_id=", num, "\r\n                                order by price_id");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetPriceDeclarationNoByItem(int item_id)
        {
            string str = string.Concat("select price_id, price_declaration_no\r\n                                from price_item \r\n                                where price_declaration_no <> 'No' and item_id=", item_id, "  and is_deleted = false and item_id is not null\r\n                                order by price_id");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetPriceQntByChallanId(int itemID, int challanID)
        {
            object[] objArray = new object[] { " select d.quantity,d.total_price,d.unit_id from trns_purchase_master m \r\n                        inner join trns_purchase_detail d on m.challan_id =d.challan_id  \r\n                        where d.item_id ='", itemID, "' AND d.challan_id ='", challanID, "'" };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable getProductByCategoryIdPrChallan(int CategoryId, string prChallan)
        {
            string str = "";
            if (CategoryId > 0)
            {
                str = string.Concat(" AND i.sub_category_id = ", CategoryId, " ");
            }
            string[] strArrays = new string[] { "select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name,pm.price_id\r\n                               from Item i\r\n                               inner join trns_production_detail pd on i.item_id=pd.item_id\r\n                               inner join trns_production_master pm on pm.production_id= pd.production_id\r\n                               where i.Is_deleted = false and pm.challan_batch_no='", prChallan, "'   ", str, " ORDER BY item_name" };
            string str1 = string.Concat(strArrays);
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetProductTypeItemID(int itemID)
        {
            string str = string.Concat(" select product_type from item where item_id = '", itemID, "' ");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetProperty()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.conDB.GetDataTable("select distinct ip.property_id, ip.property_name \r\n                            from trns_sale_detail tsd\r\n                             left join item_property ip on ip.property_id = tsd.property_id1\r\n                             left join item_property ip1 on ip1.property_id = tsd.property_id2\r\n                             left join item_property ip2 on ip2.property_id = tsd.property_id3\r\n                             left join item_property ip3 on ip3.property_id = tsd.property_id4\r\n                             left join item_property ip4 on ip4.property_id = tsd.property_id5\r\n                            where ip.is_deleted = false");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetPropertybyItemID(int itemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select ip.property_id, ip.property_name \r\n                            from trns_sale_detail tsd\r\n                             left join item_property ip on ip.property_id = tsd.property_id1\r\n                             left join item_property ip1 on ip1.property_id = tsd.property_id2\r\n                             left join item_property ip2 on ip2.property_id = tsd.property_id3\r\n                             left join item_property ip3 on ip3.property_id = tsd.property_id4\r\n                             left join item_property ip4 on ip4.property_id = tsd.property_id5\r\n                            where ip.is_deleted = false and tsd.item_id = ", itemID);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetPropertybyItemID(long itemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select ip.property_id, ip.property_name \r\n                            from trns_sale_detail tsd\r\n                             left join item_property ip on ip.property_id = tsd.property_id1\r\n                             left join item_property ip1 on ip1.property_id = tsd.property_id2\r\n                             left join item_property ip2 on ip2.property_id = tsd.property_id3\r\n                             left join item_property ip3 on ip3.property_id = tsd.property_id4\r\n                             left join item_property ip4 on ip4.property_id = tsd.property_id5\r\n                            where ip.is_deleted = false and tsd.item_id = ", itemID);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }


        public DataTable getPropQuantity(int propertyId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select quantity from item_property where property_id=", propertyId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataSet getRDFItemCategory()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  AND IS_DELETED = false  AND CATEGORY_TYPE in ('I','P') ORDER BY CATEGORY_NAME ", "CATEGORY");
        }

        public DataTable getRealStateByCategoryId(int CategoryId)
        {
            string str = "";
            if (CategoryId > 0)
            {
                object[] categoryId = new object[] { " AND (i.sub_category_id = ", CategoryId, " OR ic.parent_id = ", CategoryId, ")" };
                str = string.Concat(categoryId);
            }
            string str1 = string.Concat(" select DISTINCT i.Item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code||'-'||i.item_sku||'-'||i.item_sku) END item_name\r\n                               from Item i\r\n                               left join item_category ic\r\n                               on i.sub_category_id = ic.category_id\r\n                               inner join trns_purchase_detail as d\r\n                               on d.item_id = i.item_id\r\n                               where i.Is_deleted = false and i.product_type = 'W' ", str, " ORDER BY item_name");
            return this.conDB.GetDataTable(str1);
        }

        public DataTable GetReceiveInfoOfItem(int itemID)
        {
            string str = string.Concat("SELECT * FROM TRNS_RECEIVE_DETAIL WHERE ITEM_ID = ", itemID);
            DataTable dataTable = new DataTable();
            return this.conDB.GetDataTable(str);
        }

        public DataSet getRelatedItemPropertyValues(short propertyTypeD, int itemID)
        {
            object[] objArray = new object[] { "SELECT P.PROPERTY_ID,P.PROPERTY_NAME,P.PROPERTY_CODE FROM ITEM_PROPERTY P, ITEM_pro_relation PR  WHERE PR.property_id = P.property_id  AND P.IS_DELETED = false AND PR.Item_id = ", itemID, " and P.PROPERTY_TYPE_M = ", AllConstraint.PropertyTypeM, " AND P.PROPERTY_TYPE_D = '", propertyTypeD, "'  " };
            string str = string.Concat(objArray);
            return this.conDB.GetDataSet(str, "ITEM_PRO");
        }

        public DataTable getReusable(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_reusable from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataSet GetSaleItemInfo(int itemId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select * from trns_sale_detail tsd inner join trns_sale_master tsm on tsd.challan_id=tsm.challan_id  where tsd.ITEM_ID=", itemId, " and tsm.organization_id=", num, " and tsm.org_branch_reg_id=", num1, " " };
            string str = string.Concat(objArray);
            return this.conDB.GetDataSet(str, "DATA");
        }

        public DataTable GetSetItem()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat(" select item_id,item_name from item where product_type='S' AND organization_id = ", num);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetSetTransactionbyItemID(int itemID)
        {
            string str = string.Concat(" select * from set_itemset_master where set_item_id = '", itemID, "' ");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetSetTypeItem()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat(" select item_id,item_name from item where is_item_set=true AND organization_id = ", num);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetSKU_Code()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.conDB.GetDataTable("select coalesce(MAX(regexp_replace(item_sku, '[^0-9]', '', 'g')::int),0) sku_code from item");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet getSubCategory()
        {
            return this.conDB.GetDataSet("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE IS_DELETED = false ORDER BY CATEGORY_NAME ", "CATEGORY");
        }

        public DataSet getSubCategoryByCat(SetItemCategoryDAO objCategory)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            string str = "";
            if (objCategory.CategoryID > 0)
            {
                str = string.Concat(" AND PARENT_ID = ", objCategory.CategoryID);
            }
            object[] objArray = new object[] { "SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY\r\n            WHERE IS_DELETED = false ", str, " and CATEGORY_LEVEL = 2 and organization_id=", num, "  ORDER BY CATEGORY_NAME " };
            string str1 = string.Concat(objArray);
            return this.conDB.GetDataSet(str1, "CATEGORY");
        }

        public DataTable getSubcategoryByCategoryId(int catId)
        {
            string str = "";
            if (catId > 0)
            {
                str = string.Concat(" AND PARENT_ID = ", catId);
            }
            string str1 = string.Concat("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE IS_DELETED = false ", str, " and CATEGORY_LEVEL = 2 and is_deleted=false  ORDER BY CATEGORY_NAME ");
            return this.conDB.GetDataTable(str1);
        }

        public DataSet getSubCategoryByProdType(SetItemCategoryDAO objCategory, string productType)
        {
            string str = "";
            if (objCategory.CategoryID > 0)
            {
                str = string.Concat(" AND C.PARENT_ID = ", objCategory.CategoryID);
            }
            string str1 = string.Concat("SELECT DISTINCT C.CATEGORY_ID, C.CATEGORY_NAME\r\nFROM ITEM I INNER JOIN ITEM_CATEGORY C ON C.CATEGORY_ID = I.CATEGORY_ID \r\n WHERE I.PRODUCT_TYPE = '", productType, "' AND I.ITEM_TYPE = 'I' \r\n AND C.CATEGORY_LEVEL = 2 AND C.is_leaf = 2 AND I.IS_DELETED = false ", str);
            return this.conDB.GetDataSet(str1, "CATEGORY");
        }

        public DataTable GetSubCategoryIdbyCategory(string SubCategoryName, int catgId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select distinct ic.category_id, ic.category_name \r\n                            from item_category ic                             \r\n                            where ic.parent_id = ", catgId, " and ic.is_deleted=false and upper(category_name)='", SubCategoryName, "'" };
                string str = string.Concat(objArray);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet GetSubCategoryInfoByCategory(int categoryID)
        {
            string str = string.Concat("SELECT * FROM ITEM_CATEGORY WHERE category_id=", categoryID, " AND IS_DELETED = false and parent_id!=0");
            return this.conDB.GetDataSet(str, "DATA");
        }

        public DataTable getTruncated(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select item_id,is_truncated from item where item_id=", itemId);
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable GetUnitbyItem(int itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { " select unit_id from item where item_id=", itemID, " AND organization_id = ", num };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable getUnitByItemId(int itemId)
        {
            string str = string.Concat("select iu.*,tsd.actual_price,tsd.Quantity,tsd.row_no,ic.category_name,ic.category_id,\r\n                        case when tsd.property_id1 is null  then 0 else tsd.property_id1 end property_id1,\r\n                        case when tsd.property_id2 is null  then 0 else tsd.property_id2 end property_id2,\r\n                        case when tsd.property_id3 is null  then 0 else tsd.property_id3 end property_id3,\r\n                        case when tsd.property_id4 is null  then 0 else tsd.property_id4 end property_id4,\r\n                        case when tsd.property_id5 is null  then 0 else tsd.property_id5 end property_id5\r\n                        from trns_sale_detail tsd \r\n                        left outer join item_unit iu \r\n                        on tsd.unit_id = iu.unit_id\r\n                        inner join Item i\r\n                        on i.Item_id = tsd.Item_id\r\n                        inner join item_category ic\r\n                        on ic.category_id = i.category_id    \r\n                        where tsd.Item_id = '", itemId, "' ");
            return this.conDB.GetDataTable(str);
        }

        public DataTable getUnitbyItemSetUp(int itemId)
        {
            string str = string.Concat("SELECT UNIT_ID FROM ITEM WHERE item_id = ", itemId, " AND IS_DELETED = false");
            return this.conDB.GetDataTable(str);
        }

        public DataTable getUnitbyMesurmentandUnitId(int msrID, int unitId)
        {
            object[] objArray = new object[] { "SELECT UNIT_ID,UNIT_NAME FROM ITEM_UNIT WHERE MEASUREMENT_ID_D = ", msrID, " and UNIT_ID=", unitId, " AND IS_DELETED = false ORDER BY UNIT_ID " };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public DataTable getUnitConversionData(int unitID)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select iuc.unit_id_to as unit_id, iuc.value_to, iu.unit_code\r\n                            from item_unit_conversion as iuc\r\n                            inner join item_unit as iu\r\n                            on iu.unit_id = iuc.unit_id_to\r\n                            where iuc.unit_id_from = ", unitID, " and iuc.is_deleted = false");
                dataTable = this.conDB.GetDataTable(str);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ReallySimpleLog.WriteLog(exception);
                throw exception;
            }
            return dataTable;
        }

        public DataTable getUnitIdbyUnit(string unitname)
        {
            string str = string.Concat("SELECT unit_id from item_unit where is_deleted=false and upper(unit_code)='", unitname, "' ");
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetValue(int Unit, int unit_sec)
        {
            object[] unit = new object[] { " select value_to from item_unit_conversion                          \r\n                        where unit_id_from ='", Unit, "' AND unit_id_to ='", unit_sec, "' " };
            string str = string.Concat(unit);
            return this.conDB.GetDataTable(str);
        }

        public DataTable GetValueSec(int Unit, int unit_sec)
        {
            object[] unitSec = new object[] { " select value_to from item_unit_conversion                          \r\n                        where unit_id_from ='", unit_sec, "' AND unit_id_to ='", Unit, "'" };
            string str = string.Concat(unitSec);
            return this.conDB.GetDataTable(str);
        }

        public int InsertItem(SetItemDAO objItemDAO)
        {
            ArrayList arrayLists = new ArrayList();
            string empty = string.Empty;
            string str = string.Empty;
            objItemDAO.ItemID = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('item_id_seq')"));
            int itemID = -999;
            if (!string.IsNullOrEmpty(objItemDAO.SKU))
            {
                empty = ",item_sku";
                str = string.Concat(",'", objItemDAO.SKU, "'");
            }
            try
            {
                object[] objArray = new object[] { "INSERT INTO ITEM (Item_id, SUB_CATEGORY_ID,ITEM_NAME,ITEM_SPECIFICATION,ITEM_CODE,UNIT_ID,PROP1_REQUIRED,PROP2_REQUIRED,PROP3_REQUIRED,PROP4_REQUIRED,PROP5_REQUIRED,  LEVEL_CODE,MEASUREMENT_ID_M,MEASUREMENT_ID_D,SUPPLIER_REQUIRED,expiry_date_required,USER_ID_INSERT,  item_type, hs_code_heading, hs_code_suffix, hs_code, is_exempted, vat_rebate,is_truncated,is_tarrif,is_zero_rate, is_rebatable,is_mrp,model_no,product_type,is_vds ", empty, ",brand_name,organization_id,is_for_all_bss_unit,property_id1, property_id2, property_id3, property_id4, property_id5,is_price_declaration,is_healthcare_surcharge,weight,weight_unit_id,is_item_set,is_reusable) VALUES (", objItemDAO.ItemID, ",   '", objItemDAO.CategoryID, "', upper('", Utilities.checkForSingleQuotes(objItemDAO.ItemName), "'),'", objItemDAO.ItemSpecification, "', (SELECT (case MAX(SIC.CATEGORY_LEVEL) when 1 then MAX(SIC.CATEGORY_CODE)||'.0' when 2 then MAX(SIC.CATEGORY_CODE) end)   ||'.'||coalesce(MAX(SI.LEVEL_CODE)+1,1) LEVEL_CODE  FROM ITEM_CATEGORY SIC left outer join ITEM SI on SIC.CATEGORY_ID = SI.SUB_CATEGORY_ID  WHERE SIC.CATEGORY_ID = '", objItemDAO.CategoryID, "'  ),'", objItemDAO.UnitID, "',  '", Convert.ToBoolean(objItemDAO.Prop1Required), "','", Convert.ToBoolean(objItemDAO.Prop2Required), "','", Convert.ToBoolean(objItemDAO.Prop3Required), "',  '", Convert.ToBoolean(objItemDAO.Prop4Required), "','", Convert.ToBoolean(objItemDAO.Prop5Required), "',  (SELECT coalesce(MAX(LEVEL_CODE)+1,1) LEVEL_CODE FROM ITEM WHERE SUB_CATEGORY_ID = '", objItemDAO.CategoryID, "' ),  '", objItemDAO.MesurementIDM, "','", objItemDAO.MesurementIDD, "',", Convert.ToBoolean(objItemDAO.SupplierRequired), ",", Convert.ToBoolean(objItemDAO.ExpiryDateRequired), ",'", objItemDAO.UserIdInsert, "',  '", objItemDAO.ItemType, "', '", objItemDAO.HsHeading, "', '", objItemDAO.HsSuffix, "', '", objItemDAO.HsCode, "', ", objItemDAO.Exempted, ", ", objItemDAO.VatRebate, ", ", objItemDAO.Truncated, ",", objItemDAO.Tarrif, ",", objItemDAO.ZeroRate, ",", objItemDAO.Rebatable, ",", objItemDAO.Mrp, ",'", objItemDAO.ModelNo, "','", objItemDAO.ProductType, "',", objItemDAO.IsVDS, " ", str, ",'", objItemDAO.brandName, "',\r\n          ", objItemDAO.Organization_id, ",", objItemDAO.IsAllBssUnt, ", ", objItemDAO.propertyId1, ", ", objItemDAO.propertyId2, ", ", objItemDAO.propertyId3, ",\r\n          ", objItemDAO.propertyId4, ", ", objItemDAO.propertyId5, ",", objItemDAO.IsPriceDec, ",", objItemDAO.IsHCS, ",", objItemDAO.Weight, ",", objItemDAO.weightUnitID, ",", objItemDAO.IsSetItem, ",", objItemDAO.IsReusable, ")" };
                string str1 = string.Concat(objArray);
                string str2 = string.Concat("UPDATE ITEM_CATEGORY SET IS_LEAF = 2 WHERE CATEGORY_ID = '", objItemDAO.CategoryID, "'");
                string str3 = "";
                string str4 = "";
                if (objItemDAO.IsAllBssUnt)
                {
                    str3 = string.Concat("UPDATE ITEM_CATEGORY SET is_for_all_bss_unit = true WHERE CATEGORY_ID = '", objItemDAO.CategoryID, "'");
                    str4 = string.Concat("UPDATE ITEM_CATEGORY SET is_for_all_bss_unit = true WHERE CATEGORY_ID = '", objItemDAO.MainCategoryID, "'");
                }
                arrayLists.Add(str1);
                arrayLists.Add(str2);
                if (objItemDAO.IsAllBssUnt)
                {
                    arrayLists.Add(str3);
                    arrayLists.Add(str4);
                }
                if (this.conDB.ExecuteBatchDML(arrayLists))
                {
                    itemID = objItemDAO.ItemID;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return itemID;
        }

        public bool InsertItemBalance(SetItemDAO itemBal, string purchaseType)
        {
            bool flag;
            try
            {
                itemBal.OpnID = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('opn_id_seq')"));
                ArrayList arrayLists = new ArrayList();
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num2 = Convert.ToInt16(HttpContext.Current.Session["employee_id"]);
                string str = "O";
                DateTime today = DateTime.Today;
                string str1 = "OpeningBalance";
                if (itemBal.ItmQty != 0)
                {
                    double itmVl = itemBal.ItmVl / itemBal.ItmQty;
                }
                int num3 = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                int num4 = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                string str2 = string.Concat(" ( SELECT coalesce(MAX(row_no)+1,1) ROW_NO FROM trns_purchase_detail WHERE Challan_id = '", num4, "' )");
                object[] opnID = new object[] { "INSERT INTO OPENING_BALANCE (opn_id, ITEM_ID,ITEM_QTY,ITEM_VALUE,unit_id,purchase_type,opening_balance_date,organization_id,org_branch_reg_id,unit_price) VALUES   ( ", itemBal.OpnID, ", ", itemBal.ItemID, ",", itemBal.ItmQty, ",", itemBal.ItmVl, ",", itemBal.UnitID, ",'", purchaseType, "',to_timestamp('", null, null, null, null, null, null, null, null };
                opnID[13] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
                opnID[14] = "','MM/dd/yyyy HH24:MI'),";
                opnID[15] = num;
                opnID[16] = ",";
                opnID[17] = num1;
                opnID[18] = ",";
                opnID[19] = itemBal.unitPrice;
                opnID[20] = " )";
                arrayLists.Add(string.Concat(opnID));
                object[] objArray = new object[] { "INSERT INTO trns_purchase_master(Challan_id,Organization_id, org_branch_reg_id, challan_type, purchase_type, date_challan,   User_id_insert, challan_no )\r\n                     VALUES ( ", num4, ", ", num, ",", num1, ", '", str, "','", purchaseType, "' , to_timestamp('", null, null, null, null, null, null };
                objArray[11] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
                objArray[12] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[13] = num2;
                objArray[14] = ",\r\n                     '";
                objArray[15] = str1;
                objArray[16] = "')";
                arrayLists.Add(string.Concat(objArray));
                object[] itemID = new object[] { "INSERT INTO trns_purchase_detail(Challan_id,lot_no,detail_id, row_no, Item_id, unit_id, Quantity, actual_price,Sd, Vat,  User_id_insert, \r\n             total_price, sd_rate, vat_rate, is_source_tax_deduct, is_rebatable,zero_rate,is_truncated,is_mrp, is_exempted,\r\n           Cd, Rd, Ait, Atv, Tti,at, purchase_unit_price, purchase_vat, purchase_sd, sale_unit_price, sale_vatable_price, sale_vat, sale_sd, other_cost,document_processing_fee,vds_amount,purchase_type)\r\n           VALUES (", num4, ", 0,", num3, ",", str2, ", ", itemBal.ItemID, ",  ", itemBal.UnitID, ", ", itemBal.ItmQty, ", ", itemBal.ItmVl, ", 0 , 0, ", num2, ", \r\n                ", itemBal.ItmVl, ",0,0,", itemBal.IsVDS, ",  ", itemBal.Rebatable, ",", itemBal.ZeroRate, ",", itemBal.Truncated, ",", itemBal.Mrp, ", ", itemBal.Exempted, ",0,0, 0, 0, 0,0,", itemBal.unitPrice, ", 0, 0, 0, 0,0, 0,0,0,0,'", purchaseType, "')" };
                arrayLists.Add(string.Concat(itemID));
                flag = this.conDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return flag;
        }

        public bool InsertItemBalanceWithExcelAdtnProperty(SetItemDAO itemBal, string purchaseType, ArrayList arrxcel)
        {
            bool flag;
            try
            {
                itemBal.OpnID = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('opn_id_seq')"));
                ArrayList arrayLists = new ArrayList();
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                int num2 = Convert.ToInt16(HttpContext.Current.Session["employee_id"]);
                string str = "O";
                DateTime today = DateTime.Today;
                string str1 = "OpeningBalance";
                if (itemBal.ItmQty != 0)
                {
                    double itmVl = itemBal.ItmVl / itemBal.ItmQty;
                }
                int num3 = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                int num4 = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                string str2 = string.Concat(" ( SELECT coalesce(MAX(row_no)+1,1) ROW_NO FROM trns_purchase_detail WHERE Challan_id = '", num4, "' )");
                object[] opnID = new object[] { "INSERT INTO OPENING_BALANCE (opn_id, ITEM_ID,ITEM_QTY,ITEM_VALUE,unit_id,purchase_type,opening_balance_date,organization_id,org_branch_reg_id,unit_price) VALUES   ( ", itemBal.OpnID, ", ", itemBal.ItemID, ",", itemBal.ItmQty, ",", itemBal.ItmVl, ",", itemBal.UnitID, ",'", purchaseType, "',to_timestamp('", null, null, null, null, null, null, null, null };
                opnID[13] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
                opnID[14] = "','MM/dd/yyyy HH24:MI'),";
                opnID[15] = num;
                opnID[16] = ",";
                opnID[17] = num1;
                opnID[18] = ",";
                opnID[19] = itemBal.unitPrice;
                opnID[20] = " )";
                arrayLists.Add(string.Concat(opnID));
                object[] objArray = new object[] { "INSERT INTO trns_purchase_master(Challan_id,Organization_id, org_branch_reg_id, challan_type, purchase_type, date_challan,   User_id_insert, challan_no )\r\n                     VALUES ( ", num4, ", ", num, ",", num1, ", '", str, "','", purchaseType, "' , to_timestamp('", null, null, null, null, null, null };
                objArray[11] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
                objArray[12] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[13] = num2;
                objArray[14] = ",\r\n                     '";
                objArray[15] = str1;
                objArray[16] = "')";
                arrayLists.Add(string.Concat(objArray));
                object[] itemID = new object[] { "INSERT INTO trns_purchase_detail(Challan_id,lot_no,detail_id, row_no, Item_id, unit_id, Quantity, actual_price,Sd, Vat,  User_id_insert, \r\n             total_price, sd_rate, vat_rate, is_source_tax_deduct, is_rebatable,zero_rate,is_truncated,is_mrp, is_exempted,\r\n           Cd, Rd, Ait, Atv, Tti,at, purchase_unit_price, purchase_vat, purchase_sd, sale_unit_price, sale_vatable_price, sale_vat, sale_sd, other_cost,document_processing_fee,vds_amount,purchase_type)\r\n           VALUES (", num4, ", 0,", num3, ",", str2, ", ", itemBal.ItemID, ",  ", itemBal.UnitID, ", ", itemBal.ItmQty, ", ", itemBal.ItmVl, ", 0 , 0, ", num2, ", \r\n                ", itemBal.ItmVl, ",0,0,", itemBal.IsVDS, ",  ", itemBal.Rebatable, ",", itemBal.ZeroRate, ",", itemBal.Truncated, ",", itemBal.Mrp, ", ", itemBal.Exempted, ",0,0, 0, 0, 0,0,", itemBal.unitPrice, ", 0, 0, 0, 0,0, 0,0,0,0,'", purchaseType, "')" };
                arrayLists.Add(string.Concat(itemID));
                arrayLists = this.AddMainDeailInsertAdditionalInfo(arrayLists, arrxcel, num4, itemBal.Opening_bal_date, purchaseType);
                flag = this.conDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return flag;
        }

        public bool InsertItemCategory(SetItemCategoryDAO objCategory)
        {
            object[] categoryName = new object[] { "INSERT INTO ITEM_CATEGORY (  CATEGORY_NAME,DESCRIPTION,CATEGORY_LEVEL,LEVEL_CODE,CATEGORY_CODE,USER_ID_INSERT,organization_id) VALUES   (  upper('", objCategory.CategoryName, "'),'", objCategory.Description, "','", objCategory.CategoryLevel, "',  ( SELECT coalesce(max(LEVEL_CODE),0)+1 LEVEL_CODE FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1  ),  ( SELECT coalesce(max(LEVEL_CODE),0)+1 CATEGORY_CODE FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1 ),  '", objCategory.UserIdInsert, "',", objCategory.Organization_id, ")" };
            string str = string.Concat(categoryName);
            return this.conDB.ExecuteDML(str);
        }

        public int InsertItemSubCategory(SetItemCategoryDAO objSubCategory)
        {
            ArrayList arrayLists = new ArrayList();
            objSubCategory.CategoryID = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('item_category_id_seq')"));
            string str = string.Concat("SELECT category_type FROM ITEM_CATEGORY WHERE CATEGORY_ID = ", objSubCategory.ParentID);
            string str1 = this.conDB.GetSingleValue(str).ToString();
            if (str1 == "")
            {
                str1 = "I";
            }
            string str2 = "";
            string str3 = "";
            if (str1 == "P")
            {
                str2 = " ,category_id_common";
                int categoryID = objSubCategory.CategoryID;
                str3 = string.Concat(" ,", categoryID.ToString());
            }
            object[] objArray = new object[] { "INSERT INTO ITEM_CATEGORY (category_id, PARENT_ID,CATEGORY_NAME,DESCRIPTION,CATEGORY_LEVEL,LEVEL_CODE,CATEGORY_CODE,USER_ID_INSERT,  category_type ", str2, ",organization_id) VALUES (", objSubCategory.CategoryID, ",    '", objSubCategory.ParentID, "',upper('", objSubCategory.CategoryName, "'),'", objSubCategory.Description, "','", objSubCategory.CategoryLevel, "',  (SELECT coalesce(MAX(LEVEL_CODE)+1,1) FROM ITEM_CATEGORY WHERE PARENT_ID = '", objSubCategory.ParentID, "' ), (SELECT  ((LEVEL_CODE)||'.'||(SELECT coalesce(MAX(LEVEL_CODE)+1,1) FROM ITEM_CATEGORY WHERE PARENT_ID = '", objSubCategory.ParentID, "')) CATEGORY_CODE  FROM ITEM_CATEGORY WHERE CATEGORY_ID = '", objSubCategory.ParentID, "' ), '", objSubCategory.UserIdInsert, "' ,  '", str1, "'  ", str3, ",", objSubCategory.Organization_id, ")" };
            string str4 = string.Concat(objArray);
            string str5 = string.Concat(" UPDATE ITEM_CATEGORY SET IS_LEAF = 1  WHERE CATEGORY_ID = '", objSubCategory.ParentID, "' ");
            arrayLists.Add(str4);
            arrayLists.Add(str5);
            bool flag = this.conDB.ExecuteBatchDML(arrayLists);
            int num = -999;
            if (flag)
            {
                num = objSubCategory.CategoryID;
            }
            return num;
        }

        public bool InsertPromoPlan(GiftDiscountPlanDAON objPromo)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            int num2 = Convert.ToInt16(HttpContext.Current.Session["employee_id"]);
            object[] parentItemID = new object[] { "INSERT INTO gift_discount_plan( parent_item_id, parent_item_qnt, parent_item_unit, gift_item_id, gift_unit_id, gift_qnt, min_sale_amount,\r\n                                discount_percentage, discount_amount, gift_item_code, remarks, date_planned, date_from, date_to, is_on_item_gift, is_on_sale_gift,user_id_insert, organization_id, org_branch_id)\r\n                                VALUES(", objPromo.ParentItemID, ", ", objPromo.PrntItemMinQnt, ", ", objPromo.PrntItemUnitID, " , ", objPromo.GiftItemID, ", ", objPromo.GiftItemUnitID, ", ", objPromo.GiftQuantity, ", ", objPromo.MinSaleAmount, " , ", objPromo.DiscountPrcntg, " , ", objPromo.DiscountAmount, ", '", objPromo.GiftItemCode, "', '", objPromo.Remarks, "' , to_timestamp('", objPromo.DatePlanned.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),  to_timestamp('", objPromo.DateFrom.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), to_timestamp('", objPromo.DateTo.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", objPromo.IsOnItemPromo, ", ", objPromo.IsOnSalePromo, ", ", num2, ", ", num, ", ", num1, ")" };
            string str = string.Concat(parentItemID);
            return this.conDB.ExecuteDML(str);
        }

        public bool InsertSetItem(ArrayList arrDeailDAO, ArrayList arrMasterDAO)
        {
            int num = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('set_id_m_id_seq')"));
            ArrayList arrayLists = new ArrayList();
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num2 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            SetItemSetMasterDAO setItemSetMasterDAO = new SetItemSetMasterDAO();
            setItemSetMasterDAO = (SetItemSetMasterDAO)arrMasterDAO[0];
            object[] setItemID = new object[] { "INSERT INTO set_itemset_master (set_id_m,set_item_id,unit_id,quantity,organization_id,org_branch_reg_id,price) VALUES  (", num, " ,", setItemSetMasterDAO.SetItemID, " ,", setItemSetMasterDAO.UnitID, ",", setItemSetMasterDAO.Quantity, ",", num1, ",", num2, ",", setItemSetMasterDAO.Price, ")" };
            arrayLists.Add(string.Concat(setItemID));
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                SetItemSetDAO setItemSetDAO = new SetItemSetDAO();
                setItemSetDAO = (SetItemSetDAO)arrDeailDAO[i];
                object[] objArray = new object[] { "INSERT INTO set_itemset (set_id_m,set_item_id,item_id,unit_id,quantity,organization_id,org_branch_reg_id,price) VALUES  (", num, " , ", setItemSetDAO.SetItemID, " , ", setItemSetDAO.ItemID, ",", setItemSetDAO.UnitID, ",", setItemSetDAO.Quantity, ",", num1, ",", num2, ",", setItemSetDAO.Price, ")" };
                arrayLists.Add(string.Concat(objArray));
            }
            return this.conDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertSubCategory(SetItemCategoryDAO objSubCategory)
        {
            ArrayList arrayLists = new ArrayList();
            objSubCategory.CategoryID = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('item_category_id_seq')"));
            string str = string.Concat("SELECT category_type FROM ITEM_CATEGORY WHERE CATEGORY_ID = ", objSubCategory.ParentID);
            string str1 = this.conDB.GetSingleValue(str).ToString();
            if (str1 == "")
            {
                str1 = "I";
            }
            string str2 = "";
            string str3 = "";
            if (str1 == "P")
            {
                str2 = " ,category_id_common";
                int categoryID = objSubCategory.CategoryID;
                str3 = string.Concat(" ,", categoryID.ToString());
            }
            object[] objArray = new object[] { "INSERT INTO ITEM_CATEGORY (category_id, PARENT_ID,CATEGORY_NAME,DESCRIPTION,CATEGORY_LEVEL,LEVEL_CODE,CATEGORY_CODE,USER_ID_INSERT,  category_type ", str2, ",organization_id) VALUES (", objSubCategory.CategoryID, ",    '", objSubCategory.ParentID, "',upper('", objSubCategory.CategoryName, "'),'", objSubCategory.Description, "','", objSubCategory.CategoryLevel, "',  (SELECT coalesce(MAX(LEVEL_CODE)+1,1) FROM ITEM_CATEGORY WHERE PARENT_ID = '", objSubCategory.ParentID, "' ), (SELECT  ((LEVEL_CODE)||'.'||(SELECT coalesce(MAX(LEVEL_CODE)+1,1) FROM ITEM_CATEGORY WHERE PARENT_ID = '", objSubCategory.ParentID, "')) CATEGORY_CODE  FROM ITEM_CATEGORY WHERE CATEGORY_ID = '", objSubCategory.ParentID, "' ), '", objSubCategory.UserIdInsert, "' ,  '", str1, "'  ", str3, ",", objSubCategory.Organization_id, ")" };
            string str4 = string.Concat(objArray);
            string str5 = string.Concat(" UPDATE ITEM_CATEGORY SET IS_LEAF = 1  WHERE CATEGORY_ID = '", objSubCategory.ParentID, "' ");
            arrayLists.Add(str4);
            arrayLists.Add(str5);
            return this.conDB.ExecuteBatchDML(arrayLists);
        }

        public bool updateItem(SetItemDAO objItemDao)
        {
            ArrayList arrayLists = new ArrayList();
            object[] itemName = new object[] { "UPDATE ITEM SET ITEM_NAME = upper('", objItemDao.ItemName, "'),SUB_CATEGORY_ID = '", objItemDao.CategoryID, "',BRAND_NAME='", objItemDao.brandName, "',ITEM_SPECIFICATION = '", objItemDao.ItemSpecification, "', item_sku = '", objItemDao.SKU, "',  UNIT_ID = '", objItemDao.UnitID, "',PROP1_REQUIRED = '", Convert.ToBoolean(objItemDao.Prop1Required), "',PROP2_REQUIRED = '", Convert.ToBoolean(objItemDao.Prop2Required), "',  PROP3_REQUIRED = '", Convert.ToBoolean(objItemDao.Prop3Required), "',PROP4_REQUIRED = '", Convert.ToBoolean(objItemDao.Prop4Required), "',PROP5_REQUIRED = '", Convert.ToBoolean(objItemDao.Prop5Required), "',  MEASUREMENT_ID_D = '", objItemDao.MesurementIDD, "', hs_code_heading = '", objItemDao.HsHeading, "', hs_code_suffix = '", objItemDao.HsSuffix, "', hs_code = '", objItemDao.HsCode, "', is_exempted = '", objItemDao.Exempted, "',\r\n                             is_truncated ='", objItemDao.Truncated, "',is_tarrif = '", objItemDao.Tarrif, "',is_zero_rate='", objItemDao.ZeroRate, "', is_rebatable = '", objItemDao.Rebatable, "',is_mrp=", objItemDao.Mrp, ",model_no='", objItemDao.ModelNo, "',\r\n                             item_type = '", objItemDao.ItemType, "', vat_rebate = ", objItemDao.VatRebate, ",is_vds=", objItemDao.IsVDS, ",organization_id=", objItemDao.Organization_id, ", product_type = '", objItemDao.ProductType, "',\r\n                             is_for_all_bss_unit=", objItemDao.IsAllBssUnt, ", property_id1 = ", objItemDao.propertyId1, ", property_id2 = ", objItemDao.propertyId2, ", property_id3 = ", objItemDao.propertyId3, ",\r\n                             property_id4 =", objItemDao.propertyId4, ", property_id5 =", objItemDao.propertyId5, ",    SUPPLIER_REQUIRED = ", Convert.ToBoolean(objItemDao.SupplierRequired), ", expiry_date_required = ", Convert.ToBoolean(objItemDao.ExpiryDateRequired), ", DATE_UPDATE = now(),USER_ID_UPDATE = '", objItemDao.UserIdUpdate, "' , is_price_declaration=", objItemDao.IsPriceDec, " , is_healthcare_surcharge=", objItemDao.IsHCS, " , weight=", objItemDao.Weight, ", is_reusable=", objItemDao.IsReusable, ", weight_unit_id=", objItemDao.weightUnitID, " , is_item_set=", objItemDao.IsSetItem, " WHERE ITEM_ID = '", objItemDao.ItemID, "'" };
            string str = string.Concat(itemName);
            string str1 = "";
            string str2 = "";
            if (objItemDao.IsAllBssUnt)
            {
                str1 = string.Concat("UPDATE ITEM_CATEGORY SET is_for_all_bss_unit = true WHERE CATEGORY_ID = '", objItemDao.CategoryID, "'");
                str2 = string.Concat("UPDATE ITEM_CATEGORY SET is_for_all_bss_unit = true WHERE CATEGORY_ID = '", objItemDao.ParentID, "'");
            }
            arrayLists.Add(str);
            if (objItemDao.IsAllBssUnt)
            {
                arrayLists.Add(str1);
                arrayLists.Add(str2);
            }
            return this.conDB.ExecuteBatchDML(arrayLists);
        }

        public bool UpdateItemBalance(SetItemDAO itemBal, int challan_id, string purchaseType)
        {
            ArrayList arrayLists = new ArrayList();
            if (itemBal.ItmQty != 0)
            {
                double itmVl = itemBal.ItmVl / itemBal.ItmQty;
            }
            object[] itemID = new object[] { "UPDATE OPENING_BALANCE SET  ITEM_ID=", itemBal.ItemID, ",ITEM_QTY=", itemBal.ItmQty, ",purchase_type='", purchaseType, "',ITEM_VALUE=", itemBal.ItmVl, ",opening_balance_date=to_timestamp('", null, null, null, null, null };
            itemID[9] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
            itemID[10] = "','MM/dd/yyyy HH24:MI'),unit_price=";
            itemID[11] = itemBal.unitPrice;
            itemID[12] = " where  opn_id=";
            itemID[13] = itemBal.OpnID;
            arrayLists.Add(string.Concat(itemID));
            object[] objArray = new object[] { "UPDATE TRNS_PURCHASE_DETAIL SET purchase_type='", purchaseType, "',Quantity=", itemBal.ItmQty, ",actual_price=", itemBal.ItmVl, ",purchase_unit_price=", itemBal.unitPrice, ",total_price=", itemBal.ItmVl, " where challan_id=", challan_id };
            arrayLists.Add(string.Concat(objArray));
            object[] str = new object[] { "UPDATE TRNS_PURCHASE_MASTER SET purchase_type='", purchaseType, "',date_challan=to_timestamp('", null, null, null };
            str[3] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
            str[4] = "','MM/dd/yyyy HH24:MI') where challan_id=";
            str[5] = challan_id;
            arrayLists.Add(string.Concat(str));
            return this.conDB.ExecuteBatchDML(arrayLists);
        }

        public bool UpdateItemBalanceWithAdtnProperty(SetItemDAO itemBal, int challan_id, string purchaseType, ArrayList arrxcel)
        {
            ArrayList arrayLists = new ArrayList();
            if (itemBal.ItmQty != 0)
            {
                double itmVl = itemBal.ItmVl / itemBal.ItmQty;
            }
            object[] itemID = new object[] { "UPDATE OPENING_BALANCE SET  ITEM_ID=", itemBal.ItemID, ",ITEM_QTY=", itemBal.ItmQty, ",ITEM_VALUE=", itemBal.ItmVl, ",opening_balance_date=to_timestamp('", null, null, null, null, null };
            itemID[7] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
            itemID[8] = "','MM/dd/yyyy HH24:MI'),unit_price=";
            itemID[9] = itemBal.unitPrice;
            itemID[10] = " where  opn_id=";
            itemID[11] = itemBal.OpnID;
            arrayLists.Add(string.Concat(itemID));
            object[] objArray = new object[] { "UPDATE TRNS_PURCHASE_DETAIL SET purchase_type='", purchaseType, "',Quantity=", itemBal.ItmQty, ",actual_price=", itemBal.ItmVl, ",purchase_unit_price=", itemBal.unitPrice, ",total_price=", itemBal.ItmVl, " where challan_id=", challan_id };
            arrayLists.Add(string.Concat(objArray));
            object[] str = new object[] { "UPDATE TRNS_PURCHASE_MASTER SET purchase_type='", purchaseType, "',date_challan=to_timestamp('", null, null, null };
            str[3] = itemBal.Opening_bal_date.ToString("MM/dd/yyyy HH:mm");
            str[4] = "','MM/dd/yyyy HH24:MI') where challan_id=";
            str[5] = challan_id;
            arrayLists.Add(string.Concat(str));
            arrayLists = this.AddMainDeailInsertAdditionalInfo(arrayLists, arrxcel, challan_id, itemBal.Opening_bal_date, purchaseType);
            return this.conDB.ExecuteBatchDML(arrayLists);
        }

        public bool UpdateItemBalanceWithAdtnPropertyN(SetItemDAO itemBal, int challan_id, string purchaseType, ArrayList arrxcel)
        {
            ArrayList arrayLists = new ArrayList();
            arrayLists = this.AddMainDeailInsertAdditionalInfo(arrayLists, arrxcel, challan_id, itemBal.Opening_bal_date, purchaseType);
            return this.conDB.ExecuteBatchDML(arrayLists);
        }

        public bool UpdateItemCategory(SetItemCategoryDAO objItemCategoryDao)
        {
            object[] categoryName = new object[] { "UPDATE ITEM_CATEGORY SET CATEGORY_NAME = upper('", objItemCategoryDao.CategoryName, "'),DESCRIPTION = '", objItemCategoryDao.Description, "',  DATE_UPDATE = NOW(), USER_ID_UPDATE = '", objItemCategoryDao.UserIdUpdate, "', organization_id=", objItemCategoryDao.Organization_id, " WHERE CATEGORY_ID = '", objItemCategoryDao.CategoryID, "' " };
            string str = string.Concat(categoryName);
            return this.conDB.ExecuteDML(str);
        }

        public bool UpdatePromoPlan(GiftDiscountPlanDAON objPromo, int promoID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            Convert.ToInt16(HttpContext.Current.Session["employee_id"]);
            object[] parentItemID = new object[] { "UPDATE gift_discount_plan\r\n                               SET parent_item_id=", objPromo.ParentItemID, ",parent_item_qnt =", objPromo.PrntItemMinQnt, ",parent_item_unit=", objPromo.PrntItemUnitID, ",gift_item_id =", objPromo.GiftItemID, ", gift_unit_id =", objPromo.GiftItemUnitID, ", gift_qnt=", objPromo.GiftQuantity, ",discount_percentage=", objPromo.DiscountPrcntg, ",discount_amount=", objPromo.DiscountAmount, ",min_sale_amount=", objPromo.MinSaleAmount, ",gift_item_code= '", objPromo.GiftItemCode, "',remarks= '", objPromo.Remarks, "',date_from= to_timestamp('", objPromo.DateFrom.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), \r\n                                 date_to =to_timestamp('", objPromo.DateTo.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),  \r\n\t                             is_on_item_gift=", objPromo.IsOnItemPromo, ", is_on_sale_gift=", objPromo.IsOnSalePromo, ", \r\n\t                             date_update=to_timestamp('", objPromo.DatePlanned.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI')\r\n                             WHERE entry_id=", promoID, " AND organization_id=", num, " AND is_deleted=false" };
            string str = string.Concat(parentItemID);
            return this.conDB.ExecuteDML(str);
        }

        public bool UpdateSubCategory(SetItemCategoryDAO objSubCategory)
        {
            object[] categoryName = new object[] { "UPDATE ITEM_CATEGORY SET CATEGORY_NAME = upper('", objSubCategory.CategoryName, "'),DESCRIPTION = '", objSubCategory.Description, "',organization_id=", objSubCategory.Organization_id, " , DATE_UPDATE=NOW(),USER_ID_UPDATE='", objSubCategory.UserIdUpdate, "'  WHERE CATEGORY_ID = '", objSubCategory.CategoryID, "'" };
            string str = string.Concat(categoryName);
            return this.conDB.ExecuteDML(str);
        }
    }
}
