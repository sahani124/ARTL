<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="CntstStp.aspx.cs" Inherits="Application_ISys_Saim_CntstStp" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
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

    <script type="text/javascript" src="../../../Scripts/jquery.min.js"></script>

    <script type="text/javascript">

        function funAddVarMaster_01(cmpcode, ruleset) {
            debugger;
            //alert("OpenPopupWindow2");
            window.open("Rwd_Desc.aspx?cmpcode=" + cmpcode + "&ruleset=" + ruleset, '', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');

            //window.open("PopKPITrg.aspx?ruleset=" + ruleset + "&kpi=" + kpi, '', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');

        }

        $("[src*=btnexp]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");

        });
        $("[src*=btncol]").live("click", function () {
            debugger;
            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });


        //        $("#img2").on("click", function () {
        //            debugger;
        //            alert("hi");
        //            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        //            $(this).attr("src", "../../../images/btncol.png");

        //        })


        function test() {
            alert("hi");

            $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");
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

        function funAddVarMaster(cmpcode, cntstcode, ruleset, kpi, flag) {
            debugger;
            window.open("PopKPITrg.aspx?cmpcode=" + cmpcode + "&cntstcode=" + cntstcode + "&ruleset=" + ruleset + "&kpi=" + kpi + "&flag=" + flag, '', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');
        }

        function funAddmaster2(cmpcode, cntstcode, flag, ruletype) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwd1").src = "PopCntstMst.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype
            + "&mdlpopup=mdlVwBID";
        }

        function funAddmaster1(cmpcode, cntstcode, flag, ruletype) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwBID1").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwd2").src = "PopCntstMst.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype
            + "&mdlpopup=mdlVwBID1";
        }

        function funAddmaster3(cmpcode, cntstcode, flag, ruletype) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwBID2").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwd3").src = "PopCntstMst.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype
            + "&mdlpopup=mdlVwBID2";
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

        function ShowReqDiv(divId, btnId, img, chkId, divChk) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + chkId) != null) {
                if (document.getElementById(strContent + chkId).checked == true) {
                    $(document.getElementById(strContent + divId)).slideToggle();
                    if ($(img).attr('src') == "../../../assets/img/portlet-expand-icon-white.png") {
                        $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png');
                    }
                    else {
                        $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');

                    } //inner else
                } //outer if
                else {
                    $(document.getElementById(strContent + divId)).hide();
                    $(document.getElementById(strContent + divChk)).show();
                    $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
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

        function funblkTrg() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwTrgBID").show();
        }

        function funPopUp(div, rultyp) {
            ////alert('akshay');
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopQualSetup.aspx?kpicode=" + document.getElementById(strContent + "hdnKPICd").id
            + "&kpidesc=" + document.getElementById(strContent + "hdnKPIDsc").id + "&accmd=" + document.getElementById(strContent + "hdnAccMd").id
            + "&verfrm=" + document.getElementById(strContent + "hdnVerFrm").id + "&verto=" + document.getElementById(strContent + "hdnVerTo").id
            + "&CRYFWD=" + document.getElementById(strContent + "hdnCRYFWDQ").id + "&RwdCmpRul=" + document.getElementById(strContent + "hdnRwdCmpRulQ").id
            + "&UnitType=" + document.getElementById(strContent + "hdnUnitTypeQ").id + "&MaxLmt=" + document.getElementById(strContent + "hdnMaxLmtQ").id
            + "&UnitTypeDsc=" + document.getElementById(strContent + "hdnUnitTypeDscQ").id
            + "&verfrmval=" + document.getElementById(strContent + "hdnVersnFrm1").value + "&vertoval=" + document.getElementById(strContent + "hdnVrsnTo1").value
            + "&accmddsc=" + document.getElementById(strContent + "hdnAccMdDsc").id + "&rulsetky=" + document.getElementById(strContent + "hdnRulSetKy").value
            + "&rulsetkyid=" + document.getElementById(strContent + "hdnRulSetKy").id + "&chkdivid=" + document.getElementById(strContent + div).id
            + "&rultyp=" + rultyp
            + "&cmpnstcd=" + document.getElementById(strContent + "lblCompCodeVal").innerText
            + "&cntstcd=" + document.getElementById(strContent + "lblCntstCdVal").innerText
            + "&frmdt=" + document.getElementById(strContent + "lblEffDtFrmVal").innerText
            + "&todt=" + document.getElementById(strContent + "lblEffDtToVal").innerText
            + "&chnl=" + document.getElementById(strContent + "hdnChn").value
            + "&schnl=" + document.getElementById(strContent + "hdnSbChn").value
            + "&mdlpopup=mdlViewBID";
        }

        function funAddlCmnt(status, cmpcode, cntstcode, version, cmnttype, ruletype, flag) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBIDcmnt").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopcmnt").src = "CntstCmnts.aspx?CmpCode=" + cmpcode + "&cntstcode=" + cntstcode
            + "&version=" + version + "&status=" + status + "&cmnttype=" + cmnttype + "&ruletype=" + ruletype + "&flag=" + flag
            //            + "&updRevgrd=" + document.getElementById(strContent + "btnUpdRevGrd").ids
            + "&mdlpopup=mdlViewBIDcmnt";
        }

        function funAddmaster(cmpcode, cntstcode, flag, ruletype) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBIDcmnt").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopcmnt").src = "PopCntstMst.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype
            + "&mdlpopup=mdlViewBIDcmnt";
        }

        function funEditPopUp(div, rultyp, code, mode, rulcod, kpiCode, sID) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopQualSetup.aspx?code=" + code + "&kpiCode=" + kpiCode
            + "&rultyp=" + rultyp + "&cmpnstcd=" + document.getElementById(strContent + "lblCompCodeVal").innerText
            + "&cntstcd=" + document.getElementById(strContent + "lblCntstCdVal").innerText
            + "&chnl=" + document.getElementById(strContent + "hdnChn").value
            + "&schnl=" + document.getElementById(strContent + "hdnSbChn").value
            + "&mode=" + mode
            + "&CmpTyp=" + mode
            + "&rulcod=" + rulcod
            + "&mdlpopup=mdlViewBID";
        }

        function funPopUpTrgEdit(sort, cmpcode, cntstcd, rultyp, catgcd, sID, code) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwQTrgBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "QualTrgStp.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&catgcd=" + catgcd + "&sID=" + sID + "&flag=" + document.getElementById(strContent + "hdnFlag").id
            + "&sort=" + sort + "&code=" + code
            + "&mdlpopup=mdlVwQTrgBID";
        }

        function funPopUpRulSet(cmpcode, cntstcd, rultyp) {
            //////alert('kjbkjsbk');
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopRuleSet.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&mdlpopup=mdlViewBID";
        }

        function funcall() {

        }



        //function funPopUpTrg(cmpcode, cntstcd, rultyp, sID) {
        //    debugger;
        //    var strContent = "ctl00_ContentPlaceHolder1_";
        //    $find("mdlVwBID").show();
        //    document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "QualTrgStp.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
        //    + "&rultyp=" + rultyp  + "&sID=" + sID + "&flag=" + document.getElementById(strContent + "hdnFlag").id
        //    + "&mdlpopup=mdlVwBID";
        //}



        function funPopUpTrg(sort, cmpcode, cntstcd, rultyp, catgcd, sID) {

            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            // $find("mdlVwQTrgBID").show();


            Sys.Application.add_load(function () {
                $find("mdlVwQTrgBID").show();

                document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "QualTrgStp.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
                + "&rultyp=" + rultyp + "&catgcd=" + catgcd + "&sID=" + sID + "&flag=" + document.getElementById(strContent + "hdnFlag").id
                + "&sort=" + sort
                + "&mdlpopup=mdlVwQTrgBID";




            });
        }

        function funPopUpRwdRul(cmpcode, cntstcd, rultyp) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRwdRul.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&mdlpopup=mdlVwRwdRulBID";
        }

        function funPopUpRwdRulNSTD(cmpcode, cntstcd, rultyp, MEMBERCODE, Page) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRwdRul.aspx?Page=" + Page + "&MEMBERCODE=" + MEMBERCODE + "&compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&mdlpopup=mdlVwRwdRulBID";
        }


        function funPopUpFrml() {
            //////alert('akshay');
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID1").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup1").src = "PopFrmlEdit.aspx?mdlpopup=mdlViewBID1";
        }

        function funPopUpRwdRulEdit(cmpcode, cntstcd, rultyp, code) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////alert($find("mdlVwRwdRulBID"));
            ////$find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRwdRul.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp
            + "&code=" + code + "&mdlpopup=mdlVwRwdRulBID";
        }
        function funPopUpRwdRulEditMdl(cmpcode, cntstcd, rultyp, code, MdlFlag) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////alert($find("mdlVwRwdRulBID"));
            ////$find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRwdRul.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp
            + "&code=" + code + "&MdlFlag=" + MdlFlag + "&mdlpopup=mdlVwRwdRulBID";
        }
        function funPopUpRwdRulEditNSTD(cmpcode, cntstcd, rultyp, code, MEMBERCODE, Page) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////alert($find("mdlVwRwdRulBID"));
            ////$find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRwdRul.aspx?Page=" + Page + "&MEMBERCODE=" + MEMBERCODE + "&compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp
            + "&code=" + code + "&mdlpopup=mdlVwRwdRulBID";
        }

        function funPopUpRwdRulEditNSTDMDL(cmpcode, cntstcd, rultyp, code, MEMBERCODE, Page, MdlFlag) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////alert($find("mdlVwRwdRulBID"));
            ////$find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRwdRul.aspx?Page=" + Page + "&MEMBERCODE=" + MEMBERCODE + "&compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp
            + "&code=" + code + "&MdlFlag=" + MdlFlag + "&mdlpopup=mdlVwRwdRulBID";
        }

    </script>
    <style type="text/css">
        /*.CenterAlign
        {text-align:center !important;}
         .LeftAlign
        {text-align:left !important;}
         .RightAlign
        {text-align:right !important;}
        
        .form-section
        {
            margin: 30px 0px 25px 0px;
            padding-bottom: 5px;
            border-bottom: 1px solid #eee;
        }
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }
       */
        .new_text_new {
            color: #066de7;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .disablepage {
            display: none;
        }

        .box {
            background-color: #efefef;
            padding-left: 5px;
        }

        .custom {
            width: 180px !important;
        }

        .yourDiv {
            position: absolute;
            top: 123px;
            left: 25%;
        }
    </style>




    <%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>--%>
    <asp:Panel ID="Panel3" runat="server">
        <center>
                <div id="divcmphdrcollapse" runat="server" class="panel" style="width: 97%;">
                    <div id="Div13" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                 <img id="ImageComp" src="../../../images/Compensation_Detail_Icon.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>
                           
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%><%--added by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblhdr" Text="Compensation Details" runat="server" Style="font-size:19px;" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" class="panel-body"  style="width: 96%;text-align:left;white-space: nowrap;">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label" />
                                <%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new"
                                    TabIndex="1"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCompDesc1Val" runat="server" CssClass="form-control-static new_text_new "
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
                                <asp:Label ID="Label7" Text="Business Year" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblBusYr" runat="server" CssClass="form-control-static new_text_new" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label8" Text="Version" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblVersion" runat="server" CssClass="form-control-static new_text_new" />
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
                                </td> </tr> </table>
                            </div>
                        </div>
                    </div>
                </div>
               
                <div id="divcntstcollapse" runat="server" style="width: 97%;" class="panel">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcntst','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left" >
                                 <img id="Image2" src="../../../images/Contestant_Details_Icon.png" style="border-width:0px;width: 35px;margin-top: -13px;margin-bottom:10px;height: 35px;"/>     
                             
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                                <asp:Label ID="Label1" Text="Contestant Details" Style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <%--<img id="Img5" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                    alt="" onclick="funcall();" />--%>
                                <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divcntst" runat="server" style="width: 96%;text-align:left;white-space:nowrap;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCntstCd" Text="Contestant Code" runat="server" CssClass="control-label" /><%--col-md-5--%>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblCntstCdVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSlsChnl" Text="Sales Channel" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblSlsChnlVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSbCls" Text="Sub Class" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblSbClsVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMemTyp" Text="Member Type" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblMemTypVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblFinYr" Text="Financial Year" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblFinYrVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblVer" Text="Version" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblVerVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffFrmCnt" Text="Effective From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblEffFrmValCnt" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffToCnt" Text="Effective To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:Label ID="lblEffToValCnt" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
               
              <%--  <asp:UpdatePanel runat="server" ID="">
                    <ContentTemplate>--%>
                        <div id="divqualcollapse" runat="server" style="width: 97%;" class="panel" visible="false">
                            <div id="div3" runat="server" class="panel-heading" onclick="ShowDiv('div12');">
                                <div id="divhdr" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','Img4');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                             <img id="ImageQual" src="../../../images/Qualification_Rule_Details.png" style="border-width:0px;width: 35px;margin-top: 0px;margin-bottom: 5px;height: 35px;"/> 
                                        
                                              <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                                            <asp:Label ID="Label2" Text="Qualification Rule Details" runat="server" style="font-size:19px"/>
                                        </div>
                                        <div class="col-sm-2">
                                             <span id="Img4" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="div12" runat="server" style="display: none; text-align: left;padding-left: 42px;">
                                <asp:CheckBox ID="chkQual" Checked="true"  runat="server" CssClass="checkbox"/>
                                <asp:Label Text="Please check for setting qualification rule" CssClass="control-label" runat="server" style="padding-left: 5px;" />
                            </div>
                            <div id="divqual" runat="server" class="panel-body">
                                <h3 class="form-section" style="text-align: left;">
                                    Key Performance Indicators</h3>
                                <div id="div31" runat="server" style="width: 96%; border: none;" class="table-scrollable">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgQual" runat="server" CssClass="footable" AllowSorting="True"
                                            AllowPaging="true" OnSorting="dgQual_sorting" AutoGenerateColumns="false" OnRowDataBound="dgQual_RowDataBound">
                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lblerror" Text="No contestants have been defined" ForeColor="Red"
                                                    CssClass="control-label" runat="server" />
                                            </EmptyDataTemplate>
                                           <%-- <Columns>
                                                <asp:TemplateField HeaderText="Rule Code" SortExpression="RULE_CODE">
                                                    <ItemStyle HorizontalAlign="Left"/>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lblRulCode" runat="server" Text='<%# Bind("RULE_CODE")%>' OnClick="lblRulCode_Click"></asp:LinkButton>
                                                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("RULE_CODE")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnRulCode" runat="server" Value='<%# Bind("RULE_CODE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY">
                                                    <ItemStyle HorizontalAlign="Left"/>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                        <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">
                                                        </asp:HiddenField>
                                                        <asp:HiddenField ID="hdnCatg" Value='<%# Bind("CATEGORY")%>' runat="server"></asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKPIDesc" runat="server" Text='<%# Bind("KPI_DESC")%>' />
                                                        <asp:HiddenField ID="hdnKPIDesc" runat="server" Value='<%# Bind("KPI_DESC")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Accu Mode" SortExpression="ACC_MODE_DESC">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAccMode" runat="server" Text='<%# Bind("ACC_MODE_DESC")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnAccMode" runat="server" Value='<%# Bind("ACC_MODE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver Eff Frm" SortExpression="VER_FRM">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVerFrm" runat="server" Text='<%# Bind("VER_FRM")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnVerFrm" runat="server" Value='<%# Bind("VER_FRM")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver Eff To" SortExpression="VER_TO">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVerTo" runat="server" Text='<%# Bind("VER_TO")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnVerTo" runat="server" Value='<%# Bind("VER_TO")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="C/F Rule" SortExpression="CARRY_FWD">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRYFWD" runat="server" Text='<%# Bind("CARRY_FWD")%>' />
                                                        <asp:HiddenField ID="hdnCRYFWD" runat="server" Value='<%# Bind("CARRY_FWD")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Reward Computation Rule" SortExpression="RWD_CMP_RULE">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRwdCmpRul" runat="server" Text='<%# Bind("RWD_CMP_RULE")%>' />
                                                        <asp:HiddenField ID="hdnRwdCmpRul" runat="server" Value='<%# Bind("RWD_CMP_RULE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit Type" SortExpression="UNIT_TYPE">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitType" runat="server" Text='<%# Bind("UNIT_TYPEDsc")%>' />
                                                        <asp:HiddenField ID="hdnUnitType" runat="server" Value='<%# Bind("UNIT_TYPE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Max Limit" SortExpression="MAX_LIMIT">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMaxLmt" runat="server" Text='<%# Bind("MAX_LIMIT")%>' />
                                                        <asp:HiddenField ID="hdnMaxLmt" runat="server" Value='<%# Bind("MAX_LIMIT")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                            OnClick="lnkDelete_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Std Def.">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkQSetRule" runat="server" Text="Set Rule" OnClick="lnkQSetRule_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                

                                            </Columns>--%>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>
                                <div id="divPage" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                            <asp:TextBox runat="server" ID="txtPage_dgQual" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                                float: left; margin: 0; height: 30px;" Width="40px" Enabled="false" OnClick="btnnext_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <div id="tblqual" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                        <asp:LinkButton ID="btnQualIndctrMst" Text="ADD MASTER" runat="server" Width="100px"
                                            CssClass="btn btn-primary custom" Enabled="true" Visible="False">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Master   
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnAddQual" Text="ADD KPI" runat="server" Width="120px" CssClass="btn btn-sample"
                                            Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add KPI
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnBlkKPIQual" Text="BULK ADD KPI" runat="server" Width="150px" Visible="false"
                                            CssClass="btn btn-primary custom" Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Add KPI
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnCnclQual" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="False">
                                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnSaveQual" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            OnClick="btnSaveQual_Click" Visible="false">
                                                    <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> Save
                                        </asp:LinkButton>
                                        <asp:Button ID="btnqual" runat="server" ClientIDMode="Static" Style="display: none;"
                                            OnClick="btnqual_Click" />
                                        <asp:LinkButton ID="btnQualIndctrCmnt" Text="ADD COMMENTS" runat="server" Width="120px"
                                            CssClass="btn blue" Enabled="true" Visible="false" />
                                       
                                       <%-- <asp:Label ID="lbllbrckt" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkQualIndctrCmnt" Text="+" runat="server" />
                                        <asp:Label ID="lblrbrckt" Text="]" runat="server" CssClass="control-label" />--%>

                                         <asp:LinkButton ID="lnkQualIndctrCmnt" Text="Add Comments" runat="server" CssClass="btn btn-sample"/>
                                        <asp:LinkButton ID="lnkVwCmtQKPI" Text="View Comments" runat="server" CssClass="btn btn-sample"/>
                                      
                                        <%--<asp:Label ID="Label11" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkVwCmtQKPI" Text="..." runat="server" />
                                        <asp:Label ID="Label12" Text="]" runat="server" CssClass="control-label" />--%>
                                    </div>
                                </div>
                                <h3 class="form-section" style="text-align: left;">
                                    Key Performance Indicator Targets</h3>

                                <div id="div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgQualTrg" runat="server" CssClass="footable"
                                                AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="dgQualTrg_RowDataBound"
                                                OnSorting="dgQualTrg_Sorting">
                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                            <asp:HiddenField ID="hdnBusiCode" runat="server" Value='<%# Bind("BUSI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Bind("CODE")%>' />
                                                            <asp:HiddenField ID="HiddenRulecode" runat="server" Value='<%# Bind("RULE_CODE")%>' />
                                                            <asp:HiddenField ID="HiddenCycleCode" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                            <asp:HiddenField ID="HiddenKpiCode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">
                                                            </asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category" SortExpression="CATEGORY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATEGORY")%>' />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("CATG_DESC")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCycle" runat="server" Text='<%# Bind("CYCLE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category Description" SortExpression="CATG_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("CATG_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("CATG_DESC")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCatg" runat="server" Value='<%# Bind("CATG")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target From" SortExpression="TRG_FRM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgFrm" runat="server" Text='<%# Bind("TRG_FRM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTrgFrm" runat="server" Value='<%# Bind("TRG_FRM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target To" SortExpression="TRG_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgTo" runat="server" Text='<%# Bind("TRG_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTrgTo" runat="server" Value='<%# Bind("TRG_TO")%>' />
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
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditQualTrg" runat="server" Text="Edit" OnClick="lnkEditQualTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelQualTrg" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                                OnClick="lnkDelQualTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkQtrgSetRule" runat="server" Text="Set Rule" OnClick="lnkQtrgSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>


                                                  

                                                
                                <div id="divPgKpiTrg" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevkpitrg" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;"   OnClick="btnprevkpitrg_Click" />
                                                            <asp:TextBox runat="server" ID="txtpagetrg" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextkpitrg" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat; 
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false"   OnClick="btnnextkpitrg_Click" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnAddQualTrg" EventName="Click" />
                                                            <asp:AsyncPostBackTrigger ControlID="btnSaveQualTrg" EventName="Click" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <div class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                        <asp:LinkButton ID="btnQualTrgtMst" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="False">
                                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Master
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnAddQualTrg" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            OnClick="btnAddQualTrg_Click">
                                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Targets
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnBlkQualTrg" runat="server" CssClass="btn btn-sample" Enabled="true">
                                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Add Targets
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnDwnQTrg" runat="server" CssClass="btn btn-sample" Enabled="true">
                                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span>DownLoad Format <%--Bulk Download Targets--%>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnCnclQualTrg" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="False">
                                                        <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnSaveQualTrg" runat="server" CssClass="btn btn-sample" Visible="false"
                                            Enabled="true" OnClick="btnSaveQualTrg_Click">
                                                        <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> Save
                                        </asp:LinkButton>
                                        <asp:Button ID="btnqualtrg" runat="server" ClientIDMode="Static" Style="display: none;"
                                            OnClick="btnqualtrg_Click" />
                                        <asp:LinkButton ID="btnQualTrgtCmnt" Text="ADD COMMENTS" runat="server" Width="120px"
                                            CssClass="btn blue" Enabled="true" Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add Comments
                                            </asp:LinkButton>
                                       

                                          <asp:LinkButton ID="lnkQualTrgtCmnt" Text="Add Comments" runat="server" CssClass="btn btn-sample"/>
                                         <asp:LinkButton ID="lnkVwCmtQTrg" Text="View Comments" runat="server" CssClass="btn btn-sample"/>
                                        <%-- <asp:Label ID="lblcmntqtrg" Text="Add Comments" runat="server" CssClass="control-label" />
                                        <asp:Label ID="lbllbrktqtrg" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkQualTrgtCmnt" Text="+" runat="server" />
                                        <asp:Label ID="lblrbrktqtrg" Text="]" runat="server" CssClass="control-label" />
                                           <asp:Label ID="lblcmntqtrgView" Text="View Comments" runat="server" CssClass="control-label" />
                                        <asp:Label ID="Label13" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkVwCmtQTrg" Text="..." runat="server" />
                                        <asp:Label ID="Label14" Text="]" runat="server" CssClass="control-label" />--%>
                                    </div>
                                </div>
                            </div>
                             </div>
                        
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
               
                <%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>--%>
                        <div id="divRwdcollapse" runat="server" style="width: 97%;" class="panel">
                            <div id="div2" runat="server" class="panel-heading" onclick="ShowDiv('divchkRwd');">
                                <div id="div14" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divRwd','Img3');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <img id="ImageReward" src="../../../images/Reward_Rule_Icon.png" style="border-width:0px;width: 35px;margin-top: 0px;margin-bottom: 5px;height: 35px;"/> 
                                           
                                             <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%><%--commented by ajay sawant 25/4/2018--%>
                                            <asp:Label ID="Label3" Text="Reward Rule Details"  style="font-size: 19px;" runat="server" />
                                        </div>
                                        <div class="col-sm-2">
                                             <span id="Img3" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divchkRwd" runat="server" style="display: none; text-align: left; padding-left: 42px;" >
                                <asp:CheckBox ID="chkRwd" runat="server" CssClass="checkbox" />
                                <asp:Label Text="Please check for setting rewards rule" runat="server" style="padding-left: 5px;"/>
                            </div>
                            <div id="divRwd" runat="server" style="width: 96%;" class="panel-body">
                            <div id="divKPI" runat="server" >
                                <h3 class="form-section" style="text-align: left;">
                                       <img id="ImageKPI" src="../../../images/Key_Performance_Rule_Icon.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>
                                   
                                    Key Performance Indicators</h3>
                                <div id="div4" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvAddMst" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" DataKeyNames="RuleSetCode" 
                                                 OnRowDataBound="gvAddMst_RowDataBound" >
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField>
                                                    <ItemTemplate>
                                                <img alt="" id="img2"  style="cursor: pointer" src="../../../images/btnexp.png" />
                                                <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">
                                                    <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="dgReward" runat="server" CssClass="footable" AllowSorting="True"
                                                                OnSorting="dgReward_Sorting" AllowPaging="true" AutoGenerateColumns="false"   OnRowDataBound="dgReward_RowDataBound" >
                                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                <PagerStyle CssClass="disablepage" />
                                                                <HeaderStyle CssClass="gridview th" />                                                               
                                                                 <EmptyDataTemplate>
                                                                    <asp:Label ID="Label15" Text="No KPI have been defined" ForeColor="Red" CssClass="control-label" runat="server" />
                                                                </EmptyDataTemplate>
                                                    <Columns>
                                                        
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">

                                                            </asp:HiddenField>
                                                             <asp:HiddenField ID="hdnRuleCode" Value='<%# Bind("RULE_CODE")%>' runat="server"/>
                                                            <asp:HiddenField ID="hdnRuleSetKy" Value='<%# Bind("RULE_SET_KEY")%>' runat="server"/>
                                                            <asp:HiddenField ID="hdnCatg" Value='<%# Bind("CATEGORY")%>' runat="server"></asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPIDesc" runat="server" Text='<%# Bind("KPI_DESC")%>' />
                                                            <asp:HiddenField ID="hdnKPIDesc" runat="server" Value='<%# Bind("KPI_DESC")%>' />
                                                            <asp:HiddenField ID="hdnParentRuleSetKPI" runat="server" Value='<%# Bind("PARENT_RULE_SET_KPI")%>' />
                                                             <asp:HiddenField ID="hdnCmpFlag" runat="server" Value='<%# Bind("CMPTTN_FLAG")%>' />
                                                             <asp:HiddenField ID="hdnIsCummulative" runat="server" Value='<%# Bind("IS_CUMULATIVE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Accumulation Mode" SortExpression="ACC_MODE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccMode" runat="server" Text='<%# Bind("ACC_MODE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnAccMode" runat="server" Value='<%# Bind("ACC_MODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ver Eff Frm" SortExpression="VER_FRM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVerFrm" runat="server" Text='<%# Bind("VER_FRM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnVerFrm" runat="server" Value='<%# Bind("VER_FRM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ver Eff To" SortExpression="VER_TO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVerTo" runat="server" Text='<%# Bind("VER_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnVerTo" runat="server" Value='<%# Bind("VER_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Carry Forward Rule" SortExpression="CARRY_FWD">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCRYFWD" runat="server" Text='<%# Bind("CARRY_FWD")%>' />
                                                            <asp:HiddenField ID="hdnCRYFWD" runat="server" Value='<%# Bind("CARRY_FWD")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reward Computation Rule" SortExpression="RWD_CMP_RULE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdCmpRul" runat="server" Text='<%# Bind("RWD_CMP_RULE")%>' />
                                                            <asp:HiddenField ID="hdnRwdCmpRul" runat="server" Value='<%# Bind("RWD_CMP_RULE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="UNIT_TYPE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitType" runat="server" Text='<%# Bind("UNIT_TYPEDsc")%>' />
                                                            <asp:HiddenField ID="hdnUnitType" runat="server" Value='<%# Bind("UNIT_TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Max Limit" SortExpression="MAX_LIMIT">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMaxLmt" runat="server" Text='<%# Bind("MAX_LIMIT")%>' />
                                                            <asp:HiddenField ID="hdnMaxLmt" runat="server" Value='<%# Bind("MAX_LIMIT")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwd" runat="server" Text="Edit" OnClick="LnkEditRwrd_Click" ></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                        OnClientClick="return confirm('Are you sure you want delete'); return true;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                              <asp:LinkButton ID="lnkKPISetRule" runat="server" Text="Set Rule" OnClick="lnkKPISetRule_Click"></asp:LinkButton> 

                                                        <%--   <asp:button text="Set Rule" ID="lnkKPISetRule" runat="server" CssClass="btn btn-link" style="padding:0px" OnClick="lnkKPISetRule_Click" />  --%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Action ">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkTrgView" runat="server" Text="View Target" OnClick="lnkTrgView_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                </Columns>
                                                 
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                    </div>

                                                         </ItemTemplate>  
                                                          
                                                      </asp:TemplateField>
                                                    


                                            <asp:TemplateField HeaderText="Rule Set Code" SortExpression="RuleSetCode">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetCode" runat="server" Text='<%# Bind("RuleSetCode")%>' />
