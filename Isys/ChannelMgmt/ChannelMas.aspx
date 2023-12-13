<%--Creator:		    <Ajay Yadav> 
    Create date:      <21th Sep 2021>
    Description:	    <This page is created for Channel Mas.(Code Optimization)>
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChannelMas.aspx.cs" Inherits="INSCL.ChannelMas"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
         <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
   <%-- <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="HirerachyJS/Load.js?time=33"></script>
        <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <style type="text/css">
        .ccsalignCenter {
            text-align: center !important;
        }

        .cssalingleft {
            text-align: left !important;
        }

        .cssalingright {
            text-align: right !important;
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
        //Collapse Down-Up Function.
        function ShowReqDtl(divName, btnName) {
            //debugger;
            var objnewdiv = document.getElementById(divName);
            var objnewbtn = document.getElementById(btnName);

            if (objnewdiv.style.display == "block") {
                objnewdiv.style.display = "none";
                //  objnewbtn.className = 'glyphicon glyphicon-collapse-up'
            }
            else {
                objnewdiv.style.display = "block";
                //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
            }
        }

        //Cross Cancel Function For Hirerachy .
        
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-container" style="margin-left: 35px; margin-right: 15px;">
                <div class="row">
                    <div class="col-sm-1">
                        <asp:Image ID="Image1" runat="server" src="../../../theme/iflow/Channel.jpg" alt=""
                            Width="88px" Height="103px" />
                    </div>
                    <div class="col-sm-11">

                        <%--Channel Setup GridView Panel--%> 
                        <div class="card PanelInsideTab">
                            <div id="DivHeaderChnlStp" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_DivGvPnl','btndivchnDetails');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblChnlSetup" runat="server" Text="CHANNEL SETUP" CssClass="control-label" Font-Size="19px" style="color:#00cccc"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div id="DivGvPnl" runat="server" >
                                <input id="hdnselectedBizsrc" runat="server" type="hidden" />
                                <asp:GridView AllowSorting="True" ID="dgDetails" runat="server" CssClass="footable"
                                    AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"
                                    OnSorting="dgDetails_Sorting" OnRowDataBound="dgDetails_RowDataBound">
                                    <RowStyle CssClass="GridViewRowNew" />
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Channel Code" SortExpression="BizSrc">
                                            <ItemTemplate>
                                                <div>
                                                    <i class="fa fa-edit"></i>&nbsp;
                                                        <asp:LinkButton ID="lbBizSrc" runat="server" Text='<%# Eval("BizSrc") %>' CommandArgument='<%# Eval("BizSrc") %>'
                                                            OnClick="lbBizSrc_Click"></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="false"></ItemStyle>
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" HeaderText="Channel Description" SortExpression="ChannelDesc01">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChannelDesc01" runat="server" Text='<%# Eval("ChannelDesc01") %>'
                                                    CommandArgument='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="SortOrder" HeaderText="Sort Order" ItemStyle-Width="10%"
                                            Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSortOrder" runat="server" Text='<%# Eval("SortOrder") %>' CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10%" Visible="false">
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <i class="fa fa-trash-o"></i>
                                                        <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" />
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                                <ItemStyle CssClass="ccsalignCenter" />
                                            </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Member Hierarchy">
                                            <ItemTemplate>
                                                <div style="width: 100%;">
                                                    <i class="fa fa-male"></i>
                                                    <asp:LinkButton ID="lnkbtnHumanHierarchy" runat="server" Text="Definition" OnClick="lnkbtnHumanHierarchy_Click"></asp:LinkButton>&nbsp;&nbsp; <i class="fa fa-male">
                                                </i>
                                                     <asp:LinkButton ID="lnkMem" Text="Actual" runat="server" OnClick="lnkMem_Click">
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Office Hierarchy">
                                            <ItemTemplate>
                                                <div style="width: 100%;">
                                                    <asp:LinkButton ID="lnkbtnLocationHierarchy" runat="server" Text="Definition" OnClick="lnkbtnLocationHierarchy_Click"></asp:LinkButton>&nbsp;&nbsp;
                                                    <asp:LinkButton ID="lnkbtnUnit" runat="server" Text="Actual" OnClick="lnkbtnUnit_Click"></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Cease Channel">
                                            <ItemTemplate>
                                                <div style="width: 100%;">
                                                    <%--<asp:LinkButton ID="lbLAbc" Text="Definition" runat="server" OnClick="lbLAbc_Click"> </asp:LinkButton>--%>&nbsp;&nbsp;
                                                        <%--<asp:LinkButton ID="lnkbtnActSub" runat="server" Text="Actual" OnClick="lnkbtnActSub_Click"></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lnkbtnchnlCease"  runat="server" OnClick="lnkbtnchnlCease_Click"
                                                                     > <i aria-hidden="true" class="glyphicon glyphicon-trash" style="color:red;"></i>
                                                                    </asp:LinkButton
                                                                 >
                                                   
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <center>
                                <div id="divPage" visible="true" class="row" runat="server">
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;height:30px;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </center>
                                <br />
                                <%--Add New Button For Adding New Channel--%> 
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center">
                                    <%--    <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                            OnClick="btnAddNew_Click" TabIndex="43">
                                       <span class="glyphicon glyphicon-plus" style="color:White"> </span> ADD NEW
                                        </asp:LinkButton>--%>
                                         <asp:LinkButton ID="btnAddNew" runat="server"  CssClass="btn btn-success" 
                              CausesValidation="false" OnClick="btnAddNew_Click" TabIndex="43" >
                                  <span class="glyphicon glyphicon-plus" style="color:White"> </span> ADD NEW
               
                                </asp:LinkButton>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>

                        <%--Modal Popup For Hirerachy--%>
                        <div class="modal" id="myModalRaise" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top: -2px; margin-bottom: -31px">

                            <div class="modal-dialog" style="padding-top: 0px; margin-top: 2px; width: 95%;">
                                <div class="modal-content">
                                    <div class="modal-header" style="margin-top: -10px; background-color: #33bbff; color: white; margin-bottom: -20px; padding-bottom: 10px ! important;">
                                        Employee Hirerachy
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
                    </div>
                </div>
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>   
</asp:Content>
