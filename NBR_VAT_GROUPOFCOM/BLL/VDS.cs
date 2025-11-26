using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class VDS
    {
        private short rowNO;

        private string category;

        private string subCategory;

        private string item;

        private double quantity;

        private string unit;

        private double unitPrice;

        private double totalPrice;

        private double totalVat;

        private double totalVDS;

        private int itemId;

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

        public double Quantity
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

        public short RowNO
        {
            get
            {
                return this.rowNO;
            }
            set
            {
                this.rowNO = value;
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

        public double TotalVat
        {
            get
            {
                return this.totalVat;
            }
            set
            {
                this.totalVat = value;
            }
        }

        public double TotalVDS
        {
            get
            {
                return this.totalVDS;
            }
            set
            {
                this.totalVDS = value;
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

        public VDS()
        {
        }
    }
}
