using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class setCurrencyBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public setCurrencyBLL()
        {
        }

        public DataTable getAllCurrencyUnit()
        {
            return this.DBUtil.GetDataTable(" SELECT currency_id,concat(currency_code||'-'||currency_name) currency_code from set_currency where Is_deleted  = false Order by currency_name");
        }
    }
}
