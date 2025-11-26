using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetItemPropertyBLL
    {
        private DBUtility connDB = new DBUtility();

        public SetItemPropertyBLL()
        {
        }

        public bool deleteProperty(SET_PROPERTY_DAO objPropertyDeleteDAO)
        {
            string str = string.Concat(" DELETE from item_PROPERTY WHERE PROPERTY_ID = '", objPropertyDeleteDAO.PropertyID, "' ");
            return this.connDB.ExecuteDML(str);
        }

        public DataSet getAllDetailCode()
        {
            return this.connDB.GetDataSet("Select CODE_ID_D, CODE_NAME,CODE_SHORT_NAME from APP_CODE_DETAIL Where CODE_VALUE_1ST=1 and Is_deleted = false AND CODE_ID_M=6 Order by CODE_SHORT_NAME", "property");
        }

        public DataSet GetAllProperty(int intPropertyID)
        {
            string str = string.Concat("SELECT ip.PROPERTY_ID, ip.PROPERTY_NAME, ip.PROPERTY_CODE, ip.PROPERTY_TYPE_M,ip.PROPERTY_TYPE_D,ip.Date_insert, Cd.code_short_name,Cd.CODE_NAME  FROM item_PROPERTY ip LEFT OUTER JOIN  app_code_detail Cd ON Cd.code_id_M = 6 AND Cd.code_id_d = ip.PROPERTY_TYPE_D WHERE ip.Is_deleted = false and PROPERTY_TYPE_D='", intPropertyID, "'");
            return this.connDB.GetDataSet(str, "ALL_PROPERTY");
        }

        public DataSet GetAllProperty()
        {
            return this.connDB.GetDataSet("SELECT ip.PROPERTY_ID, ip.PROPERTY_NAME, ip.PROPERTY_CODE,ip.quantity, ip.PROPERTY_TYPE_M,ip.PROPERTY_TYPE_D,ip.Date_insert\r\n                              , Cd.code_short_name,Cd.CODE_NAME \r\n                              FROM item_PROPERTY ip\r\n                              LEFT OUTER JOIN app_code_detail Cd ON Cd.code_id_M = property_type_m AND Cd.code_id_d = ip.PROPERTY_TYPE_D\r\n                              WHERE ip.Is_deleted = false  order by ip.PROPERTY_NAME, ip.PROPERTY_CODE", "ALL_PROPERTY");
        }

        public DataSet GetAllPropertyByMasterID(int propertyMasterID, int intPropertyID)
        {
            object[] objArray = new object[] { "SELECT ip.PROPERTY_ID, ip.PROPERTY_NAME, ip.PROPERTY_CODE,ip.quantity, ip.PROPERTY_TYPE_M,ip.PROPERTY_TYPE_D,ip.Date_insert, Cd.code_short_name,Cd.CODE_NAME  FROM item_PROPERTY ip LEFT OUTER JOIN  app_code_detail Cd ON Cd.code_id_M = ", propertyMasterID, " AND Cd.code_id_d = ip.PROPERTY_TYPE_D WHERE ip.Is_deleted = false and PROPERTY_TYPE_D='", intPropertyID, "' AND PROPERTY_TYPE_M = ", propertyMasterID, " order by ip.PROPERTY_NAME, ip.PROPERTY_CODE" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataSet(str, "ALL_PROPERTY");
        }

        public DataTable GetBoxQuantity(int propertyId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select property_id, property_type_m, property_type_d, property_code, quantity from item_property where property_id = ", propertyId);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetDeletedProperty(int intPropertyIdD, string strPropertyName, string strPropertyCode)
        {
            object[] objArray = new object[] { "SELECT PROPERTY_ID, PROPERTY_TYPE_D, PROPERTY_NAME, PROPERTY_CODE FROM item_PROPERTY WHERE Is_deleted = true AND PROPERTY_TYPE_D='", intPropertyIdD, "' AND PROPERTY_NAME=UPPER('", strPropertyName, "') AND PROPERTY_CODE=UPPER('", strPropertyCode, "')" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getItemByStoreIdExceptUsed(short storeID)
        {
            string str = string.Concat(" SELECT SI.ITEM_ID,SI.ITEM_NAME||'-'||SI.ITEM_SPECIFICATION ITEM_NAME FROM Item SI WHERE SI.Is_deleted = false AND SI.ITEM_ID NOT IN(  SELECT SI.ITEM_ID  FROM item_STORE_RELATION SR ,Item SI WHERE SR.ITEM_ID = SI.ITEM_ID AND  SR.STORE_ID = '", storeID, "' AND SR.Is_deleted = false)  ORDER BY SI.ITEM_NAME ");
            DataSet dataSet = this.connDB.GetDataSet(str, "ITEM");
            DataTable dataTable = new DataTable();
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                DataRow dataRow = dataTable.NewRow();
                dataRow["ITEM_ID"] = -99;
                dataRow["ITEM_NAME"] = "";
                dataTable.Rows.InsertAt(dataRow, 0);
            }
            return dataTable;
        }

        public DataTable GetItemPropertybyMasterID(short propertyMasterID)
        {
            string str = string.Concat("Select CODE_ID_D, CODE_NAME,CODE_SHORT_NAME from APP_CODE_DETAIL Where CODE_VALUE_1ST=0 AND CODE_ID_M= ", propertyMasterID, " Order by CODE_ID_D");
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataSet getPropertyByPropertyID(int propertyID)
        {
            string str = string.Concat("SELECT * FROM item_PROPERTY WHERE PROPERTY_ID = '", propertyID, "'");
            return this.connDB.GetDataSet(str, "PROPERTY");
        }

        public DataTable GetPropertyTypeByMasterID(short propertyMasterID)
        {
            string str = string.Concat("Select CODE_ID_D, CODE_NAME,CODE_SHORT_NAME from APP_CODE_DETAIL Where CODE_VALUE_1ST=0 AND CODE_ID_M= ", propertyMasterID, " Order by CODE_SHORT_NAME");
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPropertyTypesByMasterIDDetailIdBandroll(short propertyMasterID, short propertyDetailID)
        {
            object[] objArray = new object[] { "select property_id, property_name, property_code from item_property where property_type_m=", propertyMasterID, " and  property_type_d=", propertyDetailID, " and is_deleted=false" };
            string str = string.Concat(objArray);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetSystemUsedProperty()
        {
            string str = string.Concat("SELECT CODE_NAME PROPERTY_TYPE_NAME, CODE_VALUE_1ST IS_USED_BY_SYSTEM FROM APP_CODE_DETAIL WHERE CODE_ID_M = ", AllConstraint.PropertyTypeM, " AND IS_DELETED=false ORDER BY CODE_ID_D");
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable getUsedItemForStore(short storeID)
        {
            string str = string.Concat("SELECT SI.ITEM_ID,SI.ITEM_NAME||'-'||SI.ITEM_SPECIFICATION ITEM_NAME  FROM item_STORE_RELATION SR ,Item SI WHERE SR.ITEM_ID = SI.ITEM_ID AND  SR.STORE_ID = '", storeID, "' AND SR.Is_deleted = false ORDER BY SI.ITEM_NAME ");
            DataSet dataSet = this.connDB.GetDataSet(str, "ITEM");
            DataTable dataTable = new DataTable();
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                DataRow dataRow = dataTable.NewRow();
                dataRow["ITEM_ID"] = -99;
                dataRow["ITEM_NAME"] = "";
                dataTable.Rows.InsertAt(dataRow, 0);
            }
            return dataTable;
        }

        public int InsertProperty(SET_PROPERTY_DAO objProperty)
        {
            bool flag = false;
            objProperty.PropertyID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('property_id_seq')"));
            object[] propertyID = new object[] { "INSERT INTO item_PROPERTY (property_id, PROPERTY_TYPE_M,PROPERTY_TYPE_D,PROPERTY_NAME,PROPERTY_CODE,USER_ID_INSERT,quantity)  VALUES (", objProperty.PropertyID, ", '", objProperty.PropertyIdM, "','", objProperty.PropertyIdD, "',UPPER('", objProperty.PropertyName, "'),UPPER('", objProperty.PropertyCode, "'),'", objProperty.UserIdInsert, "',", objProperty.Quantity, ")" };
            string str = string.Concat(propertyID);
            flag = this.connDB.ExecuteDML(str);
            int num = -999;
            if (flag)
            {
                num = objProperty.PropertyID;
            }
            return num;
        }

        public bool updateDeletedProperty(SET_PROPERTY_DAO objPropertyUpdateDAO, int intPropertyID)
        {
            object[] objArray = new object[] { " UPDATE item_PROPERTY SET IS_DELETED=0,DATE_UPDATE = now(), USER_ID_UPDATE = '1', synchronized = 0, SYNC_TYPE = (select case when synchronized = 1 then 1 else 0 end from item_PROPERTY WHERE PROPERTY_ID = '", intPropertyID, "'  )  WHERE PROPERTY_ID = '", intPropertyID, "'  " };
            string str = string.Concat(objArray);
            return this.connDB.ExecuteDML(str);
        }

        public bool updateProperty(SET_PROPERTY_DAO objPropertyUpdateDAO)
        {
            object[] propertyName = new object[] { " UPDATE item_PROPERTY SET PROPERTY_NAME = UPPER('", objPropertyUpdateDAO.PropertyName, "'),PROPERTY_CODE = UPPER('", objPropertyUpdateDAO.PropertyCode, "'),PROPERTY_TYPE_D='", objPropertyUpdateDAO.PropertyIdD, "', DATE_UPDATE = now(), USER_ID_UPDATE = '1',quantity=", objPropertyUpdateDAO.Quantity, "  WHERE PROPERTY_ID = '", objPropertyUpdateDAO.PropertyID, "'" };
            string str = string.Concat(propertyName);
            return this.connDB.ExecuteDML(str);
        }
    }
}