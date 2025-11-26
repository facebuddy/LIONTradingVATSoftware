using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class BranchAdDAO
    {
        private int org_branch_Id;

        private string branch_unit_bin;

        private string branch_reg_category;

        private double branch_turnover;

        private string branch_unit_name;

        private string org_branch_address;

        public string Branch_reg_category
        {
            get
            {
                return this.branch_reg_category;
            }
            set
            {
                this.branch_reg_category = value;
            }
        }

        public double Branch_turnover
        {
            get
            {
                return this.branch_turnover;
            }
            set
            {
                this.branch_turnover = value;
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

        public string Org_branch_address
        {
            get
            {
                return this.org_branch_address;
            }
            set
            {
                this.org_branch_address = value;
            }
        }

        public int Org_branch_Id
        {
            get
            {
                return this.org_branch_Id;
            }
            set
            {
                this.org_branch_Id = value;
            }
        }

        public BranchAdDAO()
        {
        }
    }
}
