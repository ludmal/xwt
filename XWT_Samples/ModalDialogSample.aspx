<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModalDialogSample.aspx.cs" Inherits="ModalDialogSample" %>

<%@ Register assembly="XWT.Web.Controls" namespace="XWT.Web.Controls" tagprefix="xwt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function showModal() {
            var width = $("input[id$='TextBox1']").val();
            var height = $("input[id$='TextBox2']").val();
            modal.show('ModalDialogContent.htm', 'Welcome to Simple Modal Dialog', width, height);
        }
    </script>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <xwt:PageManager ID="PageManager1" runat="server">
        </xwt:PageManager>
    
    </div>
    <xwt:ModalDialog ID="ModalDialog1" runat="server" />
    
    <span class="link" onclick="modal.show('ModalDialogContent.htm','Welcome to Simple Modal Dialog');">Show ModalDialog using iFrame</span><br />
    <span class="link" onclick="modal.showHtml('<b>Modal Dialog content using html</b>','Welcome to Simple Modal Dialog');">Show ModalDialog using Html</span>
    <br />
    <br />
 
    </form>
</body>
</html>
