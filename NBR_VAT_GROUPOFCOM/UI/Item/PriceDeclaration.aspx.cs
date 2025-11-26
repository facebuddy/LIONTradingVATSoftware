using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class PriceDeclaration : Page, IRequiresSessionState
    {
        private NBR_VAT_GROUPOFCOM.BLL.SaleBLL objsaleBLL = new NBR_VAT_GROUPOFCOM.BLL.SaleBLL();

        private static NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionBLL objPDBll;

        private NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAO objPDDao = new NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAO();

        private NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionRawDAO objPDRDao = new NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionRawDAO();

        private NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionValueAdditionDAO objPDVADao = new NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionValueAdditionDAO();

        private NBR_VAT_GROUPOFCOM.BLL.SetItemBLL ItemBll = new NBR_VAT_GROUPOFCOM.BLL.SetItemBLL();

        private NBR_VAT_GROUPOFCOM.BLL.SetItemBLL objSIBll = new NBR_VAT_GROUPOFCOM.BLL.SetItemBLL();

        private NBR_VAT_GROUPOFCOM.BLL.SetItemSetDAO objPriceRowItemDAO = new NBR_VAT_GROUPOFCOM.BLL.SetItemSetDAO();

        private DataTable dt = new DataTable();

        private DataColumn dc = new DataColumn();

        private CommonReports reports = new CommonReports();

        private NBR_VAT_GROUPOFCOM.BLL.OrgRegistrationInfoDAO orgReg = new NBR_VAT_GROUPOFCOM.BLL.OrgRegistrationInfoDAO();

        private NBR_VAT_GROUPOFCOM.BLL.OrgRegistrationInfoDAO orgRegInfo = new NBR_VAT_GROUPOFCOM.BLL.OrgRegistrationInfoDAO();

        private NBR_VAT_GROUPOFCOM.BLL.AddItemBLL objBLL = new NBR_VAT_GROUPOFCOM.BLL.AddItemBLL();

        private decimal decValueAdditionTotal;

        private int itemRowNo = 10;

        private decimal totalAmount;

        private decimal netUsedAmount;

        private decimal totalWastageAmount;

        private decimal grossTotalAmount;

        private object ActiveTab;

        private object Me;

     

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

        static PriceDeclaration()
        {
            PriceDeclaration.objPDBll = new NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionBLL();
        }

        public PriceDeclaration()
        {
        }

        protected DataTable addColumnsToDataTable(DataTable dt)
        {
            dt.Columns.Add("row_no");
            dt.Columns.Add("item_id");
            dt.Columns.Add("unit_id");
            dt.Columns.Add("unit_id_sec");
            dt.Columns.Add("stock");
            dt.Columns.Add("gross_usages");
            dt.Columns.Add("wastage_percent");
            dt.Columns.Add("wastage");
            dt.Columns.Add("neat_usages");
            dt.Columns.Add("shipment_quantity");
            dt.Columns.Add("shipment_cost");
            dt.Columns.Add("number_of_production");
            dt.Columns.Add("cost");
            dt.Columns.Add("reference");
            dt.Columns.Add("remarks");
            return dt;
        }

        private void AddNewRowToGrid()
        {
            int num = 0;
            if (this.ViewState["CurrentTable"] != null)
            {
                DataTable item = (DataTable)this.ViewState["CurrentTable"];
                DataRow str = null;
                if (item.Rows.Count > 0)
                {
                    for (int i = 1; i <= item.Rows.Count; i++)
                    {
                        DropDownList dropDownList = (DropDownList)this.gvItems.Rows[num].FindControl("drpCategory");
                        DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[num].FindControl("drpItemName");
                        Label label = (Label)this.gvItems.Rows[num].FindControl("lblItemUnitId");
                        Label label1 = (Label)this.gvItems.Rows[num].FindControl("lblItemUnit");
                        TextBox textBox = (TextBox)this.gvItems.Rows[num].FindControl("txtItemQuantity");
                        TextBox textBox1 = (TextBox)this.gvItems.Rows[num].FindControl("txtAvailableStock");
                        DropDownList dropDownList2 = (DropDownList)this.gvItems.Rows[num].FindControl("ddlUnit");
                        DropDownList dropDownList3 = (DropDownList)this.gvItems.Rows[num].FindControl("ddlUnitSec");
                        DropDownList dropDownList4 = (DropDownList)this.gvItems.Rows[num].FindControl("ddlUnitChallan");
                        TextBox textBox2 = (TextBox)this.gvItems.Rows[num].FindControl("txtQuantity");
                        TextBox textBox3 = (TextBox)this.gvItems.Rows[num].FindControl("txtQuantityTotal");
                        TextBox textBox4 = (TextBox)this.gvItems.Rows[num].FindControl("txtWastageParcent");
                        TextBox textBox5 = (TextBox)this.gvItems.Rows[num].FindControl("txtWastage");
                        TextBox textBox6 = (TextBox)this.gvItems.Rows[num].FindControl("txtChallanPrice");
                        TextBox textBox7 = (TextBox)this.gvItems.Rows[num].FindControl("txtChallanQuantity");
                        TextBox textBox8 = (TextBox)this.gvItems.Rows[num].FindControl("txtProductionQuantity");
                        DropDownList dropDownList5 = (DropDownList)this.gvItems.Rows[num].FindControl("txtReference");
                        TextBox textBox9 = (TextBox)this.gvItems.Rows[num].FindControl("txtQuantity");
                        TextBox textBox10 = (TextBox)this.gvItems.Rows[num].FindControl("txtRemarks");
                        str = item.Rows[i - 1];
                        str["HIDDEN_ROW_ID"] = 1;
                        str["drpCategoryValue"] = dropDownList.SelectedValue.ToString();
                        str["drpItemNameValue"] = dropDownList1.SelectedValue.ToString();
                        str["lblItemUnitIdValue"] = label.Text.Trim();
                        str["lblItemUnitValue"] = label1.Text.Trim();
                        str["txtAvailableStock"] = textBox1.Text.Trim();
                        str["txtItemQuantity"] = textBox.Text.Trim();
                        str["ddlUnit"] = dropDownList2.SelectedValue.ToString();
                        str["ddlUnitSec"] = dropDownList3.SelectedValue.ToString();
                        str["ddlUnitChallan"] = dropDownList4.SelectedValue.ToString();
                        str["txtPriceValue"] = textBox2.Text.Trim();
                        str["txtWastageValue"] = textBox5.Text.Trim();
                        str["txtQuantityTotal"] = textBox3.Text.Trim();
                        str["txtWastageParcent"] = textBox4.Text.Trim();
                        str["txtWastage"] = textBox5.Text.Trim();
                        str["txtChallanPrice"] = textBox6.Text.Trim();
                        str["txtChallanQuantity"] = textBox7.Text.Trim();
                        str["txtProductionQuantity"] = textBox8.Text.Trim();
                        str["txtReference"] = dropDownList5.SelectedValue.ToString();
                        str["txtQuantity"] = textBox9.Text.Trim();
                        str["txtRemarks"] = textBox10.Text.Trim();
                        num++;
                    }
                    int newRowNumberForAdd = this.getNewRowNumberForAdd();
                    for (int j = 0; j < newRowNumberForAdd; j++)
                    {
                        DataRow dataRow = item.NewRow();
                        item.Rows.Add(dataRow);
                    }
                    this.ViewState["CurrentTable"] = item;
                    this.gvItems.DataSource = item;
                    this.gvItems.DataBind();
                    for (int k = 0; k < this.gvItems.Rows.Count; k++)
                    {
                        DropDownList dropDownList6 = (DropDownList)this.gvItems.Rows[k].FindControl("drpItemName");
                        DropDownList dropDownList7 = (DropDownList)this.gvItems.Rows[k].FindControl("ddlUnit");
                        DropDownList dropDownList8 = (DropDownList)this.gvItems.Rows[k].FindControl("ddlUnitSec");
                        DropDownList str1 = (DropDownList)this.gvItems.Rows[k].FindControl("txtReference");
                        string str2 = item.Rows[k]["drpItemNameValue"].ToString();
                        if (str2 != "")
                        {
                            int num1 = Convert.ToInt16(str2);
                            DataTable itemChallaNo = this.objBLL.GetItemChallaNo(num1);
                            if (itemChallaNo.Rows.Count > 0)
                            {
                                str1.DataSource = itemChallaNo;
                                str1.DataTextField = itemChallaNo.Columns["challan_no"].ToString();
                                str1.DataValueField = itemChallaNo.Columns["challan_id"].ToString();
                                str1.DataBind();
                            }
                            ListItem listItem = new ListItem("-- Select ---", "-99");
                            str1.Items.Insert(0, listItem);
                        }
                        ListItem listItem1 = new ListItem("-- Select ---", "-99");
                         BLL.Utility.fillAllRawItemForBOM(dropDownList6);
                         BLL.Utility.fillAllUnit(dropDownList7);
                         BLL.Utility.fillAllUnit(dropDownList8);
                        DropDownList dropDownList9 = (DropDownList)this.gvItems.Rows[num].FindControl("ddlUnitChallan");
                         BLL.Utility.fillAllUnit(dropDownList9);
                        dropDownList6.Items.Insert(0, listItem1);
                        dropDownList7.Items.Insert(0, listItem1);
                        dropDownList8.Items.Insert(0, listItem1);
                        dropDownList9.Items.Insert(0, listItem1);
                    }
                }
            }
            this.SetPreviousData();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.lblPriceId.Text.Trim());
            decimal num1 = Convert.ToDecimal(this.txtNBRSDChargablePrice.Text.Trim());
            decimal num2 = Convert.ToDecimal(this.txtNBRSD.Text.Trim());
            decimal num3 = Convert.ToDecimal(this.txtNBRVATChargeablePrice.Text.Trim());
            decimal num4 = Convert.ToDecimal(this.txtNBRWholeSalePrice.Text.Trim());
            decimal num5 = Convert.ToDecimal(this.txtNBRRetailPrice.Text.Trim());
            string str = this.dtpNBRApproveDate.Text.ToString();
            DateTime formattedDateMMDDYYYY =  BLL.Utility.GetFormattedDateMMDDYYYY(str);
            decimal num6 = Convert.ToDecimal(this.txtNBRPrice.Text.Trim());
            this.objPDDao.intPriceID = Convert.ToInt32(this.lblPriceId.Text.Trim());
            if (!PriceDeclaration.objPDBll.updatePrice(num, num1, num2, num3, num4, num5, formattedDateMMDDYYYY, num6))
            {
                this.msgBox.AddMessage("Fail to Update.", MsgBoxs.enmMessageType.Error);
            }
            else
            {
                this.msgBox.AddMessage("Item Price Information Successfully Updated.", MsgBoxs.enmMessageType.Success);
                this.showDataInGridView();
                this.setAddMode();
                this.clearFrom();
                if (this.gvValueAddition.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvNBRValueAddition.Rows.Count; i++)
                    {
                        int num7 = Convert.ToInt32(this.lblPriceId.Text);
                        decimal num8 = Convert.ToDecimal(((TextBox)this.gvNBRValueAddition.Rows[i].FindControl("txtValueAddition0")).Text.ToString());
                        PriceDeclaration.objPDBll.updatePDValueAdd(num7, num8, 1);
                    }
                    return;
                }
            }
        }

        protected void btnClearAllRawItem_Click(object sender, EventArgs e)
        {
            this.Session["dtInSession"] = null;
            this.clearRawItem();
        }

        protected void btnRawItemSave_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (this.dt.Columns.Count == 0)
            {
                this.dt.Columns.Add("row_id", typeof(int));
                this.dt.Columns.Add("item_id", typeof(string));
                this.dt.Columns.Add("item_name", typeof(string));
                this.dt.Columns.Add("price", typeof(decimal));
                this.dt.Columns.Add("quantity", typeof(decimal));
                this.dt.Columns.Add("depreciation", typeof(decimal));
            }
            if (this.Session["dtInSession"] != null)
            {
                this.dt = (DataTable)this.Session["dtInSession"];
            }
        }

        protected void btnRefreshChallan1_Click(object sender, EventArgs e)
        {
            this.clearFrom();
        }

        protected void btnRefreshItem_Click(object sender, EventArgs e)
        {
        }

        protected void btnRefreshRawItem_Click(object sender, EventArgs e)
        {
            this.clearRawItem();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.msgBox.Visible = true;
            if (!this.Validation())
            {
                this.GetTotalValue();
            }
            else
            {
                DataTable dataTable = PriceDeclaration.objPDBll.IsExistDeclaretion(this.txtPriceDeclaretionNo.Text.ToString());
                if (dataTable == null || dataTable.Rows.Count <= 0)
                {
                    this.Session["PriceId"] = PriceDeclaration.objPDBll.intPDId();
                    this.objPDDao = this.insertPriceDeclaration(this.objPDDao);
                    ArrayList arrayLists = new ArrayList();
                    ArrayList arrayLists1 = new ArrayList();
                    ArrayList arrayLists2 = new ArrayList();
                    arrayLists = this.getRowItemPriceProperties(arrayLists);
                    int num = 1;
                    if (this.gvValueAddition.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.gvValueAddition.Rows.Count; i++)
                        {
                           NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAOVlueAdditional priceDeclaretionDAOVlueAdditional = new NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAOVlueAdditional()
                            {
                                intPriceId = (int)this.Session["PriceId"],
                                intValueAdditionItemD = Convert.ToInt32(((Label)this.gvValueAddition.Rows[i].FindControl("lblID")).Text),
                                decItemValue = Convert.ToDecimal(((TextBox)this.gvValueAddition.Rows[i].FindControl("txtValueAddition")).Text.ToString()),
                                decItemValuePct = Convert.ToDecimal(((TextBox)this.gvValueAddition.Rows[i].FindControl("txtValueAdditionpct")).Text.ToString())
                            };
                            arrayLists1.Add(priceDeclaretionDAOVlueAdditional);
                        }
                    }
                    if (this.gvValueAdditionNonItem.Rows.Count > 0)
                    {
                        for (int j = 0; j < this.gvValueAdditionNonItem.Rows.Count; j++)
                        {
                            NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAONonVlueAdditional priceDeclaretionDAONonVlueAdditional = new NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAONonVlueAdditional()
                            {
                                intPriceIdnon = (int)this.Session["PriceId"],
                                intValueAdditionItemDnon = Convert.ToInt32(((Label)this.gvValueAdditionNonItem.Rows[j].FindControl("lblID2")).Text),
                                decItemValuenon = Convert.ToDecimal(((TextBox)this.gvValueAdditionNonItem.Rows[j].FindControl("txtValueAdditionNonItem")).Text.ToString())
                            };
                            arrayLists2.Add(priceDeclaretionDAONonVlueAdditional);
                        }
                    }
                    if (!PriceDeclaration.objPDBll.InsertPDN(this.objPDDao, arrayLists, arrayLists1, num, arrayLists2))
                    {
                        this.msgBox.AddMessage("Information: Failed to save.", MsgBoxs.enmMessageType.Error);
                        return;
                    }
                    this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    this.clearFrom();
                    return;
                }
                int num1 = Convert.ToInt16(dataTable.Rows[0]["price_id"].ToString());
                if (this.gvValueAddition.Rows.Count > 0)
                {
                    for (int k = 0; k < this.gvValueAddition.Rows.Count; k++)
                    {
                        int num2 = 8;
                        int num3 = Convert.ToInt32(((Label)this.gvValueAddition.Rows[k].FindControl("lblID")).Text);
                        DataTable dataTable1 = PriceDeclaration.objPDBll.IsExistValueAddition(num1, num3, num2);
                        decimal num4 = Convert.ToDecimal(((TextBox)this.gvValueAddition.Rows[k].FindControl("txtValueAddition")).Text.ToString());
                        decimal num5 = Convert.ToDecimal(((TextBox)this.gvValueAddition.Rows[k].FindControl("txtValueAdditionpct")).Text.ToString());
                        int num6 = 1;
                        if (dataTable1.Rows.Count > 0)
                        {
                            PriceDeclaration.objPDBll.UpdatePDValueAddtn(num1, num3, num4, num6, num2, num5);
                        }
                        else if (num4 > new decimal(0))
                        {
                            PriceDeclaration.objPDBll.InsertPDValueAdd(num1, num3, num4, num6, num5);
                        }
                    }
                }
                if (this.gvValueAdditionNonItem.Rows.Count > 0)
                {
                    for (int l = 0; l < this.gvValueAdditionNonItem.Rows.Count; l++)
                    {
                        int num7 = 14;
                        int num8 = Convert.ToInt32(((Label)this.gvValueAdditionNonItem.Rows[l].FindControl("lblID2")).Text);
                        DataTable dataTable2 = PriceDeclaration.objPDBll.IsExistValueAddition(num1, num8, num7);
                        decimal num9 = Convert.ToDecimal(((TextBox)this.gvValueAdditionNonItem.Rows[l].FindControl("txtValueAdditionNonItem")).Text.ToString());
                        int num10 = 1;
                        if (dataTable2.Rows.Count > 0)
                        {
                            PriceDeclaration.objPDBll.UpdatePDValueAddtn(num1, num8, num9, num10, num7, new decimal(0));
                        }
                        else if (num9 > new decimal(0))
                        {
                            PriceDeclaration.objPDBll.InsertPDValueAddNonItem(num1, num8, num9, num10);
                        }
                    }
                }
                this.Session["PriceId"] = dataTable.Rows[0]["price_id"].ToString();
                bool flag = this.UpdateRowProdrouctItems();
                this.objPDDao = this.insertPriceDeclarationFUpdate(this.objPDDao);
                bool flag1 = PriceDeclaration.objPDBll.UpdatePD(this.objPDDao);
                if (flag && flag1)
                {
                    this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    this.clearFrom();
                    return;
                }
            }
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Session["tobacco"] = "";
            this.showDataInGridViewBySearch(Convert.ToInt16(this.drpSearchItem.SelectedValue));
        }

        protected void btnSearchPriceDeclaretionNo_Click(object sender, EventArgs e)
        {
            string str = this.txtPriceDeclaretionNo.Text.ToString();
            DataTable dataTable = PriceDeclaration.objPDBll.serachRawMaterialByDeclarationNO(str);
            if (dataTable.Rows.Count <= 0)
            {
                this.txtVATRate.Text = "0";
            }
            else
            {
                this.txtVATRate.Text = dataTable.Rows[0]["tax_value"].ToString();
                this.ddlItemCategory.SelectedValue = dataTable.Rows[0]["category_id"].ToString();
                this.ddlItem.SelectedValue = dataTable.Rows[0]["item_id"].ToString();
                this.lblUnit.Text = PriceDeclaration.objPDBll.strItemUnitName(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString())).ToString();
                this.ddlYear.SelectedValue = dataTable.Rows[0]["price_declaration_year"].ToString();
                this.txtProposedPrice.Text = dataTable.Rows[0]["prpsd_actl_prc"].ToString();
                this.txtCurrentSDPrice.Text = dataTable.Rows[0]["crnt_actl_prc_sd"].ToString();
                this.txtProposedSDPrice.Text = dataTable.Rows[0]["prpsd_actl_prc_sd"].ToString();
                this.txtSD.Text = dataTable.Rows[0]["sd_amount"].ToString();
                this.txtCurrentVATPrice.Text = dataTable.Rows[0]["cnfrmd_actl_prc_sd"].ToString();
            }
            DataTable dataTable1 = PriceDeclaration.objPDBll.findRowProducts(str);
            if (dataTable1.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    DropDownList dropDownList = (DropDownList)this.gvItems.Rows[i].FindControl("drpItemName");
                    DropDownList str1 = (DropDownList)this.gvItems.Rows[i].FindControl("drpCategory");
                    DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnit");
                    TextBox textBox = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal");
                    TextBox textBox1 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastageParcent");
                    TextBox str2 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastage");
                    TextBox textBox2 = (TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity");
                    TextBox str3 = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanPrice");
                    TextBox textBox3 = (TextBox)this.gvItems.Rows[i].FindControl("txtProductionQuantity");
                    TextBox str4 = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantity");
                    str1.SelectedValue = dataTable1.Rows[i]["category_id"].ToString();
                    dropDownList.SelectedValue = dataTable1.Rows[i]["item_id"].ToString();
                    dropDownList1.SelectedValue = dataTable1.Rows[i]["Unit_id"].ToString();
                    int num = Convert.ToInt32(dataTable1.Rows[i]["quantity"].ToString()) + Convert.ToInt32(dataTable1.Rows[i]["wastage_quantity"].ToString());
                    textBox.Text = num.ToString();
                    textBox1.Text = dataTable1.Rows[i]["wastageparcent"].ToString();
                    str2.Text = dataTable1.Rows[i]["wastage_quantity"].ToString();
                    textBox2.Text = dataTable1.Rows[i]["quantity"].ToString();
                    str3.Text = dataTable1.Rows[i]["challanprice"].ToString();
                    textBox3.Text = dataTable1.Rows[i]["productionquantity"].ToString();
                    str4.Text = dataTable1.Rows[i]["txtquantityprice"].ToString();
                }
                DataTable valueAdddition = PriceDeclaration.objPDBll.getValueAdddition(str);
                if (valueAdddition.Rows.Count > 0)
                {
                    for (int j = 0; j < valueAdddition.Rows.Count; j++)
                    {
                        for (int k = 0; k < this.gvValueAddition.Rows.Count; k++)
                        {
                            Label label = (Label)this.gvValueAddition.Rows[k].FindControl("lblID");
                            TextBox textBox4 = (TextBox)this.gvValueAddition.Rows[k].FindControl("txtValueAddition");
                            if (label.Text.Equals(valueAdddition.Rows[j]["value_adtn_item_d"].ToString()))
                            {
                                textBox4.Text = valueAdddition.Rows[j]["item_value"].ToString();
                            }
                        }
                    }
                }
                DataTable valueAddditionNonItem = PriceDeclaration.objPDBll.getValueAddditionNonItem(str);
                if (valueAddditionNonItem.Rows.Count > 0)
                {
                    for (int l = 0; l < valueAddditionNonItem.Rows.Count; l++)
                    {
                        for (int m = 0; m < this.gvValueAdditionNonItem.Rows.Count; m++)
                        {
                            Label label1 = (Label)this.gvValueAdditionNonItem.Rows[m].FindControl("lblID2");
                            TextBox str5 = (TextBox)this.gvValueAdditionNonItem.Rows[m].FindControl("txtValueAdditionNonItem");
                            if (label1.Text.Equals(valueAddditionNonItem.Rows[l]["value_adtn_item_d"].ToString()))
                            {
                                str5.Text = valueAddditionNonItem.Rows[l]["item_value"].ToString();
                            }
                        }
                    }
                }
            }
        }

        protected void btnSubClear_Click(object sender, EventArgs e)
        {
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string lower = Path.GetExtension(this.FileUpload1.FileName).ToLower();
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            if (string.IsNullOrEmpty(lower))
            {
                this.msgBox.AddMessage(" File Path not Found! Please Brows Your File. ", MsgBoxs.enmMessageType.Attention);
                return;
            }
            string str1 = base.Server.MapPath(string.Concat("~/CSV/", this.FileUpload1.FileName));
            this.FileUpload1.SaveAs(str1);
            this.Label29.Text = string.Concat(this.FileUpload1.FileName, "'s Data showing into the GridView");
            if (lower.Trim() == ".xls")
            {
                str = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", str1, ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
            }
            else if (lower.Trim() == ".xlsx")
            {
                str = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", str1, ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"");
            }
            using (OleDbConnection oleDbConnection = new OleDbConnection(str))
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand())
                {
                    try
                    {
                        oleDbCommand.Connection = oleDbConnection;
                        oleDbConnection.Open();
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        this.msgBox.AddMessage(string.Concat(" Connection Failed! ", exception.Message), MsgBoxs.enmMessageType.Attention);
                        return;
                    }
                    DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    oleDbSchemaTable.Rows[0]["TABLE_NAME"].ToString();
                    oleDbCommand.CommandText = "SELECT * FROM [PrincipalInputs$]";
                    using (OleDbConnection oleDbConnection1 = new OleDbConnection(str))
                    {
                        using (OleDbCommand oleDbCommand1 = new OleDbCommand())
                        {
                            oleDbCommand1.Connection = oleDbConnection1;
                            oleDbConnection1.Open();
                            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand1))
                            {
                                oleDbCommand1.CommandText = "SELECT * FROM [PrincipalInputs$]";
                                oleDbDataAdapter.SelectCommand = oleDbCommand1;
                                oleDbDataAdapter.Fill(dataTable);
                                oleDbCommand1.CommandText = "SELECT * FROM [ValueAddition$]";
                                oleDbDataAdapter.SelectCommand = oleDbCommand1;
                                oleDbDataAdapter.Fill(dataTable1);
                                oleDbConnection.Close();
                            }
                        }
                    }
                    decimal num = new decimal(0);
                    decimal num1 = new decimal(0);
                    decimal num2 = new decimal(0);
                    decimal num3 = new decimal(0);
                    decimal num4 = new decimal(0);
                    List<PrincipalInput> principalInputs = new List<PrincipalInput>();
                    DataTable allItems = PriceDeclaration.objPDBll.getAllItems();
                    DataTable allUnits = PriceDeclaration.objPDBll.getAllUnits();
                    for (int i = 1; i < dataTable.Rows.Count; i++)
                    {
                        Convert.ToInt16(i);
                        DataRow item = dataTable.Rows[i];
                        DataRow dataRow = allItems.AsEnumerable().Where<DataRow>((DataRow itm) => itm.Field<string>("item_name").ToLower() == item["ItemName"].ToString().ToLower()).SingleOrDefault<DataRow>();
                        DataRow dataRow1 = allUnits.AsEnumerable().Where<DataRow>((DataRow u) => u.Field<string>("unit_name").ToLower() == item["GrossUsagesUnit"].ToString().ToLower()).SingleOrDefault<DataRow>();
                        if (item != null && dataRow != null && dataRow1 != null)
                        {
                            PrincipalInput principalInput = this.makeNewPrincipalInput(i, item, dataRow, dataRow1);
                            if (principalInput.GrossUsages.HasValue)
                            {
                                decimal? grossUsages = principalInput.GrossUsages;
                                if ((grossUsages.GetValueOrDefault() != new decimal(0) ? true : !grossUsages.HasValue))
                                {
                                    num += Convert.ToDecimal(principalInput.GrossUsages);
                                }
                            }
                            if (principalInput.Wastage.HasValue)
                            {
                                decimal? wastage = principalInput.Wastage;
                                if ((wastage.GetValueOrDefault() != new decimal(0) ? true : !wastage.HasValue))
                                {
                                    num1 += Convert.ToDecimal(principalInput.Wastage);
                                }
                            }
                            if (principalInput.NeatUsages.HasValue)
                            {
                                decimal? neatUsages = principalInput.NeatUsages;
                                if ((neatUsages.GetValueOrDefault() != new decimal(0) ? true : !neatUsages.HasValue))
                                {
                                    num2 += Convert.ToDecimal(principalInput.NeatUsages);
                                }
                            }
                            if (principalInput.Cost.HasValue)
                            {
                                decimal? cost = principalInput.Cost;
                                if ((cost.GetValueOrDefault() != new decimal(0) ? true : !cost.HasValue))
                                {
                                    num3 += Convert.ToDecimal(principalInput.Cost);
                                }
                            }
                            principalInputs.Add(principalInput);
                        }
                    }
                    if (dataTable1.Rows.Count > 0 && this.gvValueAddition.Rows.Count > 0)
                    {
                        for (int j = 0; j < this.gvValueAddition.Rows.Count; j++)
                        {
                            decimal num5 = Convert.ToDecimal(dataTable1.Rows[0][j]);
                            if (num5 > new decimal(0))
                            {
                                num4 += num5;
                                TextBox textBox = (TextBox)this.gvValueAddition.Rows[j].FindControl("txtValueAddition");
                                textBox.Text = num5.ToString();
                            }
                        }
                    }
                    this.txtSumQuantityTotal.Text = num.ToString();
                    this.txtSumWastage.Text = num1.ToString();
                    this.txtSumItemQuantity.Text = num2.ToString();
                    this.txtTotalPrice.Text = num3.ToString("N2");
                    this.txtTotalExpenses.Text = num4.ToString();
                    this.showExcelDataIntoGrid(this.formatExcelDataForGrid(principalInputs));
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.AddNewRowToGrid();
                this.GetTotalValue();
                string str = "";
                str = this.Session["tobacco"].ToString();
                if (str == "2402.20.00" || str == "2402.90.00")
                {
                    this.GetValueForTobacco();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                 BLL.Utility.InsertErrorTrackNew(exception.Message, "PriceDeclaration", "ButtonAdd_Click", fileLineNumber);
            }
        }

        private void CalculateTradePrice()
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                num = (this.txtTradePricePct.Text != "" || this.txtTradePricePct.Text != "0" ? Convert.ToDecimal(this.txtTradePricePct.Text.Trim()) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(this.txtProposedPrice.Text) ? Convert.ToDecimal(this.txtProposedPrice.Text) : new decimal(0));
                num2 = num + new decimal(100);
                num3 = num1 - ((num / num2) * num1);
                if (this.txtTradePricePct.Text != "0")
                {
                    this.txtTradePriceValue.Text = num3.ToString("0.0000");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void clearFrom()
        {
            this.showItemEntryGirdView(this.itemRowNo);
            this.btnSave.Text = "Save Declaretion";
            this.setAddMode();
            this.txtsongkha.Text = "";
            this.txthlthcharge.Text = "";
            this.lblhlthcharge.Text = "";
            this.drpProperty.SelectedValue = "-99";
            this.clearRawItem();
            this.Session["dtInSession"] = null;
            this.showValueAdditionDataInGridView();
            this.Session["ProposedSDChargablePrice"] = 0;
            this.Session["ProposedVATChargablePrice"] = 0;
            this.Session["PriceId"] = 0;
             BLL.Utility.fillYearList(this.ddlYear);
             BLL.Utility.fillAllItemCategory(this.ddlItemCategory);
            ListItem listItem = new ListItem("-- Select ---", "-99");
            if (this.ddlItemCategory.Items.Count > 0)
            {
                 BLL.Utility.fillAllItemByCategory(this.ddlItem, Convert.ToInt32(this.ddlItemCategory.SelectedValue.ToString()));
                ListItem listItem1 = new ListItem("-- Select ---", "-99");
                this.ddlItem.Items.Insert(0, listItem1);
            }
            this.txtCurrentSDPrice.Text = "0";
            this.txtCurrentVATPrice.Text = "0";
            this.txtPriceDeclaretionNo.Text = "";
            this.txtProposedSDPrice.Text = "0";
            this.txtProposedVATPrice.Text = "0";
            this.txtWholeSalePrice.Text = "0";
            this.txtRetailPrice.Text = "0";
            this.txtSD.Text = "0";
            this.txtProposedPrice.Text = "0";
            this.LoadItem();
            this.ddlItemCategory.Items.Clear();
            this.ddlItemSubCategory.Items.Clear();
            this.ddlYear.ClearSelection();
            this.txtActiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.gvDeclaretion.SelectedIndex = -1;
            this.lblUnit.Text = string.Empty;
            this.txtSDRate.Text = string.Empty;
            this.txtVATRate.Text = string.Empty;
            this.txtSumQuantityTotal.Text = string.Empty;
            this.txtSumWastage.Text = string.Empty;
            this.txtSumItemQuantity.Text = string.Empty;
            this.txtTotalPrice.Text = string.Empty;
            this.txtTotalExpenses.Text = string.Empty;
            this.gvDeclaretion.DataSource = null;
            this.gvDeclaretion.DataBind();
            this.drpSearchItem.ClearSelection();
            this.nonItemTotalExpense.Text = string.Empty;
        }

        private void clearRawItem()
        {
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Session["tobacco"] = "";
                int num = 0;
                num = Convert.ToInt16(this.ddlItem.SelectedItem.Value);
                DataTable dataTable = PriceDeclaration.objPDBll.gethsCodebyItemID(num);
                if (dataTable.Rows.Count <= 0)
                {
                    this.divStick.Visible = false;
                }
                else if (dataTable.Rows[0]["hs_code"].ToString() == "2402.20.00" || dataTable.Rows[0]["hs_code"].ToString() == "2402.90.00")
                {
                    this.lblhlthcharge.Text = "";
                    this.txthlthcharge.Text = "";
                    this.Session["tobacco"] = dataTable.Rows[0]["hs_code"].ToString();
                    DataTable propertyByCodeId = this.objsaleBLL.getPropertyByCodeId(8);
                    if (propertyByCodeId != null && propertyByCodeId.Rows.Count > 0)
                    {
                        this.divStick.Visible = true;
                        this.drpProperty.DataSource = propertyByCodeId;
                        this.drpProperty.DataTextField = propertyByCodeId.Columns["property_name"].ToString();
                        this.drpProperty.DataValueField = propertyByCodeId.Columns["property_id"].ToString();
                        this.drpProperty.DataBind();
                        ListItem listItem = new ListItem("---SELECT---", "-99");
                        this.drpProperty.Items.Insert(0, listItem);
                    }
                    DataTable healthChargebyItemID = PriceDeclaration.objPDBll.getHealthChargebyItemID(num);
                    if (healthChargebyItemID.Rows.Count > 0)
                    {
                        this.lblhlthcharge.Text = Utilities.formatFraction(Convert.ToDecimal(healthChargebyItemID.Rows[0]["health_surcharge"])).ToString();
                    }
                }
                else
                {
                    this.divStick.Visible = false;
                }
                this.fVAT.Text = "";
                this.ddlItemCategory.Items.Clear();
                this.ddlItemCategory.DataBind();
                DataTable categoryWithItem = PriceDeclaration.objPDBll.GetCategoryWithItem(Convert.ToInt16(this.ddlItem.SelectedItem.Value.ToString()));
                if (categoryWithItem != null && categoryWithItem.Rows.Count > 0)
                {
                    this.ddlItemCategory.DataSource = categoryWithItem;
                    this.ddlItemCategory.DataTextField = categoryWithItem.Columns["category_name"].ToString();
                    this.ddlItemCategory.DataValueField = categoryWithItem.Columns["category_id"].ToString();
                    this.ddlItemCategory.DataBind();
                }
                this.ddlItemSubCategory.Items.Clear();
                this.ddlItemSubCategory.DataBind();
                DataTable subCategoryWithItem = PriceDeclaration.objPDBll.GetSubCategoryWithItem(Convert.ToInt16(this.ddlItem.SelectedItem.Value.ToString()));
                if (subCategoryWithItem != null && subCategoryWithItem.Rows.Count > 0)
                {
                    this.ddlItemSubCategory.DataSource = subCategoryWithItem;
                    this.ddlItemSubCategory.DataTextField = subCategoryWithItem.Columns["category_name"].ToString();
                    this.ddlItemSubCategory.DataValueField = subCategoryWithItem.Columns["category_id"].ToString();
                    this.ddlItemSubCategory.DataBind();
                }
                this.txtSDRate.Text = "0";
                DataSet itemVatSdDetail = PriceDeclaration.objPDBll.getItemVatSdDetail(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
                if (itemVatSdDetail.Tables[0].Rows.Count <= 0)
                {
                    this.lblHSCode.Text = "";
                    this.lblUnit.Text = "";
                }
                else
                {
                    this.lblHSCode.Text = itemVatSdDetail.Tables[0].Rows[0]["hs_code"].ToString();
                    this.lblUnit.Text = PriceDeclaration.objPDBll.strItemUnitName(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString())).ToString();
                    this.txtSDRate.Text = itemVatSdDetail.Tables[0].Rows[0]["sd"].ToString();
                    this.txtVATRate.Text = itemVatSdDetail.Tables[0].Rows[0]["vat"].ToString();
                    this.lblmSDPercent.Text = itemVatSdDetail.Tables[0].Rows[0]["sd"].ToString();
                    this.lblmVatPercent.Text = itemVatSdDetail.Tables[0].Rows[0]["vat"].ToString();
                    if (itemVatSdDetail.Tables[0].Rows[0]["PER"].ToString() == "1")
                    {
                        this.fVAT.Text = " Per Unit.";
                    }
                }
                DataTable tradePrice = PriceDeclaration.objPDBll.getTradePrice(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
                if (tradePrice.Rows.Count > 0)
                {
                    this.txtTradePricePct.Text = tradePrice.Rows[0]["tax_value"].ToString();
                }
                if (!(Convert.ToDecimal(this.txtTradePricePct.Text.Trim()) > new decimal(0)) || tradePrice.Rows.Count <= 0)
                {
                    this.txtTradePricePct.Text = "0";
                    this.txtTradePriceValue.Text = "0";
                }
                else
                {
                    this.CalculateTradePrice();
                }
                this.GetRawMaterialSetForFinGd();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadFinishedGoods();
            if (this.ddlItem.SelectedValue.ToString() != "-99")
            {
                DataSet itemDetail = PriceDeclaration.objPDBll.getItemDetail(Convert.ToInt32(this.ddlItem.SelectedValue.ToString()));
                if (itemDetail.Tables[0].Rows.Count > 0)
                {
                    this.lblHSCode.Text = itemDetail.Tables[0].Rows[0]["hs_code"].ToString();
                    this.lblUnit.Text = PriceDeclaration.objPDBll.strItemUnitName(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString())).ToString();
                    return;
                }
                this.lblHSCode.Text = "";
                this.lblUnit.Text = "";
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
                TextBox textBox = (TextBox)namingContainer.FindControl("txtChallanQuantity");
                TextBox textBox1 = (TextBox)namingContainer.FindControl("txtQuantityTotal");
                TextBox str = (TextBox)namingContainer.FindControl("txtProductionQuantity");
                DropDownList dropDownList = (DropDownList)namingContainer.FindControl("ddlUnitSec");
                DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("ddlUnit");
                TextBox textBox2 = (TextBox)namingContainer.FindControl("txtChallanPrice");
                TextBox str1 = (TextBox)namingContainer.FindControl("txtQuantity");
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = Convert.ToInt16(dropDownList.SelectedItem.Value.ToString());
                int num5 = Convert.ToInt16(dropDownList1.SelectedItem.Value.ToString());
                DataTable value = this.objBLL.GetValue(num5, num4);
                if (value.Rows.Count > 0)
                {
                    num2 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                }
                num = (!string.IsNullOrEmpty(textBox1.Text) ? Convert.ToDecimal(textBox1.Text) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(textBox.Text) ? Convert.ToDecimal(textBox.Text) : new decimal(0));
                if (textBox.Text != "" && dropDownList.SelectedValue != "-99" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num6 = (Convert.ToDecimal(textBox.Text) * num2) / Convert.ToDecimal(textBox1.Text);
                        str.Text = num6.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable valueSec = this.objBLL.GetValueSec(num5, num4);
                        if (valueSec.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num7 = (new decimal(1) / num) * num1;
                            str.Text = num7.ToString("0.0000");
                        }
                        else
                        {
                            decimal num8 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num8.ToString("0.0000");
                        }
                    }
                }
                if (textBox.Text != "" && dropDownList.SelectedValue != "-99" && textBox2.Text != "" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num9 = (Convert.ToDecimal(textBox.Text) / Convert.ToDecimal(textBox1.Text)) * num2;
                        str.Text = num9.ToString("0.0000");
                        decimal num10 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * num2)) * num;
                        str1.Text = num10.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable dataTable = this.objBLL.GetValueSec(num5, num4);
                        if (dataTable.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(dataTable.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num11 = (new decimal(1) / num) * num1;
                            str.Text = num11.ToString("0.0000");
                            decimal num12 = (Convert.ToDecimal(textBox2.Text.Trim()) / num1) * num;
                            str1.Text = num12.ToString("0.0000");
                        }
                        else
                        {
                            decimal num13 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num13.ToString("0.0000");
                            decimal num14 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * (new decimal(1) / num3))) * num;
                            str1.Text = num14.ToString("0.0000");
                        }
                    }
                }
                else if (num <= new decimal(0))
                {
                    str.Text = "0.00";
                }
                else
                {
                    decimal num15 = (new decimal(1) / num) * num1;
                    str.Text = num15.ToString("0.0000");
                }
                string str2 = "";
                str2 = this.Session["tobacco"].ToString();
                if (str2 == "2402.20.00" || str2 == "2402.90.00")
                {
                    this.GetValueForTobacco();
                    this.GetRowValue();
                }
                else
                {
                    this.GetTotalValue();
                }
                this.CalculateTradePrice();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void ddlUnitSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
                TextBox textBox = (TextBox)namingContainer.FindControl("txtChallanQuantity");
                TextBox textBox1 = (TextBox)namingContainer.FindControl("txtQuantityTotal");
                TextBox str = (TextBox)namingContainer.FindControl("txtProductionQuantity");
                DropDownList dropDownList = (DropDownList)namingContainer.FindControl("ddlUnitSec");
                DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("ddlUnit");
                TextBox textBox2 = (TextBox)namingContainer.FindControl("txtChallanPrice");
                TextBox str1 = (TextBox)namingContainer.FindControl("txtQuantity");
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = Convert.ToInt16(dropDownList.SelectedItem.Value.ToString());
                int num5 = Convert.ToInt16(dropDownList1.SelectedItem.Value.ToString());
                DataTable value = this.objBLL.GetValue(num5, num4);
                if (value.Rows.Count > 0)
                {
                    num2 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                }
                num = (!string.IsNullOrEmpty(textBox1.Text) ? Convert.ToDecimal(textBox1.Text) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(textBox.Text) ? Convert.ToDecimal(textBox.Text) : new decimal(0));
                if (textBox.Text != "" && dropDownList.SelectedValue != "-99" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num6 = (Convert.ToDecimal(textBox.Text) * num2) / Convert.ToDecimal(textBox1.Text);
                        str.Text = num6.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable valueSec = this.objBLL.GetValueSec(num5, num4);
                        if (valueSec.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num7 = (new decimal(1) / num) * num1;
                            str.Text = num7.ToString("0.0000");
                        }
                        else
                        {
                            decimal num8 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num8.ToString("0.0000");
                        }
                    }
                }
                if (Convert.ToDecimal(textBox.Text) != new decimal(0) && textBox.Text != "" && dropDownList.SelectedValue != "-99" && textBox2.Text != "" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num9 = (Convert.ToDecimal(textBox.Text) / Convert.ToDecimal(textBox1.Text)) * num2;
                        str.Text = num9.ToString("0.0000");
                        decimal num10 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * num2)) * num;
                        str1.Text = num10.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable dataTable = this.objBLL.GetValueSec(num5, num4);
                        if (dataTable.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(dataTable.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num11 = (new decimal(1) / num) * num1;
                            str.Text = num11.ToString("0.0000");
                            decimal num12 = (Convert.ToDecimal(textBox2.Text.Trim()) / num1) * num;
                            str1.Text = num12.ToString("0.0000");
                        }
                        else
                        {
                            decimal num13 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num13.ToString("0.0000");
                            decimal num14 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * (new decimal(1) / num3))) * num;
                            str1.Text = num14.ToString("0.0000");
                        }
                    }
                }
                else if (num <= new decimal(0))
                {
                    str.Text = "0.00";
                }
                else
                {
                    decimal num15 = (new decimal(1) / num) * num1;
                    str.Text = num15.ToString("0.0000");
                }
                string str2 = "";
                str2 = this.Session["tobacco"].ToString();
                if (str2 == "2402.20.00" || str2 == "2402.90.00")
                {
                    this.GetValueForTobacco();
                    this.GetRowValue();
                }
                else
                {
                    this.GetTotalValue();
                }
                this.CalculateTradePrice();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
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
            GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList dropDownList = (DropDownList)namingContainer.FindControl("drpCategory");
            DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("drpItemName");
            Label label = (Label)namingContainer.FindControl("lblItemUnitId");
            Label str = (Label)namingContainer.FindControl("lblItemUnit");
            TextBox textBox = (TextBox)namingContainer.FindControl("txtItemQuantity");
            DropDownList dropDownList2 = (DropDownList)namingContainer.FindControl("ddlUnitChallan");
            TextBox textBox1 = (TextBox)namingContainer.FindControl("txtPrice");
            TextBox textBox2 = (TextBox)namingContainer.FindControl("txtWastage");
            if (dropDownList.SelectedValue.ToString() != "-99")
            {
                int num = Convert.ToInt32(dropDownList.SelectedValue);
                 BLL.Utility.fillAllItemByCategory(dropDownList1, num);
                ListItem listItem = new ListItem("-- Select ---", "-99");
                dropDownList1.Items.Insert(0, listItem);
                if (dropDownList1.Items.Count <= 0)
                {
                    str.Text = "No Item";
                }
                else
                {
                    str.Text = PriceDeclaration.objPDBll.strItemUnitName(Convert.ToInt32(dropDownList1.SelectedItem.Value.ToString())).ToString();
                }
                 BLL.Utility.fillAllUnit(dropDownList2);
            }
        }

        protected void drpChallanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList dropDownList = (DropDownList)namingContainer.FindControl("drpItemName");
            DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("txtReference");
            TextBox textBox = (TextBox)namingContainer.FindControl("txtQuantityTotal");
            TextBox str = (TextBox)namingContainer.FindControl("txtChallanPrice");
            TextBox str1 = (TextBox)namingContainer.FindControl("txtChallanQuantity");
            TextBox textBox1 = (TextBox)namingContainer.FindControl("txtProductionQuantity");
            TextBox textBox2 = (TextBox)namingContainer.FindControl("txtWastage");
            TextBox str2 = (TextBox)namingContainer.FindControl("txtQuantity");
            DropDownList dropDownList2 = (DropDownList)namingContainer.FindControl("ddlUnitSec");
            DropDownList str3 = (DropDownList)namingContainer.FindControl("ddlUnit");
            DropDownList dropDownList3 = (DropDownList)namingContainer.FindControl("ddlUnitChallan");
            TextBox textBox3 = (TextBox)namingContainer.FindControl("txtQuantity");
            TextBox textBox4 = (TextBox)namingContainer.FindControl("txtItemQuantity");
            int num = Convert.ToInt32(dropDownList.SelectedItem.Value.ToString());
            int num1 = Convert.ToInt32(dropDownList1.SelectedItem.Value.ToString());
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            string str4 = textBox.Text.ToString();
            int num5 = Convert.ToInt16(dropDownList2.SelectedItem.Value.ToString());
            decimal num6 = new decimal(0);
            int num7 = 0;
            if (dropDownList1.SelectedValue.ToString() == "-99")
            {
                str.Text = "0.0000";
                str1.Text = "0.0000";
                str2.Text = "0.0000";
                textBox1.Text = "0.0000";
                this.GetTotalValue();
                this.CalculateTradePrice();
                return;
            }
            DataTable priceQntByChallanId = this.objBLL.GetPriceQntByChallanId(num, num1);
            if (priceQntByChallanId.Rows.Count <= 0)
            {
                str.Text = "0.0000";
                str1.Text = "0.0000";
                str2.Text = "0.0000";
                textBox1.Text = "0.0000";
            }
            else
            {
                str3.SelectedValue = priceQntByChallanId.Rows[0]["UNIT_ID"].ToString();
                num7 = Convert.ToInt16(str3.SelectedValue);
                DataTable value = this.objBLL.GetValue(num7, num5);
                if (value.Rows.Count > 0)
                {
                    num3 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                }
                decimal num8 = Convert.ToDecimal(priceQntByChallanId.Rows[0]["total_price"]);
                str.Text = num8.ToString("0.0000");
                decimal num9 = Convert.ToDecimal(priceQntByChallanId.Rows[0]["quantity"]);
                str1.Text = num9.ToString("0.0000");
                num6 = Convert.ToDecimal(str1.Text);
                if (str4 != "0.00")
                {
                    num2 = Convert.ToDecimal(str4);
                    decimal num10 = Convert.ToDecimal(str1.Text) / num2;
                    textBox1.Text = num10.ToString("0.0000");
                    decimal num11 = (Convert.ToDecimal(str.Text) * num2) / num6;
                    str2.Text = num11.ToString("0.0000");
                }
                if (str4 != "0.00" && num5 != -99)
                {
                    num2 = Convert.ToDecimal(str4);
                    if (num3 > new decimal(0))
                    {
                        decimal num12 = (Convert.ToDecimal(str1.Text) / num2) * num3;
                        textBox1.Text = num12.ToString("0.0000");
                        decimal num13 = (Convert.ToDecimal(str.Text) * num2) / (num3 * num6);
                        str2.Text = num13.ToString("0.0000");
                    }
                    if (num3 == new decimal(0))
                    {
                        DataTable valueSec = this.objBLL.GetValueSec(num7, num5);
                        if (valueSec.Rows.Count > 0)
                        {
                            num4 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                        }
                        if (num4 <= new decimal(0))
                        {
                            decimal num14 = (Convert.ToDecimal(str.Text) * num2) / num6;
                            str2.Text = num14.ToString("0.0000");
                        }
                        else
                        {
                            decimal num15 = Convert.ToDecimal(str1.Text) / (num2 * num4);
                            textBox1.Text = num15.ToString("0.0000");
                            decimal num16 = (Convert.ToDecimal(str.Text) * num2) / (num4 * num6);
                            str2.Text = num16.ToString("0.0000");
                        }
                    }
                }
            }
            string str5 = "";
            str5 = this.Session["tobacco"].ToString();
            if (str5 == "2402.20.00" || str5 == "2402.90.00")
            {
                this.GetValueForTobacco();
                this.GetRowValue();
            }
            else
            {
                this.GetTotalValue();
            }
            this.CalculateTradePrice();
        }

        protected void drpItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
            DropDownList str = (DropDownList)namingContainer.FindControl("drpCategory");
            DropDownList dropDownList = (DropDownList)namingContainer.FindControl("drpItemName");
            Label label = (Label)namingContainer.FindControl("lblItemUnitId");
            Label label1 = (Label)namingContainer.FindControl("lblItemUnit");
            TextBox textBox = (TextBox)namingContainer.FindControl("txtItemQuantity");
            DropDownList str1 = (DropDownList)namingContainer.FindControl("ddlUnit");
            DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("ddlUnitSec");
            DropDownList str2 = (DropDownList)namingContainer.FindControl("ddlUnitChallan");
            TextBox textBox1 = (TextBox)namingContainer.FindControl("txtPrice");
            TextBox textBox2 = (TextBox)namingContainer.FindControl("txtWastage");
            TextBox str3 = (TextBox)namingContainer.FindControl("txtAvailableStock");
            DropDownList dropDownList2 = (DropDownList)namingContainer.FindControl("txtReference");
            TextBox textBox3 = (TextBox)namingContainer.FindControl("txtQuantity");
            TextBox str4 = (TextBox)namingContainer.FindControl("txtChallanPrice");
            TextBox textBox4 = (TextBox)namingContainer.FindControl("txtChallanQuantity");
            TextBox textBox5 = (TextBox)namingContainer.FindControl("txtProductionQuantity");
            TextBox str5 = (TextBox)namingContainer.FindControl("txtQuantityTotal");
            TextBox textBox6 = (TextBox)namingContainer.FindControl("txtWastageParcent");
            TextBox textBox7 = (TextBox)namingContainer.FindControl("txtRemarks");
            int num = Convert.ToInt32(dropDownList.SelectedItem.Value.ToString());
            DataTable setTransactionbyItemID = this.objBLL.GetSetTransactionbyItemID(num);
            if (setTransactionbyItemID.Rows.Count > 0)
            {
                str5.Text = setTransactionbyItemID.Rows[0]["quantity"].ToString();
                str1.SelectedValue = setTransactionbyItemID.Rows[0]["unit_id"].ToString();
                textBox3.Text = setTransactionbyItemID.Rows[0]["price"].ToString();
            }
            if (this.isAvg.Checked)
            {
                DataTable avgPricebyItemID = this.objBLL.GetAvgPricebyItemID(num);
                if (avgPricebyItemID.Rows.Count > 0)
                {
                    str4.Text = avgPricebyItemID.Rows[0]["total_price"].ToString();
                    textBox4.Text = avgPricebyItemID.Rows[0]["quantity"].ToString();
                    str1.SelectedValue = avgPricebyItemID.Rows[0]["unit_id"].ToString();
                }
            }
            else if (this.isLast.Checked)
            {
                DataTable lastChallanPricebyItemID = this.objBLL.GetLastChallanPricebyItemID(num);
                if (lastChallanPricebyItemID.Rows.Count > 0)
                {
                    str4.Text = lastChallanPricebyItemID.Rows[0]["total_price"].ToString();
                    textBox4.Text = lastChallanPricebyItemID.Rows[0]["quantity"].ToString();
                    str1.SelectedValue = lastChallanPricebyItemID.Rows[0]["unit_id"].ToString();
                }
            }
            else if (!this.isManual.Checked)
            {
                DataTable itemChallaNo = this.objBLL.GetItemChallaNo(num);
                if (itemChallaNo.Rows.Count > 0)
                {
                    dropDownList2.DataSource = itemChallaNo;
                    dropDownList2.DataTextField = itemChallaNo.Columns["challan_no"].ToString();
                    dropDownList2.DataValueField = itemChallaNo.Columns["challan_id"].ToString();
                    dropDownList2.DataBind();
                }
            }
            ListItem listItem = new ListItem("-- Select ---", "-99");
            dropDownList2.Items.Insert(0, listItem);
            if (dropDownList.SelectedValue.ToString() == "-99")
            {
                str.SelectedValue = "-99";
                dropDownList2.ClearSelection();
                textBox3.Text = "0.00";
                str4.Text = "0.00";
                textBox4.Text = "0.00";
                textBox5.Text = "0.00";
                str3.Text = "0.00";
                str1.ClearSelection();
                str5.Text = "0.00";
                dropDownList1.ClearSelection();
                str2.ClearSelection();
                textBox6.Text = "0.00";
                textBox2.Text = "0.00";
                textBox.Text = "0.00";
                textBox7.Text = "";
                this.GetTotalValue();
                return;
            }
            DataSet itemInfoByItemID = this.objBLL.getItemInfoByItemID(num);
            DataTable availStock = this.objBLL.getAvailStock(num, DateTime.UtcNow.Date);
            if (availStock != null)
            {
                if (availStock.Rows.Count <= 0)
                {
                    str3.Text = "0.00";
                }
                else
                {
                    decimal num1 = Convert.ToDecimal(availStock.Rows[0]["availStock"]);
                    str3.Text = num1.ToString("0.0000");
                }
            }
            if (itemInfoByItemID != null && itemInfoByItemID.Tables[0] != null && itemInfoByItemID.Tables[0].Rows.Count > 0)
            {
                str.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["CATEGORY_ID"].ToString();
                str2.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["UNIT_ID"].ToString();
                str1.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["UNIT_ID"].ToString();
                dropDownList1.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["UNIT_ID"].ToString();
            }
            dropDownList2.ClearSelection();
            textBox5.Text = "0.00";
        }

        protected void drpProprty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetValueForTobacco();
        }

        protected DataTable formatExcelDataForGrid(List<PrincipalInput> principalInputList)
        {
            DataTable dataTable = this.addColumnsToDataTable(new DataTable());
            if (principalInputList.Count > 0)
            {
                foreach (PrincipalInput principalInput in principalInputList)
                {
                    DataRow dataRow = this.makeNewRow(principalInput, dataTable.NewRow());
                    dataTable.Rows.Add(dataRow);
                }
            }
            return dataTable;
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
                }
            }
        }

        [WebMethod]
        public double GetItemUnitConversionValue(string fUnit, string tUnit)
        {
            double num = 1;
            DataTable valueFromScriept = PriceDeclaration.objPDBll.GetValueFromScriept(int.Parse(fUnit), int.Parse(tUnit));
            if (valueFromScriept != null && valueFromScriept.Rows.Count > 0)
            {
                num = Convert.ToDouble(valueFromScriept.Rows[0]["convert_value"]);
            }
            return num;
        }

        private int getNewRowNumberForAdd()
        {
            int num = 1;
            try
            {
                TextBox textBox = (TextBox)this.gvItems.FooterRow.FindControl("txtAddRowNo");
                if (textBox.Text.Trim().Length > 0)
                {
                    num = Convert.ToInt32(textBox.Text.Trim());
                }
            }
            catch
            {
            }
            return num;
        }

        private void GetRawMaterialSetForFinGd()
        {
            try
            {
                SetRawMaterialBLL setRawMaterialBLL = new SetRawMaterialBLL();
                int num = Convert.ToInt32(this.ddlItem.SelectedValue);
                int num1 = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
                DataTable rawMaterialSet = setRawMaterialBLL.GetRawMaterialSet(num, num1);
                for (int i = 0; i < this.gvItems.Rows.Count; i++)
                {
                    this.gvItems.Rows[i].Visible = true;
                    DropDownList dropDownList = (DropDownList)this.gvItems.Rows[i].FindControl("drpCategory");
                    DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[i].FindControl("drpItemName");
                    DropDownList dropDownList2 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnitChallan");
                    if (dropDownList.SelectedIndex == 0 && dropDownList1.SelectedIndex == 0 && dropDownList2.SelectedIndex == 0)
                    {
                        dropDownList.SelectedIndex = 0;
                        dropDownList1.SelectedIndex = 0;
                        dropDownList2.SelectedIndex = 0;
                    }
                }
                if (rawMaterialSet != null)
                {
                    if (rawMaterialSet.Rows.Count > this.gvItems.Rows.Count)
                    {
                        this.showItemEntryGirdView(rawMaterialSet.Rows.Count);
                    }
                    for (int j = 0; j < rawMaterialSet.Rows.Count; j++)
                    {
                        DropDownList str = (DropDownList)this.gvItems.Rows[j].FindControl("drpCategory");
                        DropDownList str1 = (DropDownList)this.gvItems.Rows[j].FindControl("drpItemName");
                        DropDownList str2 = (DropDownList)this.gvItems.Rows[j].FindControl("ddlUnitChallan");
                        str.SelectedValue = rawMaterialSet.Rows[j]["category_id"].ToString();
                        str1.SelectedValue = rawMaterialSet.Rows[j]["RawMaterialID"].ToString();
                        str2.SelectedValue = rawMaterialSet.Rows[j]["UNIT_ID"].ToString();
                    }
                }
                this.GetTotalValue();
                string str3 = "";
                str3 = this.Session["tobacco"].ToString();
                if (str3 == "2402.20.00" || str3 == "2402.90.00")
                {
                    this.GetValueForTobacco();
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private ArrayList getRowItemPriceProperties(ArrayList arrPriceDetail)
        {
            if (this.gvItems.Rows.Count > 0)
            {
                int num = 1;
                for (int i = 0; i < this.gvItems.Rows.Count; i++)
                {
                  NBR_VAT_GROUPOFCOM.BLL.PriceRowItemDAO priceRowItemDAO = new NBR_VAT_GROUPOFCOM.BLL.PriceRowItemDAO();
                    TextBox textBox = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal");
                    DropDownList dropDownList = (DropDownList)this.gvItems.Rows[i].FindControl("drpCategory");
                    DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[i].FindControl("drpItemName");
                    TextBox textBox1 = (TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity");
                    DropDownList dropDownList2 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnit");
                    DropDownList dropDownList3 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnitSec");
                    TextBox textBox2 = (TextBox)this.gvItems.Rows[i].FindControl("txtPrice");
                    TextBox textBox3 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastage");
                    TextBox textBox4 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastageParcent");
                    TextBox textBox5 = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanPrice");
                    TextBox textBox6 = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanQuantity");
                    TextBox textBox7 = (TextBox)this.gvItems.Rows[i].FindControl("txtProductionQuantity");
                    TextBox textBox8 = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantity");
                    DropDownList dropDownList4 = (DropDownList)this.gvItems.Rows[i].FindControl("txtReference");
                    TextBox textBox9 = (TextBox)this.gvItems.Rows[i].FindControl("txtRemarks");
                    if (!string.IsNullOrEmpty(dropDownList1.SelectedValue) && !(dropDownList1.SelectedValue == "-99"))
                    {
                        priceRowItemDAO.PriceId = Convert.ToInt16(this.Session["PriceId"]);
                        DataTable priceRawItemForGridCount = PriceDeclaration.objPDBll.getPriceRawItemForGridCount(priceRowItemDAO.PriceId);
                        int count = priceRawItemForGridCount.Rows.Count - 1;
                        if (i > count)
                        {
                            int num1 = 0;
                            num1 = num + count + 1;
                            num++;
                            priceRowItemDAO.Row_no_insert = num1;
                        }
                        else
                        {
                            priceRowItemDAO.Row_no = Convert.ToInt16(priceRawItemForGridCount.Rows[i]["row_no"].ToString());
                        }
                        priceRowItemDAO.ItemId = Convert.ToInt16(dropDownList1.SelectedValue);
                        priceRowItemDAO.UnitId = Convert.ToInt16(dropDownList2.SelectedItem.Value.ToString());
                        if (dropDownList3.SelectedItem.Value.ToString() != "-99")
                        {
                            priceRowItemDAO.UnitIdSec = Convert.ToInt16(dropDownList3.SelectedItem.Value.ToString());
                        }
                        else
                        {
                            priceRowItemDAO.UnitIdSec = Convert.ToInt16(dropDownList2.SelectedItem.Value.ToString());
                        }
                        if (textBox1.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.Quantity = Convert.ToDecimal(textBox1.Text.Trim());
                        }
                        if (textBox3.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.WastageQuantity = Convert.ToDecimal(textBox3.Text.Trim());
                        }
                        if (textBox6.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.TxtChallanQuantity = Convert.ToDecimal(textBox6.Text.Trim());
                        }
                        if (textBox.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.TxtQuantityTotal = Convert.ToDecimal(textBox.Text.Trim());
                        }
                        if (textBox4.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.TxtWastageParcent = Convert.ToDecimal(textBox4.Text.Trim());
                        }
                        if (textBox5.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.TxtChallanPrice = Convert.ToDecimal(textBox5.Text.Trim());
                        }
                        if (textBox7.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.TxtProductionQuantity = Convert.ToDecimal(textBox7.Text.Trim());
                        }
                        if (textBox8.Text.Trim().Length > 0)
                        {
                            priceRowItemDAO.TxtQuantity = Convert.ToDecimal(textBox8.Text.Trim());
                        }
                        priceRowItemDAO.TxtReference = dropDownList4.Text.Trim();
                        priceRowItemDAO.textremarks = textBox9.Text.Trim();
                        priceRowItemDAO.UserIdInsert = 1;
                        string str = "";
                        DataTable productTypeItemID = this.objBLL.GetProductTypeItemID(priceRowItemDAO.ItemId);
                        if (productTypeItemID.Rows.Count > 0)
                        {
                            str = productTypeItemID.Rows[0]["product_type"].ToString();
                        }
                        if (str != "S")
                        {
                            priceRowItemDAO.Set_status = "N";
                            arrPriceDetail.Add(priceRowItemDAO);
                        }
                        else
                        {
                            priceRowItemDAO.Set_status = "S";
                            arrPriceDetail.Add(priceRowItemDAO);
                            DataTable itemSetItemID = this.objBLL.GetItemSetItemID(priceRowItemDAO.ItemId);
                            if (itemSetItemID.Rows.Count > 0)
                            {
                                for (int j = 0; j < itemSetItemID.Rows.Count; j++)
                                {
                                    NBR_VAT_GROUPOFCOM.BLL.PriceRowItemDAO priceRowItemDAO1 = new NBR_VAT_GROUPOFCOM.BLL.PriceRowItemDAO()
                                    {
                                        PriceId = Convert.ToInt16(this.Session["PriceId"]),
                                        ItemId = Convert.ToInt16(itemSetItemID.Rows[j]["item_id"]),
                                        TxtQuantityTotal = Convert.ToDecimal(itemSetItemID.Rows[j]["quantity"]),
                                        UnitId = Convert.ToInt16(itemSetItemID.Rows[j]["unit_id"]),
                                        UnitIdSec = Convert.ToInt16(itemSetItemID.Rows[j]["unit_id"]),
                                        TxtQuantity = Convert.ToDecimal(itemSetItemID.Rows[j]["price"]),
                                        UserIdInsert = 1,
                                        Set_status = "P"
                                    };
                                    arrPriceDetail.Add(priceRowItemDAO1);
                                }
                            }
                        }
                    }
                }
            }
            return arrPriceDetail;
        }

        private void GetRowValue()
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                if (this.gvItems.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItems.Rows.Count; i++)
                    {
                        num = num + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantity")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantity")).Text.Trim()) : new decimal(0));
                        num1 = num1 + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity")).Text.Trim()) : new decimal(0));
                        num2 = num2 + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtWastage")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtWastage")).Text.Trim()) : new decimal(0));
                        num3 = num3 + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal")).Text.Trim()) : new decimal(0));
                    }
                    if (this.gvValueAddition.Rows.Count > 0)
                    {
                        for (int j = 0; j < this.gvValueAddition.Rows.Count; j++)
                        {
                            num4 += Convert.ToDecimal(((TextBox)this.gvValueAddition.Rows[j].FindControl("txtValueAddition")).Text.Trim());
                        }
                    }
                    if (this.gvValueAdditionNonItem.Rows.Count > 0)
                    {
                        for (int k = 0; k < this.gvValueAdditionNonItem.Rows.Count; k++)
                        {
                            num5 += Convert.ToDecimal(((TextBox)this.gvValueAdditionNonItem.Rows[k].FindControl("txtValueAdditionNonItem")).Text.Trim());
                        }
                    }
                    if (this.txtsongkha.Text != "")
                    {
                        Convert.ToInt32(this.txtsongkha.Text);
                    }
                    this.txtTotalExpenses.Text = num4.ToString("N2");
                    this.nonItemTotalExpense.Text = num5.ToString("N2");
                    if (!string.IsNullOrEmpty(this.txtSDRate.Text))
                    {
                        Convert.ToDecimal(this.txtSDRate.Text);
                    }
                    if (!string.IsNullOrEmpty(this.txtVATRate.Text))
                    {
                        Convert.ToDecimal(this.txtVATRate.Text);
                    }
                    this.txtTotalPrice.Text = num.ToString("N2");
                    this.txtSumItemQuantity.Text = num1.ToString("0.0000");
                    this.txtSumWastage.Text = num2.ToString("0.0000");
                    this.txtSumQuantityTotal.Text = num3.ToString("0.0000");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void GetTotalValue()
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                decimal num6 = new decimal(0);
                decimal num7 = new decimal(0);
                decimal num8 = new decimal(0);
                int num9 = 0;
                if (this.gvItems.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItems.Rows.Count; i++)
                    {
                        num = num + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantity")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantity")).Text.Trim()) : new decimal(0));
                        num1 = num1 + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity")).Text.Trim()) : new decimal(0));
                        num2 = num2 + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtWastage")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtWastage")).Text.Trim()) : new decimal(0));
                        num3 = num3 + (!string.IsNullOrEmpty(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal")).Text.Trim()) ? Convert.ToDecimal(((TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal")).Text.Trim()) : new decimal(0));
                    }
                    if (this.gvValueAddition.Rows.Count > 0)
                    {
                        for (int j = 0; j < this.gvValueAddition.Rows.Count; j++)
                        {
                            num6 += Convert.ToDecimal(((TextBox)this.gvValueAddition.Rows[j].FindControl("txtValueAddition")).Text.Trim());
                        }
                    }
                    if (this.gvValueAdditionNonItem.Rows.Count > 0)
                    {
                        for (int k = 0; k < this.gvValueAdditionNonItem.Rows.Count; k++)
                        {
                            num7 += Convert.ToDecimal(((TextBox)this.gvValueAdditionNonItem.Rows[k].FindControl("txtValueAdditionNonItem")).Text.Trim());
                        }
                    }
                    num9 = (this.txtsongkha.Text != "" ? Convert.ToInt32(this.txtsongkha.Text) : 1);
                    this.txtTotalExpenses.Text = num6.ToString("N2");
                    this.nonItemTotalExpense.Text = num7.ToString("N2");
                    num4 = (!string.IsNullOrEmpty(this.txtSDRate.Text) ? Convert.ToDecimal(this.txtSDRate.Text) : new decimal(0));
                    num5 = (!string.IsNullOrEmpty(this.txtVATRate.Text) ? Convert.ToDecimal(this.txtVATRate.Text) : new decimal(0));
                    this.txtTotalPrice.Text = num.ToString("N2");
                    this.txtSumItemQuantity.Text = num1.ToString("0.0000");
                    this.txtSumWastage.Text = num2.ToString("0.0000");
                    this.txtSumQuantityTotal.Text = num3.ToString("0.0000");
                    num8 = (num + num6) + num7;
                    this.txtProposedPrice.Text = num8.ToString("0.0000");
                    this.txtProposedSDPrice.Text = num8.ToString("0.0000");
                    TextBox str = this.txtSD;
                    decimal num10 = (num * num4) / new decimal(100);
                    str.Text = num10.ToString("0.0000");
                    if (this.fVAT.Text != " Per Unit.")
                    {
                        TextBox textBox = this.txtCurrentVATPrice;
                        decimal num11 = ((num8 + ((num8 * num4) / new decimal(100))) * num5) / new decimal(100);
                        textBox.Text = num11.ToString("0.0000");
                        TextBox str1 = this.txtRetailPrice;
                        decimal num12 = (num8 + ((num8 * num4) / new decimal(100))) + (((num8 + ((num8 * num4) / new decimal(100))) * num5) / new decimal(100));
                        str1.Text = num12.ToString("0.0000");
                    }
                    else
                    {
                        this.txtCurrentVATPrice.Text = (num9 * num5).ToString("0.0000");
                        TextBox textBox1 = this.txtRetailPrice;
                        decimal num13 = (num8 + ((num8 * num4) / new decimal(100))) + (num9 * num5);
                        textBox1.Text = num13.ToString("0.0000");
                    }
                    TextBox str2 = this.txtProposedVATPrice;
                    decimal num14 = num8 + ((num8 * num4) / new decimal(100));
                    str2.Text = num14.ToString("0.0000");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void GetValueForTobacco()
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(1);
            decimal num4 = (!string.IsNullOrEmpty(this.txtsongkha.Text) ? Convert.ToDecimal(this.txtsongkha.Text) : new decimal(1));
            decimal num5 = (!string.IsNullOrEmpty(this.txtVATRate.Text) ? Convert.ToDecimal(this.txtVATRate.Text) : new decimal(0));
            decimal num6 = (!string.IsNullOrEmpty(this.txtSDRate.Text) ? Convert.ToDecimal(this.txtSDRate.Text) : new decimal(0));
            decimal num7 = (!string.IsNullOrEmpty(this.lblhlthcharge.Text) ? Convert.ToDecimal(this.lblhlthcharge.Text) : new decimal(0));
            decimal num8 = (!string.IsNullOrEmpty(this.txtRetailPrice.Text) ? Convert.ToDecimal(this.txtRetailPrice.Text) : new decimal(0));
            this.dt = this.objBLL.getPropQuantity((!string.IsNullOrEmpty(this.drpProperty.SelectedValue) ? (int)Convert.ToInt16(this.drpProperty.SelectedValue) : 0));
            if (this.dt.Rows.Count <= 0)
            {
                this.lblstickQuantity.Text = "0";
            }
            else
            {
                num3 = Convert.ToDecimal(this.dt.Rows[0]["quantity"]);
                this.lblstickQuantity.Text = num3.ToString();
            }
            num1 = (num4 * num8) / num3;
            num = (num5 * num1) / new decimal(100);
            num2 = (num6 * num1) / new decimal(100);
            this.txtProposedVATPrice.Text = num1.ToString();
            this.txtCurrentVATPrice.Text = num.ToString();
            this.txtSD.Text = num2.ToString();
            this.txtProposedSDPrice.Text = num1.ToString();
            this.txtProposedPrice.Text = num1.ToString();
            TextBox str = this.txthlthcharge;
            decimal num9 = (num7 * num1) / new decimal(100);
            str.Text = num9.ToString("0.00");
        }

        protected void gvDeclaretion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvDeclaretion.PageIndex = e.NewPageIndex;
            this.gvDeclaretion.DataBind();
            this.showDataInGridView();
        }

        protected void gvDeclaretion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime utcNow;
            decimal num;
            GridViewRow selectedRow = this.gvDeclaretion.SelectedRow;
            short num1 = Convert.ToInt16(this.gvDeclaretion.DataKeys[selectedRow.RowIndex].Value);
            DataTable priceRawItemForGridCount = PriceDeclaration.objPDBll.getPriceRawItemForGridCount(num1);
            if (priceRawItemForGridCount.Rows.Count > 0 && priceRawItemForGridCount != null)
            {
                this.showItemEntryGirdView(priceRawItemForGridCount.Rows.Count);
                for (int i = 0; i < priceRawItemForGridCount.Rows.Count; i++)
                {
                    int num2 = 0;
                    DropDownList str = (DropDownList)this.gvItems.Rows[i].FindControl("drpItemName");
                    DropDownList dropDownList = (DropDownList)this.gvItems.Rows[i].FindControl("drpCategory");
                     BLL.Utility.fillAllItemPD(str);
                    ListItem listItem = new ListItem("-- Select ---", "-99");
                    str.Items.Insert(0, listItem);
                    str.SelectedValue = priceRawItemForGridCount.Rows[i]["item_id"].ToString();
                    num2 = Convert.ToInt32(priceRawItemForGridCount.Rows[i]["item_id"].ToString());
                    DataSet itemInfoByItemID = this.objBLL.getItemInfoByItemID(num2);
                    DropDownList str1 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnitChallan");
                     BLL.Utility.fillAllUnitWithParameter(str1, Convert.ToInt16(itemInfoByItemID.Tables[0].Rows[0]["unit_id"].ToString()));
                    DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnit");
                     BLL.Utility.fillAllUnitWithParameter(dropDownList1, Convert.ToInt16(priceRawItemForGridCount.Rows[i]["unit_id"].ToString()));
                    DataTable unit = PriceDeclaration.objPDBll.getUnit();
                    if (unit != null && unit.Rows.Count > 0)
                    {
                        dropDownList1.DataSourceID = null;
                        dropDownList1.DataSource = unit;
                        dropDownList1.DataTextField = unit.Columns["unit_code"].ToString();
                        dropDownList1.DataValueField = unit.Columns["unit_id"].ToString();
                        dropDownList1.DataBind();
                    }
                    ListItem listItem1 = new ListItem("-- Select ---", "-99");
                    dropDownList1.Items.Insert(0, listItem1);
                    dropDownList1.SelectedValue = priceRawItemForGridCount.Rows[i]["unit_id"].ToString();
                    DropDownList str2 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnitSec");
                     BLL.Utility.fillAllUnitWithParameter(str2, Convert.ToInt16(priceRawItemForGridCount.Rows[i]["unit_id_sec"].ToString()));
                    if (unit != null && unit.Rows.Count > 0)
                    {
                        str2.DataSourceID = null;
                        str2.DataSource = unit;
                        str2.DataTextField = unit.Columns["unit_code"].ToString();
                        str2.DataValueField = unit.Columns["unit_id"].ToString();
                        str2.DataBind();
                    }
                    ListItem listItem2 = new ListItem("-- Select ---", "-99");
                    str2.Items.Insert(0, listItem2);
                    str2.SelectedValue = priceRawItemForGridCount.Rows[i]["unit_id_sec"].ToString();
                    if (unit != null && unit.Rows.Count > 0)
                    {
                        str1.DataSourceID = null;
                        str1.DataSource = unit;
                        str1.DataTextField = unit.Columns["unit_code"].ToString();
                        str1.DataValueField = unit.Columns["unit_id"].ToString();
                        str1.DataBind();
                    }
                    ListItem listItem3 = new ListItem("-- Select ---", "-99");
                    str1.Items.Insert(0, listItem3);
                    str1.SelectedValue = itemInfoByItemID.Tables[0].Rows[0]["unit_id"].ToString();
                    TextBox textBox = (TextBox)this.gvItems.Rows[i].FindControl("txtAvailableStock");
                    NBR_VAT_GROUPOFCOM.BLL.AddItemBLL addItemBLL = this.objBLL;
                    int num3 = Convert.ToInt32(priceRawItemForGridCount.Rows[i]["item_id"].ToString());
                    utcNow = DateTime.UtcNow;
                    DataTable availStock = addItemBLL.getAvailStock(num3, utcNow.Date);
                    if (availStock != null)
                    {
                        if (availStock.Rows.Count <= 0)
                        {
                            textBox.Text = "0.00";
                        }
                        else
                        {
                            num = Convert.ToDecimal(availStock.Rows[0]["availStock"]);
                            textBox.Text = num.ToString("0.0000");
                        }
                    }
                    DataTable subCategoryWithItem = PriceDeclaration.objPDBll.GetSubCategoryWithItem(Convert.ToInt16(priceRawItemForGridCount.Rows[i]["item_id"].ToString()));
                    DataTable subCategory = PriceDeclaration.objPDBll.GetSubCategory();
                    if (subCategory != null && subCategory.Rows.Count > 0)
                    {
                        dropDownList.DataSourceID = null;
                        dropDownList.DataSource = subCategory;
                        dropDownList.DataTextField = subCategory.Columns["category_name"].ToString();
                        dropDownList.DataValueField = subCategory.Columns["category_id"].ToString();
                        dropDownList.DataBind();
                    }
                    ListItem listItem4 = new ListItem("-- Select ---", "-99");
                    dropDownList.Items.Insert(0, listItem4);
                    dropDownList.SelectedValue = subCategoryWithItem.Rows[0]["category_id"].ToString();
                    TextBox textBox1 = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["quantity_total"]);
                    textBox1.Text = num.ToString("0.0000");
                    TextBox textBox2 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastageParcent");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["wastageparcent"]);
                    textBox2.Text = num.ToString("0.0000");
                    TextBox str3 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastage");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["wastage_quantity"]);
                    str3.Text = num.ToString("0.0000");
                    TextBox textBox3 = (TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["quantity"]);
                    textBox3.Text = num.ToString("0.0000");
                    TextBox str4 = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanPrice");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["challanprice"]);
                    str4.Text = num.ToString("0.0000");
                    TextBox textBox4 = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanQuantity");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["challan_quantity"]);
                    textBox4.Text = num.ToString("0.0000");
                    TextBox str5 = (TextBox)this.gvItems.Rows[i].FindControl("txtProductionQuantity");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["productionquantity"]);
                    str5.Text = num.ToString("0.0000");
                    TextBox textBox5 = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantity");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["txtQuantityPrice"]);
                    textBox5.Text = num.ToString("0.0000");
                    TextBox str6 = (TextBox)this.gvItems.Rows[i].FindControl("txtRemarks");
                    str6.Text = priceRawItemForGridCount.Rows[i]["remarks"].ToString();
                    DropDownList dropDownList2 = (DropDownList)this.gvItems.Rows[i].FindControl("txtReference");
                    int num4 = Convert.ToInt16(priceRawItemForGridCount.Rows[i]["item_id"].ToString());
                    if (priceRawItemForGridCount.Rows[i]["reference"].ToString() != "")
                    {
                         BLL.Utility.fillchallanWithParameter(dropDownList2, Convert.ToInt32(priceRawItemForGridCount.Rows[i]["reference"].ToString()));
                        DataTable itemChallaNo = this.objBLL.GetItemChallaNo(num4);
                        if (itemChallaNo.Rows.Count > 0)
                        {
                            dropDownList2.DataSource = itemChallaNo;
                            dropDownList2.DataTextField = itemChallaNo.Columns["challan_no"].ToString();
                            dropDownList2.DataValueField = itemChallaNo.Columns["challan_id"].ToString();
                            dropDownList2.DataBind();
                        }
                        ListItem listItem5 = new ListItem("-- Select ---", "-99");
                        dropDownList2.Items.Insert(0, listItem5);
                        dropDownList2.SelectedValue = priceRawItemForGridCount.Rows[i]["reference"].ToString();
                    }
                    TextBox textBox6 = (TextBox)this.gvItems.Rows[i].FindControl("txtRowNO");
                    num = Convert.ToDecimal(priceRawItemForGridCount.Rows[i]["row_no"]);
                    textBox6.Text = num.ToString();
                }
            }
            DataTable _priceitemForMasterData = PriceDeclaration.objPDBll.get_priceitemForMasterData(num1);
            if (priceRawItemForGridCount.Rows.Count > 0 && priceRawItemForGridCount != null)
            {
                this.LoadItem();
                this.ddlItem.SelectedValue = _priceitemForMasterData.Rows[0]["item_id"].ToString();
                DataTable dataTable = PriceDeclaration.objPDBll.gethsCodebyItemID(Convert.ToInt32(_priceitemForMasterData.Rows[0]["item_id"]));
                if (dataTable.Rows.Count <= 0)
                {
                    this.divStick.Visible = false;
                }
                else if (dataTable.Rows[0]["hs_code"].ToString() == "2402.20.00" || dataTable.Rows[0]["hs_code"].ToString() == "2402.90.00")
                {
                    this.lblhlthcharge.Text = "";
                    this.txthlthcharge.Text = "";
                    this.Session["tobacco"] = dataTable.Rows[0]["hs_code"].ToString();
                    DataTable propertyByCodeId = this.objsaleBLL.getPropertyByCodeId(8);
                    if (propertyByCodeId != null && propertyByCodeId.Rows.Count > 0)
                    {
                        this.divStick.Visible = true;
                        this.drpProperty.DataSource = propertyByCodeId;
                        this.drpProperty.DataTextField = propertyByCodeId.Columns["property_name"].ToString();
                        this.drpProperty.DataValueField = propertyByCodeId.Columns["property_id"].ToString();
                        this.drpProperty.DataBind();
                    }
                    this.drpProperty.SelectedValue = _priceitemForMasterData.Rows[0]["property_id1"].ToString();
                    DataTable healthChargebyItemID = PriceDeclaration.objPDBll.getHealthChargebyItemID(Convert.ToInt32(_priceitemForMasterData.Rows[0]["item_id"]));
                    if (healthChargebyItemID.Rows.Count > 0)
                    {
                        this.lblhlthcharge.Text = Utilities.formatFraction(Convert.ToDecimal(healthChargebyItemID.Rows[0]["health_surcharge"])).ToString();
                    }
                }
                else
                {
                    this.divStick.Visible = false;
                }
                this.ddlItemCategory.Items.Clear();
                this.ddlItemCategory.DataBind();
                DataTable categoryWithItem = PriceDeclaration.objPDBll.GetCategoryWithItem(Convert.ToInt16(_priceitemForMasterData.Rows[0]["item_id"].ToString()));
                if (priceRawItemForGridCount != null && priceRawItemForGridCount.Rows.Count > 0)
                {
                    this.ddlItemCategory.DataSource = categoryWithItem;
                    this.ddlItemCategory.DataTextField = categoryWithItem.Columns["category_name"].ToString();
                    this.ddlItemCategory.DataValueField = categoryWithItem.Columns["category_id"].ToString();
                    this.ddlItemCategory.DataBind();
                }
                this.ddlItemSubCategory.Items.Clear();
                this.ddlItemSubCategory.DataBind();
                DataTable subCategoryWithItem1 = PriceDeclaration.objPDBll.GetSubCategoryWithItem(Convert.ToInt16(_priceitemForMasterData.Rows[0]["item_id"].ToString()));
                if (subCategoryWithItem1 != null && subCategoryWithItem1.Rows.Count > 0)
                {
                    this.ddlItemSubCategory.DataSource = subCategoryWithItem1;
                    this.ddlItemSubCategory.DataTextField = subCategoryWithItem1.Columns["category_name"].ToString();
                    this.ddlItemSubCategory.DataValueField = subCategoryWithItem1.Columns["category_id"].ToString();
                    this.ddlItemSubCategory.DataBind();
                }
                TextBox textBox7 = this.txtTradePricePct;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["trade_price_value_pct"]);
                textBox7.Text = num.ToString("0.0000").Trim();
                if (_priceitemForMasterData.Rows[0]["trade_price_value"].ToString() != "")
                {
                    TextBox textBox8 = this.txtTradePriceValue;
                    num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["trade_price_value"]);
                    textBox8.Text = num.ToString("0.0000").Trim();
                }
                this.txtAgreementNo.Text = _priceitemForMasterData.Rows[0]["agreement_no"].ToString().Trim();
                this.txtPriceDeclaretionNo.Text = _priceitemForMasterData.Rows[0]["price_declaration_no"].ToString().Trim();
                this.txtsongkha.Text = _priceitemForMasterData.Rows[0]["production_quantity"].ToString().Trim();
                this.ddlYear.Items.Clear();
                this.ddlYear.DataBind();
                 BLL.Utility.fillYearList(this.ddlYear);
                this.ddlYear.SelectedValue = _priceitemForMasterData.Rows[0]["price_declaration_year"].ToString();
                TextBox str7 = this.txtActiveDate;
                utcNow = Convert.ToDateTime(_priceitemForMasterData.Rows[0]["date_effective"].ToString());
                str7.Text = utcNow.ToString("dd/MM/yyyy");
                this.txtSDRate.Text = "0";
                DataSet itemDetail = PriceDeclaration.objPDBll.getItemDetail(Convert.ToInt16(_priceitemForMasterData.Rows[0]["item_id"].ToString()));
                if (itemDetail.Tables[0].Rows.Count <= 0)
                {
                    this.lblHSCode.Text = "";
                    this.lblUnit.Text = "";
                }
                else
                {
                    this.lblHSCode.Text = itemDetail.Tables[0].Rows[0]["hs_code"].ToString();
                    this.lblUnit.Text = PriceDeclaration.objPDBll.strItemUnitName(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString())).ToString();
                    this.txtSDRate.Text = itemDetail.Tables[0].Rows[0]["sd"].ToString();
                    this.txtVATRate.Text = itemDetail.Tables[0].Rows[0]["vat"].ToString();
                }
                this.GetRawMaterialSetForFinGd();
                TextBox str8 = this.txtProposedPrice;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["prpsd_actl_prc"]);
                str8.Text = num.ToString("0.0000");
                TextBox str9 = this.txtCurrentSDPrice;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["crnt_actl_prc_sd"]);
                str9.Text = num.ToString("0.0000");
                TextBox textBox9 = this.txtProposedSDPrice;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["prpsd_actl_prc_sd"]);
                textBox9.Text = num.ToString("0.0000");
                TextBox str10 = this.txtSD;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["sd_amount"]);
                str10.Text = num.ToString("0.0000");
                TextBox textBox10 = this.txtCurrentVATPrice;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["crnt_actl_prc_vat"]);
                textBox10.Text = num.ToString("0.0000");
                TextBox str11 = this.txtProposedVATPrice;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["prpsd_actl_prc_vat"]);
                str11.Text = num.ToString("0.0000");
                TextBox textBox11 = this.txtWholeSalePrice;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["cnfrmd_wholesale_prc"]);
                textBox11.Text = num.ToString("0.0000");
                TextBox str12 = this.txtRetailPrice;
                num = Convert.ToDecimal(_priceitemForMasterData.Rows[0]["cnfrmd_retail_prc"]);
                str12.Text = num.ToString("0.0000");
                this.txthlthcharge.Text = _priceitemForMasterData.Rows[0]["health_surcharge"].ToString();
                DataTable grossTotal = PriceDeclaration.objPDBll.getGrossTotal(Convert.ToInt16(_priceitemForMasterData.Rows[0]["price_id"].ToString()));
                TextBox textBox12 = this.txtSumQuantityTotal;
                num = Convert.ToDecimal(grossTotal.Rows[0]["quantity_total"]);
                textBox12.Text = num.ToString("0.0000");
                DataTable totalWastageQueantity = PriceDeclaration.objPDBll.getTotalWastageQueantity(Convert.ToInt16(_priceitemForMasterData.Rows[0]["price_id"].ToString()));
                TextBox str13 = this.txtSumWastage;
                num = Convert.ToDecimal(totalWastageQueantity.Rows[0]["wastage_quantity"]);
                str13.Text = num.ToString("0.0000");
                DataTable nitUse = PriceDeclaration.objPDBll.getNitUse(Convert.ToInt16(_priceitemForMasterData.Rows[0]["price_id"].ToString()));
                this.txtSumItemQuantity.Text = nitUse.Rows[0]["quantity"].ToString();
                decimal num5 = Convert.ToDecimal(this.txtSumItemQuantity.Text);
                this.txtSumItemQuantity.Text = num5.ToString("0.0000");
                PriceDeclaration.objPDBll.getTotalQuantityPrice(Convert.ToInt16(_priceitemForMasterData.Rows[0]["price_id"].ToString()));
                DataTable dataTable1 = PriceDeclaration.objPDBll.get1stAddition(Convert.ToInt16(_priceitemForMasterData.Rows[0]["price_id"].ToString()));
                if (dataTable1.Rows[0]["item_value"].ToString() != "")
                {
                    TextBox textBox13 = this.txtTotalExpenses;
                    num = Convert.ToDecimal(dataTable1.Rows[0]["item_value"]);
                    textBox13.Text = num.ToString("N2");
                    TextBox str14 = this.txtTotalvladpct;
                    num = Convert.ToDecimal(dataTable1.Rows[0]["value_addtn_pct"]);
                    str14.Text = num.ToString("N2");
                }
                DataTable dataTable2 = PriceDeclaration.objPDBll.get2ndAddition(Convert.ToInt16(_priceitemForMasterData.Rows[0]["price_id"].ToString()));
                if (dataTable2.Rows[0]["item_value"].ToString() != "")
                {
                    TextBox textBox14 = this.nonItemTotalExpense;
                    num = Convert.ToDecimal(dataTable2.Rows[0]["item_value"]);
                    textBox14.Text = num.ToString("N2");
                }
                if (dataTable1.Rows[0]["item_value"].ToString().Length == 0)
                {
                    Convert.ToString(0);
                }
                if (dataTable2.Rows[0]["item_value"].ToString().Length == 0)
                {
                    Convert.ToString(0);
                }
            }
            if (this.gvValueAdditionNonItem.Rows.Count > 0)
            {
                for (int j = 0; j < this.gvValueAdditionNonItem.Rows.Count; j++)
                {
                    TextBox textBox15 = (TextBox)this.gvValueAdditionNonItem.Rows[j].FindControl("txtValueAdditionNonItem");
                    textBox15.Text = "0.0000";
                }
            }
            if (this.gvValueAdditionNonItem.Rows.Count > 0)
            {
                for (int k = 0; k < this.gvValueAdditionNonItem.Rows.Count; k++)
                {
                    int num6 = Convert.ToInt32(((Label)this.gvValueAdditionNonItem.Rows[k].FindControl("lblID2")).Text);
                    DataTable valueAdditionNonItem = PriceDeclaration.objPDBll.getValueAdditionNonItem(num1, num6);
                    if (valueAdditionNonItem.Rows.Count > 0 && valueAdditionNonItem != null)
                    {
                        if (((Label)this.gvValueAdditionNonItem.Rows[k].FindControl("lblvStatus1")).Text == "H")
                        {
                            this.gvValueAdditionNonItem.Rows[k].Visible = true;
                        }
                        TextBox str15 = (TextBox)this.gvValueAdditionNonItem.Rows[k].FindControl("txtValueAdditionNonItem");
                        str15.Text = valueAdditionNonItem.Rows[0]["item_value"].ToString();
                    }
                }
            }
            if (this.gvValueAddition.Rows.Count > 0)
            {
                for (int l = 0; l < this.gvValueAddition.Rows.Count; l++)
                {
                    TextBox textBox16 = (TextBox)this.gvValueAddition.Rows[l].FindControl("txtValueAddition");
                    textBox16.Text = "0.0000";
                }
            }
            if (this.gvValueAddition.Rows.Count > 0)
            {
                for (int m = 0; m < this.gvValueAddition.Rows.Count; m++)
                {
                    int num7 = Convert.ToInt32(((Label)this.gvValueAddition.Rows[m].FindControl("lblID")).Text);
                    DataTable valueAdditionItem = PriceDeclaration.objPDBll.getValueAdditionItem(num1, num7);
                    if (valueAdditionItem.Rows.Count > 0 && valueAdditionItem != null)
                    {
                        if (((Label)this.gvValueAddition.Rows[m].FindControl("lblvStatus")).Text == "H")
                        {
                            this.gvValueAddition.Rows[m].Visible = true;
                        }
                        TextBox str16 = (TextBox)this.gvValueAddition.Rows[m].FindControl("txtValueAddition");
                        TextBox str17 = (TextBox)this.gvValueAddition.Rows[m].FindControl("txtValueAdditionpct");
                        num = Convert.ToDecimal(valueAdditionItem.Rows[0]["item_value"]);
                        str16.Text = num.ToString("0.0000");
                        num = Convert.ToDecimal(valueAdditionItem.Rows[0]["value_addtn_pct"]);
                        str17.Text = num.ToString("0.0000");
                    }
                }
            }
        }

        protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow item = this.gvItems.Rows[e.RowIndex];
            DropDownList dropDownList = (DropDownList)item.FindControl("drpCategory");
            DropDownList dropDownList1 = (DropDownList)item.FindControl("drpItemName");
            TextBox textBox = (TextBox)item.FindControl("txtItemQuantity");
            DropDownList dropDownList2 = (DropDownList)item.FindControl("ddlUnit");
            TextBox textBox1 = (TextBox)item.FindControl("txtPrice");
            TextBox textBox2 = (TextBox)item.FindControl("txtWastage");
            dropDownList.SelectedIndex = 0;
            dropDownList1.SelectedIndex = 0;
            dropDownList2.SelectedIndex = 0;
            textBox.Text = "0.00";
            textBox2.Text = "0.00";
            this.gvItems.Rows[e.RowIndex].Visible = false;
        }

        protected void gvValueAddition_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        private NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAO insertPriceDeclaration(NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAO objPDDAO)
        {
            PriceDeclaration.objPDBll.IsExistDeclaretion(this.txtPriceDeclaretionNo.Text.ToString());
            objPDDAO.intPriceID = (int)this.Session["PriceId"];
            int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
            objPDDAO.BranchID = num;
            objPDDAO.strPriceDeclaretionNo =  BLL.Utility.ReplaceQuotes(this.txtPriceDeclaretionNo.Text.Trim());
            objPDDAO.intPriceDeclaretionYear = Convert.ToInt32(this.ddlYear.SelectedItem.Value.ToString());
            objPDDAO.dtActiveDate = DateTime.ParseExact(this.txtActiveDate.Text, "dd/MM/yyyy", null);
            objPDDAO.intItemId = Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString());
            objPDDAO.AgreementNo = this.txtAgreementNo.Text.ToString();
            objPDDAO.TradePricePct = Convert.ToDecimal(this.txtTradePricePct.Text.ToString());
            objPDDAO.Trade_price_value = Convert.ToDecimal(this.txtTradePriceValue.Text.ToString());
            int num1 = PriceDeclaration.objPDBll.intItemUnitId(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
            objPDDAO.intUnitId = num1;
            if (this.txtCurrentSDPrice.Text.Length <= 0)
            {
                objPDDAO.decCurrentSDChargablePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decCurrentSDChargablePrice = Convert.ToDecimal(this.txtCurrentSDPrice.Text);
            }
            objPDDAO.decProposedSDChargablePric = Convert.ToDecimal(this.txtProposedSDPrice.Text);
            objPDDAO.decSD = Convert.ToDecimal(this.txtSD.Text);
            if (this.txtCurrentVATPrice.Text.Length <= 0)
            {
                objPDDAO.decCurrentVATChargablePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decCurrentVATChargablePrice = Convert.ToDecimal(this.txtCurrentVATPrice.Text);
            }
            objPDDAO.decProposedVATChargabelPrice = Convert.ToDecimal(this.txtProposedVATPrice.Text);
            if (this.txtWholeSalePrice.Text.Length <= 0)
            {
                objPDDAO.decWholeSalePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decWholeSalePrice = Convert.ToDecimal(this.txtWholeSalePrice.Text);
            }
            if (this.txtRetailPrice.Text.Length <= 0)
            {
                objPDDAO.decRetailPrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decRetailPrice = Convert.ToDecimal(this.txtRetailPrice.Text);
            }
            objPDDAO.intUserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
            objPDDAO.intOrganizationID = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            objPDDAO.decNBRSDChargablePrice = Convert.ToDecimal(this.txtProposedSDPrice.Text);
            objPDDAO.decNBRSD = Convert.ToDecimal(this.txtSD.Text);
            objPDDAO.decNBRVATChargablePrice = Convert.ToDecimal(this.txtProposedVATPrice.Text);
            if (this.txtWholeSalePrice.Text.Length <= 0)
            {
                objPDDAO.decNBRWholeSalePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decNBRWholeSalePrice = Convert.ToDecimal(this.txtWholeSalePrice.Text);
            }
            if (this.txtRetailPrice.Text.Length <= 0)
            {
                objPDDAO.decNBRRetailPrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decNBRRetailPrice = Convert.ToDecimal(this.txtRetailPrice.Text);
            }
            objPDDAO.decProposedActualPrice = Convert.ToDecimal(this.txtProposedPrice.Text);
            objPDDAO.intDeclarationType = Convert.ToInt32(this.Session["DeclarationType"]);
            if (this.txtTotalPrice.Text.Length <= 0)
            {
                objPDDAO.Total_Price = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.Total_Price = Convert.ToDecimal(this.txtTotalPrice.Text);
            }
            objPDDAO.TradePricePct = (this.txtTradePricePct.Text != "" ? Convert.ToDecimal(this.txtTradePricePct.Text.Trim()) : new decimal(0));
            objPDDAO.TradePriceValue = (this.txtTradePriceValue.Text != "" ? Convert.ToDecimal(this.txtTradePriceValue.Text.Trim()) : new decimal(0));
            objPDDAO.ProductQuantity = (this.txtsongkha.Text != "" ? Convert.ToInt32(this.txtsongkha.Text.Trim()) : 1);
            objPDDAO.HealthCharge = (this.txthlthcharge.Text != "" ? Convert.ToDecimal(this.txthlthcharge.Text.Trim()) : new decimal(0));
            objPDDAO.StickQuantity = (this.lblstickQuantity.Text != "" ? Convert.ToDecimal(this.lblstickQuantity.Text.Trim()) : new decimal(0));
            if (!(this.drpProperty.SelectedValue != "-99") || !(this.drpProperty.SelectedValue != ""))
            {
                objPDDAO.property_id = 0;
            }
            else
            {
                objPDDAO.property_id = Convert.ToInt16(this.drpProperty.SelectedValue);
            }
            return objPDDAO;
        }

        private NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAO insertPriceDeclarationFUpdate(NBR_VAT_GROUPOFCOM.BLL.PriceDeclaretionDAO objPDDAO)
        {
            DataTable dataTable = PriceDeclaration.objPDBll.IsExistDeclaretion(this.txtPriceDeclaretionNo.Text.ToString());
            objPDDAO.intPriceID = Convert.ToInt16(dataTable.Rows[0]["price_id"].ToString());
            int num = Convert.ToInt32(this.drpBranchName.SelectedItem.Value.ToString());
            objPDDAO.BranchID = num;
            objPDDAO.strPriceDeclaretionNo =  BLL.Utility.ReplaceQuotes(this.txtPriceDeclaretionNo.Text.Trim());
            objPDDAO.intPriceDeclaretionYear = Convert.ToInt32(this.ddlYear.SelectedItem.Value.ToString());
            objPDDAO.dtActiveDate = DateTime.ParseExact(this.txtActiveDate.Text, "dd/MM/yyyy", null);
            objPDDAO.intItemId = Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString());
            objPDDAO.AgreementNo = this.txtAgreementNo.Text.ToString();
            objPDDAO.TradePricePct = Convert.ToDecimal(this.txtTradePricePct.Text.ToString());
            objPDDAO.Trade_price_value = Convert.ToDecimal(this.txtTradePriceValue.Text.ToString());
            objPDDAO.ProductQuantity = (this.txtsongkha.Text != "" ? Convert.ToInt32(this.txtsongkha.Text.Trim()) : 1);
            int num1 = PriceDeclaration.objPDBll.intItemUnitId(Convert.ToInt32(this.ddlItem.SelectedItem.Value.ToString()));
            objPDDAO.intUnitId = num1;
            if (this.txtCurrentSDPrice.Text.Length <= 0)
            {
                objPDDAO.decCurrentSDChargablePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decCurrentSDChargablePrice = Convert.ToDecimal(this.txtCurrentSDPrice.Text);
            }
            objPDDAO.decProposedSDChargablePric = Convert.ToDecimal(this.txtProposedSDPrice.Text);
            objPDDAO.decSD = Convert.ToDecimal(this.txtSD.Text);
            if (this.txtCurrentVATPrice.Text.Length <= 0)
            {
                objPDDAO.decCurrentVATChargablePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decCurrentVATChargablePrice = Convert.ToDecimal(this.txtCurrentVATPrice.Text);
            }
            objPDDAO.decProposedVATChargabelPrice = Convert.ToDecimal(this.txtProposedVATPrice.Text);
            if (this.txtWholeSalePrice.Text.Length <= 0)
            {
                objPDDAO.decWholeSalePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decWholeSalePrice = Convert.ToDecimal(this.txtWholeSalePrice.Text);
            }
            if (this.txtRetailPrice.Text.Length <= 0)
            {
                objPDDAO.decRetailPrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decRetailPrice = Convert.ToDecimal(this.txtRetailPrice.Text);
            }
            objPDDAO.intUserIdInsert = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
            objPDDAO.intOrganizationID = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            objPDDAO.decNBRSDChargablePrice = Convert.ToDecimal(this.txtProposedSDPrice.Text);
            objPDDAO.decNBRSD = Convert.ToDecimal(this.txtSD.Text);
            objPDDAO.decNBRVATChargablePrice = Convert.ToDecimal(this.txtProposedVATPrice.Text);
            if (this.txtWholeSalePrice.Text.Length <= 0)
            {
                objPDDAO.decNBRWholeSalePrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decNBRWholeSalePrice = Convert.ToDecimal(this.txtWholeSalePrice.Text);
            }
            if (this.txtRetailPrice.Text.Length <= 0)
            {
                objPDDAO.decNBRRetailPrice = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.decNBRRetailPrice = Convert.ToDecimal(this.txtRetailPrice.Text);
            }
            objPDDAO.decProposedActualPrice = Convert.ToDecimal(this.txtProposedPrice.Text);
            objPDDAO.intDeclarationType = Convert.ToInt32(this.Session["DeclarationType"]);
            if (this.txtTotalPrice.Text.Length <= 0)
            {
                objPDDAO.Total_Price = Convert.ToDecimal("0.00");
            }
            else
            {
                objPDDAO.Total_Price = Convert.ToDecimal(this.txtTotalPrice.Text);
            }
            objPDDAO.TradePricePct = (this.txtTradePricePct.Text != "" ? Convert.ToDecimal(this.txtTradePricePct.Text.Trim()) : new decimal(0));
            objPDDAO.TradePriceValue = (this.txtTradePriceValue.Text != "" ? Convert.ToDecimal(this.txtTradePriceValue.Text.Trim()) : new decimal(0));
            return objPDDAO;
        }

        private PriceDeclaretionRawDAO insertPriceDeclarationRaw(PriceDeclaretionRawDAO objPDRDAO, int intRowId)
        {
            return objPDRDAO;
        }

        private void itemWiseCalculation()
        {
        }

        private void LoadCategory()
        {
            DataTable dataTable = new DataTable();
            AddItemBLL addItemBLL = new AddItemBLL();
            try
            {
                dataTable = addItemBLL.GetAllCategoryforDLL();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.ddlItemCategory.DataSource = dataTable;
                    this.ddlItemCategory.DataTextField = dataTable.Columns["category_name"].ToString();
                    this.ddlItemCategory.DataValueField = dataTable.Columns["category_id"].ToString();
                    this.ddlItemCategory.DataBind();
                    ListItem listItem = new ListItem("--- Select ---", "-1");
                    this.ddlItemCategory.Items.Insert(0, listItem);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void LoadDesignationInfo()
        {
            int num = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
            DataSet designationInfo = this.reports.GetDesignationInfo(num);
            if (designationInfo != null)
            {
                int count = designationInfo.Tables[0].Rows.Count;
            }
        }

        private void LoadFinishedGoods()
        {
            try
            {
                AddItemBLL addItemBLL = new AddItemBLL();
                SetItemDAO setItemDAO = new SetItemDAO();
                if (this.ddlItemCategory.SelectedValue != "" && this.ddlItemCategory.SelectedValue != "-99")
                {
                    setItemDAO.CategoryID = Convert.ToInt32(this.ddlItemCategory.SelectedValue);
                }
                DataTable allItemByProdType = addItemBLL.GetAllItemByProdType(setItemDAO, "P");
                this.ddlItem.DataSource = allItemByProdType;
                this.ddlItem.DataTextField = allItemByProdType.Columns["ITEM_NAME"].ToString();
                this.ddlItem.DataValueField = allItemByProdType.Columns["ITEM_ID"].ToString();
                this.ddlItem.DataBind();
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.ddlItem.Items.Insert(0, listItem);
                this.ddlItem.Focus();
            }
            catch (Exception exception)
            {
            }
        }

        private void LoadItem()
        {
            this.ddlItem.Items.Clear();
            DataSet productForPD = this.ItemBll.GetProductForPD();
            if (productForPD != null && productForPD.Tables[0].Rows.Count > 0)
            {
                this.ddlItem.DataSource = productForPD;
                this.ddlItem.DataTextField = productForPD.Tables[0].Columns["item_name"].ToString();
                this.ddlItem.DataValueField = productForPD.Tables[0].Columns["item_id"].ToString();
                this.ddlItem.DataBind();
            }
            ListItem listItem = new ListItem("-- Select ---", "-99");
            this.ddlItem.Items.Insert(0, listItem);
        }

        private void LoadItemFSearch()
        {
            this.drpSearchItem.Items.Clear();
            DataSet productForPD = this.ItemBll.GetProductForPD();
            if (productForPD != null && productForPD.Tables[0].Rows.Count > 0)
            {
                this.drpSearchItem.DataSource = productForPD;
                this.drpSearchItem.DataTextField = productForPD.Tables[0].Columns["item_name"].ToString();
                this.drpSearchItem.DataValueField = productForPD.Tables[0].Columns["item_id"].ToString();
                this.drpSearchItem.DataBind();
            }
            ListItem listItem = new ListItem("-- Select ---", "-99");
            this.drpSearchItem.Items.Insert(0, listItem);
        }

        private void LoadOrgRegistrationInfoTable()
        {
            int num = Convert.ToInt16(this.Session["EMPLOYEE_ID"]);
            DataSet dataSet = this.reports.OrgRegistrationInfoTable(num);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                this.lblOrganization.Text = dataSet.Tables[0].Rows[0]["organization_Name"].ToString();
                this.lblOrgBIN.Text = dataSet.Tables[0].Rows[0]["registration_no"].ToString();
            }
        }

        private void LoadPresentAddress()
        {
            this.orgRegInfo.GetAllDistrictInformation();
            int num = Convert.ToInt16(this.Session["ORGANIZATION_ID"]);
            DataTable dataTable = this.orgReg.LoadFullTableAllAddressPresentAddress(num);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                dataTable.Rows[0]["holding"].ToString();
                dataTable.Rows[0]["road_no"].ToString();
                dataTable.Rows[0]["block_area"].ToString();
                dataTable.Rows[0]["road"].ToString();
                string str = dataTable.Rows[0]["district_name"].ToString();
                string str1 = dataTable.Rows[0]["upazila_name"].ToString();
                this.lblOrgAddress.Text = string.Concat(str, ",", str1);
            }
        }

        protected PrincipalInput makeNewPrincipalInput(int index, DataRow excelRow, DataRow resultItem, DataRow resultUnit)
        {
          NBR_VAT_GROUPOFCOM.BLL.PrincipalInput principalInput = new PrincipalInput()
            {
                RowNo = new int?(index),
                SubCategoryId = new int?((!string.IsNullOrWhiteSpace(resultItem["category_id"].ToString()) ? (int)Convert.ToInt16(resultItem["category_id"]) : -99)),
                ItemId = new int?((!string.IsNullOrWhiteSpace(resultItem["item_id"].ToString()) ? (int)Convert.ToInt16(resultItem["item_id"]) : -99)),
                Stock = new decimal?((!string.IsNullOrWhiteSpace(excelRow["Stock"].ToString()) ? Convert.ToDecimal(excelRow["Stock"]) : new decimal(0))),
                StockUnit = new int?((!string.IsNullOrWhiteSpace(resultItem["unit_id"].ToString()) ? (int)Convert.ToInt16(resultItem["unit_id"]) : -99)),
                GrossUsages = new decimal?((!string.IsNullOrWhiteSpace(excelRow["GrossUsages"].ToString()) ? Convert.ToDecimal(excelRow["GrossUsages"]) : new decimal(0))),
                GrossUsagesUnit = (!string.IsNullOrWhiteSpace(resultUnit["unit_id"].ToString()) ? (int)Convert.ToInt16(resultUnit["unit_id"]) : -99),
                WastagePercent = new decimal?((!string.IsNullOrWhiteSpace(excelRow["WastagePercent"].ToString()) ? Convert.ToDecimal(excelRow["WastagePercent"]) : new decimal(0))),
                Wastage = new decimal?((!string.IsNullOrWhiteSpace(excelRow["Wastage"].ToString()) ? Convert.ToDecimal(excelRow["Wastage"]) : new decimal(0))),
                NeatUsages = new decimal?((!string.IsNullOrWhiteSpace(excelRow["NeatUsages"].ToString()) ? Convert.ToDecimal(excelRow["NeatUsages"]) : new decimal(0))),
                ShipmentQuantity = new decimal?((!string.IsNullOrWhiteSpace(excelRow["ShipmentQuantity"].ToString()) ? Convert.ToDecimal(excelRow["ShipmentQuantity"]) : new decimal(0))),
                ShipmentCost = new decimal?((!string.IsNullOrWhiteSpace(excelRow["ShipmentCost"].ToString()) ? Convert.ToDecimal(excelRow["ShipmentCost"]) : new decimal(0))),
                NumberOfProduction = new decimal?((!string.IsNullOrWhiteSpace(excelRow["NumberOfProduction"].ToString()) ? Convert.ToDecimal(excelRow["NumberOfProduction"]) : new decimal(0))),
                Cost = new decimal?((!string.IsNullOrWhiteSpace(excelRow["Cost"].ToString()) ? Convert.ToDecimal(excelRow["Cost"]) : new decimal(0))),
                ShipmentReference = new int?((!string.IsNullOrWhiteSpace(excelRow["ShipmentReference"].ToString()) ? (int)Convert.ToInt16(excelRow["ShipmentReference"]) : -99)),
                Remarks = (!string.IsNullOrWhiteSpace(excelRow["Remarks"].ToString()) ? excelRow["Remarks"].ToString() : string.Empty)
            };
            return principalInput;
        }

        protected DataRow makeNewRow(PrincipalInput pi, DataRow row)
        {
            row["row_no"] = pi.RowNo;
            row["item_id"] = pi.ItemId;
            row["unit_id"] = pi.StockUnit;
            row["unit_id_sec"] = pi.GrossUsagesUnit;
            row["stock"] = pi.Stock;
            row["gross_usages"] = pi.GrossUsages;
            row["wastage_percent"] = pi.WastagePercent;
            row["wastage"] = pi.Wastage;
            row["neat_usages"] = pi.NeatUsages;
            row["shipment_quantity"] = pi.ShipmentQuantity;
            row["shipment_cost"] = pi.ShipmentCost;
            row["number_of_production"] = pi.NumberOfProduction;
            row["cost"] = pi.Cost;
            row["reference"] = pi.ShipmentReference;
            row["remarks"] = pi.Remarks;
            return row;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.Session["tobacco"] = "";
                this.txtTradePricePct.Text = "0";
                this.Session["ProposedSDChargablePrice"] = 0;
                this.Session["ProposedVATChargablePrice"] = 0;
                this.Session["PriceId"] = 0;
                this.Session["DeclarationType"] = 1;
                Dictionary<string, string> strs = new Dictionary<string, string>();
                ListItem listItem = new ListItem("-- Select --", "-99");
                 BLL.Utility.fillYearListTest(this.ddlYear);
                if (this.ddlItemCategory.Items.Count > 0)
                {
                    this.LoadFinishedGoods();
                }
                this.showItemEntryGirdView(this.itemRowNo);
                this.GetBranchInformation();
                this.GetBranchAddress();
                this.GetBranchBIN();
                this.showValueAdditionDataInGridView();
                this.showValueAdditionNonItemDataInGridView();
                this.Session["dtInSession"] = null;
                this.LoadItem();
                this.LoadItemFSearch();
                this.LoadOrgRegistrationInfoTable();
                this.lblOrgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
            }
            this.msgBox.Visible = false;
            this.txtActiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private bool SaveRowProdrouctItems()
        {
            bool flag = true;
            ArrayList arrayLists = new ArrayList();
            arrayLists = this.getRowItemPriceProperties(arrayLists);
            if (arrayLists.Count > 0)
            {
                flag = PriceDeclaration.objPDBll.InsertRowProductItem(arrayLists);
            }
            return flag;
        }

        private void setAddMode()
        {
            this.btnSave.Text = "Save Declaretion";
        }

        private void SetPreviousData()
        {
            int num = 0;
            try
            {
                if (this.ViewState["CurrentTable"] != null)
                {
                    DataTable item = (DataTable)this.ViewState["CurrentTable"];
                    if (item.Rows.Count > 0)
                    {
                        for (int i = 0; i < item.Rows.Count; i++)
                        {
                            DropDownList str = (DropDownList)this.gvItems.Rows[num].FindControl("drpCategory");
                            DropDownList dropDownList = (DropDownList)this.gvItems.Rows[num].FindControl("drpItemName");
                            TextBox textBox = (TextBox)this.gvItems.Rows[num].FindControl("txtAvailableStock");
                            Label label = (Label)this.gvItems.Rows[num].FindControl("lblItemUnitId");
                            Label str1 = (Label)this.gvItems.Rows[num].FindControl("lblItemUnit");
                            TextBox textBox1 = (TextBox)this.gvItems.Rows[num].FindControl("txtItemQuantity");
                            DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[num].FindControl("ddlUnit");
                            DropDownList str2 = (DropDownList)this.gvItems.Rows[num].FindControl("ddlUnitSec");
                            TextBox textBox2 = (TextBox)this.gvItems.Rows[num].FindControl("txtQuantity");
                            TextBox str3 = (TextBox)this.gvItems.Rows[num].FindControl("txtQuantityTotal");
                            TextBox textBox3 = (TextBox)this.gvItems.Rows[num].FindControl("txtWastageParcent");
                            TextBox str4 = (TextBox)this.gvItems.Rows[num].FindControl("txtWastage");
                            TextBox textBox4 = (TextBox)this.gvItems.Rows[num].FindControl("txtChallanPrice");
                            TextBox str5 = (TextBox)this.gvItems.Rows[num].FindControl("txtChallanQuantity");
                            TextBox textBox5 = (TextBox)this.gvItems.Rows[num].FindControl("txtProductionQuantity");
                            DropDownList dropDownList2 = (DropDownList)this.gvItems.Rows[num].FindControl("txtReference");
                            TextBox str6 = (TextBox)this.gvItems.Rows[num].FindControl("txtQuantity");
                            TextBox textBox6 = (TextBox)this.gvItems.Rows[num].FindControl("txtRemarks");
                            str.SelectedValue = item.Rows[i]["drpCategoryValue"].ToString();
                            this.drpCategory_SelectedIndexChanged(str, null);
                            dropDownList.SelectedValue = item.Rows[i]["drpItemNameValue"].ToString();
                            label.Text = item.Rows[i]["lblItemUnitIdValue"].ToString();
                            str1.Text = item.Rows[i]["lblItemUnitValue"].ToString();
                            dropDownList1.SelectedValue = item.Rows[i]["ddlUnit"].ToString();
                            str2.SelectedValue = item.Rows[i]["ddlUnitSec"].ToString();
                            DropDownList dropDownList3 = (DropDownList)this.gvItems.Rows[num].FindControl("ddlUnitChallan");
                             BLL.Utility.fillAllUnit(dropDownList3);
                            ListItem listItem = new ListItem("-- Select ---", "-99");
                            dropDownList3.Items.Insert(0, listItem);
                            dropDownList3.SelectedValue = item.Rows[i]["ddlUnitChallan"].ToString();
                            textBox2.Text = item.Rows[i]["txtPriceValue"].ToString();
                            str4.Text = item.Rows[i]["txtWastageValue"].ToString();
                            textBox6.Text = item.Rows[i]["txtRemarks"].ToString();
                            dropDownList2.SelectedValue = item.Rows[i]["txtReference"].ToString();
                            if (item.Rows[i]["txtQuantityTotal"].ToString() != string.Empty)
                            {
                                textBox.Text = item.Rows[i]["txtAvailableStock"].ToString();
                            }
                            else
                            {
                                textBox.Text = "0.00";
                            }
                            if (item.Rows[i]["txtQuantityTotal"].ToString() != string.Empty)
                            {
                                str3.Text = item.Rows[i]["txtQuantityTotal"].ToString();
                            }
                            else
                            {
                                str3.Text = "0.00";
                            }
                            if (item.Rows[i]["txtWastageParcent"].ToString() != string.Empty)
                            {
                                textBox3.Text = item.Rows[i]["txtWastageParcent"].ToString();
                            }
                            else
                            {
                                textBox3.Text = "0.00";
                            }
                            if (item.Rows[i]["txtWastage"].ToString() != string.Empty)
                            {
                                str4.Text = item.Rows[i]["txtWastage"].ToString();
                            }
                            else
                            {
                                str4.Text = "0.00";
                            }
                            if (item.Rows[i]["txtChallanPrice"].ToString() != string.Empty)
                            {
                                textBox4.Text = item.Rows[i]["txtChallanPrice"].ToString();
                            }
                            else
                            {
                                textBox4.Text = "0.00";
                            }
                            if (item.Rows[i]["txtChallanQuantity"].ToString() != string.Empty)
                            {
                                str5.Text = item.Rows[i]["txtChallanQuantity"].ToString();
                            }
                            else
                            {
                                str5.Text = "0.00";
                            }
                            if (item.Rows[i]["txtProductionQuantity"].ToString() != string.Empty)
                            {
                                textBox5.Text = item.Rows[i]["txtProductionQuantity"].ToString();
                            }
                            else
                            {
                                textBox5.Text = "0.00";
                            }
                            if (item.Rows[i]["txtItemQuantity"].ToString() != string.Empty)
                            {
                                textBox1.Text = item.Rows[i]["txtItemQuantity"].ToString();
                            }
                            else
                            {
                                textBox1.Text = "0.00";
                            }
                            if (item.Rows[i]["txtReference"].ToString() != string.Empty)
                            {
                                dropDownList2.Text = item.Rows[i]["txtReference"].ToString();
                            }
                            else
                            {
                                ListItem listItem1 = new ListItem("-- Select ---", "-99");
                                dropDownList2.Items.Insert(0, listItem1);
                            }
                            if (item.Rows[i]["txtQuantity"].ToString() != string.Empty)
                            {
                                str6.Text = item.Rows[i]["txtQuantity"].ToString();
                            }
                            else
                            {
                                str6.Text = "0.00";
                            }
                            num++;
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
                 BLL.Utility.InsertErrorTrackNew(exception.Message, "PriceDeclaration", "setpreviousdata", fileLineNumber);
            }
        }

        public void showDataInGridView()
        {
            DataSet allPriceDeclarationByType = PriceDeclaration.objPDBll.getAllPriceDeclarationByType(Convert.ToInt32(this.Session["DeclarationType"]));
            this.gvDeclaretion.DataSource = allPriceDeclarationByType;
            this.gvDeclaretion.DataBind();
        }

        public void showDataInGridViewBySearch(int item_id)
        {
            DataSet allPriceDeclarationBySearch = PriceDeclaration.objPDBll.getAllPriceDeclarationBySearch(item_id);
            this.gvDeclaretion.DataSource = allPriceDeclarationBySearch;
            this.gvDeclaretion.DataBind();
        }

        protected void showExcelDataIntoGrid(DataTable dt)
        {
            if (dt.Rows.Count > 0 && dt != null)
            {
                this.showItemEntryGirdView(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList str = (DropDownList)this.gvItems.Rows[i].FindControl("drpItemName");
                    DropDownList dropDownList = (DropDownList)this.gvItems.Rows[i].FindControl("drpCategory");
                    DataTable allRawItem = PriceDeclaration.objPDBll.getAllRawItem();
                    if (allRawItem != null && allRawItem.Rows.Count > 0)
                    {
                        str.DataSourceID = null;
                        str.DataSource = allRawItem;
                        str.DataTextField = allRawItem.Columns["item_name"].ToString();
                        str.DataValueField = allRawItem.Columns["Item_id"].ToString();
                        str.DataBind();
                    }
                    ListItem listItem = new ListItem("-- Select ---", "-99");
                    str.Items.Insert(0, listItem);
                    str.SelectedValue = dt.Rows[i]["item_id"].ToString();
                    DropDownList str1 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnit");
                     BLL.Utility.fillAllUnitWithParameter(str1, Convert.ToInt16(dt.Rows[i]["unit_id"].ToString()));
                    DataTable unit = PriceDeclaration.objPDBll.getUnit();
                    if (unit != null && unit.Rows.Count > 0)
                    {
                        str1.DataSourceID = null;
                        str1.DataSource = unit;
                        str1.DataTextField = unit.Columns["unit_code"].ToString();
                        str1.DataValueField = unit.Columns["unit_id"].ToString();
                        str1.DataBind();
                    }
                    ListItem listItem1 = new ListItem("-- Select ---", "-99");
                    str1.Items.Insert(0, listItem1);
                    str1.SelectedValue = dt.Rows[i]["unit_id"].ToString();
                    DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnitSec");
                     BLL.Utility.fillAllUnitWithParameter(dropDownList1, Convert.ToInt16(dt.Rows[i]["unit_id_sec"].ToString()));
                    if (unit != null && unit.Rows.Count > 0)
                    {
                        dropDownList1.DataSourceID = null;
                        dropDownList1.DataSource = unit;
                        dropDownList1.DataTextField = unit.Columns["unit_code"].ToString();
                        dropDownList1.DataValueField = unit.Columns["unit_id"].ToString();
                        dropDownList1.DataBind();
                    }
                    ListItem listItem2 = new ListItem("-- Select ---", "-99");
                    dropDownList1.Items.Insert(0, listItem2);
                    dropDownList1.SelectedValue = dt.Rows[i]["unit_id_sec"].ToString();
                    TextBox textBox = (TextBox)this.gvItems.Rows[i].FindControl("txtAvailableStock");
                    textBox.Text = dt.Rows[i]["stock"].ToString();
                    DataTable subCategoryWithItem = PriceDeclaration.objPDBll.GetSubCategoryWithItem(Convert.ToInt16(dt.Rows[i]["item_id"].ToString()));
                    DataTable subCategory = PriceDeclaration.objPDBll.GetSubCategory();
                    if (subCategory != null && subCategory.Rows.Count > 0)
                    {
                        dropDownList.DataSourceID = null;
                        dropDownList.DataSource = subCategory;
                        dropDownList.DataTextField = subCategory.Columns["category_name"].ToString();
                        dropDownList.DataValueField = subCategory.Columns["category_id"].ToString();
                        dropDownList.DataBind();
                    }
                    ListItem listItem3 = new ListItem("-- Select ---", "-99");
                    dropDownList.Items.Insert(0, listItem3);
                    dropDownList.SelectedValue = subCategoryWithItem.Rows[0]["category_id"].ToString();
                    TextBox textBox1 = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantityTotal");
                    decimal num = Convert.ToDecimal(dt.Rows[i]["gross_usages"]);
                    textBox1.Text = num.ToString("0.0000");
                    TextBox str2 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastageParcent");
                    decimal num1 = Convert.ToDecimal(dt.Rows[i]["wastage_percent"]);
                    str2.Text = num1.ToString("0.0000");
                    TextBox textBox2 = (TextBox)this.gvItems.Rows[i].FindControl("txtWastage");
                    decimal num2 = Convert.ToDecimal(dt.Rows[i]["wastage"]);
                    textBox2.Text = num2.ToString("0.0000");
                    TextBox str3 = (TextBox)this.gvItems.Rows[i].FindControl("txtItemQuantity");
                    decimal num3 = Convert.ToDecimal(dt.Rows[i]["neat_usages"]);
                    str3.Text = num3.ToString("0.0000");
                    TextBox textBox3 = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanPrice");
                    decimal num4 = Convert.ToDecimal(dt.Rows[i]["shipment_cost"]);
                    textBox3.Text = num4.ToString("0.0000");
                    TextBox str4 = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanQuantity");
                    decimal num5 = Convert.ToDecimal(dt.Rows[i]["shipment_quantity"]);
                    str4.Text = num5.ToString("0.0000");
                    TextBox textBox4 = (TextBox)this.gvItems.Rows[i].FindControl("txtProductionQuantity");
                    decimal num6 = Convert.ToDecimal(dt.Rows[i]["number_of_production"]);
                    textBox4.Text = num6.ToString("0.0000");
                    TextBox str5 = (TextBox)this.gvItems.Rows[i].FindControl("txtQuantity");
                    decimal num7 = Convert.ToDecimal(dt.Rows[i]["cost"]);
                    str5.Text = num7.ToString("0.0000");
                    TextBox textBox5 = (TextBox)this.gvItems.Rows[i].FindControl("txtRemarks");
                    textBox5.Text = dt.Rows[i]["remarks"].ToString();
                    DropDownList dropDownList2 = (DropDownList)this.gvItems.Rows[i].FindControl("txtReference");
                    int num8 = Convert.ToInt16(dt.Rows[i]["item_id"].ToString());
                    if (dt.Rows[i]["reference"].ToString() != "")
                    {
                         BLL.Utility.fillchallanWithParameter(dropDownList2, Convert.ToInt32(dt.Rows[i]["reference"].ToString()));
                        DataTable itemChallaNo = this.objBLL.GetItemChallaNo(num8);
                        if (itemChallaNo.Rows.Count > 0)
                        {
                            dropDownList2.DataSource = itemChallaNo;
                            dropDownList2.DataTextField = itemChallaNo.Columns["challan_no"].ToString();
                            dropDownList2.DataValueField = itemChallaNo.Columns["challan_id"].ToString();
                            dropDownList2.DataBind();
                        }
                        ListItem listItem4 = new ListItem("-- Select ---", "-99");
                        dropDownList2.Items.Insert(0, listItem4);
                        dropDownList2.SelectedValue = dt.Rows[i]["reference"].ToString();
                    }
                    TextBox str6 = (TextBox)this.gvItems.Rows[i].FindControl("txtRowNO");
                    decimal num9 = Convert.ToDecimal(dt.Rows[i]["row_no"]);
                    str6.Text = num9.ToString();
                }
            }
        }

        private void showItemEntryGirdView(int totalRowNo)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("HIDDEN_ROW_ID");
            dataTable.Columns.Add("drpCategoryValue");
            dataTable.Columns.Add("drpItemNameValue");
            dataTable.Columns.Add("txtAvailableStock");
            dataTable.Columns.Add("lblItemUnitIdValue");
            dataTable.Columns.Add("lblItemUnitValue");
            dataTable.Columns.Add("txtItemQuantity");
            dataTable.Columns.Add("ddlUnit");
            dataTable.Columns.Add("ddlUnitSec");
            dataTable.Columns.Add("ddlUnitChallan");
            dataTable.Columns.Add("txtPriceValue");
            dataTable.Columns.Add("txtWastageValue");
            dataTable.Columns.Add("txtWastageParcent");
            dataTable.Columns.Add("txtQuantityPartial");
            dataTable.Columns.Add("txtQuantity");
            dataTable.Columns.Add("txtQuantityTotal");
            dataTable.Columns.Add("txtWastage");
            dataTable.Columns.Add("txtChallanPrice");
            dataTable.Columns.Add("txtChallanQuantity");
            dataTable.Columns.Add("txtProductionQuantity");
            dataTable.Columns.Add("txtReference");
            dataTable.Columns.Add("txtRemarks");
            dataTable.Columns.Add("txtRowNO");
            int num = this.itemRowNo;
            if (totalRowNo > 0)
            {
                num = totalRowNo;
            }
            for (int i = 0; i < num; i++)
            {
                DataRow str = dataTable.NewRow();
                str["HIDDEN_ROW_ID"] = i.ToString();
                dataTable.Rows.Add(str);
            }
            this.ViewState["CurrentTable"] = dataTable;
            this.gvItems.DataSource = dataTable;
            this.gvItems.DataBind();
            for (int j = 0; j < this.gvItems.Rows.Count; j++)
            {
                DropDownList dropDownList = (DropDownList)this.gvItems.Rows[j].FindControl("drpItemName");
                DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[j].FindControl("ddlUnit");
                DropDownList dropDownList2 = (DropDownList)this.gvItems.Rows[j].FindControl("ddlUnitSec");
                DropDownList dropDownList3 = (DropDownList)this.gvItems.Rows[j].FindControl("ddlUnitChallan");
                BLL.Utility.fillAllItemPD(dropDownList);
                ListItem listItem = new ListItem("-- Select ---", "-99");
                dropDownList.Items.Insert(0, listItem);
                 BLL.Utility.fillAllUnit(dropDownList1);
                dropDownList1.Items.Insert(0, listItem);
                 BLL.Utility.fillAllUnit(dropDownList3);
                dropDownList3.Items.Insert(0, listItem);
                 BLL.Utility.fillAllUnit(dropDownList2);
                dropDownList2.Items.Insert(0, listItem);
            }
             BLL.Utility.fillAllUnit(this.drpUnit);
        }

        public void showNBRValueAdditionDataInGridView(int intPriceId)
        {
            DataSet allNBRValueAdditionArea = PriceDeclaration.objPDBll.getAllNBRValueAdditionArea(intPriceId);
            this.gvNBRValueAddition.DataSource = allNBRValueAdditionArea;
            this.gvNBRValueAddition.DataBind();
        }

        public void showValueAdditionDataInGridView()
        {
            DataSet allValueAdditionArea = PriceDeclaration.objPDBll.getAllValueAdditionArea();
            this.gvValueAddition.DataSource = allValueAdditionArea;
            this.gvValueAddition.DataBind();
            foreach (GridViewRow row in this.gvValueAddition.Rows)
            {
                if ((row.FindControl("lblvStatus") as Label).Text != "H")
                {
                    continue;
                }
                row.Visible = false;
            }
        }

        public void showValueAdditionNonItemDataInGridView()
        {
            DataSet allValueAdditionNotItemArea = PriceDeclaration.objPDBll.getAllValueAdditionNotItemArea();
            this.gvValueAdditionNonItem.DataSource = allValueAdditionNotItemArea;
            this.gvValueAdditionNonItem.DataBind();
            foreach (GridViewRow row in this.gvValueAdditionNonItem.Rows)
            {
                if ((row.FindControl("lblvStatus1") as Label).Text != "H")
                {
                    continue;
                }
                row.Visible = false;
            }
        }

        protected void txtChallanPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
                TextBox textBox = (TextBox)namingContainer.FindControl("txtQuantityTotal");
                TextBox textBox1 = (TextBox)namingContainer.FindControl("txtChallanQuantity");
                TextBox textBox2 = (TextBox)namingContainer.FindControl("txtChallanPrice");
                TextBox str = (TextBox)namingContainer.FindControl("txtQuantity");
                DropDownList dropDownList = (DropDownList)namingContainer.FindControl("ddlUnitSec");
                DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("ddlUnit");
                decimal num4 = new decimal(0);
                decimal num5 = new decimal(0);
                int num6 = Convert.ToInt16(dropDownList.SelectedItem.Value.ToString());
                int num7 = Convert.ToInt16(dropDownList1.SelectedItem.Value.ToString());
                DataTable value = this.objBLL.GetValue(num7, num6);
                if (value.Rows.Count > 0)
                {
                    num4 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                }
                num = (!string.IsNullOrEmpty(textBox.Text) ? Convert.ToDecimal(textBox.Text) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(textBox1.Text) ? Convert.ToDecimal(textBox1.Text) : new decimal(0));
                if (textBox2.Text == "")
                {
                    num2 = new decimal(0);
                }
                else if (Convert.ToDecimal(textBox1.Text.Trim()) == new decimal(0))
                {
                    num2 = new decimal(0);
                }
                else
                {
                    num2 = Convert.ToDecimal(textBox2.Text.Trim());
                    num3 = (num2 / num1) * num;
                    str.Text = num3.ToString("0.0000");
                }
                if (textBox2.Text != "" && dropDownList.SelectedValue != "-99" && num1 > new decimal(0))
                {
                    if (Convert.ToDecimal(textBox1.Text.Trim()) != new decimal(0))
                    {
                        if (num4 > new decimal(0))
                        {
                            decimal num8 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox1.Text.Trim()) * num4)) * num;
                            str.Text = num8.ToString("0.0000");
                        }
                        if (num4 == new decimal(0))
                        {
                            DataTable valueSec = this.objBLL.GetValueSec(num7, num6);
                            if (valueSec.Rows.Count > 0)
                            {
                                num5 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                            }
                            if (num5 <= new decimal(0))
                            {
                                decimal num9 = (num2 / num1) * num;
                                str.Text = num9.ToString("0.0000");
                            }
                            else
                            {
                                decimal num10 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox1.Text.Trim()) * (new decimal(1) / num5))) * num;
                                str.Text = num10.ToString("0.0000");
                            }
                        }
                    }
                }
                else if (num1 <= new decimal(0))
                {
                    str.Text = "0.00";
                }
                else
                {
                    decimal num11 = (num2 / num1) * num;
                    str.Text = num11.ToString("0.0000");
                }
                string str1 = "";
                str1 = this.Session["tobacco"].ToString();
                if (str1 == "2402.20.00" || str1 == "2402.90.00")
                {
                    this.GetValueForTobacco();
                    this.GetRowValue();
                }
                else
                {
                    this.GetTotalValue();
                }
                this.CalculateTradePrice();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtChallanQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
                TextBox textBox = (TextBox)namingContainer.FindControl("txtChallanQuantity");
                TextBox textBox1 = (TextBox)namingContainer.FindControl("txtQuantityTotal");
                TextBox str = (TextBox)namingContainer.FindControl("txtProductionQuantity");
                DropDownList dropDownList = (DropDownList)namingContainer.FindControl("ddlUnitSec");
                DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("ddlUnit");
                TextBox textBox2 = (TextBox)namingContainer.FindControl("txtChallanPrice");
                TextBox str1 = (TextBox)namingContainer.FindControl("txtQuantity");
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = Convert.ToInt16(dropDownList.SelectedItem.Value.ToString());
                int num5 = Convert.ToInt16(dropDownList1.SelectedItem.Value.ToString());
                DataTable value = this.objBLL.GetValue(num5, num4);
                if (value.Rows.Count > 0)
                {
                    num2 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                }
                num = (!string.IsNullOrEmpty(textBox1.Text) ? Convert.ToDecimal(textBox1.Text) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(textBox.Text) ? Convert.ToDecimal(textBox.Text) : new decimal(0));
                if (textBox.Text != "" && dropDownList.SelectedValue != "-99" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num6 = (Convert.ToDecimal(textBox.Text) * num2) / Convert.ToDecimal(textBox1.Text);
                        str.Text = num6.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable valueSec = this.objBLL.GetValueSec(num5, num4);
                        if (valueSec.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num7 = (new decimal(1) / num) * num1;
                            str.Text = num7.ToString("0.0000");
                        }
                        else
                        {
                            decimal num8 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num8.ToString("0.0000");
                        }
                    }
                }
                if (textBox.Text != "" && dropDownList.SelectedValue != "-99" && textBox2.Text != "" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num9 = (Convert.ToDecimal(textBox.Text) / Convert.ToDecimal(textBox1.Text)) * num2;
                        str.Text = num9.ToString("0.0000");
                        decimal num10 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * num2)) * num;
                        str1.Text = num10.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable dataTable = this.objBLL.GetValueSec(num5, num4);
                        if (dataTable.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(dataTable.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num11 = (new decimal(1) / num) * num1;
                            str.Text = num11.ToString("0.0000");
                            decimal num12 = (Convert.ToDecimal(textBox2.Text.Trim()) / num1) * num;
                            str1.Text = num12.ToString("0.0000");
                        }
                        else
                        {
                            decimal num13 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num13.ToString("0.0000");
                            decimal num14 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * (new decimal(1) / num3))) * num;
                            str1.Text = num14.ToString("0.0000");
                        }
                    }
                }
                else if (num <= new decimal(0))
                {
                    str.Text = "0.00";
                }
                else
                {
                    decimal num15 = (new decimal(1) / num) * num1;
                    str.Text = num15.ToString("0.0000");
                }
                string str2 = "";
                str2 = this.Session["tobacco"].ToString();
                if (str2 == "2402.20.00" || str2 == "2402.90.00")
                {
                    this.GetValueForTobacco();
                    this.GetRowValue();
                }
                else
                {
                    this.GetTotalValue();
                }
                this.CalculateTradePrice();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtmUnitPrice_TextChanged(object sender, EventArgs e)
        {
            double num;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            try
            {
                num = (this.txtmUnitPrice.Text.Length <= 0 || Convert.ToDouble(this.txtmUnitPrice.Text) <= 0 ? 0 : Convert.ToDouble(this.txtmUnitPrice.Text));
                double num4 = 1 * num;
                num2 = Convert.ToDouble(this.lblmSDPercent.Text);
                double num5 = num4 * num2 / 100;
                this.txtmSD.Text = num5.ToString("0.00");
                num1 = Convert.ToDouble(this.lblmVatPercent.Text);
                num3 = (num4 + num5) * num1 / 100;
                this.txtmVat.Text = num3.ToString("0.00");
                double num6 = num4 + num3 + num5;
                this.txtmVatablePrice.Text = num6.ToString("0.00");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void txtmVatablePrice_TextChanged(object sender, EventArgs e)
        {
            double num;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            try
            {
                num = (this.txtmVatablePrice.Text.Length <= 0 || Convert.ToDouble(this.txtmVatablePrice.Text) <= 0 ? 0 : Convert.ToDouble(this.txtmVatablePrice.Text));
                num2 = Convert.ToDouble(this.lblmVatPercent.Text);
                double num4 = num * num2 / (100 + num2);
                this.txtmVat.Text = num4.ToString("0.00");
                num1 = num - num4;
                num3 = Convert.ToDouble(this.lblmSDPercent.Text);
                double num5 = num1 * num3 / (100 + num3);
                this.txtmSD.Text = num5.ToString("0.00");
                double num6 = num1 - num5;
                this.txtmUnitPrice.Text = num6.ToString("0.00");
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void txtProductionQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                str = this.Session["tobacco"].ToString();
                if (str == "2402.20.00" || str == "2402.90.00")
                {
                    this.GetValueForTobacco();
                    this.GetRowValue();
                }
                else
                {
                    this.GetTotalValue();
                }
                this.CalculateTradePrice();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                str = this.Session["tobacco"].ToString();
                if (str == "2402.20.00" || str == "2402.90.00")
                {
                    this.GetValueForTobacco();
                    this.GetRowValue();
                }
                else
                {
                    this.GetTotalValue();
                }
                this.CalculateTradePrice();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtQuantityTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = new decimal(0);
                decimal num1 = new decimal(0);
                GridViewRow namingContainer = (GridViewRow)((Control)sender).NamingContainer;
                TextBox textBox = (TextBox)namingContainer.FindControl("txtChallanQuantity");
                TextBox textBox1 = (TextBox)namingContainer.FindControl("txtQuantityTotal");
                TextBox str = (TextBox)namingContainer.FindControl("txtProductionQuantity");
                DropDownList dropDownList = (DropDownList)namingContainer.FindControl("ddlUnitSec");
                DropDownList dropDownList1 = (DropDownList)namingContainer.FindControl("ddlUnit");
                TextBox textBox2 = (TextBox)namingContainer.FindControl("txtChallanPrice");
                TextBox str1 = (TextBox)namingContainer.FindControl("txtQuantity");
                decimal num2 = new decimal(0);
                decimal num3 = new decimal(0);
                int num4 = Convert.ToInt16(dropDownList.SelectedItem.Value.ToString());
                int num5 = Convert.ToInt16(dropDownList1.SelectedItem.Value.ToString());
                DataTable value = this.objBLL.GetValue(num5, num4);
                if (value.Rows.Count > 0)
                {
                    num2 = Convert.ToDecimal(value.Rows[0]["value_to"].ToString());
                }
                num = (!string.IsNullOrEmpty(textBox1.Text) ? Convert.ToDecimal(textBox1.Text) : new decimal(0));
                num1 = (!string.IsNullOrEmpty(textBox.Text) ? Convert.ToDecimal(textBox.Text) : new decimal(0));
                if (num1 != new decimal(0) && dropDownList.SelectedValue != "-99" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num6 = (Convert.ToDecimal(textBox.Text) * num2) / Convert.ToDecimal(textBox1.Text);
                        str.Text = num6.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable valueSec = this.objBLL.GetValueSec(num5, num4);
                        if (valueSec.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(valueSec.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num7 = (new decimal(1) / num) * num1;
                            str.Text = num7.ToString("0.0000");
                        }
                        else
                        {
                            decimal num8 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num8.ToString("0.0000");
                        }
                    }
                }
                if (num1 != new decimal(0) && dropDownList.SelectedValue != "-99" && textBox2.Text != "" && num > new decimal(0))
                {
                    if (num2 > new decimal(0))
                    {
                        decimal num9 = (Convert.ToDecimal(textBox.Text) / Convert.ToDecimal(textBox1.Text)) * num2;
                        str.Text = num9.ToString("0.0000");
                        decimal num10 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * num2)) * num;
                        str1.Text = num10.ToString("0.0000");
                    }
                    if (num2 == new decimal(0))
                    {
                        DataTable dataTable = this.objBLL.GetValueSec(num5, num4);
                        if (dataTable.Rows.Count > 0)
                        {
                            num3 = Convert.ToDecimal(dataTable.Rows[0]["value_to"].ToString());
                        }
                        if (num3 <= new decimal(0))
                        {
                            decimal num11 = (new decimal(1) / num) * num1;
                            str.Text = num11.ToString("0.0000");
                            decimal num12 = (Convert.ToDecimal(textBox2.Text.Trim()) / num1) * num;
                            str1.Text = num12.ToString("0.0000");
                        }
                        else
                        {
                            decimal num13 = Convert.ToDecimal(textBox.Text) / (Convert.ToDecimal(textBox1.Text) * num3);
                            str.Text = num13.ToString("0.0000");
                            decimal num14 = (Convert.ToDecimal(textBox2.Text.Trim()) / (Convert.ToDecimal(textBox.Text.Trim()) * (new decimal(1) / num3))) * num;
                            str1.Text = num14.ToString("0.0000");
                        }
                    }
                }
                else if (num <= new decimal(0))
                {
                    str.Text = "0.00";
                }
                else
                {
                    decimal num15 = (new decimal(1) / num) * num1;
                    str.Text = num15.ToString("0.0000");
                }
                string str2 = "";
                str2 = this.Session["tobacco"].ToString();
                if (str2 == "2402.20.00" || str2 == "2402.90.00")
                {
                    this.GetValueForTobacco();
                    this.GetRowValue();
                }
                else
                {
                    this.GetTotalValue();
                }
                this.CalculateTradePrice();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void txtRetailPrice_TextChanged(object sender, EventArgs e)
        {
            string str = "";
            str = this.Session["tobacco"].ToString();
            if (str == "2402.20.00" || str == "2402.90.00")
            {
                this.GetValueForTobacco();
            }
        }

        protected void txtsongkha_TextChanged(object sender, EventArgs e)
        {
            string str = "";
            str = this.Session["tobacco"].ToString();
            if (!(str == "2402.20.00") && !(str == "2402.90.00"))
            {
                this.GetTotalValue();
                return;
            }
            this.GetValueForTobacco();
            this.GetRowValue();
        }

        protected void unCheckisAvg_Changed(object sender, EventArgs e)
        {
            if (this.isAvg.Checked)
            {
                this.isLast.Checked = false;
                this.isManual.Checked = false;
                return;
            }
            this.isAvg.Checked = false;
            this.isLast.Checked = false;
            this.isManual.Checked = false;
        }

        protected void unCheckisLast_Changed(object sender, EventArgs e)
        {
            if (this.isLast.Checked)
            {
                this.isAvg.Checked = false;
                this.isManual.Checked = false;
                return;
            }
            this.isAvg.Checked = false;
            this.isLast.Checked = false;
            this.isManual.Checked = false;
        }

        protected void unCheckisManual_Changed(object sender, EventArgs e)
        {
            if (this.isManual.Checked)
            {
                this.isLast.Checked = false;
                this.isAvg.Checked = false;
                return;
            }
            this.isAvg.Checked = false;
            this.isLast.Checked = false;
            this.isManual.Checked = false;
        }

        protected void UpdateGrandTotal()
        {
            decimal num = new decimal(0);
            foreach (GridViewRow row in this.gvValueAddition.Rows)
            {
                TextBox textBox = (TextBox)row.FindControl("txtValueAddition");
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    continue;
                }
                num += Convert.ToDecimal(textBox.Text.Replace("$", string.Empty).Replace(",", string.Empty));
            }
            Label label = (Label)this.gvValueAddition.FooterRow.FindControl("lblTotalValueAddition");
            label.Text = string.Format("{0:C}", num);
        }

        private bool UpdateRowProdrouctItems()
        {
            bool flag = true;
            try
            {
                Dictionary<string, string> strs = new Dictionary<string, string>();
                GridViewRow selectedRow = this.gvDeclaretion.SelectedRow;
                short num = Convert.ToInt16(this.gvDeclaretion.DataKeys[selectedRow.RowIndex].Value);
                DataTable priceRawItemId = PriceDeclaration.objPDBll.getPriceRawItemId(num);
                ArrayList arrayLists = new ArrayList();
                arrayLists = this.getRowItemPriceProperties(arrayLists);
                if (arrayLists.Count > 0)
                {
                    if (priceRawItemId.Rows.Count > arrayLists.Count)
                    {
                        strs = priceRawItemId.AsEnumerable().ToDictionary<DataRow, string, string>((DataRow row) => row.Field<object>("item_id").ToString(), (DataRow row) => row.Field<object>("price_id").ToString());
                        for (int i = 0; i < arrayLists.Count; i++)
                        {
                            string str = ((NBR_VAT_GROUPOFCOM.BLL.PriceRowItemDAO)arrayLists[i]).ItemId.ToString();
                            if (strs.ContainsKey(str))
                            {
                                strs.Remove(str);
                            }
                        }
                    }
                    flag = PriceDeclaration.objPDBll.UpdateRowProductItem(arrayLists, strs);
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                 BLL.Utility.InsertErrorTrackNew(exception.Message, "PriceDeclaration", "UpdateRowProdrouctItems", fileLineNumber);
            }
            return flag;
        }

        private bool Validation()
        {
            this.msgBox.Visible = true;
            if (this.gvItems.Rows.Count > 0)
            {
                for (int i = 0; i < this.gvItems.Rows.Count; i++)
                {
                    NBR_VAT_GROUPOFCOM.BLL.PriceRowItemDAO priceRowItemDAO = new NBR_VAT_GROUPOFCOM.BLL.PriceRowItemDAO();
                    DropDownList dropDownList = (DropDownList)this.gvItems.Rows[i].FindControl("ddlUnit");
                    DropDownList dropDownList1 = (DropDownList)this.gvItems.Rows[i].FindControl("drpItemName");
                    TextBox textBox = (TextBox)this.gvItems.Rows[i].FindControl("txtChallanQuantity");
                    if (Convert.ToInt16(dropDownList1.SelectedItem.Value.ToString()) != -99 && textBox.Text != "0.00" && Convert.ToInt16(dropDownList.SelectedItem.Value.ToString()) == -99)
                    {
                        this.msgBox.AddMessage(string.Concat("Please select একক(চালান পরিমান). of ", i + 1, " Row"), MsgBoxs.enmMessageType.Attention);
                        return false;
                    }
                }
            }
            if (this.ddlItem.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select a item first.", MsgBoxs.enmMessageType.Attention);
                return false;
            }
            if (this.txtPriceDeclaretionNo.Text.Trim().Length == 0)
            {
                this.msgBox.AddMessage("Please fill declaretion number(মূল্য ঘোষণা নম্বরঃ ).", MsgBoxs.enmMessageType.Attention);
                this.txtPriceDeclaretionNo.Focus();
                return false;
            }
            if (this.ddlYear.Text.Trim() == "Year")
            {
                this.msgBox.AddMessage("Please select a year ).", MsgBoxs.enmMessageType.Attention);
                this.ddlYear.Focus();
                return false;
            }
            if (this.txtTotalPrice.Text.Length == 0)
            {
                this.msgBox.AddMessage("(মোট মূল্য) can't be emty. ).", MsgBoxs.enmMessageType.Attention);
                this.txtTotalPrice.Focus();
                return false;
            }
            if (this.txtSumQuantityTotal.Text.Length == 0)
            {
                this.msgBox.AddMessage("(গ্রস ব্যবহার) can't be emty. ).", MsgBoxs.enmMessageType.Attention);
                this.txtSumQuantityTotal.Focus();
                return false;
            }
            if (this.txtSumWastage.Text.Length == 0)
            {
                this.msgBox.AddMessage("(নীট ব্যবহার) can't be emty. ).", MsgBoxs.enmMessageType.Attention);
                this.txtSumWastage.Focus();
                return false;
            }
            if (this.txtSumItemQuantity.Text.Length != 0)
            {
                return true;
            }
            this.msgBox.AddMessage("(মূল্য) can't be emty. ).", MsgBoxs.enmMessageType.Attention);
            this.txtSumItemQuantity.Focus();
            return false;
        }
    }
}