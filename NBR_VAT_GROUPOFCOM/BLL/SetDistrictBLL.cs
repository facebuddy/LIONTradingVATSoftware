using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class SetDistrictBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetDistrictBLL()
        {
        }

        public bool deleteDistrict(int intDistrictId)
        {
            string str = string.Concat("UPDATE set_district SET Is_deleted=true WHERE district_id = '", intDistrictId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public bool enableDeletedDistrict(string districtName, int intDivisionId)
        {
            object[] objArray = new object[] { "UPDATE set_district SET Is_deleted=false WHERE district_name = '", districtName, "' AND division_id=", intDivisionId };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable getAllDistrict(string districtName)
        {
            string str = string.Concat("select * from set_district where Is_deleted=false and upper(district_name) = '", districtName, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getDistrict(int intDistrictId)
        {
            string str = string.Concat("select * from set_district where Is_deleted=false and district_id='", intDistrictId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getDistrictforgv()
        {
            return this.DBUtil.GetDataTable("select Sd.*, siv.division_name divName from set_district Sd \r\n        inner join set_division siv on Sd.division_id=siv.division_id where Sd.Is_deleted=false order by sd.district_name");
        }

        public bool InsertDistrict(SetDistrictDAO objSetDistrictDAO)
        {
            object[] districtName = new object[] { "INSERT INTO set_district (district_name, division_id) VALUES   ( '", objSetDistrictDAO.DistrictName, "','", objSetDistrictDAO.DivisionId, "')" };
            string str = string.Concat(districtName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateDistrict(SetDistrictDAO objSetDistrictDAO, int districtID)
        {
            object[] districtName = new object[] { "UPDATE  set_district set district_name='", objSetDistrictDAO.DistrictName, "', division_id ='", objSetDistrictDAO.DivisionId, "'\r\n           where district_id=", districtID };
            string str = string.Concat(districtName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}

