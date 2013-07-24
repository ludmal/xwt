<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ButtonsSample.aspx.cs" Inherits="ButtonsSample" %>

<%@ Register assembly="XWT.Web.Controls" namespace="XWT.Web.Controls" tagprefix="XWT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <XWT:PageManager ID="PageManager1" runat="server">
        </XWT:PageManager>
        <XWT:ButtonControl ID="ButtonControl1" runat="server">
            Click Me</XWT:ButtonControl>
    
    </div>
    <XWT:ImageButtonControl ID="ImageButtonControl1" runat="server" 
        ImageUrl="~/1281345437_cross.png">Click Me</XWT:ImageButtonControl>
    </form>
</body>
</html>
