using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class MonthClosingBalance
    {
        public int Closingid
        {
            get;
            set;
        }

        public decimal Credit_amount
        {
            get;
            set;
        }

        public decimal Debit_amount
        {
            get;
            set;
        }

        public DateTime fromdate
        {
            get;
            set;
        }

        public int Noteno
        {
            get;
            set;
        }

        public decimal Sd_amount
        {
            get;
            set;
        }

        public DateTime todate
        {
            get;
            set;
        }

        public decimal Vat_amount
        {
            get;
            set;
        }

        public MonthClosingBalance()
        {
        }
    }
}