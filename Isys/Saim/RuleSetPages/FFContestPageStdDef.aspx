<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="FFContestPageStdDef.aspx.cs" Inherits="Application_ISys_Saim_RuleSetPages_FFContestPageStdDef" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI Styles/assets/css/style.css" rel="stylesheet"
        type="text/css" />
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
    <link href="../../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
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
    <link href="../../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../assets/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src='<%= ResolveUrl("~/assets/scripts/jquery.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/assets/scripts/bootstrap.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/assets/scripts/bootstrap-multiselect.js") %>'></script>
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
        function funPopUpCycleDef(cmpcode) { //, accycle, cyctype, yrtyp, effdatefrom, effdateto, rulesetcode, cntstcode, BUSI_YEAR
            debugger;
            window.open("Date_Cycle_Defination_Split_Def.aspx?cmpcode=" + cmpcode, "PopUpCycle", "toolbar=yes,scrollbars=yes,resizable=yes,top=40,left=70,bottom=80,width=1200,height=600", true);
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

        function ShowReqDtll(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        function getUrlParameter(name) {
            name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
            var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
            var results = regex.exec(location.search);
            return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
        };

        function fnCallPOP() {
            debugger;

            var cmpCode = getUrlParameter('CMPNSTN_CODE');
            var cntCode = getUrlParameter('CNTST_CODE');
            var mapcode = getUrlParameter('mapcode');

            var ruleSet = getUrlParameter('RuleSetKey');
            // ddlRuleSetCode.val().toLowerCase();
            var strContent = "ctl00_ContentPlaceHolder1_";
            var rultyp = "R";
            $find("ModalPopupExtend1").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "../WeightedUpload.aspx?cmpCode=" + cmpCode + "&cntCode=" + cntCode
            + "&rultyp=" + rultyp + "&mapcode=" + mapcode + "&ruleSet=" + ruleSet + "&mdlpopup=ModalPopupExtend1";
            return false;
        }

        function fnCallPOP2() {
            debugger;

            var compcode = getUrlParameter('CMPNSTN_CODE');
            var cntstcd = getUrlParameter('CNTST_CODE');
            var MapCode = getUrlParameter('mapcode');

            var KpiCode = getUrlParameter('KPI_CODE');
            var RuleSetKey = getUrlParameter('RuleSetKey');
            var RuleId = "";
            // ddlRuleSetCode.val().toLowerCase();
            var strContent = "ctl00_ContentPlaceHolder1_";
            var rultyp = "R";
            $find("ModalPopupExtend1").show();

            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "../WeightedUpload.aspx?cmpCode=" + cmpCode + "&cntCode=" + cntCode
            + "&rultyp=" + rultyp + "&mapcode=" + mapcode + "&ruleSet" + ruleSet + "&mdlpopup=ModalPopupExtend1";
            return false;


            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "ProductDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&RuleId=" + RuleId + "&MapCode=" + Mapcode + "&RuleSetKey=" + RuleSetKey + "&KpiCode=" + KpiCode + "&mdlpopup=ModalPopupExtend1";


        }

        function funPopUpRulSet(cmpcode, cntstcd, rultyp, Mapcode, RuleId, dttyp, lblfrm, lblto) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "DateRelatedDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&MapCode=" + Mapcode + "&RuleId=" + RuleId + "&dttyp=" + dttyp + "&lblfrm=" + document.getElementById(strContent + "lblEffDtFrmVal").innerText
            + "&lblto=" + document.getElementById(strContent + "lblEffDtToVal").innerText + "&mdlpopup=mdlViewBID";
        }

        function funPopUpRulSetPremium(cmpcode, cntstcd, rultyp, Mapcode, RuleId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PremiumFreeqDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&RuleId=" + RuleId + "&MapCode=" + Mapcode + "&mdlpopup=mdlViewBID";
        }

        function funPopUpRulSetVPSC(cmpcode, cntstcd, rultyp, Mapcode, RuleId) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "VPSC_EKYCDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&RuleId=" + RuleId + "&MapCode=" + Mapcode + "&mdlpopup=mdlViewBID";
        }

        function funPopUpRulSetProduct(cmpcode, cntstcd, rultyp, Mapcode, RuleId, RuleSetKey, KpiCode) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_Iframe1";
            $find("ModalPopupExtend1").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "ProductDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&RuleId=" + RuleId + "&MapCode=" + Mapcode + "&RuleSetKey=" + RuleSetKey + "&KpiCode=" + KpiCode + "&mdlpopup=ModalPopupExtend1";
            return false;
        }

        function funPopUpRulSetProductBulk(cmpcode, cntstcd, rultyp, Mapcode) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_Iframe1";
            $find("ModalPopupExtend1").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "../WeightedUpload.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&MapCode=" + Mapcode + "&flag=weighted" + flag + "&mdlpopup=ModalPopupExtend1";
            return false;
        }

        //Added by Pratik
        function funGotoProductWeightage(role, flag, MAP_CODE, KPI_CODE, ACT_TYPE) {
            debugger;
            window.location.href = "../Customisation/MSTACTSU.aspx?mapcode=" + MAP_CODE + "&kpicode=" + KPI_CODE + "&role=" + role + "&ACT_TYPE=" + ACT_TYPE;
            return false;
        }
        //Added by Pratik

        function ShowReqDiv(divId, btnId, img, chkId, divChk) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + chkId) != null) {
                if (document.getElementById(strContent + chkId).checked == true) {
                    $(document.getElementById(strContent + divId)).slideToggle();
                    if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                        $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
                    }
                    else {
                        $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png');
                    }
                }
                else {
                    $(document.getElementById(strContent + divId)).hide();
                    $(document.getElementById(strContent + divChk)).show();
                }
            }
        }

        function ShowDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({
                height: 'toggle'
            });
        }

        function HideDiv(divId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).animate({ right: '25px' });
        }

        function funPopUpPrdct(div) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopStdPrdctDef.aspx?PrdctName=" + document.getElementById(strContent + "hdnPrdctName").id
            + "&PrdctFreq=" + document.getElementById(strContent + "hdnPrctFreq").id + "&Consider=" + document.getElementById(strContent + "hdnConsider").id
            + "&Type=" + document.getElementById(strContent + "hdnType").id + "&PrdctNameval=" + document.getElementById(strContent + "hdnPrdctNameval").id
            + "&PrdctFreqval=" + document.getElementById(strContent + "hdnPrctFreqval").id + "&Considerval=" + document.getElementById(strContent + "hdnConsiderval").id
            + "&Typeval=" + document.getElementById(strContent + "hdnTypeval").id + "&LOBval=" + document.getElementById(strContent + "hdnLOBval").id +
            "&LOB=" + document.getElementById(strContent + "hdnLOB").id + "&Wght=" + document.getElementById(strContent + "hdnWghtg").id
            + "&mdlpopup=mdlViewBID";
        }

        function funPopUpLOB(div) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopStdLOBDef.aspx?PrdctName=" + document.getElementById(strContent + "hdnPrdctName").id
            + "&PrdctFreq=" + document.getElementById(strContent + "hdnPrctFreq").id + "&Consider=" + document.getElementById(strContent + "hdnConsider").id
            + "&Type=" + document.getElementById(strContent + "hdnType").id + "&PrdctNameval=" + document.getElementById(strContent + "hdnPrdctNameval").id
            + "&PrdctFreqval=" + document.getElementById(strContent + "hdnPrctFreqval").id + "&Considerval=" + document.getElementById(strContent + "hdnConsiderval").id
            + "&Typeval=" + document.getElementById(strContent + "hdnTypeval").id + "&LOBval=" + document.getElementById(strContent + "hdnLOBval").id +
            "&LOB=" + document.getElementById(strContent + "hdnLOB").id + "&Wght=" + document.getElementById(strContent + "hdnWghtg").id
            + "&mdlpopup=mdlViewBID";
        }

        function btnctn() {
            debugger;
            $("#<%= btnctn.ClientID %>").click();
            return false;
        }
