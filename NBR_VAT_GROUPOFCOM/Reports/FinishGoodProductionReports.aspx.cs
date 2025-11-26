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
    public partial class FinishGoodProductionReports : Page, IRequiresSessionState
    {


     

        public FinishGoodProductionReports()
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            try
            {
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str = dateTime.ToString("yyyy-MM-dd");
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str1 = dateTime1.AddDays(1).ToString("yyyy-MM-dd");
                DataTable finishProduct = contructualProductionBLL.getFinishProduct(str, str1);
                if (finishProduct != null && finishProduct.Rows.Count > 0)
                {
                    this.drpIngredient.DataSource = finishProduct;
                    this.drpIngredient.DataTextField = finishProduct.Columns["item_name"].ToString();
                    this.drpIngredient.DataValueField = finishProduct.Columns["item_id"].ToString();
                    this.drpIngredient.DataBind();
                    ListItem listItem = new ListItem("--- Select ---", "-99");
                    this.drpIngredient.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            long num;
            string text;
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            try
            {
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                str2 = dateTime.ToString("dd-MMM-yyyy");
                string str4 = dateTime.ToString("yyyy-MM-dd");
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                str3 = dateTime1.ToString("dd-MMM-yyyy");
                string str5 = dateTime1.AddDays(1).ToString("yyyy-MM-dd");
                if (this.drpIngredient.SelectedValue == "-99")
                {
                    num = (long)0;
                }
                else
                {
                    num = Convert.ToInt64(this.drpIngredient.SelectedValue);
                    str = string.Concat("Item :", this.drpIngredient.SelectedItem.ToString());
                }
                if (this.txtChallanNumber.Text == "")
                {
                    text = "";
                }
                else
                {
                    text = this.txtChallanNumber.Text;
                    str1 = string.Concat("Challan No :", text);
                }
                Label label = this.lblParamaters;
                string[] strArrays = new string[] { "Date From :", str2, ",  Date To :", str3, " ", str, " ", str1 };
                label.Text = string.Concat(strArrays);
                DataTable finishProductReportData = contructualProductionBLL.getFinishProductReportData(str4, str5, num, text);
                int num1 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                if (finishProductReportData.Rows.Count > 0)
                {
                    string str6 = "";
                    decimal num2 = new decimal(0);
                    decimal num3 = new decimal(0);
                    decimal num4 = new decimal(0);
                    decimal num5 = new decimal(0);
                    for (int i = 0; i < finishProductReportData.Rows.Count; i++)
                    {
                        str6 = string.Concat(str6, "<tr>");
                        str6 = string.Concat(str6, "<td>", finishProductReportData.Rows[i]["challan_no"].ToString(), "</td>");
                        str6 = string.Concat(str6, "<td>", finishProductReportData.Rows[i]["challan_date"].ToString(), "</td>");
                        str6 = string.Concat(str6, "<td>", finishProductReportData.Rows[i]["item_name"].ToString(), "</td>");
                        str6 = string.Concat(str6, "<td>", finishProductReportData.Rows[i]["unit_name"].ToString(), "</td>");
                        str6 = string.Concat(str6, "<td style='text-align:right;'>", Utilities.formatFraction(Convert.ToDecimal(finishProductReportData.Rows[i]["quantity"])), "</td>");
                        str6 = string.Concat(str6, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(Convert.ToDecimal(finishProductReportData.Rows[i]["sale_unit_price"]), num1), "</td>");
                        str6 = string.Concat(str6, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(Convert.ToDecimal(finishProductReportData.Rows[i]["total_price"]), num1), "</td>");
                        str6 = string.Concat(str6, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(Convert.ToDecimal(finishProductReportData.Rows[i]["sale_sd"]), num1), "</td>");
                        str6 = string.Concat(str6, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(Convert.ToDecimal(finishProductReportData.Rows[i]["sale_vat"]), num1), "</td>");
                        str6 = string.Concat(str6, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(Convert.ToDecimal(finishProductReportData.Rows[i]["total_price_vat_sd"]), num1), "</td>");
                        str6 = string.Concat(str6, "</tr>");
                        num2 += Convert.ToDecimal(finishProductReportData.Rows[i]["total_price"].ToString());
                        num4 += Convert.ToDecimal(finishProductReportData.Rows[i]["sale_sd"].ToString());
                        num3 += Convert.ToDecimal(finishProductReportData.Rows[i]["sale_vat"].ToString());
                        num5 += Convert.ToDecimal(finishProductReportData.Rows[i]["total_price_vat_sd"].ToString());
                    }
                    str6 = string.Concat(str6, "<tr>");
                    str6 = string.Concat(str6, "<td colspan='6' style='text-align:right; padding:2px;font-weight:bold'>মোট :</td>");
                    str6 = string.Concat(str6, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.RoundUpToWithString(num2, num1), "</td>");
                    str6 = string.Concat(str6, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.RoundUpToWithString(num4, num1), "</td>");
                    str6 = string.Concat(str6, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.RoundUpToWithString(num3, num1), "</td>");
                    str6 = string.Concat(str6, "<td style='text-align:right; padding:2px;font-weight:bold'>", Utilities.RoundUpToWithString(num5, num1), "</td>");
                    str6 = string.Concat(str6, "<tr>");
                    this.lblFinishProductRpt.Text = str6;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!base.IsPostBack)
                {
                    this.lblOrgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgBin.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    ListItem listItem = new ListItem("--- Select ---", "-99");
                    this.drpIngredient.Items.Insert(0, listItem);
                    this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
                    this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}