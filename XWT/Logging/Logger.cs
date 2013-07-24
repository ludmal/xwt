using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace XWT.Logging {
    public class Logger {
        private static List<ILogger> _Loggers = null;

        #region ILogger Members

        private static object syncLock = new object();
        public static void Initialize() {
            if (_Loggers == null) {
                lock (syncLock) {
                    if (_Loggers == null) {
                        _Loggers = LoggerFactory.CreateLoggers();
                    }
                }
            }
        }

        public void Log(LogLevel logLevel, string text) {
            if (!IsValid(logLevel)) { return; }
            foreach (ILogger item in _Loggers) {
                item.Log(logLevel, text);
            }
        }

        public void Log(LogLevel logLevel, Exception ex) {
            if (!IsValid(logLevel)) { return; }
            foreach (ILogger item in _Loggers) {
                item.Log(logLevel, ex);
            }

        }

        public void Log(string text) {
            if (!IsValid(LogLevel.All)) { return; }
            foreach (ILogger item in _Loggers) {
                item.Log(text);
            }

        }

        public void Log(Exception ex) {
            if (!IsValid(LogLevel.All)) { return; }

            foreach (ILogger item in _Loggers) {
                item.Log(ex);
            }
        }

        private bool IsValid(LogLevel logLevel) {
            string _loglevel = string.Empty;
            LoggingConfiguration logConfig = null;
            if (string.IsNullOrEmpty(_loglevel)) {
                logConfig = (LoggingConfiguration)ConfigurationManager.GetSection("logging");
            }
            _loglevel = logConfig.Level;
            return _loglevel.Contains(logLevel.ToString().ToLower())
                || _loglevel == "all";
        }

        #endregion
    }
}