<%--        function btnaddMPL() {
            debugger;
            $("#<%= btnAddMPL.ClientID %>").click();
            return false;
        }--%>
        function confPromptBox()
        {
            var resp = confirm("Please select Action Description")
            if (resp==true)
            {

                location.replace(location.href);
                
            }
            else
            {
                
            }

        }
        function ClosePopup() {
            window.parent.$find('mdldatdefsetupBID').hide();
        }
    </script>
    <style type="text/css">
        .multiselect {
            overflow:hidden;
            width: 300px;
        }
        .checkbox, .radio {
            padding-right: 35px;
            padding-left: 6px;
            padding-top: 0px;
            padding-bottom: 0px;
        }
        .form-control {
            display:none;
        }
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }
        
         
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
        }*/
        .new_text_new {
            color: #066de7;
        }

        #chkKpiMst {
            margin-right: 10px;
        }

            #chkKpiMst + label {
                margin-right: 10px;
            }
    </style>
    <center>
        <div id="divcmpmain" runat="server" style="width: 97%;" class="panel">
            <div id="tblHeadare" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;font-size:19px">
                        <asp:Label ID="lblhdr" Text="Compensation Details" runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg" class="glyphicon glyphicon-chevron-down" style="float: right; color:  #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" class="panel-body" style="width: 96%;text-align:left;white-space:nowrap;">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="1"></asp:Label>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompDesc1Val" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="2"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompDesc2" Text="Compensation Description" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompDesc2Val" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAccCyc" Text="Accumulation Cycle" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblAccCycVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAccYr" Text="Accumulation Year" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblAccYrVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompTyp" Text="Compensation Type" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCompTypVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAccCycle" Text="Accural Cycle" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblAccCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblReleaseCycle" Text="Release Cycle" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblReleaseCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCntstCd" Text="Contestant Code" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblCntstCdVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="1"></asp:Label>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblSlsChnl" Text="Sales Channel" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblSlsChnlVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="2"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblSbCls" Text="Sub Class" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblSbClsVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="1"></asp:Label>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMemTyp" Text="Member Type" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblMemTypVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="2"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblFinYr" Text="Financial Year" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblFinYrVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="1"></asp:Label>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblVer" Text="Version" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblVerVal" runat="server" CssClass="form-control-static new_text_new"
                            TabIndex="2"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblEffDtFrm" Text="Effective From" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblEffDtFrmVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblEffDtTo" Text="Effective To" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="lblEffDtToVal" runat="server" CssClass="form-control-static new_text_new" />
                    </div>
                </div>
            </div>
        </div>
        <div id="DivKpi" runat="server" style="width: 97%; display: none;" class="panel">
            <div id="Div13" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpihdr','Img1');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;font-size:19px">
                       <%-- <span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>&nbsp;--%>
                        <asp:Label ID="Label1" Text="KPI Details" runat="server" />
                    </div>
                    <div class="col-sm-2">
                          <span id="Img1" class="glyphicon glyphicon-chevron-down" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divkpihdr" runat="server" style="width: 100%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="Label2" Text="KPI Code" runat="server" CssClass="control-label" />
                        </div>
                            <div class="col-sm-3">
                            <asp:Label ID="lblKpiCode" runat="server" CssClass="form-control-static new_text_new"
                                TabIndex="1"></asp:Label>
                        </div>
                            <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="Label4" Text="KPI Description" runat="server" CssClass="control-label" />
                        </div>
                            <div class="col-sm-3">
                            <asp:Label ID="lblKpiDesc" runat="server" CssClass="form-control-static new_text_new"
                                TabIndex="2"></asp:Label>
                        </div>
                    </div>
            </div>
        </div>
       
         <div class="row" style="margin-bottom: 2px;" id="rowselect" runat="server">
           <div class="col-sm-6" style="text-align: right"></div>
                        <div class="col-sm-2" style="text-align: right;font-size:14px;">
                            <asp:Label ID="Label5" Text="Select Period" runat="server" CssClass="control-label" />
                        </div>
                        <div class="col-sm-2" style="text-align: left;margin-top:-9px;">
                            <asp:DropDownList ID="ddlselect"  runat="server" AutoPostBack="true" CssClass="form-control" Enabled="false">
                            <asp:ListItem Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2" style="text-align: left">
                            <asp:LinkButton ID="lnkSplit"  runat="server" Text="Split" OnClick="lnkSplit_Click" style="font-size:15px;">
                            </asp:LinkButton>
                        </div>
                        </div>
                         <br />
        <div id="divsnd"  runat="server" style="width: 97%;" class="panel">
            <div id="Table5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divStdDefLOBDtls','Img3');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;font-size:19px">
                        <%--<span class="glyphicon glyphicon-chevron-down" style="color: Orange;"></span>&nbsp;--%>
                        <asp:Label ID="Label6" Text="Standard Definition Details" runat="server" />
                    </div>
                    <div class="col-sm-2">
                          <span id="Img3" class="glyphicon glyphicon-chevron-down" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
          <div id="divStdDefLOBDtls" runat="server" style="width: 100%;" >
           <div id="div19" runat="server" class="panel-body" >
            <div class="row">
              <div class="col-sm-3" style="text-align: right">
                <asp:Label ID="lblSeltKPI" Text="Select KPI" runat="server" Visible="false" CssClass="control-label" />                                    
              </div>
              <div class="col-sm-3" style="text-align: left">
                <asp:DropDownList runat="server" ID="ddlSeltKPI"  AutoPostBack="true" OnSelectedIndexChanged="ddlSeltKPI_SelectedIndexChanged"
                     CssClass="form-control">                                                             
                </asp:DropDownList>
              </div>
            </div>
           </div>
                <div id="div9" runat="server" class="panel-body" >
                    <h3 class="form-section" style="text-align: left;">
                        Date related definitions</h3>
                    <div id="div6" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgDateDef" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                    OnRowDataBound="dgDateDef_RowDataBound" AllowPaging="true" AutoGenerateColumns="false">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
