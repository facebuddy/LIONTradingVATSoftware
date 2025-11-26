using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class FinishProductReceiveFromSelfProductionDAO
    {
        private short rowNO;

        private string itemName;

        private string categoryName;

        private string subCategoryName;

        private int itemID;

        private short propertyID1;

        private short propertyID2;

        private short propertyID3;

        private short propertyID4;

        private short propertyID5;

        private string unitName;

        private short unitID;

        private double quantity;

        private string remark;

        private short userID;

        private char status;

        private double saleUnitPrice;

        private double saleVatablePrice;

        private double saleVat;

        private double saleSD;

        private int spReturn;

        private long detailID;

        public string CategoryName
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

        public long DetailID
        {
            get
            {
                return this.detailID;
            }
            set
            {
                this.detailID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return this.itemID;
            }
            set
            {
                this.itemID = value;
            }
        }

        public string ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        public short PropertyID1
        {
            get
            {
                return this.propertyID1;
            }
            set
            {
                this.propertyID1 = value;
            }
        }

        public short PropertyID2
        {
            get
            {
                return this.propertyID2;
            }
            set
            {
                this.propertyID2 = value;
            }
        }

        public short PropertyID3
        {
            get
            {
                return this.propertyID3;
            }
            set
            {
                this.propertyID3 = value;
            }
        }

        public short PropertyID4
        {
            get
            {
                return this.propertyID4;
            }
            set
            {
                this.propertyID4 = value;
            }
        }

        public short PropertyID5
        {
            get
            {
                return this.propertyID5;
            }
            set
            {
                this.propertyID5 = value;
            }
        }

        public double PurchaseUnitPrice
        {
            get;
            set;
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

        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
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

        public double SaleSD
        {
            get
            {
                return this.saleSD;
            }
            set
            {
                this.saleSD = value;
            }
        }

        public double SaleUnitPrice
        {
            get
            {
                return this.saleUnitPrice;
            }
            set
            {
                this.saleUnitPrice = value;
            }
        }

        public double SaleVat
        {
            get
            {
                return this.saleVat;
            }
            set
            {
                this.saleVat = value;
            }
        }

        public double SaleVatablePrice
        {
            get
            {
                return this.saleVatablePrice;
            }
            set
            {
                this.saleVatablePrice = value;
            }
        }

        public double SDRate
        {
            get;
            set;
        }

        public int SpReturn
        {
            get
            {
                return this.spReturn;
            }
            set
            {
                this.spReturn = value;
            }
        }

        public char Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public string SubCategoryName
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

        public short UnitID
        {
            get
            {
                return this.unitID;
            }
            set
            {
                this.unitID = value;
            }
        }

        public string UnitName
        {
            get
            {
                return this.unitName;
            }
            set
            {
                this.unitName = value;
            }
        }

        public short UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public double VatRate
        {
            get;
            set;
        }

        public FinishProductReceiveFromSelfProductionDAO()
        {
        }
    }
}

