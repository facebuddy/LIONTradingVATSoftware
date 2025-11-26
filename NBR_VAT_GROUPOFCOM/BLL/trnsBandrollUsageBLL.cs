using System;
using System.Collections;
using System.Data;


namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsBandrollUsageBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public trnsBandrollUsageBLL()
        {
        }

        public DataSet getBandrollUsageDetailsByChallanId(short challanId)
        {
            string str = string.Concat("SELECT *, bandroll_item_description(bandroll_id) Description, i.item_name iName, tbrm.receive_challan_no rcvNo FROM trns_bandroll_uses_d tbud\r\n        left JOIN Item i on i.Item_id=tbud.Item_id\r\n        left JOIN trns_bandroll_rcv_m tbrm on tbrm.Challan_id=tbud.rcv_challan_id\r\n        where tbud.Is_deleted=false and tbud.Challan_id=", challanId);
            return this.DBUtil.GetDataSet(str, "BandrollUsageDetailsData");
        }

        public DataSet getBandrollUsageMasterData()
        {
            return this.DBUtil.GetDataSet("SELECT tbum.*, to_char(tbum.date_challan, 'dd-Mon-yyyy') ChallanDate, ori.organization_name OrgName1 FROM trns_bandroll_uses_m tbum\r\n        LEFT OUTER JOIN org_registration_info ori on ori.Organization_id=tbum.Organization_id\r\n        WHERE tbum.Is_deleted=false ORDER BY tbum.date_challan", "BandrollUsesMasterData");
        }

        public bool InsertBandrollUsageData(trnsBandrollUsageMasterDAO objMDAO, ArrayList arrDetailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            objMDAO.ChallanId = Convert.ToInt16(this.DBUtil.GetSingleValue("SELECT  nextval('bandroll_uses_challan_id_seq')"));
            string str = "null";
            if (objMDAO.Remarks != "")
            {
                str = string.Concat("'", objMDAO.Remarks, "'");
            }
            object[] challanId = new object[] { "INSERT INTO trns_bandroll_uses_m(Challan_id, Organization_id, challan_no, date_challan, User_id_insert, Remarks) \r\n        values(", objMDAO.ChallanId, ", ", objMDAO.OrganizationId, ", '", objMDAO.ChallanNo, "', '", objMDAO.DateChallan, "', ", objMDAO.UserIdInsert, ", ", str, " )" };
            arrayLists.Add(string.Concat(challanId));
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsBandrollUsageDetailsDAO _trnsBandrollUsageDetailsDAO = new trnsBandrollUsageDetailsDAO();
                _trnsBandrollUsageDetailsDAO = (trnsBandrollUsageDetailsDAO)arrDetailDAO[i];
                object[] objArray = new object[] { "INSERT INTO trns_bandroll_uses_d(Challan_id, row_no, rcv_challan_id, bandroll_id, Quantity, unit_price, Item_id, User_id_insert) \r\n        values(", objMDAO.ChallanId, ", ", _trnsBandrollUsageDetailsDAO.RowNo, ", ", _trnsBandrollUsageDetailsDAO.RcvChallanId, ", ", _trnsBandrollUsageDetailsDAO.BandrollId, ", ", _trnsBandrollUsageDetailsDAO.Quantity, ", ", _trnsBandrollUsageDetailsDAO.UnitPrice, ", ", _trnsBandrollUsageDetailsDAO.ItemId, ", ", _trnsBandrollUsageDetailsDAO.UserIdInsert, ")" };
                arrayLists.Add(string.Concat(objArray));
            }
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }
    }
}
