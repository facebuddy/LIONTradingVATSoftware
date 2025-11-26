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
    public partial class SaleSummaryMonthwises : Page, IRequiresSessionState
    {
        private PeriodicReportBLL dbBLL = new PeriodicReportBLL();

     

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

        public SaleSummaryMonthwises()
        {
        }

        private void fillChallanYearDrp()
        {
            int year = DateTime.Now.Year;
            int num = year - 4;
            this.drpChallanYear.Items.Add(num.ToString());
            int num1 = year - 3;
            this.drpChallanYear.Items.Add(num1.ToString());
            int num2 = year - 2;
            this.drpChallanYear.Items.Add(num2.ToString());
            int num3 = year - 1;
            this.drpChallanYear.Items.Add(num3.ToString());
            this.drpChallanYear.Items.Add(year.ToString());
            this.drpChallanYear.SelectedValue = year.ToString();
        }

        private void fillMonth()
        {
            string[] monthNames = DateTimeFormatInfo.InvariantInfo.MonthNames;
            this.drpMonth.DataSource = monthNames;
            this.drpMonth.DataBind();
            ListItem listItem = new ListItem("  --- Select ---   ", "-99");
            this.drpMonth.Items.Insert(0, listItem);
        }

        private DateTime GetFromDate(string year, string monthTo)
        {
            DateTime minValue = DateTime.MinValue;
            if (monthTo != "-99")
            {
                string str = string.Concat("01/", monthTo, "/", year);
                minValue = DateTime.ParseExact(str, "dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                string str1 = string.Concat("01/01/", year);
                minValue = DateTime.ParseExact(str1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            return minValue;
        }

        private string GetReportFromat(DataTable dt)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            string str = "";
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            string empty = string.Empty;
            string str1 = "";
            if (dt.Rows.Count > 0)
            {
                this.PopupContainer.InnerHtml = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    num1 = (!string.IsNullOrEmpty(dt.Rows[i]["price"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["price"]) : new decimal(0));
                    num2 = (!string.IsNullOrEmpty(dt.Rows[i]["vat"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["vat"]) : new decimal(0));
                    num3 = (!string.IsNullOrEmpty(dt.Rows[i]["sd"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["sd"]) : new decimal(0));
                    num4 = (!string.IsNullOrEmpty(dt.Rows[i]["total"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["total"]) : new decimal(0));
                    if (this.drpItem.SelectedValue == "-99")
                    {
                        this.item_nameS.Visible = false;
                    }
                    else
                    {
                        str1 = string.Concat(dt.Rows[i]["item_name"].ToString(), "-", dt.Rows[i]["hs_code"].ToString());
                        this.item_nameS.Visible = true;
                    }
                    string str2 = dt.Rows[i]["mon"].ToString().Trim();
                    empty = this.loadDetailData(str2, num);
                    HtmlGenericControl popupContainer = this.PopupContainer;
                    popupContainer.InnerHtml = string.Concat(popupContainer.InnerHtml, empty);
                    str = string.Concat(str, "<tr style = 'background-color: White'>");
                    if (str1 != "")
                    {
                        str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", str1, "</td>");
                    }
                    str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", dt.Rows[i]["mon"].ToString(), "</td>");
                    str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num1, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num2, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num3, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num4, num), "</td>");
                    string str3 = str;
                    string[] strArrays = new string[] { str3, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px;'><a href='#PopupContent_", dt.Rows[i]["mon"].ToString().Trim(), "' data-toggle='modal' data-target='#PopupContent_", dt.Rows[i]["mon"].ToString().Trim(), "'>Details</a></td>" };
                    str = string.Concat(strArrays);
                    str = string.Concat(str, "</tr>");
                }
            }
            return str;
        }

        private DateTime GetToDate(string year, string monthTo)
        {
            DateTime minValue = DateTime.MinValue;
            if (monthTo == "-99")
            {
                string str = string.Concat("31/12/", year);
                minValue = DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else if (monthTo == "APRIL" || monthTo == "JUNE" || monthTo == "SEPTEMBER" || monthTo == "NOVEMBER")
            {
                string str1 = string.Concat("30/", monthTo, "/", year);
                minValue = DateTime.ParseExact(str1, "dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            }
            else if (monthTo != "FEBRUARY")
            {
                string str2 = string.Concat("30/", monthTo, "/", year);
                minValue = DateTime.ParseExact(str2, "dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                string str3 = string.Concat("29/", monthTo, "/", year);
                minValue = DateTime.ParseExact(str3, "dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            }
            return minValue;
        }

        private string loadDetailData(string month, int precision)
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
            DateTime fromDate = this.GetFromDate(this.drpChallanYear.SelectedItem.ToString(), month);
            DateTime toDate = this.GetToDate(this.drpChallanYear.SelectedItem.ToString(), month);
            empty2 = "<thead style='text-align: center;'><tr style='text-align: center'> </tr><tr><th  style='text-align: center;'>Date</th><th style='text-align: center;'>Purchaser Name</th><th style='text-align: center;'>Challan No</th><th style='text-align: center;'>Challan Issue Time</th><th style='text-align: center;'>H.S Code</th><th style='text-align: center;'>Item Name</th><th style='text-align: center;'>Quantity</th><th style='text-align: center;'>Unit</th><th style='text-align: center;'>Unit Price</th><th style='text-align: center;'>Total Sale Amount</th><th style='text-align: center;'>Total VAT Amount</th><th style='text-align: center;'>Total SD Amount</th></tr></thead>";
            int num3 = Convert.ToInt32(this.drpItem.SelectedValue);
            DataTable salesMonthlyDetailReportData = this.dbBLL.GetSalesMonthlyDetailReportData(fromDate, toDate, num3);
            if (salesMonthlyDetailReportData.Rows.Count <= 0)
            {
                str = string.Concat("<div id='PopupContent_", month, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'><div class='modal-content' ><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body'>'Not Found'</div></div></div></div>");
            }
            else
            {
                for (int i = 0; i < salesMonthlyDetailReportData.Rows.Count; i++)
                {
                    num += Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["price"]);
                    num1 += Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["vat"]);
                    num2 += Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["sd"]);
                    DateTime dateTime = Convert.ToDateTime(salesMonthlyDetailReportData.Rows[i]["challanTime"]);
                    string str3 = dateTime.ToString("hh:mm tt");
                    string str4 = str1;
                    string[] withString = new string[26];
                    withString[0] = str4;
                    withString[1] = "<tbody><tr><td  style='text-align: center;padding:5px'>";
                    DateTime dateTime1 = Convert.ToDateTime(salesMonthlyDetailReportData.Rows[i]["date_challan"]);
                    withString[2] = dateTime1.ToString("dd/MM/yyyy");
                    withString[3] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[4] = salesMonthlyDetailReportData.Rows[i]["party_name"].ToString();
                    withString[5] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[6] = salesMonthlyDetailReportData.Rows[i]["challan_no"].ToString();
                    withString[7] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[8] = str3;
                    withString[9] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[10] = salesMonthlyDetailReportData.Rows[i]["hs_code"].ToString();
                    withString[11] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[12] = salesMonthlyDetailReportData.Rows[i]["item_name"].ToString();
                    withString[13] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[14] = Utilities.formatFraction(Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["quantity"].ToString()));
                    withString[15] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[16] = salesMonthlyDetailReportData.Rows[i]["unit_code"].ToString();
                    withString[17] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[18] = Utilities.RoundUpToWithString(Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["actual_price"]), precision);
                    withString[19] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[20] = Utilities.RoundUpToWithString(Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["price"]), precision);
                    withString[21] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[22] = Utilities.RoundUpToWithString(Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["vat"]), precision);
                    withString[23] = "</td><td  style='text-align:right;padding:5px'>";
                    withString[24] = Utilities.RoundUpToWithString(Convert.ToDecimal(salesMonthlyDetailReportData.Rows[i]["sd"]), precision);
                    withString[25] = "</td></tr></tbody>";
                    str1 = string.Concat(withString);
                }
                string str5 = str2;
                string[] strArrays = new string[] { str5, "<tr><td colspan='9' style='text-align: right;padding:5px; font-weight:bold;'>Total :</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num, precision), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num1, precision), "</td><td  style='text-align:right;padding:5px'>", Utilities.RoundUpToWithString(num2, precision), "</td></tr>" };
                str2 = string.Concat(strArrays);
                string[] strArrays1 = new string[] { "<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty2, str1, str2, "</table>" };
                empty1 = string.Concat(strArrays1);
                string[] strArrays2 = new string[] { "<div id='PopupContent_", month, "' class='modal fade in' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-dialog'  style='width:80%' ><div class='modal-content' id='eee1'><div class='modal-header'  id='modhead11' >", empty, "<button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'></h4></div><div class='modal-body' id='section-to-print' >", empty1, "</div></div></div></div>" };
                str = string.Concat(strArrays2);
            }
            return str;
        }

        private void LoadItems()
        {
            try
            {
                DataTable allItem = (new AddItemBLL()).GetAllItem();
                this.drpItem.DataSource = allItem;
                this.drpItem.DataTextField = allItem.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = allItem.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.TaxOrganizationName.Text = (this.Session["ORGANIZATION_NAME"] != null ? this.Session["ORGANIZATION_NAME"].ToString() : "n/a");
                this.TaxOrganizationAddress.Text = (this.Session["ORGANIZATION_ADDRESS"] != null ? this.Session["ORGANIZATION_ADDRESS"].ToString() : "n/a");
                this.TaxOrganizationBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.fillChallanYearDrp();
                this.fillMonth();
                this.LoadItems();
                this.lblYearSaleFrom.InnerText = this.drpChallanYear.SelectedItem.ToString();
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.lblleisureShow.Text = "";
                string empty = string.Empty;
                string str = string.Empty;
                DateTime minValue = DateTime.MinValue;
                DateTime toDate = DateTime.MinValue;
                DateTime dateTime = DateTime.MinValue;
                DateTime minValue1 = DateTime.MinValue;
                int num = 0;
                if (this.drpMonth.SelectedValue == "-99")
                {
                    this.lblYearSaleFrom.InnerText = this.drpChallanYear.SelectedItem.ToString();
                }
                else
                {
                    this.lblYearSaleFrom.InnerText = string.Concat(this.drpMonth.SelectedItem.ToString(), "-", this.drpChallanYear.SelectedItem.ToString());
                }
                minValue = this.GetFromDate(this.drpChallanYear.SelectedItem.ToString(), this.drpMonth.SelectedValue.ToString().ToUpper());
                toDate = this.GetToDate(this.drpChallanYear.SelectedItem.ToString(), this.drpMonth.SelectedValue.ToString().ToUpper());
                num = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable saleComparativeReportData = this.dbBLL.GetSaleComparativeReportData(minValue, toDate, this.drpMonth.SelectedValue, num);
                this.lblleisureShow.Text = this.GetReportFromat(saleComparativeReportData);
                this.lblHeading.Text = "Sale Summary Report";
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}