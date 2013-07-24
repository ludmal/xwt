<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageControlSample.aspx.cs" Inherits="MessageControlSample" %>

<%@ Register assembly="XWT.Web.Controls" namespace="XWT.Web.Controls" tagprefix="xwt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <xwt:PageManager ID="PageManager1" runat="server">
    </xwt:PageManager>
    <xwt:MessageControl ID="MessageControl1" runat="server" />
    </form>
    <p>
        <span class="link" 
            onclick="msg.text('Record successfully saved!');">
        Show User Message</span><br />
        
        <span class="link" 
            onclick="msg.html('Record successfully saved! <a href=http://www.google.com>Click here</a>');">
        Show User Html Message </span><br />
    </p>
    <p>
        Note: Message will disapear after 10 seconds.</p>
</body>
</html>
