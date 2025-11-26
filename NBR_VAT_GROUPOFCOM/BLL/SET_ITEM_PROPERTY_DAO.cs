using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SET_ITEM_PROPERTY_DAO
    {
        private int intPropertyID;

        private int intPropertyTypeM;

        private int intPropertyTypeD;

        private string strPropertyName;

        private string strPropertyCode;

        private int intUserIdInsert;

        private int intUserIdUpdate;

        private short intIsDeleted;

        private static bool blIsDefaultPropertyLoad_1;

        private static bool blIsDefaultPropertyLoad_2;

        private static bool blIsDefaultPropertyLoad_3;

        private static bool blIsDefaultPropertyLoad_4;

        private static bool blIsDefaultPropertyLoad_5;

        public static bool IsDefaultPropertyLoad_1
        {
            get
            {
                return SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_1;
            }
            set
            {
                SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_1 = value;
            }
        }

        public static bool IsDefaultPropertyLoad_2
        {
            get
            {
                return SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_2;
            }
            set
            {
                SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_2 = value;
            }
        }

        public static bool IsDefaultPropertyLoad_3
        {
            get
            {
                return SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_3;
            }
            set
            {
                SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_3 = value;
            }
        }

        public static bool IsDefaultPropertyLoad_4
        {
            get
            {
                return SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_4;
            }
            set
            {
                SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_4 = value;
            }
        }

        public static bool IsDefaultPropertyLoad_5
        {
            get
            {
                return SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_5;
            }
            set
            {
                SET_ITEM_PROPERTY_DAO.blIsDefaultPropertyLoad_5 = value;
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

        public int PropertyTypeD
        {
            get
            {
                return this.intPropertyTypeM;
            }
            set
            {
                this.intPropertyTypeM = value;
            }
        }

        public int PropertyTypeM
        {
            get
            {
                return this.intPropertyTypeM;
            }
            set
            {
                this.intPropertyTypeM = value;
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

        public SET_ITEM_PROPERTY_DAO()
        {
        }
    }
}
