using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class Mushok4_3Report : Page, IRequiresSessionState
    {
        private NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionBLL objPDBLL = new NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionBLL();

        private NBR_VAT_GROUPOFCOM.BLL.SetCountryBLL scBLL = new NBR_VAT_GROUPOFCOM.BLL.SetCountryBLL();

   

        public Mushok4_3Report()
        {
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            int num;
            if (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text))
            {
                if (!int.TryParse(this.precisionTxtBox.Text, out num))
                {
                    this.msgBox.AddMessage("Precision has to be a number !", MsgBoxs.enmMessageType.Error);
                    return;
                }
                if (num < 0 || num > 12)
                {
                    this.msgBox.AddMessage("Precision has to be a number between 0 to 12 !", MsgBoxs.enmMessageType.Error);
                    return;
                }
            }
            if (this.drpDeclaretionNo.SelectedItem.Value.ToString() == "-99")
            {
                this.msgBox.AddMessage("Information: Please Select an Item !", MsgBoxs.enmMessageType.Error);
                return;
            }
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
            int num3 = 0;
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            int num9 = 0;
            string str1 = "";
            string str2 = "";
            str2 = Convert.ToString(this.drpDeclaretionNo.SelectedItem);
            char[] chrArray = new char[] { '-' };
            str1 = str2.Split(chrArray)[1];
            if (str1 == " 2402.20.00" || str1 == " 2402.90.00")
            {
                this.divOther.Visible = false;
                this.divTobacco.Visible = true;
                CompanyBLL companyBLL = new CompanyBLL();
                DataSet fullOrganizationInfo = companyBLL.getFullOrganizationInfo(Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString()));
                string str3 = fullOrganizationInfo.Tables[0].Rows[0]["organization_name"].ToString();
                string str4 = fullOrganizationInfo.Tables[0].Rows[0]["business_address"].ToString();
                string str5 = fullOrganizationInfo.Tables[0].Rows[0]["registration_no"].ToString();
                string str6 = fullOrganizationInfo.Tables[0].Rows[0]["circle_code"].ToString();
                string str7 = fullOrganizationInfo.Tables[0].Rows[0]["ba_phone"].ToString();
                string str8 = fullOrganizationInfo.Tables[0].Rows[0]["ba_fax"].ToString();
                this.Session["organization_name"] = str3;
                this.Session["business_address"] = str4;
                this.Session["registration_no"] = str5;
                this.Session["area_code"] = str6;
                this.Session["ba_phone"] = str7;
                this.Session["ba_fax"] = str8;
                this.lblNibondhitoBektirName.Text = str3;
                this.lblThikana.Text = str4;
                this.lblNibondhonShonkha.Text = str5;
                this.lblElakaCode.Text = str6;
                this.lblTelephoneNumber.Text = str7;
                this.lblFaxNumber.Text = str8;
                this.lblThikana.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                DataTable itemPriceNumber = this.objPDBLL.getItemPriceNumber(Convert.ToInt32(this.drpDeclaretionNo.SelectedItem.Value.ToString()));
                this.lblMulloGhoshonaNumber.Text = itemPriceNumber.Rows[0]["price_declaration_no"].ToString();
                this.lblYear.Text = itemPriceNumber.Rows[0]["year"].ToString();
                DataTable dataTable = this.objPDBLL.rptPriceDeclaration(Convert.ToInt32(this.drpDeclaretionNo.SelectedItem.Value.ToString()));
                this.Session["PRICE_DECLARATION_01"] = dataTable;
                DataTable dataTable1 = this.objPDBLL.rptPriceDeclarationTobacco(Convert.ToInt32(this.drpDeclaretionNo.SelectedItem.Value.ToString()));
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    str = "";
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    string empty4 = string.Empty;
                    string empty5 = string.Empty;
                    string empty6 = string.Empty;
                    string withString1 = string.Empty;
                    string withString2 = string.Empty;
                    string empty7 = string.Empty;
                    string empty8 = string.Empty;
                    string empty9 = string.Empty;
                    string str9 = string.Empty;
                    string empty10 = string.Empty;
                    string str10 = string.Empty;
                    string empty11 = string.Empty;
                    string str11 = string.Empty;
                    string empty12 = string.Empty;
                    string str12 = string.Empty;
                    string empty13 = string.Empty;
                    decimal num10 = Convert.ToDecimal(dataTable.Compute("SUM(Total_Purchase_Price_7)", string.Empty));
                    decimal num11 = Convert.ToDecimal(dataTable.Compute("SUM(Value_Added_Per_Unit_9)", string.Empty));
                    string str13 = "";
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        empty12 = dataTable.Rows[0]["Sale_Price_With_DutyNTax_Retail_Price_16"].ToString();
                        if (i != 0)
                        {
                            empty2 = "";
                            empty5 = "";
                            str13 = "";
                        }
                        else
                        {
                            empty2 = Convert.ToString("১");
                            empty5 = string.Concat("প্রতি ", dataTable.Rows[i]["production_quantity"].ToString(), " শলাকা");
                            str13 = string.Concat("প্রতি", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[0]["stick_quantity"])), "শলাকার প্যাকেটের মূল্য ", empty12);
                        }
                        empty3 = (empty3.Length != 0 ? "" : dataTable.Rows[i]["hs_code_2"].ToString());
                        empty4 = (empty4.Length != 0 ? "" : dataTable.Rows[i]["goods_name_3"].ToString());
                        empty6 = dataTable.Rows[i]["Raw_Materials_Name_5"].ToString();
                        withString1 = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["Raw_Meterials_Quantity_6"]), num);
                        withString2 = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["Total_Purchase_Price_7"]), num);
                        dataTable.Rows[i]["Value_Add_8"].ToString();
                        dataTable.Rows[i]["Value_Added_Per_Unit_9"].ToString();
                        dataTable.Rows[i]["Price_With_SD_Present_10"].ToString();
                        dataTable.Rows[i]["Price_With_SD_Applied_11"].ToString();
                        dataTable.Rows[i]["SD_On_Applied_Price_12"].ToString();
                        dataTable.Rows[i]["VAT_Applicable_Price_Present_13"].ToString();
                        empty11 = dataTable.Rows[0]["VAT_Applicable_Price_Applied_14"].ToString();
                        str11 = dataTable.Rows[0]["Sale_Price_With_DutyNTax_Wholesale_15"].ToString();
                        string[] strArrays = new string[] { withString1, "(", dataTable.Rows[i]["wastage_quantity"].ToString(), ")", dataTable.Rows[i]["unit_code"].ToString() };
                        withString1 = string.Concat(strArrays);
                        str = string.Concat(str, "<tr style = 'background-color: White'>");
                        str = string.Concat(str, "<td class='style10' align='center' style='border-right:thin;width: 10% ; background-color: White'>", empty2, "</td>");
                        str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ; background-color: White'>", empty4, "</td>");
                        str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ; background-color: White'>", empty5, "</td>");
                        str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ; background-color: White'>", empty6, "</td>");
                        str = (dataTable.Rows[i]["Raw_Meterials_Quantity_6"].ToString() != "0" ? string.Concat(str, "<td class='style14' align='right' style='width: 10% ; background-color: White'>", withString1, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'></td>"));
                        str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ; background-color: White'>", withString2, "</td>");
                        string withString3 = "";
                        if (dataTable1.Rows.Count <= 0)
                        {
                            str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                            str = string.Concat(str, "<td class='style14' align='right' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'></td>");
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                        }
                        else
                        {
                            num1 = i;
                            while (num1 < dataTable1.Rows.Count)
                            {
                                empty1 = dataTable1.Rows[num1]["value_add_8"].ToString();
                                withString = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable1.Rows[num1]["Value_Added_Per_Unit_9"]), num);
                                withString3 = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable1.Rows[num1]["charge"]), num);
                                num9++;
                                if (num9 <= 0)
                                {
                                    num1++;
                                }
                                else
                                {
                                    str = (empty1 != "0" ? string.Concat(str, "<td class='style14' align='left' style='width: 10% ;background-color: White'>", empty1, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'></td>"));
                                    str = (Convert.ToDecimal(dataTable1.Rows[num1]["Value_Added_Per_Unit_9"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 14% ; background-color: White'>", withString, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'></td>"));
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = (Convert.ToDecimal(dataTable1.Rows[num1]["charge"]) != new decimal(0) ? string.Concat(str, "<td style='text-align:right;padding:3px'>", withString3, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'></td>"));
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'>", str13, "</td>");
                                    num1++;
                                    num6 += Convert.ToDecimal(withString);
                                    num8 += Convert.ToDecimal(withString3);
                                    break;
                                }
                            }
                            num3 = i;
                            num2 = num1 + 1;
                            if (num2 > dataTable.Rows.Count && num1 == dataTable.Rows.Count)
                            {
                                for (int j = num2 - 1; j < dataTable1.Rows.Count; j++)
                                {
                                    empty1 = dataTable1.Rows[j]["value_add_8"].ToString();
                                    withString = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable1.Rows[j]["Value_Added_Per_Unit_9"]), num);
                                    withString3 = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable1.Rows[j]["charge"]), num);
                                    str = string.Concat(str, "<tr style = 'background-color: White'>");
                                    str = string.Concat(str, "<td class='style10' align='center' style='width: 2% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style11' align='center' style='width: 10% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;background-color: White'></td>");
                                    str = (empty1 != "0" ? string.Concat(str, "<td class='style14' align='left' style='width: 10% ; background-color: White'>", empty1, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                                    str = (Convert.ToDecimal(dataTable1.Rows[j]["Value_Added_Per_Unit_9"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 14% ; background-color: White'>", withString, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = (Convert.ToDecimal(dataTable1.Rows[j]["charge"]) != new decimal(0) ? string.Concat(str, "<td style='text-align:right;padding:3px'>", withString3, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'></td>"));
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                    num6 += Convert.ToDecimal(withString);
                                    num8 += Convert.ToDecimal(withString3);
                                }
                            }
                            if (num3 >= dataTable1.Rows.Count && num3 < dataTable.Rows.Count)
                            {
                                str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ; background-color: White'></td>");
                                str = string.Concat(str, "<td class='style14' align='right' style='width: 14% ;background-color: White'></td>");
                                str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                                str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                            }
                        }
                    }
                    empty2 = "";
                    empty3 = "";
                    empty4 = "";
                    empty5 = "";
                    empty6 = "";
                    withString1 = "মোট মূল্য";
                    withString2 = num10.ToString();
                    num11.ToString();
                    empty12 = "";
                    num7 = Convert.ToDecimal(withString2) + num6;
                    str = string.Concat(str, "<tr style = 'background-color: White'>");
                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(Convert.ToDecimal(withString2), num), "</td>");
                    str = string.Concat(str, "<td style='text-align:right;padding:3px'></td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(num6, num), "</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(num7, num), "</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(num7, num), "</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(num8, num), "</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(Convert.ToDecimal(empty11), num), "</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(Convert.ToDecimal(empty11), num), "</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", Utilities.RoundUpToWithString(Convert.ToDecimal(str11), num), "</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                    this.lblInfoShowtobacco.Text = str;
                    this.pnlContents.Visible = true;
                    this.btnPrint.Visible = true;
                    this.btnPrint.Focus();
                    return;
                }
            }
            else
            {
                this.divTobacco.Visible = false;
                this.divOther.Visible = true;
                DataTable dataTable2 = this.objPDBLL.rptPriceDeclarationFourPointThree(Convert.ToInt32(this.drpDeclaretionNo.SelectedItem.Value.ToString()));
                DataTable dataTable3 = this.objPDBLL.rptPriceDeclarationFourPointThreeKhat(Convert.ToInt32(this.drpDeclaretionNo.SelectedItem.Value.ToString()));
                this.Session["PRICE_DECLARATION_01"] = dataTable2;
                if (dataTable2 != null && dataTable2.Rows.Count > 0)
                {
                    str = "";
                    string empty14 = string.Empty;
                    string str14 = string.Empty;
                    string empty15 = string.Empty;
                    string str15 = string.Empty;
                    string empty16 = string.Empty;
                    string str16 = string.Empty;
                    string empty17 = string.Empty;
                    string withString4 = string.Empty;
                    string str17 = string.Empty;
                    string empty18 = string.Empty;
                    string withString5 = string.Empty;
                    string str18 = string.Empty;
                    string empty19 = string.Empty;
                    string str19 = string.Empty;
                    string empty20 = string.Empty;
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
                    Convert.ToDecimal(dataTable2.Compute("SUM(Total_Purchase_Price_7)", string.Empty));
                    Convert.ToDecimal(dataTable2.Compute("SUM(Value_Added_Per_Unit_9)", string.Empty));
                    for (int k = 0; k < dataTable2.Rows.Count; k++)
                    {
                        empty14 = (k != 0 ? "" : Convert.ToString("১"));
                        str14 = (str14.Length != 0 ? "" : dataTable2.Rows[k]["hs_code_2"].ToString());
                        empty15 = (empty15.Length != 0 ? "" : dataTable2.Rows[k]["goods_name_3"].ToString());
                        str15 = dataTable2.Rows[k]["Goods_Description_31"].ToString();
                        empty16 = dataTable2.Rows[k]["sale_unit_4"].ToString();
                        str16 = dataTable2.Rows[k]["Raw_Materials_Name_5"].ToString();
                        empty17 = string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable2.Rows[k]["Raw_Meterials_Quantity_6n"])), dataTable2.Rows[k]["Raw_Meterials_Quantity_6"].ToString());
                        withString4 = this.RoundUpToWithString(Convert.ToDecimal(dataTable2.Rows[k]["Total_Purchase_Price_7"]), num);
                        dataTable2.Rows[k]["Value_Add_8"].ToString();
                        dataTable2.Rows[k]["Value_Added_Per_Unit_9"].ToString();
                        withString5 = this.RoundUpToWithString(Convert.ToDecimal(dataTable2.Rows[k]["wastageparcent"]), num);
                        dataTable2.Rows[k]["Price_With_SD_Present_10"].ToString();
                        dataTable2.Rows[k]["Price_With_SD_Applied_11"].ToString();
                        dataTable2.Rows[k]["SD_On_Applied_Price_12"].ToString();
                        dataTable2.Rows[k]["VAT_Applicable_Price_Present_13"].ToString();
                        dataTable2.Rows[k]["VAT_Applicable_Price_Applied_14"].ToString();
                        dataTable2.Rows[k]["Sale_Price_With_DutyNTax_Wholesale_15"].ToString();
                        dataTable2.Rows[k]["Sale_Price_With_DutyNTax_Retail_Price_16"].ToString();
                        empty17 = string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable2.Rows[k]["wastage_quantityn"])), dataTable2.Rows[k]["wastage_quantity"].ToString());
                        dataTable2.Rows[k]["reference"].ToString();
                        str23 = dataTable2.Rows[k]["remarks"].ToString();
                        this.RoundUpString(dataTable2.Rows[k]["quantity"].ToString(), num);
                        str24 = string.Concat(Utilities.formatFraction(Convert.ToDecimal(dataTable2.Rows[k]["quantity_totaln"])), dataTable2.Rows[k]["quantity_total"].ToString());
                        empty25 = dataTable2.Rows[k]["date_insert"].ToString();
                        str25 = dataTable2.Rows[k]["effective_date"].ToString();
                        if (this.lblDakhilerTarikh.Text == "")
                        {
                            this.lblDakhilerTarikh.Text = empty25.ToString();
                        }
                        if (this.lblDakhilerTarikh.Text == "")
                        {
                            this.lbleffectivDate.Text = str25.ToString();
                        }
                        str = string.Concat(str, "<tr style = 'background-color: White'>");
                        str = string.Concat(str, "<td class='style10' align='center' style='width: 2% ;border-style:solid;border-width:1px; background-color: White'>", empty14, "</td>");
                        str = string.Concat(str, "<td class='style11' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", str14, "</td>");
                        str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", empty15, "</td>");
                        object obj = str;
                        object[] objArray = new object[] { obj, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", empty16, " ", '-', " ", str15, "</td>" };
                        str = string.Concat(objArray);
                        str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", str16, "</td>");
                        str = (Convert.ToDecimal(dataTable2.Rows[k]["quantity_totaln"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", str24, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                        str = (Convert.ToDecimal(dataTable2.Rows[k]["Total_Purchase_Price_7"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", withString4, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                        str = (Convert.ToDecimal(dataTable2.Rows[k]["wastage_quantityn"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", empty17, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                        str = (Convert.ToDecimal(dataTable2.Rows[k]["wastageparcent"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", withString5, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                        num4 += Convert.ToDecimal(dataTable2.Rows[k]["quantity_totalN"]);
                        num5 += Convert.ToDecimal(withString4);
                        num6 += Convert.ToDecimal(dataTable2.Rows[k]["Raw_Meterials_Depriciation_61N"]);
                        num7 += Convert.ToDecimal(withString5);
                        if (dataTable3.Rows.Count <= 0)
                        {
                            str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                            str = string.Concat(str, "<td class='style14' align='right' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'></td>");
                            str = string.Concat(str, "<td class='style14' align='left' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'>", str23, "</td>");
                        }
                        else
                        {
                            num1 = k;
                            while (num1 < dataTable3.Rows.Count)
                            {
                                empty1 = dataTable3.Rows[num1]["value_add_8"].ToString();
                                withString = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable3.Rows[num1]["Value_Added_Per_Unit_9"]), num);
                                num9++;
                                if (num9 <= 0)
                                {
                                    num1++;
                                }
                                else
                                {
                                    str = (empty1 != "0" ? string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", empty1, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                                    str = (Convert.ToDecimal(dataTable3.Rows[num1]["Value_Added_Per_Unit_9"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'>", withString, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                                    str = string.Concat(str, "<td class='style14' align='left' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'>", str23, "</td>");
                                    num1++;
                                    num8 += Convert.ToDecimal(withString);
                                    break;
                                }
                            }
                            num3 = k;
                            num2 = num1 + 1;
                            if (num2 > dataTable2.Rows.Count && num1 == dataTable2.Rows.Count)
                            {
                                for (int l = num2 - 1; l < dataTable3.Rows.Count; l++)
                                {
                                    empty1 = dataTable3.Rows[l]["value_add_8"].ToString();
                                    withString = Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable3.Rows[l]["Value_Added_Per_Unit_9"]), num);
                                    str = string.Concat(str, "<tr style = 'background-color: White'>");
                                    str = string.Concat(str, "<td class='style10' align='center' style='width: 2% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style11' align='center' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = string.Concat(str, "<td class='style14' align='center' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                    str = (empty1 != "0" ? string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'>", empty1, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                                    str = (Convert.ToDecimal(dataTable3.Rows[l]["Value_Added_Per_Unit_9"]) != new decimal(0) ? string.Concat(str, "<td class='style14' align='right' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'>", withString, "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                                    str = string.Concat(str, "<td class='style14' align='left' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'>", str23, "</td>");
                                    num8 += Convert.ToDecimal(withString);
                                }
                            }
                            if (num3 >= dataTable3.Rows.Count && num3 < dataTable2.Rows.Count)
                            {
                                str = string.Concat(str, "<td class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                str = string.Concat(str, "<td class='style14' align='right' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'></td>");
                                str = string.Concat(str, "<td class='style14' align='left' style='width: 14% ;border-style:solid;border-width:1px; background-color: White'>", str23, "</td>");
                            }
                        }
                    }
                    string withString6 = "";
                    string withString7 = "";
                    this.RoundNumberWithUnit(num4.ToString(), num);
                    withString6 = this.RoundUpToWithString(num5, num);
                    this.RoundNumberWithUnit(num6.ToString(), num);
                    this.RoundNumberWithUnit(num7.ToString(), num);
                    withString7 = this.RoundUpToWithString(num8, num);
                    str = string.Concat(str, "<tr>");
                    str = string.Concat(str, "<td colspan='5' style='text-align:right; padding:2px;font-weight:bold'>মোট :</td>");
                    str = string.Concat(str, "<td></td > ");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", withString6, "</td>");
                    str = string.Concat(str, "<td></td > ");
                    str = string.Concat(str, "<td></td > ");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'></td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", withString7, "</td>");
                    str = string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'></td>");
                    str = string.Concat(str, "<tr>");
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
               NBR_VAT_GROUPOFCOM.BLL.Utilities.fillItemPriceWithDate(this.drpDeclaretionNo, "M");
                this.Session["PRICE_DECLARATION_01"] = new DataSet();
                this.divOther.Visible = false;
                this.divTobacco.Visible = false;
                this.pnlContents.Visible = false;
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

        private decimal RoundUpNumber(decimal number, int precision)
        {
            return Utilities.RoundUpTo(number, precision);
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
    }
}