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


namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class Summary_Of_Value_Additions : Page, IRequiresSessionState
    {
       
        

    

        private SetItemBLL ItemBll = new SetItemBLL();

        private PriceDeclaretionBLL objPDBLL = new PriceDeclaretionBLL();

        private SetCountryBLL scBLL = new SetCountryBLL();

        private DateTime fromDate = DateTime.MinValue;

        private DateTime toDate = DateTime.MinValue;

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

        public Summary_Of_Value_Additions()
        {
        }

        private void clearAll()
        {
            this.FillDropdown();
        }

        protected void dtpFromDate_TextChanged(object sender, EventArgs e)
        {
            this.FillDropdown();
        }

        protected void dtpToDate_TextChanged(object sender, EventArgs e)
        {
            this.FillDropdown();
        }

        private void FillDropdown()
        {
            try
            {
                this.fromDate = DateTime.ParseExact(this.dtpFromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                this.toDate = DateTime.ParseExact(this.dtpToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                PriceDeclaretionBLL priceDeclaretionBLL = new PriceDeclaretionBLL();
                DataTable itemPriceWithDateFilter = priceDeclaretionBLL.getItemPriceWithDateFilter("M", this.fromDate, this.toDate);
                if (itemPriceWithDateFilter != null)
                {
                    this.ddlItem.DataSource = itemPriceWithDateFilter;
                    this.ddlItem.DataTextField = itemPriceWithDateFilter.Columns["Item_name"].ToString();
                    this.ddlItem.DataValueField = itemPriceWithDateFilter.Columns["price_id"].ToString();
                    this.ddlItem.DataBind();
                }
                ListItem listItem = new ListItem("---Select---", "-99");
                this.ddlItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadFullReport()
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            string str = "";
            int num1 = 0;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string withString = string.Empty;
            int num2 = 0;
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            int num8 = 0;
            if (this.ddlItem.SelectedValue != "-99")
            {
                string str1 = "";
                string str2 = "";
                str2 = Convert.ToString(this.ddlItem.SelectedItem);
                char[] chrArray = new char[] { '-' };
                str1 = str2.Split(chrArray)[1];
                if (str1 != " 2402.20.00")
                {
                    if (str1 == " 2402.90.00")
                    {
                        return;
                    }
                    DataTable dataTable = this.objPDBLL.rptPriceDeclarationFourPointThree(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
                    DataTable dataTable1 = this.objPDBLL.rptPriceDeclarationFourPointThreeKhat(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
                    DataTable totalValueAddPct = this.objPDBLL.GetTotalValueAddPct(Convert.ToInt32(this.ddlItem.SelectedItem.Value));
                    this.Session["PRICE_DECLARATION_01"] = dataTable;
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        str = "";
                        string empty2 = string.Empty;
                        string empty3 = string.Empty;
                        string str3 = string.Empty;
                        string empty4 = string.Empty;
                        string str4 = string.Empty;
                        string empty5 = string.Empty;
                        string str5 = string.Empty;
                        string withString1 = string.Empty;
                        string empty6 = string.Empty;
                        string str6 = string.Empty;
                        string withString2 = string.Empty;
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
                        string str12 = string.Empty;
                        string empty13 = string.Empty;
                        string str13 = string.Empty;
                        string empty14 = string.Empty;
                        Convert.ToDecimal(dataTable.Compute("SUM(Total_Purchase_Price_7)", string.Empty));
                        Convert.ToDecimal(dataTable.Compute("SUM(Value_Added_Per_Unit_9)", string.Empty));
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataTable.Rows[i]["Goods_Description_31"].ToString();
                            dataTable.Rows[i]["Raw_Materials_Name_5"].ToString();
                            string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["Raw_Meterials_Quantity_6n"])), dataTable.Rows[i]["Raw_Meterials_Quantity_6"].ToString());
                            withString1 = this.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["Total_Purchase_Price_7"]), num);
                            dataTable.Rows[i]["Value_Add_8"].ToString();
                            dataTable.Rows[i]["Value_Added_Per_Unit_9"].ToString();
                            withString2 = this.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["wastageparcent"]), num);
                            dataTable.Rows[i]["Price_With_SD_Present_10"].ToString();
                            dataTable.Rows[i]["Price_With_SD_Applied_11"].ToString();
                            dataTable.Rows[i]["SD_On_Applied_Price_12"].ToString();
                            dataTable.Rows[i]["VAT_Applicable_Price_Present_13"].ToString();
                            dataTable.Rows[i]["VAT_Applicable_Price_Applied_14"].ToString();
                            dataTable.Rows[i]["Sale_Price_With_DutyNTax_Wholesale_15"].ToString();
                            dataTable.Rows[i]["Sale_Price_With_DutyNTax_Retail_Price_16"].ToString();
                            string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["wastage_quantityn"])), dataTable.Rows[i]["wastage_quantity"].ToString());
                            dataTable.Rows[i]["reference"].ToString();
                            dataTable.Rows[i]["remarks"].ToString();
                            this.RoundUpString(dataTable.Rows[i]["quantity"].ToString(), num);
                            string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["quantity_totaln"])), dataTable.Rows[i]["quantity_total"].ToString());
                            str13 = dataTable.Rows[i]["date_insert"].ToString();
                            empty14 = dataTable.Rows[i]["effective_date"].ToString();
                            if (this.lblDakhilerTarikh.Text == "")
                            {
                                this.lblDakhilerTarikh.Text = str13.ToString();
                            }
                            if (this.lblDakhilerTarikh.Text == "")
                            {
                                this.lbleffectivDate.Text = empty14.ToString();
                            }
                            num3 += Convert.ToDecimal(dataTable.Rows[i]["quantity_totalN"]);
                            num4 += Convert.ToDecimal(withString1);
                            num5 += Convert.ToDecimal(dataTable.Rows[i]["Raw_Meterials_Depriciation_61N"]);
                            num6 += Convert.ToDecimal(withString2);
                            if (dataTable1.Rows.Count > 0)
                            {
                                num1 = i;
                                while (num1 < dataTable1.Rows.Count)
                                {
                                    dataTable1.Rows[num1]["value_add_8"].ToString();
                                    withString = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable1.Rows[num1]["Value_Added_Per_Unit_9"]), num);
                                    num8++;
                                    if (num8 <= 0)
                                    {
                                        num1++;
                                    }
                                    else
                                    {
                                        num1++;
                                        num7 += Convert.ToDecimal(withString);
                                        break;
                                    }
                                }
                                num2 = num1 + 1;
                                if (num2 > dataTable.Rows.Count && num1 == dataTable.Rows.Count)
                                {
                                    for (int j = num2 - 1; j < dataTable1.Rows.Count; j++)
                                    {
                                        num7 += Convert.ToDecimal(withString);
                                    }
                                }
                            }
                        }
                        empty3 = (empty3.Length != 0 ? "" : dataTable.Rows[0]["hs_code_2"].ToString());
                        str3 = (str3.Length != 0 ? "" : dataTable.Rows[0]["goods_name_3"].ToString());
                        str4 = dataTable.Rows[0]["sale_unit_4"].ToString();
                        string withString3 = "";
                        string withString4 = "";
                        this.RoundNumberWithUnit(num3.ToString(), num);
                        withString3 = this.RoundUpToWithString(num4, num);
                        this.RoundNumberWithUnit(num5.ToString(), num);
                        this.RoundNumberWithUnit(num6.ToString(), num);
                        withString4 = this.RoundUpToWithString(num7, num);
                        str = string.Concat(str, "<tr>");
                        str = string.Concat(str, "<td  style='text-align:center;'>১</td>");
                        str = string.Concat(str, "<td style='text-align:left; padding:2px;font-weight:bold'>", empty3, "</td>");
                        str = string.Concat(str, "<td  style='text-align:left; padding:2px;font-weight:bold'>", str3, "</td>");
                        str = string.Concat(str, "<td  style='text-align:left; padding:2px;font-weight:bold'>", str4, "</td>");
                        str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", withString3, "</td>");
                        str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", withString4, "</td>");
                        if (totalValueAddPct.Rows.Count <= 0)
                        {
                            str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'></td>");
                        }
                        else
                        {
                            decimal num9 = Convert.ToDecimal(totalValueAddPct.Rows[0]["value_addtn_pct"]);
                            if (num9 == new decimal(0))
                            {
                                str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'></td>");
                            }
                            else
                            {
                                object obj = str;
                                object[] objArray = new object[] { obj, "<td style='text-align:left; padding:2px;font-weight:bold'>Value Addition(%) : ", num9, "</td>" };
                                str = string.Concat(objArray);
                            }
                        }
                        str = string.Concat(str, "</tr>");
                        this.lblInfoShow.Text = str;
                        this.pnlContents.Visible = true;
                        this.btnPrint.Visible = true;
                        this.btnPrint.Focus();
                    }
                }
                return;
            }
            PriceDeclaretionBLL priceDeclaretionBLL = new PriceDeclaretionBLL();
            this.fromDate = DateTime.ParseExact(this.dtpFromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.toDate = DateTime.ParseExact(this.dtpToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataTable itemPriceWithDateFilter = priceDeclaretionBLL.getItemPriceWithDateFilter("M", this.fromDate, this.toDate);
            for (int k = 0; k < itemPriceWithDateFilter.Rows.Count; k++)
            {
                int num10 = k + 1;
                string str14 = "";
                str14 = itemPriceWithDateFilter.Rows[k]["item_name"].ToString();
                int num11 = Convert.ToInt32(itemPriceWithDateFilter.Rows[k]["price_id"].ToString());
                string[] strArrays = str14.Split(new char[] { '-' });
                string str15 = strArrays[1];
                string str16 = strArrays[0];
                DataTable dataTable2 = this.objPDBLL.rptPriceDeclarationFourPointThree(num11);
                DataTable dataTable3 = this.objPDBLL.rptPriceDeclarationFourPointThreeKhat(num11);
                DataTable totalValueAddPct1 = this.objPDBLL.GetTotalValueAddPct(num11);
                this.Session["PRICE_DECLARATION_01"] = dataTable2;
                if (dataTable2 != null && dataTable2.Rows.Count > 0)
                {
                    string empty15 = string.Empty;
                    string empty16 = string.Empty;
                    string empty17 = string.Empty;
                    string str17 = string.Empty;
                    string empty18 = string.Empty;
                    string str18 = string.Empty;
                    string empty19 = string.Empty;
                    string withString5 = string.Empty;
                    string str19 = string.Empty;
                    string empty20 = string.Empty;
                    string withString6 = string.Empty;
                    string str20 = string.Empty;
                    string empty21 = string.Empty;
                    string str21 = string.Empty;
                    string empty22 = string.Empty;
                    string str22 = string.Empty;
                    string empty23 = string.Empty;
                    string str23 = string.Empty;
                    string empty24 = string.Empty;
                    string str24 = string.Empty;
                    string empty25 = string.Empty;
                    string str25 = string.Empty;
                    string empty26 = string.Empty;
                    string str26 = string.Empty;
                    string empty27 = string.Empty;
                    string str27 = string.Empty;
                    Convert.ToDecimal(dataTable2.Compute("SUM(Total_Purchase_Price_7)", string.Empty));
                    Convert.ToDecimal(dataTable2.Compute("SUM(Value_Added_Per_Unit_9)", string.Empty));
                    for (int l = 0; l < dataTable2.Rows.Count; l++)
                    {
                        dataTable2.Rows[l]["Goods_Description_31"].ToString();
                        dataTable2.Rows[l]["Raw_Materials_Name_5"].ToString();
                        string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable2.Rows[l]["Raw_Meterials_Quantity_6n"])), dataTable2.Rows[l]["Raw_Meterials_Quantity_6"].ToString());
                        withString5 = this.RoundUpToWithString(Convert.ToDecimal(dataTable2.Rows[l]["Total_Purchase_Price_7"]), num);
                        dataTable2.Rows[l]["Value_Add_8"].ToString();
                        dataTable2.Rows[l]["Value_Added_Per_Unit_9"].ToString();
                        withString6 = this.RoundUpToWithString(Convert.ToDecimal(dataTable2.Rows[l]["wastageparcent"]), num);
                        dataTable2.Rows[l]["Price_With_SD_Present_10"].ToString();
                        dataTable2.Rows[l]["Price_With_SD_Applied_11"].ToString();
                        dataTable2.Rows[l]["SD_On_Applied_Price_12"].ToString();
                        dataTable2.Rows[l]["VAT_Applicable_Price_Present_13"].ToString();
                        dataTable2.Rows[l]["VAT_Applicable_Price_Applied_14"].ToString();
                        dataTable2.Rows[l]["Sale_Price_With_DutyNTax_Wholesale_15"].ToString();
                        dataTable2.Rows[l]["Sale_Price_With_DutyNTax_Retail_Price_16"].ToString();
                        string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable2.Rows[l]["wastage_quantityn"])), dataTable2.Rows[l]["wastage_quantity"].ToString());
                        dataTable2.Rows[l]["reference"].ToString();
                        dataTable2.Rows[l]["remarks"].ToString();
                        this.RoundUpString(dataTable2.Rows[l]["quantity"].ToString(), num);
                        string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable2.Rows[l]["quantity_totaln"])), dataTable2.Rows[l]["quantity_total"].ToString());
                        empty27 = dataTable2.Rows[l]["date_insert"].ToString();
                        str27 = dataTable2.Rows[l]["effective_date"].ToString();
                        if (this.lblDakhilerTarikh.Text == "")
                        {
                            this.lblDakhilerTarikh.Text = empty27.ToString();
                        }
                        if (this.lblDakhilerTarikh.Text == "")
                        {
                            this.lbleffectivDate.Text = str27.ToString();
                        }
                        num3 += Convert.ToDecimal(dataTable2.Rows[l]["quantity_totalN"]);
                        num4 += Convert.ToDecimal(withString5);
                        num5 += Convert.ToDecimal(dataTable2.Rows[l]["Raw_Meterials_Depriciation_61N"]);
                        num6 += Convert.ToDecimal(withString6);
                        if (dataTable3.Rows.Count > 0)
                        {
                            num1 = l;
                            while (num1 < dataTable3.Rows.Count)
                            {
                                dataTable3.Rows[num1]["value_add_8"].ToString();
                                withString = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable3.Rows[num1]["Value_Added_Per_Unit_9"]), num);
                                num8++;
                                if (num8 <= 0)
                                {
                                    num1++;
                                }
                                else
                                {
                                    num1++;
                                    num7 += Convert.ToDecimal(withString);
                                    break;
                                }
                            }
                            num2 = num1 + 1;
                            if (num2 > dataTable2.Rows.Count && num1 == dataTable2.Rows.Count)
                            {
                                for (int m = num2 - 1; m < dataTable3.Rows.Count; m++)
                                {
                                    num7 += Convert.ToDecimal(withString);
                                }
                            }
                        }
                    }
                    empty16 = (empty16.Length != 0 ? "" : dataTable2.Rows[0]["hs_code_2"].ToString());
                    empty17 = (empty17.Length != 0 ? "" : dataTable2.Rows[0]["goods_name_3"].ToString());
                    empty18 = dataTable2.Rows[0]["sale_unit_4"].ToString();
                    string withString7 = "";
                    string withString8 = "";
                    this.RoundNumberWithUnit(num3.ToString(), num);
                    withString7 = this.RoundUpToWithString(num4, num);
                    this.RoundNumberWithUnit(num5.ToString(), num);
                    this.RoundNumberWithUnit(num6.ToString(), num);
                    withString8 = this.RoundUpToWithString(num7, num);
                    str = string.Concat(str, "<tr>");
                    object obj1 = str;
                    object[] objArray1 = new object[] { obj1, "<td  style='text-align:center;'>", num10, "</td>" };
                    str = string.Concat(objArray1);
                    str = string.Concat(str, "<td style='text-align:left; padding:2px;font-weight:bold'>", empty16, "</td>");
                    str = string.Concat(str, "<td  style='text-align:left; padding:2px;font-weight:bold'>", empty17, "</td>");
                    str = string.Concat(str, "<td  style='text-align:left; padding:2px;font-weight:bold'>", empty18, "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", withString7, "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", withString8, "</td>");
                    if (totalValueAddPct1.Rows.Count <= 0)
                    {
                        str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'></td>");
                    }
                    else
                    {
                        decimal num12 = Convert.ToDecimal(totalValueAddPct1.Rows[0]["value_addtn_pct"]);
                        if (num12 == new decimal(0))
                        {
                            str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'></td>");
                        }
                        else
                        {
                            object obj2 = str;
                            object[] objArray2 = new object[] { obj2, "<td style='text-align:left; padding:2px;font-weight:bold'>Value Addition(%) : ", num12, "</td>" };
                            str = string.Concat(objArray2);
                        }
                    }
                    str = string.Concat(str, "</tr>");
                    this.lblInfoShow.Text = str;
                    this.pnlContents.Visible = true;
                    this.btnPrint.Visible = true;
                    this.btnPrint.Focus();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.divResult.Visible = false;
                this.Session["PRICE_DECLARATION_01"] = new DataSet();
                this.dtpFromDate.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.FillDropdown();
            }
        }

        private string RoundNumberWithUnit(string numberWithUnit, int precision)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string[] strArrays = numberWithUnit.Split(new char[] { '(' });
            if ((int)strArrays.Length != 2)
            {
                empty1 = this.RoundUpString(numberWithUnit, precision);
            }
            else
            {
                empty = strArrays[0];
                str = string.Concat("(", strArrays[1]);
                if (string.IsNullOrEmpty(empty) || string.IsNullOrEmpty(str))
                {
                    empty1 = empty;
                }
                else
                {
                    empty = this.RoundUpString(empty, precision);
                    empty1 = string.Concat(empty, str);
                }
            }
            return empty1;
        }

        private string RoundUpString(string number, int precision)
        {
            string str;
            if (!string.IsNullOrEmpty(number))
            {
                decimal num = Utilities.RoundUpTo(Convert.ToDecimal(number), precision);
                str = num.ToString();
            }
            else
            {
                str = number;
            }
            number = str;
            return number;
        }

        private string RoundUpToWithString(decimal number, int precision)
        {
            return Utilities.RoundUpToWithString(number, precision);
        }

        protected void showBTN_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                try
                {
                    CompanyBLL companyBLL = new CompanyBLL();
                    DataSet fullOrganizationInfo = companyBLL.getFullOrganizationInfo(Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString()));
                    string str = fullOrganizationInfo.Tables[0].Rows[0]["organization_name"].ToString();
                    string str1 = fullOrganizationInfo.Tables[0].Rows[0]["operation_address"].ToString();
                    string str2 = fullOrganizationInfo.Tables[0].Rows[0]["registration_no"].ToString();
                    string str3 = fullOrganizationInfo.Tables[0].Rows[0]["circle_code"].ToString();
                    string str4 = fullOrganizationInfo.Tables[0].Rows[0]["ba_phone"].ToString();
                    string str5 = fullOrganizationInfo.Tables[0].Rows[0]["ba_fax"].ToString();
                    this.Session["organization_name"] = str;
                    this.Session["business_address"] = str1;
                    this.Session["registration_no"] = str2;
                    this.Session["area_code"] = str3;
                    this.Session["ba_phone"] = str4;
                    this.Session["ba_fax"] = str5;
                    this.lblNibondhitoBektirName.Text = str;
                    this.lblThikana.Text = str1;
                    this.lblNibondhonShonkha.Text = str2;
                    this.pnlContents.Visible = true;
                    this.btnPrint.Visible = true;
                    this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.lblDutyOfficerDesignation.Text = this.Session["DESIGNATION_NAME"].ToString();
                    this.signatureDiv.Visible = true;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
                this.LoadFullReport();
                this.divResult.Visible = true;
                this.clearAll();
            }
        }

        private bool Validation()
        {
            if (this.dtpFromDate.Text.Length < 10 || this.dtpFromDate.Text.Length > 10)
            {
                this.msgBox.AddMessage("Please enter from date correctly.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.dtpToDate.Text.Length >= 10 && this.dtpToDate.Text.Length >= 10)
            {
                return true;
            }
            this.msgBox.AddMessage("Please enter to date correctly.", MsgBoxs.enmMessageType.Info);
            return false;
        }

    }
}