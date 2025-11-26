using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class OrgSubsidiaryUnitsBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public OrgSubsidiaryUnitsBLL()
        {
        }

        public DataTable getOrgUnitbyOrgId(short OrgId)
        {
            string str = string.Concat("SELECT * from org_subsidiary_units where Is_deleted=false and Organization_id='", OrgId, "'");
            return this.DBUtil.GetDataTable(str);
        }
    }
}

