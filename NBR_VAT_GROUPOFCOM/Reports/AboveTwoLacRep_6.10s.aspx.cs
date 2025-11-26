using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.Api;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class AboveTwoLacRep_6__10s : Page, IRequiresSessionState
    {
        private string[] eng = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };

        private string[] bng = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };

    

        public AboveTwoLacRep_6__10s()
        {
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.getPurchaseInformation();
              
                this.getSaleInformation();
              
                    this.cnPrint.Visible = true;
                    this.showPurchaseReport();
                
                    this.btnShow.Text = "Hide Report";

                    this.showSaleReport();

                    this.gridviewPurchase.Visible = false;
                    this.gridviewSale.Visible = false;
                    this.purchase.Visible = true;
                    this.sale.Visible = true;
                    this.btnPrintReport.Visible = true;
                
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getPurchaseInformation()
        {
            NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacBLL avobeTwoLacBLL = new NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacBLL();
            ArrayList item = (ArrayList)this.Session["PURCHASE_INFORMATION"] ?? new ArrayList();
            CultureInfo invariantCulture = CultureInfo.InvariantCulture;
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", invariantCulture);
            string str = dateTime.ToString("dd/MM/yyyy");
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", invariantCulture);
            string str1 = dateTime1.AddDays(1).ToString("dd/MM/yyyy");
            string str2 = this.txtChallanNumber.Text.ToString().Trim();
            try
            {
                DataTable localPurchaseData = avobeTwoLacBLL.getLocalPurchaseData(str, str1, str2);
                if (localPurchaseData != null && localPurchaseData.Rows.Count > 0)
                {
                    for (int i = 0; i < localPurchaseData.Rows.Count; i++)
                    {
                       NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO avobeTwoLacDAO = new NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO();
                        string str3 = localPurchaseData.Rows[i]["payment_method"].ToString();
                        string str4 = localPurchaseData.Rows[i]["purchase_type"].ToString();
                        avobeTwoLacDAO.TrnsType = string.Concat(str4, " , ", str3);
                        avobeTwoLacDAO.ChallanNo = localPurchaseData.Rows[i]["challan_no"].ToString();
                        avobeTwoLacDAO.Amount = Convert.ToDecimal(localPurchaseData.Rows[i]["total_price"].ToString());
                        DateTime dateTime2 = DateTime.Parse(localPurchaseData.Rows[i]["date_insert"].ToString());
                        avobeTwoLacDAO.Date = dateTime2.ToString("dd/MM/yyyy");
                        avobeTwoLacDAO.Bin = localPurchaseData.Rows[i]["party_bin"].ToString();
                        avobeTwoLacDAO.VatType = "মূসক-৬.৩";
                        avobeTwoLacDAO.Purchase_party_name = localPurchaseData.Rows[i]["party_name"].ToString();
                        avobeTwoLacDAO.Purchase_party_address = localPurchaseData.Rows[i]["party_address"].ToString();
                        item.Add(avobeTwoLacDAO);
                    }
                }


                //string start_date = Convert.ToDateTime(str).ToString("yyyy-MM-dd");
                //string end_date = Convert.ToDateTime(str1).ToString("yyyy-MM-dd");
                //var purchaseList = MushakAPI.SubForm_k_Note_14Above2Lakh(start_date, end_date);


                //if(purchaseList!=null)
                //{
                //    foreach(var items in purchaseList)
                //    {
                //       NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO avobeTwoLacDAO = new NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO();
                //        string str3 ="";
                //        string str4 = "Local Purchaes";
                //        avobeTwoLacDAO.TrnsType = string.Concat(str4, " , ", str3);
                //        avobeTwoLacDAO.ChallanNo = items.tracking_no;
                //        avobeTwoLacDAO.Amount = Convert.ToDecimal(items.price);
                //        DateTime dateTime2 = DateTime.Parse(items.chalan_date);
                //        avobeTwoLacDAO.Date = dateTime2.ToString("dd/MM/yyyy");
                //        avobeTwoLacDAO.Bin =items.vat_reg_no;
                //        avobeTwoLacDAO.VatType = "মূসক-৬.৩";
                //        avobeTwoLacDAO.Purchase_party_name =items.bikreta;
                //        avobeTwoLacDAO.Purchase_party_address = items.address;
                //        item.Add(avobeTwoLacDAO);
                //    }
                //}




                this.Session["PURCHASE_INFORMATION"] = item;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getSaleInformation()
        {
            AvobeTwoLacBLL avobeTwoLacBLL = new AvobeTwoLacBLL();
            ArrayList item = (ArrayList)this.Session["SALE_INFORMATION"] ?? new ArrayList();
            CultureInfo invariantCulture = CultureInfo.InvariantCulture;
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", invariantCulture);
            string str = dateTime.ToString("dd/MM/yyyy");
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", invariantCulture);
            string str1 = dateTime1.AddDays(1).ToString("dd/MM/yyyy");
            string str2 = this.txtChallanNumber.Text.ToString().Trim();
            try
            {
                int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                DataTable localSaleData = avobeTwoLacBLL.getLocalSaleData(str, str1, str2);
                if (localSaleData != null && localSaleData.Rows.Count > 0)
                {
                    for (int i = 0; i < localSaleData.Rows.Count; i++)
                    {
                        NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO avobeTwoLacDAO = new NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO();
                        localSaleData.Rows[i]["sale_type"].ToString();
                        avobeTwoLacDAO.ChallanNo = localSaleData.Rows[i]["challan_no"].ToString();
                        avobeTwoLacDAO.Amount = Convert.ToDecimal(Utilities.RoundUpToWithString(Convert.ToDecimal(localSaleData.Rows[i]["total_price"]), num));
                        DateTime dateTime2 = DateTime.Parse(localSaleData.Rows[i]["date_insert"].ToString());
                        avobeTwoLacDAO.Date = dateTime2.ToString("dd/MM/yyyy");
                        avobeTwoLacDAO.Bin = localSaleData.Rows[i]["party_bin"].ToString();
                        avobeTwoLacDAO.Sale_party_name = localSaleData.Rows[i]["party_name"].ToString();
                        avobeTwoLacDAO.Sale_party_address = localSaleData.Rows[i]["party_address"].ToString();
                        avobeTwoLacDAO.VatType = "মূসক-৬.৩";
                        item.Add(avobeTwoLacDAO);
                    }
                }


                //string start_date = Convert.ToDateTime(str).ToString("yyyy-MM-dd");
                //string end_date = Convert.ToDateTime(str1).ToString("yyyy-MM-dd");
                //var salesList = MushakAPI.SubForm_k_Note_14SalesAbove2Lakh(start_date, end_date);


                //if (salesList != null)
                //{
                //    foreach (var items in salesList)
                //    {
                //        NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO avobeTwoLacDAO = new NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO();
                //       // localSaleData.Rows[i]["sale_type"].ToString();
                //        avobeTwoLacDAO.ChallanNo = items.invoice_no;
                //        avobeTwoLacDAO.Amount = Convert.ToDecimal(Utilities.RoundUpToWithString(Convert.ToDecimal(items.price), num));
                //        DateTime dateTime2 = DateTime.Parse(items.issue_date);
                //        avobeTwoLacDAO.Date = dateTime2.ToString("dd/MM/yyyy");
                //        avobeTwoLacDAO.Bin =items.vat_reg_no.ToString();
                //        avobeTwoLacDAO.Sale_party_name = items.kreta_name;
                //        avobeTwoLacDAO.Sale_party_address = items.address;
                //        avobeTwoLacDAO.VatType = "মূসক-৬.৩";
                //        item.Add(avobeTwoLacDAO);
                //    }
                //}





                    this.Session["SALE_INFORMATION"] = item;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        private void loadPurchaseGridView()
        {
            ArrayList item = (ArrayList)this.Session["PURCHASE_INFORMATION"];
            this.gvPurchase.DataSource = item;
            this.gvPurchase.DataBind();
        }

        private void loadSaleGridview()
        {
            ArrayList item = (ArrayList)this.Session["SALE_INFORMATION"];
            this.gvSale.DataSource = item;
            this.gvSale.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           NBR_VAT_GROUPOFCOM.BLL.MQMM.LoginCheckForUser();


            // this.Session["PURCHASE_INFORMATION"] = new ArrayList();
            // this.Session["SALE_INFORMATION"] = new ArrayList();
            // this.dtpDateFrom.Text = DateTime.Today.ToString("01/MM/yyyy");
            //this.dtpDateTo.Text = DateTime.Today.ToString("dd/MM/yyyy");



            if (!base.IsPostBack)
            {
                this.Session["PURCHASE_INFORMATION"] = new ArrayList();
                this.Session["SALE_INFORMATION"] = new ArrayList();
                this.dtpDateFrom.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }

        private void showPurchaseReport()
        {
            try
            {
                NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO avobeTwoLacDAO = new NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO();
                this.lblPersonName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.lblBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.emp_name.Text = this.Session["EMPLOYEE_NAME"].ToString();
                this.date.Text = DateTime.Now.ToShortDateString();
                int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                ArrayList item = (ArrayList)this.Session["PURCHASE_INFORMATION"];
                string str = "";
                for (int i = 0; i < item.Count; i++)
                {
                    string str1 = i.ToString();
                    string str2 = Utilities.convertEnglistNumberIntoBangla(str1.ToString());
                    avobeTwoLacDAO = (NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO)item[i];
                    str = string.Concat(str, "<tr>");
                    str = string.Concat(str, "<td style='text-align:center;'>", str2, "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.ChallanNo, "</td>");
                    str = string.Concat(str, "<td style='text-align:center'>", avobeTwoLacDAO.Date, "</td>");
                    str = string.Concat(str, "<td style='text-align:right'>", Utilities.RoundUpToWithString(avobeTwoLacDAO.Amount, num), "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.Purchase_party_name, "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.Purchase_party_address, "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.Bin, "</td>");
                    str = string.Concat(str, "</tr>");
                    this.lblPurchaseReport.Text = str;
                }
            }
            catch(Exception ex)
            {

            }
         
        }

        private void showSaleReport()
        {
            try
            {
                NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO avobeTwoLacDAO = new NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO();
                ArrayList item = (ArrayList)this.Session["SALE_INFORMATION"];
                string str = "";
                int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                for (int i = 0; i < item.Count; i++)
                {
                    string str1 = i.ToString();
                   // string str2 = str1.Replace(this.eng[i], this.bng[i]);
                    string str2 = Utilities.convertEnglistNumberIntoBangla(str1.ToString());
                    avobeTwoLacDAO = (NBR_VAT_GROUPOFCOM.BLL.AvobeTwoLacDAO)item[i];
                    str = string.Concat(str, "<tr>");
                    str = string.Concat(str, "<td style='text-align:center;'>", str2, "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.ChallanNo, "</td>");
                    str = string.Concat(str, "<td style='text-align:center'>", avobeTwoLacDAO.Date, "</td>");
                    str = string.Concat(str, "<td style='text-align:right'>", Utilities.RoundUpToWithString(avobeTwoLacDAO.Amount, num), "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.Sale_party_name, "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.Sale_party_address, "</td>");
                    str = string.Concat(str, "<td style='text-align:left'>", avobeTwoLacDAO.Bin, "</td>");
                    str = string.Concat(str, "</tr>");
                    this.lblSale.Text = str;
                }
            }
            catch(Exception ex)
            {

            }
          
        }
    }
}