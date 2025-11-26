using ASP;
using NBR_VAT_GROUPOFCOM.BLL;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Profile;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM
{
    public partial class Logins : Page, IRequiresSessionState
    {
        private UserBLL uBll = new UserBLL();

        private AddUserBLL ubll = new AddUserBLL();

        private VATReturnBLL objVatReturn = new VATReturnBLL();

        private static string URL;

        private static string version;

        protected TextBox txtUserId;

        protected TextBox txtPassword;

        protected Button btnLogin;

        protected Label lblErrorMsg;

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

        static Logins()
        {
            Logins.URL = WebConfigurationManager.AppSettings["apiUrl"];
            Logins.version = WebConfigurationManager.AppSettings["apiVersion"];
        }

        public Logins()
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string item;
            this.Session.SessionID.ToString();
            string hostName = Dns.GetHostName();
            IPAddress[] addressList = Dns.GetHostEntry(hostName).AddressList;
            string str = hostName;
            string str1 = addressList[0].ToString();
            if (this.Validation())
            {
                string str2 = MQMM.ParseText(this.txtUserId.Text.ToUpper().Trim());
                string str3 = MQMM.ParseText(this.txtPassword.Text.Trim());
                this.Session["suserId"] = str2;
                this.Session["sPassword"] = str3;
                DataTable passwordbyUserId = this.uBll.getPasswordbyUserId(str2);
                string str4 = "";
                if (passwordbyUserId.Rows.Count > 0)
                {
                    str4 = passwordbyUserId.Rows[0]["login_password"].ToString();
                }
                string str5 = "";
                str5 = str3;
                if (Crypto.VerifyHashedPassword(str4, str5))
                {
                    this.Session["encPassword"] = str4;
                    DataTable userID = this.uBll.getUserID(str2, str4);
                    if (!this.uBll.getUserIDBool(str2, str4))
                    {
                        UserAttemptDAO userAttemptDAO = new UserAttemptDAO()
                        {
                            user_password = Utility.ParseText(this.txtPassword.Text),
                            date_attempt = DateTime.Now,
                            ip_address = str1,
                            pc_name = str,
                            reaseon_for_attempt_failure = "Server Not Found"
                        };
                        this.ubll.InsertUserLogAttempt(userAttemptDAO);
                        this.lblErrorMsg.Text = "Server Not Found.";
                        return;
                    }
                    if (userID == null || userID.Rows.Count <= 0)
                    {
                        UserAttemptDAO userAttemptDAO1 = new UserAttemptDAO()
                        {
                            user_password = Utility.ParseText(this.txtPassword.Text),
                            date_attempt = DateTime.Now,
                            ip_address = str1,
                            pc_name = str,
                            reaseon_for_attempt_failure = "incorrect password"
                        };
                        this.ubll.InsertUserLogAttempt(userAttemptDAO1);
                        this.lblErrorMsg.Text = "Password is incorrect.";
                        return;
                    }
                    DataTable userIDActive = this.uBll.getUserIDActive(str2, str4);
                    //if (!this.checkUserLimit())
                    //{
                    //    Convert.ToInt32(base.Application["TotalOnlineUsers"].ToString());
                    //    this.lblErrorMsg.Text = "User Limit Exceed ";
                    //    return;
                    //}
                    //if (!this.checkActivationStatus())
                    //{
                    //    this.lblErrorMsg.Text = "Your License Has been Expired.";
                    //    return;
                    //}
                    this.Session["EMPLOYEE_ID"] = userID.Rows[0]["employee_id"].ToString();
                    this.Session["EMPLOYEE_NAME"] = userID.Rows[0]["employee_name"].ToString();
                    this.Session["EMPLOYEE_NID"] = userID.Rows[0]["employee_nid"].ToString();
                    this.Session["IS_SYSTEM_USER"] = userID.Rows[0]["is_system_user"].ToString();
                    this.Session["LOGIN_ID"] = userID.Rows[0]["login_id"].ToString();
                    this.Session["LOGIN_PASSWORD"] = userID.Rows[0]["login_password"].ToString();
                    this.Session["MASTER_ORGANIZATION_ID"] = userID.Rows[0]["master_organization_id"].ToString();
                    this.Session["ORGANIZATION_ID"] = userID.Rows[0]["organization_id"].ToString();
                    this.Session["ORGANIZATION_NAME"] = userID.Rows[0]["Organization_name"].ToString();
                    this.Session["ORGANIZATION_BIN"] = userID.Rows[0]["BIN_NO"].ToString();
                    this.Session["ORGANIZATION_ADDRESS"] = userID.Rows[0]["address"].ToString();
                    this.Session["DEPARTMENT_ID"] = userID.Rows[0]["department_id"].ToString();
                    this.Session["DESIGNATION_ID"] = userID.Rows[0]["designation_id"].ToString();
                    this.Session["USER_LEVEL"] = userID.Rows[0]["user_level"].ToString();
                    this.Session["EMPLOYEE_STATUS"] = userID.Rows[0]["emplyee_status"].ToString();
                    this.Session["DATE_JOIN"] = userID.Rows[0]["date_join"].ToString();
                    this.Session["DATE_RETIRMENT"] = userID.Rows[0]["date_retirement"].ToString();
                    this.Session["MOBILE_NO"] = userID.Rows[0]["mobile_no"].ToString();
                    this.Session["EMAIL"] = userID.Rows[0]["email"].ToString();
                    this.Session["ORGBRANCHID"] = userID.Rows[0]["org_branch_reg_id"].ToString();
                    this.Session["VAT_DEDUCT"] = userID.Rows[0]["is_vat_deduct"].ToString();
                    this.Session["CIRCLE_ID"] = userID.Rows[0]["circle_id"].ToString();
                    this.Session["VAT_LAST_AMOUNT"] = null;
                    this.Session["SD_LAST_AMOUNT"] = null;
                    this.Session["DESIGNATION_NAME"] = (this.Session["DESIGNATION_ID"].ToString().Length > 0 ? this.objVatReturn.GetDesignation(Convert.ToInt32(this.Session["DESIGNATION_ID"])) : "");
                    if (userIDActive.Rows.Count <= 0)
                    {
                        UserAttemptDAO userAttemptDAO2 = new UserAttemptDAO()
                        {
                            user_password = Utility.ParseText(this.txtPassword.Text),
                            date_attempt = DateTime.Now,
                            ip_address = str1,
                            pc_name = str,
                            reaseon_for_attempt_failure = "inactive user"
                        };
                        this.ubll.InsertUserLogAttempt(userAttemptDAO2);
                        this.lblErrorMsg.Text = "User is InActive..";
                        return;
                    }
                    Guid.NewGuid().ToString();
                    this.Session["empId"] = userIDActive.Rows[0]["employee_id"].ToString();
                    string empty = string.Empty;
                    if (userIDActive.Rows[0]["user_status"].ToString() == "N")
                    {
                        base.Response.Redirect("CnhgPss.aspx", false);
                        return;
                    }
                    string id = userID.Rows[0]["employee_id"].ToString();

                    this.Session["EMPLOYEE_ID"] = userID.Rows[0]["employee_id"].ToString();
                    this.Session["EMPLOYEE_NAME"] = userID.Rows[0]["employee_name"].ToString();
                    this.Session["IS_SYSTEM_USER"] = userID.Rows[0]["is_system_user"].ToString();
                    this.Session["LOGIN_ID"] = userID.Rows[0]["login_id"].ToString();
                    this.Session["LOGIN_PASSWORD"] = userID.Rows[0]["login_password"].ToString();
                    this.Session["ORGANIZATION_ID"] = userID.Rows[0]["organization_id"].ToString();
                    this.Session["ORGANIZATION_NAME"] = userID.Rows[0]["Organization_name"].ToString();
                    this.Session["ORGANIZATION_BIN"] = userID.Rows[0]["BIN_NO"].ToString();
                    this.Session["ORGANIZATION_ADDRESS"] = userID.Rows[0]["address"].ToString();
                    this.Session["DEPARTMENT_ID"] = userID.Rows[0]["department_id"].ToString();
                    this.Session["DESIGNATION_ID"] = userID.Rows[0]["designation_id"].ToString();
                    this.Session["USER_LEVEL"] = userID.Rows[0]["user_level"].ToString();
                    this.Session["EMPLOYEE_STATUS"] = userID.Rows[0]["emplyee_status"].ToString();
                    this.Session["DATE_JOIN"] = userID.Rows[0]["date_join"].ToString();
                    this.Session["DATE_RETIRMENT"] = userID.Rows[0]["date_retirement"].ToString();
                    this.Session["MOBILE_NO"] = userID.Rows[0]["mobile_no"].ToString();
                    this.Session["EMAIL"] = userID.Rows[0]["email"].ToString();
                    this.Session["ORGBRANCHID"] = userID.Rows[0]["org_branch_reg_id"].ToString();
                    this.Session["VAT_DEDUCT"] = userID.Rows[0]["is_vat_deduct"].ToString();
                    this.Session["VAT_LAST_AMOUNT"] = null;
                    this.Session["SD_LAST_AMOUNT"] = null;
                    this.Session["DESIGNATION_NAME"] = (this.Session["DESIGNATION_ID"].ToString().Length > 0 ? this.objVatReturn.GetDesignation(Convert.ToInt32(this.Session["DESIGNATION_ID"])) : "");
                    UserLogDAO userLogDAO = new UserLogDAO()
                    {
                        user_id = Convert.ToInt32(userIDActive.Rows[0]["employee_id"]),
                        ip_address = str1,
                        login_logout_time = DateTime.Now,
                        status = "Logins",
                        pc_name = str
                    };
                    this.ubll.InsertUserLog(userLogDAO);
                    string[] masterOrgInfo = Utilities.GetMasterOrgInfo();
                    if (this.Session["LOGIN_ID"].ToString() != "root")
                    {
                        item = (masterOrgInfo[1] != "S" ? "Branch.aspx" : "Admin_Dashboard.aspx");
                    }
                    else
                    {
                        item = "OrgSetup.aspx";
                    }
                    if (base.Request.QueryString["returnUrl"] != null)
                    {
                        item = base.Request.QueryString["returnUrl"];
                    }
                    base.Response.Redirect(item, false);
                    return;
                }
                UserAttemptDAO userAttemptDAO3 = new UserAttemptDAO()
                {
                    user_password = Utility.ParseText(this.txtPassword.Text),
                    date_attempt = DateTime.Now,
                    ip_address = str1,
                    pc_name = str,
                    reaseon_for_attempt_failure = "Incorrect user id"
                };
                this.lblErrorMsg.Text = "User id is incorrect.";
            }
        }

        private static int callService()
        {
            int num;
            int num1 = 1;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(Logins.URL, "extenddemoperiod"));
                string macId = UtilityK.getMacId();
                string hostName = Dns.GetHostName();
                string str = Dns.GetHostByName(hostName).AddressList[0].ToString();
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Headers.Set("macId", macId);
                httpWebRequest.Headers.Set("version", Logins.version);
                httpWebRequest.Headers.Set("hostName", hostName);
                httpWebRequest.Headers.Set("ipAddress", str);
                httpWebRequest.Headers.Set("secretKey", "TCLMNOPQRSTUVWXYZ");
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                Logins.ResponseResult responseResult = (new JavaScriptSerializer()).Deserialize<Logins.ResponseResult>(end);
                string str1 = responseResult.data;
                object obj = responseResult.modal;
                string str2 = responseResult.reponseStatus;
                num1 = responseResult.totalNumber;
                num = num1;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                return num1;
            }
            return num;
        }

        private static Logins.LicenseUpdateResponse callServiceForUpdateServicePack(string publicKey)
        {
            Logins.LicenseUpdateResponse licenseUpdateResponse;
            Logins.LicenseUpdateResponse licenseUpdateResponse1 = new Logins.LicenseUpdateResponse();
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(Logins.URL, "updateservicepack"));
                string macId = UtilityK.getMacId();
                string hostName = Dns.GetHostName();
                string str = Dns.GetHostByName(hostName).AddressList[0].ToString();
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Headers.Set("macId", macId);
                httpWebRequest.Headers.Set("version", Logins.version);
                httpWebRequest.Headers.Set("publicKey", publicKey);
                httpWebRequest.Headers.Set("ipAddress", str);
                httpWebRequest.Headers.Set("secretKey", "TCLMNOPQRSTUVWXYZ");
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                licenseUpdateResponse1 = (new JavaScriptSerializer()).Deserialize<Logins.LicenseUpdateResponse>(end);
                licenseUpdateResponse = licenseUpdateResponse1;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                return licenseUpdateResponse1;
            }
            return licenseUpdateResponse;
        }



        private bool checkUserLimit()
        {
            int num = Convert.ToInt32(base.Application["TotalOnlineUsers"].ToString());
            if (num > 0)
            {
                DataTable activeLicenseInfo = this.uBll.getActiveLicenseInfo();
                if (activeLicenseInfo.Rows.Count <= 0)
                {
                    this.Session["PRODUCT_ACTIVE"] = false;
                    if (num > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    int num1 = Convert.ToInt32(activeLicenseInfo.Rows[0]["concurrent_user"].ToString());
                    Convert.ToDateTime(activeLicenseInfo.Rows[0]["activation_date"].ToString());
                    activeLicenseInfo.Rows[0]["app_version"].ToString();
                    activeLicenseInfo.Rows[0]["license_key"].ToString();
                    this.Session["PRODUCT_ACTIVE"] = true;
                    if (this.uBll.getActiveLicenseInfoNotExpire().Rows.Count > 0)
                    {
                        this.Session["PRODUCT_EXPIRE"] = false;
                    }
                    else
                    {
                        this.Session["PUB_KEY"] = activeLicenseInfo.Rows[0]["license_key"].ToString();
                        this.Session["PRODUCT_EXPIRE"] = true;
                    }
                    if (num > num1)
                    {
                        return false;
                    }
                }
            }
            return true;
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



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Session.Abandon();
            }
        }

        private bool Validation()
        {
            if (this.txtUserId.Text.Trim().Length < 1)
            {
                this.txtUserId.Focus();
                this.lblErrorMsg.Text = "Please enter your user id.";
                return false;
            }
            if (this.txtPassword.Text.Trim().Length >= 1)
            {
                return true;
            }
            this.txtPassword.Focus();
            this.lblErrorMsg.Text = "Please enter your password.";
            return false;
        }

        public class LicenseUpdateResponse
        {
            public int concurrentUser
            {
                get;
                set;
            }

            public int expireDay
            {
                get;
                set;
            }

            public long reponseCode
            {
                get;
                set;
            }

            public string reponseMessage
            {
                get;
                set;
            }

            public long reponseStatus
            {
                get;
                set;
            }

            public int servicePack
            {
                get;
                set;
            }

            public LicenseUpdateResponse()
            {
            }
        }

        public class ResponseResult
        {
            public string content
            {
                get;
                set;
            }

            public string data
            {
                get;
                set;
            }

            public object modal
            {
                get;
                set;
            }

            public string reponseMessage
            {
                get;
                set;
            }

            public string reponseStatus
            {
                get;
                set;
            }

            public int totalNumber
            {
                get;
                set;
            }

            public ResponseResult()
            {
            }
        }
    }
}