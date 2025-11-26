using AjaxControlToolkit;
using ASP;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM
{
    public partial class LoginMasterPage :  MasterPage
    {
        protected ContentPlaceHolder head;

        protected ToolkitScriptManager ToolkitScriptManager1;

        protected ContentPlaceHolder ContentPlaceHolder1;

        protected HtmlForm form1;

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

        public LoginMasterPage()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}