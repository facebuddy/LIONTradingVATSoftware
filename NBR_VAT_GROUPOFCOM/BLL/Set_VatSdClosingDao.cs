using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Set_VatSdClosingDao
    {
        private decimal vat_closing_balance;

        private decimal sd_closing_balance;

        private decimal adjust_amount;

        private decimal adjust_pct;

        private decimal closing_balance;

        private string remarks = string.Empty;

        private string type_closing = string.Empty;

        private bool is_deleted;

        private DateTime date_insert;

        private DateTime date_update;

        private DateTime date_closing;

        private DateTime date;

        public decimal adjustAmount
        {
            get
            {
                return this.adjust_amount;
            }
            set
            {
                this.adjust_amount = value;
            }
        }

        public decimal adjustPct
        {
            get
            {
                return this.adjust_pct;
            }
            set
            {
                this.adjust_pct = value;
            }
        }

        public decimal closingBalance
        {
            get
            {
                return this.closing_balance;
            }
            set
            {
                this.closing_balance = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public DateTime Date_closing
        {
            get
            {
                return this.date_closing;
            }
            set
            {
                this.date_closing = value;
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

        public DateTime Date_update
        {
            get
            {
                return this.date_update;
            }
            set
            {
                this.date_update = value;
            }
        }

        public bool Is_deleted
        {
            get
            {
                return this.is_deleted;
            }
            set
            {
                this.is_deleted = value;
            }
        }

        public bool IsVATSDAdjustment
        {
            get;
            set;
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

        public decimal sdClosingBalance
        {
            get
            {
                return this.sd_closing_balance;
            }
            set
            {
                this.sd_closing_balance = value;
            }
        }

        public string typeClosing
        {
            get
            {
                return this.type_closing;
            }
            set
            {
                this.type_closing = value;
            }
        }

        public decimal vatClosinBbalance
        {
            get
            {
                return this.vat_closing_balance;
            }
            set
            {
                this.vat_closing_balance = value;
            }
        }

        public int vatSdClosingId
        {
            get;
            set;
        }

        public Set_VatSdClosingDao()
        {
        }
    }
}


