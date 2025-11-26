using System;
using System.Runtime.CompilerServices;

namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UserLogDAO
    {
        public string ip_address
        {
            get;
            set;
        }

        public DateTime login_logout_time
        {
            get;
            set;
        }

        public string pc_name
        {
            get;
            set;
        }

        public string status
        {
            get;
            set;
        }

        public int user_id
        {
            get;
            set;
        }

        public int user_log_id
        {
            get;
            set;
        }

        public UserLogDAO()
        {
        }
    }
}

