using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ItemTaxCategoryBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public ItemTaxCategoryBLL()
        {
        }

        public DataSet getAllItemTaxCategoryFalse()
        {
            return this.DBUtil.GetDataSet("select tax_id,tax_code from item_tax_category where is_annx=false and tax_code not in ('ATV','TTI','Trade Price') order by serial ", "ItemTaxCategory");
        }

        public DataSet getAllItemTaxCategoryTrue()
        {
            return this.DBUtil.GetDataSet("select tax_id,tax_code from item_tax_category where is_annx=true", "ItemTaxCategory");
        }

        public DataSet getAllItemTaxValues(string strItemId)
        {
            string str = "";
            str = string.Concat("select item_name,branch_name,order_by from item \r\n            where i.Is_deleted=false ", strItemId, " true order by order_by ");
            return this.DBUtil.GetDataSet(str, "Item");
        }

        public DataSet getLimitInformation()
        {
            return this.DBUtil.GetDataSet("select 1 tax_id,0 as upper_limit, 0 as lower_limit,0 as vat_amount from item_tax_category limit 1", "ItemTaxCategory");
        }

        public DataSet getLimitInformationTobacco()
        {
            return this.DBUtil.GetDataSet("select  tax_id,0 as upper_limit, 0 as lower_limit,0 as vat_amount,0 as sd_amount from item_tax_category limit 1", "ItemTaxCategory");
        }

        public DataSet getPerInformation()
        {
            return this.DBUtil.GetDataSet("select 1 tax_id,'-' as unit_name, '' as per,0 as vat_amount from item_tax_category limit 1", "ItemTaxCategory");
        }

        public DataSet LoadItemWithOrder()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select i.item_name,i.branch_name,i.order_by from item i where i.is_deleted = false and (i.organization_id=", num, " or i.is_for_all_bss_unit=true) order by i.order_by ");
            return this.DBUtil.GetDataSet(str, "Item");
        }

        public DataSet LoadItemWithOrderWithParam(int ItemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] itemID = new object[] { "select i.item_name,i.branch_name,i.order_by from item i where i.is_deleted = false AND i.item_id = ", ItemID, " and (i.organization_id=", num, " or i.is_for_all_bss_unit=true) i.order by order_by " };
            string str = string.Concat(itemID);
            return this.DBUtil.GetDataSet(str, "Item");
        }

        public bool UpdateitemOrder(int branchID, string branch_name, string order_by, int itemID)
        {
            object[] objArray = new object[] { "Update item  SET org_branch_reg_id = ", branchID, " , branch_name = '", branch_name, "', order_by = ", Convert.ToInt32(order_by), " WHERE item_id = ", itemID };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}