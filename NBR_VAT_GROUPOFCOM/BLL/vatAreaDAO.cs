using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class vatAreaDAO
    {
        private short areaId;

        private string areaName;

        private string areaCode;

        private short circleId;

        private string address;

        private string phoneNo;

        private short upazillaId;

        private short unionWardId;

        private bool isDeleted;

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

        public string AreaCode
        {
            get
            {
                return this.areaCode;
            }
            set
            {
                this.areaCode = value;
            }
        }

        public short AreaId
        {
            get
            {
                return this.areaId;
            }
            set
            {
                this.areaId = value;
            }
        }

        public string AreaName
        {
            get
            {
                return this.areaName;
            }
            set
            {
                this.areaName = value;
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

        public vatAreaDAO()
        {
        }
    }
}