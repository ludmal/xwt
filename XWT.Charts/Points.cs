using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Charts {
    public class Points : List<Point> {
        public void Add(string label, string value) {
            Point p = new Point();
            p.Label = label;
            p.Value = value;
            this.Add(p);
        }

        public Point this[string label] {
            get {
                return this.Find(delegate(Point point) { return point.Label == label; });
            }
        }

    }
}
