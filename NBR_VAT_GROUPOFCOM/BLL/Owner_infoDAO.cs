using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Owner_infoDAO
    {
        private short owner_id;

        private short organization_id;

        private string owner_name;

        private string designation;

        private string nid_no;

        private string passport_no;

        private string e_tin;

        private string share_percentage;

        private int passport_issue_contry_id;

        private string passport_issue_contry;

        public string Designation
        {
            get
            {
                return this.designation;
            }
            set
            {
                this.designation = value;
            }
        }

        public string E_tin
        {
            get
            {
                return this.e_tin;
            }
            set
            {
                this.e_tin = value;
            }
        }

        public string Nid_no
        {
            get
            {
                return this.nid_no;
            }
            set
            {
                this.nid_no = value;
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

        public short Owner_id
        {
            get
            {
                return this.owner_id;
            }
            set
            {
                this.owner_id = value;
            }
        }

        public string Owner_name
        {
            get
            {
                return this.owner_name;
            }
            set
            {
                this.owner_name = value;
            }
        }

        public string Passport_issue_contry
        {
            get
            {
                return this.passport_issue_contry;
            }
            set
            {
                this.passport_issue_contry = value;
            }
        }

        public int Passport_issue_contry_id
        {
            get
            {
                return this.passport_issue_contry_id;
            }
            set
            {
                this.passport_issue_contry_id = value;
            }
        }

        public string Passport_no
        {
            get
            {
                return this.passport_no;
            }
            set
            {
                this.passport_no = value;
            }
        }

        public string Share_percentage
        {
            get
            {
                return this.share_percentage;
            }
            set
            {
                this.share_percentage = value;
            }
        }

        public Owner_infoDAO()
        {
        }
    }
}