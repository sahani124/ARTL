<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="BancaBrocaSrch.aspx.cs" Inherits="Application_Isys_ChannelMgmt_BancaBrocaSrch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

    <style type="text/css">
        .Childgridview th {
            padding: 3px;
            height: 40px;
            background-color: #e65d6b !important;
            color: #FFFFFF;
            border-color: #e65d6b;
            text-align: center;
            font-family: VAG Rounded Std Light;
            font-size: 15px;
            white-space: nowrap;
        }

        ul#menu li a:active {
            background: white;
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

        fieldset {
            padding: .35em .625em .75em !important;
            margin: 1px 11px !important;
            border: 3px solid silver !important;
        }

        legend {
            display: block !important;
            width: 21% !important;
            padding: 0 !important;
            margin-bottom: 5px !important;
            font-size: 18px !important;
            line-height: inherit !important;
            color: #333 !important;
            border: 0 !important;
            border-bottom: 0px solid #e5e5e5 !important;
        }
    </style>

    <script type="text/javascript">

        function popup() {
            $("#myModal").modal();
        }

        $(document).ready(function () {
            $("th").click(function () {
                var columnIndex = $(this).index();
                var tdArray = $(this).closest("table").find("tr td:nth-child(" + (columnIndex + 1) + ")");
                tdArray.sort(function (p, n) {
                    var pData = $(p).text();
                    var nData = $(n).text();
                    return pData < nData ? -1 : 1;
                });
                tdArray.each(function () {
                    var row = $(this).parent();
                    $("#dgCntst").append(row);
                });
            });
        })
    </script>

    <script type="text/javascript">
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


        function ShowReqDtl1(divName, btnName) {
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }


        function funcall() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }

        function callsearch() {
            document.getElementById('<%= btnSearch.ClientID%>').click();
        }
        function callPageIndex()
        {
           
            document.getElementById('imgCLick').click();
        }

    </script>

    <script type="text/javascript">
        debugger;
        $("[src*=btnexp]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td colspan = '999' ><div id='abc'>" + $(this).next().html() + "</div></td></tr>")
            $(this).attr("src", "../../../images/btncol.png");

        });
        $("[src*=btncol]").live("click", function () {
            debugger;
            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });
    </script>

    <style type="text/css">
        .radio-group label {
            overflow: hidden;
        }

        .radio-group input {
            /* This is on purpose for accessibility. Using display: hidden is evil. This makes things keyboard friendly right out tha box! */
            height: 1px;
            width: 1px;
            position: absolute;
            top: -20px;
        }

        .radio-group .not-active {
            color: #3276b1;
            background-color: #fff;
        }
    </style>

    <asp:ScriptManager ID="SMHMonboarding" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="divHMhdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divhmhdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblhdr" Text="HM OnBoarding Search Criteria" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                         <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                          padding: 1px 10px ! important; font-size: 18px;"></span> 
                    </div>
                </div>
            </div>
            <div id="divhmhdr" runat="server" style="width: 96%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMemCode" Text="Member Code" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtMemCode" runat="server" CssClass="form-control" TabIndex="1"
                                    MaxLength="8" placeholder="Member Code" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTXMemCd" runat="server" FilterType="Numbers"
                                    TargetControlID="txtMemCode">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMemName" Text="Member Name" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtMemName" runat="server" CssClass="form-control" TabIndex="2"                 
                                                       placeholder="Member Name" MaxLength="40" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                    FilterMode="ValidChars" TargetControlID="txtMemName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblChn" Text="Channel Name" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChn" runat="server" AutoPostBack="true" CssClass="select2-container form-control" OnSelectedIndexChanged="ddlChn_SelectedIndexChanged"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblChnCls" Text="SubClass Name" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="true" CssClass="select2-container form-control"  OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblmemType" Text="Member Type" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMemtype" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                    <div class="col-sm-3">
                    </div>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample" OnClick="btnClear_Click">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" OnClick="btnCancel_Click"
                                    Visible="false">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                         <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </ContentTemplate>
                         </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
       </div>
        <br />
          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="trDgDetails" runat="server" style="width: 97%;" class="panel"  visible="false">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divHMsrch','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblHMSrch" Text="HM OnBoarding Search Results" style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                                        padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="trDetails" runat="server" style="width: 96%; padding: 10px;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" >
                            <ContentTemplate>
                                <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="10" AllowSorting="True" OnSorting="dgDetails_Sorting" AllowPaging="true" OnRowCommand="dgDetails_RowCommand"
                                    CssClass="footable" OnRowDataBound="dgDetails_RowDataBound" DataKeyNames="MemCode">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        
                                        <asp:TemplateField HeaderText="Member Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MemCode">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkMemCode" Text='<%# Bind("MemCode")%>' runat="server"></asp:LinkButton> 
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Agent Name" DataField="LegalName" SortExpression="LegalName" HeaderStyle-HorizontalAlign="Center" 
                                             HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Font-Bold="False" HorizontalAlign="Left" />
                                              <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField  HeaderText="Channel" DataField="BizSrc" SortExpression="BizSrc" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true"  ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Sub Class" DataField="ChnCls" SortExpression="ChnCls" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true"  ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                         <asp:TemplateField HeaderText="" SortExpression="MemCode">
                                                                <ItemTemplate>
                                                                    <div style="white-space: nowrap; width: 100%;">
                                                                        <span class="glyphicon glyphicon-pencil" style="color:black!important;"></span>
                                                                            

                                                                        <asp:LinkButton ID="lblRequest" runat="server" CommandArgument='<%# Eval("MemCode") %>'
                                                                            CommandName="ReqClick" Text='<%# Eval("Request") %>'></asp:LinkButton>
                                                                    </div>
                                                                   
                                                                </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="pagination" style="padding: 10px;">
                             <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
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
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
       <br />
       <asp:updatepanel runat="server">
           <contenttemplate>
               <div class="row" style="margin-top:12px;">
                   <div class="col-sm-12" align="center">
                     
                       <div id="divloader" runat="server" style="display:none;">
                           <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                       </div>
                   </div>
               </div>
            </contenttemplate>
        </asp:updatepanel>

        <asp:Panel runat="server" ID="pnlMdl" Width ="500" Height="428" display = "none" top="52" left= "529px">
            <iframe runat="server" id="ifrmMdlPopup" width="610px" height="539px"  frameborder="0" style="margin-top: -100px;margin-left: 107px;"
                display="none"></iframe>
             <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
        </asp:Panel>
        <asp:Label runat="server" ID="lbl1" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        X="260" Y="100" >
         </ajaxToolkit:ModalPopupExtender>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content" >
                    <div class="modal-header" style="text-align: center;">
                        <asp:Label ID="Label16" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
                    </div>
                    <div class="modal-body" style="text-align: center">
                      <asp:Label ID="lbl" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer" style="text-align: center">
                      <button type="button"  class="btn btn-sample"  data-dismiss="modal" style='margin-top: -6px;border-radius: 15px;'>
                         <span class="glyphicon glyphicon-ok  BtnGlyphicon" style='color: White;'> </span> OK

                         </button>
         
                    </div>
               </div>
        </div>
    </div>
   </center>
</asp:Content>