<%--                                        <asp:TemplateField HeaderText="Business Type" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="BUSI_TYPE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBusiType" runat="server" Text='<%# Bind("BUSI_TYPE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnBusiType" runat="server" Value='<%# Bind("BUSI_TYPE_CODE")%>'>
                                                </asp:HiddenField>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Date Type" HeaderStyle-HorizontalAlign="Left" SortExpression="DESC01">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateType" runat="server" Text='<%# Bind("DESC01")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnDateName" runat="server" Value='<%# Bind("DESC01")%>' />
                                                <asp:HiddenField ID="hdnDateType" runat="server" Value='<%# Bind("DESC01")%>' />
                                                <asp:HiddenField ID="HdnRecId" runat="server" Value='<%# Bind("RecId")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Eff From " HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="DateEffectiveFrom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffFrom" runat="server" Text='<%# Bind("DateEffectiveFrom")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnDateEffFrom" runat="server" Value='<%# Bind("DateEffectiveFrom")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Eff To" HeaderStyle-HorizontalAlign="Left" SortExpression="DateEffectiveTo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffTo" runat="server" Text='<%# Bind("DateEffectiveTo")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnDateEffTo" runat="server" Value='<%# Bind("DateEffectiveTo")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
<%--                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Remarks" SortExpression="Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remark")%>' />
                                                <asp:HiddenField ID="hdnRemarks" runat="server" Value='<%# Bind("Remark")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" SortExpression="WEIGHTAGE">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="dgDateDefedit" runat="server" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="dgDateDefDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="dgDateDefDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <center>
                        <div id="div7" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <center>
                                                        <asp:Button ID="btnprevStdLOB" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                        <asp:TextBox runat="server" ID="txtStdLOBPage" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextStdLOB" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                            Enabled="false" />
                                                    </center>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </center>
                        <div id="Table1" runat="server"  class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAddDateReleted" runat="server" CssClass="btn btn-sample"
                                    Enabled="true" >
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                    </asp:LinkButton>
                                <asp:LinkButton ID="btnSaveStdLOB" runat="server" CssClass="btn btn-sample"
                                    Enabled="true" Visible="false">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                    </asp:LinkButton>
                                <asp:Button ID="btnLOB" runat="server" ClientIDMode="Static" Style="display: none;" />
                                <asp:Button ID="Button11" Text="ADD" runat="server" ClientIDMode="Static" Width="100px"
                                    Style="display: none;" OnClick="Button11_Click" />
                    </div>
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div id="divAgtDt" runat="server" style="width: 97%; padding: 10px;" visible="false" class="panel-body">
                            <h3 class="form-section" style="text-align: left;">
                                Member Related definitions</h3>
                            <div id="div10" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                class="table-scrollable">
                                <asp:GridView ID="dgMemDt" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                    AllowPaging="true" AutoGenerateColumns="false">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Date Type" HeaderStyle-HorizontalAlign="Left" SortExpression="DESC01">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateType" runat="server" Text='<%# Bind("DESC01")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnDateName" runat="server" Value='<%# Bind("DESC01")%>' />
                                                <asp:HiddenField ID="hdnDateType" runat="server" Value='<%# Bind("DESC01")%>' />
                                                <asp:HiddenField ID="HdnRecId" runat="server" Value='<%# Bind("RecId")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Eff From " HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="DateEffectiveFrom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffFrom" runat="server" Text='<%# Bind("DateEffectiveFrom")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnDateEffFrom" runat="server" Value='<%# Bind("DateEffectiveFrom")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Eff To" HeaderStyle-HorizontalAlign="Left" SortExpression="DateEffectiveTo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffTo" runat="server" Text='<%# Bind("DateEffectiveTo")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnDateEffTo" runat="server" Value='<%# Bind("DateEffectiveTo")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Remarks" SortExpression="Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remark")%>' />
                                                <asp:HiddenField ID="hdnRemarks" runat="server" Value='<%# Bind("Remark")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" SortExpression="WEIGHTAGE">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="dgDateDefedit" runat="server" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="lnkDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <center>
                                <div id="div11" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevmem" Text="<" OnClick="btnprevmem_Click" CssClass="form-submit-button"
                                                                runat="server" Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px;
                                                                background-repeat: no-repeat; background-color: transparent; float: left; margin: 0;
                                                                height: 30px;" />
                                                            <asp:TextBox runat="server" ID="txtMemPage" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextmem" Text=">" OnClick="btnnextmem_Click" CssClass="form-submit-button"
                                                                runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </center>
                            <div id="Table4" runat="server" class="row" style="margin-top: 12px;">
                                <div class="col-sm-12" align="center">
                                    <asp:LinkButton ID="btnAddMem" runat="server" CssClass="btn btn-sample" Enabled="true">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnAddMemCncl" runat="server" CssClass="btn btn-sample" Enabled="true"
                                        Visible="false">
                                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                    </asp:LinkButton>
                                    <asp:Button ID="Button6" runat="server" ClientIDMode="Static" Style="display: none;" />
                                    <asp:Button ID="Button7" Text="ADD" runat="server" ClientIDMode="Static" Style="display: none;"
                                        Width="100px" OnClick="Button7_Click" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div id="div1" runat="server" style="width: 97%; padding: 10px; display: block;" class="panel-body">
                    <h3 class="form-section" style="text-align: left;">
                        Premium frequency weightage definitions</h3>
                    <div id="div2" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdPremiumWeight" runat="server" CssClass="footable"
                                    PageSize="10" AllowSorting="True" OnSorting="GrdPremiumWeight_Sorting" AllowPaging="true"
                                    AutoGenerateColumns="false" OnRowDataBound="GrdPremiumWeight_RowDataBound">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Frequency Type" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="FrequencyTypeDesc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrequencyType" runat="server" Text='<%# Bind("FrequencyTypeDesc")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnFrequencyName" runat="server" Value='<%# Bind("FrequencyTypeDesc")%>' />
                                                <asp:HiddenField ID="HdnRecId" runat="server" Value='<%# Bind("RecId")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Consider" HeaderStyle-HorizontalAlign="Left" SortExpression="Consider">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsider" runat="server" Text='<%# Bind("Consider")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnConsider" runat="server" Value='<%# Bind("Consider")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left" SortExpression="TypeDesc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("TypeDesc")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnType" runat="server" Value='<%# Bind("TypeDesc")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Weightage" HeaderStyle-HorizontalAlign="Left" SortExpression="Weightage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWeightage" runat="server" Text='<%# Bind("Weightage")%>' />
                                                <asp:HiddenField ID="hdnWeightage" runat="server" Value='<%# Bind("Weightage")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="GrdPremiumWeightEdit" runat="server" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="GrdPremiumWeightDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="GrdPremiumWeightDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <center>
                        <div id="div3" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnpreGrdPremiumW" Text="<" OnClick="btnpreGrdPremiumW_Click" CssClass="form-submit-button"
                                                        runat="server" Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px;
                                                        background-repeat: no-repeat; background-color: transparent; float: left; margin: 0;
                                                        height: 30px;" />
                                                    <asp:TextBox runat="server" ID="txtpreGrdPremiumW" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnextGrdPremiumW" Text=">" OnClick="btnnextGrdPremiumW_Click" CssClass="form-submit-button"
                                                        runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                        Enabled="false" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </center>
                    <div id="Table2" runat="server" class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="BtnPremium" runat="server" CssClass="btn btn-sample" Enabled="true">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add            
                            </asp:LinkButton>
                            <asp:LinkButton ID="Button4" runat="server" CssClass="btn btn-sample"
                                Enabled="true" Visible="false">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                            </asp:LinkButton>
                            <asp:Button ID="Button5" runat="server" ClientIDMode="Static" Style="display: none;" />
                            <asp:Button ID="Button3" Text="ADD" runat="server" ClientIDMode="Static" Style="display: none;"
                                Width="100px" OnClick="Button3_Click" />
                        </div>
                    </div>
                </div>

                <div id="div12" runat="server" style="width: 97%; padding: 10px; display: block;" class="panel-body">
                    <h3 class="form-section" style="text-align: left;">
                        VPSC & EKYC Weightage Definitions
                    </h3>
                    <div id="div14" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdVPSWeight" runat="server" CssClass="footable"
                                    PageSize="10" AllowSorting="false" AllowPaging="true"
                                    AutoGenerateColumns="false" OnRowDataBound="GrdVPSWeight_RowDataBound"> <%--OnSorting="GrdPremiumWeight_Sorting"--%>
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Record No." HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="RecId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrequencyType" runat="server" Text='<%# Bind("RecId")%>'></asp:Label>
                                                <%--<asp:HiddenField ID="hdnFrequencyName" runat="server" Value='<%# Bind("FrequencyTypeDesc")%>' />--%>
                                                <asp:HiddenField ID="HdnRecId" runat="server" Value='<%# Bind("RecId")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IS VPSC" HeaderStyle-HorizontalAlign="Left" SortExpression="ISVPSC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsider" runat="server" Text='<%# Bind("ISVPSC")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnConsider" runat="server" Value='<%# Bind("ISVPSC")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IS EKYC" HeaderStyle-HorizontalAlign="Left" SortExpression="ISEKYC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("ISEKYC")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnType" runat="server" Value='<%# Bind("ISEKYC")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Weightage" HeaderStyle-HorizontalAlign="Left" SortExpression="Weightage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWeightage" runat="server" Text='<%# Bind("Weightage")%>' />
                                                <asp:HiddenField ID="hdnWeightage" runat="server" Value='<%# Bind("Weightage")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="GrdVPSCWeightEdit" runat="server" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="GrdVPSCWeightDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="GrdVPSCWeightDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <center>
                        <div id="div15" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="Button1" Text="<" OnClick="btnpreGrdPremiumW_Click" CssClass="form-submit-button"
                                                        runat="server" Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px;
                                                        background-repeat: no-repeat; background-color: transparent; float: left; margin: 0;
                                                        height: 30px;" />
                                                    <asp:TextBox runat="server" ID="TextBox1" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="Button2" Text=">" OnClick="btnnextGrdPremiumW_Click" CssClass="form-submit-button"
                                                        runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                        Enabled="false" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </center>
                    <div id="Div16" runat="server" class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="BtnVPSCAdd" runat="server" CssClass="btn btn-sample" Enabled="true">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add            
                            </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-sample"
                                Enabled="true" Visible="false">
                                        <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                            </asp:LinkButton>
                            <asp:Button ID="Button8" runat="server" ClientIDMode="Static" Style="display: none;" />
                            <asp:Button ID="Button12" Text="ADD" runat="server" ClientIDMode="Static" Style="display: none;"
                                Width="100px" OnClick="Button3_Click" />
                        </div>
                    </div>
                </div>

                <div id="div4" runat="server" style="width: 97%; padding: 10px; display: none;" class="panel-body">
                    <h3 class="form-section" style="text-align: left;">Product level weightage definitions</h3>
                    <div class="row" id="divHie" runat="server">
                        <div class="col-sm-3" style="display:flex">
                            <div>
                                <asp:checkbox text="Inherit From KPI Master" runat="server" ID="chkKpiMst" ClientIDMode="Static"/>
                            </div>
                        </div>
                         <div class="col-sm-3">
                             <asp:Label ID="Label7" Text="Split from Parent KPI" runat="server" CssClass="control-label" />
                         </div>
                        <%--added By pratik--%>
                        <div class="col-sm-3">
                            <div>
                                <%--<asp:checkbox text="Split From Parent Mapcode" runat="server" ID="chkSplit" ClientIDMode="Static"/>--%>

                                <asp:dropdownlist runat="server" ID="ddlSplit" CssClass="form-control">
                                    <asp:listitem text="Yes" Value="1" />
                                    <asp:listitem text="No" Value="0" />
                                </asp:dropdownlist>
                            </div>
                        </div>
                        <%--added By pratik--%>
                        <div class="col-sm-4">
                             <asp:Label ID="Label8" Text="Inherited Action From Master Setup" runat="server" CssClass="control-label" />
                         </div>
                        <%--added By Abuzar--%>
                        <div class="col-sm-4">
                            <div>
                                <%--<asp:checkbox text="Split From Parent Mapcode" runat="server" ID="chkSplit" ClientIDMode="Static"/>--%>

                                <asp:dropdownlist runat="server" ID="ddlinheritedProd" CssClass="form-control">
                                </asp:dropdownlist>
                            </div>
                        </div>
                        <%--added By Abuzar--%>
