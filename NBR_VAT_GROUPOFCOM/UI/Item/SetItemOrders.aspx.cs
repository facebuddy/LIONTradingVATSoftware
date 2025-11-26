using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class SetItemOrders : Page, IRequiresSessionState
    {
        private ItemTaxCategoryBLL objITCBLL = new ItemTaxCategoryBLL();

        private ItemTaxValueBLL objITVBLL = new ItemTaxValueBLL();

        private ItemTaxValueDAO objITVDAO = new ItemTaxValueDAO();

        private DBUtility dbUtility = new DBUtility();

    


        public SetItemOrders()
        {
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.setAddMode();
            this.ClearControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validations())
            {
                int num = 0;
                int num1 = 0;
                string empty = string.Empty;
                string str = string.Empty;
                num = Convert.ToInt32(this.ddlItemName.SelectedItem.Value.ToString());
                num1 = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                empty = this.drpBranchName.SelectedItem.Text.ToString();
                str = this.txtOrder.Text.ToString();
                bool flag = this.objITCBLL.UpdateitemOrder(num1, empty, str, num);
                if (flag)
                {
                    this.msgBox.AddMessage("Information saved successfully.", MsgBoxs.enmMessageType.Success);
                    this.LoadGridView();
                    this.ClearControl();
                }
                if (!flag)
                {
                    this.msgBox.AddMessage("InformationFailed to save.", MsgBoxs.enmMessageType.Error);
                }
            }
        }

        protected void btnShowList_Click(object sender, EventArgs e)
        {
            if (this.ddlItemName.SelectedValue == "-99")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Please select a Item Name.');", true);
                this.ddlItemName.Focus();
                return;
            }
            if (this.ddlItemName.Items.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Please select a value from sub Category.');", true);
                this.drpSubCategory.Focus();
            }
            else
            {
                if (this.btnShowList.Text == "Show Item")
                {
                    this.btnShowList.Text = "Hide Item";
                    this.LoadGridView();
                    this.dgvItemSort.Visible = true;
                    return;
                }
                if (this.btnShowList.Text == "Hide Item")
                {
                    this.btnShowList.Text = "Show Item";
                    this.setAddMode();
                    this.dgvItemSort.Visible = false;
                    this.dgvItemSort.DataSource = null;
                    this.dgvItemSort.DataBind();
                    return;
                }
            }
        }

        private void ClearControl()
        {
            this.drpSubCategory.Items.Clear();
            this.ddlCategory.Items.Clear();
            OrganizaitonInfo.fillDDLAllCategoryName(this.ddlCategory);
            this.GetBranchInformation();
            this.LoadItemsWithoutFilter();
            this.txtOrder.Text = "0";
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ddlCategory.SelectedValue != "0")
                {
                    this.drpSubCategory.Items.Clear();
                    this.ddlItemName.Items.Clear();
                    this.LoadItemsSubCategor();
                }
                if (this.ddlCategory.SelectedValue == "0")
                {
                    this.LoadItemsWithoutFilter();
                    this.drpSubCategory.Items.Clear();
                    ListItem listItem = new ListItem("ALL", "0");
                    this.drpSubCategory.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ddlItemName.SelectedValue == "0" || this.ddlItemName.SelectedValue == "-99")
                {
                    this.ddlCategory.Items.Clear();
                    this.LoadItemsWithoutFilter();
                    this.drpSubCategory.Items.Clear();
                    OrganizaitonInfo.fillDDLAllCategoryName(this.ddlCategory);
                }
                else
                {
                    this.showCatSubCat();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void dgvItemSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvItemSort.PageIndex = e.NewPageIndex;
            this.dgvItemSort.DataBind();
            this.LoadGridView();
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ddlItemName.Items.Clear();
                this.LoadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
                        this.drpBranchName.Items.Insert(0, listItem);
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

        private void LoadGridView()
        {
            if (this.ddlItemName.SelectedItem.Value.ToString() == "0")
            {
                DataSet dataSet = this.objITCBLL.LoadItemWithOrder();
                this.dgvItemSort.DataSource = dataSet;
                this.dgvItemSort.DataBind();
                return;
            }
            DataSet dataSet1 = this.objITCBLL.LoadItemWithOrderWithParam(Convert.ToInt32(this.ddlItemName.SelectedItem.Value.ToString()));
            this.dgvItemSort.DataSource = dataSet1;
            this.dgvItemSort.DataBind();
        }

        private void LoadItems()
        {
            this.ddlItemName.Items.Clear();
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
            DataTable allItemByCategory = addItemBLL.getAllItemByCategory(num);
            this.ddlItemName.DataSource = allItemByCategory;
            this.ddlItemName.DataTextField = allItemByCategory.Columns["ITEM_NAME"].ToString();
            this.ddlItemName.DataValueField = allItemByCategory.Columns["ITEM_ID"].ToString();
            this.ddlItemName.DataBind();
            ListItem listItem = new ListItem("ALL", "0");
            this.ddlItemName.Items.Insert(0, listItem);
        }

        private void LoadItems1()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
            DataTable allItemByCategory = addItemBLL.getAllItemByCategory(num);
            this.ddlItemName.DataSource = allItemByCategory;
            this.ddlItemName.DataTextField = allItemByCategory.Columns["ITEM_NAME"].ToString();
            this.ddlItemName.DataValueField = allItemByCategory.Columns["ITEM_ID"].ToString();
            this.ddlItemName.DataBind();
            ListItem listItem = new ListItem("ALL", "0");
            this.ddlItemName.Items.Insert(0, listItem);
        }

        private void LoadItemsSubCategor()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = Convert.ToInt32(this.ddlCategory.SelectedValue);
            if (this.ddlCategory.SelectedValue == "0")
            {
                ListItem listItem = new ListItem("ALL", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("ALL", "-99");
                this.ddlItemName.Items.Insert(0, listItem);
                return;
            }
            DataTable allISubCategory = addItemBLL.getAllISubCategory(num);
            this.drpSubCategory.DataSource = allISubCategory;
            this.drpSubCategory.DataTextField = allISubCategory.Columns["category_name"].ToString();
            this.drpSubCategory.DataValueField = allISubCategory.Columns["category_id"].ToString();
            this.drpSubCategory.DataBind();
            ListItem listItem2 = new ListItem("----SELECT----", "-0");
            this.drpSubCategory.Items.Insert(0, listItem2);
        }

        private void LoadItemsWithoutFilter()
        {
            this.ddlItemName.Items.Clear();
            DataTable allItemByCategoryWithoutFilter = (new AddItemBLL()).getAllItemByCategoryWithoutFilter();
            this.ddlItemName.DataSource = allItemByCategoryWithoutFilter;
            this.ddlItemName.DataTextField = allItemByCategoryWithoutFilter.Columns["ITEM_NAME"].ToString();
            this.ddlItemName.DataValueField = allItemByCategoryWithoutFilter.Columns["ITEM_ID"].ToString();
            this.ddlItemName.DataBind();
            ListItem listItem = new ListItem("ALL", "0");
            this.ddlItemName.Items.Insert(0, listItem);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                OrganizaitonInfo.fillDDLAllCategoryName(this.ddlCategory);
                if (this.ddlCategory.Items.Count > 0)
                {
                    this.LoadItemsWithoutFilter();
                    this.GetBranchInformation();
                }
            }
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        private void showCatSubCat()
        {
            SaleBLL saleBLL = new SaleBLL();
            try
            {
                int num = Convert.ToInt32(this.ddlItemName.SelectedValue);
                DataTable catSubCat = saleBLL.getCatSubCat(num);
                if (catSubCat != null)
                {
                    this.ddlCategory.DataSource = catSubCat;
                    this.ddlCategory.DataTextField = catSubCat.Columns["category_name"].ToString();
                    this.ddlCategory.DataValueField = catSubCat.Columns["category_id"].ToString();
                    this.ddlCategory.DataBind();
                    this.drpSubCategory.DataSource = catSubCat;
                    this.drpSubCategory.DataTextField = catSubCat.Columns["sub_category_name"].ToString();
                    this.drpSubCategory.DataValueField = catSubCat.Columns["sub_category_id"].ToString();
                    this.drpSubCategory.DataBind();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private bool Validations()
        {
            if (this.ddlCategory.SelectedValue == "-99" || this.ddlCategory.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Please select a Category first", MsgBoxs.enmMessageType.Info);
                this.ddlCategory.Focus();
                return false;
            }
            if (this.ddlItemName.SelectedValue == "-99" || this.ddlItemName.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Please select a Category first", MsgBoxs.enmMessageType.Info);
                this.ddlItemName.Focus();
                return false;
            }
            if (this.txtOrder.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert order first.", MsgBoxs.enmMessageType.Info);
                this.txtOrder.Focus();
                return false;
            }
            if (this.txtOrder.Text != "0")
            {
                return true;
            }
            this.msgBox.AddMessage("Please insert order first.", MsgBoxs.enmMessageType.Info);
            this.txtOrder.Focus();
            return false;
        }
    }
}