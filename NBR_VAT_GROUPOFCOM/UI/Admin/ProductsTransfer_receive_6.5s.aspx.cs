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
    public partial class ProductsTransfer_receive_6__5s : Page, IRequiresSessionState
    {
        private ChallanBLL objBLL = new ChallanBLL();

        private AddItemBLL objAddItemsBll = new AddItemBLL();

        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public ArrayList tableNameList = new ArrayList();

        public ProductsTransfer_receive_6__5s()
        {
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.fillDetailData();
                this.loadGridView();
                this.clearDetail();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
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
                        this.getGridData();
                        arrayLists = (ArrayList)this.Session["DETAIL_INFO"];
                        ArrayList arrayLists1 = new ArrayList();
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
                                    arrayLists1.Add(additionalProperty);
                                }
                            }
                            if (arrayLists1.Count == 0)
                            {
                                this.msgBox.AddMessage("Please Select Property from Grid.", MsgBoxs.enmMessageType.Error);
                                return;
                            }
                        }
                        if (!productTransferBLL.insertProductTransferReceivingData(productTransferMaster, arrayLists, arrayLists1))
                        {
                            this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                        }
                        else
                        {
                            this.msgBox.AddMessage("Product Transfer Data Successfully Saved.", MsgBoxs.enmMessageType.Success);
                            this.reportShow();
                            this.clearMaster();
                            this.gvAddtnProperty.DataSource = null;
                            this.gvAddtnProperty.DataBind();
                            this.gvItem.DataSource = null;
                            this.gvItem.DataBind();
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
            if (this.btnShowReport.Text == "Show Report")
            {
                this.msgBox.AddMessage("Please Save Your Data First...", MsgBoxs.enmMessageType.Attention);
                return;
            }
            this.ptPrint.Visible = false;
            this.btnShowReport.Text = "Show Report";
            this.btnPrint.Visible = false;
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
            this.txtRemark.Text = "";
            this.lblHSCode.Text = "";
        }

        private void clearMaster()
        {
            this.Session["DETAIL_INFO"] = new DataTable();
            this.drpProviderBranch.SelectedValue = "0";
            this.txtProviderAddress.Text = "";
            this.txtProviderBIN.Text = "";
            this.txtReceipentAddress.Text = "";
            this.txtReceipentBIN.Text = "";
            this.txtReceiveScrollNo.Text = "";
            this.fillChallanNo();
            this.drpVehicleType.SelectedValue = "-99";
            this.txtVehicleNo.Text = "";
            this.txtChallanReceiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                this.LoadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpChallanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.divSearch.Visible = false;
            this.lblTotalRow.Text = "";
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            try
            {
                string str = this.drpChallanNo.SelectedItem.ToString();
                int num = Convert.ToInt16(this.drpChallanNo.SelectedValue);
                DataTable issuedItemsbyChallan = productTransferBLL.getIssuedItemsbyChallan(str);
                if (issuedItemsbyChallan.Rows.Count > 0)
                {
                    this.gvAddtnProperty.DataSource = null;
                    this.gvAddtnProperty.DataBind();
                    this.gvItem.DataSource = issuedItemsbyChallan;
                    this.gvItem.DataBind();
                    this.Session["DETAIL_INFO"] = issuedItemsbyChallan;
                    this.ItemType.Value = issuedItemsbyChallan.Rows[0]["purchase_type"].ToString();
                    int num1 = Convert.ToInt32(issuedItemsbyChallan.Rows[0]["item_id"]);
                    if (issuedItemsbyChallan.Rows[0]["vehicle_type_d"].ToString() != "0")
                    {
                        this.drpVehicleType.SelectedValue = issuedItemsbyChallan.Rows[0]["vehicle_type_d"].ToString();
                    }
                    this.txtVehicleNo.Text = issuedItemsbyChallan.Rows[0]["vehicle_no"].ToString();
                    DataTable dataTable = this.objPDBll.geAdditionalPropertybytransferID(num1, "T", num);
                    if (dataTable.Rows.Count > 0)
                    {
                        short num2 = 0;
                        short num3 = 0;
                        short num4 = 0;
                        short num5 = 0;
                        short num6 = 0;
                        string str1 = "";
                        string str2 = "";
                        string str3 = "";
                        string str4 = "";
                        string str5 = "";
                        DataTable appCodeDetailName = null;
                        num2 = Convert.ToInt16(dataTable.Rows[0]["property_id1"]);
                        num3 = Convert.ToInt16(dataTable.Rows[0]["property_id2"]);
                        num4 = Convert.ToInt16(dataTable.Rows[0]["property_id3"]);
                        num5 = Convert.ToInt16(dataTable.Rows[0]["property_id4"]);
                        num6 = Convert.ToInt16(dataTable.Rows[0]["property_id5"]);
                        ArrayList arrayLists = new ArrayList();
                        appCodeDetailName = this.objAddItemsBll.GetAppCodeDetailName(num2);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField = new BoundField();
                            str1 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.tableNameList.Add(str1);
                            boundField.HeaderText = str1;
                            boundField.DataField = "Property1_Text";
                            this.gvAddtnProperty.Columns.Add(boundField);
                        }
                        appCodeDetailName = this.objAddItemsBll.GetAppCodeDetailName(num3);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField1 = new BoundField();
                            str2 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.tableNameList.Add(str2);
                            boundField1.HeaderText = str2;
                            boundField1.DataField = "Property2_Text";
                            this.gvAddtnProperty.Columns.Add(boundField1);
                        }
                        appCodeDetailName = this.objAddItemsBll.GetAppCodeDetailName(num4);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField2 = new BoundField();
                            str3 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.tableNameList.Add(str3);
                            boundField2.HeaderText = str3;
                            boundField2.DataField = "Property3_Text";
                            this.gvAddtnProperty.Columns.Add(boundField2);
                        }
                        appCodeDetailName = this.objAddItemsBll.GetAppCodeDetailName(num5);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField3 = new BoundField();
                            str4 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.tableNameList.Add(str4);
                            boundField3.HeaderText = str4;
                            boundField3.DataField = "Property4_Text";
                            this.gvAddtnProperty.Columns.Add(boundField3);
                        }
                        appCodeDetailName = this.objAddItemsBll.GetAppCodeDetailName(num6);
                        if (appCodeDetailName.Rows.Count > 0)
                        {
                            BoundField boundField4 = new BoundField();
                            str5 = appCodeDetailName.Rows[0]["code_name"].ToString();
                            this.tableNameList.Add(str5);
                            boundField4.HeaderText = str5;
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

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.drpItem.SelectedItem.ToString();
                string selectedValue = this.drpItem.SelectedValue;
                if (this.drpItem.SelectedValue != "-99")
                {
                    string[] strArrays = this.drpItem.SelectedItem.Text.Split(new char[] { '-' });
                    if (strArrays != null && strArrays.Count<string>() > 0)
                    {
                        this.lblHSCode.Text = strArrays[strArrays.Count<string>() - 1];
                    }
                    int num = Convert.ToInt32(this.drpItem.SelectedValue);
                    DataTable item = (DataTable)this.Session["ITEM_INFO"];
                    DataRow[] dataRowArray = item.Select(string.Concat("item_id = ", num));
                    DataRow dataRow = dataRowArray[0];
                    if (dataRow != null)
                    {
                        this.lblProductType.Text = dataRow["PRODUCT_TYPE"].ToString();
                    }
                    this.getAvailableStock();
                    this.getAllProperty();
                    this.fillCatSubCat();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void drpProviderBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpProviderBranch.SelectedValue == "-99")
            {
                this.txtProviderAddress.Text = string.Empty;
                return;
            }
            this.fillChallanNo();
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
                this.LoadItems();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void fillCatSubCat()
        {
            AddItemBLL addItemBLL = new AddItemBLL();
            int num = 0;
            if (this.drpItem.SelectedValue == "-99")
            {
                this.drpCategory.SelectedValue = "-99";
                this.drpSubCategory.SelectedValue = "-99";
            }
            else
            {
                num = Convert.ToInt32(this.drpItem.SelectedValue);
                DataTable allFieldByItemId = addItemBLL.getAllFieldByItemId(num);
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
                string str = allFieldByItemId.Rows[0]["product_type"].ToString();
                if (str == "C")
                {
                    this.drpType.SelectedIndex = 1;
                }
                if (str == "P")
                {
                    this.drpType.SelectedIndex = 2;
                }
                if (str == "R")
                {
                    this.drpType.SelectedIndex = 3;
                }
                if (str == "F")
                {
                    this.drpType.SelectedIndex = 4;
                }
                if (str == "W")
                {
                    this.drpType.SelectedIndex = 5;
                }
                if (str == "M")
                {
                    this.drpType.SelectedIndex = 6;
                    return;
                }
            }
        }

        private void fillChallanNo()
        {
            ProductTransferBLL productTransferBLL = new ProductTransferBLL();
            try
            {
                DateTime now = DateTime.Now;
                int num = Convert.ToInt32(now.ToString("yyyy"));
                int num1 = Convert.ToInt32(this.drpReceipentBranch.SelectedValue);
                int num2 = Convert.ToInt32(this.drpProviderBranch.SelectedValue);
                DataTable issuesChallanNo = productTransferBLL.getIssuesChallanNo(num, num2, num1);
                this.drpChallanNo.DataSource = issuesChallanNo;
                this.drpChallanNo.DataTextField = issuesChallanNo.Columns["challan_no"].ToString();
                this.drpChallanNo.DataValueField = issuesChallanNo.Columns["transfer_id"].ToString();
                this.drpChallanNo.DataBind();
                ListItem listItem = new ListItem("--- Select ---", "0");
                this.drpChallanNo.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
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
                productTransferDetail.Category = this.drpCategory.SelectedItem.ToString();
                productTransferDetail.SubCategory = this.drpSubCategory.SelectedItem.ToString();
                productTransferDetail.Item = this.drpItem.SelectedItem.ToString();
                productTransferDetail.ItemId = Convert.ToInt32(this.drpItem.SelectedValue);
                productTransferDetail.Property1 = Convert.ToInt32(this.lblProp1.Text);
                productTransferDetail.Property2 = Convert.ToInt32(this.lblProp2.Text);
                productTransferDetail.Property3 = Convert.ToInt32(this.lblProp3.Text);
                productTransferDetail.Property4 = Convert.ToInt32(this.lblProp4.Text);
                productTransferDetail.Property5 = Convert.ToInt32(this.lblProp5.Text);
                productTransferDetail.Quantity = Convert.ToInt32(this.txtQuantity.Text.Trim());
                int num1 = Convert.ToInt32(this.drpItem.SelectedItem);
                DataTable dataTable = new DataTable();
                dataTable = this.objAddItemsBll.GetItemBoolean(num1);
                if (dataTable.Rows.Count > 0)
                {
                    productTransferDetail.Mrp = Convert.ToBoolean(dataTable.Rows[0]["is_mrp"]);
                    productTransferDetail.Tarrif = Convert.ToBoolean(dataTable.Rows[0]["is_tarrif"]);
                    productTransferDetail.ZeroRate = Convert.ToBoolean(dataTable.Rows[0]["is_zero_rate"]);
                    productTransferDetail.Truncated = Convert.ToBoolean(dataTable.Rows[0]["is_truncated"]);
                    productTransferDetail.IsVDS = Convert.ToBoolean(dataTable.Rows[0]["is_vds"]);
                    productTransferDetail.Rebatable = Convert.ToBoolean(dataTable.Rows[0]["is_rebatable"]);
                    productTransferDetail.Exempted = Convert.ToBoolean(dataTable.Rows[0]["is_exempted"]);
                }
                if (productTransferDetail.Quantity <= Convert.ToInt32(this.lblAvailQuantity.Text))
                {
                    int num2 = 0;
                    while (num2 < item.Count)
                    {
                        if (productTransferDetail.ItemId != ((ProductTransferDetail)item[num2]).ItemId)
                        {
                            num2++;
                        }
                        else
                        {
                            int num3 = Convert.ToInt32(this.lblAvailQuantity.Text);
                            if (((ProductTransferDetail)item[num2]).Quantity + productTransferDetail.Quantity <= num3)
                            {
                                ((ProductTransferDetail)item[num2]).Quantity = ((ProductTransferDetail)item[num2]).Quantity + productTransferDetail.Quantity;
                                this.Session["DETAIL_INFO"] = item;
                                return;
                            }
                            else
                            {
                                this.msgBox.AddMessage(string.Concat("Stock is not available. Current Stock is: ", this.lblAvailQuantity.Text), MsgBoxs.enmMessageType.Attention);
                                return;
                            }
                        }
                    }
                    productTransferDetail.Unit = this.lblUnit.Text;
                    productTransferDetail.UnitID = Convert.ToInt16(this.lblUnitID.Text.Trim());
                    productTransferDetail.UserID = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                    productTransferDetail.Remark = this.txtRemark.Text;
                    item.Add(productTransferDetail);
                }
                else
                {
                    this.msgBox.AddMessage(string.Concat("Stock is not available.Current Stock is: ", this.lblAvailQuantity.Text), MsgBoxs.enmMessageType.Attention);
                    return;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["DETAIL_INFO"] = item;
        }

        private void fillDetailDataFromIssuedChallan()
        {
            for (int i = 0; i < this.gvItem.Rows.Count; i++)
            {
                ProductTransferDetail productTransferDetail = new ProductTransferDetail();
                if (this.drpType.SelectedIndex != 0)
                {
                    productTransferDetail.Type = 'S';
                }
                else
                {
                    productTransferDetail.Type = 'G';
                }
                productTransferDetail.Property1 = Convert.ToInt32(this.lblProp1.Text);
            }
            ArrayList item = (ArrayList)this.Session["DETAIL_INFO"] ?? new ArrayList();
            short num = Convert.ToInt16(item.Count + 1);
            try
            {
                ProductTransferDetail str = new ProductTransferDetail()
                {
                    RowNo = num
                };
                if (this.drpType.SelectedIndex != 0)
                {
                    str.Type = 'S';
                }
                else
                {
                    str.Type = 'G';
                }
                str.Category = this.drpCategory.SelectedItem.ToString();
                str.SubCategory = this.drpSubCategory.SelectedItem.ToString();
                str.Item = this.drpItem.SelectedItem.ToString();
                str.ItemId = Convert.ToInt32(this.drpItem.SelectedValue);
                str.Property1 = Convert.ToInt32(this.lblProp1.Text);
                str.Property2 = Convert.ToInt32(this.lblProp2.Text);
                str.Property3 = Convert.ToInt32(this.lblProp3.Text);
                str.Property4 = Convert.ToInt32(this.lblProp4.Text);
                str.Property5 = Convert.ToInt32(this.lblProp5.Text);
                int num1 = Convert.ToInt32(this.drpItem.SelectedItem);
                DataTable dataTable = new DataTable();
                dataTable = this.objAddItemsBll.GetItemBoolean(num1);
                if (dataTable.Rows.Count > 0)
                {
                    str.Mrp = Convert.ToBoolean(dataTable.Rows[0]["is_mrp"]);
                    str.Tarrif = Convert.ToBoolean(dataTable.Rows[0]["is_tarrif"]);
                    str.ZeroRate = Convert.ToBoolean(dataTable.Rows[0]["is_zero_rate"]);
                    str.Truncated = Convert.ToBoolean(dataTable.Rows[0]["is_truncated"]);
                    str.IsVDS = Convert.ToBoolean(dataTable.Rows[0]["is_vds"]);
                    str.Rebatable = Convert.ToBoolean(dataTable.Rows[0]["is_rebatable"]);
                    str.Exempted = Convert.ToBoolean(dataTable.Rows[0]["is_exempted"]);
                }
                if (str.Quantity <= Convert.ToInt32(this.lblAvailQuantity.Text))
                {
                    int num2 = 0;
                    while (num2 < item.Count)
                    {
                        if (str.ItemId != ((ProductTransferDetail)item[num2]).ItemId)
                        {
                            num2++;
                        }
                        else
                        {
                            int num3 = Convert.ToInt32(this.lblAvailQuantity.Text);
                            if (((ProductTransferDetail)item[num2]).Quantity + str.Quantity <= num3)
                            {
                                ((ProductTransferDetail)item[num2]).Quantity = ((ProductTransferDetail)item[num2]).Quantity + str.Quantity;
                                this.Session["DETAIL_INFO"] = item;
                                return;
                            }
                            else
                            {
                                this.msgBox.AddMessage(string.Concat("Stock is not available. Current Stock is: ", this.lblAvailQuantity.Text), MsgBoxs.enmMessageType.Attention);
                                return;
                            }
                        }
                    }
                    str.Unit = this.lblUnit.Text;
                    str.UnitID = Convert.ToInt16(this.lblUnitID.Text.Trim());
                    str.UserID = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                    str.Remark = this.txtRemark.Text;
                    item.Add(str);
                }
                else
                {
                    this.msgBox.AddMessage(string.Concat("Stock is not available.Current Stock is: ", this.lblAvailQuantity.Text), MsgBoxs.enmMessageType.Attention);
                    return;
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["DETAIL_INFO"] = item;
        }

        private ProductTransferMaster fillMasterData(ProductTransferMaster objMaster)
        {
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
                objMaster.ChallanNo = this.drpChallanNo.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(this.txtChallanReceiveDate.Text.Trim()))
                {
                    string[] strArrays = new string[] { this.txtChallanReceiveDate.Text.Trim(), " ", this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text };
                    objMaster.IssueDate = DateTime.ParseExact(string.Concat(strArrays), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                DateTime dateTime = DateTime.ParseExact(string.Concat(this.drpChDtHr.SelectedItem.Text, ":", this.drpChDtMin.SelectedItem.Text), "HH:mm", CultureInfo.InvariantCulture);
                objMaster.IssueTime = dateTime.ToString();
                DateTime dateTime1 = DateTime.ParseExact(this.txtChallanReceiveDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objMaster.Date = dateTime1.ToString("dd-MM-yyyy");
                object hour = DateTime.Now.Hour;
                DateTime now = DateTime.Now;
                objMaster.Time = string.Concat(hour, ":", now.Minute);
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
                    objMaster.MaterialType = 'F';
                }
                if (this.drpType.SelectedIndex == 2)
                {
                    objMaster.MaterialType = 'R';
                }
                objMaster.TransferStatus = 'R';
                objMaster.ReceipentBranchID = Convert.ToInt16(this.drpReceipentBranch.SelectedValue);
                objMaster.ReceiveScrollNo = this.txtReceiveScrollNo.Text.Trim();
                DateTime now1 = DateTime.Now;
                objMaster.TransferYear = Convert.ToInt16(now1.ToString("yyyy"));
                objMaster.VehicleTypeM = 7;
                objMaster.VehicleTypeD = (this.drpVehicleType.SelectedValue != "-99" ? (int)Convert.ToInt16(this.drpVehicleType.SelectedValue) : 0);
                objMaster.VehicleNo = (this.txtVehicleNo.Text.Trim() != "" ? this.txtVehicleNo.Text.Trim() : "");
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
                int num = Convert.ToInt32(this.drpItem.SelectedValue);
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
                short num = Convert.ToInt16(this.drpItem.SelectedValue);
                DateTime standardDateFromDdMMyyyy = BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtChallanReceiveDate.Text.Trim());
                DataTable availStockforTransferProduct = saleBLL.getAvailStockforTransferProduct(num, standardDateFromDdMMyyyy);
                if (availStockforTransferProduct.Rows != null)
                {
                    if (availStockforTransferProduct.Rows[0]["item_type"].ToString() != "I")
                    {
                        this.lblAvailQuantity.Text = "0";
                    }
                    else
                    {
                        this.lblAvailQuantity.Text = availStockforTransferProduct.Rows[0]["availStock"].ToString();
                    }
                    this.lblAvailQuantity.Text = availStockforTransferProduct.Rows[0]["availStock"].ToString();
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
            DateTime standardDateFromDdMMyyyy = BLL.Utility.GetStandardDateFrom_ddMMyyyy(this.txtChallanReceiveDate.Text.Trim());
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
            this.drpProviderBranch.ClearSelection();
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
                    this.drpProviderBranch.Enabled = false;
                    if (num1 != 0)
                    {
                        DataTable branchInformation = challanBLL.GetBranchInformation(num2, num1);
                        if (branchInformation != null && branchInformation.Rows.Count > 0)
                        {
                            this.drpProviderBranch.Items.Clear();
                            this.drpProviderBranch.DataSource = branchInformation;
                            this.drpProviderBranch.DataTextField = branchInformation.Columns["branch_unit_name"].ToString();
                            this.drpProviderBranch.DataValueField = branchInformation.Columns["org_branch_reg_id"].ToString();
                            this.drpProviderBranch.DataBind();
                        }
                    }
                    else
                    {
                        this.drpProviderBranch.Items.Clear();
                    }
                }
                if (num == 2 || num == 1 || num == 3)
                {
                    this.drpProviderBranch.Enabled = true;
                    DataTable branchInformationFormanagerNew = challanBLL.GetBranchInformationFormanagerNew(num2, num1);
                    if (branchInformationFormanagerNew != null && branchInformationFormanagerNew.Rows.Count > 0)
                    {
                        this.drpProviderBranch.DataSource = branchInformationFormanagerNew;
                        this.drpProviderBranch.DataTextField = branchInformationFormanagerNew.Columns["branch_unit_name"].ToString();
                        this.drpProviderBranch.DataValueField = branchInformationFormanagerNew.Columns["org_branch_reg_id"].ToString();
                        this.drpProviderBranch.DataBind();
                    }
                }
                ListItem listItem = new ListItem("--Select--", "0");
                this.drpProviderBranch.Items.Insert(0, listItem);
                this.drpProviderBranch.SelectedValue = "0";
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
                    this.drpReceipentBranch.Enabled = false;
                    if (num1 != 0)
                    {
                        DataTable selectedBusinessUnitBranchInfo = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                        if (selectedBusinessUnitBranchInfo != null && selectedBusinessUnitBranchInfo.Rows.Count > 0)
                        {
                            this.drpReceipentBranch.Items.Clear();
                            this.drpReceipentBranch.DataSource = selectedBusinessUnitBranchInfo;
                            this.drpReceipentBranch.DataTextField = selectedBusinessUnitBranchInfo.Columns["branch_unit_name"].ToString();
                            this.drpReceipentBranch.DataValueField = selectedBusinessUnitBranchInfo.Columns["org_branch_reg_id"].ToString();
                            this.drpReceipentBranch.DataBind();
                        }
                    }
                    else
                    {
                        this.drpReceipentBranch.Items.Clear();
                        ListItem listItem = new ListItem("Head Office", "0");
                        this.drpReceipentBranch.Items.Insert(0, listItem);
                    }
                    this.GetBranchRcvrAddress();
                    this.GetBranchRcvrBIN();
                }
                if (num == 2 || num == 1)
                {
                    this.drpReceipentBranch.Enabled = true;
                    DataTable dataTable = challanBLL.GetSelectedBusinessUnitBranchInfo(num2, num1);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.drpReceipentBranch.Items.Clear();
                        this.drpReceipentBranch.DataSource = dataTable;
                        this.drpReceipentBranch.DataTextField = dataTable.Columns["branch_unit_name"].ToString();
                        this.drpReceipentBranch.DataValueField = dataTable.Columns["org_branch_reg_id"].ToString();
                        this.drpReceipentBranch.DataBind();
                    }
                    this.GetBranchRcvrAddress();
                    this.GetBranchRcvrBIN();
                }
            }
        }

        private void getGridData()
        {
            ArrayList arrayLists = new ArrayList();
            try
            {
                foreach (GridViewRow row in this.gvItem.Rows)
                {
                    ProductTransferDetail productTransferDetail = new ProductTransferDetail();
                    short num = Convert.ToInt16(this.gvItem.DataKeys[row.RowIndex]["row_no"]);
                    productTransferDetail.RowNo = num;
                    HiddenField hiddenField = row.FindControl("item_id") as HiddenField;
                    productTransferDetail.ItemId = Convert.ToInt32(hiddenField.Value);
                    productTransferDetail.Item = row.Cells[4].Text;
                    productTransferDetail.BrandName = row.Cells[22].Text;
                    productTransferDetail.Unit = row.Cells[6].Text;
                    productTransferDetail.unit_price = Convert.ToDecimal(row.Cells[19].Text);
                    productTransferDetail.vat_amount = Convert.ToDecimal(row.Cells[20].Text);
                    productTransferDetail.sd_amount = Convert.ToDecimal(row.Cells[21].Text);
                    HiddenField hiddenField1 = row.FindControl("unit_id") as HiddenField;
                    productTransferDetail.UnitID = Convert.ToInt16(hiddenField1.Value);
                    HiddenField hiddenField2 = row.FindControl("property_id1") as HiddenField;
                    productTransferDetail.Property1 = Convert.ToInt16(hiddenField2.Value);
                    HiddenField hiddenField3 = row.FindControl("property_id2") as HiddenField;
                    productTransferDetail.Property2 = Convert.ToInt16(hiddenField3.Value);
                    HiddenField hiddenField4 = row.FindControl("property_id3") as HiddenField;
                    productTransferDetail.Property3 = Convert.ToInt16(hiddenField4.Value);
                    HiddenField hiddenField5 = row.FindControl("property_id4") as HiddenField;
                    productTransferDetail.Property4 = Convert.ToInt16(hiddenField5.Value);
                    HiddenField hiddenField6 = row.FindControl("property_id5") as HiddenField;
                    productTransferDetail.Property5 = Convert.ToInt16(hiddenField6.Value);
                    double num1 = Convert.ToDouble(row.Cells[23].Text);
                    TextBox textBox = row.FindControl("received_quantity") as TextBox;
                    double num2 = Convert.ToDouble(textBox.Text);
                    productTransferDetail.Remark = row.Cells[17].Text;
                    productTransferDetail.PurchaseType = char.Parse(row.Cells[18].Text);
                    productTransferDetail.Quantity = Convert.ToInt32(textBox.Text);
                    productTransferDetail.UserID = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
                    if (num2 >= num1)
                    {
                        productTransferDetail.IsFullReceive = true;
                    }
                    arrayLists.Add(productTransferDetail);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            this.Session["DETAIL_INFO"] = arrayLists;
        }

        private void getProductInfo()
        {
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
                this.Session["RBRANCH_INFO"] = allBranchByOrgID;
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
                int num = Convert.ToInt16(e.RowIndex);
                DataTable item = (DataTable)this.Session["DETAIL_INFO"];
                DataRow dataRow = item.Rows[num];
                item.Rows.Remove(dataRow);
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
                ListItem listItem = new ListItem("--- Select ---", "-99");
                this.drpCategory.Items.Insert(0, listItem);
            }
        }

        private void LoadGrid()
        {
            try
            {
                ProductTransferBLL productTransferBLL = new ProductTransferBLL();
                string str = this.drpChallanNo.SelectedItem.ToString();
                DataTable issuedItemsbyChallan = productTransferBLL.getIssuedItemsbyChallan(str);
                this.lblProp1.Text = issuedItemsbyChallan.Rows[0]["Property_id1"].ToString();
                this.lblProp2.Text = issuedItemsbyChallan.Rows[0]["Property_id2"].ToString();
                this.lblProp3.Text = issuedItemsbyChallan.Rows[0]["Property_id3"].ToString();
                this.lblProp4.Text = issuedItemsbyChallan.Rows[0]["Property_id4"].ToString();
                this.lblProp5.Text = issuedItemsbyChallan.Rows[0]["Property_id5"].ToString();
                this.fillDetailData();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void loadGridView()
        {
            DataTable item = (DataTable)this.Session["DETAIL_INFO"];
            if (item != null)
            {
                this.gvItem.DataSource = item;
                this.gvItem.DataBind();
            }
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
            DataTable finishGoodsProductByCategoryId = null;
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
                    finishGoodsProductByCategoryId = addItemBLL.getFinishGoodsProductByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem);
                }
                if (this.drpType.SelectedIndex == 1)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getFinishGoodsProductByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem1 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem1);
                }
                if (this.drpType.SelectedIndex == 2)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getFinishGoodsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem2 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem2);
                }
                if (this.drpType.SelectedIndex == 3)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getIngredientsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem3 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem3);
                }
                if (this.drpType.SelectedIndex == 4)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getGoodsByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem4 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem4);
                }
                if (this.drpType.SelectedIndex == 5)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getRealStateByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem5 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem5);
                }
                if (this.drpType.SelectedIndex == 6)
                {
                    finishGoodsProductByCategoryId = addItemBLL.getMedicineByCategoryId(num);
                    this.drpItem.DataSource = finishGoodsProductByCategoryId;
                    this.drpItem.DataTextField = finishGoodsProductByCategoryId.Columns["item_name"].ToString();
                    this.drpItem.DataValueField = finishGoodsProductByCategoryId.Columns["Item_id"].ToString();
                    this.drpItem.DataBind();
                    ListItem listItem6 = new ListItem("---Select---", "-99");
                    this.drpItem.Items.Insert(0, listItem6);
                }
                this.Session["ITEM_INFO"] = finishGoodsProductByCategoryId;
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
                    this.txtChallanReceiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.LoadHours();
                    this.LoadMinutes();
                    this.drpChDtHr.SelectedValue = DateTime.Now.Hour.ToString("00");
                    this.drpChDtMin.SelectedValue = DateTime.Now.Minute.ToString("00");
                    this.LoadCategory("C");
                    ListItem listItem = new ListItem("-- Select --", "-99");
                    this.drpCategory.Items.Insert(0, listItem);
                    UtilityK.fillSubCategoryByCatDropDownList(this.drpCategory, this.drpSubCategory);
                    this.drpSubCategory.Items.Insert(0, listItem);
                    this.LoadItems();
                    this.GetBranchRcvrInformation();
                    this.GetBranchInProviderformation();
                    UtilityK.fillVehicleTypeDropDownList(this.drpVehicleType);
                    ListItem listItem1 = new ListItem("-- SELECT --", "-99");
                    this.drpVehicleType.Items.Insert(0, listItem1);
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

        private void reportShow()
        {
            ProductTransferMaster productTransferMaster = new ProductTransferMaster();
            string[] strArrays = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
            string[] strArrays1 = strArrays;
            string[] strArrays2 = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };
            string[] strArrays3 = strArrays2;
            productTransferMaster = (ProductTransferMaster)this.Session["MASTER_DATA"];
            if (productTransferMaster == null)
            {
                this.msgBox.AddMessage("Please Save Your Data First...", MsgBoxs.enmMessageType.Attention);
            }
            else
            {
                this.lblOrgName.Text = productTransferMaster.OrgName;
                this.lblOrgBIN.Text = productTransferMaster.OrgBIN;
                this.lblPNameAddress.Text = string.Concat(productTransferMaster.ProviderName, ",", productTransferMaster.ProviderAddress);
                this.lblReceipentAddress.Text = string.Concat(productTransferMaster.ReceipentName, ",", productTransferMaster.ReceipentAddress);
                this.lblChallanNo.Text = productTransferMaster.ChallanNo;
                Label str = this.lblIssueDate;
                DateTime dateTime = Convert.ToDateTime(productTransferMaster.IssueDate);
                str.Text = dateTime.ToString("dd-MMM-yyyy");
                Label label = this.lblIssueTime;
                DateTime dateTime1 = Convert.ToDateTime(productTransferMaster.IssueTime);
                label.Text = dateTime1.ToString("hh:mm tt");
            }
            if (productTransferMaster.VehicleNo == "")
            {
                this.txtTransport.Text = string.Concat(productTransferMaster.VehicleTypeName, " ", productTransferMaster.VehicleNo);
            }
            else
            {
                this.txtTransport.Text = string.Concat(productTransferMaster.VehicleTypeName, ", ", productTransferMaster.VehicleNo);
            }
            ArrayList item = (ArrayList)this.Session["DETAIL_INFO"];
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
                string[] strArrays4 = new string[] { str5, "<td style='border:1px solid gray;text-align: center'>", Utilities.formatFraction(productTransferDetail.Quantity), "  ", productTransferDetail.Unit, "</td>" };
                str1 = string.Concat(strArrays4);
                str1 = string.Concat(str1, "<td style='border:1px solid gray;text-align: center'>", num.ToString("N2"), "</td>");
                str1 = string.Concat(str1, "<td style='border:1px solid gray'>", productTransferDetail.Remark, "</td>");
                str1 = string.Concat(str1, "</tr>");
                this.tblProductTransferChallan.Text = str1;
            }
            this.lblDutyOfficer.Text = this.Session["EMPLOYEE_NAME"].ToString();
            this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
            this.ptPrint.Visible = true;
            this.btnShowReport.Text = "Hide Report";
            this.btnPrint.Visible = true;
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
            DataTable item = (DataTable)this.Session["DETAIL_INFO"];
            string str1 = "T";
            int num = Convert.ToInt32(item.Rows[0]["item_id"]);
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            num1 = Convert.ToInt32(this.drpChallanNo.SelectedValue);
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
                Dictionary<int, int> nums = (Dictionary<int, int>)this.Session["chkProperty"];
                if (nums.Count > 0 && str == "")
                {
                    for (int j = 0; j < this.gvAddtnProperty.Rows.Count; j++)
                    {
                        CheckBox checkBox = (CheckBox)this.gvAddtnProperty.Rows[j].FindControl("chkChallan");
                        int num4 = Convert.ToInt32(((HiddenField)this.gvAddtnProperty.Rows[j].FindControl("additionalInfoId")).Value);
                        foreach (int key in nums.Keys)
                        {
                            int num5 = key;
                            if (!nums.ContainsKey(num5) || num4 != num5)
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

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
        }

        private bool validation()
        {
            if (this.drpProviderBranch.SelectedValue == "0")
            {
                this.msgBox.AddMessage("প্রেরণকারী শাখার নাম সিলেক্ট করুন", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.drpChallanNo.SelectedValue == "0")
            {
                this.msgBox.AddMessage("Please Select Challan No.", MsgBoxs.enmMessageType.Info);
                return false;
            }
            if (this.txtChallanReceiveDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Enter Issue Date.", MsgBoxs.enmMessageType.Info);
                this.txtChallanReceiveDate.Focus();
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
                    TextBox textBox = (TextBox)this.gvItem.Rows[0].FindControl("received_quantity");
                    if (arrayLists.Count != Convert.ToDecimal(textBox.Text))
                    {
                        this.msgBox.AddMessage("No of. Item Quantity and Property not equal.", MsgBoxs.enmMessageType.Error);
                        return false;
                    }
                }
            }
            return true;
        }

    }
}