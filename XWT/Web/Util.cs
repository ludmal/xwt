using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace XWT.Web {
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
    }
}
