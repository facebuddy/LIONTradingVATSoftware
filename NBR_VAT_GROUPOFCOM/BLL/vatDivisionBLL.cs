using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class vatDivisionBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public vatDivisionBLL()
        {
        }

        public bool deleteDivision(int intDivisionId)
        {
            string str = string.Concat("UPDATE vat_division SET Is_deleted=true WHERE division_id = '", intDivisionId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getDivision(int intDivisionId)
        {
            string str = string.Concat("select vd.*,VC.comm_name, su.upazila_name uName, suw.union_ward_name uwName from vat_division vd\r\n        inner join set_upazila su on vd.upazila_id=su.upazila_id \r\n        inner join set_union_ward suw on vd.union_ward_id=suw.union_ward_id\r\n\t    inner join vat_commissionerate AS VC\r\n        ON vd.comm_id = VC.comm_id\r\n\r\n        where vd.Is_deleted=false and vd.division_id='", intDivisionId, "'");
            return this.DBUtil.GetDataSet(str, "Division");
        }

        public DataTable getDivisionDataForGv()
        {
            return this.DBUtil.GetDataTable("select vd.*,VC.comm_name,su.upazila_name uName, suw.union_ward_name uwName from vat_division vd\r\n        left join set_upazila su on vd.upazila_id=su.upazila_id \r\n        left join set_union_ward suw on vd.union_ward_id=suw.union_ward_id\r\n        inner join vat_commissionerate AS VC\r\n        ON vd.comm_id = VC.comm_id\r\n        where vd.Is_deleted=false");
        }

        public bool InsertDivision(vatDivisiojnDAO objVatDivisionDAO)
        {
            object[] divisionName = new object[] { "INSERT INTO vat_division (division_name, division_code, comm_id, address, phone_no, upazila_id, union_ward_id) VALUES   ( '", objVatDivisionDAO.DivisionName, "','", objVatDivisionDAO.DivisionCode, "','", objVatDivisionDAO.ComId, "','", objVatDivisionDAO.Address, "', '", objVatDivisionDAO.PhoneNo, "','", objVatDivisionDAO.UpazillaId, "','", objVatDivisionDAO.UnionWardId, "')" };
            string str = string.Concat(divisionName);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateDivision(vatDivisiojnDAO objVatDivisionDAO, int division_id)
        {
            object[] divisionName = new object[] { "Update  vat_division SET division_name = '", objVatDivisionDAO.DivisionName, "', division_code = '", objVatDivisionDAO.DivisionCode, "', comm_id = '", objVatDivisionDAO.ComId, "', address = '", objVatDivisionDAO.Address, "', phone_no = '", objVatDivisionDAO.PhoneNo, "', upazila_id = '", objVatDivisionDAO.UpazillaId, "', union_ward_id = '", objVatDivisionDAO.UnionWardId, "' WHERE division_id = ", division_id };
            string str = string.Concat(divisionName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}
