using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Charts {
    public class SeriesCollection : List<Series> {


        public Series this[string name] {
            get {
                return this.Find(delegate(Series sItem) { return sItem.Name == name; });
            }
        }

    }
}
