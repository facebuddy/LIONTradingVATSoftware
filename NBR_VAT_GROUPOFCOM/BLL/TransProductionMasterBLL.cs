using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TransProductionMasterBLL
    {
        private DBUtility connDB = new DBUtility();

        private DBUtility DBUtil = new DBUtility();

        public TransProductionMasterBLL()
        {
        }

        public DataTable GetChallanBatchNo(DateTime ProductionYear)
        {
            string str = string.Concat("Select coalesce(Max(Cg_challan_batch_no),0)+1 as cg_challan_no  from trns_production_master where Production_year='", ProductionYear.Year, "' and Material_type='R'");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetChallanBatchNoForFinishedProduct(DateTime ProductionYear)
        {
            string str = string.Concat("Select coalesce(Max(Cg_challan_batch_no),0)+1 as cg_challan_no  from trns_production_master where Production_year='", ProductionYear.Year, "' and Material_type='F'");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetProductionId()
        {
            return this.connDB.GetDataTable("select nextval('production_id_seq') as ProductId");
        }

        public bool insertInsertTransProductionMaster(TransProductionMasterDAO objTransProductionMaster)
        {
            object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,Organization_id,Date_production,User_id_insert,Challan_batch_no,Production_year,Cg_challan_batch_no) VALUES   ('", objTransProductionMaster.ProductionId, "','", objTransProductionMaster.OrganizationId, "',' ", objTransProductionMaster.ProductionDate, "','", objTransProductionMaster.UserIdInsert, "','", objTransProductionMaster.ChallanBatchNo, "','", null, null, null, null };
            productionId[11] = objTransProductionMaster.ProductTionYear.Year;
            productionId[12] = "',' ";
            productionId[13] = objTransProductionMaster.CgChallanBatchNo;
            productionId[14] = "')";
            string str = string.Concat(productionId);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool insertInsertTransProductionMasterForFinishedProduct(TransProductionMasterDAO objTransProductionMaster)
        {
            object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,Organization_id,Material_type,Date_production,User_id_insert,Challan_batch_no,Production_year,Cg_challan_batch_no) VALUES   ('", objTransProductionMaster.ProductionId, "','", objTransProductionMaster.OrganizationId, "','", objTransProductionMaster.MaterialType, "',' ", objTransProductionMaster.ProductionDate, "','", objTransProductionMaster.UserIdInsert, "','", objTransProductionMaster.ChallanBatchNo, "','", null, null, null, null };
            productionId[13] = objTransProductionMaster.ProductTionYear.Year;
            productionId[14] = "',' ";
            productionId[15] = objTransProductionMaster.CgChallanBatchNo;
            productionId[16] = "')";
            string str = string.Concat(productionId);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}