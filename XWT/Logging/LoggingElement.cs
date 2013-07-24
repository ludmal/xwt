using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Logging {
    public class LoggingElement : System.Configuration.ConfigurationElement {
        /// <summary>
        /// Returns the key value.
        /// </summary>
        [System.Configuration.ConfigurationProperty("name", IsRequired = true)]
        public string Name {
            get {
                return this["name"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("level", DefaultValue = "all", IsRequired = false)]
        public string Level {
            get {
                return this["level"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("type", IsRequired = false)]
        public string Type {
            get {
                return this["type"] as string;
            }
        }

        /// <summary>
        /// Returns the setting value for the production environment.
        /// </summary>
        [System.Configuration.ConfigurationProperty("filePath", IsRequired = false)]
        public string FilePath {
            get {
                return this["filePath"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("emails", IsRequired = false)]
        public string Emails {
            get {
                return this["emails"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("smtp", IsRequired = false)]
        public string Smtp {
            get {
                return this["smtp"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("userid", IsRequired = false)]
        public string UserID {
            get {
                return this["userid"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("password", IsRequired = false)]
        public string Password {
            get {
                return this["password"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("eventSourceName", IsRequired = false)]
        public string EventSourceName {
            get {
                return this["eventSourceName"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("eventLogName", IsRequired = false)]
        public string EventLogName {
            get {
                return this["eventLogName"] as string;
            }
        }

    }
}
