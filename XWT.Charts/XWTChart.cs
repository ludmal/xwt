#region License
/*
 **************************************************************
 *  Author: Ludmal de silva
 *          © XWT Solutions, 2010
 *          http://www.infonexsolutions.com/
 * 
 * Created: 27/04/2010
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 **************************************************************  
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("XWT.Charts", "XWT")]
namespace XWT.Charts {
    //[NonVisualControl, Designer(typeof(PreservePropertyControlDesigner))]
    [ToolboxData("<{0}:XWTChart runat=\"server\"></{0}:XWTChart>")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.WebParts.AppearanceEditorPart))]
    public class XWTChart : WebControl {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public string ID { get; set; }

        ChartTypeEnum _chartType = ChartTypeEnum.Pie2D ;
        /// <summary>
        /// Gets or sets the type of the chart.
        /// </summary>
        /// <value>The type of the chart.</value>
        public ChartTypeEnum ChartType {
            get {
                return _chartType;
            }
            set {
                _chartType = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        string _FormatNumberScale = "1";
        /// <summary>
        /// Gets or sets the format number scale.
        /// </summary>
        /// <value>The format number scale.</value>
        public string FormatNumberScale {
            get {
                return _FormatNumberScale;
            }
            set {
                _FormatNumberScale = value;
            }
        }

        string _NumberPrefix = "";//Format.GetCurrencyCodeDesc() ;
        /// <summary>
        /// Gets or sets the number prefix.
        /// </summary>
        /// <value>The number prefix.</value>
        public string NumberPrefix {
            get {
                return _NumberPrefix;
            }
            set {
                _NumberPrefix = value;
            }
        }

        string _XAxisName = "";
        public string XAxisName {
            get {
                return _XAxisName;
            }
            set {
                _XAxisName = value;
            }
        }

        string _YAxisName = "";
        public string YAxisName {
            get {
                return _YAxisName;
            }
            set {
                _YAxisName = value;
            }
        }

        string _PYAxisName = "";
        public string PYAxisName {
            get {
                return _PYAxisName;
            }
            set {
                _PYAxisName = value;
            }
        }

        string _SYAxisName = "";
        public string SYAxisName {
            get {
                return _SYAxisName;
            }
            set {
                _SYAxisName = value;
            }
        }

        string _RotateValues = "0";
        /// <summary>
        /// Gets or sets the rotate values.
        /// </summary>
        /// <value>The rotate values.</value>
        public string RotateValues {
            get {
                return _RotateValues;
            }
            set {
                _RotateValues = value;
            }
        }

        string _PlaceValuesInside = "0";
        /// <summary>
        /// Gets or sets the place values inside.
        /// </summary>
        /// <value>The place values inside.</value>
        public string PlaceValuesInside {
            get {
                return _PlaceValuesInside;
            }
            set {
                _PlaceValuesInside = value;
            }
        }

        string _SlantLabels = "0";
        /// <summary>
        /// Gets or sets the slant labels.
        /// </summary>
        /// <value>The slant labels.</value>
        public string SlantLabels {
            get {
                return _SlantLabels;
            }
            set {
                _SlantLabels = value;
            }
        }

        string _LabelDisplay = "";
        /// <summary>
        /// Gets or sets the label display.
        /// </summary>
        /// <value>The label display.</value>
        public string LabelDisplay {
            get {
                return _LabelDisplay;
            }
            set {
                _LabelDisplay = value;
            }
        }

        string _ShowBorder = "0";
        /// <summary>
        /// Gets or sets the show border.
        /// </summary>
        /// <value>The show border.</value>
        public string ShowBorder {
            get {
                return _ShowBorder;
            }
            set {
                _ShowBorder = value;
            }
        }

        string _PieSliceDepth = "10";
        /// <summary>
        /// Gets or sets the pie slice depth.
        /// </summary>
        /// <value>The pie slice depth.</value>
        public string PieSliceDepth {
            get {
                return _PieSliceDepth;
            }
            set {
                _PieSliceDepth = value;
            }
        }

        string _EnableSmartLabels = "0";
        /// <summary>
        /// Gets or sets the enable smart labels.
        /// </summary>
        /// <value>The enable smart labels.</value>
        public string EnableSmartLabels {
            get {
                return _EnableSmartLabels;
            }
            set {
                _EnableSmartLabels = value;
            }
        }

        string _Border = "10";
        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public string Border {
            get {
                return _Border;
            }
            set {
                _Border = value;
            }
        }

        int _Width = 600;
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width {
            get {
                return _Width;
            }
            set {
                _Width = value;
            }
        }

        int _Height = 300;
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height {
            get {
                return _Height;
            }
            set {
                _Height = value;
            }
        }

        private string _ShowValues = "0";
        /// <summary>
        /// Gets or sets the show values.
        /// </summary>
        /// <value>The show values.</value>
        public string ShowValues {
            get { return _ShowValues; }
            set { _ShowValues = value; }
        }

        private SeriesCollection _Series = new SeriesCollection();
        public SeriesCollection SeriesCollection {
            get {
                return _Series;
            }
            set {
                _Series = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is post back.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is post back; otherwise, <c>false</c>.
        /// </value>
        public bool IsPostBack { get; set; }

        ChartValueType _ChartXAxisValueType = ChartValueType.String;
        /// <summary>
        /// Gets or sets the type of the chart X axis value.
        /// </summary>
        /// <value>The type of the chart X axis value.</value>
        public ChartValueType ChartXAxisValueType {
            get {
                return _ChartXAxisValueType;
            }
            set {
                _ChartXAxisValueType = value;
            }
        }


        ChartValueType _ChartYAxisValueType = ChartValueType.Numeric;
        /// <summary>
        /// Gets or sets the type of the chart Y axis value.
        /// </summary>
        /// <value>The type of the chart Y axis value.</value>
        public ChartValueType ChartYAxisValueType {
            get {
                return _ChartYAxisValueType;
            }
            set {
                _ChartYAxisValueType = value;
            }
        }


        private ChartTrendLines _TrendLines = new ChartTrendLines();
        public ChartTrendLines TrendLines {
            get {
                return _TrendLines;
            }
            set {
                _TrendLines = value;
            }
        }

        private string _XmlString = string.Empty;
        public string XmlString {
            get { return _XmlString; }
            set { _XmlString = value; }
        }

        private string _XmlFile = string.Empty;
        public string XmlFile {
            get { return _XmlFile; }
            set { _XmlFile = value; }
        }

        public static string GenerateChartID() {
            return string.Format("{0}", System.Guid.NewGuid().ToString().Replace('-', '_'));
        }

        private string GetChartProperties() {
            string properties = string.Format("<chart caption='{0}'  numberPrefix='{1}' formatNumberScale='{2}' rotateValues='{3}' placeValuesInside='{4}' showBorder='{5}' showValues='{11}' labelDisplay='{6}' slantLabels='{7}' decimals='0' pieSliceDepth='{8}' enableSmartLabels='{9}' chartLeftMargin ='{10}'  chartRightMargin ='{10}' chartTopMargin ='{10}'  chartBottomMargin ='{10}' xAxisName='{12}' yAxisName='{13}' PYAxisName='{14}' SYAxisName='{15}'>",
              Title,
              NumberPrefix,
              FormatNumberScale,
              RotateValues,
              PlaceValuesInside,
              ShowBorder,
              LabelDisplay,
              SlantLabels,
              PieSliceDepth,
              EnableSmartLabels,
              Border, ShowValues, XAxisName, YAxisName, SYAxisName, PYAxisName
              );
            return properties;
        }

        protected override void OnPreRender(EventArgs e) {
            ClientScriptManager cs = this.Page.ClientScript;
            string resourceName = "XWT.Charts.fusioncharts.min.js";
            //RegisterScript(resourceName, head);
            cs.RegisterClientScriptResource(typeof(XWT.Charts.XWTChart), resourceName);
            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.Write(this.Create());
            base.Render(writer);
        }

        public string Create() {
            string xml;
            StringBuilder xmlData = new StringBuilder();

            ID = GenerateChartID();

            if (_Series.Count == 1) {
                xmlData.Append(GetChartProperties());

                foreach (Series series in _Series) {
                    foreach (Point point in series.Points) {
                        xmlData.AppendFormat("<set label='{0}' value='{1}' />", point.Label, point.Value);
                    }
                }
                xmlData.Append(GetTrendLineString());
                xmlData.Append("</chart>");
                _XmlString = xmlData.ToString();

            } else if (_Series.Count > 1) {
                xmlData.Append(GetChartProperties());
                _Series.Sort();
                Series topSeriesItem = _Series[0];

                List<string> categories = new List<string>();
                xmlData.Append("<categories>");

                foreach (Point item in topSeriesItem.Points) {
                    categories.Add(item.Label);
                    xmlData.AppendFormat("<category label='{0}' />", item.Label);
                }

                xmlData.Append("</categories>");

                foreach (Series seriesItem in _Series) {
                    xmlData.AppendFormat("<dataset seriesName='{0}' {1}>", seriesItem.Name, seriesItem.SeriesChartType == SeriesChartType.Default ? "" : string.Format(" renderAs='{0}'", seriesItem.SeriesChartType.GetString()));
                    foreach (string pItem in categories) {
                        xmlData.AppendFormat("<set value='{0}' />", seriesItem.Points[pItem] == null ? "" : seriesItem.Points[pItem].Value);
                    }

                    xmlData.Append("</dataset>");
                }

                xmlData.Append(GetTrendLineString());
                xmlData.Append("</chart>");
                _XmlString = xmlData.ToString();

            } else if (string.IsNullOrEmpty(_XmlFile)) {

            }

            if (this.IsPostBack) {
                xml = FusionCharts.RenderChartHTML("FusionCharts/" + ChartType.GetString(), _XmlFile, XmlString, ID, Width.ToString(), Height.ToString(), false, false);
            } else {
                xml = FusionCharts.RenderChart("FusionCharts/" + ChartType.GetString(), _XmlFile, XmlString, ID, Width.ToString(), Height.ToString(), false, false);
            }
            return xml;// FusionCharts.RenderChart("FusionCharts/MSColumn3D.swf", "MultiseriesChart.xml", "", ID, "500", "300", false, false); 
        }


        private string GetTrendLineString() {
            StringBuilder str = new StringBuilder();
            str.Append(" <trendlines>");
            foreach (ChartTrendLine item in _TrendLines) {
                str.AppendFormat("<line startValue='{0}' color='{1}' displayValue='{2}' showOnTop='{3}'/>", item.StartValue, item.Color, item.DisplayValue, item.ShowOnTop);
            }
            str.Append(" </trendlines>");

            return str.ToString();
        }
    }
}