<%--                         <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAddProdweightages" runat="server" CssClass="btn btn-sample"
                                    Enabled="true" OnClick="btnAddProdweightages_click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                    </asp:LinkButton>
                         </div>--%>
                         <%--added By Abuzar--%>
                    </div>
<%--                    <div id="div21" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgProdweightages" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                    OnRowDataBound="dgProdweightages_RowDataBound" AllowPaging="true" AutoGenerateColumns="false">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="PARENT MAP CODE" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="PARENT_MAP_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparentmapcode" runat="server" Text='<%# Bind("PARENT_MAP_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnparentmapcode" runat="server" Value='<%# Bind("PARENT_MAP_CODE")%>'>
                                                </asp:HiddenField>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MAP CODE" HeaderStyle-HorizontalAlign="Left" SortExpression="MAP_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmapcode" runat="server" Text='<%# Bind("MAP_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnmapcode" runat="server" Value='<%# Bind("MAP_CODE")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION NO " HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="ACT_NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActionNo" runat="server" Text='<%# Bind("ACT_NO")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnActionNo" runat="server" Value='<%# Bind("ACT_NO")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION DESCRIPTION" HeaderStyle-HorizontalAlign="Left" SortExpression="ACT_DESC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActdesc" runat="server" Text='<%# Bind("ACT_DESC")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnActdesc" runat="server" Value='<%# Bind("ACT_DESC")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
