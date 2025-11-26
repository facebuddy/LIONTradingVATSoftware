using AjaxControlToolkit;
using ASP;
using Microsoft.CSharp.RuntimeBinder;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Caching;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Sale
{
    public partial class SaleChallan_11s : Page, IRequiresSessionState
    {



        private Collection<DropDownList> drpPropertyCollection = new Collection<DropDownList>();

        private Collection<Label> lblPropertyCollection = new Collection<Label>();

        private DBUtility conDB = new DBUtility();

        private ItemBLL item = new ItemBLL();

        private AddItemBLL dbBLL = new AddItemBLL();

        private AddUserBLL ubll = new AddUserBLL();

        private UserBLL uBll = new UserBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        private OrgRegistrationInfoDAO orgRegInfo = new OrgRegistrationInfoDAO();

        private OrgRegistrationInfoBLL orgbll = new OrgRegistrationInfoBLL();

        private CSVXMLBLL dbBLLLL = new CSVXMLBLL();

        private AddItemBLL objItemBLL = new AddItemBLL();

        private SaleBLL objBLL = new SaleBLL();

        private SetItemPropertyBLL itmProperty = new SetItemPropertyBLL();

        private DataTable dtAmount = new DataTable();

        private ContructualProductionBLL objCPBLL = new ContructualProductionBLL();

        private UserPermissionBLL permissionBLL = new UserPermissionBLL();

        public ArrayList objectPropertyNameList = new ArrayList();

        public ArrayList tableDataList = new ArrayList();

        public ArrayList tableNameList = new ArrayList();

        public ArrayList validationList = new ArrayList();

        public short status = 1;

        private DataTable dtGiftDiscountPlan = new DataTable();

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

        public SaleChallan_11s()
        {
        }

        private void AddApproveDetailDataInGrid()
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LISTA"];
                this.gvApprvItem.DataSource = item;
                this.gvApprvItem.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void AddDetailDataInGrid()
        {
            ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LIST"];
            this.gvItem.DataSource = item;
            this.gvItem.DataBind();
        }

        private void AddGiftDetailDataInGrid()
        {
            ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
            this.gvGiftItem.DataSource = item;
            this.gvGiftItem.DataBind();
        }

        private void APIforPurchase()
        {
            SaleMasterDAON saleMasterDAON = new SaleMasterDAON();
            ArrayList item = (ArrayList)base.Cache["SALE_MASTER_DETAIL"];
            saleMasterDAON = (SaleMasterDAON)item[0];
            if (this.objBLL.getPurchasePartyAPI(saleMasterDAON.PartyID, saleMasterDAON.PartyTIN.Trim()).Rows.Count >= 1)
            {
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["SALE_DETAIL_LISTF"];
                string str = string.Format("https://localhost:44353/login", new object[0]);
                WebRequest webRequest = WebRequest.Create(str);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                string str1 = JsonConvert.SerializeObject(this.GetCred());
                using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(str1);
                    streamWriter.Flush();
                    streamWriter.Close();
                    using (StreamReader streamReader = new StreamReader(((HttpWebResponse)webRequest.GetResponse()).GetResponseStream()))
                    {
                        dynamic obj = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
                        string str2 = (string)obj.token;
                    }
                }
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44353/api/purchase");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                string str7 = "";
                string str8 = "";
                string str9 = "";
                string str10 = "";
                double cashAmount = 0;
                string str11 = "";
                string str12 = "";
                string str13 = "";
                string str14 = "";
                string str15 = "";
                cashAmount = saleMasterDAON.CashAmount + saleMasterDAON.BankAmount;
                str4 = string.Concat("\"", this.Session["ORGANIZATION_ID"].ToString(), "\"");
                str5 = string.Concat("\"", this.Session["ORGANIZATION_BIN"].ToString(), "\"");
                str3 = string.Concat("\"", saleMasterDAON.PartyTIN, "\"");
                str6 = string.Concat("\"", saleMasterDAON.ChallanNo, "\"");
                DateTime challanDate = saleMasterDAON.ChallanDate;
                str7 = string.Concat("\"", challanDate.ToString("yyyy-MM-dd"), "\"");
                str8 = string.Concat("\"", saleMasterDAON.TotalBillAmount, "\"");
                str9 = string.Concat("\"", cashAmount, "\"");
                str10 = string.Concat("\"", saleMasterDAON.CreditAmount, "\"");
                string[] strArrays = new string[] { " [{\r\n\r\n        \"OrgRegistrationNo\" : ", str3, ",\r\n        \"OrgBranchBinNo\" : ", str3, ",\r\n        \"log\" : \"\",\r\n        \"PartyName\" : ", str4, ",\r\n        \"PartyBin\" : ", str5, ",\r\n        \"PartyNid\" : \"\",\r\n        \"ChallanNo\" : ", str6, ",\r\n        \"ChallanDate\" : ", str7, ",\r\n        \"TotalAmount\" : ", str8, ",\r\n        \"PaidAmount\" : ", str9, ",\r\n        \"CreditAmount\" : ", str10, ",\r\n        \"PaymentFinished\" : true,\r\n       \"IsAPITransaction\" :true,\r\n       \"IsAPITransactionAccept\" :false,\r\n        \"DetailData\" : [" };
                str14 = string.Concat(strArrays);
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    SaleDetailDAON saleDetailDAON = (SaleDetailDAON)arrayLists[i];
                    str11 = string.Concat("\"", saleDetailDAON.ItemName, "\"");
                    str12 = string.Concat("\"", saleDetailDAON.HS_Code, "\"");
                    str13 = string.Concat("\"", saleDetailDAON.UnitName, "\"");
                    object[] unitPriceBDT = new object[] { "{\r\n                                 \"log\": \"\",\r\n                                \"ItemName\":", str11, ",\r\n                                \"HSCode\":", str12, ",\r\n                                \"Unit\": ", str13, ",\r\n                                \"UnitPrice\":", saleDetailDAON.UnitPriceBDT, ",\r\n                                \"Quantity\":", saleDetailDAON.Quantity, ",\r\n                                \"IsVatCollected\" : true,\r\n                                \"VatPercentage\":", saleDetailDAON.VATRate, ",\r\n                                \"VatAmount\":", saleDetailDAON.VAT, ",\r\n                                \"IsSDCollected\" : false,\r\n                                \"SDPercentage\":", saleDetailDAON.SDRate, ",\r\n                                \"SDAmount\":", saleDetailDAON.SD, ",\r\n                                \"AitPercentage\":", saleDetailDAON.AITRate, ",\r\n                                \"AitAmount\":", saleDetailDAON.AIT, "\r\n                            }," };
                    str15 = string.Concat(unitPriceBDT);
                }
                char[] chrArray = new char[] { ',' };
                string str16 = string.Concat(str14, str15.TrimEnd(chrArray), "]}]");
                using (StreamWriter streamWriter1 = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter1.Write(str16);
                    streamWriter1.Flush();
                    streamWriter1.Close();
                    using (StreamReader streamReader1 = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
                    {
                        streamReader1.ReadToEnd();
                    }
                }
            }
        }

        private bool apprvStageValidation()
        {
            if (!(this.getApproveStage() == "F") || !(this.drpAgreement.SelectedValue == "-99") || (!(this.txtCashAmount.Text == "") || !(this.txtChequeAmount.Text == "") || !(this.txtbKashAmount.Text == "") || !(this.txtEFTAmount.Text == "") || !(this.txtPayOrderAmount.Text == "") || !(this.txtCreditAmount.Text == "") || !(this.txtRocketAmount.Text == "") || !(this.txtTPTAmount.Text == "") || !(this.txtDebitCartAmount.Text == "") || !(this.txtOthersAmount.Text == "")) && (!(this.txtCashAmount.Text == "") || !(this.txtChequeAmount.Text == "0") || !(this.txtbKashAmount.Text == "0") || !(this.txtEFTAmount.Text == "0") || !(this.txtPayOrderAmount.Text == "0") || !(this.txtCreditAmount.Text == "0") || !(this.txtRocketAmount.Text == "") || !(this.txtTPTAmount.Text == "0") || !(this.txtDebitCartAmount.Text == "0") || !(this.txtOthersAmount.Text == "0")))
            {
                return true;
            }
            this.msgBox.AddMessage("Please Add Payment first.", MsgBoxs.enmMessageType.Attention);
            return false;
        }

        private void BackCalculation()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                Convert.ToInt16(strArrays[0]);
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                num2 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text) : 1);
                num = (this.lblVAT.Text != "" ? Convert.ToDouble(this.lblVAT.Text.Trim()) : 0);
                num1 = (this.lblSD.Text != "" ? Convert.ToDouble(this.lblSD.Text.Trim()) : 0);
                num3 = (this.txtPriceIncludingVat.Text != "" ? Convert.ToDouble(this.txtPriceIncludingVat.Text.Trim()) : 0);
                num4 = num3 * num / (100 + num);
                num5 = (num3 - num4) * num1 / (100 + num1);
                num6 = num3 - (num4 - num5);
                num7 = num2 * num6;
                this.txtQuantity.Text = num2.ToString();
                this.tbTotalVAT.Text = num4.ToString("N");
                this.txtTotalSD.Text = num5.ToString("N");
                this.txtUnitPrice.Text = num6.ToString("N");
                this.txtTotalPrice.Text = num7.ToString("N");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void btnAddGiftItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.giftValidations())
                {
                    this.fillGiftDetailProperties();
                    this.AddGiftDetailDataInGrid();
                    this.ClearGiftDetailControls();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validation())
                {
                    this.fillDetailProperties();
                    this.AddDetailDataInGrid();
                    this.GetTotalSaleValue();
                    for (int i = 0; i < this.gvAddtnProperty.Rows.Count; i++)
                    {
                        CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[i].FindControl("chkChallan");
                        checkBox.Enabled = false;
                    }
                    this.ClearDetailControlsValue();
                    this.ClearCheckBox();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.drpRegType.SelectedValue == "1")
                {
                    this.mpeParty.Hide();
                    ScriptManager.RegisterStartupScript(this, base.GetType(), "onclick", "javascript:window.open( '../Others/Add_Trans_Party.aspx','_blank');", true);
                }
                else if (this.drpRegType.SelectedValue != "5")
                {
                    this.mpeParty.Hide();
                    this.msgBox.AddMessage("Please Select Not Registered Registration type first.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.mpeParty.Show();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearDetailControlsValue();
                this.txtTotalSalePrice.Text = "";
                this.Session["SALE_DETAIL_LIST"] = new ArrayList();
                this.Session["GIFT_SALE_DETAIL_LIST"] = new ArrayList();
                this.gvItem.DataSource = null;
                this.gvItem.DataBind();
                this.lblMessage.Text = "";
                this.setDetaiAddMode();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "btnClear_Click", fileLineNumber);
            }
        }

        protected void btndraftPrint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, base.GetType(), "onclick", "javascript:window.open( '../Sale/SaleChallan_11_Report.aspx?print=D','_blank');", true);
        }

        protected void btnExcelSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = "";
                this.btnExcelSave.Visible = false;
                SaleBLL saleBLL = new SaleBLL();
                SaleMasterDAON saleMasterDAON = new SaleMasterDAON();
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["SALE_Master_LIST"];
                if (saleMasterDAON != null)
                {
                    ArrayList item = new ArrayList();
                    item = (ArrayList)this.Session["SALES_EXCEL"];
                    if (item == null || item.Count == 0)
                    {
                        this.gvItem.DataSource = null;
                        this.gvItem.DataBind();
                        this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                    }
                    else if (this.btnSave.Text == SaleChallan_11s.enmBtnText.Save.ToString())
                    {
                        int num = 0;
                        foreach (SaleMasterDAON arrayList in arrayLists)
                        {
                            SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                            saleDetailDAON = (SaleDetailDAON)item[num];
                            saleBLL.InsertSaleExcelData(arrayList, saleDetailDAON);
                            num++;
                        }
                        this.chkExcelImport.Checked = false;
                        this.chkManualInput.Checked = true;
                        this.gvExcelFile.DataSource = null;
                        this.gvExcelFile.DataBind();
                    }
                }
                else
                {
                    this.msgBox.AddMessage("Please insert master data properly.", MsgBoxs.enmMessageType.Error);
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "btnExcelSave_Click");
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/UI/Sale/SaleChallan_11_Report.aspx");
        }

        protected void btnRefreshChallan_Click(object sender, EventArgs e)
        {
            this.ClearAllControlsValue();
            this.GetNextChallanNo();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                this.ItemBalancevs();
                this.lblMessage.Text = "";
                if (this.MasterValidation())
                {
                    SaleBLL saleBLL = new SaleBLL();
                    SaleMasterDAON saleMasterDAON = new SaleMasterDAON();
                    saleMasterDAON = this.GetInserMasterValues(saleMasterDAON);
                    if (saleMasterDAON != null)
                    {
                        int num = Convert.ToInt16(this.drpParty.SelectedValue);
                        DataTable partyCredlmt = saleBLL.getPartyCredlmt(num);
                        double num1 = Convert.ToDouble(partyCredlmt.Rows[0]["credit_limit"].ToString());
                        if (num1 == 0 || saleMasterDAON.CreditAmount <= num1)
                        {
                            ArrayList arrayLists = new ArrayList();
                            arrayLists = this.GetInsertGiftDetails();
                            Dictionary<int, int> item = (Dictionary<int, int>)this.Session["chkProperty"];
                            if (this.gvAddtnProperty.Rows.Count <= 0 || item.Count != 0)
                            {
                                ArrayList arrayLists1 = new ArrayList();
                                arrayLists1 = (ArrayList)this.Session["SALE_DETAIL_LISTF"];
                                if (arrayLists1 == null || arrayLists1.Count == 0)
                                {
                                    this.gvItem.DataSource = null;
                                    this.gvItem.DataBind();
                                    this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                                    return;
                                }
                                else if (this.btnSave.Text == SaleChallan_11s.enmBtnText.Save.ToString())
                                {
                                    Convert.ToDouble(this.Session["VAT_M"]);
                                    Convert.ToDouble(this.Session["SD_M"]);
                                    this.getVat();
                                    this.getSD();
                                    str = saleBLL.InsertSaleDataWithOrWithoutGift(saleMasterDAON, arrayLists1, arrayLists, item);
                                    if (str == null)
                                    {
                                        this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                                    }
                                    else
                                    {
                                        this.Session["challanId"] = str;
                                        if (this.chkDiscard.Checked)
                                        {
                                            this.msgBox.AddMessage("Sale Challan Discarded Successfully.", MsgBoxs.enmMessageType.Success);
                                        }
                                        else
                                        {
                                            this.msgBox.AddMessage("Sale Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                        }
                                        this.APIforPurchase();
                                        this.ClearAllControlsValue();
                                        this.ClearCheckBox();
                                        this.GetNextChallanNo();
                                        if ((new ChallanBLL()).GetApproverStage().Rows.Count < 1)
                                        {
                                            this.btnPrint.Visible = true;
                                            this.cashMemo.Text = "<a target='_blank' href='SaleChallan_11_Phrma_Report.aspx'>Cash Memo</a>";
                                            this.ltCustomCashMemo.Text = "<a target='_blank' href='CustomCashMemo.aspx'>Custom Cash Memo</a>";
                                        }
                                        else
                                        {
                                            this.Session["SALE_DETAIL_LISTA"] = new ArrayList();
                                            this.LoadSaleData();
                                        }
                                        this.VATLastUpdatedBalance();
                                        this.SDLastUpdatedBalance();
                                        this.insertBalance();
                                    }
                                }
                            }
                            else
                            {
                                this.msgBox.AddMessage("Please Select Property from Grid.", MsgBoxs.enmMessageType.Error);
                                return;
                            }
                        }
                        else
                        {
                            this.txtCreditAmount.Focus();
                            this.msgBox.AddMessage("Credit Limit Exceeds.", MsgBoxs.enmMessageType.Error);
                            return;
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
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "btnSave_Click");
            }
        }

        protected void btnSubSave_Click(object sender, EventArgs e)
        {
            if (!this.NewPartyValidation())
            {
                this.mpeParty.Show();
                return;
            }
            TransPartyDAO transPartyDAO = new TransPartyDAO();
            TransPartyBLL transPartyBLL = new TransPartyBLL();
            transPartyDAO.OrganizationID = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            transPartyDAO.TransPartyName = Utilities.checkForSingleQuotes(this.txtParty.Text.Trim());
            transPartyDAO.PartAddress = this.txtPrtaddress.Text;
            transPartyDAO.nationalIdNo = this.txtNationalIdNo.Text.Trim();
            transPartyDAO.RegType = 5;
            transPartyDAO.IsCustomer = true;
            transPartyDAO.BusinessInfo = 11;
            transPartyDAO.UserID = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
            if (!transPartyBLL.insertTransParty(transPartyDAO))
            {
                this.mpeParty.Show();
                return;
            }
            this.msgBox.AddMessage("Party Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
            this.mpeParty.Hide();
            this.txtParty.Text = "";
            this.txtPrtaddress.Text = "";
            this.txtNationalIdNo.Text = "";
            this.GetPartyInfoRegistrationWise(Convert.ToInt16(this.drpRegType.SelectedValue.Trim()));
            this.GetPartyInfo();
        }

        protected void btnUpdateTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = "";
                string approveStage = "";
                if (this.apprvStageValidation())
                {
                    int num = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ChallanID"]);
                    ArrayList arrayLists = new ArrayList();
                    arrayLists = (ArrayList)this.Session["Sale_DETAIL_LIST"];
                    if (arrayLists == null || arrayLists.Count == 0)
                    {
                        this.gvItem.DataSource = null;
                        this.gvItem.DataBind();
                        this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    else
                    {
                        approveStage = this.getApproveStage();
                        if (!this.objBLL.UpdateSale(approveStage, arrayLists, num))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Sale Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.ClearAllControlsValue();
                            this.ClearCheckBox();
                            this.GetNextChallanNo();
                            if (approveStage == "F")
                            {
                                this.btnPrint.Visible = true;
                                this.cashMemo.Text = "<a target='_blank' href='SaleChallan_11_Phrma_Report.aspx'>Cash Memo</a>";
                                this.ltCustomCashMemo.Text = "<a target='_blank' href='CustomCashMemo.aspx'>Custom Cash Memo</a>";
                            }
                            this.VATLastUpdatedBalance();
                            this.SDLastUpdatedBalance();
                            this.insertBalance();
                            this.Session["SALE_DETAIL_LISTA"] = new ArrayList();
                            this.LoadSaleData();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "Purchase_Challan_6.3", "btnSave_Click");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                ChallanBLL challanBLL = new ChallanBLL();
                Dictionary<string, bool> strs = new Dictionary<string, bool>();
                Dictionary<short, string> nums = new Dictionary<short, string>()
            {
                { 1, "Regular Registered (Vat)" },
                { 4, "Registered For Turnover" },
                { 5, "Not Registered" },
                { 7, "Procurement Provider" },
                { 8, "Trader" }
            };
                ArrayList arrayLists = new ArrayList();
                this.tableNameList = new ArrayList();
                this.objectPropertyNameList = new ArrayList();
                this.validationList = new ArrayList();
                this.gvExcelFile.DataSource = null;
                this.gvExcelFile.DataBind();
                string stringCellValue = "";
                string str = "";
                string str1 = "";
                string str2 = "SalesData";
                string lower = Path.GetExtension(this.FileUpload1.FileName).ToLower();
                if (string.IsNullOrEmpty(lower))
                {
                    this.msgBox.AddMessage(" File Path not Found! Please Choose Your File. ", MsgBoxs.enmMessageType.Attention);
                    return;
                }
                else
                {
                    HttpServerUtility server = base.Server;
                    DateTime now = DateTime.UtcNow.AddHours(6);
                    str1 = server.MapPath(string.Concat("~/CSV/Sale", now.ToString("ddMMyyyy_HHmmssFFF"), lower));
                    this.FileUpload1.SaveAs(str1);
                    this.Label11.Text = string.Concat(this.FileUpload1.FileName, "'s Data showing into the GridView");
                    try
                    {
                        HSSFWorkbook hSSFWorkbook = null;
                        ISheet sheet = null;
                        hSSFWorkbook = new HSSFWorkbook(new FileStream(str1, FileMode.Open, FileAccess.Read));
                        for (int i = 0; i < hSSFWorkbook.NumberOfSheets; i++)
                        {
                            ISheet sheetAt = hSSFWorkbook.GetSheetAt(i);
                            if (str2.ToUpper().Equals(sheetAt.SheetName.ToUpper()))
                            {
                                sheet = sheetAt;
                            }
                        }
                        SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                        IRow row = sheet.GetRow(1);
                        IRow rows = sheet.GetRow(0);
                        for (int j = 1; j <= row.LastCellNum; j++)
                        {
                            ICell cell = rows.GetCell(j - 1);
                            ICell cell1 = row.GetCell(j - 1);
                            stringCellValue = cell.StringCellValue;
                            str = cell1.StringCellValue;
                            if (saleDetailDAON.GetType().GetProperty(stringCellValue) != null && !string.IsNullOrEmpty(str))
                            {
                                this.objectPropertyNameList.Add(stringCellValue);
                                this.tableNameList.Add(str);
                                strs.Add(stringCellValue, false);
                                BoundField boundField = new BoundField()
                                {
                                    HeaderText = str,
                                    DataField = stringCellValue
                                };
                                this.gvExcelFile.Columns.Add(boundField);
                            }
                        }
                        DataFormatter dataFormatter = new DataFormatter();
                        int lastRowNum = sheet.LastRowNum;
                        for (int k = 2; k <= lastRowNum; k++)
                        {
                            IRow row1 = sheet.GetRow(k);
                            bool flag = true;
                            for (int l = 0; l < this.objectPropertyNameList.Count; l++)
                            {
                                ICell cell2 = row1.GetCell(l, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                                if (row1.GetCell(l) != null && cell2.CellType != CellType.Blank)
                                {
                                    flag = false;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                            Dictionary<string, bool> strs1 = new Dictionary<string, bool>();
                            foreach (string key in strs.Keys)
                            {
                                strs1.Add(key, strs[key]);
                            }
                            saleDetailDAON = new SaleDetailDAON();
                            string empty = string.Empty;
                            int num = -1;
                            foreach (string str3 in this.objectPropertyNameList)
                            {
                                num++;
                                if (saleDetailDAON.GetType().GetProperty(str3).PropertyType.Name == "Boolean")
                                {
                                    bool flag1 = false;
                                    if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        flag1 = Convert.ToBoolean(Convert.ToInt16(row1.GetCell(num).ToString()));
                                    }
                                    saleDetailDAON.GetType().GetProperty(str3).SetValue(saleDetailDAON, flag1, null);
                                }
                                else if (saleDetailDAON.GetType().GetProperty(str3).PropertyType.Name == "Int16")
                                {
                                    short num1 = 0;
                                    if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        num1 = Convert.ToInt16(row1.GetCell(num));
                                    }
                                    saleDetailDAON.GetType().GetProperty(str3).SetValue(saleDetailDAON, num1, null);
                                }
                                else if (saleDetailDAON.GetType().GetProperty(str3).PropertyType.Name != "Decimal")
                                {
                                    string empty1 = string.Empty;
                                    row1.GetCell(num).SetCellType(CellType.String);
                                    if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        empty1 = row1.GetCell(num).StringCellValue;
                                    }
                                    saleDetailDAON.GetType().GetProperty(str3).SetValue(saleDetailDAON, empty1, null);
                                    if (str3 == "Party_Name")
                                    {
                                        DataTable party = this.objBLL.GetParty(empty1.ToUpper());
                                        if (party.Rows.Count > 0)
                                        {
                                            saleDetailDAON.partyID = Convert.ToInt16(party.Rows[0]["party_id"]);
                                        }
                                    }
                                    if (str3 == "Item_Name")
                                    {
                                        DataTable itemIdByItem = this.objBLL.getItemIdByItem(empty1.ToUpper());
                                        if (itemIdByItem.Rows.Count > 0)
                                        {
                                            saleDetailDAON.ItemID = Convert.ToInt32(itemIdByItem.Rows[0]["item_id"]);
                                            DataTable itemType = this.dbBLLLL.getItemType(saleDetailDAON.ItemID);
                                            DataTable purchasetypeByItemId = (new ChallanBLL()).GetPurchasetypeByItemId(saleDetailDAON.ItemID);
                                            string str4 = "";
                                            if (purchasetypeByItemId.Rows.Count > 0)
                                            {
                                                str4 = purchasetypeByItemId.Rows[0]["purchase_type"].ToString();
                                            }
                                            string empty2 = string.Empty;
                                            string empty3 = string.Empty;
                                            if (itemType.Rows.Count > 0)
                                            {
                                                empty2 = itemType.Rows[0]["product_type"].ToString();
                                            }
                                            if (empty2 == "C")
                                            {
                                                empty3 = "F";
                                            }
                                            if (empty3 == "")
                                            {
                                                empty3 = str4;
                                            }
                                            saleDetailDAON.UnitID = Convert.ToInt32(itemIdByItem.Rows[0]["unit_id"]);
                                            saleDetailDAON.SaleUnitID = Convert.ToInt32(itemIdByItem.Rows[0]["unit_id"]);
                                            saleDetailDAON.AIT = new decimal(0);
                                            saleDetailDAON.PropStk = "0";
                                            DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", null);
                                            DataTable dataTable = new DataTable();
                                            dataTable = this.objBLL.GetSaleAvailableStockN(saleDetailDAON.ItemID, str4, dateTime, empty3);
                                            if (dataTable != null && dataTable.Rows.Count > 0)
                                            {
                                                if (dataTable.Rows[0]["item_type"].ToString() != "I")
                                                {
                                                    this.lblAvailStock.Text = "0";
                                                }
                                                else
                                                {
                                                    this.lblAvailStock.Text = dataTable.Rows[0]["availStock"].ToString();
                                                    this.lblavlStock.Text = string.Concat(dataTable.Rows[0]["availStock"].ToString(), " ", this.lblUnit.Text);
                                                }
                                                saleDetailDAON.AvailStock = Convert.ToDouble(dataTable.Rows[0]["availStock"]);
                                            }
                                        }
                                    }
                                    if (str3 != "Payment_Type")
                                    {
                                        continue;
                                    }
                                    if (empty1 != "paid")
                                    {
                                        saleDetailDAON.CreditAmount = Convert.ToDouble(saleDetailDAON.Priceincluding_VAT);
                                        saleDetailDAON.IsPaymentFinished = false;
                                    }
                                    else
                                    {
                                        saleDetailDAON.CashAmount = Convert.ToDouble(saleDetailDAON.Priceincluding_VAT);
                                        saleDetailDAON.IsPaymentFinished = true;
                                    }
                                }
                                else
                                {
                                    decimal num2 = new decimal(0);
                                    if (row1.GetCell(num) != null && row1.GetCell(num, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        num2 = Convert.ToDecimal(row1.GetCell(num).NumericCellValue);
                                    }
                                    saleDetailDAON.GetType().GetProperty(str3).SetValue(saleDetailDAON, num2, null);
                                }
                            }
                            saleDetailDAON.UserIdInsert = Convert.ToInt16(this.Session["employee_id"]);
                            saleDetailDAON.RowNo = Convert.ToInt16(this.validationList.Count);
                            arrayLists.Add(saleDetailDAON);
                        }
                        this.gvExcelFile.DataSource = arrayLists;
                        this.gvExcelFile.DataBind();
                        hSSFWorkbook.Close();
                    }
                    catch (Exception exception)
                    {
                        this.msgBox.AddMessage(exception.Message, MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                    this.Session["SALES_EXCEL"] = arrayLists;
                    this.GetInserMasterValuesforExcel();
                }
            }
            catch (Exception exception2)
            {
                Exception exception1 = exception2;
                Utilities.KillExcelFileProcess();
                BLL.Utility.InsertErrorTrack(exception1.Message, "SaleChallan_11s.aspx", "btnUpload_Click");
            }
            Utilities.KillExcelFileProcess();
        }

        private void CalculatePrices()
        {
            try
            {
                if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                {
                    if (this.hdItemType.Value != "I")
                    {
                        if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0)
                        {
                            Label str = this.lblTotalPrice;
                            double num = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                            str.Text = num.ToString("N2");
                        }
                        if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || Convert.ToDouble(this.lblTotalPrice.Text) <= 0)
                        {
                            this.lblTotalSD.Text = "0.00";
                            this.txtTotalSD.Text = "0.00";
                        }
                        else
                        {
                            TextBox textBox = this.txtTotalSD;
                            double num1 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                            textBox.Text = num1.ToString("0.00");
                            Label label = this.lblTotalSD;
                            double num2 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                            label.Text = num2.ToString("N2");
                        }
                        if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                        {
                            if (this.lblProductType.Text != "W")
                            {
                                Label str1 = this.lblTotalVAT;
                                double num3 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                str1.Text = num3.ToString("N2");
                                TextBox textBox1 = this.tbTotalVAT;
                                double num4 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                textBox1.Text = num4.ToString("0.00");
                            }
                            else
                            {
                                Label label1 = this.lblTotalVAT;
                                double num5 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                label1.Text = num5.ToString("N2");
                                TextBox str2 = this.tbTotalVAT;
                                double num6 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                str2.Text = num6.ToString("0.00");
                            }
                        }
                        Label label2 = this.lblTotalSalePrc;
                        double num7 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                        label2.Text = num7.ToString("N2");
                    }
                    else
                    {
                        if (Convert.ToDouble(this.txtUnitPrice.Text) <= 0)
                        {
                            this.lblTotalSalePrc.Text = "0.00";
                        }
                        else
                        {
                            Label str3 = this.lblTotalSalePrc;
                            double num8 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                            str3.Text = num8.ToString("0.00");
                        }
                        Label label3 = this.lblTotalPrice;
                        double num9 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                        label3.Text = num9.ToString("N2");
                        if (this.chkExempted.Checked)
                        {
                            this.lblTotalSD.Text = "0.00";
                            this.lblTotalVAT.Text = "0.00";
                            this.lblTotalSalePrc.Text = this.lblTotalPrice.Text;
                        }
                        else
                        {
                            if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0)
                            {
                                Label str4 = this.lblTotalPrice;
                                double num10 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                                str4.Text = num10.ToString("N2");
                            }
                            if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || Convert.ToDouble(this.lblTotalPrice.Text) <= 0)
                            {
                                AddItemBLL addItemBLL = new AddItemBLL();
                                int num11 = 0;
                                decimal num12 = new decimal(0);
                                decimal num13 = new decimal(0);
                                decimal num14 = new decimal(0);
                                decimal num15 = new decimal(0);
                                string str5 = "";
                                str5 = Convert.ToString(this.drpItem.SelectedValue);
                                string[] strArrays = str5.Split(new char[] { '.' });
                                num11 = Convert.ToInt16(strArrays[0]);
                                DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num11);
                                if (itemIsTeriff.Rows.Count > 0 && Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                                {
                                    DataTable itemVatAmountForSale = addItemBLL.getItemVatAmountForSale(num11);
                                    if (itemVatAmountForSale.Rows.Count > 0)
                                    {
                                        num14 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["tax_value"]);
                                        num12 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["per"]);
                                        num13 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                        num15 = (num14 * num13) / num12;
                                    }
                                }
                                if (num14 <= new decimal(0))
                                {
                                    this.lblTotalSD.Text = "0.00";
                                    this.tbTotalVAT.Text = "0.00";
                                }
                                else
                                {
                                    this.lblTotalSD.Text = "0.00";
                                    this.tbTotalVAT.Text = num15.ToString();
                                    this.lblTotalVAT.Text = num15.ToString();
                                }
                            }
                            else
                            {
                                Label label4 = this.lblTotalSD;
                                double num16 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                label4.Text = num16.ToString("N2");
                                TextBox textBox2 = this.txtTotalSD;
                                double num17 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                textBox2.Text = num17.ToString("0.00");
                            }
                            if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                            {
                                if (this.lblProductType.Text != "W")
                                {
                                    Label label5 = this.lblTotalVAT;
                                    double num18 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    label5.Text = num18.ToString("N2");
                                    TextBox textBox3 = this.tbTotalVAT;
                                    double num19 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox3.Text = num19.ToString("0.00");
                                }
                                else
                                {
                                    Label str6 = this.lblTotalVAT;
                                    double num20 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    str6.Text = num20.ToString("N2");
                                    TextBox textBox4 = this.tbTotalVAT;
                                    double num21 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox4.Text = num21.ToString("0.00");
                                }
                            }
                            Label label6 = this.lblTotalSalePrc;
                            double num22 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.tbTotalVAT.Text);
                            label6.Text = num22.ToString("N2");
                        }
                        if (this.chkInexplicitExport.Checked || this.chkZeroRate.Checked)
                        {
                            this.lblTotalSD.Text = "0.00";
                            this.lblTotalVAT.Text = "0.00";
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void CalculatePricesIncludingVatChange()
        {
            try
            {
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                {
                    if (this.hdItemType.Value != "I")
                    {
                        if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0)
                        {
                            Label str = this.lblTotalPrice;
                            double num3 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                            str.Text = num3.ToString("N2");
                        }
                        if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || Convert.ToDouble(this.lblTotalPrice.Text) <= 0)
                        {
                            this.lblTotalSD.Text = "0.00";
                            this.txtTotalSD.Text = "0.00";
                        }
                        else
                        {
                            TextBox textBox = this.txtTotalSD;
                            double num4 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                            textBox.Text = num4.ToString("0.00");
                            Label label = this.lblTotalSD;
                            double num5 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                            label.Text = num5.ToString("N2");
                        }
                        if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                        {
                            if (this.lblProductType.Text != "W")
                            {
                                Label str1 = this.lblTotalVAT;
                                double num6 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                str1.Text = num6.ToString("N2");
                                TextBox textBox1 = this.tbTotalVAT;
                                double num7 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                textBox1.Text = num7.ToString("0.00");
                            }
                            else
                            {
                                Label label1 = this.lblTotalVAT;
                                double num8 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                label1.Text = num8.ToString("N2");
                                TextBox str2 = this.tbTotalVAT;
                                double num9 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                str2.Text = num9.ToString("0.00");
                            }
                        }
                        Label label2 = this.lblTotalSalePrc;
                        double num10 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                        label2.Text = num10.ToString("N2");
                    }
                    else
                    {
                        if (Convert.ToDouble(this.txtUnitPrice.Text) <= 0)
                        {
                            this.lblTotalSalePrc.Text = "0.00";
                        }
                        else
                        {
                            Label str3 = this.lblTotalSalePrc;
                            double num11 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                            str3.Text = num11.ToString("N2");
                        }
                        Label label3 = this.lblTotalPrice;
                        double num12 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                        label3.Text = num12.ToString("N2");
                        if (this.chkExempted.Checked)
                        {
                            this.lblTotalSD.Text = "0.00";
                            this.lblTotalVAT.Text = "0.00";
                            this.lblTotalSalePrc.Text = this.lblTotalPrice.Text;
                        }
                        else
                        {
                            if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0)
                            {
                                Label str4 = this.lblTotalPrice;
                                double num13 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                                str4.Text = num13.ToString("N2");
                            }
                            if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || Convert.ToDouble(this.lblTotalPrice.Text) <= 0)
                            {
                                AddItemBLL addItemBLL = new AddItemBLL();
                                int num14 = 0;
                                decimal num15 = new decimal(0);
                                decimal num16 = new decimal(0);
                                decimal num17 = new decimal(0);
                                decimal num18 = new decimal(0);
                                string str5 = "";
                                str5 = Convert.ToString(this.drpItem.SelectedValue);
                                string[] strArrays = str5.Split(new char[] { '.' });
                                num14 = Convert.ToInt16(strArrays[0]);
                                DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num14);
                                if (itemIsTeriff.Rows.Count > 0 && Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                                {
                                    DataTable itemVatAmountForSale = addItemBLL.getItemVatAmountForSale(num14);
                                    if (itemVatAmountForSale.Rows.Count > 0)
                                    {
                                        num17 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["tax_value"]);
                                        num15 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["per"]);
                                        num16 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                        num18 = (num17 * num16) / num15;
                                    }
                                }
                                if (num17 <= new decimal(0))
                                {
                                    this.lblTotalSD.Text = "0.00";
                                    this.tbTotalVAT.Text = "0.00";
                                }
                                else
                                {
                                    this.lblTotalSD.Text = "0.00";
                                    this.tbTotalVAT.Text = num18.ToString();
                                    this.lblTotalVAT.Text = num18.ToString("N2");
                                }
                            }
                            else
                            {
                                Label label4 = this.lblTotalSD;
                                double num19 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                label4.Text = num19.ToString("N2");
                                TextBox textBox2 = this.txtTotalSD;
                                double num20 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                textBox2.Text = num20.ToString("0.00");
                            }
                            if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                            {
                                if (this.lblProductType.Text != "W")
                                {
                                    Label label5 = this.lblTotalVAT;
                                    double num21 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    label5.Text = num21.ToString("N2");
                                    TextBox textBox3 = this.tbTotalVAT;
                                    double num22 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox3.Text = num22.ToString("0.00");
                                }
                                else
                                {
                                    Label str6 = this.lblTotalVAT;
                                    double num23 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    str6.Text = num23.ToString("N2");
                                    TextBox textBox4 = this.tbTotalVAT;
                                    double num24 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox4.Text = num24.ToString("0.00");
                                }
                            }
                            Label label6 = this.lblTotalSalePrc;
                            double num25 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.tbTotalVAT.Text);
                            label6.Text = num25.ToString("N2");
                        }
                        if (this.chkInexplicitExport.Checked || this.chkZeroRate.Checked)
                        {
                            this.lblTotalSD.Text = "0.00";
                            this.lblTotalVAT.Text = "0.00";
                        }
                    }
                }
                num1 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                Convert.ToDouble(this.txtQuantity.Text);
                Convert.ToDouble(this.txtUnitPrice.Text);
                num = (!(this.txtUnitPrice.Text != "") || !(this.lblSD.Text != "") ? 0 : Convert.ToDouble(this.txtUnitPrice.Text.Trim()) * (Convert.ToDouble(this.lblSD.Text) / 100));
                if (this.txtUnitPrice.Text != "" && this.lblSD.Text != "")
                {
                    Convert.ToDouble(this.txtUnitPrice.Text.Trim());
                    double num26 = Convert.ToDouble(this.lblVAT.Text) / 100;
                }
                num2 = Convert.ToDouble(this.txtQuantity.Text.Trim()) * Convert.ToDouble(this.txtUnitPrice.Text.Trim());
                Convert.ToDouble(this.tbTotalVAT.Text);
                Convert.ToDouble(this.txtTotalSD.Text);
                this.lblTotalPrice.Text = num1.ToString("N2");
                this.txtTotalPrice.Text = num1.ToString();
                Label str7 = this.lblTotalSalePrc;
                double num27 = num1 + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                str7.Text = num27.ToString("N2");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void CalculatePricesQuantityChange()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                double num = 0;
                int num1 = 0;
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                num1 = Convert.ToInt16(strArrays[0]);
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                double num9 = 0;
                num5 = (this.txtFinalQuantity.Text != "" ? Convert.ToDouble(this.txtFinalQuantity.Text.Trim()) : 0);
                num6 = (this.lblVAT.Text != "" ? Convert.ToDouble(this.lblVAT.Text.Trim()) : 0);
                if (this.Label9.Text != " Per Unit.")
                {
                    if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                    {
                        if (this.hdItemType.Value != "I")
                        {
                            if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0)
                            {
                                Label label = this.lblTotalPrice;
                                double num10 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                                label.Text = num10.ToString("N2");
                            }
                            if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || Convert.ToDouble(this.lblTotalPrice.Text) <= 0)
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.txtTotalSD.Text = "0.00";
                            }
                            else
                            {
                                TextBox textBox = this.txtTotalSD;
                                double num11 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                textBox.Text = num11.ToString("0.00");
                                Label str1 = this.lblTotalSD;
                                double num12 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                str1.Text = num12.ToString("N2");
                            }
                            if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                            {
                                if (this.lblProductType.Text != "W")
                                {
                                    Label label1 = this.lblTotalVAT;
                                    double num13 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    label1.Text = num13.ToString("N2");
                                    TextBox textBox1 = this.tbTotalVAT;
                                    double num14 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox1.Text = num14.ToString("0.00");
                                    num2 = (this.txtUnitPrice.Text != "" ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0);
                                    num3 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                                    num4 = (this.lblAIT.Text != "" ? Convert.ToDouble(this.lblAIT.Text.Trim()) : 0);
                                    TextBox str2 = this.txtAIT;
                                    double num15 = num2 * num3 * num4 / 100;
                                    str2.Text = num15.ToString("N");
                                }
                                else
                                {
                                    Label label2 = this.lblTotalVAT;
                                    double num16 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    label2.Text = num16.ToString("N2");
                                    TextBox textBox2 = this.tbTotalVAT;
                                    double num17 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox2.Text = num17.ToString("0.00");
                                    num2 = (this.txtUnitPrice.Text != "" ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0);
                                    num3 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                                    num4 = (this.lblAIT.Text != "" ? Convert.ToDouble(this.lblAIT.Text.Trim()) : 0);
                                    TextBox str3 = this.txtAIT;
                                    double num18 = num2 * num3 * num4 / 100;
                                    str3.Text = num18.ToString("N");
                                }
                            }
                            num2 = (this.txtUnitPrice.Text != "" ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0);
                            num3 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                            num4 = (this.lblAIT.Text != "" ? Convert.ToDouble(this.lblAIT.Text.Trim()) : 0);
                            TextBox textBox3 = this.txtAIT;
                            double num19 = num2 * num3 * num4 / 100;
                            textBox3.Text = num19.ToString("N");
                            Label label3 = this.lblTotalSalePrc;
                            double num20 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                            label3.Text = num20.ToString("0.00");
                        }
                        else
                        {
                            if (Convert.ToDouble(this.txtUnitPrice.Text) <= 0)
                            {
                                this.lblTotalSalePrc.Text = "0.00";
                            }
                            else
                            {
                                Label str4 = this.lblTotalSalePrc;
                                double num21 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                                str4.Text = num21.ToString("N2");
                            }
                            Label label4 = this.lblTotalPrice;
                            double num22 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                            label4.Text = num22.ToString("N2");
                            if (this.chkExempted.Checked)
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.lblTotalVAT.Text = "0.00";
                                this.lblTotalSalePrc.Text = this.lblTotalPrice.Text;
                            }
                            else
                            {
                                if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0)
                                {
                                    Label str5 = this.lblTotalPrice;
                                    double num23 = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                                    str5.Text = num23.ToString("N2");
                                }
                                if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || Convert.ToDouble(this.lblTotalPrice.Text) <= 0)
                                {
                                    decimal num24 = new decimal(0);
                                    decimal num25 = new decimal(0);
                                    decimal num26 = new decimal(0);
                                    decimal num27 = new decimal(0);
                                    decimal num28 = new decimal(0);
                                    decimal num29 = new decimal(0);
                                    decimal num30 = new decimal(0);
                                    decimal num31 = new decimal(0);
                                    decimal num32 = new decimal(0);
                                    num26 = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text) : new decimal(1));
                                    num24 = (this.lblVAT.Text != "" ? Convert.ToDecimal(this.lblVAT.Text.Trim()) : new decimal(0));
                                    num25 = (this.lblSD.Text != "" ? Convert.ToDecimal(this.lblSD.Text.Trim()) : new decimal(0));
                                    num31 = (this.txtUnitPrice.Text != "" ? Convert.ToDecimal(this.txtUnitPrice.Text.Trim()) : new decimal(0));
                                    num32 = num26 * num31;
                                    num30 = (num31 * num26) * (num25 / new decimal(100));
                                    num27 = num30 + (num31 * num26);
                                    num29 = num27 * (num24 / new decimal(100));
                                    num28 = ((num31 * num26) + num30) + num29;
                                    this.txtTotalPrice.Text = num32.ToString();
                                    this.txtQuantity.Text = num26.ToString();
                                    this.tbTotalVAT.Text = num29.ToString();
                                    this.txtTotalSD.Text = num30.ToString();
                                    this.txtPriceIncludingVat.Text = num28.ToString();
                                }
                                else
                                {
                                    Label label5 = this.lblTotalSD;
                                    double num33 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                    label5.Text = num33.ToString("N2");
                                    TextBox textBox4 = this.txtTotalSD;
                                    double num34 = Convert.ToDouble(this.lblTotalPrice.Text) * (Convert.ToDouble(this.lblSD.Text) / 100);
                                    textBox4.Text = num34.ToString("0.00");
                                }
                                if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                                {
                                    if (this.lblProductType.Text != "W")
                                    {
                                        Label str6 = this.lblTotalVAT;
                                        double num35 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                        str6.Text = num35.ToString("N2");
                                        TextBox textBox5 = this.tbTotalVAT;
                                        double num36 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                        textBox5.Text = num36.ToString("0.00");
                                        num2 = (this.txtUnitPrice.Text != "" ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0);
                                        num3 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                                        num4 = (this.lblAIT.Text != "" ? Convert.ToDouble(this.lblAIT.Text.Trim()) : 0);
                                        TextBox textBox6 = this.txtAIT;
                                        double num37 = num2 * num3 * num4 / 100;
                                        textBox6.Text = num37.ToString("N");
                                    }
                                    else
                                    {
                                        Label label6 = this.lblTotalVAT;
                                        double num38 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                        label6.Text = num38.ToString("N2");
                                        TextBox str7 = this.tbTotalVAT;
                                        double num39 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                        str7.Text = num39.ToString("0.00");
                                        num2 = (this.txtUnitPrice.Text != "" ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0);
                                        num3 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                                        num4 = (this.lblAIT.Text != "" ? Convert.ToDouble(this.lblAIT.Text.Trim()) : 0);
                                        TextBox textBox7 = this.txtAIT;
                                        double num40 = num2 * num3 * num4 / 100;
                                        textBox7.Text = num40.ToString("N");
                                    }
                                }
                                num2 = (this.txtUnitPrice.Text != "" ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0);
                                num3 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                                num4 = (this.lblAIT.Text != "" ? Convert.ToDouble(this.lblAIT.Text.Trim()) : 0);
                                TextBox str8 = this.txtAIT;
                                double num41 = num2 * num3 * num4 / 100;
                                str8.Text = num41.ToString("N");
                                Label label7 = this.lblTotalSalePrc;
                                double num42 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.tbTotalVAT.Text);
                                label7.Text = num42.ToString("N2");
                            }
                            if (this.chkInexplicitExport.Checked || this.chkZeroRate.Checked)
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.lblTotalVAT.Text = "0.00";
                            }
                        }
                        decimal num43 = new decimal(0);
                        num43 = Convert.ToDecimal(this.lblTotalPrice.Text);
                        if (this.chkTaxDeducted.Checked)
                        {
                            if (num43 == new decimal(0) || num43 > new decimal(10000))
                            {
                                this.chkTaxDeducted.Checked = true;
                            }
                            else
                            {
                                this.chkTaxDeducted.Checked = false;
                            }
                        }
                        if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                        {
                            if ((this.txtdiscountpct.Text != "" ? Convert.ToDecimal(this.txtdiscountpct.Text) : new decimal(0)) > new decimal(0))
                            {
                                if ((this.txtDiscount.Text != "" ? Convert.ToDecimal(this.txtDiscount.Text) : new decimal(0)) > new decimal(0))
                                {
                                    TextBox textBox8 = this.txtDiscount;
                                    decimal num44 = ((Convert.ToDecimal(this.txtQuantity.Text) * Convert.ToDecimal(this.txtUnitPrice.Text)) * Convert.ToDecimal(this.txtdiscountpct.Text)) / new decimal(100);
                                    textBox8.Text = num44.ToString();
                                }
                            }
                        }
                    }
                    DataTable itemIsMRP = addItemBLL.getItemIsMRP(num1);
                    if (itemIsMRP.Rows.Count > 0 && Convert.ToBoolean(itemIsMRP.Rows[0]["is_mrp"]))
                    {
                        num = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtUnitPrice.Text);
                        this.txtTotalPrice.Text = num.ToString();
                        double num45 = 0;
                        double num46 = 0;
                        num46 = (!(this.txtUnitPrice.Text != "") || !(this.lblVAT.Text != "") ? 0 : Convert.ToDouble(this.txtUnitPrice.Text.Trim()) * (Convert.ToDouble(this.lblVAT.Text) / 100));
                        num45 = (!(this.txtUnitPrice.Text != "") || !(this.lblVAT.Text != "") ? 0 : (Convert.ToDouble(this.txtUnitPrice.Text.Trim()) + num46) * (Convert.ToDouble(this.lblVAT.Text) / 100));
                        double num47 = 0;
                        double num48 = 0;
                        double num49 = 0;
                        double num50 = 0;
                        double num51 = 0;
                        num47 = (this.txtQuantity.Text == "" ? 0 : Convert.ToDouble(this.txtQuantity.Text.Trim()));
                        num48 = (this.txtUnitPrice.Text == "" ? 0 : Convert.ToDouble(this.txtUnitPrice.Text.Trim()));
                        num50 = num45 * num47;
                        num51 = num46 * num47;
                        num49 = num47 * num48 + num51 + num50;
                        this.txtPriceIncludingVat.Text = num49.ToString("0.00");
                    }
                    this.txtvdsamount.Text = this.tbTotalVAT.Text;
                }
                else
                {
                    num7 = num5 * num6;
                    this.tbTotalVAT.Text = num7.ToString("N2");
                    num8 = num5 * (this.txtUnitPrice.Text != "" ? Convert.ToDouble(this.txtUnitPrice.Text.Trim()) : 0);
                    this.txtTotalPrice.Text = num8.ToString("N2");
                    num9 = num8 + num7;
                    this.txtPriceIncludingVat.Text = num9.ToString("N2");
                    this.lblTotalPrice.Text = num8.ToString("N2");
                    this.lblTotalVAT.Text = num7.ToString("N2");
                    this.lblTotalSD.Text = ((this.lblTotalSD.Text != "" ? Convert.ToDouble(this.lblTotalSD.Text.Trim()) : 0)).ToString("N2");
                    this.lblTotalSalePrc.Text = this.txtPriceIncludingVat.Text.Trim();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void CalculatePricesUnitChange()
        {
            decimal num;
            try
            {
                this.txtQuantity.Text = this.txtFinalQuantity.Text;
                int num1 = 0;
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                num1 = Convert.ToInt16(strArrays[0]);
                AddItemBLL addItemBLL = new AddItemBLL();
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                num2 = Convert.ToDecimal(this.txtUnitPrice.Text);
                if (this.Label9.Text != " Per Unit.")
                {
                    if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                    {
                        if (this.hdItemType.Value != "I")
                        {
                            if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDecimal(this.txtQuantity.Text) > new decimal(0))
                            {
                                Label label = this.lblTotalPrice;
                                decimal num12 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                                label.Text = num12.ToString("N2");
                            }
                            if (this.lblSD.Text.Length <= 0 || !(Convert.ToDecimal(this.lblSD.Text) > new decimal(0)) || !(Convert.ToDecimal(this.lblTotalPrice.Text) > new decimal(0)))
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.txtTotalSD.Text = "0.00";
                            }
                            else
                            {
                                TextBox textBox = this.txtTotalSD;
                                decimal num13 = Convert.ToDecimal(this.lblTotalPrice.Text) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                textBox.Text = num13.ToString("0.00");
                                Label str1 = this.lblTotalSD;
                                decimal num14 = Convert.ToDecimal(this.lblTotalPrice.Text) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                str1.Text = num14.ToString("N2");
                            }
                            if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                            {
                                if (this.lblProductType.Text != "W")
                                {
                                    Label label1 = this.lblTotalVAT;
                                    double num15 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    label1.Text = num15.ToString("N2");
                                    TextBox textBox1 = this.tbTotalVAT;
                                    double num16 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox1.Text = num16.ToString("0.00");
                                }
                                else
                                {
                                    Label str2 = this.lblTotalVAT;
                                    double num17 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    str2.Text = num17.ToString("N2");
                                    TextBox textBox2 = this.tbTotalVAT;
                                    double num18 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox2.Text = num18.ToString("0.00");
                                }
                            }
                            num3 = (this.txtUnitPrice.Text != "" ? num2 : new decimal(0));
                            num4 = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text.Trim()) : new decimal(0));
                            num5 = (this.lblAIT.Text != "" ? Convert.ToDecimal(this.lblAIT.Text.Trim()) : new decimal(0));
                            TextBox str3 = this.txtAIT;
                            decimal num19 = ((num3 * num4) * num5) / new decimal(100);
                            str3.Text = num19.ToString("N");
                            Label label2 = this.lblTotalSalePrc;
                            double num20 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.lblTotalVAT.Text);
                            label2.Text = num20.ToString("N2");
                        }
                        else
                        {
                            if (Convert.ToDecimal(this.txtUnitPrice.Text) <= new decimal(0))
                            {
                                this.lblTotalSalePrc.Text = "0.00";
                            }
                            else
                            {
                                Label label3 = this.lblTotalSalePrc;
                                decimal num21 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                                label3.Text = num21.ToString("N2");
                            }
                            Label str4 = this.lblTotalPrice;
                            decimal num22 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                            str4.Text = num22.ToString("N2");
                            if (this.chkExempted.Checked)
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.lblTotalVAT.Text = "0.00";
                                this.lblTotalSalePrc.Text = this.lblTotalPrice.Text;
                            }
                            else
                            {
                                if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDecimal(this.txtQuantity.Text) > new decimal(0))
                                {
                                    Label label4 = this.lblTotalPrice;
                                    decimal num23 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                                    label4.Text = num23.ToString("N2");
                                }
                                if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || !(Convert.ToDecimal(this.lblTotalPrice.Text) > new decimal(0)))
                                {
                                    decimal num24 = new decimal(0);
                                    decimal num25 = new decimal(0);
                                    decimal num26 = new decimal(0);
                                    decimal num27 = new decimal(0);
                                    DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num1);
                                    if (itemIsTeriff.Rows.Count > 0 && Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                                    {
                                        DataTable itemVatAmountForSale = addItemBLL.getItemVatAmountForSale(num1);
                                        if (itemVatAmountForSale.Rows.Count > 0)
                                        {
                                            num26 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["tax_value"]);
                                            num24 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["per"]);
                                            num25 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                            num27 = (num26 * num25) / num24;
                                        }
                                    }
                                    if (num26 <= new decimal(0))
                                    {
                                        this.lblTotalSD.Text = "0.00";
                                        this.tbTotalVAT.Text = "0.00";
                                    }
                                    else
                                    {
                                        this.lblTotalSD.Text = "0.00";
                                        this.tbTotalVAT.Text = num27.ToString();
                                        this.lblTotalVAT.Text = num27.ToString("N2");
                                    }
                                }
                                else
                                {
                                    Label str5 = this.lblTotalSD;
                                    decimal num28 = Convert.ToDecimal(this.lblTotalPrice.Text) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                    str5.Text = num28.ToString("N2");
                                    TextBox textBox3 = this.txtTotalSD;
                                    decimal num29 = Convert.ToDecimal(this.lblTotalPrice.Text) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                    textBox3.Text = num29.ToString("0.00");
                                }
                                if (this.lblVAT.Text.Length > 0 && Convert.ToDecimal(this.lblVAT.Text) > new decimal(0) && Convert.ToDecimal(this.lblTotalPrice.Text) > new decimal(0))
                                {
                                    if (this.lblProductType.Text != "W")
                                    {
                                        Label label5 = this.lblTotalVAT;
                                        double num30 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                        label5.Text = num30.ToString("N2");
                                        TextBox textBox4 = this.tbTotalVAT;
                                        double num31 = (Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                        textBox4.Text = num31.ToString("0.00");
                                    }
                                    else
                                    {
                                        Label str6 = this.lblTotalVAT;
                                        decimal num32 = ((Convert.ToDecimal(this.lblTotalPrice.Text) / new decimal(2)) + Convert.ToDecimal(this.lblTotalSD.Text)) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                        str6.Text = num32.ToString("N2");
                                        TextBox textBox5 = this.tbTotalVAT;
                                        decimal num33 = ((Convert.ToDecimal(this.lblTotalPrice.Text) / new decimal(2)) + Convert.ToDecimal(this.lblTotalSD.Text)) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                        textBox5.Text = num33.ToString("0.00");
                                    }
                                }
                                Label label6 = this.lblTotalSalePrc;
                                double num34 = Convert.ToDouble(this.lblTotalPrice.Text) + Convert.ToDouble(this.lblTotalSD.Text) + Convert.ToDouble(this.tbTotalVAT.Text);
                                label6.Text = num34.ToString("N2");
                                num3 = (this.txtUnitPrice.Text != "" ? num2 : new decimal(0));
                                num4 = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text.Trim()) : new decimal(0));
                                num5 = (this.lblAIT.Text != "" ? Convert.ToDecimal(this.lblAIT.Text.Trim()) : new decimal(0));
                                TextBox textBox6 = this.txtAIT;
                                decimal num35 = ((num3 * num4) * num5) / new decimal(100);
                                textBox6.Text = num35.ToString("N2");
                            }
                            if (this.chkInexplicitExport.Checked || this.chkZeroRate.Checked)
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.lblTotalVAT.Text = "0.00";
                            }
                        }
                        decimal num36 = new decimal(0);
                        decimal num37 = new decimal(0);
                        decimal num38 = new decimal(0);
                        decimal num39 = new decimal(0);
                        decimal num40 = new decimal(0);
                        decimal num41 = new decimal(0);
                        decimal num42 = new decimal(0);
                        decimal num43 = new decimal(0);
                        decimal num44 = new decimal(0);
                        num38 = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text) : new decimal(1));
                        num36 = (this.lblVAT.Text != "" ? Convert.ToDecimal(this.lblVAT.Text.Trim()) : new decimal(0));
                        num37 = (this.lblSD.Text != "" ? Convert.ToDecimal(this.lblSD.Text.Trim()) : new decimal(0));
                        num43 = (this.txtUnitPrice.Text != "" ? num2 : new decimal(0));
                        num44 = num38 * num43;
                        num42 = (num43 * num38) * (num37 / new decimal(100));
                        num39 = num42 + (num43 * num38);
                        num41 = num39 * (num36 / new decimal(100));
                        num40 = ((num43 * num38) + num42) + num41;
                        this.txtTotalPrice.Text = num44.ToString("N");
                        this.txtQuantity.Text = num38.ToString();
                        this.tbTotalVAT.Text = num41.ToString("N");
                        this.txtTotalSD.Text = num42.ToString("N");
                        this.txtPriceIncludingVat.Text = num40.ToString("N");
                    }
                    if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                    {
                        if ((this.txtdiscountpct.Text != "" ? Convert.ToDecimal(this.txtdiscountpct.Text) : new decimal(0)) > new decimal(0))
                        {
                            if ((this.txtDiscount.Text != "" ? Convert.ToDecimal(this.txtDiscount.Text) : new decimal(0)) > new decimal(0))
                            {
                                TextBox str7 = this.txtDiscount;
                                decimal num45 = ((Convert.ToDecimal(this.txtQuantity.Text) * Convert.ToDecimal(this.txtUnitPrice.Text)) * Convert.ToDecimal(this.txtdiscountpct.Text)) / new decimal(100);
                                str7.Text = num45.ToString();
                            }
                        }
                    }
                    string text = this.txtUnitPrice.Text;
                    this.txtvdsamount.Text = this.tbTotalVAT.Text;
                }
                else
                {
                    num6 = (this.txtFinalQuantity.Text != "" ? Convert.ToDecimal(this.txtFinalQuantity.Text.Trim()) : new decimal(1));
                    num7 = (this.txtUnitPrice.Text != "" ? Convert.ToDecimal(this.txtUnitPrice.Text.Trim()) : new decimal(0));
                    num10 = (this.lblVAT.Text != "" ? Convert.ToDecimal(this.lblVAT.Text.Trim()) : new decimal(0));
                    num8 = num7 * num6;
                    this.txtTotalPrice.Text = num8.ToString("N2");
                    this.lblTotalPrice.Text = num8.ToString("N2");
                    this.lblTotalVAT.Text = (num10 * num6).ToString("N2");
                    this.tbTotalVAT.Text = (num10 * num6).ToString("N2");
                    num = (this.txtTotalSD.Text != "" ? Convert.ToDecimal(this.txtTotalSD.Text.Trim()) : new decimal(0));
                    this.lblTotalSD.Text = num.ToString("N2");
                    num9 = num8 + (num10 * num6);
                    Label label7 = this.lblTotalSalePrc;
                    decimal num46 = (Convert.ToDecimal(this.lblTotalPrice.Text) + Convert.ToDecimal(this.lblTotalSD.Text)) + Convert.ToDecimal(this.lblTotalVAT.Text);
                    label7.Text = num46.ToString("N2");
                    this.txtPriceIncludingVat.Text = num9.ToString("N2");
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void CalculatePricesUnitChangeforTobacco()
        {
            decimal num;
            try
            {
                int num1 = 0;
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                num1 = Convert.ToInt16(strArrays[0]);
                AddItemBLL addItemBLL = new AddItemBLL();
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                ContructualProductionBLL contructualProductionBLL = new ContructualProductionBLL();
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                decimal num9 = new decimal(0);
                decimal num10 = new decimal(0);
                decimal num11 = new decimal(0);
                num2 = (Convert.ToDecimal(this.Session["unit_price"]) != new decimal(0) ? Convert.ToDecimal(this.Session["unit_price"]) : Convert.ToDecimal(this.txtUnitPrice.Text));
                if (this.Label9.Text != " Per Unit.")
                {
                    if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                    {
                        if (this.hdItemType.Value != "I")
                        {
                            if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDecimal(this.txtQuantity.Text) > new decimal(0))
                            {
                                Label label = this.lblTotalPrice;
                                decimal num12 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                                label.Text = num12.ToString("N2");
                            }
                            if (this.lblSD.Text.Length <= 0 || !(Convert.ToDecimal(this.lblSD.Text) > new decimal(0)) || !(Convert.ToDecimal(this.lblTotalPrice.Text) > new decimal(0)))
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.txtTotalSD.Text = "0.00";
                            }
                            else
                            {
                                TextBox textBox = this.txtTotalSD;
                                decimal num13 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                textBox.Text = num13.ToString("0.00");
                                Label str1 = this.lblTotalSD;
                                decimal num14 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                str1.Text = num14.ToString("N2");
                            }
                            if (this.lblVAT.Text.Length > 0 && Convert.ToDouble(this.lblVAT.Text) > 0 && Convert.ToDouble(this.lblTotalPrice.Text) > 0)
                            {
                                if (this.lblProductType.Text != "W")
                                {
                                    Label label1 = this.lblTotalVAT;
                                    decimal num15 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                    label1.Text = num15.ToString("N2");
                                    TextBox textBox1 = this.tbTotalVAT;
                                    decimal num16 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                    textBox1.Text = num16.ToString("0.00");
                                }
                                else
                                {
                                    Label str2 = this.lblTotalVAT;
                                    double num17 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    str2.Text = num17.ToString("N2");
                                    TextBox textBox2 = this.tbTotalVAT;
                                    double num18 = (Convert.ToDouble(this.lblTotalPrice.Text) / 2 + Convert.ToDouble(this.lblTotalSD.Text)) * (Convert.ToDouble(this.lblVAT.Text) / 100);
                                    textBox2.Text = num18.ToString("0.00");
                                }
                            }
                            num3 = (this.txtUnitPrice.Text != "" ? num2 : new decimal(0));
                            num4 = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text.Trim()) : new decimal(0));
                            num5 = (this.lblAIT.Text != "" ? Convert.ToDecimal(this.lblAIT.Text.Trim()) : new decimal(0));
                            TextBox str3 = this.txtAIT;
                            decimal num19 = ((num3 * num4) * num5) / new decimal(100);
                            str3.Text = num19.ToString("N");
                            Label label2 = this.lblTotalSalePrc;
                            double num20 = Convert.ToDouble(this.lblTotalPrice.Text);
                            label2.Text = num20.ToString("N2");
                        }
                        else
                        {
                            if (Convert.ToDecimal(this.txtUnitPrice.Text) <= new decimal(0))
                            {
                                this.lblTotalSalePrc.Text = "0.00";
                            }
                            else
                            {
                                Label label3 = this.lblTotalSalePrc;
                                decimal num21 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                                label3.Text = num21.ToString("N2");
                            }
                            Label str4 = this.lblTotalPrice;
                            decimal num22 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                            str4.Text = num22.ToString("N2");
                            if (this.chkExempted.Checked)
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.lblTotalVAT.Text = "0.00";
                                this.lblTotalSalePrc.Text = this.lblTotalPrice.Text;
                            }
                            else
                            {
                                if (this.txtUnitPrice.Text.Length > 0 && Convert.ToDecimal(this.txtQuantity.Text) > new decimal(0))
                                {
                                    Label label4 = this.lblTotalPrice;
                                    decimal num23 = Convert.ToDecimal(this.txtQuantity.Text) * num2;
                                    label4.Text = num23.ToString("N2");
                                }
                                if (this.lblSD.Text.Length <= 0 || Convert.ToDouble(this.lblSD.Text) <= 0 || !(Convert.ToDecimal(this.lblTotalPrice.Text) > new decimal(0)))
                                {
                                    decimal num24 = new decimal(0);
                                    decimal num25 = new decimal(0);
                                    decimal num26 = new decimal(0);
                                    decimal num27 = new decimal(0);
                                    DataTable itemIsTeriff = addItemBLL.getItemIsTeriff(num1);
                                    if (itemIsTeriff.Rows.Count > 0 && Convert.ToBoolean(itemIsTeriff.Rows[0]["is_tarrif"]))
                                    {
                                        DataTable itemVatAmountForSale = addItemBLL.getItemVatAmountForSale(num1);
                                        if (itemVatAmountForSale.Rows.Count > 0)
                                        {
                                            num26 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["tax_value"]);
                                            num24 = Convert.ToDecimal(itemVatAmountForSale.Rows[0]["per"]);
                                            num25 = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                                            num27 = (num26 * num25) / num24;
                                        }
                                    }
                                    if (num26 <= new decimal(0))
                                    {
                                        this.lblTotalSD.Text = "0.00";
                                        this.tbTotalVAT.Text = "0.00";
                                    }
                                    else
                                    {
                                        this.lblTotalSD.Text = "0.00";
                                        this.tbTotalVAT.Text = num27.ToString();
                                        this.lblTotalVAT.Text = num27.ToString("N2");
                                    }
                                }
                                else
                                {
                                    Label str5 = this.lblTotalSD;
                                    decimal num28 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                    str5.Text = num28.ToString("N2");
                                    TextBox textBox3 = this.txtTotalSD;
                                    decimal num29 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblSD.Text) / new decimal(100));
                                    textBox3.Text = num29.ToString("0.00");
                                }
                                if (this.lblVAT.Text.Length > 0 && Convert.ToDecimal(this.lblVAT.Text) > new decimal(0) && Convert.ToDecimal(this.lblTotalPrice.Text) > new decimal(0))
                                {
                                    if (this.lblProductType.Text != "W")
                                    {
                                        Label label5 = this.lblTotalVAT;
                                        decimal num30 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                        label5.Text = num30.ToString("N2");
                                        TextBox textBox4 = this.tbTotalVAT;
                                        decimal num31 = (Convert.ToDecimal(this.txtQuantity.Text) * num2) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                        textBox4.Text = num31.ToString("0.00");
                                    }
                                    else
                                    {
                                        Label str6 = this.lblTotalVAT;
                                        decimal num32 = ((Convert.ToDecimal(this.lblTotalPrice.Text) / new decimal(2)) + Convert.ToDecimal(this.lblTotalSD.Text)) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                        str6.Text = num32.ToString("N2");
                                        TextBox textBox5 = this.tbTotalVAT;
                                        decimal num33 = ((Convert.ToDecimal(this.lblTotalPrice.Text) / new decimal(2)) + Convert.ToDecimal(this.lblTotalSD.Text)) * (Convert.ToDecimal(this.lblVAT.Text) / new decimal(100));
                                        textBox5.Text = num33.ToString("0.00");
                                    }
                                }
                                Label label6 = this.lblTotalSalePrc;
                                double num34 = Convert.ToDouble(this.lblTotalPrice.Text);
                                label6.Text = num34.ToString("N2");
                                num3 = (this.txtUnitPrice.Text != "" ? num2 : new decimal(0));
                                num4 = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text.Trim()) : new decimal(0));
                                num5 = (this.lblAIT.Text != "" ? Convert.ToDecimal(this.lblAIT.Text.Trim()) : new decimal(0));
                                TextBox textBox6 = this.txtAIT;
                                decimal num35 = ((num3 * num4) * num5) / new decimal(100);
                                textBox6.Text = num35.ToString("N2");
                            }
                            if (this.chkInexplicitExport.Checked || this.chkZeroRate.Checked)
                            {
                                this.lblTotalSD.Text = "0.00";
                                this.lblTotalVAT.Text = "0.00";
                            }
                        }
                        decimal num36 = new decimal(0);
                        decimal num37 = new decimal(0);
                        decimal num38 = new decimal(0);
                        decimal num39 = new decimal(0);
                        decimal num40 = new decimal(0);
                        decimal num41 = new decimal(0);
                        decimal num42 = new decimal(0);
                        decimal num43 = new decimal(0);
                        decimal num44 = new decimal(0);
                        num44 = (this.lblhlthcharge.Text != "" ? Convert.ToDecimal(this.lblhlthcharge.Text.Trim()) : new decimal(0));
                        num38 = (this.txtQuantity.Text != "" ? Convert.ToDecimal(this.txtQuantity.Text) : new decimal(1));
                        num36 = (this.lblVAT.Text != "" ? Convert.ToDecimal(this.lblVAT.Text.Trim()) : new decimal(0));
                        num37 = (this.lblSD.Text != "" ? Convert.ToDecimal(this.lblSD.Text.Trim()) : new decimal(0));
                        num42 = (this.txtUnitPrice.Text != "" ? num2 : new decimal(0));
                        num43 = num38 * num42;
                        num41 = (num43 * num37) / new decimal(100);
                        num40 = num43 * (num36 / new decimal(100));
                        num39 = num43;
                        TextBox str7 = this.txthlthcharge;
                        decimal num45 = (num43 * num44) / new decimal(100);
                        str7.Text = num45.ToString("0.00");
                        this.txtTotalPrice.Text = num43.ToString("N");
                        this.txtQuantity.Text = num38.ToString();
                        this.tbTotalVAT.Text = num40.ToString("N");
                        this.txtTotalSD.Text = num41.ToString("N");
                        this.txtPriceIncludingVat.Text = num39.ToString("N");
                    }
                    if (this.txtQuantity.Text.Length > 0 && this.txtUnitPrice.Text.Length > 0)
                    {
                        if ((this.txtdiscountpct.Text != "" ? Convert.ToDecimal(this.txtdiscountpct.Text) : new decimal(0)) > new decimal(0))
                        {
                            if ((this.txtDiscount.Text != "" ? Convert.ToDecimal(this.txtDiscount.Text) : new decimal(0)) > new decimal(0))
                            {
                                TextBox textBox7 = this.txtDiscount;
                                decimal num46 = ((Convert.ToDecimal(this.txtQuantity.Text) * Convert.ToDecimal(this.txtUnitPrice.Text)) * Convert.ToDecimal(this.txtdiscountpct.Text)) / new decimal(100);
                                textBox7.Text = num46.ToString();
                            }
                        }
                    }
                    string text = this.txtUnitPrice.Text;
                    this.txtvdsamount.Text = this.tbTotalVAT.Text;
                }
                else
                {
                    num6 = (this.txtFinalQuantity.Text != "" ? Convert.ToDecimal(this.txtFinalQuantity.Text.Trim()) : new decimal(1));
                    num7 = (this.txtUnitPrice.Text != "" ? Convert.ToDecimal(this.txtUnitPrice.Text.Trim()) : new decimal(0));
                    num10 = (this.tbTotalVAT.Text != "" ? Convert.ToDecimal(this.tbTotalVAT.Text.Trim()) : new decimal(0));
                    num8 = num7 * num6;
                    this.txtTotalPrice.Text = num8.ToString("N2");
                    num9 = num8 + num10;
                    this.txtPriceIncludingVat.Text = num9.ToString("N2");
                    this.lblTotalPrice.Text = num8.ToString("N2");
                    Label label7 = this.lblTotalVAT;
                    decimal num47 = Convert.ToDecimal(this.tbTotalVAT);
                    label7.Text = num47.ToString("N2");
                    num = (this.txtTotalSD.Text != "" ? Convert.ToDecimal(this.txtTotalSD.Text.Trim()) : new decimal(0));
                    this.lblTotalSD.Text = num.ToString("N2");
                    Label str8 = this.lblTotalSalePrc;
                    decimal num48 = (Convert.ToDecimal(this.lblTotalPrice.Text) + Convert.ToDecimal(this.lblTotalSD.Text)) + Convert.ToDecimal(this.lblTotalVAT.Text);
                    str8.Text = num48.ToString("N2");
                    this.txtPriceIncludingVat.Text = this.txtPriceIncludingVat.Text.Trim();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void CalculatePricesUnitForGift()
        {
        }

        private void CaluculateDiscount()
        {
            if (this.txtQuantity.Text.Length > 0 && Convert.ToDecimal(this.txtQuantity.Text.ToString()) > new decimal(0) && !string.IsNullOrWhiteSpace(this.txtdiscountpct.Text) && Convert.ToDecimal(this.txtdiscountpct.Text.ToString()) > new decimal(0))
            {
                TextBox str = this.txtDiscount;
                decimal num = ((Convert.ToDecimal(this.txtQuantity.Text) * Convert.ToDecimal(this.txtUnitPrice.Text)) * Convert.ToDecimal(this.txtdiscountpct.Text)) / new decimal(100);
                str.Text = num.ToString("0.00");
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

        protected void chkDeemedExport_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void chkDiscard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDiscard.Checked)
            {
                this.lblDiscardReason.Visible = true;
                this.drpDiscardReason.Visible = true;
                this.drpCategory.Enabled = false;
                this.drpSubCategory.Enabled = false;
                this.drpItem.Enabled = false;
                this.btnAdd.Enabled = false;
                return;
            }
            this.lblDiscardReason.Visible = false;
            this.drpDiscardReason.Visible = false;
            this.drpCategory.Enabled = true;
            this.drpSubCategory.Enabled = true;
            this.drpItem.Enabled = true;
            this.btnAdd.Enabled = true;
        }

        protected void chkExcelImport_CheckedChanged(object sender, EventArgs e)
        {
            this.btnExcelSave.Visible = false;
            this.div_a.Visible = false;
            this.div_b.Visible = false;
            this.div_c.Visible = false;
            this.div_d.Visible = true;
            this.Session["SALES_EXCEL"] = new ArrayList();
        }

        protected void chkExempted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalculatePrices();
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "chkExempted_CheckedChanged");
            }
        }

        protected void chkInexplicitExport_CheckedChanged(object sender, EventArgs e)
        {
            this.CalculatePrices();
        }

        protected void chkInstallment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.chkInstallment.Checked)
                {
                    this.drpAgreement.Visible = false;
                    this.txtAggrementNo.Visible = true;
                }
                else
                {
                    this.drpAgreement.Visible = true;
                    this.txtAggrementNo.Visible = false;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void chkManualInput_CheckedChanged(object sender, EventArgs e)
        {
            this.div_a.Visible = true;
            this.div_b.Visible = true;
            this.div_c.Visible = true;
            this.div_d.Visible = false;
            this.Session["SALES_EXCEL"] = new ArrayList();
        }

        protected void chkReduced_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalculatePrices();
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "chkExempted_CheckedChanged");
            }
        }

        protected void chkTaxDeducted_CheckedChanged(object sender, EventArgs e)
        {
            double num = 0;
            try
            {
                if (!this.chkTaxDeducted.Checked)
                {
                    this.lblVDS.Visible = false;
                    this.txtVDS.Visible = false;
                }
                else
                {
                    double num1 = Convert.ToDouble(this.tbTotalVAT.Text.Trim());
                    num = num1 / 3;
                    this.txtVDS.Text = num.ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.CalculatePrices();
        }

        protected void chkZeroRate_CheckedChanged(object sender, EventArgs e)
        {
            this.CalculatePrices();
        }

        private void ClearAllControlsValue()
        {
            try
            {
                this.txtaddProp.Text = "";
                this.lblTotalRow.Text = "";
                this.divaddprop.Visible = false;
                this.Label5.Text = "Price";
                this.installmentStatus.Text = "";
                this.scheduleId.Text = "";
                this.chkInstallment.Checked = false;
                this.drpAgreement.Visible = false;
                this.txtAggrementNo.Visible = true;
                this.Session["SALE_DETAIL_LISTF"] = this.Session["SALE_DETAIL_LIST"];
                this.Session["SALE_DETAIL_LIST"] = new ArrayList();
                this.lblSku.Text = "";
                this.txtTotalSalePrice.Text = "";
                this.GetPartyInfo();
                this.txtChallanNo.Text = "";
                this.txtdiscountpct.Text = "";
                this.txtDiscount.Text = "";
                this.txtdiscountPctm.Text = "";
                this.txtdiscountm.Text = "";
                this.txtChallanDate.Text = DateTime.Today.Date.ToString("dd/MM/yyyy");
                this.txtDeliveryDate.Text = "";
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpParty.Items.Insert(0, listItem);
                this.drpParty.SelectedValue = "-99";
                this.txtPartyBIN.Text = "";
                this.txtAddress.Text = "";
                this.txtDestination.Text = "";
                this.drpVehicleType.SelectedValue = "-99";
                this.txtVehicleNo.Text = "";
                this.lblMessage.Text = "";
                this.drpChDtHr.SelectedValue = DateTime.UtcNow.AddHours(6).Hour.ToString("00");
                this.drpChDtMin.SelectedValue = DateTime.UtcNow.AddHours(6).Minute.ToString("00");
                this.SetDeliveryTime();
                this.btnAddParty.Text = "New";
                this.drpParty.Enabled = true;
                this.txtPartyName.Visible = false;
                this.drpSaleType.SelectedValue = "S";
                this.ClearDetailControlsValue();
                this.drpRegType.SelectedValue = "0";
                this.hdBookId.Value = "";
                this.hdPageNo.Value = "";
                this.gvItem.DataSource = null;
                this.gvItem.DataBind();
                this.gvAddtnProperty.DataSource = null;
                this.gvAddtnProperty.DataBind();
                this.chkDiscard.Checked = false;
                this.lblDiscardReason.Visible = false;
                this.drpDiscardReason.Visible = false;
                this.drpCategory.Enabled = true;
                this.drpSubCategory.Enabled = true;
                this.drpItem.Enabled = true;
                this.btnAdd.Enabled = true;
                this.drpBank.SelectedValue = "-99";
                this.drpBranch.SelectedValue = "-99";
                this.drpPortCode.SelectedValue = "-99";
                this.txtnoItem.Text = "";
                this.txtTotalPack.Text = "";
                this.txtExpBillNo.Text = "";
                this.txtExportDate.Text = "";
                this.txtRemarks.Text = "";
                this.chkInexplicitExport.Checked = false;
                this.chkInexplicitExport.Visible = false;
                this.divexport.Visible = false;
                this.drpTransaction.SelectedIndex = 0;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "ClearAllControlsValue", fileLineNumber);
            }
        }

        private void ClearCheckBox()
        {
            try
            {
                this.chkExempted.Checked = false;
                this.chkExempted.Attributes["style"] = "color:black;";
                this.chkInexplicitExport.Checked = false;
                this.chkInexplicitExport.Attributes["style"] = "color:black;";
                this.chkRebatable.Checked = false;
                this.chkRebatable.Attributes["style"] = "color:black;";
                this.chkTaxDeducted.Checked = false;
                this.chkTaxDeducted.Attributes["style"] = "color:black;";
                this.chkIsFixed.Checked = false;
                this.chkIsFixed.Attributes["style"] = "color:black;";
                this.chkMrp.Checked = false;
                this.chkMrp.Attributes["style"] = "color:black;";
                this.chkZeroRate.Checked = false;
                this.chkZeroRate.Attributes["style"] = "color:black;";
                this.chkReduced.Checked = false;
                this.chkReduced.Attributes["style"] = "color:black;";
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "ClearCheckBox", fileLineNumber);
            }
        }

        private void ClearDetailControlsValue()
        {
            try
            {
                this.partVDS.Visible = false;
                this.txtvdsamount.Text = "";
                this.txtvdsamount.Text = "";
                this.txtBatchNo.Text = "";
                this.singleRemarks.Text = "";
                this.lblhlthcharge.Text = "0.00";
                this.txthlthcharge.Text = "";
                this.lblavlStock.Text = "";
                this.lblprpstk.Text = "";
                this.Label9.Text = "%";
                this.lblfxdVT.Text = "";
                this.LoadItems();
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                this.drpSubCategory.Items.Clear();
                ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem1);
                for (int i = 0; i < this.drpPropertyCollection.Count; i++)
                {
                    this.drpPropertyCollection[i].SelectedIndex = 0;
                    this.drpPropertyCollection[i].Enabled = false;
                }
                this.productName.Text = "";
                this.txtQuantity.Text = "";
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "0.00";
                this.lblNBRPrice.Text = "0.00";
                this.lblSD.Text = "0.00";
                this.lblVAT.Text = "0.00";
                this.txtTotalPrice.Text = "";
                this.txtPriceIncludingVat.Text = "";
                this.tbTotalVAT.Text = "";
                this.txtTotalSD.Text = "";
                this.lblAvailStock.Text = "0";
                this.lblSku.Text = "";
                this.drpUnit.ClearSelection();
                this.drpUnit.Items.Clear();
                this.lblUnit.Text = "Unit";
                this.lblHSCode.Text = ".";
                this.lblTotalPrice.Text = "0.00";
                this.lblTotalSD.Text = "0.00";
                this.lblTotalVAT.Text = "0.00";
                this.lblTotalSalePrc.Text = "0.00";
                this.hdUnitID.Value = "";
                this.lblProp11.Visible = false;
                this.lblProp22.Visible = false;
                this.lblProp33.Visible = false;
                this.lblProp44.Visible = false;
                this.lblProp55.Visible = false;
                this.drpProp11.Visible = false;
                this.drpProp22.Visible = false;
                this.drpProp33.Visible = false;
                this.drpProp44.Visible = false;
                this.drpProp55.Visible = false;
                this.drpProp11.Items.Clear();
                this.drpProp22.Items.Clear();
                this.drpProp33.Items.Clear();
                this.drpProp44.Items.Clear();
                this.drpProp55.Items.Clear();
                this.lblAIT.Text = "";
                this.lblBoxQty.Visible = false;
                this.txtBoxQty.Visible = false;
                this.txtAIT.Text = "";
                this.txtdiscountpct.Text = "";
                this.txtDiscount.Text = "";
                this.txtFinalQuantity.Text = "";
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

        private void ClearGiftDetailControls()
        {
            try
            {
                this.LoadGiftItems();
                this.drpGiftUnit.Items.Clear();
                this.txtGiftQnt.Text = "";
                this.txtGiftRemarks.Text = "";
                this.lblGiftAvailStock.Text = "";
                this.lblgiftavlstock.Text = "";
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

        private void ClearOnItemChangeValue()
        {
            try
            {
                this.txtaddProp.Text = "";
                this.divaddprop.Visible = false;
                this.lblTotalRow.Text = "";
                this.divSearch.Visible = false;
                this.partVDS.Visible = false;
                this.txtvdsamount.Text = "";
                this.Label5.Text = "Price";
                this.scheduleId.Text = "";
                this.chkInstallment.Checked = false;
                this.drpAgreement.Visible = false;
                this.txtAggrementNo.Visible = true;
                this.installmentStatus.Text = "";
                this.gvAddtnProperty.DataSource = null;
                this.gvAddtnProperty.DataBind();
                this.lblhlthcharge.Text = "0.00";
                this.txthlthcharge.Text = "";
                this.Label9.Text = "%";
                UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpCategory.Items.Insert(0, listItem);
                this.drpSubCategory.Items.Clear();
                ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem1);
                for (int i = 0; i < this.drpPropertyCollection.Count; i++)
                {
                    this.drpPropertyCollection[i].SelectedIndex = 0;
                    this.drpPropertyCollection[i].Enabled = false;
                }
                this.productName.Text = "";
                this.txtQuantity.Text = "";
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "0.00";
                this.lblNBRPrice.Text = "0.00";
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
                this.lblTotalPrice.Text = "0.00";
                this.lblTotalSD.Text = "0.00";
                this.lblTotalVAT.Text = "0.00";
                this.lblTotalSalePrc.Text = "0.00";
                this.hdUnitID.Value = "";
                this.lblProp11.Visible = false;
                this.lblProp22.Visible = false;
                this.lblProp33.Visible = false;
                this.lblProp44.Visible = false;
                this.lblProp55.Visible = false;
                this.drpProp11.Visible = false;
                this.drpProp22.Visible = false;
                this.drpProp33.Visible = false;
                this.drpProp44.Visible = false;
                this.drpProp55.Visible = false;
                this.drpProp11.Items.Clear();
                this.drpProp22.Items.Clear();
                this.drpProp33.Items.Clear();
                this.drpProp44.Items.Clear();
                this.drpProp55.Items.Clear();
                this.lblAIT.Text = "";
                this.lblBoxQty.Visible = false;
                this.txtBoxQty.Visible = false;
                this.txtAIT.Text = "";
                this.txtdiscountpct.Text = "";
                this.txtDiscount.Text = "";
                this.txtFinalQuantity.Text = "";
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

        protected void drpAgreement_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpAgreement.SelectedValue != "-99")
                {
                    this.fillPendingProperties();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpBranch.Items.Clear();
            if (this.drpBank.SelectedValue != "-99")
            {
                BLL.Utility.fillAllBankBranchByBankID(this.drpBranch, Convert.ToInt32(this.drpBank.SelectedValue));
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpBranch.Items.Insert(0, listItem);
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
                this.LoadSubCategory();
                this.LoadItemsByCatgSubCatg();
                this.lblNBRPrice.Text = "0.00";
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

        protected void drpChDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetChDtTimeInWords();
            this.SetDeliveryTime();
        }

        protected void drpChDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetChDtTimeInWords();
            this.SetDeliveryTime();
        }

        protected void drpDlDtHr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetDelDtTimeInWords();
        }

        protected void drpDlDtMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetDelDtTimeInWords();
        }

        protected void drpGiftItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetAvailGiftStock();
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetAvailStock");
            }
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ClearOnItemChangeValue();
                this.ClearCheckBox();
                this.drpItem.SelectedItem.ToString();
                string selectedValue = this.drpItem.SelectedValue;
                decimal num = new decimal(0);
                int num1 = 0;
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                num1 = Convert.ToInt16(strArrays[0]);
                if (this.drpItem.SelectedValue != "-99")
                {
                    string[] strArrays1 = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                    if (strArrays1 != null && strArrays1.Count<string>() > 0)
                    {
                        this.lblHSCode.Text = strArrays1[strArrays1.Count<string>() - 2];
                    }
                    num = Convert.ToDecimal(this.drpItem.SelectedValue);
                    DataTable dataTable = this.objPDBll.gethsCodebyItemID(num1);
                    if (dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Rows[0]["hs_code"].ToString() == "2402.20.00" || dataTable.Rows[0]["hs_code"].ToString() == "2402.90.00")
                        {
                            this.divHlthChrg.Visible = true;
                            this.chkMrp.Checked = true;
                            this.chkMrp.Attributes["style"] = "color:Green;";
                            DataTable healthChargebyItemID = this.objPDBll.getHealthChargebyItemID(num1);
                            if (healthChargebyItemID.Rows.Count > 0)
                            {
                                Label label = this.lblhlthcharge;
                                decimal num2 = Convert.ToDecimal(healthChargebyItemID.Rows[0]["health_surcharge"]);
                                label.Text = num2.ToString("0.00");
                            }
                        }
                        else
                        {
                            this.divHlthChrg.Visible = false;
                            this.chkMrp.Checked = false;
                        }
                    }
                    string str1 = this.drpItem.SelectedItem.ToString();
                    AddItemBLL addItemBLL = new AddItemBLL();
                    str1.Contains("Local");
                    str1.Contains("Import");
                    str1.Contains("Production");
                    DataTable item = (DataTable)this.Session["ITEM_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("item_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.lblProductType.Text = dataRow["PRODUCT_TYPE"].ToString();
                        this.lblSku.Text = dataRow["item_sku"].ToString();
                        this.txtSpecification.Value = dataRow["item_specification"].ToString();
                    }
                    this.GetAdditionalProperty();
                    DataTable batchNo = addItemBLL.getBatchNo(num1);
                    if (batchNo.Rows.Count > 0)
                    {
                        this.txtBatchNo.Text = batchNo.Rows[0]["batch_no"].ToString();
                    }
                    DataTable truncated = addItemBLL.getTruncated(num1);
                    if (truncated.Rows.Count > 0)
                    {
                        this.HiddenIsTruncated.Value = null;
                        if (!Convert.ToBoolean(truncated.Rows[0]["is_truncated"]))
                        {
                            this.HiddenIsTruncated.Value = null;
                        }
                        else
                        {
                            this.chkReduced.Checked = true;
                            this.chkReduced.Attributes["style"] = "color:Green;";
                            this.HiddenIsTruncated.Value = "is_truncated";
                        }
                    }
                    this.chkZeroRate.Checked = false;
                    DataTable itemIsZeroRate = addItemBLL.getItemIsZeroRate(num1);
                    if (itemIsZeroRate.Rows.Count > 0 && Convert.ToBoolean(itemIsZeroRate.Rows[0]["is_zero_rate"]))
                    {
                        this.chkZeroRate.Checked = true;
                        this.chkZeroRate.Attributes["style"] = "color:Green;";
                    }
                    DataTable itemIsMRP = addItemBLL.getItemIsMRP(num1);
                    if (itemIsMRP.Rows.Count <= 0)
                    {
                        this.chkMrp.Checked = false;
                    }
                    else if (Convert.ToBoolean(itemIsMRP.Rows[0]["is_mrp"]))
                    {
                        this.chkMrp.Checked = true;
                        this.chkMrp.Attributes["style"] = "color:Green;";
                    }
                    DataTable itemIsFixedVat = addItemBLL.GetItemIsFixedVat(num1);
                    if (itemIsFixedVat.Rows.Count <= 0)
                    {
                        this.chkIsFixed.Checked = false;
                    }
                    else if (Convert.ToBoolean(itemIsFixedVat.Rows[0]["is_tarrif"]))
                    {
                        this.chkIsFixed.Checked = true;
                        this.chkIsFixed.Attributes["style"] = "color:Green;";
                    }
                    DataTable itemIsRebatable = addItemBLL.getItemIsRebatable(num1);
                    if (itemIsRebatable.Rows.Count <= 0)
                    {
                        this.chkRebatable.Checked = false;
                    }
                    else if (Convert.ToBoolean(itemIsRebatable.Rows[0]["is_rebatable"]))
                    {
                        this.chkRebatable.Checked = true;
                        this.chkRebatable.Attributes["style"] = "color:Green;";
                    }
                    DataTable itemIsExempted = addItemBLL.GetItemIsExempted(num1);
                    if (itemIsExempted.Rows.Count <= 0)
                    {
                        this.chkExempted.Checked = false;
                    }
                    else if (Convert.ToBoolean(itemIsExempted.Rows[0]["is_exempted"]))
                    {
                        this.chkExempted.Checked = true;
                        this.chkExempted.Attributes["style"] = "color:Green;";
                    }
                    DataTable itemIsVds = addItemBLL.GetItemIsVds(num1);
                    if (itemIsVds.Rows.Count <= 0)
                    {
                        this.chkTaxDeducted.Checked = false;
                        this.partVDS.Visible = false;
                    }
                    else if (Convert.ToBoolean(itemIsVds.Rows[0]["is_vds"]))
                    {
                        this.chkTaxDeducted.Checked = true;
                        this.chkTaxDeducted.Attributes["style"] = "color:Green;";
                        this.partVDS.Visible = true;
                    }
                    this.GetAvailStock();
                    if (this.chkExempted.Checked)
                    {
                        int num3 = Convert.ToInt32(num);
                        decimal num4 = new decimal(0);
                        decimal num5 = new decimal(0);
                        decimal num6 = new decimal(0);
                        DataTable unitPriceFromPD = this.objCPBLL.GetUnitPriceFromPD(num3);
                        if (unitPriceFromPD.Rows.Count <= 0)
                        {
                            DataTable saleUnitPrice = this.objBLL.getSaleUnitPrice(num3);
                            if (saleUnitPrice.Rows.Count <= 0)
                            {
                                this.txtUnitPrice.Text = "0.00";
                            }
                            else
                            {
                                this.txtUnitPrice.Text = saleUnitPrice.Rows[0]["sale_unit_price"].ToString();
                            }
                        }
                        else
                        {
                            num4 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["prpsd_actl_prc"]);
                            num5 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["production_quantity"]);
                            num6 = num4 / num5;
                            this.txtUnitPrice.Text = num6.ToString();
                        }
                    }
                    else
                    {
                        this.GetPriceInfo();
                    }
                    this.showCatSubCat();
                    this.GetItemProperty();
                    this.Session["unit_price"] = this.txtUnitPrice.Text;
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetAvailStock");
            }
        }

        protected void drpItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpCategory.Items.Clear();
            this.drpSubCategory.Items.Clear();
            this.drpItem.Items.Clear();
            ListItem listItem = new ListItem("-- SELECT --", "-99");
        }

        protected void drpParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.drpParty.SelectedValue != "-99")
                {
                    this.LoadAgreement();
                    int num = Convert.ToInt32(this.drpParty.SelectedValue);
                    double num1 = 0;
                    DataTable partyCredlmt = this.objBLL.getPartyCredlmt(num);
                    if (partyCredlmt.Rows.Count > 0)
                    {
                        num1 = Convert.ToDouble(partyCredlmt.Rows[0]["credit_limit"].ToString());
                    }
                    this.lblLimit.Text = num1.ToString();
                    this.dtAmount = this.objBLL.GetcreditedAmountByParty((long)num);
                    if (this.dtAmount.Rows.Count <= 0)
                    {
                        this.lblDue.Text = "0.00";
                    }
                    else
                    {
                        this.lblDue.Text = this.dtAmount.Rows[0]["credit_amount"].ToString();
                    }
                    DataTable item = (DataTable)this.Session["PARTY_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("party_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.txtPartyBIN.Text = dataRow["party_bin"].ToString();
                        this.txtAddress.Text = dataRow["party_address"].ToString();
                        this.txtDestination.Text = dataRow["ultimate_destination"].ToString();
                        this.partyVDS.Text = dataRow["is_vds_deduct"].ToString();
                        this.txtNationalId.Text = dataRow["national_id_no"].ToString();
                        this.drpRegType.SelectedValue = dataRow["reg_type"].ToString();
                        DataTable partyInfo = this.orgRegInfo.GetPartyInfo(num);
                        this.txtBusinessInfo.Text = partyInfo.Rows[0]["business_info"].ToString();
                        this.txtAreaOfMfg.Text = partyInfo.Rows[0]["area_of_mfg"].ToString();
                        string empty = string.Empty;
                        if (partyInfo.Rows[0]["major_area_of_ecn_activity"].ToString() != "")
                        {
                            int num2 = 0;
                            DataTable economicInfo = this.orgRegInfo.GetEconomicInfo(partyInfo.Rows[0]["major_area_of_ecn_activity"].ToString());
                            for (int i = 0; i < economicInfo.Rows.Count; i++)
                            {
                                if (num2 != 0)
                                {
                                    empty = string.Concat(empty, ",", economicInfo.Rows[i]["code_name"].ToString());
                                }
                                else
                                {
                                    empty = economicInfo.Rows[i]["code_name"].ToString();
                                    num2++;
                                }
                            }
                        }
                        this.txtMajorEcoActivity.Text = empty;
                    }
                }
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
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
                else
                {
                    this.PropertyWiseQuantity();
                }
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
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
                else
                {
                    this.PropertyWiseQuantity();
                }
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
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
                else
                {
                    this.PropertyWiseQuantity();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpProp44_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
                else
                {
                    this.PropertyWiseQuantity();
                }
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
                this.GetPropertyWiseAvailStock();
                if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
                {
                    this.stickWiseQuantity();
                }
                else
                {
                    this.PropertyWiseQuantity();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void drpRegType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetPartyInfoRegistrationWise(Convert.ToInt16(this.drpRegType.SelectedValue.Trim()));
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
                this.LoadCategory();
                this.LoadItemsByCatgSubCatg();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpTransaction_CheckedChanged(object sender, EventArgs e)
        {
            SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
            if (this.drpTransaction.SelectedIndex == 0)
            {
                this.chkInexplicitExport.Checked = false;
                this.chkInexplicitExport.Visible = false;
                this.divexport.Visible = false;
                return;
            }
            if (this.drpTransaction.SelectedIndex == 1)
            {
                this.divexport.Visible = true;
                this.chkInexplicitExport.Visible = true;
            }
        }

        protected void drpTransaction2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadItems();
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
                else
                {
                    this.PropertyWiseQuantity();
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
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                int num = 0;
                string str = "";
                if (this.drpItem.SelectedValue != "-99")
                {
                    str = Convert.ToString(this.drpItem.SelectedValue);
                    saleDetailDAON.id = str;
                    string[] strArrays = str.Split(new char[] { '.' });
                    saleDetailDAON.ItemID = Convert.ToInt16(strArrays[0]);
                    num = Convert.ToInt16(strArrays[0]);
                    DataTable itemRequiredProperty = addItemBLL.getItemRequiredProperty(num);
                    this.lblUnit.Text = itemRequiredProperty.Rows[0]["unit_name"].ToString();
                    this.hdUnitID.Value = itemRequiredProperty.Rows[0]["unit_id"].ToString();
                    return;
                }
                this.lblUnit.Text = ".";
            }
        }

        private void fillDetailProperties()
        {
            string str = "";
            string str1 = "";
            double num = 0;
            int num1 = 0;
            ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LIST"] ?? new ArrayList();
            short num2 = Convert.ToInt16(item.Count + 1);
            try
            {
                string text = this.txtUnitPrice.Text;
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON()
                {
                    RowNo = num2
                };
                if (this.txtItemSerials.Text.ToString() != "")
                {
                    saleDetailDAON.itemSerials = this.txtItemSerials.Text.ToString();
                }
                if (this.drpCategory.SelectedValue != "-99" && this.drpCategory.SelectedValue != "")
                {
                    saleDetailDAON.CatID = Convert.ToInt32(this.drpCategory.SelectedValue);
                    saleDetailDAON.CategoryName = this.drpCategory.SelectedItem.ToString();
                }
                if (this.drpSubCategory.SelectedValue != "-99" && this.drpSubCategory.SelectedValue != "")
                {
                    saleDetailDAON.SubCatID = Convert.ToInt32(this.drpSubCategory.SelectedValue);
                    saleDetailDAON.SubCategoryName = this.drpSubCategory.SelectedItem.ToString();
                }
                if (this.drpItem.SelectedValue != "-99" && this.drpItem.SelectedValue != "")
                {
                    str = Convert.ToString(this.drpItem.SelectedValue);
                    saleDetailDAON.id = str;
                    string[] strArrays = str.Split(new char[] { '.' });
                    saleDetailDAON.ItemID = Convert.ToInt16(strArrays[0]);
                    num1 = Convert.ToInt16(strArrays[0]);
                    DataTable itemNameByItemId = this.objBLL.getItemNameByItemId(num1);
                    if (itemNameByItemId.Rows.Count > 0)
                    {
                        saleDetailDAON.ItemName = itemNameByItemId.Rows[0]["item_name"].ToString();
                    }
                    str1 = this.drpItem.SelectedItem.ToString();
                }
                saleDetailDAON.HS_Code = this.lblHSCode.Text;
                if (this.drpSaleType.SelectedValue == "WholeSale")
                {
                    saleDetailDAON.SaleType = "WholeSale";
                }
                else if (this.drpTransaction.SelectedValue == "Retail")
                {
                    saleDetailDAON.SaleType = "Retail";
                }
                if (this.drpTransaction.SelectedValue == "Local")
                {
                    saleDetailDAON.TransactionType = "L";
                }
                else if (this.drpTransaction.SelectedValue == "Export")
                {
                    saleDetailDAON.TransactionType = "E";
                }
                if (this.Label9.Text != " Per Unit.")
                {
                    saleDetailDAON.Quantity = Convert.ToDecimal(this.txtQuantity.Text.Trim());
                }
                else
                {
                    saleDetailDAON.Quantity = Convert.ToDecimal(this.txtFinalQuantity.Text.Trim());
                    saleDetailDAON.Perqty = "Per Unit.";
                }
                saleDetailDAON.SaleQuantity = Convert.ToDecimal(this.txtFinalQuantity.Text.Trim());
                saleDetailDAON.SaleUnitID = Convert.ToInt32(this.drpUnit.SelectedValue);
                saleDetailDAON.AvailStock = Convert.ToDouble(this.lblAvailStock.Text);
                saleDetailDAON.UnitID = Convert.ToInt32(this.hdUnitID.Value);
                saleDetailDAON.SaleUnitName = this.drpUnit.SelectedItem.ToString();
                saleDetailDAON.UnitName = this.drpUnit.SelectedItem.ToString();
                saleDetailDAON.Specification = this.txtSpecification.Value;
                saleDetailDAON.addtnProperty = this.txtaddProp.Text;
                saleDetailDAON.instStatus = this.installmentStatus.Text;
                if (saleDetailDAON.instStatus != "I")
                {
                    saleDetailDAON.installmentStatus = false;
                }
                else
                {
                    saleDetailDAON.installmentStatus = true;
                }
                if (this.scheduleId.Text != "")
                {
                    saleDetailDAON.scheduleId = Convert.ToInt32(this.scheduleId.Text);
                }
                if (this.lblProductType.Text != "W")
                {
                    saleDetailDAON.RealProperty = '0';
                }
                else
                {
                    saleDetailDAON.RealProperty = Convert.ToChar(this.lblProductType.Text);
                }
                saleDetailDAON.HealthCharge = (!string.IsNullOrEmpty(this.txthlthcharge.Text) ? Convert.ToDecimal(this.txthlthcharge.Text) : new decimal(0));
                saleDetailDAON.SD = Convert.ToDecimal(this.lblTotalSD.Text);
                saleDetailDAON.VAT = Convert.ToDecimal(this.lblTotalVAT.Text);
                saleDetailDAON.AIT = (!string.IsNullOrEmpty(this.txtAIT.Text) ? Convert.ToDecimal(this.txtAIT.Text) : new decimal(0));
                saleDetailDAON.SDRate = Convert.ToDecimal(this.lblSD.Text);
                saleDetailDAON.VATRate = Convert.ToDecimal(this.lblVAT.Text);
                saleDetailDAON.IsSrcTAXDeduct = this.chkTaxDeducted.Checked;
                saleDetailDAON.IsExempted = this.chkExempted.Checked;
                saleDetailDAON.Price = Convert.ToDecimal(this.txtTotalPrice.Text);
                if (this.txtBatchNo.Text != "")
                {
                    saleDetailDAON.BatchNo = this.txtBatchNo.Text.Trim();
                }
                else
                {
                    saleDetailDAON.BatchNo = "";
                }
                if (this.singleRemarks.Text == "")
                {
                    saleDetailDAON.RemarksDetail = "";
                }
                else if (this.drpAgreement.SelectedValue == "-99")
                {
                    saleDetailDAON.RemarksDetail = this.singleRemarks.Text.Trim();
                }
                else
                {
                    saleDetailDAON.RemarksDetail = string.Concat(this.drpAgreement.SelectedItem.ToString(), ",", this.singleRemarks.Text.Trim());
                }
                if (!this.chkRebatable.Checked)
                {
                    saleDetailDAON.Rebatable = "No";
                }
                else
                {
                    saleDetailDAON.IsRebatable = this.chkRebatable.Checked;
                    saleDetailDAON.Rebatable = "Yes";
                }
                saleDetailDAON.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                saleDetailDAON.isInexplicitExport = this.chkInexplicitExport.Checked;
                saleDetailDAON.RemarksDetail = BLL.Utility.ReplaceQuotes(this.singleRemarks.Text);
                if (!this.chkTaxDeducted.Checked)
                {
                    saleDetailDAON.SrcTAXDeduct = "No";
                }
                else
                {
                    saleDetailDAON.SrcTAXDeduct = "Yes";
                }
                if (!this.chkInexplicitExport.Checked)
                {
                    saleDetailDAON.DeemedExport = "No";
                }
                else
                {
                    saleDetailDAON.DeemedExport = "Yes";
                }
                if (!this.chkExempted.Checked)
                {
                    saleDetailDAON.Exempted = "No";
                }
                else
                {
                    saleDetailDAON.Exempted = "Yes";
                }
                if (!this.chkIsFixed.Checked)
                {
                    saleDetailDAON.IsFixed = false;
                    saleDetailDAON.Fixed = "No";
                }
                else
                {
                    saleDetailDAON.IsFixed = true;
                    saleDetailDAON.Fixed = "Yes";
                }
                if (this.HiddenIsTruncated.Value != "is_truncated")
                {
                    saleDetailDAON.Truncated = "No";
                    saleDetailDAON.IsTruncated = false;
                }
                else
                {
                    saleDetailDAON.IsTruncated = true;
                    saleDetailDAON.Truncated = "Yes";
                }
                if (!this.chkReduced.Checked)
                {
                    saleDetailDAON.Truncated = "No";
                    saleDetailDAON.IsTruncated = false;
                }
                else
                {
                    saleDetailDAON.IsTruncated = true;
                    saleDetailDAON.Truncated = "Yes";
                }
                if (!this.chkZeroRate.Checked)
                {
                    saleDetailDAON.ZeroRate = "No";
                    saleDetailDAON.IsZeroRate = false;
                }
                else
                {
                    saleDetailDAON.IsZeroRate = true;
                    saleDetailDAON.ZeroRate = "Yes";
                }
                if (!this.chkMrp.Checked)
                {
                    saleDetailDAON.Mrp = "No";
                    saleDetailDAON.IsMrp = false;
                }
                else
                {
                    saleDetailDAON.IsMrp = true;
                    saleDetailDAON.Mrp = "Yes";
                }
                if (this.drpProp11.Visible)
                {
                    saleDetailDAON.PropertyID1 = Convert.ToInt32(this.drpProp11.SelectedValue);
                    saleDetailDAON.Property1 = this.drpProp11.SelectedItem.ToString();
                }
                if (this.drpProp22.Visible)
                {
                    saleDetailDAON.PropertyID2 = Convert.ToInt32(this.drpProp22.SelectedValue);
                    saleDetailDAON.Property2 = this.drpProp22.SelectedItem.ToString();
                }
                if (this.drpProp33.Visible)
                {
                    saleDetailDAON.PropertyID3 = Convert.ToInt32(this.drpProp33.SelectedValue);
                    saleDetailDAON.Property3 = this.drpProp33.SelectedItem.ToString();
                }
                if (this.drpProp44.Visible)
                {
                    saleDetailDAON.PropertyID4 = Convert.ToInt32(this.drpProp44.SelectedValue);
                    saleDetailDAON.Property4 = this.drpProp44.SelectedItem.ToString();
                }
                if (this.drpProp55.Visible)
                {
                    saleDetailDAON.PropertyID5 = Convert.ToInt32(this.drpProp55.SelectedValue);
                    saleDetailDAON.Property5 = this.drpProp55.SelectedItem.ToString();
                }
                saleDetailDAON.ItemType = this.hdItemType.Value;
                if (this.chkTaxDeducted.Checked)
                {
                    saleDetailDAON.VDS = true;
                }
                string[] strArrays1 = str1.Split(new char[] { '-' });
                if (strArrays1 != null && strArrays1.Count<string>() > 0)
                {
                    string str2 = strArrays1[strArrays1.Count<string>() - 3];
                }
                if (str1.Contains("Local"))
                {
                    saleDetailDAON.TypeP = "L";
                }
                if (str1.Contains("Import"))
                {
                    saleDetailDAON.TypeP = "I";
                }
                if (str1.Contains("Production"))
                {
                    saleDetailDAON.TypeP = "F";
                }
                if (str1.Contains("Service"))
                {
                    saleDetailDAON.TypeP = "S";
                }
                saleDetailDAON.PropStk = (!string.IsNullOrEmpty(this.lblprpstk.Text) ? this.lblprpstk.Text : "0");
                DataTable itemType = this.dbBLLLL.getItemType(num1);
                string empty = string.Empty;
                if (itemType.Rows.Count > 0)
                {
                    empty = itemType.Rows[0]["product_type"].ToString();
                }
                if (empty == "C" && saleDetailDAON.TypeP != "S")
                {
                    saleDetailDAON.TypeP = "F";
                }
                saleDetailDAON.ProductType = this.lblProductType.Text;
                if (this.txtDiscount.Text.Length <= 0)
                {
                    saleDetailDAON.Discount = new decimal(0);
                }
                else
                {
                    saleDetailDAON.Discount = Convert.ToDecimal(this.txtDiscount.Text.ToString());
                }
                if (this.txtdiscountpct.Text.Length <= 0)
                {
                    saleDetailDAON.Discount_pct = new decimal(0);
                }
                else
                {
                    saleDetailDAON.Discount_pct = Convert.ToDecimal(this.txtdiscountpct.Text.ToString());
                }
                if (this.chkTaxDeducted.Checked)
                {
                    saleDetailDAON.UnitPriceBDT = Convert.ToDecimal(this.lblUnitPrice.Text);
                    saleDetailDAON.UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
                    saleDetailDAON.TotalPrice = saleDetailDAON.UnitPriceBDT * saleDetailDAON.SaleQuantity;
                    if (this.installmentStatus.Text == "I")
                    {
                        saleDetailDAON.TotalSalePrice = Convert.ToDecimal(this.lblTotalSalePrc.Text);
                    }
                    else
                    {
                        saleDetailDAON.TotalSalePrice = (saleDetailDAON.UnitPriceBDT * saleDetailDAON.Quantity) + saleDetailDAON.SD + saleDetailDAON.VAT;
                    }
                    saleDetailDAON.NBRPrice = saleDetailDAON.TotalSalePrice / saleDetailDAON.SaleQuantity;
                    saleDetailDAON.Net_bill = saleDetailDAON.TotalSalePrice - saleDetailDAON.Discount;
                    saleDetailDAON.DSD = (Convert.ToDecimal(this.txtUnitPrice.Text) * Convert.ToDecimal(this.lblSD.Text)) / new decimal(100);
                    saleDetailDAON.DVAT = ((Convert.ToDecimal(this.txtUnitPrice.Text) + saleDetailDAON.DSD) * Convert.ToDecimal(this.lblVAT.Text)) / new decimal(100);
                    saleDetailDAON.DUnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
                }
                else if (this.hdItemType.Value != "I")
                {
                    saleDetailDAON.UnitPriceBDT = Convert.ToDecimal(this.lblUnitPrice.Text);
                    saleDetailDAON.UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
                    saleDetailDAON.TotalPrice = (saleDetailDAON.UnitPriceBDT * saleDetailDAON.Quantity) + saleDetailDAON.SD + saleDetailDAON.VAT;
                    if (this.installmentStatus.Text == "I")
                    {
                        saleDetailDAON.TotalSalePrice = Convert.ToDecimal(this.lblTotalSalePrc.Text);
                    }
                    else
                    {
                        saleDetailDAON.TotalSalePrice = (saleDetailDAON.UnitPriceBDT * saleDetailDAON.Quantity) + saleDetailDAON.SD + saleDetailDAON.VAT;
                    }
                    saleDetailDAON.NBRPrice = saleDetailDAON.TotalSalePrice / saleDetailDAON.Quantity;
                    saleDetailDAON.Net_bill = saleDetailDAON.TotalSalePrice - saleDetailDAON.Discount;
                    saleDetailDAON.DSD = (Convert.ToDecimal(this.txtUnitPrice.Text) * Convert.ToDecimal(this.lblSD.Text)) / new decimal(100);
                    saleDetailDAON.DVAT = ((Convert.ToDecimal(this.txtUnitPrice.Text) + saleDetailDAON.DSD) * Convert.ToDecimal(this.lblVAT.Text)) / new decimal(100);
                    saleDetailDAON.DUnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
                }
                else
                {
                    saleDetailDAON.UnitPriceBDT = Convert.ToDecimal(this.lblUnitPrice.Text);
                    saleDetailDAON.UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
                    saleDetailDAON.TotalPrice = saleDetailDAON.UnitPriceBDT * saleDetailDAON.Quantity;
                    saleDetailDAON.TotalPricegrid = saleDetailDAON.UnitPrice * saleDetailDAON.SaleQuantity;
                    saleDetailDAON.NBRPrice = Convert.ToDecimal(this.lblNBRPrice.Text);
                    if (this.installmentStatus.Text == "I")
                    {
                        saleDetailDAON.TotalSalePrice = Convert.ToDecimal(this.lblTotalSalePrc.Text);
                    }
                    else
                    {
                        saleDetailDAON.TotalSalePrice = (saleDetailDAON.UnitPriceBDT * saleDetailDAON.Quantity) + saleDetailDAON.SD + saleDetailDAON.VAT;
                    }
                    saleDetailDAON.Net_bill = saleDetailDAON.TotalSalePrice - saleDetailDAON.Discount;
                    saleDetailDAON.DSD = (Convert.ToDecimal(this.txtUnitPrice.Text) * Convert.ToDecimal(this.lblSD.Text)) / new decimal(100);
                    saleDetailDAON.DVAT = ((Convert.ToDecimal(this.txtUnitPrice.Text) + saleDetailDAON.DSD) * Convert.ToDecimal(this.lblVAT.Text)) / new decimal(100);
                    saleDetailDAON.DUnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text);
                }
                if (this.installmentStatus.Text != "I" && saleDetailDAON.TypeP != "S" && saleDetailDAON.ProductType != "W")
                {
                    num = Convert.ToDouble(this.lblAvailStock.Text);
                    if (saleDetailDAON.Quantity > Convert.ToDecimal(num))
                    {
                        this.msgBox.AddMessage(string.Concat("Stock is not available. Current stock: ", num.ToString()), MsgBoxs.enmMessageType.Error);
                        return;
                    }
                }
                if ((new ChallanBLL()).GetApproverStage().Rows.Count < 1)
                {
                    saleDetailDAON.ApproveStage = "F";
                    this.ClientButton.Enabled = true;
                }
                else
                {
                    string approveStage = this.getApproveStage();
                    if (approveStage != "")
                    {
                        saleDetailDAON.ApproveStage = approveStage;
                    }
                    else
                    {
                        saleDetailDAON.ApproveStage = "1";
                    }
                    if (approveStage != "F")
                    {
                        this.ClientButton.Enabled = false;
                    }
                    else
                    {
                        this.ClientButton.Enabled = true;
                    }
                }
                if (this.btnAdd.Text.Trim() != SaleChallan_11s.enmBtnText.Update.ToString())
                {
                    saleDetailDAON.RowNo = num2;
                    item.Add(saleDetailDAON);
                }
                else
                {
                    saleDetailDAON.RowNo = Convert.ToInt16(this.ViewState["selctedRowNoSale"]);
                    if (saleDetailDAON.RowNo > 0)
                    {
                        int rowNo = saleDetailDAON.RowNo - 1;
                        if (this.gvItem.Rows.Count > 0)
                        {
                            item.RemoveAt(rowNo);
                        }
                        item.Insert(rowNo, saleDetailDAON);
                        this.setDetaiAddMode();
                        this.ViewState["selctedRowNoSale"] = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "fillDetailProperties");
            }
            this.Session["SALE_DETAIL_LIST"] = item;
            this.Session["SALE_DETAIL_LISTF"] = this.Session["SALE_DETAIL_LIST"];
        }

        private void fillGiftDetailProperties()
        {
            string str = "";
            string str1 = "";
            ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            try
            {
                SaleGiftDetailDAON saleGiftDetailDAON = new SaleGiftDetailDAON()
                {
                    RowNo = num
                };
                if (this.drpGiftItem.SelectedValue != "-99" && this.drpGiftItem.SelectedValue != "")
                {
                    str = Convert.ToString(this.drpGiftItem.SelectedValue);
                    saleGiftDetailDAON.ItemWithTypeID = str;
                    string[] strArrays = str.Split(new char[] { '.' });
                    saleGiftDetailDAON.ItemID = Convert.ToInt16(strArrays[0]);
                    Convert.ToInt16(strArrays[0]);
                    saleGiftDetailDAON.ItemName = this.drpGiftItem.SelectedItem.ToString();
                    str1 = this.drpGiftItem.SelectedItem.ToString();
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
                }
                saleGiftDetailDAON.UnitName = this.drpGiftUnit.SelectedItem.ToString();
                saleGiftDetailDAON.UnitId = Convert.ToInt16(this.drpGiftUnit.SelectedValue);
                saleGiftDetailDAON.GiftQuantity = Convert.ToDecimal(this.txtGiftQnt.Text);
                saleGiftDetailDAON.Remarks = this.txtGiftRemarks.Text;
                if (this.btnAddGift.Text.Trim() != SaleChallan_11s.enmBtnText.Update.ToString())
                {
                    saleGiftDetailDAON.RowNo = num;
                    item.Add(saleGiftDetailDAON);
                }
                else
                {
                    saleGiftDetailDAON.RowNo = Convert.ToInt16(this.ViewState["selctedGiftRowNoSale"]);
                    if (saleGiftDetailDAON.RowNo > 0)
                    {
                        int rowNo = saleGiftDetailDAON.RowNo - 1;
                        item.RemoveAt(rowNo);
                        item.Insert(rowNo, saleGiftDetailDAON);
                        this.setGiftDetaiAddMode();
                        this.ViewState["selctedGiftRowNoSale"] = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "fillGiftDetailProperties");
            }
            this.Session["GIFT_SALE_DETAIL_LIST"] = item;
        }

        private void fillPendingProperties()
        {
            this.Label5.Text = "Installment Amount";
            ArrayList item = (ArrayList)this.Session["SALE_PendingDETAIL_LIST"] ?? new ArrayList();
            int num = Convert.ToInt16(this.drpParty.SelectedValue);
            string str = this.drpAgreement.SelectedItem.ToString();
            DataTable installmentInfo = this.objBLL.getInstallmentInfo(num, str);
            short num1 = Convert.ToInt16(installmentInfo.Rows.Count + 1);
            try
            {
                string text = this.txtUnitPrice.Text;
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON()
                {
                    RowNo = num1,
                    ItemID = Convert.ToInt32(installmentInfo.Rows[0]["item_id"].ToString())
                };
                DataTable truncated = this.objItemBLL.getTruncated(saleDetailDAON.ItemID);
                if (truncated.Rows.Count > 0)
                {
                    this.HiddenIsTruncated.Value = null;
                    if (!Convert.ToBoolean(truncated.Rows[0]["is_truncated"]))
                    {
                        this.HiddenIsTruncated.Value = null;
                    }
                    else
                    {
                        this.chkReduced.Checked = true;
                        this.chkReduced.Attributes["style"] = "color:Green;";
                        this.HiddenIsTruncated.Value = "is_truncated";
                    }
                }
                this.chkZeroRate.Checked = false;
                DataTable itemIsZeroRate = this.objItemBLL.getItemIsZeroRate(saleDetailDAON.ItemID);
                if (itemIsZeroRate.Rows.Count > 0 && Convert.ToBoolean(itemIsZeroRate.Rows[0]["is_zero_rate"]))
                {
                    this.chkZeroRate.Checked = true;
                    this.chkZeroRate.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsMRP = this.objItemBLL.getItemIsMRP(saleDetailDAON.ItemID);
                if (itemIsMRP.Rows.Count <= 0)
                {
                    this.chkMrp.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsMRP.Rows[0]["is_mrp"]))
                {
                    this.chkMrp.Checked = true;
                    this.chkMrp.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsFixedVat = this.objItemBLL.GetItemIsFixedVat(saleDetailDAON.ItemID);
                if (itemIsFixedVat.Rows.Count <= 0)
                {
                    this.chkIsFixed.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsFixedVat.Rows[0]["is_tarrif"]))
                {
                    this.chkIsFixed.Checked = true;
                    this.chkIsFixed.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsRebatable = this.objItemBLL.getItemIsRebatable(saleDetailDAON.ItemID);
                if (itemIsRebatable.Rows.Count <= 0)
                {
                    this.chkRebatable.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsRebatable.Rows[0]["is_rebatable"]))
                {
                    this.chkRebatable.Checked = true;
                    this.chkRebatable.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsExempted = this.objItemBLL.GetItemIsExempted(saleDetailDAON.ItemID);
                if (itemIsExempted.Rows.Count <= 0)
                {
                    this.chkExempted.Checked = false;
                }
                else if (Convert.ToBoolean(itemIsExempted.Rows[0]["is_exempted"]))
                {
                    this.chkExempted.Checked = true;
                    this.chkExempted.Attributes["style"] = "color:Green;";
                }
                DataTable itemIsVds = this.objItemBLL.GetItemIsVds(saleDetailDAON.ItemID);
                if (itemIsVds.Rows.Count <= 0)
                {
                    this.chkTaxDeducted.Checked = false;
                    this.partVDS.Visible = false;
                }
                else if (Convert.ToBoolean(itemIsVds.Rows[0]["is_vds"]))
                {
                    this.chkTaxDeducted.Checked = true;
                    this.chkTaxDeducted.Attributes["style"] = "color:Green;";
                    this.partVDS.Visible = true;
                }
                DataTable catSubCat = this.objBLL.getCatSubCat(saleDetailDAON.ItemID);
                if (catSubCat != null)
                {
                    this.drpCategory.SelectedValue = catSubCat.Rows[0]["category_id"].ToString();
                    this.drpSubCategory.SelectedValue = catSubCat.Rows[0]["sub_category_id"].ToString();
                    this.lblUnit.Text = catSubCat.Rows[0]["unit_code"].ToString();
                }
                saleDetailDAON.TypeP = installmentInfo.Rows[0]["product_type"].ToString();
                if (saleDetailDAON.TypeP == "L")
                {
                    saleDetailDAON.id = string.Concat(installmentInfo.Rows[0]["item_id"].ToString(), ".1");
                }
                if (saleDetailDAON.TypeP == "I")
                {
                    saleDetailDAON.id = string.Concat(installmentInfo.Rows[0]["item_id"].ToString(), ".2");
                }
                if (saleDetailDAON.TypeP == "R")
                {
                    saleDetailDAON.id = string.Concat(installmentInfo.Rows[0]["item_id"].ToString(), ".3");
                }
                this.drpItem.SelectedValue = saleDetailDAON.id;
                Dictionary<int, int> nums = (Dictionary<int, int>)this.Session["chkProperty"];
                if (installmentInfo.Rows[0]["status"].ToString() != "I")
                {
                    this.GetAdditionalProperty();
                }
                else
                {
                    this.GetAdditionalPropertybySaleId();
                    if (this.gvAddtnProperty.Rows.Count > 0)
                    {
                        CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[0].FindControl("chkChallan");
                        checkBox.Checked = true;
                        int num2 = Convert.ToInt32(((HiddenField)this.gvAddtnProperty.Rows[0].FindControl("additionalInfoId")).Value);
                        int num3 = Convert.ToInt32(this.gvAddtnProperty.DataKeys[0].Value.ToString());
                        nums.Add(num2, num3);
                        this.Session["chkProperty"] = nums;
                        this.txtaddProp.Visible = true;
                    }
                }
                this.GetAvailStock();
                this.GetPriceInfo();
                Label label = this.lblUnitPrice;
                decimal num4 = Convert.ToDecimal(installmentInfo.Rows[0]["installment_without_interest_per_month"]);
                label.Text = num4.ToString();
                this.txtUnitPrice.Text = installmentInfo.Rows[0]["installment_without_interest_per_month"].ToString();
                this.txtQuantity.Text = "1";
                this.txtFinalQuantity.Text = "1";
                this.tbTotalVAT.Text = installmentInfo.Rows[0]["vat_per_month"].ToString();
                this.txtTotalPrice.Text = installmentInfo.Rows[0]["installment_with_interest_per_month"].ToString();
                this.lblTotalVAT.Text = installmentInfo.Rows[0]["vat_per_month"].ToString();
                TextBox textBox = this.txtPriceIncludingVat;
                decimal num5 = Convert.ToDecimal(installmentInfo.Rows[0]["installment_without_interest_per_month"]) + Convert.ToDecimal(installmentInfo.Rows[0]["vat_per_month"]);
                textBox.Text = num5.ToString();
                TextBox str1 = this.txtTotalSalePrice;
                decimal num6 = Convert.ToDecimal(installmentInfo.Rows[0]["installment_without_interest_per_month"]) + Convert.ToDecimal(installmentInfo.Rows[0]["vat_per_month"]);
                str1.Text = num6.ToString();
                Label label1 = this.lblSaleamnt;
                decimal num7 = Convert.ToDecimal(installmentInfo.Rows[0]["installment_without_interest_per_month"]) + Convert.ToDecimal(installmentInfo.Rows[0]["vat_per_month"]);
                label1.Text = num7.ToString();
                Label str2 = this.lblTotalSalePrc;
                decimal num8 = Convert.ToDecimal(installmentInfo.Rows[0]["installment_without_interest_per_month"]) + Convert.ToDecimal(installmentInfo.Rows[0]["vat_per_month"]);
                str2.Text = num8.ToString();
                if (installmentInfo.Rows[0]["schedule_no"].ToString() != "0")
                {
                    this.singleRemarks.Text = string.Concat("Installment No-", installmentInfo.Rows[0]["schedule_no"].ToString());
                }
                else
                {
                    this.singleRemarks.Text = "Down Payment";
                }
                this.installmentStatus.Text = installmentInfo.Rows[0]["status"].ToString();
                this.scheduleId.Text = installmentInfo.Rows[0]["scheduler_id"].ToString();
                item.Add(saleDetailDAON);
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "fillDetailProperties");
            }
        }

        private DropDownList fillPortCode(DropDownList drpPortCode)
        {
            DataTable dataTable = (new ChallanBLL()).GetportInfo();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                drpPortCode.DataSource = dataTable;
                drpPortCode.DataTextField = dataTable.Columns["code_short_name"].ToString();
                drpPortCode.DataValueField = dataTable.Columns["code_id_d"].ToString();
                drpPortCode.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            drpPortCode.Items.Insert(0, listItem);
            return drpPortCode;
        }

        protected void GetAdditionalProperty()
        {
            int num = 0;
            string str = "";
            str = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str.Split(new char[] { '.' });
            num = Convert.ToInt16(strArrays[0]);
            string str1 = this.drpItem.SelectedItem.ToString();
            string str2 = "";
            AddItemBLL addItemBLL = new AddItemBLL();
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
            DataTable dataTable = this.objPDBll.geAdditionalPropertybyItemID(num, str2);
            if (dataTable.Rows.Count > 0)
            {
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
            this.divaddprop.Visible = true;
        }

        protected void GetAdditionalPropertybySaleId()
        {
            int num = 0;
            string str = "";
            str = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str.Split(new char[] { '.' });
            num = Convert.ToInt16(strArrays[0]);
            string str1 = this.drpItem.SelectedItem.ToString();
            string str2 = this.drpAgreement.SelectedItem.ToString();
            DataTable saleChallanIdbyAgreementNo = this.objBLL.getSaleChallanIdbyAgreementNo(str2);
            int num1 = 0;
            if (saleChallanIdbyAgreementNo.Rows.Count > 0)
            {
                num1 = Convert.ToInt32(saleChallanIdbyAgreementNo.Rows[0]["challan_id"]);
            }
            AddItemBLL addItemBLL = new AddItemBLL();
            str1.Contains("Local");
            str1.Contains("Import");
            str1.Contains("Production");
            if (num1 == 0)
            {
                this.divaddprop.Visible = true;
            }
            else
            {
                DataTable dataTable = this.objPDBll.geAdditionalPropertybySaleChallanID(num, num1);
                if (dataTable.Rows.Count > 0)
                {
                    short num2 = 0;
                    short num3 = 0;
                    short num4 = 0;
                    short num5 = 0;
                    short num6 = 0;
                    string str3 = "";
                    string str4 = "";
                    string str5 = "";
                    string str6 = "";
                    string str7 = "";
                    DataTable appCodeDetailName = null;
                    num2 = Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
                    num3 = Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
                    num4 = Convert.ToInt16(dataTable.Rows[0]["property_id3"]);
                    num5 = Convert.ToInt16(dataTable.Rows[0]["property_id4"]);
                    num6 = Convert.ToInt16(dataTable.Rows[0]["property_id5"]);
                    ArrayList arrayLists = new ArrayList();
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num2);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        BoundField boundField = new BoundField();
                        str3 = appCodeDetailName.Rows[0]["code_name"].ToString();
                        this.tableNameList.Add(str3);
                        boundField.HeaderText = str3;
                        boundField.DataField = "Property1_Text";
                        this.gvAddtnProperty.Columns.Add(boundField);
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num3);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        BoundField boundField1 = new BoundField();
                        str4 = appCodeDetailName.Rows[0]["code_name"].ToString();
                        this.tableNameList.Add(str4);
                        boundField1.HeaderText = str4;
                        boundField1.DataField = "Property2_Text";
                        this.gvAddtnProperty.Columns.Add(boundField1);
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num4);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        BoundField boundField2 = new BoundField();
                        str5 = appCodeDetailName.Rows[0]["code_name"].ToString();
                        this.tableNameList.Add(str5);
                        boundField2.HeaderText = str5;
                        boundField2.DataField = "Property3_Text";
                        this.gvAddtnProperty.Columns.Add(boundField2);
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num5);
                    if (appCodeDetailName.Rows.Count > 0)
                    {
                        BoundField boundField3 = new BoundField();
                        str6 = appCodeDetailName.Rows[0]["code_name"].ToString();
                        this.tableNameList.Add(str6);
                        boundField3.HeaderText = str6;
                        boundField3.DataField = "Property4_Text";
                        this.gvAddtnProperty.Columns.Add(boundField3);
                    }
                    appCodeDetailName = addItemBLL.GetAppCodeDetailName(num6);
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
            }
            DataTable batchNo = addItemBLL.getBatchNo(num);
            if (batchNo.Rows.Count > 0)
            {
                this.txtBatchNo.Text = batchNo.Rows[0]["batch_no"].ToString();
            }
        }

        private string getApproveStage()
        {
            string str = "";
            if (this.gvApprvItem.Rows.Count > 0 && this.gvApprvItem.SelectedValue != null)
            {
                int num = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ChallanID"]);
                ChallanBLL challanBLL = new ChallanBLL();
                DataTable approverStage = challanBLL.GetApproverStage();
                if (approverStage.Rows.Count > 0)
                {
                    DataTable saleApproveStage = challanBLL.getSaleApproveStage(num);
                    if (saleApproveStage.Rows.Count > 0)
                    {
                        int count = approverStage.Rows.Count;
                        int num1 = Convert.ToInt32(saleApproveStage.Rows[0]["approver_stage"]);
                        int num2 = count - num1;
                        if (num2 != 1)
                        {
                            str = num2.ToString();
                        }
                        else
                        {
                            str = "F";
                            this.ClientButton.Enabled = true;
                        }
                    }
                }
            }
            return str;
        }

        private string getApproveStagebyChallanId(int ChallanID)
        {
            string str = "";
            ChallanBLL challanBLL = new ChallanBLL();
            DataTable approverStage = challanBLL.GetApproverStage();
            if (approverStage.Rows.Count > 0)
            {
                DataTable saleApproveStage = challanBLL.getSaleApproveStage(ChallanID);
                if (saleApproveStage.Rows.Count > 0)
                {
                    int count = approverStage.Rows.Count;
                    int num = Convert.ToInt32(saleApproveStage.Rows[0]["approver_stage"]);
                    int num1 = count - num;
                    if (num1 != 1)
                    {
                        str = num1.ToString();
                    }
                    else
                    {
                        str = "F";
                        this.ClientButton.Enabled = true;
                    }
                }
            }
            return str;
        }

        private void GetAvailGiftStock()
        {
            try
            {
                SaleBLL saleBLL = new SaleBLL();
                string str = "";
                string str1 = "";
                DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", null);
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                int num = 0;
                string str2 = "";
                if (this.drpGiftItem.SelectedValue == "-99")
                {
                    this.lblGiftAvailStock.Text = ".";
                    this.hdGiftUnitID.Value = "";
                    this.lblgiftavlstock.Text = "0";
                }
                else
                {
                    str = this.drpGiftItem.SelectedItem.ToString();
                    str2 = Convert.ToString(this.drpGiftItem.SelectedValue);
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
                        empty = itemType.Rows[0]["product_type"].ToString();
                    }
                    if (empty == "C")
                    {
                        empty1 = "F";
                    }
                    if (empty1 == "")
                    {
                        empty1 = str1;
                    }
                    dataTable = saleBLL.GetSaleAvailableStockN(num, str1, dateTime, empty1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.lblGiftUnit.Text = dataTable.Rows[0]["unit_code"].ToString();
                        this.hdGiftUnitID.Value = dataTable.Rows[0]["unit_id"].ToString();
                        this.GetGiftUnitName(Convert.ToInt16(this.hdGiftUnitID.Value));
                        if (dataTable.Rows[0]["item_type"].ToString() != "I")
                        {
                            this.lblAvailStock.Text = "0";
                        }
                        else
                        {
                            this.lblGiftAvailStock.Text = dataTable.Rows[0]["availStock"].ToString();
                            this.lblgiftavlstock.Text = string.Concat(dataTable.Rows[0]["availStock"].ToString(), " ", this.lblGiftUnit.Text);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetAvailStock");
            }
        }

        private void GetAvailStock()
        {
            try
            {
                SaleBLL saleBLL = new SaleBLL();
                string str = "";
                string str1 = "";
                DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", null);
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                int num = 0;
                string str2 = "";
                if (this.drpItem.SelectedValue == "-99")
                {
                    this.lblUnit.Text = ".";
                    this.hdUnitID.Value = "";
                    this.hdItemType.Value = "";
                    this.lblAvailStock.Text = "0";
                    this.chkExempted.Checked = false;
                    this.chkRebatable.Checked = false;
                    this.chkZeroRate.Checked = false;
                    this.chkInexplicitExport.Checked = false;
                }
                else
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
                        this.hdUnitID.Value = dataTable.Rows[0]["unit_id"].ToString();
                        this.GetUnitName(Convert.ToInt16(this.hdUnitID.Value));
                        this.hdItemType.Value = dataTable.Rows[0]["item_type"].ToString();
                        this.chkRebatable.Checked = Convert.ToBoolean(Convert.ToInt16(dataTable.Rows[0]["is_rebatable"]));
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
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetAvailStock");
            }
        }

        private void GetAvailStockbeforeApprv(int itemID, string itemType)
        {
            try
            {
                SaleBLL saleBLL = new SaleBLL();
                DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", null);
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2 = this.dbBLLLL.getItemType(itemID);
                string empty = string.Empty;
                string str = string.Empty;
                if (dataTable2.Rows.Count > 0)
                {
                    dataTable2.Rows[0]["product_type"].ToString();
                }
                dataTable = saleBLL.GetSaleAvailableStockN(itemID, itemType, dateTime, itemType);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.lblUnit.Text = dataTable.Rows[0]["unit_code"].ToString();
                    this.hdUnitID.Value = dataTable.Rows[0]["unit_id"].ToString();
                    this.GetUnitName(Convert.ToInt16(this.hdUnitID.Value));
                    this.hdItemType.Value = dataTable.Rows[0]["item_type"].ToString();
                    this.chkRebatable.Checked = Convert.ToBoolean(Convert.ToInt16(dataTable.Rows[0]["is_rebatable"]));
                    if (dataTable.Rows[0]["item_type"].ToString() != "I")
                    {
                        this.lblAvailStock.Text = "0";
                    }
                    else
                    {
                        this.lblAvailStock.Text = dataTable.Rows[0]["availStock"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetAvailStock");
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
                        DataTable selectedBusinessUnitBranchInfo = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                        if (selectedBusinessUnitBranchInfo != null && selectedBusinessUnitBranchInfo.Rows.Count > 0)
                        {
                            this.drpBranchName.DataSource = selectedBusinessUnitBranchInfo;
                            this.drpBranchName.DataTextField = selectedBusinessUnitBranchInfo.Columns["branch_unit_name"].ToString();
                            this.drpBranchName.DataValueField = selectedBusinessUnitBranchInfo.Columns["org_branch_reg_id"].ToString();
                            this.drpBranchName.DataBind();
                        }
                    }
                    else
                    {
                        ListItem listItem = new ListItem("Head Office", "0");
                        this.drpBranchName.Items.Insert(0, listItem);
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
                if (num == 2 || num == 1)
                {
                    this.drpBranchName.Enabled = true;
                    DataTable dataTable = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpBranchName.DataSource = dataTable;
                        this.drpBranchName.DataTextField = dataTable.Columns["branch_unit_name"].ToString();
                        this.drpBranchName.DataValueField = dataTable.Columns["org_branch_reg_id"].ToString();
                        this.drpBranchName.DataBind();
                    }
                    this.GetBranchAddress();
                    this.GetBranchBIN();
                }
            }
        }

        private void GetChDtTimeInWords()
        {
        }

        private int GetColumnIndexByName(GridView grid, string name)
        {
            int num;
            IEnumerator enumerator = grid.Columns.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    DataControlField current = (DataControlField)enumerator.Current;
                    if (current.HeaderText.ToLower().Trim() != name.ToLower().Trim())
                    {
                        continue;
                    }
                    num = grid.Columns.IndexOf(current);
                    return num;
                }
                return -1;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            return num;
        }

        private void GetCPCCode()
        {
            DataTable cPCCodeforSale = (new ChallanBLL()).GetCPCCodeforSale();
            if (cPCCodeforSale != null && cPCCodeforSale.Rows.Count > 0)
            {
                this.drpCPC.DataSource = cPCCodeforSale;
                this.drpCPC.DataTextField = cPCCodeforSale.Columns["cpc_code"].ToString();
                this.drpCPC.DataValueField = cPCCodeforSale.Columns["cpc_code_id"].ToString();
                this.drpCPC.DataBind();
            }
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpCPC.Items.Insert(0, listItem);
        }

        public object GetCred()
        {
            return new { username = "adiba", password = "123" };
        }

        private void GetDelDtTimeInWords()
        {
        }

        private void GetGiftUnitName(int unitID)
        {
            DataTable allUnit = (new AddItemBLL()).getAllUnit();
            if (allUnit.Rows.Count > 0)
            {
                this.drpGiftUnit.DataSource = allUnit;
                this.drpGiftUnit.DataTextField = allUnit.Columns["unit_code"].ToString();
                this.drpGiftUnit.DataValueField = allUnit.Columns["unit_id"].ToString();
                this.drpGiftUnit.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpGiftUnit.Items.Insert(0, listItem);
                this.drpGiftUnit.SelectedValue = unitID.ToString();
            }
        }

        private SaleMasterDAON GetInserMasterValues(SaleMasterDAON objMDAO)
        {
            try
            {
                ArrayList item = (ArrayList)base.Cache["SALE_MASTER_DETAIL"] ?? new ArrayList();
                objMDAO.Org_branch_reg_id = Convert.ToInt32(this.drpBranchName.SelectedValue);
                objMDAO.ChallanType = 'S';
                this.GetNextChallanNo();
                objMDAO.ChallanNo = BLL.Utility.ReplaceQuotes(this.txtChallanNo.Text);
                objMDAO.ChallanBookID = Convert.ToInt32(this.hdBookId.Value);
                objMDAO.ChallanPageNo = Convert.ToInt32(this.hdPageNo.Value);
                objMDAO.OrgName = this.lt_companyName.Text.ToString();
                objMDAO.OrgAddress = this.It_companyAddress.Text.ToString();
                objMDAO.OrgBin = this.lblOrgBIN.Text.ToString();
                if (this.drpTransaction.SelectedIndex == 0)
                {
                    objMDAO.TransactionType = 'L';
                }
                else if (this.drpTransaction.SelectedIndex == 1)
                {
                    objMDAO.TransactionType = 'E';
                    objMDAO.BankID = Convert.ToInt16(this.drpBank.SelectedValue);
                    objMDAO.BranchID = Convert.ToInt16(this.drpBranch.SelectedValue);
                    objMDAO.portcodeId = (!string.IsNullOrEmpty(this.drpPortCode.SelectedValue) ? Convert.ToInt32(this.drpPortCode.SelectedValue) : 0);
                    objMDAO.noofItem = (!string.IsNullOrEmpty(this.txtnoItem.Text) ? Convert.ToInt32(this.txtnoItem.Text) : 0);
                    objMDAO.totalPack = (!string.IsNullOrEmpty(this.txtTotalPack.Text) ? Convert.ToInt32(this.txtTotalPack.Text) : 0);
                    objMDAO.CPC = this.drpCPC.SelectedItem.ToString();
                    objMDAO.ExportDate = DateTime.ParseExact(this.txtExportDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                if (this.chkDiscard.Checked)
                {
                    objMDAO.TransactionType = 'D';
                    objMDAO.ChallanPageDiscardReason_m = 12;
                    objMDAO.ChallanPageDiscardReason_d = Convert.ToInt32(this.drpDiscardReason.SelectedValue);
                }
                if (this.drpSaleType.SelectedValue == "S")
                {
                    objMDAO.SaleType = 'S';
                }
                if (this.drpSaleType.SelectedValue == "W")
                {
                    objMDAO.SaleType = 'W';
                }
                else if (this.drpSaleType.SelectedValue == "R")
                {
                    objMDAO.SaleType = 'R';
                }
                else if (this.drpSaleType.SelectedValue == "P")
                {
                    objMDAO.SaleType = 'P';
                }
                else if (this.drpSaleType.SelectedValue == "T")
                {
                    objMDAO.SaleType = 'T';
                }
                if (!string.IsNullOrEmpty(this.txtChallanDate.Text.Trim()))
                {
                    string[] strArrays = new string[] { this.txtChallanDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                    objMDAO.ChallanDate = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                if (!string.IsNullOrEmpty(this.txtDeliveryDate.Text.Trim()))
                {
                    string[] strArrays1 = new string[] { this.txtDeliveryDate.Text.Trim(), " ", this.drpDlDtHr.SelectedItem.Text, ":", this.drpDlDtMin.SelectedItem.Text };
                    objMDAO.DeliveryDate = DateTime.ParseExact(string.Concat(strArrays1), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                objMDAO.ChallanTime = string.Concat(this.drpChDtHr.SelectedItem.ToString(), " : ", this.drpChDtMin.SelectedItem.ToString());
                objMDAO.VehicleTypeM = 7;
                if (this.drpVehicleType.SelectedValue == "-99")
                {
                    objMDAO.VehicleTypeD = Convert.ToInt16(this.drpVehicleType.SelectedValue);
                    objMDAO.Vehicle = "";
                }
                else
                {
                    objMDAO.VehicleTypeD = Convert.ToInt16(this.drpVehicleType.SelectedValue);
                    objMDAO.Vehicle = this.drpVehicleType.SelectedItem.ToString();
                }
                objMDAO.VehicleNo = BLL.Utility.ReplaceQuotes(this.txtVehicleNo.Text);
                objMDAO.UserIdInsert = 1;
                if (!this.drpParty.Enabled)
                {
                    objMDAO.IsNewParty = true;
                    objMDAO.TransPartyName = BLL.Utility.ReplaceQuotes(this.txtPartyName.Text);
                    objMDAO.PartAddress = BLL.Utility.ReplaceQuotes(this.txtAddress.Text);
                    if (this.txtPartyBIN.Text.Length <= 0 || !(this.txtPartyBIN.Text != ""))
                    {
                        objMDAO.PartyTIN = string.Concat("(NID)", BLL.Utility.ReplaceQuotes(this.txtNationalId.Text));
                    }
                    else
                    {
                        objMDAO.PartyTIN = BLL.Utility.ReplaceQuotes(this.txtPartyBIN.Text);
                    }
                }
                else
                {
                    objMDAO.PartyID = Convert.ToInt16(this.drpParty.SelectedValue);
                    objMDAO.TransPartyName = this.drpParty.SelectedItem.ToString();
                    objMDAO.PartAddress = BLL.Utility.ReplaceQuotes(this.txtAddress.Text);
                    if (this.txtPartyBIN.Text.Length <= 0 || !(this.txtPartyBIN.Text != ""))
                    {
                        objMDAO.PartyTIN = string.Concat("(NID)", BLL.Utility.ReplaceQuotes(this.txtNationalId.Text));
                    }
                    else
                    {
                        objMDAO.PartyTIN = BLL.Utility.ReplaceQuotes(this.txtPartyBIN.Text);
                    }
                    objMDAO.PartyNID = string.Concat("(NID)", BLL.Utility.ReplaceQuotes(this.txtNationalId.Text));
                    objMDAO.IsNewParty = false;
                }
                objMDAO.PartyNID = BLL.Utility.ReplaceQuotes(this.txtNationalId.Text);
                objMDAO.UltimateDestination = BLL.Utility.ReplaceQuotes(this.txtDestination.Text);
                objMDAO.Remarks = BLL.Utility.ReplaceQuotes(this.txtRemarks.Text);
                if (this.chkDiscard.Checked)
                {
                    objMDAO.Remarks = this.drpDiscardReason.SelectedItem.Text;
                }
                objMDAO.PaymentInfo = this.txt_transaction_id.Text;
                if (!this.chkInstallment.Checked)
                {
                    objMDAO.AggrementNo = (!string.IsNullOrEmpty(this.txtAggrementNo.Text) ? this.txtAggrementNo.Text.ToString() : string.Empty);
                }
                else
                {
                    objMDAO.AggrementNo = this.drpAgreement.SelectedItem.ToString();
                }
                (new AddItemBLL()).getPaymentMethod();
                if (this.chkCash.Checked)
                {
                    SaleMasterDAON saleMasterDAON = objMDAO;
                    saleMasterDAON.PaymentMethodP = string.Concat(saleMasterDAON.PaymentMethodP, "1,");
                }
                if (this.chkBkash.Checked)
                {
                    SaleMasterDAON saleMasterDAON1 = objMDAO;
                    saleMasterDAON1.PaymentMethodP = string.Concat(saleMasterDAON1.PaymentMethodP, "8,");
                }
                if (this.chkRoccket.Checked)
                {
                    SaleMasterDAON saleMasterDAON2 = objMDAO;
                    saleMasterDAON2.PaymentMethodP = string.Concat(saleMasterDAON2.PaymentMethodP, "12,");
                }
                if (this.chkCheque.Checked)
                {
                    SaleMasterDAON saleMasterDAON3 = objMDAO;
                    saleMasterDAON3.PaymentMethodP = string.Concat(saleMasterDAON3.PaymentMethodP, "2,");
                }
                if (this.chkTT.Checked)
                {
                    SaleMasterDAON saleMasterDAON4 = objMDAO;
                    saleMasterDAON4.PaymentMethodP = string.Concat(saleMasterDAON4.PaymentMethodP, "14,");
                }
                if (this.chkEFT.Checked)
                {
                    SaleMasterDAON saleMasterDAON5 = objMDAO;
                    saleMasterDAON5.PaymentMethodP = string.Concat(saleMasterDAON5.PaymentMethodP, "11,");
                }
                if (this.CheDebitCard.Checked)
                {
                    SaleMasterDAON saleMasterDAON6 = objMDAO;
                    saleMasterDAON6.PaymentMethodP = string.Concat(saleMasterDAON6.PaymentMethodP, "7,");
                }
                if (this.chkPayOrder.Checked)
                {
                    SaleMasterDAON saleMasterDAON7 = objMDAO;
                    saleMasterDAON7.PaymentMethodP = string.Concat(saleMasterDAON7.PaymentMethodP, "5,");
                }
                if (this.chkCredit.Checked)
                {
                    SaleMasterDAON saleMasterDAON8 = objMDAO;
                    saleMasterDAON8.PaymentMethodP = string.Concat(saleMasterDAON8.PaymentMethodP, "3,");
                }
                if (this.chkCash.Checked && this.txtCashAmount.Text.Trim() != "")
                {
                    SaleMasterDAON cashAmount = objMDAO;
                    cashAmount.CashAmount = cashAmount.CashAmount + Convert.ToDouble(this.txtCashAmount.Text.Trim());
                }
                if (this.chkBkash.Checked && this.txtbKashAmount.Text.Trim() != "")
                {
                    SaleMasterDAON cashAmount1 = objMDAO;
                    cashAmount1.CashAmount = cashAmount1.CashAmount + Convert.ToDouble(this.txtbKashAmount.Text.Trim());
                }
                if (this.chkRoccket.Checked && this.txtRocketAmount.Text.Trim() != "")
                {
                    SaleMasterDAON cashAmount2 = objMDAO;
                    cashAmount2.CashAmount = cashAmount2.CashAmount + Convert.ToDouble(this.txtRocketAmount.Text.Trim());
                }
                if (this.chkCheque.Checked && this.txtChequeAmount.Text.Trim() != "")
                {
                    SaleMasterDAON bankAmount = objMDAO;
                    bankAmount.BankAmount = bankAmount.BankAmount + Convert.ToDouble(this.txtChequeAmount.Text.Trim());
                }
                if (this.chkTT.Checked && this.txtTPTAmount.Text.Trim() != "")
                {
                    SaleMasterDAON bankAmount1 = objMDAO;
                    bankAmount1.BankAmount = bankAmount1.BankAmount + Convert.ToDouble(this.txtTPTAmount.Text.Trim());
                }
                if (this.chkEFT.Checked && this.txtEFTAmount.Text.Trim() != "")
                {
                    SaleMasterDAON bankAmount2 = objMDAO;
                    bankAmount2.BankAmount = bankAmount2.BankAmount + Convert.ToDouble(this.txtEFTAmount.Text.Trim());
                }
                if (this.CheDebitCard.Checked && this.txtDebitCartAmount.Text.Trim() != "")
                {
                    SaleMasterDAON bankAmount3 = objMDAO;
                    bankAmount3.BankAmount = bankAmount3.BankAmount + Convert.ToDouble(this.txtDebitCartAmount.Text.Trim());
                }
                if (this.chkPayOrder.Checked && this.txtPayOrderAmount.Text.Trim() != "")
                {
                    SaleMasterDAON bankAmount4 = objMDAO;
                    bankAmount4.BankAmount = bankAmount4.BankAmount + Convert.ToDouble(this.txtPayOrderAmount.Text.Trim());
                }
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                double num5 = 0;
                double num6 = 0;
                double num7 = 0;
                double num8 = 0;
                double num9 = 0;
                double num10 = 0;
                double num11 = 0;
                num2 = (this.txtCashAmount.Text == "" ? 0 : Convert.ToDouble(this.txtCashAmount.Text.Trim()));
                num3 = (this.txtChequeAmount.Text == "" ? 0 : Convert.ToDouble(this.txtChequeAmount.Text.Trim()));
                num4 = (this.txtbKashAmount.Text == "" ? 0 : Convert.ToDouble(this.txtbKashAmount.Text.Trim()));
                num5 = (this.txtEFTAmount.Text == "" ? 0 : Convert.ToDouble(this.txtEFTAmount.Text.Trim()));
                num6 = (this.txtOthersAmount.Text == "" ? 0 : Convert.ToDouble(this.txtOthersAmount.Text.Trim()));
                num7 = (this.txtPayOrderAmount.Text == "" ? 0 : Convert.ToDouble(this.txtPayOrderAmount.Text.Trim()));
                num8 = (this.txtRocketAmount.Text == "" ? 0 : Convert.ToDouble(this.txtRocketAmount.Text.Trim()));
                num9 = (this.txtTPTAmount.Text == "" ? 0 : Convert.ToDouble(this.txtTPTAmount.Text.Trim()));
                num10 = (this.txtDebitCartAmount.Text == "" ? 0 : Convert.ToDouble(this.txtDebitCartAmount.Text.Trim()));
                num11 = num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9 + num10;
                if (this.gvItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItem.Rows.Count; i++)
                    {
                        num += Convert.ToDouble(this.gvItem.Rows[i].Cells[35].Text.Trim());
                    }
                    if (num11 < num)
                    {
                        num1 = num - num11;
                    }
                }
                SaleMasterDAON creditAmount = objMDAO;
                creditAmount.CreditAmount = creditAmount.CreditAmount + num1;
                if (objMDAO.PaymentMethodP == null)
                {
                    objMDAO.PaymentMethod = "3";
                }
                else
                {
                    string paymentMethodP = objMDAO.PaymentMethodP;
                    char[] chrArray = new char[] { ',' };
                    objMDAO.PaymentMethod = paymentMethodP.TrimEnd(chrArray);
                }
                double cashAmount3 = 0;
                double bankAmount5 = 0;
                double num12 = 0;
                cashAmount3 = objMDAO.CashAmount;
                bankAmount5 = objMDAO.BankAmount;
                num12 = (this.txtTotalSalePrice.Text == "" ? 0 : Convert.ToDouble(this.txtTotalSalePrice.Text.Trim()));
                if (num12 != cashAmount3 + bankAmount5)
                {
                    objMDAO.IsPaymentFinished = false;
                }
                else
                {
                    objMDAO.IsPaymentFinished = true;
                }
                objMDAO.Discountm = (!string.IsNullOrEmpty(this.txtdiscountm.Text) ? Convert.ToDecimal(this.txtdiscountm.Text.ToString()) : new decimal(0));
                objMDAO.Discount_pctm = (!string.IsNullOrEmpty(this.txtdiscountPctm.Text) ? Convert.ToDecimal(this.txtdiscountPctm.Text.ToString()) : new decimal(0));
                objMDAO.SalesProductType = Convert.ToChar(this.drpTransaction2.SelectedValue);
                double cashAmount4 = 0;
                objMDAO.TotalBillAmount = 0;
                objMDAO.TotalVat = 0;
                objMDAO.TotalVds = 0;
                objMDAO.TotalAit = 0;
                objMDAO.PaidVds = 0;
                objMDAO.PaidVat = 0;
                objMDAO.PaidAit = 0;
                cashAmount4 = objMDAO.CashAmount + objMDAO.BankAmount;
                objMDAO.TotalBillAmount = Convert.ToDouble(this.lblSaleamnt.Text);
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["SALE_DETAIL_LIST"];
                for (int j = 0; j < arrayLists.Count; j++)
                {
                    try
                    {
                        SaleDetailDAON saleDetailDAON = (SaleDetailDAON)arrayLists[j];
                        if (!saleDetailDAON.VDS)
                        {
                            SaleMasterDAON totalVat = objMDAO;
                            totalVat.TotalVat = totalVat.TotalVat + Convert.ToDouble(saleDetailDAON.VAT);
                        }
                        else
                        {
                            SaleMasterDAON totalVds = objMDAO;
                            totalVds.TotalVds = totalVds.TotalVds + Convert.ToDouble(saleDetailDAON.VAT);
                        }
                        SaleMasterDAON totalAit = objMDAO;
                        totalAit.TotalAit = totalAit.TotalAit + Convert.ToDouble(saleDetailDAON.AIT);
                    }
                    catch (Exception exception)
                    {
                        ReallySimpleLog.WriteLog(exception);
                        arrayLists = null;
                    }
                }
                objMDAO.PaidVds = objMDAO.TotalVds / objMDAO.TotalBillAmount * cashAmount4;
                objMDAO.PaidVat = objMDAO.TotalVat / objMDAO.TotalBillAmount * cashAmount4;
                objMDAO.PaidAit = objMDAO.TotalAit / objMDAO.TotalBillAmount * cashAmount4;
                objMDAO.priceWithoutVDS = Convert.ToDouble(this.txtTotalSalePrice.Text) - Convert.ToDouble(this.txtTotalVAT.Text) * (objMDAO.CashAmount + objMDAO.BankAmount + objMDAO.CreditAmount) / Convert.ToDouble(this.txtTotalSalePrice.Text);
                objMDAO.proportionVAT = Convert.ToDouble(this.txtTotalVAT.Text) * (objMDAO.CashAmount + objMDAO.BankAmount) / Convert.ToDouble(this.txtTotalSalePrice.Text);
                objMDAO.proportionAIT = Convert.ToDouble(this.txtTotalAIT.Text) * (objMDAO.CashAmount + objMDAO.BankAmount) / Convert.ToDouble(this.txtTotalSalePrice.Text);
                item.Add(objMDAO);
                base.Cache["SALE_MASTER_DETAIL"] = item;
            }
            catch (Exception exception1)
            {
                BLL.Utility.InsertErrorTrack(exception1.Message, "SaleChallan_11s.aspx", "GetInserMasterValues");
                objMDAO = null;
            }
            return objMDAO;
        }

        private void GetInserMasterValuesforExcel()
        {
            try
            {
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["SALES_EXCEL"];
                ArrayList item = (ArrayList)this.Session["SALE_Master_LIST"] ?? new ArrayList();
                foreach (SaleDetailDAON arrayList in arrayLists)
                {
                    SaleMasterDAON saleMasterDAON = new SaleMasterDAON()
                    {
                        Org_branch_reg_id = Convert.ToInt32(this.drpBranchName.SelectedValue),
                        ChallanType = 'S',
                        ChallanNo = arrayList.Challan_No,
                        OrgName = this.lt_companyName.Text.ToString(),
                        OrgAddress = this.It_companyAddress.Text.ToString(),
                        OrgBin = this.lblOrgBIN.Text.ToString()
                    };
                    if (this.drpTransaction.SelectedIndex == 0)
                    {
                        saleMasterDAON.TransactionType = 'L';
                    }
                    else if (this.drpTransaction.SelectedIndex == 1)
                    {
                        saleMasterDAON.TransactionType = 'E';
                        saleMasterDAON.BankID = Convert.ToInt16(this.drpBank.SelectedValue);
                        saleMasterDAON.BranchID = Convert.ToInt16(this.drpBranch.SelectedValue);
                    }
                    if (this.chkDiscard.Checked)
                    {
                        saleMasterDAON.TransactionType = 'D';
                        saleMasterDAON.ChallanPageDiscardReason_m = 12;
                        saleMasterDAON.ChallanPageDiscardReason_d = Convert.ToInt32(this.drpDiscardReason.SelectedValue);
                    }
                    if (this.drpSaleType.SelectedValue == "S")
                    {
                        saleMasterDAON.SaleType = 'S';
                    }
                    if (this.drpSaleType.SelectedValue == "W")
                    {
                        saleMasterDAON.SaleType = 'W';
                    }
                    else if (this.drpSaleType.SelectedValue == "R")
                    {
                        saleMasterDAON.SaleType = 'R';
                    }
                    else if (this.drpSaleType.SelectedValue == "P")
                    {
                        saleMasterDAON.SaleType = 'P';
                    }
                    else if (this.drpSaleType.SelectedValue == "T")
                    {
                        saleMasterDAON.SaleType = 'T';
                    }
                    saleMasterDAON.ChallanDate = DateTime.ParseExact(arrayList.Challan_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    saleMasterDAON.VehicleTypeM = 7;
                    saleMasterDAON.VehicleTypeD = Convert.ToInt16(this.drpVehicleType.SelectedValue);
                    saleMasterDAON.VehicleNo = BLL.Utility.ReplaceQuotes(this.txtVehicleNo.Text);
                    saleMasterDAON.UserIdInsert = 1;
                    DataTable party = this.objBLL.GetParty(arrayList.Party_Name.ToUpper());
                    if (party.Rows.Count > 0)
                    {
                        saleMasterDAON.PartyID = Convert.ToInt16(party.Rows[0]["party_id"]);
                        saleMasterDAON.IsNewParty = false;
                    }
                    saleMasterDAON.UltimateDestination = BLL.Utility.ReplaceQuotes(this.txtDestination.Text);
                    saleMasterDAON.Remarks = BLL.Utility.ReplaceQuotes(this.txtRemarks.Text);
                    if (this.chkDiscard.Checked)
                    {
                        saleMasterDAON.Remarks = this.drpDiscardReason.SelectedItem.Text;
                    }
                    saleMasterDAON.PaymentInfo = this.txt_transaction_id.Text;
                    saleMasterDAON.CreditAmount = arrayList.CreditAmount;
                    saleMasterDAON.CashAmount = arrayList.CashAmount;
                    saleMasterDAON.IsPaymentFinished = arrayList.IsPaymentFinished;
                    saleMasterDAON.AggrementNo = (!string.IsNullOrEmpty(this.txtAggrementNo.Text) ? this.txtAggrementNo.Text.ToString() : string.Empty);
                    saleMasterDAON.Discountm = (!string.IsNullOrEmpty(this.txtdiscountm.Text) ? Convert.ToDecimal(this.txtdiscountm.Text.ToString()) : new decimal(0));
                    saleMasterDAON.Discount_pctm = (!string.IsNullOrEmpty(this.txtdiscountPctm.Text) ? Convert.ToDecimal(this.txtdiscountPctm.Text.ToString()) : new decimal(0));
                    saleMasterDAON.SalesProductType = Convert.ToChar(this.drpTransaction2.SelectedValue);
                    item.Add(saleMasterDAON);
                }
                this.Session["SALE_Master_LIST"] = item;
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetInserMasterValues");
            }
        }

        private ArrayList GetInsertDeatilValues()
        {
            ArrayList arrayLists;
            ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LIST"];
            ArrayList arrayLists1 = new ArrayList();
            SaleBLL saleBLL = new SaleBLL();
            DateTime standardDateFromDdMMyyyy = BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtChallanDate.Text.Trim());
            int num = 0;
            int num1 = 0;
            Label2:
            while (num1 < item.Count)
            {
                try
                {
                    SaleDetailDAON rowNo = (SaleDetailDAON)item[num1];
                    DataSet dataSet = new DataSet();
                    if (this.btnSave.Text != SaleChallan_11s.enmBtnText.Save.ToString())
                    {
                        rowNo.ChallanID = Convert.ToInt32(this.ViewState["Challan_id"]);
                    }
                    else
                    {
                        rowNo.ChallanID = 0;
                    }
                    decimal quantity = rowNo.Quantity;
                    if (rowNo.ItemType == "S")
                    {
                        rowNo.DetailID = -99;
                        rowNo.LotNo = -99;
                        rowNo.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"].ToString());
                        rowNo.SaleRowNo = rowNo.RowNo;
                        arrayLists1.Add(rowNo);
                    }
                    else if (rowNo.RealProperty != 'W')
                    {
                        dataSet = saleBLL.GetLotInfoByItemByIDForSale(rowNo, standardDateFromDdMMyyyy);
                        SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                        if (rowNo.instStatus != "I")
                        {
                            saleDetailDAON.installmentStatus = false;
                        }
                        else
                        {
                            saleDetailDAON.installmentStatus = true;
                        }
                        if (this.scheduleId.Text != "")
                        {
                            saleDetailDAON.scheduleId = Convert.ToInt32(this.scheduleId.Text);
                        }
                        saleDetailDAON.PropStk = rowNo.PropStk;
                        saleDetailDAON.ItemID = rowNo.ItemID;
                        saleDetailDAON.RealProperty = rowNo.RealProperty;
                        saleDetailDAON.UnitPriceBDT = rowNo.UnitPriceBDT;
                        saleDetailDAON.NBRPrice = rowNo.NBRPrice;
                        saleDetailDAON.PriceId = rowNo.PriceId;
                        saleDetailDAON.HealthCharge = rowNo.HealthCharge;
                        saleDetailDAON.SD = rowNo.SD;
                        saleDetailDAON.VAT = rowNo.VAT;
                        saleDetailDAON.AIT = rowNo.AIT;
                        saleDetailDAON.VATRate = rowNo.VATRate;
                        saleDetailDAON.SDRate = rowNo.SDRate;
                        saleDetailDAON.UnitID = rowNo.UnitID;
                        saleDetailDAON.IsSrcTAXDeduct = rowNo.IsSrcTAXDeduct;
                        saleDetailDAON.IsFixed = rowNo.IsFixed;
                        saleDetailDAON.IsTruncated = rowNo.IsTruncated;
                        saleDetailDAON.IsMrp = rowNo.IsMrp;
                        saleDetailDAON.IsExempted = rowNo.IsExempted;
                        saleDetailDAON.PropertyID1 = rowNo.PropertyID1;
                        saleDetailDAON.PropertyID2 = rowNo.PropertyID2;
                        saleDetailDAON.PropertyID3 = rowNo.PropertyID3;
                        saleDetailDAON.PropertyID4 = rowNo.PropertyID4;
                        saleDetailDAON.PropertyID5 = rowNo.PropertyID5;
                        saleDetailDAON.Discount_pct = rowNo.Discount_pct;
                        saleDetailDAON.Discount = rowNo.Discount;
                        saleDetailDAON.Net_bill = rowNo.Net_bill;
                        saleDetailDAON.IsZeroRate = rowNo.IsZeroRate;
                        saleDetailDAON.BatchNo = rowNo.BatchNo;
                        if (this.drpAgreement.SelectedValue == "-99")
                        {
                            saleDetailDAON.RemarksDetail = BLL.Utility.ReplaceQuotes(rowNo.RemarksDetail);
                        }
                        else
                        {
                            saleDetailDAON.RemarksDetail = string.Concat(this.drpAgreement.SelectedItem.ToString(), ",", BLL.Utility.ReplaceQuotes(rowNo.RemarksDetail));
                        }
                        saleDetailDAON.isInexplicitExport = rowNo.isInexplicitExport;
                        saleDetailDAON.SaleUnitID = rowNo.SaleUnitID;
                        saleDetailDAON.SaleQuantity = rowNo.SaleQuantity;
                        saleDetailDAON.TypeP = rowNo.TypeP;
                        saleDetailDAON.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"].ToString());
                        saleDetailDAON.SaleRowNo = rowNo.RowNo;
                        num++;
                        saleDetailDAON.RowNo = num;
                        saleDetailDAON.itemSerials = rowNo.itemSerials;
                        if (this.installmentStatus.Text == "I")
                        {
                            saleDetailDAON.Quantity = rowNo.Quantity;
                            arrayLists1.Add(saleDetailDAON);
                        }
                        else
                        {
                            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            {
                                try
                                {
                                    decimal quantity1 = Convert.ToDecimal(dataSet.Tables[0].Rows[i]["AVAIL_QTY"]);
                                    if (this.btnSave.Text == SaleChallan_11s.enmBtnText.Update.ToString())
                                    {
                                        quantity1 += saleDetailDAON.Quantity;
                                    }
                                    saleDetailDAON.DetailID = Convert.ToInt32(dataSet.Tables[0].Rows[i]["DETAIL_ID"]);
                                    saleDetailDAON.LotNo = Convert.ToInt32(dataSet.Tables[0].Rows[i]["LOT_NO"]);
                                    if (quantity < quantity1)
                                    {
                                        SaleDetailDAON saleDetailDAON1 = saleDetailDAON;
                                        saleDetailDAON1.Quantity = saleDetailDAON1.Quantity + quantity;
                                        break;
                                    }
                                    else if (quantity == quantity1)
                                    {
                                        SaleDetailDAON quantity2 = saleDetailDAON;
                                        quantity2.Quantity = quantity2.Quantity + quantity;
                                        break;
                                    }
                                    else if (quantity > quantity1)
                                    {
                                        SaleDetailDAON saleDetailDAON2 = saleDetailDAON;
                                        saleDetailDAON2.Quantity = saleDetailDAON2.Quantity + quantity1;
                                        quantity -= quantity1;
                                    }
                                    else if (quantity > quantity1)
                                    {
                                    }
                                }
                                catch (Exception exception)
                                {
                                    ReallySimpleLog.WriteLog(exception);
                                    arrayLists1 = null;
                                }
                            }
                            if (saleDetailDAON.Quantity == new decimal(0))
                            {
                                arrayLists = arrayLists1;
                                return arrayLists;
                            }
                            else
                            {
                                arrayLists1.Add(saleDetailDAON);
                            }
                        }
                    }
                    else if (rowNo.RealProperty != 'W' || Convert.ToInt32(this.lblAvailStock.Text) <= 0)
                    {
                        SaleDetailDAON propStk = new SaleDetailDAON();
                        if (rowNo.instStatus != "I")
                        {
                            propStk.installmentStatus = false;
                        }
                        else
                        {
                            propStk.installmentStatus = true;
                        }
                        if (this.scheduleId.Text != "")
                        {
                            propStk.scheduleId = Convert.ToInt32(this.scheduleId.Text);
                        }
                        propStk.PropStk = rowNo.PropStk;
                        propStk.ItemID = rowNo.ItemID;
                        propStk.RealProperty = rowNo.RealProperty;
                        propStk.UnitPriceBDT = rowNo.UnitPriceBDT;
                        propStk.NBRPrice = rowNo.NBRPrice;
                        propStk.PriceId = rowNo.PriceId;
                        propStk.HealthCharge = rowNo.HealthCharge;
                        propStk.SD = rowNo.SD;
                        propStk.VAT = rowNo.VAT;
                        propStk.AIT = rowNo.AIT;
                        propStk.UnitID = rowNo.UnitID;
                        propStk.IsSrcTAXDeduct = rowNo.IsSrcTAXDeduct;
                        propStk.IsFixed = rowNo.IsFixed;
                        propStk.IsExempted = rowNo.IsExempted;
                        propStk.Quantity = rowNo.Quantity;
                        propStk.IsZeroRate = rowNo.IsZeroRate;
                        if (this.drpAgreement.SelectedValue == "-99")
                        {
                            propStk.RemarksDetail = BLL.Utility.ReplaceQuotes(rowNo.RemarksDetail);
                        }
                        else
                        {
                            propStk.RemarksDetail = string.Concat(this.drpAgreement.SelectedItem.ToString(), ",", BLL.Utility.ReplaceQuotes(rowNo.RemarksDetail));
                        }
                        propStk.isInexplicitExport = rowNo.isInexplicitExport;
                        propStk.TypeP = rowNo.TypeP;
                        propStk.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"].ToString());
                        propStk.SaleUnitID = rowNo.SaleUnitID;
                        propStk.SaleQuantity = rowNo.SaleQuantity;
                        propStk.SaleRowNo = rowNo.RowNo;
                        num++;
                        propStk.RowNo = num;
                        arrayLists1.Add(propStk);
                    }
                    else
                    {
                        SaleDetailDAON itemID = new SaleDetailDAON();
                        dataSet = saleBLL.GetLotInfoByItemByIDForSale(rowNo, standardDateFromDdMMyyyy);
                        itemID.PropStk = rowNo.PropStk;
                        itemID.ItemID = rowNo.ItemID;
                        itemID.RealProperty = rowNo.RealProperty;
                        itemID.UnitPriceBDT = rowNo.UnitPriceBDT;
                        itemID.NBRPrice = rowNo.NBRPrice;
                        itemID.PriceId = rowNo.PriceId;
                        itemID.HealthCharge = rowNo.HealthCharge;
                        itemID.SD = rowNo.SD;
                        itemID.VAT = rowNo.VAT;
                        itemID.AIT = rowNo.AIT;
                        itemID.UnitID = rowNo.UnitID;
                        itemID.IsSrcTAXDeduct = rowNo.IsSrcTAXDeduct;
                        itemID.IsFixed = rowNo.IsFixed;
                        itemID.IsExempted = rowNo.IsExempted;
                        itemID.SaleUnitID = rowNo.SaleUnitID;
                        itemID.SaleQuantity = rowNo.SaleQuantity;
                        itemID.IsZeroRate = rowNo.IsZeroRate;
                        itemID.isInexplicitExport = rowNo.isInexplicitExport;
                        itemID.TypeP = rowNo.TypeP;
                        itemID.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"].ToString());
                        itemID.SaleRowNo = rowNo.RowNo;
                        num++;
                        itemID.RowNo = num;
                        if (this.drpAgreement.SelectedValue == "-99")
                        {
                            itemID.RemarksDetail = BLL.Utility.ReplaceQuotes(rowNo.RemarksDetail);
                        }
                        else
                        {
                            itemID.RemarksDetail = string.Concat(this.drpAgreement.SelectedItem.ToString(), ",", BLL.Utility.ReplaceQuotes(rowNo.RemarksDetail));
                        }
                        if (this.installmentStatus.Text == "I")
                        {
                            itemID.Quantity = rowNo.Quantity;
                            arrayLists1.Add(itemID);
                        }
                        else
                        {
                            for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                            {
                                try
                                {
                                    decimal num2 = Convert.ToDecimal(dataSet.Tables[0].Rows[j]["AVAIL_QTY"]);
                                    if (this.btnSave.Text == SaleChallan_11s.enmBtnText.Update.ToString())
                                    {
                                        num2 += itemID.Quantity;
                                    }
                                    itemID.DetailID = Convert.ToInt32(dataSet.Tables[0].Rows[j]["DETAIL_ID"]);
                                    itemID.LotNo = Convert.ToInt32(dataSet.Tables[0].Rows[j]["LOT_NO"]);
                                    if (quantity < num2)
                                    {
                                        SaleDetailDAON quantity3 = itemID;
                                        quantity3.Quantity = quantity3.Quantity + quantity;
                                        break;
                                    }
                                    else if (quantity == num2)
                                    {
                                        SaleDetailDAON saleDetailDAON3 = itemID;
                                        saleDetailDAON3.Quantity = saleDetailDAON3.Quantity + quantity;
                                        break;
                                    }
                                    else if (quantity > num2)
                                    {
                                        SaleDetailDAON quantity4 = itemID;
                                        quantity4.Quantity = quantity4.Quantity + num2;
                                        quantity -= num2;
                                    }
                                    else if (quantity > num2)
                                    {
                                    }
                                }
                                catch (Exception exception1)
                                {
                                    ReallySimpleLog.WriteLog(exception1);
                                    arrayLists1 = null;
                                }
                            }
                            if (itemID.Quantity == new decimal(0))
                            {
                                arrayLists = arrayLists1;
                                return arrayLists;
                            }
                            else
                            {
                                arrayLists1.Add(itemID);
                            }
                        }
                    }
                    goto Label0;
                }
                catch (Exception exception2)
                {
                    ReallySimpleLog.WriteLog(exception2);
                    arrayLists1 = null;
                    goto Label0;
                }
                return arrayLists;
            }
            return arrayLists1;
            Label0:
            num1++;
            goto Label2;
        }

        private ArrayList GetInsertGiftDetails()
        {
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            SaleBLL saleBLL = new SaleBLL();
            if (this.Session["GIFT_SALE_DETAIL_LIST"] != null)
            {
                arrayLists = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
                DateTime standardDateFromDdMMyyyy = BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtChallanDate.Text.Trim());
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    try
                    {
                        SaleGiftDetailDAON item = (SaleGiftDetailDAON)arrayLists[i];
                        DataSet dataSet = new DataSet();
                        if (this.btnSave.Text != SaleChallan_11s.enmBtnText.Save.ToString())
                        {
                            item.ChallanID = Convert.ToInt32(this.ViewState["Challan_id"]);
                        }
                        else
                        {
                            item.ChallanID = 0;
                        }
                        item.ItemPriceBDT = new decimal(0);
                        decimal giftQuantity = item.GiftQuantity;
                        decimal num = new decimal(0);
                        decimal num1 = new decimal(0);
                        decimal num2 = new decimal(0);
                        decimal num3 = new decimal(0);
                        decimal num4 = new decimal(0);
                        decimal num5 = new decimal(0);
                        DataTable priceInfoOfGiftOwnProduction = this.objBLL.GetPriceInfoOfGiftOwnProduction((long)item.ItemID);
                        if (priceInfoOfGiftOwnProduction != null && priceInfoOfGiftOwnProduction.Rows.Count > 0)
                        {
                            num5 = Convert.ToDecimal(priceInfoOfGiftOwnProduction.Rows[0]["unit_price"]);
                            num = giftQuantity * num5;
                            num3 = Convert.ToDecimal(priceInfoOfGiftOwnProduction.Rows[0]["SD_RATE"]);
                            num1 = Convert.ToDecimal(priceInfoOfGiftOwnProduction.Rows[0]["VAT_RATE"]);
                            num4 = num * (num3 / new decimal(100));
                            num2 = (num + num4) * (num1 / new decimal(100));
                            item.DiscountSDRate = num3;
                            item.DiscountSD = num4;
                            item.DiscountVatRate = num1;
                            item.DiscountVat = num2;
                            item.ItemPriceBDT = num;
                        }
                        item.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"].ToString());
                        item.OrganizationID = Convert.ToInt16(HttpContext.Current.Session["ORGANIZATION_ID"]);
                        item.OrgBranchID = Convert.ToInt32(this.drpBranchName.SelectedValue);
                        if (item.ItemPriceBDT == new decimal(0))
                        {
                            dataSet = saleBLL.GetLotInfoByItemByIDForGift(item, standardDateFromDdMMyyyy);
                            for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                            {
                                try
                                {
                                    decimal num6 = Convert.ToDecimal(dataSet.Tables[0].Rows[j]["AVAIL_QTY"]);
                                    if (giftQuantity <= num6)
                                    {
                                        SaleGiftDetailDAON itemPriceBDT = item;
                                        itemPriceBDT.ItemPriceBDT = itemPriceBDT.ItemPriceBDT + (giftQuantity * Convert.ToDecimal(dataSet.Tables[0].Rows[j]["unit_price"]));
                                        break;
                                    }
                                    else if (giftQuantity > num6 && num6 > new decimal(0))
                                    {
                                        SaleGiftDetailDAON saleGiftDetailDAON = item;
                                        saleGiftDetailDAON.ItemPriceBDT = saleGiftDetailDAON.ItemPriceBDT + (num6 * Convert.ToDecimal(dataSet.Tables[0].Rows[j]["unit_price"]));
                                        giftQuantity -= num6;
                                    }
                                    else if (giftQuantity > num6)
                                    {
                                    }
                                }
                                catch (Exception exception)
                                {
                                    ReallySimpleLog.WriteLog(exception);
                                    arrayLists1 = null;
                                }
                            }
                        }
                        arrayLists1.Add(item);
                    }
                    catch (Exception exception1)
                    {
                        ReallySimpleLog.WriteLog(exception1);
                        arrayLists1 = null;
                    }
                }
            }
            return arrayLists;
        }

        private void GetItemProperty()
        {
            SaleBLL saleBLL = new SaleBLL();
            int num = 0;
            string str = "";
            if (this.drpItem.SelectedValue != "-99")
            {
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                num = Convert.ToInt16(strArrays[0]);
                if (this.lblProductType.Text == "C")
                {
                    this.objItemBLL.getItemRequiredProperty(num);
                    DataTable propertyByItemId = saleBLL.getPropertyByItemId("property_id1", num);
                    DataTable dataTable = saleBLL.getPropertyByItemId("property_id2", num);
                    DataTable propertyByItemId1 = saleBLL.getPropertyByItemId("property_id3", num);
                    DataTable dataTable1 = saleBLL.getPropertyByItemId("property_id4", num);
                    DataTable propertyByItemId2 = saleBLL.getPropertyByItemId("property_id5", num);
                    if (propertyByItemId == null)
                    {
                        this.lblProp11.Visible = false;
                        this.drpProp11.Visible = false;
                    }
                    else if (propertyByItemId.Rows.Count <= 0)
                    {
                        this.lblProp11.Visible = false;
                        this.drpProp11.Visible = false;
                    }
                    else
                    {
                        this.lblProp11.Visible = true;
                        this.drpProp11.Visible = true;
                        this.drpProp11.DataSource = propertyByItemId;
                        this.drpProp11.DataTextField = propertyByItemId.Columns["property_name"].ToString();
                        this.drpProp11.DataValueField = propertyByItemId.Columns["property_id"].ToString();
                        this.drpProp11.DataBind();
                        ListItem listItem = new ListItem("---SELECT---", "-99");
                        this.drpProp11.Items.Insert(0, listItem);
                        DataTable propertyName = saleBLL.GetPropertyName(Convert.ToInt32(propertyByItemId.Rows[0]["property_id"].ToString()));
                        this.lblProp11.Text = propertyName.Rows[0]["code_name"].ToString();
                    }
                    if (dataTable == null)
                    {
                        this.lblProp22.Visible = false;
                        this.drpProp22.Visible = false;
                    }
                    else if (dataTable.Rows.Count <= 0)
                    {
                        this.lblProp22.Visible = false;
                        this.drpProp22.Visible = false;
                    }
                    else
                    {
                        this.lblProp22.Visible = true;
                        this.drpProp22.Visible = true;
                        this.drpProp22.DataSource = dataTable;
                        this.drpProp22.DataTextField = dataTable.Columns["property_name"].ToString();
                        this.drpProp22.DataValueField = dataTable.Columns["property_id"].ToString();
                        this.drpProp22.DataBind();
                        ListItem listItem1 = new ListItem("---SELECT---", "-99");
                        this.drpProp22.Items.Insert(0, listItem1);
                        DataTable propertyName1 = saleBLL.GetPropertyName(Convert.ToInt32(dataTable.Rows[0]["property_id"].ToString()));
                        this.lblProp22.Text = propertyName1.Rows[0]["code_name"].ToString();
                    }
                    if (propertyByItemId1 == null)
                    {
                        this.lblProp33.Visible = false;
                        this.drpProp33.Visible = false;
                    }
                    else if (propertyByItemId1.Rows.Count <= 0)
                    {
                        this.lblProp33.Visible = false;
                        this.drpProp33.Visible = false;
                    }
                    else
                    {
                        this.lblProp33.Visible = true;
                        this.drpProp33.Visible = true;
                        this.drpProp33.DataSource = propertyByItemId1;
                        this.drpProp33.DataTextField = propertyByItemId1.Columns["property_name"].ToString();
                        this.drpProp33.DataValueField = propertyByItemId1.Columns["property_id"].ToString();
                        this.drpProp33.DataBind();
                        ListItem listItem2 = new ListItem("---SELECT---", "-99");
                        this.drpProp33.Items.Insert(0, listItem2);
                        DataTable propertyName2 = saleBLL.GetPropertyName(Convert.ToInt32(propertyByItemId1.Rows[0]["property_id"].ToString()));
                        this.lblProp33.Text = propertyName2.Rows[0]["code_name"].ToString();
                    }
                    if (dataTable1 == null)
                    {
                        this.lblProp44.Visible = false;
                        this.drpProp44.Visible = false;
                    }
                    else if (dataTable1.Rows.Count <= 0)
                    {
                        this.lblProp44.Visible = false;
                        this.drpProp44.Visible = false;
                    }
                    else
                    {
                        this.lblProp44.Visible = true;
                        this.drpProp44.Visible = true;
                        this.drpProp44.DataSource = dataTable1;
                        this.drpProp44.DataTextField = dataTable1.Columns["property_name"].ToString();
                        this.drpProp44.DataValueField = dataTable1.Columns["property_id"].ToString();
                        this.drpProp44.DataBind();
                        ListItem listItem3 = new ListItem("---SELECT---", "-99");
                        this.drpProp44.Items.Insert(0, listItem3);
                        DataTable dataTable2 = saleBLL.GetPropertyName(Convert.ToInt32(dataTable1.Rows[0]["property_id"].ToString()));
                        this.lblProp44.Text = dataTable2.Rows[0]["code_name"].ToString();
                    }
                    if (propertyByItemId2 == null)
                    {
                        this.lblProp55.Visible = false;
                        this.drpProp55.Visible = false;
                        return;
                    }
                    if (propertyByItemId2.Rows.Count <= 0)
                    {
                        this.lblProp55.Visible = false;
                        this.drpProp55.Visible = false;
                        return;
                    }
                    this.lblProp55.Visible = true;
                    this.drpProp55.Visible = true;
                    this.drpProp55.DataSource = propertyByItemId2;
                    this.drpProp55.DataTextField = propertyByItemId2.Columns["property_name"].ToString();
                    this.drpProp55.DataValueField = propertyByItemId2.Columns["property_id"].ToString();
                    this.drpProp55.DataBind();
                    ListItem listItem4 = new ListItem("---SELECT---", "-99");
                    this.drpProp55.Items.Insert(0, listItem4);
                    DataTable propertyName3 = saleBLL.GetPropertyName(Convert.ToInt32(propertyByItemId2.Rows[0]["property_id"].ToString()));
                    this.lblProp55.Text = propertyName3.Rows[0]["code_name"].ToString();
                    return;
                }
                DataTable propertyByItemId3 = saleBLL.getPropertyByItemId("property_id1", num);
                DataTable dataTable3 = saleBLL.getPropertyByItemId("property_id2", num);
                DataTable propertyByItemId4 = saleBLL.getPropertyByItemId("property_id3", num);
                DataTable dataTable4 = saleBLL.getPropertyByItemId("property_id4", num);
                DataTable propertyByItemId5 = saleBLL.getPropertyByItemId("property_id5", num);
                if (propertyByItemId3 == null)
                {
                    this.lblProp11.Visible = false;
                    this.drpProp11.Visible = false;
                }
                else if (propertyByItemId3.Rows.Count <= 0)
                {
                    this.lblProp11.Visible = false;
                    this.drpProp11.Visible = false;
                }
                else
                {
                    this.lblProp11.Visible = true;
                    this.drpProp11.Visible = true;
                    this.drpProp11.DataSource = propertyByItemId3;
                    this.drpProp11.DataTextField = propertyByItemId3.Columns["property_name"].ToString();
                    this.drpProp11.DataValueField = propertyByItemId3.Columns["property_id"].ToString();
                    this.drpProp11.DataBind();
                    ListItem listItem5 = new ListItem("---SELECT---", "-99");
                    this.drpProp11.Items.Insert(0, listItem5);
                    DataTable propertyName4 = saleBLL.GetPropertyName(Convert.ToInt32(propertyByItemId3.Rows[0]["property_id"].ToString()));
                    this.lblProp11.Text = propertyName4.Rows[0]["code_name"].ToString();
                }
                if (dataTable3 == null)
                {
                    this.lblProp22.Visible = false;
                    this.drpProp22.Visible = false;
                }
                else if (dataTable3.Rows.Count <= 0)
                {
                    this.lblProp22.Visible = false;
                    this.drpProp22.Visible = false;
                }
                else
                {
                    this.lblProp22.Visible = true;
                    this.drpProp22.Visible = true;
                    this.drpProp22.DataSource = dataTable3;
                    this.drpProp22.DataTextField = dataTable3.Columns["property_name"].ToString();
                    this.drpProp22.DataValueField = dataTable3.Columns["property_id"].ToString();
                    this.drpProp22.DataBind();
                    ListItem listItem6 = new ListItem("---SELECT---", "-99");
                    this.drpProp22.Items.Insert(0, listItem6);
                    DataTable propertyName5 = saleBLL.GetPropertyName(Convert.ToInt32(dataTable3.Rows[0]["property_id"].ToString()));
                    this.lblProp22.Text = propertyName5.Rows[0]["code_name"].ToString();
                }
                if (propertyByItemId4 == null)
                {
                    this.lblProp33.Visible = false;
                    this.drpProp33.Visible = false;
                }
                else if (propertyByItemId4.Rows.Count <= 0)
                {
                    this.lblProp33.Visible = false;
                    this.drpProp33.Visible = false;
                }
                else
                {
                    this.lblProp33.Visible = true;
                    this.drpProp33.Visible = true;
                    this.drpProp33.DataSource = propertyByItemId4;
                    this.drpProp33.DataTextField = propertyByItemId4.Columns["property_name"].ToString();
                    this.drpProp33.DataValueField = propertyByItemId4.Columns["property_id"].ToString();
                    this.drpProp33.DataBind();
                    ListItem listItem7 = new ListItem("---SELECT---", "-99");
                    this.drpProp33.Items.Insert(0, listItem7);
                    DataTable dataTable5 = saleBLL.GetPropertyName(Convert.ToInt32(propertyByItemId4.Rows[0]["property_id"].ToString()));
                    this.lblProp33.Text = dataTable5.Rows[0]["code_name"].ToString();
                }
                if (dataTable4 == null)
                {
                    this.lblProp44.Visible = false;
                    this.drpProp44.Visible = false;
                }
                else if (dataTable4.Rows.Count > 0)
                {
                    this.lblProp44.Visible = true;
                    this.drpProp44.Visible = true;
                    this.drpProp44.DataSource = dataTable4;
                    this.drpProp44.DataTextField = dataTable4.Columns["property_name"].ToString();
                    this.drpProp44.DataValueField = dataTable4.Columns["property_id"].ToString();
                    this.drpProp44.DataBind();
                    ListItem listItem8 = new ListItem("---SELECT---", "-99");
                    this.drpProp44.Items.Insert(0, listItem8);
                    DataTable propertyName6 = saleBLL.GetPropertyName(Convert.ToInt32(dataTable4.Rows[0]["property_id"].ToString()));
                    this.lblProp44.Text = propertyName6.Rows[0]["code_name"].ToString();
                }
                if (propertyByItemId5 != null)
                {
                    if (propertyByItemId5.Rows.Count <= 0)
                    {
                        this.lblProp55.Visible = false;
                        this.drpProp55.Visible = false;
                        return;
                    }
                    this.lblProp55.Visible = true;
                    this.drpProp55.Visible = true;
                    this.drpProp55.DataSource = propertyByItemId5;
                    this.drpProp55.DataTextField = propertyByItemId5.Columns["property_name"].ToString();
                    this.drpProp55.DataValueField = propertyByItemId5.Columns["property_id"].ToString();
                    this.drpProp55.DataBind();
                    ListItem listItem9 = new ListItem("---SELECT---", "-99");
                    this.drpProp55.Items.Insert(0, listItem9);
                    DataTable dataTable6 = saleBLL.GetPropertyName(Convert.ToInt32(propertyByItemId5.Rows[0]["property_id"].ToString()));
                    this.lblProp55.Text = dataTable6.Rows[0]["code_name"].ToString();
                    return;
                }
                this.lblProp55.Visible = false;
                this.drpProp55.Visible = false;
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
            try
            {
                ChallanBLL challanBLL = new ChallanBLL();
                int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
                short num1 = Convert.ToInt16(this.drpBranchName.SelectedValue);
                DataTable nextChallanNo = challanBLL.GetNextChallanNo(2, num, num1);
                if (nextChallanNo == null || nextChallanNo.Rows.Count <= 0)
                {
                    this.txtChallanNo.Text = "";
                    this.hdBookId.Value = "";
                    this.hdPageNo.Value = "";
                }
                else
                {
                    this.txtChallanNo.Text = nextChallanNo.Rows[0]["challan_no"].ToString();
                    this.hdBookId.Value = nextChallanNo.Rows[0]["challan_book_id"].ToString();
                    this.hdPageNo.Value = nextChallanNo.Rows[0]["page_no"].ToString();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "GetNextChallanNo", fileLineNumber);
            }
        }

        private void GetPartyInfo()
        {
            try
            {
                this.drpParty.Items.Clear();
                DataTable allPartyInfoForSale = (new ChallanBLL()).GetAllPartyInfoForSale();
                if (allPartyInfoForSale != null && allPartyInfoForSale.Rows.Count > 0)
                {
                    this.drpParty.DataSource = allPartyInfoForSale;
                    this.drpParty.DataTextField = allPartyInfoForSale.Columns["party_name"].ToString();
                    this.drpParty.DataValueField = allPartyInfoForSale.Columns["party_id"].ToString();
                    this.drpParty.DataBind();
                }
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpParty.Items.Insert(0, listItem);
                this.Session["PARTY_INFO"] = allPartyInfoForSale;
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetPartyInfo");
            }
        }

        private void GetPartyInfoRegistrationWise(int regTypeId)
        {
            this.drpParty.Items.Clear();
            ChallanBLL challanBLL = new ChallanBLL();
            if (regTypeId == 0)
            {
                this.GetPartyInfo();
                return;
            }
            DataTable allPartyInfoRegistrationWiseForSale = challanBLL.GetAllPartyInfoRegistrationWiseForSale(regTypeId);
            if (allPartyInfoRegistrationWiseForSale != null && allPartyInfoRegistrationWiseForSale.Rows.Count > 0)
            {
                this.drpParty.DataSource = allPartyInfoRegistrationWiseForSale;
                this.drpParty.DataTextField = allPartyInfoRegistrationWiseForSale.Columns["party_name"].ToString();
                this.drpParty.DataValueField = allPartyInfoRegistrationWiseForSale.Columns["Party_id"].ToString();
                this.drpParty.DataBind();
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpParty.Items.Insert(0, listItem);
        }

        private void GetPriceInfo()
        {
            DataTable dataTable = new DataTable();
            string str = "";
            string value = "";
            try
            {
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                saleDetailDAON.ItemID = Convert.ToInt16(strArrays[0]);
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                if (this.drpSaleType.SelectedValue == "P")
                {
                    this.lblVAT.Text = "7.5";
                    decimal num5 = new decimal(0);
                    decimal num6 = new decimal(0);
                    decimal num7 = new decimal(0);
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
                        num5 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["prpsd_actl_prc"]);
                        num6 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["production_quantity"]);
                        num7 = num5 / num6;
                        this.txtUnitPrice.Text = num7.ToString();
                        this.lblUnitPrice.Text = num7.ToString();
                    }
                    DataTable priceInfoOfItemFrSaleN = this.objBLL.GetPriceInfoOfItemFrSaleN(saleDetailDAON);
                    if (priceInfoOfItemFrSaleN != null && priceInfoOfItemFrSaleN.Rows.Count > 0)
                    {
                        if (priceInfoOfItemFrSaleN.Rows[0]["AIT_RATE"].ToString() != "")
                        {
                            num4 = Convert.ToDouble(priceInfoOfItemFrSaleN.Rows[0]["AIT_RATE"]);
                        }
                        this.lblAIT.Text = num4.ToString("N");
                    }
                }
                else if (this.drpSaleType.SelectedValue == "T")
                {
                    this.lblVAT.Text = "5";
                    decimal num8 = new decimal(0);
                    decimal num9 = new decimal(0);
                    decimal num10 = new decimal(0);
                    DataTable unitPriceFromPD1 = this.objCPBLL.GetUnitPriceFromPD(saleDetailDAON.ItemID);
                    if (unitPriceFromPD1.Rows.Count <= 0)
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
                        num8 = Convert.ToDecimal(unitPriceFromPD1.Rows[0]["prpsd_actl_prc"]);
                        num9 = Convert.ToDecimal(unitPriceFromPD1.Rows[0]["production_quantity"]);
                        num10 = num8 / num9;
                        this.txtUnitPrice.Text = num10.ToString();
                        this.lblUnitPrice.Text = num10.ToString();
                    }
                }
                else if (this.lblProductType.Text != "C")
                {
                    DataTable priceInfoOfItemFrSaleN1 = this.objBLL.GetPriceInfoOfItemFrSaleN(saleDetailDAON);
                    string str1 = "";
                    str1 = priceInfoOfItemFrSaleN1.Rows[0]["per"].ToString();
                    if (priceInfoOfItemFrSaleN1 == null || priceInfoOfItemFrSaleN1.Rows.Count <= 0)
                    {
                        this.lblSD.Text = "0.00";
                        this.lblVAT.Text = "0.00";
                    }
                    else if (str1 != "1")
                    {
                        if (priceInfoOfItemFrSaleN1.Rows[0]["SD_RATE"].ToString() != "")
                        {
                            num = Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["SD_RATE"]);
                        }
                        if (priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"].ToString() != "")
                        {
                            num1 = Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"]);
                        }
                        if (num1 != 15)
                        {
                            this.chkRebatable.Checked = false;
                        }
                        else
                        {
                            this.chkRebatable.Checked = true;
                            this.chkRebatable.Attributes["style"] = "color:Green;";
                        }
                        if (priceInfoOfItemFrSaleN1.Rows[0]["AIT_RATE"].ToString() != "")
                        {
                            num4 = Convert.ToDouble(priceInfoOfItemFrSaleN1.Rows[0]["AIT_RATE"]);
                        }
                        this.lblSD.Text = num.ToString("N");
                        this.lblVAT.Text = num1.ToString("N");
                        this.lblAIT.Text = num4.ToString("N");
                    }
                    else
                    {
                        this.tbTotalVAT.Text = priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"].ToString();
                        this.lblVAT.Text = priceInfoOfItemFrSaleN1.Rows[0]["VAT_RATE"].ToString();
                        this.Label9.Text = " Per Unit.";
                        this.lblfxdVT.Text = "Tk. ";
                    }
                    decimal num11 = new decimal(0);
                    decimal num12 = new decimal(0);
                    decimal num13 = new decimal(0);
                    DataTable dataTable1 = this.objCPBLL.GetUnitPriceFromPD(saleDetailDAON.ItemID);
                    if (dataTable1.Rows.Count <= 0)
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
                        num11 = Convert.ToDecimal(dataTable1.Rows[0]["prpsd_actl_prc"]);
                        num12 = Convert.ToDecimal(dataTable1.Rows[0]["production_quantity"]);
                        num13 = num11 / num12;
                        this.txtUnitPrice.Text = num13.ToString();
                        this.lblUnitPrice.Text = num13.ToString();
                    }
                }
                else
                {
                    value = this.hdItemType.Value;
                    DataTable priceInfoOfItemFrSaleN2 = this.objBLL.GetPriceInfoOfItemFrSaleN(saleDetailDAON);
                    if (priceInfoOfItemFrSaleN2 == null || priceInfoOfItemFrSaleN2.Rows.Count <= 0)
                    {
                        this.lblUnitPrice.Text = "0.00";
                        this.txtUnitPrice.Text = "0.00";
                        this.lblNBRPrice.Text = "0.00";
                        this.lblSD.Text = "0.00";
                        this.lblVAT.Text = "0.00";
                    }
                    else
                    {
                        if (value == "I" || value == "")
                        {
                            this.txtUnitPrice.Text = priceInfoOfItemFrSaleN2.Rows[0]["unit_price"].ToString();
                            this.lblUnitPrice.Text = priceInfoOfItemFrSaleN2.Rows[0]["unit_price"].ToString();
                            this.lblNBRPrice.Text = priceInfoOfItemFrSaleN2.Rows[0]["cnfrmd_wholesale_prc"].ToString();
                            num3 = Convert.ToDouble(priceInfoOfItemFrSaleN2.Rows[0]["cnfrmd_wholesale_prc"]);
                            num2 = Convert.ToDouble(priceInfoOfItemFrSaleN2.Rows[0]["cnfrmd_sd_amount"]);
                        }
                        string str2 = "";
                        str2 = priceInfoOfItemFrSaleN2.Rows[0]["per"].ToString();
                        if (priceInfoOfItemFrSaleN2 == null || priceInfoOfItemFrSaleN2.Rows.Count <= 0)
                        {
                            this.lblSD.Text = "0.00";
                            this.lblVAT.Text = "0.00";
                        }
                        else if (str2 != "1")
                        {
                            if (priceInfoOfItemFrSaleN2.Rows[0]["SD_RATE"].ToString() != "")
                            {
                                num = Convert.ToDouble(priceInfoOfItemFrSaleN2.Rows[0]["SD_RATE"]);
                            }
                            if (priceInfoOfItemFrSaleN2.Rows[0]["VAT_RATE"].ToString() != "")
                            {
                                num1 = Convert.ToDouble(priceInfoOfItemFrSaleN2.Rows[0]["VAT_RATE"]);
                            }
                            if (num1 != 15)
                            {
                                this.chkRebatable.Checked = false;
                            }
                            else
                            {
                                this.chkRebatable.Checked = true;
                                this.chkRebatable.Attributes["style"] = "color:Green;";
                            }
                            if (priceInfoOfItemFrSaleN2.Rows[0]["AIT_RATE"].ToString() != "")
                            {
                                num4 = Convert.ToDouble(priceInfoOfItemFrSaleN2.Rows[0]["AIT_RATE"]);
                            }
                            this.lblSD.Text = num.ToString("N");
                            this.lblVAT.Text = num1.ToString("N");
                            this.lblAIT.Text = num4.ToString("N");
                        }
                        else
                        {
                            this.tbTotalVAT.Text = priceInfoOfItemFrSaleN2.Rows[0]["VAT_RATE"].ToString();
                            this.lblVAT.Text = priceInfoOfItemFrSaleN2.Rows[0]["VAT_RATE"].ToString();
                            this.Label9.Text = " Per Unit.";
                            this.lblfxdVT.Text = "Tk. ";
                        }
                        if (value != "I" && value != "")
                        {
                            this.lblUnitPrice.Text = "0.00";
                            this.txtUnitPrice.Text = "0.00";
                            this.lblNBRPrice.Text = "0.00";
                        }
                        else if (priceInfoOfItemFrSaleN2.Rows[0]["cnfrmd_actl_prc"].ToString() != "" && num1 > 0)
                        {
                            Convert.ToDouble(priceInfoOfItemFrSaleN2.Rows[0]["cnfrmd_actl_prc"]);
                        }
                    }
                }
                if (this.lblVAT.Text == "15")
                {
                    this.chkRebatable.Checked = true;
                    this.chkRebatable.Attributes["style"] = "color:Green;";
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "GetPriceInfo");
            }
        }

        private void GetPriceInfoForProperty()
        {
            DataTable dataTable = new DataTable();
            string str = "";
            try
            {
                SaleDetailDAON saleDetailDAON = new SaleDetailDAON();
                SaleBLL saleBLL = new SaleBLL();
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                saleDetailDAON.ItemID = Convert.ToInt16(strArrays[0]);
                if (saleDetailDAON.ItemID != -99)
                {
                    int num = 0;
                    int num1 = 0;
                    int num2 = 0;
                    if (this.drpProp11.Visible && this.drpProp11.SelectedValue != "-99")
                    {
                        num = Convert.ToInt32(this.drpProp11.SelectedValue.Trim());
                    }
                    if (this.drpProp22.Visible && this.drpProp22.SelectedValue != "-99")
                    {
                        num1 = Convert.ToInt32(this.drpProp22.SelectedValue.Trim());
                    }
                    if (this.drpProp33.Visible && this.drpProp33.SelectedValue != "-99")
                    {
                        num2 = Convert.ToInt32(this.drpProp33.SelectedValue.Trim());
                    }
                    dataTable = saleBLL.getSaleUnitPriceForProperty1(saleDetailDAON.ItemID, num, num1, num2);
                    if (dataTable.Rows.Count <= 0)
                    {
                        this.txtUnitPrice.Text = "0.00";
                    }
                    else
                    {
                        this.txtUnitPrice.Text = dataTable.Rows[0]["sale_unit_price"].ToString();
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
            SaleBLL saleBLL = new SaleBLL();
            string str = "";
            string str1 = "";
            string str2 = "";
            short num = 0;
            string str3 = MQMM.ParseText(this.productName.Text.Trim());
            SaleBLL saleBLL1 = new SaleBLL();
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            DateTime standardDateFromDdMMyyyy = BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtChallanDate.Text.Trim());
            string[] strArrays = str3.Split(new char[] { '-' });
            if (strArrays != null && strArrays.Count<string>() > 0)
            {
                str = strArrays[strArrays.Count<string>() - 4];
                str1 = strArrays[strArrays.Count<string>() - 5];
                this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 2];
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
            DataTable itemType = this.dbBLLLL.getItemType(num);
            string empty = string.Empty;
            string empty1 = string.Empty;
            if (itemType.Rows.Count > 0)
            {
                empty = itemType.Rows[0]["product_type"].ToString();
            }
            if (empty == "C")
            {
                empty1 = "F";
            }
            DataTable saleAvailableStockN = saleBLL1.GetSaleAvailableStockN(num, str2, standardDateFromDdMMyyyy, empty1);
            if (saleAvailableStockN.Rows != null)
            {
                this.lblUnit.Text = saleAvailableStockN.Rows[0]["unit_code"].ToString();
                this.hdUnitID.Value = saleAvailableStockN.Rows[0]["unit_id"].ToString();
                this.hdItemType.Value = saleAvailableStockN.Rows[0]["item_type"].ToString();
                this.chkExempted.Checked = Convert.ToBoolean(Convert.ToInt16(saleAvailableStockN.Rows[0]["is_exempted"]));
                this.chkRebatable.Checked = Convert.ToBoolean(Convert.ToInt16(saleAvailableStockN.Rows[0]["is_rebatable"]));
                if (saleAvailableStockN.Rows[0]["item_type"].ToString() != "I")
                {
                    this.lblAvailStock.Text = "0";
                }
                else
                {
                    this.lblAvailStock.Text = saleAvailableStockN.Rows[0]["availStock"].ToString();
                    this.lblavlStock.Text = string.Concat(saleAvailableStockN.Rows[0]["availStock"].ToString(), " ", this.lblUnit.Text);
                }
                if (saleAvailableStockN.Rows[0]["parent_id"] != null && Convert.ToInt16(saleAvailableStockN.Rows[0]["parent_id"]) > 0)
                {
                    this.drpCategory.SelectedValue = saleAvailableStockN.Rows[0]["parent_id"].ToString();
                    this.LoadSubCategory();
                    this.drpSubCategory.SelectedValue = saleAvailableStockN.Rows[0]["sub_category_id"].ToString();
                    this.itemForSearch(num, str2);
                    this.GetItemProperty();
                    return;
                }
                this.drpCategory.SelectedValue = saleAvailableStockN.Rows[0]["category_id"].ToString();
                this.drpSubCategory.Items.Clear();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
                this.drpSubCategory.Enabled = false;
            }
        }

        private void GetPropertyWiseAvailStock()
        {
            try
            {
                short num = 0;
                short num1 = 0;
                short num2 = 0;
                short num3 = 0;
                short num4 = 0;
                string empty = string.Empty;
                SaleBLL saleBLL = new SaleBLL();
                string str = "";
                string str1 = "";
                DateTime dateTime = DateTime.ParseExact(this.txtChallanDate.Text.Trim(), "dd/MM/yyyy", null);
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                short num5 = 0;
                string str2 = "";
                if (this.drpProp11.SelectedValue != "-99" && this.drpProp11.SelectedValue != "")
                {
                    num = Convert.ToInt16(this.drpProp11.SelectedValue);
                }
                if (this.drpProp22.SelectedValue != "-99" && this.drpProp22.SelectedValue != "")
                {
                    num1 = Convert.ToInt16(this.drpProp22.SelectedValue);
                }
                if (this.drpProp33.SelectedValue != "-99" && this.drpProp33.SelectedValue != "")
                {
                    num2 = Convert.ToInt16(this.drpProp33.SelectedValue);
                }
                if (this.drpProp44.SelectedValue != "-99" && this.drpProp44.SelectedValue != "")
                {
                    num3 = Convert.ToInt16(this.drpProp44.SelectedValue);
                }
                if (this.drpProp55.SelectedValue != "-99" && this.drpProp55.SelectedValue != "")
                {
                    num4 = Convert.ToInt16(this.drpProp55.SelectedValue);
                }
                if (this.drpItem.SelectedValue != "-99")
                {
                    if (num > 0)
                    {
                        empty = string.Concat(" AND property_id1 = ", num);
                    }
                    if (num1 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id2 = ", num1);
                    }
                    if (num2 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id3 = ", num2);
                    }
                    if (num3 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id4 = ", num3);
                    }
                    if (num4 > 0)
                    {
                        empty = string.Concat(empty, " AND property_id5 = ", num4);
                    }
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
                    dataTable = saleBLL.GetStockPropertyWise(num5, str1, dateTime, num, num1, num2, num3, num4, empty);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.lblAvailStock.Text = (dataTable.Rows[0]["item_type"].ToString() == "I" ? dataTable.Rows[0]["availStock"].ToString() : "0");
                        this.lblavlStock.Text = (dataTable.Rows[0]["item_type"].ToString() == "I" ? string.Concat(dataTable.Rows[0]["availStock"].ToString(), " ", this.lblUnit.Text) : "0");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private double getSD()
        {
            double num = 0;
            try
            {
                foreach (GridViewRow row in this.gvItem.Rows)
                {
                    num = num + (row.Cells[12].Text != "" ? Convert.ToDouble(row.Cells[12].Text) : 0);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return num;
        }

        private void GetTotalSaleValue()
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                if (this.gvItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItem.Rows.Count; i++)
                    {
                        num3 = Convert.ToDecimal(this.gvItem.Rows[i].Cells[33].Text.Trim());
                        num4 = Convert.ToDecimal(this.gvItem.Rows[i].Cells[16].Text.Trim());
                        num2 += Convert.ToDecimal(this.gvItem.Rows[i].Cells[15].Text.Trim());
                        num1 += Convert.ToDecimal(this.gvItem.Rows[i].Cells[14].Text.Trim());
                        num = num + (num4 - num3);
                    }
                }
                this.txtTotalSalePrice.Text = num.ToString();
                this.lblSaleamnt.Text = num.ToString();
                this.txtTotalAIT.Text = num2.ToString();
                this.txtTotalVAT.Text = num1.ToString();
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

        private double getVat()
        {
            double num = 0;
            try
            {
                foreach (GridViewRow row in this.gvItem.Rows)
                {
                    num = num + (row.Cells[13].Text != "" ? Convert.ToDouble(row.Cells[13].Text) : 0);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return num;
        }

        protected void giftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.giftCheckBox.Checked)
                {
                    this.giftPanel.Visible = false;
                    this.gvGiftItem.DataSource = null;
                    this.gvGiftItem.DataBind();
                    this.ClearGiftDetailControls();
                    this.Session["GIFT_SALE_DETAIL_LIST"] = new ArrayList();
                }
                else
                {
                    this.giftPanel.Visible = true;
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "giftCheckBox_CheckedChanged");
            }
        }

        private bool giftValidations()
        {
            this.lblMessage.Text = "";
            if (this.drpGiftItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select an item.", MsgBoxs.enmMessageType.Attention);
                this.drpGiftItem.Focus();
                return false;
            }
            if (this.drpGiftUnit.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select an unit.", MsgBoxs.enmMessageType.Attention);
                this.drpGiftUnit.Focus();
                return false;
            }
            if (this.txtGiftQnt.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Quantity is mandatory", MsgBoxs.enmMessageType.Attention);
                this.txtGiftQnt.Focus();
                return false;
            }
            if (Convert.ToDouble(this.txtGiftQnt.Text) > 0 && Convert.ToDouble(this.txtGiftQnt.Text) <= Convert.ToDouble(this.lblGiftAvailStock.Text))
            {
                return true;
            }
            this.msgBox.AddMessage(string.Concat("Quantity should be between 1 to ", this.lblGiftAvailStock.Text), MsgBoxs.enmMessageType.Attention);
            this.txtGiftQnt.Focus();
            return false;
        }

        protected void gvAddtnProperty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        protected void gvApprvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ItemID"]);
                int num1 = Convert.ToInt16(this.gvApprvItem.SelectedDataKey["ChallanID"]);
                this.ViewState["selctedRowNoSale"] = 1;
                ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LISTA"];
                int num2 = 0;
                while (num2 < item.Count)
                {
                    SaleDetailDAON saleDetailDAON = (SaleDetailDAON)item[num2];
                    if (saleDetailDAON.ItemID != num || saleDetailDAON.ChallanID != num1)
                    {
                        num2++;
                    }
                    else
                    {
                        this.ShowDetailDataForEdit(saleDetailDAON);
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvExcelFile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            SaleDetailDAON dataItem = e.Row.DataItem as SaleDetailDAON;
            e.Row.RowIndex.ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.FindControl("rowNo");
                foreach (string str in this.tableNameList)
                {
                    int num = this.tableNameList.IndexOf(str);
                    TableCell item = e.Row.Cells[num + 1];
                    if (this.objectPropertyNameList[num].ToString() == "Party_Name")
                    {
                        if (item.Text == "" || item.Text == null || item.Text == "&nbsp;")
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "Supplier Name Can not be Empty.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        else if (dataItem.partyID == 0)
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "This Supplier Name is not available.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num].ToString() == "Challan_No" && (item.Text == "" || item.Text == null || item.Text == "&nbsp;"))
                    {
                        item.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        item.ToolTip = "Ref.Challan No 6.3  Can not be Empty.";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (this.objectPropertyNameList[num].ToString() == "Item_Name")
                    {
                        if (item.Text.Trim() == "" || item.Text.Trim() == "&nbsp;" || item.Text.Trim() == "0")
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "Item Name Can not be Empty.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        else if (dataItem.ItemID == 0)
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "This Item Name is not available.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num].ToString() == "Quantity")
                    {
                        if (item.Text.Trim() == "" || item.Text.Trim() == "&nbsp;" || item.Text.Trim() == "0")
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "Quantity Can not be Empty.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        if (Convert.ToDouble(item.Text.Trim()) > dataItem.AvailStock)
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "Stock is not available.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num].ToString() == "Unit_Price" && (item.Text.Trim() == "" || item.Text.Trim() == "&nbsp;" || item.Text.Trim() == "0"))
                    {
                        item.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        item.ToolTip = "Unit Price Can not be Empty.";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (this.objectPropertyNameList[num].ToString() == "Unit")
                    {
                        if (item.Text.Trim() == "" || item.Text.Trim() == "&nbsp;" || item.Text.Trim() == "0")
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "Unit Can not be Empty.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        if (this.objItemBLL.getUnitIdbyUnit(dataItem.Unit.ToUpper()).Rows.Count == 0)
                        {
                            item.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            item.ToolTip = "This Unit is not available.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (!(this.objectPropertyNameList[num].ToString() == "Payment_Type") || !(item.Text.Trim() == "") && !(item.Text.Trim() == "&nbsp;") && !(item.Text.Trim() == "0"))
                    {
                        continue;
                    }
                    item.BackColor = Color.Crimson;
                    e.Row.BackColor = Color.LightPink;
                    item.ToolTip = "Payment Type Can not be Empty.";
                    if (this.status != 1)
                    {
                        continue;
                    }
                    this.status = 0;
                }
                this.btnExcelSave.Visible = Convert.ToBoolean(this.status);
            }
        }

        protected void gvGiftItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"];
                item.RemoveAt(e.RowIndex);
                this.Session["GIFT_SALE_DETAIL_LIST"] = item;
                this.AddGiftDetailDataInGrid();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvGiftItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                short num = Convert.ToInt16(this.gvGiftItem.SelectedDataKey["RowNo"]);
                this.ViewState["selctedGiftRowNoSale"] = num;
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
                        this.ShowGiftDataForEdit(saleGiftDetailDAON);
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
                ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LIST"];
                item.RemoveAt(e.RowIndex);
                this.Session["SALE_DETAIL_LIST"] = item;
                this.AddDetailDataInGrid();
                this.GetTotalSaleValue();
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
                ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LIST"];
                int num1 = 0;
                while (num1 < item.Count)
                {
                    SaleDetailDAON saleDetailDAON = (SaleDetailDAON)item[num1];
                    if (saleDetailDAON.RowNo != num)
                    {
                        num1++;
                    }
                    else
                    {
                        this.ShowDetailDataForEdit(saleDetailDAON);
                        for (int i = 0; i < this.gvAddtnProperty.Rows.Count; i++)
                        {
                            CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[i].FindControl("chkChallan");
                            checkBox.Enabled = true;
                        }
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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
                DateTime now = DateTime.UtcNow.AddHours(6);
                currentAccountBLL.InsertBalance(Convert.ToInt32(str), Convert.ToDecimal(str1), Convert.ToDecimal(str2), Convert.ToInt32(str3), now);
                this.Session["VAT_LAST_AMOUNT"] = null;
                this.Session["SD_LAST_AMOUNT"] = null;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "insertBalance", fileLineNumber);
            }
        }

        private void ItemBalancevs()
        {
            DataTable dataTable = this.item.getvatsd();
            if (dataTable.Rows.Count > 0)
            {
                this.Session["VAT_M"] = Convert.ToDouble(dataTable.Rows[0]["vat"]);
                this.Session["SD_M"] = Convert.ToDouble(dataTable.Rows[0]["sd"]);
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

        private void LoadAgreement()
        {
            try
            {
                int num = Convert.ToInt16(this.drpParty.SelectedValue);
                DataTable agreementByPartyId = this.item.getAgreementByPartyId(num);
                this.drpAgreement.DataSource = agreementByPartyId;
                this.drpAgreement.DataTextField = agreementByPartyId.Columns["agreement_no"].ToString();
                this.drpAgreement.DataValueField = agreementByPartyId.Columns["agreement_no"].ToString();
                this.drpAgreement.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpAgreement.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "LoadItems");
            }
        }

        private void LoadBatchNo(int itemId)
        {
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

        private void LoadGiftItems()
        {
            try
            {
                DataTable goodItems = (new AddItemBLL()).GetGoodItems();
                this.drpGiftItem.Items.Clear();
                this.drpGiftItem.DataSource = goodItems;
                this.drpGiftItem.DataTextField = goodItems.Columns["ITEM_NAME"].ToString();
                this.drpGiftItem.DataValueField = goodItems.Columns["ITEM_ID"].ToString();
                this.drpGiftItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpGiftItem.Items.Insert(0, listItem);
                this.Session["Gift_ITEM_INFO"] = goodItems;
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "LoadItems");
            }
        }

        private void loadGiftOrDiscountData(int ItemId)
        {
            DataTable dataTable = new DataTable();
            dataTable = this.dbBLL.getOnItemPromos(DateTime.UtcNow.Date, ItemId);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!(this.txtFinalQuantity.Text != "") || Convert.ToDouble(this.txtFinalQuantity.Text) < Convert.ToDouble(row["parent_item_qnt"]))
                    {
                        continue;
                    }
                    if (Convert.ToDecimal(row["discount_percentage"]) > new decimal(0))
                    {
                        TextBox str = this.txtdiscountpct;
                        double num = Convert.ToDouble(row["discount_percentage"]);
                        str.Text = num.ToString();
                    }
                    else if (Convert.ToDecimal(row["discount_amount"]) <= new decimal(0))
                    {
                        if (Convert.ToDecimal(row["gift_qnt"]) <= new decimal(0))
                        {
                            continue;
                        }
                        ArrayList item = (ArrayList)this.Session["GIFT_SALE_DETAIL_LIST"] ?? new ArrayList();
                        short num1 = Convert.ToInt16(item.Count + 1);
                        SaleGiftDetailDAON saleGiftDetailDAON = new SaleGiftDetailDAON()
                        {
                            RowNo = num1,
                            GiftParentItemID = ItemId,
                            GiftWithItemName = this.drpItem.SelectedItem.ToString(),
                            ItemID = Convert.ToInt32(row["gift_item_id"]),
                            ItemName = Convert.ToString(row["gift_item_name"]),
                            UnitName = Convert.ToString(row["gift_unit_code"]),
                            UnitId = Convert.ToInt32(row["gift_unit_id"]),
                            GiftQuantity = Convert.ToDecimal(row["gift_qnt"]),
                            Remarks = Convert.ToString(row["remarks"])
                        };
                        if (!string.IsNullOrWhiteSpace(Convert.ToString(row["gift_item_code"])))
                        {
                            saleGiftDetailDAON.ItemWithTypeID = Convert.ToString(row["gift_item_code"]);
                        }
                        saleGiftDetailDAON.RowNo = num1;
                        item.Add(saleGiftDetailDAON);
                        this.AddGiftDetailDataInGrid();
                        this.Session["GIFT_SALE_DETAIL_LIST"] = item;
                        this.giftCheckBox.Checked = true;
                        this.giftPanel.Visible = true;
                    }
                    else
                    {
                        TextBox textBox = this.txtDiscount;
                        double num2 = Convert.ToDouble(row["discount_amount"]);
                        textBox.Text = num2.ToString();
                    }
                }
            }
        }

        private void LoadHours()
        {
            this.drpChDtHr.Items.Add("00");
            this.drpDlDtHr.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
                this.drpDlDtHr.Items.Add(i.ToString("00"));
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
                setItemDAO.CatagoryTyp = this.drpTransaction2.SelectedValue;
                DataTable allItemByCatSubCat = addItemBLL.GetAllItemByCatSubCat(setItemDAO);
                this.drpItem.DataSource = allItemByCatSubCat;
                this.drpItem.DataTextField = allItemByCatSubCat.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = allItemByCatSubCat.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpItem.Items.Insert(0, listItem);
                this.lblNBRPrice.Text = "0.00";
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "0.00";
                this.lblSD.Text = "0.00";
                this.lblVAT.Text = "0.00";
                this.drpItem.Focus();
                this.Session["ITEM_INFO"] = allItemByCatSubCat;
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "LoadItems");
            }
        }

        private void LoadItemsByCatgSubCatg()
        {
            try
            {
                this.drpItem.Items.Clear();
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
                this.lblNBRPrice.Text = "0.00";
                this.lblUnitPrice.Text = "0.00";
                this.txtUnitPrice.Text = "";
                this.txtDiscount.Text = "";
                this.txtdiscountpct.Text = "";
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

        private void loadMasterData()
        {
            string str;
            SaleMasterDAON saleMasterDAON = new SaleMasterDAON();
            ArrayList item = (ArrayList)base.Cache["SALE_MASTER_DETAIL"] ?? new ArrayList();
            try
            {
                saleMasterDAON.OrgName = this.lt_companyName.Text.ToString();
                saleMasterDAON.OrgAddress = this.It_companyAddress.Text.ToString();
                saleMasterDAON.OrgBin = this.lblOrgBIN.Text.ToString();
                saleMasterDAON.Date = this.txtChallanDate.Text.ToString();
                saleMasterDAON.ChallanTime = string.Concat(this.drpChDtHr.SelectedItem.ToString(), " : ", this.drpChDtMin.SelectedItem.ToString());
                saleMasterDAON.ChallanNo = this.txtChallanNo.Text.ToString();
                if (!this.drpParty.Enabled)
                {
                    saleMasterDAON.IsNewParty = true;
                    saleMasterDAON.TransPartyName = BLL.Utility.ReplaceQuotes(this.txtPartyName.Text);
                    saleMasterDAON.PartAddress = BLL.Utility.ReplaceQuotes(this.txtAddress.Text);
                    if (!(this.txtPartyBIN.Text != "") || !(this.txtPartyBIN.Text != ""))
                    {
                        saleMasterDAON.PartyTIN = string.Concat("(NID)", BLL.Utility.ReplaceQuotes(this.txtNationalId.Text));
                    }
                    else
                    {
                        saleMasterDAON.PartyTIN = BLL.Utility.ReplaceQuotes(this.txtPartyBIN.Text);
                    }
                }
                else
                {
                    saleMasterDAON.PartyID = Convert.ToInt16(this.drpParty.SelectedValue);
                    saleMasterDAON.IsNewParty = false;
                }
                saleMasterDAON.TransPartyName = this.drpParty.SelectedItem.ToString();
                saleMasterDAON.PartAddress = BLL.Utility.ReplaceQuotes(this.txtAddress.Text);
                if (!(this.txtPartyBIN.Text != "                                        ") || !(this.txtPartyBIN.Text != ""))
                {
                    saleMasterDAON.PartyTIN = string.Concat("(NID)", BLL.Utility.ReplaceQuotes(this.txtNationalId.Text));
                }
                else
                {
                    saleMasterDAON.PartyTIN = BLL.Utility.ReplaceQuotes(this.txtPartyBIN.Text);
                }
                saleMasterDAON.UltimateDestination = BLL.Utility.ReplaceQuotes(this.txtDestination.Text);
                string[] strArrays = new string[] { this.txtDeliveryDate.Text.ToString(), " ", this.drpChDtHr.SelectedItem.ToString(), ":", this.drpChDtMin.SelectedItem.ToString() };
                saleMasterDAON.DeleveryDateTime = string.Concat(strArrays);
                SaleMasterDAON saleMasterDAON1 = saleMasterDAON;
                if (this.drpVehicleType.SelectedValue != "-99")
                {
                    str = this.drpVehicleType.SelectedItem.ToString();
                }
                else
                {
                    str = (string.Concat(" ", this.txtVehicleNo.Text.Trim()) != "" ? this.txtVehicleNo.Text.Trim() : "");
                }
                saleMasterDAON1.Vehicle = str;
                saleMasterDAON.VehicleNo = (this.txtVehicleNo.Text.Trim() != "" ? this.txtVehicleNo.Text.Trim() : "");
                item.Add(saleMasterDAON);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            base.Cache["SALE_MASTER_DETAIL"] = item;
        }

        private void LoadMinutes()
        {
            this.drpChDtMin.Items.Add("00");
            this.drpDlDtMin.Items.Add("00");
            for (int i = 1; i <= 59; i++)
            {
                this.drpChDtMin.Items.Add(i.ToString("00"));
                this.drpDlDtMin.Items.Add(i.ToString("00"));
            }
        }

        private void LoadSaleData()
        {
            try
            {
                DataTable dataTable = new DataTable();
                ChallanBLL challanBLL = new ChallanBLL();
                int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
                if (challanBLL.GetApproverStage().Rows.Count < 1)
                {
                    this.btnUpdateTransaction.Visible = false;
                }
                else
                {
                    this.btnUpdateTransaction.Visible = true;
                    ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LISTA"] ?? new ArrayList();
                    DataTable sale = this.objBLL.getSale();
                    short num1 = Convert.ToInt16(item.Count + 1);
                    if (sale.Rows.Count > 0)
                    {
                        for (int i = 0; i < sale.Rows.Count; i++)
                        {
                            SaleDetailDAON saleDetailDAON = new SaleDetailDAON()
                            {
                                RowNo = num1,
                                ChallanID = Convert.ToInt16(sale.Rows[i]["challan_id"])
                            };
                            string approveStagebyChallanId = this.getApproveStagebyChallanId(saleDetailDAON.ChallanID);
                            dataTable = (approveStagebyChallanId != "F" ? challanBLL.GetApproverStagebyEmployeeId(num, approveStagebyChallanId) : challanBLL.GetApproverStagebyEmployeeId(num, "4"));
                            if (dataTable.Rows.Count >= 1)
                            {
                                saleDetailDAON.itemSerials = sale.Rows[i]["item_serials"].ToString();
                                saleDetailDAON.ItemID = Convert.ToInt16(sale.Rows[i]["item_id"]);
                                saleDetailDAON.ItemName = sale.Rows[i]["item_name"].ToString();
                                saleDetailDAON.Quantity = Convert.ToDecimal(sale.Rows[i]["quantity"]);
                                saleDetailDAON.SaleQuantity = Convert.ToDecimal(sale.Rows[i]["quantity"]);
                                saleDetailDAON.SaleUnitID = Convert.ToInt32(sale.Rows[i]["unit_id"]);
                                DataTable itemType = this.dbBLLLL.getItemType(saleDetailDAON.ItemID);
                                string empty = string.Empty;
                                if (itemType.Rows.Count > 0)
                                {
                                    empty = itemType.Rows[0]["item_type"].ToString();
                                }
                                saleDetailDAON.ItemType = empty;
                                saleDetailDAON.TypeP = sale.Rows[i]["type_p"].ToString();
                                if (saleDetailDAON.TypeP == "L")
                                {
                                    saleDetailDAON.id = string.Concat(sale.Rows[i]["item_id"].ToString(), ".1");
                                }
                                if (saleDetailDAON.TypeP == "I")
                                {
                                    saleDetailDAON.id = string.Concat(sale.Rows[i]["item_id"].ToString(), ".2");
                                }
                                if (saleDetailDAON.TypeP == "F")
                                {
                                    saleDetailDAON.id = string.Concat(sale.Rows[i]["item_id"].ToString(), ".3");
                                }
                                if (empty == "C" && saleDetailDAON.TypeP != "S")
                                {
                                    saleDetailDAON.TypeP = "F";
                                }
                                this.GetAvailStockbeforeApprv(saleDetailDAON.ItemID, saleDetailDAON.TypeP);
                                saleDetailDAON.AvailStock = Convert.ToDouble(this.lblAvailStock.Text);
                                saleDetailDAON.UnitID = Convert.ToInt32(sale.Rows[i]["unit_id"]);
                                saleDetailDAON.SD = Convert.ToDecimal(sale.Rows[i]["sd"]);
                                saleDetailDAON.VAT = Convert.ToDecimal(sale.Rows[i]["vat"]);
                                saleDetailDAON.AIT = Convert.ToDecimal(sale.Rows[i]["ait"]);
                                saleDetailDAON.SDRate = Convert.ToDecimal(sale.Rows[i]["sd_rate"]);
                                saleDetailDAON.VATRate = Convert.ToDecimal(sale.Rows[i]["vat_rate"]);
                                saleDetailDAON.IsSrcTAXDeduct = Convert.ToBoolean(sale.Rows[i]["is_source_tax_deduct"]);
                                saleDetailDAON.IsExempted = Convert.ToBoolean(sale.Rows[i]["is_exempted"]);
                                saleDetailDAON.Price = Convert.ToDecimal(sale.Rows[i]["quantity"]) * Convert.ToDecimal(sale.Rows[i]["actual_price"]);
                                saleDetailDAON.BatchNo = sale.Rows[i]["batch_no"].ToString();
                                saleDetailDAON.RemarksDetail = sale.Rows[i]["remarks"].ToString();
                                if (!Convert.ToBoolean(sale.Rows[i]["is_rebatable"]))
                                {
                                    saleDetailDAON.Rebatable = "No";
                                }
                                else
                                {
                                    saleDetailDAON.IsRebatable = this.chkRebatable.Checked;
                                    saleDetailDAON.Rebatable = "Yes";
                                }
                                saleDetailDAON.UserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                                saleDetailDAON.isInexplicitExport = Convert.ToBoolean(sale.Rows[i]["is_inexplicit_export"]);
                                if (!Convert.ToBoolean(sale.Rows[i]["is_source_tax_deduct"]))
                                {
                                    saleDetailDAON.SrcTAXDeduct = "No";
                                }
                                else
                                {
                                    saleDetailDAON.SrcTAXDeduct = "Yes";
                                }
                                if (!Convert.ToBoolean(sale.Rows[i]["is_exempted"]))
                                {
                                    saleDetailDAON.Exempted = "No";
                                }
                                else
                                {
                                    saleDetailDAON.Exempted = "Yes";
                                }
                                if (!Convert.ToBoolean(sale.Rows[i]["is_fixed_vat"]))
                                {
                                    saleDetailDAON.IsFixed = false;
                                    saleDetailDAON.Fixed = "No";
                                }
                                else
                                {
                                    saleDetailDAON.IsFixed = true;
                                    saleDetailDAON.Fixed = "Yes";
                                }
                                if (!Convert.ToBoolean(sale.Rows[i]["is_truncated"]))
                                {
                                    saleDetailDAON.Truncated = "No";
                                    saleDetailDAON.IsTruncated = false;
                                }
                                else
                                {
                                    saleDetailDAON.IsTruncated = true;
                                    saleDetailDAON.Truncated = "Yes";
                                }
                                if (!Convert.ToBoolean(sale.Rows[i]["is_zero_rate"]))
                                {
                                    saleDetailDAON.ZeroRate = "No";
                                    saleDetailDAON.IsZeroRate = false;
                                }
                                else
                                {
                                    saleDetailDAON.IsZeroRate = true;
                                    saleDetailDAON.ZeroRate = "Yes";
                                }
                                if (!Convert.ToBoolean(sale.Rows[i]["is_mrp"]))
                                {
                                    saleDetailDAON.Mrp = "No";
                                    saleDetailDAON.IsMrp = false;
                                }
                                else
                                {
                                    saleDetailDAON.IsMrp = true;
                                    saleDetailDAON.Mrp = "Yes";
                                }
                                if (this.chkTaxDeducted.Checked)
                                {
                                    saleDetailDAON.VDS = true;
                                }
                                saleDetailDAON.UnitPriceBDT = Convert.ToDecimal(sale.Rows[i]["actual_price"]);
                                saleDetailDAON.UnitPrice = Convert.ToDecimal(sale.Rows[i]["actual_price"]);
                                saleDetailDAON.TotalPrice = saleDetailDAON.UnitPriceBDT * saleDetailDAON.Quantity;
                                saleDetailDAON.TotalPricegrid = saleDetailDAON.UnitPrice * saleDetailDAON.SaleQuantity;
                                saleDetailDAON.DSD = Convert.ToDecimal(sale.Rows[i]["sd"]);
                                saleDetailDAON.DVAT = Convert.ToDecimal(sale.Rows[i]["vat"]);
                                saleDetailDAON.DUnitPrice = Convert.ToDecimal(sale.Rows[i]["actual_price"]);
                                saleDetailDAON.TotalSalePrice = (saleDetailDAON.TotalPrice + saleDetailDAON.DSD) + saleDetailDAON.DVAT;
                                saleDetailDAON.Net_bill = Convert.ToDecimal(sale.Rows[i]["net_bill"]);
                                item.Add(saleDetailDAON);
                            }
                        }
                    }
                    this.Session["SALE_DETAIL_LISTA"] = item;
                    this.AddApproveDetailDataInGrid();
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "fillDetailProperties");
            }
        }

        private void LoadSubCategory()
        {
            try
            {
                DataTable dataTable = new DataTable();
                AddItemBLL addItemBLL = new AddItemBLL();
                if (this.drpCategory.SelectedValue != "" && this.drpCategory.SelectedValue != "-99")
                {
                    int num = Convert.ToInt32(this.drpCategory.SelectedValue);
                    dataTable = addItemBLL.getSubcategoryByCategoryId(num);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpSubCategory.DataSource = dataTable;
                        this.drpSubCategory.DataTextField = dataTable.Columns["category_NAME"].ToString();
                        this.drpSubCategory.DataValueField = dataTable.Columns["category_id"].ToString();
                        this.drpSubCategory.DataBind();
                    }
                }
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
            }
        }

        private bool MasterValidation()
        {
            if (this.txtChallanNo.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Set Challan No. from Challan Book Setup First", MsgBoxs.enmMessageType.Attention);
                this.txtChallanNo.Focus();
                return false;
            }
            if (this.txtChallanDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Insert Challan Date.", MsgBoxs.enmMessageType.Attention);
                this.txtChallanDate.Focus();
                return false;
            }
            if (this.drpParty.Enabled && this.drpParty.SelectedValue == "-99" && !this.chkDiscard.Checked)
            {
                this.msgBox.AddMessage("Insert Customer Name.", MsgBoxs.enmMessageType.Attention);
                this.drpParty.Focus();
                return false;
            }
            if (!this.drpParty.Enabled)
            {
                if (this.txtPartyName.Text.Trim().Length == 0)
                {
                    this.msgBox.AddMessage("Insert Customer Name.", MsgBoxs.enmMessageType.Attention);
                    this.txtChallanDate.Focus();
                    return false;
                }
                if (this.txtPartyBIN.Text.Trim().Length == 0)
                {
                    this.msgBox.AddMessage("Insert Customer BIN.", MsgBoxs.enmMessageType.Attention);
                    this.txtPartyBIN.Focus();
                    return false;
                }
            }
            if (this.drpTransaction.SelectedIndex == 1)
            {
                if (this.drpBank.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage("Select a Bank.", MsgBoxs.enmMessageType.Attention);
                    this.lblMessage.Text = "";
                    return false;
                }
                if (this.drpBranch.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage("Select a Branch.", MsgBoxs.enmMessageType.Attention);
                    this.drpBranch.Focus();
                    return false;
                }
                if (this.drpCPC.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage("Select a CPC.", MsgBoxs.enmMessageType.Attention);
                    this.drpCPC.Focus();
                    return false;
                }
            }
            if (this.chkDiscard.Checked && this.drpDiscardReason.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select a discard reason.", MsgBoxs.enmMessageType.Attention);
                this.drpDiscardReason.Focus();
                return false;
            }
            if (((ArrayList)this.Session["SALE_DETAIL_LIST"]).Count == 0)
            {
                this.msgBox.AddMessage("Please Add Item first.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if ((new ChallanBLL()).GetApproverStage().Rows.Count >= 1 || !(this.drpAgreement.SelectedValue == "-99") || (!(this.txtCashAmount.Text == "") || !(this.txtChequeAmount.Text == "") || !(this.txtbKashAmount.Text == "") || !(this.txtEFTAmount.Text == "") || !(this.txtPayOrderAmount.Text == "") || !(this.txtCreditAmount.Text == "") || !(this.txtRocketAmount.Text == "") || !(this.txtTPTAmount.Text == "") || !(this.txtDebitCartAmount.Text == "") || !(this.txtOthersAmount.Text == "")) && (!(this.txtCashAmount.Text == "") || !(this.txtChequeAmount.Text == "0") || !(this.txtbKashAmount.Text == "0") || !(this.txtEFTAmount.Text == "0") || !(this.txtPayOrderAmount.Text == "0") || !(this.txtCreditAmount.Text == "0") || !(this.txtRocketAmount.Text == "") || !(this.txtTPTAmount.Text == "0") || !(this.txtDebitCartAmount.Text == "0") || !(this.txtOthersAmount.Text == "0")))
            {
                return true;
            }
            this.msgBox.AddMessage("Please Add Payment first.", MsgBoxs.enmMessageType.Attention);
            return false;
        }

        private bool NewPartyValidation()
        {
            if (this.txtParty.Text.Length == 0)
            {
                this.msgBox.AddMessage("Insert Party Name", MsgBoxs.enmMessageType.Attention);
                this.txtParty.Focus();
                return false;
            }
            if (this.txtNationalIdNo.Text.Length != 0)
            {
                return true;
            }
            this.msgBox.AddMessage("Insert Party NID.", MsgBoxs.enmMessageType.Attention);
            this.txtNationalIdNo.Focus();
            return false;
        }

        protected void OKButton_Click(object sender, EventArgs e)
        {
            if (this.chkCheque.Checked && this.txt_transaction_id.Text == "")
            {
                this.lbl_transaction_id.Attributes.Add("style", "display:block");
                this.txt_transaction_id.Attributes.Add("style", "display:block");
                this.mpe.Show();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            try
            {
                if (!base.IsPostBack)
                {
                    this.Session["chkProperty"] = new Dictionary<int, int>();
                    string str = this.Session["empId"].ToString();
                    this.Page.Form.Attributes.Add("enctype", "multipart/form-data");
                    string hostName = Dns.GetHostName();
                    IPAddress[] addressList = Dns.GetHostEntry(hostName).AddressList;
                    string str1 = hostName;
                    string str2 = addressList[0].ToString();
                    string str3 = "SaleChallan_11s";
                    string str4 = "Sales Challan 11";
                    this.ubll.InsertUserTaskLog(Convert.ToInt32(str), DateTime.Now, str3, str4, str2, str1);
                    this.div_a.Visible = true;
                    this.div_b.Visible = true;
                    this.div_c.Visible = true;
                    this.div_d.Visible = false;
                    this.partVDS.Visible = false;
                    this.divexport.Visible = false;
                    this.fillPortCode(this.drpPortCode);
                    base.Cache["SALE_DETAIL_LIST"] = new ArrayList();
                    this.Session["SALE_DETAIL_LIST"] = new ArrayList();
                    this.Session["SALE_DETAIL_LISTA"] = new ArrayList();
                    this.Session["GIFT_SALE_DETAIL_LIST"] = new ArrayList();
                    base.Cache["GIFT_SALE_DETAIL_LIST"] = new ArrayList();
                    this.Session["PARTY_INFO"] = new DataTable();
                    this.Session["SALE_MASTER_DETAIL"] = new ArrayList();
                    this.Session["SALE_Master_LIST"] = new ArrayList();
                    this.txtChallanDate.Text = DateTime.UtcNow.AddHours(6).ToString("dd/MM/yyyy");
                    this.LoadSaleData();
                    this.SetSystemUsedProperties();
                    string str5 = this.Session["ORGANIZATION_ID"].ToString();
                    base.Request.RawUrl.ToString();
                    string str6 = this.Session["ORGBRANCHID"].ToString();
                    DataTable dataTable = this.permissionBLL.CheckPaymentMethodPermision(str5, str6, "/UI/Sale/SaleChallan_11s.aspx");
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.showPermittedPaymentMethods(dataTable);
                    }
                    this.lt_companyName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.It_companyAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.orgVDS.Text = this.Session["VAT_DEDUCT"].ToString();
                    int num = Convert.ToInt16(this.Session["ORGANIZATION_ID"].ToString());
                    DataTable economicActivity = this.orgbll.GetEconomic_activity(num);
                    if (economicActivity.Rows.Count > 0 && economicActivity.Rows[0]["economic_process_activity_name"].ToString() == "সেবা প্রদানকারী ")
                    {
                        this.drpTransaction2.SelectedIndex = 0;
                    }
                    UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                    UtilityK.fillVehicleTypeDropDownList(this.drpVehicleType);
                    UtilityK.fillChallanDiscardReasonList(this.drpDiscardReason);
                    BLL.Utility.fillAllBank(this.drpBank);
                    this.GetPartyInfo();
                    ListItem listItem = new ListItem("-- SELECT --", "-99");
                    this.drpVehicleType.Items.Insert(0, listItem);
                    this.drpAgreement.Items.Insert(0, listItem);
                    ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                    this.drpCategory.Items.Insert(0, listItem1);
                    UtilityK.fillSubCategoryByCatDropDownList(this.drpCategory, this.drpSubCategory);
                    this.drpSubCategory.Items.Insert(0, listItem);
                    ListItem listItem2 = new ListItem("-- SELECT --", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                    ListItem listItem3 = new ListItem("-- SELECT --", "-99");
                    this.drpBank.Items.Insert(0, listItem);
                    this.drpBranch.Items.Insert(0, listItem);
                    this.drpDiscardReason.Items.Insert(0, listItem);
                    this.LoadHours();
                    this.LoadMinutes();
                    this.LoadItems();
                    // this.LoadGiftItems();
                 
                    this.drpChDtHr.SelectedValue = DateTime.UtcNow.AddHours(6).Hour.ToString("00");
                    this.drpChDtMin.SelectedValue = DateTime.UtcNow.AddHours(6).Minute.ToString("00");
                    this.SetDeliveryTime();
                    this.GetCPCCode();
                    this.GetBranchInformation();
                    this.GetNextChallanNo();
                    this.VATLastUpdatedBalance();
                    this.SDLastUpdatedBalance();
                    this.insertBalance();
                    this.allSaleChallanPrint.Text = string.Concat("<a class='btn btn-danger' href='AllSaleChallan11View.aspx?Organization_id=", str5, "'>View All SaleChallan</a>");
                    this.dtGiftDiscountPlan = this.dbBLL.getGiftDiscountPromos(DateTime.UtcNow.Date);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void payment_CheckedChanged(object sender, EventArgs e)
        {
            this.mpe.Show();
            if (!this.chkBkash.Checked && !this.chkRoccket.Checked && !this.chkPayOrder.Checked && !this.chkCheque.Checked && !this.chkTT.Checked && !this.chkEFT.Checked && !this.CheDebitCard.Checked)
            {
                bool @checked = this.ChkOther.Checked;
            }
        }

        protected void productName_TextChanged(object sender, EventArgs e)
        {
            this.getProductInfo();
            this.GetPriceInfo();
        }

        private void PropertyFromProduction(int itemId, string batchNo)
        {
            try
            {
                DataTable productionItemProperty = this.objBLL.GetProductionItemProperty(itemId, batchNo);
                if (productionItemProperty.Rows.Count > 0)
                {
                    this.lblMfgDate.Visible = true;
                    this.txtMfgDate.Visible = true;
                    this.lblExpiryDate.Visible = true;
                    this.txtExpiryDate.Visible = true;
                    this.txtMfgDate.Text = productionItemProperty.Rows[0]["mfg_date"].ToString();
                    this.txtExpiryDate.Text = productionItemProperty.Rows[0]["expiry_date"].ToString();
                }
            }
            catch (Exception exception)
            {
                BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11s.aspx", "PropertyFromProduction");
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
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            string str = "";
            decimal num13 = new decimal(0);
            decimal num14 = Convert.ToDecimal(this.Session["unit_price"]);
            if (this.drpProp11.SelectedValue != "-99" && this.drpProp11.SelectedValue != "")
            {
                num5 = Convert.ToInt16(this.drpProp11.SelectedValue);
            }
            if (this.drpProp22.SelectedValue != "-99" && this.drpProp22.SelectedValue != "")
            {
                num6 = Convert.ToInt16(this.drpProp22.SelectedValue);
            }
            if (this.drpProp33.SelectedValue != "-99" && this.drpProp33.SelectedValue != "")
            {
                num7 = Convert.ToInt16(this.drpProp33.SelectedValue);
            }
            if (this.drpProp44.SelectedValue != "-99" && this.drpProp44.SelectedValue != "")
            {
                num8 = Convert.ToInt16(this.drpProp44.SelectedValue);
            }
            if (this.drpProp55.SelectedValue != "-99" && this.drpProp55.SelectedValue != "")
            {
                num9 = Convert.ToInt16(this.drpProp55.SelectedValue);
            }
            if (num5 != 0)
            {
                dataTable = addItemBLL.getPropQuantity(num5);
            }
            if (num6 != 0)
            {
                dataTable = addItemBLL.getPropQuantity(num6);
            }
            if (num7 != 0)
            {
                dataTable = addItemBLL.getPropQuantity(num9);
            }
            if (num8 != 0)
            {
                dataTable = addItemBLL.getPropQuantity(num8);
            }
            if (num9 != 0)
            {
                dataTable = addItemBLL.getPropQuantity(num9);
            }
            if (dataTable.Rows.Count <= 0)
            {
                this.txtQuantity.Text = this.txtFinalQuantity.Text;
                this.CalculatePricesUnitChange();
                return;
            }
            num10 = Convert.ToDecimal(dataTable.Rows[0]["quantity"]);
            if (num10 == new decimal(0))
            {
                num10 = new decimal(1);
            }
            str = this.drpUnit.SelectedItem.ToString();
            num12 = (!string.IsNullOrEmpty(this.txtFinalQuantity.Text) ? Convert.ToDecimal(this.txtFinalQuantity.Text) : new decimal(0));
            if (this.lblUnit.Text != str)
            {
                num11 = (!string.IsNullOrEmpty(this.txtFinalQuantity.Text) ? Convert.ToDecimal(this.txtFinalQuantity.Text) : new decimal(1));
                num13 = Convert.ToDecimal(num14) * num10;
                this.txtUnitPrice.Text = num13.ToString("0.00");
                num4 = num11 * num13;
                num2 = (num4 * num1) / new decimal(100);
                this.txtTotalSD.Text = num2.ToString("0.00");
                this.txtTotalPrice.Text = num4.ToString("0.00");
                num3 = ((num4 + num2) * num) / new decimal(100);
                TextBox textBox = this.txtPriceIncludingVat;
                decimal num15 = (num4 + num2) + num3;
                textBox.Text = num15.ToString("0.00");
                this.tbTotalVAT.Text = num3.ToString("0.00");
                this.lblTotalPrice.Text = num4.ToString("0.00");
                this.lblTotalVAT.Text = num3.ToString("0.00");
                this.lblTotalSD.Text = num2.ToString("0.00");
                Label label = this.lblTotalSalePrc;
                decimal num16 = (num4 + num2) + num3;
                label.Text = num16.ToString("0.00");
            }
            else
            {
                num11 = (!string.IsNullOrEmpty(this.txtFinalQuantity.Text) ? Convert.ToDecimal(this.txtFinalQuantity.Text) : new decimal(1));
                num13 = Convert.ToDecimal(num14);
                this.txtUnitPrice.Text = num13.ToString("0.00");
                num4 = num11 * num13;
                num2 = (num4 * num1) / new decimal(100);
                this.txtTotalSD.Text = num2.ToString("0.00");
                this.txtTotalPrice.Text = num4.ToString("0.00");
                num3 = ((num4 + num2) * num) / new decimal(100);
                TextBox str1 = this.txtPriceIncludingVat;
                decimal num17 = (num4 + num2) + num3;
                str1.Text = num17.ToString("0.00");
                this.tbTotalVAT.Text = num3.ToString("0.00");
                this.lblTotalPrice.Text = num4.ToString("0.00");
                this.lblTotalVAT.Text = num3.ToString("0.00");
                this.lblTotalSD.Text = num2.ToString("0.00");
                Label label1 = this.lblTotalSalePrc;
                decimal num18 = (num4 + num2) + num3;
                label1.Text = num18.ToString("0.00");
            }
            if (num12 != new decimal(0))
            {
                this.txtQuantity.Text = (num12 * num10).ToString("0.00");
            }
            else
            {
                TextBox textBox1 = this.txtQuantity;
                decimal num19 = new decimal(1) * num10;
                textBox1.Text = num19.ToString("0.00");
            }
            this.lblprpstk.Text = num10.ToString();
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
                today = BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
                formattedDateMMDDYYYY = BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
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
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "SDLastUpdatedBalance", fileLineNumber);
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
            string str1 = this.drpItem.SelectedItem.ToString();
            string str2 = "";
            int num = 0;
            string str3 = "";
            str3 = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str3.Split(new char[] { '.' });
            num = Convert.ToInt16(strArrays[0]);
            AddItemBLL addItemBLL = new AddItemBLL();
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
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            DataTable dataTable = this.objPDBll.geAdditionalPropertybySearch(str.ToUpper(), num, str2, num1, num2, num3);
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

        private void SetAddMode()
        {
            this.btnSave.Text = SaleChallan_11s.enmBtnText.Save.ToString();
        }

        private void SetDeliveryTime()
        {
            try
            {
                DataTable challanDeliveryDelay = (new CodeBLL()).GetChallanDeliveryDelay();
                try
                {
                    if (challanDeliveryDelay != null && challanDeliveryDelay.Rows.Count > 0)
                    {
                        Convert.ToInt16(challanDeliveryDelay.Rows[0]["code_value_1st"]);
                    }
                }
                catch
                {
                }
                string[] strArrays = new string[] { this.txtChallanDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                DateTime dateTime = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                this.txtDeliveryDate.Text = dateTime.ToString("dd/MM/yyyy");
                this.drpDlDtHr.SelectedValue = dateTime.ToString("HH");
                this.drpDlDtMin.SelectedValue = dateTime.ToString("mm");
            }
            catch
            {
            }
        }

        private void setDetaiAddMode()
        {
            this.btnAdd.Text = "Add Item";
        }

        private void setDetailUpdateMode()
        {
            this.btnAdd.Text = SaleChallan_11s.enmBtnText.Update.ToString();
        }

        private void setGiftDetaiAddMode()
        {
            this.btnAddGift.Text = "Add Gift";
        }

        private void setGiftDetailUpdateMode()
        {
            this.btnAddGift.Text = SaleChallan_11s.enmBtnText.Update.ToString();
        }

        private void setMainAddMode()
        {
            this.btnSave.Text = SaleChallan_11s.enmBtnText.Save.ToString();
            this.btnClear.Text = SaleChallan_11s.enmBtnText.Clear.ToString();
        }

        private void setMainUpdateMode()
        {
            this.btnSave.Text = SaleChallan_11s.enmBtnText.Update.ToString();
            this.btnClear.Text = SaleChallan_11s.enmBtnText.Cancel.ToString();
        }

        private void SetSystemUsedProperties()
        {
            try
            {
                SetItemPropertyBLL setItemPropertyBLL = new SetItemPropertyBLL();
                DataTable dataTable = new DataTable();
                dataTable = setItemPropertyBLL.GetSystemUsedProperty();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dataTable.Rows[i]["IS_USED_BY_SYSTEM"]) != 1)
                        {
                            this.lblPropertyCollection[i].Visible = false;
                            this.drpPropertyCollection[i].Visible = false;
                        }
                        else
                        {
                            this.lblPropertyCollection[i].Text = string.Concat(dataTable.Rows[i]["PROPERTY_TYPE_NAME"].ToString(), ":");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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
                    this.hdUnitID.Value = catSubCat.Rows[0]["unit_id"].ToString();
                    this.hdItemType.Value = catSubCat.Rows[0]["item_type"].ToString();
                }
                DateTime date = DateTime.UtcNow.AddHours(6).Date;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void ShowDetailDataForEdit(SaleDetailDAON objDetailDAO)
        {
            if (objDetailDAO.CatID > 0)
            {
                this.drpCategory.SelectedValue = objDetailDAO.CatID.ToString();
            }
            this.LoadSubCategory();
            if (objDetailDAO.SubCatID <= 0)
            {
                this.drpSubCategory.SelectedValue = "-99";
            }
            else
            {
                this.drpSubCategory.SelectedValue = objDetailDAO.SubCatID.ToString();
            }
            this.LoadItems();
            this.drpItem.SelectedValue = objDetailDAO.id.ToString();
            this.lblHSCode.Text = objDetailDAO.HSCode;
            this.EnableOrDisablePropertyForItem();
            this.txtQuantity.Text = objDetailDAO.Quantity.ToString();
            this.txtFinalQuantity.Text = objDetailDAO.SaleQuantity.ToString();
            this.GetAvailStock();
            this.lblUnit.Text = objDetailDAO.UnitName;
            this.hdUnitID.Value = objDetailDAO.UnitID.ToString();
            this.txtTotalPrice.Text = objDetailDAO.TotalPrice.ToString();
            this.txtPriceIncludingVat.Text = objDetailDAO.TotalSalePrice.ToString();
            this.tbTotalVAT.Text = objDetailDAO.VAT.ToString();
            this.txtTotalSD.Text = objDetailDAO.SD.ToString();
            this.txtDiscount.Text = objDetailDAO.Discount.ToString();
            this.txtdiscountpct.Text = objDetailDAO.Discount_pct.ToString();
            this.lblNBRPrice.Text = objDetailDAO.NBRPrice.ToString();
            this.lblSD.Text = objDetailDAO.SDRate.ToString("#0.##");
            this.lblVAT.Text = objDetailDAO.VATRate.ToString("#0.##");
            this.chkTaxDeducted.Checked = objDetailDAO.IsSrcTAXDeduct;
            this.chkExempted.Checked = objDetailDAO.IsExempted;
            this.chkRebatable.Checked = objDetailDAO.IsRebatable;
            this.lblAvailStock.Text = objDetailDAO.AvailStock.ToString();
            this.lblTotalPrice.Text = objDetailDAO.TotalPrice.ToString("N2");
            this.lblTotalSD.Text = objDetailDAO.SD.ToString("N2");
            this.lblTotalVAT.Text = objDetailDAO.VAT.ToString("N2");
            this.lblTotalSalePrc.Text = objDetailDAO.TotalSalePrice.ToString("N2");
            this.hdItemType.Value = objDetailDAO.ItemType;
            if (objDetailDAO.ItemType != "I")
            {
                this.lblUnitPrice.Text = "";
                this.txtUnitPrice.Text = objDetailDAO.UnitPriceBDT.ToString("N2");
            }
            else
            {
                this.txtUnitPrice.Text = objDetailDAO.UnitPriceBDT.ToString("N2");
            }
            this.setDetailUpdateMode();
        }

        private void ShowGiftDataForEdit(SaleGiftDetailDAON objDetailDAO)
        {
            this.LoadGiftItems();
            this.drpGiftItem.SelectedValue = objDetailDAO.ItemWithTypeID.ToString();
            this.GetAvailGiftStock();
            this.txtGiftQnt.Text = objDetailDAO.GiftQuantity.ToString();
            this.txtGiftRemarks.Text = objDetailDAO.Remarks;
            this.setGiftDetailUpdateMode();
        }

        private void showPermittedPaymentMethods(DataTable permissions)
        {
            for (int i = 0; i < permissions.Rows.Count; i++)
            {
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Cash")
                {
                    this.chkCash.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Credit")
                {
                    this.chkCredit.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Cheque")
                {
                    this.chkCheque.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Rocket")
                {
                    this.chkRoccket.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "bKash")
                {
                    this.chkBkash.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Credit Card" || permissions.Rows[i]["payment_method_name"].ToString() == "Debit Card")
                {
                    this.CheDebitCard.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Pay Order")
                {
                    this.chkPayOrder.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Electronic Fund Transfer")
                {
                    this.chkEFT.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Telephone Transfer")
                {
                    this.chkTT.Visible = true;
                }
                if (permissions.Rows[i]["payment_method_name"].ToString() == "Other")
                {
                    this.ChkOther.Visible = true;
                }
            }
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
            if (this.drpProp11.SelectedValue != "-99" && this.drpProp11.SelectedValue != "")
            {
                num = Convert.ToInt16(this.drpProp11.SelectedValue);
            }
            if (this.drpProp22.SelectedValue != "-99" && this.drpProp22.SelectedValue != "")
            {
                num1 = Convert.ToInt16(this.drpProp22.SelectedValue);
            }
            if (this.drpProp33.SelectedValue != "-99" && this.drpProp33.SelectedValue != "")
            {
                Convert.ToInt16(this.drpProp33.SelectedValue);
            }
            if (this.drpProp44.SelectedValue != "-99" && this.drpProp44.SelectedValue != "")
            {
                num2 = Convert.ToInt16(this.drpProp44.SelectedValue);
            }
            if (this.drpProp55.SelectedValue != "-99" && this.drpProp55.SelectedValue != "")
            {
                num3 = Convert.ToInt16(this.drpProp55.SelectedValue);
            }
            if (this.lblProp11.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num);
            }
            if (this.lblProp22.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num1);
            }
            if (this.lblProp33.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num3);
            }
            if (this.lblProp44.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num2);
            }
            if (this.lblProp55.Text == "Stick")
            {
                dataTable = addItemBLL.getPropQuantity(num3);
            }
            if (dataTable.Rows.Count <= 0)
            {
                this.txtQuantity.Text = this.txtFinalQuantity.Text;
                this.CalculatePricesUnitChange();
                return;
            }
            num4 = Convert.ToDecimal(dataTable.Rows[0]["quantity"]);
            str = this.drpUnit.SelectedItem.ToString();
            if (this.txtFinalQuantity.Text != "")
            {
                num5 = Convert.ToDecimal(this.txtFinalQuantity.Text);
            }
            if (this.lblUnit.Text != str)
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
                this.lblQuantityPrp.Text = this.txtFinalQuantity.Text;
                num6 = Convert.ToDecimal(num7);
            }
            this.txtUnitPrice.Text = num6.ToString();
            this.lblprpstk.Text = num4.ToString();
            this.txtQuantity.Text = this.lblQuantityPrp.Text;
            this.CalculatePricesUnitChangeforTobacco();
        }

        protected void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                num = (this.txtBoxQty.Text == "" ? new decimal(0) : Convert.ToDecimal(this.txtBoxQty.Text.Trim()));
                int num3 = 0;
                num3 = Convert.ToInt32(this.drpProp44.SelectedValue.Trim());
                DataTable boxQuantity = this.itmProperty.GetBoxQuantity(num3);
                num1 = (boxQuantity.Rows.Count <= 0 ? new decimal(0) : Convert.ToDecimal(boxQuantity.Rows[0]["quantity"].ToString()));
                num2 = num1 * num;
                this.txtQuantity.Text = num2.ToString();
                this.CalculatePricesQuantityChange();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtChallanDate_TextChanged(object sender, EventArgs e)
        {
            this.GetChDtTimeInWords();
            this.SetDeliveryTime();
        }

        protected void txtDeliveryDate_TextChanged(object sender, EventArgs e)
        {
            this.GetDelDtTimeInWords();
        }

        protected void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtQuantity.Text.Length > 0 && Convert.ToDecimal(this.txtQuantity.Text.ToString()) > new decimal(0) && !string.IsNullOrWhiteSpace(this.txtdiscountpct.Text) && Convert.ToDecimal(this.txtdiscountpct.Text.ToString()) > new decimal(0))
                {
                    TextBox str = this.txtDiscount;
                    decimal num = ((Convert.ToDecimal(this.txtQuantity.Text) * Convert.ToDecimal(this.txtUnitPrice.Text)) * Convert.ToDecimal(this.txtdiscountpct.Text)) / new decimal(100);
                    str.Text = num.ToString("0.00");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtdiscountpct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtQuantity.Text.Length > 0 && Convert.ToDecimal(this.txtQuantity.Text) > new decimal(0) && Convert.ToDecimal(this.txtDiscount.Text) > new decimal(0))
                {
                    TextBox str = this.txtdiscountpct;
                    decimal num = (Convert.ToDecimal(this.txtDiscount.Text) * new decimal(100)) / (Convert.ToDecimal(this.txtQuantity.Text) * Convert.ToDecimal(this.txtUnitPrice.Text));
                    str.Text = num.ToString("0.00");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtPriceIncludingVat_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            this.lblUnitPrice.Text = this.txtUnitPrice.Text;
            if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
            {
                this.stickWiseQuantity();
            }
            else
            {
                this.PropertyWiseQuantity();
            }
            string str = "";
            str = Convert.ToString(this.drpItem.SelectedValue);
            string[] strArrays = str.Split(new char[] { '.' });
            this.loadGiftOrDiscountData(Convert.ToInt16(strArrays[0]));
            this.CaluculateDiscount();
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            this.lblUnitPrice.Text = this.txtUnitPrice.Text;
            if (this.lblHSCode.Text == "2402.20.00" || this.lblHSCode.Text == "2402.90.00")
            {
                this.stickWiseQuantity();
            }
            else
            {
                this.PropertyWiseQuantity();
            }
            this.CaluculateDiscount();
        }

        private bool Validation()
        {
            this.lblMessage.Text = "";
            if (this.txtQuantity.Text.Trim().Length < 1 && this.txtFinalQuantity.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Quantity is mandatory", MsgBoxs.enmMessageType.Attention);
                this.txtQuantity.Focus();
                return false;
            }
            if (!this.txtUnitPrice.Visible && (this.lblNBRPrice.Text.Trim().Length < 1 || Convert.ToDouble(this.lblNBRPrice.Text) == 0))
            {
                this.msgBox.AddMessage("Unit Price has not confirmed for this Item.", MsgBoxs.enmMessageType.Attention);
                this.lblNBRPrice.Focus();
                return false;
            }
            if (this.txtUnitPrice.Visible && (this.txtUnitPrice.Text.Trim().Length < 1 || Convert.ToDouble(this.txtUnitPrice.Text) == 0))
            {
                this.msgBox.AddMessage("Unit Price is mandatory", MsgBoxs.enmMessageType.Attention);
                this.lblNBRPrice.Focus();
                return false;
            }
            if (this.drpItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select an item.", MsgBoxs.enmMessageType.Attention);
                this.drpItem.Focus();
                return false;
            }
            if (this.txtChallanNo.Text.Length > 0 && this.txtChallanDate.Text.Length == 0)
            {
                this.lblMessage.Text = "Please insert challan Date.";
                this.txtChallanDate.Focus();
                return false;
            }
            if (this.lblProductType.Text != "W")
            {
                double num = 0;
                if (this.Label9.Text != " Per Unit.")
                {
                    num = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text) : 0);
                }
                else
                {
                    num = (this.txtFinalQuantity.Text != "" ? Convert.ToDouble(this.txtFinalQuantity.Text) : 0);
                }
                if (this.installmentStatus.Text != "I")
                {
                    if (this.lblQuantityPrp.Text != "")
                    {
                        if (this.hdItemType.Value == "I" && num > Convert.ToDouble(this.lblAvailStock.Text))
                        {
                            this.msgBox.AddMessage("Stock not available.", MsgBoxs.enmMessageType.Attention);
                            return false;
                        }
                    }
                    else if (this.hdItemType.Value == "I" && num > Convert.ToDouble(this.lblAvailStock.Text))
                    {
                        this.msgBox.AddMessage("Stock not available.", MsgBoxs.enmMessageType.Attention);
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
                                int num1 = Convert.ToInt32(hiddenField.Value);
                                if (checkBox.Checked)
                                {
                                    arrayLists.Add(num1);
                                }
                            }
                            if (arrayLists.Count == 0)
                            {
                                this.msgBox.AddMessage("Please Select Property from Grid.", MsgBoxs.enmMessageType.Error);
                                return false;
                            }
                            if (arrayLists.Count != Convert.ToDecimal(this.txtFinalQuantity.Text))
                            {
                                this.msgBox.AddMessage("No of. Item Quantity and Property not equal.", MsgBoxs.enmMessageType.Error);
                                return false;
                            }
                        }
                    }
                }
            }
            if (this.drpProp11.Visible && this.drpProp11.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProp11.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProp22.Visible && this.drpProp22.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProp22.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProp33.Visible && this.drpProp33.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProp33.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpProp44.Visible && this.drpProp44.SelectedValue == "-99")
            {
                this.msgBox.AddMessage(string.Concat("Please select ", this.lblProp44.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (!this.drpProp55.Visible || !(this.drpProp55.SelectedValue == "-99"))
            {
                return true;
            }
            this.msgBox.AddMessage(string.Concat("Please select ", this.lblProp55.Text.Trim()), MsgBoxs.enmMessageType.Attention);
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
                today = BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2010");
                formattedDateMMDDYYYY = BLL.Utility.GetFormattedDateMMDDYYYY("01/01/2030");
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
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "saleChallan_11", "VATLastUpdatedBalance", fileLineNumber);
            }
        }

        private enum enmBtnText
        {
            Save,
            Update,
            Cancel,
            Clear
        }

        public static class WrittenNumerics
        {
            private readonly static string[] ones;

            private readonly static string[] teens;

            private readonly static string[] tens;

            private readonly static string[] thousandsGroups;

            static WrittenNumerics()
            {
                string[] strArrays = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
                SaleChallan_11s.WrittenNumerics.ones = strArrays;
                string[] strArrays1 = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                SaleChallan_11s.WrittenNumerics.teens = strArrays1;
                string[] strArrays2 = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                SaleChallan_11s.WrittenNumerics.tens = strArrays2;
                string[] strArrays3 = new string[] { "", " Thousand", " Million", " Billion" };
                SaleChallan_11s.WrittenNumerics.thousandsGroups = strArrays3;
            }

            public static string DateToWritten(DateTime date)
            {
                return string.Format("{0} {1} {2}", SaleChallan_11s.WrittenNumerics.IntegerToWritten(date.Day), date.ToString("MMMM"), SaleChallan_11s.WrittenNumerics.IntegerToWritten(date.Year));
            }

            private static string FriendlyInteger(int n, string leftDigits, int thousands)
            {
                if (n == 0)
                {
                    return leftDigits;
                }
                string str = leftDigits;
                if (str.Length > 0)
                {
                    str = string.Concat(str, " ");
                }
                if (n < 10)
                {
                    str = string.Concat(str, SaleChallan_11s.WrittenNumerics.ones[n]);
                }
                else if (n < 20)
                {
                    str = string.Concat(str, SaleChallan_11s.WrittenNumerics.teens[n - 10]);
                }
                else if (n >= 100)
                {
                    str = (n >= 1000 ? string.Concat(str, SaleChallan_11s.WrittenNumerics.FriendlyInteger(n % 1000, SaleChallan_11s.WrittenNumerics.FriendlyInteger(n / 1000, "", thousands + 1), 0)) : string.Concat(str, SaleChallan_11s.WrittenNumerics.FriendlyInteger(n % 100, string.Concat(SaleChallan_11s.WrittenNumerics.ones[n / 100], " Hundred"), 0)));
                }
                else
                {
                    str = string.Concat(str, SaleChallan_11s.WrittenNumerics.FriendlyInteger(n % 10, SaleChallan_11s.WrittenNumerics.tens[n / 10 - 2], 0));
                }
                return string.Concat(str, SaleChallan_11s.WrittenNumerics.thousandsGroups[thousands]);
            }

            public static string IntegerToWritten(int n)
            {
                if (n == 0)
                {
                    return "Zero";
                }
                if (n >= 0)
                {
                    return SaleChallan_11s.WrittenNumerics.FriendlyInteger(n, "", 0);
                }
                return string.Concat("Negative ", SaleChallan_11s.WrittenNumerics.IntegerToWritten(-n));
            }
        }

    }
}