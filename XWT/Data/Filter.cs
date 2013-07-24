using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Data {
    public class Filter {
        private string _filter = string.Empty;

        public string Field { get; set; }
        public string Value { get; set; }
        public string Condition { get; set; }

        public bool Active { get; set; }

        public Filter() : this(string.Empty) { 
            
        }

        public Filter(string filter) {
            _filter = filter;
        }

        public string ConstructFilter() {
            if (!string.IsNullOrEmpty(_filter)) {
                return _filter;
            }

            return string.Format(" {0} {1} '{2}' ", Field, Condition, Value);
        }
    }
}
