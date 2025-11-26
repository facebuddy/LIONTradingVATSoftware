using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TurnoverDetail
    {
        private int tdId;

        private int rowId;

        private int itemId;

        private char trnsType;

        private string category;

        private string subCategory;

        private string item;

        private int prop1;

        private int prop2;

        private int prop3;

        private int prop4;

        private int prop5;

        private int quantity;

        private string unit;

        private double unitPrice;

        private double totalPrice;

        private double turnoverTax;

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public string Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public int ItemId
        {
            get
            {
                return this.itemId;
            }
            set
            {
                this.itemId = value;
            }
        }

        public int Prop1
        {
            get
            {
                return this.prop1;
            }
            set
            {
                this.prop1 = value;
            }
        }

        public int Prop2
        {
            get
            {
                return this.prop2;
            }
            set
            {
                this.prop2 = value;
            }
        }

        public int Prop3
        {
            get
            {
                return this.prop3;
            }
            set
            {
                this.prop3 = value;
            }
        }

        public int Prop4
        {
            get
            {
                return this.prop4;
            }
            set
            {
                this.prop4 = value;
            }
        }

        public int Prop5
        {
            get
            {
                return this.prop5;
            }
            set
            {
                this.prop5 = value;
            }
        }

        public int Quantity
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

        public int RowId
        {
            get
            {
                return this.rowId;
            }
            set
            {
                this.rowId = value;
            }
        }

        public string SubCategory
        {
            get
            {
                return this.subCategory;
            }
            set
            {
                this.subCategory = value;
            }
        }

        public int TdId
        {
            get
            {
                return this.tdId;
            }
            set
            {
                this.tdId = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }
            set
            {
                this.totalPrice = value;
            }
        }

        public char TrnsType
        {
            get
            {
                return this.trnsType;
            }
            set
            {
                this.trnsType = value;
            }
        }

        public double TurnoverTax
        {
            get
            {
                return this.turnoverTax;
            }
            set
            {
                this.turnoverTax = value;
            }
        }

        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }

        public TurnoverDetail()
        {
        }
    }
}
