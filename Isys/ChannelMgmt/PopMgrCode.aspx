<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopMgrCode.aspx.cs"
    Inherits="Application_INSC_ChannelMgmt_PopMgrCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
     <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"  type="text/css" />
  <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />



   <%--<link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />

    <link href="../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />

    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/formatting.js"></script>
    <script src="../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />

   <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />

    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script> --%>
    <script language="javascript" type="text/javascript">

        function ShowReqDtl(divName, btnName) {
            //debugger;
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

        function doSelect(args1, args2, args3, args4, args5) {
            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').value = args2 + " ( " + args5 + " )";
            window.parent.document.getElementById('<%=Request.QueryString["Field3"].ToString()%>').innerText = args1;
            window.parent.document.getElementById('<%=Request.QueryString["Field2"].ToString()%>').focus();
            window.parent.document.getElementById('<%=Request.QueryString["ddl"].ToString()%>').value = args4;

            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            return false;
        }

        function doClear() {
            document.getElementById("<%=txtMgrName.ClientID%>").value = "";
            document.getElementById("<%=txtSAPCode.ClientID%>").value = "";
            document.getElementById("<%=rdbPosn.ClientID%>").SelectedIndex = -1;
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        function doOk(isPrimary, rowid) {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (isPrimary == 'Y') {
                window.parent.document.getElementById("btnmemgrid").click();
            }
            else {
                window.parent.document.getElementById("btnRptmemgrid").click();
            }
            //window.parent.document.getElementById("btnRptmemgrid").click();

        }

    </script>

    <style type="text/css">
        

           .hidScroll {
            margin: 0px;
            border-color: #d6e9c6;
        }
            .clsCenter{
            text-align:center !important;
        }
        .clsLeft{
            text-align:left !important;
        }
    </style>
    <asp:ScriptManager ID="scriptMgr" runat="server" />
 <%--   <div class="container">--%>
            <div class="card PanelInsideTab"  >


            <div id="divuntcodeHdr" runat="server" class="control-label HeaderColor" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divuntcode','Span4');return false;">
                <div class="row">
                    <div class="col-xs-10" style="text-align: left">
                        <asp:Label ID="lblhdr" runat="server" Text="Manager Search" Font-Size="19px"></asp:Label>
                    </div>
                   <%-- <div class="col-xs-2">
                    <span id="Span4" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>

                    </div>--%>
                </div>
            </div>

            <div id="divuntcode" class="panel-body" runat="server">

                <div class="row">
                    <div class="col-sm-6" style="text-align: left">
                        <asp:Label ID="lblSAP" runat="server" CssClass="control-label" Text="Code"></asp:Label>
                         <asp:TextBox ID="txtSAPCode" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ValidationGroup="mgrValGrp" ValidationExpression="^[0-9]+$"
                            ControlToValidate="txtSAPCode" ID="regexp_Mobile"
                            runat="server" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                   <%-- <div class="col-sm-9">
                       
                    </div>--%>
              <%--  </div>
                <br />
                <div class="row">--%>
                    <div class="col-sm-6">
                        <asp:Label ID="lblMgrName" runat="server" CssClass="control-label" Text="Name"></asp:Label>
                         <asp:TextBox ID="txtMgrName" runat="server" CssClass="form-control"></asp:TextBox><br />
                        <asp:RegularExpressionValidator ValidationGroup="mgrValGrp" ID="regexp_Name" runat="server"
                            ControlToValidate="txtMgrName" ErrorMessage="Invalid Name!" SetFocusOnError="true"
                            ValidationExpression="^[a-zA-Z ]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                  <%--  <div class="col-sm-9">
                       
                    </div>--%>
                </div>

                <div class="row rowspacing">
                    <div class="col-sm-6" style="text-align: left">
                        <asp:Label ID="lblPosn" runat="server" CssClass="control-label" Text="Position"></asp:Label>
                    <%--</div>

                    <div class="col-sm-3">--%>
                        <asp:RadioButtonList ID="rdbPosn" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Text="&nbsp;Yes&nbsp;"></asp:ListItem>
                            <asp:ListItem Value="1" Text="&nbsp;No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div> 

               
                 <%--<div id="Tr4" runat="server" class="col-sm-12 rowspacing" align="center">
                        <asp:LinkButton ID="btnsearch" OnClick="btnsearch_Click" CssClass="btn btn-success"
                            runat="server">
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> SEARCH
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-clear" style="color:#00cccc;background-color:#fff !important;border-color:#00cccc !important"
                            OnClientClick="doClear();return false;" runat="server">
                              CLEAR </asp:LinkButton>
                         
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-danger" CausesValidation="False" OnClientClick="doCancel();return false;" 
                            TabIndex="33">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> CANCEL
                        </asp:LinkButton>
                    </div>--%>
                <div    runat="server" class="col-sm-12 rowspacing" align="center">
                  
                        <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" CausesValidation="true"
                           OnClick="btnSearch_Click" OnClientClick="javascript:validate();" > 
                            <span class="glyphicon glyphicon-search BtnGlyphicon" ></span> SEARCH

                        </asp:LinkButton> 
                        <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-clear" CausesValidation="true"
                             OnClick="btnClear_Click" OnClientClick="javascript:validate();" >  CLEAR 

                        </asp:LinkButton> 
                     <asp:LinkButton ID="btnCancel" runat="server" OnClientClick="doCancel();return false;"  CssClass="btn btn-danger">
                         <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> CANCEL 

                     </asp:LinkButton>
                  
                </div>

                <br />

                <div class="col-sm-9">
                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" CssClass="standardlabel"   Visible="false" />
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrMsg" runat="server"  Visible="False"></asp:Label>
                        <div style="width:97%;overflow-x:scroll" >
                            <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" OnRowDataBound="gv_RowDataBound" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Code" Visible="false" SortExpression="MemCode">
                                        <ItemTemplate>
                                            <i class="fa fa-male"></i>&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("MemCode") %>' Enabled="false"></asp:LinkButton>
                                        </ItemTemplate>
                                       <ItemStyle CssClass="clsCenter"></ItemStyle>
                                       <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                  <%--  <asp:BoundField DataField="EmpCode" HeaderText="Code" SortExpression="EmpCode"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />--%>
                                     <asp:TemplateField HeaderText="Code" SortExpression="EmpCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("EmpCode") %>'></asp:Label>
                                        </ItemTemplate>
                                       <ItemStyle CssClass="clsCenter"></ItemStyle>
                                       <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" SortExpression="LegalName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("LegalName") %>'></asp:Label>
                                        </ItemTemplate>
                                       <ItemStyle CssClass="clsLeft"></ItemStyle>
                                       <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Type" SortExpression="MemTypeDesc01">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemTypeDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle CssClass="clsLeft"></ItemStyle>
                                       <HeaderStyle CssClass="clsLeft" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MemStatus" HeaderText="Status" SortExpression="MemStatus"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkMemtyp" runat="server" Text='<%# Bind("MemType") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                         <ItemStyle CssClass="clsCenter"></ItemStyle>
                                       <HeaderStyle CssClass="clsCenter" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChkSelect_CheckedChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div>
                             <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;"   ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>


                <%-- <asp:Button ID="btnOK" runat="server" CssClass="standardbutton" Text="OK" onclick="btnOK_Click"  />--%>
                <div  runat="server" class="col-sm-12 rowspacing" align="center"  >
                    <%--<div class="col-sm-12" align="center">--%>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnOK" runat="server" Text="Ok" CssClass="btn btn-success"
                                    OnClick="btnOK_Click"><span class="glyphicon glyphicon-ok BtnGlyphicon"></span> OK </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                  <%--  </div>--%>
                </div>

            </div>

        </div>

    <%--</div>--%>

</asp:Content>
