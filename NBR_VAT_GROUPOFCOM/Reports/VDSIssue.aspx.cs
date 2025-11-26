using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class VDSIssue : Page, IRequiresSessionState
    {
     

        private string dFormat = "dd/MM/yyyy";

        private VATReturnBLL objBL = new VATReturnBLL();

        private CultureInfo provider = CultureInfo.InvariantCulture;

      

        public VDSIssue()
        {
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.loadGridview();
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
            try
            {
                if (this.MasterValidation())
                {
                    string str = this.txtSTDCertificate.Text.Trim();
                    DateTime dateTime = DateTime.ParseExact(this.txtCertificateDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                    string text = "";
                    List<bool> flags = new List<bool>();
                    int num = 0;
                    bool flag = false;
                    if (this.grdparty.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.grdparty.Rows.Count; i++)
                        {
                            if (((CheckBox)this.grdparty.Rows[i].FindControl("chkChallan")).Checked)
                            {
                                int num1 = Convert.ToInt32(this.grdparty.Rows[i].Cells[2].Text);
                                TextBox textBox = this.trchallanDate;
                                DateTime dateTime1 = Convert.ToDateTime(this.grdparty.Rows[i].Cells[9].Text);
                                textBox.Text = dateTime1.ToString("dd/MM/yyyy");
                                DateTime dateTime2 = DateTime.ParseExact(this.trchallanDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                DateTime dateTime3 = dateTime2.AddDays(3);
                                text = this.grdparty.Rows[i].Cells[1].Text;
                                if (dateTime > dateTime3)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", string.Concat("alert('Date Expired for ", text, ".');"), true);
                                }
                                flag = this.objBL.updateVDSForIssue(str, num1, dateTime, text);
                                num++;
                                flags.Add(flag);
                            }
                        }
                    }
                    int num2 = flags.Count<bool>((bool t) => t);
                    int num3 = flags.Count<bool>((bool t) => !t);
                    if (num2 > 0)
                    {
                        this.msgBox.AddMessage(string.Concat(num2, "Data Insert Successfully "), MsgBoxs.enmMessageType.Success);
                        this.showreport(str);
                        this.clearMaster();
                    }
                    if (num3 > 0)
                    {
                        this.msgBox.AddMessage(string.Concat(num3, "  Informations Failed to save."), MsgBoxs.enmMessageType.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.fillPartyforSearch();
                this.lblSTDC.Text = "";
                this.trch.InnerText = "";
                this.trDate.InnerText = "";
                this.trBank.InnerText = "";
                this.trBranch.InnerText = "";
                this.lblTaxDeductedCertificateNo.Text = "";
                this.issuesDate.Text = "";
                this.btnShow.Text = "Show Report";
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.btnShow.Text != "Show Report")
                {
                    this.report.Visible = false;
                    this.btnShow.Text = "Show Report";
                    this.btnPrintReport.Visible = false;
                }
                else
                {
                    this.OrgName.Text = this.lblOrgName.Text.ToString();
                    this.OrgAddress.Text = this.lblOrgAddress.Text.ToString();
                    this.OrgBin.Text = this.lblOrgBIN.Text.ToString();
                    this.showreportOnButton();
                    this.report.Visible = true;
                    this.btnShow.Text = "Show Report";
                    this.btnPrintReport.Visible = true;
                    this.clearMaster();
                    this.clearDetail();
                    this.loadGridview();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void clearDetail()
        {
            this.Session["GRID_DATA"] = new DataTable();
        }

        private void clearMaster()
        {
            this.drpParty.SelectedValue = "-99";
            this.txtPartyName.Visible = false;
            this.txtAddress.Text = "";
            this.txtPartyBIN.Text = "";
            this.GetNextChallanNo();
            this.txtCertificateDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpChallanNumber.Items.Insert(0, listItem);
            this.grdparty.DataSource = null;
            this.grdparty.DataBind();
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

        protected void drpChallanNumber_OnSelectedIndexChanged(object sender, EventArgs e)
        {
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
                this.drpChallanNumber.Items.Clear();
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
                DataTable challanNoByParty = this.objBL.getChallanNoByParty(num);
                if (challanNoByParty.Rows.Count > 0)
                {
                    this.drpChallanNumber.DataSource = challanNoByParty;
                    this.drpChallanNumber.DataTextField = challanNoByParty.Columns["challan_no"].ToString();
                    this.drpChallanNumber.DataValueField = challanNoByParty.Columns["challan_id"].ToString();
                    this.drpChallanNumber.DataBind();
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    this.drpChallanNumber.Items.Insert(0, listItem);
                }
                this.loadGridviewbyParty();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpPartySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.fillCertificateNoByParty();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpVatType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void fillCertificateNoByParty()
        {
            try
            {
                if (this.drpPartySearch.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpPartySearch.SelectedValue);
                    DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateTime2 = dateTime1.AddDays(1);
                    DataTable dataTable = this.objBL.fillVDSCertificatenoforSearch(num, dateTime, dateTime2);
                    if (dataTable != null)
                    {
                        this.drpCerficateNo.DataSource = dataTable;
                        this.drpCerficateNo.DataTextField = dataTable.Columns["vds_certificate_no"].ToString();
                        this.drpCerficateNo.DataValueField = dataTable.Columns["vds_certificate_no"].ToString();
                        this.drpCerficateNo.DataBind();
                        ListItem listItem = new ListItem("---SELECT---", "-99");
                        this.drpCerficateNo.Items.Insert(0, listItem);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void fillDetail()
        {
            long num = (long)0;
            VATReturnBLL vATReturnBLL = new VATReturnBLL();
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime2 = dateTime1.AddDays(1);
            string selectedValue = this.drpChallanNumber.SelectedValue;
            if (this.drpParty.SelectedValue != "-99")
            {
                num = Convert.ToInt64(this.drpParty.SelectedValue);
            }
            int num1 = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
            DataTable vDSData = vATReturnBLL.getVDSData(dateTime, dateTime2, selectedValue, num, num1);
            this.Session["GRID_DATA"] = vDSData;
        }

        private void fillParty()
        {
            try
            {
                DataTable dataTable = this.objBL.fillPartyName();
                if (dataTable != null)
                {
                    this.drpParty.DataSource = dataTable;
                    this.drpParty.DataTextField = dataTable.Columns["party_name"].ToString();
                    this.drpParty.DataValueField = dataTable.Columns["party_id"].ToString();
                    this.drpParty.DataBind();
                    ListItem listItem = new ListItem("---SELECT---", "-99");
                    this.drpParty.Items.Insert(0, listItem);
                }
                this.Session["PARTY_INFO"] = dataTable;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void fillPartyforSearch()
        {
            try
            {
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime2 = dateTime1.AddDays(1);
                DataTable dataTable = this.objBL.fillPartyNameforSearch(dateTime, dateTime2);
                if (dataTable != null)
                {
                    this.drpPartySearch.DataSource = dataTable;
                    this.drpPartySearch.DataTextField = dataTable.Columns["party_name"].ToString();
                    this.drpPartySearch.DataValueField = dataTable.Columns["party_id"].ToString();
                    this.drpPartySearch.DataBind();
                    ListItem listItem = new ListItem("---SELECT---", "-99");
                    this.drpPartySearch.Items.Insert(0, listItem);
                }
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
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                DataTable oRGorBranch = orgRegistrationInfoDAO.GetORGorBranch(num);
                if (oRGorBranch != null && oRGorBranch.Rows.Count > 0)
                {
                    oRGorBranch.Rows[0]["branch_unit_name"].ToString();
                    this.lblBranchAddress.Text = oRGorBranch.Rows[0]["org_branch_address"].ToString();
                    return;
                }
                this.lblBranchAddress.Text = string.Empty;
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
                Convert.ToInt32(this.Session["empId"].ToString());
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
                        DataTable selectedBusinessUnitBranchInfo = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                        if (selectedBusinessUnitBranchInfo != null && selectedBusinessUnitBranchInfo.Rows.Count > 0)
                        {
                            this.drpBranchName.DataSource = selectedBusinessUnitBranchInfo;
                            this.drpBranchName.DataTextField = selectedBusinessUnitBranchInfo.Columns["branch_unit_name"].ToString();
                            this.drpBranchName.DataValueField = selectedBusinessUnitBranchInfo.Columns["org_branch_reg_id"].ToString();
                            this.drpBranchName.DataBind();
                        }
                    }
                    else
                    {
                        ListItem listItem = new ListItem("Head Office", "0");
                        this.drpBranchName.Items.Insert(0, listItem);
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
                if (num == 2 || num == 1)
                {
                    this.drpBranchName.Enabled = true;
                    DataTable dataTable = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpBranchName.DataSource = dataTable;
                        this.drpBranchName.DataTextField = dataTable.Columns["branch_unit_name"].ToString();
                        this.drpBranchName.DataValueField = dataTable.Columns["org_branch_reg_id"].ToString();
                        this.drpBranchName.DataBind();
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
            }
        }

        private void GetNextChallanNo()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            short num1 = Convert.ToInt16(this.drpBranchName.SelectedValue);
            DataTable nextChallanNo = challanBLL.GetNextChallanNo(7, num, num1);
            if (nextChallanNo == null || nextChallanNo.Rows.Count <= 0)
            {
                this.txtSTDCertificate.Text = "";
                this.hdBookId.Value = "";
                this.hdPageNo.Value = "";
                return;
            }
            this.txtSTDCertificate.Text = nextChallanNo.Rows[0]["challan_no"].ToString();
            this.hdBookId.Value = nextChallanNo.Rows[0]["challan_book_id"].ToString();
            this.hdPageNo.Value = nextChallanNo.Rows[0]["page_no"].ToString();
        }

        protected void gvChallan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[12].Visible = false;
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
            DataTable item = (DataTable)this.Session["GRID_DATA"];
            this.gvChallanItem.DataSource = item;
            this.gvChallanItem.DataBind();
        }

        private void loadGridviewbyParty()
        {
            VATReturnBLL vATReturnBLL = new VATReturnBLL();
            int num = 0;
            if (this.drpParty.SelectedValue != "-99")
            {
                num = Convert.ToInt32(this.drpParty.SelectedValue);
            }
            DataTable vDSDatabyParty = vATReturnBLL.getVDSDatabyParty(num);
            this.grdparty.DataSource = vDSDatabyParty;
            this.grdparty.DataBind();
        }

        private bool MasterValidation()
        {
            if (this.txtSTDCertificate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Set VDS Certificate No from Challan Book Setup First", MsgBoxs.enmMessageType.Attention);
                this.txtSTDCertificate.Focus();
                return false;
            }
            int num = 0;
            if (this.grdparty.Rows.Count > 0)
            {
                int num1 = 0;
                while (num1 < this.grdparty.Rows.Count)
                {
                    if (!((CheckBox)this.grdparty.Rows[num1].FindControl("chkChallan")).Checked)
                    {
                        num1++;
                    }
                    else
                    {
                        num++;
                        break;
                    }
                }
                if (num == 0)
                {
                    this.msgBox.AddMessage("Please Check any transaction from the grid", MsgBoxs.enmMessageType.Attention);
                    return false;
                }
            }
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MQMM.LoginCheckForUser();
                if (!base.IsPostBack)
                {
                    this.lblOrgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.fillParty();
                    this.txtCertificateDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                    this.dtpDateFrom.Text = DateTime.Today.Date.ToString("01/MM/yyyy");
                    this.dtpDateTo.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                    this.GetBranchInformation();
                    this.GetNextChallanNo();
                    this.lblPrintDateTime.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
                    this.lblUser.Text = this.Session["employee_name"].ToString();
                    ListItem listItem = new ListItem("-- SELECT --", "-99");
                    this.drpChallanNumber.Items.Insert(0, listItem);
                    this.lblDutyOfficerName.InnerText = this.Session["EMPLOYEE_NAME"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void showreport(string certificate)
        {
            decimal num = new decimal(0);
            int num1 = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            int num2 = Convert.ToInt32(this.drpParty.SelectedValue);
            this.OrgName.Text = this.lblOrgName.Text.ToString();
            this.OrgAddress.Text = this.lblOrgAddress.Text.ToString();
            this.OrgBin.Text = this.lblOrgBIN.Text.ToString();
            DataTable vDSDataByPartyChallanForRpt = this.objBL.getVDSDataByPartyChallanForRpt(certificate, (long)num2);
            string str = "";
            short num3 = 0;
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            for (int i = 0; i < vDSDataByPartyChallanForRpt.Rows.Count; i++)
            {
                num3 = (short)(num3 + 1);
                str = string.Concat(str, "<tr>");
                object obj = str;
                object[] objArray = new object[] { obj, "<td>", num3, "</td>" };
                str = string.Concat(objArray);
                object obj1 = str;
                object[] item = new object[] { obj1, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["party"], "</td>" };
                str = string.Concat(item);
                object obj2 = str;
                object[] item1 = new object[] { obj2, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["party_bin"], "</td>" };
                str = string.Concat(item1);
                object obj3 = str;
                object[] objArray1 = new object[] { obj3, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["challan_no"], "</td>" };
                str = string.Concat(objArray1);
                object obj4 = str;
                object[] item2 = new object[] { obj4, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["challan_date"], "</td>" };
                str = string.Concat(item2);
                str = (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["amount"]) != new decimal(0) ? string.Concat(str, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["pamount"]), num1), "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                str = (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]) != new decimal(0) ? string.Concat(str, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]), num1), "</td>") : string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>"));
                if (vDSDataByPartyChallanForRpt.Rows.Count > 1 && i < vDSDataByPartyChallanForRpt.Rows.Count - 1)
                {
                    if (Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["item_id"]) != Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i + 1]["item_id"]) && Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["challan_id"]) == Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i + 1]["challan_id"]))
                    {
                        if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                        {
                            str = string.Concat(str, "<td rowspan='2' style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num1), "</td>");
                            num = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                        }
                        else
                        {
                            str = string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                    }
                    else if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                    {
                        str = string.Concat(str, "<td  style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num1), "</td>");
                        num = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                    }
                    else
                    {
                        str = string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                }
                else if (vDSDataByPartyChallanForRpt.Rows.Count == 1)
                {
                    if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                    {
                        str = string.Concat(str, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num1), "</td>");
                        num = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                    }
                    else
                    {
                        str = string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                }
                else if (Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["item_id"]) != Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i - 1]["item_id"]) && Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["challan_id"]) == Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i - 1]["challan_id"]))
                {
                    num = new decimal(0);
                }
                else if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                {
                    str = string.Concat(str, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num1), "</td>");
                    num = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                }
                else
                {
                    str = string.Concat(str, "<td style='text-align:right;padding:3px'>-</td>");
                }
                num4 += Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["pamount"]);
                if (vDSDataByPartyChallanForRpt.Rows.Count <= 1)
                {
                    num5 = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]);
                }
                else
                {
                    num5 += Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]);
                }
                num6 += num;
                str = string.Concat(str, "</tr>");
            }
            str = string.Concat(str, "<tr>");
            str = string.Concat(str, "<td colspan='5' style='text-align: right;padding:5px; font-weight:bold;'>মোট :</td>");
            str = string.Concat(str, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(num4, num1), "</td>");
            str = string.Concat(str, "<td style='text-align: right;font-weight:bold;'></td>");
            str = string.Concat(str, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(num6, num1), "</td>");
            str = string.Concat(str, "</tr>");
            this.lblSTDC.Text = str;
            string str1 = vDSDataByPartyChallanForRpt.Rows[0]["issue_date"].ToString();
            this.issuesDate.Text = str1;
            this.lblTaxDeductedCertificateNo.Text = vDSDataByPartyChallanForRpt.Rows[0]["vds_certificate_no"].ToString();
            this.trch.InnerText = string.Concat(vDSDataByPartyChallanForRpt.Rows[0]["tr_challan_no"].ToString(), ',');
            this.trDate.InnerText = string.Concat(vDSDataByPartyChallanForRpt.Rows[0]["trchallanDate"].ToString(), ',');
            this.trBank.InnerText = string.Concat(vDSDataByPartyChallanForRpt.Rows[0]["bank_name"].ToString(), ',');
            this.trBranch.InnerText = vDSDataByPartyChallanForRpt.Rows[0]["branch_name"].ToString();
        }

        private void showreportOnButton()
        {
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            int num4 = Convert.ToInt32(this.drpPartySearch.SelectedValue);
            string str = this.drpCerficateNo.SelectedItem.ToString();
            DataTable vDSDataByPartyChallanForRpt = this.objBL.getVDSDataByPartyChallanForRpt(str, (long)num4);
            string str1 = "";
            short num5 = 0;
            for (int i = 0; i < vDSDataByPartyChallanForRpt.Rows.Count; i++)
            {
                decimal num6 = new decimal(0);
                num5 = (short)(num5 + 1);
                str1 = string.Concat(str1, "<tr>");
                object obj = str1;
                object[] objArray = new object[] { obj, "<td>", num5, "</td>" };
                str1 = string.Concat(objArray);
                object obj1 = str1;
                object[] item = new object[] { obj1, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["party"], "</td>" };
                str1 = string.Concat(item);
                object obj2 = str1;
                object[] item1 = new object[] { obj2, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["party_bin"], "</td>" };
                str1 = string.Concat(item1);
                object obj3 = str1;
                object[] objArray1 = new object[] { obj3, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["challan_no"], "</td>" };
                str1 = string.Concat(objArray1);
                object obj4 = str1;
                object[] item2 = new object[] { obj4, "<td style='text-align:left'>", vDSDataByPartyChallanForRpt.Rows[i]["challan_date"], "</td>" };
                str1 = string.Concat(item2);
                str1 = (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["amount"]) != new decimal(0) ? string.Concat(str1, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["pamount"]), num), "</td>") : string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>"));
                str1 = (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]) != new decimal(0) ? string.Concat(str1, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]), num), "</td>") : string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>"));
                if (vDSDataByPartyChallanForRpt.Rows.Count > 1 && i < vDSDataByPartyChallanForRpt.Rows.Count - 1)
                {
                    if (Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["item_id"]) != Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i + 1]["item_id"]) && Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["challan_id"]) == Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i + 1]["challan_id"]))
                    {
                        if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                        {
                            str1 = string.Concat(str1, "<td rowspan='2' style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num), "</td>");
                            num6 = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                        }
                        else
                        {
                            str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                        }
                    }
                    else if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                    {
                        str1 = string.Concat(str1, "<td  style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num), "</td>");
                        num6 = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                }
                else if (vDSDataByPartyChallanForRpt.Rows.Count == 1)
                {
                    if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num), "</td>");
                        num6 = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                }
                else if (Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["item_id"]) == Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i - 1]["item_id"]) || Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i]["challan_id"]) != Convert.ToInt16(vDSDataByPartyChallanForRpt.Rows[i - 1]["challan_id"]))
                {
                    if (Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]) != new decimal(0))
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right'>", Utilities.RoundUpToWithString(Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]), num), "</td>");
                        num6 = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["vds_amount"]);
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                }
                num1 += Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["pamount"]);
                if (vDSDataByPartyChallanForRpt.Rows.Count <= 1)
                {
                    num2 = Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]);
                }
                else
                {
                    num2 += Convert.ToDecimal(vDSDataByPartyChallanForRpt.Rows[i]["total_vat"]);
                }
                num3 += num6;
                str1 = string.Concat(str1, "</tr>");
            }
            str1 = string.Concat(str1, "<tr>");
            str1 = string.Concat(str1, "<td colspan='5' style='text-align: right;padding:5px; font-weight:bold;'>মোট :</td>");
            str1 = string.Concat(str1, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(num1, num), "</td>");
            str1 = string.Concat(str1, "<td style='text-align: right;font-weight:bold;'></td>");
            str1 = string.Concat(str1, "<td style='text-align: right;font-weight:bold;'>", Utilities.RoundUpToWithString(num3, num), "</td>");
            str1 = string.Concat(str1, "</tr>");
            string str2 = vDSDataByPartyChallanForRpt.Rows[0]["issue_date"].ToString();
            this.issuesDate.Text = str2;
            this.lblTaxDeductedCertificateNo.Text = vDSDataByPartyChallanForRpt.Rows[0]["vds_certificate_no"].ToString();
            this.lblSTDC.Text = str1;
            this.trch.InnerText = string.Concat(vDSDataByPartyChallanForRpt.Rows[0]["tr_challan_no"].ToString(), ',');
            this.trDate.InnerText = string.Concat(vDSDataByPartyChallanForRpt.Rows[0]["trchallanDate"].ToString(), ',');
            this.trBank.InnerText = string.Concat(vDSDataByPartyChallanForRpt.Rows[0]["bank_name"].ToString(), ',');
            this.trBranch.InnerText = vDSDataByPartyChallanForRpt.Rows[0]["branch_name"].ToString();
        }
    }
}