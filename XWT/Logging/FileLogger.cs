using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace XWT.Logging {
    public class FileLogger : ILogger {
        #region ILogger Members

        public LoggingElement LoggingElement { get; set; }

        public void Log(LogLevel logLevel, string text) {
            LogEntry(logLevel, text);
        }

        public void Log(LogLevel logLevel, Exception ex) {
            LogEntry(logLevel, string.Format("{0} \r\n {1}", ex.Message, ex.StackTrace));
        }

        public void Log(string text) {
            LogEntry(LogLevel.All, text);
        }

        public void Log(Exception ex) {
            LogEntry(LogLevel.Error, string.Format("{0} \r\n {1}", ex.Message, ex.StackTrace));
        }

        private void LogEntry(LogLevel logLevel, string text) {
            if (this.IsValid(logLevel)) {
                StreamWriter SW;
                SW = File.AppendText(LoggingElement.FilePath);

                SW.WriteLine(string.Format("{0} : {1}", logLevel, this.GetDateTimeFormat()));
                SW.WriteLine(text);
                SW.WriteLine("-----------------------------------------------------------------------");
                SW.Close();
            }
        }

        #endregion

    }
}
