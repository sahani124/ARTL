<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEADTest.aspx.cs" Inherits="SEADTest" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!--> <html lang="en"> <!--<![endif]-->
<head runat="server">
    <title>SEAD Psychometric Examination</title>
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta content="width=device-width, initial-scale=1.0" name="viewport" />
  <meta content="" name="description" />
  <meta content="" name="author"/>
  
  <!-- BEGIN GLOBAL MANDATORY STYLES -->          
   
   <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
   <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
   <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
   <!-- END GLOBAL MANDATORY STYLES -->
   
   <!-- BEGIN PAGE LEVEL PLUGIN STYLES --> 
    <link href="../../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
   <link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css"/>
   <link href="assets/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
   <link href="assets/plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css"/>
   <link href="assets/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css"/>
   <link href="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css"/>
   <link href="assets/plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet" />              
   <link rel="stylesheet" href="assets/plugins/revolution_slider/css/rs-style.css" media="screen"/>
   <link rel="stylesheet" href="assets/plugins/revolution_slider/rs-plugin/css/settings.css" media="screen"/> 
   <link href="assets/plugins/bxslider/jquery.bxslider.css" rel="stylesheet" />                
   <!-- END PAGE LEVEL PLUGIN STYLES-->
   <!-- BEGIN THEME STYLES --> 
   <link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css"/>
   <link href="assets/css/style.css" rel="stylesheet" type="text/css"/>
   <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
   <link href="assets/css/custom.css" rel="stylesheet" type="text/css"/>
   <!-- END THEME STYLES -->
    <style type="text/css">.style1{width: 5%; white-space:nowrap;} .hidetxt{display:none; width:2px;}
                                        h1 {
  
   font-family: VAG Rounded std light;
 }
        p {
            font-family: VAG Rounded std light;
        }
    </style>
    <script src="script/jquery.js" type="text/javascript"></script>
   <!-- BEGIN THEME STYLES --> 
   <!-- END THEME STYLES -->
