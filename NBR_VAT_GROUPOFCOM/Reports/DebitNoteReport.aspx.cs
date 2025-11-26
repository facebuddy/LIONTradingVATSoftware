using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class DebitNoteReport : Page, IRequiresSessionState
    {


        private CraDebBLL objBLL = new CraDebBLL();

      

        public DebitNoteReport()
        {
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            try
            {
                CultureInfo invariantCulture = CultureInfo.InvariantCulture;
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", invariantCulture);
                string str = dateTime.ToString("dd/MM/yyyy");
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", invariantCulture);
                DateTime dateTime2 = dateTime1.AddDays(1);
                this.purchaseReturnByFTDate(str, dateTime2.ToString("dd/MM/yyyy"));
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlDebitChallanIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                int num = Convert.ToUInt16(this.ddlChallanId.SelectedValue);
                dataTable = this.objBLL.GetChallanByChallanId(num);
                this.ddlCustomer.DataSource = dataTable;
                this.ddlCustomer.DataTextField = dataTable.Columns["party_name"].ToString();
                this.ddlCustomer.DataValueField = dataTable.Columns["party_id"].ToString();
                this.ddlCustomer.DataBind();
            }
            catch (Exception exception)
            {
            }
        }

        protected void FromDateChangedGetChallan(object sender, EventArgs e)
        {
            this.InsertDebitChallanNo();
        }

        private void InsertDebitChallanNo()
        {
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            try
            {
                this.ddlChallanId.Items.Clear();
                if (this.ddlCustomer.SelectedValue != "-99")
                {
                    DataTable dataTable = new DataTable();
                    dataTable = this.objBLL.GetAllDebitChalanByDate(dateTime, dateTime1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.ddlChallanId.DataSource = dataTable;
                        this.ddlChallanId.DataTextField = dataTable.Columns["note_no"].ToString();
                        this.ddlChallanId.DataValueField = dataTable.Columns["note_id"].ToString();
                        this.ddlChallanId.DataBind();
                    }
                    this.ddlChallanId.Items.Insert(0, new ListItem("---Select---", "-99"));
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadParty()
        {
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            try
            {
                this.ddlChallanId.Items.Clear();
                if (this.ddlCustomer.SelectedValue != "-99")
                {
                    DataTable dataTable = new DataTable();
                    dataTable = this.objBLL.GetAllDebitChalanByDate(dateTime, dateTime1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.ddlChallanId.DataSource = dataTable;
                        this.ddlChallanId.DataTextField = dataTable.Columns["note_no"].ToString();
                        this.ddlChallanId.DataValueField = dataTable.Columns["note_id"].ToString();
                        this.ddlChallanId.DataBind();
                    }
                    this.ddlChallanId.Items.Insert(0, new ListItem("---Select---", "-99"));
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadReportData()
        {
            DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO();
            ArrayList item = (ArrayList)this.Session["DEBIT_NOTE_DETAIL"];
            DataTable dataTable = new DataTable();
            if (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text))
            {
                Convert.ToInt16(this.precisionTxtBox.Text);
            }
            string str = Convert.ToString(this.Session["NOTE_NO"]);
            if (item != null)
            {
                dataTable = this.objBLL.GetDebitNoteDataForReport(str, item);
            }
            if (dataTable.Rows.Count > 0)
            {
                this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                this.Challan_No.Text = dataTable.Rows[0]["note_no"].ToString();
                this.Challan_Date.Text = dataTable.Rows[0]["note_date"].ToString();
                this.Challan_Time.Text = dataTable.Rows[0]["issue_Time"].ToString();
                string str1 = "";
                this.provider_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.provider_BIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.receiver_name.Text = (dataTable.Rows[0]["party_name"].ToString() != "" ? dataTable.Rows[0]["party_name"].ToString() : "N/A");
                this.receiver_BIN.Text = (dataTable.Rows[0]["party_bin"].ToString() != "" ? dataTable.Rows[0]["party_bin"].ToString() : "N/A");
                this.receiver_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.provider_address.Text = (dataTable.Rows[0]["party_address"].ToString() != "" ? dataTable.Rows[0]["party_address"].ToString() : "N/A");
                this.txtTransport.Text = string.Concat(dataTable.Rows[0]["code_name"].ToString(), " ", dataTable.Rows[0]["vehicle_no"].ToString());
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    decimal num = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                    string str2 = Utilities.formatFraction(num);
                    str1 = string.Concat(str1, "<tr>");
                    object obj = str1;
                    object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                    str1 = string.Concat(objArray);
                    string str3 = str1;
                    string[] strArrays = new string[] { str3, "<td>", dataTable.Rows[i]["purchase_challan_no"].ToString(), " ", dataTable.Rows[i]["purchase_challan_date"].ToString(), "</td>" };
                    str1 = string.Concat(strArrays);
                    str1 = string.Concat(str1, "<td>", dataTable.Rows[i]["return_reason"].ToString(), "</td>");
                    if (Convert.ToDecimal(dataTable.Rows[i]["purchase_price"]) != new decimal(0))
                    {
                        decimal num1 = Convert.ToDecimal(dataTable.Rows[i]["purchase_price"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num1.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    str1 = (Convert.ToDecimal(dataTable.Rows[i]["purchase_quantity"]) != new decimal(0) ? string.Concat(str1, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["purchase_quantity"])), "</td>") : string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>"));
                    if (Convert.ToDecimal(dataTable.Rows[i]["purchase_vat"]) != new decimal(0))
                    {
                        decimal num2 = Convert.ToDecimal(dataTable.Rows[i]["purchase_vat"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num2.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["purchase_sd"]) != new decimal(0))
                    {
                        decimal num3 = Convert.ToDecimal(dataTable.Rows[i]["purchase_sd"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num3.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["note_price"]) != new decimal(0))
                    {
                        decimal num4 = Convert.ToDecimal(dataTable.Rows[i]["note_price"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num4.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    str1 = (Convert.ToDecimal(dataTable.Rows[i]["quantity"]) != new decimal(0) ? string.Concat(str1, "<td style='text-align:right;padding:3px'>", str2, "</td>") : string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>"));
                    if (Convert.ToDecimal(dataTable.Rows[i]["note_vat"]) != new decimal(0))
                    {
                        decimal num5 = Convert.ToDecimal(dataTable.Rows[i]["note_vat"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num5.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["note_sd"]) != new decimal(0))
                    {
                        decimal num6 = Convert.ToDecimal(dataTable.Rows[i]["note_sd"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num6.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    str1 = string.Concat(str1, "</tr>");
                    this.debitNoteReport.Text = str1;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.loadReportData();
                this.Session["NOTE_NO"] = string.Empty;
                this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.LoadParty();
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["employee_name"].ToString();
            }
        }

        private void purchaseReturnByFTDate(string fDate, string tDate)
        {
            string str;
            string[] strArrays;
            decimal num;
            DataTable dataTable = new DataTable();
            ArrayList arrayLists = new ArrayList();
            if (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text))
            {
                Convert.ToInt16(this.precisionTxtBox.Text);
            }
            Convert.ToString(this.Session["NOTE_NO"]);
            int num1 = Convert.ToInt32(this.ddlCustomer.SelectedValue);
            int num2 = Convert.ToInt32(this.ddlChallanId.SelectedValue);
            if (num2 != -99)
            {
                DataTable propByPartyIdandChallanId = this.objBLL.GetPropByPartyIdandChallanId(fDate, tDate, num1, num2);
                if (propByPartyIdandChallanId.Rows.Count > 0)
                {
                    int num3 = 0;
                    int num4 = 0;
                    for (int i = 0; i < propByPartyIdandChallanId.Rows.Count; i++)
                    {
                        DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO();
                        num3 = Convert.ToInt16(propByPartyIdandChallanId.Rows[i]["note_id"]);
                        num4 = Convert.ToInt16(propByPartyIdandChallanId.Rows[i]["row_no"]);
                        debitNoteDetailDAO.Property1 = Convert.ToInt16(propByPartyIdandChallanId.Rows[i]["property_id1"]);
                        debitNoteDetailDAO.Property2 = Convert.ToInt16(propByPartyIdandChallanId.Rows[i]["property_id2"]);
                        debitNoteDetailDAO.Property3 = Convert.ToInt16(propByPartyIdandChallanId.Rows[i]["property_id3"]);
                        debitNoteDetailDAO.Property4 = Convert.ToInt16(propByPartyIdandChallanId.Rows[i]["property_id4"]);
                        debitNoteDetailDAO.Property5 = Convert.ToInt16(propByPartyIdandChallanId.Rows[i]["property_id5"]);
                        arrayLists.Add(debitNoteDetailDAO);
                        ArrayList arrayLists1 = arrayLists;
                        DataTable purchaseReturnByFTDate = this.objBLL.GetPurchaseReturnByFTDate(fDate, tDate, num1, num3, arrayLists1, num4);
                        dataTable.Merge(purchaseReturnByFTDate);
                    }
                }
                if (dataTable.Rows.Count > 0)
                {
                    string str1 = "";
                    this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                    this.Challan_Date.Text = dataTable.Rows[0]["note_date"].ToString();
                    this.Challan_Time.Text = dataTable.Rows[0]["issue_Time"].ToString();
                    this.provider_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.provider_BIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.receiver_name.Text = (dataTable.Rows[0]["party_name"].ToString() != "" ? dataTable.Rows[0]["party_name"].ToString() : "N/A");
                    this.receiver_BIN.Text = (dataTable.Rows[0]["party_bin"].ToString() != "" ? dataTable.Rows[0]["party_bin"].ToString() : "N/A");
                    this.provider_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.receiver_address.Text = (dataTable.Rows[0]["party_address"].ToString() != "" ? dataTable.Rows[0]["party_address"].ToString() : "N/A");
                    this.txtTransport.Text = string.Concat(dataTable.Rows[0]["code_name"].ToString(), " ", dataTable.Rows[0]["vehicle_no"].ToString());
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    decimal num10 = new decimal(0);
                    string str2 = "";
                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        str2 = string.Concat(str2, dataTable.Rows[j]["note_no"].ToString(), ',');
                        decimal num11 = Convert.ToDecimal(dataTable.Rows[j]["quantity"]);
                        string str3 = Utilities.formatFraction(num11);
                        str1 = string.Concat(str1, "<tr>");
                        object obj = str1;
                        object[] objArray = new object[] { obj, "<td>", j + 1, "</td>" };
                        str1 = string.Concat(objArray);
                        string str4 = str1;
                        string[] strArrays1 = new string[] { str4, "<td>", dataTable.Rows[j]["purchase_challan_no"].ToString(), ", ", dataTable.Rows[j]["purchase_challan_date"].ToString(), "</td>" };
                        str1 = string.Concat(strArrays1);
                        str1 = string.Concat(str1, "<td>", dataTable.Rows[j]["return_reason"].ToString(), "</td>");
                        if (Convert.ToDecimal(dataTable.Rows[j]["purchase_price"]) != new decimal(0))
                        {
                            decimal num12 = Convert.ToDecimal(dataTable.Rows[j]["purchase_price"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num12.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["purchase_quantity"]) != new decimal(0))
                        {
                            string str5 = str1;
                            string[] strArrays2 = new string[] { str5, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[j]["purchase_quantity"])), " ", dataTable.Rows[j]["unit_name"].ToString(), "</td>" };
                            str1 = string.Concat(strArrays2);
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["purchase_vat"]) != new decimal(0))
                        {
                            decimal num13 = Convert.ToDecimal(dataTable.Rows[j]["purchase_vat"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num13.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["purchase_sd"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[j]["purchase_sd"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["note_price"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[j]["note_price"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["quantity"]) != new decimal(0))
                        {
                            str = str1;
                            strArrays = new string[] { str, "<td style='text-align:right;padding:3px'>", str3, " ", dataTable.Rows[j]["unit_name"].ToString(), "</td>" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["note_vat"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[j]["note_vat"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["note_sd"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[j]["note_sd"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        str1 = string.Concat(str1, "</tr>");
                        num5 += Convert.ToDecimal(dataTable.Rows[j]["note_price"].ToString());
                        num6 += Convert.ToDecimal(dataTable.Rows[j]["other_deduct"].ToString());
                        num7 += Convert.ToDecimal(dataTable.Rows[j]["total_w_VAT"].ToString());
                        num8 += Convert.ToDecimal(dataTable.Rows[j]["note_vat"].ToString());
                        num9 += Convert.ToDecimal(dataTable.Rows[j]["note_sd"].ToString());
                        num10 += Convert.ToDecimal(dataTable.Rows[j]["totalSD_VAT"].ToString());
                    }
                    this.Challan_No.Text = dataTable.Rows[0]["note_no"].ToString();
                    this.debitNoteReport.Text = str1;
                }
            }
            else
            {
                DataTable propByPartyId = this.objBLL.GetPropByPartyId(fDate, tDate, num1);
                if (propByPartyId.Rows.Count > 0)
                {
                    int num14 = 0;
                    int num15 = 0;
                    for (int k = 0; k < propByPartyId.Rows.Count; k++)
                    {
                        DebitNoteDetailDAO debitNoteDetailDAO1 = new DebitNoteDetailDAO();
                        num14 = Convert.ToInt16(propByPartyId.Rows[k]["note_id"]);
                        num15 = Convert.ToInt16(propByPartyId.Rows[k]["row_no"]);
                        debitNoteDetailDAO1.Property1 = Convert.ToInt16(propByPartyId.Rows[k]["property_id1"]);
                        debitNoteDetailDAO1.Property2 = Convert.ToInt16(propByPartyId.Rows[k]["property_id2"]);
                        debitNoteDetailDAO1.Property3 = Convert.ToInt16(propByPartyId.Rows[k]["property_id3"]);
                        debitNoteDetailDAO1.Property4 = Convert.ToInt16(propByPartyId.Rows[k]["property_id4"]);
                        debitNoteDetailDAO1.Property5 = Convert.ToInt16(propByPartyId.Rows[k]["property_id5"]);
                        arrayLists.Add(debitNoteDetailDAO1);
                        ArrayList arrayLists2 = arrayLists;
                        DataTable purchaseReturnByFTDate1 = this.objBLL.GetPurchaseReturnByFTDate(fDate, tDate, num1, num14, arrayLists2, num15);
                        dataTable.Merge(purchaseReturnByFTDate1);
                    }
                }
                if (dataTable.Rows.Count > 0)
                {
                    string str6 = "";
                    this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                    this.Challan_Date.Text = dataTable.Rows[0]["note_date"].ToString();
                    this.Challan_Time.Text = dataTable.Rows[0]["issue_Time"].ToString();
                    this.provider_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.provider_BIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.receiver_name.Text = (dataTable.Rows[0]["party_name"].ToString() != "" ? dataTable.Rows[0]["party_name"].ToString() : "N/A");
                    this.receiver_BIN.Text = (dataTable.Rows[0]["party_bin"].ToString() != "" ? dataTable.Rows[0]["party_bin"].ToString() : "N/A");
                    this.provider_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.receiver_address.Text = (dataTable.Rows[0]["party_address"].ToString() != "" ? dataTable.Rows[0]["party_address"].ToString() : "N/A");
                    this.txtTransport.Text = string.Concat(dataTable.Rows[0]["code_name"].ToString(), " ", dataTable.Rows[0]["vehicle_no"].ToString());
                    decimal num16 = new decimal(0);
                    decimal num17 = new decimal(0);
                    decimal num18 = new decimal(0);
                    decimal num19 = new decimal(0);
                    decimal num20 = new decimal(0);
                    decimal num21 = new decimal(0);
                    for (int l = 0; l < dataTable.Rows.Count; l++)
                    {
                        decimal num22 = Convert.ToDecimal(dataTable.Rows[l]["quantity"]);
                        string str7 = Utilities.formatFraction(num22);
                        str6 = string.Concat(str6, "<tr>");
                        object obj1 = str6;
                        object[] objArray1 = new object[] { obj1, "<td>", l + 1, "</td>" };
                        str6 = string.Concat(objArray1);
                        str = str6;
                        strArrays = new string[] { str, "<td>", dataTable.Rows[l]["purchase_challan_no"].ToString(), ", ", dataTable.Rows[l]["purchase_challan_date"].ToString(), "</td>" };
                        str6 = string.Concat(strArrays);
                        str6 = string.Concat(str6, "<td>", dataTable.Rows[l]["return_reason"].ToString(), "</td>");
                        if (Convert.ToDecimal(dataTable.Rows[l]["purchase_price"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[l]["purchase_price"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["purchase_quantity"]) != new decimal(0))
                        {
                            string str8 = str6;
                            string[] strArrays3 = new string[] { str8, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[l]["purchase_quantity"])), " ", dataTable.Rows[l]["unit_name"].ToString(), "</td>" };
                            str6 = string.Concat(strArrays3);
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["purchase_vat"]) != new decimal(0))
                        {
                            decimal num23 = Convert.ToDecimal(dataTable.Rows[l]["purchase_vat"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num23.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["purchase_sd"]) != new decimal(0))
                        {
                            decimal num24 = Convert.ToDecimal(dataTable.Rows[l]["purchase_sd"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num24.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["note_price"]) != new decimal(0))
                        {
                            decimal num25 = Convert.ToDecimal(dataTable.Rows[l]["note_price"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num25.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["quantity"]) != new decimal(0))
                        {
                            string str9 = str6;
                            string[] strArrays4 = new string[] { str9, "<td style='text-align:right;padding:3px'>", str7, " ", dataTable.Rows[l]["unit_name"].ToString(), "</td>" };
                            str6 = string.Concat(strArrays4);
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["note_vat"]) != new decimal(0))
                        {
                            decimal num26 = Convert.ToDecimal(dataTable.Rows[l]["note_vat"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num26.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["note_sd"]) != new decimal(0))
                        {
                            decimal num27 = Convert.ToDecimal(dataTable.Rows[l]["note_sd"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num27.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        str6 = string.Concat(str6, "</tr>");
                        num16 += Convert.ToDecimal(dataTable.Rows[l]["note_price"].ToString());
                        num17 += Convert.ToDecimal(dataTable.Rows[l]["other_deduct"].ToString());
                        num18 += Convert.ToDecimal(dataTable.Rows[l]["total_w_VAT"].ToString());
                        num19 += Convert.ToDecimal(dataTable.Rows[l]["note_vat"].ToString());
                        num20 += Convert.ToDecimal(dataTable.Rows[l]["note_sd"].ToString());
                        num21 += Convert.ToDecimal(dataTable.Rows[l]["totalSD_VAT"].ToString());
                    }
                    this.Challan_No.Text = dataTable.Rows[0]["note_no"].ToString();
                    this.debitNoteReport.Text = str6;
                    return;
                }
            }
        }

        protected void ToDateChangedGetChallan(object sender, EventArgs e)
        {
            this.InsertDebitChallanNo();
        }
    }

}