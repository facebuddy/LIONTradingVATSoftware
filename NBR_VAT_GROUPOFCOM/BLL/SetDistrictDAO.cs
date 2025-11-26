using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetDistrictDAO
    {
        private short districtId;

        private string districtName;

        private short divisionId;

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

        public string DistrictName
        {
            get
            {
                return this.districtName;
            }
            set
            {
                this.districtName = value;
            }
        }

        public short DivisionId
        {
            get
            {
                return this.divisionId;
            }
            set
            {
                this.divisionId = value;
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

        public SetDistrictDAO()
        {
        }
    }
}