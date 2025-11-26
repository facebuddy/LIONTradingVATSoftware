using System;
using ASP;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.UserControls
{
    public partial class Items : UserControl
    {
        protected ImageButton btnClose;

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

        public Items()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}