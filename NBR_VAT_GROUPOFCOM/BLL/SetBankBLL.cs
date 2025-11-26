using System;
using System.Data;


namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetBankBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetBankBLL()
        {
        }

        public DataSet CheckBank(SetBankDAO objBank)
        {
            string str = string.Concat("select * from set_bank where bank_name=upper('", objBank.BankName, "') and is_deleted=true");
            return this.DBUtil.GetDataSet(str, "Bank");
        }

        public bool deleteBank(int intBankId)
        {
            string str = string.Concat("UPDATE set_bank SET Is_deleted=true WHERE bank_id = '", intBankId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public bool enableDeletedBank(SetBankDAO objBank)
        {
            string str = string.Concat("update set_bank set is_deleted = false  where bank_name=upper('", objBank.BankName, "') and is_deleted=true");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataSet getAllBank()
        {
            return this.DBUtil.GetDataSet(" SELECT * from set_bank where Is_deleted  = false Order by bank_name", "Bank");
        }

        public DataTable GetAllBank()
        {
            return this.DBUtil.GetDataTable(" SELECT * from set_bank where Is_deleted  = false Order by bank_name");
        }

        public DataSet getBank(int intBankId)
        {
            string str = string.Concat(" SELECT * from set_bank where bank_id  = '", intBankId, "'");
            return this.DBUtil.GetDataSet(str, "bank");
        }

        public DataTable GetBank(int intBankId)
        {
            string str = string.Concat(" SELECT * from set_bank where bank_id  = '", intBankId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBankbyBankName(string bankName)
        {
            string str = string.Concat(" SELECT * from set_bank where Is_deleted  = false and upper(bank_name) = '", bankName, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable GetBranchBankbyBranchName(string branchName)
        {
            string str = string.Concat(" SELECT * from set_bank_branch where Is_deleted  = false and upper(branch_name) = '", branchName, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public bool InsertBank(SetBankDAO objBank)
        {
            objBank.BankID = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('bank_id_seq')"));
            object[] bankID = new object[] { "INSERT INTO set_bank (bank_id,bank_name, short_name, bank_code, phone_one, phone_two,bank_email, bank_address, web_address) \r\n                            VALUES (", objBank.BankID, ", upper('", objBank.BankName, "'),'", objBank.ShortName, "','", objBank.BankCode, "','", objBank.Phone1, "',\r\n                                          '", objBank.Phone2, "','", objBank.Email, "','", objBank.Address, "','", objBank.Web, "')" };
            string str = string.Concat(bankID);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateBank(SetBankDAO objSBDAO)
        {
            object[] bankName = new object[] { " UPDATE set_bank SET bank_name = upper('", objSBDAO.BankName, "'), \r\n                                                    short_name='", objSBDAO.ShortName, "', \r\n                                                    bank_code='", objSBDAO.BankCode, "', \r\n                                                    phone_one='", objSBDAO.Phone1, "', \r\n                                                    phone_two='", objSBDAO.Phone2, "', \r\n                                                    bank_email='", objSBDAO.Email, "', \r\n                                                    bank_address='", objSBDAO.Address, "',\r\n                                                    web_address='", objSBDAO.Web, "'\r\n                                                    where bank_id = ", objSBDAO.BankID, " " };
            string str = string.Concat(bankName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}

