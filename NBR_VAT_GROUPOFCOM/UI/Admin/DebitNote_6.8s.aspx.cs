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
    public partial class DebitNote_6__8s : Page, IRequiresSessionState
    {
        private TransPartyBLL objTransParty = new TransPartyBLL();

        private CraDebBLL objDCBLL = new CraDebBLL();

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

        public DebitNote_6__8s()
        {
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridValidation())
                {
                    this.loadDetailData();
                    this.loadGridView();
                    this.detailClear();
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "DebitNote_6.8", "btnAddRow_Click");
            }
        }

        protected void btnOA_Click(object sender, EventArgs e)
        {
            try
            {
                base.Response.Redirect("~/UI/Admin/DebitNote_Extension.aspx");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DebitNoteMasterDAO debitNoteMasterDAO = new DebitNoteMasterDAO();
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
                    debitNoteMasterDAO = (DebitNoteMasterDAO)this.Session["DEBIT_MASTER_DATA"];
                    this.lblReceiverName.Text = debitNoteMasterDAO.RecipientName.ToString();
                    this.lblReceiverBIN.Text = debitNoteMasterDAO.RecipientBin.ToString();
                    this.lblReceiverNoteNumber.Text = debitNoteMasterDAO.CreditNotNumber.ToString();
                    this.lblReceiverDate.Text = debitNoteMasterDAO.RecipientDate.ToString();
                    this.lblReceiverTime.Text = debitNoteMasterDAO.RecipientTime.ToString();
                    this.lblProviderName.Text = debitNoteMasterDAO.ProviderName.ToString();
                    this.lblProviderBIN.Text = debitNoteMasterDAO.ProviderBin.ToString();
                    this.lblProviderChallan.Text = debitNoteMasterDAO.MainChallanNo.ToString();
                    this.lblProviderDate.Text = debitNoteMasterDAO.ProviderDate.ToString();
                    ArrayList item = (ArrayList)this.Session["DEBIT_NOTE_DETAIL"];
                    if (item != null)
                    {
                        double gTotalPrice = 0;
                        double previousAmount = 0;
                        double totalPricewithVat = 0;
                        double vat = 0;
                        double sd = 0;
                        double totalTax = 0;
                        string str = "";
                        DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO();
                        for (int i = 0; i < item.Count; i++)
                        {
                            debitNoteDetailDAO = (DebitNoteDetailDAO)item[i];
                            str = string.Concat(str, "<tr>");
                            object obj = str;
                            object[] objArray = new object[] { obj, "<td style='border:1px solid gray'>", i + 1, "</td>" };
                            str = string.Concat(objArray);
                            str = string.Concat(str, "<td style='border:1px solid gray'>", debitNoteDetailDAO.Item, "</td>");
                            str = string.Concat(str, "<td style='text-align: center;border:1px solid gray'>", debitNoteDetailDAO.Unit, "</td>");
                            object obj1 = str;
                            object[] quantity = new object[] { obj1, "<td style='border:1px solid gray'>", debitNoteDetailDAO.Quantity, "</td>" };
                            str = string.Concat(quantity);
                            object obj2 = str;
                            object[] gUnitPrice = new object[] { obj2, "<td style='border:1px solid gray'>", debitNoteDetailDAO.GUnitPrice, "</td>" };
                            str = string.Concat(gUnitPrice);
                            object obj3 = str;
                            object[] gTotalPrice1 = new object[] { obj3, "<td style='border:1px solid gray'>", debitNoteDetailDAO.GTotalPrice, "</td>" };
                            str = string.Concat(gTotalPrice1);
                            str = string.Concat(str, "</tr>");
                            this.debitNoteReport.Text = str;
                            this.ReturnComment.Text = debitNoteDetailDAO.ReasonOfReturn;
                            gTotalPrice += debitNoteDetailDAO.GTotalPrice;
                            previousAmount += debitNoteDetailDAO.PreviousAmount;
                            totalPricewithVat += debitNoteDetailDAO.TotalPricewithVat;
                            vat += debitNoteDetailDAO.Vat;
                            sd += debitNoteDetailDAO.Sd;
                            totalTax += debitNoteDetailDAO.TotalTax;
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
            base.Response.Redirect("~/UI/Admin/DebitNote_6.8.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CraDebBLL craDebBLL = new CraDebBLL();
            DebitNoteMasterDAO debitNoteMasterDAO = new DebitNoteMasterDAO();
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
                        string text = this.txtDebitNot.Text;
                        char chr = 'D';
                        string text1 = this.txtDebitNot.Text;
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
                    debitNoteMasterDAO = this.loadMasterData(debitNoteMasterDAO);
                    if (debitNoteMasterDAO != null)
                    {
                        if (!this.chkDiscard.Checked)
                        {
                            arrayLists = (ArrayList)this.Session["DEBIT_NOTE_DETAIL"];
                            if (arrayLists == null || arrayLists.Count == 0)
                            {
                                this.gvItem.DataSource = null;
                                this.gvItem.DataBind();
                                this.msgBox.AddMessage("Please insert Detail data properly.", MsgBoxs.enmMessageType.Attention);
                                return;
                            }
                        }
                        Dictionary<int, int> item = (Dictionary<int, int>)this.Session["chkProperty"];
                        if (this.gvAddtnProperty.Rows.Count > 0 && item.Count == 0)
                        {
                            this.msgBox.AddMessage("Please Select Property from Grid.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else if (!craDebBLL.saveDebitNote(debitNoteMasterDAO, arrayLists, item))
                        {
                            this.msgBox.AddMessage("Data Insert Failed.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Data Insert Successfully.", MsgBoxs.enmMessageType.Success);
                            this.masterClear();
                            this.gvItem.DataSource = null;
                            this.gvItem.DataBind();
                            this.gvAddtnProperty.DataSource = null;
                            this.gvAddtnProperty.DataBind();
                            this.VATLastUpdatedBalance();
                            this.SDLastUpdatedBalance();
                            this.insertBalance();
                            this.pnlContents.Visible = true;
                            this.loadReportData();
                            this.getDebitNoteNo();
                            this.Session["DEBIT_NOTE_DETAIL"] = new ArrayList();
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
                 BLL.Utility.InsertErrorTrack(exception1.Message, "DebittNote_6.8", "btnSave_Click");
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
                    double num10 = num4 + num3;
                    this.txtTotalTax.Text = num10.ToString("0.00");
                    double num11 = num6 * Convert.ToDouble(this.txtUnitPrice.Text) + num3 + num4;
                    this.txtAmount.Text = num11.ToString("0.00");
                    Convert.ToDouble(this.txtAmount.Text.Trim());
                    double num12 = Convert.ToDouble(this.txtAmount.Text.Trim()) - Convert.ToDouble(this.txtSD.Text.Trim());
                    this.txtTotalPricewithVat.Text = num12.ToString("0.00");
                }
            }
        }

        private void calculatePrice()
        {
            double num;
            double num1 = 0;
            double num2 = Convert.ToDouble(this.lblVat.Text.ToString());
            double num3 = Convert.ToDouble(this.lblSD.Text.ToString());
            num1 = (this.txtQuantity.Text.ToString() == "" ? 0 : Convert.ToDouble(this.txtQuantity.Text.ToString()));
            num = (this.txtUnitPrice.Text.ToString() == "" ? 0 : Convert.ToDouble(this.txtUnitPrice.Text.ToString()));
            double num4 = num * num2 / 100;
            double num5 = num * num3 / 100;
            double num6 = 1 * num;
            double num7 = 0;
            double num8 = 0;
            double num9 = 0;
            double num10 = 0;
            if (num1 == 0)
            {
                if (this.Label2.Text != " Per Unit")
                {
                    num7 = num6 * num3 / 100 * 1;
                    num8 = (num7 + num6) * num2 / 100 * 1;
                }
                else
                {
                    num8 = num2 * 1;
                }
            }
            else if (this.Label2.Text != " Per Unit")
            {
                num9 = num6 * num3 / 100 * num1;
                num10 = (num9 + num6 * num1) * num2 / 100;
            }
            else
            {
                num8 = num6 * num1;
            }
            double num11 = 0;
            num11 = num6 + num8 + num7;
            if (num1 == 0)
            {
                this.HiddenFieldAkokMullo.Value = num11.ToString();
            }
            double num12 = 0;
            num12 = (num1 != 0 ? num10 + num9 : num8 + num7);
            if (num1 != 0)
            {
                this.txtVAT.Text = num10.ToString();
                this.txtSD.Text = num9.ToString();
            }
            else
            {
                this.txtVAT.Text = num8.ToString();
                this.txtSD.Text = num7.ToString();
            }
            this.txtTotalUnitPrice.Text = this.HiddenFieldAkokMullo.Value;
            if (num1 != 0)
            {
                TextBox str = this.txtAmount;
                double num13 = num1 * Convert.ToDouble(this.txtTotalUnitPrice.Text.Trim());
                str.Text = num13.ToString("0.00");
            }
            else
            {
                TextBox textBox = this.txtAmount;
                double num14 = 1 * Convert.ToDouble(this.txtTotalUnitPrice.Text.Trim());
                textBox.Text = num14.ToString("0.00");
            }
            this.txtTotalTax.Text = num12.ToString();
            if (this.txtPreviousAmount.Text.ToString() != "")
            {
                Convert.ToDouble(this.txtPreviousAmount.Text.ToString());
            }
            Convert.ToDouble(this.txtAmount.Text.Trim());
            double num15 = Convert.ToDouble(this.txtAmount.Text.Trim()) - Convert.ToDouble(this.txtSD.Text.Trim());
            this.txtTotalPricewithVat.Text = num15.ToString("0.00");
        }

        private void calculatePrice1()
        {
            double num;
            try
            {
                double num1 = 0;
                double num2 = Convert.ToDouble(this.lblVat.Text.ToString());
                double num3 = Convert.ToDouble(this.lblSD.Text.ToString());
                num1 = (this.txtQuantity.Text.ToString() == "" ? 1 : Convert.ToDouble(this.txtQuantity.Text.ToString()));
                num = (this.txtUnitPrice.Text.ToString() == "" ? 0 : Convert.ToDouble(this.txtUnitPrice.Text.ToString()));
                double num4 = num * num2 / 100;
                double num5 = num * num3 / 100;
                double num6 = 1 * num;
                double num7 = 0;
                double num8 = 0;
                double num9 = 0;
                double num10 = 0;
                if (num1 != 1)
                {
                    num9 = num6 * num3 / 100 * num1;
                    num10 = (num9 + num6) * num2 / 100 * num1;
                }
                else
                {
                    num7 = num6 * num3 / 100 * num1;
                    num8 = (num7 + num6) * num2 / 100 * num1;
                }
                double num11 = 0;
                num11 = num6 + num8 + num7;
                double num12 = 0;
                num12 = (num1 != 1 ? num10 + num9 : num8 + num7);
                if (num1 != 1)
                {
                    this.txtVAT.Text = num10.ToString();
                    this.txtSD.Text = num9.ToString();
                }
                else
                {
                    this.txtVAT.Text = num8.ToString();
                    this.txtSD.Text = num7.ToString();
                }
                this.txtTotalUnitPrice.Text = num11.ToString("0.00");
                double num13 = num1 * num11;
                this.txtAmount.Text = num13.ToString("0.00");
                this.txtTotalTax.Text = num12.ToString();
                if (this.txtPreviousAmount.Text.ToString() != "")
                {
                    Convert.ToDouble(this.txtPreviousAmount.Text.ToString());
                }
                Convert.ToDouble(this.txtAmount.Text.Trim());
                double num14 = Convert.ToDouble(this.txtAmount.Text.Trim()) - Convert.ToDouble(this.txtSD.Text.Trim());
                this.txtTotalPricewithVat.Text = num14.ToString("0.00");
            }
            catch (Exception exception)
            {
                throw exception;
            }
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
            base.Response.Redirect("~/UI/Admin/DebitNote_6.8.aspx");
            this.lblDiscardReason.Visible = false;
            this.drpDiscardReason.Visible = false;
            this.drpMainChallanNo.Enabled = true;
            this.drpCategory.Enabled = true;
            this.drpSubCategory.Enabled = true;
            this.drpItem.Enabled = true;
            this.btnAddRow.Enabled = true;
            this.drpType.Enabled = true;
            this.drpDecreaseType.Enabled = true;
            this.txtQuantity.Enabled = true;
        }

        private void clearChange()
        {
            this.drpItem.Items.Clear();
            int num = Convert.ToInt16(this.drpMainChallanNo.SelectedValue);
            DataTable debitItembyChallanId = this.objDCBLL.GetDebitItembyChallanId(num);
            this.drpItem.DataSource = debitItembyChallanId;
            this.drpItem.DataTextField = debitItembyChallanId.Columns["item_name"].ToString();
            this.drpItem.DataValueField = debitItembyChallanId.Columns["Item_id"].ToString();
            this.drpItem.DataBind();
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
            this.txtReasonofReturn.Text = "";
            this.txtAmount.Text = "";
            this.drpCategory.Items.Clear();
            this.drpSubCategory.Items.Clear();
            ListItem listItem1 = new ListItem("-- Select --", "-99");
            this.drpCategory.Items.Insert(0, listItem1);
            this.drpSubCategory.Items.Insert(0, listItem1);
            this.drpCategory.SelectedValue = "-99";
            this.drpSubCategory.SelectedValue = "-99";
        }

        private void detailClear()
        {
            this.lblfxdVT.Text = "";
            this.Label2.Text = "%";
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
                this.divProp.Visible = true;
                this.Label2.Text = "%";
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
                short num = 0;
                string str = "";
                string str1 = "";
                string str2 = "";
                this.chkRebatable.Checked = false;
                this.chkRebatable.Attributes["style"] = "color:black;";
                if (!this.chkDiscard.Checked)
                {
                    AddItemBLL addItemBLL = new AddItemBLL();
                    CraDebBLL craDebBLL = new CraDebBLL();
                    if (this.drpItem.SelectedValue != "-99")
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
                            str2 = "R";
                        }
                        str = Convert.ToString(this.drpItem.SelectedValue);
                        string[] strArrays = str.Split(new char[] { '.' });
                        num = Convert.ToInt16(strArrays[0]);
                        string[] strArrays1 = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                        if (strArrays1 != null && strArrays1.Count<string>() > 0)
                        {
                            this.lblHSCode.Text = strArrays1[strArrays1.Count<string>() - 1];
                        }
                        this.ItemType.Value = str2;
                        DataTable dataTable = this.objPDBll.geAdditionalPropertybyItemID(num, str2);
                        if (dataTable.Rows.Count > 0)
                        {
                            this.divProp.Visible = false;
                            short num1 = 0;
                            short num2 = 0;
                            short num3 = 0;
                            short num4 = 0;
                            short num5 = 0;
                            string str3 = "";
                            string str4 = "";
                            string str5 = "";
                            string str6 = "";
                            string str7 = "";
                            DataTable appCodeDetailName = null;
                            num1 = Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
                            num2 = Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
                            num3 = Convert.ToInt16(dataTable.Rows[0]["property_id3"]);
                            num4 = Convert.ToInt16(dataTable.Rows[0]["property_id4"]);
                            num5 = Convert.ToInt16(dataTable.Rows[0]["property_id5"]);
                            ArrayList arrayLists = new ArrayList();
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num1);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField = new BoundField();
                                str3 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str3);
                                boundField.HeaderText = str3;
                                boundField.DataField = "Property1_Text";
                                this.gvAddtnProperty.Columns.Add(boundField);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num2);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField1 = new BoundField();
                                str4 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str4);
                                boundField1.HeaderText = str4;
                                boundField1.DataField = "Property2_Text";
                                this.gvAddtnProperty.Columns.Add(boundField1);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num3);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField2 = new BoundField();
                                str5 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str5);
                                boundField2.HeaderText = str5;
                                boundField2.DataField = "Property3_Text";
                                this.gvAddtnProperty.Columns.Add(boundField2);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num4);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField3 = new BoundField();
                                str6 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str6);
                                boundField3.HeaderText = str6;
                                boundField3.DataField = "Property4_Text";
                                this.gvAddtnProperty.Columns.Add(boundField3);
                            }
                            appCodeDetailName = addItemBLL.GetAppCodeDetailName(num5);
                            if (appCodeDetailName.Rows.Count > 0)
                            {
                                BoundField boundField4 = new BoundField();
                                str7 = appCodeDetailName.Rows[0]["code_name"].ToString();
                                this.tableNameList.Add(str7);
                                boundField4.HeaderText = str7;
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
                this.calculatePrice();
                this.EnableOrDisablePropertyForItem();
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
                if (this.drpMainChallanNo.SelectedValue == "-99")
                {
                    this.clearChange();
                }
                else
                {
                    int num = Convert.ToInt16(this.drpMainChallanNo.SelectedValue);
                    DataTable item = (DataTable)this.Session["PURCHASE_CHALLAN"];
                    DataRow[] dataRowArray = item.Select(string.Concat("Challan_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        string str = dataRow["date_challan"].ToString();
                        string[] strArrays = str.Split(new char[] { ' ' });
                        DateTime dateTime = Convert.ToDateTime(dataRow["date_challan"]);
                        string str1 = dateTime.ToString("dd/MM/yyyy");
                        char[] chrArray = new char[] { ' ' };
                        string[] strArrays1 = str1.Split(chrArray)[0].Split(new char[] { '/' });
                        string str2 = (strArrays1[0].Length > 1 ? strArrays1[0].ToString() : string.Concat("0", strArrays1[0].ToString()));
                        string str3 = (strArrays1[1].Length > 1 ? strArrays1[1].ToString() : string.Concat("0", strArrays1[1].ToString()));
                        string str4 = strArrays1[2].ToString();
                        TextBox textBox = this.txtProviderDate;
                        string[] strArrays2 = new string[] { str2, "/", str3, "/", str4 };
                        textBox.Text = string.Concat(strArrays2);
                        if (strArrays[1].ToString() != null)
                        {
                            string str5 = strArrays[1].ToString();
                            string[] strArrays3 = str5.Split(new char[] { ':' });
                            this.drpProviderHr.SelectedValue = (strArrays3[strArrays3.Count<string>() - 3].Length > 1 ? strArrays3[strArrays3.Count<string>() - 3].ToString() : string.Concat("0", strArrays3[strArrays3.Count<string>() - 3].ToString()));
                            this.drpProviderMin.SelectedValue = (strArrays3[strArrays3.Count<string>() - 2].Length > 0 ? strArrays3[strArrays3.Count<string>() - 2].ToString() : string.Concat("0", strArrays3[strArrays3.Count<string>() - 2].ToString()));
                        }
                    }
                    this.clearChange();
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
                if (this.drpParty.SelectedValue == "-99")
                {
                    this.rbLocalPurchase.Checked = false;
                    this.rbImport.Checked = false;
                    this.drpMainChallanNo.Items.Clear();
                    this.drpMainChallanNo.SelectedValue = "-99";
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
                    int num = Convert.ToInt32(this.drpParty.SelectedValue);
                    DataTable item = (DataTable)this.Session["PARTY_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("party_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.ltAddress.Text = dataRow["party_address"].ToString();
                        this.lblBIN.Text = dataRow["party_bin"].ToString();
                    }
                    DataTable mainChallanForDebitNote = craDebBLL.getMainChallanForDebitNote(num);
                    this.rbLocalPurchase.Checked = false;
                    this.rbImport.Checked = false;
                    this.drpMainChallanNo.Items.Clear();
                    this.drpMainChallanNo.SelectedValue = "-99";
                    this.Session["CHALLAN_INFO"] = mainChallanForDebitNote;
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

        protected void drpProperty1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPropertyWiseAvailStock();
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
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            this.txtUnitName.Text = allFieldByItemId.Rows[0]["unit_code"].ToString();
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
                string str3 = string.Concat("select note_id,note_no from trns_note_master where note_type = 'D' ", str, " order by  note_no desc limit 1");
                DataTable dataTable = dBUtility.GetDataTable(str3);
                str2 = dataTable.Rows[0]["note_no"].ToString();
                this.txtDebitNot.Text = str2;
                num = Convert.ToInt32(dataTable.Rows[0]["note_id"].ToString());
                this.debitNoteId.Text = num.ToString();
                string str4 = string.Concat("select tsm.challan_no, tsm.challan_id from trns_sale_master tsm inner join trns_note_detail tnd on tsm.challan_id = tnd.challan_id\r\n                            inner join trns_note_master tnm on tnm.note_id = tnd.note_id where tnm.note_type = 'D' AND tnm.note_no = '", str2, "' ", str1);
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
                int num1 = Convert.ToInt32(this.debitNoteId.Text);
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
                DataTable saleAvailableStockN = saleBLL.GetSaleAvailableStockN(itemID, itemType, standardDateFromDdMMyyyy, itemType);
                this.lblQuantity.Text = saleAvailableStockN.Rows[0]["availStock"].ToString();
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
            this.GetBranchAddress();
        }

        private void getDebitNoteNo()
        {
            int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            short num1 = Convert.ToInt16(this.drpBranchName.SelectedValue);
            DataTable debitNoteNo = this.objDCBLL.GetDebitNoteNo(1, num, num1);
            if (debitNoteNo == null || debitNoteNo.Rows.Count <= 0)
            {
                this.txtDebitNot.Text = "";
                this.hdBookId.Value = "";
                this.hdPageNo.Value = "";
                return;
            }
            this.txtDebitNot.Text = debitNoteNo.Rows[0]["challan_no"].ToString();
            this.hdBookId.Value = debitNoteNo.Rows[0]["challan_book_id"].ToString();
            this.hdPageNo.Value = debitNoteNo.Rows[0]["page_no"].ToString();
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
                this.fillCatSubCat(num);
                DataTable allVatByItemId = craDebBLL.getAllVatByItemId(num);
                if (allVatByItemId != null && allVatByItemId.Rows.Count > 0)
                {
                    this.lblVat.Text = allVatByItemId.Rows[0]["VAT"].ToString();
                    this.lblSD.Text = allVatByItemId.Rows[0]["SD"].ToString();
                }
            }
            else
            {
                if (this.drpItem.SelectedValue != "-99")
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
                        str2 = "R";
                    }
                    str = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays = str.Split(new char[] { '.' });
                    num = Convert.ToInt16(strArrays[0]);
                }
                string str3 = this.drpMainChallanNo.SelectedItem.ToString();
                Convert.ToInt32(this.drpMainChallanNo.SelectedValue);
                DataTable purchaseUnitByItemId = craDebBLL.getPurchaseUnitByItemId(num, str3, str2);
                this.txtUnitName.Text = purchaseUnitByItemId.Rows[0]["unit_code"].ToString();
                this.lblUnitId.Text = purchaseUnitByItemId.Rows[0]["unit_id"].ToString();
                this.lblProp1.Text = purchaseUnitByItemId.Rows[0]["property_id1"].ToString();
                this.lblProp2.Text = purchaseUnitByItemId.Rows[0]["property_id2"].ToString();
                this.lblProp3.Text = purchaseUnitByItemId.Rows[0]["property_id3"].ToString();
                this.lblProp4.Text = purchaseUnitByItemId.Rows[0]["property_id4"].ToString();
                this.lblProp5.Text = purchaseUnitByItemId.Rows[0]["property_id5"].ToString();
                if (purchaseUnitByItemId.Rows[0]["is_rebatable"].ToString() != "True")
                {
                    this.chkRebatable.Checked = false;
                    this.chkRebatable.Attributes["style"] = "color:black;";
                }
                else
                {
                    this.chkRebatable.Checked = true;
                    this.chkRebatable.Attributes["style"] = "color:Green;";
                }
                this.itemProduct.Text = str2;
                this.txtUnitPrice.Text = purchaseUnitByItemId.Rows[0]["purchase_unit_price"].ToString();
                this.hdTotalVat.Text = purchaseUnitByItemId.Rows[0]["purchase_vat"].ToString();
                this.hdTotalSD.Text = purchaseUnitByItemId.Rows[0]["purchase_sd"].ToString();
                if (purchaseUnitByItemId.Rows[0]["item_type"].ToString() != "S")
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
                string str4 = "";
                str4 = (!this.rbLocalPurchase.Checked ? "I" : "L");
                DataTable vatTaxForDebit = craDebBLL.GetVatTaxForDebit(num, str4);
                string empty = string.Empty;
                if (vatTaxForDebit == null)
                {
                    this.lblVat.Text = "0.00";
                    this.lblSD.Text = "0.00";
                    return;
                }
                if (vatTaxForDebit.Rows.Count <= 0)
                {
                    this.lblVat.Text = "0.00";
                    this.lblSD.Text = "0.00";
                    return;
                }
                empty = vatTaxForDebit.Rows[0]["PER"].ToString();
                this.lblfxdVT.Text = "Tk. ";
                this.lblVat.Text = vatTaxForDebit.Rows[0]["VAT"].ToString();
                this.lblSD.Text = vatTaxForDebit.Rows[0]["SD"].ToString();
                if (empty == "1")
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

        private void GetNextChallanNo()
        {
            DataTable usedChallanNo = (new ChallanBLL()).GetUsedChallanNo(3);
            if (usedChallanNo == null || usedChallanNo.Rows.Count <= 0)
            {
                ListItem listItem = new ListItem("---Select---", "-99");
                this.drpMainChallanNo.Items.Insert(0, listItem);
                return;
            }
            this.drpMainChallanNo.DataSource = usedChallanNo;
            this.drpMainChallanNo.DataTextField = usedChallanNo.Columns["challan_no"].ToString();
            this.drpMainChallanNo.DataValueField = usedChallanNo.Columns["challan_book_id"].ToString();
            this.drpMainChallanNo.DataValueField = usedChallanNo.Columns["page_no"].ToString();
            this.drpMainChallanNo.DataBind();
            ListItem listItem1 = new ListItem("---Select---", "-99");
            this.drpMainChallanNo.Items.Insert(0, listItem1);
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
                    long debitQtyPropertyWise = craDebBLL.GetDebitQtyPropertyWise(num6, num5, str1, num, num1, num2, num3, num4);
                    label.Text = debitQtyPropertyWise.ToString();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
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
            if (this.lblQuantity.Text != "" && Convert.ToDecimal(this.lblQuantity.Text) <= new decimal(0))
            {
                this.msgBox.AddMessage("Inapropriate available quantity", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (Convert.ToDecimal(this.lblQuantity.Text) < Convert.ToDecimal(this.txtQuantity.Text))
            {
                this.msgBox.AddMessage(" Quantity is not available", MsgBoxs.enmMessageType.Attention);
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
                ArrayList item = (ArrayList)this.Session["DEBIT_NOTE_DETAIL"];
                item.RemoveAt(e.RowIndex);
                this.Session["DEBIT_NOTE_DETAIL"] = item;
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
                currentAccountBLL.InsertBalance(Convert.ToInt32(str), Convert.ToDecimal(str1), Convert.ToDecimal(str2), Convert.ToInt32(str3), now);
                this.Session["VAT_LAST_AMOUNT"] = null;
                this.Session["SD_LAST_AMOUNT"] = null;
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "DebittNote_6.8", "insertBalance");
            }
        }

        private void loadDetailData()
        {
            string str = "";
            ArrayList item = (ArrayList)this.Session["DEBIT_NOTE_DETAIL"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO()
            {
                RowNo = num,
                Category = this.drpCategory.SelectedItem.ToString(),
                SubCategory = this.drpSubCategory.SelectedItem.ToString(),
                Item = this.drpItem.SelectedItem.ToString()
            };
            str = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str.Split(new char[] { '.' });
            debitNoteDetailDAO.Item_id = Convert.ToInt16(strArrays[0]);
            debitNoteDetailDAO.TypeP = this.itemProduct.Text;
            debitNoteDetailDAO.Unit = this.txtUnitName.Text.ToString();
            debitNoteDetailDAO.UnitId = Convert.ToInt16(this.lblUnitId.Text.ToString());
            debitNoteDetailDAO.DebQuantity = Convert.ToDecimal(this.txtQuantity.Text);
            debitNoteDetailDAO.UnitPrice = Convert.ToDouble(this.txtUnitPrice.Text.ToString());
            debitNoteDetailDAO.Vat = Convert.ToDouble(this.txtVAT.Text.ToString());
            debitNoteDetailDAO.Sd = Convert.ToDouble(this.txtSD.Text.ToString());
            debitNoteDetailDAO.GUnitPrice = Convert.ToDouble(this.txtTotalUnitPrice.Text.ToString());
            debitNoteDetailDAO.GTotalPrice = Convert.ToDouble(this.txtAmount.Text.ToString());
            debitNoteDetailDAO.PreviousAmount = (!string.IsNullOrEmpty(this.txtPreviousAmount.Text) ? Convert.ToDouble(this.txtPreviousAmount.Text.ToString()) : 0);
            debitNoteDetailDAO.TotalPricewithVat = Convert.ToDouble(this.txtTotalPricewithVat.Text.ToString());
            debitNoteDetailDAO.TotalTax = Convert.ToDouble(this.txtTotalTax.Text.ToString());
            debitNoteDetailDAO.ReasonOfReturn = this.txtReasonofReturn.Text.ToString();
            debitNoteDetailDAO.isRebatable = this.chkRebatable.Checked;
            if (!(this.drpProperty1.SelectedValue != "-99") || !(this.drpProperty1.SelectedValue != ""))
            {
                debitNoteDetailDAO.Property1 = 0;
            }
            else
            {
                debitNoteDetailDAO.Property1 = Convert.ToInt32(this.drpProperty1.SelectedValue);
                debitNoteDetailDAO.Property1_Text = this.drpProperty1.SelectedItem.ToString();
            }
            if (!(this.drpProperty2.SelectedValue != "-99") || !(this.drpProperty2.SelectedValue != ""))
            {
                debitNoteDetailDAO.Property2 = 0;
            }
            else
            {
                debitNoteDetailDAO.Property2 = Convert.ToInt32(this.drpProperty2.SelectedValue);
                debitNoteDetailDAO.Property2_Text = this.drpProperty2.SelectedItem.ToString();
            }
            if (!(this.drpProperty3.SelectedValue != "-99") || !(this.drpProperty3.SelectedValue != ""))
            {
                debitNoteDetailDAO.Property3 = 0;
            }
            else
            {
                debitNoteDetailDAO.Property3 = Convert.ToInt32(this.drpProperty3.SelectedValue);
                debitNoteDetailDAO.Property3_Text = this.drpProperty3.SelectedItem.ToString();
            }
            if (!(this.drpProperty4.SelectedValue != "-99") || !(this.drpProperty4.SelectedValue != ""))
            {
                debitNoteDetailDAO.Property4 = 0;
            }
            else
            {
                debitNoteDetailDAO.Property4 = Convert.ToInt32(this.drpProperty4.SelectedValue);
                debitNoteDetailDAO.Property4_Text = this.drpProperty4.SelectedItem.ToString();
            }
            if (!(this.drpProperty5.SelectedValue != "-99") || !(this.drpProperty5.SelectedValue != ""))
            {
                debitNoteDetailDAO.Property5 = 0;
            }
            else
            {
                debitNoteDetailDAO.Property5 = Convert.ToInt32(this.drpProperty5.SelectedValue);
                debitNoteDetailDAO.Property5_Text = this.drpProperty5.SelectedItem.ToString();
            }
            debitNoteDetailDAO.Challan_id = Convert.ToInt32(this.drpMainChallanNo.SelectedValue);
            debitNoteDetailDAO.HdVat = Convert.ToDouble(this.hdTotalVat.Text.ToString());
            debitNoteDetailDAO.HdSD = Convert.ToDouble(this.hdTotalSD.Text.ToString());
            if (this.drpType.SelectedIndex == 0)
            {
                debitNoteDetailDAO.Type = 'G';
            }
            else if (this.drpType.SelectedIndex != 1)
            {
                debitNoteDetailDAO.Type = 'o';
            }
            else
            {
                debitNoteDetailDAO.Type = 'S';
            }
            debitNoteDetailDAO.DecreaseId = Convert.ToInt16(this.drpDecreaseType.SelectedValue);
            if (this.rbLocalPurchase.Checked || this.rbImport.Checked)
            {
                debitNoteDetailDAO.Status = 'P';
                debitNoteDetailDAO.Sp_Return = 1;
            }
            else
            {
                debitNoteDetailDAO.Status = 'S';
                debitNoteDetailDAO.Sp_Return = 2;
            }
            debitNoteDetailDAO.UserId = Convert.ToInt16(this.Session["employee_id"].ToString());
            item.Add(debitNoteDetailDAO);
            this.Session["DEBIT_NOTE_DETAIL"] = item;
        }

        private void loadGridView()
        {
            this.gvItem.DataSource = this.Session["DEBIT_NOTE_DETAIL"];
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

        private DebitNoteMasterDAO loadMasterData(DebitNoteMasterDAO objCNM)
        {
            string str;
            try
            {
                int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                objCNM.BranchID = num;
                objCNM.RecipientName = this.lblOrgName.Text.ToString();
                objCNM.RecipientBin = this.lblOrgBIN.Text.ToString();
                objCNM.RecipientAddress = this.lblOrgAddress.Text.ToString();
                try
                {
                    DateTime dateTime = DateTime.ParseExact(this.txtRecipientDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objCNM.RecipientDate = dateTime.ToString("dd/MM/yyyy");
                }
                catch (Exception exception)
                {
                     BLL.Utility.InsertErrorTrack(exception.Message, "rdate", "RecipientDate");
                }
                objCNM.RecipientTime = string.Concat(this.drpRecipientHr.SelectedItem.ToString(), ":", this.drpRecipientMin.SelectedItem.ToString());
                objCNM.ProviderName = this.drpParty.SelectedItem.ToString();
                objCNM.ProviderAddress = this.ltAddress.Text.ToString();
                objCNM.ProviderBin = (!string.IsNullOrEmpty(this.lblBIN.Text) ? this.lblBIN.Text.ToString() : "NA");
                this.getDebitNoteNo();
                objCNM.CreditNotNumber = this.txtDebitNot.Text.ToString();
                objCNM.ChallanBookId = Convert.ToInt16(this.hdBookId.Value.ToString());
                objCNM.ChallanPageNumber = Convert.ToInt16(this.hdPageNo.Value.ToString());
                try
                {
                    DateTime dateTime1 = DateTime.ParseExact(this.txtProviderDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    objCNM.ProviderDate = dateTime1.ToString("dd/MM/yyyy");
                }
                catch (Exception exception1)
                {
                     BLL.Utility.InsertErrorTrack(exception1.Message, "pdate", "RecipientDate");
                }
                this.getDebitNoteNo();
                objCNM.MainChallanNo = this.drpMainChallanNo.SelectedItem.ToString();
                objCNM.OrgId = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
                try
                {
                    objCNM.DateNote = DateTime.Now.Date;
                }
                catch (Exception exception2)
                {
                     BLL.Utility.InsertErrorTrack(exception2.Message, "DateNote", "loadMasterData");
                }
                objCNM.NoteYear = DateTime.Now.Year;
                if (!this.chkDiscard.Checked)
                {
                    objCNM.NoteType = 'D';
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
                string[] strArrays = new string[] { this.txtRecipientDate.Text.Trim(), " ", this.drpRecipientHr.SelectedItem.Text, ":", this.drpRecipientMin.SelectedItem.Text };
                objCNM.ChallanDate = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                objCNM.VehicalType = null;
                objCNM.VehicleTypeM = 7;
                objCNM.VehicleTypeD = (this.drpVehicleType.SelectedValue != "-99" ? (int)Convert.ToInt16(this.drpVehicleType.SelectedValue) : 0);
                DebitNoteMasterDAO debitNoteMasterDAO = objCNM;
                if (this.txtVehicleNo.Text.Trim() != "")
                {
                    str = this.txtVehicleNo.Text.Trim();
                }
                else
                {
                    str = null;
                }
                debitNoteMasterDAO.VehicleNo = str;
                objCNM.MaterialType = "D";
                objCNM.ItemType = (this.itemProduct.Text.Trim() != "" ? this.itemProduct.Text.Trim() : "L");
                objCNM.UserId = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                this.Session["DEBIT_MASTER_DATA"] = objCNM;
                this.Session["NOTE_NO"] = objCNM.CreditNotNumber;
            }
            catch (Exception exception3)
            {
                 BLL.Utility.InsertErrorTrack(exception3.Message, "DebitNote_6.8.aspx", "loadMasterData");
            }
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
            DebitNoteDetailDAO debitNoteDetailDAO = new DebitNoteDetailDAO();
            ArrayList item = (ArrayList)this.Session["DEBIT_NOTE_DETAIL"];
            DataTable dataTable = new DataTable();
            string str = Convert.ToString(this.Session["NOTE_NO"]);
            if (item != null)
            {
                dataTable = craDebBLL.GetDebitNoteDataForReport(str, item);
            }
            if (dataTable.Rows.Count > 0)
            {
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["EMPLOYEE_NAME"].ToString();
                this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                this.Challan_No.Text = dataTable.Rows[0]["note_no"].ToString();
                this.Challan_Date.Text = dataTable.Rows[0]["note_date"].ToString();
                this.Challan_Time.Text = dataTable.Rows[0]["issue_Time"].ToString();
                string str1 = "";
                this.provider_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.provider_BIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.receiver_name.Text = (dataTable.Rows[0]["party_name"].ToString() != "" ? dataTable.Rows[0]["party_name"].ToString() : "N/A");
                this.receiver_BIN.Text = (dataTable.Rows[0]["party_bin"].ToString() != "" ? dataTable.Rows[0]["party_bin"].ToString() : "N/A");
                this.provider_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.receiver_address.Text = (dataTable.Rows[0]["party_address"].ToString() != "" ? dataTable.Rows[0]["party_address"].ToString() : "N/A");
                if (dataTable.Rows[0]["vehicle_no"].ToString() == "")
                {
                    this.txtTransport.Text = string.Concat(dataTable.Rows[0]["code_name"].ToString(), " ", dataTable.Rows[0]["vehicle_no"].ToString());
                }
                else
                {
                    this.txtTransport.Text = string.Concat(dataTable.Rows[0]["code_name"].ToString(), ", ", dataTable.Rows[0]["vehicle_no"].ToString());
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    decimal num = Convert.ToDecimal(dataTable.Rows[i]["quantity"]);
                    string str2 = Utilities.formatFraction(num);
                    str1 = string.Concat(str1, "<tr>");
                    object obj = str1;
                    object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                    str1 = string.Concat(objArray);
                    string str3 = str1;
                    string[] strArrays = new string[] { str3, "<td>", dataTable.Rows[i]["purchase_challan_no"].ToString(), ", ", dataTable.Rows[i]["purchase_challan_date"].ToString(), "</td>" };
                    str1 = string.Concat(strArrays);
                    str1 = string.Concat(str1, "<td>", dataTable.Rows[i]["return_reason"].ToString(), "</td>");
                    if (Convert.ToDecimal(dataTable.Rows[i]["purchase_price"]) != new decimal(0))
                    {
                        decimal num1 = Convert.ToDecimal(dataTable.Rows[i]["purchase_price"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num1.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["purchase_quantity"]) != new decimal(0))
                    {
                        string str4 = str1;
                        string[] strArrays1 = new string[] { str4, "<td style='text-align:right;padding:3px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["purchase_quantity"])), "  ", dataTable.Rows[i]["unit_name"].ToString(), "</td>" };
                        str1 = string.Concat(strArrays1);
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["purchase_vat"]) != new decimal(0))
                    {
                        decimal num2 = Convert.ToDecimal(dataTable.Rows[i]["purchase_vat"]);
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>", num2.ToString("N2"), "</td>");
                    }
                    else
                    {
                        str1 = string.Concat(str1, "<td style='text-align:right;padding:3px'>-</td>");
                    }
                    if (Convert.ToDecimal(dataTable.Rows[i]["purchase_sd"]) != new decimal(0))
                    {
                        decimal num3 = Convert.ToDecimal(dataTable.Rows[i]["purchase_sd"]);
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
                        string[] strArrays2 = new string[] { str5, "<td style='text-align:right;padding:3px'>", str2, "  ", dataTable.Rows[i]["unit_name"].ToString(), "</td>" };
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

        private void masterClear()
        {
            this.drpParty.SelectedValue = "-99";
            this.ltAddress.Text = "";
            this.lblBIN.Text = "";
            this.txtDebitNot.Text = "";
            this.lblDiscardReason.Visible = false;
            this.drpDiscardReason.SelectedValue = "-99";
            this.drpMainChallanNo.SelectedValue = "-99";
            this.drpVehicleType.SelectedValue = "-99";
            this.txtVehicleNo.Text = "";
        }

        private bool masterValidation()
        {
            if (this.drpParty.SelectedValue == "-99")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Select a Company Name');", true);
                return false;
            }
            if (this.drpMainChallanNo.SelectedValue == "-99")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Select a Challan Number');", true);
                return false;
            }
            if (this.txtDebitNot.Text != "")
            {
                return true;
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Write your Debit note Number');", true);
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            try
            {
                if (!base.IsPostBack)
                {
                    this.Session["chkProperty"] = new Dictionary<int, int>();
                    this.Session["PARTY_INFO"] = new DataTable();
                    this.Session["CHALLAN_INFO"] = new DataTable();
                    this.Session["DEBIT_NOTE_DETAIL"] = new ArrayList();
                    this.lblOrgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.loadPertyInfo();
                    UtilityK.fillVehicleTypeDropDownList(this.drpVehicleType);
                    ListItem listItem = new ListItem("-- SELECT --", "-99");
                    this.drpVehicleType.Items.Insert(0, listItem);
                    ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                    this.drpCategory.Items.Insert(0, listItem1);
                    this.drpSubCategory.Items.Insert(0, listItem1);
                    ListItem listItem2 = new ListItem("-- SELECT --", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                    this.LoadHours();
                    this.LoadMinutes();
                    this.FillDecreaseType();
                    this.txtRecipientDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    this.txtProviderDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    this.drpRecipientHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpRecipientMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                    this.drpProviderHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpProviderMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                    UtilityK.fillChallanDiscardReasonList(this.drpDiscardReason);
                    ListItem listItem3 = new ListItem("-- SELECT --", "-99");
                    this.drpDiscardReason.Items.Insert(0, listItem3);
                    this.drpMainChallanNo.Items.Insert(0, listItem3);
                    this.GetBranchInformation();
                    this.getDebitNoteNo();
                    DebitNoteMasterDAO debitNoteMasterDAO = new DebitNoteMasterDAO();
                    this.Session["DEBIT_MASTER_DATA"] = debitNoteMasterDAO;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void PrevAmount_textChanged(object sender, EventArgs e)
        {
        }

        protected void productName_TextChanged(object sender, EventArgs e)
        {
        }

        protected void rbPurchase_OnCheckedChanged(object sender, EventArgs e)
        {
            if (this.drpParty.SelectedValue != "-99")
            {
                int num = Convert.ToInt32(this.drpParty.SelectedValue);
                string str = "";
                CraDebBLL craDebBLL = new CraDebBLL();
                try
                {
                    if (this.rbLocalPurchase.Checked)
                    {
                        str = "L";
                    }
                    if (this.rbImport.Checked)
                    {
                        str = "I";
                    }
                    DataTable dataTable = craDebBLL.loadPurchaseChallan(num, str);
                    this.drpMainChallanNo.DataSource = dataTable;
                    this.drpMainChallanNo.DataTextField = dataTable.Columns["challan_no"].ToString();
                    this.drpMainChallanNo.DataValueField = dataTable.Columns["challan_id"].ToString();
                    this.drpMainChallanNo.DataBind();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpMainChallanNo.Items.Insert(0, listItem);
                    this.Session["PURCHASE_CHALLAN"] = dataTable;
                }
                catch (Exception exception)
                {
                    ReallySimpleLog.WriteLog(exception);
                }
            }
            else if (this.drpParty.SelectedValue == "-99")
            {
                int num1 = Convert.ToInt32(this.drpBranchName.SelectedValue);
                string str1 = "";
                CraDebBLL craDebBLL1 = new CraDebBLL();
                try
                {
                    if (this.rbLocalPurchase.Checked)
                    {
                        str1 = "L";
                    }
                    if (this.rbImport.Checked)
                    {
                        str1 = "I";
                    }
                    DataTable dataTable1 = craDebBLL1.loadPurchaseChallan(num1, str1);
                    this.drpMainChallanNo.DataSource = dataTable1;
                    this.drpMainChallanNo.DataTextField = dataTable1.Columns["challan_no"].ToString();
                    this.drpMainChallanNo.DataValueField = dataTable1.Columns["challan_id"].ToString();
                    this.drpMainChallanNo.DataBind();
                    ListItem listItem1 = new ListItem("---Select---", "-99");
                    this.drpMainChallanNo.Items.Insert(0, listItem1);
                    this.Session["PURCHASE_CHALLAN"] = dataTable1;
                }
                catch (Exception exception1)
                {
                    ReallySimpleLog.WriteLog(exception1);
                }
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
                 BLL.Utility.InsertErrorTrack(exception.Message, "DebittNote_6.8", "SDLastUpdatedBalance");
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
            string str1 = "";
            int num = 0;
            string str2 = "";
            str2 = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str2.Split(new char[] { '.' });
            num = Convert.ToInt16(strArrays[0]);
            AddItemBLL addItemBLL = new AddItemBLL();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            num3 = Convert.ToInt32(this.drpMainChallanNo.SelectedValue);
            DataTable dataTable = this.objPDBll.geAdditionalPropertybySearch(str.ToUpper(), num, str1, num1, num2, num3);
            if (dataTable.Rows.Count <= 0)
            {
                this.displayTotalRecordsFound();
            }
            else
            {
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
                this.displayTotalRecordsFound();
                Dictionary<int, int> item = (Dictionary<int, int>)this.Session["chkProperty"];
                if (item.Count > 0 && str == "")
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





        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
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

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPreviousAmount.Text != "" || this.txtPreviousAmount.Text != "0")
                {
                    this.GetItemDetails();
                    this.calculatePrice();
                    this.CalculateAfterBadkorton();
                }
                else
                {
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



    

        private bool validation()
        {
            if (this.drpParty.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select party name", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtDebitNot.Text == null || this.txtDebitNot.Text == "")
            {
                this.msgBox.AddMessage("Debit number is not available", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpMainChallanNo.SelectedValue != "-99")
            {
                return true;
            }
            this.msgBox.AddMessage("Select Your Challan Number.", MsgBoxs.enmMessageType.Attention);
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
                 BLL.Utility.InsertErrorTrack(exception.Message, "DebittNote_6.8", "VATLastUpdatedBalance");
            }
        }
    }
}