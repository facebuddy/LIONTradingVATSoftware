using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Item
{
    public partial class OtherPrincipalAndValueAdditionSetups : Page, IRequiresSessionState
    {
        private UnitBLL objUnitBLL = new UnitBLL();

        private static PriceDeclaretionBLL objPDBll;


        static OtherPrincipalAndValueAdditionSetups()
        {
            OtherPrincipalAndValueAdditionSetups.objPDBll = new PriceDeclaretionBLL();
        }

        public OtherPrincipalAndValueAdditionSetups()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.msgBox.Visible = true;
            bool flag = false;
            int num = 0;
            foreach (GridViewRow row in this.slValueAddition.Rows)
            {
                int num1 = Convert.ToInt32((row.FindControl("lblCode_id_d") as Label).Text);
                int num2 = Convert.ToInt32(8);
                string text = (row.FindControl("lblId") as Label).Text;
                string str = (row.FindControl("lblvStatus") as Label).Text;
                if (this.objUnitBLL.findValueAdditionItem(num1, num2) != text)
                {
                    flag = this.objUnitBLL.InsertValueAddition(text, num1, num2, str);
                    num++;
                }
                else
                {
                    this.msgBox.AddMessage("Information: Failed to save.", MsgBoxs.enmMessageType.Error);
                    break;
                }
            }
            if (!flag)
            {
                this.msgBox.AddMessage("Information: Failed to save.", MsgBoxs.enmMessageType.Error);
            }
            else
            {
                this.msgBox.AddMessage(string.Concat("Information: ", num, " element Successfully Saved."), MsgBoxs.enmMessageType.Success);
            }
            this.showValueAdditionDataInGridView();
            this.showSelectedValueAdditionDataOnLoad();
            this.ButtonSave.Visible = false;
            this.btnSave.Visible = false;
        }

        protected void btnSave_Click_NonItem(object sender, EventArgs e)
        {
            bool flag = false;
            int num = 0;
            foreach (GridViewRow row in this.slValueAdditionNonItem.Rows)
            {
                int num1 = Convert.ToInt32((row.FindControl("lblCode_id_d1") as Label).Text);
                int num2 = Convert.ToInt32(14);
                string text = (row.FindControl("lblId1") as Label).Text;
                string str = (row.FindControl("lblvStatus1") as Label).Text;
                flag = this.objUnitBLL.InsertValueAddition(text, num1, num2, str);
                num++;
            }
            if (!flag)
            {
                this.msgBox.AddMessage("Information: Failed to save.", MsgBoxs.enmMessageType.Error);
            }
            else
            {
                this.msgBox.AddMessage(string.Concat("Information: ", num, " element Successfully Saved."), MsgBoxs.enmMessageType.Success);
            }
            this.showValueAdditionDataInGridViewNonItem();
            this.showSelectedValueAdditionDataOnLoadNonItem();
            this.ButtonSave.Visible = false;
            this.btnSave.Visible = false;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            List<OtherPrincipalAndValueAdditionDAO> otherPrincipalAndValueAdditionDAOs = new List<OtherPrincipalAndValueAdditionDAO>();
            bool flag = false;
            foreach (GridViewRow row in this.gvValueAddition.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");
                if (!(checkBox != null & checkBox.Checked))
                {
                    continue;
                }
                string text = row.Cells[1].Text;
                int num = Convert.ToInt32((row.FindControl("lblID2") as Label).Text);
                string str = "V";
                Convert.ToInt32(8);
                OtherPrincipalAndValueAdditionDAO otherPrincipalAndValueAdditionDAO = new OtherPrincipalAndValueAdditionDAO()
                {
                    code_name = text,
                    code_id_d = num,
                    vStatus = str
                };
                otherPrincipalAndValueAdditionDAOs.Add(otherPrincipalAndValueAdditionDAO);
                flag = true;
            }
            if (otherPrincipalAndValueAdditionDAOs.Count > 0)
            {
                this.slValueAddition.DataSource = otherPrincipalAndValueAdditionDAOs;
                this.slValueAddition.DataBind();
            }
            else
            {
                this.msgBox.AddMessage("Information: Sorry! No Item Selected", MsgBoxs.enmMessageType.Error);
            }
            if (flag)
            {
                this.ButtonSave.Visible = true;
                this.btnSave.Visible = true;
            }
        }

        protected void btnSelect_Click_NonItem(object sender, EventArgs e)
        {
            List<OtherPrincipalAndValueAdditionDAO> otherPrincipalAndValueAdditionDAOs = new List<OtherPrincipalAndValueAdditionDAO>();
            bool flag = false;
            foreach (GridViewRow row in this.gvValueAdditionNonItem.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox");
                if (!(checkBox != null & checkBox.Checked))
                {
                    continue;
                }
                string text = row.Cells[1].Text;
                int num = Convert.ToInt32((row.FindControl("lblIDN1") as Label).Text);
                string str = "V";
                Convert.ToInt32(8);
                OtherPrincipalAndValueAdditionDAO otherPrincipalAndValueAdditionDAO = new OtherPrincipalAndValueAdditionDAO()
                {
                    code_name = text,
                    code_id_d = num,
                    vStatus = str
                };
                otherPrincipalAndValueAdditionDAOs.Add(otherPrincipalAndValueAdditionDAO);
                flag = true;
            }
            if (otherPrincipalAndValueAdditionDAOs.Count > 0)
            {
                this.slValueAdditionNonItem.DataSource = otherPrincipalAndValueAdditionDAOs;
                this.slValueAdditionNonItem.DataBind();
            }
            else
            {
                this.msgBox.AddMessage("Information: Sorry! No Item Selected", MsgBoxs.enmMessageType.Error);
            }
            if (flag)
            {
                this.ButtonSave.Visible = true;
                this.btnSave.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.showValueAdditionDataInGridViewNonItem();
                this.showSelectedValueAdditionDataOnLoadNonItem();
                this.showValueAdditionDataInGridView();
                this.showSelectedValueAdditionDataOnLoad();
                this.ButtonSave.Visible = false;
                this.btnSave.Visible = false;
            }
        }

        public void showSelectedValueAdditionDataOnLoad()
        {
            DataSet allValueAdditionAreaForLoad = OtherPrincipalAndValueAdditionSetups.objPDBll.getAllValueAdditionAreaForLoad();
            this.slValueAddition.DataSource = allValueAdditionAreaForLoad;
            this.slValueAddition.DataBind();
        }

        public void showSelectedValueAdditionDataOnLoadNonItem()
        {
            DataSet allValueAdditionNotItemAreaForLoad = OtherPrincipalAndValueAdditionSetups.objPDBll.getAllValueAdditionNotItemAreaForLoad();
            this.slValueAdditionNonItem.DataSource = allValueAdditionNotItemAreaForLoad;
            this.slValueAdditionNonItem.DataBind();
        }

        public void showValueAdditionDataInGridView()
        {
            DataSet allValueAdditionAreaForSetup = OtherPrincipalAndValueAdditionSetups.objPDBll.getAllValueAdditionAreaForSetup();
            this.gvValueAddition.DataSource = allValueAdditionAreaForSetup;
            this.gvValueAddition.DataBind();
            foreach (GridViewRow row in this.gvValueAddition.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");
                string text = row.Cells[1].Text;
                int num = Convert.ToInt32((row.FindControl("lblID2") as Label).Text);
                int num1 = Convert.ToInt32(8);
                if (this.objUnitBLL.findValueAdditionItem(num, num1) != text)
                {
                    continue;
                }
                checkBox.Enabled = false;
            }
        }

        public void showValueAdditionDataInGridViewNonItem()
        {
            DataSet allValueAdditionNotItemAreaForSetUp = OtherPrincipalAndValueAdditionSetups.objPDBll.getAllValueAdditionNotItemAreaForSetUp();
            this.gvValueAdditionNonItem.DataSource = allValueAdditionNotItemAreaForSetUp;
            this.gvValueAdditionNonItem.DataBind();
            foreach (GridViewRow row in this.gvValueAdditionNonItem.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox");
                string text = row.Cells[1].Text;
                int num = Convert.ToInt32((row.FindControl("lblIDN1") as Label).Text);
                int num1 = Convert.ToInt32(14);
                if (this.objUnitBLL.findValueAdditionItem(num, num1) != text)
                {
                    continue;
                }
                checkBox.Enabled = false;
            }
        }

        protected void slValueAddition_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32((this.slValueAddition.SelectedRow.FindControl("lblCode_id_d") as Label).Text);
            int num1 = Convert.ToInt32(8);
            string text = (this.slValueAddition.SelectedRow.FindControl("lblId") as Label).Text;
            string str = (this.slValueAddition.SelectedRow.FindControl("lblvStatus") as Label).Text;
            str = (str == "H" ? "V" : "H");
            string str1 = (str == "H" ? "View" : "Hide");
            if (this.objUnitBLL.UpdateValueAdditionStatus(text, num, num1, str))
            {
                (this.slValueAddition.SelectedRow.FindControl("lblvStatus") as Label).Text = str;
                (this.slValueAddition.SelectedRow.FindControl("btnStatus") as Button).Text = str1;
            }
        }

        protected void slValueAddition_SelectedIndexChanged_NonItem(object sender, EventArgs e)
        {
            int num = Convert.ToInt32((this.slValueAdditionNonItem.SelectedRow.FindControl("lblCode_id_d1") as Label).Text);
            int num1 = Convert.ToInt32(14);
            string text = (this.slValueAdditionNonItem.SelectedRow.FindControl("lblId1") as Label).Text;
            string str = (this.slValueAdditionNonItem.SelectedRow.FindControl("lblvStatus1") as Label).Text;
            str = (str == "H" ? "V" : "H");
            string str1 = (str == "H" ? "View" : "Hide");
            if (this.objUnitBLL.UpdateValueAdditionStatus(text, num, num1, str))
            {
                (this.slValueAdditionNonItem.SelectedRow.FindControl("lblvStatus1") as Label).Text = str;
                (this.slValueAdditionNonItem.SelectedRow.FindControl("btnStatus1") as Button).Text = str1;
            }
        }
    }
}