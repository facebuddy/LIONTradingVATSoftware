using System;





namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class BandrollIManagementMasterDAO
    {
        private string orgName;

        private string orgAddress;

        private int challan_id;

        private int providedchallan_id;

        private int organization_id;

        private string challan_no;

        private DateTime date_challan;

        private bool is_deleted;

        private DateTime date_insert;

        private DateTime date_update;

        private short user_id_insert;

        private short user_id_update;

        private string month;

        public int Challan_id
        {
            get
            {
                return this.challan_id;
            }
            set
            {
                this.challan_id = value;
            }
        }

        public string Challan_no
        {
            get
            {
                return this.challan_no;
            }
            set
            {
                this.challan_no = value;
            }
        }

        public DateTime Date_challan
        {
            get
            {
                return this.date_challan;
            }
            set
            {
                this.date_challan = value;
            }
        }

        public DateTime Date_insert
        {
            get
            {
                return this.date_insert;
            }
            set
            {
                this.date_insert = value;
            }
        }

        public DateTime Date_update
        {
            get
            {
                return this.date_update;
            }
            set
            {
                this.date_update = value;
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

        public string Month
        {
            get
            {
                return this.month;
            }
            set
            {
                this.month = value;
            }
        }

        public string OrgAddress
        {
            get
            {
                return this.orgAddress;
            }
            set
            {
                this.orgAddress = value;
            }
        }

        public int Organization_id
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

        public string OrgName
        {
            get
            {
                return this.orgName;
            }
            set
            {
                this.orgName = value;
            }
        }

        public int Providedchallan_id
        {
            get
            {
                return this.providedchallan_id;
            }
            set
            {
                this.providedchallan_id = value;
            }
        }

        public short User_id_insert
        {
            get
            {
                return this.user_id_insert;
            }
            set
            {
                this.user_id_insert = value;
            }
        }

        public short User_id_update
        {
            get
            {
                return this.user_id_update;
            }
            set
            {
                this.user_id_update = value;
            }
        }

        public BandrollIManagementMasterDAO()
        {
        }
    }
}