<%--                                                <asp:LinkButton ID="DeleteGrdProductweight" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="DeleteGrdProductweight_Click"></asp:LinkButton>--%>
<%--                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>  
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                        <div id="div20" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                <ContentTemplate>
                                                    <center>--%>
<%--                                                        <asp:Button ID="btnprevinhrtprodweight" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevinhrtprodweight_Click"/>
                                                        <asp:TextBox runat="server" ID="txtpginhrtprodweight" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextinhrtprodweight" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                            Enabled="false" OnClick="btnnextinhrtprodweight_Click"/>--%>
                                                    </center>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    <div id="div5" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdProduct" runat="server" CssClass="footable"
                                    PageSize="10" AllowSorting="True" OnSorting="GrdProduct_Sorting" AllowPaging="true"
                                    AutoGenerateColumns="false" OnRowDataBound="GrdProduct_RowDataBound">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left" SortExpression="ProductCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductCode" runat="server" Text='<%# Bind("ProductCode")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnProductCode" runat="server" Value='<%# Bind("ProductCode")%>' />
                                                <asp:HiddenField ID="HdnRecId" runat="server" Value='<%# Bind("RecId")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>   <%--0--%>
                                        <asp:TemplateField HeaderText="Product Class" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="ProdClass">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductCls" runat="server" Text='<%# Bind("ProdClass")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnProductCls" runat="server" Value='<%# Bind("ProdClass")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:TemplateField>      <%-- 1--%>
                                        <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" SortExpression="ProductName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnProductName" runat="server" Value='<%# Bind("ProductName")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:TemplateField>       <%-- 2--%>
                                        <asp:TemplateField HeaderText="Plan Code" HeaderStyle-HorizontalAlign="Left" SortExpression="PlanCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlaneCode" runat="server" Text='<%# Bind("PlanCode")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPlaneCode" runat="server" Value='<%# Bind("PlanCode")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:TemplateField>            <%--3--%>
                                        <asp:TemplateField HeaderText="Frequency" HeaderStyle-HorizontalAlign="Left" SortExpression="FrequencyTypeDesc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrequency" runat="server" Text='<%# Bind("FrequencyTypeDesc")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnFrequency" runat="server" Value='<%# Bind("FrequencyTypeDesc")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>              <%-- 4--%>
                                        <asp:TemplateField HeaderText="Pay Mode" HeaderStyle-HorizontalAlign="Left" SortExpression="PayMode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPayMode" runat="server" Text='<%# Bind("PayMode")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPayMode" runat="server" Value='<%# Bind("PayMode")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:TemplateField>                   <%--5--%>
                                        <asp:TemplateField HeaderText="Policy Term From" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="PolicyTermFrom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPolicyTermFrom" runat="server" Text='<%# Bind("PolicyTermFrom")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPolicyTermFrom" runat="server" Value='<%# Bind("PolicyTermTo")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                     <%--6--%>
                                        <asp:TemplateField HeaderText="Policy Term To" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="PolicyTermTo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPolicyTermTo" runat="server" Text='<%# Bind("PolicyTermTo")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPolicyTermTo" runat="server" Value='<%# Bind("PolicyTermTo")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                         <%--7--%>
                                        <asp:TemplateField HeaderText="Pay Term From" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="PayTermFrom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPayTermFrom" runat="server" Text='<%# Bind("PayTermFrom")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPayTermFrom" runat="server" Value='<%# Bind("PayTermFrom")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                           <%--8--%>
                                        <asp:TemplateField HeaderText="Pay Term To" HeaderStyle-HorizontalAlign="Left" SortExpression="PayTermTo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPayTermTo" runat="server" Text='<%# Bind("PayTermTo")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPayTermTo" runat="server" Value='<%# Bind("PayTermTo")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                <%--9--%>
                                        <asp:TemplateField HeaderText="Premium From" HeaderStyle-HorizontalAlign="Left" SortExpression="PremiumFrom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPremiumFrom" runat="server" Text='<%# Bind("PremiumFrom")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPremiumFrom" runat="server" Value='<%# Bind("PremiumFrom")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                  <%--10--%>
                                        <asp:TemplateField HeaderText="Premium To" HeaderStyle-HorizontalAlign="Left" SortExpression="PremiumTo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPremiumTo" runat="server" Text='<%# Bind("PremiumTo")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPremiumTo" runat="server" Value='<%# Bind("PremiumTo")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                     <%-- 11--%>
                                        <asp:TemplateField HeaderText="Premium Type" HeaderStyle-HorizontalAlign="Left" SortExpression="PremiumType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPremiumType" runat="server" Text='<%# Bind("PremiumTypeDesc")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnPremiumType" runat="server" Value='<%# Bind("PremiumType")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:TemplateField>                      <%--12--%>
                                        <asp:TemplateField HeaderText="Consider" HeaderStyle-HorizontalAlign="Left" SortExpression="Consider">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsider" runat="server" Text='<%# Bind("Consider")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnConsider" runat="server" Value='<%# Bind("Consider")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:TemplateField>                     <%--13--%>
                                        <asp:TemplateField HeaderText="Weightage" HeaderStyle-HorizontalAlign="Left" SortExpression="Weightage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWeightage" runat="server" Text='<%# Bind("Weightage")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnWeightage" runat="server" Value='<%# Bind("Weightage")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                           <%--14--%>

                                          <asp:TemplateField HeaderText="Effective From Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Weightage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffectiveFrom" runat="server" Text='<%# Bind("DateEffectiveFrom")%>'></asp:Label>
