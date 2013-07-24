using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Data {
    public class Query {
        private string _SQL = string.Empty;
        public Query(string sql) {
            _SQL = sql;
        }

        private List<Filter> _FilterCollection = new List<Filter>();
        public List<Filter> FilterCollection {
            get { return _FilterCollection; }
            set { _FilterCollection = value;  }
        }

        private string _SortOrder = string.Empty;
        public string SortOrder {
            get {
                return _SortOrder;
            }
            set {
                _SortOrder = value;
            }
        }

        public string ConstructQuery() {
            bool activeEnable = false;
            foreach (var item in _FilterCollection) {
                if (item.Active) {
                    if (activeEnable)
                        throw new Exception("Multiple filters cannot be active");

                    activeEnable = true;
                    _SQL += string.Format(" WHERE {0}", item.ConstructFilter());
                }
            }

            return string.Format("{0} {1}",_SQL, !string.IsNullOrEmpty(_SortOrder) ? string.Format(" ORDER BY {0}", _SortOrder) : "");
        }
    }
}
