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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.ComponentModel;
namespace XWT.Web.Controls {

    [NonVisualControl, Designer(typeof(PreservePropertyControlDesigner))]
    [ToolboxData("<{0}:XWTShortcutKey runat=\"server\"></{0}:XWTShortcutKey>")]
    [ToolboxBitmap(typeof(HyperLink))]
    public class XWTShortcutKey : WebControl  {

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Function to be called")]
        public string FunctionName {
            get {
                String s = (String)ViewState["FunctionName"];
                return ((s == null) ? string.Empty : s);
            }

            set {
                ViewState["FunctionName"] = value;
            }
        }

        private XWTKeyCode _Key = XWTKeyCode.a;
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Shortcut Key")]
        public  XWTKeyCode Key {
            get {
                if (ViewState["ShortcutKey"] == null) {
                    return _Key;
                }
                return (XWTKeyCode)ViewState["ShortcutKey"];
            }

            set {
                ViewState["ShortcutKey"] = value;
            }
        }


        protected override void Render(HtmlTextWriter writer) {
            writer.Write("<script>$(document).ready(function(){$(document).keypress(function(e){if(e.which=='" + Key.GetKeyCode() + "'){" +  FunctionName + "();}});});</script>");
            base.Render(writer);
        }
    }
}