<%--                                                <asp:HiddenField ID="hdnWeightage" runat="server" Value='<%# Bind("Weightage")%>' />--%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                           <%--14--%>


                                        <asp:TemplateField HeaderText="Effective To Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Weightage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateEffectiveTo" runat="server" Text='<%# Bind("DateEffectiveTo")%>'></asp:Label>
<%--                                                <asp:HiddenField ID="hdnWeightage" runat="server" Value='<%# Bind("Weightage")%>' />--%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                           <%--14--%>


                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="EditGrdProduct" runat="server" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                              <%--  15--%>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="DeleteGrdProduct" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="DeleteGrdProduct_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>                             <%--16--%> 
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <center>
                        <div id="div8" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnpreGrdProduct" Text="<" OnClick="btnpreGrdProduct_Click" CssClass="form-submit-button"
                                                        runat="server" Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px;
                                                        background-repeat: no-repeat; background-color: transparent; float: left; margin: 0;
                                                        height: 30px;" />
                                                    <asp:TextBox runat="server" ID="txtGrdProduct" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnextGrdProduct" Text=">" OnClick="btnnextGrdProduct_Click" CssClass="form-submit-button"
                                                        runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                        Enabled="false" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                        <div id="Table3" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnproduct" runat="server" CssClass="btn btn-sample" Enabled="true">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color:White"></span> Add
                                </asp:LinkButton>

                                <asp:Button ID="btnctn" runat="server" CssClass="btn btn-sample"  style="display:none"  OnClick="btnproduct_Click">
                                        
                                </asp:Button>
                              <%--  <asp:LinkButton ID="btnDwnUpd" runat="server" CssClass="btn btn-sample" Enabled="true" OnClientClick="funPopUpRulSetProductBulk()">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color:White"></span> Bulk Upload
                                </asp:LinkButton>--%>

                             
                                <asp:LinkButton ID="btn_Download" runat="server" CssClass="btn btn-sample" Enabled="true"  OnClick="btn_Download_Click">
                                        <span class="glyphicon glyphicon-download" style="color:White"></span> Download Sample File
                                </asp:LinkButton>

                                   <button id="btnDwnUpd" type="button" class="btn btn-sample" onclick="javascript: return fnCallPOP();" runat="server">
                                            <span class="glyphicon glyphicon-upload" style="color: White;"></span> Bulk Upload
                                   </button>

                                <asp:LinkButton ID="btnDownloadData" runat="server" CssClass="btn btn-sample" Enabled="true"  OnClick="btnDownloadData_Click">
                                        <span class="glyphicon glyphicon-cloud-download" style="color:White"></span> Download Data
                                </asp:LinkButton>


                                <asp:LinkButton ID="Button9" runat="server" CssClass="btn btn-sample" Enabled="true"
                                    Visible="false">
                                            <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
                                <asp:Button ID="Button10" runat="server" ClientIDMode="Static" OnClick="Button10_Click"
                                    Style="display: none;" />
                            </div>
                        </div>
                    </center>
                </div>

                 

                <div id="div17" runat="server" style="width: 97%; padding: 10px; display: none;"   class="panel-body">
                    <h3 class="form-section" style="text-align: left;">Include Exclude Definitions</h3>
                        <div class="col-sm-4">
                             <asp:Label ID="Label9" Text="Inherited Action From Master Setup" runat="server" CssClass="control-label" />
                         </div>
                        <%--added By Abuzar--%>
                        <div class="col-sm-4">
                            <div>
                                <%--<asp:checkbox text="Split From Parent Mapcode" runat="server" ID="chkSplit" ClientIDMode="Static"/>--%>

                                <asp:dropdownlist runat="server" ID="ddlinheritedMPL" CssClass="form-control">
                                </asp:dropdownlist>
                            </div>
                        </div>
                        <%--added By Abuzar--%>
