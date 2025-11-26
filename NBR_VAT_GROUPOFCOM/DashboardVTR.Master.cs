using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM
{
    public partial class DashboardVTR : MasterPage
    {
        protected ContentPlaceHolder HeadContent;

        protected Label orgname;

        protected HyperLink HyperLink1;

        protected HyperLink HyperLink9;

        protected HyperLink HyperLink2;

        protected HyperLink HyperLink3;

        protected HyperLink HyperLink4;

        protected HyperLink HyperLink6;

        protected HyperLink HyperLink5;

        protected HyperLink HyperLink7;

        protected HyperLink HyperLink8;

        protected HtmlGenericControl lblnotification;

        protected HtmlGenericControl lblnot;

        protected Label lblEmployeeName;

        protected HyperLink lnkLogout;

        protected HyperLink lnkSwitchAccount;

        protected HyperLink chgPassword;

        protected ToolkitScriptManager ToolkitScriptManager1;

        protected ContentPlaceHolder MainContent;

        private ChallanBLL objBLL = new ChallanBLL();

        protected global_asax ApplicationInstance
        {
            get
            {
                return (global_asax)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public DashboardVTR()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if (base.Session["LOGIN_ID"].ToString() == "root")
            //    {
            //        this.HyperLink9.Visible = true;
            //    }
            //    string str = "";
            //    int num = Convert.ToInt32(base.Session["ORGBRANCHID"].ToString());
            //    int num1 = Convert.ToInt32(base.Session["ORGANIZATION_ID"].ToString());
            //    short num2 = Convert.ToInt16(base.Session["EMPLOYEE_ID"]);
            //    string str1 = base.Session["organization_name"].ToString();
            //    if (Utilities.GetMasterOrgInfo()[1] != "S")
            //    {
            //        this.lnkSwitchAccount.Visible = true;
            //    }
            //    else
            //    {
            //        this.lnkSwitchAccount.Visible = false;
            //    }
            //    DataTable purchaseInfoByAPI = this.objBLL.GetPurchaseInfoByAPI();
            //    int num3 = 0;
            //    if (purchaseInfoByAPI.Rows.Count > 0)
            //    {
            //        num3 = Convert.ToInt16(purchaseInfoByAPI.Rows[0]["challan"]);
            //        this.lblnotification.InnerText = purchaseInfoByAPI.Rows[0]["challan"].ToString();
            //        this.lblnot.InnerText = string.Concat("You have ", num3, " Purchase Challan to Receive.");
            //    }
            //    DataTable branchInformationFormanagerN = this.objBLL.GetBranchInformationFormanagerN(num1, num2, num);
            //    if (branchInformationFormanagerN.Rows.Count > 0)
            //    {
            //        str = branchInformationFormanagerN.Rows[0]["branch_unit_name"].ToString();
            //    }
            //    this.orgname.Text = string.Concat(str1, ",", str);
            //    if (num2 >= 1)
            //    {
            //        UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
            //        DataSet dataSet = userPermissionBLL.CheckAdminUser(num2);
            //        this.lblEmployeeName.Text = base.Session["EMPLOYEE_NAME"].ToString();
            //        base.Request.ApplicationPath.ToString();
            //        string str2 = base.Request.RawUrl.ToString();
            //        string str3 = "";
            //        if (!base.Request.QueryString.HasKeys())
            //        {
            //            str3 = str2;
            //        }
            //        else
            //        {
            //            char[] chrArray = new char[] { '?' };
            //            str3 = str2.Split(chrArray)[0];
            //        }
            //        string str4 = "/NBR_VAT";
            //        if (str3 != "Root")
            //        {
            //            str3 = string.Concat(str4, str3);
            //        }
            //        DataSet dataSet1 = userPermissionBLL.CheckUserAuthentication(num2, str3);
            //        //if (Convert.ToBoolean(base.Session["PRODUCT_ACTIVE"].ToString()))
            //        //{
            //        //    this.HyperLink7.Visible = false;
            //        //}
            //        if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["user_level"].ToString()) == 1)
            //        {
            //            if (str3 == "/NBR_VAT/Production.aspx" || str3 == "/NBR_VAT/Reports.aspx" || str3 == "/NBR_VAT/UI/Admin/VDS_Monitoring.aspx" || str3 == "/NBR_VAT/UI/Admin/Rebate_Monitoring.aspx" || str3 == "/NBR_VAT/UI/Admin/TreasuryChallan_6.aspx" || str3 == "/NBR_VAT/UI/Admin/Import_AIT_Refund_4.1.aspx" || str3 == "/NBR_VAT/UI/Admin/SupplDutyAdjApp_7.1.aspx" || str3 == "/NBR_VAT/UI/Item/PriceDeclaration_M1.aspx")
            //            {
            //                // base.Response.Redirect("/NoAccess.aspx", false);
            //                // return;
            //            }
            //        }
            //        else if (!(str3 == "/NBR_VAT/APIPurchase.aspx") && !(str3 == "/NBR_VAT/Default.aspx") && !(str3 == "/NBR_VAT/Admin_Dashboards.aspx") && !(str3 == "/NBR_VAT/Admin_Dashboard_Detal.aspx") && dataSet1.Tables[0].Rows.Count == 0)
            //        {
            //            // base.Response.Redirect("/NoAccess.aspx", false);
            //            //  return;
            //        }
            //    }
            //    else
            //    {
            //        base.Response.Redirect("~/LogIns.aspx");
            //    }
            //}
            //catch (Exception exception1)
            //{
            //    Exception exception = exception1;
            //    base.Response.Redirect("~/LogIns.aspx");
            //    exception.ToString();
            //}
        }
    }
}