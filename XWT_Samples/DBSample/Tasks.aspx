<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tasks.aspx.cs" Inherits="DBSample_Tasks" %>

<%@ Register Assembly="XWT.Web.Controls" Namespace="XWT.Web.Controls" TagPrefix="xwt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    

    <link href="../style.css" rel="stylesheet" type="text/css" />

</head>
<body>
<script type="text/javascript" type="text/javascript">
    function showMsg() {
        //$("#hey").addClass("xwt_msg1 xwt_msg2");
        msg.text('hey ludmal');
        return false;
    }    
    </script>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
            Text="Button" />
    </div>
    <div id="hey" style="display: inline">
        This is shit of the house
    </div>
    <xwt:XWTPageManager ID="XWTPageManager1" runat="server">
    </xwt:XWTPageManager>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    
    <ul>
       <% foreach(var n in this.Model) {%>
            <li>
                <%= Html.Encode(n.Name) %>
            </li>
       <%}%> 
    </ul>
    <xwt:XWTMessageControl ID="XWTMessageControl1" runat="server" />
    <xwt:XWTButtonControl ID="XWTButtonControl1" runat="server">Hey Hey</xwt:XWTButtonControl>
    </form>
</body>
</html>
