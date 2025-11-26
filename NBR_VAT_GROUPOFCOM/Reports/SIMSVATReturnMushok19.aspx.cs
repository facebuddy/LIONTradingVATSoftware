using AjaxControlToolkit;
using ASP;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using NBR_VAT_GROUPOFCOM.BLL;


namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class SIMSVATReturnMushok19 : Page, IRequiresSessionState
    {



        private NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL objVatReturn = new NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL();

        private CSVXMLBLL dbBLL = new CSVXMLBLL();

        private string ErrorList = "";

        protected TextBox dtpDateFrom;

        protected CalendarExtender cc11;

        protected TextBox dtpDateTo;

        protected CalendarExtender CalendarExtender1;

        protected TextBox precisionTxtBox;

        protected LinkButton btnShow;

        protected LinkButton btnPrint;

        protected LinkButton LinkButton1;

        protected Button btnSave;

        protected Label lblStatus;

        protected Label lblError;

        protected RegularExpressionValidator RegularExpressionValidator1;

        protected Label TaxOrganizationBIN;

        protected Label TaxOrganizationName;

        protected Label TaxOrganizationAddress;

        protected Label OrganizationBusinessNature;

        protected Label NatureOfBusiness;

        protected Label lblTaxPeriod;

        protected CheckBox ChkMainDakhil;

        protected CheckBox ChkLate;

        protected CheckBox ChkRevisedDakhil;

        protected CheckBox ChkExtraDakhil;

        protected CheckBox chkHa;

        protected CheckBox chkNa;

        protected Label lblReturnSubmitDate;

        protected Label zerorateDirectExportAmountN2P3;

        protected LinkButton SubForm_3Row1K;

        protected Label zerorateDeemedExportAmountN1P3;

        protected LinkButton SubForm_3Row2K;

        protected Label exemptedSupplyAmountN3P3;

        protected LinkButton SubForm_3Row3K;

        protected Label typicalSupplyAmountN4P3;

        protected Label typicalSupplySDN4P3;

        protected Label typicalSupplyVATN4P3;

        protected LinkButton SubForm_3Row4K;

        protected Label note5AmountP3;

        protected Label note5SDP3;

        protected Label note5VATP3;

        protected LinkButton SubForm_3Row5K;

        protected Label nonTypicalSupplyAmountN6P3;

        protected Label nonTypicalSupplySDN6P3;

        protected Label nonTypicalSupplyVATN6P3;

        protected LinkButton SubForm_3Row6K;

        protected Label lblAdorshoHarBatitoMullo;

        protected Label lblAdorshHarBatitoSD;

        protected Label lblAdorshoHarBatitoMushok;

        protected LinkButton SubForm_3Row7K;

        protected Label Label2;

        protected Label Label4;

        protected Label Label3;

        protected LinkButton SubForm_3Row8KH;

        protected Label lblTotalPriceP3;

        protected Label lblTotalVatN7P3;

        protected Label lblNineMushokKhaTotal;

        protected HtmlTable tbl3;

        protected Label zerorateLocalPurchaseAmountN10P4;

        protected LinkButton SubForm_4ROW10K;

        protected Label zerorateForeignPurchaseAmountN11P4;

        protected LinkButton SubForm_4ROW11k;

        protected Label exemptedLocalPurchaseAmountN8P4;

        protected LinkButton SubForm_4ROW12k;

        protected Label exemptedForeignPurchaseAmountN9P4;

        protected LinkButton SubForm_4ROW13k;

        protected Label standardLocalPurchaseAmountN12P4;

        protected Label standardLocalPurchaseVatN12P4;

        protected LinkButton SubForm_4Row14k;

        protected Label standardForeignPurchaseAmountN13P4;

        protected Label standardForeignPurchaseVatN13P4;

        protected LinkButton SubForm_4Row15k;

        protected Label lblAdorshoHarBatitoMulloLcl;

        protected Label lblAdorshoHarBatitoMushokLcl;

        protected LinkButton SubForm_4Row16k;

        protected Label lblAdorshoHarBatitoMulloImp;

        protected Label lblAdorshoHarBatitoMushokImp;

        protected LinkButton SubForm_4Row17k;

        protected Label partialRebatePurchaseAmountN14P4;

        protected Label partialRebatePurchaseVatN14P4;

        protected LinkButton SubForm_4Row18k;

        protected Label nonRebatePurchaseAmountN15P4;

        protected Label nonRebatePurchaseVatN15P4;

        protected LinkButton SubForm_k19;

        protected Label Label9;

        protected Label Label10;

        protected LinkButton SubForm_4Row20k;

        protected Label Label11;

        protected Label Label12;

        protected LinkButton SubForm_4Row21k;

        protected Label Label13;

        protected Label Label14;

        protected LinkButton SubForm_4Row22k;

        protected Label lblTotalPriceP4;

        protected Label lblTotalVatN16P4;

        protected Label receiveVDSAmountN17P5;

        protected LinkButton SubForm_5Row24GHA;

        protected Label nonBankingPaymentVatN18P5;

        protected Label changePurchaseAllVatN19P5;

        protected LinkButton link26;

        protected HtmlTableCell sub26;

        protected Label otherAdjusmentVatN20P5;

        protected LinkButton link27;

        protected HtmlTableCell sub27;

        protected Label lblTotalVatN21P5;

        protected Label paidVDSAmountN22P6;

        protected LinkButton SunForm_6Row29UMO;

        protected Label changeSaleAllVatN23P6;

        protected LinkButton SubForm_6Row30CH;

        protected Label lblforCreditNoteIssue;

        protected LinkButton link31;

        protected HtmlTableCell sub31;

        protected Label otherAdjusmentAmountN25P6;

        protected LinkButton link33;

        protected HtmlTableCell sub32;

        protected Label lblTotalVatN26P6;

        protected HtmlButton details;

        protected Label TotalVatSDAmountN27P7;

        protected Label AdvanceVatAmountN28P7;

        protected Label PrevAdvanceAmountN29P7;

        protected Label ExciseDutyN30P7;

        protected Label SurchargeN31P7;

        protected Label Label16;

        protected Label Label17;

        protected Label Label18;

        protected Label Label19;

        protected Label Label20;

        protected Label Label5;

        protected Label Label21;

        protected Label Label22;

        protected Label Label23;

        protected Label Label24;

        protected Label Label25;

        protected Label lbl50;

        protected Label Label6;

        protected Label Label26;

        protected Label Label27;

        protected Label txtnote54;

        protected Label txtnote55;

        protected Label txtnote56;

        protected Label txtnote57;

        protected Label oc1;

        protected Label TotalVatN32P8;

        protected LinkButton SubForm_9Row58CHA;

        protected Label oc2;

        protected Label SDdepositN33P8;

        protected LinkButton SubForm_9Row59CHA;

        protected Label oc6;

        protected Label ExciseDutyN33P8;

        protected LinkButton SubForm_9Row60CHA;

        protected Label oc7;

        protected Label DevelopmentN33P8;

        protected LinkButton SubForm_9Row61CHA;

        protected Label oc8;

        protected Label ICTN33P8;

        protected LinkButton SubForm_9Row62CHA;

        protected Label oc9;

        protected Label HealthN33P8;

        protected LinkButton SubForm_9Row63CHA;

        protected Label oc10;

        protected Label EnvironmentN33P8;

        protected LinkButton SubForm_9Row64CHA;

        protected TextBox txtRefundMoneyN35P9;

        protected TextBox txtRefundSD;

        protected CheckBox chk11Ha;

        protected CheckBox chk11Na;

        protected Label Label7;

        protected Label Label15;

        protected Label Label8;

        protected Label Label28;

        protected Label TaxpayerNameP10;

        protected Label TaxpayerDesignationP10;

        protected Label TaxpayerMobileNoP10;

        protected Label txtNID;

        protected Label TaxpayerEmailP10;

        protected Label Label30;

        protected TextBox chkClosing;

        protected Label lblUser;

        protected Label lblPrintDateTime;

        protected Label Label1;

        protected Button btnOK;

        protected Button btnNoCancel;

        protected Label lblMessage;

        protected Panel pnYesNoModal;

        protected HtmlGenericControl reportMain;

        protected Button btnHideButton;

        protected ModalPopupExtender mpeYesNoModal;

        protected Label node50Value;

        protected Label node9Value;

        protected Label totalOf50and9Value;

        protected Label localPurchase23Value;

        protected Label import23Value;

        protected Label subTotal23Value;

        protected Label total23Value;

        protected Label node28Value;

        protected Label node28Total;

        protected Label node34Value;

        protected Label node34Total;

        //protected MsgBoxs msgBox;

        protected UpdatePanel upDetail35Modal;

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


        protected void btnShow_OnClick(object sender, EventArgs e)
        {
          //  this.ShowReport();
        }

        protected void btnExportXML_OnClick(object sender, EventArgs e)
        {
           // this.LoadReport();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        protected void SubForm_3Row1K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_1.aspx");
        }

        protected void SubForm_3Row2K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_2.aspx");
        }

        protected void SubForm_3Row3K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_3.aspx");
        }

        protected void SubForm_3Row4K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k.aspx");
        }

        protected void SubForm_3Row5K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_5.aspx");
        }

        protected void SubForm_3Row6K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_Gha_Note_6.aspx");
        }

        protected void SubForm_3Row7K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_7.aspx");
        }

        protected void SubForm_3Row8KH_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_Kha_Note_8.aspx");
        }

        protected void SubForm_4Row10k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_10.aspx");
        }

        protected void SubForm_4ROW11K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_11.aspx");
        }

        protected void SubForm_4Row12k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note12.aspx");
        }

        protected void SubForm_4Row13k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note13.aspx");
        }

        protected void SubForm_4Row14k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note_14.aspx");
        }

        protected void SubForm_4Row15k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_15.aspx");
        }

        protected void SubForm_4Row16k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note_16.aspx");
        }

        protected void SubForm_4Row17k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_17.aspx");
        }

        protected void SubForm_4Row18k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_Gha_Note_18.aspx");
        }

        protected void SubForm_4Row19k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k19.aspx");
        }

        protected void SubForm_4Row20k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k20.aspx");
        }

        protected void SubForm_4Row21k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_K_Note_21.aspx");
        }

        protected void SubForm_4Row22k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_K_Note_22.aspx");
        }

        protected void SubForm_5_K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_5.aspx");
        }

        protected void SubForm_5Row24GHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_GHA_Note_24.aspx");
        }

        protected void SubForm_6Row30CH_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_CH.aspx");
        }

        protected void SubForm_9Row58CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_CHA.aspx");
        }

        protected void SubForm_9Row59CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note53.aspx");
        }

        protected void SubForm_9Row60CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note57.aspx");
        }

        protected void SubForm_9Row61CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note58.aspx");
        }

        protected void SubForm_9Row62CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note59.aspx");
        }

        protected void SubForm_9Row63CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note60.aspx");
        }

        protected void SubForm_9Row64CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note61.aspx");
        }

        protected void Subform26_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Subform_Note_26.aspx");
        }

        protected void Subform31_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Subform_Note_31.aspx");
        }

        protected void SunForm_6Row29UMO_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_UMO_Note_29.aspx");
        }

        protected void Details27_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Details_Note_27.aspx");
        }

        protected void Details33_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Details_Note_33.aspx");
        }

        private void DownloadFile(string filePath)
        {
            DateTime today = DateTime.Today;
            string str = string.Concat("VATReturnMushok19s", today.ToString("ddMMyy"));
            base.Response.ContentType = "application/xml";
            base.Response.AddHeader("Content-Disposition", string.Concat("attachment;filename=", str, ".xml"));
            base.Response.WriteFile(filePath);
            base.Response.End();
        }

        protected void btnCancelToSaveInvoice(object sender, EventArgs e)
        {
            //this.mpeYesNoModal.Hide();
        }


        protected void btnOkToReload(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<NBR_VAT_GROUPOFCOM.BLL.MonthClosingBalance> item = (List<NBR_VAT_GROUPOFCOM.BLL.MonthClosingBalance>)this.Session["report_values"];
            int num = 0;
            num = Convert.ToInt16(this.Session["transecID"]);
            if (this.objVatReturn.updateMontClosingBalance(item, dateTime, dateTime1, num))
            {
                // this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                return;
            }
            // this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
        }


        private void ValidateXML(string filename)
        {
            XmlReader xmlReader = null;
            try
            {
                try
                {
                    XmlReaderSettings xmlReaderSetting = new XmlReaderSettings()
                    {
                        ValidationType = ValidationType.Schema
                    };
                    XmlReaderSettings validationFlags = xmlReaderSetting;
                    validationFlags.ValidationFlags = validationFlags.ValidationFlags | XmlSchemaValidationFlags.ProcessSchemaLocation;
                    XmlReaderSettings validationFlags1 = xmlReaderSetting;
                    validationFlags1.ValidationFlags = validationFlags1.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
                    xmlReaderSetting.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);
                    xmlReader = XmlReader.Create(filename, xmlReaderSetting);
                    while (xmlReader.Read())
                    {
                    }
                    this.lblStatus.Text = "Validation Passed";
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    this.lblStatus.Text = string.Concat("Error Validating", exception.Message);
                }
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType xmlSeverityType = XmlSeverityType.Warning;
            if (!Enum.TryParse<XmlSeverityType>("Error", out xmlSeverityType) || xmlSeverityType != XmlSeverityType.Error)
            {
                Console.WriteLine(string.Concat("\r\n\tValidation Error:", e.Message));
                this.lblStatus.Text = string.Concat("Validation Failed", e.Message);
                throw new Exception(string.Concat("Validation Failed", e.Message));
            }
            throw new Exception(e.Message);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            object[] objArray;
            this.TaxOrganizationName.Text = "KALLOL TRADING LIMITED";
            this.TaxOrganizationAddress.Text = "269, Tejgaon I/A, Dhaka-1208; Tejgaon PS; Dhaka - 1208; Banglades";
            string str = "004741963-0203";
            string str1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                object obj = str1;
                object[] objArrays = new object[] { obj, "<input type='text' value = '", str[i], "' runat='server' style='width:25px; text-align:center;border:1px solid #000'>" };
                str1 = string.Concat(objArrays);
                this.TaxOrganizationBIN.Text = str1;
            }
            this.lblStatus.Text = "";
            OrganizationBusinessNature.Text = "Private Limited";
            NatureOfBusiness.Text = "Retail/Wholesale Trading";
            this.TaxpayerNameP10.Text = "GHULAM MOSTAFA";
            //string designation = this.objVatReturn.GetDesignation(Convert.ToInt32(this.Session["DESIGNATION_ID"]));
            TaxpayerDesignationP10.Text = "Managing Director";
            TaxpayerMobileNoP10.Text = "01787675121";
            //(this.Session["MOBILE_NO"] != null ? this.Session["MOBILE_NO"].ToString() : "NA");
            TaxpayerEmailP10.Text = "vat2@kallolgroup.com";

            txtNID.Text = "4193412089";
            this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");


            string str1s = DateTime.Now.ToString("dd/MM/yyyy");
            string str2 = "";
           // dateTime.ToString("dd/MM/yyyy");
            for (int i = 0; i < str1s.Length; i++)
            {
                object obj = str2;
                objArray = new object[] { obj, "<input type='text' value = '", str1s[i], "' runat='server' style = 'width:25px; text-align:center;border:1px solid #000'>" };
                str2 = string.Concat(objArray);
                this.lblReturnSubmitDate.Text = str2;
            }




        }
    }
}