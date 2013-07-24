using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XWT.Charts {
    public enum SeriesChartType {
        [StringValue("")]
        Default,
        [StringValue("Area")]
        Area,
        [StringValue("Line")]
        Line,
    }

    public enum ChartTypeEnum {
        [StringValue("Area2D.swf")]
        Area2D,

        [StringValue("Bar2D.swf")]
        Bar2D,

        [StringValue("Column2D.swf")]
        Column2D,

        [StringValue("Column3D.swf")]
        Column3D,

        [StringValue("Doughnut2D.swf")]
        Doughnut2D,

        [StringValue("Doughnut3D.swf")]
        Doughnut3D,

        [StringValue("Line.swf")]
        Line,

        [StringValue("MSArea.swf")]
        MSArea,

        [StringValue("MSBar2D.swf")]
        MSBar2D,

        [StringValue("MSBar3D.swf")]
        MSBar3D,

        [StringValue("MSColumn2D.swf")]
        MSColumn2D,

        [StringValue("MSColumn3D.swf")]
        MSColumn3D,

        [StringValue("MSCombi2D.swf")]
        MSCombi2D,

        [StringValue("MSCombi3D.swf")]
        MSCombi3D,

        [StringValue("MSLine.swf")]
        MSLine,

        [StringValue("Pie2D.swf")]
        Pie2D,

        [StringValue("Pie3D.swf")]
        Pie3D,

        [StringValue("Scatter.swf")]
        Scatter,

        [StringValue("StackedArea2D.swf")]
        StackedArea2D,

        [StringValue("StackedColumn2D.swf")]
        StackedColumn2D,

        [StringValue("StackedColumn3D.swf")]
        StackedColumn3D,

        [StringValue("StackedBar3D.swf")]
        StackedBar3D,

        [StringValue("StackedBar2D.swf")]
        StackedBar2D
        
    }

    public enum MessageType {
        Error, Info, Success
    }

    public enum ChartValueType {
        Date, String, Money, Numeric
    }
}
