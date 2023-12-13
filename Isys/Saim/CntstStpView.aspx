<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CntstStpView.aspx.cs" MasterPageFile="~/iFrame.master"
    Inherits="Application_ISys_Saim_CntstStpView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
            + "&mdlpopup=mdlViewBID";
        }

        function funEditPopUp(div, rultyp, code, sID) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopQualSetup.aspx?code=" + code + "&kpicode=" + document.getElementById(strContent + "hdnKPICd").id
            + "&kpidesc=" + document.getElementById(strContent + "hdnKPIDsc").id + "&accmd=" + document.getElementById(strContent + "hdnAccMd").id
            + "&verfrm=" + document.getElementById(strContent + "hdnVerFrm").id + "&verto=" + document.getElementById(strContent + "hdnVerTo").id
            + "&CRYFWD=" + document.getElementById(strContent + "hdnCRYFWDQ").id + "&RwdCmpRul=" + document.getElementById(strContent + "hdnRwdCmpRulQ").id
            + "&UnitType=" + document.getElementById(strContent + "hdnUnitTypeQ").id + "&MaxLmt=" + document.getElementById(strContent + "hdnMaxLmtQ").id
            + "&UnitTypeDsc=" + document.getElementById(strContent + "hdnUnitTypeDscQ").id
            + "&verfrmval=" + document.getElementById(strContent + "hdnVersnFrm1").value + "&vertoval=" + document.getElementById(strContent + "hdnVrsnTo1").value
            + "&accmddsc=" + document.getElementById(strContent + "hdnAccMdDsc").id + "&rulsetky=" + document.getElementById(strContent + "hdnRulSetKy").value
            + "&rulsetkyid=" + document.getElementById(strContent + "hdnRulSetKy").id + "&chkdivid=" + document.getElementById(strContent + div).id
            + "&rultyp=" + rultyp + "&RuleCode=" + document.getElementById(strContent + "hdnRuleCode").id
            + "&cmpnstcd=" + document.getElementById(strContent + "lblCompCodeVal").innerText
            + "&cntstcd=" + document.getElementById(strContent + "lblCntstCdVal").innerText
            + "&mdlpopup=mdlViewBID";
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

        function funPopUpTrg(sort, cmpcode, cntstcd, rultyp, catgcd, sID) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwQTrgBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmQualTrg").src = "QualTrgStp.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&catgcd=" + catgcd + "&sID=" + sID + "&flag=" + document.getElementById(strContent + "hdnFlag").id
            + "&sort=" + sort
            + "&mdlpopup=mdlVwQTrgBID";
        }

        function funPopUpRwdRul(cmpcode, cntstcd, rultyp) {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwRwdRulBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopRwdRul.aspx?compcode=" + cmpcode + "&cntstcd=" + cntstcd
            + "&rultyp=" + rultyp + "&mdlpopup=mdlVwRwdRulBID";
        }

        function funPopUpFrml() {
            //////alert('akshay');
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID1").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup1").src = "PopFrmlEdit.aspx?mdlpopup=mdlViewBID1";
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
    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
        <ContentTemplate>
            <center>
                <div id="divcmphdrcollapse" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="lblhdr" Text="Compensation Details" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img4" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                    alt="" onclick="funcall();" />
                                <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divcmphdr" runat="server" style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="1"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompDesc1Val" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="2"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCompDesc2" Text="Compensation Description" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompDesc2Val" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblAccCyc" Text="Accumulation Cycle" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblAccCycVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblAccYr" Text="Accumulation Year" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblAccYrVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCompTyp" Text="Compensation Type" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompTypVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblAccCycle" Text="Accural Cycle" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblAccCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblReleaseCycle" Text="Release Cycle" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblReleaseCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="Label7" Text="Business Year" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblBusYr" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="Label8" Text="Version" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap; top: 120px; left: 714px;" class="col-md-7">
                                    <asp:Label ID="lblVersion" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblEffDtFrm" Text="Effective From" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblEffDtFrmVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblEffDtTo" Text="Effective To" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblEffDtToVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <div id="divcntstcollapse" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="Label1" Text="Contestant Details" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img5" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                    alt="" onclick="funcall();" />
                                <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcntst','Img1','#Img1');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divcntst" runat="server" style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCntstCd" Text="Contestant Code" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCntstCdVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="1"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblSlsChnl" Text="Sales Channel" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblSlsChnlVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="2"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblSbCls" Text="Sub Class" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblSbClsVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="1"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblMemTyp" Text="Member Type" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblMemTypVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="2"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblFinYr" Text="Financial Year" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblFinYrVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="1"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblVer" Text="Version" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblVerVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="2"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblEffFrmCnt" Text="Effective From" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblEffFrmValCnt" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="1"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblEffToCnt" Text="Effective To" runat="server" CssClass="control-label col-md-5" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblEffToValCnt" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="2"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="divqualcollapse" runat="server" style="width: 90%;" class="divBorder1">
                            <div id="divhdr" runat="server" onclick="ShowDiv('div12');">
                                <table class="formtablehdr" style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td style="padding-left: 5px;">
                                            <i class="fa fa-list"></i>
                                            <asp:Label ID="Label2" Text="Qualification rule details" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                        <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                            <img id="Img6" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                                alt="" onclick="funcall();" />
                                            <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDiv('divqual','Img2','#Img2','chkQual','div12');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div12" runat="server" style="display: none; text-align: left; padding-left: 5px;">
                                <asp:CheckBox ID="chkQual" Text="Please check for setting qualification rule" runat="server"
                                    CssClass="checkbox" />
                            </div>
                            <div id="divqual" runat="server" style="width: 100%; padding: 10px; display: block;">
                                <h3 class="form-section" style="text-align: left;">
                                    Key performance indicators</h3>
                                <div id="div3" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgQual" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                                AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false">
                                                <HeaderStyle ForeColor="Black" Width="100%" />
                                                <RowStyle />
                                                <PagerStyle CssClass="disablepage" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Rule Code" SortExpression="RULE_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulCode" runat="server" Text='<%# Bind("RULE_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulCode" runat="server" Value='<%# Bind("RULE_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPIDesc" runat="server" Text='<%# Bind("KPI_DESC")%>' />
                                                            <asp:HiddenField ID="hdnKPIDesc" runat="server" Value='<%# Bind("KPI_DESC")%>' />
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
                                                    <%--<asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" Enabled="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClick="lnkDelete_Click"
                                                                Enabled="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkQSetRule" runat="server" Text="Set Rule" OnClick="lnkQSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
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
                                                            <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
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
                                <table id="tblqual" runat="server" Visible="false" class="form-actions fluid" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                            <asp:Button ID="btnAddQual" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true"  />
                                            <asp:Button ID="btnSaveQual" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnSaveQual_Click" />
                                            <asp:Button ID="btnqual" runat="server" ClientIDMode="Static" Style="display: none;"
                                                OnClick="btnqual_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <h3 class="form-section" style="text-align: left;">
                                    Key performance indicator targets</h3>
                                <div id="div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgQualTrg" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                                AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false" >
                                                <HeaderStyle ForeColor="Black" Width="100%" />
                                                <RowStyle />
                                                <PagerStyle CssClass="disablepage" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY")%>'></asp:Label>
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
                                                    <asp:TemplateField HeaderText="Category Description" SortExpression="MEMTYPE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("CATG_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("CATG_DESC")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
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
                                                    <%--<asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditQualTrg" runat="server" Text="Edit" Enabled="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelQualTrg" runat="server" Text="Delete" Enabled="false" OnClick="lnkDelQualTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkRwdSetRule" runat="server" Text="Set Rule" OnClick="lnkRwdSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnprevkpitrg" Text="<" CssClass="form-submit-button" runat="server"
                                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevkpitrg_Click" />
                                                            <asp:TextBox runat="server" ID="txtpagetrg" Style="width: 40px; border-style: solid;
                                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                            <asp:Button ID="btnnextkpitrg" Text=">" CssClass="form-submit-button" runat="server"
                                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                                Enabled="false" OnClick="btnnextkpitrg_Click" />
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
                                <table id="tblqualtrg" runat="server" Visible="false" class="form-actions fluid" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                            <asp:Button ID="btnAddQualTrg" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnAddQualTrg_Click" />
                                            <asp:Button ID="btnSaveQualTrg" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnSaveQualTrg_Click" />
                                            <asp:Button ID="btnqualtrg" runat="server" ClientIDMode="Static" Style="display: none;"
                                                OnClick="btnqualtrg_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <div id="divRwdcollapse" runat="server" style="width: 90%;" class="divBorder1">
                            <div id="div2" runat="server" onclick="ShowDiv('divchkRwd');">
                                <table class="formtablehdr" style="width: 100%;">
                                    <tr style="height: 30px;">
                                        <td style="padding-left: 5px;">
                                            <i class="fa fa-list"></i>
                                            <asp:Label ID="Label3" Text="Reward rule details" runat="server" Style="padding-left: 5px;" />
                                        </td>
                                        <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                            <img id="Img7" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                                alt="" onclick="funcall();" />
                                            <img id="Img3" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDiv('divRwd','Img3','#Img3','chkRwd');" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divchkRwd" runat="server" style="display: none; text-align: left; padding-left: 5px;">
                                <asp:CheckBox ID="chkRwd" Text="Please check for setting rewards rule" runat="server"
                                    CssClass="checkbox" />
                            </div>
                            <div id="divRwd" runat="server" style="width: 100%; padding: 10px; display: block;">
                                <h3 class="form-section" style="text-align: left;">
                                    Key performance indicators</h3>
                                <div id="div4" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgReward" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                                AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false" >
                                                <HeaderStyle ForeColor="Black" Width="100%" />
                                                <RowStyle />
                                                <PagerStyle CssClass="disablepage" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Rule Code" SortExpression="RULE_CODE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulCode" runat="server" Text='<%# Bind("RULE_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulCode" runat="server" Value='<%# Bind("RULE_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPI_CODE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Description" SortExpression="KPI_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPIDesc" runat="server" Text='<%# Bind("KPI_DESC")%>' />
                                                            <asp:HiddenField ID="hdnKPIDesc" runat="server" Value='<%# Bind("KPI_DESC")%>' />
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
                                                    <%--<asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwd" runat="server" Text="Edit"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                                OnClick="lnkDelRwd_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkKPISetRule" runat="server" Text="Set Rule" OnClick="lnkKPISetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddRwd" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveRwd" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
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
                                <div style="text-align: left; padding: 10px;">
                                    <asp:Label ID="lblNote" runat="server" ForeColor="Red" /></div>
                                <div style="text-align: left;">
                                    <asp:LinkButton ID="lnkKeyDfn" Text="Rule Set Key Definition" Visible="false" runat="server" /></div>
                                <table id="tblrwd" runat="server" Visible="false" class="form-actions fluid" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                            <asp:Button ID="btnAddRwd" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" />
                                            <asp:Button ID="btnSaveRwd" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnSaveRwd_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <h3 class="form-section" style="text-align: left;">
                                    Key performance indicator targets</h3>
                                <div id="div5" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdTrg" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                                AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false" >
                                                <HeaderStyle ForeColor="Black" Width="100%" />
                                                <RowStyle />
                                                <PagerStyle CssClass="disablepage" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY")%>'></asp:Label>
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
                                                    <%--<asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwdTrg" runat="server" Text="Edit" Enabled="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelRwdTrg" runat="server" Text="Delete" Enabled="false" OnClick="lnkDelRwdTrg_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Std Def.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkKPITrgtSetRule" runat="server" Text="Set Rule" OnClick="lnkKPITrgtSetRule_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddRwdTrg" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveRwdTrg" EventName="Click" />
                                        </Triggers>
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
                                                                Enabled="false" OnClick="btnnextrwdtrg_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                                <table id="tblrwdtrg" runat="server" Visible="false" class="form-actions fluid" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                            <asp:Button ID="btnAddRwdTrg" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnAddRwdTrg_Click" />
                                            <asp:Button ID="btnSaveRwdTrg" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnSaveRwdTrg_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <h3 class="form-section" style="text-align: left;">
                                    Key performance indicator reward rules</h3>
                                <div id="div6" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                    class="table-scrollable">
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgRwdRul" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                                AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false" OnRowDataBound="dgRwdRul_RowDataBound">
                                                <HeaderStyle ForeColor="Black" Width="100%" />
                                                <RowStyle />
                                                <PagerStyle CssClass="disablepage" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Reward Code" SortExpression="REWARD_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdCode" runat="server" Text='<%# Bind("REWARD_CODE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRwdCode" runat="server" Value='<%# Bind("REWARD_CODE")%>' />
                                                            <asp:HiddenField ID="hdnCycle" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category Code" SortExpression="CATG_CODE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCd" runat="server" Text='<%# Bind("CATG_CODE")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category Classification" SortExpression="CATEGORY">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCatgCode" runat="server" Text='<%# Bind("CATEGORY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CATG_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRulStKy" runat="server" Text='<%# Bind("RULE_SET_KEY")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRulStKy" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reward Type" SortExpression="REWARD_TYPE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>--%>
                                                            <asp:Label ID="lblCatDsc" runat="server" Text='<%# Bind("REWARD_TYPE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCatDsc" runat="server" Value='<%# Bind("REWARD_TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="TYPE_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("TYPE_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("TYPE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Based On KPI" SortExpression="KPI_CODE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>--%>
                                                            <asp:Label ID="lblBsdKpi" runat="server" Text='<%# Eval("KPI_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnBsdKpi" runat="server" Value='<%# Eval("KPI_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value" SortExpression="VALUE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValue" runat="server" Text='<%# Eval("VALUE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnValue" runat="server" Value='<%# Bind("VALUE")%>' />
                                                            <asp:HiddenField ID="hdnRate" runat="server" Value='<%# Bind("RATE")%>' />
                                                            <asp:LinkButton ID="lnkValue" Text="..." runat="server" Visible="false" OnClick="lnkValue_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reward Desc" SortExpression="RWD_DESC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRwdDesc" runat="server" Text='<%# Bind("RWD_DESC")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRwdDesc" runat="server" Value='<%# Bind("RWD_DESC")%>' />
                                                            <asp:HiddenField ID="hdnRwdDesc1" runat="server" Value='<%# Bind("RWRD_DESC02")%>' />
                                                            <asp:HiddenField ID="hdnRwdDesc2" runat="server" Value='<%# Bind("RWRD_DESC03")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Breakup Rule" SortExpression="BRK_RULE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBrkRul" runat="server" Text='<%# Eval("BRK_RULE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnBrkRul" runat="server" Value='<%# Bind("BRK_RULE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate" SortExpression="RATE">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRATE" runat="server" Text='<%# Eval("RATE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnRATE1" runat="server" Value='<%# Bind("RATE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cycle" SortExpression="CYCLE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCYCLE" runat="server" Text='<%# Eval("CYCLE")%>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCYCLE1" runat="server" Value='<%# Bind("CYCLE")%>' />
                                                            <asp:HiddenField ID="hdnCycCd" runat="server" Value='<%# Bind("CYCLE_CODE")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Action">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEditRwdRul" runat="server" Text="Edit" Enabled="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelRwdRul" runat="server" Text="Delete" Enabled="false" OnClick="lnkDelRwdRul_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddRwdRul" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnSaveRwdRul" EventName="Click" />
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
                                <table id="tblrwdrul" runat="server" Visible="false" class="form-actions fluid" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                            <asp:Button ID="btnAddRwdRul" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnAddRwdRul_Click" />
                                            <asp:Button ID="btnSaveRwdRul" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                                Enabled="true" OnClick="btnSaveRwdRul_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <div id="divAudit" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="Label6" Text="Contest Audit Trail" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img8" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divAuditTrail','Img8','#Img8');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divAuditTrail" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                        padding: 10px;" class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdAudit" runat="server" AutoGenerateColumns="false" Width="90%"
                                    PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="table table-striped table-bordered table-hover dataTable">
                                    <HeaderStyle ForeColor="Black" />
                                    <RowStyle />
                                    <PagerStyle CssClass="disablepage" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                            runat="server" />
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Contestant Code" SortExpression="CMPNSTN_CODE">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center"  />
                                            <ItemTemplate>
                                                <asp:Label ID="lnkACompCode" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnACompCode" runat="server" Value='<%# Bind("CMPNSTN_CODE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Id" SortExpression="CMPNSTN_CODE">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAUserId" runat="server" Text='<%# Bind("USERid")%>' />
                                                <asp:HiddenField ID="hdnAUserId" runat="server" Value='<%# Bind("USERid")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comments Type" SortExpression="CMPNSTN_CODE">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCmntType" runat="server" Text='<%# Bind("CmntType")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" SortExpression="CHN">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")%>' />
                                                <asp:HiddenField ID="hdnRemark" runat="server" Value='<%# Bind("Remark")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="CHNCLS">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Bind("Status")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Trail Date" SortExpression="CreateDtim">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDtim" runat="server" Text='<%# Bind("CreateDtim")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnCreatedDtim" runat="server" Value='<%# Bind("CreateDtim")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Version No." SortExpression="CMPNSTN_CODE">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblVersion" runat="server" Text='<%# Bind("Version")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <br />
                    <div id="div8" visible="true" runat="server" class="pagination">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnprevAudit" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                    Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;"  />
                                                <asp:TextBox runat="server" ID="txtAudit" Style="width: 40px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnextAudit" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px"  />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" Height="375px" Width="1020px" ID="pnlMdl" display="none"
        Style="text-align: center; padding: 10px;">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
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
        Style="text-align: center; padding: 10px;">
        <iframe runat="server" id="ifrmQualTrg" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label4" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwQTrg" BehaviorID="mdlVwQTrgBID"
        DropShadow="false" TargetControlID="Label4" PopupControlID="pnlQualTrg" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" Height="450px" Width="1000px" ID="pnlRwdRul" display="none"
                Style="text-align: center; padding: 8px;">
                <iframe runat="server" id="ifrmRwdRul" scrolling="yes" width="100%" frameborder="0"
                    display="none" style="height: 100%;"></iframe>
            </asp:Panel>
            <asp:Label runat="server" ID="Label5" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVwRwdRul" BehaviorID="mdlVwRwdRulBID"
                DropShadow="false" TargetControlID="Label5" PopupControlID="pnlRwdRul" BackgroundCssClass="modalPopupBg">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="250px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            INFORMATION
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
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
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
            <asp:HiddenField ID="hdnCatgCode" runat="server" />
            <asp:HiddenField ID="hdnCatgCnt" runat="server" />
            <asp:HiddenField ID="hdnRwrdCnt" runat="server" />
            <asp:HiddenField ID="hdnVersnFrm1" runat="server" />
            <asp:HiddenField ID="hdnVrsnTo1" runat="server" />
            <asp:HiddenField ID="hdnFlag" runat="server" />
            <asp:HiddenField ID="hdnQualCnt" runat="server" />
            <asp:HiddenField ID="hdnRuleCode" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
