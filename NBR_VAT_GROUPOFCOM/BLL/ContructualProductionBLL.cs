using NBR_VAT_GROUPOFCOM.BLL.NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.Model;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class ContructualProductionBLL
    {
        private DBUtility connDB = new DBUtility();

        private trnsPurchaseMasterBLL objPMBLL = new trnsPurchaseMasterBLL();

        private UnitBLL objUntConversion = new UnitBLL();

        public ContructualProductionBLL()
        {
        }

        private ArrayList AddMainDeailInsertAdditionalInfo(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID, DateTime dateChallan)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                contructualProductionIssueDAO.additionalInfoId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('additional_info_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_production_rcv_additional(\r\n                                additional_info_id, receive_id, item_id,status, property_id1, property_id2, property_id3, \r\n                                property_id4, property_id5, property_id1_value, property_id2_value, property_id3_value, \r\n                                property_id4_value, property_id5_value,  User_id_insert,organization_id,org_branch_id,date_challan)\r\n    VALUES (", contructualProductionIssueDAO.additionalInfoId, ", ", ChallanID, ", ", contructualProductionIssueDAO.Item_id, ",  'F', ", contructualProductionIssueDAO.Property_id1, ", ", contructualProductionIssueDAO.Property_id2, ", ", contructualProductionIssueDAO.Property_id3, ", ", contructualProductionIssueDAO.Property_id4, ",\r\n              ", contructualProductionIssueDAO.Property_id5, ", '", contructualProductionIssueDAO.Property1_Text, "',' ", contructualProductionIssueDAO.Property2_Text, "', ' ", contructualProductionIssueDAO.Property3_Text, "', '", contructualProductionIssueDAO.Property4_Text, "','", contructualProductionIssueDAO.Property5_Text, "',", contructualProductionIssueDAO.User_id_insert, ", ", num, ",", num1, ", to_timestamp('", dateChallan.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        private ArrayList AddMainDeailInsertPurchaseTable(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID)
        {
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
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", contructualProductionIssueDAO.Item_id, "' ");
                if (contructualProductionIssueDAO.Property_id1 != 0)
                {
                    str = contructualProductionIssueDAO.Property_id1.ToString();
                    object obj = str5;
                    object[] propertyId1 = new object[] { obj, " AND PROPERTY_ID1 = '", contructualProductionIssueDAO.Property_id1, "' " };
                    str5 = string.Concat(propertyId1);
                }
                if (contructualProductionIssueDAO.Property_id2 != 0)
                {
                    str1 = contructualProductionIssueDAO.Property_id2.ToString();
                    object obj1 = str5;
                    object[] propertyId2 = new object[] { obj1, " AND PROPERTY_ID2 = '", contructualProductionIssueDAO.Property_id2, "' " };
                    str5 = string.Concat(propertyId2);
                }
                if (contructualProductionIssueDAO.Property_id3 != 0)
                {
                    str2 = contructualProductionIssueDAO.Property_id3.ToString();
                    object obj2 = str5;
                    object[] propertyId3 = new object[] { obj2, " AND PROPERTY_ID3 = '", contructualProductionIssueDAO.Property_id3, "'" };
                    str5 = string.Concat(propertyId3);
                }
                if (contructualProductionIssueDAO.Property_id4 != 0)
                {
                    str3 = contructualProductionIssueDAO.Property_id4.ToString();
                    object obj3 = str5;
                    object[] propertyId4 = new object[] { obj3, " AND PROPERTY_ID4 = '", contructualProductionIssueDAO.Property_id4, "'" };
                    str5 = string.Concat(propertyId4);
                }
                if (contructualProductionIssueDAO.Property_id5 != 0)
                {
                    str4 = contructualProductionIssueDAO.Property_id5.ToString();
                    object obj4 = str5;
                    object[] propertyId5 = new object[] { obj4, " AND PROPERTY_ID5 = '", contructualProductionIssueDAO.Property_id5, "' " };
                    str5 = string.Concat(propertyId5);
                }
                str5 = string.Concat(str5, " ) ");
                contructualProductionIssueDAO.DetailID = Convert.ToInt64(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_purchase_detail(\r\n                                Challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n                                property_id4, property_id5, unit_id, Quantity, User_id_insert, lot_no, detail_id, Remarks, sale_unit_price,sale_vatable_price,\r\n                                sale_vat,sale_sd,s_p_return,vat_rate,sd_rate,purchase_unit_price,purchase_vat,purchase_sd,total_price,batch_no,mfg_date,expiry_date,purchase_type)\r\n    VALUES (", ChallanID, ", ", contructualProductionIssueDAO.RowNo, ", ", contructualProductionIssueDAO.Item_id, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", contructualProductionIssueDAO.Unit_id, ", ", contructualProductionIssueDAO.Quantity, ", ", contructualProductionIssueDAO.User_id_insert, ", ", str5, ", ", contructualProductionIssueDAO.DetailID, ", '", contructualProductionIssueDAO.Remark, "',", contructualProductionIssueDAO.SaleUnitPrice, ",", contructualProductionIssueDAO.SaleVatablePrice, ", ", contructualProductionIssueDAO.SaleVat, ",", contructualProductionIssueDAO.SaleSD, ",\r\n            ", contructualProductionIssueDAO.SpReturn, ",", contructualProductionIssueDAO.VatRate, ",", contructualProductionIssueDAO.SDRate, ",", contructualProductionIssueDAO.PurchaseUnitPrice, ",", contructualProductionIssueDAO.PurchaseVat, ",", contructualProductionIssueDAO.PurchaseSD, ",", contructualProductionIssueDAO.TotalPrice, ",'", contructualProductionIssueDAO.Batch_no, "',to_timestamp('", null, null, null, null, null, null };
                challanID[53] = contructualProductionIssueDAO.MfgDate.ToString("MM/dd/yyyy HH:mm");
                challanID[54] = "','MM/dd/yyyy HH24:MI'),to_timestamp('";
                challanID[55] = contructualProductionIssueDAO.ExpiryDate.ToString("MM/dd/yyyy HH:mm");
                challanID[56] = "','MM/dd/yyyy HH24:MI'),'";
                challanID[57] = contructualProductionIssueDAO.PurchaseType;
                challanID[58] = "')";
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        public DataTable GetBatchNo()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.connDB.GetDataTable("select production_id,batch_no from trns_production_master where trns_status='I' and batch_no!='' ");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getCgChallanNo(int crChallanNo)
        {
            string str = string.Concat("select cg_challan_batch_no from trns_production_master where cg_challan_batch_no = ", crChallanNo, " ");
            return this.connDB.GetDataTable(str);
        }

        private ArrayList getCPDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int productionID)
        {
            ArrayList arrayLists;
            try
            {
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
                    ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                    contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                    if (contructualProductionIssueDAO.Property_id1 != 0)
                    {
                        str = contructualProductionIssueDAO.Property_id1.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id2 != 0)
                    {
                        str1 = contructualProductionIssueDAO.Property_id2.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id3 != 0)
                    {
                        str2 = contructualProductionIssueDAO.Property_id3.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id4 != 0)
                    {
                        str3 = contructualProductionIssueDAO.Property_id4.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id5 != 0)
                    {
                        str4 = contructualProductionIssueDAO.Property_id5.ToString();
                    }
                    object[] objArray = new object[] { " INSERT INTO trns_production_detail (Production_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, user_id_insert,status,unit_price)\r\n                                VALUES (", productionID, ", ", contructualProductionIssueDAO.RowNo, ", ", contructualProductionIssueDAO.Item_id, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", contructualProductionIssueDAO.Unit_id, ", ", contructualProductionIssueDAO.Quantity, ", ", contructualProductionIssueDAO.User_id_insert, ",'", contructualProductionIssueDAO.Status, "', ", contructualProductionIssueDAO.Price, ")" };
                    arrDetailList.Add(string.Concat(objArray));
                    this.updateAvailableQnt(contructualProductionIssueDAO.Quantity, contructualProductionIssueDAO.Item_id, contructualProductionIssueDAO.Unit_id);
                }
                arrayLists = arrDetailList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return arrayLists;
        }

        private ArrayList getCPDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int productionID, ArrayList arrDetailchk)
        {
            ArrayList arrayLists;
            try
            {
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
                    ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                    contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                    ContructualProductionIsCheck contructualProductionIsCheck = new ContructualProductionIsCheck();
                    contructualProductionIsCheck = (ContructualProductionIsCheck)arrDetailchk[i];
                    if (contructualProductionIssueDAO.Property_id1 != 0)
                    {
                        str = contructualProductionIssueDAO.Property_id1.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id2 != 0)
                    {
                        str1 = contructualProductionIssueDAO.Property_id2.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id3 != 0)
                    {
                        str2 = contructualProductionIssueDAO.Property_id3.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id4 != 0)
                    {
                        str3 = contructualProductionIssueDAO.Property_id4.ToString();
                    }
                    if (contructualProductionIssueDAO.Property_id5 != 0)
                    {
                        str4 = contructualProductionIssueDAO.Property_id5.ToString();
                    }
                    if (contructualProductionIsCheck.IS_item_checkt)
                    {
                        object[] objArray = new object[] { " INSERT INTO trns_production_detail (Production_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, user_id_insert,status,is_item_check)\r\n                                VALUES (", productionID, ", ", contructualProductionIssueDAO.RowNo, ", ", contructualProductionIssueDAO.Item_id, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", contructualProductionIssueDAO.Unit_id, ", ", contructualProductionIssueDAO.Quantity, ", ", contructualProductionIssueDAO.User_id_insert, ",'", contructualProductionIssueDAO.Status, "','", contructualProductionIsCheck.IS_item_checkt, "')" };
                        arrDetailList.Add(string.Concat(objArray));
                    }
                    this.updateAvailableQnt(contructualProductionIssueDAO.Quantity, contructualProductionIssueDAO.Item_id, contructualProductionIssueDAO.Unit_id);
                }
                arrayLists = arrDetailList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return arrayLists;
        }

        private ArrayList getCPReceiveDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int productionID)
        {
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
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDeailDAO[i];
                if (contructualProductionIssueDAO.Property_id1 != 0)
                {
                    str = contructualProductionIssueDAO.Property_id1.ToString();
                }
                if (contructualProductionIssueDAO.Property_id2 != 0)
                {
                    str1 = contructualProductionIssueDAO.Property_id2.ToString();
                }
                if (contructualProductionIssueDAO.Property_id3 != 0)
                {
                    str2 = contructualProductionIssueDAO.Property_id3.ToString();
                }
                if (contructualProductionIssueDAO.Property_id4 != 0)
                {
                    str3 = contructualProductionIssueDAO.Property_id4.ToString();
                }
                if (contructualProductionIssueDAO.Property_id5 != 0)
                {
                    str4 = contructualProductionIssueDAO.Property_id5.ToString();
                }
                object[] objArray = new object[] { " INSERT INTO trns_production_detail (Production_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity,unit_price, user_id_insert,status)\r\n                                VALUES (", productionID, ", ", contructualProductionIssueDAO.RowNo, ", ", contructualProductionIssueDAO.Item_id, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", contructualProductionIssueDAO.Unit_id, ", ", contructualProductionIssueDAO.Quantity, ", ", contructualProductionIssueDAO.PriceValue, ", ", contructualProductionIssueDAO.User_id_insert, ",'", contructualProductionIssueDAO.Status, "')" };
                arrDetailList.Add(string.Concat(objArray));
            }
            return arrDetailList;
        }

        public DataTable GetFinishByPartyandChallan(DateTime fDate, DateTime tDate, int partyId, int challanId, string batchNo, int batch)
        {
            string str = "";
            if (partyId != -99)
            {
                str = string.Concat(str, " and tpm.party_id=", partyId);
            }
            if (challanId != -99)
            {
                str = string.Concat(str, " and tpm.production_id=", challanId);
            }
            if (batch != -99)
            {
                str = string.Concat(str, " and tpm.batch_no='", batchNo, "'");
            }
            string[] strArrays = new string[] { "select distinct tpm.challan_batch_no, to_char(tpm.date_production,'dd-Mon-yyyy') as challan_date,to_char(tpm.date_production::Time, 'HH:MI AM') issuetime, i.item_name,\r\n                            iu.unit_code,tpm.Quantity ,tp.party_name,party_bin,party_address                          \r\n                            from trns_production_master as tpm\r\n                            inner join trns_production_detail as tpd on tpm.production_id = tpd.production_id\r\n                            inner join item as i on i.item_id = tpm.finish_product_id\r\n                            inner join item_unit as iu on iu.unit_id = i.unit_id \r\n                            inner join trns_party tp on tp.party_id = tpm.party_id\r\n                            where tpm.trns_status='I' and  CAST(tpm.date_production AS DATE) >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                            AND CAST(tpm.date_production AS DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') ", str, " " };
            string str1 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getFinishProduct(string fDate, string tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] objArray = new object[] { "select distinct i.item_id, i.item_name\r\n                            from item as i\r\n                            inner join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                            inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                            where tpd.date_insert >= '", fDate, "' AND tpd.date_insert <= '", tDate, "' \r\n                            AND tpd.is_deleted = false AND tpd.s_p_return = 3 and i.product_type = 'C'  and tpm.organization_id=", num, " " };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getFinishProductActualQuantitybyRcvId(int rcvChallanId, int FitemId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select d.quantity ,iu.unit_code\r\n                            from trns_production_master m\r\n                            inner join trns_production_detail d on d.production_id = m.production_id\r\n                            inner join item_unit iu  on d.unit_id = iu.unit_id\r\n                            where m.trns_status = 'R' and m.production_id = ", rcvChallanId, " and m.finish_product_id = ", FitemId, " and m.is_deleted = false order by m.production_id desc" };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getFinishProductQuantitybyRcvId(int rcvChallanId, int FitemId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select quantity \r\n                            from trns_production_master \r\n                            where trns_status = 'R' and production_id = ", rcvChallanId, " and finish_product_id = ", FitemId, " and is_deleted = false order by production_id desc" };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable getFinishProductReportData(string fDate, string tDate, long itemID, string challan)
        {
            string str = "";
            string str1 = "";
            if (itemID > (long)0)
            {
                str = string.Concat(" AND tpd.item_id = ", itemID);
            }
            if (challan != "")
            {
                str1 = string.Concat(" AND tpm.challan_no = '", challan, "'");
            }
            string[] strArrays = new string[] { "select tpm.challan_no, to_char(tpm.date_challan,'dd-Mon-yyyy') as challan_date, i.item_name,\r\n                            iu.unit_name,tpd.Quantity, tpd.sale_unit_price, (tpd.Quantity*tpd.sale_unit_price) as total_price,\r\n                            tpd.sale_sd,tpd.sale_vat,(tpd.Quantity*tpd.sale_unit_price+tpd.sale_sd+tpd.sale_vat) as total_price_vat_sd\r\n                            from trns_purchase_master as tpm\r\n                            inner join trns_purchase_detail as tpd\r\n                            on tpm.challan_id = tpd.challan_id\r\n                            inner join item as i\r\n                            on i.item_id = tpd.item_id\r\n                            inner join item_unit as iu\r\n                            on iu.unit_id = tpd.unit_id\r\n                            where tpd.date_insert >= '", fDate, "' AND tpd.date_insert <= '", tDate, "'\r\n                            ", str, " ", str1, " AND s_p_return = 3" };
            string str2 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str2);
        }

        private ArrayList getFPReceiveDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int productionID)
        {
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
                FinishProductReceiveFromSelfProductionDAO finishProductReceiveFromSelfProductionDAO = new FinishProductReceiveFromSelfProductionDAO();
                finishProductReceiveFromSelfProductionDAO = (FinishProductReceiveFromSelfProductionDAO)arrDeailDAO[i];
                if (finishProductReceiveFromSelfProductionDAO.PropertyID1 != 0)
                {
                    str = finishProductReceiveFromSelfProductionDAO.PropertyID1.ToString();
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID2 != 0)
                {
                    str1 = finishProductReceiveFromSelfProductionDAO.PropertyID2.ToString();
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID3 != 0)
                {
                    str2 = finishProductReceiveFromSelfProductionDAO.PropertyID3.ToString();
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID4 != 0)
                {
                    str3 = finishProductReceiveFromSelfProductionDAO.PropertyID4.ToString();
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID5 != 0)
                {
                    str4 = finishProductReceiveFromSelfProductionDAO.PropertyID5.ToString();
                }
                object[] objArray = new object[] { " INSERT INTO trns_production_detail (Production_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, user_id_insert,status)\r\n                                VALUES (", productionID, ", ", finishProductReceiveFromSelfProductionDAO.RowNO, ", ", finishProductReceiveFromSelfProductionDAO.ItemID, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", finishProductReceiveFromSelfProductionDAO.UnitID, ", ", finishProductReceiveFromSelfProductionDAO.Quantity, ", ", finishProductReceiveFromSelfProductionDAO.UserID, ",'", finishProductReceiveFromSelfProductionDAO.Status, "')" };
                arrDetailList.Add(string.Concat(objArray));
            }
            return arrDetailList;
        }

        public DataTable getInfo(int item_id, string prChallanNo)
        {
            object[] itemId = new object[] { "select batch_no,mfg_date,expiry_date from trns_production_master where finish_product_id = ", item_id, " and challan_batch_no='", prChallanNo, "' " };
            string str = string.Concat(itemId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetIngredience(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["organization_id"]);
            object[] str = new object[] { "select distinct i.item_id, i.item_name\r\n                        from item as i\r\n                        inner join trns_production_detail as tprd\r\n                        on i.item_id = tprd.item_id\r\n                        where tprd.date_insert >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and i.organization_id=", num, "\r\n                        order by item_id" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetIngredienceByPartyandChallan(DateTime fDate, DateTime tDate, int partyId, int challanId, string batchNo, int batch)
        {
            string str = "";
            if (partyId != -99)
            {
                str = string.Concat(str, " and tpm.party_id=", partyId);
            }
            if (challanId != -99)
            {
                str = string.Concat(str, " and tpm.production_id=", challanId);
            }
            if (batch != -99)
            {
                str = string.Concat(str, " and tpm.batch_no='", batchNo, "'");
            }
            string[] strArrays = new string[] { "select tpm.challan_batch_no, to_char(tpm.date_production,'dd-Mon-yyyy') as challan_date, i.item_name,\r\n                            iu.unit_code,tpd.Quantity ,'' remark                         \r\n                            from trns_production_master as tpm\r\n                            inner join trns_production_detail as tpd on tpm.production_id = tpd.production_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join item_unit as iu on iu.unit_id = tpd.unit_id \r\n                            where tpm.trns_status='I' and  CAST(tpm.date_production AS DATE) >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                            AND CAST(tpm.date_production AS DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')  ", str, " " };
            string str1 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getIssuedPdQuantity(DateTime fDate, DateTime tDate, long ItemID)
        {
            object[] str = new object[] { "select tprm.production_id,tprm.challan_batch_no, to_char(tprm.date_production,'dd/MM/yyyy') as date_production,tprm.date_insert,i.item_name,iu.unit_code,tprd.Quantity,\r\n                        tprm.quantity as finish_quantity, (select ui.unit_name from item i \r\n                        inner join item_unit ui on i.unit_id=ui.unit_id\r\n                        where i.item_id=tprm.finish_product_id) as finish_unit,\r\n                        case when trns_status='I' then 'Issued'\r\n                        when trns_status='R' then 'Received' end Status\r\n                        from trns_production_master as tprm\r\n                        inner join trns_production_detail as tprd\r\n                        on tprm.Production_id = tprd.Production_id\r\n                        inner join item as i\r\n                        on i.item_id = tprd.item_id\r\n                        inner join item_unit as iu\r\n                        on tprd.unit_id = iu.unit_id\r\n                        where tprd.date_insert>= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.item_id = ", ItemID, " AND status = 'I' \r\n                        order by tprm.date_insert \r\n\t\t\t            --  tprm.date_production" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getIssuedPdQuantityByFPP(DateTime fDate, DateTime tDate, long ItemID, long finishProductId)
        {
            string str = "";
            if (ItemID > (long)0)
            {
                str = string.Concat("AND tprd.item_id =", ItemID, " ");
            }
            object[] objArray = new object[] { "select  i.item_id,i.item_name,iu.unit_code,SUM(tprd.Quantity) as issued_qnt,tprm.finish_product_id,to_char(tprm.date_production,'dd-MM-yyyy') as date_production,  (select ui.unit_name from item i \r\n                        inner join item_unit ui on i.unit_id=ui.unit_id\r\n                        where i.item_id=tprm.finish_product_id) as finish_unit,\r\n                        Sum(tprm.quantity) as finish_quantity \r\n                       from trns_production_master as tprm\r\n                        inner join trns_production_detail as tprd\r\n                        on tprm.Production_id = tprd.Production_id\r\n                        inner join item as i\r\n                        on i.item_id = tprd.item_id\r\n                        inner join item_unit as iu\r\n                        on tprd.unit_id = iu.unit_id\r\n                        where tprd.date_insert>= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        ", str, " AND tprm.finish_product_id=", finishProductId, " AND status = 'I'\r\n                        group by  i.item_id,i.item_name,iu.unit_code,tprm.finish_product_id,tprm.date_production\r\n                        order by i.item_id" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetIssuedProductQuantity(int pricedID)
        {
            string str = string.Concat("select coalesce( sum(quantity),0) quantity from trns_production_master where price_id=", pricedID);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getIssueQuantity(DateTime fDate, DateTime tDate, long ItemID)
        {
            object[] str = new object[] { "select tprm.challan_batch_no, to_char(tprm.date_production,'dd-MM-yyyy') as date_production ,i.item_name,iu.unit_code,tprd.Quantity,\r\n                        case when trns_status='I' then 'Issued'\r\n                        when trns_status='R' then 'Received' end Status\r\n                        from trns_production_master as tprm\r\n                        inner join trns_production_detail as tprd\r\n                        on tprm.Production_id = tprd.Production_id\r\n                        inner join item as i\r\n                        on i.item_id = tprd.item_id\r\n                        inner join item_unit as iu\r\n                        on tprd.unit_id = iu.unit_id\r\n                        where tprd.date_insert>= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.item_id = ", ItemID, " AND status = 'I' \r\n                        order by tprm.date_production" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetlotNo(ContructualProductionIssueDAO objCPM, ArrayList arrDetail)
        {
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDetail[0];
            string str = string.Concat("select  pd.lot_no,pd.quantity,pd.lot_no_status  from trns_purchase_detail pd \r\n                        inner join item i on pd.item_id =i.item_id\r\n                        where pd.item_id=", contructualProductionIssueDAO.Item_id, " and pd.lot_no_status =false limit 1");
            return this.connDB.GetDataTable(str);
        }

        private ArrayList getMainDeailInsertPurchaseTable(ArrayList arrDetailList, ArrayList arrDeailDAO, int ChallanID)
        {
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
                FinishProductReceiveFromSelfProductionDAO finishProductReceiveFromSelfProductionDAO = new FinishProductReceiveFromSelfProductionDAO();
                finishProductReceiveFromSelfProductionDAO = (FinishProductReceiveFromSelfProductionDAO)arrDeailDAO[i];
                str5 = string.Concat(" ( SELECT coalesce(MAX(LOT_NO)+1,1) LOT_NO FROM trns_purchase_detail WHERE ITEM_ID = '", finishProductReceiveFromSelfProductionDAO.ItemID, "' ");
                if (finishProductReceiveFromSelfProductionDAO.PropertyID1 != 0)
                {
                    str = finishProductReceiveFromSelfProductionDAO.PropertyID1.ToString();
                    object obj = str5;
                    object[] propertyID1 = new object[] { obj, " AND PROPERTY_ID1 = '", finishProductReceiveFromSelfProductionDAO.PropertyID1, "' " };
                    str5 = string.Concat(propertyID1);
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID2 != 0)
                {
                    str1 = finishProductReceiveFromSelfProductionDAO.PropertyID2.ToString();
                    object obj1 = str5;
                    object[] propertyID2 = new object[] { obj1, " AND PROPERTY_ID2 = '", finishProductReceiveFromSelfProductionDAO.PropertyID2, "' " };
                    str5 = string.Concat(propertyID2);
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID3 != 0)
                {
                    str2 = finishProductReceiveFromSelfProductionDAO.PropertyID3.ToString();
                    object obj2 = str5;
                    object[] propertyID3 = new object[] { obj2, " AND PROPERTY_ID3 = '", finishProductReceiveFromSelfProductionDAO.PropertyID3, "'" };
                    str5 = string.Concat(propertyID3);
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID4 != 0)
                {
                    str3 = finishProductReceiveFromSelfProductionDAO.PropertyID4.ToString();
                    object obj3 = str5;
                    object[] propertyID4 = new object[] { obj3, " AND PROPERTY_ID4 = '", finishProductReceiveFromSelfProductionDAO.PropertyID4, "'" };
                    str5 = string.Concat(propertyID4);
                }
                if (finishProductReceiveFromSelfProductionDAO.PropertyID5 != 0)
                {
                    str4 = finishProductReceiveFromSelfProductionDAO.PropertyID5.ToString();
                    object obj4 = str5;
                    object[] propertyID5 = new object[] { obj4, " AND PROPERTY_ID5 = '", finishProductReceiveFromSelfProductionDAO.PropertyID5, "' " };
                    str5 = string.Concat(propertyID5);
                }
                str5 = string.Concat(str5, " ) ");
                finishProductReceiveFromSelfProductionDAO.DetailID = Convert.ToInt64(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                object[] challanID = new object[] { "INSERT INTO trns_purchase_detail(\r\n            Challan_id, row_no, Item_id, property_id1, property_id2, property_id3, \r\n            property_id4, property_id5, unit_id, Quantity, User_id_insert, lot_no, detail_id, Remarks, sale_unit_price,sale_vatable_price,sale_vat,sale_sd,s_p_return,purchase_unit_price,vat_rate,sd_rate,purchase_vat,purchase_sd)\r\n    VALUES (", ChallanID, ", ", finishProductReceiveFromSelfProductionDAO.RowNO, ", ", finishProductReceiveFromSelfProductionDAO.ItemID, ",  ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",\r\n              ", finishProductReceiveFromSelfProductionDAO.UnitID, ", ", finishProductReceiveFromSelfProductionDAO.Quantity, ", ", finishProductReceiveFromSelfProductionDAO.UserID, ", ", str5, ", ", finishProductReceiveFromSelfProductionDAO.DetailID, ", '", finishProductReceiveFromSelfProductionDAO.Remark, "',", finishProductReceiveFromSelfProductionDAO.SaleUnitPrice, ",", finishProductReceiveFromSelfProductionDAO.SaleVatablePrice, ", ", finishProductReceiveFromSelfProductionDAO.SaleVat, ",", finishProductReceiveFromSelfProductionDAO.SaleSD, ",", finishProductReceiveFromSelfProductionDAO.SpReturn, ",\r\n                 ", finishProductReceiveFromSelfProductionDAO.PurchaseUnitPrice, ",", finishProductReceiveFromSelfProductionDAO.VatRate, ",", finishProductReceiveFromSelfProductionDAO.SDRate, ",", finishProductReceiveFromSelfProductionDAO.SaleVat, ",", finishProductReceiveFromSelfProductionDAO.SaleSD, ")" };
                arrDetailList.Add(string.Concat(challanID));
            }
            return arrDetailList;
        }

        public DataTable GetOpeningBalance(long ItemID, DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable;
            try
            {
                Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                string str = string.Concat("Select SUM(quantity) availstock,i.item_name,iu.unit_code from trns_purchase_detail tpd \r\ninner join trns_purchase_master tpm on tpd.challan_id=tpm.challan_id \r\ninner join item i on i.item_id= tpd.item_id\r\ninner join item_unit iu on i.unit_id=iu.unit_id  where tpm.date_challan >=TO_DATE('10/01/2020','MM/dd/yyyy') AND tpm.date_challan <=TO_DATE('10/23/2020','MM/dd/yyyy')    AND tpd.Is_deleted = false and tpd.item_id=", ItemID, "   group by i.item_name,iu.unit_code  ");
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetOpeningStock(long ItemID, DateTime startDate)
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"]);
                object[] str = new object[] { " SELECT coalesce((\r\n            ( \r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PURCHASE_DETAIL D INNER JOIN TRNS_PURCHASE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'dd/MM/yyyy'), 'dd/MM/yyyy') <= TO_DATE('", startDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "     \r\n            and M.CHALLAN_TYPE in ('P', 'F', 'R','C','O','T'))\r\n            -\r\n            ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'dd/MM/yyyy'), 'dd/MM/yyyy') <= TO_DATE('", startDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'P' )\r\n            -\r\n             ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_PRODUCTION_DETAIL D INNER JOIN TRNS_PRODUCTION_MASTER M ON M.PRODUCTION_ID = D.PRODUCTION_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_PRODUCTION, 'dd/MM/yyyy'), 'dd/MM/yyyy') < TO_DATE('", startDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, " AND D.STATUS = 'I' ))\r\n           -\r\n            ( ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_SALE_DETAIL D INNER JOIN TRNS_SALE_MASTER M ON M.Challan_id = D.Challan_id \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_CHALLAN, 'dd/MM/yyyy'), 'dd/MM/yyyy') <= TO_DATE('", startDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "    \r\n            and M.CHALLAN_TYPE in ('S', 'F', 'R') )\r\n          -\r\n          ( select coalesce(sum(D.QUANTITY),0) \r\n            from TRNS_NOTE_DETAIL D INNER JOIN TRNS_NOTE_MASTER M ON M.NOTE_ID = D.NOTE_ID \r\n\t        WHERE TO_DATE(TO_CHAR(M.DATE_NOTE, 'dd/MM/yyyy'), 'dd/MM/yyyy') <= TO_DATE('", startDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy')\r\n            and D.ITEM_ID = ", ItemID, " AND M.ORGANIZATION_ID = ", num, " AND M.ORG_BRANCH_REG_ID =", num1, "   \r\n            and M.NOTE_TYPE in ('C','D') and D.Status = 'S' ))\r\n          \r\n           --transfer issue will be deducted\r\n            -\r\n            (select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'dd/MM/yyyy'), 'dd/MM/yyyy') <= TO_DATE('", startDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy')\r\n            AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.issuing_branch_id = ", num1, " AND M.transfer_status='I' AND M.is_deleted=false)\r\n\r\n           --+\r\n            --transfer receive will be added(If receive from transfer then purchase table CHALLAN_TYPE = T)\r\n            --(select coalesce(sum(D.quantity),0) from trns_transfer_master M inner join trns_transfer_detail D on M.transfer_id=D.transfer_id\r\n            --where TO_DATE(TO_CHAR(M.ISSUES_DATE, 'dd/MM/yyyy'), 'dd/MM/yyyy') <= TO_DATE('", startDate.ToString("MM/dd/yyyy"), "','dd/MM/yyyy')\r\n            --AND D.ITEM_ID =  ", ItemID, " AND M.organization_id = ", num, " AND M.receiving_branch_id = ", num1, " AND M.transfer_status='R' AND M.is_deleted=false)\r\n\r\n          ),0) availStock, u.UNIT_ID , u.unit_name, u.unit_code, i.sub_category_id, ic.parent_id, i.item_type, i.is_exempted, i.is_rebatable,i.item_name  FROM ITEM i \r\n\t      left outer join ITEM_unit u on u.unit_id = i.unit_id   \r\n          inner join item_category ic on ic.category_id = i.sub_category_id\r\n          WHERE I.ITEM_ID = ", ItemID, "  " };
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

        public DataTable getOrgBranchName(int orgID)
        {
            string str = string.Concat("select distinct org_branch_reg_id, branch_unit_name from org_branch_reg_info where organization_id = ", orgID, " and is_deleted = false order by org_branch_reg_id");
            return this.connDB.GetDataTable(str);
        }

        public decimal getPrevProQuantity(DateTime tDate, long ItemID)
        {
            object[] str = new object[] { "select distinct\r\n                        (select coalesce(sum(Quantity),0) as Quantity from trns_production_detail where date_insert>= '01/01/1991' AND date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND item_id = ", ItemID, " AND status = 'I')\r\n                                                     -\r\n                        (select coalesce(sum(Quantity),0) as Quantity from trns_production_detail where date_insert>= '01/01/1991' AND date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND item_id = ", ItemID, " AND status = 'R')\r\n                            as Quantity\r\n                            from trns_production_detail" };
            string str1 = string.Concat(str);
            return Convert.ToDecimal(this.connDB.GetSingleValue(str1));
        }

        public DataTable GetPriceDeclarationNo(int pricedID)
        {
            string str = string.Concat("Select price_id from trns_production_master where production_id=", pricedID);
            return this.connDB.GetDataTable(str);
        }

        public int GetPriceId(int itemId)
        {
            int num;
            try
            {
                string str = string.Concat("select price_id from price_item where item_id = ", itemId, " order by price_id desc limit 1");
                num = Convert.ToInt32(this.connDB.GetSingleValue(str));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return num;
        }

        public DataSet GetProductForPD()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("Select * from item \r\n                        WHERE is_price_declaration = true \r\n                        AND is_deleted = false \r\n                        AND product_type='C' and organization_id=", num, "\r\n                        ORDER BY item_name");
            return this.connDB.GetDataSet(str, "Item");
        }

        public DataSet GetProductForPDByDate(DateTime fDate, DateTime tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] str = new object[] { "Select Distinct i.item_id,i.item_name,i.is_price_declaration from item as i\r\n        inner join trns_production_master as tprd\r\n        on i.item_id = tprd.finish_product_id\r\n\tWHERE i.is_deleted = false AND i.product_type='C' AND tprd.trns_status='I' and i.organization_id=", num, "\r\n\tAND tprd.date_insert >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataSet(str1, "Item");
        }

        public DataTable GetProductionChallanNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.connDB.GetDataTable("select distinct  production_id challan_id, challan_batch_no challan_no \r\n                            from trns_production_master \r\n                            where trns_status = 'I' \r\n                            and is_deleted = false");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetProductionChallanNobyPartyId(int party_id)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable dataTable = new DataTable();
            try
            {
                object[] partyId = new object[] { "select distinct  production_id challan_id, challan_batch_no challan_no \r\n                            from trns_production_master \r\n                            where trns_status = 'I' and party_id=", party_id, " AND organization_id=", num, "\r\n                            and is_deleted = false order by production_id desc" };
                string str = string.Concat(partyId);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetProductionLastinsert()
        {
            return this.connDB.GetDataTable("select production_id,item_id,quantity,unit_id from trns_production_detail order by production_id desc limit 1");
        }

        public DataTable GetProductionLotDetails(short lotNumber, ContructualProductionIssueDAO objCPM, ArrayList arrDetail)
        {
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrDetail[0];
            object[] itemId = new object[] { "select COALESCE(sum(pq.quantity),0) as quantity from production_issue_lot_qnt pq where pq.item_id= ", contructualProductionIssueDAO.Item_id, " and pq.lot_no =", lotNumber, " " };
            string str = string.Concat(itemId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getPropertyQuantity(int propID)
        {
            string str = string.Concat("select quantity from item_property where  property_id= ", propID, " ");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetProvideQuantityForProduct(int fgpID)
        {
            string str = string.Concat("select sum(tprd.Quantity) as Quantity, i.item_name, i.item_id\r\n                            from trns_production_detail as tprd\r\n                            inner join trns_production_master as tprm\r\n                            on tprd.Production_id = tprm.Production_id\r\n                            inner join item as i\r\n                            on tprd.item_id = i.item_id\r\n                            where tprm.finish_product_id = ", fgpID, "\r\n                            group by item_name,i.item_id\r\n                            order by i.item_id ");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetProvideQuantityForProductSingleItem(int fgpID, long partyID)
        {
            object[] objArray = new object[] { "select sum(tprd.Quantity) as Quantity, i.item_name, i.item_id, tprd.unit_id,ic.category_name,iu.unit_code\r\n                            from trns_production_detail as tprd\r\n                            inner join trns_production_master as tprm\r\n                            on tprd.Production_id = tprm.Production_id\r\n                            inner join item as i\r\n                            on tprd.item_id = i.item_id\r\n                            inner join item_category as ic\r\n                            on i.sub_category_id = ic.category_id\r\n                            inner join item_unit as iu\r\n                            on iu.unit_id = i.unit_id\r\n                            where tprd.item_id = ", fgpID, " and tprm.party_id = ", partyID, "\r\n                            group by item_name,i.item_id,tprd.unit_id,ic.category_name,iu.unit_code\r\n                            order by i.item_id" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetProvideQuantityProductIssue(int productionId)
        {
            string str = string.Concat("    select distinct tpm.quantity as production_quantity, pri.row_no,ct.category_name sub_ctg_name,pri.unit_price,\r\n\t\t                    ctp.category_name ctg_name,i.item_id,i.item_name,CAST(pri.quantity as decimal(18,4)) as Quantity,ui.unit_code,ui.unit_id                               \r\n                            from trns_production_detail as pri                          \r\n                            inner join item as i on pri.item_id = i.item_id\r\n                            inner join trns_production_master tpm on tpm.production_id=pri.production_id\r\n                            left join item_unit as ui on ui.unit_id = pri.unit_id\r\n                            left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n\t\t\t                left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n\t\t\t                left join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n\t\t\t                where tpm.production_id=", productionId, " and trns_status='I' order by pri.row_no");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPurchaseinfo(string fDate, string tDate)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            object[] objArray = new object[] { "   select i.item_id,i.item_name,SUM(tpd.quantity) tot_quantity,SUM(tpd.purchase_unit_price*tpd.quantity) tot_price ,SUM(tpd.purchase_VAT) totVAT,tpd.vat_rate\r\n                        from trns_purchase_detail tpd\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        inner join item i on i.item_id = tpd.item_id   \r\n                        where CAST(tpm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(tpm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') \r\n                        and (i.organization_id=", num, " or i.is_for_all_bss_unit=true)\r\n                        and i.product_type IN('R') and tpd.vat_rate =15 group by  i.item_id,i.item_name,tpd.vat_rate" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetPurchaseinfobyItemId(int itemID, string fDate, string tDate)
        {
            object[] objArray = new object[] { "   select i.item_name,SUM(tpd.quantity) tot_quantity,SUM(tpd.purchase_unit_price*tpd.quantity) tot_price ,SUM(tpd.purchase_VAT) totVAT,tpd.vat_rate\r\n                        from trns_purchase_detail tpd\r\n                        inner join trns_purchase_master as tpm on tpd.challan_id = tpm.challan_id\r\n                        inner join item i on i.item_id = tpd.item_id   \r\n                        where CAST(tpm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(tpm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and tpd.vat_rate =15 and tpd.item_id = ", itemID, "  \r\n                        group by i.item_name,tpd.vat_rate" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetQuantityToMadePerProduct(int fgpID, int priceID)
        {
            string str = "";
            if (priceID > 0)
            {
                str = string.Concat(" and pi.price_id = ", priceID);
            }
            object[] objArray = new object[] { "select distinct pi.production_quantity, pri.quantity_total as Quantity, i.item_name,i.item_id,pri.unit_id actualUnit_id,uit.unit_code totqunitcode,ui.unit_code,ui.unit_id,ct.category_name sub_ctg_name,\r\n\t\t                        ctp.category_name ctg_name\r\n                                --,coalesce(pri.txtquantityprice/pri.quantity,0) unit_price_old\r\n                                --,(select tax_value sd_rate from item_tax_values where item_id = tpd.item_id and tax_id = 3 and is_deleted = false)\r\n\t\t                        --,(select tax_value vat_rate from item_tax_values where item_id = tpd.item_id and tax_id = 4 and is_deleted = false)\r\n                                --coalesce(tpd.vat_rate,0) vat_rate,coalesce(tpd.sd_rate,0) sd_rate,\r\n                                ,pri.quantity_total,pri.txtquantityprice\r\n\t\t                        ,(select purchase_unit_price from trns_purchase_detail where item_id = i.item_id order by date_insert desc limit 1) unit_price\r\n                            from price_raw_item as pri\r\n                            inner join price_item as pi on pri.price_id = pi.price_id\r\n                            inner join item as i on pri.item_id = i.item_id\r\n                            left join item_unit as ui on ui.unit_id = pri.unit_id_sec\r\n                            left join item_unit as uit on uit.unit_id = pri.unit_id\r\n                            left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n\t\t\t                left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n\t\t\t                left join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                            where pi.item_id = ", fgpID, " ", str, " and pi.price_declaration_no <> 'No' and pi.is_deleted = false AND pri.set_status!='S' order by i.item_id" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetQuantityToMadePerProductbysaleItemId(int itemID, string fDate, string tDate)
        {
            object[] objArray = new object[] { "select distinct tpd.row_no RowId, pri.quantity_total as Quantity, i.item_name,i.item_id,pri.unit_id actualUnit_id\t\t                                                    \r\n                               ,pri.txtquantityprice,tpd.VAT_rate,tpd.sd_rate\r\n\t\t            ,(select purchase_unit_price from trns_purchase_detail where item_id = i.item_id order by date_insert desc limit 1) unit_price\r\n                            from price_raw_item as pri\r\n                            inner join price_item as pi on pri.price_id = pi.price_id\r\n                            inner join item as i on pri.item_id = i.item_id                                                \r\n\t\t\t                inner join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                            inner join trns_purchase_master tpm on tpd.challan_id = tpm.challan_id and tpd.VAT_rate=15\r\n                            where CAST(tpm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                            AND CAST(tpm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and pi.item_id = ", itemID, " and pi.price_declaration_no <> 'No' and pi.is_deleted = false order by i.item_id" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetQuantityToMadePerProductOwn(int fgpID, int priceID, int price_dec_id)
        {
            string str = "";
            if (priceID > 0)
            {
                str = string.Concat(" and pi.price_id = ", priceID);
            }
            object[] objArray = new object[] { "select distinct pri.quantity_total as Quantity, i.item_name,i.item_id,ui.unit_code,ui.unit_id,ct.category_name sub_ctg_name,\r\n\t\t                        ctp.category_name ctg_name\r\n                                 --,coalesce(pri.txtquantityprice/pri.quantity,0) unit_price_old\r\n                                --,(select tax_value sd_rate from item_tax_values where item_id = tpd.item_id and tax_id = 3 and is_deleted = false)\r\n\t\t                        --,(select tax_value vat_rate from item_tax_values where item_id = tpd.item_id and tax_id = 4 and is_deleted = false)\r\n                                --coalesce(tpd.vat_rate,0) vat_rate,coalesce(tpd.sd_rate,0) sd_rate,\r\n                                ,pri.quantity_total,pri.txtquantityprice\r\n\t\t                        ,(select purchase_unit_price from trns_purchase_detail where item_id = i.item_id order by date_insert desc limit 1) unit_price\r\n                            from price_raw_item as pri\r\n                            inner join price_item as pi on pri.price_id = pi.price_id\r\n                            inner join item as i on pri.item_id = i.item_id\r\n                            left join item_unit as ui on ui.unit_id = pri.unit_id_sec\r\n                            left join ITEM_category ct on ct.category_id = i.sub_category_id\r\n\t\t\t                left join ITEM_category ctp on ctp.category_id = ct.parent_id\r\n\t\t\t                left join trns_purchase_detail as tpd on tpd.item_id = i.item_id\r\n                            where pi.item_id = ", fgpID, " ", str, " and pi.price_id =", price_dec_id, " and pi.is_deleted = false order by i.item_id" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetRcvChallan()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.connDB.GetDataTable("select distinct  production_id challan_id, challan_batch_no challan_no \r\n                            from trns_production_master \r\n                            where trns_status = 'R'  and is_deleted = false order by production_id desc");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetReceiveBatchNo()
        {
            DataTable dataTable;
            try
            {
                dataTable = this.connDB.GetDataTable("select production_id,batch_no from trns_production_master where trns_status='R' and batch_no!='' ");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable GetReceivedProductQuantity(int pricedID)
        {
            string str = string.Concat("select coalesce( sum(quantity),0) quantity from trns_production_master where p_c_id in (select production_id from trns_production_master where price_id=", pricedID, ")");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetReceiveFinishByPartyandChallan(DateTime fDate, DateTime tDate, int partyId, int challanId, string batchNo, int batch)
        {
            string str = "";
            if (partyId != -99)
            {
                str = string.Concat(str, " and tpm.party_id=", partyId);
            }
            if (challanId != -99)
            {
                str = string.Concat(str, " and tpm.production_id=", challanId);
            }
            if (batch != -99)
            {
                str = string.Concat(str, " and tpm.batch_no='", batchNo, "'");
            }
            string[] strArrays = new string[] { "select distinct tpm.challan_batch_no, to_char(tpm.date_production,'dd-Mon-yyyy') as challan_date,to_char(tpm.date_production::Time, 'HH:MI AM') issuetime, i.item_name,\r\n                            iu.unit_code,tpm.Quantity ,tp.party_name,party_bin,party_address                          \r\n                            from trns_production_master as tpm\r\n                            inner join trns_production_detail as tpd on tpm.production_id = tpd.production_id\r\n                            inner join item as i on i.item_id = tpm.finish_product_id\r\n                            inner join item_unit as iu on iu.unit_id = tpm.production_unit \r\n                            inner join trns_party tp on tp.party_id = tpm.party_id\r\n                            where tpm.trns_status='R' and  CAST(tpm.date_production AS DATE) >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                            AND CAST(tpm.date_production AS DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') ", str, " " };
            string str1 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetReceiveIngredienceByPartyandChallan(DateTime fDate, DateTime tDate, int partyId, int challanId, string batchNo, int batch)
        {
            string str = "";
            if (partyId != -99)
            {
                str = string.Concat(str, " and tpm.party_id=", partyId);
            }
            if (challanId != -99)
            {
                str = string.Concat(str, " and tpm.production_id=", challanId);
            }
            if (batch != -99)
            {
                str = string.Concat(str, " and tpm.batch_no='", batchNo, "'");
            }
            string[] strArrays = new string[] { "select tpm.challan_batch_no, to_char(tpm.date_production,'dd-Mon-yyyy') as challan_date, i.item_name,\r\n                            iu.unit_code,tpd.Quantity ,tpm.remarks remark                         \r\n                            from trns_production_master as tpm\r\n                            inner join trns_production_detail as tpd on tpm.production_id = tpd.production_id\r\n                            inner join item as i on i.item_id = tpd.item_id\r\n                            inner join item_unit as iu on iu.unit_id = tpd.unit_id \r\n                            where tpm.trns_status='R' and CAST(tpm.date_production AS DATE) >= TO_DATE('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                            AND CAST(tpm.date_production AS DATE) <= TO_DATE('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') ", str, " " };
            string str1 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetReceiveProductionChallanNobyPartyId(int party_id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select distinct  production_id challan_id, challan_batch_no challan_no \r\n                            from trns_production_master \r\n                            where trns_status = 'R' and party_id=", party_id, " \r\n                            and is_deleted = false order by production_id desc");
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        private ArrayList getRMDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int productionID)
        {
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
                RawMaterialIssueForSelfProductionDAO rawMaterialIssueForSelfProductionDAO = new RawMaterialIssueForSelfProductionDAO();
                rawMaterialIssueForSelfProductionDAO = (RawMaterialIssueForSelfProductionDAO)arrDeailDAO[i];
                if (rawMaterialIssueForSelfProductionDAO.PropertyID1 != 0)
                {
                    str = rawMaterialIssueForSelfProductionDAO.PropertyID1.ToString();
                }
                if (rawMaterialIssueForSelfProductionDAO.PropertyID2 != 0)
                {
                    str1 = rawMaterialIssueForSelfProductionDAO.PropertyID2.ToString();
                }
                if (rawMaterialIssueForSelfProductionDAO.PropertyID3 != 0)
                {
                    str2 = rawMaterialIssueForSelfProductionDAO.PropertyID3.ToString();
                }
                if (rawMaterialIssueForSelfProductionDAO.PropertyID4 != 0)
                {
                    str3 = rawMaterialIssueForSelfProductionDAO.PropertyID4.ToString();
                }
                if (rawMaterialIssueForSelfProductionDAO.PropertyID5 != 0)
                {
                    str4 = rawMaterialIssueForSelfProductionDAO.PropertyID5.ToString();
                }
                object[] objArray = new object[] { " INSERT INTO trns_production_detail (Production_id, row_no, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, unit_id, Quantity, user_id_insert,status)\r\n                                VALUES (", productionID, ", ", rawMaterialIssueForSelfProductionDAO.RowNO, ", ", rawMaterialIssueForSelfProductionDAO.ItemID, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", rawMaterialIssueForSelfProductionDAO.UnitID, ", ", rawMaterialIssueForSelfProductionDAO.Quantity, ", ", rawMaterialIssueForSelfProductionDAO.UserID, ",'", rawMaterialIssueForSelfProductionDAO.Status, "')" };
                arrDetailList.Add(string.Concat(objArray));
            }
            return arrDetailList;
        }

        public DataTable getRowMaterialsByFID(int FID)
        {
            string str = string.Concat("select distinct i.item_id,i.product_type, CASE coalesce(i.item_specification, 'null') \r\n                               WHEN 'null' THEN i.item_name \r\n                               WHEN '' THEN i.item_name ||'-'|| i.hs_code \r\n                               ELSE (i.item_name ||'-'||i.item_specification ||'-'|| i.hs_code) END item_name\r\n                        from item as i\r\n                        inner join trns_production_detail as tpd\r\n                        on i.item_id = tpd.item_id\r\n                        inner join trns_production_master as tpm\r\n                        on tpd.Production_id = tpm.Production_id\r\n                        where tpm.finish_product_id = ", FID, " and tpm.trns_status = 'I'\r\n                        order by item_id");
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetSaleFinishProductWithout15VAT(int itemId, int saletype, string fDate, string tDate)
        {
            string str = "";
            if (saletype == 1)
            {
                str = "and  tsd.is_zero_rate=true AND tsm.trans_type = 'E' AND tsd.is_deleted = false AND tsd.is_inexplicit_export = false";
            }
            if (saletype == 3)
            {
                str = "and tsd.is_inexplicit_export=true AND tsm.trans_type= 'E' AND tsd.is_deleted = false ";
            }
            if (saletype == 5)
            {
                str = "AND tsd.is_deleted = false  and tsd.is_exempted=false AND tsd.is_mrp=true AND tsd.is_mrp=true";
            }
            if (saletype == 6)
            {
                str = " AND tsd.is_deleted = false  AND tsd.is_fixed_vat=true";
            }
            if (saletype == 7)
            {
                str = " AND tsm.sale_type = 'S' AND tsd.is_truncated = true AND tsd.is_exempted = false and tsd.is_fixed_vat = false";
            }
            if (saletype == 8)
            {
                str = " AND tsd.is_deleted = false AND tsm.sale_type in ('W','R','T','P') AND tsd.vat_rate!=15";
            }
            object[] objArray = new object[] { " select i.item_id,i.item_name,sum(tsd.quantity) tot_quantity,sum(tsd.actual_price*tsd.quantity) tot_price ,sum(tsd.VAT) totVAT,tsd.vat_rate\r\n                        from trns_sale_detail tsd\r\n                        inner join trns_sale_master as tsm on tsd.challan_id = tsm.challan_id\r\n                        inner join item i on i.item_id = tsd.item_id  \r\n                        where CAST(tsm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(tsm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and tsd.vat_rate !=15 and tsd.item_id = ", itemId, " ", str, " group by i.item_id,i.item_name,tsd.vat_rate" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable GetSaleFinishProductWithout15VATbyChallan(int itemId, int saletype, string fDate, string tDate)
        {
            string str = "";
            string str1 = "";
            if (itemId != -99)
            {
                str1 = string.Concat("and tsd.item_id = ", itemId);
            }
            if (saletype == 1)
            {
                str = "and  tsd.is_zero_rate=true AND tsm.trans_type = 'E' AND tsd.is_deleted = false AND tsd.is_inexplicit_export = false";
            }
            if (saletype == 3)
            {
                str = "and tsd.is_inexplicit_export=true AND tsm.trans_type= 'E' AND tsd.is_deleted = false ";
            }
            if (saletype == 5)
            {
                str = "AND tsd.is_deleted = false  and tsd.is_exempted=false AND tsd.is_mrp=true AND tsd.is_mrp=true";
            }
            if (saletype == 6)
            {
                str = " AND tsd.is_deleted = false  AND tsd.is_fixed_vat=true";
            }
            if (saletype == 7)
            {
                str = " AND tsm.sale_type = 'S' AND tsd.is_truncated = true AND tsd.is_exempted = false and tsd.is_fixed_vat = false";
            }
            if (saletype == 8)
            {
                str = " AND tsd.is_deleted = false AND tsm.sale_type in ('W','R','T','P') AND tsd.vat_rate!=15";
            }
            string[] strArrays = new string[] { "select tsd.row_no RowId,i.item_id,i.item_name,tsd.quantity,tsd.actual_price unit_price,tsd.actual_price*tsd.quantity price ,(tsd.actual_price*tsd.quantity)+tsd.sd+tsd.vat grossTotal,\r\n                         tsd.VAT ,tsd.vat_rate, tsd.SD ,tsd.sd_rate,tsm.challan_id,tsm.challan_no,to_char(tsm.date_challan,'dd/MM/yyyy') challan_date,tsm.rebate_adjust_amount,to_char(tsm.rebate_adjust_date,'dd/MM/yyyy') rebate_adjust_date\r\n                        from trns_sale_detail tsd\r\n                        inner join trns_sale_master as tsm on tsd.challan_id = tsm.challan_id\r\n                        inner join item i on i.item_id = tsd.item_id \r\n                        where CAST(tsm.date_challan as DATE) >= to_date('", fDate, "','dd/MM/yyyy') \r\n                        AND CAST(tsm.date_challan as DATE) <= to_date('", tDate, "','dd/MM/yyyy') and tsd.vat_rate !=15 ", str1, " ", str, " " };
            string str2 = string.Concat(strArrays);
            return this.connDB.GetDataTable(str2);
        }

        public DataTable GetUnitFromFinishProduct(int itemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select  iu.unit_code\r\n                            from item  i\r\n                            inner join item_unit as iu on iu.unit_id = i.unit_id\r\n                            where i.item_id = ", itemID);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetUnitPriceFromPD(int itemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select distinct  prpsd_actl_prc,production_quantity\r\n                            from price_item \r\n                            where item_id = ", itemID, " and price_id=(select max(price_id) from price_item where item_id=", itemID, " and price_declaration_no<>'No') and prpsd_actl_prc!=0" };
                string str = string.Concat(objArray);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetUsedInPdQuantity(DateTime fDate, DateTime tDate, long ItemID, long productionId)
        {
            object[] str = new object[] { "select tprm.challan_batch_no, to_char(tprm.date_production,'dd-MM-yyyy') as date_production,i.item_name,iu.unit_code,CAST(tprd.Quantity as decimal) as used_quantity,\r\n                        tprm.quantity as finish_quantity, (select ui.unit_name from item i \r\n                        inner join item_unit ui on i.unit_id=ui.unit_id\r\n                        where i.item_id=tprm.finish_product_id) as finish_unit,\r\n                        case when trns_status='I' then 'Issued'\r\n                        when trns_status='R' then 'Received' end Status,\r\n                        \r\n                                (\r\n\t\t                        select  SUM(coalesce(d.Quantity,0))\r\n\t\t                        from trns_production_master m\r\n\t\t                        inner join trns_production_detail d on m.production_id = d.production_id \r\n\t\t                        where date_production >= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n\t\t                        AND date_production <= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')\r\n\t\t                        and m.p_c_id = tprm.p_c_id and d.item_id = ", ItemID, "\r\n\t\t                        ) product_quantity   \r\n                        from trns_production_master as tprm\r\n                        inner join trns_production_detail as tprd\r\n                        on tprm.Production_id = tprd.Production_id\r\n                        inner join item as i\r\n                        on i.item_id = tprd.item_id\r\n                        inner join item_unit as iu\r\n                        on tprd.unit_id = iu.unit_id\r\n                        where tprd.date_insert>= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.item_id = ", ItemID, " AND status = 'R' AND tprm.p_c_id=", productionId, " \r\n                        order by tprm.date_production" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getUsedPdQuantityByFPP(DateTime fDate, DateTime tDate, long ItemID, long finishProductId)
        {
            string str = "";
            if (ItemID > (long)0)
            {
                str = string.Concat("AND tprd.item_id =", ItemID, " ");
            }
            object[] objArray = new object[] { "select  i.item_id,i.item_name,iu.unit_code,SUM(tprd.Quantity) as used_qnt,tprm.finish_product_id, (select ui.unit_name from item i \r\n                        inner join item_unit ui on i.unit_id=ui.unit_id\r\n                        where i.item_id=tprm.finish_product_id) as finish_unit,\r\n                        Sum(tprm.quantity) as finish_quantity \r\n                       from trns_production_master as tprm\r\n                        inner join trns_production_detail as tprd\r\n                        on tprm.Production_id = tprd.Production_id\r\n                        inner join item as i\r\n                        on i.item_id = tprd.item_id\r\n                        inner join item_unit as iu\r\n                        on tprd.unit_id = iu.unit_id\r\n                        where tprd.date_insert>= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        ", str, " AND tprm.finish_product_id=", finishProductId, " AND status = 'R'\r\n                        group by  i.item_id,i.item_name,iu.unit_code,tprm.finish_product_id\r\n                        order by i.item_id" };
            string str1 = string.Concat(objArray);
            return this.connDB.GetDataTable(str1);
        }

        public DataTable getUsedQuantity(string fDate, string tDate, long ItemID)
        {
            object[] objArray = new object[] { "select distinct Quantity as used_quantity,\r\n                    (select Quantity from trns_purchase_detail where date_insert>= '", fDate, "' AND date_insert<= '", tDate, "' AND s_p_return=3) as product_quantity\r\n                    from trns_production_detail where date_insert>= '", fDate, "' AND date_insert<= '", tDate, "' AND item_id = ", ItemID, " AND status = 'R'" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public DataTable GetUsedQuantity(DateTime fDate, DateTime tDate, long ItemID)
        {
            object[] str = new object[] { "select tprm.challan_batch_no, to_char(tprm.date_production,'dd-MM-yyyy') as date_production,tprm.date_insert,i.item_name,iu.unit_code,tprd.Quantity as used_quantity,\r\n                        case when trns_status='I' then 'Issued'\r\n                        when trns_status='R' then 'Received' end Status                         \r\n                        from trns_production_master as tprm\r\n                        inner join trns_production_detail as tprd\r\n                        on tprm.Production_id = tprd.Production_id\r\n                        inner join item as i\r\n                        on i.item_id = tprd.item_id\r\n                        inner join item_unit as iu\r\n                        on tprd.unit_id = iu.unit_id\r\n                        where tprd.date_insert>= to_date('", fDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.date_insert<= to_date('", tDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') \r\n                        AND tprd.item_id = ", ItemID, " AND status = 'R' \r\n                        order by tprm.date_insert \r\n\t\t\t            -- tprm.date_production" };
            string str1 = string.Concat(str);
            return this.connDB.GetDataTable(str1);
        }

        public double getVatSdPrice(long ItemID)
        {
            string str = string.Concat("select wholesale_prc_sd_vat from price_item where item_id = ", ItemID, " and is_deleted = false order by price_id desc limit 1;");
            return Convert.ToDouble(this.connDB.GetSingleValue(str));
        }

        private ArrayList getwastemanagementDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int wastemngID)
        {
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                WastemanagementDAO wastemanagementDAO = new WastemanagementDAO();
                wastemanagementDAO = (WastemanagementDAO)arrDeailDAO[i];
                wastemanagementDAO.WasteMngdetailId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('waste_mng_detail_id_seq')"));
                object[] wasteMngdetailId = new object[] { " INSERT INTO trns_waste_management_detail (waste_mng_detail_id, waste_mng_id, Item_id, issued_quantity, issued_unit, issued_for_quantity,\r\nissued_for_unit, finished_quantity, received_quantity, batch_no_wise_waste_qty, price,remarks,reason,challan_ref_no,challan_date,purchase_quantity,challan_price,  vat,expired_date)\r\n                                VALUES (", wastemanagementDAO.WasteMngdetailId, ", ", wastemngID, ", ", wastemanagementDAO.Item_id, ", ", wastemanagementDAO.PreQuantity, ", ", wastemanagementDAO.UsedqUnit, ", ", wastemanagementDAO.Quantity, ", ", wastemanagementDAO.Unit, ", ", wastemanagementDAO.FinishpQuantity, ", ", wastemanagementDAO.ReceivedQuantiy, ", ", wastemanagementDAO.WasteQuantity, ", ", wastemanagementDAO.Price, ", '", wastemanagementDAO.Remark, "','", wastemanagementDAO.Reason, "','", wastemanagementDAO.ChallanId, "',\r\n                                        to_timestamp('", null, null, null, null, null, null, null, null, null, null };
                wasteMngdetailId[29] = wastemanagementDAO.ChallanDate.ToString("MM/dd/yyyy HH:mm");
                wasteMngdetailId[30] = "', 'MM/dd/yyyy HH24:MI'),'";
                wasteMngdetailId[31] = wastemanagementDAO.Purchasequantity;
                wasteMngdetailId[32] = "','";
                wasteMngdetailId[33] = wastemanagementDAO.Purchaseprice;
                wasteMngdetailId[34] = "',  '";
                wasteMngdetailId[35] = wastemanagementDAO.Vat;
                wasteMngdetailId[36] = "',to_timestamp('";
                wasteMngdetailId[37] = wastemanagementDAO.ExpireDate.ToString("MM/dd/yyyy HH:mm");
                wasteMngdetailId[38] = "', 'MM/dd/yyyy HH24:MI'))";
                arrDetailList.Add(string.Concat(wasteMngdetailId));
            }
            return arrDetailList;
        }

        public long GetWastPercentage(long ItemID)
        {
            long num = (long)0;
            string str = string.Concat("select distinct wastageparcent from price_raw_item where item_id = ", ItemID);
            return Convert.ToInt64(this.connDB.GetSingleValue(str));
        }

        public bool insertCPIssueData(ContructualProductionIssueMasterDAO objCPM, ArrayList arrDetail, ArrayList arrDetailchk)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                short discardReason = objCPM.Discard_reason;
                if (objCPM.IsNewParty)
                {
                    objCPM.Party_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('party_id_seq')"));
                    object[] partyId = new object[] { "INSERT INTO trns_party (party_id, party_name, party_address, user_id_insert, party_bin)\r\n                                VALUES (", objCPM.Party_id, ", upper('", objCPM.PartyName, "'), '", objCPM.PartyAddress, "', ", objCPM.User_id_insert, ", '", objCPM.PartyBIN, "')" };
                    arrayLists.Add(string.Concat(partyId));
                }
                objCPM.Production_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('production_id_seq')"));
                object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,org_branch_reg_id, organization_id, challan_batch_no, cg_challan_batch_no, \r\n                                            production_year, material_type, date_production, user_id_insert,Remarks, trns_status,finish_product_id, party_id,quantity,price_id,batch_no,mfg_date,expiry_date)\r\n                                VALUES (", objCPM.Production_id, ",", objCPM.BranchID, ",\r\n                                        ", objCPM.Organization_id, ", '", objCPM.Challan_batch_no, "', \r\n                                        (select coalesce (max (cg_challan_batch_no),0)+1 \r\n                                                    from trns_production_master where trns_status IN ('I','R','D','S','E') \r\n                                                    and production_year ='", objCPM.Production_year, "'), ", objCPM.Production_year, ", '", objCPM.Material_type, "', \r\n                                        to_timestamp('", objCPM.Date_production.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", objCPM.User_id_insert, ",'", objCPM.Remarks, "', '", objCPM.Status, "',", objCPM.FinishProductID, ",", objCPM.Party_id, ",", objCPM.Quantity, ",", objCPM.price_id, ",'", objCPM.Batch_no, "',to_timestamp('", objCPM.MfgDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),to_timestamp('", objCPM.ExpiryDate.ToString("dd/MM/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(productionId));
                if (objCPM.Discard_reason != 0)
                {
                    object[] objArray = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objCPM.Discard_reason, "' where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                    arrayLists.Add(string.Concat(objArray));
                }
                else
                {
                    object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                    arrayLists.Add(string.Concat(challanBookId));
                }
                arrayLists = this.getCPDetails(arrayLists, arrDetail, objCPM.Production_id, arrDetailchk);
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                bool flag1 = Utility.InsertErrorTrackNew(exception.Message, "ContractualProductionBLL", "insertCPIssueData", fileLineNumber);
                flag = flag1;
            }
            return flag;
        }

        public bool insertCPIssueDataOwnProdction(ContructualProductionIssueMasterDAO objCPM, ArrayList arrDetail)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                short discardReason = objCPM.Discard_reason;
                if (objCPM.IsNewParty)
                {
                    objCPM.Party_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('party_id_seq')"));
                    object[] partyId = new object[] { "INSERT INTO trns_party (party_id, party_name, party_address, user_id_insert, party_bin)\r\n                                VALUES (", objCPM.Party_id, ", upper('", objCPM.PartyName, "'), '", objCPM.PartyAddress, "', ", objCPM.User_id_insert, ", '", objCPM.PartyBIN, "')" };
                    arrayLists.Add(string.Concat(partyId));
                }
                objCPM.Production_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('production_id_seq')"));
                object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,org_branch_reg_id, organization_id, challan_batch_no, cg_challan_batch_no, \r\n                                            production_year, material_type, date_production, user_id_insert,Remarks, trns_status,finish_product_id, party_id,quantity,price_id,batch_no,mfg_date,expiry_date)\r\n                                VALUES (", objCPM.Production_id, ",", objCPM.BranchID, ",\r\n                                        ", objCPM.Organization_id, ", '", objCPM.Challan_batch_no, "', \r\n                                        (select coalesce (max (cg_challan_batch_no),0)+1 \r\n                                                    from trns_production_master where trns_status IN ('I','R','D','S','E') \r\n                                                    and production_year ='", objCPM.Production_year, "'), ", objCPM.Production_year, ", '", objCPM.Material_type, "', \r\n                                        to_timestamp('", objCPM.Date_production.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", objCPM.User_id_insert, ",'", objCPM.Remarks, "', '", objCPM.Status, "',", objCPM.FinishProductID, ",", objCPM.Party_id, ",", objCPM.Quantity, ",", objCPM.price_id, ",'", objCPM.Batch_no, "',to_timestamp('", objCPM.MfgDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),to_timestamp('", objCPM.ExpiryDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'))" };
                arrayLists.Add(string.Concat(productionId));
                if (objCPM.Discard_reason != 0)
                {
                    object[] objArray = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objCPM.Discard_reason, "' where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                    arrayLists.Add(string.Concat(objArray));
                }
                else
                {
                    object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                    arrayLists.Add(string.Concat(challanBookId));
                }
                arrayLists = this.getCPDetails(arrayLists, arrDetail, objCPM.Production_id);
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public bool insertCPReceiveData(ContructualProductionIssueMasterDAO objCPM, ArrayList arrDetail, ArrayList arrDetailPurchase, decimal quantity)
        {
            ArrayList arrayLists = new ArrayList();
            short discardReason = objCPM.Discard_reason;
            if (objCPM.IsNewParty)
            {
                objCPM.Party_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('party_id_seq')"));
                object[] partyId = new object[] { "INSERT INTO trns_party (party_id, party_name, party_address, user_id_insert, party_bin)\r\n                                VALUES (", objCPM.Party_id, ", upper('", objCPM.PartyName, "'), '", objCPM.PartyAddress, "', ", objCPM.User_id_insert, ", '", objCPM.PartyBIN, "')" };
                arrayLists.Add(string.Concat(partyId));
            }
            objCPM.Production_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('production_id_seq')"));
            object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,org_branch_reg_id, organization_id, challan_batch_no, cg_challan_batch_no, \r\n                                production_year, material_type, date_production, user_id_insert,Remarks, trns_status, discard_reason, \r\n                                scroll_no,finish_product_id, party_id,p_c_id,quantity,batch_no,production_unit,production_quantity,unit_price,mfg_date,expiry_date)\r\n                                VALUES (", objCPM.Production_id, ",", objCPM.BranchID, ",", objCPM.Organization_id, ", '", objCPM.Challan_batch_no, "', \r\n        (select coalesce (max (cg_challan_batch_no),0)+1 from trns_production_master where trns_status IN ('I','R','D') and production_year ='", objCPM.Production_year, "'), ", objCPM.Production_year, ", '", objCPM.Material_type, "', \r\n                                          to_timestamp('", objCPM.Date_production.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", objCPM.User_id_insert, ", '", objCPM.Remarks, "','", objCPM.Status, "',", objCPM.Discard_reason, ",'", objCPM.ScrollNo, "',", objCPM.FinishProductID, ",", objCPM.Party_id, ",", objCPM.PorvidedChallanNo, ",", quantity, ",'", objCPM.Batch_no, "',", objCPM.Production_Unit, ",", objCPM.Production_Quantity, ",", objCPM.Production_Sale_Unit_Price, ",to_timestamp('", objCPM.MfgDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),to_timestamp('", objCPM.ExpiryDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'))" };
            arrayLists.Add(string.Concat(productionId));
            objCPM.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
            object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id,\r\n                            Organization_id, challan_type, purchase_type, date_challan, party_id,user_id_insert,challan_no,Remarks)\r\n             VALUES ( ", objCPM.ChallanID, ",", objCPM.BranchID, ", ", objCPM.Organization_id, ", '", objCPM.Material_type, "', '", objCPM.PurchaseType, "', \r\n                    to_timestamp('", null, null, null, null, null, null, null, null, null, null };
            challanID[11] = objCPM.Date_production.ToString("MM/dd/yyyy HH:mm");
            challanID[12] = "','MM/dd/yyyy HH24:MI'),";
            challanID[13] = objCPM.Party_id;
            challanID[14] = ",";
            challanID[15] = objCPM.User_id_insert;
            challanID[16] = ",'";
            challanID[17] = objCPM.Challan_batch_no;
            challanID[18] = "','";
            challanID[19] = objCPM.Remarks;
            challanID[20] = "' )";
            arrayLists.Add(string.Concat(challanID));
            if (objCPM.Discard_reason != 0)
            {
                object[] objArray = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objCPM.Discard_reason, "' where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                arrayLists.Add(string.Concat(objArray));
            }
            else
            {
                object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                arrayLists.Add(string.Concat(challanBookId));
            }
            arrayLists = this.getCPReceiveDetails(arrayLists, arrDetail, objCPM.Production_id);
            arrayLists = this.AddMainDeailInsertPurchaseTable(arrayLists, arrDetailPurchase, objCPM.ChallanID);
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool insertCPReceiveDataExceel(ContructualProductionIssueMasterDAO objCPM, ArrayList arrDetail, ArrayList arrDetailPurchase, decimal quantity, ArrayList arrexcel)
        {
            ArrayList arrayLists = new ArrayList();
            short discardReason = objCPM.Discard_reason;
            if (objCPM.IsNewParty)
            {
                objCPM.Party_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('party_id_seq')"));
                object[] partyId = new object[] { "INSERT INTO trns_party (party_id, party_name, party_address, user_id_insert, party_bin)\r\n                                VALUES (", objCPM.Party_id, ", upper('", objCPM.PartyName, "'), '", objCPM.PartyAddress, "', ", objCPM.User_id_insert, ", '", objCPM.PartyBIN, "')" };
                arrayLists.Add(string.Concat(partyId));
            }
            objCPM.Production_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('production_id_seq')"));
            object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,org_branch_reg_id, organization_id, challan_batch_no, cg_challan_batch_no, \r\n                                production_year, material_type, date_production, user_id_insert,Remarks, trns_status, discard_reason, \r\n                                scroll_no,finish_product_id, party_id,p_c_id,quantity,batch_no,production_unit,production_quantity,unit_price,mfg_date,expiry_date)\r\n                                VALUES (", objCPM.Production_id, ",", objCPM.BranchID, ",", objCPM.Organization_id, ", '", objCPM.Challan_batch_no, "', \r\n        (select coalesce (max (cg_challan_batch_no),0)+1 from trns_production_master where trns_status IN ('I','R','D') and production_year ='", objCPM.Production_year, "'), ", objCPM.Production_year, ", '", objCPM.Material_type, "', \r\n                                          to_timestamp('", objCPM.Date_production.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", objCPM.User_id_insert, ", '", objCPM.Remarks, "','", objCPM.Status, "',", objCPM.Discard_reason, ",'", objCPM.ScrollNo, "',", objCPM.FinishProductID, ",", objCPM.Party_id, ",", objCPM.PorvidedChallanNo, ",", quantity, ",'", objCPM.Batch_no, "',", objCPM.Production_Unit, ",", objCPM.Production_Quantity, ",", objCPM.Production_Sale_Unit_Price, ",to_timestamp('", objCPM.MfgDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'),to_timestamp('", objCPM.ExpiryDate.ToString("dd/MM/yyyy HH:mm"), "','dd/MM/yyyy HH24:MI'))" };
            arrayLists.Add(string.Concat(productionId));
            objCPM.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
            object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id,\r\n                            Organization_id, challan_type, purchase_type, date_challan, party_id,user_id_insert,challan_no,Remarks)\r\n             VALUES ( ", objCPM.ChallanID, ",", objCPM.BranchID, ", ", objCPM.Organization_id, ", '", objCPM.Material_type, "', '", objCPM.PurchaseType, "', \r\n                    to_timestamp('", null, null, null, null, null, null, null, null, null, null };
            challanID[11] = objCPM.Date_production.ToString("MM/dd/yyyy HH:mm");
            challanID[12] = "','MM/dd/yyyy HH24:MI'),";
            challanID[13] = objCPM.Party_id;
            challanID[14] = ",";
            challanID[15] = objCPM.User_id_insert;
            challanID[16] = ",'";
            challanID[17] = objCPM.Challan_batch_no;
            challanID[18] = "','";
            challanID[19] = objCPM.Remarks;
            challanID[20] = "' )";
            arrayLists.Add(string.Concat(challanID));
            if (objCPM.Discard_reason != 0)
            {
                object[] objArray = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, Remarks = '", objCPM.Discard_reason, "' where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                arrayLists.Add(string.Concat(objArray));
            }
            else
            {
                object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objCPM.ChallanBookId, " and page_no = ", objCPM.ChallanPageNo };
                arrayLists.Add(string.Concat(challanBookId));
            }
            arrayLists = this.getCPReceiveDetails(arrayLists, arrDetail, objCPM.Production_id);
            arrayLists = this.AddMainDeailInsertPurchaseTable(arrayLists, arrDetailPurchase, objCPM.ChallanID);
            arrayLists = this.AddMainDeailInsertAdditionalInfo(arrayLists, arrexcel, objCPM.Production_id, objCPM.Date_production);
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool insertFPReceiveData(FinishProductReceiveMasterFromSelfProductionDAO objCPM, ArrayList arrDetail, ArrayList arrDetailPurchase)
        {
            ArrayList arrayLists = new ArrayList();
            objCPM.Production_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('production_id_seq')"));
            object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,org_branch_reg_id, organization_id, challan_batch_no, cg_challan_batch_no, production_year, material_type, date_production, user_id_insert, trns_status, scroll_no,finish_product_id, party_id)\r\n                                VALUES (", objCPM.Production_id, ",", objCPM.BranchID, ",", objCPM.OrganizationID, ", '", objCPM.ChallanNO, "', \r\n        (select coalesce (max (cg_challan_batch_no),0)+1 from trns_production_master where trns_status IN ('I','R','D','S','E','C') and production_year ='", objCPM.ProductionYear, "'), ", objCPM.ProductionYear, ", '", objCPM.MaterialType, "', \r\n                                          to_timestamp('", objCPM.DateProduction.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), ", objCPM.User_id_insert, ",'", objCPM.Status, "','", objCPM.ScrollNO, "',", objCPM.FinishProductID, ",", objCPM.BranchID, ")" };
            arrayLists.Add(string.Concat(productionId));
            objCPM.ChallanID = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
            object[] challanID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,org_branch_reg_id,\r\n                            Organization_id, challan_type, purchase_type, date_challan, party_id,user_id_insert,challan_no)\r\n             VALUES ( ", objCPM.ChallanID, ",", objCPM.BranchID, ", ", objCPM.OrganizationID, ", '", objCPM.MaterialType, "', '", objCPM.PurchaseType, "', \r\n                    to_timestamp('", null, null, null, null, null, null, null, null };
            challanID[11] = objCPM.DateProduction.ToString("MM/dd/yyyy HH:mm");
            challanID[12] = "','MM/dd/yyyy HH24:MI'),";
            challanID[13] = objCPM.BranchID;
            challanID[14] = ",";
            challanID[15] = objCPM.User_id_insert;
            challanID[16] = ",'";
            challanID[17] = objCPM.ChallanNO;
            challanID[18] = "' )";
            arrayLists.Add(string.Concat(challanID));
            arrayLists = this.getFPReceiveDetails(arrayLists, arrDetail, objCPM.Production_id);
            arrayLists = this.getMainDeailInsertPurchaseTable(arrayLists, arrDetailPurchase, objCPM.ChallanID);
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool insertProductionLotQnt(ContructualProductionIssueDAO objPLQDao)
        {
            objPLQDao.Production_issue_lot_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('production_issue_lot_id_seq')"));
            object[] productionIssueLotId = new object[] { "INSERT INTO production_issue_lot_qnt (production_issue_lot_id,production_id,lot_no,quantity,item_id) \r\n                             Values(", objPLQDao.Production_issue_lot_id, ",", objPLQDao.Production_id, ",", objPLQDao.Lot_no, ",", objPLQDao.Quantity, ",", objPLQDao.Item_id, ")" };
            string str = string.Concat(productionIssueLotId);
            return this.connDB.ExecuteDML(str);
        }

        public bool insertRMIssueData(RawMaterialIssueMasterForSelfProductionDAO objCPM, ArrayList arrDetail)
        {
            ArrayList arrayLists = new ArrayList();
            objCPM.Production_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('production_id_seq')"));
            object[] productionId = new object[] { "INSERT INTO trns_production_master (Production_id,org_branch_reg_id, organization_id, challan_batch_no, cg_challan_batch_no, production_year, material_type, date_production, user_id_insert, trns_status,finish_product_id, party_id,Remarks)\r\n                                VALUES (", objCPM.Production_id, ",", objCPM.BranchID, ",", objCPM.OrganizationID, ", '", objCPM.RequisitionNO, "', \r\n        (select coalesce (max (cg_challan_batch_no),0)+1 from trns_production_master where trns_status IN ('I','R','D','S','E') and production_year ='", objCPM.ProductionYear, "'), \r\n        ", objCPM.ProductionYear, ", '", objCPM.MaterialType, "', to_timestamp('", objCPM.DateProduction.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'), @", objCPM.User_id_insert, ",'", objCPM.Status, "',", objCPM.FinishProductID, ",", objCPM.BranchID, ",'", objCPM.RequisitorName, "')" };
            arrayLists.Add(string.Concat(productionId));
            arrayLists = this.getRMDetails(arrayLists, arrDetail, objCPM.Production_id);
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public bool insertWastemanagementInfo(WastemanagementMasterDAO objCPM, ArrayList arrDetail)
        {
            ArrayList arrayLists = new ArrayList();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            objCPM.WastemngId = Convert.ToInt32(this.connDB.GetSingleValue("SELECT nextval('waste_mng_id_seq')"));
            object[] wastemngId = new object[] { "INSERT into trns_waste_management_master  (waste_mng_id,challan_id,challan_date,transaction_type,\r\n                             finished_porduct_id,batch_no,factory_id,organization_id) values (", objCPM.WastemngId, ",'", objCPM.Challan_no, "'\r\n                             ,  to_timestamp('", objCPM.Challan_date.ToString("MM/dd/yyyy HH:mm"), "', 'MM/dd/yyyy HH24:MI'),", objCPM.Transactiontyp, ",", objCPM.Finished_porductId, ",'", objCPM.Batch_no, "',", objCPM.Factory_id, ",", num, ")" };
            arrayLists.Add(string.Concat(wastemngId));
            arrayLists = this.getwastemanagementDetails(arrayLists, arrDetail, objCPM.WastemngId);
            return this.connDB.ExecuteBatchDML(arrayLists);
        }

        public void updateAvailableQnt(decimal amount, int itemID, int production_unit)
        {
            double desiredUnit = 0;
            double num = 0;
            int num1 = 0;
            int num2 = 0;
            DataTable dataTable = new DataTable();
            dataTable = this.objPMBLL.GetItemLotInfo(itemID);
            if (dataTable.Rows.Count > 0)
            {
                num2 = Convert.ToInt32(dataTable.Rows[0]["unit_id"]);
            }
            desiredUnit = this.objUntConversion.convertAmountToDesiredUnit(amount, production_unit, num2);
            double num3 = desiredUnit;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                num = Convert.ToDouble(dataTable.Rows[i]["available_qnt"]);
                Convert.ToDouble(dataTable.Rows[i]["purchase_unit_price"]);
                num1 = Convert.ToInt32(dataTable.Rows[i]["lot_no"]);
                if (num3 == num)
                {
                    object[] objArray = new object[] { "UPDATE trns_purchase_detail\r\n                                SET lot_no_status='true', available_qnt=available_qnt-", desiredUnit, " WHERE item_id=", itemID, " AND lot_no=", num1 };
                    string str = string.Concat(objArray);
                    this.connDB.ExecuteDML(str);
                    return;
                }
                if (num3 > num)
                {
                    object[] objArray1 = new object[] { "UPDATE trns_purchase_detail\r\n                                SET lot_no_status='true', available_qnt=available_qnt-", num, " WHERE item_id=", itemID, " AND lot_no=", num1 };
                    string str1 = string.Concat(objArray1);
                    this.connDB.ExecuteDML(str1);
                    num3 -= num;
                }
                else if (num3 < num)
                {
                    object[] objArray2 = new object[] { "UPDATE trns_purchase_detail\r\n                                SET available_qnt=available_qnt-", num3, " WHERE item_id=", itemID, " AND lot_no=", num1 };
                    string str2 = string.Concat(objArray2);
                    this.connDB.ExecuteDML(str2);
                    num3 -= num3;
                    return;
                }
            }
        }

        public bool updatePurchaseStatus(ContructualProductionIssueDAO objPLQDao)
        {
            object[] itemId = new object[] { "update trns_purchase_detail Set lot_no_status=true Where item_id =", objPLQDao.Item_id, " and lot_no=", objPLQDao.Lot_no };
            string str = string.Concat(itemId);
            return this.connDB.ExecuteDML(str);
        }
    }
}

