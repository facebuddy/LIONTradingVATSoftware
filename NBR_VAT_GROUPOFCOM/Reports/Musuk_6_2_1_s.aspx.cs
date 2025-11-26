using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.Api;
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
    public partial class Musuk_6_2_1_s : Page, IRequiresSessionState
    {
      

        private trnsPurchaseMasterBLL objPMBLL = new trnsPurchaseMasterBLL();

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

        public Musuk_6_2_1_s()
        {
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.showReport();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
              NBR_VAT_GROUPOFCOM.BLL.Utility.fillAllItemNS(this.ddlItem);
             
                var returnList = MushakAPI.ProductList();

                // DataTable dt2 = new DataTable();
                //  DataColumn dc2 = dataTable.Columns.Add("note_id", typeof(int));
                // dataTable.Columns.Add("note_no", typeof(String));

                foreach (var item in returnList)
                {
                    ListItem listItems = new ListItem(item.name, item.product_id);
                    this.ddlItem.Items.Insert(0, listItems);
                    // this.ddlItem.Items.Insert( item.name,Convert.ToString(item.product_id));
                    // allItemForReport621.Rows.Add(item.note_no, item.note_id.ToString());
                }
                ListItem listItem = new ListItem("----Select----", "-99");
                this.ddlItem.Items.Insert(0, listItem);
                this.dtpDateFrom.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["employee_name"].ToString();
                this.TaxOrganizationName.Text = (this.Session["ORGANIZATION_NAME"] != null ? this.Session["ORGANIZATION_NAME"].ToString() : "n/a");
                this.TaxOrganizationAddress.Text = (this.Session["ORGANIZATION_ADDRESS"] != null ? this.Session["ORGANIZATION_ADDRESS"].ToString() : "n/a");
                string str = this.Session["ORGANIZATION_BIN"].ToString();
                string str1 = "";
                for (int i = 0; i < str.Length; i++)
                {
                    object obj = str1;
                    object[] objArray = new object[] { obj, "<input type='text' value = '", str[i], "' runat='server' style='width:25px; text-align:center;border:1px solid #000'>" };
                    str1 = string.Concat(objArray);
                    this.TaxOrganizationBIN.Text = str1;
                }
            }
        }

        private void showReport()
        {
            object obj;
            object[] str;
            try
            {

                string def = this.ddlItem.SelectedItem.Text;

              //  var mushak = string start_date = Convert.ToDateTime(HttpContext.Current.Session["fDateSubs"]).ToString("yyyy-MM-dd");
              //  string end_date = Convert.ToDateTime(HttpContext.Current.Session["tDateSubs"]).ToString("yyyy-MM-dd");
                var productObj = MushakAPI.IsProductExist(def);
                if(productObj!=null)
                {
                  //  DateTime dateTime3 = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                   // DateTime dateTime4 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                   string start_date = Convert.ToDateTime(this.dtpDateFrom.Text.ToString()).ToString("yyyy-MM-dd");
                      string end_date = Convert.ToDateTime(this.dtpDateTo.Text.ToString()).ToString("yyyy-MM-dd");

                    int productId = Convert.ToInt32(this.ddlItem.SelectedValue);
                    var vatSixOneList =  MushakAPI.GetVatSixOneList(start_date, end_date, productId);

                    string str1 = "-";
                    string str3 = "";
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    string empty3 = string.Empty;
                    string empty4 = string.Empty;
                    string str4 = string.Empty;
                    string empty5 = string.Empty;
                    string str5 = string.Empty;
                    string empty6 = string.Empty;
                    decimal num9 = new decimal(0);
                    decimal num10 = new decimal(0);
                    decimal num11 = new decimal(0);
                    decimal num12 = new decimal(0);
                    string str6 = string.Empty;
                    string empty7 = string.Empty;
                    string str7 = string.Empty;
                    string empty8 = string.Empty;
                    string str8 = string.Empty;
                    string empty9 = string.Empty;
                    string str9 = string.Empty;

                    int j = 0;

                    foreach(var itm in vatSixOneList.vatList)
                    {
                        j = j + 1;
                            str3 = string.Concat(str3, "<tr>");
                            obj = str3;
                            str = new object[] { obj, "<td style='text-align: center;'>", j, "</td>" };
                            str3 = string.Concat(str);
                            str3 =  string.Concat(str3, "<td>", itm.transaction_date.ToString("dd-MM-yyyy"), "</td>");
                            str3 = string.Concat(str3, "<td>",itm.product_name, "</td>");
                           
                          
                                str3 = string.Concat(str3, "<td style='text-align: right;'>",itm.opening, "</td>");
                            
                         
                                str3 = string.Concat(str3, "<td style='text-align: right;'>",itm.quantity_purchase,"</td>");
                            
                            str3 =  string.Concat(str3, "<td style='text-align: right;'>",+itm.purchase_total_amount,"</td>");
                        
                       
                                str3 = string.Concat(str3, "<td style='text-align: right;'>",itm.paromvikjer+"</td>");
                            
                            str3 = string.Concat(str3, "<td style='text-align: left;'>", itm.supplier_name , "</td>");
                            str3 = string.Concat(str3, "<td style='width: 20%;text-align: left;'>", itm.supplier_address, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", itm.supplier_vat_reg_no, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", itm.tracking_no, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", itm.product_name_biboron, "</td>");
                        
                                str3 = string.Concat(str3, "<td style='text-align: right;'>", itm.sale_quantity, "</td>");
                            
                            str3 =  string.Concat(str3, "<td style='text-align: right;'>",itm.net_amount_without_mushok ,"</td>");
                            str3 =string.Concat(str3, "<td style='text-align: right;'>-</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>",itm.vat_amount,"</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", itm.distributor_name, "</td>");
                            str3 = string.Concat(str3, "<td style='width: 20%;text-align: right;'>", itm.distributor_address, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", itm.distributor_reg_number, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>", itm.invoice_no, "</td>");
                            str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                       
                                str3 = string.Concat(str3, "<td style='text-align: right;'>",itm.prantikjet,"</td>");
                           
                            str3 = string.Concat(str3, "<td>",itm.montobbo, "</td>");
               
                            str3 = string.Concat(str3, "</tr>");
                      
                          

                    }

                    this.lblReportView.Text = str3;

                }
                else
                {


                    DataTable dataTable = new DataTable();
                    int num = Convert.ToInt32(this.ddlItem.SelectedValue);
                    string str1 = this.ddlItem.SelectedItem.ToString();
                    int num1 = 0;
                    DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    empty = this.dtpDateFrom.Text.ToString();
                    empty1 = this.dtpDateTo.Text.ToString();
                    DateTime dateTime2 = DateTime.ParseExact(empty1, "dd/MM/yyyy", null);
                    dateTime2.AddDays(1).ToString("dd/MM/yyyy");
                    int num2 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
                    DataTable openingBalanceStock = new DataTable();
                    decimal num3 = new decimal(0);
                    decimal num4 = new decimal(0);
                    openingBalanceStock = this.objPMBLL.GetOpeningBalanceStock(num);
                    DataTable purchaseInfo = this.objPMBLL.GetPurchaseInfo(num);
                    DataTable itemType = this.objPMBLL.GetItemType(num);
                    if (openingBalanceStock.Rows.Count > 0)
                    {
                        num3 = Convert.ToDecimal(openingBalanceStock.Rows[0]["item_qty"]);
                        num4 = Convert.ToDecimal(openingBalanceStock.Rows[0]["item_value"]);
                    }
                    string str2 = "";
                    if (itemType.Rows.Count > 0)
                    {
                        str2 = itemType.Rows[0]["item_type"].ToString();
                    }
                    if (str2 != "S")
                    {
                        dataTable = this.objPMBLL.PurchaseNSale621(dateTime, dateTime1, num, num1);
                        if (dataTable.Rows.Count > 0)
                        {
                            string str3 = "";
                            decimal num5 = new decimal(0);
                            decimal num6 = new decimal(0);
                            decimal num7 = new decimal(0);
                            decimal num8 = new decimal(0);
                            string empty3 = string.Empty;
                            string empty4 = string.Empty;
                            string str4 = string.Empty;
                            string empty5 = string.Empty;
                            string str5 = string.Empty;
                            string empty6 = string.Empty;
                            decimal num9 = new decimal(0);
                            decimal num10 = new decimal(0);
                            decimal num11 = new decimal(0);
                            decimal num12 = new decimal(0);
                            string str6 = string.Empty;
                            string empty7 = string.Empty;
                            string str7 = string.Empty;
                            string empty8 = string.Empty;
                            string str8 = string.Empty;
                            string empty9 = string.Empty;
                            string str9 = string.Empty;
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                num5 = num3 + Convert.ToDecimal(dataTable.Rows[i]["prarombik_jer_poriman_3"]);
                                num6 = num4;
                                num7 = Convert.ToDecimal(dataTable.Rows[i]["poriman_5"]);
                                num8 = Convert.ToDecimal(dataTable.Rows[i]["mullo_6"]);
                                empty3 = dataTable.Rows[i]["name_9"].ToString();
                                empty4 = dataTable.Rows[i]["address_10"].ToString();
                                str4 = dataTable.Rows[i]["national_id_11"].ToString();
                                empty5 = dataTable.Rows[i]["challan_no_12"].ToString();
                                empty9 = dataTable.Rows[i]["date_2"].ToString();
                                str5 = dataTable.Rows[i]["date_challan_13"].ToString();
                                empty6 = dataTable.Rows[i]["biboron_14"].ToString();
                                char[] chrArray = new char[] { '(' };
                                empty6 = empty6.Split(chrArray)[0];
                                num9 = Convert.ToDecimal(dataTable.Rows[i]["poriman_15"]);
                                num10 = Convert.ToDecimal(dataTable.Rows[i]["korjoggo_mullo_16"]);
                                num11 = Convert.ToDecimal(dataTable.Rows[i]["sompurok_sulko_17"]);
                                num12 = Convert.ToDecimal(dataTable.Rows[i]["mushok_18"]);
                                str6 = dataTable.Rows[i]["name_19"].ToString();
                                empty7 = dataTable.Rows[i]["address_20"].ToString();
                                str7 = dataTable.Rows[i]["national_id_no_21"].ToString();
                                empty8 = dataTable.Rows[i]["challan_no_22"].ToString();
                                str8 = dataTable.Rows[i]["challan_date_23"].ToString();
                                str9 = dataTable.Rows[i]["montobbo_26"].ToString();
                                if (i != 0)
                                {
                                    decimal num13 = new decimal(0);
                                    decimal num14 = new decimal(0);
                                    decimal num15 = new decimal(0);
                                    decimal num16 = new decimal(0);
                                    decimal num17 = new decimal(0);
                                    if (this.hiddenPrantikJerQty.Value != "")
                                    {
                                        num17 = Convert.ToDecimal(this.hiddenPrantikJerQty.Value);
                                        Convert.ToDecimal(this.hiddenPrantikJerValue.Value);
                                    }
                                    num5 = Convert.ToDecimal(dataTable.Rows[i]["prarombik_jer_poriman_3"]);
                                    str3 = string.Concat(str3, "<tr>");
                                    obj = str3;
                                    str = new object[] { obj, "<td style='text-align: center;'>", i + 1, "</td>" };
                                    str3 = string.Concat(str);
                                    str3 = (empty9 == "-" ? string.Concat(str3, "<td>", str8.ToString(), "</td>") : string.Concat(str3, "<td>", empty9.ToString(), "</td>"));
                                    str3 = string.Concat(str3, "<td>", str1, "</td>");
                                    if (num17 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num17, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    if (num7 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num7, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    str3 = (num8 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num8, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    num13 = num17 + num7;
                                    if (num13 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num13, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    str3 = string.Concat(str3, "<td style='text-align: left;'>", empty3, "</td>");
                                    str3 = string.Concat(str3, "<td style='width: 20%;text-align: left;'>", empty4, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str4, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", empty5, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str5, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", empty6, "</td>");
                                    if (num9 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num9, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    str3 = (num10 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num10, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    str3 = (num11 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num11, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    str3 = (num12 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num12, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str6, "</td>");
                                    str3 = string.Concat(str3, "<td style='width: 20%;text-align: right;'>", empty7, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str7, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", empty8, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str8, "</td>");
                                    num15 = (dataTable.Rows[i]["status"].ToString() == "True" ? num13 : num13 - num9);
                                    num16 = num14 - num10;
                                    if (num15 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num15, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    str3 = string.Concat(str3, "<td>", str9, "</td>");
                                    this.hiddenPrantikJerQty.Value = "";
                                    this.hiddenPrantikJerValue.Value = "";
                                    this.hiddenPrantikJerQty.Value = num15.ToString();
                                    this.hiddenPrantikJerValue.Value = Utilities.RoundUpToWithString(num16, num2);
                                    str3 = string.Concat(str3, "</tr>");
                                }
                                else
                                {
                                    this.hiddenPrantikJerQty.Value = "";
                                    this.hiddenPrantikJerValue.Value = "";
                                    decimal num18 = new decimal(0);
                                    decimal num19 = new decimal(0);
                                    decimal num20 = new decimal(0);
                                    decimal num21 = new decimal(0);
                                    str3 = string.Concat(str3, "<tr>");
                                    obj = str3;
                                    str = new object[] { obj, "<td style='text-align: center;'>", i + 1, "</td>" };
                                    str3 = string.Concat(str);
                                    str3 = string.Concat(str3, "<td>", empty, "</td>");
                                    str3 = string.Concat(str3, "<td>", str1, "</td>");
                                    if (num5 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num5, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    if (num7 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num7, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    str3 = (num8 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num8, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    num18 = num5 + num7;
                                    if (num18 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num18, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    str3 = string.Concat(str3, "<td style='text-align: left;'>", empty3, "</td>");
                                    str3 = string.Concat(str3, "<td style='width: 20%;text-align: left;'>", empty4, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str4, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", empty5, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str5, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", empty6, "</td>");
                                    if (num9 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num9, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    str3 = (num10 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num10, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    str3 = (num11 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num11, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    str3 = (num12 != new decimal(0) ? string.Concat(str3, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num12, num2), "</td>") : string.Concat(str3, "<td style='text-align: right;'>-</td>"));
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str6, "</td>");
                                    str3 = string.Concat(str3, "<td style='width: 20%;text-align: right;'>", empty7, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str7, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", empty8, "</td>");
                                    str3 = string.Concat(str3, "<td style='text-align: right;'>", str8, "</td>");
                                    num20 = (dataTable.Rows[i]["status"].ToString() == "True" ? num18 : num18 - num9);
                                    num21 = num19 - num10;
                                    if (num20 != new decimal(0))
                                    {
                                        obj = str3;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num20, '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                                        str3 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str3 = string.Concat(str3, "<td style='text-align: right;'>-</td>");
                                    }
                                    this.hiddenPrantikJerQty.Value = num20.ToString();
                                    this.hiddenPrantikJerValue.Value = Utilities.RoundUpToWithString(num21, num2);
                                    str3 = string.Concat(str3, "<td>", str9, "</td>");
                                    str3 = string.Concat(str3, "</tr>");
                                }
                                this.lblReportView.Text = str3;
                            }
                        }
                    }
                    else if (purchaseInfo.Rows.Count < 1)
                    {
                        dataTable = this.objPMBLL.PurchaseNSale621(dateTime, dateTime1, num, num1);
                        if (dataTable.Rows.Count > 0)
                        {
                            string str10 = "";
                            decimal num22 = new decimal(0);
                            decimal num23 = new decimal(0);
                            decimal num24 = new decimal(0);
                            decimal num25 = new decimal(0);
                            string empty10 = string.Empty;
                            string empty11 = string.Empty;
                            string str11 = string.Empty;
                            string empty12 = string.Empty;
                            string str12 = string.Empty;
                            decimal num26 = new decimal(0);
                            decimal num27 = new decimal(0);
                            string empty13 = string.Empty;
                            decimal num28 = new decimal(0);
                            decimal num29 = new decimal(0);
                            decimal num30 = new decimal(0);
                            decimal num31 = new decimal(0);
                            string str13 = string.Empty;
                            string empty14 = string.Empty;
                            string str14 = string.Empty;
                            string empty15 = string.Empty;
                            string str15 = string.Empty;
                            string empty16 = string.Empty;
                            for (int j = 0; j < dataTable.Rows.Count; j++)
                            {
                                num22 = num3 + Convert.ToDecimal(dataTable.Rows[j]["prarombik_jer_poriman_3"]);
                                num23 = num4;
                                num24 = Convert.ToDecimal(dataTable.Rows[j]["poriman_5"]);
                                num25 = Convert.ToDecimal(dataTable.Rows[j]["mullo_6"]);
                                empty10 = dataTable.Rows[j]["name_9"].ToString();
                                empty11 = dataTable.Rows[j]["address_10"].ToString();
                                str11 = dataTable.Rows[j]["national_id_11"].ToString();
                                empty12 = dataTable.Rows[j]["challan_no_12"].ToString();
                                str12 = dataTable.Rows[j]["date_challan_13"].ToString();
                                empty13 = dataTable.Rows[j]["biboron_14"].ToString();
                                num28 = Convert.ToDecimal(dataTable.Rows[j]["poriman_15"]);
                                num29 = Convert.ToDecimal(dataTable.Rows[j]["korjoggo_mullo_16"]);
                                num30 = Convert.ToDecimal(dataTable.Rows[j]["sompurok_sulko_17"]);
                                num31 = Convert.ToDecimal(dataTable.Rows[j]["mushok_18"]);
                                str13 = dataTable.Rows[j]["name_19"].ToString();
                                empty14 = dataTable.Rows[j]["address_20"].ToString();
                                str14 = dataTable.Rows[j]["national_id_no_21"].ToString();
                                empty15 = dataTable.Rows[j]["challan_no_22"].ToString();
                                str15 = dataTable.Rows[j]["challan_date_23"].ToString();
                                empty16 = dataTable.Rows[j]["montobbo_26"].ToString();
                                if (j != 0)
                                {
                                    decimal num32 = new decimal(0);
                                    decimal num33 = new decimal(0);
                                    decimal num34 = new decimal(0);
                                    decimal num35 = new decimal(0);
                                    decimal num36 = new decimal(0);
                                    if (this.hiddenPrantikJerQty.Value != "")
                                    {
                                        num36 = Convert.ToDecimal(this.hiddenPrantikJerQty.Value);
                                        Convert.ToDecimal(this.hiddenPrantikJerValue.Value);
                                    }
                                    num22 = Convert.ToDecimal(dataTable.Rows[j]["prarombik_jer_poriman_3"]);
                                    str10 = string.Concat(str10, "<tr>");
                                    obj = str10;
                                    str = new object[] { obj, "<td style='text-align: center;'>", j + 1, "</td>" };
                                    str10 = string.Concat(str);
                                    str10 = (str12 == "-" ? string.Concat(str10, "<td>", str15.ToString(), "</td>") : string.Concat(str10, "<td>", str12.ToString(), "</td>"));
                                    str10 = string.Concat(str10, "<td>", str1, "</td>");
                                    obj = str10;
                                    str = new object[] { obj, "<td style='text-align: right;'>", '-', "</td>" };
                                    str10 = string.Concat(str);
                                    if (num24 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num24, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", '-', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    if (num25 != new decimal(0))
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num25, num2), "</td>");
                                    }
                                    else
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", '-', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    num32 = num36 + num24;
                                    if (num32 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num32, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", '-', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    str10 = string.Concat(str10, "<td style='text-align: left;'>", empty10, "</td>");
                                    str10 = string.Concat(str10, "<td style='width: 20%;text-align: left;'>", empty11, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str11, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", empty12, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str12, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", empty13, "</td>");
                                    if (num28 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num28, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>-</td>");
                                    }
                                    str10 = (num29 != new decimal(0) ? string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num29, num2), "</td>") : string.Concat(str10, "<td style='text-align: right;'>-</td>"));
                                    str10 = (num30 != new decimal(0) ? string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num30, num2), "</td>") : string.Concat(str10, "<td style='text-align: right;'>-</td>"));
                                    str10 = (num31 != new decimal(0) ? string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num31, num2), "</td>") : string.Concat(str10, "<td style='text-align: right;'>-</td>"));
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str13, "</td>");
                                    str10 = string.Concat(str10, "<td style='width: 20%;text-align: right;'>", empty14, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str14, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", empty15, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str15, "</td>");
                                    if (dataTable.Rows[j]["type_p"].ToString() == "Cr")
                                    {
                                        num34 = num26 - num32;
                                        if (num34 < new decimal(0))
                                        {
                                            num34 = new decimal(0);
                                        }
                                        num35 = num27 - num33;
                                        num26 = num34;
                                        num27 = num35;
                                    }
                                    else if (dataTable.Rows[j]["type_p"].ToString() == "S")
                                    {
                                        num34 = num28 + num32;
                                    }
                                    else if (num32 == new decimal(0))
                                    {
                                        num34 = num28 + num26;
                                        num26 = num34;
                                        num35 = num29 + num27;
                                        num27 = num35;
                                    }
                                    else
                                    {
                                        num34 = num32 - num28;
                                        num35 = num27 - num33;
                                        num26 = num34;
                                        num27 = num35;
                                    }
                                    if (num34 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num34, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>-</td>");
                                    }
                                    str10 = string.Concat(str10, "<td>", empty16, "</td>");
                                    if (dataTable.Rows[j]["type_p"].ToString() != "S")
                                    {
                                        this.hiddenPrantikJerQty.Value = num34.ToString();
                                        this.hiddenPrantikJerValue.Value = num35.ToString("N2");
                                    }
                                    else
                                    {
                                        this.hiddenPrantikJerQty.Value = "";
                                        this.hiddenPrantikJerValue.Value = "";
                                    }
                                    str10 = string.Concat(str10, "</tr>");
                                }
                                else
                                {
                                    this.hiddenPrantikJerQty.Value = "";
                                    this.hiddenPrantikJerValue.Value = "";
                                    decimal num37 = new decimal(0);
                                    decimal num38 = new decimal(0);
                                    decimal num39 = new decimal(0);
                                    str10 = string.Concat(str10, "<tr>");
                                    obj = str10;
                                    str = new object[] { obj, "<td style='text-align: center;'>", j + 1, "</td>" };
                                    str10 = string.Concat(str);
                                    str10 = string.Concat(str10, "<td>", empty, "</td>");
                                    str10 = string.Concat(str10, "<td>", str1, "</td>");
                                    if (num22 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num22, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>-</td>");
                                    }
                                    if (num24 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num24, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>-</td>");
                                    }
                                    str10 = (num25 != new decimal(0) ? string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num25, num2), "</td>") : string.Concat(str10, "<td style='text-align: right;'>-</td>"));
                                    num37 = num22 + num24;
                                    if (num37 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num37, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>-</td>");
                                    }
                                    str10 = string.Concat(str10, "<td style='text-align: left;'>", empty10, "</td>");
                                    str10 = string.Concat(str10, "<td style='width: 20%;text-align: left;'>", empty11, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str11, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", empty12, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str12, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", empty13, "</td>");
                                    if (num28 != new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num28, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>-</td>");
                                    }
                                    str10 = (num29 != new decimal(0) ? string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num29, num2), "</td>") : string.Concat(str10, "<td style='text-align: right;'>-</td>"));
                                    str10 = (num30 != new decimal(0) ? string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num30, num2), "</td>") : string.Concat(str10, "<td style='text-align: right;'>-</td>"));
                                    str10 = (num31 != new decimal(0) ? string.Concat(str10, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num31, num2), "</td>") : string.Concat(str10, "<td style='text-align: right;'>-</td>"));
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str13, "</td>");
                                    str10 = string.Concat(str10, "<td style='width: 20%;text-align: right;'>", empty14, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str14, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", empty15, "</td>");
                                    str10 = string.Concat(str10, "<td style='text-align: right;'>", str15, "</td>");
                                    num38 = num37 - num28;
                                    if (num38 == new decimal(0))
                                    {
                                        str10 = string.Concat(str10, "<td style='text-align: right;'>-</td>");
                                        this.hiddenPrantikJerQty.Value = num38.ToString();
                                    }
                                    else if (num38 >= new decimal(0))
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num38, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                        this.hiddenPrantikJerQty.Value = num38.ToString();
                                    }
                                    else
                                    {
                                        obj = str10;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num28, '(', dataTable.Rows[j]["unit_code"].ToString(), ')', "</td>" };
                                        str10 = string.Concat(str);
                                        this.hiddenPrantikJerQty.Value = num28.ToString();
                                    }
                                    str10 = string.Concat(str10, "<td>", empty16, "</td>");
                                    str10 = string.Concat(str10, "</tr>");
                                    if (dataTable.Rows[j]["type_p"].ToString() != "S")
                                    {
                                        this.hiddenPrantikJerQty.Value = num38.ToString();
                                        this.hiddenPrantikJerValue.Value = num39.ToString("N2");
                                    }
                                    else
                                    {
                                        this.hiddenPrantikJerQty.Value = "";
                                        this.hiddenPrantikJerValue.Value = "";
                                    }
                                }
                                this.lblReportView.Text = str10;
                            }
                        }
                    }
                    else
                    {
                        dataTable = this.objPMBLL.PurchaseNSale621(dateTime, dateTime1, num, num1);
                        if (dataTable.Rows.Count > 0)
                        {
                            string str16 = "";
                            decimal num40 = new decimal(0);
                            decimal num41 = new decimal(0);
                            decimal num42 = new decimal(0);
                            decimal num43 = new decimal(0);
                            string empty17 = string.Empty;
                            string str17 = string.Empty;
                            string empty18 = string.Empty;
                            string str18 = string.Empty;
                            string empty19 = string.Empty;
                            decimal num44 = new decimal(0);
                            decimal num45 = new decimal(0);
                            string str19 = string.Empty;
                            decimal num46 = new decimal(0);
                            decimal num47 = new decimal(0);
                            decimal num48 = new decimal(0);
                            decimal num49 = new decimal(0);
                            string empty20 = string.Empty;
                            string str20 = string.Empty;
                            string empty21 = string.Empty;
                            string str21 = string.Empty;
                            string empty22 = string.Empty;
                            string str22 = string.Empty;
                            for (int k = 0; k < dataTable.Rows.Count; k++)
                            {
                                num40 = num3 + Convert.ToDecimal(dataTable.Rows[k]["prarombik_jer_poriman_3"]);
                                num41 = num4;
                                num42 = Convert.ToDecimal(dataTable.Rows[k]["poriman_5"]);
                                num43 = Convert.ToDecimal(dataTable.Rows[k]["mullo_6"]);
                                empty17 = dataTable.Rows[k]["name_9"].ToString();
                                str17 = dataTable.Rows[k]["address_10"].ToString();
                                empty18 = dataTable.Rows[k]["national_id_11"].ToString();
                                str18 = dataTable.Rows[k]["challan_no_12"].ToString();
                                empty19 = dataTable.Rows[k]["date_challan_13"].ToString();
                                str19 = dataTable.Rows[k]["biboron_14"].ToString();
                                num46 = Convert.ToDecimal(dataTable.Rows[k]["poriman_15"]);
                                num47 = Convert.ToDecimal(dataTable.Rows[k]["korjoggo_mullo_16"]);
                                num48 = Convert.ToDecimal(dataTable.Rows[k]["sompurok_sulko_17"]);
                                num49 = Convert.ToDecimal(dataTable.Rows[k]["mushok_18"]);
                                empty20 = dataTable.Rows[k]["name_19"].ToString();
                                str20 = dataTable.Rows[k]["address_20"].ToString();
                                empty21 = dataTable.Rows[k]["national_id_no_21"].ToString();
                                str21 = dataTable.Rows[k]["challan_no_22"].ToString();
                                empty22 = dataTable.Rows[k]["challan_date_23"].ToString();
                                str22 = dataTable.Rows[k]["montobbo_26"].ToString();
                                if (k != 0)
                                {
                                    decimal num50 = new decimal(0);
                                    decimal num51 = new decimal(0);
                                    decimal num52 = new decimal(0);
                                    decimal num53 = new decimal(0);
                                    decimal num54 = new decimal(0);
                                    if (this.hiddenPrantikJerQty.Value != "")
                                    {
                                        num54 = Convert.ToDecimal(this.hiddenPrantikJerQty.Value);
                                        Convert.ToDecimal(this.hiddenPrantikJerValue.Value);
                                    }
                                    num40 = Convert.ToDecimal(dataTable.Rows[k]["prarombik_jer_poriman_3"]);
                                    str16 = string.Concat(str16, "<tr>");
                                    obj = str16;
                                    str = new object[] { obj, "<td style='text-align: center;'>", k + 1, "</td>" };
                                    str16 = string.Concat(str);
                                    str16 = (empty19 == "-" ? string.Concat(str16, "<td>", empty22.ToString(), "</td>") : string.Concat(str16, "<td>", empty19.ToString(), "</td>"));
                                    str16 = string.Concat(str16, "<td>", str1, "</td>");
                                    if (num54 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num54, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    if (num42 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num42, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    str16 = (num43 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", num43.ToString("N2"), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    num50 = num54 + num42;
                                    if (num50 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num50, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    str16 = string.Concat(str16, "<td style='text-align: left;'>", empty17, "</td>");
                                    str16 = string.Concat(str16, "<td style='width: 20%;text-align: left;'>", str17, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty18, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", str18, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty19, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", str19, "</td>");
                                    if (num46 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num46, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    str16 = (num47 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num47, num2), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    str16 = (num48 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num48, num2), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    str16 = (num49 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num49, num2), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty20, "</td>");
                                    str16 = string.Concat(str16, "<td style='width: 20%;text-align: right;'>", str20, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty21, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", str21, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty22, "</td>");
                                    if (dataTable.Rows[k]["type_p"].ToString() == "Cr")
                                    {
                                        num52 = num44 - num50;
                                        if (num52 < new decimal(0))
                                        {
                                            num52 = new decimal(0);
                                        }
                                        num53 = num45 - num51;
                                        num44 = num52;
                                        num45 = num53;
                                    }
                                    else if (dataTable.Rows[k]["type_p"].ToString() == "S")
                                    {
                                        num52 = (num50 != new decimal(0) ? num50 - num46 : num46 + num50);
                                    }
                                    else if (num50 == new decimal(0))
                                    {
                                        num52 = num46 + num44;
                                        num44 = num52;
                                        num53 = num47 + num45;
                                        num45 = num53;
                                    }
                                    else
                                    {
                                        num52 = num50 - num46;
                                        num53 = num45 - num51;
                                        num44 = num52;
                                        num45 = num53;
                                    }
                                    if (num52 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num52, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    str16 = string.Concat(str16, "<td>", str22, "</td>");
                                    if (dataTable.Rows[k]["type_p"].ToString() != "S")
                                    {
                                        this.hiddenPrantikJerQty.Value = num52.ToString();
                                        this.hiddenPrantikJerValue.Value = num53.ToString("N2");
                                    }
                                    else
                                    {
                                        this.hiddenPrantikJerQty.Value = "0";
                                        this.hiddenPrantikJerValue.Value = "0";
                                    }
                                    str16 = string.Concat(str16, "</tr>");
                                }
                                else
                                {
                                    this.hiddenPrantikJerQty.Value = "";
                                    this.hiddenPrantikJerValue.Value = "";
                                    decimal num55 = new decimal(0);
                                    decimal num56 = new decimal(0);
                                    decimal num57 = new decimal(0);
                                    str16 = string.Concat(str16, "<tr>");
                                    obj = str16;
                                    str = new object[] { obj, "<td style='text-align: center;'>", k + 1, "</td>" };
                                    str16 = string.Concat(str);
                                    str16 = string.Concat(str16, "<td>", empty, "</td>");
                                    str16 = string.Concat(str16, "<td>", str1, "</td>");
                                    if (num40 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num40, " ", '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    if (num42 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num42, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    str16 = (num43 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num43, num2), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    num55 = num40 + num42;
                                    if (num55 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num55, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    str16 = string.Concat(str16, "<td style='text-align: left;'>", empty17, "</td>");
                                    str16 = string.Concat(str16, "<td style='width: 20%;text-align: left;'>", str17, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty18, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", str18, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty19, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", str19, "</td>");
                                    if (num46 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num46, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    str16 = (num47 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num47, num2), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    str16 = (num48 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num48, num2), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    str16 = (num49 != new decimal(0) ? string.Concat(str16, "<td style='text-align: right;'>", Utilities.RoundUpToWithString(num49, num2), "</td>") : string.Concat(str16, "<td style='text-align: right;'>-</td>"));
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty20, "</td>");
                                    str16 = string.Concat(str16, "<td style='width: 20%;text-align: right;'>", str20, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty21, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", str21, "</td>");
                                    str16 = string.Concat(str16, "<td style='text-align: right;'>", empty22, "</td>");
                                    num56 = num55 - num46;
                                    if (num56 != new decimal(0))
                                    {
                                        obj = str16;
                                        str = new object[] { obj, "<td style='text-align: right;'>", num56, '(', dataTable.Rows[k]["unit_code"].ToString(), ')', "</td>" };
                                        str16 = string.Concat(str);
                                    }
                                    else
                                    {
                                        str16 = string.Concat(str16, "<td style='text-align: right;'>-</td>");
                                    }
                                    this.hiddenPrantikJerQty.Value = num56.ToString();
                                    this.hiddenPrantikJerValue.Value = Utilities.RoundUpToWithString(num57, num2);
                                    str16 = string.Concat(str16, "<td>", str22, "</td>");
                                    str16 = string.Concat(str16, "</tr>");
                                }
                                this.lblReportView.Text = str16;
                            }
                        }
                    }

                }

            }
            catch (Exception exception)
            {
            }
        }
    }
}