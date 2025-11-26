using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetRawMaterialDetailDAO
    {
        private int intMaterialSetID;

        private short rowNo;

        private int intRawMaterialID;

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

        private string rawMaterialName;

        private string strProperty1 = "";

        private string strProperty2 = "";

        private string strProperty3 = "";

        private string strProperty4 = "";

        private string strProperty5 = "";

        private string remarks;

        private bool isCompulsory;

        public string CategoryNameRaw
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

        public int CatIDRaw
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

        public bool IsCompulsory
        {
            get
            {
                return this.isCompulsory;
            }
            set
            {
                this.isCompulsory = value;
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

        public string Property1
        {
            get
            {
                return this.strProperty1;
            }
            set
            {
                this.strProperty1 = value;
            }
        }

        public string Property2
        {
            get
            {
                return this.strProperty2;
            }
            set
            {
                this.strProperty2 = value;
            }
        }

        public string Property3
        {
            get
            {
                return this.strProperty3;
            }
            set
            {
                this.strProperty3 = value;
            }
        }

        public string Property4
        {
            get
            {
                return this.strProperty4;
            }
            set
            {
                this.strProperty4 = value;
            }
        }

        public string Property5
        {
            get
            {
                return this.strProperty5;
            }
            set
            {
                this.strProperty5 = value;
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

        public int RawMaterialID
        {
            get
            {
                return this.intRawMaterialID;
            }
            set
            {
                this.intRawMaterialID = value;
            }
        }

        public string RawMaterialName
        {
            get
            {
                return this.rawMaterialName;
            }
            set
            {
                this.rawMaterialName = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this.remarks;
            }
            set
            {
                this.remarks = value;
            }
        }

        public short RowNo
        {
            get
            {
                return this.rowNo;
            }
            set
            {
                this.rowNo = value;
            }
        }

        public string SubCategoryNameRaw
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

        public int SubCatIDRaw
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

        public SetRawMaterialDetailDAO()
        {
        }
    }

}