using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UserAttemptDAO
    {
        public DateTime date_attempt
        {
            get;
            set;
        }

        public string ip_address
        {
            get;
            set;
        }

        public string pc_name
        {
            get;
            set;
        }

        public string reaseon_for_attempt_failure
        {
            get;
            set;
        }

        public int user_log_attempt_id
        {
            get;
            set;
        }

        public string user_password
        {
            get;
            set;
        }

        public UserAttemptDAO()
        {
        }
    }
}