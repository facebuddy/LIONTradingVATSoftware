using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class BankInformationDAO
    {
        private BankInformationBLL bankInfo = new BankInformationBLL();

        private short branch_id;

        private string branch_name;

        private short bank_id;

        private short upazila_id;

        private short union_ward_id;

        public short Bank_id
        {
            get
            {
                return this.bank_id;
            }
            set
            {
                this.bank_id = value;
            }
        }

        public short Branch_id
        {
            get
            {
                return this.branch_id;
            }
            set
            {
                this.branch_id = value;
            }
        }

        public string Branch_name
        {
            get
            {
                return this.branch_name;
            }
            set
            {
                this.branch_name = value;
            }
        }

        public short Union_ward_id
        {
            get
            {
                return this.union_ward_id;
            }
            set
            {
                this.union_ward_id = value;
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

        public BankInformationDAO()
        {
        }
    }
}