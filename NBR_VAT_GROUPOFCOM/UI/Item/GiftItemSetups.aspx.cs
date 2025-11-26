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

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class GiftItemSetups : Page, IRequiresSessionState
    {
       

        private AddItemBLL objItemBLL = new AddItemBLL();

        private DBUtility dbUtility = new DBUtility();

        private bool result;

        private CSVXMLBLL dbBLLLL = new CSVXMLBLL();

        private SaleBLL objBLL = new SaleBLL();

        public ArrayList objectPropertyNameList = new ArrayList();

        public ArrayList validationList = new ArrayList();

      

        public GiftItemSetups()
        {
        }

        protected void btnSaveGiftGiftItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validations())
                {
                    GiftDiscountPlanDAON giftDiscountPlanDAON = new GiftDiscountPlanDAON();
                    giftDiscountPlanDAON = this.fillPromoDetail();
                    if (giftDiscountPlanDAON == null)
                    {
                        this.msgBox.AddMessage("Please insert data properly.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    else if (this.btnSaveGift.Text == "UPDATE")
                    {
                        if (!this.objItemBLL.UpdatePromoPlan(giftDiscountPlanDAON, Convert.ToInt32(this.hiddenPromoId.Text)))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Gift/Discount Information Updated Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.hiddenPromoId.Text = "";
                            this.btnSaveGift.Text = "Save Promo";
                            this.reloadALL();
                        }
                    }
                    else if (!this.objItemBLL.InsertPromoPlan(giftDiscountPlanDAON))
                    {
                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage("Gift/Discount Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                        this.reloadALL();
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.drpSubCategory.Items.Clear();
                this.ddlItemName.Items.Clear();
                this.LoadItemsSubCategory();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strArrays = this.ddlItemName.SelectedValue.Split(new char[] { '.' });
            this.GetItemUnitName(Convert.ToInt32(strArrays[0]));
            this.showCatSubCat();
        }

        protected void drpGiftItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] strArrays = this.drpGiftItem.SelectedValue.Split(new char[] { '.' });
                this.GetGiftUnitName(Convert.ToInt32(strArrays[0]));
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "GiftItemSetUp.aspx", "GetAvailStock");
            }
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

        private GiftDiscountPlanDAON fillPromoDetail()
        {
            GiftDiscountPlanDAON giftDiscountPlanDAON = new GiftDiscountPlanDAON();
            if (!string.IsNullOrEmpty(this.txtHiddenDate.Text.Trim()))
            {
                string[] strArrays = new string[] { this.txtHiddenDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                giftDiscountPlanDAON.DatePlanned = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            giftDiscountPlanDAON.DateFrom = DateTime.ParseExact(this.txtDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            giftDiscountPlanDAON.DateTo = DateTime.ParseExact(this.txtDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            giftDiscountPlanDAON.Remarks = this.txtGiftRemarks.Text;
            if (this.ddlItemName.SelectedValue != "0")
            {
                string[] strArrays1 = this.ddlItemName.SelectedValue.Split(new char[] { '.' });
                giftDiscountPlanDAON.ParentItemID = Convert.ToInt32(strArrays1[0]);
                giftDiscountPlanDAON.PrntItemUnitID = Convert.ToInt32(this.drpItemUnit.SelectedValue);
                giftDiscountPlanDAON.IsOnItemPromo = true;
                giftDiscountPlanDAON.IsOnSalePromo = false;
                if (!string.IsNullOrWhiteSpace(this.txtMinItemQnt.Text))
                {
                    giftDiscountPlanDAON.PrntItemMinQnt = Convert.ToDecimal(this.txtMinItemQnt.Text);
                }
                else
                {
                    giftDiscountPlanDAON.PrntItemMinQnt = new decimal(0);
                }
            }
            else if (!string.IsNullOrWhiteSpace(this.txtMinSalePrice.Text) && Convert.ToDecimal(this.txtMinSalePrice.Text) > new decimal(0))
            {
                giftDiscountPlanDAON.IsOnItemPromo = false;
                giftDiscountPlanDAON.IsOnSalePromo = true;
                giftDiscountPlanDAON.MinSaleAmount = Convert.ToDecimal(this.txtMinSalePrice.Text);
            }
            if (string.IsNullOrWhiteSpace(this.txtDiscntPrcntg.Text) || !(Convert.ToDecimal(this.txtDiscntPrcntg.Text) > new decimal(0)))
            {
                giftDiscountPlanDAON.DiscountPrcntg = new decimal(0);
            }
            else
            {
                giftDiscountPlanDAON.DiscountPrcntg = Convert.ToDecimal(this.txtDiscntPrcntg.Text);
            }
            if (string.IsNullOrWhiteSpace(this.txtDiscountAmt.Text) || !(Convert.ToDecimal(this.txtDiscountAmt.Text) > new decimal(0)))
            {
                giftDiscountPlanDAON.DiscountAmount = new decimal(0);
            }
            else
            {
                giftDiscountPlanDAON.DiscountAmount = Convert.ToDecimal(this.txtDiscountAmt.Text);
            }
            if (this.drpGiftItem.SelectedValue != "-99")
            {
                string[] strArrays2 = this.drpGiftItem.SelectedValue.Split(new char[] { '.' });
                giftDiscountPlanDAON.GiftItemID = Convert.ToInt32(strArrays2[0]);
                giftDiscountPlanDAON.GiftItemCode = this.drpGiftItem.SelectedValue;
                giftDiscountPlanDAON.GiftQuantity = Convert.ToDecimal(this.txtGiftQnt.Text);
                giftDiscountPlanDAON.GiftItemUnitID = Convert.ToInt32(this.drpGiftUnit.SelectedValue);
            }
            return giftDiscountPlanDAON;
        }

        private void GetGiftUnitName(int itemId)
        {
            DataTable allUnit = this.objItemBLL.getAllUnit();
            DataTable unitbyItemSetUp = this.objItemBLL.getUnitbyItemSetUp(itemId);
            if (allUnit.Rows.Count > 0)
            {
                this.drpGiftUnit.DataSource = allUnit;
                this.drpGiftUnit.DataTextField = allUnit.Columns["unit_code"].ToString();
                this.drpGiftUnit.DataValueField = allUnit.Columns["unit_id"].ToString();
                this.drpGiftUnit.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpGiftUnit.Items.Insert(0, listItem);
                if (unitbyItemSetUp.Rows.Count > 0)
                {
                    this.drpGiftUnit.SelectedValue = unitbyItemSetUp.Rows[0]["unit_id"].ToString();
                }
            }
        }

        private void GetItemUnitName(int itemId)
        {
            DataTable allUnit = this.objItemBLL.getAllUnit();
            DataTable unitbyItemSetUp = this.objItemBLL.getUnitbyItemSetUp(itemId);
            if (allUnit.Rows.Count > 0)
            {
                this.drpItemUnit.DataSource = allUnit;
                this.drpItemUnit.DataTextField = allUnit.Columns["unit_code"].ToString();
                this.drpItemUnit.DataValueField = allUnit.Columns["unit_id"].ToString();
                this.drpItemUnit.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpItemUnit.Items.Insert(0, listItem);
                if (unitbyItemSetUp.Rows.Count > 0)
                {
                    this.drpItemUnit.SelectedValue = unitbyItemSetUp.Rows[0]["unit_id"].ToString();
                }
            }
        }

        protected void gvPromo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvPromos.PageIndex = e.NewPageIndex;
            this.loadGridView();
        }

        protected void gvPromo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                ((ImageButton)e.Row.Cells[e.Row.Cells.Count - 1].Controls[0]).Attributes["onclick"] = "if(!confirm('Are you sure to Delete the Discount Offer?'))return false;";
            }
        }

        protected void gvPromo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(this.gvPromos.Rows[e.RowIndex].Cells[1].Text);
                if (!this.objItemBLL.deletePromo(num))
                {
                    this.msgBox.AddMessage("Gift/Discount Promotion Delete Failed", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.msgBox.AddMessage("Gift/Discount Promotion Delete Successfully", MsgBoxs.enmMessageType.Success);
                    this.loadGridView();
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "Gift_Discount_Set_Up", "gvPromos_RowDeleting");
            }
        }

        protected void gvPromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            try
            {
                int num = Convert.ToInt32(this.gvPromos.SelectedDataKey["entry_id"]);
                this.hiddenPromoId.Text = this.gvPromos.SelectedDataKey["entry_id"].ToString();
                dataTable = this.objItemBLL.getGiftDiscountPromosById(num);
                if (dataTable != null)
                {
                    bool flag = Convert.ToBoolean(dataTable.Rows[0]["is_on_sale_gift"].ToString());
                    bool flag1 = Convert.ToBoolean(dataTable.Rows[0]["is_on_item_gift"].ToString());
                    if (flag)
                    {
                        if (Convert.ToDouble(dataTable.Rows[0]["min_sale_amount"]) > 0)
                        {
                            TextBox str = this.txtMinSalePrice;
                            double num1 = Convert.ToDouble(dataTable.Rows[0]["min_sale_amount"]);
                            str.Text = num1.ToString();
                        }
                    }
                    else if (flag1)
                    {
                        this.ddlItemName.SelectedValue = dataTable.Rows[0]["parent_item_id"].ToString();
                        this.GetItemUnitName(Convert.ToInt32(this.ddlItemName.SelectedValue));
                        if (Convert.ToDouble(dataTable.Rows[0]["parent_item_qnt"]) > 0)
                        {
                            TextBox textBox = this.txtMinItemQnt;
                            double num2 = Convert.ToDouble(dataTable.Rows[0]["parent_item_qnt"]);
                            textBox.Text = num2.ToString();
                        }
                    }
                    TextBox str1 = this.txtDateFrom;
                    DateTime dateTime = Convert.ToDateTime(dataTable.Rows[0]["date_from"]);
                    str1.Text = dateTime.ToString("dd/MM/yyyy");
                    TextBox textBox1 = this.txtDateTo;
                    DateTime dateTime1 = Convert.ToDateTime(dataTable.Rows[0]["date_to"]);
                    textBox1.Text = dateTime1.ToString("dd/MM/yyyy");
                    if (!string.IsNullOrWhiteSpace(dataTable.Rows[0]["gift_item_code"].ToString()))
                    {
                        this.drpGiftItem.SelectedValue = dataTable.Rows[0]["gift_item_code"].ToString();
                        string[] strArrays = this.drpGiftItem.SelectedValue.Split(new char[] { '.' });
                        this.GetGiftUnitName(Convert.ToInt32(strArrays[0]));
                    }
                    if (Convert.ToDouble(dataTable.Rows[0]["gift_qnt"]) > 0)
                    {
                        TextBox str2 = this.txtGiftQnt;
                        double num3 = Convert.ToDouble(dataTable.Rows[0]["gift_qnt"]);
                        str2.Text = num3.ToString();
                    }
                    if (Convert.ToDouble(dataTable.Rows[0]["discount_percentage"]) > 0)
                    {
                        TextBox textBox2 = this.txtDiscntPrcntg;
                        double num4 = Convert.ToDouble(dataTable.Rows[0]["discount_percentage"]);
                        textBox2.Text = num4.ToString();
                    }
                    if (Convert.ToDouble(dataTable.Rows[0]["discount_amount"]) > 0)
                    {
                        TextBox str3 = this.txtDiscountAmt;
                        double num5 = Convert.ToDouble(dataTable.Rows[0]["discount_amount"]);
                        str3.Text = num5.ToString();
                    }
                    this.ddlCategory.ClearSelection();
                    this.ddlCategory.SelectedValue = dataTable.Rows[0]["parent_id"].ToString();
                    this.drpSubCategory.SelectedValue = dataTable.Rows[0]["sub_category_id"].ToString();
                    this.txtGiftRemarks.Text = Convert.ToString(dataTable.Rows[0]["remarks"]);
                    this.btnSaveGift.Text = "UPDATE";
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadGiftItems()
        {
            try
            {
                DataTable goodItems = (new AddItemBLL()).GetGoodItems();
                this.drpGiftItem.Items.Clear();
                this.drpGiftItem.DataSource = goodItems;
                this.drpGiftItem.DataTextField = goodItems.Columns["ITEM_NAME"].ToString();
                this.drpGiftItem.DataValueField = goodItems.Columns["ITEM_ID"].ToString();
                this.drpGiftItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpGiftItem.Items.Insert(0, listItem);
                this.Session["Gift_ITEM_INFO"] = goodItems;
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "LoadItems");
            }
        }

        private void loadGridView()
        {
            TransPartyBLL transPartyBLL = new TransPartyBLL();
            DataTable giftDiscountPromos = this.objItemBLL.getGiftDiscountPromos();
            this.gvPromos.DataSource = giftDiscountPromos;
            this.gvPromos.DataBind();
        }

        private void LoadHours()
        {
            this.drpChDtHr.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
            }
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

        private void LoadItemsSubCategory()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = Convert.ToInt32(this.ddlCategory.SelectedValue);
            if (this.ddlCategory.SelectedValue == "0")
            {
                ListItem listItem = new ListItem("ALL", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("ALL", "0");
                this.ddlItemName.Items.Insert(0, listItem);
                return;
            }
            DataTable allISubCategory = addItemBLL.getAllISubCategory(num);
            this.drpSubCategory.DataSource = allISubCategory;
            this.drpSubCategory.DataTextField = allISubCategory.Columns["category_name"].ToString();
            this.drpSubCategory.DataValueField = allISubCategory.Columns["category_id"].ToString();
            this.drpSubCategory.DataBind();
            ListItem listItem2 = new ListItem("----Select----", "-0");
            this.drpSubCategory.Items.Insert(0, listItem2);
        }

        private void LoadItemsWithoutFilter()
        {
            this.ddlItemName.Items.Clear();
            DataTable allItemByCategoryForTaxRate = (new AddItemBLL()).getAllItemByCategoryForTaxRate();
            this.ddlItemName.DataSource = allItemByCategoryForTaxRate;
            this.ddlItemName.DataTextField = allItemByCategoryForTaxRate.Columns["ITEM_NAME"].ToString();
            this.ddlItemName.DataValueField = allItemByCategoryForTaxRate.Columns["ITEM_ID"].ToString();
            this.ddlItemName.DataBind();
            ListItem listItem = new ListItem("ALL", "0");
            this.ddlItemName.Items.Insert(0, listItem);
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
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                OrganizaitonInfo.fillDDLAllCategoryName(this.ddlCategory);
                int count = this.ddlCategory.Items.Count;
                this.LoadItemsWithoutFilter();
                this.txtDateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.txtDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.LoadGiftItems();
                UtilityK.fillSubCategoryByCatDropDownList(this.ddlCategory, this.drpSubCategory);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
                this.LoadHours();
                this.LoadMinutes();
                this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                this.txtHiddenDate.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
                this.loadGridView();
            }
        }

        private void reloadALL()
        {
            this.LoadItemsWithoutFilter();
            this.txtDateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.LoadGiftItems();
            this.LoadHours();
            this.LoadMinutes();
            this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
            this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
            this.txtHiddenDate.Text = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            this.loadGridView();
            this.txtMinSalePrice.Text = "";
            this.txtMinItemQnt.Text = "";
            this.txtGiftQnt.Text = "";
            this.drpGiftUnit.Items.Clear();
            this.hiddenPromoId.Text = "";
            this.txtHiddenGiftQnt.Text = "";
        }

        private void setGiftDetaiAddMode()
        {
            this.btnSaveGift.Text = "Save Promo";
        }

        private void setGiftDetailUpdateMode()
        {
            this.btnSaveGift.Text = GiftItemSetups.enmBtnText.Update.ToString();
        }

        private void showCatSubCat()
        {
            try
            {
                string selectedValue = this.ddlItemName.SelectedValue;
                string[] strArrays = selectedValue.Split(new char[] { '.' });
                int num = Convert.ToInt32(strArrays[0]);
                DataTable catSubCat = this.objBLL.getCatSubCat(num);
                if (catSubCat != null)
                {
                    this.ddlCategory.SelectedValue = catSubCat.Rows[0]["category_id"].ToString();
                    this.drpSubCategory.SelectedValue = catSubCat.Rows[0]["sub_category_id"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void ShowGiftDataForEdit(SaleGiftDetailDAON objDetailDAO)
        {
            this.LoadGiftItems();
            this.drpGiftItem.SelectedValue = objDetailDAO.ItemWithTypeID.ToString();
            this.txtGiftQnt.Text = objDetailDAO.GiftQuantity.ToString();
            this.txtGiftRemarks.Text = objDetailDAO.Remarks;
            this.setGiftDetailUpdateMode();
        }

        private bool Validations()
        {
            if (this.txtDateFrom.Text.Length < 10 || this.txtDateFrom.Text.Length > 10)
            {
                this.msgBox.AddMessage("Please enter from date correctly.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.txtDateTo.Text.Length < 10 || this.txtDateTo.Text.Length < 10)
            {
                this.msgBox.AddMessage("Please enter to date correctly.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(this.txtMinItemQnt.Text) && Convert.ToDecimal(this.txtMinItemQnt.Text) > new decimal(0) && this.ddlItemName.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Select Item for given minimum quantity", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(this.txtMinSalePrice.Text) && Convert.ToDecimal(this.txtMinSalePrice.Text) > new decimal(0) && this.ddlItemName.SelectedValue != "0")
            {
                this.msgBox.AddMessage("Promo can not be for both item and sale wise at a time.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if ((string.IsNullOrWhiteSpace(this.txtMinSalePrice.Text) || Convert.ToDecimal(this.txtMinSalePrice.Text) <= new decimal(0)) && this.ddlItemName.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Promo should be item wise or sale wise.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(this.txtGiftQnt.Text) && Convert.ToDecimal(this.txtGiftQnt.Text) > new decimal(0) && this.drpGiftItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select Gift item for given gift quantity", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.txtGiftQnt.Text) && this.drpGiftItem.SelectedValue != "-99")
            {
                this.msgBox.AddMessage("Type gift quantity for selected gift item", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.drpGiftItem.SelectedValue != "-99" && !string.IsNullOrWhiteSpace(this.txtDiscntPrcntg.Text) && Convert.ToDecimal(this.txtDiscntPrcntg.Text) > new decimal(0))
            {
                this.msgBox.AddMessage("Gift and discount both can not be provided together in a promo.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.drpGiftItem.SelectedValue != "-99" && !string.IsNullOrWhiteSpace(this.txtDiscountAmt.Text) && Convert.ToDecimal(this.txtDiscountAmt.Text) > new decimal(0))
            {
                this.msgBox.AddMessage("Gift and discount both can not be provided together in a promo.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (!(this.drpGiftItem.SelectedValue == "-99") || !string.IsNullOrWhiteSpace(this.txtDiscntPrcntg.Text) || !string.IsNullOrWhiteSpace(this.txtDiscountAmt.Text))
            {
                return true;
            }
            this.msgBox.AddMessage("Please provide gift or discount in this promo.", MsgBoxs.enmMessageType.Info);
            return false;
        }

        private enum enmBtnText
        {
            Save,
            Update,
            Cancel,
            Clear
        }
    }
}