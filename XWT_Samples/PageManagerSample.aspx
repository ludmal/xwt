<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageManagerSample.aspx.cs" Inherits="PageManagerSample" %>

<%@ Register assembly="XWT.Web.Controls" namespace="XWT.Web.Controls" tagprefix="xwt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function show() {
            $("#div1").fadeIn("slow");
        }
    </script>
    
    <link href="style.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <xwt:PageManager ID="PageManager1" runat="server">
        </xwt:PageManager>
    <span class="link" onclick="show();">
        <br />
        Click Me</span>
    <div id="div1" style="display:none">Hello World!</div>
    </div>
    </form>
    <p>Note:<br />
        Page manager help developers to write JQuery code without having them to add the 
        JQuery library script file. PageManager control contains the latest JQuery library and it 
        supports CDN configuration. Use PageManager properties to configure the 
        PageManager or use web.config file to configure the scripts application wide.
    </p>
</body>
</html>
