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
    public class Admin_DashboardsSIMS : Page, IRequiresSessionState
    {
        private ItemBLL item = new ItemBLL();

        protected Label lblReportData;

        protected Chart chrtServicePurchase;

        protected Chart chrtServiceSale;

        protected Label lblServicePurchaseVATCount;

        protected Label lblServicePurchaseSDCount;

        protected Label lblServicePurchaseCDCount;

        protected Label lblServicePurchaseRDCount;

        protected Label lblServicePurchaseVASCount;

        protected Label lblServicePurchaseTotalCount;

        protected Label lblServicePurchaseVAT;

        protected Label lblServicePurchaseSD;

        protected Label lblServicePurchaseCD;

        protected Label lblServicePurchaseRD;

        protected Label lblServicePurchaseVAS;

        protected Label lblServicePurchaseTotal;

        protected Label lblServiceSalesVATCount;

        protected Label lblServiceSalesSDCount;

        protected Label Label1;

        protected Label Label2;

        protected Label Label3;

        protected Label lblServiceSalesTotalCount;

        protected Label lblServiceSalesVAT;

        protected Label lblServiceSalesSD;

        protected Label lblServiceSalesCD;

        protected Label lblServiceSalesRD;

        protected Label lblServiceSalesVAS;

        protected Label lblServiceSalesTotal;

        protected Label lblGoodsPurchaseVATCount;

        protected Label lblGoodsPurchaseSDCount;

        protected Label lblGoodsPurchaseCDCount;

        protected Label lblGoodsPurchaseRDCount;

        protected Label lblGoodsPurchaseVASCount;

        protected Label lblGoodsPurchaseTotalCount;

        protected Label lblGoodsPurchaseVAT;

        protected Label lblGoodsPurchaseSD;

        protected Label lblGoodsPurchaseCD;

        protected Label lblGoodsPurchaseRD;

        protected Label lblGoodsPurchaseVAS;

        protected Label lblGoodsPurchaseTotal;

        protected Label lblGoodsSalesVATCount;

        protected Label lblGoodsSalesSDCount;

        protected Label Label4;

        protected Label Label5;

        protected Label Label6;

        protected Label lblGoodsSalesTotalCount;

        protected Label lblGoodsSalesVAT;

        protected Label lblGoodsSalesSD;

        protected Label lblGoodsSalesCD;

        protected Label lblGoodsSalesRD;

        protected Label lblGoodsSalesVAS;

        protected Label lblGoodsSalesTotal;

        protected HtmlGenericControl PopupContainer1;

        protected HtmlGenericControl PopupContainer4;

        protected HtmlGenericControl PopupContainer5;

        protected HtmlGenericControl PopupContainer3;

        protected HtmlGenericControl PopupContainer2;

        protected HtmlGenericControl PopupContainer6;

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

        public Admin_DashboardsSIMS()
        {
        }

        private void GetChartTypes()
        {
            foreach (int value in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem listItem = new ListItem(Enum.GetName(typeof(SeriesChartType), value), value.ToString());
            }
        }

        private void GetPurchaseChartDataForAdmin()
        {
            DataTable dataTable = this.item.ChartPurchaseForAdmin();
            Series item = this.chrtServicePurchase.Series["Series1"];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataPointCollection points = item.Points;
                string str = dataTable.Rows[i]["Date"].ToString();
                object[] num = new object[] { Convert.ToDouble(dataTable.Rows[i]["vat"].ToString()) };
                points.AddXY(str, num);
                DataPointCollection dataPointCollection = item.Points;
                string str1 = dataTable.Rows[i]["Date"].ToString();
                object[] objArray = new object[] { Convert.ToDouble(dataTable.Rows[i]["sd"].ToString()) };
                dataPointCollection.AddXY(str1, objArray);
                DataPointCollection points1 = item.Points;
                string str2 = dataTable.Rows[i]["Date"].ToString();
                object[] num1 = new object[] { Convert.ToDouble(dataTable.Rows[i]["total_price"].ToString()) };
                points1.AddXY(str2, num1);
                this.chrtServicePurchase.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                this.chrtServicePurchase.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            this.chrtServicePurchase.DataSource = dataTable;
            this.chrtServicePurchase.DataBind();
        }

        private void GetPurchaseChartDataForManager()
        {
            DataTable dataTable = this.item.ChartPurchaseForManager();
            Series item = this.chrtServicePurchase.Series["Series1"];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataPointCollection points = item.Points;
                string str = dataTable.Rows[i]["Date"].ToString();
                object[] num = new object[] { Convert.ToDouble(dataTable.Rows[i]["vat"].ToString()) };
                points.AddXY(str, num);
                DataPointCollection dataPointCollection = item.Points;
                string str1 = dataTable.Rows[i]["Date"].ToString();
                object[] objArray = new object[] { Convert.ToDouble(dataTable.Rows[i]["sd"].ToString()) };
                dataPointCollection.AddXY(str1, objArray);
                DataPointCollection points1 = item.Points;
                string str2 = dataTable.Rows[i]["Date"].ToString();
                object[] num1 = new object[] { Convert.ToDouble(dataTable.Rows[i]["total_price"].ToString()) };
                points1.AddXY(str2, num1);
                this.chrtServicePurchase.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                this.chrtServicePurchase.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            this.chrtServicePurchase.DataSource = dataTable;
            this.chrtServicePurchase.DataBind();
        }

        private void GetPurchaseChartDataForNormalUser()
        {
            int num = Convert.ToInt16(this.Session["employee_id"]);
            DataTable dataTable = this.item.ChartPurchaseForNormalUser(num);
            Series item = this.chrtServicePurchase.Series["Series1"];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataPointCollection points = item.Points;
                string str = dataTable.Rows[i]["Date"].ToString();
                object[] objArray = new object[] { Convert.ToDouble(dataTable.Rows[i]["vat"].ToString()) };
                points.AddXY(str, objArray);
                DataPointCollection dataPointCollection = item.Points;
                string str1 = dataTable.Rows[i]["Date"].ToString();
                object[] num1 = new object[] { Convert.ToDouble(dataTable.Rows[i]["total_price"].ToString()) };
                dataPointCollection.AddXY(str1, num1);
                this.chrtServicePurchase.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
                this.chrtServicePurchase.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            this.chrtServicePurchase.DataSource = dataTable;
            this.chrtServicePurchase.DataBind();
        }

        private void GetSaleChartDataForAdmin()
        {
            DataTable dataTable = this.item.ChartSaleForAdmin();
            Series item = this.chrtServiceSale.Series["Series1"];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataPointCollection points = item.Points;
                string str = dataTable.Rows[i]["Date"].ToString();
                object[] num = new object[] { Convert.ToDouble(dataTable.Rows[i]["vat"].ToString()) };
                points.AddXY(str, num);
                DataPointCollection dataPointCollection = item.Points;
                string str1 = dataTable.Rows[i]["Date"].ToString();
                object[] objArray = new object[] { Convert.ToDouble(dataTable.Rows[i]["total_price"].ToString()) };
                dataPointCollection.AddXY(str1, objArray);
                this.chrtServiceSale.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                this.chrtServiceSale.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            this.chrtServiceSale.DataSource = dataTable;
            this.chrtServiceSale.DataBind();
        }

        private void GetSaleChartDataForManager()
        {
            DataTable dataTable = this.item.ChartSaleForManager();
            Series item = this.chrtServiceSale.Series["Series1"];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataPointCollection points = item.Points;
                string str = dataTable.Rows[i]["Date"].ToString();
                object[] num = new object[] { Convert.ToDouble(dataTable.Rows[i]["vat"].ToString()) };
                points.AddXY(str, num);
                DataPointCollection dataPointCollection = item.Points;
                string str1 = dataTable.Rows[i]["Date"].ToString();
                object[] objArray = new object[] { Convert.ToDouble(dataTable.Rows[i]["total_price"].ToString()) };
                dataPointCollection.AddXY(str1, objArray);
                this.chrtServiceSale.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                this.chrtServiceSale.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            this.chrtServiceSale.DataSource = dataTable;
            this.chrtServiceSale.DataBind();
        }

        private void GetSaleChartDataForNormalUser()
        {
            int num = Convert.ToInt16(this.Session["employee_id"]);
            DataTable dataTable = this.item.ChartSaleForNormalUser(num);
            Series item = this.chrtServiceSale.Series["Series1"];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataPointCollection points = item.Points;
                string str = dataTable.Rows[i]["Date"].ToString();
                object[] objArray = new object[] { Convert.ToDouble(dataTable.Rows[i]["vat"].ToString()) };
                points.AddXY(str, objArray);
                DataPointCollection dataPointCollection = item.Points;
                string str1 = dataTable.Rows[i]["Date"].ToString();
                object[] num1 = new object[] { Convert.ToDouble(dataTable.Rows[i]["total_price"].ToString()) };
                dataPointCollection.AddXY(str1, num1);
                this.chrtServiceSale.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
                this.chrtServiceSale.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            }
            this.chrtServiceSale.DataSource = dataTable;
            this.chrtServiceSale.DataBind();
        }

        private void GetVDSChartDataForAdmin()
        {
            object obj;
            object[] item;
            decimal num;
            string empty = string.Empty;
            int count = 0;
            int count1 = 0;
            int num1 = 0;
            int count2 = 0;
            int num2 = 0;
            int count3 = 0;
            DataTable dataTable = this.item.challanNoforIssue();
            DataTable dataTable1 = this.item.IssuedChallan();
            DataTable dataTable2 = this.item.TreasurychallanwithPayment();
            DataTable dataTable3 = this.item.TreasurychallanwithoutPayment();
            DateTime.Today.AddDays(-3).ToString();
            DataTable dataTable4 = this.item.TreasurychallanExpireToday();
            DataTable dataTable5 = this.item.TreasurychallanExpired();
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string str3 = string.Empty;
            string empty4 = string.Empty;
            string str4 = string.Empty;
            string empty5 = string.Empty;
            string str5 = string.Empty;
            string empty6 = string.Empty;
            string str6 = string.Empty;
            string empty7 = string.Empty;
            string str7 = string.Empty;
            string empty8 = string.Empty;
            string str8 = string.Empty;
            string empty9 = string.Empty;
            string str9 = string.Empty;
            string empty10 = string.Empty;
            string str10 = string.Empty;
            string empty11 = string.Empty;
            string str11 = string.Empty;
            string empty12 = string.Empty;
            if (dataTable1.Rows.Count > 0)
            {
                count = dataTable1.Rows.Count;
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    string str12 = dataTable1.Rows[i]["date_challan"].ToString();
                    DateTime dateTime = DateTime.ParseExact(str12, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dateTime.AddDays(3);
                    string str13 = DateTime.Today.ToString("dd/MM/yyyy");
                    DateTime.ParseExact(str13, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    empty4 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'> No. of 6.6 Issue </th></tr><tr><th>Challan No</th><th>Item Name</th><th>Party Name</th><th>Certificate Issue Date</th><th>Amount</th></tr></thead>";
                    obj = str3;
                    item = new object[] { obj, "<tbody><tr><td>", dataTable1.Rows[i]["challan_no"], "</td><td>", dataTable1.Rows[i]["item_name"], "</td><td>", dataTable1.Rows[i]["party_name"], "</td><td>", dataTable1.Rows[i]["date_challan"], "</td><td style='text-align: right'>", null, null };
                    num = Convert.ToDecimal(dataTable1.Rows[i]["vds_amount"]);
                    item[10] = num.ToString("0.00");
                    item[11] = "</td></tr></tbody>";
                    str3 = string.Concat(item);
                    str4 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty4, str3, "</table>");
                }
            }
            if (dataTable.Rows.Count > 0)
            {
                count1 = dataTable.Rows.Count;
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    str5 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'> No. of 6.6 Non Issue</th></tr><tr><th>Challan No</th><th>Item Name</th><th>Party Name</th><th>Challan Date</th><th>Amount</th></tr></thead>";
                    object obj1 = empty5;
                    object[] objArray = new object[] { obj1, "<tbody><tr><td>", dataTable.Rows[j]["challan_no"], "</td><td>", dataTable.Rows[j]["item_name"], "</td><td>", dataTable.Rows[j]["party_name"], "</td><td>", dataTable.Rows[j]["date_challan"], "</td><td style='text-align: right'>", null, null };
                    decimal num3 = Convert.ToDecimal(dataTable.Rows[j]["vds_amount"]);
                    objArray[10] = num3.ToString("0.00");
                    objArray[11] = "</td></tr></tbody>";
                    empty5 = string.Concat(objArray);
                    empty6 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", str5, empty5, "</table>");
                }
            }
            if (dataTable2.Rows.Count > 0)
            {
                num1 = dataTable2.Rows.Count;
                for (int k = 0; k < dataTable2.Rows.Count; k++)
                {
                    empty7 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'> No. of TR Challan with Payment</th></tr><tr><th>Challan No</th><th>Item Name</th><th>Party Name</th><th>Challan Date</th><th>Amount</th></tr></thead>";
                    object obj2 = str6;
                    object[] item1 = new object[] { obj2, "<tbody><tr><td>", dataTable2.Rows[k]["challan_no"], "</td><td>", dataTable2.Rows[k]["item_name"], "</td><td>", dataTable2.Rows[k]["party_name"], "</td><td>", dataTable2.Rows[k]["date_challan"], "</td><td style='text-align: right'>", null, null };
                    decimal num4 = Convert.ToDecimal(dataTable2.Rows[k]["vds_amount"]);
                    item1[10] = num4.ToString("0.00");
                    item1[11] = "</td></tr></tbody>";
                    str6 = string.Concat(item1);
                    str7 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty7, str6, "</table>");
                }
            }
            if (dataTable3.Rows.Count > 0)
            {
                count2 = dataTable3.Rows.Count;
                for (int l = 0; l < dataTable3.Rows.Count; l++)
                {
                    str8 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'> No. of TR Challan without Payment</th></tr><tr><th>Challan No</th><th>Item Name</th><th>Party Name</th><th>Challan Date</th><th>Amount</th></tr></thead>";
                    object obj3 = empty8;
                    object[] objArray1 = new object[] { obj3, "<tbody><tr><td>", dataTable3.Rows[l]["challan_no"], "</td><td>", dataTable3.Rows[l]["item_name"], "</td><td>", dataTable3.Rows[l]["party_name"], "</td><td>", dataTable3.Rows[l]["date_challan"], "</td><td style='text-align: right'>", null, null };
                    decimal num5 = Convert.ToDecimal(dataTable3.Rows[l]["vds_amount"]);
                    objArray1[10] = num5.ToString("0.00");
                    objArray1[11] = "</td></tr></tbody>";
                    empty8 = string.Concat(objArray1);
                    empty9 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", str8, empty8, "</table>");
                }
            }
            if (dataTable4.Rows.Count > 0)
            {
                num2 = dataTable4.Rows.Count;
                for (int m = 0; m < dataTable4.Rows.Count; m++)
                {
                    empty10 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'> No. of Challan expire for TR Challan Today</th></tr><tr><th>Challan No</th><th>Item Name</th><th>Party Name</th><th>Challan Date</th><th>Amount</th></tr></thead>";
                    obj = str9;
                    item = new object[] { obj, "<tbody><tr><td>", dataTable4.Rows[m]["challan_no"], "</td><td>", dataTable4.Rows[m]["item_name"], "</td><td>", dataTable4.Rows[m]["party_name"], "</td><td>", dataTable4.Rows[m]["date_challan"], "</td><td style='text-align: right'>", null, null };
                    num = Convert.ToDecimal(dataTable4.Rows[m]["vds_amount"]);
                    item[10] = num.ToString("0.00");
                    item[11] = "</td></tr></tbody>";
                    str9 = string.Concat(item);
                    str10 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty10, str9, "</table>");
                }
            }
            if (dataTable5.Rows.Count > 0)
            {
                count3 = dataTable5.Rows.Count;
                for (int n = 0; n < dataTable5.Rows.Count; n++)
                {
                    str11 = "<thead style='text-align: center'><tr style='text-align: center'> <th colspan='6'  style='text-align: center'> No. of Challan already expire for TR Challan</th></tr><tr><th>Challan No</th><th>Item Name</th><th>Party Name</th><th>Certificate Issue Date</th><th>Amount</th></tr></thead>";
                    obj = empty11;
                    item = new object[] { obj, "<tbody><tr><td>", dataTable5.Rows[n]["challan_no"], "</td><td>", dataTable5.Rows[n]["item_name"], "</td><td>", dataTable5.Rows[n]["party_name"], "</td><td>", dataTable5.Rows[n]["date_challan"], "</td><td style='text-align: right'>", null, null };
                    num = Convert.ToDecimal(dataTable5.Rows[n]["vds_amount"]);
                    item[10] = num.ToString("0.00");
                    item[11] = "</td></tr></tbody>";
                    empty11 = string.Concat(item);
                    empty12 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", str11, empty11, "</table>");
                }
            }
            item = new object[] { "<div id='PopupContent_", 3, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog modal-lg'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", str7, "</div></div></div></div>" };
            str1 = string.Concat(item);
            HtmlGenericControl popupContainer3 = this.PopupContainer3;
            popupContainer3.InnerHtml = string.Concat(popupContainer3.InnerHtml, str1);
            item = new object[] { "<div id='PopupContent_", 4, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog modal-lg'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", empty9, "</div></div></div></div>" };
            empty2 = string.Concat(item);
            HtmlGenericControl popupContainer4 = this.PopupContainer4;
            popupContainer4.InnerHtml = string.Concat(popupContainer4.InnerHtml, empty2);
            item = new object[] { "<div id='PopupContent_", 5, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog modal-lg'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", str10, "</div></div></div></div>" };
            str2 = string.Concat(item);
            HtmlGenericControl popupContainer5 = this.PopupContainer5;
            popupContainer5.InnerHtml = string.Concat(popupContainer5.InnerHtml, str2);
            item = new object[] { "<div id='PopupContent_", 6, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog modal-lg'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", empty12, "</div></div></div></div>" };
            empty3 = string.Concat(item);
            HtmlGenericControl popupContainer6 = this.PopupContainer6;
            popupContainer6.InnerHtml = string.Concat(popupContainer6.InnerHtml, empty3);
            item = new object[] { "<div id='PopupContent_", 1, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog modal-lg'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", str4, "</div></div></div></div>" };
            str = string.Concat(item);
            HtmlGenericControl popupContainer1 = this.PopupContainer1;
            popupContainer1.InnerHtml = string.Concat(popupContainer1.InnerHtml, str);
            item = new object[] { "<div id='PopupContent_", 2, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog modal-lg'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>", empty6, "</div></div></div></div>" };
            empty1 = string.Concat(item);
            HtmlGenericControl popupContainer2 = this.PopupContainer2;
            popupContainer2.InnerHtml = string.Concat(popupContainer2.InnerHtml, empty1);
            empty = string.Concat(empty, "<tr>");
            obj = empty;
            item = new object[] { obj, "<td style='text-align:center; padding:2px;font-weight:bold'><a href='#PopupContent_", 3, "' data-toggle='modal' data-target='#PopupContent_", 3, "'>", num1, "</a>  </td>" };
            empty = string.Concat(item);
            obj = empty;
            item = new object[] { obj, "<td style='text-align:center; padding:2px;font-weight:bold'><a href='#PopupContent_", 4, "' data-toggle='modal' data-target='#PopupContent_", 4, "'>", count2, "</a></td>" };
            empty = string.Concat(item);
            obj = empty;
            item = new object[] { obj, "<td style='text-align:center; padding:2px;font-weight:bold'><a href='#PopupContent_", 5, "' data-toggle='modal' data-target='#PopupContent_", 5, "' style='color: orangered'>", num2, "</a></td>" };
            empty = string.Concat(item);
            obj = empty;
            item = new object[] { obj, "<td style='text-align:center; padding:2px;font-weight:bold;'><a href='#PopupContent_", 6, "' data-toggle='modal' data-target='#PopupContent_", 6, "' style='color: red;animation:1s blinker linear'>", count3, "</a></td>" };
            empty = string.Concat(item);
            obj = empty;
            item = new object[] { obj, "<td style='text-align:center; padding:2px;font-weight:bold'><a href='#PopupContent_", 1, "' data-toggle='modal' data-target='#PopupContent_", 1, "'>", count, "</a></td>" };
            empty = string.Concat(item);
            obj = empty;
            item = new object[] { obj, "<td style='text-align:center; padding:2px;font-weight:bold'><a href='#PopupContent_", 2, "' data-toggle='modal' data-target='#PopupContent_", 2, "'>", count1, "</a>  </td>" };
            empty = string.Concat(item);
            empty = string.Concat(empty, "<tr>");
            this.lblReportData.Text = empty;
        }

        private void LoadGoods()
        {
            int num = Convert.ToInt16(this.Session["employee_id"]);
            int num1 = Convert.ToInt16(this.Session["USER_LEVEL"]);
            if (num1 == 3)
            {
                DataTable goodsForNormalUser = this.item.getGoodsForNormalUser(num);
                if (goodsForNormalUser != null && goodsForNormalUser.Rows.Count > 0)
                {
                    this.lblGoodsPurchaseVAT.Text = goodsForNormalUser.Rows[0]["VAT"].ToString();
                    this.lblGoodsPurchaseVATCount.Text = goodsForNormalUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseSD.Text = goodsForNormalUser.Rows[0]["sd"].ToString();
                    this.lblGoodsPurchaseSDCount.Text = goodsForNormalUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseCD.Text = goodsForNormalUser.Rows[0]["cd"].ToString();
                    this.lblGoodsPurchaseCDCount.Text = goodsForNormalUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseRD.Text = goodsForNormalUser.Rows[0]["rd"].ToString();
                    this.lblGoodsPurchaseRDCount.Text = goodsForNormalUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseVAS.Text = goodsForNormalUser.Rows[0]["vds"].ToString();
                    this.lblGoodsPurchaseVASCount.Text = goodsForNormalUser.Rows[0]["count"].ToString();
                    Label str = this.lblGoodsPurchaseTotal;
                    double num2 = Convert.ToDouble(goodsForNormalUser.Rows[0]["total_price"]);
                    str.Text = num2.ToString();
                    this.lblGoodsPurchaseTotalCount.Text = goodsForNormalUser.Rows[0]["count"].ToString();
                }
                DataTable saleGoodsForNormalUser = this.item.getSaleGoodsForNormalUser(num);
                if (saleGoodsForNormalUser != null && saleGoodsForNormalUser.Rows.Count > 0)
                {
                    this.lblGoodsSalesVAT.Text = saleGoodsForNormalUser.Rows[0]["VAT"].ToString();
                    this.lblGoodsSalesVATCount.Text = saleGoodsForNormalUser.Rows[0]["count"].ToString();
                    this.lblGoodsSalesSD.Text = saleGoodsForNormalUser.Rows[0]["sd"].ToString();
                    this.lblGoodsSalesSDCount.Text = saleGoodsForNormalUser.Rows[0]["count"].ToString();
                    Label label = this.lblGoodsSalesTotal;
                    double num3 = Convert.ToDouble(saleGoodsForNormalUser.Rows[0]["total_price"]);
                    label.Text = num3.ToString();
                    this.lblGoodsSalesTotalCount.Text = saleGoodsForNormalUser.Rows[0]["count"].ToString();
                }
            }
            if (num1 == 2)
            {
                DataTable goodsForManagerUser = this.item.getGoodsForManagerUser(num);
                if (goodsForManagerUser != null && goodsForManagerUser.Rows.Count > 0)
                {
                    this.lblGoodsPurchaseVAT.Text = goodsForManagerUser.Rows[0]["VAT"].ToString();
                    this.lblGoodsPurchaseVATCount.Text = goodsForManagerUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseSD.Text = goodsForManagerUser.Rows[0]["sd"].ToString();
                    this.lblGoodsPurchaseSDCount.Text = goodsForManagerUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseCD.Text = goodsForManagerUser.Rows[0]["cd"].ToString();
                    this.lblGoodsPurchaseCDCount.Text = goodsForManagerUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseRD.Text = goodsForManagerUser.Rows[0]["rd"].ToString();
                    this.lblGoodsPurchaseRDCount.Text = goodsForManagerUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseVAS.Text = goodsForManagerUser.Rows[0]["vds"].ToString();
                    this.lblGoodsPurchaseVASCount.Text = goodsForManagerUser.Rows[0]["count"].ToString();
                    Label str1 = this.lblGoodsPurchaseTotal;
                    double num4 = Convert.ToDouble(goodsForManagerUser.Rows[0]["total_price"]);
                    str1.Text = num4.ToString();
                    this.lblGoodsPurchaseTotalCount.Text = goodsForManagerUser.Rows[0]["count"].ToString();
                }
                DataTable saleGoodsForManagerUser = this.item.getSaleGoodsForManagerUser(num);
                if (saleGoodsForManagerUser != null && saleGoodsForManagerUser.Rows.Count > 0)
                {
                    this.lblGoodsSalesVAT.Text = saleGoodsForManagerUser.Rows[0]["VAT"].ToString();
                    this.lblGoodsSalesVATCount.Text = saleGoodsForManagerUser.Rows[0]["count"].ToString();
                    this.lblGoodsSalesSD.Text = saleGoodsForManagerUser.Rows[0]["sd"].ToString();
                    this.lblGoodsSalesSDCount.Text = saleGoodsForManagerUser.Rows[0]["count"].ToString();
                    Label label1 = this.lblGoodsSalesTotal;
                    double num5 = Convert.ToDouble(saleGoodsForManagerUser.Rows[0]["total_price"]);
                    label1.Text = num5.ToString();
                    this.lblGoodsSalesTotalCount.Text = saleGoodsForManagerUser.Rows[0]["count"].ToString();
                }
            }
            if (num1 == 1)
            {
                DataTable goodsForAdminUser = this.item.getGoodsForAdminUser(num);
                if (goodsForAdminUser != null && goodsForAdminUser.Rows.Count > 0)
                {
                    this.lblGoodsPurchaseVAT.Text = goodsForAdminUser.Rows[0]["VAT"].ToString();
                    this.lblGoodsPurchaseVATCount.Text = goodsForAdminUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseSD.Text = goodsForAdminUser.Rows[0]["sd"].ToString();
                    this.lblGoodsPurchaseSDCount.Text = goodsForAdminUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseCD.Text = goodsForAdminUser.Rows[0]["cd"].ToString();
                    this.lblGoodsPurchaseCDCount.Text = goodsForAdminUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseRD.Text = goodsForAdminUser.Rows[0]["rd"].ToString();
                    this.lblGoodsPurchaseRDCount.Text = goodsForAdminUser.Rows[0]["count"].ToString();
                    this.lblGoodsPurchaseVAS.Text = goodsForAdminUser.Rows[0]["vds"].ToString();
                    this.lblGoodsPurchaseVASCount.Text = goodsForAdminUser.Rows[0]["count"].ToString();
                    Label str2 = this.lblGoodsPurchaseTotal;
                    double num6 = Convert.ToDouble(goodsForAdminUser.Rows[0]["total_price"]);
                    str2.Text = num6.ToString();
                    this.lblGoodsPurchaseTotalCount.Text = goodsForAdminUser.Rows[0]["count"].ToString();
                }
                DataTable saleGoodsForAdminUser = this.item.getSaleGoodsForAdminUser(num);
                if (saleGoodsForAdminUser != null && saleGoodsForAdminUser.Rows.Count > 0)
                {
                    this.lblGoodsSalesVAT.Text = saleGoodsForAdminUser.Rows[0]["VAT"].ToString();
                    this.lblGoodsSalesVATCount.Text = saleGoodsForAdminUser.Rows[0]["count"].ToString();
                    this.lblGoodsSalesSD.Text = saleGoodsForAdminUser.Rows[0]["sd"].ToString();
                    this.lblGoodsSalesSDCount.Text = saleGoodsForAdminUser.Rows[0]["count"].ToString();
                    Label label2 = this.lblGoodsSalesTotal;
                    double num7 = Convert.ToDouble(saleGoodsForAdminUser.Rows[0]["total_price"]);
                    label2.Text = num7.ToString();
                    this.lblGoodsSalesTotalCount.Text = saleGoodsForAdminUser.Rows[0]["count"].ToString();
                }
            }
        }

        private void LoadService()
        {
            int num = Convert.ToInt16(this.Session["employee_id"]);
            int num1 = Convert.ToInt16(this.Session["USER_LEVEL"]);
            if (num1 == 3)
            {
                this.GetPurchaseChartDataForNormalUser();
                this.GetSaleChartDataForNormalUser();
                DataTable purchaseServicesForNormalUser = this.item.getPurchaseServicesForNormalUser(num);
                this.lblServicePurchaseVAT.Text = Convert.ToString(0);
                if (purchaseServicesForNormalUser != null && purchaseServicesForNormalUser.Rows.Count > 0)
                {
                    this.lblServicePurchaseVAT.Text = purchaseServicesForNormalUser.Rows[0]["VAT"].ToString();
                    this.lblServicePurchaseVATCount.Text = purchaseServicesForNormalUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseSD.Text = purchaseServicesForNormalUser.Rows[0]["sd"].ToString();
                    this.lblServicePurchaseSDCount.Text = purchaseServicesForNormalUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseCD.Text = purchaseServicesForNormalUser.Rows[0]["cd"].ToString();
                    this.lblServicePurchaseCDCount.Text = purchaseServicesForNormalUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseRD.Text = purchaseServicesForNormalUser.Rows[0]["rd"].ToString();
                    this.lblServicePurchaseRDCount.Text = purchaseServicesForNormalUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseVAS.Text = purchaseServicesForNormalUser.Rows[0]["vds"].ToString();
                    this.lblServicePurchaseVASCount.Text = purchaseServicesForNormalUser.Rows[0]["count"].ToString();
                    Label str = this.lblServicePurchaseTotal;
                    double num2 = Convert.ToDouble(purchaseServicesForNormalUser.Rows[0]["total_price"]);
                    str.Text = num2.ToString();
                    this.lblServicePurchaseTotalCount.Text = purchaseServicesForNormalUser.Rows[0]["count"].ToString();
                }
                DataTable saleServicesForNormalUser = this.item.getSaleServicesForNormalUser(num);
                if (purchaseServicesForNormalUser != null && purchaseServicesForNormalUser.Rows.Count > 0)
                {
                    this.lblServiceSalesVAT.Text = saleServicesForNormalUser.Rows[0]["VAT"].ToString();
                    this.lblServiceSalesVATCount.Text = saleServicesForNormalUser.Rows[0]["count"].ToString();
                    this.lblServiceSalesSD.Text = saleServicesForNormalUser.Rows[0]["sd"].ToString();
                    this.lblServiceSalesSDCount.Text = saleServicesForNormalUser.Rows[0]["count"].ToString();
                    Label label = this.lblServiceSalesTotal;
                    double num3 = Convert.ToDouble(saleServicesForNormalUser.Rows[0]["total_price"]);
                    label.Text = num3.ToString();
                    this.lblServiceSalesTotalCount.Text = saleServicesForNormalUser.Rows[0]["count"].ToString();
                }
            }
            if (num1 == 2)
            {
                this.GetPurchaseChartDataForManager();
                this.GetSaleChartDataForManager();
                DataTable purchaseServicesForManagerUser = this.item.getPurchaseServicesForManagerUser();
                this.lblServicePurchaseVAT.Text = Convert.ToString(0);
                if (purchaseServicesForManagerUser != null && purchaseServicesForManagerUser.Rows.Count > 0)
                {
                    this.lblServicePurchaseVAT.Text = purchaseServicesForManagerUser.Rows[0]["VAT"].ToString();
                    this.lblServicePurchaseVATCount.Text = purchaseServicesForManagerUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseSD.Text = purchaseServicesForManagerUser.Rows[0]["sd"].ToString();
                    this.lblServicePurchaseSDCount.Text = purchaseServicesForManagerUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseCD.Text = purchaseServicesForManagerUser.Rows[0]["cd"].ToString();
                    this.lblServicePurchaseCDCount.Text = purchaseServicesForManagerUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseRD.Text = purchaseServicesForManagerUser.Rows[0]["rd"].ToString();
                    this.lblServicePurchaseRDCount.Text = purchaseServicesForManagerUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseVAS.Text = purchaseServicesForManagerUser.Rows[0]["vds"].ToString();
                    this.lblServicePurchaseVASCount.Text = purchaseServicesForManagerUser.Rows[0]["count"].ToString();
                    Label str1 = this.lblServicePurchaseTotal;
                    double num4 = Convert.ToDouble(purchaseServicesForManagerUser.Rows[0]["total_price"]);
                    str1.Text = num4.ToString();
                    this.lblServicePurchaseTotalCount.Text = purchaseServicesForManagerUser.Rows[0]["count"].ToString();
                }
                DataTable saleServicesForManagerUser = this.item.getSaleServicesForManagerUser();
                if (saleServicesForManagerUser != null && saleServicesForManagerUser.Rows.Count > 0)
                {
                    this.lblServiceSalesVAT.Text = saleServicesForManagerUser.Rows[0]["VAT"].ToString();
                    this.lblServiceSalesVATCount.Text = saleServicesForManagerUser.Rows[0]["count"].ToString();
                    this.lblServiceSalesSD.Text = saleServicesForManagerUser.Rows[0]["sd"].ToString();
                    this.lblServiceSalesSDCount.Text = saleServicesForManagerUser.Rows[0]["count"].ToString();
                    Label label1 = this.lblServiceSalesTotal;
                    double num5 = Convert.ToDouble(saleServicesForManagerUser.Rows[0]["total_price"]);
                    label1.Text = num5.ToString();
                    this.lblServiceSalesTotalCount.Text = saleServicesForManagerUser.Rows[0]["count"].ToString();
                }
            }
            if (num1 == 1)
            {
                this.GetPurchaseChartDataForAdmin();
                this.GetSaleChartDataForAdmin();
                this.GetVDSChartDataForAdmin();
                DataTable purchaseServicesForAdminUser = this.item.getPurchaseServicesForAdminUser();
                if (purchaseServicesForAdminUser != null && purchaseServicesForAdminUser.Rows.Count > 0)
                {
                    this.lblServicePurchaseVAT.Text = purchaseServicesForAdminUser.Rows[0]["VAT"].ToString();
                    this.lblServicePurchaseVATCount.Text = purchaseServicesForAdminUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseSD.Text = purchaseServicesForAdminUser.Rows[0]["sd"].ToString();
                    this.lblServicePurchaseSDCount.Text = purchaseServicesForAdminUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseCD.Text = purchaseServicesForAdminUser.Rows[0]["cd"].ToString();
                    this.lblServicePurchaseCDCount.Text = purchaseServicesForAdminUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseRD.Text = purchaseServicesForAdminUser.Rows[0]["rd"].ToString();
                    this.lblServicePurchaseRDCount.Text = purchaseServicesForAdminUser.Rows[0]["count"].ToString();
                    this.lblServicePurchaseVAS.Text = purchaseServicesForAdminUser.Rows[0]["vds"].ToString();
                    this.lblServicePurchaseVASCount.Text = purchaseServicesForAdminUser.Rows[0]["count"].ToString();
                    Label str2 = this.lblServicePurchaseTotal;
                    double num6 = Convert.ToDouble(purchaseServicesForAdminUser.Rows[0]["total_price"]);
                    str2.Text = num6.ToString();
                    this.lblServicePurchaseTotalCount.Text = purchaseServicesForAdminUser.Rows[0]["count"].ToString();
                }
                DataTable saleServicesForAdminUser = this.item.getSaleServicesForAdminUser();
                if (saleServicesForAdminUser != null && saleServicesForAdminUser.Rows.Count > 0)
                {
                    this.lblServiceSalesVAT.Text = saleServicesForAdminUser.Rows[0]["VAT"].ToString();
                    this.lblServiceSalesVATCount.Text = saleServicesForAdminUser.Rows[0]["count"].ToString();
                    this.lblServiceSalesSD.Text = saleServicesForAdminUser.Rows[0]["sd"].ToString();
                    this.lblServiceSalesSDCount.Text = saleServicesForAdminUser.Rows[0]["count"].ToString();
                    Label label2 = this.lblServiceSalesTotal;
                    double num7 = Convert.ToDouble(saleServicesForAdminUser.Rows[0]["total_price"]);
                    label2.Text = num7.ToString();
                    this.lblServiceSalesTotalCount.Text = saleServicesForAdminUser.Rows[0]["count"].ToString();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          NBR_VAT_GROUPOFCOM.BLL.MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.GetChartTypes();
                this.LoadService();
                this.LoadGoods();
            }

            // this.LoadService();
        }
    }
}