<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopCycStp_bkp12072021y.aspx.cs" Inherits="Application_ISys_Saim_PopCycStp" %>

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
    <script type="text/javascript">
        //        ctl00$ContentPlaceHolder1$dgYear$ctl02$txtStrtDt
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
        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ////ShowError(err.description);
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
        
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <center>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="divfinhdrcollapse" runat="server" style="width: 95%;" class="panel panel-success">
                            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg');return false;">
                                <div class="row">
                                    <div class="col-sm-10" style="text-align: left">
                                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                                        <asp:Label ID="lblbusiyrhdr" runat="server" />
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="myImg" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                            padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="divfinhdr" runat="server" style="width: 100%; text-align: left; white-space: nowrap;"
                                class="panel-body">
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblYrCode" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblYrCodeVal" runat="server" CssClass="form-control-static new_text_new"
                                            TabIndex="14" />
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblShrtYrDsc" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblShrtYrDscVal" runat="server" CssClass="form-control-static new_text_new"
                                            TabIndex="14" />
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblYrDesc" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblYrDescVal" runat="server" CssClass="form-control-static new_text_new"
                                            TabIndex="14" />
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblStrtDt" Text="Start Date" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblStrtDtVal" runat="server" CssClass="form-control-static new_text_new"
                                            TabIndex="14" />
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblEndDt" Text="End Date" runat="server" CssClass="control-label" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblEndDtVal" runat="server" CssClass="form-control-static new_text_new"
                                            TabIndex="14" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
                <div id="divYr" runat="server" style="width: 95%;" class="panel panel-success">
                    <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divyrhdr','Img3');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                                <asp:Label ID="lblyrhdr" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img3" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divyrhdr" runat="server" style="width: 100%;" class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgYear" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="12" AllowSorting="True" AllowPaging="true" CssClass="footable">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cycle Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMthCode" Text='<%# Bind("MTH_CODE")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cycle Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_NAME">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblMthName" Text='<%# Bind("MTH_NAME")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="START_DATE">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtStrtDt" Text='<%# Bind("START_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="END_DATE">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtEndDt" Text='<%# Bind("END_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Parent Busi Code" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" SortExpression="PARENT_BUSI_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparcode" runat="server" Text='<%# Bind("PARENT_BUSI_CODE")%>'></asp:Label>
                                            </ItemTemplate>
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
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevyr" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevyr_Click" />
                                                    <asp:TextBox runat="server" ID="txtPageYr" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnextyr" Text=">" CssClass="form-submit-button" Enabled="false"
                                                        runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                        OnClick="btnextyr_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSaveYr" runat="server" CssClass="btn btn-primary" OnClick="btnSaveYr_Click">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclYr" runat="server" CssClass="btn btn-primary" TabIndex="25"
                                    OnClick="btnCnclYr_Click">
                                            <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div id="divHyr" runat="server" style="width: 95%;" class="panel panel-success">
                    <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divhyrhdr','Img4');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                                <asp:Label ID="lblhyrhdr" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img4" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divhyrhdr" runat="server" style="width: 100%;" class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgHyrYr" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="12" AllowSorting="True" AllowPaging="true" CssClass="footable">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cycle Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMthCode" Text='<%# Bind("MTH_CODE")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cycle Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_NAME">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblMthName" Text='<%# Bind("MTH_NAME")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="START_DATE">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtStrtDt" Text='<%# Bind("START_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="END_DATE">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEndDt" Text='<%# Bind("END_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Parent Busi Code" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" SortExpression="PARENT_BUSI_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparcode" runat="server" Text='<%# Bind("PARENT_BUSI_CODE")%>'></asp:Label>
                                            </ItemTemplate>
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
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevhyr" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                    <asp:TextBox runat="server" ID="txtPageHyr" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnexthyr" Text=">" CssClass="form-submit-button" runat="server"
                                                        Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSaveHyr" runat="server" CssClass="btn btn-primary" OnClick="btnSaveHyr_Click">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclHyr" runat="server" CssClass="btn btn-primary" TabIndex="25"
                                    OnClick="btnCnclHyr_Click">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div id="divQtr" runat="server" style="width: 95%;" class="panel panel-success">
                    <div id="Div3" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqtrhdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                                <asp:Label ID="lblqtryrhdr" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img2" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divqtrhdr" runat="server" style="width: 100%;" class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgQtrYr" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="12" AllowSorting="True" AllowPaging="true" CssClass="footable">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cycle Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMthCode" Text='<%# Bind("MTH_CODE")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cycle Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_NAME">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblMthName" Text='<%# Bind("MTH_NAME")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="START_DATE">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtStrtDt" Text='<%# Bind("START_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="END_DATE">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEndDt" Text='<%# Bind("END_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Parent Busi Code" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" SortExpression="PARENT_BUSI_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparcode" runat="server" Text='<%# Bind("PARENT_BUSI_CODE")%>'></asp:Label>
                                            </ItemTemplate>
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
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevqtr" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                    <asp:TextBox runat="server" ID="txtPageQtr" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnewqtr" Text=">" CssClass="form-submit-button" Enabled="false"
                                                        runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSaveQtr" runat="server" CssClass="btn btn-primary" OnClick="btnSaveQtr_Click">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclQtr" runat="server" CssClass="btn btn-primary" TabIndex="25"
                                    OnClick="btnCnclQtr_Click">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div id="divMonth" runat="server" style="width: 95%;" class="panel panel-success">
                    <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmthhdr','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;
                                <asp:Label ID="lblmthyrhdr" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <span id="Img1" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divmthhdr" runat="server" style="width: 100%;" class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgMthYr" runat="server" AutoGenerateColumns="false" Width="100%"
                                    PageSize="12" AllowSorting="True" AllowPaging="true" CssClass="footable">
                                    <RowStyle CssClass="GridViewRow"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cycle Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMthCode" Text='<%# Bind("MTH_CODE")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cycle Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_NAME">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblMthName" Text='<%# Bind("MTH_NAME")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="START_DATE">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtStrtDt" Text='<%# Bind("START_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="END_DATE">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEndDt" Text='<%# Bind("END_DATE")%>' runat="server" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Parent Busi Code" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" SortExpression="PARENT_BUSI_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparcode" runat="server" Text='<%# Bind("PARENT_BUSI_CODE")%>'></asp:Label>
                                            </ItemTemplate>
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
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevmth" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                    <asp:TextBox runat="server" ID="txtPageMth" Style="width: 35px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnextmth" Text=">" CssClass="form-submit-button" Enabled="false"
                                                        runat="server" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                        <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSaveMth" runat="server" CssClass="btn btn-primary" OnClick="btnSaveMth_Click">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save    
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclMth" runat="server" CssClass="btn btn-primary" TabIndex="25"
                                    OnClick="btnCnclMth_Click">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
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
    <script type="text/javascript">
        $(function () {
            debugger;
            $("#<%= txtStrtDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtEndDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>
</asp:Content>
