<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DateRelatedDef.aspx.cs" Inherits="DateRelatedDef" %>
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="DateRelatedDef.aspx.cs" Inherits="DateRelatedDef" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../KMI Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
       <style type="text/css">
        .new_text_new
        {
            color: #066de7;
        }
        .form-submit-button
        {
        }
        .disablepage
        {
            display: none;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        .align
        {
            text-align: left;
        }
        .rowalign
        {
            margin-bottom: 15px;
        }
        </style>
   
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#<%= TxtEffFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= TxtEffTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });

        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
            }
            else {

                $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
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
            catch (err) {
                ShowError(err.description);
            }
        }



        function doOk(rultyp, flag) {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            window.parent.document.getElementById("Button11").click();
            /////window.parent.document.getElementById("Button7").click();
        }


        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("Button11") != null) {
                window.parent.document.getElementById("Button11").click();
            }
            else {
            }
//            else if (window.parent.document.getElementById("Button7") != null) {
//                window.parent.document.getElementById("Button7").click();
//            }
            
        }



        function validate() {
            debugger;
            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strcontent + "ddlDateType") != null) {
                if (document.getElementById(strcontent + "ddlDateType").value == "") {
                    alert("Please Select Date Type.");
                    document.getElementById(strcontent + "ddlDateType").focus();
                    return false;
                }
            }
            if (document.getElementById(strcontent + "TxtRemark") != null) {
                if (document.getElementById(strcontent + "TxtRemark").value == "") {
                    alert("Please Enter Remark.");
                    document.getElementById(strcontent + "TxtRemark").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "TxtEffFrom") != null) {
                if (document.getElementById(strcontent + "TxtEffFrom").value == "") {
                    alert("Please Select Date Effective From.");
                    document.getElementById(strcontent + "TxtEffFrom").focus();
                    return false;
                }
            }


            if (document.getElementById(strcontent + "TxtEffTo") != null) {
                if (document.getElementById(strcontent + "TxtEffTo").value == "") {
                    alert("Please Select Date Effective To.");
                    document.getElementById(strcontent + "TxtEffTo").focus();
                    return false;
                }
            }
        }


    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <center>
                <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                                <asp:Label ID="Label1" Text="Date Related Definitions" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
<%--                        <div id="trBusi" runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblBusiType" Text="Type of Business" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label3" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlBusiType" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlBusiType_SelectedIndexChanged">
                                            <asp:ListItem Text="--SELECT--" Value=""></asp:ListItem>
                                            <asp:ListItem Text="NEW BUSINESS" Value="1001"></asp:ListItem>
                                            <asp:ListItem Text="TOP UP BUSINESS" Value="1002"></asp:ListItem>
                                            <asp:ListItem Text="RENEWAL BUSINESS" Value="1003"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>--%>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDateType" Text="Date Type" runat="server" CssClass="control-label" />
                                <asp:Label ID="lbldatetype1" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDateType" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlDateType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
<%--                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRemark" Text="Remark" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblRemark_1" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="TxtRemark" runat="server" CssClass="form-control" />
                            </div>--%>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtFrm" Text="Date Effective From" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblEffDtFrm_1" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtEffFrom" runat="server" CssClass="form-control" Enabled="true" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtTo" Text="Date Effective To" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblEffDtTo_1" Text="*" runat="server" ForeColor="red" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtEffTo" runat="server" CssClass="form-control" Enabled="true" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <center>
                                    <asp:LinkButton ID="SAVE" runat="server" OnClick="SAVE_Click" Style="text-align: center;
                                        margin-left: 0px" OnClientClick="return validate();" CssClass="btn btn-sample">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                        </asp:LinkButton>
                                    <asp:LinkButton ID="btnCncl" runat="server" OnClientClick="doCancel();return false;"
                                        CssClass="btn btn-sample">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel                
                                        </asp:LinkButton>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
