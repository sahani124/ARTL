<%@ Page Title="ResendPaymentLink" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="ResendPaymentLink.aspx.cs" Inherits="Application_Isys_Recruit_ResendPaymentLink" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.mintxtAddrP1.js"></script>
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
    <%-- <script src="assets/KMI%20Styles/Bootstrap/datepicker/datetimepicker.js" type="text/javascript"></script>
    <script src="assets/jqueryCalendar/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>--%>
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <%-- <link href="../../../assets/KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>

 <script type="text/javascript" src="../../../Scripts/common.js"></script>
 <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
 <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
 <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
        <script language="javascript" type="text/javascript">

            function popup() {
                $("#myModal").modal();
            }
            function ShowReqDtl(divName, btnName) {
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
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }

            }
            function ShowReqDtl1(divName, btnName) {
                //debugger;
                try {
                    var objnewdiv = document.getElementById(divName)
                    var objnewbtn = document.getElementById(btnName);
                    if (objnewdiv.style.display == "block") {
                        objnewdiv.style.display = "none";
                        //        objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                    }
                    else {
                        objnewdiv.style.display = "block";
                        //      objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                    }
                }
                catch (err) {
                    ShowError(err.description);
                }
            }
            $(function () {
                debugger; $("#<%= txtDTRegFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear:true, changeMonth: true });
             });
                $(function () {
                    debugger;

                    $("#<%= txtDTRegTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true }); //txtReqDate

                });
            </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <center>
          <div class="page-container" style="margin-top: 0px;">
            <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
            <div class="panel" id="Div1" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">
                <div class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnMap');return false;">
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                            <asp:Label ID="lbltitle" runat="server" Font-Size="19px">
                            </asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                padding: 1px 10px ! important; font-size: 18px;"></span>
                            <%--<span id="btnMap" class="glyphicon glyphicon-collapse-down" style="float: right;
                                color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                        </div>
                    </div>
                </div>
                <div id="divSearch" runat="server" class="panel-body" style="display: block; margin-top: 0.9%;
                    margin-bottom: 0.9%">
                   
                    <div id="trCandidateNo" runat="server" class="row">
                        <div class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div class="col-md-6" style="text-align: left">
                                    <asp:Label ID="lblCandidateCode" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtCandCode" runat="server" CssClass="form-control" MaxLength="15" TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                        FilterMode="InvalidChars" TargetControlID="txtCandCode" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:Label ID="LblhomeNote" runat="server" Visible="false" Text="(Value should be of 12 digit.)"
                                        Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div class="col-md-6" style="text-align: left">
                                    <asp:Label ID="lblApplicationNo" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtApplicatoNo" runat="server" CssClass="form-control" MaxLength="10" TabIndex="3"></asp:TextBox><%--txtCandCode changed to txtApplicatoNo by kalyani on 23-12-2013 for new requirement--%>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                        FilterMode="InvalidChars" TargetControlID="txtApplicatoNo" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div class="col-md-6" style="text-align: left">
                                    <asp:Label ID="lblGivenName" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtGivenName" runat="server" CssClass="form-control" MaxLength="60" TabIndex="4"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtGivenName">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div class="col-md-6" style="text-align: left">
                                    <asp:Label ID="lblSurName" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" MaxLength="30" TabIndex="5"></asp:TextBox><%--txtCandCode changed to txtApplicatoNo by kalyani on 23-12-2013 for new requirement--%>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtSurname">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="trregstrtndt" runat="server" class="row">
                        <div class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div class="col-sm-6" style="text-align: left">
                                    <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label"> </asp:Label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtDTRegFrom" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                    <%-- <uc7:ctlDate ID="txtDTRegFrom" runat="server" CssClass="standardtextbox" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div id="Div3" class="col-sm-6" style="text-align: left" runat="server">
                                    <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox TabIndex="7" ID="txtDTRegTo" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%-- <uc7:ctlDate ID="txtDTRegTo" runat="server" CssClass="standardtextbox" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                       <div id="trPan" runat="Server" class="row">
                        <div id="tdPan" runat="server" class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div class="col-md-6" style="text-align: left">
                                    <asp:Label ID="lblPan" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPan" runat="server" TabIndex="11" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       
                    </div>
                   
                        <div id="trshowrecords" runat="server" class="row">
                        <div class="col-sm-6 col-lg-6" style="padding-bottom: 6px ! important;">
                            <div class="form-group form-group-Grp">
                                <div class="col-md-6" style="text-align: left">
                                    <asp:Label ID="lblShwRecords" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlShwRecrds" TabIndex="14" runat="server" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                            </div>
                  
                    <br />
                    <div class="row">
                        <div class="col-sm-12" align="center">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-sample" AutoPostback="false"
                                    OnClick="btnSearch_Click" TabIndex="15">
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> Search
                                </asp:LinkButton> 
                                <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-sample"
                                   TabIndex="16" runat="server">
                             <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> Clear </asp:LinkButton>
                               
                                
                                <div id="divloader" runat="server" style="display: none;">
                                    <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                    Loading...
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    
                    <div id="trnote" runat="server" class="row">
                        <asp:Label ID="Label2" runat="server" Text="Note: All dates are in (dd/mm/yyyy)"
                            ForeColor="black"></asp:Label>
                    </div>

                    <div id="trLbl" runat="server" class="row" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div id="trDetails" runat="server" class="page-container" style="margin-top: 0px;" visible="false">
            <div>
               
                <div class="panel" id="Div2" style="margin-left: 2%; margin-right: 2%; margin-top: 1.5%">
                    <div id="tr2" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trdgdtls','Span1');return false;">
                        <div class="row" style="margin-bottom:14px">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" Text="Candidate Registration Search Result"  Font-Size="19px">
                                </asp:Label>
                                <asp:Label ID="lblPageInfo1" runat="server" Font-Bold="true" Width="160px" Visible="false"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="trdgdtls" runat="server">
                        <div id="trDgDetails" runat="server" style=" display: block">
                            <div style="overflow-x: scroll;width:97%">
                            <asp:GridView ID="dgDetails" runat="server" Style="border-bottom-color: black;" AutoGenerateColumns="False"
                                CssClass="footable" PageSize="10" AllowSorting="True" AllowPaging="True" OnRowDataBound="dgDetails_RowDataBound"
                                OnRowCommand="dgDetails_RowCommand" OnPageIndexChanging="dgDetails_PageIndexChanging"
                             >
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <Columns>
                                    <%--column 0--%>
                                 <%--   <asp:TemplateField HeaderText="Candidate Id" HeaderStyle-HorizontalAlign="Center"
                                       SortExpression="CandidateNo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("CandidateNo") %>' CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                     <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"    HeaderText="Candidate No"
                                        ItemStyle-Width="8%" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("CandidateNo") %>'  CommandArgument='<%# Eval("CandidateNo") %>'
                                                CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>


                                    <%--column 1--%>
                                    <asp:TemplateField SortExpression="ApplicationNo" HeaderStyle-HorizontalAlign="Center"
                                        HeaderText="Application No">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbProsID" runat="server" Text='<%# Eval("ApplicationNo") %>'
                                                CommandArgument='<%# Eval("ApplicationNo") %>' CommandName="click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <%--CssClass="LnkBtn" --%>
                                    </asp:TemplateField>
                                        <%--column 1--%>
                                      <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>

                                    <%--column 2--%>
                                   
                                    <%--column 3--%>
                                    <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 4--%>
                                    <asp:TemplateField SortExpression="CndStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("CndStatus") %>' ToolTip='<%# Eval("CndStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 5--%>
                                    <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>'
                                                ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 6--%>
                                    <asp:TemplateField SortExpression="Channel" HeaderText="Channel" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbizsrc" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <%--column 7--%>
                                    <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAgtName" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>'
                                                Style="padding-left: 5px;"></asp:Label>
                                        </ItemTemplate>
                                        <%--<ItemStyle HorizontalAlign="Left" Font-Bold="False" Width="8%"></ItemStyle>--%>
                                    </asp:TemplateField>                         
                                                                                                       
                                                                   
                                    <%--column 8--%>
                                    <asp:TemplateField SortExpression="CandidateNo" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="8%" HeaderText="Action">
                                        <ItemTemplate>
                                            <span class="glyphicon glyphicon-send"></span>
                                            <asp:LinkButton ID="lnkResendLink" runat="server" Text="Payment Link" CommandArgument='<%# Eval("CandidateNo") %>' OnClick="lnkResendLink_Click"
                                                CommandName="Resendlink"></asp:LinkButton> &nbsp&nbsp&nbsp&nbsp
                                             <asp:LinkButton ID="lnkbtnOtplnk" runat="server" Text="Share OTP Link" CommandArgument='<%# Eval("CandidateNo") %>' OnClick="lnkbtnOtplnk_Click"
                                                ></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                   
                                </Columns>
                            </asp:GridView>
                                </div>
                            <div>
                                <br />
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                            <input id="hdnUpdate" type="hidden" runat="server" />
                        </div>
                        
                         
                        
                        
                        
                     
                        
                        
                        
                        
                        
                    </div>
                </div>
            </div>
        </div>
          <asp:Panel runat="server" ID="pnlMdl" Width ="500" Height="428" display = "none" top="52" left= "529px">
        <iframe runat="server" id="ifrmMdlPopup" width="610px" height="539px"  frameborder="0" style="margin-top: -85px;"
            display="none"></iframe>
         <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        X="260" Y="100" >
                    </ajaxToolkit:ModalPopupExtender>
                      <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
  

      <div class="modal-content" >
        <div class="modal-header" style="text-align: center;">
            <asp:Label ID="Label16" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button"  class="btn btn-sample"  data-dismiss="modal" style='margin-top: -6px;border-radius: 15px;'>
             <span class="glyphicon glyphicon-ok  BtnGlyphicon" style='color: White;'> </span> OK

             </button>
         
        </div>
      </div>

      
      
    </div>
 </div>
          </center>
     <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
                    BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
                    TargetControlID="hiddenField1" PopupControlID="Panel1">
                </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
                <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
                    <%--background-color: #C0C0C0;--%>
                    <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
                </asp:Panel>
</asp:Content>

