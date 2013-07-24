using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Web.Controls {
    public class CustomScript : System.Configuration.ConfigurationElement {
        /// <summary>
        /// Returns the key value.
        /// </summary>
        [System.Configuration.ConfigurationProperty("enable", DefaultValue="true", IsRequired = false)]
        public bool Enable {
            get {
                return Convert.ToBoolean(this["enable"]);
            }
        }

        /// <summary>
        /// Returns the setting value for the production environment.
        /// </summary>
        [System.Configuration.ConfigurationProperty("path", IsRequired = true)]
        public string Path {
            get {
                return this["path"] as string;
            }
        }

        [System.Configuration.ConfigurationProperty("id", IsRequired = true)]
        public string ID {
            get {
                return this["id"] as string;
            }
        }


    }
}
