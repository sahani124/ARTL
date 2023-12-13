<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CompSetup.aspx.cs"
    Inherits="Application_ISys_Saim_CompSetup" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function funPopUp(kpicode,cmpcode) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopKPIDetails.aspx?kpicode=" + kpicode + 
            "&compcode=" + cmpcode + "&mdlpopup=mdlViewBID";
        }
        function ShowReqDtl(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-';
            }
        }

        function funvalidateOnSet() {
            if (document.getElementById('<%=txtCmpTyp.ClientID%>').value == "") {
                alert("Computation Type field can not be blank");
                return false;
            }
            if (document.getElementById('<%=txtCmpDesc.ClientID%>').value == "") {
                alert("Computation Description field can not be blank");
                return false;
            }
            if (document.getElementById('<%=ddlFrequency.ClientID%>').value == "" || document.getElementById('<%=ddlFrequency.ClientID%>').value == "--Select--") {
                alert("Frequency field can not be blank");
                return false;
            }
            if (document.getElementById('<%=txtEffDt.ClientID%>').value == "") {
                alert("Effective Date field can not be blank");
                return false;
            }
        }

        function funvalidateOnAdd() {

            if (document.getElementById('<%=txtCmpName.ClientID%>').value == "") {
                alert("Computation Name field can not be blank");
                return false;
            }
            if (document.getElementById('<%=ddlBizSrc.ClientID%>').value == "" || document.getElementById('<%=ddlBizSrc.ClientID%>').value == "--Select--") {
                alert("Channel field can not be blank");
                return false;
            }
            if (document.getElementById('<%=ddlChnCls.ClientID%>').value == "" || document.getElementById('<%=ddlChnCls.ClientID%>').value == "--Select--") {
                alert("Sub Class field can not be blank");
                return false;
            }
            if (document.getElementById('<%=ddlMemType.ClientID%>').value == "" || document.getElementById('<%=ddlMemType.ClientID%>').value == "--Select--") {
                alert("Member Type field can not be blank");
                return false;
            }
            if (document.getElementById('<%=txtEffDate.ClientID%>').value == "") {
                alert("Eff. Date field can not be blank");
                return false;
            }
        }

        function funvalidateOnSetRule() {
            if (document.getElementById('<%=txtCmpName.ClientID%>').value == "") {
                alert("Computation Name field can not be blank");
                return false;
            }
        }

        function funvalidateOnProdAdd() {

            if (document.getElementById('<%=ddlProduct.ClientID%>').value == "" || document.getElementById('<%=ddlProduct.ClientID%>').value == "--Select--") {
                alert("Product field can not be blank");
                return false;
            }
            if (document.getElementById('<%=txtProdFrm.ClientID%>').value == "") {
                alert("Production From field can not be blank");
                return false;
            }
            if (document.getElementById('<%=txtProdTo.ClientID%>').value == "") {
                alert("Production To field can not be blank");
                return false;
            }
            if (document.getElementById('<%=txtCmpVal.ClientID%>').value == "") {
                alert("Comp. Value field can not be blank");
                return false;
            }
        }

    </script>
    <%--<script src="../../../Jquery/jquery-1.7.1.js" type="text/javascript"></script>
    <link href="../../../ddlsearchjquery/chosen.css" rel="stylesheet" type="text/css" />
    <script src="../../../ddlsearchjquery/chosen.jquery.js" type="text/javascript"></script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <center>
            <table width="80%" border="0" style="border-collapse: collapse;">
                <tr align="center">
                    <td>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 95%;" class="formtable2">
                <tr style="height: 25px;">
                    <td align="left" colspan="8" class="test">
                        <input runat="server" type="button" class="standardlink" value="-" id="btncmpsetupcollapse"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmpsetupdtls','ctl00_ContentPlaceHolder1_btncmpsetupcollapse');" />
                        <asp:Label ID="lblcmpsetup" runat="server" Text="Computation Setup" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
            </table>
            <div id="divcmpsetupdtls" runat="server" style="display: block; width: 95%;">
                <asp:UpdatePanel ID="updcmpstp" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%;" class="tableIsys">
                            <tr>
                                <td class="formcontent" style="width: 20%; height: 26px;">
                                    <asp:Label ID="lblcmpTyp" runat="server" Text="Comp. Type"></asp:Label>
                                    <span style="color: #ff0000">*</span>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:TextBox ID="txtCmpTyp" runat="server" Width="140px" 
                                        CssClass="standardtextbox"></asp:TextBox>
                                </td>
                                <td class="formcontent" style="width: 20%;">
                                    <asp:Label ID="lblcmpDesc" runat="server" Text="Comp. Type Desc."></asp:Label>
                                    <span style="color: #ff0000">*</span>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:TextBox ID="txtCmpDesc" runat="server" Width="140px" 
                                        CssClass="standardtextbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent" style="width: 20%; height: 26px;">
                                    <asp:Label ID="lblFreq" runat="server" Text="Frequency"></asp:Label>
                                    <span style="color: #ff0000">*</span>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:DropDownList ID="ddlFrequency" runat="server" CssClass="standardmenu" Width="140px">
                                    </asp:DropDownList>
                                </td>
                                <td class="formcontent" style="width: 20%;">
                                    <asp:Label ID="lblEffDt" runat="server" Text="Effective Date"></asp:Label>
                                    <span style="color: #ff0000">*</span>
                                </td>
                                <td class="formcontent" style="width: 30%;">
                                    <asp:TextBox ID="txtEffDt" runat="server" Width="140px" 
                                        CssClass="standardtextbox"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cldext" Format="dd/MM/yyyy" PopupButtonID="btnCalendar"
                                        TargetControlID="txtEffDt" runat="server">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:Image ID="btnCalendar" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 26px; text-align: center;">
                                    <asp:UpdatePanel ID="updsetbtn" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSet" runat="server" Text="SET" CssClass="standardbutton" 
                                                OnClick="btnSet_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <asp:UpdatePanel ID="UpdtblCmpRuleStp" runat="server">
                <ContentTemplate>
                    <table id="tblCmpRuleSetup" runat="server" style="width: 95%;" visible="false">
                        <tr>
                            <td>
                                <table style="width: 100%;" class="formtable2">
                                    <tr style="height: 25px;">
                                        <td align="left" colspan="8" class="test">
                                            <input runat="server" type="button" class="standardlink" value="-" id="btncmprulesetupcollapse"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmprulesetupdtls','ctl00_ContentPlaceHolder1_btncmprulesetupcollapse');" />
                                            <asp:Label ID="lblCmpRuleSetup" runat="server" Text="Computation Rule Setup" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divcmprulesetupdtls" runat="server" style="display: block; width: 100%;">
                                    <table style="width: 100%;" class="tableIsys">
                                        <tr>
                                            <td class="formcontent" style="width: 20%; height: 26px;">
                                                <asp:Label ID="lblcmpTypeRule" runat="server" Text="Comp. Type"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:Label ID="lblcmpTypeRuleval" runat="server"></asp:Label>
                                                <%--<asp:DropDownList ID="ddlCmpType" runat="server" Width="100px" CssClass="standardmenu">
                                                </asp:DropDownList>--%>
                                            </td>
                                            <td class="formcontent" style="width: 20%;">
                                                <asp:Label ID="lblCmpName" runat="server" Text="Comp. Rule Desc."></asp:Label>
                                                <span style="color: #ff0000">*</span></td>
                                            <td class="formcontent" style="width: 30%;">
                                                <asp:TextBox ID="txtCmpName" runat="server" Width="140px" 
                                                    CssClass="standardtextbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trtmprulset" runat="server">
                                            <td colspan="4">
                                                <table style="width: 100%;" class="tableIsys">
                                                    <tr>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblsrnoh" runat="server" Text="Sr No."></asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblSrNo" runat="server">1</asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblCmpRuleNo" runat="server" Text="Rule No."></asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblCmpRuleNoval" runat="server"></asp:Label>
                                                            <%--<asp:TextBox ID="txtCmpRuleNo" runat="server" Width="80px" CssClass="standardtextbox"></asp:TextBox>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" style="height: 26px;">
                                                            <asp:Label ID="lblBizSrc" runat="server" Text="Channel"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" style="height: 26px;">
                                                            <asp:UpdatePanel ID="updBizSrc" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlBizSrc" runat="server" AutoPostBack="True" CssClass="standardmenu"
                                                                        OnSelectedIndexChanged="ddlBizSrc_SelectedIndexChanged" Width="200px">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblChnCls" runat="server" Text="Sub Class"></asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:UpdatePanel ID="updChnCls" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlChnCls" runat="server" AutoPostBack="True" CssClass="standardmenu"
                                                                        OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" Width="200px">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlBizSrc" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblMemTyp" runat="server" Text="Member Type"></asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:UpdatePanel ID="updMemTYp" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMemType" runat="server" AutoPostBack="True" CssClass="standardmenu"
                                                                        OnSelectedIndexChanged="ddlMemType_SelectedIndexChanged" Width="200px">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlChnCls" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblCmpCode" runat="server" Text="Comp. Code"></asp:Label>
                                                        </td>
                                                        <td class="formcontent">
                                                            <asp:UpdatePanel ID="updCmpCodeval" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblCmpCodeval" runat="server"></asp:Label>
                                                                    <%--<asp:TextBox ID="txtCmpCode" runat="server" Width="80px" CssClass="standardtextbox"></asp:TextBox>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent">
                                                            <asp:Label ID="lblEffDate" runat="server" Text="Eff. Date"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" colspan="3">
                                                            <asp:TextBox ID="txtEffDate" runat="server" CssClass="standardtextbox" 
                                                                Width="200px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                                Format="dd/MM/yyyy" PopupButtonID="Image1" TargetControlID="txtEffDate">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <asp:Image ID="Image1" runat="server" 
                                                                ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <%--<td class="formcontent">
                                                            <asp:Label ID="lblAct" runat="server" Text="Action"></asp:Label>
                                                        </td>--%>
                                                        <td class="formcontent" colspan="4" style="text-align:center;">
                                                            <asp:UpdatePanel ID="updAdd" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" OnClick="btnAdd_Click"
                                                                        Text="ADD" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr ID="trtmprulgrid" runat="server">
                            <td colspan="4">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvCrsAppTo" runat="server" AutoGenerateColumns="False" 
                                            EnableTheming="True" OnRowCancelingEdit="gvCrsAppTo_RowCancelingEdit" 
                                            OnRowDataBound="gvCrsAppTo_RowDataBound" OnRowDeleting="gvCrsAppTo_RowDeleting" 
                                            OnRowEditing="gvCrsAppTo_RowEditing" OnRowUpdating="gvCrsAppTo_RowUpdating" 
                                            Width="100%">
                                            <HeaderStyle CssClass="portlet box blue" ForeColor="White" 
                                                HorizontalAlign="Center" />
                                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                            <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                            <AlternatingRowStyle CssClass="sublinkeven" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SrNo" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SrNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rule No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCmpRuleNo" runat="server" Text='<%# Bind("RuleNo") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnCmpRuleNo" runat="server" 
                                                            Value='<%# Bind("RuleNoID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comp. Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCmpCode" runat="server" Text='<%# Bind("CompCode") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnCmpCode" runat="server" 
                                                            Value='<%# Bind("CompCodeID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sales Channel">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBizSrc" runat="server" Text='<%# Bind("BizSrc") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnBizSrc" runat="server" 
                                                            Value='<%# Bind("BizSrcID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlEditBizSrc" runat="server" AutoPostBack="True" 
                                                            CssClass="standardmenu" 
                                                            OnSelectedIndexChanged="ddlEditBizSrc_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlFBizSrc" runat="server">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Channel Sub Class">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblChnCls" runat="server" Text='<%# Bind("ChnCls") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnChnCls" runat="server" 
                                                            Value='<%# Bind("ChnClsID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlEditChnCls" runat="server" AutoPostBack="True" 
                                                            CssClass="standardmenu" 
                                                            OnSelectedIndexChanged="ddlEditChnCls_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlFChnCls" runat="server">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Member Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgenttype" runat="server" Text='<%# Bind("AgentType") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnAgentType" runat="server" 
                                                            Value='<%# Bind("AgentTypeID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlEditAgentType" runat="server" AutoPostBack="True" 
                                                            CssClass="standardmenu" 
                                                            OnSelectedIndexChanged="ddlEditAgentType_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlFAgenttype" runat="server">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Eff. Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEffDt" runat="server" Text='<%# Bind("EffDt") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnEffDt" runat="server" Value='<%# Bind("EffDtID") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEffDt" runat="server" CssClass="standardtextbox">
                                                                        </asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                            Format="dd/MM/yyyy" PopupButtonID="Image1" TargetControlID="txtEffDt">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <asp:Image ID="Image1" runat="server" 
                                                            ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtFEffDt" runat="server">
                                                                        </asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowEditButton="True">
                                                <ItemStyle Width="50px" />
                                                </asp:CommandField>
                                                <asp:CommandField ShowDeleteButton="True">
                                                <ItemStyle Width="50px" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="Action" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkActInAct" runat="server" OnClick="lnkActInAct_Click" 
                                                            Text='<%# Bind("Flag") %>'></asp:LinkButton>
                                                        <asp:HiddenField ID="hdnActInAct" runat="server" 
                                                            Value='<%# Bind("FlagId") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr ID="trbtnSetRule" runat="server">
                            <td colspan="4" style="text-align: center;" class="formcontent">
                                <asp:Button ID="btnSetRule" runat="server" CssClass="standardbutton" 
                                    OnClick="btnSetRule_Click" Text="SET RULE" Visible="False" />
                            </td>
                        </tr>
                    </table>
                    </div>
                    <table ID="tblcmpprod" runat="server" class="formtable2" style="width: 95%;" 
                        visible="false">
                        <tr style="height: 25px;">
                            <td align="left" class="test" colspan="8">
                                <input runat="server" type="button" class="standardlink" value="-" id="btncmpruleprodsetupcollapse"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmpruleprodsetupdtls','ctl00_ContentPlaceHolder1_btncmpruleprodsetupcollapse');" />
                                <asp:Label ID="lblcmpruldtlstp" runat="server" Font-Bold="True" 
                                    Text="Computation Rule Details Setup"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div ID="divcmpruleprodsetupdtls" runat="server" 
                        style="display: block; width: 100%;">
                        <table class="tableIsys" style="width: 95%;">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvCheckRule" runat="server" AllowPaging="true" 
                                        AllowSorting="true" AutoGenerateColumns="False" EnableTheming="True" 
                                        onpageindexchanging="gvCheckRule_PageIndexChanging" 
                                        onrowdatabound="gvCheckRule_RowDataBound" onsorting="gvCheckRule_Sorting" 
                                        Width="100%">
                                        <HeaderStyle CssClass="portlet box blue" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                        <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="sublinkeven" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Rule No." SortExpression="RuleNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleNo" runat="server" Text='<%# Bind("RuleNo") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCmpRuleNo" runat="server" 
                                                        Value='<%# Bind("RuleNoID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comp. Code" SortExpression="CompCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompCode" runat="server" Text='<%# Bind("CompCode") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnCmpCode" runat="server" 
                                                        Value='<%# Bind("CompCodeID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField HeaderText="Comp. Name" DataField="CompName" />--%>
                                            <asp:TemplateField HeaderText="Sales Channel" SortExpression="BizSrc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBizSrc" runat="server" Text='<%# Bind("BizSrc") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnBizSrc" runat="server" 
                                                        Value='<%# Bind("BizSrcID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Channel Sub Class" SortExpression="ChnCls">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblChnCls" runat="server" Text='<%# Bind("ChnCls") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnChnCls" runat="server" 
                                                        Value='<%# Bind("ChnClsID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Type" SortExpression="AgentType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAgenttype" runat="server" Text='<%# Bind("AgentType") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnAgentType" runat="server" 
                                                        Value='<%# Bind("AgentTypeID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eff. Date" SortExpression="EffDt">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEffDt" runat="server" Text='<%# Bind("EffDt") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnEffDt" runat="server" Value='<%# Bind("EffDtID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActInAct" runat="server" Text='<%# Bind("Flag") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnActInAct" runat="server" 
                                                        Value='<%# Bind("FlagId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAddKPI" runat="server"  Text="Add KPI" 
                                                        OnClick="lnkAddKPI_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSetProduct" runat="server" OnClick="lnkSetProduct_Click" 
                                                        Text="Set Rule"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent">
                                    <asp:GridView ID="dgKPI" runat="server" AutoGenerateColumns="false" HorizontalAlign="Left"
                                        Width="100%" AllowPaging="True" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue"
                                        BorderStyle="Solid" BorderColor="Gray" PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true"
                                        AllowSorting="True" >
                                        <HeaderStyle CssClass="portlet box blue" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                        <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="sublinkeven" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Rule No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRuleNo" Text='<%# Bind("RuleNo")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnRuleNo" runat="server" Value='<%# Bind("RuleNo") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comp Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompCode" Text='<%# Bind("CompCode")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnCompCode" runat="server" Value='<%# Bind("CompCode") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="KPI Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkKPICode" Text='<%# Bind("KPICode")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPICode") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="KPI Description" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkKPIDesc1" Text='<%# Bind("KPIDesc1")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnKPIDesc1" runat="server" Value='<%# Bind("KPIDesc1") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="KPI Origin" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkKPIOrigin" Text='<%# Bind("KPIOrigin")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnKPIOrigin" runat="server" Value='<%# Bind("KPIOrigin") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eff. Frm" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkRangeFrm" Text='<%# Bind("RangeFrm")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnRangeFrm" runat="server" Value='<%# Bind("RangeFrm") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eff. To" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkRangeTo" Text='<%# Bind("RangeTo")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnRangeTo" runat="server" Value='<%# Bind("RangeTo") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Version" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkVersion" Text='<%# Bind("Version")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnVersion" runat="server" Value='<%# Bind("Version") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table ID="tblTmpProd" runat="server" class="tableIsys" style="width: 100%;" 
                                        visible="false">
                                        <tr>
                                            <td class="formcontent" style="width:20%;">
                                                <asp:Label ID="Label2" runat="server" Text="Sr No."></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width:30%;">
                                                <asp:Label ID="lblProdSrNo" runat="server">1</asp:Label>
                                            </td>
                                            <td class="formcontent" style="width:20%;">
                                                <asp:Label ID="lbltmpruleno" runat="server" Text="Rule No."></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width:30%;">
                                                <asp:Label ID="lblTmpRuleNoval" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width:20%;">
                                                <asp:Label ID="lbltmpcmpcode" runat="server" Text="Comp. Code"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width:30%;">
                                                <asp:Label ID="lblTmpCompCode" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="height: 26px;width:20%;">
                                                <asp:Label ID="lbltmpProduct" runat="server" Text="Product"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="height: 26px;width:30%;">
                                                <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" CssClass="standardmenu" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="height: 26px;width:20%;">
                                                <asp:Label ID="lblProdFrom" runat="server" Text="PRD From"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="height: 26px;width:30%;">
                                                <asp:TextBox ID="txtProdFrm" runat="server" CssClass="standardtextbox" Width="100px"></asp:TextBox>
                                            </td>
                                            <td class="formcontent" style="height: 26px;width:20%;">
                                                <asp:Label ID="lblProdTo" runat="server" Text="PRD To"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="height: 26px;width:30%;">
                                                <asp:TextBox ID="txtProdTo" runat="server" CssClass="standardtextbox" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                      
                                        <tr id="trprod" runat="server" visible="false">
                                            <td class="formcontent" style="height: 26px;">
                                                <asp:Label ID="lblCmpValTyp" runat="server" Text="Comp. Based On"></asp:Label>
                                            </td>
                                            <td class="formcontent">
                                                <asp:RadioButtonList ID="rdbCmpVal" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Amount" Value="AMT"></asp:ListItem>
                                                    <asp:ListItem Text="Rate" Value="RATE"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td class="formcontent" style="height: 26px;">
                                                <asp:Label ID="lblCmpVal" runat="server" Text="Comp. Value"></asp:Label>
                                            </td>
                                            <td class="formcontent">
                                                <asp:TextBox ID="txtCmpVal" runat="server" CssClass="standardtextbox" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                            <tr>
                                            <td class="formcontent" style="height: 26px;">
                                                <asp:Label ID="lblIncPerfCode" runat="server" Text="KPI Description"></asp:Label>
                                            </td>
                                            <td class="formcontent" colspan="3">
                                                <asp:UpdatePanel ID="updInd" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlPerIndCode" runat="server" AutoPostBack="true" 
                                                            CssClass="standardmenu" Width="200px">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            </tr>
                                        <tr>
                                        <%--<td class="formcontent" style="height: 26px;">
                                                <asp:Label ID="lblProdAction" runat="server" Text="Action"></asp:Label>
                                            </td>--%>
                                            <td class="formcontent" colspan="4" style="text-align:center;">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnProAdd" runat="server" CssClass="standardbutton" OnClick="btnProAdd_Click"
                                                            Text="ADD" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="updgrid" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvCmpRuleSetup" runat="server" AllowPaging="true" 
                                                AllowSorting="true" AutoGenerateColumns="False" EnableTheming="True" 
                                                onpageindexchanging="gvCmpRuleSetup_PageIndexChanging" 
                                                OnRowCancelingEdit="gvCmpRuleSetup_RowCancelingEdit" 
                                                OnRowDataBound="gvCmpRuleSetup_RowDataBound" 
                                                OnRowDeleting="gvCmpRuleSetup_RowDeleting" 
                                                OnRowEditing="gvCmpRuleSetup_RowEditing" 
                                                OnRowUpdating="gvCmpRuleSetup_RowUpdating" onsorting="gvCmpRuleSetup_Sorting" 
                                                Width="100%">
                                                <HeaderStyle CssClass="portlet box blue" ForeColor="White" 
                                                    HorizontalAlign="Center" />
                                                <RowStyle CssClass="sublinkodd" HorizontalAlign="Center" />
                                                <PagerStyle CssClass="pagelink" HorizontalAlign="Center" />
                                                <AlternatingRowStyle CssClass="sublinkeven" HorizontalAlign="Left" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SrNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSrNo" runat="server" Text='<%# Bind("SrNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rule No." SortExpression="RuleNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpRuleNo" runat="server" Text='<%# Bind("RuleNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comp. Code" SortExpression="CompCode">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpCode" runat="server" Text='<%# Bind("CompCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KPI Code" SortExpression="KPICode" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblKPICode" runat="server" Text='<%# Bind("KPICode") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnKPICode" runat="server" Value='<%# Bind("KPICode") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comp Type" SortExpression="CompType">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpTyp" runat="server" Text='<%# Bind("CompType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product" SortExpression="Product">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("Product") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnProduct" runat="server" 
                                                                Value='<%# Bind("ProductID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlProduct" runat="server" CssClass="standardmenu">
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlFProduct" runat="server" CssClass="standardmenu">
                                                            </asp:DropDownList>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Production from" SortExpression="ProductFrm">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductFrm" runat="server" Text='<%# Bind("ProductFrm") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnProductFrm" runat="server" 
                                                                Value='<%# Bind("ProductFrmID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtProductFrm" runat="server" CssClass="standardtextbox">
                                                                        </asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFProductFrm" runat="server" CssClass="standardtextbox">
                                                                        </asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Production To" SortExpression="ProductTo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductTo" runat="server" Text='<%# Bind("ProductTo") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnProductTo" runat="server" 
                                                                Value='<%# Bind("ProductToID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtProductTo" runat="server" CssClass="standardtextbox">
                                                                        </asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFProductTo" runat="server" CssClass="standardtextbox">
                                                                        </asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comp Value Type" SortExpression="CompValTyp">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpValTyp" runat="server" Text='<%# Bind("CompValTyp") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCmpValTyp" runat="server" 
                                                                Value='<%# Bind("CompValTypID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <EditItemTemplate>
                                                            <asp:RadioButtonList ID="rdbCmpVal" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Amount" Value="AMT"></asp:ListItem>
                                                                <asp:ListItem Text="Rate" Value="RATE"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:RadioButtonList ID="rdbFCmpVal" runat="server" 
                                                                RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Amount" Value="AMT"></asp:ListItem>
                                                                <asp:ListItem Text="Rate" Value="RATE"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comp Value" SortExpression="CmpVal">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCmpVal" runat="server" Text='<%# Bind("CmpVal") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnCmpVal" runat="server" 
                                                                Value='<%# Bind("CmpValID") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtCmpVal" runat="server" CssClass="standardtextbox" 
                                                                Width="80px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtFCmpVal" runat="server" CssClass="standardtextbox" 
                                                                Width="100px"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Perf. Indicator" SortExpression="PerfDesc" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPerfDesc" runat="server" Text='<%# Bind("PerfDesc") %>' />
                                                            <asp:HiddenField ID="hdnPerfDesc" runat="server" 
                                                                Value='<%# Bind("PerfDesc") %>' />
                                                            <asp:Label ID="lblPerfCode" runat="server" Text='<%# Bind("PerfCode") %>' 
                                                                Visible="false" />
                                                            <asp:HiddenField ID="hdnPerfCode" runat="server" 
                                                                Value='<%# Bind("PerfCode") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:UpdatePanel ID="updddl" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlPerfCode" runat="server" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowEditButton="True">
                                                    <ItemStyle Width="50px" />
                                                    </asp:CommandField>
                                                    <asp:CommandField ShowDeleteButton="True">
                                                    <ItemStyle Width="50px" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkProdActInAct" runat="server" 
                                                                OnClick="lnkProdActInAct_Click" Text='<%# Bind("Flag") %>'></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnProdActInAct" runat="server" 
                                                                Value='<%# Bind("FlagId") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnProAdd" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnSetProduct" runat="server" CssClass="standardbutton" 
                                        OnClick="btnSetProduct_Click" Text="SAVE" Visible="False" />
                                    <asp:Button ID="btnkpi" runat="server" ClientIDMode="Static" 
                                        style="display:none;" onclick="btnkpi_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    </td>
                    </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSet" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </center>
        <asp:Panel runat="server" ID="pnlMdl" Width="600" Height="355" display="none">
            <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
                display="none" style="height: 100%;"></iframe>
        </asp:Panel>
        <asp:Label runat="server" ID="lbl1" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
            DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                        <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="standardbutton" />
                    </center>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                    BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                    DropShadow="true" OkControlID="btnok" Y="100">
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--<script type="text/javascript">
          var config = {
              '.chosen-select': {},
          }
          for (var selector in config) {
              $(selector).chosen(config[selector]);
          }
          document.getElementById("ctl00_ContentPlaceHolder1_ddlFrequency_chosen").style.width = "100px";
      </script>--%>
</asp:Content>
