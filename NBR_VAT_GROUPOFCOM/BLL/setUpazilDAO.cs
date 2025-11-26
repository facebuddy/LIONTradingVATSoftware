using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class setUpazilDAO
    {
        private short upazilaId;

        private string upazilaName;

        private short districtId;

        private bool isDeleted;

        public short DistrictId
        {
            get
            {
                return this.districtId;
            }
            set
            {
                this.districtId = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this.isDeleted;
            }
            set
            {
                this.isDeleted = value;
            }
        }

        public short UpazilaId
        {
            get
            {
                return this.upazilaId;
            }
            set
            {
                this.upazilaId = value;
            }
        }

        public string UpazilaName
        {
            get
            {
                return this.upazilaName;
            }
            set
            {
                this.upazilaName = value;
            }
        }

        public setUpazilDAO()
        {
        }
    }

}