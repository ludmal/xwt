using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace XWT.Logging {
    public class LogConfiguration {
        public static string GetLogLevel() {
            return ConfigurationManager.AppSettings["LogLevel"];
        }

        public static string GetLogger() {
            return ConfigurationManager.AppSettings["Logger"];
        }

    }
}
