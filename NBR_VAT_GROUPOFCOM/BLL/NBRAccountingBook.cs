using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class NBRAccountingBook
    {
        public int AuditId
        {
            get;
            set;
        }

        public string AuditorComment
        {
            get;
            set;
        }

        public DateTime AuditorDate
        {
            get;
            set;
        }

        public string AuditorDesignation
        {
            get;
            set;
        }

        public string AuditorName
        {
            get;
            set;
        }

        public string AuditPart
        {
            get;
            set;
        }

        public string ChallanNo
        {
            get;
            set;
        }

        public int itemtId
        {
            get;
            set;
        }

        public string VatMonth
        {
            get;
            set;
        }

        public int VatYear
        {
            get;
            set;
        }

        public DateTime VMSEndDate
        {
            get;
            set;
        }

        public DateTime VMStartDate
        {
            get;
            set;
        }

        public NBRAccountingBook()
        {
        }
    }
}
