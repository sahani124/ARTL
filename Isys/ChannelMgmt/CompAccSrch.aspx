<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompAccSrch.aspx.cs" Inherits="Application_Isys_ChannelMgmt_CompAccSrch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <%--<ajay>--%>

        <center>
        <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
<%--                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                        <asp:Label ID="lblhdr" Text="Compensation Rule Search Criteria" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>

                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMemberName" Text="Member Name" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control" TabIndex="1"
                                    MaxLength="8" placeholder="Member Name" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTXCompCd" runat="server" FilterType="Numbers"
                                    TargetControlID="txtCompCode">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblJvNo" Text="JV No" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtlblJvNo" runat="server" CssClass="form-control" TabIndex="2"
                                    placeholder="Compensation Description" MaxLength="40" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                    FilterMode="ValidChars" TargetControlID="txtCompDesc1">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblMemberType" Text="Member Type" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlMemberType" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblStat" Text="Status" runat="server" CssClass="control-label" />
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-sample">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Clear
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample"
                                    Visible="false">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-sample">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add New
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <%--Start By bhau--%>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <div id="divChanlWiseCompenDsn" runat="server" style="width: 97%;" class="panel" visible="false">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divResultDtls','ImgResultDtls');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%><%-- added and commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblchnldesgin" Text="Channel Wise Compensations in Design" Style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <span id="ImgResultDtls" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divResultDtls" runat="server" style="width: 96%; padding: 10px;" class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <%--<div class="panel-body" style="margin-top: -1%; margin-right: 2%; margin-left: 2%;">--%>
                                    <div style="margin-right: 0%; margin-left: 11px;" id="dvNewReg">
                                        <div class="row" style="color: White;">
                                            <div class="col-sm-4" style="text-align: center; width: 31%; padding: 20px; margin: 1% 1% 1% 1%;
                                                box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #58caf0;"> <%--#5bc0de--%>
                                               <%-- <span id="SpnAgency" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                 <asp:Label runat="server" ID="SpnAgency" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span2" style="font-size: small; font-weight: bold;">AGENCY </span>
                                            </div>
                                            <div class="col-sm-4" style="margin: 1% 1% 1% 1%; text-align: center; width: 31%;
                                                padding: 20px; box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #aaf058;"> <%--#5cb85c--%>
                                               <%-- <span id="SpanHealth" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                  <asp:Label runat="server" ID="SpanHealth" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span3" style="font-size: small; font-weight: bold;">HEALTH</span>
                                            </div>
                                            <div class="col-sm-4" style="margin: 1% 1% 1% 1%; width: 31%; text-align: center;
                                                padding: 20px; box-shadow: 0 5px 5px #ACACAC; border-radius: 5px; background-color: #f2b852;"> <%--#f0ad4e--%>
                                               <%-- <span id="SpanDirect" style="font-size: 200%; font-weight: bold" runat="server">0</span>--%>
                                                  <asp:Label runat="server" ID="SpanDirect" Text="0" style="font-size: large; font-weight: bold;"></asp:Label>
                                                <br />
                                                <span id="Span4" style="font-size: small; font-weight: bold;">DIRECT</span>
                                            </div>
                                        </div>
                                    </div>
                                <%--</div>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--End by bhau--%>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divcmpsrchhdrcollapse" runat="server" style="width: 97%;" class="panel ">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;--%><%--commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="lblCmpSrch" Text="Compensation Rule Search Results" style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate>
                                        <%--<img id="Img2" src="../../../assets/img/portlet-reload-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="callsearch();"  />--%>
                                        <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> <%--added by ajay sawant 24/4/2018--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divkpisrch" runat="server" style="width: 96%; padding: 10px;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgCmp" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="10" 
                                    CssClass="footable">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <img alt="" style="cursor: pointer" src="../../../images/btnexp.png" />
                                                <div id="divChild" runat="server" style="display: none; width: auto; margin: 0px 0 !important;"
                                                    class="table-scrollable,divBorder1">
                                                    <asp:UpdatePanel ID="UpdatePanel61" runat="server">
                                                        <ContentTemplate>
