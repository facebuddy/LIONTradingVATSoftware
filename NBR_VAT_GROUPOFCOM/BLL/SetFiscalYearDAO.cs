using System;


namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class SetFiscalYearDAO
    {
        private short fiscalID;

        private string fiscalYear;

        private string fromDate;

        private string toDate;

        public short FiscalID
        {
            get
            {
                return this.fiscalID;
            }
            set
            {
                this.fiscalID = value;
            }
        }

        public string FiscalYear
        {
            get
            {
                return this.fiscalYear;
            }
            set
            {
                this.fiscalYear = value;
            }
        }

        public string FromDate
        {
            get
            {
                return this.fromDate;
            }
            set
            {
                this.fromDate = value;
            }
        }

        public string ToDate
        {
            get
            {
                return this.toDate;
            }
            set
            {
                this.toDate = value;
            }
        }

        public SetFiscalYearDAO()
        {
        }
    }
}

