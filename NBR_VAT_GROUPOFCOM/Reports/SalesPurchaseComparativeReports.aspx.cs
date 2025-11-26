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
    public partial class SalesPurchaseComparativeReports : Page, IRequiresSessionState
    {
        private PeriodicReportBLL dbBLL = new PeriodicReportBLL();

        protected DropDownList drpChallanYear;

       
       
        public SalesPurchaseComparativeReports()
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
            this.drpChallanYear.SelectedValue = (year - 1).ToString();
        }

        private void fillChallanYearDrpTo()
        {
            int year = DateTime.Now.Year;
            int num = year - 4;
            this.drpChallanYearTo.Items.Add(num.ToString());
            int num1 = year - 3;
            this.drpChallanYearTo.Items.Add(num1.ToString());
            int num2 = year - 2;
            this.drpChallanYearTo.Items.Add(num2.ToString());
            int num3 = year - 1;
            this.drpChallanYearTo.Items.Add(num3.ToString());
            this.drpChallanYearTo.Items.Add(year.ToString());
            this.drpChallanYearTo.SelectedValue = year.ToString();
        }

        private void fillMonth()
        {
            string[] monthNames = DateTimeFormatInfo.InvariantInfo.MonthNames;
            this.drpMonth.DataSource = monthNames;
            this.drpMonth.DataBind();
            ListItem listItem = new ListItem("  --- Select ---   ", "-99");
            this.drpMonth.Items.Insert(0, listItem);
        }

        private void fillMonthTo()
        {
            string[] monthNames = DateTimeFormatInfo.InvariantInfo.MonthNames;
            this.drpMonthTo.DataSource = monthNames;
            this.drpMonthTo.DataBind();
            ListItem listItem = new ListItem("  --- Select ---   ", "-99");
            this.drpMonthTo.Items.Insert(0, listItem);
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

        private string GetReportFromat(DataTable dt, DataTable dtRightValue)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            string str = "";
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            string str1 = "";
            string str2 = "";
            string str3 = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    num1 = (!string.IsNullOrEmpty(dt.Rows[i]["price"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["price"]) : new decimal(0));
                    num2 = (!string.IsNullOrEmpty(dt.Rows[i]["vat"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["vat"]) : new decimal(0));
                    num3 = (!string.IsNullOrEmpty(dt.Rows[i]["sd"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["sd"]) : new decimal(0));
                    num4 = (!string.IsNullOrEmpty(dt.Rows[i]["total"].ToString()) ? Convert.ToDecimal(dt.Rows[i]["total"]) : new decimal(0));
                    if (dtRightValue.Rows.Count > 0)
                    {
                        str1 = dtRightValue.Rows[i]["mon"].ToString();
                        num5 = (!string.IsNullOrEmpty(dtRightValue.Rows[i]["price"].ToString()) ? Convert.ToDecimal(dtRightValue.Rows[i]["price"]) : new decimal(0));
                        num6 = (!string.IsNullOrEmpty(dtRightValue.Rows[i]["vat"].ToString()) ? Convert.ToDecimal(dtRightValue.Rows[i]["vat"]) : new decimal(0));
                        num7 = (!string.IsNullOrEmpty(dtRightValue.Rows[i]["sd"].ToString()) ? Convert.ToDecimal(dtRightValue.Rows[i]["sd"]) : new decimal(0));
                        num8 = (!string.IsNullOrEmpty(dtRightValue.Rows[i]["total"].ToString()) ? Convert.ToDecimal(dtRightValue.Rows[i]["total"]) : new decimal(0));
                        if (this.drpItem.SelectedValue == "-99")
                        {
                            this.item_nameS.Visible = false;
                            this.item_nameSComp.Visible = false;
                            this.item_namepCmop.Visible = false;
                            this.item_name.Visible = false;
                        }
                        else
                        {
                            str2 = string.Concat(dt.Rows[i]["item_name"].ToString(), "-", dt.Rows[i]["hs_code"].ToString());
                            str3 = string.Concat(dtRightValue.Rows[i]["item_name"].ToString(), "-", dtRightValue.Rows[i]["hs_code"].ToString());
                            this.item_name.Visible = true;
                            this.item_nameS.Visible = true;
                            this.item_nameSComp.Visible = true;
                            this.item_namepCmop.Visible = true;
                        }
                    }
                    str = string.Concat(str, "<tr style = 'background-color: White'>");
                    if (str2 != "")
                    {
                        str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", str2, "</td>");
                    }
                    str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", dt.Rows[i]["mon"].ToString(), "</td>");
                    str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num1, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num2, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num3, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num4, num), "</td>");
                    str = string.Concat(str, "<td></td>");
                    if (str3 != "")
                    {
                        str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", str3, "</td>");
                    }
                    str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", str1, "</td>");
                    str = string.Concat(str, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num5, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num6, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num7, num), "</td>");
                    str = string.Concat(str, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(num8, num), "</td>");
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
            else if (monthTo == "April" || monthTo == "June" || monthTo == "September" || monthTo == "November")
            {
                string str1 = string.Concat("30/", monthTo, "/", year);
                minValue = DateTime.ParseExact(str1, "dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            }
            else if (monthTo != "February")
            {
                string str2 = string.Concat("30/", monthTo, "/", year);
                minValue = DateTime.ParseExact(str2, "dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                string str3 = string.Concat("28/", monthTo, "/", year);
                minValue = DateTime.ParseExact(str3, "dd/MMMM/yyyy", CultureInfo.InvariantCulture);
            }
            return minValue;
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
                this.fillChallanYearDrpTo();
                this.fillMonthTo();
                this.LoadItems();
                this.lblYearPurchaseFrom.InnerText = this.drpChallanYear.SelectedItem.ToString();
                this.lblYearPurchaseTo.InnerText = this.drpChallanYearTo.SelectedItem.ToString();
                this.lblYearSaleFrom.InnerText = this.drpChallanYear.SelectedItem.ToString();
                this.lblYearSaleTo.InnerText = this.drpChallanYearTo.SelectedItem.ToString();
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.lblPurchaseShow.Text = "";
                this.lblleisureShow.Text = "";
                string empty = string.Empty;
                string str = string.Empty;
                DateTime minValue = DateTime.MinValue;
                DateTime toDate = DateTime.MinValue;
                DateTime fromDate = DateTime.MinValue;
                DateTime dateTime = DateTime.MinValue;
                int num = 0;
                if (!(this.drpMonth.SelectedValue != "-99") || !(this.drpMonthTo.SelectedValue != "-99"))
                {
                    this.lblYearSaleFrom.InnerText = this.drpChallanYear.SelectedItem.ToString();
                    this.lblYearSaleTo.InnerText = this.drpChallanYearTo.SelectedItem.ToString();
                    this.lblYearPurchaseFrom.InnerText = this.drpChallanYear.SelectedItem.ToString();
                    this.lblYearPurchaseTo.InnerText = this.drpChallanYearTo.SelectedItem.ToString();
                }
                else
                {
                    this.lblYearPurchaseFrom.InnerText = string.Concat(this.drpMonth.SelectedItem.ToString(), "-", this.drpChallanYear.SelectedItem.ToString());
                    this.lblYearPurchaseTo.InnerText = string.Concat(this.drpMonthTo.SelectedItem.ToString(), "-", this.drpChallanYearTo.SelectedItem.ToString());
                    this.lblYearSaleFrom.InnerText = string.Concat(this.drpMonth.SelectedItem.ToString(), "-", this.drpChallanYear.SelectedItem.ToString());
                    this.lblYearSaleTo.InnerText = string.Concat(this.drpMonthTo.SelectedItem.ToString(), "-", this.drpChallanYearTo.SelectedItem.ToString());
                }
                minValue = this.GetFromDate(this.drpChallanYear.SelectedItem.ToString(), this.drpMonth.SelectedValue.ToString());
                toDate = this.GetToDate(this.drpChallanYear.SelectedItem.ToString(), this.drpMonth.SelectedValue.ToString());
                fromDate = this.GetFromDate(this.drpChallanYearTo.SelectedItem.ToString(), this.drpMonthTo.SelectedValue.ToString());
                dateTime = this.GetToDate(this.drpChallanYearTo.SelectedItem.ToString(), this.drpMonthTo.SelectedValue.ToString());
                num = Convert.ToInt32(this.drpItem.SelectedValue);
                if (this.drpType.SelectedValue == "1")
                {
                    DataTable purchaseComparativeReportData = this.dbBLL.GetPurchaseComparativeReportData(minValue, toDate, this.drpMonth.SelectedValue, num);
                    DataTable dataTable = this.dbBLL.GetPurchaseComparativeReportData(fromDate, dateTime, this.drpMonth.SelectedValue, num);
                    this.lblPurchaseShow.Text = this.GetReportFromat(purchaseComparativeReportData, dataTable);
                    this.lblHeading.Text = "Purchase Comparative Report";
                }
                else if (this.drpType.SelectedValue != "2")
                {
                    DataTable purchaseComparativeReportData1 = this.dbBLL.GetPurchaseComparativeReportData(minValue, toDate, this.drpMonth.SelectedValue, num);
                    DataTable dataTable1 = this.dbBLL.GetPurchaseComparativeReportData(fromDate, dateTime, this.drpMonth.SelectedValue, num);
                    this.lblPurchaseShow.Text = this.GetReportFromat(purchaseComparativeReportData1, dataTable1);
                    DataTable saleComparativeReportData = this.dbBLL.GetSaleComparativeReportData(minValue, toDate, this.drpMonth.SelectedValue, num);
                    DataTable saleComparativeReportData1 = this.dbBLL.GetSaleComparativeReportData(fromDate, dateTime, this.drpMonth.SelectedValue, num);
                    this.lblleisureShow.Text = this.GetReportFromat(saleComparativeReportData, saleComparativeReportData1);
                    this.lblHeading.Text = "Sale - Purchase Comparative Report";
                }
                else
                {
                    DataTable saleComparativeReportData2 = this.dbBLL.GetSaleComparativeReportData(minValue, toDate, this.drpMonth.SelectedValue, num);
                    DataTable dataTable2 = this.dbBLL.GetSaleComparativeReportData(fromDate, dateTime, this.drpMonth.SelectedValue, num);
                    this.lblleisureShow.Text = this.GetReportFromat(saleComparativeReportData2, dataTable2);
                    this.lblHeading.Text = "Sale Comparative Report";
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}