<%--                                                            <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                PageSize="10" AllowSorting="False" AllowPaging="true" CssClass="footable" OnRowDataBound="dgCntst_RowDataBound"
                                                                DataKeyNames="CNTSTNT_CODE">--%>
                                                           <asp:GridView ID="dgCntst" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                AllowSorting="False" AllowPaging="false" CssClass="footable" DataKeyNames="CNTSTNT_CODE">
                                                                <%--CssClass="dataTable details"--%>
                                                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                <PagerStyle CssClass="disablepage" />
                                                                <HeaderStyle CssClass="gridview th" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="Label2" Text="No contestants have been defined" ForeColor="Red" CssClass="control-label"
                                                                        runat="server" />
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTNT_CODE">
                                                                        <%--Added New--%>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("CNTSTNT_CODE")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RuleSetCode">
                                                                        <%--Added New--%>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRuleSetCode" runat="server" Text='<%# Bind("RuleSetCode")%>'></asp:Label>
                                                                            <%--<asp:HiddenField ID="hdncmpcode" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                      <asp:TemplateField HeaderText="Rule Set Description" SortExpression="RuleSetDesc">
                                                                        <%--Added New--%>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRuleSetCodeDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>'></asp:Label>
                                                                            <%--<asp:HiddenField ID="hdncmpcode" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField HeaderText="Compensation Description" SortExpression="CMPNSTN_CODE">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCmpDesc" runat="server" Text='<%# Bind("CMPNSTN_DESC01")%>' />
                                                                          <%--  <asp:HiddenField ID="lblCmpDsc" runat="server" Value='<%# Bind("CMPNSTN_CODEVAL")%>' />--%>
                                                                             <asp:HiddenField ID="hdncmp" runat="server" Value='<%# Bind("CMPNSTN_CODE")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sales Channel" SortExpression="CHN">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSlsChnl" runat="server" Text='<%# Bind("CHN")%>' />
                                                                            <asp:HiddenField ID="hdnSlsChnl" runat="server" Value='<%# Bind("BizSrc")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sub Class" SortExpression="CHNCLS">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubCls" runat="server" Text='<%# Bind("CHNCLS")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdnSubCls" runat="server" Value='<%# Bind("ChnClsVal")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Member Type" SortExpression="MEMTYPE">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MEMTYPE")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdnMemType" runat="server" Value='<%# Bind("MemTypeVal")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Unit Rank" SortExpression="UnitRank">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblUntRnk" runat="server" Text='<%# Bind("UnitRank")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdnUntRnk" runat="server" Value='<%# Bind("UnitRank")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Action">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="gridview th" />
                                                                        <ItemTemplate>
                                                                            <%--<asp:LinkButton ID="lnkDelCntst" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?');"
                                                                                OnClick="lnkDelCntst_Click"></asp:LinkButton>--%>
                                                                            <asp:LinkButton ID="lnkView" runat="server" Text="Run Batch"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comp Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkCmpCode" Text='<%# Bind("CMPNSTN_CODE")%>' runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comp Description" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCmpDesc" Text='<%# Bind("CMPNSTN_DESC01") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="CMPNSTN_DESC02" HeaderText="Comp Description" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left" SortExpression="CMPNSTN_DESC02">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>--%>
                                        <asp:BoundField DataField="ACC_CYCLE" HeaderText="Accumulation Cycle" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" SortExpression="ACC_CYCLE" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ACC_YEAR" HeaderText="Accumulation Year" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" SortExpression="ACC_YEAR" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LAST_CYCCD" HeaderText="Last Cycle Run" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" SortExpression="LAST_CYCCD" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="STATUS" HeaderText="Status" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" SortExpression="STATUS" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EFF_FROM" HeaderText="Eff. From" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="80px" SortExpression="EFF_FROM" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EFF_TO" HeaderText="Eff. To" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" SortExpression="EFF_TO" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Action">
                                            <HeaderStyle CssClass="gridview th" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelCmp" runat="server" Text="Delete"></asp:LinkButton>
                                                <%--<asp:LinkButton ID="lnkView" runat="server" Text="Run Batch" OnClick="lnkView_Click"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="pagination" style="padding: 10px;">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;"/>
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px"/>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>


        <%--<ajay>--%>

    </form>
</body>
</html>
