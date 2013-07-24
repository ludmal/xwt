<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="XWT.Web.Controls" namespace="XWT.Web.Controls" tagprefix="iwt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function show() {
            $("#div1").show();
            callMe();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/MessageControlSample.aspx">Message Control</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/ModalDialogSample.aspx">Model Dialog</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink3" runat="server" 
        NavigateUrl="~/PageManagerSample.aspx">PageManager</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink4" runat="server" 
        NavigateUrl="~/ButtonsSample.aspx">Buttons</asp:HyperLink>
          <br />
          <asp:HyperLink ID="HyperLink5" runat="server" 
        NavigateUrl="~/KeyboardShortcutKeys.aspx">Keyboard Shortcut Keys</asp:HyperLink>
    <br />
    
    </form>
</body>
</html>
