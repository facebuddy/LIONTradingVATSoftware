using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TransPartyDAO
    {
        private decimal creditLimit;

        private string strTransPartyName;

        private string strPartyTIN;

        private string economicProcess;

        private short businessInfo;

        private short areaOfManufacturing;

        private string strPartAddress;

        private string strUltimateDesignation;

        private string strOwnerName;

        private string strPhone;

        private string strEmail;

        private string strWebAddress;

        private int userID;

        private string partyBIN;

        private short vDS;

        private short regType;

        private bool isVDS;

        private short rowNo;

        private int partyID;

        private string strnationalIdNo;

        private bool isexciseduty;

        private bool isdevelopmentsurcharge;

        private bool isinformationtechnology;

        private bool ishealthsafety;

        private bool isenvironmentsafety;

        private bool isVendor;

        private bool isCustomer;

        private string registraionType;

        private string vdsInfo;

        private string businessInformation;

        private string areaOfManufacturingInfo;

        private int organizationID;

        public short AreaOfManufacturing
        {
            get
            {
                return this.areaOfManufacturing;
            }
            set
            {
                this.areaOfManufacturing = value;
            }
        }

        public string AreaOfManufacturingInfo
        {
            get
            {
                return this.areaOfManufacturingInfo;
            }
            set
            {
                this.areaOfManufacturingInfo = value;
            }
        }

        public short BusinessInfo
        {
            get
            {
                return this.businessInfo;
            }
            set
            {
                this.businessInfo = value;
            }
        }

        public string BusinessInformation
        {
            get
            {
                return this.businessInformation;
            }
            set
            {
                this.businessInformation = value;
            }
        }

        public decimal CreditLimit
        {
            get
            {
                return this.creditLimit;
            }
            set
            {
                this.creditLimit = value;
            }
        }

        public string EconomicProcess
        {
            get
            {
                return this.economicProcess;
            }
            set
            {
                this.economicProcess = value;
            }
        }

        public string Email
        {
            get
            {
                return this.strEmail;
            }
            set
            {
                this.strEmail = value;
            }
        }

        public bool IsCustomer
        {
            get
            {
                return this.isCustomer;
            }
            set
            {
                this.isCustomer = value;
            }
        }

        public bool isDevelopmentSurcharge
        {
            get
            {
                return this.isdevelopmentsurcharge;
            }
            set
            {
                this.isdevelopmentsurcharge = value;
            }
        }

        public bool isEnvironmentSafety
        {
            get
            {
                return this.isenvironmentsafety;
            }
            set
            {
                this.isenvironmentsafety = value;
            }
        }

        public bool isExciseDuty
        {
            get
            {
                return this.isexciseduty;
            }
            set
            {
                this.isexciseduty = value;
            }
        }

        public bool isHealthSafety
        {
            get
            {
                return this.ishealthsafety;
            }
            set
            {
                this.ishealthsafety = value;
            }
        }

        public bool IsImporter
        {
            get;
            set;
        }

        public bool isInformationTechnology
        {
            get
            {
                return this.isinformationtechnology;
            }
            set
            {
                this.isinformationtechnology = value;
            }
        }

        public bool IsVDS
        {
            get
            {
                return this.isVDS;
            }
            set
            {
                this.isVDS = value;
            }
        }

        public bool IsVendor
        {
            get
            {
                return this.isVendor;
            }
            set
            {
                this.isVendor = value;
            }
        }

        public string nationalIdNo
        {
            get
            {
                return this.strnationalIdNo;
            }
            set
            {
                this.strnationalIdNo = value;
            }
        }

        public int OrganizationID
        {
            get
            {
                return this.organizationID;
            }
            set
            {
                this.organizationID = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return this.strOwnerName;
            }
            set
            {
                this.strOwnerName = value;
            }
        }

        public string PartAddress
        {
            get
            {
                return this.strPartAddress;
            }
            set
            {
                this.strPartAddress = value;
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

        public string PartyCode
        {
            get;
            set;
        }

        public int PartyID
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

        public string PartyTIN
        {
            get
            {
                return this.strPartyTIN;
            }
            set
            {
                this.strPartyTIN = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.strPhone;
            }
            set
            {
                this.strPhone = value;
            }
        }

        public string RegistraionType
        {
            get
            {
                return this.registraionType;
            }
            set
            {
                this.registraionType = value;
            }
        }

        public short RegType
        {
            get
            {
                return this.regType;
            }
            set
            {
                this.regType = value;
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

        public string TransPartyName
        {
            get
            {
                return this.strTransPartyName;
            }
            set
            {
                this.strTransPartyName = value;
            }
        }

        public string UltimateDesignation
        {
            get
            {
                return this.strUltimateDesignation;
            }
            set
            {
                this.strUltimateDesignation = value;
            }
        }

        public int upazilaID
        {
            get;
            set;
        }

        public string upazilaName
        {
            get;
            set;
        }

        public int UserID
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

        public short VDS
        {
            get
            {
                return this.vDS;
            }
            set
            {
                this.vDS = value;
            }
        }

        public string VDSBool
        {
            get;
            set;
        }

        public string VdsInfo
        {
            get
            {
                return this.vdsInfo;
            }
            set
            {
                this.vdsInfo = value;
            }
        }

        public string WebAddress
        {
            get
            {
                return this.strWebAddress;
            }
            set
            {
                this.strWebAddress = value;
            }
        }

        public TransPartyDAO()
        {
        }
    }
}