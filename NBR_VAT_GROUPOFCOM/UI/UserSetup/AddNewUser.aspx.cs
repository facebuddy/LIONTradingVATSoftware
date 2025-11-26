using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ASP;
using NBR_VAT_GROUPOFCOM.UserControls;
using NBR_VAT_GROUPOFCOM.BLL;

namespace NBR_VAT_GROUPOFCOM.UI.UserSetup
{
    public partial class AddNewUser : Page, IRequiresSessionState
    {

     
        private AddUserDAO addUserDao = new AddUserDAO();

        // Token: 0x0400002B RID: 43
        private AddUserBLL objuserBll = new AddUserBLL();
     
        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.LoadSystemUser();
                this.LoadDepartment();
                this.LoadDesignation();
                this.EmployeeStatus();
                this.LoadUserLevel();
                this.LoadOrganization();
                this.LoadGridInformation();
                this.btnUpdate.Visible = false;
            }
        }

        // Token: 0x06000014 RID: 20 RVA: 0x00002C60 File Offset: 0x00000E60
        private void LoadSystemUser()
        {
            this.drpIsSyatemUser.Items.Insert(0, new ListItem("-- SELECT --", "-99"));
            this.drpIsSyatemUser.Items.Insert(1, new ListItem("Yes", "1"));
            this.drpIsSyatemUser.Items.Insert(2, new ListItem("No", "2"));
        }

        // Token: 0x06000015 RID: 21 RVA: 0x00002CD0 File Offset: 0x00000ED0
        private void LoadOrganization()
        {
            DataTable dataTable = new DataTable();
            string a = "";
            string a2 = "";
            DataTable masterOrganization = this.objuserBll.GetMasterOrganization();
            if (masterOrganization != null && masterOrganization.Rows.Count > 0)
            {
                a = masterOrganization.Rows[0]["admin_type"].ToString();
                a2 = masterOrganization.Rows[0]["bin_type"].ToString();
            }
            if (a == "S" && a2 == "M")
            {
                dataTable = this.objuserBll.GetOrganizationMultiBINSigleAdmin();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.drpOrganizationID.DataSource = dataTable;
                    this.drpOrganizationID.DataTextField = dataTable.Columns["organization_name"].ToString();
                    this.drpOrganizationID.DataValueField = dataTable.Columns["organization_id"].ToString();
                    this.drpOrganizationID.DataBind();
                }
            }
            else
            {
                dataTable = this.addUserDao.GetOrganization();
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.drpOrganizationID.DataSource = dataTable;
                    this.drpOrganizationID.DataTextField = dataTable.Columns["organization_name"].ToString();
                    this.drpOrganizationID.DataValueField = dataTable.Columns["organization_id"].ToString();
                    this.drpOrganizationID.DataBind();
                }
            }
            ListItem item = new ListItem("-- SELECT --", "-99");
            this.drpOrganizationID.Items.Insert(0, item);
            this.Session["ORGANIZATION_"] = dataTable;
        }

        // Token: 0x06000016 RID: 22 RVA: 0x00002E88 File Offset: 0x00001088
        private void LoadDepartment()
        {
            DataTable department = this.addUserDao.GetDepartment();
            if (department != null && department.Rows.Count > 0)
            {
                this.drpDepartment.DataSource = department;
                this.drpDepartment.DataTextField = department.Columns["department_name"].ToString();
                this.drpDepartment.DataValueField = department.Columns["department_id"].ToString();
                this.drpDepartment.DataBind();
            }
            ListItem item = new ListItem("-- SELECT --", "-99");
            this.drpDepartment.Items.Insert(0, item);
            this.Session["DEPARTMENT"] = department;
        }

        // Token: 0x06000017 RID: 23 RVA: 0x00002F3C File Offset: 0x0000113C
        private void LoadDesignation()
        {
            DataTable designation = this.addUserDao.GetDesignation();
            if (designation != null && designation.Rows.Count > 0)
            {
                this.drpDesignation.DataSource = designation;
                this.drpDesignation.DataTextField = designation.Columns["designation_name"].ToString();
                this.drpDesignation.DataValueField = designation.Columns["designation_id"].ToString();
                this.drpDesignation.DataBind();
            }
            ListItem item = new ListItem("-- SELECT --", "-99");
            this.drpDesignation.Items.Insert(0, item);
            this.Session["DESIGNATION"] = designation;
        }

        // Token: 0x06000018 RID: 24 RVA: 0x00002FF0 File Offset: 0x000011F0
        private void LoadUserLevel()
        {
            this.DrpUserLevel.Items.Insert(0, new ListItem("-- SELECT --", "-99"));
            this.DrpUserLevel.Items.Insert(1, new ListItem("Admin", "1"));
            this.DrpUserLevel.Items.Insert(2, new ListItem("Manager User", "2"));
            this.DrpUserLevel.Items.Insert(2, new ListItem("Normal User", "3"));
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00003080 File Offset: 0x00001280
        private void LoadUserLevelbyUser(string sysUser)
        {
            if (sysUser == "1")
            {
                this.DrpUserLevel.Items.Insert(0, new ListItem("-- SELECT --", "-99"));
                this.DrpUserLevel.Items.Insert(1, new ListItem("Admin", "1"));
                this.DrpUserLevel.SelectedValue = "1";
                return;
            }
            this.DrpUserLevel.Items.Insert(0, new ListItem("-- SELECT --", "-99"));
            this.DrpUserLevel.Items.Insert(1, new ListItem("Manager User", "2"));
            this.DrpUserLevel.Items.Insert(2, new ListItem("Normal User", "3"));
        }

        // Token: 0x0600001A RID: 26 RVA: 0x0000314C File Offset: 0x0000134C
        private void EmployeeStatus()
        {
            this.DrpEmployeeStatus.Items.Insert(0, new ListItem("-- SELECT --", "-99"));
            this.DrpEmployeeStatus.Items.Insert(1, new ListItem("Active", "1"));
            this.DrpEmployeeStatus.Items.Insert(2, new ListItem("InActive", "2"));
        }

        // Token: 0x0600001B RID: 27 RVA: 0x000031BC File Offset: 0x000013BC
        private bool Validations()
        {
            int num = (int)Convert.ToInt16(this.drpOrganizationID.SelectedValue);
            DataTable masterOrganization = this.objuserBll.GetMasterOrganization();
            int num2 = 0;
            if (masterOrganization.Rows.Count > 0)
            {
                num2 = (int)Convert.ToInt16(masterOrganization.Rows[0]["master_organization_ID"]);
            }
            DataTable noOfUserByorgId = this.addUserDao.GetNoOfUserByorgId(num2);
            DataTable noEmployeeByorgId = this.objuserBll.GetNoEmployeeByorgId(num);
            //if (noOfUserByorgId.Rows.Count > 0)
            //{
            //    int num3 = (int)Convert.ToInt16(noOfUserByorgId.Rows[0]["user_no"]);
            //    if (noEmployeeByorgId.Rows.Count > 0)
            //    {
            //        int num4 = (int)(Convert.ToInt16(noEmployeeByorgId.Rows[0]["emp"]) + 1);
            //        if (num4 > num3)
            //        {
            //            this.msgBox.AddMessage("User Limit Exceeds.", MsgBoxs.enmMessageType.Error);
            //            return false;
            //        }
            //    }
            //}
            if (this.txtEmployeeName.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Employee Name.", MsgBoxs.enmMessageType.Error);
                this.txtEmployeeName.Focus();
                return false;
            }
            if (this.txtAddress.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Employee Address.", MsgBoxs.enmMessageType.Error);
                this.txtAddress.Focus();
                return false;
            }
            if (this.txtNID.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Employee NID.", MsgBoxs.enmMessageType.Error);
                this.txtNID.Focus();
                return false;
            }
            if (this.txtNID.Text.Length != 10 && this.txtNID.Text.Length != 17)
            {
                this.msgBox.AddMessage("NID must be 10 or 17 digit.", MsgBoxs.enmMessageType.Error);
                this.txtNID.Focus();
                return false;
            }
            if (!this.FileUploadControl.HasFile)
            {
                this.msgBox.AddMessage("Please Upload Image.", MsgBoxs.enmMessageType.Error);
                return false;
            }
            if (this.txtLoginID.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Login ID.", MsgBoxs.enmMessageType.Error);
                this.txtLoginID.Focus();
                return false;
            }
            if (this.txtLoginPassword.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Login Password.", MsgBoxs.enmMessageType.Error);
                this.txtLoginPassword.Focus();
                return false;
            }
            if (this.drpOrganizationID.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Organization.", MsgBoxs.enmMessageType.Error);
                this.drpOrganizationID.Focus();
                return false;
            }
            if (this.drpDesignation.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Designation.", MsgBoxs.enmMessageType.Error);
                this.drpDesignation.Focus();
                return false;
            }
            if (this.drpDepartment.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Departmanet.", MsgBoxs.enmMessageType.Error);
                this.drpDepartment.Focus();
                return false;
            }
            if (this.DrpEmployeeStatus.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Employee Status.", MsgBoxs.enmMessageType.Error);
                this.DrpEmployeeStatus.Focus();
                return false;
            }
            if (this.txtJoiningDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Joining Date.", MsgBoxs.enmMessageType.Error);
                this.txtJoiningDate.Focus();
                return false;
            }
            if (this.txtJoiningDate.Text.Length != 0 && this.txtRetirementDate.Text.Length != 0)
            {
                try
                {
                    DateTime t = DateTime.ParseExact(this.txtJoiningDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime t2 = DateTime.ParseExact(this.txtRetirementDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (t > t2)
                    {
                        this.msgBox.AddMessage("Retirement Date must be greater than Joining Date.", MsgBoxs.enmMessageType.Error);
                        this.txtRetirementDate.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (this.txtPhone.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Phone No.", MsgBoxs.enmMessageType.Error);
                this.txtPhone.Focus();
                return false;
            }
            if (this.txtEmail.Text.Length != 0 && (!this.txtEmail.Text.EndsWith(".com") || !this.txtEmail.Text.Contains("@")))
            {
                this.msgBox.AddMessage("You should insert a valid mail address", MsgBoxs.enmMessageType.Error);
                this.txtEmail.Focus();
                return false;
            }
            if (this.txtPhone.Text.Length > 0 && this.txtPhone.Text.Length != 11)
            {
                this.msgBox.AddMessage("You should insert a valid (11 digit) phone number", MsgBoxs.enmMessageType.Error);
                this.txtEmail.Focus();
                return false;
            }
            return true;
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00003680 File Offset: 0x00001880
        private bool ValidationsforUpdate()
        {
            if (this.txtEmployeeName.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Employee Name.", MsgBoxs.enmMessageType.Error);
                this.txtEmployeeName.Focus();
                return false;
            }
            if (this.txtLoginID.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Login ID.", MsgBoxs.enmMessageType.Error);
                this.txtLoginID.Focus();
                return false;
            }
            if (this.txtLoginPassword.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Login Password.", MsgBoxs.enmMessageType.Error);
                this.txtLoginPassword.Focus();
                return false;
            }
            if (this.drpOrganizationID.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Organization.", MsgBoxs.enmMessageType.Error);
                this.drpOrganizationID.Focus();
                return false;
            }
            if (this.drpDesignation.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Designation.", MsgBoxs.enmMessageType.Error);
                this.drpDesignation.Focus();
                return false;
            }
            if (this.drpDepartment.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Departmanet.", MsgBoxs.enmMessageType.Error);
                this.drpDepartment.Focus();
                return false;
            }
            if (this.DrpEmployeeStatus.SelectedValue == "-99")
            {
                this.msgBox.AddMessage("Please select Employee Status.", MsgBoxs.enmMessageType.Error);
                this.DrpEmployeeStatus.Focus();
                return false;
            }
            if (this.txtJoiningDate.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Joining Date.", MsgBoxs.enmMessageType.Error);
                this.txtJoiningDate.Focus();
                return false;
            }
            if (this.txtJoiningDate.Text.Length != 0 && this.txtRetirementDate.Text.Length != 0)
            {
                try
                {
                    DateTime t = DateTime.ParseExact(this.txtJoiningDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime t2 = DateTime.ParseExact(this.txtRetirementDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (t > t2)
                    {
                        this.msgBox.AddMessage("Retirement Date must be greater than Joining Date.", MsgBoxs.enmMessageType.Error);
                        this.txtRetirementDate.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (this.txtPhone.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please insert Phone No.", MsgBoxs.enmMessageType.Error);
                this.txtPhone.Focus();
                return false;
            }
            if (this.txtEmail.Text.Length != 0 && (!this.txtEmail.Text.EndsWith(".com") || !this.txtEmail.Text.Contains("@")))
            {
                this.msgBox.AddMessage("You should insert a valid mail address", MsgBoxs.enmMessageType.Error);
                this.txtEmail.Focus();
                return false;
            }
            if (this.txtPhone.Text.Length > 0 && this.txtPhone.Text.Length != 11)
            {
                this.msgBox.AddMessage("You should insert a valid (11 digit) phone number", MsgBoxs.enmMessageType.Error);
                this.txtEmail.Focus();
                return false;
            }
            if (this.txtAddress.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Employee Address.", MsgBoxs.enmMessageType.Error);
                this.txtAddress.Focus();
                return false;
            }
            if (this.txtNID.Text.Length == 0)
            {
                this.msgBox.AddMessage("Please Insert Employee NID.", MsgBoxs.enmMessageType.Error);
                this.txtNID.Focus();
                return false;
            }
            if (this.txtNID.Text.Length != 10 && this.txtNID.Text.Length != 17)
            {
                this.msgBox.AddMessage("NID must be 10 or 17 digit.", MsgBoxs.enmMessageType.Error);
                this.txtNID.Focus();
                return false;
            }
            if (this.path.Text == "")
            {
                this.msgBox.AddMessage("Please Upload Image.", MsgBoxs.enmMessageType.Error);
                return false;
            }
            return true;
        }

        // Token: 0x0600001D RID: 29 RVA: 0x00003A70 File Offset: 0x00001C70
        private bool SaveAddUser()
        {
            this.addUserDao.Employee_name = this.txtEmployeeName.Text.ToString();
            if (Convert.ToInt16(this.drpIsSyatemUser.SelectedItem.Value) == 1)
            {
                this.addUserDao.Is_system_user = true;
            }
            else
            {
                this.addUserDao.Is_system_user = false;
            }
            this.addUserDao.Login_id = this.txtLoginID.Text.ToUpper().ToString();
            this.addUserDao.Login_password = Crypto.HashPassword(this.txtLoginPassword.Text.ToString());
            this.addUserDao.Department_id = Convert.ToInt16(this.drpDepartment.SelectedItem.Value.ToString());
            this.addUserDao.Designation_id = Convert.ToInt16(this.drpDesignation.SelectedItem.Value.ToString());
            this.addUserDao.User_level = Convert.ToInt16(this.DrpUserLevel.SelectedItem.Value.ToString());
            this.addUserDao.Emplyee_status = Convert.ToInt16(this.DrpEmployeeStatus.SelectedItem.Value.ToString());
            this.addUserDao.Mobile_no = this.txtPhone.Text.ToString();
            this.addUserDao.Email = this.txtEmail.Text.ToString();
            this.addUserDao.Organization_id = Convert.ToInt16(this.drpOrganizationID.SelectedItem.Value.ToString());
            this.addUserDao.Branch_id = Convert.ToInt16(this.drpBranchInformation.SelectedItem.Value.ToString());
            this.addUserDao.DateJoining = DateTime.ParseExact(this.txtJoiningDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (this.txtRetirementDate.Text.Length > 0)
            {
                this.addUserDao.DateRetirement = DateTime.ParseExact(this.txtRetirementDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                this.addUserDao.DateRetirement = DateTime.MinValue;
            }
            this.addUserDao.user_status = "N";
            if (this.FileUploadControl.HasFile)
            {
                string str = this.FileUploadControl.FileName.ToString();
                string filename = base.Server.MapPath("~/Uploads/" + str);
                this.FileUploadControl.SaveAs(filename);
                this.addUserDao.Image = base.Server.MapPath("~/Uploads/" + str);
            }
            this.addUserDao.Address = this.txtAddress.Text;
            this.addUserDao.NID = this.txtNID.Text;
            return this.addUserDao.SaveAddUser();
        }

        // Token: 0x0600001E RID: 30 RVA: 0x00003D44 File Offset: 0x00001F44
        private bool UpdateAddUser()
        {
            this.addUserDao.Employee_name = this.txtEmployeeName.Text.ToString();
            if (Convert.ToInt16(this.drpIsSyatemUser.SelectedItem.Value) == 1)
            {
                this.addUserDao.Is_system_user = true;
            }
            else
            {
                this.addUserDao.Is_system_user = false;
            }
            this.addUserDao.Login_id = this.txtLoginID.Text.ToUpper().ToString();
            this.addUserDao.Login_password = Crypto.HashPassword(this.txtLoginPassword.Text.ToString());
            this.addUserDao.Department_id = Convert.ToInt16(this.drpDepartment.SelectedItem.Value.ToString());
            this.addUserDao.Designation_id = Convert.ToInt16(this.drpDesignation.SelectedItem.Value.ToString());
            this.addUserDao.User_level = Convert.ToInt16(this.DrpUserLevel.SelectedItem.Value.ToString());
            this.addUserDao.Emplyee_status = Convert.ToInt16(this.DrpEmployeeStatus.SelectedItem.Value.ToString());
            this.addUserDao.Organization_id = Convert.ToInt16(this.drpOrganizationID.SelectedItem.Value.ToString());
            this.addUserDao.Branch_id = Convert.ToInt16(this.drpBranchInformation.SelectedItem.Value.ToString());
            this.addUserDao.Mobile_no = this.txtPhone.Text.ToString();
            this.addUserDao.Email = this.txtEmail.Text.ToString();
            this.addUserDao.DateJoining = DateTime.ParseExact(this.txtJoiningDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (this.txtRetirementDate.Text.Length > 0)
            {
                this.addUserDao.DateRetirement = DateTime.ParseExact(this.txtRetirementDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                this.addUserDao.DateRetirement = DateTime.MinValue;
            }
            if (this.FileUploadControl.HasFile)
            {
                string str = this.FileUploadControl.FileName.ToString();
                string filename = base.Server.MapPath("~/Uploads/" + str);
                this.FileUploadControl.SaveAs(filename);
                this.addUserDao.Image = base.Server.MapPath("~/Uploads/" + str);
            }
            this.addUserDao.Address = this.txtAddress.Text;
            this.addUserDao.NID = this.txtNID.Text;
            Convert.ToInt16(this.gvUserDetail.SelectedRow.Cells[1].Text);
            int num = Convert.ToInt32(this.EmployeeID.Text.Trim());
            return this.addUserDao.UpdateAddUser(num);
        }

        // Token: 0x0600001F RID: 31 RVA: 0x00004040 File Offset: 0x00002240
        private void ClearControl()
        {
            this.path.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtNID.Text = string.Empty;
            this.Image1.Visible = false;
            this.txtEmployeeName.Text = string.Empty;
            this.drpIsSyatemUser.ClearSelection();
            this.txtLoginID.Text = string.Empty;
            this.txtLoginPassword.Text = string.Empty;
            this.drpDepartment.ClearSelection();
            this.drpDesignation.ClearSelection();
            this.DrpUserLevel.ClearSelection();
            this.DrpUserLevel.Items.Clear();
            this.LoadUserLevel();
            this.DrpEmployeeStatus.ClearSelection();
            this.txtJoiningDate.Text = string.Empty;
            this.txtRetirementDate.Text = string.Empty;
            this.lblMessage.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.LoadOrganization();
            this.drpBranchInformation.Items.Clear();
            this.LoadDesignation();
        }

        // Token: 0x06000020 RID: 32 RVA: 0x00004174 File Offset: 0x00002374
        private void LoadGridInformation()
        {
            DataSet tableForGrid = this.addUserDao.GetTableForGrid();
            this.gvUserDetail.DataSource = tableForGrid;
            this.gvUserDetail.DataBind();
        }

        // Token: 0x06000021 RID: 33 RVA: 0x000041B8 File Offset: 0x000023B8
        private string Encrypt(string password)
        {
            string password2 = "ABEDIN";
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password2, new byte[]
                {
                73,
                118,
                97,
                110,
                32,
                77,
                101,
                100,
                118,
                101,
                100,
                101,
                118
                });
                aes.Key = rfc2898DeriveBytes.GetBytes(32);
                aes.IV = rfc2898DeriveBytes.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                        cryptoStream.Close();
                    }
                    password = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return password;
        }

        // Token: 0x06000022 RID: 34 RVA: 0x0000429C File Offset: 0x0000249C
        private void LoadBranchInformation(int organization_id)
        {
            DataTable branchInformation = this.addUserDao.GetBranchInformation(organization_id);
            if (branchInformation != null && branchInformation.Rows.Count > 0)
            {
                this.drpBranchInformation.DataSource = branchInformation;
                this.drpBranchInformation.DataTextField = branchInformation.Columns["branch_unit_name"].ToString();
                this.drpBranchInformation.DataValueField = branchInformation.Columns["org_branch_reg_id"].ToString();
                this.drpBranchInformation.DataBind();
            }
            this.Session["BRANCH_"] = branchInformation;
        }

        // Token: 0x06000023 RID: 35 RVA: 0x00004330 File Offset: 0x00002530
        private string GetCurrentURL()
        {
            base.Request.ApplicationPath.ToString();
            base.Request.RawUrl.ToString();
            string[] array = base.Request.RawUrl.ToString().Split(new char[]
            {
            '/'
            });
            return string.Concat(new string[]
            {
            "~/",
            array[2],
            "/",
            array[3],
            "/",
            array[4].ToString()
            });
        }

        // Token: 0x06000024 RID: 36 RVA: 0x000043C0 File Offset: 0x000025C0
        protected void btnOkToReload(object sender, EventArgs e)
        {
        }

        // Token: 0x06000025 RID: 37 RVA: 0x000043C2 File Offset: 0x000025C2
        protected void btnCancelToSaveInvoice(object sender, EventArgs e)
        {
        }

        // Token: 0x06000026 RID: 38 RVA: 0x000043C4 File Offset: 0x000025C4
        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            this.lblSave.Text = "";
            if (this.Validations())
            {
                DataSet dataSet = this.addUserDao.CheckExistUserToInsert(this.txtLoginID.Text.ToUpper().ToString());
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    this.msgBox.AddMessage("Login ID already exist.", MsgBoxs.enmMessageType.Attention);
                    return;
                }
                bool flag = this.SaveAddUser();
                if (flag)
                {
                    this.msgBox.AddMessage("Information Saved Successfully", MsgBoxs.enmMessageType.Success);
                    this.ClearControl();
                    this.LoadGridInformation();
                    return;
                }
                this.msgBox.AddMessage("Information Saved Failed", MsgBoxs.enmMessageType.Error);
            }
        }

        // Token: 0x06000027 RID: 39 RVA: 0x00004484 File Offset: 0x00002684
        protected void gvUserDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnUpdate.Visible = true;
            this.btnSave.Visible = false;
            this.ClearControl();
            this.Image1.Visible = true;
            int value = (int)Convert.ToInt16(this.gvUserDetail.SelectedRow.Cells[1].Text);
            DataSet tableForGridwithempid = this.addUserDao.GetTableForGridwithempid((int)Convert.ToInt16(value));
            this.EmployeeID.Text = value.ToString();
            this.drpIsSyatemUser.SelectedValue = tableForGridwithempid.Tables[0].Rows[0]["is_system_user_count"].ToString();
            this.drpDepartment.SelectedValue = tableForGridwithempid.Tables[0].Rows[0]["department_id"].ToString();
            this.drpDesignation.SelectedValue = tableForGridwithempid.Tables[0].Rows[0]["designation_id"].ToString();
            this.DrpUserLevel.Items.Clear();
            this.LoadUserLevelbyUser(this.drpIsSyatemUser.SelectedValue);
            this.DrpUserLevel.SelectedValue = tableForGridwithempid.Tables[0].Rows[0]["user_level"].ToString();
            this.DrpEmployeeStatus.SelectedValue = tableForGridwithempid.Tables[0].Rows[0]["emplyee_status"].ToString();
            string a = tableForGridwithempid.Tables[0].Rows[0]["organization_id"].ToString();
            if (!(a == ""))
            {
                this.drpOrganizationID.SelectedValue = tableForGridwithempid.Tables[0].Rows[0]["organization_id"].ToString();
            }
            int organization_id = Convert.ToInt32(this.drpOrganizationID.SelectedItem.Value);
            this.LoadBranchInformation(organization_id);
            this.drpBranchInformation.SelectedValue = tableForGridwithempid.Tables[0].Rows[0]["org_branch_reg_id"].ToString();
            this.txtEmployeeName.Text = tableForGridwithempid.Tables[0].Rows[0]["employee_name"].ToString();
            this.txtLoginID.Text = tableForGridwithempid.Tables[0].Rows[0]["login_id"].ToString();
            this.txtLoginPassword.Text = tableForGridwithempid.Tables[0].Rows[0]["login_password"].ToString();
            DateTime t = DateTime.Parse(tableForGridwithempid.Tables[0].Rows[0]["date_join"].ToString());
            string a2 = tableForGridwithempid.Tables[0].Rows[0]["date_retirement"].ToString();
            if (a2 != "")
            {
                DateTime t2 = DateTime.Parse(tableForGridwithempid.Tables[0].Rows[0]["date_retirement"].ToString());
                if (t > t2)
                {
                    this.txtRetirementDate.Text = "";
                }
                else
                {
                    this.txtRetirementDate.Text = t2.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                this.txtRetirementDate.Text = "";
            }
            this.txtJoiningDate.Text = t.ToString("dd/MM/yyyy");
            this.txtPhone.Text = tableForGridwithempid.Tables[0].Rows[0]["mobile_no"].ToString();
            this.txtEmail.Text = tableForGridwithempid.Tables[0].Rows[0]["email"].ToString();
            this.txtAddress.Text = tableForGridwithempid.Tables[0].Rows[0]["employee_address"].ToString();
            this.txtNID.Text = tableForGridwithempid.Tables[0].Rows[0]["employee_nid"].ToString();
            this.divImage.Visible = true;
            this.Image1.ImageUrl = "../../Uploads/" + Path.GetFileName(tableForGridwithempid.Tables[0].Rows[0]["employee_image"].ToString());
            this.path.Text = "../../Uploads/" + Path.GetFileName(tableForGridwithempid.Tables[0].Rows[0]["employee_image"].ToString());
        }

        // Token: 0x06000028 RID: 40 RVA: 0x0000499C File Offset: 0x00002B9C
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            this.lblSave.Text = "";
            if (this.ValidationsforUpdate())
            {
                bool flag = this.UpdateAddUser();
                if (!flag)
                {
                    this.msgBox.AddMessage("Information Updated Failed", MsgBoxs.enmMessageType.Error);
                    return;
                }
                this.msgBox.AddMessage("Information Updated Successfully", MsgBoxs.enmMessageType.Success);
                this.ClearControl();
                this.LoadGridInformation();
                this.gvUserDetail.SelectedIndex = -1;
                this.btnSave.Visible = true;
                this.btnUpdate.Visible = false;
            }
        }

        // Token: 0x06000029 RID: 41 RVA: 0x00004A30 File Offset: 0x00002C30
        protected void gvUserDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvUserDetail.PageIndex = e.NewPageIndex;
            this.gvUserDetail.DataBind();
        }

        // Token: 0x0600002A RID: 42 RVA: 0x00004A50 File Offset: 0x00002C50
        protected void gvUserDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.lblMessage.Text = string.Empty;
            this.lblSave.Text = string.Empty;
            string value = e.Values[0].ToString();
            if (e.Values[1].ToString() == "ADMIN")
            {
                this.lblMessage.Text = "Can't Delete Admin User.";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Can't Delete Admin User.');", true);
                return;
            }
            DataSet dataSet = this.addUserDao.CheckUserPermissionInMenuPermission((int)Convert.ToInt16(value));
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                this.lblMessage.Text = "This user has permission in several menu. Please revoke permission for delete.";
                return;
            }
            bool flag = this.addUserDao.DeleteAddUser((int)Convert.ToInt16(value));
            if (flag)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Information Deleted Successfully.');", true);
                this.ClearControl();
                this.LoadGridInformation();
                this.gvUserDetail.SelectedIndex = -1;
                return;
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('There is a problem in data delete.');", true);
        }

        // Token: 0x0600002B RID: 43 RVA: 0x00004B8A File Offset: 0x00002D8A
        protected void gvUserDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState != DataControlRowState.Normal)
            {
                DataControlRowState rowState = e.Row.RowState;
            }
        }

        // Token: 0x0600002C RID: 44 RVA: 0x00004BA8 File Offset: 0x00002DA8
        protected void drpIsSyatemUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DrpUserLevel.Items.Clear();
            string sysUser = this.drpIsSyatemUser.SelectedValue.ToString();
            this.LoadUserLevelbyUser(sysUser);
        }

        // Token: 0x0600002D RID: 45 RVA: 0x00004BE0 File Offset: 0x00002DE0
        protected void drpOrganizationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.drpBranchInformation.Items.Clear();
            if (this.drpOrganizationID.SelectedValue == "-99")
            {
                this.lblMessage.Text = "Please select Organization.";
                this.drpOrganizationID.Focus();
                return;
            }
            this.drpBranchInformation.Items.Clear();
            int organization_id = Convert.ToInt32(this.drpOrganizationID.SelectedItem.Value.ToString());
            this.LoadBranchInformation(organization_id);
            if (base.IsPostBack && !string.IsNullOrEmpty(this.txtLoginPassword.Text.Trim()))
            {
                this.txtLoginPassword.Attributes["value"] = this.txtLoginPassword.Text;
            }
        }

        // Token: 0x0600002E RID: 46 RVA: 0x00004CA4 File Offset: 0x00002EA4
        protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drpDepartment.SelectedValue != "-99")
            {
                int num = Convert.ToInt32(this.drpDepartment.SelectedValue);
                DataTable designationByDeptId = this.objuserBll.GetDesignationByDeptId(num);
                if (designationByDeptId != null && designationByDeptId.Rows.Count > 0)
                {
                    this.drpDesignation.DataSource = designationByDeptId;
                    this.drpDesignation.DataTextField = designationByDeptId.Columns["designation_name"].ToString();
                    this.drpDesignation.DataValueField = designationByDeptId.Columns["designation_id"].ToString();
                    this.drpDesignation.DataBind();
                }
                ListItem item = new ListItem("-- SELECT --", "-99");
                this.drpDesignation.Items.Insert(0, item);
                return;
            }
            DataTable designation = this.addUserDao.GetDesignation();
            if (designation != null && designation.Rows.Count > 0)
            {
                this.drpDesignation.DataSource = designation;
                this.drpDesignation.DataTextField = designation.Columns["designation_name"].ToString();
                this.drpDesignation.DataValueField = designation.Columns["designation_id"].ToString();
                this.drpDesignation.DataBind();
            }
            ListItem item2 = new ListItem("-- SELECT --", "-99");
            this.drpDesignation.Items.Insert(0, item2);
        }

      


  

      
    }
}