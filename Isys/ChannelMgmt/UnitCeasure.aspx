<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="UnitCeasure.aspx.cs" Inherits="Application_ISys_ChannelMgmt_UnitCeasure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

      <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
   <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
 <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
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
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    

   

<%--     <style type="text/css">
     
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
    </style>--%>



    <script language="javascript" type="text/javascript">
     var path = "<%=Request.ApplicationPath.ToString()%>";


     function ShowReqDtl1(divName, btnName) {
         //debugger;
         try {
             var objnewdiv = document.getElementById(divName)
             var objnewbtn = document.getElementById(btnName);
             if (objnewdiv.style.display == "block") {
                 objnewdiv.style.display = "none";
                 //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
             }
             else {
                 objnewdiv.style.display = "block";
                 //objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
             }
         }
         catch (err) {
             ShowError(err.description);
         }
     }

     function ShowReqDtl(divId, btnId, img) {
         var strContent = "ctl00_ContentPlaceHolder1_";

         if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
             $(document.getElementById(strContent + divId)).slideUp();
             $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
         }
         else {
             $(document.getElementById(strContent + divId)).slideDown();
             $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
         }
     }

     function funUntDetailsPopup(args1) {
         $find("mdl_UntDetails").show();
         document.getElementById("ctl00_ContentPlaceHolder1_ifrm_UntDetails").src = args1;
     }
        


  </script>
    
    <center>
        <asp:UpdatePanel ID="up_UnitM" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>


                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        
                       <%-- <div id="div1" runat="server" class="divBorder1" style="width: 98%;">
                            <table class="formtablehdr" style="width: 100%;">
                                <tr style="height: 30px;">
                                    <td style="padding-left: 5px;">
                                        <i class="fa fa-list"></i>
                                      
                                        &nbsp;<asp:Label ID="lblUnitCeasure" runat="server" Font-Bold="true" Style="padding-left: 5px;"></asp:Label>
                                    </td>
                                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                        <img id="Img1" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','Img1','#Img1');" />
                                    </td>
                                </tr>
                            </table>--%>
                            <div class="container">   
                              <div class="panel ">
                <div id="div1" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                 <asp:Label ID="lblUnitCeasure" runat="server" style="font-size:19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>




                            <div id="divcmphdr" style="display:block;" runat="server" class="panel-body">
                                
                                                
                        <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="lblSalesChannel" CssClass="control-label" runat="server"></asp:Label>&nbsp;
                                                        <span style="color: Red; margin-left: -5px;">*</span>
                                                    </div>
                                                        
                        <div class="col-sm-3">
                                                        <asp:UpdatePanel runat="server" ID="upnlSalesChannel">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="form-control"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvSlsChnnl" runat="server" ControlToValidate="ddlSalesChannel"
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        </div>
                                                      
                        <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="lblChnnlSubClass" CssClass="control-label" runat="server"></asp:Label>&nbsp;
                                                        <span style="color: Red; margin-left: -5px;">*</span>
                                                        </div>

                                                      
                        <div class="col-sm-3">
                                                        <asp:UpdatePanel runat="server" ID="upnlChnnlSubClass">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlChnnlSubClass" runat="server" CssClass="form-control"
                                                                    OnSelectedIndexChanged="ddlChnnlSubClass_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvChnnlSubClass" runat="server" ControlToValidate="ddlChnnlSubClass"
                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                                                </asp:AsyncPostBackTrigger>
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                   </div>
                                                   <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="lblUnitLevel" CssClass="control-label" runat="server"></asp:Label>
                                                        <span style="color: Red; margin-left: -5px;">*</span>
                                                        </div>
                                                  <div class="col-sm-3">
                                                        <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlUnitLevel" runat="server"  CssClass="form-control"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlUnitLevel_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged">
                                                                </asp:AsyncPostBackTrigger>
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                        </div>
                                                    
                                                     <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="lblUnitCode" CssClass="control-label" runat="server"></asp:Label>
                                                        </div>
                                                   
                                                <div class="col-sm-3">
                                                        <asp:TextBox ID="txtUnitCode" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                  
                            </div>
                        </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                                 
              <br />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <%--<div id="div2" runat="server" class="divBorder1" style="width: 98%;">
                            <table class="formtablehdr" style="width: 100%;">
                                <tr style="height: 30px;">
                                    <td style="padding-left: 5px;">
                                        <i class="fa fa-list"></i>
                                        
                                        &nbsp;<asp:Label ID="lblReportingUnit" runat="server" Font-Bold="true" Style="padding-left: 5px;"></asp:Label>
                                    </td>
                                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                        <img id="Img2" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('div3','Img2','#Img2');" />
                                    </td>
                                </tr>
                            </table>--%>
                          <div class="container">   
                             <div class="panel ">
                <div id="div2" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div3','Span1');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                  <asp:Label ID="lblReportingUnit" runat="server" style="font-size:19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                    
                        <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>

                                
                            <div id="div3" style="display:block;" runat="server" class="panel-body">
                              
                                   <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblReportingUnitType" runat="server" CssClass="control-label"></asp:Label>
                                            <span style="color: Red; margin-left: -5px;">*</span>
                                     </div>
                                     
                                      <div class="col-sm-3">  
                                            <asp:UpdatePanel ID="upnlReprtngUnt" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlReportingUnitType" runat="server" AutoPostBack="True" CssClass="form-control"
                                                        OnSelectedIndexChanged="ddlReportingUnitType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <ajax:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            </div>
                                      <div class="col-sm-3" style="text-align:left">
                                            <asp:Label ID="lblReportingUnitCode" runat="server" CssClass="control-label"></asp:Label>
                                       </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtReportingUnitCode" runat="server" CssClass="form-control"
                                                MaxLength="10"></asp:TextBox>
                                                </div>
                                       
                            </div>
                                                                    
                        </div>
                              </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                
                
                <div ID="div9" runat="server" style="width: 98%;">
                    
                              <%--  <asp:Button ID="btnSearch" runat="server" CausesValidation="True" 
                                    CssClass="btn blue" OnClick="btnSearch_Click" 
                                    OnClientClick="javascript:validate();" TabIndex="43" Text="SEARCH" 
                                    Width="100px" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnClear" runat="server" CausesValidation="False" 
                                    CssClass="btn default" OnClick="btnClear_Click" TabIndex="43" Text="CLEAR" 
                                    Width="100px" />--%>

                                     <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" AutoPostback="false" CausesValidation="false"  Text="SEARCH" 
                                    OnClick="btnSearch_Click">
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> Search
                                </asp:LinkButton> 
                                <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-sample" CausesValidation="False" 
                                    runat="server">
                             <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear 
                             </asp:LinkButton>
                           
                </div>
                <br />
                
                
                   <%--<div id="divcmphdrcollapse" runat="server" style="width: 98%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr ID="trDetails" runat="server" style="height: 30px;">
                    <td   style="padding-left: 5px;" runat="server">
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblTitleUnitCeasure" Text="Cease Unit Search Result"  runat="server" Style="padding-left: 5px;" />
                     
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                         <img id="myImg" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('div5','myImg','#myImg');" />
                    </td>
                </tr>
            </table>--%>

