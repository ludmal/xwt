using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Charts {
    public class Util {
        public Util() {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DateTime GetDate(string value) {
            if (value.Length < 5) {
                return DateTime.MinValue;
            }
            string year = value.Substring(0, 4);
            string month = value.Substring(4, 2);
            DateTime d = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
            return d;
        }

        /// <summary>
        /// Truncates the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string TruncateString(string text) {
            string newstr = text.Trim();
            if (newstr.Length > 33) {
                newstr = string.Format("{0}...", text.Substring(0, 32));
            }
            return newstr;
        }

        /// <summary>
        /// Cleans the XML.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static string CleanXML(object val) {
            if (val != null)
                return CleanXML(val.ToString());

            return string.Empty;
        }

        /// <summary>
        /// Cleans the XML.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static string CleanXML(string val) {
            //replace the reserved characters > < & %
            string sTemp = null;
            sTemp = val.Replace("&", "");
            sTemp = sTemp.Replace(">", "");
            sTemp = sTemp.Replace("<", "");
            sTemp = sTemp.Replace("%", "");
            sTemp = sTemp.Replace("'", "");
            return sTemp;
        }
    }
}
