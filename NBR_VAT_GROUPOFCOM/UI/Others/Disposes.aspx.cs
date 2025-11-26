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

namespace NBR_VAT_GROUPOFCOM.UI.Others
{
    public partial class Disposes : Page, IRequiresSessionState
    {
        private TransSaleMasterBLL objtrnsSaleMasterBLL = new TransSaleMasterBLL();

        private trnsSaleMasterBLL objSaleMasterBLL = new trnsSaleMasterBLL();

        private trnsSaleMasterDAO objtrnsSaleMasterDAO = new trnsSaleMasterDAO();

        private trnsNoteMasterBLL objtrnsNoteMasterBLL = new trnsNoteMasterBLL();

        private DisposeDAO objDisposeDAO = new DisposeDAO();

        private string challan = string.Empty;

     

        public Disposes()
        {
        }

        private void AddDetailDataInGrid()
        {
            ArrayList item = (ArrayList)this.Session["dtDisSession"];
            this.dgvDispose.DataSource = item;
            this.dgvDispose.DataBind();
        }

        protected void btnRefreshChallan_Click(object sender, EventArgs e)
        {
            this.refreshGrid();
        }

        protected void btnRefreshItem_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        protected void btnSaveChallan_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.MasterValidation())
                {
                    this.objtrnsSaleMasterDAO = this.GetInsertMasterValues(this.objtrnsSaleMasterDAO);
                    if (this.objtrnsSaleMasterDAO != null)
                    {
                        ArrayList arrayLists = new ArrayList();
                        arrayLists = (ArrayList)this.Session["dtDisSession"];
                        if (arrayLists == null || arrayLists.Count == 0)
                        {
                            this.dgvDispose.DataSource = null;
                            this.dgvDispose.DataBind();
                            this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else if (this.btnSaveChallan.Text == "Dispose")
                        {
                            if (!this.objSaleMasterBLL.InsertDisposeData(this.objtrnsSaleMasterDAO, arrayLists))
                            {
                                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                            else
                            {
                                this.msgBox.AddMessage("Dispose Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                this.clearForm();
                                this.refreshGrid();
                                this.getChallanNo();
                            }
                        }
                    }
                    else
                    {
                        this.msgBox.AddMessage("Please insert master data properly.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validation())
                {
                    this.fillDetailProperties();
                    this.AddDetailDataInGrid();
                    this.clearForm();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void clearForm()
        {
            this.drpPurchaseChlNo.SelectedValue = "0";
            this.drpItem.SelectedValue = "0";
            this.drpCategory.SelectedValue = "0";
            this.drpSubCat.SelectedValue = "0";
            this.clearTexts();
        }

        private void clearTexts()
        {
            this.lblStock.Text = "";
            this.txtDispose.Text = "";
            this.lblActualPrice.Text = "";
            this.lblVATPaid.Text = "";
            this.lblUnitName.Text = "";
            this.lblUnitName0.Text = "";
            this.lblPrevUnitPrice.Text = "";
            this.lblUnitVAT.Text = "";
            this.txtPresentUnitPrice.Text = "";
            this.txtDisposeReason.Text = "";
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            if (this.drpItem.SelectedValue == "0")
            {
                this.drpCategory.SelectedValue = "0";
                this.drpSubCat.SelectedValue = "0";
            }
            else
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                DataSet itemInfoByItemID = addItemBLL.getItemInfoByItemID(Convert.ToInt16(this.drpItem.SelectedValue));
                if (itemInfoByItemID != null)
                {
                    if (itemInfoByItemID.Tables[0].Rows[0]["parent_id"].ToString() != "0")
                    {
                        this.drpCategory.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["parent_id"].ToString();
                        this.drpSubCat.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["category_id"].ToString();
                    }
                    else
                    {
                        this.drpCategory.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["category_id"].ToString();
                        this.drpSubCat.SelectedValue = "0";
                    }
                }
                trnsPurchaseMasterBLL _trnsPurchaseMasterBLL = new trnsPurchaseMasterBLL();
                DataSet itemInfoForStock = _trnsPurchaseMasterBLL.getItemInfoForStock(Convert.ToInt16(this.drpPurchaseChlNo.SelectedValue), Convert.ToInt16(this.drpItem.SelectedValue));
                if (itemInfoForStock != null)
                {
                    this.hfActualPrice.Value = itemInfoForStock.Tables[0].Rows[0]["actual_price"].ToString();
                    this.hfQty.Value = itemInfoForStock.Tables[0].Rows[0]["quantity"].ToString();
                    num = Convert.ToDecimal(itemInfoForStock.Tables[0].Rows[0]["vat_rate"].ToString());
                    num1 = Convert.ToDecimal(itemInfoForStock.Tables[0].Rows[0]["sd_rate"].ToString());
                    this.vatRate.Text = num.ToString();
                    this.sdRate.Text = num1.ToString();
                    this.hfVAT.Value = itemInfoForStock.Tables[0].Rows[0]["vat"].ToString();
                    this.hfDetailId.Value = itemInfoForStock.Tables[0].Rows[0]["detail_id"].ToString();
                    this.hfLotNo.Value = itemInfoForStock.Tables[0].Rows[0]["LotNo"].ToString();
                    this.hfUnitId.Value = itemInfoForStock.Tables[0].Rows[0]["unitId"].ToString();
                    DataSet itemStock = this.objtrnsSaleMasterBLL.getItemStock(Convert.ToInt16(this.drpPurchaseChlNo.SelectedValue), Convert.ToInt16(this.hfDetailId.Value));
                    double num7 = 0;
                    double num8 = 0;
                    if (itemStock.Tables[0].Rows[0]["saleQty"].ToString() != "")
                    {
                        num7 = Convert.ToDouble(itemStock.Tables[0].Rows[0]["saleQty"]);
                    }
                    num8 = Convert.ToDouble(this.hfQty.Value) - num7;
                    num2 = Convert.ToDecimal(num8) * Convert.ToDecimal(this.hfActualPrice.Value);
                    num6 = (num2 * num1) / new decimal(100);
                    num4 = ((num2 + num6) * num) / new decimal(100);
                    num5 = (Convert.ToDecimal(this.hfActualPrice.Value) * num1) / new decimal(100);
                    num3 = ((Convert.ToDecimal(this.hfActualPrice.Value) + num5) * num) / new decimal(100);
                    this.lblStock.Text = num8.ToString();
                    double num9 = Convert.ToDouble(this.hfActualPrice.Value) * num8;
                    this.lblActualPrice.Text = num9.ToString("0.00");
                    this.lblVATPaid.Text = num4.ToString("0.00");
                    TextBox str = this.lblPrevUnitPrice;
                    decimal num10 = Convert.ToDecimal(this.hfActualPrice.Value);
                    str.Text = num10.ToString("0.00");
                    this.lblUnitVAT.Text = num3.ToString("0.00");
                    this.lblUnitName.Text = itemInfoForStock.Tables[0].Rows[0]["uname"].ToString();
                    this.lblUnitName0.Text = itemInfoForStock.Tables[0].Rows[0]["uname"].ToString();
                    return;
                }
            }
        }

        protected void drpOrgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpOrgName.SelectedValue == "0")
            {
                this.lblAddress.Text = "";
                this.lblPhone.Text = "";
                this.lblBIN.Text = "";
                this.lblBusinessActivity.Text = "";
                this.lblAreaCode.Text = "";
                this.drpPurchaseChlNo.SelectedValue = "0";
                return;
            }
            DataTable orgById = this.objtrnsNoteMasterBLL.getOrgById(Convert.ToInt16(this.drpOrgName.SelectedValue));
            this.lblAddress.Text = orgById.Rows[0]["address"].ToString();
            this.lblPhone.Text = orgById.Rows[0]["ba_phone"].ToString();
            this.lblBIN.Text = orgById.Rows[0]["registration_no"].ToString();
            this.lblBusinessActivity.Text = orgById.Rows[0]["business_activity"].ToString();
            this.lblAreaCode.Text = orgById.Rows[0]["vc_code"].ToString();
            Util.fillChallanNoByOrgId(this.drpPurchaseChlNo, Convert.ToInt16(this.drpOrgName.SelectedValue));
        }

        protected void drpPurchaseChlNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpPurchaseChlNo.SelectedValue == "0")
            {
                this.drpItem.SelectedValue = "0";
                return;
            }
            string str = this.drpPurchaseChlNo.SelectedItem.ToString();
            string[] strArrays = str.Split(new char[] { '#' });
            Disposes uIDispose = this;
            uIDispose.challan = string.Concat(uIDispose.challan, strArrays[0], ",");
            this.lblPurchaseChallan.Text = this.challan;
            Util.fillPurchasedItembyChallanId(this.drpItem, Convert.ToInt16(this.drpPurchaseChlNo.SelectedValue));
        }

        private void fillDetailProperties()
        {
            this.Session["dtDisSession"] = new ArrayList();
            DisposeDAO disposeDAO = new DisposeDAO();
            ArrayList item = (ArrayList)this.Session["dtDisSession"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            try
            {
                disposeDAO.RowNo = num;
                disposeDAO.Category = this.drpCategory.SelectedItem.Text;
                disposeDAO.SubCategory = this.drpSubCat.SelectedItem.Text;
                disposeDAO.Item = this.drpItem.SelectedItem.Text;
                disposeDAO.PurchaseChallanNo = this.drpPurchaseChlNo.SelectedItem.Text;
                disposeDAO.SaleChalanNo = this.txtChallanNo.Text;
                disposeDAO.CurrentStock = Convert.ToDouble(this.lblStock.Text);
                disposeDAO.ActualTotalPrice = Convert.ToDouble(this.lblActualPrice.Text);
                disposeDAO.DisposeQuantity = Convert.ToDouble(this.txtDispose.Text);
                disposeDAO.PresentUnitPrice = Convert.ToDouble(this.txtPresentUnitPrice.Text);
                disposeDAO.DisposeReason = this.drpDisposalReason.SelectedItem.Text;
                disposeDAO.LotNo = Convert.ToInt16(this.hfLotNo.Value);
                disposeDAO.DetailId = Convert.ToInt16(this.hfDetailId.Value);
                disposeDAO.ItemId = Convert.ToInt16(this.drpItem.SelectedValue);
                disposeDAO.UnitId = Convert.ToInt16(this.hfUnitId.Value);
                disposeDAO.Vat = Convert.ToDouble(this.hfVAT.Value);
                disposeDAO.DisposeReasonD = Convert.ToInt16(this.drpDisposalReason.SelectedValue);
                disposeDAO.DisposeReasonM = 10;
                disposeDAO.PurchaseChallanId = Convert.ToInt16(this.drpPurchaseChlNo.SelectedValue);
                disposeDAO.ActualPrice = Convert.ToDouble(this.lblPrevUnitPrice.Text);
                disposeDAO.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                disposeDAO.Remarks = this.txtDisposeReason.Text;
                disposeDAO.Vat2 = Convert.ToDecimal(this.lblVat.Text);
                item.Add(disposeDAO);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                item = null;
            }
            this.Session["dtDisSession"] = item;
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
                }
            }
        }

        private void getChallanNo()
        {
            CraDebBLL craDebBLL = new CraDebBLL();
            int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            short num1 = Convert.ToInt16(this.drpBranchName.SelectedValue);
            DataTable creditNoteNo = craDebBLL.GetCreditNoteNo(13, num, num1);
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

        private trnsSaleMasterDAO GetInsertMasterValues(trnsSaleMasterDAO objtrnsSaleMasterDAO)
        {
            objtrnsSaleMasterDAO.OrganizationId = Convert.ToInt16(this.drpOrgName.SelectedValue);
            string text = this.lblPurchaseChallan.Text;
            char[] chrArray = new char[] { ',' };
            objtrnsSaleMasterDAO.ChallanNo = text.TrimEnd(chrArray);
            objtrnsSaleMasterDAO.ChallanBookID = Convert.ToInt32(this.hdBookId.Value);
            objtrnsSaleMasterDAO.ChallanPageNo = Convert.ToInt32(this.hdPageNo.Value);
            DateTime standardDateFromDdMMyyyy = BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.dtpDate0.Text);
            objtrnsSaleMasterDAO.ChallanYear = standardDateFromDdMMyyyy.Year;
            objtrnsSaleMasterDAO.ChallanType = "D";
            objtrnsSaleMasterDAO.SaleType = "W";
            objtrnsSaleMasterDAO.TransType = "L";
            objtrnsSaleMasterDAO.DateChallan = DateTime.ParseExact(this.dtpDate0.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objtrnsSaleMasterDAO.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
            objtrnsSaleMasterDAO.Remarks = this.txtDisposeReason.Text;
            objtrnsSaleMasterDAO.DisposeIDM = 10;
            objtrnsSaleMasterDAO.DisposeIDD = Convert.ToInt16(this.drpDisposalReason.SelectedItem.Value);
            if (Convert.ToInt16(this.drpDisposalReason.SelectedItem.Value) != 8)
            {
                objtrnsSaleMasterDAO.MNo = 26;
            }
            else
            {
                objtrnsSaleMasterDAO.MNo = 27;
            }
            return objtrnsSaleMasterDAO;
        }

        private bool MasterValidation()
        {
            if (this.txtChallanNo.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Enter Challan No", MsgBoxs.enmMessageType.Attention);
                this.txtChallanNo.Focus();
                return false;
            }
            if (this.dtpDate0.Text.Trim().Length < 1)
            {
                this.dtpDate0.Focus();
                return false;
            }
            if (this.drpOrgName.SelectedValue == "0")
            {
                this.drpOrgName.Focus();
                return false;
            }
            if (this.dgvDispose.Rows.Count < 1)
            {
                return false;
            }
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Util.fillOrgName(this.drpOrgName);
                this.drpOrgName.SelectedValue = this.Session["ORGANIZATION_ID"].ToString();
                this.objtrnsNoteMasterBLL.getOrgById(Convert.ToInt16(this.drpOrgName.SelectedValue));
                this.lblAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.lblBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                Util.fillChallanNoByOrgId(this.drpPurchaseChlNo, Convert.ToInt16(this.drpOrgName.SelectedValue));
                this.dtpDate0.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                Util.fillItemCategoryDropDownList(this.drpCategory);
                Util.fillSubCategory(this.drpSubCat);
                Util.fillDisposalReason(this.drpDisposalReason);
                this.GetBranchInformation();
                this.getChallanNo();
            }
        }

        private void refreshGrid()
        {
            ArrayList arrayLists = new ArrayList();
            this.Session["dtDisSession"] = arrayLists;
            this.dgvDispose.DataSource = arrayLists;
            this.dgvDispose.DataBind();
        }

        protected void txtDispose_TextChanged(object sender, EventArgs e)
        {
            decimal num = Convert.ToDecimal(this.txtDispose.Text);
            decimal num1 = num * Convert.ToDecimal(this.hfActualPrice.Value);
            decimal num2 = Convert.ToDecimal(this.vatRate.Text.Trim());
            decimal num3 = Convert.ToDecimal(this.sdRate.Text.Trim());
            decimal num4 = (num1 * num3) / new decimal(100);
            decimal num5 = ((num1 + num4) * num2) / new decimal(100);
            this.lblVat.Text = num5.ToString();
        }

        private bool Validation()
        {
            if (this.drpPurchaseChlNo.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Select Purchase Challan", MsgBoxs.enmMessageType.Attention);
                this.drpPurchaseChlNo.Focus();
                return false;
            }
            if (this.drpDisposalReason.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Select Disposal Reason", MsgBoxs.enmMessageType.Attention);
                this.drpDisposalReason.Focus();
                return false;
            }
            if (this.drpItem.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Select An Item", MsgBoxs.enmMessageType.Attention);
                this.drpItem.Focus();
                return false;
            }
            if (this.txtDispose.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Enter Dispose Quantity", MsgBoxs.enmMessageType.Attention);
                this.txtDispose.Focus();
                return false;
            }
            if (this.txtPresentUnitPrice.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Enter Present Unit Price", MsgBoxs.enmMessageType.Attention);
                this.txtPresentUnitPrice.Focus();
                return false;
            }
            if (this.txtDisposeReason.Text.Trim().Length >= 1)
            {
                return true;
            }
            this.msgBox.AddMessage("Enter Remarks", MsgBoxs.enmMessageType.Attention);
            this.txtDisposeReason.Focus();
            return false;
        }
    }
}