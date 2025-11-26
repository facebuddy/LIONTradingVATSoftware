using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UserPermissionDAO
    {
        public DateTime Date_insert
        {
            get;
            set;
        }

        public DateTime Date_join
        {
            get;
            set;
        }

        public string Date_retirement
        {
            get;
            set;
        }

        private DateTime Date_update
        {
            get;
            set;
        }

        public short Department_id
        {
            get;
            set;
        }

        public short Designation_id
        {
            get;
            set;
        }

        public int employee_id
        {
            get;
            set;
        }

        public string employee_name
        {
            get;
            set;
        }

        public short Emplyee_status
        {
            get;
            set;
        }

        public bool Is_deleted
        {
            get;
            set;
        }

        public bool Is_system_user
        {
            get;
            set;
        }

        public string Login_id
        {
            get;
            set;
        }

        public string Login_password
        {
            get;
            set;
        }

        public short Organization_id
        {
            get;
            set;
        }

        public string PermissionKey
        {
            get;
            set;
        }

        public short User_level
        {
            get;
            set;
        }

        public UserPermissionDAO()
        {
        }

        public class ButtonUserDAO
        {
            public int ButtonId
            {
                get;
                set;
            }

            public bool DeleteButton
            {
                get;
                set;
            }

            public bool EditButton
            {
                get;
                set;
            }

            public short IsEnable
            {
                get;
                set;
            }

            public int MenuId
            {
                get;
                set;
            }

            public bool SaveButton
            {
                get;
                set;
            }

            public int UserId
            {
                get;
                set;
            }

            public ButtonUserDAO()
            {
            }
        }
    }
}
