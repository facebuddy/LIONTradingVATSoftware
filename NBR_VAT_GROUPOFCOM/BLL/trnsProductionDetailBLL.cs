using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsProductionDetailBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public trnsProductionDetailBLL()
        {
        }

        public DataTable getOrganizationNames()
        {
            return this.DBUtil.GetDataTable("SELECT * from org_registration_info where Is_deleted=false");
        }

        public bool insertInsertTransProductionDetails(trnsProductionDetailDAO objTransProductionDetails)
        {
            object[] productionId = new object[] { "INSERT INTO trns_production_detail (Production_id,row_no,Item_id,unit_id,Quantity,unit_price,User_id_insert) VALUES   ('", objTransProductionDetails.ProductionId, "','", objTransProductionDetails.RowNo, "',' ", objTransProductionDetails.ItemId, "','", objTransProductionDetails.UnitId, "','", objTransProductionDetails.Quantity, "',' ", objTransProductionDetails.UnitPrice, "',' ", objTransProductionDetails.UserIdInsert, "')" };
            string str = string.Concat(productionId);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}
