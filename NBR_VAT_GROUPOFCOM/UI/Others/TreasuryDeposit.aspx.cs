using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Others
{
    public partial class TreasuryDeposit : Page, IRequiresSessionState
    {
     

        private trnsTreasuryChallanBLL objtrnsTreasuryChallanBLL = new trnsTreasuryChallanBLL();

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

        public TreasuryDeposit()
        {
        }

        protected void Advanced_Click(object sender, EventArgs e)
        {
            this.showAllDataInGrid();
        }

        protected void basic_Click(object sender, EventArgs e)
        {
            this.showDataInGrid();
        }

        protected void gvForTRchallan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddTRchallan")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                GridViewRow item = this.gvForTRchallan.Rows[num];
                TextBox textBox = (TextBox)this.gvForTRchallan.Rows[num].Cells[1].FindControl("txtTRchallanNO");
                FileUpload fileUpload = (FileUpload)this.gvForTRchallan.Rows[num].Cells[7].FindControl("FileUploadControl");
                Image image = (Image)this.gvForTRchallan.Rows[num].Cells[7].FindControl("Image1");
                string str = textBox.Text.ToString();
                this.gvForTRchallan.Rows[num].Cells[2].Text.ToString();
                int num1 = Convert.ToInt32(this.gvForTRchallan.Rows[num].Cells[6].Text.ToString());
                string str1 = "";
                if (fileUpload.HasFile)
                {
                    Path.GetExtension(fileUpload.FileName).ToLower();
                    string str2 = fileUpload.FileName.ToString();
                    string str3 = base.Server.MapPath(string.Concat("~/Uploads/", str2));
                    fileUpload.SaveAs(str3);
                    str1 = base.Server.MapPath(string.Concat("~/Uploads/", str2));
                }
                if (this.objtrnsTreasuryChallanBLL.updateTRchallanByID(str, num1, str1))
                {
                    this.showDataInGrid();
                    this.msgBox.AddMessage("TR Challan Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    return;
                }
                this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.showDataInGrid();
            }
        }

        private void showAllDataInGrid()
        {
            DataTable dataTable = this.objtrnsTreasuryChallanBLL.showAllChallan();
            if (dataTable.Rows != null)
            {
                this.gvForTRchallan.DataSource = dataTable;
                this.gvForTRchallan.DataBind();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Image image = (Image)this.gvForTRchallan.Rows[i].Cells[7].FindControl("Image1");
                    Button button = (Button)this.gvForTRchallan.Rows[i].Cells[7].FindControl("btnPrev");
                    if (dataTable.Rows[i]["tr_challan_image"].ToString() != "")
                    {
                        image.ImageUrl = string.Concat("../../Uploads/", Path.GetFileName(dataTable.Rows[i]["tr_challan_image"].ToString()));
                    }
                    else
                    {
                        image.Visible = false;
                    }
                }
            }
        }

        private void showDataInGrid()
        {
            DataTable dataTable = this.objtrnsTreasuryChallanBLL.showChallan();
            if (dataTable.Rows != null)
            {
                this.gvForTRchallan.DataSource = dataTable;
                this.gvForTRchallan.DataBind();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Image image = (Image)this.gvForTRchallan.Rows[i].Cells[7].FindControl("Image1");
                    Button button = (Button)this.gvForTRchallan.Rows[i].Cells[7].FindControl("btnPrev");
                    image.Visible = false;
                }
            }
        }
    }
}