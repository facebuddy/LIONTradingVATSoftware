using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class treasuryChallan_forms : Page, IRequiresSessionState
    {
        //protected TextBox dtpDateFrom;

        //protected CalendarExtender cc11;

        //protected TextBox dtpDateTo;

        //protected CalendarExtender CalendarExtender1;

        //protected DropDownList drptrChallan;

        //protected LinkButton btnPrint;

        //protected LinkButton btnClear;

        //protected TextBox precisionTxtBox;

        //protected RegularExpressionValidator RegularExpressionValidator1;

        //protected Label Label13;

        //protected Label Label14;

        //protected Label Label15;

        //protected HtmlGenericControl trch;

        //protected Label Label1;

        //protected HtmlGenericControl trdate;

        //protected Label Label16;

        //protected HtmlGenericControl trBranchDistrict;

        //protected Label Label3;

        //protected HtmlGenericControl trbranch;

        //protected Label Label2;

        //protected TextBox TextBox0;

        //protected TextBox TextBox1;

        //protected TextBox TextBox2;

        //protected TextBox TextBox3;

        //protected TextBox TextBox4;

        //protected TextBox TextBox5;

        //protected TextBox TextBox6;

        //protected TextBox TextBox7;

        //protected TextBox TextBox8;

        //protected TextBox TextBox9;

        //protected TextBox TextBox10;

        //protected TextBox TextBox11;

        //protected TextBox TextBox12;

        //protected Label lblTRForm;

        //protected Label lblTotalTK;

        //protected Label lblTotalPaisa;

        //protected Label lblAmountInWord;

        //protected Label lblDate2;

        //protected HtmlGenericControl printTRForm;

        //protected MsgBoxs msgBox;

        //protected Label lblReportHtml;

        //protected HtmlGenericControl printAnnexure;

        //protected Button btnPrintAnnexere;

        //protected Image Image1;

        //protected Panel pnInput;

        //protected HtmlGenericControl divImage;

        //protected Image ImageP;

       // protected UpdatePanel upContent;

        private NBR_VAT_GROUPOFCOM.BLL.trnsTreasuryChallanBLL objtrnsTreasuryChallanBLL = new NBR_VAT_GROUPOFCOM.BLL.trnsTreasuryChallanBLL();

        private NBR_VAT_GROUPOFCOM.BLL.trnsNoteMasterBLL objtrnsNoteMasterBLL = new NBR_VAT_GROUPOFCOM.BLL.trnsNoteMasterBLL();

        private NBR_VAT_GROUPOFCOM.BLL.trnsSaleMasterBLL objtrnsSaleMasterBLL = new NBR_VAT_GROUPOFCOM.BLL.trnsSaleMasterBLL();

        private NBR_VAT_GROUPOFCOM.BLL.trnsSaleMasterDAO objtrnsSaleMasterDAO = new NBR_VAT_GROUPOFCOM.BLL.trnsSaleMasterDAO();

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

        public treasuryChallan_forms()
        {
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            this.divImage.Visible = true;
            if (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text))
            {
                Convert.ToInt16(this.precisionTxtBox.Text);
            }
            int num = Convert.ToInt16(this.drptrChallan.SelectedValue);
            this.drptrChallan.SelectedItem.ToString();
            string text = this.dtpDateFrom.Text;
            string str = this.dtpDateTo.Text;
            DataTable dataTable = this.objtrnsTreasuryChallanBLL.showTRChallan(num, text, str);
            if (dataTable.Rows.Count <= 0)
            {
                this.lblTRForm.Text = "";
                this.lblReportHtml.Text = "";
                return;
            }
            string str1 = "";
            string str2 = "";
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            string str3 = "";
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string str4 = ((dataTable.Rows[i]["amount"].ToString() != null ? Convert.ToDecimal(dataTable.Rows[i]["amount"].ToString()) : new decimal(0))).ToString("0.00", CultureInfo.InvariantCulture);
                string[] strArrays = str4.Split(new char[] { '.' });
                int num3 = int.Parse(strArrays[0]);
                int num4 = int.Parse(strArrays[1]);
                str3 = dataTable.Rows[i]["deposit_description"].ToString();
                str1 = dataTable.Rows[i]["code_no"].ToString();
                str2 = string.Concat(str2, "<tr>");
                object obj = str2;
                object[] item = new object[] { obj, "<td>", dataTable.Rows[i]["bearer_name_address"], "</td>" };
                str2 = string.Concat(item);
                object obj1 = str2;
                object[] objArray = new object[] { obj1, "<td>", dataTable.Rows[i]["bearer_name_designation"], "</td>" };
                str2 = string.Concat(objArray);
                object obj2 = str2;
                object[] item1 = new object[] { obj2, "<td>", dataTable.Rows[i]["deposit_description"], "</td>" };
                str2 = string.Concat(item1);
                object obj3 = str2;
                object[] objArray1 = new object[] { obj3, "<td>", dataTable.Rows[i]["instrument_description"], "</td>" };
                str2 = string.Concat(objArray1);
                str2 = (Convert.ToDecimal(num3) != new decimal(0) ? string.Concat(str2, "<td style='text-align:right;'> ", num3.ToString("N0"), "</td>") : string.Concat(str2, "<td style='text-align:right;'>-</td>"));
                if (num4 != 0)
                {
                    object obj4 = str2;
                    object[] objArray2 = new object[] { obj4, "<td style='text-align:right;'>", num4, "</td>" };
                    str2 = string.Concat(objArray2);
                }
                else
                {
                    str2 = string.Concat(str2, "<td style='text-align:right;'>-</td>");
                }
                str2 = string.Concat(str2, "<td></td>");
                str2 = string.Concat(str2, "</tr>");
                num1 += num3;
                num2 += num4;
                this.Image1.ImageUrl = string.Concat("../../Uploads/", Path.GetFileName(dataTable.Rows[i]["tr_challan_image"].ToString()));
                this.ImageP.ImageUrl = string.Concat("../../Uploads/", Path.GetFileName(dataTable.Rows[i]["tr_challan_image"].ToString()));
                this.trch.InnerText = this.drptrChallan.SelectedItem.ToString();
                this.trdate.InnerText = dataTable.Rows[i]["date_challan"].ToString();
                this.lblDate2.Text = dataTable.Rows[i]["date_challan"].ToString();
                this.trbranch.InnerText = dataTable.Rows[i]["branch_name"].ToString();
            }
            this.lblTRForm.Text = str2;
            if (num1 != new decimal(0))
            {
                this.lblTotalTK.Text = num1.ToString("N0");
            }
            else
            {
                this.lblTotalTK.Text = "-";
            }
            if (num2 != new decimal(0))
            {
                this.lblTotalPaisa.Text = num2.ToString();
            }
            else
            {
                this.lblTotalPaisa.Text = "-";
            }
            this.lblAmountInWord.Text = InWord.ConvertToWordBangla(Convert.ToDouble(num1 + (num2 / new decimal(100))));
            ArrayList arrayLists = new ArrayList();
            for (short j = 0; j < str1.Length; j = (short)(j + 1))
            {
                char chr = str1[j];
                arrayLists.Add(chr.ToString());
            }
            this.TextBox0.Text = (!string.IsNullOrEmpty(arrayLists[0].ToString()) ? arrayLists[0].ToString() : string.Empty);
            this.TextBox1.Text = (!string.IsNullOrEmpty(arrayLists[1].ToString()) ? arrayLists[1].ToString() : string.Empty);
            this.TextBox2.Text = (!string.IsNullOrEmpty(arrayLists[2].ToString()) ? arrayLists[2].ToString() : string.Empty);
            this.TextBox3.Text = (!string.IsNullOrEmpty(arrayLists[3].ToString()) ? arrayLists[3].ToString() : string.Empty);
            this.TextBox4.Text = (!string.IsNullOrEmpty(arrayLists[4].ToString()) ? arrayLists[4].ToString() : string.Empty);
            this.TextBox5.Text = (!string.IsNullOrEmpty(arrayLists[5].ToString()) ? arrayLists[5].ToString() : string.Empty);
            this.TextBox6.Text = (!string.IsNullOrEmpty(arrayLists[6].ToString()) ? arrayLists[6].ToString() : string.Empty);
            this.TextBox7.Text = (!string.IsNullOrEmpty(arrayLists[7].ToString()) ? arrayLists[7].ToString() : string.Empty);
            this.TextBox8.Text = (!string.IsNullOrEmpty(arrayLists[8].ToString()) ? arrayLists[8].ToString() : string.Empty);
            this.TextBox9.Text = (!string.IsNullOrEmpty(arrayLists[9].ToString()) ? arrayLists[9].ToString() : string.Empty);
            this.TextBox10.Text = (!string.IsNullOrEmpty(arrayLists[10].ToString()) ? arrayLists[10].ToString() : string.Empty);
            this.TextBox11.Text = (!string.IsNullOrEmpty(arrayLists[11].ToString()) ? arrayLists[11].ToString() : string.Empty);
            this.TextBox12.Text = (!string.IsNullOrEmpty(arrayLists[12].ToString()) ? arrayLists[12].ToString() : string.Empty);
            this.printTRForm.Visible = true;
            this.btnPrint.Visible = true;
            this.btnPrintAnnexere.Visible = true;
            int num5 = 0;
            DataTable tRChallanIdForAnnexure = this.objtrnsTreasuryChallanBLL.getTRChallanIdForAnnexure(num);
            if (tRChallanIdForAnnexure.Rows.Count <= 0)
            {
                this.lblReportHtml.Text = "";
                return;
            }
            num5 = Convert.ToInt32(tRChallanIdForAnnexure.Rows[0]["challan_id"]);
            this.LoadAnnexureGrid(num5, str3);
        }

        private void LoadAnnexureGrid(int challanId, string description)
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            try
            {
                string str = "";
                decimal num1 = new decimal(0);
                DataTable tRChallanInfoForAnnexure = this.objtrnsTreasuryChallanBLL.getTRChallanInfoForAnnexure(challanId);
                if (tRChallanInfoForAnnexure != null && tRChallanInfoForAnnexure.Rows.Count > 0)
                {
                    for (int i = 0; i < tRChallanInfoForAnnexure.Rows.Count; i++)
                    {
                        str = string.Concat(str, "<tr>");
                        str = string.Concat(str, "<td>", tRChallanInfoForAnnexure.Rows[i]["party_name"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", tRChallanInfoForAnnexure.Rows[i]["challan_no"].ToString(), "</td>");
                        str = string.Concat(str, "<td>", this.drptrChallan.SelectedItem.ToString(), "</td>");
                        str = string.Concat(str, "<td>", description, "</td>");
                        if (Convert.ToDecimal(tRChallanInfoForAnnexure.Rows[i]["tr_amount"]) != new decimal(0))
                        {
                            str = string.Concat(str, "<td align='right' >", Utilities.RoundUpToWithString(Convert.ToDecimal(tRChallanInfoForAnnexure.Rows[i]["tr_amount"]), num), "</td>");
                            num1 += Convert.ToDecimal(tRChallanInfoForAnnexure.Rows[i]["tr_amount"]);
                        }
                        else
                        {
                            str = string.Concat(str, "<td style='text-align:right;'>-</td>");
                        }
                        str = string.Concat(str, "</tr>");
                    }
                    str = string.Concat(str, "<td colspan='4' class='style11' style='width: 10% ;border-style:solid;border-width:1px;text-align:right; padding-right: 15px; font-weight:bold'>Total</td>");
                    str = string.Concat(str, "<td class='style14' align='right' style='width: 10% ;border-style:solid;border-width:1px;font-weight:bold'>", Utilities.RoundUpToWithString(num1, num), "</td>");
                    this.lblReportHtml.Text = str;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void LoadTrChallan()
        {
            DataTable tRChallan = this.objtrnsTreasuryChallanBLL.getTRChallan();
            if (tRChallan != null && tRChallan.Rows.Count > 0)
            {
                this.drptrChallan.DataSource = tRChallan;
                this.drptrChallan.DataTextField = tRChallan.Columns["tr_challan_no"].ToString();
                this.drptrChallan.DataValueField = tRChallan.Columns["challan_id"].ToString();
                this.drptrChallan.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drptrChallan.Items.Insert(0, listItem);
            this.Session["TYPEOFBUSINESS_INFO"] = tRChallan;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.LoadTrChallan();
            }
        }
    }
}