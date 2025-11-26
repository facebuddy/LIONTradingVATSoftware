using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
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

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class ContractualProduction_Receive_6__4s : Page, IRequiresSessionState
    { 


        private ContructualProductionBLL objCPBLL = new ContructualProductionBLL();

        private SaleBLL objBLL = new SaleBLL();

        private decimal quantity_global_to_sum;

     

        public ContractualProduction_Receive_6__4s()
        {
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Label9.Text = "%";
                if (this.gridValidation())
                {
                    if (Convert.ToDecimal(this.txtFinalQuantity.Text) > Convert.ToDecimal(this.lblAvailableQuantity.Text))
                    {
                        this.msgBox.AddMessage("Quantity is not available", MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                    else if (Convert.ToDecimal(this.txtFinalQuantity.Text) != new decimal(0))
                    {
                        this.getCPDetailData();
                        this.loadMainGridView();
                        this.getUsedQuantityN();
                        this.loadGridView();
                        this.clearAll();
                    }
                    else
                    {
                        this.msgBox.AddMessage("Quantity can not be 0.", MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "Own_Production_Receive6.4", "btnAddItem_Click", fileLineNumber);
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.clearAll();
            ArrayList arrayLists = new ArrayList();
            this.Session["CP_DETAIL_MAIN"] = arrayLists;
            this.gvMainItem.Visible = false;
            this.gvItem.Visible = false;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.printBTN.Text != "Show Report")
                {
                    this.btnPrintReport.Visible = false;
                    this.cpPrint.Visible = false;
                    this.printBTN.Text = "Show Report";
                }
                else
                {
                    this.msgBox.AddMessage("Please Save Your Data First.", MsgBoxs.enmMessageType.Attention);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            ContructualProductionIssueMasterDAO contructualProductionIssueMasterDAO = new ContructualProductionIssueMasterDAO();
            ArrayList arrayLists = new ArrayList();
            ArrayList item = new ArrayList();
            try
            {
                if (this.validation())
                {
                    contructualProductionIssueMasterDAO = this.getCPMasterData(contructualProductionIssueMasterDAO);
                    if (contructualProductionIssueMasterDAO != null)
                    {
                        if (!this.chkDiscard.Checked)
                        {
                            this.getUsedQuantitySave();
                            arrayLists = (ArrayList)this.Session["CP_DETAIL_Save"];
                            item = (ArrayList)this.Session["CP_DETAIL_MAIN"];
                            if (arrayLists == null || arrayLists.Count == 0)
                            {
                                this.gvItem.DataSource = null;
                                this.gvItem.DataBind();
                                this.msgBox.AddMessage("Please Add Item First.", MsgBoxs.enmMessageType.Error);
                                return;
                            }
                        }
                        decimal num = new decimal(0);
                        ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                        for (int i = 0; i < item.Count; i++)
                        {
                            contructualProductionIssueDAO = (ContructualProductionIssueDAO)item[i];
                            num = Convert.ToDecimal(contructualProductionIssueDAO.Quantity);
                        }
                        if (!contructualProductionBLL.insertCPReceiveData(contructualProductionIssueMasterDAO, arrayLists, item, num))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Product Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.showReport();
                            this.clearMasterData();
                            this.getChallanNo();
                        }
                    }
                    else
                    {
                        this.msgBox.AddMessage("Please insert master data properly.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "ContractualProductionReceive_6.4", "btnSave_Click", fileLineNumber);
            }
        }

        private void calculation()
        {
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            if (this.Label9.Text == " Per Unit")
            {
                num2 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                num = num2 * (this.txtSaleUnitPrice.Text != "" ? Convert.ToDouble(this.txtSaleUnitPrice.Text.Trim()) : 0);
            }
            else if (this.txtQuantity.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0 && this.txtSaleUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtSaleUnitPrice.Text) > 0)
            {
                if (this.txtSaleUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtSaleUnitPrice.Text) > 0)
                {
                    num1 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtSaleUnitPrice.Text);
                }
                if (this.lblSaleSD.Text.Length <= 0 || Convert.ToDouble(this.lblSaleSD.Text) <= 0 || num1 <= 0)
                {
                    this.txtSaleSD.Text = "0.00";
                    num = num1 + Convert.ToDouble(this.txtSaleSD.Text);
                    if (this.lblSaleVat.Text.Length <= 0 || Convert.ToDouble(this.lblSaleVat.Text) <= 0)
                    {
                        this.txtSaleVat.Text = "0.00";
                    }
                    else
                    {
                        TextBox str = this.txtSaleVat;
                        double num3 = num * Convert.ToDouble(this.lblSaleVat.Text) / 100;
                        str.Text = num3.ToString("0.00");
                        Convert.ToDouble(this.txtSaleVat.Text.Trim());
                    }
                }
                else
                {
                    TextBox textBox = this.txtSaleSD;
                    double num4 = num1 * Convert.ToDouble(this.lblSaleSD.Text) / 100;
                    textBox.Text = num4.ToString("0.00");
                    Convert.ToDouble(this.txtSaleSD.Text.Trim());
                    num = num1 + Convert.ToDouble(this.txtSaleSD.Text);
                    if (this.lblSaleVat.Text.Length <= 0 || Convert.ToDouble(this.lblSaleVat.Text) <= 0)
                    {
                        this.txtSaleVat.Text = "0.00";
                    }
                    else
                    {
                        TextBox str1 = this.txtSaleVat;
                        double num5 = num * Convert.ToDouble(this.lblSaleVat.Text) / 100;
                        str1.Text = num5.ToString("0.00");
                        Convert.ToDouble(this.txtSaleVat.Text.Trim());
                    }
                }
            }
            this.txtSaleVatablePrice.Text = num.ToString("0.00");
        }

        protected void challanNo_textChanged(object sender, EventArgs e)
        {
        }

        protected void chkDiscard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDiscard.Checked)
            {
                this.txtChallanNo.Style.Add("width", "50px");
                this.txtChallanNo.Enabled = false;
                this.chkDiscard.Text = "Discard Reason:";
                this.drpDiscardReason1.Visible = true;
                return;
            }
            this.txtChallanNo.Style.Add("width", "150px");
            this.txtChallanNo.Enabled = true;
            this.chkDiscard.Text = "Discard";
            this.drpDiscardReason1.Visible = false;
        }

        private void clearAll()
        {
            this.lblfxdVT.Text = "";
            this.fnUnitPrice.Text = string.Empty;
            this.fnSD.Text = string.Empty;
            this.fnVat.Text = string.Empty;
            this.fnTotal.Text = string.Empty;
            this.LoadCategory("C");
            this.drpSubCategory.Items.Clear();
            ListItem listItem = new ListItem("--- Select ---", "-99");
            this.drpSubCategory.Items.Insert(0, listItem);
            this.drpItem.SelectedValue = "-99";
            this.lblHSCode.Text = "";
            this.txtQuantity.Text = "";
            this.drpUnit.Items.Clear();
            this.txtRemark.Text = "";
            this.txtSaleSD.Text = "";
            this.txtSaleUnitPrice.Text = "";
            this.txtSaleVat.Text = "";
            this.txtSaleVatablePrice.Text = "";
            this.lblProperty1.Visible = false;
            this.drpProperty1.Visible = false;
            this.lblProperty2.Visible = false;
            this.drpProperty2.Visible = false;
            this.lblProperty3.Visible = false;
            this.drpProperty3.Visible = false;
            this.lblProperty4.Visible = false;
            this.drpProperty4.Visible = false;
            this.lblProperty5.Visible = false;
            this.drpProperty5.Visible = false;
            this.drpProperty1.Items.Clear();
            this.drpProperty2.Items.Clear();
            this.drpProperty3.Items.Clear();
            this.drpProperty4.Items.Clear();
            this.drpProperty5.Items.Clear();
            this.lblSaleVat.Text = "";
            this.lblSaleSD.Text = "";
            this.txtBatchNo.Text = "";
            this.txtExpDate.Text = "";
            this.txtMfgDate.Text = "";
            this.lblAvailableQuantity.Text = "";
        }

        private void clearMasterData()
        {
            this.ddlProvidedChallan.SelectedValue = "-1";
            this.drpParty.SelectedValue = "-99";
            this.txtAddress.Text = "";
            this.txtPartyBIN.Text = "";
            this.txtChallanNo.Text = "";
            this.chkDiscard.Checked = false;
            this.lblDiscardReason.Visible = false;
            this.drpDiscardReason.SelectedValue = "-99";
            this.drpDiscardReason.Visible = false;
            this.txtScroll.Text = "";
            this.drpChDtHr.SelectedIndex = 0;
            this.drpChDtMin.SelectedIndex = 0;
            this.drpRole.SelectedIndex = 0;
            this.Session["CP_DETAIL"] = new ArrayList();
            this.Session["CP_DETAIL_Save"] = new ArrayList();
            this.loadGridView();
            this.Session["CP_DETAIL_MAIN"] = new ArrayList();
            this.loadMainGridView();
        }

        protected void ddlProvidedChallan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpItem.Items.Clear();
            string str = this.ddlProvidedChallan.SelectedItem.ToString();
            int num = 0;
            AddItemBLL addItemBLL = new AddItemBLL();
            DataTable finishGoodsProductByCategoryIdPrChallan = null;
            try
            {
                this.lblHSCode.Text = "";
                this.txtBatchNo.Text = "";
                this.txtExpDate.Text = "";
                this.txtMfgDate.Text = "";
                this.drpUnit.ClearSelection();
                if (this.drpCategory.SelectedValue == "-99" && this.drpSubCategory.SelectedValue == "-99")
                {
                    num = 0;
                }
                else if (this.drpCategory.SelectedValue != "-99" && this.drpSubCategory.SelectedValue == "-99")
                {
                    num = Convert.ToInt32(this.drpCategory.SelectedValue);
                }
                else if (this.drpCategory.SelectedValue != "-99" && this.drpSubCategory.SelectedValue != "-99")
                {
                    num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                }
                finishGoodsProductByCategoryIdPrChallan = addItemBLL.getFinishGoodsProductByCategoryIdPrChallan(num, str);
                if (finishGoodsProductByCategoryIdPrChallan.Rows.Count <= 0)
                {
                    finishGoodsProductByCategoryIdPrChallan = addItemBLL.getProductByCategoryIdPrChallan(num, str);
                    if (finishGoodsProductByCategoryIdPrChallan.Rows.Count > 0)
                    {
                        this.drpItem.DataSource = finishGoodsProductByCategoryIdPrChallan;
                        this.drpItem.DataTextField = finishGoodsProductByCategoryIdPrChallan.Columns["item_name"].ToString();
                        this.drpItem.DataValueField = finishGoodsProductByCategoryIdPrChallan.Columns["Item_id"].ToString();
                        this.drpItem.DataBind();
                        Label label = this.priceDecId;
                        Label label1 = this.priceDecId;
                        string str1 = finishGoodsProductByCategoryIdPrChallan.Rows[0]["price_id"].ToString();
                        string str2 = str1;
                        label1.Text = str1;
                        label.Text = str2;
                    }
                }
                else
                {
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdPrChallan;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdPrChallan.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdPrChallan.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    this.priceDecId.Text = finishGoodsProductByCategoryIdPrChallan.Rows[0]["price_id"].ToString();
                }
                ListItem listItem = new ListItem("---Select---", "-99");
                this.drpItem.Items.Insert(0, listItem);
                this.Session["ITEM_INFO"] = finishGoodsProductByCategoryIdPrChallan;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadSubCategory();
                this.loadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpChDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpChDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Label9.Text = "%";
                string str = this.ddlProvidedChallan.SelectedItem.ToString();
                this.drpItem.SelectedItem.ToString();
                string selectedValue = this.drpItem.SelectedValue;
                if (this.drpItem.SelectedValue != "-99")
                {
                    string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                    if (strArrays != null && strArrays.Count<string>() > 0)
                    {
                        this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 1];
                    }
                    int num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable item = (DataTable)this.Session["ITEM_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("item_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.lblProductType.Text = dataRow["PRODUCT_TYPE"].ToString();
                    }
                    DataTable info = this.objCPBLL.getInfo(num, str);
                    if (info.Rows.Count > 0)
                    {
                        if (info.Rows[0]["mfg_date"].ToString() != DateTime.MinValue.ToString())
                        {
                            TextBox textBox = this.txtMfgDate;
                            DateTime dateTime = Convert.ToDateTime(info.Rows[0]["mfg_date"]);
                            textBox.Text = dateTime.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            this.txtMfgDate.Text = "";
                        }
                        if (info.Rows[0]["expiry_date"].ToString() != DateTime.MinValue.ToString())
                        {
                            TextBox str1 = this.txtExpDate;
                            DateTime dateTime1 = Convert.ToDateTime(info.Rows[0]["expiry_date"]);
                            str1.Text = dateTime1.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            this.txtExpDate.Text = "";
                        }
                        this.txtBatchNo.Text = info.Rows[0]["batch_no"].ToString();
                    }
                    this.getAvailableStock();
                    this.getAllProperty();
                    this.EnableOrDisablePropertyForItem();
                    this.fillCatSubCat();
                    this.GetPriceInfo();
                    this.GetVatSdPrice();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            DataTable dataTable = new DataTable();
            int num = 0;
            try
            {
                if (this.drpParty.SelectedValue != "-99")
                {
                    int num1 = Convert.ToInt32(this.drpParty.SelectedValue);
                    DataTable item = (DataTable)this.Session["PARTY_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("party_id = ", num1));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.txtAddress.Text = dataRow["party_address"].ToString();
                        this.txtPartyBIN.Text = dataRow["party_bin"].ToString();
                    }
                    if (this.drpRole.SelectedIndex == 0)
                    {
                        dataTable = addItemBLL.GetFinishProductByPartyID(num1);
                    }
                    item = this.objCPBLL.GetProductionChallanNobyPartyId(num1);
                    if (item != null && item.Rows.Count > 0)
                    {
                        for (int i = 0; i < item.Rows.Count; i++)
                        {
                            num = Convert.ToInt32(item.Rows[i]["challan_id"]);
                            DataTable availStockforProduction = this.objBLL.getAvailStockforProduction(num);
                            if (availStockforProduction.Rows.Count > 0 && availStockforProduction.Rows[0]["quantity"].ToString() == "0.0000")
                            {
                                item.Rows[i].Delete();
                            }
                        }
                        item.AcceptChanges();
                        this.ddlProvidedChallan.DataSource = item;
                        this.ddlProvidedChallan.DataTextField = item.Columns["challan_no"].ToString();
                        this.ddlProvidedChallan.DataValueField = item.Columns["challan_id"].ToString();
                        this.ddlProvidedChallan.DataBind();
                        ListItem listItem = new ListItem("-- SELECT --", "-1");
                        this.ddlProvidedChallan.Items.Insert(0, listItem);
                    }
                }
                this.Session["ITEM_INFO"] = dataTable;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpProp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.stickWiseQuantity();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.stickWiseQuantity();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProp3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.stickWiseQuantity();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProp4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.stickWiseQuantity();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProp5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.stickWiseQuantity();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if (this.drpRole.SelectedIndex == 0)
                {
                    str = "C";
                }
                if (this.drpRole.SelectedIndex == 1)
                {
                    str = "P";
                }
                if (this.drpRole.SelectedIndex == 2)
                {
                    str = "R";
                }
                this.LoadCategory(str);
                this.loadSubCategory();
                this.loadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                this.stickWiseQuantity();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ReallySimpleLog.WriteLog(exception);
                throw exception;
            }
        }

        private void EnableOrDisablePropertyForItem()
        {
            if (!string.IsNullOrEmpty(this.drpItem.SelectedValue))
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = 0;
                if (this.drpItem.SelectedValue != "-99")
                {
                    num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(num);
                    this.hdUnitID.Value = itemRequiredProperty.Rows[0]["unit_id"].ToString();
                    this.lblUID.Text = itemRequiredProperty.Rows[0]["unit_id"].ToString();
                    this.lblUnitCode.Text = itemRequiredProperty.Rows[0]["unit_code"].ToString();
                    this.hdItemType.Value = itemRequiredProperty.Rows[0]["item_type"].ToString();
                    HiddenField str = this.hdProp1;
                    int num1 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop1_required"]);
                    str.Value = num1.ToString();
                    HiddenField hiddenField = this.hdProp2;
                    int num2 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop2_required"]);
                    hiddenField.Value = num2.ToString();
                    HiddenField str1 = this.hdProp3;
                    int num3 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop3_required"]);
                    str1.Value = num3.ToString();
                    HiddenField hiddenField1 = this.hdProp4;
                    int num4 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop4_required"]);
                    hiddenField1.Value = num4.ToString();
                    HiddenField str2 = this.hdProp5;
                    int num5 = Convert.ToInt32(itemRequiredProperty.Rows[0]["prop5_required"]);
                    str2.Value = num5.ToString();
                    this.GetUnitName(Convert.ToInt32(this.hdUnitID.Value));
                    Convert.ToBoolean(itemRequiredProperty.Rows[0]["is_vds"]);
                    short num6 = 0;
                    short num7 = 0;
                    short num8 = 0;
                    short num9 = 0;
                    short num10 = 0;
                    DataTable appCodeDetailName = null;
                    num6 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id1"]);
                    num7 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id2"]);
                    num8 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id3"]);
                    num9 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id4"]);
                    num10 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id5"]);
                    DataTable itemProperty = addItemBLL.getItemProperty(num6);
                    if (itemProperty != null && itemProperty.Rows.Count > 0)
                    {
                        this.drpProperty1.DataSource = itemProperty;
                        this.drpProperty1.DataTextField = itemProperty.Columns["property_name"].ToString();
                        this.drpProperty1.DataValueField = itemProperty.Columns["property_id"].ToString();
                        this.drpProperty1.DataBind();
                        ListItem listItem = new ListItem("---Select---", "-99");
                        this.drpProperty1.Items.Insert(0, listItem);
                        this.drpProperty1.Visible = true;
                        this.lblProperty1.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num6);
                        this.lblProperty1.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable = addItemBLL.getItemProperty(num7);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpProperty2.DataSource = dataTable;
                        this.drpProperty2.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProperty2.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProperty2.DataBind();
                        ListItem listItem1 = new ListItem("---Select---", "-99");
                        this.drpProperty2.Items.Insert(0, listItem1);
                        this.drpProperty2.Visible = true;
                        this.lblProperty2.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num7);
                        this.lblProperty2.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty1 = addItemBLL.getItemProperty(num8);
                    if (itemProperty1 != null && itemProperty1.Rows.Count > 0)
                    {
                        this.drpProperty3.DataSource = itemProperty1;
                        this.drpProperty3.DataTextField = itemProperty1.Columns["property_name"].ToString();
                        this.drpProperty3.DataValueField = itemProperty1.Columns["property_id"].ToString();
                        this.drpProperty3.DataBind();
                        ListItem listItem2 = new ListItem("---Select---", "-99");
                        this.drpProperty3.Items.Insert(0, listItem2);
                        this.drpProperty3.Visible = true;
                        this.lblProperty3.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num8);
                        this.lblProperty3.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable1 = addItemBLL.getItemProperty(num9);
                    if (dataTable1 != null && dataTable1.Rows.Count > 0)
                    {
                        this.drpProperty4.DataSource = dataTable1;
                        this.drpProperty4.DataTextField = dataTable1.Columns["property_name"].ToString();
                        this.drpProperty4.DataValueField = dataTable1.Columns["property_id"].ToString();
                        this.drpProperty4.DataBind();
                        ListItem listItem3 = new ListItem("---Select---", "-99");
                        this.drpProperty4.Items.Insert(0, listItem3);
                        this.drpProperty4.Visible = true;
                        this.lblProperty4.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num9);
                        this.lblProperty4.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty2 = addItemBLL.getItemProperty(num10);
                    if (itemProperty2 != null && itemProperty2.Rows.Count > 0)
                    {
                        this.drpProperty5.DataSource = itemProperty2;
                        this.drpProperty5.DataTextField = itemProperty2.Columns["property_name"].ToString();
                        this.drpProperty5.DataValueField = itemProperty2.Columns["property_id"].ToString();
                        this.drpProperty5.DataBind();
                        ListItem listItem4 = new ListItem("---Select---", "-99");
                        this.drpProperty5.Items.Insert(0, listItem4);
                        this.drpProperty5.Visible = true;
                        this.lblProperty5.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num10);
                        this.lblProperty5.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                }
            }
        }

        private void fillCatSubCat()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = 0;
            if (this.drpItem.SelectedValue == "-99")
            {
                this.drpCategory.SelectedValue = "-99";
                this.drpSubCategory.SelectedValue = "-99";
                return;
            }
            num = Convert.ToInt32(this.drpItem.SelectedValue);
            DataTable allFieldByItemId = addItemBLL.getAllFieldByItemId(num);
            this.lblProductType.Text = allFieldByItemId.Rows[0]["item_type"].ToString();
            this.drpCategory.DataSource = allFieldByItemId;
            this.drpCategory.DataTextField = allFieldByItemId.Columns["category_name"].ToString();
            this.drpCategory.DataValueField = allFieldByItemId.Columns["category_id"].ToString();
            this.drpCategory.DataBind();
            this.drpSubCategory.DataSource = allFieldByItemId;
            this.drpSubCategory.DataTextField = allFieldByItemId.Columns["sub_category_name"].ToString();
            this.drpSubCategory.DataValueField = allFieldByItemId.Columns["sub_category_id"].ToString();
            this.drpSubCategory.DataBind();
        }

        private void getAllProperty()
        {
            try
            {
                ProductTransferBLL productTransferBLL = new ProductTransferBLL();
                int num = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable dataTable = productTransferBLL.fillProperty(num);
                if (dataTable != null)
                {
                    this.lblProp1.Text = dataTable.Rows[0]["property1"].ToString();
                    this.lblProp2.Text = dataTable.Rows[0]["property2"].ToString();
                    this.lblProp3.Text = dataTable.Rows[0]["property3"].ToString();
                    this.lblProp4.Text = dataTable.Rows[0]["property4"].ToString();
                    this.lblProp5.Text = dataTable.Rows[0]["property5"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getAllPropertyByID(int itemId)
        {
            try
            {
                DataTable dataTable = (new ProductTransferBLL()).fillProperty(itemId);
                if (dataTable != null)
                {
                    this.lblProp1.Text = dataTable.Rows[0]["property1"].ToString();
                    this.lblProp2.Text = dataTable.Rows[0]["property2"].ToString();
                    this.lblProp3.Text = dataTable.Rows[0]["property3"].ToString();
                    this.lblProp4.Text = dataTable.Rows[0]["property4"].ToString();
                    this.lblProp5.Text = dataTable.Rows[0]["property5"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getAvailableStock()
        {
            SaleBLL saleBLL = new SaleBLL();
            try
            {
                int num = Convert.ToInt32(this.ddlProvidedChallan.SelectedValue);
                DataTable availStockforProduction = saleBLL.getAvailStockforProduction(num);
                if (availStockforProduction.Rows != null)
                {
                    this.lblAvailableQuantity.Text = Utilities.RoundUpToWithString(Convert.ToDecimal(availStockforProduction.Rows[0]["quantity"].ToString()), 2);
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
                int num = Convert.ToInt32(this.Session["empId"].ToString());
                int num1 = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num2 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num3 = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                if (num3 <= 0)
                {
                    num3 = 0;
                }
                if (num1 == 3)
                {
                    this.drpBranchName.Enabled = false;
                    if (num2 != 0)
                    {
                        DataTable branchInformation = challanBLL.GetBranchInformation(num3, num2);
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
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
                if (num1 == 2 || num1 == 1)
                {
                    this.drpBranchName.Enabled = true;
                    DataTable branchInformationFormanagerN = challanBLL.GetBranchInformationFormanagerN(num3, num, num2);
                    if (branchInformationFormanagerN == null || branchInformationFormanagerN.Rows.Count <= 0)
                    {
                        ListItem listItem1 = new ListItem("Head Office", "0");
                        this.drpBranchName.Items.Insert(0, listItem1);
                    }
                    else
                    {
                        this.drpBranchName.DataSource = branchInformationFormanagerN;
                        this.drpBranchName.DataTextField = branchInformationFormanagerN.Columns["branch_unit_name"].ToString();
                        this.drpBranchName.DataValueField = branchInformationFormanagerN.Columns["org_branch_reg_id"].ToString();
                        this.drpBranchName.DataBind();
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
            }
        }

        private void getChallanNo()
        {
            CraDebBLL craDebBLL = new CraDebBLL();
            int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            short num1 = Convert.ToInt16(this.drpBranchName.SelectedValue);
            DataTable creditNoteNo = craDebBLL.GetCreditNoteNo(11, num, num1);
            if (creditNoteNo == null || creditNoteNo.Rows.Count <= 0)
            {
                this.txtChallanNo.Text = "";
                this.hdBookId.Value = "";
                this.hdPageNo.Value = "";
                return;
            }
            this.txtChallanNo.Text = creditNoteNo.Rows[0]["challan_no"].ToString();
            this.hdBookId.Value = creditNoteNo.Rows[0]["challan_book_id"].ToString();
            this.hdPageNo.Value = creditNoteNo.Rows[0]["page_no"].ToString();
        }

        private void getCPDetailData()
        {
            ArrayList item = (ArrayList)this.Session["CP_DETAIL_MAIN"] ?? new ArrayList();
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            short num = 0;
            contructualProductionIssueDAO.ItemName = this.drpItem.SelectedItem.ToString();
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            if (item.Count <= 0)
            {
                this.getCPDetailData_load(contructualProductionIssueDAO, item, num, this.quantity_global_to_sum, num1, num2);
            }
            else
            {
                ContructualProductionIssueDAO contructualProductionIssueDAO1 = new ContructualProductionIssueDAO();
                for (int i = 0; i < item.Count; i++)
                {
                    contructualProductionIssueDAO1 = (ContructualProductionIssueDAO)item[i];
                    if (contructualProductionIssueDAO1.ItemName == contructualProductionIssueDAO.ItemName)
                    {
                        this.quantity_global_to_sum = Convert.ToDecimal(contructualProductionIssueDAO1.Quantity);
                        num1 = Convert.ToDecimal(contructualProductionIssueDAO1.SaleVat);
                        num2 = Convert.ToDecimal(contructualProductionIssueDAO1.SaleVatablePrice);
                        item.RemoveAt(i);
                    }
                }
                this.getCPDetailData_load(contructualProductionIssueDAO, item, num, this.quantity_global_to_sum, num1, num2);
            }
            this.Session["CP_DETAIL_MAIN"] = item;
        }

        private void getCPDetailData_load(ContructualProductionIssueDAO objCP, ArrayList arrayList, short rowNo, decimal quantity, decimal Vat, decimal Vatable_Price)
        {
            rowNo = Convert.ToInt16(arrayList.Count + 1);
            objCP.RowNo = rowNo;
            objCP.CategoryName = this.drpCategory.SelectedItem.ToString();
            objCP.SubCategoryName = this.drpSubCategory.SelectedItem.ToString();
            objCP.Item_id = Convert.ToInt32(this.drpItem.SelectedValue);
            if (!(this.drpProperty1.SelectedValue != "-99") || !(this.drpProperty1.SelectedValue != ""))
            {
                objCP.Property_id1 = 0;
            }
            else
            {
                objCP.Property_id1 = Convert.ToInt16(this.drpProperty1.SelectedValue);
                objCP.Property1_Text = this.drpProperty1.SelectedItem.ToString();
            }
            if (!(this.drpProperty2.SelectedValue != "-99") || !(this.drpProperty2.SelectedValue != ""))
            {
                objCP.Property_id2 = 0;
            }
            else
            {
                objCP.Property_id2 = Convert.ToInt16(this.drpProperty2.SelectedValue);
                objCP.Property2_Text = this.drpProperty2.SelectedItem.ToString();
            }
            if (!(this.drpProperty3.SelectedValue != "-99") || !(this.drpProperty3.SelectedValue != ""))
            {
                objCP.Property_id3 = 0;
            }
            else
            {
                objCP.Property_id3 = Convert.ToInt16(this.drpProperty3.SelectedValue);
                objCP.Property3_Text = this.drpProperty3.SelectedItem.ToString();
            }
            if (!(this.drpProperty4.SelectedValue != "-99") || !(this.drpProperty4.SelectedValue != ""))
            {
                objCP.Property_id4 = 0;
            }
            else
            {
                objCP.Property_id4 = Convert.ToInt16(this.drpProperty4.SelectedValue);
                objCP.Property4_Text = this.drpProperty4.SelectedItem.ToString();
            }
            if (!(this.drpProperty5.SelectedValue != "-99") || !(this.drpProperty5.SelectedValue != ""))
            {
                objCP.Property_id5 = 0;
            }
            else
            {
                objCP.Property_id5 = Convert.ToInt16(this.drpProperty5.SelectedValue);
                objCP.Property5_Text = this.drpProperty5.SelectedItem.ToString();
            }
            objCP.UnitName = this.drpUnit.SelectedItem.ToString();
            objCP.Unit_id = Convert.ToInt16(this.lblUID.Text);
            if ((Convert.ToDecimal(this.txtFinalQuantity.Text) + quantity) <= Convert.ToDecimal(this.lblAvailableQuantity.Text))
            {
                objCP.Quantity = Convert.ToDecimal(this.txtFinalQuantity.Text) + quantity;
                objCP.SaleVatablePrice = Convert.ToDouble(this.txtSaleVatablePrice.Text.Trim()) + Convert.ToDouble(Vatable_Price);
                objCP.SaleVat = (!string.IsNullOrEmpty(this.txtSaleVat.Text) ? Convert.ToDouble(this.txtSaleVat.Text.Trim()) + Convert.ToDouble(Vat) : 0);
            }
            else
            {
                this.msgBox.AddMessage("Quantity is not available", MsgBoxs.enmMessageType.Attention);
                objCP.Quantity = quantity;
                objCP.SaleVatablePrice = Convert.ToDouble(Vatable_Price);
                objCP.SaleVat = Convert.ToDouble(Vat);
            }
            objCP.SaleUnitPrice = Convert.ToDouble(this.txtSaleUnitPrice.Text.Trim());
            objCP.SpReturn = 3;
            objCP.VatRate = (!string.IsNullOrEmpty(this.lblSaleVat.Text) ? Convert.ToDouble(this.lblSaleVat.Text.Trim()) : 0);
            objCP.SDRate = (!string.IsNullOrEmpty(this.lblSaleSD.Text) ? Convert.ToDouble(this.lblSaleSD.Text.Trim()) : 0);
            objCP.Batch_no = (!string.IsNullOrEmpty(this.txtBatchNo.Text) ? this.txtBatchNo.Text : "");
            objCP.PurchaseType = 'F';
            if (string.IsNullOrEmpty(this.txtExpDate.Text.Trim()))
            {
                objCP.ExpiryDate = DateTime.MinValue;
            }
            else
            {
                objCP.ExpiryDate = DateTime.ParseExact(this.txtExpDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (string.IsNullOrEmpty(this.txtMfgDate.Text.Trim()))
            {
                objCP.MfgDate = DateTime.MinValue;
            }
            else
            {
                objCP.MfgDate = DateTime.ParseExact(this.txtMfgDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            objCP.PurchaseUnitPrice = (!string.IsNullOrEmpty(this.fnUnitPrice.Text) ? Convert.ToDouble(this.fnUnitPrice.Text.Trim()) : 1);
            objCP.PurchaseVat = (!string.IsNullOrEmpty(this.fnVat.Text) ? Convert.ToDouble(this.fnVat.Text.Trim()) : 0);
            objCP.PurchaseSD = (!string.IsNullOrEmpty(this.fnSD.Text) ? Convert.ToDouble(this.fnSD.Text.Trim()) : 0);
            objCP.TotalPrice = (!string.IsNullOrEmpty(this.fnTotal.Text) ? Convert.ToDouble(this.fnTotal.Text.Trim()) : 1);
            this.Session["production_quantity"] = Convert.ToDecimal(this.txtQuantity.Text);
            objCP.PreQuantity = Convert.ToDecimal(this.txtQuantity.Text);
            this.Session["production_unit"] = Convert.ToInt16(this.drpUnit.SelectedValue);
            this.Session["production_sale_unit_price"] = Convert.ToDecimal(this.txtSaleUnitPrice.Text.Trim());
            objCP.Status = 'R';
            objCP.Remark = this.txtRemark.Text;
            objCP.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
            arrayList.Add(objCP);
            this.Session["ITEM_ID"] = objCP.Item_id;
            this.Session["Batch_No"] = objCP.Batch_no;
            this.Session["Exp_Date"] = objCP.ExpiryDate.ToString("dd/MM/yyyy");
            this.Session["Mfg_Date"] = objCP.MfgDate.ToString("dd/MM/yyyy");
            this.Session["remarks"] = objCP.Remark;
        }

        private ContructualProductionIssueMasterDAO getCPMasterData(ContructualProductionIssueMasterDAO objCPMaster)
        {
            try
            {
                objCPMaster.OrgName = this.lt_companyName.Text;
                objCPMaster.ChallanIssueAddress = this.It_companyAddress.Text;
                objCPMaster.OrgBIN = this.lblOrgBIN.Text;
                objCPMaster.Batch_no = this.Session["Batch_No"].ToString();
                objCPMaster.ExpiryDate = DateTime.ParseExact(this.Session["Exp_Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objCPMaster.MfgDate = DateTime.ParseExact(this.Session["Mfg_Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (!this.drpParty.Enabled)
                {
                    objCPMaster.IsNewParty = true;
                    objCPMaster.PartyAddress = this.txtAddress.Text.ToString();
                    objCPMaster.PartyBIN = this.txtPartyBIN.Text.ToString();
                }
                else if (this.drpParty.SelectedValue != "-99")
                {
                    objCPMaster.IsNewParty = false;
                    objCPMaster.PartyName = this.drpParty.SelectedItem.ToString();
                    objCPMaster.PartyAddress = this.txtAddress.Text.ToString();
                    objCPMaster.PartyBIN = this.txtPartyBIN.Text.ToString();
                    objCPMaster.Party_id = Convert.ToInt16(this.drpParty.SelectedValue);
                }
                int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                objCPMaster.BranchID = num;
                objCPMaster.PorvidedChallanNo = (!string.IsNullOrEmpty(this.ddlProvidedChallan.SelectedValue) ? Convert.ToInt32(this.ddlProvidedChallan.SelectedValue) : 0);
                objCPMaster.Challan_batch_no = this.txtChallanNo.Text;
                DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objCPMaster.Production_year = Convert.ToInt16(dateTime.ToString("yyyy"));
                string[] strArrays = new string[] { this.txtChallanDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                objCPMaster.Date_production = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (this.drpRole.SelectedIndex == 0)
                {
                    objCPMaster.Material_type = 'C';
                }
                else if (this.drpRole.SelectedIndex == 1)
                {
                    objCPMaster.Material_type = 'P';
                }
                else if (this.drpRole.SelectedIndex == 2)
                {
                    objCPMaster.Material_type = 'R';
                }
                if (this.chkDiscard.Checked)
                {
                    objCPMaster.Discard_reason = Convert.ToInt16(this.drpDiscardReason.SelectedValue);
                }
                objCPMaster.ChallanPageNo = Convert.ToInt32(this.hdPageNo.Value.ToString());
                objCPMaster.ChallanBookId = Convert.ToInt32(this.hdBookId.Value.ToString());
                objCPMaster.Audit_user_id = Convert.ToInt16(this.Session["employee_id"]);
                objCPMaster.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
                objCPMaster.Organization_id = Convert.ToInt16(this.Session["organization_id"]);
                objCPMaster.Status = 'R';
                objCPMaster.PurchaseType = 'F';
                objCPMaster.ScrollNo = this.txtScroll.Text.ToString();
                objCPMaster.IssueTime = string.Concat(this.drpChDtHr.Text, " : ", this.drpChDtMin.Text);
                objCPMaster.FinishProductID = Convert.ToInt64(this.Session["ITEM_ID"]);
                objCPMaster.Remarks = this.Session["remarks"].ToString();
                objCPMaster.Production_Quantity = Convert.ToDecimal(this.Session["production_quantity"]);
                objCPMaster.Production_Unit = Convert.ToInt16(this.Session["production_unit"]);
                objCPMaster.Production_Sale_Unit_Price = Convert.ToDecimal(this.Session["production_sale_unit_price"]);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["MASTER_DATA"] = objCPMaster;
            return objCPMaster;
        }

        private void GetPriceInfo()
        {
            try
            {
                SaleDetailDAO saleDetailDAO = new SaleDetailDAO()
                {
                    ItemID = Convert.ToInt32(this.drpItem.SelectedValue)
                };
                if (saleDetailDAO.ItemID != -99)
                {
                    DataTable priceInfoOfItem = (new SaleBLL()).GetPriceInfoOfItem(saleDetailDAO);
                    string empty = string.Empty;
                    if (priceInfoOfItem == null)
                    {
                        this.lblSaleSD.Text = "0.00";
                        this.lblSaleVat.Text = "0.00";
                        this.hdPriceID.Value = "";
                    }
                    else if (priceInfoOfItem.Rows.Count <= 0)
                    {
                        this.lblSaleSD.Text = "0.00";
                        this.lblSaleVat.Text = "0.00";
                        this.hdPriceID.Value = "";
                    }
                    else
                    {
                        empty = priceInfoOfItem.Rows[0]["PER"].ToString();
                        this.lblSaleSD.Text = priceInfoOfItem.Rows[0]["SD_RATE"].ToString();
                        this.lblfxdVT.Text = "Tk. ";
                        this.lblSaleVat.Text = priceInfoOfItem.Rows[0]["VAT_RATE"].ToString();
                        this.hdPriceID.Value = priceInfoOfItem.Rows[0]["price_id"].ToString();
                        if (empty == "1")
                        {
                            this.Label9.Text = " Per Unit";
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getProductInfo()
        {
        }

        private void GetTotalSaleValue()
        {
            try
            {
                int num = 0;
                if (this.gvMainItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvMainItem.Rows.Count; i++)
                    {
                        num += Convert.ToInt32(this.gvMainItem.Rows[i].Cells[11].Text.Trim());
                    }
                }
                this.lblquantity.Text = num.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void GetUnitName(int unitID)
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
                this.drpUnit.SelectedValue = unitID.ToString();
            }
        }

        private void getUsedQuantity()
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            ArrayList arrayLists = new ArrayList();
            decimal num = new decimal(0);
            int num1 = 0;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            short num5 = 0;
            string str = "";
            int num6 = 0;
            long num7 = (long)0;
            short num8 = 0;
            int num9 = 0;
            int num10 = 0;
            try
            {
                num = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                if (this.drpItem.SelectedValue != "-99")
                {
                    num1 = Convert.ToInt32(this.drpItem.SelectedValue);
                }
                if (this.drpParty.SelectedValue != "-99")
                {
                    num7 = (long)Convert.ToInt32(this.drpParty.SelectedValue);
                }
                num10 = Convert.ToInt16(this.ddlProvidedChallan.SelectedValue);
                DataTable priceDeclarationNo = contructualProductionBLL.GetPriceDeclarationNo(num10);
                int num11 = Convert.ToInt32(priceDeclarationNo.Rows[0]["price_id"].ToString());
                DataTable quantityToMadePerProductOwn = contructualProductionBLL.GetQuantityToMadePerProductOwn(num1, num9, num11);
                if (quantityToMadePerProductOwn.Rows.Count > 0)
                {
                    for (int i = 0; i < quantityToMadePerProductOwn.Rows.Count; i++)
                    {
                        ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                        num3 = Convert.ToDecimal(quantityToMadePerProductOwn.Rows[i]["quantity"].ToString());
                        num6 = Convert.ToInt32(quantityToMadePerProductOwn.Rows[i]["item_id"].ToString());
                        str = quantityToMadePerProductOwn.Rows[i]["item_name"].ToString();
                        num2 = num * num3;
                        this.getAllPropertyByID(num6);
                        DataTable provideQuantityForProductSingleItem = contructualProductionBLL.GetProvideQuantityForProductSingleItem(num6, num7);
                        if (provideQuantityForProductSingleItem.Rows.Count > 0)
                        {
                            num4 = Convert.ToDecimal(provideQuantityForProductSingleItem.Rows[0]["quantity"].ToString());
                            num5 = Convert.ToInt16(provideQuantityForProductSingleItem.Rows[0]["unit_id"].ToString());
                            contructualProductionIssueDAO.SubCategoryName = provideQuantityForProductSingleItem.Rows[0]["category_name"].ToString();
                        }
                        contructualProductionIssueDAO.UnitName = provideQuantityForProductSingleItem.Rows[0]["unit_code"].ToString();
                        num8 = Convert.ToInt16(i + 1);
                        contructualProductionIssueDAO.Item_id = num6;
                        contructualProductionIssueDAO.ItemName = str;
                        contructualProductionIssueDAO.Quantity = num2;
                        contructualProductionIssueDAO.Unit_id = num5;
                        contructualProductionIssueDAO.RowNo = num8;
                        contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
                        contructualProductionIssueDAO.Status = 'R';
                        contructualProductionIssueDAO.Remark = this.txtRemark.Text;
                        if (!(this.drpProperty1.SelectedValue != "-99") || !(this.drpProperty1.SelectedValue != ""))
                        {
                            contructualProductionIssueDAO.Property_id1 = 0;
                        }
                        else
                        {
                            contructualProductionIssueDAO.Property_id1 = Convert.ToInt16(this.drpProperty1.SelectedValue);
                        }
                        if (!(this.drpProperty2.SelectedValue != "-99") || !(this.drpProperty2.SelectedValue != ""))
                        {
                            contructualProductionIssueDAO.Property_id2 = 0;
                        }
                        else
                        {
                            contructualProductionIssueDAO.Property_id2 = Convert.ToInt16(this.drpProperty2.SelectedValue);
                        }
                        if (!(this.drpProperty3.SelectedValue != "-99") || !(this.drpProperty3.SelectedValue != ""))
                        {
                            contructualProductionIssueDAO.Property_id3 = 0;
                        }
                        else
                        {
                            contructualProductionIssueDAO.Property_id3 = Convert.ToInt16(this.drpProperty3.SelectedValue);
                        }
                        if (!(this.drpProperty4.SelectedValue != "-99") || !(this.drpProperty4.SelectedValue != ""))
                        {
                            contructualProductionIssueDAO.Property_id4 = 0;
                        }
                        else
                        {
                            contructualProductionIssueDAO.Property_id4 = Convert.ToInt16(this.drpProperty4.SelectedValue);
                        }
                        if (!(this.drpProperty5.SelectedValue != "-99") || !(this.drpProperty5.SelectedValue != ""))
                        {
                            contructualProductionIssueDAO.Property_id5 = 0;
                        }
                        else
                        {
                            contructualProductionIssueDAO.Property_id5 = Convert.ToInt16(this.drpProperty5.SelectedValue);
                        }
                        arrayLists.Add(contructualProductionIssueDAO);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["CP_DETAIL"] = arrayLists;
        }

        private void getUsedQuantityN()
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            ArrayList arrayLists = new ArrayList();
            try
            {
                decimal num = new decimal(0);
                int num1 = 0;
                AddItemBLL addItemBLL = new AddItemBLL();
                num = ((Convert.ToDecimal(this.txtFinalQuantity.Text) + this.quantity_global_to_sum) <= Convert.ToDecimal(this.lblAvailableQuantity.Text) ? Convert.ToDecimal(this.txtFinalQuantity.Text.Trim()) + this.quantity_global_to_sum : this.quantity_global_to_sum);
                if (this.drpItem.SelectedValue != "-99")
                {
                    num1 = Convert.ToInt32(this.drpItem.SelectedValue);
                }
                if (this.drpParty.SelectedValue != "-99")
                {
                    Convert.ToInt32(this.drpParty.SelectedValue);
                }
                DataTable quantityToMadePerProduct = contructualProductionBLL.GetQuantityToMadePerProduct(num1, (this.priceDecId.Text != "" ? Convert.ToInt32(this.priceDecId.Text) : 0));
                if (quantityToMadePerProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < quantityToMadePerProduct.Rows.Count; i++)
                    {
                        decimal num2 = new decimal(0);
                        decimal num3 = new decimal(0);
                        decimal num4 = new decimal(0);
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        decimal num7 = new decimal(0);
                        short num8 = 0;
                        short num9 = 0;
                        string str = "";
                        int num10 = 0;
                        decimal num11 = new decimal(0);
                        short num12 = 0;
                        decimal num13 = new decimal(0);
                        ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                        if (quantityToMadePerProduct.Rows[i]["unit_price"].ToString() != "")
                        {
                            Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["unit_price"]);
                        }
                        num8 = Convert.ToInt16(quantityToMadePerProduct.Rows[i]["unit_id"].ToString());
                        num9 = Convert.ToInt16(quantityToMadePerProduct.Rows[i]["actualUnit_id"].ToString());
                        num6 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["quantity"].ToString());
                        num10 = Convert.ToInt32(quantityToMadePerProduct.Rows[i]["item_id"].ToString());
                        str = quantityToMadePerProduct.Rows[i]["item_name"].ToString();
                        num11 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["production_quantity"]);
                        num5 = (num * num6) / num11;
                        num5 = Convert.ToDecimal(Utilities.RoundUpToWithString(num5, 2));
                        DataTable value = addItemBLL.GetValue(num9, num8);
                        if (value.Rows.Count > 0)
                        {
                            num2 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                        }
                        if (num2 > new decimal(0))
                        {
                            num4 = num5 / num2;
                        }
                        if (num2 == new decimal(0))
                        {
                            DataTable valueSec = addItemBLL.GetValueSec(num9, num8);
                            if (valueSec.Rows.Count <= 0)
                            {
                                num4 = num5;
                            }
                            else if (num3 <= new decimal(0))
                            {
                                num4 = num5;
                            }
                            else
                            {
                                num3 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                                num4 = num5 * num2;
                            }
                        }
                        contructualProductionIssueDAO.PreQuantity = num6;
                        num13 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["txtquantityprice"].ToString());
                        this.getAllPropertyByID(num10);
                        num12 = Convert.ToInt16(i + 1);
                        contructualProductionIssueDAO.Price = (num * num13) / num11;
                        contructualProductionIssueDAO.PriceValue = contructualProductionIssueDAO.Price.ToString("0.00");
                        contructualProductionIssueDAO.Item_id = num10;
                        contructualProductionIssueDAO.ItemName = str;
                        contructualProductionIssueDAO.Quantity = num4;
                        contructualProductionIssueDAO.Unit_id = num9;
                        contructualProductionIssueDAO.RowNo = num12;
                        contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
                        contructualProductionIssueDAO.Status = 'R';
                        contructualProductionIssueDAO.Remark = this.txtRemark.Text;
                        contructualProductionIssueDAO.Property_id1 = Convert.ToInt16(this.lblProp1.Text);
                        contructualProductionIssueDAO.Property_id2 = Convert.ToInt16(this.lblProp2.Text);
                        contructualProductionIssueDAO.Property_id3 = Convert.ToInt16(this.lblProp3.Text);
                        contructualProductionIssueDAO.Property_id4 = Convert.ToInt16(this.lblProp4.Text);
                        contructualProductionIssueDAO.Property_id5 = Convert.ToInt16(this.lblProp5.Text);
                        contructualProductionIssueDAO.CategoryName = quantityToMadePerProduct.Rows[i]["ctg_name"].ToString();
                        contructualProductionIssueDAO.SubCategoryName = quantityToMadePerProduct.Rows[i]["sub_ctg_name"].ToString();
                        contructualProductionIssueDAO.UnitName = quantityToMadePerProduct.Rows[i]["unit_code"].ToString();
                        contructualProductionIssueDAO.TotUnitName = quantityToMadePerProduct.Rows[i]["totqunitcode"].ToString();
                        arrayLists.Add(contructualProductionIssueDAO);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["CP_DETAIL"] = arrayLists;
        }

        private void getUsedQuantitySave()
        {
            ArrayList arrayLists = new ArrayList();
            ArrayList item = (ArrayList)this.Session["CP_DETAIL"];
            Convert.ToDecimal(this.txtFinalQuantity.Text.Trim());
            try
            {
                for (int i = 0; i < item.Count; i++)
                {
                    ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                    decimal num = new decimal(0);
                    ContructualProductionIssueDAO contructualProductionIssueDAO1 = new ContructualProductionIssueDAO();
                    contructualProductionIssueDAO1 = (ContructualProductionIssueDAO)item[i];
                    TextBox textBox = this.gvItem.Rows[i].FindControl("Quantity") as TextBox;
                    num = Convert.ToDecimal(textBox.Text);
                    contructualProductionIssueDAO.PreQuantity = contructualProductionIssueDAO1.PreQuantity;
                    contructualProductionIssueDAO.ProductionPrice = contructualProductionIssueDAO1.ProductionPrice;
                    contructualProductionIssueDAO.ProductionQuantity = contructualProductionIssueDAO1.ProductionQuantity;
                    contructualProductionIssueDAO.Price = Convert.ToDecimal(this.gvItem.Rows[i].Cells[12].Text);
                    contructualProductionIssueDAO.PriceValue = contructualProductionIssueDAO.Price.ToString("0.00");
                    contructualProductionIssueDAO.Item_id = contructualProductionIssueDAO1.Item_id;
                    contructualProductionIssueDAO.ItemName = contructualProductionIssueDAO1.ItemName;
                    contructualProductionIssueDAO.Quantity = num;
                    contructualProductionIssueDAO.Unit_id = contructualProductionIssueDAO1.Unit_id;
                    contructualProductionIssueDAO.RowNo = contructualProductionIssueDAO1.RowNo;
                    contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
                    contructualProductionIssueDAO.Status = 'R';
                    contructualProductionIssueDAO.Remark = contructualProductionIssueDAO1.Remark;
                    contructualProductionIssueDAO.Property_id1 = contructualProductionIssueDAO1.Property_id1;
                    contructualProductionIssueDAO.Property_id2 = contructualProductionIssueDAO1.Property_id2;
                    contructualProductionIssueDAO.Property_id3 = contructualProductionIssueDAO1.Property_id3;
                    contructualProductionIssueDAO.Property_id4 = contructualProductionIssueDAO1.Property_id4;
                    contructualProductionIssueDAO.Property_id5 = Convert.ToInt16(this.lblProp5.Text);
                    contructualProductionIssueDAO.CategoryName = contructualProductionIssueDAO1.CategoryName;
                    contructualProductionIssueDAO.SubCategoryName = contructualProductionIssueDAO1.SubCategoryName;
                    contructualProductionIssueDAO.UnitName = contructualProductionIssueDAO1.UnitName;
                    contructualProductionIssueDAO.TotUnitName = contructualProductionIssueDAO1.TotUnitName;
                    arrayLists.Add(contructualProductionIssueDAO);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["CP_DETAIL_Save"] = arrayLists;
        }

        private void GetVatSdPrice()
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            double vatSdPrice = 0;
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            double num4 = 0;
            double num5 = 0;
            double num6 = 0;
            try
            {
                num = Convert.ToDouble(this.lblSaleVat.Text.Trim());
                num1 = Convert.ToDouble(this.lblSaleSD.Text.Trim());
                if (this.drpItem.SelectedValue != "-99")
                {
                    int num7 = Convert.ToInt32(this.drpItem.SelectedValue);
                    vatSdPrice = contructualProductionBLL.getVatSdPrice((long)num7);
                    num5 = vatSdPrice * 100 / (100 + num);
                    num2 = vatSdPrice - num5;
                    num6 = num5 * 100 / (100 + num1);
                    num3 = num5 - num6;
                    num4 = num6;
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    decimal num10 = new decimal(0);
                    DataTable unitPriceFromPD = this.objCPBLL.GetUnitPriceFromPD(num7);
                    if (unitPriceFromPD.Rows.Count <= 0)
                    {
                        this.txtSaleUnitPrice.Text = vatSdPrice.ToString("0.00");
                    }
                    else
                    {
                        num8 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["prpsd_actl_prc"]);
                        num9 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["production_quantity"]);
                        num10 = num8 / num9;
                        this.txtSaleUnitPrice.Text = num10.ToString();
                    }
                    this.txtSaleVatablePrice.Text = num4.ToString("0.00");
                    this.txtSaleVat.Text = num2.ToString("0.00");
                    this.txtSaleSD.Text = num3.ToString("0.00");
                }
                this.Session["unit_price"] = this.txtSaleUnitPrice.Text;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private bool gridValidation()
        {
            if (this.drpCategory.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(" Select Category", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpSubCategory.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(" Select Sub-Category", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(" Select Item", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtQuantity.Text == "")
            {
                this.msgBox.AddMessage(" Enter Quantity", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtMfgDate.Text.ToString() != "" && this.txtExpDate.Text.ToString() != "" && DateTime.ParseExact(this.txtMfgDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(this.txtExpDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture))
            {
                this.msgBox.AddMessage("Manufacture Date must be less than Expiry Date", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty1.Visible && this.drpProperty1.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty1.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty2.Visible && this.drpProperty2.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty2.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty3.Visible && this.drpProperty3.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty3.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProperty4.Visible && this.drpProperty4.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty4.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (!this.drpProperty5.Visible || !(this.drpProperty5.SelectedValue == "-99"))
            {
                return true;
            }
            this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty5.Text.Trim()), MsgBoxs.enmMessageType.Attention);
            return false;
        }

        protected void gvItem_PreRender(object sender, EventArgs e)
        {
        }

        protected void gvItem_RowDataBound(object sender, EventArgs e)
        {
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["CP_DETAIL"];
                item.RemoveAt(e.RowIndex);
                this.Session["CP_DETAIL"] = item;
                this.loadGridView();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LoadCategory(string type)
        {
            List<Category> categories = new List<Category>();
            categories = (new AddItemBLL()).getCategory();
            if (categories != null)
            {
                this.drpCategory.DataSource = categories;
                this.drpCategory.DataTextField = "CatName";
                this.drpCategory.DataValueField = "CatID";
                this.drpCategory.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpCategory.Items.Insert(0, listItem);
            }
        }

        private void loadGridView()
        {
            this.gvItem.Visible = true;
            this.gvItem.DataSource = this.Session["CP_DETAIL"];
            this.gvItem.DataBind();
        }

        private void loadHours()
        {
            this.drpChDtHr.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
            }
        }

        private void loadItems()
        {
            int num = 0;
            AddItemBLL addItemBLL = new AddItemBLL();
            DataTable finishGoodsProductByCategoryId = null;
            try
            {
                if (this.drpCategory.SelectedValue == "-99" && this.drpSubCategory.SelectedValue == "-99")
                {
                    num = 0;
                }
                else if (this.drpCategory.SelectedValue != "-99" && this.drpSubCategory.SelectedValue == "-99")
                {
                    num = Convert.ToInt32(this.drpCategory.SelectedValue);
                }
                else if (this.drpCategory.SelectedValue != "-99" && this.drpSubCategory.SelectedValue != "-99")
                {
                    num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                }
                if (this.drpRole.SelectedIndex == 0)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getFinishGoodsProductByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem);
                }
                if (this.drpRole.SelectedIndex == 1)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getFinishGoodsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem1 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem1);
                }
                if (this.drpRole.SelectedIndex == 2)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getIngredientsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem2 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                }
                this.Session["ITEM_INFO"] = finishGoodsProductByCategoryId;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadMainGridView()
        {
            this.gvMainItem.Visible = true;
            this.gvMainItem.DataSource = this.Session["CP_DETAIL_MAIN"];
            this.gvMainItem.DataBind();
        }

        private void loadMinute()
        {
            this.drpChDtMin.Items.Add("00");
            for (int i = 1; i <= 59; i++)
            {
                this.drpChDtMin.Items.Add(i.ToString("00"));
            }
        }

        private void loadPertyInfo()
        {
            this.drpParty.Items.Clear();
            DataTable allMfgPartyInfo = (new ChallanBLL()).GetAllMfgPartyInfo();
            if (allMfgPartyInfo != null && allMfgPartyInfo.Rows.Count > 0)
            {
                this.drpParty.DataSource = allMfgPartyInfo;
                this.drpParty.DataTextField = allMfgPartyInfo.Columns["party_name"].ToString();
                this.drpParty.DataValueField = allMfgPartyInfo.Columns["party_id"].ToString();
                this.drpParty.DataBind();
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpParty.Items.Insert(0, listItem);
            this.Session["PARTY_INFO"] = allMfgPartyInfo;
        }

        private void loadSubCategory()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = 0;
                if (this.drpCategory.SelectedValue != null && this.drpCategory.SelectedValue != "-99")
                {
                    num = Convert.ToInt32(this.drpCategory.SelectedValue);
                }
                DataTable subcategoryByCategoryId = addItemBLL.getSubcategoryByCategoryId(num);
                if (subcategoryByCategoryId.Rows.Count > 0)
                {
                    this.drpSubCategory.DataSource = subcategoryByCategoryId;
                    this.drpSubCategory.DataTextField = subcategoryByCategoryId.Columns["CATEGORY_NAME"].ToString();
                    this.drpSubCategory.DataValueField = subcategoryByCategoryId.Columns["CATEGORY_ID"].ToString();
                    this.drpSubCategory.DataBind();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpSubCategory.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                try
                {
                    this.Session["PARTY_INFO"] = new DataTable();
                    this.Session["CP_DETAIL"] = new ArrayList();
                    this.Session["CP_DETAIL_Save"] = new ArrayList();
                    this.Session["CP_DETAIL_MAIN"] = new ArrayList();
                    this.Session["ITEM_ID"] = "";
                    this.Session["production_unit"] = "";
                    this.Session["production_sale_unit_price"] = "";
                    this.Session["production_quantity"] = "";
                    this.lt_companyName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.It_companyAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    TextBox str = this.txtChallanDate;
                    DateTime now = DateTime.Now;
                    str.Text = now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    BLL.UtilityK.fillChallanDiscardReasonList(this.drpDiscardReason1);
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    this.drpDiscardReason1.Items.Insert(0, listItem);
                    this.drpSubCategory.Items.Insert(0, listItem);
                    this.drpCategory.Items.Insert(0, listItem);
                    this.loadPertyInfo();
                    this.loadHours();
                    this.loadMinute();
                    this.GetBranchInformation();
                    this.getChallanNo();
                    this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
            }
        }

        protected void productName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.getProductInfo();
                this.getAvailableStock();
                this.getAllProperty();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            int rowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            TextBox textBox = this.gvItem.Rows[rowIndex].FindControl("Quantity") as TextBox;
            num = Convert.ToDecimal(textBox.Text);
            num2 = Convert.ToDecimal(this.gvItem.Rows[rowIndex].Cells[8].Text);
            num1 = Convert.ToDecimal(this.gvItem.Rows[rowIndex].Cells[11].Text);
            TableCell item = this.gvItem.Rows[rowIndex].Cells[12];
            decimal num3 = (num * num1) / num2;
            item.Text = num3.ToString("0.00");
        }

        private void showReport()
        {
            ContructualProductionIssueMasterDAO contructualProductionIssueMasterDAO = new ContructualProductionIssueMasterDAO();
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            string[] strArrays = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
            string[] strArrays1 = strArrays;
            string[] strArrays2 = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };
            string[] strArrays3 = strArrays2;
            contructualProductionIssueMasterDAO = (ContructualProductionIssueMasterDAO)this.Session["MASTER_DATA"];
            this.lblOrgName.Text = contructualProductionIssueMasterDAO.OrgName;
            this.lblOrgBinNo.Text = contructualProductionIssueMasterDAO.OrgBIN;
            this.lblChallanAddress.Text = contructualProductionIssueMasterDAO.ChallanIssueAddress;
            this.lblTransport.Text = contructualProductionIssueMasterDAO.PartyAddress;
            this.lblReceipentName.Text = contructualProductionIssueMasterDAO.PartyName;
            this.lblReceipentBIN.Text = contructualProductionIssueMasterDAO.PartyBIN;
            this.lblChallanNo.Text = contructualProductionIssueMasterDAO.Challan_batch_no;
            this.lblChallanIssueDate.Text = contructualProductionIssueMasterDAO.Date_production.ToString("dd-MM-yyyy");
            Label str = this.lblChallanIssueTime;
            DateTime dateTime = Convert.ToDateTime(contructualProductionIssueMasterDAO.IssueTime);
            str.Text = dateTime.ToString("hh:mm tt");
            ArrayList item = (ArrayList)this.Session["CP_DETAIL_Save"];
            ArrayList arrayLists = (ArrayList)this.Session["CP_DETAIL_MAIN"];
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            ContructualProductionIssueDAO contructualProductionIssueDAO1 = new ContructualProductionIssueDAO();
            string str1 = "";
            string str2 = "";
            contructualProductionIssueDAO1 = (ContructualProductionIssueDAO)arrayLists[0];
            DataTable unitFromFinishProduct = contructualProductionBLL.GetUnitFromFinishProduct(contructualProductionIssueDAO1.Item_id);
            if (unitFromFinishProduct.Rows.Count > 0)
            {
                str2 = unitFromFinishProduct.Rows[0]["unit_code"].ToString();
            }
            str1 = string.Concat(str1, "<tr>");
            str1 = string.Concat(str1, "<td style='border:1px solid gray'></td>");
            str1 = string.Concat(str1, "<td style='border:1px solid gray'>-</td>");
            str1 = string.Concat(str1, "<td style='border:1px solid gray'>", contructualProductionIssueDAO1.ItemName, "</td>");
            object obj = str1;
            object[] quantity = new object[] { obj, "<td style='text-align:right;border:1px solid gray'>", contructualProductionIssueDAO1.Quantity, " ", str2, "</td>" };
            str1 = string.Concat(quantity);
            str1 = string.Concat(str1, "<td style='border:1px solid gray'>-</td>");
            for (int i = 0; i < item.Count; i++)
            {
                string str3 = i.ToString();
                string str4 = str3.Replace(strArrays1[i], strArrays3[i]);
                contructualProductionIssueDAO = (ContructualProductionIssueDAO)item[i];
                str1 = string.Concat(str1, "<tr>");
                str1 = string.Concat(str1, "<td style='border:1px solid gray'>", str4, "</td>");
                str1 = string.Concat(str1, "<td style='text-align:left;border:1px solid gray'>", contructualProductionIssueDAO.ItemName, "</td>");
                str1 = string.Concat(str1, "<td style='border:1px solid gray'>-</td>");
                string str5 = str1;
                string[] strArrays4 = new string[] { str5, "<td style='text-align:right;border:1px solid gray'>", Utilities.formatFraction(contructualProductionIssueDAO.Quantity), " ", contructualProductionIssueDAO.TotUnitName, "</td>" };
                str1 = string.Concat(strArrays4);
                str1 = string.Concat(str1, "<td style='text-align:left;border:1px solid gray'>", contructualProductionIssueDAO.Remark, "</td>");
                str1 = string.Concat(str1, "</tr>");
                this.HaiMan.Text = str1;
            }
            this.lblDutyOfficer.Text = this.Session["EMPLOYEE_NAME"].ToString();
            this.btnPrintReport.Visible = true;
            this.cpPrint.Visible = true;
            this.printBTN.Text = "Hide Report";
        }

        private void stickWiseQuantity()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            DataTable dataTable = new DataTable();
            short num = 0;
            short num1 = 0;
            short num2 = 0;
            short num3 = 0;
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            string str = "";
            decimal num6 = new decimal(0);
            decimal num7 = Convert.ToDecimal(this.Session["unit_price"]);
            if (this.drpProperty1.SelectedValue != "-99" && this.drpProperty1.SelectedValue != "")
            {
                num = Convert.ToInt16(this.drpProperty1.SelectedValue);
            }
            if (this.drpProperty2.SelectedValue != "-99" && this.drpProperty2.SelectedValue != "")
            {
                num1 = Convert.ToInt16(this.drpProperty2.SelectedValue);
            }
            if (this.drpProperty3.SelectedValue != "-99" && this.drpProperty3.SelectedValue != "")
            {
                Convert.ToInt16(this.drpProperty3.SelectedValue);
            }
            if (this.drpProperty4.SelectedValue != "-99" && this.drpProperty4.SelectedValue != "")
            {
                num2 = Convert.ToInt16(this.drpProperty4.SelectedValue);
            }
            if (this.drpProperty5.SelectedValue != "-99" && this.drpProperty5.SelectedValue != "")
            {
                num3 = Convert.ToInt16(this.drpProperty5.SelectedValue);
            }
            if (this.lblProperty1.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num);
            }
            if (this.lblProperty2.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num1);
            }
            if (this.lblProperty3.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num3);
            }
            if (this.lblProperty4.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num2);
            }
            if (this.lblProperty5.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num3);
            }
            if (dataTable.Rows.Count <= 0)
            {
                this.txtFinalQuantity.Text = this.txtQuantity.Text;
            }
            else
            {
                num4 = Convert.ToDecimal(dataTable.Rows[0]["quantity"]);
                str = this.drpUnit.SelectedItem.ToString();
                num5 = (!string.IsNullOrEmpty(this.txtQuantity.Text) ? Convert.ToDecimal(this.txtQuantity.Text) : new decimal(0));
                if (this.lblUnitCode.Text != str)
                {
                    if (str == "PACK")
                    {
                        this.lblQuantityPrp.Text = (num4 * num5).ToString();
                    }
                    if (str == "DOZ")
                    {
                        Label label = this.lblQuantityPrp;
                        decimal num8 = (new decimal(12) * num4) * num5;
                        label.Text = num8.ToString();
                    }
                    if (str == "GRS")
                    {
                        Label str1 = this.lblQuantityPrp;
                        decimal num9 = (new decimal(144) * num4) * num5;
                        str1.Text = num9.ToString();
                    }
                    if (str == "CRT")
                    {
                        Label label1 = this.lblQuantityPrp;
                        decimal num10 = (new decimal(500) * num4) * num5;
                        label1.Text = num10.ToString();
                    }
                    if (num4 != new decimal(0))
                    {
                        num6 = num7 * num4;
                    }
                }
                else
                {
                    this.lblQuantityPrp.Text = this.txtQuantity.Text;
                    num6 = Convert.ToDecimal(num7);
                }
                this.txtSaleUnitPrice.Text = num6.ToString("0.00");
                this.txtFinalQuantity.Text = this.lblQuantityPrp.Text;
                if (this.txtQuantity.Text != "0")
                {
                    this.VatSDCalculationForTobacco();
                    return;
                }
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            this.stickWiseQuantity();
            this.VatSDCalculation();
            if (this.drpParty.SelectedValue == "-99")
            {
                this.drpParty.Focus();
                this.msgBox.AddMessage("Please Select Your Party Name.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void txtSaleUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.calculation();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtVatablePrice_TextChanged(object sender, EventArgs e)
        {
        }

        private bool validation()
        {
            if (this.txtChallanNo.Text == "")
            {
                this.msgBox.AddMessage("Enter Challan No / Select Discard", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.ddlProvidedChallan.SelectedValue != "-1")
            {
                return true;
            }
            this.msgBox.AddMessage("Select Provided Challan No", MsgBoxs.enmMessageType.Attention);
            this.ddlProvidedChallan.Focus();
            return false;
        }

        private void VatSDCalculation()
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            double num4 = 0;
            double num5 = 0;
            double num6 = 0;
            double num7 = 0;
            try
            {
                num3 = (!string.IsNullOrEmpty(this.lblSaleVat.Text) ? Convert.ToDouble(this.lblSaleVat.Text.Trim()) : 0);
                num4 = (!string.IsNullOrEmpty(this.lblSaleSD.Text) ? Convert.ToDouble(this.lblSaleSD.Text.Trim()) : 0);
                if (this.drpItem.SelectedValue != "-99")
                {
                    num = Convert.ToDouble(this.Session["unit_price"]);
                    if (this.txtFinalQuantity.Text == "")
                    {
                        num1 = (!string.IsNullOrEmpty(this.txtQuantity.Text) ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                    }
                    else
                    {
                        num1 = (!string.IsNullOrEmpty(this.txtFinalQuantity.Text) ? Convert.ToDouble(this.txtFinalQuantity.Text.Trim()) : 0);
                    }
                    num2 = num1 * num;
                    num6 = num2 * num4 / 100;
                    num5 = (this.Label9.Text != " Per Unit" ? (num2 + num6) * num3 / 100 : Convert.ToDouble(this.lblSaleVat.Text.Trim()) * Convert.ToDouble(this.txtQuantity.Text.Trim()));
                    this.fnUnitPrice.Text = num.ToString("N2");
                    this.fnVat.Text = num5.ToString("N2");
                    this.fnSD.Text = num6.ToString("N2");
                    this.fnTotal.Text = num2.ToString("N2");
                    this.txtSaleVat.Text = num5.ToString("N2");
                    this.txtSaleSD.Text = num6.ToString("N2");
                    num7 = (this.Label9.Text != " Per Unit" ? num2 + num6 : num1 * num);
                    this.txtSaleVatablePrice.Text = num7.ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void VatSDCalculationForTobacco()
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            double num4 = 0;
            double num5 = 0;
            double num6 = 0;
            double num7 = 0;
            try
            {
                num3 = (!string.IsNullOrEmpty(this.lblSaleVat.Text) ? Convert.ToDouble(this.lblSaleVat.Text.Trim()) : 0);
                num4 = (!string.IsNullOrEmpty(this.lblSaleSD.Text) ? Convert.ToDouble(this.lblSaleSD.Text.Trim()) : 0);
                if (this.drpItem.SelectedValue != "-99")
                {
                    num = Convert.ToDouble(this.Session["unit_price"]);
                    if (this.txtFinalQuantity.Text == "")
                    {
                        num1 = (!string.IsNullOrEmpty(this.txtQuantity.Text) ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                    }
                    else
                    {
                        num1 = (!string.IsNullOrEmpty(this.txtFinalQuantity.Text) ? Convert.ToDouble(this.txtFinalQuantity.Text.Trim()) : 0);
                    }
                    num6 = num1 * num * num4 / 100;
                    num5 = (this.Label9.Text != " Per Unit" ? num1 * num * num3 / 100 : Convert.ToDouble(this.lblSaleVat.Text.Trim()) * Convert.ToDouble(this.txtQuantity.Text.Trim()));
                    this.fnUnitPrice.Text = num.ToString("N2");
                    this.fnVat.Text = num5.ToString("N2");
                    this.fnSD.Text = num6.ToString("N2");
                    this.fnTotal.Text = num2.ToString("N2");
                    this.txtSaleVat.Text = num5.ToString("N2");
                    this.txtSaleSD.Text = num6.ToString("N2");
                    num7 = (this.Label9.Text != " Per Unit" ? num1 * num : num1 * num);
                    this.txtSaleVatablePrice.Text = num7.ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}