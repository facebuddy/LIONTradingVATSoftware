using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class setUpazilaBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public setUpazilaBLL()
        {
        }

        public DataSet CheckUpazilla(setUpazilDAO objsetUpazilDAO)
        {
            object[] upazilaName = new object[] { "select * from set_upazila where is_deleted=true and upazila_name='", objsetUpazilDAO.UpazilaName, "' and district_id =", objsetUpazilDAO.DistrictId };
            string str = string.Concat(upazilaName);
            return this.DBUtil.GetDataSet(str, "Upazilla");
        }

        public bool deleteUpazila(int intUpazilaId)
        {
            string str = string.Concat("UPDATE set_upazila SET Is_deleted=true WHERE upazila_id = '", intUpazilaId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public bool enableDeletedUpazilla(setUpazilDAO objsetUpazilDAO)
        {
            object[] upazilaName = new object[] { "update set_upazila set is_deleted = false where is_deleted=true and upazila_name='", objsetUpazilDAO.UpazilaName, "' and district_id =", objsetUpazilDAO.DistrictId };
            string str = string.Concat(upazilaName);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable getAllUpazilaData()
        {
            return this.DBUtil.GetDataTable("select upazila_id, upazila_name, district_id from set_upazila where Is_deleted=false order by upazila_name");
        }

        public DataTable getDistrictName()
        {
            return this.DBUtil.GetDataTable("select * from set_district where Is_deleted=false order by district_name");
        }

        public DataTable getUpazila(int intUpazilaId)
        {
            string str = string.Concat("select up.*, dis.district_id from set_upazila up \r\n        inner join set_district dis on up.district_id=dis.district_id where up.Is_deleted=false and up.upazila_id='", intUpazilaId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getUpazillaforgv()
        {
            return this.DBUtil.GetDataTable("select up.*, dis.district_name disName from set_upazila up \r\n        inner join set_district dis on up.district_id=dis.district_id where up.Is_deleted=false order by up.upazila_name");
        }

        public bool InsertDistrict(setUpazilDAO objsetUpazilDAO)
        {
            object[] upazilaName = new object[] { "INSERT INTO set_upazila (upazila_name, district_id) VALUES   ( '", objsetUpazilDAO.UpazilaName, "','", objsetUpazilDAO.DistrictId, "')" };
            string str = string.Concat(upazilaName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateDistrict(setUpazilDAO objsetUpazilDAO, int intUpazilaId)
        {
            object[] upazilaName = new object[] { "Update set_upazila set  upazila_name='", objsetUpazilDAO.UpazilaName, "', district_id='", objsetUpazilDAO.DistrictId, "' where upazila_id=", intUpazilaId };
            string str = string.Concat(upazilaName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}