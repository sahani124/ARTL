<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="FireQuotation.aspx.cs" Inherits="Application_ISys_Saim_FireQuotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Common/Styles/bootstrap.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    
    <script language="javascript" type="text/javascript">

        function ShowReqDtl(divId, btnId, img, separator) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
                $(separator).css("border-bottom", "4px solid #2cafec");
                //document.getElementById(separator).style.borderBottom = "thick solid #0000FF";
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png');
                $(separator).css("border-bottom", "4px solid green");
            }
        }
    </script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        debugger;
        $("[src*=btnexp]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td colspan = '888'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../images/btncol.png");
        });
        $("[src*=btncol]").live("click", function () {
            debugger;
            $(this).attr("src", "../../../images/btnexp.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <asp:ScriptManager ID="scr" runat="server">
    </asp:ScriptManager>
    <center>
        <table style="width: 90%;">
            <tr>
                <td>
                <div id="divquotecollapse" onclick="ShowReqDtl('divquotedtls', '#divquotecollapse','#Img2','#divseprator1');" style="width: 100%;">
                    <table class="formtablehdr1" style="width: 100%;" >
                        <tr>
                            <td style="height:32px;" >
                                <%--<input type="button" runat="server" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divquotedtls','ctl00_ContentPlaceHolder1_btnQuoteDtls');"
                                    class="btn btn-xs btn-primary" value="-" id="btnQuoteDtls" style="width: 20px;" />--%>
                                <asp:Label ID="quoHdr" Text="Quote Details" runat="server" style="padding-left: 10px;" />
                            </td>
                            <td style="height: 32px; text-align: right;">
                                <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div runat="server" id="divquotedtls" style="display: block;">
                        <table class="tableIsys" style="width: 100%;" >
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblBusiType" Text="Type of Business" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                            <asp:DropDownList ID="ddlBusiType" runat="server" AutoPostBack="True" CssClass="standardmenu1"
                                                Width="200px" OnSelectedIndexChanged="ddlBusiType_SelectedIndexChanged">
                                                <asp:ListItem Text="-- Select --" Value="" />
                                                <asp:ListItem Text="Direct" Value="D" />
                                                <asp:ListItem Text="Intermediary" Value="I" />
                                            </asp:DropDownList>
                                       <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblTrnType" Text="Transaction Type" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                    <asp:DropDownList ID="ddlTrnType" runat="server" CssClass="standardmenu1" Width="200px"
                                        OnSelectedIndexChanged="ddlTrnType_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="-- Select --" Value="" />
                                        <asp:ListItem Text="Fresh" Value="F" />
                                        <asp:ListItem Text="Renewal" Value="R" />
                                    </asp:DropDownList>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </td>
                            </tr>
                            <tr id="trBrkAgn" runat="server" visible="false">
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblBrkName" Text="Broker Name" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtBrkName" runat="server" CssClass="standardtextbox" Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblAgnName" Text="Agent Name" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtAgnName" runat="server" CssClass="standardtextbox"  Width="200px" />
                                </td>
                            </tr>
                            <tr id="trBnk" runat="server" visible="false">
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblBnkNm" Text="Bank Name" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtBnkNm" runat="server" CssClass="standardtextbox" Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblInsuNm" Text="Insured Name" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtInsuNm" runat="server" CssClass="standardtextbox" Width="200px" />
                                </td>
                            </tr>
                            <tr id="trRenTyp" runat="server" visible="false">
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblRenType" Text="Renewal Type" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                            <asp:DropDownList ID="ddlRenType" runat="server" CssClass="standardmenu1" Width="200px"
                                                OnSelectedIndexChanged="ddlRenType_SelectedIndexChanged" 
                                                AutoPostBack="True">
                                                <asp:ListItem Text="-- Select --" Value="" />
                                                <asp:ListItem Text="USGI" Value="USG" />
                                                <asp:ListItem Text="Other- Expiring Insurer" Value="Oth" />
                                            </asp:DropDownList>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </td>
                            </tr>
                            <tr id="trPolNo" runat="server" visible="false">
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblPolNo" Text="Policy Number" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtPolNo" runat="server" CssClass="standardtextbox" Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblInsuType" Text="Insurer Name" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtInsuType" runat="server" CssClass="standardtextbox" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formtablehdr1" colspan="4">
                                    <asp:Label Text="Policy Period" runat="server" style="padding-left: 10px;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblFrm" Text="From" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtFrm" runat="server" CssClass="standardtextbox" Width="200px" />
                                    <asp:Image ID="img1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" /> 
                                    <ajaxToolkit:CalendarExtender ID="CEXFrm" runat="server"
                                    TargetControlID="txtFrm" PopupButtonID="img1" Format="dd/MM/yyyy" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblTo" Text="To" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtTo" runat="server" CssClass="standardtextbox" Width="200px" />
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" /> 
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    TargetControlID="txtTo" PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblHypo" Text="Hypothecation" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                            <asp:RadioButtonList ID="rblHypo" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                CssClass="radiobtn" OnSelectedIndexChanged="rblHypo_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </td>
                            </tr>
                            <tr id="trBnkNm" runat="server" visible="false">
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblBnkName" Text="Name of the Bank" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtBnkName" runat="server" CssClass="standardtextbox" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formtablehdr1" colspan="4">
                                    <asp:Label ID="lblCorrAddr" Text="Correspondence Address" runat="server" style="padding-left: 10px;"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width:20%;">
                                    <asp:Label ID="lblAddr1" Text="Address Line 1" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width:30%;">
                                    <asp:TextBox ID="txtAddr1" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width:20%;">
                                    <asp:Label ID="lblState" Text="State" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="white-space:nowrap;">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" CssClass="standardmenu1"
                                                Width="200px">
                                            </asp:DropDownList>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    <asp:Button Text="Search" runat="server" CssClass="standardbutton1" Width="80px"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblAddr2" Text="Address Line 2" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtAddr2" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblDistrict" Text="District" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtDistrict" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblAddr3" Text="Address Line 3" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtAddr3" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblCity" Text="City" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtCity" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="Label1" Text="Village" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtVillage" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblArea" Text="Area" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtArea" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblPin" Text="Pincode" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtPin" runat="server" CssClass="standardtextbox" 
                                        Width="200px" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblCountry" Text="Country" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:TextBox ID="txtCCode" runat="server" CssClass="standardtextbox" Width="50px"/>&nbsp;
                                    <asp:TextBox ID="txtCName" runat="server" CssClass="standardtextbox" Width="143px"/>
                                </td>
                            </tr>
                            </table>
                    </div>
                    <div id="divseprator1" style="width: 100%;border-bottom:4px solid #2cafec;"></div>
                    <div id="divriskdtlscollapse" onclick="ShowReqDtl('divriskdtls', '#divriskdtlscollapse','#Img3','#divseperator2');" style="width: 100%;">
                    <table class="formtablehdr1" style="width: 100%;">
                        <tr>
                            <td style="height:32px;" >
<%--                                <input type="button" runat="server" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divriskdtls','ctl00_ContentPlaceHolder1_btnriskdtls');"
                                    class="btn btn-xs btn-primary" value="-" id="btnriskdtls" style="width: 20px;" />--%>
                                <asp:Label ID="Label2" Text="Risk Details" runat="server" style="padding-left: 10px;" />
                            </td>
                            <td style="height: 32px; text-align: right;">
                                <img id="Img3" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div runat="server" id="divriskdtls" style="display: block;">
                        <table class="tableIsys" style="width: 100%;" >
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblRskAddr" Text="Risk Location Address" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtRskAddr" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblRskTyp" Text="Type of Risk" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:DropDownList runat="server" CssClass="standardmenu1" AutoPostBack="True" 
                                        Width="200px">
                                        <asp:ListItem Text="-- Select --" Value="" />
                                        <asp:ListItem Text="Dwellings/Offices/Hotels/Shops .etc" Value="DW" />
                                        <asp:ListItem Text="Industrial /  Manufacturing Risk" Value="IMR" />
                                        <asp:ListItem Text="Utilities Located Out Side the industrial/Manufacturing Risk (Stand Alones)"
                                            Value="UTL" />
                                        <asp:ListItem Text="Storage Risks outside the compound of Industrial / /Manufacturing Risk)"
                                            Value="STR" />
                                        <asp:ListItem Text="Tank farms/Gas Holders Outside the compound of Industrial/Manufacturing Risk "
                                            Value="TNK" />
                                    </asp:DropDownList>
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblOccup" Text="Occupancy" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:DropDownList ID="ddlOccup" runat="server" CssClass="standardmenu1" AutoPostBack="True"
                                        Width="200px">
                                        <asp:ListItem Text="-- Select --" Value="" />
                                        <asp:ListItem Text="Occupancy 1" Value="O1" />
                                        <asp:ListItem Text="Occupancy 2" Value="O2" />
                                        <asp:ListItem Text="Occupancy 3" Value="O3" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblRawMtrl" Text="Major Raw material Used" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtRawMtrl" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblFinGds" Text="Finished Goods" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtFinGds" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblNghOccup" Text="Neighboring Occupancies" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                    <asp:GridView ID="dgNghOccup" runat="server" AllowSorting="True" 
                                    Width="100%" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Center" 
                                    RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" AllowPaging="True" 
                                    PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" HeaderStyle-ForeColor="White">
                                        <EmptyDataTemplate>
                                            <asp:Label Text="No Records" runat="server" /></EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="North" SortExpression="North" ItemStyle-Height="25px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtNorth" Text='<%# Bind("North") %>' runat="server" CssClass="standardtextbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Height="25px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="South" SortExpression="South" ItemStyle-Height="25px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtSouth" Text='<%# Bind("South") %>' runat="server" CssClass="standardtextbox" />
                                                </ItemTemplate>
                                                <ItemStyle Height="25px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="East" SortExpression="East" ItemStyle-Height="25px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEast" Text='<%# Bind("East") %>' runat="server" CssClass="standardtextbox" />
                                                </ItemTemplate>
                                                <ItemStyle Height="25px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="West" SortExpression="West" ItemStyle-Height="25px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtWest" Text='<%# Bind("West") %>' runat="server" CssClass="standardtextbox" />
                                                </ItemTemplate>
                                                <ItemStyle Height="25px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Height="25px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnAdd" Text="Add" runat="server" onclick="btnAdd_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Height="25px"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="sublinkodd"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="portlet blue" ForeColor="white" HorizontalAlign="Center">
                                        </HeaderStyle>
                                        <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                    </asp:GridView>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblOthFtr" Text="Any other Features of the Risk" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtOthFtr" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblSfty" Text="Safety Features" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtSfty" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblSecu" Text="Security  Features" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtSecu" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblSunInsu" Text="Sum Inured Details" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgSumInsu" runat="server" AllowSorting="True" 
                                                Width="100%" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Center" 
                                                RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" AllowPaging="True" 
                                                PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" HeaderStyle-ForeColor="White"
                                                OnRowDataBound="dgSumInsu_RowDataBound" DataKeyNames="Desc">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                            <div id="divChild" runat="server" style="display: none; margin: 0px 0 !important;">
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="dgSumInChld" runat="server" Width="100%" AllowSorting="True" 
                                                                        AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Center" 
                                                                        RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" AllowPaging="True" 
                                                                        PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" HeaderStyle-ForeColor="White">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="20px">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDesc" Text='<%# Bind("Desc") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="20px">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSumInsu" Text='<%# Bind("SumInsu") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <RowStyle CssClass="sublinkodd"></RowStyle>
                                                                            <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center"> <%--Font-Underline="True"--%> <%--Commented by pranjali on 14-12-2013 for removing the link for page indexing of the current page--%>
                                                                            </PagerStyle>
                                                                            <HeaderStyle CssClass="portlet blue" ForeColor="white" HorizontalAlign="Center"></HeaderStyle>
                                                                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesc" Text='<%# Bind("Desc") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sum Insured (location wise)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSumInsu" Text='<%# Bind("SumInsu") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="sublinkodd"></RowStyle>
                                                <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center">
                                                </PagerStyle>
                                                <HeaderStyle CssClass="portlet blue" ForeColor="white" HorizontalAlign="Center"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divseperator2" style="width: 100%;border-bottom:4px solid #2cafec;"></div>
                    <div id="divclmdtlscollapse" onclick="ShowReqDtl('divclmdtls', '#divclmdtlscollapse','#Img4','#div1');" style="width: 100%;">
                    <table class="formtablehdr1" style="width: 100%;">
                        <tr>
                            <td style="height:32px;" >
                                <%--<input type="button" runat="server" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divclmdtls','ctl00_ContentPlaceHolder1_btnclmdtls');"
                                    class="btn btn-xs btn-primary" value="-" id="btnclmdtls" style="width: 20px;" />--%>
                                <asp:Label ID="Label3" Text="Claim History Details" runat="server" style="padding-left: 10px;" />
                            </td>
                            <td style="height: 32px; text-align: right;">
                                <img id="Img4" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div runat="server" id="divclmdtls" style="display: block">
                        <table class="tableIsys" style="width: 100%;" >
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label Text="Claim History" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                            <asp:RadioButtonList ID="rblClaim" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                CssClass="radiobtn" OnSelectedIndexChanged="rblClaim_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </td>
                            </tr>
                            <tr id="trClmHst" runat="server" visible="false">
                                <td class="formcontent4" align="left" colspan="4">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgClmHst" runat="server" AllowSorting="True" 
                                                Width="100%" AutoGenerateColumns="False" PagerStyle-HorizontalAlign="Center" 
                                                RowStyle-CssClass="formtable" HorizontalAlign="Left" PagerStyle-ForeColor="blue" AllowPaging="True" 
                                                PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink" HeaderStyle-ForeColor="White">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr.No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSrNo" Text='<%# Bind("SrNo") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYear" Text='<%# Bind("Year") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type of Claim">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTypClm" Text='<%# Bind("ClmTyp") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Claim Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClmAmt" Text='<%# Bind("ClmAmt") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Paid/ Reputed">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPdRpt" Text='<%# Bind("PdRpt") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="sublinkodd"></RowStyle>
                                                <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center">
                                                </PagerStyle>
                                                <HeaderStyle CssClass="portlet blue" ForeColor="white" HorizontalAlign="Center">
                                                </HeaderStyle>
                                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblFltReq" Text="Floater Required" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <%--<asp:UpdatePanel runat="server">
                                        <ContentTemplate>--%>
                                            <asp:RadioButtonList ID="rblFltReq" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                CssClass="radiobtn" 
                                                onselectedindexchanged="rblFltReq_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                    <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </td>
                            </tr>
                            <tr id="trLoc" runat="server" visible="false">
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblNoLoc" Text="Number of Locations" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtNoLoc" runat="server" CssClass="standardtextbox" Width="200px"/>
                                </td>
                            </tr>
                            <tr id="trLocDtls" runat="server" visible="false">
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblLocDtls" Text="Location  Details" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtLocDtls" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Width="100%" Rows="3"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblDecBs" Text="Declaration Basis" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtDescBs" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblFltDecBs" Text="Floater Declaration Basis" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:TextBox ID="txtFltDecBs" runat="server" CssClass="standardtextbox" TextMode="MultiLine" Rows="3"
                                        Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblRSMDReq" Text="RSMD Required" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rblRSMDReq" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                CssClass="radiobtn">
                                                <asp:ListItem Text="Yes" Value="Y" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblSTFIReq" Text="STFI Required" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" style="width: 30%;">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rblSTFIReq" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                CssClass="radiobtn">
                                                <asp:ListItem Text="Yes" Value="Y" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblTerr" Text="Terrorism" runat="server" />
                                </td>
                                <td class="formcontent4" align="left" colspan="3">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rblTerr" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                CssClass="radiobtn">
                                                <asp:ListItem Text="Yes" Value="Y" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div1" style="width: 100%;border-bottom:4px solid #2cafec;"></div>
                    <div id="divaddoncvrscollapse" onclick="ShowReqDtl('divaddoncvrs', '#divaddoncvrscollapse','#Img5','#div5');" style="width: 100%;">
                    <table class="formtablehdr1" style="width: 100%;">
                        <tr>
                            <td style="height:32px;" >
                                <%--<input type="button" runat="server" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divaddoncvrs','ctl00_ContentPlaceHolder1_btnaddoncvrs');"
                                    class="btn btn-xs btn-primary" value="-" id="btnaddoncvrs" style="width: 20px;" />--%>
                                <asp:Label ID="Label4" Text="Add On Covers" runat="server" style="padding-left: 10px;" />
                            </td>
                            <td style="height: 32px; text-align: right;">
                                <img id="Img5" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div runat="server" id="divaddoncvrs" style="display: block">
                        <table style="width:100%;">
                            <tr>
                                <%--<td class="formcontent4" align="left" style="width: 20%;">
                                    <asp:Label ID="lblAddOnCvrs" Text="Add On Covers" runat="server" />
                                </td>--%>
                                <td align="left" colspan="4">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <%--<asp:CheckBoxList ID="chkAddOnCvrs" runat="server" AutoPostBack="true" CssClass="checkbox">
                                            </asp:CheckBoxList>--%>
                                            <asp:GridView ID="dgAddOnCvrs" runat="server" AllowSorting="True" AutoGenerateColumns="false" 
                                                 CssClass="table table-striped table-bordered table-hover dataTable" Width="100%" ShowHeader="false">
                                                 <HeaderStyle ForeColor="Black" />
                                                <RowStyle />
                                                <PagerStyle CssClass="disablepage" />
                                                <Columns>   
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkAddOnCvrs" runat="server" AutoPostBack="true"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCvrs" Text='<%# Bind("CvrsDesc") %>' runat="server" 
                                                            Font-Names="Verdana" Font-Size="12px" ForeColor="Black" />
                                                        <asp:HiddenField ID="hdnCvrs" runat="server" Value='<%# Bind("CvrsVal") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                           </tr>
                        </table>
                    </div>
                    <div id="div5" style="width: 100%;border-bottom:4px solid #2cafec;"></div>
                    <table class="tableIsys" style="width: 100%;">
                        <tr>
                            <td style="text-align: center;">
                                <asp:Button ID="btnSearch" Text="SAVE" runat="server" CssClass="standardbutton1" Width="100px" />&nbsp;
                                <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CssClass="standardbutton1"
                                    Width="100px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
