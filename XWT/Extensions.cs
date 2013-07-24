#region License
/*
 **************************************************************
 *  Author: Ludmal de silva
 *          © XWT Solutions, 2010
 *          http://www.infonexsolutions.com/
 * 
 * Created: 12/11/2009
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 **************************************************************  
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace XWT
{
    public static class Extensions
    {
        private const int CHAR_LENGTH = 35;
        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        //Remove duplicates in the tasks

        //public static List<T> RemoveDuplicates(this List<T> inputList) {
        //    Dictionary uniqueStore = new Dictionary();
        //    List<T> finalList = new List();
        //    foreach (string currValue in inputList) {
        //        if (!uniqueStore.ContainsKey(currValue)) {
        //            uniqueStore.Add(currValue, 0);
        //            finalList.Add(currValue);
        //        }
        //    }
        //    return finalList;
        //}

        /// <summary>
        /// Validates the Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="theEnum">The enum.</param>
        /// <param name="value">The value.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        public static bool TryParse<T>(this T theEnum, object value, out T result)
        {
            result = theEnum;
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                if (item.Equals(value))
                {
                    result = (T)
                      Enum.Parse(typeof(T), value.ToString());
                    return true;
                }
            }

            if (Enum.IsDefined(typeof(T), Convert.ChangeType(value, (Enum.GetUnderlyingType(typeof(T))))))
            {
                result = (T)Enum.Parse(typeof(T), value.ToString());
                return true;
            }

            return false;
        }

        /// <summary>
        /// To the SQL date time.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string ToSqlDateTime(this DateTime dt)
        {
            string format = "yyyy-MM-dd HH:mm:ss:ff";
            return dt.ToString(format);
            //return dt.ToLongDateString();
        }

        /// <summary>
        /// To the camel case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static string ToCamelCase(this string name) {
            string str = "";
            bool flag = false;
            bool flag2 = true;
            bool flag3 = true;
            foreach (char ch in name) {
                if (char.IsLower(ch)) {
                    flag3 = false;
                    break;
                }
            }
            foreach (char ch2 in name) {
                switch (ch2) {
                    case ' ':
                        if (!flag2) {
                            flag = true;
                        }
                        break;

                    case '.':
                        if (!flag2) {
                            flag = true;
                        }
                        break;

                    case '_':
                        if (!flag2) {
                            flag = true;
                        }
                        break;

                    default:
                        if (flag) {
                            str = str + ch2.ToString().ToUpper();
                            flag = false;
                        } else if (flag2) {
                            str = str + ch2.ToString().ToLower();
                            flag2 = false;
                        } else if (flag3) {
                            str = str + ch2.ToString().ToLower();
                        } else {
                            str = str + ch2.ToString();
                        }
                        break;
                }
            }
            return str;
        }

        /// <summary>
        /// To the camel case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="trimList">The trim list.</param>
        /// <returns></returns>
        public static string ToCamelCase(this string name, char[] trimList) {
            for (int i = 0; i < trimList.GetLength(0); i++) {
                name = name.Replace(trimList[i], ' ');
            }
            return name.ToCamelCase();
        }

        /// <summary>
        /// To the pascal case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static string ToPascalCase(this string name) {
            string str = "";
            bool flag = true;
            bool flag2 = true;
            foreach (char ch in name) {
                if (char.IsLower(ch)) {
                    flag2 = false;
                    break;
                }
            }
            foreach (char ch2 in name) {
                switch (ch2) {
                    case ' ':
                        flag = true;
                        break;

                    case '.':
                        flag = true;
                        break;

                    case '_':
                        flag = true;
                        break;

                    default:
                        if (flag) {
                            str = str + ch2.ToString().ToUpper();
                            flag = false;
                        } else if (flag2) {
                            str = str + ch2.ToString().ToLower();
                        } else {
                            str = str + ch2.ToString();
                        }
                        break;
                }
            }
            return str;
        }


        /// <summary>
        /// Toes the pascal case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="trimList">The trim list.</param>
        /// <returns></returns>
        public static string ToPascalCase(this string name, char[] trimList) {
            for (int i = 0; i < trimList.GetLength(0); i++) {
                name = name.Replace(trimList[i], ' ');
            }
            return name.ToPascalCase();
        }

        /// <summary>
        /// Trims the spaces.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static string TrimSpaces(string name) {
            return name.Replace(" ", "");
        }

        /// <summary>
        /// Trims the spaces.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="trimList">The trim list.</param>
        /// <returns></returns>
        public static string TrimSpaces(string name, char[] trimList) {
            for (int i = 0; i < trimList.GetLength(0); i++) {
                name = name.Replace(trimList[i], ' ');
            }
            return TrimSpaces(name);
        }


        /// <summary>
        /// Parses the UTC date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime ParseUTCDateTime(string dateTime) {
            return DateTime.SpecifyKind(Convert.ToDateTime(dateTime), DateTimeKind.Utc);
        }

        /// <summary>
        /// Returns URL with HTTP://
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string FormatUrl(this string url) {
            if (!string.IsNullOrEmpty(url)) {
                if (url.IndexOf("http://") == -1) {
                    return string.Format("http://{0}", url);
                }
                return url;
            }
            return string.Empty;
        }

        /// <summary>
        /// Add LineBreak
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string LineBreakAdd(string text) {
            text = text.Replace("\r\n", "</br>");
            return text;
        }

        /// <summary>
        /// Remove LineBreak
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string LineBreakRemove(this string text) {
            text = text.Replace("<br/>", "\r\n");
            return text;
        }

        /// <summary>
        /// Trims LineBreak
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string LineBreakTrim(this string text) {
            if (!string.IsNullOrEmpty(text)) {
                text = text.Replace("", "\r\n");
            }
            return text;
        }

        /// <summary>
        /// Truncates the string, default length is 35
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TruncateString(this string text) {
            return TruncateString(text, CHAR_LENGTH);
        }

        /// <summary>
        /// Truncates the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="charLength">Length of the char.</param>
        /// <returns></returns>
        public static string TruncateString(this string text, int charLength) {
            string newstr = text.Trim();
            if (newstr.Length > charLength) {
                newstr = string.Format("{0}...", text.Substring(0, charLength));
            }
            return newstr;
        }

        /// <summary>
        /// Cleans the XML.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static string CleanXML(this string val) {
            //replace the reserved characters > < & %
            string sTemp = null;
            sTemp = val.Replace("&", "");
            sTemp = sTemp.Replace(">", "");
            sTemp = sTemp.Replace("<", "");
            sTemp = sTemp.Replace("%", "");
            sTemp = sTemp.Replace("'", "");
            
            return sTemp;
        }

        /// <summary>
        /// Determines whether [is valid email] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid email] [the specified email]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEmail(this string email) {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            return re.IsMatch(email);
        }

        /// <summary>
        /// Determines whether [is null or empty] [the specified text].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        /// 	<c>true</c> if [is null or empty] [the specified text]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string text) {
            return string.IsNullOrEmpty(text);
        }

        public static bool IsValid(this string value) {
            return !string.IsNullOrEmpty(value.Trim());
        }

        public static bool IsValid(this int value) {
            return (value > -1);
        }

        public static bool IsValid(this DateTime date) {
            return date > DateTime.MinValue;
        }

        public static int ToInt(this object value) {
            int result = 0;
            if (value == null) {
                return 0;
            }

            if (int.TryParse(value.ToString(), out result)) {
                return result;
            }

            return 0;
        }

        public static bool ToBool(this object value) {
            bool result = false;
            if (value == null) {
                return false;
            }

            if (bool.TryParse(value.ToString(), out result)) {
                return result;
            }

            return false;
        }

        public static decimal ToDecimal(this object value) {
            decimal result = decimal.MinValue;
            if (value == null) {
                return result;
            }

            if (decimal.TryParse(value.ToString(), out result)) {
                return Convert.ToDecimal(value);
            }

            return result;
        }

        public static DateTime ToMinValue(this DateTime date) {
            return date.AddYears(-30);
        }

        public static DateTime ToMaxValue(this DateTime date) {
            return date.AddYears(30);
        }

        public static string ToTrimString(this string value) {
            return value.Trim();
        }

        public static DateTime ToDateTime(this object value) {
            return Convert.ToDateTime(value);
        }

        public static DateTime ToMonthRefDate(this DateTime dt) {
            return new DateTime(dt.Year, dt.Month, 1);
        }


    }
}
