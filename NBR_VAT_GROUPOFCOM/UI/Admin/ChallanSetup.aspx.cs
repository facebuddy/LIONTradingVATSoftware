using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class ChallanSetup : Page, IRequiresSessionState
    {
        private NBR_VAT_GROUPOFCOM.BLL.ChallanBLL objBLL = new NBR_VAT_GROUPOFCOM.BLL.ChallanBLL();

        private int fixedDigit;

      

        public ChallanSetup()
        {
        }

        protected void btnFiscalYear_Click(object sender, EventArgs e)
        {
            ChallanBLL challanBLL = new ChallanBLL();
            SetFiscalYearDAO setFiscalYearDAO = new SetFiscalYearDAO()
            {
                FiscalYear = this.lblFiscalYear.Text.ToString()
            };
            DateTime dateTime = DateTime.ParseExact(this.txtFromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            setFiscalYearDAO.FromDate = dateTime.ToString("dd/MM/yyyy");
            DateTime dateTime1 = DateTime.ParseExact(this.txtToDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            setFiscalYearDAO.ToDate = dateTime1.ToString("dd/MM/yyyy");
            if (challanBLL.saveFiscalData(setFiscalYearDAO))
            {
                this.msgBox.AddMessage("Fiscal Year Data Successfully Saved.", MsgBoxs.enmMessageType.Success);
                return;
            }
            this.msgBox.AddMessage(" This Fiscal Year is Exists. Please try later ", MsgBoxs.enmMessageType.Attention);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                NBR_VAT_GROUPOFCOM.BLL.ChallanNoMasterDAO challanNoMasterDAO = this.fillChallanNoMasterData();
                ArrayList arrayLists = this.fillChallanNoDetailData();
                ArrayList item = (ArrayList)this.Session["ChallanDet"];
                if (this.btnSave.Text == "Save")
                {
                    if (this.objBLL.InsertChallanNo(challanNoMasterDAO, arrayLists, item))
                    {
                        this.clearFrom();
                        this.drpChallanType_selectedIndexChanged(null, null);
                        this.msgBox.AddMessage("Challan No Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        return;
                    }
                    this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShowChallanBookDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvChallanBook.Visible)
                {
                    this.gvChallanBook.Visible = false;
                }
                ChallanBLL challanBLL = new ChallanBLL();
                DataTable dataTable = new DataTable();
                short num = Convert.ToInt16(this.drpChallanType.SelectedValue);
                string str = Utilities.ReplaceQuotes(this.txtBookNo.Text.Trim());
                int num1 = Convert.ToInt16(this.Session["ORGBRANCHID"]);
                int num2 = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                dataTable = challanBLL.GetChallanNoInfo(num2, num, str, num1);
                this.dgvChallanNo.DataSource = dataTable;
                this.dgvChallanNo.DataBind();
                this.gvBookDetail.DataSource = null;
                this.gvBookDetail.DataBind();
            }
            catch
            {
            }
        }

        private string changeChallanNoFormat(int digitMax, string challlaNo)
        {
            string str = "";
            if (digitMax >= 1)
            {
                for (int i = 0; i < digitMax - challlaNo.Length; i++)
                {
                    str = string.Concat(str, "0");
                }
                str = string.Concat(str, challlaNo);
            }
            else
            {
                str = challlaNo;
            }
            return str;
        }

        private void clearFrom()
        {
            this.Session["ChallanDet"] = new ArrayList();
            this.chkIsAppAllBranch.Checked = false;
            this.drpChallanType.SelectedValue = "-99";
            this.drpBranch.SelectedValue = "0";
            this.txtBookNo.Text = "";
            this.txtPageFrom.Text = "";
            this.txtPageTo.Text = "";
            this.txtPrefix.Text = "";
            this.fillChallanYearDrp();
            this.dgvChallanNo.DataSource = null;
            this.dgvChallanNo.DataBind();
            this.btnSave.Text = "Save";
            this.setAddMode();
            this.gvBookDetail.DataSource = null;
            this.gvBookDetail.DataBind();
        }

        protected void dgvDistrict_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton imageButton = control as ImageButton;
                        if (imageButton == null || !(imageButton.CommandName == "Delete"))
                        {
                            continue;
                        }
                        if (e.Row.Cells[2].Text != "True")
                        {
                            imageButton.Enabled = true;
                            imageButton.OnClientClick = "if (!confirm('Are you sure you want to discard this page?')) return;";
                        }
                        else
                        {
                            imageButton.Enabled = false;
                        }
                    }
                }
            }
        }

        protected void dgvDistrict_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void dgvDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.dgvChallanNo.SelectedDataKey["challan_book_id"]);
            DataTable challanBookDetailByBookID = (new ChallanBLL()).GetChallanBookDetailByBookID(num);
            this.gvBookDetail.DataSource = challanBookDetailByBookID;
            this.gvBookDetail.DataBind();
        }

        protected void digitCheckChanged(object sender, EventArgs e)
        {
            if (this.digitCheck.Checked)
            {
                this.digitNumber.Visible = true;
                return;
            }
            if (!this.digitCheck.Checked)
            {
                this.digitNumber.Visible = false;
                this.fixedDigit = 0;
            }
        }

        protected void drpChallanType_selectedIndexChanged(object sender, EventArgs e)
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.drpChallanType.SelectedValue != null && this.drpChallanType.SelectedValue != "-99")
            {
                short num = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                this.drpChallanType.SelectedItem.ToString();
                short num1 = Convert.ToInt16(this.drpChallanType.SelectedValue);
                short num2 = Convert.ToInt16(this.drpBranch.SelectedValue);
                DataTable challanBookNumber = challanBLL.getChallanBookNumber(num1, num, num2);
                if (challanBookNumber != null)
                {
                    this.gvChallanBook.DataSource = challanBookNumber;
                    this.gvChallanBook.DataBind();
                }
            }
        }

        private void fillChallanBookType()
        {
            DataTable challanBookType = this.objBLL.getChallanBookType();
            if (challanBookType != null && challanBookType.Rows.Count > 0)
            {
                this.drpChallanType.DataSource = challanBookType;
                this.drpChallanType.DataValueField = challanBookType.Columns["code_id_d"].ToString();
                this.drpChallanType.DataTextField = challanBookType.Columns["code_name"].ToString();
                this.drpChallanType.DataBind();
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpChallanType.Items.Insert(0, listItem);
        }

        private ArrayList fillChallanNoDetailData()
        {
            ArrayList arrayLists;
            ArrayList arrayLists1 = new ArrayList();
            try
            {
                int num = Convert.ToInt32(this.txtPageFrom.Text);
                int num1 = Convert.ToInt32(this.txtPageTo.Text);
                string str = this.txtBookNo.Text.Trim();
                string str1 = this.drpChallanYear.SelectedItem.Text.Substring(2);
                int num2 = Convert.ToInt32(this.drpBranch.SelectedValue);
                for (int i = num; i <= num1; i++)
                {
                   NBR_VAT_GROUPOFCOM.BLL.ChallanNoDetailDAO challanNoDetailDAO = new NBR_VAT_GROUPOFCOM.BLL.ChallanNoDetailDAO()
                    {
                        PageNo = i,
                        BranchID = num2
                    };
                    if (this.txtPrefix.Text == "")
                    {
                        object[] objArray = new object[] { num2, str, str1, "-", this.changeChallanNoFormat(this.fixedDigit, i.ToString()) };
                        challanNoDetailDAO.ChallanNo = string.Concat(objArray);
                    }
                    else
                    {
                        string text = this.txtPrefix.Text;
                        object[] objArray1 = new object[] { text, num2, str, str1, "-", this.changeChallanNoFormat(this.fixedDigit, i.ToString()) };
                        challanNoDetailDAO.ChallanNo = string.Concat(objArray1);
                    }
                    challanNoDetailDAO.ChallanType = Convert.ToInt16(this.drpChallanType.SelectedValue);
                    arrayLists1.Add(challanNoDetailDAO);
                }
                return arrayLists1;
            }
            catch
            {
                arrayLists = null;
            }
            return arrayLists;
        }

        private NBR_VAT_GROUPOFCOM.BLL.ChallanNoMasterDAO fillChallanNoMasterData()
        {
            NBR_VAT_GROUPOFCOM.BLL.ChallanNoMasterDAO challanNoMasterDAO = new NBR_VAT_GROUPOFCOM.BLL.ChallanNoMasterDAO();
            ArrayList arrayLists = new ArrayList();
            try
            {
                challanNoMasterDAO.ChallanBookNo = Utilities.ReplaceQuotes(this.txtBookNo.Text.Trim());
                challanNoMasterDAO.ChallanType = Convert.ToInt16(this.drpChallanType.SelectedValue);
                challanNoMasterDAO.ChallanYear = Convert.ToInt16(this.drpChallanYear.SelectedValue);
                DateTime today = DateTime.Today;
                challanNoMasterDAO.currentChallanYear = Convert.ToInt16(today.ToString("yyyy"));
                challanNoMasterDAO.PageFrom = Convert.ToInt16(this.txtPageFrom.Text);
                challanNoMasterDAO.PageTo = Convert.ToInt16(this.txtPageTo.Text);
                challanNoMasterDAO.OrganizationID = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                challanNoMasterDAO.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                challanNoMasterDAO.BranchID = Convert.ToInt16(this.drpBranch.SelectedValue);
                challanNoMasterDAO.IsApplicableAllBrnch = this.chkIsAppAllBranch.Checked;
                int num = 0;
                int challanYear = challanNoMasterDAO.ChallanYear - 1;
                if (challanNoMasterDAO.ChallanYear != challanNoMasterDAO.currentChallanYear)
                {
                    DataTable challanBookID = this.objBLL.getChallanBookID(challanNoMasterDAO.ChallanType, challanYear);
                    if (challanBookID.Rows.Count > 0)
                    {
                        for (int i = 0; i < challanBookID.Rows.Count; i++)
                        {
                            num = Convert.ToInt32(challanBookID.Rows[i]["challan_book_id"]);
                            arrayLists.Add(num);
                        }
                    }
                    this.Session["ChallanDet"] = arrayLists;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return challanNoMasterDAO;
        }

        private void fillChallanYearDrp()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Text");
            dataTable.Columns.Add("Value");
            DataRowCollection rows = dataTable.Rows;
            object[] objArray = new object[] { string.Concat(year - 1, "-", year.ToString()), year };
            rows.Add(objArray);
            DataRowCollection dataRowCollection = dataTable.Rows;
            object[] objArray1 = new object[2];
            int num = year + 1;
            objArray1[0] = string.Concat(year, "-", num.ToString());
            objArray1[1] = year + 1;
            dataRowCollection.Add(objArray1);
            DataRowCollection rows1 = dataTable.Rows;
            object[] objArray2 = new object[2];
            int num1 = year + 2;
            objArray2[0] = string.Concat(year + 1, "-", num1.ToString());
            objArray2[1] = year + 2;
            rows1.Add(objArray2);
            DataRowCollection dataRowCollection1 = dataTable.Rows;
            object[] objArray3 = new object[2];
            int num2 = year + 3;
            objArray3[0] = string.Concat(year + 2, "-", num2.ToString());
            objArray3[1] = year + 3;
            dataRowCollection1.Add(objArray3);
            this.drpChallanYear.DataSource = dataTable;
            this.drpChallanYear.DataTextField = "Text";
            this.drpChallanYear.DataValueField = "Value";
            this.drpChallanYear.DataBind();
            if (month > 6)
            {
                this.drpChallanYear.SelectedValue = (year + 1).ToString();
            }
        }

        private void fillFiscalYear()
        {
            int year;
            int num;
            string str;
            string str1;
            if (DateTime.Today.Month >= 7)
            {
                year = DateTime.Today.Year;
                num = DateTime.Today.Year + 1;
                int month = DateTime.Today.Month;
                int day = DateTime.Today.Day;
                str = string.Concat("01/07/", year.ToString());
                str1 = string.Concat("30/06/", num.ToString());
            }
            else
            {
                year = DateTime.Today.Year - 1;
                num = DateTime.Today.Year;
                int month1 = DateTime.Today.Month;
                int day1 = DateTime.Today.Day;
                str = string.Concat("01/07/", year.ToString());
                str1 = string.Concat("30/06/", num.ToString());
            }
            this.txtFromDate.Text = str;
            this.txtToDate.Text = str1;
            this.lblFiscalYear.Text = string.Concat(year.ToString(), "-", num.ToString());
        }

        private SetDistrictDAO insertUnionWard(SetDistrictDAO objSetDistrictDAO)
        {
            objSetDistrictDAO.DistrictName = this.txtBookNo.Text.Trim();
            objSetDistrictDAO.DivisionId = Convert.ToInt16(this.drpChallanType.SelectedValue);
            return objSetDistrictDAO;
        }

        private void loadBranch()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            try
            {
                int num = Convert.ToInt32(this.Session["empId"].ToString());
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
                if (Utilities.GetMasterOrgInfo()[1] != "S")
                {
                    DataTable selectedBusinessUnitBranchInfobyEmployee = challanBLL.GetSelectedBusinessUnitBranchInfobyEmployee(num1, num);
                    if (selectedBusinessUnitBranchInfobyEmployee.Rows.Count > 0)
                    {
                        this.drpBranch.DataSource = selectedBusinessUnitBranchInfobyEmployee;
                        this.drpBranch.DataTextField = selectedBusinessUnitBranchInfobyEmployee.Columns["branch_unit_name"].ToString();
                        this.drpBranch.DataValueField = selectedBusinessUnitBranchInfobyEmployee.Columns["org_branch_reg_id"].ToString();
                        this.drpBranch.DataBind();
                    }
                }
                else
                {
                    DataTable dataTable = challanBLL.loadOrgBranch(num1);
                    if (dataTable.Rows.Count > 0)
                    {
                        this.drpBranch.DataSource = dataTable;
                        this.drpBranch.DataTextField = dataTable.Columns["branch_unit_name"].ToString();
                        this.drpBranch.DataValueField = dataTable.Columns["org_branch_reg_id"].ToString();
                        this.drpBranch.DataBind();
                    }
                }
                ListItem listItem = new ListItem("--SELECT--", "0");
                this.drpBranch.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.Session["ChallanDet"] = new ArrayList();
                this.fillChallanBookType();
                this.fillChallanYearDrp();
                this.fillFiscalYear();
                this.loadBranch();
            }
        }

        private void RefreshGridView()
        {
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        private bool Validation()
        {
            bool flag;
            try
            {
                if (this.drpChallanType.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage("Select a challan type.", MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.drpBranch.SelectedValue == "0")
                {
                    this.msgBox.AddMessage("Select Organization Branch.", MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.txtBookNo.Text.Length == 0)
                {
                    this.msgBox.AddMessage("Book No is mandatory.", MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.txtPageFrom.Text.Length == 0)
                {
                    this.msgBox.AddMessage("Page No is mandatory.", MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.txtPageTo.Text.Length == 0)
                {
                    this.msgBox.AddMessage("Page No is mandatory.", MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.digitNumber.Text.Length <= 0 || !(Convert.ToDecimal(this.digitNumber.Text) > new decimal(10)))
                {
                    int num = Convert.ToInt16(this.drpChallanType.SelectedValue);
                    int num1 = Convert.ToInt32(this.drpChallanYear.SelectedValue);
                    DataTable dataTable = new DataTable();
                    dataTable = (!this.chkIsAppAllBranch.Checked ? this.objBLL.getMaxChallanPageNOrg(num, num1) : this.objBLL.getMaxChallanPageNo(num, num1));
                    if (dataTable.Rows.Count > 0)
                    {
                        int num2 = Convert.ToInt32(dataTable.Rows[0]["page_no"]);
                        int num3 = Convert.ToInt32(dataTable.Rows[0]["challan_book_no"]);
                        int num4 = num2 + 1;
                        int num5 = num3 + 1;
                        if (Convert.ToInt32(this.txtBookNo.Text) <= num3)
                        {
                            this.msgBox.AddMessage(string.Concat("Challan Book No. is already existed. New Book No. will start from ", num5), MsgBoxs.enmMessageType.Attention);
                            flag = false;
                            return flag;
                        }
                        else if (Convert.ToInt32(this.txtBookNo.Text) != num5)
                        {
                            this.msgBox.AddMessage(string.Concat("Challan Book No. must be started from ", num5), MsgBoxs.enmMessageType.Attention);
                            flag = false;
                            return flag;
                        }
                        else if (Convert.ToInt32(this.txtPageFrom.Text) <= num2)
                        {
                            this.msgBox.AddMessage(string.Concat("Page No. is already existed. New Page No. will start from ", num4), MsgBoxs.enmMessageType.Attention);
                            flag = false;
                            return flag;
                        }
                        else if (Convert.ToInt32(this.txtPageFrom.Text) != num4)
                        {
                            this.msgBox.AddMessage(string.Concat("Page From. must be started from ", num4), MsgBoxs.enmMessageType.Attention);
                            flag = false;
                            return flag;
                        }
                    }
                    int num6 = Convert.ToInt32(this.txtPageFrom.Text);
                    if (Convert.ToInt32(this.txtPageTo.Text) >= num6)
                    {
                        try
                        {
                            Convert.ToInt32(this.txtPageFrom.Text);
                            Convert.ToInt32(this.txtPageTo.Text);
                        }
                        catch
                        {
                            this.msgBox.AddMessage("Page No must be numeric.", MsgBoxs.enmMessageType.Attention);
                            flag = false;
                            return flag;
                        }
                        if (this.digitCheck.Checked && this.digitNumber.Text != "")
                        {
                            int num7 = Convert.ToInt32(this.digitNumber.Text);
                            if (this.txtPageTo.Text.Length <= num7)
                            {
                                this.fixedDigit = num7;
                            }
                            else
                            {
                                this.msgBox.AddMessage("Last page no digit is greater than required formatted digits", MsgBoxs.enmMessageType.Attention);
                            }
                        }
                        return true;
                    }
                    else
                    {
                        this.msgBox.AddMessage("Page To must be greater than Page From.", MsgBoxs.enmMessageType.Attention);
                        flag = false;
                    }
                }
                else
                {
                    this.msgBox.AddMessage("Page digit no can not be greater than 10", MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
    }
}