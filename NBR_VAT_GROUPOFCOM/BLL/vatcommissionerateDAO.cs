using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class vatcommissionerateDAO
    {
        private short comId;

        private string comName;

        private string comCode;

        private string address;

        private string phoneNo;

        private short upazillaId;

        private short unionWardId;

        private short policeStationId;

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

        public string ComCode
        {
            get
            {
                return this.comCode;
            }
            set
            {
                this.comCode = value;
            }
        }

        public short ComId
        {
            get
            {
                return this.comId;
            }
            set
            {
                this.comId = value;
            }
        }

        public string ComName
        {
            get
            {
                return this.comName;
            }
            set
            {
                this.comName = value;
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

        public short PoliceStationId
        {
            get
            {
                return this.policeStationId;
            }
            set
            {
                this.policeStationId = value;
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

        public vatcommissionerateDAO()
        {
        }
    }
}