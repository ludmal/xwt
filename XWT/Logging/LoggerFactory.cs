using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace XWT.Logging {
    public class LoggerFactory {
        public static List<ILogger> CreateLoggers() {
            try {
                List<ILogger> _Loggers = new List<ILogger>();
                LoggingConfiguration logConfig = (LoggingConfiguration)ConfigurationManager.GetSection("logging");
                if (logConfig.Level.ToLower() != "off") {
                    foreach (LoggingElement item in logConfig.Elements) {
                        if (item.Level.ToLower() != "off" && item.Name != string.Empty) {
                            if (item.Name.ToLower() == "file") {
                                _Loggers.Add(new FileLogger() { LoggingElement = item });
                            } else if (item.Name.ToLower() == "mail") {

                            } else if (item.Name.ToLower() == "eventview") {
                                _Loggers.Add(new EventLogger() { LoggingElement = item });
                            } else {
                                _Loggers.Add((ILogger)Activator.CreateInstance(Type.GetType(item.Type)));
                            }
                        }
                    }
                }

                return _Loggers;

            } catch (Exception ex) {
                throw new Exception("Invalid Logging Configuration.");
            }

            return null;
        }   
    }
}
