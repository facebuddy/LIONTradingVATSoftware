using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrgRegistrationInfoBLL
    {
        private DBUtility DBUtil = new DBUtility();

        private DBUtility connDB = new DBUtility();

        public OrgRegistrationInfoBLL()
        {
        }

        private ArrayList AddDeailInsertAuthPersonSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int Organization_id)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                AuthorizePersonInfoDAO authorizePersonInfoDAO = new AuthorizePersonInfoDAO();
                authorizePersonInfoDAO = (AuthorizePersonInfoDAO)arrDeailDAO[i];
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('auth_person_info_id_seq')"));
                object[] organizationId = new object[] { "insert into authorize_person_info (authorize_person_info_id,organization_id,authorize_person_name, email,nid,mobile,purpose) values (", num, ",", Organization_id, ",'", authorizePersonInfoDAO.Name, "','", authorizePersonInfoDAO.Email, "','", authorizePersonInfoDAO.NID, "','", authorizePersonInfoDAO.Mobile, "','", authorizePersonInfoDAO.Purpose, "')" };
                arrDetailList.Add(string.Concat(organizationId));
            }
            return arrDetailList;
        }

        private ArrayList AddDeailInsertBranchSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int Organization_id)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                BranchAdDAO branchAdDAO = new BranchAdDAO();
                branchAdDAO = (BranchAdDAO)arrDeailDAO[i];
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('org_branch_reg_id_seq')"));
                object[] organizationId = new object[] { "insert into org_branch_reg_info(org_branch_reg_id,organization_id, branch_unit_name,org_branch_address,org_branch_category,annual_turnover,branch_unit_bin) values (", num, ",", Organization_id, ",'", branchAdDAO.Branch_unit_name, "','", branchAdDAO.Org_branch_address, "','", branchAdDAO.Branch_reg_category, "',", branchAdDAO.Branch_turnover, ",'", branchAdDAO.Branch_unit_bin, "')" };
                arrDetailList.Add(string.Concat(organizationId));
            }
            return arrDetailList;
        }

        private ArrayList AddDeailInsertBusinessSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int Organization_id)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                business_cls_codeDAO businessClsCodeDAO = new business_cls_codeDAO();
                businessClsCodeDAO = (business_cls_codeDAO)arrDeailDAO[i];
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('business_cls_id_seq')"));
                object[] comDescription = new object[] { "insert into business_cls_code(business_cls_id, com_description, hs_code, hs_description, organization_id) values (", num, ",'", businessClsCodeDAO.Com_description, "','", businessClsCodeDAO.HS_code, "','", businessClsCodeDAO.HS_description, "',", Organization_id, ")" };
                arrDetailList.Add(string.Concat(comDescription));
            }
            return arrDetailList;
        }

        private ArrayList AddDeailInsertOwnerSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int Organization_id)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                Owner_infoDAO ownerInfoDAO = new Owner_infoDAO();
                ownerInfoDAO = (Owner_infoDAO)arrDeailDAO[i];
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('owner_id_seq')"));
                object[] organizationId = new object[] { "insert into owner_info (owner_id,organization_id,owner_name, share_pct,owner_nid,owner_passport,issuing_country_id,e_tin) values (", num, ",", Organization_id, ",'", ownerInfoDAO.Owner_name, "','", ownerInfoDAO.Share_percentage, "','", ownerInfoDAO.Nid_no, "','", ownerInfoDAO.Passport_no, "',", ownerInfoDAO.Passport_issue_contry_id, ",'", ownerInfoDAO.E_tin, "')" };
                arrDetailList.Add(string.Concat(organizationId));
            }
            return arrDetailList;
        }

        private ArrayList AddDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int Organization_id)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('org_bank_account_id_seq')"));
                bankInfo _bankInfo = new bankInfo();
                _bankInfo = (bankInfo)arrDeailDAO[i];
                object[] organizationId = new object[] { "insert into org_bank_account(account_id, organization_id, bank_branch_id, account_no, account_name, bank_id) values (", num, ",", Organization_id, ",", _bankInfo.branch_id, ",'", _bankInfo.strAccountNo, "','", _bankInfo.strAccountName, "',", _bankInfo.Bank_id, ")" };
                arrDetailList.Add(string.Concat(organizationId));
            }
            return arrDetailList;
        }

        private ArrayList AddInsertCapitalMachineryInfos(ArrayList arrDetailList, ArrayList arrDeailDAOmanufact, int Organization_id)
        {
            for (int i = 0; i < arrDeailDAOmanufact.Count; i++)
            {
                capitalMachinaryInfoDAO item = (capitalMachinaryInfoDAO)arrDeailDAOmanufact[i];
                item.OrganizationId = Organization_id;
                object[] organizationId = new object[] { "insert into capital_machinary_infos(org_id, description, quantity, hs_code, value, production_capacity, physical_condition, user_id_insert) values(", item.OrganizationId, ", '", item.Description, "', ", item.Quantity, ", '", item.HScode, "', ", item.ValueinBDT, ", ", item.ProductionCapacity, ", '", item.PhysicalCondition, "', ", item.UserIdInsert, ")" };
                arrDetailList.Add(string.Concat(organizationId));
            }
            return arrDetailList;
        }

        private ArrayList AddInsertEconomicSpecification(ArrayList arrDetailList, ArrayList arrDeailDAOEcoSpecify, int Organization_id)
        {
            for (int i = 0; i < arrDeailDAOEcoSpecify.Count; i++)
            {
                int num = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('economic_specific_id_seq')"));
                EconomicSpecificationAdDAO item = (EconomicSpecificationAdDAO)arrDeailDAOEcoSpecify[i];
                int organizationId = Organization_id;
                object[] salePct = new object[] { "insert into economic_activity_specification(economic_specific_id,organization_id,sale_pct,is_rebatable,specification,is_other,is_manufacture,is_service,is_import,is_export) values(", num, ",", organizationId, ", ", item.Sale_pct, ", '", item.IsRebatable, "', '", item.Specification, "', '", item.IsOther, "', '", item.IsManufacture, "', '", item.IsService, "', '", item.IsImport, "', '", item.IsExport, "')" };
                arrDetailList.Add(string.Concat(salePct));
            }
            return arrDetailList;
        }

        private ArrayList AddInsertInputOutputs(ArrayList arrDetailList, ArrayList arrDeailDAOinputoutput, int Organization_id)
        {
            for (int i = 0; i < arrDeailDAOinputoutput.Count; i++)
            {
                InputOutputInfoDAO item = (InputOutputInfoDAO)arrDeailDAOinputoutput[i];
                item.OrganizationId = Organization_id;
                object[] organizationId = new object[] { "insert into input_output_data(org_id, output_description, output_code, selling_unit, input_description, input_code, input_quantity, user_id_insert) values(", item.OrganizationId, ", '", item.OutputDescription, "', '", item.OutputCode, "', ", item.SellingUnit, ", '", item.InputDescription, "', '", item.InputCode, "', ", item.InputQuantity, ", ", item.UserIdInsert, ")" };
                arrDetailList.Add(string.Concat(organizationId));
            }
            return arrDetailList;
        }

        public DataTable CheckIsExistBranchName(int organID, string branchName)
        {
            object[] objArray = new object[] { "select upper(branch_unit_name) branch_unit_name,organization_id,org_branch_reg_id  from org_branch_reg_info \r\n                        WHERE is_deleted = false AND organization_id = ", organID, " AND upper(branch_unit_name) = '", branchName, "' order by branch_unit_name" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public bool ExecuteDMLWithOnlyQuery(string strSql)
        {
            return this.DBUtil.ExecuteDMLWithOnlyQuery(strSql);
        }

        public DataTable FullReport(int id)
        {
            return this.DBUtil.GetDataTable("");
        }

        public DataTable FullTableOrgBranchRegistrationInfo(int id, int branchID)
        {
            object[] objArray = new object[] { "select O.organization_name,O.registration_no,B.branch_unit_name,\r\n\t\t    B.Amount,B.amount_in_word,B.date_of_registration,\r\n\t\t    O.registration_no from org_branch_reg_info AS B\r\n                    LEFT JOIN org_registration_info O\r\n                    ON B.organization_id = O.organization_id\r\n\t\tWHERE B.organization_id = ", id, " AND org_branch_reg_id = ", branchID, " AND B.is_deleted = false" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable FullTableOrgRegistrationInfo(int id)
        {
            string str = string.Concat("\r\n\r\n               SELECT ORI.registration_no,ORI.Amount,ORI.amount_in_word,APD.code_name AS registration_type,\r\n\t\t\t    CASE \r\n\t\t\t    WHEN ORI.vat_deducted_at_source = '0' THEN 'No'\r\n\t\t\t    ELSE 'Yes'\r\n\t\t\t    END Condition,\r\n\t\t\t    vat_deducted_at_source_name AS vat_deducted_at_sourceCode,\r\n\t\t\t    business_type_Name AS business_typeCode,\r\n\t\t\t    other_tax_collection_name AS other_tax_collectionCode,\r\n\t\t\t    ORI.registration_date,\r\n\t\t\t    application_nature_name  AS Application_natureCode,\r\n\t\t\t    \r\n\t\t\t    business_process_activity_name AS Economic_process_activityCode,\r\n\t\t\t    economic_process_activity_name AS business_process_activityCode\r\n\r\n\r\n                             FROM org_registration_info AS ORI\r\n\r\n\t                            LEFT JOIN  \r\n\t\t                            (SELECT code_id_m,code_id_d,code_name FROM  app_code_detail WHERE code_id_m IN \r\n\t\t                            (SELECT code_id_m FROM app_code_master WHERE code_id_m = 16) AND is_deleted = false ORDER BY code_name) APD\r\n\t\t                            ON ORI.registration_type_n = code_id_d\r\n                                 \r\n                                 WHERE ORI.organization_id = ", id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet GetAllCircle()
        {
            return this.DBUtil.GetDataSet("select circle_id,circle_name from vat_circle  WHERE is_deleted = false order by circle_name", "Circle");
        }

        public DataTable GetAllDistrictInformation()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM set_district WHERE Is_deleted = false ORDER BY district_name");
        }

        public DataTable GetAllEBIN(string bin)
        {
            string str = string.Concat("select registration_no from org_registration_info where upper(registration_no)  = '", bin, "' AND Is_deleted = false ORDER BY organization_name;");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllETIN(string tin)
        {
            string str = string.Concat("select tin_company from org_registration_info where upper(tin_company)  = '", tin, "' AND Is_deleted = false ORDER BY organization_name;");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllOrganization()
        {
            return this.DBUtil.GetDataTable("select organization_name,organization_id,business_type_name,economic_process_activity_name,registration_no \r\n                 from org_registration_info where Is_deleted = false ORDER BY organization_name;");
        }

        public DataTable GetAllOrganizationDetail(string orgName)
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = "";
            if (orgName != "")
            {
                str = string.Concat("AND Org.organization_name='", orgName, "' ");
            }
            object[] objArray = new object[] { "select Org.organization_name,org_branch.branch_unit_name,Org.organization_id as org_id,org_branch.org_branch_reg_id as branch_id from org_registration_info Org\r\n                        inner join org_branch_reg_info org_branch on Org.organization_id=org_branch.organization_id\r\n                        where Org.Is_deleted = false and Org.organization_id = ", num, "  ", str, " ORDER BY Org.organization_name;" };
            string str1 = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str1);
        }

        public DataTable GetAllOrganizationName(string organizName)
        {
            string str = string.Concat("select organization_name from org_registration_info where upper(organization_name)  = '", organizName, "' AND Is_deleted = false ORDER BY organization_name;");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllParties()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("SELECT * from trns_party where separator=1 and Is_deleted = false AND organization_id = ", num, " AND (is_vendor=true or (is_vendor=true and is_customer=true)) order by party_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetAllPostOfficeformation()
        {
            return this.DBUtil.GetDataTable("select * from set_post_code WHERE Is_deleted = false ORDER BY post_office_name");
        }

        public DataTable GetAllThanaInformation()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM set_police_station WHERE Is_deleted = false ORDER BY police_station_name");
        }

        public DataTable GetAllUpazilaInformation()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM set_upazila WHERE Is_deleted = false ORDER BY upazila_name");
        }

        public DataTable GetAuthorizePersonInfo(int orgID)
        {
            string str = string.Concat("select authorize_person_name as Name,nid ,email,mobile,purpose,'' Designation \r\n                         from authorize_person_info                                         \r\n                         where authorize_person_info.organization_id=", orgID, ";");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBankName()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  set_bank WHERE Is_deleted = false ORDER BY bank_name");
        }

        public DataTable GetBankNrachName(int id)
        {
            string str = string.Concat("SELECT * FROM  set_bank_branch WHERE bank_id = ", id, "  AND Is_deleted = false ORDER BY branch_name;");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchAddBrachRegistration(int branchid)
        {
            string str = string.Concat("SELECT AAD.para_moholla, AAD.village,PS.police_station_name,DST.district_name,UP.upazila_name,AAD.holding,AAD.road_no,\r\n\t\t        PCI.post_office_name, AAD.moza_name,AAD.phone_no1,AAD.mobile_no1, AAD.website,\r\n                AAD.fax,AAD.email\r\n  \r\n                FROM  all_address AS AAD\r\n\r\n                LEFT JOIN set_upazila AS UP\r\n                ON AAD.upazila_id = UP.upazila_id\r\n\r\n                LEFT JOIN set_police_station AS PS\r\n                ON AAD.thana_id = PS.police_station_id\r\n\r\n                LEFT JOIN set_post_code AS PCI\r\n                ON  AAD.post_code_id = PCI.post_code_id\r\n\r\n                LEFT JOIN set_district AS DST\r\n                ON  AAD.district_id = DST.district_id\r\n                WHERE AAD.org_branch_reg_id = ", branchid, " AND AAD.IS_branch_registration = true AND AAD.is_present_address = true");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchAddORGRegistration(int branchid)
        {
            string str = string.Concat("SELECT AAD.para_moholla, AAD.village,PS.police_station_name,DST.district_name,UP.upazila_name,AAD.holding,AAD.road_no,\r\n\t\t        PCI.post_office_name, AAD.moza_name,AAD.phone_no1,AAD.mobile_no1, AAD.website,\r\n                AAD.fax,AAD.email\r\n  \r\n                FROM  all_address AS AAD\r\n\r\n                LEFT JOIN set_upazila AS UP\r\n                ON AAD.upazila_id = UP.upazila_id\r\n\r\n                LEFT JOIN set_police_station AS PS\r\n                ON AAD.thana_id = PS.police_station_id\r\n\r\n                LEFT JOIN set_post_code AS PCI\r\n                ON  AAD.post_code_id = PCI.post_code_id\r\n\r\n                LEFT JOIN set_district AS DST\r\n                ON  AAD.district_id = DST.district_id\r\n                WHERE AAD.org_branch_reg_id = ", branchid, " AND AAD.is_vat_registration = true AND AAD.is_branch_address = true");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchbyOrgId(int orgID)
        {
            string str = string.Concat("select Org_branch_address,Branch_unit_name ,org_branch_category Branch_reg_category,annual_turnover Branch_turnover,Branch_unit_bin\r\n                         from org_branch_reg_info                                         \r\n                         where organization_id=", orgID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet GetBranchInfo(int organID)
        {
            string str = string.Concat("select * from  org_branch_reg_info WHERE organization_id = ", organID, " AND is_deleted = false ORDER BY branch_unit_name");
            return this.DBUtil.GetDataSet(str, "org_registration_info");
        }

        public DataTable GetBranchInfoAfetrsave(int organID)
        {
            string str = string.Concat("select * from org_branch_reg_info WHERE organization_id = ", organID, " AND is_deleted = false ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBusinessProcessActivities()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 21) AND Is_deleted = false ORDER BY code_name");
        }

        public DataTable GetDeclaretion()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 23) AND Is_deleted = false ORDER BY code_name");
        }

        public DataTable GetEconomic_activity(int orgId)
        {
            string str = string.Concat("SELECT economic_process_activity_name FROM org_registration_info WHERE  organization_id=", orgId, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetEconomicInfo(string economicIds)
        {
            string str = string.Concat("select code_name from app_code_detail where code_id_m=22 and code_id_d in(", economicIds, ")");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetEconomicProcessActivities()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 22) AND Is_deleted = false ORDER BY code_name");
        }

        public DataTable GetEconomicProcessActivity()
        {
            return this.DBUtil.GetDataTable("select code_id_d, code_name, code_short_name from app_code_detail where code_id_m = 22 AND is_deleted=false order by code_id_d");
        }

        public DataTable GetfullTableOrganizationInfo(int tableID)
        {
            string str = string.Concat("SELECT * FROM org_registration_info WHERE organization_id  = ", tableID, " AND Is_deleted = false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetFullTabOrganizationName()
        {
            return this.DBUtil.GetDataTable("select * from org_registration_info WHERE Is_DELETED = false ORDER BY organization_name");
        }

        public DataTable GetHScode()
        {
            return this.DBUtil.GetDataTable("select hs_code from hs_code_library");
        }

        public DataSet GetMasterID()
        {
            return this.DBUtil.GetDataSet("SELECT Organization_id FROM org_registration_info ORDER BY Organization_id DESC LIMIT 1;", "org_registration_info");
        }

        public DataTable GetNatureOfApplication()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 20) AND Is_deleted = false ORDER BY code_name");
        }

        public DataSet GetOganizationInfo()
        {
            return this.DBUtil.GetDataSet("SELECT organization_id,organization_name FROM org_registration_info ;", "org_registration_info");
        }

        public DataTable GetOrganization(int orgID)
        {
            string str = string.Concat("select organization_name,organization_id,business_type_name,economic_process_activity_name,registration_no,master_organization_id \r\n                 from org_registration_info                 \r\n                 where Is_deleted = false and organization_id=", orgID, ";");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetORGorBranch(int branchid)
        {
            string str = string.Concat("select distinct branch_unit_name,org_branch_address from org_branch_reg_info where org_branch_reg_id= ", branchid, " ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetORGorBranchAddress(int branchid)
        {
            string str = string.Concat("select distinct org_branch_address from org_branch_reg_info where org_branch_reg_id = ", branchid);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetOtherTaxCollection()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 19) AND Is_deleted = false ORDER BY code_name");
        }

        public DataTable GetPartyInfo(int partyId)
        {
            string str = string.Concat("select p.* \r\n                        ,(select code_name from app_code_detail where code_id_m=24 and code_id_d=p.business_info_id and p.is_deleted=false) business_info\r\n                        ,(select code_name from app_code_detail where code_id_m=35 and code_id_d=p.area_of_mfg_id and p.is_deleted=false) area_of_mfg\r\n                        from trns_party p where p.party_id=", partyId, " and p.is_deleted=false");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetPostOfficeformation(int distrID)
        {
            string str = string.Concat("select * from set_post_code WHERE district_id = ", distrID, " AND Is_deleted = false ORDER BY post_office_name");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetRegistrationType()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 16) AND Is_deleted = false ORDER BY code_name");
        }

        public DataTable GetThanaInformation(int distrcID)
        {
            string str = string.Concat("SELECT * FROM set_police_station WHERE district_id = ", distrcID, " AND Is_deleted = false ORDER BY police_station_name;");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetTypeOfBusinessOrganaization()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 17) AND Is_deleted = false ORDER BY code_name");
        }

        public DataTable GetTypeofmenuf()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 35) AND Is_deleted = false ORDER BY code_id_d");
        }

        public DataTable GetTypeofownership()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 24) AND Is_deleted = false ORDER BY code_id_d");
        }

        public DataTable GetTypeofservice()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 36) AND Is_deleted = false ORDER BY code_id_d");
        }

        public DataTable GetUpazilaInformation(int dstrID)
        {
            string str = string.Concat("SELECT * FROM set_upazila WHERE district_id = ", dstrID, " AND Is_deleted = false ORDER BY upazila_name; ");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetVatDeductedAtSource()
        {
            return this.DBUtil.GetDataTable("SELECT * FROM  app_code_detail WHERE code_id_m IN (SELECT code_id_m FROM app_code_master WHERE code_id_m = 18) AND Is_deleted = false ORDER BY code_name");
        }

        public bool insertMasterOrgInfo(OrgGroupManagementDAO objOrg)
        {
            int num = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('org_group_management_id_seq')"));
            object[] objArray = new object[] { "INSERT INTO org_group_management (master_organization_id,master_organization_name,bin_type,admin_type,user_no) VALUES (", num, ", upper('", objOrg.masterOrgName, "'),'", objOrg.BINType, "','", objOrg.AdminType, "',", objOrg.noOfUser, ")" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool InsertOrganizationRegistrationData(OrgRegistrationInfoDAO objMDAO, ArrayList arrDeailDAObranch, ArrayList arrDeailDAOauthperson)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            ArrayList arrayLists2 = new ArrayList();
            string str = "Select max(organization_id) as organization_id from org_registration_info";
            int num = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('org_branch_reg_id_seq')"));
            this.DBUtil.GetDataTable(str);
            objMDAO.Organization_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('organization_id_seq')"));
            objMDAO.Org_reg_address_id = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('Org_reg_address_id_seq')"));
            object[] orgRegAddressId = new object[] { "insert into org_reg_address (org_reg_address_id,operation_address,district_id,thana_id,post_code_id,phone_no1,mobile_no1,email,fax,website,registered_hq_address,registered,hq_address_foreign)\r\n        values (", objMDAO.Org_reg_address_id, ",'", objMDAO.Reg_address, "', ", objMDAO.District_id, ",", objMDAO.Thana_id, ",", objMDAO.Post_code_id, ",'", objMDAO.Phone_no1, "','", objMDAO.Mobile_no1, "','", objMDAO.Email, "','", objMDAO.Fax, "','", objMDAO.Website, "','", objMDAO.HQ_address, "','", objMDAO.Registered, "','", objMDAO.HQ_address_foreign, "')" };
            arrayLists.Add(string.Concat(orgRegAddressId));
            object[] masterOrganizationID = new object[] { "insert into org_registration_info  (master_organization_id,organization_id,org_type_id_m,org_type_id_d,business_address,tc_fiscal_year_from,tc_fiscal_year_to,\r\n                 circle_id,business_activity,organization_name,business_type_name,is_withholding_entity,trade_license_no,\r\n                 rjsc_incorporation_num,e_tin,company_name_diff_etin,trading_brand,vat_turnover,\r\n                 bida_reg_num,economic_process_activity_name,manufacturing_name,service_name,registration_no,\r\n                 is_manufacturing,is_service,is_imports,is_exports,is_other,other_specification,irc_issue_date,erc_issue_date,\r\n                 irc_no,erc_no,bida_reg_issue_date,trade_license_issue_date,rjsc_incorporation_issue_date,register_persoon_name,reg_person_desig_id) values\r\n                (", objMDAO.MasterOrganizationID, ",", objMDAO.Organization_id, ",11,11,'','2018-06-01','2019-06-01',1,'','", objMDAO.Organization_name, "','", objMDAO.Business_type_Name, "', '", objMDAO.Iswithholding, "','", objMDAO.Licencenseno, "','", objMDAO.RJSC_num, "','", objMDAO.Ginfoetin, "','", objMDAO.CompdifName, "','", objMDAO.Tradbrand, "','", objMDAO.Reg_typ, "','", objMDAO.Bida_regno, "','", objMDAO.Economic_process_activity_name, "','", objMDAO.Manufacture, "','", objMDAO.Service, "','", objMDAO.BIN_number, "'\r\n                 ,'", objMDAO.is_Manufacturing, "','", objMDAO.is_Service, "','", objMDAO.is_Imports, "','", objMDAO.is_Exports, "',\r\n                 '", objMDAO.is_Other, "','", objMDAO.Otherspecification, "',to_timestamp('", objMDAO.IRC_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.ERC_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),'", objMDAO.IRC_no, "',\r\n                 '", objMDAO.ERC_no, "',to_timestamp('", objMDAO.Bida_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.Trad_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.Rjsc_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),'", objMDAO.FullNameReg, "',", objMDAO.Designation, ")" };
            arrayLists.Add(string.Concat(masterOrganizationID));
            object[] organizationId = new object[] { "insert into org_branch_reg_info(org_branch_reg_id,organization_id, branch_unit_name,org_branch_address,branch_unit_bin) values (", num, ",", objMDAO.Organization_id, ",'Head Office' ,'", objMDAO.Reg_address, "','", objMDAO.BIN_number, "')" };
            arrayLists.Add(string.Concat(organizationId));
            object[] bINNumber = new object[] { "insert into trns_party(party_id,party_name, party_tin,party_address,party_bin,user_id_insert) values (-999,'Factory',", objMDAO.BIN_number, " ,'", objMDAO.Reg_address, "','", objMDAO.BIN_number, "',", objMDAO.UserIdInsert, ")" };
            arrayLists.Add(string.Concat(bINNumber));
            if (arrDeailDAObranch != null)
            {
                arrayLists = this.AddDeailInsertBranchSQL(arrayLists, arrDeailDAObranch, objMDAO.Organization_id);
            }
            if (arrDeailDAOauthperson != null)
            {
                arrayLists = this.AddDeailInsertAuthPersonSQL(arrayLists, arrDeailDAOauthperson, objMDAO.Organization_id);
            }
            if (this.connDB.ExecuteBatchDML(arrayLists))
            {
                object[] objArray = new object[] { "update org_reg_address set organization_id=", objMDAO.Organization_id, " where org_reg_address_id=", objMDAO.Org_reg_address_id, " " };
                arrayLists2.Add(string.Concat(objArray));
                flag = this.connDB.ExecuteBatchDML(arrayLists2);
            }
            return flag;
        }

        public bool InsertRegistrationData(OrgRegistrationInfoDAO objMDAO, ArrayList arrDeailDAO, ArrayList arrDeailDAObusiness, ArrayList arrDeailDAObranch, ArrayList arrDeailDAOmanufact, ArrayList arrDeailDAOinputoutput, ArrayList arrDeailDAOauthperson, ArrayList arrDeailDAOowner, ArrayList arrDeailDAOEcoSpecify)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            ArrayList arrayLists1 = new ArrayList();
            ArrayList arrayLists2 = new ArrayList();
            string str = "Select max(organization_id) as organization_id from org_registration_info";
            int num = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('org_branch_reg_id_seq')"));
            this.DBUtil.GetDataTable(str);
            objMDAO.Organization_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('organization_id_seq')"));
            objMDAO.Org_reg_address_id = Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('Org_reg_address_id_seq')"));
            objMDAO.Nature_of_application_id = (long)Convert.ToInt16(this.connDB.GetSingleValue("SELECT  nextval('nature_of_application_id_seq')"));
            if (!objMDAO.Old_application)
            {
                object[] natureOfApplicationId = new object[] { "insert into nature_of_application(nature_of_application_id,new_application, new_bin_number, organization_name) values (", objMDAO.Nature_of_application_id, ",'", objMDAO.New_application, "' ,'", objMDAO.New_bin_number, "','", objMDAO.Organization_name, "')" };
                arrayLists.Add(string.Concat(natureOfApplicationId));
            }
            else
            {
                object[] objArray = new object[] { "insert into nature_of_application(nature_of_application_id,old_application, old_bin_number, organization_name) values (", objMDAO.Nature_of_application_id, ",'", objMDAO.Old_application, "' ,'", objMDAO.Old_bin_number, "','", objMDAO.Organization_name, "')" };
                arrayLists.Add(string.Concat(objArray));
            }
            object[] orgRegAddressId = new object[] { "insert into org_reg_address (org_reg_address_id,operation_address,district_id,thana_id,post_code_id,phone_no1,mobile_no1,email,fax,website,registered_hq_address,registered,hq_address_foreign)\r\n                  values (", objMDAO.Org_reg_address_id, ",'", objMDAO.Reg_address, "', ", objMDAO.District_id, ",", objMDAO.Thana_id, ",", objMDAO.Post_code_id, ",'", objMDAO.Phone_no1, "','", objMDAO.Mobile_no1, "','", objMDAO.Email, "','", objMDAO.Fax, "','", objMDAO.Website, "','", objMDAO.HQ_address, "','", objMDAO.Registered, "','", objMDAO.HQ_address_foreign, "')" };
            arrayLists.Add(string.Concat(orgRegAddressId));
            object[] organizationId = new object[] { "insert into org_registration_info  (organization_id,org_type_id_m,org_type_id_d,business_address,tc_fiscal_year_from,tc_fiscal_year_to,\r\ncircle_id,business_activity,organization_name,business_type_name,is_withholding_entity,trade_license_no,\r\n                                                        rjsc_incorporation_num,e_tin,company_name_diff_etin,trading_brand,vat_turnover,\r\n                                                        bida_reg_num,economic_process_activity_name,manufacturing_name,service_name,registration_no,\r\nis_manufacturing,is_service,is_imports,is_exports,is_other,other_specification,irc_issue_date,erc_issue_date,\r\nirc_no,erc_no,bida_reg_issue_date,trade_license_issue_date,rjsc_incorporation_issue_date,register_persoon_name,reg_person_desig_id) values\r\n                               (", objMDAO.Organization_id, ",11,11,'','2018-06-01','2019-06-01',1,'','", objMDAO.Organization_name, "','", objMDAO.Business_type_Name, "', '", objMDAO.Iswithholding, "','", objMDAO.Licencenseno, "','", objMDAO.RJSC_num, "','", objMDAO.Ginfoetin, "','", objMDAO.CompdifName, "','", objMDAO.Tradbrand, "','", objMDAO.Reg_typ, "','", objMDAO.Bida_regno, "','", objMDAO.Economic_process_activity_name, "','", objMDAO.Manufacture, "','", objMDAO.Service, "','", objMDAO.BIN_number, "'\r\n                               ,'", objMDAO.is_Manufacturing, "','", objMDAO.is_Service, "','", objMDAO.is_Imports, "','", objMDAO.is_Exports, "',\r\n                               '", objMDAO.is_Other, "','", objMDAO.Otherspecification, "',to_timestamp('", objMDAO.IRC_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.ERC_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),'", objMDAO.IRC_no, "',\r\n'", objMDAO.ERC_no, "',to_timestamp('", objMDAO.Bida_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.Trad_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),to_timestamp('", objMDAO.Rjsc_issuedate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),'", objMDAO.FullNameReg, "',", objMDAO.Designation, ")" };
            arrayLists.Add(string.Concat(organizationId));
            object[] organizationId1 = new object[] { "insert into org_branch_reg_info(org_branch_reg_id,organization_id, branch_unit_name,org_branch_address,branch_unit_bin) values (", num, ",", objMDAO.Organization_id, ",'Head Office' ,'", objMDAO.Reg_address, "','", objMDAO.BIN_number, "')" };
            arrayLists.Add(string.Concat(organizationId1));
            object[] bINNumber = new object[] { "insert into trns_party(party_id,party_name, party_tin,party_address,party_bin,user_id_insert) values (-999,'Factory',", objMDAO.BIN_number, " ,'", objMDAO.Reg_address, "','", objMDAO.BIN_number, "',", objMDAO.UserIdInsert, ")" };
            arrayLists.Add(string.Concat(bINNumber));
            if (arrDeailDAO != null)
            {
                arrayLists = this.AddDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.Organization_id);
            }
            if (arrDeailDAObusiness != null)
            {
                arrayLists = this.AddDeailInsertBusinessSQL(arrayLists, arrDeailDAObusiness, objMDAO.Organization_id);
            }
            if (arrDeailDAObranch != null)
            {
                arrayLists = this.AddDeailInsertBranchSQL(arrayLists, arrDeailDAObranch, objMDAO.Organization_id);
            }
            if (arrDeailDAOowner != null)
            {
                arrayLists = this.AddDeailInsertOwnerSQL(arrayLists, arrDeailDAOowner, objMDAO.Organization_id);
            }
            if (arrDeailDAOauthperson != null)
            {
                arrayLists = this.AddDeailInsertAuthPersonSQL(arrayLists, arrDeailDAOauthperson, objMDAO.Organization_id);
            }
            if (arrDeailDAOmanufact != null)
            {
                arrayLists = this.AddInsertCapitalMachineryInfos(arrayLists, arrDeailDAOmanufact, objMDAO.Organization_id);
            }
            if (arrDeailDAOinputoutput != null)
            {
                arrayLists = this.AddInsertInputOutputs(arrayLists, arrDeailDAOinputoutput, objMDAO.Organization_id);
            }
            if (arrDeailDAOEcoSpecify != null)
            {
                arrayLists = this.AddInsertEconomicSpecification(arrayLists, arrDeailDAOEcoSpecify, objMDAO.Organization_id);
            }
            if (this.connDB.ExecuteBatchDML(arrayLists))
            {
                object[] objArray1 = new object[] { "update nature_of_application set organization_id=", objMDAO.Organization_id, " where nature_of_application_id=", objMDAO.Nature_of_application_id };
                arrayLists2.Add(string.Concat(objArray1));
                object[] organizationId2 = new object[] { "update org_reg_address set organization_id=", objMDAO.Organization_id, " where org_reg_address_id=", objMDAO.Org_reg_address_id, " " };
                arrayLists2.Add(string.Concat(organizationId2));
                flag = this.connDB.ExecuteBatchDML(arrayLists2);
            }
            return flag;
        }

        public DataTable LoadFullTableAllAddressBranchUnit(int id)
        {
            string str = string.Concat("\r\n                SELECT PS.police_station_name ||','|| UP.upazila_name ||','|| DST.district_name AS fullAddress,\r\n\t\t        AAD.mobile_no1,\r\n\t\t        AAD.moza_name,\r\n                AAD.phone_no1\r\n                FROM  all_address AS AAD\r\n                LEFT JOIN set_upazila AS UP\r\n                ON AAD.upazila_id = UP.upazila_id\r\n                LEFT JOIN set_police_station AS PS\r\n                ON AAD.thana_id = PS.police_station_id\r\n                LEFT JOIN set_post_code AS PCI\r\n                ON  AAD.post_code_id = PCI.post_code_id\r\n                LEFT JOIN set_district AS DST\r\n                ON  AAD.district_id = DST.district_id\r\n\r\n               \r\n                WHERE AAD.organization_id = ", id, " AND AAD.is_vat_registration = true AND AAD.is_branch_address = true");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTableAllAddressForBranchParmanentAddress(int id, int branchID)
        {
            object[] objArray = new object[] { "\r\n                SELECT AAD.para_moholla, AAD.village,PS.police_station_name,DST.district_name,UP.upazila_name,\r\n\t\t        PCI.post_office_name, AAD.moza_name,AAD.phone_no1,AAD.mobile_no1, AAD.website,\r\n                AAD.fax,AAD.email\r\n  \r\n                FROM  all_address AS AAD\r\n\r\n                LEFT JOIN set_upazila AS UP\r\n                ON AAD.upazila_id = UP.upazila_id\r\n\r\n                LEFT JOIN set_police_station AS PS\r\n                ON AAD.thana_id = PS.police_station_id\r\n\r\n                LEFT JOIN set_post_code AS PCI\r\n                ON  AAD.post_code_id = PCI.post_code_id\r\n\r\n                LEFT JOIN set_district AS DST\r\n                ON  AAD.district_id = DST.district_id\r\n                WHERE AAD.organization_id = ", id, "  AND AAD.org_branch_reg_id = ", branchID, " -- AND AAD.is_branch_registration = true AND AAD.is_parmanent_address = true" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTableAllAddressForBranchRegPresentAdd(int id, int branchID)
        {
            object[] objArray = new object[] { "\r\n\r\n                SELECT AAD.holding,AAD.road_no, AAD.block_area,DST.district_name,UP.upazila_name, \r\n\t\t        PCI.post_office_name,AAD.moza_name,AAD.phone_no1,AAD.mobile_no1,\r\n\t\t        AAD.website,  AAD.fax, AAD.email\r\n                \r\n                FROM  all_address AS AAD\r\n\r\n                LEFT JOIN set_upazila AS UP\r\n                ON AAD.upazila_id = UP.upazila_id\r\n\r\n                LEFT JOIN set_police_station AS PS\r\n                ON AAD.thana_id = PS.police_station_id\r\n\r\n                LEFT JOIN set_post_code AS PCI\r\n                ON  AAD.post_code_id = PCI.post_code_id\r\n\r\n                LEFT JOIN set_district AS DST\r\n                ON  AAD.district_id = DST.district_id\r\n\r\n\t\t        WHERE AAD.organization_id = ", id, " AND AAD.org_branch_reg_id = ", branchID, "  -- AND AAD.is_branch_registration = true AND AAD.is_present_address = true" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTableAllAddressParmanentAddress(int id)
        {
            string str = string.Concat(" SELECT AAD.para_moholla, AAD.village,PS.police_station_name,AAD.district_id,DST.district_name,AAD.upazila_id,UP.upazila_name,\r\n\t\t        AAD.post_code_id,PCI.post_office_name, AAD.moza_name,AAD.phone_no1,AAD.phone_no2,AAD.mobile_no1,AAD.mobile_no2, AAD.website,AAD.thana_id,PS.police_station_name,\r\n                AAD.fax,AAD.email,AAD.road_no\r\n  \r\n                FROM  all_address AS AAD\r\n\r\n                LEFT JOIN set_upazila AS UP\r\n                ON AAD.upazila_id = UP.upazila_id\r\n\r\n                LEFT JOIN set_police_station AS PS\r\n                ON AAD.thana_id = PS.police_station_id\r\n\r\n                LEFT JOIN set_post_code AS PCI\r\n                ON  AAD.post_code_id = PCI.post_code_id\r\n\r\n                LEFT JOIN set_district AS DST\r\n                ON  AAD.district_id = DST.district_id\r\n                 WHERE AAD.organization_id = ", id, " AND AAD.is_vat_registration = true AND AAD.is_parmanent_address = true");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTableAllAddressPresentAddress(int id)
        {
            string str = string.Concat(" select  AAD.holding,AAD.road_no, AAD.block_area,AAD.district_id,DST.district_name,AAD.upazila_id,UP.upazila_name, \r\n\t\t        AAD.post_code_id,PCI.post_office_name,AAD.thana_id,PS.police_station_name,AAD.moza_name,AAD.phone_no1,AAD.phone_no2,AAD.mobile_no1,AAD.mobile_no2,\r\n\t\t        AAD.website,  AAD.fax, AAD.email,AAD.road\r\n                \r\n                FROM  all_address AS AAD\r\n\r\n                LEFT JOIN set_upazila AS UP\r\n                ON AAD.upazila_id = UP.upazila_id\r\n\r\n                LEFT JOIN set_police_station AS PS\r\n                ON AAD.thana_id = PS.police_station_id\r\n\r\n                LEFT JOIN set_post_code AS PCI\r\n                ON  AAD.post_code_id = PCI.post_code_id\r\n\r\n                LEFT JOIN set_district AS DST\r\n                ON  AAD.district_id = DST.district_id\r\n\r\n\t\t         WHERE organization_id = ", id, " AND is_vat_registration = true AND is_present_address = true");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTableOrgBankAccount(int id)
        {
            string str = string.Concat(" SELECT OBA.account_name,OBA.account_no,SB.bank_name,SBB.branch_name\r\n\t              \r\n\r\n              FROM org_bank_account AS OBA\r\n\t\r\n\t            LEFT JOIN \r\n\t            (SELECT * FROM  set_bank WHERE is_deleted = false ORDER BY bank_name) AS SB\r\n\t            ON\r\n\t            OBA.bank_id = SB.bank_id\r\n\r\n\t            LEFT JOIN \r\n\t            set_bank_branch AS SBB\r\n\t            ON\r\n\t            OBA.bank_branch_id = SBB.branch_id\r\n\r\n                WHERE OBA.organization_id = ", id, " AND OBA.is_vat_registration = true");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTableOrgBranchBankAccount(int id, int branchID)
        {
            object[] objArray = new object[] { "\r\n              SELECT OBA.account_name,OBA.account_no,BRI.branch_unit_bin,BRI.branch_unit_name,\r\n\t              SB.bank_name,SBB.branch_name,\r\n\t              CASE \r\n\t                WHEN account_type_id = 1 THEN 'Saving'\r\n\t                WHEN account_type_id = 2 THEN 'Current'\r\n\t                WHEN account_type_id = 3 THEN 'STD'\r\n\t              END Account_Type\r\n\t              \r\n              FROM org_bank_account AS OBA\r\n\t\r\n\t            LEFT JOIN \r\n\t            (SELECT * FROM  set_bank WHERE is_deleted = false ORDER BY bank_name) AS SB\r\n\t            ON\r\n\t            OBA.bank_id = SB.bank_id\r\n\r\n\t            LEFT JOIN \r\n\t            set_bank_branch AS SBB\r\n\t            ON\r\n\t            OBA.bank_branch_id = SBB.branch_id\r\n\r\n                LEFT JOIN \r\n\t            org_branch_reg_info AS BRI\r\n\t            ON\r\n\t            OBA.org_branch_reg_id = BRI.org_branch_reg_id\r\n\r\n                WHERE OBA.organization_id = ", id, "AND OBA.org_branch_reg_id = ", branchID, " -- AND OBA.is_branch_registration = true AND OBA.is_deleted = false" };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTablNatureOfApplication(int id)
        {
            string str = string.Concat("SELECT organization_name,branch_name,old_application,old_bin_number,\r\n        CASE WHEN old_application = false then 'New Application'\r\n        ELSE 'Old Application'\r\n        END logic\r\n        FROM nature_of_application WHERE organization_id = ", id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable LoadFullTablOwnerInformation(int id)
        {
            string str = string.Concat("SELECT  director_name,designation,share_percentage,start_date,end_date,\r\n\t    nid_no, passport_no, passport_issue_contry\r\n        FROM owner_type\r\n        WHERE organization_id = ", id);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable majorArea(string marea)
        {
            Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select code_name from app_code_detail where code_id_m=22 and code_id_d in (", marea, ") and is_deleted=false");
            return this.DBUtil.GetDataTable(str);
        }
    }
}