using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class DisposeDAO
    {
        private short rowNo;

        private string category;

        private string subCategory;

        private string item;

        private string purchaseChallanNo;

        private string saleChalanNo;

        private double currentStock;

        private double actualTotalPrice;

        private double disposeQuantity;

        private double presentUnitPrice;

        private string disposeReason;

        private short lotNo;

        private short detailId;

        private short itemId;

        private short unitId;

        private double vat;

        private short disposeReasonD;

        private short disposeReasonM;

        private short purchaseChallanId;

        private int propertyID1;

        private int propertyID2;

        private int propertyID3;

        private int propertyID4;

        private int propertyID5;

        private char purchaseType = 'L';

        private double actualPrice;

        private short userIdInsert;

        public double ActualPrice
        {
            get
            {
                return this.actualPrice;
            }
            set
            {
                this.actualPrice = value;
            }
        }

        public double ActualTotalPrice
        {
            get
            {
                return this.actualTotalPrice;
            }
            set
            {
                this.actualTotalPrice = value;
            }
        }

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

        public double CurrentStock
        {
            get
            {
                return this.currentStock;
            }
            set
            {
                this.currentStock = value;
            }
        }

        public short DetailId
        {
            get
            {
                return this.detailId;
            }
            set
            {
                this.detailId = value;
            }
        }

        public double DisposeQuantity
        {
            get
            {
                return this.disposeQuantity;
            }
            set
            {
                this.disposeQuantity = value;
            }
        }

        public string DisposeReason
        {
            get
            {
                return this.disposeReason;
            }
            set
            {
                this.disposeReason = value;
            }
        }

        public short DisposeReasonD
        {
            get
            {
                return this.disposeReasonD;
            }
            set
            {
                this.disposeReasonD = value;
            }
        }

        public short DisposeReasonM
        {
            get
            {
                return this.disposeReasonM;
            }
            set
            {
                this.disposeReasonM = value;
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

        public short ItemId
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

        public short LotNo
        {
            get
            {
                return this.lotNo;
            }
            set
            {
                this.lotNo = value;
            }
        }

        public double PresentUnitPrice
        {
            get
            {
                return this.presentUnitPrice;
            }
            set
            {
                this.presentUnitPrice = value;
            }
        }

        public short PurchaseChallanId
        {
            get
            {
                return this.purchaseChallanId;
            }
            set
            {
                this.purchaseChallanId = value;
            }
        }

        public string PurchaseChallanNo
        {
            get
            {
                return this.purchaseChallanNo;
            }
            set
            {
                this.purchaseChallanNo = value;
            }
        }

        public string Remarks
        {
            get;
            set;
        }

        public char PurchaseType
        {
            get
            {
                return this.purchaseType;
            }
            set
            {
                this.purchaseType = value;
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

        public string SaleChalanNo
        {
            get
            {
                return this.saleChalanNo;
            }
            set
            {
                this.saleChalanNo = value;
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

        public short UnitId
        {
            get
            {
                return this.unitId;
            }
            set
            {
                this.unitId = value;
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

        public double Vat
        {
            get
            {
                return this.vat;
            }
            set
            {
                this.vat = value;
            }
        }

        public int PropertyID1
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

        public int PropertyID2
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

        public int PropertyID3
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

        public int PropertyID4
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

        public int PropertyID5
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

        public decimal Vat2
        {
            get;
            set;
        }

        public DisposeDAO()
        {
        }
    }
}
