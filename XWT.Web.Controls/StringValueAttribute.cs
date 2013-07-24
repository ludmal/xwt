using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Web.Controls {
    public class StringValueAttribute : Attribute {
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }
        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value) {
            this.StringValue = value;
        }
    }
}
