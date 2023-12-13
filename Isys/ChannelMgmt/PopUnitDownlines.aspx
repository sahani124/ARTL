<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUnitDownlines.aspx.cs" Inherits="Application_ISys_ChannelMgmt_PopUnitDownlines" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>PopUnitDownlines</title>
<style type="text/css">
.databox-header
{
    FONT: bold 12px/16px "Lucida Grande","Lucida Sans Unicode",Helvetica,Arial,Verdana,sans-serif; 
    WHITE-SPACE: nowrap; 
    COLOR: #000000; 
    OVERFLOW: hidden; 
    MARGIN-RIGHT: 20px;
}
.databox-Address
{
     DISPLAY: block; 
     FONT: 12px/18px "Lucida Grande","Lucida Sans Unicode",Helvetica,Arial,Verdana,sans-serif; 
     COLOR: #333333;
 }    
 #pnl_Body
 {
 background-color:#E8E8E8; background-repeat:repeat-x; width:100%; height:100%;    
 }
</style>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <center><asp:Label ID="lblStatusMsg" runat="server" CssClass="standardlabel" ForeColor="Red" Font-Size="Medium"/></center>
    <asp:Panel runat="server" ID="pnl_Body" HorizontalAlign="Justify" ScrollBars="Auto">
        <asp:Literal ID="Literal" runat="server" />
    </asp:Panel>
</body>
</html>
