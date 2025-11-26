using System;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrgGroupManagementDAO
    {
        public string AdminType
        {
            get;
            set;
        }

        public string BINType
        {
            get;
            set;
        }

        public int masterOrgId
        {
            get;
            set;
        }

        public string masterOrgName
        {
            get;
            set;
        }

        public int noOfUser
        {
            get;
            set;
        }

        public OrgGroupManagementDAO()
        {
        }
    }
}