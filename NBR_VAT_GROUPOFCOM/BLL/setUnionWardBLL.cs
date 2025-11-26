using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class setUnionWardBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public setUnionWardBLL()
        {
        }

        public bool deleteUnionWard(int intUnionWardId)
        {
            string str = string.Concat("UPDATE set_union_ward SET Is_deleted=true WHERE union_ward_id = '", intUnionWardId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable getAllUnionWardData()
        {
            return this.DBUtil.GetDataTable("select union_ward_id, union_ward_name, police_station_id, upazila_id, is_union from set_union_ward where Is_deleted=false order by union_ward_name");
        }

        public DataTable getPoliceStationDataByUnionward(int intunionID)
        {
            string str = string.Concat("select set_police_station.police_station_name,set_police_station.police_station_id from set_police_station \r\n                                inner join set_union_ward on set_police_station.police_station_id=set_union_ward.police_station_id \r\n                                where set_union_ward.union_ward_id=", intunionID, " order by set_police_station.police_station_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getUnionWard(int intUnionWardId)
        {
            string str = string.Concat("select * from set_union_ward where Is_deleted=false and union_ward_id='", intUnionWardId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getUnionWardDataByUpazila(int intUpazilaId)
        {
            string str = "";
            str = (intUpazilaId == 0 ? "select union_ward_id, union_ward_name, police_station_id, upazila_id, is_union from set_union_ward where Is_deleted=false order by union_ward_name" : string.Concat("select union_ward_id, union_ward_name, police_station_id, upazila_id, is_union from set_union_ward where Is_deleted=false and upazila_id='", intUpazilaId, "' order by union_ward_name"));
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getUnionWardDataByUpazilaThana(string union_ward_name, int intUpazilaId, int police_station_id)
        {
            string str = "";
            if (intUpazilaId == 0)
            {
                str = "select union_ward_id, union_ward_name, police_station_id, upazila_id, is_union from set_union_ward where Is_deleted=false order by union_ward_name";
            }
            else
            {
                object[] unionWardName = new object[] { "select union_ward_id, union_ward_name, police_station_id, upazila_id, is_union from set_union_ward where upper(union_ward_name)='", union_ward_name, "' and  Is_deleted=false and upazila_id='", intUpazilaId, "' and police_station_id =", police_station_id, " order by union_ward_name" };
                str = string.Concat(unionWardName);
            }
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getUnionWardforgv()
        {
            return this.DBUtil.GetDataTable("select uw.union_ward_id, uw.union_ward_name, uw.police_station_id, uw.upazila_id, \r\ncase when is_union=true then 'Yes' else 'No' end isUnion, sps.police_station_name psName, su.upazila_name uName from set_union_ward uw \r\ninner join set_police_station sps on uw.police_station_id=sps.police_station_id\r\ninner join set_upazila su on uw.upazila_id=su.upazila_id where uw.Is_deleted=false order by uw.union_ward_name");
        }

        public DataTable getUnionWardforgvbyUnionId(int intUnionWardId)
        {
            string str = string.Concat("select uw.union_ward_id, uw.union_ward_name, uw.police_station_id, uw.upazila_id, \r\ncase when is_union=true then 'Yes' else 'No' end isUnion, sps.police_station_name psName, su.upazila_name uName from set_union_ward uw \r\ninner join set_police_station sps on uw.police_station_id=sps.police_station_id\r\ninner join set_upazila su on uw.upazila_id=su.upazila_id where uw.Is_deleted=false  and uw.union_ward_id='", intUnionWardId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public bool InsertUnionWard(setUnionWardDAO objsetUnionWardDAO)
        {
            object[] unionWardName = new object[] { "INSERT INTO set_union_ward (union_ward_name, police_station_id, upazila_id, is_union) VALUES   ( '", objsetUnionWardDAO.UnionWardName, "','", objsetUnionWardDAO.PoliceStationId, "', '", objsetUnionWardDAO.UpazilaId, "', '", objsetUnionWardDAO.IsUnion, "')" };
            string str = string.Concat(unionWardName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateUnionWard(setUnionWardDAO objsetUnionWardDAO, int UpdateUnionWard)
        {
            object[] unionWardName = new object[] { "UPDATE set_union_ward set union_ward_name='", objsetUnionWardDAO.UnionWardName, "', police_station_id='", objsetUnionWardDAO.PoliceStationId, "',\r\n         upazila_id='", objsetUnionWardDAO.UpazilaId, "', is_union='", objsetUnionWardDAO.IsUnion, "' where union_ward_id=", UpdateUnionWard };
            string str = string.Concat(unionWardName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}