<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopFrmEditor.aspx.cs" Inherits="Application_ISys_Saim_PopFrmEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
        <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet"
        type="text/css" />
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
    <style type="text/css">
        .gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
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
            vertical-align: top;
        }
        
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function ShowReqDtl1(divName, btnName) {
            debugger;
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
                ShowError(err.description);
            }
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
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
                ShowError(err.description);
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

        function doOk(funckey, lstkey, fldkey, frml,frmlcode) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ////alert(strContent);
            window.parent.document.getElementById('<%=Request.QueryString["funckey"].ToString()%>').value = funckey;
            window.parent.document.getElementById('<%=Request.QueryString["lstkey"].ToString()%>').value = lstkey;
            window.parent.document.getElementById('<%=Request.QueryString["fldkey"].ToString()%>').value = fldkey;
            window.parent.document.getElementById('<%=Request.QueryString["frml"].ToString()%>').disabled = false;
            window.parent.document.getElementById('<%=Request.QueryString["frml"].ToString()%>').value = frml;
            window.parent.document.getElementById('<%=Request.QueryString["frmlcd"].ToString()%>').value = frmlcode;
            ////alert(frmlcode);
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString() %>').hide();
            window.parent.document.getElementById("btnfrml").click();
        }

        function doCancel() {
                         
            /////alert('dkjahjkd');
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <center>
                <div id="divfrmedtcollapse" runat="server" style="width: 95%;" class="panel panel-success">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>
                                <asp:Label ID="Label1" Text="Formula Editor" runat="server" Style="padding-left: 5px;" />
                            </div>
                            <div class="col-sm-2">
                                <span id="myImg" class="glyphicon glyphicon-collapse-down" style="float: right; color: Orange;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divfrmedthdr" runat="server" style="width: 100%;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDtFuncKey" Text="Data Function Key" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDtFunKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="22" Width="97%" OnSelectedIndexChanged="ddlDtFunKey_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDtOprtr" Text="Data Operator" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDtOperator" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="22" Width="97%" Enabled="true">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div id="div3" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;
                                padding: 10px;" class="table-scrollable">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgFormula" runat="server" AutoGenerateColumns="false" Width="100%"
                                            PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable">
                                            <RowStyle CssClass="GridViewRow"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Data Function Key" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlDtFuncKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                            TabIndex="22" Width="97%" OnSelectedIndexChanged="ddlDtFuncKey_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Data List Key" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlDtLstKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                            OnSelectedIndexChanged="ddlDtLstKey_SelectedIndexChanged" TabIndex="20" Width="97%">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Data Field Key" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlDtFldKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                            TabIndex="21" Width="97%" OnSelectedIndexChanged="ddlDtFldKey_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>     
                    </div>
                    <div id="divfrmltrg" runat="server" style="width: 100%; padding: 10px;">
                        <div id="tblfrml" runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Data Function Key" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlFunckeyTrg" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="22" Width="97%" OnSelectedIndexChanged="ddlFunckeyTrg_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label3" Text="Based on KPI" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlKPICode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="22" Width="97%" OnSelectedIndexChanged="ddlKPICode_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="tblfrmltxt" runat="server" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:TextBox ID="txtFrmlTrg" runat="server" CssClass="standardtextbox" TextMode="MultiLine"
                                    Width="100%" />
                            </div>
                        </div>
                        <div id="tblbtnfrml" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSaveFrml" runat="server" CssClass="btn btn-primary" TabIndex="24">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCnclFrml" runat="server" CssClass="btn btn-primary" TabIndex="25"
                                    OnClientClick="doCancel();return false;">
                                            <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                </asp:LinkButton>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div id="tblbtn" runat="server" class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary" TabIndex="24"
                                OnClick="btnSave_Click">
                                            <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary"
                                TabIndex="25" OnClientClick="doCancel();return false;">
                                            <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                            </asp:LinkButton>
                            <asp:Button ID="btnClose" Text="CLOSE" runat="server" CssClass="btn default" Width="100px"
                                Visible="false" TabIndex="26" />
                            <asp:HiddenField ID="hdnFormula" runat="server" />
                            <asp:HiddenField ID="hdnFormCode" runat="server" />
                        </div>
                    </div>
                    <br />
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

