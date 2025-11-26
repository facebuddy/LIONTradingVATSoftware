using NBR_VAT_GROUPOFCOM.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class CraDebBLL
    {
        private DBUtility connDB = new DBUtility();

        public CraDebBLL()
        {
        }

        public DataTable categoryByItemId(int itemId)
        {
            string str = string.Concat("select distinct icc.category_name,icc.category_id from item_category ic\r\n                         inner join item_category icc \r\n                         on icc.category_id = ic.parent_id\r\n                         where ic.parent_id =(select  ic.parent_id from item_category ic inner join Item i on i.category_id = ic.category_id where item_id = ", itemId, ")");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetAllCreditChalanByDate(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select distinct tsm.note_no,tsm.note_id,tsm.party_id,tp.party_name\r\n                        from trns_note_master tsm \r\n                        inner join trns_party tp on tsm.party_id = tp.party_id\r\n                        inner join trns_note_detail td on tsm.note_id=td.note_id\r\n                        where cast(tsm.date_note as Date)>=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND cast(tsm.date_note as Date) <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and note_type='C' and td.status != 'O' and  td.item_id != 0 and tsm.organization_id=", num };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);



                string start_date = fromDate.ToString("yyyy-MM-dd");
                string end_date = toDate.ToString("yyyy-MM-dd");
             //   var returnList = MushakAPI.MushakReturn(start_date, end_date);

               // DataTable dt2 = new DataTable();
              //  DataColumn dc2 = dataTable.Columns.Add("note_id", typeof(int));
               // dataTable.Columns.Add("note_no", typeof(String));
            
                //foreach(var item in returnList)
                //{
                //    dataTable.Rows.Add(item.note_no, item.note_id.ToString());
                //}
               
            

               // dataTable = ListtoDataTableConverter.ToDataTable(returnList);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }








        public DataTable GetAllCreditChalanByDateS(DateTime fromDate, DateTime toDate, string fromDates, string toDates)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] str = new object[] { "select distinct tsm.note_no,tsm.note_id,tsm.party_id,tp.party_name\r\n                        from trns_note_master tsm \r\n                        inner join trns_party tp on tsm.party_id = tp.party_id\r\n                        inner join trns_note_detail td on tsm.note_id=td.note_id\r\n                        where cast(tsm.date_note as Date)>=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND cast(tsm.date_note as Date) <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and note_type='C' and td.status != 'O' and  td.item_id != 0 and tsm.organization_id=", num };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }



        public DataTable GetAllDebitChalanByDate(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string[] str = new string[] { "select distinct tsm.note_no,tsm.note_id,tsm.party_id,tp.party_name\r\n                        from trns_note_master tsm \r\n                        inner join trns_party tp on tsm.party_id = tp.party_id\r\n                        inner join trns_note_detail td on tsm.note_id=td.note_id\r\n                        where cast(tsm.date_note as Date)>=TO_DATE('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND cast(tsm.date_note as Date) <=TO_DATE('", toDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and note_type='D' and td.status != 'O' and  td.item_id != 0" };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getAllVatByItemId(int itemId)
        {
            string str = "";
            if (itemId > 0)
            {
                str = string.Concat(" AND i.Item_id = ", itemId);
            }
            string[] strArrays = new string[] { " select item_name,   max(Cd) CD,   max(Rd) RD,  max(Sd) SD, max(Vat)  VAT,  max(Ait) AIT from(\r\n            select i.item_name,itv.tax_value as CD, 0 as RD, 0 as SD, 0 as VAT, 0 as AIT\r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 1\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, itv.tax_value as RD, 0 as SD, 0 as VAT, 0 as AIT\r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 2\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, itv.tax_value as SD, 0 as VAT, 0 as AIT\r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 3\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, itv.tax_value as VAT, 0 as AIT\r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 4\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, 0 as VAT, itv.tax_value as AIT\r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 5\r\n           where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            ) item_tax_values group by item_name" };
            string str1 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getAvailStock(short ItemID, DateTime saleDate)
        {
            object[] str = new object[] { " SELECT coalesce((\r\n      ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'P' ))\r\n   -\r\n    ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n\r\n    ),0) availStock FROM ITEM i \r\n\tleft outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n    inner join item_category ic on ic.category_id = i.sub_category_id\r\n    WHERE I.ITEM_ID = ", ItemID, "  " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetChallanByChallanId(int challanid)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select distinct tsm.note_id,tsm.note_no,tp.party_name,tp.party_id\r\n                        from trns_note_master tsm \r\n                        inner join trns_party tp on tsm.party_id = tp.party_id\r\n                        where note_id=", challanid);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        private ArrayList getCrdateDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int noteID, long challanID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                str7 = " NULL ";
                str8 = " NULL ";
                CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO();
                creditNoteDetailDAO = (CreditNoteDetailDAO)arrDeailDAO[i];
                if (creditNoteDetailDAO.Property1 != 0)
                {
                    str = creditNoteDetailDAO.Property1.ToString();
                }
                if (creditNoteDetailDAO.Property2 != 0)
                {
                    str1 = creditNoteDetailDAO.Property2.ToString();
                }
                if (creditNoteDetailDAO.Property3 != 0)
                {
                    str2 = creditNoteDetailDAO.Property3.ToString();
                }
                if (creditNoteDetailDAO.Property4 != 0)
                {
                    str3 = creditNoteDetailDAO.Property4.ToString();
                }
                if (creditNoteDetailDAO.Property5 != 0)
                {
                    str4 = creditNoteDetailDAO.Property5.ToString();
                }
                if (creditNoteDetailDAO.Status == 'P')
                {
                    str7 = creditNoteDetailDAO.Challan_id.ToString();
                }
                if (creditNoteDetailDAO.Status == 'S')
                {
                    str8 = creditNoteDetailDAO.Challan_id.ToString();
                }
                creditNoteDetailDAO.DetailId = (long)Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('trns_note_detail_id_seq')"));
                object[] objArray = new object[] { " INSERT INTO trns_note_detail (note_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, actual_price, User_id_insert,Type,reason_drcr,\r\n                                        return_vat,return_sd,unit_price,total_price,other_deduct,vs_total_price,total_vat,return_reason,detail_id,Status, challan_id_purchase,challan_id_sale,type_p,credit_quantity,credit_unit)\r\n            VALUES (", noteID, ", ", creditNoteDetailDAO.RowNo, ",", creditNoteDetailDAO.Item_id, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", creditNoteDetailDAO.UnitId, ", ", creditNoteDetailDAO.CredQuantity, ",", creditNoteDetailDAO.ActUnitPrice, ",", creditNoteDetailDAO.UserId, ",'", creditNoteDetailDAO.Type, "',", creditNoteDetailDAO.DecreaseId, ",", creditNoteDetailDAO.Vat, ",", creditNoteDetailDAO.Sd, ",", creditNoteDetailDAO.GUnitPrice, ",", creditNoteDetailDAO.GTotalPrice, ",", creditNoteDetailDAO.PreviousAmount, ",", creditNoteDetailDAO.TotalPricewithVat, ",", creditNoteDetailDAO.TotalTax, ",'", creditNoteDetailDAO.ReasonOfReturn, "',", creditNoteDetailDAO.DetailId, ", '", creditNoteDetailDAO.Status, "',", str7, ",", str8, ",'", creditNoteDetailDAO.TypeP, "',", creditNoteDetailDAO.actualQuantity, ",", creditNoteDetailDAO.creditUnitId, ")" };
                arrDetailList.Add(string.Concat(objArray));
                if (creditNoteDetailDAO.DecreaseId == 1)
                {
                    str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", creditNoteDetailDAO.Item_id, "' )");
                    str6 = string.Concat(" ( SELECT coalesce(MAX(row_no)+1,1) ROW_NO FROM trns_purchase_detail WHERE Challan_id = '", challanID, "' )");
                    long num = (long)Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('item_detail_id_seq')"));
                    object[] objArray1 = new object[] { "INSERT INTO trns_purchase_detail(\r\n                    Challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n                    property_id4, property_id5, unit_id, Quantity, actual_price, Sd, Vat,  User_id_insert, \r\n                    lot_no, total_price, purchase_unit_price,sale_unit_price, purchase_vat, purchase_sd, s_p_return,detail_id)\r\n                    VALUES (", challanID, ", ", str6, ", ", creditNoteDetailDAO.Item_id, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n                            ", creditNoteDetailDAO.UnitId, ", ", creditNoteDetailDAO.CredQuantity, ", ", creditNoteDetailDAO.UnitPrice, ", ", creditNoteDetailDAO.Sd, ", ", creditNoteDetailDAO.Vat, ", ", creditNoteDetailDAO.UserId, ", \r\n                            ", str5, ", ", creditNoteDetailDAO.TotalPricewithVat, ", ", creditNoteDetailDAO.UnitPrice, ",", creditNoteDetailDAO.UnitPrice, ", ", creditNoteDetailDAO.Vat, ", ", creditNoteDetailDAO.Sd, ", ", creditNoteDetailDAO.Sp_Return, ",", num, ")" };
                    arrDetailList.Add(string.Concat(objArray1));
                }
            }
            return arrDetailList;
        }

        public DataTable getCreditChallanbyPartyId(int partyId)
        {
            string str = string.Concat("  Select * from trns_note_master where party_id= ", partyId, " and note_type='C' order by note_id desc");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getCreditItembyChallanId(int chaId)
        {
            string str = string.Concat(" select DISTINCT --tsd.row_no, \r\n                          CASE when tsd.type_p = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tsd.type_p = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tsd.type_p = 'S' then i.item_name ||'-'||'Service'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tsd.type_p = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            case when tsd.type_p = 'L' then i.item_id+.1\r\n                            when tsd.type_p = 'I' then i.item_id+.2 \r\n                            when tsd.type_p = 'S' then i.item_id+.4 \r\n                            when tsd.type_p = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                            from Item i\r\n                            inner join trns_sale_detail tsd\r\n                            on i.Item_id = tsd.Item_id\r\n                            where tsd.Challan_id=", chaId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetCreditNoteDataForReport(string noteID, ArrayList allmaster)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                ArrayList arrayLists = allmaster;
                CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO();
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    creditNoteDetailDAO = (CreditNoteDetailDAO)arrayLists[i];
                    if (creditNoteDetailDAO.Property1 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id1 = tsd.property_id1");
                    }
                    if (creditNoteDetailDAO.Property2 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id2 = tsd.property_id2");
                    }
                    if (creditNoteDetailDAO.Property3 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id3 = tsd.property_id3");
                    }
                    if (creditNoteDetailDAO.Property4 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id4 = tsd.property_id4");
                    }
                    if (creditNoteDetailDAO.Property5 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id5 = tsd.property_id5");
                    }
                }
                string[] strArrays = new string[] { "select distinct note_no, note_date, party_name, party_address, party_bin\r\n                        --, quantity,, item_name\r\n                        ,quantity,note_price,note_vat,note_sd, issue_Time, unit_price, unit_name,totalSD_VAT,\r\n                         sale_price, sale_quantity,sale_vat,sale_sd, return_reason, phone, fax, sale_challan_no, sale_challan_date, other_deduct,total_w_VAT\r\n                         , sale_challan_no, sale_challan_date,vehicle_no,code_name\r\n                        from(\r\n                        select tnm.note_no, to_char(tnm.date_note, 'dd-MON-yyyy') note_date, to_char(tnm.date_note::Time, 'HH:MI AM') issue_Time, tp.party_name, tp.party_address, tp.party_bin\r\n                        --, i.item_name\r\n\r\n                       \r\n\r\n                        , tnd.quantity, tnd.total_price note_price,\r\n                        tnd.return_vat note_vat, tnd.unit_price, itmunit.unit_code unit_name, tnd.return_sd note_sd\r\n                        ,tsd.vat sale_vat, tsd.sd sale_sd,tsd.quantity sale_quantity,((tsd.quantity * tsd.actual_price)+tsd.sd+tsd.vat) sale_price\r\n                       --select vat from trns_sale_detail where item_id=tnd.item_id AND challan_id = tnd.challan_id_sale limit 1) AS sale_vat\r\n                        --,(select sd from trns_sale_detail where item_id=tnd.item_id AND challan_id = tnd.challan_id_sale limit 1) AS sale_sd\r\n                        , tnd.return_reason, ori.ba_phone as phone, ori.ba_fax as fax,\r\n                        --tsm.challan_no as purchase_challan_no, to_char(tsm.date_challan, 'dd/MM/yyyy') as purchase_challan_date, \r\n                        tnd.other_deduct, tnd.total_vat totalSD_VAT, tnd.vs_total_price total_w_VAT\r\n                       ,tsm.challan_no as sale_challan_no, to_char(tsm.date_challan, 'dd/MM/yyyy') as sale_challan_date,tnm.vehicle_no Vehicle_No,acd.code_name\r\n                       -- ,(select m.challan_no from trns_sale_master m  inner join trns_sale_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS sale_challan_no\r\n                        --,(select to_char(m.date_challan, 'dd/MM/yyyy') from trns_sale_master m  inner join trns_sale_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS sale_challan_date\r\n                        from trns_note_master as tnm\r\n                        inner join trns_note_detail as tnd on tnm.note_id = tnd.note_id\r\n                        inner join trns_party as tp on tp.party_id = tnm.party_id\r\n                        inner join item as i on tnd.item_id = i.item_id                       \r\n                        inner join item_unit itmunit on itmunit.unit_id = tnd.unit_id\r\n                        inner join trns_sale_detail as tsd on tnd.challan_id_sale = tsd.challan_id and tnd.item_id = tsd.item_id ", str, "\r\n                        inner join trns_sale_master as tsm on tsd.challan_id = tsm.challan_id\r\n                        LEFT OUTER JOIN app_code_detail acd ON tnm.vehicle_type_m=acd.code_id_m AND tnm.vehicle_type_d=acd.code_id_d\r\n                        inner join org_registration_info as ori on ori.organization_id = tnm.organization_id\r\n\r\n                        where tnm.note_no = '", noteID, "' and tnm.is_deleted = false AND tnm.note_type='C'\r\n                        )mqmm\r\n                        " };
                string str1 = string.Concat(strArrays);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetCreditNoteNo(int challanType, int orgID, short brnchID)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select d.challan_book_id,d.page_no,d.challan_no,m.challan_book_no\r\n                        from trns_challan_no_detail as d\r\n                        left join trns_challan_no_master as m on d.challan_book_id = m.challan_book_id\r\n                        where d.challan_type = ", challanType, " and d.is_used = false\r\n                        and m.organization_id = ", orgID, " and (m.org_branch_reg_id = ", brnchID, " OR m.is_applicable_all_brnch = true)\r\n                        order by challan_book_no,page_no" };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getCreditOtherAdjusment()
        {
            return this.connDB.GetDataTable("select code_name, code_id_d from app_code_detail where code_id_m = 51");
        }

        public DataTable getDebitChallanbyPartyId(int partyId)
        {
            string str = string.Concat("  Select * from trns_note_master where party_id= ", partyId, " and note_type='D'  order by note_id desc");
            return this.connDB.GetDataTable(str);
        }

        private ArrayList getDebitDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int noteID, long challanID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                str7 = " NULL ";
                str8 = " NULL ";
                DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO();
                debitNoteDetailDAO = (DebitNoteDetailDAO)arrDeailDAO[i];
                if (debitNoteDetailDAO.Property1 != 0)
                {
                    str = debitNoteDetailDAO.Property1.ToString();
                }
                if (debitNoteDetailDAO.Property2 != 0)
                {
                    str1 = debitNoteDetailDAO.Property2.ToString();
                }
                if (debitNoteDetailDAO.Property3 != 0)
                {
                    str2 = debitNoteDetailDAO.Property3.ToString();
                }
                if (debitNoteDetailDAO.Property4 != 0)
                {
                    str3 = debitNoteDetailDAO.Property4.ToString();
                }
                if (debitNoteDetailDAO.Property5 != 0)
                {
                    str4 = debitNoteDetailDAO.Property5.ToString();
                }
                if (debitNoteDetailDAO.Status == 'P')
                {
                    str7 = debitNoteDetailDAO.Challan_id.ToString();
                }
                if (debitNoteDetailDAO.Status == 'S')
                {
                    str8 = debitNoteDetailDAO.Challan_id.ToString();
                }
                debitNoteDetailDAO.DetailId = (long)Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('trns_note_detail_id_seq')"));
                object[] objArray = new object[] { " INSERT INTO trns_note_detail (note_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, actual_price, User_id_insert,Type,reason_drcr,\r\n                                        return_vat,return_sd,unit_price,total_price,other_deduct,vs_total_price,total_vat,return_reason,detail_id,Status, challan_id_purchase,challan_id_sale,type_p,is_rebatable)\r\n            VALUES (", noteID, ", ", debitNoteDetailDAO.RowNo, ",", debitNoteDetailDAO.Item_id, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", debitNoteDetailDAO.UnitId, ", ", debitNoteDetailDAO.DebQuantity, ",", debitNoteDetailDAO.UnitPrice, ",", debitNoteDetailDAO.UserId, ",'", debitNoteDetailDAO.Type, "',", debitNoteDetailDAO.DecreaseId, ",", debitNoteDetailDAO.Vat, ",", debitNoteDetailDAO.Sd, ",", debitNoteDetailDAO.GUnitPrice, ",", debitNoteDetailDAO.GTotalPrice, ",", debitNoteDetailDAO.PreviousAmount, ",", debitNoteDetailDAO.TotalPricewithVat, ",", debitNoteDetailDAO.TotalTax, ",'", debitNoteDetailDAO.ReasonOfReturn, "',", debitNoteDetailDAO.DetailId, ", '", debitNoteDetailDAO.Status, "',", str7, ",", str8, ",'", debitNoteDetailDAO.TypeP, "',", debitNoteDetailDAO.isRebatable, ")" };
                arrDetailList.Add(string.Concat(objArray));
                if (debitNoteDetailDAO.DecreaseId == 1)
                {
                    str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", debitNoteDetailDAO.Item_id, "' )");
                    str6 = string.Concat(" ( SELECT coalesce(MAX(row_no)+1,1) ROW_NO FROM trns_purchase_detail WHERE Challan_id = ", challanID, " )");
                    long num = (long)Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('item_detail_id_seq')"));
                    object[] objArray1 = new object[] { "INSERT INTO trns_purchase_detail(\r\n                    Challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n                    property_id4, property_id5, unit_id, Quantity, actual_price, Sd, Vat,  User_id_insert, \r\n                    lot_no, total_price, purchase_unit_price, purchase_vat, purchase_sd, s_p_return,detail_id)\r\n                    VALUES (", challanID, ", ", str6, ", ", debitNoteDetailDAO.Item_id, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n                            ", debitNoteDetailDAO.UnitId, ", ", debitNoteDetailDAO.DebQuantity, ", ", debitNoteDetailDAO.UnitPrice, ", ", debitNoteDetailDAO.Sd, ", ", debitNoteDetailDAO.Vat, ", ", debitNoteDetailDAO.UserId, ", \r\n                            ", str5, ", ", debitNoteDetailDAO.TotalPricewithVat, ", ", debitNoteDetailDAO.UnitPrice, ", ", debitNoteDetailDAO.Vat, ", ", debitNoteDetailDAO.Sd, ", ", debitNoteDetailDAO.Sp_Return, ",", num, ")" };
                    arrDetailList.Add(string.Concat(objArray1));
                }
            }
            return arrDetailList;
        }

        public DataTable getDebitItembyChallanId(int chaId)
        {
            string str = string.Concat("  select DISTINCT tpd.row_no, \r\n                          CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                            from Item i\r\n                            inner join trns_purchase_detail tpd\r\n                            on i.Item_id = tpd.Item_id\r\n                            inner join trns_purchase_master as tpm\r\n                            on tpm.challan_id = tpd.challan_id\r\n                            where tpd.Challan_id = ", chaId, " and tpd.is_exempted=false and tpd.zero_rate=false");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDebitItembyChallanId(int chaId)
        {
            string str = string.Concat("  select DISTINCT \r\n                          CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                            from Item i\r\n                            inner join trns_purchase_detail tpd\r\n                            on i.Item_id = tpd.Item_id\r\n                            inner join trns_purchase_master as tpm\r\n                            on tpm.challan_id = tpd.challan_id\r\n                            where tpd.Challan_id = ", chaId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getDebitItembyChallanIdNew(int chaId)
        {
            string str = string.Concat("  select DISTINCT tpd.row_no, \r\n                          CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                            from Item i\r\n                            inner join trns_purchase_detail tpd\r\n                            on i.Item_id = tpd.Item_id\r\n                            inner join trns_purchase_master as tpm\r\n                            on tpm.challan_id = tpd.challan_id\r\n                            where tpd.Challan_id = ", chaId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getDebitItemSalebyChallanId(int chaId)
        {
            string str = string.Concat(" select DISTINCT tsd.row_no, \r\n                          CASE when tsd.type_p = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tsd.type_p = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tsd.type_p = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                            case when tsd.type_p = 'L' then i.item_id+.1\r\n                            when tsd.type_p = 'I' then i.item_id+.2 \r\n                            when tsd.type_p = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                            from Item i\r\n                            inner join trns_sale_detail tsd\r\n                            on i.Item_id = tsd.Item_id\r\n                            where tsd.Challan_id = ", chaId, " and tsd.is_exempted=false and tsd.is_zero_rate=false");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetDebitNoteDataForReport(string noteID, ArrayList allMaster)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                ArrayList arrayLists = allMaster;
                DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO();
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    debitNoteDetailDAO = (DebitNoteDetailDAO)arrayLists[i];
                    if (debitNoteDetailDAO.Property1 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id1 = tpd.property_id1");
                    }
                    if (debitNoteDetailDAO.Property2 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id2 = tpd.property_id2");
                    }
                    if (debitNoteDetailDAO.Property3 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id3 = tpd.property_id3");
                    }
                    if (debitNoteDetailDAO.Property4 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id4 = tpd.property_id4");
                    }
                    if (debitNoteDetailDAO.Property5 != 0)
                    {
                        str = string.Concat(str, " and tnd.property_id5 = tpd.property_id5");
                    }
                }
                string[] strArrays = new string[] { "select note_no,note_date,party_name,party_address,party_bin\r\n                       --,item_name\r\n                        ,quantity\r\n                        ,note_price,note_vat,note_sd,issue_Time,unit_price,unit_name,totalSD_VAT,vehicle_no,code_name,\r\n                      purchase_quantity, purchase_price,purchase_vat,purchase_sd,return_reason,phone,fax,purchase_challan_no,purchase_challan_date,other_deduct,total_w_VAT\r\n                        from (\r\n                        select tnm.note_no, to_char(tnm.date_note,'dd-MON-yyyy') note_date ,to_char(tnm.date_note::Time, 'HH:MI AM')  issue_Time, tp.party_name, tp.party_address, tp.party_bin\r\n                        --,i.item_name\r\n\r\n\r\n                        ,tnm.vehicle_no ,acd.code_name\r\n\r\n                        ,tnd.quantity\r\n                        ,tnd.total_price note_price,tnd.unit_price,itmunit.unit_code unit_name,tnd.other_deduct other_deduct,\r\n                        tnd.return_vat note_vat, tnd.return_sd note_sd, tpd.purchase_vat purchase_vat,tpd.purchase_sd purchase_sd,total_vat totalSD_VAT,tnd.vs_total_price total_w_VAT, tnd.return_reason, ori.ba_phone as phone, ori.ba_fax as fax,\r\n                      tpd.quantity purchase_quantity,tpm.challan_no as purchase_challan_no, to_char(tpm.date_challan,'dd/MM/yyyy') as purchase_challan_date,((tpd.purchase_unit_price*tpd.quantity)+tpd.purchase_sd+tpd.purchase_vat) purchase_price\r\n                       -- ,(select m.challan_no from trns_purchase_master m  inner join trns_purchase_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS purchase_challan_no\r\n                       -- ,(select to_char(m.date_challan, 'dd/MM/yyyy') from trns_purchase_master m  inner join trns_purchase_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS purchase_challan_date\r\n                        from trns_note_master as tnm\r\n                        inner join trns_note_detail as tnd on tnm.note_id = tnd.note_id\r\n                        inner join trns_party as tp on tp.party_id = tnm.party_id\r\n                        inner join item as i on tnd.item_id = i.item_id\r\n                        inner join item_unit itmunit on itmunit.unit_id=tnd.unit_id\r\n                        inner join trns_purchase_detail as tpd on tnd.challan_id_purchase = tpd.challan_id and tnd.item_id = tpd.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id ", str, "\r\n                        inner join org_registration_info as ori on ori.organization_id = tnm.organization_id\r\n                        LEFT OUTER JOIN app_code_detail acd ON tnm.vehicle_type_m=acd.code_id_m AND tnm.vehicle_type_d=acd.code_id_d\r\n                        where tnm.note_no = '", noteID, "' and tnm.is_deleted = false AND tnm.note_type='D'\r\n                        )mqmm" };
                string str1 = string.Concat(strArrays);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetDebitNoteNo(int challanType, int orgID, short brnchID)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select d.challan_book_id,d.page_no,d.challan_no,m.challan_book_no\r\n                        from trns_challan_no_detail as d\r\n                        left join trns_challan_no_master as m\r\n                        on d.challan_book_id = m.challan_book_id\r\n                        where d.challan_type = ", challanType, " and d.is_used = false\r\n                        and m.organization_id = ", orgID, " and (m.org_branch_reg_id = ", brnchID, " OR m.is_applicable_all_brnch = true)\r\n                        order by challan_book_no,page_no" };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public long GetDebitQtyPropertyWise(int cid, int iId, string type, short property1, short property2, short property3, short property4, short property5)
        {
            long num;
            try
            {
                string str = "";
                string empty = string.Empty;
                if (property1 > 0)
                {
                    object obj = str;
                    object[] objArray = new object[] { obj, " AND (tpd.property_id1 = ", property1, " OR tpd.property_id2 = ", property1, " OR tpd.property_id3 = ", property1, " OR tpd.property_id4 = ", property1, " OR tpd.property_id5 = ", property1, ")" };
                    str = string.Concat(objArray);
                }
                if (property2 > 0)
                {
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, " AND (tpd.property_id1 = ", property2, " OR tpd.property_id2 = ", property2, " OR tpd.property_id3 = ", property2, " OR tpd.property_id4 = ", property2, " OR tpd.property_id5 = ", property2, ")" };
                    str = string.Concat(objArray1);
                }
                if (property3 > 0)
                {
                    object obj2 = str;
                    object[] objArray2 = new object[] { obj2, " AND (tpd.property_id1 = ", property3, " OR tpd.property_id2 = ", property3, " OR tpd.property_id3 = ", property3, " OR tpd.property_id4 = ", property3, " OR tpd.property_id5 = ", property3, ")" };
                    str = string.Concat(objArray2);
                }
                if (property4 > 0)
                {
                    object obj3 = str;
                    object[] objArray3 = new object[] { obj3, " AND (tpd.property_id1 = ", property4, " OR tpd.property_id2 = ", property4, " OR tpd.property_id3 = ", property4, " OR tpd.property_id4 = ", property4, " OR tpd.property_id5 = ", property4, ")" };
                    str = string.Concat(objArray3);
                }
                if (property5 > 0)
                {
                    object obj4 = str;
                    object[] objArray4 = new object[] { obj4, " AND (tpd.property_id1 = ", property5, " OR tpd.property_id2 = ", property5, " OR tpd.property_id3 = ", property5, " OR tpd.property_id4 = ", property5, " OR tpd.property_id5 = ", property5, ")" };
                    str = string.Concat(objArray4);
                }
                object[] objArray5 = new object[] { " select distinct\r\n                        (select coalesce(sum(Quantity),0) \r\n                        from trns_purchase_detail as tpd \r\n                        inner join trns_purchase_master as tpm \r\n                        on tpd.challan_id = tpm.challan_id \r\n                        where tpd.challan_id = ", cid, " and tpd.item_id =", iId, " AND tpm.purchase_type = '", type, "'\r\n                        ", str, "\r\n                        )\r\n                        -\r\n                        (select coalesce(sum(Quantity),0) \r\n                        from trns_note_detail tpd\r\n                        where tpd.challan_id_purchase = ", cid, " AND tpd.type_p = '", type, "' ", str, ") as Quantity\r\n                        from trns_purchase_detail" };
                empty = string.Concat(objArray5);
                num = Convert.ToInt64(this.connDB.GetSingleValue(empty));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return num;
        }

        public long getDebitQuantity(int cid, int iId, string type)
        {
            object[] objArray = new object[] { "select distinct\r\n                        (select coalesce(sum(Quantity),0) \r\n                        from trns_purchase_detail as tpd \r\n                        inner join trns_purchase_master as tpm \r\n                        on tpd.challan_id = tpm.challan_id \r\n                        where tpd.challan_id = ", cid, " and tpd.item_id =", iId, " AND tpm.purchase_type = '", type, "')\r\n                        -\r\n                        (select coalesce(sum(Quantity),0) \r\n                        from trns_note_detail \r\n                        where challan_id_purchase = ", cid, " AND type_p = '", type, "') \t\t\t           \r\n                        as Quantity\r\n                        from trns_purchase_detail" };
            string str = string.Concat(objArray);
            return Convert.ToInt64(this.connDB.GetSingleValue(str));
        }

        public DataTable getMainChallan(int partyId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select tsm.challan_no, tsm.date_challan, tsm.Challan_id from trns_sale_master tsm\r\n                         inner join trns_sale_detail tsd on tsm.challan_id = tsd.challan_id\r\n                        where tsm.party_id =", partyId, "  and tsm.organization_id=", num1, " and tsm.org_branch_reg_id=", num, " and tsd.approver_stage='F' order by Challan_id desc " };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getMainChallanByBranch(int branchID)
        {
            string str = string.Concat("select challan_no, date_challan, Challan_id from trns_sale_master where org_branch_reg_id =", branchID);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getMainChallanforDebit(int partyId)
        {
            string str = string.Concat("select * from trns_purchase_master where party_id =", partyId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getMainChallanForDebitNote(int partyId)
        {
            string str = string.Concat("select challan_no, date_challan, Challan_id from trns_purchase_master where party_id =", partyId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getOAPartyBySeparator(short separator)
        {
            string str = string.Concat("select * from trns_party where separator =", separator);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getOtherAdjusment()
        {
            return this.connDB.GetDataTable("select code_name, code_id_d from app_code_detail where code_id_m = 34");
        }

        public DataTable GetPropByPartyId(string fdate, string tdate, int customerId)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (customerId != -1)
                {
                    str = string.Concat(str, "and  tnm.party_id = ", customerId);
                }
                string[] strArrays = new string[] { "select tnd.row_no,tnm.note_id,Coalesce(property_id1,0) property_id1,Coalesce(property_id2,0) property_id2,Coalesce(property_id3,0) property_id3,Coalesce(property_id4,0) property_id4,Coalesce(property_id5,0) property_id5 from trns_note_detail tnd \r\n                          inner join trns_note_master tnm on tnd.note_id=tnm.note_id where note_type='D' and tnm.date_note>=to_date('", fdate, "','dd/MM/yyyy') and tnm.date_note<=to_date('", tdate, "','dd/MM/yyyy') ", str, " " };
                string str1 = string.Concat(strArrays);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPropByPartyIdandChallanId(string fdate, string tdate, int customerId, int challanId)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (customerId != -1)
                {
                    str = string.Concat(str, "and  tnm.party_id = ", customerId);
                }
                object[] objArray = new object[] { "select tnd.row_no,tnm.note_id,Coalesce(property_id1,0) property_id1,Coalesce(property_id2,0) property_id2,Coalesce(property_id3,0) property_id3,Coalesce(property_id4,0) property_id4,Coalesce(property_id5,0) property_id5 from trns_note_detail tnd \r\n                          inner join trns_note_master tnm on tnd.note_id=tnm.note_id where note_type='D' and  tnd.note_id=", challanId, " and tnm.date_note>=to_date('", fdate, "','dd/MM/yyyy') and tnm.date_note<=to_date('", tdate, "','dd/MM/yyyy') ", str, " " };
                string str1 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPropforCreditByPartyId(string fdate, string tdate, int customerId)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (customerId != -1)
                {
                    str = string.Concat(str, "and  tnm.party_id = ", customerId);
                }
                string[] strArrays = new string[] { "select tnd.row_no,tnm.note_id,Coalesce(property_id1,0) property_id1,Coalesce(property_id2,0) property_id2,Coalesce(property_id3,0) property_id3,Coalesce(property_id4,0) property_id4,Coalesce(property_id5,0) property_id5 from trns_note_detail tnd \r\n                          inner join trns_note_master tnm on tnd.note_id=tnm.note_id where note_type='C' and tnm.date_note>=to_date('", fdate, "','dd/MM/yyyy') and tnm.date_note<=to_date('", tdate, "','dd/MM/yyyy') ", str, " " };
                string str1 = string.Concat(strArrays);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPropforCreditByPartyIdandChallanId(string fdate, string tdate, int customerId, int challanId)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (customerId != -1)
                {
                    str = string.Concat(str, "and  tnm.party_id = ", customerId);
                }
                object[] objArray = new object[] { "select tnd.row_no,tnm.note_id,Coalesce(property_id1,0) property_id1,Coalesce(property_id2,0) property_id2,Coalesce(property_id3,0) property_id3,Coalesce(property_id4,0) property_id4,Coalesce(property_id5,0) property_id5 from trns_note_detail tnd \r\n                          inner join trns_note_master tnm on tnd.note_id=tnm.note_id where note_type='C' and  tnd.note_id=", challanId, " and tnm.date_note>=to_date('", fdate, "','dd/MM/yyyy') and tnm.date_note<=to_date('", tdate, "','dd/MM/yyyy') ", str, " " };
                string str1 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPurchaseItembyChallanId(int chaId)
        {
            string str = string.Concat(" select i.Item_id, tpd.row_no,\r\n                          CASE coalesce(I.ITEM_SPECIFICATION,'null') WHEN 'null' THEN I.ITEM_NAME \r\n                          WHEN '' THEN I.ITEM_NAME||'-'||i.hs_code ELSE (I.ITEM_NAME||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code) END ITEM_NAME \r\n                            from Item i\r\n                            inner join trns_purchase_detail tpd\r\n                            on i.Item_id = tpd.Item_id\r\n                            where Challan_id = ", chaId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPurchaseReturnByFTDate(string fDate, string tDate, int customerId, int challanId, ArrayList allMaster, int row_no)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                string str1 = "";
                if (customerId != -1)
                {
                    str = string.Concat(str, "and tnm.party_id = ", customerId);
                }
                if (challanId != -99)
                {
                    str = string.Concat(str, "and tnm.note_id=", challanId);
                }
                ArrayList arrayLists = allMaster;
                DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO();
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    debitNoteDetailDAO = (DebitNoteDetailDAO)arrayLists[i];
                    if (debitNoteDetailDAO.Property1 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id1 = tpd.property_id1");
                    }
                    if (debitNoteDetailDAO.Property2 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id2 = tpd.property_id2");
                    }
                    if (debitNoteDetailDAO.Property3 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id3 = tpd.property_id3");
                    }
                    if (debitNoteDetailDAO.Property4 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id4 = tpd.property_id4");
                    }
                    if (debitNoteDetailDAO.Property5 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id5 = tpd.property_id5");
                    }
                }
                int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
                object[] rowNo = new object[] { "select note_no,note_date,party_name,party_address,party_bin,quantity,note_price,note_vat,note_sd,issue_Time,unit_price,unit_name,totalSD_VAT,\r\n                          purchase_quantity, purchase_price, purchase_vat,purchase_sd,return_reason,phone,fax,vehicle_no,code_name\r\n                            ,purchase_challan_no,purchase_challan_date\r\n                            ,other_deduct,total_w_VAT,vat_rate\r\n                        from (\r\n                        select tnm.note_no, to_char(tnm.date_note,'dd/MM/yyyy') note_date ,to_char(tnm.date_note::Time, 'HH:MI AM') issue_Time, tp.party_name, tp.party_address, tp.party_bin\r\n                        --,i.item_name\r\n\r\n                        ,tnm.vehicle_no ,acd.code_name\r\n\r\n                        ,tnd.quantity,tpd.vat_rate\r\n                        ,tnd.total_price note_price,tnd.unit_price,itmunit.unit_code unit_name,tnd.other_deduct other_deduct,\r\n                        tnd.return_vat note_vat, tnd.return_sd note_sd, tpd.purchase_vat purchase_vat,tpd.purchase_sd purchase_sd,total_vat totalSD_VAT,tnd.vs_total_price total_w_VAT, tnd.return_reason, ori.ba_phone as phone, ori.ba_fax as fax,\r\n                      tpd.quantity purchase_quantity,tpm.challan_no as purchase_challan_no, to_char(tpm.date_challan,'dd/MM/yyyy') as purchase_challan_date,((tpd.purchase_unit_price*tpd.quantity)+tpd.purchase_sd+tpd.purchase_vat) purchase_price\r\n                       -- ,(select m.challan_no from trns_purchase_master m  inner join trns_purchase_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS purchase_challan_no\r\n                       -- ,(select to_char(m.date_challan, 'dd/MM/yyyy') from trns_purchase_master m  inner join trns_purchase_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS purchase_challan_date\r\n                        from trns_note_master as tnm\r\n                        inner join trns_note_detail as tnd on tnm.note_id = tnd.note_id\r\n                        inner join trns_party as tp on tp.party_id = tnm.party_id\r\n                        inner join item as i on tnd.item_id = i.item_id\r\n                        inner join item_unit itmunit on itmunit.unit_id=tnd.unit_id\r\n                       inner join trns_purchase_detail as tpd on tnd.challan_id_purchase = tpd.challan_id and tnd.item_id = tpd.item_id ", str1, "\r\n                       inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        LEFT OUTER JOIN app_code_detail acd ON tnm.vehicle_type_m=acd.code_id_m AND tnm.vehicle_type_d=acd.code_id_d\r\n                        inner join org_registration_info as ori on ori.organization_id = tnm.organization_id\r\n                        where tnd.row_no=", row_no, " and tnm.date_note>=to_date('", fDate, "','dd/MM/yyyy') and tnm.date_note<=to_date('", tDate, "','dd/MM/yyyy') and tnm.is_deleted = false and tnm.note_type = 'D'\r\n                        and tnm.organization_id=", num, " ", str, ")mqmm" };
                string str2 = string.Concat(rowNo);
                dataTable = this.connDB.GetDataTable(str2);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPurchaseStock(short ItemID, DateTime saleDate)
        {
            object[] str = new object[] { " SELECT coalesce((\r\n       ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t    WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n    and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t    WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n    and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C') )\r\n\r\n    ),0) availStock FROM ITEM i \r\n\tleft outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n    inner join item_category ic on ic.category_id = i.sub_category_id\r\n    WHERE I.ITEM_ID = ", ItemID, "  " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getPurchaseUnitByItemId(int itemId, string challanNo, string type)
        {
            object[] objArray = new object[] { "select iu.*,tpd.purchase_unit_price,tpd.Quantity,tpd.row_no,ic.category_name,ic.category_id,\r\n                         tpd.purchase_vat, tpd.purchase_sd,tpd.is_rebatable,i.item_type,\r\n                        case when tpd.property_id1 is null  then 0 else tpd.property_id1 end property_id1,\r\n                        case when tpd.property_id2 is null  then 0 else tpd.property_id2 end property_id2,\r\n                        case when tpd.property_id3 is null  then 0 else tpd.property_id3 end property_id3,\r\n                        case when tpd.property_id4 is null  then 0 else tpd.property_id4 end property_id4,\r\n                        case when tpd.property_id5 is null  then 0 else tpd.property_id5 end property_id5\r\n                        from trns_purchase_detail tpd \r\n                        left outer join item_unit iu \r\n                        on tpd.unit_id = iu.unit_id\r\n                        inner join Item i\r\n                        on i.Item_id = tpd.Item_id\r\n                        inner join item_category ic\r\n                        on ic.category_id = i.sub_category_id\r\n                        inner join trns_purchase_master tpm\r\n                        on tpm.challan_id = tpd.challan_id    \r\n                        where tpd.item_id = '", itemId, "' AND tpm.challan_no = '", challanNo, "' AND tpm.purchase_type='", type, "' " };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public long getQuantity(int cid, int iId, string type)
        {
            object[] objArray = new object[] { "select distinct\r\n(select coalesce(sum(Quantity),0) from trns_sale_detail where challan_id = ", cid, " and item_id =", iId, " AND type_p = '", type, "')\r\n-\r\n(select coalesce(sum(Quantity),0) from trns_note_detail where challan_id_sale = ", cid, " AND type_p = '", type, "') as Quantity\r\nfrom trns_sale_detail" };
            string str = string.Concat(objArray);
            return Convert.ToInt64(this.connDB.GetSingleValue(str));
        }

        public long GetQuantityForCredit(int cid, int iId, string type, short property1, short property2, short property3, short property4, short property5)
        {
            long num;
            try
            {
                string str = "";
                string empty = string.Empty;
                if (property1 > 0)
                {
                    object obj = str;
                    object[] objArray = new object[] { obj, " AND (property_id1 = ", property1, " OR property_id2 = ", property1, " OR property_id3 = ", property1, " OR property_id4 = ", property1, " OR property_id5 = ", property1, ")" };
                    str = string.Concat(objArray);
                }
                if (property2 > 0)
                {
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, " AND (property_id1 = ", property2, " OR property_id2 = ", property2, " OR property_id3 = ", property2, " OR property_id4 = ", property2, " OR property_id5 = ", property2, ")" };
                    str = string.Concat(objArray1);
                }
                if (property3 > 0)
                {
                    object obj2 = str;
                    object[] objArray2 = new object[] { obj2, " AND (property_id1 = ", property3, " OR property_id2 = ", property3, " OR property_id3 = ", property3, " OR property_id4 = ", property3, " OR property_id5 = ", property3, ")" };
                    str = string.Concat(objArray2);
                }
                if (property4 > 0)
                {
                    object obj3 = str;
                    object[] objArray3 = new object[] { obj3, " AND (property_id1 = ", property4, " OR property_id2 = ", property4, " OR property_id3 = ", property4, " OR property_id4 = ", property4, " OR property_id5 = ", property4, ")" };
                    str = string.Concat(objArray3);
                }
                if (property5 > 0)
                {
                    object obj4 = str;
                    object[] objArray4 = new object[] { obj4, " AND (property_id1 = ", property5, " OR property_id2 = ", property5, " OR property_id3 = ", property5, " OR property_id4 = ", property5, " OR property_id5 = ", property5, ")" };
                    str = string.Concat(objArray4);
                }
                object[] objArray5 = new object[] { " select distinct\r\n                    (select coalesce(sum(Quantity),0) from trns_sale_detail where challan_id = ", cid, " and item_id =", iId, " AND type_p = '", type, "' ", str, ")\r\n                    -\r\n                    (select coalesce(sum(Quantity),0) from trns_note_detail where challan_id_sale = ", cid, " AND type_p = '", type, "' ", str, ") as Quantity\r\n                    from trns_sale_detail" };
                empty = string.Concat(objArray5);
                num = Convert.ToInt64(this.connDB.GetSingleValue(empty));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return num;
        }

        public DataTable getSaleItembyChallanId(int chaId)
        {
            string str = string.Concat(" select i.Item_id, \r\n                          CASE coalesce(I.ITEM_SPECIFICATION,'null') WHEN 'null' THEN I.ITEM_NAME \r\n                          WHEN '' THEN I.ITEM_NAME||'-'||i.hs_code ELSE (I.ITEM_NAME||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code) END ITEM_NAME \r\n                            from Item i\r\n                            inner join trns_sale_detail tpd\r\n                            on i.Item_id = tpd.Item_id\r\n                            where Challan_id = ", chaId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetSaleReturnByFTDateReport(string fDate, string tDate, int customerId, int creditChallanId, ArrayList allMaster, int row_id)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                string str1 = "";
                if (customerId != -1)
                {
                    str = string.Concat(str, "and tnm.party_id = ", customerId);
                }
                if (creditChallanId != -99)
                {
                    str = string.Concat(str, "and tnm.note_id=", creditChallanId);
                }
                ArrayList arrayLists = allMaster;
                CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO();
                for (int i = 0; i < arrayLists.Count; i++)
                {
                  //  creditNoteDetailDAO = (CreditNoteDetailDAO)arrayLists[i];
                    if (creditNoteDetailDAO.Property1 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id1 = tsd.property_id1");
                    }
                    if (creditNoteDetailDAO.Property2 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id2 = tsd.property_id2");
                    }
                    if (creditNoteDetailDAO.Property3 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id3 = tsd.property_id3");
                    }
                    if (creditNoteDetailDAO.Property4 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id4 = tsd.property_id4");
                    }
                    if (creditNoteDetailDAO.Property5 != 0)
                    {
                        str1 = string.Concat(str1, " and tnd.property_id5 = tsd.property_id5");
                    }
                }
                int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
                object[] objArray = new object[] { "select distinct note_no, note_date, party_name, party_address, party_bin, item_name, quantity, note_price, note_vat, note_sd, issue_Time, unit_price, unit_name, totalSD_VAT,\r\n                         sale_price, sale_quantity,sale_vat, sale_sd, return_reason, phone, fax\r\n                        --,sale_challan_no, sale_challan_date\r\n                        ,other_deduct, total_w_VAT\r\n                        ,sale_challan_no, sale_challan_date,vehicle_no Vehicle_No,code_name\r\n                        from(\r\n                        select tnm.note_no, to_char(tnm.date_note, 'dd-MON-yyyy') note_date, to_char(tnm.date_note::Time, 'HH:MI AM') issue_Time, tp.party_name, tp.party_address, tp.party_bin\r\n                        --,i.item_name\r\n\r\n                        ,(i.item_name \r\n                        || ' ' || (CASE WHEN tnd.property_id1 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t            where a.property_id1=tnd.property_id1 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id2 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t            where a.property_id2=tnd.property_id2 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id3 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id3=tnd.property_id3 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id4 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id4=tnd.property_id4 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN tnd.property_id5 > 0 THEN (select c.property_name from trns_note_detail a \r\n\t\t\t            inner join trns_note_master b on a.note_id=b.note_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id5=tnd.property_id5 and b.note_no = tnm.note_no and b.note_type = 'C' limit 1) ELSE '' END)\r\n\t\t\t            ) AS item_name\r\n\r\n                        ,tnd.quantity, tnd.total_price note_price,\r\n                        tnd.return_vat note_vat, tnd.unit_price, itmunit.unit_code unit_name, tnd.return_sd note_sd\r\n                       ,tsd.vat sale_vat, tsd.sd sale_sd,tsd.quantity sale_quantity,((tsd.quantity * tsd.actual_price)+tsd.sd+tsd.vat) sale_price\r\n                       -- ,(select vat from trns_sale_detail where item_id=tnd.item_id AND challan_id = tnd.challan_id_sale limit 1) AS sale_vat\r\n                       -- ,(select sd from trns_sale_detail where item_id=tnd.item_id AND challan_id = tnd.challan_id_sale limit 1) AS sale_sd\r\n                        ,tnd.return_reason, ori.ba_phone as phone, ori.ba_fax as fax,\r\n                        tsm.challan_no as purchase_challan_no, to_char(tsm.date_challan, 'dd/MM/yyyy') as purchase_challan_date, \r\n                        tnd.other_deduct, tnd.total_vat totalSD_VAT, tnd.vs_total_price total_w_VAT\r\n                        ,tsm.challan_no as sale_challan_no, to_char(tsm.date_challan, 'dd/MM/yyyy') as sale_challan_date,tnm.vehicle_no Vehicle_No,acd.code_name\r\n                      --  ,(select m.challan_no from trns_sale_master m  inner join trns_sale_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS sale_challan_no\r\n                       -- ,(select to_char(m.date_challan, 'dd/MM/yyyy') from trns_sale_master m  inner join trns_sale_detail d on m.challan_id=d.challan_id where d.challan_id = tnd.challan_id_sale limit 1) AS sale_challan_date\r\n                        from trns_note_master as tnm\r\n                        inner join trns_note_detail as tnd on tnm.note_id = tnd.note_id\r\n                        inner join trns_party as tp on tp.party_id = tnm.party_id\r\n                        inner join item as i on tnd.item_id = i.item_id                       \r\n                        inner join item_unit itmunit on itmunit.unit_id = tnd.unit_id\r\n                        inner join trns_sale_detail as tsd on tnd.challan_id_sale = tsd.challan_id and tnd.item_id = tsd.item_id ", str1, "\r\n                        inner join trns_sale_master as tsm on tsd.challan_id = tsm.challan_id\r\n                        LEFT OUTER JOIN app_code_detail acd ON tnm.vehicle_type_m=acd.code_id_m AND tnm.vehicle_type_d=acd.code_id_d\r\n                        inner join org_registration_info as ori on ori.organization_id = tnm.organization_id\r\n\r\n\r\n                        where tnm.date_note>=to_date('", fDate, "','dd/MM/yyyy') and tnd.row_no=", row_id, " and tnm.date_note<=to_date('", tDate, "','dd/MM/yyyy')  and tnm.is_deleted = false and tnm.note_type = 'C'\r\n                        and tnm.organization_id=", num, " ", str, ")mqmm" };
                string str2 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str2);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getSaleStock(short ItemID, DateTime saleDate)
        {
            object[] str = new object[] { " SELECT coalesce((\r\n       ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t    WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n    and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t    WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n    and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C') )\r\n\r\n    ),0) availStock FROM ITEM i \r\n\tleft outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n    inner join item_category ic on ic.category_id = i.category_id\r\n    WHERE I.ITEM_ID = ", ItemID, "  " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getUnitByItemId(int itemId, string challanNo)
        {
            object[] objArray = new object[] { "select iu.*,tsd.actual_price,tsd.Quantity,tsd.row_no,ic.category_name,ic.category_id,tsd.Vat,tsd.Sd,i.item_type,\r\n                        case when tsd.property_id1 is null  then 0 else tsd.property_id1 end property_id1,\r\n                        case when tsd.property_id2 is null  then 0 else tsd.property_id2 end property_id2,\r\n                        case when tsd.property_id3 is null  then 0 else tsd.property_id3 end property_id3,\r\n                        case when tsd.property_id4 is null  then 0 else tsd.property_id4 end property_id4,\r\n                        case when tsd.property_id5 is null  then 0 else tsd.property_id5 end property_id5\r\n                        from trns_sale_detail tsd \r\n                        left outer join item_unit iu \r\n                        on tsd.unit_id = iu.unit_id\r\n                        inner join Item i\r\n                        on i.Item_id = tsd.Item_id\r\n                        inner join item_category ic\r\n                        on ic.category_id = i.sub_category_id\r\n                        inner join trns_sale_master tsm\r\n                        on tsm.Challan_id = tsd.Challan_id    \r\n                        where tsd.Item_id = '", itemId, "' AND tsm.challan_no = '", challanNo, "' " };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetVatTaxForCredit(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (itemId > 0)
                {
                    str = string.Concat(" AND i.Item_id = ", itemId, " and itv.is_tran_sale=true");
                }
                object[] objArray = new object[] { " select item_name,   max(Cd) CD,   max(Rd) RD,  max(Sd) SD, max(Vat)  VAT,  max(Ait) AIT,max(per) AS PER from(\r\n            select i.item_name,itv.tax_value as CD, 0 as RD, 0 as SD, 0 as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 1\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, itv.tax_value as RD, 0 as SD, 0 as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 2\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, itv.tax_value as SD, 0 as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 3\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, itv.tax_value as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 4\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, 0 as VAT, itv.tax_value as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 5\r\n           where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            UNION ALL\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, itv.tax_value as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 99\r\n            where i.Is_deleted=false AND itv.is_current = true AND i.Item_id = ", itemId, " AND itv.is_tran_sale=true and itv.per='1'\r\n\r\n            ) item_tax_values group by item_name" };
                string str1 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetVatTaxForDebit(int itemId, string purchaseTyp)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (itemId > 0)
                {
                    str = string.Concat(str, " AND i.Item_id = ", itemId);
                }
                str = (purchaseTyp != "L" ? string.Concat(str, " AND itv.is_tran_import = true") : string.Concat(str, " AND itv.is_tran_local = true"));
                object[] objArray = new object[] { " select item_name,   max(Cd) CD,   max(Rd) RD,  max(Sd) SD, max(Vat)  VAT,  max(Ait) AIT,max(per) AS PER from(\r\n            select i.item_name,itv.tax_value as CD, 0 as RD, 0 as SD, 0 as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 1\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, itv.tax_value as RD, 0 as SD, 0 as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 2\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, itv.tax_value as SD, 0 as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 3\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, itv.tax_value as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 4\r\n            where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, 0 as VAT, itv.tax_value as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 5\r\n           where i.Is_deleted=false AND itv.is_current = true", str, "\r\n\r\n            UNION ALL\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, itv.tax_value as VAT, 0 as AIT,itv.per \r\n            from Item as i\r\n            left outer join item_tax_values as itv\r\n            on i.Item_id = itv.Item_id and tax_id = 99\r\n            where i.Is_deleted = false AND itv.is_current = true AND i.Item_id = ", itemId, " and itv.per='1'\r\n\r\n            ) item_tax_values group by item_name" };
                string str1 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable loadDecreaseType()
        {
            return this.connDB.GetDataTable("select code_id_d, code_name from app_code_detail where code_id_m = 20");
        }

        public DataTable loadPurchaseChallan(int partyId, string type)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
            object[] objArray = new object[] { "select tpm.challan_no,tpm.challan_id,tpm.date_challan from trns_purchase_master tpm\r\n                                inner join trns_purchase_detail tpd on tpm.challan_id = tpd.challan_id\r\n                                where tpm.party_id = ", partyId, " and tpm.purchase_type='", type, "' and tpm.Challan_type='P' and tpm.organization_id = ", num1, " and tpm.org_branch_reg_id = ", num, " and tpd.approver_stage='F' order by challan_id desc" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable loadPurchaseChallanForBranch(int branchId, string type)
        {
            object[] objArray = new object[] { "select challan_no,challan_id,date_challan from trns_purchase_master \r\n                                where org_branch_reg_id = ", branchId, " and purchase_type='", type, "'" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public bool saveCreditNote(CreditNoteMasterDAO objMaster, ArrayList arrDetail, ArrayList chkadditionalPropId)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string vehicalType = objMaster.VehicalType;
            str = (objMaster.PartyId == 0 ? "NULL" : objMaster.PartyId.ToString());
            try
            {
                objMaster.NoteId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('note_id_seq')"));
                object[] noteId = new object[] { "insert into trns_note_master(note_id,org_branch_reg_id,organization_id, note_type, date_note, note_year, note_no, cg_note_no, party_id, vehicle_type_m, vehicle_type_d, vehicle_no, reason, User_id_insert) \r\n                    values('", objMaster.NoteId, "',", objMaster.BranchID, ",'", objMaster.OrgId, "', '", objMaster.NoteType, "', to_timestamp('", objMaster.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", objMaster.NoteYear, "', '", objMaster.CreditNotNumber, "', (select coalesce (max (cg_note_no),0)+1 from trns_note_master where note_type IN ('C','R','D') and note_year='", objMaster.NoteYear, "'), ", str, ", ", objMaster.VehicleTypeM, ", ", objMaster.VehicleTypeD, ", '", objMaster.VehicleNo, "', '", objMaster.DiscardReasion, "', ", objMaster.UserId, ")" };
                arrayLists.Add(string.Concat(noteId));
                objMaster.Challan_id = Convert.ToInt64(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                object[] challanId = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id, Organization_id, challan_type, purchase_type,\r\n                                                            date_challan, party_id,user_id_insert,challan_no,payment_method)\r\n             VALUES ( ", objMaster.Challan_id, ",", objMaster.BranchID, ", ", objMaster.OrgId, ", '", objMaster.MaterialType, "', '", objMaster.ItemType, "', \r\n                    to_timestamp('", null, null, null, null, null, null, null, null };
                challanId[11] = objMaster.ChallanDate.ToString("MM/dd/yyyy HH:mm");
                challanId[12] = "','MM/dd/yyyy HH24:MI'),";
                challanId[13] = objMaster.PartyId;
                challanId[14] = ",";
                challanId[15] = objMaster.UserId;
                challanId[16] = ",'";
                challanId[17] = objMaster.CreditNotNumber;
                challanId[18] = "','0' )";
                arrayLists.Add(string.Concat(challanId));
                if (chkadditionalPropId.Count > 0)
                {
                    for (int i = 0; i < chkadditionalPropId.Count; i++)
                    {
                        AdditionalProperty additionalProperty = new AdditionalProperty();
                        additionalProperty = (AdditionalProperty)chkadditionalPropId[i];
                        object[] objArray = new object[] { "Update trns_production_rcv_additional set status='", additionalProperty.status, "' where additional_info_id=", additionalProperty.additionalInfoId, " " };
                        arrayLists.Add(string.Concat(objArray));
                    }
                }
                if (objMaster.NoteType != 'R')
                {
                    object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMaster.ChallanBookId, " and page_no = ", objMaster.ChallanPageNumber };
                    arrayLists.Add(string.Concat(challanBookId));
                }
                else
                {
                    object[] discardReasion = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objMaster.DiscardReasion, "' where challan_book_id = ", objMaster.ChallanBookId, " and page_no = ", objMaster.ChallanPageNumber };
                    arrayLists.Add(string.Concat(discardReasion));
                }
                arrayLists = this.getCrdateDetails(arrayLists, arrDetail, objMaster.NoteId, objMaster.Challan_id);
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }

        public bool saveDebitNote(DebitNoteMasterDAO objMaster, ArrayList arrDetail, Dictionary<int, int> chkadditionalPropId)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string vehicalType = objMaster.VehicalType;
            str = (objMaster.PartyId == 0 ? "NULL" : objMaster.PartyId.ToString());
            try
            {
                objMaster.NoteId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('note_id_seq')"));
                object[] noteId = new object[] { "insert into trns_note_master(note_id,org_branch_reg_id, organization_id, note_type, date_note, note_year, note_no, cg_note_no, party_id, vehicle_type_m, vehicle_type_d, vehicle_no, reason, User_id_insert) \r\n                    values('", objMaster.NoteId, "', ", objMaster.BranchID, ", '", objMaster.OrgId, "', '", objMaster.NoteType, "', to_timestamp('", objMaster.ChallanDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'), '", objMaster.NoteYear, "', '", objMaster.CreditNotNumber, "', (select coalesce (max (cg_note_no),0)+1 from trns_note_master where note_type IN ('C','R','D') and note_year='", objMaster.NoteYear, "'), ", str, ", ", objMaster.VehicleTypeM, ", ", objMaster.VehicleTypeD, ", '", objMaster.VehicleNo, "', '", objMaster.DiscardReasion, "', ", objMaster.UserId, ")" };
                arrayLists.Add(string.Concat(noteId));
                objMaster.Challan_id = Convert.ToInt64(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                if (chkadditionalPropId.Count > 0)
                {
                    foreach (int key in chkadditionalPropId.Keys)
                    {
                        int num = Convert.ToInt32(key);
                        arrayLists.Add(string.Concat("Update trns_production_rcv_additional set status='D' where additional_info_id=", num, " "));
                    }
                }
                object[] challanId = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id, Organization_id, challan_type, purchase_type,\r\n                                                            date_challan, party_id,user_id_insert,challan_no)\r\n             VALUES ( ", objMaster.Challan_id, ",", objMaster.BranchID, ", ", objMaster.OrgId, ", '", objMaster.MaterialType, "', '", objMaster.ItemType, "', \r\n                    to_timestamp('", null, null, null, null, null, null, null, null };
                challanId[11] = objMaster.ChallanDate.ToString("dd/MM/yyyy HH:mm");
                challanId[12] = "','dd/MM/yyyy HH24:MI'),";
                challanId[13] = objMaster.PartyId;
                challanId[14] = ",";
                challanId[15] = objMaster.UserId;
                challanId[16] = ",'";
                challanId[17] = objMaster.CreditNotNumber;
                challanId[18] = "' )";
                arrayLists.Add(string.Concat(challanId));
                if (objMaster.NoteType != 'R')
                {
                    object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMaster.ChallanBookId, " and page_no = ", objMaster.ChallanPageNumber };
                    arrayLists.Add(string.Concat(challanBookId));
                }
                else
                {
                    object[] discardReasion = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objMaster.DiscardReasion, "' where challan_book_id = ", objMaster.ChallanBookId, " and page_no = ", objMaster.ChallanPageNumber };
                    arrayLists.Add(string.Concat(discardReasion));
                }
                arrayLists = this.getDebitDetails(arrayLists, arrDetail, objMaster.NoteId, objMaster.Challan_id);
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return flag;
        }

        public bool saveOtherAdjusment(DebitNoteMasterDAO objMaster, DebitNoteDetailDAO objCD)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = " NULL";
                string str4 = " NULL";
                string str5 = " NULL";
                string str6 = " NULL";
                string str7 = " NULL";
                string str8 = " NULL ";
                string str9 = " NULL ";
                if (objMaster.VehicalType == null)
                {
                    str = "NULL";
                    str1 = "NULL";
                    str2 = "NULL";
                }
                objMaster.NoteId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('note_id_seq')"));
                object[] noteId = new object[] { "insert into trns_note_master(note_id, organization_id, note_type, date_note, note_year, other_note_no, cg_note_no, party_id, vehicle_type_m, vehicle_type_d, vehicle_no, reason, User_id_insert,is_other_adj,note_no,application_submit_date) \r\n                    values('", objMaster.NoteId, "', '", objMaster.OrgId, "', '", objMaster.NoteType, "', to_timestamp('", objMaster.DateNote.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", objMaster.NoteYear, "', '", objMaster.CreditNotNumber, "', (select coalesce (max (cg_note_no),0)+1 from trns_note_master where note_type IN ('C','R','D') and note_year='", objMaster.NoteYear, "'), ", objMaster.PartyId, ", ", str, ", ", str1, ", ", str2, ", '", objMaster.DiscardReasion, "', ", objMaster.UserId, ",", objMaster.IsOtherAdj, ",'otheradjustment',to_timestamp('", objMaster.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(noteId));
                objCD.DetailId = (long)Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('trns_note_detail_id_seq')"));
                object[] objArray = new object[] { " INSERT INTO trns_note_detail (note_id,row_no,item_id,unit_id, property_id1, property_id2, property_id3, property_id4, property_id5, User_id_insert,\r\n                                        actual_price,total_vat,detail_id,Status, challan_id_purchase,challan_id_sale, oa_subject, oa_case_no, oa_description,type_p,vat_amount,no_of_days,interest_pct,interest_amount,particulars,reason_drcr,ait_pct,ait_amount)\r\n            VALUES (", objMaster.NoteId, ",1, 0, 1, ", str3, ", ", str4, ", ", str5, ", ", str6, ", ", str7, ",", objCD.UserId, ", ", objCD.OA_Amount, ",0, ", objCD.DetailId, ", '", objCD.Status, "',", str8, ",", str9, ",'", objCD.OA_Subject, "', '", objCD.OA_CaseNo, "',\r\n                     '", objCD.OA_CaseDetail, "','", objCD.TypeP, "',", objCD.Vat_Amount, ",", objCD.No_of_Days, ",", objCD.Interest_Pct, ",", objCD.Interest_Amount, ",\r\n                     '", objCD.Particulars, "',", objCD.reason_drcr, ",", objCD.AIT_Pct, ",", objCD.AIT_Amount, ")" };
                arrayLists.Add(string.Concat(objArray));
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool saveOtherAdjusmentforGift(DebitNoteMasterDAO objMaster, DebitNoteDetailDAO objCD, string challan)
        {
            bool flag;
            try
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = challan.TrimEnd(chrArray).Split(new char[] { ',' });
                ArrayList arrayLists = new ArrayList();
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = " NULL";
                string str4 = " NULL";
                string str5 = " NULL";
                string str6 = " NULL";
                string str7 = " NULL";
                string str8 = " NULL ";
                string str9 = " NULL ";
                if (objMaster.VehicalType == null)
                {
                    str = "NULL";
                    str1 = "NULL";
                    str2 = "NULL";
                }
                objMaster.NoteId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('note_id_seq')"));
                object[] noteId = new object[] { "insert into trns_note_master(note_id, organization_id, note_type, date_note, note_year, other_note_no, cg_note_no, party_id, vehicle_type_m, vehicle_type_d, vehicle_no, reason, User_id_insert,is_other_adj,note_no,application_submit_date) \r\n                    values('", objMaster.NoteId, "', '", objMaster.OrgId, "', '", objMaster.NoteType, "', to_timestamp('", objMaster.DateNote.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", objMaster.NoteYear, "', '", objMaster.CreditNotNumber, "', (select coalesce (max (cg_note_no),0)+1 from trns_note_master where note_type IN ('C','R','D') and note_year='", objMaster.NoteYear, "'), ", objMaster.PartyId, ", ", str, ", ", str1, ", ", str2, ", '", objMaster.DiscardReasion, "', ", objMaster.UserId, ",", objMaster.IsOtherAdj, ",'otheradjustment',to_timestamp('", objMaster.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(noteId));
                objCD.DetailId = (long)Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('trns_note_detail_id_seq')"));
                object[] objArray = new object[] { " INSERT INTO trns_note_detail (note_id,row_no,item_id,unit_id, property_id1, property_id2, property_id3, property_id4, property_id5, User_id_insert,\r\n                                        actual_price,total_vat,detail_id,Status, challan_id_purchase,challan_id_sale, oa_subject, oa_case_no, oa_description,type_p,vat_amount,no_of_days,interest_pct,interest_amount,particulars,reason_drcr,ait_pct,ait_amount)\r\n            VALUES (", objMaster.NoteId, ",1, 0, 1, ", str3, ", ", str4, ", ", str5, ", ", str6, ", ", str7, ",", objCD.UserId, ", ", objCD.OA_Amount, ",0, ", objCD.DetailId, ", '", objCD.Status, "',", str8, ",", str9, ",'", objCD.OA_Subject, "', '", objCD.OA_CaseNo, "',\r\n                     '", objCD.OA_CaseDetail, "','", objCD.TypeP, "',", objCD.Vat_Amount, ",", objCD.No_of_Days, ",", objCD.Interest_Pct, ",", objCD.Interest_Amount, ",\r\n                     '", objCD.Particulars, "',", objCD.reason_drcr, ",", objCD.AIT_Pct, ",", objCD.AIT_Amount, ")" };
                arrayLists.Add(string.Concat(objArray));
                string[] strArrays1 = strArrays;
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    string str10 = strArrays1[i];
                    arrayLists.Add(string.Concat("update gift_items_detail set is_vat_deducted = true where challan_id = ", str10));
                }
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool saveOtherAdjusmentforRebateAdjustment(DebitNoteMasterDAO objMaster, DebitNoteDetailDAO objCD, int challanId)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = " NULL";
                string str4 = " NULL";
                string str5 = " NULL";
                string str6 = " NULL";
                string str7 = " NULL";
                string str8 = " NULL ";
                string str9 = " NULL ";
                if (objMaster.VehicalType == null)
                {
                    str = "NULL";
                    str1 = "NULL";
                    str2 = "NULL";
                }
                objMaster.NoteId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('note_id_seq')"));
                object[] noteId = new object[] { "insert into trns_note_master(note_id, organization_id, note_type, date_note, note_year, other_note_no, cg_note_no, party_id, vehicle_type_m, vehicle_type_d, vehicle_no, reason, User_id_insert,is_other_adj,note_no,application_submit_date) \r\n                    values('", objMaster.NoteId, "', '", objMaster.OrgId, "', '", objMaster.NoteType, "', to_timestamp('", objMaster.DateNote.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", objMaster.NoteYear, "', '", objMaster.CreditNotNumber, "', (select coalesce (max (cg_note_no),0)+1 from trns_note_master where note_type IN ('C','R','D') and note_year='", objMaster.NoteYear, "'), ", objMaster.PartyId, ", ", str, ", ", str1, ", ", str2, ", '", objMaster.DiscardReasion, "', ", objMaster.UserId, ",", objMaster.IsOtherAdj, ",'otheradjustment',to_timestamp('", objMaster.submisionDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(noteId));
                objCD.DetailId = (long)Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('trns_note_detail_id_seq')"));
                object[] objArray = new object[] { " INSERT INTO trns_note_detail (note_id,row_no,item_id,unit_id, property_id1, property_id2, property_id3, property_id4, property_id5, User_id_insert,\r\n                                        actual_price,total_vat,detail_id,Status, challan_id_purchase,challan_id_sale, oa_subject, oa_case_no, oa_description,type_p,vat_amount,no_of_days,interest_pct,interest_amount,particulars,reason_drcr,ait_pct,ait_amount)\r\n            VALUES (", objMaster.NoteId, ",1, 0, 1, ", str3, ", ", str4, ", ", str5, ", ", str6, ", ", str7, ",", objCD.UserId, ", ", objCD.OA_Amount, ",0, ", objCD.DetailId, ", '", objCD.Status, "',", str8, ",", str9, ",'", objCD.OA_Subject, "', '", objCD.OA_CaseNo, "',\r\n                     '", objCD.OA_CaseDetail, "','", objCD.TypeP, "',", objCD.Vat_Amount, ",", objCD.No_of_Days, ",", objCD.Interest_Pct, ",", objCD.Interest_Amount, ",\r\n                     '", objCD.Particulars, "',", objCD.reason_drcr, ",", objCD.AIT_Pct, ",", objCD.AIT_Amount, ")" };
                arrayLists.Add(string.Concat(objArray));
                object[] oAAmount = new object[] { "update trns_sale_master set rebate_adjust_amount = ", objCD.OA_Amount, ", rebate_adjust_date = to_timestamp('", null, null, null };
                oAAmount[3] = objMaster.DateNote.ToString("MM/dd/yyyy HH:mm");
                oAAmount[4] = "','MM/dd/yyyy HH24:MI') where challan_id = ";
                oAAmount[5] = challanId;
                arrayLists.Add(string.Concat(oAAmount));
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }
    }
}

