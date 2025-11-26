using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM
{
    public partial class KGCDashboard : Page, IRequiresSessionState
    {
        private ItemBLL item = new ItemBLL();


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

        public KGCDashboard()
        {
        }

        private void GetChartTypes()
        {
            foreach (int value in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem listItem = new ListItem(Enum.GetName(typeof(SeriesChartType), value), value.ToString());
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            //NBR_VAT_GROUPOFCOM.BLL.MQMM.LoginCheckForUser();
            //  if (!base.IsPostBack)
            //  {
            //      this.GetChartTypes();
            //      this.LoadService();
            //      this.LoadGoods();
            //  }

            // this.LoadService();
        }
    }
}