using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class vatcommissionerateBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public vatcommissionerateBLL()
        {
        }

        public bool deleteCommissionerate(int intCommissionerateId)
        {
            string str = string.Concat("UPDATE vat_commissionerate SET Is_deleted=true WHERE comm_id = '", intCommissionerateId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public bool deleteDesignation(int intCommissionerateId)
        {
            string str = string.Concat("UPDATE vat_commissionerate SET Is_deleted=true WHERE comm_id = '", intCommissionerateId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable GetAllCommName(string commName)
        {
            string str = string.Concat("select comm_name from vat_commissionerate where upper(comm_name)  = '", commName, "' AND Is_deleted = false ORDER BY comm_name;");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getCommissionerate(int intCommissionerateId)
        {
            string str = string.Concat(" SELECT vc.*, su.upazila_name uName, suw.union_ward_name uwName,ps.police_station_name from vat_commissionerate vc \r\n        left join set_upazila su on vc.upazila_id=su.upazila_id \r\n        left join set_union_ward suw on vc.union_ward_id=suw.union_ward_id\r\n        left join set_police_station ps on suw.police_station_id=ps.police_station_id\r\n        where vc.Is_deleted=false and comm_id  = ", intCommissionerateId, " ");
            return this.DBUtil.GetDataSet(str, "Commissionerate");
        }

        public DataTable getCommissionerateDataForGv()
        {
            return this.DBUtil.GetDataTable("SELECT vc.*, su.upazila_name uName, suw.union_ward_name uwName ,ps.police_station_name ps_name\r\n                                from vat_commissionerate vc \r\n                                left join set_upazila su on vc.upazila_id=su.upazila_id \r\n                                left join set_union_ward suw on vc.union_ward_id=suw.union_ward_id \r\n                                left join set_police_station ps on suw.police_station_id=ps.police_station_id\r\n                                where vc.Is_deleted=false");
        }

        public bool InsertCommissionerate(vatcommissionerateDAO objvatcommissionerateDAO)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            empty = (objvatcommissionerateDAO.UpazillaId != 0 ? objvatcommissionerateDAO.UpazillaId.ToString() : "NULL");
            str = (objvatcommissionerateDAO.UnionWardId != 0 ? objvatcommissionerateDAO.UnionWardId.ToString() : "NULL");
            empty1 = (objvatcommissionerateDAO.PoliceStationId != 0 ? objvatcommissionerateDAO.PoliceStationId.ToString() : "NULL");
            string[] comName = new string[] { "INSERT INTO vat_commissionerate (comm_name, comm_code, address, phone_no, upazila_id, union_ward_id,police_station_id) VALUES   ( '", objvatcommissionerateDAO.ComName, "','", objvatcommissionerateDAO.ComCode, "','", objvatcommissionerateDAO.Address, "',\r\n        '", objvatcommissionerateDAO.PhoneNo, "',", empty, ",", str, ",", empty1, ")" };
            string str1 = string.Concat(comName);
            return this.DBUtil.ExecuteDML(str1);
        }

        public bool UpdateCommissionerate(vatcommissionerateDAO objvatcommissionerateDAO, int comm_id)
        {
            object[] comName = new object[] { "Update vat_commissionerate  SET comm_name = '", objvatcommissionerateDAO.ComName, "', comm_code = '", objvatcommissionerateDAO.ComCode, "', address = '", objvatcommissionerateDAO.Address, "', phone_no = '", objvatcommissionerateDAO.PhoneNo, "', upazila_id = '", objvatcommissionerateDAO.UpazillaId, "', union_ward_id = '", objvatcommissionerateDAO.UnionWardId, "' ,police_station_id= '", objvatcommissionerateDAO.PoliceStationId, "' WHERE comm_id = ", comm_id };
            string str = string.Concat(comName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}