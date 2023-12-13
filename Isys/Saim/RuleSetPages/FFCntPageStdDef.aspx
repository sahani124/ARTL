<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FFCntPageStdDef.aspx.cs" Inherits="Application_Isys_Saim_RuleSetPages_FFCntPageStdDef" %>

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
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
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



        function funPopUpRulSet(cmpcode, cntstcd, rultyp, Mapcode, RuleId, dttyp, lblfrm, lblto) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "FFCntDateRelatedDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&MapCode=" + Mapcode + "&RuleId=" + RuleId + "&dttyp=" + dttyp + "&lblfrm=" + document.getElementById(strContent + "lblEffDtFrmVal").innerText
            + "&lblto=" + document.getElementById(strContent + "lblEffDtToVal").innerText + "&mdlpopup=mdlViewBID";
        }

        function funPopUpRulSetPremium(cmpcode, cntstcd, rultyp, Mapcode, RuleId) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PremiumFreeqDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&RuleId=" + RuleId + "&MapCode=" + Mapcode + "&mdlpopup=mdlViewBID";
        }

        function funPopUpRulSetVPSC(cmpcode, cntstcd, RuleSet, Cycle, rultyp, Mapcode, RuleId) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "FFCntMemFilterDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&RuleId=" + RuleId + "&MapCode=" + Mapcode + "&RULE_SET_KEY=" + RuleSet + "&CYCLE_CODE=" + Cycle + "&mdlpopup=mdlViewBID";
        }


        function funPopUpRulSetProduct(cmpcode, cntstcd, rultyp, Mapcode, RuleId) {
            var strContent = "ctl00_ContentPlaceHolder1_Iframe1";
            $find("ModalPopupExtend1").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "ProductDef.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&RuleId=" + RuleId + "&MapCode=" + Mapcode + "&mdlpopup=ModalPopupExtend1";
        }


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



        //+"&PrdctNameval=" + document.getElementById(strContent + "hdnPrdctName").value + "&PrdctFreqval=" + document.getElementById(strContent + "hdnPrctFreq").value
        //            + "&Considerval=" + document.getElementById(strContent + "hdnConsider").value + "&Typeval=" + document.getElementById(strContent + "hdnType").value
        //            + "&Wghtval=" + document.getElementById(strContent + "hdnWghtg").value 
    </script>
    <style type="text/css">
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
    </style>
    <center>
        <div id="divcmpmain" runat="server" style="width: 97%;" class="panel">
            <div id="tblHeadare" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;font-size:19px">
                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                        <asp:Label ID="lblhdr" Text="Compensation Details" runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
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
        <br />
         <div class="row" style="margin-bottom: 2px;">
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
        <div id="divsnd" runat="server" style="width: 97%;" class="panel">
            <div id="Table5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divStdDefLOBDtls','Img3');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;font-size:19px">
                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                        <asp:Label ID="Label6" Text="Standard Definition Details" runat="server" />
                    </div>
                    <div class="col-sm-2">
                          <span id="Img3" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divStdDefLOBDtls" runat="server" style="width: 100%;" >
                <div id="div9" runat="server" class="panel-body" >
                    <h3 class="form-section" style="text-align: left;">
                        Date related definitions
                    </h3>
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
                                        <asp:TemplateField HeaderText="Business Type" HeaderStyle-HorizontalAlign="Left"
                                            SortExpression="BUSI_TYPE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBusiType" runat="server" Text='<%# Bind("BUSI_TYPE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnBusiType" runat="server" Value='<%# Bind("BUSI_TYPE_CODE")%>'>
                                                </asp:HiddenField>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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

                <div id="div12" runat="server" class="panel-body">  <%--style="width: 97%; padding: 10px; display: block;" --%>
                    <h3 class="form-section" style="text-align: left;">
                        Member Filteration
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
                                        <asp:TemplateField HeaderText="Compensation Code" HeaderStyle-HorizontalAlign="Left" SortExpression="CmpCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsider" runat="server" Text='<%# Bind("CmpCode")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnConsider" runat="server" Value='<%# Bind("CmpCode")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contestant Code" HeaderStyle-HorizontalAlign="Left" SortExpression="CntCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("CntCode")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnType" runat="server" Value='<%# Bind("CntCode")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rule Set Key" HeaderStyle-HorizontalAlign="Left" SortExpression="RSKey">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWeightage" runat="server" Text='<%# Bind("RSKey")%>' />
                                                <asp:HiddenField ID="hdnWeightage" runat="server" Value='<%# Bind("RSKey")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cycle" HeaderStyle-HorizontalAlign="Left" SortExpression="Cycle">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCycle" runat="server" Text='<%# Bind("Cycle")%>' />
                                                <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("Cycle")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Map Source" HeaderStyle-HorizontalAlign="Left" SortExpression="MapSrc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMapSrc" runat="server" Text='<%# Bind("MapSrc")%>' />
                                                <asp:HiddenField ID="hdnMapSrc" runat="server" Value='<%# Bind("MapSrc")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Map Source Value" HeaderStyle-HorizontalAlign="Left" SortExpression="MSValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMapSrcVal" runat="server" Text='<%# Bind("MSValue")%>' />
                                                <asp:HiddenField ID="hdnMapSrcVal" runat="server" Value='<%# Bind("MSValue")%>' />
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

            </div>
            <div id="Table6" runat="server" class="row" style="margin-top: 12px;">
                <div class="col-sm-12" align="center">
                    <asp:LinkButton ID="btnCancelAll" runat="server" CssClass="btn btn-sample" Enabled="true"
                        OnClick="btnCancelAll_Click">
                                <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color: White;"></span> Back    
                    </asp:LinkButton>
                </div>
            </div>
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
</asp:Content>

