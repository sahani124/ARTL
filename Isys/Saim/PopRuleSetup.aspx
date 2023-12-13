<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopRuleSetup.aspx.cs" Inherits="Application_ISys_Saim_PopRuleSetup" %>

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

        function funPopUpPrdct(div) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopStdPrdctDef.aspx?PrdctName=" + document.getElementById(strContent + "hdnPrdctName").id
            + "&PrdctFreq=" + document.getElementById(strContent + "hdnPrctFreq").id + "&Consider=" + document.getElementById(strContent + "hdnConsider").id
            + "&Type=" + document.getElementById(strContent + "hdnType").id + "&PrdctNameval=" + document.getElementById(strContent + "hdnPrdctNameval").id
            +"&PrdctFreqval=" + document.getElementById(strContent + "hdnPrctFreqval").id + "&Considerval=" + document.getElementById(strContent + "hdnConsiderval").id
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
                <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="divBorder1">
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
                <div id="divStdDefPrdtDtls" runat="server" style="width: 97%;" class="divBorder1">
                    <div id="divhdr" runat="server" onclick="ShowDiv('div12');">
                        <table class="formtablehdr" style="width: 100%;">
                            <tr style="height: 30px;">
                                <td style="padding-left: 5px;">
                                    <i class="fa fa-list"></i>
                                    <asp:Label ID="lblStdDefPrdtDtl" Text="Standard Definition details" runat="server"
                                        Style="padding-left: 5px;" />
                                </td>
                                <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                    <img id="Img6" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 5px;"
                                        alt="" onclick="funcall();" />
                                    <img id="Img3" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divPrdct','Img3','#Img3');" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divPrdct" runat="server" style="width: 100%; padding: 10px; display: block;">
                        <div id="divStdDefLOBDtls" runat="server" style="width: 100%; padding: 10px; display: block;">
                            <h3 class="form-section" style="text-align: left;">
                                LOB level weightage definitions</h3>
                            <div id="div6" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                class="table-scrollable">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgLOBGrid" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                            PageSize="10" AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false">
                                            <HeaderStyle ForeColor="Black" Width="100%" />
                                            <RowStyle />
                                            <PagerStyle CssClass="disablepage" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="LOB Name" SortExpression="LOB_DESC">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLOBName" runat="server" Text='<%# Bind("LOB_DESC")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnLOBName" runat="server" Value='<%# Bind("LOB_DESC")%>' />
                                                        <asp:HiddenField ID="hdnLOBCode" runat="server" Value='<%# Bind("LOB_CODE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Frequency" SortExpression="FREQUENCY">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLOBFreq" runat="server" Text='<%# Bind("FREQUENCY")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnLOBFreq" runat="server" Value='<%# Bind("FREQUENCY")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Consider" SortExpression="CONSIDER">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLOBConsider" runat="server" Text='<%# Bind("CONSIDER")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnLOBConsider" runat="server" Value='<%# Bind("CONSIDER")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type" SortExpression="TYPE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLOBType" runat="server" Text='<%# Bind("TYPE")%>' />
                                                        <asp:HiddenField ID="hdnLOBTyp" runat="server" Value='<%# Bind("TYPE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Weightage" SortExpression="WEIGHTAGE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLOBWeightg" runat="server" Text='<%# Bind("WEIGHTAGE")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnLOBWghtg" runat="server" Value='<%# Bind("WEIGHTAGE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDeleteLOB" runat="server" onclick="lnkDeleteLOB_Click" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div id="div7" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                <center>
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprevStdLOB" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevStdLOB_Click" />
                                                        <asp:TextBox runat="server" ID="txtStdLOBPage" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextStdLOB" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                            Enabled="false" OnClick="btnnextStdLOB_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                            <table id="Table1" runat="server" class="form-actions fluid" style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                        <asp:Button ID="btnAddStdLOB" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                            Enabled="true" OnClick="btnAddStdLOB_Click" />
                                        <asp:Button ID="btnSaveStdLOB" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                            Enabled="true" OnClick="btnSaveStdLOB_Click" />
                                        <asp:Button ID="btnLOB" runat="server" ClientIDMode="Static" Style="display: none;"
                                            OnClick="btnLOB_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divStdDefPrdDtls" runat="server" style="width: 100%; padding: 10px; display: block;">
                            <h3 class="form-section" style="text-align: left;">
                                Product level weightage definitions</h3>
                            <div id="div3" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;"
                                class="table-scrollable">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgPrdctGrid" runat="server" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable"
                                            PageSize="5" AllowSorting="True" AllowPaging="true" AutoGenerateColumns="false">
                                            <HeaderStyle ForeColor="Black" Width="100%" />
                                            <RowStyle />
                                            <PagerStyle CssClass="disablepage" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Product Name" SortExpression="PROD_DESC">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProdName" runat="server" Text='<%# Bind("PROD_DESC")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnPrdName" runat="server" Value='<%# Bind("PROD_DESC")%>' />
                                                        <asp:HiddenField ID="hdnPrdCode" runat="server" Value='<%# Bind("PROD_CODE")%>' />
                                                        <asp:HiddenField ID="hdnLOBCode" runat="server" Value='<%# Bind("LOB_CODE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Frequency" SortExpression="FREQUENCY">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFreq" runat="server" Text='<%# Bind("FREQUENCY")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnFreq" runat="server" Value='<%# Bind("FREQUENCY")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Consider" SortExpression="CONSIDER">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblConsider" runat="server" Text='<%# Bind("CONSIDER")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnConsider" runat="server" Value='<%# Bind("CONSIDER")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type" SortExpression="TYPE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%# Bind("TYPE")%>' />
                                                        <asp:HiddenField ID="hdnTyp" runat="server" Value='<%# Bind("TYPE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Weightage" SortExpression="WEIGHTAGE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWeightg" runat="server" Text='<%# Bind("WEIGHTAGE")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdnWghtg" runat="server" Value='<%# Bind("WEIGHTAGE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDeletePrd" runat="server" onclick="lnkDeletePrd_Click" Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div id="divPageStdPrd" visible="true" runat="server" class="pagination" style="padding: 10px;">
                                <center>
                                    <table>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprevStdPrd" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevStdPrd_Click" />
                                                        <asp:TextBox runat="server" ID="txtPageStdPrd" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnnextStdPrd" Text=">" CssClass="form-submit-button" runat="server"
                                                            Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                            Enabled="false" OnClick="btnnextStdPrd_Click" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                            <table id="tblStdPrd" runat="server" class="form-actions fluid" style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                        <asp:Button ID="btnAddStdPrd" Text="ADD" runat="server" Width="100px" CssClass="btn blue"
                                            Enabled="true" />
                                        <asp:Button ID="btnSaveStdPrd" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                            Enabled="true" OnClick="btnSaveStdPrd_Click" />
                                        <asp:Button ID="btnqual" runat="server" ClientIDMode="Static" Style="display: none;"
                                            OnClick="btnqual_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnKPICd" runat="server" />
            <asp:HiddenField ID="hdnVerFrm" runat="server" />
            <asp:HiddenField ID="hdnVerTo" runat="server" />
            <asp:HiddenField ID="hdnRulSetKy" runat="server" />
            <asp:HiddenField ID="hdnRwrdCnt" runat="server" />
            <asp:HiddenField ID="hdnRulCode" runat="server" />
            <asp:HiddenField ID="hdnCompCode" runat="server" />
            <asp:HiddenField ID="hdnCntstCode" runat="server" />
            <asp:HiddenField ID="hdnPrdctName" runat="server" />
            <asp:HiddenField ID="hdnPrctFreq" runat="server" />
            <asp:HiddenField ID="hdnConsider" runat="server" />
            <asp:HiddenField ID="hdnType" runat="server" />
            <asp:HiddenField ID="hdnWghtg" runat="server" />
            <asp:HiddenField ID="hdnPrdctNameval" runat="server" />
            <asp:HiddenField ID="hdnConsiderval" runat="server" />
            <asp:HiddenField ID="hdnTypeval" runat="server" />
            <asp:HiddenField ID="hdnPrctFreqval" runat="server" />
            <asp:HiddenField ID="hdnLOB" runat="server" />
            <asp:HiddenField ID="hdnLOBval" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" Height="275px" Width="1020px" ID="pnlMdl" display="none"
        Style="text-align: center;padding:10px;">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
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
</asp:Content>
