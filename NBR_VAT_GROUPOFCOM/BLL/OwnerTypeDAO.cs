using System;
using System.Collections;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OwnerTypeDAO
    {
        private OwnerTypeBLL ownerTypebll = new OwnerTypeBLL();

        private DBUtility DBUtil = new DBUtility();

        private int intRowNo;

        private short owner_type_table_id;

        private short organization_id;

        private string organization_name;

        private short owner_type_id;

        private string owner_type_name;

        private string designation;

        private string nid_no;

        private string start_date;

        private string end_date;

        private string passport_no;

        private string branch_name;

        private int branch_ID;

        private string passport_issue_date;

        private string director_name;

        private string share_percentage;

        private string passport_issue_contry;

        public int Branch_ID
        {
            get
            {
                return this.branch_ID;
            }
            set
            {
                this.branch_ID = value;
            }
        }

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

        public string Designation
        {
            get
            {
                return this.designation;
            }
            set
            {
                this.designation = value;
            }
        }

        public string Director_name
        {
            get
            {
                return this.director_name;
            }
            set
            {
                this.director_name = value;
            }
        }

        public string End_date
        {
            get
            {
                return this.end_date;
            }
            set
            {
                this.end_date = value;
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

        public string Nid_no
        {
            get
            {
                return this.nid_no;
            }
            set
            {
                this.nid_no = value;
            }
        }

        public short Organization_id
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

        public short Owner_type_id
        {
            get
            {
                return this.owner_type_id;
            }
            set
            {
                this.owner_type_id = value;
            }
        }

        public string Owner_type_name
        {
            get
            {
                return this.owner_type_name;
            }
            set
            {
                this.owner_type_name = value;
            }
        }

        public short Owner_type_table_id
        {
            get
            {
                return this.owner_type_table_id;
            }
            set
            {
                this.owner_type_table_id = value;
            }
        }

        public string Passport_issue_contry
        {
            get
            {
                return this.passport_issue_contry;
            }
            set
            {
                this.passport_issue_contry = value;
            }
        }

        public string Passport_issue_date
        {
            get
            {
                return this.passport_issue_date;
            }
            set
            {
                this.passport_issue_date = value;
            }
        }

        public string Passport_no
        {
            get
            {
                return this.passport_no;
            }
            set
            {
                this.passport_no = value;
            }
        }

        public string Share_percentage
        {
            get
            {
                return this.share_percentage;
            }
            set
            {
                this.share_percentage = value;
            }
        }

        public string Start_date
        {
            get
            {
                return this.start_date;
            }
            set
            {
                this.start_date = value;
            }
        }

        public OwnerTypeDAO()
        {
        }

        public DataTable GetOwnertype()
        {
            return this.ownerTypebll.GetOwnerType();
        }

        public bool SaveOwberType(ArrayList list, int org_id)
        {
            ArrayList arrayLists = new ArrayList();
            DBUtility dBUtility = new DBUtility();
            DataSet ownerTypeTableID = this.ownerTypebll.GetOwnerTypeTableID();
            if (ownerTypeTableID.Tables[0].Rows.Count <= 0)
            {
                this.owner_type_table_id = 0;
            }
            else
            {
                this.owner_type_table_id = Convert.ToInt16(ownerTypeTableID.Tables[0].Rows[0]["owner_type_table_id"].ToString());
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (this.owner_type_table_id <= 0)
                {
                    this.owner_type_table_id = 1;
                }
                else
                {
                    this.owner_type_table_id = Convert.ToInt16(this.owner_type_table_id + 1);
                }
                OwnerTypeDAO ownerTypeDAO = new OwnerTypeDAO();
                ownerTypeDAO = (OwnerTypeDAO)list[i];
                object obj = "INSERT INTO owner_type(owner_type_table_id,Organization_id, owner_type_id, designation, nid_no, start_date,end_date, passport_no, branch_name,director_name,share_percentage, passport_issue_contry,org_branch_reg_id)";
                object[] ownerTypeTableId = new object[] { obj, "  VALUES(", this.Owner_type_table_id, ", ", org_id, ", ", ownerTypeDAO.owner_type_id, ",'", ownerTypeDAO.designation, "','", ownerTypeDAO.nid_no, "','", DateTime.ParseExact(ownerTypeDAO.start_date, "dd/MM/yyyy", null), "','", DateTime.ParseExact(ownerTypeDAO.end_date, "dd/MM/yyyy", null), "','", ownerTypeDAO.passport_no, "','", ownerTypeDAO.branch_name, "','", ownerTypeDAO.director_name, "','", ownerTypeDAO.share_percentage, "','", ownerTypeDAO.passport_issue_contry, "',", ownerTypeDAO.branch_ID, ")" };
                arrayLists.Add(string.Concat(ownerTypeTableId));
            }
            return dBUtility.ExecuteBatchDML(arrayLists);
        }
    }
}