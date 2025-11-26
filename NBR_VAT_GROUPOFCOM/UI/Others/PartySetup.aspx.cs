using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Others
{
    public partial class PartySetup : Page, IRequiresSessionState
    {
      
        private ChallanBLL challanBLL = new ChallanBLL();

        private TransPartyBLL objTsPBLL = new TransPartyBLL();

        private TransPartyDAO objTsPDAO = new TransPartyDAO();

        private OrgRegistrationInfoDAO orgRegInfo = new OrgRegistrationInfoDAO();

        private OrgRegistrationInfoBLL orgRegbll = new OrgRegistrationInfoBLL();

        public Dictionary<string, bool> partyNameList = new Dictionary<string, bool>();

        public ArrayList objectPropertyNameList = new ArrayList();

        public ArrayList tableDataList = new ArrayList();

        public ArrayList tableNameList = new ArrayList();

        public ArrayList validationList = new ArrayList();

        public ArrayList detailsList = new ArrayList();

        public ArrayList headerList = new ArrayList();

        public ArrayList headerNames = new ArrayList();

        public short status = 1;

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

        public PartySetup()
        {
        }

        protected void btnCancelToSaveInvoice(object sender, EventArgs e)
        {
            this.mpeYesNoModal.Hide();
        }

        protected void btnExcelSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnExcelSave.Visible = false;
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["PARTY_LIST"];
                this.Session.Remove("PARTY_LIST");
                if (arrayLists == null || arrayLists.Count == 0)
                {
                    this.gvExcelFile.DataSource = null;
                    this.gvExcelFile.DataBind();
                    this.msgBox.AddMessage("Please Upload Excel with valid DATA set.", MsgBoxs.enmMessageType.Error);
                }
                else if (this.btnExcelSave.Text == "Save")
                {
                    List<bool> flags = new List<bool>();
                    foreach (TransPartyDAO arrayList in arrayLists)
                    {
                        flags.Add(this.objTsPBLL.insertTransParty(arrayList));
                    }
                    int num = flags.Count<bool>((bool t) => t);
                    int num1 = flags.Count<bool>((bool t) => !t);
                    if (num > 0)
                    {
                        this.msgBox.AddMessage(string.Concat(num, " Party's Information  Save Successfully."), MsgBoxs.enmMessageType.Success);
                        this.clearFrom();
                        this.chkExcelImport.Checked = false;
                        this.chkManualInput.Checked = true;
                        this.manualMode();
                        this.GetPartyInfo();
                        this.loadGridView();
                    }
                    if (num1 > 0)
                    {
                        this.msgBox.AddMessage(string.Concat(num1, " Party's Informations Failed to save."), MsgBoxs.enmMessageType.Error);
                    }
                    this.gvExcelFile.DataSource = null;
                    this.gvExcelFile.DataBind();
                }
            }
            catch (Exception exception)
            {
                  BLL.Utility.InsertErrorTrack(exception.Message, "Add_trans_Party", "btnExcelSave_Click");
            }
        }

        protected void btnOkToReload(object sender, EventArgs e)
        {
            if (!this.objTsPBLL.reenableDeletedTrnsPartyById(this.deletedParty.Value))
            {
                this.msgBox.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
                return;
            }
            this.mpeYesNoModal.Hide();
            this.msgBox.AddMessage("Party Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
            this.clearFrom();
            this.loadGridView();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validation())
                {
                    this.objTsPDAO = this.insertTransParty(this.objTsPDAO);
                    if (this.btnSave.Text != "Save")
                    {
                        this.objTsPDAO = this.updateTransParty(this.objTsPDAO);
                        if (!this.objTsPBLL.updateTrnsParty(this.objTsPDAO))
                        {
                            this.msgBox.AddMessage("Party Information Update Failed ", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Party Information Update Successfully ", MsgBoxs.enmMessageType.Success);
                            this.clearFrom();
                            this.loadGridView();
                        }
                    }
                    else
                    {
                        int deletedTrnsPartyId = this.objTsPBLL.getDeletedTrnsPartyId(this.objTsPDAO.TransPartyName, this.objTsPDAO.PartyTIN, this.objTsPDAO.PartAddress);
                        if (deletedTrnsPartyId > 0)
                        {
                            this.deletedParty.Value = Convert.ToString(deletedTrnsPartyId);
                            this.mpeYesNoModal.Show();
                        }
                        else if (!this.objTsPBLL.insertTransParty(this.objTsPDAO))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Party Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.clearFrom();
                            this.loadGridView();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "Add_trans_Party", "btnSave_Click");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.loadGridViewByPartyId(Convert.ToInt32(this.drpParty.SelectedValue));
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.loadGridView();
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "Add_trans_Party", "btnShow_Click");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.objTsPDAO = this.updateTransParty(this.objTsPDAO);
                if (this.btnUpdate.Text == "Update")
                {
                    if (!this.objTsPBLL.updateTrnsParty(this.objTsPDAO))
                    {
                        this.msgBox.AddMessage("Party Information Update Failed ", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        this.msgBox.AddMessage("Party Information Update Successfully ", MsgBoxs.enmMessageType.Success);
                        this.clearFrom();
                        this.loadGridView();
                    }
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "Add_trans_Party", "btnUpdate_Click");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int m;
            int item;
            try
            {
                Dictionary<string, bool> strs = new Dictionary<string, bool>();
                Dictionary<short, string> nums = new Dictionary<short, string>()
            {
                { 1, "Regular Registered (Vat)" },
                { 4, "Registered For Turnover" },
                { 5, "Not Registered" },
                { 7, "Procurement Provider" },
                { 8, "Trader" }
            };
                Dictionary<short, string> nums1 = nums;
                Dictionary<string, int> dictionary = this.chklistTypeofBusiness.Items.Cast<ListItem>().ToDictionary<ListItem, string, int>((ListItem i) => i.Text.ToUpper(), (ListItem i) => Convert.ToInt32(i.Value));
                ArrayList arrayLists = new ArrayList();
                this.tableNameList = new ArrayList();
                this.objectPropertyNameList = new ArrayList();
                this.validationList = new ArrayList();
                this.partyNameList = new Dictionary<string, bool>();
                this.headerList = new ArrayList();
                this.headerNames = new ArrayList();
                this.detailsList = new ArrayList();
                this.gvExcelFile.DataSource = null;
                this.gvExcelFile.DataBind();
                string stringCellValue = "";
                string str = "";
                string str1 = "";
                string str2 = "SetParty";
                string lower = Path.GetExtension(this.FileUpload1.FileName).ToLower();
                if (string.IsNullOrEmpty(lower))
                {
                    this.msgBox.AddMessage(" File Path not Found! Please Choose Your File. ", MsgBoxs.enmMessageType.Attention);
                    return;
                }
                else
                {
                    HttpServerUtility server = base.Server;
                    DateTime now = DateTime.Now;
                    str1 = server.MapPath(string.Concat("~/CSV/partyImport_", now.ToString("ddMMyyyy_HHmmssFFF"), lower));
                    this.FileUpload1.SaveAs(str1);
                    this.Label11.Text = string.Concat(this.FileUpload1.FileName, "'s Data showing into the GridView");
                    try
                    {
                        HSSFWorkbook hSSFWorkbook = null;
                        ISheet sheet = null;
                        hSSFWorkbook = new HSSFWorkbook(new FileStream(str1, FileMode.Open, FileAccess.Read))
                        {
                            MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK
                        };
                        for (int num = 0; num < hSSFWorkbook.NumberOfSheets; num++)
                        {
                            ISheet sheetAt = hSSFWorkbook.GetSheetAt(num);
                            if (str2.ToUpper().Equals(sheetAt.SheetName.ToUpper()))
                            {
                                sheet = sheetAt;
                            }
                        }
                        IRow row = sheet.GetRow(1);
                        IRow rows = sheet.GetRow(0);
                        TransPartyDAO transPartyDAO = new TransPartyDAO();
                        for (int j = 1; j <= row.LastCellNum; j++)
                        {
                            ICell cell = rows.GetCell(j - 1);
                            ICell cell1 = row.GetCell(j - 1);
                            stringCellValue = cell.StringCellValue;
                            str = cell1.StringCellValue;
                            if (transPartyDAO.GetType().GetProperty(stringCellValue) != null)
                            {
                                this.objectPropertyNameList.Add(stringCellValue);
                                this.tableNameList.Add(str);
                                strs.Add(stringCellValue, false);
                                if (this.gvExcelFile.Columns.Count != 27)
                                {
                                    BoundField boundField = new BoundField()
                                    {
                                        HeaderText = str,
                                        DataField = stringCellValue
                                    };
                                    this.gvExcelFile.Columns.Add(boundField);
                                }
                            }
                        }
                        int lastRowNum = sheet.LastRowNum;
                        for (int k = 2; k <= lastRowNum; k++)
                        {
                            IRow row1 = sheet.GetRow(k);
                            bool flag = true;
                            for (int l = 0; l < this.tableNameList.Count; l++)
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
                            transPartyDAO = new TransPartyDAO();
                            bool flag1 = false;
                            int num1 = -1;
                            foreach (string str3 in this.objectPropertyNameList)
                            {
                                num1++;
                                string name = transPartyDAO.GetType().GetProperty(str3).PropertyType.Name;
                                if (transPartyDAO.GetType().GetProperty(str3).PropertyType.Name == "Boolean")
                                {
                                    row1.GetCell(num1).SetCellType(CellType.Boolean);
                                    bool booleanCellValue = false;
                                    if (row1.GetCell(num1) != null && row1.GetCell(num1, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        booleanCellValue = row1.GetCell(num1).BooleanCellValue;
                                    }
                                    transPartyDAO.GetType().GetProperty(str3).SetValue(transPartyDAO, booleanCellValue, null);
                                }
                                else if (transPartyDAO.GetType().GetProperty(str3).PropertyType.Name == "Int16")
                                {
                                    short num2 = 0;
                                    if (row1.GetCell(num1) != null && row1.GetCell(num1, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        num2 = Convert.ToInt16(row1.GetCell(num1));
                                    }
                                    transPartyDAO.GetType().GetProperty(str3).SetValue(transPartyDAO, num2, null);
                                }
                                else if (transPartyDAO.GetType().GetProperty(str3).PropertyType.Name != "Decimal")
                                {
                                    string empty = string.Empty;
                                    row1.GetCell(num1).SetCellType(CellType.String);
                                    if (row1.GetCell(num1) != null && row1.GetCell(num1, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        empty = row1.GetCell(num1).StringCellValue.Trim();
                                    }
                                    transPartyDAO.GetType().GetProperty(str3).SetValue(transPartyDAO, empty, null);
                                    if (empty == "")
                                    {
                                        continue;
                                    }
                                    if (str3 == "TransPartyName" && !this.partyNameList.ContainsKey(transPartyDAO.TransPartyName.Trim()))
                                    {
                                        if (this.partyNameList.TryGetValue(transPartyDAO.TransPartyName.Trim(), out flag1))
                                        {
                                            this.partyNameList[transPartyDAO.TransPartyName.Trim()] = true;
                                        }
                                        else if (this.objTsPBLL.getTrnsParty(transPartyDAO.TransPartyName.Trim()) <= 0)
                                        {
                                            this.partyNameList.Add(transPartyDAO.TransPartyName.Trim(), false);
                                        }
                                        else
                                        {
                                            this.partyNameList[transPartyDAO.TransPartyName.Trim()] = true;
                                        }
                                    }
                                    if (str3 == "upazilaName")
                                    {
                                        DataTable allUpazilaIdbyname = this.objTsPBLL.getAllUpazilaIdbyname(empty.ToUpper());
                                        if (allUpazilaIdbyname.Rows.Count > 0)
                                        {
                                            transPartyDAO.upazilaID = Convert.ToInt16(allUpazilaIdbyname.Rows[0]["upazila_id"]);
                                        }
                                    }
                                    if (str3 == "BusinessInformation")
                                    {
                                        DataTable businessInfo = this.objTsPBLL.getBusinessInfo(24, transPartyDAO.BusinessInformation);
                                        if (businessInfo.Rows.Count == 1)
                                        {
                                            transPartyDAO.BusinessInfo = Convert.ToInt16(businessInfo.Rows[0]["code_id_d"]);
                                        }
                                    }
                                    if (str3 == "VdsInfo")
                                    {
                                        DataTable vDSData = this.objTsPBLL.getVDSData(18, transPartyDAO.VdsInfo);
                                        if (vDSData.Rows.Count != 1)
                                        {
                                            strs1[str3] = true;
                                        }
                                        else
                                        {
                                            transPartyDAO.VDS = Convert.ToInt16(vDSData.Rows[0]["code_id_d"]);
                                        }
                                    }
                                    if (str3 == "RegistraionType")
                                    {
                                        TransPartyDAO key1 = transPartyDAO;
                                        KeyValuePair<short, string> keyValuePair = nums1.FirstOrDefault<KeyValuePair<short, string>>((KeyValuePair<short, string> x) => x.Value.Trim().ToUpper() == transPartyDAO.RegistraionType.Trim().ToUpper());
                                        key1.RegType = keyValuePair.Key;
                                        if (transPartyDAO.RegType == 0)
                                        {
                                            strs1[str3] = true;
                                        }
                                    }
                                    if (str3 == "EconomicProcess")
                                    {
                                        string[] strArrays = transPartyDAO.EconomicProcess.Split(new char[] { ',' });
                                        for (m = 0; m < (int)strArrays.Length; m++)
                                        {
                                            if (!dictionary.ContainsKey(strArrays[m].Trim().ToUpper()) && !strs1[str3])
                                            {
                                                strs1[str3] = true;
                                            }
                                        }
                                    }
                                    if (str3 != "PartAddress")
                                    {
                                        continue;
                                    }
                                    transPartyDAO.PartAddress = Utilities.checkForAschi(empty.Trim());
                                }
                                else
                                {
                                    decimal num3 = new decimal(0);
                                    if (row1.GetCell(num1) != null && row1.GetCell(num1, MissingCellPolicy.RETURN_NULL_AND_BLANK).CellType != CellType.Blank)
                                    {
                                        num3 = Convert.ToDecimal(row1.GetCell(num1).NumericCellValue);
                                    }
                                    transPartyDAO.GetType().GetProperty(str3).SetValue(transPartyDAO, num3, null);
                                }
                            }
                            transPartyDAO.UserID = Convert.ToInt16(this.Session["employee_id"]);
                            transPartyDAO.OrganizationID = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
                            transPartyDAO.PartyTIN = transPartyDAO.PartyBIN;
                            transPartyDAO.RowNo = Convert.ToInt16(this.validationList.Count);
                            arrayLists.Add(transPartyDAO);
                            this.validationList.Add(strs1);
                        }
                        Utilities.KillExcelFileProcess();
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        Utilities.KillExcelFileProcess();
                        this.msgBox.AddMessage(exception.Message, MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                    this.gvExcelFile.DataSource = arrayLists;
                    this.gvExcelFile.DataBind();
                    foreach (TransPartyDAO arrayList in arrayLists)
                    {
                        if (string.IsNullOrWhiteSpace(arrayList.EconomicProcess))
                        {
                            continue;
                        }
                        bool flag2 = false;
                        string empty1 = string.Empty;
                        string[] strArrays1 = arrayList.EconomicProcess.Split(new char[] { ',' });
                        for (m = 0; m < (int)strArrays1.Length; m++)
                        {
                            string str4 = strArrays1[m];
                            if (dictionary.ContainsKey(str4.Trim().ToUpper()))
                            {
                                if (flag2)
                                {
                                    item = dictionary[str4.Trim().ToUpper()];
                                    empty1 = string.Concat(empty1, ",", item.ToString());
                                }
                                else
                                {
                                    item = dictionary[str4.Trim().ToUpper()];
                                    empty1 = item.ToString();
                                    flag2 = true;
                                }
                            }
                        }
                        arrayList.EconomicProcess = empty1;
                    }
                    this.Session["PARTY_LIST"] = arrayLists;
                }
            }
            catch (Exception exception3)
            {
                Exception exception2 = exception3;
                Utilities.KillExcelFileProcess();
                BLL.Utility.InsertErrorTrack(exception2.Message, "Add_trans_Party", "btnUpload_Click");
            }
            Utilities.KillExcelFileProcess();
        }

        protected void chkExcelImport_OnCheckedChanged(object sender, EventArgs e)
        {
            this.excelMode();
        }

        protected void chklistTypeofBusiness_Changed(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            for (int i = 0; i < this.chklistTypeofBusiness.Items.Count; i++)
            {
                if (this.chklistTypeofBusiness.Items[i].Selected)
                {
                    empty1 = this.chklistTypeofBusiness.Items[i].Value.ToString();
                    if (empty1 == "4")
                    {
                        break;
                    }
                }
            }
            if (empty1 != "4")
            {
                this.divAreaOfMfg.Visible = false;
                return;
            }
            this.divAreaOfMfg.Visible = true;
            this.GetAreaOfManufacturing();
        }

        protected void chkManualInput_OnCheckedChanged(object sender, EventArgs e)
        {
            this.manualMode();
        }

        private void clearExcelData()
        {
            this.gvExcelFile.DataSource = null;
            this.gvExcelFile.DataBind();
        }

        private void clearFrom()
        {
            this.txtPartyCode.Text = "";
            this.txtPartyName.Text = "";
            this.txtPartyBIN.Text = "";
            this.txtPartyAddress.Text = "";
            this.txtPartyAddress.Text = "";
            this.txtUltimateDesignation.Text = "";
            this.txtOwnerName.Text = "";
            this.txtPhone.Text = "";
            this.txtEmail.Text = "";
            this.txtWeb.Text = "";
            this.chkVDS.Checked = false;
            this.chkExciseDuty.Checked = false;
            this.chkDevelopmentSurCharge.Checked = false;
            this.chkInformationTechology.Checked = false;
            this.chkHealthSafety.Checked = false;
            this.chkEnvironmentSafety.Checked = false;
            this.isVendor.Checked = false;
            this.isCustomer.Checked = false;
            this.isVc.Checked = false;
            this.isImporter.Checked = false;
            this.chklistTypeofBusiness.ClearSelection();
            this.drpRegistrationType.SelectedValue = "-99";
            this.drpVDS.SelectedValue = "0";
            this.txtNationalIdNo.Text = "";
            this.drpBusinessInfo.SelectedValue = "-99";
            this.drpTypeofBusiness.SelectedValue = "-99";
            this.drpUpazila.SelectedValue = "-99";
            this.txtcreditlmt.Text = "";
            this.btnSave.Text = "Save";
            this.deletedParty.Value = "";
        }

        protected void drpBusinessInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpRegistrationType.SelectedValue == "5" && this.drpBusinessInfo.SelectedValue == "6")
            {
                this.makeC2SectionRequired(false);
                this.makeC1SectionRequired(false);
                return;
            }
            if (this.drpRegistrationType.SelectedValue == "5" && this.drpBusinessInfo.SelectedValue != "6")
            {
                this.makeC2SectionRequired(false);
                this.makeC1SectionRequired(true);
            }
        }

        protected void drpRegistrationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(this.drpRegistrationType.SelectedValue == "1") && !(this.drpRegistrationType.SelectedValue == "4"))
            {
                this.makeC2SectionRequired(false);
                this.makeC1SectionRequired(true);
                return;
            }
            this.makeC2SectionRequired(true);
            this.makeC1SectionRequired(false);
        }

        private bool ExcellDataValidation(ArrayList list)
        {
            bool flag;
            int num = 1;
            IEnumerator enumerator = list.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    TransPartyDAO current = (TransPartyDAO)enumerator.Current;
                    if (current.TransPartyName == "" || current.TransPartyName == null)
                    {
                        this.msgBox.AddMessage(string.Concat("Row no ", num, "s Party name is missing "), MsgBoxs.enmMessageType.Error);
                        flag = false;
                        return flag;
                    }
                    else if (current.RegType == 0)
                    {
                        this.msgBox.AddMessage(string.Concat("Row no ", num, "s Registration type is missing"), MsgBoxs.enmMessageType.Error);
                        flag = false;
                        return flag;
                    }
                    else if (current.BusinessInfo == 0)
                    {
                        this.msgBox.AddMessage(string.Concat("Row no ", num, "s Business info is missing "), MsgBoxs.enmMessageType.Error);
                        flag = false;
                        return flag;
                    }
                    else if (!current.IsVendor && !current.IsCustomer)
                    {
                        this.msgBox.AddMessage(string.Concat("Row no ", num, "s Party type is not selected "), MsgBoxs.enmMessageType.Error);
                        flag = false;
                        return flag;
                    }
                    else if ((current.RegType == 1 || current.RegType == 4) && (current.PartyBIN == "" || current.PartyBIN == null))
                    {
                        this.msgBox.AddMessage(string.Concat("Row no ", num, "s Party BIN is mandatory as for its Registration type "), MsgBoxs.enmMessageType.Error);
                        flag = false;
                        return flag;
                    }
                    else if (current.PartyBIN != null && current.PartyBIN != "" && current.PartyBIN.Trim().Length < 13)
                    {
                        this.msgBox.AddMessage(string.Concat("Row no ", num, "s Party BIN must be 13 digit."), MsgBoxs.enmMessageType.Error);
                        flag = false;
                        return flag;
                    }
                    else if ((current.RegType == 5 || current.RegType == 7 || current.RegType == 8) && (current.nationalIdNo == "" || current.nationalIdNo == null))
                    {
                        this.msgBox.AddMessage(string.Concat("Row no ", num, "s National Nid is mandatory as for its Registration type "), MsgBoxs.enmMessageType.Error);
                        flag = false;
                        return flag;
                    }
                    else
                    {
                        num++;
                    }
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

        private void excelMode()
        {
            this.Div4.Visible = false;
            this.part_a.Visible = false;
            this.Div5.Visible = false;
            this.part_b.Visible = false;
            this.part_c.Visible = false;
            this.part_d.Visible = false;
            this.part_e.Visible = false;
            this.Div7.Visible = false;
            this.part_f.Visible = false;
            this.Div2.Visible = false;
            this.part_g.Visible = false;
            this.part_h.Visible = true;
            this.btnExcelSave.Visible = false;
        }

        private void GetAreaOfManufacturing()
        {
            this.drpAreaOfMfg.Items.Clear();
            DataTable areaOfManufacturing = (new ChallanBLL()).GetAreaOfManufacturing("");
            if (areaOfManufacturing != null && areaOfManufacturing.Rows.Count > 0)
            {
                this.drpAreaOfMfg.DataSource = areaOfManufacturing;
                this.drpAreaOfMfg.DataTextField = areaOfManufacturing.Columns["code_name"].ToString();
                this.drpAreaOfMfg.DataValueField = areaOfManufacturing.Columns["code_id_d"].ToString();
                this.drpAreaOfMfg.DataBind();
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpAreaOfMfg.Items.Insert(0, listItem);
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

        private void GetPartyInfo()
        {
            try
            {
                this.drpParty.Items.Clear();
                DataTable allPartyInfo = (new ChallanBLL()).GetAllPartyInfo();
                if (allPartyInfo != null && allPartyInfo.Rows.Count > 0)
                {
                    this.drpParty.DataSource = allPartyInfo;
                    this.drpParty.DataTextField = allPartyInfo.Columns["party_name"].ToString();
                    this.drpParty.DataValueField = allPartyInfo.Columns["party_id"].ToString();
                    this.drpParty.DataBind();
                }
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpParty.Items.Insert(0, listItem);
                this.Session["PARTY_INFO"] = allPartyInfo;
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "GetPartyInfo");
            }
        }

        protected void gvExcelFile_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            int deletedTrnsPartyId = 0;
            TransPartyDAO dataItem = e.Row.DataItem as TransPartyDAO;
            e.Row.RowIndex.ToString();
            if (e.Row.RowIndex >= 0)
            {
                if (!dataItem.IsVendor && !dataItem.IsCustomer && !dataItem.IsImporter)
                {
                    flag1 = true;
                }
                if ((dataItem.RegType == 1 || dataItem.RegType == 4) && (dataItem.PartyBIN == "" || dataItem.PartyBIN == null) && dataItem.BusinessInformation.ToUpper() != "INTERNATIONAL ORGANIZATION")
                {
                    flag2 = true;
                }
                if (dataItem.PartyBIN != null && dataItem.PartyBIN != "")
                {
                    int num = dataItem.PartyBIN.Count<char>((char c) => char.IsNumber(c));
                    if (num < 13 || num > 13)
                    {
                        flag3 = true;
                    }
                }
                if ((dataItem.RegType == 5 || dataItem.RegType == 7 || dataItem.RegType == 8) && (dataItem.nationalIdNo == "" || dataItem.nationalIdNo == null) && dataItem.BusinessInformation.ToUpper() != "INTERNATIONAL ORGANIZATION")
                {
                    flag4 = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hiddenField = e.Row.FindControl("rowNo") as HiddenField;
                Dictionary<string, bool> item = (Dictionary<string, bool>)this.validationList[Convert.ToInt32(hiddenField.Value)];
                foreach (string str in this.tableNameList)
                {
                    int num1 = this.tableNameList.IndexOf(str);
                    TableCell crimson = e.Row.Cells[num1 + 1];
                    if (item[this.objectPropertyNameList[num1].ToString()])
                    {
                        e.Row.BackColor = Color.LightPink;
                        if (this.status == 1 && this.objectPropertyNameList[num1].ToString().Trim() != "EconomicProcess")
                        {
                            this.status = 0;
                        }
                    }
                    else if (this.objectPropertyNameList[num1].ToString() == "TransPartyName")
                    {
                        if (crimson.Text == "" || crimson.Text == null || crimson.Text == "&nbsp;")
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Party Name Can not be Empty.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        else
                        {
                            string str1 = Utilities.checkForAschi(crimson.Text.Trim());
                            deletedTrnsPartyId = this.objTsPBLL.getDeletedTrnsPartyId(str1, dataItem.PartyTIN, dataItem.PartAddress);
                            if (this.partyNameList[str1])
                            {
                                crimson.BackColor = Color.Crimson;
                                e.Row.BackColor = Color.LightPink;
                                if (deletedTrnsPartyId <= 0)
                                {
                                    crimson.ToolTip = "This party already exists.";
                                }
                                else
                                {
                                    crimson.ToolTip = "This party is in deleted mode. Attempt to make this entry manually.";
                                }
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "PartyCode" && crimson.Text.Trim() != "" && crimson.Text.Trim() != "&nbsp;" && this.challanBLL.GetpartyCode(dataItem.PartyCode.Trim()).Rows.Count >= 1)
                    {
                        crimson.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        crimson.ToolTip = "This Party Code is already existed.";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "EconomicProcess")
                    {
                        if (crimson.Text.IndexOf("manufacturing", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            flag = true;
                        }
                        if (item[this.objectPropertyNameList[num1].ToString()])
                        {
                            crimson.BackColor = Color.Crimson;
                            crimson.ToolTip = "This Major Area of Economic Activities is not available.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "AreaOfManufacturingInfo")
                    {
                        if (crimson.Text.Trim() != "" && crimson.Text.Trim() != "&nbsp;")
                        {
                            DataTable areaOfManufacturing = this.challanBLL.GetAreaOfManufacturing(dataItem.AreaOfManufacturingInfo);
                            if (areaOfManufacturing.Rows.Count != 1)
                            {
                                crimson.BackColor = Color.Crimson;
                                e.Row.BackColor = Color.LightPink;
                                crimson.ToolTip = "This Area of Manufacturing is not present.";
                                if (this.status == 1)
                                {
                                    this.status = 0;
                                }
                            }
                            else
                            {
                                dataItem.AreaOfManufacturing = Convert.ToInt16(areaOfManufacturing.Rows[0]["code_id_d"]);
                            }
                        }
                        if (crimson.Text.Trim() != "" && crimson.Text.Trim() != "&nbsp;" && !flag)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Major Area of Economic Activities field is missng 'manufacturing'";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "RegistraionType" && (crimson.Text.Trim() == "" || crimson.Text.Trim() == "&nbsp;" || crimson.Text.Trim() == "0"))
                    {
                        crimson.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        crimson.ToolTip = "Registration type is missing";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "BusinessInformation" && (crimson.Text.Trim() == "" || crimson.Text.Trim() == "&nbsp;" || crimson.Text.Trim() == "0"))
                    {
                        crimson.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        crimson.ToolTip = "Business info is missing";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "IsVendor" && flag1)
                    {
                        crimson.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        crimson.ToolTip = "Party type is missing";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "IsImporter")
                    {
                        if (flag1)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Party type is missing";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        if ((dataItem.IsVendor || dataItem.IsCustomer) && dataItem.IsImporter)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Party type should be Only Importer";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "IsCustomer" && flag1)
                    {
                        crimson.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        crimson.ToolTip = "Party type is missing";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "PartyBIN")
                    {
                        if (flag2)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            TableCell tableCell = crimson;
                            tableCell.ToolTip = string.Concat(tableCell.ToolTip, "Party Bin should be provided for the selected regsitartion type. ");
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        if (flag3)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Party Bin should be 13 digit.(ex: 000000000-0000)";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        if (dataItem.PartyBIN.Length > 14)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Party Bin should be in this format (ex:000000000-0000)";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num1].ToString() == "nationalIdNo" && flag4)
                    {
                        crimson.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        crimson.ToolTip = "National NID should be provided for the selected regsitartion type. ";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (!(this.objectPropertyNameList[num1].ToString() == "upazilaName") || !(dataItem.upazilaName != "") || this.objTsPBLL.getAllUpazilaIdbyname(dataItem.upazilaName.ToUpper()).Rows.Count != 0)
                    {
                        continue;
                    }
                    crimson.BackColor = Color.Crimson;
                    e.Row.BackColor = Color.LightPink;
                    crimson.ToolTip = "This Upazila Name is not valid. ";
                    if (this.status != 1)
                    {
                        continue;
                    }
                    this.status = 0;
                }
                this.btnExcelSave.Visible = Convert.ToBoolean(this.status);
            }
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                this.gvShowParty.Rows[e.RowIndex].Cells[2].Text.Trim().ToString();
                int num = Convert.ToInt32(this.gvShowParty.Rows[e.RowIndex].Cells[1].Text);
                int num1 = Convert.ToInt16(this.gvShowParty.Rows[e.RowIndex].Cells[1].Text.Trim().ToString());
                DataTable partyfromSale = this.objTsPBLL.getPartyfromSale(num1);
                DataTable partyfromPurchase = this.objTsPBLL.getPartyfromPurchase(num1);
                DataTable partyfromProduction = this.objTsPBLL.getPartyfromProduction(num1);
                if (partyfromSale.Rows.Count >= 1 || partyfromPurchase.Rows.Count >= 1 || partyfromProduction.Rows.Count >= 1)
                {
                    this.msgBox.AddMessage("Fail to delete. Transaction exists of this Party.", MsgBoxs.enmMessageType.Error);
                }
                else if (!this.objTsPBLL.deleteTrnsPartyById(num))
                {
                    this.msgBox.AddMessage("Supplier Information Delete Failed", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.msgBox.AddMessage("Supplier Information Delete Successfully", MsgBoxs.enmMessageType.Success);
                    this.loadGridView();
                }
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "Add_trans_Party", "gvItem_RowDeleting");
            }
        }

        protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            try
            {
                short num = Convert.ToInt16(this.gvShowParty.SelectedDataKey["party_id"]);
                dataTable = this.objTsPBLL.getPartyByPartyID(num);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    bool flag = Convert.ToBoolean(dataTable.Rows[0]["is_vendor"].ToString());
                    bool flag1 = Convert.ToBoolean(dataTable.Rows[0]["is_customer"].ToString());
                    bool flag2 = Convert.ToBoolean(dataTable.Rows[0]["is_importer"].ToString());
                    if (!flag || !flag1)
                    {
                        this.isVc.Checked = false;
                        this.isVendor.Checked = flag;
                        this.isCustomer.Checked = flag1;
                        this.isImporter.Checked = flag2;
                    }
                    else
                    {
                        this.isVc.Checked = true;
                    }
                    this.drpRegistrationType.SelectedValue = dataTable.Rows[0]["reg_type"].ToString();
                    if (dataTable.Rows[0]["upazila_id"].ToString() != "" && dataTable.Rows[0]["upazila_id"].ToString() != "0")
                    {
                        this.drpUpazila.SelectedValue = dataTable.Rows[0]["upazila_id"].ToString();
                    }
                    this.drpBusinessInfo.SelectedValue = dataTable.Rows[0]["business_info_id"].ToString();
                    this.txtPartyName.Text = dataTable.Rows[0]["party_name"].ToString();
                    this.txtPhone.Text = dataTable.Rows[0]["phone"].ToString();
                    this.txtPartyBIN.Text = dataTable.Rows[0]["party_bin"].ToString();
                    this.txtEmail.Text = dataTable.Rows[0]["email"].ToString();
                    this.txtUltimateDesignation.Text = dataTable.Rows[0]["ultimate_destination"].ToString();
                    this.txtWeb.Text = dataTable.Rows[0]["web"].ToString();
                    this.txtOwnerName.Text = dataTable.Rows[0]["owner_name"].ToString();
                    this.txtcreditlmt.Text = dataTable.Rows[0]["credit_limit"].ToString();
                    this.txtPartyAddress.Text = dataTable.Rows[0]["party_address"].ToString();
                    this.txtPartyCode.Text = dataTable.Rows[0]["party_code"].ToString();
                    this.lblPartyID.Text = dataTable.Rows[0]["party_id"].ToString();
                    this.drpVDS.SelectedValue = dataTable.Rows[0]["vds"].ToString();
                    this.drpRegistrationType.SelectedValue = (dataTable.Rows[0]["reg_type"].ToString().Length > 0 ? dataTable.Rows[0]["reg_type"].ToString() : "-99");
                    this.txtNationalIdNo.Text = dataTable.Rows[0]["national_id_no"].ToString();
                    this.chkVDS.Checked = Convert.ToBoolean(dataTable.Rows[0]["is_vds_deduct"].ToString());
                    this.chkExciseDuty.Checked = Convert.ToBoolean(dataTable.Rows[0]["is_excise_duty"].ToString());
                    this.chkDevelopmentSurCharge.Checked = Convert.ToBoolean(dataTable.Rows[0]["is_development_surcharge"].ToString());
                    this.chkInformationTechology.Checked = Convert.ToBoolean(dataTable.Rows[0]["is_information_technology"].ToString());
                    this.chkHealthSafety.Checked = Convert.ToBoolean(dataTable.Rows[0]["is_health_safety"].ToString());
                    this.chkEnvironmentSafety.Checked = Convert.ToBoolean(dataTable.Rows[0]["is_environment_safety"].ToString());
                    this.drpBusinessInfo.SelectedValue = dataTable.Rows[0]["business_info_id"].ToString();
                    if (Convert.ToInt16(dataTable.Rows[0]["area_of_mfg_id"]) == 0)
                    {
                        this.divAreaOfMfg.Visible = false;
                    }
                    else
                    {
                        this.GetAreaOfManufacturing();
                        this.divAreaOfMfg.Visible = true;
                        this.drpAreaOfMfg.SelectedValue = dataTable.Rows[0]["area_of_mfg_id"].ToString();
                    }
                    string empty = string.Empty;
                    if (dataTable.Rows[0]["major_area_of_ecn_activity"].ToString() == "")
                    {
                        for (int i = 0; i < this.chklistTypeofBusiness.Items.Count; i++)
                        {
                            this.chklistTypeofBusiness.Items[i].Selected = false;
                        }
                    }
                    else
                    {
                        empty = dataTable.Rows[0]["major_area_of_ecn_activity"].ToString();
                        if (empty.Length > 0)
                        {
                            string[] strArrays = empty.Split(new char[] { ',' });
                            for (int j = 0; j < this.chklistTypeofBusiness.Items.Count; j++)
                            {
                                this.chklistTypeofBusiness.Items[j].Selected = strArrays.Contains<string>(this.chklistTypeofBusiness.Items[j].Value);
                            }
                        }
                    }
                    this.btnSave.Text = "Update";
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvShowParty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvShowParty.PageIndex = e.NewPageIndex;
            this.loadGridView();
        }

        protected void gvShowParty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Details")
                {
                    GridViewRow namingContainer = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int num = Convert.ToInt32(namingContainer.Cells[1].Text.ToString());
                    DataTable partyInfo = this.orgRegInfo.GetPartyInfo(num);
                    if (partyInfo != null && partyInfo.Rows.Count > 0)
                    {
                        DataRow item = partyInfo.Rows[0];
                        string str = item[29].ToString();
                        string str1 = "";
                        if (str != "")
                        {
                            DataTable dataTable = this.orgRegbll.majorArea(str);
                            if (dataTable.Rows.Count > 0)
                            {
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    str1 = string.Concat(str1, dataTable.Rows[i]["code_name"].ToString(), ',');
                                }
                            }
                        }
                        this.detailsPartyName.InnerText = (item[1].ToString().Length > 0 ? item[1].ToString() : "N/A");
                        this.detailsPartyAddress.InnerText = (item[3].ToString().Length > 0 ? item[3].ToString() : "N/A");
                        this.detailsPartyTin.InnerText = (item[2].ToString().Length > 0 ? item[2].ToString() : "N/A");
                        this.detailsPartyNid.InnerText = (item[21].ToString().Length > 0 ? item[21].ToString() : "N/A");
                        this.detailsOwnerName.InnerText = (item[5].ToString().Length > 0 ? item[5].ToString() : "N/A");
                        this.detailsBusinessType.InnerText = (item[37].ToString().Length > 0 ? item[37].ToString() : "N/A");
                        this.detailsPhone.InnerText = (item[6].ToString().Length > 0 ? item[6].ToString() : "N/A");
                        this.detailsEmail.InnerText = (item[7].ToString().Length > 0 ? item[7].ToString() : "N/A");
                        this.detailsWeb.InnerText = (item[8].ToString().Length > 0 ? item[8].ToString() : "N/A");
                        HtmlGenericControl htmlGenericControl = this.detailsMajorAreaOfEcnActivity;
                        char[] chrArray = new char[] { ',' };
                        htmlGenericControl.InnerText = str1.TrimEnd(chrArray);
                        this.detailsVendor.InnerText = (item[30].ToString().Length > 0 ? item[30].ToString() : "N/A");
                        this.detailsCustomer.InnerText = (item[31].ToString().Length > 0 ? item[31].ToString() : "N/A");
                        if (this.detailsVendor.InnerText.Length > 0 && this.detailsCustomer.InnerText.Length > 0)
                        {
                            this.partyHeader.InnerText = "Vendor / Customer Profile";
                        }
                        else if (this.detailsVendor.InnerText.Length > 0)
                        {
                            this.partyHeader.InnerText = "Vendor Profile";
                        }
                        else if (this.detailsCustomer.InnerText.Length <= 0)
                        {
                            this.partyHeader.InnerText = "Profile";
                        }
                        else
                        {
                            this.partyHeader.InnerText = "Customer Profile";
                        }
                        this.partyDetailsDiv.Visible = true;
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvShowParty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
            {
                ((ImageButton)e.Row.Cells[e.Row.Cells.Count - 2].Controls[0]).Attributes["onclick"] = "if(!confirm('Do you want to delete?'))return false;";
            }
        }

        private TransPartyDAO insertTransParty(TransPartyDAO objTransPartyDAO)
        {
            objTransPartyDAO.OrganizationID = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            objTransPartyDAO.upazilaID = Convert.ToInt32(this.drpUpazila.SelectedValue);
            objTransPartyDAO.TransPartyName = Utilities.checkForSingleQuotes(this.txtPartyName.Text.Trim());
            objTransPartyDAO.PartyBIN = this.txtPartyBIN.Text.Trim();
            objTransPartyDAO.PartyTIN = this.txtPartyBIN.Text.Trim();
            objTransPartyDAO.PartAddress = Utilities.checkForSingleQuotes(this.txtPartyAddress.Text.Trim());
            objTransPartyDAO.UltimateDesignation = Utilities.checkForSingleQuotes(this.txtUltimateDesignation.Text.Trim());
            objTransPartyDAO.OwnerName = Utilities.checkForSingleQuotes(this.txtOwnerName.Text.Trim());
            objTransPartyDAO.Phone = this.txtPhone.Text.Trim();
            objTransPartyDAO.Email = this.txtEmail.Text.Trim();
            objTransPartyDAO.WebAddress = this.txtWeb.Text.Trim();
            objTransPartyDAO.UserID = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
            objTransPartyDAO.PartyBIN = this.txtPartyBIN.Text.Trim();
            objTransPartyDAO.PartyCode = this.txtPartyCode.Text.Trim();
            objTransPartyDAO.CreditLimit = (!string.IsNullOrEmpty(this.txtcreditlmt.Text.ToString()) ? Convert.ToDecimal(this.txtcreditlmt.Text) : new decimal(0));
            if (this.drpVDS.SelectedValue == "-99")
            {
                objTransPartyDAO.VDS = 0;
            }
            else
            {
                objTransPartyDAO.VDS = Convert.ToInt16(this.drpVDS.SelectedValue);
            }
            if (!this.chkVDS.Checked)
            {
                objTransPartyDAO.IsVDS = false;
            }
            else
            {
                objTransPartyDAO.IsVDS = true;
            }
            if (this.drpRegistrationType.SelectedValue == "-99")
            {
                objTransPartyDAO.RegType = 0;
            }
            else
            {
                objTransPartyDAO.RegType = Convert.ToInt16(this.drpRegistrationType.SelectedValue);
            }
            objTransPartyDAO.nationalIdNo = this.txtNationalIdNo.Text.Trim();
            if (!this.chkExciseDuty.Checked)
            {
                objTransPartyDAO.isExciseDuty = false;
            }
            else
            {
                objTransPartyDAO.isExciseDuty = true;
            }
            if (!this.chkDevelopmentSurCharge.Checked)
            {
                objTransPartyDAO.isDevelopmentSurcharge = false;
            }
            else
            {
                objTransPartyDAO.isDevelopmentSurcharge = true;
            }
            if (!this.chkInformationTechology.Checked)
            {
                objTransPartyDAO.isInformationTechnology = false;
            }
            else
            {
                objTransPartyDAO.isInformationTechnology = true;
            }
            if (!this.chkHealthSafety.Checked)
            {
                objTransPartyDAO.isHealthSafety = false;
            }
            else
            {
                objTransPartyDAO.isHealthSafety = true;
            }
            if (!this.chkEnvironmentSafety.Checked)
            {
                objTransPartyDAO.isEnvironmentSafety = false;
            }
            else
            {
                objTransPartyDAO.isEnvironmentSafety = true;
            }
            string empty = string.Empty;
            int num = 0;
            for (int i = 0; i < this.chklistTypeofBusiness.Items.Count; i++)
            {
                if (this.chklistTypeofBusiness.Items[i].Selected)
                {
                    if (num != 0)
                    {
                        empty = string.Concat(empty, ",", this.chklistTypeofBusiness.Items[i].Value.ToString());
                    }
                    else
                    {
                        empty = this.chklistTypeofBusiness.Items[i].Value.ToString();
                        num++;
                    }
                }
            }
            empty = empty.Trim();
            objTransPartyDAO.EconomicProcess = empty;
            objTransPartyDAO.BusinessInfo = Convert.ToInt16(this.drpBusinessInfo.SelectedValue);
            if (this.drpAreaOfMfg.SelectedValue != "")
            {
                objTransPartyDAO.AreaOfManufacturing = Convert.ToInt16(this.drpAreaOfMfg.SelectedValue);
            }
            if (!this.isVc.Checked)
            {
                objTransPartyDAO.IsImporter = (this.isImporter.Checked ? true : false);
                objTransPartyDAO.IsVendor = (this.isVendor.Checked ? true : false);
                objTransPartyDAO.IsCustomer = (this.isCustomer.Checked ? true : false);
            }
            else
            {
                objTransPartyDAO.IsVendor = true;
                objTransPartyDAO.IsCustomer = true;
            }
            return objTransPartyDAO;
        }

        private void loadBusinessInfo()
        {
            TransPartyBLL transPartyBLL = new TransPartyBLL();
            try
            {
                DataTable businessInfo = transPartyBLL.getBusinessInfo(24, "");
                if (businessInfo.Rows.Count > 0)
                {
                    this.drpBusinessInfo.DataSource = businessInfo;
                    this.drpBusinessInfo.DataTextField = businessInfo.Columns["code_name"].ToString();
                    this.drpBusinessInfo.DataValueField = businessInfo.Columns["code_id_d"].ToString();
                    this.drpBusinessInfo.DataBind();
                    ListItem listItem = new ListItem("--- SELECT ---", "-99");
                    this.drpBusinessInfo.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadGridView()
        {
            DataTable allPartyForGrid = (new TransPartyBLL()).getAllPartyForGrid();
            this.gvShowParty.DataSource = allPartyForGrid;
            this.gvShowParty.DataBind();
        }

        private void loadGridViewByPartyId(int party_id)
        {
            DataTable partyByPartyID = (new TransPartyBLL()).getPartyByPartyID(party_id);
            this.gvShowParty.DataSource = partyByPartyID;
            this.gvShowParty.DataBind();
        }

        private void loadParty()
        {
            TransPartyBLL transPartyBLL = new TransPartyBLL();
            ArrayList arrayLists = new ArrayList();
            try
            {
                DataTable allParty = transPartyBLL.getAllParty();
                if (allParty.Rows.Count > 0)
                {
                    for (int i = 0; i < allParty.Rows.Count; i++)
                    {
                        TransPartyDAO transPartyDAO = new TransPartyDAO()
                        {
                            RowNo = Convert.ToInt16(i + 1),
                            PartyID = Convert.ToInt32(allParty.Rows[i]["party_id"].ToString()),
                            TransPartyName = allParty.Rows[i]["party_name"].ToString(),
                            PartAddress = allParty.Rows[i]["party_address"].ToString(),
                            PartyBIN = allParty.Rows[i]["party_bin"].ToString(),
                            OwnerName = allParty.Rows[i]["owner_name"].ToString(),
                            Phone = allParty.Rows[i]["phone"].ToString(),
                            IsVDS = Convert.ToBoolean(allParty.Rows[i]["is_vds_deduct"]),
                            IsVendor = Convert.ToBoolean(allParty.Rows[i]["is_vendor"]),
                            IsCustomer = Convert.ToBoolean(allParty.Rows[i]["is_customer"]),
                            IsImporter = Convert.ToBoolean(allParty.Rows[i]["is_customer"]),
                            UltimateDesignation = allParty.Rows[i]["ultimate_destination"].ToString(),
                            Email = allParty.Rows[i]["email"].ToString(),
                            WebAddress = allParty.Rows[i]["web"].ToString(),
                            VDS = Convert.ToInt16(allParty.Rows[i]["vds"].ToString()),
                            RegType = Convert.ToInt16(allParty.Rows[i]["reg_type"].ToString())
                        };
                        arrayLists.Add(transPartyDAO);
                    }
                }
                this.Session["PARTY_INFO"] = arrayLists;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadTypeOfBusinessOrganization()
        {
            DataTable economicPrcActivity = this.orgRegInfo.GetEconomicPrcActivity();
            if (economicPrcActivity != null && economicPrcActivity.Rows.Count > 0)
            {
                this.drpTypeofBusiness.DataSource = economicPrcActivity;
                this.drpTypeofBusiness.DataTextField = economicPrcActivity.Columns["code_name"].ToString();
                this.drpTypeofBusiness.DataValueField = economicPrcActivity.Columns["code_id_d"].ToString();
                this.drpTypeofBusiness.DataBind();
                for (int i = 0; i < economicPrcActivity.Rows.Count; i++)
                {
                    this.chklistTypeofBusiness.Items.Add(new ListItem(economicPrcActivity.Rows[i]["code_name"].ToString(), economicPrcActivity.Rows[i]["code_id_d"].ToString()));
                }
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpTypeofBusiness.Items.Insert(0, listItem);
            this.Session["TYPEOFBUSINESS_INFO"] = economicPrcActivity;
        }

        private void loadVDS()
        {
            TransPartyBLL transPartyBLL = new TransPartyBLL();
            try
            {
                DataTable vDSData = transPartyBLL.getVDSData(18, "");
                if (vDSData.Rows.Count > 0)
                {
                    this.drpVDS.DataSource = vDSData;
                    this.drpVDS.DataTextField = vDSData.Columns["code_name"].ToString();
                    this.drpVDS.DataValueField = vDSData.Columns["code_id_d"].ToString();
                    this.drpVDS.DataBind();
                    ListItem listItem = new ListItem("--- SELECT ---", "0");
                    this.drpVDS.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void lpadUpazila()
        {
            DataTable allUpazila = (new TransPartyBLL()).getAllUpazila();
            if (allUpazila != null && allUpazila.Rows.Count > 0)
            {
                this.drpUpazila.DataSource = allUpazila;
                this.drpUpazila.DataTextField = allUpazila.Columns["upazila_name"].ToString();
                this.drpUpazila.DataValueField = allUpazila.Columns["upazila_id"].ToString();
                this.drpUpazila.DataBind();
            }
            ListItem listItem = new ListItem("-- SELECT --", "-99");
            this.drpUpazila.Items.Insert(0, listItem);
        }

        protected void makeC1SectionRequired(bool required)
        {
            if (required)
            {
                this.lblNID.CssClass = "control-label col-sm-5 rqrd";
                return;
            }
            this.lblNID.CssClass = "control-label col-sm-5";
        }

        protected void makeC2SectionRequired(bool required)
        {
            if (required)
            {
                this.labelpartyBIN.CssClass = "control-label col-sm-5 rqrd";
                return;
            }
            this.labelpartyBIN.CssClass = "control-label col-sm-5";
        }

        private void manualMode()
        {
            this.Div4.Visible = true;
            this.part_a.Visible = true;
            this.Div5.Visible = true;
            this.part_b.Visible = true;
            this.part_c.Visible = true;
            this.part_d.Visible = true;
            this.part_e.Visible = true;
            this.Div7.Visible = true;
            this.part_f.Visible = true;
            this.Div2.Visible = true;
            this.part_g.Visible = true;
            this.part_h.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.GetPartyInfo();
                this.divAreaOfMfg.Visible = false;
                this.LoadTypeOfBusinessOrganization();
                this.Session["PARTY_LIST"] = new ArrayList();
                this.Session["PARTY_INFO"] = new ArrayList();
                this.loadVDS();
                this.loadBusinessInfo();
                ListItem listItem = new ListItem("--- SELECT ---", "-99");
                this.drpRegistrationType.Items.Insert(0, listItem);
                this.part_a.Visible = true;
                this.part_b.Visible = true;
                this.part_c.Visible = true;
                this.part_d.Visible = true;
                this.part_e.Visible = true;
                this.part_f.Visible = true;
                this.part_g.Visible = true;
                this.part_h.Visible = false;
                this.Div2.Visible = true;
                this.loadGridView();
                this.lpadUpazila();
            }
            Utilities.KillExcelFileProcess();
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnRefresh.Text = "Refresh";
        }

        private void showDataForEdit(TransPartyDAO objPartyDAO)
        {
            TransPartyBLL transPartyBLL = new TransPartyBLL();
            if (objPartyDAO != null)
            {
                this.txtPartyName.Text = objPartyDAO.TransPartyName;
                this.txtPhone.Text = objPartyDAO.Phone;
                this.txtPartyBIN.Text = objPartyDAO.PartyBIN;
                this.txtEmail.Text = objPartyDAO.Email;
                this.txtUltimateDesignation.Text = objPartyDAO.UltimateDesignation;
                this.txtWeb.Text = objPartyDAO.WebAddress;
                this.txtOwnerName.Text = objPartyDAO.OwnerName;
                if (objPartyDAO.IsVDS)
                {
                    this.chkVDS.Checked = true;
                }
                this.txtPartyAddress.Text = objPartyDAO.PartAddress;
                this.lblPartyID.Text = objPartyDAO.PartyID.ToString();
                this.drpVDS.SelectedValue = objPartyDAO.VDS.ToString();
                this.drpRegistrationType.SelectedValue = objPartyDAO.RegType.ToString();
            }
        }

        private TransPartyDAO updateTransParty(TransPartyDAO objTransPartyDAO)
        {
            objTransPartyDAO.TransPartyName = Utilities.checkForSingleQuotes(this.txtPartyName.Text.Trim());
            objTransPartyDAO.PartyBIN = this.txtPartyBIN.Text.Trim();
            objTransPartyDAO.PartyTIN = this.txtPartyBIN.Text.Trim();
            objTransPartyDAO.PartAddress = Utilities.checkForSingleQuotes(this.txtPartyAddress.Text.Trim());
            objTransPartyDAO.UltimateDesignation = Utilities.checkForSingleQuotes(this.txtUltimateDesignation.Text.Trim());
            objTransPartyDAO.OwnerName = Utilities.checkForSingleQuotes(this.txtOwnerName.Text.Trim());
            objTransPartyDAO.Phone = this.txtPhone.Text.Trim();
            objTransPartyDAO.PartyCode = this.txtPartyCode.Text.Trim();
            objTransPartyDAO.Email = this.txtEmail.Text.Trim();
            objTransPartyDAO.WebAddress = this.txtWeb.Text.Trim();
            objTransPartyDAO.UserID = Convert.ToInt32(this.Session["EMPLOYEE_ID"]);
            objTransPartyDAO.PartyBIN = this.txtPartyBIN.Text.Trim();
            if (this.drpVDS.SelectedValue == "-99")
            {
                objTransPartyDAO.VDS = 0;
            }
            else
            {
                objTransPartyDAO.VDS = Convert.ToInt16(this.drpVDS.SelectedValue);
            }
            if (!this.chkVDS.Checked)
            {
                objTransPartyDAO.IsVDS = false;
            }
            else
            {
                objTransPartyDAO.IsVDS = true;
            }
            if (!this.chkExciseDuty.Checked)
            {
                objTransPartyDAO.isExciseDuty = false;
            }
            else
            {
                objTransPartyDAO.isExciseDuty = true;
            }
            if (!this.chkDevelopmentSurCharge.Checked)
            {
                objTransPartyDAO.isDevelopmentSurcharge = false;
            }
            else
            {
                objTransPartyDAO.isDevelopmentSurcharge = true;
            }
            if (!this.chkInformationTechology.Checked)
            {
                objTransPartyDAO.isInformationTechnology = false;
            }
            else
            {
                objTransPartyDAO.isInformationTechnology = true;
            }
            if (!this.chkHealthSafety.Checked)
            {
                objTransPartyDAO.isHealthSafety = false;
            }
            else
            {
                objTransPartyDAO.isHealthSafety = true;
            }
            if (!this.chkEnvironmentSafety.Checked)
            {
                objTransPartyDAO.isEnvironmentSafety = false;
            }
            else
            {
                objTransPartyDAO.isEnvironmentSafety = true;
            }
            if (this.drpRegistrationType.SelectedValue == "-99")
            {
                objTransPartyDAO.RegType = 0;
            }
            else
            {
                objTransPartyDAO.RegType = Convert.ToInt16(this.drpRegistrationType.SelectedValue);
            }
            objTransPartyDAO.PartyID = Convert.ToInt32(this.lblPartyID.Text.Trim());
            objTransPartyDAO.nationalIdNo = this.txtNationalIdNo.Text.Trim();
            objTransPartyDAO.CreditLimit = Convert.ToDecimal(this.txtcreditlmt.Text);
            string empty = string.Empty;
            int num = 0;
            for (int i = 0; i < this.chklistTypeofBusiness.Items.Count; i++)
            {
                if (this.chklistTypeofBusiness.Items[i].Selected)
                {
                    if (num != 0)
                    {
                        empty = string.Concat(empty, ",", this.chklistTypeofBusiness.Items[i].Value.ToString());
                    }
                    else
                    {
                        empty = this.chklistTypeofBusiness.Items[i].Value.ToString();
                        num++;
                    }
                }
            }
            empty = empty.Trim();
            objTransPartyDAO.EconomicProcess = empty;
            objTransPartyDAO.BusinessInfo = Convert.ToInt16(this.drpBusinessInfo.SelectedValue);
            objTransPartyDAO.upazilaID = Convert.ToInt16(this.drpUpazila.SelectedValue);
            objTransPartyDAO.AreaOfManufacturing = (this.drpAreaOfMfg.SelectedValue.ToString().Length > 0 ? Convert.ToInt16(this.drpAreaOfMfg.SelectedValue) : Convert.ToInt16(0));
            if (!this.isVc.Checked)
            {
                objTransPartyDAO.IsImporter = (this.isImporter.Checked ? true : false);
                objTransPartyDAO.IsVendor = (this.isVendor.Checked ? true : false);
                objTransPartyDAO.IsCustomer = (this.isCustomer.Checked ? true : false);
            }
            else
            {
                objTransPartyDAO.IsVendor = true;
                objTransPartyDAO.IsCustomer = true;
            }
            return objTransPartyDAO;
        }

        private bool Validation()
        {
            if (this.drpRegistrationType.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select registration type", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpBusinessInfo.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Business Info.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtPartyName.Text.Trim().Length < 1)
            {
                this.msgBox.AddMessage("Please type party name", MsgBoxs.enmMessageType.Attention);
                this.txtPartyName.Focus();
                return false;
            }
            if (!this.isVendor.Checked && !this.isCustomer.Checked && !this.isVc.Checked && !this.isImporter.Checked)
            {
                this.msgBox.AddMessage("Please Select party type", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (Convert.ToInt16(this.drpRegistrationType.SelectedValue) == 5 && this.txtNationalIdNo.Text == "" && this.drpBusinessInfo.SelectedValue != "6")
            {
                this.msgBox.AddMessage("Please insert national id", MsgBoxs.enmMessageType.Attention);
                this.txtNationalIdNo.Focus();
                return false;
            }
            if ((Convert.ToInt16(this.drpRegistrationType.SelectedValue) == 1 || Convert.ToInt16(this.drpRegistrationType.SelectedValue) == 4) && this.txtPartyBIN.Text == "")
            {
                this.msgBox.AddMessage("Please insert Party BIN.", MsgBoxs.enmMessageType.Attention);
                this.txtNationalIdNo.Focus();
                return false;
            }
            if (this.txtPartyBIN.Text != "" && this.txtPartyBIN.Text.Trim().Length < 13)
            {
                this.msgBox.AddMessage("Party BIN must be 13 digit.", MsgBoxs.enmMessageType.Attention);
                this.txtPartyName.Focus();
                return false;
            }
            if (this.txtNationalIdNo.Text.Length > 0 && this.txtNationalIdNo.Text.Length != 10 && this.txtNationalIdNo.Text.Length != 17)
            {
                this.msgBox.AddMessage("NID must be 10 or 17 digit.", MsgBoxs.enmMessageType.Error);
                this.txtNationalIdNo.Focus();
                return false;
            }
            if (this.txtPhone.Text.Length > 0 && this.txtPhone.Text.Length != 11)
            {
                this.msgBox.AddMessage("You should insert a valid (11 digit) phone number", MsgBoxs.enmMessageType.Error);
                this.txtEmail.Focus();
                return false;
            }
            if (this.btnSave.Text == "Save")
            {
                DataTable party = this.objTsPBLL.getParty();
                if (party.Rows.Count > 0)
                {
                    for (int i = 0; i < party.Rows.Count; i++)
                    {
                        if (this.txtPartyName.Text == party.Rows[i]["party_name"].ToString())
                        {
                            this.msgBox.AddMessage("Duplicate Party Name", MsgBoxs.enmMessageType.Attention);
                            return false;
                        }
                        if (this.txtPartyCode.Text == party.Rows[i]["party_code"].ToString() && party.Rows[i]["party_code"].ToString() != "")
                        {
                            this.msgBox.AddMessage("Duplicate Party Code", MsgBoxs.enmMessageType.Attention);
                            return false;
                        }
                    }
                }
            }
            if (this.txtEmail.Text.Length == 0 || this.txtEmail.Text.EndsWith(".com") && this.txtEmail.Text.Contains("@"))
            {
                return true;
            }
            this.msgBox.AddMessage("You should insert a valid mail address", MsgBoxs.enmMessageType.Error);
            this.txtEmail.Focus();
            return false;
        }
    }
}