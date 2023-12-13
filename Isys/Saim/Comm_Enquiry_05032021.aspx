<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Comm_Enquiry.aspx.cs" Inherits="Application_Isys_Saim_Comm_Enquiry" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script>
        function funAddmaster1(cmpcode, cntstcode, cmptype, ruletype, RuleSetkey, Cycle) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $find("mdlVwBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwd1").src = "CntstStp_INC.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&Cmptype=" + cmptype + "&ruletype=" + ruletype+"&RuleSetKey="+RuleSetkey+ "&Cycle="+Cycle
            + "&mdlpopup=mdlVwBID";
        }

        function funAddmaster2(cmpcode, cntstcode, Flag, RuleSetkey, Cycle, RuleCode, Memcode, CategoryCode, Flag2) {
            debugger;
        //    window.open("CntstStp_INC.aspx");

            window.open("CntstStp_INC.aspx?Flag2=" + Flag2 + "&CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&Flag=" + Flag + "&RuleSetKey=" + RuleSetkey + "&Cycle=" + Cycle + "&RuleCode=" + RuleCode + "&Memcode=" +
            Memcode + "&CategoryCode=" + CategoryCode + "&#divKPIRR", "_blank", "toolbar=yes,scrollbars=yes,resizable=yes,top=40,left=70,bottom=80,width=1200,height=600");


        }



        function Validtion() {
            if ((document.getElementById('<%=ddlCompCode.ClientID %>').value == "Select") || (document.getElementById('<%=ddlCompCode.ClientID %>').value == "")) {
                alert("Please Select Compensation Description");
               document.getElementById('<%= ddlCompCode.ClientID %>').focus();

                return false;
            }
            if ((document.getElementById('<%=ddlContCode.ClientID %>').value == "Select") || (document.getElementById('<%=ddlContCode.ClientID %>').value == "")) {
                alert("Please Select Contestent Code");
                document.getElementById('<%= ddlContCode.ClientID %>').focus();

                return false;
            }
            if ((document.getElementById('<%=ddlRSetKey.ClientID %>').value == "Select") || (document.getElementById('<%=ddlRSetKey.ClientID %>').value == "")) {
                alert("Please Select Rule Set Key");
                document.getElementById('<%= ddlRSetKey.ClientID %>').focus();

                return false;
            }
        }
    </script>
    <style type="text/css">
        ul#menu li a:active {
            background: white;
        }
        .gridright
        {

           text-align:right !important;
        }

          .gridleft
        {

           text-align:left !important;
        }
           .gridcenter
        {

           text-align: center !important;
        }




        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }

                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }
    </style>

    <center> 

        <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                         <img id="ImageEnq" src="../../../images/incentive_Enquiry.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>
                        <asp:Label ID="lblhdr"  Font-Size="19px" runat="server" />
                    </div>
                    <div class="col-sm-2">
                             <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> 
                    </div>
                </div>
            </div>
            <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompCode" Text="Compensation" runat="server" CssClass="control-label" ></asp:Label>
                       <span style="color: #ff0000">&nbsp*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCompCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control" OnSelectedIndexChanged="ddlCompCode_SelectedIndexChanged">
                                 </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompDesc1" Text="Contestant Code" runat="server" CssClass="control-label"></asp:Label>
                         <span style="color: #ff0000">&nbsp*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                               <asp:DropDownList ID="ddlContCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control" OnSelectedIndexChanged="ddlContCode_SelectedIndexChanged">
                                    </asp:DropDownList> 
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 5px;">
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblCompTyp" Text="Rule Set Key" runat="server" CssClass="control-label"></asp:Label>
                         <span style="color: #ff0000">&nbsp*</span>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlRSetKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    TabIndex="4"> 
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>--%>
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" OnClick="btnSearch_Click" OnClientClick="Validtion()">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Search
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" OnClick="btnCancel_Click">
                                    <span class="glyphicon glyphicon-erase BtnGlyphicon"></span> Cancel
                                </asp:LinkButton>
