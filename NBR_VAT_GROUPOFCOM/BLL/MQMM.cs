using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class MQMM
    {
        public MQMM()
        {
        }

        public static void CheckNBR()
        {
            if (Convert.ToString(HttpContext.Current.Session["LOGIN_ID"]).Trim() != "NBR")
            {
                HttpContext.Current.Server.Transfer("~/Login.aspx?");
            }
        }

        public static void ExportToExcel(string XmlName)
        {
            try
            {
                XmlName = string.Concat(XmlName, ".xml");
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.AddHeader("content-disposition", string.Concat("attachment;filename=", XmlName));
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = "application/xml";
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                HttpContext.Current.Response.Output.Write(stringWriter.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        public static DropDownList fillPurchaseChallanNoBySaleParty(DropDownList ddlSPurchaseChallanNo, int intSalePartyId)
        {
            DataSet challan = (new PurchaseReturnBLL()).getChallan(intSalePartyId);
            if (challan != null && challan.Tables[0].Rows.Count > 0)
            {
                ddlSPurchaseChallanNo.DataSource = challan;
                ddlSPurchaseChallanNo.DataTextField = challan.Tables[0].Columns["challanNoDate"].ToString();
                ddlSPurchaseChallanNo.DataValueField = challan.Tables[0].Columns["Challan_id"].ToString();
                ddlSPurchaseChallanNo.DataBind();
                ListItem listItem = new ListItem("-- Select ---", "-99");
                ddlSPurchaseChallanNo.Items.Insert(0, listItem);
            }
            return ddlSPurchaseChallanNo;
        }

        public static DropDownList fillPurchaseReturnOrg(DropDownList ddlPurchaseReturnOrg)
        {
            DataSet purchaseReturnOrg = (new PurchaseReturnBLL()).getPurchaseReturnOrg();
            if (purchaseReturnOrg != null && purchaseReturnOrg.Tables[0].Rows.Count > 0)
            {
                ddlPurchaseReturnOrg.DataSource = purchaseReturnOrg;
                ddlPurchaseReturnOrg.DataTextField = purchaseReturnOrg.Tables[0].Columns["organization_name"].ToString();
                ddlPurchaseReturnOrg.DataValueField = purchaseReturnOrg.Tables[0].Columns["Organization_id"].ToString();
                ddlPurchaseReturnOrg.DataBind();
            }
            return ddlPurchaseReturnOrg;
        }

        public static DropDownList fillSaleParty(DropDownList ddlSaleParty, int intOrgId)
        {
            DataSet salePartyNameByOrg = (new PurchaseReturnBLL()).getSalePartyNameByOrg(intOrgId);
            if (salePartyNameByOrg != null && salePartyNameByOrg.Tables[0].Rows.Count > 0)
            {
                ddlSaleParty.DataSource = salePartyNameByOrg;
                ddlSaleParty.DataTextField = salePartyNameByOrg.Tables[0].Columns["party_name"].ToString();
                ddlSaleParty.DataValueField = salePartyNameByOrg.Tables[0].Columns["Party_id"].ToString();
                ddlSaleParty.DataBind();
                ListItem listItem = new ListItem("-- Select ---", "-99");
                ddlSaleParty.Items.Insert(0, listItem);
            }
            return ddlSaleParty;
        }

        public static void LoginCheckForUser(string folderName, string pageName)
        {
            if (HttpContext.Current.Session["USER_ID"] == null)
            {
                string str = string.Concat("~/Login.aspx?returnUrl=~/", folderName, "/", pageName);
                HttpContext.Current.Server.Transfer(str);
            }
        }

        public static void LoginCheckForUser()
        {
            if (HttpContext.Current.Session["EMPLOYEE_ID"] == null)
            {
                HttpContext.Current.Server.Transfer("~/Login.aspx?");
            }
        }

        public static string ParseText(string strInputValue)
        {
            return strInputValue.Replace("'", "''");
        }
    }
}