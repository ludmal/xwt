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
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Drawing.Design;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design;
using System.Drawing;
using System.Configuration;

[assembly: TagPrefix("XWT.Web.Controls", "xwt")]
namespace XWT.Web.Controls {
    [NonVisualControl, Designer(typeof(PreservePropertyControlDesigner))]
    [DefaultProperty("EnableCDN")]
    [ToolboxData("<{0}:XWTPageManager runat=\"server\"></{0}:XWTPageManager>")]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.Substitution))]
    public class XWTPageManager : WebControl {
        private const string CDN_URL = "http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"; 
        
        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Javascript file name")]
        [EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
        public string JQueryFileName {
            get {
                String s = (String)ViewState["FileName"];
                return ((s == null) ? string.Empty : s);
            }

            set {
                ViewState["FileName"] = value;
            }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Url of the CDN(Content Delivery Network Location")]
        public string CDNUrl {
            get {
                String s = (String)ViewState["CDNUrl"];
                return ((s == null) ? CDN_URL : s);
            }

            set {
                ViewState["CDNUrl"] = value;
            }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [Description("This will bind the jquery file from Google CDN location. It is false by default.")]
        public bool EnableCDN {
            get {
                if (ViewState["UseCDN"] != null) {
                    return Convert.ToBoolean(ViewState["UseCDN"]);
                }
                return false;
            }


            set {
                ViewState["UseCDN"] = value;
            }
        }

        private void RegisterScript(ClientScriptManager cs, string scriptfile, HtmlHead head) {
            //LiteralControl lctl = new LiteralControl(string.Format("<script src=\"{0}\" type=\"text/javascript\" />", this.Page.ClientScript.GetWebResourceUrl(typeof(XWT.Web.Controls.PageManager), scriptfile)));
            //head.Controls.Add(lctl);
            if (!string.IsNullOrEmpty(scriptfile) && scriptfile.Length > 2) {
                cs.RegisterClientScriptInclude(typeof(XWT.Web.Controls.XWTPageManager), scriptfile.Substring(0, scriptfile.LastIndexOf(".js")), Page.ResolveClientUrl(scriptfile));
            }
        }

        protected override void OnPreRender(EventArgs e) {
            ClientScriptManager cs = this.Page.ClientScript;
            RegisterCssLink(this);
            HtmlHead head = Page.Header;

            CustomScriptsConfig logConfig = (CustomScriptsConfig)ConfigurationManager.GetSection("customScripts");

            if (logConfig != null && logConfig.Enable) {
                foreach (CustomScript item in logConfig.Elements) {
                    _Scripts.Add(new ScriptFile() { File = item.Path, Enable = item.Enable });
                }
                if (logConfig.EnableCDN) {
                    if (!string.IsNullOrEmpty(logConfig.CDNUrl)) {
                        if (HttpContext.Current.Items["__CDN"] == null) {
                            cs.RegisterClientScriptInclude(typeof(XWT.Web.Controls.XWTPageManager), "__CDN_J", logConfig.CDNUrl);
                        }
                    } else {
                        if (HttpContext.Current.Items["__CDN"] == null) {
                            cs.RegisterClientScriptInclude(typeof(XWT.Web.Controls.XWTPageManager), "__CDN_J", CDNUrl);
                        } 
                    }
                } else { 
                    if (!string.IsNullOrEmpty(logConfig.JQueryFile)) {
                        cs.RegisterClientScriptInclude(typeof(XWT.Web.Controls.XWTPageManager), "__JS_URL", Page.ResolveClientUrl(logConfig.JQueryFile));

                    } else {
                        string resourceName = Constants.JQUERY_FILE ;
                        //RegisterScript(resourceName, head);
                        cs.RegisterClientScriptResource(typeof(XWT.Web.Controls.XWTPageManager), resourceName);
                    } 
                }

            } else {
                if (!EnableCDN) {
                    if (string.IsNullOrEmpty(JQueryFileName)) {
                        string resourceName = Constants.JQUERY_FILE;
                        //RegisterScript(resourceName, head);
                        cs.RegisterClientScriptResource(typeof(XWT.Web.Controls.XWTPageManager), resourceName);
                    } else {
                        if (JQueryFileName.Substring(JQueryFileName.Length - 2, 2).ToLower() != "js") { throw new InvalidCastException("Invalid Javascript file"); }
                        cs.RegisterClientScriptInclude(typeof(XWT.Web.Controls.XWTPageManager), "__JS_URL", Page.ResolveClientUrl(JQueryFileName));
                    }
                } else {
                    if (HttpContext.Current.Items["__CDN"] == null) {
                        cs.RegisterClientScriptInclude(typeof(XWT.Web.Controls.XWTPageManager), "__CDN_J", CDNUrl);
                    }
                }
            }

            foreach (ScriptFile script in Scripts) {
                if (script.Enable) {
                    RegisterScript(cs, script.File, head);
                }
            }

            string global = "XWT.Web.Controls.g.min.js";
            cs.RegisterClientScriptResource(typeof(XWT.Web.Controls.XWTPageManager), global);

            base.OnPreRender(e);
        }

        private Scripts _Scripts = new Scripts();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]  // .Visible Content generates code for each page
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Scripts Scripts {
            get {
                return _Scripts;
            }
            set {
                _Scripts = value;
            }
        }

        public void RegisterCssLink(Control control) {

            if (HttpContext.Current.Items["_ADD"] != null)
                return;

            Control container = control.Page.Header;
            if (container == null)
                container = control.Page.Form;

            if (container == null)
                throw new InvalidOperationException("There's no header or form to add CSS to Register Resource CSS on the page.");

            string output = "<link rel=\"stylesheet\" type=\"text/css\" href=\"" + control.Page.ClientScript.GetWebResourceUrl(control.GetType(), "XWT.Web.Controls.skin.min.css") + "\" />";

            container.Controls.Add(new LiteralControl(output));

            HttpContext.Current.Items.Add("_ADD", 1);
        }
    }

    internal class PreservePropertyControlDesigner : ControlDesigner {
        public override string GetDesignTimeHtml() {
            return base.CreatePlaceHolderDesignTimeHtml("");
        }
    }

    public class ScriptFile {
        [EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
        public string File { get; set; }
        private bool _Enable = true;
        public bool Enable {
            get { return _Enable; }
            set {
                _Enable = value;
            }
        }
    }

    public class Scripts : System.Collections.Generic.List<ScriptFile> {

    }
}
