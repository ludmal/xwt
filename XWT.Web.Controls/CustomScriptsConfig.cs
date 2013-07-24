using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
//Nextr code base

namespace XWT.Web.Controls {
    public class CustomScriptsConfig : ConfigurationSection {

        [ConfigurationProperty("enable", DefaultValue = "true", IsRequired = false)]
        public bool Enable {
            get {
                return Convert.ToBoolean(this["enable"]);
            }
        }

        [ConfigurationProperty("CDNUrl", DefaultValue = "", IsRequired = false)]
        public string CDNUrl {
            get {
                return this["CDNUrl"] as string;
            }
        }

        [ConfigurationProperty("enableCDN", DefaultValue = "false", IsRequired = false)]
        public bool EnableCDN {
            get {
                return Convert.ToBoolean(this["enableCDN"]);
            }
        }

        [System.Configuration.ConfigurationProperty("JQueryFile",DefaultValue = "", IsRequired = false)]
        public string JQueryFile {
            get {
                return this["JQueryFile"] as string;
            }
        }

        CustomScript element = null;

        public CustomScriptsConfig() {
            element = new CustomScript();
        }

        [ConfigurationProperty("scripts", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CustomScriptCollection), AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public CustomScriptCollection Elements {
            get {
                return (CustomScriptCollection)base["scripts"];
            }
        }

    }
}
