using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Charts {
    public class Series : IComparable<Series> {
        private SeriesChartType _SeriesChartType = SeriesChartType.Default;
        public SeriesChartType SeriesChartType {
            get {
                return _SeriesChartType;
            }
            set {
                _SeriesChartType = value;
            }
        }


        private Points _Points = new Points();
        public Points Points {
            get {
                return _Points;
            }
            set {
                _Points = value;
            }
        }

        public string Name { get; set; }

        public Series(string name) {
            Name = name;
        }

        public Series()
            : this("") {

        }

        public int CompareTo(Series other) {
            if (this.Points.Count > other.Points.Count) {
                return 1;
            }
            return 0;
        }

    }
}
