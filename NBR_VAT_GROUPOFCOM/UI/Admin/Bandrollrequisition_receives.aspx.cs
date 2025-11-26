using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class Bandrollrequisition_receives : Page, IRequiresSessionState
    {
        private AddItemBLL objItemBLL = new AddItemBLL();

    

        public Bandrollrequisition_receives()
        {
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validation())
                {
                    this.getCPDetailData();
                    this.loadMainGridView();
                    this.clearAll();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.clearAll();
            this.clearMasterAll();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.printBTN.Text != "Show Report")
                {
                    this.btnPrintReport.Visible = false;
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
            BandrollManagementBLL bandrollManagementBLL = new BandrollManagementBLL();
            BandrollIManagementMasterDAO bandrollIManagementMasterDAO = new BandrollIManagementMasterDAO();
            try
            {
                if (this.Mastervalidation())
                {
                    bandrollIManagementMasterDAO = this.fillCPMasterData(bandrollIManagementMasterDAO);
                    if (bandrollIManagementMasterDAO != null)
                    {
                        ArrayList item = (ArrayList)this.Session["CP_DETAIL_MAIN"];
                        if (item == null || item.Count == 0)
                        {
                            this.gvItem.DataSource = null;
                            this.gvItem.DataBind();
                            this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else if (!bandrollManagementBLL.insertBandrollReceiveData(bandrollIManagementMasterDAO, item))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Bandroll Register Receive Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.showReport();
                            this.clearMasterAll();
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
                BLL.Utility.InsertErrorTrackNew(exception.Message, "Bandroll_requisition.4", "btnSave_Click", fileLineNumber);
            }
        }

        private void clearAll()
        {
            this.lblavlQuantity.Text = "";
            this.drpFilterType.SelectedValue = "-99";
            this.drpStickType.SelectedValue = "-99";
            this.drpPacketType.SelectedValue = "-99";
            this.drpbrsdType.SelectedValue = "-99";
            this.drpFinishProduct.SelectedValue = "-99";
            this.drpdesignType.SelectedValue = "-99";
            this.txtPrice.Text = "";
            this.txtPQuantity.Text = "";
            this.txtRemarks.Text = "";
        }

        private void clearMasterAll()
        {
            this.drpProvidedChallan.SelectedValue = "-99";
            this.txtRefNo.Text = "";
            this.gvItem.DataSource = null;
            this.gvItem.DataBind();
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

        protected void drpFinishProduct_Click(object sender, EventArgs e)
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            long num = Convert.ToInt64(this.drpFinishProduct.SelectedValue);
            try
            {
                DataTable hsCodeByItemID = addItemBLL.GetHsCodeByItemID(num);
                if (hsCodeByItemID.Rows.Count > 0 && hsCodeByItemID != null)
                {
                    if (!hsCodeByItemID.Rows[0]["hs_code"].ToString().EndsWith("90.00"))
                    {
                        this.drpFilterType.Enabled = false;
                        this.PacketLabel.Attributes.Add("Class", "control-label col-sm-5 rqrd");
                    }
                    else
                    {
                        this.drpFilterType.Enabled = true;
                        this.PacketLabel.Attributes.Add("Class", "control-label col-sm-5");
                    }
                }
                this.LoadFinishProductIngredients();
                this.Session["hs_code"] = hsCodeByItemID.Rows[0]["hs_code"].ToString();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpProvidedChallan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpProvidedChallan.SelectedValue != "-99")
            {
                int num = 0;
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = Convert.ToInt16(this.drpProvidedChallan.SelectedValue);
                DataTable dataTable = this.objItemBLL.GetallBandrollrequisitionChallan(num4);
                if (dataTable.Rows.Count > 0)
                {
                    num = Convert.ToInt16(dataTable.Rows[0]["item_id"]);
                    this.drpFinishProduct.SelectedValue = dataTable.Rows[0]["item_id"].ToString();
                    if (dataTable.Rows[0]["property_id1"].ToString() != "")
                    {
                        this.drpFilterType.SelectedValue = dataTable.Rows[0]["property_id1"].ToString();
                    }
                    this.drpStickType.SelectedValue = dataTable.Rows[0]["property_id2"].ToString();
                    this.drpbrsdType.SelectedValue = dataTable.Rows[0]["property_id3"].ToString();
                    if (dataTable.Rows[0]["property_id4"].ToString() != "")
                    {
                        this.drpPacketType.SelectedValue = dataTable.Rows[0]["property_id4"].ToString();
                    }
                    this.drpdesignType.SelectedValue = dataTable.Rows[0]["property_id5"].ToString();
                    num1 = Convert.ToDecimal(dataTable.Rows[0]["quantity"]);
                }
                DataTable dataTable1 = this.objItemBLL.GetallBandrollreceiveQuantity(num, num4);
                if (dataTable1.Rows.Count > 0)
                {
                    num2 = Convert.ToDecimal(dataTable1.Rows[0]["quantity"]);
                }
                num3 = num1 - num2;
                this.lblavlQuantity.Text = num3.ToString();
            }
        }

        private BandrollIManagementMasterDAO fillCPMasterData(BandrollIManagementMasterDAO objCPMaster)
        {
            try
            {
                int num = Convert.ToInt32(this.Session["Organization_Id"]);
                Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
                DateTime dateTime = DateTime.Parse(this.txtRefDate.Text.ToString());
                objCPMaster.Date_challan = dateTime;
                objCPMaster.Organization_id = num;
                objCPMaster.Challan_no = this.txtRefNo.Text;
                objCPMaster.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
                objCPMaster.Providedchallan_id = Convert.ToInt16(this.drpProvidedChallan.SelectedValue);
                objCPMaster.OrgName = this.Session["ORGANIZATION_NAME"].ToString();
                objCPMaster.OrgAddress = this.Session["ORGANIZATION_ADDRESS"].ToString();
                objCPMaster.Month = dateTime.ToString("MMMM");
                this.Session["MASTER_DATA"] = objCPMaster;
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

        private void fillPropertyTypeDropDownLists()
        {
            BLL.Utility.FillPropertyTypeDropDownListBandRoll(this.drpStickType, Convert.ToInt16(AllConstraint.PropertyTypeM), Convert.ToInt16(AllConstraint.PropertyTypeD_Stick));
            BLL.Utility.FillPropertyTypeDropDownListBandRoll(this.drpPacketType, Convert.ToInt16(AllConstraint.PropertyTypeM), Convert.ToInt16(AllConstraint.PropertyTypeD_Packet_Type));
            BLL.Utility.FillPropertyTypeDropDownListBandRoll(this.drpbrsdType, Convert.ToInt16(AllConstraint.PropertyTypeM), Convert.ToInt16(AllConstraint.PropertyTypeD_Bandroll));
            BLL.Utility.FillPropertyTypeDropDownListBandRoll(this.drpdesignType, Convert.ToInt16(AllConstraint.PropertyTypeM), Convert.ToInt16(AllConstraint.PropertyTypeD_Design));
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

        private void getCPDetailData()
        {
            ArrayList item = (ArrayList)this.Session["CP_DETAIL_MAIN"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            BandrollIManagementDAO bandrollIManagementDAO = new BandrollIManagementDAO()
            {
                Row_No = num,
                BrandName = this.drpFinishProduct.SelectedItem.ToString(),
                Item_id = Convert.ToInt32(this.drpFinishProduct.SelectedValue)
            };
            if (!(this.drpFilterType.SelectedValue != "-99") || !(this.drpFilterType.SelectedValue != ""))
            {
                bandrollIManagementDAO.Property_id1 = 0;
            }
            else
            {
                bandrollIManagementDAO.Property_id1 = Convert.ToInt16(this.drpFilterType.SelectedValue);
                bandrollIManagementDAO.Property1_Text = this.drpFilterType.SelectedItem.ToString();
            }
            if (!(this.drpStickType.SelectedValue != "-99") || !(this.drpStickType.SelectedValue != ""))
            {
                bandrollIManagementDAO.Property_id2 = 0;
            }
            else
            {
                bandrollIManagementDAO.Property_id2 = Convert.ToInt16(this.drpStickType.SelectedValue);
                bandrollIManagementDAO.Property2_Text = this.drpStickType.SelectedItem.ToString();
            }
            if (!(this.drpbrsdType.SelectedValue != "-99") || !(this.drpbrsdType.SelectedValue != ""))
            {
                bandrollIManagementDAO.Property_id3 = 0;
            }
            else
            {
                bandrollIManagementDAO.Property_id3 = Convert.ToInt16(this.drpbrsdType.SelectedValue);
                bandrollIManagementDAO.Property3_Text = this.drpbrsdType.SelectedItem.ToString();
            }
            if (!(this.drpPacketType.SelectedValue != "-99") || !(this.drpPacketType.SelectedValue != ""))
            {
                bandrollIManagementDAO.Property_id4 = 0;
                bandrollIManagementDAO.Property4_Text = string.Concat(this.drpStickType.SelectedItem.ToString(), ' ', this.drpdesignType.SelectedItem.ToString());
            }
            else
            {
                bandrollIManagementDAO.Property_id4 = Convert.ToInt16(this.drpPacketType.SelectedValue);
                bandrollIManagementDAO.Property4_Text = this.drpPacketType.SelectedItem.ToString();
            }
            if (!(this.drpdesignType.SelectedValue != "-99") || !(this.drpdesignType.SelectedValue != ""))
            {
                bandrollIManagementDAO.Property_id5 = 0;
            }
            else
            {
                bandrollIManagementDAO.Property_id5 = Convert.ToInt16(this.drpdesignType.SelectedValue);
                bandrollIManagementDAO.Property5_Text = this.drpdesignType.SelectedItem.ToString();
            }
            bandrollIManagementDAO.Quantity = Convert.ToDecimal(this.txtPQuantity.Text);
            bandrollIManagementDAO.BandrollAdjAmount = Convert.ToDecimal(this.txtPrice.Text);
            bandrollIManagementDAO.Remark = (!string.IsNullOrEmpty(this.txtRemarks.Text) ? this.txtRemarks.Text : "");
            bandrollIManagementDAO.User_id_insert = Convert.ToInt16(this.Session["employee_id"]);
            item.Add(bandrollIManagementDAO);
            this.Session["ITEM_ID"] = bandrollIManagementDAO.Item_id;
            this.Session["CP_DETAIL_MAIN"] = item;
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        private void LoadFinishProduct()
        {
            try
            {
                DataTable finishGoodsProductionBiriCigarate = this.objItemBLL.GetFinishGoodsProductionBiriCigarate();
                this.drpFinishProduct.DataSource = finishGoodsProductionBiriCigarate;
                this.drpFinishProduct.DataTextField = finishGoodsProductionBiriCigarate.Columns["item_name"].ToString();
                this.drpFinishProduct.DataValueField = finishGoodsProductionBiriCigarate.Columns["Item_id"].ToString();
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
        }

        private void LoadHours()
        {
            this.drpChDtHr.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
            }
        }

        private void loadMainGridView()
        {
            try
            {
                this.gvItem.DataSource = this.Session["CP_DETAIL_MAIN"];
                this.gvItem.DataBind();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "BandrollManagement", "loadMainGridView", fileLineNumber);
            }
        }

        private void LoadMinutes()
        {
            this.drpChDtMin.Items.Add("00");
            for (int i = 1; i <= 59; i++)
            {
                this.drpChDtMin.Items.Add(i.ToString("00"));
            }
        }

        private void LoadProvidedChallan()
        {
            try
            {
                DataTable bandrollrequisitionChallan = this.objItemBLL.GetBandrollrequisitionChallan();
                this.drpProvidedChallan.DataSource = bandrollrequisitionChallan;
                this.drpProvidedChallan.DataTextField = bandrollrequisitionChallan.Columns["challan_no"].ToString();
                this.drpProvidedChallan.DataValueField = bandrollrequisitionChallan.Columns["challan_id"].ToString();
                this.drpProvidedChallan.DataBind();
                ListItem listItem = new ListItem("---SELECT---", "-99");
                this.drpProvidedChallan.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private bool Mastervalidation()
        {
            if (this.txtRefNo.Text != "")
            {
                return true;
            }
            this.msgBox.AddMessage("Enter  Reference No", MsgBoxs.enmMessageType.Attention);
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!base.IsPostBack)
                {
                    this.Session["CP_DETAIL_MAIN"] = new ArrayList();
                    this.Session["MASTER_DATA"] = "";
                    this.org_name.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                    this.org_address.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.fillPropertyTypeDropDownLists();
                    this.LoadFinishProduct();
                    this.txtRefDate.Text = DateTime.Today.Date.ToShortDateString();
                    this.LoadMinutes();
                    this.LoadHours();
                    this.GetBranchInformation();
                    this.LoadProvidedChallan();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                base.Response.Redirect("~/LogIn.aspx");
                exception.ToString();
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
                BandrollIManagementMasterDAO item = (BandrollIManagementMasterDAO)this.Session["MASTER_DATA"];
                ArrayList arrayLists = (ArrayList)this.Session["CP_DETAIL_MAIN"];
                BandrollIManagementDAO bandrollIManagementDAO = new BandrollIManagementDAO();
                string str = "";
                this.savedRefNo.Text = item.Challan_no;
                this.savedRefDate.Text = item.Date_challan.ToString("dd/MM/yyyy");
                this.savedRefMonth.Text = item.Month;
                DateTime dateChallan = item.Date_challan;
                int num = Convert.ToInt16(dateChallan.ToString("MM"));
                string str1 = "";
                if (num <= 6)
                {
                    DateTime dateTime = item.Date_challan;
                    object obj = Convert.ToInt16(dateTime.ToString("yy")) - 1 + 45;
                    DateTime dateChallan1 = item.Date_challan;
                    str1 = string.Concat(obj, dateChallan1.ToString("yy"));
                }
                else
                {
                    string str2 = item.Date_challan.ToString("yy");
                    object obj1 = '-';
                    DateTime dateTime1 = item.Date_challan;
                    str1 = string.Concat(str2, obj1, Convert.ToInt16(dateTime1.ToString("yy")) + 1);
                }
                this.savedRefYear.Text = str1;
                for (int i = 0; i < arrayLists.Count; i++)
                {
                    string str3 = i.ToString();
                    string str4 = str3.Replace(strArrays1[i], strArrays3[i]);
                    bandrollIManagementDAO = (BandrollIManagementDAO)arrayLists[i];
                    str = string.Concat(str, "<tr>");
                    str = string.Concat(str, "<td style='border:1px solid gray'>", str4, "</td>");
                    str = string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", bandrollIManagementDAO.BrandName, "</td>");
                    str = string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", bandrollIManagementDAO.Property4_Text, "</td>");
                    str = string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", bandrollIManagementDAO.Property3_Text, "</td>");
                    object obj2 = str;
                    object[] quantity = new object[] { obj2, "<td style='text-align:center;border:1px solid gray'>", bandrollIManagementDAO.Quantity, " </td>" };
                    str = string.Concat(quantity);
                    object obj3 = str;
                    object[] bandrollAdjAmount = new object[] { obj3, "<td style='text-align:right;border:1px solid gray'>", bandrollIManagementDAO.BandrollAdjAmount, " </td>" };
                    str = string.Concat(bandrollAdjAmount);
                    str = (bandrollIManagementDAO.Remark != "" ? string.Concat(str, "<td style='text-align:left;border:1px solid gray'>", bandrollIManagementDAO.Remark, "</td>") : string.Concat(str, "<td style='text-align:left;border:1px solid gray'>-</td>"));
                    str = string.Concat(str, "</tr>");
                    this.HaiMan.Text = str;
                }
                this.lblDutyOfficer.Text = string.Concat(this.Session["EMPLOYEE_NAME"].ToString(), ' ', this.Session["DESIGNATION_NAME"].ToString());
                this.orgNameAddress.Text = string.Concat(item.OrgName, " ", item.OrgAddress);
                this.orgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                this.btnPrintReport.Visible = true;
                this.cpPrint.Visible = true;
                this.printBTN.Text = "Hide Report";
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private bool validation()
        {
            if (this.drpFinishProduct.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select Finish Product", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpStickType.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select Stick Type", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpbrsdType.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select Band-roll & Stamp", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtPQuantity.Text == "")
            {
                this.msgBox.AddMessage("Enter Quantity", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpFinishProduct.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Select Finish Product", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtPrice.Text != "")
            {
                return true;
            }
            this.msgBox.AddMessage("Enter Bandroll Adjustment", MsgBoxs.enmMessageType.Attention);
            return false;
        }
    }
}