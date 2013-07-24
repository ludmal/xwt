using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Logging {
    public class EmailLogger : ILogger {
        #region ILogger Members

        public LoggingElement LoggingElement {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public void Log(LogLevel logLevel, string text) {
            FileLogger f = new FileLogger();
            f.Log(logLevel, text);
        }

        public void Log(LogLevel logLevel, Exception ex) {
            throw new NotImplementedException();
        }

        public void Log(string text) {
            throw new NotImplementedException();
        }

        public void Log(Exception ex) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