</head>
<body>
<form action="" method="post" runat="server">
<asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" ID="UpdPnl_Main">
    <ContentTemplate>
   
        <div id="divCount" runat="server" visible="false">
            <div class="col-md-12" style="background-color: #f7f7f7;">
                <h3 class="page-title" style="font-family: VAG Rounded std thin;">
                   <b> <font size="8" color="darkblue">Agenroll</font> <font size="8" color="red">+</font></b>DashBoard <small>statistics and more</small>
                </h3>
                <table class="page-breadcrumb breadcrumb" width="94%" style="background-color: antiquewhite;">
                    <tr>
                        <td style="font-family: VAG Rounded std thin; padding-left: 10px;">
                        <asp:Label ID="Label6" runat="server" CssClass="HeaderInfo" Text="Month Of  " ></asp:Label>
                            <span class="HeaderDetail">
                                <%=System.DateTime.Now.ToString("MMMM")%></span>
                                  <%= DateTime.Now.Year.ToString()  %></span>
                           
                        </td>
                        <td style="width: 240px;">
                        </td>
                        <td style="width: 320px;">
                        </td>
                        <td align="right" style="font-family: VAG Rounded std thin; padding-right: 10px;">
                            <asp:Label ID="lbldate" runat="server" CssClass="HeaderInfo" Text="Date:  " Font-Bold="true"></asp:Label>
                            <span class="HeaderDetail">
                                <%= string.Format("{0:dd/MM/yyyy   hh:mm:ss}",System.DateTime.Now)%></span>
                            &nbsp;&nbsp; <span class="HeaderDetail">
                                <%= DateTime.Now.DayOfWeek.ToString()  %></span>
                        </td>
                    </tr>
                </table>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
            <div id="divimg" class="col-md-12" style="background-color: #f7f7f7;">
                <table width="100%" align="center" class="tableIsys">
                    <tr >
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 25%;">
                                        <div style="height: 100px; width: 213px; background-color: #f3255e;">
                                            <table align="center" style="width: 90%">
                                                <tr style="height: 20%">
                                                    <td rowspan="2" style="width: 20%; color: White;">
                                                        <i class="fa fa-file fa-5x" style="opacity: 0.3;"></i>
                                                    </td>
                                                    <td style="width: 70%; padding-top: 10px;" align="right">
                                                        <asp:Label Font-Size="22px" ForeColor="White" ID="lblRegCnt" runat="server"></asp:Label>
                                                        
                                                        <asp:Label ID="lblcndcount" runat="server" Font-Size="Small" ForeColor="White" Text="(Mobile/Web)"></asp:Label>
                                                    </td>
                                                </tr>
                                                 
                                                <tr>
                                                    <td style="padding-top: 10px;"  align="right">
                                                        <asp:Label ID="lblMobReg" runat="server" Font-Size="Small" ForeColor="White" Text="Total Registered"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="height: 10px; width: 215px; display:none;background-color: #f20d4d; background-repeat: no-repeat;"
                                            onmouseover="this.style.background='#da0c45';" onmouseout="this.style.background='#f20d4d';">
                                            &nbsp;&nbsp;&nbsp;
                                            <%--<asp:LinkButton ID="lbView" ForeColor="White" CssClass="stylink" Font-Size="11px"
                                                runat="server" Text="VIEW MORE"></asp:LinkButton>--%>
                                        </div>
                                    </td>
                                    <td style="width: 25%;">
                                        <div style="height: 100px; width: 217px; background-color: #28b779;">
                                            <table align="center" style="width: 90%">
                                                <tr style="height: 20%">
                                                    <td rowspan="2" style="width: 20%; color: White;">
                                                        <i class="fa fa-users fa-5x" style="opacity: 0.3;"></i>
                                                    </td>
                                                    <td style="width: 80%; padding-top: 10px;" align="right">
                                                        <asp:Label Font-Size="22px" ForeColor="White" ID="lblMobCount" runat="server"></asp:Label>
                                                    
                                                        <asp:Label ID="Label7" runat="server" Font-Size="Small" ForeColor="White" Text="(Mobile/Web)"></asp:Label>
                                                    </td>
                                                </tr>
                                                 
                                                
                                                <tr>
                                                     <td  align="right">
                                                        <asp:Label ID="lblMobFlowDesc" runat="server" Font-Size="Small" ForeColor="White"
                                                            Text="Total Submitted(Registered+Sponsored)"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="height: 10px; width: 215px;display:none; background-color: #17a668; background-repeat: no-repeat;"
                                            onmouseover="this.style.background='#10a062';" onmouseout="this.style.background='#17a668';">
                                            &nbsp;&nbsp;&nbsp;
                                            <%--<asp:LinkButton ID="lbActMemDtls" ForeColor="White" CssClass="stylink" Font-Size="11px"
                                                runat="server" Text="VIEW MORE"></asp:LinkButton>--%>
                                        </div>
                                    </td>
                                    <td style="width: 25%;">
                                        <div style="height:100px; width: 213px; background-color: #852b99;">
                                            <table align="center" style="width: 90%">
                                                <tr style="height: 20%">
                                                    <td rowspan="2" style="width: 20%; color: White;">
                                                        <i class="fa fa-ban fa-5x" style="opacity: 0.3;"></i>
                                                    </td>
                                                    <td style="width: 80%; padding-top: 10px;" align="right">
                                                        <asp:Label Font-Size="22px" ForeColor="White" ID="lblBranchCount" runat="server"></asp:Label>
                                                    
                                                        <asp:Label ID="Label9" runat="server" Font-Size="Small" ForeColor="White" Text="(Mobile/Web)"></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td  align="right">
                                                        <asp:Label ID="lblBranch" runat="server" Font-Size="Small" ForeColor="White" Text="Branch Usage(Logged In)"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="height: 10px; width: 215px;display:none; background-color: #741d88; background-repeat: no-repeat;"
                                            onmouseover="this.style.background='#6e1881';" onmouseout="this.style.background='#741d88';">
                                            &nbsp;&nbsp;&nbsp;
                                           <%-- <asp:LinkButton ID="lbDelMemDtls" ForeColor="White" CssClass="stylink" Font-Size="11px"
                                                runat="server" Text="VIEW MORE"></asp:LinkButton>--%>
                                        </div>
                                    </td>
                                    <td style="width: 25%;">
                                        <div style="height: 100px; width: 213px; background-color: #87CEEB;">
                                            <table align="center" style="width: 90%">
                                                <tr style="height: 20%">
                                                    <td rowspan="2" style="width: 20%; color: White;">
                                                        <i class="fa fa-refresh fa-5x" style="opacity: 0.3;"></i>
                                                    </td>
                                                    <td style="width: 80%; padding-top: 10px;" align="right">
                                                        <asp:Label Font-Size="22px" ForeColor="White" ID="lblUserCount" runat="server"></asp:Label>
                                                   
                                                        <asp:Label ID="Label11" runat="server" Font-Size="Small" ForeColor="White" Text="(Mobile/Web)"></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td  align="right">
                                                        <asp:Label ID="lblUser" runat="server" Font-Size="Small" ForeColor="White" Text="Employees Usage"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="height: 10px; width: 210px;display:none; background-color: #00BFF0; background-repeat: no-repeat;"
                                            onmouseover="this.style.background='#00BFFF';" onmouseout="this.style.background='#00BFF0';">
                                            &nbsp;&nbsp;&nbsp;
                                           <%-- <asp:LinkButton ID="lbPremSmmry" ForeColor="White" CssClass="stylink" Font-Size="11px"
                                                runat="server" Text="VIEW MORE"></asp:LinkButton>--%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                    <br />
                     <table width="94%">
                    <tr id="trCandidate" runat="server">
                        <td style="width:46%">
                            <div class="portletIsys" style="border: 1px solid  #17a668;">
                                <div class="portletIsys-title" style="background-color: #382982;">
                                    <i class="fa fa-User" style="padding-left: 5px; padding-top: 10px; color: White">
                                    </i>&nbsp;
                                    <asp:Label Text="Recruitment Status Summary" Font-Size="Large" runat="server" ID="Label5"
                                        ForeColor="White"></asp:Label>
                                </div>
                                <table style="width: 100%" class="table">
                                    <tr>
                                        <td>
                                           <telerik:RadGrid ID="GridCnt" runat="server" AllowPaging="True" AllowSorting="false" 
                            AllowFilteringByColumn="false" CellSpacing="0" GridLines="None"  PageSize="100" >
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed">
                                <Columns>
                                  
                                    <telerik:GridTemplateColumn HeaderText="Process State" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                                 <asp:Label ID="lblcndreg" runat="server" Text='<%# Eval("modulename") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn HeaderText=" Usages Of Mobile" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                                <asp:Label ID="lblspon" runat="server" Text='<%# Eval("AllCount") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                 <telerik:GridTemplateColumn HeaderText="Usages Of Web" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                                <asp:Label ID="lblWeb" runat="server" Text='<%# Eval("cndwebcount") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                  
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" PageSizes="5,10" PagerTextFormat="{4}<strong>{5}</strong> Items matching your search criteria" 
                                    PageSizeLabelText="Items per page:" />
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                            </ClientSettings>
                        </telerik:RadGrid>
                                         
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                       
                       <td  style="width:7%">
                       </td>
                        <td  style="width:47%">
                            <div class="portletIsys" style="border: 1px solid  #17a668;">
                                <div class="portletIsys-title" style="background-color: #382982;">
                                    <i class="fa fa-User" style="padding-left: 5px; padding-top: 10px; color: White">
                                    </i>&nbsp;
                                    <asp:Label Text="Top 5 Branch Usage Summary" Font-Size="Large" runat="server" ID="Label4"
                                        ForeColor="White"></asp:Label>
                                </div>
                                <table style="width: 100%" class="table">
                                    <tr>
                                        <td>
                                             <telerik:RadGrid ID="GridBranch" runat="server" AllowPaging="True" AllowSorting="false" 
                            AllowFilteringByColumn="false" CellSpacing="0" GridLines="None"  PageSize="100" >
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed">
                                <Columns>
                                  
                                    <telerik:GridTemplateColumn HeaderText="Branch Name" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                               <asp:Label ID="lblBMName" runat="server" Text='<%# Eval("BMName") %>'></asp:Label>
                                                  
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn HeaderText="Total Count" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                                          <asp:Label ID="lblBMCount" runat="server" Text='<%# Eval("BMCount") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                
                                  
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" PageSizes="5,10" PagerTextFormat="{4}<strong>{5}</strong> Items matching your search criteria" 
                                    PageSizeLabelText="Items per page:" />
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                            </ClientSettings>
                        </telerik:RadGrid>
                                         
                                        </td>
                                    </tr>
                                </table>
                            </div>
                           
                        </td>
                    </tr>
          
                    <tr id="trEmp" runat="server" >
                       <td  style="width:47%">
                       <br />
                            <div class="portletIsys" style="border: 1px solid  #17a668;">
                                <div class="portletIsys-title" style="background-color: #382982;">
                                    <i class="fa fa-User" style="padding-left: 5px; padding-top: 10px; color: White">
                                    </i>&nbsp;
                                    <asp:Label Text="Employees Usage Summary" Font-Size="Large" runat="server" ID="Label2"
                                        ForeColor="White"></asp:Label>
                                </div>
                                <table style="width: 100%" class="table">
                                    <tr>
                                        <td>
                                             <telerik:RadGrid ID="GridUser" runat="server" AllowPaging="True" AllowSorting="false" 
                            AllowFilteringByColumn="false" CellSpacing="0" GridLines="None"  PageSize="100" >
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed">
                                <Columns>
                                  
                                    <telerik:GridTemplateColumn HeaderText="Employees Type" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                                <asp:Label ID="lblEMPType" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                                                            
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                     <telerik:GridTemplateColumn HeaderText="Usages of Mobile" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                                          <asp:Label ID="lblempmobCount" runat="server" Text='<%# Eval("mobcount") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                  <telerik:GridTemplateColumn HeaderText="Usages of Web" HeaderStyle-Width="100px" FilterControlWidth="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                                          <asp:Label ID="lblEmpWebCount" runat="server" Text='<%# Eval("Webcount") %>'></asp:Label>
                                            </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                     </telerik:GridTemplateColumn>
                                  
                                </Columns>
                                <PagerStyle HorizontalAlign="Center" PageSizes="5,10" PagerTextFormat="{4}<strong>{5}</strong> Items matching your search criteria" 
                                    PageSizeLabelText="Items per page:" />
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                            </ClientSettings>
                        </telerik:RadGrid>
                                  
                                        </td>
                                    </tr>
                                </table>
                                
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    <div id="divSead" runat="server" >
     <table   border="0" cellpadding="1" cellspacing="0" width="60%" align="center" class="table">
    
            <tr style="width: 60%;" valign="middle" class="portlet-title">
                <td align="left" colspan="2">
                    <asp:TextBox runat="server" ID="txttemp" CssClass="hidetxt"/>
                    <h1>
                        SEAD Psychometric Profiling for sales managers</h1>
                    <div style="float: left; width: 100%; white-space: nowrap;" align="left">
                        <blockquote>
                            <p>
                                Hi <asp:Label ID="lblName" Font-Names="VAG Rounded std thin" runat="server" />!<br />
                                Help us to know you better by answering a few questions below...
                                <br />
                            </p>
                        </blockquote>
                    </div>
                    <span style="padding-left: 40px;"></span>
                    <asp:Image ImageUrl="~/assets/icon-bulb.png" runat="server" Height="16px" Width="15px" />
                    <span style="padding-left: 10px;"></span>
                    <asp:Image ImageUrl="~/assets/icon-questionmark.png" runat="server" Height="16px"
                        Width="16px" />
                        <span style="padding-left: 85%;"></span>
                <a href="#" class="caption" id="lnkHelp" onmouseover="javascript:showPopup();return false;">
                            Help</a>
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label Text="1.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                            <asp:Button ID="btn1a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                                OnClientClick="javascript:changeTitleText('btn1a');return false;" CssClass="btn btn-xs blue"
                                Width="30%" Text="-" />
                <td>
                    <asp:Label ID="lbl1a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label1" Text="1.B" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn1b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn1b');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl1b" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label3" Text="2.A" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn2a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn2a'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" data-original-title="This is it." data-placement="right" />
                </td>
                <td>
                    <asp:Label ID="lbl2a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label8" Text="2.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn2b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn2b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl2b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label10" Text="3.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn3a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn3a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl3a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label12" Text="3.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn3b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn3b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl3b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label14" Text="4.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn4a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn4a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl4a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label16" Text="4.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn4b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn4b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl4b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label18" Text="5.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn5a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn5a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl5a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label20" Text="5.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn5b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn5b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl5b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label22" Text="6.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn6a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn6a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl6a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label24" Text="6.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn6b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn6b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl6b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label26" Text="7.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn7a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn7a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl7a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label28" Text="7.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn7b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn7b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl7b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label30" Text="8.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn8a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn8a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl8a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label32" Text="8.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn8b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn8b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl8b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label34" Text="9.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn9a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn9a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl9a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label36" Text="9.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn9b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn9b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl9b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label38" Text="10.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn10a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn10a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl10a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label40" Text="10.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn10b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn10b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl10b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label42" Text="11.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn11a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn11a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl11a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label44" Text="11.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn11b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn11b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl11b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label46" Text="12.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn12a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn12a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl12a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label48" Text="12.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn12b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn12b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl12b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label50" Text="13.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn13a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn13a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl13a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label52" Text="13.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn13b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn13b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl13b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label54" Text="14.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn14a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn14a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl14a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label56" Text="14.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn14b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn14b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl14b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label58" Text="15.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn15a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn15a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl15a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label60" Text="15.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn15b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn15b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl15b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label62" Text="16.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn16a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn16a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl16a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label64" Text="16.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn16b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn16b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl16b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label66" Text="17.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn17a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn17a');return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl17a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label68" Text="17.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn17b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn17b'); return false;" CssClass="btn btn-xs blue" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl17b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label70" Text="18.A" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin"
                        Font-Size="14.5px" Width="30px" />
                    <asp:Button ID="btn18a" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn18a');return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl18a" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td class="style1">
                    <asp:Label ID="Label72" Text="18.B" runat="server" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        Width="30px" />
                    <asp:Button ID="btn18b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px"
                        OnClientClick="javascript:changeTitleText('btn18b'); return false;" CssClass="btn btn-xs green" Width="30%"
                         Text="-" />
                </td>
                <td>
                    <asp:Label ID="lbl18b" runat="server" ForeColor="Black" Font-Names="VAG Rounded std thin" Font-Size="14.5px" />
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td colspan="2">
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td align="center" colspan="2" style="white-space: nowrap;">
                    <asp:UpdatePanel runat="server" ID="UpdPnl_Submit" UpdateMode="Conditional">
                        <ContentTemplate>
                           <%-- <div class="btn btn-primary btn-xs" style="white-space:nowrap; width:110px;">
                                <i class="fa fa-check"></i>--%>
                               <%-- <asp:Button Text="Submit" runat="server" CssClass="btn btn-sample"    style="border-radius: 15px!important;" ID=""
                                    OnClick="btnSubmit_Click" Width="85px"/>--%>
                          <%--  </div>--%>
                          

                             <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-sample" style="border-radius: 15px!important;" AutoPostback="false"
                                    OnClick="btnSubmit_Click" TabIndex="15">
                                 <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon" style='color:White;'></span> Search
                                </asp:LinkButton> 
                              <span style="padding-left: 3px;"></span>
                           <%-- <div class="btn btn-primary btn-xs" style="white-space:nowrap; width:110px;">
                                <i class="fa fa-times"></i>--%>
                               <%-- <asp:Button Text="Cancel" runat="server" style="border-radius: 15px!important;" CssClass="btn btn-sample" 
                                    ID="" onclick="btnCancel_Click" Width="90px"/>--%>

                               <asp:LinkButton ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-sample" style="border-radius: 15px!important;" CausesValidation="False"
                                OnClick="btnCancel_Click" TabIndex="359">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Cancel
                             </asp:LinkButton> 
                          <%--  </div>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="width: 60%;" valign="middle">
                <td colspan="2">
                </td>
            </tr>
        </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
    <script type="text/javascript">
        var var1 = "-1";
        var parentID = "ctl00_ContentPlaceholder1_";

        function changeTitleText(args1) {
            var adjacentbuttonID = args1.substring(0, args1.length - 1);

            var css_Low = { "background-color": "Red" };
            var css_High = { "background-color": "#48FF00" };
            
            var1 = $("#" + args1).val();

            if (args1.slice(-1) == "a") {adjacentbuttonID = adjacentbuttonID + "b";}
            else {adjacentbuttonID = adjacentbuttonID + "a";}
            
            var currentButton = "#" + args1;
            var adjacentButton = "#" + adjacentbuttonID;
            var jscurrentId = args1;
            var jsadjacentId = adjacentbuttonID;


            adjacentbuttonID = document.getElementById(adjacentbuttonID);
            
            var initialbuttonID = document.getElementById(args1);
            
            if (var1 == "-") {
                initialbuttonID.value = "0"; adjacentbuttonID.value = "3";
                $(currentButton).css(css_Low); $(adjacentButton).css(css_High);
                document.getElementById('hdn' + jsadjacentId).value = "3";
                document.getElementById('hdn' + jscurrentId).value = "0";
            }
            else {
                var1++;
                switch (var1) {
                    case 0:
                    initialbuttonID.value = "0"; $(currentButton).css(css_Low);
                    adjacentbuttonID.value = "3"; $(adjacentButton).css(css_High);
                    document.getElementById('hdn' + jsadjacentId).value = "3";
                    document.getElementById('hdn'+jscurrentId).value = "0";
                    break;
                    case 1:
                    initialbuttonID.value = "1"; $(currentButton).css(css_Low);
                    adjacentbuttonID.value = "2"; $(adjacentButton).css(css_High);
                    document.getElementById('hdn' + jsadjacentId).value = "2";
                    document.getElementById('hdn' + jscurrentId).value = "1";
                    break;
                case 2:
                    initialbuttonID.value = "2"; $(currentButton).css(css_High);
                    adjacentbuttonID.value = "1"; $(adjacentButton).css(css_Low);
                    document.getElementById('hdn' + jsadjacentId).value = "1";
                    document.getElementById('hdn' + jscurrentId).value = "2";
                    break;
                case 3:
                    initialbuttonID.value = "3"; $(currentButton).css(css_High);
                    adjacentbuttonID.value = "0"; $(adjacentButton).css(css_Low);
                    document.getElementById('hdn' + jsadjacentId).value = "0";
                    document.getElementById('hdn' + jscurrentId).value = "3";
                    break;
                default:
                    initialbuttonID.value = "0"; $(currentButton).css(css_Low);
                    adjacentbuttonID.value = "3"; $(adjacentButton).css(css_High);
                    document.getElementById('hdn' + jsadjacentId).value = "3";
                    document.getElementById('hdn' + jscurrentId).value = "0";
                    break;
                }
            }
        }
    </script>
    <input type="hidden" id="hdnbtn1a" runat="server"/>
    <input type="hidden" id="hdnbtn1b" runat="server"/>
    <input type="hidden" id="hdnbtn2a" runat="server"/>
    <input type="hidden" id="hdnbtn2b" runat="server"/>
    <input type="hidden" id="hdnbtn3a" runat="server"/>
    <input type="hidden" id="hdnbtn3b" runat="server"/>
    <input type="hidden" id="hdnbtn4a" runat="server"/>
    <input type="hidden" id="hdnbtn4b" runat="server"/>
    <input type="hidden" id="hdnbtn5a" runat="server"/>
    <input type="hidden" id="hdnbtn5b" runat="server"/>
    <input type="hidden" id="hdnbtn6a" runat="server"/>
    <input type="hidden" id="hdnbtn6b" runat="server"/>
    <input type="hidden" id="hdnbtn7a" runat="server"/>
    <input type="hidden" id="hdnbtn7b" runat="server"/>
    <input type="hidden" id="hdnbtn8a" runat="server"/>
    <input type="hidden" id="hdnbtn8b" runat="server"/>
    <input type="hidden" id="hdnbtn9a" runat="server"/>
    <input type="hidden" id="hdnbtn9b" runat="server"/>
    <input type="hidden" id="hdnbtn10a" runat="server"/>
    <input type="hidden" id="hdnbtn10b" runat="server"/>
    <input type="hidden" id="hdnbtn11a" runat="server"/>
    <input type="hidden" id="hdnbtn11b" runat="server"/>
    <input type="hidden" id="hdnbtn12a" runat="server"/>
    <input type="hidden" id="hdnbtn12b" runat="server"/>
    <input type="hidden" id="hdnbtn13a" runat="server"/>
    <input type="hidden" id="hdnbtn13b" runat="server"/>
    <input type="hidden" id="hdnbtn14a" runat="server"/>
    <input type="hidden" id="hdnbtn14b" runat="server"/>
    <input type="hidden" id="hdnbtn15a" runat="server"/>
    <input type="hidden" id="hdnbtn15b" runat="server"/>
    <input type="hidden" id="hdnbtn16a" runat="server"/>
    <input type="hidden" id="hdnbtn16b" runat="server"/>
    <input type="hidden" id="hdnbtn17a" runat="server"/>
    <input type="hidden" id="hdnbtn17b" runat="server"/>
    <input type="hidden" id="hdnbtn18a" runat="server"/>
    <input type="hidden" id="hdnbtn18b" runat="server"/>
    <input type="hidden" id="hdndisplay" runat="server"/>
    </form>