<%--                                                     <asp:HiddenField ID="hdnRulCode" runat="server" Value='<%# Bind("RULE_CODE")%>' />--%>
                                                     <asp:HiddenField ID="hdnACCRUAL_ACC_CYCLE" runat="server" Value='<%# Bind("ACCRUAL_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWD_CMP_CYCLE" runat="server" Value='<%# Bind("RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnRWRD_REL_CYCLE" runat="server" Value='<%# Bind("RWRD_REL_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnACC_CYCLE" runat="server" Value='<%# Bind("ACC_CYCLE")%>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         
                                            <asp:TemplateField HeaderText="Rule Set Description" SortExpression="RuleSetDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleSetDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>' />
                                                     <asp:HiddenField ID="hdnPARENT_CMPNSTN_CODE" runat="server" Value='<%# Bind("PARENT_CMPNSTN_CODE")%>' />
                                                    <asp:HiddenField ID="hdnPARENT_CNTST_CODE" runat="server" Value='<%# Bind("PARENT_CNTST_CODE")%>' />
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule Method" SortExpression="RULE_METHOD">
                                                <ItemStyle HorizontalAlign="Center" Width="0px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleMethod" runat="server" Text='<%# Bind("RuleMethod")%>' />
                                                    <asp:HiddenField ID="hdnRuleMethod" runat="server" Value='<%# Bind("RULE_METHOD")%>' />
                                                    <asp:HiddenField ID="hdnMEM_ACH_ACC_CYCLE" runat="server" Value='<%# Bind("MEM_ACH_ACC_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_CMP_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_CMP_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnMEM_RWD_REL_CYCLE" runat="server" Value='<%# Bind("MEM_RWD_REL_CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnAchTbl" runat="server" Value='<%# Bind("PTR_TBL")%>' />
                                                    <asp:HiddenField ID="hdnOperator" runat="server" Value='<%# Bind("OPERATOR")%>' />
                                                   <%--  <asp:HiddenField ID="hdnRUL_CLASS" runat="server" Value='<%# Bind("RUL_CLASS")%>' />--%>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           

                                            <%--Added by Prity--%>
                                            <asp:TemplateField HeaderText="Parent Compensation Desc" SortExpression="PARENT_CMPNSTN_CODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CMPNSTN_CODE" runat="server" Text='<%# Bind("PARENT_CMPNSTN_DESC")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                    
                                                      <asp:TemplateField HeaderText="Parent contestant Code" SortExpression="PARENT_CNTST_CODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_CNTST_CODE" runat="server" Text='<%# Bind("PARENT_CNTST_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Parent Rule Set Code" SortExpression="PARENT_RULESECODE">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPARENT_RULESECODE" runat="server" Text='<%# Bind("PARENT_RULESECODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Parent Rule Set Description" SortExpression="PARENT_RULESETDesc">
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPRuleSetDesc" runat="server" Text='<%# Bind("PARENT_RULESETDesc")%>' />
                                                     <asp:HiddenField ID="hdnPARENT_KPICODE" runat="server" Value='<%# Bind("PARENT_KPICODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--ended by prity--%>
                           
                                                     <asp:TemplateField HeaderText=" Target Rule Class" SortExpression="TRG_CATG_RUL_CLASS">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTRG_CATG_RUL_CLASS_DESC" runat="server" Text='<%# Bind("TRG_CATG_RUL_CLASS_DESC")%>' />
                                                 <asp:HiddenField ID="hdnTRG_CATG_RUL_CLASS" runat="server" Value='<%# Bind("TRG_CATG_RUL_CLASS")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Reward  Rule Class" SortExpression="RWD_RUL_CLASS">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRWD_RUL_CLASS_DESC" runat="server" Text='<%# Bind("RWD_RUL_CLASS_DESC")%>' />
                                                    <asp:HiddenField ID="hdnRWD_RUL_CLASS" runat="server" Value='<%# Bind("RWD_RUL_CLASS")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rule Complexity" SortExpression="RUL_SET_CMPLXTY">
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRUL_SET_CMPLXTY_DESC" runat="server" Text='<%# Bind("RUL_SET_CMPLXTY_DESC")%>' />
                                                    <asp:HiddenField ID="hdnRUL_SET_CMPLXTY" runat="server" Value='<%# Bind("RUL_SET_CMPLXTY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                  <%--  <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>--%>
                                              <%--  </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                        OnClientClick="return confirm('Are you sure you want delete'); return true;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            </Columns>
                                                 </asp:GridView>
                                                       </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                  
                                  </div>
                                </div>
                                <div id="divPageRwd" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevrwd" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevrwd_Click" />
                                                            <asp:TextBox runat="server" ID="txtPageRwd" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextrwd" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false" OnClick="btnnextrwd_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <div style="text-align: left;">
                                    <asp:LinkButton ID="lnkKeyDfn" Text="Rule Set Key Definition" runat="server" Visible="false" />
                                </div>
                                <div id="tblrwd" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                        <asp:LinkButton ID="btnAddIndctrMst" runat="server" CssClass="btn btn-primary custom" Enabled="true"
                                            Visible="False">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Master
                                        </asp:LinkButton>
                                           <asp:LinkButton ID="lnkAddRuleMst" runat="server"  CssClass="btn btn-sample" ><%--OnClick="lnkAddRuleMst_Click"--%>
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span>Add Rule Set 
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnAddRwd" runat="server" CssClass="btn btn-sample" >
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add KPI
                                        </asp:LinkButton>

                                         <%--Added by Prathamesh on 27_02_2018 start--%>
                                          <asp:LinkButton ID="btnDwdFormat" runat="server" CssClass="btn btn-sample" Visible="false" Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Download Format
                                        </asp:LinkButton>
                                         <%--Added by Prathamesh on 27_02_2018 end--%>
                                        <asp:LinkButton ID="btnBlkKPIRwd" Visible="false" runat="server" CssClass="btn btn-sample" Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Add KPI
                                        </asp:LinkButton>

                                       

                                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="False">
                                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnSaveRwd" runat="server" CssClass="btn btn-sample" Visible="false"
                                            Enabled="true">
                                                    <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> Save
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnindctrcmnt" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="false">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add Comments
                                        </asp:LinkButton>
                                        
                                      <%-- <asp:Label ID="lbllbrktrwd" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkindctrcmnt" Text="+" runat="server" />
                                        <asp:Label ID="lblrbrktrwd" Text="]" runat="server" CssClass="control-label" />--%>
                                     <asp:LinkButton ID="lnkindctrcmnt"  CssClass="btn btn-sample"  runat="server" >
                                      <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Comments
                                     </asp:LinkButton>
                                         <asp:LinkButton ID="lnkVwCmtRwd"  CssClass="btn btn-sample" Text="View Comments" runat="server" >
                                             <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> View Comments
                                         </asp:LinkButton>
                                     <%--<asp:Label ID="Label15" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkVwCmtRwd" Text="..." runat="server" />
                                        <asp:Label ID="Label16" Text="]" runat="server" CssClass="control-label" />--%>
                                    </div>
                                </div>
                               
                                <div id="divKPIT" runat="server">
                                <h3 class="form-section" style="text-align: left;">
                                        <img id="ImageKPITrgs" src="../../../images/Key_Performance_Indicator_targets.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>

                                    Key Performance Indicator Targets</h3>
                                    <div id="div20" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow-x:scroll!important"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgTrg" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="100" AllowSorting="True" AllowPaging="true" CssClass="footable" DataKeyNames="rulesetCode" OnRowDataBound="dgTrg_RowDataBound">   <%--OnRowDataBound="dgTrg_RowDataBound"--%>
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                                 <EmptyDataTemplate>
                                            <asp:Label ID="Label15" Text="No Rule have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        
                                                <Columns>

                                           <asp:TemplateField>
                                                    <ItemTemplate>
                                <img alt="" id="img2"  style="cursor: pointer" src="../../../images/btnexp.png" />
                                <div id="div5" runat="server" style="display: none; width: auto; margin: 0px 0 !important;overflow-x:scroll !important"
                                                   >
                                   <%--  class="table-scrollable,divBorder1"--%>
                                   
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdTrg" runat="server" CssClass="footable" AllowSorting="True"  
                                                AllowPaging="false" AutoGenerateColumns="false" 
                                                OnSorting="dgRwdTrg_Sorting"    OnPageIndexChanging="dgRwdTrg_PageIndexChanging"  >
                                                
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <%--<PagerStyle CssClass="disablepage" />--%>
                                                <HeaderStyle CssClass="gridview th" />
                                                <EmptyDataTemplate>
                                            <asp:Label ID="Label15" Text="No Target have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                            <asp:HiddenField ID="hdnBusiCode" runat="server" Value='<%# Bind("BUSI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCode" runat="server" Value='<%# Bind("CODE")%>' />
                                                            <asp:HiddenField ID="HiddenRulecode" runat="server" Value='<%# Bind("RULE_CODE")%>' />
                                                            <asp:HiddenField ID="HiddenCycleCode" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                            <asp:HiddenField ID="HiddenKpiCode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnKpiOrg" Value='<%# Bind("KPI_ORIGIN")%>' runat="server">
                                                            </asp:HiddenField>
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
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
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
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCatg" runat="server" Value='<%# Bind("CATG")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target From" SortExpression="TRG_FRM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgFrm" runat="server" Text='<%# Bind("TRG_FRM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTrgFrm" runat="server" Value='<%# Bind("TRG_FRM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Target To" SortExpression="TRG_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrgTo" runat="server" Text='<%# Bind("TRG_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTrgTo" runat="server" Value='<%# Bind("TRG_TO")%>' />
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
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MEMBER_CODE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMEM_CODE" runat="server" Text='<%# Bind("MEM_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnMEM_CODE" runat="server" Value='<%# Bind("MEM_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwdTrg" runat="server" Text="Edit" OnClick="lnkEditRwdTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelRwdTrg" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                                OnClick="lnkDelRwdTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkKPITrgtSetRule" runat="server" Text="Set Rule" OnClick="lnkKPITrgtSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- ---Added by Akash on 15/01/19-----------%>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSetRule" runat="server" Text="Set Rule" OnClick="lnkSetRule_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- ---Ended by Akash on 15/01/19-----------%>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddRwdTrg" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveRwdTrg" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>


                                                        </ItemTemplate>
                                           </asp:TemplateField>

                                                    
                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="rulesetCode">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lnkRule_SET_KEY" runat="server" Text='<%# Bind("rulesetCode")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Rule Set Description" SortExpression="RuleSetDesc">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRuleSetDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>'></asp:Label>
                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCycle" runat="server" Text='<%# Bind("Cycle_Desc")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Eff From" SortExpression="EFF_FROM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffFrom" runat="server" Text='<%# Bind("EFF_FROM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnEffFrom" runat="server" Value='<%# Bind("EFF_FROM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eff To" SortExpression="EFF_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffTo" runat="server" Text='<%# Bind("EFF_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnEffTo" runat="server" Value='<%# Bind("EFF_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <%-- <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkQtrgSetRule" runat="server" Text="Set Rule" OnClick="lnkQtrgSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>


                                                    </Columns>


                                             </asp:GridView>
                                             </ContentTemplate>

                                                </asp:UpdatePanel>
                                         </div>


                                <div id="divRwdPgTrg" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevrwdtrg" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevrwdtrg_Click" />
                                                            <asp:TextBox runat="server" ID="txtpgrwdtrg" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextrwdtrg" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="true" OnClick="btnnextrwdtrg_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <div id="tblrwdtrg" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                     
                                        <asp:LinkButton ID="btnAddTrgtMst" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="false">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Master
                                        </asp:LinkButton>

                                         <asp:LinkButton ID="btnAddCategory" runat="server" CssClass="btn btn-sample" Enabled="true"
                                         > <%--OnClick="btnAddCategory_Click" --%>
                                              <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Category
                                        </asp:LinkButton>


                                        <asp:LinkButton ID="btnAddRwdTrg" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            OnClick="btnAddRwdTrg_Click">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Targets
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="btnBlkRwTrg" Text="BULK ADD TARGETS" runat="server" CssClass="btn btn-sample" Visible="false"
                                            Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Add Targets    
                                        </asp:LinkButton>

                                         <%--Added by Prathamesh on 27_02_2018 start--%>
                                         <asp:LinkButton ID="LinkButton1" Text="BULK ADD TARGETS" runat="server" CssClass="btn btn-sample"  Visible="false"
                                            Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Download Format  
                                        </asp:LinkButton>
                                         <%--Added by Prathamesh on 27_02_2018 end--%>

                                        <asp:LinkButton ID="btnSaveRwdTrg" runat="server" CssClass="btn btn-sample"   Visible="false"
                                            Enabled="true">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Save
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnCancelRwdTrg" runat="server" CssClass="btn btn-sample"  Visible="false"
                                            Enabled="true">
                                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btntrgtcmnt" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Comments
                                        </asp:LinkButton>

                                        <asp:LinkButton ID="lnlGenCategory"  runat="server" OnClick="lnlGenCategory_Click" CssClass="btn btn-sample" Visible="true" >
                                         <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Generate Category
                                        </asp:LinkButton>
                                       
                                        <%--<asp:Label ID="lbllbrkrtrg" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnktrgtcmnt" Text="+" runat="server" />
                                        <asp:Label ID="lblrbrkrtrg" Text="]" runat="server" CssClass="control-label" />--%>
                                        <asp:LinkButton ID="lnktrgtcmnt"  runat="server" CssClass="btn btn-sample" Visible="true" >
                                         <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Comments
                                        </asp:LinkButton>
                                         <asp:LinkButton ID="lnkVwCmtRTrg" runat="server" CssClass="btn btn-sample" Visible="true" >
                                          <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> View Comments
                                         </asp:LinkButton>
                                         <%--added by ajay sawant--%>
                                        <asp:LinkButton ID="btnDwnTrg"   Visible="true" runat="server" CssClass="btn btn-sample" OnClick="btnDwnTrg_Click">
                                         <span class="glyphicon glyphicon-download" style="color: White;"></span> Download Targets
                                       </asp:LinkButton>

                                       <%-- <asp:Label ID="Label17" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkVwCmtRTrg" Text="..." runat="server" />
                                        <asp:Label ID="Label18" Text="]" runat="server" CssClass="control-label" />--%>

                                    
                                    </div>
                                </div>
                                </div>
                                <div id="divKPIRR" runat="server">
                                <h3 class="form-section" style="text-align: left;">
                                        <img id="ImageReward2" src="../../../images/Reward_Rule_Icon.png" style="border-width:0px;width: 35px;margin-top: 0px;margin-bottom: 5px;height: 35px;"/> 
                                            
                                    Key Performance Indicator Reward Rules</h3>
                                <div id="div6" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;overflow:auto;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdRul" runat="server" CssClass="footable" AllowSorting="True" PageSize="10"
                                                OnSorting="dgRwdRul_Sorting" AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="dgRwdRul_RowDataBound">
                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <PagerStyle CssClass="disablepage" />
                                                <HeaderStyle CssClass="gridview th" />
                                                <Columns>
                                                  <%--  1--%>
                                                    <asp:TemplateField>
                                            <ItemTemplate>
                                                <img alt="" id="img2"  style="cursor: pointer" src="../../../images/btnexp.png" />
                                                <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">
                                                    <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable"
                                                                 >
                                                              
                                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                <PagerStyle CssClass="disablepage" />
                                                                <HeaderStyle CssClass="gridview th" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                        runat="server" />
                                                                </EmptyDataTemplate>
                                                                <Columns>

                                                                
                                             <asp:TemplateField HeaderText="Buisiness Type" SortExpression="BusType">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBusType" runat="server" Text='<%# Bind("BusType")%>' />
                                                    <asp:HiddenField ID="lblBusType11" runat="server" Value='<%# Bind("BusType")%>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Product Code" SortExpression="ProdCode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Bind("ProdCode")%>' />
                                                    <asp:HiddenField ID="lblProdCode11" runat="server" Value='<%# Bind("ProdCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                             <asp:TemplateField HeaderText="Plan Code" SortExpression="PlanCode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlanCode" runat="server" Text='<%# Bind("PlanCode")%>' />
                                                    <asp:HiddenField ID="lblPlanCode11" runat="server" Value='<%# Bind("PlanCode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Product Category" SortExpression="ProdCategory">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdCategory" runat="server" Text='<%# Bind("ProdCategory")%>' />
                                                    <asp:HiddenField ID="lblProdCategory11" runat="server" Value='<%# Bind("ProdCategory")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Frequency" SortExpression="Frequency">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFrequency" runat="server" Text='<%# Bind("Frequency")%>' />
                                                    <asp:HiddenField ID="lblFrequency11" runat="server" Value='<%# Bind("Frequency")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Policy Term From" SortExpression="PolicyTermFrom">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle CssClass="CenterAlign" Width="20px" />
                                                <ItemTemplate >
                                                    <asp:Label ID="lblPolicyTermFrom" runat="server" Text='<%# Bind("PolicyTermFrom")%>' />
                                                    <asp:HiddenField ID="lblPolicyTermFrom11" runat="server" Value='<%# Bind("PolicyTermFrom")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Policy Term To" SortExpression="PolicyTermTo">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle CssClass="CenterAlign"  Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPolicyTermTo" runat="server" Text='<%# Bind("PolicyTermTo")%>' />
                                                    <asp:HiddenField ID="lblPolicyTermTo11" runat="server" Value='<%# Bind("PolicyTermTo")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Premium Term From" SortExpression="PremiumFrom">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle  CssClass="RightAlign"  Width="20px" />
                                                <ItemTemplate >
                                                    <asp:Label ID="lblPremiumFrom" runat="server" Text='<%# Bind("PremiumFrom")%>' />
                                                    <asp:HiddenField ID="lblPremiumFrom11" runat="server" Value='<%# Bind("PremiumFrom")%>' />
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Premium To" SortExpression="PremiumTo">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle  CssClass="RightAlign" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPremiumTo" runat="server" Text='<%# Bind("PremiumTo")%>' />
                                                    <asp:HiddenField ID="lblPremiumTo11" runat="server" Value='<%# Bind("PremiumTo")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Premium Type" SortExpression="PremiumType">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPremiumType" runat="server" Text='<%# Bind("PremiumType")%>' />
                                                    <asp:HiddenField ID="lblPremiumType11" runat="server" Value='<%# Bind("PremiumType")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Commission Rate" SortExpression="CommRate">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle CssClass="RightAlign" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommRate" runat="server" Text='<%# Bind("CommRate")%>' />
                                                    <asp:HiddenField ID="lblCommRate11" runat="server" Value='<%# Bind("CommRate")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Pay Mode" SortExpression="PayMode">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayMode" runat="server" Text='<%# Bind("PayMode")%>' />
                                                    <asp:HiddenField ID="lblPayMode11" runat="server" Value='<%# Bind("PayMode")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                                   
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                     <%--  2--%>
                                                    <asp:TemplateField HeaderText="Reward Code" SortExpression="RWD_RUL_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdRulCode" runat="server" Text='<%# Bind("RWD_RUL_CODE")%>'></asp:Label>
                                                            <%--<asp:Label ID="lblRwdCode" runat="server" Text='<%# Bind("REWARD_CODE")%>'></asp:Label>--%>
                                                            <asp:HiddenField ID="hdnRwdCode" runat="server" Value='<%# Bind("REWARD_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                             <asp:HiddenField ID="hdnActSts" runat="server" Value='<%# Bind("ACTV_STATUS")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  3--%>
                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCYCLE" runat="server" Text='<%# Eval("CYCLE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCYCLE1" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                            <asp:HiddenField ID="hdnCycCd" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <%--  4--%>
                                                    <asp:TemplateField HeaderText="Category Code" SortExpression="CATG_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCd" runat="server" Text='<%# Bind("CATG_CODE")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <%--  5--%>
                                                    <asp:TemplateField HeaderText="Category Classification" SortExpression="CATEGORY">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATG_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  6--%>
                                                    <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY_DESC">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  7--%>
                                                    <asp:TemplateField HeaderText="Reward Type" SortExpression="REWARD_TYPE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>--%>
                                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("REWARD_TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  8--%>
                                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="TYPE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("TYPE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  9--%>
                                                    <asp:TemplateField HeaderText="Based On KPI" SortExpression="KPI_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>--%>
                                                            <asp:Label ID="lblBsdKpi" runat="server" Text='<%# Eval("KPI_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnBsdKpi" runat="server" Value='<%# Eval("KPI_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  10--%>
                                                    <asp:TemplateField HeaderText="Value" SortExpression="VALUE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValue" runat="server" Text='<%# Eval("VALUE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnValue" runat="server" Value='<%# Bind("VALUE")%>' />
                                                            <asp:HiddenField ID="hdnRate" runat="server" Value='<%# Bind("RATE")%>' />
                                                            <asp:LinkButton ID="lnkValue" Text="..." runat="server" Visible="false" OnClick="lnkValue_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  11--%>
                                                    <asp:TemplateField HeaderText="Reward Desc" SortExpression="RWD_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdDesc" runat="server" Text='<%# Bind("RWD_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRwdDesc" runat="server" Value='<%# Bind("RWD_DESC")%>' />
                                                            <asp:HiddenField ID="hdnRwdDesc1" runat="server" Value='<%# Bind("RWRD_DESC02")%>' />
                                                            <asp:HiddenField ID="hdnRwdDesc2" runat="server" Value='<%# Bind("RWRD_DESC03")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  12--%>
                                                    <asp:TemplateField HeaderText="Breakup Rule" SortExpression="BRK_RULE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBrkRul" runat="server" Text='<%# Eval("BRK_RULE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnBrkRul" runat="server" Value='<%# Bind("BRK_RULE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  13--%>
                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RATE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRATE" runat="server" Text='<%# Eval("RATE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRATE1" runat="server" Value='<%# Bind("RATE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--  14--%>

                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MEMBERCODE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMEMBERCODE" runat="server" Text='<%# Eval("MEMBERCODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnMEMBERCODE" runat="server" Value='<%# Bind("MEMBERCODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                     <%--  15--%>
                                                     <asp:TemplateField HeaderText="Target From" SortExpression="TRGT_FROM">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTRGT_FROM" runat="server" Text='<%# Eval("TRGT_FROM")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTRGT_FROM" runat="server" Value='<%# Bind("TRGT_FROM")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                     <%--  16--%>
                                                    <asp:TemplateField HeaderText="Target To" SortExpression="TRGT_TO">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTRGT_TO" runat="server" Text='<%# Eval("TRGT_TO")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnTRGT_TO" runat="server" Value='<%# Bind("TRGT_TO")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                     <%--  17--%>
                                                   <%-- added by arjun dated on 06/09/2018 for the UAT bug 2052--%>
                                                     <asp:TemplateField HeaderText="Reason for Edit Rate" SortExpression="ParamDesc1">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLParamDesc1RED" runat="server" Text='<%# Bind("ParamDesc1")%>' />
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                 <%--   ended by arjun--%>
                                                          <%--  18--%>                                             
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwdRul" runat="server" Text="Edit" OnClick="lnkEditRwdRul_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <%--   Addeds by Megha 06.03.2021--%>
                                                          <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                      <asp:LinkButton ID="lnkviewRwdRulMdl" runat="server" Text="View" Visible="true" OnClick="lnkviewRwdRulMdl_Click" ></asp:LinkButton> &nbsp;  
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                       <%--   ended by Megha 06.03.2021 OnClick="lnkviewRwdRulMdl_Click"--%>
                                                             <%--  19--%>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelRwdRul" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                                OnClick="lnkDelRwdRul_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddRwdRul" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveRwdRul" EventName="Click" />
                                             <asp:AsyncPostBackTrigger ControlID="LNKRWD" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="div7" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                    <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevrwdrul" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevrwdrul_Click" />
                                                            <asp:TextBox runat="server" ID="txtPageRwdRul" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextrwdrul" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false" OnClick="btnnextrwdrul_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <div id="tblrwdrul" runat="server" class="row" style="margin-top: 12px;">
                                    <div class="col-sm-12" align="center">
                                        <asp:LinkButton ID="GenerateRwrds" runat="server" CssClass="btn btn-sample" Enabled="true" OnClick="GenerateRwrds_Click" >
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Generate Rewards
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnAddRwdRuleMst" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="False">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Master    
                                        </asp:LinkButton>
                                          <asp:LinkButton ID="btnAddRewardType" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            >
                                               <%-- OnClick="btnAddRewardType_Click"--%>    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Reward Type
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnAddRwdRul" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            >
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Rewards
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnBlkRwd" runat="server" CssClass="btn btn-sample" Enabled="true" Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Bulk Add Rewards
                                        </asp:LinkButton>

                                         <%--Added by Prathamesh on 27_02_2018 start--%>
                                         <asp:LinkButton ID="btnDwdFormat1" runat="server" CssClass="btn btn-sample" Enabled="true" Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Download Format
                                        </asp:LinkButton>
                                         <%--Added by Prathamesh on 27_02_2018 end--%>

                                        <asp:LinkButton ID="btnCancelRul" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="False">
                                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnSaveRwdRul" runat="server" CssClass="btn btn-primary custom" Visible="false"
                                            Enabled="true" OnClick="btnSaveRwdRul_Click">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Save
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnrwdrulecmnt" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            Visible="false">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Comments
                                        </asp:LinkButton>
                                       
                                      <%--  <asp:Label ID="lbllbrkrul" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkrwdrulecmnt" Text="+" runat="server" />
                                        <asp:Label ID="lblrbrkrul" Text="]" runat="server" CssClass="control-label" />--%>
                                      <asp:LinkButton ID="lnkrwdrulecmnt"  runat="server" Visible="true" CssClass="btn btn-sample" > 
                                       <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Comments
                                      </asp:LinkButton>
                                       <asp:LinkButton ID="lnkVwCmtRwRul" Text="View Comments" runat="server" CssClass="btn btn-sample">
                                         <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> View Comments
                                       </asp:LinkButton>

                                        <asp:LinkButton ID="lnkDownloadReward" Text="Download Rewards" runat="server" CssClass="btn btn-sample" OnClick="lnkDownloadReward_Click">
                                         <span class="glyphicon glyphicon-download" style="color: White;"></span> Download Rewards
                                       </asp:LinkButton>

                                               
                                        <%--Added by prity on 26 sept 2018--%>
                                       <asp:LinkButton ID="LnkEditRwrd" Text="Edit Rewards" runat="server" CssClass="btn btn-sample" 
                                           OnClick="LnkEditRwrd_Click" >
                                         <span class="glyphicon glyphicon-pencil" style="color: White;" ></span> Edit Rewards
                                       </asp:LinkButton>
                                        <asp:LinkButton ID="lnkview" Text="View" runat="server" CssClass="btn btn-sample" 
                                           OnClick="lnkview_Click" >
                                         <span class="glyphicon glyphicon-eye-open" style="color: White;" ></span> View
                                       </asp:LinkButton>
                                        <%--<div class="modal-footer">
                                         <asp:Button ID="LnkEditRwrd" Text="Edit Rewards" runat="server" CssClass="btn btn-sample" 
                                           OnClick="LnkEditRwrd_Click" data-toggle="modal" data-target="#myModal" UseSubmitBehavior="false">
                                        
                                       </asp:Button>--%>
                                        </div>
                                        <%--ended by prity on 26 sept 2018--%>
                                        <div class="loader" id="loading" runat="server" visible="false"></div>
                                       <%-- <asp:Label ID="Label19" Text="[" runat="server" CssClass="control-label" />
                                        <asp:LinkButton ID="lnkVwCmtRwRul" Text="..." runat="server" />
                                        <asp:Label ID="Label20" Text="]" runat="server" CssClass="control-label" />--%>
                                    </div>
                                </div>
                                <div  runat="server" class="row" style="margin-top: 12px;" id="DivAddStandNonDef" visible="false">
                                <div class="col-sm-12" align="center">

                                        <asp:LinkButton ID="LNKRWD" runat="server" CssClass="btn btn-sample" Enabled="true"
                                            OnClick="btnAddRwdRul2_Click">
                                                    <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Rewards
                                        </asp:LinkButton>
                                     <asp:LinkButton ID="LinkButton2" Visible="false" Text="Edit Rewards" runat="server" CssClass="btn btn-sample" 
                                           OnClick="LnkEditRwrd_Click" >
                                         <span class="glyphicon glyphicon-pencil" style="color: White;" ></span> Edit Rewards
                                       </asp:LinkButton>
                                      <%--  <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary custom" Enabled="true"
                                         OnClick="LinkButton2_Click"
                                            >
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> SAVE    
                                        </asp:LinkButton>--%>
                                    </div>
                                </div>
                                </div>
             </div>
           
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                <br />




                <div id="Table1" runat="server" class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:Button ID="btnSaveFn" Text="SAVE" runat="server" CssClass="btn btn-sample" Width="100px"
                            Visible="false" OnClick="btnSaveFn_Click" />
                        <asp:LinkButton ID="btnCnclFn" Text="BACK" runat="server" CssClass="btn btn-sample"
                             OnClick="btnCnclFn_Click" Visible="true">
                                <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color: White;"></span> Back    
                        </asp:LinkButton>
                    </div>
                </div>
                <br />
                <div id="divAudit" runat="server" style="width: 97%;" class="panel">
                    <div id="div15" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divAuditTrail','Img8');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                 <img id="ImageCon" src="../../../images/Contestant_Details_Icon.png" style="border-width:0px;width: 35px;margin-top: -13px;margin-bottom:10px;height: 35px;"/>     
                             
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%>
                                <asp:Label ID="Label9" Text="Contest Audit Trail" Style="font-size:19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                 <span id="Img8" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                            </div>
                        </div>
                    </div>
                        <div id="divAuditTrail" runat="server" style="width: 96%;" class="">
                            <div id="div9" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                                padding: 10px;" class="table-scrollable">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gdAudit" runat="server" AutoGenerateColumns="false" Width="100%"
                                            PageSize="10" AllowSorting="True" OnSorting="gdAudit_Sorting" AllowPaging="true"
                                            DataKeyNames="CMPNSTN_CODE" CssClass="footable">
                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <%--<EmptyDataTemplate>
                                            <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>--%>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Compensation Code" SortExpression="CMPNSTN_CODE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkACompCode" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnACompCode" runat="server" Value='<%# Bind("CMPNSTN_CODE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User Id" SortExpression="USERid">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAUserId" runat="server" Text='<%# Bind("USERid")%>' />
                                                        <asp:HiddenField ID="hdnAUserId" runat="server" Value='<%# Bind("USERid")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comments Type" SortExpression="CmntType">
                                                    <HeaderStyle Width="20px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCmntType" runat="server" Text='<%# Bind("CmntType")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks" SortExpression="Remark">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")%>' />
                                                        <asp:HiddenField ID="hdnRemark" runat="server" Value='<%# Bind("Remark")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Bind("Status")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Trail Date" SortExpression="CreateDtim">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreatedDtim" runat="server" Text='<%# Bind("CreateDtim")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnCreatedDtim" runat="server" Value='<%# Bind("CreateDtim")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Version No." SortExpression="Version">
                                                    <HeaderStyle Width="20px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVersion" runat="server" Text='<%# Bind("Version")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddCntst" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnSaveCntst" EventName="Click" />
                            </Triggers>--%>
                                </asp:UpdatePanel>
                            </div>
                            <%--<br/>--%>
                            <div id="div8" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                <center>
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="Button1" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                            Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="Button1_Click" /><%--OnClick="btnprevious_Click"--%>
                                                        <asp:TextBox runat="server" ID="TextBox1" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="Button2" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="40px" OnClick="Button2_Click" /><%--OnClick="btnnext_Click"--%>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                        </div>
                    
                </div>
                <br />
                <div id="divRevHist" runat="server" style="width: 95%;" class="panel panel-success">
                    <div id="div16" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div10','Img9');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                                <asp:Label ID="Label10" Text="Comment History" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img9" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="div10" runat="server" style="width: 100%; padding: 10px;">
                        <div id="divkpisrch" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                            padding: 10px;" class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvRevHist" runat="server" OnSorting="gvRevHist_Sorting" AutoGenerateColumns="false"
                                        PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                runat="server" />
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Compensation Code" SortExpression="CMPNSTN_CODE">
                                                <HeaderStyle />
                                                <%--Width="10%" Delete--%>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkACompCode" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Id" SortExpression="USERid">
                                                <HeaderStyle />
                                                <%--Width="10%"--%>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <%-- Width="10%" --%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAUserId" runat="server" Text='<%# Bind("USERid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comments Type" SortExpression="CmntType">
                                                <HeaderStyle />
                                                <%--Width="10%" --%>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <%-- Width="10%"--%>
                                                <%--<HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCmntType" runat="server" Text='<%# Bind("CmntType")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks" SortExpression="Remark">
                                                <HeaderStyle />
                                                <%--Width="10%" --%>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <%-- Width="10%"--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comments By" SortExpression="SubCmntDesc">
                                                <HeaderStyle />
                                                <%--Width="10%"--%>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <%--Width="10%" --%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubCmntDsc" runat="server" Text='<%# Bind("SubCmntDesc")%>' />
                                                    <asp:HiddenField ID="hdnSubCmntId" runat="server" Value='<%# Bind("SubCmntId")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rule Type" SortExpression="RuleType">
                                                <HeaderStyle />
                                                <%--Width="10%"--%>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <%-- Width="10%"--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleType" runat="server" Text='<%# Bind("RuleType")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                <HeaderStyle />
                                                <%-- Width="10%"--%>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <%--Width="10%"--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Trail Date" SortExpression="CreateDtim">
                                                <HeaderStyle />
                                                <%--Width="10%" --%>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <%-- Width="10%" --%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreatedDtim" runat="server" Text='<%# Bind("CreateDtim")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Version No." SortExpression="Version">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <%--Width="10%" --%>
                                                <ItemStyle HorizontalAlign="left" />
                                                <%-- Width="10%" --%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVersion" runat="server" Text='<%# Bind("Version")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddCntst" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnSaveCntst" EventName="Click" />
                            </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                        <div id="div11" visible="true" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprvgvRevHist" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprvgvRevHist_Click" />
                                                    <asp:TextBox runat="server" ID="txtbtnprvgvRevHist" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnxtgvRevHist" Text=">" CssClass="form-submit-button" runat="server"
                                                        Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                        OnClick="btnnxtgvRevHist_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </div>
                </div>
            </center>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </asp:Panel>


    <div id="myModal" class="yourDiv" style="display: none" runat="server">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">

                <div id="divModel" runat="server" style="width: 97%;" class="panel">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <div id="Div17" runat="server" class="panel-heading" style="width: 99%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmdlBody','myImg5');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left; font-size: 19px;">

                                <asp:Label ID="Label14" Text="Reward Search " runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg5" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="panel-body" id="divmdlBody">
                        <div class="row" id="divsrch" style="margin-bottom: 5px;" visible="true" runat="server">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblrule" Text="Rule Set Key" runat="server" CssClass="control-label" />
                                <span style="color: red;">*</span>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:DropDownList runat="server" ID="ddlRulesetkey" AutoPostBack="true"
                                    CssClass="form-control" Width="100%" OnSelectedIndexChanged="ddlRulesetkey_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>


                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="LblCycle" Text="Cycle" runat="server" CssClass="control-label" />
                                <span style="color: red;">*</span>
                            </div>
                            <div class="col-sm-3" style="text-align: left">

                                <asp:DropDownList runat="server" ID="ddlCycle"
                                    CssClass="form-control" Width="100%" AutoPostBack="true">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">

                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClick="btnSearch_click">
                                        <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>

                                <asp:LinkButton ID="lnkClose" runat="server" CssClass="btn btn-sample" OnClick="btnEditCancel_click">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>

                            </div>
                        </div>
                        <div id="div18" runat="server" style="width: 100%; border: none; margin: 0px 0 !important; overflow: auto;"
                            class="table-scrollable">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridMdlEditRwrd" runat="server" CssClass="footable" AllowSorting="True" PageSize="10"
                                        OnSorting="GridMdlEditRwrd_Sorting" AllowPaging="false" AutoGenerateColumns="false" OnRowDataBound="GridMdlEditRwrd_RowDataBound">
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle CssClass="disablepage" />
                                        <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <%--  1--%>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img alt="" id="img2" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                    <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                        class="table-scrollable,divBorder1">
                                                        <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="dgCntst1" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable">

                                                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                    <PagerStyle CssClass="disablepage" />
                                                                    <HeaderStyle CssClass="gridview th" />
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                            runat="server" />
                                                                    </EmptyDataTemplate>
                                                                    <Columns>


                                                                        <asp:TemplateField HeaderText="Buisiness Type" SortExpression="BusType">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBusType" runat="server" Text='<%# Bind("BusType")%>' />
                                                                                <asp:HiddenField ID="lblBusType11" runat="server" Value='<%# Bind("BusType")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Product Code" SortExpression="ProdCode">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblProdCode" runat="server" Text='<%# Bind("ProdCode")%>' />
                                                                                <asp:HiddenField ID="lblProdCode11" runat="server" Value='<%# Bind("ProdCode")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>


                                                                        <asp:TemplateField HeaderText="Plan Code" SortExpression="PlanCode">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPlanCode" runat="server" Text='<%# Bind("PlanCode")%>' />
                                                                                <asp:HiddenField ID="lblPlanCode11" runat="server" Value='<%# Bind("PlanCode")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Product Category" SortExpression="ProdCategory">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblProdCategory" runat="server" Text='<%# Bind("ProdCategory")%>' />
                                                                                <asp:HiddenField ID="lblProdCategory11" runat="server" Value='<%# Bind("ProdCategory")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Frequency" SortExpression="Frequency">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFrequency" runat="server" Text='<%# Bind("Frequency")%>' />
                                                                                <asp:HiddenField ID="lblFrequency11" runat="server" Value='<%# Bind("Frequency")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Policy Term From" SortExpression="PolicyTermFrom">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle CssClass="CenterAlign" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPolicyTermFrom" runat="server" Text='<%# Bind("PolicyTermFrom")%>' />
                                                                                <asp:HiddenField ID="lblPolicyTermFrom11" runat="server" Value='<%# Bind("PolicyTermFrom")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Policy Term To" SortExpression="PolicyTermTo">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle CssClass="CenterAlign" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPolicyTermTo" runat="server" Text='<%# Bind("PolicyTermTo")%>' />
                                                                                <asp:HiddenField ID="lblPolicyTermTo11" runat="server" Value='<%# Bind("PolicyTermTo")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Premium Term From" SortExpression="PremiumFrom">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle CssClass="RightAlign" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPremiumFrom" runat="server" Text='<%# Bind("PremiumFrom")%>' />
                                                                                <asp:HiddenField ID="lblPremiumFrom11" runat="server" Value='<%# Bind("PremiumFrom")%>' />
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Premium To" SortExpression="PremiumTo">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle CssClass="RightAlign" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPremiumTo" runat="server" Text='<%# Bind("PremiumTo")%>' />
                                                                                <asp:HiddenField ID="lblPremiumTo11" runat="server" Value='<%# Bind("PremiumTo")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Premium Type" SortExpression="PremiumType">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPremiumType" runat="server" Text='<%# Bind("PremiumType")%>' />
                                                                                <asp:HiddenField ID="lblPremiumType11" runat="server" Value='<%# Bind("PremiumType")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Commission Rate" SortExpression="CommRate">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle CssClass="RightAlign" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCommRate" runat="server" Text='<%# Bind("CommRate")%>' />
                                                                                <asp:HiddenField ID="lblCommRate11" runat="server" Value='<%# Bind("CommRate")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Pay Mode" SortExpression="PayMode">
                                                                            <HeaderStyle Width="20px" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPayMode" runat="server" Text='<%# Bind("PayMode")%>' />
                                                                                <asp:HiddenField ID="lblPayMode11" runat="server" Value='<%# Bind("PayMode")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  2--%>
                                            <asp:TemplateField HeaderText="Reward Code" SortExpression="RWD_RUL_CODE">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRwdRulCode" runat="server" Text='<%# Bind("RWD_RUL_CODE")%>'></asp:Label>
                                                    <%--<asp:Label ID="lblRwdCode" runat="server" Text='<%# Bind("REWARD_CODE")%>'></asp:Label>--%>
                                                    <asp:HiddenField ID="hdnRwdCode" runat="server" Value='<%# Bind("REWARD_CODE")%>' />
                                                    <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  3--%>
                                            <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCYCLE" runat="server" Text='<%# Eval("CYCLE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCYCLE1" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                    <asp:HiddenField ID="hdnCycCd" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  4--%>
                                            <asp:TemplateField HeaderText="Category Code" SortExpression="CATG_CODE">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatgCd" runat="server" Text='<%# Bind("CATG_CODE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  5--%>
                                            <asp:TemplateField HeaderText="Category Classification" SortExpression="CATEGORY">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATG_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  6--%>
                                            <asp:TemplateField HeaderText="RS Key" SortExpression="RULE_SET_KEY_DESC">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  7--%>
                                            <asp:TemplateField HeaderText="Reward Type" SortExpression="REWARD_TYPE_DESC">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>--%>
                                                    <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("REWARD_TYPE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  8--%>
                                            <asp:TemplateField HeaderText="Unit Type" SortExpression="TYPE_DESC">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("TYPE_DESC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("TYPE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  9--%>
                                            <asp:TemplateField HeaderText="Based On KPI" SortExpression="KPI_DESC">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>--%>
                                                    <asp:Label ID="lblBsdKpi" runat="server" Text='<%# Eval("KPI_DESC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnBsdKpi" runat="server" Value='<%# Eval("KPI_CODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  10--%>
                                            <asp:TemplateField HeaderText="Value" SortExpression="VALUE">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValue" runat="server" Text='<%# Eval("VALUE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnValue" runat="server" Value='<%# Bind("VALUE")%>' />
                                                    <asp:HiddenField ID="hdnRate" runat="server" Value='<%# Bind("RATE")%>' />
                                                    <asp:LinkButton ID="lnkValue" Text="..." runat="server" Visible="false" OnClick="lnkValue_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  11--%>
                                            <asp:TemplateField HeaderText="Reward Desc" SortExpression="RWD_DESC">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRwdDesc" runat="server" Text='<%# Bind("RWD_DESC")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnRwdDesc" runat="server" Value='<%# Bind("RWD_DESC")%>' />
                                                    <asp:HiddenField ID="hdnRwdDesc1" runat="server" Value='<%# Bind("RWRD_DESC02")%>' />
                                                    <asp:HiddenField ID="hdnRwdDesc2" runat="server" Value='<%# Bind("RWRD_DESC03")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  12--%>
                                            <asp:TemplateField HeaderText="Breakup Rule" SortExpression="BRK_RULE">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBrkRul" runat="server" Text='<%# Eval("BRK_RULE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnBrkRul" runat="server" Value='<%# Bind("BRK_RULE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  13--%>
                                            <asp:TemplateField HeaderText="Rate" SortExpression="RATE">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRATE" runat="server" Text='<%# Eval("RATE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnRATE1" runat="server" Value='<%# Bind("RATE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  14--%>

                                            <asp:TemplateField HeaderText="Member Code" SortExpression="MEMBERCODE">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMEMBERCODE" runat="server" Text='<%# Eval("MEMBERCODE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMEMBERCODE" runat="server" Value='<%# Bind("MEMBERCODE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  15--%>
                                            <asp:TemplateField HeaderText="Target From" SortExpression="TRGT_FROM">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTRGT_FROM" runat="server" Text='<%# Eval("TRGT_FROM")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnTRGT_FROM" runat="server" Value='<%# Bind("TRGT_FROM")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  16--%>
                                            <asp:TemplateField HeaderText="Target To" SortExpression="TRGT_TO">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTRGT_TO" runat="server" Text='<%# Eval("TRGT_TO")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnTRGT_TO" runat="server" Value='<%# Bind("TRGT_TO")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  17--%>
                                            <%-- added by arjun dated on 06/09/2018 for the UAT bug 2052--%>
                                            <asp:TemplateField HeaderText="Reason for Edit Rate" SortExpression="ParamDesc1">
                                                <HeaderStyle Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="LBLParamDesc1RED" runat="server" Text='<%# Bind("ParamDesc1")%>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--   ended by arjun--%>

                                            <%--  18--%>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="lnkEditRwdRulMdl" runat="server" Text="Edit" OnClick="lnkEditRwdRulMdl_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  19--%>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelRwdRul" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                        OnClick="lnkDelRwdRul_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddRwdRul" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSaveRwdRul" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="LNKRWD" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div id="div19" visible="false" runat="server" class="pagination" style="padding: 10px;">
                            <center>
                                        <table>
                                            <tr>
                                                <td style="white-space: nowrap;">
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="Button4" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevrwdrul_Click" />
                                                            <asp:TextBox runat="server" ID="TexeditRwd" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextrwdrulEdit" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false" OnClick="btnnextrwdrul_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>



    <asp:Panel runat="server" Height="450px" Width="1100px" ID="pnlMdl" display="none"
        Style="text-align: center; padding: 10px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" Height="330px" Width="1000px" ID="pnlcmnt" display="none"
        Style="text-align: center; padding: 10px;">
        <iframe runat="server" id="ifrmMdlPopcmnt" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label6" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBIDcmnt"
        DropShadow="false" TargetControlID="Label6" PopupControlID="pnlcmnt" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" Height="275px" Width="1020px" ID="pnlMdl1" display="none"
        Style="text-align: center; padding: 10px;">
        <iframe runat="server" id="ifrmMdlPopup1" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl2" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView1" BehaviorID="mdlViewBID1"
        DropShadow="false" TargetControlID="lbl2" PopupControlID="pnlMdl1" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" Height="494px" Width="1020px" ID="pnlQualTrg" display="none"
        Style="text-align: center; padding: 10px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmQualTrg" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label4" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwQTrg" BehaviorID="mdlVwQTrgBID" ClientIDMode="Static"
        DropShadow="false" TargetControlID="Label4" PopupControlID="pnlQualTrg" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>




    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" Height="510px" Width="1000px" ID="pnlRwdRul" display="none"
                Style="text-align: center; top: 20%" CssClass="panel panel-success">
                <iframe runat="server" id="ifrmRwdRul" scrolling="yes" width="100%" frameborder="0"
                    display="none" style="height: 100%;"></iframe>
            </asp:Panel>
            <asp:Label runat="server" ID="Label5" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwRwdRul" BehaviorID="mdlVwRwdRulBID"
                DropShadow="false" TargetControlID="Label5" PopupControlID="pnlRwdRul" BackgroundCssClass="modalPopupBg">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="250px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">INFORMATION
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lbl3" runat="server"></asp:Label></center>
                            <br />
                            <center>
                                <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                        </td>
                    </tr>
                </table>
                <center>
                    <br />
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="standardbutton" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnChn" runat="server" />
            <asp:HiddenField ID="hdnSbChn" runat="server" />
            <asp:HiddenField ID="hdnMemType" runat="server" />
            <asp:HiddenField ID="hdnKPICd" runat="server" />
            <asp:HiddenField ID="hdnKPIDsc" runat="server" />
            <asp:HiddenField ID="hdnAccMd" runat="server" />
            <asp:HiddenField ID="hdnAccMdDsc" runat="server" />
            <asp:HiddenField ID="hdnVerFrm" runat="server" />
            <asp:HiddenField ID="hdnVerTo" runat="server" />
            <asp:HiddenField ID="hdnCRYFWDQ" runat="server" />
            <asp:HiddenField ID="hdnRwdCmpRulQ" runat="server" />
            <asp:HiddenField ID="hdnUnitTypeQ" runat="server" />
            <asp:HiddenField ID="hdnUnitTypeDscQ" runat="server" />
            <asp:HiddenField ID="hdnMaxLmtQ" runat="server" />
            <asp:HiddenField ID="hdnRulSetKy" runat="server" />
            <asp:HiddenField ID="hdnRulSetKyQ" runat="server" />
            <asp:HiddenField ID="hdnCatgCode" runat="server" />
            <asp:HiddenField ID="hdnCatgCnt" runat="server" />
            <asp:HiddenField ID="hdnRwrdCnt" runat="server" />
            <asp:HiddenField ID="hdnVersnFrm1" runat="server" />
            <asp:HiddenField ID="hdnVrsnTo1" runat="server" />
            <asp:HiddenField ID="hdnFlag" runat="server" />
            <asp:HiddenField ID="hdnQualCnt" runat="server" />
            <asp:HiddenField ID="hdnRuleCode" runat="server" />
            <asp:HiddenField ID="hdnstatus" runat="server" />
            <asp:HiddenField ID="hdnstatusval" runat="server" />

            <asp:HiddenField ID="hdnChannel" runat="server" />
            <asp:HiddenField ID="hdnChnCls" runat="server" />
            <asp:HiddenField ID="hdnMemTyp" runat="server" />

            <asp:HiddenField ID="hdnBUSI_CODE" runat="server" />
            <asp:HiddenField ID="hdnVerEffFrom" runat="server" />
            <asp:HiddenField ID="hdnVerEffTo" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnrwdrul" runat="server" Style="display: none;" ClientIDMode="Static"
        OnClick="btnrwdrul_Click" />
    <asp:Button ID="btnrwd" runat="server" ClientIDMode="Static" Style="display: none;"
        OnClick="btnrwd_Click" />
    <%--    <asp:Button ID="btnUpdRWD" runat="server" ClientIDMode="Static" Style="display: none;"
        OnClick="btnUpdRWD_Click" />--%>
    <asp:Button ID="btnrwdtrg" runat="server" ClientIDMode="Static" Style="display: none;"
        OnClick="btnrwdtrg_Click" />
    <asp:Button ID="btnqualrul" runat="server" Style="display: none;" ClientIDMode="Static"
        OnClick="btnqualrul_Click" />
    <asp:Button ID="btnUpdRevGrd" runat="server" Style="display: none;" ClientIDMode="Static"
        OnClick="btnUpdRevGrd_Click" />
    <asp:Panel runat="server" ID="pnlDwnld" display="none"
        Style="text-align: center; padding: 10px; background-color: White;">
        <table id="Table2" runat="server" style="width: 100%;">
            <tr>
                <td style="text-align: center; padding-bottom: 5px; padding-top: 5px; white-space: nowrap;"
                    colspan="4">
                    <asp:Button ID="Button3" Text="BULK DOWNLOAD TARGETS" runat="server" Width="200px"
                        CssClass="btn btn-sample" Enabled="true" OnClick="btnBlkQualDwnld_Click" />
                    <asp:Button ID="btnCncBlk" runat="server" Text="CANCEL" Width="100px" ClientIDMode="Static"
                        OnClientClick="doCancel();return false;" CssClass="btn btn-sample" />
                    <asp:GridView ID="gvFiles" runat="server" Visible="false">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>



    <asp:Label runat="server" ID="Label21" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwTrg" BehaviorID="mdlVwTrgBID"
        DropShadow="false" TargetControlID="Label21" PopupControlID="pnlDwnld" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>


    <asp:Panel runat="server" Height="350px" Width="900px" ID="pnlRwdRulDemo" display="none"
        Style="text-align: center; padding: 10px; margin-left: 200px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmRwd1" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label11" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw" BehaviorID="mdlVwBID" DropShadow="false"
        TargetControlID="Label11" PopupControlID="pnlRwdRulDemo" BackgroundCssClass="modalPopupBg" X="15" Y="30">
    </ajaxToolkit:ModalPopupExtender>





    <asp:Panel runat="server" Height="450px" Width="900px" ID="Panel1" display="none"
        Style="text-align: center; padding: 8px; margin-left: 200px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmRwd2" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label12" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw1" BehaviorID="mdlVwBID1" DropShadow="false"
        TargetControlID="Label12" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg" X="15" Y="30">
    </ajaxToolkit:ModalPopupExtender>



    <asp:Panel runat="server" Height="400px" Width="900px" ID="Panel2" display="none"
        Style="text-align: center; padding: 8px; margin-left: 200px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmRwd3" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label13" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw2" BehaviorID="mdlVwBID2" DropShadow="false" X="15" Y="30"
        TargetControlID="Label13" PopupControlID="Panel2" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>


</asp:Content>
