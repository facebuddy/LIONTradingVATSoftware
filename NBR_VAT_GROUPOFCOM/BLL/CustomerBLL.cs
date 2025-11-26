using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CustomerBLL
    {
        private DBUtility db = new DBUtility();

        public CustomerBLL()
        {
        }

        public bool deleteCustomerDetail(string customer)
        {
            bool flag = false;
            try
            {
                string str = string.Concat("UPDATE set_customer\r\n                                   SET is_deleted = true where customer_name = '", customer, "'");
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }

        public DataTable GetAllCustomer()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select * from set_customer where is_deleted = false order by customer_id desc");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetCustomerByCustomerID(int CID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select * from set_customer where is_deleted = false and customer_id = ", CID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public string GetEmail(string email)
        {
            string empty = string.Empty;
            try
            {
                string str = string.Concat("select customer_email from set_customer where is_deleted = false and customer_email = '", email, "'");
                object singleValue = this.db.GetSingleValue(str);
                if (singleValue != null)
                {
                    empty = Convert.ToString(singleValue);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return empty;
        }

        public string GetMobileNo(string Mobile)
        {
            string empty = string.Empty;
            try
            {
                string str = string.Concat("select customer_mobile from set_customer where is_deleted = false and customer_mobile = '", Mobile, "'");
                object singleValue = this.db.GetSingleValue(str);
                if (singleValue != null)
                {
                    empty = Convert.ToString(singleValue);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return empty;
        }

        public bool insertCustomerDetail(CustomerDAO customer)
        {
            bool flag = false;
            try
            {
                customer.CustomerID = Convert.ToInt32(this.db.GetSingleValue("select nextval('customer_id_seq')"));
                object[] customerID = new object[] { "INSERT INTO set_customer( customer_id, customer_name, customer_address, customer_mobile, \r\n                                customer_phone, customer_email, customer_web, customer_bin, ultimate_destination, \r\n                                owner_name, owner_phone, owner_email,user_id_insert)\r\n             VALUES ( ", customer.CustomerID, ", '", customer.CustomerName, "','", customer.CustomerAddress, "','", customer.CustomerMobile, "',\r\n                    '", customer.CustomerPhone, "','", customer.CustomerEmail, "','", customer.CustomerWeb, "','", customer.CustomerBIN, "',\r\n                    '", customer.UltimateDestination, "','", customer.OwnerName, "','", customer.OwnerPhone, "','", customer.OwnerEmail, "',", customer.UserIdInsert, ")" };
                string str = string.Concat(customerID);
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }

        public bool updateCustomerDetail(CustomerDAO customer)
        {
            bool flag = false;
            try
            {
                object[] customerName = new object[] { "UPDATE set_customer\r\n                                   SET customer_name='", customer.CustomerName, "', customer_address='", customer.CustomerAddress, "', customer_mobile='", customer.CustomerMobile, "', \r\n                                       customer_phone='", customer.CustomerPhone, "', customer_email='", customer.CustomerEmail, "', customer_web='", customer.CustomerWeb, "', \r\n                                       owner_email='", customer.OwnerEmail, "',customer_bin='", customer.CustomerBIN, "', \r\n                                       ultimate_destination='", customer.UltimateDestination, "', owner_name='", customer.OwnerName, "', owner_phone='", customer.OwnerPhone, "', \r\n                                       date_updated= '", DateTime.Now, "',user_id_update=", customer.UserIdUpdated, "\r\n                                   WHERE customer_id = ", customer.CustomerID };
                string str = string.Concat(customerName);
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }
    }
}
