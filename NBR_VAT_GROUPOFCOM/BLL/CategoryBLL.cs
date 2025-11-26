using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CategoryBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public CategoryBLL()
        {
        }

        public DataSet getAllCategoryName()
        {
            return this.DBUtil.GetDataSet("select  category_name ,category_id from item_category where Is_deleted=false AND category_level = 1 /*and category_type='I'*/ ORDER BY category_name", "Category");
        }

        public DataSet getAllCategoryNameForTaxValues()
        {
            DataSet dataSet;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select  category_name ,category_id from item_category where Is_deleted=false AND organization_id=", num, " AND category_level = 1 /*and category_type='I'*/ ORDER BY category_name");
                dataSet = this.DBUtil.GetDataSet(str, "Category");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataSet;
        }
    }
}