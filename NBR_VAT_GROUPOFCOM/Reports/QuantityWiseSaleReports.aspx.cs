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
    public partial class QuantityWiseSaleReports : Page, IRequiresSessionState
    {
        private AccountingBookBLL objAccountingBook = new AccountingBookBLL();




        public QuantityWiseSaleReports()
        {
        }

        private void LoadItem()
        {
            try
            {
                DataTable saleAllItem62 = this.objAccountingBook.GetSaleAllItem62();
                if (saleAllItem62.Rows.Count > 0)
                {
                    this.ddlItem.DataSource = saleAllItem62;
                    this.ddlItem.DataTextField = saleAllItem62.Columns["item_name"].ToString();
                    this.ddlItem.DataValueField = saleAllItem62.Columns["item_id"].ToString();
                    this.ddlItem.DataBind();
                    ListItem listItem = new ListItem("ALL", "-99");
                    this.ddlItem.Items.Insert(0, listItem);
                }
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
                this.rptPrint.Visible = false;
                this.dtpDateFrom.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.LoadItem();
            }
        }

        private void ReportGenerate()
        {
            try
            {
                this.rptPrint.Visible = true;
                string str = "";
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                int num7 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                decimal num8 = new decimal(0);
                int num9 = Convert.ToInt16(this.ddlItem.SelectedValue);
                DataTable saleQuantitywise = this.objAccountingBook.GetSaleQuantitywise(dateTime, dateTime1, num9);
                if (saleQuantitywise == null)
                {
                    this.lblReportHtml.Text = "";
                }
                else if (saleQuantitywise.Rows.Count <= 0)
                {
                    this.lblReportHtml.Text = "";
                }
                else
                {
                    for (int i = 0; i < saleQuantitywise.Rows.Count; i++)
                    {
                        num = Convert.ToDecimal(saleQuantitywise.Rows[i]["price"]);
                        num1 = Convert.ToDecimal(saleQuantitywise.Rows[i]["sd"]);
                        num2 = Convert.ToDecimal(saleQuantitywise.Rows[i]["vat"]);
                        num8 = (Convert.ToDecimal(saleQuantitywise.Rows[i]["weight"]) == new decimal(0) ? Convert.ToDecimal(saleQuantitywise.Rows[i]["quantity"]) * new decimal(1) : Convert.ToDecimal(saleQuantitywise.Rows[i]["quantity"]) * Convert.ToDecimal(saleQuantitywise.Rows[i]["weight"]));
                        str = string.Concat(str, "<tr>");
                        int num10 = i + 1;
                        str = string.Concat(str, "<td style='text-align:center;'>", Utilities.convertEnglistNumberIntoBangla(num10.ToString()), "</td>");
                        str = string.Concat(str, "<td>", saleQuantitywise.Rows[i]["item_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", saleQuantitywise.Rows[i]["hs_code"].ToString(), "</td>");
                        string str1 = str;
                        string[] strArrays = new string[] { str1, "<td  style='text-align:right;'>", Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(Convert.ToDecimal(Utilities.formatFraction(num8)), num7)), " (", saleQuantitywise.Rows[i]["unit_code"].ToString(), ") </td>" };
                        str = string.Concat(strArrays);
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num, num7))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num7))), "</td>");
                        str = string.Concat(str, "<td style='text-align:right;'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num2, num7))), "</td>");
                        str = string.Concat(str, "<td>", saleQuantitywise.Rows[i]["remarks"].ToString(), "</td>");
                        str = string.Concat(str, "</tr>");
                        num5 += num1;
                        num6 += num2;
                        num3 += num;
                        num4 += num8;
                    }
                    str = string.Concat(str, "<tr style='border:2px solid black;'>");
                    str = string.Concat(str, "<td colspan='3' style='text-align:right; padding:2px;font-weight:bold'>মোট</td>");
                    string str2 = str;
                    string[] strArrays1 = new string[] { str2, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num7)), " (", saleQuantitywise.Rows[0]["unit_code"].ToString(), ")</td>" };
                    str = string.Concat(strArrays1);
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num7))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num7))), "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.checkZero(Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num6, num7))), "</td>");
                    str = string.Concat(str, "<td></td>");
                    str = string.Concat(str, "<tr>");
                    this.lblReportHtml.Text = str;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void showReport_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.ReportGenerate();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}