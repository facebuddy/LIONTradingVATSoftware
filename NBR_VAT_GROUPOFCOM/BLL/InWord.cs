using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class InWord
    {
        public InWord()
        {
        }

        public static string ConvertEnglishToBanglaMonth(string EnglishMonth)
        {
            string str = "";
            string englishMonth = EnglishMonth;
            string str1 = englishMonth;
            if (englishMonth != null)
            {
                switch (str1)
                {
                    case "January":
                        {
                            str = "জানুয়ারী";
                            break;
                        }
                    case "February":
                        {
                            str = "ফেব্রুয়ারি";
                            break;
                        }
                    case "March":
                        {
                            str = "মার্চ";
                            break;
                        }
                    case "April":
                        {
                            str = "এপ্রিল";
                            break;
                        }
                    case "May":
                        {
                            str = "মে";
                            break;
                        }
                    case "June":
                        {
                            str = "জুন";
                            break;
                        }
                    case "July":
                        {
                            str = "জুলাই";
                            break;
                        }
                    case "August":
                        {
                            str = "অগাস্ট";
                            break;
                        }
                    case "September":
                        {
                            str = "সেপ্টেম্বর";
                            break;
                        }
                    case "October":
                        {
                            str = "অক্টোবর";
                            break;
                        }
                    case "November":
                        {
                            str = "নভেম্বর";
                            break;
                        }
                    case "December":
                        {
                            str = "ডিসেম্বর";
                            break;
                        }
                    default:
                        {
                            str = "";
                            return str;
                        }
                }
            }
            else
            {
                str = "";
                return str;
            }
            return str;
        }

        public static string ConvertEnglishToBanglaNumber(int EngNumber)
        {
            string str = "";
            switch (EngNumber)
            {
                case 1:
                    {
                        str = "১";
                        break;
                    }
                case 2:
                    {
                        str = "২";
                        break;
                    }
                case 3:
                    {
                        str = "৩";
                        break;
                    }
                case 4:
                    {
                        str = "৪";
                        break;
                    }
                case 5:
                    {
                        str = "৫";
                        break;
                    }
                case 6:
                    {
                        str = "৬";
                        break;
                    }
                case 7:
                    {
                        str = "৭";
                        break;
                    }
                case 8:
                    {
                        str = "৮";
                        break;
                    }
                case 9:
                    {
                        str = "৯ ";
                        break;
                    }
                case 10:
                    {
                        str = "১০";
                        break;
                    }
                case 11:
                    {
                        str = "১১";
                        break;
                    }
                case 12:
                    {
                        str = "১২";
                        break;
                    }
                case 13:
                    {
                        str = "১৩";
                        break;
                    }
                case 14:
                    {
                        str = "১৪";
                        break;
                    }
                case 15:
                    {
                        str = "১৫";
                        break;
                    }
                case 16:
                    {
                        str = "১৬";
                        break;
                    }
                case 17:
                    {
                        str = "১৭";
                        break;
                    }
                case 18:
                    {
                        str = "১৮";
                        break;
                    }
                case 19:
                    {
                        str = "১৯";
                        break;
                    }
                case 20:
                    {
                        str = "২০";
                        break;
                    }
                case 21:
                    {
                        str = "২১";
                        break;
                    }
                case 22:
                    {
                        str = "২২";
                        break;
                    }
                case 23:
                    {
                        str = "২৩";
                        break;
                    }
                case 24:
                    {
                        str = "২৪";
                        break;
                    }
                case 25:
                    {
                        str = "২৫";
                        break;
                    }
                case 26:
                    {
                        str = "২৬";
                        break;
                    }
                case 27:
                    {
                        str = "২৭";
                        break;
                    }
                case 28:
                    {
                        str = "২৮";
                        break;
                    }
                case 29:
                    {
                        str = "২৯";
                        break;
                    }
                case 30:
                    {
                        str = "৩০";
                        break;
                    }
                default:
                    {
                        str = "";
                        break;
                    }
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
                str = string.Concat(str, InWord.getSingleBanglaNumber(str1));
            }
            return str;
        }

        public static string ConvertToWord(double dblNumber)
        {
            string str = null;
            string str1 = null;
            double num = 0;
            double num1 = 0;
            int num2 = 0;
            string str2 = Convert.ToString(dblNumber);
            str2 = string.Format("{0:F2}", Convert.ToDouble(str2));
            num2 = Convert.ToInt32(str2.Substring(str2.IndexOf(".") + 1, 2));
            num1 = Convert.ToDouble(num2);
            str1 = " ";
            if (dblNumber > 999999999.99)
            {
                return "It is too big to convert in word by this class. Try with smaller one. ";
            }
            if (dblNumber == 0)
            {
                return "Zero Only.";
            }
            if (dblNumber < 0)
            {
                return "Negative number cannot be converted.";
            }
            num = Math.Floor(dblNumber / 10000000);
            dblNumber %= 10000000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Crore ");
            }
            num = Math.Floor(dblNumber / 100000);
            dblNumber %= 100000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Lac ");
            }
            num = Math.Floor(dblNumber / 1000);
            dblNumber %= 1000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Thousand ");
            }
            num = Math.Floor(dblNumber / 100);
            dblNumber %= 100;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Hundred ");
            }
            num = Math.Floor(dblNumber / 1);
            dblNumber %= 1;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num));
            }
            if (num1 > 0)
            {
                str1 = string.Concat(str1, " and Paisa", InWord.ConverTwoDigit(num1 % 100));
            }
            str = string.Concat("Taka ", str1.Substring(2, 1).ToUpper(), str1.Substring(3), " Only");
            return str;
        }

        public static string ConvertToWordBangla(double dblNumber)
        {
            string str = null;
            string str1 = null;
            double num = 0;
            double num1 = 0;
            int num2 = 0;
            string str2 = Convert.ToString(dblNumber);
            str2 = string.Format("{0:F2}", Convert.ToDouble(str2));
            num2 = Convert.ToInt32(str2.Substring(str2.IndexOf(".") + 1, 2));
            num1 = Convert.ToDouble(num2);
            str1 = " ";
            if (dblNumber > 999999999.99)
            {
                return "It is too big to convert in word by this class. Try with smaller one. ";
            }
            if (dblNumber == 0)
            {
                return "Zero Only.";
            }
            if (dblNumber < 0)
            {
                return "Negative number cannot be converted.";
            }
            num = Math.Floor(dblNumber / 10000000);
            dblNumber %= 10000000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigitBangla(num), " কোটি ");
            }
            num = Math.Floor(dblNumber / 100000);
            dblNumber %= 100000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigitBangla(num), " লক্ষ ");
            }
            num = Math.Floor(dblNumber / 1000);
            dblNumber %= 1000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigitBangla(num), " হাজার ");
            }
            num = Math.Floor(dblNumber / 100);
            dblNumber %= 100;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigitBangla(num), " শত ");
            }
            num = Math.Floor(dblNumber / 1);
            dblNumber %= 1;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigitBangla(num));
            }
            if (num1 <= 0)
            {
                str = string.Concat(str1.Substring(2, 1).ToUpper(), str1.Substring(3), " টাকা মাত্র");
            }
            else
            {
                str1 = string.Concat(str1, " টাকা এবং ", InWord.ConverTwoDigitBangla(num1 % 100), " পয়সা");
                str = string.Concat(str1.Substring(2, 1).ToUpper(), str1.Substring(3), " মাত্র");
            }
            return str;
        }

        public static string ConvertToWordWeight(double dblNumber, string unit)
        {
            string str = null;
            string str1 = null;
            double num = 0;
            double num1 = 0;
            int num2 = 0;
            double num3 = 0;
            double num4 = 0;
            string str2 = "";
            string str3 = Convert.ToString(dblNumber);
            str3 = string.Format("{0:F3}", Convert.ToDouble(str3));
            num2 = Convert.ToInt32(str3.Substring(str3.IndexOf(".") + 1, 3));
            num1 = Convert.ToDouble(num2);
            dblNumber = dblNumber - num1 / 1000;
            str1 = " ";
            if (dblNumber > 999999999.999)
            {
                return "It is too big to convert in word by this class. Try with smaller one. ";
            }
            if (dblNumber == 0)
            {
                return "Zero Only.";
            }
            if (dblNumber < 0)
            {
                return "Negative number cannot be converted.";
            }
            num = Math.Floor(dblNumber / 10000000);
            dblNumber %= 10000000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Crore ");
            }
            num = Math.Floor(dblNumber / 100000);
            dblNumber %= 100000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Lac ");
            }
            num = Math.Floor(dblNumber / 1000);
            dblNumber %= 1000;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Thousand ");
            }
            num = Math.Floor(dblNumber / 100);
            dblNumber %= 100;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num), " Hundred ");
            }
            num = Math.Floor(dblNumber / 1);
            dblNumber %= 1;
            if (num > 0)
            {
                str1 = string.Concat(str1, InWord.ConverTwoDigit(num));
            }
            if (num1 <= 0)
            {
                str = string.Concat(str1, " ", unit, " Only");
            }
            else
            {
                string str4 = "";
                if (unit == "KG")
                {
                    str4 = "Grams";
                }
                else if (unit == "MT")
                {
                    str4 = "Kilograms";
                }
                num3 = Math.Floor(num1 / 100);
                num4 = num1 % 100;
                if (num3 > 0)
                {
                    str2 = string.Concat(InWord.ConverTwoDigit(num3), " Hundred ");
                }
                str2 = string.Concat(str2, InWord.ConverTwoDigit(num4));
                string[] strArrays = new string[] { str1, " ", unit, " and ", str2, " ", str4 };
                str1 = string.Concat(strArrays);
                str = string.Concat(str1.Substring(2, 1).ToUpper(), str1.Substring(3));
            }
            return str;
        }

        private static string ConverTwoDigit(double dblTwoDigit)
        {
            double num = 0;
            double round = 0;
            string[] strArrays = new string[10];
            string[] strArrays1 = new string[10];
            string[] strArrays2 = new string[10];
            strArrays[1] = " One";
            strArrays[2] = " Two";
            strArrays[3] = " Three";
            strArrays[4] = " Four";
            strArrays[5] = " Five";
            strArrays[6] = " Six";
            strArrays[7] = " Seven";
            strArrays[8] = " Eight";
            strArrays[9] = " Nine";
            strArrays1[1] = " Ten";
            strArrays1[2] = " Twenty";
            strArrays1[3] = " Thirty";
            strArrays1[4] = " Forty";
            strArrays1[5] = " Fifty";
            strArrays1[6] = " Sixty";
            strArrays1[7] = " Seventy";
            strArrays1[8] = " Eighty";
            strArrays1[9] = " Ninety";
            strArrays2[1] = " Eleven";
            strArrays2[2] = " Twelve";
            strArrays2[3] = " Thirteen";
            strArrays2[4] = " Fourteen";
            strArrays2[5] = " Fifteen";
            strArrays2[6] = " Sixteen";
            strArrays2[7] = " Seventeen";
            strArrays2[8] = " Eighteen";
            strArrays2[9] = " Nineteen";
            num = Math.Floor(dblTwoDigit / 10);
            round = (double)InWord.FiveToRound(dblTwoDigit % 10);
            if (num > 0 && round == 0)
            {
                return strArrays1[Convert.ToInt32(num)];
            }
            if (num == 1 && round > 0)
            {
                return strArrays2[Convert.ToInt32(round)];
            }
            if (num == 0 && round > 0)
            {
                return strArrays[Convert.ToInt32(round)];
            }
            if (!(num > 0 & round > 0))
            {
                return " ";
            }
            return string.Concat(strArrays1[Convert.ToInt32(num)], strArrays[Convert.ToInt32(round)]);
        }

        private static string ConverTwoDigitBangla(double dblTwoDigit)
        {
            double num = 0;
            double round = 0;
            string[] strArrays = new string[10];
            string[] strArrays1 = new string[10];
            string[] strArrays2 = new string[10];
            string[] strArrays3 = new string[10];
            string[] strArrays4 = new string[10];
            string[] strArrays5 = new string[10];
            string[] strArrays6 = new string[10];
            string[] strArrays7 = new string[10];
            string[] strArrays8 = new string[10];
            string[] strArrays9 = new string[10];
            string[] strArrays10 = new string[10];
            strArrays[1] = " এক";
            strArrays[2] = " দুই";
            strArrays[3] = " তিন";
            strArrays[4] = " চার";
            strArrays[5] = " পাঁচ";
            strArrays[6] = " ছয়";
            strArrays[7] = " সাত";
            strArrays[8] = " আট";
            strArrays[9] = " নয়";
            strArrays1[1] = " দশ";
            strArrays1[2] = " বিশ";
            strArrays1[3] = " ত্রিশ";
            strArrays1[4] = " চল্লিশ";
            strArrays1[5] = " পঞ্চাশ";
            strArrays1[6] = " ষাট";
            strArrays1[7] = " সত্তর";
            strArrays1[8] = " আশি";
            strArrays1[9] = " নব্বুই";
            strArrays2[1] = " এগার";
            strArrays2[2] = " বার";
            strArrays2[3] = " তের";
            strArrays2[4] = " চৌদ্দ";
            strArrays2[5] = " পনের";
            strArrays2[6] = " ষোল";
            strArrays2[7] = " সতের";
            strArrays2[8] = " আটারো";
            strArrays2[9] = " উনিশ";
            strArrays3[1] = " একুশ";
            strArrays3[2] = " বাইশ";
            strArrays3[3] = " তেইশ";
            strArrays3[4] = " চব্বিশ";
            strArrays3[5] = " পঁচিশ";
            strArrays3[6] = " ছাব্বিশ";
            strArrays3[7] = " সাতাশ";
            strArrays3[8] = " আটাশ";
            strArrays3[9] = " ঊনত্রিশ";
            strArrays4[1] = " একত্রিশ";
            strArrays4[2] = " বত্রিশ";
            strArrays4[3] = " তেত্রিশ";
            strArrays4[4] = " চৌত্রিশ";
            strArrays4[5] = " পঁয়ত্রিশ";
            strArrays4[6] = " ছয়ত্রিশ";
            strArrays4[7] = " সাইত্রিশ";
            strArrays4[8] = " আটত্রিশ";
            strArrays4[9] = " ঊনচল্লিশ";
            strArrays5[1] = " একচল্লিশ";
            strArrays5[2] = " বিয়াল্লিশ";
            strArrays5[3] = " তেতাল্লিশ";
            strArrays5[4] = " চুয়াল্লিশ";
            strArrays5[5] = " পঁয়তাল্লিশ";
            strArrays5[6] = " ছেচল্লিশ";
            strArrays5[7] = " সাতচল্লিশ";
            strArrays5[8] = " আটচল্লিশ";
            strArrays5[9] = " ঊনপঞ্চাশ";
            strArrays6[1] = " একান্ন";
            strArrays6[2] = " বাহান্ন";
            strArrays6[3] = " তেপ্পান্ন";
            strArrays6[4] = " চুয়ান্ন";
            strArrays6[5] = " পঞ্চান্ন";
            strArrays6[6] = " ছাপ্পান্ন";
            strArrays6[7] = " সাতান্ন";
            strArrays6[8] = " আটান্ন";
            strArrays6[9] = " ঊনষাট";
            strArrays7[1] = " একষট্টি";
            strArrays7[2] = " বাষট্টি";
            strArrays7[3] = " তেষট্টি";
            strArrays7[4] = " চৌষট্টি";
            strArrays7[5] = " পঁয়ষট্টি";
            strArrays7[6] = " ছেষট্টি";
            strArrays7[7] = " সাতষট্টি";
            strArrays7[8] = " আটষট্টি";
            strArrays7[9] = " ঊনসত্তুর";
            strArrays8[1] = " একাত্তর";
            strArrays8[2] = " বাহাত্তর";
            strArrays8[3] = " তেহাত্তর";
            strArrays8[4] = " চুয়াত্তর";
            strArrays8[5] = " পচাত্তর";
            strArrays8[6] = " ছিয়াত্তর";
            strArrays8[7] = " সাতাত্তর";
            strArrays8[8] = " আটাত্তর";
            strArrays8[9] = " ঊনআশি";
            strArrays9[1] = " একাশি";
            strArrays9[2] = " বিরাশি";
            strArrays9[3] = " তিরাশি";
            strArrays9[4] = " চুরাশি";
            strArrays9[5] = " পঁচাশি";
            strArrays9[6] = " ছিয়াশি";
            strArrays9[7] = " সাতাশি";
            strArrays9[8] = " আটাশি";
            strArrays9[9] = " ঊনানব্বুই";
            strArrays10[1] = " একানব্বই";
            strArrays10[2] = " বিরানব্বই";
            strArrays10[3] = " তিরানব্বই";
            strArrays10[4] = " চুরানব্বই";
            strArrays10[5] = " পঁচানব্বই";
            strArrays10[6] = " ছিয়ানব্বই";
            strArrays10[7] = " সাতানব্বই";
            strArrays10[8] = " আটানব্বই";
            strArrays10[9] = " নিরানব্বই";
            num = Math.Floor(dblTwoDigit / 10);
            round = (double)InWord.FiveToRound(dblTwoDigit % 10);
            if (num > 0 && round == 0)
            {
                return strArrays1[Convert.ToInt32(num)];
            }
            if (num == 1 && round > 0)
            {
                return strArrays2[Convert.ToInt32(round)];
            }
            if (num == 2 && round > 0)
            {
                return strArrays3[Convert.ToInt32(round)];
            }
            if (num == 3 && round > 0)
            {
                return strArrays4[Convert.ToInt32(round)];
            }
            if (num == 4 && round > 0)
            {
                return strArrays5[Convert.ToInt32(round)];
            }
            if (num == 5 && round > 0)
            {
                return strArrays6[Convert.ToInt32(round)];
            }
            if (num == 6 && round > 0)
            {
                return strArrays7[Convert.ToInt32(round)];
            }
            if (num == 7 && round > 0)
            {
                return strArrays8[Convert.ToInt32(round)];
            }
            if (num == 8 && round > 0)
            {
                return strArrays9[Convert.ToInt32(round)];
            }
            if (num == 9 && round > 0)
            {
                return strArrays10[Convert.ToInt32(round)];
            }
            if (num == 0 && round > 0)
            {
                return strArrays[Convert.ToInt32(round)];
            }
            if (!(num > 0 & round > 0))
            {
                return " ";
            }
            return string.Concat(strArrays1[Convert.ToInt32(num)], strArrays[Convert.ToInt32(round)]);
        }

        private static int FiveToRound(double dblDigit)
        {
            int num = 0;
            num = Convert.ToInt32(Math.Floor(dblDigit));
            if (dblDigit - Convert.ToDouble(num) <= 0.5)
            {
                return num;
            }
            return num + 1;
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
    }
}