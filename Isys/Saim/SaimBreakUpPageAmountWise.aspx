﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaimBreakUpPageAmountWise.aspx.cs" Inherits="Application_ISys_Saim_SaimBreakUpPageAmountWise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>KMT</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta content="" name="description"/>
<meta content="" name="author"/>
<meta name="MobileOptimized" content="320">
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2_metro.css"/>
<!-- END PAGE LEVEL SCRIPTS -->
<!-- BEGIN THEME STYLES -->
<link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/plugins.css" rel="stylesheet" type="text/css"/>
<%--<link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>--%>
<link href="assets/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="favicon.ico"/>

<script type="text/javascript" >
 function Print() {


        document.getElementById("btn1").style.visibility = "hidden"
        document.getElementById("btn2").style.visibility = "hidden"
        document.getElementById("btn3").style.visibility = "hidden"


        window.print();

      

    }

    </script>
</head>
<body>
<form runat="server" >
    <br />
     <div style="margin-left:30px;margin-right:30px" id="divtest" runat="server">
   
    </div>

     <br />

    <div >
    <center>
    	  <asp:Button   ID="btn1" runat="server"  onclick="Button1_Click" Text="Download Report" 
                                                                CssClass="btn default" />                                                          
		<button  id ="btn2" onclick="Print()" type="button" class="btn default">Print</button>

          <input class="btn default" id="btn3" onclick="window.close()" type="button" 
              value="Close" /><%--<button  id ="btn3" type="button" onclick="close();" class="btn default">Close</button>--%><asp:GridView ID="GridView1"  runat="server">
        </asp:GridView>
        
        </center>
    </div>
    <br />
    </form>
</body>
</html>
