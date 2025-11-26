using AjaxControlToolkit;
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
using Westwind.Web.Controls;


namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class PriceDeclarationTD : Page, IRequiresSessionState
    {
      

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        private PriceDeclaretionDAO objPDDao = new PriceDeclaretionDAO();

        private PriceDeclaretionRawDAO objPDRDao = new PriceDeclaretionRawDAO();

        private PriceDeclaretionValueAdditionDAO objPDVADao = new PriceDeclaretionValueAdditionDAO();

        private SetItemBLL objSIBll = new SetItemBLL();

        private int itemRowNo = 10;

        private decimal decValueAdditionTotal;

        private DataTable dt = new DataTable();

        private DataColumn dc = new DataColumn();

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

        public PriceDeclarationTD()
        {
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.lblPriceId.Text.Trim());
            decimal num1 = Convert.ToDecimal(this.txtNBRSDChargablePrice.Text.Trim());
            decimal num2 = Convert.ToDecimal(this.txtNBRSD.Text.Trim());
            decimal num3 = Convert.ToDecimal(this.txtNBRVATChargeablePrice.Text.Trim());
            decimal num4 = Convert.ToDecimal(this.txtNBRWholeSalePrice.Text.Trim());
            decimal num5 = Convert.ToDecimal(this.txtNBRRetailPrice.Text.Trim());
            string str = this.dtpNBRApproveDate.Text.ToString();
            DateTime formattedDateMMDDYYYY = BLL.Utility.GetFormattedDateMMDDYYYY(str);
            decimal num6 = Convert.ToDecimal(this.txtNBRPrice.Text.Trim());
            this.objPDDao.intPriceID = Convert.ToInt32(this.lblPriceId.Text.Trim());
            if (!this.objPDBll.updatePrice(num, num1, num2, num3, num4, num5, formattedDateMMDDYYYY, num6))
            {
                this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
                return;
            }
            this.msgBox.AddMessage("Item Price Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
            this.showDataInGridView();
            this.setAddMode();
            this.clearFrom();
            for (int i = 0; i < this.gvNBRValueAddition.Rows.Count; i++)
            {
                int num7 = Convert.ToInt32(this.lblPriceId.Text);
                decimal num8 = Convert.ToDecimal(((TextBox)this.gvNBRValueAddition.Rows[i].FindControl("txtValueAddition0")).Text.ToString());
                this.objPDBll.updatePDValueAdd(num7, num8, 1);
            }
        }

        protected void btnApprovePrice_Click(object sender, EventArgs e)
        {
            this.dtpNBRApproveDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            if (this.ddlPriceDeclarationNo.Items.Count > 0)
            {
                int num = Convert.ToInt32(this.ddlPriceDeclarationNo.SelectedItem.Value.ToString());
                DataSet priceByDeclarationId = this.objPDBll.getPriceByDeclarationId(num);
                int num1 = this.objPDBll.intTaxValueByItemPrice(num);
                if (priceByDeclarationId != null)
                {
                    this.lblPriceId.Text = priceByDeclarationId.Tables[0].Rows[0]["price_id"].ToString();
                    this.lblPriceDeclarationNo.Text = priceByDeclarationId.Tables[0].Rows[0]["price_declaration_no"].ToString();
                    this.lblPrice.Text = priceByDeclarationId.Tables[0].Rows[0]["prpsd_actl_prc"].ToString();
                    this.lblNBRSDChargablePrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_actl_prc_sd"].ToString();
                    this.lblNBRSD.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_sd_amount"].ToString();
                    this.lblNBRVATChargeablePrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_actl_prc_vat"].ToString();
                    this.lblNBRWholeSalePrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_wholesale_prc"].ToString();
                    this.lblNBRRetailPrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_retail_prc"].ToString();
                    this.txtNBRPrice.Text = priceByDeclarationId.Tables[0].Rows[0]["prpsd_actl_prc"].ToString();
                    this.txtNBRSDChargablePrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_actl_prc_sd"].ToString();
                    this.txtNBRSD.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_sd_amount"].ToString();
                    this.txtNBRVATChargeablePrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_actl_prc_vat"].ToString();
                    this.txtNBRWholeSalePrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_wholesale_prc"].ToString();
                    this.txtNBRRetailPrice.Text = priceByDeclarationId.Tables[0].Rows[0]["cnfrmd_retail_prc"].ToString();
                    this.hfNBRPrice.Value = priceByDeclarationId.Tables[0].Rows[0]["actual_price"].ToString();
                    this.hfNBRSD.Value = num1.ToString();
                    this.hfPriceId.Value = priceByDeclarationId.Tables[0].Rows[0]["price_id"].ToString();
                }
                this.showNBRValueAdditionDataInGridView(num);
            }
            this.modalPopupForApprovePrice.Show();
        }

        protected void btnClearAllRawItem_Click(object sender, EventArgs e)
        {
            this.Session["dtInSession"] = null;
            this.clearRawItem();
        }

        protected void btnRawItemSave_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (this.dt.Columns.Count == 0)
            {
                this.dt.Columns.Add("row_id", typeof(int));
                this.dt.Columns.Add("item_id", typeof(string));
                this.dt.Columns.Add("item_name", typeof(string));
                this.dt.Columns.Add("price", typeof(decimal));
                this.dt.Columns.Add("quantity", typeof(decimal));
                this.dt.Columns.Add("depreciation", typeof(decimal));
            }
            if (this.Session["dtInSession"] != null)
            {
                this.dt = (DataTable)this.Session["dtInSession"];
            }
        }

        protected void btnRefreshChallan1_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnRefreshItem_Click(object sender, EventArgs e)
        {
        }

        protected void btnRefreshRawItem_Click(object sender, EventArgs e)
        {
            this.clearRawItem();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validation())
            {
                this.Session["PriceId"] = this.objPDBll.intPDId();
                this.objPDDao = this.insertPriceDeclaration(this.objPDDao);
                if (this.btnSave.Text == "Save Declaretion")
                {
                    if (!this.objPDBll.InsertPD(this.objPDDao))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        if (this.gvValueAddition.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.gvValueAddition.Rows.Count; i++)
                            {
                                int item = (int)this.Session["PriceId"];
                                Convert.ToInt32(((Label)this.gvValueAddition.Rows[i].FindControl("lblID")).Text);
                                decimal num = Convert.ToDecimal(((TextBox)this.gvValueAddition.Rows[i].FindControl("txtValueAddition")).Text.ToString());
                                bool flag = num > new decimal(0);
                            }
                        }
                        this.clearFrom();
                        this.msgBox.AddMessage("Item Price Declaration Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    }
                }
            }
            BLL.Utility.fillAllPriceDeclarationNo(this.ddlPriceDeclarationNo);
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
        }

        protected void btnSubClear_Click(object sender, EventArgs e)
        {
        }

        private void clearFrom()
        {
            this.btnSave.Text = "Save Declaretion";
            this.setAddMode();
            this.showDataInGridView();
            this.clearRawItem();
            this.Session["dtInSession"] = null;
            this.Session["ProposedSDChargablePrice"] = 0;
            this.Session["ProposedVATChargablePrice"] = 0;
            this.Session["PriceId"] = 0;
            OrganizaitonInfo.fillAllOrganizaiton(this.ddlOrganization);
            ListItem listItem = new ListItem("-- Select ---", "-99");
            this.ddlOrganization.Items.Insert(0, listItem);
            BLL.Utility.fillYearList(this.ddlYear);
            BLL.Utility.fillAllItemCategory(this.ddlItemCategory);
            ListItem listItem1 = new ListItem("-- Select ---", "-99");
            this.ddlItemCategory.Items.Insert(0, listItem1);
            if (this.ddlItemCategory.Items.Count > 0)
            {
                BLL.Utility.fillAllItemByCategory(this.ddlItem, Convert.ToInt32(this.ddlItemCategory.SelectedValue.ToString()));
                ListItem listItem2 = new ListItem("-- Select ---", "-99");
                this.ddlItem.Items.Insert(0, listItem2);
            }
            this.txtCurrentSDPrice.Text = "0";
            this.txtCurrentVATPrice.Text = "0";
            this.txtPriceDeclaretionNo.Text = "0";
            this.txtProposedSDPrice.Text = "0";
            this.txtProposedVATPrice.Text = "0";
            this.txtWholeSalePrice.Text = "0";
            this.txtRetailPrice.Text = "0";
            this.txtSD.Text = "0";
            this.txtPurchasePrice.Text = "0";
            this.lblUnit.Text = "";
            this.lblHSCode.Text = "";
            this.txtSDRate.Text = "0";
            this.txtVATRate.Text = "0";
            this.txtTotalExpenses.Text = "0.00";
            if (this.gvValueAddition.Rows != null)
            {
                for (int i = 0; i < this.gvValueAddition.Rows.Count; i++)
                {
                    ((Label)this.gvValueAddition.Rows[i].FindControl("lblID")).Text = "0.00";
                    ((TextBox)this.gvValueAddition.Rows[i].FindControl("txtValueAddition")).Text = "0.00";
                }
            }
        }

        private void clearRawItem()
        {
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtSDRate.Text = "0";
            DataSet itemDetail = this.objPDBll.getItemDetail(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
            if (itemDetail.Tables[0].Rows.Count <= 0)
            {
                this.lblHSCode.Text = "";
                this.lblUnit.Text = "";
            }
            else
            {
                this.lblHSCode.Text = itemDetail.Tables[0].Rows[0]["hs_code"].ToString();
                this.lblUnit.Text = this.objPDBll.strItemUnitName(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString())).ToString();
            }
            this.GetPriceInfo();
        }

        protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.Utility.fillAllItemByCategory(this.ddlItem, Convert.ToInt32(this.ddlItemCategory.SelectedValue.ToString()));
            ListItem listItem = new ListItem("-- Select ---", "-99");
            this.ddlItem.Items.Insert(0, listItem);
            if (this.ddlItem.SelectedItem.Value.ToString() != "-99")
            {
                DataSet itemDetail = this.objPDBll.getItemDetail(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
                if (itemDetail.Tables[0].Rows.Count > 0)
                {
                    this.lblHSCode.Text = itemDetail.Tables[0].Rows[0]["hs_code"].ToString();
                    this.lblUnit.Text = this.objPDBll.strItemUnitName(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString())).ToString();
                    return;
                }
                this.lblHSCode.Text = "";
                this.lblUnit.Text = "";
            }
        }

        protected void ddlPriceDeclarationNo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList dropDownList = (DropDownList)namingContainer.FindControl("drpCategory");
            DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("drpItemName");
            Label label = (Label)namingContainer.FindControl("lblItemUnitId");
            Label str = (Label)namingContainer.FindControl("lblItemUnit");
            TextBox textBox = (TextBox)namingContainer.FindControl("txtItemQuantity");
            DropDownList dropDownList2 = (DropDownList)namingContainer.FindControl("ddlUnit");
            TextBox textBox1 = (TextBox)namingContainer.FindControl("txtPrice");
            TextBox textBox2 = (TextBox)namingContainer.FindControl("txtWastage");
            if (dropDownList.SelectedValue.ToString() != "-99")
            {
                int num = Convert.ToInt32(dropDownList.SelectedValue);
                BLL.Utility.fillAllItemByCategory(dropDownList1, num);
                ListItem listItem = new ListItem("-- Select ---", "-99");
                dropDownList1.Items.Insert(0, listItem);
                if (dropDownList1.Items.Count <= 0)
                {
                    str.Text = "No Item";
                }
                else
                {
                    str.Text = this.objPDBll.strItemUnitName(Convert.ToInt32(dropDownList1.SelectedItem.Value.ToString())).ToString();
                }
                BLL.Utility.fillAllUnit(dropDownList2);
            }
        }

        protected void drpItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList str = (DropDownList)namingContainer.FindControl("drpCategory");
            DropDownList dropDownList = (DropDownList)namingContainer.FindControl("drpItemName");
            Label label = (Label)namingContainer.FindControl("lblItemUnitId");
            Label label1 = (Label)namingContainer.FindControl("lblItemUnit");
            TextBox textBox = (TextBox)namingContainer.FindControl("txtItemQuantity");
            DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("ddlUnit");
            TextBox textBox1 = (TextBox)namingContainer.FindControl("txtPrice");
            TextBox textBox2 = (TextBox)namingContainer.FindControl("txtWastage");
            if (dropDownList.SelectedValue.ToString() != "-99")
            {
                int itemCategoryId = this.objSIBll.getItemCategoryId(Convert.ToInt32(dropDownList.SelectedItem.Value.ToString()));
                str.SelectedValue = itemCategoryId.ToString();
                BLL.Utility.fillAllUnit(dropDownList1);
            }
        }

        private void GetPriceInfo()
        {
            try
            {
                SaleDetailDAO saleDetailDAO = new SaleDetailDAO()
                {
                    ItemID = Convert.ToInt32(this.ddlItem.SelectedValue)
                };
                if (saleDetailDAO.ItemID != -99)
                {
                    DataTable priceInfoOfItem = (new SaleBLL()).GetPriceInfoOfItem(saleDetailDAO);
                    if (priceInfoOfItem == null || priceInfoOfItem.Rows.Count <= 0)
                    {
                        this.txtSDRate.Text = "0";
                        this.txtVATRate.Text = "0";
                    }
                    else
                    {
                        this.txtSDRate.Text = priceInfoOfItem.Rows[0]["SD_RATE"].ToString();
                        this.txtVATRate.Text = priceInfoOfItem.Rows[0]["VAT_RATE"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvValueAddition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox textBox = (TextBox)e.Row.FindControl("txtValueAddition");
                this.decValueAdditionTotal += Convert.ToDecimal(textBox.Text.ToString());
                decimal num = Convert.ToDecimal(this.Session["ProposedVATChargablePrice"]) + this.decValueAdditionTotal;
                this.Session["ProposedVATChargablePrice"] = num;
                this.txtProposedVATPrice.Text = this.Session["ProposedVATChargablePrice"].ToString();
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label str = (Label)e.Row.FindControl("lblTotalValueAddition");
                str.Text = this.Session["ProposedVATChargablePrice"].ToString();
            }
        }

        private PriceDeclaretionDAO insertPriceDeclaration(PriceDeclaretionDAO objPDDAO)
        {
            objPDDAO.intPriceID = (int)this.Session["PriceId"];
            objPDDAO.intOrganizationID = Convert.ToInt32(this.ddlOrganization.SelectedItem.Value.ToString());
            objPDDAO.strPriceDeclaretionNo = BLL.Utility.ReplaceQuotes(this.txtPriceDeclaretionNo.Text);
            objPDDAO.intPriceDeclaretionYear = Convert.ToInt32(this.ddlYear.SelectedItem.Value.ToString());
            DateTime value = this.dtpActiveDate.SelectedDate.Value;
            objPDDAO.dtActiveDate = BLL.Utility.GetFormattedDateMMDDYYYY(value.ToString("dd/MM/yyyy"));
            objPDDAO.intItemId = Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString());
            int num = this.objPDBll.intItemUnitId(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
            objPDDAO.intUnitId = num;
            objPDDAO.decCurrentSDChargablePrice = Convert.ToDecimal(this.txtCurrentSDPrice.Text);
            objPDDAO.decProposedSDChargablePric = Convert.ToDecimal(this.txtProposedSDPrice.Text);
            objPDDAO.decSD = Convert.ToDecimal(this.txtSD.Text);
            objPDDAO.decCurrentVATChargablePrice = Convert.ToDecimal(this.txtCurrentVATPrice.Text);
            objPDDAO.decProposedVATChargabelPrice = Convert.ToDecimal(this.txtProposedVATPrice.Text);
            objPDDAO.decWholeSalePrice = Convert.ToDecimal(this.txtWholeSalePrice.Text);
            objPDDAO.decRetailPrice = Convert.ToDecimal(this.txtRetailPrice.Text);
            objPDDAO.intUserIdInsert = 1;
            objPDDAO.decNBRSDChargablePrice = Convert.ToDecimal(this.txtProposedSDPrice.Text);
            objPDDAO.decNBRSD = Convert.ToDecimal(this.txtSD.Text);
            objPDDAO.decNBRVATChargablePrice = Convert.ToDecimal(this.txtProposedVATPrice.Text);
            objPDDAO.decNBRWholeSalePrice = Convert.ToDecimal(this.txtWholeSalePrice.Text);
            objPDDAO.decNBRRetailPrice = Convert.ToDecimal(this.txtRetailPrice.Text);
            objPDDAO.decProposedActualPrice = Convert.ToDecimal(this.txtPurchasePrice.Text);
            return objPDDAO;
        }

        private PriceDeclaretionRawDAO insertPriceDeclarationRaw(PriceDeclaretionRawDAO objPDRDAO, int intRowId)
        {
            return objPDRDAO;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.Session["ProposedSDChargablePrice"] = 0;
                this.Session["ProposedVATChargablePrice"] = 0;
                this.Session["PriceId"] = 0;
                OrganizaitonInfo.fillAllOrganizaiton(this.ddlOrganization);
                this.ddlOrganization.SelectedValue = this.Session["ORGANIZATION_ID"].ToString();
                BLL.Utility.fillYearList(this.ddlYear);
                BLL.Utility.fillAllItemCategory(this.ddlItemCategory);
                ListItem listItem = new ListItem("-- Select ---", "-99");
                this.ddlItemCategory.Items.Insert(0, listItem);
                if (this.ddlItemCategory.Items.Count > 0)
                {
                    BLL.Utility.fillAllItemByCategory(this.ddlItem, Convert.ToInt32(this.ddlItemCategory.SelectedValue.ToString()));
                    ListItem listItem1 = new ListItem("-- Select ---", "-99");
                    this.ddlItem.Items.Insert(0, listItem1);
                    if (this.ddlItem.SelectedItem.Value.ToString() != "-99")
                    {
                        DataSet itemDetail = this.objPDBll.getItemDetail(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
                        if (itemDetail.Tables[0].Rows.Count <= 0)
                        {
                            this.lblHSCode.Text = "";
                        }
                        else
                        {
                            this.lblHSCode.Text = itemDetail.Tables[0].Rows[0]["hs_code"].ToString();
                        }
                    }
                }
                BLL.Utility.fillAllPriceDeclarationNo(this.ddlPriceDeclarationNo);
                this.showValueAdditionDataInGridView();
                this.Session["dtInSession"] = null;
            }
            this.dtpActiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save Declaretion";
        }

        public void showDataInGridView()
        {
            DataSet allPriceDeclaration = this.objPDBll.getAllPriceDeclaration();
            this.gvDeclaretion.DataSource = allPriceDeclaration;
            this.gvDeclaretion.DataBind();
        }

        public void showNBRValueAdditionDataInGridView(int intPriceId)
        {
            DataSet allNBRValueAdditionArea = this.objPDBll.getAllNBRValueAdditionArea(intPriceId);
            this.gvNBRValueAddition.DataSource = allNBRValueAdditionArea;
            this.gvNBRValueAddition.DataBind();
        }

        public void showValueAdditionDataInGridView()
        {
            DataSet allValueAdditionArea = this.objPDBll.getAllValueAdditionArea();
            this.gvValueAddition.DataSource = allValueAdditionArea;
            this.gvValueAddition.DataBind();
        }

        protected void txtValueAddition_TextChanged(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                TextBox textBox = (TextBox)sender;
                TextBox textBox1 = (TextBox)((GridViewRow)textBox.NamingContainer).FindControl("txtValueAddition");
                textBox1.Text = string.Format("{0:C}", Convert.ToInt32(textBox.Text));
            }
        }

        private bool Validation()
        {
            if (this.txtPriceDeclaretionNo.Text.Trim().Length >= 1)
            {
                return true;
            }
            this.txtPriceDeclaretionNo.Focus();
            return false;
        }
    }
}