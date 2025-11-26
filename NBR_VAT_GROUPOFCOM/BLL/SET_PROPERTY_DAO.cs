using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SET_PROPERTY_DAO
    {
        private int intPropertyID;

        private int intCenterID;

        private string strPropertyName;

        private string strPropertyCode;

        private int intPropertyIdM;

        private int intPropertyIdD;

        private int intUserIdInsert;

        private int intUserIdUpdate;

        private short intIsDeleted;

        private int intUserInsertCenterId;

        private int intUserUpdateCenterId;

        private decimal quantity;

        public int CenterID
        {
            get
            {
                return this.intCenterID;
            }
            set
            {
                this.intCenterID = value;
            }
        }

        public short IsDeleted
        {
            get
            {
                return this.intIsDeleted;
            }
            set
            {
                this.intIsDeleted = value;
            }
        }

        public string PropertyCode
        {
            get
            {
                return this.strPropertyCode;
            }
            set
            {
                this.strPropertyCode = value;
            }
        }

        public int PropertyID
        {
            get
            {
                return this.intPropertyID;
            }
            set
            {
                this.intPropertyID = value;
            }
        }

        public int PropertyIdD
        {
            get
            {
                return this.intPropertyIdD;
            }
            set
            {
                this.intPropertyIdD = value;
            }
        }

        public int PropertyIdM
        {
            get
            {
                return this.intPropertyIdM;
            }
            set
            {
                this.intPropertyIdM = value;
            }
        }

        public string PropertyName
        {
            get
            {
                return this.strPropertyName;
            }
            set
            {
                this.strPropertyName = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public int UserIdInsert
        {
            get
            {
                return this.intUserIdInsert;
            }
            set
            {
                this.intUserIdInsert = value;
            }
        }

        public int UserIdUpdate
        {
            get
            {
                return this.intUserIdUpdate;
            }
            set
            {
                this.intUserIdUpdate = value;
            }
        }

        public int UserInsertCenterId
        {
            get
            {
                return this.intUserInsertCenterId;
            }
            set
            {
                this.intUserInsertCenterId = value;
            }
        }

        public int UserUpdateCenterId
        {
            get
            {
                return this.intUserUpdateCenterId;
            }
            set
            {
                this.intUserUpdateCenterId = value;
            }
        }

        public SET_PROPERTY_DAO()
        {
        }
    }
}