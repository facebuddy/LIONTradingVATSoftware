using System;
using System.Data;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrganizaitonInfo
    {
        public OrganizaitonInfo()
        {
        }

        public static DropDownList fillAllOrganizaiton(DropDownList ddlAllOrganizaiton)
        {
            DataSet allOrganization = (new CompanyBLL()).getAllOrganization();
            if (allOrganization != null && allOrganization.Tables[0].Rows.Count > 0)
            {
                ddlAllOrganizaiton.DataSource = allOrganization;
                ddlAllOrganizaiton.DataTextField = allOrganization.Tables[0].Columns["Organization_name"].ToString();
                ddlAllOrganizaiton.DataValueField = allOrganization.Tables[0].Columns["Organization_id"].ToString();
                ddlAllOrganizaiton.DataBind();
            }
            return ddlAllOrganizaiton;
        }

        public static DropDownList fillAllVATArea(DropDownList ddlAllVATArea)
        {
            DataSet allVATArea = (new CompanyBLL()).getAllVATArea();
            if (allVATArea != null && allVATArea.Tables[0].Rows.Count > 0)
            {
                ddlAllVATArea.DataSource = allVATArea;
                ddlAllVATArea.DataTextField = allVATArea.Tables[0].Columns["area_name"].ToString();
                ddlAllVATArea.DataValueField = allVATArea.Tables[0].Columns["area_id"].ToString();
                ddlAllVATArea.DataBind();
            }
            return ddlAllVATArea;
        }

        public static DropDownList fillAllVATAreaByCircleID(DropDownList ddlAllVATAreaByCircleID, int intVATCircleID)
        {
            DataSet allVATAreaByVATCircle = (new CompanyBLL()).getAllVATAreaByVATCircle(intVATCircleID);
            if (allVATAreaByVATCircle != null && allVATAreaByVATCircle.Tables[0].Rows.Count > 0)
            {
                ddlAllVATAreaByCircleID.DataSource = allVATAreaByVATCircle;
                ddlAllVATAreaByCircleID.DataTextField = allVATAreaByVATCircle.Tables[0].Columns["area_name"].ToString();
                ddlAllVATAreaByCircleID.DataValueField = allVATAreaByVATCircle.Tables[0].Columns["area_id"].ToString();
                ddlAllVATAreaByCircleID.DataBind();
            }
            return ddlAllVATAreaByCircleID;
        }

        public static DropDownList fillAllVATCirle(DropDownList ddlAllVATCirle)
        {
            DataSet allVATCircle = (new CompanyBLL()).getAllVATCircle();
            if (allVATCircle != null && allVATCircle.Tables[0].Rows.Count > 0)
            {
                ddlAllVATCirle.DataSource = allVATCircle;
                ddlAllVATCirle.DataTextField = allVATCircle.Tables[0].Columns["circle_name"].ToString();
                ddlAllVATCirle.DataValueField = allVATCircle.Tables[0].Columns["circle_id"].ToString();
                ddlAllVATCirle.DataBind();
            }
            return ddlAllVATCirle;
        }

        public static DropDownList fillAllVATCirleByDivisionID(DropDownList ddlAllVATCirleByCommissionerateID, int intVATDivisionID)
        {
            DataSet allVATCircleByVATDivision = (new CompanyBLL()).getAllVATCircleByVATDivision(intVATDivisionID);
            if (allVATCircleByVATDivision != null && allVATCircleByVATDivision.Tables[0].Rows.Count > 0)
            {
                ddlAllVATCirleByCommissionerateID.DataSource = allVATCircleByVATDivision;
                ddlAllVATCirleByCommissionerateID.DataTextField = allVATCircleByVATDivision.Tables[0].Columns["circle_name"].ToString();
                ddlAllVATCirleByCommissionerateID.DataValueField = allVATCircleByVATDivision.Tables[0].Columns["circle_id"].ToString();
                ddlAllVATCirleByCommissionerateID.DataBind();
            }
            return ddlAllVATCirleByCommissionerateID;
        }

        public static DropDownList fillAllVATCommissionerate(DropDownList ddlAllVATCommissionerate)
        {
            DataSet allVATCommissionerate = (new CompanyBLL()).getAllVATCommissionerate();
            if (allVATCommissionerate != null && allVATCommissionerate.Tables[0].Rows.Count > 0)
            {
                ddlAllVATCommissionerate.DataSource = allVATCommissionerate;
                ddlAllVATCommissionerate.DataTextField = allVATCommissionerate.Tables[0].Columns["comm_name"].ToString();
                ddlAllVATCommissionerate.DataValueField = allVATCommissionerate.Tables[0].Columns["comm_id"].ToString();
                ddlAllVATCommissionerate.DataBind();
            }
            ListItem listItem = new ListItem("----SELECT----", "-99");
            ddlAllVATCommissionerate.Items.Insert(0, listItem);
            return ddlAllVATCommissionerate;
        }

        public static DropDownList fillAllVATCommissionerateForReport(DropDownList ddlAllVATCommissionerate)
        {
            DataSet allVATCommissionerate = (new CompanyBLL()).getAllVATCommissionerate();
            if (allVATCommissionerate != null && allVATCommissionerate.Tables[0].Rows.Count > 0)
            {
                ddlAllVATCommissionerate.DataSource = allVATCommissionerate;
                ddlAllVATCommissionerate.DataTextField = allVATCommissionerate.Tables[0].Columns["comm_name"].ToString();
                ddlAllVATCommissionerate.DataValueField = allVATCommissionerate.Tables[0].Columns["comm_id"].ToString();
                ddlAllVATCommissionerate.DataBind();
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            ddlAllVATCommissionerate.Items.Insert(0, listItem);
            return ddlAllVATCommissionerate;
        }

        public static DropDownList fillAllVATDivision(DropDownList ddlAllVATDivision)
        {
            DataSet allVATDivision = (new CompanyBLL()).getAllVATDivision();
            if (allVATDivision != null && allVATDivision.Tables[0].Rows.Count > 0)
            {
                ddlAllVATDivision.DataSource = allVATDivision;
                ddlAllVATDivision.DataTextField = allVATDivision.Tables[0].Columns["division_name"].ToString();
                ddlAllVATDivision.DataValueField = allVATDivision.Tables[0].Columns["division_id"].ToString();
                ddlAllVATDivision.DataBind();
            }
            return ddlAllVATDivision;
        }

        public static DropDownList fillDDLAllCategoryName(DropDownList ddlAllCategoryName)
        {
            DataSet allCategoryNameForTaxValues = (new CategoryBLL()).getAllCategoryNameForTaxValues();
            if (allCategoryNameForTaxValues != null && allCategoryNameForTaxValues.Tables[0].Rows.Count > 0)
            {
                ddlAllCategoryName.DataSource = allCategoryNameForTaxValues;
                ddlAllCategoryName.DataTextField = allCategoryNameForTaxValues.Tables[0].Columns["category_name"].ToString();
                ddlAllCategoryName.DataValueField = allCategoryNameForTaxValues.Tables[0].Columns["category_id"].ToString();
                ddlAllCategoryName.DataBind();
            }
            ListItem listItem = new ListItem("-----SELECT-----", "-99");
            ddlAllCategoryName.Items.Insert(0, listItem);
            return ddlAllCategoryName;
        }

        public static DropDownList fillDDLAllCountryName(DropDownList ddlAllCountryName)
        {
            DataSet allCountry = (new SetCountryBLL()).getAllCountry();
            if (allCountry != null && allCountry.Tables[0].Rows.Count > 0)
            {
                ddlAllCountryName.DataSource = allCountry;
                ddlAllCountryName.DataTextField = allCountry.Tables[0].Columns["country_name"].ToString();
                ddlAllCountryName.DataValueField = allCountry.Tables[0].Columns["country_id"].ToString();
                ddlAllCountryName.DataBind();
            }
            return ddlAllCountryName;
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

        public static DropDownList fillDDLAllParentOrganizaiton(DropDownList ddlAllParentOrganizaiton)
        {
            DataSet allParentOrganization = (new CompanyBLL()).getAllParentOrganization();
            if (allParentOrganization != null && allParentOrganization.Tables[0].Rows.Count > 0)
            {
                ddlAllParentOrganizaiton.DataSource = allParentOrganization;
                ddlAllParentOrganizaiton.DataTextField = allParentOrganization.Tables[0].Columns["Organization_name"].ToString();
                ddlAllParentOrganizaiton.DataValueField = allParentOrganization.Tables[0].Columns["Organization_id"].ToString();
                ddlAllParentOrganizaiton.DataBind();
            }
            return ddlAllParentOrganizaiton;
        }

        public static DropDownList fillVATDivisionByVATCommissionerate(DropDownList ddlVATCommissionerateByVATDivision, int intVATCommissionerateID)
        {
            DataSet allVATDivisionByVATCommissionerate = (new CompanyBLL()).getAllVATDivisionByVATCommissionerate(intVATCommissionerateID);
            if (allVATDivisionByVATCommissionerate == null || allVATDivisionByVATCommissionerate.Tables[0].Rows.Count <= 0)
            {
                ddlVATCommissionerateByVATDivision.Items.Clear();
                ListItem listItem = new ListItem("----SELECT----", "-99");
                ddlVATCommissionerateByVATDivision.Items.Insert(0, listItem);
            }
            else
            {
                ddlVATCommissionerateByVATDivision.DataSource = allVATDivisionByVATCommissionerate;
                ddlVATCommissionerateByVATDivision.DataTextField = allVATDivisionByVATCommissionerate.Tables[0].Columns["division_name"].ToString();
                ddlVATCommissionerateByVATDivision.DataValueField = allVATDivisionByVATCommissionerate.Tables[0].Columns["division_id"].ToString();
                ddlVATCommissionerateByVATDivision.DataBind();
            }
            return ddlVATCommissionerateByVATDivision;
        }

        public static DataSet FullOrganizaitonInfo(DataSet dsFullOrganizaitonInfo, int intOrganizationID)
        {
            DataSet fullOrganizationInfo = (new CompanyBLL()).getFullOrganizationInfo(intOrganizationID);
            if (fullOrganizationInfo != null)
            {
                int count = fullOrganizationInfo.Tables[0].Rows.Count;
            }
            return dsFullOrganizaitonInfo;
        }
    }

}