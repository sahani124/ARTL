<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="PopMstDBFunc.aspx.cs"
    Inherits="Application_ISys_Saim_Masters_PopMstDBFunc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">

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

        function doCancel(rultyp, flag) {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        function doOk() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnBindGrid").click();
        }

        function ShowReqDtl1(divName, btnName) {

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
                ////ShowError(err.description);
            }
        }
    </script>
    <style type="text/css">
        .new_text_new
        {
            color: #066de7;
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
        .disablepage
        {
            display: none;
        }
        
        .box
        {
            background-color: #efefef;
            padding-left: 5px;
        }
    </style>
    <center>
        <div id="divtrghdrcollapse" runat="server" style="width: 95%;" class="panel panel-success">
            <div id="div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divtrg','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                        <asp:Label ID="lblhdr" Text="DBFunction Setup" runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <img id="myImg" src="../../../../assets/img/portlet-expand-icon-white.png" alt=""
                            onclick="ShowReqDtl('divtrg','myImg','#myImg');" />
                    </div>
                </div>
            </div>
            <div id="divtrg" runat="server" style="width: 100%; white-space: nowrap; text-align: left;"
                class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCode" Text="Code" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="select2-container form-control"
                            placeholder="Code"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblName" Text="Name" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtName" runat="server" CssClass="select2-container form-control"
                            placeholder="Name"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblDesc1" Text="Function Description 1" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDesc1" runat="server" CssClass="select2-container form-control"
                            placeholder="Function Description 1"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblDesc2" Text="Function Description 2" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDesc2" runat="server" CssClass="select2-container form-control"
                            placeholder="Function Description 2"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblDesc3" Text="Function Description 3" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtDesc3" runat="server" CssClass="select2-container form-control"
                            placeholder="Function Description 3"></asp:TextBox>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblIsActive" Text="Is Active" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="ddlIsActive" runat="server" CssClass="select2-container form-control">
                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                            <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tblsvtrg" runat="server" class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary" Enabled="true"
                            OnClick="btnSave_Click">
                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-primary" Enabled="false"
                            OnClick="btnSave_Click">
                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Update
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCnclTrg" runat="server" CssClass="btn btn-primary" Enabled="true"
                            OnClientClick="doCancel();return false;">
                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </center>
</asp:Content>
