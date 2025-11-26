using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class subfrom
    {
        private string Price;

        private string Vat;

        private string Sd;

        public string price
        {
            get
            {
                return this.Price;
            }
            set
            {
                this.Price = value;
            }
        }

        public string sd
        {
            get
            {
                return this.Sd;
            }
            set
            {
                this.Sd = value;
            }
        }

        public string vat
        {
            get
            {
                return this.Vat;
            }
            set
            {
                this.Vat = value;
            }
        }

        public subfrom()
        {
        }
    }
}