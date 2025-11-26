using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrgRegAddressDAO
    {
        private short organization_id;

        private short org_reg_address_id;

        private short org_branch_id;

        private short bank_branch_id;

        private short address_type_id;

        private char holding;

        private short upazila_id;

        private char moza_name;

        private char road;

        private short thana_id;

        private char block_area;

        private char para_moholla;

        private char village;

        private short post_code_id;

        private short district_id;

        private char road_no;

        private char email;

        private char website;

        private char fax;

        private char phone_no1;

        private char phone_no2;

        private char mobile_no1;

        private char mobile_no2;

        public short Address_type_id
        {
            get
            {
                return this.address_type_id;
            }
            set
            {
                this.address_type_id = value;
            }
        }

        public short Bank_branch_id
        {
            get
            {
                return this.bank_branch_id;
            }
            set
            {
                this.bank_branch_id = value;
            }
        }

        public char Block_area
        {
            get
            {
                return this.block_area;
            }
            set
            {
                this.block_area = value;
            }
        }

        public short District_id
        {
            get
            {
                return this.district_id;
            }
            set
            {
                this.district_id = value;
            }
        }

        public char Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public char Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }

        public char Holding
        {
            get
            {
                return this.holding;
            }
            set
            {
                this.holding = value;
            }
        }

        public char Mobile_no1
        {
            get
            {
                return this.mobile_no1;
            }
            set
            {
                this.mobile_no1 = value;
            }
        }

        public char Mobile_no2
        {
            get
            {
                return this.mobile_no2;
            }
            set
            {
                this.mobile_no2 = value;
            }
        }

        public char Moza_name
        {
            get
            {
                return this.moza_name;
            }
            set
            {
                this.moza_name = value;
            }
        }

        public short Org_branch_id
        {
            get
            {
                return this.org_branch_id;
            }
            set
            {
                this.org_branch_id = value;
            }
        }

        public short Org_reg_address_id
        {
            get
            {
                return this.org_reg_address_id;
            }
            set
            {
                this.org_reg_address_id = value;
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

        public char Para_moholla
        {
            get
            {
                return this.para_moholla;
            }
            set
            {
                this.para_moholla = value;
            }
        }

        public char Phone_no1
        {
            get
            {
                return this.phone_no1;
            }
            set
            {
                this.phone_no1 = value;
            }
        }

        public char Phone_no2
        {
            get
            {
                return this.phone_no2;
            }
            set
            {
                this.phone_no2 = value;
            }
        }

        public short Post_code_id
        {
            get
            {
                return this.post_code_id;
            }
            set
            {
                this.post_code_id = value;
            }
        }

        public char Road
        {
            get
            {
                return this.road;
            }
            set
            {
                this.road = value;
            }
        }

        public char Road_no
        {
            get
            {
                return this.road_no;
            }
            set
            {
                this.road_no = value;
            }
        }

        public short Thana_id
        {
            get
            {
                return this.thana_id;
            }
            set
            {
                this.thana_id = value;
            }
        }

        public short Upazila_id
        {
            get
            {
                return this.upazila_id;
            }
            set
            {
                this.upazila_id = value;
            }
        }

        public char Village
        {
            get
            {
                return this.village;
            }
            set
            {
                this.village = value;
            }
        }

        public char Website
        {
            get
            {
                return this.website;
            }
            set
            {
                this.website = value;
            }
        }

        public OrgRegAddressDAO()
        {
        }
    }
}