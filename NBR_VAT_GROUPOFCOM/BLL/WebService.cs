using AjaxControlToolkit;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class _WebService : WebService
    {
        private PriceDeclaretionBLL objPDBll = new PriceDeclaretionBLL();

        public _WebService()
        {
        }

        [ScriptMethod]
        [WebMethod(EnableSession = true)]
        public CascadingDropDownNameValue[] GetCategory(string knownCategoryValues, string category)
        {
            CascadingDropDownNameValue[] array;
            string connString = DBUtility.GetConnString();
            string str = HttpContext.Current.Session["ORGANIZATION_ID"].ToString();
            int num = Convert.ToInt32(HttpContext.Current.Session["master_organization_id"]);
            object[] objArray = new object[] { "SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY ic inner join org_registration_info o on o.organization_id=ic.organization_id WHERE CATEGORY_LEVEL = ", (short)1, " /*and (( category_type in ('I', 'L'))  OR (category_type in ('P'))) */ AND ic.IS_DELETED = false and (ic.organization_id=", str, " or is_for_all_bss_unit) and o.master_organization_id=", num, " ORDER BY CATEGORY_NAME " };
            string str1 = string.Concat(objArray);
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str1, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            int num1 = Convert.ToInt16(npgsqlDataReader["CATEGORY_ID"]);
                            string str2 = npgsqlDataReader["CATEGORY_NAME"].ToString();
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(str2, Convert.ToString(num1)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetCategoryNew(string knownCategoryValues)
        {
            string item = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["CATEGORY_ID"];
            string str = string.Format("SELECT CATEGORY_NAME, CATEGORY_ID FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1", new object[0]);
            return this.GetData(str).ToArray();
        }

        [ScriptMethod]
        [WebMethod]
        public string[] GetCustomerList(string prefixText, int count, string contextKey)
        {
            string[] array;
            ArrayList arrayLists = new ArrayList();
            string connString = DBUtility.GetConnString();
            string str = "select registration_id,registration_no from cutomer_registration ";
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            arrayLists.Add((string)npgsqlDataReader["registration_no"]);
                        }
                    }
                    array = (string[])arrayLists.ToArray(typeof(string));
                }
            }
            return array;
        }

        private List<CascadingDropDownNameValue> GetData(string query)
        {
            List<CascadingDropDownNameValue> cascadingDropDownNameValues;
            string connectionString = ConfigurationManager.ConnectionStrings["NBR_POS_ConnString"].ConnectionString;
            List<CascadingDropDownNameValue> cascadingDropDownNameValues1 = new List<CascadingDropDownNameValue>();
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString))
            {
                npgsqlConnection.Open();
                using (NpgsqlDataReader npgsqlDataReader = (new NpgsqlCommand(query, npgsqlConnection)).ExecuteReader())
                {
                    while (npgsqlDataReader.Read())
                    {
                        CascadingDropDownNameValue cascadingDropDownNameValue = new CascadingDropDownNameValue()
                        {
                            name = npgsqlDataReader[0].ToString(),
                            @value = npgsqlDataReader[1].ToString()
                        };
                        cascadingDropDownNameValues1.Add(cascadingDropDownNameValue);
                    }
                    npgsqlDataReader.Close();
                    npgsqlConnection.Close();
                    cascadingDropDownNameValues = cascadingDropDownNameValues1;
                }
            }
            return cascadingDropDownNameValues;
        }

        [ScriptMethod]
        [WebMethod]
        public CascadingDropDownNameValue[] GetDistricts(string knownCategoryValues, string category)
        {
            CascadingDropDownNameValue[] array;
            string connString = DBUtility.GetConnString();
            string str = "select district_id,district_name from set_district where IS_DELETED = false order by district_name";
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            short num = Convert.ToInt16(npgsqlDataReader["district_id"]);
                            string str1 = npgsqlDataReader["district_name"].ToString();
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(str1, Convert.ToString(num)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetItemByCategory(string knownCategoryValues)
        {
            string item = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["CategoryNId"];
            int num = Convert.ToInt32(item);
            string str = string.Format(string.Concat("SELECT DISTINCT I.ITEM_ID, I.ITEM_NAME,ct.PARENT_ID\r\n                                    FROM ITEM I LEFT OUTER JOIN ITEM_CATEGORY CT ON I.SUB_CATEGORY_ID = CT.CATEGORY_ID\r\n                                    WHERE I.IS_DELETED = false and CT.PARENT_ID = ", num, " ORDER BY ITEM_NAME"), new object[0]);
            return this.GetData(str).ToArray();
        }

        [WebMethod]
        public void GetItemByCategoryNew(int CategoryNId)
        {
            string connString = DBUtility.GetConnString();
            List<Item> items = new List<Item>();
            string str = string.Concat("SELECT DISTINCT I.ITEM_ID, I.ITEM_NAME,ct.PARENT_ID\r\n                                    FROM ITEM I LEFT OUTER JOIN ITEM_CATEGORY CT ON I.SUB_CATEGORY_ID = CT.CATEGORY_ID\r\n                                    WHERE I.IS_DELETED = false and CT.PARENT_ID = ", CategoryNId, " ORDER BY ITEM_NAME");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            Item item = new Item()
                            {
                                Id = Convert.ToInt16(npgsqlDataReader["ITEM_ID"]),
                                Name = npgsqlDataReader["ITEM_NAME"].ToString(),
                                CategoryNId = Convert.ToInt16(npgsqlDataReader["PARENT_ID"])
                            };
                            items.Add(item);
                        }
                    }
                }
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            base.Context.Response.Write(javaScriptSerializer.Serialize(items));
        }

        [WebMethod]
        public void GetItemCategoryNew()
        {
            string connString = DBUtility.GetConnString();
            List<CategoryN> categoryNs = new List<CategoryN>();
            string str = "SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = 1 ";
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            CategoryN categoryN = new CategoryN()
                            {
                                Id = Convert.ToInt16(npgsqlDataReader["CATEGORY_ID"]),
                                Name = npgsqlDataReader["CATEGORY_NAME"].ToString()
                            };
                            categoryNs.Add(categoryN);
                        }
                    }
                }
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            base.Context.Response.Write(javaScriptSerializer.Serialize(categoryNs));
        }

        [WebMethod]
        public void GetItemSubCategoryNew(int CategoryNId)
        {
            string connString = DBUtility.GetConnString();
            List<SetSubCategory> setSubCategories = new List<SetSubCategory>();
            string str = string.Concat("SELECT distinct ic.CATEGORY_ID,ic.CATEGORY_NAME,ic.PARENT_ID \r\n                                    FROM item_category as ic\r\n                                    inner join item as i on i.sub_category_id = ic.category_id\r\n                                    WHERE ic.parent_id = ", CategoryNId, " and category_level = 2 and i.is_deleted = false");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            SetSubCategory setSubCategory = new SetSubCategory()
                            {
                                Id = Convert.ToInt16(npgsqlDataReader["CATEGORY_ID"]),
                                Name = npgsqlDataReader["CATEGORY_NAME"].ToString(),
                                CategoryNId = Convert.ToInt16(npgsqlDataReader["parent_id"])
                            };
                            setSubCategories.Add(setSubCategory);
                        }
                    }
                }
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            base.Context.Response.Write(javaScriptSerializer.Serialize(setSubCategories));
        }

        [WebMethod]
        public double GetItemUnitConversionValue(string fUnit, string tUnit)
        {
            double num = 1;
            DataTable valueFromScriept = this.objPDBll.GetValueFromScriept(int.Parse(fUnit), int.Parse(tUnit));
            if (valueFromScriept != null && valueFromScriept.Rows.Count > 0)
            {
                num = Convert.ToDouble(valueFromScriept.Rows[0]["convert_value"]);
            }
            return num;
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetMachineCategory(string knownCategoryValues, string category)
        {
            CascadingDropDownNameValue[] array;
            string connString = DBUtility.GetConnString();
            string str = string.Concat("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE CATEGORY_LEVEL = ", (short)1, " AND IS_DELETED = false");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            int num = Convert.ToInt16(npgsqlDataReader["CATEGORY_ID"]);
                            string str1 = npgsqlDataReader["CATEGORY_NAME"].ToString();
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(str1, Convert.ToString(num)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetParty()
        {
            CascadingDropDownNameValue[] array;
            string connString = DBUtility.GetConnString();
            string str = string.Format("SELECT party_id, party_name FROM trns_party WHERE is_deleted = false and separator <> 3", new object[0]);
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            int num = Convert.ToInt16(npgsqlDataReader["party_id"]);
                            string str1 = npgsqlDataReader["party_name"].ToString();
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(str1, Convert.ToString(num)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [ScriptMethod]
        [WebMethod]
        public string[] GetProductByProductName(string prefixText, int count)
        {
            string[] array;
            ArrayList arrayLists = new ArrayList();
            string connString = DBUtility.GetConnString();
            string str = string.Concat("select Item_id,item_name from Item where item_name like upper(N'%", prefixText, "%')");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            arrayLists.Add((string)npgsqlDataReader["item_name"]);
                        }
                    }
                    array = (string[])arrayLists.ToArray(typeof(string));
                }
            }
            return array;
        }

        [ScriptMethod]
        [WebMethod]
        public string[] GetProductByProductName1(string prefixText, int count)
        {
            string[] array;
            ArrayList arrayLists = new ArrayList();
            string connString = DBUtility.GetConnString();
            string str = string.Concat("select i.Item_id, coalesce(i.item_name,'')||' '|| coalesce(ip.property_name,'') as item_name from Item i\r\n                                inner join trns_purchase_detail tpd\r\n                                on i.Item_id = tpd.Item_id\r\n                                inner join item_property ip\r\n                                on tpd.property_id1 = ip.property_id\r\n                                where i.item_name like upper(N'%", prefixText, "%')");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            arrayLists.Add((string)npgsqlDataReader["item_name"]);
                        }
                    }
                    array = (string[])arrayLists.ToArray(typeof(string));
                }
            }
            return array;
        }

        [ScriptMethod]
        [WebMethod]
        public string[] GetSaleProductByProductName(string prefixText, int count)
        {
            string[] array;
            ArrayList arrayLists = new ArrayList();
            string connString = DBUtility.GetConnString();
            string str = string.Concat("SELECT DISTINCT \r\n                                CASE when tpm.purchase_type = 'L' then i.item_name ||'-'||'Local'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code\r\n                                when tpm.purchase_type = 'I' then i.item_name ||'-'||'Import'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code \r\n                                when tpm.purchase_type = 'F' then i.item_name ||'-'||'Production'||'-'|| I.ITEM_SPECIFICATION||'-'||i.hs_code END ITEM_NAME,\r\n\r\n                                case when tpm.purchase_type = 'L' then i.item_id+.1\r\n                                when tpm.purchase_type = 'I' then i.item_id+.2 \r\n                                when tpm.purchase_type = 'F' then i.item_id+.3 end ITEM_ID\r\n\r\n                                FROM ITEM as i \r\n                                inner JOIN ITEM_CATEGORY as ic \r\n                                ON i.SUB_CATEGORY_ID = ic.CATEGORY_ID\r\n                                inner  join trns_purchase_detail as tpd\r\n                                on tpd.item_id = i.item_id\r\n                                inner join trns_purchase_master as tpm\r\n                                on tpd.challan_id = tpm.challan_id\r\n                                WHERE I.IS_DELETED = false AND item_name like upper(N'%", prefixText, "%')");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            arrayLists.Add((string)npgsqlDataReader["item_name"]);
                        }
                    }
                    array = (string[])arrayLists.ToArray(typeof(string));
                }
            }
            return array;
        }

        [ScriptMethod]
        [WebMethod(EnableSession = true)]
        public CascadingDropDownNameValue[] GetSubCategoryByCategory(string knownCategoryValues, string category)
        {
            int num;
            CascadingDropDownNameValue[] array;
            StringDictionary stringDictionaries = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (!stringDictionaries.ContainsKey("Category") || !int.TryParse(stringDictionaries["Category"], out num))
            {
                return null;
            }
            string connString = DBUtility.GetConnString();
            string str = string.Concat("SELECT CATEGORY_ID,CATEGORY_NAME FROM ITEM_CATEGORY WHERE PARENT_ID = ", num, "  AND IS_DELETED = false ORDER BY CATEGORY_NAME ");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            int num1 = Convert.ToInt32(npgsqlDataReader["CATEGORY_ID"]);
                            string item = (string)npgsqlDataReader["CATEGORY_NAME"];
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(item, Convert.ToString(num1)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetTypeofMesurement(string knownCategoryValues, string category)
        {
            CascadingDropDownNameValue[] array;
            string connString = DBUtility.GetConnString();
            string str = string.Concat("SELECT CODE_ID_D,CODE_NAME FROM APP_CODE_DETAIL WHERE CODE_ID_M = '", AllConstraint.measurementTypeMasterId, "' AND IS_DELETED = false ORDER BY CODE_NAME ");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            int num = Convert.ToInt16(npgsqlDataReader["CODE_ID_D"]);
                            string str1 = npgsqlDataReader["CODE_NAME"].ToString();
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(str1, Convert.ToString(num)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [ScriptMethod]
        [WebMethod]
        public CascadingDropDownNameValue[] GetUnionByUpazila(string knownCategoryValues, string category)
        {
            int num;
            CascadingDropDownNameValue[] array;
            StringDictionary stringDictionaries = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (!stringDictionaries.ContainsKey("Upazila") || !int.TryParse(stringDictionaries["Upazila"], out num))
            {
                return null;
            }
            string connString = DBUtility.GetConnString();
            string str = string.Concat("select union_ward_id,upper(union_ward_name) union_name from  set_union_ward where police_station_id  = ", num, " order by union_ward_name");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            short num1 = Convert.ToInt16(npgsqlDataReader["union_ward_id"]);
                            string item = (string)npgsqlDataReader["union_name"];
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(item, Convert.ToString(num1)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetUnitByMsntType(string knownCategoryValues, string category)
        {
            int num;
            CascadingDropDownNameValue[] array;
            StringDictionary stringDictionaries = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (!stringDictionaries.ContainsKey("msntType") || !int.TryParse(stringDictionaries["msntType"], out num))
            {
                return null;
            }
            string connString = DBUtility.GetConnString();
            string str = string.Concat("SELECT UNIT_ID,UNIT_NAME FROM ITEM_UNIT WHERE MEASUREMENT_ID_D = '", num, "' AND IS_DELETED = false ORDER BY UNIT_NAME ");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            int num1 = Convert.ToInt32(npgsqlDataReader["UNIT_ID"]);
                            string item = (string)npgsqlDataReader["UNIT_NAME"];
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(item, Convert.ToString(num1)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [ScriptMethod]
        [WebMethod]
        public CascadingDropDownNameValue[] GetUpazillasByDistrict(string knownCategoryValues, string category)
        {
            int num;
            CascadingDropDownNameValue[] array;
            StringDictionary stringDictionaries = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (!stringDictionaries.ContainsKey("District") || !int.TryParse(stringDictionaries["District"], out num))
            {
                return null;
            }
            string connString = DBUtility.GetConnString();
            string str = string.Concat("select police_station_id,police_station_name from set_police_station where district_id = ", num, " order by police_station_name ");
            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connString))
            {
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(str, npgsqlConnection))
                {
                    npgsqlConnection.Open();
                    List<CascadingDropDownNameValue> cascadingDropDownNameValues = new List<CascadingDropDownNameValue>();
                    using (NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader())
                    {
                        while (npgsqlDataReader.Read())
                        {
                            short num1 = Convert.ToInt16(npgsqlDataReader["police_station_id"]);
                            string item = (string)npgsqlDataReader["police_station_name"];
                            cascadingDropDownNameValues.Add(new CascadingDropDownNameValue(item, Convert.ToString(num1)));
                        }
                    }
                    array = cascadingDropDownNameValues.ToArray();
                }
            }
            return array;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}