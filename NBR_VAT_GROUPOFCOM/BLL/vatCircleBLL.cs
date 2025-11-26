using System;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class vatCircleBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public vatCircleBLL()
        {
        }

        public bool deleteCircle(int intCircleId)
        {
            string str = string.Concat("UPDATE vat_circle SET Is_deleted=true WHERE circle_id = '", intCircleId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getCircle(int intCircleId)
        {
            string str = string.Concat("select vc.*, su.upazila_name uName, suw.union_ward_name uwName from vat_circle vc\r\n        left join set_upazila su on vc.upazila_id=su.upazila_id \r\n        left join set_union_ward suw on vc.union_ward_id=suw.union_ward_id\r\n        where vc.Is_deleted=false and vc.circle_id='", intCircleId, "'");
            return this.DBUtil.GetDataSet(str, "Circle");
        }

        public DataTable getCircleDataForGv()
        {
            return this.DBUtil.GetDataTable("select vc.*,vd.division_name,VCM.comm_name, su.upazila_name uName, suw.union_ward_name uwName from vat_circle vc\r\n        left join set_upazila su on vc.upazila_id=su.upazila_id \r\n        left join set_union_ward suw on vc.union_ward_id=suw.union_ward_id\r\n        inner join vat_division vd on vc.division_id=vd.division_id\r\n        inner join vat_commissionerate AS VCM\r\n        ON vc.comm_id = VCM.comm_id\r\n        where vc.Is_deleted=false");
        }

        public bool InsertDivision(vatCircleDAO objVatCircleDAO)
        {
            object[] commId = new object[] { "INSERT INTO vat_circle (comm_id,circle_name, circle_code, division_id, address, phone_no, upazila_id, union_ward_id,jurisdiction) VALUES   ('", objVatCircleDAO.Comm_id, "','", objVatCircleDAO.CircleName, "','", objVatCircleDAO.CircleCode, "','", objVatCircleDAO.DivisionId, "','", objVatCircleDAO.Address, "', '", objVatCircleDAO.PhoneNo, "','", objVatCircleDAO.UpazillaId, "','", objVatCircleDAO.UnionWardId, "','", objVatCircleDAO.Jurisdiction, "')" };
            string str = string.Concat(commId);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool UpdateDivision(vatCircleDAO objVatCircleDAO, int circle_id)
        {
            object[] commId = new object[] { "Update vat_circle SET comm_id = '", objVatCircleDAO.Comm_id, "',circle_name = '", objVatCircleDAO.CircleName, "', circle_code = '", objVatCircleDAO.CircleCode, "', division_id = '", objVatCircleDAO.DivisionId, "', address = '", objVatCircleDAO.Address, "', phone_no = '", objVatCircleDAO.PhoneNo, "', upazila_id = '", objVatCircleDAO.UpazillaId, "', union_ward_id = '", objVatCircleDAO.UnionWardId, "',jurisdiction = '", objVatCircleDAO.Jurisdiction, "' WHERE circle_id = ", circle_id };
            string str = string.Concat(commId);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}
