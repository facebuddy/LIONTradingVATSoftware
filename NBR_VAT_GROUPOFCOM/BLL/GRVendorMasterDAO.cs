using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class GRVendorMasterDAO
    {
        public DateTime Date
        {
            get;
            set;
        }

        public string GRN
        {
            get;
            set;
        }

        public long ID
        {
            get;
            set;
        }

        public int OrganizationBranchID
        {
            get;
            set;
        }

        public int OrganizationID
        {
            get;
            set;
        }

        public string PurchaseOrder
        {
            get;
            set;
        }

        public string ReceivingStore
        {
            get;
            set;
        }

        public string RegNo
        {
            get;
            set;
        }

        public int TemplateID
        {
            get;
            set;
        }

        public string TemplateNo
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public string Vendor
        {
            get;
            set;
        }

        public int VendorID
        {
            get;
            set;
        }

        public string VoucharNo
        {
            get;
            set;
        }

        public GRVendorMasterDAO()
        {
        }
    }
}