<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="POSPApproval.aspx.cs" Inherits="Application_Isys_Recruit_POSPApproval" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>
<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
         <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
 
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <%-- <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
  
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
      <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
     <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
        <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>--%>

          <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
  
    <script type="text/javascript">
        $(function () {
            debugger;

            $("#<%= txtDTRegFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });

            $("#<%= txtDTRegTo.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });

        });


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
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
    </script>

    <style type="text/css">
        .clscenter{
            text-align:center !important;
        }

        .gvnone{
display:none;
        }
        .header{
        position: fixed !important;
    z-index: 100001 !important;
    left: 385px !important;
    top: 100px !important;
}

   .headerSpac{
       padding:7px !important;
           font-weight:normal;
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

    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
        function DateValidation(args1, argsID) {
            var Splitargs1 = args1.split("/");
            var BeginMonth = eval(Splitargs1[1]);
            var BeginYear = eval(Splitargs1[2]);
            var RegDate = new Date(args1);
            var BeginDate1 = args1;
            var TodayDate = new Date();

            if (BeginMonth != '' && BeginYear != '') {
                if (!validDate(BeginDate1, 'dd/mm/yyyy', 1, 2)) {
                    alert('err');
                    document.getElementById(argsID).focus();
                    return 1;
                }
            }
            return 0;
        }

        $(function () {
            // debugger;
            $('#<%=dgDetails.ClientID %>').footable({
                breakpoints: {

                    phone: 300,
                    tablet: 1000
                }
            });
        });


            function validation() {
                if (SpaceTrim(document.getElementById(strContent + "txtDTRegFrom").value) != "") {
                    if (DateValidation(document.getElementById("<%= txtDTRegFrom.ClientID %>").value, "ctl00_ContentPlaceHolder1_txtDTRegFrom") == 1)
                        return false;
                }

            }

            function SpaceTrim(InString) {
                var LoopCtrl = true;
                while (LoopCtrl) {
                    if (InString.indexOf("  ") != -1) {
                        Temp = InString.substring(0, InString.indexOf("  "));
                        InString = Temp + InString.substring(InString.indexOf("  ") + 1, InString.length);
                    }
                    else
                        LoopCtrl = false;
                }
                if (InString.substring(0, 1) == " ")
                    InString = InString.substring(1, InString.length);
                if (InString.substring(InString.length - 1) == " ")
                    InString = InString.substring(0, InString.length - 1);
                return (InString);
            }

            function ValidationConfirm() {
                debugger;

                if (document.getElementById('<%= chkrcvd.ClientID %>').checked == false) {
                alert('Please Confirm taking a personal interview and found the said candidate suitable for inducting him into Group company.');

                var myExtender = $find('ProgressBarModalPopupExtender');
                myExtender.hide();
                return false;

            }
        }
        //Ended by Nikhil on 5.6.15 for confirm validation 

        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();

            return true;
        }
        //added by nikhil for noc  cfr
        function funcopenCFRBrn(arg1, Code) {
            debugger;
            $find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/AdvTrnHrsReqSubmit.aspx?TrnRequest=CFRRaise&CndNo=" + arg1 + "&Code=" + Code + "&Type=R&user=Brn&mdlpopup=MdlPopRaiseSub";
        }
        function funcNOCDtls(arg1) {
            debugger;
            //$find("MdlPopRaiseSub").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseSub").src = "../../../Application/ISys/Recruit/NOCApproval.aspx?TrnRequest=NOCDtls&CndNo=" + arg1 + "&Type=NOCPage&mdlpopup=MdlPopRaiseSub";
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div >
        
        <asp:Panel ID="Panel2" Width="100%" runat="server" Style="overflow: hidden;">

            <center>
     <div class="card PanelInsideTab">

                <div id="div2" runat="server" Visible="false" class="row">
                        <div class="col-sm-12" style="margin-bottom: 5px;">
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Green"  Width="310px"></asp:Label>
                        </div>
                    </div>


                         <div id="Div1" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnWfParam');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lbltitle" runat="server" CssClass="control-label HeaderColor"></asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right;padding: 1px 10px ! important; font-size: 18px;color: #00cccc;"></span>
                            </div>
                        </div>
                    </div>
                      
                          <div id="divSearch" runat="server" style="display: block" class="panel-body panelContent spacebetnrow">
                             <div class="row rowspacing">
                                <div class="col-sm-4" style="text-align: left;display:none">
                                <asp:Label ID="lblCandID" runat="server" CssClass="control-label"  Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="txtCandCode" runat="server" CssClass="form-control" MaxLength="10" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" InvalidChars="&quot;'/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                   FilterMode="InvalidChars" TargetControlID="txtCandCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                           
                            </div>
                         
                              
                                <div class="col-sm-4" style="text-align: left" >
                                <asp:Label ID="lblApplicationNo" runat="server" CssClass="control-label"  Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control" MaxLength="15" TabIndex="2"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender95" runat="server"
                                            FilterType="Custom,Numbers"
                                            TargetControlID="txtAppNo">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                          
                           <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblGivenName" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="txtGivenName" runat="server" CssClass="form-control" MaxLength="60" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                TargetControlID="txtGivenName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                </div>

                                   <div class="col-sm-4" style="text-align: left">
                                <asp:Label ID="lblSurname" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" MaxLength="60" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_Surname" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " 
                                TargetControlID="txtSurname">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                         </div>
                                <div class="row rowspacing">
                         
                               
                         
                             <div class="col-md-4" style="text-align: left">
                                <asp:Label ID="lblDTRegFrom" CssClass="control-label"  runat="server" Font-Bold="False" ></asp:Label>
                                            <asp:TextBox  ID="txtDTRegFrom" runat="server" CssClass="form-control" MaxLength="15" style="margin-bottom:5px;" TabIndex="6" placeholder="dd/mm/yyyy"/>
                                                   <%-- <ajaxToolkit:CalendarExtender ID="CldrRegDtfrom" runat="server" TargetControlID="txtDTRegFrom" PopupButtonID="btnRegFrom" Format="dd/MM/yyyy"  />
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            ValidChars ="1234567890/" FilterMode="ValidChars"
                                                            TargetControlID="txtDTRegFrom" FilterType="Custom">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                     <asp:RequiredFieldValidator ID="RFVRegdt" runat="server" SetFocusOnError="true"  ControlToValidate="txtDTRegFrom"  Enabled="false"
                                                    ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>
                                                &nbsp;
                                                <asp:CompareValidator ID="COMPAREVALIDATOROldLicense" runat="server" 
                                                    controltovalidate="txtDTRegFrom" Display="Dynamic" errormessage="Invalid date!" 
                                                    operator="DataTypeCheck" type="Date"></asp:CompareValidator>
                                                &nbsp;
                                                <asp:RangeValidator ID="RVOldLicense" runat="server" 
                                                    ControlToValidate="txtDTRegFrom" Display="Dynamic" 
                                                    ErrorMessage="Date out of range!" MaximumValue="2099-01-01" 
                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>--%>
                                   </div>

<div class="col-md-4"style="text-align: left">
                                <asp:Label ID="lblDTRegTO" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                                    <asp:TextBox  ID="txtDTRegTo" runat="server" CssClass="form-control" MaxLength="15" style="margin-bottom:5px;" TabIndex="8" placeholder="dd/mm/yyyy"/>
                                     </div>

                                      <div class="col-md-4" style="text-align: left">
                            <asp:Label ID="lblPan" CssClass="control-label"  runat="server" Font-Bold="false"></asp:Label>
                            <asp:TextBox ID="txtPan" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                       
                       </div>
                                    </div>
                                <div class="row rowspacing" style="display:none">
                              
                      

                                    <div  class="col-md-4" style="text-align: left;display:none">
                                    <asp:Label ID="lblAgntBroker" runat="server" CssClass="control-label"  Text="Agent Broker Code" Width="140px"></asp:Label>
                                    <asp:TextBox ID="txtAgntBroker" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>

                                    <div class="col-md-4" style="text-align: left;display:none">
                                <asp:Label ID="lblSapcode" CssClass="control-label"  runat="server" Text="SAP Code" Font-Bold="False"></asp:Label>
                                <asp:TextBox ID="txtSapCode" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                   </div>

             
                      <div  runat="Server" class="row rowspacing">
                          <div class="col-md-4" style="text-align: left">
                                <asp:Label ID="lblShwRecords" CssClass="control-label"  runat="server" Font-Bold="False"></asp:Label>
                                <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass=" form-select form-control"  TabIndex="9">
                                </asp:DropDownList>
                                </div>
                        
                        </div>
                       

                          <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                              
                              <%--  <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-suscess"
                                    runat="server">
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                                </asp:LinkButton>--%>
                                  <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success" AutoPostback="false"
                                    OnClick="btnSearch_Click" TabIndex="15">
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> SEARCH
                                </asp:LinkButton> 
 
                               <%-- <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-suscess"
                                    TabIndex="5" runat="server">
                                 <span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> Clear
                                </asp:LinkButton>--%>
                                 <asp:LinkButton ID="btnClear"   OnClick="btnClear_Click" CssClass="btn btn-clear"
                                   TabIndex="16" runat="server">
                             CLEAR </asp:LinkButton>
                        
                            </div>
                            <div id="divloader" runat="server" style="display: none;">
                            </div>
                           
                            <div class="row" style="margin-top: 12px;">
                                <%-- </tr>--%>
                            </div>
                        </div>

                         <div id="trlbl" runat="server" class="row">
                     
                        <div class="col-sm-12" style="margin-bottom: 5px; height: 14px;">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" Width="310px"></asp:Label>
                        </div>
                         </div>

                          <div  id="tr4" runat="server" class="col-sm-12" style="margin-bottom: 5px;">
                          <asp:Label ID="Label2" runat="server" Text="Note: All dates are in (dd/mm/yyyy)"
                            ForeColor="Black" Visible="false"></asp:Label>
                    </div>
                   

                            </div>
                                </div>
                     
                      <div id="trnote" runat="server" visible="false" class="card PanelInsideTab">
                      <div id="Div4" runat="server" class="panelheadingAliginment">
                            <div class="row" id="trDetails" runat="server">
                                <div class="col-sm-10" style="text-align: left">
                                    
                                    <asp:Label ID="Label3" Text="Candidate Search Results" runat="server" CssClass="control-label HeaderColor">
                            </asp:Label>                                     
                                        <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                   
                                </div>
                                <div class="col-sm-2">
                                    <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; padding: 1px 10px ! important; font-size: 18px;"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','Span1');return false;"></span>
                                </div>
                            </div>
                        </div>
                 
                                       <div id="trDgDetails" runat="server" style="overflow: auto; margin-top: 10px;padding: 10px" >
                                           <div id="Div3" runat="server" style="overflow: auto; margin-top: 10px;padding: 10px" >
                  <asp:UpdatePanel ID="UpdatePanel002" runat="server">
                                    <ContentTemplate>
                                        
                                             <asp:GridView runat="server" AllowSorting="True" ID="dgDetails" CssClass="footable"  Style="border-bottom-color: black;margin-top: 15px;"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1" OnSorting="dgDetails_Sorting"
                                        OnRowDataBound="dgDetails_RowDataBound" OnRowCommand="dgDetails_RowCommand" >
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                      <HeaderStyle CssClass="gridview th" />
                                   <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                      <%--  <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                                            <Columns>
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate ID" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="10%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("CandidateNo") %>' CommandArgument='<%# Eval("CandidateNo") %>'
                                                            CommandName="click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" CssClass="headerSpac" Wrap="False" />
                                                    <ItemStyle CssClass="clscenter"/>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo" HeaderText="Application No" ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblappno" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'></asp:Label>
                                                        <%--<asp:LinkButton ID="lblappno" runat="server" Text='<%# Eval("ApplicationNo") %>' CommandArgument='<%# Eval("ApplicationNo") %>'
                                                            ></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter"/>
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNamePronoun" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter"/>
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle CssClass="clscenter"/>
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField SortExpression="RecruitAgtName" Visible="false" HeaderText="Recruiter Name" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("RecruitAgtName") %>' ToolTip='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clscenter"/>
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>

                                                 <asp:TemplateField SortExpression="PANNo" HeaderText="PAN No" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPanNo" runat="server" Text='<%# Eval("PANNo") %>' ToolTip='<%# Eval("PANNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <ItemStyle CssClass="clscenter"/>
                                                     <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                                 <asp:TemplateField SortExpression="AadharNo" HeaderText="Aadhar No" ItemStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaadharNo" runat="server" Text='<%# Eval("AadharNo") %>' ToolTip='<%# Eval("AadharNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle CssClass="clscenter"/>
                                                     <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>

                                                <asp:TemplateField SortExpression="ReportingSMCode" HeaderText="Reporting SM Code" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRSMCode" runat="server" Text='<%# Eval("ReportingSMCode") %>' ToolTip='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="BranchName" HeaderText="Branch Name" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblbranchname" runat="server" Text='<%# Eval("BranchName") %>' ToolTip='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="BranchCode" HeaderText="Branch Code" ItemStyle-Width="15%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblbranchcode" runat="server" Text='<%# Eval("BranchCode") %>' ToolTip='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <ItemStyle CssClass="clscenter"/>
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>

                                                <asp:TemplateField SortExpression="CreateDtim"  HeaderText="Registration Date" ItemStyle-Width="13%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDtim" runat="server" Text='<%# Eval("CreateDtim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDtim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    
                                                  <ItemStyle CssClass="clscenter"/>
                                                     <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                             
                                                <asp:TemplateField visible="false" SortExpression="ActionableDate" HeaderText="Actionable Date" ItemStyle-Width="13%" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActDate" runat="server" Text='<%# Eval("Actdate","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("Actdate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    
                                                    <ItemStyle Font-Bold="False"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Approve"  ItemStyle-Width="5%" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblapprove" runat="server" Text='<%# Eval("cndStatus") %>' Visible="false" />
                                                         
                                                        <asp:RadioButton ID="rbrapprove" GroupName="Approval" runat="server" 
                                                            AutoPostBack="True" oncheckedchanged="rbrapprove_CheckedChanged" />
                                                    </ItemTemplate>
                                                  
                                                    
                                                    <ItemStyle CssClass="clscenter"/>
                                                  <HeaderStyle  CssClass="headerSpac"/>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Reject"  Visible="True" ItemStyle-Width="4%" >
                                                    <ItemTemplate>
                                                   
                                                        <asp:RadioButton ID="rbrreject" GroupName="Approval" runat="server" 
                                                            AutoPostBack="True" oncheckedchanged="rbrreject_CheckedChanged"/>
                                                    </ItemTemplate>
                                                    
                                                    <HeaderStyle  CssClass="headerSpac"/>
                                                    <ItemStyle CssClass="clscenter"/>
                                                    
                                                </asp:TemplateField>
                                                 
                                              

                                              
                                                <asp:TemplateField HeaderText="Remark"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="18%" >
                                                    <ItemTemplate>
                                                    
                                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="standardtextbox" MaxLength="150"
                                                            Width="200px" />
                                                         <%--Added by Kalyani on 25-11-13 Hidden fields as Bank Templatefield is invisible start--%>
                                                        <input type="hidden" runat="server" id="hdntxtVarify" value="NotDone"  />
                                                        <input type="hidden" runat="server" id="hdnPmtMode" value='<%# Eval("PmtMode") %>' />
                                                         <%--Added by Kalyani on 25-11-13  Hidden fields as Bank Templatefield is invisible end--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle  HorizontalAlign="Center" CssClass="headerSpac"/>
                                                     <ItemStyle CssClass="clscenter"/>
                                                </asp:TemplateField>
                                       
                                                <asp:TemplateField HeaderText="Detail" HeaderStyle-ForeColor="teal" ItemStyle-Width="6%" Visible="false" ControlStyle-CssClass="gvnone">
                                                    <ItemTemplate>
                                                        <input type="button" id="btnVarify" value="Verify" class="standardbutton" width="50px"
                                                            runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle ForeColor="Teal" CssClass="gvnone"/>
                                                    <ItemStyle Width="6%" CssClass="gvnone"/>
                                                </asp:TemplateField>
                                            </Columns>
                                           
                                        </asp:GridView>
                                            
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                      </div>
                                           <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 40px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" Enabled="false" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                              
                              <div class="col-sm-12" style="display:none;">

                            <asp:CheckBox ID="chkrcvd" runat="server" />
                             <asp:Label ID="lblconfirm" runat="server" Style="color: black" Text="
                                I Confirm taking a personal interview and found the said candidate suitable for 
                                inducting him into Group company."></asp:Label>
                                
                                </div>  
                            
                            <br />
                            <div id="trButton" style="padding-bottom:6px; margin-top: 5px;"   runat="server" class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSubmit" OnClick="btnSubmit_Click" Visible="True" CssClass="btn btn-success"
                                    runat="server" >
                                 <span style="color:white" class="glyphicon glyphicon-floppy-disk"> </span> SUBMIT
                                </asp:LinkButton>
                               <asp:LinkButton ID="btnCancel"   runat="server" CssClass="btn btn-clear" Visible="True"
                                        OnClick="btnCancel_Click">
                             <span style="color:#00cccc" class="glyphicon glyphicon-remove"> </span> CANCEL </asp:LinkButton>
                                
                            </div>
                        </div>
                       
                       </div>
    
      
    </center>
        </asp:Panel>


        <div id="alert" runat="server">
        </div>
        <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
            <iframe runat="server" id="ifrmMdlPopup" frameborder="0" display="none" style="height: 220px; width: 696px"></iframe>
        </asp:Panel>
        <asp:Label runat="server" ID="lbl1" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
            DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        
        
        <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" style='width:400px;height:225px;'>
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label1" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl3" runat="server"></asp:Label><br />
          <asp:Label ID="lbl2" runat="server"></asp:Label><br />
          <asp:Label ID="lbl4" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-verify" data-dismiss="modal" style='margin-top: -6px;border-radius: 15px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
                 <asp:Panel ID="pnl" runat="server" CssClass="header">
                 <div class="panel panel-success #rcorners2" id="divAlert" runat="server" style="width:35%;
                display: block; border: 2px; border-radius: 15px; background-color: white; border: solid;
                border-color: blue; border-width: 2px;" cellpadding="0" cellspacing="0">
                <div id="Div8" runat="server"   style="width:98%;!important" class="panelheadingAliginment" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                              <div id="Div26" runat="server">
                             <center style="color: #034ea2;font-size: 22px;padding:10px;margin-left: -27px;width: 100%;"  CssClass="control-label HeaderColor">INFORMATION</center>
                            </div>
                        </div>
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lbl13" runat="server"></asp:Label><br />
                        <br />
                    </center>
                     <center>
                        <asp:Label ID="lbl12" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <center st>
                        <asp:Label ID="lbl14" runat="server"></asp:Label><br />
                        <br />
                    </cente>
                    <br />
                </td>
            </tr>
        </table>
                     <center>
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn btn-success"/>
                     <asp:Label ID="Label4" runat="server"></asp:Label><br />
                      </center>
            <br />
            </div>

    </asp:Panel>
           
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Label4"
        BehaviorID="mdlpopup"  PopupControlID="pnl"
       OkControlID="btnok" Y="100" >    
    </ajaxToolkit:ModalPopupExtender>
    


        <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    </div>
    <%--Added By Ibrahim on 03/05/2013 for Information Pop-up End--%>
    <%--loader image start--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
        <%--background-color: #C0C0C0;--%>
        <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
    </asp:Panel>
    <%--loader image end--%>
    <asp:Panel runat="server" ID="PnlRaiseSub" Width="1000px" display="none">
        <iframe runat="server" id="IframeRaiseSub" frameborder="0" display="none" style="width: 1000px; height: 500px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblSub" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseSub" BehaviorID="MdlPopRaiseSub"
        DropShadow="true" TargetControlID="lblSub" PopupControlID="PnlRaiseSub" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

