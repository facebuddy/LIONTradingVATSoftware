using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class ItemSetSetups : Page, IRequiresSessionState
    {
     


        private AddItemBLL objItem = new AddItemBLL();

        private SetItemSetDAO objItemDAO = new SetItemSetDAO();

        private SetItemSetMasterDAO objmaster = new SetItemSetMasterDAO();

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

        public ItemSetSetups()
        {
        }

        private void AddDetailDataInGrid()
        {
            ArrayList item = (ArrayList)this.Session["SetItem_DETAIL_LIST"];
            this.gvItem.DataSource = item;
            this.gvItem.DataBind();
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            this.fillDetailProperties();
            this.AddDetailDataInGrid();
            this.GetTotalValue();
            this.ClearAll();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList arrayLists = new ArrayList();
            ArrayList item = new ArrayList();
            this.fillMasterProperties();
            arrayLists = (ArrayList)this.Session["SetItem_DETAIL_LIST"];
            item = (ArrayList)this.Session["SetItem_Master_LIST"];
            if (this.objItem.InsertSetItem(arrayLists, item))
            {
                this.msgBox.AddMessage("Item Set Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                this.Session["SetItem_DETAIL_LIST"] = new ArrayList();
                this.drpSetItem.SelectedValue = "-99";
                this.gvItem.DataSource = null;
                this.gvItem.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.ShowDataInGridView();
        }

        private void calculatePrice()
        {
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            num = (!string.IsNullOrEmpty(this.txtChallanQuantity.Text) ? Convert.ToDecimal(this.txtChallanQuantity.Text) : new decimal(0));
            num2 = (!string.IsNullOrEmpty(this.txtChallanPrice.Text) ? Convert.ToDecimal(this.txtChallanPrice.Text) : new decimal(0));
            num1 = (!string.IsNullOrEmpty(this.txtQuantityTotal.Text) ? Convert.ToDecimal(this.txtQuantityTotal.Text) : new decimal(0));
            if (num != new decimal(0))
            {
                num3 = (num2 * num1) / num;
                this.txtPrice.Text = num3.ToString();
            }
        }

        private void ClearAll()
        {
            this.drpItem.SelectedValue = "-99";
            this.drpUnit.SelectedValue = "-99";
            this.drpChallan.SelectedValue = "-99";
            this.drpitemUnit.SelectedValue = "-99";
            this.txtChallanQuantity.Text = "";
            this.txtChallanPrice.Text = "";
            this.txtQuantityTotal.Text = "";
            this.txtPrice.Text = "";
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            num = Convert.ToInt32(this.drpChallan.SelectedValue);
            DataTable pricebyChallan = this.objItem.GetPricebyChallan(num);
            if (pricebyChallan.Rows.Count > 0)
            {
                this.txtPrice.Text = pricebyChallan.Rows[0]["purchase_unit_price"].ToString();
            }
        }

        protected void ddlUnitSec_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drpChallan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            num = Convert.ToInt32(this.drpChallan.SelectedValue);
            DataTable pricebyChallan = this.objItem.GetPricebyChallan(num);
            if (pricebyChallan.Rows.Count > 0)
            {
                this.txtChallanPrice.Text = pricebyChallan.Rows[0]["purchase_unit_price"].ToString();
                this.txtChallanQuantity.Text = pricebyChallan.Rows[0]["quantity"].ToString();
            }
        }

        protected void drpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            num = Convert.ToInt32(this.drpItem.SelectedValue);
            DataTable unitbyItem = this.objItem.GetUnitbyItem(num);
            if (unitbyItem.Rows.Count > 0)
            {
                this.drpitemUnit.SelectedValue = unitbyItem.Rows[0]["unit_id"].ToString();
            }
            DataTable challanIdItem = this.objItem.GetChallanIdItem(num);
            if (challanIdItem.Rows.Count > 0)
            {
                this.drpChallan.DataSource = challanIdItem;
                this.drpChallan.DataTextField = challanIdItem.Columns["challan_no"].ToString();
                this.drpChallan.DataValueField = challanIdItem.Columns["challan_id"].ToString();
                this.drpChallan.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpChallan.Items.Insert(0, listItem);
            }
        }

        private void fillDetailProperties()
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["SetItem_DETAIL_LIST"] ?? new ArrayList();
                int num = Convert.ToInt16(item.Count + 1);
                this.objItemDAO.RowNo = num;
                this.objItemDAO.ItemID = Convert.ToInt32(this.drpItem.SelectedValue);
                this.objItemDAO.ItemName = this.drpItem.SelectedItem.ToString();
                this.objItemDAO.UnitName = this.drpUnit.SelectedItem.ToString();
                this.objItemDAO.UnitID = Convert.ToInt32(this.drpUnit.SelectedValue);
                this.objItemDAO.SetItemID = Convert.ToInt32(this.drpSetItem.SelectedValue);
                this.objItemDAO.SetItemName = this.drpSetItem.SelectedItem.ToString();
                this.objItemDAO.Quantity = Convert.ToDecimal(this.txtQuantityTotal.Text);
                this.objItemDAO.Price = Convert.ToDecimal(this.txtPrice.Text);
                this.objItemDAO.ChallanID = Convert.ToInt32(this.drpChallan.SelectedValue);
                item.Add(this.objItemDAO);
                this.Session["SetItem_DETAIL_LIST"] = item;
            }
            catch (Exception exception)
            {
                Utility.InsertErrorTrack(exception.Message, "ItemSetSetup.aspx", "fillDetailProperties");
            }
        }

        private void fillMasterProperties()
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["SetItem_Master_LIST"] ?? new ArrayList();
                int num = Convert.ToInt16(item.Count + 1);
                this.objmaster.RowNo = num;
                DataTable allUnitByUnitName = this.objItem.getAllUnitByUnitName("SET");
                if (allUnitByUnitName.Rows.Count > 0)
                {
                    this.objmaster.UnitID = Convert.ToInt32(allUnitByUnitName.Rows[0]["unit_id"]);
                }
                this.objmaster.SetItemID = Convert.ToInt32(this.drpSetItem.SelectedValue);
                this.objmaster.SetItemName = this.drpSetItem.SelectedItem.ToString();
                this.objmaster.Quantity = new decimal(1);
                this.objmaster.Price = Convert.ToDecimal(this.txtTotalSalePrice.Text);
                item.Add(this.objmaster);
                this.Session["SetItem_Master_LIST"] = item;
            }
            catch (Exception exception)
            {
                Utility.InsertErrorTrack(exception.Message, "ItemSetSetup.aspx", "fillDetailProperties");
            }
        }

        private void GetTotalValue()
        {
            try
            {
                decimal num = new decimal(0);
                if (this.gvItem.Rows.Count > 0)
                {
                    for (int i = 0; i < this.gvItem.Rows.Count; i++)
                    {
                        num += Convert.ToDecimal(this.gvItem.Rows[i].Cells[5].Text.Trim());
                    }
                }
                this.txtTotalSalePrice.Text = num.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void GetUnitName()
        {
            DataTable allUnit = (new AddItemBLL()).getAllUnit();
            if (allUnit.Rows.Count > 0)
            {
                this.drpUnit.DataSource = allUnit;
                this.drpUnit.DataTextField = allUnit.Columns["unit_code"].ToString();
                this.drpUnit.DataValueField = allUnit.Columns["unit_id"].ToString();
                this.drpUnit.DataBind();
                this.drpitemUnit.DataSource = allUnit;
                this.drpitemUnit.DataTextField = allUnit.Columns["unit_code"].ToString();
                this.drpitemUnit.DataValueField = allUnit.Columns["unit_id"].ToString();
                this.drpitemUnit.DataBind();
                ListItem listItem = new ListItem("---SELECT---", "-99");
                this.drpUnit.Items.Insert(0, listItem);
                ListItem listItem1 = new ListItem("---SELECT---", "-99");
                this.drpitemUnit.Items.Insert(0, listItem1);
            }
        }

        protected void gvSetItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TableCell item = e.Row.Cells[0];
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        ((LinkButton)e.Row.Cells[0].Controls[0]).Attributes["onclick"] = "if(!confirm('Are you sure you want to delete?'))return   false;";
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void gvSetItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void gvSetItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LoadItems()
        {
            try
            {
                DataTable setTypeItem = this.objItem.GetSetTypeItem();
                this.drpItem.DataSource = setTypeItem;
                this.drpItem.DataTextField = setTypeItem.Columns["ITEM_NAME"].ToString();
                this.drpItem.DataValueField = setTypeItem.Columns["ITEM_ID"].ToString();
                this.drpItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "LoadItems");
            }
        }

        private void LoadSetItems()
        {
            try
            {
                DataTable setItem = this.objItem.GetSetItem();
                this.drpSetItem.DataSource = setItem;
                this.drpSetItem.DataTextField = setItem.Columns["ITEM_NAME"].ToString();
                this.drpSetItem.DataValueField = setItem.Columns["ITEM_ID"].ToString();
                this.drpSetItem.DataBind();
                ListItem listItem = new ListItem("-- SELECT --", "-99");
                this.drpSetItem.Items.Insert(0, listItem);
            }
            catch (Exception exception)
            {
                Utility.InsertErrorTrack(exception.Message, "SaleChallan_11.aspx", "LoadItems");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Session["SetItem_DETAIL_LIST"] = new ArrayList();
                this.Session["SetItem_Master_LIST"] = new ArrayList();
                this.LoadItems();
                this.LoadSetItems();
                this.GetUnitName();
            }
        }

        private void ShowDataInGridView()
        {
            try
            {
                int num = 0;
                num = Convert.ToInt32(this.drpSetItem.SelectedValue);
                DataTable itemSetItemID = this.objItem.GetItemSetItemID(num);
                if (itemSetItemID.Rows.Count > 0)
                {
                    this.gvSetItem.DataSource = itemSetItemID;
                    this.gvSetItem.DataBind();
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void txtChallanPrice_TextChanged(object sender, EventArgs e)
        {
            this.calculatePrice();
        }

        protected void txtChallanQuantity_TextChanged(object sender, EventArgs e)
        {
            this.calculatePrice();
        }

        protected void txtQuantityTotal_TextChanged(object sender, EventArgs e)
        {
            this.calculatePrice();
        }
    }
}