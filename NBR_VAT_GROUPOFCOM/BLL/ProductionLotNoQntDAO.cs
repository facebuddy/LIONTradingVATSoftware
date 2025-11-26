using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class ProductionLotNoQntDAO
    {
        private int production_issue_lot_id;

        private int production_id;

        private int lot_no;

        private decimal quantity;

        private int item_id;

        private DateTime date_insert;

        private string batch_no;

        private DateTime mfgDate;

        private DateTime expiryDate;

        public string Batch_no
        {
            get
            {
                return this.batch_no;
            }
            set
            {
                this.batch_no = value;
            }
        }

        public DateTime Date_insert
        {
            get
            {
                return this.date_insert;
            }
            set
            {
                this.date_insert = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return this.expiryDate;
            }
            set
            {
                this.expiryDate = value;
            }
        }

        public int Item_id
        {
            get
            {
                return this.item_id;
            }
            set
            {
                this.item_id = value;
            }
        }

        public int Lot_no
        {
            get
            {
                return this.lot_no;
            }
            set
            {
                this.lot_no = value;
            }
        }

        public DateTime MfgDate
        {
            get
            {
                return this.mfgDate;
            }
            set
            {
                this.mfgDate = value;
            }
        }

        public int Production_id
        {
            get
            {
                return this.production_id;
            }
            set
            {
                this.production_id = value;
            }
        }

        public int Production_issue_lot_id
        {
            get
            {
                return this.production_issue_lot_id;
            }
            set
            {
                this.production_issue_lot_id = value;
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

        public ProductionLotNoQntDAO()
        {
        }
    }
}