<!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
<!-- BEGIN CORE PLUGINS -->   
<!--[if lt IE 9]>
<script src="assets/plugins/respond.min.js"></script>
<script src="assets/plugins/excanvas.min.js"></script> 
<![endif]-->
<script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
<!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
<script src="assets/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>  
<script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript" ></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS-->
<script src="assets/plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>   
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
<script src="assets/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript"></script>  
<script src="assets/plugins/flot/jquery.flot.js" type="text/javascript"></script>
<script src="assets/plugins/flot/jquery.flot.resize.js" type="text/javascript"></script>
<script src="assets/plugins/jquery.pulsate.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap-daterangepicker/moment.min.js" type="text/javascript"></script>
<script src="assets/plugins/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>     
<script src="assets/plugins/gritter/js/jquery.gritter.js" type="text/javascript"></script>
<!-- IMPORTANT! fullcalendar depends on jquery-ui-1.10.3.custom.min.js for drag & drop support -->
<script src="assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
<script src="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.js" type="text/javascript"></script>
<script src="assets/plugins/jquery.sparkline.min.js" type="text/javascript"></script>  
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="assets/scripts/app.js" type="text/javascript"></script>
<script src="assets/scripts/index.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->  
<script type="text/javascript">
    jQuery(document).ready(function () {
        App.init(); // initlayout and core plugins
    });
