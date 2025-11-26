using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PriceRowItemDAO
    {
        private int priceId;

        private short rowNo;

        private short itemId;

        private short propertyId1;

        private short propertyId2;

        private short propertyId3;

        private short propertyId4;

        private short propertyId5;

        private short unitId;

        private short unitIdsec;

        private decimal quantity;

        private decimal wastageQuantity;

        private decimal unitPrice;

        private bool isDelete;

        private DateTime dateInsert;

        private DateTime dateUpdate;

        private short userIdInsert;

        private short userIdUpdate;

        private int row_no;

        private int row_no_insert;

        private decimal txtQuantityTotal;

        private decimal txtWastageParcent;

        private decimal txtChallanPrice;

        private decimal txtProductionQuantity;

        private decimal txtQuantity;

        private decimal txtChallanQuantity;

        public string ChallanUnit
        {
            get;
            set;
        }

        public DateTime DateInsert
        {
            get
            {
                return this.dateInsert;
            }
            set
            {
                this.dateInsert = value;
            }
        }

        public DateTime DateUpdate
        {
            get
            {
                return this.dateUpdate;
            }
            set
            {
                this.dateUpdate = value;
            }
        }

        public string FinishProduct
        {
            get;
            set;
        }

        public string GrossUsagesUnit
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get
            {
                return this.isDelete;
            }
            set
            {
                this.isDelete = value;
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

        public string ItemName
        {
            get;
            set;
        }

        public decimal NeatUsages
        {
            get;
            set;
        }

        public decimal NetQuantityMQMM
        {
            get;
            set;
        }

        public int PriceId
        {
            get
            {
                return this.priceId;
            }
            set
            {
                this.priceId = value;
            }
        }

        public decimal ProductQuantity
        {
            get;
            set;
        }

        public short PropertyId1
        {
            get
            {
                return this.propertyId1;
            }
            set
            {
                this.propertyId1 = value;
            }
        }

        public short PropertyId2
        {
            get
            {
                return this.propertyId2;
            }
            set
            {
                this.propertyId2 = value;
            }
        }

        public short PropertyId3
        {
            get
            {
                return this.propertyId3;
            }
            set
            {
                this.propertyId3 = value;
            }
        }

        public short PropertyId4
        {
            get
            {
                return this.propertyId4;
            }
            set
            {
                this.propertyId4 = value;
            }
        }

        public short PropertyId5
        {
            get
            {
                return this.propertyId5;
            }
            set
            {
                this.propertyId5 = value;
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

        public int Row_no
        {
            get
            {
                return this.row_no;
            }
            set
            {
                this.row_no = value;
            }
        }

        public int Row_no_insert
        {
            get
            {
                return this.row_no_insert;
            }
            set
            {
                this.row_no_insert = value;
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

        public string Set_status
        {
            get;
            set;
        }

        public string strPriceDeclaretionNo
        {
            get;
            set;
        }

        public string textremarks
        {
            get;
            set;
        }

        public string TextRemarks
        {
            get
            {
                return this.textremarks;
            }
            set
            {
                this.textremarks = value;
            }
        }

        public decimal TxtChallanPrice
        {
            get
            {
                return this.txtChallanPrice;
            }
            set
            {
                this.txtChallanPrice = value;
            }
        }

        public decimal TxtChallanQuantity
        {
            get
            {
                return this.txtChallanQuantity;
            }
            set
            {
                this.txtChallanQuantity = value;
            }
        }

        public decimal TxtProductionQuantity
        {
            get
            {
                return this.txtProductionQuantity;
            }
            set
            {
                this.txtProductionQuantity = value;
            }
        }

        public decimal TxtQuantity
        {
            get
            {
                return this.txtQuantity;
            }
            set
            {
                this.txtQuantity = value;
            }
        }

        public decimal TxtQuantityTotal
        {
            get
            {
                return this.txtQuantityTotal;
            }
            set
            {
                this.txtQuantityTotal = value;
            }
        }

        public string txtReference
        {
            get;
            set;
        }

        public string TxtReference
        {
            get
            {
                return this.txtReference;
            }
            set
            {
                this.txtReference = value;
            }
        }

        public decimal TxtWastageParcent
        {
            get
            {
                return this.txtWastageParcent;
            }
            set
            {
                this.txtWastageParcent = value;
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

        public short UnitIdSec
        {
            get
            {
                return this.unitIdsec;
            }
            set
            {
                this.unitIdsec = value;
            }
        }

        public decimal UnitPrice
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

        public decimal UsedQuantityMQMM
        {
            get;
            set;
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

        public short UserIdUpdate
        {
            get
            {
                return this.userIdUpdate;
            }
            set
            {
                this.userIdUpdate = value;
            }
        }

        public decimal WastageQuantity
        {
            get
            {
                return this.wastageQuantity;
            }
            set
            {
                this.wastageQuantity = value;
            }
        }

        public decimal WastQuantityMQMM
        {
            get;
            set;
        }

        public PriceRowItemDAO()
        {
        }
    }
}