<div class="container">
                          <div id="demo" runat="server" visible="false" class="panel">
                <div id="divcmphdrcollapse" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div5','Span2');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                 <asp:Label ID="lblTitleUnitCeasure" Text="Cease Unit Search Result"  runat="server" style="font-size:19px"/>
                    </div>
                    <div class="col-sm-2">
                    
                        <span id="Span2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                                     
                <div id="div5" style="display:block;width: 97%;margin-top: 10px;" runat="server">
                            
                            <asp:RadioButtonList ID="rdbUnit" runat="server" 
                                CssClass="radiobtnHidden" Enabled="false" Height="11px" 
                                RepeatDirection="Horizontal" Visible="false">
                            </asp:RadioButtonList>
                       
             
                            <asp:UpdatePanel ID="updPnl_DgDetails" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgDetails" runat="server" AllowPaging="True"  PageSize="10"
                                        AllowSorting="True" AutoGenerateColumns="false" DataKeyNames="UnitCode" 
                                        HorizontalAlign="Left" OnPageIndexChanging="dgDetails_PageIndexChanging" 
                                        OnRowCommand="dgDetails_RowCommand" OnRowDataBound="dgDetails_RowDataBound" 
                                        OnRowDeleting="dgDetails_RowDeleting" OnSorting="dgDetails_Sorting" 
                                        CssClass="footable">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                                        
                                        <Columns>
                                            <asp:BoundField DataField="UnitCode" HeaderText="Unit Code" 
                                                SortExpression="UnitCode" />
                                            <asp:TemplateField HeaderText="BizSrc" ShowHeader="true" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBizSrc" runat="server" Text='<%# Bind("Bizsrc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LegalName" HeaderText="Unit Description" 
                                                SortExpression="LegalName">
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RptUnitCode" HeaderText="Reporting Unit" 
                                                SortExpression="RptUnitCode">
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitMgrName" HeaderText="Unit Manager" 
                                                SortExpression="UnitMgrName">
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitType" HeaderText="Unit Type" 
                                                SortExpression="UnitType">
                                            <ItemStyle Font-Bold="false" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CmsUnitCode" HeaderText="Insurer Code" 
                                                SortExpression="CmsUnitCode">
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RptCmsUnitCode" HeaderText="Insc Reporting Code" 
                                                SortExpression="RptCmsUnitCode">
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Cease Unit">
                                                <ItemTemplate>
                                                    <i class="fa fa-ban" style="color:Red;"></i>
                                                    <asp:LinkButton ID="lnkCease" runat="server" CommandName="Cease"     ForeColor="Red" Text="Cease"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                       
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                       
                    
                    
                    <tr ID="trBtnNew" runat="server" style="width: 80%" visible="false">
                        <td align="center">
                        </td>
                    </tr>
                </table>
                <br />
                 
                 <div id="divPage" visible="true" runat="server" class="pagination">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                    <br />

                </div>

                </div>
              </div>
               
               
               
               
               
               
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
   <%-- <asp:UpdatePanel ID="updPnl_Message" runat="server" UpdateMode="Always">
        <ContentTemplate>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="150px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    <asp:Label ID="lblModalTitle" runat="server" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                        <asp:Label ID="Lbl" runat="server"></asp:Label>
                        <br />
                    </center>
                    <br />
                </td>
                </tr>
        </table>
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" CssClass="standardbutton" />
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl" BehaviorID="mdlpopup" 
    BackgroundCssClass="modalPopupBg" PopupControlID="pnl" DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
--%>
     <asp:Panel runat="server" ID="pnl_UntDetails" Width="920px" Height="400px">
            <iframe id="ifrm_UntDetails" height="400px" width="920px" runat="server" visible="true"></iframe>
            </asp:Panel>
     <ajaxToolkit:ModalPopupExtender ID="mdl_UntDetails" runat="server" TargetControlID="ifrm_UntDetails" BehaviorID="mdl_UntDetails" BackgroundCssClass="modalPopupBg"
            PopupControlID="pnl_UntDetails" DropShadow="false"></ajaxToolkit:ModalPopupExtender>

</asp:Content>