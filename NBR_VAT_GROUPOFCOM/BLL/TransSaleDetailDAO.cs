using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TransSaleDetailDAO
    {
        private int itemId;

        private string itemName;

        private string reason;

        private int reasonId;

        private int reason_m;

        private int quantity;

        private int disposeQty;

        private int unitId;

        private string unitName;

        private double actualPrice;

        private double vat;

        private int lotNo;

        private double currenttPrice;

        private int detailId;

        private int rowNo;

        private int userIdInsert;

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

        public double CurrenttPrice
        {
            get
            {
                return this.currenttPrice;
            }
            set
            {
                this.currenttPrice = value;
            }
        }

        public int DetailId
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

        public int DisposalReasonD
        {
            get
            {
                return this.reasonId;
            }
            set
            {
                this.reasonId = value;
            }
        }

        public int DisposalReasonM
        {
            get
            {
                return this.reason_m;
            }
            set
            {
                this.reason_m = value;
            }
        }

        public int DisposeQty
        {
            get
            {
                return this.disposeQty;
            }
            set
            {
                this.disposeQty = value;
            }
        }

        public int ItemID
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
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        public int LotNo
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

        public string Reason
        {
            get
            {
                return this.reason;
            }
            set
            {
                this.reason = value;
            }
        }

        public int RowNo
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

        public int UnitID
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

        public int UserIdInsert
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

        public double VAT
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

        public TransSaleDetailDAO()
        {
        }
    }
}