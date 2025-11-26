using System;
using System.Collections;
using System.Data;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class DadoBLL
    {
        private DBUtility db = new DBUtility();

        public DadoBLL()
        {
        }

        private ArrayList AddDadoDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, long DadoID)
        {
            if (arrDeailDAO.Count > 0)
            {
                for (int i = 0; i < arrDeailDAO.Count; i++)
                {
                    DadoDAO dadoDAO = new DadoDAO();
                    dadoDAO = (DadoDAO)arrDeailDAO[i];
                    dadoDAO.DetailID = (long)Convert.ToInt32(this.db.GetSingleValue("SELECT  nextval('dado_detail_id_seq')"));
                    object[] dadoID = new object[] { "INSERT INTO trns_dado_detail(dado_id, row_no, item_id, unit_id, quantity, unit_price, used_quantity_price, \r\n                                                             cd, rd, sd, vat, ait, atv, tti, at, import_tax, total_amount, detail_id)\r\n                                VALUES (", DadoID, ", ", dadoDAO.RowNo, ", ", dadoDAO.ItemID, ",", dadoDAO.UnitID, ", ", dadoDAO.Quantity, ",", dadoDAO.UnitPrice, ",\r\n                                        ", dadoDAO.UsedQuantityPrice, ",", dadoDAO.CD, ",", dadoDAO.RD, ",", dadoDAO.SD, ",", dadoDAO.VAT, ",", dadoDAO.AIT, ",\r\n                                        ", dadoDAO.ATV, ",", dadoDAO.TTI, ",", dadoDAO.AT, ",", dadoDAO.ImportTax, ",", dadoDAO.Total, ",", dadoDAO.DetailID, " \r\n                                        )" };
                    arrDetailList.Add(string.Concat(dadoID));
                }
            }
            return arrDetailList;
        }

        public DataTable GetAllTax(int ItemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] itemID = new object[] { "select max(Cd)Cd,max(Rd)Rd,max(Sd)Sd, max(Vat)Vat,max(Ait)Ait,max(Atv)Atv,max(Tti)Tti,max(AT_)AT_  from (\r\n                            select tax_value CD,0 RD,0 Sd,0 Vat,0 Ait, 0 Atv,0 Tti,0 AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '1'\r\n                            union all\r\n                            select 0 CD,tax_value RD,0 Sd,0 Vat,0 Ait, 0 Atv,0 Tti,0 AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '2'\r\n                            union all\r\n                            select 0 CD,0 RD,tax_value Sd,0 Vat,0 Ait, 0 Atv,0 Tti,0 AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '3'\r\n                            union all\r\n                            select 0 CD,0 RD,0 Sd,tax_value Vat,0 Ait, 0 Atv,0 Tti,0 AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '4'\r\n                            union all\r\n                            select 0 CD,0 RD,0 Sd,0 Vat,tax_value Ait, 0 Atv,0 Tti,0 AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '5'\r\n                            union all\r\n                            select 0 CD,0 RD,0 Sd,0 Vat,0 Ait, tax_value Atv,0 Tti,0 AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '6'\r\n                            union all\r\n                            select 0 CD,0 RD,0 Sd,0 Vat,0 Ait, 0 Atv,tax_value Tti,0 AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '7'\r\n                            union all\r\n                            select 0 CD,0 RD,0 Sd,0 Vat,0 Ait, 0 Atv,0 Tti,tax_value AT_\r\n                            from \r\n                            item_tax_values\r\n                            where item_id = ", ItemID, "  AND is_current  = true and tax_id = '8'\r\n                            )mqmm " };
                string str = string.Concat(itemID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetChallanByItemType(DateTime fDate, DateTime tDate, string type)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] objArray = new object[] { "select challan_id, challan_no \r\n                            from trns_sale_master\r\n                            where date_challan >= to_date('", fDate, "','MM/dd/yyyy')\r\n                            and date_challan <= to_date('", tDate, "','MM/dd/yyyy')\r\n                            and is_deleted = false\r\n                            and is_dado = false\r\n                            and trans_type = '", type, "'" };
                string str = string.Concat(objArray);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetDetailsByItemID(int PriceID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select i.item_id, i.item_name,iu.unit_id, iu.unit_code unit_name, i.hs_code,pri.quantity_total Quantity,\r\n                            (select purchase_unit_price from trns_purchase_detail where item_id = pri.item_id order by  challan_id desc limit 1)\r\n                            from price_raw_item pri\r\n                            inner join item i on pri.item_id = i.item_id\r\n                            inner join item_unit iu on i.unit_id = iu.unit_id\r\n                            where pri.is_deleted = false\r\n                            and i.is_deleted = false\r\n                            and price_id = ", PriceID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetDetailsByPriceandItemID(int PriceID, int itemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                object[] priceID = new object[] { "select i.item_id, i.item_name,iu.unit_id, iu.unit_code unit_name, i.hs_code,pri.quantity_total Quantity,\r\n                            (select purchase_unit_price from trns_purchase_detail where item_id = pri.item_id order by  challan_id desc limit 1)\r\n                            from price_raw_item pri\r\n                            inner join item i on pri.item_id = i.item_id\r\n                            inner join item_unit iu on i.unit_id = iu.unit_id\r\n                            where pri.is_deleted = false\r\n                            and i.is_deleted = false\r\n                            and pri.price_id = ", PriceID, " \r\n                            and pri.item_id = ", itemID, " " };
                string str = string.Concat(priceID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetIngredianceByPriceID(int PriceID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select i.item_id, i.item_name,iu.unit_id, iu.unit_name, i.hs_code,pri.quantity_total Quantity\r\n                            from price_raw_item pri\r\n                            inner join item i on pri.item_id = i.item_id\r\n                            inner join item_unit iu on i.unit_id = iu.unit_id\r\n                            where pri.is_deleted = false\r\n                            and i.is_deleted = false\r\n                            and price_id = ", PriceID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetItemByChallanID(long ChallanID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select i.item_id, i.item_name ||' - '|| i.hs_code item_name\r\n                            from trns_sale_detail tsd \r\n                            inner join item i on tsd.item_id = i.item_id\r\n                            where i.is_deleted = false\r\n                            and tsd.challan_id = ", ChallanID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetPriceDeclarationNoByItemID(int ItemID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select pi.price_id, pi.price_declaration_no, iu.unit_id, iu.unit_name\r\n                            from price_item pi\r\n                            inner join item_unit iu on pi.unit_id = iu.unit_id\r\n                            where pi.price_declaration_no != 'No'\r\n                            and pi.is_deleted = false\r\n                            and pi.item_id = ", ItemID);
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public decimal GetSaleQuantityByCIDIID(long CID, int IID)
        {
            decimal num = new decimal(1);
            try
            {
                object[] cID = new object[] { " select quantity \r\n                            from trns_sale_detail\r\n                            where challan_id = ", CID, "\r\n                            and item_id = ", IID, " " };
                string str = string.Concat(cID);
                object singleValue = this.db.GetSingleValue(str);
                if (singleValue != null)
                {
                    num = Convert.ToDecimal(singleValue);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return num;
        }

        public bool InsertDadoMasterData(DadoMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            bool flag = false;
            ArrayList arrayLists = new ArrayList();
            try
            {
                objMDAO.DadoID = (long)Convert.ToInt32(this.db.GetSingleValue("SELECT  nextval('dado_id_seq')"));
                object[] dadoID = new object[] { "INSERT INTO trns_dado_master(dado_id, sale_challan_id, sale_challan_no, price_declaration_id, price_declaration_no,apply_date, trns_type, product_id, organization_id, \r\n                        org_branch_id,user_id_insert)\r\n      VALUES ( ", objMDAO.DadoID, ",", objMDAO.SaleChallanID, ", '", objMDAO.SaleChallanNo, "', ", objMDAO.PriceDclarationID, ", '", objMDAO.PriceDeclarationNo, "', to_timestamp('", objMDAO.ApplyDate.ToString("MM/dd/yyyy HH:mm"), "','MM/dd/yyyy HH24:MI'),\r\n             '", objMDAO.TrnsType, "',", objMDAO.ProductID, ",", objMDAO.OrganizationID, ",", objMDAO.OrgBranchID, ",", objMDAO.UserIDInsert, " )" };
                arrayLists.Add(string.Concat(dadoID));
                arrayLists = this.AddDadoDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.DadoID);
                object[] userIDInsert = new object[] { "UPDATE trns_sale_master SET is_dado=true, User_id_update=", objMDAO.UserIDInsert, ", Date_update = to_timestamp('", null, null, null };
                userIDInsert[3] = objMDAO.ApplyDate.ToString("MM/dd/yyyy HH:mm");
                userIDInsert[4] = "','MM/dd/yyyy HH24:MI') WHERE challan_id=";
                userIDInsert[5] = objMDAO.SaleChallanID;
                arrayLists.Add(string.Concat(userIDInsert));
                flag = this.db.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }
    }
}