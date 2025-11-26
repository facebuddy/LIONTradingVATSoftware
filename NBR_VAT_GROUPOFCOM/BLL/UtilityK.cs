using System;
using System.Data;
using System.Management;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UtilityK
    {
        public UtilityK()
        {
        }

        public static bool CheckConnection()
        {
            if (UtilityK.CheckForInternetConnection())
            {
                return true;
            }
            return false;
        }

        public static bool CheckForInternetConnection()
        {
            bool flag;
            try
            {
                Ping ping = new Ping();
                string str = "google.com";
                byte[] numArray = new byte[32];
                PingReply pingReply = ping.Send(str, 1000, numArray, new PingOptions());
                if (pingReply.Status != IPStatus.Success)
                {
                    flag = (pingReply.Status != IPStatus.TimedOut ? false : false);
                }
                else
                {
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                flag = false;
            }
            return flag;
        }

        public static DropDownList fillCategoryDropDownListByPrdType(DropDownList drpItemCategory, string productType)
        {
            DataSet categoryByProductType = (new AddItemBLL()).getCategoryByProductType(productType);
            if (categoryByProductType != null && categoryByProductType.Tables[0].Rows.Count > 0)
            {
                drpItemCategory.DataSource = categoryByProductType;
                drpItemCategory.DataTextField = categoryByProductType.Tables[0].Columns["CATEGORY_NAME"].ToString();
                drpItemCategory.DataValueField = categoryByProductType.Tables[0].Columns["CATEGORY_ID"].ToString();
                drpItemCategory.DataBind();
            }
            return drpItemCategory;
        }

        public static DropDownList fillChallanDiscardReasonList(DropDownList drpChallanDiscardReason)
        {
            DataTable challanPgeDiscardReason = (new CodeBLL()).GetChallanPgeDiscardReason();
            if (challanPgeDiscardReason != null && challanPgeDiscardReason.Rows.Count > 0)
            {
                drpChallanDiscardReason.DataSource = challanPgeDiscardReason;
                drpChallanDiscardReason.DataTextField = challanPgeDiscardReason.Columns["code_short_name"].ToString();
                drpChallanDiscardReason.DataValueField = challanPgeDiscardReason.Columns["code_id_d"].ToString();
                drpChallanDiscardReason.DataBind();
            }
            return drpChallanDiscardReason;
        }

        public static DropDownList fillItemCategoryDropDownList(DropDownList drpItemCategory)
        {
            DataSet orgWiseAllItemCategory = (new AddItemBLL()).getOrgWiseAllItemCategory();
            if (orgWiseAllItemCategory != null && orgWiseAllItemCategory.Tables[0].Rows.Count > 0)
            {
                drpItemCategory.DataSource = orgWiseAllItemCategory;
                drpItemCategory.DataTextField = orgWiseAllItemCategory.Tables[0].Columns["CATEGORY_NAME"].ToString();
                drpItemCategory.DataValueField = orgWiseAllItemCategory.Tables[0].Columns["CATEGORY_ID"].ToString();
                drpItemCategory.DataBind();
            }
            return drpItemCategory;
        }

        public static DropDownList fillItemCategoryDropDownListByType(DropDownList drpItemCategory, string catType)
        {
            DataSet categoryByType = (new AddItemBLL()).getCategoryByType(catType);
            if (categoryByType != null && categoryByType.Tables[0].Rows.Count > 0)
            {
                drpItemCategory.DataSource = categoryByType;
                drpItemCategory.DataTextField = categoryByType.Tables[0].Columns["CATEGORY_NAME"].ToString();
                drpItemCategory.DataValueField = categoryByType.Tables[0].Columns["CATEGORY_ID"].ToString();
                drpItemCategory.DataBind();
            }
            return drpItemCategory;
        }

        public static DropDownList fillItemPropertyByPropertyType(DropDownList drpPropertyRequired, short propertyTypeD)
        {
            DataSet itemPropertyValues = (new AddItemBLL()).getItemPropertyValues(propertyTypeD);
            DataTable item = itemPropertyValues.Tables[0];
            drpPropertyRequired.ClearSelection();
            drpPropertyRequired.DataSource = item;
            drpPropertyRequired.DataTextField = item.Columns["PROPERTY_CODE"].ToString();
            drpPropertyRequired.DataValueField = item.Columns["PROPERTY_ID"].ToString();
            drpPropertyRequired.DataBind();
            return drpPropertyRequired;
        }

        public static DropDownList fillItemSubCategoryDropDownList(DropDownList drpItemCategory)
        {
            DataSet allItemSubCategory = (new AddItemBLL()).getAllItemSubCategory();
            if (allItemSubCategory != null && allItemSubCategory.Tables[0].Rows.Count > 0)
            {
                drpItemCategory.DataSource = allItemSubCategory;
                drpItemCategory.DataTextField = allItemSubCategory.Tables[0].Columns["CATEGORY_NAME"].ToString();
                drpItemCategory.DataValueField = allItemSubCategory.Tables[0].Columns["CATEGORY_ID"].ToString();
                drpItemCategory.DataBind();
            }
            return drpItemCategory;
        }

        public static DropDownList fillOrgUnitDropDownList(DropDownList drpOrgUnit, int organizationID)
        {
            DataTable orgUnitByOrgID = (new ChallanBLL()).GetOrgUnitByOrgID(organizationID);
            if (orgUnitByOrgID != null && orgUnitByOrgID.Rows.Count > 0)
            {
                drpOrgUnit.DataSource = orgUnitByOrgID;
                drpOrgUnit.DataTextField = orgUnitByOrgID.Columns["unit_name"].ToString();
                drpOrgUnit.DataValueField = orgUnitByOrgID.Columns["sub_unit_id"].ToString();
                drpOrgUnit.DataBind();
            }
            return drpOrgUnit;
        }

        public static DropDownList fillPartyNameDropDownList(DropDownList drpParty)
        {
            DataTable allPartyInfo = (new ChallanBLL()).GetAllPartyInfo();
            if (allPartyInfo != null && allPartyInfo.Rows.Count > 0)
            {
                drpParty.DataSource = allPartyInfo;
                drpParty.DataTextField = allPartyInfo.Columns["party_name"].ToString();
                drpParty.DataValueField = allPartyInfo.Columns["Party_id"].ToString();
                drpParty.DataBind();
            }
            return drpParty;
        }

        public static DropDownList fillSubCatDropDownListByProdType(DropDownList drpItemCategory, DropDownList drpSubCategory, string productType)
        {
            SetItemCategoryDAO setItemCategoryDAO = new SetItemCategoryDAO();
            AddItemBLL addItemBLL = new AddItemBLL();
            if (!string.IsNullOrEmpty(drpItemCategory.SelectedValue))
            {
                setItemCategoryDAO.CategoryID = Convert.ToInt32(drpItemCategory.SelectedValue);
                DataSet subCategoryByProdType = addItemBLL.getSubCategoryByProdType(setItemCategoryDAO, productType);
                if (subCategoryByProdType == null || subCategoryByProdType.Tables[0].Rows.Count <= 0)
                {
                    drpSubCategory.DataSource = null;
                    drpSubCategory.Items.Clear();
                }
                else
                {
                    drpSubCategory.DataSource = subCategoryByProdType;
                    drpSubCategory.DataTextField = subCategoryByProdType.Tables[0].Columns["CATEGORY_NAME"].ToString();
                    drpSubCategory.DataValueField = subCategoryByProdType.Tables[0].Columns["CATEGORY_ID"].ToString();
                    drpSubCategory.DataBind();
                }
            }
            return drpSubCategory;
        }

        public static DropDownList fillSubCategoryByCatDropDownList(DropDownList drpItemCategory, DropDownList drpSubCategory)
        {
            SetItemCategoryDAO setItemCategoryDAO = new SetItemCategoryDAO();
            AddItemBLL addItemBLL = new AddItemBLL();
            if (!string.IsNullOrEmpty(drpItemCategory.SelectedValue))
            {
                setItemCategoryDAO.CategoryID = Convert.ToInt32(drpItemCategory.SelectedValue);
                DataSet subCategoryByCat = addItemBLL.getSubCategoryByCat(setItemCategoryDAO);
                if (subCategoryByCat == null || subCategoryByCat.Tables[0].Rows.Count <= 0)
                {
                    drpSubCategory.DataSource = null;
                    drpSubCategory.Items.Clear();
                }
                else
                {
                    drpSubCategory.DataSource = subCategoryByCat;
                    drpSubCategory.DataTextField = subCategoryByCat.Tables[0].Columns["CATEGORY_NAME"].ToString();
                    drpSubCategory.DataValueField = subCategoryByCat.Tables[0].Columns["CATEGORY_ID"].ToString();
                    drpSubCategory.DataBind();
                }
            }
            return drpSubCategory;
        }

        public static DropDownList fillVehicleTypeDropDownList(DropDownList drpVehicleType)
        {
            DataSet dataSet = (new ChallanBLL()).fillVehicleType();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                drpVehicleType.DataSource = dataSet;
                drpVehicleType.DataTextField = dataSet.Tables[0].Columns["code_name"].ToString();
                drpVehicleType.DataValueField = dataSet.Tables[0].Columns["code_id_d"].ToString();
                drpVehicleType.DataBind();
            }
            return drpVehicleType;
        }

        public static string getMacId()
        {
            return UtilityK.identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }

        private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string str = "";
            foreach (ManagementObject instance in (new ManagementClass(wmiClass)).GetInstances())
            {
                if (!(instance[wmiMustBeTrue].ToString() == "True") || !(str == ""))
                {
                    continue;
                }
                try
                {
                    str = instance[wmiProperty].ToString();
                    break;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return str;
        }
    }
}