using System;
using System.Collections;
using System.Data;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsPurchaseDetailBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private PurchaseDetailDAO PurchaseDetailDAO = new PurchaseDetailDAO();

        public trnsPurchaseDetailBLL()
        {
        }

        public DataSet getChallanNobyPurchaseType(string PurchaseType)
        {
            string str = string.Concat("select Challan_id, challan_no from trns_purchase_master where purchase_type='", PurchaseType, "'");
            return this.DBUtil.GetDataSet(str, "ChallanNoByChalllanType");
        }

        public DataTable getExportItemInfoByItemId(short itemId)
        {
            string str = string.Concat("select sale_detl.challan_id, salemast.challan_no challan_no,salemast.date_challan,(sale_detl.quantity*sale_detl.actual_price) total_price,sale_detl.quantity,uni.unit_code,itm.item_name,\r\n                                itm.hs_code,0 vat,0 cd,0 tti,sale_detl.actual_price,0 rd,0 ait,0 atv\r\n                                from trns_sale_detail sale_detl\r\n                                inner join item itm on sale_detl.item_id = itm.item_id\r\n                                inner join trns_sale_master salemast on sale_detl.challan_id = salemast.challan_id\r\n                                inner join item_unit uni on sale_detl.unit_id = uni.unit_id where sale_detl.Is_deleted=false and itm.item_id='", itemId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getItemInfoByChallanId(short ChallanId)
        {
            string str = string.Concat("select tpd.Challan_id, tpd.Item_id ItemId, i.item_name ItemName from trns_purchase_detail tpd\r\n        LEFT OUTER JOIN Item i on tpd.Item_id=i.Item_id where tpd.Challan_id=", ChallanId);
            return this.DBUtil.GetDataSet(str, "ItemsByChallanId");
        }

        public DataTable getItemInfoBydetailId(short detailId)
        {
            string str = string.Concat("select * from trns_purchase_detail where Is_deleted=false and detail_id='", detailId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getItemInfoByItemId(short itemId)
        {
            string str = string.Concat("select purchmast.challan_no challan_no,purchmast.date_challan,purchs.total_price,purchs.quantity,uni.unit_code,itm.item_name,\r\n                                itm.hs_code,purchs.purchase_vat as vat,purchs.purchase_sd as sd,purchs.cd,purchs.tti,purchs.purchase_unit_price,purchs.rd,purchs.ait,purchs.atv\r\n                                from trns_purchase_detail purchs\r\n                                inner join item itm on purchs.item_id = itm.item_id\r\n                                inner join trns_purchase_master purchmast on purchs.challan_id = purchmast.challan_id\r\n                                inner join item_unit uni on purchs.unit_id = uni.unit_id where purchs.Is_deleted=false and itm.item_id='", itemId, "' and purchs.purchase_sd!=0");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getLatestUnitPriceByItemId(short itemId)
        {
            object[] objArray = new object[] { "select tpd.actual_price actual_price, iu.unit_code UnitName from trns_purchase_detail tpd \r\n        left join item_unit iu on iu.unit_id=tpd.unit_id\r\n        where tpd.Is_deleted=false and tpd.Item_id=", itemId, " and tpd.Date_insert=(select max(Date_insert)from trns_purchase_detail where Item_id=", itemId, ")" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getusedQuantityperUnit(short itemId)
        {
            string str = string.Concat("select quantity_total from price_raw_item pri\r\n                                inner join item itm on pri.item_id = itm.item_id\r\n                                where itm.item_id='", itemId, "' ");
            return this.DBUtil.GetDataTable(str);
        }

        public bool UpdateItemDataForDADO(ArrayList arrDetailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                purchaseDetailDAO = (PurchaseDetailDAO)arrDetailDAO[i];
                object[] userIdUpdate = new object[] { "UPDATE trns_purchase_detail SET is_dado=true, User_id_update=", purchaseDetailDAO.UserIdUpdate, ", Date_update='", purchaseDetailDAO.DateUpdte, "' WHERE detail_id=", purchaseDetailDAO.DetailID };
                arrayLists.Add(string.Concat(userIdUpdate));
            }
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }
    }
}
