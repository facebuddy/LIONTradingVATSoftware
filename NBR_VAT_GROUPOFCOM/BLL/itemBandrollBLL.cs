using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class itemBandrollBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public itemBandrollBLL()
        {
        }

        public DataSet GetAllBandrollData()
        {
            return this.DBUtil.GetDataSet("select *, length||'; '||width||'; '||color_design bandrollId, case when bandroll_type='B' then 'Bandroll' else 'Stamp' end btype from item_bandroll", "AllBandrollData");
        }

        public DataSet GetBandrollByOrgWithStock(itemBandrollDAO objitemBandrollDAO)
        {
            object[] organizationId = new object[] { "select d.r_org,d.bid,ib.length||'-'||ib.width||'-'||ib.color_design bandrolls,sum(d.rqty)-sum(d.dqty) stock from\r\n        (select m.Organization_id r_org,d.bandroll_id bId,d.Quantity rqty,0 dqty\r\n        from trns_bandroll_rcv_d d inner join trns_bandroll_rcv_m m on m.Challan_id=d.Challan_id and m.Is_deleted=false\r\n        where m.Organization_id=", objitemBandrollDAO.OrganizationId, " \r\n        union all\r\n        select m.Organization_id r_org,d.bandroll_id bId,0 rqty,d.Quantity dqty\r\n        from trns_bandroll_uses_d d inner join trns_bandroll_uses_m m on m.Challan_id=d.Challan_id and m.Is_deleted=false\r\n        where m.Organization_id=", objitemBandrollDAO.OrganizationId, ") as d inner join item_bandroll ib on d.bid=ib.bandroll_id\r\n        group by d.r_org,d.bid,ib.length||'-'||ib.width||'-'||ib.color_design\r\n        having sum(d.rqty)-sum(d.dqty)>0" };
            string str = string.Concat(organizationId);
            return this.DBUtil.GetDataSet(str, "BandrollByOrgWithStock");
        }

        public DataSet getBandrollRcvDataByChallanIdandBandrollId(short ChallanId, short BandrollId)
        {
            object[] challanId = new object[] { "SELECT * from trns_bandroll_rcv_d where Is_deleted=false and Challan_id=", ChallanId, " and bandroll_id= ", BandrollId };
            string str = string.Concat(challanId);
            return this.DBUtil.GetDataSet(str, "BandrollRcvByChallanIdandBandrollId");
        }

        public DataSet GetBChallanIdByBandrollIdWithStock(itemBandrollDAO objitemBandrollDAO)
        {
            object[] organizationId = new object[] { "select m.Challan_id ChlnId, m.receive_challan_no ||' // '||m.date_receive ChlnNo,sum(d.qty) stock from\r\n        (select m.Organization_id r_org,d.bandroll_id bId,d.Quantity qty, m.Challan_id chlnId \r\n        from trns_bandroll_rcv_d d inner join trns_bandroll_rcv_m m on m.Challan_id=d.Challan_id and m.Is_deleted=false\r\n        where m.Organization_id=", objitemBandrollDAO.OrganizationId, "  and d.bandroll_id=", objitemBandrollDAO.BandrollId, "\r\n        union all\r\n        select m.Organization_id r_org,d.bandroll_id bId,-d.Quantity qty, d.rcv_challan_id chlnId\r\n        from trns_bandroll_uses_d d inner join trns_bandroll_uses_m m on m.Challan_id=d.Challan_id and m.Is_deleted=false\r\n        where m.Organization_id=", objitemBandrollDAO.OrganizationId, " and d.bandroll_id=", objitemBandrollDAO.BandrollId, ") as d inner join  trns_bandroll_rcv_m m on m.Challan_id=d.chlnId       \r\n        group by m.Challan_id, m.receive_challan_no ||' // '||m.date_receive\r\n        having sum(d.qty)>0" };
            string str = string.Concat(organizationId);
            return this.DBUtil.GetDataSet(str, "challanIdByBandrollId");
        }

        public DataSet GetStock(itemBandrollDAO objitemBandrollDAO)
        {
            object[] organizationId = new object[] { "select m.Challan_id, m.receive_challan_no,sum(d.qty) stock from\r\n        (select m.Organization_id r_org,d.bandroll_id bId,d.Quantity qty, m.Challan_id chlnId \r\n        from trns_bandroll_rcv_d d inner join trns_bandroll_rcv_m m on m.Challan_id=d.Challan_id and m.Is_deleted=false\r\n        where m.Organization_id=", objitemBandrollDAO.OrganizationId, "  and d.bandroll_id=", objitemBandrollDAO.BandrollId, " and m.Challan_id=", objitemBandrollDAO.ReceivechallanId, "\r\n        union all\r\n        select m.Organization_id r_org,d.bandroll_id bId,-d.Quantity qty, d.rcv_challan_id chlnId\r\n        from trns_bandroll_uses_d d inner join trns_bandroll_uses_m m on m.Challan_id=d.Challan_id and m.Is_deleted=false\r\n        where m.Organization_id=", objitemBandrollDAO.OrganizationId, " and d.bandroll_id=", objitemBandrollDAO.BandrollId, " and d.rcv_challan_id=", objitemBandrollDAO.ReceivechallanId, ") as d inner join  trns_bandroll_rcv_m m on m.Challan_id=d.chlnId       \r\n        group by m.Challan_id, m.receive_challan_no\r\n        having sum(d.qty)>0" };
            string str = string.Concat(organizationId);
            return this.DBUtil.GetDataSet(str, "challanIdByBandrollId");
        }

        public bool insertBandroll(itemBandrollDAO objItemBandroll)
        {
            object[] bandrollType = new object[] { "insert into item_bandroll(bandroll_type, length, width, color_design, User_id_insert) \r\nvalues('", objItemBandroll.BandrollType, "', '", objItemBandroll.Length, "', '", objItemBandroll.Width, "', '", objItemBandroll.ColorDesign, "', ", objItemBandroll.UserIdInsert, ")" };
            string str = string.Concat(bandrollType);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}