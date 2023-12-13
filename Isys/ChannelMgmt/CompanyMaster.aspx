<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="CompanyMaster.aspx.cs" Inherits="Application_Isys_ChannelMgmt_CompanyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

      <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"  type="text/css" />
  <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
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


  

  <%--  <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
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
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>--%>
    <script src="HirerachyJS/Load.js"></script>
    <script>
		        function ShowReqDtl(divName, btnName) {
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }

    </script>
    <style type="text/css">
        .clsleft{
            text-align:left !important;
        }
        .disablepage
        {
            display: none;
        }

        .gridview th
        {
               padding: 0px;
    height: 40px;
    border-color: #53accd !important;
    text-align: center;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 10px;
        }
       
    </style>
     <div >
      <div class="row">
                 <div class="col-sm-1">
                          <%--  <td valign="top" style="width:5%;">--%>
                                <asp:Image ID="ImgCompany" runat="server" src="../../../theme/iflow/Company.jpg"
                                    alt="" Width="80px" Height="67px" />
                              <%--  <br /> <br /> <br /> <br />  <br /> <br /> <br /> <br /> <br /> <br />
                            <asp:Image ID="Image1" runat="server" src="../../../theme/iflow/Channel.jpg" alt=""
                                    Width="88px" Height="103px" />--%>
                         <%--   </td>--%>
                         </div>
                                <%--<asp:UpdatePanel runat="server"  ID="updlbl">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMsg" runat="server" Font-Bold="False" ForeColor="Red" Visible="False"
                                            Width="510px"></asp:Label></ContentTemplate>
                                </asp:UpdatePanel>--%>
                                   <div class="col-sm-11">

                                 <div class="PanelInsideTab card">
           
              <div id="divcmphdrcollapse" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divsrch','btndivSearchDetails');return false;">     
                  <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblCmpySetup" runat="server" Text="COMPANY SETUP"  CssClass="control-label" Font-Size="19px" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btndivSearchDetails" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
         
         
          </div> 

         <%--   Changed css class by usha on 07.09.2015--%>
       
                <div id="divsrch" runat="server" class="panel-body" style="display:block; overflow:auto">
                    <%-- <div id="Div2" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                         class="table-scrollable">--%>
                        
                        
                              <%--   <asp:GridView ID="dgComDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                     AllowSorting="true" Width="100%" AllowPaging="True" OnRowCommand="dgComDetails_RowCommand"
                                     OnRowDataBound="dgComDetails_RowDataBound" OnSorting="dgComDetails_Sorting" OnPageIndexChanging="dgComDetails_PageIndexChanging"
                                     CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                     OnRowDeleting="dgComDetails_RowDeleting">
                                     <HeaderStyle ForeColor="Black" />
                                     <RowStyle />
                                     <PagerStyle CssClass="disablepage" />--%>
                    <input id="hdnselectedBizsrc" runat="server" type="hidden" />
                                       <asp:GridView  AllowSorting="True" ID="dgComDetails" runat="server" CssClass="footable"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   OnRowDeleting="dgComDetails_RowDeleting"
                                        OnRowDataBound="dgComDetails_RowDataBound" OnSorting="dgComDetails_Sorting" OnRowCommand="dgComDetails_RowCommand" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <%--<AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                                     <Columns>
                                         <asp:TemplateField SortExpression="BizSrc" HeaderText="Company Code" ItemStyle-Width="20%">
                                             <ItemTemplate>
                                                 <div>
                                                     <i class="fa fa-edit"></i>&nbsp;
                                                     <asp:LinkButton ID="lbComBizSrc" runat="server" Text='<%# Eval("BizSrc") %>' CommandArgument='<%# Eval("BizSrc") %>'
                                                         OnClick="lbComBizSrc_Click1"></asp:LinkButton>
                                                 </div>
                                             </ItemTemplate>
                                             <ItemStyle CssClass="clsleft"></ItemStyle>
                                             <HeaderStyle CssClass="clsleft" />
                                         </asp:TemplateField>
                                         <asp:TemplateField SortExpression="ChannelDesc01" ItemStyle-HorizontalAlign="Left"
                                             HeaderText="Company Desc">
                                             <ItemTemplate>
                                                 <asp:Label ID="lblComChannelDesc01" runat="server" Text='<%# Eval("ChannelDesc01") %>'
                                                     CommandArgument='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                             </ItemTemplate>
                                     <ItemStyle CssClass="clsleft"></ItemStyle>
                                             <HeaderStyle CssClass="clsleft" />
                                         </asp:TemplateField>
                                         <asp:TemplateField SortExpression="SortOrder" HeaderText="Sort Order" ItemStyle-Width="10%"
                                             Visible="false">
                                             <ItemTemplate>
                                                 <asp:Label ID="lblComSortOrder" runat="server" Text='<%# Eval("SortOrder") %>' CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                             </ItemTemplate>
                                                   <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10%" Visible="false">
                                             <ItemTemplate>
                                                 <div style="width: 100%;">
                                                     <i class="fa fa-trash-o"></i>
                                                     <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" />
                                                 </div>
                                             </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad"  Font-Bold="False"></ItemStyle>
                                         </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-Width="20%" HeaderText="Channel Classification">
                                             <ItemTemplate>
                                                 <div style="width: 100%;">
                                                     <i class="fa fa-male"></i>
                                                     <asp:LinkButton ID="lbCompHumanHierarchy" Text="Definition" runat="server" OnClick="lbCompHumanHierarchy_Click"
                                                        CssClass="default"></asp:LinkButton>&nbsp;&nbsp; <i class="fa fa-male"></i>
                                                     <asp:LinkButton ID="lnkActHmnCmp" Text="Actual" runat="server" CssClass="default"   Enabled="false" 
                                                         OnClick="lnkActHmnCmp_Click" Visible="false"></asp:LinkButton>
                                             </ItemTemplate>
                                             <ItemStyle CssClass="clsleft"></ItemStyle>
                                             <HeaderStyle CssClass="clsleft" />
                                         </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-Width="20%" HeaderText="Office Hierarchy" Visible="false">
                                             <ItemTemplate>
                                                 <div style="width: 100%;">
                                                     <i class="fa fa-map-marker"></i>
                                                     <asp:LinkButton ID="lbCompLocationHierarchy" Text="Definition" runat="server" OnClick="lbCompLocationHierarchy_Click"
                                                         CssClass="default"></asp:LinkButton>&nbsp;&nbsp; <i class="fa fa-map-marker">
                                                     </i>
                                                     <asp:LinkButton ID="lnkActLocCmp" Text="Actual" runat="server" CssClass="default"
                                                         OnClick="lnkActLocCmp_Click"></asp:LinkButton>
                                             </ItemTemplate>
                                              <ItemStyle CssClass="clsleft"></ItemStyle>
                                             <HeaderStyle CssClass="clsleft" />
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>
                             
                
                     <%-- added by usha --%>
                    <br />
                     <center>
                     <div id="div5" visible="true" runat="server">
                         <center>
                             <table>
                                 <tr>
                                     <td >
                                      
                                                 <asp:Button ID="btnCompprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                     Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnCompprevious_Click" />
                                                 <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                     border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                     text-align: center;" Text="1" ReadOnly="true" />
                                                 <asp:Button ID="btnCompnext" Text=">" CssClass="form-submit-button" runat="server"
                                                     Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                     background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                     OnClick="btnCompnext_Click" />
                                            
                                     </td>
                                 </tr>
                             </table>
                         </center>
                     </div>
                     </center>
                    
                 </div>
          

          
                                <%--<table style="width: 100%; " class="form-actions fluid" >
                                    <tr id="tr3" runat="server">
                                        <td style="text-align: center; width: 50%; padding-bottom: 5px; padding-top: 5px;" colspan="4">--%>
                                          <div class="row" id="tr3" runat="server" style="margin-bottom: 30px">
                      <div class="col-md-12" style="text-align: center">
                                          <%--  <asp:Button ID="btnAddNwCmp" runat="server"  CssClass="btn btn-primary" TabIndex="43"
                                                    Text="ADD NEW" Width="100px" OnClick="btnAddNwCmp_Click" />--%>
                                                        <asp:LinkButton ID="btnAddNwCmp" runat="server"  CssClass="btn btn-success" 
                              CausesValidation="false" OnClick="btnAddNwCmp_Click" TabIndex="43" >
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> ADD NEW
               
                                </asp:LinkButton>
                                </div>
                                </div>
                                        <%--</td>
                                    </tr>
                                </table>--%>
                                </div>
                                </div>
                    </div>       
                     <%--      added by usa--%>
               
                </div>
                <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" style='width:400px;height:225px;'>
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl_popup" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>

      <%--Modal Popup For Hirerachy--%>
                        <div class="modal" id="myModalRaise" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top: -2px; margin-bottom: -31px">

                            <div class="modal-dialog" style="padding-top: 0px; margin-top: 2px; width: 95%;">
                                <div class="modal-content" style=" width: 260%; margin-left: -408px;">
                                    <div class="modal-header" style="margin-top: -10px; background-color: #33bbff; color: white; margin-bottom: -20px; padding-bottom: 10px ! important;">
                                        Company Hirerachy
                        <button type="button" class="close" data-dismiss="modal" style="margin-top: -7px;" aria-hidden="true">&times;</button>

                                    </div>
                                    <div class="modal-body">
                                        <br />
                                        <iframe id="iframeElement" width="100%" height="450" frameborder="0" allowtransparency="true"></iframe>
                                    </div>
                                    <div class="modal-footer" style="display: none">
                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
</asp:Content>
