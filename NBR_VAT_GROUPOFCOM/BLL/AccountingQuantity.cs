using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AccountingQuantity
    {
        private int quantity;

        public int Quantity
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

        public AccountingQuantity()
        {
        }
    }
}