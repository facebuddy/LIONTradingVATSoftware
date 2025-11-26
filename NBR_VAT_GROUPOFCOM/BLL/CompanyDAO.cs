using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CompanyDAO
    {
        private int OrganizationId;

        private string OrganizationName;

        private string AbbrName;

        private bool RegistrationType;

        private int OrgTypeM;

        private int OrgTypeD;

        private int ParentOrgID;

        private string BusinessAddress;

        private string BusinessPhone;

        private string BusinessEmail;

        private string BusinessFax;

        private string FactoryAddress;

        private string FactoryPhone;

        private string FactoryEmail;

        private string FactoryFax;

        private string HeadOfficeAddress;

        private string HeadOfficePhone;

        private string HeadOfficeEmail;

        private string HeadOfficeFax;

        private string PermanentAddress;

        private string PermanentPhone;

        private string PermanentEmail;

        private string PermanentFax;

        private string TINChairman;

        private string TINCompany;

        private string PreviousRegNo;

        private bool TCVAT;

        private bool TCTrnOvrYrly;

        private bool TCTrnOvrQrtrly;

        private bool TCTrnOvrMnthly;

        private bool TCCottageIndustry;

        private bool TCOther;

        private bool TCSupplierManufacturer;

        private bool TCSupplierTrader;

        private bool TCServiceRenderer;

        private bool TCImporter;

        private bool TCExporter;

        private string TCTradeLicenseNo;

        private string TCAuthority;

        private DateTime TCFiscalYearFrom;

        private DateTime TCFiscalYearTo;

        private string TCImportRegNo;

        private string TCExportRegNo;

        private DateTime RegtrationEffctiveDate;

        private int AreaID;

        private string ChairmanNationalID;

        private string BINNo;

        private string BusinessActivities;

        private string BusinessType;

        public bool boolRegistrationType
        {
            get
            {
                return this.RegistrationType;
            }
            set
            {
                this.RegistrationType = value;
            }
        }

        public bool boolTCCottageIndustry
        {
            get
            {
                return this.TCCottageIndustry;
            }
            set
            {
                this.TCCottageIndustry = value;
            }
        }

        public bool boolTCExporter
        {
            get
            {
                return this.TCExporter;
            }
            set
            {
                this.TCExporter = value;
            }
        }

        public bool boolTCImporter
        {
            get
            {
                return this.TCImporter;
            }
            set
            {
                this.TCImporter = value;
            }
        }

        public bool boolTCOther
        {
            get
            {
                return this.TCOther;
            }
            set
            {
                this.TCOther = value;
            }
        }

        public bool boolTCServiceRenderer
        {
            get
            {
                return this.TCServiceRenderer;
            }
            set
            {
                this.TCServiceRenderer = value;
            }
        }

        public bool boolTCSupplierManufacturer
        {
            get
            {
                return this.TCSupplierManufacturer;
            }
            set
            {
                this.TCSupplierManufacturer = value;
            }
        }

        public bool boolTCSupplierTrader
        {
            get
            {
                return this.TCSupplierTrader;
            }
            set
            {
                this.TCSupplierTrader = value;
            }
        }

        public bool boolTCTrnOvrMnthly
        {
            get
            {
                return this.TCTrnOvrMnthly;
            }
            set
            {
                this.TCTrnOvrMnthly = value;
            }
        }

        public bool boolTCTrnOvrQrtrly
        {
            get
            {
                return this.TCTrnOvrQrtrly;
            }
            set
            {
                this.TCTrnOvrQrtrly = value;
            }
        }

        public bool boolTCTrnOvrYrly
        {
            get
            {
                return this.TCTrnOvrYrly;
            }
            set
            {
                this.TCTrnOvrYrly = value;
            }
        }

        public bool boolTCVAT
        {
            get
            {
                return this.TCVAT;
            }
            set
            {
                this.TCVAT = value;
            }
        }

        public DateTime dtRegtrationEffctiveDate
        {
            get
            {
                return this.RegtrationEffctiveDate;
            }
            set
            {
                this.RegtrationEffctiveDate = value;
            }
        }

        public DateTime dtTCFiscalYearFrom
        {
            get
            {
                return this.TCFiscalYearFrom;
            }
            set
            {
                this.TCFiscalYearFrom = value;
            }
        }

        public DateTime dtTCFiscalYearTo
        {
            get
            {
                return this.TCFiscalYearTo;
            }
            set
            {
                this.TCFiscalYearTo = value;
            }
        }

        public int intAreaID
        {
            get
            {
                return this.AreaID;
            }
            set
            {
                this.AreaID = value;
            }
        }

        public int intOrganizationId
        {
            get
            {
                return this.OrganizationId;
            }
            set
            {
                this.OrganizationId = value;
            }
        }

        public int intOrgTypeD
        {
            get
            {
                return this.OrgTypeD;
            }
            set
            {
                this.OrgTypeD = value;
            }
        }

        public int intOrgTypeM
        {
            get
            {
                return this.OrgTypeM;
            }
            set
            {
                this.OrgTypeM = value;
            }
        }

        public int intParentOrgID
        {
            get
            {
                return this.ParentOrgID;
            }
            set
            {
                this.ParentOrgID = value;
            }
        }

        public string strAbbrName
        {
            get
            {
                return this.AbbrName;
            }
            set
            {
                this.AbbrName = value;
            }
        }

        public string strBINNo
        {
            get
            {
                return this.BINNo;
            }
            set
            {
                this.BINNo = value;
            }
        }

        public string strBusinessActivities
        {
            get
            {
                return this.BusinessActivities;
            }
            set
            {
                this.BusinessActivities = value;
            }
        }

        public string strBusinessAddress
        {
            get
            {
                return this.BusinessAddress;
            }
            set
            {
                this.BusinessAddress = value;
            }
        }

        public string strBusinessEmail
        {
            get
            {
                return this.BusinessEmail;
            }
            set
            {
                this.BusinessEmail = value;
            }
        }

        public string strBusinessFax
        {
            get
            {
                return this.BusinessFax;
            }
            set
            {
                this.BusinessFax = value;
            }
        }

        public string strBusinessPhone
        {
            get
            {
                return this.BusinessPhone;
            }
            set
            {
                this.BusinessPhone = value;
            }
        }

        public string strBusinessType
        {
            get
            {
                return this.BusinessType;
            }
            set
            {
                this.BusinessType = value;
            }
        }

        public string strChairmanNationalID
        {
            get
            {
                return this.ChairmanNationalID;
            }
            set
            {
                this.ChairmanNationalID = value;
            }
        }

        public string strFactoryAddress
        {
            get
            {
                return this.FactoryAddress;
            }
            set
            {
                this.FactoryAddress = value;
            }
        }

        public string strFactoryEmail
        {
            get
            {
                return this.FactoryEmail;
            }
            set
            {
                this.FactoryEmail = value;
            }
        }

        public string strFactoryFax
        {
            get
            {
                return this.FactoryFax;
            }
            set
            {
                this.FactoryFax = value;
            }
        }

        public string strFactoryPhone
        {
            get
            {
                return this.FactoryPhone;
            }
            set
            {
                this.FactoryPhone = value;
            }
        }

        public string strHeadOfficeAddress
        {
            get
            {
                return this.HeadOfficeAddress;
            }
            set
            {
                this.HeadOfficeAddress = value;
            }
        }

        public string strHeadOfficeEmail
        {
            get
            {
                return this.HeadOfficeEmail;
            }
            set
            {
                this.HeadOfficeEmail = value;
            }
        }

        public string strHeadOfficeFax
        {
            get
            {
                return this.HeadOfficeFax;
            }
            set
            {
                this.HeadOfficeFax = value;
            }
        }

        public string strHeadOfficePhone
        {
            get
            {
                return this.HeadOfficePhone;
            }
            set
            {
                this.HeadOfficePhone = value;
            }
        }

        public string strOrganizationName
        {
            get
            {
                return this.OrganizationName;
            }
            set
            {
                this.OrganizationName = value;
            }
        }

        public string strPermanentAddress
        {
            get
            {
                return this.PermanentAddress;
            }
            set
            {
                this.PermanentAddress = value;
            }
        }

        public string strPermanentEmail
        {
            get
            {
                return this.PermanentEmail;
            }
            set
            {
                this.PermanentEmail = value;
            }
        }

        public string strPermanentFax
        {
            get
            {
                return this.PermanentFax;
            }
            set
            {
                this.PermanentFax = value;
            }
        }

        public string strPermanentPhone
        {
            get
            {
                return this.PermanentPhone;
            }
            set
            {
                this.PermanentPhone = value;
            }
        }

        public string strPreviousRegNo
        {
            get
            {
                return this.PreviousRegNo;
            }
            set
            {
                this.PreviousRegNo = value;
            }
        }

        public string strTCAuthority
        {
            get
            {
                return this.TCAuthority;
            }
            set
            {
                this.TCAuthority = value;
            }
        }

        public string strTCExportRegNo
        {
            get
            {
                return this.TCExportRegNo;
            }
            set
            {
                this.TCExportRegNo = value;
            }
        }

        public string strTCImportRegNo
        {
            get
            {
                return this.TCImportRegNo;
            }
            set
            {
                this.TCImportRegNo = value;
            }
        }

        public string strTCTradeLicenseNo
        {
            get
            {
                return this.TCTradeLicenseNo;
            }
            set
            {
                this.TCTradeLicenseNo = value;
            }
        }

        public string strTINChairman
        {
            get
            {
                return this.TINChairman;
            }
            set
            {
                this.TINChairman = value;
            }
        }

        public string strTINCompany
        {
            get
            {
                return this.TINCompany;
            }
            set
            {
                this.TINCompany = value;
            }
        }

        public CompanyDAO()
        {
        }
    }
}