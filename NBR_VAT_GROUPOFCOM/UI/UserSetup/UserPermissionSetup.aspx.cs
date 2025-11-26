using System;
using System.Collections;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using NBR_VAT_GROUPOFCOM.UserControls;
using NBR_VAT_GROUPOFCOM.BLL;

namespace NBR_VAT_GROUPOFCOM.UI.UserSetup
{
    public partial class UserPermissionSetup : Page, IRequiresSessionState
    {

        private UserPermissionBLL userPermission = new UserPermissionBLL();

        private UserPermissionDAO userPermissionDAO = new UserPermissionDAO();

        private ArrayList arrPermissionKey = new ArrayList();

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

        public UserPermissionSetup()
        {
        }

        private void AddPermissionKey(TreeNode tParentNode)
        {
            try
            {
                DataSet dataSet = new DataSet();
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                UserPermissionDAO userPermissionDAO = new UserPermissionDAO();
                if (tParentNode != null)
                {
                    foreach (TreeNode childNode in tParentNode.ChildNodes)
                    {
                        if (!childNode.Checked)
                        {
                            continue;
                        }
                        userPermissionDAO.PermissionKey = childNode.Value.ToString();
                        this.arrPermissionKey.Add(childNode.Value.ToString());
                        this.AddPermissionKey(childNode);
                    }
                }
                else
                {
                    foreach (TreeNode node in this.tvwUserPermission.Nodes)
                    {
                        if (node.Checked)
                        {
                            userPermissionDAO.PermissionKey = node.Value.ToString();
                            this.arrPermissionKey.Add(node.Value.ToString());
                        }
                        foreach (TreeNode treeNode in node.ChildNodes)
                        {
                            if (!treeNode.Checked)
                            {
                                continue;
                            }
                            userPermissionDAO.PermissionKey = treeNode.Value.ToString();
                            this.arrPermissionKey.Add(treeNode.Value.ToString());
                            this.AddPermissionKey(treeNode);
                        }
                    }
                }
                this.Session["arrPermissionKey"] = this.arrPermissionKey;
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.tvwUserPermission.Nodes.Clear();
                string str = Utility.ParseText(this.txtEmployeeName.Text.ToUpper().Trim());
                if (this.txtEmployeeName.Text.Length != 0)
                {
                    this.ShowAllUserInGrid(str);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Please insert Employee Name.');", true);
                    this.txtEmployeeName.Focus();
                }
                this.LoadPermissionData(null);
                this.tvwUserPermission.CollapseAll();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = string.Empty;
            if (this.gvUser.SelectedIndex == -1)
            {
                this.msgBox.AddMessage("User Permission Please select a user first..", MsgBoxs.enmMessageType.Error);
                return;
            }
            UserPermissionDAO userPermissionDAO = new UserPermissionDAO()
            {
                employee_id = Convert.ToInt32(this.ViewState["UID"])
            };
            this.SaveUserPermission(userPermissionDAO.employee_id);
            this.tvwUserPermission.Nodes.Clear();
            this.tvwUserPermission.CollapseAll();
            this.LoadPermissionData(null);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Data Saved Successfully.');", true);
            this.gvUser.SelectedIndex = -1;
        }

        private void EditUserPermission(TreeNode tParentNode, int intUserId)
        {
            try
            {
                this.userPermission = new UserPermissionBLL();
                DataSet dataSet = new DataSet();
                dataSet = (tParentNode != null ? this.userPermission.getUserPermission(tParentNode.Value.ToString()) : this.userPermission.getUserPermission(""));
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    TreeNode treeNode = new TreeNode()
                    {
                        SelectAction = TreeNodeSelectAction.None,
                        Text = row[3].ToString(),
                        Value = row[0].ToString()
                    };
                    if (tParentNode != null)
                    {
                        tParentNode.ChildNodes.Add(treeNode);
                        treeNode.Checked = Convert.ToBoolean(this.EditUserPermission(intUserId, row[0].ToString()));
                    }
                    else
                    {
                        this.tvwUserPermission.Nodes.Add(treeNode);
                        treeNode.Checked = Convert.ToBoolean(this.EditUserPermission(intUserId, row[0].ToString()));
                    }
                    this.EditUserPermission(treeNode, intUserId);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private bool EditUserPermission(int intUserId, string strPermissionKey)
        {
            bool flag;
            try
            {
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                UserPermissionDAO userPermissionDAO = new UserPermissionDAO();
                DataSet dataSet = new DataSet();
                userPermissionDAO.employee_id = Convert.ToInt16(intUserId);
                userPermissionDAO.PermissionKey = strPermissionKey;
                dataSet = userPermissionBLL.CheckUserPermission(userPermissionDAO);
                flag = (dataSet == null || dataSet.Tables[0] == null || dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[0].Rows[0][0] == null ? false : true);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
                flag = false;
            }
            return flag;
        }

        private DataTable getUserLevelDefaultPermission()
        {
            return new DataTable();
        }

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string str = Utility.ParseText(this.txtEmployeeName.Text.Trim());
                this.gvUser.PageIndex = e.NewPageIndex;
                this.ShowAllUserInGrid(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.gvUser.SelectedDataKey["employee_id"]);
            this.ViewState["UID"] = num;
            if (this.userPermission.getUserByUserID(num) != null)
            {
                this.tvwUserPermission.Nodes.Clear();
                this.EditUserPermission(null, Convert.ToInt32(this.gvUser.SelectedDataKey["employee_id"]));
                this.tvwUserPermission.ExpandAll();
            }
        }

        private void LoadPermissionData(TreeNode tParentNode)
        {
            try
            {
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                DataSet dataSet = new DataSet();
                dataSet = (tParentNode != null ? userPermissionBLL.getUserPermission(tParentNode.Value.ToString()) : userPermissionBLL.getUserPermission(""));
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    TreeNode treeNode = new TreeNode()
                    {
                        SelectAction = TreeNodeSelectAction.None,
                        Text = row[3].ToString(),
                        Value = row[0].ToString()
                    };
                    if (tParentNode != null)
                    {
                        tParentNode.ChildNodes.Add(treeNode);
                    }
                    else
                    {
                        this.tvwUserPermission.Nodes.Add(treeNode);
                    }
                    this.LoadPermissionData(treeNode);
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.msgBox.AddMessage("Menu Population Error!!", MsgBoxs.enmMessageType.Error);
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void loadUserLevelMenuPermission()
        {
            DataTable userLevelDefaultPermission = this.getUserLevelDefaultPermission();
            for (int i = 0; i < userLevelDefaultPermission.Rows.Count; i++)
            {
                string str = userLevelDefaultPermission.Rows[i]["menu_id"].ToString();
                foreach (TreeNode node in this.tvwUserPermission.Nodes)
                {
                    if (node.Value != str)
                    {
                        if (node.ChildNodes.Count <= 0)
                        {
                            continue;
                        }
                        foreach (TreeNode childNode in node.ChildNodes)
                        {
                            if (childNode.Value != str)
                            {
                                if (childNode.ChildNodes.Count <= 0)
                                {
                                    continue;
                                }
                                foreach (TreeNode treeNode in childNode.ChildNodes)
                                {
                                    if (treeNode.Value != str)
                                    {
                                        if (treeNode.ChildNodes.Count <= 0)
                                        {
                                            continue;
                                        }
                                        foreach (TreeNode childNode1 in treeNode.ChildNodes)
                                        {
                                            if (childNode1.Value != str)
                                            {
                                                continue;
                                            }
                                            childNode1.Checked = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        treeNode.Checked = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                childNode.Checked = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        node.Checked = true;
                        break;
                    }
                }
            }
            this.tvwUserPermission.ExpandAll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ShowAllUserInGrid("");
                this.LoadPermissionData(null);
                this.loadUserLevelMenuPermission();
                this.tvwUserPermission.CollapseAll();
                this.tvwUserPermission.Attributes.Add("onclick", "OnTreeClick(event)");
            }
        }

        private void SaveUserPermission(int userID)
        {
            try
            {
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                UserPermissionDAO userPermissionDAO = new UserPermissionDAO()
                {
                    employee_id = Convert.ToInt16(userID)
                };
                this.AddPermissionKey(null);
                ArrayList item = (ArrayList)this.Session["arrPermissionKey"];
                DataTable allSubform = userPermissionBLL.GetAllSubform();
                if (allSubform.Rows.Count > 0)
                {
                    userPermissionBLL.SaveUserPermision(userPermissionDAO, item, allSubform);
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void ShowAllUserInGrid(string userName)
        {
            if (this.Session["LOGIN_ID"].ToString() != "root")
            {
                DataTable allUser = this.userPermission.GetAllUser(userName);
                this.gvUser.DataSource = allUser;
                this.gvUser.DataBind();
                return;
            }
            DataTable dataTable = this.userPermission.GetAllUser(userName);
            this.gvUser.DataSource = dataTable;
            this.gvUser.DataBind();
        }


    }
}