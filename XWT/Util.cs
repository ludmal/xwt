#region License
/*
 **************************************************************
 *  Author: Ludmal de silva
 *          © XWT Solutions, 2010
 *          http://www.infonexsolutions.com/
 * 
 * Created: 12/11/2009
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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XWT {
    public class Util {

        public static Control FindControlRecursively(string controlID, ControlCollection controls) {
            if (controlID == null || controls == null)
                return null;

            foreach (Control c in controls) {
                if (c.ID == controlID)
                    return c;

                if (c.HasControls()) {
                    Control inner = FindControlRecursively(controlID, c.Controls);
                    if (inner != null)
                        return inner;
                }

            }
            return null;
        }

        public static DateTime ParseUTCDateTime(string dateTime) {
            return DateTime.SpecifyKind(Convert.ToDateTime(dateTime), DateTimeKind.Utc);
        }

        public static string FormatWebUrl(string url) {

            if (!string.IsNullOrEmpty(url)) {
                if (url.IndexOf("http://") == -1) {
                    return string.Format("http://{0}", url);
                }
                return url;
            }
            return string.Empty;
        }

        public static void AddDropDownText(DropDownList ddl, string text) {
            ddl.Items.Insert(0, new ListItem(text, "0"));
        }
        public static void ListBoxSort(ListBox sortList) {
            string ID = string.Empty;
            string Text = string.Empty;

            for (int x = 0; x < sortList.Items.Count - 1; x++) {
                for (int y = x + 1; y < sortList.Items.Count; y++) {
                    if (sortList.Items[x].Text.CompareTo(sortList.Items[y].Text) != -1) {
                        // Swap rows
                        ID = sortList.Items[x].Value;
                        Text = sortList.Items[x].Text;
                        sortList.Items[x].Value = sortList.Items[y].Value;
                        sortList.Items[x].Text = sortList.Items[y].Text;
                        sortList.Items[y].Value = ID;
                        sortList.Items[y].Text = Text;
                    }
                }
            }
        }

        public static void ListBoxRemoveDuplicateListItems(ListBox all, ListBox assigned) {
            for (int x = 0; x < assigned.Items.Count; x++) {
                for (int y = 0; y < all.Items.Count; y++) {
                    if (all.Items[y].Text == assigned.Items[x].Text) {
                        all.Items.Remove(new ListItem(all.Items[y].Text, all.Items[y].Value));
                    }
                }
            }
        }

        public static string LineBreakAdd(string text) {
            text = text.Replace("\r\n", "</br>");
            return text;
        }

        public static string LineBreakRemove(string text) {
            text = text.Replace("<br/>", "\r\n");
            return text;
        }

        public static string LineBreakTrim(string text) {
            if (!string.IsNullOrEmpty(text)) {
                text = text.Replace("", "\r\n");
            }
            return text;
        }
    }
}
