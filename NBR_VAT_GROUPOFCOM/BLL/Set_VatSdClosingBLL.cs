using System;
using System.Data;
using System.Web;
using System.Web.SessionState;


namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class Set_VatSdClosingBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public Set_VatSdClosingBLL()
        {
        }

        public bool deleteDesignation(int designationId)
        {
            string str = string.Concat("UPDATE admn_designation SET Is_deleted=true WHERE designation_id = '", designationId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable GetDepartment()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select department_id, department_name \r\n                            from admn_department \r\n                            where is_deleted = false \r\n                            order by department_name");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataSet getDesignation(int designationId)
        {
            string str = string.Concat(" select * from admn_designation  where designation_id = '", designationId, "'");
            return this.DBUtil.GetDataSet(str, "Designation");
        }

        public DataTable getDesignationDataForGv()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.DBUtil.GetDataTable("select * from vat_sd_closing where is_deleted = false order by date_closing");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getVatSdAdjustmentDataForGv()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
                string str = string.Concat("select case when type_closing = 'V' then 'VAT' else 'SD' end AS type_closing,sd_closing_balance sdClosingBalance,vat_closing_balance vatClosinBbalance,vat_sd_closing_id,date_closing from vat_sd_closing where is_deleted = false  and organization_id = ", num, " and isvatsdadjustment=true order by date_closing");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataSet getVatSdClosing(int vatSdClosingId)
        {
            DataSet dataSet;
            try
            {
                string str = string.Concat(" select type_closing,closing_balance ,adjust_amount,remarks,vat_sd_closing_id,TO_CHAR(date_closing,'dd/MM/yyyy') date_closing,adjust_pct\r\n            from vat_sd_closing where is_deleted = false AND vat_sd_closing_id = ", vatSdClosingId, " order by date_closing   ");
                dataSet = this.DBUtil.GetDataSet(str, "Designation");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataSet;
        }

        public DataSet getVatSdClosing18_6(int vatSdClosingId)
        {
            DataSet dataSet;
            try
            {
                string str = string.Concat(" select type_closing,closing_balance ,adjust_amount,remarks,vat_sd_closing_id,vat_closing_balance,sd_closing_balance,TO_CHAR(date_closing,'dd/MM/yyyy') date_closing,adjust_pct\r\n            from vat_sd_closing where is_deleted = false AND vat_sd_closing_id = ", vatSdClosingId, " order by date_closing   ");
                dataSet = this.DBUtil.GetDataSet(str, "Designation");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataSet;
        }

        public DataTable getVatSdClosingDataForGv()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
                string str = string.Concat("select case when type_closing = 'V' then 'VAT' else 'SD' end AS type_closing,closing_balance ,adjust_amount,remarks,vat_sd_closing_id,date_closing,adjust_pct \r\n                                    from vat_sd_closing\r\n                                    where is_deleted = false and organization_id = ", num, " order by date_closing");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public bool InsertVatSdAdjustment(Set_VatSdClosingDao objVatSdClosing)
        {
            bool flag;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                objVatSdClosing.vatSdClosingId = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('vat_sd_id_seq')"));
                object[] str = new object[] { "INSERT INTO vat_sd_closing(vat_sd_closing_id, type_closing, vat_closing_balance,sd_closing_balance, is_deleted, date_closing,organization_id,isVATSDadjustment) VALUES   (", objVatSdClosing.vatSdClosingId, ", '", objVatSdClosing.typeClosing, "',", objVatSdClosing.vatClosinBbalance, ",", objVatSdClosing.sdClosingBalance, ",\r\n                                 '", objVatSdClosing.Is_deleted, "',to_timestamp('", null, null, null, null, null, null };
                str[11] = objVatSdClosing.Date_closing.ToString("MM/dd/yyyy HH:mm");
                str[12] = "','MM/dd/yyyy HH24:MI'),";
                str[13] = num;
                str[14] = ",'";
                str[15] = objVatSdClosing.IsVATSDAdjustment;
                str[16] = "')";
                string str1 = string.Concat(str);
                flag = this.DBUtil.ExecuteDML(str1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool InsertVatSdClosing(Set_VatSdClosingDao objVatSdClosing)
        {
            bool flag;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                objVatSdClosing.vatSdClosingId = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('vat_sd_id_seq')"));
                object[] str = new object[] { "INSERT INTO vat_sd_closing(vat_sd_closing_id, type_closing, closing_balance,adjust_amount,remarks, is_deleted, date_closing,adjust_pct,organization_id) VALUES   (", objVatSdClosing.vatSdClosingId, ", '", objVatSdClosing.typeClosing, "',", objVatSdClosing.closingBalance, ",", objVatSdClosing.adjustAmount, ",\r\n                                 '", objVatSdClosing.Remarks, "','", objVatSdClosing.Is_deleted, "',\r\n                                  to_timestamp('", null, null, null, null, null, null };
                str[13] = objVatSdClosing.Date_closing.ToString("MM/dd/yyyy HH:mm");
                str[14] = "','MM/dd/yyyy HH24:MI'),";
                str[15] = objVatSdClosing.adjustPct;
                str[16] = ",";
                str[17] = num;
                str[18] = ")";
                string str1 = string.Concat(str);
                flag = this.DBUtil.ExecuteDML(str1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataTable IsExistDesignationName(string designation)
        {
            string str = string.Concat("select designation_name from admn_designation WHERE UPPER(designation_name) = '", designation, "' AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDesignationNameForUpdate(string designationName, int designationID)
        {
            object[] objArray = new object[] { "select designation_name from admn_designation WHERE UPPER(designation_name) = '", designationName, "' AND is_deleted = false AND designation_id <> ", designationID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDesignationShortName(string designationShortName)
        {
            string str = string.Concat("select designation_short_name from admn_designation WHERE UPPER(designation_short_name) = '", designationShortName, "' AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable IsExistDesignationShortNameForUpdate(string designationShortName, int designationID)
        {
            object[] objArray = new object[] { "select designation_short_name from admn_designation WHERE UPPER(designation_short_name) = '", designationShortName, "' AND is_deleted = false AND designation_id <> ", designationID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public bool UpdateDesignation(Set_DesignationDao objDesignation, int designationID)
        {
            object[] designationName = new object[] { "UPDATE admn_designation SET  designation_name= '", objDesignation.Designation_name, "',\r\n                                department_id = ", objDesignation.DepartmentID, ", \r\n                                designation_short_name= '", objDesignation.Designation_short_name, "',\r\n                                is_deleted = '", objDesignation.Is_deleted, "', \r\n                                date_insert = to_timestamp('", null, null, null };
            designationName[9] = objDesignation.Date.ToString("MM/dd/yyyy HH:mm");
            designationName[10] = "','MM/dd/yyyy HH24:MI') \r\n                                WHERE designation_id = ";
            designationName[11] = designationID;
            string str = string.Concat(designationName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateVatSdClosing(Set_VatSdClosingDao objVatSd, int vatSdClosingId)
        {
            bool flag;
            try
            {
                object[] str = new object[] { "UPDATE vat_sd_closing SET  type_closing= '", objVatSd.typeClosing, "',\r\n                                    closing_balance = ", objVatSd.closingBalance, ", \r\n                                    adjust_amount= ", objVatSd.adjustAmount, ",\r\n                                    remarks= '", objVatSd.Remarks, "',\r\n                                    is_deleted = '", objVatSd.Is_deleted, "', \r\n                                    date_closing = to_timestamp('", null, null, null, null, null };
                str[11] = objVatSd.Date_closing.ToString("MM/dd/yyyy HH:mm");
                str[12] = "','MM/dd/yyyy HH24:MI'),\r\n                                    adjust_pct=";
                str[13] = objVatSd.adjustPct;
                str[14] = "\r\n                                    WHERE vat_sd_closing_id = ";
                str[15] = vatSdClosingId;
                string str1 = string.Concat(str);
                flag = this.DBUtil.ExecuteDML(str1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }
    }
}

