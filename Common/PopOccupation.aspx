<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopOccupation.aspx.cs" Inherits="Application_Common_PopOccupation" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="txtDate" TagPrefix="uc5" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
   <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
     <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
<%--     <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
        <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />


<link href="../../Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<script type="text/javascript" src="../../Scripts/formatting.js"></script>
<script language="javascript" type="text/javascript">

    function doSelect(args1, args2) 
    {
        window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = doEncodeToParent(args1);
        window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = doEncodeToParent(args2);
        window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').focus();
        window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide(); // Added By Ibrahim on 03-05-2013 for hiding the popup after selecting the vlaue from Grid
        return false;
    }

    function doClear() {
        document.getElementById("<%=txtStateCode.ClientID%>").value = "";
        document.getElementById("<%=txtStateDesc.ClientID%>").value = "";
    }

    function doCancel() {
        window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide(); //Added By Ibrahim on 03-05-2013 for hiding the popup on Click of "Cancal" Button 
    }
</script>
<script type="text/javascript" >
    function ShowReqDtl2(divName, btnName) {
        debugger;

        //alert("1");
        var objnewdiv = document.getElementById(divName);
       

        var objnewbtn = document.getElementById(btnName);
     

        if (objnewdiv.style.display == "block") {
            objnewdiv.style.display = "none";
            objnewbtn.className = 'glyphicon glyphicon-collapse-up';
        }
        else {
            objnewdiv.style.display = "block";
            objnewbtn.className = 'glyphicon glyphicon-collapse-down';
        }
    }
        </script>
<style type="text/css">
     
      .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
        }
        .disablepage
        {
            display: none;
        }
        ul#menu
        {
            padding: 0;
            margin-right: 69%;
        }
        
        ul#menu li
        {
            display: inline;
        }
        
        
        
        ul#menu li a
        {
            background-color: Silver;
            color: black;
            cursor: pointer;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 4px 4px 0 0;
        }
        ul#menu li a:active
        {
            background: white;
        }
        
        ul#menu li a:hover
        {
            background-color: red;
        }
        #GrdStateDtls tr.rowHover:hover
        {
            background-color: #FCF8E3;
        }

    </style>
<head id="Head1" runat="server">
    <title>Occupation</title>
</head>
<body>
    <atlas:ScriptManager ID="scriptMgr" EnablePartialRendering="true" runat="server" />
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="0%" Width="99%" DefaultButton="btnSearch">
       
       
      <%--  <tr>
                        <td align="center" class="test" colspan="2" >
                            <asp:Label ID="lblocchead" runat="server" Text="Occupation Search" Font-Bold="true"></asp:Label>
		</td>
                    </tr>--%>

                     <div class="panel panel-success" id="div1" runat="server">
            <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl2('divpersnldtls','btnprsnldtlscollapse');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                         <asp:Label ID="lblocchead" runat="server" Text="Occupation Search" Font-Bold="true"></asp:Label>
  
                    </div>
                    <div class="col-sm-2">
                        <span id="btnprsnldtlscollapse" runat="server" class="glyphicon glyphicon-collapse-down" style="float: right;
                            color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>


                    <%--Added By Ibrahim on 25=06-2013 for header on popup page End--%>
            <div id="divpersnldtls" runat="server" class="panel-body" style="display: block">
              <div class="row">
              <div class="col-md-3" style="text-align: left">
                    <asp:Label ID="lblStateCode" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox  ID="txtStateCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             </div>
               <div class="row">
                <div class="col-md-3" style="text-align: left">
                    <asp:Label ID="lblStateDesc" runat="server" CssClass="control-label"></asp:Label>
                </div>
               <div class="col-md-3">
                    <asp:TextBox  ID="txtStateDesc" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>
         </div>
            
          
            
            <br />
           
            <div id="Tr4" runat="server" class="col-sm-12" align="center">
                    <asp:LinkButton  ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click">
                     <span class="glyphicon glyphicon-search BtnGlyphicon"></span> Search
                    </asp:LinkButton>
                    <asp:LinkButton  ID="btnClear" runat="server" CssClass="btn btn-primary" Text="Clear" OnClientClick="doClear();return false;">
                        <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                        </asp:LinkButton>
                    <asp:LinkButton  ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClientClick="doCancel();return false;">
                         <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel
                    </asp:LinkButton>
                    </div>

              <br />

                    <atlas:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrMsg" runat="server" CssClass="msgerror2" 
                                Visible="False"></asp:Label>
                            <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" CssClass="footable"
                                AutoGenerateColumns="False" OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound"
                                OnSorting="gv_Sorting" PageSize="12" Width="100%">
                               <RowStyle CssClass="GridViewRow"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Occupation Code" SortExpression="ParamValue">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("ParamValue") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ParamDesc" HeaderText="Occupation Name" SortExpression="ParamDesc" ItemStyle-HorizontalAlign="Left"/>
                                     
                                </Columns>
                            </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <atlas:ControlEventTrigger ControlID="btnSearch" EventName="Click" />
                </Triggers>
            </atlas:UpdatePanel>
            
          
           </div>
           </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

