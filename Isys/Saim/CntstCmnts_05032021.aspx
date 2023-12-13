<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" CodeFile="CntstCmnts.aspx.cs"
    Inherits="Application_ISys_Saim_CntstCmnts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space:nowrap;
        }
        .ajax__calendar
        {
            z-index: 100px;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .form-submit-button
        {
        }
        .disablepage
        {
            display: none;
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
        .align
        {
            text-align: left;
        }
        .rowalign
        {
            margin-bottom: 15px;
        }*/
    </style>
    <script type="text/javascript">
        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-down'
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


        //        function ShowReqDtl1(divId, btnId, img, divi) {
        //            var strContent = "ctl00_ContentPlaceHolder1_";
        //            $(document.getElementById(strContent + divId)).slideToggle();
        //            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
        //                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
        //            }
        //            else {
        //                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
        //            }
        //        }

        function doCancel() {
            window.parent.document.getElementById("btnUpdRevGrd").click();
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

        }

    </script>
    <script language="javascript" type="text/javascript">
        function funPopUp(cmpcode, cmpdesc) {
            $find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopCntst.aspx?cmpCode=" + cmpcode + "&cmpdesc=" + cmpdesc + "&mdlpopup=mdlViewBID";
        }


    </script>
    <center>
        <div id="div1" runat="server" style="width: 99%;" class="panel">
            <div id="divC" runat="server" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divok','Img2');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%><%--added ajay by sawant 25/4/2018--%>
                        <asp:Label ID="Label4" Text="Add Comments" style="font-size:19px;" runat="server" />
                    </div>
                    <div class="col-sm-2">
                        <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                    </div>
                </div>
            </div>
            <div id="divok" runat="server" style="width: 97%;" class="panel-body">
                <div style="width: 100%; border: none;" class="table-scrollable">
                    <div class="row" style="margin-bottom: 5px;">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblRuleSetKey" Text="Rule Set Key" runat="server" CssClass="control-label" />
				<span style="color: red;">*</span> 
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlRuleSetKey" runat="server" AutoPostBack="false" CssClass="select2-container form-control"
                                        TabIndex="4">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblContestStatus" Text="Reason" runat="server" CssClass="control-label" />
				 <span style="color: red;">*</span> 
                        </div>
                        <div class="col-sm-3">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlStatusR" runat="server" AutoPostBack="false" CssClass="select2-container form-control"
                                        TabIndex="4">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="text-align: left">
                            <asp:Label ID="lblStatusRemark" runat="server" CssClass="control-label" Text="Approval Remark" />
				 <span style="color: red;">*</span> 
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" CssClass="form-control"
                                TabIndex="2" />
                        </div>
                        </div>
                </div>
                <div id="Table2" runat="server" class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <asp:LinkButton ID="btOK" Text="" runat="server" Width="100px" CssClass="btn btn-sample"
                            OnClick="btOK_Click">
                                <span class="glyphicon glyphicon-floppy-disk" style="color: White;"></span> Save
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCncl" runat="server" Width="100px" CssClass="btn btn-sample"
                            OnClientClick="doCancel();return false;">
                                <span class="glyphicon glyphicon-erase" style="color: White;"></span> Cancel
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
           
                <div id="divRevHist" runat="server" class="panel-heading" style="width: 97%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divAuditTrail','Img9');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                           <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                            <asp:Label ID="Label10" Text="Comment History" runat="server" />
                        </div>
                        <div class="col-sm-2">
                            <span id="Img9" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>
                <div id="divAuditTrail" runat="server" style="width: 100%; padding: 10px;" class="panel-body">
                    <div class="table-scrollable">
                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvRevHist" runat="server" AutoGenerateColumns="false" Width="100%"
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
                                            <ItemTemplate>
                                                <asp:Label ID="lnkACompCode" runat="server" Text='<%# Bind("CMPNSTN_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contestant Code" SortExpression="CNTSTN_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkACntstCode" runat="server" Text='<%# Bind("CNTSTN_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                         
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_KEY">
                                            <ItemTemplate>
                                                
                                                <asp:Label ID="lblRuleSetDesc" runat="server" Text='<%# Bind("RuleSetDesc")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnRULE_SET_KEY" runat="server" Value='<%# Bind("RULE_SET_KEY")%>' />
                                            </ItemTemplate>
                                         
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="User Id" SortExpression="CMPNSTN_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAUserId" runat="server" Text='<%# Bind("USERid")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Comments Type" SortExpression="CMPNSTN_CODE">
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCmntType" runat="server" Text='<%# Bind("CmntType")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Comment" SortExpression="CHN">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Segment" SortExpression="CHN">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubCmntDsc" runat="server" Text='<%# Bind("SubCmntId")%>' />
                                               <%-- <asp:HiddenField ID="hdnSubCmntId" runat="server" Value='<%# Bind("SubCmntId")%>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason" SortExpression="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("ParamDesc1")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Bind("Status")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Trail Date" SortExpression="CreateDtim">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDtim" runat="server" Text='<%# Bind("CreateDtim")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField HeaderText="Version No." SortExpression="Version">
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblVersion" runat="server" Text='<%# Bind("Version")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div id="div11" visible="true" runat="server" class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="Button3" Text="<" CssClass="form-submit-button" runat="server" Width="40px"
                                                        Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                    <asp:TextBox runat="server" ID="TextBox2" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="Button4" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </div>
              
                    <div id="Div2" runat="server" class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                       
                        <asp:LinkButton ID="LinkButton2" runat="server" Width="100px" CssClass="btn btn-sample"
                            OnClientClick="doCancel();return false;">
                                <span class="glyphicon glyphicon-erase" style="color: White;"></span> Cancel
                        </asp:LinkButton>
                    </div>
                </div>
                      </div>
            
        </div>
    </center>
</asp:Content>
