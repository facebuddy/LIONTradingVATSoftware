using System;
using System.IO;
using System.Xml.Linq;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ReallySimpleLog
    {
        private static string m_baseDir;

        static ReallySimpleLog()
        {
            ReallySimpleLog.m_baseDir = "C:\\Inetpub\\wwwroot\\NBR-POS\\Log\\";
        }

        public ReallySimpleLog()
        {
        }

        public static string GetFilenameYYYMMDD(string suffix, string extension)
        {
            DateTime now = DateTime.Now;
            return string.Concat(now.ToString("yyyy_MM_dd"), suffix, extension);
        }

        public static void WriteLog(string message)
        {
            try
            {
                string str = string.Concat(ReallySimpleLog.m_baseDir, ReallySimpleLog.GetFilenameYYYMMDD("_LOG", ".log"));
                StreamWriter streamWriter = new StreamWriter(str, true);
                XName xName = "logEntry";
                object[] xElement = new object[2];
                XName xName1 = "Date";
                DateTime now = DateTime.Now;
                xElement[0] = new XElement(xName1, now.ToString());
                xElement[1] = new XElement("Message", message);
                streamWriter.WriteLine(new XElement(xName, xElement));
                streamWriter.Close();
            }
            catch (Exception exception)
            {
            }
        }

        public static void WriteLog(Exception ex)
        {
            try
            {
                string str = string.Concat(ReallySimpleLog.m_baseDir, ReallySimpleLog.GetFilenameYYYMMDD("_LOG", ".log"));
                StreamWriter streamWriter = new StreamWriter(str, true);
                XName xName = "logEntry";
                object[] xElement = new object[2];
                XName xName1 = "Date";
                DateTime now = DateTime.Now;
                xElement[0] = new XElement(xName1, now.ToString());
                XName xName2 = "Exception";
                object[] objArray = new object[] { new XElement("Source", ex.Source), new XElement("Message", ex.Message), new XElement("Stack", ex.StackTrace) };
                xElement[1] = new XElement(xName2, objArray);
                XElement xElement1 = new XElement(xName, xElement);
                if (ex.InnerException != null)
                {
                    XElement xElement2 = xElement1.Element("Exception");
                    XName xName3 = "InnerException";
                    object[] objArray1 = new object[] { new XElement("Source", ex.InnerException.Source), new XElement("Message", ex.InnerException.Message), new XElement("Stack", ex.InnerException.StackTrace) };
                    xElement2.Add(new XElement(xName3, objArray1));
                }
                streamWriter.WriteLine(xElement1);
                streamWriter.Close();
            }
            catch (Exception exception)
            {
            }
        }
    }
}

