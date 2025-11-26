using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class ProductTransferBLL
    {
        private DBUtility connDB = new DBUtility();

        public ProductTransferBLL()
        {
        }

        public DataTable fillOrgBranch()
        {
            return this.connDB.GetDataTable("select org_branch_reg_id,organization_id,central_bin,branch_unit_bin,branch_unit_name,date_of_registration  from org_branch_reg_info");
        }

        public DataTable fillProperty(int itemId)
        {
            string str = string.Concat("select \r\n                        case when property_id1 is null then 0 else property_id1 end property1,\r\n                        case when property_id2 is null then 0 else property_id2 end property2,\r\n                        case when property_id3 is null then 0 else property_id3 end property3,\r\n                        case when property_id4 is null then 0 else property_id4 end property4,\r\n                        case when property_id5 is null then 0 else property_id5 end property5\r\n                        from trns_purchase_detail where item_id = ", itemId);
            return this.connDB.GetDataTable(str);
        }

        public DataTable getAllBranchByOrgID(int OrgID)
        {
            string str = string.Concat("select distinct b.org_branch_reg_id as branch_id, b.branch_unit_name as branch_name, b.branch_unit_bin as bin,(a.holding ||','|| a.road_no ||','|| a.road ||','||a.para_moholla ||','||d.district_name) address\r\n                        from org_branch_reg_info as b\r\n                        inner join all_address as a\r\n                        on a.org_branch_reg_id = b.org_branch_reg_id\r\n                        inner join set_district as d\r\n                        on d.district_id = a.district_id\r\n                        where b.organization_id = ", OrgID, " AND b.is_deleted = false\r\n                        order by  branch_id");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getChallanNoByParty(int partyId)
        {
            string str = string.Concat("select challan_no from trns_sale_master tsm \r\n               inner join trns_sale_detail tsd  on tsm.challan_id=tsd.challan_id\r\n               where party_id=", partyId, " and tsd.is_source_tax_deduct=true and tsd.vds_certificate_no is null ");
            return this.connDB.GetDataTable(str);
        }

        public DataTable getIssuedItemsbyChallan(string challanNo)
        {
            DataTable dataTable;
            try
            {
                string[] strArrays = new string[] { "select i.item_name,i.brand_name,i.item_id, Quantity as issued_quantity, iu.unit_code Unit,d.row_no,iu.unit_id,\r\n                               case when m.material_type='C' then 'Finish Product Production' \r\n                                    when m.material_type='R' then 'Raw Materials' \r\n                                    when m.material_type='F' then 'Finish Product' end product_type,\r\n                              d.unit_price,d.vat_amount,d.sd_amount,\r\n                               case when d.property_id1 is null  then 0 else d.property_id1 end property_id1,\r\n                               case when d.property_id2 is null  then 0 else d.property_id2 end property_id2,\r\n                               case when d.property_id3 is null  then 0 else d.property_id3 end property_id3,\r\n                               case when d.property_id4 is null  then 0 else d.property_id4 end property_id4,\r\n                               case when d.property_id5 is null  then 0 else d.property_id5 end property_id5\r\n\r\n                               ,(case when d.property_id1 is not null AND d.property_id1 > 0 then (select property_name from item_property where property_id=d.property_id1) else '' end) AS Property1_Text\r\n                               ,(case when d.property_id2 is not null AND d.property_id2 > 0 then (select property_name from item_property where property_id=d.property_id2) else '' end) AS Property2_Text\r\n                               ,(case when d.property_id3 is not null AND d.property_id3 > 0 then (select property_name from item_property where property_id=d.property_id3) else '' end) AS Property3_Text\r\n                               ,(case when d.property_id4 is not null AND d.property_id4 > 0 then (select property_name from item_property where property_id=d.property_id4) else '' end) AS Property4_Text\r\n                               ,(case when d.property_id5 is not null AND d.property_id5 > 0 then (select property_name from item_property where property_id=d.property_id5) else '' end) AS Property5_Text\r\n\r\n                               ,d.Remarks,d.purchase_type,m.vehicle_type_d,m.vehicle_no\r\n                             ,coalesce(d.quantity-coalesce((select SUM(quantity) quantity1 from trns_transfer_detail d  inner join trns_transfer_master as m on m.transfer_id = d.transfer_id where  m.challan_no = '", challanNo, "' and m.transfer_status = 'R' ),0),0) received_quantity\r\n                            from trns_transfer_master as m\r\n                            inner join trns_transfer_detail as d on m.transfer_id = d.transfer_id\r\n                            inner join item as i on i.item_id = d.item_id\r\n                            inner join  item_unit as iu on iu.unit_id = d.unit_id\r\n                            left join app_code_detail acd on acd.code_id_d = m.vehicle_type_d and acd.code_id_m=7\r\n                            where m.transfer_status = 'I' and m.is_deleted = false and m.challan_no='", challanNo, "'" };
                string str = string.Concat(strArrays);
                dataTable = this.connDB.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return dataTable;
        }

        public DataTable getIssuesChallanNo(int transferYear, int issuingId, int rcvId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct m.challan_no,m.transfer_id \r\n                            from trns_transfer_master as m\r\n                            inner join trns_transfer_detail as d\r\n                            on m.transfer_id = d.transfer_id\r\n                            where m.transfer_status = 'I' and d.is_full_receive = false and issuing_branch_id= ", issuingId, " and receiving_branch_id= ", rcvId };
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

        public DataTable getIssuesChallanNoforRepoort(int issuingId, int rcvId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct m.challan_no,m.transfer_id \r\n                            from trns_transfer_master as m\r\n                            inner join trns_transfer_detail as d\r\n                            on m.transfer_id = d.transfer_id\r\n                            where m.transfer_status = 'I' and issuing_branch_id= ", issuingId, " and receiving_branch_id= ", rcvId, " order by m.transfer_id desc" };
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

        private ArrayList getProductTransferDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, long TransferID)
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
                ProductTransferDetail productTransferDetail = new ProductTransferDetail();
                productTransferDetail = (ProductTransferDetail)arrDeailDAO[i];
                if (productTransferDetail.Property1 != 0)
                {
                    str = productTransferDetail.Property1.ToString();
                }
                if (productTransferDetail.Property2 != 0)
                {
                    str1 = productTransferDetail.Property2.ToString();
                }
                if (productTransferDetail.Property3 != 0)
                {
                    str2 = productTransferDetail.Property3.ToString();
                }
                if (productTransferDetail.Property4 != 0)
                {
                    str3 = productTransferDetail.Property4.ToString();
                }
                if (productTransferDetail.Property5 != 0)
                {
                    str4 = productTransferDetail.Property5.ToString();
                }
                productTransferDetail.DetailID = Convert.ToInt64(this.connDB.GetSingleValue("SELECT nextval('transfer_detail_id')"));
                object[] transferID = new object[] { " INSERT INTO trns_transfer_detail (transfer_id, row_no, detail_id, item_id, property_id1, property_id2, \r\n                                                                    property_id3, property_id4, property_id5, unit_id, Quantity, \r\n                                                                    user_id_insert, Remarks,purchase_type,unit_price,vat_amount,sd_amount)\r\n                                VALUES (", TransferID, ", ", productTransferDetail.RowNo, ",", productTransferDetail.DetailID, ", ", productTransferDetail.ItemId, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", productTransferDetail.UnitID, ", ", productTransferDetail.Quantity, ", ", productTransferDetail.UserID, ",'", productTransferDetail.Remark, "','", productTransferDetail.PurchaseType, "', ", productTransferDetail.unit_price, ", ", productTransferDetail.vat_amount, ", ", productTransferDetail.sd_amount, ")" };
                arrDetailList.Add(string.Concat(transferID));
            }
            return arrDetailList;
        }

        public DataTable getRcvChallanNoforRepoort(int issuingId, int rcvId)
        {
            DataTable dataTable;
            try
            {
                object[] objArray = new object[] { "select distinct m.challan_no,m.transfer_id \r\n                            from trns_transfer_master as m\r\n                            inner join trns_transfer_detail as d\r\n                            on m.transfer_id = d.transfer_id\r\n                            where m.transfer_status = 'R' and issuing_branch_id= ", issuingId, " and receiving_branch_id= ", rcvId, "  order by m.transfer_id desc" };
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

        private ArrayList getReceicedProductTransferDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, long TransferID, string challan, int challanId)
        {
            int num = Convert.ToInt16(HttpContext.Current.Session["employee_id"]);
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                int num1 = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('item_detail_id_seq')"));
                string str5 = string.Concat(" ( SELECT coalesce(MAX(row_no)+1,1) ROW_NO FROM trns_purchase_detail WHERE Challan_id = '", challanId, "' )");
                str = " NULL";
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                ProductTransferDetail productTransferDetail = new ProductTransferDetail();
                productTransferDetail = (ProductTransferDetail)arrDeailDAO[i];
                if (productTransferDetail.Property1 != 0)
                {
                    str = productTransferDetail.Property1.ToString();
                }
                if (productTransferDetail.Property2 != 0)
                {
                    str1 = productTransferDetail.Property2.ToString();
                }
                if (productTransferDetail.Property3 != 0)
                {
                    str2 = productTransferDetail.Property3.ToString();
                }
                if (productTransferDetail.Property4 != 0)
                {
                    str3 = productTransferDetail.Property4.ToString();
                }
                if (productTransferDetail.Property5 != 0)
                {
                    str4 = productTransferDetail.Property5.ToString();
                }
                if (productTransferDetail.IsFullReceive)
                {
                    arrDetailList.Add(string.Concat("update trns_transfer_detail set is_full_receive = true where transfer_id = (select transfer_id from trns_transfer_master where challan_no = '", challan, "' and transfer_status = 'I')"));
                }
                productTransferDetail.DetailID = Convert.ToInt64(this.connDB.GetSingleValue("SELECT nextval('transfer_detail_id')"));
                object[] transferID = new object[] { " INSERT INTO trns_transfer_detail (transfer_id, row_no, detail_id, item_id, property_id1, property_id2, \r\n                                                                    property_id3, property_id4, property_id5, unit_id, Quantity, unit_price,\r\n                                                                    user_id_insert, Remarks,is_full_receive,purchase_type)\r\n                                VALUES (", TransferID, ", ", productTransferDetail.RowNo, ",", productTransferDetail.DetailID, ", ", productTransferDetail.ItemId, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", productTransferDetail.UnitID, ", ", productTransferDetail.Quantity, ", ", productTransferDetail.unit_price, ", ", productTransferDetail.UserID, ",'", productTransferDetail.Remark, "',", productTransferDetail.IsFullReceive, ",'", productTransferDetail.PurchaseType, "')" };
                arrDetailList.Add(string.Concat(transferID));
                object[] objArray = new object[] { "INSERT INTO trns_purchase_detail(Challan_id,lot_no,detail_id, row_no, Item_id, unit_id, Quantity, actual_price,Sd, Vat,  User_id_insert, \r\n             total_price, sd_rate, vat_rate, is_source_tax_deduct, is_rebatable,zero_rate,is_truncated,is_mrp, is_exempted,\r\n           Cd, Rd, Ait, Atv, Tti,at, purchase_unit_price, purchase_vat, purchase_sd, sale_unit_price, sale_vatable_price, sale_vat, sale_sd, other_cost,document_processing_fee,vds_amount,purchase_type)\r\n           VALUES (", challanId, ", 0,", num1, ",", str5, ", ", productTransferDetail.ItemId, ",  ", productTransferDetail.UnitID, ", ", productTransferDetail.Quantity, ", 0, 0 , 0, ", num, ",0,0,0,", productTransferDetail.IsVDS, ",  ", productTransferDetail.Rebatable, ",", productTransferDetail.ZeroRate, ",", productTransferDetail.Truncated, ",", productTransferDetail.Mrp, ", ", productTransferDetail.Exempted, ",0,0, 0, 0, 0,0,", productTransferDetail.unit_price, ", ", productTransferDetail.vat_amount, ", ", productTransferDetail.sd_amount, ", 0, 0,0, 0,0,0,0,'", productTransferDetail.PurchaseType, "')" };
                arrDetailList.Add(string.Concat(objArray));
            }
            return arrDetailList;
        }

        public DataTable getSaleVDSChallanNoByParty(int partyId, DateTime fromDate, DateTime toDateN)
        {
            object[] objArray = new object[] { "select Distinct tsvd.sale_challan_no As challan_no, tsvd.sale_challan_id  AS challan_id \r\n                        from trns_sale_vds_detail  tsvd\r\n                        inner join trns_sale_master tsm on tsvd.sale_challan_id=tsm.challan_id\r\n                        --inner join trns_treasury_detail ttd on ttd.purchase_challan_id = tsm.challan_id --was added for IVAS ,now change by instruction of ruhul vai 8.9.2022\r\n                        where tsvd.is_rcv_vds=false and tsm.party_id= ", partyId, " and cast(tsm.date_challan as Date) >=to_date('", fromDate.ToString("dd/MM/yyyy"), "','dd/MM/yyyy') and   cast(tsm.date_challan as Date) <=to_date('", toDateN.ToString("dd/MM/yyyy"), "','dd/MM/yyyy')  order by tsvd.sale_challan_id" };
            string str = string.Concat(objArray);
            return this.connDB.GetDataTable(str);
        }

        public bool insertData(SaleMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            return flag;
        }

        public bool insertProductTransferIssuingData(ProductTransferMaster objMaster, ArrayList arrDetail, ArrayList chkadditionalPropId)
        {
            bool flag;
            bool flag1 = false;
            try
            {
                ArrayList arrayLists = new ArrayList();
                if (objMaster.IsNewParty)
                {
                    objMaster.ReceipentBranchID = Convert.ToInt16(this.connDB.GetSingleValue("SELECT nextval('party_id_seq')"));
                    object[] receipentBranchID = new object[] { "INSERT INTO trns_party (party_id, party_name, party_address, user_id_insert, party_bin)\r\n                                VALUES (", objMaster.ReceipentBranchID, ", upper('", objMaster.NewBranchName, "'), '", objMaster.NewBranchAddress, "', ", objMaster.UserID, ", '", objMaster.NewBranchBIN, "')" };
                    arrayLists.Add(string.Concat(receipentBranchID));
                }
                objMaster.TransferID = Convert.ToInt64(this.connDB.GetSingleValue("SELECT nextval('transfer_id_seq')"));
                object[] transferID = new object[] { "INSERT INTO trns_transfer_master (transfer_id, organization_id, receiving_branch_id, issuing_branch_id, \r\n                                                                        challan_no, cg_challan_no, issues_date, user_id_insert, audit_id_insert, \r\n                                                                        material_type, transfer_status,transfer_year,vehicle_type_m,vehicle_type_d,vehicle_no)\r\n                                VALUES (", objMaster.TransferID, ",", objMaster.OrganizationID, ",", objMaster.ReceipentBranchID, ", ", objMaster.ProviderBranchID, ",'", objMaster.ChallanNo, "', (select coalesce (max (cg_challan_no),0)+1 from trns_transfer_master where transfer_status IN ('I','R') and transfer_year ='", objMaster.TransferYear, "'), to_timestamp('", objMaster.IssueDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),", objMaster.UserID, ",", objMaster.AuditID, ", '", objMaster.MaterialType, "', '", objMaster.TransferStatus, "',", objMaster.TransferYear, ",", objMaster.VehicleTypeM, ",", objMaster.VehicleTypeD, ",'", objMaster.VehicleNo, "')" };
                arrayLists.Add(string.Concat(transferID));
                if (chkadditionalPropId.Count > 0)
                {
                    for (int i = 0; i < chkadditionalPropId.Count; i++)
                    {
                        int num = Convert.ToInt32(chkadditionalPropId[i]);
                        object[] str = new object[] { "Update trns_production_rcv_additional set status='T', org_branch_id=", objMaster.ReceipentBranchID, ",receive_id=", objMaster.TransferID, ", date_challan= to_timestamp('", null, null, null };
                        str[5] = objMaster.IssueDate.ToString("MM/dd/yyyy HH:mm");
                        str[6] = "','MM/dd/yyyy HH24:MI') where additional_info_id=";
                        str[7] = num;
                        arrayLists.Add(string.Concat(str));
                    }
                }
                object[] challanBookId = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 1 where challan_book_id = ", objMaster.ChallanBookId, " and page_no = ", objMaster.ChallanPageNo };
                arrayLists.Add(string.Concat(challanBookId));
                arrayLists = this.getProductTransferDetails(arrayLists, arrDetail, objMaster.TransferID);
                flag1 = this.connDB.ExecuteBatchDML(arrayLists);
                flag = flag1;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                return flag1;
            }
            return flag;
        }

        public bool insertProductTransferReceivingData(ProductTransferMaster objMaster, ArrayList arrDetail, ArrayList chkadditionalPropId)
        {
            bool flag;
            bool flag1 = false;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGBRANCHID"].ToString());
                Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"].ToString());
                ArrayList arrayLists = new ArrayList();
                int num1 = Convert.ToInt16(HttpContext.Current.Session["employee_id"]);
                int num2 = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('challan_id_seq')"));
                objMaster.TransferID = Convert.ToInt64(this.connDB.GetSingleValue("SELECT nextval('transfer_id_seq')"));
                object[] transferID = new object[] { "INSERT INTO trns_transfer_master (transfer_id, organization_id, receiving_branch_id, issuing_branch_id, \r\n                                                                        challan_no, cg_challan_no, issues_date, user_id_insert, audit_id_insert, \r\n                                                                        material_type, transfer_status,transfer_year,receive_scroll_no,vehicle_type_m,vehicle_type_d,vehicle_no)\r\n                                VALUES (", objMaster.TransferID, ",", objMaster.OrganizationID, ",", objMaster.ReceipentBranchID, ", ", objMaster.ProviderBranchID, ",'", objMaster.ChallanNo, "', \r\n                                (select coalesce (max (cg_challan_no),0)+1 from trns_transfer_master where transfer_status IN ('I','R') and transfer_year ='", objMaster.TransferYear, "'), to_timestamp('", objMaster.IssueDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),", objMaster.UserID, ", \r\n                                    ", objMaster.AuditID, ", '", objMaster.MaterialType, "', '", objMaster.TransferStatus, "',", objMaster.TransferYear, ",'", objMaster.ReceiveScrollNo, "',", objMaster.VehicleTypeM, ",", objMaster.VehicleTypeD, ",'", objMaster.VehicleNo, "')" };
                arrayLists.Add(string.Concat(transferID));
                object[] organizationID = new object[] { "INSERT INTO trns_purchase_master(Challan_id,Organization_id, org_branch_reg_id, challan_type, purchase_type, date_challan,   User_id_insert, challan_no )\r\n                     VALUES ( ", num2, ", ", objMaster.OrganizationID, ",", objMaster.ReceipentBranchID, ", 'T','L' , to_timestamp('", null, null, null, null, null, null };
                organizationID[7] = objMaster.IssueDate.ToString("MM/dd/yyyy HH:mm");
                organizationID[8] = "','MM/dd/yyyy HH24:MI'),  ";
                organizationID[9] = num1;
                organizationID[10] = ",\r\n                     '";
                organizationID[11] = objMaster.ChallanNo;
                organizationID[12] = "')";
                arrayLists.Add(string.Concat(organizationID));
                if (chkadditionalPropId.Count > 0)
                {
                    for (int i = 0; i < chkadditionalPropId.Count; i++)
                    {
                        AdditionalProperty additionalProperty = new AdditionalProperty();
                        additionalProperty = (AdditionalProperty)chkadditionalPropId[i];
                        object[] str = new object[] { "Update trns_production_rcv_additional set status='", additionalProperty.status, "',date_challan=to_timestamp('", null, null, null, null, null };
                        str[3] = objMaster.IssueDate.ToString("MM/dd/yyyy HH:mm");
                        str[4] = "','MM/dd/yyyy HH24:MI') where additional_info_id=";
                        str[5] = additionalProperty.additionalInfoId;
                        str[6] = " and org_branch_id=";
                        str[7] = num;
                        arrayLists.Add(string.Concat(str));
                    }
                }
                arrayLists = this.getReceicedProductTransferDetails(arrayLists, arrDetail, objMaster.TransferID, objMaster.ChallanNo, num2);
                flag1 = this.connDB.ExecuteBatchDML(arrayLists);
                flag = flag1;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                return flag1;
            }
            return flag;
        }
    }
}

