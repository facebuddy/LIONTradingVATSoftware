using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class itemBandrollDAO
    {
        private short bandrollId;

        private string bandrollType = "B";

        private string length;

        private string width;

        private string colorDesign;

        private bool isDeleted;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        private short organizationId;

        private short receivechallanId;

        public short BandrollId
        {
            get
            {
                return this.bandrollId;
            }
            set
            {
                this.bandrollId = value;
            }
        }

        public string BandrollType
        {
            get
            {
                return this.bandrollType;
            }
            set
            {
                this.bandrollType = value;
            }
        }

        public string ColorDesign
        {
            get
            {
                return this.colorDesign;
            }
            set
            {
                this.colorDesign = value;
            }
        }

        public DateTime DateInsert
        {
            get
            {
                return this.dateInsert;
            }
            set
            {
                this.dateInsert = value;
            }
        }

        public DateTime DateUpdate
        {
            get
            {
                return this.dateUpdate;
            }
            set
            {
                this.dateUpdate = value;
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

        public string Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }

        public short OrganizationId
        {
            get
            {
                return this.organizationId;
            }
            set
            {
                this.organizationId = value;
            }
        }

        public short ReceivechallanId
        {
            get
            {
                return this.receivechallanId;
            }
            set
            {
                this.receivechallanId = value;
            }
        }

        public short UserIdInsert
        {
            get
            {
                return this.userIdInsert;
            }
            set
            {
                this.userIdInsert = value;
            }
        }

        public short UserIdUpdate
        {
            get
            {
                return this.userIdUpdate;
            }
            set
            {
                this.userIdUpdate = value;
            }
        }

        public string Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public itemBandrollDAO()
        {
        }
    }
}