<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AGTSearchLvl.aspx.cs" Inherits="INSCL.AGTSearchLvl"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
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
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
   
      
          <style type="text/css">
          .panel-success{margin-left: 2% !important;margin-right: 2% !important;}
          .disablepage
        {
            display: none;
        }
    

    </style>
    
    <script language="javascript" type="text/javascript">
        function popup() {
            $("#myModal").modal();
        }

        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
            var objnewbtn = document.getElementById(btnName);

            if (objnewdiv.style.display == "block") {
                objnewdiv.style.display = "none";
               // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
            }
            else {
                objnewdiv.style.display = "block";
               // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
            }
        }

    </script>
    <%--Added by Pranjali on 28-05-2013 for modal popup display start--%>
    <asp:ScriptManager ID="SM1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>
    <%--Added by Pranjali on 28-05-2013 for modal popup display end--%>


            <center class="container">
                
         <div class="panel" id="divMemTypehdrcollapse" runat="server" >
                  <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divMemTypehdr','btndivMemTypehdr');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblAgtTypeSearch" runat="server"  CssClass="control-label"  Font-Size="19px"></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                     <asp:LinkButton align="right" ID="lbOldHier" OnClick="btnOldHier_Click" Font-Bold="true" ForeColor="Yellow"  Font-Italic="true" Visible="false" Font-Size="Smaller" Text="View Old Hierarchy" runat="server" />
                         <span id="btndivMemTypehdr" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                  
                    <div id="divMemTypehdr" runat="server" class="panel-body" style="display:block"> 
                     <div class="row" style="margin-bottom:5px;">
                     <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblChnlType" runat="server" CssClass="control-label"></asp:Label>
                     </div>
                      <div class="col-md-3">
                            <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" CellPadding="2" 
                                                CellSpacing="2" RepeatDirection="Horizontal" 
                                        TabIndex="1" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="&nbsp;Company  &nbsp;&nbsp;"></asp:ListItem>
                                        <asp:ListItem Selected="True" Value="1" Text="&nbsp;Channel"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                    </div>
                        <div class="col-md-3">
                        </div>
                         <div class="col-md-3">
                         </div>  
                  </div>
                      <div class="row" style="margin-bottom:5px;">
                  <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblSalesChannel" runat="server"  Height="22px" Width="150px" CssClass="control-label"></asp:Label>
                   </div>
                  <div class="col-md-3">
                            <asp:UpdatePanel ID="upddlSales" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSalesChannel" runat="server"  TabIndex="2" AutoPostBack="True"  CssClass="form-control"
                                        OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                    </div>
                  <div class="col-md-3" style="text-align:left">
                            <asp:Label ID="lblChnnlClass" runat="server" Height="22px" Width="150px" CssClass="control-label"></asp:Label>
                     </div>
                  <div class="col-md-3">
                            <asp:UpdatePanel ID="upddlChnlCls" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlChnnlClass" runat="server"  TabIndex="3" CssClass="form-control"  OnSelectedIndexChanged="ddlChnnlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </div>
                </div>
                   <div class="row">
                  
                   </div>
                    </div>
     
              <div class="col-md-12" style="text-align:center">
                            <input id="flgHidden" type="hidden" />
                             <%--   <asp:Button ID="btnSearch" runat="server"  TabIndex="43"
                                    Text="SEARCH" Width="80px" OnClick="btnSearch_Click"  CssClass="btn blue"/>--%>
                                    <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-sample" style='margin-top:10px;'
                              CausesValidation="false" OnClick="btnSearch_Click" TabIndex="4" >
                                  <span class="glyphicon glyphicon-search BtnGlyphicon" style="color:White"> </span> Search
               
                                </asp:LinkButton> 
                                    &nbsp;&nbsp;
