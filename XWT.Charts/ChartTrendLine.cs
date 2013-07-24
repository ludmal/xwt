using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Charts {
    public class ChartTrendLine {

        public string StartValue { get; set; }

        private string _Color = "91C728";
        public string Color {
            get {
                return _Color;
            }
            set {
                _Color = value;
            }
        }

        public string DisplayValue { get; set; }

        private string _ShowOnTop = "1";
        public string ShowOnTop {
            get { return _ShowOnTop; }
            set { _ShowOnTop = value; }
        }

        public ChartTrendLine() {
            
        }
    }
}
