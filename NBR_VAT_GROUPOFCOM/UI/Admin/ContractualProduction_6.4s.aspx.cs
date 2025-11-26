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
    public partial class ContractualProduction_6__4s : Page, IRequiresSessionState
    {
      
      

      
        public ContractualProduction_6__4s()
        {
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            ArrayList item = (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"];
            try
            {
                if (this.gridValidation())
                {
                    if (item.Count <= 0)
                    {
                        this.getCPDetailData();
                        this.loadGridView();
                        this.clearAll();
                    }
                    else
                    {
                        this.getCPDetailDatagvIngredience();
                        this.showIngredience();
                        this.clearAll();
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "ContractualProduction_6.4", "btnAddItem_Click", fileLineNumber);
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            try
            {
                base.Response.Redirect("~/UI/Others/PartySetup.aspx");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.clearAll();
            this.ClearAllControlsValue();
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
                    this.msgBox.AddMessage("Please Save your Data First.", MsgBoxs.enmMessageType.Attention);
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "ContractualProduction_6.4", "btnPrint_Click");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            ContructualProductionIssueMasterDAO contructualProductionIssueMasterDAO = new ContructualProductionIssueMasterDAO();
            ProductionLotNoQntDAO productionLotNoQntDAO = new ProductionLotNoQntDAO();
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            Convert.ToDecimal(this.Session["Quantity"]);
            int num = 0;
            try
            {
                if (this.validation())
                {
                    contructualProductionIssueMasterDAO = this.fillCPMasterData(contructualProductionIssueMasterDAO);
                    if (contructualProductionIssueMasterDAO != null)
                    {
                        if (!this.chkDiscard.Checked)
                        {
                            arrayLists = (((ArrayList)this.Session["CP_DETAIL"]).Count > 0 ? (ArrayList)this.Session["CP_DETAIL"] : (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"]);
                            if (this.gvIngredience.Rows.Count <= 0)
                            {
                                for (int i = 0; i < this.gvItem.Rows.Count; i++)
                                {
                                    ContructualProductionIsCheck contructualProductionIsCheck = new ContructualProductionIsCheck();
                                    if (!((CheckBox)this.gvItem.Rows[i].FindControl("chkChallan")).Checked)
                                    {
                                        contructualProductionIsCheck.IS_item_checkt=false;
                                    }
                                    else
                                    {
                                        contructualProductionIsCheck.IS_item_checkt=true;
                                        num++;
                                    }
                                    arrayLists1.Add(contructualProductionIsCheck);
                                    contructualProductionIsCheck = null;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < this.gvIngredience.Rows.Count; j++)
                                {
                                    ContructualProductionIsCheck contructualProductionIsCheck1 = new ContructualProductionIsCheck();
                                    if (!((CheckBox)this.gvIngredience.Rows[j].FindControl("chkChallan")).Checked)
                                    {
                                        contructualProductionIsCheck1.IS_item_checkt=false;
                                    }
                                    else
                                    {
                                        contructualProductionIsCheck1.IS_item_checkt=(true);
                                        num++;
                                    }
                                    arrayLists1.Add(contructualProductionIsCheck1);
                                    contructualProductionIsCheck1 = null;
                                }
                            }
                            if (num == 0)
                            {
                                this.msgBox.AddMessage("Please Check Ingredients from the Grid.", MsgBoxs.enmMessageType.Error);
                                return;
                            }
                            else if (arrayLists == null || arrayLists.Count == 0)
                            {
                                this.gvItem.DataSource = null;
                                this.gvItem.DataBind();
                                this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                                return;
                            }
                        }
                        if (!contructualProductionBLL.insertCPIssueData(contructualProductionIssueMasterDAO, arrayLists, arrayLists1))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Ingredience For Production Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.showReport(arrayLists1);
                            this.ClearAllControlsValue();
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
                 BLL.Utility.InsertErrorTrackNew(exception.Message, "ContractualProduction_6.4", "btnSave_Click", fileLineNumber);
            }
        }

        protected void btnShowIngredience_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.drpFinishProduct.SelectedItem.Value == "-99")
                {
                    this.msgBox.AddMessage("Select Finish Product (Production)", MsgBoxs.enmMessageType.Attention);
                }
                else if (this.txtPQuantity.Text.Trim() == "")
                {
                    this.msgBox.AddMessage("Write Product Quantity", MsgBoxs.enmMessageType.Attention);
                }
                else if (this.drpPriceDeclarationNo.SelectedItem.Value != "")
                {
                    this.getUsedQuantity();
                    this.showIngredience();
                }
                else
                {
                    this.msgBox.AddMessage("Select Price Declaration No.", MsgBoxs.enmMessageType.Attention);
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "ContractualProduction_6.4", "btnShowIngredience_OnClick");
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
        }

        protected void chkDiscard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDiscard.Checked)
            {
                this.drpCategory.Enabled = false;
                this.drpSubCategory.Enabled = false;
                this.drpItem.Enabled = false;
                this.btnAdd.Enabled = false;
                return;
            }
            this.drpCategory.Enabled = true;
            this.drpSubCategory.Enabled = true;
            this.drpItem.Enabled = true;
            this.btnAdd.Enabled = true;
        }

        private void clearAll()
        {
            this.LoadCategory("R");
            this.drpSubCategory.Items.Clear();
            ListItem listItem = new ListItem("---Select---", "-99");
            this.drpSubCategory.Items.Insert(0, listItem);
            this.drpItem.SelectedValue = "-99";
            this.lblHSCode.Text = "";
            this.txtQuantity.Text = "";
            this.lblUnit.Text = "";
            this.txtRemark.Text = "";
            this.avlQuantity.Text = "";
        }

        private void ClearAllControlsValue()
        {
            try
            {
                this.drpParty.SelectedValue = "-99";
                this.btnAddParty.Text = "New";
                this.txtAddress.Text = "";
                this.txtPartyBIN.Text = "";
                this.txtPQuantity.Text = string.Empty;
                this.drpFinishProduct.SelectedValue = "-99";
                this.drpPriceDeclarationNo.ClearSelection();
                this.txtChallanDate.Text = DateTime.Now.Date.ToShortDateString();
                this.drpChDtHr.SelectedIndex = 0;
                this.drpChDtMin.SelectedIndex = 0;
                this.drpRole.SelectedIndex = 0;
                this.Session["CP_DETAIL"] = new ArrayList();
                this.Session["CPISSUE_DETAIL_GRID_DATA"] = new ArrayList();
                this.loadGridView();
                this.gvIngredience.DataSource = null;
                this.gvIngredience.DataBind();
                this.drpFinishProduct.SelectedValue = "-99";
                this.txtBatchNo.Text = "";
                this.txtMfgDate.Text = "";
                this.txtExpDate.Text = "";
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "ContractualProduction_6.4", "ClearAllControlsValue");
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
                this.LoadItemsByCatgSubCatg();
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

        protected void drpFinishProduct_Click(object sender, EventArgs e)
        {
            this.LoadFinishProductIngredients();
            this.LoadPriceDeclarationNo();
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
                    this.FillPurchaseRate(num);
                    this.getAvailableStock();
                    this.getAllProperty();
                    this.fillCatSubCat();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpParty.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpParty.SelectedValue);
                    DataTable item = (DataTable)this.Session["PARTY_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("party_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.txtAddress.Text = dataRow["party_address"].ToString();
                        this.txtPartyBIN.Text = dataRow["party_bin"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if (this.drpRole.SelectedIndex == 0)
                {
                    str = "R";
                }
                if (this.drpRole.SelectedIndex == 1)
                {
                    str = "P";
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
                this.LoadItemsByCatgSubCatg();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
            this.lblUnit.Text = allFieldByItemId.Rows[0]["unit_code"].ToString();
            this.lblUnitId.Text = allFieldByItemId.Rows[0]["unit_id"].ToString();
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

        private ContructualProductionIssueMasterDAO fillCPMasterData(ContructualProductionIssueMasterDAO objCPMaster)
        {
            try
            {
                objCPMaster.OrgName=(this.org_name.Text.ToString());
                objCPMaster.OrgBIN=(this.lblOrgBIN.Text.ToString());
                objCPMaster.OrgAddress=(this.org_address.Text.ToString());
                this.getChallanNo();
                objCPMaster.ChallanNo=(this.txtChallanNo.Text.ToString());
                objCPMaster.FinishProduct=(this.drpFinishProduct.SelectedItem.ToString());
                objCPMaster.DeliveryDate=((this.txtDeliveryDate.Text.Trim() != "" ? this.txtDeliveryDate.Text.Trim() : "N/A"));
                objCPMaster.DeliveryTime=(string.Concat(this.drpDeliveryHour.SelectedItem.ToString(), " : ", this.drpDeliveryMin.SelectedItem.ToString()));
                if (!this.drpParty.Enabled)
                {
                    objCPMaster.IsNewParty=(true);
                    objCPMaster.PartyAddress=(this.txtAddress.Text.ToString());
                    objCPMaster.PartyBIN=(this.txtPartyBIN.Text.Trim());
                }
                else if (this.drpParty.SelectedValue != "-99")
                {
                    objCPMaster.IsNewParty=(false);
                    objCPMaster.Party_id=(Convert.ToInt32(this.drpParty.SelectedValue));
                    objCPMaster.PartyName=(this.drpParty.SelectedItem.ToString());
                    objCPMaster.PartyAddress=(this.txtAddress.Text.ToString());
                    objCPMaster.PartyBIN=(this.txtPartyBIN.Text.Trim());
                }
                int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                objCPMaster.Batch_no=((!string.IsNullOrEmpty(this.txtBatchNo.Text) ? this.txtBatchNo.Text : ""));
                if (string.IsNullOrEmpty(this.txtExpDate.Text.Trim()))
                {
                    objCPMaster.ExpiryDate=(DateTime.MinValue);
                }
                else
                {
                    objCPMaster.ExpiryDate=(DateTime.ParseExact(this.txtExpDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                if (string.IsNullOrEmpty(this.txtMfgDate.Text.Trim()))
                {
                    objCPMaster.MfgDate=(DateTime.MinValue);
                }
                else
                {
                    objCPMaster.MfgDate=(DateTime.ParseExact(this.txtMfgDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                objCPMaster.BranchID=(num);
                objCPMaster.Challan_batch_no=(this.txtChallanNo.Text);
                DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objCPMaster.Production_year=(Convert.ToInt16(dateTime.ToString("yyyy")));
                string[] strArrays = new string[] { this.txtChallanDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                objCPMaster.Date_production=(DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
                string[] strArrays1 = new string[] { this.txtChallanDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                objCPMaster.IssueDate=(DateTime.ParseExact(string.Concat(strArrays1), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture));
                DateTime dateTime1 = DateTime.ParseExact(string.Concat(this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text), "HH:mm", CultureInfo.InvariantCulture);
                objCPMaster.IssueTime=(dateTime1.ToString());
                if (this.drpRole.SelectedIndex == 0)
                {
                    objCPMaster.Material_type=('I');
                }
                else if (this.drpRole.SelectedIndex == 1)
                {
                    objCPMaster.Material_type=('F');
                }
                bool @checked = this.chkDiscard.Checked;
                objCPMaster.Remarks=("NA");
                if (this.hdPageNo.Value != "")
                {
                    objCPMaster.ChallanPageNo=(Convert.ToInt32(this.hdPageNo.Value.ToString()));
                }
                if (this.hdBookId.Value != "")
                {
                    objCPMaster.ChallanBookId=(Convert.ToInt32(this.hdBookId.Value.ToString()));
                }
                objCPMaster.Audit_user_id=(Convert.ToInt16(this.Session["employee_id"]));
                objCPMaster.User_id_insert=(Convert.ToInt16(this.Session["employee_id"]));
                objCPMaster.Organization_id=(Convert.ToInt16(this.Session["organization_id"]));
                objCPMaster.Status=('I');
                objCPMaster.FinishProductID=(Convert.ToInt64(this.drpFinishProduct.SelectedValue));
                if (this.txtPQuantity.Text != "")
                {
                    objCPMaster.Quantity=(Convert.ToInt32(this.txtPQuantity.Text));
                }
                else
                {
                    objCPMaster.Quantity=(0);
                }
                if (this.drpPriceDeclarationNo.SelectedValue != "")
                {
                    objCPMaster.price_id=(Convert.ToInt32(this.drpPriceDeclarationNo.SelectedValue));
                }
                else
                {
                    objCPMaster.price_id=(-99);
                }
                this.Session["CP_MASTER_DATA"] = objCPMaster;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                 BLL.Utility.InsertErrorTrackNew(exception.Message, "ContractualProduction6.4", "fillCPMasterData", fileLineNumber);
            }
            return objCPMaster;
        }

        private void FillPurchaseRate(int itemID)
        {
            ItemBLL itemBLL = new ItemBLL();
            try
            {
                DataTable itemRate = itemBLL.getItemRate(itemID);
                if (itemRate.Rows.Count > 0)
                {
                    this.lblUnitPrice.Text = itemRate.Rows[0]["purchase_unit_price"].ToString();
                    this.lblVatRate.Text = itemRate.Rows[0]["vat_rate"].ToString();
                    this.lblSdRate.Text = itemRate.Rows[0]["sd_rate"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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
                if (dataTable != null && dataTable.Rows.Count > 0)
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
                short num = Convert.ToInt16(this.drpItem.SelectedValue);
                DateTime dateTime = DateTime.Parse(this.txtChallanDate.Text.Trim());
                DataTable availStockforTransferProduct = saleBLL.getAvailStockforTransferProduct(num, dateTime);
                if (availStockforTransferProduct.Rows != null)
                {
                    if (availStockforTransferProduct.Rows[0]["item_type"].ToString() != "I")
                    {
                        this.avlQuantity.Text = "0";
                    }
                    else
                    {
                        this.avlQuantity.Text = availStockforTransferProduct.Rows[0]["availStock"].ToString();
                    }
                    this.avlQuantity.Text = availStockforTransferProduct.Rows[0]["availStock"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private decimal getAvailableStock(short itemId)
        {
            decimal num = new decimal(0);
            SaleBLL saleBLL = new SaleBLL();
            DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataTable saleAvailableStockP = saleBLL.GetSaleAvailableStockP(itemId, dateTime);
            if (saleAvailableStockP.Rows != null && saleAvailableStockP.Rows[0]["item_type"].ToString() == "I")
            {
                num = Convert.ToDecimal(saleAvailableStockP.Rows[0]["availStock"]);
            }
            return num;
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
                    if (branchInformationFormanagerN != null && branchInformationFormanagerN.Rows.Count > 0)
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
            DataTable creditNoteNo = craDebBLL.GetCreditNoteNo(9, num, num1);
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
            decimal num = new decimal(0);
            ArrayList item = (ArrayList)this.Session["CP_DETAIL"] ?? new ArrayList();
            short num1 = Convert.ToInt16(item.Count + 1);
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            contructualProductionIssueDAO.RowNo=(num1);
            contructualProductionIssueDAO.ItemName=(this.drpItem.SelectedItem.ToString());
            contructualProductionIssueDAO.CategoryName=(this.drpCategory.SelectedItem.ToString());
            contructualProductionIssueDAO.SubCategoryName=(this.drpSubCategory.SelectedItem.ToString());
            contructualProductionIssueDAO.Item_id=(Convert.ToInt32(this.drpItem.SelectedValue));
            contructualProductionIssueDAO.Property_id1=(Convert.ToInt16(this.lblProp1.Text));
            contructualProductionIssueDAO.Property_id2=(Convert.ToInt16(this.lblProp2.Text));
            contructualProductionIssueDAO.Property_id3=(Convert.ToInt16(this.lblProp3.Text));
            contructualProductionIssueDAO.Property_id4=(Convert.ToInt16(this.lblProp4.Text));
            contructualProductionIssueDAO.Property_id5=(Convert.ToInt16(this.lblProp5.Text));
            contructualProductionIssueDAO.UnitName=(this.lblUnit.Text.ToString());
            contructualProductionIssueDAO.Unit_id=(Convert.ToInt16(this.lblUnitId.Text));
            contructualProductionIssueDAO.Quantity=(Convert.ToDecimal(this.txtQuantity.Text));
            contructualProductionIssueDAO.Batch_no=((!string.IsNullOrEmpty(this.txtBatchNo.Text) ? this.txtBatchNo.Text : ""));
            contructualProductionIssueDAO.ExpiryDate=((!string.IsNullOrEmpty(this.txtExpDate.Text) ? Convert.ToDateTime(this.txtExpDate.Text) : DateTime.MinValue));
            contructualProductionIssueDAO.MfgDate=((!string.IsNullOrEmpty(this.txtMfgDate.Text) ? Convert.ToDateTime(this.txtMfgDate.Text) : DateTime.MinValue));
            num = Convert.ToDecimal(this.avlQuantity.Text);
            if (contructualProductionIssueDAO.Quantity > num)
            {
                this.msgBox.AddMessage(string.Concat("Stock is not available. Current stock: ", num.ToString()), MsgBoxs.enmMessageType.Error);
                return;
            }
            for (int i = 0; i < item.Count; i++)
            {
                if (contructualProductionIssueDAO.Item_id == ((ContructualProductionIssueDAO)item[i]).Item_id)
                {
                    if ((((ContructualProductionIssueDAO)item[i]).Quantity + contructualProductionIssueDAO.Quantity) > num)
                    {
                        this.msgBox.AddMessage(string.Concat("Stock is not available. Current stock: ", num.ToString()), MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    ((ContructualProductionIssueDAO)item[i]).Quantity=(((ContructualProductionIssueDAO)item[i]).Quantity + contructualProductionIssueDAO.Quantity);
                    this.Session["CP_DETAIL"] = item;
                    this.Session["CP_DETAIL_R"] = item;
                    return;
                }
            }
            contructualProductionIssueDAO.Remark=(this.txtRemark.Text);
            contructualProductionIssueDAO.User_id_insert=(Convert.ToInt16(this.Session["employee_id"]));
            contructualProductionIssueDAO.Status=('I');
            item.Add(contructualProductionIssueDAO);
            this.Session["CP_DETAIL"] = item;
            this.Session["CP_DETAIL_R"] = item;
        }

        private void getCPDetailDatagvIngredience()
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            ArrayList item = (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"] ?? new ArrayList();
            short num4 = Convert.ToInt16(item.Count + 1);
            num1 = (this.lblUnitPrice.Text.Trim() != "" ? Convert.ToDecimal(this.lblUnitPrice.Text.Trim()) : new decimal(0));
            num3 = (this.lblSdRate.Text.Trim() != "" ? Convert.ToDecimal(this.lblSdRate.Text.Trim()) : new decimal(0));
            num2 = (this.lblVatRate.Text.Trim() != "" ? Convert.ToDecimal(this.lblVatRate.Text.Trim()) : new decimal(0));
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            contructualProductionIssueDAO.RowNo=(num4);
            contructualProductionIssueDAO.ItemName=(this.drpItem.SelectedItem.ToString());
            contructualProductionIssueDAO.CategoryName=(this.drpCategory.SelectedItem.ToString());
            contructualProductionIssueDAO.SubCategoryName=(this.drpSubCategory.SelectedItem.ToString());
            contructualProductionIssueDAO.Item_id=(Convert.ToInt32(this.drpItem.SelectedValue));
            contructualProductionIssueDAO.Property_id1=(Convert.ToInt16(this.lblProp1.Text));
            contructualProductionIssueDAO.Property_id2=(Convert.ToInt16(this.lblProp2.Text));
            contructualProductionIssueDAO.Property_id3=(Convert.ToInt16(this.lblProp3.Text));
            contructualProductionIssueDAO.Property_id4=(Convert.ToInt16(this.lblProp4.Text));
            contructualProductionIssueDAO.Property_id5=(Convert.ToInt16(this.lblProp5.Text));
            contructualProductionIssueDAO.UnitName=(this.lblUnit.Text.ToString());
            contructualProductionIssueDAO.Unit_id=(Convert.ToInt16(this.lblUnitId.Text));
            contructualProductionIssueDAO.Quantity=(Convert.ToDecimal(this.txtQuantity.Text));
            contructualProductionIssueDAO.Price=(((contructualProductionIssueDAO.Quantity * num1) + ((((contructualProductionIssueDAO.Quantity * num1) + (((contructualProductionIssueDAO.Quantity * num1) * num3) / new decimal(100))) * num2) / new decimal(100))) + (((contructualProductionIssueDAO.Quantity * num1) * num3) / new decimal(100)));
            num = Convert.ToDecimal(this.avlQuantity.Text);
            if (contructualProductionIssueDAO.Quantity > num)
            {
                this.msgBox.AddMessage(string.Concat("Stock is not available. Current stock: ", num.ToString()), MsgBoxs.enmMessageType.Error);
                return;
            }
            for (int i = 0; i < item.Count; i++)
            {
                if (contructualProductionIssueDAO.Item_id == ((ContructualProductionIssueDAO)item[i]).Item_id)
                {
                    if ((((ContructualProductionIssueDAO)item[i]).Quantity + contructualProductionIssueDAO.Quantity) > num)
                    {
                        this.msgBox.AddMessage(string.Concat("Stock is not available. Current stock: ", num.ToString()), MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    ((ContructualProductionIssueDAO)item[i]).Quantity=(((ContructualProductionIssueDAO)item[i]).Quantity + contructualProductionIssueDAO.Quantity);
                    ((ContructualProductionIssueDAO)item[i]).Price=(((ContructualProductionIssueDAO)item[i]).Price + contructualProductionIssueDAO.Price);
                    this.Session["CPISSUE_DETAIL_GRID_DATA"] = item;
                    return;
                }
            }
            contructualProductionIssueDAO.Remark=(this.txtRemark.Text);
            contructualProductionIssueDAO.User_id_insert=(Convert.ToInt16(this.Session["employee_id"]));
            contructualProductionIssueDAO.Status=('I');
            item.Add(contructualProductionIssueDAO);
            this.Session["CPISSUE_DETAIL_GRID_DATA"] = item;
        }

        private ContructualProductionIssueMasterDAO getCPMasterData()
        {
            ContructualProductionIssueMasterDAO contructualProductionIssueMasterDAO = new ContructualProductionIssueMasterDAO();
            try
            {
                if (!this.drpParty.Enabled)
                {
                    contructualProductionIssueMasterDAO.IsNewParty=(true);
                    contructualProductionIssueMasterDAO.PartyAddress=( BLL.Utility.ReplaceQuotes(this.txtAddress.Text));
                    contructualProductionIssueMasterDAO.PartyBIN=( BLL.Utility.ReplaceQuotes(this.txtPartyBIN.Text));
                }
                else
                {
                    contructualProductionIssueMasterDAO.Party_id=(Convert.ToInt16(this.drpParty.SelectedValue));
                    contructualProductionIssueMasterDAO.IsNewParty=(false);
                    contructualProductionIssueMasterDAO.PartyName=(this.drpParty.SelectedItem.ToString());
                    contructualProductionIssueMasterDAO.PartyAddress=( BLL.Utility.ReplaceQuotes(this.txtAddress.Text));
                    contructualProductionIssueMasterDAO.PartyBIN=(this.txtPartyBIN.Text.ToString());
                }
                contructualProductionIssueMasterDAO.OrgName=(this.org_name.Text.ToString());
                contructualProductionIssueMasterDAO.OrgBIN=(this.lblOrgBIN.Text.ToString());
                contructualProductionIssueMasterDAO.OrgAddress=(this.org_address.Text.ToString());
                contructualProductionIssueMasterDAO.ChallanNo=(this.txtChallanNo.Text.ToString());
                contructualProductionIssueMasterDAO.IssueTime=(string.Concat(this.drpChDtHr.SelectedItem.ToString(), " : ", this.drpChDtMin.SelectedItem.ToString()));
                contructualProductionIssueMasterDAO.FinishProduct=(this.drpFinishProduct.SelectedItem.ToString());
                contructualProductionIssueMasterDAO.DeliveryDate=((this.txtDeliveryDate.Text.Trim() != "" ? this.txtDeliveryDate.Text.Trim() : "N/A"));
                contructualProductionIssueMasterDAO.DeliveryTime=(string.Concat(this.drpDeliveryHour.SelectedItem.ToString(), " : ", this.drpDeliveryMin.SelectedItem.ToString()));
                this.Session["CP_MASTER_DATA"] = contructualProductionIssueMasterDAO;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return contructualProductionIssueMasterDAO;
        }

        private void getGridData()
        {
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            ArrayList arrayLists = new ArrayList();
            try
            {
                foreach (GridViewRow row in this.gvIngredience.Rows)
                {
                    short num = Convert.ToInt16(this.gvIngredience.DataKeys[row.RowIndex]["RowNo"]);
                    contructualProductionIssueDAO.RowNo=(num);
                    HiddenField hiddenField = row.FindControl("item_id") as HiddenField;
                    contructualProductionIssueDAO.Item_id=(Convert.ToInt32(hiddenField.Value));
                    contructualProductionIssueDAO.ItemName=(row.Cells[3].Text);
                    HiddenField hiddenField1 = row.FindControl("unit_id") as HiddenField;
                    contructualProductionIssueDAO.Unit_id=(Convert.ToInt16(hiddenField1.Value));
                    HiddenField hiddenField2 = row.FindControl("property_id1") as HiddenField;
                    contructualProductionIssueDAO.Property_id1=(Convert.ToInt16(hiddenField2.Value));
                    HiddenField hiddenField3 = row.FindControl("property_id2") as HiddenField;
                    contructualProductionIssueDAO.Property_id2=(Convert.ToInt16(hiddenField3.Value));
                    HiddenField hiddenField4 = row.FindControl("property_id3") as HiddenField;
                    contructualProductionIssueDAO.Property_id3=(Convert.ToInt16(hiddenField4.Value));
                    HiddenField hiddenField5 = row.FindControl("property_id4") as HiddenField;
                    contructualProductionIssueDAO.Property_id4=(Convert.ToInt16(hiddenField5.Value));
                    HiddenField hiddenField6 = row.FindControl("property_id5") as HiddenField;
                    contructualProductionIssueDAO.Property_id5=(Convert.ToInt16(hiddenField6.Value));
                    Convert.ToDouble(row.Cells[4].Text);
                    TextBox textBox = row.FindControl("received_quantity") as TextBox;
                    Convert.ToDouble(textBox.Text.Trim());
                    contructualProductionIssueDAO.Quantity=(Convert.ToInt32(textBox.Text.Trim()));
                    contructualProductionIssueDAO.User_id_insert=(Convert.ToInt16(this.Session["EMPLOYEE_ID"]));
                    arrayLists.Add(contructualProductionIssueDAO);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["CPISSUE_DETAIL_GRID_DATA"] = arrayLists;
        }

        private void getProductInfo()
        {
        }

        private void getUsedQuantity()
        {
            short num;
            short num1;
            short num2;
            short num3;
            short num4;
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            ArrayList arrayLists = new ArrayList();
            try
            {
                decimal num5 = new decimal(0);
                int num6 = 0;
                AddItemBLL addItemBLL = new AddItemBLL();
                num5 = Convert.ToDecimal(this.txtPQuantity.Text.Trim());
                if (this.drpFinishProduct.SelectedValue != "-99")
                {
                    num6 = Convert.ToInt32(this.drpFinishProduct.SelectedValue);
                }
                if (this.drpParty.SelectedValue != "-99")
                {
                    Convert.ToInt32(this.drpParty.SelectedValue);
                }
                DataTable quantityToMadePerProduct = contructualProductionBLL.GetQuantityToMadePerProduct(num6, (this.drpPriceDeclarationNo.SelectedValue != "" ? Convert.ToInt32(this.drpPriceDeclarationNo.SelectedItem.Value) : 0));
                if (quantityToMadePerProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < quantityToMadePerProduct.Rows.Count; i++)
                    {
                        decimal num7 = new decimal(0);
                        decimal num8 = new decimal(0);
                        decimal num9 = new decimal(0);
                        decimal num10 = new decimal(0);
                        decimal num11 = new decimal(0);
                        decimal num12 = new decimal(0);
                        short num13 = 0;
                        short num14 = 0;
                        string str = "";
                        int num15 = 0;
                        decimal num16 = new decimal(0);
                        short num17 = 0;
                        decimal num18 = new decimal(0);
                        ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                        if (quantityToMadePerProduct.Rows[i]["unit_price"].ToString() != "")
                        {
                            Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["unit_price"]);
                        }
                        num13 = Convert.ToInt16(quantityToMadePerProduct.Rows[i]["unit_id"].ToString());
                        num14 = Convert.ToInt16(quantityToMadePerProduct.Rows[i]["actualUnit_id"].ToString());
                        num11 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["quantity"].ToString());
                        num15 = Convert.ToInt32(quantityToMadePerProduct.Rows[i]["item_id"].ToString());
                        str = quantityToMadePerProduct.Rows[i]["item_name"].ToString();
                        num16 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["production_quantity"]);
                        num10 = (num5 * num11) / num16;
                        DataTable value = addItemBLL.GetValue(num14, num13);
                        if (value.Rows.Count > 0)
                        {
                            num7 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                        }
                        if (num7 > new decimal(0))
                        {
                            num9 = num10 / num7;
                        }
                        if (num7 == new decimal(0))
                        {
                            DataTable valueSec = addItemBLL.GetValueSec(num14, num13);
                            if (valueSec.Rows.Count <= 0)
                            {
                                num9 = num10;
                            }
                            else if (num8 <= new decimal(0))
                            {
                                num9 = num10;
                            }
                            else
                            {
                                num8 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                                num9 = num10 * num7;
                            }
                        }
                        contructualProductionIssueDAO.PreQuantity=(Convert.ToDecimal(Utilities.RoundUpToWithString(num11, 2)));
                        num18 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["txtquantityprice"].ToString());
                        this.getAllPropertyByID(num15);
                        num17 = Convert.ToInt16(i + 1);
                        contructualProductionIssueDAO.Price=((num5 * num18) / num16);
                        contructualProductionIssueDAO.PriceValue=(contructualProductionIssueDAO.Price.ToString());
                        contructualProductionIssueDAO.Item_id=(num15);
                        contructualProductionIssueDAO.ItemName=(str);
                        contructualProductionIssueDAO.Quantity=(Convert.ToDecimal(Utilities.RoundUpToWithString(num9, 2)));
                        contructualProductionIssueDAO.Unit_id=(num14);
                        contructualProductionIssueDAO.RowNo=(num17);
                        contructualProductionIssueDAO.User_id_insert=(Convert.ToInt16(this.Session["employee_id"]));
                        contructualProductionIssueDAO.Status=('I');
                        contructualProductionIssueDAO.Remark=(this.txtRemark.Text);
                        ContructualProductionIssueDAO contructualProductionIssueDAO1 = contructualProductionIssueDAO;
                        if (!string.IsNullOrEmpty(this.lblProp1.Text))
                        {
                            num = Convert.ToInt16(this.lblProp1.Text);
                        }
                        else
                        {
                            num = 0;
                        }
                        contructualProductionIssueDAO1.Property_id1=(num);
                        ContructualProductionIssueDAO contructualProductionIssueDAO2 = contructualProductionIssueDAO;
                        if (!string.IsNullOrEmpty(this.lblProp2.Text))
                        {
                            num1 = Convert.ToInt16(this.lblProp1.Text);
                        }
                        else
                        {
                            num1 = 0;
                        }
                        contructualProductionIssueDAO2.Property_id2=(num1);
                        ContructualProductionIssueDAO contructualProductionIssueDAO3 = contructualProductionIssueDAO;
                        if (!string.IsNullOrEmpty(this.lblProp3.Text))
                        {
                            num2 = Convert.ToInt16(this.lblProp1.Text);
                        }
                        else
                        {
                            num2 = 0;
                        }
                        contructualProductionIssueDAO3.Property_id3=(num2);
                        ContructualProductionIssueDAO contructualProductionIssueDAO4 = contructualProductionIssueDAO;
                        if (!string.IsNullOrEmpty(this.lblProp4.Text))
                        {
                            num3 = Convert.ToInt16(this.lblProp1.Text);
                        }
                        else
                        {
                            num3 = 0;
                        }
                        contructualProductionIssueDAO4.Property_id4=(num3);
                        ContructualProductionIssueDAO contructualProductionIssueDAO5 = contructualProductionIssueDAO;
                        if (!string.IsNullOrEmpty(this.lblProp5.Text))
                        {
                            num4 = Convert.ToInt16(this.lblProp1.Text);
                        }
                        else
                        {
                            num4 = 0;
                        }
                        contructualProductionIssueDAO5.Property_id5=(num4);
                        contructualProductionIssueDAO.CategoryName=(quantityToMadePerProduct.Rows[i]["ctg_name"].ToString());
                        contructualProductionIssueDAO.SubCategoryName=(quantityToMadePerProduct.Rows[i]["sub_ctg_name"].ToString());
                        contructualProductionIssueDAO.UnitName=(quantityToMadePerProduct.Rows[i]["unit_code"].ToString());
                        contructualProductionIssueDAO.TotUnitName=(quantityToMadePerProduct.Rows[i]["totqunitcode"].ToString());
                        arrayLists.Add(contructualProductionIssueDAO);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["CPISSUE_DETAIL_GRID_DATA"] = arrayLists;
        }

        private void getUsedQuantity2()
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            ArrayList arrayLists = new ArrayList();
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            short num4 = 0;
            string str = "";
            int num5 = 0;
            short num6 = 0;
            try
            {
                num = Convert.ToDecimal(this.txtPQuantity.Text.Trim());
                if (this.drpFinishProduct.SelectedValue != "-99")
                {
                    Convert.ToInt32(this.drpFinishProduct.SelectedValue);
                }
                if (this.drpParty.SelectedValue != "-99")
                {
                    Convert.ToInt32(this.drpParty.SelectedValue);
                }
                DataTable dataTable = null;
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                        num2 = Convert.ToDecimal(dataTable.Rows[i]["quantity"].ToString());
                        num5 = Convert.ToInt32(dataTable.Rows[i]["item_id"].ToString());
                        str = dataTable.Rows[i]["item_name"].ToString();
                        num1 = num * num2;
                        contructualProductionIssueDAO.PreQuantity=(num2);
                        this.getAllPropertyByID(num5);
                        num4 = Convert.ToInt16(dataTable.Rows[0]["unit_id"].ToString());
                        contructualProductionIssueDAO.UnitName=(dataTable.Rows[0]["unit_code"].ToString());
                        num6 = Convert.ToInt16(i + 1);
                        contructualProductionIssueDAO.Item_id=(num5);
                        contructualProductionIssueDAO.ItemName=(str);
                        contructualProductionIssueDAO.Quantity=(num1);
                        contructualProductionIssueDAO.Unit_id=(num4);
                        contructualProductionIssueDAO.RowNo=(num6);
                        contructualProductionIssueDAO.User_id_insert=(Convert.ToInt16(this.Session["employee_id"]));
                        contructualProductionIssueDAO.Status=('I');
                        contructualProductionIssueDAO.Remark=(this.txtRemark.Text);
                        contructualProductionIssueDAO.Property_id1=(Convert.ToInt16(this.lblProp1.Text));
                        contructualProductionIssueDAO.Property_id2=(Convert.ToInt16(this.lblProp2.Text));
                        contructualProductionIssueDAO.Property_id3=(Convert.ToInt16(this.lblProp3.Text));
                        contructualProductionIssueDAO.Property_id4=(Convert.ToInt16(this.lblProp4.Text));
                        contructualProductionIssueDAO.Property_id5=(Convert.ToInt16(this.lblProp5.Text));
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

        private bool gridValidation()
        {
            if (this.drpCategory.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(" Select Category", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            this.lblErrorMessage.Visible = false;
            if (this.drpSubCategory.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(" Select Sub-Category", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            this.lblErrorMessage.Visible = false;
            if (this.drpItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(" Select Item", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            this.lblErrorMessage.Visible = false;
            if (this.txtQuantity.Text != "")
            {
                this.lblErrorMessage.Visible = false;
                return true;
            }
            this.msgBox.AddMessage(" Enter Quantity", MsgBoxs.enmMessageType.Attention);
            return false;
        }

        protected void gvIngredience_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
        }

        protected void gvIngredience_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ArrayList item = (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"];
            item.RemoveAt(e.RowIndex);
            this.Session["CPISSUE_DETAIL_GRID_DATA"] = item;
            this.showIngredience();
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ArrayList item = (ArrayList)this.Session["CP_DETAIL"];
            item.RemoveAt(e.RowIndex);
            this.Session["CP_DETAIL"] = item;
            this.loadGridView();
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

        private void LoadFinishProduct()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                DataTable finishGoodsProduction = addItemBLL.GetFinishGoodsProduction();
                this.drpFinishProduct.DataSource = finishGoodsProduction;
                this.drpFinishProduct.DataTextField = finishGoodsProduction.Columns["item_name"].ToString();
                this.drpFinishProduct.DataValueField = finishGoodsProduction.Columns["Item_id"].ToString();
                this.drpFinishProduct.DataBind();
                ListItem listItem = new ListItem("---SELECT---", "-99");
                this.drpFinishProduct.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadFinishProductIngredients()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                int num = Convert.ToInt32(this.drpFinishProduct.SelectedValue);
                DataTable ingredienceByFinishProductID = addItemBLL.GetIngredienceByFinishProductID(num, (this.drpPriceDeclarationNo.SelectedValue != "" ? Convert.ToInt32(this.drpPriceDeclarationNo.SelectedItem.Value) : 0));
                this.drpItem.DataSource = ingredienceByFinishProductID;
                this.drpItem.DataTextField = ingredienceByFinishProductID.Columns["item_name"].ToString();
                this.drpItem.DataValueField = ingredienceByFinishProductID.Columns["item_id"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpItem.Items.Insert(0, listItem);
                this.Session["ITEM_INFO"] = ingredienceByFinishProductID;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadGridView()
        {
            this.gvItem.DataSource = this.Session["CP_DETAIL"];
            this.gvItem.DataBind();
        }

        private void loadHours()
        {
            this.drpChDtHr.Items.Add("00");
            this.drpDeliveryHour.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
                this.drpDeliveryHour.Items.Add(i.ToString("00"));
            }
        }

        private void loadItems()
        {
            int num = 0;
            AddItemBLL addItemBLL = new AddItemBLL();
            DataTable ingredientsByCategoryId = null;
            try
            {
                if (this.drpCategory.SelectedValue == "ALL" && this.drpSubCategory.SelectedValue == "-99")
                {
                    num = 0;
                }
                else if (this.drpCategory.SelectedValue != "ALL" && this.drpSubCategory.SelectedValue == "-99")
                {
                    num = Convert.ToInt32(this.drpCategory.SelectedValue);
                }
                else if (this.drpCategory.SelectedValue != "ALL" && this.drpSubCategory.SelectedValue != "-99")
                {
                    num = Convert.ToInt32(this.drpCategory.SelectedValue);
                }
                if (this.drpRole.SelectedIndex == 0)
                {
                    ingredientsByCategoryId = addItemBLL.getIngredientsByCategoryId(num);
                    this.drpItem.DataSource = ingredientsByCategoryId;
                    this.drpItem.DataTextField = ingredientsByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = ingredientsByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem);
                }
                if (this.drpRole.SelectedIndex == 1)
                {
                    ingredientsByCategoryId = addItemBLL.getFinishGoodsProductByCategoryId(num);
                    this.drpItem.DataSource = ingredientsByCategoryId;
                    this.drpItem.DataTextField = ingredientsByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = ingredientsByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem1 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem1);
                }
                this.Session["ITEM_INFO"] = ingredientsByCategoryId;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadItemsByCatgSubCatg()
        {
            try
            {
                this.drpItem.Items.Clear();
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO();
                setItemDAO.CategoryID=((Convert.ToInt32(this.drpCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpCategory.SelectedValue) : 0));
                setItemDAO.SubCatgID=((Convert.ToInt32(this.drpSubCategory.SelectedValue) > 0 ? Convert.ToInt32(this.drpSubCategory.SelectedValue) : 0));
                if (this.drpRole.SelectedIndex != 0)
                {
                    setItemDAO.ProductType=('P');
                }
                else
                {
                    setItemDAO.ProductType=('R');
                }
                DataTable allItemForPurchasebyCatgSubCatg = addItemBLL.GetAllItemForPurchasebyCatgSubCatg(setItemDAO);
                this.drpItem.DataSource = allItemForPurchasebyCatgSubCatg;
                this.drpItem.DataTextField = allItemForPurchasebyCatgSubCatg.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = allItemForPurchasebyCatgSubCatg.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadMinute()
        {
            this.drpChDtMin.Items.Add("00");
            this.drpDeliveryMin.Items.Add("00");
            for (int i = 1; i <= 59; i++)
            {
                this.drpChDtMin.Items.Add(i.ToString("00"));
                this.drpDeliveryMin.Items.Add(i.ToString("00"));
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

        private void LoadPriceDeclarationNo()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                int num = Convert.ToInt16(this.drpFinishProduct.SelectedValue);
                DataTable priceDeclarationNoByItem = addItemBLL.GetPriceDeclarationNoByItem(num);
                if (priceDeclarationNoByItem.Rows.Count > 0)
                {
                    this.drpPriceDeclarationNo.DataSource = priceDeclarationNoByItem;
                    this.drpPriceDeclarationNo.DataTextField = priceDeclarationNoByItem.Columns["price_declaration_no"].ToString();
                    this.drpPriceDeclarationNo.DataValueField = priceDeclarationNoByItem.Columns["price_id"].ToString();
                    this.drpPriceDeclarationNo.DataBind();
                    ListItem listItem = new ListItem("---SELECT---", "");
                    this.drpPriceDeclarationNo.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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
                    this.Session["CP_DETAIL_R"] = new ArrayList();
                    this.Session["CPISSUE_DETAIL_GRID_DATA"] = new ArrayList();
                    this.org_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.org_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.loadPertyInfo();
                    this.LoadFinishProduct();
                    this.txtChallanDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.txtDeliveryDate.Text = DateTime.Today.Date.ToShortDateString();
                    this.LoadCategory("R");
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    ListItem listItem1 = new ListItem("-- Select --", "-99");
                    this.drpSubCategory.Items.Insert(0, listItem1);
                    ListItem listItem2 = new ListItem("-- Select --", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                    this.loadHours();
                    this.loadMinute();
                    this.loadItems();
                    this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                    this.drpDeliveryHour.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpDeliveryMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                    this.GetBranchInformation();
                    this.getChallanNo();
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

        private void showIngredience()
        {
            ArrayList item = (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"];
            this.gvIngredience.DataSource = item;
            this.gvIngredience.DataBind();
        }

        private void showReport(ArrayList arrDetailchk)
        {
            try
            {
                this.ChallanNo.Text = "";
                this.ChallanIssueDate.Text = "";
                this.ChallanIssueTime.Text = "";
                ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
                string[] strArrays = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
                string[] strArrays1 = strArrays;
                string[] strArrays2 = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };
                string[] strArrays3 = strArrays2;
                ContructualProductionIssueMasterDAO item = (ContructualProductionIssueMasterDAO)this.Session["CP_MASTER_DATA"];
                this.OrgName.Text = item.OrgName;
                this.OrgAddress.Text = item.OrgAddress;
                this.OrgBIN.Text = item.OrgBIN;
                this.PartyName.Text = item.PartyName;
                this.PartyAddress.Text = item.PartyAddress;
                this.PartyBIN.Text = item.PartyBIN;
                this.vehicleType.Text = string.Concat(item.VehicleType, "  ", item.VehicleNo);
                this.ChallanNo.Text = item.ChallanNo;
                Label challanIssueDate = this.ChallanIssueDate;
                DateTime dateTime = Convert.ToDateTime(item.IssueDate);
                challanIssueDate.Text = dateTime.ToString("dd-MMM-yyyy");
                Label challanIssueTime = this.ChallanIssueTime;
                DateTime dateTime1 = Convert.ToDateTime(item.IssueTime);
                challanIssueTime.Text = dateTime1.ToString("hh:mm tt");
                this.ChallanDeliverDate.Text = string.Concat(item.DeliveryDate, "  ", item.DeliveryTime);
                ContructualProductionIsCheck contructualProductionIsCheck = new ContructualProductionIsCheck();
                ArrayList arrayLists = (((ArrayList)this.Session["CP_DETAIL"]).Count > 0 ? (ArrayList)this.Session["CP_DETAIL"] : (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"]);
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                string str = "";
                int count = arrayLists.Count;
                string str1 = "";
                int num = Convert.ToInt32(this.drpFinishProduct.SelectedValue);
                DataTable unitFromFinishProduct = contructualProductionBLL.GetUnitFromFinishProduct(num);
                if (unitFromFinishProduct.Rows.Count > 0)
                {
                    str1 = unitFromFinishProduct.Rows[0]["unit_code"].ToString();
                }
                str = string.Concat(str, "<tr>");
                str = string.Concat(str, "<td style='border:1px solid gray'></td>");
                str = string.Concat(str, "<td style='border:1px solid gray'>-</td>");
                str = string.Concat(str, "<td style='border:1px solid gray'>", this.drpFinishProduct.SelectedItem.Text.Trim(), "</td>");
                string str2 = str;
                string[] strArrays4 = new string[] { str2, "<td style='text-align:right;border:1px solid gray'>", this.txtPQuantity.Text.Trim(), " ", str1, "</td>" };
                str = string.Concat(strArrays4);
                str = string.Concat(str, "<td style='border:1px solid gray'>-</td>");
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    if (((ContructualProductionIsCheck)arrDetailchk[i]).IS_item_checkt)
                    {
                        string str3 = i.ToString();
                        string str4 = str3.Replace(strArrays1[i], strArrays3[i]);
                        contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrayLists[i];
                        str = string.Concat(str, "<tr>");
                        str = string.Concat(str, "<td style='border:1px solid gray'>", str4, "</td>");
                        str = string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", contructualProductionIssueDAO.ItemName, "</td>");
                        str = string.Concat(str, "<td style='border:1px solid gray'>-</td>");
                        string str5 = str;
                        string[] strArrays5 = new string[] { str5, "<td style='text-align:right;border:1px solid gray'>", Utilities.formatFraction(contructualProductionIssueDAO.Quantity), " ", contructualProductionIssueDAO.TotUnitName, "</td>" };
                        str = string.Concat(strArrays5);
                        str = string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", contructualProductionIssueDAO.Remark, "</td>");
                        str = string.Concat(str, "</tr>");
                        this.HaiMan.Text = str;
                    }
                    this.lblDutyOfficer.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.btnPrintReport.Visible = true;
                    this.cpPrint.Visible = true;
                    this.printBTN.Text = "Hide Report";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtChallanNo_TextChanged(object sender, EventArgs e)
        {
            if ((new ChallanBLL()).checkProductionChallan(this.txtChallanNo.Text.Trim()))
            {
                this.txtChallanNo.Text = "";
                this.txtChallanNo.Focus();
                this.msgBox.AddMessage("This challan already exists.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
        }

        private bool validation()
        {
            bool flag;
            if (this.txtAddress.Text == "")
            {
                this.msgBox.AddMessage(" Enter Party Address", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtChallanNo.Text == "")
            {
                this.msgBox.AddMessage(" Enter Challan No or Select Discard", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtMfgDate.Text != "" && this.txtExpDate.Text != "" && DateTime.ParseExact(this.txtMfgDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(this.txtExpDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture))
            {
                this.msgBox.AddMessage("Manufacture Date must be less than Expiry Date", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.gvIngredience.Rows.Count > 0)
            {
                IEnumerator enumerator = ((ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"]).GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ContructualProductionIssueDAO current = (ContructualProductionIssueDAO)enumerator.Current;
                        short num = Convert.ToInt16(current.Item_id);
                        decimal num1 = Convert.ToDecimal(current.Quantity);
                        if (this.getAvailableStock(num) >= num1)
                        {
                            continue;
                        }
                        this.msgBox.AddMessage(string.Concat("Available Stock is less than reqiured quantity of ", current.ItemName, " "), MsgBoxs.enmMessageType.Attention);
                        flag = false;
                        return flag;
                    }
                    return true;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                return flag;
            }
            return true;
        }
    }
}