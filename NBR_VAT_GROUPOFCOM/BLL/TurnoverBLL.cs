using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TurnoverBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public TurnoverBLL()
        {
        }

        public bool deleteTurnover(int intTurnoverId)
        {
            string str = string.Concat("UPDATE org_item_service_turnover set Is_deleted='true' WHERE turnover_id = '", intTurnoverId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getAllTurnover()
        {
            return this.DBUtil.GetDataSet("SELECT st.*,i.Item_Name,ori.organization_name from org_item_service_turnover st left outer join\r\norg_registration_info ori on ori.Organization_id=st.Organization_id inner join\r\nItem i on i.Item_id=st.Item_id where st.Is_deleted  = 'false' Order by i.item_name", "Country");
        }

        public DataSet getTurnoverBYID(int intTurnoverId)
        {
            string str = string.Concat("SELECT * from org_item_service_turnover where turnover_id  = '", intTurnoverId, "'");
            return this.DBUtil.GetDataSet(str, "country");
        }

        public bool InsertTurnover(TurnoverDAO objTurnoverDAO)
        {
            object[] objArray = new object[] { "INSERT INTO org_item_service_turnover (Organization_id,Item_id,yearly_turnover,User_id_insert) VALUES   ('", objTurnoverDAO.intOrganizatioID, "','", objTurnoverDAO.intItemID, "','", objTurnoverDAO.decYearlyTurnover, "','", objTurnoverDAO.intUserIDInsert, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateTurnover(TurnoverDAO objTurnoverDAO)
        {
            object[] objArray = new object[] { "UPDATE org_item_service_turnover SET Organization_id ='", objTurnoverDAO.intOrganizatioID, "', Item_id='", objTurnoverDAO.intItemID, "',yearly_turnover='", objTurnoverDAO.decYearlyTurnover, "' WHERE turnover_id = '", objTurnoverDAO.intTurnoverID, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}