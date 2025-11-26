using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UnitBLL
    {
        private DBUtility connDB = new DBUtility();

        public UnitBLL()
        {
        }

        public double convertAmountToDesiredUnit(decimal amount, int fromUNit, int toUnit)
        {
            decimal num = new decimal(0);
            if (fromUNit != toUnit)
            {
                decimal unitConversionValue = this.getUnitConversionValue(toUnit, fromUNit);
                decimal unitConversionValue1 = this.getUnitConversionValue(fromUNit, toUnit);
                if (unitConversionValue > new decimal(0))
                {
                    num = amount * unitConversionValue;
                }
                else if (unitConversionValue1 > new decimal(0))
                {
                    num = amount / unitConversionValue1;
                }
            }
            else
            {
                num = amount;
            }
            return Convert.ToDouble(num);
        }

        public bool DeleteUnit(SetUnitDAO objUnitDAO)
        {
            string str = string.Concat("UPDATE item_UNIT SET IS_DELETED = true WHERE UNIT_ID = '", objUnitDAO.UnitId, "'");
            return this.connDB.ExecuteDML(str);
        }

        public string findValueAdditionItem(int code_d, int code_m)
        {
            object[] codeD = new object[] { "Select code_name FROM principal_value_addition_detail where code_id_d = '", code_d, "' and code_id_m = '", code_m, "' " };
            string str = string.Concat(codeD);
            object singleValue = this.connDB.GetSingleValue(str);
            string str1 = "";
            if (singleValue != null)
            {
                str1 = singleValue.ToString();
            }
            return str1;
        }

        public DataSet getAllUnit()
        {
            return this.connDB.GetDataSet("select * from item_unit where Is_deleted=false order by unit_name", "detailCode");
        }

        public DataSet getAllUnitByMeasurementType(int MeasurementID)
        {
            string str = string.Concat("Select UNIT_ID, UNIT_CODE, UNIT_NAME from item_UNIT Where Is_deleted = false and MEASUREMENT_ID_D='", MeasurementID, "' Order by UNIT_NAME");
            return this.connDB.GetDataSet(str, "detailCode");
        }

        public DataSet GetAllUnitConversion(int intMeasurementType)
        {
            string str = string.Concat("SELECT iuc.CONVERSION_ID,iuc.UNIT_ID_FROM,iu.unit_name UNIT_NAME_FROM,iuc.VALUE_FROM,iuc.UNIT_ID_TO,\r\n                                iu0.unit_name UNIT_NAME_TO, iuc.VALUE_TO, iuc.measurement_id_d,Cd.CODE_SHORT_NAME,iuc.Date_insert\r\n                                FROM item_unit_conversion iuc\r\n                                inner JOIN item_unit iu ON iu.UNIT_ID=iuc.UNIT_ID_FROM\r\n                                inner JOIN item_unit iu0 ON iu0.UNIT_ID=iuc.UNIT_ID_TO\r\n                                inner JOIN app_code_detail Cd ON Cd.code_id_d = iuc.measurement_id_d AND \r\n                                Cd.code_id_m = iuc.measurement_id_m \r\n                                WHERE iuc.Is_deleted = false AND iuc.MEASUREMENT_ID_D='", intMeasurementType, "'");
            return this.connDB.GetDataSet(str, "ALL_CURRENCY");
        }

        public DataSet GetAllUnitExceptSelectedUnit(int measurementID, int unitID)
        {
            object[] objArray = new object[] { "Select UNIT_ID, UNIT_NAME from item_UNIT Where Is_deleted = false and UNIT_ID<>'", unitID, "' AND MEASUREMENT_ID_D='", measurementID, "' Order by UNIT_NAME" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataSet(str, "detailCode");
        }

        public DataSet GetAllUnitFromTable()
        {
            return this.connDB.GetDataSet("\r\n            select distinct item_unit.unit_id,item_unit.unit_name,item_unit.unit_code,item_unit_conversion.value_to from item_unit \r\n            RIGHT JOIN item_unit_conversion\r\n            ON item_unit.unit_id = item_unit_conversion.unit_id_to\r\n            WHERE item_unit.Is_deleted = false and item_unit_conversion.is_deleted = false ORDER BY unit_name", "detailCode");
        }

        public DataTable getAllUnitType()
        {
            string str = string.Concat("select * from app_code_detail\r\n                            where code_id_m = ", AllConstraint.measurementTypeMasterId, " order by code_id_d");
            return this.connDB.GetDataTable(str);
        }

        public DataSet getAllUnitWithParameter(int unit_id)
        {
            string str = string.Concat("select distinct * from item_unit where Is_deleted=false AND unit_id = ", unit_id, " order by unit_name ");
            return this.connDB.GetDataSet(str, "detailCode");
        }

        public DataSet getUnitConversionByConversionID(int intMeasurementID, int conversionID)
        {
            object[] objArray = new object[] { "SELECT *  FROM item_UNIT_CONVERSION WHERE MEASUREMENT_ID_D='", intMeasurementID, "' and  conversion_id = ", conversionID };
            string str = string.Concat(objArray);
            return this.connDB.GetDataSet(str, "UNITCONVERSION");
        }

        public decimal getUnitConversionValue(int stdUnitID, int unitID)
        {
            object[] objArray = new object[] { "SELECT VALUE_TO FROM item_UNIT_CONVERSION WHERE UNIT_ID_FROM = '", unitID, "' AND UNIT_ID_TO = '", stdUnitID, "' AND Is_deleted = false " };
            string str = string.Concat(objArray);
            object singleValue = this.connDB.GetSingleValue(str);
            decimal num = new decimal(0);
            if (singleValue != null)
            {
                num = Convert.ToDecimal(singleValue);
            }
            return num;
        }

        public DataTable GetUnitDetail(SetUnitDAO objUnitDAO)
        {
            return this.connDB.GetDataTable("select un.unit_id, un.unit_name, un.unit_code, \r\n                            un.measurement_id_m, un.measurement_id_d, Cd.code_name unit_type\r\n                             from item_unit un, app_code_detail Cd  \r\n                             where un.Is_deleted = false\r\n                             and un. measurement_id_m = Cd.code_id_m\r\n                             and un. measurement_id_d = Cd.code_id_d\r\n                            order by un.unit_id");
        }

        public DataTable GetUnitDetailByItemId(int intItemId)
        {
            string str = "";
            str = string.Concat(" select u.*, I.HS_CODE from item_unit u INNER JOIN ITEM I ON U.UNIT_ID = I.UNIT_ID \r\n                        AND I.ITEM_ID = ", intItemId, " and I.Is_deleted=false and U.Is_deleted=false");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetUnitDetailByUnitID(int unitID)
        {
            string str = string.Concat("select un.unit_id, un.unit_name, un.unit_code, \r\n                             un.measurement_id_m, un.measurement_id_d, Cd.code_name unit_type\r\n                             from item_unit un, app_code_detail Cd  \r\n                             where un.Is_deleted = false\r\n                             and un. measurement_id_m = Cd.code_id_m\r\n                             and un. measurement_id_d = Cd.code_id_d\r\n                             and un.unit_id = ", unitID, " order by un.unit_id");
            return this.connDB.GetDataTable(str);
        }

        public bool InsertUnit(SetUnitDAO objUnitDAO)
        {
            string str = "";
            objUnitDAO.UnitId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('unit_id_seq')"));
            object[] unitId = new object[] { " insert into item_unit(unit_id, unit_name,unit_code, measurement_id_m , measurement_id_d)\r\n\t                values (", objUnitDAO.UnitId, ",  upper('", objUnitDAO.UnitName, "'), upper('", objUnitDAO.UnitCode, "'), ", objUnitDAO.MeasurementIdM, ", ", objUnitDAO.MeasurementIdD, ")" };
            str = string.Concat(unitId);
            return this.connDB.ExecuteDML(str);
        }

        public bool InsertUnitConversion(SET_UNIT_CONVERSION_DAO objUnitConvertion)
        {
            objUnitConvertion.ConversionId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('unit_conversion_id_seq')"));
            object[] objArray = new object[] { "INSERT INTO item_UNIT_CONVERSION (MEASUREMENT_ID_M,MEASUREMENT_ID_D, conversion_id,UNIT_ID_FROM,VALUE_FROM,UNIT_ID_TO,VALUE_TO,CONVERSION_TYPE)  VALUES (  '", objUnitConvertion.measurementIDM, "','", objUnitConvertion.measurementIDD, "', ", objUnitConvertion.ConversionId, ",   '", objUnitConvertion.UnitIdFrom, "', '", objUnitConvertion.ValueFrom, "','", objUnitConvertion.UnitIdTo, "', '", objUnitConvertion.ValueTo, "','", objUnitConvertion.ConversionType, "')" };
            string str = string.Concat(objArray);
            return this.connDB.ExecuteDML(str);
        }

        public bool InsertValueAddition(string item, int code_d, int code_m, string status)
        {
            object[] objArray = new object[] { "INSERT INTO principal_value_addition_detail (code_name, code_id_d, code_id_m, vStatus)  VALUES (  '", item, "','", code_d, "','", code_m, "', '", status, "'  )" };
            string str = string.Concat(objArray);
            return this.connDB.ExecuteDML(str);
        }

        public bool UpdateUnit(SetUnitDAO objUnitDAO)
        {
            string str = "";
            object[] unitName = new object[] { "update item_unit set unit_name = upper('", objUnitDAO.UnitName, "') , unit_code = upper('", objUnitDAO.UnitCode, "'), measurement_id_d = ", objUnitDAO.MeasurementIdD, " where unit_id = ", objUnitDAO.UnitId };
            str = string.Concat(unitName);
            return this.connDB.ExecuteDML(str);
        }

        public bool updateUnitConvertion(SET_UNIT_CONVERSION_DAO objUnitUpdateConversionDAO)
        {
            object[] unitIdFrom = new object[] { " UPDATE item_UNIT_CONVERSION SET UNIT_ID_FROM = '", objUnitUpdateConversionDAO.UnitIdFrom, "',VALUE_FROM = '", objUnitUpdateConversionDAO.ValueFrom, "',UNIT_ID_TO='", objUnitUpdateConversionDAO.UnitIdTo, "',VALUE_TO='", objUnitUpdateConversionDAO.ValueTo, "' WHERE CONVERSION_ID = '", objUnitUpdateConversionDAO.ConversionId, "'" };
            string str = string.Concat(unitIdFrom);
            return this.connDB.ExecuteDML(str);
        }

        public bool UpdateValueAdditionStatus(string item, int code_d, int code_m, string status)
        {
            object[] objArray = new object[] { "UPDATE principal_value_addition_detail SET vStatus = '", status, "' where code_name = '", item, "' and code_id_d = '", code_d, "' and code_id_m = '", code_m, "' " };
            string str = string.Concat(objArray);
            return this.connDB.ExecuteDML(str);
        }
    }
}
