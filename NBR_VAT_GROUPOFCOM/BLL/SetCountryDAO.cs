using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetCountryDAO
    {
        private int intCountryId;

        private string strCountryName;

        private string strCountryCode;

        private string strCountryAbbr;

        private int intDataSourceId;

        public string CountryAbbr
        {
            get
            {
                return this.strCountryAbbr;
            }
            set
            {
                this.strCountryAbbr = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return this.strCountryCode;
            }
            set
            {
                this.strCountryCode = value;
            }
        }

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

        public string CountryName
        {
            get
            {
                return this.strCountryName;
            }
            set
            {
                this.strCountryName = value;
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

        public SetCountryDAO()
        {
        }
    }
}