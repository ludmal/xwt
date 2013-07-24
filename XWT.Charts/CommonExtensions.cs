using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace XWT.Charts {
    public static class CommonExtensions {
        /// <summary>
        /// Toes the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetString(this Enum value) {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }


        public static bool IsNumber(this string str) {
            int i = 0;
            return int.TryParse(str, out i);
        }

        public static string ToFormattedValue(this decimal d) {
            return d.ToString(Format.NUMBER_FORMAT);
        }

        public static string ToMonthRef(this DateTime dateTime) {
            return dateTime.ToString(Format.MONTH_REF);
        }

        public static string ToShortMonth(this DateTime dateTime) {
            return dateTime.ToString(Format.MONTH);
        }

        public static string ToShortDate(this DateTime dateTime) {
            return dateTime.ToString(Format.DATE_SHORT);
        }

        public static string ToDefaultShortDateTime(this DateTime dateTime) {
            return dateTime.ToString("dd-MMM-yyyy hh:mm tt");
        }

        public static string ToMonthYearOnly(this DateTime dateTime) {
            return dateTime.ToString(Format.MONTH_YEAR);
        }

        public static string ToDecimalStringFormat(this string str) {
            decimal d = 0;
            if (decimal.TryParse(str, out d)) {
                return d.ToString(Format.NUMBER_FORMAT);
            }
            return str;
        }

        public static string ToDecimalFormat(this object str) {
            return ToDecimalStringFormat(str.ToString());
        }
    }
}
