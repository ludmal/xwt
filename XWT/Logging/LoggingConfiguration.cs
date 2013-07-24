using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace XWT.Logging {
    public class LoggingConfiguration : ConfigurationSection {
        [ConfigurationProperty("level", DefaultValue = "all", IsRequired = false)]
        public string Level {
            get {
                return this["level"] as string;
            }
        }

        //[ConfigurationProperty("enable", DefaultValue = "true", IsRequired = false)]
        //public bool Enable {
        //    get {
        //        return Convert.ToBoolean(this["enable"]);
        //    }
        //}

        LoggingElement element = null;

        public LoggingConfiguration() {
            element = new LoggingElement();
        }

        [ConfigurationProperty("loggers", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(LoggingElementCollection), AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public LoggingElementCollection Elements {
            get {
                return (LoggingElementCollection)base["loggers"];
            }
        }

    }

}
