using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;


namespace NBR_VAT_GROUPOFCOM
{
    public class Global : HttpApplication
    {
        private static bool __initialized;

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)base.Context.Profile;
            }
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            String fullOrigionalpath = Request.Url.ToString();
            String[] sElements = fullOrigionalpath.Split('/');
            String[] sFilePath = sElements[sElements.Length - 1].Split('.');

            if (!fullOrigionalpath.Contains(".aspx") && sFilePath.Length == 1)
            {
                if (!string.IsNullOrEmpty(sFilePath[0].Trim()))
                    Context.RewritePath(sFilePath[0] + ".aspx");
            }
        }

        [DebuggerNonUserCode]
        public Global()
        {
            if (!Global.__initialized)
            {
                Global.__initialized = true;
            }
        }

        private void Application_End(object sender, EventArgs e)
        {
            base.Application["TotalOnlineUsers"] = 0;
        }

        private void Application_Error(object sender, EventArgs e)
        {
        }

        private void Application_Start(object sender, EventArgs e)
        {
            base.Application["TotalOnlineUsers"] = 0;
        }

        private void Session_End(object sender, EventArgs e)
        {
            base.Application.Lock();
            base.Application["TotalOnlineUsers"] = (int)base.Application["TotalOnlineUsers"] - 1;
            base.Application.UnLock();
        }

        private void Session_Start(object sender, EventArgs e)
        {
            base.Session["TEST"] = "MOHI";
            base.Application.Lock();
            base.Application["TotalOnlineUsers"] = (int)base.Application["TotalOnlineUsers"] + 1;
            base.Application.UnLock();
        }
    }

}