</script>
<!-- END JAVASCRIPTS -->
<!-- Load javascripts at bottom, this will reduce page load time -->
    <!-- BEGIN CORE PLUGINS(REQUIRED FOR ALL PAGES) -->
    <!--[if lt IE 9]>
    <script src="assets/plugins/respond.min.js"></script>  
    <script src="assets/plugins/excanvas.min.js"></script> 
    <![endif]-->  
    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>      
    <script type="text/javascript" src="assets/plugins/back-to-top.js"></script>    
    <!-- END CORE PLUGINS -->

    <!-- BEGIN PAGE LEVEL JAVASCRIPTS(REQUIRED ONLY FOR CURRENT PAGE) -->
    <script type="text/javascript" src="assets/plugins/fancybox/source/jquery.fancybox.pack.js"></script>  
    <script type="text/javascript" src="assets/plugins/revolution_slider/rs-plugin/js/jquery.themepunch.plugins.min.js"></script>
    <script type="text/javascript" src="assets/plugins/revolution_slider/rs-plugin/js/jquery.themepunch.revolution.min.js"></script> 
    <script type="text/javascript" src="assets/plugins/bxslider/jquery.bxslider.min.js"></script>
    <script src="assets/scripts/app.js" type="text/javascript"></script>
    <script src="assets/scripts/index.js" type="text/javascript"></script>    
    <script src="assets/scripts/core/app.js" type="text/javascript"></script>
    <script src="assets/scripts/custom/ui-alert-dialog-api.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootbox/bootbox.min.js" type="text/javascript"></script>
    
    
    <script type="text/javascript">
        function showPopup() 
        {
            var some_html = '<div style="font-size:10.0pt;font-family:Calibri,sans-serif;color:black;"><p>The maximum score for each pair of questions is 3,total for question A and question B is 3, for example</p><ul><li>If A is very characteristic of you and B is very uncharacteristic, write ‘3’ next to A and ‘0’ next to B. </li><li>If B is very characteristic of you and A is very uncharacteristic, write ‘3’ next to B and ‘0’ next to A. </li><li>If A is somewhat characteristic of you and B is less characteristic, write ‘2’ next to A and ‘1’ next to B. </li><li>If B is somewhat characteristic of you and A is less characteristic, write ‘2’ next to B and ‘1’ next to A </li></ul></div>';
            bootbox.alert(some_html);
        }

        jQuery(document).ready(function () {
            App.init();
            UIAlertDialogApi.init();
        });
    </script>
    <!-- END PAGE LEVEL JAVASCRIPTS -->
</body>
</html>