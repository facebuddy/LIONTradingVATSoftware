using NBR_VAT_GROUPOFCOM.Api;
using Npgsql;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Utility
    {
        public Utility()
        {
        }

        public bool ExecuteBatchDML(ArrayList arrSQL)
        {
            bool flag;
            DBUtility.OpenDBConnection();
            NpgsqlTransaction npgsqlTransaction = null;
            try
            {
                try
                {
                    int i = 0;
                    npgsqlTransaction = DBUtility.npgConn.BeginTransaction();
                    for (i = 0; i < arrSQL.Count; i++)
                    {
                        DBUtility.npgCmd = new NpgsqlCommand(arrSQL[i].ToString(), DBUtility.npgConn, npgsqlTransaction)
                        {
                            CommandTimeout = 7200
                        };
                        DBUtility.npgCmd.ExecuteNonQuery();
                    }
                    npgsqlTransaction.Commit();
                    flag = true;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                    ReallySimpleLog.WriteLog(DBUtility.npgCmd.CommandText);
                    npgsqlTransaction.Rollback();
                    flag = false;
                }
            }
            finally
            {
                DBUtility.CloseDBConnection();
            }
            return flag;
        }

        public static string Encrypt(string passEn)
        {
            string str = "ABEDIN";
            byte[] bytes = Encoding.Unicode.GetBytes(passEn);
            using (Aes ae = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(str, new byte[] { 73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118 });
                ae.Key = rfc2898DeriveByte.GetBytes(32);
                ae.IV = rfc2898DeriveByte.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, ae.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, (int)bytes.Length);
                        cryptoStream.Close();
                    }
                    passEn = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return passEn;
        }

        public static DropDownList fillAllBank(DropDownList ddlBank)
        {
            DataSet allBank = (new SetBankBLL()).getAllBank();
            if (allBank.Tables[0].Rows.Count > 0)
            {
                ddlBank.DataSource = allBank;
                ddlBank.DataTextField = allBank.Tables[0].Columns["bank_name"].ToString();
                ddlBank.DataValueField = allBank.Tables[0].Columns["bank_id"].ToString();
                ddlBank.DataBind();
            }
            return ddlBank;
        }
        public static bool InsertInvoicePrint(string invoiceNo)
        {
            DBUtility dBUtility = new DBUtility();
            DateTime today = DateTime.Today;
            // int num = Convert.ToInt32(dBUtility.GetSingleValue("SELECT  nextval('error_track_id_seq')"));
            object[] objArray = new object[] { "INSERT INTO invoiceprint(invoiceno) VALUES   (", invoiceNo, " )" };
            return dBUtility.ExecuteDML(string.Concat(objArray));
        }

        public static DropDownList fillAllBankBranchByBankID(DropDownList ddlBankBranch, int intBankID)
        {
            DataSet bankBranchByBankId = (new SetBankBranchBLL()).getBankBranchByBankId(intBankID);
            if (bankBranchByBankId.Tables[0].Rows.Count <= 0)
            {
                ddlBankBranch.Items.Clear();
            }
            else
            {
                ddlBankBranch.DataSource = bankBranchByBankId;
                ddlBankBranch.DataTextField = bankBranchByBankId.Tables[0].Columns["branch_name"].ToString();
                ddlBankBranch.DataValueField = bankBranchByBankId.Tables[0].Columns["branch_id"].ToString();
                ddlBankBranch.DataBind();
            }
            return ddlBankBranch;
        }

        public static DropDownList fillAllItem(DropDownList drpItem)
        {
            DataSet allItemForBOMWithService = (new SetItemBLL()).getAllItemForBOMWithService();
            if (allItemForBOMWithService != null)
            {
                drpItem.DataSource = allItemForBOMWithService;
                drpItem.DataTextField = allItemForBOMWithService.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = allItemForBOMWithService.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }

        public static DropDownList fillAllItemByCategory(DropDownList drpItem, int intCategoryId)
        {
            DataSet allItemByCategory = (new SetItemBLL()).getAllItemByCategory(intCategoryId);
            if (allItemByCategory != null)
            {
                drpItem.DataSource = allItemByCategory;
                drpItem.DataTextField = allItemByCategory.Tables[0].Columns["hs_item"].ToString();
                drpItem.DataValueField = allItemByCategory.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }

        public static DropDownList fillAllItemCategory(DropDownList ddlItemCategory)
        {
            DataSet allItemCategory = (new SetItemBLL()).getAllItemCategory();
            if (allItemCategory != null && allItemCategory.Tables[0].Rows.Count > 0)
            {
                ddlItemCategory.DataSource = allItemCategory;
                ddlItemCategory.DataTextField = allItemCategory.Tables[0].Columns["Category_name"].ToString();
                ddlItemCategory.DataValueField = allItemCategory.Tables[0].Columns["Category_id"].ToString();
                ddlItemCategory.DataBind();
            }
            return ddlItemCategory;
        }

        public static DropDownList fillAllItemCategorymqmm(DropDownList ddlCat)
        {
            DataTable allCategorymqmm = (new SetItemBLL()).GetAllCategorymqmm();
            if (allCategorymqmm != null && allCategorymqmm.Rows.Count > 0)
            {
                ddlCat.DataSource = allCategorymqmm;
                ddlCat.DataTextField = allCategorymqmm.Columns["category_name"].ToString();
                ddlCat.DataValueField = allCategorymqmm.Columns["category_id"].ToString();
                ddlCat.DataBind();
            }
            return ddlCat;
        }

        public static DropDownList fillAllItemForBOM(DropDownList drpItem)
        {
            DataSet allItemForBOM = (new SetItemBLL()).getAllItemForBOM();
            if (allItemForBOM != null)
            {
                drpItem.DataSource = allItemForBOM;
                drpItem.DataTextField = allItemForBOM.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = allItemForBOM.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }

        public static DropDownList fillAllItemForBOMWithParameter(DropDownList drpItem, int item_id)
        {
            DataSet allItemForBOMWithParameter = (new SetItemBLL()).getAllItemForBOMWithParameter(item_id);
            if (allItemForBOMWithParameter != null)
            {
                drpItem.DataSource = allItemForBOMWithParameter;
                drpItem.DataTextField = allItemForBOMWithParameter.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = allItemForBOMWithParameter.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }

        public static DropDownList fillAllItemForReport(DropDownList drpItem)
        {
            DataSet itemInfoForReport = (new SetItemBLL()).GetItemInfoForReport();
            if (itemInfoForReport != null)
            {
                drpItem.DataSource = itemInfoForReport;
                drpItem.DataTextField = itemInfoForReport.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = itemInfoForReport.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }

        public static DropDownList fillAllItemN(DropDownList drpItem)
        {
            DataSet allItemForReport621 = (new SetItemBLL()).getAllItemForReport621();


           
          

            if (allItemForReport621 != null)
            {
                drpItem.DataSource = allItemForReport621;
                drpItem.DataTextField = allItemForReport621.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = allItemForReport621.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }



        public static DropDownList fillAllItemNS(DropDownList drpItem)
        {
            DataSet allItemForReport621 = (new SetItemBLL()).getAllItemForReport621S();





            if (allItemForReport621 != null)
            {
                drpItem.DataSource = allItemForReport621;
                drpItem.DataTextField = allItemForReport621.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = allItemForReport621.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }



        public static DropDownList fillAllItemPD(DropDownList drpItem)
        {
            DataSet allItem = (new SetItemBLL()).getAllItem();
            if (allItem != null)
            {
                drpItem.DataSource = allItem;
                drpItem.DataTextField = allItem.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = allItem.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }

        public static DropDownList fillAllPriceDeclarationNo(DropDownList ddlPD)
        {
            DataSet allUnauthorizedPriceDeclarationNo = (new PriceDeclaretionBLL()).getAllUnauthorizedPriceDeclarationNo();
            if (allUnauthorizedPriceDeclarationNo != null && allUnauthorizedPriceDeclarationNo.Tables[0].Rows.Count > 0)
            {
                ddlPD.DataSource = allUnauthorizedPriceDeclarationNo;
                ddlPD.DataTextField = allUnauthorizedPriceDeclarationNo.Tables[0].Columns["price_declaration_no"].ToString();
                ddlPD.DataValueField = allUnauthorizedPriceDeclarationNo.Tables[0].Columns["Price_id"].ToString();
                ddlPD.DataBind();
            }
            return ddlPD;
        }

        public static DropDownList fillAllPriceDeclarationNoByType(DropDownList ddlPD, int intType)
        {
            DataSet allUnauthorizedPriceDeclarationNoByType = (new PriceDeclaretionBLL()).getAllUnauthorizedPriceDeclarationNoByType(intType);
            if (allUnauthorizedPriceDeclarationNoByType != null && allUnauthorizedPriceDeclarationNoByType.Tables[0].Rows.Count > 0)
            {
                ddlPD.DataSource = allUnauthorizedPriceDeclarationNoByType;
                ddlPD.DataTextField = allUnauthorizedPriceDeclarationNoByType.Tables[0].Columns["price_declaration_no"].ToString();
                ddlPD.DataValueField = allUnauthorizedPriceDeclarationNoByType.Tables[0].Columns["Price_id"].ToString();
                ddlPD.DataBind();
            }
            return ddlPD;
        }

        public static DropDownList fillAllRawItemForBOM(DropDownList drpItem)
        {
            DataSet allRawItemForBOM = (new SetItemBLL()).getAllRawItemForBOM();
            if (allRawItemForBOM != null)
            {
                drpItem.DataSource = allRawItemForBOM;
                drpItem.DataTextField = allRawItemForBOM.Tables[0].Columns["ITEM_NAME"].ToString();
                drpItem.DataValueField = allRawItemForBOM.Tables[0].Columns["ITEM_ID"].ToString();
                drpItem.DataBind();
            }
            return drpItem;
        }

        public static DropDownList fillAllUnit(DropDownList drpUnit)
        {
            DataSet allUnit = (new UnitBLL()).getAllUnit();
            if (allUnit != null)
            {
                drpUnit.DataSource = allUnit;
                drpUnit.DataTextField = allUnit.Tables[0].Columns["UNIT_CODE"].ToString();
                drpUnit.DataValueField = allUnit.Tables[0].Columns["UNIT_ID"].ToString();
                drpUnit.DataBind();
            }
            return drpUnit;
        }

        public static DropDownList fillAllUnitFromTable(DropDownList ddlSecUnit)
        {
            DataSet allUnitFromTable = (new UnitBLL()).GetAllUnitFromTable();
            if (allUnitFromTable != null)
            {
                ddlSecUnit.DataSource = allUnitFromTable;
                ddlSecUnit.DataTextField = allUnitFromTable.Tables[0].Columns["UNIT_CODE"].ToString();
                ddlSecUnit.DataValueField = allUnitFromTable.Tables[0].Columns["UNIT_ID"].ToString();
                ddlSecUnit.DataBind();
            }
            return ddlSecUnit;
        }

        public static DropDownList fillAllUnitWithParameter(DropDownList drpUnit, int unit_id)
        {
            DataSet allUnitWithParameter = (new UnitBLL()).getAllUnitWithParameter(unit_id);
            if (allUnitWithParameter != null)
            {
                drpUnit.DataSource = allUnitWithParameter;
                drpUnit.DataTextField = allUnitWithParameter.Tables[0].Columns["UNIT_CODE"].ToString();
                drpUnit.DataValueField = allUnitWithParameter.Tables[0].Columns["UNIT_ID"].ToString();
                drpUnit.DataBind();
            }
            return drpUnit;
        }

        public static DropDownList fillchallanWithParameter(DropDownList txtReference, int challan_id)
        {
            DataSet challanWithParameter = (new ChallanBLL()).getChallanWithParameter(challan_id);
            if (challanWithParameter != null)
            {
                txtReference.DataSource = challanWithParameter;
                txtReference.DataTextField = challanWithParameter.Tables[0].Columns["challan_no"].ToString();
                txtReference.DataValueField = challanWithParameter.Tables[0].Columns["challan_id"].ToString();
                txtReference.DataBind();
            }
            return txtReference;
        }

        public static DropDownList fillDayList(DropDownList ddlDayList)
        {
            ddlDayList.Items.Add(new ListItem("Day", "Day"));
            ddlDayList.SelectedIndex = 0;
            int num = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            for (int i = 1; i <= num; i++)
            {
                ddlDayList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            return ddlDayList;
        }

        public static DropDownList fillDDLAllItemName(DropDownList ddlAllItemName, int CategoreyId)
        {
            DataSet allItemName = (new ItemBLL()).getAllItemName(CategoreyId);
            if (allItemName != null && allItemName.Tables[0].Rows.Count > 0)
            {
                ddlAllItemName.DataSource = allItemName;
                ddlAllItemName.DataTextField = allItemName.Tables[0].Columns["item_name"].ToString();
                ddlAllItemName.DataValueField = allItemName.Tables[0].Columns["Item_id"].ToString();
                ddlAllItemName.DataBind();
            }
            ListItem listItem = new ListItem("....SELECT....", "0");
            ddlAllItemName.Items.Insert(0, listItem);
            return ddlAllItemName;
        }

        public static DropDownList fillDetailCode(DropDownList drpDetailCode, int masterID)
        {
            DataSet allDetailCode = (new CodeBLL()).GetAllDetailCode(masterID);
            if (allDetailCode != null)
            {
                drpDetailCode.DataSource = allDetailCode;
                drpDetailCode.DataTextField = allDetailCode.Tables[0].Columns["CODE_SHORT_NAME"].ToString();
                drpDetailCode.DataValueField = allDetailCode.Tables[0].Columns["CODE_ID_D"].ToString();
                drpDetailCode.DataBind();
            }
            return drpDetailCode;
        }

        public static DropDownList fillItemCategoryDropDownListForAddSubItem(DropDownList drpItemCategory)
        {
            DataSet allCategoryForAddSubCategory = (new AddItemBLL()).getAllCategoryForAddSubCategory();
            if (allCategoryForAddSubCategory != null && allCategoryForAddSubCategory.Tables[0].Rows.Count > 0)
            {
                drpItemCategory.DataSource = allCategoryForAddSubCategory;
                drpItemCategory.DataTextField = allCategoryForAddSubCategory.Tables[0].Columns["CATEGORY_NAME"].ToString();
                drpItemCategory.DataValueField = allCategoryForAddSubCategory.Tables[0].Columns["CATEGORY_ID"].ToString();
                drpItemCategory.DataBind();
            }
            return drpItemCategory;
        }

        public static DropDownList FillItemPropertyDropDownList(DropDownList drpItemPorperty, short propertyMasterID)
        {
            DataTable itemPropertybyMasterID = (new SetItemPropertyBLL()).GetItemPropertybyMasterID(propertyMasterID);
            if (itemPropertybyMasterID.Rows.Count <= 0)
            {
                drpItemPorperty.Items.Clear();
            }
            else
            {
                drpItemPorperty.DataSource = itemPropertybyMasterID;
                drpItemPorperty.DataTextField = itemPropertybyMasterID.Columns["CODE_NAME"].ToString();
                drpItemPorperty.DataValueField = itemPropertybyMasterID.Columns["CODE_ID_D"].ToString();
                drpItemPorperty.DataBind();
            }
            return drpItemPorperty;
        }

        public static DropDownList FillMeasurementTypeDropDownList(DropDownList drpMeasurementType)
        {
            DBUtility dBUtility = new DBUtility();
            DataTable allUnitType = (new UnitBLL()).getAllUnitType();
            drpMeasurementType.DataSource = allUnitType;
            drpMeasurementType.DataTextField = allUnitType.Columns["code_name"].ToString();
            drpMeasurementType.DataValueField = allUnitType.Columns["code_id_d"].ToString();
            drpMeasurementType.DataBind();
            return drpMeasurementType;
        }

        public static DropDownList fillMonthList(DropDownList ddlMonthList)
        {
            ddlMonthList.Items.Add(new ListItem("Month", "Month"));
            ddlMonthList.SelectedIndex = 0;
            DateTime dateTime = Convert.ToDateTime("1/1/2000");
            for (int i = 0; i < 12; i++)
            {
                DateTime dateTime1 = dateTime.AddMonths(i);
                ddlMonthList.Items.Add(new ListItem(dateTime1.ToString("MMMM"), dateTime1.ToString("MM")));
            }
            return ddlMonthList;
        }

        public static DropDownList fillOrganizationName(DropDownList drpOrganizationName)
        {
            DataTable organizationNames = (new trnsProductionDetailBLL()).getOrganizationNames();
            if (organizationNames != null)
            {
                drpOrganizationName.DataSource = organizationNames;
                drpOrganizationName.DataTextField = organizationNames.Columns["organization_name"].ToString();
                drpOrganizationName.DataValueField = organizationNames.Columns["Organization_id"].ToString();
                drpOrganizationName.DataBind();
            }
            return drpOrganizationName;
        }

        public static DropDownList FillPropertyTypeDropDownList(DropDownList drpPorpertyType, short propertyMasterID)
        {
            DataTable propertyTypeByMasterID = (new SetItemPropertyBLL()).GetPropertyTypeByMasterID(propertyMasterID);
            if (propertyTypeByMasterID.Rows.Count <= 0)
            {
                drpPorpertyType.Items.Clear();
            }
            else
            {
                drpPorpertyType.DataSource = propertyTypeByMasterID;
                drpPorpertyType.DataTextField = propertyTypeByMasterID.Columns["CODE_NAME"].ToString();
                drpPorpertyType.DataValueField = propertyTypeByMasterID.Columns["CODE_ID_D"].ToString();
                drpPorpertyType.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "0");
            drpPorpertyType.Items.Insert(0, listItem);
            return drpPorpertyType;
        }

        public static DropDownList FillPropertyTypeDropDownListBandRoll(DropDownList drpPorpertyType, short propertyMasterID, short propertyDetailID)
        {
            DataTable propertyTypesByMasterIDDetailIdBandroll = (new SetItemPropertyBLL()).GetPropertyTypesByMasterIDDetailIdBandroll(propertyMasterID, propertyDetailID);
            if (propertyTypesByMasterIDDetailIdBandroll.Rows.Count <= 0)
            {
                drpPorpertyType.Items.Clear();
            }
            else
            {
                drpPorpertyType.DataSource = propertyTypesByMasterIDDetailIdBandroll;
                drpPorpertyType.DataTextField = propertyTypesByMasterIDDetailIdBandroll.Columns["property_name"].ToString();
                drpPorpertyType.DataValueField = propertyTypesByMasterIDDetailIdBandroll.Columns["property_id"].ToString();
                drpPorpertyType.DataBind();
            }
            ListItem listItem = new ListItem("---SELECT---", "-99");
            drpPorpertyType.Items.Insert(0, listItem);
            return drpPorpertyType;
        }

        public static DropDownList fillSubCategoryParameter(DropDownList drpCategory, int item_id)
        {
            DataSet subCategoryWithItemWithParam = (new PriceDeclaretionBLL()).GetSubCategoryWithItemWithParam(item_id);
            if (subCategoryWithItemWithParam != null)
            {
                drpCategory.DataSource = subCategoryWithItemWithParam;
                drpCategory.DataTextField = subCategoryWithItemWithParam.Tables[0].Columns["category_name"].ToString();
                drpCategory.DataValueField = subCategoryWithItemWithParam.Tables[0].Columns["category_id"].ToString();
                drpCategory.DataBind();
            }
            return drpCategory;
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

        public static DropDownList fillUnit(DropDownList drpUnit, int measurementID)
        {
            DataSet allUnitByMeasurementType = (new UnitBLL()).getAllUnitByMeasurementType(measurementID);
            if (allUnitByMeasurementType != null)
            {
                drpUnit.DataSource = allUnitByMeasurementType;
                drpUnit.DataTextField = allUnitByMeasurementType.Tables[0].Columns["UNIT_NAME"].ToString();
                drpUnit.DataValueField = allUnitByMeasurementType.Tables[0].Columns["UNIT_ID"].ToString();
                drpUnit.DataBind();
            }
            return drpUnit;
        }

        public static DropDownList fillUnitTo(DropDownList drpUnitFrom, int measurementID, int unitID)
        {
            DataSet allUnitExceptSelectedUnit = (new UnitBLL()).GetAllUnitExceptSelectedUnit(measurementID, unitID);
            if (allUnitExceptSelectedUnit != null)
            {
                drpUnitFrom.DataSource = allUnitExceptSelectedUnit;
                drpUnitFrom.DataTextField = allUnitExceptSelectedUnit.Tables[0].Columns["UNIT_NAME"].ToString();
                drpUnitFrom.DataValueField = allUnitExceptSelectedUnit.Tables[0].Columns["UNIT_ID"].ToString();
                drpUnitFrom.DataBind();
            }
            return drpUnitFrom;
        }

        public static DropDownList fillUpazillaNameDropdownList(DropDownList drpUpzaillaName)
        {
            DataTable allUpazilaData = (new setUpazilaBLL()).getAllUpazilaData();
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

        public static DropDownList fillVehicleType(DropDownList ddlVehicleType)
        {
            DataSet dataSet = (new ChallanBLL()).fillVehicleType();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                ddlVehicleType.DataSource = dataSet;
                ddlVehicleType.DataTextField = dataSet.Tables[0].Columns["Code_name"].ToString();
                ddlVehicleType.DataValueField = dataSet.Tables[0].Columns["Code_id_d"].ToString();
                ddlVehicleType.DataBind();
            }
            return ddlVehicleType;
        }

        public static DropDownList fillYearList(DropDownList ddlYearList)
        {
            ddlYearList.Items.Add(new ListItem("Year", "Year"));
            ddlYearList.SelectedIndex = 0;
            for (int i = 2011; i <= Convert.ToInt32(DateTime.Now.Year + 5); i++)
            {
                ddlYearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            return ddlYearList;
        }

        public static DropDownList fillYearListTest(DropDownList ddlYearList)
        {
            ddlYearList.Items.Add(new ListItem("Year", "Year"));
            ddlYearList.SelectedIndex = 0;
            for (int i = 2011; i <= Convert.ToInt32(DateTime.Now.Year + 5); i++)
            {
                ddlYearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlYearList.SelectedValue = DateTime.Now.Year.ToString();
            }
            return ddlYearList;
        }

        public static DateTime GetFormattedDateMMDDYYYY(string ddMMYYYY)
        {
            string[] strArrays = ddMMYYYY.Split(new char[] { '/' });
            object[] timeOfDay = new object[] { strArrays[1], "/", strArrays[0], "/", strArrays[2], " ", null };
            timeOfDay[6] = DateTime.Now.TimeOfDay;
            string.Concat(timeOfDay);
            return Convert.ToDateTime(ddMMYYYY);
        }

        public static short GetLoggedEmployeeID()
        {
            short num = 0;
            try
            {
                num = Convert.ToInt16(HttpContext.Current.Session["EMPLOYEE_ID"]);
            }
            catch
            {
            }
            return num;
        }

        public static string GetLoggedEmployeeName()
        {
            string str = "";
            try
            {
                str = HttpContext.Current.Session["EMPLOYEE_NAME"].ToString();
            }
            catch
            {
            }
            return str;
        }

        public static string GetLoggedOrgAddress()
        {
            string str = "";
            try
            {
                str = HttpContext.Current.Session["ORGANIZATION_ADDRESS"].ToString();
            }
            catch
            {
            }
            return str;
        }

        public static string GetLoggedOrgBIN()
        {
            string str = "";
            try
            {
                str = HttpContext.Current.Session["ORGANIZATION_BIN"].ToString();
            }
            catch
            {
            }
            return str;
        }

        public static short GetLoggedOrgID()
        {
            short num = 0;
            try
            {
                num = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
            }
            catch
            {
            }
            return num;
        }

        public static string GetLoggedOrgName()
        {
            string str = "";
            try
            {
                str = HttpContext.Current.Session["ORGANIZATION_NAME"].ToString();
            }
            catch
            {
            }
            return str;
        }

        public static DateTime GetStandardDateFrom_ddMMyyyy(string ddMMyyyy)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.ParseExact(ddMMyyyy, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return dateTime;
        }

        public static DateTime GetStandardFormattedDate(string ddMMyy)
        {
            IFormatProvider cultureInfo = new CultureInfo("fr-Fr", true);
            DateTime dateTime = new DateTime();
            dateTime = DateTime.ParseExact(ddMMyy, "dd/MM/yy", cultureInfo, DateTimeStyles.NoCurrentDateDefault);
            return dateTime;
        }

        public static bool InsertErrorTrack(string errorDes, string className, string methodName)
        {
            DBUtility dBUtility = new DBUtility();
            DateTime today = DateTime.Today;
            int num = Convert.ToInt32(dBUtility.GetSingleValue("SELECT  nextval('error_track_id_seq')"));
            object[] objArray = new object[] { "INSERT INTO trns_error_tracking(error_track_id,error_description, class_name, method_name,error_generate_date) VALUES   (", num, ", '", errorDes, "','", className, "','", methodName, "',to_timestamp('", today.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
            return dBUtility.ExecuteDML(string.Concat(objArray));
        }

        public static bool InsertErrorTrackNew(string errorDes, string className, string methodName, int lineNumber)
        {
            DBUtility dBUtility = new DBUtility();
            DateTime today = DateTime.Today;
            int num = Convert.ToInt32(dBUtility.GetSingleValue("SELECT  nextval('error_track_id_seq')"));
            object[] objArray = new object[] { "INSERT INTO trns_error_tracking(error_track_id,error_description, class_name, method_name,line_number,error_generate_date) VALUES   (", num, ", '", errorDes, "','", className, "','", methodName, "',", lineNumber, ",to_timestamp('", today.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'))" };
            return dBUtility.ExecuteDML(string.Concat(objArray));
        }

        public static void LoginCheckForUser(string folderName, string pageName)
        {
            if (HttpContext.Current.Session["USER_ID"] == null)
            {
                string str = string.Concat("~/Login.aspx?returnUrl=~/", folderName, "/", pageName);
                HttpContext.Current.Server.Transfer(str);
            }
        }

        public static string ParseText(string inputValue)
        {
            return inputValue.Replace("'", "''");
        }

        public static string ReplaceQuotes(string inputValue)
        {
            return inputValue.Replace("'", "''");
        }

        public static DropDownList rptFillMonthList(DropDownList ddlMonthList)
        {
            ddlMonthList.Items.Add(new ListItem("Month", "Month"));
            ddlMonthList.SelectedIndex = 0;
            DateTime dateTime = Convert.ToDateTime("1/1/2000");
            for (int i = 0; i < 12; i++)
            {
                DateTime dateTime1 = dateTime.AddMonths(i);
                ddlMonthList.Items.Add(new ListItem(dateTime1.ToString("MMMM / yyyy"), dateTime1.ToString("MM/yyyy")));
            }
            return ddlMonthList;
        }
    }
}