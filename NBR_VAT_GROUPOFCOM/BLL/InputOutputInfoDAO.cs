using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class InputOutputInfoDAO
    {
        public string InputCode
        {
            get;
            set;
        }

        public string InputDescription
        {
            get;
            set;
        }

        public decimal InputQuantity
        {
            get;
            set;
        }

        public int OrganizationId
        {
            get;
            set;
        }

        public string OutputCode
        {
            get;
            set;
        }

        public string OutputDescription
        {
            get;
            set;
        }

        public decimal SellingUnit
        {
            get;
            set;
        }

        public int UserIdInsert
        {
            get;
            set;
        }

        public InputOutputInfoDAO()
        {
        }
    }
}