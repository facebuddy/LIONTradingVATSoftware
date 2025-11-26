using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SaleBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public SaleBLL()
        {
        }

        private ArrayList AddDeailExcelData(ArrayList arrDetailList, SaleDetailDAON objDetail, int ChallanID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            str = " NULL";
            str1 = " NULL";
            str2 = " NULL";
            str3 = " NULL";
            str4 = " NULL";
            string str8 = "";
            str8 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_sale_detail WHERE ITEM_ID = '", objDetail.ItemID, "' ");
            if (objDetail.PropertyID1 != 0)
            {
                str = objDetail.PropertyID1.ToString();
                object obj = str8;
                object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", objDetail.PropertyID1, "' " };
                str8 = string.Concat(propertyID1);
            }
            if (objDetail.PropertyID2 != 0)
            {
                str1 = objDetail.PropertyID2.ToString();
                object obj1 = str8;
                object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", objDetail.PropertyID2, "' " };
                str8 = string.Concat(propertyID2);
            }
            if (objDetail.PropertyID3 != 0)
            {
                str2 = objDetail.PropertyID3.ToString();
                object obj2 = str8;
                object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", objDetail.PropertyID3, "' " };
                str8 = string.Concat(propertyID3);
            }
            if (objDetail.PropertyID4 != 0)
            {
                str3 = objDetail.PropertyID4.ToString();
                object obj3 = str8;
                object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", objDetail.PropertyID4, "' " };
                str8 = string.Concat(propertyID4);
            }
            if (objDetail.PropertyID5 != 0)
            {
                str4 = objDetail.PropertyID5.ToString();
                object obj4 = str8;
                object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", objDetail.PropertyID5, "' " };
                str8 = string.Concat(propertyID5);
            }
            str8 = string.Concat(str8, " ) ");
            if (objDetail.PriceId > 0)
            {
                objDetail.PriceId.ToString();
            }
            str5 = (objDetail.DetailID <= 0 ? "-99" : objDetail.DetailID.ToString());
            if (objDetail.itemSerials != "" && objDetail.itemSerials != null)
            {
                str6 = ", item_serials";
                str7 = string.Concat(",'", objDetail.itemSerials, "'");
            }
            object[] challanID = new object[] { "INSERT INTO trns_sale_detail(\r\n            Challan_id, row_no, Item_id", str6, ", property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, actual_price, \r\n            Sd, Vat,  User_id_insert, is_source_tax_deduct, lot_no, detail_id,\r\n            nbr_confirm_price,is_exempted,is_rebatable, sale_row_no,is_zero_rate,is_inexplicit_export,real_property,type_p,vat_rate,sd_rate,is_fixed_vat,is_truncated,is_mrp,discount_amt,discount_pct,net_bill,remarks,ait,property_quantity,sale_quantity,sale_unit,health_surcharge)\r\n            VALUES (", ChallanID, ", ", objDetail.RowNo, ", ", objDetail.ItemID, str7, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", objDetail.UnitID, ", ", objDetail.Quantity, ", ", objDetail.Unit_Price, ", ", objDetail.SD_Amount, ", ", objDetail.VAT_Amount, ", ", objDetail.UserIdInsert, ", \r\n              ", objDetail.IsSrcTAXDeduct, ", ", str8, ", '", str5, "',  ", objDetail.NBRPrice, ", ", objDetail.IsExempted, ", ", objDetail.IsRebatable, ", ", objDetail.SaleRowNo, ",", objDetail.IsZeroRate, ",", objDetail.isInexplicitExport, ",'0','", objDetail.TypeP, "',", objDetail.VAT_Rate, ",", objDetail.SD_Rate, ",", objDetail.IsFixed, ",", objDetail.IsTruncated, ",", objDetail.IsMrp, ",", objDetail.Discount, ",", objDetail.Discount_pct, ",", objDetail.Net_bill, ",'", objDetail.RemarksDetail, "',", objDetail.AIT, ",", objDetail.PropStk, ",", objDetail.Quantity, ",", objDetail.SaleUnitID, ",", objDetail.HealthCharge, " )" };
            arrDetailList.Add(string.Concat(challanID));
            return arrDetailList;
        }

        private ArrayList AddDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                str5 = " NULL";
                string str7 = "";
                SaleDetailDAO saleDetailDAO = new SaleDetailDAO();
                saleDetailDAO = (SaleDetailDAO)arrDeailDAO[i];
                str7 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_sale_detail WHERE ITEM_ID = '", saleDetailDAO.ItemID, "' ");
                if (saleDetailDAO.PropertyID1 != 0)
                {
                    str = saleDetailDAO.PropertyID1.ToString();
                    object obj = str7;
                    object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", saleDetailDAO.PropertyID1, "' " };
                    str7 = string.Concat(propertyID1);
                }
                if (saleDetailDAO.PropertyID2 != 0)
                {
                    str1 = saleDetailDAO.PropertyID2.ToString();
                    object obj1 = str7;
                    object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", saleDetailDAO.PropertyID2, "' " };
                    str7 = string.Concat(propertyID2);
                }
                if (saleDetailDAO.PropertyID3 != 0)
                {
                    str2 = saleDetailDAO.PropertyID3.ToString();
                    object obj2 = str7;
                    object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", saleDetailDAO.PropertyID3, "' " };
                    str7 = string.Concat(propertyID3);
                }
                if (saleDetailDAO.PropertyID4 != 0)
                {
                    str3 = saleDetailDAO.PropertyID4.ToString();
                    object obj3 = str7;
                    object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", saleDetailDAO.PropertyID4, "' " };
                    str7 = string.Concat(propertyID4);
                }
                if (saleDetailDAO.PropertyID5 != 0)
                {
                    str4 = saleDetailDAO.PropertyID5.ToString();
                    object obj4 = str7;
                    object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", saleDetailDAO.PropertyID5, "' " };
                    str7 = string.Concat(propertyID5);
                }
                str7 = string.Concat(str7, " ) ");
                if (saleDetailDAO.PriceId > 0)
                {
                    str5 = saleDetailDAO.PriceId.ToString();
                }
                str6 = (saleDetailDAO.DetailID <= 0 ? " NULL " : saleDetailDAO.DetailID.ToString());
                object[] challanID = new object[] { "INSERT INTO trns_sale_detail(\r\n            Challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, actual_price, \r\n            Sd, Vat,  User_id_insert, is_source_tax_deduct, lot_no, detail_id, price_id, \r\n            nbr_confirm_price,is_exempted,is_rebatable, sale_row_no,is_zero_rate,is_inexplicit_export,real_property,type_p,vat_rate,is_fixed_vat,is_truncated,is_mrp,discount_amt,discount_pct,net_bill,remarks,ait)\r\n            VALUES (", ChallanID, ", ", saleDetailDAO.RowNo, ", ", saleDetailDAO.ItemID, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", saleDetailDAO.UnitID, ", ", saleDetailDAO.Quantity, ", ", saleDetailDAO.UnitPriceBDT, ", ", saleDetailDAO.SD, ", ", saleDetailDAO.VAT, ", ", saleDetailDAO.UserIdInsert, ", \r\n              ", saleDetailDAO.IsSrcTAXDeduct, ", ", str7, ", ", str6, ", ", str5, ", ", saleDetailDAO.NBRPrice, ", ", saleDetailDAO.IsExempted, ", ", saleDetailDAO.IsRebatable, ", ", saleDetailDAO.SaleRowNo, ",", saleDetailDAO.IsZeroRate, ",", saleDetailDAO.isInexplicitExport, ",'", saleDetailDAO.RealProperty, "','", saleDetailDAO.TypeP, "',", saleDetailDAO.VATRate, ",", saleDetailDAO.IsFixed, ",", saleDetailDAO.IsTruncated, ",", saleDetailDAO.IsMrp, ",", saleDetailDAO.Discount, ",", saleDetailDAO.Discount_pct, ",", saleDetailDAO.Net_bill, ",'", saleDetailDAO.RemarksDetail, "',", saleDetailDAO.AIT, " )" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        private ArrayList AddDeailInsertSQLN(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID)
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
                str5 = " NULL";
                string str9 = "";
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                saleDetailDAON = (SaleDetailDAON)arrDeailDAO[i];
                str9 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_sale_detail WHERE ITEM_ID = '", saleDetailDAON.ItemID, "' ");
                if (saleDetailDAON.PropertyID1 != 0)
                {
                    str = saleDetailDAON.PropertyID1.ToString();
                    object obj = str9;
                    object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", saleDetailDAON.PropertyID1, "' " };
                    str9 = string.Concat(propertyID1);
                }
                if (saleDetailDAON.PropertyID2 != 0)
                {
                    str1 = saleDetailDAON.PropertyID2.ToString();
                    object obj1 = str9;
                    object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", saleDetailDAON.PropertyID2, "' " };
                    str9 = string.Concat(propertyID2);
                }
                if (saleDetailDAON.PropertyID3 != 0)
                {
                    str2 = saleDetailDAON.PropertyID3.ToString();
                    object obj2 = str9;
                    object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", saleDetailDAON.PropertyID3, "' " };
                    str9 = string.Concat(propertyID3);
                }
                if (saleDetailDAON.PropertyID4 != 0)
                {
                    str3 = saleDetailDAON.PropertyID4.ToString();
                    object obj3 = str9;
                    object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", saleDetailDAON.PropertyID4, "' " };
                    str9 = string.Concat(propertyID4);
                }
                if (saleDetailDAON.PropertyID5 != 0)
                {
                    str4 = saleDetailDAON.PropertyID5.ToString();
                    object obj4 = str9;
                    object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", saleDetailDAON.PropertyID5, "' " };
                    str9 = string.Concat(propertyID5);
                }
                str9 = string.Concat(str9, " ) ");
                if (saleDetailDAON.PriceId > 0)
                {
                    str5 = saleDetailDAON.PriceId.ToString();
                }
                str6 = (saleDetailDAON.DetailID <= 0 ? " NULL " : saleDetailDAON.DetailID.ToString());
                if (saleDetailDAON.itemSerials != "" && saleDetailDAON.itemSerials != null)
                {
                    str7 = ", item_serials";
                    str8 = string.Concat(",'", saleDetailDAON.itemSerials, "'");
                }
                object[] challanID = new object[] { "INSERT INTO trns_sale_detail(\r\n            Challan_id, row_no, Item_id", str7, ", property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, actual_price, \r\n            Sd, Vat,  User_id_insert, is_source_tax_deduct, lot_no, detail_id, price_id, \r\n            nbr_confirm_price,is_exempted,is_rebatable, sale_row_no,is_zero_rate,is_inexplicit_export,real_property,type_p,vat_rate,sd_rate,is_fixed_vat,is_truncated,is_mrp,discount_amt,discount_pct,net_bill,remarks,ait,property_quantity,sale_quantity,sale_unit,health_surcharge,installment_status,approver_stage,additional_property)\r\n            VALUES (", ChallanID, ", ", saleDetailDAON.RowNo, ", ", saleDetailDAON.ItemID, str8, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", saleDetailDAON.UnitID, ", ", saleDetailDAON.Quantity, ", ", saleDetailDAON.UnitPriceBDT, ", ", saleDetailDAON.SD, ", ", saleDetailDAON.VAT, ", ", saleDetailDAON.UserIdInsert, ", \r\n              ", saleDetailDAON.IsSrcTAXDeduct, ", ", str9, ", ", str6, ", ", str5, ", ", saleDetailDAON.NBRPrice, ", ", saleDetailDAON.IsExempted, ", ", saleDetailDAON.IsRebatable, ", ", saleDetailDAON.SaleRowNo, ",", saleDetailDAON.IsZeroRate, ",", saleDetailDAON.isInexplicitExport, ",'", saleDetailDAON.RealProperty, "','", saleDetailDAON.TypeP, "',", saleDetailDAON.VATRate, ",", saleDetailDAON.SDRate, ",", saleDetailDAON.IsFixed, ",", saleDetailDAON.IsTruncated, ",", saleDetailDAON.IsMrp, ",", saleDetailDAON.Discount, ",", saleDetailDAON.Discount_pct, ",", saleDetailDAON.Net_bill, ",'", saleDetailDAON.RemarksDetail, "',", saleDetailDAON.AIT, ",", saleDetailDAON.PropStk, ",", saleDetailDAON.SaleQuantity, ",", saleDetailDAON.SaleUnitID, ",", saleDetailDAON.HealthCharge, ",", saleDetailDAON.installmentStatus, ",'", saleDetailDAON.ApproveStage, "' ,'", saleDetailDAON.addtnProperty, "' )" };
                arrDetailList.Add(string.Concat(challanID));
                if (saleDetailDAON.scheduleId != 0)
                {
                    arrDetailList.Add(string.Concat("update installment_scheduler set is_paid=true where scheduler_id=", saleDetailDAON.scheduleId));
                }
            }
            return arrDetailList;
        }

        private ArrayList AddGiftDetailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID, DateTime dateChallan)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                SaleGiftDetailDAON saleGiftDetailDAON = new SaleGiftDetailDAON();
                saleGiftDetailDAON = (SaleGiftDetailDAON)arrDeailDAO[i];
                object[] challanID = new object[] { "INSERT INTO gift_items_detail(\r\n            challan_id, row_no, parent_item_id, item_id, unit_id,quantity, price, discounted_sd_rate, discounted_sd, discounted_vat_rate, discounted_vat, remarks, date_challan, user_id_insert,organization_id, org_branch_id, date_consumable_challan ,purchase_type  )\r\n            VALUES (", ChallanID, ", ", saleGiftDetailDAON.RowNo, ", ", saleGiftDetailDAON.GiftParentItemID, ", ", saleGiftDetailDAON.ItemID, ",  ", saleGiftDetailDAON.UnitId, ", ", saleGiftDetailDAON.GiftQuantity, ", ", saleGiftDetailDAON.ItemPriceBDT, ", ", saleGiftDetailDAON.DiscountSDRate, ", ", saleGiftDetailDAON.DiscountSD, ", ", saleGiftDetailDAON.DiscountVatRate, ", ", saleGiftDetailDAON.DiscountVat, ", '", saleGiftDetailDAON.Remarks, "', to_timestamp('", dateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", saleGiftDetailDAON.UserIdInsert, ", ", saleGiftDetailDAON.OrganizationID, ", ", saleGiftDetailDAON.OrgBranchID, ",  to_timestamp('", dateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), '", saleGiftDetailDAON.TypeP, "' )" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        public bool deleteRowById(int id)
        {
            DataTable dataTable = new DataTable();
            string str = string.Concat("update trns_sale_master set Is_deleted=true where Challan_id=", id);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable getAdditionalPendingSaleInfobyChallanId(int challanId)
        {
            string str = string.Concat("select * from trns_sale_additional_master where challan_id = ", challanId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getAllSaleChallan(string org_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select sm.Challan_id,sm.challan_no,sm.date_challan,tp.party_name from trns_sale_master sm \r\n                            join trns_party as tp on tp.Party_id=sm.Party_id\r\n                            where sm.Organization_id='", org_id, "' order by sm.Challan_id desc;");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetAllSalesDataByChallanIDmqmm(long ChallanID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select sm.challan_id, sm.challan_no,p.party_name,p.party_bin,p.party_address,sd.item_id, i.item_name, i.item_specification pack_size,i.item_sku product_code,sm.aggrement_no,\r\n                                iu.unit_id, iu.unit_name, iu.unit_code, sd.quantity, sd.actual_price , coalesce(sd.vat,0) VAT,sd.vat_rate, (coalesce(sd.vat,0)/sd.quantity) unit_VAT,((coalesce(sd.vat,0)/sd.quantity)+sd.actual_price) price_W_VAT, coalesce(sd.sd,0) SD,\r\n                                coalesce(sd.quantity*sd.actual_price,0) total,coalesce(sm.service_charge,0) service_charge ,sd.discount_amt as discount,sd.discount_pct as discount_percentage,0 as bonus,sm.date_challan,sm.challan_no,sm.credit_amount\r\n                                from trns_sale_master sm\r\n                                inner join trns_sale_detail sd on sm.challan_id = sd.challan_id\r\n                                inner join trns_party p on sm.party_id = p.party_id\r\n                                inner join item i on sd.item_id = i.item_id\r\n                                inner join item_unit iu on sd.unit_id = iu.unit_id\r\n                                where sm.is_deleted = false \r\n                                and i.is_deleted = false\r\n                                and sm.challan_id = ", ChallanID);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetAvailableStock(short ItemID, DateTime saleDate)
        {
            object[] str = new object[] { " SELECT coalesce((\r\n       ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t    WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n    and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R') )\r\n     +\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t    WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n    and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C') )\r\n\t-\r\n\t(\r\n\tselect coalesce(sum(D.QUANTITY),0)\r\n\tfrom TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\nWHERE M.Is_deleted = FALSE /* and TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') */ \r\nand D.ITEM_ID =", ItemID, "  \r\n and M.CHALLAN_TYPE in ('S', 'R', 'D', 'L') )\r\n\r\n    ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable  FROM ITEM i \r\n\tleft outer join ITEM_unit u on u.unit_id = i.unit_id   \r\ninner join item_category ic on ic.category_id = i.category_id\r\nWHERE I.ITEM_ID = ", ItemID, "  " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getAvailStock(int ItemID, DateTime saleDate)
        {
            object[] str = new object[] { " SELECT coalesce((\r\n      ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R','C') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'P' ))\r\n   -\r\n    ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n    -\r\n     ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n\r\n    ),0) availStock, i.item_type, i.product_type,i.is_exempted, i.is_rebatable,i.is_vds FROM ITEM i \r\n\tleft outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n    inner join item_category ic on ic.category_id = i.sub_category_id\r\n    WHERE I.ITEM_ID = ", ItemID, "  " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getAvailStockforProduction(int productionId)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string empty = string.Empty;
            object[] objArray = new object[] { "select coalesce(quantity-coalesce((select SUM(quantity) quantity1 from trns_production_master where organization_id=", num, " and p_c_id=", productionId, "),0),0) quantity\r\n                    from trns_production_master where production_id = ", productionId, " and organization_id = ", num };
            empty = string.Concat(objArray);
            return this.connDB.GetDataTable(empty);
        }

        public DataTable getAvailStockforTransferProduct(int ItemID, DateTime saleDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] str = new object[] { " SELECT coalesce((\r\n          ( ( select coalesce(sum(D.QUANTITY),0) \r\n                from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n             WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R', 'C', 'O','T') AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " )\r\n        -\r\n         (select coalesce(sum(D.QUANTITY),0) \r\n                from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n             WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'P' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " )\r\n        -\r\n        (select coalesce(sum(D.QUANTITY),0) \r\n                from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n             WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                and D.ITEM_ID = ", ItemID, " AND D.STATUS IN ('R') AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, "))\r\n           -\r\n            (( select coalesce(sum(D.QUANTITY),0) \r\n                    from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n                 WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                    and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('S', 'F', 'R') AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, ")\r\n            -\r\n         (select coalesce(sum(D.QUANTITY),0) \r\n                from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n             WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'S' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " ))\r\n                --transfer issue will be deducted\r\n                -\r\n                (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n                where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false)\r\n\r\n               --+\r\n                --transfer receive will be added(in purchase table CHALLAN_TYPE = T)\r\n                --(select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n                --where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                --AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false)\r\n\r\n            ),0) availStock,u.UNIT_ID , u.unit_name, u.unit_code, i.item_type, i.product_type,i.is_exempted, i.is_rebatable FROM ITEM i \r\n         left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n            inner join item_category ic on ic.category_id = i.sub_category_id\r\n            WHERE I.ITEM_ID = ", ItemID, "  " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getAvailStockforTransferProductNew(int ItemID, DateTime saleDate, string purchaseType)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] str = new object[] { " SELECT coalesce((\r\n      ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')  and d.approver_stage='F'\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R', 'C', 'O') AND D.PURCHASE_TYPE='", purchaseType, "' AND M.organization_id = ", num, " and M.is_trns_accepted=true AND M.org_branch_reg_id = ", num1, " )\r\n    -\r\n     (select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'P' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " AND D.type_p = '", purchaseType, "')\r\n    -\r\n    (select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.trns_status ='R' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, "))\r\n       -\r\n        (( select coalesce(sum(D.QUANTITY),0) \r\n                from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t            WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and D.installment_status = false and d.approver_stage='F'\r\n                and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('S', 'F', 'R') AND D.type_p = '", purchaseType, "'    AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, ")\r\n        -\r\n     (select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'S' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " AND D.type_p='", purchaseType, "'))\r\n           \t-\r\n--gift\r\n\t\t\t(select coalesce(sum(gd.quantity),0) from gift_items_detail gd  where gd.item_id= ", ItemID, " AND  gd.PURCHASE_TYPE = '", purchaseType, "' AND organization_id=", num, " AND \r\n            org_branch_id=", num1, " AND gd.is_deleted=false )\r\n\r\n--transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false AND D.PURCHASE_TYPE='", purchaseType, "')\r\n\r\n            +\r\n            --transfer receive will be added(in purchase table CHALLAN_TYPE = T)\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n           AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false  AND D.PURCHASE_TYPE='", purchaseType, "')\r\n\r\n        ),0) availStock,u.UNIT_ID , u.unit_name, u.unit_code, i.item_type, i.product_type,i.is_exempted, i.is_rebatable FROM ITEM i \r\n\t    left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n        inner join item_category ic on ic.category_id = i.sub_category_id\r\n        WHERE I.ITEM_ID = ", ItemID, "  " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getAvailStockforTransferProductPropertyWise(int ItemID, DateTime saleDate, string purchaseType, short property1, short property2, short property3, short property4, short property5)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                string str = "";
                string empty = string.Empty;
                if (property1 > 0)
                {
                    object obj = str;
                    object[] objArray = new object[] { obj, " AND (D.property_id1 = ", property1, " OR D.property_id2 = ", property1, " OR D.property_id3 = ", property1, " OR D.property_id4 = ", property1, " OR D.property_id5 = ", property1, ")" };
                    str = string.Concat(objArray);
                }
                if (property2 > 0)
                {
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, " AND (D.property_id1 = ", property2, " OR D.property_id2 = ", property2, " OR D.property_id3 = ", property2, " OR D.property_id4 = ", property2, " OR D.property_id5 = ", property2, ")" };
                    str = string.Concat(objArray1);
                }
                if (property3 > 0)
                {
                    object obj2 = str;
                    object[] objArray2 = new object[] { obj2, " AND (D.property_id1 = ", property3, " OR D.property_id2 = ", property3, " OR D.property_id3 = ", property3, " OR D.property_id4 = ", property3, " OR D.property_id5 = ", property3, ")" };
                    str = string.Concat(objArray2);
                }
                if (property4 > 0)
                {
                    object obj3 = str;
                    object[] objArray3 = new object[] { obj3, " AND (D.property_id1 = ", property4, " OR D.property_id2 = ", property4, " OR D.property_id3 = ", property4, " OR D.property_id4 = ", property4, " OR D.property_id5 = ", property4, ")" };
                    str = string.Concat(objArray3);
                }
                if (property5 > 0)
                {
                    object obj4 = str;
                    object[] objArray4 = new object[] { obj4, " AND (D.property_id1 = ", property5, " OR D.property_id2 = ", property5, " OR D.property_id3 = ", property5, " OR D.property_id4 = ", property5, " OR D.property_id5 = ", property5, ")" };
                    str = string.Concat(objArray4);
                }
                object[] str1 = new object[] { " SELECT coalesce((\r\n           ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('P', 'F', 'R', 'C', 'O','T') AND D.PURCHASE_TYPE='", purchaseType, "' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " ", str, " )\r\n            -\r\n           (select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'P' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " ", str, " )\r\n            -\r\n           (select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND D.STATUS IN ('I','S') AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " ", str, "))\r\n           -\r\n           (( select coalesce(sum(D.QUANTITY),0) \r\n                from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t            WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                and D.ITEM_ID = ", ItemID, "    and M.CHALLAN_TYPE in ('S', 'F', 'R') AND D.type_p = '", purchaseType, "'    AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " ", str, ")\r\n            -\r\n            (select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, "    and M.NOTE_TYPE in ('C','D') and D.Status = 'S' AND M.organization_id = ", num, " AND M.org_branch_reg_id = ", num1, " ", str, " ))\r\n            --transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false ", str, ")\r\n\r\n           --+\r\n            --transfer receive will be added(in purchase table CHALLAN_TYPE = T)\r\n            --(select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            --where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            --AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false)\r\n\r\n          ),0) availStock,u.UNIT_ID , u.unit_name, u.unit_code, i.item_type, i.product_type,i.is_exempted, i.is_rebatable FROM ITEM i \r\n\t      left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n          inner join item_category ic on ic.category_id = i.sub_category_id\r\n          WHERE I.ITEM_ID = ", ItemID, "  " };
                empty = string.Concat(str1);
                dataTable = this.connDB.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetBankBranchId(string branchName, int bankId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct bank_id,branch_id from set_bank_branch where upper(branch_name) ='", branchName, "' and  bank_id=", bankId };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetBankId(string bankName)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select distinct bank_id from set_bank where upper(bank_name) ='", bankName, "' ");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetBatchNo(int itemId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select distinct challan_id,batch_no from trns_purchase_detail where item_id=", itemId, " ");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable Getcash_amountAmountchallan_id(long ChallanID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select sm.challan_id, sm.challan_no,(coalesce(sm.cash_amount,0)+coalesce(sm.bank_amount,0)) cash_amount,to_char(sm.date_challan,'dd/MM/yyyy') date_challan\r\n                                from trns_sale_master sm\r\n                                inner join trns_sale_detail sd on sm.challan_id = sd.challan_id\r\n                                inner join trns_party p on sm.party_id = p.party_id                                \r\n                                where sm.is_deleted = false and  sm.credit_amount!=0                               \r\n                                and sm.challan_id = ", ChallanID);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getCatSubCat(int itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] objArray = new object[] { "SELECT distinct ct.category_id sub_category_id,ct.category_name sub_category_name,ctp.category_id,ctp.category_name,\r\n                         u.UNIT_ID , u.unit_name, u.unit_code, i.item_type,i.item_sku \r\n                         FROM ITEM i \r\n                         left join trns_purchase_detail tpd on tpd.Item_id = i.Item_id\r\n                         left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n                         left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n                         left outer join ITEM_unit u on u.unit_id = i.unit_id WHERE i.organization_id = ", num, " and I.ITEM_ID = ", itemID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getCatSubCat(long itemID)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] objArray = new object[] { "SELECT distinct ct.category_id sub_category_id,ct.category_name sub_category_name,ctp.category_id,ctp.category_name,\r\n                         u.UNIT_ID , u.unit_name, u.unit_code, i.item_type,i.item_sku \r\n                         FROM ITEM i \r\n                         left join trns_purchase_detail tpd on tpd.Item_id = i.Item_id\r\n                         left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n                         left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n                         left outer join ITEM_unit u on u.unit_id = i.unit_id WHERE i.organization_id = ", num, " and I.ITEM_ID = ", itemID };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }


        public DataTable getChallanDetail(int challan_id)
        {
            string str = string.Concat("select  ori.organization_name,ori.registration_no,tp.party_name,tp.party_address,tp.party_bin,operation_address business_address,\r\n                        sm.Challan_id,sm.challan_no,sm.date_challan,sm.date_goods_delivery,sm.ultimate_destination,sm.vehicle_no,Cd.code_name\r\n                        from trns_sale_master as sm\r\n                        join org_registration_info as ori on ori.Organization_id=sm.Organization_id\r\n                        left join trns_party as tp on tp.Party_id=sm.Party_id\r\n                        left join app_code_detail as Cd on Cd.code_id_m=sm.vehicle_type_m and Cd.code_id_d=sm.vehicle_type_d   \r\n                        inner join org_reg_address ora on ora.organization_id=ori.Organization_id                       \r\n                        where sm.Challan_id=", challan_id);
            return this.DBUtil.GetDataTable(str);
        }

        public string getChallanDetailCashMemoHtml(DataTable dt)
        {
            string str = string.Concat("", "<table align='center' width = '100%'>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='3'></td>");
            str = string.Concat(str, "<td><center><h3 style='text-align: left;margin-left: -13%;'>বিক্রয় ক্যাশ মেমো </h3>");
            str = string.Concat(str, "<h5 style='text-align: left;margin-left: -7%;'> মূল্য সংযোজন কর চালান</h5>");
            str = string.Concat(str, "<h5 style='text-align: left;'>[বিধি ১৬ দ্রষ্টব্য]</h5>");
            str = string.Concat(str, "</center>");
            str = string.Concat(str, "</td>");
            str = string.Concat(str, "</tr>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='3'></td>");
            object obj = string.Concat(str, "<td>প্রতিষ্ঠানের নাম</td><td>:</td>");
            object[] item = new object[] { obj, "<td>", dt.Rows[0]["organization_name"], "</td>" };
            str = string.Concat(string.Concat(item), "</tr>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='3'></td>");
            object obj1 = string.Concat(str, "<td>ঠিকানা</td><td>:</td>");
            object[] objArray = new object[] { obj1, "<td>", dt.Rows[0]["business_address"], "</td>" };
            str = string.Concat(string.Concat(objArray), "</tr>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='3'></td>");
            object obj2 = string.Concat(str, "<td>করদাতা সনাক্তকরণ সংখ্যা</td><td>:</td>");
            object[] item1 = new object[] { obj2, "<td>", dt.Rows[0]["registration_no"], "</td>" };
            str = string.Concat(string.Concat(item1), "</tr>");
            str = string.Concat(str, "<tr>");
            object obj3 = string.Concat(str, "<td>ক্রেতার নাম</td><td>:</td>");
            object[] objArray1 = new object[] { obj3, "<td>", dt.Rows[0]["party_name"], "</td>" };
            object obj4 = string.Concat(string.Concat(objArray1), "<td>ক্রমিক নং </td><td>:</td>");
            object[] item2 = new object[] { obj4, "<td>", dt.Rows[0]["Challan_id"], "</td>" };
            str = string.Concat(string.Concat(item2), "</tr>");
            str = string.Concat(str, "<tr>");
            object obj5 = string.Concat(str, "<td>ঠিকানা</td><td>:</td>");
            object[] objArray2 = new object[] { obj5, "<td>", dt.Rows[0]["party_address"], "</td>" };
            str = string.Concat(objArray2);
            DateTime dateTime = DateTime.Parse(dt.Rows[0]["date_challan"].ToString());
            str = string.Concat(str, "<td>ক্যাশ মেমো প্রদানের তারিখ </td><td>:</td>");
            str = string.Concat(str, "<td>", dateTime.ToString("dd-MM-yyyy"), "</td>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td></td>");
            str = string.Concat(str, "<td></td>");
            str = string.Concat(str, "<td></td>");
            str = string.Concat(str, "<td>ক্যাশ মেমো  প্রদানের সময় </td><td>:</td>");
            str = string.Concat(str, "<td>", dateTime.ToString("hh:mm tt"), "</td>");
            return string.Concat(string.Concat(str, "</tr>"), "</table>");
        }

        public string getChallanDetailInHtml(DataTable dt)
        {
            string str = string.Concat("", "<table align='center'>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='2'></td>");
            str = string.Concat(str, "<td><center><h5>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h5>");
            str = string.Concat(str, "<h5>জাতীয় রাজস্ব বোর্ড</h5>");
            str = string.Concat(str, "<h5>ঢাকা ।</h5>");
            str = string.Concat(str, "</center>");
            str = string.Concat(str, "</td>");
            str = string.Concat(str, "</tr>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='3'></td>");
            object obj = string.Concat(str, "<td>ব্যবসায় প্রতিষ্ঠানের নাম</td><td>:</td>");
            object[] item = new object[] { obj, "<td>", dt.Rows[0]["organization_name"], "</td>" };
            str = string.Concat(string.Concat(item), "</tr>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='3'></td>");
            object obj1 = string.Concat(str, "<td>ঠিকানা</td><td>:</td>");
            object[] objArray = new object[] { obj1, "<td>", dt.Rows[0]["business_address"], "</td>" };
            str = string.Concat(string.Concat(objArray), "</tr>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='3'></td>");
            object obj2 = string.Concat(str, "<td>করদাতা সনাক্তকরণ সংখ্যা</td><td>:</td>");
            object[] item1 = new object[] { obj2, "<td>", dt.Rows[0]["registration_no"], "</td>" };
            str = string.Concat(string.Concat(item1), "</tr>");
            str = string.Concat(str, "<tr>");
            object obj3 = string.Concat(str, "<td>ক্রেতার নাম</td><td>:</td>");
            object[] objArray1 = new object[] { obj3, "<td>", dt.Rows[0]["party_name"], "</td>" };
            object obj4 = string.Concat(string.Concat(objArray1), "<td>চালানপত্রের ক্রমিক সংখ্য </td><td>:</td>");
            object[] item2 = new object[] { obj4, "<td>", dt.Rows[0]["Challan_id"], "</td>" };
            str = string.Concat(string.Concat(item2), "</tr>");
            str = string.Concat(str, "<tr>");
            object obj5 = string.Concat(str, "<td>ঠিকানা</td><td>:</td>");
            object[] objArray2 = new object[] { obj5, "<td>", dt.Rows[0]["party_address"], "</td>" };
            object obj6 = string.Concat(string.Concat(objArray2), "<td>চালানপত্র প্রদানের তারিখ </td><td>:</td>");
            object[] item3 = new object[] { obj6, "<td>", dt.Rows[0]["date_challan"], "</td>" };
            str = string.Concat(string.Concat(item3), "<tr>");
            object obj7 = string.Concat(str, "<td>করদাতা সনাক্তকরণ সংখ্যা</td><td>:</td>");
            object[] objArray3 = new object[] { obj7, "<td>", dt.Rows[0]["party_bin"], "</td>" };
            object obj8 = string.Concat(string.Concat(objArray3), "<td>চালানপত্র প্রদানের সময় </td><td>:</td>");
            object[] item4 = new object[] { obj8, "<td>", dt.Rows[0]["date_challan"], "</td>" };
            str = string.Concat(string.Concat(item4), "</tr>");
            str = string.Concat(str, "<tr>");
            object obj9 = string.Concat(str, "<td>পণ্য/সেবার চূড়ান্ত গন্তব্য স্থল</td><td>:</td>");
            object[] objArray4 = new object[] { obj9, "<td>", dt.Rows[0]["ultimate_destination"], "</td>" };
            object obj10 = string.Concat(string.Concat(objArray4), "<td>পণ্য অপসারণের/অর্পণের বা সেবা <br>প্রদানের প্রকৃত  তারিখ ও সময় </td><td>:</td>");
            object[] item5 = new object[] { obj10, "<td>", dt.Rows[0]["date_goods_delivery"], "</td>" };
            str = string.Concat(string.Concat(item5), "</tr>");
            str = string.Concat(str, "<tr>");
            object obj11 = string.Concat(str, "<td> যানবাহনের প্রকৃতি এবং নম্বর </td><td>:</td>");
            object[] objArray5 = new object[] { obj11, "<td>", dt.Rows[0]["code_name"], "</td>" };
            str = string.Concat(objArray5);
            return string.Concat(string.Concat(str, "</tr>"), "</table>");
        }

        public DataTable getChallanProduct(int challan_id)
        {
            DataTable dataTable = new DataTable();
            string str = string.Concat("select i.item_name,Sd.Quantity,(Sd.actual_price*Sd.Quantity) as actual_price,Sd.Sd,(Sd.actual_price*Sd.Quantity+Sd.Sd) as actual_and_sd,Sd.Vat,(Sd.actual_price*Sd.Quantity +Sd.Sd+Sd.Vat) as total_price,coalesce(sm.discount,0) discount \r\n                        from trns_sale_detail as Sd\r\n                        join trns_sale_master as sm on sm.Challan_id=Sd.Challan_id\r\n                        join Item as i on i.Item_id=Sd.Item_id\r\n                         where sm.Challan_id=", challan_id);
            return this.DBUtil.GetDataTable(str);
        }

        public string getChallanProductgCashMemoHtml(DataTable dt)
        {
            string str = "";
            str = string.Concat(str, "<table border='1px' style='border-collapse:collapse;width:100%' align='center' >");
            str = string.Concat(str, "<thead>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<th>ক্রমিক সংখ্যা</th>");
            str = string.Concat(str, "<th>পণ্যের নাম ও বিবরণ</th>");
            str = string.Concat(str, "<th>পণ্যের পরিমাণ </th>");
            str = string.Concat(str, "<th>মোট মূল্য ( মূল্য সংযোজন করসহ) </th>");
            str = string.Concat(str, "</tr>");
            str = string.Concat(str, "</thead>");
            str = string.Concat(str, "<tbody>");
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal num2 = new decimal(0);
                num2 = Convert.ToDecimal(dt.Rows[i]["total_price"]);
                str = string.Concat(str, "<tr>");
                object obj = str;
                object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                str = string.Concat(objArray);
                object obj1 = str;
                object[] item = new object[] { obj1, "<td>", dt.Rows[i]["item_name"], "</td>" };
                str = string.Concat(item);
                str = string.Concat(str, "<td>", Utilities.formatFraction(Convert.ToDecimal(dt.Rows[i]["Quantity"])), "</td>");
                str = string.Concat(str, "<td>", num2.ToString("N2"), "</td>");
                str = string.Concat(str, "</tr>");
                num += num2;
            }
            num1 = Convert.ToDecimal(dt.Rows[0]["discount"]);
            str = string.Concat(str, "<tr><td colspan='2'></td><td>মোট</td><td>", num.ToString("N2"), "</td> </tr>");
            str = string.Concat(str, "<tr><td colspan='2'></td><td>ডিসকাউন্ট</td><td>", num1.ToString("N2"), "</td> </tr>");
            decimal num3 = num - num1;
            str = string.Concat(str, "<tr><td colspan='2'></td><td>সর্বমোট</td><td>", num3.ToString("N2"), "</td> </tr>");
            str = string.Concat(str, "</tbody>");
            str = string.Concat(str, "</table>");
            return str;
        }

        public string getChallanProductgDetailInHtml(DataTable dt)
        {
            string str = "";
            str = string.Concat(str, "<table border='1px' style='border-collapse:collapse;width:100%' align='center' >");
            str = string.Concat(str, "<thead>");
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<th>ক্রমিক সংখ্যা</th>");
            str = string.Concat(str, "<th>পণ্য/সেবার নাম</th>");
            str = string.Concat(str, "<th>পরিমাণ</th>");
            str = string.Concat(str, "<th> সম্পূরক শুল্ক আরোপ যোগ্য মূল্য</th>");
            str = string.Concat(str, "<th>সম্পূরক শুল্কের পরিমাণ</th>");
            str = string.Concat(str, "<th>মূল্য সংযোজন কর আরোপ যোগ্য মূল্য </th>");
            str = string.Concat(str, "<th>মূল্য সংযোজন করের পরিমাণ</th>");
            str = string.Concat(str, "<th>সম্পূরক শুল্ক ও মূসকসহ মোট মূল্য</th>");
            str = string.Concat(str, "</tr>");
            str = string.Concat(str, "</thead>");
            str = string.Concat(str, "<tbody>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str = string.Concat(str, "<tr>");
                object obj = str;
                object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                str = string.Concat(objArray);
                object obj1 = str;
                object[] item = new object[] { obj1, "<td>", dt.Rows[i]["item_name"], "</td>" };
                str = string.Concat(item);
                decimal num = Convert.ToDecimal(dt.Rows[i]["Quantity"]);
                str = string.Concat(str, "<td>", num.ToString("N2"), "</td>");
                decimal num1 = Convert.ToDecimal(dt.Rows[i]["actual_price"]);
                str = string.Concat(str, "<td>", num1.ToString("N2"), "</td>");
                decimal num2 = Convert.ToDecimal(dt.Rows[i]["Sd"]);
                str = string.Concat(str, "<td>", num2.ToString("N2"), "</td>");
                decimal num3 = Convert.ToDecimal(dt.Rows[i]["actual_and_sd"]);
                str = string.Concat(str, "<td>", num3.ToString("N2"), "</td>");
                decimal num4 = Convert.ToDecimal(dt.Rows[i]["Vat"]);
                str = string.Concat(str, "<td>", num4.ToString("N2"), "</td>");
                decimal num5 = Convert.ToDecimal(dt.Rows[i]["total_price"]);
                str = string.Concat(str, "<td>", num5.ToString("N2"), "</td>");
                str = string.Concat(str, "</tr>");
            }
            str = string.Concat(str, "</tbody>");
            str = string.Concat(str, "</table>");
            return str;
        }

        public DataTable GetChallanType(short ItemID, string ItemType, DateTime saleDate)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] itemID = new object[] { "SELECT  I.PRODUCT_TYPE, \r\n                        tpm.purchase_type,\r\n                        CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                            when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                            when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n                            case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                            when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                            when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID, i.order_by,i.item_sku,i.item_specification\r\n                        FROM ITEM as i \r\n                        inner JOIN ITEM_CATEGORY as ic ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                        inner  join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        WHERE I.IS_DELETED = false  AND tpm.organization_id = ", num, " and  tpd.item_id = ", ItemID, "      \r\n                        union\r\n\t\t                select I.PRODUCT_TYPE,'' AS purchase_type, i.item_name ||'-'|| i.ITEM_SPECIFICATION||'-'||i.hs_code ,i.item_id,order_by,i.item_sku,i.item_specification\r\n                        from item as i\r\n                        WHERE I.IS_DELETED = false and i.PRODUCT_TYPE='W' AND (i.organization_id = ", num, " OR i.is_for_all_bss_unit = true) and i.item_id = ", ItemID, " \r\n                        ORDER BY item_name" };
                string str = string.Concat(itemID);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getCkEditor()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select * from CKEditor;");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetcreditedAmount(long party_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct sm.challan_id, sm.challan_no,sm.credit_amount,to_char(sm.date_challan,'dd/MM/yyyy') date_challan\r\n                                from trns_sale_master sm\r\n                                inner join trns_sale_detail sd on sm.challan_id = sd.challan_id\r\n                                inner join trns_party p on sm.party_id = p.party_id                                \r\n                                where sm.is_deleted = false and  sm.credit_amount!=0                               \r\n                                and p.party_id = ", party_id);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetcreditedAmountByParty(long party_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct p.party_id, SUM(coalesce(sm.credit_amount,0)) credit_amount\r\n                                from trns_sale_master sm\r\n                                inner join trns_sale_detail sd on sm.challan_id = sd.challan_id\r\n                                inner join trns_party p on sm.party_id = p.party_id                                \r\n                                where sm.is_deleted = false and  sm.credit_amount!=0                             \r\n                                and p.party_id = ", party_id, " group by p.party_id");
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getGiftItem(string fDate, string tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] strArrays = new string[] { "Select i.item_name,i.item_id\r\n                             from item i\r\n                             inner join gift_items_detail gid on gid.item_id = i.item_id\r\n                             where CAST(gid.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(gid.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and gid.discounted_vat != 0 and gid.is_vat_deducted = false" };
                string str = string.Concat(strArrays);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getGiftItemVAT(int item_id, string fDate, string tDate)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "Select i.item_name,i.item_id,gid.challan_id,tsm.challan_no,gid.discounted_vat vat,gid.quantity,gid.price \r\n                                from item i\r\n                                inner join gift_items_detail gid on gid.item_id = i.item_id\r\n                                inner join trns_sale_master tsm on tsm.challan_id = gid.challan_id\r\n                             where CAST(gid.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(gid.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and gid.discounted_vat != 0 and gid.is_vat_deducted = false and gid.item_id = ", item_id };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable getGiftListOnSale(int challanid)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select i.item_name, iu.unit_name, gid.quantity from gift_items_detail gid \r\n                        inner join item i on gid.item_id=i.item_id\r\n                        inner join item_unit iu on gid.unit_id=iu.unit_id\r\n                        where gid.challan_id=", challanid, " and gid.organization_id=", num, "  and gid.org_branch_id=", num1 };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getImport()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select * ,i.item_name,iu.unit_code \r\n                          from trns_purchase_detail  tpd   \r\n                          inner join trns_purchase_master tpm on tpd.challan_id= tpm.challan_id\r\n                          inner join item i on i.item_id = tpd.item_id\r\n                          inner join item_unit iu on iu.unit_id= tpd.unit_id\r\n                        where tpm.organization_id = ", num, " and tpd.approver_stage !='F' and tpm.purchase_type='I' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getInstallmentInfo(int partyId, string agreementNo)
        {
            object[] objArray = new object[] { "select * from installment_scheduler where party_id = ", partyId, " and agreement_no = '", agreementNo, "' and is_paid=false order by schedule_no " };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getInvoice()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select sm.Challan_id,sm.challan_no,tp.party_name,sm.date_challan,sm.date_goods_delivery,sum(Sd.Quantity * Sd.actual_price + Sd + Vat) as total_price from trns_sale_master as sm\r\n                        join trns_sale_detail as Sd on Sd.Challan_id=sm.Challan_id\r\n                        join trns_party as tp on tp.Party_id=sm.Party_id \r\n                        where sm.organization_id = ", num, " and sm.org_branch_reg_id = ", num1, "\r\n                        group by sm.Challan_id,sm.challan_no,sm.date_challan,sm.date_goods_delivery,tp.party_name,sm.Is_deleted\r\n                        having sm.Is_deleted=false                        \r\n                        order by sm.Challan_id desc" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getItemIdByItem(string itemName)
        {
            string str = string.Concat("select i.item_id,i.unit_id,i.is_zero_rate,i.is_exempted,iu.unit_code from item i\r\n                         inner join item_unit iu on i.unit_id=iu.unit_id\r\n                        where upper(i.Item_name) ='", itemName, "' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getItemIdByItemandCategoryandSubcatId(string itemName, int catId, int subcatId)
        {
            object[] objArray = new object[] { "select i.item_id,i.unit_id,i.is_zero_rate,i.is_exempted,iu.unit_code \r\n                         from item i\r\n                        inner join item_category ic on ic.category_id = i.sub_category_id and ic.parent_id!=0 \r\n                        inner join item_unit iu on i.unit_id=iu.unit_id\r\n                        where upper(Item_name) ='", itemName, "' and parent_id=", catId, " and i.sub_category_id=", subcatId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getItemNameByItemId(int itemId)
        {
            string str = string.Concat("select item_name,brand_name from item where Item_id ='", itemId, "' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet GetLotInfoByItemByID(int itemId, DateTime saleDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            string str = "";
            object[] objArray = new object[] { "SELECT RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,\r\n                        RD.purchase_unit_price UNIT_PRICE, RD.QUANTITY, RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate,Rd.Sd, Rd.Vat,Rd.total_price,\r\n                        (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> 0\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00)\r\n            - coalesce((SELECT SUM(ID.QUANTITY) FROM trns_production_detail ID INNER JOIN\r\n\t\t\ttrns_production_master IM ON IM.production_id = ID.production_id AND status='R' AND ID.DETAIL_ID=RD.DETAIL_ID AND IM.IS_DELETED = FALSE ),0.00)\r\n\r\n           + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) ) -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), " ','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", itemId, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n and M.NOTE_TYPE in ('D') and D.Status = 'P' ) +\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", itemId, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "   \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          and M.NOTE_TYPE in ('C') and D.Status = 'S' )\r\n                        AVAIL_QTY\r\n                        FROM TRNS_PURCHASE_MASTER RM, TRNS_PURCHASE_DETAIL RD left outer join price_item pr on pr.price_id = Rd.price_id\r\n\t\t\tWHERE RM.IS_DELETED = FALSE AND RM.Challan_id =RD.Challan_id AND RM.CHALLAN_TYPE in ('P', 'F', 'R','C','O')\r\n        AND TO_DATE(TO_CHAR(RM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        and RD.ITEM_ID =  ", itemId, "   \r\n        GROUP BY RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,RD.ITEM_ID,\r\n                    RD.actual_price, RD.QUANTITY ,RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate, Rd.Sd, Rd.Vat,Rd.total_price\r\n                   HAVING  (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> 0\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00) + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) ) > 0 \r\n                         ORDER BY RD.DETAIL_ID" };
            str = string.Concat(objArray);
            return this.connDB.GetDataSet(str, "LOT_INFO");
        }

        public DataSet GetLotInfoByItemByIDForGift(SaleGiftDetailDAON objDetail, DateTime saleDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            string str = "";
            object[] challanID = new object[] { "SELECT RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,\r\n                        RD.purchase_unit_price UNIT_PRICE, RD.QUANTITY, RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate,Rd.Sd, Rd.Vat,Rd.total_price,\r\n                        (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> ", objDetail.ChallanID, "\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00) + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) ) -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), " ','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", objDetail.ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n and M.NOTE_TYPE in ('D') and D.Status = 'P' ) +\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", objDetail.ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "   \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          and M.NOTE_TYPE in ('C') and D.Status = 'S' )\r\n                        AVAIL_QTY\r\n                        FROM TRNS_PURCHASE_MASTER RM, TRNS_PURCHASE_DETAIL RD left outer join price_item pr on pr.price_id = Rd.price_id\r\n\t\t\tWHERE RM.IS_DELETED = FALSE AND RM.Challan_id =RD.Challan_id AND RM.CHALLAN_TYPE in ('P', 'F', 'R','C','O')\r\n        AND TO_DATE(TO_CHAR(RM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        and RD.ITEM_ID =  ", objDetail.ItemID, "   \r\n        GROUP BY RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,RD.ITEM_ID,\r\n                    RD.actual_price, RD.QUANTITY ,RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate, Rd.Sd, Rd.Vat,Rd.total_price\r\n                   HAVING  (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> ", objDetail.ChallanID, "\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00) + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) ) > 0 \r\n                         ORDER BY RD.DETAIL_ID" };
            str = string.Concat(challanID);
            return this.connDB.GetDataSet(str, "LOT_INFO");
        }

        public DataSet GetLotInfoByItemByIDForSale(SaleDetailDAON objDetail, DateTime saleDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            string str = "";
            object[] challanID = new object[] { "SELECT RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,\r\n                        RD.purchase_unit_price UNIT_PRICE, RD.QUANTITY, RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate,Rd.Sd, Rd.Vat,Rd.total_price,\r\n                        (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> ", objDetail.ChallanID, "\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00) + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) ) -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), " ','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", objDetail.ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n and M.NOTE_TYPE in ('D') and D.Status = 'P' ) +\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", objDetail.ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "   \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          and M.NOTE_TYPE in ('C') and D.Status = 'S' )\r\n                        AVAIL_QTY\r\n                        FROM TRNS_PURCHASE_MASTER RM, TRNS_PURCHASE_DETAIL RD left outer join price_item pr on pr.price_id = Rd.price_id\r\n\t\t\tWHERE RM.IS_DELETED = FALSE AND RM.Challan_id =RD.Challan_id AND RM.CHALLAN_TYPE in ('P', 'F', 'R','Cr','O')\r\n        AND TO_DATE(TO_CHAR(RM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        and RD.ITEM_ID =  ", objDetail.ItemID, "   \r\n        GROUP BY RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,RD.ITEM_ID,\r\n                    RD.actual_price, RD.QUANTITY ,RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate, Rd.Sd, Rd.Vat,Rd.total_price\r\n                   HAVING  (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> ", objDetail.ChallanID, "\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00) + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) ) > 0 \r\n                         ORDER BY RD.DETAIL_ID" };
            str = string.Concat(challanID);
            return this.connDB.GetDataSet(str, "LOT_INFO");
        }

        public DataSet GetLotInfoByItemIDForSale(SaleDetailDAO objDetail, DateTime saleDate)
        {
            string str = "";
            object[] challanID = new object[] { "SELECT RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,\r\n                        RD.actual_price UNIT_PRICE, RD.QUANTITY, RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate,Rd.Sd, Rd.Vat,Rd.total_price,\r\n                        (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> ", objDetail.ChallanID, "\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00) + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) )\r\n                        AVAIL_QTY\r\n                        FROM TRNS_PURCHASE_MASTER RM, TRNS_PURCHASE_DETAIL RD left outer join price_item pr on pr.price_id = Rd.price_id\r\n\t\t\tWHERE RM.IS_DELETED = FALSE AND RM.Challan_id =RD.Challan_id AND RM.CHALLAN_TYPE in ('P', 'F', 'R','C','O')\r\n        AND TO_DATE(TO_CHAR(RM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        and RD.ITEM_ID =  ", objDetail.ItemID, "   \r\n        GROUP BY RD.Challan_id,RD.DETAIL_ID,RD.LOT_NO,RD.ITEM_ID,\r\n                    RD.actual_price, RD.QUANTITY ,RD.unit_id, RD.price_id, RD.SD_rate, RD,vat_rate, Rd.Sd, Rd.Vat,Rd.total_price\r\n                   HAVING  (RD.QUANTITY - coalesce((SELECT SUM(ID.QUANTITY) FROM TRNS_SALE_DETAIL ID INNER JOIN\r\n\t\t\tTRNS_SALE_MASTER IM ON IM.Challan_id = ID.Challan_id AND IM.CHALLAN_TYPE in ('S','R', 'D', 'L','N')\r\n                        AND ID.DETAIL_ID=RD.DETAIL_ID and im.Challan_id <> ", objDetail.ChallanID, "\r\n        AND IM.IS_DELETED = FALSE \r\n                        ),0.00) + \r\n\tcoalesce((SELECT SUM(ND.QUANTITY) FROM TRNS_NOTE_DETAIL ND INNER JOIN\r\n\t\t\tTRNS_NOTE_MASTER NM ON NM.NOTE_ID = ND.NOTE_ID AND NM.note_type in ('C','D')\r\n                        AND ND.ITEM_ID = RD.ITEM_ID and ND.detail_id = RD.detail_id\r\n        AND NM.IS_DELETED = FALSE AND TO_DATE(TO_CHAR(NM.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        ),0.00) ) > 0 \r\n                         ORDER BY RD.DETAIL_ID" };
            str = string.Concat(challanID);
            return this.connDB.GetDataSet(str, "LOT_INFO");
        }

        public DataTable GetmaxChallanId()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.connDB.GetDataTable("Select max(challan_id) challan_id from trns_sale_master");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetPaidAmount(long challan_idp)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select ch.* ,sm.challan_id, sm.challan_no,sm.credit_amount\r\n                                from trns_sale_master sm\r\n                                inner join trns_sale_detail sd on sm.challan_id = sd.challan_id\r\n                                inner join credit_transac_history ch on sm.challan_id = ch.challan_id                                \r\n                                where sm.is_deleted = false                                 \r\n                                and sm.challan_id = ", challan_idp);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetParty(string partyName)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select * from trns_party where upper(party_name)='", partyName, "' and organization_id=", num, " and Is_deleted = false and is_importer=true" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPartybySaleChallan(int challanId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select p.party_id, p.party_name,m.date_challan from trns_party p\r\n                             inner join trns_sale_master m on m.party_id=p.party_id\r\n                             where m.challan_id = ", challanId, " and m.organization_id=", num };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPartyCredlmt(int party_id)
        {
            string str = string.Concat("select coalesce(credit_limit,0) credit_limit from trns_party where party_id=", party_id, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPartyLocalPurchase(string partyName)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select * from trns_party where upper(party_name)='", partyName, "' and organization_id=", num, " and Is_deleted = false and (is_vendor=true or (is_vendor=true and is_customer=true))" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPartyPurchase(int partyId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select * from trns_party where party_id=", partyId, " and organization_id=", num, " and (is_vendor=true or (is_vendor=true and is_customer=true)) " };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPartysale(string partyName)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select * from trns_party where upper(party_name)='", partyName, "' and organization_id=", num, " and Is_deleted = false and (is_customer=true or (is_vendor=true and is_customer=true))" };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPartySale(int partyId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "select * from trns_party where party_id=", partyId, " and organization_id=", num, " and (is_customer=true or (is_vendor=true and is_customer=true)) " };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPendingDetailSaleInfo(int challanId)
        {
            string str = string.Concat("select * from trns_sale_detail where challan_id = ", challanId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getPendingSaleInfo()
        {
            return this.connDB.GetDataTable("select * from trns_sale_master where is_approved = 'pending'");
        }

        public DataTable getPendingSaleInfobyChallanId(int challanId)
        {
            string str = string.Concat("select * from trns_sale_master where challan_id = ", challanId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPriceInfoOfGiftOwnProduction(long ItemID)
        {
            object[] itemID = new object[] { "SELECT SUM(D.price_id) price_id, SUM(D.unit_price) unit_price, SUM(D.cnfrmd_wholesale_prc) cnfrmd_wholesale_prc, SUM(D.cnfrmd_retail_prc) cnfrmd_retail_prc, \r\n                       SUM(D.cnfrmd_actl_prc) cnfrmd_actl_prc, SUM(D.cnfrmd_sd_amount) cnfrmd_sd_amount, sum(d.cnfrmd_actl_prc_sd) cnfrmd_actl_prc_sd, sum(d.cnfrmd_actl_prc_vat) cnfrmd_actl_prc_vat,\r\n                       SUM(D.ITEM_ID) ITEM_ID, max(D.TAX_ID_SD) TAX_ID_SD,  SUM(D.SD_AMOUNT) SD_RATE, max(D.TAX_ID_VAT) TAX_ID_VAT, SUM(D.VAT_AMOUNT) VAT_RATE,max(D.TAX_ID_AIT) TAX_ID_AIT,  SUM(D.AIT_AMOUNT) AIT_RATE,MAX(PER) AS PER\r\n                FROM (\r\n\r\n                SELECT  P.price_id, case when production_quantity is null then CAST(P.prpsd_actl_prc as decimal(18,4)) else CAST((P.prpsd_actl_prc/production_quantity) as decimal(18,4)) end unit_price, P.cnfrmd_wholesale_prc, P.cnfrmd_retail_prc,P.cnfrmd_actl_prc, P.cnfrmd_sd_amount, P.cnfrmd_actl_prc_sd, P.cnfrmd_actl_prc_vat,\r\n                0 ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM price_item P WHERE P.price_id = (SELECT MAX(price_id) FROM price_item\r\n                WHERE ITEM_ID = ", ItemID, " AND IS_DELETED = FALSE\r\n                GROUP BY ITEM_ID, PROPERTY_ID1, PROPERTY_ID2,PROPERTY_ID3,PROPERTY_ID4,PROPERTY_ID5)\r\n\t        \tunion all\r\n                SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                S.ITEM_ID, S.TAX_ID TAX_ID_SD,  S.TAX_VALUE SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM ITEM_TAX_VALUES S\r\n\t\t        WHERE S.ITEM_ID = ", ItemID, " AND S.TAX_ID =", (short)3, "  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n                GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", ItemID, " AND TAX_ID =", (short)3, "   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_sale=true)\r\n\t\t        union all\r\n\t\t        SELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t        V.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM  ITEM_TAX_VALUES V\r\n\t\t        WHERE V.ITEM_ID = ", ItemID, " AND V.TAX_ID =", (short)4, "  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE\r\n                GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", ItemID, " AND TAX_ID =", (short)4, "  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_sale=true)\r\n\t\t\r\n                union all\r\n                SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,S.TAX_ID TAX_ID_AIT,  S.TAX_VALUE AIT_AMOUNT,'' AS PER\r\n\t\t        FROM ITEM_TAX_VALUES S\r\n\t\t        WHERE S.ITEM_ID = ", ItemID, " AND S.TAX_ID =5  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE AND S.IS_TRAN_SALE=TRUE\r\n                GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", ItemID, " AND TAX_ID =5   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND IS_TRAN_SALE=true)\r\n\r\n               UNION ALL\r\n\t\t\t   SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t\t   S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, S.TAX_ID TAX_ID_VAT, S.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,S.PER\r\n\t\t       FROM ITEM_TAX_VALUES S\r\n\t\t       WHERE S.ITEM_ID = ", ItemID, " AND S.TAX_ID = 99  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE AND S.IS_TRAN_SALE=TRUE\r\n               GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t       HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", ItemID, " AND TAX_ID = 99   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND IS_TRAN_SALE=true)\r\n               ) D having SUM(D.unit_price) >= 0" };
            string str = string.Concat(itemID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPriceInfoOfItem(SaleDetailDAO objDetailDAO)
        {
            DataTable dataTable;
            try
            {
                if (objDetailDAO.PropertyID1 > 0)
                {
                    string.Concat(" AND PROPERTY_ID1 = ", objDetailDAO.PropertyID1);
                }
                if (objDetailDAO.PropertyID2 > 0)
                {
                    string.Concat(" AND PROPERTY_ID2 = ", objDetailDAO.PropertyID2);
                }
                if (objDetailDAO.PropertyID3 > 0)
                {
                    string.Concat(" AND PROPERTY_ID3 = ", objDetailDAO.PropertyID3);
                }
                if (objDetailDAO.PropertyID4 > 0)
                {
                    string.Concat(" AND PROPERTY_ID4 = ", objDetailDAO.PropertyID4);
                }
                if (objDetailDAO.PropertyID5 > 0)
                {
                    string.Concat(" AND PROPERTY_ID5 = ", objDetailDAO.PropertyID5);
                }
                object[] itemID = new object[] { "SELECT SUM(D.price_id) price_id, SUM(D.unit_price) unit_price, SUM(D.cnfrmd_wholesale_prc) cnfrmd_wholesale_prc, SUM(D.cnfrmd_retail_prc) cnfrmd_retail_prc, \r\n            SUM(D.cnfrmd_actl_prc) cnfrmd_actl_prc, SUM(D.cnfrmd_sd_amount) cnfrmd_sd_amount, sum(d.cnfrmd_actl_prc_sd) cnfrmd_actl_prc_sd, sum(d.cnfrmd_actl_prc_vat) cnfrmd_actl_prc_vat,\r\n                SUM(D.ITEM_ID) ITEM_ID, max(D.TAX_ID_SD) TAX_ID_SD,  SUM(D.SD_AMOUNT) SD_RATE, max(D.TAX_ID_VAT) TAX_ID_VAT, SUM(D.VAT_AMOUNT) VAT_RATE,MAX(PER) PER\r\n                FROM (\r\n\r\n                SELECT  P.price_id, P.prpsd_actl_prc  unit_price, P.cnfrmd_wholesale_prc, P.cnfrmd_retail_prc,P.cnfrmd_actl_prc, P.cnfrmd_sd_amount, P.cnfrmd_actl_prc_sd, P.cnfrmd_actl_prc_vat,\r\n                0 ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,'' PER\r\n\t\t        FROM price_item P WHERE P.price_id = (SELECT MAX(price_id) FROM price_item\r\n                WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND IS_DELETED = FALSE\r\n                GROUP BY ITEM_ID, PROPERTY_ID1, PROPERTY_ID2,PROPERTY_ID3,PROPERTY_ID4,PROPERTY_ID5)\r\n\t\t union all\r\n                SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                S.ITEM_ID, S.TAX_ID TAX_ID_SD,  S.TAX_VALUE SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,S.PER\r\n\t\tFROM ITEM_TAX_VALUES S\r\n\t\tWHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =", (short)3, "  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n        GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\tHAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)3, "   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE and is_tran_sale=true)\r\n\t\tunion all\r\n\t\tSELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\tV.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,V.PER\r\n\t\tFROM  ITEM_TAX_VALUES V\r\n\t\tWHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID =", (short)4, "  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE\r\n        GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\tHAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)4, "  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE and is_tran_sale=true)\r\n\r\n        UNION ALL\r\n\t\tSELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\tV.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,V.PER\r\n\t\tFROM  ITEM_TAX_VALUES V\r\n\t\tWHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID = 99  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE\r\n\t\tGROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\tHAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =99  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE and is_tran_sale=true)\r\n\t\t) D having SUM(D.unit_price) >= 0" };
                string str = string.Concat(itemID);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetPriceInfoOfItemForImportPurchase(SaleDetailDAO objDetailDAO)
        {
            if (objDetailDAO.PropertyID1 > 0)
            {
                string.Concat(" AND PROPERTY_ID1 = ", objDetailDAO.PropertyID1);
            }
            if (objDetailDAO.PropertyID2 > 0)
            {
                string.Concat(" AND PROPERTY_ID2 = ", objDetailDAO.PropertyID2);
            }
            if (objDetailDAO.PropertyID3 > 0)
            {
                string.Concat(" AND PROPERTY_ID3 = ", objDetailDAO.PropertyID3);
            }
            if (objDetailDAO.PropertyID4 > 0)
            {
                string.Concat(" AND PROPERTY_ID4 = ", objDetailDAO.PropertyID4);
            }
            if (objDetailDAO.PropertyID5 > 0)
            {
                string.Concat(" AND PROPERTY_ID5 = ", objDetailDAO.PropertyID5);
            }
            object[] itemID = new object[] { "SELECT SUM(D.price_id) price_id, SUM(D.unit_price) unit_price, SUM(D.cnfrmd_wholesale_prc) cnfrmd_wholesale_prc, SUM(D.cnfrmd_retail_prc) cnfrmd_retail_prc, \r\n                   SUM(D.cnfrmd_actl_prc) cnfrmd_actl_prc, SUM(D.cnfrmd_sd_amount) cnfrmd_sd_amount, sum(d.cnfrmd_actl_prc_sd) cnfrmd_actl_prc_sd, sum(d.cnfrmd_actl_prc_vat) cnfrmd_actl_prc_vat,\r\n                   SUM(D.ITEM_ID) ITEM_ID, max(D.TAX_ID_SD) TAX_ID_SD,  SUM(D.SD_AMOUNT) SD_RATE, max(D.TAX_ID_VAT) TAX_ID_VAT, SUM(D.VAT_AMOUNT) VAT_RATE, max(D.TAX_ID_AIT) TAX_ID_AIT, SUM(D.AIT_AMOUNT) AIT_RATE,MAX(PER) AS PER\r\n                   FROM (\r\n                   SELECT  P.price_id, P.prpsd_actl_prc  unit_price, P.cnfrmd_wholesale_prc, P.cnfrmd_retail_prc,P.cnfrmd_actl_prc, P.cnfrmd_sd_amount, P.cnfrmd_actl_prc_sd, P.cnfrmd_actl_prc_vat,\r\n                   0 ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,'' AS PER\r\n\t\t           FROM price_item P WHERE P.price_id = (SELECT MAX(price_id) FROM price_item\r\n                   WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND IS_DELETED = FALSE\r\n                   GROUP BY ITEM_ID, PROPERTY_ID1, PROPERTY_ID2,PROPERTY_ID3,PROPERTY_ID4,PROPERTY_ID5)\r\n\t\t          union all\r\n                    SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                    S.ITEM_ID, S.TAX_ID TAX_ID_SD,  S.TAX_VALUE SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,'' AS PER\r\n\t\t            FROM ITEM_TAX_VALUES S\r\n\t\t            WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =", (short)3, "  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n                    GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t            HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)3, "   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_import=true)\r\n\t\t         union all\r\n                  SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                  S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,S.TAX_ID TAX_ID_AIT,  S.TAX_VALUE AIT_AMOUNT,'' AS PER\r\n\t\t          FROM ITEM_TAX_VALUES S\r\n\t\t          WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =5  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n                  GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t          HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =5   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_import=true)\r\n                union all\r\n\t\t        SELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t        V.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM  ITEM_TAX_VALUES V\r\n\t\t        WHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID =", (short)4, "  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE\r\n                GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)4, "  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_import=true)\r\n\r\n                --fixed vat\r\n\t\t       UNION ALL\r\n\t\t    \r\n\t\t        SELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t        V.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,V.PER\r\n\t\t        FROM  ITEM_TAX_VALUES V\r\n\t\t        WHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID = 99  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE AND V.PER='1'\r\n\t\t        GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND TAX_ID = 99  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_import=true)\r\n\t\t        ) D having SUM(D.unit_price) >= 0" };
            string str = string.Concat(itemID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPriceInfoOfItemForLocalPurchase(SaleDetailDAO objDetailDAO)
        {
            if (objDetailDAO.PropertyID1 > 0)
            {
                string.Concat(" AND PROPERTY_ID1 = ", objDetailDAO.PropertyID1);
            }
            if (objDetailDAO.PropertyID2 > 0)
            {
                string.Concat(" AND PROPERTY_ID2 = ", objDetailDAO.PropertyID2);
            }
            if (objDetailDAO.PropertyID3 > 0)
            {
                string.Concat(" AND PROPERTY_ID3 = ", objDetailDAO.PropertyID3);
            }
            if (objDetailDAO.PropertyID4 > 0)
            {
                string.Concat(" AND PROPERTY_ID4 = ", objDetailDAO.PropertyID4);
            }
            if (objDetailDAO.PropertyID5 > 0)
            {
                string.Concat(" AND PROPERTY_ID5 = ", objDetailDAO.PropertyID5);
            }
            object[] itemID = new object[] { "SELECT SUM(D.price_id) price_id, SUM(D.unit_price) unit_price, SUM(D.cnfrmd_wholesale_prc) cnfrmd_wholesale_prc, SUM(D.cnfrmd_retail_prc) cnfrmd_retail_prc, \r\n                   SUM(D.cnfrmd_actl_prc) cnfrmd_actl_prc, SUM(D.cnfrmd_sd_amount) cnfrmd_sd_amount, sum(d.cnfrmd_actl_prc_sd) cnfrmd_actl_prc_sd, sum(d.cnfrmd_actl_prc_vat) cnfrmd_actl_prc_vat,\r\n                   SUM(D.ITEM_ID) ITEM_ID, max(D.TAX_ID_SD) TAX_ID_SD,  SUM(D.SD_AMOUNT) SD_RATE, max(D.TAX_ID_VAT) TAX_ID_VAT, SUM(D.VAT_AMOUNT) VAT_RATE, max(D.TAX_ID_AIT) TAX_ID_AIT, SUM(D.AIT_AMOUNT) AIT_RATE,MAX(PER) AS PER\r\n                   FROM (\r\n                   SELECT  P.price_id, P.prpsd_actl_prc  unit_price, P.cnfrmd_wholesale_prc, P.cnfrmd_retail_prc,P.cnfrmd_actl_prc, P.cnfrmd_sd_amount, P.cnfrmd_actl_prc_sd, P.cnfrmd_actl_prc_vat,\r\n                   0 ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,'' AS PER\r\n\t\t           FROM price_item P WHERE P.price_id = (SELECT MAX(price_id) FROM price_item\r\n                   WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND IS_DELETED = FALSE\r\n                   GROUP BY ITEM_ID, PROPERTY_ID1, PROPERTY_ID2,PROPERTY_ID3,PROPERTY_ID4,PROPERTY_ID5)\r\n\t\t          union all\r\n                    SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                    S.ITEM_ID, S.TAX_ID TAX_ID_SD,  S.TAX_VALUE SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,'' AS PER\r\n\t\t            FROM ITEM_TAX_VALUES S\r\n\t\t            WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =", (short)3, "  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n                    GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t            HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)3, "   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_local=true)\r\n\t\t         union all\r\n                  SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                  S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,S.TAX_ID TAX_ID_AIT,  S.TAX_VALUE AIT_AMOUNT,'' AS PER\r\n\t\t          FROM ITEM_TAX_VALUES S\r\n\t\t          WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =5  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n                  GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t          HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =5   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_local=true)\r\n                union all\r\n\t\t        SELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t        V.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM  ITEM_TAX_VALUES V\r\n\t\t        WHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID =", (short)4, "  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE\r\n                GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)4, "  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_local=true)\r\n\r\n                --fixed vat\r\n\t\t       UNION ALL\r\n\t\t    \r\n\t\t        SELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t        V.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT, 0 AIT_AMOUNT,V.PER\r\n\t\t        FROM  ITEM_TAX_VALUES V\r\n\t\t        WHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID = 99  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE AND V.PER='1'\r\n\t\t        GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND TAX_ID = 99  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_local=true)\r\n\t\t        ) D having SUM(D.unit_price) >= 0" };
            string str = string.Concat(itemID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPriceInfoOfItemFrSale(SaleDetailDAO objDetailDAO)
        {
            if (objDetailDAO.PropertyID1 > 0)
            {
                string.Concat(" AND PROPERTY_ID1 = ", objDetailDAO.PropertyID1);
            }
            if (objDetailDAO.PropertyID2 > 0)
            {
                string.Concat(" AND PROPERTY_ID2 = ", objDetailDAO.PropertyID2);
            }
            if (objDetailDAO.PropertyID3 > 0)
            {
                string.Concat(" AND PROPERTY_ID3 = ", objDetailDAO.PropertyID3);
            }
            if (objDetailDAO.PropertyID4 > 0)
            {
                string.Concat(" AND PROPERTY_ID4 = ", objDetailDAO.PropertyID4);
            }
            if (objDetailDAO.PropertyID5 > 0)
            {
                string.Concat(" AND PROPERTY_ID5 = ", objDetailDAO.PropertyID5);
            }
            object[] itemID = new object[] { "SELECT SUM(D.price_id) price_id, SUM(D.unit_price) unit_price, SUM(D.cnfrmd_wholesale_prc) cnfrmd_wholesale_prc, SUM(D.cnfrmd_retail_prc) cnfrmd_retail_prc, \r\n                       SUM(D.cnfrmd_actl_prc) cnfrmd_actl_prc, SUM(D.cnfrmd_sd_amount) cnfrmd_sd_amount, sum(d.cnfrmd_actl_prc_sd) cnfrmd_actl_prc_sd, sum(d.cnfrmd_actl_prc_vat) cnfrmd_actl_prc_vat,\r\n                       SUM(D.ITEM_ID) ITEM_ID, max(D.TAX_ID_SD) TAX_ID_SD,  SUM(D.SD_AMOUNT) SD_RATE, max(D.TAX_ID_VAT) TAX_ID_VAT, SUM(D.VAT_AMOUNT) VAT_RATE,max(D.TAX_ID_AIT) TAX_ID_AIT,  SUM(D.AIT_AMOUNT) AIT_RATE,MAX(PER) AS PER\r\n                FROM (\r\n\r\n                SELECT  P.price_id, case when production_quantity is null then CAST(P.prpsd_actl_prc as decimal(18,4)) else CAST((P.prpsd_actl_prc/production_quantity) as decimal(18,4)) end unit_price, P.cnfrmd_wholesale_prc, P.cnfrmd_retail_prc,P.cnfrmd_actl_prc, P.cnfrmd_sd_amount, P.cnfrmd_actl_prc_sd, P.cnfrmd_actl_prc_vat,\r\n                0 ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM price_item P WHERE P.price_id = (SELECT MAX(price_id) FROM price_item\r\n                WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND IS_DELETED = FALSE\r\n                GROUP BY ITEM_ID, PROPERTY_ID1, PROPERTY_ID2,PROPERTY_ID3,PROPERTY_ID4,PROPERTY_ID5)\r\n\t        \tunion all\r\n                SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                S.ITEM_ID, S.TAX_ID TAX_ID_SD,  S.TAX_VALUE SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM ITEM_TAX_VALUES S\r\n\t\t        WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =", (short)3, "  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n                GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)3, "   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_sale=true)\r\n\t\t        union all\r\n\t\t        SELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t        V.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM  ITEM_TAX_VALUES V\r\n\t\t        WHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID =", (short)4, "  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE\r\n                GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)4, "  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_sale=true)\r\n\t\t\r\n                union all\r\n                SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,S.TAX_ID TAX_ID_AIT,  S.TAX_VALUE AIT_AMOUNT,'' AS PER\r\n\t\t        FROM ITEM_TAX_VALUES S\r\n\t\t        WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =5  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE AND S.IS_TRAN_SALE=TRUE\r\n                GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =5   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND IS_TRAN_SALE=true)\r\n\r\n               UNION ALL\r\n\t\t\t   SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t\t   S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, S.TAX_ID TAX_ID_VAT, S.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,S.PER\r\n\t\t       FROM ITEM_TAX_VALUES S\r\n\t\t       WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID = 99  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE AND S.IS_TRAN_SALE=TRUE\r\n               GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t       HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID = 99   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND IS_TRAN_SALE=true)\r\n               ) D having SUM(D.unit_price) >= 0" };
            string str = string.Concat(itemID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPriceInfoOfItemFrSaleN(SaleDetailDAON objDetailDAO)
        {
            if (objDetailDAO.PropertyID1 > 0)
            {
                string.Concat(" AND PROPERTY_ID1 = ", objDetailDAO.PropertyID1);
            }
            if (objDetailDAO.PropertyID2 > 0)
            {
                string.Concat(" AND PROPERTY_ID2 = ", objDetailDAO.PropertyID2);
            }
            if (objDetailDAO.PropertyID3 > 0)
            {
                string.Concat(" AND PROPERTY_ID3 = ", objDetailDAO.PropertyID3);
            }
            if (objDetailDAO.PropertyID4 > 0)
            {
                string.Concat(" AND PROPERTY_ID4 = ", objDetailDAO.PropertyID4);
            }
            if (objDetailDAO.PropertyID5 > 0)
            {
                string.Concat(" AND PROPERTY_ID5 = ", objDetailDAO.PropertyID5);
            }
            object[] itemID = new object[] { "SELECT SUM(D.price_id) price_id, SUM(D.unit_price) unit_price, SUM(D.cnfrmd_wholesale_prc) cnfrmd_wholesale_prc, SUM(D.cnfrmd_retail_prc) cnfrmd_retail_prc, \r\n                       SUM(D.cnfrmd_actl_prc) cnfrmd_actl_prc, SUM(D.cnfrmd_sd_amount) cnfrmd_sd_amount, sum(d.cnfrmd_actl_prc_sd) cnfrmd_actl_prc_sd, sum(d.cnfrmd_actl_prc_vat) cnfrmd_actl_prc_vat,\r\n                       SUM(D.ITEM_ID) ITEM_ID, max(D.TAX_ID_SD) TAX_ID_SD,  SUM(D.SD_AMOUNT) SD_RATE, max(D.TAX_ID_VAT) TAX_ID_VAT, SUM(D.VAT_AMOUNT) VAT_RATE,max(D.TAX_ID_AIT) TAX_ID_AIT,  SUM(D.AIT_AMOUNT) AIT_RATE,MAX(PER) AS PER\r\n                FROM (\r\n\r\n                SELECT  P.price_id, case when production_quantity is null then CAST(P.prpsd_actl_prc as decimal(18,4)) else CAST((P.prpsd_actl_prc/production_quantity) as decimal(18,4)) end unit_price, P.cnfrmd_wholesale_prc, P.cnfrmd_retail_prc,P.cnfrmd_actl_prc, P.cnfrmd_sd_amount, P.cnfrmd_actl_prc_sd, P.cnfrmd_actl_prc_vat,\r\n                0 ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM price_item P WHERE P.price_id = (SELECT MAX(price_id) FROM price_item\r\n                WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND IS_DELETED = FALSE\r\n                GROUP BY ITEM_ID, PROPERTY_ID1, PROPERTY_ID2,PROPERTY_ID3,PROPERTY_ID4,PROPERTY_ID5)\r\n\t        \tunion all\r\n                SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                S.ITEM_ID, S.TAX_ID TAX_ID_SD,  S.TAX_VALUE SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM ITEM_TAX_VALUES S\r\n\t\t        WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =", (short)3, "  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE\r\n                GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)3, "   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_sale=true)\r\n\t\t        union all\r\n\t\t        SELECT 0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc,  0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t        V.ITEM_ID, 0 TAX_ID_VAT, 0 SD_AMOUNT, V.TAX_ID TAX_ID_VAT, V.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,'' AS PER\r\n\t\t        FROM  ITEM_TAX_VALUES V\r\n\t\t        WHERE V.ITEM_ID = ", objDetailDAO.ItemID, " AND V.TAX_ID =", (short)4, "  AND V.IS_CURRENT = TRUE AND V.IS_DELETED=FALSE\r\n                GROUP BY V.tax_value_id,V.ITEM_ID, V.TAX_ID, V.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =", (short)4, "  AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND is_tran_sale=true)\r\n\t\t\r\n                union all\r\n                SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n                S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, 0 TAX_ID_VAT, 0 VAT_AMOUNT,S.TAX_ID TAX_ID_AIT,  S.TAX_VALUE AIT_AMOUNT,'' AS PER\r\n\t\t        FROM ITEM_TAX_VALUES S\r\n\t\t        WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID =5  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE AND S.IS_TRAN_SALE=TRUE\r\n                GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t        HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID =5   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND IS_TRAN_SALE=true)\r\n\r\n               UNION ALL\r\n\t\t\t   SELECT  0 price_id, 0 unit_price,0 cnfrmd_wholesale_prc, 0 cnfrmd_retail_prc, 0 cnfrmd_actl_prc, 0 cnfrmd_sd_amount, 0 cnfrmd_actl_prc_sd, 0 cnfrmd_actl_prc_vat,\r\n\t\t\t   S.ITEM_ID, 0 TAX_ID_SD,  0 SD_AMOUNT, S.TAX_ID TAX_ID_VAT, S.TAX_VALUE VAT_AMOUNT,0 TAX_ID_AIT,  0 AIT_AMOUNT,S.PER\r\n\t\t       FROM ITEM_TAX_VALUES S\r\n\t\t       WHERE S.ITEM_ID = ", objDetailDAO.ItemID, " AND S.TAX_ID = 99  AND S.IS_CURRENT = TRUE AND S.IS_DELETED=FALSE AND S.IS_TRAN_SALE=TRUE\r\n               GROUP BY S.tax_value_id,S.ITEM_ID, S.TAX_ID, S.TAX_VALUE \r\n\t\t       HAVING tax_value_id = (SELECT MAX(tax_value_id) FROM ITEM_TAX_VALUES WHERE ITEM_ID =  ", objDetailDAO.ItemID, " AND TAX_ID = 99   AND IS_CURRENT = TRUE AND IS_DELETED=FALSE AND IS_TRAN_SALE=true)\r\n               ) D having SUM(D.unit_price) >= 0" };
            string str = string.Concat(itemID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getProductDetailInfo(string product, DateTime saleDate)
        {
            string str = string.Concat("select Item_id from Item where item_name like '%", product, "%'");
            DataTable dataTable = this.connDB.GetDataTable(str);
            int num = Convert.ToInt32(dataTable.Rows[0]["Item_id"].ToString());
            object[] objArray = new object[] { " SELECT coalesce((\r\n                   ( select coalesce(sum(D.QUANTITY),0) \r\n                        from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t                WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                and D.ITEM_ID = ", num, "    and M.CHALLAN_TYPE in ('P', 'F', 'R') )\r\n                 +\r\n                 ( select coalesce(sum(D.QUANTITY),0) \r\n                        from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t                WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                and D.ITEM_ID = ", num, "    and M.NOTE_TYPE in ('C') )\r\n\t            -\r\n\t            (\r\n\t            select coalesce(sum(D.QUANTITY),0)\r\n\t            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n            WHERE M.Is_deleted = FALSE /* and TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') */ \r\n            and D.ITEM_ID =", num, "  \r\n             and M.CHALLAN_TYPE in ('S', 'R', 'D', 'L') )\r\n\r\n                ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable, i.Item_id  FROM ITEM i \r\n\t            left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n            inner join item_category ic on ic.category_id = i.sub_category_id\r\n            WHERE I.ITEM_ID = ", num, "  " };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getProductInfo(string product)
        {
            DataTable dataTable = null;
            try
            {
                string str = string.Concat("select * from Item where item_name like '%", product, "%' and Is_deleted='0';");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetProductionItemProperty(int itemId, string batchNo)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct challan_id,mfg_date,expiry_date from trns_purchase_detail where item_id=", itemId, " AND batch_no='", batchNo, "' " };
                string str = string.Concat(objArray);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPropertyByCodeId(int proprtyId)
        {
            string str = string.Concat("select distinct property_name,property_id from item_property \r\n                      where property_type_m = 5 AND property_type_d ='", proprtyId, "' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPropertyByItemId(string column, int itemId)
        {
            object[] objArray = new object[] { "select DISTINCT ip.property_name,ip.property_id from item_property ip \r\n                            inner join  trns_purchase_detail tpd\r\n                            on tpd.", column, " = ip.property_id where Item_id ='", itemId, "' " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPropertyName(int propertyId)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select distinct b.code_name,b.code_id_d from item_property a \r\n                            inner join app_code_detail b on a.property_type_d=b.code_id_d\r\n                            where b.code_id_m = 5 AND a.property_id = ", propertyId);
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getPurchase()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select * ,i.item_name \r\n                          from trns_purchase_detail  tpd   \r\n                          inner join trns_purchase_master tpm on tpd.challan_id= tpm.challan_id\r\n                          inner join item i on i.item_id = tpd.item_id\r\n                        where tpm.organization_id = ", num, " and tpd.approver_stage !='F'  and tpm.purchase_type='L'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPurchasePartyAPI(int partyId, string bin)
        {
            object[] objArray = new object[] { "select * from party_purchase_api                        \r\n                        where party_id = ", partyId, " and party_bin ='", bin, "' " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPurchaseUnitPrice(int itemID)
        {
            object[] objArray = new object[] { "select purchase_unit_price  from trns_purchase_detail where item_id = ", itemID, " AND purchase_unit_price > 0 AND challan_id = (select max(challan_id) from trns_purchase_detail where item_id = ", itemID, " AND purchase_unit_price > 0)" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getSale()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            string str = string.Concat("select * ,i.item_name \r\n                          from trns_sale_detail  tsd\r\n                          inner join trns_sale_master tsm on tsd.challan_id= tsm.challan_id\r\n                          inner join item i on i.item_id = tsd.item_id\r\n                        where tsm.organization_id = ", num, " and tsd.approver_stage !='F' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetSaleAvailableStock(int ItemID, string ItemType, DateTime saleDate)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] str = new object[] { " SELECT coalesce((\r\n            ( \r\n            \r\n           ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.approver_stage='F'\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.purchase_type='", ItemType, "'    \r\n            and M.CHALLAN_TYPE in ('P', 'F', 'R','C','O','T'))\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", ItemType, "'    \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n            -\r\n             ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND M.trns_status = 'R' ))\r\n           -\r\n            ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.approver_stage='F'\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", ItemType, "'    \r\n            and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n          -\r\n          ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", ItemType, "'   \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          \r\n           --transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false)\r\n\r\n           --+\r\n            --transfer receive will be added(If receive from transfer then purchase table CHALLAN_TYPE = T)\r\n            --(select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            --where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            --AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false)\r\n\r\n          ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable  FROM ITEM i \r\n\t      left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n          inner join item_category ic on ic.category_id = i.sub_category_id\r\n          WHERE I.ITEM_ID = ", ItemID, "  " };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetSaleAvailableStockN(int ItemID, string ItemType, DateTime saleDate, string typeS)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] str = new object[] { " SELECT coalesce((\r\n            ( \r\n           \r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and d.approver_stage='F'\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.purchase_type='", ItemType, "'    \r\n            and M.CHALLAN_TYPE in ('P', 'F', 'R','C','O') and M.is_trns_accepted=true)\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", typeS, "'    \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n            -\r\n             ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND M.trns_status = 'R' ))\r\n           -\r\n            ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and D.installment_status=false and d.approver_stage='F'\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", typeS, "'    \r\n            and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n          -\r\n          ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", typeS, "'   \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          \r\n           --transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false and D.purchase_type='", ItemType, "')\r\n\r\n            ----- deduct gift items from stock while saling by sabbir 24/2/21\r\n\t\t\t-\r\n\t\t\t(select coalesce(sum(gd.quantity),0) from gift_items_detail gd  where gd.item_id= ", ItemID, "  AND gd.purchase_type = '", ItemType, "' AND organization_id=", num, " AND \r\n            org_branch_id=", num1, " AND gd.is_deleted=false)\r\n\r\n           +\r\n            --transfer receive will be added(If receive from transfer then purchase table CHALLAN_TYPE = T)\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false and D.purchase_type='", ItemType, "')\r\n\r\n          ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable  FROM ITEM i \r\n\t      left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n          inner join item_category ic on ic.category_id = i.sub_category_id\r\n          WHERE I.ITEM_ID = ", ItemID, "  " };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetSaleAvailableStockNExcel(int ItemID, string ItemType, DateTime saleDate, string typeS)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] str = new object[] { " SELECT coalesce((\r\n            ( \r\n           \r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.purchase_type='", ItemType, "'    \r\n            and M.CHALLAN_TYPE in ('P', 'F', 'R','C','O'))\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", typeS, "'    \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n            -\r\n             ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND M.trns_status = 'I' ))\r\n           -\r\n            ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and D.installment_status=false \r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", typeS, "'    \r\n            and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n          -\r\n          ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", typeS, "'   \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          \r\n           --transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false and D.purchase_type='", ItemType, "')\r\n\r\n            ----- deduct gift items from stock while saling by sabbir 24/2/21\r\n\t\t\t-\r\n\t\t\t(select coalesce(sum(gd.quantity),0) from gift_items_detail gd  where gd.item_id= ", ItemID, "  AND gd.purchase_type = '", ItemType, "' AND organization_id=", num, " AND \r\n            org_branch_id=", num1, " AND gd.is_deleted=false)\r\n\r\n           +\r\n            --transfer receive will be added(If receive from transfer then purchase table CHALLAN_TYPE = T)\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false and D.purchase_type='", ItemType, "')\r\n\r\n          ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable  FROM ITEM i \r\n\t      left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n          inner join item_category ic on ic.category_id = i.sub_category_id\r\n          WHERE I.ITEM_ID = ", ItemID, "  " };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetSaleAvailableStockP(int ItemID, DateTime saleDate)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] str = new object[] { " SELECT coalesce((\r\n            ( \r\n           \r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "     \r\n            and M.CHALLAN_TYPE in ('P', 'F', 'R','C','O'))\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n            -\r\n             ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND M.trns_status = 'I' ))\r\n           -\r\n            ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') and D.installment_status=false \r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "   \r\n            and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n          -\r\n          ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "   \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          \r\n           --transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false)\r\n\r\n            ----- deduct gift items from stock while saling by sabbir 24/2/21\r\n\t\t\t-\r\n\t\t\t(select coalesce(sum(gd.quantity),0) from gift_items_detail gd  where gd.item_id= ", ItemID, " AND organization_id=", num, " AND \r\n            org_branch_id=", num1, " AND gd.is_deleted=false)\r\n\r\n           +\r\n            --transfer receive will be added(If receive from transfer then purchase table CHALLAN_TYPE = T)\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false)\r\n\r\n          ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable  FROM ITEM i \r\n\t      left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n          inner join item_category ic on ic.category_id = i.sub_category_id\r\n          WHERE I.ITEM_ID = ", ItemID, "  " };
                string str1 = string.Concat(str);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetSaleChallan17ReportData(short ItemID, DateTime fromDate, DateTime toDate)
        {
            object[] str = new object[] { "\r\n        SELECT  D.TRANS_TYPE, D.CHALLAN_ID,D.CHALLAN_NO,D.DATE_CHALLAN, D.ITEM_ID, D.ITEM_NAME,\r\n        D.OPENING_STOCK OPENING_STOCK, D.TOTAL_OPENING_PRICE TOTAL_OPENING_PRICE, D.QUANTITY, D.UNIT_PRICE, D.TOTAL_PRICE,  D.SALE_QTY, D.TOTAL_SALE_PRICE,\r\n        D.TOTAL_SD, D.TOTAL_VAT,\r\n        D.SALE_PARTY_NAME, D.PARTY_TIN, D.PARTY_ADDRESS\r\n\r\n        FROM (\r\n\r\n        --------------OPENING\r\n\r\n\r\n        SELECT 'O' TRANS_TYPE, 0 CHALLAN_ID, '' CHALLAN_NO, TO_DATE('01/01/1000','MM/dd/yyyy') DATE_CHALLAN, O.ITEM_ID, O.ITEM_NAME, \r\n        SUM(O.QUANTITY) OPENING_STOCK, SUM(O.TOTAL_PRICE) TOTAL_OPENING_PRICE,\r\n        0 QUANTITY, MAX(O.UNIT_PRICE) UNIT_PRICE, 0 TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n        0 TOTAL_SD,0 TOTAL_VAT,\r\n         '' SALE_PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS  \r\n \r\n         FROM (\r\n\r\n\r\n        -----OPENING PURCHASE\r\n\r\n        SELECT   PD.ITEM_ID, I.ITEM_NAME,  \r\n        (PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE)+(PD.SD)+(PD.VAT) TOTAL_PRICE, \r\n        (PD.SD) TOTAL_SD, (PD.VAT) TOTAL_VAT\r\n        FROM TRNS_PURCHASE_DETAIL PD \r\n        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\n        WHERE TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') < TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND \r\n        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type IN ( 'P', 'F') \r\n        AND PD.ITEM_ID = ", ItemID, "\r\n\r\n\r\n        UNION ALL\r\n\r\n        SELECT  PD.ITEM_ID, I.ITEM_NAME, \r\n        (PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE)+(PD.rbt_other_tax)+(PD.rbt_vat) TOTAL_PRICE, \r\n        (PD.rbt_other_tax) TOTAL_SD, (PD.rbt_vat) TOTAL_VAT\r\n        FROM trns_note_detail PD \r\n        INNER JOIN trns_note_MASTER PM ON PM.note_id = PD.note_id\r\n        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\n        WHERE TO_DATE(TO_CHAR(PM.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy') < TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.note_type in ( 'C' )\r\n        AND PD.ITEM_ID = ", ItemID, "\r\n\r\n        /*\r\n        UNION ALL\r\n\r\n        ----OPENING PRODUCTION\r\n\r\n\r\n        SELECT  PD.ITEM_ID, I.ITEM_NAME,  \r\n        (PD.QUANTITY) QUANTITY, PD.UNIT_PRICE, (PD.QUANTITY * PD.unit_price) TOTAL_PRICE, \r\n        0 TOTAL_SD, 0 TOTAL_VAT\r\n        FROM TRNS_PRODUCTION_DETAIL PD \r\n        INNER JOIN TRNS_PRODUCTION_MASTER PM ON PM.Production_id = PD.Production_id\r\n        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\n        WHERE TO_DATE(TO_CHAR(PM.Date_production, 'MM/dd/yyyy'), 'MM/dd/yyyy') < TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND \r\n        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.Material_type = 'P' \r\n        AND PD.ITEM_ID = ", ItemID, "\r\n        */\r\n\r\n\r\n        UNION ALL\r\n\r\n        ----OPENING SALE\r\n\r\n        SELECT SD.ITEM_ID, I.ITEM_NAME,\r\n        SUM(-SD.QUANTITY) QUANTITY, MAX(SD.nbr_confirm_price) UNIT_PRICE,  SUM(-SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE, \r\n        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n        left outer join TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n        WHERE SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type IN ( 'S', 'R', 'D') AND SD.ITEM_ID = ", ItemID, "\r\n        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') < TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n        GROUP BY SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME, PR.party_name, PR.PARTY_BIN, PR.PARTY_ADDRESS\r\n\r\n\r\n        ) O\r\n        GROUP BY  O.ITEM_ID, O.ITEM_NAME\r\n\r\n        ----------END OF OPENING\r\n\r\n        UNION ALL\r\n\r\n        -----PURCHASE\r\n\r\n        SELECT challan_type TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN, PD.ITEM_ID, I.ITEM_NAME,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n        (PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE)+(PD.SD)+(PD.VAT) TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n        (PD.SD) TOTAL_SD, (PD.VAT) TOTAL_VAT,\r\n         '' SALE_PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS  \r\n        FROM TRNS_PURCHASE_DETAIL PD \r\n        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\n        WHERE TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P', 'F' )\r\n        AND PD.ITEM_ID = ", ItemID, "\r\n\r\n\r\n        UNION ALL\r\n\r\n        SELECT PM.note_type TRANS_TYPE, PM.note_id CHALLAN_ID, PM.note_no CHALLAN_NO, PM.date_note DATE_CHALLAN, PD.ITEM_ID, I.ITEM_NAME,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n        (PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE)+(PD.rbt_other_tax)+(PD.rbt_vat) TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n        (PD.rbt_other_tax) TOTAL_SD, (PD.rbt_vat) TOTAL_VAT,\r\n         '' SALE_PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS  \r\n        FROM trns_note_detail PD \r\n        INNER JOIN trns_note_MASTER PM ON PM.note_id = PD.note_id\r\n        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\n        WHERE TO_DATE(TO_CHAR(PM.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(PM.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.note_type in ( 'C' )\r\n        AND PD.ITEM_ID =  ", ItemID, "\r\n\r\n        /*\r\n        UNION ALL\r\n\r\n        ----FINISHED GOODS PRODUCTION\r\n\r\n\r\n        SELECT 'P' TRANS_TYPE, PM.Production_id CHALLAN_ID, PM.Challan_batch_no CHALLAN_NO, PM.Date_production DATE_CHALLAN, PD.ITEM_ID, I.ITEM_NAME,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n        (PD.QUANTITY) QUANTITY, PD.UNIT_PRICE, (PD.QUANTITY * PD.unit_price) TOTAL_PRICE, 0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n        0 TOTAL_SD, 0 TOTAL_VAT,\r\n         '' SALE_PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS  \r\n        FROM TRNS_PRODUCTION_DETAIL PD \r\n        INNER JOIN TRNS_PRODUCTION_MASTER PM ON PM.Production_id = PD.Production_id\r\n        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\n        WHERE PM.Date_production >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND PM.Date_production <= TO_DATE('12/31/2012','MM/dd/yyyy') AND\r\n        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.Material_type = 'P' \r\n        AND PD.ITEM_ID = ", ItemID, "\r\n\r\n\r\n        SELECT 'F' TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN, PD.ITEM_ID, I.ITEM_NAME,  0 OPENING_STOCK, 0 TOTAL_OPENING_PRICE,\r\n        (PD.QUANTITY) QUANTITY, PD.ACTUAL_PRICE UNIT_PRICE, (PD.QUANTITY * PD.ACTUAL_PRICE)+(PD.SD)+(PD.VAT) TOTAL_PRICE,  0 SALE_QTY, 0  TOTAL_SALE_PRICE,\r\n        (PD.SD) TOTAL_SD, (PD.VAT) TOTAL_VAT,\r\n         '' SALE_PARTY_NAME, '' PARTY_TIN, '' PARTY_ADDRESS  \r\n        FROM TRNS_PURCHASE_DETAIL PD \r\n        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID\r\n        WHERE TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type = 'F' \r\n        AND PD.ITEM_ID = ", ItemID, "\r\n        */\r\n\r\n        UNION ALL\r\n\r\n        ----SALE\r\n\r\n        SELECT sm.challan_type TRANS_TYPE, SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME,0 OPENING_STOCK,0 TOTAL_OPENING_PRICE,\r\n        0 QUANTITY, MAX(SD.ACTUAL_PRICE) UNIT_PRICE, 0 TOTAL_PRICE, SUM(SD.QUANTITY) SALE_QTY, \r\n        /*SUM(SD.QUANTITY * SD.nbr_confirm_price)*/  SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_SALE_PRICE,\r\n        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT,\r\n         PR.party_name SALE_PARTY_NAME, PR.PARTY_BIN PARTY_TIN, PR.PARTY_ADDRESS\r\n        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n        left outer JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n        WHERE SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type IN ( 'S', 'R', 'D') AND SD.ITEM_ID = ", ItemID, "\r\n        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        GROUP BY sm.challan_type,SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME, PR.party_name, PR.PARTY_BIN, PR.PARTY_ADDRESS\r\n\r\n        /*\r\n        UNION ALL\r\n\r\n        ----RAW MATERIAL CONSUMPTION\r\n\r\n        SELECT 'R' TRANS_TYPE, SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME,0 OPENING_STOCK,0 TOTAL_OPENING_PRICE,\r\n        0 QUANTITY, MAX(SD.ACTUAL_PRICE) UNIT_PRICE, 0 TOTAL_PRICE, SUM(SD.QUANTITY) SALE_QTY, SUM(SD.QUANTITY * SD.nbr_confirm_price) TOTAL_SALE_PRICE,\r\n        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT,\r\n         PR.party_name SALE_PARTY_NAME, PR.PARTY_BIN PARTY_TIN, PR.PARTY_ADDRESS\r\n        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n        left outer JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n        WHERE SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type IN ('R') AND SD.ITEM_ID = ", ItemID, "\r\n        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        GROUP BY SM.CHALLAN_ID,SM.CHALLAN_NO,SM.DATE_CHALLAN, SD.ITEM_ID, I.ITEM_NAME, PR.party_name, PR.PARTY_BIN, PR.PARTY_ADDRESS\r\n        */\r\n\r\n\r\n        ) D \r\n\r\n        ORDER BY D.DATE_CHALLAN" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getSaleChallanIdbyAgreementNo(string agreementNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select coalesce(max(Challan_id),0) as Challan_id from trns_sale_master\r\n                            where aggrement_no='", agreementNo, "'");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return dataTable;
        }

        public DataTable GetSaleDayWiseSummaryReportInfo(DateTime fromDate, DateTime toDate, string Filter)
        {
            string[] loggedOrgName = new string[] { "----SALE SUMMARY REP: DATE WISE\r\n\r\n\t\t\tSELECT D.DATE_CHALLAN,SUM(D.TOTAL_PRICE) TOTAL_PRICE,\r\n                        SUM(D.TOTAL_SD) TOTAL_SD, SUM(D.TOTAL_VAT) TOTAL_VAT , SUM(D.TOTAL_PRICE_WITH_SD_VAT)  TOTAL_PRICE_WITH_SD_VAT,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM (\r\n                        \r\n\t\t\tSELECT TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') DATE_CHALLAN,\r\n                        SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,\r\n\t\t\t\t (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT) ) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_SALE_DETAIL PD \r\n                        INNER JOIN TRNS_SALE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        WHERE PD.is_source_tax_deduct = FALSE AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'S') \r\n                        GROUP BY TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') \r\n                     \r\n\t\t\tUNION ALL\r\n\r\n\t\t\tSELECT TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') DATE_CHALLAN,\r\n                        SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT,\r\n\t\t\t\t (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) /*- SUM(PD.SD) - SUM(PD.VAT)*/) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_SALE_DETAIL PD \r\n                        INNER JOIN TRNS_SALE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        WHERE PD.is_source_tax_deduct = TRUE AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'S') \r\n                        GROUP BY TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') \r\n                      \r\n\r\n                       ) D GROUP BY D.DATE_CHALLAN\r\n                           ORDER BY D.DATE_CHALLAN" };
            string str = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataTable(str);
        }

        public string getSaleReport(DataTable dt)
        {
            string str = "";
            str = string.Concat(str, "<h2 class='text-center'>Sales Summary Report</h2>");
            str = string.Concat(str, "<table class='table_report'>");
            str = string.Concat(str, "<thead> <tr><th>Item Name</th><th>UNIT CODE</th> <th>Quantity</th><th>TOTAL PRICE</th><th>TOTAL SD</th><th>TOTAL VAT</th><th>TOTAL PRICE WITH SD VAT</th></tr></thead>");
            str = string.Concat(str, "<tbody>");
            string str1 = "VATABLE SALE";
            string str2 = "Goods";
            string str3 = "Goods";
            float single = 0f;
            float single1 = 0f;
            float single2 = 0f;
            float single3 = 0f;
            float single4 = 0f;
            float single5 = 0f;
            float single6 = 0f;
            float single7 = 0f;
            float single8 = 0f;
            float single9 = 0f;
            float single10 = 0f;
            float single11 = 0f;
            float single12 = 0f;
            float single13 = 0f;
            float single14 = 0f;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (str1 != dt.Rows[i]["TRANS_TYPE"].ToString() || i == 0)
                {
                    if (i != 0)
                    {
                        object obj = str;
                        object[] objArray = new object[] { obj, "<tr class='bold-text'><td colspan='2' class='text-right'>Sub Total</td><td>", single, "</td><td>", single3, "</td><td>", single6, "</td><td>", single9, "</td><td>", single12, "</td></tr>" };
                        str = string.Concat(objArray);
                        single1 += single;
                        single4 += single3;
                        single7 += single6;
                        single10 += single9;
                        single13 += single12;
                        single = 0f;
                        single3 = 0f;
                        single6 = 0f;
                        single9 = 0f;
                        single12 = 0f;
                        object obj1 = str;
                        object[] objArray1 = new object[] { obj1, "<tr class='bold-text'><td colspan='2' class='text-right'>Total</td><td>", single1, "</td><td>", single4, "</td><td>", single7, "</td><td>", single10, "</td><td>", single13, "</td></tr>" };
                        str = string.Concat(objArray1);
                        single2 += single1;
                        single5 += single4;
                        single8 += single7;
                        float single15 = single10;
                        single11 = single15;
                        single11 = single15;
                        single14 += single13;
                        single1 = 0f;
                        single4 = 0f;
                        single7 = 0f;
                        single10 = 0f;
                        single13 = 0f;
                    }
                    object obj2 = str;
                    object[] item = new object[] { obj2, "<tr class='bold-text'><td colspan='7' style='background:#cfc;'>", dt.Rows[i]["TRANS_TYPE"], "</td></tr>" };
                    str = string.Concat(item);
                    str1 = dt.Rows[i]["TRANS_TYPE"].ToString();
                    str = string.Concat(str, "<tr class='bold-text'><td colspan='7' style='background:#C9DFF3;'>", str3, "</td></tr>");
                    str2 = dt.Rows[i]["item_type"].ToString();
                    if (str3 != str2)
                    {
                        object obj3 = str;
                        object[] item1 = new object[] { obj3, "<tr class='bold-text'><td colspan='7' style='background:#C9DFF3;'>", dt.Rows[i]["item_type"], "</td></tr>" };
                        str = string.Concat(item1);
                    }
                }
                if (str2 != dt.Rows[i]["item_type"].ToString())
                {
                    object obj4 = str;
                    object[] objArray2 = new object[] { obj4, "<tr class='bold-text'><td colspan='2' class='text-right'>Sub Total</td><td>", single, "</td><td>", single3, "</td><td>", single6, "</td><td>", single9, "</td><td>", single12, "</td></tr>" };
                    str = string.Concat(objArray2);
                    single1 += single;
                    single4 += single3;
                    single7 += single6;
                    single10 += single9;
                    single13 += single12;
                    single = 0f;
                    single3 = 0f;
                    single6 = 0f;
                    single9 = 0f;
                    single12 = 0f;
                    object obj5 = str;
                    object[] item2 = new object[] { obj5, "<tr class='bold-text'><td colspan='7' style='background:#C9DFF3;'>", dt.Rows[i]["item_type"], "</td></tr>" };
                    str = string.Concat(item2);
                    str2 = dt.Rows[i]["item_type"].ToString();
                }
                str = string.Concat(str, "<tr>");
                object obj6 = str;
                object[] item3 = new object[] { obj6, "<td>", dt.Rows[i]["ITEM_NAME"], "</td>" };
                str = string.Concat(item3);
                object obj7 = str;
                object[] objArray3 = new object[] { obj7, "<td>", dt.Rows[i]["UNIT_CODE"], "</td>" };
                str = string.Concat(objArray3);
                object obj8 = str;
                object[] item4 = new object[] { obj8, "<td>", dt.Rows[i]["QUANTITY"], "</td>" };
                str = string.Concat(item4);
                object obj9 = str;
                object[] objArray4 = new object[] { obj9, "<td>", dt.Rows[i]["TOTAL_PRICE"], "</td>" };
                str = string.Concat(objArray4);
                object obj10 = str;
                object[] item5 = new object[] { obj10, "<td>", dt.Rows[i]["TOTAL_SD"], "</td>" };
                str = string.Concat(item5);
                object obj11 = str;
                object[] objArray5 = new object[] { obj11, "<td>", dt.Rows[i]["TOTAL_VAT"], "</td>" };
                str = string.Concat(objArray5);
                object obj12 = str;
                object[] item6 = new object[] { obj12, "<td>", dt.Rows[i]["TOTAL_PRICE_WITH_SD_VAT"], "</td>" };
                str = string.Concat(item6);
                str = string.Concat(str, "</tr>");
                single += float.Parse(dt.Rows[i]["QUANTITY"].ToString());
                single3 += float.Parse(dt.Rows[i]["TOTAL_PRICE"].ToString());
                single6 += float.Parse(dt.Rows[i]["TOTAL_SD"].ToString());
                single9 += float.Parse(dt.Rows[i]["TOTAL_VAT"].ToString());
                single12 += float.Parse(dt.Rows[i]["TOTAL_PRICE_WITH_SD_VAT"].ToString());
            }
            object obj13 = str;
            object[] objArray6 = new object[] { obj13, "<tr class='bold-text'><td colspan='2' class='text-right'>Sub Total</td><td>", single, "</td><td>", single3, "</td><td>", single6, "</td><td>", single9, "</td><td>", single12, "</td></tr>" };
            str = string.Concat(objArray6);
            single1 += single;
            single4 += single3;
            single7 += single6;
            single10 += single9;
            single13 += single12;
            single = 0f;
            single3 = 0f;
            single6 = 0f;
            single9 = 0f;
            single12 = 0f;
            object obj14 = str;
            object[] objArray7 = new object[] { obj14, "<tr class='bold-text'><td colspan='2' class='text-right'>Total</td><td>", single1, "</td><td>", single4, "</td><td>", single7, "</td><td>", single10, "</td><td>", single13, "</td></tr>" };
            str = string.Concat(objArray7);
            single2 += single1;
            single5 += single4;
            single8 += single7;
            single11 += single10;
            single14 += single13;
            single1 = 0f;
            single4 = 0f;
            single7 = 0f;
            single13 = 0f;
            object obj15 = str;
            object[] objArray8 = new object[] { obj15, "<tr style='background:#00AFF0;height:50px;' class='bold-text'><td colspan='2' class='text-right'>Grand Total</td><td>", single2, "</td><td>", single5, "</td><td>", single8, "</td><td>", single11, "</td><td>", single14, "</td></tr>" };
            str = string.Concat(objArray8);
            single2 = 0f;
            str = string.Concat(str, "</tbody>");
            str = string.Concat(str, "</table>");
            return str;
        }

        public DataTable GetSaleStatementReportInfo(short ItemID, DateTime fromDate, DateTime toDate, string challanNo, string Filter)
        {
            string str = "";
            string str1 = "";
            if (ItemID > 0)
            {
                str = string.Concat(" I.ITEM_ID = ", ItemID, " and ");
            }
            if (challanNo != "")
            {
                str1 = string.Concat(" PM.CHALLAN_NO = '", challanNo, "' and ");
            }
            string[] loggedOrgName = new string[] { "----SALE DETAIL REP: DATE, ITEM, CHALLAN WISE\r\n\r\n\t\t\tSELECT TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') DATE_CHALLAN, PM.CHALLAN_ID, PM.CHALLAN_NO,\r\n\t\t\t PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, PD.DETAIL_ID, PD.actual_price UNIT_PRICE,\r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        /*CASE WHEN PD.is_source_tax_deduct = TRUE THEN SUM(-PD.SD) ELSE SUM(PD.SD) END*/ SUM(PD.SD) TOTAL_SD, \r\n                        /*CASE WHEN PD.is_source_tax_deduct = TRUE THEN SUM(-PD.VAT) ELSE SUM(PD.VAT) END*/ SUM(PD.VAT) TOTAL_VAT ,\r\n                        CASE WHEN PD.is_source_tax_deduct = TRUE \r\n\t\t\t\tTHEN (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) /*- SUM(PD.SD) - SUM(PD.VAT)*/ )\r\n\t\t\t\tELSE (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT) ) \r\n\t\t\t\tEND TOTAL_PRICE_WITH_SD_VAT,\r\n                         CASE WHEN PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE AND PM.trans_type = 'L'  THEN 'LOCAL' \r\n\t\t\tWHEN PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE AND PM.trans_type = 'E'  THEN 'EXPORT' \r\n\t\t\tWHEN PD.is_source_tax_deduct = TRUE  AND PD.IS_EXEMPTED= FALSE   THEN 'SOURCE VAT DEDUCTED' \r\n\t\t\tWHEN PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= TRUE THEN 'EXEMPTED' \r\n\t\t\tWHEN PD.is_source_tax_deduct = FALSE  AND PD.is_rebatable= TRUE THEN 'REBATABLE'\r\n\t\t\t ELSE 'OTHER' END TRANS_TYPE,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_SALE_MASTER PM \r\n                      INNER JOIN TRNS_SALE_DETAIL PD  ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                       INNER JOIN  ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                       INNER JOIN  ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, str1, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                       PM.IS_DELETED = FALSE  AND PM.challan_type in ( 'S') AND PM.TRANS_TYPE != 'D'\r\n                        GROUP BY PM.CHALLAN_ID, PM.CHALLAN_NO,TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy'), PD.DETAIL_ID,PD.actual_price,\r\n                        PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE,PD.is_source_tax_deduct,PD.IS_EXEMPTED,PD.is_rebatable,PM.trans_type\r\n                       --ORDER BY TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy'),I.ITEM_NAME \r\n\r\nunion all \r\n\r\n                       SELECT TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') DATE_CHALLAN, PM.CHALLAN_ID, PM.CHALLAN_NO,\r\n\t\t\t 0 ITEM_ID, '' ITEM_NAME,0 UNIT_ID,'' UNIT_CODE, 0 DETAIL_ID,0 UNIT_PRICE,\r\n                      0 QUANTITY, 0 TOTAL_PRICE, 0 TOTAL_SD, 0 TOTAL_VAT, 0 TOTAL_PRICE_WITH_SD_VAT, 'DISCARDED due to ' ||PM.Remarks  TRANS_TYPE,\r\n            '", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n\t\t\tFROM TRNS_SALE_MASTER PM\r\n\t\t\t WHERE ", str1, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                       PM.IS_DELETED = FALSE  AND PM.challan_type in ( 'S') AND PM.TRANS_TYPE = 'D' " };
            string str2 = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataTable(str2);
        }

        public DataTable GetSaleSummaryReportInfo(short ItemID, short partyID, string invoiceNumber, DateTime fromDate, DateTime toDate)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            if (ItemID > 0)
            {
                str = string.Concat(" I.ITEM_ID = ", ItemID, " and ");
            }
            if (partyID > 0)
            {
                str1 = string.Concat("SM.Party_id =", partyID, " and ");
            }
            str2 = string.Concat("SM.challan_no LIKE'%", invoiceNumber.ToString(), "%' and ");
            string[] strArrays = new string[] { "\r\n                        SELECT 'VATABLE SALE' TRANS_TYPE,'Goods' item_type, SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                       WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='I'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= FALSE\r\n                        --AND SM.trans_type = 'L'\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.Item_type\r\n                        HAVING SUM(SD.SD) + SUM(SD.VAT) > 0\r\n\r\n\t\t\t            UNION ALL\r\n                \r\n                        SELECT 'VATABLE SALE' TRANS_TYPE,'Service' item_type, SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                       WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='S' or I.item_type='U'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= FALSE\r\n                        --AND SM.trans_type = 'L'\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.Item_type\r\n                        HAVING SUM(SD.SD) + SUM(SD.VAT) > 0\r\n           UNION ALL\r\n\t\t\t\r\n                        SELECT 'NON VATABLE SALE' TRANS_TYPE,'Goods' item_type ,SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                         WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='I'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= FALSE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type\r\n                        HAVING    SUM(SD.SD) + SUM(SD.VAT) = 0\r\n\r\n                        UNION ALL\r\n\t\t\t\r\n                        SELECT 'NON VATABLE SALE' TRANS_TYPE,'Service' item_type ,SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                         WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='S' or I.item_type='U'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= FALSE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type\r\n                        HAVING    SUM(SD.SD) + SUM(SD.VAT) = 0\r\n\r\n              UNION ALL\r\n\t\t\t\r\n                        SELECT 'EXEMPTED' TRANS_TYPE,'Goods' item_type , SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='I'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= TRUE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type\r\n                        \r\n                        UNION ALL\r\n\t\t\t\r\n                        SELECT 'EXEMPTED' TRANS_TYPE,'Service' item_type , SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='S' or I.item_type='U'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= TRUE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type\r\n\r\n              UNION ALL\r\n\t\t\t\r\n                        SELECT 'VAT DEDUCTED AT SOURCE' TRANS_TYPE,'Goods' item_type, SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) /*- SUM(SD.SD) - SUM(SD.VAT)*/ TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='I'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = TRUE  AND SD.IS_EXEMPTED= FALSE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type\r\n                        \r\n                        UNION ALL\r\n\t\t\t\r\n                        SELECT 'VAT DEDUCTED AT SOURCE' TRANS_TYPE,'Service' item_type, SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) /*- SUM(SD.SD) - SUM(SD.VAT)*/ TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, str1, str2, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='S' or I.item_type='U'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = TRUE  AND SD.IS_EXEMPTED= FALSE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type" };
            string str3 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str3);
        }

        public DataTable GetSaleTypeSummaryReportInfo(short ItemID, DateTime fromDate, DateTime toDate, string Filter)
        {
            string str = "";
            if (ItemID > 0)
            {
                str = string.Concat(" I.ITEM_ID = ", ItemID, " and ");
            }
            string[] loggedOrgName = new string[] { "SELECT 'VATABLE SALE' TRANS_TYPE, SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT,\r\n                        CASE SM.TRANS_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'E' THEN 'EXPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') \r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= FALSE AND SD.IS_REBATABLE = FALSE\r\n                        GROUP BY  SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,SM.TRANS_TYPE\r\n                        HAVING SUM(SD.SD) + SUM(SD.VAT) > 0\r\n\r\n\t\t\tUNION ALL\r\n\t\t\t\r\n                        SELECT 'NON VATABLE SALE' TRANS_TYPE, SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT,\r\n                         CASE SM.TRANS_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'E' THEN 'EXPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') \r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= FALSE AND SD.IS_REBATABLE = FALSE\r\n                        GROUP BY  SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,SM.TRANS_TYPE\r\n                        HAVING    SUM(SD.SD) + SUM(SD.VAT) = 0\r\n\r\n                        UNION ALL\r\n\t\t\t\r\n                        SELECT 'EXEMPTED' TRANS_TYPE, SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT,\r\n                         CASE SM.TRANS_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'E' THEN 'EXPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') \r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= TRUE AND SD.IS_REBATABLE = FALSE\r\n                        GROUP BY SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                         SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,SM.TRANS_TYPE\r\n\r\n                        UNION ALL\r\n\t\t\t\r\n                        SELECT 'SOURCE VAT DEDUCTED' TRANS_TYPE, SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) /* - SUM(SD.SD) - SUM(SD.VAT) */ TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, /*SUM(-SD.VAT)*/ SUM(SD.VAT) TOTAL_VAT,\r\n                         CASE SM.TRANS_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'E' THEN 'EXPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') \r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = TRUE  AND SD.IS_EXEMPTED= FALSE AND SD.IS_REBATABLE = FALSE\r\n                        GROUP BY  SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,SM.TRANS_TYPE\r\n\r\n                        UNION ALL\r\n\t\t\t\r\n                        SELECT 'REBATABLE' TRANS_TYPE, SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                         SUM(SD.QUANTITY * SD.ACTUAL_PRICE) + SUM(SD.SD) + SUM(SD.VAT) TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT,\r\n                         CASE SM.TRANS_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'E' THEN 'EXPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') \r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = FALSE  AND SD.IS_EXEMPTED= FALSE AND SD.IS_REBATABLE = TRUE\r\n                        GROUP BY  SM.CHALLAN_ID, SM.CHALLAN_NO, SM.DATE_CHALLAN,\r\n                        SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,SM.TRANS_TYPE" };
            string str1 = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable getSaleUnitPrice(int itemID)
        {
            object[] objArray = new object[] { "select sale_unit_price as sale_unit_price from trns_purchase_detail where item_id = ", itemID, " AND sale_unit_price > 0 AND challan_id = (select max(challan_id) from trns_purchase_detail where item_id = ", itemID, " AND sale_unit_price > 0)" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getSaleUnitPriceForProperty1(int itemID, int property1Id, int property2Id, int property3Id)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                if (property1Id > 0)
                {
                    str = string.Concat(str, " AND property_id1=", property1Id);
                }
                if (property2Id > 0)
                {
                    str = string.Concat(str, " AND property_id2=", property2Id);
                }
                if (property3Id > 0)
                {
                    str = string.Concat(str, " AND property_id3=", property3Id);
                }
                object[] objArray = new object[] { "select sale_unit_price as sale_unit_price from trns_purchase_detail where item_id = ", itemID, " AND sale_unit_price > 0 AND challan_id = (select max(challan_id) from trns_purchase_detail where item_id = ", itemID, " ", str, " AND sale_unit_price > 0)" };
                string str1 = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getSDLocalPurchasebyItemId(int itemId)
        {
            string str = string.Concat("select * from item_tax_values                         \r\n                        where item_id =", itemId, " and is_tran_local=true AND IS_CURRENT = TRUE AND IS_DELETED=FALSE and tax_id=3");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getSDRateByItem(string itemName)
        {
            string str = string.Concat("select tax_id,tax_value from item_tax_values itv\r\n                        inner join item i on i.Item_id = itv.Item_id\r\n                        where upper(i.Item_name) ='", itemName, "' and itv.is_tran_sale=true and itv.is_deleted=false and tax_id=3");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getSDSalebyItemId(int itemId)
        {
            string str = string.Concat("select * from item_tax_values                         \r\n                        where item_id =", itemId, " and is_tran_sale=true AND IS_CURRENT = TRUE AND IS_DELETED=FALSE and tax_id=3");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetStockPropertyWise(short ItemID, string ItemType, DateTime saleDate, short property1, short property2, short property3, short property4, short property5, string strCondition)
        {
            DataTable dataTable;
            try
            {
                string str = "";
                string empty = string.Empty;
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                if (property1 > 0)
                {
                    object obj = str;
                    object[] objArray = new object[] { obj, " AND (D.property_id1 = ", property1, " OR D.property_id2 = ", property1, " OR D.property_id3 = ", property1, " OR D.property_id4 = ", property1, " OR D.property_id5 = ", property1, ")" };
                    str = string.Concat(objArray);
                }
                if (property2 > 0)
                {
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, " AND (D.property_id1 = ", property2, " OR D.property_id2 = ", property2, " OR D.property_id3 = ", property2, " OR D.property_id4 = ", property2, " OR D.property_id5 = ", property2, ")" };
                    str = string.Concat(objArray1);
                }
                if (property3 > 0)
                {
                    object obj2 = str;
                    object[] objArray2 = new object[] { obj2, " AND (D.property_id1 = ", property3, " OR D.property_id2 = ", property3, " OR D.property_id3 = ", property3, " OR D.property_id4 = ", property3, " OR D.property_id5 = ", property3, ")" };
                    str = string.Concat(objArray2);
                }
                if (property4 > 0)
                {
                    object obj3 = str;
                    object[] objArray3 = new object[] { obj3, " AND (D.property_id1 = ", property4, " OR D.property_id2 = ", property4, " OR D.property_id3 = ", property4, " OR D.property_id4 = ", property4, " OR D.property_id5 = ", property4, ")" };
                    str = string.Concat(objArray3);
                }
                if (property5 > 0)
                {
                    object obj4 = str;
                    object[] objArray4 = new object[] { obj4, " AND (D.property_id1 = ", property5, " OR D.property_id2 = ", property5, " OR D.property_id3 = ", property5, " OR D.property_id4 = ", property5, " OR D.property_id5 = ", property5, ")" };
                    str = string.Concat(objArray4);
                }
                object[] str1 = new object[] { " SELECT coalesce((\r\n            ( \r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.purchase_type='", ItemType, "'    \r\n            and M.CHALLAN_TYPE in ('P', 'F', 'R','C','O','T')\r\n            --AND (D.property_id1 = ", property1, " OR D.property_id2 = ", property1, " OR D.property_id3 = ", property1, " OR  D.property_id4 = ", property1, " OR  D.property_id5 = ", property1, ")\r\n            ", str, "\r\n            )\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", ItemType, "'    \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'P' \r\n            and M.NOTE_TYPE in ('D') and D.Status = 'P' \r\n            --AND (D.property_id1 = ", property1, " OR D.property_id2 = ", property1, " OR D.property_id3 = ", property1, " OR  D.property_id4 = ", property1, " OR  D.property_id5 = ", property1, ")\r\n            ", str, "\r\n            )\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.STATUS = 'I' \r\n            --AND (D.property_id1 = ", property1, " OR D.property_id2 = ", property1, " OR D.property_id3 = ", property1, " OR  D.property_id4 = ", property1, " OR  D.property_id5 = ", property1, ")\r\n            ", str, "\r\n            ))\r\n            -\r\n            ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", ItemType, "'    \r\n            and M.CHALLAN_TYPE in ('S', 'F', 'R') \r\n            --AND (D.property_id1 = ", property1, " OR D.property_id2 = ", property1, " OR D.property_id3 = ", property1, " OR  D.property_id4 = ", property1, " OR  D.property_id5 = ", property1, ")\r\n            ", str, "\r\n            )\r\n            )\r\n            +\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.type_p = '", ItemType, "'   \r\n            --and M.NOTE_TYPE in ('C','D') and D.Status = 'S' )\r\n            and M.NOTE_TYPE in ('C') and D.Status = 'S' \r\n            --AND (D.property_id1 = ", property1, " OR D.property_id2 = ", property1, " OR D.property_id3 = ", property1, " OR  D.property_id4 = ", property1, " OR  D.property_id5 = ", property1, ")\r\n            ", str, "\r\n            )\r\n           --transfer issue will be deducted\r\n           --still in transfer dynamic property not implemented as Ruhul Bhai told it no need now, think in future\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", saleDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false)\r\n            ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable  FROM ITEM i \r\n\t        left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n            inner join item_category ic on ic.category_id = i.sub_category_id\r\n            WHERE I.ITEM_ID = ", ItemID, "  " };
                empty = string.Concat(str1);
                dataTable = this.connDB.GetDataTable(empty);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getUnitIdbyUnit(string unitname)
        {
            string str = string.Concat("SELECT unit_id from item_unit where is_deleted=false and upper(unit_code)='", unitname, "' ");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getValueadditionIdbyValueAddition(string ValueAddition)
        {
            string str = string.Concat("select code_id_d,code_name from app_code_detail where Is_deleted='false' and code_id_m=8 and  Trim(upper(code_name)) ='", ValueAddition, "' ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getValueadditionNonIdbyValueAddition(string ValueAddition)
        {
            string str = string.Concat("select code_id_d,code_name from app_code_detail where Is_deleted='false' and code_id_m=14 and  Trim(upper(code_name)) ='", ValueAddition, "' ");
            return this.DBUtil.GetDataTable(str);
        }

        public string getVatDeductedSourceReport(DataTable dt)
        {
            string str = "";
            str = string.Concat(str, "<h2 class='text-center'>Vat Deducted Source Report</h2>");
            str = string.Concat(str, "<table class='table_report'>");
            str = string.Concat(str, "<thead> <tr><th>Item Name</th><th>UNIT CODE</th> <th>Quantity</th><th>TOTAL PRICE</th><th>TOTAL SD</th><th>TOTAL VAT</th><th>TOTAL PRICE WITH SD VAT</th></tr></thead>");
            str = string.Concat(str, "<tbody>");
            string str1 = "VAT DEDUCTED AT SOURCE";
            string str2 = "Goods";
            string str3 = "Goods";
            float single = 0f;
            float single1 = 0f;
            float single2 = 0f;
            float single3 = 0f;
            float single4 = 0f;
            float single5 = 0f;
            float single6 = 0f;
            float single7 = 0f;
            float single8 = 0f;
            float single9 = 0f;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (str1 != dt.Rows[i]["TRANS_TYPE"].ToString() || i == 0)
                {
                    if (i != 0)
                    {
                        object obj = str;
                        object[] objArray = new object[] { obj, "<tr class='bold-text'><td colspan='2' class='text-right'>Sub Total</td><td>", single, "</td><td>", single2, "</td><td>", single4, "</td><td>", single6, "</td><td>", single8, "</td></tr>" };
                        str = string.Concat(objArray);
                        single1 += single;
                        single3 += single2;
                        single5 += single4;
                        single7 += single6;
                        single9 += single8;
                        single = 0f;
                        single2 = 0f;
                        single4 = 0f;
                        single6 = 0f;
                        single8 = 0f;
                        object obj1 = str;
                        object[] objArray1 = new object[] { obj1, "<tr class='bold-text'><td colspan='2' class='text-right'>Total</td><td>", single1, "</td><td>", single3, "</td><td>", single5, "</td><td>", single7, "</td><td>", single9, "</td></tr>" };
                        str = string.Concat(objArray1);
                        single1 = 0f;
                        single3 = 0f;
                        single5 = 0f;
                        single7 = 0f;
                        single9 = 0f;
                    }
                    object obj2 = str;
                    object[] item = new object[] { obj2, "<tr class='bold-text'><td colspan='7' style='background:#cfc;'>", dt.Rows[i]["TRANS_TYPE"], "</td></tr>" };
                    str = string.Concat(item);
                    str1 = dt.Rows[i]["TRANS_TYPE"].ToString();
                    str = string.Concat(str, "<tr class='bold-text'><td colspan='7' style='background:#C9DFF3;'>", str3, "</td></tr>");
                    str2 = dt.Rows[i]["item_type"].ToString();
                    if (str3 != str2)
                    {
                        object obj3 = str;
                        object[] item1 = new object[] { obj3, "<tr class='bold-text'><td colspan='7' style='background:#C9DFF3;'>", dt.Rows[i]["item_type"], "</td></tr>" };
                        str = string.Concat(item1);
                    }
                }
                if (str2 != dt.Rows[i]["item_type"].ToString())
                {
                    object obj4 = str;
                    object[] objArray2 = new object[] { obj4, "<tr class='bold-text'><td colspan='2' class='text-right'>Sub Total</td><td>", single, "</td><td>", single2, "</td><td>", single4, "</td><td>", single6, "</td><td>", single8, "</td></tr>" };
                    str = string.Concat(objArray2);
                    single1 += single;
                    single3 += single2;
                    single5 += single4;
                    single7 += single6;
                    single9 += single8;
                    single = 0f;
                    single2 = 0f;
                    single4 = 0f;
                    single6 = 0f;
                    single8 = 0f;
                    object obj5 = str;
                    object[] item2 = new object[] { obj5, "<tr class='bold-text'><td colspan='7' style='background:#C9DFF3;'>", dt.Rows[i]["item_type"], "</td></tr>" };
                    str = string.Concat(item2);
                    str2 = dt.Rows[i]["item_type"].ToString();
                }
                str = string.Concat(str, "<tr>");
                object obj6 = str;
                object[] item3 = new object[] { obj6, "<td>", dt.Rows[i]["ITEM_NAME"], "</td>" };
                str = string.Concat(item3);
                object obj7 = str;
                object[] objArray3 = new object[] { obj7, "<td>", dt.Rows[i]["UNIT_CODE"], "</td>" };
                str = string.Concat(objArray3);
                object obj8 = str;
                object[] item4 = new object[] { obj8, "<td>", dt.Rows[i]["QUANTITY"], "</td>" };
                str = string.Concat(item4);
                object obj9 = str;
                object[] objArray4 = new object[] { obj9, "<td>", dt.Rows[i]["TOTAL_PRICE"], "</td>" };
                str = string.Concat(objArray4);
                object obj10 = str;
                object[] item5 = new object[] { obj10, "<td>", dt.Rows[i]["TOTAL_SD"], "</td>" };
                str = string.Concat(item5);
                object obj11 = str;
                object[] objArray5 = new object[] { obj11, "<td>", dt.Rows[i]["TOTAL_VAT"], "</td>" };
                str = string.Concat(objArray5);
                object obj12 = str;
                object[] item6 = new object[] { obj12, "<td>", dt.Rows[i]["TOTAL_PRICE_WITH_SD_VAT"], "</td>" };
                str = string.Concat(item6);
                str = string.Concat(str, "</tr>");
                single += float.Parse(dt.Rows[i]["QUANTITY"].ToString());
                single2 += float.Parse(dt.Rows[i]["TOTAL_PRICE"].ToString());
                single4 += float.Parse(dt.Rows[i]["TOTAL_SD"].ToString());
                single6 += float.Parse(dt.Rows[i]["TOTAL_VAT"].ToString());
                single8 += float.Parse(dt.Rows[i]["TOTAL_PRICE_WITH_SD_VAT"].ToString());
            }
            object obj13 = str;
            object[] objArray6 = new object[] { obj13, "<tr class='bold-text'><td colspan='2' class='text-right'>Sub Total</td><td>", single, "</td><td>", single2, "</td><td>", single4, "</td><td>", single6, "</td><td>", single8, "</td></tr>" };
            str = string.Concat(objArray6);
            single1 += single;
            single3 += single2;
            single5 += single4;
            single7 += single6;
            single9 += single8;
            single = 0f;
            single2 = 0f;
            single4 = 0f;
            single6 = 0f;
            single8 = 0f;
            object obj14 = str;
            object[] objArray7 = new object[] { obj14, "<tr class='bold-text'><td colspan='2' class='text-right'>Total</td><td>", single1, "</td><td>", single3, "</td><td>", single5, "</td><td>", single7, "</td><td>", single9, "</td></tr>" };
            str = string.Concat(objArray7);
            single1 = 0f;
            single3 = 0f;
            single5 = 0f;
            single9 = 0f;
            str = string.Concat(str, "</tbody>");
            str = string.Concat(str, "</table>");
            return str;
        }

        public DataTable GetVatDeductedSourceReportInfo(short ItemID, DateTime fromDate, DateTime toDate)
        {
            string str = "";
            if (ItemID > 0)
            {
                str = string.Concat(" I.ITEM_ID = ", ItemID, " and ");
            }
            string[] strArrays = new string[] { "\t\t\t\r\n                        SELECT 'VAT DEDUCTED AT SOURCE' TRANS_TYPE,'Goods' item_type, SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) /*- SUM(SD.SD) - SUM(SD.VAT)*/ TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='I'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = TRUE  AND SD.IS_EXEMPTED= FALSE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type\r\n                        \r\n                 UNION ALL\r\n\t\t\t\r\n                        SELECT 'VAT DEDUCTED AT SOURCE' TRANS_TYPE,'Service' item_type, SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID,U.UNIT_CODE, \r\n                         SUM(SD.QUANTITY) QUANTITY, SUM(SD.QUANTITY * SD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(SD.QUANTITY * SD.ACTUAL_PRICE) /*- SUM(SD.SD) - SUM(SD.VAT)*/ TOTAL_PRICE_WITH_SD_VAT,\r\n                        SUM(SD.SD) TOTAL_SD, SUM(SD.VAT) TOTAL_VAT\r\n                        FROM TRNS_SALE_MASTER SM INNER JOIN  TRNS_SALE_DETAIL SD ON SM.CHALLAN_ID = SD.CHALLAN_ID\r\n                        INNER JOIN TRNS_PARTY PR ON PR.PARTY_ID = SM.PARTY_ID \r\n                        INNER JOIN ITEM I ON I.ITEM_ID = SD.ITEM_ID\r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " SM.IS_DELETED = FALSE AND SD.IS_DELETED = FALSE AND SM.challan_type in ( 'S') and I.item_type='S' or I.item_type='U'\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         AND SD.is_source_tax_deduct = TRUE  AND SD.IS_EXEMPTED= FALSE\r\n                        GROUP BY  SD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE, PR.party_name, PR.PARTY_TIN, PR.PARTY_ADDRESS, I.UNIT_ID, UNIT_CODE,I.item_type" };
            string str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable getVATLocalPurchasebyItemId(int itemId)
        {
            string str = string.Concat("select * from item_tax_values                         \r\n                        where item_id =", itemId, " and is_tran_local=true AND IS_CURRENT = TRUE AND IS_DELETED=FALSE and tax_id=4");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getVATRateByItem(string itemName)
        {
            string str = string.Concat("select tax_id,tax_value from item_tax_values itv\r\n                        inner join item i on i.Item_id = itv.Item_id\r\n                        where upper(i.Item_name) ='", itemName, "' and itv.is_tran_sale=true and itv.is_deleted=false and tax_id=4");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getVATsalebyItemId(int itemId)
        {
            string str = string.Concat("select * from item_tax_values                         \r\n                        where item_id =", itemId, " and is_tran_sale=true AND IS_CURRENT = TRUE AND IS_DELETED=FALSE and tax_id=4");
            return this.DBUtil.GetDataTable(str);
        }

        public bool InsertAdjustSD(adjustSDDAO objsd, int chno)
        {
            DataTable dataTable = new DataTable();
            ArrayList arrayLists = new ArrayList();
            object[] applicationDate = new object[] { "update trns_sale_detail set application_date='", objsd.Application_date, "', export_date='", objsd.Export_date, "',sd_refund_amount=", objsd.Refund_SD, " where challan_id=", chno, " " };
            arrayLists.Add(string.Concat(applicationDate));
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertConsumableSaleItem(ArrayList arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                SaleGiftDetailDAON saleGiftDetailDAON = new SaleGiftDetailDAON();
                saleGiftDetailDAON = (SaleGiftDetailDAON)arrDeailDAO[i];
                object[] challanID = new object[] { "INSERT INTO gift_items_detail(\r\n            challan_id, row_no, parent_item_id, item_id, unit_id,quantity, price, discounted_sd_rate, discounted_sd, discounted_vat_rate, discounted_vat, remarks, date_challan, user_id_insert,organization_id, org_branch_id,date_consumable_challan,purchase_type)\r\n            VALUES (", saleGiftDetailDAON.ChallanID, ", ", saleGiftDetailDAON.RowNo, ", ", saleGiftDetailDAON.GiftParentItemID, ", ", saleGiftDetailDAON.ItemID, ",  ", saleGiftDetailDAON.UnitId, ", ", saleGiftDetailDAON.GiftQuantity, ", ", saleGiftDetailDAON.ItemPriceBDT, ", ", saleGiftDetailDAON.DiscountSDRate, ", ", saleGiftDetailDAON.DiscountSD, ", ", saleGiftDetailDAON.DiscountVatRate, ", ", saleGiftDetailDAON.DiscountVat, ", '", saleGiftDetailDAON.Remarks, "', to_timestamp('", saleGiftDetailDAON.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", saleGiftDetailDAON.UserIdInsert, ", ", saleGiftDetailDAON.OrganizationID, ", ", saleGiftDetailDAON.OrgBranchID, ", to_timestamp('", saleGiftDetailDAON.ConsumableChallanDate.ToString("MM/dd/yyyy HH:mm"), "', 'MM/dd/yyyy HH24:MI'), '", saleGiftDetailDAON.TypeP, "' )" };
                arrayLists.Add(string.Concat(challanID));
            }
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertInstallmentPayment(ArrayList arrDeailDAO, ArrayList arrchk)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            InstalmentSchedule instalmentSchedule = new InstalmentSchedule();
            InstalmentScheduleChk instalmentScheduleChk = new InstalmentScheduleChk();
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                instalmentScheduleChk = (InstalmentScheduleChk)arrchk[i];
                instalmentSchedule = (InstalmentSchedule)arrDeailDAO[i];
                object[] str = new object[55];
                str[0] = "INSERT INTO installment_scheduler(schedule_no,item_id,party_id,agreement_no,no_of_year,no_of_month,loan_from_date,loan_to_date,\r\n        down_payment,down_vat,total_payment,total_vat,product_price,pricedec_price,interest_rate,interest_amount,vat_per_month,interest_per_month,installment_with_interest_per_month,installment_without_interest_per_month,status,discount_pct,discount_amount,product_type,organization_id,org_branch_reg_id,is_paid)\r\n        VALUES ('";
                str[1] = instalmentSchedule.scheduleNo;
                str[2] = "',";
                str[3] = instalmentSchedule.itemId;
                str[4] = ",";
                str[5] = instalmentSchedule.partyId;
                str[6] = ", '";
                str[7] = instalmentSchedule.agreementNo;
                str[8] = "', '";
                str[9] = instalmentSchedule.loanYear;
                str[10] = "','";
                str[11] = instalmentSchedule.loanMonth;
                str[12] = "',\r\n         to_timestamp('";
                DateTime dateTime = Convert.ToDateTime(instalmentSchedule.loanFromDate);
                str[13] = dateTime.ToString("MM/dd/yyyy HH:mm");
                str[14] = "','MM/dd/yyyy HH24:MI'),to_timestamp('";
                DateTime dateTime1 = Convert.ToDateTime(instalmentSchedule.loanToDate);
                str[15] = dateTime1.ToString("MM/dd/yyyy HH:mm");
                str[16] = "','MM/dd/yyyy HH24:MI'),\r\n         '";
                str[17] = instalmentSchedule.downPayment;
                str[18] = "', '";
                str[19] = instalmentSchedule.downPaymentVAT;
                str[20] = "', '";
                str[21] = instalmentSchedule.TotalPrice;
                str[22] = "', '";
                str[23] = instalmentSchedule.TotalVAT;
                str[24] = "', '";
                str[25] = instalmentSchedule.productPrice;
                str[26] = "',\r\n          '";
                str[27] = instalmentSchedule.priceDecPrice;
                str[28] = "', '";
                str[29] = instalmentSchedule.interestRate;
                str[30] = "', '";
                str[31] = instalmentSchedule.interestAmount;
                str[32] = "', '";
                str[33] = instalmentSchedule.restvat;
                str[34] = "', '";
                str[35] = instalmentSchedule.restInterest;
                str[36] = "', '";
                str[37] = instalmentSchedule.paymentWithInterest;
                str[38] = "', '";
                str[39] = instalmentSchedule.paymentWithoutInterest;
                str[40] = "', '";
                str[41] = instalmentSchedule.status;
                str[42] = "', '";
                str[43] = instalmentSchedule.discountPct;
                str[44] = "', '";
                str[45] = instalmentSchedule.discountAmount;
                str[46] = "', '";
                str[47] = instalmentSchedule.itemType;
                str[48] = "', ";
                str[49] = num;
                str[50] = ", ";
                str[51] = num1;
                str[52] = ",";
                str[53] = instalmentScheduleChk.isPaid;
                str[54] = ")";
                arrayLists.Add(string.Concat(str));
            }
            object[] challanBookID = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", instalmentSchedule.ChallanBookID, " and page_no = ", instalmentSchedule.ChallanPageNo };
            arrayLists.Add(string.Concat(challanBookID));
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public string InsertSaleData(SaleMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            DBUtility dBUtility = this.connDB;
            object[] year = new object[] { "SELECT coalesce(max(cg_challan_no),0)+1 from trns_sale_master group by challan_year, challan_type having challan_year = ", null, null, null, null };
            year[1] = objMDAO.ChallanDate.Year;
            year[2] = " and challan_type = '";
            year[3] = objMDAO.ChallanType;
            year[4] = "'";
            objMDAO.ComGenChallanNo = Convert.ToInt16(dBUtility.GetSingleValue(string.Concat(year)));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (Party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.TransactionType == 'E')
            {
                str = ", date_export, export_bill_no, bank_id, branch_id";
                object[] exportBillNo = new object[] { " ,TO_DATE('", null, null, null, null, null, null, null };
                exportBillNo[1] = objMDAO.ExportDate.ToString("MM/dd/yyyy");
                exportBillNo[2] = "','MM/dd/yyyy'), '";
                exportBillNo[3] = objMDAO.ExportBillNo;
                exportBillNo[4] = "', ";
                exportBillNo[5] = objMDAO.BankID;
                exportBillNo[6] = ", ";
                exportBillNo[7] = objMDAO.BranchID;
                str1 = string.Concat(exportBillNo);
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str2 = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str3 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType == 'R' || objMDAO.TransactionType == 'D')
            {
                str4 = " null,  null, ";
            }
            else
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str4 = string.Concat(objArray);
            }
            if (objMDAO.TransactionType == 'D')
            {
                object[] challanPageDiscardReasonM = new object[] { ", ", objMDAO.ChallanPageDiscardReason_m, ",  ", objMDAO.ChallanPageDiscardReason_d };
                str5 = string.Concat(challanPageDiscardReasonM);
            }
            else
            {
                str5 = ", null,  null ";
            }
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(",'", objMDAO.AggrementNo, "'");
            }
            if (objMDAO.Discountm > new decimal(0))
            {
                empty2 = ",discount";
                empty3 = string.Concat(",", objMDAO.Discountm);
            }
            if (objMDAO.Discount_pctm > new decimal(0))
            {
                empty4 = ",discount_pct";
                empty5 = string.Concat(",", objMDAO.Discount_pctm);
            }
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] challanID = new object[] { "INSERT INTO trns_sale_master(Challan_id,org_branch_reg_id,cg_challan_no,challan_year, \r\n             Organization_id,payment_method,cash_amount,bank_amount,credit_amount,is_payment_finished,payment_info, challan_type, sale_type, trans_type, date_challan, ", str2, "\r\n            date_goods_delivery, Party_id , ultimate_destination,   User_id_insert, challan_no, Remarks,service_charge,type, challan_page_discard_reason_m, challan_page_discard_reason_d ", str, " ", empty, " ", empty2, " ", empty4, ")\r\n            VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.ComGenChallanNo, ", ", objMDAO.ChallanDate.Year, ", ", num, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.IsPaymentFinished, ",'", objMDAO.PaymentInfo, "', '", objMDAO.ChallanType, "', '", objMDAO.SaleType, "', '", objMDAO.TransactionType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str3, str4, "  \r\n                   '", objMDAO.UltimateDestination, "',  ", objMDAO.UserIdInsert, ",\r\n                   '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "',", objMDAO.ServiceCharge, ",'", objMDAO.SalesProductType, "' ", str5, str1, " ", empty1, " ", empty3, " ", empty5, ")" };
            arrayLists.Add(string.Concat(challanID));
            arrayLists = this.AddDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            if (objMDAO.ChallanType == 'S')
            {
                if (objMDAO.TransactionType != 'D')
                {
                    object[] challanBookID = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(challanBookID));
                }
                else
                {
                    object[] remarks = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objMDAO.Remarks, "' where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(remarks));
                }
            }
            DataTable dataTable = new DataTable();
            this.connDB.ExecuteBatchDML(arrayLists);
            return objMDAO.ChallanID.ToString();
        }

        public string InsertSaleDataForApproval(SaleMasterDAON objMDAO, ArrayList arrDeailDAO, SaleAdditionalMasterDAON objAMDAO, ArrayList arrsch)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            objAMDAO.ChallanID = objMDAO.ChallanID;
            DBUtility dBUtility = this.connDB;
            object[] year = new object[] { "SELECT coalesce(max(cg_challan_no),0)+1 from trns_sale_master group by challan_year, challan_type having challan_year = ", null, null, null, null };
            year[1] = objMDAO.ChallanDate.Year;
            year[2] = " and challan_type = '";
            year[3] = objMDAO.ChallanType;
            year[4] = "'";
            objMDAO.ComGenChallanNo = Convert.ToInt16(dBUtility.GetSingleValue(string.Concat(year)));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (Party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.TransactionType == 'E')
            {
                str = ", date_export, export_bill_no, bank_id, branch_id";
                object[] exportBillNo = new object[] { " ,TO_DATE('", null, null, null, null, null, null, null };
                exportBillNo[1] = objMDAO.ExportDate.ToString("MM/dd/yyyy");
                exportBillNo[2] = "','MM/dd/yyyy'), '";
                exportBillNo[3] = objMDAO.ExportBillNo;
                exportBillNo[4] = "', ";
                exportBillNo[5] = objMDAO.BankID;
                exportBillNo[6] = ", ";
                exportBillNo[7] = objMDAO.BranchID;
                str1 = string.Concat(exportBillNo);
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str2 = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str3 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType == 'R' || objMDAO.TransactionType == 'D')
            {
                str4 = " null,  null, ";
            }
            else
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str4 = string.Concat(objArray);
            }
            if (objMDAO.TransactionType == 'D')
            {
                object[] challanPageDiscardReasonM = new object[] { ", ", objMDAO.ChallanPageDiscardReason_m, ",  ", objMDAO.ChallanPageDiscardReason_d };
                str5 = string.Concat(challanPageDiscardReasonM);
            }
            else
            {
                str5 = ", null,  null ";
            }
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(",'", objMDAO.AggrementNo, "'");
            }
            if (objMDAO.Discountm > new decimal(0))
            {
                empty2 = ",discount";
                empty3 = string.Concat(",", objMDAO.Discountm);
            }
            if (objMDAO.Discount_pctm > new decimal(0))
            {
                empty4 = ",discount_pct";
                empty5 = string.Concat(",", objMDAO.Discount_pctm);
            }
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt16(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] challanID = new object[] { "INSERT INTO trns_sale_master(Challan_id,org_branch_reg_id,cg_challan_no,challan_year, is_approved, approval_ref_no, is_final_saved,\r\n             Organization_id,payment_method,cash_amount,bank_amount,credit_amount,is_payment_finished,payment_info, challan_type, sale_type, trans_type, date_challan, ", str2, "\r\n            date_goods_delivery, Party_id , ultimate_destination,   User_id_insert, challan_no, Remarks,service_charge,type, challan_page_discard_reason_m, challan_page_discard_reason_d ", str, " ", empty, " ", empty2, " ", empty4, ",is_installment)\r\n            VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.ComGenChallanNo, ", ", objMDAO.ChallanDate.Year, ", '", objMDAO.isApproved, "', '", objMDAO.approvalRefNo, "', ", objMDAO.isFinalSaved, ", ", num, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.IsPaymentFinished, ",'", objMDAO.PaymentInfo, "', '", objMDAO.ChallanType, "', '", objMDAO.SaleType, "', '", objMDAO.TransactionType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str3, str4, "  \r\n                   '", objMDAO.UltimateDestination, "',  ", objMDAO.UserIdInsert, ",\r\n                   '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "',", objMDAO.ServiceCharge, ",'", objMDAO.SalesProductType, "' ", str5, str1, " ", empty1, " ", empty3, " ", empty5, ",", objMDAO.Isinstallment, ")" };
            arrayLists.Add(string.Concat(challanID));
            object[] challanID1 = new object[] { "INSERT INTO credit_transac_history(scroll_id, challan_id,org_branch_reg_id, challan_no, current_balance, payment_amount, \r\n                            balance_due, payment_type,cash_amount,bank_amount, payment_date,  \r\n                            date_insert,status,payment_status,organization_id,payment_info,vat_amount,sd_amount)\r\n                            VALUES(nextval('scroll_id'), ", objMDAO.ChallanID, ",", num1, ",'", objMDAO.ChallanNo, "',", objMDAO.currentBalance, ",", objMDAO.downPaymment, ",\r\n                            ", objMDAO.dueBalance, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),'S',", 1, ",", num, ",'", objMDAO.PaymentInfo, "',", objMDAO.vatPaid, ",", objMDAO.sdPaid, ")" };
            arrayLists.Add(string.Concat(challanID1));
            arrayLists = this.AddDeailInsertSQLN(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            if (arrsch.Count > 0)
            {
                foreach (InstalmentSchedule instalmentSchedule in arrsch)
                {
                    InstalmentSchedule instalmentSchedule1 = new InstalmentSchedule()
                    {
                        restAmount = instalmentSchedule.restAmount,
                        restvat = instalmentSchedule.restvat,
                        restsd = instalmentSchedule.restsd,
                        restait = instalmentSchedule.restait,
                        tenurePeriod = instalmentSchedule.tenurePeriod,
                        noOfInstalment = instalmentSchedule.noOfInstalment,
                        scheduleNo = instalmentSchedule.scheduleNo
                    };
                    object[] aggrementNo = new object[21];
                    aggrementNo[0] = "INSERT INTO installment_scheduler(Challan_id,party_id,agreement_no,no_of_installment,tenure_date,amount,vat,sd,ait,schedule_no)\r\n        VALUES ( ";
                    aggrementNo[1] = objMDAO.ChallanID;
                    aggrementNo[2] = ",'";
                    aggrementNo[3] = objMDAO.PartyID;
                    aggrementNo[4] = "', '";
                    aggrementNo[5] = objMDAO.AggrementNo;
                    aggrementNo[6] = "', '";
                    aggrementNo[7] = instalmentSchedule1.noOfInstalment;
                    aggrementNo[8] = "', to_timestamp('";
                    DateTime dateTime = Convert.ToDateTime(instalmentSchedule1.tenurePeriod);
                    aggrementNo[9] = dateTime.ToString("MM/dd/yyyy HH:mm");
                    aggrementNo[10] = "','MM/dd/yyyy HH24:MI'), '";
                    aggrementNo[11] = instalmentSchedule1.restAmount;
                    aggrementNo[12] = "', \r\n             '";
                    aggrementNo[13] = instalmentSchedule1.restvat;
                    aggrementNo[14] = "', '";
                    aggrementNo[15] = instalmentSchedule1.restsd;
                    aggrementNo[16] = "', '";
                    aggrementNo[17] = instalmentSchedule1.restait;
                    aggrementNo[18] = "', '";
                    aggrementNo[19] = instalmentSchedule1.scheduleNo;
                    aggrementNo[20] = "')";
                    arrayLists.Add(string.Concat(aggrementNo));
                }
            }
            DataTable dataTable = new DataTable();
            this.connDB.ExecuteBatchDML(arrayLists);
            return objMDAO.ChallanID.ToString();
        }

        public string InsertSaleDataN(SaleMasterDAON objMDAO, ArrayList arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            DBUtility dBUtility = this.connDB;
            object[] year = new object[] { "SELECT coalesce(max(cg_challan_no),0)+1 from trns_sale_master group by challan_year, challan_type having challan_year = ", null, null, null, null };
            year[1] = objMDAO.ChallanDate.Year;
            year[2] = " and challan_type = '";
            year[3] = objMDAO.ChallanType;
            year[4] = "'";
            objMDAO.ComGenChallanNo = Convert.ToInt16(dBUtility.GetSingleValue(string.Concat(year)));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (Party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.TransactionType == 'E')
            {
                str = ", date_export, export_bill_no, bank_id, branch_id";
                object[] exportBillNo = new object[] { " ,TO_DATE('", null, null, null, null, null, null, null };
                exportBillNo[1] = objMDAO.ExportDate.ToString("MM/dd/yyyy");
                exportBillNo[2] = "','MM/dd/yyyy'), '";
                exportBillNo[3] = objMDAO.ExportBillNo;
                exportBillNo[4] = "', ";
                exportBillNo[5] = objMDAO.BankID;
                exportBillNo[6] = ", ";
                exportBillNo[7] = objMDAO.BranchID;
                str1 = string.Concat(exportBillNo);
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str2 = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str3 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType == 'R' || objMDAO.TransactionType == 'D')
            {
                str4 = " null,  null, ";
            }
            else
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str4 = string.Concat(objArray);
            }
            if (objMDAO.TransactionType == 'D')
            {
                object[] challanPageDiscardReasonM = new object[] { ", ", objMDAO.ChallanPageDiscardReason_m, ",  ", objMDAO.ChallanPageDiscardReason_d };
                str5 = string.Concat(challanPageDiscardReasonM);
            }
            else
            {
                str5 = ", null,  null ";
            }
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(",'", objMDAO.AggrementNo, "'");
            }
            if (objMDAO.Discountm > new decimal(0))
            {
                empty2 = ",discount";
                empty3 = string.Concat(",", objMDAO.Discountm);
            }
            if (objMDAO.Discount_pctm > new decimal(0))
            {
                empty4 = ",discount_pct";
                empty5 = string.Concat(",", objMDAO.Discount_pctm);
            }
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] challanID = new object[] { "INSERT INTO trns_sale_master(Challan_id,org_branch_reg_id,cg_challan_no,challan_year, \r\n             Organization_id,payment_method,cash_amount,bank_amount,credit_amount,is_payment_finished,payment_info, challan_type, sale_type, trans_type, date_challan, ", str2, "\r\n            date_goods_delivery, Party_id , ultimate_destination,   User_id_insert, challan_no, Remarks,service_charge,type, challan_page_discard_reason_m, challan_page_discard_reason_d ", str, " ", empty, " ", empty2, " ", empty4, ")\r\n            VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.ComGenChallanNo, ", ", objMDAO.ChallanDate.Year, ", ", num, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.IsPaymentFinished, ",'", objMDAO.PaymentInfo, "', '", objMDAO.ChallanType, "', '", objMDAO.SaleType, "', '", objMDAO.TransactionType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str3, str4, "  \r\n                   '", objMDAO.UltimateDestination, "',  ", objMDAO.UserIdInsert, ",\r\n                   '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "',", objMDAO.ServiceCharge, ",'", objMDAO.SalesProductType, "' ", str5, str1, " ", empty1, " ", empty3, " ", empty5, ")" };
            arrayLists.Add(string.Concat(challanID));
            arrayLists = this.AddDeailInsertSQLN(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            if (objMDAO.ChallanType == 'S')
            {
                if (objMDAO.TransactionType != 'D')
                {
                    object[] challanBookID = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(challanBookID));
                }
                else
                {
                    object[] remarks = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objMDAO.Remarks, "' where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(remarks));
                }
            }
            DataTable dataTable = new DataTable();
            this.connDB.ExecuteBatchDML(arrayLists);
            return objMDAO.ChallanID.ToString();
        }

        public string InsertSaleDataWithOrWithoutGift(SaleMasterDAON objMDAO, ArrayList arrDeailDAO, ArrayList giftArrDetail, Dictionary<int, int> chkadditionalPropId)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            DBUtility dBUtility = this.connDB;
            object[] year = new object[] { "SELECT coalesce(max(cg_challan_no),0)+1 from trns_sale_master group by challan_year, challan_type having challan_year = ", null, null, null, null };
            year[1] = objMDAO.ChallanDate.Year;
            year[2] = " and challan_type = '";
            year[3] = objMDAO.ChallanType;
            year[4] = "'";
            objMDAO.ComGenChallanNo = Convert.ToInt16(dBUtility.GetSingleValue(string.Concat(year)));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (Party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.TransactionType == 'E')
            {
                str = ", date_export, export_bill_no, bank_id, branch_id,port_code_id,no_of_item,total_pack,CPC";
                object[] objArray = new object[] { " ,TO_DATE('", objMDAO.ExportDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'), '", objMDAO.ExportBillNo, "', ", objMDAO.BankID, ", ", objMDAO.BranchID, ",", objMDAO.portcodeId, ", ", objMDAO.noofItem, ", ", objMDAO.totalPack, ", '", objMDAO.CPC, "' " };
                str1 = string.Concat(objArray);
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str2 = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str3 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType == 'R' || objMDAO.TransactionType == 'D')
            {
                str4 = " null,  null, ";
            }
            else
            {
                object[] partyID1 = new object[] { " to_timestamp('", null, null, null, null };
                partyID1[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                partyID1[2] = "','MM/dd/yyyy HH24:MI'),  ";
                partyID1[3] = objMDAO.PartyID;
                partyID1[4] = ", ";
                str4 = string.Concat(partyID1);
            }
            if (objMDAO.TransactionType == 'D')
            {
                object[] challanPageDiscardReasonM = new object[] { ", ", objMDAO.ChallanPageDiscardReason_m, ",  ", objMDAO.ChallanPageDiscardReason_d };
                str5 = string.Concat(challanPageDiscardReasonM);
            }
            else
            {
                str5 = ", null,  null ";
            }
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(",'", objMDAO.AggrementNo, "'");
            }
            if (objMDAO.Discountm > new decimal(0))
            {
                empty2 = ",discount";
                empty3 = string.Concat(",", objMDAO.Discountm);
            }
            if (objMDAO.Discount_pctm > new decimal(0))
            {
                empty4 = ",discount_pct";
                empty5 = string.Concat(",", objMDAO.Discount_pctm);
            }
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] challanID = new object[] { "INSERT INTO trns_sale_master(Challan_id,org_branch_reg_id,cg_challan_no,challan_year, \r\n             Organization_id,payment_method,cash_amount,bank_amount,credit_amount, total_bill_amount, total_vat,  paid_vat, total_vds, paid_vds, total_ait, paid_ait, is_payment_finished,payment_info, challan_type, sale_type, trans_type, date_challan, ", str2, "\r\n            date_goods_delivery, Party_id , ultimate_destination,   User_id_insert, challan_no, Remarks,service_charge,type, challan_page_discard_reason_m, challan_page_discard_reason_d ", str, " ", empty, " ", empty2, " ", empty4, ")\r\n            VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.ComGenChallanNo, ", ", objMDAO.ChallanDate.Year, ", ", num, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.TotalBillAmount, ",", objMDAO.TotalVat, ",", objMDAO.PaidVat, ",", objMDAO.TotalVds, ",", objMDAO.PaidVds, ",", objMDAO.TotalAit, ",", objMDAO.PaidAit, ",", objMDAO.IsPaymentFinished, ",'", objMDAO.PaymentInfo, "', '", objMDAO.ChallanType, "', '", objMDAO.SaleType, "', '", objMDAO.TransactionType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str3, str4, "  \r\n                   '", objMDAO.UltimateDestination, "',  ", objMDAO.UserIdInsert, ",\r\n                   '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "',", objMDAO.ServiceCharge, ",'", objMDAO.SalesProductType, "' ", str5, str1, " ", empty1, " ", empty3, " ", empty5, ")" };
            arrayLists.Add(string.Concat(challanID));
            if (objMDAO.TotalVds > 0)
            {
                object[] userIdInsert = new object[] { "INSERT INTO trns_sale_vds_detail(\r\n            sale_challan_id, sale_challan_no,row_no,payment_amount,vds_amount,vds_date_challan,organization_id, org_branch_id, user_id_insert)\r\n            VALUES(", objMDAO.ChallanID, ",'", objMDAO.ChallanNo, "', ", 1, ",", objMDAO.CashAmount + objMDAO.BankAmount, ",", objMDAO.PaidVds, ", to_timestamp('", null, null, null, null, null, null, null, null };
                userIdInsert[11] = objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm");
                userIdInsert[12] = "','MM/dd/yyyy HH24:MI'), ";
                userIdInsert[13] = num;
                userIdInsert[14] = ", ";
                userIdInsert[15] = num1;
                userIdInsert[16] = ", ";
                userIdInsert[17] = objMDAO.UserIdInsert;
                userIdInsert[18] = ") ";
                arrayLists.Add(string.Concat(userIdInsert));
            }
            if (chkadditionalPropId.Count > 0)
            {
                foreach (int key in chkadditionalPropId.Keys)
                {
                    int num2 = Convert.ToInt32(key);
                    object[] challanID1 = new object[] { "Update trns_production_rcv_additional set status='S', sale_id=", objMDAO.ChallanID, ",date_challan=to_timestamp('", null, null, null };
                    challanID1[3] = objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm");
                    challanID1[4] = "','MM/dd/yyyy HH24:MI') where additional_info_id=";
                    challanID1[5] = num2;
                    arrayLists.Add(string.Concat(challanID1));
                }
            }
            arrayLists = this.AddDeailInsertSQLN(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            if (giftArrDetail.Count > 0)
            {
                arrayLists = this.AddGiftDetailInsertSQL(arrayLists, giftArrDetail, objMDAO.ChallanID, objMDAO.ChallanDate);
            }
            if (objMDAO.ChallanType == 'S')
            {
                if (objMDAO.TransactionType != 'D')
                {
                    object[] challanBookID = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(challanBookID));
                }
                else
                {
                    object[] remarks = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objMDAO.Remarks, "' where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(remarks));
                }
            }
            if (objMDAO.CreditAmount > 0)
            {
                object[] objArray1 = new object[] { "INSERT INTO credit_transac_history(scroll_id, challan_id,org_branch_reg_id, challan_no, current_balance, payment_amount, \r\n                            balance_due, payment_type,cash_amount,bank_amount, payment_date,  \r\n                            date_insert,status,payment_status,organization_id,payment_info,proportion_vds,proportion_ait,amount_without_vds)\r\n                            VALUES(nextval('scroll_id'),", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",'", objMDAO.ChallanNo, "',", objMDAO.CashAmount + objMDAO.BankAmount + objMDAO.CreditAmount, ",", objMDAO.CashAmount + objMDAO.BankAmount, "\r\n                            \r\n                            ,", objMDAO.CreditAmount, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                           to_timestamp('", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),'P',", 0, ",", num, ",'", objMDAO.PaymentInfo, "', ", objMDAO.proportionVAT, ",", objMDAO.proportionAIT, ",", objMDAO.priceWithoutVDS, ")" };
                arrayLists.Add(string.Concat(objArray1));
            }
            DataTable dataTable = new DataTable();
            if (!this.connDB.ExecuteBatchDML(arrayLists))
            {
                return null;
            }
            return objMDAO.ChallanID.ToString();
        }

        public bool InsertSaleExcelData(SaleMasterDAON objMDAO, SaleDetailDAON arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            DBUtility dBUtility = this.connDB;
            object[] year = new object[] { "SELECT coalesce(max(cg_challan_no),0)+1 from trns_sale_master group by challan_year, challan_type having challan_year = ", null, null, null, null };
            year[1] = objMDAO.ChallanDate.Year;
            year[2] = " and challan_type = '";
            year[3] = objMDAO.ChallanType;
            year[4] = "'";
            objMDAO.ComGenChallanNo = Convert.ToInt16(dBUtility.GetSingleValue(string.Concat(year)));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (Party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.TransactionType == 'E')
            {
                str = ", date_export, export_bill_no, bank_id, branch_id";
                object[] exportBillNo = new object[] { " ,TO_DATE('", null, null, null, null, null, null, null };
                exportBillNo[1] = objMDAO.ExportDate.ToString("MM/dd/yyyy");
                exportBillNo[2] = "','MM/dd/yyyy'), '";
                exportBillNo[3] = objMDAO.ExportBillNo;
                exportBillNo[4] = "', ";
                exportBillNo[5] = objMDAO.BankID;
                exportBillNo[6] = ", ";
                exportBillNo[7] = objMDAO.BranchID;
                str1 = string.Concat(exportBillNo);
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str2 = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str3 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType == 'R' || objMDAO.TransactionType == 'D')
            {
                str4 = " null,  null, ";
            }
            else
            {
                DateTime deliveryDate = objMDAO.DeliveryDate;
                str4 = string.Concat(" to_timestamp('", deliveryDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI') ");
            }
            if (objMDAO.TransactionType == 'D')
            {
                object[] challanPageDiscardReasonM = new object[] { ", ", objMDAO.ChallanPageDiscardReason_m, ",  ", objMDAO.ChallanPageDiscardReason_d };
                str5 = string.Concat(challanPageDiscardReasonM);
            }
            else
            {
                str5 = ", null,  null ";
            }
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(",'", objMDAO.AggrementNo, "'");
            }
            if (objMDAO.Discountm > new decimal(0))
            {
                empty2 = ",discount";
                empty3 = string.Concat(",", objMDAO.Discountm);
            }
            if (objMDAO.Discount_pctm > new decimal(0))
            {
                empty4 = ",discount_pct";
                empty5 = string.Concat(",", objMDAO.Discount_pctm);
            }
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] challanID = new object[] { "INSERT INTO trns_sale_master(Challan_id,org_branch_reg_id,cg_challan_no,challan_year, \r\n             Organization_id,payment_method,cash_amount,bank_amount,credit_amount, total_bill_amount, total_vat,  paid_vat, total_vds, paid_vds, total_ait, paid_ait, is_payment_finished,payment_info, challan_type, sale_type, trans_type, date_challan, ", str2, "\r\n            date_goods_delivery, Party_id , ultimate_destination,   User_id_insert, challan_no, Remarks,service_charge,type, challan_page_discard_reason_m, challan_page_discard_reason_d ", str, " ", empty, " ", empty2, " ", empty4, ",invoice_no)\r\n            VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.ComGenChallanNo, ", ", objMDAO.ChallanDate.Year, ", ", num, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.TotalBillAmount, ",", objMDAO.TotalVat, ",", objMDAO.PaidVat, ",", objMDAO.TotalVds, ",", objMDAO.PaidVds, ",", objMDAO.TotalAit, ",", objMDAO.PaidAit, ",", objMDAO.IsPaymentFinished, ",'", objMDAO.PaymentInfo, "', '", objMDAO.ChallanType, "', '", objMDAO.SaleType, "', '", objMDAO.TransactionType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                       ", str3, str4, "  \r\n                  ,  ", objMDAO.PartyID, ", '", objMDAO.UltimateDestination, "',  ", objMDAO.UserIdInsert, ",\r\n                   '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "',", objMDAO.ServiceCharge, ",'B' ", str5, str1, " ", empty1, " ", empty3, " ", empty5, ", '", objMDAO.Invoice_No, "')" };
            arrayLists.Add(string.Concat(challanID));
            if (objMDAO.TotalVds > 0)
            {
                object[] userIdInsert = new object[] { "INSERT INTO trns_sale_vds_detail(\r\n            sale_challan_id, sale_challan_no,row_no,payment_amount,vds_amount,vds_date_challan,organization_id, org_branch_id, user_id_insert)\r\n            VALUES(", objMDAO.ChallanID, ",'", objMDAO.ChallanNo, "', ", 1, ",", objMDAO.CashAmount + objMDAO.BankAmount, ",", objMDAO.PaidVds, ", to_timestamp('", null, null, null, null, null, null, null, null };
                userIdInsert[11] = objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm");
                userIdInsert[12] = "','MM/dd/yyyy HH24:MI'), ";
                userIdInsert[13] = num;
                userIdInsert[14] = ", ";
                userIdInsert[15] = num1;
                userIdInsert[16] = ", ";
                userIdInsert[17] = objMDAO.UserIdInsert;
                userIdInsert[18] = ") ";
                arrayLists.Add(string.Concat(userIdInsert));
            }
            if (objMDAO.CreditAmount > 0)
            {
                object[] objArray = new object[] { "INSERT INTO credit_transac_history(scroll_id, challan_id,org_branch_reg_id, challan_no, current_balance, payment_amount, \r\n                            balance_due, payment_type,cash_amount,bank_amount, payment_date,  \r\n                            date_insert,status,payment_status,organization_id,payment_info,proportion_vds,proportion_ait,amount_without_vds)\r\n                            VALUES(nextval('scroll_id'),", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",'", objMDAO.ChallanNo, "',", objMDAO.CashAmount + objMDAO.BankAmount + objMDAO.CreditAmount, ",", objMDAO.CashAmount + objMDAO.BankAmount, "\r\n                            \r\n                            ,", objMDAO.CreditAmount, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                           to_timestamp('", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),'P',", 0, ",", num, ",'", objMDAO.PaymentInfo, "', ", objMDAO.proportionVAT, ",", objMDAO.proportionAIT, ",", objMDAO.priceWithoutVDS, ")" };
                arrayLists.Add(string.Concat(objArray));
            }
            arrayLists = this.AddDeailExcelData(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            if (objMDAO.ChallanType == 'S')
            {
                if (objMDAO.TransactionType != 'D')
                {
                    object[] challanBookID = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(challanBookID));
                }
                else
                {
                    object[] remarks = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objMDAO.Remarks, "' where challan_book_id = ", objMDAO.ChallanBookID, " and page_no = ", objMDAO.ChallanPageNo };
                    arrayLists.Add(string.Concat(remarks));
                }
            }
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertSaleExcelSameChallanData(SaleMasterDAON objMDAO, SaleDetailDAON objDetail)
        {
            ArrayList arrayLists = new ArrayList();
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue(string.Concat("SELECT  max(challan_id)  from trns_sale_master where invoice_no = '", objMDAO.Invoice_No, "'")));
            objDetail.RowNo = Convert.ToInt32(this.connDB.GetSingleValue(string.Concat("SELECT  max(row_no)+1  from trns_sale_detail where challan_id = ", objMDAO.ChallanID)));
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            str = " NULL";
            str1 = " NULL";
            str2 = " NULL";
            str3 = " NULL";
            str4 = " NULL";
            string str8 = "";
            str8 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_sale_detail WHERE ITEM_ID = '", objDetail.ItemID, "' ");
            if (objDetail.PropertyID1 != 0)
            {
                str = objDetail.PropertyID1.ToString();
                object obj = str8;
                object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", objDetail.PropertyID1, "' " };
                str8 = string.Concat(propertyID1);
            }
            if (objDetail.PropertyID2 != 0)
            {
                str1 = objDetail.PropertyID2.ToString();
                object obj1 = str8;
                object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", objDetail.PropertyID2, "' " };
                str8 = string.Concat(propertyID2);
            }
            if (objDetail.PropertyID3 != 0)
            {
                str2 = objDetail.PropertyID3.ToString();
                object obj2 = str8;
                object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", objDetail.PropertyID3, "' " };
                str8 = string.Concat(propertyID3);
            }
            if (objDetail.PropertyID4 != 0)
            {
                str3 = objDetail.PropertyID4.ToString();
                object obj3 = str8;
                object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", objDetail.PropertyID4, "' " };
                str8 = string.Concat(propertyID4);
            }
            if (objDetail.PropertyID5 != 0)
            {
                str4 = objDetail.PropertyID5.ToString();
                object obj4 = str8;
                object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", objDetail.PropertyID5, "' " };
                str8 = string.Concat(propertyID5);
            }
            str8 = string.Concat(str8, " ) ");
            if (objDetail.PriceId > 0)
            {
                objDetail.PriceId.ToString();
            }
            str5 = (objDetail.DetailID <= 0 ? "-99" : objDetail.DetailID.ToString());
            if (objDetail.itemSerials != "" && objDetail.itemSerials != null)
            {
                str6 = ", item_serials";
                str7 = string.Concat(",'", objDetail.itemSerials, "'");
            }
            object[] challanID = new object[] { "INSERT INTO trns_sale_detail(\r\n            Challan_id, row_no, Item_id", str6, ", property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, actual_price, \r\n            Sd, Vat,  User_id_insert, is_source_tax_deduct, lot_no, detail_id,\r\n            nbr_confirm_price,is_exempted,is_rebatable, sale_row_no,is_zero_rate,is_inexplicit_export,real_property,type_p,vat_rate,sd_rate,is_fixed_vat,is_truncated,is_mrp,discount_amt,discount_pct,net_bill,remarks,ait,property_quantity,sale_quantity,sale_unit,health_surcharge)\r\n            VALUES (", objMDAO.ChallanID, ", ", objDetail.RowNo, ", ", objDetail.ItemID, str7, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", objDetail.UnitID, ", ", objDetail.Quantity, ", ", objDetail.Unit_Price, ", ", objDetail.SD_Amount, ", ", objDetail.VAT_Amount, ", ", objDetail.UserIdInsert, ", \r\n              ", objDetail.IsSrcTAXDeduct, ", ", str8, ", '", str5, "',  ", objDetail.NBRPrice, ", ", objDetail.IsExempted, ", ", objDetail.IsRebatable, ", ", objDetail.SaleRowNo, ",", objDetail.IsZeroRate, ",", objDetail.isInexplicitExport, ",'0','", objDetail.TypeP, "',", objDetail.VAT_Rate, ",", objDetail.SD_Rate, ",", objDetail.IsFixed, ",", objDetail.IsTruncated, ",", objDetail.IsMrp, ",", objDetail.Discount, ",\r\n          ", objDetail.Discount_pct, ",", objDetail.Net_bill, ",'", objDetail.RemarksDetail, "',", objDetail.AIT, ",", objDetail.PropStk, ",", objDetail.Quantity, ",", objDetail.SaleUnitID, ",", objDetail.HealthCharge, " )" };
            arrayLists.Add(string.Concat(challanID));
            object[] totalBillAmount = new object[] { "Update trns_sale_master set \r\n         total_bill_amount=", objMDAO.TotalBillAmount, ",   cash_amount=", objMDAO.CashAmount, ",credit_amount=", objMDAO.CreditAmount, ",  total_vat=", objMDAO.TotalVat, ",  paid_vat=", objMDAO.PaidVat, ", total_vds=", objMDAO.TotalVds, ", \r\npaid_vds=", objMDAO.PaidVds, ", total_ait=", objMDAO.TotalAit, ", paid_ait=", objMDAO.PaidAit, "  where challan_id=", objMDAO.ChallanID, " " };
            arrayLists.Add(string.Concat(totalBillAmount));
            if (objMDAO.TotalVds > 0)
            {
                object[] cashAmount = new object[] { "Update trns_sale_vds_detail set  payment_amount=", objMDAO.CashAmount + objMDAO.BankAmount, ",vds_amount=", objMDAO.PaidVds, " where sale_challan_id=", objMDAO.ChallanID, " " };
                arrayLists.Add(string.Concat(cashAmount));
            }
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertTemplate(string description)
        {
            DataTable dataTable = new DataTable();
            string str = string.Concat("insert into CKEditor (Description) values ('", description, "')");
            return this.connDB.ExecuteDML(str);
        }

        public bool UpdateSale(string ApproveStage, ArrayList arrDeailDAO, int ChallanID)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                string str5 = "";
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                saleDetailDAON = (SaleDetailDAON)arrDeailDAO[i];
                str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_sale_detail WHERE ITEM_ID = '", saleDetailDAON.ItemID, "' ");
                if (saleDetailDAON.PropertyID1 != 0)
                {
                    str = saleDetailDAON.PropertyID1.ToString();
                    object obj = str5;
                    object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", saleDetailDAON.PropertyID1, "' " };
                    str5 = string.Concat(propertyID1);
                }
                if (saleDetailDAON.PropertyID2 != 0)
                {
                    str1 = saleDetailDAON.PropertyID2.ToString();
                    object obj1 = str5;
                    object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", saleDetailDAON.PropertyID2, "' " };
                    str5 = string.Concat(propertyID2);
                }
                if (saleDetailDAON.PropertyID3 != 0)
                {
                    str2 = saleDetailDAON.PropertyID3.ToString();
                    object obj2 = str5;
                    object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", saleDetailDAON.PropertyID3, "' " };
                    str5 = string.Concat(propertyID3);
                }
                if (saleDetailDAON.PropertyID4 != 0)
                {
                    str3 = saleDetailDAON.PropertyID4.ToString();
                    object obj3 = str5;
                    object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", saleDetailDAON.PropertyID4, "' " };
                    str5 = string.Concat(propertyID4);
                }
                if (saleDetailDAON.PropertyID5 != 0)
                {
                    str4 = saleDetailDAON.PropertyID5.ToString();
                    object obj4 = str5;
                    object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", saleDetailDAON.PropertyID5, "' " };
                    str5 = string.Concat(propertyID5);
                }
                str5 = string.Concat(str5, " ) ");
                if (saleDetailDAON.PriceId > 0)
                {
                    saleDetailDAON.PriceId.ToString();
                }
                if (saleDetailDAON.DetailID > 0)
                {
                    saleDetailDAON.DetailID.ToString();
                }
                if (saleDetailDAON.itemSerials != "" && saleDetailDAON.itemSerials != null)
                {
                    string.Concat(",'", saleDetailDAON.itemSerials, "'");
                }
                object[] itemID = new object[] { "Update  trns_sale_detail set \r\n             Item_id=", saleDetailDAON.ItemID, ", item_serials='", saleDetailDAON.itemSerials, "', property_id1=", str, ", property_id2=", str1, ", property_id3=", str2, ", \r\n            property_id4=", str3, ", property_id5=", str4, ", unit_id=", saleDetailDAON.UnitID, ", Quantity=", saleDetailDAON.Quantity, ", actual_price=", saleDetailDAON.UnitPrice, ", \r\n            Sd=", saleDetailDAON.SD, ", Vat=", saleDetailDAON.VAT, ", is_source_tax_deduct=", saleDetailDAON.IsSrcTAXDeduct, ", User_id_insert=", saleDetailDAON.UserIdInsert, ",   \r\n            nbr_confirm_price =", saleDetailDAON.NBRPrice, ",is_exempted=", saleDetailDAON.IsExempted, ",is_rebatable=", saleDetailDAON.IsRebatable, ", is_zero_rate=", saleDetailDAON.IsZeroRate, ",is_inexplicit_export=", saleDetailDAON.isInexplicitExport, ",\r\n           type_p='", saleDetailDAON.TypeP, "',vat_rate=", saleDetailDAON.VATRate, ",sd_rate=", saleDetailDAON.SDRate, ",is_fixed_vat=", saleDetailDAON.IsFixed, ",is_truncated=", saleDetailDAON.IsTruncated, ",is_mrp=", saleDetailDAON.IsMrp, ",\r\n            discount_amt=", saleDetailDAON.Discount, ",discount_pct=", saleDetailDAON.Discount_pct, ",net_bill=", saleDetailDAON.Net_bill, ",remarks='", saleDetailDAON.RemarksDetail, "',\r\n            ait=", saleDetailDAON.AIT, ",property_quantity=", saleDetailDAON.PropStk, ",sale_quantity=", saleDetailDAON.SaleQuantity, ",sale_unit=", saleDetailDAON.SaleUnitID, ",health_surcharge=", saleDetailDAON.HealthCharge, ",installment_status=", saleDetailDAON.installmentStatus, ",approver_stage='", saleDetailDAON.ApproveStage, "' where challan_id = ", ChallanID };
                arrayLists.Add(string.Concat(itemID));
                if (saleDetailDAON.scheduleId != 0)
                {
                    arrayLists.Add(string.Concat("update installment_scheduler set is_paid=true where scheduler_id=", saleDetailDAON.scheduleId));
                }
            }
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool UpdateSaleData(SaleMasterDAON objMDAO, int challanId)
        {
            DataTable dataTable = new DataTable();
            object[] challanNo = new object[] { "Update trns_sale_master set challan_no = '", objMDAO.ChallanNo, "',date_challan = to_timestamp('", null, null, null };
            challanNo[3] = objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm");
            challanNo[4] = "','MM/dd/yyyy HH24:MI'),is_final_saved=true where challan_id=";
            challanNo[5] = challanId;
            string str = string.Concat(challanNo);
            return this.connDB.ExecuteDML(str);
        }

        public string UpdateSaleDataForApproval(SaleMasterDAON objMDAO, ArrayList arrDeailDAO, SaleAdditionalMasterDAON objAMDAO, int challanId)
        {
            ArrayList arrayLists = new ArrayList();
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('sale_challan_id_seq')"));
            objAMDAO.ChallanID = objMDAO.ChallanID;
            DBUtility dBUtility = this.connDB;
            object[] year = new object[] { "SELECT coalesce(max(cg_challan_no),0)+1 from trns_sale_master group by challan_year, challan_type having challan_year = ", null, null, null, null };
            year[1] = objMDAO.ChallanDate.Year;
            year[2] = " and challan_type = '";
            year[3] = objMDAO.ChallanType;
            year[4] = "'";
            objMDAO.ComGenChallanNo = Convert.ToInt16(dBUtility.GetSingleValue(string.Concat(year)));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (Party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.TransactionType == 'E')
            {
                object[] exportBillNo = new object[] { " ,TO_DATE('", null, null, null, null, null, null, null };
                exportBillNo[1] = objMDAO.ExportDate.ToString("MM/dd/yyyy");
                exportBillNo[2] = "','MM/dd/yyyy'), '";
                exportBillNo[3] = objMDAO.ExportBillNo;
                exportBillNo[4] = "', ";
                exportBillNo[5] = objMDAO.BankID;
                exportBillNo[6] = ", ";
                exportBillNo[7] = objMDAO.BranchID;
                string.Concat(exportBillNo);
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType != 'R' && objMDAO.TransactionType != 'D')
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                string.Concat(objArray);
            }
            if (objMDAO.TransactionType == 'D')
            {
                object[] challanPageDiscardReasonM = new object[] { ", ", objMDAO.ChallanPageDiscardReason_m, ",  ", objMDAO.ChallanPageDiscardReason_d };
                string.Concat(challanPageDiscardReasonM);
            }
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                string.Concat(",'", objMDAO.AggrementNo, "'");
            }
            if (objMDAO.Discountm > new decimal(0))
            {
                string.Concat(",", objMDAO.Discountm);
            }
            if (objMDAO.Discount_pctm > new decimal(0))
            {
                string.Concat(",", objMDAO.Discount_pctm);
            }
            Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            str3 = " NULL";
            str4 = " NULL";
            str5 = " NULL";
            str6 = " NULL";
            str7 = " NULL";
            str8 = " NULL";
            string str10 = "";
            SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
            saleDetailDAON = (SaleDetailDAON)arrDeailDAO[0];
            str10 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_sale_detail WHERE ITEM_ID = '", saleDetailDAON.ItemID, "' ");
            if (saleDetailDAON.PropertyID1 != 0)
            {
                str3 = saleDetailDAON.PropertyID1.ToString();
                object obj = str10;
                object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", saleDetailDAON.PropertyID1, "' " };
                str10 = string.Concat(propertyID1);
            }
            if (saleDetailDAON.PropertyID2 != 0)
            {
                str4 = saleDetailDAON.PropertyID2.ToString();
                object obj1 = str10;
                object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", saleDetailDAON.PropertyID2, "' " };
                str10 = string.Concat(propertyID2);
            }
            if (saleDetailDAON.PropertyID3 != 0)
            {
                str5 = saleDetailDAON.PropertyID3.ToString();
                object obj2 = str10;
                object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", saleDetailDAON.PropertyID3, "' " };
                str10 = string.Concat(propertyID3);
            }
            if (saleDetailDAON.PropertyID4 != 0)
            {
                str6 = saleDetailDAON.PropertyID4.ToString();
                object obj3 = str10;
                object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", saleDetailDAON.PropertyID4, "' " };
                str10 = string.Concat(propertyID4);
            }
            if (saleDetailDAON.PropertyID5 != 0)
            {
                str7 = saleDetailDAON.PropertyID5.ToString();
                object obj4 = str10;
                object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", saleDetailDAON.PropertyID5, "' " };
                str10 = string.Concat(propertyID5);
            }
            str10 = string.Concat(str10, " ) ");
            if (saleDetailDAON.PriceId > 0)
            {
                str8 = saleDetailDAON.PriceId.ToString();
            }
            str9 = (saleDetailDAON.DetailID <= 0 ? " NULL " : saleDetailDAON.DetailID.ToString());
            if (saleDetailDAON.itemSerials != "" && saleDetailDAON.itemSerials != null)
            {
                string.Concat(",'", saleDetailDAON.itemSerials, "'");
            }
            object[] comGenChallanNo = new object[] { "UPDATE trns_sale_master set cg_challan_no=", objMDAO.ComGenChallanNo, ",challan_year=", objMDAO.ChallanDate.Year, ", \r\n                       is_approved='approved', approval_ref_no='", objMDAO.approvalRefNo, "', is_final_saved=", objMDAO.isFinalSaved, ",\r\n                       payment_method='", objMDAO.PaymentMethod, "',cash_amount=", objMDAO.CashAmount, ",bank_amount=", objMDAO.BankAmount, ",\r\n                       credit_amount=", objMDAO.CreditAmount, ",is_payment_finished=", objMDAO.IsPaymentFinished, ",payment_info='", objMDAO.PaymentInfo, "', \r\n                       challan_type='", objMDAO.ChallanType, "', sale_type='", objMDAO.SaleType, "', trans_type='", objMDAO.TransactionType, "',\r\n                       date_challan=to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), \r\n                        Party_id=", objMDAO.PartyID, " , ultimate_destination='", objMDAO.UltimateDestination, "',   User_id_insert= ", objMDAO.UserIdInsert, ", \r\n                       challan_no= '", objMDAO.ChallanNo, "', Remarks='", objMDAO.Remarks, "',service_charge=", objMDAO.ServiceCharge, " where challan_id=", challanId, " " };
            arrayLists.Add(string.Concat(comGenChallanNo));
            object[] itemID = new object[] { "UPDATE trns_sale_detail set Item_id=", saleDetailDAON.ItemID, ",  property_id1 = ", str3, ", property_id2 = ", str4, ", property_id3 = ", str5, ",\r\n            property_id4 = ", str6, ", property_id5 = ", str7, ", unit_id = ", saleDetailDAON.UnitID, ", Quantity = ", saleDetailDAON.Quantity, ", actual_price = ", saleDetailDAON.UnitPriceBDT, ",\r\n            Sd = ", saleDetailDAON.SD, ", Vat = ", saleDetailDAON.VAT, ", User_id_insert = ", saleDetailDAON.UserIdInsert, ", is_source_tax_deduct = ", saleDetailDAON.IsSrcTAXDeduct, ",\r\n            detail_id = ", str9, ", price_id = ", str8, ",\r\n            nbr_confirm_price = ", saleDetailDAON.NBRPrice, ", is_exempted = ", saleDetailDAON.IsExempted, ", is_rebatable = ", saleDetailDAON.IsRebatable, ", sale_row_no = ", saleDetailDAON.SaleRowNo, ",\r\n            is_zero_rate = ", saleDetailDAON.IsZeroRate, ", is_inexplicit_export = ", saleDetailDAON.isInexplicitExport, ", real_property = '", saleDetailDAON.RealProperty, "',\r\n            type_p = '", saleDetailDAON.TypeP, "', vat_rate = ", saleDetailDAON.VATRate, ", sd_rate = ", saleDetailDAON.SDRate, ", is_fixed_vat = ", saleDetailDAON.IsFixed, ",\r\n            is_truncated = ", saleDetailDAON.IsTruncated, ", is_mrp = ", saleDetailDAON.IsMrp, ", discount_amt = ", saleDetailDAON.Discount, ",\r\n            discount_pct = ", saleDetailDAON.Discount_pct, ", net_bill = ", saleDetailDAON.Net_bill, ", remarks = '", saleDetailDAON.RemarksDetail, "',\r\n            ait = ", saleDetailDAON.AIT, ", property_quantity = ", saleDetailDAON.PropStk, ", sale_quantity = ", saleDetailDAON.SaleQuantity, ",\r\n            sale_unit = ", saleDetailDAON.SaleUnitID, ", health_surcharge = ", saleDetailDAON.HealthCharge, "  where challan_id=", challanId };
            arrayLists.Add(string.Concat(itemID));
            object[] approvalRefNo = new object[] { "UPDATE trns_sale_additional_master set approval_ref_no = '", objAMDAO.ApprovalRefNo, "', purchase_order_no = '", objAMDAO.PurchaseOrderNo, "', delivery_challan_no = '", objAMDAO.DeliveryChallanNo, "', mrp_no = '", objAMDAO.MrpNo, "', project_detail = '", objAMDAO.ProjectDetail, "',\r\n        client_contact = '", objAMDAO.ClientContact, "', own_contact = '", objAMDAO.OwnContact, "', user_id_insert = ", objMDAO.UserIdInsert, "  where challan_id=", challanId };
            arrayLists.Add(string.Concat(approvalRefNo));
            DataTable dataTable = new DataTable();
            this.connDB.ExecuteBatchDML(arrayLists);
            return objMDAO.ChallanID.ToString();
        }
    }
}
