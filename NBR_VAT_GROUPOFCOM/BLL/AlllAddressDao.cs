using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class AlllAddressDao
    {
        private AlllAddressBLL allAddressBll = new AlllAddressBLL();

        private NatureOfApplicationBLL natureOfApllicationBLL = new NatureOfApplicationBLL();

        private int intRowNo;

        private short organization_id;

        private short address_table_id;

        private string holding;

        private string para_moholla;

        private string village;

        private short upazila_id;

        private string upazila_name;

        private string moza_Name;

        private string road;

        private short thana_id;

        private string thana_name;

        private string block_area;

        private short post_code_id;

        private string post_code;

        private short district_id;

        private string distric;

        private string road_no;

        private string email;

        private string website;

        private string fax;

        private string phone_no1;

        private string phone_no2;

        private string mobile_no1;

        private string mobile_no2;

        private bool is_present_address;

        private bool is_parmanent_address;

        private bool is_branch_address;

        private bool is_deleted;

        private bool is_vat_registration;

        private bool is_branch_registration;

        private short nature_of_application_id;

        private string organization_name;

        private bool new_application;

        private bool old_application;

        private string new_bin_number;

        private string old_bin_number;

        private string branch_name;

        public short Address_table_id
        {
            get
            {
                return this.address_table_id;
            }
            set
            {
                this.address_table_id = value;
            }
        }

        public string Block_area
        {
            get
            {
                return this.block_area;
            }
            set
            {
                this.block_area = value;
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

        public string District
        {
            get
            {
                return this.distric;
            }
            set
            {
                this.distric = value;
            }
        }

        public short District_id
        {
            get
            {
                return this.district_id;
            }
            set
            {
                this.district_id = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }

        public string Holding
        {
            get
            {
                return this.holding;
            }
            set
            {
                this.holding = value;
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

        public bool Is_branch_address
        {
            get
            {
                return this.Is_branch_address;
            }
            set
            {
                this.is_branch_address = value;
            }
        }

        public bool Is_branch_registration
        {
            get
            {
                return this.is_branch_registration;
            }
            set
            {
                this.is_branch_registration = value;
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

        public bool Is_parmanent_address
        {
            get
            {
                return this.is_parmanent_address;
            }
            set
            {
                this.is_parmanent_address = value;
            }
        }

        public bool Is_present_address
        {
            get
            {
                return this.is_present_address;
            }
            set
            {
                this.is_present_address = value;
            }
        }

        public bool Is_vat_registration
        {
            get
            {
                return this.is_vat_registration;
            }
            set
            {
                this.is_vat_registration = value;
            }
        }

        public string Mobile_no1
        {
            get
            {
                return this.mobile_no1;
            }
            set
            {
                this.mobile_no1 = value;
            }
        }

        public string Mobile_no2
        {
            get
            {
                return this.mobile_no2;
            }
            set
            {
                this.mobile_no2 = value;
            }
        }

        public string Moza_Name
        {
            get
            {
                return this.moza_Name;
            }
            set
            {
                this.moza_Name = value;
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

        public string Para_moholla
        {
            get
            {
                return this.para_moholla;
            }
            set
            {
                this.para_moholla = value;
            }
        }

        public string Phone_no1
        {
            get
            {
                return this.phone_no1;
            }
            set
            {
                this.phone_no1 = value;
            }
        }

        public string Phone_no2
        {
            get
            {
                return this.phone_no2;
            }
            set
            {
                this.phone_no2 = value;
            }
        }

        public string Post_code
        {
            get
            {
                return this.post_code;
            }
            set
            {
                this.post_code = value;
            }
        }

        public short Post_code_id
        {
            get
            {
                return this.post_code_id;
            }
            set
            {
                this.post_code_id = value;
            }
        }

        public string Road
        {
            get
            {
                return this.road;
            }
            set
            {
                this.road = value;
            }
        }

        public string Road_no
        {
            get
            {
                return this.road_no;
            }
            set
            {
                this.road_no = value;
            }
        }

        public short Thana_id
        {
            get
            {
                return this.thana_id;
            }
            set
            {
                this.thana_id = value;
            }
        }

        public string Thana_name
        {
            get
            {
                return this.thana_name;
            }
            set
            {
                this.thana_name = value;
            }
        }

        public short Upazila_id
        {
            get
            {
                return this.upazila_id;
            }
            set
            {
                this.upazila_id = value;
            }
        }

        public string Upazila_name
        {
            get
            {
                return this.upazila_name;
            }
            set
            {
                this.upazila_name = value;
            }
        }

        public string Village
        {
            get
            {
                return this.village;
            }
            set
            {
                this.village = value;
            }
        }

        public string Website
        {
            get
            {
                return this.website;
            }
            set
            {
                this.website = value;
            }
        }

        public AlllAddressDao()
        {
        }

        public void DeleteMasterData(int organID)
        {
            DBUtility dBUtility = new DBUtility();
            string str = string.Concat("delete  from org_branch_reg_info WHERE organization_id = ", organID);
            dBUtility.ExecuteDML(str);
            string str1 = string.Concat("delete  from all_address WHERE organization_id = ", organID);
            dBUtility.ExecuteDML(str1);
            string str2 = string.Concat("delete  from nature_of_application WHERE organization_id = ", organID);
            dBUtility.ExecuteDML(str2);
            string str3 = string.Concat("delete from org_bank_account WHERE organization_id = ", organID);
            dBUtility.ExecuteDML(str3);
            string str4 = string.Concat("delete from owner_type WHERE organization_id = ", organID);
            dBUtility.ExecuteDML(str4);
            string str5 = string.Concat("delete from org_registration_info WHERE organization_id = ", organID);
            dBUtility.ExecuteDML(str5);
        }

        public bool SaveAllAddress()
        {
            DataSet allAddressTableID = this.allAddressBll.GetAllAddressTableID();
            if (allAddressTableID.Tables[0].Rows.Count <= 0)
            {
                this.address_table_id = 1;
            }
            else
            {
                int num = Convert.ToInt16(allAddressTableID.Tables[0].Rows[0]["address_table_id"].ToString());
                this.address_table_id = Convert.ToInt16(num + 1);
            }
            object obj = "INSERT INTO all_address(Organization_id,address_table_id,holding,para_moholla,village,upazila_id,moza_Name,road,thana_id,block_area,post_code_id,district_id,road_no,email,website,fax,phone_no1,phone_no2,mobile_no1,mobile_no2,is_present_address,is_parmanent_address,is_branch_address,Is_deleted,is_vat_registration,is_branch_registration)";
            object[] organizationId = new object[] { obj, " VALUES(", this.organization_id, ", ", this.address_table_id, ", '", this.holding, "','", this.para_moholla, "','", this.village, "', ", this.upazila_id, ",'", this.moza_Name, "','", this.road, "',", this.thana_id, ",'", this.block_area, "',", this.post_code_id, ", ", this.district_id, ",'", this.road_no, "','", this.email, "','", this.website, "','", this.fax, "','", this.phone_no1, "','", this.phone_no2, "','", this.mobile_no1, "','", this.mobile_no2, "',", this.is_present_address, ",", this.is_parmanent_address, ",", this.is_branch_address, ", ", this.is_deleted, ", ", this.is_vat_registration, ", ", this.is_branch_registration, ")" };
            string str = string.Concat(organizationId);
            return this.allAddressBll.ExecuteDMLWithOnlyQuery(str);
        }

        public bool SaveBranchAllAddress()
        {
            DataSet allAddressTableID = this.allAddressBll.GetAllAddressTableID();
            if (allAddressTableID.Tables[0].Rows.Count <= 0)
            {
                this.address_table_id = 1;
            }
            else
            {
                int num = Convert.ToInt16(allAddressTableID.Tables[0].Rows[0]["address_table_id"].ToString());
                this.address_table_id = Convert.ToInt16(num + 1);
            }
            int num1 = 0;
            if (HttpContext.Current.Session["BRANCH_INFO_ID"] != null)
            {
                num1 = Convert.ToInt32(HttpContext.Current.Session["BRANCH_INFO_ID"].ToString());
            }
            object obj = "INSERT INTO all_address(Organization_id,org_branch_reg_id,address_table_id,holding,para_moholla,village,upazila_id,moza_Name,road,thana_id,block_area,post_code_id,district_id,road_no,email,website,fax,phone_no1,phone_no2,mobile_no1,mobile_no2,is_present_address,is_parmanent_address,is_branch_address,Is_deleted,is_vat_registration,is_branch_registration)";
            object[] organizationId = new object[] { obj, " VALUES(", this.organization_id, ", ", num1, ", ", this.address_table_id, ", '", this.holding, "','", this.para_moholla, "','", this.village, "', ", this.upazila_id, ",'", this.moza_Name, "','", this.road, "',", this.thana_id, ",'", this.block_area, "',", this.post_code_id, ", ", this.district_id, ",'", this.road_no, "','", this.email, "','", this.website, "','", this.fax, "','", this.phone_no1, "','", this.phone_no2, "','", this.mobile_no1, "','", this.mobile_no2, "',", this.is_present_address, ",", this.is_parmanent_address, ",", this.is_branch_address, ", ", this.is_deleted, ", ", this.is_vat_registration, ", ", this.is_branch_registration, ")" };
            string str = string.Concat(organizationId);
            return this.allAddressBll.ExecuteDMLWithOnlyQuery(str);
        }

        public bool SaveBranchUnitAddress(ArrayList list, int org_id, bool Is_branch, int BranchTableID)
        {
            ArrayList arrayLists = new ArrayList();
            DBUtility dBUtility = new DBUtility();
            DataSet allAddressTableID = this.allAddressBll.GetAllAddressTableID();
            if (allAddressTableID.Tables[0].Rows.Count <= 0)
            {
                this.address_table_id = 0;
            }
            else
            {
                this.address_table_id = Convert.ToInt16(allAddressTableID.Tables[0].Rows[0]["address_table_id"].ToString());
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (this.address_table_id <= 0)
                {
                    this.address_table_id = 1;
                }
                else
                {
                    this.address_table_id = Convert.ToInt16(this.address_table_id + 1);
                }
                if (BranchTableID <= 0)
                {
                    BranchTableID = 1;
                }
                else
                {
                    BranchTableID = Convert.ToInt16(BranchTableID + 1);
                }
                AlllAddressDao alllAddressDao = new AlllAddressDao();
                alllAddressDao = (AlllAddressDao)list[i];
                object obj = "INSERT INTO all_address(Organization_id,address_table_id,holding,para_moholla,village,upazila_id,moza_Name,road,thana_id,block_area,post_code_id,district_id,road_no,email,website,fax,phone_no1,phone_no2,mobile_no1,mobile_no2,is_present_address,is_parmanent_address,is_branch_address,Is_deleted,is_vat_registration,is_branch_registration,org_branch_reg_id)";
                object[] orgId = new object[] { obj, " VALUES(", org_id, ", ", this.address_table_id, ", '", alllAddressDao.holding, "','", alllAddressDao.para_moholla, "','", alllAddressDao.village, "', ", alllAddressDao.upazila_id, ",'", alllAddressDao.moza_Name, "','", alllAddressDao.road, "',", alllAddressDao.thana_id, ",'", alllAddressDao.block_area, "',", alllAddressDao.post_code_id, ", ", alllAddressDao.district_id, ",'", alllAddressDao.road_no, "','", alllAddressDao.email, "','", alllAddressDao.website, "','", alllAddressDao.fax, "','", alllAddressDao.phone_no1, "','", alllAddressDao.phone_no2, "','", alllAddressDao.mobile_no1, "','", alllAddressDao.mobile_no2, "',", this.is_present_address, ",", this.is_parmanent_address, ",", Is_branch, ", ", this.is_deleted, ",", this.is_vat_registration, ",", this.is_branch_registration, ",", BranchTableID, ")" };
                arrayLists.Add(string.Concat(orgId));
            }
            return dBUtility.ExecuteBatchDML(arrayLists);
        }

        public bool SaveNatureOfApplication(ArrayList list, int org_id, bool newChk, bool oldChk, int branchTableID)
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
                if (branchTableID <= 0)
                {
                    branchTableID = 1;
                }
                else
                {
                    branchTableID = Convert.ToInt16(branchTableID + 1);
                }
                AlllAddressDao alllAddressDao = new AlllAddressDao();
                alllAddressDao = (AlllAddressDao)list[i];
                object obj = "INSERT INTO nature_of_application(Organization_id,nature_of_application_id,organization_name,new_application,old_application,new_bin_number,old_bin_number,branch_name,Is_deleted,org_branch_reg_id)";
                object[] orgId = new object[] { obj, " VALUES(", org_id, ",", this.nature_of_application_id, ",'", alllAddressDao.Organization_name, "',", newChk, ", ", oldChk, ", '", alllAddressDao.new_bin_number, "','", alllAddressDao.old_bin_number, "','", alllAddressDao.branch_name, "',", this.is_deleted, ",", branchTableID, ")" };
                arrayLists.Add(string.Concat(orgId));
            }
            return dBUtility.ExecuteBatchDML(arrayLists);
        }

        public bool SaveOrgBranchTable(ArrayList list, int org_id, bool newChk, bool oldChk, int BranchTableID, string etin, string date)
        {
            ArrayList arrayLists = new ArrayList();
            DBUtility dBUtility = new DBUtility();
            this.natureOfApllicationBLL.GetBranchRegTableID();
            for (int i = 0; i < list.Count; i++)
            {
                if (BranchTableID <= 0)
                {
                    BranchTableID = 1;
                }
                else
                {
                    BranchTableID = Convert.ToInt16(BranchTableID + 1);
                }
                AlllAddressDao alllAddressDao = new AlllAddressDao();
                alllAddressDao = (AlllAddressDao)list[i];
                object obj = "INSERT INTO org_branch_reg_info(organization_id,org_branch_reg_id,central_bin, branch_unit_bin, branch_unit_name, is_deleted,date_of_registration,old_bin)";
                object[] orgId = new object[] { obj, " VALUES(", org_id, ",", BranchTableID, ",'", etin, "','", alllAddressDao.new_bin_number, "','", alllAddressDao.branch_name, "',", false, ",'", DateTime.ParseExact(date, "dd/MM/yyyy", null), "', '", alllAddressDao.old_bin_number, "')" };
                arrayLists.Add(string.Concat(orgId));
            }
            return dBUtility.ExecuteBatchDML(arrayLists);
        }
    }
}
