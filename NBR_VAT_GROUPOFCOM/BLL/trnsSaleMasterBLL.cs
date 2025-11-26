using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsSaleMasterBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public trnsSaleMasterBLL()
        {
        }

        public DataTable GetAllChalanByDate(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string[] str = new string[] { "select distinct tsm.challan_id,tsm.challan_no,tp.party_name,tp.party_id\r\n                        from trns_sale_master tsm \r\n                        inner join trns_party tp on tsm.party_id = tp.party_id\r\n                        where cast(tsm.date_challan as Date)>=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND cast(tsm.date_challan as Date) <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')" };
                string str1 = string.Concat(str);
                dataTable = this.DBUtil.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetChallanByChallanId(int challanid)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select distinct tsm.challan_id,tsm.challan_no,tp.party_name,tp.party_id\r\n                        from trns_sale_master tsm \r\n                        inner join trns_party tp on tsm.party_id = tp.party_id\r\n                        where challan_id=", challanid);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public short getChallanId()
        {
            return Convert.ToInt16(this.DBUtil.GetSingleValue("select nextval('sale_challan_id_seq'::regclass)"));
        }

        public DataTable GetCustomer()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select distinct tp.party_id, tp.party_name\r\n                        from trns_sale_master tsm\r\n                        inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                        inner join trns_party tp on tsm.party_id = tp.party_id where tp.organization_id = ", num);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet getDisposalReason()
        {
            return this.DBUtil.GetDataSet("select * from app_code_detail where Is_deleted=false and code_id_m=10", "DisposalReason");
        }

        public DataTable GetinvoicebyChallanId(int challanid)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct tsm.invoice_no\r\n                        from trns_sale_master tsm \r\n                        where tsm.challan_id=", challanid, " ");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataSet getItemsforRpt(short orgId, DateTime startDate, DateTime finishDate)
        {
            string str = "";
            string str1 = "";
            if (!(startDate.ToShortDateString() != "1/1/1900") || !(finishDate.ToShortDateString() != "1/1/1900"))
            {
                str = "";
            }
            else
            {
                object[] objArray = new object[] { " and date_challan>='", startDate, "' and date_challan<'", finishDate, "' " };
                str = string.Concat(objArray);
            }
            str1 = (orgId == 0 ? "" : string.Concat("and tsm.Organization_id=", orgId));
            string[] strArrays = new string[] { "select distinct tsd.Item_id ItemId, i.item_name iname from trns_sale_master tsm\r\n        inner join trns_sale_detail tsd on tsm.Challan_id=tsd.Challan_id\r\n        inner join Item i on i.Item_id=tsd.Item_id\r\n        where tsm.Is_deleted=false and tsm.challan_type='D' ", str1, " ", str, " order by i.item_name" };
            string str2 = string.Concat(strArrays);
            return this.DBUtil.GetDataSet(str2, "ReportItems");
        }

        public DataSet getItemStock(short purchaseChallanId, short detailId)
        {
            object[] objArray = new object[] { "select sum(Quantity) saleQty from trns_sale_detail where detail_id=", detailId, " and purchase_challan_id=", purchaseChallanId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "itemStock");
        }

        public DataSet getPartyByDate(DateTime startDate, DateTime finishDate)
        {
            string str = "";
            if (!(startDate.ToShortDateString() != "1/1/1900") || !(finishDate.ToShortDateString() != "1/1/1900"))
            {
                str = "";
            }
            else
            {
                object[] objArray = new object[] { " and tsm.date_challan>='", startDate, "' and tsm.date_challan<'", finishDate, "' " };
                str = string.Concat(objArray);
            }
            string str1 = string.Concat("select distinct tsm.Party_id, tp.party_name from trns_sale_master tsm inner join trns_party tp on tp.Party_id=tsm.Party_id \r\n        where tsm.Is_deleted=false ", str);
            return this.DBUtil.GetDataSet(str1, "PartyByDate");
        }

        public DataTable GetSaleChallan()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select distinct tsm.challan_id,tsm.challan_no\r\n                        from trns_sale_master tsm where tsm.organization_id=", num);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSaleChallanbyCustomebyDater(int customerid, DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select distinct tsm.challan_id,tsm.challan_no\r\n                        from trns_sale_master tsm \r\n                        inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                        inner join trns_party tp on tsm.party_id = tp.party_id where tsm.party_id=", customerid, " and cast(tsm.date_challan as Date) >=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND cast(tsm.date_challan as Date) <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSaleChallanbyCustomer(int customerid)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct tsm.challan_id,tsm.challan_no\r\n                        from trns_sale_master tsm \r\n                        inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                        inner join trns_party tp on tsm.party_id = tp.party_id where tsm.party_id=", customerid, " ");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSaleChallanbyDate(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select distinct tsm.challan_id,tsm.challan_no\r\n                        from trns_sale_master tsm where tsm.organization_id=", num, " and tsm.date_challan >=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND tsm.date_challan <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')" };
                string str1 = string.Concat(str);
                dataTable = this.DBUtil.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getSaleChallanNumber()
        {
            return this.DBUtil.GetDataTable("select challan_no from trns_sale_master where trans_type='E' and Is_deleted=FALSE");
        }

        public DataTable GetSales_unitId(DateTime fromDate, DateTime toDate, int itemID, int branchID)
        {
            string str = "";
            string str1 = "";
            if (itemID > 0)
            {
                str = string.Concat(" AND d.item_id = '", itemID, "'");
            }
            string[] strArrays = new string[] { "select d.unit_id,ui.unit_code,d.quantity,d.lot_no from trns_sale_detail d \r\n                          inner join trns_sale_master m on d.Challan_id = m.Challan_id                         \r\n                          inner join Item i on i.item_id = d.item_id\r\n                          inner join  item_unit ui on ui.unit_id=d.unit_id              \r\n                          where m.date_challan >=TO_DATE('", fromDate.ToString("MM/dd/yyy"), "','MM/dd/yyyy') AND m.date_challan <=TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') ", str, "   AND d.Is_deleted = false  order by lot_no" };
            str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetSkuNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select distinct i.item_id, i.item_name, i.item_sku\r\n                        from trns_sale_master tsm\r\n                        inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                        inner join item i on tsd.item_id = i.item_id where tsm.organization_id = ", num);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public bool InsertDisposeData(trnsSaleMasterDAO objMDAO, ArrayList arrDetailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            objMDAO.ChallanId = Convert.ToInt16(this.DBUtil.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            object[] challanId = new object[] { "insert into trns_sale_master(Challan_id, Organization_id, challan_no, cg_challan_no, challan_year, challan_type, date_challan, User_id_insert, Remarks,challan_page_discard_reason_m,challan_page_discard_reason_d,m_no) values('", objMDAO.ChallanId, "', '", objMDAO.OrganizationId, "', '", objMDAO.ChallanNo, "', (select coalesce (max (cg_challan_no),0)+1 from trns_sale_master where challan_type='D' and challan_year='", objMDAO.ChallanYear, "'),", objMDAO.ChallanYear, ", '", objMDAO.ChallanType, "', to_timestamp('", objMDAO.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),", objMDAO.UserIdInsert, ", '", objMDAO.Remarks, "',", objMDAO.DisposeIDM, ",", objMDAO.DisposeIDD, ",", objMDAO.MNo, ")" };
            arrayLists.Add(string.Concat(challanId));
            for (int i = 0; i < arrDetailDAO.Count; i++)
            {
                DisposeDAO disposeDAO = new DisposeDAO();
                disposeDAO = (DisposeDAO)arrDetailDAO[i];
                object[] objArray = new object[] { "insert into trns_sale_detail(Challan_id, row_no, lot_no, detail_id, Item_id, unit_id, Quantity, actual_price, Vat, disposal_reason_m, disposal_reason_d, User_id_insert, sale_row_no, purchase_challan_id, current_price,remarks) values('", objMDAO.ChallanId, "', '", disposeDAO.RowNo, "', '", disposeDAO.LotNo, "', ", disposeDAO.DetailId, ", ", disposeDAO.ItemId, ", ", disposeDAO.UnitId, ", ", disposeDAO.DisposeQuantity, ", ", disposeDAO.ActualPrice, ", ", disposeDAO.Vat2, ", ", disposeDAO.DisposeReasonM, ", ", disposeDAO.DisposeReasonD, ", ", disposeDAO.UserIdInsert, ", ", disposeDAO.RowNo, ", ", disposeDAO.PurchaseChallanId, ", '", disposeDAO.PresentUnitPrice, "','", disposeDAO.Remarks, "')" };
                arrayLists.Add(string.Concat(objArray));
            }
            object[] challanBookID = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
            arrayLists.Add(string.Concat(challanBookID));
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public DataSet rptCashmemo(trnsSaleMasterDAO objtrnsSaleMasterDAO)
        {
            string str = "";
            string str1 = "";
            if (objtrnsSaleMasterDAO.PartyId != 0)
            {
                str = string.Concat(" AND tsm.Party_id=", objtrnsSaleMasterDAO.PartyId);
            }
            if (objtrnsSaleMasterDAO.ChallanNo != "")
            {
                str1 = string.Concat(" AND tsm.challan_no='", objtrnsSaleMasterDAO.ChallanNo, "'");
            }
            object[] orgName = new object[] { "SELECT '", objtrnsSaleMasterDAO.OrgName, "' OrgName1, '", objtrnsSaleMasterDAO.OrgAddress, "' OrgAddress, '", objtrnsSaleMasterDAO.OrgBIN, "' OrgBIN, tp.party_name PartyName, tp.party_address PartyAddress, tsm.challan_no ChallanNo, i.item_name||'//'||i.hs_code ItemDetails, \r\n        tsd.Quantity Quantity,(tsd.actual_price*tsd.Quantity) +tsd.Sd+tsd.Vat TotalPrice from trns_sale_master tsm INNER JOIN\r\n        trns_party tp ON tp.Party_id=tsm.Party_id INNER JOIN\r\n        trns_sale_detail tsd ON tsd.Challan_id=tsm.Challan_id INNER JOIN\r\n        Item i ON i.Item_id=tsd.Item_id\r\n        WHERE tsm.Is_deleted=false AND tsm.challan_type='S' AND date_challan>='", objtrnsSaleMasterDAO.StartDate, "' AND date_challan<'", objtrnsSaleMasterDAO.FinishDate, "' ", str, " ", str1 };
            string str2 = string.Concat(orgName);
            return this.DBUtil.GetDataSet(str2, "SaleCashMemo");
        }
        public DataTable rptChallanForm112(trnsSaleMasterDAO objtrnsSaleMasterDAO)
        {
            string str = "";
            int num = 0;
            num = Convert.ToInt32(objtrnsSaleMasterDAO.ChallanNo);
            if (objtrnsSaleMasterDAO.PartyId != 0)
            {
                str = string.Concat(str, " and tp.Party_id = ", objtrnsSaleMasterDAO.PartyId);
            }
            if (objtrnsSaleMasterDAO.ChallanNo.Trim() != "")
            {
                str = string.Concat(str, " and tsm.challan_id='", objtrnsSaleMasterDAO.ChallanNo, "'");
            }
            string str1 = "01/01/2023";
            string str2 = "01/01/2050";
            object[] orgName = new object[] { "SELECT i.item_id,'", objtrnsSaleMasterDAO.OrgName, "' OrgName1, '", objtrnsSaleMasterDAO.OrgAddress, "' OrgAddress, '", objtrnsSaleMasterDAO.OrgBIN, "' OrgTin, tp.party_name Customer_name,\r\n        tp.party_address Customer_Address, tp.party_tin Customer_TIN, tp.party_bin, tp.national_id_no nid, tsm.ultimate_destination Goods_Services_Shipping_Address, acd.code_name Vehicle_Type, tsm.challan_no Challan_No, to_char(tsm.date_challan,'dd-MON-yyyy') Challan_Date, to_char(tsm.date_challan::Time, 'HH24:MI') Challan_Time, \r\n        tsm.date_goods_delivery Goods_Unload_Date_Time, tsm.vehicle_no Vehicle_No, row_number() over (order by i.item_name nulls last) as Sl_No,acd.code_name\r\n        --,i.item_name Goods_Services_Name\r\n\r\n            ,(i.item_name \r\n            || ' ' || (CASE WHEN tsd.property_id1 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id1=c.property_id \r\n\t\t\twhere a.property_id1=tsd.property_id1 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id2 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id2=c.property_id \r\n\t\t\twhere a.property_id2=tsd.property_id2 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id3 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id3=c.property_id \r\n\t\t\twhere a.property_id3=tsd.property_id3 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id4 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id4=c.property_id \r\n\t\t\twhere a.property_id4=tsd.property_id4 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id5 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id5=c.property_id \r\n\t\t\twhere a.property_id5=tsd.property_id5 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t) AS Goods_Services_Name\r\n        ,(case when tsd.item_serials<>'' THEN CONCAT('(',tsd.item_serials,')') ELSE '' END) AS itemserials      --added this portion to add item serials with each item name by sabbir\r\n       ,tsd.is_fixed_vat,i.item_specification,tsd.Quantity Quantity,tsd.sale_quantity, ui.unit_code UNIT, tsd.actual_price SD_Applicable_Price, tsd.Sd SD_Amount, tsd.Vat VAT_Amount,\r\n        to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),1,2)))||' '||substr(to_char(date_challan, 'dd/yyyy/MONTH'),9)||' '||to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),7,4))) TextDate,\r\n        to_text(int2(substr(to_char(date_challan, 'HH24:mi'),1,2)))||' HOUR '||to_text(int2(substr(to_char(date_challan, 'hh:mi'),4,2)))||' MINUTE' TextTime, (acd.code_name||'  '||tsm.vehicle_no) Vehicle \r\n        ,tsd.vat_rate,tsd.sd_rate sd_rate,property_quantity,tsd.discount_amt,tsd.additional_property\r\n        FROM trns_sale_master tsm \r\n        LEFT OUTER JOIN trns_party tp ON tsm.Party_id=tp.Party_id\r\n        LEFT OUTER JOIN app_code_detail acd ON tsm.vehicle_type_m=acd.code_id_m AND tsm.vehicle_type_d=acd.code_id_d\r\n        LEFT OUTER JOIN trns_sale_detail tsd ON tsm.Challan_id=tsd.Challan_id\r\n        LEFT OUTER JOIN Item i ON tsd.Item_id=i.Item_id\r\n       -- inner join item_unit ui on ui.unit_id=i.unit_id\r\n        inner join item_unit ui on ui.unit_id=tsd.sale_unit\r\n        WHERE tsm.challan_type='S' and tsm.Is_deleted=false and tsm.date_challan>= to_date('", str1, "','dd/MM/yyyy') and tsm.date_challan<=to_date('", str2, "','dd/MM/yyyy') ", str, "  order by tsm.date_challan " };
            string str3 = string.Concat(orgName);
            return this.DBUtil.GetDataTable(str3);
        }
        public DataTable rptChallanForm11(trnsSaleMasterDAO objtrnsSaleMasterDAO)
        {
            string str = "";
            int num = 0;
            num = Convert.ToInt32(objtrnsSaleMasterDAO.ChallanNo);
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
            object[] orgName = new object[] { "SELECT i.item_id,'", objtrnsSaleMasterDAO.OrgName, "' OrgName1, '", objtrnsSaleMasterDAO.OrgAddress, "' OrgAddress, '", objtrnsSaleMasterDAO.OrgBIN, "' OrgTin, tp.party_name Customer_name,\r\n        tp.party_address Customer_Address, tp.party_tin Customer_TIN, tp.party_bin, tp.national_id_no nid, tsm.ultimate_destination Goods_Services_Shipping_Address, acd.code_name Vehicle_Type, tsm.challan_no Challan_No, to_char(tsm.date_challan,'dd-MON-yyyy') Challan_Date, to_char(tsm.date_challan::Time, 'HH24:MI') Challan_Time, \r\n        tsm.date_goods_delivery Goods_Unload_Date_Time, tsm.vehicle_no Vehicle_No, row_number() over (order by i.item_name nulls last) as Sl_No,acd.code_name\r\n        --,i.item_name Goods_Services_Name\r\n\r\n            ,(i.item_name \r\n            || ' ' || (CASE WHEN tsd.property_id1 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id1=c.property_id \r\n\t\t\twhere a.property_id1=tsd.property_id1 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id2 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id2=c.property_id \r\n\t\t\twhere a.property_id2=tsd.property_id2 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id3 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id3=c.property_id \r\n\t\t\twhere a.property_id3=tsd.property_id3 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id4 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id4=c.property_id \r\n\t\t\twhere a.property_id4=tsd.property_id4 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN tsd.property_id5 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\tinner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id5=c.property_id \r\n\t\t\twhere a.property_id5=tsd.property_id5 and b.challan_id = ", num, " limit 1) ELSE '' END)\r\n\t\t\t) AS Goods_Services_Name\r\n        ,(case when tsd.item_serials<>'' THEN CONCAT('(',tsd.item_serials,')') ELSE '' END) AS itemserials      --added this portion to add item serials with each item name by sabbir\r\n       ,tsd.is_fixed_vat,i.item_specification,tsd.Quantity Quantity,tsd.sale_quantity, ui.unit_code UNIT, tsd.actual_price SD_Applicable_Price, tsd.Sd SD_Amount, tsd.Vat VAT_Amount,\r\n        to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),1,2)))||' '||substr(to_char(date_challan, 'dd/yyyy/MONTH'),9)||' '||to_text(int2(substr(to_char(date_challan, 'dd/mm/yyyy'),7,4))) TextDate,\r\n        to_text(int2(substr(to_char(date_challan, 'HH24:mi'),1,2)))||' HOUR '||to_text(int2(substr(to_char(date_challan, 'hh:mi'),4,2)))||' MINUTE' TextTime, (acd.code_name||'  '||tsm.vehicle_no) Vehicle \r\n        ,tsd.vat_rate,tsd.sd_rate sd_rate,property_quantity,tsd.discount_amt,tsd.additional_property\r\n        FROM trns_sale_master tsm \r\n        LEFT OUTER JOIN trns_party tp ON tsm.Party_id=tp.Party_id\r\n        LEFT OUTER JOIN app_code_detail acd ON tsm.vehicle_type_m=acd.code_id_m AND tsm.vehicle_type_d=acd.code_id_d\r\n        LEFT OUTER JOIN trns_sale_detail tsd ON tsm.Challan_id=tsd.Challan_id\r\n        LEFT OUTER JOIN Item i ON tsd.Item_id=i.Item_id\r\n       -- inner join item_unit ui on ui.unit_id=i.unit_id\r\n        inner join item_unit ui on ui.unit_id=tsd.sale_unit\r\n        WHERE tsm.challan_type='S' and tsm.Is_deleted=false and tsm.date_challan>= to_date('", str1, "','dd/MM/yyyy') and tsm.date_challan<=to_date('", str2, "','dd/MM/yyyy') ", str, "  order by tsm.date_challan " };
            string str3 = string.Concat(orgName);
            return this.DBUtil.GetDataTable(str3);
        }

        public DataSet rptDispose(trnsSaleMasterDAO objtrnsSaleMasterDAO)
        {
            string str = "";
            string str1 = "";
            if (objtrnsSaleMasterDAO.OrganizationId != 0)
            {
                str = string.Concat(" and m.Organization_id=", objtrnsSaleMasterDAO.OrganizationId);
            }
            if (objtrnsSaleMasterDAO.ItemId != 0)
            {
                str1 = string.Concat(" and i.Item_id=", objtrnsSaleMasterDAO.ItemId);
            }
            object[] startDate = new object[] { "select org.organization_name Organization_name, org.business_address Organization_address, org.registration_no Organization_BIN, \r\n        org.business_activity Business_activity_code, va.area_code Area_code, org.ba_phone Telephone_no,\r\n        d.row_no Sl_No_1, i.item_name Name_of_Inputs_2, d.purchase_challan_id Sl_No_of_Purchase_Challan_and_Sales_Book_3, d.Quantity Quantity_4, \r\n        (d.actual_price*d.Quantity) Actual_Value_5, (d.Vat*d.Quantity) VAT_Paid_6, (d.current_price*d.Quantity) Present_Value_7, \r\n        acd.code_name Reason_for_the_Unfit_8\r\n        from trns_sale_master m left join\r\n        trns_sale_detail d on m.Challan_id=d.Challan_id inner join\r\n        Item i on i.Item_id=d.Item_id inner join\r\n        org_registration_info org on org.Organization_id=m.Organization_id left join\r\n        vat_area va on va.area_id=org.area_id left join\r\n        app_code_detail acd on acd.code_id_m=disposal_reason_m and acd.code_id_d=disposal_reason_d\r\n        where m.challan_type='D' and m.date_challan>='", objtrnsSaleMasterDAO.StartDate, "' and m.date_challan<'", objtrnsSaleMasterDAO.FinishDate, "' ", str, str1 };
            string str2 = string.Concat(startDate);
            return this.DBUtil.GetDataSet(str2, "Disposal_of_UnusedUnfit_Inputs_Form_26");
        }
    }
}
