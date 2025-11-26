using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class CreditNote_ExtensionDeduct : Page, IRequiresSessionState
    {
        private bool hasKeys;

        private int challanId;

    

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

        public CreditNote_ExtensionDeduct()
        {
        }

        private void adjusmentReason()
        {
            DataTable creditOtherAdjusment = (new CraDebBLL()).getCreditOtherAdjusment();
            if (creditOtherAdjusment.Rows.Count > 0)
            {
                this.drpOAReason.DataSource = creditOtherAdjusment;
                this.drpOAReason.DataTextField = creditOtherAdjusment.Columns["code_name"].ToString();
                this.drpOAReason.DataValueField = creditOtherAdjusment.Columns["code_id_d"].ToString();
                this.drpOAReason.DataBind();
                ListItem listItem = new ListItem("--সমন্বয়ের কারণ নির্বাচন করুন--", "-99");
                this.drpOAReason.Items.Insert(0, listItem);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
           // base.Response.Redirect("~/UI/Admin/DebitNote_Extension.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          NBR_VAT_GROUPOFCOM.BLL.CraDebBLL craDebBLL = new NBR_VAT_GROUPOFCOM.BLL.CraDebBLL();
            NBR_VAT_GROUPOFCOM.BLL.DebitNoteMasterDAO debitNoteMasterDAO = new NBR_VAT_GROUPOFCOM.BLL.DebitNoteMasterDAO();
            NBR_VAT_GROUPOFCOM.BLL.DebitNoteDetailDAO debitNoteDetailDAO = new NBR_VAT_GROUPOFCOM.BLL.DebitNoteDetailDAO();
            bool flag = false;
            try
            {
                if (this.validation())
                {
                    debitNoteMasterDAO = this.loadMasterData(debitNoteMasterDAO);
                    debitNoteDetailDAO = this.loadDetailData(debitNoteDetailDAO);
                    this.hasKeys = base.Request.QueryString.HasKeys();
                    if (this.hasKeys)
                    {
                        string[] strArrays = base.Request.QueryString["Amount"].ToString().Split(new char[] { '?' });
                        this.challanId = Convert.ToInt16(strArrays[1]);
                    }
                    flag = (this.challanId == 0 ? craDebBLL.saveOtherAdjusment(debitNoteMasterDAO, debitNoteDetailDAO) : craDebBLL.saveOtherAdjusmentforRebateAdjustment(debitNoteMasterDAO, debitNoteDetailDAO, this.challanId));
                    if (!flag)
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        if (this.FileUploadControl.HasFile)
                        {
                            HttpFileCollection files = base.Request.Files;
                            for (int i = 0; i < files.Count; i++)
                            {
                                HttpPostedFile item = files[i];
                                string str = Convert.ToString(this.Session["ORGANIZATION_ID"]);
                                string str1 = Convert.ToString(this.Session["ORGBRANCHID"]);
                                string[] creditNotNumber = new string[] { "Credit_", str, "_", str1, "_", debitNoteMasterDAO.CreditNotNumber, "_", null, null, null, null };
                                creditNotNumber[7] = DateTime.Today.ToString("dd-MM-yyyy");
                                creditNotNumber[8] = "_";
                                creditNotNumber[9] = (i + 1).ToString();
                                creditNotNumber[10] = ".jpeg";
                                string str2 = string.Concat(creditNotNumber);
                                item.SaveAs(base.Server.MapPath(string.Concat("~/files/Credit_Note_Extension//", str2)));
                                this.StatusLabel.ForeColor = Color.ForestGreen;
                            }
                        }
                        this.msgBox.AddMessage("Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.clear();
                        this.fillImagegrid();
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "CreditNote_Extension", "btnSave_Click");
            }
        }

        private void clear()
        {
            this.drpParty.SelectedValue = "-99";
            this.txtReceiverAddress.Text = "";
            this.txtReceiverBIN.Text = "";
            this.txtReceiveDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            this.txtProviderDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            this.txtSubject.Text = "";
            this.txtCaseNo.Text = "";
            this.txtDescription.Text = "";
            this.txtAmount.Text = "";
            this.txtVatAmount.Text = "";
            this.txtNoOfDays.Text = "";
            this.txtInterestPct.Text = "";
            this.txtInterestAmount.Text = "";
            this.txtParticulars.Text = "";
            this.txtRent.Text = "";
            this.txtVATpct.Text = "";
            this.txtVATamnt.Text = "";
            this.txtPartic.Text = "";
            this.txtAITPct.Text = "";
            this.txtAIT.Text = "";
            this.drpOAReason.SelectedValue = "-99";
        }

        protected void drpOAReason_IndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpOAReason.SelectedValue != "-99")
                {
                    string str = this.drpOAReason.SelectedItem.Text.Trim();
                    if (str == "অপরিশোধিত মসুকের জন্য সুদ্")
                    {
                        this.divCal.Visible = true;
                        this.divhomeRent.Visible = false;
                        this.lblCalculation.InnerText = string.Concat("Calculation for- ", str);
                    }
                    else if (str == "অপরিশোধিত সম্পূরূক শুল্ক এর জন্য সুদ")
                    {
                        this.divhomeRent.Visible = false;
                        this.divCal.Visible = true;
                        this.lblCalculation.InnerText = string.Concat("Calculation for- ", str);
                    }
                    else if (str != "বাড়ি ভাড়া")
                    {
                        this.divCal.Visible = false;
                        this.divhomeRent.Visible = false;
                    }
                    else
                    {
                        this.txtVATpct.Text = "15";
                        this.divhomeRent.Visible = true;
                        this.divCal.Visible = false;
                        this.lblHomeRent.InnerText = string.Concat("Calculation for- ", str);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpParty_IndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpParty.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpParty.SelectedValue);
                    DataTable item = (DataTable)this.Session["PARTY_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("party_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.txtReceiverAddress.Text = dataRow["party_address"].ToString();
                        if (dataRow["party_bin"].ToString() == "")
                        {
                            this.txtReceiverBIN.Text = "Data Not Found";
                        }
                        else
                        {
                            this.txtReceiverBIN.Text = dataRow["party_bin"].ToString();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void fillImagegrid()
        {
            string[] files = Directory.GetFiles(base.Server.MapPath("~/files/Credit_Note_Extension/"));
            List<NBR_VAT_GROUPOFCOM.Model.ImageInfoCre> imageInfoCres = new List<NBR_VAT_GROUPOFCOM.Model.ImageInfoCre>();
            string[] strArrays = files;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string fileName = Path.GetFileName(strArrays[i]);
                string[] strArrays1 = fileName.Split(new char[] { '\u005F' });
                string str = strArrays1[1];
                string str1 = strArrays1[2];
                string str2 = strArrays1[3];
                string str3 = strArrays1[4];
                if (str == Convert.ToString(this.Session["ORGANIZATION_ID"]) && str1 == Convert.ToString(this.Session["ORGBRANCHID"]))
                {
                    NBR_VAT_GROUPOFCOM.Model.ImageInfoCre imageInfoCre = new NBR_VAT_GROUPOFCOM.Model.ImageInfoCre()
                    {
                        imageName = fileName,
                        adjustmentNo = str2,
                        adjustmentDate = str3,
                        imageUrl = string.Concat("~/files/Credit_Note_Extension/", fileName)
                    };
                    imageInfoCres.Add(imageInfoCre);
                }
            }
            this.Gv_imgs.DataSource = imageInfoCres;
            this.Gv_imgs.DataBind();
        }

        private void getParty()
        {
            try
            {
                DataTable oAPartyBySeparator = (new CraDebBLL()).getOAPartyBySeparator(1);
                if (oAPartyBySeparator != null)
                {
                    this.drpParty.DataSource = oAPartyBySeparator;
                    this.drpParty.DataTextField = oAPartyBySeparator.Columns["party_name"].ToString();
                    this.drpParty.DataValueField = oAPartyBySeparator.Columns["party_id"].ToString();
                    this.drpParty.DataBind();
                    ListItem listItem = new ListItem("--- Select ---", "-99");
                    this.drpParty.Items.Insert(0, listItem);
                }
                this.Session["PARTY_INFO"] = oAPartyBySeparator;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Gv_imgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = Convert.ToString(this.Gv_imgs.SelectedDataKey["imageUrl"]);
            base.Response.Redirect(str);
        }

        private NBR_VAT_GROUPOFCOM.BLL.DebitNoteDetailDAO loadDetailData(NBR_VAT_GROUPOFCOM.BLL.DebitNoteDetailDAO objCND)
        {
            short num;
            objCND.OA_Subject = this.txtSubject.Text.Trim();
            objCND.OA_CaseNo = this.txtCaseNo.Text.Trim();
            objCND.OA_CaseDetail = this.txtDescription.Text.Trim();
            objCND.OA_Amount = Convert.ToDouble(this.txtAmount.Text.Trim());
            objCND.UserId = Convert.ToInt16(this.Session["employee_id"].ToString());
            NBR_VAT_GROUPOFCOM.BLL.DebitNoteDetailDAO debitNoteDetailDAO = objCND;
            if (this.drpOAReason.SelectedValue != "-99")
            {
                num = Convert.ToInt16(this.drpOAReason.SelectedValue);
            }
            else
            {
                num = 0;
            }
            debitNoteDetailDAO.OtherDeductReasonId = num;
            objCND.Code_id_m = 31;
            objCND.Status = 'O';
            objCND.TypeP = "C";
            if (Convert.ToInt32(this.drpOAReason.SelectedValue) == 6)
            {
                objCND.Vat_Amount = (this.txtVatAmount.Text != "" ? Convert.ToDecimal(this.txtVatAmount.Text.Trim()) : new decimal(0));
                objCND.No_of_Days = (this.txtNoOfDays.Text != "" ? Convert.ToInt32(this.txtNoOfDays.Text.Trim()) : 0);
                objCND.Interest_Pct = (this.txtInterestPct.Text != "" ? Convert.ToDecimal(this.txtInterestPct.Text.Trim()) : new decimal(0));
                objCND.Interest_Amount = (this.txtInterestAmount.Text != "" ? Convert.ToDecimal(this.txtInterestAmount.Text.Trim()) : new decimal(0));
                objCND.Particulars = this.txtParticulars.Text.Trim();
            }
            if (Convert.ToInt32(this.drpOAReason.SelectedValue) == 7)
            {
                objCND.Vat_Amount = (this.txtVatAmount.Text != "" ? Convert.ToDecimal(this.txtVatAmount.Text.Trim()) : new decimal(0));
                objCND.No_of_Days = (this.txtNoOfDays.Text != "" ? Convert.ToInt32(this.txtNoOfDays.Text.Trim()) : 0);
                objCND.Interest_Pct = (this.txtInterestPct.Text != "" ? Convert.ToDecimal(this.txtInterestPct.Text.Trim()) : new decimal(0));
                objCND.Interest_Amount = (this.txtInterestAmount.Text != "" ? Convert.ToDecimal(this.txtInterestAmount.Text.Trim()) : new decimal(0));
                objCND.Particulars = this.txtParticulars.Text.Trim();
            }
            if (Convert.ToInt32(this.drpOAReason.SelectedValue) == 8)
            {
                objCND.Vat_Amount = (this.txtRent.Text != "" ? Convert.ToDecimal(this.txtRent.Text.Trim()) : new decimal(0));
                objCND.Interest_Pct = (this.txtVATpct.Text != "" ? Convert.ToDecimal(this.txtVATpct.Text.Trim()) : new decimal(0));
                objCND.Interest_Amount = (this.txtVATamnt.Text != "" ? Convert.ToDecimal(this.txtVATamnt.Text.Trim()) : new decimal(0));
                objCND.Particulars = this.txtPartic.Text.Trim();
                objCND.AIT_Pct = (this.txtAITPct.Text != "" ? Convert.ToDecimal(this.txtAITPct.Text.Trim()) : new decimal(0));
                objCND.AIT_Amount = (this.txtAmount.Text != "" ? Convert.ToDecimal(this.txtAmount.Text.Trim()) : new decimal(0));
            }
            objCND.reason_drcr = Convert.ToInt16(this.drpOAReason.SelectedValue);
            return objCND;
        }

        //private void LoadKorMeyad()
        //{
        //    try
        //    {
        //        DateTime today = DateTime.Today;
        //        string str = today.ToString("yyyy");
        //        string str1 = today.ToString("MM");
        //        string str2 = today.ToString("MMMM");
        //        string str3 = string.Concat("15/", str1, "/", str);
        //        DateTime dateTime = DateTime.ParseExact(str3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        string str4 = today.AddMonths(-1).ToString("MM");
        //        string str5 = today.AddMonths(-1).ToString("MMMM");
        //        if (today <= dateTime)
        //        {
        //            this.drpsubmissionDate.Items.Add(new ListItem(str2, str1));
        //            this.drpsubmissionDate.Items.Add(new ListItem(str5, str4));
        //        }
        //        else
        //        {
        //            this.drpsubmissionDate.Items.Add(new ListItem(str2, str1));
        //            this.drpsubmissionDate.Items.Add(new ListItem(str5, str4));
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //         BLL.Utility.InsertErrorTrack(exception.Message, "TreasuryChallan_6.aspx", "GetPartyInfo");
        //    }
        //}





        private void LoadKorMeyad()
        {
            try
            {
                DateTime today = DateTime.Today;

                // Current Month
                string currentMonthValue = today.ToString("MM");
                string currentMonthName = today.ToString("MMMM");

                // Previous Month 1
                DateTime prev1 = today.AddMonths(-1);
                string prev1Value = prev1.ToString("MM");
                string prev1Name = prev1.ToString("MMMM");

                // Previous Month 2 (Third month)
                DateTime prev2 = today.AddMonths(-2);
                string prev2Value = prev2.ToString("MM");
                string prev2Name = prev2.ToString("MMMM");

                // Always Add three months
                drpsubmissionDate.Items.Add(new ListItem(currentMonthName, currentMonthValue));
                drpsubmissionDate.Items.Add(new ListItem(prev1Name, prev1Value));
                drpsubmissionDate.Items.Add(new ListItem(prev2Name, prev2Value));
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "TreasuryChallan_6.aspx", "GetPartyInfo");
            }
        }








        private NBR_VAT_GROUPOFCOM.BLL.DebitNoteMasterDAO loadMasterData(NBR_VAT_GROUPOFCOM.BLL.DebitNoteMasterDAO objCNM)
        {
            objCNM.OrgId = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
            objCNM.DateNote = DateTime.Now.Date;
            objCNM.NoteYear = DateTime.Now.Year;
            objCNM.UserId = Convert.ToInt16(this.Session["employee_id"].ToString());
            objCNM.PartyId = Convert.ToInt16(this.drpParty.SelectedValue);
            objCNM.RecipientDate = this.txtReceiveDate.Text.ToString();
            objCNM.CreditNotNumber = (!string.IsNullOrEmpty(this.txtCreditNote.Text) ? this.txtCreditNote.Text.Trim() : "");
            objCNM.NoteType = 'C';
            objCNM.IsOtherAdj = true;
            DateTime today = DateTime.Today;
            string str = today.ToString("yyyy");
            string str1 = today.ToString("MM");
            string str2 = today.AddMonths(-1).ToString("MM");
            string str3 = string.Concat("01/", str2, "/", str);
            if (this.drpsubmissionDate.SelectedValue != str1)
            {
                objCNM.submisionDate = DateTime.ParseExact(str3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                objCNM.submisionDate = DateTime.ParseExact(this.txtReceiveDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            return objCNM;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!base.IsPostBack)
                {
                    this.divCal.Visible = false;
                    this.divhomeRent.Visible = false;
                    this.txtReceiveDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    this.txtProviderDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    this.lblOrgName.Text = this.Session["organization_name"].ToString();
                    this.lblOrgAddress.Text = this.Session["organization_address"].ToString();
                    this.lblOrgBIN.Text = this.Session["organization_bin"].ToString();
                    this.getParty();
                    this.adjusmentReason();
                    this.LoadKorMeyad();
                    this.fillImagegrid();
                    this.hasKeys = base.Request.QueryString.HasKeys();
                    if (this.hasKeys)
                    {
                        string[] strArrays = base.Request.QueryString["Amount"].ToString().Split(new char[] { '?' });
                        this.txtAmount.Text = strArrays[0];
                        this.challanId = Convert.ToInt16(strArrays[1]);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void txtAITPct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                num = (!string.IsNullOrEmpty(this.txtRent.Text) ? Convert.ToDecimal(this.txtRent.Text.Trim()) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(this.txtAITPct.Text) ? Convert.ToDecimal(this.txtAITPct.Text.Trim()) : new decimal(0));
                num2 = (num * num1) / new decimal(100);
                this.txtAIT.Text = num2.ToString("0.00");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtInterestPct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                num = (!string.IsNullOrEmpty(this.txtRent.Text) ? Convert.ToDecimal(this.txtRent.Text.Trim()) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(this.txtVATpct.Text) ? Convert.ToDecimal(this.txtVATpct.Text.Trim()) : new decimal(0));
                num2 = (num * num1) / new decimal(100);
                this.txtInterestAmount.Text = num2.ToString("0.00");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtRent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                num = (!string.IsNullOrEmpty(this.txtRent.Text) ? Convert.ToDecimal(this.txtRent.Text.Trim()) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(this.txtVATpct.Text) ? Convert.ToDecimal(this.txtVATpct.Text.Trim()) : new decimal(0));
                num2 = (num * num1) / new decimal(100);
                this.txtVATamnt.Text = num2.ToString("0.00");
                num3 = (!string.IsNullOrEmpty(this.txtAITPct.Text) ? Convert.ToDecimal(this.txtAITPct.Text.Trim()) : new decimal(0));
                num4 = (num * num3) / new decimal(100);
                this.txtAIT.Text = num4.ToString("0.00");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtVATpct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                num = (!string.IsNullOrEmpty(this.txtRent.Text) ? Convert.ToDecimal(this.txtRent.Text.Trim()) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(this.txtVATpct.Text) ? Convert.ToDecimal(this.txtVATpct.Text.Trim()) : new decimal(0));
                num2 = (num * num1) / new decimal(100);
                this.txtVATamnt.Text = num2.ToString("0.00");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (this.FileUploadControl.HasFile)
            {
                try
                {
                    if (this.FileUploadControl.PostedFile.ContentType != "image/jpeg")
                    {
                        this.StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                    }
                    else if (this.FileUploadControl.PostedFile.ContentLength >= 102400)
                    {
                        this.StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                    {
                        string fileName = Path.GetFileName(this.FileUploadControl.FileName);
                        this.FileUploadControl.SaveAs(string.Concat(base.Server.MapPath("~/"), fileName));
                        this.StatusLabel.Text = "Upload status: File uploaded!";
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    this.StatusLabel.Text = string.Concat("Upload status: The file could not be uploaded. The following error occured: ", exception.Message);
                }
            }
        }

        private bool validation()
        {
            if (this.drpParty.SelectedValue == "" || this.drpParty.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select party name", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpOAReason.SelectedValue == "" || this.drpOAReason.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select the reason of adjustment", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtReceiveDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please provide Receive Date", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtProviderDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please provide Provide Date", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtSubject.Text == "")
            {
                this.msgBox.AddMessage("Please provide Subject", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtAmount.Text != "")
            {
                return true;
            }
            this.msgBox.AddMessage("Please provide amount", MsgBoxs.enmMessageType.Attention);
            return false;
        }
    }
}