<%--
                                <asp:Button ID="btnClear" runat="server" CssClass="btn default" TabIndex="43"
                                    Text="CLEAR" Width="80px" OnClick="btnClear_Click" />--%>
                                     <asp:LinkButton ID="btnClear" runat="server"  CssClass="btn btn-sample"  style='margin-top:10px;'
                              CausesValidation="false" OnClick="btnClear_Click" TabIndex="5" OnClientClick="return validate();" >
                                  <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color:White"> </span> Clear
               
                                </asp:LinkButton> 
                  </div>
               </div>
          <table align="center" width="75%" > 
               <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" Width="659px"></asp:Label>
                </td>
            </tr>
                    
                </table>
                <br />
                
                        <div class="panel" id="divcmpsrchhdrcollapse" runat="server" style ="margin-left: 0% !important;margin-right: 0% !important;">
                            <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divkpisrch','btndivkpisrch');return false;">
                                <div class="row" id="trDetails" runat="server" style="margin-bottom: 12px;">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblAgtTypSearchRes" runat="server"  CssClass="control-label" Font-Size="19px"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btndivkpisrch" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divkpisrch" runat="server" style="display: block;width:97%;">
                               
                                    <div id="Div1" runat="server" style="overflow: auto">
                                     <%--   <asp:UpdatePanel ID="updgDetails" runat="server">
                                            <ContentTemplate>--%>
                                                <%--  <asp:GridView ID="dgDetails" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
                                        CssClass="table table-striped table-bordered table-hover table-scrollable dataTable" 
                                        HorizontalAlign="Left" OnPageIndexChanging="dgDetails_PageIndexChanging" 
                                        OnRowCommand="dgDetails_RowCommand" OnRowDataBound="dgDetails_RowDataBound" 
                                        OnRowDeleting="dgDetails_RowDeleting" OnSorting="dgDetails_Sorting" 
                                        Width="100%">
                                        <HeaderStyle ForeColor="Black" />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />--%>
                                                <asp:GridView AllowSorting="True" ID="dgDetails" runat="server" CssClass="footable"
                                                    AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                                    OnRowDeleting="dgDetails_RowDeleting" OnRowDataBound="dgDetails_RowDataBound"
                                                    OnSorting="dgDetails_Sorting" OnRowCommand="dgDetails_RowCommand">
                                                    <FooterStyle CssClass="GridViewFooter" />
                                                    <RowStyle CssClass="GridViewRowNew" />
                                                    <HeaderStyle CssClass="gridview" />
                                                    <PagerStyle CssClass="disablepage" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                                    <%--<AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                                                    <Columns>
                                                        <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType" />
                                                        <asp:BoundField DataField="ChannelDesc" HeaderText="Hierarchy Name" SortExpression="ChannelDesc">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ChnlDesc" HeaderText="Sub Class" SortExpression="ChnlDesc">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UnitRank" HeaderText="Unit Rank" SortExpression="UnitRank" />
                                                        <asp:BoundField DataField="MemLevel" HeaderText="Member Level" SortExpression="MemLevel" />
                                                        <asp:BoundField DataField="MemTypeDesc01" HeaderText="Member Type Description" SortExpression="MemTypeDesc01">
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmemtyp" runat="server" Text='<%#Bind("MemType")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbizsrc" runat="server" Text='<%#Bind("BizSrc")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblchncls" runat="server" Text='<%#Bind("ChnCls")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ShowHeader="True" HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <div style="width: 100%;">
                                                                    <i class="fa fa-trash-o"></i>
                                                                    <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" Text="Delete" />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                          <%--  </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                  <br />
                                    <center>
                                        <div id="divPage" visible="true" runat="server" style="margin-left: 555px">
                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                        </div>
                                        <br />
                                    </center>
                                   
                                   
                               
                            </div>  
                           
                             
                          
                        </div>
                         
                 <div class="row">
                                <div class="col-md-12" style='margin-left:2%;' align="center">
                                  
                                    <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-sample" CausesValidation="false" style='margin-top:10px;margin-bottom:10px;'
                                        OnClick="btnAddNew_Click" Visible="false" TabIndex="6">
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> Add New
               
                                    </asp:LinkButton>
                                    &nbsp;&nbsp;
                               
                                    <asp:LinkButton ID="btnCopy" runat="server" Visible="false" CssClass="btn btn-sample" CausesValidation="false" style='margin-top:10px;margin-bottom:10px;'
                                        OnClick="btnCopy_Click" TabIndex="7">
                                  <span class="glyphicon glyphicon-duplicate" style="color:White"> </span> Copy Hierarchy
               
                                    </asp:LinkButton>
                                </div>
                            </div>
                <br />
                
                <div class="panel" id="divCopy" runat="server" style ="margin-left: 2% !important;margin-right: 2% !important;">
                    <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divUnittypecopy','btndivUnittypecopy');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Text="Hirearchy Copy" CssClass="control-label"  Font-Size="19px"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btndivUnittypecopy" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                   
                            <div id="divUnittypecopy" runat="server" class="panel-body" style="display: block">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblChnl" runat="server" Text="Hierarchy Name" CssClass="control-label" />
                                    </div>
                                    <div class="col-md-3">
                                    <%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>--%>
                                                <asp:DropDownList ID="ddlChnl" TabIndex="8" runat="server" CssClass="form-control" AutoPostBack="true"
                                                    onselectedindexchanged="ddlChnl_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                           <%-- </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    </div>
                                    <div class="col-md-3" style="text-align: left">
                                        <asp:Label ID="lblRank" runat="server" CssClass="control-label" Height="22px" Text="Sub Class"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSubclass" TabIndex="9" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlChnl" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center">
                                        <%--   <asp:Button ID="btnUpdate" runat="server" CssClass="btn blue"
                                        OnClick="btnUpdate_Click" TabIndex="6" Text="UPDATE" Width="80px" />--%>
                                        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sample" CausesValidation="false" style='margin-top:10px;'
                                            OnClick="btnUpdate_Click" TabIndex="10">
                                  <span aria-hidden="true" class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Update
               
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                              </div>
                       
                  


          
               <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" >
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl_popup" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-verify" data-dismiss="modal" style='margin-top:-6px;border-radius: 15px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="200px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
                </table>
                <table>
                </table>
                <table>
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lbl" runat="server"></asp:Label><br />
                            </center>
                            <br />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
     
    </center>
    <%--Added by Pranjali on 28-05-2013 for modal popup end--%>
</asp:Content>
