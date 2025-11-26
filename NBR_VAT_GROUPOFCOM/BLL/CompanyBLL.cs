using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class CompanyBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public CompanyBLL()
        {
        }

        public DataSet dsOgrInfo(int intOrgId)
        {
            string str = string.Concat("select organization_name,business_address,tin_company,area_id \r\nfrom org_registration_info where Is_deleted=false  and Organization_id='", intOrgId, "'");
            return this.DBUtil.GetDataSet(str, "Country");
        }

        public DataSet getAllOrganization()
        {
            return this.DBUtil.GetDataSet("select Organization_id, Organization_name from org_registration_info where Is_deleted=false Order by Organization_name", "ParentOrganization");
        }

        public DataSet getAllParentOrganization()
        {
            return this.DBUtil.GetDataSet("select Organization_id, Organization_name from org_registration_info where Is_deleted=false and registration_type=true Order by Organization_name", "ParentOrganization");
        }

        public DataSet getAllVATArea()
        {
            return this.DBUtil.GetDataSet("select area_id, area_name from vat_area where Is_deleted=false order by area_name", "AllVATArea");
        }

        public DataSet getAllVATAreaByVATCircle(int intVATCircleID)
        {
            string str = string.Concat("select area_id, area_name from vat_area where Is_deleted=false and circle_id='", intVATCircleID, "' order by area_name");
            return this.DBUtil.GetDataSet(str, "VATAreaByVATCircle");
        }

        public DataSet getAllVATCircle()
        {
            return this.DBUtil.GetDataSet("select circle_id, circle_name from vat_circle where Is_deleted=false order by circle_name", "VATCircle");
        }

        public DataSet getAllVATCircleByVATDivision(int intVATDivisionID)
        {
            string str = string.Concat("select circle_id, circle_name from vat_circle where Is_deleted=false and division_id='", intVATDivisionID, "' order by circle_name");
            return this.DBUtil.GetDataSet(str, "VATCircleByVATDivision");
        }

        public DataSet getAllVATCommissionerate()
        {
            return this.DBUtil.GetDataSet("select comm_id, comm_name from vat_commissionerate where Is_deleted=false order by comm_name", "VATCommissionerate");
        }

        public DataSet getAllVATDivision()
        {
            return this.DBUtil.GetDataSet("Select division_id, division_name from vat_division where Is_deleted=false order by division_name", "VATDivision");
        }

        public DataSet getAllVATDivisionByVATCommissionerate(int intCommissionerateID)
        {
            string str = string.Concat("Select division_id, division_name from vat_division where Is_deleted=false and comm_id='", intCommissionerateID, "' order by division_name");
            return this.DBUtil.GetDataSet(str, "VATDivisionByCommissionerate");
        }

        public DataSet getFullOrganizationInfo(int intOrganizationID)
        {
            string str = string.Concat("select oi.*, va.circle_code,orgad.operation_address from org_registration_info oi \r\n              inner join vat_circle va on oi.circle_id=va.circle_id\r\n              inner join org_reg_address orgad on oi.organization_id=orgad.organization_id\r\n              where oi.Is_deleted=false and oi.Organization_id='", intOrganizationID, "'");
            return this.DBUtil.GetDataSet(str, "FullOrganizationInfo");
        }

        public bool InsertCompany(CompanyDAO objCDAO)
        {
            object[] objArray = new object[] { "insert INTO org_registration_info(organization_name,abbr_name,registration_type,parent_org_id,org_type_id_m,\r\norg_type_id_d,business_address,ba_phone,ba_email,\r\nba_fax,factory_address,fa_phone,fa_email,fa_fax,\r\nhead_office_address,ho_phone,ho_email,ho_fax,\r\ntin_company,previous_registration_no,tc_is_vat,tc_is_cottage_industry,tc_is_other,\r\ntc_is_supplier_manufacturer,tc_is_supplier_trader,tc_is_service_renderer,tc_is_importer,\r\ntc_is_exporter,tc_trade_license_no,tc_authority,tc_fiscal_year_from, tc_fiscal_year_to,\r\ntc_import_reg_no,tc_export_reg_no,owner_permanent_address,ow_phone,\r\now_email,ow_fax,tc_is_trnovr_tax_yrly,tc_is_trnovr_tax_qrtrly,tc_is_trnovr_tax_mnthly,\r\nreg_effictive_date, area_id,tin_chairman,national_id_of_chairman,registration_no,business_activity,business_type) \r\nVALUES ('", objCDAO.strOrganizationName, "','", objCDAO.strAbbrName, "','", objCDAO.boolRegistrationType, "','", objCDAO.intParentOrgID, "','", objCDAO.intOrgTypeM, "','", objCDAO.intOrgTypeD, "','", objCDAO.strBusinessAddress, "','", objCDAO.strBusinessPhone, "','", objCDAO.strBusinessEmail, "','", objCDAO.strBusinessFax, "','", objCDAO.strFactoryAddress, "','", objCDAO.strFactoryPhone, "','", objCDAO.strFactoryEmail, "','", objCDAO.strFactoryFax, "','", objCDAO.strHeadOfficeAddress, "','", objCDAO.strHeadOfficePhone, "','", objCDAO.strHeadOfficeEmail, "','", objCDAO.strHeadOfficeFax, "','", objCDAO.strTINCompany, "','", objCDAO.strPreviousRegNo, "','", objCDAO.boolTCVAT, "','", objCDAO.boolTCCottageIndustry, "','", objCDAO.boolTCOther, "','", objCDAO.boolTCSupplierManufacturer, "','", objCDAO.boolTCSupplierTrader, "','", objCDAO.boolTCServiceRenderer, "','", objCDAO.boolTCImporter, "','", objCDAO.boolTCExporter, "','", objCDAO.strTCTradeLicenseNo, "','", objCDAO.strTCAuthority, "','", objCDAO.dtTCFiscalYearFrom, "','", objCDAO.dtTCFiscalYearTo, "','", objCDAO.strTCImportRegNo, "','", objCDAO.strTCExportRegNo, "','", objCDAO.strPermanentAddress, "','", objCDAO.strPermanentPhone, "','", objCDAO.strPermanentEmail, "','", objCDAO.strPermanentFax, "','", objCDAO.boolTCTrnOvrYrly, "','", objCDAO.boolTCTrnOvrQrtrly, "','", objCDAO.boolTCTrnOvrMnthly, "','", objCDAO.dtRegtrationEffctiveDate, "','", objCDAO.intAreaID, "','", objCDAO.strTINChairman, "','", objCDAO.strChairmanNationalID, "','", objCDAO.strBINNo, "','", objCDAO.strBusinessActivities, "','", objCDAO.strBusinessType, "')" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}