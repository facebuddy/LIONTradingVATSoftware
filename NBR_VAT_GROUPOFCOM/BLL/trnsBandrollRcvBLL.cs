using System;
using System.Collections;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsBandrollRcvBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public trnsBandrollRcvBLL()
        {
        }

        public DataSet getBandrollDetailsDataByChallanId(short challanId)
        {
            string str = string.Concat("SELECT *, bandroll_item_description(bandroll_id) Description FROM trns_bandroll_rcv_d where Is_deleted=false and Challan_id=", challanId);
            return this.DBUtil.GetDataSet(str, "BandrollDetailsData");
        }

        public DataSet getBandrollMasterData()
        {
            return this.DBUtil.GetDataSet("SELECT tbrm.*, to_char(tbrm.date_receive, 'dd-Mon-yyyy') receiveDate, ori.organization_name OrgName1, ttc.challan_no tChNo FROM trns_bandroll_rcv_m tbrm\r\n        LEFT OUTER JOIN org_registration_info ori on ori.Organization_id=tbrm.Organization_id\r\n        LEFT OUTER JOIN trns_treasury_challan ttc on ttc.Challan_id=tbrm.treasury_challan_id\r\n        WHERE tbrm.Is_deleted=false ORDER BY tbrm.date_receive", "BandrollMasterData");
        }

        public bool InsertBandrollReceiveData(trnsBandrollRcvMaster objMDAO, ArrayList arrDetailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            objMDAO.ChallanId = Convert.ToInt16(this.DBUtil.GetSingleValue("SELECT  nextval('bandroll_rcv_challan_id_seq')"));
            string str = "";
            str = (objMDAO.TreasuryChallanId != 0 ? objMDAO.TreasuryChallanId.ToString() : "null");
            object[] challanId = new object[] { "INSERT INTO trns_bandroll_rcv_m(Challan_id, Organization_id, date_receive, receive_challan_no, treasury_challan_id, User_id_insert) \r\n        values(", objMDAO.ChallanId, ", ", objMDAO.OrganizationId, ", '", objMDAO.DateReceive, "', '", objMDAO.ReceiveChallanNo, "', ", str, ", ", objMDAO.UserIdInsert, " )" };
            arrayLists.Add(string.Concat(challanId));
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                trnsBandrollRcvDetails trnsBandrollRcvDetail = new trnsBandrollRcvDetails();
                trnsBandrollRcvDetail = (trnsBandrollRcvDetails)arrDetailDAO[i];
                object[] objArray = new object[] { "INSERT INTO trns_bandroll_rcv_d(Challan_id, row_no, bandroll_id, Quantity, total_price, unit_price, User_id_insert) \r\n        values(", objMDAO.ChallanId, ", ", trnsBandrollRcvDetail.RowNo, ", ", trnsBandrollRcvDetail.BandrollId, ", ", trnsBandrollRcvDetail.Quantity, ", ", trnsBandrollRcvDetail.TotalPrice, ", ", trnsBandrollRcvDetail.UnitPrice, ", ", trnsBandrollRcvDetail.UserIdInsert, ")" };
                arrayLists.Add(string.Concat(objArray));
            }
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }
    }
}