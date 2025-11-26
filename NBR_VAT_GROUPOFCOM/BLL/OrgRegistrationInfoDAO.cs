using System;
using System.Data;
using System.Runtime.CompilerServices;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class OrgRegistrationInfoDAO
    {
        private OrgRegistrationInfoBLL orgRegistrationInfo = new OrgRegistrationInfoBLL();

        private DBUtility DBUtil = new DBUtility();

        private string fiscalDateFrom;

        private string fiscalDateTo;

        private int organization_id;

        private long nature_of_application_id;

        private string organization_name;

        private string withholding_entity;

        private string register_persoon_name;

        private string abbr_name;

        private bool registration_type = true;

        private bool iswithholding = true;

        private short registration_type_n;

        private short org_reg_address_id;

        private double amount;

        private string amount_in_word;

        private string vat_deducted_at_source;

        private string vat_deducted_at_source_name;

        private string other_tax_collection;

        private string other_tax_collection_name;

        private string registration_date;

        private string application_nature;

        private string application_nature_name;

        private string business_process_activity;

        private string business_process_activity_name;

        private string economic_process_activity;

        private string economic_process_activity_name;

        private short parent_org_id;

        private int userIdInsert;

        private short org_type_id_m = 11;

        private short org_type_id_d = 11;

        private string business_address = "";

        private string ba_phone;

        private string ba_email;

        private string ba_fax;

        private string factory_address;

        private string fa_phone;

        private string fa_email;

        private string fa_fax;

        private string head_office_address;

        private string ho_phone;

        private string ho_email;

        private string ho_fax;

        private string tin_company;

        private string previous_registration_no;

        private bool tc_is_vat;

        private bool tc_is_cottage_industry;

        private bool tc_is_other;

        private bool tc_is_supplier_manufacturer;

        private bool tc_is_supplier_trader;

        private bool tc_is_service_renderer;

        private bool tc_is_importer;

        private bool tc_is_exporter;

        private string tc_trade_license_no;

        private string tc_authority;

        private DateTime tc_fiscal_year_from = DateTime.Now;

        private DateTime tc_fiscal_year_to = DateTime.Now;

        private string tc_import_reg_no;

        private string tc_export_reg_no;

        private bool is_deleted;

        private string owner_permanent_address;

        private string ow_phone;

        private string ow_email;

        private string ow_fax;

        private bool tc_is_trnovr_tax_yrly;

        private bool tc_is_trnovr_tax_qrtrly;

        private bool tc_is_trnovr_tax_mnthly;

        private DateTime reg_effictive_date;

        private long circle_id;

        private string tin_chairman;

        private string national_id_of_chairman;

        private string registration_no;

        private string business_activity = "";

        private string business_type;

        private string business_type_Name;

        private bool is_vat_deduct;

        private int business_cls_id;

        private string manufacture;

        private string import_irc;

        private string import_issuedate;

        private string export_irc;

        private string export_issuedate;

        private string otherspecification;

        private string comdesSupply;

        private string servicecode;

        private string desservicecode;

        private string service;

        private string mjdescripction;

        private int mjquantity;

        private string mjhscode;

        private int mjvalue;

        private int mjproducCapacity;

        private string mjPhycondition;

        private string iodescripction;

        private string iocodeoutput;

        private string sellingunit;

        private string iodesinput;

        private string iocodeinput;

        private int ioquantity;

        private string authname;

        private string authdesignation;

        private int authnid;

        private int authmobile;

        private string authemail;

        private string authpurpose;

        private string licencenseno;

        private string rjsc_num;

        private string ginfoetin;

        private string compName;

        private string compdifName;

        private string tradbrand;

        private string reg_typ;

        private string equityinfo_local;

        private string equityinfo_foreign;

        private string equityinfo_jv;

        private string bida_regno;

        private DateTime bida_issuedate;

        private DateTime trad_issuedate;

        private DateTime rjsc_issuedate;

        private string branch_reg_category_;

        private bool new_application;

        private bool old_application;

        private string new_bin_number;

        private string old_bin_number;

        private string branch_name;

        private short thana_id;

        private short post_code_id;

        private short district_id;

        private string email;

        private string website;

        private string fax;

        private string phone_no1;

        private string mobile_no1;

        private string hq_address;

        private string hq_address_foreign;

        private string registered;

        private string reg_address;

        private string branch_unit_bin;

        private string branch_unit_name;

        private string reg_category;

        private int branch_Id;

        private string bin_number;

        private string AccountNo;

        private string AccountName;

        private int bank_Id;

        private string director_name;

        private string share_percentage;

        private string etin_d;

        private string nid;

        private int account_id;

        private string org_branch_address;

        private double branch_turnover;

        private int org_branch_Id;

        private bool is_other = true;

        private bool is_manufacturing = true;

        private bool is_service = true;

        private bool is_imports = true;

        private bool is_exports = true;

        private string irc_no;

        private string erc_no;

        private string other_specification;

        private DateTime irc_issuedate;

        private DateTime erc_issuedate;

        private string fullNameReg;

        private int designation;

        public string Abbr_name
        {
            get
            {
                return this.abbr_name;
            }
            set
            {
                this.abbr_name = value;
            }
        }

        public int Account_id
        {
            get
            {
                return this.account_id;
            }
            set
            {
                this.account_id = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string Amount_in_word
        {
            get
            {
                return this.amount_in_word;
            }
            set
            {
                this.amount_in_word = value;
            }
        }

        public string Application_nature
        {
            get
            {
                return this.application_nature;
            }
            set
            {
                this.application_nature = value;
            }
        }

        public string Application_nature_name
        {
            get
            {
                return this.application_nature_name;
            }
            set
            {
                this.application_nature_name = value;
            }
        }

        public string Authdesignation
        {
            get
            {
                return this.authdesignation;
            }
            set
            {
                this.authdesignation = value;
            }
        }

        public string Authemail
        {
            get
            {
                return this.authemail;
            }
            set
            {
                this.authemail = value;
            }
        }

        public int Authmobile
        {
            get
            {
                return this.authmobile;
            }
            set
            {
                this.authmobile = value;
            }
        }

        public string Authname
        {
            get
            {
                return this.authname;
            }
            set
            {
                this.authname = value;
            }
        }

        public int Authnid
        {
            get
            {
                return this.authnid;
            }
            set
            {
                this.authnid = value;
            }
        }

        public string Authpurpose
        {
            get
            {
                return this.authpurpose;
            }
            set
            {
                this.authpurpose = value;
            }
        }

        public string Ba_email
        {
            get
            {
                return this.ba_email;
            }
            set
            {
                this.ba_email = value;
            }
        }

        public string Ba_fax
        {
            get
            {
                return this.ba_fax;
            }
            set
            {
                this.ba_fax = value;
            }
        }

        public string Ba_phone
        {
            get
            {
                return this.ba_phone;
            }
            set
            {
                this.ba_phone = value;
            }
        }

        public int Bank_id
        {
            get
            {
                return this.bank_Id;
            }
            set
            {
                this.bank_Id = value;
            }
        }

        public DateTime Bida_issuedate
        {
            get
            {
                return this.bida_issuedate;
            }
            set
            {
                this.bida_issuedate = value;
            }
        }

        public string Bida_regno
        {
            get
            {
                return this.bida_regno;
            }
            set
            {
                this.bida_regno = value;
            }
        }

        public string BIN_number
        {
            get
            {
                return this.bin_number;
            }
            set
            {
                this.bin_number = value;
            }
        }

        public int branch
        {
            get
            {
                return this.branch_Id;
            }
            set
            {
                this.branch_Id = value;
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

        public string Branch_reg_category
        {
            get
            {
                return this.branch_reg_category_;
            }
            set
            {
                this.branch_reg_category_ = value;
            }
        }

        public double Branch_turnover
        {
            get
            {
                return this.branch_turnover;
            }
            set
            {
                this.branch_turnover = value;
            }
        }

        public string Branch_unit_bin
        {
            get
            {
                return this.branch_unit_bin;
            }
            set
            {
                this.branch_unit_bin = value;
            }
        }

        public string Branch_unit_name
        {
            get
            {
                return this.branch_unit_name;
            }
            set
            {
                this.branch_unit_name = value;
            }
        }

        public string Business_activity
        {
            get
            {
                return this.business_activity;
            }
            set
            {
                this.business_activity = value;
            }
        }

        public string Business_address
        {
            get
            {
                return this.business_address;
            }
            set
            {
                this.business_address = value;
            }
        }

        public int Business_cls_id
        {
            get
            {
                return this.business_cls_id;
            }
            set
            {
                this.business_cls_id = value;
            }
        }

        public string Business_process_activity
        {
            get
            {
                return this.business_process_activity;
            }
            set
            {
                this.business_process_activity = value;
            }
        }

        public string Business_process_activity_name
        {
            get
            {
                return this.business_process_activity_name;
            }
            set
            {
                this.business_process_activity_name = value;
            }
        }

        public string Business_type
        {
            get
            {
                return this.business_type;
            }
            set
            {
                this.business_type = value;
            }
        }

        public string Business_type_Name
        {
            get
            {
                return this.business_type_Name;
            }
            set
            {
                this.business_type_Name = value;
            }
        }

        public long Circle_id
        {
            get
            {
                return this.circle_id;
            }
            set
            {
                this.circle_id = value;
            }
        }

        public string ComdesSupply
        {
            get
            {
                return this.comdesSupply;
            }
            set
            {
                this.comdesSupply = value;
            }
        }

        public string CompdifName
        {
            get
            {
                return this.compdifName;
            }
            set
            {
                this.compdifName = value;
            }
        }

        public string CompName
        {
            get
            {
                return this.compName;
            }
            set
            {
                this.compName = value;
            }
        }

        public int Designation
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

        public string Desservicecode
        {
            get
            {
                return this.desservicecode;
            }
            set
            {
                this.desservicecode = value;
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

        public string Economic_process_activity
        {
            get
            {
                return this.economic_process_activity;
            }
            set
            {
                this.economic_process_activity = value;
            }
        }

        public string Economic_process_activity_name
        {
            get
            {
                return this.economic_process_activity_name;
            }
            set
            {
                this.economic_process_activity_name = value;
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

        public string Equityinfo_foreign
        {
            get
            {
                return this.equityinfo_foreign;
            }
            set
            {
                this.equityinfo_foreign = value;
            }
        }

        public string Equityinfo_jv
        {
            get
            {
                return this.equityinfo_jv;
            }
            set
            {
                this.equityinfo_jv = value;
            }
        }

        public string Equityinfo_local
        {
            get
            {
                return this.equityinfo_local;
            }
            set
            {
                this.equityinfo_local = value;
            }
        }

        public DateTime ERC_issuedate
        {
            get
            {
                return this.erc_issuedate;
            }
            set
            {
                this.erc_issuedate = value;
            }
        }

        public string ERC_no
        {
            get
            {
                return this.erc_no;
            }
            set
            {
                this.erc_no = value;
            }
        }

        public string Etin_d
        {
            get
            {
                return this.etin_d;
            }
            set
            {
                this.etin_d = value;
            }
        }

        public string Export_irc
        {
            get
            {
                return this.export_irc;
            }
            set
            {
                this.export_irc = value;
            }
        }

        public string Export_issuedate
        {
            get
            {
                return this.export_issuedate;
            }
            set
            {
                this.export_issuedate = value;
            }
        }

        public string Fa_email
        {
            get
            {
                return this.fa_email;
            }
            set
            {
                this.fa_email = value;
            }
        }

        public string Fa_fax
        {
            get
            {
                return this.fa_fax;
            }
            set
            {
                this.fa_fax = value;
            }
        }

        public string Fa_phone
        {
            get
            {
                return this.fa_phone;
            }
            set
            {
                this.fa_phone = value;
            }
        }

        public string Factory_address
        {
            get
            {
                return this.factory_address;
            }
            set
            {
                this.factory_address = value;
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

        public string FiscalDateFrom
        {
            get
            {
                return this.fiscalDateFrom;
            }
            set
            {
                this.fiscalDateFrom = value;
            }
        }

        public string FiscalDateTo
        {
            get
            {
                return this.fiscalDateTo;
            }
            set
            {
                this.fiscalDateTo = value;
            }
        }

        public string FullNameReg
        {
            get
            {
                return this.fullNameReg;
            }
            set
            {
                this.fullNameReg = value;
            }
        }

        public string Ginfoetin
        {
            get
            {
                return this.ginfoetin;
            }
            set
            {
                this.ginfoetin = value;
            }
        }

        public string Head_office_address
        {
            get
            {
                return this.head_office_address;
            }
            set
            {
                this.head_office_address = value;
            }
        }

        public string Ho_email
        {
            get
            {
                return this.ho_email;
            }
            set
            {
                this.ho_email = value;
            }
        }

        public string Ho_fax
        {
            get
            {
                return this.ho_fax;
            }
            set
            {
                this.ho_fax = value;
            }
        }

        public string Ho_phone
        {
            get
            {
                return this.ho_phone;
            }
            set
            {
                this.ho_phone = value;
            }
        }

        public string HQ_address
        {
            get
            {
                return this.hq_address;
            }
            set
            {
                this.hq_address = value;
            }
        }

        public string HQ_address_foreign
        {
            get
            {
                return this.hq_address_foreign;
            }
            set
            {
                this.hq_address_foreign = value;
            }
        }

        public string Import_irc
        {
            get
            {
                return this.import_irc;
            }
            set
            {
                this.import_irc = value;
            }
        }

        public string Import_issuedate
        {
            get
            {
                return this.import_issuedate;
            }
            set
            {
                this.import_issuedate = value;
            }
        }

        public string IOcodeinput
        {
            get
            {
                return this.iocodeinput;
            }
            set
            {
                this.iocodeinput = value;
            }
        }

        public string IOcodeoutput
        {
            get
            {
                return this.iocodeoutput;
            }
            set
            {
                this.iocodeoutput = value;
            }
        }

        public string IOdescripction
        {
            get
            {
                return this.iodescripction;
            }
            set
            {
                this.iodescripction = value;
            }
        }

        public string IOdesinput
        {
            get
            {
                return this.iodesinput;
            }
            set
            {
                this.iodesinput = value;
            }
        }

        public int IOquantity
        {
            get
            {
                return this.ioquantity;
            }
            set
            {
                this.ioquantity = value;
            }
        }

        public DateTime IRC_issuedate
        {
            get
            {
                return this.irc_issuedate;
            }
            set
            {
                this.irc_issuedate = value;
            }
        }

        public string IRC_no
        {
            get
            {
                return this.irc_no;
            }
            set
            {
                this.irc_no = value;
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

        public bool is_Exports
        {
            get
            {
                return this.is_exports;
            }
            set
            {
                this.is_exports = value;
            }
        }

        public bool is_Imports
        {
            get
            {
                return this.is_imports;
            }
            set
            {
                this.is_imports = value;
            }
        }

        public bool is_Manufacturing
        {
            get
            {
                return this.is_manufacturing;
            }
            set
            {
                this.is_manufacturing = value;
            }
        }

        public bool is_Other
        {
            get
            {
                return this.is_other;
            }
            set
            {
                this.is_other = value;
            }
        }

        public bool is_Service
        {
            get
            {
                return this.is_service;
            }
            set
            {
                this.is_service = value;
            }
        }

        public bool Is_vat_deduct
        {
            get
            {
                return this.is_vat_deduct;
            }
            set
            {
                this.is_vat_deduct = value;
            }
        }

        public bool Iswithholding
        {
            get
            {
                return this.iswithholding;
            }
            set
            {
                this.iswithholding = value;
            }
        }

        public string Licencenseno
        {
            get
            {
                return this.licencenseno;
            }
            set
            {
                this.licencenseno = value;
            }
        }

        public string Manufacture
        {
            get
            {
                return this.manufacture;
            }
            set
            {
                this.manufacture = value;
            }
        }

        public int MasterOrganizationID
        {
            get;
            set;
        }

        public string Mjdescripction
        {
            get
            {
                return this.mjdescripction;
            }
            set
            {
                this.mjdescripction = value;
            }
        }

        public string Mjhscode
        {
            get
            {
                return this.mjhscode;
            }
            set
            {
                this.mjhscode = value;
            }
        }

        public string MjPhycondition
        {
            get
            {
                return this.mjPhycondition;
            }
            set
            {
                this.mjPhycondition = value;
            }
        }

        public int MjproducCapacity
        {
            get
            {
                return this.mjproducCapacity;
            }
            set
            {
                this.mjproducCapacity = value;
            }
        }

        public int Mjquantity
        {
            get
            {
                return this.mjquantity;
            }
            set
            {
                this.mjquantity = value;
            }
        }

        public int Mjvalue
        {
            get
            {
                return this.mjvalue;
            }
            set
            {
                this.mjvalue = value;
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

        public string National_id_of_chairman
        {
            get
            {
                return this.national_id_of_chairman;
            }
            set
            {
                this.national_id_of_chairman = value;
            }
        }

        public long Nature_of_application_id
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

        public string NID
        {
            get
            {
                return this.nid;
            }
            set
            {
                this.nid = value;
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

        public string Org_branch_address
        {
            get
            {
                return this.org_branch_address;
            }
            set
            {
                this.org_branch_address = value;
            }
        }

        public int Org_branch_Id
        {
            get
            {
                return this.org_branch_Id;
            }
            set
            {
                this.org_branch_Id = value;
            }
        }

        public short Org_reg_address_id
        {
            get
            {
                return this.org_reg_address_id;
            }
            set
            {
                this.org_reg_address_id = value;
            }
        }

        public short Org_type_id_d
        {
            get
            {
                return this.org_type_id_d;
            }
            set
            {
                this.org_type_id_d = value;
            }
        }

        public short Org_type_id_m
        {
            get
            {
                return this.org_type_id_m;
            }
            set
            {
                this.org_type_id_m = value;
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

        public string Other_specification
        {
            get
            {
                return this.other_specification;
            }
            set
            {
                this.other_specification = value;
            }
        }

        public string Other_tax_collection
        {
            get
            {
                return this.other_tax_collection;
            }
            set
            {
                this.other_tax_collection = value;
            }
        }

        public string Other_tax_collection_name
        {
            get
            {
                return this.other_tax_collection_name;
            }
            set
            {
                this.other_tax_collection_name = value;
            }
        }

        public string Otherspecification
        {
            get
            {
                return this.otherspecification;
            }
            set
            {
                this.otherspecification = value;
            }
        }

        public string Ow_email
        {
            get
            {
                return this.ow_email;
            }
            set
            {
                this.ow_email = value;
            }
        }

        public string Ow_fax
        {
            get
            {
                return this.ow_fax;
            }
            set
            {
                this.ow_fax = value;
            }
        }

        public string Ow_phone
        {
            get
            {
                return this.ow_phone;
            }
            set
            {
                this.ow_phone = value;
            }
        }

        public string Owner_permanent_address
        {
            get
            {
                return this.owner_permanent_address;
            }
            set
            {
                this.owner_permanent_address = value;
            }
        }

        public short Parent_org_id
        {
            get
            {
                return this.parent_org_id;
            }
            set
            {
                this.parent_org_id = value;
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

        public string Previous_registration_no
        {
            get
            {
                return this.previous_registration_no;
            }
            set
            {
                this.previous_registration_no = value;
            }
        }

        public string Reg_address
        {
            get
            {
                return this.reg_address;
            }
            set
            {
                this.reg_address = value;
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

        public DateTime Reg_effictive_date
        {
            get
            {
                return this.reg_effictive_date;
            }
            set
            {
                this.reg_effictive_date = value;
            }
        }

        public string Reg_typ
        {
            get
            {
                return this.reg_typ;
            }
            set
            {
                this.reg_typ = value;
            }
        }

        public string Register_persoon_name
        {
            get
            {
                return this.register_persoon_name;
            }
            set
            {
                this.register_persoon_name = value;
            }
        }

        public string Registered
        {
            get
            {
                return this.registered;
            }
            set
            {
                this.registered = value;
            }
        }

        public string Registration_date
        {
            get
            {
                return this.registration_date;
            }
            set
            {
                this.registration_date = value;
            }
        }

        public string Registration_no
        {
            get
            {
                return this.registration_no;
            }
            set
            {
                this.registration_no = value;
            }
        }

        public bool Registration_type
        {
            get
            {
                return this.registration_type;
            }
            set
            {
                this.registration_type = value;
            }
        }

        public short Registration_type_n
        {
            get
            {
                return this.registration_type_n;
            }
            set
            {
                this.registration_type_n = value;
            }
        }

        public DateTime Rjsc_issuedate
        {
            get
            {
                return this.rjsc_issuedate;
            }
            set
            {
                this.rjsc_issuedate = value;
            }
        }

        public string RJSC_num
        {
            get
            {
                return this.rjsc_num;
            }
            set
            {
                this.rjsc_num = value;
            }
        }

        public string Sellingunit
        {
            get
            {
                return this.sellingunit;
            }
            set
            {
                this.sellingunit = value;
            }
        }

        public string Service
        {
            get
            {
                return this.service;
            }
            set
            {
                this.service = value;
            }
        }

        public string Servicecode
        {
            get
            {
                return this.servicecode;
            }
            set
            {
                this.servicecode = value;
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

        public string strAccountName
        {
            get
            {
                return this.AccountName;
            }
            set
            {
                this.AccountName = value;
            }
        }

        public string strAccountNo
        {
            get
            {
                return this.AccountNo;
            }
            set
            {
                this.AccountNo = value;
            }
        }

        public string Tc_authority
        {
            get
            {
                return this.tc_authority;
            }
            set
            {
                this.tc_authority = value;
            }
        }

        public string Tc_export_reg_no
        {
            get
            {
                return this.tc_export_reg_no;
            }
            set
            {
                this.tc_export_reg_no = value;
            }
        }

        public DateTime Tc_fiscal_year_from
        {
            get
            {
                return this.tc_fiscal_year_from;
            }
            set
            {
                this.tc_fiscal_year_from = value;
            }
        }

        public DateTime Tc_fiscal_year_to
        {
            get
            {
                return this.tc_fiscal_year_to;
            }
            set
            {
                this.tc_fiscal_year_to = value;
            }
        }

        public string Tc_import_reg_no
        {
            get
            {
                return this.tc_import_reg_no;
            }
            set
            {
                this.tc_import_reg_no = value;
            }
        }

        public bool Tc_is_cottage_industry
        {
            get
            {
                return this.tc_is_cottage_industry;
            }
            set
            {
                this.tc_is_cottage_industry = value;
            }
        }

        public bool Tc_is_exporter
        {
            get
            {
                return this.tc_is_exporter;
            }
            set
            {
                this.tc_is_exporter = value;
            }
        }

        public bool Tc_is_importer
        {
            get
            {
                return this.tc_is_importer;
            }
            set
            {
                this.tc_is_importer = value;
            }
        }

        public bool Tc_is_other
        {
            get
            {
                return this.tc_is_other;
            }
            set
            {
                this.tc_is_other = value;
            }
        }

        public bool Tc_is_service_renderer
        {
            get
            {
                return this.tc_is_service_renderer;
            }
            set
            {
                this.tc_is_service_renderer = value;
            }
        }

        public bool Tc_is_supplier_manufacturer
        {
            get
            {
                return this.tc_is_supplier_manufacturer;
            }
            set
            {
                this.tc_is_supplier_manufacturer = value;
            }
        }

        public bool Tc_is_supplier_trader
        {
            get
            {
                return this.tc_is_supplier_trader;
            }
            set
            {
                this.tc_is_supplier_trader = value;
            }
        }

        public bool Tc_is_trnovr_tax_mnthly
        {
            get
            {
                return this.tc_is_trnovr_tax_mnthly;
            }
            set
            {
                this.tc_is_trnovr_tax_mnthly = value;
            }
        }

        public bool Tc_is_trnovr_tax_qrtrly
        {
            get
            {
                return this.tc_is_trnovr_tax_qrtrly;
            }
            set
            {
                this.tc_is_trnovr_tax_qrtrly = value;
            }
        }

        public bool Tc_is_trnovr_tax_yrly
        {
            get
            {
                return this.tc_is_trnovr_tax_yrly;
            }
            set
            {
                this.tc_is_trnovr_tax_yrly = value;
            }
        }

        public bool Tc_is_vat
        {
            get
            {
                return this.tc_is_vat;
            }
            set
            {
                this.tc_is_vat = value;
            }
        }

        public string Tc_trade_license_no
        {
            get
            {
                return this.tc_trade_license_no;
            }
            set
            {
                this.tc_trade_license_no = value;
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

        public string Tin_chairman
        {
            get
            {
                return this.tin_chairman;
            }
            set
            {
                this.tin_chairman = value;
            }
        }

        public string Tin_company
        {
            get
            {
                return this.Tin_company;
            }
            set
            {
                this.tin_company = value;
            }
        }

        public DateTime Trad_issuedate
        {
            get
            {
                return this.trad_issuedate;
            }
            set
            {
                this.trad_issuedate = value;
            }
        }

        public string Tradbrand
        {
            get
            {
                return this.tradbrand;
            }
            set
            {
                this.tradbrand = value;
            }
        }

        public int UserIdInsert
        {
            get
            {
                return this.userIdInsert;
            }
            set
            {
                this.userIdInsert = value;
            }
        }

        public string Vat_deducted_at_source
        {
            get
            {
                return this.vat_deducted_at_source;
            }
            set
            {
                this.vat_deducted_at_source = value;
            }
        }

        public string Vat_deducted_at_source_name
        {
            get
            {
                return this.vat_deducted_at_source_name;
            }
            set
            {
                this.vat_deducted_at_source_name = value;
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

        public string Withholding_entity
        {
            get
            {
                return this.withholding_entity;
            }
            set
            {
                this.withholding_entity = value;
            }
        }

        public OrgRegistrationInfoDAO()
        {
        }

        public DataTable CheckIsExistBranchName(int organID, string branchName)
        {
            return this.orgRegistrationInfo.CheckIsExistBranchName(organID, branchName);
        }

        public DataTable FullTableOrgBranchRegistrationInfo(int id, int branchID)
        {
            return this.orgRegistrationInfo.FullTableOrgBranchRegistrationInfo(id, branchID);
        }

        public DataTable FullTableOrgRegistrationInfo(int id)
        {
            return this.orgRegistrationInfo.FullTableOrgRegistrationInfo(id);
        }

        public DataTable GetAllBIN(string bin)
        {
            return this.orgRegistrationInfo.GetAllEBIN(bin);
        }

        public DataSet GetAllCircle()
        {
            return this.orgRegistrationInfo.GetAllCircle();
        }

        public DataTable GetAllDistrictInformation()
        {
            return this.orgRegistrationInfo.GetAllDistrictInformation();
        }

        public DataTable GetAllEtin(string etin)
        {
            return this.orgRegistrationInfo.GetAllETIN(etin);
        }

        public DataTable GetAllOrganizationName(string organizName)
        {
            return this.orgRegistrationInfo.GetAllOrganizationName(organizName);
        }

        public DataTable GetAllParties()
        {
            return this.orgRegistrationInfo.GetAllParties();
        }

        public DataTable GetAllPostOfficeformation()
        {
            return this.orgRegistrationInfo.GetAllPostOfficeformation();
        }

        public DataTable GetAllThanaInformation()
        {
            return this.orgRegistrationInfo.GetAllThanaInformation();
        }

        public DataTable GetAllUpazilaInformation()
        {
            return this.orgRegistrationInfo.GetAllUpazilaInformation();
        }

        public DataTable GetBankBranchName(int id)
        {
            return this.orgRegistrationInfo.GetBankNrachName(id);
        }

        public DataTable GetBankName()
        {
            return this.orgRegistrationInfo.GetBankName();
        }

        public DataTable GetBranchAddBrachRegistration(int id)
        {
            return this.orgRegistrationInfo.GetBranchAddBrachRegistration(id);
        }

        public DataTable GetBranchAddORGRegistration(int id)
        {
            return this.orgRegistrationInfo.GetBranchAddORGRegistration(id);
        }

        public DataSet GetBranchInfo(int branchID)
        {
            return this.orgRegistrationInfo.GetBranchInfo(branchID);
        }

        public DataTable GetBranchInfoAfetrsave(int organID)
        {
            return this.orgRegistrationInfo.GetBranchInfoAfetrsave(organID);
        }

        public DataTable GetBusinessProcessActivities()
        {
            return this.orgRegistrationInfo.GetBusinessProcessActivities();
        }

        public DataTable GetDeclaretion()
        {
            return this.orgRegistrationInfo.GetDeclaretion();
        }

        public DataTable GetEconomicInfo(string economicIds)
        {
            return this.orgRegistrationInfo.GetEconomicInfo(economicIds);
        }

        public DataTable GetEconomicPrcActivity()
        {
            return this.orgRegistrationInfo.GetEconomicProcessActivity();
        }

        public DataTable GetEconomicProcessActivities()
        {
            return this.orgRegistrationInfo.GetEconomicProcessActivities();
        }

        public DataTable GetFullReport(int orgID)
        {
            return this.orgRegistrationInfo.FullReport(orgID);
        }

        public DataTable GetfullTableOrganizationInfo(int tableID)
        {
            return this.orgRegistrationInfo.GetfullTableOrganizationInfo(tableID);
        }

        public DataTable GetFullTabOrganizationName()
        {
            return this.orgRegistrationInfo.GetFullTabOrganizationName();
        }

        public DataTable GetHSCode()
        {
            return this.orgRegistrationInfo.GetHScode();
        }

        public DataSet GetMasterID()
        {
            return this.orgRegistrationInfo.GetMasterID();
        }

        public DataTable GetNatureOfApplication()
        {
            return this.orgRegistrationInfo.GetNatureOfApplication();
        }

        public DataSet GetOrganizationInfo()
        {
            return this.orgRegistrationInfo.GetOganizationInfo();
        }

        public DataTable GetORGorBranch(int id)
        {
            return this.orgRegistrationInfo.GetORGorBranch(id);
        }

        public DataTable GetOtherTaxCollection()
        {
            return this.orgRegistrationInfo.GetOtherTaxCollection();
        }

        public DataTable GetPartyInfo(int partyId)
        {
            return this.orgRegistrationInfo.GetPartyInfo(partyId);
        }

        public DataTable GetPostOfficeformation(int dstrcID)
        {
            return this.orgRegistrationInfo.GetPostOfficeformation(dstrcID);
        }

        public DataTable GetRegistrationType()
        {
            return this.orgRegistrationInfo.GetRegistrationType();
        }

        public DataTable GetThanaInformation(int distrcID)
        {
            return this.orgRegistrationInfo.GetThanaInformation(distrcID);
        }

        public DataTable GetTypeOfBusinessOrganaization()
        {
            return this.orgRegistrationInfo.GetTypeOfBusinessOrganaization();
        }

        public DataTable GetTypeOfManufacture()
        {
            return this.orgRegistrationInfo.GetTypeofmenuf();
        }

        public DataTable GetTypeOfOWNERSHIP()
        {
            return this.orgRegistrationInfo.GetTypeofownership();
        }

        public DataTable GetTypeOfService()
        {
            return this.orgRegistrationInfo.GetTypeofservice();
        }

        public DataTable GetUpazilaInformation(int dstrID)
        {
            return this.orgRegistrationInfo.GetUpazilaInformation(dstrID);
        }

        public DataTable GetVatDeductedAtSource()
        {
            return this.orgRegistrationInfo.GetVatDeductedAtSource();
        }

        public DataTable LoadFullTableAllAddressBranchunit(int id)
        {
            return this.orgRegistrationInfo.LoadFullTableAllAddressBranchUnit(id);
        }

        public DataTable LoadFullTableAllAddressForBranchParmanentAddress(int id, int branchID)
        {
            return this.orgRegistrationInfo.LoadFullTableAllAddressForBranchParmanentAddress(id, branchID);
        }

        public DataTable LoadFullTableAllAddressForBranchRegPresentAdd(int id, int branchID)
        {
            return this.orgRegistrationInfo.LoadFullTableAllAddressForBranchRegPresentAdd(id, branchID);
        }

        public DataTable LoadFullTableAllAddressParmanentAddress(int id)
        {
            return this.orgRegistrationInfo.LoadFullTableAllAddressParmanentAddress(id);
        }

        public DataTable LoadFullTableAllAddressPresentAddress(int id)
        {
            return this.orgRegistrationInfo.LoadFullTableAllAddressPresentAddress(id);
        }

        public DataTable LoadFullTableOrgBankAccount(int id)
        {
            return this.orgRegistrationInfo.LoadFullTableOrgBankAccount(id);
        }

        public DataTable LoadFullTableOrgBranchBankAccount(int id, int branchID)
        {
            return this.orgRegistrationInfo.LoadFullTableOrgBranchBankAccount(id, branchID);
        }

        public DataTable LoadFullTablNatureOfApplication(int id)
        {
            return this.orgRegistrationInfo.LoadFullTablNatureOfApplication(id);
        }

        public DataTable LoadFullTablOwnerInformation(int id)
        {
            return this.orgRegistrationInfo.LoadFullTablOwnerInformation(id);
        }

        public bool SaveOrgRegistrationInfo()
        {
            string str = "INSERT INTO org_registration_info(Organization_id,organization_name,abbr_name,registration_type,parent_org_id,org_type_id_m,org_type_id_d,business_address,ba_phone,ba_email,ba_fax,factory_address,fa_phone,fa_email,fa_fax,head_office_address,ho_phone,ho_email,ho_fax,tin_company,previous_registration_no,tc_is_vat,tc_is_cottage_industry,tc_is_other,tc_is_supplier_manufacturer,tc_is_supplier_trader,tc_is_service_renderer,tc_is_importer,tc_is_exporter,tc_trade_license_no,tc_authority,tc_fiscal_year_from,tc_fiscal_year_to,tc_import_reg_no,tc_export_reg_no,Is_deleted,owner_permanent_address,ow_phone,ow_email,ow_fax,tc_is_trnovr_tax_yrly,tc_is_trnovr_tax_qrtrly,tc_is_trnovr_tax_mnthly,reg_effictive_date,circle_id,tin_chairman,national_id_of_chairman,registration_no,business_activity,business_type,register_persoon_name,registration_type_n,Amount,amount_in_word,vat_deducted_at_source,other_tax_collection,registration_date,application_nature,business_process_activity,economic_process_activity,business_type_Name,vat_deducted_at_source_name,other_tax_collection_name,application_nature_name,business_process_activity_name,economic_process_activity_name,is_vat_deduct) ";
            object[] organizationName = new object[] { " Values(nextval('organization_id_seq'),'", this.organization_name, "', '", this.abbr_name, "', ", this.registration_type, ",", this.parent_org_id, ", ", this.org_type_id_m, ",", this.Org_type_id_d, ",'", this.business_address, "','", this.ba_phone, "','", this.ba_email, "','", this.ba_fax, "','", this.factory_address, "','", this.fa_phone, "','", this.fa_email, "','", this.fa_fax, "','", this.head_office_address, "','", this.ho_phone, "','", this.ho_email, "','", this.ho_fax, "','", this.tin_company, "','", this.previous_registration_no, "',", this.tc_is_vat, ",", this.tc_is_cottage_industry, ",", this.tc_is_other, ",", this.tc_is_supplier_manufacturer, ",", this.tc_is_supplier_trader, ",", this.tc_is_service_renderer, ",", this.tc_is_importer, ",", this.tc_is_exporter, ",'", this.tc_trade_license_no, "','", this.tc_authority, "','", this.FiscalDateFrom, "','", this.fiscalDateTo, "','", this.tc_import_reg_no, "','", this.tc_export_reg_no, "',", this.is_deleted, ",'", this.owner_permanent_address, "','", this.ow_phone, "','", this.ow_email, "','", this.ow_fax, "',", this.tc_is_trnovr_tax_yrly, ",", this.tc_is_trnovr_tax_qrtrly, ",", this.tc_is_trnovr_tax_mnthly, ",'", this.reg_effictive_date, "',", this.circle_id, ",'", this.tin_chairman, "','", this.national_id_of_chairman, "','", this.registration_no, "','", this.business_activity, "','", this.business_type, "','", this.register_persoon_name, "',", this.registration_type_n, ",", this.amount, ",'", this.amount_in_word, "','", this.vat_deducted_at_source, "','", this.other_tax_collection, "','", DateTime.ParseExact(this.registration_date, "dd/MM/yyyy", null), "','", this.application_nature, "','", this.business_process_activity, "','", this.economic_process_activity, "','", this.business_type_Name, "','", this.vat_deducted_at_source_name, "','", this.other_tax_collection_name, "','", this.application_nature_name, "',' ", this.business_process_activity_name, "','", this.economic_process_activity_name, "',", this.is_vat_deduct, ")" };
            string str1 = string.Concat(str, string.Concat(organizationName));
            return this.orgRegistrationInfo.ExecuteDMLWithOnlyQuery(str1);
        }
    }
}