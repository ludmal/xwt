using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace XWT.Logging {
    public class EventLogger : ILogger {
        #region ILogger Members

        public LoggingElement LoggingElement { get; set; }

        public void Log(LogLevel logLevel, string text) {
            LogEntry(logLevel, text);
        }

        

        public void Log(LogLevel logLevel, Exception ex) {
            LogEntry(logLevel, string.Format("{0}:{1}", ex.Message, ex.StackTrace));
        }

        public void Log(string text) {
            LogEntry(LogLevel.All, text);
        }

        public void Log(Exception ex) {
            LogEntry(LogLevel.Error, string.Format("{0}:{1}", ex.Message, ex.StackTrace));
        }

        private void LogEntry(LogLevel logLevel, string text) {
                if (this.IsValid(logLevel)) {
                    string sSource;
                    string sLog;
                    string sEvent;

                    sSource = LoggingElement.EventSourceName;
                    sLog = LoggingElement.EventLogName;
                    sEvent = text;

                    if (!EventLog.Exists(sLog)) {
                        if (!EventLog.SourceExists(sSource))
                            EventLog.CreateEventSource(sSource, sLog);
                    }
                    EventLogEntryType entryType = EventLogEntryType.Information;

                    switch (logLevel) {
                        case LogLevel.All:
                        case LogLevel.Info:
                            entryType = EventLogEntryType.Information;
                            break;
                        case LogLevel.Warn:
                        case LogLevel.Debug:
                            entryType = EventLogEntryType.Warning;
                            break;
                        case LogLevel.Error:
                            entryType = EventLogEntryType.Error;
                            break;
                        default:
                            entryType = EventLogEntryType.Information;
                            break;
                    }

                    EventLog.WriteEntry(sSource, sEvent, entryType);
                }
        }

        #endregion

    }
}
