using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ChallanBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public ChallanBLL()
        {
        }

        private ArrayList AddBOEDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID)
        {
            ArrayList arrayLists;
            try
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
                    str6 = " NULL";
                    bool flag = false;
                    PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                    purchaseDetailDAO = (PurchaseDetailDAO)arrDeailDAO[i];
                    flag = (purchaseDetailDAO.IsWarStr != "Yes" ? false : true);
                    str5 = string.Concat(" (SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", purchaseDetailDAO.ItemID, "' ");
                    if (purchaseDetailDAO.PropertyID1 != 0)
                    {
                        str = purchaseDetailDAO.PropertyID1.ToString();
                        object obj = str5;
                        object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", purchaseDetailDAO.PropertyID1, "' " };
                        str5 = string.Concat(propertyID1);
                    }
                    if (purchaseDetailDAO.PropertyID2 != 0)
                    {
                        str1 = purchaseDetailDAO.PropertyID2.ToString();
                        object obj1 = str5;
                        object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", purchaseDetailDAO.PropertyID2, "' " };
                        str5 = string.Concat(propertyID2);
                    }
                    if (purchaseDetailDAO.PropertyID3 != 0)
                    {
                        str2 = purchaseDetailDAO.PropertyID3.ToString();
                        object obj2 = str5;
                        object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", purchaseDetailDAO.PropertyID3, "'" };
                        str5 = string.Concat(propertyID3);
                    }
                    if (purchaseDetailDAO.PropertyID4 != 0)
                    {
                        str3 = purchaseDetailDAO.PropertyID4.ToString();
                        object obj3 = str5;
                        object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", purchaseDetailDAO.PropertyID4, "'" };
                        str5 = string.Concat(propertyID4);
                    }
                    if (purchaseDetailDAO.PropertyID5 != 0)
                    {
                        str4 = purchaseDetailDAO.PropertyID5.ToString();
                        object obj4 = str5;
                        object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", purchaseDetailDAO.PropertyID5, "' " };
                        str5 = string.Concat(propertyID5);
                    }
                    str5 = string.Concat(str5, " ) ");
                    if (purchaseDetailDAO.PriceId > 0)
                    {
                        str6 = purchaseDetailDAO.PriceId.ToString();
                    }
                    purchaseDetailDAO.DetailID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                    object[] challanID = new object[] { "INSERT INTO trns_purchase_detail(\r\n                 Challan_id,warranty,row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, actual_price, \r\n                Sd, Vat,  User_id_insert, \r\n                is_source_tax_deduct, lot_no, detail_id, total_price, price_id, sd_rate, vat_rate, Remarks, is_rebatable, is_exempted,\r\n                Cd, Rd, Ait, Atv, Tti, purchase_unit_price, purchase_vat, purchase_sd, sale_unit_price, sale_vatable_price, sale_vat, sale_sd, \r\n                real_property,other_cost,document_processing_fee,psi,cnf_vat,cnf_commission,vds_amount,at,serial_no,batch_no,mfg_date,p_lot_no,is_fixed_vat,is_truncated,zero_rate,available_qnt,purchase_type,assesment_amount,is_current_month_rebate,approver_stage)\r\n                VALUES (", ChallanID, ",", flag, ",", purchaseDetailDAO.RowNo, ", ", purchaseDetailDAO.ItemID, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", purchaseDetailDAO.UnitID, ", ", purchaseDetailDAO.Quantity, ", ", purchaseDetailDAO.UnitPriceBDT, ", ", purchaseDetailDAO.PurchaseSD, ", ", purchaseDetailDAO.PurchaseVAT, ", ", purchaseDetailDAO.UserIdInsert, ", \r\n              ", purchaseDetailDAO.IsSrcTAXDeduct, ", ", str5, ", ", purchaseDetailDAO.DetailID, ", ", purchaseDetailDAO.TotalPricet, ", ", str6, ", ", purchaseDetailDAO.SDRate, ", ", purchaseDetailDAO.VATRate, ", '", purchaseDetailDAO.RemarksDetail, "', ", purchaseDetailDAO.IsRebatable, ", ", purchaseDetailDAO.IsExempted, ",", purchaseDetailDAO.CD_Amount, ", ", purchaseDetailDAO.RD_Amount, ", ", purchaseDetailDAO.AIT_Amount, ", ", purchaseDetailDAO.ATV_Amount, ", ", purchaseDetailDAO.TTI_Amount, ", ", purchaseDetailDAO.PurchaseUnitPrice, ", ", purchaseDetailDAO.PurchaseVAT, ", \r\n              ", purchaseDetailDAO.PurchaseSD, ", ", purchaseDetailDAO.SaleUnitPrice, ", ", purchaseDetailDAO.SaleVatablePrice, ",\r\n              ", purchaseDetailDAO.SaleVAT, ", ", purchaseDetailDAO.SaleSD, ",'", purchaseDetailDAO.RealProperty, "',", purchaseDetailDAO.OthersPrice, ",", purchaseDetailDAO.DocumentProcessingFee, ",", purchaseDetailDAO.PSI, ",", purchaseDetailDAO.CnFVat, ",", purchaseDetailDAO.CnFCommission, ",", purchaseDetailDAO.VDSAmount, ",", purchaseDetailDAO.AT_Amount, ",'", purchaseDetailDAO.TempSerialNo, "','", purchaseDetailDAO.TempBatchNo, "','", purchaseDetailDAO.TempMfgDate.ToString("MM/dd/yyyy HH:mm"), "','", purchaseDetailDAO.TempLotNo, "',", purchaseDetailDAO.IsFixed, ",", purchaseDetailDAO.IsTruncated, ",", purchaseDetailDAO.IsZeroRate, ", ", purchaseDetailDAO.Quantity, ",'", purchaseDetailDAO.PurchaseType, "', ", purchaseDetailDAO.AssesValue, ", ", purchaseDetailDAO.IsCurrentMonthRebate, ", '", purchaseDetailDAO.ApproveStage, "')" };
                    arrDetailList.Add(string.Concat(challanID));
                    int num = (new PriceDeclaretionBLL()).intPDId();
                    string str7 = HttpContext.Current.Session["ORGANIZATION_ID"].ToString();
                    object[] itemID = new object[] { "INSERT INTO price_item (price_id,Organization_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id,\r\n                                         cnfrmd_actl_prc_sd,User_id_insert) values('", num, "','", str7, "','No','2016','01-01-2016','", purchaseDetailDAO.ItemID, "','", purchaseDetailDAO.UnitID, "','", purchaseDetailDAO.UnitSalePriceBDT, "','1')" };
                    arrDetailList.Add(string.Concat(itemID));
                }
                arrayLists = arrDetailList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return arrayLists;
        }

        private ArrayList AddBOEDeailInsertSQLExcel(ArrayList arrDetailList, PurchaseDetailDAO objDetail, int ChallanID)
        {
            ArrayList arrayLists;
            try
            {
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                str6 = " NULL";
                bool flag = false;
                flag = (objDetail.IsWarStr != "Yes" ? false : true);
                str5 = string.Concat(" (SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", objDetail.ItemID, "' ");
                if (objDetail.PropertyID1 != 0)
                {
                    str = objDetail.PropertyID1.ToString();
                    object obj = str5;
                    object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", objDetail.PropertyID1, "' " };
                    str5 = string.Concat(propertyID1);
                }
                if (objDetail.PropertyID2 != 0)
                {
                    str1 = objDetail.PropertyID2.ToString();
                    object obj1 = str5;
                    object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", objDetail.PropertyID2, "' " };
                    str5 = string.Concat(propertyID2);
                }
                if (objDetail.PropertyID3 != 0)
                {
                    str2 = objDetail.PropertyID3.ToString();
                    object obj2 = str5;
                    object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", objDetail.PropertyID3, "'" };
                    str5 = string.Concat(propertyID3);
                }
                if (objDetail.PropertyID4 != 0)
                {
                    str3 = objDetail.PropertyID4.ToString();
                    object obj3 = str5;
                    object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", objDetail.PropertyID4, "'" };
                    str5 = string.Concat(propertyID4);
                }
                if (objDetail.PropertyID5 != 0)
                {
                    str4 = objDetail.PropertyID5.ToString();
                    object obj4 = str5;
                    object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", objDetail.PropertyID5, "' " };
                    str5 = string.Concat(propertyID5);
                }
                str5 = string.Concat(str5, " ) ");
                if (objDetail.PriceId > 0)
                {
                    str6 = objDetail.PriceId.ToString();
                }
                objDetail.DetailID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_purchase_detail(\r\n                 Challan_id,warranty,row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, actual_price, \r\n                Sd, Vat,  User_id_insert, \r\n                is_source_tax_deduct, lot_no, detail_id, total_price, price_id, sd_rate, vat_rate, Remarks, is_rebatable, is_exempted,\r\n                Cd, Rd, Ait, Atv, Tti, purchase_unit_price, purchase_vat, purchase_sd, sale_unit_price, sale_vatable_price, sale_vat, sale_sd, \r\n               other_cost,document_processing_fee,psi,cnf_vat,cnf_commission,vds_amount,at,serial_no,batch_no,mfg_date,p_lot_no,is_fixed_vat,is_truncated,zero_rate,available_qnt,purchase_type)\r\n                VALUES (", ChallanID, ",", flag, ",", objDetail.RowNo, ", ", objDetail.ItemID, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", objDetail.UnitID, ", ", objDetail.Quantity, ", ", objDetail.UnitPriceBDT, ", ", objDetail.SD_Amount, ", ", objDetail.VAT_Amount, ", ", objDetail.UserIdInsert, ", \r\n              ", objDetail.IsSrcTAXDeduct, ", ", str5, ", ", objDetail.DetailID, ", ", objDetail.TotalPricet, ", ", str6, ", ", objDetail.SD, ", ", objDetail.VAT, ", '", objDetail.RemarksDetail, "', ", objDetail.IsRebatable, ", ", objDetail.IsExempted, ",", objDetail.CD_Amount, ", ", objDetail.RD_Amount, ", ", objDetail.AIT_Amount, ", ", objDetail.ATV_Amount, ", ", objDetail.TTI_Amount, ", ", objDetail.PurchaseUnitPrice, ", ", objDetail.VAT_Amount, ", \r\n              ", objDetail.SD_Amount, ", ", objDetail.SaleUnitPrice, ", ", objDetail.SaleVatablePrice, ",\r\n              ", objDetail.SaleVAT, ", ", objDetail.SaleSD, ",", objDetail.OthersPrice, ",", objDetail.DocumentProcessingFee, ",", objDetail.PSI, ",", objDetail.CnFVat, ",", objDetail.CnFCommission, ",", objDetail.VDSAmount, ",", objDetail.AT_Amount, ",'", objDetail.TempSerialNo, "','", objDetail.TempBatchNo, "','", objDetail.TempMfgDate.ToString("MM/dd/yyyy HH:mm"), "','", objDetail.TempLotNo, "',", objDetail.IsFixed, ",", objDetail.IsTruncated, ",", objDetail.IsZeroRate, ", ", objDetail.Quantity, ",'", objDetail.PurchaseType, "')" };
                arrDetailList.Add(string.Concat(challanID));
                int num = (new PriceDeclaretionBLL()).intPDId();
                string str7 = HttpContext.Current.Session["ORGANIZATION_ID"].ToString();
                object[] itemID = new object[] { "INSERT INTO price_item (price_id,Organization_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id,\r\n                                         cnfrmd_actl_prc_sd,User_id_insert) values('", num, "','", str7, "','No','2016','01-01-2016','", objDetail.ItemID, "','", objDetail.UnitID, "','", objDetail.UnitSalePriceBDT, "','1')" };
                arrDetailList.Add(string.Concat(itemID));
                arrayLists = arrDetailList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return arrayLists;
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
                str6 = " NULL";
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                purchaseDetailDAO = (PurchaseDetailDAO)arrDeailDAO[i];
                str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", purchaseDetailDAO.ItemID, "' ");
                if (purchaseDetailDAO.PropertyID1 > 0)
                {
                    str = (purchaseDetailDAO.IntProperty1 > 0 ? purchaseDetailDAO.IntProperty1.ToString() : "NULL");
                    object obj = str5;
                    object[] intProperty1 = new object[] { obj, " AND PROPERTY_ID1 = '", purchaseDetailDAO.IntProperty1, "' " };
                    str5 = string.Concat(intProperty1);
                }
                if (purchaseDetailDAO.PropertyID2 > 0)
                {
                    str1 = (purchaseDetailDAO.IntProperty2 > 0 ? purchaseDetailDAO.IntProperty2.ToString() : "NULL");
                    object obj1 = str5;
                    object[] intProperty2 = new object[] { obj1, " AND PROPERTY_ID2 = '", purchaseDetailDAO.IntProperty2, "' " };
                    str5 = string.Concat(intProperty2);
                }
                if (purchaseDetailDAO.PropertyID3 > 0)
                {
                    str2 = (purchaseDetailDAO.IntProperty3 > 0 ? purchaseDetailDAO.IntProperty3.ToString() : "NULL");
                    object obj2 = str5;
                    object[] intProperty3 = new object[] { obj2, " AND PROPERTY_ID3 = '", purchaseDetailDAO.IntProperty3, "'" };
                    str5 = string.Concat(intProperty3);
                }
                if (purchaseDetailDAO.PropertyID4 > 0)
                {
                    str3 = (purchaseDetailDAO.IntProperty4 > 0 ? purchaseDetailDAO.IntProperty4.ToString() : "NULL");
                    object obj3 = str5;
                    object[] intProperty4 = new object[] { obj3, " AND PROPERTY_ID4 = '", purchaseDetailDAO.IntProperty4, "'" };
                    str5 = string.Concat(intProperty4);
                }
                if (purchaseDetailDAO.PropertyID5 > 0)
                {
                    str4 = (purchaseDetailDAO.IntProperty5 > 0 ? purchaseDetailDAO.IntProperty5.ToString() : "NULL");
                    object obj4 = str5;
                    object[] intProperty5 = new object[] { obj4, " AND PROPERTY_ID5 = '", purchaseDetailDAO.IntProperty5, "' " };
                    str5 = string.Concat(intProperty5);
                }
                str5 = string.Concat(str5, " ) ");
                if (purchaseDetailDAO.PriceId > 0)
                {
                    str6 = purchaseDetailDAO.PriceId.ToString();
                }
                purchaseDetailDAO.DetailID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_purchase_detail(\r\n            Challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, actual_price, \r\n            Sd, Vat,  User_id_insert, \r\n           is_source_tax_deduct, lot_no, detail_id, total_price, price_id, sd_rate, vat_rate, Remarks, is_rebatable, is_exempted,\r\n           Cd, Rd, Ait, Atv, Tti,at, purchase_unit_price, purchase_vat, purchase_sd, sale_unit_price, sale_vatable_price, sale_vat, sale_sd, real_property,other_cost,document_processing_fee,vds_amount,serial_no,batch_no,mfg_date,p_lot_no,is_fixed_vat,is_truncated,zero_rate,is_mrp,available_qnt,purchase_type,is_current_month_rebate,approver_stage)\r\n           VALUES (", ChallanID, ", ", purchaseDetailDAO.RowNo, ", ", purchaseDetailDAO.ItemID, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", purchaseDetailDAO.UnitID, ", ", purchaseDetailDAO.Quantity, ", ", purchaseDetailDAO.UnitPriceBDT, ", ", purchaseDetailDAO.SD, ", ", purchaseDetailDAO.VAT, ", ", purchaseDetailDAO.UserIdInsert, ", \r\n              ", purchaseDetailDAO.IsSrcTAXDeduct, ", ", str5, ", ", purchaseDetailDAO.DetailID, ", ", purchaseDetailDAO.TotalPrice, ", ", str6, ", ", purchaseDetailDAO.SDRate, ", ", purchaseDetailDAO.VATRate, ", '", purchaseDetailDAO.RemarksDetail, "', ", purchaseDetailDAO.IsRebatable, ", ", purchaseDetailDAO.IsExempted, ",", purchaseDetailDAO.CD_Amount, ", ", purchaseDetailDAO.RD_Amount, ", ", purchaseDetailDAO.AIT_Amount, ", ", purchaseDetailDAO.ATV_Amount, ", ", purchaseDetailDAO.TTI_Amount, ", ", purchaseDetailDAO.AT_Amount, ", ", purchaseDetailDAO.PurchaseUnitPrice, ", ", purchaseDetailDAO.PurchaseVAT, ", \r\n              ", purchaseDetailDAO.PurchaseSD, ", ", purchaseDetailDAO.SaleUnitPrice, ", ", purchaseDetailDAO.SaleVatablePrice, ", \r\n              ", purchaseDetailDAO.SaleVAT, ", ", purchaseDetailDAO.SaleSD, ",'", purchaseDetailDAO.RealProperty, "',", purchaseDetailDAO.OthersPrice, ",", purchaseDetailDAO.DocumentProcessingFee, ",", purchaseDetailDAO.VDSAmount, ",'", purchaseDetailDAO.TempSerialNo, "','", purchaseDetailDAO.TempBatchNo, "','", purchaseDetailDAO.TempMfgDate.ToString("MM/dd/yyyy HH:mm"), "','", purchaseDetailDAO.TempLotNo, "',", purchaseDetailDAO.IsFixed, ",", purchaseDetailDAO.IsTruncated, ",", purchaseDetailDAO.IsZeroRate, ",", purchaseDetailDAO.IsMrp, ", ", purchaseDetailDAO.Quantity, ",'", purchaseDetailDAO.PurchaseType, "',", purchaseDetailDAO.IsCurrentMonthRebate, ",'", purchaseDetailDAO.ApproveStage, "')" };
                arrDetailList.Add(string.Concat(challanID));
                int num = (new PriceDeclaretionBLL()).intPDId();
                string str7 = HttpContext.Current.Session["ORGANIZATION_ID"].ToString();
                object[] itemID = new object[] { "INSERT INTO price_item (price_id,Organization_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id,\r\n          cnfrmd_actl_prc_sd,User_id_insert) values('", num, "','", str7, "','No','2016','01-01-2016','", purchaseDetailDAO.ItemID, "','", purchaseDetailDAO.UnitID, "','", purchaseDetailDAO.UnitSalePriceBDT, "','1')" };
                arrDetailList.Add(string.Concat(itemID));
            }
            return arrDetailList;
        }

        private ArrayList AddDeailInsertSQLExcel(ArrayList arrDetailList, PurchaseDetailDAO objDetail, int ChallanID)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            str = " NULL";
            str1 = " NULL";
            str2 = " NULL";
            str3 = " NULL";
            str4 = " NULL";
            str6 = " NULL";
            str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", objDetail.ItemID, "' ");
            if (objDetail.PropertyID1 > 0)
            {
                str = (objDetail.IntProperty1 > 0 ? objDetail.IntProperty1.ToString() : "NULL");
                object obj = str5;
                object[] intProperty1 = new object[] { obj, " AND PROPERTY_ID1 = '", objDetail.IntProperty1, "' " };
                str5 = string.Concat(intProperty1);
            }
            if (objDetail.PropertyID2 > 0)
            {
                str1 = (objDetail.IntProperty2 > 0 ? objDetail.IntProperty2.ToString() : "NULL");
                object obj1 = str5;
                object[] intProperty2 = new object[] { obj1, " AND PROPERTY_ID2 = '", objDetail.IntProperty2, "' " };
                str5 = string.Concat(intProperty2);
            }
            if (objDetail.PropertyID3 > 0)
            {
                str2 = (objDetail.IntProperty3 > 0 ? objDetail.IntProperty3.ToString() : "NULL");
                object obj2 = str5;
                object[] intProperty3 = new object[] { obj2, " AND PROPERTY_ID3 = '", objDetail.IntProperty3, "'" };
                str5 = string.Concat(intProperty3);
            }
            if (objDetail.PropertyID4 > 0)
            {
                str3 = (objDetail.IntProperty4 > 0 ? objDetail.IntProperty4.ToString() : "NULL");
                object obj3 = str5;
                object[] intProperty4 = new object[] { obj3, " AND PROPERTY_ID4 = '", objDetail.IntProperty4, "'" };
                str5 = string.Concat(intProperty4);
            }
            if (objDetail.PropertyID5 > 0)
            {
                str4 = (objDetail.IntProperty5 > 0 ? objDetail.IntProperty5.ToString() : "NULL");
                object obj4 = str5;
                object[] intProperty5 = new object[] { obj4, " AND PROPERTY_ID5 = '", objDetail.IntProperty5, "' " };
                str5 = string.Concat(intProperty5);
            }
            str5 = string.Concat(str5, " ) ");
            if (objDetail.PriceId > 0)
            {
                str6 = objDetail.PriceId.ToString();
            }
            objDetail.DetailID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
            object[] challanID = new object[] { "INSERT INTO trns_purchase_detail(\r\n            Challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, actual_price, \r\n            Sd, Vat,  User_id_insert, \r\n           is_source_tax_deduct, lot_no, detail_id, total_price, price_id, sd_rate, vat_rate, Remarks,\r\n           is_rebatable, is_exempted, Cd, Rd, Ait, Atv, Tti,at, purchase_unit_price, purchase_vat, purchase_sd, \r\n         sale_unit_price, sale_vatable_price, sale_vat, sale_sd, other_cost,document_processing_fee,vds_amount,serial_no,batch_no,mfg_date,p_lot_no,is_fixed_vat,is_truncated,zero_rate,is_mrp,available_qnt,purchase_type)\r\n           VALUES (", ChallanID, ", ", objDetail.RowNo, ", ", objDetail.ItemID, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", objDetail.UnitID, ", ", objDetail.QuantityExcel, ", ", objDetail.UnitPriceBDT, ", ", objDetail.SD, ", ", objDetail.VAT, ", ", objDetail.UserIdInsert, ", \r\n              ", objDetail.IsSrcTAXDeduct, ", ", str5, ", ", objDetail.DetailID, ", ", objDetail.TotalPrice, ", ", str6, ", ", objDetail.SDRate, ", ", objDetail.VATRate, ", '", objDetail.RemarksDetail, "', ", objDetail.IsRebatable, ", ", objDetail.IsExempted, ",", objDetail.CD_Amount, ", ", objDetail.RD_Amount, ", ", objDetail.AIT_Amount, ", ", objDetail.ATV_Amount, ", ", objDetail.TTI_Amount, ", ", objDetail.AT_Amount, ", ", objDetail.PurchaseUnitPrice, ", ", objDetail.PurchaseVAT, ", \r\n              ", objDetail.PurchaseSD, ", ", objDetail.SaleUnitPrice, ", ", objDetail.SaleVatablePrice, ", \r\n              ", objDetail.SaleVAT, ", ", objDetail.SaleSD, ",", objDetail.OthersPrice, ",", objDetail.DocumentProcessingFee, ",", objDetail.VDSAmount, ",'", objDetail.TempSerialNo, "','", objDetail.TempBatchNo, "','", objDetail.TempMfgDate.ToString("MM/dd/yyyy HH:mm"), "','", objDetail.TempLotNo, "',", objDetail.IsFixed, ",", objDetail.IsTruncated, ",", objDetail.IsZeroRate, ",", objDetail.IsMrp, ", ", objDetail.QuantityExcel, ",'", objDetail.PurchaseType, "')" };
            arrDetailList.Add(string.Concat(challanID));
            int num = (new PriceDeclaretionBLL()).intPDId();
            string str7 = HttpContext.Current.Session["ORGANIZATION_ID"].ToString();
            object[] itemID = new object[] { "INSERT INTO price_item (price_id,Organization_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id,\r\n          cnfrmd_actl_prc_sd,User_id_insert) values('", num, "','", str7, "','No','2016','01-01-2016','", objDetail.ItemID, "','", objDetail.UnitID, "','", objDetail.UnitSalePriceBDT, "','1')" };
            arrDetailList.Add(string.Concat(itemID));
            return arrDetailList;
        }

        private ArrayList AddImportMainDeailInsertAdditionalInfo(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID, DateTime ChallanDate)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                contructualProductionIssueDAO.additionalInfoId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('additional_info_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_production_rcv_additional(\r\n                                additional_info_id, purchase_challan_id, item_id,status, property_id1, property_id2, property_id3, \r\n                                property_id4, property_id5, property_id1_value, property_id2_value, property_id3_value, \r\n                                property_id4_value, property_id5_value,  User_id_insert,organization_id,org_branch_id,date_challan)\r\n    VALUES (", contructualProductionIssueDAO.additionalInfoId, ", ", ChallanID, ", ", contructualProductionIssueDAO.Item_id, ",  'I', ", contructualProductionIssueDAO.Property_id1, ", ", contructualProductionIssueDAO.Property_id2, ", ", contructualProductionIssueDAO.Property_id3, ", ", contructualProductionIssueDAO.Property_id4, ",\r\n              ", contructualProductionIssueDAO.Property_id5, ", '", contructualProductionIssueDAO.Property1_Text, "',' ", contructualProductionIssueDAO.Property2_Text, "', ' ", contructualProductionIssueDAO.Property3_Text, "', '", contructualProductionIssueDAO.Property4_Text, "','", contructualProductionIssueDAO.Property5_Text, "',", contructualProductionIssueDAO.User_id_insert, ", ", num, ",", num1, ",TO_DATE('", ChallanDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'))" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        private ArrayList AddMainDeailInsertAdditionalInfo(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID, DateTime ChallanDate)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                contructualProductionIssueDAO.additionalInfoId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('additional_info_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_production_rcv_additional(\r\n                                additional_info_id, purchase_challan_id, item_id,status, property_id1, property_id2, property_id3, \r\n                                property_id4, property_id5, property_id1_value, property_id2_value, property_id3_value, \r\n                                property_id4_value, property_id5_value,  User_id_insert,organization_id,org_branch_id,date_challan)\r\n    VALUES (", contructualProductionIssueDAO.additionalInfoId, ", ", ChallanID, ", ", contructualProductionIssueDAO.Item_id, ",  'L', ", contructualProductionIssueDAO.Property_id1, ", ", contructualProductionIssueDAO.Property_id2, ", ", contructualProductionIssueDAO.Property_id3, ", ", contructualProductionIssueDAO.Property_id4, ",\r\n              ", contructualProductionIssueDAO.Property_id5, ", '", contructualProductionIssueDAO.Property1_Text, "',' ", contructualProductionIssueDAO.Property2_Text, "', ' ", contructualProductionIssueDAO.Property3_Text, "', '", contructualProductionIssueDAO.Property4_Text, "','", contructualProductionIssueDAO.Property5_Text, "',", contructualProductionIssueDAO.User_id_insert, ", ", num, ",", num1, ",to_timestamp('", ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        private ArrayList AddPreviousDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID)
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
                str6 = " NULL";
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                purchaseDetailDAO = (PurchaseDetailDAO)arrDeailDAO[i];
                str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM prev_trns_purchase_detail WHERE ITEM_ID = '", purchaseDetailDAO.ItemID, "' ");
                if (purchaseDetailDAO.PropertyID1 > 0)
                {
                    str = (purchaseDetailDAO.IntProperty1 > 0 ? purchaseDetailDAO.IntProperty1.ToString() : "NULL");
                    object obj = str5;
                    object[] intProperty1 = new object[] { obj, " AND PROPERTY_ID1 = '", purchaseDetailDAO.IntProperty1, "' " };
                    str5 = string.Concat(intProperty1);
                }
                if (purchaseDetailDAO.PropertyID2 > 0)
                {
                    str1 = (purchaseDetailDAO.IntProperty2 > 0 ? purchaseDetailDAO.IntProperty2.ToString() : "NULL");
                    object obj1 = str5;
                    object[] intProperty2 = new object[] { obj1, " AND PROPERTY_ID2 = '", purchaseDetailDAO.IntProperty2, "' " };
                    str5 = string.Concat(intProperty2);
                }
                if (purchaseDetailDAO.PropertyID3 > 0)
                {
                    str2 = (purchaseDetailDAO.IntProperty3 > 0 ? purchaseDetailDAO.IntProperty3.ToString() : "NULL");
                    object obj2 = str5;
                    object[] intProperty3 = new object[] { obj2, " AND PROPERTY_ID3 = '", purchaseDetailDAO.IntProperty3, "'" };
                    str5 = string.Concat(intProperty3);
                }
                if (purchaseDetailDAO.PropertyID4 > 0)
                {
                    str3 = (purchaseDetailDAO.IntProperty4 > 0 ? purchaseDetailDAO.IntProperty4.ToString() : "NULL");
                    object obj3 = str5;
                    object[] intProperty4 = new object[] { obj3, " AND PROPERTY_ID4 = '", purchaseDetailDAO.IntProperty4, "'" };
                    str5 = string.Concat(intProperty4);
                }
                if (purchaseDetailDAO.PropertyID5 > 0)
                {
                    str4 = (purchaseDetailDAO.IntProperty5 > 0 ? purchaseDetailDAO.IntProperty5.ToString() : "NULL");
                    object obj4 = str5;
                    object[] intProperty5 = new object[] { obj4, " AND PROPERTY_ID5 = '", purchaseDetailDAO.IntProperty5, "' " };
                    str5 = string.Concat(intProperty5);
                }
                str5 = string.Concat(str5, " ) ");
                if (purchaseDetailDAO.PriceId > 0)
                {
                    str6 = purchaseDetailDAO.PriceId.ToString();
                }
                purchaseDetailDAO.DetailID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('prev_item_detail_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO prev_trns_purchase_detail(\r\n            prev_challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, actual_price, Sd, Vat,  User_id_insert, \r\n            is_source_tax_deduct, lot_no, prev_detail_id, total_price, price_id, sd_rate, vat_rate, Remarks, is_rebatable, is_exempted,\r\n            Cd, Rd, Ait, Atv, Tti,at, purchase_unit_price, purchase_vat, purchase_sd, sale_unit_price, sale_vatable_price, sale_vat, sale_sd, real_property,other_cost,document_processing_fee,vds_amount,serial_no,batch_no,mfg_date,p_lot_no,is_fixed_vat,is_truncated,zero_rate,is_mrp,available_qnt,purchase_type)\r\n            VALUES (", ChallanID, ", ", purchaseDetailDAO.RowNo, ", ", purchaseDetailDAO.ItemID, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", purchaseDetailDAO.UnitID, ", ", purchaseDetailDAO.Quantity, ", ", purchaseDetailDAO.UnitPriceBDT, ", ", purchaseDetailDAO.SD, ", ", purchaseDetailDAO.VAT, ", ", purchaseDetailDAO.UserIdInsert, ", \r\n              ", purchaseDetailDAO.IsSrcTAXDeduct, ", ", str5, ", ", purchaseDetailDAO.DetailID, ", ", purchaseDetailDAO.TotalPrice, ", ", str6, ", ", purchaseDetailDAO.SDRate, ", ", purchaseDetailDAO.VATRate, ", '", purchaseDetailDAO.RemarksDetail, "', ", purchaseDetailDAO.IsRebatable, ", ", purchaseDetailDAO.IsExempted, ",", purchaseDetailDAO.CD_Amount, ", ", purchaseDetailDAO.RD_Amount, ", ", purchaseDetailDAO.AIT_Amount, ", ", purchaseDetailDAO.ATV_Amount, ", ", purchaseDetailDAO.TTI_Amount, ", ", purchaseDetailDAO.AT_Amount, ", ", purchaseDetailDAO.PurchaseUnitPrice, ", ", purchaseDetailDAO.PurchaseVAT, ", \r\n              ", purchaseDetailDAO.PurchaseSD, ", ", purchaseDetailDAO.SaleUnitPrice, ", ", purchaseDetailDAO.SaleVatablePrice, ", \r\n              ", purchaseDetailDAO.SaleVAT, ", ", purchaseDetailDAO.SaleSD, ",'", purchaseDetailDAO.RealProperty, "',", purchaseDetailDAO.OthersPrice, ",", purchaseDetailDAO.DocumentProcessingFee, ",", purchaseDetailDAO.VDSAmount, ",'", purchaseDetailDAO.TempSerialNo, "','", purchaseDetailDAO.TempBatchNo, "','", purchaseDetailDAO.TempMfgDate.ToString("MM/dd/yyyy HH:mm"), "','", purchaseDetailDAO.TempLotNo, "',", purchaseDetailDAO.IsFixed, ",", purchaseDetailDAO.IsTruncated, ",", purchaseDetailDAO.IsZeroRate, ",", purchaseDetailDAO.IsMrp, ", ", purchaseDetailDAO.Quantity, ",'", purchaseDetailDAO.PurchaseType, "')" };
                arrDetailList.Add(string.Concat(challanID));
                int num = (new PriceDeclaretionBLL()).intPDId();
                string str7 = HttpContext.Current.Session["ORGANIZATION_ID"].ToString();
                object[] itemID = new object[] { "INSERT INTO price_item (price_id,Organization_id, price_declaration_no, price_declaration_year, date_effective, Item_id, unit_id,\r\n                                   cnfrmd_actl_prc_sd,User_id_insert) values('", num, "','", str7, "','No','2016','01-01-2016','", purchaseDetailDAO.ItemID, "','", purchaseDetailDAO.UnitID, "','", purchaseDetailDAO.UnitSalePriceBDT, "','1')" };
                arrDetailList.Add(string.Concat(itemID));
            }
            return arrDetailList;
        }

        public int CheckPartyOpeningBalance(int partyID, string challanType)
        {
            object[] objArray = new object[] { "Select * from trns_party_balance where party_id=", partyID, " and challan_type='", challanType, "'" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str).Rows.Count;
        }

        public bool checkPrintedPreviously(int challanId)
        {
            string str = string.Concat("select print_id from print_information where challan_id=", challanId);
            DataTable dataTable = this.DBUtil.GetDataTable(str);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool checkProductionChallan(string challan_no)
        {
            bool flag = false;
            string str = string.Concat(" SELECT * from trns_production_master where challan_batch_no='", challan_no, "' and is_deleted=false");
            DataTable dataTable = this.DBUtil.GetDataTable(str);
            if (dataTable.Rows.Count > 0 && dataTable != null)
            {
                flag = true;
            }
            return flag;
        }

        public bool DiscardChallanBookPage(int challanBookId, int pageNo)
        {
            object[] objArray = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = 'Discarded' where challan_book_id = ", challanBookId, " and page_no = ", pageNo, " and is_used = false" };
            string str = string.Concat(objArray);
            return this.connDB.ExecuteDML(str);
        }

        public static DropDownList fillAllItem(DropDownList ddlItem)
        {
            DataSet allItem = (new SetItemBLL()).getAllItem();
            if (allItem != null && allItem.Tables[0].Rows.Count > 0)
            {
                ddlItem.DataSource = allItem;
                ddlItem.DataTextField = allItem.Tables[0].Columns["item_name"].ToString();
                ddlItem.DataValueField = allItem.Tables[0].Columns["Item_id"].ToString();
                ddlItem.DataBind();
            }
            return ddlItem;
        }

        public static DropDownList fillAllItemByCategory(DropDownList ddlItemByCategory, int intCategoryID)
        {
            DataSet allItemByCategory = (new SetItemBLL()).getAllItemByCategory(intCategoryID);
            if (allItemByCategory != null && allItemByCategory.Tables[0].Rows.Count > 0)
            {
                ddlItemByCategory.DataSource = allItemByCategory;
                ddlItemByCategory.DataTextField = allItemByCategory.Tables[0].Columns["item_name"].ToString();
                ddlItemByCategory.DataValueField = allItemByCategory.Tables[0].Columns["Item_id"].ToString();
                ddlItemByCategory.DataBind();
            }
            return ddlItemByCategory;
        }

        public static DropDownList fillAllItemCategory(DropDownList ddlItemCategory)
        {
            DataSet allItemCategory = (new SetItemBLL()).getAllItemCategory();
            if (allItemCategory != null && allItemCategory.Tables[0].Rows.Count > 0)
            {
                ddlItemCategory.DataSource = allItemCategory;
                ddlItemCategory.DataTextField = allItemCategory.Tables[0].Columns["category_name"].ToString();
                ddlItemCategory.DataValueField = allItemCategory.Tables[0].Columns["category_id"].ToString();
                ddlItemCategory.DataBind();
            }
            return ddlItemCategory;
        }

        public static DropDownList fillItemProperty1ByItemID(DropDownList ddlItemByCategory, int intItemID)
        {
            DataSet allItemByCategory = (new SetItemBLL()).getAllItemByCategory(intItemID);
            if (allItemByCategory != null && allItemByCategory.Tables[0].Rows.Count > 0)
            {
                ddlItemByCategory.DataSource = allItemByCategory;
                ddlItemByCategory.DataTextField = allItemByCategory.Tables[0].Columns["item_name"].ToString();
                ddlItemByCategory.DataValueField = allItemByCategory.Tables[0].Columns["Item_id"].ToString();
                ddlItemByCategory.DataBind();
            }
            return ddlItemByCategory;
        }

        public DataSet fillVehicleType()
        {
            return this.DBUtil.GetDataSet("SELECT * from app_code_detail where code_id_m=7 order by code_name", "Country");
        }

        public DataTable GetAllCustomerInfo()
        {
            return this.DBUtil.GetDataTable("SELECT * from set_customer where Is_deleted = false order by customer_id");
        }

        public DataTable GetAllMfgPartyInfo()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("SELECT * from trns_party where separator=1 and Is_deleted = false AND organization_id = ", num, " And major_area_of_ecn_activity like'%4%'  order by party_name");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllPartyInfo()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("SELECT * from trns_party where separator=1 and Is_deleted = false AND organization_id = ", num, " order by party_name");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllPartyInfobyPartyId(int partyId)
        {
            string str = string.Concat("SELECT * from trns_party where Is_deleted = false and party_id=", partyId, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllPartyInfoForLocalPurchase()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("SELECT party_id,case when party_code='' then party_name else party_name ||'('|| party_code||')' end party_name,party_bin,party_address,national_id_no,ultimate_destination,reg_type,is_vds_deduct from trns_party where separator=1 and Is_deleted = false and (is_vendor=true or (is_vendor=true and is_customer=true)) and  organization_id=", num, "  and party_id != -999 order by party_name");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllPartyInfoForSale()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("SELECT party_id,case when party_code = '' then party_name else party_name ||'('|| party_code||')' end party_name,party_bin,party_address,national_id_no,ultimate_destination,reg_type,is_vds_deduct from trns_party where separator=1 and Is_deleted = false AND (is_customer=true or (is_vendor=true and is_customer=true)) AND organization_id = ", num, " and party_id != -999  order by party_name");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetAllPartyInfoRegistrationWise(int regTypeId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "SELECT party_id,case when party_code ='' then party_name else party_name ||'('|| party_code||')' end party_name,party_bin,party_address,national_id_no,ultimate_destination,reg_type,is_vds_deduct from trns_party where separator=1 and Is_deleted = false and party_id != -999 AND organization_id = ", num, " AND reg_type = ", regTypeId, " AND (is_vendor=true or (is_vendor=true and is_customer=true)) order by party_name" };
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

        public DataTable GetAllPartyInfoRegistrationWiseForSale(int regTypeId)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "SELECT party_id,case when party_code ='' then party_name else party_name ||'('|| party_code||')' end party_name,party_bin,party_address,national_id_no,ultimate_destination,reg_type,is_vds_deduct from trns_party where separator=1 and Is_deleted = false and party_id != -999 AND organization_id = ", num, " AND reg_type = ", regTypeId, " AND (is_customer=true or (is_vendor=true and is_customer=true)) order by party_name" };
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

        public DataTable GetAllPartyInfoWithPurchaseChallans()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "SELECT * from trns_party where separator=1 and Is_deleted = false AND organization_id = ", num, "  \r\n            And party_id in (select party_id from trns_purchase_master) \r\n            OR party_id in (select party_id from trns_party_balance where organization_id = ", num, " and challan_type='P') --this condition is added by sabbir to fetch opening due balance parties\r\n            order by party_name" };
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

        public DataTable GetAllPartyInfoWithSaleChallans()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "SELECT * from trns_party where separator=1 and Is_deleted = false AND organization_id =  ", num, " \r\n            And party_id in (select party_id from trns_sale_master) \r\n            OR party_id in (select party_id from trns_party_balance where organization_id = ", num, " and challan_type='R') --this condition is added by sabbir to fetch opening due balance parties\r\n            order by party_name" };
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

        public DataTable GetAllPartyInOrganizationWise()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("SELECT * from trns_party where separator=1 and Is_deleted = false AND organization_id=", num, " and is_vendor=true order by party_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllPurchaseDetail(DateTime fromDate, DateTime toDate, int challan_id)
        {
            object[] challanId = new object[] { "select to_char(sm.date_challan,'dd-MON-yyyy') date_challan,p.party_name,sm.challan_no,i.item_name,sd.quantity,sd.purchase_unit_price, cast(sd.total_price as double precision) total_price\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND SD.challan_id = ", challan_id, "AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            ORDER BY sd.challan_id" };
            string str = string.Concat(challanId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetAllPurchaseDetailTotal(DateTime fromDate, DateTime toDate, int challan_id)
        {
            object[] challanId = new object[] { " select CAST(SUM(sd.total_price) AS double precision) total\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND SD.challan_id = ", challan_id, " AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n           " };
            string str = string.Concat(challanId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetAllPurchaseFromMaster(DateTime fromDate, DateTime toDate)
        {
            string[] str = new string[] { "select challan_id,date_challan from trns_purchase_master WHERE  is_deleted= false AND payment_method <> '0'   AND TO_DATE(TO_CHAR(date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            ORDER BY challan_id" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetAllPurchaseFullTotal(DateTime fromDate, DateTime toDate)
        {
            string[] str = new string[] { " select CAST(SUM(sd.total_price) AS double precision) fulltotal\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND sm.payment_method <> '0' AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n           " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetAllSaleDetail(DateTime fromDate, DateTime toDate, int challan_id)
        {
            object[] challanId = new object[] { "select to_char(sm.date_challan,'dd-MON-yyyy') date_challan,p.party_name,sm.challan_no,i.item_name,sd.quantity,sd.actual_price, cast(SD.Quantity * SD.actual_price + SD.sd + SD.Vat as double precision) total_price\r\n                        from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND SD.challan_id = ", challan_id, "AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            ORDER BY sd.challan_id" };
            string str = string.Concat(challanId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetAllSaleDetailTotal(DateTime fromDate, DateTime toDate, int challan_id)
        {
            object[] challanId = new object[] { " select CAST(SUM(SD.Quantity * SD.actual_price + SD.sd + SD.Vat) AS double precision) total\r\n                        from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND SD.challan_id = ", challan_id, " AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n           " };
            string str = string.Concat(challanId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetAllSaleFromMaster(DateTime fromDate, DateTime toDate)
        {
            string[] str = new string[] { "select challan_id,date_challan from trns_sale_master WHERE  is_deleted= false AND payment_method <> '0'  AND TO_DATE(TO_CHAR(date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            ORDER BY challan_id" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetAllSaleFullTotal(DateTime fromDate, DateTime toDate)
        {
            string[] str = new string[] { " select CAST(SUM(SD.Quantity * SD.actual_price + SD.sd + SD.Vat) AS double precision) fulltotal\r\n                        from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where  SD.is_deleted = false AND sm.payment_method <> '0' AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(sm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n           " };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetApproverStage()
        {
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt16(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select * from approver_stage_setting where organization_id = ", num, " AND org_branch_id = ", num1, " AND is_deleted = false" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetApproverStagebyEmployeeId(int empId, string apvs)
        {
            int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt16(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select * from approver_stage_setting where organization_id = ", num, " AND org_branch_id = ", num1, " AND is_deleted = false and employee_id = ", empId, " and approver_stage_no='", apvs, "'" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAreaOfManufacturing(string aomName)
        {
            string str = "";
            if (!string.IsNullOrEmpty(aomName))
            {
                string str1 = str;
                string[] lower = new string[] { str1, " and (lower(code_name) like '", aomName.ToLower(), "' or lower(code_short_name) like '", aomName.ToLower(), "')" };
                str = string.Concat(lower);
            }
            string str2 = string.Concat("select code_id_m,code_id_d,code_name,code_short_name from app_code_detail where code_id_m=35 and is_deleted=false", str, " order by serial_no asc");
            return this.DBUtil.GetDataTable(str2);
        }

        public DataTable GetBalanceDue(int challanID)
        {
            string str = string.Concat("select * from  credit_transac_history where challan_id =  ", challanID, " ORDER BY date_insert DESC LIMIT 1");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchBIN(int brnchID)
        {
            string str = string.Concat("select branch_unit_bin from org_branch_reg_info WHERE org_branch_reg_id = ", brnchID, " AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchFromTrnsParty()
        {
            return this.connDB.GetDataTable("select party_name, party_id from trns_party where separator = 3 and is_deleted = false");
        }

        public DataTable GetBranchInformation(int oorganID, int brnchID)
        {
            object[] objArray = new object[] { "select * from org_branch_reg_info where organization_id = ", oorganID, " AND org_branch_reg_id = ", brnchID, " AND is_deleted = false" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchInformation621(int oorganID, int empID, int branchID)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { " select * from org_branch_reg_info obrinfo\r\n            --inner join  admn_employee ademp on obrinfo.organization_id=ademp.organization_id\r\n            where obrinfo.organization_id = ", oorganID, " AND obrinfo.is_deleted = false and obrinfo.org_branch_reg_id=", branchID, " order by obrinfo.org_branch_reg_id " };
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

        public DataTable GetBranchInformationFormanager(int oorganID)
        {
            string str = string.Concat("select distinct * from org_branch_reg_info where organization_id = ", oorganID, " AND is_deleted = false order by org_branch_reg_id");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchInformationFormanagerN(int oorganID, int empID, int branchID)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "\r\n            select * from org_branch_reg_info obrinfo           \r\n            where obrinfo.organization_id = ", oorganID, " AND obrinfo.is_deleted = false and  obrinfo.org_branch_reg_id=", branchID, " order by obrinfo.org_branch_reg_id " };
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

        public DataTable GetBranchInformationFormanagerNew(int oorganID, int orgBranch)
        {
            object[] objArray = new object[] { "select distinct * from org_branch_reg_info where organization_id = ", oorganID, " AND is_deleted = false AND org_branch_reg_id <> ", orgBranch, " order by org_branch_reg_id" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchInformationForRcvr(int oorganID, int brnchID)
        {
            string str = string.Concat("select * from org_branch_reg_info where organization_id = ", oorganID, "  AND is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getChallan(string challan_no)
        {
            string str = string.Concat(" SELECT * FROM trns_sale_master where challan_no='", challan_no, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetChallanBookDetailByBookID(int challanBookID)
        {
            string str = string.Concat("select challan_book_id, page_no, challan_no,is_used, case page_status when 0 then 'Not Used' when 1 then 'Used' when 2 then 'Discarded' else '' end page_status, Remarks\r\n                        from trns_challan_no_detail\r\n                        where challan_book_id = ", challanBookID, " \r\n                        order by challan_book_id, page_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getChallanBookID(int challan_type, int chllanyr)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] challanType = new object[] { " SELECT * FROM trns_challan_no_detail tcd\r\n                            inner join trns_challan_no_master tcm on tcd.challan_book_id=tcm.challan_book_id\r\n                            where tcd.challan_type=", challan_type, " and is_used=false and challan_year =", chllanyr, " and tcm.organization_id = ", num, " and tcm. org_branch_reg_id = ", num1 };
            string str = string.Concat(challanType);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getChallanBookNumber(short ChallanType, short OrgID, short BrncID)
        {
            object[] orgID = new object[] { "select d.code_name as challan_type, m.challan_book_no, m.page_from, m.page_to, m.challan_year,\r\n                (select coalesce(max(page_no),0) from trns_challan_no_detail WHERE challan_book_id = m.challan_book_id AND IS_USED = TRUE) USED_PAGE_COUNT,\r\n               case when  m.org_branch_reg_id = 0 then 'Head Office' else o.branch_unit_name end branch_name \r\n                    from trns_challan_no_master m\r\n                    inner join app_code_detail as d\r\n\t\t            on m.challan_type = d.code_id_d\r\n                    left join org_branch_reg_info as o\r\n\t\t            on o.org_branch_reg_id = m.org_branch_reg_id\r\n                    where m.organization_id = ", OrgID, " and m.org_branch_reg_id = ", BrncID, " and challan_type='", ChallanType, "' and d.code_id_m = 26 order by challan_book_no " };
            string str = string.Concat(orgID);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getChallanBookType()
        {
            return this.connDB.GetDataTable("select code_id_d,code_name from app_code_detail where code_id_m = 26 and Is_deleted=false order by code_string_1st");
        }

        public DataTable GetChallanForSalesLedger(int partyID)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat("select distinct m.challan_id,m.challan_no from trns_sale_master m \r\n                        inner join trns_sale_detail d on m.challan_id = d.challan_id \r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.party_id = ", partyID, " AND m.is_deleted = false;");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetChallanNoForSalesLedger(int partyID)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct m.challan_id,m.challan_no from trns_sale_master m \r\n                        inner join trns_sale_detail d on m.challan_id = d.challan_id \r\n                        inner join trns_party p on m.party_id = p.party_id\r\n                        where m.party_id = ", partyID, " AND m.is_deleted = false  and d.approver_stage='F'\r\n\r\n                        UNION ALL \r\n\r\n\t                    Select tpb.challan_id, tpb.challan_no\r\n\t                    from trns_party_balance tpb\r\n\t                    LEFT JOIN trns_party AS P ON tpb.party_id = P.party_id\r\n\t                    where tpb.party_id = ", partyID, "  And tpb.challan_type='R' AND tpb.is_deleted = false " };
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

        public DataTable GetChallanNoInfo(int orgId, short challanType, string bookNo, int branchId)
        {
            DataTable dataTable = new DataTable();
            string str = "";
            string str1 = "";
            if (bookNo.Length > 0)
            {
                str = string.Concat(" and M.challan_book_no = '", bookNo, "'");
            }
            if (challanType > 0)
            {
                str1 = string.Concat(" AND M.challan_type = '", challanType, "'");
            }
            object[] objArray = new object[] { "SELECT  M.challan_book_id, M.challan_book_no, M.page_from, M.page_to, d.code_name as challan_type, Concat(M.challan_year-1||'-'||M.challan_year) challan_year,\r\n           (SELECT COALESCE(MAX(PAGE_NO),0) FROM trns_challan_no_DETAIL\r\n            WHERE challan_book_id = M.challan_book_id AND IS_USED = TRUE) USED_PAGE_COUNT,\r\n            case when  m.org_branch_reg_id = 0 then 'Head Office' else o.branch_unit_name end branch_name\r\n            FROM trns_challan_no_master M\r\n            inner join app_code_detail as d\r\n\t        on m.challan_type = d.code_id_d\r\n\t        left join org_branch_reg_info as o\r\n\t        on o.org_branch_reg_id = m.org_branch_reg_id\r\n            WHERE m.Organization_id =", orgId, " and o.org_branch_reg_id=", branchId, " and d.code_id_m = 26 ", str, " ", str1, " " };
            string str2 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str2);
        }

        public DataTable getChallanNumber()
        {
            return this.connDB.GetDataTable("select challan_no from trns_purchase_master");
        }

        public DataSet getChallanWithParameter(int challan_id)
        {
            string str = string.Concat("select m.challan_id,m.challan_no from trns_purchase_master m where m.challan_id=", challan_id, "  ");
            return this.DBUtil.GetDataSet(str, "AllItem");
        }

        public DataTable GetChallanWithParty(int partyID)
        {
            string str = string.Concat("      Select P.party_name,I.item_name,SM.challan_no,SD.sd_rate,\r\n\t\t\tSD.Vat,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price,SD.total_price vatable_price,\r\n                        SD.Quantity * SD.purchase_unit_price  AS Total,\r\n\t\t\tSM.challan_id,\r\n\t\t\tP.party_ID\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.party_id = ", partyID, "   AND SM.is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetChallanWithPartySales(int partyID)
        {
            DataTable dataTable;
            try
            {
                string str = string.Concat(" select COALESCE(SD.vat,0) vat,SM.challan_id,SM.organization_id,I.item_name,\r\n                        SM.challan_no,party_name,SM.payment_method,\r\n                        SD.sd,SD.Vat,SD.Quantity,SD.actual_price,\r\n                        SD.Quantity * SD.actual_price + SD.sd + SD.Vat AS Total from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n                         where SM.party_id = ", partyID, " AND SM.is_deleted = false");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetCPCCodeforBOE()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.DBUtil.GetDataTable("SELECT cpc_code_id,cpc_code from set_cpc_code where Is_deleted = false and cpc_code_type='P' ");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetCPCCodeforSale()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.DBUtil.GetDataTable("SELECT cpc_code_id,cpc_code from set_cpc_code where Is_deleted = false and cpc_code_type='S' ");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetCurrencyIdbyCurrency(string currency)
        {
            string str = string.Concat("select * from set_currency where is_deleted=false and upper(currency_name)='", currency, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public Dictionary<string, object> getDataForExcel()
        {
            Dictionary<string, object> strs = new Dictionary<string, object>();
            DataTable dataTable = this.DBUtil.GetDataTable("select max(detail_id) from trns_sale_detail");
            strs.Add("max_detail_id", (dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0]) : 0));
            Dictionary<int, string> dictionary = this.DBUtil.GetDataTable("select party_id, party_name from trns_party where is_deleted = false order by party_name asc").AsEnumerable().ToDictionary<DataRow, int, string>((DataRow row) => Convert.ToInt32(row[0]), (DataRow row) => row[1].ToString().ToUpper().Trim());
            strs.Add("parties", dictionary);
            DataTable dataTable1 = this.DBUtil.GetDataTable("select i.item_id, ic2.category_id, ic2.category_name, i.sub_category_id, ic.category_name as sub_category_name, i.item_name from item i inner join item_category ic on ic.category_id = i.sub_category_id inner join item_category ic2 on ic2.category_id = ic.parent_id where i.is_deleted = false order by item_id asc");
            Dictionary<int, string> nums = dataTable1.AsEnumerable().ToDictionary<DataRow, int, string>((DataRow row) => Convert.ToInt32(row[0]), (DataRow row) => row[5].ToString().ToUpper().Trim());
            strs.Add("items", nums);
            Dictionary<int, DataRow> nums1 = new Dictionary<int, DataRow>();
            if (dataTable1.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    nums1.Add(Convert.ToInt32(dataRow["item_id"]), dataRow);
                }
            }
            strs.Add("detailItems", nums1);
            Dictionary<int, decimal> dictionary1 = this.DBUtil.GetDataTable("select item_id, tax_value from item_tax_values where tax_id = 4 and is_tran_sale = true and is_deleted = false order by item_id asc").AsEnumerable().ToDictionary<DataRow, int, decimal>((DataRow row) => Convert.ToInt32(row[0]), (DataRow row) => Convert.ToDecimal(row[1]));
            strs.Add("taxRates", dictionary1);
            Dictionary<int, decimal> dictionary2 = this.DBUtil.GetDataTable("select item_id, tax_value from item_tax_values where tax_id = 3 and is_tran_sale = true and is_deleted = false order by item_id asc").AsEnumerable().ToDictionary<DataRow, int, decimal>((DataRow row) => Convert.ToInt32(row[0]), (DataRow row) => Convert.ToDecimal(row[1]));
            strs.Add("sdRates", dictionary2);
            Dictionary<int, string> nums2 = this.DBUtil.GetDataTable("select unit_id, unit_name from item_unit where is_deleted = false order by unit_name").AsEnumerable().ToDictionary<DataRow, int, string>((DataRow row) => Convert.ToInt32(row[0]), (DataRow row) => row[1].ToString().ToUpper().Trim());
            strs.Add("units", nums2);
            Dictionary<string, string> strs1 = new Dictionary<string, string>()
        {
            { "S", "SERVICE" },
            { "G", "GOODS" },
            { "B", "BOTH" }
        };
            strs.Add("categoryTypes", strs1);
            Dictionary<string, string> strs2 = new Dictionary<string, string>()
        {
            { "W", "WHOLESALE" },
            { "R", "RETAIL" },
            { "P", "PROCUREMENT PROVIDER" },
            { "T", "TRADER" }
        };
            strs.Add("saleTypes", strs2);
            Dictionary<string, string> strs3 = new Dictionary<string, string>()
        {
            { "1", "CASH" },
            { "2", "CHEQUE" },
            { "3", "CREDIT" },
            { "5", "PAY ORDER" },
            { "7", "DEBIT" },
            { "8", "BKASH" },
            { "11", "EFT" },
            { "12", "ROCKET" },
            { "14", "TELEPHONE TRANSFER" }
        };
            strs.Add("paymentMethods", strs3);
            return strs;
        }

        public DataTable getExportItem(int item_id)
        {
            ArrayList arrayLists = new ArrayList();
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            string str = string.Concat("Select distinct reference from price_raw_item where  item_id =", item_id, " ");
            DataTable dataTable2 = this.connDB.GetDataTable(str);
            for (int i = 0; i < dataTable2.Rows.Count; i++)
            {
                string str1 = dataTable2.Rows[i]["reference"].ToString();
                object[] itemId = new object[] { "select distinct price_id from price_raw_item where item_id = ", item_id, " and reference = '", str1, "' " };
                string str2 = string.Concat(itemId);
                dataTable = this.connDB.GetDataTable(str2);
                arrayLists.Add(dataTable);
            }
            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                int num = Convert.ToInt32(dataTable.Rows[j]["price_id"]);
                string str3 = string.Concat("  select price_item.price_id,item.item_name,item.item_id from price_item\r\n                            inner join item on item.item_id = price_item.item_id\r\n                            inner join trns_sale_detail on item.item_id = trns_sale_detail.item_id\r\n                        inner join trns_purchase_detail purchs on purchs.item_id = item.item_id\r\n                        inner join trns_purchase_master purchmast on purchs.challan_id = purchmast.challan_id\r\n                        inner join trns_sale_master on trns_sale_detail.challan_id = trns_sale_master.challan_id\r\n                        where purchmast.purchase_type = 'F' and trns_sale_master.trans_type = 'E' and trns_sale_detail.Is_deleted = FALSE and price_item.price_id =", num, " order by date_effective desc limit 1");
                dataTable1 = this.connDB.GetDataTable(str3);
            }
            return dataTable1;
        }

        public DataTable getGoodsaleInfo(string fDate, string tDate, int issueBranchId)
        {
            string str = "";
            if (issueBranchId != 0)
            {
                str = string.Concat(str, " and tsm.org_branch_reg_id=", issueBranchId);
            }
            string[] strArrays = new string[] { "select obr.branch_unit_name isuue_branch,tsd.quantity,tsm.challan_no,to_char(tcm.date_insert,'dd / MM / yyyy') date_insert,tcm.challan_book_no\r\n                           ,(tsd.quantity*tsd.actual_price) price,tsd.vat,tsd.sd,case when tsd.is_fixed_vat=true then tsd.vat else 0 end fxd_vat,\r\n                            i.item_name, org.organization_name,org.registration_no,obr.org_branch_address,i.brand_name,iu.unit_code,to_char(tsm.date_challan,'dd / MM / yyyy') date_challan\r\n                            from trns_sale_detail tsd                           \r\n                            inner join trns_sale_master tsm on tsm.challan_id=tsd.challan_id                            \r\n                            inner join org_branch_reg_info obr on obr.org_branch_reg_id=tsm.org_branch_reg_id                            \r\n                            inner join trns_challan_no_detail tcd on tcd.challan_no = tsm.challan_no\r\n                            inner join trns_challan_no_master tcm on  tcm.challan_book_id=tcd.challan_book_id\r\n                            inner join item i on i.item_id=tsd.item_id\r\n                            inner join item_unit iu on iu.unit_id =tsd.unit_id\r\n                            inner join org_registration_info org on org.organization_id=obr.organization_id\r\n                           \r\n                            where CAST(tsm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(tsm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') ", str, "  and tsd.approver_stage='F'" };
            string str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable getGoodTransferInfo(string fDate, string tDate, int issueBranchId, int rcvBranchId)
        {
            string str = "";
            int num = Convert.ToInt32(HttpContext.Current.Session["master_organization_id"]);
            if (issueBranchId != 0)
            {
                str = string.Concat(str, "and issuing_branch_id = ", issueBranchId);
            }
            if (rcvBranchId != 0)
            {
                str = string.Concat(str, " and receiving_branch_id = ", rcvBranchId);
            }
            object[] objArray = new object[] { " select obr.branch_unit_name isuue_branch,obrr.branch_unit_name rcv_branch,tfd.quantity,tfm.challan_no,to_char(tcm.date_insert,'dd / MM / yyyy') date_insert,tcm.challan_book_no\r\n                           ,(tfd.quantity*tfd.unit_price) price,(tfd.vat_amount+tfd.sd_amount) kormullo,i.item_name,i.brand_name,iu.unit_code\r\n                           , org.organization_name,org.registration_no,obr.org_branch_address issue_address,obrr.org_branch_address rcv_address,tfm.issues_date\r\n                            from trns_transfer_detail tfd\r\n                            inner join trns_transfer_master tfm on tfd.transfer_id = tfm.transfer_id\r\n                            --inner join trns_purchase_detail tpd on tpd.item_id =tfd.item_id\r\n                            inner join org_branch_reg_info obr on obr.org_branch_reg_id=tfm.issuing_branch_id\r\n                            inner join org_branch_reg_info obrr on obrr.org_branch_reg_id=tfm.receiving_branch_id\r\n                            inner join trns_challan_no_detail tcd on tcd.challan_no = tfm.challan_no\r\n                            inner join trns_challan_no_master tcm on  tcm.challan_book_id=tcd.challan_book_id\r\n                            inner join item i on i.item_id=tfd.item_id\r\n                            inner join item_unit iu on iu.unit_id =tfd.unit_id\r\n                            inner join org_registration_info org on org.organization_id=obr.organization_id\r\n                           \r\n                            where CAST(tfm.issues_date as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(tfm.issues_date as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and org.master_organization_id =", num, "  and tfm.transfer_status='I' ", str };
            string str1 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable getImporItem(string Fromdate, string ToDate)
        {
            string[] toDate = new string[] { " select itm.item_id,itm.item_name from item itm\r\n                                    inner join trns_purchase_detail purchs  on purchs.item_id = itm.item_id\r\n                                inner join trns_purchase_master purchmast on purchs.challan_id = purchmast.challan_id\r\n                                where purchmast.purchase_type='I' and purchmast.date_challan< to_date('", ToDate, "','dd/MM/yyyy')\r\n                                and purchmast.date_challan> to_date('", Fromdate, "','dd/MM/yyyy')  and purchs.purchase_sd!=0" };
            string str = string.Concat(toDate);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getMaxChallanPageNo(int ChallanType, int challanYear)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select coalesce(max(d.page_no), 0) page_no,coalesce(max(m.challan_book_no),0) challan_book_no from\r\n        trns_challan_no_detail d\r\n        inner join trns_challan_no_master m on d.challan_book_id = m.challan_book_id\r\n        where m.challan_year=", challanYear, " and d.challan_type = ", ChallanType, " and m.organization_id = ", num, " and(m.org_branch_reg_id = ", num1, " OR is_applicable_all_brnch = true)" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getMaxChallanPageNOrg(int ChallanType, int challanYear)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
            object[] objArray = new object[] { "select coalesce(max(d.page_no), 0) page_no,coalesce(max(m.challan_book_no),0) challan_book_no from\r\n        trns_challan_no_detail d\r\n        inner join trns_challan_no_master m on d.challan_book_id = m.challan_book_id\r\n        where m.challan_year=", challanYear, " and d.challan_type = ", ChallanType, " and m.organization_id = ", num };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetNextChallanNo(int challanType, int orgID, int brnchID)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select d.challan_book_id,d.page_no,d.challan_no,m.challan_book_no\r\n                        from trns_challan_no_detail as d\r\n                        left join trns_challan_no_master as m on d.challan_book_id = m.challan_book_id\r\n                        where d.challan_type = ", challanType, " and d.is_used = false\r\n                        and m.organization_id = ", orgID, " and (m.org_branch_reg_id = ", brnchID, " OR m.is_applicable_all_brnch = true)\r\n                        order by challan_book_no,page_no" };
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

        public DataTable GetOrgUnitByOrgID(int organizationID)
        {
            string str = string.Concat("SELECT * from org_subsidiary_units where Is_deleted = false and Organization_id = ", organizationID, " order by org_subsidiary_units");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetpartyCode(string partyCode)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                object[] objArray = new object[] { "SELECT * from trns_party where separator=1 and Is_deleted = false and party_id != -999 AND organization_id = ", num, "\r\n                                                     AND party_code = '", partyCode, "' order by party_name" };
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

        public DataTable GetportCodebyport(string codeName)
        {
            string str = string.Concat("select * from app_code_detail where code_id_m=38 and upper(code_short_name)='", codeName, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetportInfo()
        {
            return this.DBUtil.GetDataTable("select * from app_code_detail where code_id_m=38");
        }

        public DataTable GetPriceInfoOfItem(PurchaseDetailDAO objDetailDAO)
        {
            string str = "";
            if (objDetailDAO.PropertyID1 > 0)
            {
                str = string.Concat(" AND PROPERTY_ID1 = ", objDetailDAO.PropertyID1);
            }
            if (objDetailDAO.PropertyID2 > 0)
            {
                str = string.Concat(" AND PROPERTY_ID2 = ", objDetailDAO.PropertyID2);
            }
            if (objDetailDAO.PropertyID3 > 0)
            {
                str = string.Concat(" AND PROPERTY_ID3 = ", objDetailDAO.PropertyID3);
            }
            if (objDetailDAO.PropertyID4 > 0)
            {
                str = string.Concat(" AND PROPERTY_ID4 = ", objDetailDAO.PropertyID4);
            }
            if (objDetailDAO.PropertyID5 > 0)
            {
                str = string.Concat(" AND PROPERTY_ID5 = ", objDetailDAO.PropertyID5);
            }
            object[] itemID = new object[] { "SELECT price_id,price_declaration_no, crnt_actl_prc_sd unit_price, sd_amount,cnfrmd_wholesale_prc,cnfrmd_retail_prc,\r\n                (SELECT MAX(tax_value) FROM item_tax_values WHERE ITEM_ID = ", objDetailDAO.ItemID, " AND IS_DELETED = FALSE AND IS_CURRENT = TRUE) VAT\r\n                FROM price_item WHERE price_id = (SELECT MAX(price_id) FROM price_item\r\n                WHERE ITEM_ID = ", objDetailDAO.ItemID, str, " AND IS_DELETED = FALSE\r\n                GROUP BY ITEM_ID, PROPERTY_ID1, PROPERTY_ID2,PROPERTY_ID3,PROPERTY_ID4,PROPERTY_ID5)" };
            string str1 = string.Concat(itemID);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable getProduct(string data)
        {
            return this.connDB.GetDataTable("select item_name from Item");
        }

        public DataTable getPurchaseApproveStage(int challanId)
        {
            string str = string.Concat(" select approver_stage from trns_purchase_detail where challan_id =", challanId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchasebyAPI()
        {
            return this.DBUtil.GetDataTable(" Select distinct I.item_name,SM.challan_no,SM.date_challan,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price,SD.purchase_sd,\r\n                        SD.Quantity * SD.purchase_unit_price  AS price,iu.unit_code,\r\n\t\t\tSM.challan_id\r\n                        from trns_purchase_master AS SM\r\n                        inner JOIN trns_purchase_detail AS SD ON SM.challan_id = SD.challan_id                        \r\n                        inner JOIN item AS I ON SD.item_id = I.item_id\r\n                        inner JOIN item_unit AS iu ON iu.unit_id = SD.unit_id\r\n        where SM.is_api_transaction = true AND SM.is_trns_accepted = false");
        }

        public DataTable getPurchaseChallan(int partId)
        {
            string str = "";
            if (partId != 0)
            {
                str = string.Concat("WHERE party_id = '", partId, "' ");
            }
            string str1 = string.Concat(" select challan_id, challan_no, date_insert from trns_purchase_master ", str);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetPurchaseChallanWithParty(int partyID)
        {
            object[] objArray = new object[] { " Select distinct  P.party_name,I.item_name,SM.challan_no,SD.sd_rate,\r\n\t\t\tSD.Vat,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price,SD.total_price vatable_price,\r\n                        SD.Quantity * SD.purchase_unit_price  AS Total,\r\n\t\t\tSM.challan_id,\r\n\t\t\tP.party_ID\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.party_id = ", partyID, "  AND SM.is_deleted = false\r\n\r\n        UNION ALL \r\n\r\n\t    Select P.party_name,'' AS item_name, tpb.challan_no, 0 AS sd_rate, 0 AS vat, 0 AS purchase_vat, 0 as Quantity,\r\n\t    0 AS purchase_unit_price,0 AS vatable_price,tpb.credit_amount AS total, tpb.challan_id, tpb.party_id\r\n\t    from trns_party_balance tpb\r\n\t    LEFT JOIN trns_party AS P ON tpb.party_id = P.party_id\r\n\t    where tpb.party_id = ", partyID, "  And tpb.challan_type='P' AND tpb.is_deleted = false " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseChallanWithPartyID(int partyID)
        {
            object[] objArray = new object[] { "  Select distinct  P.party_name,SM.challan_no,SM.challan_id,P.party_ID\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.party_id = ", partyID, "  AND SM.is_deleted = false  and sd.approver_stage='F'\r\n\r\n        UNION ALL \r\n\r\n\t    Select P.party_name,tpb.challan_no, tpb.challan_id, tpb.party_id\r\n\t    from trns_party_balance tpb\r\n\t    LEFT JOIN trns_party AS P ON tpb.party_id = P.party_id\r\n\t    where tpb.party_id = ", partyID, "  And tpb.challan_type='P' AND tpb.is_deleted = false  " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseCreditTransacInfo(int partyID, string challan_number, DateTime fromDate, DateTime toDate)
        {
            string[] challanNumber = new string[] { "select challan_id,challan_no,cast(current_balance as double precision),cast(balance_due as double precision),cast(payment_amount as double precision),to_char(payment_date,'dd-MON-yyyy') payment_date,org_branch_reg_id \r\n        from credit_transac_history \r\n        WHERE Status = 'P' AND challan_id IN(", challan_number, ")  AND TO_DATE(TO_CHAR(payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n          AND TO_DATE(TO_CHAR(payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n        ORDER BY challan_id,payment_date" };
            string str = string.Concat(challanNumber);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseDayWiseSummaryReportInfo(DateTime fromDate, DateTime toDate, string Filter)
        {
            string[] loggedOrgName = new string[] { "\t\t\t----PURCHSE SUMMARY REP: DATE WISE\r\n\r\n\t\t\tSELECT D.DATE_CHALLAN,SUM(D.TOTAL_PRICE) TOTAL_PRICE,\r\n                        SUM(D.TOTAL_SD) TOTAL_SD, SUM(D.TOTAL_VAT) TOTAL_VAT ,SUM(D.TOTAL_CD) TOTAL_CD, \r\n                        SUM(D.TOTAL_RD) TOTAL_RD, SUM(D.TOTAL_AIT) TOTAL_AIT, SUM(D.TOTAL_ATV) TOTAL_ATV, \r\n                        SUM(D.TOTAL_TTI) TOTAL_TTI, SUM(D.TOTAL_PRICE_WITH_SD_VAT)  TOTAL_PRICE_WITH_SD_VAT,\r\n '", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM (\r\n                        \r\n\t\t\tSELECT TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') DATE_CHALLAN,\r\n                        SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,SUM(PD.CD) TOTAL_CD, SUM(PD.RD) TOTAL_RD, SUM(PD.AIT) TOTAL_AIT, SUM(PD.ATV) TOTAL_ATV, SUM(PD.TTI) TOTAL_TTI,\r\n\t\t\t\t (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT) + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) \r\n\t\t\t\t TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        WHERE PD.is_source_tax_deduct = FALSE AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') \r\n                        GROUP BY TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') \r\n                     \r\n\t\t\tUNION ALL\r\n\r\n\t\t\tSELECT TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') DATE_CHALLAN,\r\n                        SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(-PD.SD) TOTAL_SD, SUM(-PD.VAT) TOTAL_VAT ,SUM(PD.CD) TOTAL_CD, SUM(PD.RD) TOTAL_RD, SUM(PD.AIT) TOTAL_AIT, SUM(PD.ATV) TOTAL_ATV, SUM(PD.TTI) TOTAL_TTI,\r\n\t\t\t\t (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) /*- SUM(PD.SD) - SUM(PD.VAT) */+ SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI))\r\n\t\t\t\t TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        WHERE PD.is_source_tax_deduct = TRUE AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') \r\n                        GROUP BY TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') \r\n                      \r\n\r\n                       ) D GROUP BY D.DATE_CHALLAN\r\n                           ORDER BY D.DATE_CHALLAN" };
            string str = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseInfoByAPI()
        {
            return this.DBUtil.GetDataTable("select count(challan_id) challan from trns_purchase_master where is_trns_accepted=false and is_api_transaction=true;");
        }

        public DataTable GetPurchaseInfoByChallanId(int challanId)
        {
            string str = string.Concat("select to_char(tpm.date_challan,'dd/MM/yyyy') date_challan,tpd.quantity,tpd.purchase_unit_price,tpd.purchase_vat from trns_purchase_detail tpd inner join trns_purchase_master tpm on tpd.challan_id=tpm.challan_id where tpd.challan_id=", challanId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseLeisureInfo(int partyID, int challan_number, DateTime fromDate, DateTime toDate, string paymentType)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (challan_number > 0 || challan_number < 0)
            {
                object obj = empty;
                object[] challanNumber = new object[] { obj, " AND SM.challan_id = '", challan_number, "' " };
                empty = string.Concat(challanNumber);
                object obj1 = str;
                object[] objArray = new object[] { obj1, " AND tpb.challan_id =  '", challan_number, "' " };
                str = string.Concat(objArray);
            }
            if (paymentType != "-99")
            {
                if (paymentType == "F")
                {
                    empty = string.Concat(empty, " AND SM.payment_method <>'3' ");
                }
                else if (paymentType == "P")
                {
                    empty = string.Concat(empty, " AND SM.payment_method ='3' ");
                }
            }
            object[] objArray1 = new object[] { "\r\n                                    UNION ALL\r\n\r\n        Select P.party_name,'' AS item_name, tpb.challan_no, 0 AS sd_rate, 0 AS sd, 0 AS vat, 0 AS purchase_vat, 0 as Quantity,\r\n\t    0 AS purchase_unit_price, tpb.credit_amount AS vatable_price,tpb.credit_amount AS total, tpb.challan_id,0 AS ait, 0 AS vds, tpb.party_id\r\n        from trns_party_balance tpb\r\n        LEFT JOIN trns_party AS P ON tpb.party_id = P.party_id\r\n        where tpb.party_id =  ", partyID, " ", str, " And tpb.challan_type = 'P'\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy') AND tpb.is_deleted = false    \r\n        " };
            string str1 = string.Concat(objArray1);
            object[] objArray2 = new object[] { "Select P.party_name\r\n            --,I.item_name\r\n\r\n            ,(i.item_name \r\n            || ' ' || (CASE WHEN SD.property_id1 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\tinner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id1=c.property_id \r\n\t\t\twhere a.property_id1=SD.property_id1 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", empty, " LIMIT 1) ELSE '' END)\r\n            || ' ' ||\r\n\t\t\t(CASE WHEN SD.property_id2 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\tinner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id2=c.property_id \r\n\t\t\twhere a.property_id2=SD.property_id2 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", empty, " LIMIT 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN SD.property_id3 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\tinner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id3=c.property_id \r\n\t\t\twhere a.property_id3=SD.property_id3 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", empty, " LIMIT 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN SD.property_id4 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\tinner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id3=c.property_id \r\n\t\t\twhere a.property_id4=SD.property_id4 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", empty, " LIMIT 1) ELSE '' END)\r\n\t\t\t|| ' ' ||\r\n\t\t\t(CASE WHEN SD.property_id5 > 0 THEN (select c.property_name from trns_purchase_detail a \r\n\t\t\tinner join trns_purchase_master b on a.challan_id=b.challan_id \r\n\t\t\tinner join item_property c on a.property_id3=c.property_id \r\n\t\t\twhere a.property_id5=SD.property_id5 and b.challan_no = SM.challan_no AND b.party_id = ", partyID, " ", empty, " LIMIT 1) ELSE '' END)\r\n\t\t\t) AS item_name\r\n\r\n            ,SM.challan_no,SD.sd_rate,SD.purchase_sd sd,---added for fetching full sd value 18/2/20\r\n\t\t\tSD.Vat,case when SD.vds_amount>0\r\n\t\t\t\t\tthen 0\r\n\t\t\t\telse SD.purchase_Vat\r\n\t\t\t\tend purchase_Vat,\r\n            SD.Quantity,SD.purchase_unit_price,SD.total_price vatable_price,\r\n                        --case when SD.vds_amount>0\r\n\t\t\t\t--then SD.Quantity * SD.purchase_unit_price  \r\n\t\t\t--else SD.Quantity * SD.purchase_unit_price+SD.vat  \r\n\t\t\t\t--end Total,\r\n              --case when SD.vds_amount>0 then SD.total_price+SD.sd else SD.total_price+SD.sd+SD.purchase_Vat  end Total,\r\n            SD.total_price+SD.sd+SD.purchase_Vat Total,\r\n\t\t\tSM.challan_id,SD.ait, SD.vds_amount VDS,\r\n\t\t\tP.party_ID\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.party_id = ", partyID, " ", empty, "  AND SM.is_deleted = false  AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') ", str1, " order by challan_id " };
            string str2 = string.Concat(objArray2);
            return this.DBUtil.GetDataTable(str2);
        }

        public DataTable GetPurchaseLeisureInfoForCash(int partyID, int challan_number, DateTime fromDate, DateTime toDate)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (challan_number > 0 || challan_number < 0)
            {
                object obj = empty;
                object[] challanNumber = new object[] { obj, " AND SM.challan_id = '", challan_number, "' " };
                empty = string.Concat(challanNumber);
                object obj1 = str;
                object[] objArray = new object[] { obj1, " AND tpb.challan_id = '", challan_number, "' " };
                str = string.Concat(objArray);
            }
            object[] objArray1 = new object[] { "(Select distinct to_char(sm.date_challan,'dd-MON-yyyy') date_challan,SM.challan_no,SM.challan_id,P.party_ID,case when(SD.is_source_tax_deduct=true) then cast(SM.cash_amount+SM.bank_amount- SD.vat as decimal) else cast(SM.cash_amount+SM.bank_amount as decimal) end  debit,\r\n                          case when SM.credit_amount>0\r\n\t\t\t\t            then  Cast((coalesce(SM.credit_amount,0)-coalesce(SD.vds_amount ,0)) as varchar) \r\n\t\t\t            else Cast(coalesce(SM.credit_amount,0) as varchar) end credit,\r\n                        SD.vds_amount VDS, SD.ait AIT,\r\n                            case when SM.credit_amount>0\r\n\t\t\t\t                then coalesce(SM.credit_amount,0)-coalesce(SD.vds_amount ,0)\r\n\t\t\t                else coalesce(SM.credit_amount,0) end balance,\r\n            to_char(sm.date_challan,'dd-MON-yyyy') payment_date,'-' particulars\r\n        --,org_branch_reg_id \r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n                      where SM.party_id = ", partyID, " AND SM.payment_method <> '0' ", empty, "   AND SM.is_deleted = false  AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'))\r\n\r\n        UNION ALL\r\n\r\n        Select to_char(tpb.date_challan,'dd-MON-yyyy') AS date_challan, tpb.challan_no,tpb.challan_id, tpb.party_id, 0 AS debit, Cast(tpb.credit_amount as varchar) AS credit, 0 AS vds, 0 AS ait, \r\n\ttpb.credit_amount AS balance, to_char(tpb.date_challan,'dd-MON-yyyy') AS payment_date, '-' particulars\r\n        from trns_party_balance tpb\r\n        LEFT JOIN trns_party AS P ON tpb.party_id = P.party_id\r\n        where tpb.party_id =  ", partyID, str, " And tpb.challan_type = 'P'\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy') AND tpb.is_deleted = false order by challan_id" };
            string str1 = string.Concat(objArray1);
            DataTable dataTable = this.DBUtil.GetDataTable(str1);
            object[] challanNumber1 = new object[] { "(Select   '-' date_challan,cth.challan_no,0 party_ID, coalesce(cast((coalesce(cth.payment_amount,0)-coalesce(cth.proportion_VDS,0)) as double precision),0) debit,'' as credit,cth.proportion_vds VDS, cth.proportion_ait AIT\r\n                   -- ,case when balance_due=0 then coalesce(balance_due,0) else (coalesce(balance_due,0)-coalesce(cth.proportion_VDS,0)) end balance\r\n                    ,coalesce(amount_without_vds,0) balance\r\n                   ,to_char(cth.payment_date,'dd-MON-yyyy') payment_date,case when cth.particulars is null then '-' else cth.particulars end particulars\r\n        --,org_branch_reg_id \r\n                   --,org_branch_reg_id \r\n                   from credit_transac_history cth\r\n                   WHERE cth.Status = 'P' \r\n                   AND cth.challan_id IN(", challan_number, ") and payment_amount!=0\r\n                   AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                   --order by payment_date,date_challan desc)\r\n                    order by cth.payment_date)" };
            string str2 = string.Concat(challanNumber1);
            DataTable dataTable1 = this.DBUtil.GetDataTable(str2);
            if (dataTable1.Rows.Count > 0)
            {
                dataTable.Merge(dataTable1, true, MissingSchemaAction.Ignore);
            }
            return dataTable;
        }

        public DataTable GetPurchaseLsrInfo(int partyID, int challan_number, DateTime fromDate, DateTime toDate)
        {
            string empty = string.Empty;
            if (challan_number > 0)
            {
                empty = string.Concat(" AND SM.challan_id = '", challan_number, "' ");
            }
            object[] objArray = new object[] { "Select P.party_name,I.item_name,SM.challan_no,SD.sd_rate,\r\n\t\t\tSD.Vat,SD.purchase_Vat,SD.Quantity,SD.purchase_unit_price,SD.total_price vatable_price,\r\n                        SD.Quantity * SD.purchase_unit_price  AS Total,\r\n\t\t\tSM.challan_id,SD.ait, case when SD.vat_rate!=15 then SD.purchase_Vat else 0.0000 end VDS,\r\n\t\t\tP.party_ID\r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n        where SM.party_id = ", partyID, " ", empty, "   AND SM.credit_amount != 0 AND SM.is_deleted = false  AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n           AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        " };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseLsrInfoForCash(int partyID, int challan_number, DateTime fromDate, DateTime toDate)
        {
            string empty = string.Empty;
            if (challan_number > 0)
            {
                empty = string.Concat(" AND SM.challan_id = '", challan_number, "' ");
            }
            object[] objArray = new object[] { "Select  to_char(sm.date_challan,'dd-MON-yyyy') date_challan,SM.challan_no,P.party_ID,cast(SM.cash_amount+SM.bank_amount as decimal) debit,\r\n                        SM.credit_amount credit,to_char(sm.date_challan,'dd-MON-yyyy') payment_date,'-' particulars\r\n        --,org_branch_reg_id \r\n                        from trns_purchase_master AS SM\r\n                        LEFT JOIN trns_purchase_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n                      where SM.party_id = ", partyID, " AND SM.payment_method <> '0' ", empty, "   AND SM.is_deleted = false  AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                 union \r\n                    Select   '-' date_challan,cth.challan_no,0 party_ID, cast(cth.payment_amount as double precision) debit,cast(balance_due as double precision) credit\r\n                   ,to_char(cth.payment_date,'dd-MON-yyyy') payment_date,case when cth.particulars is null then '-' else cth.particulars end particulars\r\n        --,org_branch_reg_id \r\n                   --,org_branch_reg_id \r\n                   from credit_transac_history cth\r\n                   WHERE cth.Status = 'P' \r\n                   AND cth.challan_id IN(", challan_number, ")\r\n                   AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                   order by payment_date,date_challan desc" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseStatementReportInfo(short ItemID, DateTime fromDate, DateTime toDate, string challanNo, string Filter)
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
            string[] loggedOrgName = new string[] { "----PURCHSE DETAIL REP: DATE, ITEM, CHALLAN WISE\r\n\r\n\t\t\tSELECT TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') DATE_CHALLAN, PM.CHALLAN_ID, PM.CHALLAN_NO,\r\n\t\t\t PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, PD.DETAIL_ID, PD.actual_price UNIT_PRICE,\r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        /*CASE WHEN PD.is_source_tax_deduct = TRUE THEN SUM(-PD.SD) ELSE SUM(PD.SD) END*/ SUM(PD.SD) TOTAL_SD, \r\n                        /*CASE WHEN PD.is_source_tax_deduct = TRUE THEN SUM(-PD.VAT) ELSE SUM(PD.VAT) END*/ SUM(PD.VAT) TOTAL_VAT ,\r\n                        SUM(PD.CD) TOTAL_CD, SUM(PD.RD) TOTAL_RD, SUM(PD.AIT) TOTAL_AIT, SUM(PD.ATV) TOTAL_ATV, SUM(PD.TTI) TOTAL_TTI,\r\n                        CASE WHEN PD.is_source_tax_deduct = TRUE \r\n\t\t\t\tTHEN (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) /*- SUM(PD.SD) - SUM(PD.VAT) */+ SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI))\r\n\t\t\t\tELSE (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT) + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) \r\n\t\t\t\tEND TOTAL_PRICE_WITH_SD_VAT,\r\n                         CASE WHEN PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE AND PM.PURCHASE_TYPE = 'L'  THEN 'LOCAL' \r\n\t\t\tWHEN PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE AND PM.PURCHASE_TYPE = 'I'  THEN 'IMPORT' \r\n\t\t\tWHEN PD.is_source_tax_deduct = TRUE  AND PD.IS_EXEMPTED= FALSE   THEN 'SOURCE VAT DEDUCTED' \r\n\t\t\tWHEN PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= TRUE THEN 'EXEMPTED' \r\n            WHEN PD.is_source_tax_deduct = FALSE  AND PD.is_rebatable= TRUE THEN 'REBATABLE'\r\n\t\t\t ELSE 'OTHER' END TRANS_TYPE,\r\n            '", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, str1, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                       PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') \r\n                        GROUP BY PM.CHALLAN_ID, PM.CHALLAN_NO,TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy'), PD.DETAIL_ID,PD.actual_price,\r\n                        PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE,PD.is_source_tax_deduct,PD.IS_EXEMPTED,PD.is_rebatable,PM.PURCHASE_TYPE\r\n                       ORDER BY TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy'),I.ITEM_NAME " };
            string str2 = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataTable(str2);
        }

        public string getPurchaseSummaryReport(DataTable dt)
        {
            string str = "";
            str = string.Concat(str, "<h2 class='text-center'>purchase Summary Report</h2>");
            str = string.Concat(str, "<table class='table_report'>");
            str = string.Concat(str, "<thead> <tr><th>Item Name</th><th>UNIT CODE</th> <th>Quantity</th><th>TOTAL PRICE</th><th>TOTAL SD</th><th>TOTAL VAT</th><th>TOTAL PRICE WITH SD VAT</th></tr></thead>");
            str = string.Concat(str, "<tbody>");
            string str1 = "LOCAL PURCHSE";
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

        public DataTable GetPurchaseSummaryReportInfo(short ItemID, DateTime fromDate, DateTime toDate)
        {
            string str = "";
            if (ItemID > 0)
            {
                str = string.Concat(" I.ITEM_ID = ", ItemID, " and ");
            }
            string[] strArrays = new string[] { " SELECT 'LOCAL PURCHASE' TRANS_TYPE, 'Goods' item_type, PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT) + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID                    \r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') and I.item_type='I'\r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE\r\n                        AND PM.PURCHASE_TYPE = 'L'\r\n                        GROUP BY PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE, I.item_type\r\n                       -- ORDER BY I.ITEM_NAME\r\n                     UNION ALL \r\n                        SELECT 'LOCAL PURCHASE' TRANS_TYPE, 'Service' item_type, PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT) + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID                    \r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') and I.item_type='S' or I.item_type='U' \r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE\r\n                        AND PM.PURCHASE_TYPE = 'L'\r\n                        GROUP BY PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE, I.item_type\r\n                \r\n                       \r\n     UNION ALL\r\n\r\n                        SELECT 'IMPORT PURCHASE' TRANS_TYPE,'Goods' item_type, PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT)  + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID                      \r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') and I.item_type='I'\r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE\r\n                        AND PM.PURCHASE_TYPE = 'I'\r\n                        GROUP BY PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE , I.item_type\r\n                       -- ORDER BY I.ITEM_NAME\r\n                    UNION ALL\r\n                       SELECT 'IMPORT PURCHASE' TRANS_TYPE,'Service' item_type, PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT)  + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID                      \r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') and I.item_type='S' or I.item_type='U'\r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE\r\n                        AND PM.PURCHASE_TYPE = 'I'\r\n                        GROUP BY PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE , I.item_type\r\n\r\n                        \r\n\r\n    UNION ALL\r\n\r\n                        SELECT 'EXEMPTED' TRANS_TYPE,'Goods' item_type, PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT)  + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID                       \r\n                       WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P')  and I.item_type='I'\r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= TRUE\r\n                        GROUP BY PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE, I.item_type\r\n                       -- ORDER BY I.ITEM_NAME\r\n                UNION ALL \r\n                       SELECT 'EXEMPTED' TRANS_TYPE,'Service' item_type, PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT ,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT)  + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT\r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID                       \r\n                       WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P')  and I.item_type='S' or  I.item_type='U'\r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= TRUE\r\n                        GROUP BY PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE, I.item_type" };
            string str1 = string.Concat(strArrays);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetPurchasetypeByItemId(int itemId)
        {
            string str = string.Concat("select tpm.purchase_type from trns_purchase_master tpm \r\n                       inner join trns_purchase_detail tpd on tpd.challan_id=tpm.challan_id \r\n                      where tpd.item_id=", itemId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPurchaseTypeWiseSummaryReportInfo(short ItemID, DateTime fromDate, DateTime toDate, string Filter)
        {
            string str = "";
            if (ItemID > 0)
            {
                str = string.Concat(" I.ITEM_ID = ", ItemID, " and ");
            }
            string[] loggedOrgName = new string[] { "\t\t\tSELECT 'REGULAR PURCHASE' TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN,\r\n\t\t\tCASE PM.PURCHASE_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'I' THEN 'IMPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n\t\t\t PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT, SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI) TOTAL_OTHER_DUTY,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT) + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT,\r\n        '", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID   \r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') \r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE  AND PD.IS_REBATABLE = FALSE\r\n                        --AND PM.PURCHASE_TYPE = 'L'\r\n                        GROUP BY PM.CHALLAN_ID, PM.CHALLAN_NO,PM.PURCHASE_TYPE, PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE,\r\n                        PM.DATE_CHALLAN\r\n                       \r\n                      \r\n                        \r\n\r\n                         UNION ALL\r\n\r\n                        SELECT 'EXEMPTED' TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN,\r\n                        CASE PM.PURCHASE_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'I' THEN 'IMPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n                        PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT , SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI) TOTAL_OTHER_DUTY,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT)  + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') \r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= TRUE\r\n                        GROUP BY PM.CHALLAN_ID, PM.CHALLAN_NO,PM.PURCHASE_TYPE,PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE,\r\n                        PM.DATE_CHALLAN\r\n                      \r\n\r\n                       UNION ALL\r\n\r\n\r\n                       \r\n\r\n                    SELECT  'SOURCE VAT DEDUCTED' TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN,\r\n                    CASE PM.PURCHASE_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'I' THEN 'IMPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n                    PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        /*SUM(-PD.SD)*/ SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT , SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI) TOTAL_OTHER_DUTY,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) /*- SUM(PD.SD) - SUM(PD.VAT) */ + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') \r\n                        AND PD.is_source_tax_deduct = TRUE AND PD.IS_EXEMPTED= FALSE\r\n                        GROUP BY PM.CHALLAN_ID, PM.CHALLAN_NO,PM.PURCHASE_TYPE,PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE,\r\n                        PM.DATE_CHALLAN\r\n\r\n                         UNION ALL\r\n\r\n                        SELECT 'REBATABLE' TRANS_TYPE, PM.CHALLAN_ID, PM.CHALLAN_NO, PM.DATE_CHALLAN,\r\n                        CASE PM.PURCHASE_TYPE WHEN 'L' THEN 'LOCAL' WHEN 'I' THEN 'IMPORT'  ELSE 'OTHER' END PURCHASE_TYPE,\r\n                        PD.ITEM_ID, I.ITEM_NAME||' - '||I.HS_CODE ITEM_NAME, I.UNIT_ID, U.UNIT_CODE, \r\n                        SUM(PD.QUANTITY) QUANTITY, SUM(PD.QUANTITY * PD.ACTUAL_PRICE) TOTAL_PRICE,\r\n                        SUM(PD.SD) TOTAL_SD, SUM(PD.VAT) TOTAL_VAT , SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI) TOTAL_OTHER_DUTY,\r\n                         (SUM(PD.QUANTITY * PD.ACTUAL_PRICE) + SUM(PD.SD) + SUM(PD.VAT)  + SUM(PD.CD) + SUM(PD.RD) + SUM(PD.AIT)+ SUM(PD.ATV)+ SUM(PD.TTI)) TOTAL_PRICE_WITH_SD_VAT,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n                        FROM TRNS_PURCHASE_DETAIL PD \r\n                        INNER JOIN TRNS_PURCHASE_MASTER PM ON PM.CHALLAN_ID = PD.CHALLAN_ID\r\n                        INNER JOIN ITEM I ON I.ITEM_ID = PD.ITEM_ID \r\n                        INNER JOIN ITEM_UNIT U ON U.UNIT_ID = I.UNIT_ID\r\n                        WHERE ", str, " TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(PM.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') AND\r\n                        PM.IS_DELETED = FALSE AND PD.IS_DELETED = FALSE AND PM.challan_type in ( 'P') \r\n                        AND PD.is_source_tax_deduct = FALSE  AND PD.IS_EXEMPTED= FALSE AND PD.IS_REBATABLE = TRUE\r\n                        GROUP BY PM.CHALLAN_ID, PM.CHALLAN_NO,PM.PURCHASE_TYPE,PD.ITEM_ID, I.ITEM_NAME, I.ITEM_NAME||' - '||I.HS_CODE, I.UNIT_ID, U.UNIT_CODE,\r\n                       PM.DATE_CHALLAN" };
            string str1 = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable getSaleApproveStage(int challanId)
        {
            string str = string.Concat(" select approver_stage from trns_sale_detail where challan_id =", challanId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getSaleChallan(int partId)
        {
            string str = "";
            if (partId != 0)
            {
                str = string.Concat("WHERE party_id = '", partId, "' ");
            }
            string str1 = string.Concat(" select challan_id, challan_no, date_challan,challan_year,challan_type,sale_type,trans_type,Type from trns_sale_master ", str);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetSaleChallanNo()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt16(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] objArray = new object[] { "select m.challan_id,m.challan_no\r\n                             from trns_sale_master m                        \r\n                             where m.organization_id = ", num, " and m.org_branch_reg_id = ", num1, " " };
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

        public DataTable GetSaleChallanNo_In_consumableItem()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt16(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] objArray = new object[] { "select m.challan_id,m.challan_no\r\n                             from trns_sale_master m                        \r\n                             where m.organization_id = ", num, " and m.org_branch_reg_id = ", num1, " ORDER BY challan_id DESC " };
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

        public DataTable GetSaleLeisureInfoForCash(int partyID, int challan_number, DateTime fromDate, DateTime toDate)
        {
            string empty = string.Empty;
            string str = string.Empty;
            if (challan_number > 0 || challan_number < 0)
            {
                object obj = empty;
                object[] challanNumber = new object[] { obj, " AND SM.challan_id = '", challan_number, "' " };
                empty = string.Concat(challanNumber);
                object obj1 = str;
                object[] objArray = new object[] { obj1, " AND tpb.challan_id = '", challan_number, "' " };
                str = string.Concat(objArray);
            }
            object[] objArray1 = new object[] { "Select  to_char(sm.date_challan,'dd-MON-yyyy') date_challan,SM.challan_no,P.party_ID,\r\ncase when(SD.is_source_tax_deduct=true) then cast(SM.cash_amount+SM.bank_amount- SD.vat as decimal) else cast(SM.cash_amount+SM.bank_amount as decimal) end  credit\r\n                        ,case when(SD.is_source_tax_deduct=true)\r\n                     then SD.vat\r\n                        else 0 end VDS, SD.ait AIT, \r\n                            case when(SD.is_source_tax_deduct=true) then case when SM.credit_amount>0\r\n\t\t\t\t               then  Cast((coalesce(SM.credit_amount,0)-coalesce(SD.vat,0)) as varchar) end end debit,\r\n\t\t\t               coalesce( (case when(SD.is_source_tax_deduct=true) then case when SM.credit_amount>0\r\n\t\t\t\t                then  (SM.credit_amount-SD.vat)  end end),0)  as balance\r\n                        ,to_char(sm.date_challan,'dd-MON-yyyy') payment_date,'-' particulars\r\n        --,org_branch_reg_id \r\n                        from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n                      where SM.party_id = ", partyID, " AND SM.payment_method <> '0' ", empty, "   AND SM.is_deleted = false  AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n        UNION ALL\r\n\r\n        Select to_char(tpb.date_challan,'dd-MON-yyyy') AS date_challan, tpb.challan_no, tpb.party_id, 0 AS credit, 0 AS vds, 0 AS ait,  Cast(tpb.credit_amount as varchar) AS debit, \r\n\t    tpb.credit_amount AS balance, to_char(tpb.date_challan,'dd-MON-yyyy') AS payment_date, '-' particulars\r\n        from trns_party_balance tpb\r\n        LEFT JOIN trns_party AS P ON tpb.party_id = P.party_id\r\n        where tpb.party_id =  ", partyID, str, " And tpb.challan_type = 'R'\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy') AND tpb.is_deleted = false" };
            string str1 = string.Concat(objArray1);
            DataTable dataTable = this.DBUtil.GetDataTable(str1);
            object[] challanNumber1 = new object[] { "Select   '-' date_challan,cth.challan_no,0 party_ID, cast((coalesce(cth.payment_amount,0)) as double precision) credit,cth.proportion_vds VDS, cth.proportion_ait AIT,'0' as debit,coalesce(cth.amount_without_vds,0)  balance\r\n                   ,to_char(cth.payment_date,'dd-MON-yyyy') payment_date,case when cth.particulars is null then '-' else cth.particulars end particulars\r\n        --,org_branch_reg_id \r\n                   --,org_branch_reg_id \r\n                   from credit_transac_history cth\r\n                   WHERE cth.Status = 'S' \r\n                   AND cth.challan_id IN(", challan_number, ")\r\n                   AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                   order by cth.payment_date" };
            string str2 = string.Concat(challanNumber1);
            DataTable dataTable1 = this.DBUtil.GetDataTable(str2);
            if (dataTable1.Rows.Count > 0)
            {
                dataTable.Merge(dataTable1, true, MissingSchemaAction.Ignore);
            }
            return dataTable;
        }

        public DataTable GetSaleLsrInfoForCash(int partyID, int challan_number, DateTime fromDate, DateTime toDate)
        {
            string empty = string.Empty;
            if (challan_number > 0)
            {
                empty = string.Concat(" AND SM.challan_id = '", challan_number, "' ");
            }
            object[] objArray = new object[] { "Select  to_char(sm.date_challan,'dd-MON-yyyy') date_challan,SM.challan_no,P.party_ID,cast(SM.cash_amount+SM.bank_amount as decimal) debit,\r\n                        SM.credit_amount credit,to_char(sm.date_challan,'dd-MON-yyyy') payment_date,'-' particulars\r\n        --,org_branch_reg_id \r\n                        from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD \r\n                        ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P\r\n                        ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I\r\n                        ON SD.item_id = I.item_id\r\n                      where SM.party_id = ", partyID, " AND SM.payment_method <> '0' ", empty, "   AND SM.is_deleted = false  AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                 union \r\n                    Select   '-' date_challan,cth.challan_no,0 party_ID, cast(cth.payment_amount as double precision) debit,cast(balance_due as double precision) credit\r\n                   ,to_char(cth.payment_date,'dd-MON-yyyy') payment_date,case when cth.particulars is null then '-' else cth.particulars end particulars\r\n        --,org_branch_reg_id \r\n                   --,org_branch_reg_id \r\n                   from credit_transac_history cth\r\n                   WHERE cth.Status = 'S' \r\n                   AND cth.challan_id IN(", challan_number, ")\r\n                   AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                      AND TO_DATE(TO_CHAR(cth.payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                   order by payment_date,date_challan desc" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetSalesCreditTransacInfo(int partyID, string challan_number, DateTime fromDate, DateTime toDate)
        {
            string[] challanNumber = new string[] { "select challan_id,challan_no,cast(current_balance as double precision),cast(balance_due as double precision),cast(payment_amount as double precision),to_char(payment_date,'dd-MON-yyyy') payment_date,org_branch_reg_id \r\n            from credit_transac_history \r\n            WHERE Status = 'S' AND challan_id IN( ", challan_number, ")  AND TO_DATE(TO_CHAR(payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n            AND TO_DATE(TO_CHAR(payment_date, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n            ORDER BY challan_id,payment_date" };
            string str = string.Concat(challanNumber);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetSalesLsrInfo(int partyID, int challan_number, DateTime fromDate, DateTime toDate, string paymentType)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            if (challan_number > 0 || challan_number < 0)
            {
                empty = string.Concat(" AND SM.challan_id = '", challan_number, "' ");
                str = string.Concat(" AND b.challan_id = '", challan_number, "' ");
                object obj = empty1;
                object[] challanNumber = new object[] { obj, " AND tpb.challan_id =  '", challan_number, "' " };
                empty1 = string.Concat(challanNumber);
            }
            if (paymentType != "-99")
            {
                if (paymentType == "F")
                {
                    empty = string.Concat(empty, " AND SM.payment_method <>'3' ");
                    str = string.Concat(str, " AND b.payment_method <>'3' ");
                }
                else if (paymentType == "P")
                {
                    empty = string.Concat(empty, " AND SM.payment_method ='3' ");
                    str = string.Concat(str, " AND b.payment_method ='3' ");
                }
            }
            object[] objArray = new object[] { "select COALESCE(SD.vat,0) vat1,SM.challan_id,SM.organization_id\r\n                        --,I.item_name\r\n\r\n                        ,(i.item_name \r\n\t\t\t            || ' ' || (CASE WHEN SD.property_id1 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t            inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t            inner join item_property c on a.property_id1=c.property_id \r\n\t\t\t            where a.property_id1=SD.property_id1 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", str, " LIMIT 1) ELSE '' END)\r\n                                    || ' ' ||\r\n\t\t\t            (CASE WHEN SD.property_id2 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t            inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t            inner join item_property c on a.property_id2=c.property_id \r\n\t\t\t            where a.property_id2=SD.property_id2 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", str, " LIMIT 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN SD.property_id3 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t            inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id3=SD.property_id3 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", str, " LIMIT 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN SD.property_id4 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t            inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id4=SD.property_id4 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", str, " LIMIT 1) ELSE '' END)\r\n\t\t\t            || ' ' ||\r\n\t\t\t            (CASE WHEN SD.property_id5 > 0 THEN (select c.property_name from trns_sale_detail a \r\n\t\t\t            inner join trns_sale_master b on a.challan_id=b.challan_id \r\n\t\t\t            inner join item_property c on a.property_id3=c.property_id \r\n\t\t\t            where a.property_id5=SD.property_id5 and b.challan_no = SM.challan_no and b.party_id = ", partyID, " ", str, " LIMIT 1) ELSE '' END)\r\n\t\t\t            ) AS item_name\r\n\r\n                        ,SM.challan_no,party_name,SM.payment_method,\r\n                        SD.sd,case when (SD.is_source_tax_deduct=true) then 0 else SD.Vat end Vat,case when(SD.is_source_tax_deduct=true)\r\n\t                    then SD.vat\r\n                        else 0 end VDS, SD.ait AIT,\r\n                        SD.Quantity,SD.actual_price,\r\n                        SD.Quantity * SD.actual_price + SD.sd AS vatablePrice,\r\n                        SD.Quantity * SD.actual_price + SD.sd + SD.Vat AS Total from trns_sale_master AS SM\r\n                        LEFT JOIN trns_sale_detail AS SD ON SM.challan_id = SD.challan_id\r\n                        LEFT JOIN trns_party AS P ON SM.party_id = P.party_id\r\n                        LEFT JOIN item AS I ON SD.item_id = I.item_id\r\n                        where SM.party_id = ", partyID, " ", empty, " AND SM.is_deleted = false AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(SM.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy') \r\n        \r\n        UNION ALL\r\n\r\n        Select 0 AS vat1, tpb.challan_id, tpb.organization_id,'' AS item_name, tpb.challan_no, P.party_name,'' AS payment_method, 0 AS sd, 0 AS vat, \r\n        0 AS vds, 0 AS ait, 0 as quantity, 0 AS actual_price, tpb.credit_amount AS vatableprice,tpb.credit_amount AS total\r\n        from trns_party_balance tpb\r\n        LEFT JOIN trns_party AS P ON tpb.party_id = P.party_id\r\n        where tpb.party_id =  ", partyID, " ", empty1, " And tpb.challan_type = 'R'\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy')\r\n        AND TO_DATE(TO_CHAR(tpb.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "', 'MM/dd/yyyy') AND tpb.is_deleted = false    \r\n         order by challan_id " };
            string str1 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetSaleTransactionHistoryByPartyId(int party_id, DateTime fromDate, DateTime toDate)
        {
            object[] partyId = new object[] { "select cth.challan_no,cth.current_balance,cth.payment_amount,cth.balance_due,to_char(cth.payment_date,'dd-MON-yyyy') payment_date from credit_transac_history cth\r\n               inner join trns_sale_master tpm on cth.challan_id=tpm.challan_id \r\n               where cth.status='S' and tpm.party_id=", party_id, " AND TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n           AND TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')" };
            string str = string.Concat(partyId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetSelectedBusinessUnitBranchInfo(int orgId, int brnId)
        {
            object[] objArray = new object[] { "\r\n             select org_branch_reg_id,branch_unit_bin,central_bin,branch_unit_name,org_branch_address\r\n                                from org_branch_reg_info where organization_id=", orgId, " and org_branch_reg_id=", brnId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetSelectedBusinessUnitBranchInfobyEmployee(int orgId, int employeeId)
        {
            object[] objArray = new object[] { "\r\n             select distinct obr.org_branch_reg_id,obr.branch_unit_bin,obr.central_bin,obr.branch_unit_name,obr.org_branch_address\r\n                                from org_branch_reg_info obr\r\n                                inner join bss_unit_branch_acc_control buc on buc.organization_id=obr.organization_id\r\n                                where obr.organization_id=", orgId, " and buc.employee_id=", employeeId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetselfPartyInfo()
        {
            return this.DBUtil.GetDataTable("SELECT * from trns_party where party_name='Factory' and  separator=1 and Is_deleted = false ");
        }

        public DataTable GetTransactionHistoryByPartyId(int party_id, DateTime fromDate, DateTime toDate)
        {
            object[] partyId = new object[] { "select cth.challan_no,cth.current_balance,cth.payment_amount,cth.balance_due,to_char(cth.payment_date,'dd-MON-yyyy') payment_date from credit_transac_history cth\r\n               inner join trns_purchase_master tpm on cth.challan_id=tpm.challan_id \r\n               where cth.status='P' and tpm.party_id=", party_id, " AND TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  >= to_date('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n           AND TO_DATE(TO_CHAR(tpm.date_challan, 'MM/dd/yyyy'), 'MM/dd/yyyy')  <= to_date('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')" };
            string str = string.Concat(partyId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getTransferIssueInfo(int issuingBranch_id, int rcvngBranch_id, int transfer_id)
        {
            object[] issuingBranchId = new object[] { "select distinct ttd.quantity, (ttd.quantity*ttd.unit_price) price,ttd.remarks,Concat(case when i.brand_name='' then i.item_name else i.item_name||'-' || i.brand_name end ) item_name,ttm.challan_no,\r\n                            to_char(ttm.issues_date,'dd-MON-yyyy') issues_date,to_char(ttm.issues_date,'HH12:MI AM') issues_time,Concat(ad.code_name||'-' || ttm.vehicle_no) vehicle_no,iu.unit_code\r\n                            from trns_transfer_detail ttd \r\n                            inner join trns_transfer_master ttm on ttm.transfer_id= ttd.transfer_id\r\n                            inner join item i on i.item_id = ttd.item_id\r\ninner join item_unit iu on iu.unit_id = ttd.unit_id\r\n                             left join app_code_detail ad on ad.code_id_m = ttm.vehicle_type_m and code_id_d = ttm.vehicle_type_d\r\n                            where ttm.transfer_status ='I' and ttm.issuing_branch_id = ", issuingBranch_id, " and ttm.receiving_branch_id = ", rcvngBranch_id, "  and ttm.transfer_id = ", transfer_id, " " };
            string str = string.Concat(issuingBranchId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getTransferRcvInfo(int issuingBranch_id, int rcvngBranch_id, int transfer_id)
        {
            object[] issuingBranchId = new object[] { "select distinct ttd.quantity, (ttd.quantity*ttd.unit_price) price,ttd.remarks,Concat(case when i.brand_name='' then i.item_name else i.item_name||'-' || i.brand_name end ) item_name,ttm.challan_no,\r\n                            to_char(ttm.issues_date,'dd-MON-yyyy') issues_date,to_char(ttm.issues_date,'HH12:MI AM') issues_time,Concat(ad.code_name||'-' || ttm.vehicle_no) vehicle_no,iu.unit_code\r\n                            from trns_transfer_detail ttd \r\n                            inner join trns_transfer_master ttm on ttm.transfer_id= ttd.transfer_id\r\n                            inner join item i on i.item_id = ttd.item_id\r\n                            inner join item_unit iu on iu.unit_id = ttd.unit_id\r\n                             left join app_code_detail ad on ad.code_id_m = ttm.vehicle_type_m and code_id_d = ttm.vehicle_type_d\r\n                            where ttm.transfer_status ='R' and ttm.issuing_branch_id = ", issuingBranch_id, " and ttm.receiving_branch_id = ", rcvngBranch_id, "  and ttm.transfer_id = ", transfer_id, " " };
            string str = string.Concat(issuingBranchId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetUsedChallanNo(int challanType)
        {
            string str = string.Concat("select challan_book_id,page_no,challan_no\r\n                        from trns_challan_no_detail\r\n                        where challan_type = ", challanType, " and is_used = true\r\n                        order by challan_book_id, page_no");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetVATMonthlySummaryReportInfo(DateTime fromDate, DateTime toDate, string Filter)
        {
            string[] loggedOrgName = new string[] { "SELECT D.TRANS_MONTH TransMonth, SUM(D.PURCHASE_TOTAL_VAT) PurchaseVAT, SUM(D.SALE_TOTAL_VAT) SaleVAT, SUM(D.TOTAL_TREASURY_CHALLAN) TreasuryChallan,\r\n            SUM(D.CREDIT_NT_TOTAL_VAT) CreditNoteVAT, SUM(D.DEBIT_NT_TOTAL_VAT) DebitNoteVAT, \r\n '", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n\t\t\tFROM (\r\n\r\n\t\t\tSELECT TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy') TRANS_MONTH,\r\n\t\t\tSUM(D.VAT) PURCHASE_TOTAL_VAT, 0 SALE_TOTAL_VAT, 0 TOTAL_TREASURY_CHALLAN, 0 CREDIT_NT_TOTAL_VAT, 0 DEBIT_NT_TOTAL_VAT \r\n\t\t\tFROM TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.CHALLAN_ID = D.CHALLAN_ID\r\n\t\t\tWHERE M.CHALLAN_TYPE = 'P' AND D.is_source_tax_deduct = FALSE\r\n\t\t\tAND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        GROUP BY TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy')\r\n\r\n                        UNION ALL \r\n\r\n                        SELECT TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy') TRANS_MONTH,\r\n                        /*SUM(-D.VAT)*/  SUM(D.VAT) PURCHASE_TOTAL_VAT, 0 SALE_TOTAL_VAT, 0 TOTAL_TREASURY_CHALLAN, 0 CREDIT_NT_TOTAL_VAT, 0 DEBIT_NT_TOTAL_VAT \r\n                        FROM TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.CHALLAN_ID = D.CHALLAN_ID\r\n\t\t\tWHERE M.CHALLAN_TYPE = 'P' AND D.is_source_tax_deduct = TRUE\r\n\t\t\tAND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         GROUP BY TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy')\r\n\r\n\t\t\tUNION ALL \r\n\r\n                        SELECT TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy') TRANS_MONTH,\r\n                        0 PURCHASE_TOTAL_VAT, SUM(D.VAT) SALE_TOTAL_VAT, 0 TOTAL_TREASURY_CHALLAN, 0 CREDIT_NT_TOTAL_VAT, 0 DEBIT_NT_TOTAL_VAT  \r\n                        FROM TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.CHALLAN_ID = D.CHALLAN_ID\r\n\t\t\tWHERE M.CHALLAN_TYPE = 'S' AND D.is_source_tax_deduct = FALSE\r\n\t\t\tAND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         GROUP BY TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy')\r\n\r\n                        UNION ALL \r\n\r\n                        SELECT TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy') TRANS_MONTH,\r\n                        0 PURCHASE_TOTAL_VAT, /*SUM(-D.VAT)*/ SUM(D.VAT) SALE_TOTAL_VAT, 0 TOTAL_TREASURY_CHALLAN, 0 CREDIT_NT_TOTAL_VAT, 0 DEBIT_NT_TOTAL_VAT  \r\n                        FROM TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.CHALLAN_ID = D.CHALLAN_ID\r\n\t\t\tWHERE M.CHALLAN_TYPE = 'S' AND D.is_source_tax_deduct = TRUE\r\n\t\tAND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         GROUP BY TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy')\r\n\r\n                         UNION ALL \r\n\r\n                        SELECT TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy') TRANS_MONTH,\r\n                        0 PURCHASE_TOTAL_VAT, 0 SALE_TOTAL_VAT, SUM(M.Amount) TOTAL_TREASURY_CHALLAN, 0 CREDIT_NT_TOTAL_VAT, 0 DEBIT_NT_TOTAL_VAT  \r\n                        FROM trns_treasury_challan M\r\n\t\t\tWHERE  TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         GROUP BY TO_CHAR(M.DATE_CHALLAN, 'Mon-yyyy')\r\n\r\n                         \r\n\t\t\tUNION ALL \r\n\r\n                        SELECT TO_CHAR(M.date_note, 'Mon-yyyy') TRANS_MONTH,\r\n                        0 PURCHASE_TOTAL_VAT, 0 SALE_TOTAL_VAT, 0 TOTAL_TREASURY_CHALLAN, SUM(D.rbt_vat) CREDIT_NT_TOTAL_VAT, 0 DEBIT_NT_TOTAL_VAT  \r\n                        FROM trns_note_DETAIL D INNER JOIN trns_note_master M ON M.note_id = D.note_id\r\n\t\t\tWHERE M.note_type = 'C' \r\n\t\t\tAND TO_DATE(TO_CHAR(M.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(M.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         GROUP BY TO_CHAR(M.date_note, 'Mon-yyyy')\r\n\r\n\r\n\t\t\tUNION ALL \r\n\r\n                        SELECT TO_CHAR(M.date_note, 'Mon-yyyy') TRANS_MONTH,\r\n                        0 PURCHASE_TOTAL_VAT, 0 SALE_TOTAL_VAT, 0 TOTAL_TREASURY_CHALLAN, 0 CREDIT_NT_TOTAL_VAT, SUM(D.rbt_vat) DEBIT_NT_TOTAL_VAT  \r\n                        FROM trns_note_DETAIL D INNER JOIN trns_note_master M ON M.note_id = D.note_id\r\n\t\t\tWHERE M.note_type = 'D' \r\n\t\t\tAND TO_DATE(TO_CHAR(M.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy') >= TO_DATE('", fromDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                        AND TO_DATE(TO_CHAR(M.date_note, 'MM/dd/yyyy'), 'MM/dd/yyyy') <= TO_DATE('", toDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy')\r\n                         GROUP BY TO_CHAR(M.date_note, 'Mon-yyyy')\r\n\r\n                         ) D GROUP BY D.TRANS_MONTH" };
            string str = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetVatRateNValue(int itemId)
        {
            string str = string.Concat("select vat_rate, purchase_unit_price from trns_purchase_detail where item_id=", itemId, " order by lot_no desc limit 1");
            return this.DBUtil.GetDataTable(str);
        }

        public int getVDS(short orgId)
        {
            string str = string.Concat("select vat_deducted_at_source from org_registration_info where organization_id = ", orgId);
            return Convert.ToInt32(this.DBUtil.GetSingleValue(str));
        }

        public bool InsertBLEntryData(PurchaseMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                if (objMDAO.IsNewParty)
                {
                    objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                    object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_tin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                    arrayLists.Add(string.Concat(partyID));
                }
                object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,Org_branch_reg_id,Organization_id, challan_type, purchase_type, date_challan, date_goods_delivery, ultimate_destination,\r\n                    User_id_insert, challan_no, party_id, insurance_no, lc_no, lc_date, lc_amount, bl_no, bl_date, port_code, port_from, port_to,bank_name, branch_name, \r\n                    bank_branch_id, lc_foreign_amount, insurance_amount, lc_foreign_currency, Remarks,release_order_no,release_order_date,payment_method,is_payment_finished,cash_amount,bank_amount,credit_amount,country_of_origin,tax_payment_date,payment_info,no_of_item,total_pack,prt_code,exh_rate,CPC)\r\n                    VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', TO_DATE('", objMDAO.ChallanDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),  TO_DATE('", objMDAO.DeliveryDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),\r\n             '", objMDAO.UltimateDestination, "', ", objMDAO.UserIdInsert, ", '", objMDAO.ChallanNo, "', ", objMDAO.PartyID, ", '", objMDAO.InsuranceNo, "', '", objMDAO.LCNo, "', TO_DATE('", objMDAO.LCDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),  '", objMDAO.LCAmount, "', '", objMDAO.BLNo, "', TO_DATE('", objMDAO.BLDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'), '", objMDAO.PortCode, "', '", objMDAO.PortFrom, "', '", objMDAO.PortTo, "', '", objMDAO.BankId, "','", objMDAO.BankBranchId, "','", objMDAO.BankBranchId, "', '", objMDAO.LCForeignAmount, "', '", objMDAO.InsuranceAmount, "', '", objMDAO.LCForeingnCurrencyUnit, "','", objMDAO.Remarks, "','", objMDAO.ReleaseOrderNo, "',TO_DATE('", objMDAO.ReleaseOrderDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),'", objMDAO.PaymentMethod, "',", objMDAO.IsPaymentFinished, ",", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.CountryId, ",TO_DATE('", objMDAO.TaxPaymentDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),'", objMDAO.PaymentInfo, "',", objMDAO.NoOfItem, ",", objMDAO.TotalPack, ",", objMDAO.PrtCode, ",", objMDAO.ExhRate, ",'", objMDAO.CPC, "')" };
                arrayLists.Add(string.Concat(challanID));
                arrayLists = this.AddBOEDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID);
                DataTable dataTable = new DataTable();
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool InsertBLEntryDataExcel(PurchaseMasterDAO objMDAO, PurchaseDetailDAO arrDeailDAO)
        {
            bool flag;
            try
            {
                objMDAO.Org_branch_reg_id = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
                ArrayList arrayLists = new ArrayList();
                objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                if (objMDAO.IsNewParty)
                {
                    objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                    object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_tin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                    arrayLists.Add(string.Concat(partyID));
                }
                object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,Org_branch_reg_id,Organization_id, challan_type, purchase_type, date_challan, date_goods_delivery, ultimate_destination,\r\n                    User_id_insert, challan_no, party_id, insurance_no, lc_no, lc_date, lc_amount, bl_no, bl_date, port_code, port_from, port_to,bank_name, branch_name, \r\n                    bank_branch_id, lc_foreign_amount, insurance_amount, lc_foreign_currency, Remarks,release_order_no,release_order_date,payment_method,is_payment_finished,cash_amount,bank_amount,credit_amount,country_of_origin,tax_payment_date,payment_info,no_of_item,total_pack,prt_code,exh_rate)\r\n                    VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', TO_DATE('", objMDAO.ChallanDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),  TO_DATE('", objMDAO.DeliveryDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),\r\n             '", objMDAO.UltimateDestination, "', ", objMDAO.UserIdInsert, ", '", objMDAO.ChallanNo, "', ", objMDAO.PartyID, ", '", objMDAO.InsuranceNo, "', '", objMDAO.LCNo, "', TO_DATE('", objMDAO.LCDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),  '", objMDAO.LCAmount, "', '", objMDAO.BLNo, "', TO_DATE('", objMDAO.BLDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'), '", objMDAO.PortCode, "', '", objMDAO.PortFrom, "', '", objMDAO.PortTo, "', '", objMDAO.BankId, "','", objMDAO.BankBranchId, "','", objMDAO.BankBranchId, "', '", objMDAO.LCForeignAmount, "', '", objMDAO.InsuranceAmount, "', '", objMDAO.LCForeingnCurrencyUnit, "','", objMDAO.Remarks, "','", objMDAO.ReleaseOrderNo, "',TO_DATE('", objMDAO.ReleaseOrderDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),'", objMDAO.PaymentMethod, "',", objMDAO.IsPaymentFinished, ",", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.CountryId, ",TO_DATE('", objMDAO.TaxPaymentDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),'", objMDAO.PaymentInfo, "',", objMDAO.NoOfItem, ",", objMDAO.TotalPack, ",", objMDAO.PrtCode, ",", objMDAO.ExhRate, ")" };
                arrayLists.Add(string.Concat(challanID));
                arrayLists = this.AddBOEDeailInsertSQLExcel(arrayLists, arrDeailDAO, objMDAO.ChallanID);
                DataTable dataTable = new DataTable();
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool InsertBLEntryDatawithAdditionalInfo(PurchaseMasterDAO objMDAO, ArrayList arrDeailDAO, ArrayList arrexcel)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                if (objMDAO.IsNewParty)
                {
                    objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                    object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_tin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                    arrayLists.Add(string.Concat(partyID));
                }
                object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,Org_branch_reg_id,Organization_id, challan_type, purchase_type, date_challan, date_goods_delivery, ultimate_destination,\r\n                    User_id_insert, challan_no, party_id, insurance_no, lc_no, lc_date, lc_amount, bl_no, bl_date, port_code, port_from, port_to,bank_name, branch_name, \r\n                    bank_branch_id, lc_foreign_amount, insurance_amount, lc_foreign_currency, Remarks,release_order_no,release_order_date,payment_method,is_payment_finished,cash_amount,bank_amount,credit_amount,country_of_origin,tax_payment_date,payment_info,no_of_item,total_pack,prt_code,exh_rate,CPC)\r\n                    VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', TO_DATE('", objMDAO.ChallanDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),  TO_DATE('", objMDAO.DeliveryDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),\r\n             '", objMDAO.UltimateDestination, "', ", objMDAO.UserIdInsert, ", '", objMDAO.ChallanNo, "', ", objMDAO.PartyID, ", '", objMDAO.InsuranceNo, "', '", objMDAO.LCNo, "', TO_DATE('", objMDAO.LCDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),  '", objMDAO.LCAmount, "', '", objMDAO.BLNo, "', TO_DATE('", objMDAO.BLDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'), '", objMDAO.PortCode, "', '", objMDAO.PortFrom, "', '", objMDAO.PortTo, "', '", objMDAO.BankId, "','", objMDAO.BankBranchId, "','", objMDAO.BankBranchId, "', '", objMDAO.LCForeignAmount, "', '", objMDAO.InsuranceAmount, "', '", objMDAO.LCForeingnCurrencyUnit, "','", objMDAO.Remarks, "','", objMDAO.ReleaseOrderNo, "',TO_DATE('", objMDAO.ReleaseOrderDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),'", objMDAO.PaymentMethod, "',", objMDAO.IsPaymentFinished, ",", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",", objMDAO.CountryId, ",TO_DATE('", objMDAO.TaxPaymentDate.ToString("MM/dd/yyyy"), "','MM/dd/yyyy'),'", objMDAO.PaymentInfo, "',", objMDAO.NoOfItem, ",", objMDAO.TotalPack, ",", objMDAO.PrtCode, ",", objMDAO.ExhRate, ",'", objMDAO.CPC, "')" };
                arrayLists.Add(string.Concat(challanID));
                arrayLists = this.AddBOEDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID);
                arrayLists = this.AddImportMainDeailInsertAdditionalInfo(arrayLists, arrexcel, objMDAO.ChallanID, objMDAO.ChallanDate);
                DataTable dataTable = new DataTable();
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool InsertChallanNo(ChallanNoMasterDAO objMDAO, ArrayList arrDetailDAO, ArrayList arrChallan)
        {
            ArrayList arrayLists = new ArrayList();
            objMDAO.ChallanBookID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_book_id_seq')"));
            object[] challanBookID = new object[] { "INSERT INTO trns_challan_no_master(\r\n            challan_book_id, challan_book_no, page_from, page_to, \r\n            User_id_insert, challan_type, Organization_id, challan_year,org_branch_reg_id, is_applicable_all_brnch)\r\n             VALUES (", objMDAO.ChallanBookID, ", '", objMDAO.ChallanBookNo, "', ", objMDAO.PageFrom, ", ", objMDAO.PageTo, ", ", objMDAO.UserIdInsert, ", ", objMDAO.ChallanType, ", ", objMDAO.OrganizationID, ", ", objMDAO.ChallanYear, ",", objMDAO.BranchID, ", ", objMDAO.IsApplicableAllBrnch, " )" };
            arrayLists.Add(string.Concat(challanBookID));
            if (arrChallan.Count > 0)
            {
                for (int i = 0; i < arrChallan.Count; i++)
                {
                    int item = (int)arrChallan[i];
                    object[] challanType = new object[] { "update trns_challan_no_detail set is_used=true where challan_type=", objMDAO.ChallanType, " and challan_book_id=", item };
                    arrayLists.Add(string.Concat(challanType));
                }
            }
            for (int j = 0; j < arrDetailDAO.Count; j++)
            {
                ChallanNoDetailDAO challanNoDetailDAO = (ChallanNoDetailDAO)arrDetailDAO[j];
                object[] objArray = new object[] { "INSERT INTO trns_challan_no_detail(\r\n            challan_book_id, page_no, challan_no,  challan_type)\r\n            VALUES (", objMDAO.ChallanBookID, ",", challanNoDetailDAO.PageNo, ", '", challanNoDetailDAO.ChallanNo, "',", challanNoDetailDAO.ChallanType, ")" };
                arrayLists.Add(string.Concat(objArray));
            }
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertPartyOpeningBalance(PurchaseMasterDAO objMDAO)
        {
            if (this.connDB.GetSingleValue("SELECT min(challan_id) FROM trns_party_balance") == null || Convert.ToString(this.connDB.GetSingleValue("SELECT min(challan_id) FROM trns_party_balance")) == "")
            {
                objMDAO.ChallanID = -1;
            }
            else
            {
                objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT min(challan_id) FROM trns_party_balance")) - 1;
            }
            object[] challanID = new object[] { "INSERT INTO trns_party_balance(\r\n            challan_id, organization_id, org_branch_reg_id,  challan_type, date_challan,user_id_insert, challan_no,party_id, remarks,credit_amount)\r\n            VALUES (", objMDAO.ChallanID, ",", objMDAO.OrganizatioID, ",", objMDAO.Org_branch_reg_id, ", '", objMDAO.ChallanType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", objMDAO.UserIdInsert, ",'", objMDAO.ChallanNo, "', ", objMDAO.PartyID, ",'", objMDAO.Remarks, "',", objMDAO.CreditAmount, " )" };
            string str = string.Concat(challanID);
            return this.connDB.ExecuteDML(str);
        }

        public bool InsertPreviousPurchaseData(PurchaseMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('prev_challan_id_seq')"));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str1 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType != 'F')
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str2 = string.Concat(objArray);
            }
            else
            {
                str2 = " null,  null, ";
            }
            str3 = (objMDAO.BankBranchId <= 0 ? " null " : objMDAO.BankBranchId.ToString());
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(", '", objMDAO.AggrementNo, "'");
            }
            if (!string.IsNullOrEmpty(objMDAO.Subject) && !string.IsNullOrEmpty(objMDAO.CChallanNo))
            {
                empty2 = ",Subject,contails_challan_no";
                string[] subject = new string[] { ", '", objMDAO.Subject, "', '", objMDAO.CChallanNo, "'" };
                empty3 = string.Concat(subject);
            }
            object[] challanID = new object[] { "INSERT INTO prev_trns_purchase_master(prev_challan_id,org_branch_reg_id,\r\n             Organization_id, challan_type, purchase_type, date_challan, \r\n             date_goods_delivery, party_id,Type,transaction_type,scroll_no,bank_name,branch_name, ultimate_destination, ", str, "  User_id_insert, challan_no, Remarks, bank_branch_id,payment_method,is_payment_finished,cash_amount,bank_amount,credit_amount,payment_info ", empty, " ", empty2, " )\r\n             VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str2, " '", objMDAO.Type, "','", objMDAO.TransactionType, "','", objMDAO.ScrollNo, "','", objMDAO.BankName, "','", objMDAO.BranchName, "','", objMDAO.UltimateDestination, "', ", str1, " ", objMDAO.UserIdInsert, ",\r\n             '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "', ", str3, ",'", objMDAO.PaymentMethod, "',", objMDAO.IsPaymentFinished, ",", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",'", objMDAO.PaymentInfo, "' ", empty1, " ", empty3, " )" };
            arrayLists.Add(string.Concat(challanID));
            arrayLists = this.AddPreviousDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertPrintInformation(int challan_id, string challan_no, int printed_by, DateTime printed_date)
        {
            int num = 1;
            DataTable dataTable = this.DBUtil.GetDataTable("select print_id from print_information order by print_id desc limit 1");
            if (dataTable.Rows.Count > 0)
            {
                num = Convert.ToInt32(dataTable.Rows[0]["print_id"]) + 1;
            }
            object[] challanId = new object[] { "INSERT INTO print_information (print_id, challan_id, challan_no, printed_by, printed_date) VALUES   ( ", num, ",", challan_id, ",'", challan_no, "','", printed_by, "', '", printed_date, "')" };
            string str = string.Concat(challanId);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertPurchaseData(PurchaseMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str1 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType != 'F')
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str2 = string.Concat(objArray);
            }
            else
            {
                str2 = " null,  null, ";
            }
            str3 = (objMDAO.BankBranchId <= 0 ? " null " : objMDAO.BankBranchId.ToString());
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(", '", objMDAO.AggrementNo, "'");
            }
            if (!string.IsNullOrEmpty(objMDAO.Subject) && !string.IsNullOrEmpty(objMDAO.CChallanNo))
            {
                empty2 = ",Subject,contails_challan_no";
                string[] subject = new string[] { ", '", objMDAO.Subject, "', '", objMDAO.CChallanNo, "'" };
                empty3 = string.Concat(subject);
            }
            object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id,\r\n             Organization_id, challan_type, purchase_type, date_challan, ref_challan_date,\r\n            date_goods_delivery, party_id,Type,transaction_type,scroll_no,bank_name,branch_name, ultimate_destination, ", str, "  User_id_insert, challan_no, Remarks, bank_branch_id,payment_method,is_payment_finished,cash_amount,bank_amount,credit_amount,payment_info ", empty, " ", empty2, " )\r\n      VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.RefChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str2, " '", objMDAO.Type, "','", objMDAO.TransactionType, "','", objMDAO.ScrollNo, "','", objMDAO.BankName, "','", objMDAO.BranchName, "','", objMDAO.UltimateDestination, "', ", str1, " ", objMDAO.UserIdInsert, ",\r\n             '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "', ", str3, ",'", objMDAO.PaymentMethod, "',", objMDAO.IsPaymentFinished, ",", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",'", objMDAO.PaymentInfo, "' ", empty1, " ", empty3, " )" };
            arrayLists.Add(string.Concat(challanID));
            if (objMDAO.CreditAmount > 0)
            {
                object[] challanID1 = new object[] { "INSERT INTO credit_transac_history(scroll_id, challan_id,org_branch_reg_id, challan_no, current_balance, payment_amount, \r\n                            balance_due, payment_type,cash_amount,bank_amount, payment_date,  \r\n                            date_insert,status,payment_status,organization_id,payment_info,proportion_vds,proportion_ait,amount_without_vds)\r\n                            VALUES(nextval('scroll_id'),", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",'", objMDAO.ChallanNo, "',", objMDAO.CashAmount + objMDAO.BankAmount + objMDAO.CreditAmount, ",", objMDAO.CashAmount + objMDAO.BankAmount, "\r\n                            \r\n                            ,", objMDAO.CreditAmount, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                           to_timestamp('", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),'P',", 0, ",", objMDAO.OrganizatioID, ",'", objMDAO.PaymentInfo, "', ", objMDAO.proportionVAT, ",", objMDAO.proportionAIT, ",", objMDAO.priceWithoutVDS, ")" };
                arrayLists.Add(string.Concat(challanID1));
            }
            arrayLists = this.AddDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertPurchaseDataExcel(PurchaseMasterDAO objMDAO, PurchaseDetailDAO arrDeailDAO)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
            objMDAO.Org_branch_reg_id = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str1 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType != 'F')
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str2 = string.Concat(objArray);
            }
            else
            {
                str2 = " null,  null, ";
            }
            str3 = (objMDAO.BankBranchId <= 0 ? " null " : objMDAO.BankBranchId.ToString());
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(", '", objMDAO.AggrementNo, "'");
            }
            if (!string.IsNullOrEmpty(objMDAO.Subject) && !string.IsNullOrEmpty(objMDAO.CChallanNo))
            {
                empty2 = ",Subject,contails_challan_no";
                string[] subject = new string[] { ", '", objMDAO.Subject, "', '", objMDAO.CChallanNo, "'" };
                empty3 = string.Concat(subject);
            }
            object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id,\r\n             Organization_id, challan_type, purchase_type, date_challan, ref_challan_date,\r\n            date_goods_delivery, party_id,Type,transaction_type,scroll_no,bank_name,branch_name, ultimate_destination, ", str, "  User_id_insert, challan_no, Remarks, bank_branch_id,payment_method,is_payment_finished,cash_amount,bank_amount,credit_amount,payment_info ", empty, " ", empty2, " )\r\n      VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.RefChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str2, " '", objMDAO.Type, "','", objMDAO.TransactionType, "','", objMDAO.ScrollNo, "','", objMDAO.BankName, "','", objMDAO.BranchName, "','", objMDAO.UltimateDestination, "', ", str1, " ", objMDAO.UserIdInsert, ",\r\n             '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "', ", str3, ",'", objMDAO.PaymentMethod, "',", objMDAO.IsPaymentFinished, ",", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",'", objMDAO.PaymentInfo, "' ", empty1, " ", empty3, " )" };
            arrayLists.Add(string.Concat(challanID));
            if (objMDAO.CreditAmount > 0)
            {
                object[] challanID1 = new object[] { "INSERT INTO credit_transac_history(scroll_id, challan_id,org_branch_reg_id, challan_no, current_balance, payment_amount, \r\n                            balance_due, payment_type,cash_amount,bank_amount, payment_date,  \r\n                            date_insert,status,payment_status,organization_id,payment_info,proportion_vds,proportion_ait,amount_without_vds)\r\n                            VALUES(nextval('scroll_id'),", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",'", objMDAO.ChallanNo, "',", objMDAO.CashAmount + objMDAO.BankAmount + objMDAO.CreditAmount, ",", objMDAO.CashAmount + objMDAO.BankAmount, "\r\n                            \r\n                            ,", objMDAO.CreditAmount, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                           to_timestamp('", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),'P',", 0, ",", objMDAO.OrganizatioID, ",'", objMDAO.PaymentInfo, "', ", objMDAO.proportionVAT, ",", objMDAO.proportionAIT, ",", objMDAO.priceWithoutVDS, ")" };
                arrayLists.Add(string.Concat(challanID1));
            }
            arrayLists = this.AddDeailInsertSQLExcel(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool InsertPurchaseDatawithadditional(PurchaseMasterDAO objMDAO, ArrayList arrDeailDAO, ArrayList arrexcel)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            objMDAO.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
            if (objMDAO.IsNewParty)
            {
                objMDAO.PartyID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('party_id_seq')"));
                object[] partyID = new object[] { "INSERT INTO trns_party (party_id, party_name,party_bin,party_address,ultimate_destination,User_id_insert)\r\n             VALUES (", objMDAO.PartyID, ", upper('", objMDAO.TransPartyName, "'),'", objMDAO.PartyTIN, "','", objMDAO.PartAddress, "','", objMDAO.UltimateDestination, "',", objMDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(partyID));
            }
            if (objMDAO.VehicleTypeM > 0 && objMDAO.VehicleTypeD > 0)
            {
                str = " vehicle_type_m, vehicle_type_d, vehicle_no, ";
                object[] vehicleTypeM = new object[] { (int)objMDAO.VehicleTypeM, ", ", objMDAO.VehicleTypeD, ", '", objMDAO.VehicleNo, "'," };
                str1 = string.Concat(vehicleTypeM);
            }
            if (objMDAO.ChallanType != 'F')
            {
                object[] objArray = new object[] { " to_timestamp('", null, null, null, null };
                objArray[1] = objMDAO.DeliveryDate.ToString("MM/dd/yyyy HH:mm");
                objArray[2] = "','MM/dd/yyyy HH24:MI'),  ";
                objArray[3] = objMDAO.PartyID;
                objArray[4] = ", ";
                str2 = string.Concat(objArray);
            }
            else
            {
                str2 = " null,  null, ";
            }
            str3 = (objMDAO.BankBranchId <= 0 ? " null " : objMDAO.BankBranchId.ToString());
            if (!string.IsNullOrEmpty(objMDAO.AggrementNo))
            {
                empty = ",aggrement_no";
                empty1 = string.Concat(", '", objMDAO.AggrementNo, "'");
            }
            if (!string.IsNullOrEmpty(objMDAO.Subject) && !string.IsNullOrEmpty(objMDAO.CChallanNo))
            {
                empty2 = ",Subject,contails_challan_no";
                string[] subject = new string[] { ", '", objMDAO.Subject, "', '", objMDAO.CChallanNo, "'" };
                empty3 = string.Concat(subject);
            }
            object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id,\r\n             Organization_id, challan_type, purchase_type, date_challan, ref_challan_date,\r\n            date_goods_delivery, party_id,Type,transaction_type,scroll_no,bank_name,branch_name, ultimate_destination, ", str, "  User_id_insert, challan_no, Remarks, bank_branch_id,payment_method,is_payment_finished,cash_amount,bank_amount,credit_amount,payment_info ", empty, " ", empty2, " )\r\n      VALUES ( ", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ", ", objMDAO.OrganizatioID, ", '", objMDAO.ChallanType, "', '", objMDAO.PurchaseType, "', to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.RefChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", str2, " '", objMDAO.Type, "','", objMDAO.TransactionType, "','", objMDAO.ScrollNo, "','", objMDAO.BankName, "','", objMDAO.BranchName, "','", objMDAO.UltimateDestination, "', ", str1, " ", objMDAO.UserIdInsert, ",\r\n             '", objMDAO.ChallanNo, "', '", objMDAO.Remarks, "', ", str3, ",'", objMDAO.PaymentMethod, "',", objMDAO.IsPaymentFinished, ",", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",", objMDAO.CreditAmount, ",'", objMDAO.PaymentInfo, "' ", empty1, " ", empty3, " )" };
            arrayLists.Add(string.Concat(challanID));
            if (objMDAO.CreditAmount > 0)
            {
                object[] challanID1 = new object[] { "INSERT INTO credit_transac_history(scroll_id, challan_id,org_branch_reg_id, challan_no, current_balance, payment_amount, \r\n                            balance_due, payment_type,cash_amount,bank_amount, payment_date,  \r\n                            date_insert,status,payment_status,organization_id,payment_info,proportion_vds,proportion_ait,amount_without_vds)\r\n                            VALUES(nextval('scroll_id'),", objMDAO.ChallanID, ",", objMDAO.Org_branch_reg_id, ",'", objMDAO.ChallanNo, "',", objMDAO.CashAmount + objMDAO.BankAmount + objMDAO.CreditAmount, ",", objMDAO.CashAmount + objMDAO.BankAmount, "\r\n                            \r\n                            ,", objMDAO.CreditAmount, ",'", objMDAO.PaymentMethod, "',", objMDAO.CashAmount, ",", objMDAO.BankAmount, ",to_timestamp('", objMDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n                           to_timestamp('", DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),'P',", 0, ",", objMDAO.OrganizatioID, ",'", objMDAO.PaymentInfo, "', ", objMDAO.proportionVAT, ",", objMDAO.proportionAIT, ",", objMDAO.priceWithoutVDS, ")" };
                arrayLists.Add(string.Concat(challanID1));
            }
            arrayLists = this.AddDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.ChallanID);
            arrayLists = this.AddMainDeailInsertAdditionalInfo(arrayLists, arrexcel, objMDAO.ChallanID, objMDAO.ChallanDate);
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public DataTable loadOrgBranch(int orgID)
        {
            string str = string.Concat("select branch_unit_name, org_branch_reg_id\r\n                            from org_branch_reg_info \r\n                            where is_deleted = false and organization_id = ", orgID);
            return this.connDB.GetDataTable(str);
        }

        public DataTable loadPartyByChallanNo(string challan)
        {
            string str = string.Concat("select tp.party_name, tp.party_address, tp.party_bin,tp.party_id\r\n                            from trns_party as tp\r\n                            left join trns_purchase_master as m\r\n                            on tp.party_id = m.party_id\r\n                            where m.challan_no = '", challan, "'");
            return this.connDB.GetDataTable(str);
        }

        public bool saveFiscalData(SetFiscalYearDAO objFiscal)
        {
            int num = Convert.ToInt32(this.connDB.GetSingleValue("SELECT coalesce(max(fiscal_id),0)  from fiscal_year"));
            objFiscal.FiscalID = Convert.ToInt16(num + 1);
            object[] fiscalID = new object[] { "INSERT INTO fiscal_year(fiscal_id, fiscal_year, from_date, to_date) VALUES('", objFiscal.FiscalID, "','", objFiscal.FiscalYear, "','", objFiscal.FromDate, "','", objFiscal.ToDate, "')" };
            string str = string.Concat(fiscalID);
            return this.connDB.ExecuteDML(str);
        }

        public bool UpdateImportData(string ApproveStage, ArrayList arrDeailDAO, int ChallanID)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                purchaseDetailDAO = (PurchaseDetailDAO)arrDeailDAO[i];
                if (purchaseDetailDAO.PropertyID1 > 0)
                {
                    str = (purchaseDetailDAO.IntProperty1 > 0 ? purchaseDetailDAO.IntProperty1.ToString() : "NULL");
                    object obj = str5;
                    object[] intProperty1 = new object[] { obj, " AND PROPERTY_ID1 = '", purchaseDetailDAO.IntProperty1, "' " };
                    str5 = string.Concat(intProperty1);
                }
                if (purchaseDetailDAO.PropertyID2 > 0)
                {
                    str1 = (purchaseDetailDAO.IntProperty2 > 0 ? purchaseDetailDAO.IntProperty2.ToString() : "NULL");
                    object obj1 = str5;
                    object[] intProperty2 = new object[] { obj1, " AND PROPERTY_ID2 = '", purchaseDetailDAO.IntProperty2, "' " };
                    str5 = string.Concat(intProperty2);
                }
                if (purchaseDetailDAO.PropertyID3 > 0)
                {
                    str2 = (purchaseDetailDAO.IntProperty3 > 0 ? purchaseDetailDAO.IntProperty3.ToString() : "NULL");
                    object obj2 = str5;
                    object[] intProperty3 = new object[] { obj2, " AND PROPERTY_ID3 = '", purchaseDetailDAO.IntProperty3, "'" };
                    str5 = string.Concat(intProperty3);
                }
                if (purchaseDetailDAO.PropertyID4 > 0)
                {
                    str3 = (purchaseDetailDAO.IntProperty4 > 0 ? purchaseDetailDAO.IntProperty4.ToString() : "NULL");
                    object obj3 = str5;
                    object[] intProperty4 = new object[] { obj3, " AND PROPERTY_ID4 = '", purchaseDetailDAO.IntProperty4, "'" };
                    str5 = string.Concat(intProperty4);
                }
                if (purchaseDetailDAO.PropertyID5 > 0)
                {
                    str4 = (purchaseDetailDAO.IntProperty5 > 0 ? purchaseDetailDAO.IntProperty5.ToString() : "NULL");
                    object obj4 = str5;
                    object[] intProperty5 = new object[] { obj4, " AND PROPERTY_ID5 = '", purchaseDetailDAO.IntProperty5, "' " };
                    str5 = string.Concat(intProperty5);
                }
                str5 = string.Concat(str5, " ) ");
                if (purchaseDetailDAO.PriceId > 0)
                {
                    purchaseDetailDAO.PriceId.ToString();
                }
                purchaseDetailDAO.DetailID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                object[] itemID = new object[] { "Update  trns_purchase_detail set  Item_id=", purchaseDetailDAO.ItemID, ", property_id1=", str, ", property_id2=", str1, ", property_id3=", str2, ", \r\n            property_id4=", str3, ", property_id5= ", str4, ", unit_id=", purchaseDetailDAO.UnitID, ", Quantity= ", purchaseDetailDAO.Quantity, ", actual_price=", purchaseDetailDAO.UnitPriceBDT, ", \r\n            Sd=", purchaseDetailDAO.SD, ", Vat=", purchaseDetailDAO.VAT, ",  User_id_insert=", purchaseDetailDAO.UserIdInsert, ", \r\n           is_source_tax_deduct=", purchaseDetailDAO.IsSrcTAXDeduct, ",   total_price =", purchaseDetailDAO.TotalPrice, ",  sd_rate=", purchaseDetailDAO.SDRate, ", vat_rate = ", purchaseDetailDAO.VATRate, ",\r\n           Remarks ='", purchaseDetailDAO.RemarksDetail, "', is_rebatable =  ", purchaseDetailDAO.IsRebatable, ", is_exempted = ", purchaseDetailDAO.IsExempted, ",\r\n           Cd =", purchaseDetailDAO.CD_Amount, ", Rd = ", purchaseDetailDAO.RD_Amount, ", Ait = ", purchaseDetailDAO.AIT_Amount, ", Atv = ", purchaseDetailDAO.ATV_Amount, ",at = ", purchaseDetailDAO.AT_Amount, ",\r\n           purchase_unit_price =", purchaseDetailDAO.PurchaseUnitPrice, ", purchase_vat=", purchaseDetailDAO.PurchaseVAT, ",\r\n           purchase_sd = ", purchaseDetailDAO.PurchaseSD, ", sale_unit_price =", purchaseDetailDAO.SaleUnitPrice, ", sale_vatable_price = ", purchaseDetailDAO.SaleVatablePrice, ", \r\n           sale_vat  = ", purchaseDetailDAO.SaleVAT, ", sale_sd = ", purchaseDetailDAO.SaleSD, " ,approver_stage ='", ApproveStage, "' where challan_id = ", ChallanID };
                arrayLists.Add(string.Concat(itemID));
            }
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool UpdatePurchase(int challanId)
        {
            string str = string.Concat("update trns_purchase_master set is_trns_accepted = true, where challan_id = ", challanId);
            return this.connDB.ExecuteDML(str);
        }

        public bool UpdatePurchaseData(string ApproveStage, ArrayList arrDeailDAO, int ChallanID)
        {
            ArrayList arrayLists = new ArrayList();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                purchaseDetailDAO = (PurchaseDetailDAO)arrDeailDAO[i];
                if (purchaseDetailDAO.PropertyID1 > 0)
                {
                    str = (purchaseDetailDAO.IntProperty1 > 0 ? purchaseDetailDAO.IntProperty1.ToString() : "NULL");
                    object obj = str5;
                    object[] intProperty1 = new object[] { obj, " AND PROPERTY_ID1 = '", purchaseDetailDAO.IntProperty1, "' " };
                    str5 = string.Concat(intProperty1);
                }
                if (purchaseDetailDAO.PropertyID2 > 0)
                {
                    str1 = (purchaseDetailDAO.IntProperty2 > 0 ? purchaseDetailDAO.IntProperty2.ToString() : "NULL");
                    object obj1 = str5;
                    object[] intProperty2 = new object[] { obj1, " AND PROPERTY_ID2 = '", purchaseDetailDAO.IntProperty2, "' " };
                    str5 = string.Concat(intProperty2);
                }
                if (purchaseDetailDAO.PropertyID3 > 0)
                {
                    str2 = (purchaseDetailDAO.IntProperty3 > 0 ? purchaseDetailDAO.IntProperty3.ToString() : "NULL");
                    object obj2 = str5;
                    object[] intProperty3 = new object[] { obj2, " AND PROPERTY_ID3 = '", purchaseDetailDAO.IntProperty3, "'" };
                    str5 = string.Concat(intProperty3);
                }
                if (purchaseDetailDAO.PropertyID4 > 0)
                {
                    str3 = (purchaseDetailDAO.IntProperty4 > 0 ? purchaseDetailDAO.IntProperty4.ToString() : "NULL");
                    object obj3 = str5;
                    object[] intProperty4 = new object[] { obj3, " AND PROPERTY_ID4 = '", purchaseDetailDAO.IntProperty4, "'" };
                    str5 = string.Concat(intProperty4);
                }
                if (purchaseDetailDAO.PropertyID5 > 0)
                {
                    str4 = (purchaseDetailDAO.IntProperty5 > 0 ? purchaseDetailDAO.IntProperty5.ToString() : "NULL");
                    object obj4 = str5;
                    object[] intProperty5 = new object[] { obj4, " AND PROPERTY_ID5 = '", purchaseDetailDAO.IntProperty5, "' " };
                    str5 = string.Concat(intProperty5);
                }
                str5 = string.Concat(str5, " ) ");
                if (purchaseDetailDAO.PriceId > 0)
                {
                    purchaseDetailDAO.PriceId.ToString();
                }
                purchaseDetailDAO.DetailID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                object[] itemID = new object[] { "Update  trns_purchase_detail set  Item_id=", purchaseDetailDAO.ItemID, ", property_id1=", str, ", property_id2=", str1, ", property_id3=", str2, ", \r\n            property_id4=", str3, ", property_id5= ", str4, ", unit_id=", purchaseDetailDAO.UnitID, ", Quantity= ", purchaseDetailDAO.Quantity, ", actual_price=", purchaseDetailDAO.UnitPriceBDT, ", \r\n            Sd=", purchaseDetailDAO.SD, ", Vat=", purchaseDetailDAO.VAT, ",  User_id_insert=", purchaseDetailDAO.UserIdInsert, ", \r\n           is_source_tax_deduct=", purchaseDetailDAO.IsSrcTAXDeduct, ",   total_price =", purchaseDetailDAO.TotalPrice, ",  sd_rate=", purchaseDetailDAO.SDRate, ", vat_rate = ", purchaseDetailDAO.VATRate, ",\r\n           Remarks ='", purchaseDetailDAO.RemarksDetail, "', is_rebatable =  ", purchaseDetailDAO.IsRebatable, ", is_exempted = ", purchaseDetailDAO.IsExempted, ",\r\n           Cd =", purchaseDetailDAO.CD_Amount, ", Rd = ", purchaseDetailDAO.RD_Amount, ", Ait = ", purchaseDetailDAO.AIT_Amount, ", Atv = ", purchaseDetailDAO.ATV_Amount, ",at = ", purchaseDetailDAO.AT_Amount, ",\r\n           purchase_unit_price =", purchaseDetailDAO.PurchaseUnitPrice, ", purchase_vat=", purchaseDetailDAO.PurchaseVAT, ",\r\n           purchase_sd = ", purchaseDetailDAO.PurchaseSD, ", sale_unit_price =", purchaseDetailDAO.SaleUnitPrice, ", sale_vatable_price = ", purchaseDetailDAO.SaleVatablePrice, ", \r\n           sale_vat  = ", purchaseDetailDAO.SaleVAT, ", sale_sd = ", purchaseDetailDAO.SaleSD, " ,approver_stage ='", ApproveStage, "' where challan_id = ", ChallanID };
                arrayLists.Add(string.Concat(itemID));
            }
            DataTable dataTable = new DataTable();
            return this.connDB.ExecuteBatchDML(arrayLists);
        }
    }
}