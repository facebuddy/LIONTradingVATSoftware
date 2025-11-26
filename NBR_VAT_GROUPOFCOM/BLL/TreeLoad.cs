using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class TreeLoad
    {
        public TreeLoad()
        {
        }

        private static void LoadProblems(TreeNode tnM, TreeView objTvw)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["master_organization_id"]);
            int num1 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataSet dataSet = new DataSet();
            DBUtility dBUtility = new DBUtility();
            string str = "";
            str = (tnM == null ? " AND PARENT_ID = 0" : string.Concat(" AND PARENT_ID = ", tnM.Value));
            object[] objArray = new object[] { "SELECT CATEGORY_ID ,CATEGORY_NAME FROM ITEM_CATEGORY ic inner join org_registration_info o on o.organization_id=ic.organization_id WHERE ic.Is_deleted = false AND (ic.organization_id=", num1, " OR is_for_all_bss_unit = true) and o.master_organization_id=", num, "  /*and category_type IN ('P') */  ", str, " ORDER BY CATEGORY_NAME " };
            dataSet = dBUtility.GetDataSet(string.Concat(objArray), "Problems");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                TreeNode treeNode = new TreeNode(row[1].ToString(), row[0].ToString());
                if (tnM != null)
                {
                    tnM.ChildNodes.Add(treeNode);
                }
                else
                {
                    objTvw.Nodes.Add(treeNode);
                }
                TreeLoad.LoadProblems(treeNode, objTvw);
            }
        }

        public static void LoadProblemTree(TreeView objTvw)
        {
            objTvw.Nodes.Clear();
            TreeLoad.LoadProblems(null, objTvw);
            objTvw.CollapseAll();
        }
    }

}

