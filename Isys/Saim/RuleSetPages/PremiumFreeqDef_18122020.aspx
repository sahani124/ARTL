<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PremiumFreeqDef.aspx.cs" Inherits="Application_ISys_Saim_RuleSetPages_PremiumFreeqDef" %>

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
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
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
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space:nowrap;
        }
        .style1
        {
            width: 100%;
        }
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

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("Button3") != null) {
                ////alert("btncmp");
                // window.parent.document.getElementById("btncmp").click();

                window.parent.document.getElementById("Button3").click();
                ////alert("btncmp2564654");
            }
            else {

                ///alert("no btncmp");
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

            window.parent.document.getElementById("Button3").click();
        }
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


        function validate() {
            debugger;
            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strcontent + "ddlfreguency") != null) {
                if (document.getElementById(strcontent + "ddlfreguency").value == "") {
                    alert("Please Select Frequency Type.");
                    document.getElementById(strcontent + "ddlfreguency").focus();
                    return false;
                }

            }

            if (document.getElementById(strcontent + "ddltype") != null) {
                if (document.getElementById(strcontent + "ddltype").value == "") {
                    alert("Please Select Type.");
                    document.getElementById(strcontent + "ddltype").focus();
                    return false;
                }
            }

            var TxtWeg = document.getElementById('<%= TxtWeg.ClientID %>');
            if (!(TxtWeg.disabled)) {

                if (document.getElementById(strcontent + "TxtWeg") != null) {
                    if (document.getElementById(strcontent + "TxtWeg").value != "") {
                        var myregex = /^[0-9][0-9]{0,3}$|^[0-9][0-9]{0,3}[\.][0-9]$/;
                        if (!myregex.test($('#TxtWeg').val()) || $('#TxtWeg').val() == "0") {
                            if (document.getElementById(strcontent + "TxtWeg").value > 0) {
                                return true;
                            }
                            alert("Please Enter Correct value");
                            return false;
                        }
                        return false;

                    }
                    else {
                        alert("Please  Enter Weightage.");
                        document.getElementById(strcontent + "TxtWeg").focus();
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel ">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="Label6" Text="Premium Frequency Definition" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Text="Frequency Type" CssClass="control-label"></asp:Label>
                                <asp:Label ID="lbldfretype1" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlfreguency" runat="server" AutoPostBack="true"
                                    CssClass="select2-container form-control" TabIndex="1">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" runat="server" Text="Consider" CssClass="control-label"></asp:Label>
                                <asp:Label ID="Label5" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:RadioButtonList ID="rblSplit" runat="server" AutoPostBack="true"
                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSplit_SelectedIndexChanged">
                                    <asp:ListItem Text="Include  &nbsp; " Value="IN"></asp:ListItem>
                                    <asp:ListItem Text="Exclude  &nbsp; " Value="EX"></asp:ListItem>
                                    <asp:ListItem Text="All  &nbsp; " Value="AR"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label3" runat="server" Text="Type" CssClass="control-label"></asp:Label>
                                <asp:Label ID="Label7" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="true" CssClass="select2-container form-control" 
                                    TabIndex="3">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label4" runat="server" Text="Weightage" CssClass="control-label"></asp:Label>
                                <asp:Label ID="Label8" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="TxtWeg" runat="server" CssClass="form-control" TabIndex="4" style="text-align:right"
                                    MaxLength="10">100</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TxtWeg">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <br />
                        <div style="width: 100%;text-align:left;padding:5px;">
                            <asp:Label ID="lbl1" Text="Note- <b>Consider</b>* -<br/>Include- Only Include the given frequency with the specified std. defn. rule"
                                ForeColor="Red" runat="server" />
                            <br />
                            <asp:Label ID="lbl2" Text="Exclude- Exclude the given frequency"
                                ForeColor="Red" runat="server" />
                            <br />
                            <asp:Label ID="lbl3" Text="All- Include all the frequency with the default std. defn. rule and also the mentioned frequency std. defn. rule"
                                runat="server" ForeColor="Red" />
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <center>
                                    <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-sample" Style="text-align: center"
                                        OnClientClick="return validate();" OnClick="Button1_Click">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample" OnClientClick="doCancel();return false;">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
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
