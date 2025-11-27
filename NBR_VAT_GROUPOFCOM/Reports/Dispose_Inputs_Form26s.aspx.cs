using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class Dispose_Inputs_Form26s : System.Web.UI.Page
    {
        private DisposalBLL dbBll = new DisposalBLL();

        public Dispose_Inputs_Form26s()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                Utility.fillAllItemPD(this.ddlItem);
                this.ddlItem.Items.Insert(0, new ListItem("----Select----", "-99"));
                this.orgName.Text = this.Session["ORGANIZATION_NAME"].ToString();
                this.orgAddress.Text = this.Session["ORGANIZATION_ADDRESS"].ToString();
                this.orgBIN.Text = this.Session["ORGANIZATION_BIN"].ToString();
                Convert.ToInt32(this.Session["CIRCLE_ID"]);
                this.fromDate.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.toDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["employee_name"].ToString();
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
                minValue = DateTime.ParseExact(this.fromDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dateTime = DateTime.ParseExact(this.toDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                long num = Convert.ToInt64(this.ddlItem.SelectedValue);
                dataTable = this.dbBll.GetDisposalDataForReport(minValue, dateTime, num);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.lblDutyOfficerName.Text = this.Session["EMPLOYEE_NAME"].ToString();
                    this.lblDutyOfficerDesignationName.Text = this.Session["DESIGNATION_NAME"].ToString();
                    this.lblItem.Text = dataTable.Rows[0]["hs_code"].ToString();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        decimal num1 = Convert.ToDecimal(dataTable.Rows[i]["prev_amount"]);
                        decimal num2 = Convert.ToDecimal(dataTable.Rows[i]["vat"]);
                        decimal num3 = Convert.ToDecimal(dataTable.Rows[i]["pre_amount"]);
                        empty = string.Concat(empty, "<tr>");
                        object obj = empty;
                        object[] objArray = new object[] { obj, "<td>", i + 1, "</td>" };
                        empty = string.Concat(objArray);
                        empty = string.Concat(empty, "<td>", dataTable.Rows[i]["item_name"].ToString(), "</td>");
                        empty = string.Concat(empty, "<td>", dataTable.Rows[i]["challan_no"].ToString(), "</td>");
                        object obj1 = empty;
                        object[] objArray1 = new object[] { obj1, "<td>", Convert.ToInt16(dataTable.Rows[i]["purchaseSl"]), "</td>" };
                        empty = string.Concat(objArray1);
                        object obj2 = empty;
                        object[] objArray2 = new object[] { obj2, "<td style='text-align:right; padding-right:5px'>", Utilities.formatFraction(Convert.ToDecimal(dataTable.Rows[i]["quantity"])), '(', dataTable.Rows[i]["unit_code"].ToString(), ')', "</td>" };
                        empty = string.Concat(objArray2);
                        empty = string.Concat(empty, "<td style='text-align:right; padding-right:5px'>", num1.ToString("N2"), "</td>");
                        empty = string.Concat(empty, "<td style='text-align:right; padding-right:5px'>", num2.ToString("N2"), "</td>");
                        empty = string.Concat(empty, "<td style='text-align:right; padding-right:5px'>", num3.ToString("N2"), "</td>");
                        empty = string.Concat(empty, "<td>", dataTable.Rows[i]["Remarks"].ToString(), "</td>");
                        empty = string.Concat(empty, "</tr>");
                    }
                    this.btnPrint.Visible = true;
                    this.lblReportHtml.Text = empty;
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

      


    }
}