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

    [ToolboxData("<{0}:ActionMenu runat=\"server\"></{0}:ActionMenu>")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.Menu))]
    public class ActionMenu : WebControl {
        private List<ActionMenuItem> _ActionMenuItems = new List<ActionMenuItem>();
        public List<ActionMenuItem> ActionMenuItems {
            get {
                //if (ViewState["_XWT_ACTION_ITEMS"] == null) {
                //    ViewState["_XWT_ACTION_ITEMS"] = _ActionMenuItems;
                //    return _ActionMenuItems;
                //}
                //return (List<ActionMenuItem>)ViewState["_XWT_ACTION_ITEMS"];
                return _ActionMenuItems;
            }
            set {
                _ActionMenuItems = value;
            }
        }

        public string Text { get; set; }

        private string _ActionMenuBodyCssClass = "menu_body";
        public string ActionMenuBodyCssClass {
            get {
                return _ActionMenuBodyCssClass;
            }
            set {
                _ActionMenuBodyCssClass = value;
            }
        }

        public string RenderHtml() {
            StringBuilder html = new StringBuilder();
            html.AppendFormat("<div id=\"menu_head\" class=\"btn\"><span><span>{0}</span></span></div>", Text);
            html.AppendFormat("<ul class=\"{0}\"> ", _ActionMenuBodyCssClass );

            for (int i = 0; i < _ActionMenuItems.Count; i++) {
                html.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", _ActionMenuItems[i].NavigateUrl, _ActionMenuItems[i].Text);
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

    [Serializable]
    public class ActionMenuItem {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }

    }
}
