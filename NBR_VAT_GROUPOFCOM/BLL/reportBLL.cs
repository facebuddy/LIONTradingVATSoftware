using System;
using System.Data;


namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class reportBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public reportBLL()
        {
        }

        public DataTable GetFullOrganizationInfo(int intOrganizationID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("SELECT o.register_persoon_name,o.Organization_name, ad.holding ||','|| ad.road_no ||','|| ad.road ||','|| d.district_name ||'-'|| ad.post_code_id as address,\r\n                        o.registration_no BIN_NO,ow_phone, ow_fax, vc.circle_code\r\n                         FROM org_registration_info o\r\n                         left outer join vat_circle  vc on o.circle_id = vc.circle_id\r\n                         left join all_address as ad on ad.organization_id = o.organization_id\r\n                         left join set_police_station as p on p.police_station_id = ad.thana_id\r\n                         left join set_upazila as u on u.upazila_id = ad.upazila_id\r\n                         left join set_district as d on d.district_id = ad.district_id\r\n                         where  o.organization_id = ", intOrganizationID, " \r\n                         and ad.is_deleted = false\r\n                         and vc.is_deleted = false\r\n                         and o.is_deleted = false");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetItemforProduction()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select i.item_id, i.item_name ||' - '|| i.hs_code as  item_name\r\n                            from price_item pi\r\n                            inner join item i on pi.item_id = i.item_id\r\n                            where pi.is_deleted = false\r\n                            and (pi.price_declaration_no is not null and pi.price_declaration_no != 'No')\r\n                            and i.product_type = 'C'");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public int GetItemIDforProductionByPriceNo(long PriceID)
        {
            int num = 0;
            try
            {
                string str = string.Concat("select i.item_id\r\n                            from price_item pi\r\n                            inner join item i on pi.item_id = i.item_id\r\n                            where pi.is_deleted = false\r\n                            and (pi.price_declaration_no is not null and pi.price_declaration_no != 'No')\r\n                            and i.product_type = 'C'\r\n                            and pi.price_id = ", PriceID);
                object singleValue = this.DBUtil.GetSingleValue(str);
                if (singleValue != null)
                {
                    num = Convert.ToInt32(singleValue);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return num;
        }

        public DataTable getItemPriceNumber(int intPriceId)
        {
            string str = string.Concat("select price_declaration_no||'/'|| price_declaration_year price_declaration_number,price_declaration_year as year,price_declaration_no\r\n                                from price_item pi  \r\n                                where pi.Is_deleted=false \r\n                                and is_nbr_confirmed=false \r\n                                and price_id='", intPriceId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getOrgById(int orgId)
        {
            string str = string.Concat("select ori.*, va.area_code acode from org_registration_info ori\r\n        inner join vat_area va on va.area_id=ori.area_id\r\n        where ori.Is_deleted=false and ori.Organization_id=", orgId);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPriceDeclarationNo()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.DBUtil.GetDataTable("select price_id, price_declaration_no\r\n                            from price_item pi\r\n                            where pi.is_deleted = false\r\n                            and pi.price_declaration_no is not null \r\n                            and pi.price_declaration_no != 'No'\r\n                            and pi.item_id is not null");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public long GetPriceIDforProductionByItemID(int itemID)
        {
            long num = (long)0;
            try
            {
                string str = string.Concat("select price_id, price_declaration_no\r\n                            from price_item pi\r\n                            where pi.is_deleted = false\r\n                            and pi.price_declaration_no is not null \r\n                            and pi.price_declaration_no != 'No'\r\n                            and pi.item_id is not null\r\n                            and item_id = ", itemID);
                object singleValue = this.DBUtil.GetSingleValue(str);
                if (singleValue != null)
                {
                    num = Convert.ToInt64(singleValue);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return num;
        }

        public DataSet rptFinishGoodProductionDetail(PurchaseMasterDAO objPurchaseMasterDAO, string Filter)
        {
            string str = "";
            if (objPurchaseMasterDAO.ChallanNo != "")
            {
                str = string.Concat(" and tpm.challan_no='", objPurchaseMasterDAO.ChallanNo, "'");
            }
            object[] loggedOrgName = new object[] { "SELECT org.organization_name, org.business_address, org.registration_no BIN, tpm.Challan_id, to_char(tpm.date_challan,'dd/mm/yyyy') challan_date, tpm.challan_no, \r\n        i.item_name, iu.unit_code, tpd.Quantity, tpd.actual_price UnitPrice, tpd.Sd totalSd, tpd.Vat TotalVat, tpd.total_price TotalPrice,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter \r\n        FROM trns_purchase_master tpm\r\n        LEFT JOIN org_registration_info org on tpm.Organization_id=org.Organization_id\r\n        LEFT JOIN trns_purchase_detail tpd on tpm.Challan_id=tpd.Challan_id\r\n        LEFt JOIN Item i on tpd.Item_id=i.Item_id\r\n        LEFT JOIN item_unit iu on tpd.unit_id=iu.unit_id\r\n        where tpm.Is_deleted=false and tpm.challan_type='F' and tpm.Organization_id=", objPurchaseMasterDAO.OrganizatioID, "\r\n        and tpm.date_challan>='", objPurchaseMasterDAO.StartDate, "' and tpm.date_challan<='", objPurchaseMasterDAO.FinishDate, "'", str };
            string str1 = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataSet(str1, "FinishGoodProdutionData");
        }

        public DataTable rptPriceDeclarationGHA(int intPriceId)
        {
            object[] objArray = new object[] { "select pi.price_id, '1' Sl_No_1,i.hs_code HS_Code_2,i.item_name Goods_Name_3,pi.Item_id Item_id,i.item_specification Goods_Description_31,iu.unit_code Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        ''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_Code,\r\n                        '' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        pi.crnt_actl_prc_sd Price_With_SD_Present_10,pi.prpsd_actl_prc_sd Price_With_SD_Applied_11,pi.sd_amount SD_On_Applied_Price_12,pi.crnt_actl_prc_vat VAT_Applicable_Price_Present_13,\r\n                        pi.prpsd_actl_prc_vat VAT_Applicable_Price_Applied_14,pi.wholesale_prc_sd_vat Sale_Price_With_DutyNTax_Wholesale_15,pi.retail_prc_sd_vat Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                        from price_item pi left outer join\r\n                        Item i on pi.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pi.price_id=", intPriceId, " \r\n\r\n              union all\r\n\r\n                        select pri.price_id,'' Sl_No_1,'' HS_Code_2,''Goods_Name_3,pri.Item_id Item_id,'' Goods_Description_31,'' Sale_Unit_4,i.item_name Raw_Materials_Name_5,\r\n                        i.item_specification Ra_Meterials_Description_51,pri.Quantity Raw_Meterials_Quantity_6,iu.unit_code Unit_Code,\r\n                        '('||pri.wastage_quantity||' '||iu.unit_code||')' Raw_Meterials_Depriciation_61,\r\n                        cast(coalesce(pri.txtquantityprice,0) as decimal(10,2)) Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,cast(pri.wastage_quantity as decimal(5,2)) wastage_quantity \r\n                        from price_raw_item pri left outer join\r\n                        Item i on pri.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pri.price_id=", intPriceId, "\r\n                    --union all\r\n\t\t\t           -- select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,acd.code_name Raw_Materials_Name_5,\r\n                      --  '' Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_code,'' Raw_Meterials_Depriciation_61,cast(coalesce(pvaa.item_value,0) as decimal(10,2)) Total_Purchase_Price_7,'' Value_Add_8,\r\n                      --  0 Value_Added_Per_Unit_9,\r\n                      --  0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                     --   0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                      --  from price_value_addition_area pvaa \r\n                     --   left outer join\r\n                      --  app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=14\r\n                      --  where pvaa.value_adtn_item_m=14 and pvaa.price_id=", intPriceId, "\r\n\r\n                      --   union all\r\n\r\n                         --select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        --''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_code,'' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,acd.code_name Value_Add_8,\r\n                        --pvaa.item_value Value_Added_Per_Unit_9,\r\n                        --0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        --0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                        --from price_value_addition_area pvaa \r\n                        --left outer join\r\n                        --app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=8\r\n                        --where pvaa.value_adtn_item_m=8 and pvaa.price_id=", intPriceId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable rptPriceDeclarationGHAA(int intPriceId)
        {
            object[] objArray = new object[] { "select pi.price_id, '1' Sl_No_1,i.hs_code HS_Code_2,i.item_name Goods_Name_3,pi.Item_id Item_id,i.item_specification Goods_Description_31,iu.unit_code Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        ''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_Code,\r\n                        '' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        pi.crnt_actl_prc_sd Price_With_SD_Present_10,pi.prpsd_actl_prc_sd Price_With_SD_Applied_11,pi.sd_amount SD_On_Applied_Price_12,pi.crnt_actl_prc_vat VAT_Applicable_Price_Present_13,\r\n                        pi.prpsd_actl_prc_vat VAT_Applicable_Price_Applied_14,pi.wholesale_prc_sd_vat Sale_Price_With_DutyNTax_Wholesale_15,pi.retail_prc_sd_vat Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                        from price_item pi left outer join\r\n                        Item i on pi.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pi.price_id=", intPriceId, " \r\n\r\n              union all\r\n\r\n                        select pri.price_id,'' Sl_No_1,'' HS_Code_2,''Goods_Name_3,pri.Item_id Item_id,'' Goods_Description_31,'' Sale_Unit_4,i.item_name Raw_Materials_Name_5,\r\n                        i.item_specification Ra_Meterials_Description_51,pri.Quantity Raw_Meterials_Quantity_6,iu.unit_code Unit_Code,\r\n                        '('||pri.wastage_quantity||' '||iu.unit_code||')' Raw_Meterials_Depriciation_61,\r\n                        cast(coalesce(pri.txtquantityprice,0) as decimal(10,2)) Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,cast(pri.wastage_quantity as decimal(5,2)) wastage_quantity \r\n                        from price_raw_item pri left outer join\r\n                        Item i on pri.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pri.price_id=", intPriceId, "\r\n                    --union all\r\n\t\t\t           -- select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,acd.code_name Raw_Materials_Name_5,\r\n                      --  '' Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_code,'' Raw_Meterials_Depriciation_61,cast(coalesce(pvaa.item_value,0) as decimal(10,2)) Total_Purchase_Price_7,'' Value_Add_8,\r\n                      --  0 Value_Added_Per_Unit_9,\r\n                      --  0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                     --   0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                      --  from price_value_addition_area pvaa \r\n                     --   left outer join\r\n                      --  app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=14\r\n                      --  where pvaa.value_adtn_item_m=14 and pvaa.price_id=", intPriceId, "\r\n\r\n                      --   union all\r\n\r\n                         --select pvaa.price_id, '' Sl_No_1,'' HS_Code_2,'' Goods_Name_3,0 Item_id,'' Goods_Description_31,'' Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        --''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_code,'' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,acd.code_name Value_Add_8,\r\n                        --pvaa.item_value Value_Added_Per_Unit_9,\r\n                        --0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        --0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                        --from price_value_addition_area pvaa \r\n                        --left outer join\r\n                        --app_code_detail acd on pvaa.value_adtn_item_d=acd.code_id_d and acd.code_id_m=8\r\n                        --where pvaa.value_adtn_item_m=8 and pvaa.price_id=", intPriceId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable rptPriceDeclarationKHA(int intPriceId)
        {
            object[] objArray = new object[] { "select pi.price_id, '1' Sl_No_1,i.hs_code HS_Code_2,i.item_name Goods_Name_3,pi.Item_id Item_id,i.item_specification Goods_Description_31,iu.unit_code Sale_Unit_4,'' Raw_Materials_Name_5,\r\n                        ''Raw_Meterials_Description_51,0 Raw_Meterials_Quantity_6,'' Unit_Code,\r\n                        '' Raw_Meterials_Depriciation_61,0 Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,\r\n                        pi.crnt_actl_prc_sd Price_With_SD_Present_10,pi.prpsd_actl_prc_sd Price_With_SD_Applied_11,pi.sd_amount SD_On_Applied_Price_12,pi.crnt_actl_prc_vat VAT_Applicable_Price_Present_13,\r\n                        pi.prpsd_actl_prc_vat VAT_Applicable_Price_Applied_14,pi.wholesale_prc_sd_vat Sale_Price_With_DutyNTax_Wholesale_15,pi.retail_prc_sd_vat Sale_Price_With_DutyNTax_Retail_Price_16,0 wastage_quantity\r\n                        from price_item pi left outer join\r\n                        Item i on pi.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pi.price_id=", intPriceId, " \r\n\r\n              union all\r\n\r\n                        select pri.price_id,'' Sl_No_1,'' HS_Code_2,''Goods_Name_3,pri.Item_id Item_id,'' Goods_Description_31,'' Sale_Unit_4,i.item_name Raw_Materials_Name_5,\r\n                        i.item_specification Ra_Meterials_Description_51,pri.Quantity Raw_Meterials_Quantity_6,iu.unit_code Unit_Code,\r\n                        '('||pri.wastage_quantity||' '||iu.unit_code||')' Raw_Meterials_Depriciation_61,\r\n                        cast(coalesce(pri.txtquantityprice,0) as decimal(10,2)) Total_Purchase_Price_7,'' Value_Add_8,\r\n                        0 Value_Added_Per_Unit_9,0 Price_With_SD_Present_10,0 Price_With_SD_Applied_11,0 SD_On_Applied_Price_12,0 VAT_Applicable_Price_Present_13,\r\n                        0 VAT_Applicable_Price_Applied_14,0 Sale_Price_With_DutyNTax_Wholesale_15,0 Sale_Price_With_DutyNTax_Retail_Price_16,cast(pri.wastage_quantity as decimal(5,2)) wastage_quantity \r\n                        from price_raw_item pri left outer join\r\n                        Item i on pri.Item_id=i.Item_id inner join\r\n                        item_unit iu on iu.unit_id=i.unit_id \r\n                        where pri.price_id=", intPriceId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet rptRawMaterialConsumptionDetail(trnsSaleMasterDAO objtrnsSaleMasterDAO, string Filter)
        {
            string str = "";
            if (objtrnsSaleMasterDAO.ChallanNo != "")
            {
                str = string.Concat(" and tsm.challan_no='", objtrnsSaleMasterDAO.ChallanNo, "'");
            }
            object[] loggedOrgName = new object[] { "select org.organization_name, org.business_address, org.registration_no BIN, tsm.Challan_id, tsm.challan_no, \r\n        to_char(tsm.date_challan, 'dd/mm/yyyy') challan_date, i.item_name, iu.unit_code, tsd.Quantity, tsd.actual_price, tsd.Sd, tsd.Vat,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter  \r\n        from trns_sale_master tsm \r\n        LEFT JOIN trns_sale_detail tsd on tsm.Challan_id=tsd.Challan_id\r\n        LEFT JOIN org_registration_info org on tsm.Organization_id=org.Organization_id\r\n        Left JOIN Item i on tsd.Item_id=i.Item_id\r\n        LEFT JOIN item_unit iu on tsd.unit_id=iu.unit_id\r\n        where tsm.Is_deleted=false and tsm.date_challan>= '", objtrnsSaleMasterDAO.StartDate, "' and tsm.date_challan<='", objtrnsSaleMasterDAO.FinishDate, "' and challan_type='R' and tsm.Organization_id=", objtrnsSaleMasterDAO.OrganizationId, " ", str };
            string str1 = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataSet(str1, "RawMaterialConsumptionData");
        }

        public DataSet rptTreasuryChallanDetail(trnsTreasuryChallanDAO objtrnsTreasuryChallanDAO, string Filter)
        {
            string str = "";
            if (objtrnsTreasuryChallanDAO.ChallanTyped != 0)
            {
                str = string.Concat(" and chalan_type_m=9 and chalan_type_d=", objtrnsTreasuryChallanDAO.ChallanTyped);
            }
            object[] loggedOrgName = new object[] { "SELECT ttc.challan_no, to_char(ttc.date_challan, 'dd/mm/yyyy') challan_date,ttc.code_no, ttc.bearer_name_address, bbr.branch_name, org.organization_name behalf_of,\r\n        ttc.deposit_description, ttc.instrument_description, ttc.unit_price, ttc.designation, ttc.Unit, ttc.Amount,\r\n        ttc.instrument_type, acd.code_short_name challan_for, bnk.bank_name,\r\n'", Utility.GetLoggedOrgName(), "' OrgName1, '", Utility.GetLoggedOrgAddress(), "' OrgAddress, '", Utility.GetLoggedOrgBIN(), "' BIN, '", Filter, "' Filter  \r\nFROM trns_treasury_challan ttc\r\n        LEFT JOIN set_bank_branch bbr on ttc.branch_id=bbr.branch_id\r\n        LEFT JOIN org_registration_info org on ttc.Organization_id=org.Organization_id\r\n        LEFT JOIN app_code_detail acd on ttc.chalan_type_m=acd.code_id_m and ttc.chalan_type_d=acd.code_id_d\r\n        LEFT JOIN set_bank bnk on bbr.bank_id=bnk.bank_id\r\n        where ttc.Is_deleted=false and ttc.date_challan>= '", objtrnsTreasuryChallanDAO.StartDate, "' and ttc.date_challan<='", objtrnsTreasuryChallanDAO.FinishDate, "' ", str, " order by ttc.date_challan desc " };
            string str1 = string.Concat(loggedOrgName);
            return this.DBUtil.GetDataSet(str1, "TreasuryChallanDetailRpt");
        }
    }
}

