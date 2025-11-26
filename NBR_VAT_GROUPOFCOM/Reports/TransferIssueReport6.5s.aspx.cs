using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class TransferIssueReport6__5s : Page, IRequiresSessionState
    {
    

       
        

        private SaleBLL objsBLL = new SaleBLL();

        private ChallanBLL objBLL = new ChallanBLL();

        private AddItemBLL objItemBLL = new AddItemBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

        private ContructualProductionBLL objCPBLL = new ContructualProductionBLL();

       

        public TransferIssueReport6__5s()
        {
        }

        protected void btnShowReport_OnClick(object sender, EventArgs e)
        {
            this.showReport();
        }

        protected void drpProviderBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpProviderBranch.SelectedValue == "-99")
            {
                this.txtProviderAddress.Text = string.Empty;
                return;
            }
            this.GetBranchProviderAddress();
            this.GetBranchProviderBIN();
        }

        protected void drpReceipentBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpReceipentBranch.SelectedValue != "-99")
            {
                this.fillChallanNo();
                this.GetBranchRcvrAddress();
                this.GetBranchRcvrBIN();
                return;
            }
            this.txtReceipentAddress.Text = string.Empty;
            this.txtReceipentBIN.Text = string.Empty;
        }

        private void fillChallanNo()
        {
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            try
            {
                int num = Convert.ToInt32(this.drpReceipentBranch.SelectedValue);
                int num1 = Convert.ToInt32(this.drpProviderBranch.SelectedValue);
                DataTable issuesChallanNoforRepoort = productTransferBLL.getIssuesChallanNoforRepoort(num1, num);
                this.drpChallanNo.DataSource = issuesChallanNoforRepoort;
                this.drpChallanNo.DataTextField = issuesChallanNoforRepoort.Columns["challan_no"].ToString();
                this.drpChallanNo.DataValueField = issuesChallanNoforRepoort.Columns["transfer_id"].ToString();
                this.drpChallanNo.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "0");
                this.drpChallanNo.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void GetBranchInProviderformation()
        {
            this.drpProviderBranch.Items.Clear();
            if (this.Session["ORGBRANCHID"] != null)
            {
                Convert.ToInt32(this.Session["empId"].ToString());
                Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                DataTable branchInformationForRcvr = this.objBLL.GetBranchInformationForRcvr(num1, num);
                if (branchInformationForRcvr != null && branchInformationForRcvr.Rows.Count > 0)
                {
                    this.drpProviderBranch.Items.Clear();
                    this.drpProviderBranch.DataSource = branchInformationForRcvr;
                    this.drpProviderBranch.DataTextField = branchInformationForRcvr.Columns["branch_unit_name"].ToString();
                    this.drpProviderBranch.DataValueField = branchInformationForRcvr.Columns["org_branch_reg_id"].ToString();
                    this.drpProviderBranch.DataBind();
                }
                this.GetBranchProviderAddress();
                this.GetBranchProviderBIN();
                ListItem listItem = new ListItem("--Select--", "0");
                this.drpProviderBranch.Items.Insert(0, listItem);
                this.drpProviderBranch.SelectedValue = "0";
            }
        }

        private void GetBranchProviderAddress()
        {
            if (this.Session["ORGBRANCHID"] != null)
            {
                OrgRegistrationInfoDAO orgRegistrationInfoDAO = new OrgRegistrationInfoDAO();
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.drpProviderBranch.SelectedItem.Value.ToString());
                DataTable oRGorBranch = orgRegistrationInfoDAO.GetORGorBranch(num);
                if (oRGorBranch != null && oRGorBranch.Rows.Count > 0)
                {
                    oRGorBranch.Rows[0]["branch_unit_name"].ToString();
                    this.txtProviderAddress.Text = oRGorBranch.Rows[0]["org_branch_address"].ToString();
                    return;
                }
                this.txtProviderAddress.Text = string.Empty;
            }
        }

        private void GetBranchProviderBIN()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.drpProviderBranch.SelectedItem.Value.ToString());
                if (num == 1 || num == 2 || num == 3)
                {
                    if (num1 == 0)
                    {
                        return;
                    }
                    DataTable branchBIN = challanBLL.GetBranchBIN(num2);
                    if (branchBIN != null && branchBIN.Rows.Count > 0)
                    {
                        this.txtProviderBIN.Text = branchBIN.Rows[0]["branch_unit_bin"].ToString();
                        return;
                    }
                    this.txtProviderBIN.Text = string.Empty;
                }
            }
        }

        private void GetBranchRcvrAddress()
        {
            if (this.Session["ORGBRANCHID"] != null)
            {
                OrgRegistrationInfoDAO orgRegistrationInfoDAO = new OrgRegistrationInfoDAO();
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.drpReceipentBranch.SelectedItem.Value.ToString());
                DataTable oRGorBranch = orgRegistrationInfoDAO.GetORGorBranch(num);
                if (oRGorBranch != null && oRGorBranch.Rows.Count > 0)
                {
                    oRGorBranch.Rows[0]["branch_unit_name"].ToString();
                    this.txtReceipentAddress.Text = oRGorBranch.Rows[0]["org_branch_address"].ToString();
                    return;
                }
                this.txtReceipentAddress.Text = string.Empty;
            }
        }

        private void GetBranchRcvrBIN()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.drpReceipentBranch.SelectedItem.Value.ToString());
                if (num == 1 || num == 2 || num == 3)
                {
                    if (num1 == 0)
                    {
                        return;
                    }
                    DataTable branchBIN = challanBLL.GetBranchBIN(num2);
                    if (branchBIN != null && branchBIN.Rows.Count > 0)
                    {
                        this.txtReceipentBIN.Text = branchBIN.Rows[0]["branch_unit_bin"].ToString();
                        return;
                    }
                    this.txtReceipentBIN.Text = string.Empty;
                }
            }
        }

        private void GetBranchRcvrInformation()
        {
            this.drpReceipentBranch.Items.Clear();
            ChallanBLL challanBLL = new ChallanBLL();
            Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
            int num = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
            int num1 = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
            DataTable branchInformationFormanagerNew = challanBLL.GetBranchInformationFormanagerNew(num1, num);
            if (branchInformationFormanagerNew != null && branchInformationFormanagerNew.Rows.Count > 0)
            {
                this.drpReceipentBranch.Items.Clear();
                this.drpReceipentBranch.DataSource = branchInformationFormanagerNew;
                this.drpReceipentBranch.DataTextField = branchInformationFormanagerNew.Columns["branch_unit_name"].ToString();
                this.drpReceipentBranch.DataValueField = branchInformationFormanagerNew.Columns["org_branch_reg_id"].ToString();
                this.drpReceipentBranch.DataBind();
            }
            ListItem listItem = new ListItem("--Select--", "0");
            this.drpReceipentBranch.Items.Insert(0, listItem);
            this.drpReceipentBranch.SelectedValue = "0";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            try
            {
                if (!base.IsPostBack)
                {
                    ProductTransferMaster productTransferMaster = new ProductTransferMaster();
                    this.GetBranchRcvrInformation();
                    this.GetBranchInProviderformation();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void showReport()
        {
            try
            {
                ProductTransferMaster productTransferMaster = new ProductTransferMaster();
                string[] strArrays = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
                string[] strArrays1 = strArrays;
                string[] strArrays2 = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };
                string[] strArrays3 = strArrays2;
                if (this.btnShowReport.Text == "Show Report")
                {
                    int num = Convert.ToInt32(this.drpChallanNo.SelectedValue);
                    int num1 = Convert.ToInt32(this.drpProviderBranch.SelectedValue);
                    int num2 = Convert.ToInt32(this.drpReceipentBranch.SelectedValue);
                    DataTable transferIssueInfo = this.objBLL.getTransferIssueInfo(num1, num2, num);
                    if (transferIssueInfo.Rows.Count <= 0)
                    {
                        this.tblProductTransferChallan.Text = "";
                    }
                    else
                    {
                        this.lblOrgName.Text = this.Session["organization_name"].ToString();
                        this.lblOrgBIN.Text = this.Session["organization_bin"].ToString();
                        this.lblPNameAddress.Text = string.Concat(this.drpProviderBranch.SelectedItem.ToString(), ",", this.txtProviderAddress.Text);
                        this.lblReceipentAddress.Text = string.Concat(this.drpReceipentBranch.SelectedItem.ToString(), ',', this.txtReceipentAddress.Text);
                        this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                        this.lblDutyOfficer.Text = this.Session["EMPLOYEE_NAME"].ToString();
                        this.lblChallanNo.Text = transferIssueInfo.Rows[0]["challan_no"].ToString();
                        this.lblIssueDate.Text = transferIssueInfo.Rows[0]["issues_date"].ToString();
                        this.lblIssueTime.Text = transferIssueInfo.Rows[0]["issues_time"].ToString();
                        this.txtTransport.Text = transferIssueInfo.Rows[0]["vehicle_no"].ToString();
                        string str = "";
                        for (int i = 0; i < transferIssueInfo.Rows.Count; i++)
                        {
                            string str1 = i.ToString();
                            string str2 = str1.Replace(strArrays1[i], strArrays3[i]);
                            str = string.Concat(str, "<tr>");
                            str = string.Concat(str, "<td style='border:1px solid gray'>", str2, "</td>");
                            str = string.Concat(str, "<td style='border:1px solid gray'>", transferIssueInfo.Rows[i]["item_name"].ToString(), "</td>");
                            string str3 = str;
                            string[] str4 = new string[] { str3, "<td style='border:1px solid gray;text-align: center'>", transferIssueInfo.Rows[i]["quantity"].ToString(), " ", transferIssueInfo.Rows[i]["unit_code"].ToString(), "</td>" };
                            str = string.Concat(str4);
                            str = string.Concat(str, "<td style='border:1px solid gray;text-align: center'>", transferIssueInfo.Rows[i]["price"].ToString(), "</td>");
                            str = string.Concat(str, "<td style='border:1px solid gray'>", transferIssueInfo.Rows[i]["remarks"].ToString(), "</td>");
                            str = string.Concat(str, "</tr>");
                            this.tblProductTransferChallan.Text = str;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}