using System;
using System.IO;
using System.Net;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class APIController
    {
        public APIController()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("URL");
            httpWebRequest.ContentType = "text/plain;charset=UTF-8";
            httpWebRequest.Accept = "text/plain;charset=UTF-8";
            httpWebRequest.Method = "POST";
            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.WriteLine("Hello");
            }
            using (StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
    }
}
