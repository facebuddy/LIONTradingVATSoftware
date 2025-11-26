using System;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetItemBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetItemBLL()
        {
        }

        public DataTable GetAllCategorymqmm()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select category_id, category_name from item_category where parent_id = 0");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet getAllItem()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["master_organization_id"]);
            object[] objArray = new object[] { "select i.Item_id,i.item_name||'--'||i.hs_code \r\n                         item_name from Item i\r\n                         inner join org_registration_info o on o.organization_id=i.organization_id\r\n                         where i.Is_deleted=false and (i.organization_id=", num, " or i.is_for_all_bss_unit=true) and o.master_organization_id=", num1, " order by item_name" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "AllItem");
        }

        public DataSet getAllItemByCategory(int intCategoryID)
        {
            string str = string.Concat("select Item_id,item_name, item_name||'--'||hs_code hs_item from Item where Is_deleted=false and sub_category_id='", intCategoryID, "' order by item_name");
            return this.DBUtil.GetDataSet(str, "ItemByCategory");
        }

        public DataSet getAllItemCategory()
        {
            return this.DBUtil.GetDataSet("select category_id,category_name from item_category where Is_deleted=false AND IS_LEAF = 2 order by category_name", "ItemCategory");
        }

        public DataSet getAllItemCategoryPD()
        {
            DataSet dataSet = this.DBUtil.GetDataSet("select distinct IC.category_id,IC.category_name  from item_category AS IC\r\n                            LEFT JOIN Item AS I\r\n                            ON IC.category_id = I.sub_category_id\r\n                            WHERE  IC.Is_deleted=false \r\n                            AND IC.category_level = 2 order by category_name ", "ItemCategory");
            DataTable item = dataSet.Tables[0];
            DataRow dataRow = item.NewRow();
            dataRow["category_id"] = -99;
            dataRow["category_name"] = "";
            item.Rows.InsertAt(dataRow, 0);
            return dataSet;
        }

        public DataSet getAllItemCategoryWithBlankRow()
        {
            DataSet dataSet = this.DBUtil.GetDataSet("select category_id,category_name from item_category where Is_deleted=false order by category_name", "ItemCategory");
            DataTable item = dataSet.Tables[0];
            DataRow dataRow = item.NewRow();
            dataRow["category_id"] = -99;
            dataRow["category_name"] = "";
            item.Rows.InsertAt(dataRow, 0);
            return dataSet;
        }

        public DataSet getAllItemCategoryWithBlankRowForBOM()
        {
            DataSet dataSet = this.DBUtil.GetDataSet("select IC.category_id,IC.category_name  from item_category AS IC\r\nLEFT JOIN Item AS I\r\nON IC.category_id = I.sub_category_id\r\nWHERE I.product_type IN('R','P') AND IC.Is_deleted=false AND IC.category_level = 2 order by category_name ", "ItemCategory");
            DataTable item = dataSet.Tables[0];
            DataRow dataRow = item.NewRow();
            dataRow["category_id"] = -99;
            dataRow["category_name"] = "";
            item.Rows.InsertAt(dataRow, 0);
            return dataSet;
        }

        public DataSet getAllItemCategoryWithBlankRowForBOM2()
        {
            DataSet dataSet = this.DBUtil.GetDataSet("select distinct IC.category_id,IC.category_name  from item_category AS IC\r\n                            LEFT JOIN Item AS I\r\n                            ON IC.category_id = I.sub_category_id\r\n                            WHERE I.product_type IN('R','P') AND IC.Is_deleted=false \r\n                            AND IC.category_level = 2 order by category_name ", "ItemCategory");
            DataTable item = dataSet.Tables[0];
            DataRow dataRow = item.NewRow();
            dataRow["category_id"] = -99;
            dataRow["category_name"] = "";
            item.Rows.InsertAt(dataRow, 0);
            return dataSet;
        }

        public DataSet getAllItemForBOM()
        {
            return this.DBUtil.GetDataSet("select Item_id,item_name||'--'||hs_code item_name from Item where Is_deleted=false AND item_type = 'I' AND product_type IN('R','P','C','F','W')  order by item_name", "AllItem");
        }

        public DataSet getAllItemForBOMWithParameter(int item_id)
        {
            string str = string.Concat("select Item_id,item_name||'--'||hs_code item_name from Item where Is_deleted=false AND item_type = 'I' AND product_type IN('R','P') AND item_id = ", item_id, " order by item_name ");
            return this.DBUtil.GetDataSet(str, "AllItem");
        }

        public DataSet getAllItemForBOMWithService()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { "select distinct * from\r\n(select Item_id,item_name||'--'||hs_code item_name from Item where Is_deleted=false AND item_type IN('I','S') AND product_type IN('R') and (organization_id=", num, " or is_for_all_bss_unit=true)\r\n                         union all\r\n                            select distinct i.Item_id,item_name || '--' || hs_code item_name from Item i\r\n                            inner join gift_items_detail gid on gid.item_id = i.item_id\r\n                            where i.Is_deleted = false AND item_type IN('I', 'S')                    \r\n                            and(i.organization_id=", num, " or is_for_all_bss_unit = true)order by item_name)m" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "AllItem");
        }

        public DataSet getAllItemForBOMWithServiceN()
        {
            return this.DBUtil.GetDataSet("select Item_id,item_name||'--'||hs_code item_name from Item where Is_deleted=false AND item_type IN('I','S') AND product_type IN('F','P','W','M') order by item_name", "AllItem");
        }

        public DataSet getAllItemForReport621()
        {
            DataSet dataSet;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select Item_id,item_name||'--'||hs_code item_name from Item where (organization_id = ", num, " OR is_for_all_bss_unit=true) AND Is_deleted=false AND item_type IN('I','S') AND product_type IN('F','P','W','M') order by item_name");
                dataSet = this.DBUtil.GetDataSet(str, "AllItem");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataSet;
        }


        public DataSet getAllItemForReport621S()
        {
            DataSet dataSet;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select Item_id,item_name||'--'||hs_code item_name from Item where (organization_id = ", num, " OR is_for_all_bss_unit=true) AND Is_deleted=false AND item_type IN('I','S') AND product_type IN('F','P','W','M') AND is_tp=1 order by item_name");
                dataSet = this.DBUtil.GetDataSet(str, "AllItem");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataSet;
        }

        public DataSet getAllRawItemForBOM()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select Item_id,item_name||'--'||hs_code item_name from Item where Is_deleted=false AND item_type = 'I' AND product_type = 'R' and (organization_id=", num, " or is_for_all_bss_unit=true) order by item_name");
            return this.DBUtil.GetDataSet(str, "AllItem");
        }

        public DataSet GetFinishProduction()
        {
            return this.DBUtil.GetDataSet("Select * from item WHERE Product_type = 'C' AND is_deleted = false ORDER BY item_name", "Item");
        }

        public int getItemCategoryId(int intItemId)
        {
            string str = string.Concat("Select category_id from Item where Item_id='", intItemId, "'");
            return Convert.ToInt32(this.DBUtil.GetSingleValue(str));
        }

        public DataSet GetItemInfoForReport()
        {
            DataSet dataSet;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select Item_id,item_name||'--'||hs_code item_name from Item where Is_deleted=false AND organization_id = ", num, " AND item_type IN('I','S') AND product_type IN('R') order by item_name");
                dataSet = this.DBUtil.GetDataSet(str, "AllItem");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataSet;
        }

        public DataSet GetProductForPD()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("Select * from item WHERE is_price_declaration = true AND is_deleted = false and (organization_id=", num, " or is_for_all_bss_unit=true) ORDER BY item_name");
            return this.DBUtil.GetDataSet(str, "Item");
        }
    }
}

