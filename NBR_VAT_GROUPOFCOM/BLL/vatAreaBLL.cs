using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class vatAreaBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public vatAreaBLL()
        {
        }

        public bool deleteArea(int intAreaId)
        {
            string str = string.Concat("UPDATE vat_area SET Is_deleted=true WHERE area_id = '", intAreaId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getArea(int intAreaId)
        {
            string str = string.Concat("select va.*, vc.circle_name cName, su.upazila_name uName, suw.union_ward_name uwName,vc.comm_id,vc.division_id from vat_area va\r\n        inner join vat_circle vc on va.circle_id=vc.circle_id\r\n        inner join set_upazila su on va.upazila_id=su.upazila_id \r\n        inner join set_union_ward suw on va.union_ward_id=suw.union_ward_id\r\n        where va.Is_deleted=false and va.area_id='", intAreaId, "'");
            return this.DBUtil.GetDataSet(str, "Area");
        }

        public DataTable getAreaDataForGv()
        {
            return this.DBUtil.GetDataTable("select va.*, vc.circle_name cName, su.upazila_name uName, suw.union_ward_name uwName from vat_area va\r\n        inner join vat_circle vc on va.circle_id=vc.circle_id\r\n        inner join set_upazila su on va.upazila_id=su.upazila_id \r\n        inner join set_union_ward suw on va.union_ward_id=suw.union_ward_id\r\n        where va.Is_deleted=false");
        }

        public bool InsertArea(vatAreaDAO objVatAreaDAO)
        {
            int num = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('vat_area_id_seq')"));
            object[] areaName = new object[] { "INSERT INTO vat_area (area_id,area_name, area_code, circle_id, address, phone_no, upazila_id, union_ward_id) VALUES   (", num, ", '", objVatAreaDAO.AreaName, "','", objVatAreaDAO.AreaCode, "','", objVatAreaDAO.CircleId, "','", objVatAreaDAO.Address, "', '", objVatAreaDAO.PhoneNo, "','", objVatAreaDAO.UpazillaId, "','", objVatAreaDAO.UnionWardId, "')" };
            string str = string.Concat(areaName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateArea(vatAreaDAO objVatAreaDAO)
        {
            Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('vat_area_id_seq')"));
            object[] areaName = new object[] { "UPDATE vat_area set area_name='", objVatAreaDAO.AreaName, "', area_code='", objVatAreaDAO.AreaCode, "', circle_id='", objVatAreaDAO.CircleId, "', \r\n        address='", objVatAreaDAO.Address, "', phone_no='", objVatAreaDAO.PhoneNo, "', upazila_id='", objVatAreaDAO.UpazillaId, "', union_ward_id= '", objVatAreaDAO.UnionWardId, "' where area_id=", objVatAreaDAO.AreaId };
            string str = string.Concat(areaName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}

