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
    public partial class Challan_Form11sCheck : Page, IRequiresSessionState
    {
        private trnsNoteMasterBLL objtrnsNoteMasterBLL = new trnsNoteMasterBLL();

        private trnsSaleMasterBLL objtrnsSaleMasterBLL = new trnsSaleMasterBLL();

        private trnsSaleMasterDAO objtrnsSaleMasterDAO = new trnsSaleMasterDAO();

        private SaleBLL objSaleBLL = new SaleBLL();

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

        public Challan_Form11sCheck()
        {
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            AddItemBLL addItemBLL = new AddItemBLL();

            dulicate.Visible = false;

            short num;
            this.mushok11Panel.Visible = true;
            int num1 = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            this.objtrnsNoteMasterBLL.getOrgById(num1);
            this.objtrnsSaleMasterDAO.OrgName = this.Session["ORGANIZATION_NAME"].ToString();
            this.objtrnsSaleMasterDAO.OrgAddress = this.Session["ORGANIZATION_ADDRESS"].ToString();
            this.objtrnsSaleMasterDAO.OrgBIN = this.Session["ORGANIZATION_BIN"].ToString();
            //if (this.dtpDateFrom.Text != "")
            //{
            //    this.objtrnsSaleMasterDAO.StartDate = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //}
            //if (this.dtpDateTo.Text != "")
            //{
            //    trnsSaleMasterDAO _trnsSaleMasterDAO = this.objtrnsSaleMasterDAO;
            //    DateTime dateTime = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    _trnsSaleMasterDAO.FinishDate = dateTime.AddDays(1);
            //}
            trnsSaleMasterDAO _trnsSaleMasterDAO1 = this.objtrnsSaleMasterDAO;
            //if (Convert.ToInt16(this.ddlCustomer.SelectedValue) > 0)
            //{
            //    num = Convert.ToInt16(this.ddlCustomer.SelectedValue);
            //}
            //else
            //{
            //    num = 0;
            //}
           // _trnsSaleMasterDAO1.PartyId = num;
            this.objtrnsSaleMasterDAO.ChallanNo = (this.ddlChallanId.SelectedValue.ToString() != null ? this.ddlChallanId.SelectedValue.ToString() : "0");


            DataTable itemIsPriceDeclarNew = addItemBLL.getItemInvoicePrint(this.objtrnsSaleMasterDAO.ChallanNo);

            if (itemIsPriceDeclarNew.Rows.Count > 0)
            {
                dulicate.Visible = true;
            }





            BLL.Utility.InsertInvoicePrint(this.objtrnsSaleMasterDAO.ChallanNo);

          //  if (this.dtpDateFrom.Text != "" && this.dtpDateTo.Text != "")
          //  {
                this.LoadReport();
           // }
            this.FillDDL();
        }

        //protected void dateChangedGetChallan(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        DataTable dataTable = new DataTable();
        //        DataTable dataTable1 = new DataTable();
        //        dataTable = this.objtrnsSaleMasterBLL.GetAllChalanByDate(dateTime, dateTime1);
        //        if (dataTable != null && dataTable.Rows.Count > 0)
        //        {
        //            this.ddlChallanId.DataSource = dataTable;
        //            this.ddlChallanId.DataTextField = dataTable.Columns["challan_no"].ToString();
        //            this.ddlChallanId.DataValueField = dataTable.Columns["challan_id"].ToString();
        //            this.ddlChallanId.DataBind();
        //        }
        //        this.ddlChallanId.Items.Insert(0, new ListItem("---SELECT---", "-1"));
        //    }
        //    catch (Exception exception)
        //    {
        //    }
        //}

        protected void ddlChallanId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DataTable dataTable = new DataTable();
                int num = Convert.ToUInt16(this.ddlChallanId.SelectedValue);
                dataTable = this.objtrnsSaleMasterBLL.GetChallanByChallanId(num);
                //this.ddlCustomer.DataSource = dataTable;
                //this.ddlCustomer.DataTextField = dataTable.Columns["party_name"].ToString();
                //this.ddlCustomer.DataValueField = dataTable.Columns["party_id"].ToString();
                //this.ddlCustomer.DataBind();
                //if (this.ddlCustomer.SelectedValue != "-99")
                //{
                //    DataTable dataTable1 = new DataTable();
                //    dataTable1 = this.objtrnsSaleMasterBLL.GetinvoicebyChallanId(num);
                //    if (dataTable1 != null && dataTable1.Rows.Count > 0)
                //    {
                //        this.lblinvoice.Text = dataTable1.Rows[0]["invoice_no"].ToString();
                //    }
                //}
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.ddlCustomer.SelectedValue != "-99")
            //    {
            //        DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //        DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //        DataTable dataTable = new DataTable();
            //        int num = Convert.ToUInt16(this.ddlCustomer.SelectedValue);
            //        dataTable = this.objtrnsSaleMasterBLL.GetSaleChallanbyCustomebyDater(num, dateTime, dateTime1);
            //        if (dataTable != null && dataTable.Rows.Count > 0)
            //        {
            //            this.ddlChallanId.DataSource = dataTable;
            //            this.ddlChallanId.DataTextField = dataTable.Columns["challan_no"].ToString();
            //            this.ddlChallanId.DataValueField = dataTable.Columns["challan_id"].ToString();
            //            this.ddlChallanId.DataBind();
            //        }
            //        this.ddlChallanId.Items.Insert(0, new ListItem("---SELECT---", "-1"));
            //    }
            //}
            //catch (Exception exception)
            //{
            //    ReallySimpleLog.WriteLog(exception);
            //}
        }

        private void FillDDL()
        {
            DataTable dataTable = new DataTable();
            DataTable customer = new DataTable();
            DataTable allChalanByDate = new DataTable();
            DateTime dateTime = DateTime.ParseExact("01/01/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact("01/01/2025", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            try
            {
                dataTable = this.objtrnsSaleMasterBLL.GetSkuNo();
                customer = this.objtrnsSaleMasterBLL.GetCustomer();
                allChalanByDate = this.objtrnsSaleMasterBLL.GetAllChalanByDate(dateTime, dateTime1);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    //this.ddlSKU.DataSource = dataTable;
                    //this.ddlSKU.DataTextField = dataTable.Columns["item_sku"].ToString();
                    //this.ddlSKU.DataValueField = dataTable.Columns["item_id"].ToString();
                    //this.ddlSKU.DataBind();
                }
                if (customer != null && customer.Rows.Count > 0)
                {
                    //this.ddlCustomer.DataSource = customer;
                    //this.ddlCustomer.DataTextField = customer.Columns["party_name"].ToString();
                    //this.ddlCustomer.DataValueField = customer.Columns["party_id"].ToString();
                    //this.ddlCustomer.DataBind();
                }
                //this.ddlSKU.Items.Insert(0, new ListItem("---SELECT---", "-1"));
                //this.ddlCustomer.Items.Insert(0, new ListItem("---Select Customer---", "-1"));
                if (allChalanByDate != null && allChalanByDate.Rows.Count > 0)
                {
                    this.ddlChallanId.DataSource = allChalanByDate;
                    this.ddlChallanId.DataTextField = allChalanByDate.Columns["challan_no"].ToString();
                    this.ddlChallanId.DataValueField = allChalanByDate.Columns["challan_id"].ToString();
                    this.ddlChallanId.DataBind();
                }
                this.ddlChallanId.Items.Insert(0, new ListItem("---SELECT---", "-1"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadReport()
        {
            DateTime dateTime;
            object obj;
            object[] num;
            PriceDeclaretionBLL priceDeclaretionBLL = new PriceDeclaretionBLL();
            DataTable dataTable = new DataTable();
            try
            {
                string str = "";
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                string str1 = "";
                string str2 = "Per Unit";
                string str3 = "Tk.";
                string str4 = "";
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                int num10 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                dataTable = this.objtrnsSaleMasterBLL.rptChallanForm112(this.objtrnsSaleMasterDAO);
                int num11 = 0;
                num11 = Convert.ToInt32(this.ddlChallanId.SelectedValue);
                if (dataTable == null)
                {
                    this.mushok11Panel.Visible = false;
                }
                else if (dataTable.Rows.Count > 0)
                {
                    this.OrgName.Text = dataTable.Rows[0]["OrgName1"].ToString();
                    this.OrgAddress.Text = dataTable.Rows[0]["OrgAddress"].ToString();
                    this.OrgTin.Text = dataTable.Rows[0]["OrgTin"].ToString();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        decimal num12 = Convert.ToDecimal(dataTable.Rows[i]["property_quantity"].ToString());
                        int num13 = Convert.ToInt16(dataTable.Rows[i]["item_id"]);
                        string str5 = "";
                        DataTable dataTable1 = priceDeclaretionBLL.geAdditionalPropertybySaleChallanID(num13, num11);
                        if (dataTable1.Rows.Count > 0)
                        {
                            for (int j = 0; j < dataTable1.Rows.Count; j++)
                            {
                                if (dataTable1.Rows[j]["property_id1_value"].ToString() != "")
                                {
                                    str5 = string.Concat(str5, dataTable1.Rows[j]["property_id1_value"].ToString());
                                }
                                if (dataTable1.Rows[j]["property_id2_value"].ToString() != "")
                                {
                                    str5 = string.Concat(str5, ",", dataTable1.Rows[j]["property_id2_value"].ToString());
                                }
                                if (dataTable1.Rows[j]["property_id3_value"].ToString() != "")
                                {
                                    str5 = string.Concat(str5, ",", dataTable1.Rows[j]["property_id3_value"].ToString());
                                }
                                if (dataTable1.Rows[j]["property_id4_value"].ToString() != "")
                                {
                                    str5 = string.Concat(str5, ",", dataTable1.Rows[j]["property_id4_value"].ToString());
                                }
                                if (dataTable1.Rows[j]["property_id5_value"].ToString() != "")
                                {
                                    str5 = string.Concat(str5, ",", dataTable1.Rows[j]["property_id5_value"].ToString());
                                }
                            }
                        }
                        DataTable dataTable2 = priceDeclaretionBLL.gethsCodebyItemID(num13);
                        if (dataTable2.Rows.Count > 0)
                        {
                            if (dataTable2.Rows[0]["hs_code"].ToString() == "2402.20.00" || dataTable2.Rows[0]["hs_code"].ToString() == "2402.90.00" || dataTable2.Rows[0]["hs_code"].ToString() == "2403.99.00")
                            {
                                decimal num14 = Convert.ToDecimal(dataTable.Rows[i]["Quantity"].ToString()) / num12;
                                string str6 = Utilities.formatFraction(num14);
                                this.Customer_name.Text = dataTable.Rows[i]["Customer_name"].ToString();
                                this.Customer_Address.Text = dataTable.Rows[i]["Customer_Address"].ToString();
                                if (string.IsNullOrWhiteSpace(dataTable.Rows[i]["party_bin"].ToString()) || !(dataTable.Rows[i]["party_bin"].ToString() != ""))
                                {
                                    this.Customer_TIN.Text = dataTable.Rows[i]["nid"].ToString();
                                }
                                else
                                {
                                    this.Customer_TIN.Text = dataTable.Rows[i]["party_bin"].ToString();
                                }
                                this.Goods_Services_Ship.Text = dataTable.Rows[i]["Goods_Services_Shipping_Address"].ToString();
                                this.txtTransport.Text = string.Concat(dataTable.Rows[i]["code_name"].ToString(), " ", dataTable.Rows[i]["Vehicle_No"].ToString());
                                this.Challan_No.Text = dataTable.Rows[i]["Challan_No"].ToString();
                                this.Challan_Date.Text = dataTable.Rows[i]["Challan_Date"].ToString();
                                Label challanTime = this.Challan_Time;
                                dateTime = Convert.ToDateTime(dataTable.Rows[i]["Challan_Time"].ToString());
                                challanTime.Text = dateTime.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
                                str4 = dataTable.Rows[i]["is_fixed_vat"].ToString();
                                num1 = Convert.ToDecimal(dataTable.Rows[i]["SD_Applicable_Price"]) * num12;
                                num2 = Convert.ToDecimal(dataTable.Rows[i]["SD_Amount"].ToString());
                                num3 = Convert.ToDecimal(dataTable.Rows[i]["VAT_Amount"].ToString());
                                num7 = Convert.ToDecimal(dataTable.Rows[i]["vat_rate"].ToString());
                                str1 = dataTable.Rows[i]["item_specification"].ToString();
                                decimal num15 = new decimal(0);
                                num15 = Convert.ToDecimal(dataTable.Rows[i]["sale_quantity"].ToString()) * num1;
                                str = string.Concat(str, "<tr  style='line-height:20px;'>");
                                obj = str;
                                num = new object[] { obj, "<td style='text-align:center;'>", i + 1, "</td>" };
                                str = string.Concat(num);
                                string str7 = str;
                                string[] strArrays = new string[] { str7, "<td>", dataTable.Rows[i]["Goods_Services_Name"].ToString(), " ", dataTable.Rows[i]["itemserials"].ToString(), "</td>" };
                                str = string.Concat(strArrays);
                                if (str1 == "")
                                {
                                    str = string.Concat(str, "<td>", dataTable.Rows[i]["unit"].ToString(), " </td>");
                                }
                                else
                                {
                                    object obj1 = str;
                                    object[] objArray = new object[] { obj1, "<td>", dataTable.Rows[i]["unit"].ToString(), "  ", '-', " ", str1, "</td>" };
                                    str = string.Concat(objArray);
                                }
                                str = string.Concat(str, "<td style='text-align:right;'>", str6, "</td>");
                                str = string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num1, num10), "</td>");
                                str = string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num15, num10), "</td>");
                                object obj2 = str;
                                object[] objArray1 = new object[] { obj2, "<td style='text-align:right;'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["sd_rate"])), '%', "</td>" };
                                str = string.Concat(objArray1);
                                str = string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num2, num10), "</td>");
                                if (str4 != "True")
                                {
                                    object obj3 = str;
                                    object[] objArray2 = new object[] { obj3, "<td style='text-align:right;'>", num7, '%', "</td>" };
                                    str = string.Concat(objArray2);
                                }
                                else
                                {
                                    object obj4 = str;
                                    object[] objArray3 = new object[] { obj4, "<td style='text-align:right;'>", str3, num7, " ", str2, "</td>" };
                                    str = string.Concat(objArray3);
                                }
                                str = string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num3, num10), "</td>");
                                str = string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num15, num10), "</td>");
                                str = string.Concat(str, "</tr>");
                                num5 += num2;
                                num4 += num3;
                                num6 += num15;
                                num8 += num15;
                                num9 += Convert.ToDecimal(dataTable.Rows[i]["discount_amt"].ToString());
                            }
                            else
                            {
                                decimal num16 = Convert.ToDecimal(dataTable.Rows[i]["sale_quantity"].ToString());
                                string str8 = Utilities.formatFraction(num16);
                                this.Customer_name.Text = dataTable.Rows[i]["Customer_name"].ToString();
                                this.Customer_Address.Text = dataTable.Rows[i]["Customer_Address"].ToString();
                                if (string.IsNullOrWhiteSpace(dataTable.Rows[i]["party_bin"].ToString()) || !(dataTable.Rows[i]["party_bin"].ToString() != ""))
                                {
                                    this.Customer_TIN.Text = dataTable.Rows[i]["nid"].ToString();
                                }
                                else
                                {
                                    this.Customer_TIN.Text = dataTable.Rows[i]["party_bin"].ToString();
                                }
                                this.Goods_Services_Ship.Text = dataTable.Rows[i]["Goods_Services_Shipping_Address"].ToString();
                                this.txtTransport.Text = string.Concat(dataTable.Rows[i]["code_name"].ToString(), " ", dataTable.Rows[i]["Vehicle_No"].ToString());
                                this.Challan_No.Text = dataTable.Rows[i]["Challan_No"].ToString();
                                this.Challan_Date.Text = dataTable.Rows[i]["Challan_Date"].ToString();
                                Label label = this.Challan_Time;
                                DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[i]["Challan_Time"].ToString());
                                label.Text = dateTime1.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
                                str4 = dataTable.Rows[i]["is_fixed_vat"].ToString();
                                num1 = Convert.ToDecimal(dataTable.Rows[i]["SD_Applicable_Price"].ToString());
                                num2 = Convert.ToDecimal(dataTable.Rows[i]["SD_Amount"].ToString());
                                num3 = Convert.ToDecimal(dataTable.Rows[i]["VAT_Amount"].ToString());
                                num7 = Convert.ToDecimal(dataTable.Rows[i]["vat_rate"].ToString());
                                str1 = dataTable.Rows[i]["item_specification"].ToString();
                                decimal num17 = new decimal(0);
                                num17 = Convert.ToDecimal(dataTable.Rows[i]["Quantity"].ToString()) * num1;
                                str = string.Concat(str, "<tr style='line-height:20px;'>");
                                object obj5 = str;
                                object[] objArray4 = new object[] { obj5, "<td style='text-align:center;'>", i + 1, "</td>" };
                                str = string.Concat(objArray4);
                                string str9 = str;
                                string[] strArrays1 = new string[] { str9, "<td>", dataTable.Rows[i]["Goods_Services_Name"].ToString(), " ", dataTable.Rows[i]["itemserials"].ToString(), " ", null, null };
                                string str10 = str5.Trim();
                                char[] chrArray = new char[] { ',' };
                                strArrays1[6] = str10.TrimEnd(chrArray);
                                strArrays1[7] = " </td>";
                                str = string.Concat(strArrays1);
                                if (str1 == "")
                                {
                                    str = string.Concat(str, "<td>", dataTable.Rows[i]["UNIT"].ToString(), "</td>");
                                }
                                else
                                {
                                    object obj6 = str;
                                    object[] objArray5 = new object[] { obj6, "<td>", dataTable.Rows[i]["UNIT"].ToString(), " ", '-', " ", str1, "</td>" };
                                    str = string.Concat(objArray5);
                                }
                                str = (str8 != "0" ? string.Concat(str, "<td style='text-align:right;'>", str8, "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                                if (num1 != new decimal(0))
                                {
                                    str = (num12 == new decimal(0) ? string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num1, num10), "</td>") : string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num1 * num12, num10), "</td>"));
                                }
                                else
                                {
                                    str = string.Concat(str, "<td style='text-align:right;'>-</td>");
                                }
                                str = (num17 != new decimal(0) ? string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num17, num10), "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                                if (Convert.ToDecimal(dataTable.Rows[i]["sd_rate"]) != new decimal(0))
                                {
                                    object obj7 = str;
                                    object[] objArray6 = new object[] { obj7, "<td style='text-align:right;'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["sd_rate"])), '%', "</td>" };
                                    str = string.Concat(objArray6);
                                }
                                else
                                {
                                    str = string.Concat(str, "<td style='text-align:right;'>-</td>");
                                }
                                str = (num2 != new decimal(0) ? string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num2, num10), "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                                if (str4 == "True")
                                {
                                    object obj8 = str;
                                    object[] objArray7 = new object[] { obj8, "<td style='text-align:right;'>", str3, num7, " ", str2, "</td>" };
                                    str = string.Concat(objArray7);
                                }
                                else if (num7 != new decimal(0))
                                {
                                    obj = str;
                                    num = new object[] { obj, "<td style='text-align:right;'>", num7, '%', "</td>" };
                                    str = string.Concat(num);
                                }
                                else
                                {
                                    str = string.Concat(str, "<td style='text-align:right;'>-</td>");
                                }
                                str = (num3 != new decimal(0) ? string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString(num3, num10), "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                                str = (((num17 + num2) + num3) != new decimal(0) ? string.Concat(str, "<td style='text-align:right;'>", Utilities.RoundUpToWithString((num17 + num2) + num3, num10), "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                                str = string.Concat(str, "</tr>");
                                num5 += num2;
                                num4 += num3;
                                num6 = num6 + (num17 + num2) + num3;
                                num8 += num17;
                                num9 += Convert.ToDecimal(dataTable.Rows[i]["discount_amt"].ToString());
                            }
                        }
                    }
                    DataTable giftListOnSale = new DataTable();
                    giftListOnSale = this.objSaleBLL.getGiftListOnSale(Convert.ToInt32(this.ddlChallanId.SelectedValue));
                    if (giftListOnSale.Rows.Count > 0)
                    {
                        int count = dataTable.Rows.Count;
                        for (int k = 0; k < giftListOnSale.Rows.Count; k++)
                        {
                            str = string.Concat(str, "<tr style='line-height:20px;'>");
                            obj = str;
                            num = new object[] { obj, "<td style='text-align:center;'>", count + k + 1, "</td>" };
                            str = string.Concat(num);
                            str = string.Concat(str, "<td>", giftListOnSale.Rows[k]["item_name"].ToString(), " (Gift) </td>");
                            str = string.Concat(str, "<td>", giftListOnSale.Rows[k]["unit_name"].ToString(), " </td>");
                            obj = str;
                            num = new object[] { obj, "<td  style='text-align:right;' >", Convert.ToDouble(giftListOnSale.Rows[k]["quantity"]), " </td>" };
                            str = string.Concat(num);
                            str = string.Concat(str, "<td> - </td>");
                            str = string.Concat(str, "<td> - </td>");
                            str = string.Concat(str, "<td> - </td>");
                            str = string.Concat(str, "<td> - </td>");
                            str = string.Concat(str, "<td> - </td>");
                            str = string.Concat(str, "<td> - </td>");
                            str = string.Concat(str, "<td> - </td>");
                            str = string.Concat(str, "</tr>");
                        }
                    }
                    str = string.Concat(str, "<tr> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> <td> &nbsp </td> </tr> ");
                    str = string.Concat(str, "<tr style=' border: 2px solid black;line-height:10px;'>");
                    str = string.Concat(str, "<td colspan='5' style='text-align:right; padding:5px;font-weight:bold'>মোট =</td>");
                    str = string.Concat(str, "<td style='text-align:right; font-weight:bold'>", num8.ToString("N2"), "</td>");
                    str = string.Concat(str, "<td style='font-weight:bold'></td>");
                    str = (num5 != new decimal(0) ? string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", num5.ToString("N2"), "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                    str = string.Concat(str, "<td></td>");
                    str = (num4 != new decimal(0) ? string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", num4.ToString("N2"), "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                    str = (num6 != new decimal(0) ? string.Concat(str, "<td style='text-align:right; padding:2px;font-weight:bold'>", num6.ToString("N2"), "</td>") : string.Concat(str, "<td style='text-align:right;'>-</td>"));
                    str = string.Concat(str, "</tr>");
                    if (num9 > new decimal(0))
                    {
                        decimal num18 = new decimal(0);
                        num18 = num6 - num9;
                        str = string.Concat(str, "<tr style=' border: 2px solid black;line-height:10px;'>");
                        str = string.Concat(str, "<td colspan='5' style='text-align:right; padding:2px;font-weight:bold'>ছাড় =</td>");
                        str = string.Concat(str, "<td colspan='6'   style='text-align:right; font-weight:bold'>", num9.ToString("N2"), "</td>");
                        str = string.Concat(str, "</tr>");
                        str = string.Concat(str, "<tr style=' border: 2px solid black;line-height:10px;'>");
                        str = string.Concat(str, "<td colspan='5' style='text-align:right; padding:2px;font-weight:bold'>সর্বমোট =</td>");
                        str = string.Concat(str, "<td colspan='6'   style='text-align:right; font-weight:bold'>", num18.ToString("N2"), "</td>");
                        str = string.Concat(str, "</tr>");
                    }
                    this.lblReportHtml.Text = str;
                    this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                }
               // TextBox textBox = this.dtpDateFrom;
                dateTime = DateTime.UtcNow;
               // textBox.Text = dateTime.ToString("dd/MM/yyyy");
               // TextBox textBox1 = this.dtpDateTo;
                dateTime = DateTime.UtcNow;
               // textBox1.Text = dateTime.ToString("dd/MM/yyyy");
                this.Session["Challan_Form_11_rpt"] = new DataSet();
                this.FillDDL();
                this.ddlChallanId.Items.Clear();
                this.ddlChallanId.Items.Insert(0, new ListItem("---SELECT---", "-1"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                //this.dtpDateFrom.Text = DateTime.UtcNow.ToString("dd/MM/yyyy");
                //this.dtpDateTo.Text = DateTime.UtcNow.ToString("dd/MM/yyyy");
                //this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.Session["Challan_Form_11_rpt"] = new DataSet();
                this.mushok11Panel.Visible = false;
                this.FillDDL();
            }
        }
    }
}