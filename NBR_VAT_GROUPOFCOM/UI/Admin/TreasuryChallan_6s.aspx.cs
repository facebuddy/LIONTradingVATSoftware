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
using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.UserControls;
using NBR_VAT_GROUPOFCOM.BLL;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class TreasuryChallan_6s : Page, IRequiresSessionState
    {

        private trnsTreasuryChallanBLL objtrnsTreasuryChallanBLL = new trnsTreasuryChallanBLL();

        // Token: 0x040000C5 RID: 197
        private trnsTreasuryChallanDAO objTrnsTreasuryChallanDAO = new trnsTreasuryChallanDAO();

        // Token: 0x040000C6 RID: 198
        private trnsNoteMasterBLL objtrnsNoteMasterBLL = new trnsNoteMasterBLL();
        // Token: 0x040000C4 RID: 196
   

        // Token: 0x040000C7 RID: 199
        private decimal total;

        // Token: 0x040000C8 RID: 200
        private decimal amount;

        // Token: 0x040000C9 RID: 201
        private decimal amountf;

        // Token: 0x040000CA RID: 202
        private DataTable dtTCHgrid = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.Session["TRStatus"] = new Dictionary<int, bool>();
                this.Session["chkVDS"] = new Dictionary<int, trnsTreasuryChallanDAODetail>();
                this.Session["dtTCHInSession"] = new ArrayList();
                this.Session["dtTCHInSessionTd"] = new ArrayList();
                Util.fillBank(this.drpBankName);
                Util.fillInstrumentType(this.drpInstrumentType);
                Util.fillChallanTypeWithOrderBy(this.drpChallanType);
                Util.fillOrgName(this.drpOrgName);
                int orgId = (int)Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
                DataTable orgById = this.objtrnsNoteMasterBLL.getOrgById(orgId);
                if (orgById.Rows.Count > 0)
                {
                    this.txtAddress1.Text = ((orgById.Rows[0]["registered_hq_address"] != null) ? orgById.Rows[0]["registered_hq_address"].ToString() : "N/A");
                }
                this.LoadKorMeyad();
                this.LoadHours();
                this.LoadMinutes();
                this.GetPartyInfo();
                this.dtpUnloadRealDate2.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.txtFormDate.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.ShowChallanGridView();
            }
        }

        // Token: 0x0600009D RID: 157 RVA: 0x000084F4 File Offset: 0x000066F4
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                new ArrayList();
                Dictionary<int, bool> isTR = (Dictionary<int, bool>)this.Session["TRStatus"];
                ArrayList arrayList = new ArrayList();
                arrayList = (ArrayList)this.Session["dtTCHInSession"];
                ArrayList arrDetailDAOTd = new ArrayList();
                arrDetailDAOTd = (ArrayList)this.Session["dtTCHInSessionTd"];
                if (arrayList == null || arrayList.Count == 0)
                {

                    this.dgvTreasuryDeposit.DataSource = null;
                    this.dgvTreasuryDeposit.DataBind();
                    this.msgBox.AddMessage("Please Add Item First.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    string isPayment = "";
                    if (this.btnSave.Text == "Save")
                    {
                        if (this.drpRdbSelection.SelectedValue == "1")
                        {
                            if (this.radio_vat_9_1.Checked)
                            {
                                bool flag = this.objtrnsTreasuryChallanBLL.InsertTreasuryChallanDataForPurchase(arrayList, isPayment, arrDetailDAOTd, isTR);
                                if (flag)
                                {
                                    this.showTRChallanFormGV();
                                 //   this.msgBox.AddMessage("Treasury Challan Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);


                                      string msg = "Treasury Challan Infomation Successfully Saved.";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + msg + "')", true);

                                    this.clearFrom();
                                    this.RefreshGridView();
                                    this.dgvTreasuryDeposit.Visible = false;
                                    this.ShowChallanGridViewForVatReturnReport();
                                    this.txtAmount.Text = string.Empty;
                                    this.VATLastUpdatedBalance();
                                    this.SDLastUpdatedBalance();
                                    this.insertBalance();
                                    this.ShowChallanGridView();
                                    this.radio_challan_list.Checked = true;
                                    this.radio_non_challan.Checked = false;
                                    this.radio_vat_9_1.Checked = false;
                                    this.radio_VAT_AIT.Checked = false;
                                    this.Session["chkVDS"] = new ArrayList();
                                }
                                else
                                {
                                    this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                                }
                            }
                            else if (this.radio_non_challan.Checked)
                            {
                                bool flag2 = this.objtrnsTreasuryChallanBLL.InsertTreasuryChallanDataForNote(arrayList, arrDetailDAOTd);
                                if (flag2)
                                {
                                    this.showTRChallanFormGV();
                                    //  this.msgBox.AddMessage("Treasury Challan Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                    string msg = "Treasury Challan Infomation Successfully Saved.";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + msg + "')", true);
                                    this.clearFrom();
                                    this.RefreshGridView();
                                    this.dgvTreasuryDeposit.Visible = false;
                                    this.ShowChallanGridViewForVatReturnReport();
                                    this.txtAmount.Text = string.Empty;
                                    this.VATLastUpdatedBalance();
                                    this.SDLastUpdatedBalance();
                                    this.insertBalance();
                                    this.ShowChallanGridView();
                                    this.radio_challan_list.Checked = true;
                                    this.radio_non_challan.Checked = false;
                                    this.radio_vat_9_1.Checked = false;
                                    this.radio_VAT_AIT.Checked = false;
                                    this.Session["chkVDS"] = new ArrayList();
                                }
                                else
                                {
                                    this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                                }
                            }
                            else if (this.radio_VAT_AIT.Checked)
                            {
                                bool flag3 = this.objtrnsTreasuryChallanBLL.InsertTreasuryChallanDataForPurchase(arrayList, isPayment, arrDetailDAOTd, isTR);
                                if (flag3)
                                {
                                    this.showTRChallanFormGV();
                                    // this.msgBox.AddMessage("Treasury Challan Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                    string msg = "Treasury Challan Infomation Successfully Saved.";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + msg + "')", true);
                                    this.clearFrom();
                                    this.RefreshGridView();
                                    this.dgvTreasuryDeposit.Visible = false;
                                    this.ShowChallanGridViewForVatReturnReport();
                                    this.txtAmount.Text = string.Empty;
                                    this.VATLastUpdatedBalance();
                                    this.SDLastUpdatedBalance();
                                    this.insertBalance();
                                    this.ShowChallanGridView();
                                    this.radio_challan_list.Checked = true;
                                    this.radio_non_challan.Checked = false;
                                    this.radio_vat_9_1.Checked = false;
                                    this.radio_VAT_AIT.Checked = false;
                                    this.Session["chkVDS"] = new ArrayList();
                                }
                                else
                                {
                                    this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                                }
                            }
                            else
                            {
                                bool flag4 = this.objtrnsTreasuryChallanBLL.InsertTreasuryChallanDataTR(arrayList, arrDetailDAOTd);
                                if (flag4)
                                {
                                    this.showTRChallanFormGV();
                                    // this.msgBox.AddMessage("Treasury Challan Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                    string msg = "Treasury Challan Infomation Successfully Saved.";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + msg + "')", true);
                                    this.clearFrom();
                                    this.RefreshGridView();
                                    this.dgvTreasuryDeposit.Visible = false;
                                    this.VATLastUpdatedBalance();
                                    this.SDLastUpdatedBalance();
                                    this.insertBalance();
                                    this.ShowChallanGridView();
                                    this.radio_challan_list.Checked = true;
                                    this.radio_non_challan.Checked = false;
                                    this.radio_vat_9_1.Checked = false;
                                    this.radio_VAT_AIT.Checked = false;
                                    this.Session["chkVDS"] = new ArrayList();
                                }
                                else
                                {
                                    this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                                }
                            }
                        }
                        if (this.drpRdbSelection.SelectedValue == "2" && this.radio_challan_list.Checked)
                        {
                            bool flag5 = this.objtrnsTreasuryChallanBLL.InsertTreasuryChallanDataForSD(arrayList, arrDetailDAOTd);
                            if (flag5)
                            {
                                this.showTRChallanFormGV();
                                // this.msgBox.AddMessage("Treasury Challan Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                string msg = "Treasury Challan Infomation Successfully Saved.";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + msg + "')", true);
                                this.clearFrom();
                                this.RefreshGridView();
                                this.dgvTreasuryDeposit.Visible = false;
                                this.VATLastUpdatedBalance();
                                this.SDLastUpdatedBalance();
                                this.insertBalance();
                                this.ShowChallanGridView();
                                this.radio_challan_list.Checked = true;
                                this.radio_non_challan.Checked = false;
                                this.radio_vat_9_1.Checked = false;
                                this.Session["chkVDS"] = new ArrayList();
                            }
                            else
                            {
                                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                        }
                        if (this.drpRdbSelection.SelectedValue == "4" && this.radio_challan_list.Checked)
                        {
                            bool flag6 = this.objtrnsTreasuryChallanBLL.InsertTreasuryChallanDataForHealthCharge(arrayList, arrDetailDAOTd);
                            if (flag6)
                            {
                                this.showTRChallanFormGV();
                                // this.msgBox.AddMessage("Treasury Challan Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                string msg = "Treasury Challan Infomation Successfully Saved.";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + msg + "')", true);
                                this.clearFrom();
                                this.RefreshGridView();
                                this.dgvTreasuryDeposit.Visible = false;
                                this.VATLastUpdatedBalance();
                                this.SDLastUpdatedBalance();
                                this.insertBalance();
                                this.ShowChallanGridView();
                                this.radio_challan_list.Checked = true;
                                this.radio_non_challan.Checked = false;
                                this.radio_vat_9_1.Checked = false;
                                this.Session["chkVDS"] = new ArrayList();
                            }
                            else
                            {
                                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                        }
                        if (this.drpRdbSelection.SelectedValue == "3")
                        {
                            for (int i = 0; i < this.gridAIT.Rows.Count; i++)
                            {
                                CheckBox checkBox = (CheckBox)this.gridAIT.Rows[i].FindControl("chkChallan");
                                if (checkBox.Checked)
                                {
                                    int challanId = Convert.ToInt32(this.gridAIT.Rows[i].Cells[3].Text);
                                    DataTable paymentFinish = this.objtrnsTreasuryChallanBLL.getPaymentFinish(challanId);
                                    if (paymentFinish.Rows.Count > 0)
                                    {
                                        isPayment = paymentFinish.Rows[0]["is_payment_finished"].ToString();
                                    }
                                }
                            }
                            bool flag7 = this.objtrnsTreasuryChallanBLL.InsertTreasuryChallanDataForPurchaseAIT(arrayList, isPayment, arrDetailDAOTd);
                            if (flag7)
                            {
                                this.showTRChallanFormGV();
                                // this.msgBox.AddMessage("Treasury Challan Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                string msg = "Treasury Challan Infomation Successfully Saved.";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "successalert('" + msg + "')", true);
                                this.clearFrom();
                                this.RefreshGridView();
                                this.dgvTreasuryDeposit.Visible = false;
                                this.ShowChallanGridViewForVatReturnReport();
                                this.txtAmount.Text = string.Empty;
                                this.VATLastUpdatedBalance();
                                this.SDLastUpdatedBalance();
                                this.insertBalance();
                                this.ShowChallanGridView();
                                this.radio_challan_list.Checked = true;
                                this.radio_non_challan.Checked = false;
                                this.radio_vat_9_1.Checked = false;
                                this.radio_VAT_AIT.Checked = false;
                                this.drpRdbSelection.SelectedValue = "1";
                                this.Session["chkVDS"] = new ArrayList();
                            }
                            else
                            {
                                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               BLL.Utility.InsertErrorTrack(ex.Message, "TreasuryChallan_6", "btnSave_Click");
            }
        }

        // Token: 0x0600009E RID: 158 RVA: 0x00008CB4 File Offset: 0x00006EB4
        protected void btnTRInsert_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/UI/Others/TreasuryDeposit.aspx");
        }


        private void LoadAnnexureGrid(int challanId)
        {
            try
            {
                this.grdAnnexere.DataSource = null;
                DataTable tRChallanInfoForAnnexure = this.objtrnsTreasuryChallanBLL.getTRChallanInfoForAnnexure(challanId);
                if (tRChallanInfoForAnnexure.Rows.Count > 0)
                {
                    this.grdAnnexere.DataSource = tRChallanInfoForAnnexure;
                    this.grdAnnexere.DataBind();
                    decimal num = new decimal(0);
                    this.grdAnnexere.FooterRow.Cells[1].Text = "Total";
                    this.grdAnnexere.FooterRow.Cells[1].Font.Bold = true;
                    this.grdAnnexere.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                    for (int i = 1; i < tRChallanInfoForAnnexure.Columns.Count - 1; i++)
                    {
                        num = tRChallanInfoForAnnexure.AsEnumerable().Sum<DataRow>((DataRow row) => row.Field<decimal>(tRChallanInfoForAnnexure.Columns[3].ToString()));
                        this.grdAnnexere.FooterRow.Cells[2].Text = num.ToString("N2");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        // Token: 0x060000A0 RID: 160 RVA: 0x00008E44 File Offset: 0x00007044
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
            this.RefreshGridView();
        }

        // Token: 0x060000A1 RID: 161 RVA: 0x00008E54 File Offset: 0x00007054
        protected void drpBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intBankId = Convert.ToInt32(this.drpBankName.SelectedValue.ToString());
            Util.fillBankBranch(this.drpBankBranch, intBankId);
        }

        // Token: 0x060000A2 RID: 162 RVA: 0x00008E84 File Offset: 0x00007084
        protected void drpInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpInstrumentType.SelectedValue == "1")
            {
                this.lblInsDescription.Text = "Denomination:";
            }
            if (this.drpInstrumentType.SelectedValue == "2")
            {
                this.lblInsDescription.Text = "Demand Draft No:";
            }
            if (this.drpInstrumentType.SelectedValue == "3")
            {
                this.lblInsDescription.Text = "Pay Order No:";
            }
            if (this.drpInstrumentType.SelectedValue == "4")
            {
                this.lblInsDescription.Text = "Cheque No:";
            }
        }

        // Token: 0x060000A3 RID: 163 RVA: 0x00008F30 File Offset: 0x00007130
        protected void btnShowItemList_Click(object sender, EventArgs e)
        {
            if (this.btnShowItemList.Text == "Show List")
            {
                ArrayList dataSource = (ArrayList)this.Session["dtTCHInSession"];
                this.dgvTreasuryDeposit.DataSource = dataSource;
                this.dgvTreasuryDeposit.DataBind();
                this.dgvTreasuryDeposit.Visible = true;
                this.btnShowItemList.Text = "Hide List";
                return;
            }
            this.dgvTreasuryDeposit.Visible = false;
            this.btnShowItemList.Text = "Show List";
        }

        // Token: 0x060000A4 RID: 164 RVA: 0x00008FBC File Offset: 0x000071BC
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.searchByDateValidation())
                {
                    DateTime t = DateTime.Today;
                    DateTime t2 = DateTime.Today;
                    t = DateTime.ParseExact(this.txtFormDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    t2 = DateTime.ParseExact(this.txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    for (int i = 0; i < this.gvChallanItem.Rows.Count; i++)
                    {
                        DateTime t3 = DateTime.ParseExact(this.gvChallanItem.Rows[i].Cells[5].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        if (t3 >= t && t3 <= t2)
                        {
                            this.gvChallanItem.Rows[i].Visible = true;
                        }
                        else
                        {
                            this.gvChallanItem.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000A5 RID: 165 RVA: 0x000090C4 File Offset: 0x000072C4
        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.drpParty.SelectedValue);
            if (num == -99)
            {
                if (this.radio_challan_list.Checked)
                {
                    this.ShowChallanGridView();
                }
                if (this.radio_non_challan.Checked)
                {
                    this.ShowChallanGridViewForNonSale();
                }
                if (this.radio_vat_9_1.Checked)
                {
                    this.ShowChallanGridViewForVatReturnReport();
                }
                if (this.radio_VAT_AIT.Checked)
                {
                    this.ShowChallanGridViewForAITReturnReport();
                    return;
                }
            }
            else
            {
                for (int i = 0; i < this.gvChallanItem.Rows.Count; i++)
                {
                    int num2 = Convert.ToInt32(this.gvChallanItem.Rows[i].Cells[7].Text);
                    if (num == num2)
                    {
                        this.gvChallanItem.Rows[i].Visible = true;
                    }
                    else
                    {
                        this.gvChallanItem.Rows[i].Visible = false;
                    }
                }
            }
        }

        // Token: 0x060000A6 RID: 166 RVA: 0x000091AC File Offset: 0x000073AC
        protected void dgvTreasuryDeposit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intChallanId = Convert.ToInt32(this.dgvTreasuryDeposit.SelectedDataKey["challan_id"]);
            DataTable challanDataById = this.objtrnsTreasuryChallanBLL.getChallanDataById(intChallanId);
            if (challanDataById != null)
            {
                this.txtChallanNo.Text = challanDataById.Rows[0]["challan_no"].ToString();
                this.dtpUnloadRealDate2.Text = challanDataById.Rows[0]["date_challan"].ToString();
                this.drpBankName.SelectedValue = challanDataById.Rows[0]["bankId"].ToString();
                this.drpBankBranch.SelectedValue = challanDataById.Rows[0]["branchId"].ToString();
                this.txtCodeNo.Text = challanDataById.Rows[0]["code_no"].ToString();
                this.txtBearerNameAddress.Text = challanDataById.Rows[0]["bearer_name_address"].ToString();
                this.txtBehalfOf.Text = challanDataById.Rows[0]["orName"].ToString();
                this.txtDesignation.Text = challanDataById.Rows[0]["designation"].ToString();
                this.txtAddress1.Text = challanDataById.Rows[0]["orAddress"].ToString();
                this.txtDepositDescription.Text = challanDataById.Rows[0]["deposit_description"].ToString();
                this.drpInstrumentType.SelectedValue = this.drpInstrumentType.Items.FindByText(challanDataById.Rows[0]["instrument_type"].ToString()).Value;
                this.txtAmount.Text = challanDataById.Rows[0]["amount"].ToString();
                this.txtInstrumentDescription.Text = challanDataById.Rows[0]["instrument_description"].ToString();
                this.txtUnit.Text = challanDataById.Rows[0]["unit"].ToString();
                this.drpChallanType.SelectedValue = challanDataById.Rows[0]["chalan_type_d"].ToString();
                this.btnSave.Text = "Update";
            }
        }

        // Token: 0x060000A7 RID: 167 RVA: 0x00009448 File Offset: 0x00007648
        protected void dgvTreasuryDeposit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList arrayList = (ArrayList)this.Session["dtTCHInSession"];
                arrayList.RemoveAt(e.RowIndex);
                this.Session["dtTCHInSession"] = arrayList;
                this.AddDetailDataInGrid();
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000A8 RID: 168 RVA: 0x000094AC File Offset: 0x000076AC
        protected void dgvTreasuryDeposit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (object obj in e.Row.Cells)
                {
                    DataControlFieldCell dataControlFieldCell = (DataControlFieldCell)obj;
                    foreach (object obj2 in dataControlFieldCell.Controls)
                    {
                        Control control = (Control)obj2;
                        ImageButton imageButton = control as ImageButton;
                        if (imageButton != null && imageButton.CommandName == "Delete")
                        {
                            imageButton.OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
                        }
                    }
                }
            }
        }

        // Token: 0x060000A9 RID: 169 RVA: 0x00009588 File Offset: 0x00007788
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validation())
                {
                    this.fillDetailProperties();
                    this.AddDetailDataInGrid();
                    this.dgvTreasuryDeposit.Visible = true;
                    this.btnShowItemList.Text = "Hide List";
                    this.clearFrom();
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000AA RID: 170 RVA: 0x000095E8 File Offset: 0x000077E8
        protected void btnNewOrg_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.txtBehalfOf.Visible)
                {
                    this.btnNewOrg.Text = "Cancel";
                    this.drpOrgName.Enabled = false;
                    this.txtBehalfOf.Visible = true;
                }
                else
                {
                    this.btnNewOrg.Text = "New";
                    this.drpOrgName.Enabled = true;
                    this.txtBehalfOf.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000AB RID: 171 RVA: 0x00009670 File Offset: 0x00007870
        protected void drpOrgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable orgById = this.objtrnsNoteMasterBLL.getOrgById((int)Convert.ToInt16(this.drpOrgName.SelectedValue));
            this.txtAddress1.Text = orgById.Rows[0]["business_address"].ToString();
        }

        // Token: 0x060000AC RID: 172 RVA: 0x000096BF File Offset: 0x000078BF
        protected void radio_challan_list_CheckedChanged(object sender, EventArgs e)
        {
            this.gvChallanItem.Visible = true;
            this.lbl_nonChallan.Visible = false;
            this.txtAmount.Text = "0.00";
            this.ShowChallanGridView();
        }

        // Token: 0x060000AD RID: 173 RVA: 0x000096EF File Offset: 0x000078EF
        protected void radio_non_challan_CheckedChanged(object sender, EventArgs e)
        {
            this.gvChallanItem.Visible = true;
            this.lbl_nonChallan.Visible = false;
            this.txtAmount.Text = "0.00";
            this.ShowChallanGridViewForNonSale();
        }

        // Token: 0x060000AE RID: 174 RVA: 0x0000971F File Offset: 0x0000791F
        protected void radio_VAT_AIT_CheckedChanged(object sender, EventArgs e)
        {
            this.gvChallanItem.Visible = true;
            this.lbl_nonChallan.Visible = false;
            this.txtAmount.Text = "0.00";
            this.ShowChallanGridViewForAITReturnReport();
        }

        // Token: 0x060000AF RID: 175 RVA: 0x0000974F File Offset: 0x0000794F
        protected void radio_vat_9_1_CheckedChanged(object sender, EventArgs e)
        {
            this.gvChallanItem.Visible = true;
            this.lbl_nonChallan.Visible = false;
            this.txtAmount.Text = "0.00";
            this.ShowChallanGridViewForVatReturnReport();
        }

        // Token: 0x060000B0 RID: 176 RVA: 0x0000977F File Offset: 0x0000797F
        protected void gvDistricts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == 0)
            {
                e.Row.Style.Add("height", "50px");
            }
        }

        // Token: 0x060000B1 RID: 177 RVA: 0x000097B8 File Offset: 0x000079B8
        protected void btnShowTRChallan_Click(object sender, EventArgs e)
        {
            if (this.btnShowTRChallan.Text == "Show TR Challan Form")
            {
                this.btnShowTRChallan.Text = "Hide TR Challan Form";
                this.printTRForm.Visible = true;
                this.btnPrint.Visible = true;
                return;
            }
            this.btnShowTRChallan.Text = "Show TR Challan Form";
            this.printTRForm.Visible = false;
            this.btnPrint.Visible = false;
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x00009830 File Offset: 0x00007A30
        protected void gvChallanItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string challanNo = string.Empty;
                GridViewRow selectedRow = this.gvChallanItem.SelectedRow;
                if (this.drpRdbSelection.SelectedValue == "3" && selectedRow.RowType == DataControlRowType.DataRow)
                {
                    challanNo = selectedRow.Cells[2].Text.Trim();
                    DataTable paymentBreakdownAIT = this.objtrnsTreasuryChallanBLL.getPaymentBreakdownAIT(challanNo);
                    this.gridAIT.DataSource = paymentBreakdownAIT;
                    this.gridAIT.DataBind();
                    this.ModalPopupAIT.Show();
                }
                if (this.radio_vat_9_1.Checked && selectedRow.RowType == DataControlRowType.DataRow)
                {
                    challanNo = selectedRow.Cells[2].Text.Trim();
                    int challanId = Convert.ToInt32(selectedRow.Cells[8].Text);
                    int num = Convert.ToInt32(selectedRow.Cells[7].Text);
                    DataTable paymentBreakdown = this.objtrnsTreasuryChallanBLL.getPaymentBreakdown(challanNo, challanId);
                    paymentBreakdown.Columns.Add("party_id", typeof(int));
                    foreach (object obj in paymentBreakdown.Rows)
                    {
                        DataRow dataRow = (DataRow)obj;
                        dataRow["party_id"] = num;
                    }
                    this.gvPurchase2.DataSource = paymentBreakdown;
                    this.gvPurchase2.DataBind();
                    if (paymentBreakdown.Rows.Count > 0)
                    {
                        for (int i = 0; i < paymentBreakdown.Rows.Count; i++)
                        {
                            string a = paymentBreakdown.Rows[i]["status"].ToString();
                            if (a == "partially TR Challan Paid")
                            {
                                this.gvPurchase2.Rows[i].Cells[0].Enabled = false;
                            }
                        }
                    }
                    Dictionary<int, trnsTreasuryChallanDAODetail> dictionary = (Dictionary<int, trnsTreasuryChallanDAODetail>)this.Session["chkVDS"];
                    if (dictionary.Count > 0)
                    {
                        for (int j = 0; j < this.gvPurchase2.Rows.Count; j++)
                        {
                            CheckBox checkBox = (CheckBox)this.gvPurchase2.Rows[j].FindControl("chkChallan");
                            foreach (int num2 in dictionary.Keys)
                            {
                                int num3 = num2;
                                if (dictionary.ContainsKey(num3) && Convert.ToInt32(this.gvPurchase2.Rows[j].Cells[5].Text) == num3)
                                {
                                    checkBox.Checked = true;
                                }
                            }
                        }
                    }
                    this.modalPopupForLocalPurchase.Show();
                }
                if (this.radio_VAT_AIT.Checked && selectedRow.RowType == DataControlRowType.DataRow)
                {
                    int challanId = Convert.ToInt32(selectedRow.Cells[8].Text);
                    challanNo = selectedRow.Cells[2].Text.Trim();
                    DataTable paymentBreakdown2 = this.objtrnsTreasuryChallanBLL.getPaymentBreakdown(challanNo, challanId);
                    this.gridAIT.DataSource = paymentBreakdown2;
                    this.gridAIT.DataBind();
                    if (paymentBreakdown2.Rows.Count > 0)
                    {
                        for (int k = 0; k < paymentBreakdown2.Rows.Count; k++)
                        {
                            string a2 = paymentBreakdown2.Rows[k]["status"].ToString();
                            if (a2 == "partially TR Challan Paid")
                            {
                                this.gridAIT.Rows[k].Cells[0].Enabled = false;
                            }
                        }
                    }
                    this.ModalPopupAIT.Show();
                }
                if (this.radio_challan_list.Checked && selectedRow.RowType == DataControlRowType.DataRow)
                {
                    LinkButton linkButton = (LinkButton)selectedRow.FindControl("lnkSelect");
                    linkButton.Visible = false;
                }
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                throw;
            }
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x00009CA4 File Offset: 0x00007EA4
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string challanNo = string.Empty;
                GridViewRow selectedRow = this.gvChallanItem.SelectedRow;
                if (!this.radio_challan_list.Checked)
                {
                    for (int i = 0; i < this.gvChallanItem.Rows.Count; i++)
                    {
                        CheckBox checkBox = (CheckBox)this.gvChallanItem.Rows[i].FindControl("chkChallan");
                        challanNo = this.gvChallanItem.Rows[i].Cells[2].Text.Trim();
                        int challanId = Convert.ToInt32(this.gvChallanItem.Rows[i].Cells[8].Text.Trim());
                        if (checkBox.Checked)
                        {
                            DataTable paymentBreakdown = this.objtrnsTreasuryChallanBLL.getPaymentBreakdown(challanNo, challanId);
                            if (paymentBreakdown.Rows.Count >= 1)
                            {
                                this.amount = Convert.ToDecimal(this.gvChallanItem.Rows[i].Cells[3].Text.Trim());
                                checkBox.Checked = false;
                                this.txtAmount.Text = "0.00";
                                this.msgBox.AddMessage("This Challan has Multiple payment transaction", MsgBoxs.enmMessageType.Error);
                            }
                            else
                            {
                                this.total = Convert.ToDecimal(this.txtAmount.Text);
                            }
                            this.amountf = this.total - this.amount;
                            if (this.amountf < 0m)
                            {
                                this.txtAmount.Text = "0.00";
                            }
                            else
                            {
                                this.txtAmount.Text = this.amountf.ToString("0.00");
                            }
                        }
                    }
                }
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                throw;
            }
        }

        // Token: 0x060000B4 RID: 180 RVA: 0x00009E84 File Offset: 0x00008084
        protected void chkVDS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Dictionary<int, trnsTreasuryChallanDAODetail> dictionary = (Dictionary<int, trnsTreasuryChallanDAODetail>)this.Session["chkVDS"];
                for (int i = 0; i < this.gvPurchase2.Rows.Count; i++)
                {
                    trnsTreasuryChallanDAODetail trnsTreasuryChallanDAODetail = new trnsTreasuryChallanDAODetail();
                    CheckBox checkBox = (CheckBox)this.gvPurchase2.Rows[i].FindControl("chkChallan");
                    if (checkBox.Checked)
                    {
                        this.gvPurchase2.Rows[i].Cells[4].Text.ToString();
                        int key = Convert.ToInt32(this.gvPurchase2.Rows[i].Cells[5].Text);
                        if (!dictionary.ContainsKey(key))
                        {
                            trnsTreasuryChallanDAODetail.Index_Id = Convert.ToInt32(this.gvPurchase2.Rows[i].Cells[7].Text);
                            trnsTreasuryChallanDAODetail.purchaseChallanNo = this.gvPurchase2.Rows[i].Cells[4].Text.ToString();
                            trnsTreasuryChallanDAODetail.Purchase_challan_id = Convert.ToInt32(this.gvPurchase2.Rows[i].Cells[3].Text.ToString());
                            trnsTreasuryChallanDAODetail.Amount = Convert.ToDecimal(this.gvPurchase2.Rows[i].Cells[1].Text.ToString());
                            trnsTreasuryChallanDAODetail.Scroll_Id = Convert.ToInt32(this.gvPurchase2.Rows[i].Cells[5].Text.ToString());
                            trnsTreasuryChallanDAODetail.Party_Id = Convert.ToInt32(this.gvPurchase2.Rows[i].Cells[8].Text);
                            dictionary.Add(key, trnsTreasuryChallanDAODetail);
                        }
                    }
                    else
                    {
                        int key2 = Convert.ToInt32(this.gvPurchase2.Rows[i].Cells[5].Text);
                        if (dictionary.ContainsKey(key2))
                        {
                            dictionary.Remove(key2);
                        }
                    }
                }
                this.Session["chkVDS"] = dictionary;
                this.modalPopupForLocalPurchase.Show();
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                throw;
            }
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x0000A0FC File Offset: 0x000082FC
        protected void drpRdbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpRdbSelection.SelectedValue == "2")
            {
                this.radio_challan_list.Checked = true;
                this.radio_vat_9_1.Checked = false;
                this.radio_non_challan.Checked = false;
                this.gvChallanItem.DataSource = null;
                this.gvChallanItem.DataBind();
                this.ShowChallanGridViewForSD();
            }
            if (this.drpRdbSelection.SelectedValue == "1")
            {
                this.gvChallanItem.DataSource = null;
                this.gvChallanItem.DataBind();
                this.radio_vat_9_1.Visible = true;
                this.radio_non_challan.Visible = true;
                this.radio_vat_9_1.Checked = false;
                this.radio_non_challan.Checked = false;
                this.radio_challan_list.Checked = true;
                this.ShowChallanGridView();
            }
            if (this.drpRdbSelection.SelectedValue == "3")
            {
                this.gvChallanItem.DataSource = null;
                this.gvChallanItem.DataBind();
                this.radio_vat_9_1.Visible = true;
                this.radio_non_challan.Visible = true;
                this.radio_vat_9_1.Checked = false;
                this.radio_non_challan.Checked = false;
                this.radio_challan_list.Checked = true;
                this.ShowChallanAITGridView();
            }
            if (this.drpRdbSelection.SelectedValue == "4")
            {
                this.gvChallanItem.DataSource = null;
                this.gvChallanItem.DataBind();
                this.radio_vat_9_1.Visible = true;
                this.radio_non_challan.Visible = true;
                this.radio_vat_9_1.Checked = false;
                this.radio_non_challan.Checked = false;
                this.radio_challan_list.Checked = true;
                this.ShowChallanGridViewHealthCharge();
            }
        }

        // Token: 0x060000B6 RID: 182 RVA: 0x0000A2B4 File Offset: 0x000084B4
        //private void LoadKorMeyad()
        //{
        //    try
        //    {
        //        DateTime today = DateTime.Today.AddMonths(-1);
        //        string str = today.ToString("yyyy");
        //        string text = today.ToString("MM");
        //        string text2 = today.ToString("MMMM");
        //        string s = "15/" + text + "/" + str;
        //        DateTime t = DateTime.ParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        string value = today.AddMonths(-1).ToString("MM");
        //        string text3 = today.AddMonths(-1).ToString("MMMM");
        //        if (today > t)
        //        {
        //            this.drpsubmissionDate.Items.Add(new ListItem(text2, text));
        //        }
        //        else
        //        {
        //            this.drpsubmissionDate.Items.Add(new ListItem(text2, text));
        //            this.drpsubmissionDate.Items.Add(new ListItem(text3, value));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //         BLL.Utility.InsertErrorTrack(ex.Message, "TreasuryChallan_6.aspx", "GetPartyInfo");
        //    }
        //}


        private void LoadKorMeyad()
        {
            try
            {
                DateTime today = DateTime.Today.AddMonths(-1); // main base month

                string year = today.ToString("yyyy");
                string month1Value = today.ToString("MM");
                string month1Text = today.ToString("MMMM");

                string targetDateStr = "15/" + month1Value + "/" + year;
                DateTime targetDate = DateTime.ParseExact(targetDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // previous month
                DateTime prevMonth = today.AddMonths(-1);
                string month2Value = prevMonth.ToString("MM");
                string month2Text = prevMonth.ToString("MMMM");

                // previous previous month  (3rd month)
                DateTime prevPrevMonth = today.AddMonths(-2);
                string month3Value = prevPrevMonth.ToString("MM");
                string month3Text = prevPrevMonth.ToString("MMMM");

                if (today > targetDate)
                {
                    // Add 3 months (current, previous, previous previous)
                    this.drpsubmissionDate.Items.Add(new ListItem(month1Text, month1Value));
                    this.drpsubmissionDate.Items.Add(new ListItem(month2Text, month2Value));
                    this.drpsubmissionDate.Items.Add(new ListItem(month3Text, month3Value));
                }
                else
                {
                    // Add 2 months only (current, previous)
                    this.drpsubmissionDate.Items.Add(new ListItem(month1Text, month1Value));
                    this.drpsubmissionDate.Items.Add(new ListItem(month2Text, month2Value));
                    this.drpsubmissionDate.Items.Add(new ListItem(month3Text, month3Value));
                }
            }
            catch (Exception ex)
            {
                BLL.Utility.InsertErrorTrack(ex.Message, "TreasuryChallan_6.aspx", "GetPartyInfo");
            }
        }


        // Token: 0x060000B7 RID: 183 RVA: 0x0000A3C4 File Offset: 0x000085C4
        private void GetPartyInfo()
        {
            try
            {
                this.drpParty.Items.Clear();
                ChallanBLL challanBLL = new ChallanBLL();
                DataTable allPartyInfo = challanBLL.GetAllPartyInfo();
                if (allPartyInfo != null && allPartyInfo.Rows.Count > 0)
                {
                    this.drpParty.DataSource = allPartyInfo;
                    this.drpParty.DataTextField = allPartyInfo.Columns["party_name"].ToString();
                    this.drpParty.DataValueField = allPartyInfo.Columns["party_id"].ToString();
                    this.drpParty.DataBind();
                }
                ListItem item = new ListItem("-- SELECT --", "-99");
                this.drpParty.Items.Insert(0, item);
            }
            catch (Exception ex)
            {
                 BLL.Utility.InsertErrorTrack(ex.Message, "TreasuryChallan_6.aspx", "GetPartyInfo");
            }
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x0000A4A4 File Offset: 0x000086A4
        private void showTRChallanFormGV()
        {
            DataTable lastChallan_id = this.objtrnsTreasuryChallanBLL.getLastChallan_id();
            if (lastChallan_id.Rows.Count > 0)
            {
                string challan_id = lastChallan_id.Rows[0]["challan_id"].ToString();
                DataTable dataTable = this.objtrnsTreasuryChallanBLL.showTRChallanFormByChallanNO(challan_id);
                if (dataTable.Rows.Count > 0)
                {
                    string text = "";
                    string text2 = "";
                    double num = 0.0;
                    double num2 = 0.0;
                    string empty = string.Empty;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string text3 = ((dataTable.Rows[i]["amount"].ToString() != null) ? Convert.ToDouble(dataTable.Rows[i]["amount"].ToString()) : 0.0).ToString("0.00", CultureInfo.InvariantCulture);
                        string[] array = text3.Split(new char[]
                        {
                        '.'
                        });
                        int num3 = int.Parse(array[0]);
                        int num4 = int.Parse(array[1]);
                        text = dataTable.Rows[i]["code_no"].ToString();
                        text2 += "<tr>";
                        object obj = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj,
                        "<td>",
                        dataTable.Rows[i]["bearer_name_address"],
                        "</td>"
                        });
                        object obj2 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj2,
                        "<td>",
                        dataTable.Rows[i]["bearer_name_designation"],
                        "</td>"
                        });
                        object obj3 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj3,
                        "<td>",
                        dataTable.Rows[i]["deposit_description"],
                        "</td>"
                        });
                        object obj4 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj4,
                        "<td>",
                        dataTable.Rows[i]["instrument_description"],
                        "</td>"
                        });
                        if (Convert.ToDecimal(num3) == 0m)
                        {
                            text2 += "<td style='text-align:right;'>-</td>";
                        }
                        else
                        {
                            text2 = text2 + "<td style='text-align:right;'> " + num3.ToString("N0") + "</td>";
                        }
                        if (num4 == 0)
                        {
                            text2 += "<td style='text-align:right;'>-</td>";
                        }
                        else
                        {
                            object obj5 = text2;
                            text2 = string.Concat(new object[]
                            {
                            obj5,
                            "<td style='text-align:right;'>",
                            num4,
                            "</td>"
                            });
                        }
                        text2 += "<td></td>";
                        text2 += "</tr>";
                        num += (double)num3;
                        num2 += (double)num4;
                        this.trdate.InnerText = dataTable.Rows[i]["date_challan"].ToString();
                        this.trbranch.InnerText = dataTable.Rows[i]["bank_branch_name"].ToString();
                        this.trBranchDistrict.InnerText = dataTable.Rows[i]["district_name"].ToString();
                    }
                    this.lblTRForm.Text = text2;
                    if (num == 0.0)
                    {
                        this.lblTotalTK.Text = "-";
                    }
                    else
                    {
                        this.lblTotalTK.Text = num.ToString("N0");
                    }
                    if (num2 == 0.0)
                    {
                        this.lblTotalPaisa.Text = "-";
                    }
                    else
                    {
                        this.lblTotalPaisa.Text = num2.ToString();
                    }
                    this.lblAmountInWord.Text = InWord.ConvertToWordBangla(num + num2 / 100.0);
                    this.lblDate2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                    ArrayList arrayList = new ArrayList();
                    short num5 = 0;
                    while ((int)num5 < text.Length)
                    {
                        arrayList.Add(text[(int)num5].ToString());
                        num5 += 1;
                    }
                    this.TextBox0.Text = ((!string.IsNullOrEmpty(arrayList[0].ToString())) ? arrayList[0].ToString() : string.Empty);
                    this.TextBox1.Text = ((!string.IsNullOrEmpty(arrayList[1].ToString())) ? arrayList[1].ToString() : string.Empty);
                    this.TextBox2.Text = ((!string.IsNullOrEmpty(arrayList[2].ToString())) ? arrayList[2].ToString() : string.Empty);
                    this.TextBox3.Text = ((!string.IsNullOrEmpty(arrayList[3].ToString())) ? arrayList[3].ToString() : string.Empty);
                    this.TextBox4.Text = ((!string.IsNullOrEmpty(arrayList[4].ToString())) ? arrayList[4].ToString() : string.Empty);
                    this.TextBox5.Text = ((!string.IsNullOrEmpty(arrayList[5].ToString())) ? arrayList[5].ToString() : string.Empty);
                    this.TextBox6.Text = ((!string.IsNullOrEmpty(arrayList[6].ToString())) ? arrayList[6].ToString() : string.Empty);
                    this.TextBox7.Text = ((!string.IsNullOrEmpty(arrayList[7].ToString())) ? arrayList[7].ToString() : string.Empty);
                    this.TextBox8.Text = ((!string.IsNullOrEmpty(arrayList[8].ToString())) ? arrayList[8].ToString() : string.Empty);
                    this.TextBox9.Text = ((!string.IsNullOrEmpty(arrayList[9].ToString())) ? arrayList[9].ToString() : string.Empty);
                    this.TextBox10.Text = ((!string.IsNullOrEmpty(arrayList[10].ToString())) ? arrayList[10].ToString() : string.Empty);
                    this.TextBox11.Text = ((!string.IsNullOrEmpty(arrayList[11].ToString())) ? arrayList[11].ToString() : string.Empty);
                    this.TextBox12.Text = ((!string.IsNullOrEmpty(arrayList[12].ToString())) ? arrayList[12].ToString() : string.Empty);
                    this.printTRForm.Visible = true;
                    this.btnPrint.Visible = true;
                    this.printAnnexure.Visible = true;
                    this.btnPrintAnnexere.Visible = true;
                    this.LoadAnnexureGrid(Convert.ToInt32(HttpContext.Current.Session["challanIdAnnexere"]));
                    HttpContext.Current.Session["challanIdAnnexere"] = null;
                }
            }
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x0000AC44 File Offset: 0x00008E44
        private void ShowChallanGridViewHealthCharge()
        {
            try
            {
                this.gvChallanItem.Columns[3].HeaderText = "Health care surcharge";
                DataTable challanForHealthCharge = this.objtrnsTreasuryChallanBLL.getChallanForHealthCharge();
                if (challanForHealthCharge != null)
                {
                    this.gvChallanItem.DataSource = challanForHealthCharge;
                    this.gvChallanItem.DataBind();
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000BA RID: 186 RVA: 0x0000ACB0 File Offset: 0x00008EB0
        private void ShowChallanGridView()
        {
            try
            {
                this.gvChallanItem.Columns[3].HeaderText = "VAT";
                DataTable challanForVat = this.objtrnsTreasuryChallanBLL.getChallanForVat();
                if (challanForVat != null)
                {
                    this.gvChallanItem.DataSource = challanForVat;
                    this.gvChallanItem.DataBind();
                }
                this.gvChallanItem.Columns[0].ItemStyle.CssClass = "hiddencol";
                this.gvChallanItem.Columns[0].HeaderStyle.CssClass = "hiddencol";
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000BB RID: 187 RVA: 0x0000AD5C File Offset: 0x00008F5C
        private void ShowChallanAITGridView()
        {
            try
            {
                DataTable challanForAIT = this.objtrnsTreasuryChallanBLL.getChallanForAIT();
                if (challanForAIT != null)
                {
                    this.gvChallanItem.DataSource = challanForAIT;
                    this.gvChallanItem.DataBind();
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000BC RID: 188 RVA: 0x0000ADAC File Offset: 0x00008FAC
        private void ShowChallanGridViewForSD()
        {
            try
            {
                this.gvChallanItem.Columns[3].HeaderText = "SD";
                DataTable challanForSD = this.objtrnsTreasuryChallanBLL.getChallanForSD();
                if (challanForSD != null)
                {
                    this.gvChallanItem.DataSource = challanForSD;
                    this.gvChallanItem.DataBind();
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000BD RID: 189 RVA: 0x0000AE18 File Offset: 0x00009018
        private void LoadMinutes()
        {
            for (int i = 1; i <= 59; i++)
            {
            }
        }

        // Token: 0x060000BE RID: 190 RVA: 0x0000AE34 File Offset: 0x00009034
        private void LoadHours()
        {
            for (int i = 1; i <= 23; i++)
            {
            }
        }

        // Token: 0x060000BF RID: 191 RVA: 0x0000AE50 File Offset: 0x00009050
        private bool ChallanValidation()
        {
            if (this.txtChallanNo.Text.Trim().Length < 1)
            {
                this.txtChallanNo.Focus();
                return false;
            }
            if (this.dtpUnloadRealDate2.Text.Trim().Length < 1)
            {
                this.dtpUnloadRealDate2.Focus();
                return false;
            }
            if (this.drpBankName.SelectedValue == 0.ToString())
            {
                this.drpBankName.Focus();
                return false;
            }
            if (this.drpBankBranch.SelectedValue == 0.ToString())
            {
                this.drpBankBranch.Focus();
                return false;
            }
            if (this.txtCodeNo.Text.Trim().Length < 1)
            {
                this.txtCodeNo.Focus();
                return false;
            }
            if (this.txtBearerNameAddress.Text.Trim().Length < 1)
            {
                this.txtBearerNameAddress.Focus();
                return false;
            }
            if (this.txtBehalfOf.Text.Trim().Length < 1)
            {
                this.txtBehalfOf.Focus();
                return false;
            }
            if (this.txtAddress1.Text.Trim().Length < 1)
            {
                this.txtAddress1.Focus();
                return false;
            }
            if (this.txtDepositDescription.Text.Trim().Length < 1)
            {
                this.txtDepositDescription.Focus();
                return false;
            }
            if (this.drpInstrumentType.SelectedValue == 0.ToString())
            {
                this.drpInstrumentType.Focus();
                return false;
            }
            if (this.txtAmount.Text.Trim().Length < 1)
            {
                this.txtAmount.Focus();
                return false;
            }
            if (this.drpChallanType.SelectedValue == 0.ToString())
            {
                this.drpChallanType.Focus();
                return false;
            }
            return true;
        }

        // Token: 0x060000C0 RID: 192 RVA: 0x0000B026 File Offset: 0x00009226
        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        // Token: 0x060000C1 RID: 193 RVA: 0x0000B048 File Offset: 0x00009248
        private void clearFrom()
        {
            this.txtChallanNo.Text = "";
            this.dtpUnloadRealDate2.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
            this.drpBankName.SelectedValue = "0";
            this.drpBankBranch.SelectedValue = "0";
            this.txtCodeNo.Text = "";
            this.txtBearerNameAddress.Text = "";
            this.txtBehalfOf.Text = "";
            this.txtBehalfOf.Visible = false;
            this.drpOrgName.Visible = true;
            Util.fillOrgName(this.drpOrgName);
            this.drpOrgName.SelectedValue = this.Session["ORGANIZATION_ID"].ToString();
            this.objtrnsNoteMasterBLL.getOrgById((int)Convert.ToInt16(this.drpOrgName.SelectedValue));
            this.btnNewOrg.Text = "New";
            this.txtDesignation.Text = "";
            this.txtDepositDescription.Text = "";
            this.drpInstrumentType.SelectedValue = "0";
            this.txtAmount.Text = "";
            this.txtInstrumentDescription.Text = "";
            this.txtUnit.Text = "";
            this.drpChallanType.SelectedValue = "0";
            this.setAddMode();
        }

        // Token: 0x060000C2 RID: 194 RVA: 0x0000B1C0 File Offset: 0x000093C0
        private void RefreshGridView()
        {
            this.dtTCHgrid = new DataTable();
            this.Session["dtTCHInSession"] = null;
            this.dgvTreasuryDeposit.DataSource = this.dtTCHgrid;
            this.dgvTreasuryDeposit.DataBind();
        }

        // Token: 0x060000C3 RID: 195 RVA: 0x0000B1FC File Offset: 0x000093FC
        private bool Validation()
        {
            if (string.IsNullOrEmpty(this.dtpUnloadRealDate2.Text))
            {
                this.msgBox.AddMessage("Challan date can't be empty", MsgBoxs.enmMessageType.Attention);
                this.dtpUnloadRealDate2.Focus();
                return false;
            }
            if (this.drpBankName.SelectedValue == "0")
            {
                this.drpBankName.Focus();
                this.msgBox.AddMessage("Please select bank ", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpBankBranch.SelectedValue == "0")
            {
                this.drpBankBranch.Focus();
                this.msgBox.AddMessage("Please select bank branch ", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpChallanType.SelectedValue == "0")
            {
                this.drpChallanType.Focus();
                this.msgBox.AddMessage("  Select Challan For ", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtCodeNo.Text))
            {
                this.msgBox.AddMessage("Code can't be empty'", MsgBoxs.enmMessageType.Attention);
                this.txtCodeNo.Focus();
                return false;
            }
            if (this.drpOrgName.SelectedValue == "0" && this.txtBehalfOf.Text.Count<char>() < 0)
            {
                this.txtBehalfOf.Focus();
                return false;
            }
            if (this.drpInstrumentType.SelectedValue == "0")
            {
                this.drpInstrumentType.Focus();
                this.msgBox.AddMessage("  Select Instrument Type ", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtAmount.Text == "" || this.txtAmount.Text == "0" || this.txtAmount.Text == "0.00")
            {
                this.msgBox.AddMessage("Amount can't be empty or zero", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            return true;
        }

        // Token: 0x060000C4 RID: 196 RVA: 0x0000B3D0 File Offset: 0x000095D0
        private void fillDetailProperties()
        {
            DateTime dateTime = DateTime.Now;
            ArrayList arrayList = (ArrayList)this.Session["dtTCHInSession"];
            if (arrayList == null)
            {
                arrayList = new ArrayList();
            }
            ArrayList arrayList2 = (ArrayList)this.Session["dtTCHInSessionTd"];
            if (arrayList2 == null)
            {
                arrayList2 = new ArrayList();
            }
            Convert.ToInt16(arrayList.Count + 1);
            try
            {
                this.objTrnsTreasuryChallanDAO.ChallanNo = SequentialNumber.GetNextNumber().ToString();
                if (!string.IsNullOrEmpty(this.dtpUnloadRealDate2.Text.Trim()))
                {
                    dateTime = DateTime.ParseExact(this.dtpUnloadRealDate2.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                this.objTrnsTreasuryChallanDAO.DateChallan = dateTime;
                DateTime today = DateTime.Today;
                string str = today.ToString("yyyy");
                string b = today.ToString("MM");
                string text = today.AddMonths(-1).ToString("MM");
                string s;
                if (text == "12")
                {
                    string str2 = today.AddYears(-1).ToString("yyyy");
                    s = "01/" + text + "/" + str2;
                }
                else
                {
                    s = "01/" + text + "/" + str;
                }
                if (this.drpsubmissionDate.SelectedValue == b)
                {
                    this.objTrnsTreasuryChallanDAO.submisionDate = dateTime;
                }
                else
                {
                    this.objTrnsTreasuryChallanDAO.submisionDate = DateTime.ParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                this.objTrnsTreasuryChallanDAO.BankName = this.drpBankName.SelectedItem.ToString();
                this.objTrnsTreasuryChallanDAO.StrDate = this.dtpUnloadRealDate2.Text.Trim();
                this.objTrnsTreasuryChallanDAO.BranchName = this.drpBankBranch.SelectedItem.ToString();
                this.objTrnsTreasuryChallanDAO.BranchId = Convert.ToInt16(this.drpBankBranch.SelectedValue);
                this.objTrnsTreasuryChallanDAO.CodeNo = this.txtCodeNo.Text;
                this.objTrnsTreasuryChallanDAO.BearerNameAddress = this.txtBearerNameAddress.Text;
                this.objTrnsTreasuryChallanDAO.OrganizationId = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                this.objTrnsTreasuryChallanDAO.OrgName = this.drpOrgName.SelectedItem.Text;
                this.objTrnsTreasuryChallanDAO.DepositDescription = this.txtDepositDescription.Text.Trim();
                this.objTrnsTreasuryChallanDAO.Designation = this.txtDesignation.Text.Trim();
                this.objTrnsTreasuryChallanDAO.OrgAddress = this.txtAddress1.Text.Trim();
                this.objTrnsTreasuryChallanDAO.InstrumentDescription = this.txtInstrumentDescription.Text.Trim();
                this.objTrnsTreasuryChallanDAO.InstrumentType = this.drpInstrumentType.SelectedItem.Text;
                this.objTrnsTreasuryChallanDAO.Amount = Convert.ToDouble(this.txtAmount.Text.Trim());
                this.objTrnsTreasuryChallanDAO.ChallanTypem = 9;
                this.objTrnsTreasuryChallanDAO.ChallanTyped = Convert.ToInt16(this.drpChallanType.SelectedValue);
                this.objTrnsTreasuryChallanDAO.ChallanType = this.drpChallanType.SelectedItem.Text;
                this.objTrnsTreasuryChallanDAO.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                for (int i = 0; i < this.gvChallanItem.Rows.Count; i++)
                {
                    trnsTreasuryChallanDAODetail trnsTreasuryChallanDAODetail = new trnsTreasuryChallanDAODetail();
                    CheckBox checkBox = (CheckBox)this.gvChallanItem.Rows[i].FindControl("chkChallan");
                    if (checkBox.Checked)
                    {
                        string item = this.gvChallanItem.Rows[i].Cells[8].Text.ToString();
                        list.Add(item);
                        trnsTreasuryChallanDAODetail.purchaseChallanNo = this.gvChallanItem.Rows[i].Cells[2].Text.ToString();
                        trnsTreasuryChallanDAODetail.Purchase_challan_id = Convert.ToInt32(this.gvChallanItem.Rows[i].Cells[8].Text.ToString());
                        trnsTreasuryChallanDAODetail.Amount = Convert.ToDecimal(this.gvChallanItem.Rows[i].Cells[3].Text.ToString());
                        trnsTreasuryChallanDAODetail.Party_Id = Convert.ToInt32(this.gvChallanItem.Rows[i].Cells[7].Text.ToString());
                        if (this.drpRdbSelection.SelectedValue == "1")
                        {
                            trnsTreasuryChallanDAODetail.Is_VAT = true;
                        }
                        if (this.drpRdbSelection.SelectedValue == "2")
                        {
                            trnsTreasuryChallanDAODetail.Is_SD = true;
                        }
                        arrayList2.Add(trnsTreasuryChallanDAODetail);
                    }
                }
                Dictionary<int, trnsTreasuryChallanDAODetail> dictionary = (Dictionary<int, trnsTreasuryChallanDAODetail>)this.Session["chkVDS"];
                if (dictionary.Count > 0)
                {
                    foreach (trnsTreasuryChallanDAODetail trnsTreasuryChallanDAODetail2 in dictionary.Values)
                    {
                        trnsTreasuryChallanDAODetail trnsTreasuryChallanDAODetail3 = new trnsTreasuryChallanDAODetail();
                        trnsTreasuryChallanDAODetail3.purchaseChallanNo = trnsTreasuryChallanDAODetail2.purchaseChallanNo;
                        trnsTreasuryChallanDAODetail3.Purchase_challan_id = trnsTreasuryChallanDAODetail2.Purchase_challan_id;
                        trnsTreasuryChallanDAODetail3.Amount = trnsTreasuryChallanDAODetail2.Amount;
                        trnsTreasuryChallanDAODetail3.Scroll_Id = trnsTreasuryChallanDAODetail2.Scroll_Id;
                        trnsTreasuryChallanDAODetail3.Party_Id = trnsTreasuryChallanDAODetail2.Party_Id;
                        list.Add(trnsTreasuryChallanDAODetail3.Purchase_challan_id.ToString());
                        list2.Add(trnsTreasuryChallanDAODetail3.Scroll_Id.ToString());
                        if (this.drpRdbSelection.SelectedValue == "1")
                        {
                            trnsTreasuryChallanDAODetail3.Is_VAT = true;
                        }
                        if (this.drpRdbSelection.SelectedValue == "2")
                        {
                            trnsTreasuryChallanDAODetail3.Is_SD = true;
                        }
                        arrayList2.Add(trnsTreasuryChallanDAODetail3);
                    }
                }
                if (this.drpRdbSelection.SelectedValue == "3")
                {
                    for (int j = 0; j < this.gridAIT.Rows.Count; j++)
                    {
                        trnsTreasuryChallanDAODetail trnsTreasuryChallanDAODetail4 = new trnsTreasuryChallanDAODetail();
                        CheckBox checkBox2 = (CheckBox)this.gridAIT.Rows[j].FindControl("chkChallan");
                        if (checkBox2.Checked)
                        {
                            string item2 = this.gridAIT.Rows[j].Cells[3].Text.ToString();
                            string item3 = this.gridAIT.Rows[j].Cells[5].Text.ToString();
                            list.Add(item2);
                            list2.Add(item3);
                            trnsTreasuryChallanDAODetail4.purchaseChallanNo = this.gridAIT.Rows[j].Cells[4].Text.ToString();
                            trnsTreasuryChallanDAODetail4.Purchase_challan_id = Convert.ToInt32(this.gridAIT.Rows[j].Cells[3].Text.ToString());
                            trnsTreasuryChallanDAODetail4.Amount = Convert.ToDecimal(this.gridAIT.Rows[j].Cells[1].Text.ToString());
                            trnsTreasuryChallanDAODetail4.Scroll_Id = Convert.ToInt32(this.gridAIT.Rows[j].Cells[5].Text.ToString());
                            arrayList2.Add(trnsTreasuryChallanDAODetail4);
                        }
                    }
                }
                this.objTrnsTreasuryChallanDAO.Challan_numbers = list;
                this.objTrnsTreasuryChallanDAO.ScrollId = list2;
                int num = 0;
                int num2 = 0;
                Dictionary<int, bool> dictionary2 = new Dictionary<int, bool>();
                if (list.Count > 0)
                {
                    foreach (string value in list)
                    {
                        int num3 = Convert.ToInt32(value);
                        DataTable paymentFinish = this.objtrnsTreasuryChallanBLL.getPaymentFinish(num3);
                        if (paymentFinish.Rows.Count > 0)
                        {
                            this.objTrnsTreasuryChallanDAO.isPayment = Convert.ToBoolean(paymentFinish.Rows[0]["is_payment_finished"].ToString());
                        }
                        DataTable maxScrollID = this.objtrnsTreasuryChallanBLL.getMaxScrollID(num3);
                        if (maxScrollID.Rows.Count > 0)
                        {
                            num = (int)Convert.ToInt16(maxScrollID.Rows[0]["noscroll_id"]);
                        }
                        DataTable dataTable = this.objtrnsTreasuryChallanBLL.getpaidScrollID(num3);
                        if (dataTable.Rows.Count > 0)
                        {
                            num2 = (int)Convert.ToInt16(dataTable.Rows[0]["noscroll_id"]);
                        }
                        if (num - 1 == num2 || num == 0)
                        {
                            this.objTrnsTreasuryChallanDAO.isTR = true;
                        }
                        else
                        {
                            this.objTrnsTreasuryChallanDAO.isTR = false;
                        }
                        if (!dictionary2.ContainsKey(num3))
                        {
                            dictionary2.Add(num3, this.objTrnsTreasuryChallanDAO.isTR);
                        }
                    }
                }
                arrayList.Add(this.objTrnsTreasuryChallanDAO);
                this.Session["dtTCHInSession"] = arrayList;
                this.Session["dtTCHInSessionTd"] = arrayList2;
                this.Session["TRStatus"] = dictionary2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Token: 0x060000C5 RID: 197 RVA: 0x0000BDBC File Offset: 0x00009FBC
        private void AddDetailDataInGrid()
        {
            ArrayList dataSource = (ArrayList)this.Session["dtTCHInSession"];
            this.dgvTreasuryDeposit.DataSource = dataSource;
            this.dgvTreasuryDeposit.DataBind();
        }

        // Token: 0x060000C6 RID: 198 RVA: 0x0000BDF8 File Offset: 0x00009FF8
        private void ShowChallanGridViewForNonSale()
        {
            try
            {
                this.gvChallanItem.Columns[3].HeaderText = "VAT";
                DataTable challanForNonSale = this.objtrnsTreasuryChallanBLL.getChallanForNonSale();
                if (challanForNonSale != null)
                {
                    this.gvChallanItem.DataSource = challanForNonSale;
                    this.gvChallanItem.DataBind();
                }
                this.gvChallanItem.Columns[0].ItemStyle.CssClass = "hiddencol";
                this.gvChallanItem.Columns[0].HeaderStyle.CssClass = "hiddencol";
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000C7 RID: 199 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
        private void ShowChallanGridViewForAITReturnReport()
        {
            try
            {
                this.gvChallanItem.Columns[3].HeaderText = "AIT";
                DataTable aitreturnReportData = this.objtrnsTreasuryChallanBLL.getAITReturnReportData();
                if (aitreturnReportData != null)
                {
                    this.gvChallanItem.DataSource = aitreturnReportData;
                    this.gvChallanItem.DataBind();
                }
                this.gvChallanItem.Columns[0].ItemStyle.CssClass = "hiddent";
                this.gvChallanItem.Columns[0].HeaderStyle.CssClass = "hiddent";
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000C8 RID: 200 RVA: 0x0000BF50 File Offset: 0x0000A150
        private void ShowChallanGridViewForVatReturnReport()
        {
            try
            {
                this.gvChallanItem.Columns[3].HeaderText = "VAT";
                DataTable vatReturnReportData = this.objtrnsTreasuryChallanBLL.getVatReturnReportData();
                if (vatReturnReportData != null)
                {
                    this.gvChallanItem.DataSource = vatReturnReportData;
                    this.gvChallanItem.DataBind();
                }
                this.gvChallanItem.Columns[0].ItemStyle.CssClass = "hiddent";
                this.gvChallanItem.Columns[0].HeaderStyle.CssClass = "hiddent";
                for (int i = 0; i < this.gvChallanItem.Rows.Count; i++)
                {
                    if (this.gvChallanItem.Rows.Count > 1 && i != 0 && this.gvChallanItem.Rows[i].Cells[2].Text.ToString() == this.gvChallanItem.Rows[i - 1].Cells[2].Text.ToString() && this.gvChallanItem.Rows[i].Cells[8].Text.ToString() == this.gvChallanItem.Rows[i - 1].Cells[8].Text.ToString())
                    {
                        this.gvChallanItem.Rows[i].Attributes.Add("style", "display:none");
                    }
                }
            }
            catch (Exception ex)
            {
                ReallySimpleLog.WriteLog(ex);
            }
        }

        // Token: 0x060000C9 RID: 201 RVA: 0x0000C114 File Offset: 0x0000A314
        private DataTable getNewDataTableWithBalance(DataTable dtCurrentAccount)
        {
            decimal d = 0m;
            for (int i = 0; i < dtCurrentAccount.Rows.Count; i++)
            {
                decimal d2 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["treasury_deposit"]);
                decimal d3 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["exempt_amount"]);
                decimal num = Convert.ToDecimal(dtCurrentAccount.Rows[i]["others"]);
                decimal d4 = Convert.ToDecimal(dtCurrentAccount.Rows[i]["pay_amount"]);
                decimal d5 = d2 + d3 - d4;
                short num2 = Convert.ToInt16(dtCurrentAccount.Rows[i]["balance_action"]);
                if (i == 0)
                {
                    d = Convert.ToDecimal(dtCurrentAccount.Rows[0]["balance_amount"]);
                }
                else
                {
                    if (num2 == 1)
                    {
                        d += d5;
                        if (num > 0m)
                        {
                            d -= num;
                        }
                    }
                    else
                    {
                        d = d + num + d5;
                    }
                    dtCurrentAccount.Rows[i]["balance_amount"] = d.ToString("0.00");
                }
            }
            return dtCurrentAccount;
        }

        // Token: 0x060000CA RID: 202 RVA: 0x0000C260 File Offset: 0x0000A460
        private void VATLastUpdatedBalance()
        {
            CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
            DateTime fromDate = DateTime.Today;
            DateTime toDate = DateTime.Today;
            string value = this.Session["ORGANIZATION_ID"].ToString();
            fromDate =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
            toDate =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
            DataTable currentAccount18ReportBySearchVAT = currentAccountBLL.GetCurrentAccount18ReportBySearchVAT(fromDate, toDate, Convert.ToInt16(value));
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
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "date_challan ASC";
                DataTable dtCurrentAccount = defaultView.ToTable();
                dataTable = this.getNewDataTableWithBalance(dtCurrentAccount);
            }
            else
            {
                dataTable = currentAccount18ReportBySearchVAT;
                dataTable = this.getNewDataTableWithBalance(dataTable);
            }
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("date_challan");
                dataTable2.Columns.Add("trns_desc");
                dataTable2.Columns.Add("challan_no");
                dataTable2.Columns.Add("treasury_deposit");
                dataTable2.Columns.Add("exempt_amount");
                dataTable2.Columns.Add("others", typeof(decimal));
                dataTable2.Columns.Add("pay_amount", typeof(decimal));
                dataTable2.Columns.Add("balance_amount", typeof(decimal));
                dataTable2.Columns.Add("balance_action");
                DataRow dataRow = dataTable.Rows[dataTable.Rows.Count - 1];
                if (dataRow != null)
                {
                    dataTable2.ImportRow(dataRow);
                    if (dataTable2.Rows[0]["balance_amount"] != null)
                    {
                        decimal num = Convert.ToDecimal(dataTable2.Rows[0]["balance_amount"].ToString());
                        this.Session["VAT_LAST_AMOUNT"] = num.ToString("0.00");
                    }
                }
            }
        }

        // Token: 0x060000CB RID: 203 RVA: 0x0000C564 File Offset: 0x0000A764
        private void SDLastUpdatedBalance()
        {
            CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
            DateTime fromDate = DateTime.Today;
            DateTime toDate = DateTime.Today;
            string value = this.Session["ORGANIZATION_ID"].ToString();
            fromDate =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
            toDate =  BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
            DataTable currentAccount18ReportBySearchSD = currentAccountBLL.GetCurrentAccount18ReportBySearchSD(fromDate, toDate, Convert.ToInt16(value));
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
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "date_challan ASC";
                DataTable dtCurrentAccount = defaultView.ToTable();
                dataTable = this.getNewDataTableWithBalance(dtCurrentAccount);
            }
            else
            {
                dataTable = currentAccount18ReportBySearchSD;
                dataTable = this.getNewDataTableWithBalance(dataTable);
            }
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string empty = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("date_challan");
                dataTable2.Columns.Add("trns_desc");
                dataTable2.Columns.Add("challan_no");
                dataTable2.Columns.Add("treasury_deposit");
                dataTable2.Columns.Add("exempt_amount");
                dataTable2.Columns.Add("others", typeof(decimal));
                dataTable2.Columns.Add("pay_amount", typeof(decimal));
                dataTable2.Columns.Add("balance_amount", typeof(decimal));
                dataTable2.Columns.Add("balance_action");
                DataRow dataRow = dataTable.Rows[dataTable.Rows.Count - 1];
                if (dataRow != null)
                {
                    dataTable2.ImportRow(dataRow);
                    if (dataTable2.Rows[0]["balance_amount"] != null)
                    {
                        decimal num = Convert.ToDecimal(dataTable2.Rows[0]["balance_amount"].ToString());
                        this.Session["SD_LAST_AMOUNT"] = num.ToString("0.00");
                    }
                }
            }
        }

        // Token: 0x060000CC RID: 204 RVA: 0x0000C868 File Offset: 0x0000AA68
        private void insertBalance()
        {
            CurrentAccountBLL currentAccountBLL = new CurrentAccountBLL();
            string value = this.Session["ORGANIZATION_ID"].ToString();
            string value2 = this.Session["VAT_LAST_AMOUNT"].ToString();
            string value3 = this.Session["SD_LAST_AMOUNT"].ToString();
            string value4 = this.Session["EMPLOYEE_ID"].ToString();
            DateTime formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY(DateTime.Now.ToString("dd/MM/yyyy"));
            currentAccountBLL.InsertBalance(Convert.ToInt32(value), Convert.ToDecimal(value2), Convert.ToDecimal(value3), Convert.ToInt32(value4), formattedDateMMDDYYYY);
            this.Session["VAT_LAST_AMOUNT"] = null;
            this.Session["SD_LAST_AMOUNT"] = null;
        }

        // Token: 0x060000CD RID: 205 RVA: 0x0000C934 File Offset: 0x0000AB34
        private void getCircleCode()
        {
             int circle_id = Convert.ToInt32(this.Session["commissionarate_id"].ToString());
           // int circle_id = 32;
            DataTable circleCodeForAccount = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
            if (circleCodeForAccount.Rows.Count > 0 && circleCodeForAccount != null)
            {
                string str = circleCodeForAccount.Rows[0]["circle_code"].ToString();
                this.txtCodeNo.Text = "11111" + str + "0311";
            }
        }

        // Token: 0x060000CE RID: 206 RVA: 0x0000C9B4 File Offset: 0x0000ABB4
        protected void drpChallanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Session["ORGBRANCHID"] != null)
            {
                int orgId = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                int circle_id = 0;
                this.txtCodeNo.Text = string.Empty;
                if (this.drpChallanType.SelectedValue == "1" || this.drpChallanType.SelectedValue == "5")
                {
                    DataTable policeStationId2_ = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_.Rows.Count > 0)
                    {
                         circle_id = Convert.ToInt32(policeStationId2_.Rows[0]["thana_id"].ToString());
                       // circle_id = 32;
                    }
                    DataTable circleCodeForAccount = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount.Rows.Count > 0 && circleCodeForAccount != null)
                    {
                        string text = circleCodeForAccount.Rows[0]["comm_code"].ToString();
                        if (text.Length == 1)
                        {
                            this.txtCodeNo.Text = "11133000" + text + "0311";
                        }
                        else if (text.Length == 2)
                        {
                            this.txtCodeNo.Text = "1113300" + text + "0311";
                        }
                        else if (text.Length == 3)
                        {
                            this.txtCodeNo.Text = "111330" + text + "0311";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11133" + text + "0311";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "2" || this.drpChallanType.SelectedValue == "3")
                {
                    DataTable policeStationId2_2 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_2.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_2.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount2 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount2.Rows.Count > 0 && circleCodeForAccount2 != null)
                    {
                        string text2 = circleCodeForAccount2.Rows[0]["comm_code"].ToString();
                        if (text2.Length == 1)
                        {
                            this.txtCodeNo.Text = "11103000" + text2 + "1901";
                        }
                        else if (text2.Length == 2)
                        {
                            this.txtCodeNo.Text = "1110300" + text2 + "1901";
                        }
                        else if (text2.Length == 3)
                        {
                            this.txtCodeNo.Text = "111030" + text2 + "1901";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11103" + text2 + "1901";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "4" || this.drpChallanType.SelectedValue == "6")
                {
                    DataTable policeStationId2_3 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_3.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_3.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount3 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount3.Rows.Count > 0 && circleCodeForAccount3 != null)
                    {
                        string text3 = circleCodeForAccount3.Rows[0]["comm_code"].ToString();
                        if (text3.Length == 1)
                        {
                            this.txtCodeNo.Text = "11133000" + text3 + "0711-0721";
                        }
                        else if (text3.Length == 2)
                        {
                            this.txtCodeNo.Text = "1113300" + text3 + "0711-0721";
                        }
                        else if (text3.Length == 3)
                        {
                            this.txtCodeNo.Text = "111330" + text3 + "0711-0721";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11133" + text3 + "0711-0721";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "7")
                {
                    DataTable policeStationId2_4 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_4.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_4.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount4 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount4.Rows.Count > 0 && circleCodeForAccount4 != null)
                    {
                        string text4 = circleCodeForAccount4.Rows[0]["comm_code"].ToString();
                        if (text4.Length == 1)
                        {
                            this.txtCodeNo.Text = "11133000" + text4 + "0601";
                        }
                        else if (text4.Length == 2)
                        {
                            this.txtCodeNo.Text = "1113300" + text4 + "0601";
                        }
                        else if (text4.Length == 3)
                        {
                            this.txtCodeNo.Text = "111330" + text4 + "0601";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11133" + text4 + "0601";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "8")
                {
                    DataTable policeStationId2_5 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_5.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_5.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount5 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount5.Rows.Count > 0 && circleCodeForAccount5 != null)
                    {
                        string text5 = circleCodeForAccount5.Rows[0]["comm_code"].ToString();
                        if (text5.Length == 1)
                        {
                            this.txtCodeNo.Text = "11133000" + text5 + "2225";
                        }
                        else if (text5.Length == 2)
                        {
                            this.txtCodeNo.Text = "1113300" + text5 + "2225";
                        }
                        else if (text5.Length == 3)
                        {
                            this.txtCodeNo.Text = "111330" + text5 + "2225";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11133" + text5 + "2225";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "9")
                {
                    DataTable policeStationId2_6 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_6.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_6.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount6 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount6.Rows.Count > 0 && circleCodeForAccount6 != null)
                    {
                        string text6 = circleCodeForAccount6.Rows[0]["comm_code"].ToString();
                        if (text6.Length == 1)
                        {
                            this.txtCodeNo.Text = "11103000" + text6 + "2214";
                        }
                        else if (text6.Length == 2)
                        {
                            this.txtCodeNo.Text = "1110300" + text6 + "2214";
                        }
                        else if (text6.Length == 3)
                        {
                            this.txtCodeNo.Text = "111030" + text6 + "2214";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11103" + text6 + "2214";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "10")
                {
                    DataTable policeStationId2_7 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_7.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_7.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount7 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount7.Rows.Count > 0 && circleCodeForAccount7 != null)
                    {
                        string text7 = circleCodeForAccount7.Rows[0]["comm_code"].ToString();
                        if (text7.Length == 1)
                        {
                            this.txtCodeNo.Text = "11103000" + text7 + "2212";
                        }
                        else if (text7.Length == 2)
                        {
                            this.txtCodeNo.Text = "1110300" + text7 + "2212";
                        }
                        else if (text7.Length == 3)
                        {
                            this.txtCodeNo.Text = "111030" + text7 + "2212";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11103" + text7 + "2212";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "11")
                {
                    DataTable policeStationId2_8 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_8.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_8.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount8 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount8.Rows.Count > 0 && circleCodeForAccount8 != null)
                    {
                        string text8 = circleCodeForAccount8.Rows[0]["comm_code"].ToString();
                        if (text8.Length == 1)
                        {
                            this.txtCodeNo.Text = "11103000" + text8 + "2213";
                        }
                        else if (text8.Length == 2)
                        {
                            this.txtCodeNo.Text = "1110300" + text8 + "2213";
                        }
                        else if (text8.Length == 3)
                        {
                            this.txtCodeNo.Text = "111030" + text8 + "2213";
                        }
                        else
                        {
                            this.txtCodeNo.Text = "11103" + text8 + "2213";
                        }
                    }
                }
                if (this.drpChallanType.SelectedValue == "12")
                {
                    DataTable policeStationId2_9 = this.objtrnsTreasuryChallanBLL.getPoliceStationId2_1(orgId);
                    if (policeStationId2_9.Rows.Count > 0)
                    {
                        circle_id = Convert.ToInt32(policeStationId2_9.Rows[0]["thana_id"].ToString());
                    }
                    DataTable circleCodeForAccount9 = this.objtrnsTreasuryChallanBLL.getCircleCodeForAccount(circle_id);
                    if (circleCodeForAccount9.Rows.Count > 0 && circleCodeForAccount9 != null)
                    {
                        string text9 = circleCodeForAccount9.Rows[0]["comm_code"].ToString();
                        if (text9.Length == 1)
                        {
                            this.txtCodeNo.Text = "11103000" + text9 + "0101";
                            return;
                        }
                        if (text9.Length == 2)
                        {
                            this.txtCodeNo.Text = "1110300" + text9 + "0101";
                            return;
                        }
                        if (text9.Length == 3)
                        {
                            this.txtCodeNo.Text = "111030" + text9 + "0101";
                            return;
                        }
                        this.txtCodeNo.Text = "11103" + text9 + "0101";
                    }
                }
            }
        }

        // Token: 0x060000CF RID: 207 RVA: 0x0000D500 File Offset: 0x0000B700
        private void Testing()
        {
            DataTable lastChallan_id = this.objtrnsTreasuryChallanBLL.getLastChallan_id();
            if (lastChallan_id.Rows.Count > 0)
            {
                string challan_id = lastChallan_id.Rows[0]["challan_id"].ToString();
                DataTable dataTable = this.objtrnsTreasuryChallanBLL.showTRChallanFormByChallanNO(challan_id);
                if (dataTable.Rows.Count > 0)
                {
                    string text = "";
                    string text2 = "";
                    double num = 0.0;
                    double num2 = 0.0;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string text3 = ((dataTable.Rows[i]["amount"].ToString() != null) ? Convert.ToDouble(dataTable.Rows[i]["amount"].ToString()) : 0.0).ToString("0.00", CultureInfo.InvariantCulture);
                        string[] array = text3.Split(new char[]
                        {
                        '.'
                        });
                        int num3 = int.Parse(array[0]);
                        int num4 = int.Parse(array[1]);
                        text = dataTable.Rows[i]["code_no"].ToString();
                        text2 += "<tr>";
                        object obj = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj,
                        "<td>",
                        dataTable.Rows[i]["bearer_name_address"],
                        "</td>"
                        });
                        object obj2 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj2,
                        "<td>",
                        dataTable.Rows[i]["bearer_name_designation"],
                        "</td>"
                        });
                        object obj3 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj3,
                        "<td>",
                        dataTable.Rows[i]["deposit_description"],
                        "</td>"
                        });
                        object obj4 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj4,
                        "<td>",
                        dataTable.Rows[i]["instrument_description"],
                        "</td>"
                        });
                        object obj5 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj5,
                        "<td>",
                        num3,
                        "</td>"
                        });
                        object obj6 = text2;
                        text2 = string.Concat(new object[]
                        {
                        obj6,
                        "<td>",
                        num4,
                        "</td>"
                        });
                        text2 += "<td></td>";
                        text2 += "</tr>";
                        num += (double)num3;
                        num2 += (double)num4;
                    }
                    this.lblTRForm.Text = text2;
                    this.lblTotalTK.Text = num.ToString();
                    this.lblTotalPaisa.Text = num2.ToString();
                    this.lblAmountInWord.Text = InWord.ConvertToWordBangla(num + num2 / 100.0);
                    this.lblDate2.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                    ArrayList arrayList = new ArrayList();
                    short num5 = 0;
                    while ((int)num5 < text.Length)
                    {
                        arrayList.Add(text[(int)num5].ToString());
                        num5 += 1;
                    }
                    this.TextBox0.Text = ((!string.IsNullOrEmpty(arrayList[0].ToString())) ? arrayList[0].ToString() : string.Empty);
                    this.TextBox1.Text = ((!string.IsNullOrEmpty(arrayList[1].ToString())) ? arrayList[1].ToString() : string.Empty);
                    this.TextBox2.Text = ((!string.IsNullOrEmpty(arrayList[2].ToString())) ? arrayList[2].ToString() : string.Empty);
                    this.TextBox3.Text = ((!string.IsNullOrEmpty(arrayList[3].ToString())) ? arrayList[3].ToString() : string.Empty);
                    this.TextBox4.Text = ((!string.IsNullOrEmpty(arrayList[4].ToString())) ? arrayList[4].ToString() : string.Empty);
                    this.TextBox5.Text = ((!string.IsNullOrEmpty(arrayList[5].ToString())) ? arrayList[5].ToString() : string.Empty);
                    this.TextBox6.Text = ((!string.IsNullOrEmpty(arrayList[6].ToString())) ? arrayList[6].ToString() : string.Empty);
                    this.TextBox7.Text = ((!string.IsNullOrEmpty(arrayList[7].ToString())) ? arrayList[7].ToString() : string.Empty);
                    this.TextBox8.Text = ((!string.IsNullOrEmpty(arrayList[8].ToString())) ? arrayList[8].ToString() : string.Empty);
                    this.TextBox9.Text = ((!string.IsNullOrEmpty(arrayList[9].ToString())) ? arrayList[9].ToString() : string.Empty);
                    this.TextBox10.Text = ((!string.IsNullOrEmpty(arrayList[10].ToString())) ? arrayList[10].ToString() : string.Empty);
                    this.TextBox11.Text = ((!string.IsNullOrEmpty(arrayList[11].ToString())) ? arrayList[11].ToString() : string.Empty);
                    this.TextBox12.Text = ((!string.IsNullOrEmpty(arrayList[12].ToString())) ? arrayList[12].ToString() : string.Empty);
                }
            }
        }

        // Token: 0x060000D0 RID: 208 RVA: 0x0000DB60 File Offset: 0x0000BD60
        protected bool searchByDateValidation()
        {
            bool result = true;
            if (this.txtFormDate.Text.Trim().Length <= 0)
            {
                this.msgBox.AddMessage("Select From date",MsgBoxs.enmMessageType.Attention);
                this.txtFormDate.Focus();
                result = false;
            }
            if (this.txtToDate.Text.Trim().Length <= 0)
            {
                this.msgBox.AddMessage("Select To date", MsgBoxs.enmMessageType.Attention);
                this.txtToDate.Focus();
                result = false;
            }
            return result;
        }

        

    }
}