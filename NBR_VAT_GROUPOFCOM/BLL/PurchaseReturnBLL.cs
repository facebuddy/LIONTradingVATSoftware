using System;
using System.Collections;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PurchaseReturnBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private ArrayList arrSQL = new ArrayList();

        public PurchaseReturnBLL()
        {
        }

        private ArrayList AddDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                SaleDetailDAO saleDetailDAO = new SaleDetailDAO();
                saleDetailDAO = (SaleDetailDAO)arrDeailDAO[i];
                ArrayList arrayLists = this.arrSQL;
                object[] challanID = new object[] { "INSERT INTO trns_sale_detail(Challan_id, row_no,lot_no,detail_id, Item_id, unit_id, Quantity, actual_price, \r\n            Sd, Vat,  User_id_insert)\r\n    VALUES (", saleDetailDAO.ChallanID, ", ", saleDetailDAO.RowNo, ",'", saleDetailDAO.LotNo, "','", saleDetailDAO.DetailID, "', ", saleDetailDAO.ItemID, ",  ", saleDetailDAO.UnitID, ", ", saleDetailDAO.Quantity, ",", saleDetailDAO.UnitPriceBDT, ", ", saleDetailDAO.SD, ", ", saleDetailDAO.VAT, ", ", saleDetailDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(challanID));
            }
            return this.arrSQL;
        }

        public DataTable GetAllDataForUpdate(long challan)
        {
            string str = string.Concat("select d.row_no,m.challan_id,m.challan_no, to_char(m.date_challan,'dd/MM/yyyy') as challan_date,m.bl_no,to_char(m.bl_date,'dd/MM/yyyy') as bl_date,\r\n\t\t\tm.port_code, m.port_from, m.port_to,m.lc_no, to_char(m.lc_date,'dd/MM/yyyy') as lc_date,m.lc_amount,m.lc_foreign_amount as lc_value,\r\n\t\t\tm.lc_foreign_currency as lc_currency,m.insurance_no, m.insurance_amount,to_char(m.date_goods_delivery,'dd/MM/yyyy') as delivery_date, \r\n\t\t\tm.release_order_no,to_char(m.release_order_date,'dd/MM/yyyy') as release_order_date,m.country_of_origin, d.detail_id,\r\n\t\t\tto_char(m.tax_payment_date,'dd/MM/yyyy') as tax_payment_date,m.remarks,m.Type,\r\n                        case when m.ultimate_destination is null then 'N/A' else m.ultimate_destination end ultimate_destination,\r\n                        tp.party_id, tp.party_name, tp.party_address, \r\n                        case when tp.party_bin is null then 'N/A' else tp.party_bin end party_bin,\r\n                        i.item_id,i.item_name, iu.unit_id, iu.unit_code,\r\n                        d.Quantity,d.is_source_tax_deduct,d.is_exempted,d.is_rebatable,\r\n                        COALESCE(d.vds_amount,0) as vds_amount,COALESCE(d.purchase_unit_price,0) as purchase_unit_price,\r\n                        COALESCE(d.purchase_vat,0) as purchase_vat,COALESCE(d.purchase_sd,0) as purchase_sd,\r\n                        ((COALESCE(d.Quantity,0)*COALESCE(d.purchase_unit_price,0))-(COALESCE(d.purchase_vat,0)+COALESCE(d.purchase_sd,0))) as vatable_price,\r\n                        COALESCE(d.cd,0) as cd,COALESCE(d.rd,0) as rd,COALESCE(d.ait,0) as ait,COALESCE(d.at,0) as at,\r\n                        COALESCE(d.atv,0) as atv,COALESCE(d.tti,0) as tti,COALESCE(d.document_processing_fee,0) as document_processing_fee,\r\n                        COALESCE(d.psi,0) as psi,COALESCE(d.cnf_vat,0) as cnf_vat,COALESCE(d.cnf_commission,0) as cnf_commission,\r\n                        COALESCE(d.other_cost,0) as other_cost,i.product_type\r\n                        from trns_purchase_master as m\r\n                        left join trns_party as tp\r\n                        on tp.party_id = m.party_id\r\n                        left join trns_purchase_detail as d\r\n                        on m.challan_id = d.challan_id\r\n                        left join item as i\r\n                        on d.item_id = i.item_id\r\n                        left join item_unit as iu\r\n                        on d.unit_id = iu.unit_id\r\n                        where m.challan_id = ", challan, " and m.is_deleted = false order by row_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getAllImportParty()
        {
            return this.DBUtil.GetDataTable("select distinct tp.party_id,tp.party_name\r\n                            from trns_purchase_master as m\r\n                            left join trns_party as tp\r\n                            on m.party_id = tp.party_id\r\n                            where m.purchase_type='I' and m.is_deleted = false order by party_id");
        }

        public DataTable GetAllPurchaseDataByChallan(long challan)
        {
            string str = string.Concat("select d.row_no, to_char(m.date_challan,'dd-MM-yyyy') as challan_date,m.challan_no,d.detail_id,m.challan_id, \r\n                        case when m.ultimate_destination is null then 'N/A' else m.ultimate_destination end ultimate_destination, \r\n                        tp.party_id, tp.party_name, tp.party_address, \r\n                        case when tp.party_bin is null then 'N/A' else tp.party_bin end party_bin,\r\n                        m.transaction_type, m.purchase_type, m.Type, m.scroll_no,\r\n                        i.item_id,i.item_name, iu.unit_id, iu.unit_code,\r\n                        d.Quantity,d.is_source_tax_deduct,d.is_exempted,d.is_rebatable,\r\n                        COALESCE(d.vds_amount,0) as vds_amount,\r\n                        COALESCE(d.purchase_unit_price,0) as purchase_unit_price,\r\n                        COALESCE(d.purchase_vat,0) as purchase_vat,\r\n                        COALESCE(d.purchase_sd,0) as purchase_sd,\r\n                        ((COALESCE(d.Quantity,0)*COALESCE(d.purchase_unit_price,0))-(COALESCE(d.purchase_vat,0)+COALESCE(d.purchase_sd,0))) as price,\r\n                        m.vehicle_type_d, m.vehicle_no,\r\n                        COALESCE(d.sale_unit_price,0) as sale_unit_price,\r\n                        COALESCE(d.sale_vatable_price,0) as sale_vatable_price,\r\n                        COALESCE(d.sale_vat,0) as sale_vat,\r\n                        COALESCE(d.sale_sd,0) as sale_sd,i.product_type\r\n                        from trns_purchase_master as m\r\n                        left join trns_party as tp\r\n                        on tp.party_id = m.party_id\r\n                        left join trns_purchase_detail as d\r\n                        on m.challan_id = d.challan_id\r\n                        left join item as i\r\n                        on d.item_id = i.item_id\r\n                        left join item_unit as iu\r\n                        on d.unit_id = iu.unit_id\r\n                        where m.challan_id = ", challan, " and m.is_deleted = false order by row_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllSaleDataByChallan(long challan)
        {
            string str = string.Concat("select d.row_no, to_char(m.date_challan,'dd-MM-yyyy') as challan_date,m.challan_no,d.detail_id,m.challan_id, \r\n                        case when m.ultimate_destination is null then 'N/A' else m.ultimate_destination end ultimate_destination, \r\n                        tp.party_id, tp.party_name, tp.party_address, \r\n                        case when tp.party_bin is null then 'N/A' else tp.party_bin end party_bin,\r\n                        m.sale_type, m.trans_type, m.Type,\r\n                        i.item_id,i.item_name, iu.unit_id, iu.unit_code,\r\n                        d.Quantity,d.is_source_tax_deduct,d.is_exempted,d.is_rebatable,\r\n                        COALESCE(d.vds_amount,0) as vds_amount,\r\n                        COALESCE(d.actual_price,0) as unit_price,\r\n                        COALESCE(d.vat,0) as vat,\r\n                        COALESCE(d.sd,0) as sd,\r\n                        ((COALESCE(d.Quantity,0)*COALESCE(d.actual_price,0))-(COALESCE(d.vat,0)+COALESCE(d.sd,0))) as price,\r\n                        m.vehicle_type_d, m.vehicle_no,\r\n                        i.product_type,m.Remarks\r\n                        from trns_sale_master as m\r\n                        left join trns_party as tp\r\n                        on tp.party_id = m.party_id\r\n                        left join trns_sale_detail as d\r\n                        on m.challan_id = d.challan_id\r\n                        left join item as i\r\n                        on d.item_id = i.item_id\r\n                        left join item_unit as iu\r\n                        on d.unit_id = iu.unit_id\r\n                        where m.challan_id = ", challan, " and m.is_deleted = false order by row_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchDetail(int orgID)
        {
            string str = string.Concat("SELECT o.org_branch_reg_id, o.branch_unit_bin, o.branch_unit_name,\r\n                              ad.holding ||','||ad.road_no ||','|| ad.road ||','|| ad.block_area ||','|| p.police_station_name ||','|| u.upazila_name ||','|| d.district_name ||'-'|| ad.post_code_id as address\r\n                         FROM org_branch_reg_info as o\r\n                         left join all_address as ad\r\n                         on o.org_branch_reg_id = ad.org_branch_reg_id\r\n                         left join set_police_station as p\r\n                         on p.police_station_id = ad.thana_id\r\n                         left join set_upazila as u\r\n                         on u.upazila_id = ad.upazila_id\r\n                         left join set_district as d\r\n                         on d.district_id = ad.district_id\r\n                      where o.organization_id = ", orgID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getChallan(int intSalePartyId)
        {
            string str = string.Concat("select Challan_id, challan_no||' # '||to_char(date_challan, 'DD-Mon-YY') challanNoDate \r\nfrom trns_purchase_master where Is_deleted=false and Party_id='", intSalePartyId, "'");
            return this.DBUtil.GetDataSet(str, "PurchaseReturn");
        }

        public DataTable GetImportChallanNo(string fDate, string tDate, int partyID)
        {
            string str = "";
            if (partyID != 0)
            {
                str = string.Concat(" AND m.party_id = ", partyID, " ");
            }
            string[] strArrays = new string[] { "select m.challan_id, m.challan_no,m.date_insert\r\n                            from trns_purchase_master as m\r\n                            where m.date_insert >='", fDate, "' AND m.date_insert <='", tDate, "' ", str, " AND m.purchase_type='I' AND m.is_deleted = false order by date_insert" };
            string str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataSet getItem(int intChallanId)
        {
            object[] objArray = new object[] { "select row_no, Challan_id,detail_id,item_name,Quantity,actual_price,Sd,Vat,total_price, \r\nsum(purchase_qty)purchase_qty,case when sum(sale_qty) isnull then 0 else sum(sale_qty) end sale_qty,\r\nsum(purchase_qty)- case when sum(sale_qty) isnull or sum(sale_qty)=0 then 0 else sum(sale_qty) end stock_qty, Item_id, lot_no,unit_id  from\r\n(\r\n\r\nselect pd.row_no, pd.Challan_id,pd.detail_id,i.item_name,pd.Quantity,pd.actual_price,pd.Sd,pd.Vat,pd.total_price, \r\nsum(pd.Quantity)purchase_qty,0 sale_qty,\r\npd.Item_id, pd.lot_no,pd.unit_id \r\nfrom trns_purchase_detail pd \r\ninner join Item i on pd.Item_id=i.Item_id \r\nwhere pd.Challan_id='", intChallanId, "' and pd.Is_deleted=false\r\ngroup by pd.row_no, pd.Challan_id,pd.detail_id, pd.Item_id,i.item_name,pd.Quantity,pd.actual_price,pd.Sd,pd.Vat,pd.total_price, pd.Item_id, pd.lot_no,pd.unit_id\r\n\r\nunion all\r\n\r\nselect pd.row_no, pd.Challan_id,pd.detail_id,i.item_name,pd.Quantity,pd.actual_price,pd.Sd,pd.Vat,pd.total_price, \r\n0 purchase_qty,case when sum(Sd.Quantity) isnull then 0 else sum(Sd.Quantity) end sale_qty,\r\n pd.Item_id, pd.lot_no,pd.unit_id \r\nfrom trns_purchase_detail pd \r\ninner join Item i on pd.Item_id=i.Item_id \r\nleft outer join trns_sale_detail Sd on pd.detail_id=Sd.detail_id\r\nwhere pd.Challan_id='", intChallanId, "' and pd.Is_deleted=false\r\ngroup by pd.row_no, pd.Challan_id,pd.detail_id, pd.Item_id,i.item_name,pd.Quantity,pd.actual_price,pd.Sd,pd.Vat,pd.total_price, pd.Item_id, pd.lot_no,pd.unit_id\r\n\r\n) purchaseReturn group by row_no, Challan_id,detail_id,item_name,Quantity,actual_price,Sd,Vat,total_price, Item_id, lot_no,unit_id order by row_no" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataSet(str, "PurchaseReturn");
        }

        public DataTable getItem()
        {
            return this.DBUtil.GetDataTable("SELECT DISTINCT I.ITEM_ID, I.PRODUCT_TYPE, CASE coalesce(I.ITEM_SPECIFICATION,'null') WHEN 'null' THEN I.ITEM_NAME \r\n            WHEN '' THEN I.ITEM_NAME||'-'||i.hs_code ELSE (I.ITEM_NAME||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code) END ITEM_NAME\r\n            FROM ITEM I \r\n            LEFT OUTER JOIN ITEM_CATEGORY CT \r\n            ON I.SUB_CATEGORY_ID = CT.CATEGORY_ID\r\n            WHERE I.IS_DELETED = false ORDER BY ITEM_NAME");
        }

        public DataTable getItemTax(int itemID)
        {
            object[] objArray = new object[] { "  select item_name,   max(cd) CD,   max(rd) RD,  max(sd) SD, max(vat)  VAT,  max(ait) AIT, max(at) AT_  \r\n\tfrom(\r\n            select i.item_name,itv.tax_value as CD, 0 as RD, 0 as SD, 0 as VAT, 0 as AIT, 0 as  AT\r\n            from item as i\r\n            left outer join item_tax_values as itv\r\n            on i.item_id = itv.item_id and tax_id = 1\r\n            where i.Is_deleted=false AND i.item_id = ", itemID, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, itv.tax_value as RD, 0 as SD, 0 as VAT, 0 as AIT, 0 as  AT\r\n            from item as i\r\n            left outer join item_tax_values as itv\r\n            on i.item_id = itv.item_id and tax_id = 2\r\n            where i.Is_deleted=false AND i.item_id =  ", itemID, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, itv.tax_value as SD, 0 as VAT, 0 as AIT, 0 as  AT\r\n            from item as i\r\n            left outer join item_tax_values as itv\r\n            on i.item_id = itv.item_id and tax_id = 3\r\n            where i.Is_deleted=false AND i.item_id =  ", itemID, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, itv.tax_value as VAT, 0 as AIT, 0 as  AT\r\n            from item as i\r\n            left outer join item_tax_values as itv\r\n            on i.item_id = itv.item_id and tax_id = 4\r\n            where i.Is_deleted=false AND i.item_id =  ", itemID, "\r\n\r\n            union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, 0 as VAT, itv.tax_value as AIT, 0 as  AT\r\n            from item as i\r\n            left outer join item_tax_values as itv\r\n            on i.item_id = itv.item_id and tax_id = 5\r\n           where i.Is_deleted=false AND i.item_id =  ", itemID, "\r\n\r\n           union all\r\n\r\n            select i.item_name, 0 as CD, 0 as RD, 0 as SD, 0 as VAT, 0 as AIT, itv.tax_value as  AT\r\n            from item as i\r\n            left outer join item_tax_values as itv\r\n            on i.item_id = itv.item_id and tax_id = 8\r\n\t    where i.Is_deleted=false AND i.item_id =  ", itemID, "\r\n\r\n            ) item_tax_values group by item_name" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyInfo(int intPartyId)
        {
            string str = string.Concat("select party_tin, party_address from trns_party where Party_id='", intPartyId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseChallanNo(string fDate, string tDate, int partyID)
        {
            string str = "";
            if (partyID != 0)
            {
                str = string.Concat(" AND m.party_id = ", partyID, " ");
            }
            string[] strArrays = new string[] { "select m.challan_id, m.challan_no,m.date_insert\r\n                            from trns_purchase_master as m\r\n                            where m.date_insert >='", fDate, "' AND m.date_insert <='", tDate, "' ", str, " AND m.is_deleted = false order by date_insert" };
            string str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetPurchaseParty()
        {
            return this.DBUtil.GetDataTable("select distinct tp.party_id,tp.party_name\r\n                            from trns_purchase_master as m\r\n                            left join trns_party as tp\r\n                            on m.party_id = tp.party_id\r\n                            where m.is_deleted = false order by party_id");
        }

        public DataTable GetPurchasePartyBIN(string fDate, string tDate)
        {
            string[] strArrays = new string[] { "select distinct tp.party_id,tp.party_bin\r\n                                from trns_purchase_master as m\r\n                                left join trns_party as tp\r\n                                on m.party_id = tp.party_id\r\n                            where m.date_insert >='", fDate, "' AND m.date_insert <='", tDate, "' AND m.is_deleted = false order by party_id" };
            string str = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getPurchaseReturnOrg()
        {
            return this.DBUtil.GetDataSet("select distinct pm.Organization_id,ori.organization_name from  trns_purchase_master  pm \r\ninner join org_registration_info ori on pm.Organization_id=ori.Organization_id and ori.Is_deleted=false\r\norder by ori.organization_name", "PurchaseReturn");
        }

        public DataTable GetSaleChallanNo(string fDate, string tDate, int partyID)
        {
            string str = "";
            if (partyID != 0)
            {
                str = string.Concat(" AND m.party_id = ", partyID, " ");
            }
            string[] strArrays = new string[] { "select m.challan_id, m.challan_no,m.date_insert\r\n                            from trns_sale_master as m\r\n                            where m.date_insert >='", fDate, "' AND m.date_insert <='", tDate, "' ", str, " AND m.is_deleted = false order by date_insert" };
            string str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetSaleParty()
        {
            return this.DBUtil.GetDataTable("select distinct tp.party_id,tp.party_name\r\n                            from trns_sale_master as m\r\n                            left join trns_party as tp\r\n                            on m.party_id = tp.party_id\r\n                            where m.is_deleted = false order by party_id");
        }

        public DataSet getSalePartyNameByOrg(int intOrgId)
        {
            string str = string.Concat("select distinct pm.Party_id,tp.party_name from trns_purchase_master pm inner join\r\ntrns_party tp on pm.Party_id=tp.Party_id and tp.Is_deleted=false \r\nwhere  pm.Organization_id='", intOrgId, "' order by tp.party_name");
            return this.DBUtil.GetDataSet(str, "PurchaseReturn");
        }

        public bool InsertPurchaseReturnData(SaleMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            DBUtility dBUtil = this.DBUtil;
            object[] year = new object[] { "SELECT coalesce(max(cg_challan_no),0)+1 from trns_sale_master group by challan_year, challan_type having challan_year = ", null, null, null, null };
            year[1] = objMDAO.ChallanDate.Year;
            year[2] = " and challan_type = '";
            year[3] = objMDAO.ChallanType;
            year[4] = "'";
            objMDAO.ComGenChallanNo = Convert.ToInt16(dBUtil.GetSingleValue(string.Concat(year)));
            ArrayList arrayLists = this.arrSQL;
            object[] challanID = new object[] { "INSERT INTO trns_sale_master(Challan_id,challan_no,cg_challan_no,Organization_id, challan_type, sale_type, trans_type, date_challan, \r\nUser_id_insert,Remarks,purchase_challan_id,challan_year)\r\n    VALUES ( ", objMDAO.ChallanID, ",'", objMDAO.ChallanNo, "',", objMDAO.ComGenChallanNo, ",", objMDAO.OrganizatioID, ",'", objMDAO.ChallanType, "','", objMDAO.SaleType, "', '", objMDAO.TransactionType, "',to_timestamp('", null, null, null, null, null, null, null, null, null, null };
            challanID[15] = objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm");
            challanID[16] = "','MM/dd/yyyy HH24:MI'),";
            challanID[17] = objMDAO.UserIdInsert;
            challanID[18] = ",'";
            challanID[19] = objMDAO.Remarks;
            challanID[20] = "','";
            challanID[21] = objMDAO.PurchaseChallanId;
            challanID[22] = "','";
            challanID[23] = objMDAO.ChallanDate.Year;
            challanID[24] = "')";
            arrayLists.Add(string.Concat(challanID));
            this.arrSQL = this.AddDeailInsertSQL(this.arrSQL, arrDeailDAO);
            DataTable dataTable = new DataTable();
            return this.DBUtil.ExecuteBatchDML(this.arrSQL);
        }

        public int intSaleChallanId()
        {
            return Convert.ToInt32(this.DBUtil.GetSingleValue("select nextval('sale_challan_id_seq')"));
        }

        public bool updateBillofEntryHistory(BillOfEntryMaster objMaster, BillOfEntryDetail objDetail)
        {
            ArrayList arrayLists = new ArrayList();
            if (objMaster.IsNewParty)
            {
                objMaster.PartyID = Convert.ToInt16(this.DBUtil.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMaster.PartyID, ", upper('", objMaster.PartyName, "'),'", objMaster.PartyAddress, "','", objMaster.UltimateDestination, "',", objMaster.UserID, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            object[] objArray = new object[] { "update trns_purchase_master set party_id = ", objMaster.PartyID, ", date_challan=to_timestamp('", objMaster.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                            ultimate_destination ='", objMaster.UltimateDestination, "', user_id_insert=", objMaster.UserID, ",\r\n                            challan_no = '", objMaster.ChallanNO, "', Type = '", objMaster.Type, "', date_update=to_timestamp('", objMaster.UpdateDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                            date_goods_delivery = to_timestamp('", objMaster.Deliverydate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),insurance_no='", objMaster.InsuranceNO, "',\r\n                            lc_no = '", objMaster.LCNo, "',lc_date = to_timestamp('", objMaster.LCDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),lc_amount=", objMaster.LCAmount, ",\r\n                            bl_no = '", objMaster.BLNo, "',bl_date = to_timestamp('", objMaster.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),port_code=", objMaster.PortCode, ",\r\n                            port_from = '", objMaster.PortFrom, "', port_to = '", objMaster.PortTo, "',lc_foreign_amount = ", objMaster.LCValue, ",insurance_amount = ", objMaster.InsuranceAmount, ",\r\n                            lc_foreign_currency = ", objMaster.LCCurrency, ",remarks = '", objMaster.Remarks, "',release_order_no = '", objMaster.ReleaseOrderNo, "',\r\n                            release_order_date = to_timestamp('", objMaster.ReleaseOrderDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),country_of_origin = ", objMaster.SupplierCountry, ",\r\n                            tax_payment_date = to_timestamp('", objMaster.TaxPaymentDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI')\r\n                            where challan_id = ", objMaster.ChallanID, "  " };
            string str = string.Concat(objArray);
            object[] itemID = new object[] { "update trns_purchase_detail set item_id = ", objDetail.ItemID, ", unit_id=", objDetail.UnitID, ", \r\n                            quantity = ", objDetail.Quantity, ", purchase_unit_price =", objDetail.UnitPrice, ", purchase_vat = ", objDetail.VAT, ",\r\n                            user_id_insert=", objDetail.UserID, ", date_update=to_timestamp('", objDetail.UpdateDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), \r\n                            cd = ", objDetail.CD, ", rd = ", objDetail.RD, ", ait = ", objDetail.AIT, ", atv = ", objDetail.ATV, ", tti = ", objDetail.TTI, ", at = ", objDetail.AT, ",\r\n                            other_cost = ", objDetail.OtherCost, ", document_processing_fee = ", objDetail.DocumentPF, ", psi = ", objDetail.PSI, ", cnf_vat = ", objDetail.CNFVat, ",\r\n                            cnf_commission = ", objDetail.CNFCommission, ", vds_amount = ", objDetail.VDSAmount, ",warranty = ", objDetail.IsWarStr, " \r\n                            purchase_sd = ", objDetail.SD, ", total_price = ", objDetail.VatablePrice, " \r\n                            where challan_id = ", objDetail.ChallanID, " AND row_no = ", objDetail.RowNo, " AND detail_id = ", objDetail.DetailID, " " };
            string str1 = string.Concat(itemID);
            arrayLists.Add(str);
            arrayLists.Add(str1);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool updatePurchaseHistory(PurchaseEditMaster objMaster, PurchaseEdit objDetail)
        {
            ArrayList arrayLists = new ArrayList();
            string str = " NULL ";
            string str1 = " NULL ";
            if (objMaster.VehicleIDD != -99)
            {
                str = Convert.ToString(objMaster.VehicleIDM);
                str1 = Convert.ToString(objMaster.VehicleIDD);
            }
            if (objMaster.IsNewParty)
            {
                objMaster.PartyID = Convert.ToInt16(this.DBUtil.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMaster.PartyID, ", upper('", objMaster.PartyName, "'),'", objMaster.PartyBIN, "','", objMaster.PartyAddress, "','", objMaster.UltimateDestination, "',", objMaster.UserID, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            object[] objArray = new object[] { "update trns_purchase_master set party_id = ", objMaster.PartyID, ", purchase_type='", objMaster.PurchaseType, "', \r\n                            date_challan=to_timestamp('", objMaster.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                            ultimate_destination ='", objMaster.UltimateDestination, "', vehicle_type_m = ", str, ",\r\n                            vehicle_type_d = ", str1, ", vehicle_no = '", objMaster.VehecalNo, "', user_id_insert=", objMaster.UserID, ",\r\n                            challan_no = '", objMaster.ChallanNO, "', Type = '", objMaster.Type, "', transaction_type = '", objMaster.TrnsType, "',\r\n                            scroll_no = '", objMaster.ReceiveScrollNo, "', date_update=to_timestamp('", objMaster.UpdateDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI')\r\n                            where challan_id = ", objMaster.ChallanID, "  " };
            string str2 = string.Concat(objArray);
            object[] itemID = new object[] { "update trns_purchase_detail set item_id = ", objDetail.ItemID, ", unit_id=", objDetail.UnitID, ", \r\n                            quantity = ", objDetail.Quantity, ", purchase_unit_price =", objDetail.PUnitPrice, ", purchase_vat = ", objDetail.PVat, ",\r\n                            user_id_insert=", objDetail.UserID, ", date_update=to_timestamp('", objDetail.UpdateDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                            purchase_sd = ", objDetail.PSD, ", sale_unit_price = ", objDetail.SUnitPrice, ", sale_vatable_price = ", objDetail.SVatablePrice, ",\r\n                            sale_vat = ", objDetail.SVat, ", sale_sd = ", objDetail.SSD, ", total_price = ", objDetail.PVatablePrice, " \r\n                            where challan_id = ", objDetail.ChallanID, " AND row_no = ", objDetail.RowNo, " AND detail_id = ", objDetail.DetailID, " " };
            string str3 = string.Concat(itemID);
            arrayLists.Add(str2);
            arrayLists.Add(str3);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool updateSaleHistory(SaleEditMaster objMaster, SaleEdit objDetail)
        {
            ArrayList arrayLists = new ArrayList();
            string str = " NULL ";
            string str1 = " NULL ";
            if (objMaster.VehicleIDD != -99)
            {
                str = Convert.ToString(objMaster.VehicleIDM);
                str1 = Convert.ToString(objMaster.VehicleIDD);
            }
            if (objMaster.IsNewParty)
            {
                objMaster.PartyID = Convert.ToInt16(this.DBUtil.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMaster.PartyID, ", upper('", objMaster.PartyName, "'),'", objMaster.PartyBIN, "','", objMaster.PartyAddress, "','", objMaster.UltimateDestination, "',", objMaster.UserID, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            object[] objArray = new object[] { "update trns_sale_master set party_id = ", objMaster.PartyID, ", sale_type='", objMaster.SaleType, "', \r\n                            date_challan=to_timestamp('", objMaster.DateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                            ultimate_destination ='", objMaster.UltimateDestination, "', vehicle_type_m = ", str, ",remarks='", objMaster.Remarks, "',\r\n                            vehicle_type_d = ", str1, ", vehicle_no = '", objMaster.VehecalNo, "', user_id_insert=", objMaster.UserID, ",\r\n                            challan_no = '", objMaster.ChallanNO, "', Type = '", objMaster.Type, "', trans_type = '", objMaster.TrnsType, "',\r\n                            date_update=to_timestamp('", objMaster.UpdateDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI')\r\n                            where challan_id = ", objMaster.ChallanID, "  " };
            string str2 = string.Concat(objArray);
            object[] itemID = new object[] { "update trns_sale_detail set item_id = ", objDetail.ItemID, ", unit_id=", objDetail.UnitID, ", quantity = ", objDetail.Quantity, ",\r\n                            user_id_insert=", objDetail.UserID, ", date_update=to_timestamp('", objDetail.UpdateDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                            actual_price = ", objDetail.SUnitPrice, ", vat = ", objDetail.SVat, ", sd = ", objDetail.SSD, "\r\n                            where challan_id = ", objDetail.ChallanID, " AND row_no = ", objDetail.RowNo, " AND detail_id = ", objDetail.DetailID, " " };
            string str3 = string.Concat(itemID);
            arrayLists.Add(str2);
            arrayLists.Add(str3);
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }
    }
}
