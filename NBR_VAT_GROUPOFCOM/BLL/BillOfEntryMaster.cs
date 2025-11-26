using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class BillOfEntryMaster
    {
        private bool isNewParty;

        private short partyID;

        private string partyName;

        private string partyAddress;

        private string partyBIN;

        private string challanNO;

        private string challanDate;

        private string ultimateDestination;

        private string type;

        private short userID;

        private DateTime updateDate;

        private DateTime dateChallan;

        private long challanID;

        private string remarks;

        private string bLNo;

        private short portCode;

        private string portFrom;

        private string portTo;

        private string lCNo;

        private DateTime lCDate;

        private double lCAmount;

        private double lCValue;

        private short lCCurrency;

        private string insuranceNO;

        private double insuranceAmount;

        private DateTime shipmentdate;

        private DateTime deliverydate;

        private string releaseOrderNo;

        private DateTime releaseOrderDate;

        private int supplierId;

        private string supplierName;

        private int supplierCountry;

        private string supplierAddress;

        private DateTime taxPaymentDate;

        public string BLNo
        {
            get
            {
                return this.bLNo;
            }
            set
            {
                this.bLNo = value;
            }
        }

        public string ChallanDate
        {
            get
            {
                return this.challanDate;
            }
            set
            {
                this.challanDate = value;
            }
        }

        public long ChallanID
        {
            get
            {
                return this.challanID;
            }
            set
            {
                this.challanID = value;
            }
        }

        public string ChallanNO
        {
            get
            {
                return this.challanNO;
            }
            set
            {
                this.challanNO = value;
            }
        }

        public DateTime DateChallan
        {
            get
            {
                return this.dateChallan;
            }
            set
            {
                this.dateChallan = value;
            }
        }

        public DateTime Deliverydate
        {
            get
            {
                return this.deliverydate;
            }
            set
            {
                this.deliverydate = value;
            }
        }

        public double InsuranceAmount
        {
            get
            {
                return this.insuranceAmount;
            }
            set
            {
                this.insuranceAmount = value;
            }
        }

        public string InsuranceNO
        {
            get
            {
                return this.insuranceNO;
            }
            set
            {
                this.insuranceNO = value;
            }
        }

        public bool IsNewParty
        {
            get
            {
                return this.isNewParty;
            }
            set
            {
                this.isNewParty = value;
            }
        }

        public double LCAmount
        {
            get
            {
                return this.lCAmount;
            }
            set
            {
                this.lCAmount = value;
            }
        }

        public short LCCurrency
        {
            get
            {
                return this.lCCurrency;
            }
            set
            {
                this.lCCurrency = value;
            }
        }

        public DateTime LCDate
        {
            get
            {
                return this.lCDate;
            }
            set
            {
                this.lCDate = value;
            }
        }

        public string LCNo
        {
            get
            {
                return this.lCNo;
            }
            set
            {
                this.lCNo = value;
            }
        }

        public double LCValue
        {
            get
            {
                return this.lCValue;
            }
            set
            {
                this.lCValue = value;
            }
        }

        public string PartyAddress
        {
            get
            {
                return this.partyAddress;
            }
            set
            {
                this.partyAddress = value;
            }
        }

        public string PartyBIN
        {
            get
            {
                return this.partyBIN;
            }
            set
            {
                this.partyBIN = value;
            }
        }

        public short PartyID
        {
            get
            {
                return this.partyID;
            }
            set
            {
                this.partyID = value;
            }
        }

        public string PartyName
        {
            get
            {
                return this.partyName;
            }
            set
            {
                this.partyName = value;
            }
        }

        public short PortCode
        {
            get
            {
                return this.portCode;
            }
            set
            {
                this.portCode = value;
            }
        }

        public string PortFrom
        {
            get
            {
                return this.portFrom;
            }
            set
            {
                this.portFrom = value;
            }
        }

        public string PortTo
        {
            get
            {
                return this.portTo;
            }
            set
            {
                this.portTo = value;
            }
        }

        public DateTime ReleaseOrderDate
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

        public string Remarks
        {
            get
            {
                return this.remarks;
            }
            set
            {
                this.remarks = value;
            }
        }

        public DateTime Shipmentdate
        {
            get
            {
                return this.shipmentdate;
            }
            set
            {
                this.shipmentdate = value;
            }
        }

        public string SupplierAddress
        {
            get
            {
                return this.supplierAddress;
            }
            set
            {
                this.supplierAddress = value;
            }
        }

        public int SupplierCountry
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

        public int SupplierId
        {
            get
            {
                return this.supplierId;
            }
            set
            {
                this.supplierId = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return this.supplierName;
            }
            set
            {
                this.supplierName = value;
            }
        }

        public DateTime TaxPaymentDate
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

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string UltimateDestination
        {
            get
            {
                return this.ultimateDestination;
            }
            set
            {
                this.ultimateDestination = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return this.updateDate;
            }
            set
            {
                this.updateDate = value;
            }
        }

        public short UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public BillOfEntryMaster()
        {
        }
    }
}
