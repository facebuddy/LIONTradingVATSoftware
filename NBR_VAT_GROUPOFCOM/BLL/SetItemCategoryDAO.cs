using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetItemCategoryDAO
    {
        private int intCategoryID;

        private int mainintCategoryID;

        private int intCenterID;

        private int intParentID;

        private int intParentCenterID;

        private string strCategoryName;

        private string strDescription;

        private int intCategoryLevel;

        private int intLevelCode;

        private string strCategoryCode;

        private short intIsLeaf;

        private int intUserIdInsert;

        private int intUserIdUpdate;

        private short intIsDeleted;

        private int intUserInsertCenterID;

        private int intUserUpdateCenterID;

        private char chCategoryType = 'I';

        private int intCategoryIDCommon;

        private short synchronized;

        private DateTime dateSynchronized;

        private string synchronizeMode;

        private short dataSourceId;

        private int organization_id;

        public string CategoryCode
        {
            get
            {
                return this.strCategoryCode;
            }
            set
            {
                this.strCategoryCode = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return this.intCategoryID;
            }
            set
            {
                this.intCategoryID = value;
            }
        }

        public int CategoryIDCommon
        {
            get
            {
                return this.intCategoryIDCommon;
            }
            set
            {
                this.intCategoryIDCommon = value;
            }
        }

        public int CategoryLevel
        {
            get
            {
                return this.intCategoryLevel;
            }
            set
            {
                this.intCategoryLevel = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return this.strCategoryName;
            }
            set
            {
                this.strCategoryName = value;
            }
        }

        public char CategoryType
        {
            get
            {
                return this.chCategoryType;
            }
            set
            {
                this.chCategoryType = value;
            }
        }

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

        public short DataSourceId
        {
            get
            {
                return this.dataSourceId;
            }
            set
            {
                this.dataSourceId = value;
            }
        }

        public DateTime DateSynchronized
        {
            get
            {
                return this.dateSynchronized;
            }
            set
            {
                this.dateSynchronized = value;
            }
        }

        public string Description
        {
            get
            {
                return this.strDescription;
            }
            set
            {
                this.strDescription = value;
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

        public short IsLeaf
        {
            get
            {
                return this.intIsLeaf;
            }
            set
            {
                this.intIsLeaf = value;
            }
        }

        public int LevelCode
        {
            get
            {
                return this.intLevelCode;
            }
            set
            {
                this.intLevelCode = value;
            }
        }

        public int Organization_id
        {
            get
            {
                return this.organization_id;
            }
            set
            {
                this.organization_id = value;
            }
        }

        public int ParentCenterID
        {
            get
            {
                return this.intParentCenterID;
            }
            set
            {
                this.intParentCenterID = value;
            }
        }

        public int ParentID
        {
            get
            {
                return this.intParentID;
            }
            set
            {
                this.intParentID = value;
            }
        }

        public short Synchronized
        {
            get
            {
                return this.synchronized;
            }
            set
            {
                this.synchronized = value;
            }
        }

        public string SynchronizedMode
        {
            get
            {
                return this.synchronizeMode;
            }
            set
            {
                this.synchronizeMode = value;
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

        public int UserInsertCenterID
        {
            get
            {
                return this.intUserInsertCenterID;
            }
            set
            {
                this.intUserInsertCenterID = value;
            }
        }

        public int UserUpdateCenterID
        {
            get
            {
                return this.intUserUpdateCenterID;
            }
            set
            {
                this.intUserUpdateCenterID = value;
            }
        }

        public SetItemCategoryDAO()
        {
        }
    }
}