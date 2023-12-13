<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AdminModule.aspx.cs"
    Inherits="Application_ISys_Recruit_AdminModule" Title="Untitled Page" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate"  TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
     <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
   
 <script type ="text/javascript">
     
     function doCancel() {
         debugger;
         $("#ctl00_ContentPlaceHolder1_pnl").hide();

     }
     function validateEmail1() {
         debugger;
         var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;
         var sEmail1 = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value;
         if (!sEmail1.match(reEmail)) {
             alert("Please Enter Valid Email-1 Address");
             document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
            
             return;
         }


     } 
     function popup() {
         $("#myModal").modal();
     }
     function popupPnl() {
         $("#myModalPnl").modal();
     }
     function ShowReqDtl(divName, btnName) {
         debugger;
         try {
             var objnewdiv = document.getElementById(divName)
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
         catch (err) {
             ShowError(err.description);
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
    </style>
    <asp:ScriptManager ID="sm50HrsSearch1" runat="server">
    </asp:ScriptManager>
   
    <div style="overflow: hidden;">
                    <asp:Panel ID="pnlRprt" Width="100%" runat="server" Style="overflow: hidden;">
            <center>
               <div class="panel  panel-success">
                    
                         <div id="Divmain" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_idpnlBdy','btnWfParam');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;">
                                            </span>
                                            <asp:Label ID="lblTitle" runat="server" Text="Document Email Search"
                                              ></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="btnWfParam" class="glyphicon glyphicon-collapse-down" style="float: right;
                                                color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                      
                        <div id="idpnlBdy" runat="server" class="panel-body" style="display:block;">
                  <div id="divSrvcReqReport"  class="panel-body panel-collapse collapse in">
                           <div id="tblRpt" runat="server" class="row">

                             <div class="row">
                            <div class="col-md-3" style="text-align: left">

                     
                           
                                <asp:Label ID="lblchncls" runat="server" CssClass="control-label" Text="Channel" Style="color: black" Font-Bold="False"></asp:Label>
                               <span style="color: Red;"> * </span>
                          
                           </div>
                           <div class="col-md-3">
                                <asp:DropDownList ID="ddlchcnls" DataTextField="ParamDesc" DataValueField="ParamValue" AutoPostBack ="true"
                                    runat="server"  CssClass="form-control" TabIndex="10" style="margin-bottom: 5px;"
                                    OnSelectedIndexChanged="ddlChncls_SelectedIndexChanged">
                                </asp:DropDownList>
                               
                          </div>
                              <div class="col-md-3" style="text-align: left">
                           
                                <asp:Label ID="lblInsuranceType" Text="Sub Channel" CssClass ="control-label" runat="server" Style="color: black" Font-Bold="False"></asp:Label>
                                  <span style="color: Red;">  * </span>
                           </div>
                               <div class="col-md-3">
                                <asp:DropDownList ID="ddlInsuranceType" runat="server" CssClass="form-control" AutoPostBack ="true"
                                    TabIndex="11" style="margin-bottom: 5px;" OnSelectedIndexChanged="ddlBizsrc_SelectedIndexChanged">
                                </asp:DropDownList>
                           </div>
                            </div>
                     <div class="row">
                            <div class="col-md-3" style="text-align: left">
                     
                                <asp:Label ID="lblBranchName" Text="Branch Name" CssClass ="control-label" runat="server" Font-Bold="False"></asp:Label>
                       
                           </div>
                           <div class="col-md-3">
                                <asp:DropDownList ID="ddlBranchName" style="margin-bottom: 5px;" runat="server" CssClass="form-control" TabIndex="12" >
                              
                                </asp:DropDownList>
                           </div>
                               <div class="col-md-3" style="text-align: left">
                               </div>
                               <div class="col-md-3">
                               </div>

                                  <div ID="SeaCan" runat="server">

                                <div align="center" class="col-sm-12">
                                    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-primary" 
                                        OnClick="btnSearch_Click"  >
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                                </asp:LinkButton>
                                    <asp:LinkButton ID="btncancel" runat="server" CssClass="btn btn-danger" 
                                 OnClick="btnClear_Click" > <%-- --%>
                                 <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Clear
                                </asp:LinkButton>
                                </div>

                                 <div align="center" class="col-sm-12">
                                   <asp:Label ID="Label5" runat="server" ForeColor="Red" Visible="False" CssClass="control-label"></asp:Label>
                                 </div>
                            </div>

                        </div>
                        </div>
                        <br />
                         <div id="Divnote" class="panel panel-success" runat="server" visible="false">
                      <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_tblAdminSearch','Span1');return false;">
                            <div class="row" id="trDetails" runat="server">
                                <div class="col-sm-10" style="text-align: left">
                                
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;">
                                       </span>
                                        Mail Search Results
                                        <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                   
                                </div>
                                <div class="col-sm-2">
                                    <span id="Span1" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                   <div id="tblAdminSearch" runat="server" style="overflow:auto;">
                   <%-- <table id="tblAdminSearch" runat="server" style="width:90%;">
                        <tr>
                            <td colspan="2">--%>
                               
                                        <asp:GridView ID="dgAdmin" runat="server" AllowSorting="True" CssClass="footable"
                                            PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                            RowStyle-CssClass="formtable" AllowPaging="True" HorizontalAlign="Left" AutoGenerateColumns="False"
                                            OnRowCommand="dgAdmin_RowCommand"  OnPageIndexChanging="dgAdmin_PageIndexChanging" Width="100%">
                                              <RowStyle CssClass="GridViewRow"></RowStyle>
                                      <HeaderStyle CssClass="gridview th" />
                                   <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>
                                            <Columns>
                                                <asp:BoundField SortExpression="Branchcode" HeaderText="Branch code" DataField="unitcode"
                                                    Visible="false" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField SortExpression="Branch" HeaderText="Branch Name" DataField="Branch"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle CssClass="pad" > </ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField SortExpression="Channel" HeaderText="Sales Channel" DataField="Channel"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField SortExpression="SubChannel" HeaderText="Sales Sub Channel" DataField="SubChannel"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField SortExpression="Email" HeaderText="Email" DataField="Email" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField SortExpression="Request" HeaderText="">
                                                    <ItemTemplate>
                                                        <div style="white-space: nowrap; width: 100%;">
                                                            <i class="fa fa-flash"></i>
                                                            <asp:LinkButton ID="lblEmailClick" runat="server" Text="Edit Email" CommandArgument='<%# Eval("unitcode") %>'
                                                            CommandName="EmailClick"></asp:LinkButton>
                                                           <asp:Label ID="lblUnitCode" runat="server" Text='<%# Eval("unitcode") %>' Visible="false"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                            </Columns>
                                            <%--<RowStyle CssClass="sublinkodd"></RowStyle>
                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                            </PagerStyle>
                                            <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" HorizontalAlign="Center">
                                            </HeaderStyle>
                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                        </asp:GridView>

                                         <br />
                                         <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                  
                          </div>
                    </div>
                    </div>
          </div>
          </div>
            </center>
            </asp:Panel>
            </div>
    <div class="modal fade" id="myModalPnl" role="dialog">
        <div class="modal-dialog" style="width:95%;">
            <!-- Modal content-->
            <div class="modal-content" >
                <div id="Divpnl" runat="server" class="panel-heading" style="background-color:#dff0d8;" > <%-- class="modal-header" --%>
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <span class="glyphicon glyphicon-menu-hamburger"></span>
                            <asp:Label ID="lblmail" Text=" Email Edit" ForeColor="Green"   runat="server"></asp:Label>
                            <%--<asp:Label ID="lblMessage" runat="server" Visible ="false" ForeColor="red"></asp:Label>--%>
                        </div>
                        
                    </div>
                </div>
                <div class="modal-body" style="text-align: center">
                    <div class="row" style="padding-bottom: 15px">
                        <div class="col-md-3" style="text-align: left">
                            <%--<tr id="tr1" runat="server">--%>
                            <%-- <td class="formcontent" align="left" style="width: 20%">--%>
                            <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Channel" Font-Bold="False"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="Ddlchannel" runat="server" Style="margin-bottom: 5px;" CssClass="form-control"
                                Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="Label3" Text="Sub Channel" runat="server" CssClass="control-label"
                                Font-Bold="False"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="Ddlsubchannel" Style="margin-bottom: 5px;" runat="server" CssClass="form-control"
                                Enabled="false"></asp:TextBox>
                        </div>
                        <%-- </tr>
                    <tr id="tr2" runat="server">--%>
                        <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="Label4" Text="Branch Name" runat="server" CssClass="control-label"
                                Font-Bold="False"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="DDlBranch" Style="margin-bottom: 5px;" runat="server" CssClass="form-control"
                                Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblEmailId" runat="server" CssClass="control-label" Text="Email-ID"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtEmail" Style="margin-bottom: 5px;" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <%--  </tr>
                        --%>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <asp:LinkButton ID="btnedit" OnClick="btnedit_Click" OnClientClick="validateEmail1();"
                        CssClass="btn btn-primary" runat="server">
                                 <span class="glyphicon glyphicon-ok-circle" style='color:White;'> </span> Update Email
                    </asp:LinkButton>
                     <button type="button" class="btn btn-danger" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-remove" style='color:White;'> </span> Cancel

             </button>
         
                </div>
            </div>
        </div>
    </div>
             <asp:Panel ID="pnl" Width="90%" visible="false" Height="100%"  runat="server" Style="overflow: hidden; left: 5px; top: 5px; 
                z-index: 1; position:fixed">
            <%-- <asp:Panel ID="pnl" runat="server" Style=" left: 5px; top: 5px; 
                z-index: 1; " Width="100%" Height="50%" >--%>
                
              <%--  <table id="table" runat="server" class="tableIsys" style="width: 100%;">--%>
                <div class="panel  panel-success">
               
                      
                   <%-- <tr>
                        <td class="test portlet-title" colspan="4" align="left" style="height: 20px;">
                            <asp:Label ID="Label1" runat="server" Text=" Email Edit" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>--%>
                 
                       <%-- <tr  id="trRecord" runat="server" visible="false">
                            <td align="center" colspan="4" style="height: 30px;">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
                            </td>
                        </tr>--%>
                         <div class="panel  panel-success">
                    <div id="divSearch" runat="server" style="display: block" class="panel-body">
                           
       

                     <div id="tr3" style="padding-bottom:6px"   runat="server" class="col-sm-12" align="center">
                               
                            </div>
                                </div>
                                </div>
                 <%--   <tr id="tr3" runat="server">
                        <td align="center" colspan="4" style="height: 20px">--%>
                           <%-- <asp:Button ID="btnedit" runat="server" CssClass="standardbutton" OnClick="btnedit_Click" OnClientClick="validateEmail1();"
                                TabIndex="43" Text="Update Email" Width="100px" />
                            <asp:Button ID="Button2" runat="server" CssClass="standardbutton"
                            OnClientClick="return doCancel();"
                             OnClick="btnClear_Click"--%>
                           <%--     TabIndex="43" Text="Cancel" Width="80px" />
                            <div id="div1" runat="server" style="display: none;">
                                &nbsp;&nbsp;
                                <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
                            </div>
                        </td>
                    </tr>--%>
                    
                 
              <%--  </table>--%>
                   </div>
            </asp:Panel>
    
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblSub"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="Button2" X="200" Y="100">
        </ajaxToolkit:ModalPopupExtender>



         <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" style='width:400px;height:225px;'>
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label1" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl3" runat="server"></asp:Label><br />
          <asp:Label ID="lbl2" runat="server"></asp:Label><br />
          <asp:Label ID="lbl4" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
 
        <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="330" BackColor="Blue"  style="display:none;" Height="130">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
                </table>
                <table>
                </table>
                <center>
                    <br />
                    <asp:Label ID="lblSub" Text ="Email Id Changed Successfully"  runat="server"></asp:Label></center>
                <br />
                <center>
                     <asp:Button ID="btnokSub" runat="server" Text="OK" Width="81px"  OnClientClick="return doCancel();"  />
                   </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblSub"
                BehaviorID="mdlpopupSub" PopupControlID="pnlSub"
                DropShadow="false" OkControlID="btnokSub" X="300" Y="100">
            </ajaxToolkit:ModalPopupExtender>

            
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>