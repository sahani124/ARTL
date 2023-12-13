<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="QualTrgStp_INC.aspx.cs" Inherits="Application_ISys_Saim_QualTrgStp_INC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        $(function () {
            $("#<%= txtEffFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtEffTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });

        function ShowReqDtl1(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }

        function chktrg(expval) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            var trgval = document.getElementById(strContent + "txtRskDesc").value;
            if (trgval < expval) {
                alert('Target From should be greater than or equal to');
                return false;
            }
            
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
        function funAddmaster(cmpcode, cntstcode, flag, ruletype) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ///$find("mdlViewBIDcmnt").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopCntstMst.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype
            + "&mdlpopup=mdlVwBID";
        }

        function doCancel(rultyp, flag) {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (rultyp == 'Q') {
                window.parent.document.getElementById("btnqualtrg").click();
            }
            else if (rultyp == 'R') {
                /////alert(rultyp);
                window.parent.document.getElementById("btnrwdtrg").click();
            }
            window.parent.$find('<%=Request.QueryString["flag"].ToString()%>') = flag;
        }

        function doOk(rultyp, flag) {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById('<%=Request.QueryString["flag"].ToString()%>').value = flag;
            //            alert(rultyp);
            //            alert(flag);
            if (rultyp == 'Q') {
                window.parent.document.getElementById("btnqualtrg").click();
                ///alert('akshay');
            }
            else if (rultyp == 'R') {
                window.parent.document.getElementById("btnrwdtrg").click();
                ///alert('akshay22');
            }
        }
        function doOk1() {
            //////alert("Please add all the KPI's for the category");
        }

        function validTargets() {
            var strContent = "ctl00_ContentPlaceHolder1_";


            if (document.getElementById(strContent + "ddlRulSetKy").disabled != true) {
                if (document.getElementById(strContent + "ddlRulSetKy") != null) {
                    if (document.getElementById(strContent + "ddlRulSetKy").value == "") {
                        alert("Please select Rule Set Key");
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "txtRskDesc") != null) {
                if (document.getElementById(strContent + "txtRskDesc").value == "") {
                    alert("Please enter Rule Set Key description");
                    return false;
                }
            }

            if (document.getElementById(strContent + "ddlCyc") != null) {
                if (document.getElementById(strContent + "ddlCyc").value == "") {
                    alert("Please select Target Cycle");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtEffFrom") != null) {
                if (document.getElementById(strContent + "txtEffFrom").value == "") {
                    alert("Please enter Effective Date From");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtEffTo") != null) {
                if (document.getElementById(strContent + "txtEffTo").value == "") {
                    alert("Please enter Effective Date To");
                    return false;
                }
            }

            if (document.getElementById(strContent + "ddlCatgDesc") != null) {
                if (document.getElementById(strContent + "ddlCatgDesc").value == "") {
                    alert("Please select Category Description");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtCatgCode") != null) {
                if (document.getElementById(strContent + "txtCatgCode").value == "") {
                    alert("Please enter Category");
                    return false;
                }
            }

            if (document.getElementById(strContent + "ddlCatgDesc") != null) {
                if (document.getElementById(strContent + "ddlCatgDesc").value == "") {
                    alert("Please select Category Description");
                    return false;
                }
            }

            if (document.getElementById(strContent + "ddlKPICode").disabled != true) {
                if (document.getElementById(strContent + "ddlKPICode") != null) {
                    if (document.getElementById(strContent + "ddlKPICode").value == "") {
                        alert("Please select KPI Description");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "txtKpiName") != null) {
                if (document.getElementById(strContent + "txtKpiName").value == "") {
                    alert("Please select KPI Code");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtTrgFrm") != null) {
                if (document.getElementById(strContent + "txtTrgFrm").value == "") {
                    alert("Please enter target from");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtTrgTo") != null) {
                if (document.getElementById(strContent + "txtTrgTo").value == "") {
                    alert("Please enter Target to");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtSubCtgry") != null) {
                if (document.getElementById(strContent + "txtSubCtgry").value == "") {
                    alert("Please enter Sub Category");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtSort") != null) {
                if (document.getElementById(strContent + "txtSort").value == "") {
                    alert("Please enter Sort");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtTrgTo") != null) {
                if (document.getElementById(strContent + "txtTrgTo").value == "") {
                    alert("Please enter Target to");
                    return false;
                }
            }

            var isChecked = false;
            var rblPExcl = document.getElementById("<%=rblPExcl.ClientID%>");
            /////alert(rblPExcl);
            if (rblPExcl != null) {
                var radioButtons = rblPExcl.getElementsByTagName("input");
                for (var i = 0; i < radioButtons.length; i++) {
                    if (radioButtons[i].checked) {
                        isChecked = true;
                        break;
                    }
                }
                if (!isChecked) {
                    alert("Please Select Primary Exclusive");
                }

                return isChecked;
            }

            //            var isChecked = false;
            //            var rblSExcl = document.getElementById(strContent + "rblSExcl");
            //            alert('hi1');
            //            alert(rblSExcl);
            //            if (rblSExcl != null) {
            //                alert('hi');
            //                var radioButtons = rblSExcl.getElementsByTagName("input");
            //                for (var i = 0; i < radioButtons.length; i++) {
            //                    if (radioButtons[i].checked) {
            //                        isChecked = true;
            //                        break;
            //                    }
            //                }
            //                if (!isChecked) {
            //                    alert("Please Select Secondary Exclusive");
            //                }
            //                return isChecked;
            //                alert(isChecked);
            /// }  
        }

    </script>
    <style type="text/css">
        /*.lbtn
        {
            margin-top: 10px;
        }
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }
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
            border-;
        }*/
        
        .disablepage
        {
            display: none;
        }
        
        /*.box
        {
            background-color: #efefef;
            padding-left: 5px;
        }*/
    </style>
    <div class="container">
    <div class="row">
    <center>



     
        <div>
                <asp:HiddenField ID="hdnTargetFrom" runat="server" />
                <asp:HiddenField ID="hdnTargetTo" runat="server" />

        </div>
     
        <div id="divtrghdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divtrg','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                       <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                        <asp:Label ID="lblhdr"  style="font-size:19px;" runat="server"/>
                    </div>
                    <div class="col-sm-2">
                        <span id="MyImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                    </div>
                </div>
            </div>
            <div id="divtrg" runat="server" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblRulSetKy" Text="Rule Set Key" runat="server" CssClass="control-label" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row col-xs-12">
                                    <asp:DropDownList ID="ddlRulSetKy" runat="server" AutoPostBack="true" CssClass="form-control"
                                        OnSelectedIndexChanged="ddlRulSetKy_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                     <asp:HiddenField ID="hdnIsValid" runat="server" />

                                </div>
                                <div>
                                    <asp:Image ID="imgRul" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-3-Process-Info.ico"
                                        runat="server" Width="25px" Height="25px" Visible="false" />
                                    <asp:Image ID="imgRulP" ImageUrl="~/images/process-accept-icon.png" runat="server"
                                        Width="25px" Height="25px" Visible="false" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblRskDesc" Text="Rule Set Key Description" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtRskDesc" runat="server" CssClass="form-control"
                                    Enabled="false" placeholder="Rule Set Key Description" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div id="div2" runat="server"  style="width:97%;" class="panel">
            <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divtrgcyc','myImg2');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                        <asp:Label ID="Label3" Text="Target Details" style="font-size:19px;"  runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                    </div>
                </div>
            </div>
            <div id="divtrgcyc" runat="server" class="panel-body" style="width:96%;">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCyc" Text="Target Cycles" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row col-xs-12">
                                    <asp:DropDownList ID="ddlCyc" runat="server" AutoPostBack="true" Enabled="true" Width="100%"
                                        CssClass="form-control" OnSelectedIndexChanged="ddlCyc_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Image ID="imgCyc" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-3-Process-Info.ico"
                                        runat="server" Width="25px" Height="25px" Visible="false" />
                                    <asp:Image ID="imgCycP" ImageUrl="~/images/process-accept-icon.png" runat="server"
                                        Width="25px" Height="25px" Visible="false" />
                                    <asp:HiddenField ID="hdnYrType" runat="server" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                     <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMemberYear" Text="Member Cycle" runat="server" CssClass="control-label" />
                        
                    </div>
                     <div class="col-sm-3" style="text-align: left">
                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                            <ContentTemplate>
                          <asp:DropDownList ID="ddlMemberCycle" runat="server" AutoPostBack="true"  Enabled="false"  CssClass="form-control"
                                        Width="100%" >
                                    </asp:DropDownList>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label1" Text="Effective Date From" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div style="white-space: nowrap;">
                                    <asp:TextBox ID="txtEffFrom" runat="server" CssClass="form-control"
                                        MaxLength="20" Enabled="false" placeholder="Effective Date From" ></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label2" Text="Effective Date To" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <div style="white-space: nowrap;">
                                    <asp:TextBox ID="txtEffTo" runat="server" CssClass="form-control"
                                        MaxLength="20" Enabled="false" placeholder="Effective Date To" ></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCatgDesc" Text="Category Description" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row col-xs-12">
                                    <asp:TextBox ID="txtCatgDesc" runat="server" CssClass="form-control" Enabled="false"
                                        placeholder="Category Description"></asp:TextBox>
                                    <asp:DropDownList ID="ddlCatgDesc" runat="server" AutoPostBack="true" CssClass="form-control"
                                        Width="100%" OnSelectedIndexChanged="ddlCatgDesc_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Image ID="imgCatg" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-3-Process-Info.ico"
                                        runat="server" Width="25px" Height="25px" Visible="false" />
                                    <asp:Image ID="imgCatgP" ImageUrl="~/images/process-accept-icon.png" runat="server"
                                        Width="25px" Height="25px" Visible="false" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCatgCode" Text="Category" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel121" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCatgCode" runat="server" CssClass="form-control"
                                    Enabled="false" placeholder="Category"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblKpicode" Text="KPI Description" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <div class="row col-xs-12">
                                    <asp:DropDownList ID="ddlKPICode" runat="server" AutoPostBack="true" CssClass="form-control" Width="100%"
                                        Enabled="false" OnSelectedIndexChanged="ddlKPICode_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <asp:Image ID="imgKPI" ImageUrl="~/images/Custom-Icon-Design-Pretty-Office-3-Process-Info.ico"
                                        runat="server" Width="25px" Height="25px" Visible="false" />
                                    <asp:Image ID="imgKPIP" ImageUrl="~/images/process-accept-icon.png" runat="server"
                                        Width="25px" Height="25px" Visible="false" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblKpiName" Text="KPI Code" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtKpiName" runat="server" CssClass="form-control"
                                    Enabled="false" placeholder="KPI Description"></asp:TextBox></ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTrgFrm" Text="Target From" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtTrgFrm" runat="server" CssClass="form-control"
                                    placeholder="Target From"   OnTextChanged="txtTrgFrm_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="ftxtxtTrgFrm" runat="server" TargetControlID="txtTrgFrm"
                                    ValidChars=".,-" FilterMode="ValidChars" FilterType="Custom,Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblTrgTo" Text="Target To" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtTrgTo" runat="server" CssClass="form-control"
                                    placeholder="Target To"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="ftxtxtTrgTo" runat="server" TargetControlID="txtTrgTo"
                                    ValidChars=".,-" FilterMode="ValidChars" FilterType="Custom,Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                 <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                            <ContentTemplate>
                 <div class="row" id="divScore" style="margin-bottom: 5px;"  runat="server" visible="false">
                      <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblScoreFrom" Text="Min Weighted" runat="server" CssClass="control-label" />
                    </div>
                      <div class="col-sm-3" style="text-align: left">
                          <asp:TextBox ID="txtScoreFrom" runat="server" CssClass="form-control"
                                         placeholder="Weigthed Score From"></asp:TextBox>
                    </div>
                      <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblScoreTo" Text="Max Weighted" runat="server" CssClass="control-label" />
                    </div>
                      <div class="col-sm-3" style="text-align: left">
                        
                          <asp:TextBox ID="txtScoreTo" runat="server" CssClass="form-control"
                                        placeholder="Weighted Score To"></asp:TextBox>
                    </div>

                     </div>
                <div class="row" id="divWeighted" style="margin-bottom: 5px;"  runat="server" visible="false">
                     <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblWeighted" Text="Weighted" runat="server" CssClass="control-label" />
                    </div>
                     <div class="col-sm-3" style="text-align: left">
                         <asp:TextBox ID="txtWeighted" runat="server" CssClass="form-control"
                                        placeholder="Enter Weighted"></asp:TextBox>
                    

                    </div>
                     <div class="col-sm-6" style="text-align: left">
                        
                    </div>

                     </div>
                                </ContentTemplate>
                                 </asp:UpdatePanel>
                            


                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblSpl" Text="Split" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rblSplit" runat="server" CssClass="radio-list" AutoPostBack="true"
                                    Enabled="false" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Equal Split" Value="EQ"></asp:ListItem>
                                    <asp:ListItem Text="Unequal Split" Value="UEQ"></asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label6" Text="Sub Category" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3" style="white-space: nowrap; text-align: left;">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <div class="row col-xs-6">
                                    <asp:TextBox ID="txtSubCtgry" runat="server" CssClass="form-control"
                                        Enabled="false" placeholder="Sub Category"></asp:TextBox>
                                </div>
                                <div class="col-xs-6 lbtn">
                                    <asp:LinkButton ID="lnkNewCatg" Text="New Code" runat="server"
                                        OnClick="lnkNewCatg_Click"/>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label4" Text="Primary Exclusive" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rblPExcl" runat="server" CssClass="radio-list" AutoPostBack="true"
                                    Enabled="false" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label5" Text="Secondary Exclusive" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rblSExcl" runat="server" CssClass="radio-list" AutoPostBack="true"
                                    Enabled="false" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="Label7" Text="Sort" runat="server" CssClass="control-label" />
                        <span style="color: Red;">*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtSort" runat="server" CssClass="form-control"
                                    Enabled="false" placeholder="Sort"></asp:TextBox></ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-6" style="text-align: left">
                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkStdTrg" Text="Please check for applying standard definition rule"
                                    AutoPostBack="true" runat="server" CssClass="checkbox" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnAddMaster" runat="server" CssClass="btn btn-sample"
                                    Enabled="true" OnClick="btnAddMaster_Click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Category
                                    </asp:LinkButton>
                                <asp:LinkButton ID="btnAdd" Enabled="false" runat="server" CssClass="btn btn-sample"
                                    OnClick="btnAdd_Click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Target
                                    </asp:LinkButton>

                                <asp:LinkButton ID="btnEnqSave"  runat="server" Visible="false" CssClass ="btn btn-sample"
                                    OnClick="btnSave_Click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Save Target
                                    </asp:LinkButton>

                                <asp:LinkButton ID="btnCncl" runat="server" CssClass="btn btn-sample"
                                    Visible="false" OnClick="btnCncl_Click" OnClientClick="doCancel();return false;">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                    </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div id="div3" runat="server" class="panel" style="width:97%;">
            <div id="Div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divtrgrs','Img2');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                        <asp:Label ID="Label8" runat="server" Text="Target Details Results"  Style="font-size:19px"/>
                    </div>
                    <div class="col-sm-2">
                        <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                    </div>
                </div>
            </div>
            <div id="divtrgrs" runat="server" class="panel-body">
                <div id="div1" runat="server" style="width: 100%; margin: 0px 0 !important;" class="table-scrollable">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dgQualTrg" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="1000" AllowSorting="false" AllowPaging="true" CssClass="footable" OnRowDataBound="dgQualTrg_RowDataBound">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                            <asp:HiddenField ID="hdnBusiCode" runat="server" Value='<%# Bind("BUSI_CODE")%>' />
                                            <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Bind("CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category" SortExpression="CATEGORY">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATEGORY")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCycle" runat="server" Text='<%# Bind("CYCLE")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category Description" SortExpression="CATG_DESC">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("CATG_DESC")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("CATG_DESC")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Member Cycle" SortExpression="MEMTYPE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemberCycle" runat="server" Text='<%# Bind("MEMBER_CYCLE")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnMemberCycle" runat="server" Value='<%# Bind("MEMBER_CYCLE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Target From" SortExpression="TRG_FRM">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTrgFrm" runat="server" Text='<%# Bind("TRG_FRM")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnTrgFrm" runat="server" Value='<%# Bind("TRG_FRM")%>' />
                                            <asp:TextBox ID="txtTrgFrm" runat="server" Text='<%# Bind("TRG_FRM")%>' Visible="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Target To" SortExpression="TRG_TO">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTrgTo" runat="server" Text='<%# Bind("TRG_TO")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnTrgTo" runat="server" Value='<%# Bind("TRG_TO")%>' />
                                            <asp:TextBox ID="txtTrgTo" runat="server" Text='<%# Bind("TRG_TO")%>' Visible="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eff From" SortExpression="EFFDT_FROM">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEffFrom" runat="server" Text='<%# Bind("EFFDT_FROM")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnEffFrom" runat="server" Value='<%# Bind("EFFDT_FROM")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eff To" SortExpression="EFFDT_TO">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEffTo" runat="server" Text='<%# Bind("EFFDT_TO")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnEffTo" runat="server" Value='<%# Bind("EFFDT_TO")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Catg Set" SortExpression="CATSET">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCATSET" runat="server" Text='<%# Bind("CATSET")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnCATSET" runat="server" Value='<%# Bind("CATSET")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="P Excl" SortExpression="P_EXCL">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblP_EXCL" runat="server" Text='<%# Bind("P_EXCL_DESC")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnP_EXCL" runat="server" Value='<%# Bind("P_EXCL")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S Excl" SortExpression="S_EXCL">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblS_EXCL" runat="server" Text='<%# Bind("S_EXCL_DESC")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnS_EXCL" runat="server" Value='<%# Bind("S_EXCL")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort" SortExpression="SORT">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblSORT" runat="server" Text='<%# Bind("SORT")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnSORT" runat="server" Value='<%# Bind("SORT")%>' />
                                            <asp:HiddenField ID="hdnStdDefn" runat="server" Value='<%# Bind("STDDEFN")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Min Weighted" SortExpression="MIN_WEIGHTED">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblMinWeighted" runat="server" Text='<%# Bind("MIN_WEIGHTED")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnMinWeighted" runat="server" Value='<%# Bind("MIN_WEIGHTED")%>' />
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Max Weighted" SortExpression="MAX_WEIGHTED">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaxWeighted" runat="server" Text='<%# Bind("MAX_WEIGHTED")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnMaxWeighted" runat="server" Value='<%# Bind("MAX_WEIGHTED")%>' />
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Weighted" SortExpression="WEIGHTED">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblWeighted" runat="server" Text='<%# Bind("WEIGHTED")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnWeighted" runat="server" Value='<%# Bind("WEIGHTED")%>' />
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Action" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelRwdTrg" runat="server" Text="Delete" Enabled="false" OnClick="lnkDelRwdTrg_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <ajax:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <br />
                <div id="divPage" visible="true" runat="server" class="pagination">
                    <center>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                            <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
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
                <div class="row">
                    <div class="col-sm-6" style="text-align: left;padding-left:40px;">
                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkAllCyc" AutoPostBack="true" runat="server"
                                    CssClass="checkbox" OnCheckedChanged="chkAllCyc_CheckedChanged"/>
                                <asp:Label Text="Apply to all Cycles" runat="server" CssClass="control-label" style="padding-left: 5px;"/>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-6" style="text-align: left;padding-left:40px;">
                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkConfTrg" Enabled="false" AutoPostBack="true"
                                    runat="server" CssClass="checkbox" />
                                    <asp:Label ID="Label10" text="Please confirm targets" runat="server" CssClass="control-label" style="padding-left: 5px;"/>
                                    </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div id="tblsvtrg" runat="server" class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnSaveTrg" runat="server" CssClass="btn btn-sample"
                            Enabled="true" OnClick="btnSaveTrg_Click" >
                                <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                            </asp:LinkButton>
                        <asp:LinkButton ID="btnCnclTrg" runat="server" CssClass="btn btn-sample"
                            Enabled="true" OnClick="btnCnclTrg_Click" >
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                            </asp:LinkButton>
                        <asp:Button ID="btntrg" runat="server" ClientIDMode="Static" Style="display: none;"
                            OnClick="btntrg_Click" />
                        <asp:LinkButton ID="btnKPI" runat="server" Style="display: none;" ClientIDMode="Static"
                            OnClick="btnKPI_Click"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </center>
    <asp:Panel runat="server" Height="350px" Width="900px" ID="pnlRwdRul" display="none"
        Style="text-align: center; padding: 10px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmRwdRul" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label9" Style="display: none" />
    <ajaxtoolkit:modalpopupextender runat="server" id="mdlVw" behaviorid="mdlVwBID" dropshadow="false"
        targetcontrolid="Label5" popupcontrolid="pnlRwdRul" backgroundcssclass="modalPopupBg"  X="15" Y="30">
            </ajaxtoolkit:modalpopupextender>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnAccCyc" runat="server" />
            <asp:HiddenField ID="hdnSetTrgRul" runat="server" />
            <asp:HiddenField ID="hdnTrgFrm" runat="server" />
            <asp:HiddenField ID="hdnTrgTo" runat="server" />
            <asp:HiddenField ID="hdnBusiYear" runat="server" />
            <asp:HiddenField ID="hdnbusicode" runat="server" />
            <asp:HiddenField ID="hdnCount" runat="server" />
            <asp:HiddenField ID="hdnyrtyp" runat="server" />
            <asp:HiddenField ID="hdnTrgCnt" runat="server" />
            <asp:HiddenField ID="hdnTrgCnt1" runat="server" />
            <asp:HiddenField ID="hdnSortNo" runat="server" />
            <asp:HiddenField ID="hdntxtfrm" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div>
</asp:Content>
