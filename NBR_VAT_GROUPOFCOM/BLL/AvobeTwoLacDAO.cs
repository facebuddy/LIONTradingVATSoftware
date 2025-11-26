using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class AvobeTwoLacDAO
    {
        private int rowId;

        private string dateFrom;

        private string dateTo;

        private string challanNo;

        private string trnsType;

        private string vatType;

        private string description;

        private decimal amount;

        private string date;

        private string bin;

        private string listedPersonName;

        private string listedPersonBin;

        private string mushokType;

        private string orgname;

        private string orgBin;

        private string purchase_party_name;

        private string purchase_party_address;

        private string sale_party_name;

        private string sale_party_address;

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string Bin
        {
            get
            {
                return this.bin;
            }
            set
            {
                this.bin = value;
            }
        }

        public string ChallanNo
        {
            get
            {
                return this.challanNo;
            }
            set
            {
                this.challanNo = value;
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string DateFrom
        {
            get
            {
                return this.dateFrom;
            }
            set
            {
                this.dateFrom = value;
            }
        }

        public string DateTo
        {
            get
            {
                return this.dateTo;
            }
            set
            {
                this.dateTo = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string ListedPersonBin
        {
            get
            {
                return this.listedPersonBin;
            }
            set
            {
                this.listedPersonBin = value;
            }
        }

        public string ListedPersonName
        {
            get
            {
                return this.listedPersonName;
            }
            set
            {
                this.listedPersonName = value;
            }
        }

        public string MushokType
        {
            get
            {
                return this.mushokType;
            }
            set
            {
                this.mushokType = value;
            }
        }

        public string OrgBin
        {
            get
            {
                return this.orgBin;
            }
            set
            {
                this.orgBin = value;
            }
        }

        public string Orgname
        {
            get
            {
                return this.orgname;
            }
            set
            {
                this.orgname = value;
            }
        }

        public string Purchase_party_address
        {
            get
            {
                return this.purchase_party_address;
            }
            set
            {
                this.purchase_party_address = value;
            }
        }

        public string Purchase_party_name
        {
            get
            {
                return this.purchase_party_name;
            }
            set
            {
                this.purchase_party_name = value;
            }
        }

        public int RowId
        {
            get
            {
                return this.rowId;
            }
            set
            {
                this.rowId = value;
            }
        }

        public string Sale_party_address
        {
            get
            {
                return this.sale_party_address;
            }
            set
            {
                this.sale_party_address = value;
            }
        }

        public string Sale_party_name
        {
            get
            {
                return this.sale_party_name;
            }
            set
            {
                this.sale_party_name = value;
            }
        }

        public string TrnsType
        {
            get
            {
                return this.trnsType;
            }
            set
            {
                this.trnsType = value;
            }
        }

        public string VatType
        {
            get
            {
                return this.vatType;
            }
            set
            {
                this.vatType = value;
            }
        }

        public AvobeTwoLacDAO()
        {
        }
    }
}