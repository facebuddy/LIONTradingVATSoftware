using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class ItemTaxValueDAO
    {
        private int intItemId;

        private int intTaxId;

        private DateTime DateDateOfEffective;

        private double dblTaxValue;

        private string dblTaxPer;

        private double dupper;

        private double dlower;

        private bool blIsAnnx;

        private string testDate;

        private int empID;

        private bool is_last_insert;

        private bool isimported;

        private bool islocal;

        private bool isproduction;

        private bool isimportnproduction;

        private bool isbusiness;

        private bool isservice;

        private bool tranimported;

        private bool tranlocal;

        private bool transale;

        private bool trantradePrice;

        private int levelId;

        private int packetId;

        private double healthCharge;

        public double AIT
        {
            get;
            set;
        }

        public int AITId
        {
            get;
            set;
        }

        public double AT
        {
            get;
            set;
        }

        public int ATId
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public int CatgID
        {
            get;
            set;
        }

        public double CD
        {
            get;
            set;
        }

        public int CDId
        {
            get;
            set;
        }

        public DateTime DateOfEffective
        {
            get
            {
                return this.DateDateOfEffective;
            }
            set
            {
                this.DateDateOfEffective = value;
            }
        }

        public double dLower
        {
            get
            {
                return this.dlower;
            }
            set
            {
                this.dlower = value;
            }
        }

        public double dUpper
        {
            get
            {
                return this.dupper;
            }
            set
            {
                this.dupper = value;
            }
        }

        public string effectiveDate
        {
            get;
            set;
        }

        public int EmpID
        {
            get
            {
                return this.empID;
            }
            set
            {
                this.empID = value;
            }
        }

        public double Healthcharge
        {
            get
            {
                return this.healthCharge;
            }
            set
            {
                this.healthCharge = value;
            }
        }

        public bool Is_last_insert
        {
            get
            {
                return this.is_last_insert;
            }
            set
            {
                this.is_last_insert = value;
            }
        }

        public bool IsAnnx
        {
            get
            {
                return this.blIsAnnx;
            }
            set
            {
                this.blIsAnnx = value;
            }
        }

        public bool IsBusiness
        {
            get
            {
                return this.isbusiness;
            }
            set
            {
                this.isbusiness = value;
            }
        }

        public bool IsExempted
        {
            get;
            set;
        }

        public bool IsfxdCD
        {
            get;
            set;
        }

        public bool IsImported
        {
            get
            {
                return this.isimported;
            }
            set
            {
                this.isimported = value;
            }
        }

        public bool IsImportnproduction
        {
            get
            {
                return this.isimportnproduction;
            }
            set
            {
                this.isimportnproduction = value;
            }
        }

        public bool IsLocal
        {
            get
            {
                return this.islocal;
            }
            set
            {
                this.islocal = value;
            }
        }

        public bool IsProduction
        {
            get
            {
                return this.isproduction;
            }
            set
            {
                this.isproduction = value;
            }
        }

        public bool IsService
        {
            get
            {
                return this.isservice;
            }
            set
            {
                this.isservice = value;
            }
        }

        public bool IszeroRate
        {
            get;
            set;
        }

        public string Item
        {
            get;
            set;
        }

        public int ItemID
        {
            get
            {
                return this.intItemId;
            }
            set
            {
                this.intItemId = value;
            }
        }

        public int LevelId
        {
            get
            {
                return this.levelId;
            }
            set
            {
                this.levelId = value;
            }
        }

        public int PacketId
        {
            get
            {
                return this.packetId;
            }
            set
            {
                this.packetId = value;
            }
        }

        public double RD
        {
            get;
            set;
        }

        public int RDId
        {
            get;
            set;
        }

        public int RowNo
        {
            get;
            set;
        }

        public double SD
        {
            get;
            set;
        }

        public int SDId
        {
            get;
            set;
        }

        public string SubCategory
        {
            get;
            set;
        }

        public int SubCatgID
        {
            get;
            set;
        }

        public int TaxID
        {
            get
            {
                return this.intTaxId;
            }
            set
            {
                this.intTaxId = value;
            }
        }

        public string TaxPer
        {
            get
            {
                return this.dblTaxPer;
            }
            set
            {
                this.dblTaxPer = value;
            }
        }

        public double TaxValue
        {
            get
            {
                return this.dblTaxValue;
            }
            set
            {
                this.dblTaxValue = value;
            }
        }

        public string TestDate
        {
            get
            {
                return this.testDate;
            }
            set
            {
                this.testDate = value;
            }
        }

        public bool TranImported
        {
            get
            {
                return this.tranimported;
            }
            set
            {
                this.tranimported = value;
            }
        }

        public bool TranLocal
        {
            get
            {
                return this.tranlocal;
            }
            set
            {
                this.tranlocal = value;
            }
        }

        public bool TranSale
        {
            get
            {
                return this.transale;
            }
            set
            {
                this.transale = value;
            }
        }

        public bool TrantradePrice
        {
            get
            {
                return this.trantradePrice;
            }
            set
            {
                this.trantradePrice = value;
            }
        }

        public string trnsType
        {
            get;
            set;
        }

        public double VAT
        {
            get;
            set;
        }

        public int VATId
        {
            get;
            set;
        }

        public ItemTaxValueDAO()
        {
        }
    }

}

