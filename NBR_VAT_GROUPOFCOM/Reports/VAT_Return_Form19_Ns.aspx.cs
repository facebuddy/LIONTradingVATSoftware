using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

public class Reports_VAT_Return_Form19_Ns : Page, IRequiresSessionState
{
    protected TextBox dtpDateFrom;

    protected CalendarExtender cc11;

    protected TextBox dtpDateTo;

    protected CalendarExtender CalendarExtender1;

    protected LinkButton btnShow;

    protected LinkButton btnPrint;

    protected LinkButton btnXMLFormat;

    protected Label month;

    protected Label year;

    protected Label orgBIN;

    protected Label orgName;

    protected Label orgAddress;

    protected Label txtPhone;

    protected Label localSalePrice;

    protected Label localSaleSD;

    protected Label localSaleVat;

    protected Label exportPrice;

    protected Label Label101;

    protected Label Label102;

    protected Label saleExamptedPrice;

    protected Label Label103;

    protected Label Label104;

    protected Label totalSaleTax;

    protected Label otherSaleTax;

    protected Label saleTotal;

    protected Label localPurchasePrice;

    protected Label localPurchaseRebat;

    protected Label importPrice;

    protected Label importRebat;

    protected Label Label11;

    protected Label exportRebat;

    protected Label purchaseExempted;

    protected Label Label16;

    protected Label totalRebat;

    protected Label other12;

    protected Label prevMonthValue;

    protected Label grandTotalRebat;

    protected Label netPayment;

    protected Label treasuryPaymentTax;

    protected Label nextMonthJer;

    protected Label Label24;

    protected Label VDS_19;

    protected Label lblDate;

    protected HtmlGenericControl rpVatReturn;

    protected UpdatePanel upContent;

    private VATReturnBLL objVatReturn = new VATReturnBLL();

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

    public Reports_VAT_Return_Form19_Ns()
    {
    }

    protected void btnShow_OnClick(object sender, EventArgs e)
    {
        this.ShowReport();
    }

