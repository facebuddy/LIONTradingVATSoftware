using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class trnsNoteMasterBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public trnsNoteMasterBLL()
        {
        }

        public DataTable getChallanNoDateByChallanId(int ChallanId)
        {
            string str = string.Concat("select challan_no from trns_sale_master where Is_deleted=false and Challan_id='", ChallanId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getChallanNoDateByOrg(int orgId)
        {
            string str = string.Concat("select *, challan_no challanNoDate from trns_purchase_master where Is_deleted=false and challan_type='P' and Organization_id='", orgId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getChallanNoDateByPartyAndOrg(int partyId, int orgId)
        {
            object[] objArray = new object[] { "select *, challan_no||' # '||to_char(date_challan, 'DD-Mon-YY') challanNoDate from trns_sale_master where Is_deleted=false and Party_id='", partyId, "' and Organization_id='", orgId, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public short getNoteId()
        {
            return Convert.ToInt16(this.DBUtil.GetSingleValue("select nextval('note_id_seq'::regclass)"));
        }

        public DataTable getOrgById(int orgId)
        {
            string str = string.Concat("select COALESCE(oa.operation_address,'') AS registered_hq_address from org_registration_info o\r\n        inner join org_reg_address oa on o.organization_id = oa.organization_id\r\n        where o.Organization_id = ", orgId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getOrgData()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select * from org_registration_info where Is_deleted=false AND organization_id=", num);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
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
                object[] objArray = new object[] { " and m.date_note>='", startDate, "' and m.date_note<'", finishDate, "' " };
                str = string.Concat(objArray);
            }
            string str1 = string.Concat("select distinct m.Party_id, tp.party_name from trns_note_master m inner join trns_party tp on tp.Party_id=m.Party_id \r\n        where m.Is_deleted=false ", str);
            return this.DBUtil.GetDataSet(str1, "PartyByDate");
        }

        public DataTable getPartyById(int partyId)
        {
            string str = string.Concat("select * from trns_party where Is_deleted=false and Party_id='", partyId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyData()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("SELECT * from trns_party where separator=1 and Is_deleted = false and (is_vendor=true or (is_vendor=true and is_customer=true)) and  organization_id=", num, " order by party_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyDataByOrg(short orgId)
        {
            string str = string.Concat("select distinct tsm.Party_id, tp.party_name from trns_sale_master tsm inner join trns_party tp on tsm.Party_id=tp.Party_id where tsm.Is_deleted=false and tsm.Organization_id=", orgId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyDataImport()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("SELECT * from trns_party where separator=1 and Is_deleted = false and is_importer=true and  organization_id=", num, " order by party_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPurchasedItemByItemAndChallanNoAndRowNo(int itemId, string ChallanNo, int RowNo)
        {
            object[] challanNo = new object[] { "select i.Item_id,tsd.detail_id, i.Item_id||'.'||tsd.row_no item_id_row, (tsd.row_no||'.'||i.item_name||'- '||i.hs_code) items, iu.unit_name, tsd.unit_id, tsd.Quantity, tsd.actual_price, tsd.row_no, tsd.Sd, tsd.Vat from Item i \r\n        inner join trns_sale_detail tsd on i.Item_id=tsd.Item_id\r\n        inner join item_unit iu on iu.unit_id=tsd.unit_id\r\n        right outer join trns_sale_master tpm on tsd.Challan_id=tpm.Challan_id\r\n        where tpm.challan_no='", ChallanNo, "' and tsd.Item_id='", itemId, "' and tsd.row_no=", RowNo };
            string str = string.Concat(challanNo);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPurchasedItemByPartyAndChallanNo(int PartyId, string ChallanNo)
        {
            object[] challanNo = new object[] { "select i.Item_id, i.Item_id||'.'||tsd.row_no item_id_row, (tsd.row_no||'.'||i.item_name||'- '||i.hs_code) items, iu.unit_name, tsd.unit_id, tsd.Quantity, tsd.actual_price, tsd.row_no from Item i \r\n        inner join trns_sale_detail tsd on i.Item_id=tsd.Item_id\r\n        inner join item_unit iu on iu.unit_id=tsd.unit_id\r\n        right outer join trns_sale_master tpm on tsd.Challan_id=tpm.Challan_id\r\n        where tpm.challan_no='", ChallanNo, "' and tpm.Party_id='", PartyId, "' order by tsd.row_no" };
            string str = string.Concat(challanNo);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getVehicleType()
        {
            return this.DBUtil.GetDataTable("select * from app_code_detail where Is_deleted=false and code_id_m='7'");
        }

        public bool insertNote(ArrayList arrSql)
        {
            return this.DBUtil.ExecuteBatchDML(arrSql);
        }

        public DataSet rptCreditNote(trnsNoteDetaiDAO objtrnsNoteDetaiDAO)
        {
            string str = "";
            string str1 = "";
            if (objtrnsNoteDetaiDAO.PartyId != 0)
            {
                str = string.Concat(" AND m.Party_id=", objtrnsNoteDetaiDAO.PartyId);
            }
            if (objtrnsNoteDetaiDAO.CreditNoteNo != "")
            {
                str1 = string.Concat(" AND m.note_no='", objtrnsNoteDetaiDAO.CreditNoteNo, "'");
            }
            object[] orgName = new object[] { "SELECT '", objtrnsNoteDetaiDAO.OrgName, "' OrgName1, '", objtrnsNoteDetaiDAO.OrgAddress, "' OrgAddress, '", objtrnsNoteDetaiDAO.OrgBIN, "' OrgBIN, '", objtrnsNoteDetaiDAO.OrgTelephone, "' OrgTelephone, '", objtrnsNoteDetaiDAO.OrgFax, "' OrgFax, tp.party_name PartyName, tp.party_address PartyAddress, \r\n        tp.party_tin PartyTIN, acd.code_name Vehicle_Type, m.vehicle_no Vehicle_No, acd.code_name||' '||m.vehicle_no VehicleTypeAndNo, m.note_no Credit_Note_No, m.date_note Credit_Note_Date, d.row_no SlNo_1, tsm.challan_no Challan_Sl_No, \r\n        tsm.date_challan Challan_Date, tsm.challan_no||'\\n'||to_char(tsm.date_challan, 'dd Mon yyyy') Challan_SlAndDate_2, i.item_name||'//'||i.hs_code Name_of_Goods, d.Quantity Quantity_of_Goods, i.item_name||'//'||i.hs_code||'\\n'||d.Quantity Goods_NameAndQty_3, \r\n\t    (d.actual_price*d.Quantity) Total_Price_4, (d.rbt_other_tax*d.Quantity) Rbt_Other_Tax_Amount_5, (d.rbt_vat*d.Quantity) Rbt_VAT_Amount_6, \r\n\t    (d.cln_other_tax*d.Quantity) Cln_Other_Tax_Amount_7, (d.cln_vat*d.Quantity) Cln_VAT_Amount_8, (d.dif_other_tax*d.Quantity) Dif_Other_Tax_Amount_9, \r\n\t    (d.dif_vat*d.Quantity) Dif_VAT_Amount_10, m.reason Remarks\r\n        FROM trns_note_master m LEFT JOIN \r\n        trns_party tp ON m.Party_id=tp.Party_id LEFT JOIN\r\n        app_code_detail acd ON m.vehicle_type_m=acd.code_id_m AND m.vehicle_type_d=acd.code_id_d LEFT JOIN\r\n        trns_note_detail d ON m.note_id=d.note_id LEFT JOIN\r\n        trns_sale_master tsm ON d.Challan_id=tsm.Challan_id LEFT JOIN\r\n        Item i ON d.Item_id=i.Item_id\r\n        where m.Is_deleted=false AND m.note_type='C' AND m.date_note>='", objtrnsNoteDetaiDAO.StartDate, "' AND m.date_note<'", objtrnsNoteDetaiDAO.FinishDate, "' ", str, " ", str1 };
            string str2 = string.Concat(orgName);
            return this.DBUtil.GetDataSet(str2, "Credit_Note_Form_12");
        }

        public DataSet rptCreditNoteSummary(trnsNoteDetaiDAO objtrnsNoteDetaiDAO)
        {
            object[] startDate = new object[] { "SELECT m.note_no Credit_Note_No, tp.party_name Party_Name, sum((d.actual_price+d.rbt_other_tax+d.rbt_vat)*d.Quantity) TotalPrice, sum(d.rbt_other_tax*d.Quantity) Rbt_SD, sum(d.rbt_vat*d.Quantity) Rbt_VAT, sum(d.dif_other_tax*d.Quantity) Dif_SD, sum(d.dif_vat*d.Quantity) Dif_VAT \r\n        FROM trns_note_master m, trns_note_detail d, trns_party tp\r\n        where m.note_id=d.note_id and m.Party_id=tp.Party_id AND m.note_type='C' AND m.date_note>='", objtrnsNoteDetaiDAO.StartDate, "' AND m.date_note<'", objtrnsNoteDetaiDAO.FinishDate, "'\r\n        group by m.note_no, tp.party_name" };
            string str = string.Concat(startDate);
            return this.DBUtil.GetDataSet(str, "CreditNoteSummary");
        }
    }
}