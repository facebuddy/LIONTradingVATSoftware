using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class saleExportDAO
    {
        private string strChallanNo;

        public string ChallanNo
        {
            get
            {
                return this.strChallanNo;
            }
            set
            {
                this.strChallanNo = value;
            }
        }

        public string HScode
        {
            get
            {
                return this.HSCode;
            }
            set
            {
                this.HSCode = value;
            }
        }

        public string HSCode
        {
            get;
            set;
        }

        public string Item_name
        {
            get
            {
                return this.Item_Name;
            }
            set
            {
                this.Item_Name = value;
            }
        }

        public string Item_Name
        {
            get;
            set;
        }

        public double quantity
        {
            get;
            set;
        }

        public double Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public double sd
        {
            get;
            set;
        }

        public double SD
        {
            get
            {
                return this.sd;
            }
            set
            {
                this.sd = value;
            }
        }

        public double total
        {
            get;
            set;
        }

        public double Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
            }
        }

        public saleExportDAO()
        {
        }
    }
}
