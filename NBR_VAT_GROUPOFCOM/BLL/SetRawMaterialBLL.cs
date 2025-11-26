using System;
using System.Collections;
using System.Data;


namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class SetRawMaterialBLL
    {
        private DBUtility conDB = new DBUtility();

        public SetRawMaterialBLL()
        {
        }

        public DataTable GetFinishProduction()
        {
            return this.conDB.GetDataTable("Select * from item WHERE Product_type = 'C' ORDER BY item_name");
        }

        public DataTable GetRawMaterialSet(int itemId, int orgId)
        {
            object[] objArray = new object[] { "select m.material_set_id, \r\ncase ic.parent_id when 0 then ic.category_id else cat.category_id end CatIDRaw,\r\ncase ic.parent_id when 0 then ic.category_name else cat.category_name end CategoryNameRaw, \r\ncase ic.parent_id when 0 then 0 else ic.category_id end SubCatIDRaw,\r\ncase ic.parent_id when 0 then '' else ic.category_name end SubCategoryNameRaw, i.category_id, i.unit_id,\r\nd.row_no RowNo,d.raw_material_id RawMaterialID,  i.item_name  || '-' || i.hs_code RawMaterialName, d.Remarks, \r\ncase d.is_compulsory_material when true then 'true' else 'false' end IsCompulsory\r\nfrom set_raw_material_m m inner join set_raw_material_d d on m.material_set_id = d.material_set_id\r\ninner join Item i on i.Item_id = d.raw_material_id\r\nleft outer join item_category ic on ic.category_id = i.category_id\r\nleft outer join item_category cat on cat.category_id = ic.parent_id\r\n where m.finished_good_id = ", itemId, " and m.Is_deleted = false\r\n and m.Organization_id = ", orgId, " and m.material_set_id = (select max(material_set_id) from set_raw_material_m where finished_good_id = m.finished_good_id and  Organization_id = m.Organization_id)" };
            string str = string.Concat(objArray);
            return this.conDB.GetDataTable(str);
        }

        public bool InsertRawMaterialSet(SetRawMaterialMasterDAO objMDAO, ArrayList arrDeailDAO)
        {
            string str = "";
            ArrayList arrayLists = new ArrayList();
            objMDAO.MaterialSetID = Convert.ToInt32(this.conDB.GetSingleValue("SELECT  nextval('raw_material_set_id')"));
            string str1 = " NULL";
            string str2 = " NULL";
            string str3 = " NULL";
            string str4 = " NULL";
            string str5 = " NULL";
            if (objMDAO.PropertyID1 > 0)
            {
                str1 = objMDAO.PropertyID1.ToString();
            }
            if (objMDAO.PropertyID2 > 0)
            {
                str2 = objMDAO.PropertyID2.ToString();
            }
            if (objMDAO.PropertyID3 > 0)
            {
                str3 = objMDAO.PropertyID3.ToString();
            }
            if (objMDAO.PropertyID4 > 0)
            {
                str4 = objMDAO.PropertyID4.ToString();
            }
            if (objMDAO.PropertyID5 > 0)
            {
                str5 = objMDAO.PropertyID5.ToString();
            }
            object[] finishedGoodsID = new object[] { " select coalesce(max(material_set_id),0) from set_raw_material_m where finished_good_id = ", objMDAO.FinishedGoodsID, " and Organization_id = ", objMDAO.OrganizationID };
            str = string.Concat(finishedGoodsID);
            int num = Convert.ToInt32(this.conDB.GetSingleValue(str));
            if (((SetRawMaterialDetailDAO)arrDeailDAO[0]).MaterialSetID > 0)
            {
                arrayLists.Add(string.Concat("delete from set_raw_material_d where material_set_id = ", ((SetRawMaterialDetailDAO)arrDeailDAO[0]).MaterialSetID));
                objMDAO.MaterialSetID = ((SetRawMaterialDetailDAO)arrDeailDAO[0]).MaterialSetID;
            }
            else if (num <= 0)
            {
                object[] materialSetID = new object[] { "INSERT INTO set_raw_material_m(\r\n            material_set_id, finished_good_id, property_id1, property_id2, \r\n            property_id3, property_id4, property_id5, \r\n           User_id_insert,  Organization_id)\r\n    VALUES (", objMDAO.MaterialSetID, ", ", objMDAO.FinishedGoodsID, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", str5, ",  ", objMDAO.UserIdInsert, ", ", objMDAO.OrganizationID, " )" };
                arrayLists.Add(string.Concat(materialSetID));
            }
            else
            {
                arrayLists.Add(string.Concat("delete from set_raw_material_d where material_set_id = ", num));
                objMDAO.MaterialSetID = num;
            }
            for (int i = 0; i < arrDeailDAO.Count; i++)
            {
                str1 = " NULL";
                str2 = " NULL";
                str3 = " NULL";
                str4 = " NULL";
                str5 = " NULL";
                SetRawMaterialDetailDAO setRawMaterialDetailDAO = new SetRawMaterialDetailDAO();
                setRawMaterialDetailDAO = (SetRawMaterialDetailDAO)arrDeailDAO[i];
                if (setRawMaterialDetailDAO.PropertyID1 > 0)
                {
                    str1 = setRawMaterialDetailDAO.PropertyID1.ToString();
                }
                if (setRawMaterialDetailDAO.PropertyID2 > 0)
                {
                    str2 = setRawMaterialDetailDAO.PropertyID2.ToString();
                }
                if (setRawMaterialDetailDAO.PropertyID3 > 0)
                {
                    str3 = setRawMaterialDetailDAO.PropertyID3.ToString();
                }
                if (setRawMaterialDetailDAO.PropertyID4 > 0)
                {
                    str4 = setRawMaterialDetailDAO.PropertyID4.ToString();
                }
                if (setRawMaterialDetailDAO.PropertyID5 > 0)
                {
                    str5 = setRawMaterialDetailDAO.PropertyID5.ToString();
                }
                object[] objArray = new object[] { "INSERT INTO set_raw_material_d(\r\n            material_set_id, row_no, raw_material_id, property_id1, property_id2, \r\n            property_id3, property_id4, property_id5, Remarks, is_compulsory_material, \r\n             User_id_insert)\r\n    VALUES (", objMDAO.MaterialSetID, ", ", setRawMaterialDetailDAO.RowNo, ", ", setRawMaterialDetailDAO.RawMaterialID, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ", ", str5, ",  '", setRawMaterialDetailDAO.Remarks, "', ", setRawMaterialDetailDAO.IsCompulsory, ", ", setRawMaterialDetailDAO.UserIdInsert, " )" };
                arrayLists.Add(string.Concat(objArray));
            }
            return this.conDB.ExecuteBatchDML(arrayLists);
        }
    }
}

