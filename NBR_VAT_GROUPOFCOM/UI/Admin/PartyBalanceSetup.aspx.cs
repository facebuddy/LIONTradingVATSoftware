using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class PartyBalanceSetup : Page, IRequiresSessionState
    {
      

 


        private TransPartyBLL objTransParty = new TransPartyBLL();

        private ChallanBLL objBllobjBLL = new ChallanBLL();

     

        public PartyBalanceSetup()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.refreshAll();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validation())
                {
                    ChallanBLL challanBLL = new ChallanBLL();
                    PurchaseMasterDAO purchaseMasterDAO = new PurchaseMasterDAO();
                    purchaseMasterDAO = this.GetInserMasterValues(purchaseMasterDAO);
                    if (purchaseMasterDAO == null)
                    {
                        this.msgBox.AddMessage("Please insert data properly.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    else if (!challanBLL.InsertPartyOpeningBalance(purchaseMasterDAO))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage("Purchase Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.refreshAll();
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "Purchase_Challan_6.3", "btnSave_Click");
            }
        }

        private PurchaseMasterDAO GetInserMasterValues(PurchaseMasterDAO objMDAO)
        {
            try
            {
                objMDAO.OrganizatioID = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
                objMDAO.Org_branch_reg_id = Convert.ToInt16(this.Session["ORGBRANCHID"].ToString());
                objMDAO.ChallanType = Convert.ToChar(this.drpType.SelectedValue);
                if (objMDAO.ChallanType == 'P')
                {
                    objMDAO.ChallanNo = string.Concat("Payable_opening_", this.drpPartyName.SelectedValue);
                }
                else if (objMDAO.ChallanType == 'R')
                {
                    objMDAO.ChallanNo = string.Concat("Receivable_opening_", this.drpPartyName.SelectedValue);
                }
                if (!string.IsNullOrEmpty(this.txtOpeningDate.Text.Trim()))
                {
                    string[] strArrays = new string[] { this.txtOpeningDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                    objMDAO.ChallanDate = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                objMDAO.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                objMDAO.PartyID = Convert.ToInt16(this.drpPartyName.SelectedItem.Value.ToString());
                if (this.txtRemarks.Text != "")
                {
                    objMDAO.Remarks = this.txtRemarks.Text;
                }
                objMDAO.CreditAmount = Convert.ToDouble(this.txtOpeningBalance.Text);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                objMDAO = null;
            }
            return objMDAO;
        }

        private void GetPartyInfo()
        {
            this.drpPartyName.Items.Clear();
            DataTable organizationWiseParty = this.objTransParty.getOrganizationWiseParty();
            if (organizationWiseParty != null && organizationWiseParty.Rows.Count > 0)
            {
                this.drpPartyName.DataSource = organizationWiseParty;
                this.drpPartyName.DataTextField = organizationWiseParty.Columns["party_name"].ToString();
                this.drpPartyName.DataValueField = organizationWiseParty.Columns["Party_id"].ToString();
                this.drpPartyName.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpPartyName.Items.Insert(0, listItem);
            this.Session["PARTY_INFO"] = organizationWiseParty;
        }

        private void LoadHours()
        {
            this.drpChDtHr.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
            }
        }

        private void LoadMinutes()
        {
            this.drpChDtMin.Items.Add("00");
            for (int i = 1; i <= 59; i++)
            {
                this.drpChDtMin.Items.Add(i.ToString("00"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.GetPartyInfo();
                TextBox str = this.txtOpeningDate;
                DateTime now = DateTime.Now;
                str.Text = now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                this.LoadHours();
                this.LoadMinutes();
                this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
            }
        }

        private void refreshAll()
        {
            this.txtOpeningBalance.Text = "0";
            this.txtOpeningDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.drpType.SelectedValue = "Sl";
            this.drpPartyName.SelectedValue = "-99";
            this.txtRemarks.Text = "";
        }

        private bool validation()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.drpType.SelectedValue == "Sl")
            {
                this.msgBox.AddMessage("Select Type.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.txtOpeningBalance.Text.Length == 0 || this.txtOpeningBalance.Text == "0")
            {
                this.msgBox.AddMessage("Please provide Opening balance.", MsgBoxs.enmMessageType.Info);
                this.txtOpeningBalance.Focus();
                return false;
            }
            if (this.txtOpeningDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please fill Opening Date.", MsgBoxs.enmMessageType.Info);
                this.txtOpeningDate.Focus();
                return false;
            }
            if (this.drpPartyName.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select Party Name.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (challanBLL.CheckPartyOpeningBalance(Convert.ToInt32(this.drpPartyName.SelectedItem.Value.ToString()), this.drpType.SelectedValue) <= 0)
            {
                return true;
            }
            this.msgBox.AddMessage(string.Concat("The party has already ", this.drpType.SelectedItem), MsgBoxs.enmMessageType.Info);
            return false;
        }
    }
}