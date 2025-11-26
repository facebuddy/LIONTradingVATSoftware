using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class vatDivisiojnDAO
    {
        private short divisionId;

        private string divisionName;

        private string divisionCode;

        private short comId;

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

        public string DivisionCode
        {
            get
            {
                return this.divisionCode;
            }
            set
            {
                this.divisionCode = value;
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

        public string DivisionName
        {
            get
            {
                return this.divisionName;
            }
            set
            {
                this.divisionName = value;
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

        public vatDivisiojnDAO()
        {
        }
    }
}

