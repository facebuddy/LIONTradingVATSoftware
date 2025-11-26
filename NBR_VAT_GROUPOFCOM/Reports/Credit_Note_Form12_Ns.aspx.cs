using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.Api;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.ModelVW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class Credit_Note_Form12_Ns : Page, IRequiresSessionState
    {
        private NBR_VAT_GROUPOFCOM.BLL.CraDebBLL objBLL = new NBR_VAT_GROUPOFCOM.BLL.CraDebBLL();

        protected TextBox dtpDateFrom;

        protected CalendarExtender CalendarExtender2;

        protected TextBox dtpDateTo;

        protected CalendarExtender CalendarExtender3;

        protected DropDownList ddlCustomer;

        protected DropDownList ddlChallanId;

        protected TextBox precisionTxtBox;

        protected LinkButton LinkButton1;

        protected LinkButton LinkButton2;

        protected RegularExpressionValidator RegularExpressionValidator1;

        protected Label Challan_No;

        protected Label Challan_Date;

        protected Label Challan_Time;

        protected Label provider_name;

        protected Label provider_BIN;

        protected Label provider_address;

        protected Label receiver_name;

        protected Label receiver_BIN;

        protected Label receiver_address;

        protected Label txtTransport;

        protected Label debitNoteReport;

        protected Label lblDutyOfficerName;

        protected Label lblDutyOfficerDesignationName;

        protected Label Label3;

        protected Label Label4;

        protected Label lblUser;

        protected Label lblPrintDateTime;

        protected Label Label1;

        protected Panel pnlContents;

        protected Label lblMessage;

        protected UpdatePanel upContent;

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

        public Credit_Note_Form12_Ns()
        {
        }


        void LoadApiReport(List<MushakReturnVw> list )
        {
            string str;
            string pcsr = " PCS";
            string[] strArrays;
            int j = 0;
            decimal num;
            string str1 = "";
            string salesRt = "Sales Return";
            this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString(); 
            this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
            this.Challan_Date.Text =Convert.ToDateTime(list[0].return_date).ToString("dd/MM/yyyy");
            Label challanTime = this.Challan_Time;
            DateTime dateTime = DateTime.Now;
                //Convert.ToDateTime("issue_Time");
            challanTime.Text = dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            this.provider_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
            this.provider_BIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
            this.receiver_name.Text = list[0].kreata_name;
            this.receiver_BIN.Text = list[0].bin;
            this.provider_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
            this.receiver_address.Text = list[0].address_a;
            this.txtTransport.Text = "";
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            string str2 = "";
            foreach (var item in list)
            {
                str2 = item.return_invoice_no;
                decimal num11 = item.return_qty;
                string str3 = Utilities.formatFraction(num11);
                str1 = string.Concat(str1, "<tr>");
                object obj = str1;
                object[] objArray = new object[] { obj, "<td>", j + 1, "</td>" };
                str1 = string.Concat(objArray);
                string str4 = str1;
                string[] strArrays1 = new string[] { str4, "<td>", item.invoice_no, ", ", item.return_date, "</td>" };
                str1 = string.Concat(strArrays1);
                str1 = string.Concat(str1, "<td>", salesRt, "</td>");
                if (Convert.ToDecimal(item.sales_netamount) != new decimal(0))
                {
                    decimal num12 = Convert.ToDecimal(item.sales_netamount);
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num12.ToString("N2"), "</td>");
                }
                else
                {
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                }
                if (Convert.ToDecimal(item.sale_qty) != new decimal(0))
                {
                    string str5 = str1;
                    strArrays = new string[] { str5, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(item.sale_qty)), pcsr, "</td>" };
                    str1 = string.Concat(strArrays);
                }
                else
                {
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                }


                if (Convert.ToDecimal(item.sales_vatamount) != new decimal(0))
                {
                    num = Convert.ToDecimal(item.sales_vatamount);
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                }
                else
                {
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                }
                //if (Convert.ToDecimal(item.return_netamount) != new decimal(0))
                //{
                //    num = Convert.ToDecimal(item.return_netamount);
                //    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                //}
                //else
                //{
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
               // }
                if (Convert.ToDecimal(item.return_netamount) != new decimal(0))
                {
                    num = Convert.ToDecimal(item.return_netamount);
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                }
                else
                {
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                }
                if (Convert.ToDecimal(item.return_qty) != new decimal(0))
                {
                    str = str1;
                    strArrays = new string[] { str, "<td style='text-align:right;padding:3px'>", str3, pcsr, "</td>" };
                    str1 = string.Concat(strArrays);
                }
                else
                {
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                }
                if (Convert.ToDecimal(item.return_vatamount) != new decimal(0))
                {
                    num = Convert.ToDecimal(item.return_vatamount);
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                }
                else
                {
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                }
                //if (Convert.ToDecimal(item.return_qty) != new decimal(0))
                //{
                //    num = Convert.ToDecimal(item.return_qty);
                //    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                //}
                //else
                //{
                    str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
               // }
                str1 = string.Concat(str1, "</tr>");
                num5 += Convert.ToDecimal(item.return_netamount);
                num6 += Convert.ToDecimal(0);
                num7 += Convert.ToDecimal(item.return_qty);
                num8 += Convert.ToDecimal(item.return_vatamount);
                num9 += Convert.ToDecimal(item.sales_vatamount);
                num10 += Convert.ToDecimal(item.return_vatamount);
            }
            this.Challan_No.Text = list[0].return_invoice_no;
            this.debitNoteReport.Text = str1;
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



                Boolean flag = false;


                string invoice_no = ddlChallanId.SelectedItem.Text;

                if (invoice_no != "")
                {
                    var items = invoice_no.Split('-');
                    if (items[0] == "INVR")
                    {
                        flag = true;
                    }
                }


                if(flag==false)
                {

                    this.loadSaleReturnDatabyFTDate(str, dateTime2.ToString("dd/MM/yyyy"));
                    this.ddlCustomer.Items.Clear();
                    this.InsertCreditChallanNo();
                }
                else
                {

                    //   MushakReturnData
                    string start_date = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
                    string end_date = Convert.ToDateTime(dateTime1).ToString("yyyy-MM-dd");
                    var returnList = MushakAPI.MushakReturnData(invoice_no);
                    LoadApiReport(returnList);


                }


            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ChallanNoSelectedIndexChanged(object sender, EventArgs e)
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
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void FromDateChangedGetChallan(object sender, EventArgs e)
        {
            this.InsertCreditChallanNo();
        }

        private void InsertCreditChallanNo()
        {
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);


            //string start_date = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
            //string end_date = Convert.ToDateTime(dateTime1).ToString("yyyy-MM-dd");
            //var returnList = MushakAPI.MushakReturn(start_date, end_date);




            try
            {
                this.ddlChallanId.Items.Clear();
                if (this.ddlCustomer.SelectedValue != "-99")
                {
                    DataTable dataTable = new DataTable();
                    dataTable = objBLL.GetAllCreditChalanByDate(dateTime, dateTime1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.ddlChallanId.DataSource = dataTable;
                        this.ddlChallanId.DataTextField = dataTable.Columns["note_no"].ToString();
                        this.ddlChallanId.DataValueField = dataTable.Columns["note_id"].ToString();
                        this.ddlChallanId.DataBind();
                    }

                    //if(returnList!=null)
                    //{

                    //}

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
            this.InsertCreditChallanNo();
        }

        private void loadReportData()
        {
            DataTable dataTable = new DataTable();
            CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO();
            ArrayList item = (ArrayList)this.Session["CREDIT_NOTE_DETAIL"];
            string str = Convert.ToString(this.Session["NOTE_NO"]);
            this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
            this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
            if (item != null)
            {
                dataTable = this.objBLL.GetCreditNoteDataForReport(str, item);
            }
            if (dataTable.Rows.Count > 0)
            {
                string str1 = "";
                this.provider_name.Text = (dataTable.Rows[0]["party_name"].ToString() != "" ? dataTable.Rows[0]["party_name"].ToString() : "N/A");
                this.provider_BIN.Text = (dataTable.Rows[0]["party_bin"].ToString() != "" ? dataTable.Rows[0]["party_bin"].ToString() : "N/A");
                this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                this.Challan_No.Text = dataTable.Rows[0]["note_no"].ToString();
                this.Challan_Date.Text = dataTable.Rows[0]["note_date"].ToString();
                Label challanTime = this.Challan_Time;
                DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["issue_Time"].ToString());
                challanTime.Text = dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                this.receiver_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.receiver_BIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
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
                    string[] strArrays = new string[] { str3, "<td>", dataTable.Rows[i]["sale_challan_no"].ToString(), " ", dataTable.Rows[i]["sale_challan_date"].ToString(), "</td>" };
                    str1 = string.Concat(strArrays);
                    str1 = string.Concat(str1, "<td>", dataTable.Rows[i]["return_reason"].ToString(), "</td>");
                    if (Convert.ToDecimal(dataTable.Rows[i]["sale_price"]) != new decimal(0))
                    {
                        decimal num1 = Convert.ToDecimal(dataTable.Rows[i]["sale_price"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num1.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    str1 = (Convert.ToDecimal(dataTable.Rows[i]["sale_quantity"]) != new decimal(0) ? string.Concat(str1, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["sale_quantity"])), "</td>") : string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>"));
                    if (Convert.ToDecimal(dataTable.Rows[i]["sale_vat"]) != new decimal(0))
                    {
                        decimal num2 = Convert.ToDecimal(dataTable.Rows[i]["sale_vat"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num2.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["sale_sd"]) != new decimal(0))
                    {
                        decimal num3 = Convert.ToDecimal(dataTable.Rows[i]["sale_sd"]);
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

        private void loadSaleReturnDatabyFTDate(string fDate, string tDate)
        {
            string str;
            string[] strArrays;
            decimal num;
            ArrayList arrayLists = new ArrayList();
            DataTable dataTable = new DataTable();
            this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
            this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
            if (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text))
            {
                Convert.ToInt16(this.precisionTxtBox.Text);
            }
            Convert.ToString(this.Session["NOTE_NO"]);
            int num1 = Convert.ToInt32(this.ddlCustomer.SelectedValue);
            int num2 = Convert.ToInt32(this.ddlChallanId.SelectedValue);
            if (num2 != -99)
            {
                DataTable propforCreditByPartyIdandChallanId = this.objBLL.GetPropforCreditByPartyIdandChallanId(fDate, tDate, num1, num2);
                if (propforCreditByPartyIdandChallanId.Rows.Count > 0)
                {
                    int num3 = 0;
                    int num4 = 0;
                    for (int i = 0; i < propforCreditByPartyIdandChallanId.Rows.Count; i++)
                    {
                        CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO();
                        num3 = Convert.ToInt16(propforCreditByPartyIdandChallanId.Rows[i]["note_id"]);
                        num4 = Convert.ToInt16(propforCreditByPartyIdandChallanId.Rows[i]["row_no"]);
                        creditNoteDetailDAO.Property1 = Convert.ToInt16(propforCreditByPartyIdandChallanId.Rows[i]["property_id1"]);
                        creditNoteDetailDAO.Property2 = Convert.ToInt16(propforCreditByPartyIdandChallanId.Rows[i]["property_id2"]);
                        creditNoteDetailDAO.Property3 = Convert.ToInt16(propforCreditByPartyIdandChallanId.Rows[i]["property_id3"]);
                        creditNoteDetailDAO.Property4 = Convert.ToInt16(propforCreditByPartyIdandChallanId.Rows[i]["property_id4"]);
                        creditNoteDetailDAO.Property5 = Convert.ToInt16(propforCreditByPartyIdandChallanId.Rows[i]["property_id5"]);
                        arrayLists.Add(creditNoteDetailDAO);
                        ArrayList arrayLists1 = arrayLists;
                        DataTable saleReturnByFTDateReport = this.objBLL.GetSaleReturnByFTDateReport(fDate, tDate, num1, num3, arrayLists1, num4);
                       dataTable.Merge(saleReturnByFTDateReport);
                    }
                }
                if (dataTable.Rows.Count > 0)
                {
                    string str1 = "";
                    this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                    this.Challan_Date.Text = dataTable.Rows[0]["note_date"].ToString();
                    Label challanTime = this.Challan_Time;
                    DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["issue_Time"].ToString());
                    challanTime.Text = dateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
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
                        string[] strArrays1 = new string[] { str4, "<td>", dataTable.Rows[j]["sale_challan_no"].ToString(), ", ", dataTable.Rows[j]["sale_challan_date"].ToString(), "</td>" };
                        str1 = string.Concat(strArrays1);
                        str1 = string.Concat(str1, "<td>", dataTable.Rows[j]["return_reason"].ToString(), "</td>");
                        if (Convert.ToDecimal(dataTable.Rows[j]["sale_price"]) != new decimal(0))
                        {
                            decimal num12 = Convert.ToDecimal(dataTable.Rows[j]["sale_price"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num12.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["sale_quantity"]) != new decimal(0))
                        {
                            string str5 = str1;
                            strArrays = new string[] { str5, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[j]["sale_quantity"])), dataTable.Rows[j]["unit_name"].ToString(), "</td>" };
                            str1 = string.Concat(strArrays);
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["sale_vat"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[j]["sale_vat"]);
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[j]["sale_sd"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[j]["sale_sd"]);
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
                            strArrays = new string[] { str, "<td style='text-align:right;padding:3px'>", str3, dataTable.Rows[j]["unit_name"].ToString(), "</td>" };
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
                DataTable propforCreditByPartyId = this.objBLL.GetPropforCreditByPartyId(fDate, tDate, num1);
                if (propforCreditByPartyId.Rows.Count > 0)
                {
                    int num13 = 0;
                    int num14 = 0;
                    for (int k = 0; k < propforCreditByPartyId.Rows.Count; k++)
                    {
                        CreditNoteDetailDAO creditNoteDetailDAO1 = new CreditNoteDetailDAO();
                        num13 = Convert.ToInt16(propforCreditByPartyId.Rows[k]["note_id"]);
                        num14 = Convert.ToInt16(propforCreditByPartyId.Rows[k]["row_no"]);
                        creditNoteDetailDAO1.Property1 = Convert.ToInt16(propforCreditByPartyId.Rows[k]["property_id1"]);
                        creditNoteDetailDAO1.Property2 = Convert.ToInt16(propforCreditByPartyId.Rows[k]["property_id2"]);
                        creditNoteDetailDAO1.Property3 = Convert.ToInt16(propforCreditByPartyId.Rows[k]["property_id3"]);
                        creditNoteDetailDAO1.Property4 = Convert.ToInt16(propforCreditByPartyId.Rows[k]["property_id4"]);
                        creditNoteDetailDAO1.Property5 = Convert.ToInt16(propforCreditByPartyId.Rows[k]["property_id5"]);
                        arrayLists.Add(creditNoteDetailDAO1);
                        ArrayList arrayLists2 = arrayLists;
                        DataTable saleReturnByFTDateReport1 = this.objBLL.GetSaleReturnByFTDateReport(fDate, tDate, num1, num13, arrayLists2, num14);
                        dataTable.Merge(saleReturnByFTDateReport1);
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
                    decimal num15 = new decimal(0);
                    decimal num16 = new decimal(0);
                    decimal num17 = new decimal(0);
                    decimal num18 = new decimal(0);
                    decimal num19 = new decimal(0);
                    decimal num20 = new decimal(0);
                    string str7 = "";
                    for (int l = 0; l < dataTable.Rows.Count; l++)
                    {
                        str7 = string.Concat(str7, dataTable.Rows[l]["note_no"].ToString(), ',');
                        decimal num21 = Convert.ToDecimal(dataTable.Rows[l]["quantity"]);
                        string str8 = Utilities.formatFraction(num21);
                        str6 = string.Concat(str6, "<tr>");
                        object obj1 = str6;
                        object[] objArray1 = new object[] { obj1, "<td>", l + 1, "</td>" };
                        str6 = string.Concat(objArray1);
                        str = str6;
                        strArrays = new string[] { str, "<td>", dataTable.Rows[l]["sale_challan_no"].ToString(), ", ", dataTable.Rows[l]["sale_challan_date"].ToString(), "</td>" };
                        str6 = string.Concat(strArrays);
                        str6 = string.Concat(str6, "<td>", dataTable.Rows[l]["return_reason"].ToString(), "</td>");
                        if (Convert.ToDecimal(dataTable.Rows[l]["sale_price"]) != new decimal(0))
                        {
                            num = Convert.ToDecimal(dataTable.Rows[l]["sale_price"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["sale_quantity"]) != new decimal(0))
                        {
                            string str9 = str6;
                            string[] strArrays2 = new string[] { str9, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[l]["sale_quantity"])), dataTable.Rows[l]["unit_name"].ToString(), "</td>" };
                            str6 = string.Concat(strArrays2);
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["sale_vat"]) != new decimal(0))
                        {
                            decimal num22 = Convert.ToDecimal(dataTable.Rows[l]["sale_vat"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num22.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["sale_sd"]) != new decimal(0))
                        {
                            decimal num23 = Convert.ToDecimal(dataTable.Rows[l]["sale_sd"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num23.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["note_price"]) != new decimal(0))
                        {
                            decimal num24 = Convert.ToDecimal(dataTable.Rows[l]["note_price"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num24.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["quantity"]) != new decimal(0))
                        {
                            string str10 = str6;
                            string[] strArrays3 = new string[] { str10, "<td style='text-align:right;padding:3px'>", str8, dataTable.Rows[l]["unit_name"].ToString(), "</td>" };
                            str6 = string.Concat(strArrays3);
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["note_vat"]) != new decimal(0))
                        {
                            decimal num25 = Convert.ToDecimal(dataTable.Rows[l]["note_vat"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num25.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        if (Convert.ToDecimal(dataTable.Rows[l]["note_sd"]) != new decimal(0))
                        {
                            decimal num26 = Convert.ToDecimal(dataTable.Rows[l]["note_sd"]);
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>", num26.ToString("N2"), "</td>");
                        }
                        else
                        {
                            str6 = string.Concat(str6, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                        str6 = string.Concat(str6, "</tr>");
                        num15 += Convert.ToDecimal(dataTable.Rows[l]["note_price"].ToString());
                        num16 += Convert.ToDecimal(dataTable.Rows[l]["other_deduct"].ToString());
                        num17 += Convert.ToDecimal(dataTable.Rows[l]["total_w_VAT"].ToString());
                        num18 += Convert.ToDecimal(dataTable.Rows[l]["note_vat"].ToString());
                        num19 += Convert.ToDecimal(dataTable.Rows[l]["note_sd"].ToString());
                        num20 += Convert.ToDecimal(dataTable.Rows[l]["totalSD_VAT"].ToString());
                    }
                    this.Challan_No.Text = dataTable.Rows[0]["note_no"].ToString();
                    this.debitNoteReport.Text = str6;
                    return;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          NBR_VAT_GROUPOFCOM.BLL.MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.Session["NOTE_NO"] = string.Empty;
                this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.LoadParty();
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["employee_name"].ToString();
            }
        }

        protected void ToDateChangedGetChallan(object sender, EventArgs e)
        {
            this.InsertCreditChallanNo();
        }
    }
}