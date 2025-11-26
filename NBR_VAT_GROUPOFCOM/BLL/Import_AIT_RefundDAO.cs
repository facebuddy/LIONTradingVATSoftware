using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Import_AIT_RefundDAO
    {
        private short rowNo;

        private string orgName;

        private string orgAddress;

        private string orgBIN;

        private string billOfEntryNo;

        private string billOfEntryDate;

        private string supplierCountry;

        private string taxPaymentDate;

        private string advancePaymentTax;

        private string releaseOrderNo;

        private string releaseOrderDate;

        private string item;

        private string emp_id;

        private short desg_id;

        private string emp_name;

        private string emp_desig;

        public string AdvancePaymentTax
        {
            get
            {
                return this.advancePaymentTax;
            }
            set
            {
                this.advancePaymentTax = value;
            }
        }

        public string BillOfEntryDate
        {
            get
            {
                return this.billOfEntryDate;
            }
            set
            {
                this.billOfEntryDate = value;
            }
        }

        public string BillOfEntryNo
        {
            get
            {
                return this.billOfEntryNo;
            }
            set
            {
                this.billOfEntryNo = value;
            }
        }

        public short Desg_id
        {
            get
            {
                return this.desg_id;
            }
            set
            {
                this.desg_id = value;
            }
        }

        public string Emp_desig
        {
            get
            {
                return this.emp_desig;
            }
            set
            {
                this.emp_desig = value;
            }
        }

        public string Emp_id
        {
            get
            {
                return this.emp_id;
            }
            set
            {
                this.emp_id = value;
            }
        }

        public string Emp_name
        {
            get
            {
                return this.emp_name;
            }
            set
            {
                this.emp_name = value;
            }
        }

        public string Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public string OrgAddress
        {
            get
            {
                return this.orgAddress;
            }
            set
            {
                this.orgAddress = value;
            }
        }

        public string OrgBIN
        {
            get
            {
                return this.orgBIN;
            }
            set
            {
                this.orgBIN = value;
            }
        }

        public string OrgName
        {
            get
            {
                return this.orgName;
            }
            set
            {
                this.orgName = value;
            }
        }

        public string ReleaseOrderDate
        {
            get
            {
                return this.releaseOrderDate;
            }
            set
            {
                this.releaseOrderDate = value;
            }
        }

        public string ReleaseOrderNo
        {
            get
            {
                return this.releaseOrderNo;
            }
            set
            {
                this.releaseOrderNo = value;
            }
        }

        public short RowNo
        {
            get
            {
                return this.rowNo;
            }
            set
            {
                this.rowNo = value;
            }
        }

        public string SupplierCountry
        {
            get
            {
                return this.supplierCountry;
            }
            set
            {
                this.supplierCountry = value;
            }
        }

        public string TaxPaymentDate
        {
            get
            {
                return this.taxPaymentDate;
            }
            set
            {
                this.taxPaymentDate = value;
            }
        }

        public Import_AIT_RefundDAO()
        {
        }
    }
}