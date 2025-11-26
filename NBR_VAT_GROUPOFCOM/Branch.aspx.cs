using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM
{
    public partial class Branch : Page, IRequiresSessionState
    {
        private NBR_VAT_GROUPOFCOM.BLL.UserBLL uBll = new NBR_VAT_GROUPOFCOM.BLL.UserBLL();

        private NBR_VAT_GROUPOFCOM.BLL.AddUserBLL ubll = new NBR_VAT_GROUPOFCOM.BLL.AddUserBLL();

        private NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL objVatReturn = new NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL();

        private static string URL;

        private static string version;

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

        static Branch()
        {
            Branch.URL = WebConfigurationManager.AppSettings["apiUrl"];
            Branch.version = WebConfigurationManager.AppSettings["apiVersion"];
        }

        public Branch()
        {
        }

        protected void btnBusinessUnit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Session["BSS_UNT_TRUE"] = "TRU";
                this.Session["orgId"] = this.drpSchema.SelectedValue.Trim();
                this.Session.SessionID.ToString();
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                hostEntry.AddressList[0].ToString();
                if (this.Validations())
                {
                    DataTable businessInformation = this.uBll.GetBusinessInformation(Convert.ToInt32(this.Session["orgId"]));
                    if (this.uBll.getUserIDBool(this.Session["suserId"].ToString(), this.Session["encPassword"].ToString()) && businessInformation != null && businessInformation.Rows.Count > 0)
                    {
                        string empty = string.Empty;
                        this.Session["ORGANIZATION_ID"] = businessInformation.Rows[0]["organization_id"].ToString();
                        this.Session["ORGANIZATION_NAME"] = businessInformation.Rows[0]["Organization_name"].ToString();
                        this.Session["ORGANIZATION_BIN"] = businessInformation.Rows[0]["BIN_NO"].ToString();
                        this.Session["ORGANIZATION_ADDRESS"] = businessInformation.Rows[0]["address"].ToString();
                        this.Session["ORGBRANCHID"] = this.drpBusinessUnitBranch.SelectedValue.Trim();
                        int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
                        int num1 = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
                        int num2 = Convert.ToInt32(this.Session["ORGBRANCHID"]);
                        this.uBll.updateBusinessStatusActive(num, num1, num2);
                        base.Response.Redirect("KGCDashboard.aspx", false);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private string Decrypt(string password)
        {
            string str = "ABEDIN";
            byte[] numArray = Convert.FromBase64String(password);
            using (Aes bytes = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(str, new byte[] { 73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118 });
                bytes.Key = rfc2898DeriveByte.GetBytes(32);
                bytes.IV = rfc2898DeriveByte.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, bytes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(numArray, 0, (int)numArray.Length);
                        cryptoStream.Close();
                    }
                    password = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
            }
            return password;
        }

        protected void drpSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetBusinessUnitBranch();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private string Encrypt(string passEn)
        {
            string str = "ABEDIN";
            byte[] bytes = Encoding.Unicode.GetBytes(passEn);
            using (Aes ae = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(str, new byte[] { 73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118 });
                ae.Key = rfc2898DeriveByte.GetBytes(32);
                ae.IV = rfc2898DeriveByte.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, ae.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, (int)bytes.Length);
                        cryptoStream.Close();
                    }
                    passEn = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return passEn;
        }

        private void GetBusinessUnit()
        {
            try
            {
                int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
                this.drpSchema.Items.Clear();
                ChallanBLL challanBLL = new ChallanBLL();
                DataTable organizationAccess = this.uBll.GetOrganizationAccess(num);
                if (organizationAccess != null && organizationAccess.Rows.Count > 0)
                {
                    this.drpSchema.DataSource = organizationAccess;
                    this.drpSchema.DataTextField = organizationAccess.Columns["organization_name"].ToString();
                    this.drpSchema.DataValueField = organizationAccess.Columns["organization_id"].ToString();
                    this.drpSchema.DataBind();
                }
                ListItem listItem = new ListItem("-- Select --", "-99");
                this.drpSchema.Items.Insert(0, listItem);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "Branch.aspx", "GetBusinessUnit", fileLineNumber);
            }
        }

        private void GetBusinessUnitBranch()
        {
            try
            {
                int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
                int num1 = Convert.ToInt32(this.drpSchema.SelectedValue.Trim());
                this.drpBusinessUnitBranch.Items.Clear();
                DataTable organizationBranchAccess = this.uBll.GetOrganizationBranchAccess(num, num1);
                if (organizationBranchAccess != null && organizationBranchAccess.Rows.Count > 0)
                {
                    this.drpBusinessUnitBranch.DataSource = organizationBranchAccess;
                    this.drpBusinessUnitBranch.DataTextField = organizationBranchAccess.Columns["branch_unit_name"].ToString();
                    this.drpBusinessUnitBranch.DataValueField = organizationBranchAccess.Columns["org_branch_reg_id"].ToString();
                    this.drpBusinessUnitBranch.DataBind();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.GetBusinessUnit();
            }
        }

        private bool Validations()
        {
            int num = Convert.ToInt32(this.Session["EMPLOYEE_ID"].ToString());
            DataTable employeewiseBranchAccess = this.uBll.GetEmployeewiseBranchAccess(num);
            int num1 = Convert.ToInt32(this.drpSchema.SelectedValue);
            if (employeewiseBranchAccess.Rows.Count > 0)
            {
                for (int i = 0; i < employeewiseBranchAccess.Rows.Count; i++)
                {
                    if (employeewiseBranchAccess.Rows[i]["business_unit_status"].ToString() == "True" && Convert.ToInt32(employeewiseBranchAccess.Rows[i]["organization_id"]) != num1)
                    {
                        //  this.msgBox.AddMessage("Already Login in other BIN.", MsgBoxs.enmMessageType.Error);
                        return false;
                    }
                }
            }
            return true;
        }

    }
}