using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class PrintHelper
    {
        public PrintHelper()
        {
        }

        public static void PrintWebControl(Control ctrl)
        {
            PrintHelper.PrintWebControl(ctrl, string.Empty);
        }

        public static void PrintWebControl(Control ctrl, string Script)
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            if (ctrl is WebControl)
            {
                Unit unit = new Unit(100, UnitType.Percentage);
                ((WebControl)ctrl).Width = unit;
            }
            Page page = new Page()
            {
                EnableEventValidation = false
            };
            if (Script != string.Empty)
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "PrintJavaScript", Script);
            }
            HtmlForm htmlForm = new HtmlForm();
            page.Controls.Add(htmlForm);
            htmlForm.Attributes.Add("runat", "server");
            htmlForm.Controls.Add(ctrl);
            page.DesignerInitialize();
            page.RenderControl(htmlTextWriter);
            string str = stringWriter.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }
    }
}

