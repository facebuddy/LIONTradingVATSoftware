using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class WastemanagementMasterDAO
    {
        private int wastemngId;

        private int challan_id;

        private DateTime challan_date;

        private int transactiontyp;

        private int finished_porductId;

        private string batch_no;

        private string challan_no;

        private int factory_id;

        private int organization_id;

        public string Batch_no
        {
            get
            {
                return this.batch_no;
            }
            set
            {
                this.batch_no = value;
            }
        }

        public DateTime Challan_date
        {
            get
            {
                return this.challan_date;
            }
            set
            {
                this.challan_date = value;
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

        public int ChallanId
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

        public int Factory_id
        {
            get
            {
                return this.factory_id;
            }
            set
            {
                this.factory_id = value;
            }
        }

        public int Finished_porductId
        {
            get
            {
                return this.finished_porductId;
            }
            set
            {
                this.finished_porductId = value;
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

        public int Transactiontyp
        {
            get
            {
                return this.transactiontyp;
            }
            set
            {
                this.transactiontyp = value;
            }
        }

        public int WastemngId
        {
            get
            {
                return this.wastemngId;
            }
            set
            {
                this.wastemngId = value;
            }
        }

        public WastemanagementMasterDAO()
        {
        }
    }

}