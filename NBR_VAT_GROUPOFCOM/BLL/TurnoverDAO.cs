using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TurnoverDAO
    {
        private int TurnoverID;

        private int OrganizationID;

        private int ItemID;

        private decimal YearlyTurnover;

        private int userIDInsert;

        public decimal decYearlyTurnover
        {
            get
            {
                return this.YearlyTurnover;
            }
            set
            {
                this.YearlyTurnover = value;
            }
        }

        public int intItemID
        {
            get
            {
                return this.ItemID;
            }
            set
            {
                this.ItemID = value;
            }
        }

        public int intOrganizatioID
        {
            get
            {
                return this.OrganizationID;
            }
            set
            {
                this.OrganizationID = value;
            }
        }

        public int intTurnoverID
        {
            get
            {
                return this.TurnoverID;
            }
            set
            {
                this.TurnoverID = value;
            }
        }

        public int intUserIDInsert
        {
            get
            {
                return this.userIDInsert;
            }
            set
            {
                this.userIDInsert = value;
            }
        }

        public TurnoverDAO()
        {
        }
    }
}