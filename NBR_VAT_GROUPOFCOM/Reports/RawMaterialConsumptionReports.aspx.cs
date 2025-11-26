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
    public partial class RawMaterialConsumptionReports : Page, IRequiresSessionState
    {
  

        private ItemBLL objItem = new ItemBLL();

        private ContructualProductionBLL objProductBLL = new ContructualProductionBLL();

        private DateTime issueFirstDate = new DateTime();



        public RawMaterialConsumptionReports()
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            try
            {
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime2 = dateTime1.AddDays(1);
                DataTable ingredience = contructualProductionBLL.GetIngredience(dateTime, dateTime2);
                if (ingredience != null && ingredience.Rows.Count > 0)
                {
                    this.drpIngredient.DataSource = ingredience;
                    this.drpIngredient.DataTextField = ingredience.Columns["item_name"].ToString();
                    this.drpIngredient.DataValueField = ingredience.Columns["item_id"].ToString();
                    this.drpIngredient.DataBind();
                    ListItem listItem = new ListItem("--- Select ---", "-99");
                    this.drpIngredient.Items.Insert(0, listItem);
                }
                this.LoadFinishedProductionProductionByDate(dateTime, dateTime2);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            object obj;
            object[] str;
            string str1;
            long wastPercentage = (long)0;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            string str2 = "";
            string str3 = "";
            long num6 = (long)0;
            this.lblFinishProductRpt.Text = "";
            try
            {
                int num7 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime2 = dateTime1;
                DateTime dateTime3 = dateTime.AddDays(-1);
                DataTable dataTable = new DataTable();
                if (this.drpIngredient.SelectedValue != "-99")
                {
                    num6 = Convert.ToInt64(this.drpIngredient.SelectedValue);
                    str2 = string.Concat("Item :", this.drpIngredient.SelectedItem.ToString());
                }
                if (this.txtChallanNumber.Text != "")
                {
                    str3 = string.Concat("Challan No :", this.txtChallanNumber.Text);
                }
                wastPercentage = contructualProductionBLL.GetWastPercentage(num6);
                contructualProductionBLL.getPrevProQuantity(dateTime3, num6);
                contructualProductionBLL.GetUsedQuantity(dateTime, dateTime2, num6);
                DataTable issuedPdQuantity = contructualProductionBLL.getIssuedPdQuantity(dateTime, dateTime2, num6);
                if (issuedPdQuantity == null || issuedPdQuantity.Rows.Count <= 0)
                {
                    dataTable = contructualProductionBLL.GetOpeningStock(num6, dateTime);
                }
                else
                {
                    this.issueFirstDate = DateTime.ParseExact(issuedPdQuantity.Rows[0]["date_production"].ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dataTable = contructualProductionBLL.GetOpeningBalance(num6, dateTime, dateTime2);
                }
                Label label = this.lblParamaters;
                string[] strArrays = new string[] { "Date From :", dateTime.ToString("dd-MMM-yyyy"), ",  Date To :", dateTime2.ToString("dd-MMM-yyyy"), " ", str2, " ", str3 };
                label.Text = string.Concat(strArrays);
                string str4 = "";
                if (this.drpFinishedProduct.SelectedValue != "-99")
                {
                    DataTable issuedPdQuantityByFPP = contructualProductionBLL.getIssuedPdQuantityByFPP(dateTime, dateTime2, num6, Convert.ToInt64(this.drpFinishedProduct.SelectedValue));
                    DataTable usedPdQuantityByFPP = contructualProductionBLL.getUsedPdQuantityByFPP(dateTime, dateTime2, num6, Convert.ToInt64(this.drpFinishedProduct.SelectedValue));
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    string str5 = "";
                    string str6 = "";
                    if (usedPdQuantityByFPP.Rows.Count > 0)
                    {
                        num8 = Convert.ToDecimal(usedPdQuantityByFPP.Rows[0]["used_qnt"]);
                        num9 = Convert.ToDecimal(usedPdQuantityByFPP.Rows[0]["finish_quantity"]);
                        str5 = usedPdQuantityByFPP.Rows[0]["unit_code"].ToString();
                        str6 = usedPdQuantityByFPP.Rows[0]["finish_unit"].ToString();
                    }
                    if (issuedPdQuantityByFPP.Rows.Count > 0)
                    {
                        for (int i = 0; i < issuedPdQuantityByFPP.Rows.Count; i++)
                        {
                            this.issueFirstDate = Convert.ToDateTime(issuedPdQuantityByFPP.Rows[i]["date_production"]);
                            DataTable openingStock = contructualProductionBLL.GetOpeningStock(Convert.ToInt64(issuedPdQuantityByFPP.Rows[i]["item_id"].ToString()), this.issueFirstDate);
                            decimal num10 = Convert.ToDecimal(openingStock.Rows[0]["availstock"]);
                            decimal num11 = Convert.ToDecimal(contructualProductionBLL.GetWastPercentage(Convert.ToInt64(issuedPdQuantityByFPP.Rows[i]["item_id"])));
                            decimal num12 = Convert.ToDecimal(issuedPdQuantityByFPP.Rows[i]["issued_qnt"]) - num8;
                            decimal num13 = Convert.ToDecimal(issuedPdQuantityByFPP.Rows[i]["issued_qnt"]);
                            decimal num14 = num13 * (Convert.ToDecimal(num11) / new decimal(100));
                            str4 = string.Concat(str4, "<tr>");
                            str4 = string.Concat(str4, "<td>Issued</td>");
                            str4 = string.Concat(str4, "<td></td>");
                            str4 = string.Concat(str4, "<td></td>");
                            if (num7 != -1)
                            {
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(num10, num7), "</td>" };
                                str4 = string.Concat(str);
                                str4 = string.Concat(str4, "<td>", issuedPdQuantityByFPP.Rows[i]["item_name"].ToString(), "</td>");
                                str4 = string.Concat(str4, "<td>", issuedPdQuantityByFPP.Rows[i]["unit_code"].ToString(), "</td>");
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(num13), num7), "(", issuedPdQuantityByFPP.Rows[i]["unit_code"].ToString(), ")</td>" };
                                str4 = string.Concat(str);
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(issuedPdQuantityByFPP.Rows[i]["finish_quantity"]), num7), "(", issuedPdQuantityByFPP.Rows[i]["finish_unit"].ToString(), ")</td>" };
                                str4 = string.Concat(str);
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(usedPdQuantityByFPP.Rows[i]["finish_quantity"]), num7), "(", usedPdQuantityByFPP.Rows[i]["finish_unit"].ToString(), ")</td>" };
                                str4 = string.Concat(str);
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(usedPdQuantityByFPP.Rows[i]["used_qnt"]), num7), "(", usedPdQuantityByFPP.Rows[i]["unit_code"].ToString(), ")</td>" };
                                str4 = string.Concat(str);
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(num11, num7), "</td>" };
                                str4 = string.Concat(str);
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(num14), num7), "</td>" };
                                str4 = string.Concat(str);
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(num12), num7), "(", usedPdQuantityByFPP.Rows[i]["unit_code"].ToString(), ")</td>" };
                                str4 = string.Concat(str);
                            }
                            else
                            {
                                obj = str4;
                                str = new object[] { obj, "<td align='right' >", num10, "</td>" };
                                str4 = string.Concat(str);
                                str4 = string.Concat(str4, "<td>", issuedPdQuantityByFPP.Rows[i]["item_name"].ToString(), "</td>");
                                str4 = string.Concat(str4, "<td>", issuedPdQuantityByFPP.Rows[i]["unit_code"].ToString(), "</td>");
                                str1 = str4;
                                string[] strArrays1 = new string[] { str1, "<td align='right' >", Utilities.formatFraction(Convert.ToDecimal(num13)), "(", issuedPdQuantityByFPP.Rows[i]["unit_code"].ToString(), ")</td>" };
                                str4 = string.Concat(strArrays1);
                                string str7 = str4;
                                string[] strArrays2 = new string[] { str7, "<td align='right' >", Utilities.formatFraction(Convert.ToDecimal(issuedPdQuantityByFPP.Rows[i]["finish_quantity"])), "(", issuedPdQuantityByFPP.Rows[i]["finish_unit"].ToString(), ")</td>" };
                                str4 = string.Concat(strArrays2);
                                string str8 = str4;
                                string[] strArrays3 = new string[] { str8, "<td align='right' >", Utilities.formatFraction(num9), "(", str6, ")</td>" };
                                str4 = string.Concat(strArrays3);
                                string str9 = str4;
                                string[] strArrays4 = new string[] { str9, "<td align='right' >", Utilities.formatFraction(num8), "(", str5, ")</td>" };
                                str4 = string.Concat(strArrays4);
                                object obj1 = str4;
                                object[] objArray = new object[] { obj1, "<td align='right' >", num11, "</td>" };
                                str4 = string.Concat(objArray);
                                str4 = string.Concat(str4, "<td align='right' >", Utilities.formatFraction(Convert.ToDecimal(num14)), "</td>");
                                str1 = str4;
                                strArrays = new string[] { str1, "<td align='right' >", Utilities.formatFraction(Convert.ToDecimal(num12)), "(", str5, ")</td>" };
                                str4 = string.Concat(strArrays);
                            }
                            this.lblFinishProductRpt.Text = str4;
                        }
                    }
                }
                else if (num7 != -1)
                {
                    if (dataTable.Rows.Count > 0 && dataTable != null)
                    {
                        num3 = Convert.ToDecimal(dataTable.Rows[0]["availstock"].ToString());
                        str4 = string.Concat(str4, "<tr>");
                        str4 = string.Concat(str4, "<td>Opening</td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        obj = str4;
                        str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(num3, num7), "</td>" };
                        str4 = string.Concat(str);
                        str4 = string.Concat(str4, "<td>", dataTable.Rows[0]["item_name"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", dataTable.Rows[0]["unit_code"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                    }
                    for (int j = 0; j < issuedPdQuantity.Rows.Count; j++)
                    {
                        decimal num15 = new decimal(0);
                        decimal num16 = new decimal(0);
                        num = Convert.ToDecimal(issuedPdQuantity.Rows[j]["quantity"].ToString());
                        if (num3 > new decimal(0))
                        {
                            num4 = num3 - num;
                        }
                        str4 = string.Concat(str4, "<tr>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[j]["status"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[j]["challan_batch_no"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[j]["date_production"].ToString(), "</td>");
                        obj = str4;
                        str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(num3, num7), "</td>" };
                        str4 = string.Concat(str);
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[j]["item_name"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[j]["unit_code"].ToString(), "</td>");
                        obj = str4;
                        str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(issuedPdQuantity.Rows[j]["quantity"]), num7), "</td>" };
                        str4 = string.Concat(str);
                        obj = str4;
                        str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(issuedPdQuantity.Rows[j]["finish_quantity"]), num7), "(", issuedPdQuantity.Rows[j]["finish_unit"].ToString(), ")</td>" };
                        str4 = string.Concat(str);
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "</tr>");
                        this.lblFinishProductRpt.Text = str4;
                        num3 = num4;
                        long num17 = Convert.ToInt64(issuedPdQuantity.Rows[j]["production_id"]);
                        DataTable usedInPdQuantity = contructualProductionBLL.GetUsedInPdQuantity(dateTime, dateTime2, num6, num17);
                        for (int k = 0; k < usedInPdQuantity.Rows.Count; k++)
                        {
                            decimal num18 = new decimal(0);
                            num5 = Convert.ToDecimal(usedInPdQuantity.Rows[k]["used_quantity"]);
                            num2 = num1 - num5;
                            num15 = num - (num5 + num16);
                            num18 = Convert.ToDecimal(num5) * (Convert.ToDecimal(wastPercentage) / new decimal(100));
                            str4 = string.Concat(str4, "<tr>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity.Rows[k]["status"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity.Rows[k]["challan_batch_no"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity.Rows[k]["date_production"].ToString(), "</td>");
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(num3, num7), "</td>" };
                            str4 = string.Concat(str);
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity.Rows[k]["item_name"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity.Rows[k]["unit_code"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td></td>");
                            str4 = string.Concat(str4, "<td></td>");
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(usedInPdQuantity.Rows[k]["finish_quantity"]), num7), "(", usedInPdQuantity.Rows[k]["finish_unit"].ToString(), ")</td>" };
                            str4 = string.Concat(str);
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(Convert.ToDecimal(usedInPdQuantity.Rows[k]["used_quantity"]), num7), "(", usedInPdQuantity.Rows[k]["unit_code"].ToString(), ")</td>" };
                            str4 = string.Concat(str);
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(wastPercentage, num7), "</td>" };
                            str4 = string.Concat(str);
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(num18, num7), "(", usedInPdQuantity.Rows[k]["unit_code"].ToString(), ")</td>" };
                            str4 = string.Concat(str);
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", Utilities.RoundUpTo(num15, num7), "(", usedInPdQuantity.Rows[k]["unit_code"].ToString(), ")</td>" };
                            str4 = string.Concat(str);
                            str4 = string.Concat(str4, "</tr>");
                            this.lblFinishProductRpt.Text = str4;
                            num1 = num2;
                            num16 += num5;
                        }
                    }
                }
                else
                {
                    if (dataTable.Rows.Count > 0 && dataTable != null)
                    {
                        num3 = Convert.ToDecimal(dataTable.Rows[0]["availstock"].ToString());
                        str4 = string.Concat(str4, "<tr>");
                        str4 = string.Concat(str4, "<td>Opening</td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        obj = str4;
                        str = new object[] { obj, "<td align='right' >", num3, "</td>" };
                        str4 = string.Concat(str);
                        str4 = string.Concat(str4, "<td>", dataTable.Rows[0]["item_name"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", dataTable.Rows[0]["unit_code"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                    }
                    for (int l = 0; l < issuedPdQuantity.Rows.Count; l++)
                    {
                        decimal num19 = new decimal(0);
                        decimal num20 = new decimal(0);
                        num = Convert.ToDecimal(issuedPdQuantity.Rows[l]["quantity"].ToString());
                        if (num3 > new decimal(0))
                        {
                            num4 = num3 - num;
                        }
                        str4 = string.Concat(str4, "<tr>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[l]["status"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[l]["challan_batch_no"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[l]["date_production"].ToString(), "</td>");
                        obj = str4;
                        str = new object[] { obj, "<td align='right' >", num3, "</td>" };
                        str4 = string.Concat(str);
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[l]["item_name"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td>", issuedPdQuantity.Rows[l]["unit_code"].ToString(), "</td>");
                        str4 = string.Concat(str4, "<td align='right' >", issuedPdQuantity.Rows[l]["quantity"].ToString(), "</td>");
                        str1 = str4;
                        strArrays = new string[] { str1, "<td align='right' >", null, null, null, null };
                        double num21 = Convert.ToDouble(issuedPdQuantity.Rows[l]["finish_quantity"]);
                        strArrays[2] = num21.ToString();
                        strArrays[3] = "(";
                        strArrays[4] = issuedPdQuantity.Rows[l]["finish_unit"].ToString();
                        strArrays[5] = ")</td>";
                        str4 = string.Concat(strArrays);
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "<td></td>");
                        str4 = string.Concat(str4, "</tr>");
                        this.lblFinishProductRpt.Text = str4;
                        num3 = num4;
                        long num22 = Convert.ToInt64(issuedPdQuantity.Rows[l]["production_id"]);
                        DataTable usedInPdQuantity1 = contructualProductionBLL.GetUsedInPdQuantity(dateTime, dateTime2, num6, num22);
                        for (int m = 0; m < usedInPdQuantity1.Rows.Count; m++)
                        {
                            decimal num23 = new decimal(0);
                            num5 = Convert.ToDecimal(usedInPdQuantity1.Rows[m]["used_quantity"].ToString());
                            num2 = num1 - num5;
                            num19 = num - (num5 + num20);
                            num23 = Convert.ToDecimal(num5) * (Convert.ToDecimal(wastPercentage) / new decimal(100));
                            str4 = string.Concat(str4, "<tr>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity1.Rows[m]["status"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity1.Rows[m]["challan_batch_no"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity1.Rows[m]["date_production"].ToString(), "</td>");
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", num3, "</td>" };
                            str4 = string.Concat(str);
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity1.Rows[m]["item_name"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td>", usedInPdQuantity1.Rows[m]["unit_code"].ToString(), "</td>");
                            str4 = string.Concat(str4, "<td></td>");
                            str4 = string.Concat(str4, "<td></td>");
                            str1 = str4;
                            strArrays = new string[] { str1, "<td align='right' >", null, null, null, null };
                            num21 = Convert.ToDouble(usedInPdQuantity1.Rows[m]["finish_quantity"]);
                            strArrays[2] = num21.ToString();
                            strArrays[3] = "(";
                            strArrays[4] = usedInPdQuantity1.Rows[m]["finish_unit"].ToString();
                            strArrays[5] = ")</td>";
                            str4 = string.Concat(strArrays);
                            str1 = str4;
                            strArrays = new string[] { str1, "<td align='right' >", usedInPdQuantity1.Rows[m]["used_quantity"].ToString(), "(", usedInPdQuantity1.Rows[m]["unit_code"].ToString(), ")</td>" };
                            str4 = string.Concat(strArrays);
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", wastPercentage, "</td>" };
                            str4 = string.Concat(str);
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", num23, "(", usedInPdQuantity1.Rows[m]["unit_code"].ToString(), ")</td>" };
                            str4 = string.Concat(str);
                            obj = str4;
                            str = new object[] { obj, "<td align='right' >", num19, "(", usedInPdQuantity1.Rows[m]["unit_code"].ToString(), ")</td>" };
                            str4 = string.Concat(str);
                            str4 = string.Concat(str4, "</tr>");
                            this.lblFinishProductRpt.Text = str4;
                            num1 = num2;
                            num20 += num5;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadFinishedProductionProduction()
        {
            this.drpFinishedProduct.Items.Clear();
            DataSet productForPD = this.objProductBLL.GetProductForPD();
            if (productForPD != null && productForPD.Tables[0].Rows.Count > 0)
            {
                this.drpFinishedProduct.DataSource = productForPD;
                this.drpFinishedProduct.DataTextField = productForPD.Tables[0].Columns["item_name"].ToString();
                this.drpFinishedProduct.DataValueField = productForPD.Tables[0].Columns["item_id"].ToString();
                this.drpFinishedProduct.DataBind();
            }
            ListItem listItem = new ListItem("-- Select ---", "-99");
            this.drpFinishedProduct.Items.Insert(0, listItem);
        }

        private void LoadFinishedProductionProductionByDate(DateTime fdate, DateTime tdate)
        {
            this.drpFinishedProduct.Items.Clear();
            DataSet productForPDByDate = this.objProductBLL.GetProductForPDByDate(fdate, tdate);
            if (productForPDByDate != null && productForPDByDate.Tables[0].Rows.Count > 0)
            {
                this.drpFinishedProduct.DataSource = productForPDByDate;
                this.drpFinishedProduct.DataTextField = productForPDByDate.Tables[0].Columns["item_name"].ToString();
                this.drpFinishedProduct.DataValueField = productForPDByDate.Tables[0].Columns["item_id"].ToString();
                this.drpFinishedProduct.DataBind();
            }
            ListItem listItem = new ListItem("-- Select ---", "-99");
            this.drpFinishedProduct.Items.Insert(0, listItem);
        }

        private void LoadIngredience()
        {
            try
            {
                DataTable rawmaterials = this.objItem.GetRawmaterials();
                if (rawmaterials.Rows.Count > 0)
                {
                    this.drpIngredient.DataSource = rawmaterials;
                    this.drpIngredient.DataTextField = rawmaterials.Columns["item_name"].ToString();
                    this.drpIngredient.DataValueField = rawmaterials.Columns["item_id"].ToString();
                    this.drpIngredient.DataBind();
                }
                ListItem listItem = new ListItem("All", "-999");
                this.drpIngredient.Items.Insert(0, listItem);
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
                    this.LoadIngredience();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpIngredient.Items.Insert(0, listItem);
                    this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
                    this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.LoadFinishedProductionProduction();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}