using System;


namespace NBR_VAT_GROUPOFCOM.BLL
{


    public class AuthorizePersonInfoDAO
    {
        private string authname;

        private string authdesignation;

        private string authnid;

        private string authmobile;

        private string authemail;

        private string authpurpose;

        public string Designation
        {
            get
            {
                return this.authdesignation;
            }
            set
            {
                this.authdesignation = value;
            }
        }

        public string Email
        {
            get
            {
                return this.authemail;
            }
            set
            {
                this.authemail = value;
            }
        }

        public string Mobile
        {
            get
            {
                return this.authmobile;
            }
            set
            {
                this.authmobile = value;
            }
        }

        public string Name
        {
            get
            {
                return this.authname;
            }
            set
            {
                this.authname = value;
            }
        }

        public string NID
        {
            get
            {
                return this.authnid;
            }
            set
            {
                this.authnid = value;
            }
        }

        public string Purpose
        {
            get
            {
                return this.authpurpose;
            }
            set
            {
                this.authpurpose = value;
            }
        }

        public AuthorizePersonInfoDAO()
        {
        }
    }
}

