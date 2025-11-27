using System;
using System.Collections;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class DisposalBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public DisposalBLL()
        {
        }

        private ArrayList AddDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                TransSaleDetailDAO transSaleDetailDAO = new TransSaleDetailDAO();
                transSaleDetailDAO = (TransSaleDetailDAO)arrDeailDAO[i];
                object[] challanID = new object[] { "INSERT INTO trns_sale_detail(\r\n            Challan_id, row_no, lot_no,detail_id,Item_id,unit_id, Quantity, actual_price, Vat,disposal_reason_m,disposal_reason_d,User_id_insert,current_price)\r\n    VALUES (", ChallanID, ", ", transSaleDetailDAO.RowNo, ", ", transSaleDetailDAO.LotNo, ",  ", transSaleDetailDAO.DetailId, ", ", transSaleDetailDAO.ItemID, ", ", transSaleDetailDAO.UnitID, ", ", transSaleDetailDAO.DisposeQty, ", ", transSaleDetailDAO.ActualPrice, ",\r\n              ", transSaleDetailDAO.VAT, ", ", transSaleDetailDAO.DisposalReasonM, ", ", transSaleDetailDAO.DisposalReasonD, ", ", transSaleDetailDAO.UserIdInsert, ", ", transSaleDetailDAO.CurrenttPrice, ")" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        public string CircleCode(int CircleID)
        {
            string str = "NA";
            try
            {
                string str1 = string.Concat("select circle_code from vat_circle where is_deleted = false and circle_id = ", CircleID);
                object singleValue = this.DBUtil.GetSingleValue(str1);
                if (singleValue != null)
                {
                    str = Convert.ToString(singleValue);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return str;
        }

        public DataTable GetAllReason()
        {
            return this.DBUtil.GetDataTable("select * from app_code_detail where  Is_deleted=false");
        }

        public DataTable getChallanNoByItemIdAndOrganizationId(long intItemId, int intOrgId)
        {
            string str = string.Concat("select Distinct pm.Challan_id, pm.challan_no AS Challan_No from trns_purchase_master pm,trns_purchase_detail pd where pm.Challan_id=pd.Challan_id and Item_id='", intItemId, "' order by  pm.challan_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetDamagedDataForReport(DateTime fDate, DateTime tDate, long itemId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                if (itemId != (long)-99)
                {
                    str = string.Concat(str, "and i.item_id=", itemId);
                }
                string[] strArrays = new string[] { "select i.item_id,i.hs_code, i.item_name,m.challan_id, m.challan_no,m.date_challan,d.quantity,\r\n                            d.quantity*d.actual_price prev_amount,d.vat,d.Remarks,d.quantity*d.current_price pre_amount,iu.unit_code \r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            inner join item i on d.item_id = i.item_id\r\n                            inner join item_unit iu on iu.unit_id=d.unit_id\r\n                            where m.challan_type = 'D'\r\n                            and m.m_no = 27 and\r\n                            to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                            and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')  \r\n                            and m.is_deleted = false ", str, " " };
                string str1 = string.Concat(strArrays);
                dataTable = this.DBUtil.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetDisposalDataForReport(DateTime fDate, DateTime tDate, long itemId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                if (itemId != (long)-99)
                {
                    str = string.Concat(str, "and i.item_id=", itemId);
                }
                string[] strArrays = new string[] { "select i.item_id,i.hs_code, i.item_name,m.challan_id, m.challan_no,m.date_challan,d.quantity,\r\n                            d.quantity*d.actual_price prev_amount,d.vat,d.Remarks,d.quantity*d.current_price pre_amount,iu.unit_code,\r\n                            (select td.row_no from trns_purchase_master tm inner join trns_purchase_detail td on td.challan_id=tm.challan_id where tm.challan_no=m.challan_no limit 1) purchaseSl\r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            inner join item i on d.item_id = i.item_id\r\n                            inner join item_unit iu on iu.unit_id=d.unit_id\r\n                            where m.challan_type = 'D'\r\n                            and m.m_no = 26 and\r\n                            to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') >= to_date('", fDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') \r\n                            and to_date(to_char(m.date_challan,'MM/dd/yyyy'),'MM/dd/yyyy') <= to_date('", tDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy')                           \r\n                            and m.is_deleted = false ", str };
                string str1 = string.Concat(strArrays);
                dataTable = this.DBUtil.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetDisposalDataForReportByChallanNo(string challanNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select i.item_id,i.hs_code, i.item_name,m.challan_id, m.challan_no,m.date_challan,d.quantity,\r\n                            d.quantity*d.actual_price prev_amount,d.vat,d.Remarks,d.quantity*d.current_price pre_amount,iu.unit_code,\r\n                            (select td.row_no from trns_purchase_master tm inner join trns_purchase_detail td on td.challan_id=tm.challan_id where tm.challan_no=m.challan_no limit 1) purchaseSl\r\n                            from trns_sale_master m\r\n                            inner join trns_sale_detail d on m.challan_id = d.challan_id\r\n                            inner join item i on d.item_id = i.item_id\r\n                            inner join item_unit iu on iu.unit_id=d.unit_id\r\n                            where m.challan_type = 'D' and\r\n                            m.challan_no='", challanNo, "'                          \r\n                            and m.is_deleted = false ", "");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetOrganizationInfo(int OrgId)
        {
            string str = string.Concat("select * from org_registration_info where Organization_id='", OrgId, "' AND Is_deleted=false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetStockByChallanAndItem(long intItemId, int challanId, DateTime stockDate)
        {
            object[] str = new object[] { "SELECT RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,\r\n                        RD.actual_price UNIT_PRICE, RD.QUANTITY, RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate,Rd.Sd, Rd.Vat,\r\n                        (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\t            TRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L')\r\n                                    AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> 0\r\n                    AND IM.IS_DELETED = FALSE \r\n                                    ),0.00) + \r\n\t            coalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\t            TRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C')\r\n                                    AND ND.ITEM_ID = RD.ITEM_ID and ND.DETAIL_ID = RD.DETAIL_ID AND NM.IS_DELETED = FALSE \r\n                AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", stockDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')  \r\n                                    ),0.00) )\r\n                                    AVAIL_QTY\r\n                                    FROM TRNS_PURCHASE_MASTER RM, TRNS_PURCHASE_DETAIL RD left outer join price_item pr on pr.price_id = Rd.price_id\r\n\t\t\t            WHERE RM.IS_DELETED = FALSE AND RM.Challan_id =RD.Challan_id AND RM.CHALLAN_TYPE in ('P', 'F', 'R')\r\n                    AND TO_DATE(TO_CHAR(RM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", stockDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n                    and RD.ITEM_ID = ", intItemId, " and rm.Challan_id =", challanId, "\r\n                    GROUP BY RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,RD.ITEM_ID,\r\n                                RD.actual_price, RD.QUANTITY ,RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate, Rd.Sd, Rd.Vat\r\n                               HAVING  (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\t            TRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L')\r\n                                    AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> 0\r\n                    AND IM.IS_DELETED = FALSE \r\n                                    ),0.00) + \r\n\t            coalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\t            TRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C')\r\n                                    AND ND.ITEM_ID = RD.ITEM_ID and ND.Challan_id = RD.CHALLAN_ID AND NM.IS_DELETED = FALSE \r\n                AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", stockDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')  \r\n                                    ),0.00) ) > 0 \r\n                         ORDER BY RD.DETAIL_ID" };
            string str1 = string.Concat(str);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable getUnusedProductByItemIdANDChallanNo(int intItemId, int challanID)
        {
            object[] objArray = new object[] { "select pd.unit_id,pd.Quantity,pd.actual_price,pd.Vat, pd.lot_no,pd.detail_id from trns_purchase_master pm,trns_purchase_detail pd where pm.Challan_id=pd.Challan_id and Item_id='", intItemId, "'  and pm.Challan_id='", challanID, "' order by  challan_no" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public bool InsertDisposeData(TransSaleMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            object[] challanID = new object[] { "INSERT INTO trns_sale_master(Challan_id,\r\n                  Organization_id, challan_no, cg_challan_no, challan_year, \r\n                  challan_type, date_challan,  User_id_insert)\r\n    VALUES (", objMDAO.ChallanID, ", ", objMDAO.OrganizationId, ", '", objMDAO.ChallanNo, "',", objMDAO.CgChallanNo, ",'", null, null, null, null, null, null, null, null };
            challanID[9] = objMDAO.ChallanYear.Year;
            challanID[10] = "','";
            challanID[11] = objMDAO.ChallanType;
            challanID[12] = "',TO_DATE('";
            challanID[13] = objMDAO.ChallanDate.ToString("MM/dd/yyyy");
            challanID[14] = "','MM/dd/yyyy'),";
            challanID[15] = objMDAO.UserIdInsert;
            challanID[16] = ")";
            arrayLists.Add(string.Concat(challanID));
            arrayLists = this.AddDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }
    }
}
