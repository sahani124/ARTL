<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ARTLDashBoard.aspx.cs" Inherits="Application_Common_ARTLDashBoard" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Charting" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE6" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="expires" content="-1" />

    <link href="../../assets/plugins/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link  rel="Stylesheet" href="Styles/style_Isys.css"/>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css"> 
    .sublinkeven
    {
        padding-top:5px;
    }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM1" runat="server">
    </asp:ScriptManager>
    <div >
        <div class="col-md-12"  style="background-color:#f7f7f7;" >
            <h3 class="page-title">
                Dashboard <small>statistics and more</small>
            </h3>
            <table class="page-breadcrumb breadcrumb" width="94%" style="background-color:antiquewhite;">
                <tr>
                    <td style="width: 110px; height: 30px;">
                        
                    </td>
                    <td style="width: 240px;">
                        
                    </td>
                    <td style="width: 320px;">
                    </td>
                    <td align="right" style="font-family: Arial; padding-right: 10px;">
                        <asp:Label ID="lbldate" runat="server" CssClass="HeaderInfo" Text="Date:   " Font-Bold="true"></asp:Label>
                        <span class="HeaderDetail">
                            <%= string.Format("{0:dd/MM/yyyy   hh:mm:ss}",System.DateTime.Now)%></span>
                        &nbsp;&nbsp; <span class="HeaderDetail">
                            <%= DateTime.Now.DayOfWeek.ToString()  %></span>
                    </td>
                </tr>
            </table>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
        <div id="divimg" class="col-md-12"  style="background-color:#f7f7f7;">
            <table width="100%" align="center" class="formtable table">
                <tr>
                    <td colspan="3">
                        <table width="100%">
                            <tr>
                                <td style="width: 25%;">
                                   
                                    <div  style="height: 80px; width: 200px; background-color:#f3255e;">
                                        <table align="center" style="width:90%">
                                        <tr style="height:20%">
                                        <td rowspan="2" style="width:20% ; color:White;"> 
                                        <i class="fa fa-male fa-5x"  style="opacity:0.3;"></i>
                                        </td>
                                        <td style="width:70%" align="right"><asp:Label Font-Size="35px"   ForeColor="White" ID="lblCndCnt" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td  align="right"><asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="White" Text="Candidate Count"></asp:Label></td>
                                        </tr>
                                        </table>
                                    </div>
                                    <div  style="height: 24px; width: 200px; background-color:#f20d4d;  background-repeat: no-repeat;"
                                     onmouseover="this.style.background='#da0c45';" onmouseout="this.style.background='#f20d4d';">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton  ID="lbView" ForeColor="White" CssClass="stylink"    Font-Size="11px" runat="server" Text="VIEW MORE"></asp:LinkButton>
                                    </div>
                                </td>
                                <td style="width: 25%;">
                                    <div style="height: 80px; width: 200px; background-color:#28b779;">
                                         <table align="center" style="width:90%">
                                        <tr style="height:20%">
                                        <td rowspan="2" style="width:20%; color:White;"> <i class="fa fa-users fa-5x" style="opacity:0.3;"></i></td>
                                        <td style="width:80%" align="right"><asp:Label Font-Size="35px" ForeColor="White" ID="lblAgntCnt" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td  align="right"><asp:Label ID="lbl2" runat="server" Font-Size="Medium" ForeColor="White" Text="Agent Count"></asp:Label></td>
                                        </tr>
                                        </table>
                                    </div>
                                     <div  style="height: 24px; width: 200px; background-color:#17a668;  background-repeat: no-repeat;"
                                     onmouseover="this.style.background='#10a062';" onmouseout="this.style.background='#17a668';">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton  ID="LinkButton1" ForeColor="White" CssClass="stylink"    Font-Size="11px" runat="server" Text="VIEW MORE"></asp:LinkButton>
                                    </div>
                                </td>
                                <td style="width: 25%;">
                                    <div style="height: 80px; width: 200px; background-color:#852b99;">
                                        <table align="center" style="width:90%">
                                        <tr style="height:20%">
                                        <td rowspan="2" style="width:20%; color:White;"> <i class="fa fa-repeat fa-5x"  style="opacity:0.3;"></i></td>
                                        <td style="width:80%" align="right"><asp:Label Font-Size="35px" ForeColor="White" ID="lblRenwlsCnt" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td  align="right"><asp:Label ID="Label3" runat="server" Font-Size="Medium" ForeColor="White" Text="Renewal Count"></asp:Label></td>
                                        </tr>
                                        </table>
                                    </div>
                                     <div  style="height: 24px; width: 200px; background-color:#741d88;  background-repeat: no-repeat;"
                                     onmouseover="this.style.background='#6e1881';" onmouseout="this.style.background='#741d88';">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton  ID="LinkButton2" ForeColor="White" CssClass="stylink"    Font-Size="11px" runat="server" Text="VIEW MORE"></asp:LinkButton>
                                    </div>
                                </td>
                                <td style="width: 25%;">
                                    <div style="height: 80px; width: 200px; background-color:#ffb848;">
                                       <table align="center" style="width:90%">
                                        <tr style="height:20%">
                                        <td rowspan="2" style="width:20%; color:White;"> <i class="fa fa-refresh fa-5x"  style="opacity:0.3;"></i></td>
                                        <td style="width:80%" align="right"><asp:Label Font-Size="35px" ForeColor="White" ID="lblRpterCnt" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td  align="right"><asp:Label ID="Label4" runat="server" Font-Size="Medium" ForeColor="White" Text="Repeater Count"></asp:Label></td>
                                        </tr>
                                        </table>
                                    </div>
                                     <div  style="height: 24px; width: 200px; background-color:#da9627;  background-repeat: no-repeat;"
                                     onmouseover="this.style.background='#cb871b';" onmouseout="this.style.background='#da9627';">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton  ID="LinkButton3" ForeColor="White" CssClass="stylink"    Font-Size="11px" runat="server" Text="VIEW MORE"></asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
                <tr>
                
               <td>
               
               <div class="portletIsys"  style="  border:1px solid  #60051e;">
                              <div class="portletIsys-title" style="background-color:#60051e;" >
                              
                                  <i class="fa fa-male" style="padding-left:5px;padding-top:10px;color:White"></i>&nbsp;
                                   <asp:Label Text="Status wise summary current FY" Font-Size="Large" runat="server" ID="lbl1"  ForeColor="White"></asp:Label>  
                               
                               
                            </div>
                   <asp:Chart ID="ChartLicAgentsTillDate" BackColor="Transparent" AntiAliasing="Graphics" 
                                  runat="server" Width="270px" 
                       Height="190px" Palette="SemiTransparent">
                       <Series>
                           <asp:Series Name="Series1" Font="verdana">
                           </asp:Series>
                       </Series>
                       <ChartAreas>
                           <asp:ChartArea Name="ChartArea1">
                           </asp:ChartArea>
                       </ChartAreas>
                   </asp:Chart>
               
               </div>
               </td>
               
               <td>
                 <div class="portletIsys"  style="  border:1px solid #0095b6;">
                              <div class="portletIsys-title" style="background-color : #0095b6;" >
                              
                                    <i class="fa fa-tachometer" style="padding-left:5px;padding-top:10px;color:White"></i>&nbsp;
                                   <asp:Label Text="Month on month agent licensed" Font-Size="Large" runat="server" ID="Label2"  ForeColor="White"></asp:Label>  
                               
                               
                            </div>
                   <asp:Chart ID="ChartLicAgentCurrent" BackColor="Transparent" AntiAliasing="Graphics" 
                                  runat="server" Width="270px" 
                       Height="190px" Palette="SemiTransparent" >
                       <Series>
                           <asp:Series Name="Series1" >
                           </asp:Series>
                       </Series>
                       <ChartAreas>
                           <asp:ChartArea Name="ChartArea1">
                           </asp:ChartArea>
                       </ChartAreas>
                   </asp:Chart>
               </div>
               </td>

               <td>
                  <div class="portletIsys"  style=" border:1px solid  #2dcc70;">
                              <div class="portletIsys-title" style="background-color : #2dcc70;" >
                              
                                    <i class="fa fa-refresh fa-1x" style="padding-left:5px;padding-top:10px;color:White"></i>&nbsp;
                                   <asp:Label Text=" Conversion report current FY" Font-Size="Large" runat="server" ID="Label5"  ForeColor="White"></asp:Label>  
                               
                               
                            </div>
                <table align="center" style="height:100%;width:100%;">
                <tr>
                <td style="vertical-align:top; padding-top:5px;">
                <asp:GridView   ID="gv_CndCountRatio" Width="100%" Height="100%" runat="server" CssClass="portletIsys" AutoGenerateColumns="false">

                <Columns>
                <asp:TemplateField HeaderText="Branch" HeaderStyle-Width="80px">
                <ItemTemplate>
                <asp:Label ID="lbl1" runat="server" Text='<%# Bind("Branch") %>' ></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Reg." HeaderStyle-Width="40px">
                <ItemTemplate>
                <asp:Label ID="lbl2" runat="server" Text='<%# Bind("Candidate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle  HorizontalAlign="Right" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Licensed" HeaderStyle-Width="40px">
                <ItemTemplate>
                <asp:Label ID="lbl3" runat="server" Text='<%# Bind("Conversion") %>'></asp:Label>
                </ItemTemplate>
                 <ItemStyle  HorizontalAlign="Right" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Ratio" HeaderStyle-Width="40px">
                <ItemTemplate>
                <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Ratio") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle  HorizontalAlign="Right" />
                </asp:TemplateField>
                </Columns>

                <RowStyle CssClass="sublinkodd" Font-Size="9" Font-Names="Open Sans,sans-serif" ></RowStyle>
                <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center"  Font-Underline="True">
                </PagerStyle>
                <HeaderStyle CssClass="portlet blue" ForeColor="White" BackColor="#4b8df8" HorizontalAlign="Center" Font-Bold="true"></HeaderStyle>
                <AlternatingRowStyle CssClass="sublinkeven" Font-Size="9" Font-Names="Open Sans,sans-serif"></AlternatingRowStyle>
                </asp:GridView>
               
                </td>
                </tr>
                </table>
                </div>
                </td>
               </tr>

                <tr>
              
                
               <td>
               
                 <div class="portletIsys"  style="  border:1px solid  #336600;">
                              <div class="portletIsys-title" style="background-color : #336600;" >
                              
                                    <i class="fa fa-list" style="padding-left:5px;padding-top:10px;color:White"></i>&nbsp;
                                   <asp:Label Text="Candidate Count (Monthly)" Font-Size="Large" runat="server" ID="Label6"  ForeColor="White"></asp:Label>  
                               
                               
                            </div>
                   <asp:Chart ID="ChartCndCountMonthly" BackColor="Transparent" AntiAliasing="Graphics" runat="server" Width="270" Height="190" 
                       Palette="SemiTransparent">
                       <Series>
                           <asp:Series ChartType="Line" Name="Series1" Color="Green" >
                           </asp:Series>
                       </Series>
                       <ChartAreas>
                           <asp:ChartArea Name="ChartArea1">
                           </asp:ChartArea>
                       </ChartAreas>
                   </asp:Chart>
               
               </div>
               </td>
               <td>
                 <div class="portletIsys"  style="  border:1px solid  #e43287;">
                              <div class="portletIsys-title"  style="background-color : #e43287;">
                              
                                    <i class="fa fa-flash" style="padding-left:5px;padding-top:10px;color:White"></i>&nbsp;
                                   <asp:Label Text="Pending Renewals Count" Font-Size="Large" runat="server" ID="Label7"  ForeColor="White"></asp:Label>  
                               
                               
                            </div>
               
                   <asp:Chart ID="ChartPendingRenewal" BackColor="Transparent" AntiAliasing="Graphics" 
                                  runat="server" Width="270px" Height="190px" 
                       Palette="SemiTransparent">
                       <Series>
                           <asp:Series Name="Series1">
                           </asp:Series>
                       </Series>
                       <ChartAreas>
                           <asp:ChartArea Name="ChartArea1">
                           </asp:ChartArea>
                       </ChartAreas>
                   </asp:Chart>
               </div>
               
               </td>
               <td>
                 <div class="portletIsys"  style="  border:1px solid  #ce64cc;">
                              <div class="portletIsys-title" style="background-color : #ce64cc;" >
                              
                                    <i class="fa fa-magic" style="padding-left:5px;padding-top:10px;color:White"></i>&nbsp;
                                   <asp:Label Text="Missed Renewals Count" Font-Size="Large" runat="server" ID="Label8"  ForeColor="White"></asp:Label>  
                               
                               
                            </div>
                   <asp:Chart ID="ChartMissedRenewal" BackColor="Transparent" AntiAliasing="Graphics" 
                                  runat="server" Width="270px" Height="190px" 
                       Palette="SemiTransparent" >
                       <Series>
                           <asp:Series Name="Series1" Color="AliceBlue" >
                           </asp:Series>
                       </Series>
                       <ChartAreas>
                           <asp:ChartArea Name="ChartArea1">
                           </asp:ChartArea>
                       </ChartAreas>
                   </asp:Chart>
               </div>
               </td>
               </tr>

                

                
            </table>
        </div>
    </div>
    </form>
</body>
</html>
