using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class SupplDutyAdjApp_7__1s : Page, IRequiresSessionState
    {

        private string[] eng = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };

        private string[] bng = new string[] { "১", "২", "৩", "৪", "৫", "৬", "৭", "৮", "৯", "১০", "১১", "১২", "১৩", "১৪", "১৫", "১৬", "১৭", "১৮", "১৯", "২০", "২১", "২২", "২৩", "২৪", "২৫", "২৬", "২৭", "২৮", "২৯", "৩০", "৩১", "৩২", "৩৩", "৩৪", "৩৫", "৩৬", "৩৭", "৩৮", "৩৯", "৪০", "৪১", "৪২", "৪৩", "৪৪", "৪৫", "৪৬", "৪৭", "৪৮", "৪৯", "৫০" };

        private Collection<DropDownList> drpPropertyCollection = new Collection<DropDownList>();

        private Collection<Label> lblPropertyCollection = new Collection<Label>();

        private PurchaseDetailDAO objDetailDAO;

        private ItemBLL bll = new ItemBLL();

        private SaleBLL objBLL = new SaleBLL();

        private trnsPurchaseDetailBLL objpurchase = new trnsPurchaseDetailBLL();

        private saleExportDAO objsale = new saleExportDAO();

    
        public SupplDutyAdjApp_7__1s()
        {
        }

        private void AddDetailDataInGrid()
        {
            try
            {
                ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"];
                this.gvImportItem.DataSource = item;
                this.gvImportItem.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (this.MasterValidation())
            {
                adjustSDDAO _adjustSDDAO = new adjustSDDAO()
                {
                    Application_date = this.txtApplicationDate.Text,
                    Export_date = this.txtExportDate.Text,
                    refund_SD = Convert.ToDouble(this.lblrefundSDTK.Text)
                };
                short num = Convert.ToInt16(this.drpExportItemDescription.SelectedValue);
                DataTable exportItemInfoByItemId = this.objpurchase.getExportItemInfoByItemId(num);
                for (int i = 0; i < exportItemInfoByItemId.Rows.Count; i++)
                {
                    int num1 = Convert.ToInt32(exportItemInfoByItemId.Rows[i]["challan_id"]);
                    if (this.objBLL.InsertAdjustSD(_adjustSDDAO, num1))
                    {
                        this.msgBox.AddMessage("Infomation Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtFromdate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert From Date.", MsgBoxs.enmMessageType.Attention);
                this.txtApplicationDate.Focus();
            }
            if (this.txtTodate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert To Date.", MsgBoxs.enmMessageType.Attention);
                this.txtExportDate.Focus();
            }
            if (this.txtTodate.Text.Length != 0 && this.txtFromdate.Text.Length != 0)
            {
                CultureInfo invariantCulture = CultureInfo.InvariantCulture;
                DateTime dateTime = DateTime.ParseExact(this.txtFromdate.Text.ToString(), "dd/MM/yyyy", invariantCulture);
                string str = dateTime.ToString("dd/MM/yyyy");
                DateTime dateTime1 = DateTime.ParseExact(this.txtTodate.Text.ToString(), "dd/MM/yyyy", invariantCulture);
                string str1 = dateTime1.AddDays(1).ToString("dd/MM/yyyy");
                Util.fillImportItem(this.drpImportItemDescription, str, str1);
            }
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            this.showPurchaseReport();
            this.ShowExportReport();
        }

        protected void drpExportItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpExportItemDescription.SelectedIndex > 0)
            {
                this.part_b.Visible = true;
                ArrayList arrayLists = new ArrayList();
                PurchaseEdit purchaseEdit = new PurchaseEdit();
                short num = Convert.ToInt16(this.drpExportItemDescription.SelectedValue);
                saleExportDAO _saleExportDAO = new saleExportDAO();
                DataTable dataTable = new DataTable();
                DataTable exportItemInfoByItemId = new DataTable();
                short num1 = Convert.ToInt16(this.drpImportItemDescription.SelectedValue);
                dataTable = this.objpurchase.getItemInfoByItemId(num1);
                DataTable dataTable1 = this.objpurchase.getusedQuantityperUnit(num1);
                purchaseEdit.UsedQuantity = Convert.ToDouble(dataTable1.Rows[0]["quantity_total"]);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ArrayList arrayLists1 = new ArrayList();
                    purchaseEdit.Quantity = Convert.ToDouble(dataTable.Rows[i]["quantity"]);
                    purchaseEdit.SSD = Convert.ToDouble(dataTable.Rows[i]["sd"]);
                    arrayLists1.Add(purchaseEdit);
                }
                exportItemInfoByItemId = this.objpurchase.getExportItemInfoByItemId(num);
                exportItemInfoByItemId.Columns.Add("SD");
                exportItemInfoByItemId.Columns.Add("total");
                string str = "";
                string str1 = "";
                double usedQuantity = 0;
                double num2 = 0;
                for (int j = 0; j < exportItemInfoByItemId.Rows.Count; j++)
                {
                    this.objsale.ChallanNo = exportItemInfoByItemId.Rows[j]["challan_no"].ToString();
                    this.objsale.HSCode = exportItemInfoByItemId.Rows[j]["hs_code"].ToString();
                    this.objsale.Item_Name = exportItemInfoByItemId.Rows[j]["item_name"].ToString();
                    this.objsale.Quantity = Convert.ToDouble(exportItemInfoByItemId.Rows[j]["quantity"]);
                    usedQuantity = purchaseEdit.UsedQuantity * this.objsale.Quantity * purchaseEdit.SSD / purchaseEdit.Quantity;
                    str = string.Format("{0:0.0#}", usedQuantity);
                    num2 = usedQuantity + Convert.ToDouble(exportItemInfoByItemId.Rows[j]["total_price"].ToString());
                    this.objsale.Total = num2;
                    str1 = string.Format("{0:0.0#}", num2);
                    this.objsale.SD = usedQuantity;
                    arrayLists.Add(this.objsale);
                }
                exportItemInfoByItemId.Rows[0]["SD"] = str;
                exportItemInfoByItemId.Rows[0]["total"] = str1;
                exportItemInfoByItemId.Rows[0]["challan_no"] = this.objsale.ChallanNo;
                this.Session["SALE_DETAIL_LIST"] = arrayLists;
                this.gvExportItem.DataSource = exportItemInfoByItemId;
                this.gvExportItem.DataBind();
            }
        }

        protected void drpImportItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpImportItemDescription.SelectedIndex > 0)
            {
                this.part_a.Visible = true;
                ArrayList arrayLists = new ArrayList();
                short num = Convert.ToInt16(this.drpImportItemDescription.SelectedValue);
                PurchaseDetailDAO purchaseDetailDAO = new PurchaseDetailDAO();
                DataTable dataTable = new DataTable();
                dataTable = this.objpurchase.getItemInfoByItemId(num);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    PurchaseEdit purchaseEdit = new PurchaseEdit()
                    {
                        ChallanNO = dataTable.Rows[i]["challan_no"].ToString(),
                        HSCode = dataTable.Rows[i]["hs_code"].ToString(),
                        ItemName = dataTable.Rows[i]["item_name"].ToString(),
                        Quantity = Convert.ToDouble(dataTable.Rows[i]["quantity"])
                    };
                    arrayLists.Add(purchaseEdit);
                }
                this.Session["PURCHASE_DETAIL_LIST"] = arrayLists;
                this.gvImportItem.DataSource = dataTable;
                this.gvImportItem.DataBind();
                Util.fillExportItem(this.drpExportItemDescription, num);
            }
        }

        protected void File_download(object sender, EventArgs e)
        {
            string str = base.Server.MapPath(this.FileUpload1.FileName);
            FileInfo fileInfo = new FileInfo(str);
            if (fileInfo.Exists)
            {
                base.Response.Clear();
                base.Response.ClearHeaders();
                base.Response.ClearContent();
                base.Response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
                base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                base.Response.ContentType = "text/plain";
                base.Response.Flush();
                base.Response.TransmitFile(fileInfo.FullName);
                base.Response.End();
            }
        }

        protected void gvExportItem_PreRender(object sender, EventArgs e)
        {
        }

        protected void gvExportItem_RowDataBound(object sender, EventArgs e)
        {
        }

        protected void gvExportItem_RowDeleting(object sender, EventArgs e)
        {
        }

        protected void gvExportItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void gvImportItem_PreRender(object sender, EventArgs e)
        {
        }

        protected void gvImportItem_RowDataBound(object sender, EventArgs e)
        {
        }

        protected void gvImportItem_RowDeleting(object sender, EventArgs e)
        {
        }

        protected void gvImportItem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private bool MasterValidation()
        {
            if (this.txtApplicationDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Application Date.", MsgBoxs.enmMessageType.Attention);
                this.txtApplicationDate.Focus();
                return false;
            }
            if (this.txtExportDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Export Date.", MsgBoxs.enmMessageType.Attention);
                this.txtExportDate.Focus();
                return false;
            }
            if (this.txtAdjustableSDTk.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Adjustable SD.", MsgBoxs.enmMessageType.Attention);
                this.txtAdjustableSDTk.Focus();
                return false;
            }
            if (this.lblrefundSDTK.Text.Length != 0)
            {
                return true;
            }
            this.msgBox.AddMessage("Please Insert SD Refund.", MsgBoxs.enmMessageType.Attention);
            this.lblrefundSDTK.Focus();
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            try
            {
                if (!base.IsPostBack)
                {
                    this.part_b.Visible = false;
                    this.part_a.Visible = false;
                    this.lt_companyName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                    this.It_companyAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                    this.lblOrgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void ShowExportReport()
        {
            ArrayList item = (ArrayList)this.Session["SALE_DETAIL_LIST"];
            string str = "";
            for (int i = 0; i < item.Count; i++)
            {
                i.ToString();
                this.objsale = (saleExportDAO)item[i];
                str = string.Concat(str, "<tr>");
                str = string.Concat(str, "<td style='text-align:left'>", this.objsale.ChallanNo, "</td>");
                str = string.Concat(str, "<td style='text-align:left'>", this.objsale.HSCode, "</td>");
                str = string.Concat(str, "<td style='text-align:left'>", this.objsale.Item_Name, "</td>");
                object obj = str;
                object[] quantity = new object[] { obj, "<td style='text-align:left'>", this.objsale.Quantity, "</td>" };
                str = string.Concat(quantity);
                str = string.Concat(str, "</tr>");
                this.lblExportProductDetails.Text = str;
            }
        }

        private void showPurchaseReport()
        {
            PurchaseEdit purchaseEdit = new PurchaseEdit();
            this.lblpersonName.Text = this.Session["ORGANIZATION_NAME"].ToString();
            this.lblbin.Text = this.Session["ORGANIZATION_BIN"].ToString();
            this.lblAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
            this.lblExportsd.Text = this.lblrefundSDTK.Text;
            this.lblApplictnDate.Text = this.txtApplicationDate.Text;
            this.lblExpoortDate.Text = this.txtExportDate.Text;
            this.lblSd.Text = this.txtAdjustableSDTk.Text;
            ArrayList item = (ArrayList)this.Session["PURCHASE_DETAIL_LIST"];
            string str = "";
            for (int i = 0; i < item.Count; i++)
            {
                i.ToString();
                purchaseEdit = (PurchaseEdit)item[i];
                str = string.Concat(str, "<tr>");
                str = string.Concat(str, "<td style='text-align:left'>", purchaseEdit.ChallanNO, "</td>");
                str = string.Concat(str, "<td style='text-align:left'>", purchaseEdit.HSCode, "</td>");
                str = string.Concat(str, "<td style='text-align:left'>", purchaseEdit.ItemName, "</td>");
                object obj = str;
                object[] quantity = new object[] { obj, "<td style='text-align:left'>", purchaseEdit.Quantity, "</td>" };
                str = string.Concat(quantity);
                str = string.Concat(str, "</tr>");
                this.lblImportProductDetails.Text = str;
            }
        }

        private bool Validation()
        {
            return true;
        }

        private enum enmBtnText
        {
            Save,
            Update,
            Cancel,
            Clear
        }
    }
}