using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Charts {
    public class Format {

        /// <summary>
        /// MMM
        /// </summary>
        public const string MONTH = "MMM";

        /// <summary>
        /// Dec 7, 2008
        /// </summary>
        public const string DATE_SHORT = "MMM dd, yyyy";

        public const string MONTH_YEAR = "MMM, yyyy";
        /// <summary>
        /// yyyyMM
        /// </summary>
        public const string MONTH_REF = "yyyyMM";
        /// <summary>
        /// Previous
        /// </summary>
        public const string PREVIOUS = "Previous";
        /// <summary>
        /// Current
        /// </summary>
        public const string CURRENT = "Current";
        /// <summary>
        /// S$ #VAL{C}
        /// </summary>
        public const string CHART_FORMAT_CURRENCY = CURRENCY_CODE + " #VAL{C}";
        /// <summary>
        /// #VAL
        /// </summary>
        public const string CHART_FORMAT_NUMBER = "#VAL";
        /// <summary>
        /// S$0,, M
        /// </summary>
        public const string AXISX_CURRENCY = CURRENCY_CODE + "0,, M";
        /// <summary>
        /// S$
        /// </summary>
        //public const string CURRENCY_CODE = "¥";
        public const string CURRENCY_CODE = "S$";

        /// <summary>
        /// ##,###0
        /// </summary>
        public const string NUMBER_FORMAT = "##,###0";

        /// <summary>
        /// ##,###.##0
        /// </summary>
        public const string CURRENCY_FORMAT = "##,###.##0";

        /// <summary>
        /// ###.##0
        /// </summary>
        public const string PERCENTAGE_FORMAT = "###.##0";

        /// <summary>
        /// SGD
        /// </summary>
        //public const string CURRENCY_CODE_DESC = "RMB";
        public const string CURRENCY_CODE_DESC = "SGD";

        /// <summary>
        /// S$
        /// </summary>
        /// <returns></returns>
        //public static string GetCurrencyCode() {
        //    return AppSettings.GetSessionCountry().CurrencyCode;
        //}

        /// <summary>
        /// SGD
        /// </summary>
        /// <returns></returns>
        //public static string GetCurrencyCodeDesc() {
        //    return AppSettings.GetSessionCountry().LocalCurrency;
        //}


    }
}
