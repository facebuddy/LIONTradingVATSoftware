using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class adjustSDDAO
    {
        private string application_date;

        public string Application_date
        {
            get
            {
                return this.application_date;
            }
            set
            {
                this.application_date = value;
            }
        }

        public string export_date
        {
            get;
            set;
        }

        public string Export_date
        {
            get
            {
                return this.export_date;
            }
            set
            {
                this.export_date = value;
            }
        }

        public double refund_SD
        {
            get;
            set;
        }

        public double Refund_SD
        {
            get
            {
                return this.refund_SD;
            }
            set
            {
                this.refund_SD = value;
            }
        }

        public adjustSDDAO()
        {
        }
    }
}

