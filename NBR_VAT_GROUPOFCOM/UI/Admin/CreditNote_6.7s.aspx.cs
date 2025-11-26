using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    public partial class CreditNote_6__7s : Page, IRequiresSessionState
    {
        private trnsNoteMasterBLL objtrnsNoteMasterBLL = new trnsNoteMasterBLL();

        private trnsNoteMasterDAO objtrnsNoteMasterDAO = new trnsNoteMasterDAO();

        private trnsNoteDetaiDAO objtrnsNoteDetailDAO = new trnsNoteDetaiDAO();

        private TransPartyBLL objTransParty = new TransPartyBLL();

        private DBUtility conDB = new DBUtility();

        private CSVXMLBLL dbBLLLL = new CSVXMLBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

      

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

        public CreditNote_6__7s()
        {
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridValidation())
                {
                    this.loadDetailData();
                    if (!(this.drpType.SelectedValue != "Service") || !(Convert.ToDecimal(this.txtQuantity.Text) > Convert.ToDecimal(this.lblQuantity.Text)))
                    {
                        this.loadGridView();
                        this.detailClear();
                    }
                    else
                    {
                        this.Session["CREDIT_NOTE_DETAIL"] = new ArrayList();
                        this.msgBox.AddMessage("Quantity must be less than Available Quantity.", MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "CreditNote_6.7", "btnAddRow_Click");
            }
        }

        protected void btnOA_Click(object sender, EventArgs e)
        {
            try
            {
                base.Response.Redirect("~/UI/Admin/CreditNote_Extension.aspx");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            CreditNoteMasterDAO creditNoteMasterDAO = new CreditNoteMasterDAO();
            try
            {
                if (this.btnPrint.Text != "Show Report")
                {
                    this.cnPrint.Visible = false;
                    this.btnPrint.Text = "Show Report";
                    this.btnPrintReport.Visible = false;
                }
                else
                {
                    this.lblReceiverName.Text = creditNoteMasterDAO.ProviderName.ToString();
                    this.lblReceiverBIN.Text = creditNoteMasterDAO.ProviderBin.ToString();
                    this.lblReceiverNoteNumber.Text = creditNoteMasterDAO.CreditNotNumber.ToString();
                    this.lblReceiverDate.Text = creditNoteMasterDAO.RecipientDate.ToString();
                    this.lblReceiverTime.Text = creditNoteMasterDAO.RecipientTime.ToString();
                    this.lblProviderName.Text = creditNoteMasterDAO.RecipientName.ToString();
                    this.lblProviderBIN.Text = creditNoteMasterDAO.RecipientBin.ToString();
                    this.lblProviderChallan.Text = creditNoteMasterDAO.MainChallanNo.ToString();
                    this.lblProviderDate2.Text = creditNoteMasterDAO.ProviderDate.ToString();
                    ArrayList item = (ArrayList)this.Session["CREDIT_NOTE_DETAIL"];
                    if (item != null)
                    {
                        double gTotalPrice = 0;
                        double previousAmount = 0;
                        double totalPricewithVat = 0;
                        double vat = 0;
                        double sd = 0;
                        double totalTax = 0;
                        string str = "";
                        CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO();
                        for (int i = 0; i < item.Count; i++)
                        {
                            creditNoteDetailDAO = (CreditNoteDetailDAO)item[i];
                            str = string.Concat(str, "<tr>");
                            object obj = str;
                            object[] objArray = new object[] { obj, "<td style='border:1px solid gray'>", i + 1, "</td>" };
                            str = string.Concat(objArray);
                            str = string.Concat(str, "<td style='border:1px solid gray'>", creditNoteDetailDAO.Item, "</td>");
                            str = string.Concat(str, "<td style='text-align: center;border:1px solid gray'>", creditNoteDetailDAO.Unit, "</td>");
                            object obj1 = str;
                            object[] quantity = new object[] { obj1, "<td style='border:1px solid gray'>", creditNoteDetailDAO.Quantity, "</td>" };
                            str = string.Concat(quantity);
                            object obj2 = str;
                            object[] gUnitPrice = new object[] { obj2, "<td style='border:1px solid gray'>", creditNoteDetailDAO.GUnitPrice, "</td>" };
                            str = string.Concat(gUnitPrice);
                            object obj3 = str;
                            object[] gTotalPrice1 = new object[] { obj3, "<td style='border:1px solid gray'>", creditNoteDetailDAO.GTotalPrice, "</td>" };
                            str = string.Concat(gTotalPrice1);
                            str = string.Concat(str, "</tr>");
                            this.CreditNoteReport.Text = str;
                            this.ReturnComment.Text = creditNoteDetailDAO.ReasonOfReturn;
                            gTotalPrice += creditNoteDetailDAO.GTotalPrice;
                            previousAmount += creditNoteDetailDAO.PreviousAmount;
                            totalPricewithVat += creditNoteDetailDAO.TotalPricewithVat;
                            vat += creditNoteDetailDAO.Vat;
                            sd += creditNoteDetailDAO.Sd;
                            totalTax += creditNoteDetailDAO.TotalTax;
                        }
                        this.lblTotalPrice.Text = gTotalPrice.ToString();
                        this.lblCutPrice.Text = previousAmount.ToString();
                        this.lblTotalPriceWithVat.Text = totalPricewithVat.ToString();
                        this.lblVatPrice.Text = vat.ToString();
                        this.lblSDPrice.Text = sd.ToString();
                        this.lblTotalTax.Text = totalTax.ToString();
                    }
                    this.cnPrint.Visible = true;
                    this.btnPrint.Text = "Hide Report";
                    this.btnPrintReport.Visible = true;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/UI/Admin/CreditNote_6.7.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CraDebBLL craDebBLL = new CraDebBLL();
            CreditNoteMasterDAO creditNoteMasterDAO = new CreditNoteMasterDAO();
            ArrayList arrayLists = new ArrayList();
            try
            {
                if (this.chkDiscard.Checked)
                {
                    DBUtility dBUtility = new DBUtility();
                    try
                    {
                        ArrayList arrayLists1 = new ArrayList();
                        string str = this.drpDiscardReason.SelectedItem.ToString();
                        short num = Convert.ToInt16(this.drpDiscardReason.SelectedValue);
                        int num1 = Convert.ToInt32(this.hdBookId.Value);
                        Convert.ToInt32(this.hdPageNo.Value);
                        string text = this.txtCraditNot.Text;
                        char chr = 'C';
                        string text1 = this.txtCraditNot.Text;
                        object[] objArray = new object[] { "update trns_challan_no_detail set is_used = true, page_status = 2, remarks = '", str, "' where challan_no = '", text1, "' and challan_book_id = ", num1 };
                        arrayLists1.Add(string.Concat(objArray));
                        object[] objArray1 = new object[] { "update trns_note_master set discard = ", num, "  where note_type = '", chr, "' and note_no = '", text1, "'" };
                        arrayLists1.Add(string.Concat(objArray1));
                        if (!dBUtility.ExecuteBatchDML(arrayLists1))
                        {
                            this.msgBox.AddMessage("Data Update Failed.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Data Update Successfully.", MsgBoxs.enmMessageType.Success);
                        }
                    }
                    catch (Exception exception)
                    {
                        ReallySimpleLog.WriteLog(exception);
                    }
                }
                else if (this.validation())
                {
                    creditNoteMasterDAO = this.loadMasterData(creditNoteMasterDAO);
                    if (creditNoteMasterDAO != null)
                    {
                        if (!this.chkDiscard.Checked)
                        {
                            arrayLists = (ArrayList)this.Session["CREDIT_NOTE_DETAIL"];
                            if (arrayLists == null || arrayLists.Count == 0)
                            {
                                this.gvItem.DataSource = null;
                                this.gvItem.DataBind();
                                this.msgBox.AddMessage("Please insert Detail data properly.", MsgBoxs.enmMessageType.Attention);
                                return;
                            }
                        }
                        ArrayList arrayLists2 = new ArrayList();
                        if (this.gvAddtnProperty.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.gvAddtnProperty.Rows.Count; i++)
                            {
                                AdditionalProperty additionalProperty = new AdditionalProperty();
                                CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[i].FindControl("chkChallan");
                                HiddenField hiddenField = (HiddenField)this.gvAddtnProperty.Rows[i].FindControl("additionalInfoId");
                                additionalProperty.additionalInfoId = Convert.ToInt32(hiddenField.Value);
                                additionalProperty.status = this.ItemType.Value;
                                if (checkBox.Checked)
                                {
                                    arrayLists2.Add(additionalProperty);
                                }
                            }
                            if (arrayLists2.Count == 0)
                            {
                                this.msgBox.AddMessage("Please Select Property from Grid.", MsgBoxs.enmMessageType.Error);
                                return;
                            }
                        }
                        if (!craDebBLL.saveCreditNote(creditNoteMasterDAO, arrayLists, arrayLists2))
                        {
                            this.msgBox.AddMessage("Data Insert Failed.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Data Insert Successfully.", MsgBoxs.enmMessageType.Success);
                            this.clearMaster();
                            this.gvItem.DataSource = null;
                            this.gvItem.DataBind();
                            this.getCreditNoteNo();
                            this.loadReportData();
                            this.VATLastUpdatedBalance();
                            this.SDLastUpdatedBalance();
                            this.insertBalance();
                            this.pnlContents.Visible = true;
                            this.gvAddtnProperty.DataSource = null;
                            this.gvAddtnProperty.DataBind();
                        }
                    }
                    else
                    {
                        this.msgBox.AddMessage("Please insert master data properly.", MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                }
            }
            catch (Exception exception1)
            {
                 BLL.Utility.InsertErrorTrack(exception1.Message, "CreditNote_6.7", "btnSave_Click");
            }
        }

        private void CalculateAfterBadkorton()
        {
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            double num4 = 0;
            double num5 = 0;
            double num6 = 0;
            double num7 = 0;
            double num8 = (!string.IsNullOrEmpty(this.txtPreviousAmount.Text) ? Convert.ToDouble(this.txtPreviousAmount.Text) : 0);
            num1 = Convert.ToDouble(this.lblVat.Text.Trim());
            num = Convert.ToDouble(this.lblSD.Text.Trim());
            if (this.txtQuantity.Text != string.Empty)
            {
                num6 = Convert.ToDouble(this.txtQuantity.Text.Trim());
            }
            else
            {
                this.txtQuantity.Text = 1.ToString();
                num6 = 1;
            }
            if (num1 > 0)
            {
                num2 = Convert.ToDouble(this.txtAmount.Text.Trim()) - num8;
                num3 = num2 * num1 / (num1 + 100);
                num5 = num2 - num3;
                if (num > 0)
                {
                    num4 = num5 * num / (num + 100);
                }
                this.txtVAT.Text = num3.ToString("0.00");
                this.txtSD.Text = num4.ToString("0.00");
                if (num6 != 0)
                {
                    num7 = num2 * 100 * 100 / ((100 + num1) * (100 + num));
                    this.txtUnitPrice.Text = (num7 / num6).ToString("0.00");
                    double num9 = num7 / num6 + num3 + num4;
                    this.txtTotalUnitPrice.Text = num9.ToString("0.00");
                    double num10 = num6 * Convert.ToDouble(this.txtUnitPrice.Text) + num3 + num4;
                    this.txtAmount.Text = num10.ToString("0.00");
                    double num11 = num4 + num3;
                    this.txtTotalTax.Text = num11.ToString("0.00");
                    Convert.ToDouble(this.txtAmount.Text.Trim());
                    double num12 = Convert.ToDouble(this.txtAmount.Text.Trim()) - Convert.ToDouble(this.txtSD.Text.Trim());
                    this.txtTotalPricewithVat.Text = num12.ToString("0.00");
                    this.txtcredQuantity.Text = this.txtQuantity.Text;
                }
            }
        }

        private void calculatePrice()
        {
            double num;
            double num1 = Convert.ToDouble(this.lblVat.Text.ToString());
            double num2 = Convert.ToDouble(this.lblSD.Text.ToString());
            num = (this.txtQuantity.Text.ToString() == "" ? 0 : Convert.ToDouble(this.txtQuantity.Text.ToString()));
            double num3 = (this.txtUnitPrice.Text.ToString() != "" ? Convert.ToDouble(this.txtUnitPrice.Text.ToString()) : 0);
            this.txtTotalUnitPrice.Text = num3.ToString();
            double num4 = 1 * num3;
            double num5 = 0;
            double num6 = 0;
            double num7 = 0;
            double num8 = 0;
            if (num != 0)
            {
                num7 = num4 * num2 / 100 * num;
                num8 = (num7 + num4 * num) * num1 / 100;
            }
            else if (this.Label2.Text == " Per Unit")
            {
                num6 = num1 * 1;
            }
            else if (this.Label2.Text != " Per Unit")
            {
                num5 = num4 * num2 / 100 * 1;
                num6 = (num5 + num4) * num1 / 100 * 1;
            }
            else
            {
                num6 = num4 * num;
            }
            double num9 = 0;
            num9 = num4 + num6 + num5;
            if (num == 0)
            {
                this.HiddenFieldAkokMullo.Value = num9.ToString();
            }
            double num10 = 0;
            num10 = (num != 0 ? num8 + num7 : num6 + num5);
            if (num != 0)
            {
                this.txtVAT.Text = num8.ToString();
                this.txtSD.Text = num7.ToString();
            }
            else
            {
                this.txtVAT.Text = num6.ToString();
                this.txtSD.Text = num5.ToString();
            }
            this.txtTotalUnitPrice.Text = this.HiddenFieldAkokMullo.Value;
            if (num != 0)
            {
                TextBox str = this.txtAmount;
                double num11 = num * Convert.ToDouble(this.txtTotalUnitPrice.Text.Trim());
                str.Text = num11.ToString("0.00");
            }
            else
            {
                TextBox textBox = this.txtAmount;
                double num12 = 1 * Convert.ToDouble(this.txtTotalUnitPrice.Text.Trim());
                textBox.Text = num12.ToString("0.00");
            }
            this.txtTotalTax.Text = num10.ToString();
            if (this.txtPreviousAmount.Text.ToString() != "")
            {
                Convert.ToDouble(this.txtPreviousAmount.Text.ToString());
            }
            Convert.ToDouble(this.txtAmount.Text.Trim());
            double num13 = Convert.ToDouble(this.txtAmount.Text.Trim()) - Convert.ToDouble(this.txtSD.Text.Trim());
            this.txtTotalPricewithVat.Text = num13.ToString("0.00");
        }

        protected void chkAdditionalProperty_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Dictionary<int, int> item = (Dictionary<int, int>)this.Session["chkProperty"];
                for (int i = 0; i < this.gvAddtnProperty.Rows.Count; i++)
                {
                    CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[i].FindControl("chkChallan");
                    int num = Convert.ToInt32(((HiddenField)this.gvAddtnProperty.Rows[i].FindControl("additionalInfoId")).Value);
                    int num1 = Convert.ToInt32(this.gvAddtnProperty.DataKeys[0].Value.ToString());
                    if (!checkBox.Checked)
                    {
                        item.Remove(num);
                    }
                    else if (!item.ContainsKey(num))
                    {
                        item.Add(num, num1);
                    }
                }
                this.Session["chkProperty"] = item;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void chkDiscard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDiscard.Checked)
            {
                this.FillDiscardData();
                this.lblDiscardReason.Visible = true;
                this.drpDiscardReason.Visible = true;
                this.btnAddRow.Enabled = false;
                return;
            }
            base.Response.Redirect("~/UI/Admin/CreditNote_6.7.aspx");
            this.lblDiscardReason.Visible = false;
            this.drpDiscardReason.Visible = false;
            this.drpMainChallanNo.Enabled = true;
            this.drpCategory.Enabled = true;
            this.drpSubCategory.Enabled = true;
            this.drpItem.Enabled = true;
            this.btnAddRow.Enabled = true;
        }

        private void clearMaster()
        {
            this.drpItem.SelectedValue = "-99";
            this.drpMainChallanNo.SelectedValue = "-99";
            this.ltAddress.Text = "";
            this.lblBIN.Text = "";
            this.drpVehicleType.SelectedValue = "-99";
            this.txtVehicleNo.Text = "";
        }

        private void detailClear()
        {
            this.lblUnitPrice.Text = "";
            this.Label2.Text = "%";
            this.lblfxdVT.Text = "";
            this.drpItem.SelectedValue = "-99";
            this.lblHSCode.Text = "";
            this.txtQuantity.Text = "";
            this.txtUnitName.Text = "";
            this.txtUnitPrice.Text = "";
            this.txtVAT.Text = "";
            this.txtSD.Text = "";
            this.txtTotalUnitPrice.Text = "";
            this.txtAmount.Text = "";
            this.txtPreviousAmount.Text = "";
            this.txtTotalPricewithVat.Text = "";
            this.txtTotalTax.Text = "";
            this.txtReasonofReturn.Text = "";
            this.lblVat.Text = "";
            this.lblSD.Text = "";
            this.lblQuantity.Text = "";
            UtilityK.fillItemCategoryDropDownList(this.drpCategory);
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpCategory.Items.Insert(0, listItem);
            this.drpSubCategory.Items.Clear();
            ListItem listItem1 = new ListItem("-- Select --", "-99");
            this.drpSubCategory.Items.Insert(0, listItem1);
            this.lblProperty1.Visible = false;
            this.lblProperty2.Visible = false;
            this.lblProperty3.Visible = false;
            this.lblProperty4.Visible = false;
            this.lblProperty5.Visible = false;
            this.drpProperty1.Visible = false;
            this.drpProperty2.Visible = false;
            this.drpProperty3.Visible = false;
            this.drpProperty4.Visible = false;
            this.drpProperty5.Visible = false;
            this.drpProperty1.Items.Clear();
            this.drpProperty2.Items.Clear();
            this.drpProperty3.Items.Clear();
            this.drpProperty4.Items.Clear();
            this.drpProperty5.Items.Clear();
        }

        private void displayTotalRecordsFound()
        {
            if (this.gvAddtnProperty.Rows.Count <= 0)
            {
                this.lblTotalRow.Text = "";
            }
            else if (this.gvAddtnProperty.Rows[0].Cells[0].Text != "No Item(s) Found")
            {
                int count = this.gvAddtnProperty.Rows.Count;
                this.lblTotalRow.Text = string.Concat("Total ", count, " record(s) found.");
                return;
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

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.gvAddtnProperty.DataSource = null;
                this.gvAddtnProperty.DataBind();
                this.divSearch.Visible = false;
                this.lblTotalRow.Text = "";
                this.Session["unit_price"] = "";
                this.Label2.Text = "%";
                string str = "";
                string str1 = "";
                string str2 = "";
                short num = 0;
                string str3 = "";
                this.lblHSCode.Text = "";
                this.txtQuantity.Text = "";
                this.txtUnitName.Text = "";
                this.txtUnitPrice.Text = "";
                this.txtVAT.Text = "";
                this.txtSD.Text = "";
                this.lblSD.Text = "";
                this.lblVat.Text = "";
                this.txtTotalUnitPrice.Text = "";
                this.txtPreviousAmount.Text = "";
                this.txtTotalPricewithVat.Text = "";
                this.txtTotalTax.Text = "";
                this.lblQuantity.Text = "";
                this.txtAmount.Text = "";
                this.txtReasonofReturn.Text = "";
                this.drpCategory.Items.Clear();
                this.drpSubCategory.Items.Clear();
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                this.drpSubCategory.Items.Insert(0, listItem);
                decimal num1 = new decimal(1);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                if (!this.chkDiscard.Checked)
                {
                    AddItemBLL addItemBLL = new AddItemBLL();
                    CraDebBLL craDebBLL = new CraDebBLL();
                    if (this.drpItem.SelectedValue != "-99")
                    {
                        str1 = this.drpItem.SelectedItem.ToString();
                        string[] strArrays = str1.Split(new char[] { '-' });
                        if (strArrays != null && strArrays.Count<string>() > 0)
                        {
                            str = strArrays[strArrays.Count<string>() - 3];
                            this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 1];
                        }
                        if (str == "Local")
                        {
                            str2 = "L";
                        }
                        if (str == "Import")
                        {
                            str2 = "I";
                        }
                        if (str == "Production")
                        {
                            str2 = "F";
                        }
                        if (str == "Service")
                        {
                            str2 = "S";
                        }
                        str3 = Convert.ToString(this.drpItem.SelectedValue);
                        string[] strArrays1 = str3.Split(new char[] { '.' });
                        num = Convert.ToInt16(strArrays1[0]);
                        this.ItemType.Value = str2;
                        int num4 = Convert.ToInt16(this.drpMainChallanNo.SelectedValue);
                        DataTable dataTable = this.objPDBll.geAdditionalPropertybySaleChallanID(num, num4);
                        if (dataTable.Rows.Count <= 0)
                        {
                            this.divProp.Visible = true;
                        }
                        else
                        {
                            this.divProp.Visible = false;
                            short num5 = 0;
                            short num6 = 0;
                            short num7 = 0;
                            short num8 = 0;
                            short num9 = 0;
                            string str4 = "";
                            string str5 = "";
                            string str6 = "";
                            string str7 = "";
                            string str8 = "";
                            DataTable appCodeDetailName = null;
                            num5 = Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
                            num6 = Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
                            num7 = Convert.ToInt16(dataTable.Rows[0]["property_id3"]);
                            num8 = Convert.ToInt16(dataTable.Rows[0]["property_id4"]);
                            num9 = Convert.ToInt16(dataTable.Rows[0]["property_id5"]);
                            ArrayList arrayLists = new ArrayList();
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num5);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField = new BoundField();
                                str4 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str4);
                                boundField.HeaderText = str4;
                                boundField.DataField = "Property1_Text";
                                this.gvAddtnProperty.Columns.Add(boundField);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num6);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField1 = new BoundField();
                                str5 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str5);
                                boundField1.HeaderText = str5;
                                boundField1.DataField = "Property2_Text";
                                this.gvAddtnProperty.Columns.Add(boundField1);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num7);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField2 = new BoundField();
                                str6 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str6);
                                boundField2.HeaderText = str6;
                                boundField2.DataField = "Property3_Text";
                                this.gvAddtnProperty.Columns.Add(boundField2);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num8);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField3 = new BoundField();
                                str7 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str7);
                                boundField3.HeaderText = str7;
                                boundField3.DataField = "Property4_Text";
                                this.gvAddtnProperty.Columns.Add(boundField3);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num9);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField4 = new BoundField();
                                str8 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str8);
                                boundField4.HeaderText = str8;
                                boundField4.DataField = "Property5_Text";
                                this.gvAddtnProperty.Columns.Add(boundField4);
                            }
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO()
                                {
                                    additionalInfoId = Convert.ToInt32(dataTable.Rows[i]["additional_info_id"]),
                                    Item_id = Convert.ToInt32(dataTable.Rows[i]["item_id"])
                                };
                                if (dataTable.Rows[i]["property_id1_value"].ToString() != "")
                                {
                                    contructualProductionIssueDAO.Property1_Text = dataTable.Rows[i]["property_id1_value"].ToString();
                                }
                                if (dataTable.Rows[i]["property_id2_value"].ToString() != "")
                                {
                                    contructualProductionIssueDAO.Property2_Text = dataTable.Rows[i]["property_id2_value"].ToString();
                                }
                                if (dataTable.Rows[i]["property_id3_value"].ToString() != "")
                                {
                                    contructualProductionIssueDAO.Property3_Text = dataTable.Rows[i]["property_id3_value"].ToString();
                                }
                                if (dataTable.Rows[i]["property_id4_value"].ToString() != "")
                                {
                                    contructualProductionIssueDAO.Property4_Text = dataTable.Rows[i]["property_id4_value"].ToString();
                                }
                                if (dataTable.Rows[i]["property_id5_value"].ToString() != "")
                                {
                                    contructualProductionIssueDAO.Property5_Text = dataTable.Rows[i]["property_id5_value"].ToString();
                                }
                                arrayLists.Add(contructualProductionIssueDAO);
                            }
                            if (arrayLists.Count <= 0)
                            {
                                this.divSearch.Visible = false;
                            }
                            else
                            {
                                this.divSearch.Visible = true;
                            }
                            this.gvAddtnProperty.DataSource = arrayLists;
                            this.gvAddtnProperty.DataBind();
                            this.displayTotalRecordsFound();
                        }
                        this.GetItemDetails();
                    }
                }
                else
                {
                    this.fillDiscardItem();
                }
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.txtVAT.Text = (num2 / num1).ToString();
                    this.txtSD.Text = (num3 / num1).ToString();
                    this.txtTotalUnitPrice.Text = this.txtUnitPrice.Text;
                    this.txtTotalPricewithVat.Text = this.txtUnitPrice.Text;
                    this.txtAmount.Text = this.txtUnitPrice.Text;
                    TextBox textBox = this.txtTotalTax;
                    decimal num10 = (num2 + num3) / num1;
                    textBox.Text = num10.ToString();
                }
                else
                {
                    this.calculatePrice();
                }
                this.EnableOrDisablePropertyForItem();
                this.Session["unit_price"] = this.txtUnitPrice.Text;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpMainChallanNo_selectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.gvAddtnProperty.DataSource = null;
                this.gvAddtnProperty.DataBind();
                this.divSearch.Visible = false;
                this.lblTotalRow.Text = "";
                CraDebBLL craDebBLL = new CraDebBLL();
                if (this.drpMainChallanNo.SelectedValue == "-99")
                {
                    this.drpItem.Items.Clear();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem);
                    this.lblHSCode.Text = "";
                    this.txtQuantity.Text = "";
                    this.txtUnitName.Text = "";
                    this.txtUnitPrice.Text = "";
                    this.txtVAT.Text = "";
                    this.txtSD.Text = "";
                    this.lblSD.Text = "";
                    this.lblVat.Text = "";
                    this.txtTotalUnitPrice.Text = "";
                    this.txtPreviousAmount.Text = "";
                    this.txtTotalPricewithVat.Text = "";
                    this.txtTotalTax.Text = "";
                    this.lblQuantity.Text = "";
                    this.txtAmount.Text = "";
                    this.txtReasonofReturn.Text = "";
                    this.drpCategory.Items.Clear();
                    this.drpSubCategory.Items.Clear();
                    ListItem listItem1 = new ListItem("-- Select --", "-99");
                    this.drpCategory.Items.Insert(0, listItem1);
                    this.drpSubCategory.Items.Insert(0, listItem1);
                    this.drpCategory.SelectedValue = "-99";
                    this.drpSubCategory.SelectedValue = "-99";
                }
                else
                {
                    int num = Convert.ToInt16(this.drpMainChallanNo.SelectedValue);
                    DataTable item = (DataTable)this.Session["CHALLAN_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("Challan_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        string str = dataRow["date_challan"].ToString();
                        DateTime dateTime = DateTime.Parse(str);
                        DateTime dateTime1 = DateTime.Parse(DateTime.Now.ToShortDateString());
                        int days = dateTime1.Subtract(dateTime).Days;
                        string str1 = dataRow["date_challan"].ToString();
                        string[] strArrays = str1.Split(new char[] { ' ' });
                        DateTime dateTime2 = Convert.ToDateTime(dataRow["date_challan"]);
                        string str2 = dateTime2.ToString("dd/MM/yyyy");
                        char[] chrArray = new char[] { ' ' };
                        string[] strArrays1 = str2.Split(chrArray)[0].Split(new char[] { '/' });
                        string str3 = (strArrays1[0].Length > 1 ? strArrays1[0].ToString() : string.Concat("0", strArrays1[0].ToString()));
                        string str4 = (strArrays1[1].Length > 1 ? strArrays1[1].ToString() : string.Concat("0", strArrays1[1].ToString()));
                        string str5 = strArrays1[2].ToString();
                        TextBox textBox = this.txtProviderDate;
                        string[] strArrays2 = new string[] { str3, "/", str4, "/", str5 };
                        textBox.Text = string.Concat(strArrays2);
                        if (strArrays[1].ToString() != null)
                        {
                            string str6 = strArrays[1].ToString();
                            string[] strArrays3 = str6.Split(new char[] { ':' });
                            this.drpProviderHr.SelectedValue = (strArrays3[strArrays3.Count<string>() - 3].Length > 1 ? strArrays3[strArrays3.Count<string>() - 3].ToString() : string.Concat("0", strArrays3[strArrays3.Count<string>() - 3].ToString()));
                            this.drpProviderMin.SelectedValue = (strArrays3[strArrays3.Count<string>() - 2].Length > 0 ? strArrays3[strArrays3.Count<string>() - 2].ToString() : string.Concat("0", strArrays3[strArrays3.Count<string>() - 2].ToString()));
                        }
                    }
                    DataTable creditItembyChallanId = craDebBLL.getCreditItembyChallanId(num);
                    this.drpItem.DataSource = creditItembyChallanId;
                    this.drpItem.DataTextField = creditItembyChallanId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = creditItembyChallanId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem2 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                    this.lblHSCode.Text = "";
                    this.txtQuantity.Text = "";
                    this.txtUnitName.Text = "";
                    this.txtUnitPrice.Text = "";
                    this.txtVAT.Text = "";
                    this.txtSD.Text = "";
                    this.lblSD.Text = "";
                    this.lblVat.Text = "";
                    this.txtTotalUnitPrice.Text = "";
                    this.txtPreviousAmount.Text = "";
                    this.txtTotalPricewithVat.Text = "";
                    this.txtTotalTax.Text = "";
                    this.lblQuantity.Text = "";
                    this.txtAmount.Text = "";
                    this.txtReasonofReturn.Text = "";
                    this.drpCategory.Items.Clear();
                    this.drpSubCategory.Items.Clear();
                    ListItem listItem3 = new ListItem("-- Select --", "-99");
                    this.drpCategory.Items.Insert(0, listItem3);
                    this.drpSubCategory.Items.Insert(0, listItem3);
                    this.drpCategory.SelectedValue = "-99";
                    this.drpSubCategory.SelectedValue = "-99";
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            CraDebBLL craDebBLL = new CraDebBLL();
            try
            {
                this.lblBranchAddress.Text = "";
                this.lblBranchBin.Text = "";
                if (this.drpParty.SelectedValue == "-99")
                {
                    this.drpMainChallanNo.Items.Clear();
                    this.drpItem.Items.Clear();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem);
                    this.lblHSCode.Text = "";
                    this.txtQuantity.Text = "";
                    this.txtUnitName.Text = "";
                    this.txtUnitPrice.Text = "";
                    this.txtVAT.Text = "";
                    this.txtSD.Text = "";
                    this.lblSD.Text = "";
                    this.lblVat.Text = "";
                    this.txtTotalUnitPrice.Text = "";
                    this.txtPreviousAmount.Text = "";
                    this.txtTotalPricewithVat.Text = "";
                    this.txtTotalTax.Text = "";
                    this.lblQuantity.Text = "";
                    this.txtAmount.Text = "";
                    this.txtReasonofReturn.Text = "";
                    this.drpCategory.Items.Clear();
                    this.drpSubCategory.Items.Clear();
                    this.drpCategory.Items.Insert(0, listItem);
                    this.drpSubCategory.Items.Insert(0, listItem);
                    this.drpCategory.SelectedValue = "-99";
                    this.drpSubCategory.SelectedValue = "-99";
                }
                else
                {
                    int num = Convert.ToInt32(this.drpParty.SelectedValue);
                    DataTable item = (DataTable)this.Session["PARTY_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("party_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.ltAddress.Text = dataRow["party_address"].ToString();
                        this.lblBIN.Text = dataRow["party_bin"].ToString();
                    }
                    DataTable mainChallan = craDebBLL.getMainChallan(num);
                    this.drpMainChallanNo.DataSource = mainChallan;
                    this.drpMainChallanNo.DataTextField = mainChallan.Columns["challan_no"].ToString();
                    this.drpMainChallanNo.DataValueField = mainChallan.Columns["Challan_id"].ToString();
                    this.drpMainChallanNo.DataBind();
                    ListItem listItem1 = new ListItem("---Select---", "-99");
                    this.drpMainChallanNo.Items.Insert(0, listItem1);
                    this.Session["CHALLAN_INFO"] = mainChallan;
                    this.drpItem.Items.Clear();
                    ListItem listItem2 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                    this.lblHSCode.Text = "";
                    this.txtQuantity.Text = "";
                    this.txtUnitName.Text = "";
                    this.txtUnitPrice.Text = "";
                    this.txtVAT.Text = "";
                    this.txtSD.Text = "";
                    this.lblSD.Text = "";
                    this.lblVat.Text = "";
                    this.txtTotalUnitPrice.Text = "";
                    this.txtPreviousAmount.Text = "";
                    this.txtTotalPricewithVat.Text = "";
                    this.txtTotalTax.Text = "";
                    this.lblQuantity.Text = "";
                    this.txtAmount.Text = "";
                    this.txtReasonofReturn.Text = "";
                    this.drpCategory.Items.Clear();
                    this.drpSubCategory.Items.Clear();
                    this.drpCategory.Items.Insert(0, listItem1);
                    this.drpSubCategory.Items.Insert(0, listItem1);
                    this.drpCategory.SelectedValue = "-99";
                    this.drpSubCategory.SelectedValue = "-99";
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpProperty1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProperty2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProperty3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProperty4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProperty5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                if (this.drpSubCategory.SelectedValue != "-99")
                {
                    num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                }
                DataTable itemByCatSubCatId = addItemBLL.getItemByCatSubCatId(num);
                this.drpItem.DataSource = itemByCatSubCatId;
                this.drpItem.DataTextField = itemByCatSubCatId.Columns["item_name"].ToString();
                this.drpItem.DataValueField = itemByCatSubCatId.Columns["Item_id"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("---Select---", "-99");
                this.drpItem.Items.Insert(0, listItem);
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
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
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
                string str = "";
                if (this.drpItem.SelectedValue != "-99")
                {
                    str = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays = str.Split(new char[] { '.' });
                    num = Convert.ToInt16(strArrays[0]);
                    DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(num);
                    short num1 = 0;
                    short num2 = 0;
                    short num3 = 0;
                    short num4 = 0;
                    short num5 = 0;
                    DataTable appCodeDetailName = null;
                    num1 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id1"]);
                    num2 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id2"]);
                    num3 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id3"]);
                    num4 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id4"]);
                    num5 = Convert.ToInt16(itemRequiredProperty.Rows[0]["property_id5"]);
                    DataTable itemProperty = addItemBLL.getItemProperty(num1);
                    if (itemProperty == null)
                    {
                        this.drpProperty1.Visible = false;
                        this.lblProperty1.Visible = false;
                    }
                    else if (itemProperty.Rows.Count <= 0)
                    {
                        this.drpProperty1.Visible = false;
                        this.lblProperty1.Visible = false;
                    }
                    else
                    {
                        this.drpProperty1.DataSource = itemProperty;
                        this.drpProperty1.DataTextField = itemProperty.Columns["property_name"].ToString();
                        this.drpProperty1.DataValueField = itemProperty.Columns["property_id"].ToString();
                        this.drpProperty1.DataBind();
                        ListItem listItem = new ListItem("---Select---", "-99");
                        this.drpProperty1.Items.Insert(0, listItem);
                        this.drpProperty1.Visible = true;
                        this.lblProperty1.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num1);
                        this.lblProperty1.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable = addItemBLL.getItemProperty(num2);
                    if (dataTable == null)
                    {
                        this.drpProperty2.Visible = false;
                        this.lblProperty2.Visible = false;
                    }
                    else if (dataTable.Rows.Count <= 0)
                    {
                        this.drpProperty2.Visible = false;
                        this.lblProperty2.Visible = false;
                    }
                    else
                    {
                        this.drpProperty2.DataSource = dataTable;
                        this.drpProperty2.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProperty2.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProperty2.DataBind();
                        ListItem listItem1 = new ListItem("---Select---", "-99");
                        this.drpProperty2.Items.Insert(0, listItem1);
                        this.drpProperty2.Visible = true;
                        this.lblProperty2.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num2);
                        this.lblProperty2.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty1 = addItemBLL.getItemProperty(num3);
                    if (itemProperty1 == null)
                    {
                        this.drpProperty3.Visible = false;
                        this.lblProperty3.Visible = false;
                    }
                    else if (itemProperty1.Rows.Count <= 0)
                    {
                        this.drpProperty3.Visible = false;
                        this.lblProperty3.Visible = false;
                    }
                    else
                    {
                        this.drpProperty3.DataSource = itemProperty1;
                        this.drpProperty3.DataTextField = itemProperty1.Columns["property_name"].ToString();
                        this.drpProperty3.DataValueField = itemProperty1.Columns["property_id"].ToString();
                        this.drpProperty3.DataBind();
                        ListItem listItem2 = new ListItem("---Select---", "-99");
                        this.drpProperty3.Items.Insert(0, listItem2);
                        this.drpProperty3.Visible = true;
                        this.lblProperty3.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num3);
                        this.lblProperty3.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable dataTable1 = addItemBLL.getItemProperty(num4);
                    if (dataTable1 == null)
                    {
                        this.drpProperty4.Visible = false;
                        this.lblProperty4.Visible = false;
                    }
                    else if (dataTable1.Rows.Count <= 0)
                    {
                        this.drpProperty4.Visible = false;
                        this.lblProperty4.Visible = false;
                    }
                    else
                    {
                        this.drpProperty4.DataSource = dataTable1;
                        this.drpProperty4.DataTextField = dataTable1.Columns["property_name"].ToString();
                        this.drpProperty4.DataValueField = dataTable1.Columns["property_id"].ToString();
                        this.drpProperty4.DataBind();
                        ListItem listItem3 = new ListItem("---Select---", "-99");
                        this.drpProperty4.Items.Insert(0, listItem3);
                        this.drpProperty4.Visible = true;
                        this.lblProperty4.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num4);
                        this.lblProperty4.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                    }
                    DataTable itemProperty2 = addItemBLL.getItemProperty(num5);
                    if (itemProperty2 != null)
                    {
                        if (itemProperty2.Rows.Count <= 0)
                        {
                            this.drpProperty5.Visible = false;
                            this.lblProperty5.Visible = false;
                            return;
                        }
                        this.drpProperty5.DataSource = itemProperty2;
                        this.drpProperty5.DataTextField = itemProperty2.Columns["property_name"].ToString();
                        this.drpProperty5.DataValueField = itemProperty2.Columns["property_id"].ToString();
                        this.drpProperty5.DataBind();
                        ListItem listItem4 = new ListItem("---Select---", "-99");
                        this.drpProperty5.Items.Insert(0, listItem4);
                        this.drpProperty5.Visible = true;
                        this.lblProperty5.Visible = true;
                        appCodeDetailName = addItemBLL.GetAppCodeDetailName(num5);
                        this.lblProperty5.Text = appCodeDetailName.Rows[0]["code_name"].ToString();
                        return;
                    }
                    this.drpProperty5.Visible = false;
                    this.lblProperty5.Visible = false;
                }
            }
        }

        private void fillCatSubCat(int itemID)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            if (this.drpItem.SelectedValue == "-99")
            {
                this.drpCategory.SelectedValue = "-99";
                this.drpSubCategory.SelectedValue = "-99";
                return;
            }
            DataTable allFieldByItemId = addItemBLL.getAllFieldByItemId(itemID);
            this.lblUnitId.Text = allFieldByItemId.Rows[0]["unit_id"].ToString();
            this.hdItemType.Text = allFieldByItemId.Rows[0]["item_type"].ToString();
            this.drpCategory.DataSource = allFieldByItemId;
            this.drpCategory.DataTextField = allFieldByItemId.Columns["category_name"].ToString();
            this.drpCategory.DataValueField = allFieldByItemId.Columns["category_id"].ToString();
            this.drpCategory.DataBind();
            this.drpSubCategory.DataSource = allFieldByItemId;
            this.drpSubCategory.DataTextField = allFieldByItemId.Columns["sub_category_name"].ToString();
            this.drpSubCategory.DataValueField = allFieldByItemId.Columns["sub_category_id"].ToString();
            this.drpSubCategory.DataBind();
        }

        private void FillDecreaseType()
        {
            try
            {
                CraDebBLL craDebBLL = new CraDebBLL();
                DataTable dataTable = craDebBLL.loadDecreaseType();
                if (craDebBLL != null)
                {
                    this.drpDecreaseType.DataSource = dataTable;
                    this.drpDecreaseType.DataTextField = dataTable.Columns["code_name"].ToString();
                    this.drpDecreaseType.DataValueField = dataTable.Columns["code_id_d"].ToString();
                    this.drpDecreaseType.DataBind();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void FillDiscardData()
        {
            DBUtility dBUtility = new DBUtility();
            try
            {
                string str = "";
                string str1 = "";
                string str2 = "";
                int num = 0;
                int num1 = Convert.ToInt32(this.drpParty.SelectedValue);
                if (this.drpParty.SelectedValue != "-99")
                {
                    str = string.Concat(" AND party_id = ", num1);
                    str1 = string.Concat(" And tnm.party_id = ", num1, " ");
                }
                string str3 = string.Concat("select note_id,note_no from trns_note_master where note_type = 'C' ", str, " order by  note_no desc limit 1");
                DataTable dataTable = dBUtility.GetDataTable(str3);
                str2 = dataTable.Rows[0]["note_no"].ToString();
                this.txtCraditNot.Text = str2;
                num = Convert.ToInt32(dataTable.Rows[0]["note_id"].ToString());
                this.creditNoteId.Text = num.ToString();
                string str4 = string.Concat("select tsm.challan_no, tsm.challan_id from trns_sale_master tsm inner join trns_note_detail tnd on tsm.challan_id = tnd.challan_id\r\n                            inner join trns_note_master tnm on tnm.note_id = tnd.note_id where tnm.note_type = 'C' AND tnm.note_no = '", str2, "' ", str1);
                DataTable dataTable1 = dBUtility.GetDataTable(str4);
                if (dataTable1 != null)
                {
                    this.drpMainChallanNo.DataSource = dataTable1;
                    this.drpMainChallanNo.DataTextField = dataTable1.Columns["challan_no"].ToString();
                    this.drpMainChallanNo.DataValueField = dataTable1.Columns["challan_id"].ToString();
                    this.drpMainChallanNo.DataBind();
                }
                ListItem listItem = new ListItem("---Select---", "-99");
                this.drpMainChallanNo.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void fillDiscardItem()
        {
            try
            {
                DBUtility dBUtility = new DBUtility();
                int num = Convert.ToInt32(this.drpItem.SelectedValue);
                int num1 = Convert.ToInt32(this.creditNoteId.Text);
                object[] objArray = new object[] { "select quantity,actual_price,return_vat,return_sd,unit_price,total_price,other_deduct, vs_total_price, total_vat,return_reason \r\n                                from trns_note_detail where item_id = ", num, " and note_id = ", num1 };
                DataTable dataTable = dBUtility.GetDataTable(string.Concat(objArray));
                this.txtQuantity.Text = dataTable.Rows[0]["quantity"].ToString();
                this.txtUnitPrice.Text = dataTable.Rows[0]["actual_price"].ToString();
                this.txtVAT.Text = dataTable.Rows[0]["return_vat"].ToString();
                this.txtSD.Text = dataTable.Rows[0]["return_sd"].ToString();
                this.txtTotalUnitPrice.Text = dataTable.Rows[0]["unit_price"].ToString();
                this.txtAmount.Text = dataTable.Rows[0]["total_price"].ToString();
                this.txtPreviousAmount.Text = dataTable.Rows[0]["other_deduct"].ToString();
                this.txtTotalPricewithVat.Text = dataTable.Rows[0]["vs_total_price"].ToString();
                this.txtTotalTax.Text = dataTable.Rows[0]["total_vat"].ToString();
                this.txtReasonofReturn.Text = dataTable.Rows[0]["return_reason"].ToString();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getAvailStock(int itemID, string itemType)
        {
            SaleBLL saleBLL = new SaleBLL();
            try
            {
                DateTime standardDateFromDdMMyyyy =  BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtRecipientDate.Text.Trim());
                DataTable saleAvailableStock = saleBLL.GetSaleAvailableStock(itemID, itemType, standardDateFromDdMMyyyy);
                if (saleAvailableStock != null && saleAvailableStock.Rows.Count > 0)
                {
                    this.txtUnitName.Text = saleAvailableStock.Rows[0]["unit_code"].ToString();
                    this.lblUnitId.Text = saleAvailableStock.Rows[0]["unit_id"].ToString();
                    this.GetUnitName(Convert.ToInt16(this.lblUnitId.Text));
                    this.hdItemType.Text = saleAvailableStock.Rows[0]["item_type"].ToString();
                    if (saleAvailableStock.Rows[0]["parent_id"] == null || Convert.ToInt16(saleAvailableStock.Rows[0]["parent_id"]) <= 0)
                    {
                        this.drpCategory.SelectedValue = saleAvailableStock.Rows[0]["sub_category_id"].ToString();
                        this.drpSubCategory.Items.Clear();
                        ListItem listItem = new ListItem("-- Select --", "-99");
                        this.drpSubCategory.Items.Insert(0, listItem);
                        this.drpSubCategory.Enabled = false;
                    }
                    else
                    {
                        this.drpCategory.SelectedValue = saleAvailableStock.Rows[0]["parent_id"].ToString();
                        this.LoadSubCategory();
                        this.drpSubCategory.SelectedValue = saleAvailableStock.Rows[0]["sub_category_id"].ToString();
                    }
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

        private void getBranchChallan()
        {
            CraDebBLL craDebBLL = new CraDebBLL();
            int num = Convert.ToInt32(this.drpBranchName.SelectedValue);
            try
            {
                DataTable mainChallanByBranch = craDebBLL.getMainChallanByBranch(num);
                this.drpMainChallanNo.DataSource = mainChallanByBranch;
                this.drpMainChallanNo.DataTextField = mainChallanByBranch.Columns["challan_no"].ToString();
                this.drpMainChallanNo.DataValueField = mainChallanByBranch.Columns["Challan_id"].ToString();
                this.drpMainChallanNo.DataBind();
                ListItem listItem = new ListItem("---Select---", "-99");
                this.drpMainChallanNo.Items.Insert(0, listItem);
                this.Session["CHALLAN_INFO"] = mainChallanByBranch;
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
                Convert.ToInt32(this.Session["empId"].ToString());
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
                        this.drpBranchName.Items.Insert(1, listItem);
                    }
                    this.GetBranchAddress();
                }
                if (num == 2 || num == 1)
                {
                    this.drpBranchName.Enabled = true;
                    DataTable selectedBusinessUnitBranchInfo = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                    if (selectedBusinessUnitBranchInfo != null && selectedBusinessUnitBranchInfo.Rows.Count > 0)
                    {
                        this.drpBranchName.DataSource = selectedBusinessUnitBranchInfo;
                        this.drpBranchName.DataTextField = selectedBusinessUnitBranchInfo.Columns["branch_unit_name"].ToString();
                        this.drpBranchName.DataValueField = selectedBusinessUnitBranchInfo.Columns["org_branch_reg_id"].ToString();
                        this.drpBranchName.DataBind();
                    }
                }
            }
        }

        private void getCreditNoteNo()
        {
            CraDebBLL craDebBLL = new CraDebBLL();
            int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            short num1 = Convert.ToInt16(this.drpBranchName.SelectedValue);
            DataTable creditNoteNo = craDebBLL.GetCreditNoteNo(3, num, num1);
            if (creditNoteNo == null || creditNoteNo.Rows.Count <= 0)
            {
                this.txtCraditNot.Text = "";
                this.hdBookId.Value = "";
                this.hdPageNo.Value = "";
                return;
            }
            this.txtCraditNot.Text = creditNoteNo.Rows[0]["challan_no"].ToString();
            this.hdBookId.Value = creditNoteNo.Rows[0]["challan_book_id"].ToString();
            this.hdPageNo.Value = creditNoteNo.Rows[0]["page_no"].ToString();
        }

        private void GetItemDetails()
        {
            int num = 0;
            string str = "";
            string str1 = "";
            string str2 = "";
            CraDebBLL craDebBLL = new CraDebBLL();
            if (this.drpMainChallanNo.SelectedValue == "-99")
            {
                this.getAvailStock(num, str2);
                DataTable allVatByItemId = craDebBLL.getAllVatByItemId(num);
                if (allVatByItemId != null && allVatByItemId.Rows.Count > 0)
                {
                    this.lblVat.Text = allVatByItemId.Rows[0]["VAT"].ToString();
                    this.lblSD.Text = allVatByItemId.Rows[0]["SD"].ToString();
                }
            }
            else
            {
                str1 = this.drpItem.SelectedItem.ToString();
                str1.Split(new char[] { '-' });
                if (str1.Contains("Local"))
                {
                    str2 = "L";
                }
                if (str1.Contains("Import"))
                {
                    str2 = "I";
                }
                if (str1.Contains("Production"))
                {
                    str2 = "F";
                }
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                num = Convert.ToInt16(strArrays[0]);
                string str3 = this.drpMainChallanNo.SelectedItem.ToString();
                int num1 = Convert.ToInt32(this.drpMainChallanNo.SelectedValue);
                DataTable unitByItemId = craDebBLL.getUnitByItemId(num, str3);
                this.txtUnitName.Text = unitByItemId.Rows[0]["unit_code"].ToString();
                this.lblUnitId.Text = unitByItemId.Rows[0]["unit_id"].ToString();
                this.lblProp1.Text = unitByItemId.Rows[0]["property_id1"].ToString();
                this.lblProp2.Text = unitByItemId.Rows[0]["property_id2"].ToString();
                this.lblProp3.Text = unitByItemId.Rows[0]["property_id3"].ToString();
                this.lblProp4.Text = unitByItemId.Rows[0]["property_id4"].ToString();
                this.lblProp5.Text = unitByItemId.Rows[0]["property_id5"].ToString();
                this.typeP.Text = str2;
                this.txtUnitPrice.Text = unitByItemId.Rows[0]["actual_price"].ToString();
                this.lblUnitPrice.Text = unitByItemId.Rows[0]["actual_price"].ToString();
                this.hdTotalVat.Text = unitByItemId.Rows[0]["vat"].ToString();
                this.hdTotalSD.Text = unitByItemId.Rows[0]["sd"].ToString();
                Convert.ToDecimal(unitByItemId.Rows[0]["vat"]);
                Convert.ToDecimal(unitByItemId.Rows[0]["sd"]);
                Convert.ToDecimal(unitByItemId.Rows[0]["quantity"]);
                if (unitByItemId.Rows[0]["item_type"].ToString() != "S")
                {
                    this.drpType.SelectedValue = "Goods";
                }
                else
                {
                    this.drpType.SelectedValue = "Service";
                    this.txtUnitPrice.Enabled = true;
                }
                this.getAvailStock(num, str2);
                this.fillCatSubCat(num);
                string empty = string.Empty;
                DataTable itemType = this.dbBLLLL.getItemType(num);
                if (itemType.Rows.Count > 0)
                {
                    empty = itemType.Rows[0]["product_type"].ToString();
                }
                if (empty == "C")
                {
                    str2 = "F";
                }
                Label label = this.lblQuantity;
                long quantity = craDebBLL.getQuantity(num1, num, str2);
                label.Text = quantity.ToString();
                DataTable vatTaxForCredit = craDebBLL.GetVatTaxForCredit(num);
                string empty1 = string.Empty;
                if (vatTaxForCredit == null)
                {
                    this.lblVat.Text = "0.00";
                    this.lblSD.Text = "0.00";
                    return;
                }
                if (vatTaxForCredit.Rows.Count <= 0)
                {
                    this.lblVat.Text = "0.00";
                    this.lblSD.Text = "0.00";
                    return;
                }
                this.lblfxdVT.Text = "Tk. ";
                this.lblVat.Text = vatTaxForCredit.Rows[0]["VAT"].ToString();
                this.lblSD.Text = vatTaxForCredit.Rows[0]["SD"].ToString();
                if (vatTaxForCredit.Rows[0]["PER"].ToString() == "1")
                {
                    this.Label2.Text = " Per Unit";
                    return;
                }
            }
        }

        private DataTable getNewDataTableWithBalance(DataTable dtCurrentAccount)
        {
            decimal num = new decimal(0);
            for (int i = 0; i < dtCurrentAccount.Rows.Count; i++)
            {
                decimal num1 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["treasury_deposit"]);
                decimal num2 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["exempt_amount"]);
                decimal num3 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["others"]);
                decimal num4 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["pay_amount"]);
                decimal num5 = (num1 + num2) - num4;
                short num6 = Convert.ToInt16(dtCurrentAccount.Rows[i]["balance_action"]);
                if (i != 0)
                {
                    if (num6 != 1)
                    {
                        num = (num + num3) + num5;
                    }
                    else
                    {
                        num += num5;
                        if (num3 > new decimal(0))
                        {
                            num -= num3;
                        }
                    }
                    dtCurrentAccount.Rows[i]["balance_amount"] = num.ToString("0.00");
                }
                else
                {
                    num = Convert.ToDecimal(dtCurrentAccount.Rows[0]["balance_amount"]);
                }
            }
            return dtCurrentAccount;
        }

        private void getProductInfo()
        {
            string str = "";
            string str1 = MQMM.ParseText(this.productName.Text.Trim());
            SaleBLL saleBLL = new SaleBLL();
            string[] strArrays = str1.Split(new char[] { '-' });
            if (strArrays != null && strArrays.Count<string>() > 0)
            {
                string str2 = strArrays[strArrays.Count<string>() - 3];
                str = strArrays[strArrays.Count<string>() - 4];
                this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 1];
            }
            DataTable productInfo = saleBLL.getProductInfo(str);
            if (productInfo.Rows == null)
            {
                this.drpItem.SelectedValue = "-99";
                return;
            }
            this.drpItem.SelectedValue = productInfo.Rows[0]["item_id"].ToString();
        }

        private void GetPropertyWiseAvailStock()
        {
            try
            {
                CraDebBLL craDebBLL = new CraDebBLL();
                short num = 0;
                short num1 = 0;
                short num2 = 0;
                short num3 = 0;
                short num4 = 0;
                string empty = string.Empty;
                SaleBLL saleBLL = new SaleBLL();
                string str = "";
                string str1 = "";
                DateTime today = DateTime.Today;
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                short num5 = 0;
                string str2 = "";
                int num6 = 0;
                num6 = Convert.ToInt32(this.drpMainChallanNo.SelectedValue);
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
                    num2 = Convert.ToInt16(this.drpProperty3.SelectedValue);
                }
                if (this.drpProperty4.SelectedValue != "-99" && this.drpProperty4.SelectedValue != "")
                {
                    num3 = Convert.ToInt16(this.drpProperty4.SelectedValue);
                }
                if (this.drpProperty5.SelectedValue != "-99" && this.drpProperty5.SelectedValue != "")
                {
                    num4 = Convert.ToInt16(this.drpProperty5.SelectedValue);
                }
                if (this.drpItem.SelectedValue != "-99")
                {
                    str = this.drpItem.SelectedItem.ToString();
                    str2 = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays = str2.Split(new char[] { '.' });
                    num5 = Convert.ToInt16(strArrays[0]);
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
                    Label label = this.lblQuantity;
                    long quantityForCredit = craDebBLL.GetQuantityForCredit(num6, num5, str1, num, num1, num2, num3, num4);
                    label.Text = quantityForCredit.ToString();
                }
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

        private bool gridValidation()
        {
            if (this.drpItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select Item", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtQuantity.Text == "")
            {
                this.msgBox.AddMessage("Enter Quantity", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtUnitPrice.Text == "")
            {
                this.msgBox.AddMessage("Enter Unit Price", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtReasonofReturn.Text == "")
            {
                this.msgBox.AddMessage("ফেরতের কারণ লিখুন", MsgBoxs.enmMessageType.Attention);
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
            if (this.drpProperty5.Visible && this.drpProperty5.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty5.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.gvAddtnProperty.Rows.Count > 0)
            {
                ArrayList arrayLists = new ArrayList();
                if (this.gvAddtnProperty.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvAddtnProperty.Rows.Count; i++)
                    {
                        CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[i].FindControl("chkChallan");
                        HiddenField hiddenField = (HiddenField)this.gvAddtnProperty.Rows[i].FindControl("additionalInfoId");
                        int num = Convert.ToInt32(hiddenField.Value);
                        if (checkBox.Checked)
                        {
                            arrayLists.Add(num);
                        }
                    }
                    if (arrayLists.Count == 0)
                    {
                        this.msgBox.AddMessage("Please Select Property from Grid.", MsgBoxs.enmMessageType.Error);
                        return false;
                    }
                    if (arrayLists.Count != Convert.ToDecimal(this.txtQuantity.Text))
                    {
                        this.msgBox.AddMessage("No of. Item Quantity and Property not equal.", MsgBoxs.enmMessageType.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        protected void gvAddtnProperty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
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
                ArrayList item = (ArrayList)this.Session["CREDIT_NOTE_DETAIL"];
                item.RemoveAt(e.RowIndex);
                this.Session["CREDIT_NOTE_DETAIL"] = item;
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

        private void insertBalance()
        {
            try
            {
                CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
                string str = this.Session["ORGANIZATION_ID"].ToString();
                string str1 = this.Session["VAT_LAST_AMOUNT"].ToString();
                string str2 = this.Session["SD_LAST_AMOUNT"].ToString();
                string str3 = this.Session["EMPLOYEE_ID"].ToString();
                DateTime now = DateTime.Now;
                DateTime formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY(now.ToString("dd/MM/yyyy"));
                currentAccountBLL.InsertBalance(Convert.ToInt32(str), Convert.ToDecimal(str1), Convert.ToDecimal(str2), Convert.ToInt32(str3), formattedDateMMDDYYYY);
                this.Session["VAT_LAST_AMOUNT"] = null;
                this.Session["SD_LAST_AMOUNT"] = null;
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "CreditNote_6.7", "insertBalance");
            }
        }

        private void itemForSearch(short itemID, string itemType)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                DataTable itemBySearch = addItemBLL.GetItemBySearch(itemID, itemType);
                this.drpItem.DataSource = itemBySearch;
                this.drpItem.DataTextField = itemBySearch.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = itemBySearch.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadDetailData()
        {
            string str = "";
            ArrayList item = (ArrayList)this.Session["CREDIT_NOTE_DETAIL"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO()
            {
                RowNo = num,
                Category = this.drpCategory.SelectedItem.ToString(),
                SubCategory = this.drpSubCategory.SelectedItem.ToString(),
                Item = this.drpItem.SelectedItem.ToString()
            };
            str = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str.Split(new char[] { '.' });
            creditNoteDetailDAO.Item_id = Convert.ToInt16(strArrays[0]);
            creditNoteDetailDAO.TypeP = this.typeP.Text;
            creditNoteDetailDAO.Unit = this.drpUnit.SelectedItem.ToString();
            creditNoteDetailDAO.UnitId = Convert.ToInt16(this.lblUnitId.Text.ToString());
            creditNoteDetailDAO.creditUnitId = Convert.ToInt16(this.drpUnit.SelectedValue);
            creditNoteDetailDAO.actualQuantity = Convert.ToDecimal(this.txtQuantity.Text.ToString());
            creditNoteDetailDAO.CredQuantity = Convert.ToDecimal(this.txtcredQuantity.Text.ToString());
            creditNoteDetailDAO.UnitPrice = Convert.ToDouble(this.txtUnitPrice.Text.ToString());
            creditNoteDetailDAO.ActUnitPrice = Convert.ToDouble(this.lblUnitPrice.Text.ToString());
            creditNoteDetailDAO.Vat = Convert.ToDouble(this.txtVAT.Text.ToString());
            creditNoteDetailDAO.Sd = Convert.ToDouble(this.txtSD.Text.ToString());
            creditNoteDetailDAO.GUnitPrice = Convert.ToDouble(this.txtTotalUnitPrice.Text.ToString());
            creditNoteDetailDAO.GTotalPrice = Convert.ToDouble(this.txtAmount.Text.ToString());
            creditNoteDetailDAO.PreviousAmount = (this.txtPreviousAmount.Text.ToString().Length > 0 ? Convert.ToDouble(this.txtPreviousAmount.Text.ToString()) : 0);
            creditNoteDetailDAO.TotalPricewithVat = Convert.ToDouble(this.txtTotalPricewithVat.Text.ToString());
            creditNoteDetailDAO.TotalTax = Convert.ToDouble(this.txtTotalTax.Text.ToString());
            creditNoteDetailDAO.ReasonOfReturn = this.txtReasonofReturn.Text.ToString();
            if (!(this.drpProperty1.SelectedValue != "-99") || !(this.drpProperty1.SelectedValue != ""))
            {
                creditNoteDetailDAO.Property1 = 0;
            }
            else
            {
                creditNoteDetailDAO.Property1 = Convert.ToInt32(this.drpProperty1.SelectedValue);
                creditNoteDetailDAO.Property1_Text = this.drpProperty1.SelectedItem.ToString();
            }
            if (!(this.drpProperty2.SelectedValue != "-99") || !(this.drpProperty2.SelectedValue != ""))
            {
                creditNoteDetailDAO.Property2 = 0;
            }
            else
            {
                creditNoteDetailDAO.Property2 = Convert.ToInt32(this.drpProperty2.SelectedValue);
                creditNoteDetailDAO.Property2_Text = this.drpProperty2.SelectedItem.ToString();
            }
            if (!(this.drpProperty3.SelectedValue != "-99") || !(this.drpProperty3.SelectedValue != ""))
            {
                creditNoteDetailDAO.Property3 = 0;
            }
            else
            {
                creditNoteDetailDAO.Property3 = Convert.ToInt32(this.drpProperty3.SelectedValue);
                creditNoteDetailDAO.Property3_Text = this.drpProperty3.SelectedItem.ToString();
            }
            if (!(this.drpProperty4.SelectedValue != "-99") || !(this.drpProperty4.SelectedValue != ""))
            {
                creditNoteDetailDAO.Property4 = 0;
            }
            else
            {
                creditNoteDetailDAO.Property4 = Convert.ToInt32(this.drpProperty4.SelectedValue);
                creditNoteDetailDAO.Property4_Text = this.drpProperty4.SelectedItem.ToString();
            }
            if (!(this.drpProperty5.SelectedValue != "-99") || !(this.drpProperty5.SelectedValue != ""))
            {
                creditNoteDetailDAO.Property5 = 0;
            }
            else
            {
                creditNoteDetailDAO.Property5 = Convert.ToInt32(this.drpProperty5.SelectedValue);
                creditNoteDetailDAO.Property5_Text = this.drpProperty5.SelectedItem.ToString();
            }
            creditNoteDetailDAO.Challan_id = Convert.ToInt32(this.drpMainChallanNo.SelectedValue);
            creditNoteDetailDAO.HdVat = Convert.ToDouble(this.hdTotalVat.Text.ToString());
            creditNoteDetailDAO.HdSD = Convert.ToDouble(this.hdTotalSD.Text.ToString());
            creditNoteDetailDAO.Status = 'S';
            creditNoteDetailDAO.Sp_Return = 2;
            if (this.drpType.SelectedIndex == 0)
            {
                creditNoteDetailDAO.Type = 'G';
            }
            else if (this.drpType.SelectedIndex != 1)
            {
                creditNoteDetailDAO.Type = 'o';
            }
            else
            {
                creditNoteDetailDAO.Type = 'S';
            }
            creditNoteDetailDAO.DecreaseId = Convert.ToInt16(this.drpDecreaseType.SelectedValue);
            creditNoteDetailDAO.UserId = Convert.ToInt16(this.Session["employee_id"].ToString());
            item.Add(creditNoteDetailDAO);
            this.Session["CREDIT_NOTE_DETAIL"] = item;
        }

        private void loadGridView()
        {
            this.gvItem.DataSource = this.Session["CREDIT_NOTE_DETAIL"];
            this.gvItem.DataBind();
        }

        private void LoadHours()
        {
            this.drpRecipientHr.Items.Add("00");
            this.drpProviderHr.Items.Add("00");
            for (int i = 1; i < 24; i++)
            {
                this.drpRecipientHr.Items.Add(i.ToString("00"));
                this.drpProviderHr.Items.Add(i.ToString("00"));
            }
        }

        private void loadItems()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
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
                DataTable allItemByCatSubCat = addItemBLL.GetAllItemByCatSubCat(setItemDAO);
                this.drpItem.DataSource = allItemByCatSubCat;
                this.drpItem.DataTextField = allItemByCatSubCat.Columns["item_name"].ToString();
                this.drpItem.DataValueField = allItemByCatSubCat.Columns["Item_id"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("---Select---", "-99");
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private CreditNoteMasterDAO loadMasterData(CreditNoteMasterDAO objCNM)
        {
            string str;
            objCNM.RecipientName = this.lblOrgName.Text.ToString();
            int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
            objCNM.BranchID = num;
            objCNM.RecipientBin = this.lblOrgBIN.Text.ToString();
            objCNM.RecipientAddress = this.lblOrgAddress.Text.ToString();
            objCNM.RecipientDate = this.txtRecipientDate.Text.ToString();
            objCNM.RecipientTime = string.Concat(this.drpRecipientHr.SelectedItem.ToString(), ":", this.drpRecipientMin.SelectedItem.ToString());
            objCNM.ProviderName = this.drpParty.SelectedItem.ToString();
            objCNM.ProviderAddress = this.ltAddress.Text.ToString();
            objCNM.ProviderBin = this.lblBIN.Text.ToString();
            this.getCreditNoteNo();
            objCNM.CreditNotNumber = this.txtCraditNot.Text.ToString();
            objCNM.ProviderDate = this.txtProviderDate.Text.ToString();
            objCNM.MainChallanNo = this.drpMainChallanNo.SelectedItem.ToString();
            objCNM.OrgId = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
            objCNM.DateNote = DateTime.Now.Date;
            objCNM.NoteYear = DateTime.Now.Year;
            if (!this.chkDiscard.Checked)
            {
                objCNM.NoteType = 'C';
            }
            else
            {
                objCNM.DiscardReasion = this.drpDiscardReason.SelectedItem.ToString();
                objCNM.NoteType = 'R';
            }
            objCNM.UserId = Convert.ToInt16(this.Session["employee_id"].ToString());
            if (this.drpParty.SelectedValue == "-99")
            {
                objCNM.PartyId = 0;
            }
            else
            {
                objCNM.PartyId = Convert.ToInt16(this.drpParty.SelectedValue);
            }
            objCNM.RecipientDate = this.txtRecipientDate.Text.ToString();
            objCNM.VehicalType = null;
            objCNM.VehicleTypeM = 7;
            objCNM.VehicleTypeD = (this.drpVehicleType.SelectedValue != "-99" ? (int)Convert.ToInt16(this.drpVehicleType.SelectedValue) : 0);
            CreditNoteMasterDAO creditNoteMasterDAO = objCNM;
            if (this.txtVehicleNo.Text.Trim() != "")
            {
                str = this.txtVehicleNo.Text.Trim();
            }
            else
            {
                str = null;
            }
            creditNoteMasterDAO.VehicleNo = str;
            objCNM.ChallanBookId = Convert.ToInt16(this.hdBookId.Value.ToString());
            objCNM.ChallanPageNumber = Convert.ToInt16(this.hdPageNo.Value.ToString());
            objCNM.MaterialType = "Cr";
            objCNM.ItemType = (this.typeP.Text.Trim() != "" ? this.typeP.Text.Trim() : "L");
            objCNM.UserId = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
            string[] strArrays = new string[] { this.txtRecipientDate.Text.Trim(), " ", this.drpRecipientHr.SelectedItem.Text, ":", this.drpRecipientMin.SelectedItem.Text };
            objCNM.ChallanDate = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            this.Session["CREDIT_NOTE_MASTER"] = objCNM;
            this.Session["NOTE_NO"] = objCNM.CreditNotNumber;
            return objCNM;
        }

        private void LoadMinutes()
        {
            this.drpRecipientMin.Items.Add("00");
            this.drpProviderMin.Items.Add("00");
            for (int i = 1; i < 60; i++)
            {
                this.drpRecipientMin.Items.Add(i.ToString("00"));
                this.drpProviderMin.Items.Add(i.ToString("00"));
            }
        }

        private void loadPertyInfo()
        {
            this.drpParty.Items.Clear();
            DataTable organizationWiseParty = this.objTransParty.getOrganizationWiseParty();
            if (organizationWiseParty != null && organizationWiseParty.Rows.Count > 0)
            {
                this.drpParty.DataSource = organizationWiseParty;
                this.drpParty.DataTextField = organizationWiseParty.Columns["party_name"].ToString();
                this.drpParty.DataValueField = organizationWiseParty.Columns["party_id"].ToString();
                this.drpParty.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpParty.Items.Insert(0, listItem);
            this.Session["PARTY_INFO"] = organizationWiseParty;
        }

        private void loadReportData()
        {
            this.btnPrintReport.Visible = true;
            CraDebBLL craDebBLL = new CraDebBLL();
            DataTable dataTable = new DataTable();
            CreditNoteDetailDAO creditNoteDetailDAO = new CreditNoteDetailDAO();
            ArrayList item = (ArrayList)this.Session["CREDIT_NOTE_DETAIL"];
            string str = Convert.ToString(this.Session["NOTE_NO"]);
            this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
            this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
            this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            this.lblUser.Text = this.Session["employee_name"].ToString();
            if (item != null)
            {
                dataTable = craDebBLL.GetCreditNoteDataForReport(str, item);
            }
            if (dataTable.Rows.Count > 0)
            {
                string str1 = "";
                this.provider_name.Text = (dataTable.Rows[0]["party_name"].ToString() != "" ? dataTable.Rows[0]["party_name"].ToString() : "N/A");
                this.provider_BIN.Text = (dataTable.Rows[0]["party_bin"].ToString() != "" ? dataTable.Rows[0]["party_bin"].ToString() : "N/A");
                this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                this.Challan_No.Text = dataTable.Rows[0]["note_no"].ToString();
                this.Challan_Date.Text = dataTable.Rows[0]["note_date"].ToString();
                this.Challan_Time.Text = dataTable.Rows[0]["issue_Time"].ToString();
                this.receiver_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.receiver_BIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.receiver_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.provider_address.Text = (dataTable.Rows[0]["party_address"].ToString() != "" ? dataTable.Rows[0]["party_address"].ToString() : "N/A");
                this.txtTransport.Text = string.Concat(dataTable.Rows[0]["code_name"].ToString(), " ", dataTable.Rows[0]["vehicle_no"].ToString());
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    decimal num = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                    string str2 = Utilities.formatFraction(num);
                    str1 = string.Concat(str1, "<tr>");
                    object obj = str1;
                    object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                    str1 = string.Concat(objArray);
                    string str3 = str1;
                    string[] strArrays = new string[] { str3, "<td>", dataTable.Rows[i]["sale_challan_no"].ToString(), ", ", dataTable.Rows[i]["sale_challan_date"].ToString(), "</td>" };
                    str1 = string.Concat(strArrays);
                    str1 = string.Concat(str1, "<td>", dataTable.Rows[i]["return_reason"].ToString(), "</td>");
                    if (Convert.ToDecimal(dataTable.Rows[i]["sale_price"]) != new decimal(0))
                    {
                        decimal num1 = Convert.ToDecimal(dataTable.Rows[i]["sale_price"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num1.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["sale_quantity"]) != new decimal(0))
                    {
                        string str4 = str1;
                        string[] strArrays1 = new string[] { str4, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["sale_quantity"])), " ", dataTable.Rows[i]["unit_name"].ToString(), "</td>" };
                        str1 = string.Concat(strArrays1);
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["sale_vat"]) != new decimal(0))
                    {
                        decimal num2 = Convert.ToDecimal(dataTable.Rows[i]["sale_vat"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num2.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["sale_sd"]) != new decimal(0))
                    {
                        decimal num3 = Convert.ToDecimal(dataTable.Rows[i]["sale_sd"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num3.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["note_price"]) != new decimal(0))
                    {
                        decimal num4 = Convert.ToDecimal(dataTable.Rows[i]["note_price"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num4.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["quantity"]) != new decimal(0))
                    {
                        string str5 = str1;
                        string[] strArrays2 = new string[] { str5, "<td style='text-align:right;padding:3px'>", str2, " ", dataTable.Rows[i]["unit_name"].ToString(), "</td>" };
                        str1 = string.Concat(strArrays2);
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["note_vat"]) != new decimal(0))
                    {
                        decimal num5 = Convert.ToDecimal(dataTable.Rows[i]["note_vat"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num5.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["note_sd"]) != new decimal(0))
                    {
                        decimal num6 = Convert.ToDecimal(dataTable.Rows[i]["note_sd"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num6.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    str1 = string.Concat(str1, "</tr>");
                    this.debitNoteReport.Text = str1;
                }
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
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.Session["chkProperty"] = new Dictionary<int, int>();
                this.pnlContents.Visible = false;
                this.Session["CREDIT_NOTE_DETAIL"] = new ArrayList();
                this.Session["PARTY_INFO"] = new DataTable();
                this.Session["CHALLAN_INFO"] = new DataTable();
                this.Session["CHALLAN_ID"] = (long)0;
                this.Session["unit_price"] = "";
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                this.lblOrgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.lblOrgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.loadPertyInfo();
                UtilityK.fillVehicleTypeDropDownList(this.drpVehicleType);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpVehicleType.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("-- Select --", "-99");
                this.drpCategory.Items.Insert(0, listItem1);
                this.drpSubCategory.Items.Insert(0, listItem1);
                ListItem listItem2 = new ListItem("-- Select --", "-99");
                this.drpItem.Items.Insert(0, listItem2);
                this.LoadHours();
                this.LoadMinutes();
                this.FillDecreaseType();
                this.txtRecipientDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.txtProviderDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.drpRecipientHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpRecipientMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                this.drpProviderHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                this.drpProviderMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                UtilityK.fillChallanDiscardReasonList(this.drpDiscardReason);
                ListItem listItem3 = new ListItem("-- Select --", "-99");
                this.drpDiscardReason.Items.Insert(0, listItem3);
                this.GetBranchInformation();
                this.getCreditNoteNo();
                CreditNoteMasterDAO creditNoteMasterDAO = new CreditNoteMasterDAO();
                this.Session["CREDIT_NOTE_MASTER"] = creditNoteMasterDAO;
                this.GetBranchAddress();
                this.GetBranchBIN();
            }
        }

        protected void PrevAmount_textChanged(object sender, EventArgs e)
        {
        }

        protected void productName_TextChanged(object sender, EventArgs e)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            short num = 0;
            try
            {
                CraDebBLL craDebBLL = new CraDebBLL();
                string str3 = MQMM.ParseText(this.productName.Text.Trim());
                string[] strArrays = str3.Split(new char[] { '-' });
                if (strArrays != null && strArrays.Count<string>() > 0)
                {
                    str = strArrays[strArrays.Count<string>() - 3];
                    str1 = strArrays[strArrays.Count<string>() - 4];
                    this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 1];
                }
                if (str == "Local")
                {
                    str2 = "L";
                }
                if (str == "Import")
                {
                    str2 = "I";
                }
                if (str == "Production")
                {
                    str2 = "F";
                }
                string str4 = string.Concat("select Item_id from Item where item_name like '%", str1, "%'");
                DataTable dataTable = this.conDB.GetDataTable(str4);
                num = Convert.ToInt16(dataTable.Rows[0]["Item_id"].ToString());
                if (this.drpMainChallanNo.SelectedItem == null)
                {
                    this.getAvailStock(num, str2);
                    DataTable allVatByItemId = craDebBLL.getAllVatByItemId(num);
                    if (allVatByItemId != null && allVatByItemId.Rows.Count > 0)
                    {
                        this.lblVat.Text = allVatByItemId.Rows[0]["VAT"].ToString();
                        this.lblSD.Text = allVatByItemId.Rows[0]["SD"].ToString();
                    }
                }
                else
                {
                    string str5 = this.drpMainChallanNo.SelectedItem.ToString();
                    DataTable unitByItemId = craDebBLL.getUnitByItemId(num, str5);
                    this.txtUnitName.Text = unitByItemId.Rows[0]["unit_code"].ToString();
                    this.lblUnitId.Text = unitByItemId.Rows[0]["unit_id"].ToString();
                    this.lblProp1.Text = unitByItemId.Rows[0]["property_id1"].ToString();
                    this.lblProp2.Text = unitByItemId.Rows[0]["property_id2"].ToString();
                    this.lblProp3.Text = unitByItemId.Rows[0]["property_id3"].ToString();
                    this.lblProp4.Text = unitByItemId.Rows[0]["property_id4"].ToString();
                    this.lblProp5.Text = unitByItemId.Rows[0]["property_id5"].ToString();
                    this.txtUnitPrice.Text = unitByItemId.Rows[0]["actual_price"].ToString();
                    this.hdTotalVat.Text = unitByItemId.Rows[0]["vat"].ToString();
                    this.hdTotalSD.Text = unitByItemId.Rows[0]["sd"].ToString();
                    this.getAvailStock(num, str2);
                    DataTable allVatByItemId1 = craDebBLL.getAllVatByItemId(num);
                    if (allVatByItemId1 != null && allVatByItemId1.Rows.Count > 0)
                    {
                        this.lblVat.Text = allVatByItemId1.Rows[0]["VAT"].ToString();
                        this.lblSD.Text = allVatByItemId1.Rows[0]["SD"].ToString();
                    }
                }
                this.itemForSearch(num, str2);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void SDLastUpdatedBalance()
        {
            try
            {
                CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
                decimal num = new decimal(0);
                DateTime today = DateTime.Today;
                DateTime formattedDateMMDDYYYY = DateTime.Today;
                string str = this.Session["ORGANIZATION_ID"].ToString();
                today =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
                formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
                DataTable currentAccount18ReportBySearchSD = currentAccountBLL.GetCurrentAccount18ReportBySearchSD(today, formattedDateMMDDYYYY, Convert.ToInt16(str));
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("date_challan");
                dataTable.Columns.Add("trns_desc");
                dataTable.Columns.Add("challan_no");
                dataTable.Columns.Add("treasury_deposit");
                dataTable.Columns.Add("exempt_amount");
                dataTable.Columns.Add("others", typeof(decimal));
                dataTable.Columns.Add("pay_amount", typeof(decimal));
                dataTable.Columns.Add("balance_amount", typeof(decimal));
                dataTable.Columns.Add("balance_action");
                if (dataTable == null || dataTable.Rows.Count <= 0)
                {
                    dataTable = currentAccount18ReportBySearchSD;
                    dataTable = this.getNewDataTableWithBalance(dataTable);
                }
                else
                {
                    DataView defaultView = dataTable.DefaultView;
                    defaultView.Sort = "date_challan ASC";
                    dataTable = this.getNewDataTableWithBalance(defaultView.ToTable());
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    string str1 = string.Empty;
                    string empty2 = string.Empty;
                    string str2 = string.Empty;
                    string empty3 = string.Empty;
                    DataTable dataTable1 = new DataTable();
                    dataTable1.Columns.Add("date_challan");
                    dataTable1.Columns.Add("trns_desc");
                    dataTable1.Columns.Add("challan_no");
                    dataTable1.Columns.Add("treasury_deposit");
                    dataTable1.Columns.Add("exempt_amount");
                    dataTable1.Columns.Add("others", typeof(decimal));
                    dataTable1.Columns.Add("pay_amount", typeof(decimal));
                    dataTable1.Columns.Add("balance_amount", typeof(decimal));
                    dataTable1.Columns.Add("balance_action");
                    DataRow item = dataTable.Rows[dataTable.Rows.Count - 1];
                    if (item != null)
                    {
                        dataTable1.ImportRow(item);
                        num = new decimal(0);
                        if (dataTable1.Rows[0]["balance_amount"] != null)
                        {
                            num = Convert.ToDecimal(dataTable1.Rows[0]["balance_amount"].ToString());
                            this.Session["SD_LAST_AMOUNT"] = num.ToString("0.00");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "CreditNote_6.7", "SDLastUpdatedBalance");
            }
        }

        protected void Search(object sender, EventArgs e)
        {
            this.SearchProperty();
        }

        private void SearchProperty()
        {
            this.gvAddtnProperty.DataSource = null;
            this.gvAddtnProperty.DataBind();
            string str = this.txtSearch.Text.Trim();
            this.drpItem.SelectedItem.ToString();
            int num = 0;
            string str1 = "";
            str1 = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str1.Split(new char[] { '.' });
            num = Convert.ToInt16(strArrays[0]);
            AddItemBLL addItemBLL = new AddItemBLL();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            num2 = Convert.ToInt16(this.drpMainChallanNo.SelectedValue);
            DataTable dataTable = this.objPDBll.geAdditionalPropertybySearch(str.ToUpper(), num, "S", num1, num2, num3);
            if (dataTable.Rows.Count <= 0)
            {
                this.displayTotalRecordsFound();
                return;
            }
            Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
            Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
            Convert.ToInt16(dataTable.Rows[0]["property_id3"]);
            Convert.ToInt16(dataTable.Rows[0]["property_id4"]);
            Convert.ToInt16(dataTable.Rows[0]["property_id5"]);
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ContructualProductionIssueDAO contructualProductionIssueDAO = new ContructualProductionIssueDAO()
                {
                    additionalInfoId = Convert.ToInt32(dataTable.Rows[i]["additional_info_id"]),
                    Item_id = Convert.ToInt32(dataTable.Rows[i]["item_id"])
                };
                if (dataTable.Rows[i]["property_id1_value"].ToString() != "")
                {
                    contructualProductionIssueDAO.Property1_Text = dataTable.Rows[i]["property_id1_value"].ToString();
                }
                if (dataTable.Rows[i]["property_id2_value"].ToString() != "")
                {
                    contructualProductionIssueDAO.Property2_Text = dataTable.Rows[i]["property_id2_value"].ToString();
                }
                if (dataTable.Rows[i]["property_id3_value"].ToString() != "")
                {
                    contructualProductionIssueDAO.Property3_Text = dataTable.Rows[i]["property_id3_value"].ToString();
                }
                if (dataTable.Rows[i]["property_id4_value"].ToString() != "")
                {
                    contructualProductionIssueDAO.Property4_Text = dataTable.Rows[i]["property_id4_value"].ToString();
                }
                if (dataTable.Rows[i]["property_id5_value"].ToString() != "")
                {
                    contructualProductionIssueDAO.Property5_Text = dataTable.Rows[i]["property_id5_value"].ToString();
                }
                arrayLists.Add(contructualProductionIssueDAO);
            }
            this.gvAddtnProperty.DataSource = arrayLists;
            this.gvAddtnProperty.DataBind();
            Dictionary<int, int> item = (Dictionary<int, int>)this.Session["chkProperty"];
            if (item != null && item.Count > 0 && str == "")
            {
                for (int j = 0; j < this.gvAddtnProperty.Rows.Count; j++)
                {
                    CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[j].FindControl("chkChallan");
                    int num4 = Convert.ToInt32(((HiddenField)this.gvAddtnProperty.Rows[j].FindControl("additionalInfoId")).Value);
                    foreach (int key in item.Keys)
                    {
                        int num5 = key;
                        if (!item.ContainsKey(num5) || num4 != num5)
                        {
                            continue;
                        }
                        checkBox.Checked = true;
                    }
                }
            }
            this.displayTotalRecordsFound();
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
                this.txtQuantity.Text = this.txtQuantity.Text;
            }
            else
            {
                num4 = Convert.ToDecimal(dataTable.Rows[0]["quantity"]);
                str = this.drpUnit.SelectedItem.ToString();
                num5 = (!string.IsNullOrEmpty(this.txtQuantity.Text) ? Convert.ToDecimal(this.txtQuantity.Text) : new decimal(0));
                if (this.txtUnitName.Text != str)
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
                this.txtUnitPrice.Text = num6.ToString("0.00");
                this.txtcredQuantity.Text = this.lblQuantityPrp.Text;
                if (this.txtcredQuantity.Text != "0")
                {
                    this.VatSDCalculationForTobacco();
                    return;
                }
            }
        }

        protected void txtPreviousAmount_TextChanged(object sender, EventArgs e)
        {
            if (!(this.txtPreviousAmount.Text == "") && !(this.txtPreviousAmount.Text == "0"))
            {
                this.CalculateAfterBadkorton();
                return;
            }
            this.GetItemDetails();
            this.calculatePrice();
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
                else if (this.txtPreviousAmount.Text != "" || this.txtPreviousAmount.Text != "0")
                {
                    this.txtcredQuantity.Text = this.txtQuantity.Text;
                    this.GetItemDetails();
                    this.calculatePrice();
                    this.CalculateAfterBadkorton();
                }
                else
                {
                    this.txtcredQuantity.Text = this.txtQuantity.Text;
                    double num = (this.txtQuantity.Text != "") ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 1.0;
                    double num2 = (this.txtUnitPrice.Text != "") ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0.0;
                    double num3 = (this.lblSD.Text != "") ? Convert.ToDouble(this.lblSD.Text.Trim()) : 0.0;
                    double num4 = num * num2 * (num3 / 100.0);
                    this.txtSD.Text = num4.ToString("N");
                    double num5 = ((this.txtUnitPrice.Text != "") ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0.0) + ((this.txtSD.Text != "") ? Convert.ToDouble(this.txtSD.Text.Trim()) : 0.0);
                    double num6 = num5 * ((this.lblVat.Text != "") ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0.0) / 100.0;
                    double num7 = (this.txtSD.Text != "") ? Convert.ToDouble(this.txtSD.Text.Trim()) : 0.0;
                    double num8 = (this.lblVat.Text != "") ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0.0;
                    double num9 = (this.txtUnitPrice.Text != "") ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0.0;
                    double num10 = num9 * ((this.lblSD.Text != "") ? Convert.ToDouble(this.lblSD.Text.Trim()) : 0.0) / 100.0;
                    double num11 = num9 + num10;
                    double num12;
                    if (this.Label2.Text == " Per Unit")
                    {
                        num12 = num * num8;
                    }
                    else
                    {
                        num12 = num11 * ((this.lblVat.Text != "") ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0.0) / 100.0;
                    }
                    double num13 = num11 + num12;
                    if (this.txtVAT.Text != "")
                    {
                        Convert.ToDouble(this.txtVAT.Text.Trim());
                    }
                    double num14;
                    if (this.Label2.Text == " Per Unit")
                    {
                        num14 = num * Convert.ToDouble(this.txtUnitPrice.Text.Trim()) + num * Convert.ToDouble(this.lblVat.Text.Trim());
                    }
                    else
                    {
                        num14 = num * num13;
                    }
                    this.txtAmount.Text = num14.ToString("N");
                    double num15 = num14 - num7;
                    this.txtTotalPricewithVat.Text = num15.ToString("N");
                    double num16;
                    if (this.Label2.Text == " Per Unit")
                    {
                        num16 = num * Convert.ToDouble(this.lblVat.Text.Trim());
                    }
                    else
                    {
                        num16 = (num * num2 + num4) * ((this.lblVat.Text != "") ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0.0) / 100.0;
                    }
                    this.txtVAT.Text = num16.ToString("N");
                    double num17 = (this.txtVAT.Text != "") ? Convert.ToDouble(this.txtVAT.Text.Trim()) : 0.0;
                    double num18 = (this.txtSD.Text != "") ? Convert.ToDouble(this.txtSD.Text.Trim()) : 0.0;
                    this.txtTotalTax.Text = (this.txtTotalTax.Text = (num17 + num18).ToString("N"));
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

    protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
    {

            try
            {
                this.lblUnitPrice.Text = this.txtUnitPrice.Text;
                double num = (this.txtQuantity.Text != "") ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 1.0;
                double num2 = (this.txtUnitPrice.Text != "") ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0.0;
                double num3 = (this.lblSD.Text != "") ? Convert.ToDouble(this.lblSD.Text.Trim()) : 0.0;
                double num4 = num * num2 * (num3 / 100.0);
                this.txtSD.Text = num4.ToString("N");
                double num5 = ((this.txtUnitPrice.Text != "") ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0.0) + ((this.txtSD.Text != "") ? Convert.ToDouble(this.txtSD.Text.Trim()) : 0.0);
                double num6 = num5 * ((this.lblVat.Text != "") ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0.0) / 100.0;
                double num7 = (this.txtSD.Text != "") ? Convert.ToDouble(this.txtSD.Text.Trim()) : 0.0;
                if (this.lblVat.Text != "")
                {
                    Convert.ToDouble(this.lblVat.Text.Trim());
                }
                double num8 = (this.txtUnitPrice.Text != "") ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0.0;
                double num9 = num8 * ((this.lblSD.Text != "") ? Convert.ToDouble(this.lblSD.Text.Trim()) : 0.0) / 100.0;
                double num10 = num8 + num9;
                double num11 = num10 * ((this.lblVat.Text != "") ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0.0) / 100.0;
                double num12 = num10 + num11;
                this.txtTotalUnitPrice.Text = num12.ToString("N");
                if (this.txtVAT.Text != "")
                {
                    Convert.ToDouble(this.txtVAT.Text.Trim());
                }
                double num13 = num * num12;
                this.txtAmount.Text = num13.ToString("N");
                double num14 = num13 - num7;
                this.txtTotalPricewithVat.Text = num14.ToString("N");
                double num15 = (num * num2 + num4) * ((this.lblVat.Text != "") ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0.0) / 100.0;
                this.txtVAT.Text = num15.ToString("N");
                double num16 = (this.txtVAT.Text != "") ? Convert.ToDouble(this.txtVAT.Text.Trim()) : 0.0;
                double num17 = (this.txtSD.Text != "") ? Convert.ToDouble(this.txtSD.Text.Trim()) : 0.0;
                this.txtTotalTax.Text = (this.txtTotalTax.Text = (num16 + num17).ToString("N"));
                if (this.txtPreviousAmount.Text != "" || this.txtPreviousAmount.Text != "0")
                {
                    this.CalculateAfterBadkorton();
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

    private bool validation()
    {
        if (this.drpParty.SelectedValue == "" || this.drpParty.SelectedValue == "-99")
        {
            this.msgBox.AddMessage("Please select party name", MsgBoxs.enmMessageType.Attention);
            return false;
        }
        if (this.txtCraditNot.Text == "")
        {
            this.msgBox.AddMessage("Credit number not available", MsgBoxs.enmMessageType.Attention);
            return false;
        }
        if (!(this.drpMainChallanNo.SelectedValue == "") && !(this.drpMainChallanNo.SelectedValue == "-99"))
        {
            return true;
        }
        this.msgBox.AddMessage("Please select Challan Number.", MsgBoxs.enmMessageType.Attention);
        return false;
    }

    private void VATLastUpdatedBalance()
    {
        try
        {
            CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
            decimal num = new decimal(0);
            DateTime today = DateTime.Today;
            DateTime formattedDateMMDDYYYY = DateTime.Today;
            string str = this.Session["ORGANIZATION_ID"].ToString();
            today =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
            formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
            DataTable currentAccount18ReportBySearchVAT = currentAccountBLL.GetCurrentAccount18ReportBySearchVAT(today, formattedDateMMDDYYYY, Convert.ToInt16(str));
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("date_challan");
            dataTable.Columns.Add("trns_desc");
            dataTable.Columns.Add("challan_no");
            dataTable.Columns.Add("treasury_deposit");
            dataTable.Columns.Add("exempt_amount");
            dataTable.Columns.Add("others", typeof(decimal));
            dataTable.Columns.Add("pay_amount", typeof(decimal));
            dataTable.Columns.Add("balance_amount", typeof(decimal));
            dataTable.Columns.Add("balance_action");
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                dataTable = currentAccount18ReportBySearchVAT;
                dataTable = this.getNewDataTableWithBalance(dataTable);
            }
            else
            {
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "date_challan ASC";
                dataTable = this.getNewDataTableWithBalance(defaultView.ToTable());
            }
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string empty = string.Empty;
                string empty1 = string.Empty;
                string str1 = string.Empty;
                string empty2 = string.Empty;
                string str2 = string.Empty;
                string empty3 = string.Empty;
                DataTable dataTable1 = new DataTable();
                dataTable1.Columns.Add("date_challan");
                dataTable1.Columns.Add("trns_desc");
                dataTable1.Columns.Add("challan_no");
                dataTable1.Columns.Add("treasury_deposit");
                dataTable1.Columns.Add("exempt_amount");
                dataTable1.Columns.Add("others", typeof(decimal));
                dataTable1.Columns.Add("pay_amount", typeof(decimal));
                dataTable1.Columns.Add("balance_amount", typeof(decimal));
                dataTable1.Columns.Add("balance_action");
                DataRow item = dataTable.Rows[dataTable.Rows.Count - 1];
                if (item != null)
                {
                    dataTable1.ImportRow(item);
                    num = new decimal(0);
                    if (dataTable1.Rows[0]["balance_amount"] != null)
                    {
                        num = Convert.ToDecimal(dataTable1.Rows[0]["balance_amount"].ToString());
                        this.Session["VAT_LAST_AMOUNT"] = num.ToString("0.00");
                    }
                }
            }
        }
        catch (Exception exception)
        {
             BLL.Utility.InsertErrorTrack(exception.Message, "CreditNote_6.7", "VATLastUpdatedBalance");
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
        try
        {
            num2 = (!string.IsNullOrEmpty(this.lblVat.Text) ? Convert.ToDouble(this.lblVat.Text.Trim()) : 0);
            num3 = (!string.IsNullOrEmpty(this.lblSD.Text) ? Convert.ToDouble(this.lblSD.Text.Trim()) : 0);
            if (this.drpItem.SelectedValue != "-99")
            {
                num = Convert.ToDouble(this.Session["unit_price"]);
                if (this.txtcredQuantity.Text == "")
                {
                    num1 = (!string.IsNullOrEmpty(this.txtQuantity.Text) ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                }
                else
                {
                    num1 = (!string.IsNullOrEmpty(this.txtcredQuantity.Text) ? Convert.ToDouble(this.txtcredQuantity.Text.Trim()) : 0);
                }
                num5 = num1 * num * num3 / 100;
                num4 = (this.Label9.Text != " Per Unit" ? num1 * num * num2 / 100 : Convert.ToDouble(this.lblVat.Text.Trim()) * Convert.ToDouble(this.txtQuantity.Text.Trim()));
                this.txtVAT.Text = num4.ToString("N2");
                this.txtSD.Text = num5.ToString("N2");
                num6 = (this.Label9.Text != " Per Unit" ? num1 * num : num1 * num);
                this.txtTotalPricewithVat.Text = num6.ToString();
                this.txtAmount.Text = num6.ToString();
                this.txtTotalUnitPrice.Text = num6.ToString();
                this.txtTotalTax.Text = (num4 + num5).ToString();
            }
        }
        catch (Exception exception)
        {
            ReallySimpleLog.WriteLog(exception);
        }
    }
    }
}