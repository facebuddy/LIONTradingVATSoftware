using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class Set_DepartmentDao
    {
        private string department_name = string.Empty;

        private string department_short_name = string.Empty;

        private bool is_deleted;

        private string date_insert = string.Empty;

        private int organization_id;

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

        public string Department_name
        {
            get
            {
                return this.department_name;
            }
            set
            {
                this.department_name = value;
            }
        }

        public string Department_short_name
        {
            get
            {
                return this.department_short_name;
            }
            set
            {
                this.department_short_name = value;
            }
        }

        public int DeptID
        {
            get;
            set;
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

        public Set_DepartmentDao()
        {
        }
    }
}
