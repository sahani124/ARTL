<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="TestEnabling.aspx.cs"
    Inherits="Application_INSC_Recruit_TestEnabling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" type="text/css" />


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
    <script type="text/javascript">

        function ABCD(id) {
        }
        function AlertMsgs(msgs) {
            alert(msgs);
        }
        function popup() {
            debugger;
            $("#myModal").modal();
        }
        function modalpopup() {
            debugger;
            $("#mypopup").modal();
        }
        //    function PopupModal() {
        //        //debugger;
        //        var modal = $find('mdlcfrdtlsID');

        //        if (modal) {
        //            if (modal.show) {
        //                modal.show();
        //            }
        //            else {
        //                alert("nope!");
        //            }
        //        }
        //        else {
        //            throw modal;
        //        }
        //    }

        function StartProgressBar() {
            //        var myExtender = $find('ProgressBarModalPopupExtender');
            //        myExtender.show();
            //        //document.getElementById("btnSubmit").click();
            //        return true;
        }
        //        function ShowReqDtl(divName, btnName) {
        //            debugger;

        //            var objnewdiv = document.getElementById(divName);
        //            var objnewbtn = document.getElementById(btnName);

        //            if (objnewdiv.style.display == "block") {
        //                objnewdiv.style.display = "none";
        //                objnewbtn.value = '+'
        //            }
        //            else {
        //                objnewdiv.style.display = "block";
        //                objnewbtn.value = '-'
        //            }
        //        }


        //function ShowReqDtl(divName, btnName) {
        //    //debugger;
        //    var objnewdiv = document.getElementById(divName);
        //    var objnewbtn = document.getElementById(btnName);

        //    if (objnewdiv.style.display == "block") {
        //        objnewdiv.style.display = "none";
        //       // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
        //    }
        //    else {
        //        objnewdiv.style.display = "block";
        //       // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
        //    }
        //}

        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
                else {
                    objnewdiv.style.display = "block";

                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
    </script>
    <style type="text/css">
        .control-labels{
            font-size:16px !important;
        }
        .footable > tbody > tr > td{
            text-align:center !important;
        }
        
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
        }*/
        body .modal {
            width: 100%;
            height: 100%;
            padding: 2%;
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

        .clsCenter {
            text-align: center !important;
        }
    </style>

    <asp:ScriptManager ID="SM1" runat="server">
    </asp:ScriptManager>
    <br />
    <center>
        <div class="card PanelInsideTab">
            <%--<div class="panel">--%>
            <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnWfParam');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lbltitle" runat="server" CssClass="control-label" Font-Size="19px">Download</asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <br />
            <br />

            <div id="divSearch" runat="server" style="display: block; margin-bottom: 66px;" class="card PanelInsideTab">
                <div class="row" style="padding-bottom: 6px ! important; text-align: left;">
                    <asp:Label ID="lblUpload" runat="server" CssClass="control-labels" Text="Document Type"></asp:Label>

                </div>
                <div class="row" style="padding-bottom: 6px ! important; text-align: left;">
                    <div class="col-md-6" style="text-align: left">
                        <asp:DropDownList ID="ddlUpload" DataTextField="ParamDesc" DataValueField="ParamValue" Font-Size="15px"
                            runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlUpload_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3" style="text-align: left">
                        <asp:LinkButton ID="btndwnld" runat="server" CssClass="btn btn-success" OnClick="btndwnld_Click" Style="height: 33px;">
                         <span class="glyphicon glyphicon-search BtnGlyphicon"></span>  SEARCH</asp:LinkButton>
                    </div>
                </div>
                 <div class="row" style="padding-bottom: 6px ! important; text-align: left;margin-top:15px;" id="trATIDoc" runat="server"
                    visible="false">
                    <div class="col-md-6" style="text-align: left">
                        <asp:Label ID="lblTrnInst" runat="server" CssClass="control-labels" Text="Traning Institute"></asp:Label><span
                            style="color: #ff0000">*</span>
                    </div>


                </div>
                <div class="row" style="padding-bottom: 6px ! important;">

                    <div class="col-md-6" style="text-align: left">

                        <asp:DropDownList ID="ddlTrnInst" DataTextField="ParamDesc" DataValueField="ParamValue" Visible="false" Font-Size="15px"
                            runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlTrnInst_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>


                    <div class="col-md-3" style="text-align: left">
                        <asp:LinkButton ID="lnkView" runat="server" Visible="false" CssClass="btn btn-success" Style="height: 34px; width: 99px;"
                            OnClick="lnkView_Click">
                            <span id="spnView" runat="server" visible="false" class="glyphicon glyphicon-search BtnGlyphicon"></span> VIEW
                        </asp:LinkButton>
                    </div>
                </div>
               

                <div class="row" style="padding-bottom: 6px ! important;">
                    <div class="col-md-12" style="text-align: center">
                        <%--  <asp:LinkButton ID="btndwnld" runat="server" CssClass="btn btn-primary" OnClick="btndwnld_Click">
                         <span class="glyphicon glyphicon-search BtnGlyphicon"></span> Search</asp:LinkButton>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="red" Visible="False" Width="310px"></asp:Label>
                    </div>
                </div>
                <div class="row" id="divSearchDetails" runat="server" style="display: none">
                    <div class="card PanelInsideTab_body" style="width: auto;">
                        <div class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trdg','btnDeptMstGrd');return false;">
                            <div class="row" id="trdgHdr" runat="server" visible="false">
                                <div class="col-sm-10" style="text-align: left">
                                    <asp:Label ID="lblSearch" runat="server" class="subheader"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                    <span id="btnDeptMstGrd" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                                </div>
                            </div>
                        </div>
                        <div id="trdg" runat="server" visible="false">
                            <div>
                                <div style="overflow-x: scroll;">
                                    <asp:GridView ID="dgDownload" runat="server" AutoGenerateColumns="true" CssClass="footable" CellPadding="10"
                                        Style="border-bottom-color: black; margin-top: 16px;"
                                        PageSize="10" AllowSorting="False" AllowPaging="True" OnPageIndexChanging="dgDownload_PageIndexChanging" OnRowDataBound="dgDownload_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />

                                    </asp:GridView>
                                </div>
                                <br />
                                <div id="lblPageInfo" runat="server">
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 34px;"
                                                        OnClick="btnprevious_Click" /><%--OnClick="btnprevious_Click"--%>
                                                    <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 40px; border-style: solid; border-width: 1px; border-color: Gray; height: 34px; float: left; margin: 0; text-align: center;" CssClass="form-submit-button" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 34px;"
                                                        Width="40px" OnClick="btnnext_Click" /><%--OnClick="btnnext_Click"--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <div class="row">
                                    <div width="100%" align="center">
                                        <asp:CheckBox ID="chkfiledwnld" CellPadding="0" CellSpacing="0" RepeatLayout="Table" Style="margin-top: 24px; margin-bottom: 19px; font-size: 13px !important;"
                                            TextAlign="Right" runat="server" RepeatDirection="Horizontal" Width="100%"
                                            AutoPostBack="true" OnCheckedChanged="chkfiledwnld_CheckedChanged" Text="Confirm Successful File Download" />

                                    </div>
                                </div>
                                <asp:HiddenField ID="hdnEnbl" runat="server" />
                                <asp:HiddenField ID="hdncheck" runat="server" />
                                <div class="row">
                                    <div align="center">
                                        <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-success" OnClientClick="ABCD(this.id);"
                                            OnClick="btnExport_Click">
                         <span class="glyphicon glyphicon-download BtnGlyphicon"></span> DOWNLOAD</asp:LinkButton>
                                        <asp:LinkButton ID="btncnfrm" runat="server" CssClass="btn btn-success" OnClick="btncnfrm_Click">
                         <span class="glyphicon glyphicon-info-sign BtnGlyphicon"></span> CONFIRM</asp:LinkButton>
                                        <asp:LinkButton ID="btnfail" runat="server" CssClass="btn btn-clear" OnClick="btnFail_Click">
                         <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:red"></span> CANCEL</asp:LinkButton>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                        <div id="trdgDetails" runat="server" visible="false" style="display: none;">
                            <div class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trdgdtls','ctl00_ContentPlaceHolder1_Span1');return false;"
                                style="background-color: #EDF1cc !important;">
                                <div class="row" id="Div2" runat="server">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblTra" runat="server" Font-Bold="True" Font-Size="Small">Training Search Results</asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--  <div class="row">
                    <div width="100%" align="center">
                        <asp:CheckBox ID="chkfiledwnld" CellPadding="0" CellSpacing="0" RepeatLayout="Table"
                            TextAlign="Right" runat="server" RepeatDirection="Horizontal" Width="100%" CssClass="standardCheckBox"
                            AutoPostBack="true" OnCheckedChanged="chkfiledwnld_CheckedChanged"
                            Text="Confirm Successfull File Download"  font-size="120%"/>
                    </div>
                </div>
                <asp:HiddenField ID="hdnEnbl" runat="server" />
                <asp:HiddenField ID="hdncheck" runat="server" />
                <div class="row">
                    <div align="center">
                        <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-primary" OnClientClick="ABCD(this.id);"
                            OnClick="btnExport_Click">
                         <span class="glyphicon glyphicon-download BtnGlyphicon"></span> Download</asp:LinkButton>
                        <asp:LinkButton ID="btncnfrm" runat="server" CssClass="btn btn-primary" OnClick="btncnfrm_Click">
                         <span class="glyphicon glyphicon-info-sign BtnGlyphicon"></span> Confirm</asp:LinkButton>
                        <asp:LinkButton ID="btnfail" runat="server" CssClass="btn btn-danger" OnClick="btnFail_Click">
                         <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> Cancel</asp:LinkButton>
                    </div>
                </div>--%>
                <div id="btncan" runat="server" visible="false" style="display: none;" class="row">
                    <div align="center">
                        <asp:LinkButton ID="btnpopcancel" runat="server" CssClass="btn btn-clear">
                         <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:red;"></span> Cancel1</asp:LinkButton>
                    </div>
                </div>
            </div>
            <%-- </div>--%>
        </div>
        <div class="modal fade" id="myModal" role="dialog" style="text-align: center;">
            <!-- Modal content-->
            <asp:UpdatePanel ID="updctran" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left; background-color: #dff0d8;">

                            <asp:Label ID="Label3" Style="font-size: 19px; margin-left: 487px;" Text=" Training Search Results" runat="server"></asp:Label>

                            <button type="button" data-dismiss="modal">
                                <a><span class="glyphicon glyphicon-remove BtnGlyphicon" style="color: red"></span></a>
                            </button>
                        </div>
                        <div class="modal-body" style="text-align: center">
                            <div id="trdgdtls" runat="server" class="panel-body">
                                <div style="overflow-x: scroll;">
                                    <asp:GridView ID="dgDetails1" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                        Style="border-bottom-color: black;" PageSize="10" AllowSorting="False" AllowPaging="True">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Training Mode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTrnMode" runat="server" Text='<%# Bind("[Training Mode]") %>' Visible="true" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsCenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ATI Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblATILoc" runat="server" Text='<%# Bind("[ATI Loaction]") %>' Visible="true" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsCenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Accrediation No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccNo" runat="server" Text='<%# Bind("[Accrediation No]") %>' Visible="true" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsCenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Training Institute">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("[Training Institute]") %>'
                                                        Visible="true" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsCenter" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Count">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCount" runat="server" Text='<%# Bind("[Count]") %>' Visible="true" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsCenter" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </div>
                                <div id="Div3" runat="server" style="margin-top: 26px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnPreTran" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 34px;"
                                                        OnClick="btnprevioustr_Click" /><%--OnClick="btnprevious_Click"--%>
                                                    <asp:TextBox runat="server" ID="txtTran" Text="1" Style="width: 40px; border-style: solid; border-width: 1px; border-color: Gray; height: 34px; float: left; margin: 0; text-align: center;" CssClass="form-submit-button" ReadOnly="true" />
                                                    <asp:Button ID="btnNexttran" Text=">" CssClass="form-submit-button" runat="server"
                                                        Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; background-color: transparent; float: left; margin: 0; height: 34px;"
                                                        Width="40px"
                                                        OnClick="btnnexttr_Click" /><%--OnClick="btnnext_Click"--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </div>
                        </div>
                        <div class="row" id="Div4" runat="server">
                            <div class="col-sm-12" style="text-align: left">
                            </div>
                        </div>

                        <%--<div class="modal-footer" style="text-align: center">
                                
                            </div>--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="modal fade" id="mypopup" role="dialog">
            <div class="modal-dialog modal-sm">

                <!-- Modal content-->
                <div class="modal-content" style='width: 400px; height: 225px;'>

                    <asp:Label ID="Label1" Text="INFORMATION" runat="server" Style="font-weight: bold; margin-left: 7px; color: blue; font-size: 20px; margin-top: 20px;"></asp:Label>

                    <div class="modal-body" style="text-align: center; font-size: 16px;">
                        <asp:Label ID="lbl" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lbl2" runat="server" Style="color: red"></asp:Label>
                        <asp:Label ID="lbl3" runat="server"></asp:Label>
                    </div>

                    <button type="button" class="btn btn-success" data-dismiss="modal" style='margin-bottom: 36px; width: 69px; margin-left: 171px;'>
                        <span class="glyphicon glyphicon-ok-circle" style="color: white"></span>OK

                    </button>

                </div>

            </div>
        </div>

    </center>
    <asp:HiddenField ID="hdnBatchId" runat="server" />
    <asp:HiddenField ID="hdnModuleId" runat="server" />
    <%--added by sanoj --%>
    <asp:HiddenField ID="hdnDwnld" runat="server" />
    <asp:Panel runat="server" ID="pnlMdl" Width="500" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="500" height="300px" frameborder="0"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--<asp:Panel ID="pnl" runat="server" class="modalpopupmesg" BorderColor="ActiveBorder"
            BorderStyle="Solid" BorderWidth="2px" Width="400px" Height="220px" Visible="true">
            <table width="100%">
                <tr align="center">
                    <td class="test" width="100%" colspan="1" style="height: 32px">
                        INFORMATION
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 391px">
                        <br />
                        <center>
                            <asp:Label ID="lbl23" runat="server"></asp:Label><br />
                        </center>
                        <br />
                    </td>
                </tr>
            </table>
            <center>
                <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" />
            </center>
        </asp:Panel>--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
        <%--background-color: #C0C0C0;--%>
        <center>
            <img src="../../../../theme/iflow/animated_progress_bar.gif" />
            <br />
            <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
        </center>
    </asp:Panel>

</asp:Content>
