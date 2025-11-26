using System;
using System.Data;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Util
    {
        public Util()
        {
        }

        public static DropDownList fillBandrollId(DropDownList drpItem)
        {
            DataSet allBandrollData = (new itemBandrollBLL()).GetAllBandrollData();
            if (allBandrollData != null && allBandrollData.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = allBandrollData;
                drpItem.DataTextField = allBandrollData.Tables[0].Columns["bandrollId"].ToString();
                drpItem.DataValueField = allBandrollData.Tables[0].Columns["bandroll_id"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillBandrollIdByOrgWithStock(DropDownList drpItem, itemBandrollDAO objitemBandrollDAO)
        {
            DataSet bandrollByOrgWithStock = (new itemBandrollBLL()).GetBandrollByOrgWithStock(objitemBandrollDAO);
            if (bandrollByOrgWithStock != null && bandrollByOrgWithStock.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = bandrollByOrgWithStock;
                drpItem.DataTextField = bandrollByOrgWithStock.Tables[0].Columns["bandrolls"].ToString();
                drpItem.DataValueField = bandrollByOrgWithStock.Tables[0].Columns["bId"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillBank(DropDownList drpBank)
        {
            DataSet allBank = (new SetBankBLL()).getAllBank();
            if (allBank != null)
            {
                drpBank.DataSource = allBank;
                drpBank.DataTextField = allBank.Tables[0].Columns["bank_name"].ToString();
                drpBank.DataValueField = allBank.Tables[0].Columns["bank_id"].ToString();
                drpBank.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpBank.Items.Insert(0, listItem);
            return drpBank;
        }

        public static DropDownList fillBankBranch(DropDownList drpBankBrach, int intBankId)
        {
            DataTable dataTable = (new SetBankBranchBLL()).dtGetBankBranchByBankId(intBankId);
            if (dataTable != null)
            {
                drpBankBrach.DataSource = dataTable;
                drpBankBrach.DataTextField = dataTable.Columns["branch_name"].ToString();
                drpBankBrach.DataValueField = dataTable.Columns["branch_id"].ToString();
                drpBankBrach.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpBankBrach.Items.Insert(0, listItem);
            return drpBankBrach;
        }

        public static DropDownList fillChallanNo(DropDownList drpChallan)
        {
            DataTable challanNumber = (new ChallanBLL()).getChallanNumber();
            if (challanNumber != null)
            {
                drpChallan.DataSource = challanNumber;
                drpChallan.DataTextField = challanNumber.Columns["challan_no"].ToString();
                drpChallan.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChallan.Items.Insert(0, listItem);
            return drpChallan;
        }

        public static DropDownList fillChallanNoByOrgId(DropDownList drpChlNo, int orgId)
        {
            DataTable challanNoDateByOrg = (new trnsNoteMasterBLL()).getChallanNoDateByOrg(orgId);
            if (challanNoDateByOrg != null)
            {
                drpChlNo.DataSource = challanNoDateByOrg;
                drpChlNo.DataTextField = challanNoDateByOrg.Columns["challanNoDate"].ToString();
                drpChlNo.DataValueField = challanNoDateByOrg.Columns["Challan_id"].ToString();
                drpChlNo.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChlNo.Items.Insert(0, listItem);
            return drpChlNo;
        }

        public static DropDownList fillChallanNoByParty(DropDownList drpChallanNoDate, int PartyId, int orgId)
        {
            DataTable challanNoDateByPartyAndOrg = (new trnsNoteMasterBLL()).getChallanNoDateByPartyAndOrg(PartyId, orgId);
            if (challanNoDateByPartyAndOrg != null)
            {
                drpChallanNoDate.DataSource = challanNoDateByPartyAndOrg;
                drpChallanNoDate.DataTextField = challanNoDateByPartyAndOrg.Columns["challanNoDate"].ToString();
                drpChallanNoDate.DataValueField = challanNoDateByPartyAndOrg.Columns["Challan_id"].ToString();
                drpChallanNoDate.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChallanNoDate.Items.Insert(0, listItem);
            return drpChallanNoDate;
        }

        public static DropDownList fillChallanType(DropDownList drpChallanType)
        {
            DataTable challanType = (new trnsTreasuryChallanBLL()).getChallanType();
            if (challanType != null)
            {
                drpChallanType.DataSource = challanType;
                drpChallanType.DataTextField = challanType.Columns["code_name"].ToString();
                drpChallanType.DataValueField = challanType.Columns["code_id_d"].ToString();
                drpChallanType.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChallanType.Items.Insert(0, listItem);
            return drpChallanType;
        }

        public static DropDownList fillChallanTypeWithOrderBy(DropDownList drpChallanType)
        {
            DataTable challanTypeWithOrderBy = (new trnsTreasuryChallanBLL()).getChallanTypeWithOrderBy();
            if (challanTypeWithOrderBy != null)
            {
                drpChallanType.DataSource = challanTypeWithOrderBy;
                drpChallanType.DataTextField = challanTypeWithOrderBy.Columns["code_name"].ToString();
                drpChallanType.DataValueField = challanTypeWithOrderBy.Columns["code_id_d"].ToString();
                drpChallanType.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChallanType.Items.Insert(0, listItem);
            return drpChallanType;
        }

        public static DropDownList fillCountry(DropDownList drpCountry)
        {
            DataTable dataTable = (new SetCountryBLL()).dtGetAllCountry();
            if (dataTable != null)
            {
                drpCountry.DataSource = dataTable;
                drpCountry.DataTextField = dataTable.Columns["country_name"].ToString();
                drpCountry.DataValueField = dataTable.Columns["country_id"].ToString();
                drpCountry.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpCountry.Items.Insert(0, listItem);
            return drpCountry;
        }

        public static DropDownList fillCurrencyUnit(DropDownList drpCurrencyName)
        {
            DataTable allCurrencyUnit = (new setCurrencyBLL()).getAllCurrencyUnit();
            if (allCurrencyUnit != null)
            {
                drpCurrencyName.DataSource = allCurrencyUnit;
                drpCurrencyName.DataTextField = allCurrencyUnit.Columns["currency_code"].ToString();
                drpCurrencyName.DataValueField = allCurrencyUnit.Columns["currency_id"].ToString();
                drpCurrencyName.DataBind();
            }
            ListItem listItem = new ListItem("--SELECT--", "0");
            drpCurrencyName.Items.Insert(0, listItem);
            return drpCurrencyName;
        }

        public static DropDownList fillDisposalReason(DropDownList drpDReason)
        {
            DataSet disposalReason = (new TransSaleMasterBLL()).getDisposalReason();
            if (disposalReason == null || disposalReason.Tables[0].Rows.Count <= 0)
            {
                drpDReason.DataSource = null;
                drpDReason.Items.Clear();
            }
            else
            {
                drpDReason.DataSource = disposalReason;
                drpDReason.DataTextField = disposalReason.Tables[0].Columns["code_name"].ToString();
                drpDReason.DataValueField = disposalReason.Tables[0].Columns["code_id_d"].ToString();
                drpDReason.DataBind();
                ListItem listItem = new ListItem("---SELECT---", "0");
                drpDReason.Items.Insert(0, listItem);
            }
            return drpDReason;
        }

        public static DropDownList fillDistrict(DropDownList drpDistrictName)
        {
            DataTable districtName = (new setUpazilaBLL()).getDistrictName();
            if (districtName != null)
            {
                drpDistrictName.DataSource = districtName;
                drpDistrictName.DataTextField = districtName.Columns["district_name"].ToString();
                drpDistrictName.DataValueField = districtName.Columns["district_id"].ToString();
                drpDistrictName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpDistrictName.Items.Insert(0, listItem);
            return drpDistrictName;
        }

        public static DropDownList filldivision(DropDownList drpDivision)
        {
            DataTable divisionData = (new SetDivsionBLL()).getDivisionData();
            if (divisionData != null)
            {
                drpDivision.DataSource = divisionData;
                drpDivision.DataTextField = divisionData.Columns["division_name"].ToString();
                drpDivision.DataValueField = divisionData.Columns["division_id"].ToString();
                drpDivision.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpDivision.Items.Insert(0, listItem);
            return drpDivision;
        }

        public static DropDownList fillExportItem(DropDownList drpChallan, int item_id)
        {
            DataTable exportItem = (new ChallanBLL()).getExportItem(item_id);
            if (exportItem != null && exportItem.Rows.Count > 0)
            {
                drpChallan.DataSource = exportItem;
                drpChallan.DataTextField = exportItem.Columns["item_name"].ToString();
                drpChallan.DataValueField = exportItem.Columns["item_id"].ToString();
                drpChallan.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChallan.Items.Insert(0, listItem);
            return drpChallan;
        }

        public static DropDownList fillImportItem(DropDownList drpChallan, string fromDate, string toDate)
        {
            DataTable imporItem = (new ChallanBLL()).getImporItem(fromDate, toDate);
            if (imporItem != null)
            {
                drpChallan.DataSource = imporItem;
                drpChallan.DataTextField = imporItem.Columns["item_name"].ToString();
                drpChallan.DataValueField = imporItem.Columns["item_id"].ToString();
                drpChallan.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChallan.Items.Insert(0, listItem);
            return drpChallan;
        }

        public static DropDownList fillInstrumentType(DropDownList drpBank)
        {
            DataSet allInstrumentTypeCode = (new CodeBLL()).GetAllInstrumentTypeCode();
            if (allInstrumentTypeCode != null)
            {
                drpBank.DataSource = allInstrumentTypeCode;
                drpBank.DataTextField = allInstrumentTypeCode.Tables[0].Columns["CODE_SHORT_NAME"].ToString();
                drpBank.DataValueField = allInstrumentTypeCode.Tables[0].Columns["CODE_ID_D"].ToString();
                drpBank.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpBank.Items.Insert(0, listItem);
            drpBank.SelectedValue = "1";
            return drpBank;
        }

        public static DropDownList fillItemCategoryDropDownList(DropDownList drpItemCategory)
        {
            DataSet allItemCategory = (new AddItemBLL()).getAllItemCategory();
            if (allItemCategory != null && allItemCategory.Tables[0].Rows.Count > 0)
            {
                drpItemCategory.DataSource = allItemCategory;
                drpItemCategory.DataTextField = allItemCategory.Tables[0].Columns["CATEGORY_NAME"].ToString();
                drpItemCategory.DataValueField = allItemCategory.Tables[0].Columns["CATEGORY_ID"].ToString();
                drpItemCategory.DataBind();
            }
            ListItem listItem = new ListItem(" ", "0");
            drpItemCategory.Items.Insert(0, listItem);
            return drpItemCategory;
        }

        public static DropDownList fillItemName(DropDownList drpItem)
        {
            DataSet items = (new ItemBLL()).getItems();
            if (items != null && items.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = items;
                drpItem.DataTextField = items.Tables[0].Columns["item_name"].ToString();
                drpItem.DataValueField = items.Tables[0].Columns["Item_id"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillItemNameByChallanId(DropDownList drpItem, short challanId)
        {
            DataSet itemsByChallanId = (new ItemBLL()).getItemsByChallanId(challanId);
            if (itemsByChallanId != null && itemsByChallanId.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = itemsByChallanId;
                drpItem.DataTextField = itemsByChallanId.Tables[0].Columns["item_name"].ToString();
                drpItem.DataValueField = itemsByChallanId.Tables[0].Columns["detail_id"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillItemType(DropDownList drpItem)
        {
            DataSet itemTypes = (new ItemBLL()).getItemTypes();
            if (itemTypes != null && itemTypes.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = itemTypes;
                drpItem.DataTextField = itemTypes.Tables[0].Columns["code_name"].ToString();
                drpItem.DataValueField = itemTypes.Tables[0].Columns["itemCode"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillItemWithHashCode(DropDownList drpItem)
        {
            DataSet allItemNameWithHashCode = (new ItemBLL()).getAllItemNameWithHashCode();
            if (allItemNameWithHashCode != null && allItemNameWithHashCode.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = allItemNameWithHashCode;
                drpItem.DataTextField = allItemNameWithHashCode.Tables[0].Columns["items"].ToString();
                drpItem.DataValueField = allItemNameWithHashCode.Tables[0].Columns["Item_id"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillItemWithPrice(DropDownList drpItem, DataSet ds)
        {
            PriceDeclaretionBLL priceDeclaretionBLL = new PriceDeclaretionBLL();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = ds;
                drpItem.DataTextField = ds.Tables[0].Columns["ItemName"].ToString();
                drpItem.DataValueField = ds.Tables[0].Columns["ItemId"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillOrgName(DropDownList drpOrgName)
        {
            DataTable orgData = (new trnsNoteMasterBLL()).getOrgData();
            if (orgData != null)
            {
                drpOrgName.DataSource = orgData;
                drpOrgName.DataTextField = orgData.Columns["organization_name"].ToString();
                drpOrgName.DataValueField = orgData.Columns["Organization_id"].ToString();
                drpOrgName.DataBind();
            }
            return drpOrgName;
        }

        public static DropDownList fillOrgUnitbyOrgId(DropDownList drpOrgUnit, short OrgId)
        {
            DataTable orgUnitbyOrgId = (new OrgSubsidiaryUnitsBLL()).getOrgUnitbyOrgId(OrgId);
            if (orgUnitbyOrgId != null)
            {
                drpOrgUnit.DataSource = orgUnitbyOrgId;
                drpOrgUnit.DataTextField = orgUnitbyOrgId.Columns["unit_name"].ToString();
                drpOrgUnit.DataValueField = orgUnitbyOrgId.Columns["sub_unit_id"].ToString();
                drpOrgUnit.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpOrgUnit.Items.Insert(0, listItem);
            return drpOrgUnit;
        }

        public static DropDownList fillPartyName(DropDownList drpPartyName)
        {
            DataTable partyDataImport = (new trnsNoteMasterBLL()).getPartyDataImport();
            if (partyDataImport != null)
            {
                drpPartyName.DataSource = partyDataImport;
                drpPartyName.DataTextField = partyDataImport.Columns["party_name"].ToString();
                drpPartyName.DataValueField = partyDataImport.Columns["Party_id"].ToString();
                drpPartyName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpPartyName.Items.Insert(0, listItem);
            return drpPartyName;
        }

        public static DropDownList fillPartyNameByOrg(DropDownList drpPartyName, short orgId)
        {
            DataTable partyDataByOrg = (new trnsNoteMasterBLL()).getPartyDataByOrg(orgId);
            if (partyDataByOrg != null)
            {
                drpPartyName.DataSource = partyDataByOrg;
                drpPartyName.DataTextField = partyDataByOrg.Columns["party_name"].ToString();
                drpPartyName.DataValueField = partyDataByOrg.Columns["Party_id"].ToString();
                drpPartyName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpPartyName.Items.Insert(0, listItem);
            return drpPartyName;
        }

        public static DropDownList fillPoliceStation(DropDownList drpPoliceStation)
        {
            DataTable allPoliceStation = (new SetPoliceStationBLL()).getAllPoliceStation();
            if (allPoliceStation != null)
            {
                drpPoliceStation.DataSource = allPoliceStation;
                drpPoliceStation.DataTextField = allPoliceStation.Columns["police_station_name"].ToString();
                drpPoliceStation.DataValueField = allPoliceStation.Columns["police_station_id"].ToString();
                drpPoliceStation.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpPoliceStation.Items.Insert(0, listItem);
            return drpPoliceStation;
        }

        public static DropDownList fillPoliceStationByUnionward(DropDownList drpThana, int intunionID)
        {
            DataTable policeStationDataByUnionward = (new setUnionWardBLL()).getPoliceStationDataByUnionward(intunionID);
            if (policeStationDataByUnionward != null)
            {
                drpThana.DataSource = policeStationDataByUnionward;
                drpThana.DataTextField = policeStationDataByUnionward.Columns["police_station_name"].ToString();
                drpThana.DataValueField = policeStationDataByUnionward.Columns["police_station_id"].ToString();
                drpThana.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpThana.Items.Insert(0, listItem);
            return drpThana;
        }

        public static DropDownList fillPurchaseChallanNo(DropDownList drpItem, string PurchaseType)
        {
            DataSet challanNobyPurchaseType = (new trnsPurchaseDetailBLL()).getChallanNobyPurchaseType(PurchaseType);
            if (challanNobyPurchaseType != null && challanNobyPurchaseType.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = challanNobyPurchaseType;
                drpItem.DataTextField = challanNobyPurchaseType.Tables[0].Columns["challan_no"].ToString();
                drpItem.DataValueField = challanNobyPurchaseType.Tables[0].Columns["Challan_id"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillPurchasedItembyChallanId(DropDownList drpItem, short challanId)
        {
            DataSet itemInfoByChallanId = (new trnsPurchaseDetailBLL()).getItemInfoByChallanId(challanId);
            if (itemInfoByChallanId != null && itemInfoByChallanId.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = itemInfoByChallanId;
                drpItem.DataTextField = itemInfoByChallanId.Tables[0].Columns["ItemName"].ToString();
                drpItem.DataValueField = itemInfoByChallanId.Tables[0].Columns["ItemId"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillRbtItem(DropDownList drpRbtItemName, int PartyId, string ChallanNo)
        {
            DataTable purchasedItemByPartyAndChallanNo = (new trnsNoteMasterBLL()).getPurchasedItemByPartyAndChallanNo(PartyId, ChallanNo);
            if (purchasedItemByPartyAndChallanNo != null)
            {
                drpRbtItemName.DataSource = purchasedItemByPartyAndChallanNo;
                drpRbtItemName.DataTextField = purchasedItemByPartyAndChallanNo.Columns["items"].ToString();
                drpRbtItemName.DataValueField = purchasedItemByPartyAndChallanNo.Columns["item_id_row"].ToString();
                drpRbtItemName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpRbtItemName.Items.Insert(0, listItem);
            return drpRbtItemName;
        }

        public static DropDownList fillReceiveChallanIdByBandrollId(DropDownList drpItem, itemBandrollDAO objitemBandrollDAO)
        {
            DataSet bChallanIdByBandrollIdWithStock = (new itemBandrollBLL()).GetBChallanIdByBandrollIdWithStock(objitemBandrollDAO);
            if (bChallanIdByBandrollIdWithStock != null && bChallanIdByBandrollIdWithStock.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = bChallanIdByBandrollIdWithStock;
                drpItem.DataTextField = bChallanIdByBandrollIdWithStock.Tables[0].Columns["ChlnNo"].ToString();
                drpItem.DataValueField = bChallanIdByBandrollIdWithStock.Tables[0].Columns["ChlnId"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillSaleChallanNo(DropDownList drpChallan)
        {
            DataTable saleChallanNumber = (new trnsSaleMasterBLL()).getSaleChallanNumber();
            if (saleChallanNumber != null)
            {
                drpChallan.DataSource = saleChallanNumber;
                drpChallan.DataTextField = saleChallanNumber.Columns["challan_no"].ToString();
                drpChallan.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpChallan.Items.Insert(0, listItem);
            return drpChallan;
        }

        public static DropDownList fillSubCategory(DropDownList drpSubCategory)
        {
            DataSet subCategory = (new AddItemBLL()).getSubCategory();
            if (subCategory == null || subCategory.Tables[0].Rows.Count <= 0)
            {
                drpSubCategory.DataSource = null;
                drpSubCategory.Items.Clear();
            }
            else
            {
                drpSubCategory.DataSource = subCategory;
                drpSubCategory.DataTextField = subCategory.Tables[0].Columns["CATEGORY_NAME"].ToString();
                drpSubCategory.DataValueField = subCategory.Tables[0].Columns["CATEGORY_ID"].ToString();
                drpSubCategory.DataBind();
                ListItem listItem = new ListItem(" ", "0");
                drpSubCategory.Items.Insert(0, listItem);
            }
            return drpSubCategory;
        }

        public static DropDownList fillTreasuryChallanByOrgId(DropDownList drpItem, short OrgId)
        {
            DataSet challanInfoByOrgId = (new trnsTreasuryChallanBLL()).getChallanInfoByOrgId(OrgId);
            if (challanInfoByOrgId != null && challanInfoByOrgId.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = challanInfoByOrgId;
                drpItem.DataTextField = challanInfoByOrgId.Tables[0].Columns["challanId"].ToString();
                drpItem.DataValueField = challanInfoByOrgId.Tables[0].Columns["Challan_id"].ToString();
                drpItem.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpItem.Items.Insert(0, listItem);
            return drpItem;
        }

        public static DropDownList fillUnionWardByUpazila(DropDownList drpUnionWardName, int intUpazilaId)
        {
            DataTable unionWardDataByUpazila = (new setUnionWardBLL()).getUnionWardDataByUpazila(intUpazilaId);
            if (unionWardDataByUpazila != null)
            {
                drpUnionWardName.DataSource = unionWardDataByUpazila;
                drpUnionWardName.DataTextField = unionWardDataByUpazila.Columns["union_ward_name"].ToString();
                drpUnionWardName.DataValueField = unionWardDataByUpazila.Columns["union_ward_id"].ToString();
                drpUnionWardName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpUnionWardName.Items.Insert(0, listItem);
            return drpUnionWardName;
        }

        public static DropDownList fillUnionWardNameDropdownList(DropDownList drpUnionWardName)
        {
            DataTable allUnionWardData = (new setUnionWardBLL()).getAllUnionWardData();
            if (allUnionWardData != null)
            {
                drpUnionWardName.DataSource = allUnionWardData;
                drpUnionWardName.DataTextField = allUnionWardData.Columns["union_ward_name"].ToString();
                drpUnionWardName.DataValueField = allUnionWardData.Columns["union_ward_id"].ToString();
                drpUnionWardName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpUnionWardName.Items.Insert(0, listItem);
            return drpUnionWardName;
        }

        public static DropDownList fillUpazila(DropDownList drpUpazilaName)
        {
            DataTable upazillaforgv = (new setUpazilaBLL()).getUpazillaforgv();
            if (upazillaforgv != null)
            {
                drpUpazilaName.DataSource = upazillaforgv;
                drpUpazilaName.DataTextField = upazillaforgv.Columns["upazila_name"].ToString();
                drpUpazilaName.DataValueField = upazillaforgv.Columns["upazila_id"].ToString();
                drpUpazilaName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpUpazilaName.Items.Insert(0, listItem);
            return drpUpazilaName;
        }

        public static DropDownList fillUpazillaNameDropdownList(DropDownList drpUpzaillaName)
        {
            DataTable allUpazilaData = (new setUpazillaBLL()).getAllUpazilaData();
            if (allUpazilaData != null)
            {
                drpUpzaillaName.DataSource = allUpazilaData;
                drpUpzaillaName.DataTextField = allUpazilaData.Columns["upazila_name"].ToString();
                drpUpzaillaName.DataValueField = allUpazilaData.Columns["upazila_id"].ToString();
                drpUpzaillaName.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpUpzaillaName.Items.Insert(0, listItem);
            return drpUpzaillaName;
        }

        public static DropDownList fillVehicle(DropDownList drpVehicleType)
        {
            DataTable vehicleType = (new trnsNoteMasterBLL()).getVehicleType();
            if (vehicleType != null)
            {
                drpVehicleType.DataSource = vehicleType;
                drpVehicleType.DataTextField = vehicleType.Columns["code_name"].ToString();
                drpVehicleType.DataValueField = vehicleType.Columns["code_id_d"].ToString();
                drpVehicleType.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpVehicleType.Items.Insert(0, listItem);
            return drpVehicleType;
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
            {
                return "Zero";
            }
            if (number < 0)
            {
                return string.Concat("Minus ", Util.NumberToWords(Math.Abs(number)));
            }
            string str = "";
            if (number / 1000000 > 0)
            {
                str = string.Concat(str, Util.NumberToWords(number / 1000000), " Million ");
                number %= 1000000;
            }
            if (number / 1000 > 0)
            {
                str = string.Concat(str, Util.NumberToWords(number / 1000), " Thousand ");
                number %= 1000;
            }
            if (number / 100 > 0)
            {
                str = string.Concat(str, Util.NumberToWords(number / 100), " Hundred ");
                number %= 100;
            }
            if (number > 0)
            {
                if (str != "")
                {
                    str = str ?? "";
                }
                string[] strArrays = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                string[] strArrays1 = strArrays;
                string[] strArrays2 = new string[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                string[] strArrays3 = strArrays2;
                if (number >= 20)
                {
                    str = string.Concat(str, strArrays3[number / 10]);
                    if (number % 10 > 0)
                    {
                        str = string.Concat(str, "-", strArrays1[number % 10]);
                    }
                }
                else
                {
                    str = string.Concat(str, strArrays1[number]);
                }
            }
            return str;
        }
    }
}