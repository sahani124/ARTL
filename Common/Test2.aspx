<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Application_Common_Test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="~/Styles/main.css" />    
<script type="text/javascript" src="~/Scripts/common.js"></script>
<script type="text/javascript" src="~/Scripts/subModal.js"></script>
<script type="text/javascript" language="javascript">
var path = "<%=Request.ApplicationPath.ToString()%>";
</script>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
bbbbbbbbbbbbb
<input onclick="showPopWin('PopCountry.aspx', 500, 200, null);" id="Button1" type="button" value="button" />
    </div>
    </form>
</body>
</html>
