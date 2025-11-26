using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.Model;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
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
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class SourceTaxDedutForm : Page, IRequiresSessionState
    {
      

        private string dFormat = "dd/MM/yyyy";

        private CultureInfo provider = CultureInfo.InvariantCulture;

   

        public SourceTaxDedutForm()
        {
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtVDSAmount.Text = this.txtReceivableVds.Text;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            VATReturnBLL vATReturnBLL = new VATReturnBLL();
            try
            {
                Convert.ToDouble(this.txtVDSAmount.Text.Trim());
                string str = this.txtSTDCertificate.Text.Trim();
                string text = this.txtAccountCode.Text;
                string selectedValue = this.drpChallanNo.SelectedValue;
                string text1 = this.txtTransferNo.Text;
                DateTime dateTime = DateTime.ParseExact(this.txtDepoDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(this.txtChallanDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime2 = DateTime.ParseExact(this.txtCertificateDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTime1.ToString("dd/MM/yyyy");
                dateTime2.ToString("dd/MM/yyyy");
                Convert.ToInt16(this.drpsubmissionDate.SelectedValue);
                DateTime today = DateTime.Today;
                string str1 = today.ToString("yyyy");
                string str2 = today.AddMonths(-1).ToString("MM");
                string str3 = "";
                if (str2 != "12")
                {
                    str3 = string.Concat("01/", str2, "/", str1);
                }
                else
                {
                    string str4 = today.AddYears(-1).ToString("yyyy");
                    str3 = string.Concat("01/", str2, "/", str4);
                }
                DateTime now = DateTime.Now;
                DateTime now1 = DateTime.Now;
                string str5 = today.ToString("MM");
                now1 = (this.drpsubmissionDate.SelectedValue != str5 ? DateTime.ParseExact(str3, "dd/MM/yyyy", CultureInfo.InvariantCulture) : now);
                if (!this.MasterValidation())
                {
                    this.msgBox.AddMessage("Insert Data Properly ", MsgBoxs.enmMessageType.Error);
                }
                else if (!vATReturnBLL.updateRcvVDS(this.txtVdsIDs.Text, str, selectedValue, text, dateTime2, dateTime, text1, now1))
                {
                    this.msgBox.AddMessage("Data Insert failed ", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    if (this.FileUploadControl.HasFile)
                    {
                        HttpFileCollection files = base.Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFile item = files[i];
                            string str6 = Convert.ToString(this.Session["ORGANIZATION_ID"]);
                            string str7 = Convert.ToString(this.Session["ORGBRANCHID"]);
                            string[] strArrays = new string[] { "StdCertificate_", str6, "_", str7, "_", selectedValue, "_", null, null, null, null };
                            strArrays[7] = DateTime.Today.ToString("dd-MM-yyyy");
                            strArrays[8] = "_";
                            strArrays[9] = (i + 1).ToString();
                            strArrays[10] = ".jpeg";
                            string str8 = string.Concat(strArrays);
                            item.SaveAs(base.Server.MapPath(string.Concat("~/files/SourceTaxDeductedCertificate_Receive//", str8)));
                            this.StatusLabel.ForeColor = Color.ForestGreen;
                        }
                    }
                    this.msgBox.AddMessage("Data Insert Successfully ", MsgBoxs.enmMessageType.Success);
                    this.clearMaster();
                    this.clearDetail();
                    this.fillImagegrid();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void clearDetail()
        {
            this.txtReceivableVds.Text = "";
            ListItem listItem = new ListItem("", "-99");
            this.txtAmount.Text = "";
            this.txtTax.Text = "";
            this.txtPaidAmount.Text = "";
        }

        private void clearMaster()
        {
            this.drpParty.SelectedValue = "-99";
            this.txtPartyName.Visible = false;
            this.txtAddress.Text = "";
            this.txtPartyBIN.Text = "";
            this.txtSTDCertificate.Text = "";
            this.txtAccountCode.Text = "";
            this.txtVDSAmount.Text = "";
            this.txtTransferNo.Text = "";
            this.txtCertificateDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.txtChallanDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
            this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
            this.Session["DETAIL_VDS"] = new ArrayList();
            this.loadGridview();
            this.drpChallanNo.SelectedValue = "-99";
        }

        protected void drpBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpBranchName.SelectedValue == "-99")
            {
                this.lblBranchAddress.Text = string.Empty;
                return;
            }
            this.GetBranchAddress();
            this.GetBranchBIN();
        }

        protected void drpChallanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            VATReturnBLL vATReturnBLL = new VATReturnBLL();
            string selectedValue = this.drpChallanNo.SelectedValue;
            DataTable challnDate = vATReturnBLL.getChallnDate(selectedValue);
            if (challnDate.Rows.Count > 0)
            {
                string str = challnDate.Rows[0]["date_challan"].ToString();
                string[] strArrays = str.Split(new char[] { ' ' });
                DateTime dateTime = DateTime.Parse(strArrays[0].ToString());
                this.txtChallanDate.Text = dateTime.ToString("dd/MM/yyyy");
                this.LoadKorMeyad();
                if (strArrays[1].ToString() != null)
                {
                    string str1 = strArrays[1].ToString();
                    string[] strArrays1 = str1.Split(new char[] { ':' });
                    if (strArrays1[0].Length == 1)
                    {
                        strArrays1[0] = string.Concat("0", strArrays1[0]);
                    }
                    if (strArrays1[1].Length == 1)
                    {
                        strArrays1[1] = string.Concat("0", strArrays1[1]);
                    }
                    this.drpChDtHr.SelectedValue = strArrays1[0].ToString();
                    this.drpChDtMin.SelectedValue = strArrays1[1].ToString();
                }
            }
            DataTable receivableVDS = vATReturnBLL.getReceivableVDS(selectedValue);
            if (receivableVDS != null && receivableVDS.Rows.Count > 0)
            {
                TextBox textBox = this.txtAmount;
                decimal num = Convert.ToDecimal(receivableVDS.Rows[0]["total_price"]);
                textBox.Text = num.ToString("N2");
                TextBox textBox1 = this.txtTax;
                decimal num1 = Convert.ToDecimal(receivableVDS.Rows[0]["total_vds"]);
                textBox1.Text = num1.ToString("N2");
                TextBox str2 = this.txtPaidAmount;
                decimal num2 = Convert.ToDecimal(receivableVDS.Rows[0]["paid_amount"]);
                str2.Text = num2.ToString("N2");
                TextBox textBox2 = this.txtReceivedVds;
                decimal num3 = Convert.ToDecimal(receivableVDS.Rows[0]["received_vds"]);
                textBox2.Text = num3.ToString("N2");
                TextBox str3 = this.txtReceivableVds;
                decimal num4 = Convert.ToDecimal(receivableVDS.Rows[0]["vat"]);
                str3.Text = num4.ToString("N2");
                this.txtVdsIDs.Text = Convert.ToString(receivableVDS.Rows[0]["serials"]);
                this.txtAmount.ReadOnly = true;
                this.txtTax.ReadOnly = true;
            }
        }

        protected void drpChDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpChDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.clearDetail();
                this.drpChallanNo.Items.Clear();
                ProductTransferBLL productTransferBLL = new ProductTransferBLL();
                int num = Convert.ToInt32(this.drpParty.SelectedValue);
                DataTable item = (DataTable)this.Session["PARTY_INFO"];
                if (item != null)
                {
                    DataRow[] dataRowArray = item.Select(string.Concat("party_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.txtAddress.Text = dataRow["party_address"].ToString();
                        this.txtPartyBIN.Text = dataRow["party_bin"].ToString();
                    }
                }
                DateTime now = DateTime.Now;
                DateTime dateTime = now.AddMonths(-5);
                DataTable saleVDSChallanNoByParty = productTransferBLL.getSaleVDSChallanNoByParty(num, dateTime, now);
                if (saleVDSChallanNoByParty.Rows.Count <= 0)
                {
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    this.drpChallanNo.Items.Insert(0, listItem);
                }
                else
                {
                    this.drpChallanNo.DataSource = saleVDSChallanNoByParty;
                    this.drpChallanNo.DataTextField = saleVDSChallanNoByParty.Columns["challan_no"].ToString();
                    this.drpChallanNo.DataBind();
                    ListItem listItem1 = new ListItem("-- Select --", "-99");
                    this.drpChallanNo.Items.Insert(0, listItem1);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpVatType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void fillDetailData()
        {
            VDS vD = new VDS();
            ArrayList item = (ArrayList)this.Session["DETAIL_VDS"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            vD.RowNO = num;
            vD.TotalPrice = Convert.ToDouble(this.txtAmount.Text.Trim());
            vD.TotalVat = Convert.ToDouble(this.txtTax.Text.Trim());
            for (int i = 0; i < item.Count; i++)
            {
                if (vD.Item == ((VDS)item[i]).Item)
                {
                    VDS quantity = (VDS)item[i];
                    quantity.Quantity = quantity.Quantity + vD.Quantity;
                    VDS unitPrice = (VDS)item[i];
                    unitPrice.UnitPrice = unitPrice.UnitPrice + vD.UnitPrice;
                    VDS totalPrice = (VDS)item[i];
                    totalPrice.TotalPrice = totalPrice.TotalPrice + vD.TotalPrice;
                    VDS totalVat = (VDS)item[i];
                    totalVat.TotalVat = totalVat.TotalVat + vD.TotalVat;
                    this.Session["DETAIL_VDS"] = item;
                    return;
                }
            }
            item.Add(vD);
            this.Session["DETAIL_VDS"] = item;
        }

        private void fillImagegrid()
        {
            string[] files = Directory.GetFiles(base.Server.MapPath("~/files/SourceTaxDeductedCertificate_Receive/"));
            List<ImageInfoSTD> imageInfoSTDs = new List<ImageInfoSTD>();
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
                    ImageInfoSTD imageInfoSTD = new ImageInfoSTD()
                    {
                        imageName = fileName,
                        challanNo = str2,
                        certificateDate = str3,
                        imageUrl = string.Concat("~/files/SourceTaxDeductedCertificate_Receive/", fileName)
                    };
                    imageInfoSTDs.Add(imageInfoSTD);
                }
            }
            this.Gv_imgs.DataSource = imageInfoSTDs;
            this.Gv_imgs.DataBind();
        }

        private void fillParty()
        {
            VATReturnBLL vATReturnBLL = new VATReturnBLL();
            try
            {
                DataTable dataTable = vATReturnBLL.fillPartyName();
                if (dataTable != null)
                {
                    this.drpParty.DataSource = dataTable;
                    this.drpParty.DataTextField = dataTable.Columns["party_name"].ToString();
                    this.drpParty.DataValueField = dataTable.Columns["party_id"].ToString();
                    this.drpParty.DataBind();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpParty.Items.Insert(0, listItem);
                }
                this.Session["PARTY_INFO"] = dataTable;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void GetBranchAddress()
        {
            if (this.Session["ORGBRANCHID"] != null)
            {
                OrgRegistrationInfoDAO orgRegistrationInfoDAO = new OrgRegistrationInfoDAO();
                int num = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num1 = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                DataTable oRGorBranch = orgRegistrationInfoDAO.GetORGorBranch(num1);
                if (oRGorBranch == null || oRGorBranch.Rows.Count <= 0)
                {
                    this.lblBranchAddress.Text = string.Empty;
                }
                else
                {
                    string str = oRGorBranch.Rows[0]["IS_branch_registration"].ToString();
                    if (str == "False")
                    {
                        DataTable branchAddORGRegistration = orgRegistrationInfoDAO.GetBranchAddORGRegistration(num);
                        string str1 = branchAddORGRegistration.Rows[0]["holding"].ToString();
                        string str2 = branchAddORGRegistration.Rows[0]["road_no"].ToString();
                        string str3 = branchAddORGRegistration.Rows[0]["district_name"].ToString();
                        Label label = this.lblBranchAddress;
                        string[] strArrays = new string[] { "  ", str1, ",", str2, ",", str3, "." };
                        label.Text = string.Concat(strArrays);
                    }
                    if (str == "True")
                    {
                        DataTable branchAddBrachRegistration = orgRegistrationInfoDAO.GetBranchAddBrachRegistration(num);
                        string str4 = branchAddBrachRegistration.Rows[0]["holding"].ToString();
                        string str5 = branchAddBrachRegistration.Rows[0]["road_no"].ToString();
                        string str6 = branchAddBrachRegistration.Rows[0]["district_name"].ToString();
                        Label label1 = this.lblBranchAddress;
                        string[] strArrays1 = new string[] { "  ", str4, ",", str5, ",", str6, "." };
                        label1.Text = string.Concat(strArrays1);
                        return;
                    }
                }
            }
        }

        private void GetBranchBIN()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                if (num == 1 || num == 2 || num == 3)
                {
                    if (num1 == 0)
                    {
                        return;
                    }
                    DataTable branchBIN = challanBLL.GetBranchBIN(num2);
                    if (branchBIN != null && branchBIN.Rows.Count > 0)
                    {
                        this.lblBranchBin.Text = branchBIN.Rows[0]["branch_unit_bin"].ToString();
                        return;
                    }
                    this.lblBranchBin.Text = string.Empty;
                }
            }
        }

        private void GetBranchInformation()
        {
            this.drpBranchName.Items.Clear();
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                if (num2 <= 0)
                {
                    num2 = 0;
                }
                if (num == 3)
                {
                    this.drpBranchName.Enabled = false;
                    if (num1 != 0)
                    {
                        DataTable branchInformation = challanBLL.GetBranchInformation(num2, num1);
                        if (branchInformation != null && branchInformation.Rows.Count > 0)
                        {
                            this.drpBranchName.DataSource = branchInformation;
                            this.drpBranchName.DataTextField = branchInformation.Columns["branch_unit_name"].ToString();
                            this.drpBranchName.DataValueField = branchInformation.Columns["org_branch_reg_id"].ToString();
                            this.drpBranchName.DataBind();
                        }
                    }
                    else
                    {
                        ListItem listItem = new ListItem("Head Office", "0");
                        this.drpBranchName.Items.Insert(1, listItem);
                    }
                }
                if (num == 2 || num == 1)
                {
                    this.drpBranchName.Enabled = true;
                    DataTable branchInformationFormanager = challanBLL.GetBranchInformationFormanager(num2);
                    if (branchInformationFormanager != null && branchInformationFormanager.Rows.Count > 0)
                    {
                        this.drpBranchName.DataSource = branchInformationFormanager;
                        this.drpBranchName.DataTextField = branchInformationFormanager.Columns["branch_unit_name"].ToString();
                        this.drpBranchName.DataValueField = branchInformationFormanager.Columns["org_branch_reg_id"].ToString();
                        this.drpBranchName.DataBind();
                    }
                    ListItem listItem1 = new ListItem("Head Office", "0");
                    this.drpBranchName.Items.Insert(0, listItem1);
                }
            }
        }

        protected void Gv_imgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = Convert.ToString(this.Gv_imgs.SelectedDataKey["imageUrl"]);
            base.Response.Redirect(str);
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["DETAIL_VDS"];
                item.RemoveAt(e.RowIndex);
                this.Session["DETAIL_VDS"] = item;
                this.loadGridview();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadGridview()
        {
            ArrayList item = (ArrayList)this.Session["DETAIL_VDS"];
            this.gvItem.DataSource = item;
            this.gvItem.DataBind();
        }

        private void loadHour()
        {
            for (int i = 0; i < 24; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
            }
        }

        private void LoadKorMeyad()
        {
            try
            {
                DateTime today = DateTime.Today;
                string str = today.ToString("yyyy");
                string str1 = today.ToString("MM");
                string str2 = today.ToString("MMMM");
                string str3 = string.Concat("15/", str1, "/", str);
                DateTime dateTime = DateTime.ParseExact(str3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str4 = today.AddMonths(-1).ToString("MM");
                string str5 = today.AddMonths(-1).ToString("MMMM");
                if (today <= dateTime)
                {
                    this.drpsubmissionDate.Items.Add(new ListItem(str2, str1));
                    this.drpsubmissionDate.Items.Add(new ListItem(str5, str4));
                }
                else
                {
                    this.drpsubmissionDate.Items.Add(new ListItem(str2, str1));
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "TreasuryChallan_6.aspx", "GetPartyInfo");
            }
        }

        private void loadMinutes()
        {
            this.drpChDtMin.Items.Add("00");
            for (int i = 0; i < 60; i++)
            {
                this.drpChDtMin.Items.Add(i.ToString("00"));
            }
        }

        private bool MasterValidation()
        {
            if (this.txtAccountCode.Text.Length == 0)
            {
                this.msgBox.AddMessage("Insert Account Code.", MsgBoxs.enmMessageType.Attention);
                this.txtAccountCode.Focus();
                return false;
            }
            if (this.txtAmount.Text.Length == 0)
            {
                this.msgBox.AddMessage("Insert Amount.", MsgBoxs.enmMessageType.Attention);
                this.txtAmount.Focus();
                return false;
            }
            if (this.txtSTDCertificate.Text.Length != 0)
            {
                return true;
            }
            this.msgBox.AddMessage("Insert VDS Certificate No.", MsgBoxs.enmMessageType.Attention);
            this.txtSTDCertificate.Focus();
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!base.IsPostBack)
                {
                    this.Session["DETAIL_VDS"] = new ArrayList();
                    this.lblOrgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.fillParty();
                    this.txtCertificateDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                    this.txtChallanDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                    this.txtDepoDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                    this.loadHour();
                    this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.loadMinutes();
                    this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                    this.GetBranchInformation();
                    this.fillImagegrid();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
    }
}