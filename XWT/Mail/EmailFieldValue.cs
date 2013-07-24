using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Mail {
    public class EmailFieldValue {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public EmailFieldValue(string fieldName, string fieldValue) {
            this.FieldName = fieldName;
            this.FieldValue = fieldValue;
        }
    }
}
