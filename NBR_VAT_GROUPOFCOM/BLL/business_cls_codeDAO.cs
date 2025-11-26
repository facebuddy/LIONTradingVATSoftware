using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class business_cls_codeDAO
    {
        private int business_cls_id;

        public int Business_cls_id
        {
            get
            {
                return this.business_cls_id;
            }
            set
            {
                this.business_cls_id = value;
            }
        }

        public string com_description
        {
            get;
            set;
        }

        public string Com_description
        {
            get
            {
                return this.com_description;
            }
            set
            {
                this.com_description = value;
            }
        }

        public string hs_code
        {
            get;
            set;
        }

        public string HS_code
        {
            get
            {
                return this.hs_code;
            }
            set
            {
                this.hs_code = value;
            }
        }

        public string hs_description
        {
            get;
            set;
        }

        public string HS_description
        {
            get
            {
                return this.hs_description;
            }
            set
            {
                this.hs_description = value;
            }
        }

        public business_cls_codeDAO()
        {
        }
    }
}