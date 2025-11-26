using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetCountryBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetCountryBLL()
        {
        }

        public bool deleteCountry(int intCountryId)
        {
            string str = string.Concat("UPDATE set_country set Is_deleted='true' WHERE country_id = '", intCountryId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet dsCountry()
        {
            return this.DBUtil.GetDataSet("select organization_name,business_address,tin_company,area_id \r\nfrom org_registration_info where Is_deleted=false  and Organization_id=3", "Country");
        }

        public DataSet dsCuurentAccount()
        {
            return this.DBUtil.GetDataSet("Select '0' Sl_No_1, '' Date_2, '' Transaction_Detail_3,'' PurchaseSale_Book_Sl_No_4,'' PurchaseSale_Book_Date_5,\r\n0 Treasury_Deposit_6, 0 Rebate_7,0 Payable_8, 0 Closing_Balance_9, '' Remarks_10 from set_country", "Country");
        }

        public DataSet dsDispose()
        {
            return this.DBUtil.GetDataSet("Select '0' Sl_No_1, '' Name_of_Inputs_2, '' Sl_No_of_Purchase_Challan_and_Sales_Book_3,'' Quantity_4,'' Actual_Value_5,\r\n0 VAT_Paid_6, 0 Present_Value_7,0 Reason_for_the_Unfit_8 from set_country", "Dispose");
        }

        public DataSet dsTest()
        {
            return this.DBUtil.GetDataSet("SELECT Country_Name,Country_Code,abbr_name,''test from set_country where Is_deleted  = 'false' Order by country_name", "test");
        }

        public DataTable dtGetAllCountry()
        {
            return this.DBUtil.GetDataTable(" SELECT * from set_country where Is_deleted  = 'false' Order by country_name");
        }

        public bool enableDeletedDeleteCountry(string strCountryName)
        {
            string str = string.Concat("UPDATE set_country set Is_deleted='false' WHERE Country_name = upper('", strCountryName, "')");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getAllCountry()
        {
            return this.DBUtil.GetDataSet(" SELECT * from set_country where Is_deleted  = 'false' Order by country_name", "Country");
        }

        public DataTable GetAllCountryCode(string countryName)
        {
            string str = string.Concat(" SELECT country_name,country_code from set_country where Is_deleted  = 'false' and upper(country_name) = '", countryName, "' Order by country_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllCountryInfo()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.DBUtil.GetDataTable("SELECT * from set_country where is_deleted=false order by country_name");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllDeleteCountryCode(string countryName)
        {
            string str = string.Concat(" SELECT country_name,country_code from set_country where Is_deleted  = 'true' and country_name = '", countryName, "' Order by country_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getCountry(int intCountryId)
        {
            string str = string.Concat(" SELECT * from set_country where country_id  = '", intCountryId, "'");
            return this.DBUtil.GetDataSet(str, "country");
        }

        public DataTable getcountryBycountryID(int countryID)
        {
            string str = string.Concat("select * from set_country where is_deleted = false and country_id = ", countryID);
            return this.DBUtil.GetDataTable(str);
        }

        public bool InsertCountry(SetCountryDAO objCountry)
        {
            string[] countryName = new string[] { "INSERT INTO set_country (country_name,abbr_name,country_code) VALUES   ( upper('", objCountry.CountryName, "'),'", objCountry.CountryAbbr, "','", objCountry.CountryCode, "')" };
            string str = string.Concat(countryName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateCountry(int intCountryId, string strCountryName, string strCountryCode, string strCountryAbbr)
        {
            object[] objArray = new object[] { " UPDATE set_country SET Country_name = upper('", strCountryName, "'), country_code='", strCountryCode, "',abbr_name='", strCountryAbbr, "' WHERE country_id = '", intCountryId, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}