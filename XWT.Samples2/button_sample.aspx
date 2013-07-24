<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="button_sample.aspx.cs" Inherits="XWT.Samples2.button_sample" %>
<%@ Register assembly="XWT.Web.Controls" namespace="XWT.Web.Controls" tagprefix="xwt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <xwt:XWTPageManager ID="XWTPageManager1" runat="server">
        </xwt:XWTPageManager>
    
    </div>
    <xwt:XWTButtonControl ID="XWTButtonControl1" OnClientClick="javascript:msg.text('asdfsadfasd','xwt_msg','');" runat="server" Text="Click me" 
        onclick="XWTButtonControl1_Click" />
    <xwt:XWTMessageControl ID="XWTMessageControl1" runat="server" />
    </form>
</body>
</html>
