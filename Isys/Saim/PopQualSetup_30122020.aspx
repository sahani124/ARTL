<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopQualSetup.aspx.cs" Inherits="Application_ISys_Saim_PopQualSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
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
            debugger;
            $("#<%= txtVrEffFrm.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtVrEffTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });

        function OpenPopupWindow(cmpcode, cntstcode, ruleset,kpi) {
            debugger;
            //alert("OpenPopupWindow2");
            window.open("PopKpiMemCycle.aspx?cmpcode=" + cmpcode + "&cntstcode=" + cntstcode + "&ruleset=" + ruleset + "&kpi=" + kpi, '', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');

        }

        function funAddVarMaster(cmpcode, cntstcode, ruleset, kpi,ruleclass) {
            debugger;
            //alert("OpenPopupWindow2");
            window.open("PopKPITrg.aspx?cmpcode=" + cmpcode + "&cntstcode=" + cntstcode + "&ruleset=" + ruleset + "&kpi=" + kpi + "&ruleclass=" + ruleclass, '', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');

            //window.open("PopKPITrg.aspx?ruleset=" + ruleset + "&kpi=" + kpi, '', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');

        }

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
                   // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
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

        $(function () {
            var strcontent = "ctl00_ContentPlaceHolder1_";
            $("#<%=txtRSKDesc.ClientID %>").keypress(function () {
                alert("Please add master using ADD MASTER...")
                document.getElementById(strcontent + "txtRSKDesc").value == "";
                //document.getElementById(strcontent + "txtRSKDesc").value = "";
                return false;


            });
        });

        function funAddmaster(cmpcode, cntstcode, flag, ruletype) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////$find("mdlVw").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopCntstMst.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype
            + "&mdlpopup=mdlVwBID";
        }

        function doCancel(rultyp) {

            if (rultyp == "Q") {
                /////alert('akshayQ');
                window.parent.document.getElementById("btnqual").click();
            }
            else if (rultyp == "R") {
                /////alert('akshayR');
                window.parent.document.getElementById("btnrwd").click();
            }
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        function funPopUpRwdRul(cmpcode, cntstcd, rultyp) {
            //////alert('kjbkjsbk');
            var strContent = "ctl00_ContentPlaceHolder1_";
            /////$find("ctl00_ContentPlaceHolder1_mdlVwBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRuleSet.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&mdlpopup=mdlVwBID";
        }

        function funPopSubCnt(cmpcode, cntstcd, rultyp) {
            //////alert('kjbkjsbk');
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////$find("ctl00_ContentPlaceHolder1_mdlVwBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopSubCntst.aspx?cmpnstcd=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&mdlpopup=mdlVwBID";
        }

        function validate() {

            var strcontent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strcontent + "txtRSKDesc") != null) {
                if (document.getElementById(strcontent + "txtRSKDesc").value == "") {
                    alert("Please add master using ADD MASTER...");
                    document.getElementById(strcontent + "txtRSKDesc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlRSKDesc") != null) {
                if (document.getElementById(strcontent + "ddlRSKDesc").value == "") {
                    alert("Please Select Rule Set Key Description...");
                    document.getElementById(strcontent + "ddlRSKDesc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlKPICode") != null) {
                if (document.getElementById(strcontent + "ddlKPICode").value == "") {
                    alert("Please Select KPI Description");
                    document.getElementById(strcontent + "ddlKPICode").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlAccMode") != null) {
                if (document.getElementById(strcontent + "ddlAccMode").value == "") {
                    alert("Please Select Accumulation Mode");
                    document.getElementById(strcontent + "ddlAccMode").focus();
                    return false;
                }
            }





            if (document.getElementById(strcontent + "txtVrEffFrm") != null) {
                if (document.getElementById(strcontent + "txtVrEffFrm").value == "") {
                    alert("Please enter Eff. From");
                    document.getElementById(strcontent + "txtVrEffFrm").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtVrEffTo") != null) {
                if (document.getElementById(strcontent + "txtVrEffTo").value == "") {
                    alert("Please enter Eff. To");
                    document.getElementById(strcontent + "txtVrEffTo").focus();
                    return false;
                }
            }

            var RB1 = document.getElementById("<%=rblCRYFWD.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {
                    isChecked = true;
                    break;
                }
            }
            if (!isChecked) {
                alert("Please select Carry Forward Rule");
                return false;
            }

            if (document.getElementById(strcontent + "ddlRwdCmpRul") != null) {
                if (document.getElementById(strcontent + "ddlRwdCmpRul").value == "") {
                    alert("Please Select Reward Computation Rule");
                    document.getElementById(strcontent + "ddlRwdCmpRul").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtMaxLmt") != null) {
                if (document.getElementById(strcontent + "txtMaxLmt").value == "") {
                    alert("Please enter Max Limit");
                    document.getElementById(strcontent + "txtMaxLmt").focus();
                    return false;
                }
            }

        }

    </script>
    <%--<Added by bhaurao>--%>
    <style type="text/css">
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
        .ajax__calendar
        {
            position: relative;
            z-index: 9999;
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
          .custom {
            width: 150px !important;
        }
        
        .custommodalPopup
        {
            height:300px !important;
            
    
    
}

    </style>
    <center>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="divqualhdrcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="Div6" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%><%--commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblhdr" Text="Select KPI for qualification rule" style="font-size:19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divqual" runat="server" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblrlSetKy" Text="Rule Set Key" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label6" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRuleSetKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            placeholder="Rule Set Key" Enabled="false" />
                                        <asp:CheckBox ID="chkRulSetKy" Text="Please check to generate new rule set key" runat="server"
                                            CssClass="checkbox" AutoPostBack="true" Visible="false" OnCheckedChanged="chkRulSetKy_CheckedChanged" />
                                        <asp:LinkButton ID="lnkRuleSetKy" Text="New Rule Set Key" Visible="false" runat="server"
                                            OnClick="lnkRuleSetKy_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label15" Text="Rule Set Key Description" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label23" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtRSKDesc" runat="server" CssClass="select2-container form-control"
                                    placeholder="Rule Set Key Description" MaxLength="40" OnTextChanged="txtRSKDesc_TextChanged" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ,&,_"
                                    FilterMode="ValidChars" TargetControlID="txtRSKDesc">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:DropDownList ID="ddlRSKDesc" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    Visible="false" OnSelectedIndexChanged="ddlRSKDesc_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblKPICode" Text="KPI Description" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label7" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlKPICode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            OnSelectedIndexChanged="ddlKPICode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAccMode" Text="Accumulation Mode" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label8" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlAccMode" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;display:none">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVrEffFrm" Text="Eff. From" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label9" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtVrEffFrm" runat="server" CssClass="select2-container form-control"
                                    placeholder="Eff. From" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVrEffTo" Text="Eff. To" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label10" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtVrEffTo" runat="server" CssClass="select2-container form-control"
                                    placeholder="Ver. Eff. To" AutoPostBack="true">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;display:none"  runat="server" >
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label1" Text="Carry Forward Rule" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label11" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:RadioButtonList ID="rblCRYFWD" runat="server" CssClass="radio-list" AutoPostBack="true"
                                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rblCRYFWD_SelectedIndexChanged">
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="N" selected="true"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Reward Computation Rule" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label12" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlRwdCmpRul" runat="server" CssClass="select2-container form-control">
                                    <asp:ListItem Value="">--SELECT--</asp:ListItem>
                                    <asp:ListItem Value="AC"  selected="true">Accumulation Cycle</asp:ListItem>
                                    <asp:ListItem Value="RRC">Reward Release Cycle</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label3" Text="Unit Type" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label13" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlUnitType" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="ddlUnitType_SelectedIndexChanged" Enabled="true" CssClass="select2-container form-control"  >
                                </asp:DropDownList>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                     <asp:Label ID="lblKpiRulClass" Text="KPI Rule Class" runat="server" CssClass="control-label" />
                                    
                                     </div>

                                        <div class="col-sm-3" style="text-align: left">
                                        <asp:DropDownList runat="server" ID="ddlRuleClass"  AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  >
                                           
                                        </asp:DropDownList>
                                    </div>



                             </div>
                         <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label4" Text="Do You Want Defined Target" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label14" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                  <div class="row col-xs-10">
                                <asp:DropDownList ID="ddlDfnTrg" runat="server" Enabled="true" AutoPostBack="true" CssClass="select2-container form-control" OnSelectedIndexChanged="ddlDfnTrg_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- SELECT -- </asp:ListItem>
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                                  <div class="row col-xs-2">
                                  <asp:LinkButton ID="btnTrg" runat="server" Visible="false" CssClass="btn btn-sample"  OnClick="btnTrg_Click" >
                                    <span class="glyphicon glyphicon-hand-right BtnGlyphicon"> </span> 
                                                    </asp:LinkButton>
                                      </div>


                            </div>
                                <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label29" Text="Set Computation Rule" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label30" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3"  style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCmptnRule" runat="server" AutoPostBack="true" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                    </div>
                            </div>
                       
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label25" Text="Computation type" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label26" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlComptype" runat="server" Enabled="false" CssClass="select2-container form-control">
                                <asp:ListItem Value="0">-- SELECT -- </asp:ListItem>
                                <asp:ListItem Value="1">Incremental</asp:ListItem>
                                <asp:ListItem Value="2" selected="true">Regular</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                              <div class="col-sm-3" style="text-align: left;display:none">
                                 <asp:Label ID="lblKPI_Code" Text="Parent KPI Code" runat="server" CssClass="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left;display:none">
                                 <asp:DropDownList runat="server" ID="ddlKPI_Code" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                
                                 </asp:DropDownList>
                             
                                </div>
                            </div>
                        <div class="row" style="margin-bottom: 5px;">

                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lblCumulative" Text="Is Cumulative" runat="server" CssClass="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlIsCumulative" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" OnSelectedIndexChanged="ddlIsCumulative_SelectedIndexChanged" >
                                     <asp:listItem Value="0" >--SELECT--</asp:ListItem>
                                     <asp:listItem Value="1" >YES</asp:ListItem>
                                     <asp:listItem Value="2"  selected="true">NO</asp:ListItem>
                                
                                 </asp:DropDownList>
                             
                                </div>
                            <div class="col-sm-3" style="text-align: left">
                                 <asp:LinkButton ID="btnMemCycle" runat="server" CssClass="btn btn-sample" OnClick="btnMemCycle_Click" Visible="false">
                                        <span class="glyphicon glyphicon-check" style="color: White;"></span> Define Member Cycle
                                </asp:LinkButton>
                            </div>
                            </div>



                      <%--  added by ajay sawant--%>
                        <div class="row" runat="server" visible="false">
                             <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label27" Text="Max Limit" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label28" Text="*" runat="server" Style="color: Red" />
                            </div>
                            <div class="col-sm-3">
                                
                                <asp:TextBox ID="txtMaxLmt" runat="server" OnTextChanged="txtMaxLmt_TextChanged"
                                    CssClass="select2-container form-control" placeholder="Max Limit" MaxLength="10">
                                </asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="txtMaxLmt">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>

                        </div>

                        <div class="row" style="margin-bottom: 5px;display:none ">
                            <div class="col-sm-6" style="text-align: left; padding-left: 40px;">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkStdRwd" AutoPostBack="true" runat="server" CssClass="checkbox" />
                                        <asp:Label ID="Label24" Text="Please check for applying standard definition rule"
                                            runat="server" CssClass="control-label" Style="padding-left: 5px;" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>




                        </div>
                        <br />
                        <div id="divBsKPIhdr" runat="server" style="width: 95%; margin-left: 0px; margin-right: 0px;"
                            visible="false" class="panel panel-success">
                            <div style="width: 100%;" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divBsKPI','myImg1');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                        <asp:Label ID="Label16" Text="Map to Base KPI" runat="server" />
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="myImg1" class="glyphicon glyphicon-collapse-down" style="float: right;
                                            color: Orange; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divBsKPI" runat="server" style="width: 100%;" class="panel-body">
                                <div id="tblBskpi" runat="server" style="width: 100%;">
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label17" Text="Sales Channel" runat="server" CssClass="control-label" />
                                            <asp:Label ID="Label19" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSlsChnl" runat="server" CssClass="select2-container form-control"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSlsChnl_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="Label21" Text="Sub Class" runat="server" CssClass="control-label" />
                                            <asp:Label ID="Label22" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel71" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSubCls" runat="server" CssClass="select2-container form-control"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSubCls_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 5px;">
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblCntst" Text="Contestant Code" runat="server" CssClass="control-label" />
                                            <asp:Label ID="Label18" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlContestant" runat="server" CssClass="select2-container form-control"
                                                        OnSelectedIndexChanged="ddlContestant_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-sm-3" style="text-align: left">
                                            <asp:Label ID="lblSubCont" Text="Rule Set Key" runat="server" CssClass="control-label" />
                                            <asp:Label ID="Label20" Text="*" runat="server" Style="color: Red" />
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSubCnt" runat="server" CssClass="select2-container form-control"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div id="div4" runat="server" style="width: 100%; border: none; padding: 10px; margin: 0px 0 !important;"
                                        class="table-scrollable">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="dgSubCntst" runat="server" CssClass="footable" AllowSorting="True"
                                                    AllowPaging="true" AutoGenerateColumns="false">
                                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                                    <PagerStyle CssClass="disablepage" />
                                                    <HeaderStyle CssClass="gridview th" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sales Channel" SortExpression="SUB_CHN">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("SUBCHNDESC")%>' />
                                                                <asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("SUB_CHN")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sub Class" SortExpression="CHNCLS">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("SUBCLSDESC")%>'></asp:Label>
                                                                <asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("SUB_CHNCLS")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sub Contest" SortExpression="MEMTYPE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                                <asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("SUBCNTST")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Rule Code" SortExpression="RULE_CODE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRulCode" runat="server" Text='<%# Bind("SUBRSKDESC")%>'></asp:Label>
                                                                <asp:HiddenField ID="hdnRulCode" runat="server" Value='<%# Bind("SUBRSK")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="row" style="margin-top: 12px;">
                                        <div class="col-sm-12" align="center">
                                            <asp:LinkButton ID="btnAddSub" runat="server" CssClass="btn btn-primary" OnClick="btnAddSub_Click">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                    </div>

                     <div id="Divdpndhead" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg2');return false;" visible="false">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%><%--commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="Label31" Text="Dependant parent defination" style="font-size:19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>



                      <div id="divdpnd"  class="panel-body"  runat="server" visible="false">


                        
                                  <div class="row" style="margin-bottom: 5px;">
                                      <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lblparentCode" Text="Parent Compensation Code" runat="server" CssClass="control-label"  Visible="false" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlParntCmpCode" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%"  OnSelectedIndexChanged="ddlParntCmpCode_SelectedIndexChanged"  Visible="false"  >

                                 </asp:DropDownList>
                              <asp:HiddenField ID="hdnComLinked" runat="server"  />
                                </div>




                        </div>


                   <%--     added by ajay sawant--%>
                           <div class="row" style="margin-bottom: 5px;" id="divParentCntst"  runat="server" visible="false">

                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lblParentCntst" Text="Parent Contestant Code" runat="server" CssClass="control-label"  />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlParntCntstCode" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" OnSelectedIndexChanged="ddlParntCntstCode_SelectedIndexChanged" >
                                   
                                 </asp:DropDownList>
                             
                                </div>
                            <div class="col-sm-3" style="text-align: left">
                                 <asp:Label ID="lblParentRulSetky" Text="Parent Rule Set Key" runat="server" CssClass="control-label" />
                                </div>
                             <div class="col-sm-3" style="text-align: left">
                                 <asp:DropDownList runat="server" ID="ddlParntRulSetKy" AutoPostBack="true" 
                                            CssClass="form-control" Width="100%" >
                                   
                                 </asp:DropDownList>
                                
                            </div>

                        </div>

                         <div class="row" style="margin-top: 12px;" runat="server"  id="divbutton">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sample" OnClick="btnAdd_Click" >
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                </asp:LinkButton>
                            </div>
                         </div>


                          </br>
                       
                        <div id="dvdpnd" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">

                              <asp:UpdatePanel runat="server">
                              <ContentTemplate>
                            <asp:GridView ID="dgdpnd" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" 
                                >
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <EmptyDataTemplate>
                                     <asp:Label ID="lblerror" Text="No Dependant Reward Define" ForeColor="Red"
                                                    CssClass="control-label" runat="server" />
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrulesetkey" runat="server" Text='<%# Bind("RULE_SET_DESC")%>' ></asp:Label>
                                            <%--<asp:HiddenField ID="hdnrulesetkey" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KPI  Code" SortExpression="KPI_CODE">
                                        <ItemTemplate>
                                               <asp:Label ID="lblkpicode" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                           <%-- <asp:HiddenField ID="hdnkpicode" runat="server" Value='<%# Bind("KPI_CODE")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Parent Comp Code" SortExpression="PRNT_CMPNSTN_CODE">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPRNT_CMPNSTN_CODE" runat="server" Text='<%# Bind("CMPNSTN_DESC")%>'></asp:Label>
                                            <%--<asp:HiddenField ID="hdnPRNT_CMPNSTN_CODE" runat="server" Value='<%# Bind("PRNT_CMPNSTN_CODE")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Parent Contestant Code" SortExpression="PRNT_CNTSTNT_CODE">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPRNT_CNTSTNT_CODE" runat="server" Text='<%# Bind("PRNT_CNTSTNT_CODE")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnPRNT_CNTSTNT_CODE" runat="server" Value='<%# Bind("PRNT_CNTSTNT_CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Parent Rule Ret Key" SortExpression="PRNT_RULE_SET_KEY">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPRNT_RULE_SET_KEY" runat="server" Text='<%# Bind("PARENT_RULE_SET_DESC")%>'></asp:Label>
                                         <%--   <asp:HiddenField ID="hdnPRNT_RULE_SET_KEY" runat="server" Value='<%# Bind("PRNT_RULE_SET_KEY")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                            </columns>

                          </asp:GridView>
                             
                        </ContentTemplate>
                       </asp:UpdatePanel>


                        </div>
                        

                </div>


                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnMaster" runat="server" CssClass="btn btn-sample" OnClick="btnMaster_Click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Rule Set
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" OnClick="btnSave_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnUpdate" Text="UPDATE" runat="server" CssClass="btn btn-sample"
                                    Visible="false" OnClick="btnUpdate_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Update
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCncl" Text="CANCEL" runat="server" CssClass="btn btn-sample"
                                    OnClick="btnCncl_Click" OnClientClick="doCancel();return false;">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                                <asp:Button ID="btnKPI" runat="server" Style="display: none;" ClientIDMode="Static"
                                    OnClick="btnKPI_Click" />
                            </div>
                        </div>


                    </div>

                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" Height="350px" Width="900px"  ID="pnlRwdRul" display="none" 
                            Style="text-align: center; padding: 8px;margin-left:76px;" CssClass="panel panel-success">
                            <iframe runat="server" id="ifrmRwdRul" scrolling="yes" width="100%" frameborder="0"
                                display="none" style="height: 100%;"></iframe>
                        </asp:Panel>
                        <asp:Label runat="server" ID="Label5" Style="display: none" />
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw" BehaviorID="mdlVwBID" DropShadow="false" X="15" Y="18"
                            TargetControlID="Label5" PopupControlID="pnlRwdRul" BackgroundCssClass="modalPopupBg">
                        </ajaxToolkit:ModalPopupExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HiddenField ID="hdnRulSetKy" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hdnKPIOrigin" runat="server" />
                <asp:Button ID="btnSbCnt" runat="server" ClientIDMode="Static" Style="display: none;"
                    OnClick="btnSbCnt_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <%--    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
