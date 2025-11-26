using System;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetBankBranchBLL
    {
        private DBUtility DBUtil = new DBUtility();

        public SetBankBranchBLL()
        {
        }

        public bool deleteBank(int intBranchId)
        {
            string str = string.Concat("UPDATE set_bank_branch SET Is_deleted=true WHERE branch_id = '", intBranchId, "'");
            return this.DBUtil.ExecuteDML(str);
        }

        public DataTable dtGetBankBranchByBankandUnionId(int intBankId, int unionId)
        {
            object[] objArray = new object[] { "SELECT * from set_bank_branch where Is_deleted=false and bank_id='", intBankId, "' and union_id=", unionId };
            string str = string.Concat(objArray);
            return this.DBUtil.GetDataTable(str);
        }

        public DataTable dtGetBankBranchByBankId(int intBankId)
        {
            string str = string.Concat("SELECT * from set_bank_branch where Is_deleted=false and bank_id='", intBankId, "'");
            return this.DBUtil.GetDataTable(str);
        }

        public DataSet getAllBranch()
        {
            return this.DBUtil.GetDataSet("select sbb.*, sb.bank_name,su.upazila_name, suw.union_ward_name \r\n                            from set_bank_branch sbb\r\n                            left outer join set_bank sb on sbb.bank_id=sb.bank_id \r\n                            inner join set_upazila su on sbb.upazila_id=su.upazila_id \r\n                            inner join set_union_ward suw on sbb.union_id=suw.union_ward_id\r\n                            where sbb.Is_deleted='false' order by sb.bank_name, sbb.branch_name", "Branch");
        }

        public DataSet getBankBranchByBankId(int intBankId)
        {
            string str = string.Concat("SELECT * from set_bank_branch where Is_deleted=false and bank_id='", intBankId, "'");
            return this.DBUtil.GetDataSet(str, "bankBranch");
        }

        public DataSet getBranch(int intBranchId)
        {
            string str = string.Concat(" SELECT * from set_bank_branch where branch_id  = '", intBranchId, "'");
            return this.DBUtil.GetDataSet(str, "branch");
        }

        public bool InsertBranch(SetBankBranchDAO objBranch)
        {
            objBranch.BranchId = Convert.ToInt32(this.DBUtil.GetSingleValue("SELECT  nextval('bank_branch_id_seq')"));
            object[] branchId = new object[] { "INSERT INTO set_bank_branch (branch_id,branch_name, branch_address, branch_email, phone_one,phone_two, bank_id, upazila_id, union_id) VALUES    (", objBranch.BranchId, ", upper('", objBranch.BranchName, "'),'", objBranch.Address, "','", objBranch.Email, "','", objBranch.Phone, "','", objBranch.Phone2, "',", objBranch.BankId, ",", objBranch.UpazilaId, ",", objBranch.UnionWardId, ")" };
            string str = string.Concat(branchId);
            return this.DBUtil.ExecuteDML(str);
        }

        public bool updateBranch(SetBankBranchDAO objSBBDAO)
        {
            object[] branchName = new object[] { " UPDATE set_bank_branch  SET branch_name='", objSBBDAO.BranchName, "', \r\n                                                            branch_address='", objSBBDAO.Address, "', \r\n                                                            branch_email='", objSBBDAO.Email, "', \r\n                                                            phone_one='", objSBBDAO.Phone, "', \r\n                                                            phone_two='", objSBBDAO.Phone2, "', \r\n                                                            bank_id=", objSBBDAO.BankId, ", \r\n                                                            upazila_id=", objSBBDAO.UpazilaId, ", \r\n                                                            union_id=", objSBBDAO.UnionWardId, "\r\n                                                            where branch_id=", objSBBDAO.BranchId };
            string str = string.Concat(branchName);
            return this.DBUtil.ExecuteDML(str);
        }
    }
}