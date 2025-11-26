using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    public partial class ProductsTransfer_6__5s : Page, IRequiresSessionState
    {
        private SaleBLL objsBLL = new SaleBLL();

        private ChallanBLL objBLL = new ChallanBLL();

        private AddItemBLL objItemBLL = new AddItemBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

        private ContructualProductionBLL objCPBLL = new ContructualProductionBLL();

 

        public ProductsTransfer_6__5s()
        {
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validationForGrid())
                {
                    this.fillDetailData();
                    this.loadGridView();
                    for (int i = 0; i < this.gvAddtnProperty.Rows.Count; i++)
                    {
                        CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[i].FindControl("chkChallan");
                        checkBox.Enabled = false;
                    }
                    this.clearDetail();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            if (this.btnAddParty.Text == "New")
            {
                this.drpReceipentBranch.Enabled = false;
                this.btnAddParty.Text = "Cancel";
                return;
            }
            this.drpReceipentBranch.Enabled = true;
            this.btnAddParty.Text = "New";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.clearDetail();
            this.clearMaster();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            ProductTransferMaster productTransferMaster = new ProductTransferMaster();
            ArrayList arrayLists = new ArrayList();
            try
            {
                if (this.validation())
                {
                    productTransferMaster = this.fillMasterData(productTransferMaster);
                    if (productTransferMaster != null)
                    {
                        arrayLists = (ArrayList)this.Session["DETAIL_INFO"];
                        if (arrayLists == null || arrayLists.Count == 0)
                        {
                            this.gvItem.DataSource = null;
                            this.gvItem.DataBind();
                            this.msgBox.AddMessage("Please insert detail data properly.", MsgBoxs.enmMessageType.Error);
                            return;
                        }
                        else
                        {
                            ArrayList arrayLists1 = new ArrayList();
                            if (this.gvAddtnProperty.Rows.Count > 0)
                            {
                                for (int i = 0; i < this.gvAddtnProperty.Rows.Count; i++)
                                {
                                    CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[i].FindControl("chkChallan");
                                    HiddenField hiddenField = (HiddenField)this.gvAddtnProperty.Rows[i].FindControl("additionalInfoId");
                                    int num = Convert.ToInt32(hiddenField.Value);
                                    if (checkBox.Checked)
                                    {
                                        arrayLists1.Add(num);
                                    }
                                }
                                if (arrayLists1.Count == 0)
                                {
                                    this.msgBox.AddMessage("Please Select Property from Grid.", MsgBoxs.enmMessageType.Error);
                                    return;
                                }
                            }
                            if (!productTransferBLL.insertProductTransferIssuingData(productTransferMaster, arrayLists, arrayLists1))
                            {
                                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                            }
                            else
                            {
                                this.msgBox.AddMessage("Product Transfer Data Successfully Saved.", MsgBoxs.enmMessageType.Success);
                                this.showReport();
                                this.clearMaster();
                                this.gvAddtnProperty.DataSource = null;
                                this.gvAddtnProperty.DataBind();
                                this.GetNextChallanNo();
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

        protected void btnShowReport_OnClick(object sender, EventArgs e)
        {
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

        private void clearDetail()
        {
            this.lblSku.Text = "";
            UtilityK.fillItemCategoryDropDownList(this.drpCategory);
            ListItem listItem = new ListItem("-- Select --", "-99");
            this.drpCategory.Items.Insert(0, listItem);
            this.drpSubCategory.Items.Clear();
            ListItem listItem1 = new ListItem("--- Select ---", "-99");
            this.drpSubCategory.Items.Insert(0, listItem1);
            this.drpItem.SelectedValue = "-99";
            this.lblAvailQuantity.Text = "";
            this.lblUnit.Text = "";
            this.txtQuantity.Text = "";
            this.txtPurchaseUnitPrice.Text = "";
            this.txtPurchaseVAT.Text = "";
            this.txtPurchaseSD.Text = "";
            this.txtTotalPrice.Text = "";
            this.txtRemark.Text = "";
            this.lblHSCode.Text = "";
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

        private void clearMaster()
        {
            this.drpReceipentBranch.SelectedValue = "0";
            this.txtProviderAddress.Text = "";
            this.txtProviderBIN.Text = "";
            this.txtReceipentAddress.Text = "";
            this.txtReceipentBIN.Text = "";
            this.drpVehicleType.SelectedValue = "-99";
            this.txtVehicleNo.Text = "";
            this.txtChallanIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.Session["DETAIL_INFO"] = new ArrayList();
            this.loadGridView();
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

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadSubCategory();
                this.LoadItemsByCatgSubCatg();
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
                this.lblTotalRow.Text = "";
                this.lblSku.Text = "";
                this.divSearch.Visible = false;
                this.divProp.Visible = true;
                this.gvAddtnProperty.DataSource = null;
                this.gvAddtnProperty.DataBind();
                this.txtQuantity.Text = "";
                this.txtPurchaseUnitPrice.Text = "";
                this.txtPurchaseVAT.Text = "";
                this.txtPurchaseSD.Text = "";
                this.lblPurchaseVAT.Text = "";
                this.lblPurchaseSD.Text = "";
                this.drpItem.SelectedItem.ToString();
                string selectedValue = this.drpItem.SelectedValue;
                string str = "";
                if (this.drpItem.SelectedValue != "-99")
                {
                    string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                    if (strArrays != null && strArrays.Count<string>() > 0)
                    {
                        this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 1];
                    }
                    str = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays1 = str.Split(new char[] { '.' });
                    int num = Convert.ToInt16(strArrays1[0]);
                    DataTable item = (DataTable)this.Session["ITEM_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("item_id = ", str));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.lblProductType.Text = dataRow["PRODUCT_TYPE"].ToString();
                        this.lblSku.Text = dataRow["item_sku"].ToString();
                    }
                    this.getAvailableStock();
                    this.getAllProperty();
                    this.fillCatSubCat();
                    this.EnableOrDisablePropertyForItem();
                    this.GetPriceInfo();
                    string empty = string.Empty;
                    string str1 = this.drpItem.SelectedItem.ToString();
                    if (str1.Contains("Local"))
                    {
                        empty = "L";
                    }
                    if (str1.Contains("Import"))
                    {
                        empty = "I";
                    }
                    if (str1.Contains("Production"))
                    {
                        empty = "R";
                    }
                    DataTable dataTable = this.objPDBll.geAdditionalPropertybyItemID(num, empty);
                    if (dataTable.Rows.Count > 0)
                    {
                        this.divProp.Visible = false;
                        short num1 = 0;
                        short num2 = 0;
                        short num3 = 0;
                        short num4 = 0;
                        short num5 = 0;
                        string str2 = "";
                        string str3 = "";
                        string str4 = "";
                        string str5 = "";
                        string str6 = "";
                        DataTable appCodeDetailName = null;
                        num1 = Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
                        num2 = Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
                        num3 = Convert.ToInt16(dataTable.Rows[0]["property_id3"]);
                        num4 = Convert.ToInt16(dataTable.Rows[0]["property_id4"]);
                        num5 = Convert.ToInt16(dataTable.Rows[0]["property_id5"]);
                        ArrayList arrayLists = new ArrayList();
                        appCodeDetailName = this.objItemBLL.GetAppCodeDetailName(num1);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField = new BoundField();
                            str2 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.lblProperty11.Text = str2;
                            this.tableNameList.Add(str2);
                            boundField.HeaderText = str2;
                            boundField.DataField = "Property1_Text";
                            this.gvAddtnProperty.Columns.Add(boundField);
                        }
                        appCodeDetailName = this.objItemBLL.GetAppCodeDetailName(num2);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField1 = new BoundField();
                            str3 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.lblProperty22.Text = str3;
                            this.tableNameList.Add(str3);
                            boundField1.HeaderText = str3;
                            boundField1.DataField = "Property2_Text";
                            this.gvAddtnProperty.Columns.Add(boundField1);
                        }
                        appCodeDetailName = this.objItemBLL.GetAppCodeDetailName(num3);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField2 = new BoundField();
                            str4 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.lblProperty33.Text = str4;
                            this.tableNameList.Add(str4);
                            boundField2.HeaderText = str4;
                            boundField2.DataField = "Property3_Text";
                            this.gvAddtnProperty.Columns.Add(boundField2);
                        }
                        appCodeDetailName = this.objItemBLL.GetAppCodeDetailName(num4);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField3 = new BoundField();
                            str5 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.lblProperty44.Text = str5;
                            this.tableNameList.Add(str5);
                            boundField3.HeaderText = str5;
                            boundField3.DataField = "Property4_Text";
                            this.gvAddtnProperty.Columns.Add(boundField3);
                        }
                        appCodeDetailName = this.objItemBLL.GetAppCodeDetailName(num5);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField4 = new BoundField();
                            str6 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.lblProperty55.Text = str6;
                            this.tableNameList.Add(str6);
                            boundField4.HeaderText = str6;
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

        protected void drpProviderBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpProviderBranch.SelectedValue == "-99")
            {
                this.txtProviderAddress.Text = string.Empty;
                return;
            }
            this.GetBranchProviderAddress();
            this.GetBranchProviderBIN();
        }

        protected void drpReceipentBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpReceipentBranch.SelectedValue != "-99")
            {
                this.GetBranchRcvrAddress();
                this.GetBranchRcvrBIN();
                return;
            }
            this.txtReceipentAddress.Text = string.Empty;
            this.txtReceipentBIN.Text = string.Empty;
        }

        protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if (this.drpType.SelectedIndex == 1)
                {
                    str = "C";
                }
                if (this.drpType.SelectedIndex == 2)
                {
                    str = "P";
                }
                if (this.drpType.SelectedIndex == 3)
                {
                    str = "R";
                }
                if (this.drpType.SelectedIndex == 4)
                {
                    str = "F";
                }
                if (this.drpType.SelectedIndex == 5)
                {
                    str = "W";
                }
                if (this.drpType.SelectedIndex == 6)
                {
                    str = "M";
                }
                this.LoadCategory(str);
                this.LoadSubCategory();
                this.LoadItems();
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
                this.LoadItemsByCatgSubCatg();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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

        private void fillCatSubCat()
        {
            try
            {
                string str = "";
                if (this.drpItem.SelectedValue == "-99")
                {
                    this.drpCategory.SelectedValue = "-99";
                    this.drpSubCategory.SelectedValue = "-99";
                }
                else
                {
                    str = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays = str.Split(new char[] { '.' });
                    int num = Convert.ToInt16(strArrays[0]);
                    DataTable allFieldByItemId = this.objItemBLL.getAllFieldByItemId(num);
                    this.lblUnit.Text = allFieldByItemId.Rows[0]["unit_code"].ToString();
                    this.lblUnitID.Text = allFieldByItemId.Rows[0]["unit_id"].ToString();
                    this.lblProductType.Text = allFieldByItemId.Rows[0]["item_type"].ToString();
                    this.drpCategory.DataSource = allFieldByItemId;
                    this.drpCategory.DataTextField = allFieldByItemId.Columns["category_name"].ToString();
                    this.drpCategory.DataValueField = allFieldByItemId.Columns["category_id"].ToString();
                    this.drpCategory.DataBind();
                    this.drpSubCategory.DataSource = allFieldByItemId;
                    this.drpSubCategory.DataTextField = allFieldByItemId.Columns["sub_category_name"].ToString();
                    this.drpSubCategory.DataValueField = allFieldByItemId.Columns["sub_category_id"].ToString();
                    this.drpSubCategory.DataBind();
                    string str1 = allFieldByItemId.Rows[0]["product_type"].ToString();
                    if (str1 == "C")
                    {
                        this.drpType.SelectedIndex = 1;
                    }
                    if (str1 == "P")
                    {
                        this.drpType.SelectedIndex = 2;
                    }
                    if (str1 == "R")
                    {
                        this.drpType.SelectedIndex = 3;
                    }
                    if (str1 == "F")
                    {
                        this.drpType.SelectedIndex = 4;
                    }
                    if (str1 == "W")
                    {
                        this.drpType.SelectedIndex = 5;
                    }
                    if (str1 == "M")
                    {
                        this.drpType.SelectedIndex = 6;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void fillDetailData()
        {
            ArrayList item = (ArrayList)this.Session["DETAIL_INFO"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            try
            {
                ProductTransferDetail productTransferDetail = new ProductTransferDetail()
                {
                    RowNo = num
                };
                if (this.drpType.SelectedIndex != 0)
                {
                    productTransferDetail.Type = 'S';
                }
                else
                {
                    productTransferDetail.Type = 'G';
                }
                string str = "";
                string str1 = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                str1 = this.drpItem.SelectedItem.ToString();
                if (str1.Contains("Local"))
                {
                    productTransferDetail.PurchaseType = 'L';
                }
                if (str1.Contains("Import"))
                {
                    productTransferDetail.PurchaseType = 'I';
                }
                if (str1.Contains("Production"))
                {
                    productTransferDetail.PurchaseType = 'F';
                }
                if (str1.Contains("Service"))
                {
                    productTransferDetail.PurchaseType = 'S';
                }
                productTransferDetail.Category = this.drpCategory.SelectedItem.ToString();
                productTransferDetail.SubCategory = this.drpSubCategory.SelectedItem.ToString();
                DataTable itemNameByItemId = this.objsBLL.getItemNameByItemId(Convert.ToInt16(strArrays[0]));
                if (itemNameByItemId.Rows.Count > 0)
                {
                    productTransferDetail.Item = itemNameByItemId.Rows[0]["item_name"].ToString();
                    productTransferDetail.BrandName = itemNameByItemId.Rows[0]["brand_name"].ToString();
                }
                productTransferDetail.ItemId = Convert.ToInt16(strArrays[0]);
                productTransferDetail.Property11 = this.lblProperty11.Text;
                productTransferDetail.Property22 = this.lblProperty22.Text;
                productTransferDetail.Property33 = this.lblProperty33.Text;
                productTransferDetail.Property44 = this.lblProperty44.Text;
                productTransferDetail.Property55 = this.lblProperty55.Text;
                if (!(this.drpProperty1.SelectedValue != "-99") || !(this.drpProperty1.SelectedValue != ""))
                {
                    productTransferDetail.Property1 = 0;
                }
                else
                {
                    productTransferDetail.Property1 = Convert.ToInt32(this.drpProperty1.SelectedValue);
                    productTransferDetail.Property1_Text = this.drpProperty1.SelectedItem.ToString();
                }
                if (!(this.drpProperty2.SelectedValue != "-99") || !(this.drpProperty2.SelectedValue != ""))
                {
                    productTransferDetail.Property2 = 0;
                }
                else
                {
                    productTransferDetail.Property2 = Convert.ToInt32(this.drpProperty2.SelectedValue);
                    productTransferDetail.Property2_Text = this.drpProperty2.SelectedItem.ToString();
                }
                if (!(this.drpProperty3.SelectedValue != "-99") || !(this.drpProperty3.SelectedValue != ""))
                {
                    productTransferDetail.Property3 = 0;
                }
                else
                {
                    productTransferDetail.Property3 = Convert.ToInt32(this.drpProperty3.SelectedValue);
                    productTransferDetail.Property3_Text = this.drpProperty3.SelectedItem.ToString();
                }
                if (!(this.drpProperty4.SelectedValue != "-99") || !(this.drpProperty4.SelectedValue != ""))
                {
                    productTransferDetail.Property4 = 0;
                }
                else
                {
                    productTransferDetail.Property4 = Convert.ToInt32(this.drpProperty4.SelectedValue);
                    productTransferDetail.Property4_Text = this.drpProperty4.SelectedItem.ToString();
                }
                if (!(this.drpProperty5.SelectedValue != "-99") || !(this.drpProperty5.SelectedValue != ""))
                {
                    productTransferDetail.Property5 = 0;
                }
                else
                {
                    productTransferDetail.Property5 = Convert.ToInt32(this.drpProperty5.SelectedValue);
                    productTransferDetail.Property5_Text = this.drpProperty5.SelectedItem.ToString();
                }
                productTransferDetail.Quantity = Convert.ToInt32(this.txtQuantity.Text.Trim());
                if (productTransferDetail.Quantity <= Convert.ToInt32(this.lblAvailQuantity.Text))
                {
                    productTransferDetail.Unit = this.lblUnit.Text;
                    productTransferDetail.UnitID = Convert.ToInt16(this.lblUnitID.Text.Trim());
                    productTransferDetail.UserID = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                    productTransferDetail.Remark = this.txtRemark.Text;
                    productTransferDetail.unit_price = Convert.ToDecimal(this.txtPurchaseUnitPrice.Text);
                    productTransferDetail.vat_amount = Convert.ToDecimal(this.txtPurchaseVAT.Text);
                    productTransferDetail.sd_amount = Convert.ToDecimal(this.txtPurchaseSD.Text);
                    productTransferDetail.vat_rate = Convert.ToDecimal(this.lblPurchaseVAT.Text);
                    productTransferDetail.sd_rate = Convert.ToDecimal(this.lblPurchaseSD.Text);
                    item.Add(productTransferDetail);
                }
                else
                {
                    this.msgBox.AddMessage(string.Concat("Stock is not available.Current Stock is: ", this.lblAvailQuantity.Text), MsgBoxs.enmMessageType.Attention);
                    return;
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "ProductsTransfer_6.5.aspx", "fillDetailData", fileLineNumber);
            }
            this.Session["DETAIL_INFO"] = item;
        }

        private ProductTransferMaster fillMasterData(ProductTransferMaster objMaster)
        {
            string str;
            try
            {
                objMaster.OrgName = this.orgName.Text;
                objMaster.OrgAddress = this.orgAddress.Text;
                objMaster.OrgBIN = this.orgBIN.Text;
                objMaster.ProviderName = this.drpProviderBranch.SelectedItem.ToString();
                objMaster.ProviderAddress = this.txtProviderAddress.Text;
                objMaster.ProviderBIN = this.txtProviderBIN.Text;
                objMaster.ReceipentName = this.drpReceipentBranch.SelectedItem.ToString();
                objMaster.ReceipentAddress = this.txtReceipentAddress.Text;
                objMaster.ReceipentBIN = this.txtReceipentBIN.Text;
                this.GetNextChallanNo();
                objMaster.ChallanNo = this.txtChallanNo.Text.Trim();
                if (!string.IsNullOrEmpty(this.txtChallanIssueDate.Text.Trim()))
                {
                    string[] strArrays = new string[] { this.txtChallanIssueDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                    objMaster.IssueDate = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                DateTime dateTime = DateTime.ParseExact(string.Concat(this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text), "HH:mm", CultureInfo.InvariantCulture);
                objMaster.IssueTime = dateTime.ToString();
                objMaster.ProviderBranchID = Convert.ToInt16(this.drpProviderBranch.SelectedValue);
                objMaster.OrganizationID = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
                objMaster.UserID = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                objMaster.AuditID = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                if (this.drpType.SelectedIndex == 0)
                {
                    objMaster.MaterialType = 'C';
                }
                if (this.drpType.SelectedIndex == 1)
                {
                    objMaster.MaterialType = 'P';
                }
                if (this.drpType.SelectedIndex == 2)
                {
                    objMaster.MaterialType = 'R';
                }
                if (this.drpType.SelectedIndex == 3)
                {
                    objMaster.MaterialType = 'F';
                }
                if (this.drpType.SelectedIndex == 4)
                {
                    objMaster.MaterialType = 'W';
                }
                if (this.drpType.SelectedIndex == 5)
                {
                    objMaster.MaterialType = 'M';
                }
                objMaster.TransferStatus = 'I';
                if (this.btnAddParty.Text != "New")
                {
                    objMaster.IsNewParty = true;
                    objMaster.NewBranchAddress = this.txtReceipentAddress.Text;
                    objMaster.NewBranchBIN = this.txtReceipentBIN.Text;
                }
                else
                {
                    objMaster.IsNewParty = false;
                    objMaster.ReceipentBranchID = Convert.ToInt16(this.drpReceipentBranch.SelectedValue);
                }
                DateTime now = DateTime.Now;
                objMaster.TransferYear = Convert.ToInt16(now.ToString("yyyy"));
                objMaster.ChallanBookId = Convert.ToInt16(this.hdBookId.Value);
                objMaster.ChallanPageNo = Convert.ToInt16(this.hdPageNo.Value);
                objMaster.VehicleTypeM = 7;
                objMaster.VehicleTypeD = (this.drpVehicleType.SelectedValue != "-99" ? (int)Convert.ToInt16(this.drpVehicleType.SelectedValue) : 0);
                ProductTransferMaster productTransferMaster = objMaster;
                if (this.txtVehicleNo.Text.Trim() != "")
                {
                    str = this.txtVehicleNo.Text.Trim();
                }
                else
                {
                    str = null;
                }
                productTransferMaster.VehicleNo = str;
                objMaster.VehicleTypeName = (this.drpVehicleType.SelectedValue != "-99" ? this.drpVehicleType.SelectedItem.ToString() : "");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["MASTER_DATA"] = objMaster;
            return objMaster;
        }

        private void fillProviderBranch()
        {
        }

        private void fillReceipentBranch()
        {
        }

        private void getAllProperty()
        {
            try
            {
                ProductTransferBLL productTransferBLL = new ProductTransferBLL();
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                int num = Convert.ToInt16(strArrays[0]);
                DataTable dataTable = productTransferBLL.fillProperty(num);
                if (dataTable != null)
                {
                    this.lblProp1.Text = dataTable.Rows[0]["property1"].ToString();
                    this.lblProp2.Text = dataTable.Rows[0]["property2"].ToString();
                    this.lblProp3.Text = dataTable.Rows[0]["property3"].ToString();
                    this.lblProp4.Text = dataTable.Rows[0]["property4"].ToString();
                    this.lblProp5.Text = dataTable.Rows[0]["property5"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void getAvailableStock()
        {
            SaleBLL saleBLL = new SaleBLL();
            try
            {
                string str = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                int num = Convert.ToInt16(strArrays[0]);
                DateTime dateTime = DateTime.ParseExact(this.txtChallanIssueDate.Text.Trim(), "dd/MM/yyyy", null);
                string empty = string.Empty;
                string empty1 = string.Empty;
                empty = this.drpItem.SelectedItem.ToString();
                if (empty.Contains("Local"))
                {
                    empty1 = "L";
                }
                if (empty.Contains("Import"))
                {
                    empty1 = "I";
                }
                if (empty.Contains("Production"))
                {
                    empty1 = "F";
                }
                DataTable availStockforTransferProductNew = saleBLL.getAvailStockforTransferProductNew(num, dateTime, empty1);
                if (availStockforTransferProductNew.Rows != null)
                {
                    if (availStockforTransferProductNew.Rows[0]["item_type"].ToString() != "I")
                    {
                        this.lblAvailQuantity.Text = "0";
                    }
                    else
                    {
                        this.lblAvailQuantity.Text = availStockforTransferProductNew.Rows[0]["availStock"].ToString();
                    }
                    this.lblAvailQuantity.Text = availStockforTransferProductNew.Rows[0]["availStock"].ToString();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void GetAvailStock()
        {
            SaleBLL saleBLL = new SaleBLL();
            DateTime standardDateFromDdMMyyyy = BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtChallanIssueDate.Text.Trim());
            DataTable dataTable = new DataTable();
            if (this.drpItem.SelectedValue == "-99")
            {
                this.lblUnit.Text = ".";
                this.lblUnitID.Text = "";
                this.lblItemType.Text = "";
                this.lblAvailQuantity.Text = "0";
            }
            else
            {
                Convert.ToInt32(this.drpItem.SelectedValue);
                dataTable = saleBLL.GetAvailableStock(Convert.ToInt16(this.drpItem.SelectedValue), standardDateFromDdMMyyyy);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.lblUnit.Text = dataTable.Rows[0]["unit_code"].ToString();
                    this.lblUnitID.Text = dataTable.Rows[0]["unit_id"].ToString();
                    this.lblItemType.Text = dataTable.Rows[0]["item_type"].ToString();
                    if (dataTable.Rows[0]["item_type"].ToString() != "I")
                    {
                        this.lblAvailQuantity.Text = "0";
                    }
                    else
                    {
                        this.lblAvailQuantity.Text = dataTable.Rows[0]["availStock"].ToString();
                    }
                    if (dataTable.Rows[0]["parent_id"] != null && Convert.ToInt16(dataTable.Rows[0]["parent_id"]) > 0)
                    {
                        this.drpCategory.SelectedValue = dataTable.Rows[0]["parent_id"].ToString();
                        this.LoadSubCategory();
                        this.drpSubCategory.SelectedValue = dataTable.Rows[0]["category_id"].ToString();
                        return;
                    }
                    this.drpCategory.SelectedValue = dataTable.Rows[0]["category_id"].ToString();
                    this.drpSubCategory.Items.Clear();
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    this.drpSubCategory.Items.Insert(0, listItem);
                    this.drpSubCategory.Enabled = false;
                    return;
                }
            }
        }

        private void GetBranchInProviderformation()
        {
            this.drpProviderBranch.Items.Clear();
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
                    this.drpProviderBranch.Enabled = false;
                    if (num1 != 0)
                    {
                        DataTable selectedBusinessUnitBranchInfo = this.objBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                        if (selectedBusinessUnitBranchInfo != null && selectedBusinessUnitBranchInfo.Rows.Count > 0)
                        {
                            this.drpProviderBranch.Items.Clear();
                            this.drpProviderBranch.DataSource = selectedBusinessUnitBranchInfo;
                            this.drpProviderBranch.DataTextField = selectedBusinessUnitBranchInfo.Columns["branch_unit_name"].ToString();
                            this.drpProviderBranch.DataValueField = selectedBusinessUnitBranchInfo.Columns["org_branch_reg_id"].ToString();
                            this.drpProviderBranch.DataBind();
                        }
                    }
                    else
                    {
                        this.drpProviderBranch.Items.Clear();
                        ListItem listItem = new ListItem("Head Office", "0");
                        this.drpProviderBranch.Items.Insert(0, listItem);
                    }
                    this.GetBranchProviderAddress();
                }
                if (num == 2 || num == 1)
                {
                    this.drpProviderBranch.Enabled = true;
                    DataTable dataTable = this.objBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpProviderBranch.DataSource = dataTable;
                        this.drpProviderBranch.DataTextField = dataTable.Columns["branch_unit_name"].ToString();
                        this.drpProviderBranch.DataValueField = dataTable.Columns["org_branch_reg_id"].ToString();
                        this.drpProviderBranch.DataBind();
                    }
                    this.GetBranchProviderAddress();
                    this.GetBranchProviderBIN();
                }
            }
        }

        private void GetBranchProviderAddress()
        {
            if (this.Session["ORGBRANCHID"] != null)
            {
                OrgRegistrationInfoDAO orgRegistrationInfoDAO = new OrgRegistrationInfoDAO();
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.drpProviderBranch.SelectedItem.Value.ToString());
                DataTable oRGorBranch = orgRegistrationInfoDAO.GetORGorBranch(num);
                if (oRGorBranch != null && oRGorBranch.Rows.Count > 0)
                {
                    oRGorBranch.Rows[0]["branch_unit_name"].ToString();
                    this.txtProviderAddress.Text = oRGorBranch.Rows[0]["org_branch_address"].ToString();
                    return;
                }
                this.txtProviderAddress.Text = string.Empty;
            }
        }

        private void GetBranchProviderBIN()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.drpProviderBranch.SelectedItem.Value.ToString());
                if (num == 1 || num == 2 || num == 3)
                {
                    if (num1 == 0)
                    {
                        return;
                    }
                    DataTable branchBIN = challanBLL.GetBranchBIN(num2);
                    if (branchBIN != null && branchBIN.Rows.Count > 0)
                    {
                        this.txtProviderBIN.Text = branchBIN.Rows[0]["branch_unit_bin"].ToString();
                        return;
                    }
                    this.txtProviderBIN.Text = string.Empty;
                }
            }
        }

        private void GetBranchRcvrAddress()
        {
            if (this.Session["ORGBRANCHID"] != null)
            {
                OrgRegistrationInfoDAO orgRegistrationInfoDAO = new OrgRegistrationInfoDAO();
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.drpReceipentBranch.SelectedItem.Value.ToString());
                DataTable oRGorBranch = orgRegistrationInfoDAO.GetORGorBranch(num);
                if (oRGorBranch != null && oRGorBranch.Rows.Count > 0)
                {
                    oRGorBranch.Rows[0]["branch_unit_name"].ToString();
                    this.txtReceipentAddress.Text = oRGorBranch.Rows[0]["org_branch_address"].ToString();
                    return;
                }
                this.txtReceipentAddress.Text = string.Empty;
            }
        }

        private void GetBranchRcvrBIN()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.drpReceipentBranch.SelectedItem.Value.ToString());
                if (num == 1 || num == 2 || num == 3)
                {
                    if (num1 == 0)
                    {
                        return;
                    }
                    DataTable branchBIN = challanBLL.GetBranchBIN(num2);
                    if (branchBIN != null && branchBIN.Rows.Count > 0)
                    {
                        this.txtReceipentBIN.Text = branchBIN.Rows[0]["branch_unit_bin"].ToString();
                        return;
                    }
                    this.txtReceipentBIN.Text = string.Empty;
                }
            }
        }

        private void GetBranchRcvrInformation()
        {
            this.drpReceipentBranch.Items.Clear();
            ChallanBLL challanBLL = new ChallanBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                int num = Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                int num1 = Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num2 = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                if (num2 <= 0)
                {
                    num2 = 0;
                }
                if (num == 3)
                {
                    this.drpReceipentBranch.Enabled = true;
                    DataTable branchInformationForRcvr = challanBLL.GetBranchInformationForRcvr(num2, num1);
                    if (branchInformationForRcvr != null && branchInformationForRcvr.Rows.Count > 0)
                    {
                        this.drpReceipentBranch.Items.Clear();
                        this.drpReceipentBranch.DataSource = branchInformationForRcvr;
                        this.drpReceipentBranch.DataTextField = branchInformationForRcvr.Columns["branch_unit_name"].ToString();
                        this.drpReceipentBranch.DataValueField = branchInformationForRcvr.Columns["org_branch_reg_id"].ToString();
                        this.drpReceipentBranch.DataBind();
                    }
                }
                if (num == 2 || num == 1)
                {
                    this.drpReceipentBranch.Enabled = true;
                    DataTable branchInformationFormanagerNew = challanBLL.GetBranchInformationFormanagerNew(num2, num1);
                    if (branchInformationFormanagerNew != null && branchInformationFormanagerNew.Rows.Count > 0)
                    {
                        this.drpReceipentBranch.Items.Clear();
                        this.drpReceipentBranch.DataSource = branchInformationFormanagerNew;
                        this.drpReceipentBranch.DataTextField = branchInformationFormanagerNew.Columns["branch_unit_name"].ToString();
                        this.drpReceipentBranch.DataValueField = branchInformationFormanagerNew.Columns["org_branch_reg_id"].ToString();
                        this.drpReceipentBranch.DataBind();
                    }
                }
                ListItem listItem = new ListItem("--Select--", "0");
                this.drpReceipentBranch.Items.Insert(0, listItem);
                this.drpReceipentBranch.SelectedValue = "0";
            }
        }

        private void GetNextChallanNo()
        {
            ChallanBLL challanBLL = new ChallanBLL();
            int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            short num1 = Convert.ToInt16(this.drpProviderBranch.SelectedValue);
            DataTable nextChallanNo = challanBLL.GetNextChallanNo(4, num, num1);
            if (nextChallanNo == null || nextChallanNo.Rows.Count <= 0)
            {
                this.txtChallanNo.Text = "";
                this.hdBookId.Value = "";
                this.hdPageNo.Value = "";
                return;
            }
            this.txtChallanNo.Text = nextChallanNo.Rows[0]["challan_no"].ToString();
            this.hdBookId.Value = nextChallanNo.Rows[0]["challan_book_id"].ToString();
            this.hdPageNo.Value = nextChallanNo.Rows[0]["page_no"].ToString();
        }

        private void GetPriceInfo()
        {
            try
            {
                ChallanBLL challanBLL = new ChallanBLL();
                SaleDetailDAO saleDetailDAO = new SaleDetailDAO();
                string str = "";
                string str1 = "";
                string str2 = "";
                str = Convert.ToString(this.drpItem.SelectedValue);
                string[] strArrays = str.Split(new char[] { '.' });
                saleDetailDAO.ItemID = Convert.ToInt32(strArrays[0]);
                DataTable dataTable = new DataTable();
                if (saleDetailDAO.ItemID != -99)
                {
                    str1 = this.drpItem.SelectedItem.ToString();
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
                    SaleBLL saleBLL = new SaleBLL();
                    decimal num = new decimal(0);
                    decimal num1 = new decimal(0);
                    decimal num2 = new decimal(0);
                    DataTable unitPriceFromPD = this.objCPBLL.GetUnitPriceFromPD(saleDetailDAO.ItemID);
                    if (unitPriceFromPD.Rows.Count <= 0)
                    {
                        DataTable vatRateNValue = challanBLL.GetVatRateNValue(saleDetailDAO.ItemID);
                        if (vatRateNValue.Rows.Count > 0)
                        {
                            this.txtPurchaseUnitPrice.Text = vatRateNValue.Rows[0]["purchase_unit_price"].ToString();
                        }
                        if (str2 == "L")
                        {
                            dataTable = saleBLL.GetPriceInfoOfItemForLocalPurchase(saleDetailDAO);
                        }
                        else if (str2 == "I")
                        {
                            dataTable = saleBLL.GetPriceInfoOfItemForImportPurchase(saleDetailDAO);
                        }
                        else if (str2 == "F")
                        {
                            dataTable = saleBLL.GetPriceInfoOfItemFrSale(saleDetailDAO);
                        }
                    }
                    else
                    {
                        num = Convert.ToDecimal(unitPriceFromPD.Rows[0]["prpsd_actl_prc"]);
                        num1 = Convert.ToDecimal(unitPriceFromPD.Rows[0]["production_quantity"]);
                        num2 = num / num1;
                        this.txtPurchaseUnitPrice.Text = num2.ToString();
                        dataTable = saleBLL.GetPriceInfoOfItemFrSale(saleDetailDAO);
                    }
                    if (dataTable != null)
                    {
                        if (dataTable.Rows.Count <= 0)
                        {
                            this.lblPurchaseUnitPrice.Text = "0.00";
                            this.lblPurchaseSD.Text = "0.00";
                            this.lblPurchaseVAT.Text = "0.00";
                        }
                        else if (dataTable.Rows[0]["per"].ToString() != "1")
                        {
                            this.lblPurchaseSD.Text = dataTable.Rows[0]["SD_RATE"].ToString();
                            this.lblPurchaseVAT.Text = dataTable.Rows[0]["VAT_RATE"].ToString();
                        }
                        else
                        {
                            this.txtPurchaseVAT.Text = dataTable.Rows[0]["VAT_RATE"].ToString();
                            this.lblfxdVT.Text = "Tk. ";
                            this.lblPurchaseVAT.Text = dataTable.Rows[0]["VAT_RATE"].ToString();
                            this.Label25.Text = " Per Unit.";
                        }
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
        }

        private void GetPropertyWiseAvailStock()
        {
            try
            {
                SaleBLL saleBLL = new SaleBLL();
                short num = 0;
                short num1 = 0;
                short num2 = 0;
                short num3 = 0;
                short num4 = 0;
                string str = "";
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
                    str = Convert.ToString(this.drpItem.SelectedValue);
                    string[] strArrays = str.Split(new char[] { '.' });
                    int num5 = Convert.ToInt16(strArrays[0]);
                    DateTime dateTime = DateTime.Parse(this.txtChallanIssueDate.Text.Trim());
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    empty = this.drpItem.SelectedItem.ToString();
                    if (empty.Contains("Local"))
                    {
                        empty1 = "L";
                    }
                    if (empty.Contains("Import"))
                    {
                        empty1 = "I";
                    }
                    if (empty.Contains("Production"))
                    {
                        empty1 = "F";
                    }
                    DataTable availStockforTransferProductPropertyWise = saleBLL.getAvailStockforTransferProductPropertyWise(num5, dateTime, empty1, num, num1, num2, num3, num4);
                    if (availStockforTransferProductPropertyWise.Rows != null)
                    {
                        if (availStockforTransferProductPropertyWise.Rows[0]["item_type"].ToString() != "I")
                        {
                            this.lblAvailQuantity.Text = "0";
                        }
                        else
                        {
                            this.lblAvailQuantity.Text = availStockforTransferProductPropertyWise.Rows[0]["availStock"].ToString();
                        }
                        this.lblAvailQuantity.Text = availStockforTransferProductPropertyWise.Rows[0]["availStock"].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void GetProviderBranchInformation()
        {
            this.drpProviderBranch.Items.Clear();
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                if (num <= 0)
                {
                    num = 0;
                }
                this.drpProviderBranch.Enabled = true;
                DataTable allBranchByOrgID = productTransferBLL.getAllBranchByOrgID(num);
                if (allBranchByOrgID != null && allBranchByOrgID.Rows.Count > 0)
                {
                    this.drpProviderBranch.DataSource = allBranchByOrgID;
                    this.drpProviderBranch.DataTextField = allBranchByOrgID.Columns["branch_name"].ToString();
                    this.drpProviderBranch.DataValueField = allBranchByOrgID.Columns["branch_id"].ToString();
                    this.drpProviderBranch.DataBind();
                }
                ListItem listItem = new ListItem("Head Office", "0");
                this.drpProviderBranch.Items.Insert(0, listItem);
                this.Session["PBRANCH_INFO"] = allBranchByOrgID;
            }
        }

        private void GetReceipentBranchInformation()
        {
            this.drpReceipentBranch.Items.Clear();
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            if (this.Session["ORGBRANCHID"] != null)
            {
                Convert.ToInt32(this.Session["USER_LEVEL"].ToString());
                Convert.ToInt32(this.Session["ORGBRANCHID"].ToString());
                int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"].ToString());
                if (num <= 0)
                {
                    num = 0;
                }
                this.drpReceipentBranch.Enabled = true;
                DataTable allBranchByOrgID = productTransferBLL.getAllBranchByOrgID(num);
                if (allBranchByOrgID != null && allBranchByOrgID.Rows.Count > 0)
                {
                    this.drpReceipentBranch.DataSource = allBranchByOrgID;
                    this.drpReceipentBranch.DataTextField = allBranchByOrgID.Columns["branch_name"].ToString();
                    this.drpReceipentBranch.DataValueField = allBranchByOrgID.Columns["branch_id"].ToString();
                    this.drpReceipentBranch.DataBind();
                }
                ListItem listItem = new ListItem("Head Office", "0");
                this.drpReceipentBranch.Items.Insert(0, listItem);
                this.drpReceipentBranch.SelectedValue = "0";
                this.Session["RBRANCH_INFO"] = allBranchByOrgID;
            }
        }

        private void GetTotalPurchasePriceQtyChange()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                ChallanBLL challanBLL = new ChallanBLL();
                double num = 0;
                double num1 = 0;
                double num2 = 0;
                double num3 = 0;
                double num4 = 0;
                num1 = (this.txtQuantity.Text != "" ? Convert.ToDouble(this.txtQuantity.Text.Trim()) : 0);
                num2 = (this.lblPurchaseVAT.Text != "" ? Convert.ToDouble(this.lblPurchaseVAT.Text.Trim()) : 0);
                if (this.Label25.Text == " Per Unit.")
                {
                    num3 = num1 * num2;
                    this.txtPurchaseVAT.Text = num3.ToString("N2");
                    num4 = num1 * (this.txtPurchaseUnitPrice.Text != "" ? Convert.ToDouble(this.txtPurchaseUnitPrice.Text.Trim()) : 0);
                    this.txtTotalPrice.Text = num4.ToString("N2");
                    if (this.txtPurchaseSD.Text != "")
                    {
                        Convert.ToDouble(this.txtPurchaseSD.Text.Trim());
                    }
                }
                else if (this.txtQuantity.Text.Length > 0 && Convert.ToDouble(this.txtQuantity.Text) > 0 && this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                {
                    if (this.txtPurchaseUnitPrice.Text.Length > 0 && Convert.ToDouble(this.txtPurchaseUnitPrice.Text) > 0)
                    {
                        num = Convert.ToDouble(this.txtQuantity.Text) * Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                        Convert.ToDouble(this.txtQuantity.Text);
                        Convert.ToDouble(this.txtPurchaseUnitPrice.Text);
                    }
                    if (this.lblPurchaseSD.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseSD.Text) <= 0 || num <= 0)
                    {
                        this.txtPurchaseSD.Text = "0.00";
                    }
                    else
                    {
                        TextBox str = this.txtPurchaseSD;
                        double num5 = num * (Convert.ToDouble(this.lblPurchaseSD.Text) / 100);
                        str.Text = num5.ToString("0.00");
                    }
                    if (this.lblPurchaseVAT.Text.Length <= 0 || Convert.ToDouble(this.lblPurchaseVAT.Text) <= 0 || num <= 0)
                    {
                        this.txtPurchaseVAT.Text = "0.00";
                    }
                    else if (this.lblProductType.Text == "W")
                    {
                        TextBox textBox = this.txtPurchaseVAT;
                        double num6 = (num + Convert.ToDouble(this.txtPurchaseSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100) / 2;
                        textBox.Text = num6.ToString("0.00");
                    }
                    else
                    {
                        TextBox str1 = this.txtPurchaseVAT;
                        double num7 = (num + Convert.ToDouble(this.txtPurchaseSD.Text)) * (Convert.ToDouble(this.lblPurchaseVAT.Text) / 100);
                        str1.Text = num7.ToString("0.00");
                    }
                    this.txtTotalPrice.Text = num.ToString();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void gvAddtnProperty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["DETAIL_INFO"];
                item.RemoveAt(e.RowIndex);
                this.Session["DETAIL_INFO"] = item;
                this.loadGridView();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadCategory(string type)
        {
            List<Category> categories = new List<Category>();
            categories = (new AddItemBLL()).getCategory();
            if (categories != null)
            {
                this.drpCategory.DataSource = categories;
                this.drpCategory.DataTextField = "CatName";
                this.drpCategory.DataValueField = "CatID";
                this.drpCategory.DataBind();
            }
        }

        private void loadGridView()
        {
            ArrayList item = (ArrayList)this.Session["DETAIL_INFO"];
            this.gvItem.DataSource = item;
            this.gvItem.DataBind();
        }

        private void LoadHours()
        {
            this.drpChDtHr.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                this.drpChDtHr.Items.Add(i.ToString("00"));
            }
        }

        private void LoadItems()
        {
            int num = 0;
            AddItemBLL addItemBLL = new AddItemBLL();
            DataTable finishGoodsProductByCategoryIdNew = null;
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
                if (this.drpType.SelectedIndex == 0)
                {
                    finishGoodsProductByCategoryIdNew = addItemBLL.GetFinishGoodsProductByCategoryIdNew(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdNew;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdNew.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdNew.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem);
                }
                if (this.drpType.SelectedIndex == 1)
                {
                    finishGoodsProductByCategoryIdNew = addItemBLL.getFinishGoodsProductByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdNew;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdNew.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdNew.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem1 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem1);
                }
                if (this.drpType.SelectedIndex == 2)
                {
                    finishGoodsProductByCategoryIdNew = addItemBLL.getFinishGoodsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdNew;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdNew.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdNew.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem2 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                }
                if (this.drpType.SelectedIndex == 3)
                {
                    finishGoodsProductByCategoryIdNew = addItemBLL.getIngredientsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdNew;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdNew.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdNew.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem3 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem3);
                }
                if (this.drpType.SelectedIndex == 4)
                {
                    finishGoodsProductByCategoryIdNew = addItemBLL.getGoodsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdNew;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdNew.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdNew.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem4 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem4);
                }
                if (this.drpType.SelectedIndex == 5)
                {
                    finishGoodsProductByCategoryIdNew = addItemBLL.getRealStateByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdNew;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdNew.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdNew.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem5 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem5);
                }
                if (this.drpType.SelectedIndex == 6)
                {
                    finishGoodsProductByCategoryIdNew = addItemBLL.getMedicineByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryIdNew;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryIdNew.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryIdNew.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem6 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem6);
                }
                this.Session["ITEM_INFO"] = finishGoodsProductByCategoryIdNew;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
                DataTable allItemForPurchasebyCatgSubCatg = addItemBLL.GetAllItemForPurchasebyCatgSubCatg(setItemDAO);
                if (allItemForPurchasebyCatgSubCatg != null && allItemForPurchasebyCatgSubCatg.Rows.Count > 0)
                {
                    this.drpItem.DataSource = allItemForPurchasebyCatgSubCatg;
                    this.drpItem.DataTextField = allItemForPurchasebyCatgSubCatg.Columns["ITEM_NAME"].ToString();
                    this.drpItem.DataValueField = allItemForPurchasebyCatgSubCatg.Columns["ITEM_ID"].ToString();
                    this.drpItem.DataBind();
                }
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            try
            {
                if (!base.IsPostBack)
                {
                    ProductTransferMaster productTransferMaster = new ProductTransferMaster();
                    this.Session["DETAIL_INFO"] = new ArrayList();
                    this.Session["MASTER_DATA"] = productTransferMaster;
                    this.Session["chkProperty"] = new Dictionary<int, int>();
                    this.orgName.Text = this.Session["organization_name"].ToString();
                    this.orgAddress.Text = this.Session["organization_address"].ToString();
                    this.orgBIN.Text = this.Session["organization_bin"].ToString();
                    this.txtChallanIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.GetBranchRcvrInformation();
                    this.GetBranchInProviderformation();
                    UtilityK.fillItemCategoryDropDownList(this.drpCategory);
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    this.drpCategory.Items.Insert(0, listItem);
                    UtilityK.fillSubCategoryByCatDropDownList(this.drpCategory, this.drpSubCategory);
                    this.drpSubCategory.Items.Insert(0, listItem);
                    this.LoadItems();
                    this.GetNextChallanNo();
                    UtilityK.fillVehicleTypeDropDownList(this.drpVehicleType);
                    ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                    this.drpVehicleType.Items.Insert(0, listItem1);
                    this.LoadHours();
                    this.LoadMinutes();
                    this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void productName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.getProductInfo();
                this.getAvailableStock();
                this.getAllProperty();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
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

        private void showReport()
        {
            try
            {
                ProductTransferMaster productTransferMaster = new ProductTransferMaster();
                string[] strArrays = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
                string[] strArrays1 = strArrays;
                string[] strArrays2 = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };
                string[] strArrays3 = strArrays2;
                if (this.btnShowReport.Text == "Show Report")
                {
                    productTransferMaster = (ProductTransferMaster)this.Session["MASTER_DATA"];
                    this.lblOrgName.Text = productTransferMaster.OrgName;
                    this.lblOrgBIN.Text = productTransferMaster.OrgBIN;
                    this.lblPNameAddress.Text = string.Concat(productTransferMaster.ProviderName, ",", productTransferMaster.ProviderAddress);
                    this.lblReceipentAddress.Text = string.Concat(productTransferMaster.ReceipentName, ',', productTransferMaster.ReceipentAddress);
                    this.lblChallanNo.Text = productTransferMaster.ChallanNo;
                    Label str = this.lblIssueDate;
                    DateTime dateTime = Convert.ToDateTime(productTransferMaster.IssueDate);
                    str.Text = dateTime.ToString("dd-MMM-yyyy");
                    Label label = this.lblIssueTime;
                    DateTime dateTime1 = Convert.ToDateTime(productTransferMaster.IssueTime);
                    label.Text = dateTime1.ToString("hh:mm tt");
                    this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                    ArrayList item = (ArrayList)this.Session["DETAIL_INFO"];
                    if (productTransferMaster.VehicleNo == "")
                    {
                        this.txtTransport.Text = string.Concat(productTransferMaster.VehicleTypeName, " ", productTransferMaster.VehicleNo);
                    }
                    else
                    {
                        this.txtTransport.Text = string.Concat(productTransferMaster.VehicleTypeName, ", ", productTransferMaster.VehicleNo);
                    }
                    string str1 = "";
                    decimal num = new decimal(0);
                    for (int i = 0; i < item.Count; i++)
                    {
                        string str2 = i.ToString();
                        ProductTransferDetail productTransferDetail = (ProductTransferDetail)item[i];
                        string str3 = str2.Replace(strArrays1[i], strArrays3[i]);
                        decimal vatAmount = productTransferDetail.vat_amount;
                        num = productTransferDetail.Quantity * productTransferDetail.unit_price;
                        str1 = string.Concat(str1, "<tr>");
                        str1 = string.Concat(str1, "<td style='border:1px solid gray'>", str3, "</td>");
                        if (productTransferDetail.BrandName == "")
                        {
                            str1 = string.Concat(str1, "<td style='border:1px solid gray'>", productTransferDetail.Item, "</td>");
                        }
                        else
                        {
                            string str4 = str1;
                            string[] item1 = new string[] { str4, "<td style='border:1px solid gray'>", productTransferDetail.Item, ", ", productTransferDetail.BrandName, "</td>" };
                            str1 = string.Concat(item1);
                        }
                        string str5 = str1;
                        string[] strArrays4 = new string[] { str5, "<td style='border:1px solid gray;text-align: center'>", Utilities.formatFraction(productTransferDetail.Quantity), " ", productTransferDetail.Unit, "</td>" };
                        str1 = string.Concat(strArrays4);
                        str1 = string.Concat(str1, "<td style='border:1px solid gray;text-align: center'>", num.ToString("N2"), "</td>");
                        str1 = string.Concat(str1, "<td style='border:1px solid gray'>", productTransferDetail.Remark, "</td>");
                        str1 = string.Concat(str1, "</tr>");
                        this.tblProductTransferChallan.Text = str1;
                    }
                    this.lblDutyOfficer.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.ptPrint.Visible = true;
                    this.btnShowReport.Text = "Hide Report";
                    this.btnPrint.Visible = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            this.GetTotalPurchasePriceQtyChange();
        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
        }

        private bool validation()
        {
            if (this.drpReceipentBranch.SelectedValue == "0")
            {
                this.msgBox.AddMessage("গ্রহীতা শাখার নাম সিলেক্ট করুন", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtChallanNo.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Enter Challan No.", MsgBoxs.enmMessageType.Info);
                this.txtChallanNo.Focus();
                return false;
            }
            if (this.txtChallanIssueDate.Text.Length != 0)
            {
                return true;
            }
            this.msgBox.AddMessage("Please Enter Issue Date.", MsgBoxs.enmMessageType.Info);
            this.txtChallanIssueDate.Focus();
            return false;
        }

        private bool validationForGrid()
        {
            bool flag;
            try
            {
                if (this.drpProperty1.Visible && this.drpProperty1.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty1.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.drpProperty2.Visible && this.drpProperty2.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty2.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.drpProperty3.Visible && this.drpProperty3.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty3.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (this.drpProperty4.Visible && this.drpProperty4.SelectedValue == "-99")
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty4.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
                else if (!this.drpProperty5.Visible || !(this.drpProperty5.SelectedValue == "-99"))
                {
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
                                this.msgBox.AddMessage("Select Property from Grid.", MsgBoxs.enmMessageType.Attention);
                                this.txtQuantity.Focus();
                                flag = false;
                                return flag;
                            }
                            else if (arrayLists.Count != Convert.ToDecimal(this.txtQuantity.Text))
                            {
                                this.msgBox.AddMessage("Quantity and No of Additional Property are not equal", MsgBoxs.enmMessageType.Attention);
                                this.txtQuantity.Focus();
                                flag = false;
                                return flag;
                            }
                        }
                    }
                    flag = true;
                }
                else
                {
                    this.msgBox.AddMessage(string.Concat("Please select ", this.lblProperty5.Text.Trim()), MsgBoxs.enmMessageType.Attention);
                    flag = false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return flag;
        }
    }
}