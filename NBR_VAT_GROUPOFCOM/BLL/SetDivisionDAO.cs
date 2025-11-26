using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetDivisionDAO
    {
        private int intCountryId;

        private string strDivisionName;

        private string strDivisionCode;

        private int intDataSourceId;

        public int CountryId
        {
            get
            {
                return this.intCountryId;
            }
            set
            {
                this.intCountryId = value;
            }
        }

        public int DataSourceId
        {
            get
            {
                return this.intDataSourceId;
            }
            set
            {
                this.intDataSourceId = value;
            }
        }

        public string DivisionCode
        {
            get
            {
                return this.strDivisionCode;
            }
            set
            {
                this.strDivisionCode = value;
            }
        }

        public string DivisionName
        {
            get
            {
                return this.strDivisionName;
            }
            set
            {
                this.strDivisionName = value;
            }
        }

        public SetDivisionDAO()
        {
        }
    }
}