<%--                        <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAddMPL" runat="server" CssClass="btn btn-sample"
                                    Enabled="true" OnClick="btnAddMPL_click">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                    </asp:LinkButton>
                         </div>--%>
<%--                      <div id="div19" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                        class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgMPL" runat="server" CssClass="footable" PageSize="10" AllowSorting="True"
                                    OnRowDataBound="dgMPL_RowDataBound" AllowPaging="true" AutoGenerateColumns="false">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="PARENT MAP CODE" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="PARENT_MAP_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparentmapcode" runat="server" Text='<%# Bind("PARENT_MAP_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnparentmapcode" runat="server" Value='<%# Bind("PARENT_MAP_CODE")%>'>
                                                </asp:HiddenField>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MAP CODE" HeaderStyle-HorizontalAlign="Left" SortExpression="MAP_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmapcode" runat="server" Text='<%# Bind("MAP_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnmapcode" runat="server" Value='<%# Bind("MAP_CODE")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION NO " HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="ACT_NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActionNo" runat="server" Text='<%# Bind("ACT_NO")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnActionNo" runat="server" Value='<%# Bind("ACT_NO")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION DESCRIPTION" HeaderStyle-HorizontalAlign="Left" SortExpression="ACT_DESC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActdesc" runat="server" Text='<%# Bind("ACT_DESC")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnActdesc" runat="server" Value='<%# Bind("ACT_DESC")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
