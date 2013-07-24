using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Logging {
    public interface ILogger {
        LoggingElement LoggingElement {
            get;
            set;
        }
        void Log(LogLevel logLevel, string text);
        void Log(LogLevel logLevel, Exception ex);
        void Log(string text);
        void Log(Exception ex);
    }
}
