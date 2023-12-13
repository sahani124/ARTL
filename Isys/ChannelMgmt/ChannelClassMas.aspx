<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChannelClassMas.aspx.cs"
    Inherits="INSCL.ChannelClassMas" MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

      <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" /> 
  <%--  <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>


   <%--  <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    
    <%--<link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
      <script src="HirerachyJS/Load.js"></script>--%>

    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
         <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
  
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
    </style>
    <script  type="text/javascript">
     
        //added by sanoj 06112023
        function OpenForCease() {
            debugger;
            var pouId = document.getElementById("MdlCeaseSubChnl");
            pouId.style.display = "block";
            $(function () {
                debugger;
                $("#<%= txt1effdate.ClientID  %>").datepicker({
                    maxDate: '+365d',
                    minDate: '-0d',
                    dateFormat: 'dd/mm/yy',
                    position: {
                        my: "left top",
                        at: "left bottom",
                        collision: "none"
                    }
                });
            });
        }

        function closedForCease() {
            var pouId = document.getElementById("MdlCeaseSubChnl");
            pouId.style.display = "none";
        }
        function openMoveTo() {
            debugger;
            var pouId = document.getElementById("Mdlmovetto");
            pouId.style.display = "block";
            $(function () {
                debugger;
                $("#<%= txteffdate.ClientID  %>").datepicker({
                    maxDate: '+365d',
                    minDate: '-0d',
                    dateFormat: 'dd/mm/yy',
                    position: {
                        my: "left top",
                        at: "left bottom",
                        collision: "none"
                    }
                });
            });
        }
        function closedMoveto() {
            var pouId = document.getElementById("Mdlmovetto");
            pouId.style.display = "none";
        }

        //Endded by sanoj 06112023

        function popup() {
            $("#myModal").modal();
        }
                function ShowReqDtl1(divName, btnName) {
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


        function funpopup() {
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../ISys/ChannelMgmt/PopChannelClassMas.aspx";
        }

        function ShowReqDtl(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                var btncontrol = document.getElementById("ctl00_ContentPlaceHolder1_btnAddNew");
                btncontrol.style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                var btncontrol = document.getElementById("ctl00_ContentPlaceHolder1_btnAddNew");
                btncontrol.style.display = "block";
                document.getElementById(btnId).value = '-';
            }
        }
        function ShowReqDtls(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }
        function funAddlCmnt() {
            debugger
            var modal = document.getElementById('myModalRaise');
            var modaliframe = document.getElementById("iframeCFR");
            modaliframe.src = "./index.html";
            $('#myModalRaise').modal();
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <table align="center" width="60%" style="padding-top: 28px;">
        <tr id="trMain" runat="server">
            <td colspan="4" rowspan="3" align="center">
                &nbsp;
                <table class="formtable" style="width: 100%">
                    <tr>
                        <td colspan="4" align="left" class="test formHeader">
                            <asp:Label ID="lblchnlscs" runat="server" Height="22px" Width="259px" Text="Channel Sub Class Search"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td align="right" class="formcontent" style="width: 124px; height: 21px">
                            <asp:Label ID="lblSalesChannel" runat="server" Height="22px" Width="259px"></asp:Label>
                        </td>
                        <td align="center" class="formcontent" colspan="3" style="width: 524px; height: 21px">
                            <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="standardmenu">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 26px" align="center">
                            <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="SEARCH" Width="80px" />&nbsp;&nbsp;
                            <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="CLEAR" Width="80px" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table align="center" width="80%">
        <tr>
            <td align="center">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="False" ForeColor="Red" Visible="False"
                    Width="504px"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="95%" align="left">
        <tr>
           <br />
                <br />
            <td valign="top" style="width: 100px">
                <asp:Image ID="ImgCompany" runat="server" src="../../../theme/iflow/Company.jpg"
                    alt="" Width="80px" Height="64px" />
              
                <asp:Image ID="Image1" runat="server" src="../../../theme/iflow/Channel.jpg" alt="" style="height:103px;width:88px;border-width:0px;margin-top: 174px;" />
            </td>
            <td colspan="3" align="center">
              
                <div class="panel">
                    <div id="divcmphdrcollapse" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divComSUBCLASS','btnpersnl');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblCmpSub" Text="COMPANY SUB CLASS SETUP" runat="server" Font-Size="19px"/>
                            </div>
                            <div class="col-sm-2">
                                <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right;
                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divComSUBCLASS" runat="server" class="panel-body" style="display: block;
                        overflow: auto;">
                        <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                            CssClass="footable"
                            Width="100%" OnPageIndexChanging="dgDetails_PageIndexChanging" OnRowDataBound="dgDetails_RowDataBound"
                            OnSorting="dgDetails_Sorting" AllowPaging="True" AllowSorting="True"
                            >
                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />


                            <Columns>
                                <asp:TemplateField HeaderText="Company Code">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCompBizSrc" Text='<%# Eval("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--  added bhau--%>
                                <asp:TemplateField HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCompName" Text='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%-- End--%>
                                <%--<asp:BoundField DataField="ChnCls" HeaderText="Channel Sub Class" SortExpression="ChnCls"></asp:BoundField>--%>
                                <asp:TemplateField HeaderText="SubClass">
                                    <ItemTemplate>
                                        <div>
                                            <i class="fa fa-edit"></i>
                                            <asp:LinkButton ID="lbChnSubCls" runat="server" Text='<%# Eval("ChnCls") %>' OnClick="lbChnSubCls_Click"></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubClass Desc">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblChnClsDesc" Text='<%# Eval("ChnClsDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sort Order">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSortOrder" Text='<%# Eval("SortOrder") %>' CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                              
                                <asp:TemplateField ShowHeader="True" HeaderText="Delete" Visible="false">
                                    <ItemTemplate>
                                        <div style="width: 100%;">
                                            <i class="fa fa-trash-o"></i>
                                            <asp:LinkButton ID="btnDel" Text="Delete" CommandName="Delete" runat="server" />
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Human Hierarchy">
                                    <ItemTemplate>
                                        <div style="width: 100%;">
                                            <i class="fa fa-male"></i>
                                            <asp:LinkButton ID="lbHumanHierarchy" Text="Definition"  runat="server"
                                                OnClick="lbCompHumanHierarchy1_Click"></asp:LinkButton>&nbsp;&nbsp; <%--<i class="fa fa-male">
                                                </i>  --%>
                                              <asp:linkbutton id="lnkbtnActSub" text="Actual" runat="server" 
                                                        onclick="lnkbtnActSub_Click"></asp:linkbutton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location Hierarchy">
                                    <ItemTemplate>
                                        <div style="width: 100%;">
                                            <i class="fa fa-map-marker"></i>
                                            <asp:LinkButton ID="lbLocationHierarchy" Text="Definition" runat="server"
                                                OnClick="lbCompLocationHierarchy1_Click"></asp:LinkButton>&nbsp;&nbsp; <i class="fa fa-map-marker">
                                                </i>
                                              <asp:LinkButton ID="lnkSubLocCmpAct" Text="Actual" runat="server" 
                                                        onclick="lnkSubLocCmpAct_Click"></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         </div>
                    
                <%--PS    <div id="div5" visible="true" runat="server" class="pagination">

                        <table>
                            <tr>
                                <td style="white-space: nowrap;">
                                    <asp:Button ID="btnCompprevious" Text="<" CssClass="form-submit-button" runat="server"
                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                        OnClick="btnCompprevious_Click" />
                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0; text-align: center;"
                                        Text="1" CssClass="form-control" ReadOnly="true" />
                                    <asp:Button ID="btnCompnext" Text=">" CssClass="form-submit-button" runat="server"
                                        Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 30px;"
                                        Width="40px"
                                        OnClick="btnCompnext_Click" />
                                </td>
                            </tr>
                        </table>

                    </div>PE--%>
                   
                   
                        <div id="div5"  visible="true" runat="server">
                        
                                    <div class="row" style="margin-left: 450px;">
                                        <asp:Button ID="btnCompprevious" Text="<" CssClass="form-submit-button" runat="server"
                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; height: 30px; float: left;"
                                            OnClick="btnCompprevious_Click" />
                                        <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid; border-width: 1px; border-color: Gray; height: 30px; text-align: center;"
                                            Text="1" ReadOnly="true" />
                                        <asp:Button ID="btnCompnext" Text=">" CssClass="form-submit-button" runat="server"
                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; height: 30px; float: left;"
                                            Width="40px"
                                            OnClick="btnCompnext_Click" />
                                    </div>
                              
                                
                        </div>
                        

                    
                </div>
              
                <br />
              
                <div class="panel">
                    <div id="div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div4','Span1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblchnsub" Text="CHANNEL SUB CLASS SETUP" runat="server" Font-Size="19px"/>
                            </div>
                            <div class="col-sm-2">
                                <asp:LinkButton Text="View Old Hierarchy" ID="lbOldHier" Font-Italic="true" Font-Size="Smaller"
                                    Visible="false" ForeColor="Yellow" OnClick="btnOldHier_Click" runat="server" />
                                <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div4" runat="server" class="panel-body" style="display: block; overflow: auto;">
                         <%--ADDED BY AJAY 24 MAY 2023 START--%>
                                    <div class="row" style="border: none; margin-bottom: 8px; background-color: #e9f7ff; margin: 0px 0px 10px 0px; border-top: solid 1px #91d3f7; margin-top: -14px; border-bottom: solid 1px #91d3f7; padding-top: 8px;">
                                        <div class="col-sm-1">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#53accd" Style="font-size: 16px;" Text="Status:"></asp:Label>
                                        </div>
                                        <div class="col-sm-5" style="text-align: left; width: 15%;">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal" Style="display: none">
                                                <asp:ListItem style="font-family: Verdana, Tahoma;" Text="&amp;nbspAll&nbsp;&nbsp;&nbsp;" />
                                                <%-- Value="All"--%>
                                                <asp:ListItem Selected="True" style="font-family: Verdana, Tahoma;" Text="&amp;nbspActive&nbsp;" />
                                                <%--Value="Active" --%>
                                                <asp:ListItem style="font-family: Verdana, Tahoma;" Text="&amp;nbspInactive&nbsp;" />
                                                <%--Value="Inactive"--%>
                                            </asp:RadioButtonList>
                                            <table style="float: right;">
                                                <tr id="tractivechnl" runat="server">
                                                    <td align="left" class="">
                                                        <asp:RadioButtonList ID="rblChnlStatus" runat="server" AutoPostBack="true" CellPadding="2" CellSpacing="2" OnSelectedIndexChanged="rblChnlStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True"  Text="&amp;nbspAll&nbsp;&nbsp;&nbsp;" Value="All" />
                                                            <asp:ListItem Text="&amp;nbspActive&nbsp;" Value="Act" />
                                                            <asp:ListItem Text="&amp;nbspInactive&nbsp;" Value="Inact" />
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-sm-6" style="float: right; text-align: right;">
                                            <asp:TextBox ID="txtchnlsearch" runat="server" placeholder="search sub channel desc." Style="color: Gray; background: #e9f7ff; border-bottom: solid 1px #999; font-size: 16px; border-left: none; border-right: none; border-top: none;"></asp:TextBox>
                                            <asp:LinkButton ID="lnksearchmastergv" runat="server" CssClass="" OnClick="lnksearchmastergv_Click" Text="text">
                                            <%--<img style="width:21px;height:21px;" src="assets/img/Search_icon.png" />--%>
                                <img style="width:21px;height:21px;"  src="../../../assets/img/search-icon-blue.png" />
                                        </asp:LinkButton>
                                        </div>
                                    </div>
                        <br />
                                    <%--ADDED BY AJAY 24 MAY 2023 END--%>
 <input id="hdnselectedBizsrc" runat="server" type="hidden" />     <%--added by sanoj 20052023--%>
                                    <input id="hdnChnCls" runat="server" type="hidden" />     <%--added by sanoj 20052023--%>
                        <asp:GridView AllowSorting="True" ID="Gv_ChannelDetails" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="45" AllowPaging="true" CellPadding="1"
                            OnSorting="Gv_ChannelDetails_Sorting" 
                            OnRowDataBound="Gv_ChannelDetails_RowDataBound">
                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                            <Columns>
                                <asp:TemplateField HeaderText="Channel Code" SortExpression="BizSrc">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblBizSrc" Text='<%# Eval("BizSrc") %>' CommandArgument='<%# Eval("BizSrc") %>'></asp:Label>
                                    </ItemTemplate>
                                 
                                     <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                              <%--  added bhau--%>
                                <asp:TemplateField HeaderText="Channel Name" SortExpression="ChannelDesc01">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblChnName" Text='<%# Eval("ChannelDesc01") %>' CommandArgument='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>

                                 <%--  end--%>
                                <asp:TemplateField HeaderText="SubClass" SortExpression="ChnCls">
                                    <ItemTemplate>
                                        <i class="fa fa-edit"></i>
                                        <asp:LinkButton ID="lbChnSubCls1" runat="server" Text='<%# Eval("ChnCls") %>' CommandArgument='<%# Eval("ChnCls")%>'
                                            OnClick="lbChnSubCls1_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubClass Desc" ControlStyle-Width="170" SortExpression="ChnClsDesc01">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblChnClsDesc1" Text='<%# Eval("ChnClsDesc01") %>'
                                            CommandArgument='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sort Order" SortExpression="SortOrder">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSortOrder1" Text='<%# Eval("SortOrder") %>' CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="ChnClsDesc01" HeaderText="Channel Class Desc" SortExpression="ChnClsDesc01">
                            <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Sort Order" DataField="SortOrder" SortExpression="SortOrder">
                        </asp:BoundField>--%>
                                <asp:TemplateField ShowHeader="True" HeaderText="Delete" Visible="false">
                                    <ItemTemplate>
                                        <div style="width: 100%;">
                                            <i class="fa fa-trash-o"></i>
                                            <asp:LinkButton ID="DeleteBtn" Text="Delete" CommandName="Delete" runat="server" />
                                        </div>
                                    </ItemTemplate>
                                   <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Human Hierarchy">
                                    <ItemTemplate>
                                        <div style="width: 100%;">
                                            <i class="fa fa-male"></i>
                                            <asp:LinkButton ID="lbHumanHierarchy" Text="Definition" Enabled="false" runat="server"
                                                OnClick="lbCompHumanHierarchy1_Click"></asp:LinkButton>&nbsp;&nbsp; <i class="fa fa-male">
                                                </i>
                                             <asp:linkbutton id="lnksubhmncmpact" text="Actual" runat="server" 
                                                        onclick="lnksubhmncmpact_click"></asp:linkbutton>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location Hierarchy">
                                    <ItemTemplate>
                                        <div style="width: 100%;">
                                            <i class="fa fa-map-marker"></i>
                                            <asp:LinkButton ID="lbLocationHierarchy" Text="Definition" runat="server" Enabled="false"
                                                OnClick="lbCompLocationHierarchy1_Click"></asp:LinkButton>&nbsp;&nbsp; <i class="fa fa-map-marker">
                                                </i>
                                            <%--    <asp:LinkButton ID="lnkSubLocCmpAct" Text="Actual" runat="server" 
                                                        onclick="lnkSubLocCmpAct_Click"></asp:LinkButton>--%>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ccsalignCenter" />
                                </asp:TemplateField>
                                 <%--ADDED BY AJAY 23 MAY 2023 START--%>
                                            <asp:TemplateField HeaderText="Move Channel" ItemStyle-Width="20%">
                                                <ItemTemplate>
                                                    <div style="width: 100%;">
                                                        <asp:LinkButton ID="btnchnlmove" runat="server" OnClick="btnchnlmove_Click" Text="MOVE TO">

                                                        </asp:LinkButton>
                                                        &nbsp;&nbsp;
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="pad" Font-Bold="False" HorizontalAlign="Center" />
                                                <ItemStyle CssClass="ccsalignCenter" />
                                            </asp:TemplateField>

                                 <asp:TemplateField ItemStyle-Width="20%" HeaderText="Cease SubChannel">
                                            <ItemTemplate>
                                                      <asp:LinkButton ID="lnkbtnSubchnlCease"  runat="server" OnClick="lnkbtnSubchnlCease_Click"
                                                                     > <i aria-hidden="true" class="glyphicon glyphicon-trash" style="color:red;"></i>
                                                                    </asp:LinkButton>
                                         
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" CssClass="pad" Font-Bold="False"></ItemStyle>
                                            <ItemStyle CssClass="ccsalignCenter" />
                                        </asp:TemplateField>
                                            <%--ADDED BY AJAY 23 MAY 2023 END--%>
                            </Columns>
                        </asp:GridView>
                        <div id="divPage" visible="true" runat="server">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtPage1" Style="width: 40px; border-style: solid;
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
                        <br />
                        <div class="row">
                            <div class="col-sm-12" align="center">
                                <div class="col-sm-12" align="center">
                                    <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-success" CausesValidation="false" OnClick="btnAddNew_Click"
                                        TabIndex="43" Text="ADD NEW">
                                 <span class="glyphicon glyphicon-plus" style='color:White;'> </span> Add New
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>                
                <br />
                <div id="div3" visible="false" runat="server" style="width: 98%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-search"></i>
                                <asp:Label ID="Label1" Text="Partner SubClass Setup" runat="server" Style="padding-left: 5px;" />
                                <span style="padding-left: 400px;"></span>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <asp:LinkButton Text="View Old Hierarchy" ID="LinkButton1" Font-Italic="true" Visible="false"
                                    Font-Size="Smaller" ForeColor="Yellow" OnClick="btnOldHier_Click" runat="server" />
                                <img id="Img2" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtls('divPartner','Img2','#Img2');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divPartner" runat="server" style="width: 100%;">
                        <div id="Div7" runat="server" style="width: 100%; padding: 10px; border: none; margin: 0px 0 !important;"
                            class="table-scrollable">
                            <asp:GridView ID="gvPartner" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                PageSize="10" AllowPaging="True" Width="100%">
                                <HeaderStyle ForeColor="Black" />
                                <RowStyle />
                                <PagerStyle CssClass="disablepage" />
                                <Columns>
                                    <%-- <asp:BoundField DataField="BizSrc" HeaderText="Channel Code" SortExpression="BizSrc">
                        </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Partner Code">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblBizSrc" Text='<%# Eval("BizSrc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Partner Name">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCompBizSrc" Text='<%# Eval("ChannelDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubClass">
                                        <ItemTemplate>
                                            <i class="fa fa-edit"></i>
                                            <%-- <asp:LinkButton ID="lbChnSubPtr" runat="server" Text='<%# Eval("ChnCls") %>' OnClick="lbChnSubPtr_Click"></asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubClass Desc" ControlStyle-Width="170">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblChnClsDesc1" Text='<%# Eval("ChnClsDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="170px"></ControlStyle>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort Order">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSortOrder1" Text='<%# Eval("SortOrder") %>' CommandArgument='<%# Eval("SortOrder") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="True" HeaderText="Delete">
                                        <ItemTemplate>
                                            <div style="width: 100%;">
                                                <i class="fa fa-trash-o"></i>
                                                <asp:LinkButton ID="DeleteBtn" Text="Delete" runat="server" />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Human Hierarchy">
                                        <ItemTemplate>
                                            <div style="width: 100%;">
                                                <i class="fa fa-male"></i>
                                                <%-- <asp:LinkButton ID="lbHumanHierarchyPtr" Text="Definition" runat="server" OnClick="lbHumanHierarchyPtr_Click"></asp:LinkButton>&nbsp;&nbsp;--%>
                                                <i class="fa fa-male"></i>
                                                <%--  <asp:LinkButton ID="lnkSubHmnPtrAct" Text="Actual" runat="server" 
                                                        onclick="lnkSubHmnPtrAct_Click"></asp:LinkButton>--%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location Hierarchy">
                                        <ItemTemplate>
                                            <div style="width: 100%;">
                                                <i class="fa fa-map-marker"></i>
                                                <%--<asp:LinkButton ID="lbLocationHierarchyPtr" Text="Definition" runat="server"
                                                        OnClick="lbLocationHierarchyPtr_Click"></asp:LinkButton>&nbsp;&nbsp;--%>
                                                <i class="fa fa-map-marker"></i>
                                                <%-- <asp:LinkButton ID="lnkSubLocPtrAct" Text="Actual" runat="server" 
                                                        onclick="lnkSubLocPtrAct_Click"></asp:LinkButton>--%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div id="div6" visible="true" runat="server" class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:Button ID="btnnext2" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" />
                                            <asp:TextBox runat="server" ID="txtPages" Style="width: 40px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnprevious2" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                        <table class="form-actions fluid" style="width: 100%;">
                            <tr>
                                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                    <asp:Button ID="btnNewPtnr" runat="server" CssClass="btn blue" TabIndex="43" Text="ADD NEW"
                                        Width="100px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
  
   <%-- <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                Style="display: none;" BorderWidth="2px" class="modalpopupmesg" Width="400px"
                Height="250px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
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
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" CssClass="standardbutton" /></center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content" >
                <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-verify" data-dismiss="modal"  style='margin-top: -6px;border-radius: 15px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK
                    </button>
                </div>
            </div>
        </div>
    </div>

    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate> --%>
            <asp:Panel ID="pnlVersion" runat="server" BorderColor="ActiveBorder" BackColor="White"
                Style="display: none;" BorderStyle="Solid" BorderWidth="2px" Width="700px" Height="370px">
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
            </asp:Panel>
       <%-- </ContentTemplate>--%>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnclose" />
        </Triggers>
   <%-- </asp:UpdatePanel>--%>
    <asp:Label ID="lbl_popup1" runat="server"></asp:Label>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup1" runat="server" TargetControlID="lbl_popup1"
        BehaviorID="mdlpopup1" PopupControlID="pnlVersion" DropShadow="true">
    </ajaxToolkit:ModalPopupExtender>


            <div class="modal" id="myModalRaise" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true" style="padding-top: 0px;">
                <div class="modal-dialog" style="padding-top: 0px; margin-top: 2px; width: 95%;">
                    <div class="modal-content" style=" width: 260%; margin-left: -408px;">
<%--                        <div class="modal-header" style="margin-top: -10px; margin-bottom: -20px; padding-bottom: 6px ! important;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title" id="myModalLabel">CKYC Related Person Details</h4>
                        </div>--%>
                        <div class="modal-body">
                            <iframe id="iframeCFR" src="" scrolling="no" width="100%" height="505px" frameborder="0"  allowtransparency="true"></iframe>
                        </div>
                        <div class="modal-footer">
<%--                            <div style="text-align: center;">
                                <asp:LinkButton ID="lnkRaise" TabIndex="43" runat="server" CssClass="btn-animated bg-horrible"
                                    data-dismiss="modal" aria-hidden="true">
                                    <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                </asp:LinkButton>
                            </div>--%>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>

               <%--MODAL POPUP   FOR MOVE TO CHANNEL START--%>
            <div class="modal" id="Mdlmovetto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top: -2px; margin-bottom: -31px">
                <div class="modal-dialog" style="padding-top: 0px; margin-top: 2px; width: 25%; margin-right: 35px">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-1">
                                </div>
                                <div class="col-sm-10" style="text-align: left">
                                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
                                    <asp:Label ID="lblmovetoano" runat="server" Text="Move to another"></asp:Label>
                                    <asp:RadioButtonList ID="rdmoveto" runat="server" CellPadding="5" OnSelectedIndexChanged="rdmoveto_SelectedIndexChanged" AutoPostBack="true"
                                        CellSpacing="5" RepeatDirection="Horizontal"
                                        TabIndex="33">
                                        <asp:ListItem Value="0" Text=" &nbsp;Channel&nbsp;&nbsp;" Selected="False"></asp:ListItem>
                                        <asp:ListItem Value="1" Text=" &nbsp;Sub Channel" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
         </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rdmoveto" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>

                            <br />
                            <div class="row" style="text-align: left">
                                <div class="col-sm-1">
                                </div>
                                <div class="col-sm-10">
                                    <asp:UpdatePanel ID="MyUpdatePanel" runat="server">
    <ContentTemplate>
        <asp:Label ID="lblmovechnl" Text="Channel Name" runat="server"></asp:Label>
        <asp:DropDownList ID="ddlmovechnl" runat="server" TabIndex="2" CssClass="form-control" OnSelectedIndexChanged="ddlmovechnl_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
        </asp:DropDownList>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlmovechnl" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
                                 
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>

                            <br />
                            <div class="row" style="text-align: left">
                                <div class="col-sm-1">
                                </div>
                                <div class="col-sm-10">
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
                                    <asp:Label ID="Label2" Text="Sub Class" runat="server"></asp:Label>

                                    <asp:DropDownList ID="ddlChnnlClass" runat="server" TabIndex="3" CssClass="form-control" Enabled="false">
                                    </asp:DropDownList>
         </ContentTemplate>
                                         </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-sm-1">
                                </div>
                                <div class="col-sm-10" style="text-align: left">
                                    <asp:Label ID="lbleffdate" runat="server" Height="22px" Width="259px" Style="padding-top: 7px;">Effective Date
  <span  style="color: red">*</span>
                                    </asp:Label>
                                    <asp:TextBox ID="txteffdate" runat="server" CssClass="form-control"></asp:TextBox>


                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="row" style="text-align: center">
                                <asp:LinkButton ID="btnmovechnl" runat="server" CssClass="btn btn-sample" TabIndex="216"
                                    OnClick="btnmovechnl_Click" OnClientClick="return getvalid();">
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> MOVE CHANNEL
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" OnClientClick="closedMoveto();"
                                    CausesValidation="False" TabIndex="220">
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> CANCEL
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                <%--MODAL POPUP   FOR CEASE SUBCHANNEL START--%>
                        <div class="modal" id="MdlCeaseSubChnl" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top: -2px; margin-bottom: -31px;">
                <div class="modal-dialog" style="padding-top: 0px;width:1200px;margin-top:2px;">
                    <div class="modal-content">
                        <div class="modal-body">
                            <%--//Unit TYPE GRIDVIEW START--%>
                           <div  id="ImpactedunttypeCount" style="width: 80%;margin: 0 auto;">
        <div id="trtitle" runat="server" class="panel-heading"
            >

            </div>
                        </div>
                        
                            <div class="row" id="trDetails" runat="server">
                <div class="col-sm-5" style="text-align: left;float:left;margin-top:10px;;margin-left:18px">
                    <asp:Label ID="lblprospectsearch" runat="server" Text="UNITS THAT CAN BE IMPACTED" Style="font-size: 19px;"></asp:Label>
                </div>
                <div class="col-sm-2" style="float:right; margin-top:10px;">
                    <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div2','ctl00_ContentPlaceHolder1_Img1');return false;"></span>
                </div>
                <div style="clear:both;">

                </div>
            </div>
        
                          <div id="div2" runat="server" style="width: 96%; height: 40%; padding: 10px;" class="panel-body">
           
            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" CssClass="standardlabel"
                Visible="false" />


            <asp:UpdatePanel ID="UPDErrMsg" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblErrMsg" runat="server" CssClass="footable" Visible="False"></asp:Label>
                    <div class="row" id="trAgentTypes" runat="server" style="margin-left: 19px; width: 97%; overflow: auto;">
                        <asp:GridView AllowSorting="True" ID="gv" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                            
                            <Columns>

                                 <asp:BoundField DataField="memtypeNew" HeaderText="Channel-Sub Channel-Unit Type" SortExpression="memtypeNew"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle CssClass="cssalingleft" />
                                    <HeaderStyle CssClass="cssalingleft" />
                                 </asp:BoundField>
                                
                              <%--  <asp:BoundField HeaderText="Channel" DataField="channel" Visible="false" SortExpression="BizSrc" ItemStyle-CssClass="ccsalignCenter" HeaderStyle-CssClass="ccsalignCenter"
                                    >
                                     <HeaderStyle CssClass="cssalingleft" />
                                     <ItemStyle CssClass="cssalingleft" />
                                   
                                </asp:BoundField>
                                <asp:BoundField DataField="subchannel" HeaderText="Sub Channel" SortExpression="ChnCls" Visible="false"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="cssalingleft" />
                                     <ItemStyle CssClass="cssalingleft" />
                                </asp:BoundField>--%>

                                <asp:BoundField HeaderText="In-force" DataField="Active" SortExpression="Active"
                                    HeaderStyle-HorizontalAlign="Center" >
                                    <HeaderStyle CssClass="ccsalignCenter" />
                                     <ItemStyle CssClass="ccsalignCenter" />
                                     </asp:BoundField>
                                <asp:BoundField HeaderText="Terminated" DataField="inactive" SortExpression="InActive"
                                    HeaderStyle-HorizontalAlign="Center" >
                                    <HeaderStyle CssClass="ccsalignCenter" />
                                     <ItemStyle CssClass="ccsalignCenter" />
                                     </asp:BoundField>
                                 <%--<asp:BoundField DataField="Impacted" HeaderText="Impacted" SortExpression="Position"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                 <asp:BoundField DataField="notImpacted" HeaderText="Not impacted" SortExpression="Position"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>--%>
                                  
                                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Position"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="ccsalignCenter" />
                                     <ItemStyle CssClass="ccsalignCenter" />
                                     </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>

            <br />  

            <asp:UpdatePanel ID="UpdOk" runat="server" style="margin-left: 506px;margin: 0 auto;width: 19%;">
                <ContentTemplate>
                    
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
                       <%--//Unit TYPE GRIDVIEW END--%>

                             <%--//Unit TYPE GRIDVIEW START--%>
                            <%--MEMBER TYPE GRIDVIEW START--%>
                               <div  id="ImpactedMemTypeCount" style="width: 80%;margin: 0 auto;">
        <div id="Div8" runat="server" class="panel-heading"
           >

            </div>

                            </div>
                           
                                 <div class="row" id="Div9" runat="server">
                <div class="col-sm-5" style="text-align: left;float:left;margin-top:10px;margin-left:18px">
                    <asp:Label ID="Label5" runat="server" Text="MEMBERS THAT CAN BE IMPACTED" Style="font-size: 19px;"></asp:Label>
                </div>
                <div class="col-sm-2" style="float:right; margin-top:10px;">
                    <span id="Img11" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div10','ctl00_ContentPlaceHolder1_Img11');return false;"></span>
                </div>
                <div style="clear:both;">

                </div>
            </div>
        
                                <div id="div10" runat="server" style="width: 96%; height: 40%; padding: 10px;" class="panel-body">
           
            <asp:Label ID="Label6" runat="server" ForeColor="Red" CssClass="standardlabel"
                Visible="false" />


            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label7" runat="server" CssClass="footable" Visible="False"></asp:Label>
                    <div class="row" id="Div11" runat="server" style="margin-left: 19px; width: 97%; overflow: auto;">
                        <asp:GridView AllowSorting="True" ID="gvmem" runat="server" CssClass="footable"
                            AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                            <FooterStyle CssClass="GridViewFooter" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                            
                            <Columns>

                                 <asp:BoundField DataField="memtypeNew" HeaderText="Channel-Sub Channel-Member Type" SortExpression="memtypeNew"
                                    HeaderStyle-CssClass="ccsalignCenter" ItemStyle-CssClass="ccsalignCenter" >
                                      <HeaderStyle CssClass="cssalingleft" />
                                     <ItemStyle CssClass="cssalingleft" />
                                 </asp:BoundField>
                                
                                <asp:BoundField HeaderText="Channel" DataField="channel" SortExpression="BizSrc" Visible="false"
                                    HeaderStyle-CssClass="ccsalignCenter" ItemStyle-CssClass="ccsalignCenter">
                                     <HeaderStyle CssClass="cssalingleft" />
                                     <ItemStyle CssClass="cssalingleft" />
                                </asp:BoundField>
                                <asp:BoundField DataField="subchannel" HeaderText="Sub Channel" SortExpression="ChnCls" Visible="false"
                                    HeaderStyle-HorizontalAlign="Center">
                                     <HeaderStyle CssClass="cssalingleft" />
                                     <ItemStyle CssClass="cssalingleft" />
                                  

                                </asp:BoundField>

                                <asp:BoundField HeaderText="In-force" DataField="Active" SortExpression="Active"
                                    HeaderStyle-HorizontalAlign="Center" >
                                     <HeaderStyle CssClass="ccsalignCenter" />
                                     <ItemStyle CssClass="ccsalignCenter" />
                                     </asp:BoundField>
                                <asp:BoundField HeaderText="Terminated" DataField="inactive" SortExpression="InActive"
                                    HeaderStyle-HorizontalAlign="Center" >
                                     <HeaderStyle CssClass="ccsalignCenter" />
                                     <ItemStyle CssClass="ccsalignCenter" />
                                     </asp:BoundField>
                                 <%--<asp:BoundField DataField="Impacted" HeaderText="Impacted" SortExpression="Position"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                 <asp:BoundField DataField="notImpacted" HeaderText="Not impacted" SortExpression="Position"
                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>--%>
                                  
                                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Position"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="ccsalignCenter" />
                                     <ItemStyle CssClass="ccsalignCenter" />
                                     </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>

            <br />  

            <asp:UpdatePanel ID="UpdatePanel5" runat="server" style="margin-left: 506px;margin: 0 auto;width: 19%;">
                <ContentTemplate>
                    
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
                            <%--MEMBER TYPE GRIDVIEW END--%>
                            <div class="row" style="margin-left:35px">
                                <div class="col-sm-4" style="text-align:left">
                                    <asp:Label ID="Label8" runat="server" Text="Effective Date"></asp:Label>
                                    <asp:TextBox ID="txt1effdate" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer" style="text-align:center;border-top:none;">
                                <asp:LinkButton ID="btnupdate" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnupdate_Click">
                                          <span class="glyphicon glyphicon-check BtnGlyphicon"></span> Proceed </asp:LinkButton>
                          <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="closedForCease();return false;" Text="Cancel" CssClass="btn btn-danger">
                                          <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <%--MODAL POPUP   FOR MOVE TO CHANNEL END--%>


                    </div>

            </ContentTemplate>
         </asp:UpdatePanel>
        <%--Modal Popup For Hirerachy--%>
                        <div class="modal" id="myModalRaise1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top: -2px; margin-bottom: -31px">

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
