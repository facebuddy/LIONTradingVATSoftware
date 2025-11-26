using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class InstalmentSchedule
    {
        public string agreementNo
        {
            get;
            set;
        }

        public int ChallanBookID
        {
            get;
            set;
        }

        public int ChallanPageNo
        {
            get;
            set;
        }

        public decimal discountAmount
        {
            get;
            set;
        }

        public decimal discountPct
        {
            get;
            set;
        }

        public decimal downPayment
        {
            get;
            set;
        }

        public decimal downPaymentVAT
        {
            get;
            set;
        }

        public decimal installmenAmount
        {
            get;
            set;
        }

        public decimal interestAmount
        {
            get;
            set;
        }

        public decimal interestRate
        {
            get;
            set;
        }

        public int itemId
        {
            get;
            set;
        }

        public string itemType
        {
            get;
            set;
        }

        public DateTime loanFromDate
        {
            get;
            set;
        }

        public decimal loanMonth
        {
            get;
            set;
        }

        public DateTime loanToDate
        {
            get;
            set;
        }

        public decimal loanYear
        {
            get;
            set;
        }

        public int noOfInstalment
        {
            get;
            set;
        }

        public int partyId
        {
            get;
            set;
        }

        public decimal paymentWithInterest
        {
            get;
            set;
        }

        public decimal paymentWithoutInterest
        {
            get;
            set;
        }

        public decimal priceDecPrice
        {
            get;
            set;
        }

        public decimal productPrice
        {
            get;
            set;
        }

        public decimal restait
        {
            get;
            set;
        }

        public decimal restAmount
        {
            get;
            set;
        }

        public decimal restInterest
        {
            get;
            set;
        }

        public decimal restsd
        {
            get;
            set;
        }

        public decimal restvat
        {
            get;
            set;
        }

        public decimal scheduleAmount
        {
            get;
            set;
        }

        public int scheduleNo
        {
            get;
            set;
        }

        public string status
        {
            get;
            set;
        }

        public DateTime tenurePeriod
        {
            get;
            set;
        }

        public decimal TotalPrice
        {
            get;
            set;
        }

        public decimal TotalVAT
        {
            get;
            set;
        }

        public InstalmentSchedule()
        {
        }
    }
}