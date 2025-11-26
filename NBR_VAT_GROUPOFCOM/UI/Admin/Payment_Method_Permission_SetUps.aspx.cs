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
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.UI.Admin
{
    public partial class Payment_Method_Permission_SetUps : Page, IRequiresSessionState
    {
        private OrgRegistrationInfoBLL organizationInfo = new OrgRegistrationInfoBLL();

        private OrgRegistrationInfoDAO organizationInfoDAO = new OrgRegistrationInfoDAO();

        private UserPermissionBLL userPermission = new UserPermissionBLL();

        private UserPermissionDAO userPermissionDAO = new UserPermissionDAO();

        private string[] menuID = new string[] { "46", "47", "48", "49", "58", "59", "140" };

        private ArrayList arrPermissionKey = new ArrayList();

        private int menuId;

    

        public Payment_Method_Permission_SetUps()
        {
        }

        private void AddPermissionKey(int orgId, int orgBranchId, TreeNode tParentNode)
        {
            try
            {
                DataSet dataSet = new DataSet();
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                UserPermissionDAO userPermissionDAO = new UserPermissionDAO();
                foreach (TreeNode node in this.tvwOrgPermission.Nodes)
                {
                    foreach (TreeNode childNode in node.ChildNodes)
                    {
                        foreach (TreeNode treeNode in childNode.ChildNodes)
                        {
                            if (!treeNode.Checked)
                            {
                                continue;
                            }
                            PaymentMethodPermissionDao paymentMethodPermissionDao = new PaymentMethodPermissionDao()
                            {
                                paymentMetodId = (long)Convert.ToInt32(treeNode.Value),
                                menuId = (long)Convert.ToInt32(treeNode.Parent.Value),
                                organizationId = (long)orgId,
                                branchId = (long)orgBranchId
                            };
                            this.arrPermissionKey.Add(paymentMethodPermissionDao);
                        }
                    }
                }
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
                this.tvwOrgPermission.Nodes.Clear();
                string str = Utility.ParseText(this.txtOrgName.Text.ToUpper().Trim());
                if (this.txtOrgName.Text.Length != 0)
                {
                    this.ShowAllOrganizationInGrid(str);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Please insert Organization Name.');", true);
                    this.txtOrgName.Focus();
                }
                this.LoadPermissionData(null);
                this.tvwOrgPermission.CollapseAll();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = string.Empty;
            if (this.gvOrg.SelectedIndex == -1)
            {
                this.msgBox.AddMessage("Organization Payment Method Permission Please select a user first..", MsgBoxs.enmMessageType.Error);
                return;
            }
            UserPermissionDAO userPermissionDAO = new UserPermissionDAO();
            int num = Convert.ToInt32(this.ViewState["OrgID"]);
            int num1 = Convert.ToInt32(this.ViewState["OrgBranchID"]);
            this.SaveOrgPermission(num, num1);
            this.tvwOrgPermission.Nodes.Clear();
            this.tvwOrgPermission.CollapseAll();
            this.LoadPermissionData(null);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Data Saved Successfully.');", true);
            this.gvOrg.SelectedIndex = -1;
        }

        private void EditOrgPermission(TreeNode tParentNode, int orgId, int orgBranchId)
        {
            try
            {
                this.userPermission = new UserPermissionBLL();
                DataSet dataSet = new DataSet();
                dataSet = (tParentNode != null ? this.userPermission.getPayMenuPermission(tParentNode.Value.ToString()) : this.userPermission.getPayMenuPermission(""));
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        TreeNode treeNode = new TreeNode()
                        {
                            SelectAction = TreeNodeSelectAction.None,
                            Text = row[3].ToString(),
                            Value = row[0].ToString()
                        };
                        if (treeNode.Value == this.menuID[1] || treeNode.Value == this.menuID[2] || treeNode.Value == this.menuID[3] || treeNode.Value == this.menuID[4] || treeNode.Value == this.menuID[5])
                        {
                            this.menuId = Convert.ToInt32(treeNode.Value);
                        }
                        if (tParentNode != null)
                        {
                            tParentNode.ChildNodes.Add(treeNode);
                            treeNode.Checked = Convert.ToBoolean(this.EditOrgPermission(orgId, orgBranchId, this.menuId, Convert.ToInt32(treeNode.Value)));
                        }
                        else
                        {
                            this.tvwOrgPermission.Nodes.Add(treeNode);
                            treeNode.Checked = Convert.ToBoolean(this.EditOrgPermission(orgId, orgBranchId, this.menuId, Convert.ToInt32(treeNode.Value)));
                        }
                        this.EditOrgPermission(treeNode, orgId, orgBranchId);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private bool EditOrgPermission(int orgId, int orgBranchId, int menuId, int paymentMehtodId)
        {
            bool flag;
            try
            {
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                DataSet dataSet = new DataSet();
                dataSet = userPermissionBLL.CheckPaymentMethodPermission(orgId, orgBranchId, menuId, paymentMehtodId);
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

        protected void gvOrg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string str = Utility.ParseText(this.txtOrgName.Text.Trim());
                this.gvOrg.PageIndex = e.NewPageIndex;
                this.ShowAllOrganizationInGrid(str);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void gvOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.gvOrg.SelectedDataKey["org_id"]);
            int num1 = Convert.ToInt32(this.gvOrg.SelectedDataKey["branch_id"]);
            this.ViewState["OrgID"] = num;
            this.ViewState["OrgBranchID"] = num1;
            this.tvwOrgPermission.Nodes.Clear();
            this.EditOrgPermission(null, Convert.ToInt32(this.gvOrg.SelectedDataKey["org_id"]), Convert.ToInt32(this.gvOrg.SelectedDataKey["branch_id"]));
            this.tvwOrgPermission.ExpandAll();
        }

        private void loadOrgNameMenuPermission()
        {
            DataTable userLevelDefaultPermission = this.getUserLevelDefaultPermission();
            for (int i = 0; i < userLevelDefaultPermission.Rows.Count; i++)
            {
                string str = userLevelDefaultPermission.Rows[i]["menu_id"].ToString();
                foreach (TreeNode node in this.tvwOrgPermission.Nodes)
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
            this.tvwOrgPermission.ExpandAll();
        }

        private void LoadPermissionData(TreeNode tParentNode)
        {
            try
            {
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                DataSet dataSet = new DataSet();
                dataSet = (tParentNode != null ? userPermissionBLL.getPayMenuPermission(tParentNode.Value.ToString()) : userPermissionBLL.getPayMenuPermission(""));
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
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
                            this.tvwOrgPermission.Nodes.Add(treeNode);
                        }
                        this.LoadPermissionData(treeNode);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ShowAllOrganizationInGrid("");
                this.LoadPermissionData(null);
                this.loadOrgNameMenuPermission();
                this.tvwOrgPermission.CollapseAll();
                this.tvwOrgPermission.Attributes.Add("onclick", "OnTreeClick(event)");
            }
        }

        private void SaveOrgPermission(int orgId, int orgBranchId)
        {
            try
            {
                UserPermissionBLL userPermissionBLL = new UserPermissionBLL();
                UserPermissionDAO userPermissionDAO = new UserPermissionDAO();
                this.AddPermissionKey(orgId, orgBranchId, null);
                userPermissionBLL.SaveOrgPaymentMethodPermision(orgId, orgBranchId, this.arrPermissionKey);
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        private void ShowAllOrganizationInGrid(string orgName)
        {
            DataTable dataTable = new DataTable();
            dataTable = this.organizationInfo.GetAllOrganizationDetail(orgName);
            this.gvOrg.DataSource = dataTable;
            this.gvOrg.DataBind();
        }
    }
}