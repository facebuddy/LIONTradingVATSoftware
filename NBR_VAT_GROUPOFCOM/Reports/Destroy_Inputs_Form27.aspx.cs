using ASP;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class Destroy_Inputs_Form27 : Page, IRequiresSessionState
    {
        private DisposalBLL dbBll = new DisposalBLL();

        private trnsSaleMasterBLL objtrnsSaleMasterBLL = new trnsSaleMasterBLL();

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

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            DateTime minValue = DateTime.MinValue;
            DateTime dateTime = DateTime.MinValue;
            DataTable dataTable = new DataTable();
            string empty = string.Empty;
            try
            {
                long num = Convert.ToInt64(this.ddlItem.SelectedValue);
                minValue = DateTime.ParseExact(this.fromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTime = DateTime.ParseExact(this.toDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dataTable = this.dbBll.GetDamagedDataForReport(minValue, dateTime, num);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                    this.lblItem.Text = dataTable.Rows[0]["hs_code"].ToString();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        decimal num1 = Convert.ToDecimal(dataTable.Rows[i]["prev_amount"]);
                        Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                        decimal num2 = Convert.ToDecimal(dataTable.Rows[i]["pre_amount"]);
                        empty = string.Concat(empty, "<tr>");
                        object obj = empty;
                        object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                        empty = string.Concat(objArray);
                        empty = string.Concat(empty, "<td>", dataTable.Rows[i]["item_name"].ToString(), "</td>");
                        object obj1 = empty;
                        object[] objArray1 = new object[] { obj1, "<td style='text-align:right; padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["quantity"])), '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                        empty = string.Concat(objArray1);
                        empty = string.Concat(empty, "<td style='text-align:right; padding-right:5px'>", num1.ToString("0.00"), "</td>");
                        empty = string.Concat(empty, "<td style='text-align:right; padding-right:5px'>", num2.ToString("0.00"), "</td>");
                        empty = string.Concat(empty, "<td>", dataTable.Rows[i]["Remarks"].ToString(), "</td>");
                        empty = string.Concat(empty, "</tr>");
                    }
                    this.btnPrint.Visible = true;
                    this.lblReportHtml.Text = empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnShowApplication_OnClick(object sender, EventArgs e)
        {
            if (this.droChallanNo.SelectedValue == "-1")
            {
                this.msgBox.AddMessage(" Select Challan No First.", 2);
                return;
            }
            this.Session["Dispose_ChallanNo"] = this.droChallanNo.SelectedItem.ToString();
            base.Response.Redirect("~/Reports/Musok4_4_and_4_5_Application.aspx");
        }

        private void LoadDisposeChallanNo()
        {
            DataTable disposeChallanNo45 = this.objtrnsSaleMasterBLL.GetDisposeChallanNo4_5();
            if (disposeChallanNo45 != null && disposeChallanNo45.Rows.Count > 0)
            {
                this.droChallanNo.DataSource = disposeChallanNo45;
                this.droChallanNo.DataTextField = disposeChallanNo45.Columns["challan_no"].ToString();
                this.droChallanNo.DataValueField = disposeChallanNo45.Columns["challan_id"].ToString();
                this.droChallanNo.DataBind();
            }
            this.droChallanNo.Items.Insert(0, new ListItem("-- SELECT --", "-1"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Utility.fillAllItemPD(this.ddlItem);
                ListItem listItem = new ListItem("--- SELECT ---", "-99");
                this.ddlItem.Items.Insert(0, listItem);
                this.orgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.orgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.orgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                Convert.ToInt32(this.Session["CIRCLE_ID"]);
                this.fromDate.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.toDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["employee_name"].ToString();
                this.LoadDisposeChallanNo();
            }
        }
    }
}
