using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class TransPartyBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public TransPartyBLL()
        {
        }

        public bool deleteTrnsParty(string party)
        {
            string str = string.Concat("update trns_party\r\n                        set is_deleted = true\r\n                            where party_name = '", party, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public bool deleteTrnsPartyById(int partyId)
        {
            string str = string.Concat("update trns_party\r\n                        set is_deleted = true\r\n                            where party_id = ", partyId);
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable getAllParty()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select * from trns_party where is_deleted = false and organization_id=", num, " order by party_id desc");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getAllPartyForGrid()
        {
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            string str = string.Concat("select party_id,party_name,party_address,party_bin,owner_name,phone\r\n                    ,case when is_vds_deduct=true then 'Yes' else 'No' end is_vds_deduct\r\n                    ,case when is_vendor=true then 'Yes' else 'No' end is_vendor\r\n                    ,case when is_customer=true then 'Yes' else 'No' end is_customer\r\n                    ,case when is_importer=true then 'Yes' else 'No' end is_importer \r\n                    from trns_party where is_deleted = false and organization_id=", num, " order by party_id desc");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getAllUpazila()
        {
            return this.DBUtil.GetDataTable("select upazila_id,upazila_name from set_upazila where is_deleted = false");
        }

        public DataTable getAllUpazilaIdbyname(string upazilaName)
        {
            string str = string.Concat("select upazila_id,upazila_name from set_upazila where is_deleted = false and upper(upazila_name)='", upazilaName, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getBusinessInfo(int code_id_m, string bInfo)
        {
            string str = "";
            if (!string.IsNullOrEmpty(bInfo))
            {
                string str1 = str;
                string[] lower = new string[] { str1, " and (lower(code_name) like '%", bInfo.ToLower(), "%' or lower(code_short_name) like '%", bInfo.ToLower(), "%')" };
                str = string.Concat(lower);
            }
            string str2 = string.Concat("select code_id_d, code_name, code_short_name\r\n                        from app_code_detail\r\n                        where code_id_m=", code_id_m, str);
            return this.DBUtil.GetDataTable(str2);
        }

        public int getDeletedTrnsPartyId(string partyName, string partBin, string partyAddress)
        {
            string[] upper = new string[] { "select party_id from trns_party where upper(party_name) ='", Utilities.checkForSingleQuotes(partyName).ToUpper(), "' and party_tin='", partBin, "' and party_address='", partyAddress, "' and is_deleted=true" };
            string str = string.Concat(upper);
            return Convert.ToInt32(this.DBUtil.GetSingleValue(str));
        }

        public DataTable GetEconomicProcessActivity(string epaName)
        {
            string str = "";
            if (!string.IsNullOrEmpty(epaName))
            {
                string str1 = str;
                string[] lower = new string[] { str1, " and (lower(code_short_name) like '", epaName.ToLower(), "' or lower(code_name) like '", epaName.ToLower(), "')" };
                str = string.Concat(lower);
            }
            string str2 = string.Concat("select code_id_d, code_name, code_short_name from app_code_detail where code_id_m = 22 AND is_deleted=false ", str, " order by serial_no asc");
            return this.DBUtil.GetDataTable(str2);
        }

        public int GetLastPartyId()
        {
            return Convert.ToInt32(this.DBUtil.GetSingleValue("select party_id from trns_party order by date_insert desc limit 1"));
        }

        public DataTable getOrganizationWiseParty()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("select * from trns_party where is_deleted = false AND organization_id=", num, " order by party_id desc");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getOrganizationWisePartyForImport()
        {
            DataTable dataTable;
            try
            {
                int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string str = string.Concat("SELECT party_id,case when party_code ='' then party_name else party_name ||'('|| party_code||')' end party_name,party_bin,party_address,national_id_no,ultimate_destination,reg_type,is_vds_deduct from trns_party where separator=1 and Is_deleted = false and is_importer=true  and  organization_id=", num, " and party_id != -999 order by party_name");
                dataTable = this.DBUtil.GetDataTable(str);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return dataTable;
        }

        public DataTable getParty()
        {
            return this.DBUtil.GetDataTable("select * from trns_party where is_deleted = false");
        }

        public DataTable getPartyByPartyID(int partyID)
        {
            string str = string.Concat("select * from trns_party where is_deleted = false and party_id = ", partyID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyfromProduction(int partyID)
        {
            string str = string.Concat("select * from trns_production_master where is_deleted = false and party_id = ", partyID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyfromPurchase(int partyID)
        {
            string str = string.Concat("select * from trns_purchase_master where is_deleted = false and party_id = ", partyID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPartyfromSale(int partyID)
        {
            string str = string.Concat("select * from trns_sale_master where is_deleted = false and party_id = ", partyID);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable getPurchaseParty()
        {
            return this.DBUtil.GetDataTable("select distinct tp.party_name, tp.party_id, tp.party_address, tp.party_bin from trns_party tp inner join trns_purchase_master tpm on tpm.party_id = tp.party_id");
        }

        public DataTable getSaleParty()
        {
            return this.DBUtil.GetDataTable("select distinct tp.party_name, tp.party_id, tp.party_address, tp.party_bin from trns_party tp inner join trns_sale_master tpm on tpm.party_id = tp.party_id");
        }

        public int getTrnsParty(string partyName)
        {
            string str = string.Concat("select party_id from trns_party where upper(party_name) = '", Utilities.checkForSingleQuotes(partyName).ToUpper(), "'");
            return Convert.ToInt32(this.DBUtil.GetSingleValue(str));
        }

        public DataTable getVDSData(int code_id_m, string vdsName)
        {
            string str = "";
            if (!string.IsNullOrEmpty(vdsName))
            {
                str = string.Concat(str, " and lower(code_name) like '", vdsName.ToLower(), "'");
            }
            object[] codeIdM = new object[] { "select code_name, code_id_d from app_code_detail where code_id_m= ", code_id_m, str, " AND IS_DELETED = false" };
            string str1 = string.Concat(codeIdM);
            return this.DBUtil.GetDataTable(str1);
        }

        public bool insertPartyFromExcel(ArrayList list)
        {
            ArrayList arrayLists = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                TransPartyDAO transPartyDAO = new TransPartyDAO();
                transPartyDAO = (TransPartyDAO)list[i];
                object[] transPartyName = new object[] { "INSERT INTO trns_party (party_name,party_tin,party_address,ultimate_destination,owner_name,phone,email,web,User_id_insert,party_bin,vds,is_vds_deduct,reg_type) VALUES ( upper('", transPartyDAO.TransPartyName, "'),'", transPartyDAO.PartyBIN, "','", transPartyDAO.PartAddress, "','", transPartyDAO.UltimateDesignation, "','", transPartyDAO.OwnerName, "','", transPartyDAO.Phone, "','", transPartyDAO.Email, "','", transPartyDAO.WebAddress, "',", transPartyDAO.UserID, ",'", transPartyDAO.PartyBIN, "',", transPartyDAO.VDS, ",", transPartyDAO.IsVDS, ",", transPartyDAO.RegType, ")" };
                arrayLists.Add(string.Concat(transPartyName));
            }
            return this.DBUtil.ExecuteBatchDML(arrayLists);
        }

        public bool insertTransParty(TransPartyDAO objTransParty)
        {
            object[] objArray = new object[] { "INSERT INTO trns_party (party_name,party_tin,party_address,ultimate_destination,owner_name,phone,email,web,User_id_insert,party_bin,vds,is_vds_deduct,reg_type,national_id_no,is_excise_duty,is_development_surcharge,is_information_technology,is_health_safety,is_environment_safety,area_of_mfg_id,business_info_id,major_area_of_ecn_activity,is_vendor,is_customer,organization_id,credit_limit,party_code,is_importer,upazila_id) VALUES ( upper('", Utilities.checkForSingleQuotes(objTransParty.TransPartyName), "'),'", objTransParty.PartyTIN, "','", Utilities.checkForSingleQuotes(objTransParty.PartAddress), "','", objTransParty.UltimateDesignation, "','", objTransParty.OwnerName, "','", objTransParty.Phone, "','", objTransParty.Email, "','", objTransParty.WebAddress, "',", objTransParty.UserID, ",'", objTransParty.PartyBIN, "',", objTransParty.VDS, ",", objTransParty.IsVDS, ",", objTransParty.RegType, ",'", objTransParty.nationalIdNo, "',", objTransParty.isExciseDuty, ",", objTransParty.isDevelopmentSurcharge, ",", objTransParty.isInformationTechnology, ",", objTransParty.isHealthSafety, ",", objTransParty.isEnvironmentSafety, ",", objTransParty.AreaOfManufacturing, ",", objTransParty.BusinessInfo, ",'", objTransParty.EconomicProcess, "',", objTransParty.IsVendor, ",", objTransParty.IsCustomer, ",", objTransParty.OrganizationID, ",", objTransParty.CreditLimit, ",'", objTransParty.PartyCode, "',", objTransParty.IsImporter, ",", objTransParty.upazilaID, ")" };
            string str = string.Concat(objArray);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool reenableDeletedTrnsPartyById(string partyID)
        {
            string str = string.Concat("update trns_party set is_deleted=false where party_id=", Convert.ToInt32(partyID));
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateTrnsParty(TransPartyDAO objTransParty)
        {
            object[] transPartyName = new object[] { "update trns_party\r\n                        set party_name = '", objTransParty.TransPartyName, "',\r\n                            phone = '", objTransParty.Phone, "',\r\n                            party_bin = '", objTransParty.PartyBIN, "',\r\n                            party_tin = '", objTransParty.PartyBIN, "',\r\n                            email='", objTransParty.Email, "',\r\n                            ultimate_destination = '", objTransParty.UltimateDesignation, "',\r\n                            web='", objTransParty.WebAddress, "',\r\n                            owner_name='", objTransParty.OwnerName, "',\r\n                            vds=", objTransParty.VDS, ",\r\n                            is_vds_deduct=", objTransParty.IsVDS, ",\r\n                            reg_type=", objTransParty.RegType, ",\r\n                            party_address='", objTransParty.PartAddress, "',\r\n                            national_id_no='", objTransParty.nationalIdNo, "',\r\n                            is_excise_duty=", objTransParty.isExciseDuty, ",\r\n                            is_development_surcharge=", objTransParty.isDevelopmentSurcharge, ",\r\n                            is_information_technology=", objTransParty.isInformationTechnology, ",\r\n                            is_health_safety=", objTransParty.isHealthSafety, ",\r\n                            is_environment_safety=", objTransParty.isEnvironmentSafety, ",\r\n                            area_of_mfg_id=", objTransParty.AreaOfManufacturing, ",\r\n                            business_info_id=", objTransParty.BusinessInfo, ",\r\n                            major_area_of_ecn_activity='", objTransParty.EconomicProcess, "',\r\n                            is_vendor=", objTransParty.IsVendor, ",\r\n                            is_customer=", objTransParty.IsCustomer, ",\r\n                            credit_limit=", objTransParty.CreditLimit, ",\r\n                            party_code='", objTransParty.PartyCode, "',\r\n                            is_importer=", objTransParty.IsImporter, ",\r\n                            upazila_id=", objTransParty.upazilaID, "\r\n                            where party_id = ", objTransParty.PartyID };
            string str = string.Concat(transPartyName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}