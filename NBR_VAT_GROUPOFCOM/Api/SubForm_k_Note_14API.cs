using NBR_VAT_GROUPOFCOM.ModelVW;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace NBR_VAT_GROUPOFCOM.Api
{
    public class SubForm_k_Note_14API
    {
        public static List<SubForm_k_Note_14Vw> LoadMukhak(string start_date, string end_date)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-SubForm_k_Note_14");
                //  SalesDetailObj sales = new SalesDetailObj();
                // var postData = "company_id=" + company_id;
                var postData = "&start_date=" + start_date;
                postData += "&end_date=" + end_date;


                var data2 = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data2.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data2, 0, data2.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;

                var salesList = serializer.Deserialize<List<SubForm_k_Note_14Vw>>(responseString);




                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }







            //  List<SalesDetailView> salesObjectList = new List<SalesDetailView>();
        }
    }
}