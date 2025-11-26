using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetRawMaterialMasterDAO
    {
        private int intOrganizationID;

        private int intMaterialSetID;

        private int intFinishedGoodsID;

        private int intPropertyID1;

        private int intPropertyID2;

        private int intPropertyID3;

        private int intPropertyID4;

        private int intPropertyID5;

        private short shIsDeleted;

        private short shUserIdInsert;

        private short shUserIdUpdate;

        private int intCatID;

        private int intSubCatID;

        private string categoryName;

        private string subCategoryName;

        private string finishedGoodName;

        public string CategoryNameFin
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
            }
        }

        public int CatIDFin
        {
            get
            {
                return this.intCatID;
            }
            set
            {
                this.intCatID = value;
            }
        }

        public string FinishedGoodName
        {
            get
            {
                return this.finishedGoodName;
            }
            set
            {
                this.finishedGoodName = value;
            }
        }

        public int FinishedGoodsID
        {
            get
            {
                return this.intFinishedGoodsID;
            }
            set
            {
                this.intFinishedGoodsID = value;
            }
        }

        public short IsDeleted
        {
            get
            {
                return this.shIsDeleted;
            }
            set
            {
                this.shIsDeleted = value;
            }
        }

        public int MaterialSetID
        {
            get
            {
                return this.intMaterialSetID;
            }
            set
            {
                this.intMaterialSetID = value;
            }
        }

        public int OrganizationID
        {
            get
            {
                return this.intOrganizationID;
            }
            set
            {
                this.intOrganizationID = value;
            }
        }

        public int PropertyID1
        {
            get
            {
                return this.intPropertyID1;
            }
            set
            {
                this.intPropertyID1 = value;
            }
        }

        public int PropertyID2
        {
            get
            {
                return this.intPropertyID2;
            }
            set
            {
                this.intPropertyID2 = value;
            }
        }

        public int PropertyID3
        {
            get
            {
                return this.intPropertyID3;
            }
            set
            {
                this.intPropertyID3 = value;
            }
        }

        public int PropertyID4
        {
            get
            {
                return this.intPropertyID4;
            }
            set
            {
                this.intPropertyID4 = value;
            }
        }

        public int PropertyID5
        {
            get
            {
                return this.intPropertyID5;
            }
            set
            {
                this.intPropertyID5 = value;
            }
        }

        public string SubCategoryNameFin
        {
            get
            {
                return this.subCategoryName;
            }
            set
            {
                this.subCategoryName = value;
            }
        }

        public int SubCatIDFin
        {
            get
            {
                return this.intSubCatID;
            }
            set
            {
                this.intSubCatID = value;
            }
        }

        public short UserIdInsert
        {
            get
            {
                return this.shUserIdInsert;
            }
            set
            {
                this.shUserIdInsert = value;
            }
        }

        public short UserIdUpdate
        {
            get
            {
                return this.shUserIdUpdate;
            }
            set
            {
                this.shUserIdUpdate = value;
            }
        }

        public SetRawMaterialMasterDAO()
        {
        }
    }

}

