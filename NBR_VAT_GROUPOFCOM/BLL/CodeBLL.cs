using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CodeBLL
    {
        private DBUtility connDB = new DBUtility();

        public CodeBLL()
        {
        }

        public bool DeleteBaseData(APP_CODE_DETAIL_DAO objDetailDAO)
        {
            string str = "";
            object[] codeIDM = new object[] { "UPDATE APP_CODE_DETAIL SET IS_DELETED = true WHERE CODE_ID_M = ", objDetailDAO.CodeIDM, " AND CODE_ID_D = ", objDetailDAO.CodeIDD };
            str = string.Concat(codeIDM);
            return this.connDB.ExecuteDML(str);
        }

        public DataSet GetAllDetailCode(int masterID)
        {
            string str = string.Concat("Select CODE_ID_D, CODE_SHORT_NAME from APP_CODE_DETAIL Where IS_DELETED = false and CODE_ID_M='", masterID, "' Order by CODE_ID_D");
            return this.connDB.GetDataSet(str, "dt");
        }

        public DataSet GetAllInstrumentTypeCode()
        {
            return this.connDB.GetDataSet("Select CODE_ID_D, CODE_SHORT_NAME from APP_CODE_DETAIL Where IS_DELETED = false and CODE_ID_M=11 Order by CODE_ID_D", "dt");
        }

        public DataTable GetAllReason()
        {
            return this.connDB.GetDataTable("select code_id_d,code_short_name from app_code_detail where code_id_m=10 and Is_deleted=false");
        }

        public DataTable GetAppCodeMaster()
        {
            string str = "select * from app_code_master order by code_name_m";
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetChallanDeliveryDelay()
        {
            return this.connDB.GetDataTable("select code_id_d,code_short_name, code_value_1st from app_code_detail where code_id_m=13 and code_id_d=1 and Is_deleted=false");
        }

        public DataTable GetChallanPgeDiscardReason()
        {
            return this.connDB.GetDataTable("select code_id_d,code_short_name from app_code_detail where code_id_m=12 and Is_deleted = false order by code_id_d");
        }

        public DataTable GetDataFromItem(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select measurement_id_d from item where measurement_id_m=", codeId_m, " and measurement_id_d=", codeId_d, " " };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromItemProperty(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select property_type_d from item_property where property_type_m=", codeId_m, " and property_type_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromItemProRelation(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select property_type_d from item_pro_relation where property_type_m=", codeId_m, " and property_type_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromItemUnit(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select measurement_id_d from item_unit where measurement_id_m=", codeId_m, " and measurement_id_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromItemUnitConversion(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select measurement_id_d from item_unit_conversion where measurement_id_m=", codeId_m, " and measurement_id_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromOrgRegInfo(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select org_type_id_d from org_registration_info where org_type_id_m=", codeId_m, " and org_type_id_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromPrchaseMaster(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select vehicle_type_d from trns_purchase_master where vehicle_type_m=", codeId_m, " and vehicle_type_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromPriceValueAdditionArea(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select value_adtn_item_d from price_value_addition_area where value_adtn_item_m=", codeId_m, " and value_adtn_item_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDataFromSaleMaster(int codeId_d, int codeId_m)
        {
            object[] codeIdM = new object[] { "select vehicle_type_d from trns_sale_master where vehicle_type_m=", codeId_m, " and vehicle_type_d=", codeId_d };
            string str = string.Concat(codeIdM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDetailCodeByMasterId(APP_CODE_DETAIL_DAO objDetailDAO)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            if (objDetailDAO.CodeName != "")
            {
                str = string.Concat(" AND lower(CODE_NAME) LIKE lower('%", objDetailDAO.CodeName, "%') ");
            }
            if (objDetailDAO.CodeShortName != "")
            {
                str1 = string.Concat(" AND lower(CODE_SHORT_NAME) LIKE lower('%", objDetailDAO.CodeShortName, "%') ");
            }
            if (objDetailDAO.CodeValue1st > 0 && objDetailDAO.CodeValue2nd > 0)
            {
                object[] codeValue1st = new object[] { " AND CODE_VALUE_1ST = ", objDetailDAO.CodeValue1st, " AND CODE_VALUE_2ND = ", objDetailDAO.CodeValue2nd };
                str2 = string.Concat(codeValue1st);
            }
            object[] codeIDM = new object[] { "SELECT CODE_ID_M, CODE_ID_D, CODE_NAME, CODE_SHORT_NAME, CODE_VALUE_1ST, CODE_VALUE_2ND, CODE_STRING_1ST, CODE_STRING_2ND, TO_CHAR(CODE_DATE_1ST,'DD/MM/YYYY') CODE_DATE_1ST, TO_CHAR(CODE_DATE_2ND,'DD/MM/YYYY') CODE_DATE_2ND\r\n                            FROM APP_CODE_DETAIL\r\n                            WHERE CODE_ID_M = ", objDetailDAO.CodeIDM, " AND IS_DELETED = false", str, str1, str2, " ORDER BY CODE_ID_D" };
            string str3 = string.Concat(codeIDM);
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str3);
        }

        public short GetDetailCodeIdbyCodeName(string codeName)
        {
            short num = 0;
            string str = string.Concat("SELECT CODE_ID_M, CODE_ID_D, CODE_NAME, CODE_SHORT_NAME FROM APP_CODE_DETAIL\r\n                            WHERE CODE_ID_M = 5 and code_name='", codeName, "' AND IS_DELETED = false ORDER BY CODE_ID_D");
            DataTable dataTable = new DataTable();
            dataTable = this.connDB.GetDataTable(str);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                num = Convert.ToInt16(dataTable.Rows[0]["CODE_ID_D"]);
            }
            return num;
        }

        public DataTable getIsExistDescriptionSave(string description)
        {
            string str = string.Concat(" select * from app_code_master WHERE upper(code_name_m) =  '", description, "'");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getIsExistDescriptionUpdate(string description, int id)
        {
            object[] objArray = new object[] { " select * from app_code_master WHERE upper(code_description) =  '", description, "' AND code_id_m <> ", id };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getIsExistNameSave(string name)
        {
            string str = string.Concat(" select * from app_code_master WHERE upper(code_name_m) =  '", name, "'");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getIsExistNameUpdate(string name, int id)
        {
            object[] objArray = new object[] { " select * from app_code_master WHERE upper(code_name_m) =  '", name, "' AND  code_id_m <> ", id };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataSet getMasterGridClick(int Id)
        {
            string str = string.Concat(" select * from app_code_master where code_id_m = '", Id, "'");
            return this.connDB.GetDataSet(str, "Department");
        }

        public DataTable GetSystemMasterCode()
        {
            string str = "SELECT CODE_ID_m, CODE_NAME_m, CODE_TYPE, reference_id FROM APP_CODE_MASTER\r\n                        WHERE CODE_TYPE <> 0 AND IS_DELETED = false ORDER BY CODE_NAME_m";
            DataTable dataTable = new DataTable();
            return this.connDB.GetDataTable(str);
        }

        public bool InsertAppcodeMaster(APP_CODE_MASTER_DAO objMaster)
        {
            DataSet dataSet = this.connDB.GetDataSet("select code_id_m from app_code_master order by code_id_m DESC LIMIT 1", "app_code_master");
            int num = 0;
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                num = 1;
            }
            else
            {
                int num1 = Convert.ToInt16(dataSet.Tables[0].Rows[0]["code_id_m"].ToString());
                num = Convert.ToInt16(num1 + 1);
            }
            object[] mCodeName = new object[] { "INSERT INTO app_code_master( code_id_m, code_name_m, code_description, code_type, is_deleted, date_insert) VALUES   ( '", num, "','", objMaster.MCodeName, "','", objMaster.MCodeDescription, "',", objMaster.MCodeType, ",'", objMaster.IsDeleted, "',to_date('", null, null };
            mCodeName[11] = DateTime.Now.ToString("dd/MM/yyyy");
            mCodeName[12] = "','dd/MM/yyyy'))";
            string str = string.Concat(mCodeName);
            return this.connDB.ExecuteDML(str);
        }

        public bool InsertBaseData(APP_CODE_DETAIL_DAO objDetailDAO)
        {
            string str = "";
            string str1 = "";
            int num = 0;
            Convert.ToInt32(this.connDB.GetSingleValue("select max(CODE_ID_M) CODE_ID_M from APP_CODE_MASTER WHERE IS_DELETED = false "));
            if (this.connDB.GetDataTable(string.Concat("SELECT code_id_m FROM APP_CODE_DETAIL WHERE  CODE_ID_M = ", objDetailDAO.CodeIDM, " ")).Rows.Count <= 0)
            {
                num = 1;
                object[] codeIDM = new object[] { "INSERT INTO APP_CODE_DETAIL(CODE_ID_M,CODE_ID_D, CODE_NAME, CODE_SHORT_NAME, CODE_VALUE_1ST, CODE_VALUE_2ND)\r\n                    VALUES (", objDetailDAO.CodeIDM, ",", num, ",'", objDetailDAO.CodeName, "', '", objDetailDAO.CodeShortName, "', ", objDetailDAO.CodeValue1st, ", ", objDetailDAO.CodeValue2nd, ")" };
                str1 = string.Concat(codeIDM);
            }
            else
            {
                str = string.Concat("SELECT (MAX(CODE_ID_D) + 1) CODE_ID_D FROM APP_CODE_DETAIL WHERE  CODE_ID_M = ", objDetailDAO.CodeIDM, " ");
                num = Convert.ToInt32(this.connDB.GetSingleValue(str));
                object[] objArray = new object[] { "INSERT INTO APP_CODE_DETAIL(CODE_ID_M,CODE_ID_D, CODE_NAME, CODE_SHORT_NAME, CODE_VALUE_1ST, CODE_VALUE_2ND)\r\n                   VALUES (", objDetailDAO.CodeIDM, ",", num, ",'", objDetailDAO.CodeName, "', '", objDetailDAO.CodeShortName, "', ", objDetailDAO.CodeValue1st, ", ", objDetailDAO.CodeValue2nd, ")" };
                str1 = string.Concat(objArray);
            }
            return this.connDB.ExecuteDML(str1);
        }

        public bool UpdateAppcodeMaster(APP_CODE_MASTER_DAO objMaster, int id)
        {
            object[] mCodeName = new object[] { "UPDATE app_code_master  SET code_name_m = '", objMaster.MCodeName, "', code_description='", objMaster.MCodeDescription, "', code_type= ", objMaster.MCodeType, ", is_deleted= '", objMaster.IsDeleted, "', date_insert= '", null, null, null };
            mCodeName[9] = DateTime.Now.ToString();
            mCodeName[10] = "' WHERE code_id_m  = ";
            mCodeName[11] = id;
            string str = string.Concat(mCodeName);
            return this.connDB.ExecuteDML(str);
        }

        public bool UpdateBaseCodeValue(APP_CODE_DETAIL_DAO objDetailDAO)
        {
            string str = "";
            object[] codeValue1st = new object[] { "UPDATE APP_CODE_DETAIL SET CODE_VALUE_1ST = ", objDetailDAO.CodeValue1st, ", CODE_VALUE_2ND = ", objDetailDAO.CodeValue2nd, " WHERE CODE_ID_M = ", objDetailDAO.CodeIDM, " AND CODE_ID_D = ", objDetailDAO.CodeIDD };
            str = string.Concat(codeValue1st);
            return this.connDB.ExecuteDML(str);
        }

        public bool UpdateBaseData(APP_CODE_DETAIL_DAO objDetailDAO)
        {
            string str = "";
            string str1 = "";
            if (objDetailDAO.MCodeType == 6)
            {
                string[] strArrays = new string[] { " ,CODE_DATE_1ST = TO_DATE('", null, null, null, null };
                strArrays[1] = objDetailDAO.CodeDate1st.ToString("MM/dd/yyyy");
                strArrays[2] = "','MM/dd/yyyy') ,CODE_DATE_2ND = TO_DATE('";
                strArrays[3] = objDetailDAO.CodeDate2nd.ToString("MM/dd/yyyy");
                strArrays[4] = "','MM/dd/yyyy') ";
                str1 = string.Concat(strArrays);
            }
            object[] codeName = new object[] { "UPDATE APP_CODE_DETAIL SET CODE_NAME = '", objDetailDAO.CodeName, "', CODE_SHORT_NAME = '", objDetailDAO.CodeShortName, "', CODE_VALUE_1ST = ", objDetailDAO.CodeValue1st, ", CODE_VALUE_2ND  = ", objDetailDAO.CodeValue2nd, str1, " WHERE CODE_ID_M = ", objDetailDAO.CodeIDM, " AND CODE_ID_D = ", objDetailDAO.CodeIDD };
            str = string.Concat(codeName);
            return this.connDB.ExecuteDML(str);
        }
    }
}