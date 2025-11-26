using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
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
    public partial class DailySaleReports : Page, IRequiresSessionState
    {
        private PeriodicReportBLL dbBLL = new PeriodicReportBLL();

       




        public DailySaleReports()
        {
        }

        private string loadDetailData(DateTime dateChallan, int precision)
        {
            string str = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            string str3 = dateChallan.ToString("ddMMyyyy");
            empty = string.Concat("<button onclick='PrintModal(\"", str3, "\")' style='background-color:#5bc0de;color: #fff;border-color: #46b8da;border-radius: 4px;font-size: 14px;'   data-dismiss='modal' >  Print </button> ");
            empty2 = "<thead style='text-align: center;'><tr style='text-align: center'> </tr><tr><th  style='text-align: center;'>Date</th><th style='text-align: center;'>Purchaser Name</th><th style='text-align: center;'>Challan No</th><th style='text-align: center;'>Challan Issue Time</th><th style='text-align: center;'>H.S Code</th><th style='text-align: center;'>Item Name</th><th style='text-align: center;'>Quantity</th><th style='text-align: center;'>Unit</th><th style='text-align: center;'>Unit Price</th><th style='text-align: center;'>Total Sale Amount</th><th style='text-align: center;'>Total VAT Amount</th><th style='text-align: center;'>Total SD Amount</th></tr></thead>";
            DataTable salesDailyDetailReportData = this.dbBLL.GetSalesDailyDetailReportData(dateChallan);
            if (salesDailyDetailReportData.Rows.Count <= 0)
            {
                str = string.Concat("<div id='PopupContent_", dateChallan.ToString("ddMMyyyy"), "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content' ><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>'Not Found'</div></div></div></div>");
            }
            else
            {
                for (int i = 0; i < salesDailyDetailReportData.Rows.Count; i++)
                {
                    num += Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["price"]);
                    num1 += Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["vat"]);
                    num2 += Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["sd"]);
                    DateTime dateTime = Convert.ToDateTime(salesDailyDetailReportData.Rows[i]["challanTime"]);
                    string str4 = dateTime.ToString("hh:mm tt");
                    string str5 = str1;
                    string[] strArrays = new string[] { str5, "<tbody><tr><td  style='text-align: center;padding:5px'>", dateChallan.ToString("dd/MM/yyyy"), "</td><td  style='text-align:right;padding:5px'>", salesDailyDetailReportData.Rows[i]["party_name"].ToString(), "</td><td  style='text-align:right;padding:5px'>", salesDailyDetailReportData.Rows[i]["challan_no"].ToString(), "</td><td  style='text-align:right;padding:5px'>", str4, "</td><td  style='text-align:right;padding:5px'>", salesDailyDetailReportData.Rows[i]["hs_code"].ToString(), "</td><td  style='text-align:right;padding:5px'>", salesDailyDetailReportData.Rows[i]["item_name"].ToString(), "</td><td  style='text-align:right;padding:5px'>", Utilities.formatFraction(Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["quantity"].ToString())), "</td><td  style='text-align:right;padding:5px'>", salesDailyDetailReportData.Rows[i]["unit_code"].ToString(), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["actual_price"]), precision), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["price"]), precision), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["vat"]), precision), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(salesDailyDetailReportData.Rows[i]["sd"]), precision), "</td></tr></tbody>" };
                    str1 = string.Concat(strArrays);
                }
                string str6 = str2;
                string[] withString = new string[] { str6, "<tr><td colspan='9' style='text-align: right;padding:5px; font-weight:bold;'>Total :</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num, precision), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num1, precision), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num2, precision), "</td></tr>" };
                str2 = string.Concat(withString);
                string[] strArrays1 = new string[] { "<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty2, str1, str2, "</table>" };
                empty1 = string.Concat(strArrays1);
                string[] strArrays2 = new string[] { "<div id='PopupContent_", dateChallan.ToString("ddMMyyyy"), "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'  style='width:80%' ><div class='modal-content' id='eee1'><div class='modal-header'  id='modhead11' >", empty, "<button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body' id='section-to-print' >", empty1, "</div></div></div></div>" };
                str = string.Concat(strArrays2);
            }
            return str;
        }

        private string loadDetailPurchaseData(DateTime dateChallan)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            string str = "";
            string empty = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            string str3 = dateChallan.ToString("ddMMyyyy");
            empty = string.Concat("<button onclick='PrintModal_Purchase(\"", str3, "\")'  style='background-color:#5bc0de;color: #fff;border-color: #46b8da;border-radius: 4px;font-size: 14px;'   data-dismiss='modal'>  Print </button> ");
            empty2 = "<thead style='text-align: center;'><tr style='text-align: center'> </tr><tr><th style='text-align: center;'>Date</th><th style='text-align: center;'>Supplier Name</th><th style='text-align: center;'>Challan No</th><th style='text-align: center;'>Challan Issue Time</th><th style='text-align: center;'>H.S Code</th><th style='text-align: center;'>Item Name</th><th style='text-align: center;'>Quantity</th><th style='text-align: center;'>Unit</th><th style='text-align: center;'>Unit Price</th><th style='text-align: center;'>Total Purchase Amount</th><th style='text-align: center;'>Total VAT Amount</th><th style='text-align: center;'>Total SD Amount</th></tr></thead>";
            DataTable purchaseDailyDetailReportData = this.dbBLL.GetPurchaseDailyDetailReportData(dateChallan);
            if (purchaseDailyDetailReportData.Rows.Count <= 0)
            {
                str = string.Concat("<div id='PopupContentp_", dateChallan.ToString("ddMMyyyy"), "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>'Not Found'</div></div></div></div>");
            }
            else
            {
                for (int i = 0; i < purchaseDailyDetailReportData.Rows.Count; i++)
                {
                    DateTime dateTime = Convert.ToDateTime(purchaseDailyDetailReportData.Rows[i]["challanTime"]);
                    string str4 = dateTime.ToString("hh:mm tt");
                    num1 += Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["price"]);
                    num2 += Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["purchase_vat"]);
                    num3 += Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["purchase_sd"]);
                    string str5 = str1;
                    string[] strArrays = new string[] { str5, "<tbody><tr><td  style='text-align: center;padding:5px'>", dateChallan.ToString("dd/MM/yyyy"), "</td><td  style='text-align:right;padding:5px'>", purchaseDailyDetailReportData.Rows[i]["party_name"].ToString(), "</td><td  style='text-align:right;padding:5px'>", purchaseDailyDetailReportData.Rows[i]["challan_no"].ToString(), "</td><td  style='text-align:right;padding:5px'>", str4, "</td><td  style='text-align:right;padding:5px'>", purchaseDailyDetailReportData.Rows[i]["hs_code"].ToString(), "</td><td  style='text-align:right;padding:5px'>", purchaseDailyDetailReportData.Rows[i]["item_name"].ToString(), "</td><td  style='text-align:right;padding:5px'>", Utilities.formatFraction(Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["quantity"])), "</td><td  style='text-align:right;padding:5px'>", purchaseDailyDetailReportData.Rows[i]["unit_code"].ToString(), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["actual_price"]), num), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["price"]), num), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["purchase_vat"]), num), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(purchaseDailyDetailReportData.Rows[i]["purchase_sd"]), num), "</td></tr></tbody>" };
                    str1 = string.Concat(strArrays);
                }
                string str6 = str2;
                string[] withString = new string[] { str6, "<tr><td colspan='9' style='text-align: right;padding:5px; font-weight:bold;'>Total :</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num1, num), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num2, num), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num3, num), "</td></tr>" };
                str2 = string.Concat(withString);
                string[] strArrays1 = new string[] { "<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty2, str1, str2, "</table>" };
                empty1 = string.Concat(strArrays1);
                string[] strArrays2 = new string[] { "<div id='PopupContentp_", dateChallan.ToString("ddMMyyyy"), "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'  style='width:80%'><div class='modal-content' id='eee1'><div class='modal-header' id='modhead11'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4>", empty, "</div><div class='modal-body' id='modalprinT'>", empty1, "</div></div></div></div>" };
                str = string.Concat(strArrays2);
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.TaxOrganizationName.Text = (this.Session["ORGANIZATION_NAME"] != null ? this.Session["ORGANIZATION_NAME"].ToString() : "n/a");
                this.TaxOrganizationAddress.Text = (this.Session["ORGANIZATION_ADDRESS"] != null ? this.Session["ORGANIZATION_ADDRESS"].ToString() : "n/a");
                this.TaxOrganizationBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.dtpDateFrom.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            try
            {
                int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                string empty = string.Empty;
                string str = string.Empty;
                string str1 = "";
                string str2 = "";
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                DateTime minValue = DateTime.MinValue;
                DateTime dateTime = DateTime.MinValue;
                if (this.dtpDateFrom.Text.Trim().Length > 0)
                {
                    minValue = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (this.dtpDateTo.Text.Trim().Length > 0)
                {
                    dateTime = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                Label label = this.lblDate;
                string[] strArrays = new string[] { "( ", minValue.ToString("dd/MM/yyyy"), " To ", dateTime.ToString("dd/MM/yyyy"), ")" };
                label.Text = string.Concat(strArrays);
                DataTable salesDailyReportData = this.dbBLL.GetSalesDailyReportData(minValue, dateTime);
                if (salesDailyReportData.Rows.Count > 0)
                {
                    this.PopupContainer.InnerHtml = "";
                    this.PopupContainerPurchase.InnerHtml = "";
                    for (int i = 0; i < salesDailyReportData.Rows.Count; i++)
                    {
                        DateTime dateTime1 = Convert.ToDateTime(salesDailyReportData.Rows[i]["date_challan"]);
                        empty = this.loadDetailData(dateTime1, num);
                        HtmlGenericControl popupContainer = this.PopupContainer;
                        popupContainer.InnerHtml = string.Concat(popupContainer.InnerHtml, empty);
                        decimal num9 = Convert.ToDecimal(salesDailyReportData.Rows[i]["price"]);
                        decimal num10 = Convert.ToDecimal(salesDailyReportData.Rows[i]["vat"]);
                        decimal num11 = num9 + num10;
                        DataTable salesDailyDetailReportData = this.dbBLL.GetSalesDailyDetailReportData(dateTime1);
                        decimal num12 = new decimal(0);
                        decimal num13 = new decimal(0);
                        decimal num14 = new decimal(0);
                        decimal num15 = new decimal(0);
                        if (salesDailyDetailReportData.Rows.Count <= 0)
                        {
                            num12 = Convert.ToDecimal(salesDailyReportData.Rows[0]["sd"]);
                        }
                        else
                        {
                            for (int j = 0; j < salesDailyDetailReportData.Rows.Count; j++)
                            {
                                num13 = Convert.ToDecimal(salesDailyDetailReportData.Rows[j]["sd"]);
                                num12 += num13;
                                if (salesDailyDetailReportData.Rows[j]["trans_type"].ToString() != "E")
                                {
                                    num14 = num14++;
                                }
                                else
                                {
                                    num15 = num15++;
                                }
                            }
                        }
                        num11 += num12;
                        str1 = string.Concat(str1, "<tr style = 'background-color: White'>");
                        int num16 = i + 1;
                        str1 = string.Concat(str1, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", num16.ToString(), "</td>");
                        str1 = string.Concat(str1, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", dateTime1.ToString("dd/MM/yyyy"), "</td>");
                        object obj = str1;
                        object[] objArray = new object[] { obj, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", num14, "</td>" };
                        str1 = string.Concat(objArray);
                        object obj1 = str1;
                        object[] objArray1 = new object[] { obj1, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", num15, "</td>" };
                        str1 = string.Concat(objArray1);
                        str1 = string.Concat(str1, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(salesDailyReportData.Rows[i]["price"]), num), "</td>");
                        str1 = string.Concat(str1, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(salesDailyReportData.Rows[i]["vat"].ToString()), num), "</td>");
                        str1 = string.Concat(str1, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num12, num), "</td>");
                        str1 = string.Concat(str1, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num11, num), "</td>");
                        string str3 = str1;
                        string[] strArrays1 = new string[] { str3, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px;'><a href='#PopupContent_", dateTime1.ToString("ddMMyyyy"), "' data-toggle='modal' data-target='#PopupContent_", dateTime1.ToString("ddMMyyyy"), "'>Details</a></td>" };
                        str1 = string.Concat(strArrays1);
                        num1 += Convert.ToDecimal(salesDailyReportData.Rows[i]["price"]);
                        num2 += Convert.ToDecimal(salesDailyReportData.Rows[i]["vat"]);
                        num3 += num12;
                        num4 += num11;
                    }
                    str1 = string.Concat(str1, "</tr>");
                    str1 = string.Concat(str1, "<tr style='background-color: White'>");
                    str1 = string.Concat(str1, "<th colspan='4' style='text-align:center'>Total</th>");
                    str1 = string.Concat(str1, "<td  align='right'>", Utilities.RoundUpToWithString(num1, num), "</td>");
                    str1 = string.Concat(str1, "<td  align='right'>", Utilities.RoundUpToWithString(num2, num), "</td>");
                    str1 = string.Concat(str1, "<td  align='right'>", Utilities.RoundUpToWithString(num3, num), "</td>");
                    str1 = string.Concat(str1, "<td  align='right'>", Utilities.RoundUpToWithString(num4, num), "</td>");
                    str1 = string.Concat(str1, "<td  align='right'></td>");
                    str1 = string.Concat(str1, "</tr>");
                    this.lblleisureShow.Text = str1;
                }
                DataTable purchaseDailyReportData = this.dbBLL.GetPurchaseDailyReportData(minValue, dateTime);
                if (purchaseDailyReportData.Rows.Count > 0)
                {
                    for (int k = 0; k < purchaseDailyReportData.Rows.Count; k++)
                    {
                        DateTime dateTime2 = Convert.ToDateTime(purchaseDailyReportData.Rows[k]["date_challan"]);
                        str = this.loadDetailPurchaseData(dateTime2);
                        HtmlGenericControl popupContainerPurchase = this.PopupContainerPurchase;
                        popupContainerPurchase.InnerHtml = string.Concat(popupContainerPurchase.InnerHtml, str);
                        decimal num17 = Convert.ToDecimal(purchaseDailyReportData.Rows[k]["price"]);
                        decimal num18 = Convert.ToDecimal(purchaseDailyReportData.Rows[k]["vat"]);
                        decimal num19 = num17 + num18;
                        DataTable purchaseDailyDetailReportData = this.dbBLL.GetPurchaseDailyDetailReportData(dateTime2);
                        decimal num20 = new decimal(0);
                        decimal num21 = new decimal(0);
                        decimal num22 = new decimal(0);
                        decimal num23 = new decimal(0);
                        if (purchaseDailyDetailReportData.Rows.Count <= 0)
                        {
                            num20 = Convert.ToDecimal(salesDailyReportData.Rows[0]["purchase_sd"]);
                        }
                        else
                        {
                            for (int l = 0; l < purchaseDailyDetailReportData.Rows.Count; l++)
                            {
                                num21 = Convert.ToDecimal(purchaseDailyDetailReportData.Rows[l]["purchase_sd"]);
                                num20 += num21;
                                if (purchaseDailyDetailReportData.Rows[l]["purchase_type"].ToString() != "I")
                                {
                                    num23 = num23++;
                                }
                                else
                                {
                                    num22 = num22++;
                                }
                            }
                        }
                        num19 += num20;
                        str2 = string.Concat(str2, "<tr style = 'background-color: White'>");
                        int num24 = k + 1;
                        str2 = string.Concat(str2, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", num24.ToString(), "</td>");
                        str2 = string.Concat(str2, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", dateTime2.ToString("dd/MM/yyyy"), "</td>");
                        object obj2 = str2;
                        object[] objArray2 = new object[] { obj2, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", num23, "</td>" };
                        str2 = string.Concat(objArray2);
                        object obj3 = str2;
                        object[] objArray3 = new object[] { obj3, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", num22, "</td>" };
                        str2 = string.Concat(objArray3);
                        str2 = string.Concat(str2, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(purchaseDailyReportData.Rows[k]["price"]), num), "</td>");
                        str2 = string.Concat(str2, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(Convert.ToDecimal(purchaseDailyReportData.Rows[k]["vat"]), num), "</td>");
                        str2 = string.Concat(str2, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num20, num), "</td>");
                        str2 = string.Concat(str2, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px;'>", Utilities.RoundUpToWithString(num19, num), "</td>");
                        string str4 = str2;
                        string[] strArrays2 = new string[] { str4, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px;'><a href='#PopupContentp_", dateTime2.ToString("ddMMyyyy"), "' data-toggle='modal' data-target='#PopupContentp_", dateTime2.ToString("ddMMyyyy"), "'>Details</a></td>" };
                        str2 = string.Concat(strArrays2);
                        num5 += Convert.ToDecimal(purchaseDailyReportData.Rows[k]["price"]);
                        num6 += Convert.ToDecimal(purchaseDailyReportData.Rows[k]["vat"]);
                        num7 += num20;
                        num8 += num19;
                    }
                    str2 = string.Concat(str2, "</tr>");
                    str2 = string.Concat(str2, "<tr style='background-color: White'>");
                    str2 = string.Concat(str2, "<th colspan='4' style='text-align:center'>Total</th>");
                    str2 = string.Concat(str2, "<td  align='right'>", Utilities.RoundUpToWithString(num5, num), "</td>");
                    str2 = string.Concat(str2, "<td  align='right'>", Utilities.RoundUpToWithString(num6, num), "</td>");
                    str2 = string.Concat(str2, "<td  align='right'>", Utilities.RoundUpToWithString(num7, num), "</td>");
                    str2 = string.Concat(str2, "<td  align='right'>", Utilities.RoundUpToWithString(num8, num), "</td>");
                    str2 = string.Concat(str2, "<td  align='right'></td>");
                    str2 = string.Concat(str2, "</tr>");
                    this.lblPurchaseShow.Text = str2;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}