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

using System.Drawing;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.ComponentModel;

[assembly: TagPrefix("XWT.Web.Controls", "xwt")]
namespace XWT.Web.Controls {

    [NonVisualControl, Designer(typeof(PreservePropertyControlDesigner))]
    [ToolboxData("<{0}:XWTMessageControl runat=\"server\"></{0}:XWTMessageControl>")]
    [ToolboxBitmap(typeof(Label))]
    public class XWTMessageControl : WebControl {
        protected override void Render(HtmlTextWriter writer) {
            writer.Write("<div id=\"___msg_box\" class=\"msg_iwt_core\"\"></div>");
            base.Render(writer);
        }

        public void SetMsg(string msg) {
            
        }
        public void SetMsg(string msg, MessageMode messageMode) {
            string className = "xwt_msg";

            switch (messageMode) {
                case MessageMode.Success:
                    className = "xwt_msg";
                    break;
                case MessageMode.Warning:
                    className = "xwt_error";
                    break;
                case MessageMode.Error:
                    className = "xwt_error";
                    break;
                default:
                    className = "xwt_msg";
                    break;
            }

            Page.RegisterStartupScript("__SC_MSG", System.String.Format("<script>msg.text('{0}', '{1}','');</script>", msg.Replace("'", ""), className));

           // Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "__SC_MSG", System.String.Format("<script>msg.text('{0}');</script>", msg));
        }
    }

    public enum MessageMode { 
        Success,
        Warning,
        Error
    }
}
