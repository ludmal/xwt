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
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("XWT.Web.Controls", "xwt")]
namespace XWT.Web.Controls {
    public class VerticalMenu : MenuBase {

        private List<XWTMenuItem> _MenuItems = new List<XWTMenuItem>();
        public List<XWTMenuItem> MenuItems {
            get {
                return _MenuItems;
            }
            set {
                _MenuItems = value;
            }
        }

        private string _ActionMenuBodyCssClass = "v_menu";
        public string ActionMenuBodyCssClass {
            get {
                return _ActionMenuBodyCssClass;
            }
            set {
                _ActionMenuBodyCssClass = value;
            }
        }

        private string _CssClass = "";
        public string CssClass {
            get {
                return _CssClass;
            }
            set {
                _CssClass = value;
            }
        }

        private string RegisterImage(string imageUrl) {
            if (!string.IsNullOrEmpty(imageUrl)) {
                return string.Format("<img src=\"{0}\" />", imageUrl);
            }
            return string.Empty;
        }

        public string RenderHtml() {
            StringBuilder html = new StringBuilder();
            html.AppendFormat("<ul class=\"{0} {1}\"> ", _ActionMenuBodyCssClass, _CssClass );

            for (int i = 0; i < _MenuItems.Count; i++) {
                html.AppendFormat("<li><a href=\"{0}\" id=\"{1}\">{2}&nbsp;{3}</a></li>", _MenuItems[i].NavigateUrl,_MenuItems[i].Text,RegisterImage(_MenuItems[i].ImageUrl),_MenuItems[i].Text);
            }

            html.Append("</ul>");
            return html.ToString();
        }

        protected override void Render(HtmlTextWriter writer) {
            //writer.Write(this.RenderHtml());

            writer.Write(this.RenderHtml());
            base.Render(writer);
        }

    }
}
