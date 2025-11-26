using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class VDS_Monitorings : Page, IRequiresSessionState
    {
       
        private BLL.Utility DBUtil = new BLL.Utility();

        private string dFormat = "dd/MM/yyyy";

        private CultureInfo provider = CultureInfo.InvariantCulture;

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

        public VDS_Monitorings()
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
                    object[] objArray = new object[] { "update trns_purchase_detail set is_source_tax_deduct = true where challan_id = (select challan_id from trns_purchase_master where challan_no = '", text, "') and row_no = ", num };
                    arrayLists.Add(string.Concat(objArray));
                }
                if (arrayLists.Count == 0)
                {
                    this.msgBox.AddMessage("VDS Data Update Failed...", MsgBoxs.enmMessageType.Error);
                }
                else if (this.DBUtil.ExecuteBatchDML(arrayLists))
                {
                    this.msgBox.AddMessage("VDS Data Update Successfully...", MsgBoxs.enmMessageType.Success);
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
                string str = dateTime.ToString("yyyy-MM-dd");
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), this.dFormat, this.provider);
                string str1 = dateTime1.AddDays(1).ToString("yyyy-MM-dd");
                if (this.drpParty.SelectedValue != "-99")
                {
                    num = Convert.ToInt64(this.drpParty.SelectedItem.Value);
                }
                this.localPurchase.Visible = true;
                this.loadLocalPurchaseData(str, str1, num);
                this.loadLocalPurchaseGV();
                this.import.Visible = true;
                this.loadImportData(str, str1, num);
                this.loadImportGV();
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "VDS_Monitoring.aspx", "btnShow_Click");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList arrayLists = new ArrayList();
                foreach (GridViewRow row in this.gvPurchase2.Rows)
                {
                    if (row.RowType != DataControlRowType.DataRow || !(row.Cells[0].FindControl("chkChallan") as CheckBox).Checked)
                    {
                        continue;
                    }
                    string text = row.Cells[1].Text;
                    HiddenField hiddenField = row.FindControl("row_no") as HiddenField;
                    int num = Convert.ToInt32(hiddenField.Value);
                    object[] objArray = new object[] { "update trns_purchase_detail set is_source_tax_deduct = true where challan_id = (select challan_id from trns_purchase_master where challan_no = '", text, "') and row_no = ", num };
                    arrayLists.Add(string.Concat(objArray));
                }
                if (arrayLists == null)
                {
                    this.msgBox.AddMessage("You are Not Select any Purchase Record...", MsgBoxs.enmMessageType.Success);
                }
                else if (this.DBUtil.ExecuteBatchDML(arrayLists))
                {
                    this.msgBox.AddMessage("VDS Data Update Successfully...", MsgBoxs.enmMessageType.Success);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
                string text = "";
                GridViewRow selectedRow = this.gvImport.SelectedRow;
                if (selectedRow.RowType == DataControlRowType.DataRow)
                {
                    text = selectedRow.Cells[2].Text;
                    DataTable importHistoryVDS = rebatMonitoringBLL.GetImportHistoryVDS(text);
                    this.gvImport2.DataSource = importHistoryVDS;
                    this.gvImport2.DataBind();
                    this.modalPopupForImportDetail.Show();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "VDS_Monitoring", "gvImport_SelectedIndexChanged", fileLineNumber);
            }
        }

        protected void gvLocalPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
                string text = "";
                GridViewRow selectedRow = this.gvLocalPurchase.SelectedRow;
                if (selectedRow.RowType == DataControlRowType.DataRow)
                {
                    text = selectedRow.Cells[2].Text;
                    DataTable localPurchaseHistoryVDS = rebatMonitoringBLL.GetLocalPurchaseHistoryVDS(text);
                    this.gvPurchase2.DataSource = localPurchaseHistoryVDS;
                    this.gvPurchase2.DataBind();
                    this.modalPopupForLocalPurchase.Show();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "VDS_Monitoring", "gvLocalPurchase_SelectedIndexChanged", fileLineNumber);
            }
        }

        private void loadImportData(string fDate, string tDate, long partyId)
        {
            RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
            RebatMonitoringDAO rebatMonitoringDAO = new RebatMonitoringDAO();
            ArrayList arrayLists = null;
            try
            {
                DataTable importHistoryVDS = rebatMonitoringBLL.getImportHistoryVDS(fDate, tDate, partyId);
                if (importHistoryVDS.Rows.Count > 0)
                {
                    for (short i = 0; i < importHistoryVDS.Rows.Count; i = (short)(i + 1))
                    {
                        if (arrayLists == null)
                        {
                            arrayLists = new ArrayList();
                        }
                        rebatMonitoringDAO = new RebatMonitoringDAO();
                        string challanNo = "";
                        rebatMonitoringDAO.RowID = Convert.ToInt64(importHistoryVDS.Rows[i]["RowId"].ToString());
                        rebatMonitoringDAO.ChallanNo = importHistoryVDS.Rows[i]["challan_no"].ToString();
                        rebatMonitoringDAO.ChallanDate = importHistoryVDS.Rows[i]["challan_date"].ToString();
                        rebatMonitoringDAO.TotalAmount = Convert.ToDouble(importHistoryVDS.Rows[i]["total_price"].ToString());
                        rebatMonitoringDAO.Amount = Convert.ToDouble(importHistoryVDS.Rows[i]["amount"].ToString());
                        rebatMonitoringDAO.Vat = Convert.ToDouble(importHistoryVDS.Rows[i]["Vat"].ToString());
                        rebatMonitoringDAO.SD = Convert.ToDouble(importHistoryVDS.Rows[i]["sd"].ToString());
                        rebatMonitoringDAO.CD = Convert.ToDouble(importHistoryVDS.Rows[i]["cd"].ToString());
                        rebatMonitoringDAO.RD = Convert.ToDouble(importHistoryVDS.Rows[i]["rd"].ToString());
                        rebatMonitoringDAO.ATV = Convert.ToDouble(importHistoryVDS.Rows[i]["atv"].ToString());
                        rebatMonitoringDAO.AIT = Convert.ToDouble(importHistoryVDS.Rows[i]["ait"].ToString());
                        rebatMonitoringDAO.TTI = Convert.ToDouble(importHistoryVDS.Rows[i]["tti"].ToString());
                        rebatMonitoringDAO.IsVDS = importHistoryVDS.Rows[i]["is_vds"].ToString();
                        rebatMonitoringDAO.PartyName = importHistoryVDS.Rows[i]["party"].ToString();
                        if (arrayLists.Count == 0)
                        {
                            arrayLists.Add(rebatMonitoringDAO);
                        }
                        else
                        {
                            for (int j = 0; j < arrayLists.Count; j++)
                            {
                                if (rebatMonitoringDAO.ChallanNo == ((RebatMonitoringDAO)arrayLists[j]).ChallanNo)
                                {
                                    challanNo = rebatMonitoringDAO.ChallanNo;
                                }
                            }
                            if (challanNo == "")
                            {
                                arrayLists.Add(rebatMonitoringDAO);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "VDS_Monitoring.aspx", "loadImportData");
            }
            this.Session["IMPORT_DATA"] = arrayLists;
        }

        private void loadImportGV()
        {
            this.gvImport.DataSource = null;
            ArrayList item = (ArrayList)this.Session["IMPORT_DATA"];
            this.gvImport.DataSource = item;
            this.gvImport.DataBind();
        }

        private void loadLocalPurchaseData(string fDate, string tDate, long partyId)
        {
            RebatMonitoringBLL rebatMonitoringBLL = new RebatMonitoringBLL();
            RebatMonitoringDAO rebatMonitoringDAO = new RebatMonitoringDAO();
            ArrayList arrayLists = null;
            try
            {
                DataTable localPurchaseHistoryVDS = rebatMonitoringBLL.getLocalPurchaseHistoryVDS(fDate, tDate, partyId);
                if (localPurchaseHistoryVDS.Rows.Count > 0)
                {
                    for (short i = 0; i < localPurchaseHistoryVDS.Rows.Count; i = (short)(i + 1))
                    {
                        if (arrayLists == null)
                        {
                            arrayLists = new ArrayList();
                        }
                        rebatMonitoringDAO = new RebatMonitoringDAO();
                        string challanNo = "";
                        rebatMonitoringDAO.RowID = Convert.ToInt64(localPurchaseHistoryVDS.Rows[i]["RowId"].ToString());
                        rebatMonitoringDAO.ChallanNo = localPurchaseHistoryVDS.Rows[i]["challan_no"].ToString();
                        rebatMonitoringDAO.ChallanDate = localPurchaseHistoryVDS.Rows[i]["challan_date"].ToString();
                        rebatMonitoringDAO.TotalAmount = Convert.ToDouble(localPurchaseHistoryVDS.Rows[i]["total_price"].ToString());
                        rebatMonitoringDAO.Amount = Convert.ToDouble(localPurchaseHistoryVDS.Rows[i]["amount"].ToString());
                        rebatMonitoringDAO.Vat = Convert.ToDouble(localPurchaseHistoryVDS.Rows[i]["Vat"].ToString());
                        rebatMonitoringDAO.SD = Convert.ToDouble(localPurchaseHistoryVDS.Rows[i]["sd"].ToString());
                        rebatMonitoringDAO.IsVDS = localPurchaseHistoryVDS.Rows[i]["is_vds"].ToString();
                        rebatMonitoringDAO.PartyName = localPurchaseHistoryVDS.Rows[i]["party"].ToString();
                        if (arrayLists.Count == 0)
                        {
                            arrayLists.Add(rebatMonitoringDAO);
                        }
                        else
                        {
                            for (int j = 0; j < arrayLists.Count; j++)
                            {
                                if (rebatMonitoringDAO.ChallanNo == ((RebatMonitoringDAO)arrayLists[j]).ChallanNo)
                                {
                                    challanNo = rebatMonitoringDAO.ChallanNo;
                                }
                            }
                            if (challanNo == "")
                            {
                                arrayLists.Add(rebatMonitoringDAO);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "VDS_Monitoring.aspx", "loadLocalPurchaseData");
            }
            this.Session["LOCAL_PURCHASE_DATA"] = arrayLists;
        }

        private void loadLocalPurchaseGV()
        {
            this.gvLocalPurchase.DataSource = null;
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