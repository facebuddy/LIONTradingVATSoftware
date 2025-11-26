using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.UI.Audit
{
    public partial class ProductionNSalesStatements : Page, IRequiresSessionState
    {
        private AccountingBookBLL objACBLL = new AccountingBookBLL();

        private string Format = "dd/MM/yyyy";

        private CultureInfo provider = CultureInfo.InvariantCulture;

     



        public ProductionNSalesStatements()
        {
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.fromDate.Text) || string.IsNullOrEmpty(this.toDate.Text))
            {
                this.msgBox.AddMessage(" Enter from date and to date ", MsgBoxs.enmMessageType.Attention);
                return;
            }
            this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            this.lblUser.Text = this.Session["employee_name"].ToString();
            DateTime dateTime = DateTime.ParseExact(this.fromDate.Text.ToString(), this.Format, this.provider);
            DateTime dateTime1 = DateTime.ParseExact(this.toDate.Text.ToString(), this.Format, this.provider);
            DateTime dateTime2 = dateTime1.AddDays(1);
            this.lfDate.Text = dateTime.ToString("dd-MMM-yyyy");
            this.ltDate.Text = dateTime1.ToString("dd-MMM-yyyy");
            this.loadReport(dateTime, dateTime2);
            this.btnPrint.Visible = true;
        }

        private void loadIngredients()
        {
            try
            {
                DataTable allIngredients = this.objACBLL.getAllIngredients();
                int count = allIngredients.Rows.Count;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadReport(DateTime fDate, DateTime tDate)
        {
            string str = "";
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            try
            {
                trnsPurchaseMasterBLL _trnsPurchaseMasterBLL = new trnsPurchaseMasterBLL();
                decimal totalProPrice = new decimal(0);
                decimal num6 = new decimal(0);
                AccountingBookBLL accountingBookBLL = new AccountingBookBLL();
                int num7 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                DataTable allIngredientsByDate = this.objACBLL.GetAllIngredientsByDate(fDate, tDate);
                if (allIngredientsByDate.Rows.Count <= 0)
                {
                    this.lblReportHtml.Text = str;
                    this.msgBox.AddMessage(" Data Not Found ", MsgBoxs.enmMessageType.Attention);
                }
                else
                {
                    for (int i = 0; i < allIngredientsByDate.Rows.Count; i++)
                    {
                        int num8 = Convert.ToInt32(allIngredientsByDate.Rows[i]["item_id"].ToString());
                        DataTable detailData = this.objACBLL.GetDetailData(fDate, tDate, num8);
                        if (detailData.Rows.Count > 0)
                        {
                            num = Convert.ToDecimal(detailData.Rows[0]["pre_amount"]);
                            num1 = Convert.ToDecimal(detailData.Rows[0]["imp_amount"]);
                            num2 = Convert.ToDecimal(detailData.Rows[0]["bin_amount"]);
                            num3 = Convert.ToDecimal(detailData.Rows[0]["nobin_amount"]);
                            num4 = Convert.ToDecimal(detailData.Rows[0]["total_amount"]);
                            Convert.ToDecimal(detailData.Rows[0]["pro_amount"]);
                            num5 = Convert.ToDecimal(detailData.Rows[0]["last_amount"]);
                            DataTable itemLotInfo = _trnsPurchaseMasterBLL.GetItemLotInfo(num8);
                            num6 = Convert.ToDecimal(detailData.Rows[0]["pro_quantity"]);
                            totalProPrice = accountingBookBLL.getTotalProPrice(itemLotInfo, num6);
                            str = string.Concat(str, "<tr>");
                            str = string.Concat(str, "<td>", detailData.Rows[0]["item_name"].ToString(), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(detailData.Rows[0]["pre_quantity"])), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num, num7), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(detailData.Rows[0]["imp_quantity"])), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num1, num7), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(detailData.Rows[0]["bin_quantity"])), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num2, num7), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(detailData.Rows[0]["nobin_quantity"])), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num3, num7), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(detailData.Rows[0]["total_quantity"])), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num4, num7), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(detailData.Rows[0]["pro_quantity"])), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(totalProPrice, num7), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(detailData.Rows[0]["last_quantity"])), "</td>");
                            str = string.Concat(str, "<td style='text-align:right;padding-right:5px'>", Utilities.RoundUpToWithString(num5, num7), " </td>");
                            str = string.Concat(str, "</tr>");
                        }
                        this.lblReportHtml.Text = str;
                    }
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
                this.fromDate.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.toDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
    }
}