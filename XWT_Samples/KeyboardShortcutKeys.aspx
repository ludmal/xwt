<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KeyboardShortcutKeys.aspx.cs"
    Inherits="KeyboardShortcutKeys" %>

<%@ Register Assembly="XWT.Web.Controls" Namespace="XWT.Web.Controls" TagPrefix="xwt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>
        function showThis() {
            $("#key_div").show("slow");
        }

        function showAlert() {
            alert('Hey you pressed a key!');
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="key_div" style="display: none">
        Hey! You just pressed key!
    </div>
    <xwt:PageManager ID="PageManager1" runat="server">
    </xwt:PageManager>
    <xwt:ShortcutKey ID="ShortcutKey1" Key="a" FunctionName="showThis" runat="server" />
    <xwt:ShortcutKey ID="ShortcutKey2" runat="server" FunctionName="showAlert" 
        Key="b" />
    <xwt:ShortcutKey ID="ShortcutKey3" Key="g" FunctionName="showThis" runat="server" />
    </form>
</body>
</html>
