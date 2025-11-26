using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Globalization;
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

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class Item_Tax_Values_Setup : System.Web.UI.Page, IRequiresSessionState  
    {
        private ItemTaxCategoryBLL objITCBLL = new ItemTaxCategoryBLL();

        private ItemTaxValueBLL objITVBLL = new ItemTaxValueBLL();

        private ItemTaxValueDAO objITVDAO = new ItemTaxValueDAO();

        private TaxValuesDAO objTaxVal = new TaxValuesDAO();

        private DBUtility dbUtility = new DBUtility();

        private double dblTaxValue;

        private bool result;

        private SaleBLL objBLL = new SaleBLL();

        public ArrayList objectPropertyNameList = new ArrayList();

        public ArrayList tableDataList = new ArrayList();

        public ArrayList tableNameList = new ArrayList();

        public ArrayList validationList = new ArrayList();

        public short status = 1;

        private string tran_type = "";

        private bool ifExists;

        private bool ifPerExists;

        private bool ifLimitExists;

        private bool isPercentage;

        private bool isPer;

        private bool isLimit;

 


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

        public Item_Tax_Values_Setup()
        {
        }

        protected void btnExcelSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnExcelSave.Visible = false;
                ArrayList arrayLists = new ArrayList();
                arrayLists = (ArrayList)this.Session["Tax_EXCEL"];
                List<bool> flags = new List<bool>();
                int num = 0;
                foreach (ItemTaxValueDAO arrayList in arrayLists)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        arrayList.DateOfEffective = Convert.ToDateTime(arrayList.effectiveDate);
                        if (i == 0)
                        {
                            arrayList.TaxID = arrayList.CDId;
                            arrayList.TaxValue = arrayList.CD;
                        }
                        if (i == 1)
                        {
                            arrayList.TaxID = arrayList.RDId;
                            arrayList.TaxValue = arrayList.RD;
                        }
                        if (i == 2)
                        {
                            arrayList.TaxID = arrayList.SDId;
                            arrayList.TaxValue = arrayList.SD;
                        }
                        if (i == 3)
                        {
                            arrayList.TaxID = arrayList.VATId;
                            arrayList.TaxValue = arrayList.VAT;
                        }
                        if (i == 4)
                        {
                            arrayList.TaxID = arrayList.AITId;
                            arrayList.TaxValue = arrayList.AIT;
                        }
                        if (i == 5)
                        {
                            arrayList.TaxID = arrayList.ATId;
                            arrayList.TaxValue = arrayList.AT;
                        }
                        if (arrayList.TaxValue != 0)
                        {
                            this.result = this.objITVBLL.insertInsertItemTaxValue(arrayList, true);
                        }
                        else if (arrayList.TaxValue == 0)
                        {
                            this.result = this.objITVBLL.insertInsertItemTaxValue(arrayList, false);
                        }
                    }
                    num++;
                    flags.Add(this.result);
                }
                int num1 = flags.Count<bool>((bool t) => t);
                flags.Count<bool>((bool t) => !t);
                if (num1 > 0)
                {
                    this.msgBox.AddMessage(string.Concat(num1, " Tax Rate informations are Successfully Saved."), MsgBoxs.enmMessageType.Success);
                }
                this.gvExcelFile.DataSource = null;
                this.gvExcelFile.DataBind();
            }
            catch (Exception exception)
            {
                 BLL.Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "btnExcelSave_Click");
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.gvItemTaxValues.DataSource = null;
            this.gvItemTaxValues.DataBind();
            this.gvItemTaxValues.Visible = false;
            this.btnShowList.Text = "Show Item Tax List";
            this.dgvCountry.DataSource = null;
            this.dgvCountry.DataBind();
            this.dgvCountry.Visible = false;
            this.setAddMode();
            this.txtUnitName.Visible = false;
            this.txtUnitName.Text = string.Empty;
            this.drpTransactionType.SelectedValue = "0";
            this.LoadItemsWithoutFilter();
            this.drpSubCategory.Items.Clear();
            OrganizaitonInfo.fillDDLAllCategoryName(this.ddlCategory);
            this.ShowGridviewPer();
            this.ShowGridviewLimit();
            this.ClearGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            double num = 0;
            double num1 = 0;
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            try
            {
                if (this.Validation())
                {
                    ArrayList arrayLists = new ArrayList();
                    bool flag = false;
                    bool flag1 = false;
                    bool flag2 = false;
                    bool flag3 = false;
                    bool flag4 = false;
                    double num4 = 0;
                    double num5 = 0;
                    double num6 = 0;
                    double num7 = 0;
                    bool flag5 = false;
                    double num8 = 0;
                    if (this.drpTransactionType.SelectedValue == "1")
                    {
                        flag2 = true;
                        this.tran_type = "is_tran_import";
                    }
                    if (this.drpTransactionType.SelectedValue == "2")
                    {
                        flag1 = true;
                        this.tran_type = "is_tran_local";
                    }
                    if (this.drpTransactionType.SelectedValue == "3")
                    {
                        flag3 = true;
                        this.tran_type = "is_tran_sale";
                    }
                    if (this.drpTransactionType.SelectedValue == "4")
                    {
                        flag4 = true;
                        this.tran_type = "is_trade_price";
                    }
                    if (this.btnSave.Text == "Save")
                    {
                        string str = this.Session["hsCode"].ToString();
                        if (str == "2402.20.00" || str == "2402.90.00" || str == "2403.99.00")
                        {
                            TextBox textBox = (TextBox)this.grdTobacco.Rows[0].FindControl("txtUpperLimit");
                            num6 = Convert.ToDouble(textBox.Text);
                            TextBox textBox1 = (TextBox)this.grdTobacco.Rows[0].FindControl("txtLowerLimit");
                            num5 = Convert.ToDouble(textBox1.Text);
                            TextBox textBox2 = (TextBox)this.grdTobacco.Rows[0].FindControl("txtQuantity");
                            num7 = Convert.ToDouble(textBox2.Text);
                            TextBox textBox3 = (TextBox)this.grdTobacco.Rows[0].FindControl("txtSDQuantity");
                            Convert.ToDouble(textBox3.Text);
                            this.ifLimitExists = this.objITVBLL.CheckLimitVatExists(Convert.ToInt32(this.ddlItemName.SelectedItem.Value), this.tran_type);
                            if (!this.ifLimitExists)
                            {
                                for (int i = 0; i < this.grdTobacco.Rows.Count; i++)
                                {
                                    TextBox textBox4 = (TextBox)this.grdTobacco.Rows[i].FindControl("txtQuantity");
                                    TextBox textBox5 = (TextBox)this.grdTobacco.Rows[i].FindControl("txtSDQuantity");
                                    TextBox textBox6 = (TextBox)this.grdTobacco.Rows[i].FindControl("txtUpperLimit");
                                    TextBox textBox7 = (TextBox)this.grdTobacco.Rows[i].FindControl("txtLowerLimit");
                                    int num9 = (!string.IsNullOrEmpty(this.drpLevel.SelectedValue) ? (int)Convert.ToInt16(this.drpLevel.SelectedValue) : 0);
                                    int num10 = (!string.IsNullOrEmpty(this.drpPacketType.SelectedValue) ? (int)Convert.ToInt16(this.drpPacketType.SelectedValue) : 0);
                                    double num11 = (!string.IsNullOrEmpty(this.txthealthSurcharge.Text) ? Convert.ToDouble(this.txthealthSurcharge.Text) : 0);
                                    if (textBox4.Text != string.Empty)
                                    {
                                        this.dblTaxValue = Convert.ToDouble(textBox4.Text);
                                        num = Convert.ToDouble(textBox6.Text);
                                        num1 = Convert.ToDouble(textBox7.Text);
                                        num8 = Convert.ToDouble(textBox5.Text);
                                        if (this.dblTaxValue != 0)
                                        {
                                            this.insertInsertItemTaxValueLimitTobacco(this.dblTaxValue, num1, num, num9, num10, num11, num8);
                                            ArrayList item = new ArrayList();
                                            item = (ArrayList)this.Session["CP_DETAIL_MAIN"];
                                            this.result = this.objITVBLL.insertInsertItemTaxValueLimitTobacco(item, true);
                                            if (this.result)
                                            {
                                                this.ShowGridviewLimitTobacco();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                this.msgBox.AddMessage("Already exists vat information for this item in such combination", MsgBoxs.enmMessageType.Error);
                                return;
                            }
                        }
                        else
                        {
                            int num12 = 0;
                            while (num12 < this.dgvItemTaxCategoryFalse.Rows.Count)
                            {
                                DataTable dataTable = this.objITVBLL.LoadUniqueValue(Convert.ToInt32(this.ddlItemName.SelectedItem.Value), Convert.ToInt32(this.dgvItemTaxCategoryFalse.DataKeys[num12].Values["tax_id"]), this.txtDate.Text.ToString(), flag2, flag1, flag3, flag4);
                                if (dataTable == null || dataTable.Rows.Count <= 0)
                                {
                                    num12++;
                                }
                                else
                                {
                                    this.msgBox.AddMessage("Tax Values of Item InformationSame combination of data already exist(item,tax value,Effective Date)", MsgBoxs.enmMessageType.Error);
                                    flag = true;
                                    return;
                                }
                            }
                            try
                            {
                                TextBox textBox8 = (TextBox)this.dgvItemTaxPer.Rows[0].FindControl("txtQuantity");
                                num4 = Convert.ToDouble(textBox8.Text);
                                TextBox textBox9 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtQuantity");
                                num7 = Convert.ToDouble(textBox9.Text);
                                TextBox textBox10 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtUpperLimit");
                                num6 = Convert.ToDouble(textBox10.Text);
                                TextBox textBox11 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtLowerLimit");
                                num5 = Convert.ToDouble(textBox11.Text);
                            }
                            catch (Exception exception)
                            {
                                 BLL.Utility.InsertErrorTrack(exception.Message, "SetItem.aspx", "gvItem_PreRender");
                            }
                            if (!flag)
                            {
                                int num13 = 0;
                                while (num13 < this.dgvItemTaxCategoryFalse.Rows.Count)
                                {
                                    double num14 = 0;
                                    TextBox textBox12 = (TextBox)this.dgvItemTaxCategoryFalse.Rows[num13].FindControl("txtTaxVavue");
                                    num14 = (textBox12.Text == "" ? 0 : Convert.ToDouble(textBox12.Text));
                                    if (num14 <= 0)
                                    {
                                        num13++;
                                    }
                                    else
                                    {
                                        flag5 = true;
                                        break;
                                    }
                                }
                                if (num4 <= 0 || num7 <= 0 || num6 <= 0 || num5 <= 0)
                                {
                                    for (int j = 0; j < this.dgvItemTaxCategoryFalse.Rows.Count; j++)
                                    {
                                        int num15 = Convert.ToInt32(this.dgvItemTaxCategoryFalse.DataKeys[j].Values["tax_id"]);
                                        TextBox str1 = (TextBox)this.dgvItemTaxCategoryFalse.Rows[j].FindControl("txtTaxVavue");
                                        if (str1.Text == "")
                                        {
                                            str1.Text = 0.ToString();
                                        }
                                        if (str1.Text != string.Empty)
                                        {
                                            this.dblTaxValue = Convert.ToDouble(str1.Text);
                                            if (this.dblTaxValue != 0)
                                            {
                                                this.objITVDAO = this.insertInsertItemTaxValue(this.objITVDAO, num15, this.dblTaxValue);
                                                this.result = this.objITVBLL.insertInsertItemTaxValue(this.objITVDAO, true);
                                            }
                                            else if (this.dblTaxValue == 0)
                                            {
                                                this.objITVDAO = this.insertInsertItemTaxValue(this.objITVDAO, num15, this.dblTaxValue);
                                                this.result = this.objITVBLL.insertInsertItemTaxValue(this.objITVDAO, false);
                                            }
                                        }
                                    }
                                    if (num7 <= 0 || num6 <= 0 || num5 <= 0 || !flag5)
                                    {
                                        this.ifPerExists = this.objITVBLL.CheckPerVatExists(Convert.ToInt32(this.ddlItemName.SelectedItem.Value), this.tran_type);
                                        if (!this.ifPerExists)
                                        {
                                            for (int k = 0; k < this.dgvItemTaxPer.Rows.Count; k++)
                                            {
                                                TextBox textBox13 = (TextBox)this.dgvItemTaxPer.Rows[k].FindControl("txtQuantity");
                                                TextBox textBox14 = (TextBox)this.dgvItemTaxPer.Rows[k].FindControl("txtPer");
                                                if (textBox13.Text != string.Empty)
                                                {
                                                    this.dblTaxValue = Convert.ToDouble(textBox13.Text);
                                                    empty = textBox14.Text;
                                                    if (this.dblTaxValue == 0)
                                                    {
                                                        double num16 = this.dblTaxValue;
                                                    }
                                                    else
                                                    {
                                                        this.objITVDAO = this.insertInsertItemTaxValuePer(this.objITVDAO, this.dblTaxValue, empty);
                                                        this.result = this.objITVBLL.insertInsertItemTaxValuePer(this.objITVDAO, true);
                                                    }
                                                }
                                            }
                                            if (num4 <= 0 && !flag5)
                                            {
                                                this.ifLimitExists = this.objITVBLL.CheckLimitVatExists(Convert.ToInt32(this.ddlItemName.SelectedItem.Value), this.tran_type);
                                                if (!this.ifLimitExists)
                                                {
                                                    for (int l = 0; l < this.dgvItemLimit.Rows.Count; l++)
                                                    {
                                                        TextBox textBox15 = (TextBox)this.dgvItemLimit.Rows[l].FindControl("txtQuantity");
                                                        TextBox textBox16 = (TextBox)this.dgvItemLimit.Rows[l].FindControl("txtUpperLimit");
                                                        TextBox textBox17 = (TextBox)this.dgvItemLimit.Rows[l].FindControl("txtLowerLimit");
                                                        int num17 = (!string.IsNullOrEmpty(this.drpLevel.SelectedValue) ? (int)Convert.ToInt16(this.drpLevel.SelectedValue) : 0);
                                                        int num18 = (!string.IsNullOrEmpty(this.drpPacketType.SelectedValue) ? (int)Convert.ToInt16(this.drpPacketType.SelectedValue) : 0);
                                                        double num19 = (!string.IsNullOrEmpty(this.txthealthSurcharge.Text) ? Convert.ToDouble(this.txthealthSurcharge.Text) : 0);
                                                        if (textBox15.Text != string.Empty)
                                                        {
                                                            this.dblTaxValue = Convert.ToDouble(textBox15.Text);
                                                            num = Convert.ToDouble(textBox16.Text);
                                                            num1 = Convert.ToDouble(textBox17.Text);
                                                            if (this.dblTaxValue == 0)
                                                            {
                                                                double num20 = this.dblTaxValue;
                                                            }
                                                            else
                                                            {
                                                                this.objITVDAO = this.insertInsertItemTaxValueLimit(this.objITVDAO, this.dblTaxValue, num1, num, num17, num18, num19);
                                                                this.result = this.objITVBLL.insertInsertItemTaxValueLimit(this.objITVDAO, true);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    this.msgBox.AddMessage("Already exists vat information for this item in such combination", MsgBoxs.enmMessageType.Error);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.msgBox.AddMessage("Already exists vat information for this item in such combination", MsgBoxs.enmMessageType.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        this.msgBox.AddMessage("Multiple combination not valid for an item", MsgBoxs.enmMessageType.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    this.msgBox.AddMessage("Multiple combination not valid for an item", MsgBoxs.enmMessageType.Error);
                                    return;
                                }
                            }
                            if (!this.result)
                            {
                                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                            else
                            {
                                this.msgBox.AddMessage("Tax Values of Item Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                this.txtUnitName.Visible = false;
                                this.dgvCountry.DataSource = null;
                                this.dgvCountry.DataBind();
                                this.showDataInGridView();
                                this.ShowGridviewPer();
                                this.ShowGridviewLimit();
                                this.drpTransactionType.ClearSelection();
                                if (this.isPercentage)
                                {
                                    this.showTaxInGridView();
                                    this.dgvCountry.Visible = true;
                                }
                                if (this.isPer)
                                {
                                    this.ShowTaxInGridViewPer();
                                    this.GridViewPer.Visible = true;
                                }
                                if (this.isLimit)
                                {
                                    this.ShowTaxInGridViewLimit();
                                    this.GridViewUpperLower.Visible = true;
                                }
                            }
                        }
                    }
                    if (this.btnSave.Text == "Update")
                    {
                        int num21 = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
                        GridViewRow selectedRow = this.dgvCountry.SelectedRow;
                        GridViewRow gridViewRow = this.GridViewPer.SelectedRow;
                        if (gridViewRow != null)
                        {
                            short num22 = Convert.ToInt16(this.GridViewPer.DataKeys[gridViewRow.RowIndex].Value);
                            if (this.objITVBLL.LoadinsertDateValue(num22).Rows.Count > 0)
                            {
                                for (int m = 0; m < this.dgvItemTaxPer.Rows.Count; m++)
                                {
                                    int num23 = Convert.ToInt32(this.dgvItemTaxPer.DataKeys[m].Values["tax_id"]);
                                    TextBox textBox18 = (TextBox)this.dgvItemTaxPer.Rows[m].FindControl("txtQuantity");
                                    Convert.ToDecimal(textBox18.Text);
                                    TextBox textBox19 = (TextBox)this.dgvItemTaxPer.Rows[m].FindControl("txtPer");
                                    string str2 = Convert.ToString(textBox19.Text);
                                    DateTime.ParseExact(this.txtDate.Text.ToString(), "dd/MM/yyyy", null);
                                    DateTime dateTime = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
                                    if (textBox18.Text != string.Empty)
                                    {
                                        this.dblTaxValue = Convert.ToDouble(textBox18.Text);
                                        this.result = this.objITVBLL.UpdteItemTaxValuesPer(num22, num23, str2, this.dblTaxValue, dateTime, num21, flag1, flag2, flag3, flag4);
                                        if (!this.result)
                                        {
                                            this.msgBox.AddMessage("Update Faied.", MsgBoxs.enmMessageType.Error);
                                            return;
                                        }
                                        else if (this.result)
                                        {
                                            this.msgBox.AddMessage("Updated Successfully.", MsgBoxs.enmMessageType.Success);
                                            this.btnShowList.Text = "Show Item Tax List";
                                            this.btnSave.Text = "Save";
                                            this.btnSave.Style.Add("background-color", "#0D7B78");
                                            this.ShowTaxInGridViewPer();
                                        }
                                    }
                                }
                            }
                        }
                        GridViewRow selectedRow1 = this.GridViewUpperLower.SelectedRow;
                        if (selectedRow1 != null)
                        {
                            short num24 = Convert.ToInt16(this.GridViewUpperLower.DataKeys[selectedRow1.RowIndex].Value);
                            if (this.objITVBLL.LoadinsertDateValue(num24).Rows.Count > 0)
                            {
                                for (int n = 0; n < this.dgvItemLimit.Rows.Count; n++)
                                {
                                    int num25 = Convert.ToInt32(this.dgvItemLimit.DataKeys[n].Values["tax_id"]);
                                    TextBox textBox20 = (TextBox)this.dgvItemLimit.Rows[n].FindControl("txtLowerLimit");
                                    TextBox textBox21 = (TextBox)this.dgvItemLimit.Rows[n].FindControl("txtUpperLimit");
                                    TextBox textBox22 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtQuantity");
                                    double num26 = Convert.ToDouble(textBox22.Text);
                                    Convert.ToDecimal(textBox20.Text);
                                    Convert.ToDecimal(textBox21.Text);
                                    DateTime.ParseExact(this.txtDate.Text.ToString(), "dd/MM/yyyy", null);
                                    DateTime dateTime1 = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
                                    if (textBox20.Text != string.Empty && textBox21.Text != string.Empty)
                                    {
                                        num3 = Convert.ToDecimal(textBox20.Text);
                                        num2 = Convert.ToDecimal(textBox21.Text);
                                        this.result = this.objITVBLL.UpdteItemTaxValuesLimit(num24, num25, num26, num2, num3, dateTime1, num21, flag1, flag2, flag3, flag4);
                                        if (!this.result)
                                        {
                                            this.msgBox.AddMessage("Update Faied.", MsgBoxs.enmMessageType.Error);
                                            return;
                                        }
                                        else if (this.result)
                                        {
                                            this.msgBox.AddMessage("Updated Successfully.", MsgBoxs.enmMessageType.Success);
                                            this.btnShowList.Text = "Show Item Tax List";
                                            this.btnSave.Text = "Save";
                                            this.ShowTaxInGridViewLimit();
                                        }
                                    }
                                }
                            }
                        }
                        GridViewRow gridViewRow1 = this.GridTobacco.SelectedRow;
                        if (gridViewRow1 != null)
                        {
                            short num27 = Convert.ToInt16(this.GridTobacco.DataKeys[gridViewRow1.RowIndex].Value);
                            if (this.objITVBLL.LoadinsertDateValue(num27).Rows.Count > 0)
                            {
                                for (int o = 0; o < this.grdTobacco.Rows.Count; o++)
                                {
                                    int num28 = Convert.ToInt32(this.grdTobacco.DataKeys[o].Values["tax_id"]);
                                    TextBox textBox23 = (TextBox)this.grdTobacco.Rows[o].FindControl("txtQuantity");
                                    TextBox textBox24 = (TextBox)this.grdTobacco.Rows[o].FindControl("txtSDQuantity");
                                    TextBox textBox25 = (TextBox)this.grdTobacco.Rows[o].FindControl("txtUpperLimit");
                                    TextBox textBox26 = (TextBox)this.grdTobacco.Rows[o].FindControl("txtLowerLimit");
                                    int num29 = (!string.IsNullOrEmpty(this.drpLevel.SelectedValue) ? (int)Convert.ToInt16(this.drpLevel.SelectedValue) : 0);
                                    if (!string.IsNullOrEmpty(this.drpPacketType.SelectedValue))
                                    {
                                        Convert.ToInt16(this.drpPacketType.SelectedValue);
                                    }
                                    double num30 = (!string.IsNullOrEmpty(this.txthealthSurcharge.Text) ? Convert.ToDouble(this.txthealthSurcharge.Text) : 0);
                                    if (textBox23.Text != string.Empty && textBox25.Text != string.Empty && textBox26.Text != string.Empty)
                                    {
                                        this.dblTaxValue = Convert.ToDouble(textBox23.Text);
                                        num = Convert.ToDouble(textBox25.Text);
                                        num1 = Convert.ToDouble(textBox26.Text);
                                        num8 = Convert.ToDouble(textBox24.Text);
                                        DateTime.ParseExact(this.txtDate.Text.ToString(), "dd/MM/yyyy", null);
                                        DateTime dateTime2 = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
                                        this.result = this.objITVBLL.UpdteItemTaxValuesLimitTobacco(num27, num28, this.dblTaxValue, num8, num29, num30, num2, num3, dateTime2, num21, flag1, flag2, flag3, flag4);
                                        if (!this.result)
                                        {
                                            this.msgBox.AddMessage("Update Faied.", MsgBoxs.enmMessageType.Error);
                                            return;
                                        }
                                        else if (this.result)
                                        {
                                            this.msgBox.AddMessage("Updated Successfully.", MsgBoxs.enmMessageType.Success);
                                            this.btnShowList.Text = "Show Item Tax List";
                                            this.btnSave.Text = "Save";
                                            this.ShowTaxInGridViewLimit();
                                        }
                                    }
                                }
                            }
                        }
                        if (selectedRow != null)
                        {
                            short num31 = Convert.ToInt16(this.dgvCountry.DataKeys[selectedRow.RowIndex].Value);
                            DataTable dataTable1 = this.objITVBLL.LoadinsertDateValue(num31);
                            if (dataTable1.Rows.Count > 0)
                            {
                                string str3 = dataTable1.Rows[0]["date_insert"].ToString();
                                Convert.ToDateTime(str3);
                                bool flag6 = false;
                                bool flag7 = false;
                                if (this.chkFxdCD.Checked)
                                {
                                    flag7 = true;
                                }
                                for (int p = 0; p < this.dgvItemTaxCategoryFalse.Rows.Count; p++)
                                {
                                    int num32 = Convert.ToInt32(this.dgvItemTaxCategoryFalse.DataKeys[p].Values["tax_id"]);
                                    TextBox textBox27 = (TextBox)this.dgvItemTaxCategoryFalse.Rows[p].FindControl("txtTaxVavue");
                                    DateTime.ParseExact(this.txtDate.Text.ToString(), "dd/MM/yyyy", null);
                                    DateTime dateTime3 = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
                                    if (textBox27.Text != string.Empty && Convert.ToDecimal(textBox27.Text) >= new decimal(0))
                                    {
                                        this.dblTaxValue = Convert.ToDouble(textBox27.Text);
                                        flag6 = this.objITVBLL.UpdteItemTaxValues(num31, num32, this.dblTaxValue, dateTime3, num21, flag1, flag2, flag3, flag4, flag7);
                                        if (!flag6)
                                        {
                                            this.msgBox.AddMessage("Update Faied.", MsgBoxs.enmMessageType.Error);
                                            return;
                                        }
                                    }
                                }
                                if (flag6)
                                {
                                    this.msgBox.AddMessage("Updated Successfully.", MsgBoxs.enmMessageType.Success);
                                    this.btnShowList.Text = "Show Item Tax List";
                                    this.txtUnitName.Visible = false;
                                    this.dgvCountry.DataSource = null;
                                    this.dgvCountry.DataBind();
                                    this.ClearGrid();
                                    this.txtDate.ReadOnly = false;
                                    this.btnSave.Text = "Save";
                                    this.showTaxInGridView();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                Exception exception1 = exception2;
                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                ReallySimpleLog.WriteLog(exception1);
            }
        }

        protected void btnShowList_Click(object sender, EventArgs e)
        {
            if (this.ddlCategory.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select a value from Category.", MsgBoxs.enmMessageType.Error);
                this.ddlCategory.Focus();
                return;
            }
            if (this.ddlItemName.Items.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Please select a value from sub Category.');", true);
                this.drpSubCategory.Focus();
            }
            else
            {
                if (this.btnShowList.Text == "Show Item Tax List")
                {
                    this.dgvCountry.SelectedIndex = -1;
                    this.gvItemTaxValues.DataSource = null;
                    this.gvItemTaxValues.DataBind();
                    this.gvItemTaxValues.Visible = false;
                    this.dgvCountry.Visible = false;
                    this.dgvCountry.DataSource = null;
                    this.dgvCountry.DataBind();
                    this.showTaxInGridView();
                    this.ShowTaxInGridViewPer();
                    this.ShowTaxInGridViewLimit();
                    if (this.dgvCountry.Rows.Count <= 0)
                    {
                        this.dgvCountry.Visible = false;
                    }
                    else
                    {
                        this.dgvCountry.Visible = true;
                    }
                    if (this.GridViewPer.Rows.Count <= 0)
                    {
                        this.GridViewPer.Visible = false;
                    }
                    else
                    {
                        this.GridViewPer.Visible = true;
                    }
                    if (this.GridViewPer.Rows.Count > 0)
                    {
                        this.GridViewUpperLower.Visible = true;
                        return;
                    }
                    this.GridViewUpperLower.Visible = true;
                    return;
                }
                if (this.btnShowList.Text == "Hide Item Tax List")
                {
                    this.dgvCountry.SelectedIndex = -1;
                    this.btnShowList.Text = "Show Item Tax List";
                    this.gvItemTaxValues.DataSource = null;
                    this.gvItemTaxValues.DataBind();
                    this.gvItemTaxValues.Visible = false;
                    this.dgvCountry.DataSource = null;
                    this.dgvCountry.DataBind();
                    this.dgvCountry.Visible = false;
                    this.setAddMode();
                    return;
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, bool> strs = new Dictionary<string, bool>();
                ArrayList arrayLists = new ArrayList();
                this.tableNameList = new ArrayList();
                this.objectPropertyNameList = new ArrayList();
                this.validationList = new ArrayList();
                this.gvExcelFile.DataSource = null;
                this.gvExcelFile.DataBind();
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "TaxRateSetup";
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
                    str2 = server.MapPath(string.Concat("~/CSV/partyImport_", now.ToString("ddMMyyyy_HHmmssFFF"), lower));
                    this.FileUpload1.SaveAs(str2);
                    this.Label33.Text = string.Concat(this.FileUpload1.FileName, "'s Data showing into the GridView");
                    try
                    {
                    
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
                    this.Session["Tax_EXCEL"] = arrayLists;
                }
            }
            catch (Exception exception3)
            {
                Exception exception2 = exception3;
                Utilities.KillExcelFileProcess();
                 BLL.Utility.InsertErrorTrack(exception2.Message, "LocalPurchase", "btnUpload_Click");
            }
            Utilities.KillExcelFileProcess();
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ClearGrid()
        {
            for (int i = 0; i < this.dgvItemTaxCategoryFalse.Rows.Count; i++)
            {
                Convert.ToInt32(this.dgvItemTaxCategoryFalse.DataKeys[i].Values["tax_id"]);
                TextBox textBox = (TextBox)this.dgvItemTaxCategoryFalse.Rows[i].FindControl("txtTaxVavue");
                textBox.Text = "0";
            }
            this.txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.drpSubCategory.Items.Clear();
                this.ddlItemName.Items.Clear();
                this.LoadItemsSubCategor();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvCountry.DataSource = null;
            this.GridViewPer.DataSource = null;
            this.GridViewUpperLower.DataSource = null;
            this.btnShowList.Text = "Show Item Tax List";
            this.dgvCountry.DataBind();
            this.GridViewPer.DataBind();
            this.GridViewUpperLower.DataBind();
            this.showDataInGridView();
            this.ShowGridviewPer();
            this.ShowGridviewLimit();
            this.dgvCountry.Visible = false;
            this.GridViewPer.Visible = false;
            this.GridViewUpperLower.Visible = false;
            try
            {
                if (this.ddlItemName.SelectedValue != "0")
                {
                    this.txtUnitName.Visible = true;
                    this.LoadItemHSCode();
                    this.LoadUnit();
                    this.showCatSubCat();
                }
                else if (this.ddlItemName.SelectedValue != "0")
                {
                    this.txtUnitName.Text = string.Empty;
                    this.txtUnitName.Visible = false;
                    this.dgvCountry.DataSource = null;
                    this.dgvCountry.DataBind();
                }
                else
                {
                    this.ddlCategory.Items.Clear();
                    this.LoadItemsWithoutFilter();
                    this.drpSubCategory.Items.Clear();
                    OrganizaitonInfo.fillDDLAllCategoryName(this.ddlCategory);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void dgvCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dgvCountry.PageIndex = e.NewPageIndex;
            this.dgvCountry.DataBind();
            this.showTaxInGridView();
        }

        protected void dgvCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.objITVBLL = new ItemTaxValueBLL();
                int num = Convert.ToInt32(this.dgvCountry.DataKeys[e.RowIndex].Value.ToString());
                if (!this.objITVBLL.deleteTaxValue(num))
                {
                    this.msgBox.AddMessage("Fail to delete.", MsgBoxs.enmMessageType.Error);
                }
                else
                {
                    this.msgBox.AddMessage("Successfully Deleted.", MsgBoxs.enmMessageType.Success);
                    this.showTaxInGridView();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void dgvCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Text = "Update";
            this.btnSave.Style.Add("background-color", "#f2b202");
            this.txtDate.ReadOnly = true;
            string text = this.dgvCountry.SelectedRow.Cells[13].Text;
            this.showTaxInGridViewBySelection(text);
        }

        protected void drpSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ddlItemName.Items.Clear();
                this.LoadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpTransactionType.SelectedValue != "4")
            {
                this.dgvItemTaxPer.Rows[0].Enabled = true;
                this.dgvItemLimit.Rows[0].Enabled = true;
                for (int i = 0; i < this.dgvItemTaxCategoryFalse.Rows.Count; i++)
                {
                    this.dgvItemTaxCategoryFalse.Rows[i].Enabled = true;
                }
                return;
            }
            TextBox textBox = (TextBox)this.dgvItemTaxPer.Rows[0].FindControl("txtQuantity");
            textBox.Text = "0";
            TextBox textBox1 = (TextBox)this.dgvItemTaxPer.Rows[0].FindControl("txtPer");
            textBox1.Text = "";
            this.dgvItemTaxPer.Rows[0].Enabled = false;
            TextBox textBox2 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtQuantity");
            textBox2.Text = "0";
            TextBox textBox3 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtUpperLimit");
            textBox3.Text = "0";
            TextBox textBox4 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtLowerLimit");
            textBox4.Text = "0";
            this.dgvItemLimit.Rows[0].Enabled = false;
            for (int j = 0; j < this.dgvItemTaxCategoryFalse.Rows.Count; j++)
            {
                if (j != 3)
                {
                    this.dgvItemTaxCategoryFalse.Rows[j].Enabled = false;
                }
            }
        }

        protected void GridViewPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Text = "Update";
            this.btnSave.Style.Add("background-color", "#f2b202");
            this.txtDate.ReadOnly = true;
            string text = this.GridViewPer.SelectedRow.Cells[6].Text;
            this.ShowTaxInGridViewBySelectionPer(text);
        }

        protected void GridViewUpperLower_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSave.Text = "Update";
            this.btnSave.Style.Add("background-color", "#f2b202");
            this.txtDate.ReadOnly = true;
            string text = this.GridViewUpperLower.SelectedRow.Cells[7].Text;
            this.ShowTaxInGridViewBySelectionLimit(text);
        }

        protected void gvExcelFile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            ItemTaxValueDAO dataItem = e.Row.DataItem as ItemTaxValueDAO;
            e.Row.RowIndex.ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hiddenField = e.Row.FindControl("rowNo") as HiddenField;
                Dictionary<string, bool> item = (Dictionary<string, bool>)this.validationList[Convert.ToInt32(hiddenField.Value)];
                foreach (string str in this.tableNameList)
                {
                    int num = this.tableNameList.IndexOf(str);
                    TableCell crimson = e.Row.Cells[num + 1];
                    if (this.objectPropertyNameList[num].ToString() == "Item")
                    {
                        if (crimson.Text == "" || crimson.Text == null || crimson.Text == "&nbsp;")
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Item Name Can not be Empty.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        else if (dataItem.ItemID == 0)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "This Item Name is not available.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                        else if ((new DataTable()).Rows.Count > 0)
                        {
                            crimson.BackColor = Color.Crimson;
                            e.Row.BackColor = Color.LightPink;
                            crimson.ToolTip = "Tax Rate is already exist for this Item.";
                            if (this.status == 1)
                            {
                                this.status = 0;
                            }
                        }
                    }
                    if (this.objectPropertyNameList[num].ToString() == "DateOfEffective" && (crimson.Text == "" || crimson.Text == null || crimson.Text == "&nbsp;"))
                    {
                        crimson.BackColor = Color.Crimson;
                        e.Row.BackColor = Color.LightPink;
                        crimson.ToolTip = " Effective Date Can not be Empty.";
                        if (this.status == 1)
                        {
                            this.status = 0;
                        }
                    }
                    if (!(this.objectPropertyNameList[num].ToString() == "trnsType") || !(crimson.Text.Trim() == "") && !(crimson.Text.Trim() == "&nbsp;") && !(crimson.Text.Trim() == "0"))
                    {
                        continue;
                    }
                    crimson.BackColor = Color.Crimson;
                    e.Row.BackColor = Color.LightPink;
                    crimson.ToolTip = "Transaction Type Can not be Empty.";
                    if (this.status != 1)
                    {
                        continue;
                    }
                    this.status = 0;
                }
                this.btnExcelSave.Visible = Convert.ToBoolean(this.status);
            }
        }

        private ItemTaxValueDAO insertInsertItemTaxValue(ItemTaxValueDAO objItemTaxValueDAO, int intTaxid, double dblTaxvalue)
        {
            objItemTaxValueDAO.ItemID = Convert.ToInt32(this.ddlItemName.SelectedItem.Value);
            objItemTaxValueDAO.TaxID = intTaxid;
            objItemTaxValueDAO.DateOfEffective = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
            objItemTaxValueDAO.TaxValue = dblTaxvalue;
            int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
            objItemTaxValueDAO.EmpID = num;
            objItemTaxValueDAO.Is_last_insert = true;
            objItemTaxValueDAO.IsAnnx = false;
            if (!this.chkFxdCD.Checked)
            {
                objItemTaxValueDAO.IsfxdCD = false;
            }
            else
            {
                objItemTaxValueDAO.IsfxdCD = true;
            }
            if (this.drpTransactionType.SelectedValue == "1")
            {
                objItemTaxValueDAO.TranImported = true;
            }
            if (this.drpTransactionType.SelectedValue == "2")
            {
                objItemTaxValueDAO.TranLocal = true;
            }
            if (this.drpTransactionType.SelectedValue == "3")
            {
                objItemTaxValueDAO.TranSale = true;
            }
            if (this.drpTransactionType.SelectedValue == "4")
            {
                objItemTaxValueDAO.TrantradePrice = true;
            }
            return objItemTaxValueDAO;
        }

        private ItemTaxValueDAO insertInsertItemTaxValueANNX(ItemTaxValueDAO objItemTaxValueDAO, int intTaxid)
        {
            objItemTaxValueDAO.ItemID = Convert.ToInt32(this.ddlItemName.SelectedItem.Value);
            objItemTaxValueDAO.TaxID = intTaxid;
            objItemTaxValueDAO.DateOfEffective = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
            objItemTaxValueDAO.TaxValue = 0;
            objItemTaxValueDAO.IsAnnx = true;
            return objItemTaxValueDAO;
        }

        private ItemTaxValueDAO insertInsertItemTaxValueforExcel(ItemTaxValueDAO objItemTaxValueDAO, int intTaxid, double dblTaxvalue)
        {
            objItemTaxValueDAO.ItemID = Convert.ToInt32(this.ddlItemName.SelectedItem.Value);
            objItemTaxValueDAO.TaxID = intTaxid;
            objItemTaxValueDAO.DateOfEffective = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
            objItemTaxValueDAO.TaxValue = dblTaxvalue;
            int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
            objItemTaxValueDAO.EmpID = num;
            objItemTaxValueDAO.Is_last_insert = true;
            objItemTaxValueDAO.IsAnnx = false;
            if (this.drpTransactionType.SelectedValue == "1")
            {
                objItemTaxValueDAO.TranImported = true;
            }
            if (this.drpTransactionType.SelectedValue == "2")
            {
                objItemTaxValueDAO.TranLocal = true;
            }
            if (this.drpTransactionType.SelectedValue == "3")
            {
                objItemTaxValueDAO.TranSale = true;
            }
            if (this.drpTransactionType.SelectedValue == "4")
            {
                objItemTaxValueDAO.TrantradePrice = true;
            }
            return objItemTaxValueDAO;
        }

        private ItemTaxValueDAO insertInsertItemTaxValueLimit(ItemTaxValueDAO objItemTaxValueDAO, double dblTaxvalue, double dLower, double dUpper, int levelId, int packet_category, double healthcharge)
        {
            objItemTaxValueDAO.ItemID = Convert.ToInt32(this.ddlItemName.SelectedItem.Value);
            objItemTaxValueDAO.DateOfEffective = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
            objItemTaxValueDAO.TaxValue = dblTaxvalue;
            objItemTaxValueDAO.dUpper = dUpper;
            objItemTaxValueDAO.dLower = dLower;
            objItemTaxValueDAO.LevelId = levelId;
            objItemTaxValueDAO.PacketId = packet_category;
            objItemTaxValueDAO.Healthcharge = healthcharge;
            int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
            objItemTaxValueDAO.EmpID = num;
            objItemTaxValueDAO.Is_last_insert = true;
            objItemTaxValueDAO.IsAnnx = true;
            objItemTaxValueDAO.TaxID = 999;
            if (this.drpTransactionType.SelectedValue == "1")
            {
                objItemTaxValueDAO.TranImported = true;
            }
            if (this.drpTransactionType.SelectedValue == "2")
            {
                objItemTaxValueDAO.TranLocal = true;
            }
            if (this.drpTransactionType.SelectedValue == "3")
            {
                objItemTaxValueDAO.TranSale = true;
            }
            if (this.drpTransactionType.SelectedValue == "4")
            {
                objItemTaxValueDAO.TrantradePrice = true;
            }
            return objItemTaxValueDAO;
        }

        private void insertInsertItemTaxValueLimitTobacco(double dblTaxvalue, double dLower, double dUpper, int levelId, int packet_category, double healthcharge, double SDValue)
        {
            ArrayList item = (ArrayList)this.Session["CP_DETAIL_MAIN"] ?? new ArrayList();
            for (int i = 0; i < 2; i++)
            {
                ItemTaxValueDAO itemTaxValueDAO = new ItemTaxValueDAO();
                if (i != 0)
                {
                    itemTaxValueDAO.ItemID = Convert.ToInt32(this.ddlItemName.SelectedItem.Value);
                    itemTaxValueDAO.DateOfEffective = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
                    itemTaxValueDAO.TaxValue = SDValue;
                    itemTaxValueDAO.dUpper = dUpper;
                    itemTaxValueDAO.dLower = dLower;
                    itemTaxValueDAO.LevelId = levelId;
                    itemTaxValueDAO.PacketId = packet_category;
                    itemTaxValueDAO.Healthcharge = healthcharge;
                    int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
                    itemTaxValueDAO.EmpID = num;
                    itemTaxValueDAO.Is_last_insert = true;
                    itemTaxValueDAO.IsAnnx = true;
                    itemTaxValueDAO.TaxID = 3;
                    if (this.drpTransactionType.SelectedValue == "1")
                    {
                        itemTaxValueDAO.TranImported = true;
                    }
                    if (this.drpTransactionType.SelectedValue == "2")
                    {
                        itemTaxValueDAO.TranLocal = true;
                    }
                    if (this.drpTransactionType.SelectedValue == "3")
                    {
                        itemTaxValueDAO.TranSale = true;
                    }
                    if (this.drpTransactionType.SelectedValue == "4")
                    {
                        itemTaxValueDAO.TrantradePrice = true;
                    }
                }
                else
                {
                    itemTaxValueDAO.ItemID = Convert.ToInt32(this.ddlItemName.SelectedItem.Value);
                    itemTaxValueDAO.DateOfEffective = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
                    itemTaxValueDAO.TaxValue = dblTaxvalue;
                    itemTaxValueDAO.dUpper = dUpper;
                    itemTaxValueDAO.dLower = dLower;
                    itemTaxValueDAO.LevelId = levelId;
                    itemTaxValueDAO.PacketId = packet_category;
                    itemTaxValueDAO.Healthcharge = healthcharge;
                    int num1 = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
                    itemTaxValueDAO.EmpID = num1;
                    itemTaxValueDAO.Is_last_insert = true;
                    itemTaxValueDAO.IsAnnx = true;
                    itemTaxValueDAO.TaxID = 4;
                    if (this.drpTransactionType.SelectedValue == "1")
                    {
                        itemTaxValueDAO.TranImported = true;
                    }
                    if (this.drpTransactionType.SelectedValue == "2")
                    {
                        itemTaxValueDAO.TranLocal = true;
                    }
                    if (this.drpTransactionType.SelectedValue == "3")
                    {
                        itemTaxValueDAO.TranSale = true;
                    }
                    if (this.drpTransactionType.SelectedValue == "4")
                    {
                        itemTaxValueDAO.TrantradePrice = true;
                    }
                }
                item.Add(itemTaxValueDAO);
                itemTaxValueDAO = null;
                this.Session["CP_DETAIL_MAIN"] = item;
            }
        }

        private ItemTaxValueDAO insertInsertItemTaxValuePer(ItemTaxValueDAO objItemTaxValueDAO, double dblTaxvalue, string dblTaxPer)
        {
            objItemTaxValueDAO.ItemID = Convert.ToInt32(this.ddlItemName.SelectedItem.Value);
            objItemTaxValueDAO.DateOfEffective = DateTime.ParseExact(this.txtDate.Text, "dd/MM/yyyy", null);
            objItemTaxValueDAO.TaxValue = dblTaxvalue;
            objItemTaxValueDAO.TaxPer = dblTaxPer;
            int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
            objItemTaxValueDAO.EmpID = num;
            objItemTaxValueDAO.Is_last_insert = true;
            objItemTaxValueDAO.IsAnnx = true;
            objItemTaxValueDAO.TaxID = 99;
            if (this.drpTransactionType.SelectedValue == "1")
            {
                objItemTaxValueDAO.TranImported = true;
            }
            if (this.drpTransactionType.SelectedValue == "2")
            {
                objItemTaxValueDAO.TranLocal = true;
            }
            if (this.drpTransactionType.SelectedValue == "3")
            {
                objItemTaxValueDAO.TranSale = true;
            }
            if (this.drpTransactionType.SelectedValue == "4")
            {
                objItemTaxValueDAO.TrantradePrice = true;
            }
            return objItemTaxValueDAO;
        }

        private void LoadItemHSCode()
        {
            int num = Convert.ToInt32(this.ddlItemName.SelectedValue);
            DataTable itemHSCodedByItemId = this.objITVBLL.getItemHSCodedByItemId(num);
            if (itemHSCodedByItemId.Rows.Count > 0)
            {
                this.txtUnitName.Text = string.Concat("Unit :", itemHSCodedByItemId.Rows[0]["unit_name"].ToString(), ", H.S Code : ", itemHSCodedByItemId.Rows[0]["hs_code"].ToString());
                if (itemHSCodedByItemId.Rows[0]["is_healthcare_surcharge"].ToString() != "True")
                {
                    this.hltcharge.Visible = false;
                }
                else
                {
                    this.hltcharge.Visible = true;
                }
                if (itemHSCodedByItemId.Rows[0]["hs_code"].ToString() == "2402.20.00")
                {
                    this.lblLevel.Visible = true;
                    this.lblPacket.Visible = false;
                }
                if (itemHSCodedByItemId.Rows[0]["hs_code"].ToString() == "2402.90.00")
                {
                    this.lblLevel.Visible = false;
                    this.lblPacket.Visible = true;
                }
                if (itemHSCodedByItemId.Rows[0]["hs_code"].ToString() == "2403.99.00")
                {
                    this.lblLevel.Visible = false;
                    this.lblPacket.Visible = false;
                }
                this.Session["hsCode"] = itemHSCodedByItemId.Rows[0]["hs_code"].ToString();
            }
        }

        private void LoadItems()
        {
            this.ddlItemName.Items.Clear();
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
            DataTable allItemByCategory = addItemBLL.getAllItemByCategory(num);
            this.ddlItemName.DataSource = allItemByCategory;
            this.ddlItemName.DataTextField = allItemByCategory.Columns["ITEM_NAME"].ToString();
            this.ddlItemName.DataValueField = allItemByCategory.Columns["ITEM_ID"].ToString();
            this.ddlItemName.DataBind();
            ListItem listItem = new ListItem("ALL", "0");
            this.ddlItemName.Items.Insert(0, listItem);
        }

        private void LoadItems1()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = Convert.ToInt32(this.drpSubCategory.SelectedValue);
            DataTable allItemByCategory = addItemBLL.getAllItemByCategory(num);
            this.ddlItemName.DataSource = allItemByCategory;
            this.ddlItemName.DataTextField = allItemByCategory.Columns["ITEM_NAME"].ToString();
            this.ddlItemName.DataValueField = allItemByCategory.Columns["ITEM_ID"].ToString();
            this.ddlItemName.DataBind();
            ListItem listItem = new ListItem("ALL", "0");
            this.ddlItemName.Items.Insert(0, listItem);
        }

        private void LoadItemsSubCategor()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = Convert.ToInt32(this.ddlCategory.SelectedValue);
            if (this.ddlCategory.SelectedValue == "0")
            {
                ListItem listItem = new ListItem("ALL", "-99");
                this.drpSubCategory.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("ALL", "0");
                this.ddlItemName.Items.Insert(0, listItem);
                return;
            }
            DataTable allISubCategory = addItemBLL.getAllISubCategory(num);
            this.drpSubCategory.DataSource = allISubCategory;
            this.drpSubCategory.DataTextField = allISubCategory.Columns["category_name"].ToString();
            this.drpSubCategory.DataValueField = allISubCategory.Columns["category_id"].ToString();
            this.drpSubCategory.DataBind();
            ListItem listItem2 = new ListItem("----Select----", "-0");
            this.drpSubCategory.Items.Insert(0, listItem2);
        }

        private void LoadItemsWithoutFilter()
        {
            this.ddlItemName.Items.Clear();
            DataTable allItemByCategoryForTaxRate = (new AddItemBLL()).getAllItemByCategoryForTaxRate();
            this.ddlItemName.DataSource = allItemByCategoryForTaxRate;
            this.ddlItemName.DataTextField = allItemByCategoryForTaxRate.Columns["ITEM_NAME"].ToString();
            this.ddlItemName.DataValueField = allItemByCategoryForTaxRate.Columns["ITEM_ID"].ToString();
            this.ddlItemName.DataBind();
            ListItem listItem = new ListItem("ALL", "0");
            this.ddlItemName.Items.Insert(0, listItem);
        }

        private void LoadLevel()
        {
            this.drpLevel.Items.Clear();
            DataTable itemLevel = (new AddItemBLL()).getItemLevel();
            this.drpLevel.DataSource = itemLevel;
            this.drpLevel.DataTextField = itemLevel.Columns["code_name"].ToString();
            this.drpLevel.DataValueField = itemLevel.Columns["code_id_d"].ToString();
            this.drpLevel.DataBind();
            ListItem listItem = new ListItem("SELECT", "0");
            this.drpLevel.Items.Insert(0, listItem);
        }

        private void LoadUnit()
        {
            try
            {
                int num = Convert.ToInt32(this.ddlItemName.SelectedValue);
                DataTable dataTable = this.objITVBLL.LoadUnit(num);
                this.dgvItemTaxPer.DataSource = dataTable;
                this.dgvItemTaxPer.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                OrganizaitonInfo.fillDDLAllCategoryName(this.ddlCategory);
                int count = this.ddlCategory.Items.Count;
                this.LoadLevel();
                this.LoadItemsWithoutFilter();
                this.ShowGridviewLimitTobacco();
                this.showDataInGridView();
                this.ShowGridviewPer();
                this.ShowGridviewLimit();
                this.txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.lblLevel.Visible = false;
                this.lblPacket.Visible = false;
                this.Session["CP_DETAIL_MAIN"] = new ArrayList();
                this.btnExcelSave.Visible = false;
                this.Session["Tax_EXCEL"] = "";
                if (base.Request.QueryString.HasKeys())
                {
                    string[] strArrays = base.Request.QueryString["itemId"].ToString().Split(new char[] { '?' });
                    int num = Convert.ToInt16(strArrays[0]);
                    this.ddlItemName.SelectedValue = num.ToString();
                    this.showCatSubCat();
                    this.LoadItemHSCode();
                }
            }
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save";
            this.btnSave.Style.Add("background-color", "#0D7B78");
            this.btnRefresh.Text = "Refresh";
        }

        private void showCatSubCat()
        {
            SaleBLL saleBLL = new SaleBLL();
            try
            {
                int num = Convert.ToInt32(this.ddlItemName.SelectedValue);
                DataTable catSubCat = saleBLL.getCatSubCat(num);
                if (catSubCat != null)
                {
                    this.ddlCategory.DataSource = catSubCat;
                    this.ddlCategory.DataTextField = catSubCat.Columns["category_name"].ToString();
                    this.ddlCategory.DataValueField = catSubCat.Columns["category_id"].ToString();
                    this.ddlCategory.DataBind();
                    this.drpSubCategory.DataSource = catSubCat;
                    this.drpSubCategory.DataTextField = catSubCat.Columns["sub_category_name"].ToString();
                    this.drpSubCategory.DataValueField = catSubCat.Columns["sub_category_id"].ToString();
                    this.drpSubCategory.DataBind();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        public void showDataInGridView()
        {
            DataSet allItemTaxCategoryFalse = this.objITCBLL.getAllItemTaxCategoryFalse();
            this.dgvItemTaxCategoryFalse.DataSource = allItemTaxCategoryFalse;
            this.dgvItemTaxCategoryFalse.DataBind();
        }

        public void showDataInGridView1()
        {
            this.objITCBLL.getAllItemTaxCategoryTrue();
        }

        public void showDataInGridViewAfterSaving()
        {
            this.gvItemTaxValues.DataSource = null;
            this.gvItemTaxValues.DataBind();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("HS_Code", typeof(string));
            dataTable.Columns.Add("Item", typeof(string));
            dataTable.Columns.Add("Unit", typeof(string));
            int num = Convert.ToInt32(this.ddlItemName.SelectedValue);
            DataSet itemTaxvalues = this.objITVBLL.getItemTaxvalues(num);
            for (int i = 0; i < itemTaxvalues.Tables[0].Rows.Count; i++)
            {
                dataTable.Columns.Add(itemTaxvalues.Tables[0].Rows[i][3].ToString(), typeof(string));
            }
            dataTable.Columns.Add("Effective Date", typeof(string));
            if (itemTaxvalues.Tables[0].Rows.Count > 0)
            {
                DataRow str = dataTable.NewRow();
                str["HS_Code"] = itemTaxvalues.Tables[0].Rows[0][0].ToString();
                str["Item"] = itemTaxvalues.Tables[0].Rows[0][1].ToString();
                str["Unit"] = itemTaxvalues.Tables[0].Rows[0][2].ToString();
                for (int j = 0; j < itemTaxvalues.Tables[0].Rows.Count; j++)
                {
                    str[itemTaxvalues.Tables[0].Rows[j][3].ToString()] = itemTaxvalues.Tables[0].Rows[j][4].ToString();
                }
                str["Effective Date"] = itemTaxvalues.Tables[0].Rows[0]["date_effective"].ToString();
                dataTable.Rows.Add(str);
                this.gvItemTaxValues.DataSource = dataTable;
                this.gvItemTaxValues.DataBind();
            }
            this.gvItemTaxValues.Visible = true;
        }

        public void ShowGridviewLimit()
        {
            try
            {
                DataSet limitInformation = this.objITCBLL.getLimitInformation();
                this.dgvItemLimit.DataSource = limitInformation;
                this.dgvItemLimit.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ShowGridviewLimitTobacco()
        {
            try
            {
                DataSet limitInformationTobacco = this.objITCBLL.getLimitInformationTobacco();
                this.grdTobacco.DataSource = limitInformationTobacco;
                this.grdTobacco.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ShowGridviewPer()
        {
            try
            {
                DataSet perInformation = this.objITCBLL.getPerInformation();
                this.dgvItemTaxPer.DataSource = perInformation;
                this.dgvItemTaxPer.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void showTaxInGridView()
        {
            string str = "";
            if (this.ddlCategory.SelectedItem.Value.ToString() == "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99" && this.drpSubCategory.SelectedItem.Value.ToString() == "-99")
            {
                str = "";
            }
            else if (this.drpSubCategory.SelectedItem.Value.ToString() != "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99")
            {
                str = string.Concat(" and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            else if (this.drpSubCategory.SelectedItem.Value.ToString() != "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99")
            {
                str = string.Concat(" and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            else if (!(this.ddlCategory.SelectedItem.Value.ToString() != "0") || !(this.ddlItemName.SelectedItem.Value.ToString() == "-99") || !(this.ddlItemName.SelectedItem.Value.ToString() == "0") || !(this.drpSubCategory.SelectedItem.Value.ToString() != "-99") || !(this.drpSubCategory.SelectedItem.Value.ToString() != "0"))
            {
                string[] strArrays = new string[] { " and i.item_id='", this.ddlItemName.SelectedItem.Value.ToString(), "' and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'" };
                str = string.Concat(strArrays);
            }
            else
            {
                str = string.Concat(" and i.category_id ='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            DataSet allItemTaxValues = this.objITVBLL.getAllItemTaxValues(str);
            this.dgvCountry.DataSource = allItemTaxValues;
            if (allItemTaxValues.Tables[0].Rows.Count > 0)
            {
                this.dgvCountry.DataBind();
                this.btnShowList.Text = "Hide Item Tax List";
                return;
            }
            this.btnShowList.Text = "Show Item Tax List";
            this.dgvCountry.DataSource = null;
            this.dgvCountry.DataBind();
        }

        public void showTaxInGridViewBySelection(string strTransactionType)
        {
            string str = "";
            GridViewRow selectedRow = this.dgvCountry.SelectedRow;
            short num = Convert.ToInt16(this.dgvCountry.DataKeys[selectedRow.RowIndex].Value);
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            if (strTransactionType == "Local_purchase")
            {
                flag = true;
            }
            if (strTransactionType == "Import")
            {
                flag1 = true;
            }
            if (strTransactionType == "Sale")
            {
                flag2 = true;
            }
            if (strTransactionType == "Trade_price")
            {
                flag3 = true;
            }
            str = string.Concat(" and i.item_id=", num);
            DataTable allItemTaxValuesForSelect = this.objITVBLL.getAllItemTaxValuesForSelect(str, flag, flag1, flag2, flag3);
            if (allItemTaxValuesForSelect != null && allItemTaxValuesForSelect.Rows.Count > 0)
            {
                for (int i = 0; i < this.dgvItemTaxCategoryFalse.Rows.Count; i++)
                {
                    int num1 = Convert.ToInt32(this.dgvItemTaxCategoryFalse.DataKeys[i].Values["tax_id"]);
                    TextBox textBox = (TextBox)this.dgvItemTaxCategoryFalse.Rows[i].FindControl("txtTaxVavue");
                    if (num1 == 1)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["cd"].ToString();
                    }
                    if (num1 == 2)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["rd"].ToString();
                    }
                    if (num1 == 3)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["sd"].ToString();
                    }
                    if (num1 == 4)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["vat"].ToString();
                    }
                    if (num1 == 5)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["ait"].ToString();
                    }
                    if (num1 == 6)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["atv"].ToString();
                    }
                    if (num1 == 7)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["Tti"].ToString();
                    }
                    if (num1 == 8)
                    {
                        textBox.Text = allItemTaxValuesForSelect.Rows[0]["at_"].ToString();
                    }
                }
                DateTime dateTime = Convert.ToDateTime(allItemTaxValuesForSelect.Rows[0]["date_effective"].ToString());
                this.txtDate.Text = dateTime.ToString("dd/MM/yyyy");
                if (strTransactionType == "Local_purchase")
                {
                    this.drpTransactionType.SelectedValue = "2";
                }
                if (strTransactionType == "Import")
                {
                    this.drpTransactionType.SelectedValue = "1";
                }
                if (strTransactionType == "Sale")
                {
                    this.drpTransactionType.SelectedValue = "3";
                }
                if (strTransactionType == "Trade_price")
                {
                    this.drpTransactionType.SelectedValue = "4";
                }
            }
        }

        public void ShowTaxInGridViewBySelectionLimit(string strTransactionType)
        {
            string str = "";
            GridViewRow selectedRow = this.GridViewUpperLower.SelectedRow;
            short num = Convert.ToInt16(this.GridViewUpperLower.DataKeys[selectedRow.RowIndex].Value);
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            if (strTransactionType == "Local_purchase")
            {
                flag = true;
            }
            if (strTransactionType == "Import")
            {
                flag1 = true;
            }
            if (strTransactionType == "Sale")
            {
                flag2 = true;
            }
            if (strTransactionType == "Trade_price")
            {
                flag3 = true;
            }
            str = string.Concat(" and i.item_id=", num);
            DataTable allItemTaxValuesForSelectLimit = this.objITVBLL.getAllItemTaxValuesForSelectLimit(str, flag, flag1, flag2, flag3);
            if (allItemTaxValuesForSelectLimit != null && allItemTaxValuesForSelectLimit.Rows.Count > 0)
            {
                this.dgvItemLimit.DataSource = null;
                this.dgvItemLimit.DataSource = allItemTaxValuesForSelectLimit;
                this.dgvItemLimit.DataBind();
                DateTime dateTime = Convert.ToDateTime(allItemTaxValuesForSelectLimit.Rows[0]["date_effective"].ToString());
                this.txtDate.Text = dateTime.ToString("dd/MM/yyyy");
                if (strTransactionType == "Local_purchase")
                {
                    this.drpTransactionType.SelectedValue = "2";
                }
                if (strTransactionType == "Import")
                {
                    this.drpTransactionType.SelectedValue = "1";
                }
                if (strTransactionType == "Sale")
                {
                    this.drpTransactionType.SelectedValue = "3";
                }
                if (strTransactionType == "Trade_price")
                {
                    this.drpTransactionType.SelectedValue = "4";
                }
            }
        }

        public void ShowTaxInGridViewBySelectionPer(string strTransactionType)
        {
            string str = "";
            GridViewRow selectedRow = this.GridViewPer.SelectedRow;
            short num = Convert.ToInt16(this.GridViewPer.DataKeys[selectedRow.RowIndex].Value);
            bool flag = false;
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            if (strTransactionType == "Local_purchase")
            {
                flag = true;
            }
            if (strTransactionType == "Import")
            {
                flag1 = true;
            }
            if (strTransactionType == "Sale")
            {
                flag2 = true;
            }
            if (strTransactionType == "Trade_price")
            {
                flag3 = true;
            }
            str = string.Concat(" and i.item_id=", num);
            DataTable allItemTaxValuesForSelectPer = this.objITVBLL.getAllItemTaxValuesForSelectPer(str, flag, flag1, flag2, flag3);
            if (allItemTaxValuesForSelectPer != null && allItemTaxValuesForSelectPer.Rows.Count > 0)
            {
                this.dgvItemTaxPer.DataSource = null;
                this.dgvItemTaxPer.DataSource = allItemTaxValuesForSelectPer;
                this.dgvItemTaxPer.DataBind();
                DateTime dateTime = Convert.ToDateTime(allItemTaxValuesForSelectPer.Rows[0]["date_effective"].ToString());
                this.txtDate.Text = dateTime.ToString("dd/MM/yyyy");
                if (strTransactionType == "Local_purchase")
                {
                    this.drpTransactionType.SelectedValue = "2";
                }
                if (strTransactionType == "Import")
                {
                    this.drpTransactionType.SelectedValue = "1";
                }
                if (strTransactionType == "Sale")
                {
                    this.drpTransactionType.SelectedValue = "3";
                }
                if (strTransactionType == "Trade_price")
                {
                    this.drpTransactionType.SelectedValue = "4";
                }
            }
        }

        public void ShowTaxInGridViewLimit()
        {
            string str = "";
            if (this.ddlCategory.SelectedItem.Value.ToString() == "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99" && this.drpSubCategory.SelectedItem.Value.ToString() == "-99")
            {
                str = "";
            }
            else if (this.drpSubCategory.SelectedItem.Value.ToString() != "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99")
            {
                str = string.Concat(" and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            else if (this.drpSubCategory.SelectedItem.Value.ToString() != "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99")
            {
                str = string.Concat(" and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            else if (!(this.ddlCategory.SelectedItem.Value.ToString() != "0") || !(this.ddlItemName.SelectedItem.Value.ToString() == "-99") || !(this.ddlItemName.SelectedItem.Value.ToString() == "0") || !(this.drpSubCategory.SelectedItem.Value.ToString() != "-99") || !(this.drpSubCategory.SelectedItem.Value.ToString() != "0"))
            {
                string[] strArrays = new string[] { " and i.item_id='", this.ddlItemName.SelectedItem.Value.ToString(), "' and sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'" };
                str = string.Concat(strArrays);
            }
            else
            {
                str = string.Concat(" and i.category_id ='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            DataSet allItemTaxValuesLimit = this.objITVBLL.GetAllItemTaxValuesLimit(str);
            this.GridViewUpperLower.DataSource = allItemTaxValuesLimit;
            if (allItemTaxValuesLimit.Tables[0].Rows.Count > 0)
            {
                this.GridViewUpperLower.DataBind();
                this.btnShowList.Text = "Hide Item Tax List";
                return;
            }
            this.btnShowList.Text = "Show Item Tax List";
            this.GridViewUpperLower.DataSource = null;
            this.GridViewUpperLower.DataBind();
        }

        public void ShowTaxInGridViewPer()
        {
            string str = "";
            if (this.ddlCategory.SelectedItem.Value.ToString() == "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99" && this.drpSubCategory.SelectedItem.Value.ToString() == "-99")
            {
                str = "";
            }
            else if (this.drpSubCategory.SelectedItem.Value.ToString() != "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99")
            {
                str = string.Concat(" and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            else if (this.drpSubCategory.SelectedItem.Value.ToString() != "0" && this.ddlItemName.SelectedItem.Value.ToString() == "-99")
            {
                str = string.Concat(" and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            else if (!(this.ddlCategory.SelectedItem.Value.ToString() != "0") || !(this.ddlItemName.SelectedItem.Value.ToString() == "-99") || !(this.ddlItemName.SelectedItem.Value.ToString() == "0") || !(this.drpSubCategory.SelectedItem.Value.ToString() != "-99") || !(this.drpSubCategory.SelectedItem.Value.ToString() != "0"))
            {
                string[] strArrays = new string[] { " and i.item_id='", this.ddlItemName.SelectedItem.Value.ToString(), "' and i.sub_category_id='", this.drpSubCategory.SelectedItem.Value.ToString(), "'" };
                str = string.Concat(strArrays);
            }
            else
            {
                str = string.Concat(" and i.category_id ='", this.drpSubCategory.SelectedItem.Value.ToString(), "'");
            }
            DataSet allItemTaxValuesPer = this.objITVBLL.getAllItemTaxValuesPer(str);
            this.GridViewPer.DataSource = allItemTaxValuesPer;
            if (allItemTaxValuesPer.Tables[0].Rows.Count > 0)
            {
                this.GridViewPer.DataBind();
                this.btnShowList.Text = "Hide Item Tax List";
                return;
            }
            this.btnShowList.Text = "Show Item Tax List";
            this.GridViewPer.DataSource = null;
            this.GridViewPer.DataBind();
        }

        private bool Validation()
        {
            if (this.btnSave.Text == "Save")
            {
                if (this.ddlCategory.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage("Please select category", MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (this.drpSubCategory.SelectedValue == "-0")
                {
                    this.msgBox.AddMessage("Please select sub-category", MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (this.ddlItemName.SelectedValue == "0")
                {
                    this.msgBox.AddMessage("Please select Item Name", MsgBoxs.enmMessageType.Attention);
                    this.ddlItemName.Focus();
                    return false;
                }
                if (this.txtDate.Text == "")
                {
                    this.msgBox.AddMessage("Please type effective date", MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (DateTime.ParseExact(this.txtDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy").Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    this.msgBox.AddMessage("Effective date can not be greater than Current /date.", MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                if (this.drpTransactionType.SelectedValue == "0")
                {
                    this.msgBox.AddMessage("Please choose transaction type", MsgBoxs.enmMessageType.Attention);
                    return false;
                }
                double num = 0;
                double num1 = 0;
                if (this.dgvItemTaxPer.Rows.Count > 0 && Convert.ToDouble(((TextBox)this.dgvItemTaxPer.Rows[0].FindControl("txtQuantity")).Text) > 0)
                {
                    this.isPer = true;
                }
                if (this.dgvItemLimit.Rows.Count > 0)
                {
                    TextBox textBox = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtQuantity");
                    num = Convert.ToDouble(textBox.Text);
                    TextBox textBox1 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtUpperLimit");
                    TextBox textBox2 = (TextBox)this.dgvItemLimit.Rows[0].FindControl("txtLowerLimit");
                    if (num > 0)
                    {
                        if (Convert.ToDecimal(textBox2.Text) >= Convert.ToDecimal(textBox1.Text))
                        {
                            this.msgBox.AddMessage("Upper limit must be greater than lower limit", MsgBoxs.enmMessageType.Attention);
                            return false;
                        }
                        this.isLimit = true;
                    }
                }
                if (this.dgvItemTaxCategoryFalse.Rows.Count > 0)
                {
                    int num2 = 0;
                    while (num2 < this.dgvItemTaxCategoryFalse.Rows.Count)
                    {
                        TextBox textBox3 = (TextBox)this.dgvItemTaxCategoryFalse.Rows[num2].FindControl("txtTaxVavue");
                        if (textBox3.Text != "")
                        {
                            num1 = Convert.ToDouble(textBox3.Text);
                        }
                        if (num1 <= 0)
                        {
                            num2++;
                        }
                        else
                        {
                            this.isPercentage = true;
                            break;
                        }
                    }
                }
            }
            if (!(this.btnSave.Text == "Update") || !(this.drpTransactionType.SelectedValue == "0"))
            {
                return true;
            }
            this.msgBox.AddMessage("Please choose transaction type", MsgBoxs.enmMessageType.Attention);
            return false;
        }
    }
}