using NBR_VAT_GROUPOFCOM.Model;
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
    public class  MushakAPI
    {
        public static List<SubForm_k> LoadMukhak(string start_date, string end_date)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-SubForm_k");
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

                var salesList = serializer.Deserialize<List<SubForm_k>>(responseString);




                return salesList;
            }

         
            
            catch (Exception exception)
            {
                return null;
            }







            //  List<SalesDetailView> salesObjectList = new List<SalesDetailView>();
        }




        public static List<SubForm_k_Note_14Vw> SubForm_k_Note_14(string start_date, string end_date)
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



        public static List<InvoiceVw> getInvoceList(string start_date, string end_date)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-invoicelist");
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

                var salesList = serializer.Deserialize<List<InvoiceVw>>(responseString);




                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }



            //  List<SalesDetailView> salesObjectList = new List<SalesDetailView>();
        }







        public static List<Subform_Note_31Vw> Subform_Note_31API(string start_date, string end_date)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-Subform_Note_31CreditNoteReturn");

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

                var salesList = serializer.Deserialize<List<Subform_Note_31Vw>>(responseString);




                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }

        }





        public static List<BikroyChalanAboveLakh> SubForm_k_Note_14Above2Lakh(string start_date, string end_date)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-SubForm_k_Note_14Lakh");
   
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

                var salesList = serializer.Deserialize<List<BikroyChalanAboveLakh>>(responseString);




                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }







            //  List<SalesDetailView> salesObjectList = new List<SalesDetailView>();
        }


        public static List<SalesChalanAboveLakh> SubForm_k_Note_14SalesAbove2Lakh(string start_date, string end_date)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-SubForm_k_Note_14SalesLakh");

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

                var salesList = serializer.Deserialize<List<SalesChalanAboveLakh>>(responseString);




                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }

            //  List<SalesDetailView> salesObjectList = new List<SalesDetailView>();
        }



        public static List<VatSixOne> VATsixOne(string start_date, string end_date,int product_id)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-mushoksixone-report");

                var postData = "&start_date=" + start_date;
                postData += "&end_date=" + end_date;
                postData += "&product_id=" + product_id;


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

                var salesList = serializer.Deserialize<List<VatSixOne>>(responseString);




                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }

            //  List<SalesDetailView> salesObjectList = new List<SalesDetailView>();
        }



        public static VatSixOneObj GetVatSixOneList(string start_date, string end_date, int product_id)
        {
            var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-mushoksixone-report");
            VatSixOneObj ledger = new VatSixOneObj();

            var postData = "start_date=" + start_date;
            postData += "&end_date=" + end_date;
            postData += "&product_id=" + product_id;
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


            var ledgerList = (new JavaScriptSerializer()).Deserialize<List<VatSixOneObj>>(responseString);


            List<VatSixOne> ledgerObjectList = new List<VatSixOne>();

            // r = t.NewRow();

            int i = 0;
            int closing = 0;
            foreach (var item in ledgerList.FirstOrDefault().vatList)
            {
                VatSixOne obj = new VatSixOne();
                if (i == 0)
                {
                    obj.opening = ledgerList.FirstOrDefault().opening_balance;

                    obj.paromvikjer = obj.opening;
                    obj.prantikjet = obj.opening;
                    obj.product_name = item.product_name;
                    closing = obj.prantikjet;
                    obj.transaction_date = Convert.ToDateTime(start_date);
                    // obj.sale_date = new DateTime();
                    ledgerObjectList.Add(obj);
                    obj = new VatSixOne();

                    // r = t.NewRow();
                    obj.distributor_address = item.distributor_address;
                    obj.distributor_name = item.distributor_name;
                    obj.distributor_reg_number = item.distributor_reg_number;
                    obj.invoice_no = item.invoice_no;
                    obj.montobbo = item.montobbo;
                    obj.net_amount_without_mushok = item.net_amount_without_mushok;
                    obj.opening = closing;
                    // obj.openingjer = obj.opening + item.;
                    obj.paromvikjer = obj.opening + item.quantity_purchase;
                    obj.prantikjet = obj.opening - item.sale_quantity;
                    // obj.prantikjet = item.prantikjet;
                    if (item.Operationtype == "receive")
                    {
                        closing = obj.paromvikjer;
                        obj.prantikjet = obj.paromvikjer;

                    }
                    if (item.Operationtype == "sale")
                    {
                        closing = obj.prantikjet;
                        // obj.paromvikjer = closing;

                    }
                    if (item.Operationtype == "return")
                    {
                        closing = obj.paromvikjer;

                    }
                    // obj.opening = closing;

                    obj.product_name_biboron = item.product_name_biboron;
                    obj.purchase_date = item.purchase_date;
                    obj.purchase_netamount = item.purchase_netamount;
                    obj.purchase_rebate_amount = item.purchase_rebate_amount;
                    obj.purchase_rebate_percent = item.purchase_rebate_percent;
                    obj.purchase_total_amount = item.purchase_netamount;
                    obj.purchase_unit_price = item.purchase_unit_price;
                    obj.quantity_purchase = item.quantity_purchase;
                    obj.reference_number = item.reference_number;
                    obj.remarks = item.remarks;
                    obj.sale_amount = item.sale_amount;
                    obj.sale_date = item.sale_date;
                    obj.sale_quantity = item.sale_quantity;
                    obj.supplier_address = item.supplier_address;
                    obj.supplier_name = item.supplier_name;
                    obj.supplier_vat_reg_no = item.supplier_vat_reg_no;
                    obj.tracking_no = item.tracking_no;
                    obj.transaction_date = item.transaction_date;
                    obj.vat_amount = item.vat_amount;
                    obj.ctn_quantity_purchase = item.ctn_quantity_purchase;
                    // obj.net_amount = item.net_amount;
                    obj.product_name = item.product_name;


                    ledgerObjectList.Add(obj);

                }
                else
                {

                    // r = t.NewRow();
                    obj.distributor_address = item.distributor_address;
                    obj.distributor_name = item.distributor_name;
                    obj.distributor_reg_number = item.distributor_reg_number;
                    obj.invoice_no = item.invoice_no;
                    obj.montobbo = item.montobbo;
                    obj.net_amount_without_mushok = item.net_amount_without_mushok;
                    obj.opening = closing;
                    // obj.openingjer = obj.opening + item.;
                    obj.paromvikjer = obj.opening + item.quantity_purchase;
                    obj.prantikjet = obj.opening - item.sale_quantity;
                    // obj.prantikjet = item.prantikjet;
                    if (item.Operationtype == "receive")
                    {
                        obj.opening = closing;
                        closing = obj.paromvikjer;
                        obj.prantikjet = obj.paromvikjer;


                    }
                    if (item.Operationtype == "sale")
                    {
                        closing = obj.prantikjet;

                    }
                    if (item.Operationtype == "return")
                    {
                        closing = obj.paromvikjer;

                    }
                    // obj.opening = closing;
                    obj.product_name_biboron = item.product_name_biboron;
                    obj.purchase_date = item.purchase_date;
                    obj.purchase_netamount = item.purchase_netamount;
                    obj.purchase_rebate_amount = item.purchase_rebate_amount;
                    obj.purchase_rebate_percent = item.purchase_rebate_percent;
                    obj.purchase_total_amount = item.purchase_total_amount;
                    obj.purchase_unit_price = item.purchase_unit_price;
                    obj.quantity_purchase = item.quantity_purchase;
                    obj.reference_number = item.reference_number;
                    obj.remarks = item.remarks;
                    obj.sale_amount = item.sale_amount;
                    obj.sale_date = item.sale_date;
                    obj.sale_quantity = item.sale_quantity;
                    obj.supplier_address = item.supplier_address;
                    obj.supplier_name = item.supplier_name;
                    obj.supplier_vat_reg_no = item.supplier_vat_reg_no;
                    obj.tracking_no = item.tracking_no;
                    obj.transaction_date = item.transaction_date;
                    obj.vat_amount = item.vat_amount;
                    obj.ctn_quantity_purchase = item.ctn_quantity_purchase;
                    // obj.net_amount = item.net_amount;
                    obj.product_name = item.product_name;


                    ledgerObjectList.Add(obj);

                }
                i = i + 1;

            }

            ledger.vatList = ledgerObjectList;






            return ledger;




        }






        public static List<ReturnVw> MushakReturn(string start_date, string end_date)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-MushakSalesReturn");

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

                var salesList = serializer.Deserialize<List<ReturnVw>>(responseString);

                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }

        }




        public static List<ProductVw> IsProductExist(string name)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-MushakSalesReturn");

                var postData = "&name=" + name;
              //  postData += "&end_date=" + end_date;


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

                var salesList = serializer.Deserialize<List<ProductVw>>(responseString);

                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }

        }





        public static List<ProductVw> ProductList()
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-productlist");

                var postData = "";
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

                var salesList = serializer.Deserialize<List<ProductVw>>(responseString);

                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }

        }




        public static List<MushakReturnVw> MushakReturnData(string invoice_no)
        {


            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ServiceConfig.ServiceUrl + "get-MushakSalesReturnMushak6");

                var postData = "&invoice_no=" + invoice_no;
               // postData += "&end_date=" + end_date;


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

                var salesList = serializer.Deserialize<List<MushakReturnVw>>(responseString);

                return salesList;
            }



            catch (Exception exception)
            {
                return null;
            }

        }







    }
}