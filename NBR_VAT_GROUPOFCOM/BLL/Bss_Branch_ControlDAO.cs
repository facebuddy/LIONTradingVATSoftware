using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class Bss_Branch_ControlDAO
    {
        private short bss_brnch_cont_id;

        private short organization_id;

        private short org_branch_reg_id;

        private short employee_id;

        private string employee_name;

        private string org_name;

        private string org_branch_name;

        private string remarks;

        public short BSS_brnch_cont_id
        {
            get
            {
                return this.bss_brnch_cont_id;
            }
            set
            {
                this.bss_brnch_cont_id = value;
            }
        }

        public short Employee_id
        {
            get
            {
                return this.employee_id;
            }
            set
            {
                this.employee_id = value;
            }
        }

        public string Employee_name
        {
            get
            {
                return this.employee_name;
            }
            set
            {
                this.employee_name = value;
            }
        }

        public string Org_branch_name
        {
            get
            {
                return this.org_branch_name;
            }
            set
            {
                this.org_branch_name = value;
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

        public string Org_name
        {
            get
            {
                return this.org_name;
            }
            set
            {
                this.org_name = value;
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

        public string Remarks
        {
            get
            {
                return this.remarks;
            }
            set
            {
                this.remarks = value;
            }
        }

        public Bss_Branch_ControlDAO()
        {
        }
    }
}
