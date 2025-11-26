using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class vatCircleDAO
    {
        private short circleId;

        private string circleName;

        private string circleCode;

        private short divisionId;

        private string address;

        private string phoneNo;

        private short upazillaId;

        private short unionWardId;

        private bool isDeleted;

        private short comm_id;

        private string jurisdiction;

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string CircleCode
        {
            get
            {
                return this.circleCode;
            }
            set
            {
                this.circleCode = value;
            }
        }

        public short CircleId
        {
            get
            {
                return this.circleId;
            }
            set
            {
                this.circleId = value;
            }
        }

        public string CircleName
        {
            get
            {
                return this.circleName;
            }
            set
            {
                this.circleName = value;
            }
        }

        public short Comm_id
        {
            get
            {
                return this.comm_id;
            }
            set
            {
                this.comm_id = value;
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

        public string Jurisdiction
        {
            get
            {
                return this.jurisdiction;
            }
            set
            {
                this.jurisdiction = value;
            }
        }

        public string PhoneNo
        {
            get
            {
                return this.phoneNo;
            }
            set
            {
                this.phoneNo = value;
            }
        }

        public short UnionWardId
        {
            get
            {
                return this.unionWardId;
            }
            set
            {
                this.unionWardId = value;
            }
        }

        public short UpazillaId
        {
            get
            {
                return this.upazillaId;
            }
            set
            {
                this.upazillaId = value;
            }
        }

        public vatCircleDAO()
        {
        }
    }
}