<%--                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
        </div>  

           <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="divcmpsrchhdrcollapse" runat="server" style="width: 97%;" class="panel ">
                    <div class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divkpisrch','Img1');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">     
                                 <img id="ImageComp" src="../../../images/incentive_Enquiry_results.png" style="border-width:0px;width: 35px;margin-top: 6px;margin-bottom:10px;height: 35px;"/>
                                <asp:Label ID="lblCmpSrch" style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                    <ContentTemplate> 
                                        <span id="Img1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div id="divkpisrch" runat="server" style="width: 96%; padding: 10px;">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgCmpStEq" runat="server" AutoGenerateColumns="false" Width="100%" Visible="true"
                                    PageSize="10" AllowSorting="True"  AllowPaging="true"   
                                    CssClass="footable" >
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                    <PagerStyle CssClass="disablepage" />
                                    <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Compensation Description" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="CMPNSTN_DESC01">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblCmpDesc" Text='<%# Bind("CMPNSTN_DESC01") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Code" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center" >

                                            <ItemStyle  CssClass="gridcenter"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemcode" Text='<%# Bind("Mem_code") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Policy No" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpolicyNo" Text='<%# Bind("POLICY_NO") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                         <asp:TemplateField HeaderText="Rate" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center"  ControlStyle-CssClass="gridcenter">

                                              <ItemStyle  CssClass="gridcenter"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRATE" Text='<%# Bind("RATE") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Premium Amount" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Right">
                                             <ItemStyle  CssClass="gridright"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPREM_AMT" Text='<%# Bind("PREM_AMT") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Reward Amount" HeaderStyle-HorizontalAlign="Right"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Right">
                                               <ItemStyle  CssClass="gridright"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRWRD_AMT" Text='<%# Bind("RWRD_AMT") %>' runat="server" />
                                            </ItemTemplate>
                                              </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Category" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategoryDesc" Text='<%# Bind("CategoryDesc") %>' runat="server" />
                                                 <asp:HiddenField ID="hdnCatgCode" runat="server" Value='<%# Bind("CategoryCode")%>' />

                                            </ItemTemplate>
                                            </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Employee Code" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">

                                             <ItemStyle  CssClass="gridcenter"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpCode" Text='<%# Bind("EmpCode") %>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Advisor Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLegalName" Text='<%# Bind("LegalName") %>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cycle Name" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBUSI_DESC" Text='<%# Bind("BUSI_DESC") %>' runat="server" />
                                                 <asp:HiddenField ID="hdnBusiCode" runat="server" Value='<%# Bind("BusiCode")%>' />
                                                
                                            </ItemTemplate>
                                            </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Member Cycle" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">

                                            <ItemStyle  CssClass="gridcenter"/>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRuleCode" Text='<%# Bind("RuleCode") %>' runat="server" />
                                                 <asp:HiddenField ID="hdnRuleCode" runat="server" Value='<%# Bind("RuleCode")%>' />
                                                
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RS Description" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Wrap="true" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRULESETDESC" Text='<%# Bind("RULESETDESC") %>' runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Action">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" 
                                                          OnClick="lnkView_Click"  ></asp:LinkButton>    

                                                         <%--<asp:LinkButton ID="lnkCnstCode" runat="server" Text='<%# Bind("CNTSTNT_CODE")%>'
                                                        OnClick="lnkCnstCode_Click"></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div  class="pagination" style="padding: 10px;" >
                            <center>
                                <table>
                                    <caption>
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprevious" runat="server" CssClass="form-submit-button" Enabled="false" OnClick="btnprevious_Click" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" Text="&lt;" Width="40px"  />
                                                        <asp:TextBox ID="txtPage" runat="server"  CssClass="form-control" ReadOnly="true" Style="width: 50px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" />
                                                        <asp:Button ID="btnnext" runat="server" CssClass="form-submit-button" OnClick="btnnext_Click" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Text="&gt;" Width="40px"  />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </caption>
                                </table>
                            </center>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
                   <div class="row" style="margin-top: 12px;">
                    <div class="col-sm-12" align="center">
                        <%--<asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>--%>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample" OnClick="LinkButton1_Click">
                                    <span class="glyphicon glyphicon-search" style="color: White;"></span> Export To Excel
                                </asp:LinkButton>
                           <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
    </center>

     <asp:Panel runat="server" Height="350px" Width="900px" ID="pnlRwdRulDemo" display="none"
        Style="text-align: center; padding: 10px; margin-left: 200px;" CssClass="panel panel-success">
        <iframe runat="server" id="ifrmRwd1" scrolling="yes" width="100%" frameborder="0"
            display="none" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label11" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw" BehaviorID="mdlVwBID" DropShadow="false"
        TargetControlID="Label11" PopupControlID="pnlRwdRulDemo" BackgroundCssClass="modalPopupBg" X="15" Y="30">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

