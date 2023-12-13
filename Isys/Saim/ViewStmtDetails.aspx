<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="ViewStmtDetails.aspx.cs" Inherits="Application_ISys_Saim_ViewStmtDetails" %>

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
                                <%--<img id="Img4" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                    alt="" onclick="funcall();" />--%>
                                <img id="myImg" src="../../../assets/img/portlet-collapse-icon-white.png" alt=""
                                    onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divcmphdr" runat="server" style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCompCode" Text="Compensation Code" runat="server" CssClass="control-label" />
                                    <%--col-md-5--%>
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompCodeVal" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="1"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblCompDesc1" Text="Compensation Description" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompDesc1Val" runat="server" CssClass="form-control-static new_text_new"
                                        TabIndex="2"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCompDesc2" Text="Compensation Description" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompDesc2Val" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblAccCyc" Text="Accumulation Cycle" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblAccCycVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblAccYr" Text="Accumulation Year" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblAccYrVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCompTyp" Text="Compensation Type" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCompTypVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblAccCycle" Text="Accural Cycle" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblAccCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblReleaseCycle" Text="Release Cycle" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblReleaseCycleValue" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="Label7" Text="Business Year" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblBusYr" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="Label8" Text="Version" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap; top: 120px; left: 714px;" class="col-md-7">
                                    <asp:Label ID="lblVersion" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblEffDtFrm" Text="Effective From" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblEffDtFrmVal" runat="server" CssClass="form-control-static new_text_new" />
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblEffDtTo" Text="Effective To" runat="server" CssClass="control-label" />
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
                                <%--<img id="Img5" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                    alt="" onclick="funcall();" />--%>
                                <img id="Img1" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divcntst','Img1','#Img1');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divcntst" runat="server" style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblCntstCd" Text="Contestant Code" runat="server" CssClass="control-label" /><%--col-md-5--%>
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblCntstCdVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblSlsChnl" Text="Sales Channel" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblSlsChnlVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblSbCls" Text="Sub Class" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblSbClsVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblMemTyp" Text="Member Type" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblMemTypVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblFinYr" Text="Financial Year" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblFinYrVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblVer" Text="Version" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblVerVal" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                    <asp:Label ID="lblEffFrmCnt" Text="Effective From" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblEffFrmValCnt" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                                <td style="white-space: nowrap; width: 20%;" class="form-body align  col-md-6">
                                    <asp:Label ID="lblEffToCnt" Text="Effective To" runat="server" CssClass="control-label" />
                                </td>
                                <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                    <asp:Label ID="lblEffToValCnt" runat="server" CssClass="form-control-static new_text_new"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <div id="divgrdCycHdr" runat="server" style="width: 90%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="Label2" Text="Statement Details" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <%--<img id="Img5" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                    alt="" onclick="funcall();" />--%>
                                <img id="Img2" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divgrdCyc','Img2','#Img2');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divgrdCyc" runat="server" style="width: 100%;">
                        <div id="div1" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                            padding: 10px;" class="table-scrollable">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgCycGrd" runat="server" AutoGenerateColumns="false" Width="100%"
                                        PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable">
                                        <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Member Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemCode" Text='<%# Bind("MEM_NAME") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnMemCode" Value='<%# Bind("MEM_CODE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cycle Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCycName" Text='<%# Bind("CYCLE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cycle Run Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCycCode" Text='<%# Bind("CYCLE_DESC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCycCode" Value='<%# Bind("CYCLE_CODE") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnEfffrm" Value='<%# Bind("EFF_FROM") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnEffto" Value='<%# Bind("EFF_TO") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatgCode" Text='<%# Bind("CATG_DESC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnCatgCode" Value='<%# Bind("CATG_CODE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reward Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRwdCode" Text='<%# Bind("REWARD_DESC") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnRwdCode" Value='<%# Bind("REWARD_CODE") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRwdAmt" Text='<%# Bind("CALC_RWD_AMT") %>' 
                                                        runat="server" onclick="lnkRwdAmt_Click" />
                                                    <asp:HiddenField ID="hdnAchvAmt" Value='<%# Bind("CALC_AMT") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
                <asp:Panel runat="server" Height="250px" Width="800px" ID="pnlMdl" display="none"
                    Style="text-align: center; padding: 10px; background-color: White;">
                    <div id="div2" runat="server" style="width: 100%;" class="divBorder1">
                        <table class="formtablehdr" style="width: 100%;">
                            <tr style="height: 30px;">
                                <td style="padding-left: 5px;">
                                    <i class="fa fa-list"></i>
                                    <asp:Label ID="Label3" Text="Achievement Details" runat="server" Style="padding-left: 5px;" />
                                </td>
                                <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                    <img id="Img3" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divachv','Img2','#Img2');" />
                                </td>
                            </tr>
                        </table>
                        <div id="div3" runat="server" style="width: 100%;">
                            <div id="divachv" runat="server" style="width: 100%; border: none; padding: 10px;"
                                class="table-scrollable">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgAchv" runat="server" AutoGenerateColumns="false" Width="100%"
                                            PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable">
                                            <HeaderStyle ForeColor="Black" CssClass="sorting" />
                                            <RowStyle />
                                            <PagerStyle CssClass="disablepage" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Rule Set Key">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRSKdesc" runat="server" Text='<%# Bind("RULE_SET_KEY_DESC")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnRSKdesc" runat="server" Value='<%# Bind("RULE_SET_KEY")%>'>
                                                        </asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="KPI Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPI_DESC")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPI_CODE")%>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Achievements">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAchAmt" runat="server" Text='<%# Bind("ACHVD_AMT")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table class="form-actions fluid" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                            <asp:Button ID="btnCncl" Text="CANCEL" runat="server" Width="100px" CssClass="btn default" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Label runat="server" ID="lbl1" Style="display: none" />
                <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
                    DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
                </ajaxToolkit:ModalPopupExtender>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnChn" runat="server" />
            <asp:HiddenField ID="hdnSbChn" runat="server" />
            <asp:HiddenField ID="hdnMemType" runat="server" />
            <asp:HiddenField ID="hdnVersnFrm1" runat="server" />
            <asp:HiddenField ID="hdnVrsnTo1" runat="server" />
            <asp:HiddenField ID="hdnstatusval" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
