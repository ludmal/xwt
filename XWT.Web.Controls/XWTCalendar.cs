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
using System.Text;

[assembly: TagPrefix("XWT.Web.Controls", "xwt")]
namespace XWT.Web.Controls {
    [NonVisualControl, Designer(typeof(PreservePropertyControlDesigner))]
    [ToolboxData("<{0}:XWTCalendar runat=\"server\"></{0}:XWTCalendar>")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.Calendar))]
    public class XWTCalendar : WebControl {

        private int _Size = 15;

        [Browsable(true)]
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Width")]
        public int Size {
            get {
                return _Size;
            }
            set {
                _Size = value;
            }
        }

        private string _DateFormat = "dd/mm/yyyy";

        [Browsable(true)]
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("DateTime Format")]
        public string DateFormat {
            get {
                return _DateFormat;
            }
            set {
                _DateFormat = value;
            }
        }

        [Browsable(true)]
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [Editor(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Description("URL for the Calender Image")]
        public string ImageUrl {
            get {
                String s = (String)ViewState["ImageUrl"];
                return ((s == null) ? string.Empty : s);
            }

            set {
                ViewState["ImageUrl"] = value;
            }
        }

        public string ControlID {
            get {
                return string.Format("__{0}", this.ClientID);
            }    
        }

        protected override void Render(HtmlTextWriter writer) {
            ClientScriptManager cs = this.Page.ClientScript;
            Type rsType = this.GetType();
            string upUrl = cs.GetWebResourceUrl(rsType, "XWT.Web.Controls.up.gif");
            string downUrl = cs.GetWebResourceUrl(rsType, "XWT.Web.Controls.down.gif");
            string calUrl = cs.GetWebResourceUrl(rsType, "XWT.Web.Controls.calendar.png");

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<input id=\"__{0}\" name=\"__{0}\" size=\"{1}\" type=\"text\" />", this.ClientID, Size);
            builder.Append("<a href=\"javascript: void(0);\"");
            builder.AppendFormat("onclick=\"g_Calendar.show('#__{0}','{3}','{4}',event,'{2}.__{0}', false, '{1}'); return false;\"", this.ClientID, DateFormat, this.Page.Form.ClientID, upUrl, downUrl );
            builder.Append("onmouseout=\"if (timeoutDelay) calendarTimeout();window.status='';\"");
            builder.Append("onmouseover=\"if (timeoutId) clearTimeout(timeoutId);window.status='Show Calendar';return true;\">");
            builder.AppendFormat("<img alt=\"\" border=\"0\" name=\"imgCalendar\" src=\"{0}\" /></a>", string.IsNullOrEmpty(ImageUrl)?calUrl:Page.ResolveClientUrl(ImageUrl));

            writer.Write(builder.ToString());
            base.Render(writer);
        }
    }
}
