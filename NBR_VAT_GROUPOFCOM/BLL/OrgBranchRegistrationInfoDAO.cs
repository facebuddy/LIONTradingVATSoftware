using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrgBranchRegistrationInfoDAO
    {
        private DBUtility dbutil = new DBUtility();

        private OrgBranchRegistrationInfoBLL orgBranchRegbll = new OrgBranchRegistrationInfoBLL();

        private int intRowNo;

        private short org_branch_reg_id;

        private short organization_id;

        private string central_bin;

        private string branch_unit_bin;

        private string branch_unit_name;

        private double amount;

        private string amount_in_word;

        private string date_of_registration;

        private bool is_present_address;

        private bool is_permanent_address;

        private bool is_deleted;

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string Amount_in_word
        {
            get
            {
                return this.amount_in_word;
            }
            set
            {
                this.amount_in_word = value;
            }
        }

        public string Branch_unit_bin
        {
            get
            {
                return this.branch_unit_bin;
            }
            set
            {
                this.branch_unit_bin = value;
            }
        }

        public string Branch_unit_name
        {
            get
            {
                return this.branch_unit_name;
            }
            set
            {
                this.branch_unit_name = value;
            }
        }

        public string Central_bin
        {
            get
            {
                return this.central_bin;
            }
            set
            {
                this.central_bin = value;
            }
        }

        public string Date_of_registration
        {
            get
            {
                return this.date_of_registration;
            }
            set
            {
                this.date_of_registration = value;
            }
        }

        public int IntRowNo
        {
            get
            {
                return this.intRowNo;
            }
            set
            {
                this.intRowNo = value;
            }
        }

        public bool Is_deleted
        {
            get
            {
                return this.is_deleted;
            }
            set
            {
                this.is_deleted = value;
            }
        }

        public bool Is_permanent_address
        {
            get
            {
                return this.is_permanent_address;
            }
            set
            {
                this.is_permanent_address = value;
            }
        }

        public bool Is_present_address
        {
            get
            {
                return this.is_present_address;
            }
            set
            {
                this.is_present_address = value;
            }
        }

        public short Org_branch_reg_id
        {
            get
            {
                return this.org_branch_reg_id;
            }
            set
            {
                this.org_branch_reg_id = value;
            }
        }

        public short Organization_id
        {
            get
            {
                return this.organization_id;
            }
            set
            {
                this.organization_id = value;
            }
        }

        public OrgBranchRegistrationInfoDAO()
        {
        }

        public DataSet CheckUniqueKeyForBankInfo(int orgID, int bbranchID, string baccNo)
        {
            return this.orgBranchRegbll.CheckUniqueKeyForBankInfo(orgID, bbranchID, baccNo);
        }

        public bool SaveOrgRegistrationInfo()
        {
            DataSet dataSet = this.orgBranchRegbll.OrgBranchRegistrationInfoTableID();
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                this.org_branch_reg_id = 1;
            }
            else
            {
                int num = Convert.ToInt16(dataSet.Tables[0].Rows[0]["org_branch_reg_id"].ToString());
                this.org_branch_reg_id = Convert.ToInt16(num + 1);
            }
            HttpContext.Current.Session["BRANCH_INFO_ID"] = this.org_branch_reg_id.ToString();
            string str = "INSERT INTO org_branch_reg_info( org_branch_reg_id, organization_id, central_bin, branch_unit_bin,branch_unit_name, Amount,amount_in_word, date_of_registration, is_deleted) ";
            object[] orgBranchRegId = new object[] { " Values(", this.org_branch_reg_id, ", ", this.organization_id, ",'", this.central_bin, "','", this.branch_unit_bin, "','", this.branch_unit_name, "',", this.amount, ",'", this.amount_in_word, "','", DateTime.ParseExact(this.date_of_registration, "dd/MM/yyyy", null), "',", this.is_deleted, ")" };
            string str1 = string.Concat(str, string.Concat(orgBranchRegId));
            return this.orgBranchRegbll.ExecuteDMLWithOnlyQuery(str1);
        }
    }
}