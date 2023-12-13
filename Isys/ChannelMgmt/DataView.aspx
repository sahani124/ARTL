<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="DataView.aspx.cs" Inherits="Application_ISys_ChannelMgmt_DataView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
 <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

 <script type="text/javascript" src="../../../Scripts/common.js"></script>
 <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
 <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
 <style type="text/css">
  .margin-top
  {
      margin-top:-109px;
  }
  .BtnGlyphicon
{
    color:White !important;
    }
    
    .btn-primary{color:#fff;background-color:#428bca;border-color:#357ebd}
    
    .modal-footer .btn-group .btn+.btn{margin-left:-1px}
</style>
<script language="javascript" type="text/javascript">

    function ShowReqDtl(divName, btnName) {
        //debugger;
        var objnewdiv = document.getElementById(divName);
        var objnewbtn = document.getElementById(btnName);

        if (objnewdiv.style.display == "block") {
            objnewdiv.style.display = "none";
            objnewbtn.className = 'glyphicon glyphicon-collapse-up'
        }
        else {
            objnewdiv.style.display = "block";
            objnewbtn.className = 'glyphicon glyphicon-collapse-down'
        }
    }
</script>
 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<div id="show" runat="server" style="display:none;">
    <asp:Label ID="lblChannel" runat="server" Text="Channel" CssClass="control-label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:DropDownList ID="ddlChannel" runat="server" Width="20%" CssClass="select2-container form-control" AutoPostBack="true"
                OnSelectedIndexChanged="ddlChannel_SelectedIndexChanged">
                  </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSubChannel" runat="server" Text="SubChannel" CssClass="control-label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:DropDownList ID="ddlSubChannel" runat="server" Width="20%" CssClass="select2-container form-control" AutoPostBack="true"
               ><%-- OnSelectedIndexChanged="ddlSubChannel_SelectedIndexChanged"--%>
   
    </asp:DropDownList>
</div>
<br />
<div class="panel panel-success" id="div4" runat="server">
         <div id="Div5" runat="server" class="panel-heading" style="padding:0px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div6','btnAgentdtls');return false;"> 
         <div class="row">
           <div id="divAgentdtls" runat="server" class="panel-body" style="display:block"> 
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                     <asp:Label ID="lblTitle" runat="server"  CssClass="control-label" text="Channel Details"></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnAgentdtls" class="glyphicon glyphicon-collapse-down" style="float: right;color:Orange;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                    </div>
                    </div>
                    </div>

                      <div id="div6" runat="server" class="panel-body" style="display:block"> 
<div runat="server" id="div1" style="display:none;">
<table id="tblIFrame" align="left"  width="20%" height="495" style="margin-top: -15px; border-style:Solid; border-color:gray; border-width:1px"
                        runat="server" >
                        <tr>
                         <td id="cell1" align="left" runat="server">
    <asp:DataList ID="DataList1" runat="server"  style="line-height: 2.1em; margin-top:-96%;width:100%; margin-left:10%;">
                <ItemTemplate>
 
               <asp:LinkButton runat="server" OnClick="lnk2_click" CommandArgument='<%# Eval("BizSrc")%>'>  <%# Eval("ChannelDesc01").ToString().Length > 30 ? (Eval("ChannelDesc01") as string).Substring(0, 9) + " ..." : Eval("ChannelDesc01")%></asp:LinkButton>
 
              <%-- <label>Customer Name :  <%# Eval("customer_name")%></label>
 
               <label>Customer Surname : <%# Eval("customer_surname")%></label>
 
               <label>Customer City : <%# Eval("customer_city") %></label>--%>
 
            </ItemTemplate>
            <ItemStyle Wrap="true"/>
    </asp:DataList>
 </td>
 </tr>
 </table >
 </div>
     
   <div id="div2"  runat="server" style="display:none;">
 <table id="tbList" cellspacing="0" cellpadding="0"  height="500" width="80%"  style="margin-top:-17px;"
                        runat="server">
 <tr>
 <td>
  <asp:ListView ID="productList" runat="server" style="height:80%;" 
                 GroupItemCount="4"  >    <%-- DataKeyNames="ProductID" ItemType="WingtipToys.Models.Product" SelectMethod="GetProducts"   OnItemCommand="productList_ItemEditing"--%>
                <%--        <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>--%>           
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td id="Td1" runat="server">
                        <table>
                            <tr>
                            
                                <td>  
                                    <a href="DataView.aspx">             <%-- ProductDetails.aspx?productID=<%#:Item.ProductID%>--%>
                                        <img src="../../../theme/iflow/Channel.jpg"
                                            width="100" height="75"/></a>
                                </td>
                            </tr>
                            <tr>
                            
                                <td>
                                <span>
                                <asp:LinkButton ID="lnk1" runat="server" OnClick="lnk1_click" CommandArgument='<%# Eval("BizSrc")%>'> <%# Eval("ChannelDesc01").ToString().Length > 20 ? (Eval("ChannelDesc01") as string).Substring(0, 17) + " ..." : Eval("ChannelDesc01")%></asp:LinkButton>
                                </span>
                                    <%-- <a href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                        <span>  <%# Eval("ChannelDesc01")%>
                                            <%#:Item.ProductName%>
                                        </span>--%>
                                    <%--</a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                                    </span>
                                    <br />--%>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;border-style:solid; border-color:gray; border-width:1px; margin-left: 5px;">
                        <tbody>
                            <tr>
                                <td    style=" border-bottom: 1px solid gray; height:494px;">
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%;margin-left:118px;margin-top:-225px;">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
 </td>
 </tr>
 </table>
 </div>
  <div id="div3"  runat="server" style="display:none;" >
   
   <table id="Table1" style="border-style:solid; width:80%;   border-color:gray; border-width:1px; height:495px; margin-left: 240px;margin-top:-15px; " runat="server" >
                        <tr>
                        
                         <td >    
  <asp:FormView ID="FormView1" runat="server"  DefaultMode="ReadOnly"  >
            <EditItemTemplate>
<%--              <img src="../../../theme/iflow/Backb.jpg"
                                            width="50" height="25" onclick="Img1_click"/></a>--%>
                                            <%--  <img src="../../../theme/iflow/Forward.jpg"
                                            width="50" height="25"  onclick="Img2_click" /></a>--%>

             <table style="width:100%; margin-left: 5px;margin-top:-22%;">
                        <tbody> 
                            <tr>
                             <td >  
                                    <a href="DataView.aspx">             <%-- ProductDetails.aspx?productID=<%#:Item.ProductID%>--%>
                                        <img src="../../../theme/iflow/Channel.jpg" 
                                            width="75%" height="125"  style="border:1px solid gray; margin-top:-13%"/></a>

                                            
                                </td>
                             <td style="padding-bottom:71px; padding-top:5px;">
                <asp:Label ID="LblH" runat="server"  CssClass="control-label"  Text="Hierarchy:"></asp:Label>
                <asp:Label ID="Label1" runat="server"  CssClass="control-label"
                    Text='<%# Eval("BizSrc") %>' />
                <br />  
                 <asp:Label ID="LabH2" runat="server"  CssClass="control-label"  Text="Description:"></asp:Label>
                   <asp:Label ID="EmployeeIDLabel1" runat="server"  CssClass="control-label"
                    Text='<%# Eval("ChannelDesc01") %>' />
                
                 <%--<asp:Label ID="LblH3" runat="server"  CssClass="control-label"  Text="SortOrder:"></asp:Label>
                <asp:Label ID="LastNameTextBox" runat="server"  CssClass="control-label"
                    Text='<%# Bind("SortOrder") %>' />--%>
                <br />
                  <asp:Label ID="LblH4" runat="server"  CssClass="control-label"  Text="Period:"></asp:Label>
                <asp:Label ID="FirstNameTextBox" runat="server" CssClass="control-label"
                    Text='<%# Bind("Period") %>' />
                <br />
                 <asp:Label ID="LblH5" runat="server"  CssClass="control-label"  Text="Version:"></asp:Label>
                <asp:Label ID="TitleTextBox" runat="server" Text='<%# Bind("Version") %>'  CssClass="control-label"/>
                </td>
                <td style="padding-left:90px;" >
                <asp:LinkButton  runat="server" ID="lnkPrevious" style="margin-left: 250px; font-size:20px;" ToolTip="Click to view previous"  OnClick="lnkPrevious_Click">
                <span class="glyphicon glyphicon-arrow-left margin-top btn btn-primary BtnGlyphicon"></span>
                </asp:LinkButton>
                </td>
                <td>
                <asp:LinkButton runat="server" ID="lnkNext" style="margin-top: -107px;margin-left: 5px; font-size:20px;" ToolTip="Click to view next" OnClick="lnkNext_Click">
                                <span class="glyphicon glyphicon-arrow-right margin-top btn btn-primary BtnGlyphicon"></span>
                </asp:LinkButton>
                                            </td>
                <td style="padding-right: 7px;">
                 <asp:LinkButton ID="lnkBack"   runat="server" style="margin-top: -107px;margin-left: 5px; font-size:20px;" ToolTip="Click to go back" OnClick="lnkBack_Click">
                <span class="glyphicon glyphicon-arrow-up margin-top btn btn-primary BtnGlyphicon"></span><%----%>
                </asp:LinkButton>
                                            </td>
                </tr>
                </table>

                
               <%-- <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                 <asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />--%>
            </EditItemTemplate>
            </asp:FormView>
            <br />
            
            
                <br />
                 <br />
                 <br />
                 </td>
                 </tr>
                 </table>
         </div>
         </div>
         </div>
         
    
</asp:Content>


