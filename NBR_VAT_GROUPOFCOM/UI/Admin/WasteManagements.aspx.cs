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
    public partial class WasteManagements : Page, IRequiresSessionState
    {
     

        private AddItemBLL objBLL = new AddItemBLL();

        private ChallanBLL objcBLL = new ChallanBLL();

        private WastemanagementDAO objCP = new WastemanagementDAO();

        private ContructualProductionBLL objCPBLL = new ContructualProductionBLL();

      

        public WasteManagements()
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
                BLL.Utility.InsertErrorTrackNew(exception.Message, "Own_Production_6.4", "btnAddItem_Click", fileLineNumber);
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
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WastemanagementMasterDAO wastemanagementMasterDAO = new WastemanagementMasterDAO();
            try
            {
                if (this.validation())
                {
                    wastemanagementMasterDAO = this.fillCPMasterData(wastemanagementMasterDAO);
                    if (wastemanagementMasterDAO != null)
                    {
                        ArrayList arrayLists = new ArrayList();
                        arrayLists = this.getRowItemPriceProperties(arrayLists);
                        if (arrayLists == null || arrayLists.Count == 0)
                        {
                            this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else if (!this.objCPBLL.insertWastemanagementInfo(wastemanagementMasterDAO, arrayLists))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Product Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.ClearAllControlsValue();
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
                BLL.Utility.InsertErrorTrackNew(exception.Message, "Own_Production_6.4", "btnSave_Click", fileLineNumber);
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
        }

        protected void chkDiscard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDiscard.Checked)
            {
                this.drpItem.Enabled = false;
                this.btnAdd.Enabled = false;
                return;
            }
            this.drpItem.Enabled = true;
            this.btnAdd.Enabled = true;
        }

        private void clearAll()
        {
            this.LoadCategory("R");
            ListItem listItem = new ListItem("---Select---", "-99");
            this.drpItem.SelectedValue = "-99";
            this.lblHSCode.Text = "";
            this.txtQuantity.Text = "";
            this.lblUnit.Text = "";
            this.txtRemark.Text = "";
            this.avlQuantity.Text = "";
        }

        private void ClearAllControlsValue()
        {
            this.drpParty.SelectedValue = "-999";
            this.txtAddress.Text = "";
            this.txtChallanNo.Text = "";
            this.drpFinishProduct.SelectedValue = "-99";
            this.txtChallanDate.Text = DateTime.Now.Date.ToShortDateString();
            this.drpChDtHr.SelectedIndex = 0;
            this.drpChDtMin.SelectedIndex = 0;
            this.Session["CP_DETAIL"] = new ArrayList();
            this.loadGridView();
            this.drpFinishProduct.SelectedValue = "-99";
            this.gvIngredience.DataSource = null;
            this.gvIngredience.DataBind();
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
                this.loadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpChallan_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList dropDownList = (DropDownList)namingContainer.FindControl("drpChallan");
            TextBox str = (TextBox)namingContainer.FindControl("challanDate");
            TextBox textBox = (TextBox)namingContainer.FindControl("purchase_quantity");
            TextBox str1 = (TextBox)namingContainer.FindControl("challanPrice");
            TextBox textBox1 = (TextBox)namingContainer.FindControl("vat");
            TextBox textBox2 = (TextBox)namingContainer.FindControl("expireDate");
            int num = Convert.ToInt32(dropDownList.SelectedValue);
            DataTable purchaseInfoByChallanId = this.objcBLL.GetPurchaseInfoByChallanId(num);
            if (purchaseInfoByChallanId.Rows.Count > 0)
            {
                str.Text = purchaseInfoByChallanId.Rows[0]["date_challan"].ToString();
                textBox.Text = purchaseInfoByChallanId.Rows[0]["quantity"].ToString();
                str1.Text = purchaseInfoByChallanId.Rows[0]["purchase_unit_price"].ToString();
                textBox1.Text = purchaseInfoByChallanId.Rows[0]["purchase_vat"].ToString();
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
            ArrayList arrayLists = new ArrayList();
            int priceId = 0;
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            int num2 = 0;
            if (this.drpFinishProduct.SelectedValue != "-99")
            {
                num2 = Convert.ToInt32(this.drpFinishProduct.SelectedValue);
            }
            priceId = this.objCPBLL.GetPriceId(num2);
            DataTable issuedProductQuantity = this.objCPBLL.GetIssuedProductQuantity(priceId);
            if (issuedProductQuantity.Rows.Count > 0)
            {
                num = Convert.ToDecimal(issuedProductQuantity.Rows[0]["quantity"]);
            }
            DataTable receivedProductQuantity = this.objCPBLL.GetReceivedProductQuantity(priceId);
            if (receivedProductQuantity.Rows.Count > 0)
            {
                num1 = Convert.ToDecimal(receivedProductQuantity.Rows[0]["quantity"]);
            }
            DataTable quantityToMadePerProduct = this.objCPBLL.GetQuantityToMadePerProduct(num2, priceId);
            if (quantityToMadePerProduct.Rows.Count > 0)
            {
                for (int i = 0; i < quantityToMadePerProduct.Rows.Count; i++)
                {
                    WastemanagementDAO wastemanagementDAO = new WastemanagementDAO();
                    decimal num3 = new decimal(0);
                    decimal num4 = new decimal(0);
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    decimal num10 = new decimal(0);
                    short num11 = 0;
                    short num12 = 0;
                    string str = "";
                    int num13 = 0;
                    decimal num14 = new decimal(0);
                    decimal num15 = new decimal(0);
                    if (quantityToMadePerProduct.Rows[i]["unit_price"].ToString() != "")
                    {
                        Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["unit_price"]);
                    }
                    num11 = Convert.ToInt16(quantityToMadePerProduct.Rows[i]["unit_id"].ToString());
                    num12 = Convert.ToInt16(quantityToMadePerProduct.Rows[i]["actualUnit_id"].ToString());
                    num9 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["quantity"].ToString());
                    num13 = Convert.ToInt32(quantityToMadePerProduct.Rows[i]["item_id"].ToString());
                    str = quantityToMadePerProduct.Rows[i]["item_name"].ToString();
                    num14 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["production_quantity"]);
                    num6 = (num * num9) / num14;
                    num7 = (num1 * num9) / num14;
                    DataTable value = this.objBLL.GetValue(num12, num11);
                    if (value.Rows.Count > 0)
                    {
                        num3 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                    }
                    if (num3 > new decimal(0))
                    {
                        num5 = num6 / num3;
                        num8 = num7 / num3;
                    }
                    if (num3 == new decimal(0))
                    {
                        DataTable valueSec = this.objBLL.GetValueSec(num12, num11);
                        if (valueSec.Rows.Count <= 0)
                        {
                            num5 = num6;
                            num8 = num7;
                        }
                        else if (num4 <= new decimal(0))
                        {
                            num5 = num6;
                            num8 = num7;
                        }
                        else
                        {
                            num4 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                            num5 = num6 * num3;
                            num8 = num7 * num3;
                        }
                    }
                    wastemanagementDAO.PreQuantity = num9;
                    num15 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["txtquantityprice"].ToString());
                    this.getAllPropertyByID(num13);
                    Convert.ToInt16(i + 1);
                    wastemanagementDAO.Price = (num * num15) / num14;
                    wastemanagementDAO.Item_id = num13;
                    wastemanagementDAO.ItemName = str;
                    wastemanagementDAO.Quantity = num5;
                    wastemanagementDAO.UsedqUnit = num12;
                    wastemanagementDAO.Unit = num11;
                    wastemanagementDAO.Remark = this.txtRemark.Text;
                    wastemanagementDAO.UnitName = quantityToMadePerProduct.Rows[i]["unit_code"].ToString();
                    wastemanagementDAO.TotUnitName = quantityToMadePerProduct.Rows[i]["totqunitcode"].ToString();
                    wastemanagementDAO.ReceivedQuantiy = num8;
                    arrayLists.Add(wastemanagementDAO);
                    wastemanagementDAO = null;
                }
            }
            this.Session["CPISSUE_DETAIL_GRID_DATA"] = arrayLists;
            this.showIngredience();
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
                this.LoadCategory("");
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

        private void fillCatSubCat()
        {
        }

        private WastemanagementMasterDAO fillCPMasterData(WastemanagementMasterDAO objCPMaster)
        {
            try
            {
                if (this.drpParty.SelectedValue != "-99")
                {
                    objCPMaster.Factory_id = Convert.ToInt32(this.drpParty.SelectedValue);
                }
                objCPMaster.Transactiontyp = Convert.ToInt32(this.drpTransactionType.SelectedValue);
                objCPMaster.Batch_no = (!string.IsNullOrEmpty(this.txtBatchNo.Text) ? this.txtBatchNo.Text : "");
                objCPMaster.Challan_date = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objCPMaster.Challan_no = (!string.IsNullOrEmpty(this.txtChallanNo.Text) ? this.txtChallanNo.Text : "");
                objCPMaster.Finished_porductId = Convert.ToInt32(this.drpFinishProduct.SelectedValue);
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "wastemanagement", "fillCPMasterData");
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
            DataTable creditNoteNo = craDebBLL.GetCreditNoteNo(4, num, num1);
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
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO()
            {
                RowNo = num1,
                ItemName = this.drpItem.SelectedItem.ToString(),
                Item_id = Convert.ToInt32(this.drpItem.SelectedValue),
                Property_id1 = Convert.ToInt16(this.lblProp1.Text),
                Property_id2 = Convert.ToInt16(this.lblProp2.Text),
                Property_id3 = Convert.ToInt16(this.lblProp3.Text),
                Property_id4 = Convert.ToInt16(this.lblProp4.Text),
                Property_id5 = Convert.ToInt16(this.lblProp5.Text),
                UnitName = this.lblUnit.Text.ToString(),
                Unit_id = Convert.ToInt16(this.lblUnitId.Text),
                Quantity = Convert.ToDecimal(this.txtQuantity.Text)
            };
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
                    ((ContructualProductionIssueDAO)item[i]).Quantity = ((ContructualProductionIssueDAO)item[i]).Quantity + contructualProductionIssueDAO.Quantity;
                    this.Session["CP_DETAIL"] = item;
                    this.Session["CP_DETAIL_R"] = item;
                    return;
                }
            }
            contructualProductionIssueDAO.Remark = this.txtRemark.Text;
            contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
            contructualProductionIssueDAO.Status = 'I';
            item.Add(contructualProductionIssueDAO);
            this.Session["CP_DETAIL"] = item;
            this.Session["CP_DETAIL_R"] = item;
        }

        private void getCPDetailDatagvIngredience()
        {
            ArrayList arrayList = (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"];
            if (arrayList == null)
            {
                arrayList = new ArrayList();
            }
            short rowNo = Convert.ToInt16(arrayList.Count + 1);
            decimal d = (this.lblUnitPrice.Text.Trim() != "") ? Convert.ToDecimal(this.lblUnitPrice.Text.Trim()) : 0m;
            decimal d2 = (this.lblSdRate.Text.Trim() != "") ? Convert.ToDecimal(this.lblSdRate.Text.Trim()) : 0m;
            decimal d3 = (this.lblVatRate.Text.Trim() != "") ? Convert.ToDecimal(this.lblVatRate.Text.Trim()) : 0m;
            ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
            contructualProductionIssueDAO.RowNo = (int)rowNo;
            contructualProductionIssueDAO.ItemName = this.drpItem.SelectedItem.ToString();
            contructualProductionIssueDAO.Item_id = Convert.ToInt32(this.drpItem.SelectedValue);
            contructualProductionIssueDAO.Property_id1 = Convert.ToInt16(this.lblProp1.Text);
            contructualProductionIssueDAO.Property_id2 = Convert.ToInt16(this.lblProp2.Text);
            contructualProductionIssueDAO.Property_id3 = Convert.ToInt16(this.lblProp3.Text);
            contructualProductionIssueDAO.Property_id4 = Convert.ToInt16(this.lblProp4.Text);
            contructualProductionIssueDAO.Property_id5 = Convert.ToInt16(this.lblProp5.Text);
            contructualProductionIssueDAO.UnitName = this.lblUnit.Text.ToString();
            contructualProductionIssueDAO.Unit_id = (int)Convert.ToInt16(this.lblUnitId.Text);
            contructualProductionIssueDAO.Quantity = Convert.ToDecimal(this.txtQuantity.Text);
            contructualProductionIssueDAO.Price = contructualProductionIssueDAO.Quantity * d + (contructualProductionIssueDAO.Quantity * d + contructualProductionIssueDAO.Quantity * d * d2 / 100m) * d3 / 100m + contructualProductionIssueDAO.Quantity * d * d2 / 100m;
            decimal d4 = Convert.ToDecimal(this.avlQuantity.Text);
            if (contructualProductionIssueDAO.Quantity > d4)
            {
                this.msgBox.AddMessage("Stock is not available. Current stock: " + d4.ToString(), MsgBoxs.enmMessageType.Error);
                return;
            }
            int i = 0;
            while (i < arrayList.Count)
            {
                if (contructualProductionIssueDAO.Item_id == ((ContructualProductionIssueDAO)arrayList[i]).Item_id)
                {
                    if (((ContructualProductionIssueDAO)arrayList[i]).Quantity + contructualProductionIssueDAO.Quantity > d4)
                    {
                        this.msgBox.AddMessage("Stock is not available. Current stock: " + d4.ToString(), MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    ((ContructualProductionIssueDAO)arrayList[i]).Quantity = ((ContructualProductionIssueDAO)arrayList[i]).Quantity + contructualProductionIssueDAO.Quantity;
                    ((ContructualProductionIssueDAO)arrayList[i]).Price = ((ContructualProductionIssueDAO)arrayList[i]).Price + contructualProductionIssueDAO.Price;
                    this.Session["CPISSUE_DETAIL_GRID_DATA"] = arrayList;
                    return;
                }
                else
                {
                    i++;
                }
            }
            contructualProductionIssueDAO.Remark = this.txtRemark.Text;
            contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
            contructualProductionIssueDAO.Status = 'I';
            arrayList.Add(contructualProductionIssueDAO);
            this.Session["CPISSUE_DETAIL_GRID_DATA"] = arrayList;
        }

        private ContructualProductionIssueMasterDAO getCPMasterData()
        {
            ContructualProductionIssueMasterDAO contructualProductionIssueMasterDAO = new ContructualProductionIssueMasterDAO();
            try
            {
                if (!this.drpParty.Enabled)
                {
                    contructualProductionIssueMasterDAO.IsNewParty = true;
                    contructualProductionIssueMasterDAO.PartyAddress = "999";
                    contructualProductionIssueMasterDAO.PartyBIN = "999";
                }
                else
                {
                    contructualProductionIssueMasterDAO.Party_id = Convert.ToInt16(this.drpParty.SelectedValue);
                    contructualProductionIssueMasterDAO.IsNewParty = false;
                    contructualProductionIssueMasterDAO.PartyName = this.drpParty.SelectedItem.ToString();
                    contructualProductionIssueMasterDAO.PartyAddress = "999";
                    contructualProductionIssueMasterDAO.PartyBIN = "999";
                }
                contructualProductionIssueMasterDAO.OrgName = this.org_name.Text.ToString();
                contructualProductionIssueMasterDAO.OrgBIN = this.lblOrgBIN.Text.ToString();
                contructualProductionIssueMasterDAO.OrgAddress = this.org_address.Text.ToString();
                contructualProductionIssueMasterDAO.ChallanNo = this.txtChallanNo.Text.ToString();
                contructualProductionIssueMasterDAO.IssueTime = string.Concat(this.drpChDtHr.SelectedItem.ToString(), " : ", this.drpChDtMin.SelectedItem.ToString());
                contructualProductionIssueMasterDAO.FinishProduct = this.drpFinishProduct.SelectedItem.ToString();
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
                    contructualProductionIssueDAO.RowNo = num;
                    HiddenField hiddenField = row.FindControl("item_id") as HiddenField;
                    contructualProductionIssueDAO.Item_id = Convert.ToInt32(hiddenField.Value);
                    contructualProductionIssueDAO.ItemName = row.Cells[3].Text;
                    HiddenField hiddenField1 = row.FindControl("unit_id") as HiddenField;
                    contructualProductionIssueDAO.Unit_id = Convert.ToInt16(hiddenField1.Value);
                    HiddenField hiddenField2 = row.FindControl("property_id1") as HiddenField;
                    contructualProductionIssueDAO.Property_id1 = Convert.ToInt16(hiddenField2.Value);
                    HiddenField hiddenField3 = row.FindControl("property_id2") as HiddenField;
                    contructualProductionIssueDAO.Property_id2 = Convert.ToInt16(hiddenField3.Value);
                    HiddenField hiddenField4 = row.FindControl("property_id3") as HiddenField;
                    contructualProductionIssueDAO.Property_id3 = Convert.ToInt16(hiddenField4.Value);
                    HiddenField hiddenField5 = row.FindControl("property_id4") as HiddenField;
                    contructualProductionIssueDAO.Property_id4 = Convert.ToInt16(hiddenField5.Value);
                    HiddenField hiddenField6 = row.FindControl("property_id5") as HiddenField;
                    contructualProductionIssueDAO.Property_id5 = Convert.ToInt16(hiddenField6.Value);
                    Convert.ToDouble(row.Cells[4].Text);
                    TextBox textBox = row.FindControl("received_quantity") as TextBox;
                    Convert.ToDouble(textBox.Text.Trim());
                    contructualProductionIssueDAO.Quantity = Convert.ToInt32(textBox.Text.Trim());
                    contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
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

        private ArrayList getRowItemPriceProperties(ArrayList arrPriceDetail)
        {
            if (this.gvIngredience.Rows.Count > 0)
            {
                for (int i = 0; i < this.gvIngredience.Rows.Count; i++)
                {
                    WastemanagementDAO wastemanagementDAO = new WastemanagementDAO();
                    TextBox textBox = (TextBox)this.gvIngredience.Rows[i].FindControl("ItemName");
                    TextBox textBox1 = (TextBox)this.gvIngredience.Rows[i].FindControl("ItemId");
                    TextBox textBox2 = (TextBox)this.gvIngredience.Rows[i].FindControl("PreQuantity");
                    TextBox textBox3 = (TextBox)this.gvIngredience.Rows[i].FindControl("UnitName");
                    TextBox textBox4 = (TextBox)this.gvIngredience.Rows[i].FindControl("UsedqUnit");
                    TextBox textBox5 = (TextBox)this.gvIngredience.Rows[i].FindControl("used_quantity");
                    TextBox textBox6 = (TextBox)this.gvIngredience.Rows[i].FindControl("TotUnitName");
                    TextBox textBox7 = (TextBox)this.gvIngredience.Rows[i].FindControl("Unit");
                    TextBox textBox8 = (TextBox)this.gvIngredience.Rows[i].FindControl("finished_prod_issued_qty");
                    TextBox textBox9 = (TextBox)this.gvIngredience.Rows[i].FindControl("received_quantity");
                    TextBox textBox10 = (TextBox)this.gvIngredience.Rows[i].FindControl("wastage_quantity_batchwise");
                    TextBox textBox11 = (TextBox)this.gvIngredience.Rows[i].FindControl("PriceValue");
                    TextBox textBox12 = (TextBox)this.gvIngredience.Rows[i].FindControl("remarks");
                    TextBox textBox13 = (TextBox)this.gvIngredience.Rows[i].FindControl("reason");
                    DropDownList dropDownList = (DropDownList)this.gvIngredience.Rows[i].FindControl("drpChallan");
                    TextBox textBox14 = (TextBox)this.gvIngredience.Rows[i].FindControl("challanDate");
                    TextBox textBox15 = (TextBox)this.gvIngredience.Rows[i].FindControl("purchase_quantity");
                    TextBox textBox16 = (TextBox)this.gvIngredience.Rows[i].FindControl("challanPrice");
                    TextBox textBox17 = (TextBox)this.gvIngredience.Rows[i].FindControl("vat");
                    TextBox textBox18 = (TextBox)this.gvIngredience.Rows[i].FindControl("expireDate");
                    wastemanagementDAO.Item_id = Convert.ToInt32(textBox1.Text);
                    wastemanagementDAO.PreQuantity = (!string.IsNullOrEmpty(textBox2.Text) ? Convert.ToDecimal(textBox2.Text) : new decimal(0));
                    wastemanagementDAO.Quantity = (!string.IsNullOrEmpty(textBox5.Text) ? Convert.ToDecimal(textBox5.Text) : new decimal(0));
                    wastemanagementDAO.UsedqUnit = (!string.IsNullOrEmpty(textBox4.Text) ? Convert.ToInt32(textBox4.Text) : 0);
                    wastemanagementDAO.Unit = (!string.IsNullOrEmpty(textBox7.Text) ? Convert.ToInt32(textBox7.Text) : 0);
                    wastemanagementDAO.FinishpQuantity = (!string.IsNullOrEmpty(textBox8.Text) ? Convert.ToDecimal(textBox8.Text) : new decimal(0));
                    wastemanagementDAO.ReceivedQuantiy = (!string.IsNullOrEmpty(textBox9.Text) ? Convert.ToDecimal(textBox9.Text) : new decimal(0));
                    wastemanagementDAO.WasteQuantity = (!string.IsNullOrEmpty(textBox10.Text) ? Convert.ToDecimal(textBox10.Text) : new decimal(0));
                    wastemanagementDAO.ChallanId = (!string.IsNullOrEmpty(dropDownList.SelectedValue) ? Convert.ToInt32(dropDownList.SelectedValue) : 0);
                    wastemanagementDAO.ChallanDate = (!string.IsNullOrEmpty(textBox14.Text.Trim()) ? DateTime.ParseExact(textBox14.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue);
                    wastemanagementDAO.ExpireDate = (!string.IsNullOrEmpty(textBox18.Text) ? DateTime.ParseExact(textBox18.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue);
                    wastemanagementDAO.Purchasequantity = (!string.IsNullOrEmpty(textBox15.Text) ? Convert.ToDecimal(textBox15.Text) : new decimal(0));
                    wastemanagementDAO.Purchaseprice = (!string.IsNullOrEmpty(textBox16.Text) ? Convert.ToDecimal(textBox16.Text) : new decimal(0));
                    wastemanagementDAO.Price = (!string.IsNullOrEmpty(textBox11.Text) ? Convert.ToDecimal(textBox11.Text) : new decimal(0));
                    wastemanagementDAO.Vat = (!string.IsNullOrEmpty(textBox17.Text) ? Convert.ToDecimal(textBox17.Text) : new decimal(0));
                    arrPriceDetail.Add(wastemanagementDAO);
                    wastemanagementDAO = null;
                }
            }
            return arrPriceDetail;
        }

        private void getUsedQuantity()
        {
            ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
            ArrayList arrayLists = new ArrayList();
            int priceId = 0;
            decimal num = new decimal(0);
            int num1 = 0;
            AddItemBLL addItemBLL = new AddItemBLL();
            num = new decimal(1);
            if (this.drpFinishProduct.SelectedValue != "-99")
            {
                num1 = Convert.ToInt32(this.drpFinishProduct.SelectedValue);
            }
            priceId = contructualProductionBLL.GetPriceId(num1);
            DropDownList str = (DropDownList)this.gvIngredience.FindControl("drpChallan");
            DataTable quantityToMadePerProduct = contructualProductionBLL.GetQuantityToMadePerProduct(num1, priceId);
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
                    string str1 = "";
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
                    DataTable itemChallaNo = addItemBLL.GetItemChallaNo(num10);
                    if (itemChallaNo.Rows.Count > 0)
                    {
                        str.DataSource = itemChallaNo;
                        str.DataTextField = itemChallaNo.Columns["challan_no"].ToString();
                        str.DataValueField = itemChallaNo.Columns["challan_id"].ToString();
                        str.DataBind();
                    }
                    ListItem listItem = new ListItem("-- Select ---", "-99");
                    str.Items.Insert(0, listItem);
                    str1 = quantityToMadePerProduct.Rows[i]["item_name"].ToString();
                    num11 = Convert.ToDecimal(quantityToMadePerProduct.Rows[i]["production_quantity"]);
                    num5 = (num * num6) / num11;
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
                    contructualProductionIssueDAO.ItemName = str1;
                    contructualProductionIssueDAO.Quantity = num4;
                    contructualProductionIssueDAO.Unit_id = num9;
                    contructualProductionIssueDAO.RowNo = num12;
                    contructualProductionIssueDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
                    contructualProductionIssueDAO.Status = 'I';
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
            this.Session["CPISSUE_DETAIL_GRID_DATA"] = arrayLists;
        }

        private bool gridValidation()
        {
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

        protected void gvIngredience_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"];
                item.RemoveAt(e.RowIndex);
                this.Session["CPISSUE_DETAIL_GRID_DATA"] = item;
                this.showIngredience();
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "Own_Production_6.4", "gvIngredience_RowDeleting");
            }
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
                BLL.Utility.InsertErrorTrack(exception.Message, "Own_Production_6.4", "gvItem_RowDeleting");
            }
        }

        private void LoadCategory(string type)
        {
            List<Category> categories = new List<Category>();
            (new AddItemBLL()).getCategory();
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
                ListItem listItem = new ListItem("---Select---", "-99");
                this.drpFinishProduct.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadGridView()
        {
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
            AddItemBLL addItemBLL = new AddItemBLL();
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
            DataTable dataTable = (new ChallanBLL()).GetselfPartyInfo();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                this.drpParty.DataSource = dataTable;
                this.drpParty.DataTextField = dataTable.Columns["party_name"].ToString();
                this.drpParty.DataValueField = dataTable.Columns["party_id"].ToString();
                this.drpParty.DataBind();
            }
            this.Session["PARTY_INFO"] = dataTable;
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
                    this.txtChallanDate.Text = DateTime.Today.Date.ToShortDateString();
                    this.LoadCategory("R");
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    ListItem listItem1 = new ListItem("-- Select --", "-99");
                    ListItem listItem2 = new ListItem("-- Select --", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                    this.loadHours();
                    this.loadMinute();
                    this.loadItems();
                    this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
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
            for (int i = 0; i < this.gvIngredience.Rows.Count; i++)
            {
                DropDownList str = (DropDownList)this.gvIngredience.Rows[i].FindControl("drpChallan");
                TextBox textBox = (TextBox)this.gvIngredience.Rows[i].FindControl("ItemId");
                int num = Convert.ToInt32(textBox.Text);
                DataTable itemChallaNo = this.objBLL.GetItemChallaNo(num);
                if (itemChallaNo.Rows.Count > 0)
                {
                    str.DataSource = itemChallaNo;
                    str.DataTextField = itemChallaNo.Columns["challan_no"].ToString();
                    str.DataValueField = itemChallaNo.Columns["challan_id"].ToString();
                    str.DataBind();
                    ListItem listItem = new ListItem("-- Select ---", "-99");
                    str.Items.Insert(0, listItem);
                }
            }
        }

        private void showReport()
        {
            try
            {
                string[] strArrays = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
                string[] strArrays1 = strArrays;
                string[] strArrays2 = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };
                string[] strArrays3 = strArrays2;
                ContructualProductionIssueMasterDAO item = (ContructualProductionIssueMasterDAO)this.Session["CP_MASTER_DATA"];
                this.OrgName.Text = item.OrgName;
                this.OrgAddress.Text = item.OrgAddress;
                this.PartyName.Text = item.PartyName;
                this.PartyAddress.Text = this.org_address.Text;
                this.PartyBIN.Text = this.lblOrgBIN.Text;
                this.vehicleType.Text = string.Concat(item.VehicleType, "  ", item.VehicleNo);
                this.ChallanNo.Text = item.ChallanNo;
                this.ChallanIssueTime.Text = item.IssueTime;
                this.ChallanDeliverDate.Text = string.Concat(item.DeliveryDate, "  ", item.DeliveryTime);
                ContructualProductionIsCheck contructualProductionIsCheck = new ContructualProductionIsCheck();
                ArrayList arrayLists = (((ArrayList)this.Session["CP_DETAIL"]).Count > 0 ? (ArrayList)this.Session["CP_DETAIL"] : (ArrayList)this.Session["CPISSUE_DETAIL_GRID_DATA"]);
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO();
                string str = "";
                int count = arrayLists.Count;
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    string str1 = i.ToString();
                    string str2 = str1.Replace(strArrays1[i], strArrays3[i]);
                    contructualProductionIssueDAO = (ContructualProductionIssueDAO)arrayLists[i];
                    str = string.Concat(str, "<tr>");
                    str = string.Concat(str, "<td style='border:1px solid gray'>", str2, "</td>");
                    str = string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", contructualProductionIssueDAO.ItemName, "</td>");
                    str = (i != 0 ? string.Concat(str, "<td style='border:1px solid gray'>-</td>") : string.Concat(str, "<td style='border:1px solid gray'>", this.drpFinishProduct.SelectedItem.Text.Trim(), "</td>"));
                    object obj = str;
                    object[] quantity = new object[] { obj, "<td style='border:1px solid gray'>", contructualProductionIssueDAO.Quantity, " ", contructualProductionIssueDAO.TotUnitName, "</td>" };
                    str = string.Concat(quantity);
                    str = string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", contructualProductionIssueDAO.Remark, "</td>");
                    str = string.Concat(str, "</tr>");
                    this.HaiMan.Text = str;
                }
                this.lblDutyOfficer.Text = this.Session["EMPLOYEE_NAME"].ToString();
                this.btnPrintReport.Visible = true;
                this.cpPrint.Visible = true;
                this.printBTN.Text = "Hide Report";
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtBatchNo_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
        }

        private bool validation()
        {
            if (this.txtChallanNo.Text == "")
            {
                this.msgBox.AddMessage(" Enter Challan No or Select Discard", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtChallanDate.Text != "")
            {
                return true;
            }
            this.msgBox.AddMessage(" Enter Challan Date", MsgBoxs.enmMessageType.Attention);
            return false;
        }
    }
}