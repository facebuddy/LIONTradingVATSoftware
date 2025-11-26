using System;
using System.Collections;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class NatureOfApplicationDao
    {
        private NatureOfApplicationBLL natureOfApllicationBLL = new NatureOfApplicationBLL();

        private int intRowNo;

        private short nature_of_application_id;

        private int organization_id;

        private string reg_category;

        private string organization_name;

        private bool new_application;

        private bool old_application;

        private string new_bin_number;

        private string old_bin_number;

        private string branch_name;

        private bool is_deleted;

        public string Branch_name
        {
            get
            {
                return this.branch_name;
            }
            set
            {
                this.branch_name = value;
            }
        }

        public int IntRowNo
        {
            get
            {
                return this.intRowNo;
            }
            set
            {
                this.intRowNo = value;
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

        public short Nature_of_application_id
        {
            get
            {
                return this.nature_of_application_id;
            }
            set
            {
                this.nature_of_application_id = value;
            }
        }

        public bool New_application
        {
            get
            {
                return this.new_application;
            }
            set
            {
                this.new_application = value;
            }
        }

        public string New_bin_number
        {
            get
            {
                return this.new_bin_number;
            }
            set
            {
                this.new_bin_number = value;
            }
        }

        public bool Old_application
        {
            get
            {
                return this.old_application;
            }
            set
            {
                this.old_application = value;
            }
        }

        public string Old_bin_number
        {
            get
            {
                return this.old_bin_number;
            }
            set
            {
                this.old_bin_number = value;
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

        public string Organization_name
        {
            get
            {
                return this.organization_name;
            }
            set
            {
                this.organization_name = value;
            }
        }

        public string Reg_category
        {
            get
            {
                return this.reg_category;
            }
            set
            {
                this.reg_category = value;
            }
        }

        public NatureOfApplicationDao()
        {
        }

        public DataSet GetBranchTableID()
        {
            DataSet dataSet = new DataSet();
            return this.natureOfApllicationBLL.GetBranchRegTableID();
        }

        public bool SaveNatureOfApplication(ArrayList list, int org_id, bool newChk, bool oldChk, int BranchTableID)
        {
            ArrayList arrayLists = new ArrayList();
            DBUtility dBUtility = new DBUtility();
            DataSet natureOfApplicationTableID = this.natureOfApllicationBLL.GetNatureOfApplicationTableID();
            if (natureOfApplicationTableID.Tables[0].Rows.Count <= 0)
            {
                this.nature_of_application_id = 0;
            }
            else
            {
                this.nature_of_application_id = Convert.ToInt16(natureOfApplicationTableID.Tables[0].Rows[0]["nature_of_application_id"].ToString());
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (this.nature_of_application_id <= 0)
                {
                    this.nature_of_application_id = 1;
                }
                else
                {
                    this.nature_of_application_id = Convert.ToInt16(this.nature_of_application_id + 1);
                }
                NatureOfApplicationDao natureOfApplicationDao = new NatureOfApplicationDao();
                natureOfApplicationDao = (NatureOfApplicationDao)list[i];
                object obj = "INSERT INTO nature_of_application(Organization_id,nature_of_application_id,organization_name,new_application,old_application,new_bin_number,old_bin_number,branch_name,Is_deleted)";
                object[] orgId = new object[] { obj, " VALUES(", org_id, ",", this.nature_of_application_id, ",'", natureOfApplicationDao.organization_name, "',", newChk, ", ", oldChk, ", '", natureOfApplicationDao.new_bin_number, "','", natureOfApplicationDao.old_bin_number, "','", natureOfApplicationDao.branch_name, "',", this.is_deleted, ")" };
                arrayLists.Add(string.Concat(orgId));
            }
            return dBUtility.ExecuteBatchDML(arrayLists);
        }
    }
}