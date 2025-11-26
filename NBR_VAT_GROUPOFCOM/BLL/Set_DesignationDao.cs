using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Set_DesignationDao
    {
        private string designation_name = string.Empty;

        private string designation_short_name = string.Empty;

        private bool is_deleted;

        private string date_insert = string.Empty;

        private DateTime date;

        private int organization_id;

        public DateTime Date
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

        public string Date_insert
        {
            get
            {
                return this.date_insert;
            }
            set
            {
                this.date_insert = value;
            }
        }

        public short DepartmentID
        {
            get;
            set;
        }

        public int DesgID
        {
            get;
            set;
        }

        public string Designation_name
        {
            get
            {
                return this.designation_name;
            }
            set
            {
                this.designation_name = value;
            }
        }

        public string Designation_short_name
        {
            get
            {
                return this.designation_short_name;
            }
            set
            {
                this.designation_short_name = value;
            }
        }

        public bool Is_deleted
        {
            get
            {
                return this.is_deleted;
            }
            set
            {
                this.is_deleted = value;
            }
        }

        public int Organization_id
        {
            get
            {
                return this.organization_id;
            }
            set
            {
                this.organization_id = value;
            }
        }

        public Set_DesignationDao()
        {
        }
    }
}