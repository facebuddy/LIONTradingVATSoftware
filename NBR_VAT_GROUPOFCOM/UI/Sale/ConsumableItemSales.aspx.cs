using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Sale
{
    public partial class ConsumableItemSales : Page, IRequiresSessionState
    {

       
        private CSVXMLBLL dbBLLLL = new CSVXMLBLL();

        private ItemBLL item = new ItemBLL();

        private AddItemBLL dbBLL = new AddItemBLL();

        private AddUserBLL ubll = new AddUserBLL();

        private SaleBLL objBLL = new SaleBLL();

        private SetItemPropertyBLL itmProperty = new SetItemPropertyBLL();

        private DataTable dtAmount = new DataTable();

        private ContructualProductionBLL objCPBLL = new ContructualProductionBLL();

        

        public ConsumableItemSales()
        {
        }

        private void AddDetailDataInGrid()
        {
            ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
            this.gvItem.DataSource = item;
            this.gvItem.DataBind();
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (this.btnAdd.Text != "Add Item")
            {
                this.GetInsertGiftDetails();
                this.AddDetailDataInGrid();
                this.ClearAllControlsValue();
                this.gvItem.Visible = true;
                this.lblAvailStock.Text = "0";
                this.setDetaiAddMode();
            }
            else if (this.Validation())
            {
                this.GetInsertGiftDetails();
                this.AddDetailDataInGrid();
                this.ClearAllControlsValue();
                this.gvItem.Visible = true;
                this.lblAvailStock.Text = "0";
                this.lblavlStock.Text = "0";
                return;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAllControlsValue();
            this.ClearOnItemChangeValue();
            this.Session["GIFT_SALE_DETAIL_LIST"] = new ArrayList();
            this.gvItem.DataSource = null;
            this.gvItem.DataBind();
            this.Refresh_First_Table();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
                if (!this.objBLL.InsertConsumableSaleItem(arrayLists) || arrayLists.Count <= 0)
                {
                    this.msgBox.AddMessage(" Please Add Item first..", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    this.ClearAllControlsValue();
                    this.GetChallanNo();
                    arrayLists.Clear();
                    this.gvItem.Visible = false;
                    this.ClearOnItemChangeValue();
                    this.setDetaiAddMode();
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "ApproveSaleChallan.aspx", "btnGenerate_Click");
            }
        }

        private void ClearAllControlsValue()
        {
            try
            {
                this.LoadItems();
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                this.GetUnitName();
                this.drpSubCategory.Items.Clear();
                ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem1);
                this.txtQuantity.Text = "";
                this.txtUnitPrice.Text = "";
                this.txtFinalQuantity.Text = "";
                this.txtPriceIncludingVat.Text = "";
                this.txtTotalPrice.Text = "";
                this.tbTotalVAT.Text = "";
                this.txtTotalSD.Text = "";
                this.lblHSCode.Text = "";
                this.Session["instalment"] = new ArrayList();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "installmentScheduler", "ClearAllControlsValue", fileLineNumber);
            }
        }

        private void ClearOnItemChangeValue()
        {
            try
            {
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                this.drpSubCategory.Items.Clear();
                ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem1);
                this.productName.Text = "";
                this.txtQuantity.Text = "";
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "0.00";
                this.lblSD.Text = "0.00";
                this.lblVAT.Text = "0.00";
                this.txtTotalPrice.Text = "";
                this.txtPriceIncludingVat.Text = "";
                this.tbTotalVAT.Text = "";
                this.txtTotalSD.Text = "";
                this.lblAvailStock.Text = "0";
                this.lblavlStock.Text = "0";
                this.lblSku.Text = "";
                this.lblUnit.Text = "Unit";
                this.lblHSCode.Text = ".";
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "ClearDetailControlsValue", fileLineNumber);
            }
        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadSubCategory();
                this.LoadItemsByCatgSubCatg();
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "";
                this.lblSD.Text = "0.00";
                this.lblVAT.Text = "0.00";
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpChallan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpChallanNo.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpChallanNo.SelectedValue);
                    DataTable partybySaleChallan = this.objBLL.GetPartybySaleChallan(num);
                    if (partybySaleChallan.Rows.Count > 0)
                    {
                        this.drpParty.DataSource = partybySaleChallan;
                        this.drpParty.DataTextField = partybySaleChallan.Columns["party_name"].ToString();
                        this.drpParty.DataValueField = partybySaleChallan.Columns["party_id"].ToString();
                        this.drpParty.DataBind();
                        this.txtChallanDate.Text = partybySaleChallan.Rows[0]["date_challan"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ClearOnItemChangeValue();
                this.Label9.Text = "%";
                this.drpItem.SelectedItem.ToString();
                string selectedValue = this.drpItem.SelectedValue;
                decimal num = new decimal(0);
                int num1 = 0;
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                num1 = Convert.ToInt16(strArrays[0]);
                PriceDeclaretionBLL priceDeclaretionBLL = new PriceDeclaretionBLL();
                if (this.drpItem.SelectedValue != "-99")
                {
                    string[] strArrays1 = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                    if (strArrays1 != null && strArrays1.Count<string>() > 0)
                    {
                        this.lblHSCode.Text = strArrays1[strArrays1.Count<string>() - 2];
                    }
                    num = Convert.ToDecimal(this.drpItem.SelectedValue);
                    this.drpItem.SelectedItem.ToString();
                    AddItemBLL addItemBLL = new AddItemBLL();
                    DataTable item = (DataTable)this.Session["ITEM_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("item_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.lblProductType.Text = dataRow["PRODUCT_TYPE"].ToString();
                        this.lblSku.Text = dataRow["item_sku"].ToString();
                        this.txtSpecification.Value = dataRow["item_specification"].ToString();
                        this.drpUnit.SelectedValue = dataRow["unit_id"].ToString();
                    }
                    DataTable batchNo = addItemBLL.getBatchNo(num1);
                    if (batchNo.Rows.Count > 0)
                    {
                        this.txtBatchNo.Text = batchNo.Rows[0]["batch_no"].ToString();
                    }
                    this.GetAvailStock();
                    this.GetPriceInfo();
                    this.showCatSubCat();
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "GetAvailStock");
            }
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadCategory();
                this.LoadItemsByCatgSubCatg();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpUseStatus.SelectedValue != "1")
                {
                    this.drpParty.Enabled = true;
                    this.txtConsumableDate.Enabled = true;
                    this.txtChallanDate.Enabled = true;
                    this.drpChallanNo.Enabled = true;
                    this.txtConsumableDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    this.drpParty.Enabled = false;
                    this.txtConsumableDate.Enabled = false;
                    this.txtChallanDate.Enabled = false;
                    this.drpChallanNo.Enabled = false;
                    this.OwnuseClearallinfo();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void GetAvailStock()
        {
            try
            {
                SaleBLL saleBLL = new SaleBLL();
                string str = "";
                string str1 = "";
                DateTime dateTime = DateTime.ParseExact(this.txtConsumableDate.Text.Trim(), "dd/MM/yyyy", null);
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                int num = 0;
                string str2 = "";
                if (this.drpItem.SelectedValue != "-99")
                {
                    str = this.drpItem.SelectedItem.ToString();
                    str2 = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays = str2.Split(new char[] { '.' });
                    num = Convert.ToInt16(strArrays[0]);
                    if (str.Contains("Local"))
                    {
                        str1 = "L";
                    }
                    if (str.Contains("Import"))
                    {
                        str1 = "I";
                    }
                    if (str.Contains("Production"))
                    {
                        str1 = "F";
                    }
                    DataTable itemType = this.dbBLLLL.getItemType(num);
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    if (itemType.Rows.Count > 0)
                    {
                        itemType.Rows[0]["product_type"].ToString();
                    }
                    dataTable = saleBLL.GetSaleAvailableStockN(num, str1, dateTime, str1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.lblUnit.Text = dataTable.Rows[0]["unit_code"].ToString();
                        if (dataTable.Rows[0]["item_type"].ToString() != "I")
                        {
                            this.lblAvailStock.Text = "0";
                        }
                        else
                        {
                            this.lblAvailStock.Text = dataTable.Rows[0]["availStock"].ToString();
                            this.lblavlStock.Text = string.Concat(dataTable.Rows[0]["availStock"].ToString(), " ", this.lblUnit.Text);
                        }
                        if (dataTable.Rows[0]["parent_id"] == null || Convert.ToInt16(dataTable.Rows[0]["parent_id"]) <= 0)
                        {
                            this.drpCategory.SelectedValue = dataTable.Rows[0]["sub_category_id"].ToString();
                            this.drpSubCategory.Items.Clear();
                            ListItem listItem = new ListItem("-- SELECT --", "-99");
                            this.drpSubCategory.Items.Insert(0, listItem);
                            this.drpSubCategory.Enabled = false;
                        }
                        else
                        {
                            this.drpCategory.SelectedValue = dataTable.Rows[0]["parent_id"].ToString();
                            this.LoadSubCategory();
                            this.drpSubCategory.SelectedValue = dataTable.Rows[0]["sub_category_id"].ToString();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "GetAvailStock");
            }
        }

        private void GetChallanNo()
        {
            try
            {
                DataTable saleChallanNoInConsumableItem = (new ChallanBLL()).GetSaleChallanNo_In_consumableItem();
                if (saleChallanNoInConsumableItem.Rows.Count > 0)
                {
                    this.drpChallanNo.DataSource = saleChallanNoInConsumableItem;
                    this.drpChallanNo.DataTextField = saleChallanNoInConsumableItem.Columns["Challan_no"].ToString();
                    this.drpChallanNo.DataValueField = saleChallanNoInConsumableItem.Columns["Challan_id"].ToString();
                    this.drpChallanNo.DataBind();
                }
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpChallanNo.Items.Insert(0, listItem);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "GetChallanNo", fileLineNumber);
            }
        }

        private void GetInsertGiftDetails()
        {
            ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            try
            {
                SaleGiftDetailDAON saleGiftDetailDAON = new SaleGiftDetailDAON();
                string str = this.drpItem.SelectedValue.ToString();
                string str1 = this.drpItem.SelectedItem.ToString();
                string[] strArrays = str.Split(new char[] { '.' });
                if (str1.Contains("Local"))
                {
                    saleGiftDetailDAON.TypeP = "L";
                }
                if (str1.Contains("Import"))
                {
                    saleGiftDetailDAON.TypeP = "I";
                }
                if (str1.Contains("Production"))
                {
                    saleGiftDetailDAON.TypeP = "F";
                }
                if (str1.Contains("Service"))
                {
                    saleGiftDetailDAON.TypeP = "S";
                }
                saleGiftDetailDAON.catID = Convert.ToInt32(this.drpCategory.SelectedValue);
                saleGiftDetailDAON.subcatID = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                saleGiftDetailDAON.ItemName = this.drpItem.SelectedItem.ToString();
                saleGiftDetailDAON.ItemID = Convert.ToInt16(strArrays[0]);
                saleGiftDetailDAON.ItemID2 = this.drpItem.SelectedValue.ToString();
                saleGiftDetailDAON.UnitId = Convert.ToInt32(this.drpUnit.SelectedValue);
                saleGiftDetailDAON.UnitName = this.drpUnit.SelectedItem.ToString();
                saleGiftDetailDAON.ChallanDate = (!string.IsNullOrEmpty(this.txtChallanDate.Text) ? Convert.ToDateTime(this.txtChallanDate.Text) : DateTime.Now);
                saleGiftDetailDAON.ConsumableChallanDate = DateTime.ParseExact(this.txtConsumableDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                saleGiftDetailDAON.ChallanID = Convert.ToInt32(this.drpChallanNo.SelectedValue);
                saleGiftDetailDAON.DiscountSDRate = Convert.ToDecimal(this.lblSD.Text);
                saleGiftDetailDAON.DiscountSD = Convert.ToDecimal(this.txtTotalSD.Text);
                saleGiftDetailDAON.DiscountVatRate = Convert.ToDecimal(this.lblVAT.Text);
                saleGiftDetailDAON.DiscountVat = Convert.ToDecimal(this.tbTotalVAT.Text);
                saleGiftDetailDAON.ItemPriceBDT = Convert.ToDecimal(this.txtFinalQuantity.Text) * Convert.ToDecimal(this.txtUnitPrice.Text);
                saleGiftDetailDAON.GiftQuantity = Convert.ToDecimal(this.txtFinalQuantity.Text);
                saleGiftDetailDAON.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"].ToString());
                saleGiftDetailDAON.OrganizationID = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
                saleGiftDetailDAON.OrgBranchID = Convert.ToInt16(HttpContext.Current.Session["ORGBRANCHID"]);
                saleGiftDetailDAON.Remarks = this.drpUseStatus.SelectedItem.ToString();
                if (this.btnAdd.Text.Trim() != ConsumableItemSales.enmBtnText.Update.ToString())
                {
                    saleGiftDetailDAON.RowNo = num;
                    item.Add(saleGiftDetailDAON);
                }
                else
                {
                    saleGiftDetailDAON.RowNo = Convert.ToInt16(this.ViewState["selctedRowNoSale"]);
                    if (saleGiftDetailDAON.RowNo > 0)
                    {
                        int rowNo = saleGiftDetailDAON.RowNo - 1;
                        item.RemoveAt(rowNo);
                        item.Insert(rowNo, saleGiftDetailDAON);
                        this.setDetaiAddMode();
                        this.ViewState["selctedRowNo"] = 0;
                    }
                }
                this.Session["GIFT_SALE_DETAIL_LIST"] = item;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void GetPriceInfo()
        {
            DataTable dataTable = new DataTable();
            string str = "";
            string str1 = "";
            try
            {
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                saleDetailDAON.ItemID = Convert.ToInt16(strArrays[0]);
                if (saleDetailDAON.ItemID != -99)
                {
                    double num = 0;
                    double num1 = 0;
                    double num2 = 0;
                    double num3 = 0;
                    if (this.lblProductType.Text != "C")
                    {
                        DataTable priceInfoOfItemFrSaleN = this.objBLL.GetPriceInfoOfItemFrSaleN(saleDetailDAON);
                        string str2 = "";
                        str2 = priceInfoOfItemFrSaleN.Rows[0]["per"].ToString();
                        if (priceInfoOfItemFrSaleN == null || priceInfoOfItemFrSaleN.Rows.Count <= 0)
                        {
                            this.lblSD.Text = "0.00";
                            this.lblVAT.Text = "0.00";
                        }
                        else if (str2 != "1")
                        {
                            if (priceInfoOfItemFrSaleN.Rows[0]["SD_RATE"].ToString() != "")
                            {
                                num = Convert.ToDouble(priceInfoOfItemFrSaleN.Rows[0]["SD_RATE"]);
                            }
                            if (priceInfoOfItemFrSaleN.Rows[0]["VAT_RATE"].ToString() != "")
                            {
                                num1 = Convert.ToDouble(priceInfoOfItemFrSaleN.Rows[0]["VAT_RATE"]);
                            }
                            if (priceInfoOfItemFrSaleN.Rows[0]["AIT_RATE"].ToString() != "")
                            {
                                Convert.ToDouble(priceInfoOfItemFrSaleN.Rows[0]["AIT_RATE"]);
                            }
                            this.lblSD.Text = num.ToString("N");
                            this.lblVAT.Text = num1.ToString("N");
                        }
                        else
                        {
                            this.tbTotalVAT.Text = priceInfoOfItemFrSaleN.Rows[0]["VAT_RATE"].ToString();
                            this.lblVAT.Text = priceInfoOfItemFrSaleN.Rows[0]["VAT_RATE"].ToString();
                            this.Label9.Text = " Per Unit.";
                            this.lblfxdVT.Text = "Tk. ";
                        }
                        decimal num4 = new decimal(0);
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        DataTable unitPriceFromPD = this.objCPBLL.GetUnitPriceFromPD(saleDetailDAON.ItemID);
                        if (unitPriceFromPD.Rows.Count <= 0)
                        {
                            dataTable = this.objBLL.getSaleUnitPrice(saleDetailDAON.ItemID);
                            if (dataTable.Rows.Count <= 0)
                            {
                                this.txtUnitPrice.Text = "0.00";
                                this.lblUnitPrice.Text = "0.00";
                            }
                            else
                            {
                                this.txtUnitPrice.Text = dataTable.Rows[0]["sale_unit_price"].ToString();
                                this.lblUnitPrice.Text = dataTable.Rows[0]["sale_unit_price"].ToString();
                            }
                        }
                        else
                        {
                            num4 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["prpsd_actl_prc"]);
                            num5 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["production_quantity"]);
                            num6 = num4 / num5;
                            this.txtUnitPrice.Text = num6.ToString();
                            this.lblUnitPrice.Text = num6.ToString();
                        }
                    }
                    else
                    {
                        DataTable priceInfoOfItemFrSaleN1 = this.objBLL.GetPriceInfoOfItemFrSaleN(saleDetailDAON);
                        if (priceInfoOfItemFrSaleN1 == null || priceInfoOfItemFrSaleN1.Rows.Count <= 0)
                        {
                            this.lblUnitPrice.Text = "0.00";
                            this.txtUnitPrice.Text = "0.00";
                            this.lblSD.Text = "0.00";
                            this.lblVAT.Text = "0.00";
                        }
                        else
                        {
                            if (str1 == "I" || str1 == "")
                            {
                                this.txtUnitPrice.Text = priceInfoOfItemFrSaleN1.Rows[0]["unit_price"].ToString();
                                this.lblUnitPrice.Text = priceInfoOfItemFrSaleN1.Rows[0]["unit_price"].ToString();
                                num3 = Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["cnfrmd_wholesale_prc"]);
                                num2 = Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["cnfrmd_sd_amount"]);
                            }
                            string str3 = "";
                            str3 = priceInfoOfItemFrSaleN1.Rows[0]["per"].ToString();
                            if (priceInfoOfItemFrSaleN1 == null || priceInfoOfItemFrSaleN1.Rows.Count <= 0)
                            {
                                this.lblSD.Text = "0.00";
                                this.lblVAT.Text = "0.00";
                            }
                            else if (str3 != "1")
                            {
                                if (priceInfoOfItemFrSaleN1.Rows[0]["SD_RATE"].ToString() != "")
                                {
                                    num = Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["SD_RATE"]);
                                }
                                if (priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"].ToString() != "")
                                {
                                    num1 = Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"]);
                                }
                                if (priceInfoOfItemFrSaleN1.Rows[0]["AIT_RATE"].ToString() != "")
                                {
                                    Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["AIT_RATE"]);
                                }
                                this.lblSD.Text = num.ToString("N");
                                this.lblVAT.Text = num1.ToString("N");
                            }
                            else
                            {
                                this.tbTotalVAT.Text = priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"].ToString();
                                this.lblVAT.Text = priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"].ToString();
                                this.Label9.Text = " Per Unit.";
                                this.lblfxdVT.Text = "Tk. ";
                            }
                            if (str1 != "I" && str1 != "")
                            {
                                this.lblUnitPrice.Text = "0.00";
                                this.txtUnitPrice.Text = "0.00";
                            }
                            else if (priceInfoOfItemFrSaleN1.Rows[0]["cnfrmd_actl_prc"].ToString() != "" && num1 > 0)
                            {
                                Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["cnfrmd_actl_prc"]);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "GetPriceInfo");
            }
        }

        private void GetUnitName()
        {
            DataTable allUnit = (new AddItemBLL()).getAllUnit();
            if (allUnit.Rows.Count > 0)
            {
                this.drpUnit.DataSource = allUnit;
                this.drpUnit.DataTextField = allUnit.Columns["unit_code"].ToString();
                this.drpUnit.DataValueField = allUnit.Columns["unit_id"].ToString();
                this.drpUnit.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpUnit.Items.Insert(0, listItem);
            }
        }

        protected void gvItem_PreRender(object sender, EventArgs e)
        {
        }

        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                ((ImageButton)e.Row.Cells[20].Controls[0]).Attributes["onclick"] = "if(!confirm('Do you want to delete?'))return   false;";
            }
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
                item.RemoveAt(e.RowIndex);
                this.Session["GIFT_SALE_DETAIL_LIST"] = item;
                this.AddDetailDataInGrid();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                short num = Convert.ToInt16(this.gvItem.SelectedDataKey["RowNo"]);
                this.ViewState["selctedRowNoSale"] = num;
                ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
                int num1 = 0;
                while (num1 < item.Count)
                {
                    SaleGiftDetailDAON saleGiftDetailDAON = (SaleGiftDetailDAON)item[num1];
                    if (saleGiftDetailDAON.RowNo != num)
                    {
                        num1++;
                    }
                    else
                    {
                        this.ShowDetailDataForEdit(saleGiftDetailDAON);
                        this.GetAvailStock();
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadCategory()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (this.drpSubCategory.SelectedValue != "" && this.drpSubCategory.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                    dataTable = this.dbBLL.GetCategoryBySubCategoryID(num);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpCategory.SelectedValue = dataTable.Rows[0]["category_id"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void LoadItems()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO();
                if (this.drpCategory.SelectedValue == "ALL" && this.drpSubCategory.SelectedValue == "-99")
                {
                    setItemDAO.CategoryID = 0;
                }
                else if (this.drpCategory.SelectedValue != "ALL" && this.drpSubCategory.SelectedValue == "-99")
                {
                    setItemDAO.CategoryID = Convert.ToInt32(this.drpCategory.SelectedValue);
                }
                else if (this.drpCategory.SelectedValue != "ALL" && this.drpSubCategory.SelectedValue != "-99")
                {
                    setItemDAO.CategoryID = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                }
                setItemDAO.CatagoryTyp = "B";
                DataTable allItemByCatSubCat = addItemBLL.GetAllItemByCatSubCat(setItemDAO);
                this.drpItem.DataSource = allItemByCatSubCat;
                this.drpItem.DataTextField = allItemByCatSubCat.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = allItemByCatSubCat.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpItem.Items.Insert(0, listItem);
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "0.00";
                this.lblSD.Text = "0.00";
                this.lblVAT.Text = "0.00";
                this.drpItem.Focus();
                this.Session["ITEM_INFO"] = allItemByCatSubCat;
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "LoadItems");
            }
        }

        private void LoadItemsByCatgSubCatg()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO()
                {
                    CategoryID = (Convert.ToInt32(this.drpCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpCategory.SelectedValue) : 0),
                    SubCatgID = (Convert.ToInt32(this.drpSubCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpSubCategory.SelectedValue) : 0)
                };
                DataTable itemByCatgSubCatgmqmm = addItemBLL.GetItemByCatgSubCatgmqmm(setItemDAO);
                this.drpItem.DataSource = itemByCatgSubCatgmqmm;
                this.drpItem.DataTextField = itemByCatgSubCatgmqmm.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = itemByCatgSubCatgmqmm.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpItem.Items.Insert(0, listItem);
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "";
                this.lblSD.Text = "0.00";
                this.lblVAT.Text = "0.00";
                this.drpItem.Focus();
                this.Session["ITEM_INFO"] = itemByCatgSubCatgmqmm;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadSubCategory()
        {
            try
            {
                this.drpSubCategory.DataSource = null;
                this.drpSubCategory.Items.Clear();
                this.drpSubCategory.Enabled = true;
                if (this.drpCategory.SelectedValue != "" && this.drpCategory.SelectedValue != "-99")
                {
                    UtilityK.fillSubCategoryByCatDropDownList(this.drpCategory, this.drpSubCategory);
                    if (this.drpSubCategory.Items.Count != 0)
                    {
                        this.drpSubCategory.Focus();
                    }
                    else
                    {
                        this.drpSubCategory.Enabled = false;
                        this.drpItem.Focus();
                    }
                }
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
            }
        }

        private void OwnuseClearallinfo()
        {
            this.txtChallanDate.Text = null;
            this.txtConsumableDate.Text = null;
            this.drpChallanNo.Text = null;
            this.drpChallanNo.SelectedValue = null;
            this.drpParty.Items.Clear();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                UtilityK.fillSubCategoryByCatDropDownList(this.drpCategory, this.drpSubCategory);
                ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem1);
                ListItem listItem2 = new ListItem("-- SELECT --", "-99");
                this.drpItem.Items.Insert(0, listItem2);
                ListItem listItem3 = new ListItem("-- SELECT --", "-99");
                this.LoadItems();
                ArrayList arrayLists = new ArrayList();
                this.Session["GIFT_SALE_DETAIL_LIST"] = new ArrayList();
                this.GetUnitName();
                this.GetChallanNo();
                this.txtConsumableDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void PropertyWiseQuantity()
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            num = (!string.IsNullOrEmpty(this.lblVAT.Text) ? Convert.ToDecimal(this.lblVAT.Text.Trim()) : new decimal(0));
            num1 = (!string.IsNullOrEmpty(this.lblSD.Text) ? Convert.ToDecimal(this.lblSD.Text.Trim()) : new decimal(0));
            AddItemBLL addItemBLL = new AddItemBLL();
            DataTable dataTable = new DataTable();
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            this.drpUnit.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(this.txtFinalQuantity.Text))
            {
                Convert.ToDecimal(this.txtFinalQuantity.Text);
            }
            num5 = (!string.IsNullOrEmpty(this.txtFinalQuantity.Text) ? Convert.ToDecimal(this.txtFinalQuantity.Text) : new decimal(1));
            num6 = (!string.IsNullOrEmpty(this.txtUnitPrice.Text) ? Convert.ToDecimal(this.txtUnitPrice.Text) : new decimal(0));
            this.txtUnitPrice.Text = num6.ToString("0.00");
            num4 = num5 * num6;
            num2 = (num4 * num1) / new decimal(100);
            this.txtTotalSD.Text = num2.ToString("0.00");
            this.txtTotalPrice.Text = num4.ToString("0.00");
            num3 = ((num4 + num2) * num) / new decimal(100);
            TextBox str = this.txtPriceIncludingVat;
            decimal num7 = (num4 + num2) + num3;
            str.Text = num7.ToString("0.00");
            this.tbTotalVAT.Text = num3.ToString("0.00");
            this.txtQuantity.Text = this.txtFinalQuantity.Text;
        }

        private void Refresh_First_Table()
        {
            this.txtChallanDate.Text = null;
            this.txtConsumableDate.Text = null;
            this.drpChallanNo.Text = null;
            this.drpChallanNo.SelectedValue = null;
            this.drpUseStatus.Text = null;
            this.drpParty.Items.Clear();
            this.drpUseStatus.SelectedValue = null;
            this.setDetaiAddMode();
        }

        private void setDetaiAddMode()
        {
            this.btnAdd.Text = "Add Item";
        }

        private void setDetailUpdateMode()
        {
            this.btnAdd.Text =ConsumableItemSales.enmBtnText.Update.ToString();
        }

        private void showCatSubCat()
        {
            try
            {
                string selectedValue = this.drpItem.SelectedValue;
                string[] strArrays = selectedValue.Split(new char[] { '.' });
                int num = Convert.ToInt32(strArrays[0]);
                DataTable catSubCat = this.objBLL.getCatSubCat(num);
                if (catSubCat != null)
                {
                    this.drpCategory.SelectedValue = catSubCat.Rows[0]["category_id"].ToString();
                    this.drpSubCategory.SelectedValue = catSubCat.Rows[0]["sub_category_id"].ToString();
                    this.lblUnit.Text = catSubCat.Rows[0]["unit_code"].ToString();
                }
                DateTime date = DateTime.Now.Date;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void ShowDetailDataForEdit(SaleGiftDetailDAON objDetailDAO)
        {
            ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
            try
            {
                objDetailDAO.ItemID.ToString();
                objDetailDAO.Remarks.ToString();
                this.drpChallanNo.SelectedValue = objDetailDAO.ChallanID.ToString();
                this.txtFinalQuantity.Text = objDetailDAO.GiftQuantity.ToString();
                this.drpCategory.SelectedValue = objDetailDAO.catID.ToString();
                this.LoadSubCategory();
                this.drpSubCategory.SelectedValue = objDetailDAO.subcatID.ToString();
                this.LoadItems();
                this.drpItem.SelectedValue = objDetailDAO.ItemID2;
                this.drpItem.SelectedItem.Text = objDetailDAO.ItemName.ToString();
                this.drpUnit.SelectedValue = objDetailDAO.UnitId.ToString();
                TextBox str = this.txtUnitPrice;
                decimal num = Convert.ToDecimal(objDetailDAO.ItemPriceBDT) / Convert.ToDecimal(objDetailDAO.GiftQuantity);
                str.Text = num.ToString();
                this.txtTotalPrice.Text = objDetailDAO.ItemPriceBDT.ToString();
                TextBox textBox = this.txtPriceIncludingVat;
                decimal num1 = Convert.ToDecimal(objDetailDAO.ItemPriceBDT) + Convert.ToDecimal(objDetailDAO.DiscountVat);
                textBox.Text = num1.ToString();
                this.lblSD.Text = objDetailDAO.DiscountSDRate.ToString();
                this.txtTotalSD.Text = objDetailDAO.DiscountSD.ToString();
                this.lblVAT.Text = objDetailDAO.DiscountVatRate.ToString();
                this.tbTotalVAT.Text = objDetailDAO.DiscountVat.ToString();
                this.setDetailUpdateMode();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            this.lblUnitPrice.Text = this.txtUnitPrice.Text;
            this.PropertyWiseQuantity();
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            this.PropertyWiseQuantity();
        }

        private bool Validation()
        {
            if (this.drpChallanNo.SelectedValue == "-99" && this.drpUseStatus.SelectedValue != "1")
            {
                this.msgBox.AddMessage("Please Select Challan No.", MsgBoxs.enmMessageType.Attention);
                this.drpChallanNo.Focus();
                return false;
            }
            if (this.drpUseStatus.SelectedValue != "0")
            {
                return true;
            }
            this.msgBox.AddMessage("Please Select use status", MsgBoxs.enmMessageType.Attention);
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