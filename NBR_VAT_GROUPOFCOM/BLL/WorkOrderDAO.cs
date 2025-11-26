using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class WorkOrderDAO
    {
        public DateTime EffectiveDate
        {
            get;
            set;
        }

        public int? ItemID
        {
            get;
            set;
        }

        public int OrganizationID
        {
            get;
            set;
        }

        public int OrgBranchID
        {
            get;
            set;
        }

        public int PriceID
        {
            get;
            set;
        }

        public int? PropertyID1
        {
            get;
            set;
        }

        public int? PropertyID2
        {
            get;
            set;
        }

        public int? PropertyID3
        {
            get;
            set;
        }

        public int? PropertyID4
        {
            get;
            set;
        }

        public int? PropertyID5
        {
            get;
            set;
        }

        public string TemplateNO
        {
            get;
            set;
        }

        public int TemplateYear
        {
            get;
            set;
        }

        public int? UnitID
        {
            get;
            set;
        }

        public int UserIdInsert
        {
            get;
            set;
        }

        public WorkOrderDAO()
        {
        }
    }
}