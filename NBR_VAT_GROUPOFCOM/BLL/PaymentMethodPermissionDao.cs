using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class PaymentMethodPermissionDao
    {
        public long branchId
        {
            get;
            set;
        }

        public long menuId
        {
            get;
            set;
        }

        public long organizationId
        {
            get;
            set;
        }

        public long paymentMetodId
        {
            get;
            set;
        }

        public PaymentMethodPermissionDao()
        {
        }
    }
}