<%--                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="DeleteGrdMPL" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                    OnClick="DeleteGrdMPL_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
<%--                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>  
                        <div id="div22" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                <ContentTemplate>
                                                    <center>--%>
<%--                                                        <asp:Button ID="btnprevinhrtmpl" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevinhrtmpl_Click"/>
                                                        <asp:TextBox runat="server" ID="txtpginhrtmpl" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextinhrtmpl" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                            Enabled="false" OnClick="btnnextinhrtmpl_Click"/>--%>
                                                    </center>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>                                         
                    <%--added By Abuzar--%>
                    <div class="row" id="div18" runat="server">
                                <asp:Button ID="btnMPL" runat="server" CssClass="btn btn-sample"   Text="Continue For Include Exclude Setup" OnClick="btnMPL_Click" />
                        </div>
                    </div>
           <div id="divTableConcat" runat="server" class="">
                            
           </div>
             <%-- <div id="divstd" runat="server" style="width:793px;height:166px;">
                  <img src="../../../../image/Saim_Info_banner.gif" />
           </div>--%>
            </div>
           <div id="Table6" runat="server" class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">
                    <asp:LinkButton ID="btnCancelAll" runat="server" CssClass="btn btn-sample" Enabled="true" 
                        OnClick="btnCancelAll_Click" >
                                <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color: White;"></span> Back    
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample"
                        Visible="false" OnClientClick="ClosePopup();">
                                <span class="glyphicon glyphicon-remove" style="color: White;"></span> Cancel
                    </asp:LinkButton>
                    <asp:HiddenField ID="hdnBackUrl" runat="server"/>                
                </div>
            </div>
        </div>

        <div id="dvimagebanner"  runat="server" style="width: 1212px; margin-left:-85px;"  class="row">
        <%--<div id="divstd" class="col-sm-6" runat="server" style="width:793px;height:166px;">--%>
                    <div id="div21" class="col-sm-8" runat="server" style="float:left;" >
                  <img src="../../../../image/Saim_Info_banner.gif" />
           </div>
            <div class="col-sm-2" style="float:left;">
                     <img src="../../../../image/important_Banner.jpg" />
            </div>
            <div class="col-sm-2" style="float:left;">
                 <img src="../../../../image/SAIM_Messages.png" />
                </div>
            <div style="clear:both;"></div>
        </div>
         
        <asp:Panel runat="server" Height="380px" Width="1000px" ID="pnlMdl" display="none"
            Style="text-align: center; padding: 5px;" CssClass="panel">
            <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
                display="none" style="height: 100%;"></iframe>
        </asp:Panel>
        <asp:Panel runat="server" Height="380px" Width="1000px" ID="Panel1" display="none"
            Style="text-align: center;" CssClass="panel panel-success">
            <iframe runat="server" id="Iframe1" scrolling="yes" width="100%" frameborder="0" display="none"
                style="height: 100%;"></iframe>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExt1" BehaviorID="ModalPopupExtend1"
            DropShadow="false" TargetControlID="Label3" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Label runat="server" ID="Label3" Style="display: none"></asp:Label>
        <asp:Label runat="server" ID="lbl1" Style="display: none"></asp:Label>
        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
            DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
    </center>
    <script src="../../../../assets/scripts/jquery.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap.min.js"></script>
    <script src="../../../../assets/scripts/bootstrap-multiselect.js"></script>
    <script>
        function btnSaveRprt(PAR_MAP_CODE, NEW_MAP_CODE,ACT_NO,optionSelIndex) {
            debugger;
            var obj = {}
            var object = {}
            var dataObj = [];
            //var ActNo = getQueryVal('uid', window.location);
            object["INS_PARENT_MAP_CODE"] = PAR_MAP_CODE;
            object["INS_MAP_CODE"] = NEW_MAP_CODE;
            object["INS_ACT_TYP"] = ACT_NO;
            object["INS_ACT_NO"] = optionSelIndex;

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }

            $.ajax({
                type: "POST",
                url: "FFContestPageStdDef.aspx/InsActdta",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    debugger;
                    if (response.d == "0") {
                        //alert("Action mapping has been saved successfully .");
                        //location.reload(true);
                    }
                    else {
                        alert("Something went wrong.");
                    }
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });

        }
        function confPromptBoxforDynDel(MAP_CODE, ACT_NO) {
            var resp = confirm("Are you sure you want to Delete? ")
            if (resp == true) {
                var MAP_CODE = MAP_CODE;
                var ACT_NO = ACT_NO;
                btnDelRprt(MAP_CODE, ACT_NO)
                //location.replace(location.href);
                //alert("you have selected to delete.");
            }
            else {

                //alert("Horray!!!");
                location.replace(location.href);
            }

        }
        function btnDelRprt(MAP_CODE, ACT_NO) {
            debugger;
            var obj = {}
            var object = {}
            var dataObj = [];
            //var ActNo = getQueryVal('uid', window.location);
            object["DEL_MAP_CODE"] = MAP_CODE;
            object["DEL_ACT_NO"] = ACT_NO;

            dataObj.push(object);
            sendObj = {
                data: (dataObj)
            }

            $.ajax({
                type: "POST",
                url: "FFContestPageStdDef.aspx/delActdta",
                data: JSON.stringify(sendObj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    debugger;
                    if (response.d == "0") {
                        alert("Action mapping has been deleted successfully .");
                        location.reload(true);
                    }
                    else {
                        alert("Something went wrong.");
                    }
                },
                failure: function (response) {
                    alert("Something went wrong.");
                }
            });

        }
    </script>
</asp:Content>