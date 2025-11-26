using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetDivisionBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetDivisionBLL()
        {
        }

        public bool deleteDivision(int intDivisionId)
        {
            string str = string.Concat(" UPDATE set_division SET is_deleted =true where division_id=", intDivisionId);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool enableDeletedDivision(SetDivisionDAO objDivision)
        {
            object[] divisionName = new object[] { "UPDATE set_division SET is_deleted=false where division_name=upper('", objDivision.DivisionName, "') and country_id=", objDivision.CountryId, " and is_deleted=true" };
            string str = string.Concat(divisionName);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getAllDivision()
        {
            return this.DBUtil.GetDataSet(" Select Sd.division_id,Sd.division_name,Sd.division_code,sc.country_name from set_division Sd, set_country sc where  Sd.country_id=sc.country_id and Sd.Is_deleted=false order by Sd.division_name", "Division");
        }

        public DataSet getDivision(int intdivisionId)
        {
            string str = string.Concat(" Select Sd.division_id,Sd.division_name,Sd.division_code,sc.country_name,Sd.country_id from set_division Sd, set_country sc where  Sd.country_id=sc.country_id and Sd.division_id='", intdivisionId, "'");
            return this.DBUtil.GetDataSet(str, "division");
        }

        public DataTable GetDivisionAndCode(string divisionName, int country_id)
        {
            DataTable dataTable = new DataTable();
            object[] objArray = new object[] { "Select * from set_division where upper(division_name) ='", divisionName, "' and country_id=", country_id };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetDivisionExistsInDistrict(int intDivisionId)
        {
            DataTable dataTable = new DataTable();
            string str = string.Concat("Select * from set_district where division_id=", intDivisionId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetDivisionFromDistrict(int intDivisionId)
        {
            DataTable dataTable = new DataTable();
            string str = string.Concat("Select * from set_district where division_id=", intDivisionId);
            return this.DBUtil.GetDataTable(str);
        }

        public bool InsertDivision(SetDivisionDAO objDivision)
        {
            object[] divisionName = new object[] { "INSERT INTO set_division (division_name,division_code,country_id) VALUES   ( upper('", objDivision.DivisionName, "'),'", objDivision.DivisionCode, "','", objDivision.CountryId, "')" };
            string str = string.Concat(divisionName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateDivision(int intDivisionId, string strDivisionName, string strDivisionCode, int CountryId)
        {
            object[] objArray = new object[] { " UPDATE set_division SET division_name = upper('", strDivisionName, "'), division_code='", strDivisionCode, "',country_id='", CountryId, "' WHERE division_id = '", intDivisionId, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}
