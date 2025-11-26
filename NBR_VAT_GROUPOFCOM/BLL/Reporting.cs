using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Reporting
    {
        public Reporting()
        {
        }

        public static void ExportPanelToPDF(Panel tdReportInfo, string reportName)
        {
            try
            {
                reportName = string.Concat(reportName, ".pdf");
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("content-disposition", string.Concat("attachment;filename=", reportName));
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter stringWriter = new StringWriter();
                tdReportInfo.RenderControl(new HtmlTextWriter(stringWriter));
                string str = Regex.Replace(stringWriter.ToString(), "</?(a|A).*?>", "");
                string str1 = HttpContext.Current.Server.MapPath("~/Content/Default.css");
                string[] strArrays = new string[] { "<html><head><link href='", str1, "' rel='stylesheet' type=text/css /></head><body>", str, "</body></html>" };
                StringReader stringReader = new StringReader(string.Concat(strArrays));
                Document document = new Document(PageSize.LEGAL, 10f, 10f, 10f, 0f);
                HTMLWorker hTMLWorker = new HTMLWorker(document);
                PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                document.Open();
                hTMLWorker.Parse(stringReader);
                document.Close();
                HttpContext.Current.Response.Write(document);
                HttpContext.Current.Response.End();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}