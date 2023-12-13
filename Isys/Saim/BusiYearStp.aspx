<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="BusiYearStp.aspx.cs" Inherits="Application_ISys_Saim_BusiYearStp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>

    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
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
    <script type="text/javascript">
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
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        function funPopUp(yrtyp, yrcode, flag) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCycStp.aspx?Type=" + yrtyp + "&flag=" + flag
                + "&YrCode=" + yrcode + "&mdlpopup=mdlViewBID";
        }
    </script>
    <style type="text/css">
        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #f04e5e;
            color: white;
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
            vertical-align: top;
        }

        .clsCenter {
            text-align: center !important;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="divfinhdrcollapse" runat="server" style="width: 95%; border-style:none" class="panel panel-success">
            <div id="Div6" runat="server" class="panel-heading" style="border-style:none;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                       <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;;"></span>&nbsp;--%>
                        <asp:Label ID="Label1" Text="FINANCIAL YEAR SETUP" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <span class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>&nbsp;
                    </div>
                </div>
            </div>
            <div id="divfinhdr" runat="server" style="width: 96%;" class="panel-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="dgFinYr" runat="server" AutoGenerateColumns="false" Width="100%"
                            PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable">
                            <RowStyle CssClass="GridViewRow"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                            <Columns>
                                <asp:TemplateField HeaderText="Financial Year Code" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center" SortExpression="BUSI_CODE">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFyCode" Text='<%# Bind("BUSI_CODE")%>' runat="server" OnClick="lnkFyCode_Click"></asp:LinkButton>
                                        <%--<div id="divStat" runat="server" class="img-responsive">
                                                <asp:Label ID="lblStatus" Text='<%# Bind("STATUS")%>' runat="server" />
                                            </div>--%>
                                        <asp:HiddenField ID="hdnYrTypFin" runat="server" Value='<%# Bind("YEAR_TYPE") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Financial Year Description" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center" SortExpression="BUSI_DESC">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBsDesc" Text='<%# Bind("BUSI_DESC")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="START_DATE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStrtDate" Text='<%# Bind("START_DATE")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="END_DATE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate" Text='<%# Bind("END_DATE")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelFinYr" Text="Delete" runat="server" OnClick="lnkDelFinYr_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Std. Definition" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkStdDefFin" Text="Set Rule" runat="server" OnClick="lnkStdDefFin_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />                                  
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="pagination">
                    <center>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnprevfin" Text="<" CssClass="form-submit-button" 
                                                runat="server" Width="40px"
                                                Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" 
                                                onclick="btnprevfin_Click"/>
                                            <asp:TextBox runat="server" ID="txtPageFin" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnextfin" Text=">" CssClass="form-submit-button" 
                                                runat="server" Style="border-style: solid;
                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                float: left; margin: 0; height: 30px;" Width="40px" 
                                                onclick="btnnextfin_Click"/>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btnAddFin" runat="server" CssClass="btn btn-sample" OnClick="btnAddFin_Click">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add New
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCnclFin" runat="server" CssClass="btn btn-sample" OnClick="btnCnclFin_Click">
                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div id="divcalhdrcollapse" runat="server" style="width: 95%; border-style:none;" class="panel panel-success">
            <div id="Div1" runat="server" style="border-style:none;" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcalhdr','Img1');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>&nbsp;--%>
                        <asp:Label ID="Label2" Text="CALENDAR YEAR SETUP" Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                      <span class="glyphicon glyphicon-chevron-down" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>&nbsp;
                    </div>
                </div>
            </div>
            <div id="divcalhdr" runat="server" style="width: 96%;" class="panel-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="dgCalYr" runat="server" AutoGenerateColumns="false" Width="100%"
                            PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable">
                            <RowStyle CssClass="GridViewRow"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                            <Columns>
                                <asp:TemplateField HeaderText="Calendar Year Code" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center" SortExpression="BUSI_CODE">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkCalCode" Text='<%# Bind("BUSI_CODE")%>' runat="server" OnClick="lnkCalCode_Click"></asp:LinkButton>
                                        <asp:HiddenField ID="hdnYrTypCal" runat="server" Value='<%# Bind("YEAR_TYPE") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Calendar Year Description" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center" SortExpression="BUSI_DESC">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBsDesc" Text='<%# Bind("BUSI_DESC")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="START_DT">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStrtDate" Text='<%# Bind("START_DATE")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    SortExpression="END_DT">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate" Text='<%# Bind("END_DATE")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelCalYr" Text="Delete" runat="server" OnClick="lnkDelCalYr_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Std. Definition" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkStdDefCal" Text="Set Rule" runat="server" OnClick="lnkStdDefCal_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="clsCenter"/>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="pagination">
                    <center>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnprevcal" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" 
                                                onclick="btnprevcal_Click" />
                                            <asp:TextBox runat="server" ID="txtPageCal" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                            <asp:Button ID="btnnextcal" Text=">" CssClass="form-submit-button" 
                                                runat="server" Style="border-style: solid;
                                                border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                float: left; margin: 0; height: 30px;" Width="40px" 
                                                onclick="btnnextcal_Click"/>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
                <table class="form-actions fluid" style="width: 100%;">
                    <tr>
                        <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;">
                            <asp:LinkButton ID="btnAddCal" runat="server" 
                                CssClass="btn btn-sample" onclick="btnAddCal_Click">
                                    <span class="glyphicon glyphicon-plus BtnGlyphicon"></span> Add New
                                </asp:LinkButton>
                            <asp:LinkButton ID="btnCnclCal" runat="server"
                                CssClass="btn btn-sample" onclick="btnCnclCal_Click">
                                <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </center>
    <asp:Panel runat="server" Height="500px" Width="1020px" ID="pnlMdl" display="none"
        Style="text-align: center; padding: 10px;">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>
