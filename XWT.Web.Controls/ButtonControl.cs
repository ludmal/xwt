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
 ****************************************************************  
*/
#endregion

using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;

[assembly: TagPrefix("XWT.Web.Controls", "xwt")]
namespace XWT.Web.Controls {
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:XWTButtonControl runat=server></{0}:XWTButtonControl>")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.Button))]
    public class XWTButtonControl : Button {
        //[Bindable(true)]
        //[Category("Appearance")]
        //[DefaultValue("Button")]
        //[Localizable(true)]
        //[Description("Text to be appear on the button")]
        //public override string Text {
        //    get {
        //        String s = (String)ViewState["Text"];
        //        return ((s == null) ? string.Empty : s);
        //    }

        //    set {
        //        ViewState["Text"] = value;
        //    }
        //}

        //protected override void RenderContents(HtmlTextWriter output) {
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendFormat("<span><span>&nbsp;{0}&nbsp;", Text);
        //    sb.Append("</span></span>");
            
        //    output.Write(sb.ToString());
        //}

        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer) {
            writer.AddAttribute("class", "button blue");
            base.AddAttributesToRender(writer);
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
        }
    }
}
