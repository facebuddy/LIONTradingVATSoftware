using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Linq;
namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class Utilities
    {
        public Utilities()
        {
        }

        public static string checkForAschi(string str)
        {
            foreach (KeyValuePair<string, string> keyValuePair in new Dictionary<string, string>()
        {
            { "&#39;", "'" },
            { "&amp;", "&" }
        })
            {
                if (!str.Contains(keyValuePair.Key))
                {
                    continue;
                }
                str = str.Replace(keyValuePair.Key, keyValuePair.Value);
                break;
            }
            return str;
        }

        public static string checkForSingleQuotes(string str)
        {
            return str.Replace("'", "''");
        }

        public static string checkZero(string checkValue)
        {
            string str = "-";
            if (Convert.ToDecimal(Utilities.convertBanglaToEnglish(checkValue)) > new decimal(0))
            {
                str = checkValue;
            }
            return str;
        }

        public static string comma(string amount)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            str1 = amount.ToString();
            int num = amount.ToString().IndexOf(".", 0);
            str2 = amount.ToString().Substring(num + 1);
            if (str1 != str2)
            {
                str1 = amount.ToString().Substring(0, amount.ToString().IndexOf(".", 0));
                str1 = str1.Replace(",", "").ToString();
            }
            else
            {
                str2 = "";
            }
            switch (str1.Length)
            {
                case 4:
                    {
                        if (str2 != "")
                        {
                            string[] strArrays = new string[] { str1.Substring(0, 1), ",", str1.Substring(1, 3), ".", str2 };
                            str = string.Concat(strArrays);
                            break;
                        }
                        else
                        {
                            str = string.Concat(str1.Substring(0, 1), ",", str1.Substring(1, 3));
                            break;
                        }
                    }
                case 5:
                    {
                        if (str2 != "")
                        {
                            string[] strArrays1 = new string[] { str1.Substring(0, 2), ",", str1.Substring(2, 3), ".", str2 };
                            str = string.Concat(strArrays1);
                            break;
                        }
                        else
                        {
                            str = string.Concat(str1.Substring(0, 2), ",", str1.Substring(2, 3));
                            break;
                        }
                    }
                case 6:
                    {
                        if (str2 != "")
                        {
                            string[] strArrays2 = new string[] { str1.Substring(0, 1), ",", str1.Substring(1, 2), ",", str1.Substring(3, 3), ".", str2 };
                            str = string.Concat(strArrays2);
                            break;
                        }
                        else
                        {
                            string[] strArrays3 = new string[] { str1.Substring(0, 1), ",", str1.Substring(1, 2), ",", str1.Substring(3, 3) };
                            str = string.Concat(strArrays3);
                            break;
                        }
                    }
                case 7:
                    {
                        if (str2 != "")
                        {
                            string[] strArrays4 = new string[] { str1.Substring(0, 2), ",", str1.Substring(2, 2), ",", str1.Substring(4, 3), ".", str2 };
                            str = string.Concat(strArrays4);
                            break;
                        }
                        else
                        {
                            string[] strArrays5 = new string[] { str1.Substring(0, 2), ",", str1.Substring(2, 2), ",", str1.Substring(4, 3) };
                            str = string.Concat(strArrays5);
                            break;
                        }
                    }
                case 8:
                    {
                        if (str2 != "")
                        {
                            string[] strArrays6 = new string[] { str1.Substring(0, 1), ",", str1.Substring(1, 2), ",", str1.Substring(3, 2), ",", str1.Substring(5, 3), ".", str2 };
                            str = string.Concat(strArrays6);
                            break;
                        }
                        else
                        {
                            string[] strArrays7 = new string[] { str1.Substring(0, 1), ",", str1.Substring(1, 2), ",", str1.Substring(3, 2), ",", str1.Substring(5, 3) };
                            str = string.Concat(strArrays7);
                            break;
                        }
                    }
                case 9:
                    {
                        if (str2 != "")
                        {
                            string[] strArrays8 = new string[] { str1.Substring(0, 2), ",", str1.Substring(2, 2), ",", str1.Substring(4, 2), ",", str1.Substring(6, 3), ".", str2 };
                            str = string.Concat(strArrays8);
                            break;
                        }
                        else
                        {
                            string[] strArrays9 = new string[] { str1.Substring(0, 2), ",", str1.Substring(2, 2), ",", str1.Substring(4, 2), ",", str1.Substring(6, 3) };
                            str = string.Concat(strArrays9);
                            break;
                        }
                    }
                default:
                    {
                        if (str2 != "")
                        {
                            str = string.Concat(str1, ".", str2);
                            break;
                        }
                        else
                        {
                            str = str1;
                            break;
                        }
                    }
            }
            return str;
        }

        public static byte[] ComputeHash(string plainText)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            return (new SHA256Managed()).ComputeHash(bytes);
        }

        public static string convertBanglaToEnglish(string englistNumber)
        {
            string str = "";
            char[] charArray = englistNumber.ToCharArray();
            for (int i = 0; i < (int)charArray.Length; i++)
            {
                string str1 = charArray[i].ToString();
                str = string.Concat(str, Utilities.getSingleEnglishNumber(str1));
            }
            return str;
        }

        public static string convertEnglistNumberIntoBangla(string englistNumber)
        {
            string str = "";
            char[] charArray = englistNumber.ToCharArray();
            for (int i = 0; i < (int)charArray.Length; i++)
            {
                string str1 = charArray[i].ToString();
                str = string.Concat(str, Utilities.getSingleBanglaNumber(str1));
            }
            return str;
        }

        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] numArray;
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] numArray1 = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(Passphrase));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()
            {
                Key = numArray1,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] numArray2 = Convert.FromBase64String(Message);
            try
            {
                try
                {
                    ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                    numArray = cryptoTransform.TransformFinalBlock(numArray2, 0, (int)numArray2.Length);
                }
                catch (Exception exception)
                {
                    numArray = numArray2;
                }
            }
            finally
            {
                tripleDESCryptoServiceProvider.Clear();
                mD5CryptoServiceProvider.Clear();
            }
            return uTF8Encoding.GetString(numArray);
        }

        public static string Encrypt(string clearText)
        {
            string base64String;
            try
            {
                byte[] numArray = Utilities.ComputeHash(clearText);
                byte[] randomSalt = Utilities.GetRandomSalt();
                Utilities.ComputeHash(randomSalt.ToString());
                byte[] numArray1 = new byte[(int)numArray.Length + (int)randomSalt.Length];
                for (int i = 0; i < (int)numArray.Length; i++)
                {
                    numArray1[i] = numArray[i];
                }
                for (int j = 0; j < (int)randomSalt.Length; j++)
                {
                    numArray1[(int)numArray.Length + j] = randomSalt[j];
                }
                base64String = Convert.ToBase64String(numArray1);
            }
            catch (Exception exception)
            {
                throw;
            }
            return base64String;
        }

        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] numArray;
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] numArray1 = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(Passphrase));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider()
            {
                Key = numArray1,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] bytes = uTF8Encoding.GetBytes(Message);
            try
            {
                ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                numArray = cryptoTransform.TransformFinalBlock(bytes, 0, (int)bytes.Length);
            }
            finally
            {
                tripleDESCryptoServiceProvider.Clear();
                mD5CryptoServiceProvider.Clear();
            }
            return Convert.ToBase64String(numArray);
        }

        public static DropDownList fillItemPrice(DropDownList ddlItemPrice, string strDeclarationType)
        {
            DataTable itemPrice = (new PriceDeclaretionBLL()).getItemPrice(strDeclarationType);
            if (itemPrice != null)
            {
                ddlItemPrice.DataSource = itemPrice;
                ddlItemPrice.DataTextField = itemPrice.Columns["Item_name"].ToString();
                ddlItemPrice.DataValueField = itemPrice.Columns["price_id"].ToString();
                ddlItemPrice.DataBind();
            }
            ListItem listItem = new ListItem("---Select---", "-99");
            ddlItemPrice.Items.Insert(0, listItem);
            return ddlItemPrice;
        }

        public static DropDownList fillItemPriceWithDate(DropDownList ddlItemPrice, string strDeclarationType)
        {
            DataTable itemPriceWithDate = (new PriceDeclaretionBLL()).getItemPriceWithDate(strDeclarationType);
            if (itemPriceWithDate != null)
            {
                ddlItemPrice.DataSource = itemPriceWithDate;
                ddlItemPrice.DataTextField = itemPriceWithDate.Columns["Item_name"].ToString();
                ddlItemPrice.DataValueField = itemPriceWithDate.Columns["price_id"].ToString();
                ddlItemPrice.DataBind();
            }
            ListItem listItem = new ListItem("---Select---", "-99");
            ddlItemPrice.Items.Insert(0, listItem);
            return ddlItemPrice;
        }

        public static string formatDate(string value)
        {
            value = Regex.Replace(value, "[^0-9A-Za-z ,]", "/");
            int num = value.IndexOf("/");
            string str = value.Substring(0, num);
            if (str.Length < 2)
            {
                str = string.Concat("0", str);
            }
            int num1 = value.IndexOf("/", num + 1);
            string str1 = "";
            if (num1 >= 6)
            {
                str1 = value.Substring(num + 1, 3);
                DateTime dateTime = DateTime.ParseExact(str1, "MMM", CultureInfo.InvariantCulture);
                int month = dateTime.Month;
                str1 = string.Concat(month.ToString(), "/");
            }
            else
            {
                str1 = value.Substring(num + 1, 2);
            }
            if (str1.IndexOf("/") > -1)
            {
                str1 = str1.Replace("/", "");
                str1 = string.Concat("0", str1);
            }
            int num2 = value.LastIndexOf("/");
            string str2 = value.Substring(num2 + 1, 4);
            string[] strArrays = new string[] { str, "/", str1, "/", str2 };
            return string.Concat(strArrays);
        }

        public static string formatFraction(decimal number)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            if ((number % new decimal(1)) != new decimal(0))
            {
                string str1 = number.ToString();
                string[] strArrays = str1.Split(new char[] { '.' });
                if ((int)strArrays.Length <= 0)
                {
                    empty = string.Concat(empty, str1);
                }
                else
                {
                    decimal num = Convert.ToDecimal(strArrays[0]);
                    empty = num.ToString("N0");
                    empty = string.Concat(empty, ".");
                    Stack<char> chrs = new Stack<char>();
                    Stack<char> chrs1 = new Stack<char>();
                    string str2 = strArrays[1];
                    for (int i = 0; i < str2.Length; i++)
                    {
                        chrs.Push(str2[i]);
                    }
                    while (true)
                    {
                        if (chrs.Count == 0)
                        {
                            break;
                        }
                        else if (chrs.Peek() != '0')
                        {
                            while (chrs.Count != 0)
                            {
                                chrs1.Push(chrs.Peek());
                                chrs.Pop();
                            }
                            break;
                        }
                        else
                        {
                            chrs.Pop();
                        }
                    }
                    while (chrs1.Count != 0)
                    {
                        empty = string.Concat(empty, chrs1.Peek());
                        chrs1.Pop();
                    }
                }
            }
            else
            {
                long num1 = (long)Math.Round(number, 0);
                empty = num1.ToString();
            }
            return empty.ToString();
        }

        public static DataSet getExcelDataSet(string ConStr, string sheetName)
        {
            DataSet dataSet;
            DataSet dataSet1 = new DataSet();
            using (OleDbConnection oleDbConnection = new OleDbConnection(ConStr))
            {
                using (OleDbCommand oleDbCommand = new OleDbCommand())
                {
                    try
                    {
                        oleDbCommand.Connection = oleDbConnection;
                        oleDbConnection.Open();
                    }
                    catch (Exception exception)
                    {
                        dataSet = dataSet1;
                        return dataSet;
                    }
                    DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    oleDbSchemaTable.Rows[0]["TABLE_NAME"].ToString();
                    oleDbCommand.CommandText = string.Format("SELECT * FROM [{0}$]", sheetName);
                    using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand))
                    {
                        oleDbDataAdapter.SelectCommand = oleDbCommand;
                        oleDbDataAdapter.Fill(dataSet1);
                    }
                }
                return dataSet1;
            }
            return dataSet;
        }

        public static string[] GetMasterOrgInfo()
        {
            AddUserBLL addUserBLL = new AddUserBLL();
            string str = "";
            string str1 = "";
            DataTable masterOrganization = addUserBLL.GetMasterOrganization();
            if (masterOrganization != null && masterOrganization.Rows.Count > 0)
            {
                str = masterOrganization.Rows[0]["admin_type"].ToString();
                str1 = masterOrganization.Rows[0]["bin_type"].ToString();
            }
            return new string[] { str, str1 };
        }

        public static byte[] GetRandomSalt()
        {
            byte[] numArray = new byte[(new Random()).Next(16, 32)];
            (new RNGCryptoServiceProvider()).GetNonZeroBytes(numArray);
            return numArray;
        }

        public static string getSingleBanglaNumber(string character)
        {
            string str = "";
            string str1 = character;
            string str2 = str1;
            if (str1 != null)
            {
                switch (str2)
                {
                    case "1":
                        {
                            str = "১";
                            break;
                        }
                    case "2":
                        {
                            str = "২";
                            break;
                        }
                    case "3":
                        {
                            str = "৩";
                            break;
                        }
                    case "4":
                        {
                            str = "৪";
                            break;
                        }
                    case "5":
                        {
                            str = "৫";
                            break;
                        }
                    case "6":
                        {
                            str = "৬";
                            break;
                        }
                    case "7":
                        {
                            str = "৭";
                            break;
                        }
                    case "8":
                        {
                            str = "৮";
                            break;
                        }
                    case "9":
                        {
                            str = "৯";
                            break;
                        }
                    case "0":
                        {
                            str = "০";
                            break;
                        }
                    case ".":
                        {
                            str = ".";
                            break;
                        }
                    case "/":
                        {
                            str = "/";
                            break;
                        }
                    case "%":
                        {
                            str = "%";
                            break;
                        }
                    default:
                        {
                            str = character;
                            return str;
                        }
                }
            }
            else
            {
                str = character;
                return str;
            }
            return str;
        }

        public static string getSingleEnglishNumber(string character)
        {
            string str = "";
            string str1 = character;
            string str2 = str1;
            if (str1 != null)
            {
                switch (str2)
                {
                    case "১":
                        {
                            str = "1";
                            break;
                        }
                    case "২":
                        {
                            str = "2";
                            break;
                        }
                    case "৩":
                        {
                            str = "3";
                            break;
                        }
                    case "৪":
                        {
                            str = "4";
                            break;
                        }
                    case "৫":
                        {
                            str = "5";
                            break;
                        }
                    case "৬":
                        {
                            str = "6";
                            break;
                        }
                    case "৭":
                        {
                            str = "7";
                            break;
                        }
                    case "৮":
                        {
                            str = "8";
                            break;
                        }
                    case "৯":
                        {
                            str = "9";
                            break;
                        }
                    case "০":
                        {
                            str = "0";
                            break;
                        }
                    case ".":
                        {
                            str = ".";
                            break;
                        }
                    case "/":
                        {
                            str = "/";
                            break;
                        }
                    case "%":
                        {
                            str = "%";
                            break;
                        }
                    default:
                        {
                            str = character;
                            return str;
                        }
                }
            }
            else
            {
                str = character;
                return str;
            }
            return str;
        }

        public static void KillExcelFileProcess()
        {
            IEnumerable<Process> processesByName =
                from p in (IEnumerable<Process>)Process.GetProcessesByName("EXCEL")
                select p;
            foreach (Process process in processesByName)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception exception)
                {
                }
            }
        }

        public static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return Math.Abs(lValue.Month - rValue.Month + 12 * (lValue.Year - rValue.Year));
        }

        public static string ReplaceCommas(string inputValue)
        {
            return inputValue.Replace(",", "''");
        }

        public static string ReplacedotQuotes(string inputValue)
        {
            return inputValue.Replace(".", "");
        }

        public static string ReplaceQuotes(string inputValue)
        {
            return inputValue.Replace("'", "''");
        }

        public static decimal RoundUpTo(decimal number, int precision)
        {
            number = (precision > -1 ? Math.Round(number, precision) : number);
            if (precision > 0)
            {
                string str = string.Concat("{0:f", precision, "}");
                string str1 = string.Format(str, Convert.ToDecimal(number.ToString()));
                number = Convert.ToDecimal(str1);
            }
            return number;
        }

        public static string RoundUpToWithString(decimal number, int precision)
        {
            number = (precision > -1 ? Math.Round(number, precision) : number);
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            if (precision <= 0)
            {
                precision = 2;
                string str = string.Concat("{0:f", precision, "}");
                string str1 = string.Format(str, Convert.ToDecimal(number.ToString()));
                number = Convert.ToDecimal(str1);
                num = Math.Truncate(number);
                num1 = Math.Abs(number - num);
            }
            else
            {
                string str2 = string.Concat("{0:f", precision, "}");
                string str3 = string.Format(str2, Convert.ToDecimal(number.ToString()));
                number = Convert.ToDecimal(str3);
                num = Math.Truncate(number);
                num1 = Math.Abs(number - num);
            }
            string str4 = num.ToString("N0");
            string str5 = num1.ToString();
            char[] chrArray = new char[] { '0' };
            return string.Concat(str4, str5.TrimStart(chrArray));
        }
    }
}