    protected void btnXMLFormat_OnClick(object sender, EventArgs e)
    {
        this.xmlVAT19();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.lblDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
            this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.orgName.Text = (this.Session["ORGANIZATION_NAME"] != null ? this.Session["ORGANIZATION_NAME"].ToString() : "n/a");
            this.orgAddress.Text = (this.Session["ORGANIZATION_ADDRESS"] != null ? this.Session["ORGANIZATION_ADDRESS"].ToString() : "n/a");
            string str = this.Session["ORGANIZATION_BIN"].ToString();
            string str1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                object obj = str1;
                object[] objArray = new object[] { obj, "<input type='text' value = '", str[i], "' runat='server' style='width:25px; text-align:center;border:1px solid #000'>" };
                str1 = string.Concat(objArray);
                this.orgBIN.Text = str1;
            }
            this.txtPhone.Text = this.Session["MOBILE_NO"].ToString();
            Label label = this.month;
            DateTime dateTime = DateTime.Now.AddMonths(-1);
            label.Text = dateTime.ToString("MMMM");
            this.year.Text = DateTime.Now.Year.ToString();
        }
    }

    private void ShowReport()
    {
        double num = 0;
        double num1 = 0;
        double num2 = 0;
        double num3 = 0;
        double num4 = 0;
        double num5 = 0;
        double num6 = 0;
        double num7 = 0;
        DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime dateTime2 = dateTime1.AddDays(1);
        short num8 = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
        DataTable dataTable = this.objVatReturn.rptVATReturn(dateTime, dateTime2, num8);
        if (dataTable.Rows.Count > 0)
        {
            num6 = Convert.ToDouble(dataTable.Rows[0]["other_adjustment"]) + Convert.ToDouble(dataTable.Rows[0]["vds_amount_19"]);
            Label str = this.localSalePrice;
            double num9 = Convert.ToDouble(dataTable.Rows[0]["sale_price"]) - Convert.ToDouble(dataTable.Rows[0]["credit_balance"]);
            str.Text = num9.ToString("0.00");
            Label label = this.localSaleSD;
            double num10 = Convert.ToDouble(dataTable.Rows[0]["sale_sd"]) - Convert.ToDouble(dataTable.Rows[0]["credit_sd"]);
            label.Text = num10.ToString("0.00");
            Label str1 = this.localSaleVat;
            double num11 = Convert.ToDouble(dataTable.Rows[0]["sale_vat"]) - Convert.ToDouble(dataTable.Rows[0]["credit_vat"]);
            str1.Text = num11.ToString("0.00");
            num7 = Convert.ToDouble(dataTable.Rows[0]["sale_exmp"]);
            Label label1 = this.exportPrice;
            double num12 = num7 / 78;
            label1.Text = string.Concat("US$-", num12.ToString("0.00"));
            this.saleExamptedPrice.Text = dataTable.Rows[0]["exmp_item_sale"].ToString();
            num = Convert.ToDouble(dataTable.Rows[0]["sale_sd"]) + Convert.ToDouble(dataTable.Rows[0]["sale_vat"]);
            this.totalSaleTax.Text = num.ToString("0.00");
            this.otherSaleTax.Text = num6.ToString("0.00");
            num1 = num + num6;
            this.saleTotal.Text = num1.ToString("0.00");
            this.localPurchasePrice.Text = dataTable.Rows[0]["purchase_value"].ToString();
            this.localPurchaseRebat.Text = dataTable.Rows[0]["rebatable_tax"].ToString();
            this.importPrice.Text = dataTable.Rows[0]["purchase_value_import"].ToString();
            this.importRebat.Text = dataTable.Rows[0]["rebatable_tax_import"].ToString();
            this.exportRebat.Text = dataTable.Rows[0]["rebate_on_export"].ToString();
            this.purchaseExempted.Text = dataTable.Rows[0]["purchase"].ToString();
            num2 = Convert.ToDouble(dataTable.Rows[0]["rebatable_tax"]) + Convert.ToDouble(dataTable.Rows[0]["rebatable_tax_import"]) + Convert.ToDouble(dataTable.Rows[0]["rebate_on_export"]);
            this.totalRebat.Text = num2.ToString("0.00");
            this.other12.Text = dataTable.Rows[0]["other_adj_purchase"].ToString();
            this.prevMonthValue.Text = dataTable.Rows[0]["pre_m_cls_b"].ToString();
            num3 = num2 + Convert.ToDouble(dataTable.Rows[0]["other_adj_purchase"]) + Convert.ToDouble(dataTable.Rows[0]["pre_m_cls_b"]);
            this.grandTotalRebat.Text = num3.ToString("0.00");
            num4 = num1 - num3;
            this.netPayment.Text = num4.ToString("0.00");
            num5 = Convert.ToDouble(dataTable.Rows[0]["treasury_deposit"]) + Convert.ToDouble(dataTable.Rows[0]["return_tax_office"]) + Convert.ToDouble(dataTable.Rows[0]["ts_tax_deduct"]);
            this.treasuryPaymentTax.Text = num5.ToString("0.00");
            double num13 = num5 - num4;
            this.nextMonthJer.Text = num13.ToString("0.00");
            this.VDS_19.Text = dataTable.Rows[0]["vds_amount_19"].ToString();
        }
    }

    private void xmlVAT19()
    {
        double num = 0;
        DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime dateTime2 = dateTime1.AddDays(1);
        short num1 = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
        try
        {
            DataTable dataTable = this.objVatReturn.rptVATReturn(dateTime, dateTime2, num1);
            if (dataTable != null)
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlNode xmlNodes = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(xmlNodes);
                XmlElement xmlElement = xmlDocument.CreateElement("ArrayOfVAT_18");
                xmlDocument.AppendChild(xmlElement);
                num = Convert.ToDouble(dataTable.Rows[0]["other_adjustment"]) + Convert.ToDouble(dataTable.Rows[0]["vds_amount_19"]);
                decimal num2 = Convert.ToDecimal(dataTable.Rows[0]["sale_sd"].ToString()) + Convert.ToDecimal(dataTable.Rows[0]["sale_vat"].ToString());
                decimal num3 = num2 + Convert.ToDecimal(dataTable.Rows[0]["other_adjustment"].ToString());
                decimal num4 = (Convert.ToDecimal(dataTable.Rows[0]["rebatable_tax"].ToString()) + Convert.ToDecimal(dataTable.Rows[0]["rebatable_tax_import"].ToString())) + Convert.ToDecimal(dataTable.Rows[0]["rebate_on_export"].ToString());
                decimal num5 = (num4 + Convert.ToDecimal(dataTable.Rows[0]["other_adj_purchase"].ToString())) + Convert.ToDecimal(dataTable.Rows[0]["pre_m_cls_b"].ToString());
                decimal num6 = ((((Convert.ToDecimal(dataTable.Rows[0]["rebatable_tax"].ToString()) + Convert.ToDecimal(dataTable.Rows[0]["rebatable_tax_import"].ToString())) + Convert.ToDecimal(dataTable.Rows[0]["rebate_on_export"].ToString())) + Convert.ToDecimal(dataTable.Rows[0]["other_adj_purchase"].ToString())) + Convert.ToDecimal(dataTable.Rows[0]["pre_m_cls_b"].ToString())) + Convert.ToDecimal(dataTable.Rows[0]["treasury_deposit"].ToString());
                decimal num7 = (Convert.ToDecimal(dataTable.Rows[0]["sale_sd"].ToString()) + Convert.ToDecimal(dataTable.Rows[0]["sale_vat"].ToString())) + Convert.ToDecimal(dataTable.Rows[0]["other_adjustment"].ToString());
                decimal num8 = Math.Round(num6 - num7, 2);
                XmlNode xmlNodes1 = csXML.XmlHelper.AddElement("VAT19", null, xmlElement);
                csXML.XmlHelper.AddElement("sessionvalue", "999", xmlNodes1);
                csXML.XmlHelper.AddElement("VatRegistrationNo", this.Session["ORGANIZATION_BIN"].ToString(), xmlNodes1);
                decimal num9 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["sale_price"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column1A", num9.ToString(), xmlNodes1);
                decimal num10 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["sale_sd"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column1B", num10.ToString(), xmlNodes1);
                decimal num11 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["sale_vat"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column1C", num11.ToString(), xmlNodes1);
                decimal num12 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["sale_exmp"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column2A", num12.ToString(), xmlNodes1);
                decimal num13 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["sale_exmp_sd"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column2B", num13.ToString(), xmlNodes1);
                decimal num14 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["sale_exmp_vat"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column2C", num14.ToString(), xmlNodes1);
                decimal num15 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["exmp_item_sale"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column3", num15.ToString(), xmlNodes1);
                decimal num16 = Math.Round(num2, 2);
                csXML.XmlHelper.AddElement("Column4", num16.ToString(), xmlNodes1);
                decimal num17 = Math.Round(Convert.ToDecimal(num.ToString()), 2);
                csXML.XmlHelper.AddElement("Column5", num17.ToString(), xmlNodes1);
                decimal num18 = Math.Round(num3, 2);
                csXML.XmlHelper.AddElement("Column6", num18.ToString(), xmlNodes1);
                decimal num19 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["purchase_value"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column7A", num19.ToString(), xmlNodes1);
                decimal num20 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["rebatable_tax"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column7B", num20.ToString(), xmlNodes1);
                decimal num21 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["purchase_value_import"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column8A", num21.ToString(), xmlNodes1);
                decimal num22 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["rebatable_tax_import"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column8B", num22.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("Column9A", "0", xmlNodes1);
                decimal num23 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["rebate_on_export"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column9B", num23.ToString(), xmlNodes1);
                decimal num24 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["purchase"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column10", num24.ToString(), xmlNodes1);
                decimal num25 = Math.Round(num4, 2);
                csXML.XmlHelper.AddElement("Column11", num25.ToString(), xmlNodes1);
                decimal num26 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["other_adj_purchase"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column12", num26.ToString(), xmlNodes1);
                decimal num27 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["pre_m_cls_b"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column13", num27.ToString(), xmlNodes1);
                decimal num28 = Math.Round(num5, 2);
                csXML.XmlHelper.AddElement("Column14", num28.ToString(), xmlNodes1);
                decimal num29 = Math.Round(num3 - num5, 2);
                csXML.XmlHelper.AddElement("Column15", num29.ToString(), xmlNodes1);
                decimal num30 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["treasury_deposit"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column16", num30.ToString(), xmlNodes1);
                decimal num31 = Math.Round(num8, 2);
                csXML.XmlHelper.AddElement("Column17", num31.ToString(), xmlNodes1);
                decimal num32 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["return_tax_office"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column18", num32.ToString(), xmlNodes1);
                decimal num33 = Math.Round(Convert.ToDecimal(dataTable.Rows[0]["ts_tax_deduct"].ToString()), 2);
                csXML.XmlHelper.AddElement("Column19", num33.ToString(), xmlNodes1);
                xmlDocument.Save(base.Server.MapPath("VAT_19.xml"));
                string fullPath = Path.GetFullPath(base.Server.MapPath("VAT_19.xml"));
                FileInfo fileInfo = new FileInfo(fullPath);
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Cache.SetCacheability(HttpCacheability.Private);
                response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
                response.ContentType = "application/xml";
                response.WriteFile(fullPath);
                response.End();
            }
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }
}