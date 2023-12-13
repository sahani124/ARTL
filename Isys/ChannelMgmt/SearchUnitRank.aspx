<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchUnitRank.aspx.cs" Inherits="INSCL.SearchUnitRank"
    MasterPageFile="~/iFrame.master" %>

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
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />

    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
       <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
<%--    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />--%>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
     <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
 
         

  <%--  <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />--%>
  <%--  <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>

  
    <style type="text/css">
        /*.panel-success{margin-left: 50px !important;margin-right: 50px !important;}*/
        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
        }

        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }



                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }
    </style>

     <style type="text/css">
        .disablepage
        {
            display: none;
        }

     .gridview th {
    padding: 10px;
    height: 40px;
    border-color: #53accd !important;
    /*text-align: center;*/
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
} 
.clsCenter{
    text-align:center !important;
}
.clsLeft{
    text-align:left !important;
}
      .panel_over
      {
            margin-left: 0%!important;
            margin-right: 0%!important;
      }
	  .pad{
		  text-align:center !important;
	  }
	  .pad1{
		  text-align:left !important;
	  }
       
    </style>

    <script type="text/javascript">

        function popup() {
            debugger;
            $("#myModal").modal();
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }

        function funpopup() {
            var myExtender = $find('mdlpopup1');
            myExtender.show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../ISys/ChannelMgmt/PopSearchUnitRank.aspx";
        }

        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

    </script>
    <center>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <%--Unit Rank Setup--%>
          <div class="card PanelInsideTab">
                <div id="divcmphdrcollapse" runat="server" class="panelheadingAliginment"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    
                        <asp:Label ID="lblhdr"  runat="server"  CssClass="control-label HeaderColor" Font-Size="19px" />
                 
                    </div>
                    <div class="col-sm-2">
                     <asp:LinkButton align="right" ID="lbOldHier" OnClick="btnOldHier_Click" Font-Bold="true" ForeColor="Yellow"  Visible="false" Font-Italic="true" Font-Size="Smaller" Text="View Old Hierarchy" runat="server" />
                        <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                
                         
                         <div id="divcmphdr"  style="display:block;" runat="server" class="panel-body">
                          
                              <div id="trregstrtndt" runat="server" class="row rowspacing">
                           <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="lblChnlType" runat="server" CssClass="control-label"></asp:Label>
                                </div>   
                                       
                                       
                                        <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                            <ContentTemplate>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:RadioButtonList ID="rdbChnlTyp" runat="server" CssClass="radiobtn control-label" AutoPostBack="true" CellPadding="2" 
                                                       CellSpacing="2" RepeatDirection="Horizontal" Width="185px"
                                                    TabIndex="1"  OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="&nbspCompany" ></asp:ListItem>
                                                    <asp:ListItem Value="1" Selected="True" Text="&nbspChannel" ></asp:ListItem>
                                                </asp:RadioButtonList>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                  
                                   <div class="col-sm-3" style="text-align:left">
                                        <asp:Label ID="lblSaleschannel" runat="server" CssClass="control-label"></asp:Label>
                                        </div>
                                   
                                        <asp:UpdatePanel ID="upChnnl" runat="server">
                                            <ContentTemplate>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:DropDownList ID="ddlSalesChannel" runat="server"   CssClass="form-control"
                                                     TabIndex="2">
                                                </asp:DropDownList>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                 
                         </div>
                            <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" Width="415px"></asp:Label>
                        
                        </div>

                       </div>

        <%--Button Area--%>
          <div class="row">
                    <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" AutoPostback="false" OnClick="btnSearch_Click" TabIndex="11">
                                    <span class="glyphicon glyphicon-search" style='color:White;'></span> SEARCH
                                </asp:LinkButton> 
                                <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" 
                                     CssClass="btn btn-clear" runat="server">  CLEAR 
                                </asp:LinkButton>
                    </div>
            </div>

          <br />  

        <%--Unit Rank Search Results--%>
          <%--<div class="container"  >--%>
                          <div id="divcmpsrchhdrcollapse" class="card PanelInsideTab"   runat="server" >
                <div id="div2" runat="server" class="panelheadingAliginment"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divsrch','Span1');return false;">           
                          <div class="row"  style="margin-bottom: 12px;">
                    <div class="col-sm-10" style="text-align:left">
                  
                        <asp:Label ID="lblUnitRankSearchResult"  runat="server" CssClass="control-label HeaderColor"  Font-Size="19px"
                                     />
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                    
                    </div>          
                       
                 <div id="divsrch" runat="server"  >
                           
                     <div style="overflow-x: scroll; display: block;">
                               <asp:GridView  AllowSorting="True" ID="dgDetails" runat="server" CssClass="footable"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   OnRowDeleting="dgDetails_RowDeleting"
                                        OnRowDataBound="dgDetails_RowDataBound" OnSorting="dgDetails_Sorting" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                                  <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        
                                        <EmptyDataTemplate>
                                            <asp:Label ID="lblerror" Text="No unit rank have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="ChannelDesc01" HeaderText="Sales Channel" 
                                                SortExpression="ChannelDesc01">
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                          <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitRank" HeaderText="Unit Rank" 
                                                SortExpression="UnitRank">
                                                  <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                                 <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                                </asp:BoundField>
                                            <asp:TemplateField ShowHeader="false" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbluntRnk"  runat="server" Text='<%# Bind("UnitRank") %>'></asp:Label>
                                                </ItemTemplate>
                                                  <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                                 <ItemStyle CssClass="clsLeft" />
                                                <HeaderStyle CssClass="clsLeft" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitRankDesc01" HeaderStyle-Width="180px"  
                                                HeaderText="Unit Rank Description" SortExpression="UnitRankDesc01">
                                            <ItemStyle Font-Bold="False" HorizontalAlign="Center" />
                                                 <ItemStyle CssClass="clsLeft" />
                                        <HeaderStyle CssClass="clsLeft" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Delete" ShowHeader="true" Visible="false" >
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <i class="fa fa-trash-o"></i>
                                                        <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" 
                                                             Text="Delete" />  
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle  HorizontalAlign="Center" />  
                                              
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                              
                         </div>
               
                           
                   
                           <div>
                          <br />
                        <center>
                            <table>
                                <tr>
                                    <td  >
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                           
                                    </td>
                                </tr>
                            </table>
                        </center>
                        
                    </div>
                  
                   <div class="row">
                        <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnAddnew" runat="server" CssClass="btn btn-success" style='margin-left:10px;margin:10px;'
                                OnClick="btnAddnew_Click" TabIndex="43" Text="ADD NEW"  Visible="false">
                                  <span class="glyphicon glyphicon-plus" style='color:White;'></span> ADD NEW 
                                 </asp:LinkButton>
                               </div>

                                </div>

                     </div>
                  </div>
       <%-- </div>--%>

          <br />
    </center>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" Style="display: none"
                BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="250px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            <span>INFORMATION</span>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lblpopup" runat="server"></asp:Label><br />
                                <br />
                            </center>
                            <br />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" CssClass="standardbutton"
                        Width="80px" /></center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>--%>

    <asp:Label ID="lbl_popup1" runat="server"></asp:Label>
    <asp:Panel ID="pnlVersion" runat="server" BorderColor="ActiveBorder" BackColor="White" BorderStyle="Solid"
        BorderWidth="2px" Width="700px" Height="370px" Style="display: none">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table class="formtable">
                    <tr>
                        <td colspan="2">
                            <iframe runat="server" id="ifrmMdlPopup" backcolor="#6B0408" width="700px" height="370px"
                                frameborder="1" display="none"></iframe>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <asp:Button ID="btnclose" Text="Close" runat="server" CssClass="standardbutton" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnclose" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup1" runat="server" TargetControlID="lbl_popup1"
        BehaviorID="mdlpopup1" PopupControlID="pnlVersion"
        DropShadow="true">
    </ajaxToolkit:ModalPopupExtender>

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" style='margin-top: -6px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK
                    </button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
