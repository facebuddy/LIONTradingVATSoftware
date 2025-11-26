using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class SetPoliceStationBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetPoliceStationBLL()
        {
        }

        public DataTable getAllPoliceStation()
        {
            return this.DBUtil.GetDataTable("select * from set_police_station order by police_station_name");
        }
    }
}

