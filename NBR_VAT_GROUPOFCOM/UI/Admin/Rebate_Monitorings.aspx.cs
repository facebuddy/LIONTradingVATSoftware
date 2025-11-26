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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class Rebate_Monitorings : Page, IRequiresSessionState
    {
        private DBUtility DBUtil = new DBUtility();

        private string dFormat = "dd/MM/yyyy";

        private CultureInfo provider = CultureInfo.InvariantCulture;

        private decimal total;

        private decimal cashPayment;

        private decimal bankPayment;

        private decimal totalVat;

        private decimal totaldSd;

        private decimal totalVatableAmt;

        private decimal totalPrice;

        private decimal rebatableAmount;

        private decimal totalPriceWithVat;

       

        public Rebate_Monitorings()
        {
        }

        protected void btnImportUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList arrayLists = new ArrayList();
                foreach (GridViewRow row in this.gvImport2.Rows)
                {
                    if (row.RowType != DataControlRowType.DataRow || !(row.Cells[0].FindControl("chkChallan") as CheckBox).Checked)
                    {
                        continue;
                    }
                    string text = row.Cells[1].Text;
                    HiddenField hiddenField = row.FindControl("row_no") as HiddenField;
                    int num = Convert.ToInt32(hiddenField.Value);
                    object[] objArray = new object[] { "update trns_purchase_detail set is_rebatable = true where challan_id = (select challan_id from trns_purchase_master where challan_no = '", text, "') and row_no = ", num };
                    arrayLists.Add(string.Concat(objArray));
                }
                if (arrayLists.Count == 0)
                {
                    this.msgBox.AddMessage("Rebatable Data Update Failed...", MsgBoxs.enmMessageType.Error);
                }
                else if (this.DBUtil.ExecuteBatchDML(arrayLists))
                {
                    this.msgBox.AddMessage("Rebatable Data Update Successfully...", MsgBoxs.enmMessageType.Success);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
            try
            {
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), this.dFormat, this.provider);
                dateTime.ToString("yyyy-MM-dd");
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), this.dFormat, this.provider);
                dateTime1.AddDays(1).ToString("yyyy-MM-dd");
                DataTable partyByftDate = rebatMonitoringBLL.getPartyByftDate(dateTime, dateTime1);
                if (partyByftDate != null && partyByftDate.Rows.Count > 0)
                {
                    this.drpParty.DataSource = partyByftDate;
                    this.drpParty.DataTextField = partyByftDate.Columns["party_name"].ToString();
                    this.drpParty.DataValueField = partyByftDate.Columns["party_id"].ToString();
                    this.drpParty.DataBind();
                    ListItem listItem = new ListItem("--- SELECT ---", "-99");
                    this.drpParty.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
            long num = (long)0;
            try
            {
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), this.dFormat, this.provider);
                dateTime.ToString("yyyy-MM-dd");
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), this.dFormat, this.provider);
                dateTime1.AddDays(1).ToString("yyyy-MM-dd");
                if (this.drpParty.SelectedValue != "-99")
                {
                    num = Convert.ToInt64(this.drpParty.SelectedItem.Value);
                }
                this.Session["LOCAL_PURCHASE_DATA"] = new ArrayList();
                this.localPurchase.Visible = true;
                this.loadLocalPurchaseData(dateTime, dateTime1, num);
                this.loadLocalPurchaseGV();
                this.Session["IMPORT_DATA"] = new ArrayList();
                this.import.Visible = true;
                this.loadImportData(dateTime, dateTime1, num);
                this.loadImportGV();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "";
                string str = DateTime.Now.ToString("dd/MM/yyyy");
                decimal num = new decimal(0);
                foreach (GridViewRow row in this.gvPurchase2.Rows)
                {
                    if (row.RowType != DataControlRowType.DataRow)
                    {
                        continue;
                    }
                    text = row.Cells[1].Text;
                    break;
                }
                ArrayList arrayLists = new ArrayList();
                num = Convert.ToDecimal(this.txtTotalRebateable.Text.Trim());
                object[] objArray = new object[] { "update trns_purchase_master set rebate_amt = ", num, " AND rebate_taken_amt = ", num, " AND rebate_date='", str, "' where challan_id = (select challan_id from trns_purchase_master where challan_no = '", text, "')" };
                arrayLists.Add(string.Concat(objArray));
                if (arrayLists == null)
                {
                    this.msgBox.AddMessage("You are Not Select any Purchase Record...", MsgBoxs.enmMessageType.Success);
                }
                else if (this.DBUtil.ExecuteBatchDML(arrayLists))
                {
                    this.msgBox.AddMessage("Data Updated Successfully...", MsgBoxs.enmMessageType.Success);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void grdPaymentHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    this.cashPayment += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "cash_amount"));
                    this.bankPayment += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "bank_amount"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[2].Text = string.Format("{0:0.00#}", this.cashPayment);
                    e.Row.Cells[3].Text = string.Format("{0:0.00#}", this.bankPayment);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void gvImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
            string text = "";
            GridViewRow selectedRow = this.gvImport.SelectedRow;
            if (selectedRow.RowType == DataControlRowType.DataRow)
            {
                text = selectedRow.Cells[2].Text;
                DataTable importHistory = rebatMonitoringBLL.GetImportHistory(text);
                this.gvImport2.DataSource = importHistory;
                this.gvImport2.DataBind();
                this.modalPopupForImportDetail.Show();
            }
        }

        protected void gvLocalPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
                string text = "";
                int num = 0;
                GridViewRow selectedRow = this.gvLocalPurchase.SelectedRow;
                if (selectedRow.RowType == DataControlRowType.DataRow)
                {
                    num = Convert.ToInt32(this.gvLocalPurchase.DataKeys[selectedRow.RowIndex].Value);
                    text = selectedRow.Cells[2].Text;
                    DataTable localPurchaseHistory = rebatMonitoringBLL.GetLocalPurchaseHistory(num);
                    this.gvPurchase2.DataSource = localPurchaseHistory;
                    this.gvPurchase2.DataBind();
                    DataTable paymentHistory = rebatMonitoringBLL.GetPaymentHistory(text);
                    this.grdPaymentHistory.DataSource = paymentHistory;
                    this.grdPaymentHistory.DataBind();
                    decimal num1 = new decimal(0);
                    decimal num2 = new decimal(0);
                    decimal num3 = new decimal(0);
                    string str = "";
                    decimal num4 = new decimal(0);
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    foreach (GridViewRow row in this.gvPurchase2.Rows)
                    {
                        if (row.RowType != DataControlRowType.DataRow)
                        {
                            continue;
                        }
                        string text1 = row.Cells[1].Text;
                        str = row.Cells[2].Text.ToString();
                        if (row.Cells[10].Text.Trim() == "No")
                        {
                            continue;
                        }
                        num5 += Convert.ToDecimal(row.Cells[6].Text.Trim());
                    }
                    DateTime dateTime = DateTime.ParseExact(str.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string str1 = dateTime.ToString("yyyy");
                    string str2 = dateTime.ToString("MM");
                    string str3 = string.Concat(str2, "/01/", str1);
                    DateTime dateTime1 = Convert.ToDateTime(str3).AddMonths(3);
                    string str4 = dateTime1.AddDays(-1).ToString("dd/MM/yyyy");
                    DateTime dateTime2 = DateTime.ParseExact(str3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateTime3 = DateTime.ParseExact(str4, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (GridViewRow gridViewRow in this.grdPaymentHistory.Rows)
                    {
                        if (gridViewRow.RowType != DataControlRowType.DataRow)
                        {
                            continue;
                        }
                        DateTime dateTime4 = DateTime.ParseExact(gridViewRow.Cells[1].Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        if (!(dateTime4 >= dateTime2) || !(dateTime4 <= dateTime3))
                        {
                            continue;
                        }
                        num1 += Convert.ToDecimal(gridViewRow.Cells[2].Text.Trim());
                        num2 += Convert.ToDecimal(gridViewRow.Cells[3].Text.Trim());
                    }
                    num3 = num1 + num2;
                    GridViewRow footerRow = this.gvPurchase2.FooterRow;
                    if (footerRow.RowType == DataControlRowType.Footer)
                    {
                        num6 = Convert.ToDecimal(footerRow.Cells[9].Text.Trim());
                    }
                    num4 = (num5 / num6) * num3;
                    this.txtTotalRebateable.Text = num4.ToString("0.00");
                    this.modalPopupForLocalPurchase.Show();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void gvPurchase2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    this.totalVat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "vat"));
                    this.totaldSd += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "sd"));
                    this.totalPrice += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "price"));
                    this.totalPriceWithVat += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "price_total"));
                    this.rebatableAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "rebatable_amount"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[6].Text = string.Format("{0:0.00#}", this.totalVat);
                    e.Row.Cells[7].Text = string.Format("{0:0.00#}", this.totaldSd);
                    e.Row.Cells[8].Text = string.Format("{0:0.00#}", this.totalPrice);
                    e.Row.Cells[9].Text = string.Format("{0:0.00#}", this.totalPriceWithVat);
                    e.Row.Cells[11].Text = string.Format("{0:0.00#}", this.rebatableAmount);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void loadImportData(DateTime fDate, DateTime tDate, long partyId)
        {
            RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
            RebatMonitoringDAO rebatMonitoringDAO = new RebatMonitoringDAO();
            ArrayList item = null;
            try
            {
                DataTable importedHistory = rebatMonitoringBLL.getImportedHistory(fDate, tDate, partyId);
                if (importedHistory.Rows.Count > 0)
                {
                    for (short i = 0; i < importedHistory.Rows.Count; i = (short)(i + 1))
                    {
                        item = (ArrayList)this.Session["IMPORT_DATA"] ?? new ArrayList();
                        rebatMonitoringDAO = new RebatMonitoringDAO();
                        string challanNo = "";
                        rebatMonitoringDAO.RowID = Convert.ToInt64(importedHistory.Rows[i]["RowId"].ToString());
                        rebatMonitoringDAO.ChallanNo = importedHistory.Rows[i]["challan_no"].ToString();
                        rebatMonitoringDAO.ChallanDate = importedHistory.Rows[i]["challan_date"].ToString();
                        rebatMonitoringDAO.TotalAmount = Convert.ToDouble(importedHistory.Rows[i]["total_price"].ToString());
                        rebatMonitoringDAO.Vat = Convert.ToDouble(importedHistory.Rows[i]["Vat"].ToString());
                        rebatMonitoringDAO.SD = Convert.ToDouble(importedHistory.Rows[i]["sd"].ToString());
                        rebatMonitoringDAO.CD = Convert.ToDouble(importedHistory.Rows[i]["cd"].ToString());
                        rebatMonitoringDAO.RD = Convert.ToDouble(importedHistory.Rows[i]["rd"].ToString());
                        rebatMonitoringDAO.ATV = Convert.ToDouble(importedHistory.Rows[i]["atv"].ToString());
                        rebatMonitoringDAO.AIT = Convert.ToDouble(importedHistory.Rows[i]["ait"].ToString());
                        rebatMonitoringDAO.TTI = Convert.ToDouble(importedHistory.Rows[i]["tti"].ToString());
                        rebatMonitoringDAO.IsRebatable = importedHistory.Rows[i]["is_rebatable"].ToString();
                        rebatMonitoringDAO.PartyName = importedHistory.Rows[i]["party"].ToString();
                        if (item.Count == 0)
                        {
                            item.Add(rebatMonitoringDAO);
                        }
                        else
                        {
                            for (int j = 0; j < item.Count; j++)
                            {
                                if (rebatMonitoringDAO.ChallanNo == ((RebatMonitoringDAO)item[j]).ChallanNo)
                                {
                                    challanNo = rebatMonitoringDAO.ChallanNo;
                                }
                            }
                            if (challanNo == "")
                            {
                                item.Add(rebatMonitoringDAO);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["IMPORT_DATA"] = item;
        }

        private void loadImportGV()
        {
            ArrayList item = (ArrayList)this.Session["IMPORT_DATA"];
            this.gvImport.DataSource = item;
            this.gvImport.DataBind();
        }

        private void loadLocalPurchaseData(DateTime fDate, DateTime tDate, long partyId)
        {
            RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
            RebatMonitoringDAO rebatMonitoringDAO = new RebatMonitoringDAO();
            ArrayList item = null;
            try
            {
                DataTable localPurchasedHistory = rebatMonitoringBLL.getLocalPurchasedHistory(fDate, tDate, partyId);
                if (localPurchasedHistory.Rows.Count > 0)
                {
                    for (short i = 0; i < localPurchasedHistory.Rows.Count; i = (short)(i + 1))
                    {
                        item = (ArrayList)this.Session["LOCAL_PURCHASE_DATA"] ?? new ArrayList();
                        rebatMonitoringDAO = new RebatMonitoringDAO();
                        string challanNo = "";
                        rebatMonitoringDAO.RowID = Convert.ToInt64(localPurchasedHistory.Rows[i]["RowId"].ToString());
                        rebatMonitoringDAO.ChallanNo = localPurchasedHistory.Rows[i]["challan_no"].ToString();
                        rebatMonitoringDAO.ChallanDate = localPurchasedHistory.Rows[i]["challan_date"].ToString();
                        rebatMonitoringDAO.TotalAmount = Convert.ToDouble(localPurchasedHistory.Rows[i]["total_price"].ToString());
                        rebatMonitoringDAO.Vat = Convert.ToDouble(localPurchasedHistory.Rows[i]["Vat"].ToString());
                        rebatMonitoringDAO.SD = Convert.ToDouble(localPurchasedHistory.Rows[i]["sd"].ToString());
                        rebatMonitoringDAO.IsRebatable = localPurchasedHistory.Rows[i]["is_rebatable"].ToString();
                        rebatMonitoringDAO.PartyName = localPurchasedHistory.Rows[i]["party"].ToString();
                        if (item.Count == 0)
                        {
                            item.Add(rebatMonitoringDAO);
                        }
                        else
                        {
                            for (int j = 0; j < item.Count; j++)
                            {
                                if (rebatMonitoringDAO.ChallanNo == ((RebatMonitoringDAO)item[j]).ChallanNo)
                                {
                                    challanNo = rebatMonitoringDAO.ChallanNo;
                                }
                            }
                            if (challanNo == "")
                            {
                                item.Add(rebatMonitoringDAO);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["LOCAL_PURCHASE_DATA"] = item;
        }

        private void loadLocalPurchaseGV()
        {
            ArrayList item = (ArrayList)this.Session["LOCAL_PURCHASE_DATA"];
            this.gvLocalPurchase.DataSource = item;
            this.gvLocalPurchase.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!base.IsPostBack)
                {
                    this.Session["LOCAL_PURCHASE_DATA"] = new ArrayList();
                    this.Session["IMPORT_DATA"] = new ArrayList();
                    ListItem listItem = new ListItem("--- SELECT ---", "-99");
                    this.drpParty.Items.Insert(0, listItem);
                    this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
                    this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }
    }
}