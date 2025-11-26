using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class UserTaskLogDAO
    {
        public string ip_address
        {
            get;
            set;
        }

        public string menu_name
        {
            get;
            set;
        }

        public string page_name
        {
            get;
            set;
        }

        public string pc_name
        {
            get;
            set;
        }

        public DateTime task_date
        {
            get;
            set;
        }

        public string user_id
        {
            get;
            set;
        }

        public int user_task_id
        {
            get;
            set;
        }

        public UserTaskLogDAO()
        {
        }
    }
}