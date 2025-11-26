using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class Periodic_Purchase_Report_BIs : Page, IRequiresSessionState
    {
        private PeriodicReportBLL pbll = new PeriodicReportBLL();

        private OrgRegistrationInfoDAO orgRegInfo = new OrgRegistrationInfoDAO();

        private trnsPurchaseMasterBLL objtrnsSaleMasterBLL = new trnsPurchaseMasterBLL();

        private AddItemBLL dbLL = new AddItemBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

        private AddItemBLL dbBLL = new AddItemBLL();

        private ExcelUtility excelUtility = new ExcelUtility();

        private bool tableTwoDisable;

        private string challanNoFor2ndRow = "";

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

        public Periodic_Purchase_Report_BIs()
        {
        }

        private void clearAll()
        {
            this.dtpFromDate.Text = null;
        }

        public void CsharpFunction(object sender, EventArgs e)
        {
            if (this.tableTwoDisable)
            {
                string str = "";
                this.header1.Visible = true;
                this.loadAdditionalPropertyData(Convert.ToInt32(str));
            }
        }

        private void FillDropdown()
        {
            try
            {
                DataTable allItemForPurchase = this.pbll.GetAllItemForPurchase();
                this.objtrnsSaleMasterBLL.GetPurchaseSkuNo();
                if (allItemForPurchase != null && allItemForPurchase.Rows.Count > 0)
                {
                    this.ddlSKU.DataSource = allItemForPurchase;
                    this.ddlSKU.DataTextField = allItemForPurchase.Columns["item_name"].ToString();
                    this.ddlSKU.DataValueField = allItemForPurchase.Columns["item_id"].ToString();
                    this.ddlSKU.DataBind();
                }
                this.ddlSKU.Items.Insert(0, new ListItem("---Select Item---", "-1"));
                DataTable allSupplierForPurchase = this.pbll.GetAllSupplierForPurchase();
                if (allSupplierForPurchase != null && allSupplierForPurchase.Rows.Count > 0)
                {
                    this.ddlSupplier.DataSource = allSupplierForPurchase;
                    this.ddlSupplier.DataTextField = allSupplierForPurchase.Columns["party_name"].ToString();
                    this.ddlSupplier.DataValueField = allSupplierForPurchase.Columns["party_id"].ToString();
                    this.ddlSupplier.DataBind();
                }
                this.ddlSupplier.Items.Insert(0, new ListItem("---Select Supplier---", "-1"));
                DateTime minValue = DateTime.MinValue;
                DateTime dateTime = DateTime.MinValue;
                minValue = DateTime.ParseExact(this.dtpFromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTime = DateTime.ParseExact(this.dtpToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DataTable allPurchasePeriodicChallanNo = this.pbll.GetAllPurchasePeriodicChallanNo(minValue, dateTime);
                if (allPurchasePeriodicChallanNo != null && allPurchasePeriodicChallanNo.Rows.Count > 0)
                {
                    this.DtchallanDrpdn.DataSource = allPurchasePeriodicChallanNo;
                    this.DtchallanDrpdn.DataTextField = allPurchasePeriodicChallanNo.Columns["challan_no"].ToString();
                    this.DtchallanDrpdn.DataValueField = allPurchasePeriodicChallanNo.Columns["challan_id"].ToString();
                    this.DtchallanDrpdn.DataBind();
                }
                this.DtchallanDrpdn.Items.Insert(0, new ListItem("---Select Challan Number---", "-1"));
                this.purchase.Items.Insert(0, new ListItem("---Select Transaction Type---", "-1"));
                this.purchase.Items.Insert(1, new ListItem("Local", "L"));
                this.purchase.Items.Insert(2, new ListItem("Import", "I"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private string GetDataHtml(string displayHtml, int j, DataTable dt, string dateChallan, string partyname, string challan_No, string sQuantity, string item, string unit_name, decimal unitprice, decimal vat, decimal sd, decimal vds, decimal at, decimal ait, decimal cd, decimal rd, decimal assesvalue, decimal value, decimal ConValue, int challanId, string TaxType1, string methodNames, decimal itemSKU)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            int count = dt.Rows.Count;
            displayHtml = string.Concat(displayHtml, "<tr style = 'background-color: White'>");
            if (j == 0)
            {
                object obj = displayHtml;
                object[] objArray = new object[] { obj, "<td rowspan = '", count, "' class='style10' align='left' style='width: 10% ;border-style:solid;border-width:1px'> </td>" };
                displayHtml = string.Concat(objArray);
                object obj1 = displayHtml;
                object[] objArray1 = new object[] { obj1, "<td rowspan = '", count, "' class='style10' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", dateChallan, "</td>" };
                displayHtml = string.Concat(objArray1);
                object obj2 = displayHtml;
                object[] objArray2 = new object[] { obj2, "<td rowspan = '", count, "' class='style11' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", partyname, "</td>" };
                displayHtml = string.Concat(objArray2);
                object obj3 = displayHtml;
                object[] objArray3 = new object[] { obj3, "<td rowspan = '", count, "' class='style14' align='left' style='width: 10% ;border-style:solid;border-width:1px;'><a  href='#PopupContent_", challanId, "'  data-target='#PopupContent_", challanId, " ' onclick='return check(", challanId, ")'>", challan_No, "</a></td>" };
                displayHtml = string.Concat(objArray3);
            }
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", item, "</td>");
            object obj4 = displayHtml;
            object[] objArray4 = new object[] { obj4, "<td class='style13' align='left' style='width: 10% ;border-style:solid;border-width:1px'>", itemSKU, "</td>" };
            displayHtml = string.Concat(objArray4);
            displayHtml = string.Concat(displayHtml, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", sQuantity, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style15' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", unit_name, "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(unitprice, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(vat, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(sd, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(vds, num), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(ait, num), "</td>");
            if (this.purchase.SelectedItem.Value == "I" || this.purchase.SelectedItem.Value == "-1")
            {
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(assesvalue, num), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(cd, num), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(rd, num), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(at, num), "</td>");
            }
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(value, num), "</td>");
            if (j == 0)
            {
                object obj5 = displayHtml;
                object[] withString = new object[] { obj5, "<td rowspan = '", count, "' class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", Utilities.RoundUpToWithString(ConValue, num), "</td>" };
                displayHtml = string.Concat(withString);
            }
            displayHtml = string.Concat(displayHtml, "<td class='style11' align='right' style='width: 10% ;border-style:solid;border-width:1px'>", methodNames.Trim(), "</td>");
            return displayHtml;
        }

        private string GetTotalHtml(string displayHtml, decimal vatT, decimal sdT, decimal vdsT, decimal aitT, decimal cdT, decimal rdT, decimal atT, decimal Total1, decimal Total2, int precision)
        {
            displayHtml = string.Concat(displayHtml, "<tr style = 'background-color: White'>");
            displayHtml = string.Concat(displayHtml, "<td colspan='9' class='style11' style='width: 10% ;border-style:solid;border-width:1px;text-align:right; padding-right: 15px; font-weight:bold'>Total</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(vatT, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(sdT, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(vdsT, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(aitT, precision), " </td>");
            if (this.purchase.SelectedItem.Value == "I" || this.purchase.SelectedItem.Value == "-1")
            {
                displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'></td>");
                displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(cdT, precision), " </td>");
                displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(rdT, precision), "</td>");
                displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(atT, precision), "</td>");
            }
            displayHtml = string.Concat(displayHtml, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(Total1, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "<td class='style13' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(Total2, precision), "</td>");
            displayHtml = string.Concat(displayHtml, "</tr>");
            return displayHtml;
        }

        private string loadAdditionalPropertyData(int challanId)
        {
            string str = "";
            DataTable appCodeDetailName = null;
            AddItemBLL addItemBLL = new AddItemBLL();
            GridView gridView = new GridView();
            short num = 0;
            short num1 = 0;
            short num2 = 0;
            short num3 = 0;
            short num4 = 0;
            string empty = string.Empty;
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            DataTable dataTable = this.objPDBll.geAdditionalPropertybySaleInformation(challanId);
            if (dataTable.Rows.Count <= 0)
            {
                str = string.Concat("<div id='PopupContent_", challanId, "'  aria-hidden='true' style='display: none;'> Not Found</div>");
            }
            else
            {
                num = Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
                num1 = Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
                ArrayList arrayLists = new ArrayList();
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField = new BoundField();
                    str1 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str1);
                    boundField.HeaderText = str1;
                    boundField.DataField = "Property1_Text";
                    gridView.Columns.Add(boundField);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num1);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField1 = new BoundField();
                    str2 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str2);
                    boundField1.HeaderText = str2;
                    boundField1.DataField = "Property2_Text";
                    gridView.Columns.Add(boundField1);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num2);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField2 = new BoundField();
                    str3 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str3);
                    boundField2.HeaderText = str3;
                    boundField2.DataField = "Property3_Text";
                    gridView.Columns.Add(boundField2);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num3);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField3 = new BoundField();
                    str4 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str4);
                    boundField3.HeaderText = str4;
                    boundField3.DataField = "Property4_Text";
                    gridView.Columns.Add(boundField3);
                }
                appCodeDetailName = addItemBLL.GetAppCodeDetailName(num4);
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField4 = new BoundField();
                    str5 = appCodeDetailName.Rows[0]["code_name"].ToString();
                    this.tableNameList.Add(str5);
                    boundField4.HeaderText = str5;
                    boundField4.DataField = "Property5_Text";
                    gridView.Columns.Add(boundField4);
                }
                if (appCodeDetailName.Rows.Count > 0)
                {
                    BoundField boundField5 = new BoundField();
                    str6 = "Item Id";
                    this.tableNameList.Add(str6);
                    boundField5.HeaderText = str6;
                    boundField5.DataField = "Property6_Text";
                    gridView.Columns.Add(boundField5);
                }
                string[] strArrays = new string[] { "<thead style='text-align: center'><tr style='text-align: center'> </tr><tr><th> Item Name </th><th  style='text-align: center;'>", str1, "</th><th>", str2, "</th><th> Color</th><th>Status</th><th> Challan No</th><th> Challan Date</th><th> Purchaser Name</th><th> Quantity</th><th> Unit</th><th> Unit Price</th><th> Vat</th><th> SD</th><th> VDS</th><th> Value</th> <th>Value Consolidated</th><th>Payment Method</th></tr></thead>" };
                empty3 = string.Concat(strArrays);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                    if (dataTable.Rows[i]["property_id1_value"].ToString() != "")
                    {
                        contructualProductionIssueDAO.Property1_Text = dataTable.Rows[i]["property_id1_value"].ToString();
                    }
                    if (dataTable.Rows[i]["property_id2_value"].ToString() != "")
                    {
                        contructualProductionIssueDAO.Property2_Text = dataTable.Rows[i]["property_id2_value"].ToString();
                    }
                    string empty4 = string.Empty;
                    empty = dataTable.Rows[i]["payment"].ToString();
                    if (!(empty != "''") || !(empty != "Not applicable"))
                    {
                        empty4 = empty;
                    }
                    else
                    {
                        char[] chrArray = new char[] { ',' };
                        int[] array = empty.Split(chrArray).Select<string, int>(new Func<string, int>(int.Parse)).ToArray<int>();
                        for (int j = 0; j < (int)array.Length; j++)
                        {
                            DataTable paymentMethodName = this.pbll.getPaymentMethodName(array[j]);
                            if (paymentMethodName.Rows.Count > 0)
                            {
                                empty4 = (j != (int)array.Length - 1 ? string.Concat(empty4, paymentMethodName.Rows[0]["payment_method_name"], ",") : string.Concat(empty4, paymentMethodName.Rows[0]["payment_method_name"]));
                            }
                        }
                    }
                    string str7 = empty2;
                    string[] strArrays1 = new string[] { str7, "<tbody><tr><td>", dataTable.Rows[i]["item_name"].ToString(), "</td><td  style='text-align: center;padding:5px'>", contructualProductionIssueDAO.Property1_Text, "</td><td  style='text-align:right;padding:5px'>", contructualProductionIssueDAO.Property2_Text, "</td><td  style='text-align:right;padding:5px'>- </td><td  style='text-align:right;padding:5px'>", dataTable.Rows[i]["status"].ToString(), "</td><td  style='text-align:right;padding:5px'>", dataTable.Rows[i]["challan_no"].ToString(), "</td><td  style='text-align:right;padding:5px'>", dataTable.Rows[i]["date_challan"].ToString(), "</td> <td  style='text-align:right;'>", dataTable.Rows[i]["party_name"].ToString(), "</td><td>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["quantity"])), "</td><td>", dataTable.Rows[i]["unit_code"].ToString(), "</td><td>", Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["actual_price"]), 2), "</td><td>", Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["vat"]), 2), "</td><td>", Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["sd"]), 2), "</td><td>", Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["vds"]), 2), "</td><td>", Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["pricevalue"]), 2), "</td><td>", Utilities.RoundUpToWithString(Convert.ToDecimal(dataTable.Rows[i]["valuecons"]), 2), "</td><td>", empty4, "</td></tr></tbody>" };
                    empty2 = string.Concat(strArrays1);
                    empty1 = string.Concat("<table border='1' style='width:100%; border-collapse:collapse; border:1px solid #000000'>", empty3, empty2, "</table>");
                    arrayLists.Add(contructualProductionIssueDAO);
                }
                gridView.DataSource = arrayLists;
                gridView.DataBind();
                object[] objArray = new object[] { "<div id='PopupContent_", challanId, "'  aria-hidden='true' style='display: none;'>", empty1, "</div>" };
                str = string.Concat(objArray);
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.dtpFromDate.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.dtpToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.FillDropdown();
            }
        }

        protected void SelectedPurchaseType_Changed(object sender, EventArgs e)
        {
        }

        protected void showBTN_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                this.showReport("html", null, null, null);
            }
        }

        private void showReport(string reportFormat, ISheet sheet, HSSFCellStyle headerStyle, HSSFWorkbook workbook)
        {
            DateTime minValue = DateTime.MinValue;
            DateTime dateTime = DateTime.MinValue;
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            string empty = string.Empty;
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            string str = "-1";
            string value = string.Empty;
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            int num12 = 2;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            decimal num13 = new decimal(0);
            decimal num14 = new decimal(0);
            decimal num15 = new decimal(0);
            decimal num16 = new decimal(0);
            decimal num17 = new decimal(0);
            decimal num18 = new decimal(0);
            decimal num19 = new decimal(0);
            decimal num20 = new decimal(0);
            decimal num21 = new decimal(0);
            string empty3 = string.Empty;
            string str3 = "";
            decimal num22 = new decimal(0);
            decimal num23 = new decimal(0);
            decimal num24 = new decimal(0);
            string str4 = "ALL";
            string str5 = "";
            if (this.dtpFromDate.Text.Trim().Length > 0)
            {
                minValue = DateTime.ParseExact(this.dtpFromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (this.dtpToDate.Text.Trim().Length > 0)
            {
                dateTime = DateTime.ParseExact(this.dtpToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            int num25 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            num = (Convert.ToInt32(this.ddlSupplier.SelectedItem.Value) > 0 ? Convert.ToInt32(this.ddlSupplier.SelectedItem.Value) : 0);
            num1 = (Convert.ToInt32(this.ddlSKU.SelectedItem.Value) > 0 ? Convert.ToInt32(this.ddlSKU.SelectedItem.Value) : 0);
            num2 = (Convert.ToInt32(this.DtchallanDrpdn.SelectedItem.Value) > 0 ? Convert.ToInt32(this.DtchallanDrpdn.SelectedItem.Value) : 0);
            empty = this.purchase.SelectedItem.Value;
            this.lblHeaderShow.Text = string.Empty;
            this.lblleisureShow.Text = string.Empty;
            string dataHtml = "";
            value = this.purchase.SelectedItem.Value;
            DataTable purchasePeriodicChallanNoanddetails = this.pbll.GetPurchasePeriodicChallanNoanddetails(minValue, dateTime, num, num2, num1, empty);
            decimal num26 = Convert.ToDecimal(this.ddlSKU.SelectedValue);
            if (purchasePeriodicChallanNoanddetails != null && purchasePeriodicChallanNoanddetails.Rows.Count > 0)
            {
                string empty4 = string.Empty;
                int num27 = 0;
                decimal num28 = new decimal(0);
                if (value == "L")
                {
                    this.header2.Visible = false;
                    this.header1.Visible = true;
                    if (this.purchase.SelectedValue != "-1")
                    {
                        this.purchaseTypelbl.Visible = true;
                        this.purchaseTypelbl.Text = string.Concat("Purchase Type: ", this.purchase.SelectedItem.ToString(), "     ");
                    }
                    if (this.ddlSupplier.SelectedValue != "-1")
                    {
                        this.vendorlbl.Visible = true;
                        this.vendorlbl.Text = string.Concat("Vendor/Supplier: ", this.ddlSupplier.SelectedItem.ToString(), "     ");
                    }
                    this.fromdatelbl.Visible = true;
                    this.todatelbl.Visible = true;
                    this.fromdatelbl.Text = string.Concat("From Date:", this.dtpFromDate.Text, "     ");
                    this.todatelbl.Text = string.Concat("To Date:", this.dtpToDate.Text, "     ");
                }
                else if (value == "I" || value == "-1")
                {
                    this.header1.Visible = false;
                    this.header2.Visible = true;
                    if (this.purchase.SelectedValue != "-1")
                    {
                        this.purchaseTypelbl.Visible = true;
                        this.purchaseTypelbl.Text = string.Concat("Purchase Type: ", this.purchase.SelectedItem.ToString(), "     ");
                    }
                    if (this.ddlSupplier.SelectedValue != "-1")
                    {
                        this.vendorlbl.Visible = true;
                        this.vendorlbl.Text = string.Concat("Vendor/Supplier: ", this.ddlSupplier.SelectedItem.ToString(), "     ");
                    }
                    this.fromdatelbl.Visible = true;
                    this.todatelbl.Visible = true;
                    this.fromdatelbl.Text = string.Concat("From Date:", this.dtpFromDate.Text, "     ");
                    this.todatelbl.Text = string.Concat("To Date:", this.dtpToDate.Text, "     ");
                }
                if (str != "-1")
                {
                    if (str == "purchase_vat")
                    {
                        str4 = "VAT";
                    }
                    else if (str == "purchase_sd")
                    {
                        str4 = "SD";
                    }
                }
                for (int i = 0; i < purchasePeriodicChallanNoanddetails.Rows.Count; i++)
                {
                    long num29 = Convert.ToInt64(purchasePeriodicChallanNoanddetails.Rows[i]["challan_id"].ToString());
                    DataTable purchasePeriodicReportData = this.pbll.GetPurchasePeriodicReportData(num29, num1, str);
                    int count = purchasePeriodicReportData.Rows.Count;
                    for (int j = 0; j < purchasePeriodicReportData.Rows.Count; j++)
                    {
                        if (num26 == Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["item_id"]))
                        {
                            string empty5 = string.Empty;
                            num27 = Convert.ToInt32(purchasePeriodicReportData.Rows[j]["challan_id"]);
                            empty4 = this.loadAdditionalPropertyData(num27);
                            HtmlGenericControl popupContainer = this.PopupContainer;
                            popupContainer.InnerHtml = string.Concat(popupContainer.InnerHtml, empty4);
                            empty1 = purchasePeriodicReportData.Rows[j]["vouchar_date"].ToString();
                            str1 = purchasePeriodicReportData.Rows[j]["supplier_name"].ToString();
                            empty2 = purchasePeriodicReportData.Rows[j]["challan_no"].ToString();
                            str2 = purchasePeriodicReportData.Rows[j]["item_name"].ToString();
                            num28 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["item_sku"]);
                            num13 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["quantity"].ToString());
                            str3 = Utilities.formatFraction(num13);
                            num14 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["unit_price"].ToString());
                            num15 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["value"].ToString());
                            str5 = purchasePeriodicReportData.Rows[j]["unit_name"].ToString();
                            num17 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vat"].ToString());
                            num18 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["sd"].ToString());
                            num19 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vds"].ToString());
                            num20 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["ait"].ToString());
                            empty3 = purchasePeriodicReportData.Rows[j]["payment"].ToString();
                            if (!(empty3 != "''") || !(empty3 != "Not applicable"))
                            {
                                empty5 = empty3;
                            }
                            else
                            {
                                char[] chrArray = new char[] { ',' };
                                int[] array = empty3.Split(chrArray).Select<string, int>(new Func<string, int>(int.Parse)).ToArray<int>();
                                for (int k = 0; k < (int)array.Length; k++)
                                {
                                    DataTable paymentMethodName = this.pbll.getPaymentMethodName(array[k]);
                                    if (paymentMethodName.Rows.Count > 0)
                                    {
                                        empty5 = (k != (int)array.Length - 1 ? string.Concat(empty5, paymentMethodName.Rows[0]["payment_method_name"], ",") : string.Concat(empty5, paymentMethodName.Rows[0]["payment_method_name"]));
                                    }
                                }
                            }
                            num16 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["total"].ToString());
                            if (reportFormat == "html")
                            {
                                dataHtml = this.GetDataHtml(dataHtml, j, purchasePeriodicReportData, empty1, str1, empty2, str3, str2, str5, num14, num17, num18, num19, num24, num20, num22, num23, num21, num15, num16, num27, str4, empty5, num28);
                            }
                            if (reportFormat == "excel")
                            {
                                num12 = num12 + j + 1;
                            }
                            if (value == "I" || value == "-1")
                            {
                                num3 += num15;
                                num4 += num16;
                                num5 += num17;
                                num6 += num18;
                                num7 += num19;
                                num8 += num20;
                                num9 += num22;
                                num10 += num23;
                                num11 += num24;
                            }
                            else
                            {
                                num3 += num15;
                                if (j == 0)
                                {
                                    num4 += num15;
                                }
                                num5 += num17;
                                num6 += num18;
                                num7 += num19;
                                num8 += num20;
                            }
                        }
                        else if (num26 == new decimal(-1))
                        {
                            string empty6 = string.Empty;
                            num27 = Convert.ToInt32(purchasePeriodicReportData.Rows[j]["challan_id"]);
                            empty4 = this.loadAdditionalPropertyData(num27);
                            HtmlGenericControl htmlGenericControl = this.PopupContainer;
                            htmlGenericControl.InnerHtml = string.Concat(htmlGenericControl.InnerHtml, empty4);
                            empty1 = purchasePeriodicReportData.Rows[j]["vouchar_date"].ToString();
                            str1 = purchasePeriodicReportData.Rows[j]["supplier_name"].ToString();
                            empty2 = purchasePeriodicReportData.Rows[j]["challan_no"].ToString();
                            str2 = purchasePeriodicReportData.Rows[j]["item_name"].ToString();
                            num28 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["item_sku"]);
                            num13 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["quantity"].ToString());
                            str3 = Utilities.formatFraction(num13);
                            num14 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["unit_price"].ToString());
                            num15 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["value"].ToString());
                            str5 = purchasePeriodicReportData.Rows[j]["unit_name"].ToString();
                            num17 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vat"].ToString());
                            num18 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["sd"].ToString());
                            num19 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["vds"].ToString());
                            num20 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["ait"].ToString());
                            empty3 = purchasePeriodicReportData.Rows[j]["payment"].ToString();
                            if (!(empty3 != "''") || !(empty3 != "Not applicable"))
                            {
                                empty6 = empty3;
                            }
                            else
                            {
                                char[] chrArray1 = new char[] { ',' };
                                int[] numArray = empty3.Split(chrArray1).Select<string, int>(new Func<string, int>(int.Parse)).ToArray<int>();
                                for (int l = 0; l < (int)numArray.Length; l++)
                                {
                                    DataTable dataTable = this.pbll.getPaymentMethodName(numArray[l]);
                                    if (dataTable.Rows.Count > 0)
                                    {
                                        empty6 = (l != (int)numArray.Length - 1 ? string.Concat(empty6, dataTable.Rows[0]["payment_method_name"], ",") : string.Concat(empty6, dataTable.Rows[0]["payment_method_name"]));
                                    }
                                }
                            }
                            num16 = Convert.ToDecimal(purchasePeriodicReportData.Rows[j]["total"].ToString());
                            if (reportFormat == "html")
                            {
                                dataHtml = this.GetDataHtml(dataHtml, j, purchasePeriodicReportData, empty1, str1, empty2, str3, str2, str5, num14, num17, num18, num19, num24, num20, num22, num23, num21, num15, num16, num27, str4, empty6, num28);
                            }
                            if (reportFormat == "excel")
                            {
                                num12 = num12 + j + 1;
                            }
                            if (value == "I" || value == "-1")
                            {
                                num3 += num15;
                                num4 += num16;
                                num5 += num17;
                                num6 += num18;
                                num7 += num19;
                                num8 += num20;
                                num9 += num22;
                                num10 += num23;
                                num11 += num24;
                            }
                            else
                            {
                                num3 += num15;
                                if (j == 0)
                                {
                                    num4 += num15;
                                }
                                num5 += num17;
                                num6 += num18;
                                num7 += num19;
                                num8 += num20;
                            }
                        }
                    }
                }
                if (reportFormat == "html")
                {
                    dataHtml = this.GetTotalHtml(dataHtml, num5, num6, num7, num8, num9, num10, num11, num3, num4, num25);
                }
                if (reportFormat == "excel")
                {
                    num12++;
                }
                this.lblleisureShow.Text = dataHtml;
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