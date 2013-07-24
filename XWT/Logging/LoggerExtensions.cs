using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XWT.Logging {
    public static class LoggerExtensions {
        public static string GetDateTimeFormat(this ILogger logger) {
            return DateTime.Now.ToLongDateString();
        }

        public static bool IsValid(this ILogger logger, LogLevel loglevel) {
            string _loglevel = logger.LoggingElement.Level;
            return _loglevel.Contains(loglevel.ToString().ToLower())
                || _loglevel == "all";
        }
    }
}
