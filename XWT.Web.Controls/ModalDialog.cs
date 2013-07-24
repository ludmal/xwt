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
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("XWT.Web.Controls", "xwt")]
namespace XWT.Web.Controls {

    [NonVisualControl, Designer(typeof(PreservePropertyControlDesigner))]
    [ToolboxData("<{0}:XWTModalDialog runat=\"server\"></{0}:XWTModalDialog>")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.WebParts.PageCatalogPart))]
    public class XWTModalDialog : WebControl {
        protected override void Render(HtmlTextWriter writer) {
            writer.Write("<div id=\"overlay\" class=\"modal_overlay\" style=\"background-color: #000\"></div><div id=\"modal_outer\" style=\"display: none;\"><div id='modal_frame'><table cellpadding=\"0\" id=\"modal_title\" cellspacing=\"0\"><tr><td ><div id=\"modalTitle\" ></div></td><td class=\"set_right\"><div class=\"modal_close set_righ\" onclick=\"modal.c();\"></div> </td></tr></table><div id=\"modal_iframe\"><iframe src='' id=\"modalIFrame\" style=\"background-color: #fff\" frameborder=\"0\" width=\"100%\"height=\"100%\"></iframe></div> </div> </div>");
            base.Render(writer);
        }
    }
}
