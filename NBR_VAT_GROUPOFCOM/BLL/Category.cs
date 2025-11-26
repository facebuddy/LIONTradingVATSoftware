using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Category
    {
        private int catID;

        private string catName;

        public int CatID
        {
            get
            {
                return this.catID;
            }
            set
            {
                this.catID = value;
            }
        }

        public string CatName
        {
            get
            {
                return this.catName;
            }
            set
            {
                this.catName = value;
            }
        }

        public Category()
        {
        }
    }
}