using System;
using System.Data;


namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class TransSaleMasterBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public TransSaleMasterBLL()
        {
        }

        public DataTable GetCgChallanNo(DateTime DisposeYear)
        {
            string str = string.Concat("Select coalesce(Max(cg_challan_no),0)+1 as cg_challan_no  from trns_sale_master where challan_year='", DisposeYear.Year, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public short getChallanId()
        {
            return Convert.ToInt16(this.DBUtil.GetSingleValue("select nextval('sale_challan_id_seq'::regclass)"));
        }

        public DataSet getDisposalReason()
        {
            return this.DBUtil.GetDataSet("select * from app_code_detail where Is_deleted=false and code_id_m=10", "DisposalReason");
        }

        public DataSet getItemsforRpt(short orgId, string startDate, string finishDate)
        {
            string str = "";
            if (!(startDate != "") || !(finishDate != ""))
            {
                str = "";
            }
            else
            {
                string[] strArrays = new string[] { "and date_challan>='", startDate, "' and date_challan<'", finishDate, "' " };
                str = string.Concat(strArrays);
            }
            object[] objArray = new object[] { "select tsm.Challan_id, tsd.Item_id ItemId, i.item_name iname from trns_sale_master tsm\r\ninner join trns_sale_detail tsd on tsm.Challan_id=tsd.Challan_id\r\ninner join Item i on i.Item_id=tsd.Item_id\r\nwhere tsm.Is_deleted=false and tsm.challan_type='D' and tsm.Organization_id='", orgId, "' ", str, " order by date_challan" };
            string str1 = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str1, "ReportItems");
        }

        public DataSet getItemStock(short purchaseChallanId, short detailId)
        {
            object[] objArray = new object[] { "select sum(Quantity) saleQty from trns_sale_detail where detail_id=", detailId, " and purchase_challan_id=", purchaseChallanId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "itemStock");
        }

        public DataTable rptChallanForm11(trnsSaleMasterDAO objtrnsSaleMasterDAO)
        {
            string str = "";
            if (objtrnsSaleMasterDAO.PartyId != 0)
            {
                str = string.Concat(str, " and tp.Party_id = ", objtrnsSaleMasterDAO.PartyId);
            }
            if (objtrnsSaleMasterDAO.ChallanNo.Trim() != "")
            {
                str = string.Concat(str, " and tsm.challan_id='", objtrnsSaleMasterDAO.ChallanNo, "'");
            }
            string str1 = objtrnsSaleMasterDAO.StartDate.ToString("dd/MM/yyyy");
            string str2 = objtrnsSaleMasterDAO.FinishDate.ToString("dd/MM/yyyy");
            string[] orgName = new string[] { "SELECT '", objtrnsSaleMasterDAO.OrgName, "' OrgName1, '", objtrnsSaleMasterDAO.OrgAddress, "' OrgAddress, '", objtrnsSaleMasterDAO.OrgBIN, "' OrgTin, tp.party_name Customer_name, tp.party_address Customer_Address, tp.party_tin Customer_TIN, tsm.ultimate_destination Goods_Services_Shipping_Address, acd.code_name Vehicle_Type, tsm.challan_no Challan_No, to_char(tsm.date_challan,'dd/mm/yyyy') Challan_Date, to_char(tsm.date_challan::Time, 'HH24:MI') Challan_Time, \r\n        tsm.date_goods_delivery Goods_Unload_Date_Time, tsm.vehicle_no Vehicle_No, row_number() over (order by i.item_name nulls last) as Sl_No,\r\n        i.item_name Goods_Services_Name, tsd.Quantity Quantity, tsd.actual_price SD_Applicable_Price, tsd.Sd SD_Amount, tsd.Vat VAT_Amount,\r\n        to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),1,2)))||' '||substr(to_char(date_challan, 'dd/yyyy/MONTH'),9)||' '||to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),7,4))) TextDate,\r\n        to_text(int2(substr(to_char(date_challan, 'HH24:mi'),1,2)))||' HOUR '||to_text(int2(substr(to_char(date_challan, 'hh:mi'),4,2)))||' MINUTE' TextTime, (acd.code_name||'  '||tsm.vehicle_no) Vehicle \r\n        FROM trns_sale_master tsm \r\n        LEFT OUTER JOIN trns_party tp ON tsm.Party_id=tp.Party_id\r\n        LEFT OUTER JOIN app_code_detail acd ON tsm.vehicle_type_m=acd.code_id_m AND tsm.vehicle_type_d=acd.code_id_d\r\n        LEFT OUTER JOIN trns_sale_detail tsd ON tsm.Challan_id=tsd.Challan_id\r\n        LEFT OUTER JOIN Item i ON tsd.Item_id=i.Item_id\r\n        WHERE tsm.challan_type='S' and tsm.Is_deleted=false and tsm.date_challan>= to_date('", str1, "' ,'dd/MM/yyyy')and tsm.date_challan<=to_date('", str2, "','dd/MM/yyyy') ", str, "  order by tsm.date_challan " };
            string str3 = string.Concat(orgName);
            return this.DBUtil.GetDataTable(str3);
        }

        public DataSet rptDispose()
        {
            return this.DBUtil.GetDataSet("", "");
        }
    }
}

