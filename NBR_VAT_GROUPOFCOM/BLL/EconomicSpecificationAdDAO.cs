using System;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class EconomicSpecificationAdDAO
    {
        private int economicSpecific_id;

        private bool isRebatable;

        private bool isOther;

        private bool isManufacture;

        private bool isService;

        private bool isImport;

        private bool isExport;

        private string specification;

        private decimal sale_pct;

        public int EconomicSpecific_id
        {
            get
            {
                return this.economicSpecific_id;
            }
            set
            {
                this.economicSpecific_id = value;
            }
        }

        public bool IsExport
        {
            get
            {
                return this.isExport;
            }
            set
            {
                this.isExport = value;
            }
        }

        public bool IsImport
        {
            get
            {
                return this.isImport;
            }
            set
            {
                this.isImport = value;
            }
        }

        public bool IsManufacture
        {
            get
            {
                return this.isManufacture;
            }
            set
            {
                this.isManufacture = value;
            }
        }

        public bool IsOther
        {
            get
            {
                return this.isOther;
            }
            set
            {
                this.isOther = value;
            }
        }

        public bool IsRebatable
        {
            get
            {
                return this.isRebatable;
            }
            set
            {
                this.isRebatable = value;
            }
        }

        public bool IsService
        {
            get
            {
                return this.isService;
            }
            set
            {
                this.isService = value;
            }
        }

        public decimal Sale_pct
        {
            get
            {
                return this.sale_pct;
            }
            set
            {
                this.sale_pct = value;
            }
        }

        public string Specification
        {
            get
            {
                return this.specification;
            }
            set
            {
                this.specification = value;
            }
        }

        public EconomicSpecificationAdDAO()
        {
        }
    }
}
