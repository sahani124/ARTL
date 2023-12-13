<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="NOC.aspx.cs" Inherits="Application_INSC_Recruit_NOC" Title="Untitled Page" %>

<%@ Register Src="../../../App_UserControl/Common/ctlDate.ascx" TagName="ctlDate"
    TagPrefix="uc7" %>
<%@ Register Src="~/Application/Common/popupAML.ascx" TagName="popupAML" TagPrefix="uc6" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
<%--    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
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
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"type="text/css" />--%>
   <%-- <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />--%>
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
    <script type="text/javascript">

        function ShowReqDtl12(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
        //for main div
        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-menu-hamburger'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function popup(HTML) {
			debugger;
			//$("#myModal").modal();
			$("#mdlpopup1").show();
			//document.getElementById("ctl00_ContentPlaceHolder1_divmdlbdy").innerHTML = HTML;
			document.getElementById("divmdlbdy").innerHTML = HTML;
        }

        function ClosePopup() {
            debugger;
            $("#mdlpopup1").hide();

        }

    </script>
    <style type="text/css">
        .disablepage {
            display: none;
        }
                .tabsize {
            font-size:12px;
        }


        .gridview th {
    padding: 0px;
    height: 40px;
    border-color: #53accd !important;
    text-align: center;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
        }

        .modal-dialog {
            position: relative;
            display: table;
            overflow-y: auto;
            overflow-x: auto;
            width: auto;
            min-width: 50px;
        }

        .textalign th {
            padding-left: 42%;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div class="stripPanelClass">
        <ul class="nav nav-tabs" id="myTab" role="tablist">
            <li class="nav-item" role="presentation" style="font-size: 12px!important;">
                <button class="nav-link active Strip tabsize" id="divPDH" runat="server" data-bs-toggle="tab" data-bs-target="#divPD" type="button" role="tab" aria-controls="divPD" aria-selected="true"><span id="span5" runat="server" class="badge bg-secondary numbercircle">1</span>&nbsp Personal Details</button>
            </li>


            <li class="nav-item" role="presentation">
                <button class="nav-link Strip tabsize" id="divCDH" runat="server" data-bs-toggle="tab" data-bs-target="#divCD" type="button" role="tab" aria-controls="divCD" aria-selected="false"><span id="span9" runat="server" class="badge bg-secondary numbercircle">2</span>&nbsp Document Upload</button>
            </li>


        </ul>
    </div>
    <%--  <div class="container">--%>
       <%-- <asp:UpdatePanel ID="Upd" runat="server">
            <ContentTemplate>--%>
               <%-- <div style="overflow: hidden;">--%>
                    <%--<asp:Panel ID="pnlRprt"  runat="server" Style="overflow: hidden;"> --%><%-- Width="90%"--%>
                       <%-- <center>--%>
                            
                            <div class="row  rowspacing">
                                <div id="tdPop" runat="server" visible="false" class="col-sm-12" style="margin-bottom: 5px;">
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
                                    <asp:Label ID="lblSuccessMsg" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
                                </div>
                            </div>
                       
                            <%--<div id="divNocrq" class="PanelInsideTab" visible="true">--%>
                                <div id="Div3" runat="server" class="panelheadingAliginment" >  <%--onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_idpnlBdy','btnWfParam');return false;"--%>
                                    <div class="row rowspacing">
                                        <div class="col-sm-10" style="text-align: left">
                                           <%-- <span class="" style="color: Orange;">
                                            </span>--%>
                                            <asp:Label ID="lblTitle1" style="font-size:19px;" runat="server" Text="NOC Request Search"
                                              ></asp:Label>
                                        </div>
                                       
                                    </div>
                                </div>
                                  <%--</div>--%>
                                 <div class="tab-content" id="myTabContent">

    <%--Personal Details Start--%>
           <%-- <div class="tab-pane fade show active PanelInsideTab" id="divPD" role="tabpanel" aria-labelledby="divPDH">
                            
            </div>--%>
    <%--Personal Details End--%>

 
    <%--Training & Exam Details Start--%>
            <div class="tab-pane fade PanelInsideTab" id="divTED" role="tabpanel" aria-labelledby="divEEDH">
        
  </div>
       <%--Training & Exam Details End--%>
</div>                                                       
                               
                                <%--<div id="idpnlBdy"  style="display: block;" runat="server" class="">--%>
                                    <div id="divSrvcReqReport" runat="server" class="card PanelInsideTab" style="display: block; margin-right:68px;margin-left:70px ;margin-top: -3px;"> 
                                       <div class="panelheadingAliginment" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divagndetails','Span1');return false;" > <%--style="background-color:"--%> <%--style="margin-right: 75px;margin-left:0px;"--%>
                                         <div class="row">
                                        <div class="col-sm-10" style="text-align: left" >
                                            <asp:Label ID="lblCnddtls"  runat="server" class=" control-label HeaderColor" style="margin-right: 190px;" ></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="Span1" class="glyphicon glyphicon-chevron-up" style="float: right; color: #00cccc; padding: 1px 10px ! important; font-size: 18px;"></span>
                                            <%--class=" glyphicon glyphicon-menu-hamburger"--%>
                                        </div>
                                    </div>
                                    </div>
                                                <div id="divIsSpecified" runat="server" style="display: block;">
                                                    <asp:UpdatePanel ID="Updatepanel114" runat="server">
                                                        <ContentTemplate>
                                                            <div class="row rowspacing">
                                                                <div class="col-md-6" style="margin-bottom: 5px;">
                                                                    <asp:Label ID="lblIsSPFlag" CssClass="control-label" runat="server" Style="color: black"></asp:Label>
                                                                </div>
                                                                <div class="col-md-6" style="margin-bottom: 5px;">
                                                                    <asp:UpdatePanel ID="UpdIsSPFlag" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:RadioButtonList ID="rbtIsSP" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                                                                Visible="true" TabIndex="25" Enabled="false">
                                                                                <%--AutoPostBack="true" OnSelectedIndexChanged="rbtIsSP_SelectedIndexChanged"--%>
                                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <div class="row rowspacing" >
                                                                <div id="tr_IsSPDtls" runat="server" class="col-md-4" style="margin-bottom: 5px;">
                                                                    <%--<tr id="tr_IsSPDtls" visible="false" runat="server">--%>
                                                                    <asp:UpdatePanel ID="Updatepanel15" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblCACode" runat="server" CssClass="control-label labelSize" Style="color: black"></asp:Label>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-4" style="margin-bottom: 5px;">
                                                                    <asp:UpdatePanel ID="Updatepanel16" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtCACode" runat="server" CssClass="form-control" MaxLength="15"
                                                                                Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();"> 
                                                                            </asp:TextBox>
                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender77" runat="server"
                                                                                InvalidChars=",#$@%^!*()& ''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                                FilterMode="InvalidChars" TargetControlID="txtCACode" FilterType="Custom">
                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-4" style="margin-bottom: 5px;">
                                                                    <asp:UpdatePanel ID="Updatepanel17" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblCAName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-4" style="margin-bottom: 5px;">
                                                                    <asp:UpdatePanel ID="Updatepanel118" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtCAName" runat="server" CssClass="form-control" MaxLength="20"
                                                                                Enabled="false" onChange="javascript:this.value=this.value.toUpperCase();">
                                                                            </asp:TextBox>
                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender76" runat="server"
                                                                                InvalidChars="&`''#%!@$^*-_+={}[]()|\:;?><,'~1234567890" FilterMode="InvalidChars"
                                                                                TargetControlID="txtCAName" FilterType="Custom">
                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="rbtIsSP" EventName="SelectedIndexChanged" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div id="divagndetails" runat="server" style="display: block;" class="panel-body">
                                                     <div class="row rowspacing" >
                                                         <div class="col-sm-4" style="text-align: left">
                                                               </div>
                                                         <div class="col-sm-4" style="text-align: left">
                                                               </div>
                                                        <div class="col-sm-4" style="text-align: left">
                                                            <%--<asp:Label ID="lblAdvWaiver" Text="Advisor Waiver" Visible="false" runat="server"></asp:Label>--%>
                                                            <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                                                        </div>
                                                        </div>
                                                         <div class="row rowspacing"  style="padding-left:20px;">
                                                        <div class="col-md-4" style="text-align: left">
                                                        <asp:Label ID="lblAppNo" runat="server" Text="Application No" CssClass="control-label labelSize" ></asp:Label>
                                                    </div>
                                                    <div class="col-md-4" style="text-align: left">
                                                        <asp:Label ID="lblCndName" runat="server" CssClass="control-label labelSize"></asp:Label>
                                                    </div>
                                                        <div class="col-sm-4" style="text-align: left" >
                                                            <asp:Label ID="lblCndNo" runat="server" CssClass="control-label labelSize" ></asp:Label>
                                                        </div>
                                                    </div>
                                                         <div class="row"  style="padding-left:20px;">
                                                    <div class="col-md-4" style="text-align: left">
                                                        <asp:TextBox ID="lblAppNoValue" runat="server" Enabled="false"  CssClass="form-control" ></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4"style="text-align: left" >
                                                        <asp:TextBox ID="lblAdvNameValue" Enabled="false"  CssClass="form-control" runat="server" ></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4" style="text-align: left">
                                                            <asp:TextBox ID="lblCndNoValue" runat="server" Enabled="false"  CssClass="form-control" ></asp:TextBox>
                                                        </div>
                                                         </div>
                                                         <div class="row rowspacing"  style="padding-left:20px;" >
                                                        <div class="col-sm-4" style="text-align: left">
                                                            <asp:Label ID="Label11" Text="Mobile No" runat="server" CssClass="control-label labelSize"
                                                                Style="color: Black"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-4" style="text-align: left">
                                                            <asp:Label ID="Label12" runat="server" Text="PAN No" CssClass="control-label labelSize" 
                                                                Style="color: Black"></asp:Label>
                                                        </div>
                                                         <div class="col-sm-4" style="text-align: left">
                                                            <asp:Label ID="Label13" runat="server" Text="Agency Code" CssClass="control-label labelSize"
                                                                ></asp:Label>
                                                        </div>

                                                     </div>
                                                         <div class="row"  style="padding-left:20px;">
                                                        <div class="col-sm-4" style="text-align: left" >
                                                            <asp:TextBox ID="lblmobile" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4" style="text-align: left">
                                                            <asp:TextBox ID="lblpanno" runat="server" Enabled="false"  CssClass="form-control" ></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4" style="text-align: left">
                                                            <asp:TextBox ID="lblagencycodeValue" runat="server" Enabled="false"  CssClass="form-control" ></asp:TextBox>
                                                        </div>
                                                        </div>
                                                         <div class="row rowspacing"  style="padding-left:20px;">
                                                        <div class="col-sm-4"style="text-align: left">
                                                            <asp:Label ID="lbldateissue" runat="server" Text="Date of Issue of Appointment" CssClass="control-label labelSize"
                                                                ></asp:Label>
                                                        </div>
                                                             <div id="trdos" class="col-sm-4" runat="server" style="text-align: left">
                                                            <asp:Label ID="lbldos" runat="server" CssClass="control-label labelSize" Text="Date of Submission"
                                                                ></asp:Label>
                                                        </div>
                                                             <div class="col-sm-4" style="text-align: left">
                                                            <asp:Label ID="lbldoa" runat="server" CssClass="control-label labelSize" Text="Date of Acceptance of Resignation"
                                                                ></asp:Label>
                                                        </div>
                                                        </div>
                                                         <div class="row"  style="padding-left:20px;" >
                                                        <div class="col-sm-4" style="margin-bottom: 5px;">
                                                            <asp:TextBox ID="lbldateissuevalue" runat="server" Enabled="false"  CssClass="form-control" ></asp:TextBox>
                                                        </div>
                                                        
                                                        <div class="col-sm-4" style="margin-bottom: 5px;">
                                                            <asp:TextBox ID="txtdos" runat="server" CssClass="form-control" Enabled="false" TabIndex="18" />
                                                        </div>
                                                        
                                                        <div class="col-sm-4" style="margin-bottom: 5px;">
                                                            <asp:TextBox ID="txtdoa" runat="server" CssClass="form-control" Enabled="false" TabIndex="12"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <%-- comended by usha --%>
                                                    <table visible="false">
                                                        <tr style="display: none">
                                                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblDate" runat="server" ></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblDate1" runat="server" ></asp:Label>
                                                            </td>
                                                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblSMName" runat="server" ></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblSMNameValue" runat="server" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%; height: 16px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblReqStatus" runat="server" ></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 16px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblReqStatusValue" runat="server" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 20%; height: 16px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" ></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 16px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblSponsorDtValue" runat="server" Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%; height: 38px; display: none" class="formcontent" align="left">
                                                                <span style="color: Red">
                                                                    <asp:Label ID="lblMobileNo" Text="Mobile No" runat="server" Style="color: Black"></asp:Label>*</span>
                                                            </td>
                                                            <td style="width: 30%; height: 38px; display: none" class="formcontent" align="left">
                                                                <asp:TextBox ID="txtmobilecode" runat="server" Text="91" CssClass="standardtextbox"
                                                                    Width="25px" Enabled="false" BackColor="#FFFFB2"></asp:TextBox>
                                                                <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" CssClass="standardtextbox"
                                                                    Width="155px" BackColor="#FFFFB2"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~`ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                                                    FilterMode="InvalidChars" TargetControlID="txtMobileNo" FilterType="Custom">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:Button ID="btnverifymobile" runat="server" Text="Verify" ValidationGroup="RecruitInfo"
                                                                    CssClass="standardbutton"></asp:Button>
                                                                <div id="divmob" class="Content" style="display: none">
                                                                    <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                                                    Loading...</div>
                                                                <br />
                                                                <asp:Label ID="lblmobileverify" runat="server"  Font-Size="X-Small"></asp:Label>
                                                            </td>
                                                            <td style="width: 20%; height: 38px; display: none" class="formcontent" align="left">
                                                                <span style="color: Red">
                                                                    <asp:Label ID="lblPAN" runat="server" Text="PAN No"  Style="color: Black"></asp:Label>*</span>
                                                            </td>
                                                            <td style="width: 30%; height: 38px; display: none" class="formcontent" align="left">
                                                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" CssClass="standardtextbox"
                                                                            onChange="javascript:this.value=this.value.toUpperCase();" BackColor="#FFFFB2"></asp:TextBox>
                                                                        <asp:Button ID="btnVerifyPAN" runat="server" Text="Verify" CssClass="standardbutton"
                                                                            ValidationGroup="RecruitInfo"></asp:Button>
                                                                        <div id="divPAN" class="Content" style="display: none">
                                                                            <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                                                            Loading...</div>
                                                                        <br />
                                                                        <asp:Label ID="lblPANMsg" runat="server"  Font-Size="X-Small"></asp:Label>
                                                                        <asp:HiddenField ID="hdnPanDtls" runat="server"></asp:HiddenField>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                                                <span style="color: Red">
                                                                    <asp:Label ID="lblEmail" runat="server" Text="Email" Style="color: Black"></asp:Label>*</span>
                                                            </td>
                                                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:TextBox ID="txtEMail" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"
                                                                    onblur="validateEmail1(this.value)"></asp:TextBox>
                                                                <asp:Button ID="btnverifyemail" runat="server" Text="Verify" ValidationGroup="RecruitInfo"
                                                                    CssClass="standardbutton"></asp:Button>
                                                                <div id="divEmail" class="Content" style="display: none">
                                                                    <img src="../../../App_Themes/Isys/images/spinner.gif" alt="Loading..." />
                                                                    Loading...</div>
                                                                <br />
                                                                <asp:Label ID="lblEmailMsg" runat="server"  Font-Size="X-Small"></asp:Label>
                                                            </td>
                                                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblpandetail" runat="server" Text="Is Pan name different from registered name"
                                                                    ></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:CheckBox ID="Chkpan" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trlicn" runat="server" visible="false">
                                                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblLicnno" runat="server" Text="License No" CssClass="standardlabel"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:TextBox ID="txtlicno" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                                <asp:Label ID="lbllicnoval" runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td style="width: 20%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:Label ID="lblLicExpDt" runat="server" Text="LicenseExpDate" CssClass="standardlabel"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%; height: 20px; display: none" class="formcontent" align="left">
                                                                <asp:TextBox ID="txtLicExpDt" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--   ended by usah--%>
                                                </div>
                                            <%--</div>--%>
                                            
                                            <div id="divNocrsn" runat="server" style="display:block">
                                    <div class="panelheadingAliginment" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divNOCdetails','Span2');return false;" > <%--style="margin-right:75px;margin-left:0px"--%>
                                                    <div class="row rowspacing" >
                                                        <div class="col-sm-10" style="text-align: left">
                                                            <asp:Label ID="reasonNOC" runat="server" Text="Reason for NOC" class="control-label HeaderColor"  ></asp:Label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <span id="Span2" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important;
                                                                font-size: 18px; color: #00cccc; "></span><%--left: 0px; height: 20px; width: 24px;--%>
                                                        </div>
                                                    </div>
                                                </div>
                                    <div id="divNOCdetails" runat="server" class="panel-body" style="display:block">
                                           <div class="row rowspacing"  style="padding-left:20px;" >
                                                        <div class="col-md-3" style="text-align: left" >
                                                            <asp:Label ID="lblselect" CssClass="control-label labelSize " runat="server" Text="Select the Reason for NOC"
                                                                ></asp:Label>
                                                            <span style="color: red">*</span>
                                                        </div>
                                                          <div class="col-md-3" style="text-align: left">
                                                            <asp:RadioButtonList ID="radioReason" AutoPostBack="true"  runat="server" RepeatDirection="Vertical"
                                                                OnSelectedIndexChanged="radioReason_SelectedIndexChanged">
                                                                <asp:ListItem Text="Surrender/Resignation" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Death" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                         </div>
                                           <div class="row rowspacing" style="padding-left:20px;" >
                                                            <div id="tdreasontext" runat="server" class="col-md-3" >
                                                            <%--<td id="tdreasontext" runat="server" style="width: 25%; height: 17px" class="formcontent" align="left">--%>
                                                            <asp:Label ID="lblreasontext" runat="server" Text="Remark of Reason for NOC" CssClass="control-label labelSize"
                                                                ></asp:Label>
                                                            <%--<span style="color: red">*</span>--%>
                                                        </div>
                                                              <div class="col-md-3">
                                                            <asp:TextBox ID="txtreasonleave" runat="server" Rows="4" TextMode="multiline" CssClass="form-control mandatory"></asp:TextBox>
                                                        </div>
                                                            </div>

                                    </div>
                               </div>
                           
                                        </div>
                        
                                <div id="trNote" visible="false" runat="server" class="card PanelInsideTab" style="margin-right:68px; margin-left:70px">
                                                <div class="panelheadingAliginment" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_div1','Span6');return false;"
                                                    style="">
                                                    <div class="row" >
                                                        <div class="col-sm-10" style="text-align: left">
                                                            <span class="">
                                                            </span>
                                                            <asp:Label ID="Label2" runat="server" Text="CONFIRMATION" Font-Bold="false" CssClass="control-label HeaderColor"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-2">
                                                            <span id="Span6" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important;
                                                                font-size: 18px;"></span> <%--color: #034ea2;--%>
                                                        </div>
                                                    </div>
                                                </div>
                                             
                                               <div id="div1" style="display: block;" runat="server" class="panel-body">
                                                    <div class="row" style="padding-left:20px;">
                                                        <div class="col-md-10">
                                                            <asp:Label ID="lblconfirm" CssClass="control-label labelSize" Text="Have you intimated Agent that your application for transfer to another General Insurance Company will be accepted by the new Insurer only after 90 days from the date of cessation (NOC) I-C certificate ?"
                                                                runat="server"></asp:Label>
                                                            <span style="color: red">*</span>
                                                        </div>
                                                        <div class="col-md-2" >
                                                            <asp:RadioButtonList ID="radioConfrm" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                                OnSelectedIndexChanged="radioConfrm_SelectedIndexChanged">
                                                                <asp:ListItem Value="3" Text=" Yes "></asp:ListItem> 
                                                                <asp:ListItem Value="4" Text=" No"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                    <div class="row" visible="false" runat="server">
                                                <div class="col-md-6" style="margin-bottom: 5px;">
                                                    <%--  <td style="width: 30%; height: 20px" class="formcontent" align="left">--%>
                                                    <asp:Label ID="lblremark" runat="server" Text="Remark of Insurer" CssClass="control-label"
                                                        ></asp:Label>
                                                    <%--</td>--%>
                                                </div>
                                                <div class="col-md-6" style="margin-bottom: 5px;">
                                                    <asp:TextBox ID="txtInsurer" runat="server" Rows="4" TextMode="multiline" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                <div id="divButton" runat="server">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="height: 20px" align="center" colspan="4">
                                                    <asp:Button ID="btnupd" runat="server" Width="120px" Style="display: none;" Text="Upload Documents"
                                                        CssClass="standardbutton" OnClick="btnupddoc" OnClientClick="StartProgressBar();">
                                                    </asp:Button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <table id="trnsfrtitle" runat="server" class="tableIsys table-condensed" style="width: 90%;
                                    display: none">
                                    <tr id="trtran" runat="server">
                                        <td colspan="4" class="test">
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblTransferDtl" Text="Transfer Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    <asp:Label ID="lblTrfrFlag" runat="server" Style="color: black" Text="Transfer Case"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    <asp:CheckBox ID="cbTrfrFlag" runat="server" CssClass="standardcheckbox" AutoPostBack="true"
                                                        TabIndex="19" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <table id="CompositeTitle" runat="server" class="tableIsys table-condensed" style="width: 90%;
                                    display: none">
                                    <tr id="chkcom" runat="server">
                                        <td colspan="4" class="test">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <%--<input runat="server" type="button" class="standardlink" value="+" id="btnCompositeDetails" style="width: 20px;"
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCompositeDetails','ctl00_ContentPlaceHolder1_btnCompositeDetails');" />--%>
                                                    <asp:Label ID="lblCompositeDtl" Text="Composite Details" runat="server" Font-Bold="true"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    <asp:Label ID="lblCompLcn" runat="server" Style="color: black" Text="Composite Case"></asp:Label>&nbsp
                                                    <asp:CheckBox ID="cbTccCompLcn" runat="server" CssClass="standardcheckbox" Enabled="true"
                                                        AutoPostBack="true" TabIndex="20" />
                                                    <%--     added by Nikhil for composite start--%>
                                                    <tr id="tr5" class="formcontent" runat="server">
                                                        <td>
                                                            <asp:Label ID="lblHasAgent" Text="Has the agent taken an acknowledgement on form I-B from the life Insurance Company  (Y/N)"
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="radioComposite" AutoPostBack="true" runat="server" RepeatDirection="Horizontal"
                                                                Enabled="True">
                                                                <asp:ListItem Value="0" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="No"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <table id="trIsPriorAgt" class="tableIsys" runat="server" style="height: 5%; width: 90%;
                                    display: none">
                                    <tr>
                                        <td align="left" colspan="4" class="test">
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkCompAgnt" runat="server" CssClass="standardcheckbox" Enabled="true"
                                                        TabIndex="21" AutoPostBack="true" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <table id="tblCndURN" runat="server" style="width: 90%; display: none" visible="false">
                                            <tr>
                                                <td class="test" colspan="4" style="text-align: left;">
                                                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                        <ContentTemplate>
                                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="BtnCndTrnsDtls"
                                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCndTrnsDtls', 'ctl00_ContentPlaceHolder1_BtnCndTrnsDtls');" />
                                                            <asp:Label ID="lbltitleURN" runat="server" Font-Bold="True" Text="Candidate URN No."></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divCndTrnsDtls" runat="server">
                                            <table id="tblCndURNDtl" runat="server" style="width: 90%; display: block; display: none">
                                                <tr>
                                                    <td align="left" class="formcontent">
                                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                            <ContentTemplate>
                                                                <span style="color: red">
                                                                    <asp:Label ID="lblcndURNNo" Text="Candidate URN No." runat="server" Style="color: black"></asp:Label>*</span>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td class="formcontent" style="width: 30%;">
                                                        <asp:UpdatePanel ID="UpdatePanel171" runat="server">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="txtCndURNNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                                <asp:Label ID="lblcndURNVal" runat="server" Style="color: Black" Visible="false"></asp:Label>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="chkCompAgnt" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left" class="formcontent" style="width: 20%; display: none;">
                                                        <asp:Label ID="lblTrnsfrReqNo" Text="IRDA Transfer Request No." runat="server" Style="color: black"></asp:Label>
                                                    </td>
                                                    <td class="formcontent" style="width: 30%; display: none;">
                                                        <asp:TextBox ID="TxtTrnsfrReqNo" runat="server" CssClass="standardtextbox" BackColor="#FFFFB2"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%-- added by shreela on 18-04-2014 for Renewal Details start--%>
                                <table id="tblRenewalCollapse" style="width: 90%; display: none" class="formtable table-condensed"
                                    runat="server" visible="false">
                                    <tr>
                                        <td colspan="4" align="left" class="test">
                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnRenew"
                                                style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRenewal', 'ctl00_ContentPlaceHolder1_btnRenew');" />
                                            <asp:Label ID="lblRenew" runat="server" Text="Renewal Details" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="updrenewal" runat="server">
                                    <ContentTemplate>
                                        <div id="divRenewal" runat="server" visible="false" style="display: none">
                                            <table id="tblRenewal" style="width: 90%; display: none" class="tableIsys" runat="server">
                                                <tr>
                                                    <td align="left" colspan="4" class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblCndType" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                    <td id="Td1" runat="server" class="formcontent" style="width: 30%;">
                                                        <asp:Label ID="lblCndVal" runat="server"></asp:Label>
                                                    </td>
                                                    <td id="Td2" runat="server" class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblCount" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                    <td id="Td3" runat="server" class="formcontent" style="width: 30%;">
                                                        <asp:Label ID="lblCountVal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="Comp" runat="server" style="display: none;">
                                                    <td id="Td4" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                                        <span style="color: Red">
                                                            <asp:Label ID="lblRenewType" runat="server" Style="color: Black"></asp:Label>*</span>
                                                    </td>
                                                    <td id="Td5" runat="server" class="formcontent">
                                                        <asp:DropDownList ID="ddlRenewType" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                                            Width="210px" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td id="Td6" runat="server" class="formcontent" style="width: 20%;">
                                                        <span style="color: Red">
                                                            <asp:Label ID="lbllyfTraining" runat="server" Style="color: Black"></asp:Label>*</span>
                                                    </td>
                                                    <td id="Td7" runat="server" class="formcontent">
                                                        <asp:DropDownList ID="ddllyfTraining" runat="server" CssClass="standardmenu" BackColor="#FFFFB2"
                                                            Width="210px" Enabled="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <%--Added by kalyani to fetch Renewal record on QC module start--%>
                                                <tr id="trCompQC" runat="server" visible="false">
                                                    <td id="Td8" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                                        <span style="color: Red">
                                                            <asp:Label ID="lblQCRenewType" runat="server" Style="color: Black"></asp:Label></span>
                                                    </td>
                                                    <td id="Td9" runat="server" class="formcontent">
                                                        <asp:Label ID="lbltxtQCRenewType" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                    <td id="Td10" runat="server" class="formcontent" style="width: 20%;">
                                                        <span style="color: Red">
                                                            <asp:Label ID="lblQClyfTraining" runat="server" Style="color: Black"></asp:Label></span>
                                                    </td>
                                                    <td id="Td11" runat="server" class="formcontent">
                                                        <asp:Label ID="lbltxtQClyfTraining" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%--Added by kalyani to fetch Renewal record on QC module end--%>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table id="TblRptrTitle" style="width: 90%; display: none" class="formtable table-condensed"
                                    runat="server" visible="false">
                                    <tr>
                                        <td colspan="4" align="left" class="test">
                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="btnRptr"
                                                style="width: 20px;" onclick="ShowReqDtlRenew('ctl00_ContentPlaceHolder1_divRptr', 'ctl00_ContentPlaceHolder1_btnRptr');" />
                                            <asp:Label ID="TblRptrDtls" runat="server" Text="Repeater Details" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                    <ContentTemplate>
                                        <div id="divRptr" runat="server" style="display: none">
                                            <table id="tblRptr" style="width: 90%; display: none" class="tableIsys" runat="server">
                                                <tr>
                                                    <td align="left" colspan="4" class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblRptrCndTyp" Text="Candidate Type" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                    <td id="Td12" runat="server" class="formcontent" style="width: 30%;">
                                                        <asp:Label ID="lblRptrCndTypVal" runat="server"></asp:Label>
                                                    </td>
                                                    <td id="Td13" runat="server" class="formcontent" style="width: 20%;">
                                                        <asp:Label ID="lblRptrCount" Text="ReExam Count" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                    <td id="Td15" runat="server" class="formcontent" style="width: 30%;">
                                                        <asp:Label ID="lblRptrCountVal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="tr4" runat="server">
                                                    <td id="Td22" align="left" colspan="4" runat="server" class="formcontent" style="width: 20%;">
                                                        <span style="color: Red">
                                                            <asp:Label ID="lblRptrTyp" Text="ReExam Type" runat="server" Style="color: Black"></asp:Label></span>
                                                    </td>
                                                    <td id="Td23" runat="server" class="formcontent">
                                                        <asp:Label ID="lblRptrTypVal" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                    <td id="Td24" runat="server" class="formcontent" style="width: 20%;">
                                                        <span style="color: Red">
                                                            <asp:Label ID="Label17" runat="server" Style="color: Black"></asp:Label></span>
                                                    </td>
                                                    <td id="Td25" runat="server" class="formcontent">
                                                        <asp:Label ID="Label18" runat="server" Style="color: Black"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table id="tbloldlic" runat="server" style="width: 90%; display: none" class="tableIsys"
                                    visible="false">
                                    <tr>
                                        <td id="tdoldlic" class="test" runat="server" colspan="4">
                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnOldLicDtls"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divoldlic', 'ctl00_ContentPlaceHolder1_BtnOldLicDtls');" />
                                            <asp:Label ID="lbloldlic" runat="server" Text="Old License Details" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divoldlic" runat="server" style="display: none" visible="false">
                                    <table id="tbloldlicdtls" runat="server" class="tableIsys" style="width: 90%; display: none">
                                        <tr>
                                            <td align="left" class="formcontent" style="width: 20%">
                                                <asp:Label ID="lbloldlicno" Text="License No" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                                <asp:Label ID="lbloldlicnoval" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" class="formcontent" style="width: 20%">
                                                <asp:Label ID="lbloldexpdate" Text="Old LicenseExpDate" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                                <asp:Label ID="lbloldexpdateval" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%">
                                                <asp:Label ID="lbloldlicissu" Text="Old License Issue Date" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                                <asp:Label ID="lbloldlicissuval" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 20%">
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table id="tblnewlic" runat="server" style="width: 90%; display: none" class="tableIsys"
                                    visible="false">
                                    <tr>
                                        <td id="tdnewlic" class="test" runat="server" colspan="4">
                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="+" id="BtnNewLicDtls"
                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divnewlic', 'ctl00_ContentPlaceHolder1_BtnNewLicDtls');" />
                                            <asp:Label ID="lblnewlic" runat="server" Text="New License Details" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divnewlic" runat="server" style="display: none" visible="false">
                                    <table id="tblnewlicdtls" runat="server" class="tableIsys" style="width: 90%; display: none">
                                        <tr>
                                            <td align="left" class="formcontent" style="width: 20%">
                                                <asp:Label ID="lblnewlicno" Text="License No" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                                <asp:Label ID="lblnewlicnoval" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" class="formcontent" style="width: 20%">
                                                <asp:Label ID="lblnewexpdate" Text="LicenseExpDate" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                                <asp:TextBox ID="txtnewexpdate" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtnewexpdate"
                                                    PopupButtonID="btnCalendar" Format="dd/MM/yyyy" Enabled="false" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="txtnewexpdate" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Invalid date!"
                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewexpdate" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtnewexpdate"
                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                                <%--  <asp:Label ID="Label8" runat="server"></asp:Label>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formcontent" style="width: 20%">
                                                <asp:Label ID="lblnewlicissu" Text="License Issue Date" runat="server"></asp:Label>
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                                <asp:TextBox ID="txtnewlicissu" runat="server" CssClass="standardtextbox"></asp:TextBox>
                                                <asp:Image ID="btnCalenderissu" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtnewlicissu"
                                                    PopupButtonID="btnCalenderissu" Format="dd/MM/yyyy" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="txtnewlicissu" Enabled="false" ErrorMessage="Mandatory!" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Invalid date!"
                                                    Operator="DataTypeCheck" Type="Date" ControlToValidate="txtnewlicissu" Display="Dynamic"></asp:CompareValidator>&nbsp;
                                                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtnewlicissu"
                                                    Display="Dynamic" ErrorMessage="Date out of range!" MaximumValue="2099-01-01"
                                                    MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator>
                                            </td>
                                            <td class="formcontent" style="width: 20%">
                                            </td>
                                            <td class="formcontent" style="width: 30%">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <div id="tblCFRInboxCollapse" runat="server" class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_Div5','Span3');"
                                    style="background-color: #EDF1cc !important;">
                                    <div class="row" style="margin-left: -68%;">
                                        <div class="col-sm-10">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="margin-right: 5px; color: Orange;">
                                            </span>
                                            <asp:Label ID="lblhead" runat="server"  Text="Raised CFR's" Height="14px"
                                                Font-Size="Small"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="Span3" class="glyphicon glyphicon-resize-full" style="float: right; padding: 1px 10px ! important;
                                                font-size: 18px; color: Orange;"></span>
                                        </div>
                                    </div>
                                </div>
                         
                                <div id="divCFRInbox" runat="server" style="display: block">
                                    <div id="tblCFRInbox" runat="server">
                                        <div class="row" id="Div4" runat="server">
                   
                                            <div class="col-sm-12" style="margin-bottom: 5px; height: 14px; width: 1082px;">
                                                <asp:Label ID="lblcfrraised" runat="server" Text="Raised CFR" CssClass="control-label"></asp:Label>&nbsp;
                                                <asp:Label ID="lblcfrraisedcount" runat="server" CssClass="control-label"></asp:Label>&nbsp;
                                                <asp:Label ID="lblresponded" runat="server" Text="Responded CFR" CssClass="control-label"></asp:Label>
                                                <asp:Label ID="lblcfrrespondedcount" runat="server" CssClass="control-label"></asp:Label>&nbsp;
                                            </div>
                                        </div>
                                        <div id="Div5" runat="server"  class="panel-body"  style="overflow:auto;display:block;">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="dgDetailsInbox" runat="server" CssClass="footable" AutoGenerateColumns="False"
                                                        AllowPaging="True" Width="100%" OnRowCommand="dgDetailsInbox_RowCommand" OnPageIndexChanging="dgDetailsInbox_PageIndexChanging"
                                                        PageSize="5" OnRowDataBound="dgDetailsInbox_RowDataBound">
                                                       <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                        <HeaderStyle CssClass="gridview th" />
                                   <PagerStyle CssClass="disablepage" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkAssigned" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle Wrap="False" CssClass="pad"></HeaderStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="CFR Remark" HeaderText="CFR Remarks">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemarks") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" ></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="CFRFor" HeaderText="CFR Raised For">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcfr" runat="server" Text='<%# Eval("CFRFor") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle />
                                                                <ItemStyle HorizontalAlign="left" ></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="RemarkId" HeaderText="" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRemarkid" runat="server" Text='<%# Eval("RemarkId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" ></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="Responded" HeaderText="Responded">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Responded" runat="server" Text='<%# Eval("Responded") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" ></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Responded" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCFRRemarkID" runat="server" Text='<%# Eval("CFRRemarkID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" ></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRaisedFlag" runat="server" Text='<%# Eval("RaisedFlag") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" ></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCFRDocCode" runat="server" Text='<%# Eval("DocCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCFRFlagType" runat="server" Text='<%# Eval("CFRFlagType") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkReopen" Style="text-align: center;" runat="server" Text="ReOpen CFR"
                                                                        CommandArgument='<%# Eval("RemarkId") %>' CommandName="ReopenCFR" Visible="false"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAddnlRemark" runat="server" Text='<%# Eval("AddnlRemark") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="pad" />
                                                                <ItemStyle HorizontalAlign="left" Font-Bold="False"></ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <%-- <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                            <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                            </RowStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>--%>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <%-- <tr>
                <td id="Td14" runat="server" align="left" class="test" Visible="false" colspan="4">
                <asp:Label ID="lblTitleRemarks" Visible="false" runat="server" Text="Remarks" Font-Bold="true"></asp:Label>
                </td>
                </tr>--%>
                                        <%-- <tr>
                    <td>--%>
                                        <div id="Div6" runat="server" class="panel-body"  style="overflow:auto;">
                                            <asp:GridView ID="GridRemarks" runat="server" RowStyle-CssClass="tableIsys" HorizontalAlign="Left"
                                                AutoGenerateColumns="False" AllowPaging="True" Width="100%" PageSize="5" CssClass="footable">
                                                <FooterStyle CssClass="GridViewFooter" />
                                                <RowStyle CssClass="GridViewRow" />
                                                <%--<PagerStyle CssClass="GridViewPager"></PagerStyle>--%>
                                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                                <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                                                <Columns>
                                                    <asp:TemplateField SortExpression="Date" HeaderText="Date" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle />
                                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField SortExpression="CFRRemark" HeaderText="Remarks" ItemStyle-Width="70%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblRemark" runat="server" Text='<%# Eval("CFRRemark") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle />
                                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <%--<HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true" />
                            <PagerStyle HorizontalAlign="Left" Font-Underline="True" ForeColor="Black"></PagerStyle>
                            <RowStyle CssClass="sublinkodd" HorizontalAlign="Left" ForeColor="Black" Font-Size="Small">
                            </RowStyle>
                            <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>    --%>
                                            </asp:GridView>
                                        </div>
                                        <%-- </td>
                    </tr>--%>
                                        <div id="trRespond" runat="server" visible="false" class="row" style="margin-top: 12px;">
                                            <div class="col-sm-12" align="center">
                                                <%-- <tr id="trRespond" runat="server" visible="false">
                    <td align="center">--%>
                                                <asp:LinkButton ID="btnRespond" Visible="false" CssClass="btn btn-primary" runat="server">
                                 <span class="glyphicon glyphicon-share-alt"> </span> Respond
                                                </asp:LinkButton>
                                                <%--<asp:Button ID="btnCloseCfr" runat="server" Text="Respond" CssClass="standardbutton"
                            Width="84px" Visible="false"></asp:Button>--%>
                                                <asp:LinkButton ID="btnCloseCfr" CssClass="btn btn-primary" runat="server">
                                 <span class="glyphicon glyphicon-ban-circle"> </span> Close CFR
                                                </asp:LinkButton>
                                                <%-- <asp:Button ID="btnCloseCfr" runat="server" Text="Close CFR" CssClass="standardbutton"
                            Width="114px" ></asp:Button>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               
                                <div id="trdgview" class="card PanelInsideTab" runat="server" visible="false" style="margin-top:-43px;margin-right:68px;margin-left:70px" >
                               
                                      <div id="Div7" runat="server" class="panel-heading subheader" style="" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_trdgview1','Span4');"> <%--onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_trdgview1','Span4');"--%>
                                        <div class="row" id="trDetails" runat="server">
                                            <div class="col-sm-3" style="text-align:left">
                                                <span class="">
                                                </span>
                                                <asp:Label ID="lblCanddoc" runat="server" Text="Candidate Document Upload" style="font-size:17px;" 
                                                 class=" control-label HeaderColor"  ></asp:Label>  <%--Font-Bold="True"--%>
                                               </div>
                                                <div class="col-sm-5" style="text-align:center">
                                                <asp:Label ID="txtcolr" runat="server" CssClass="control-label" Width="20px" Height="12px"
                                                    ></asp:Label>
                                                <asp:Label ID="LinkButton1" runat="server" Text="Mandatory Documents" Visible="false">
                                                </asp:Label>&nbsp;&nbsp;&nbsp;
                                            </div>
                                            <div class="col-sm-4">
                                    <span id="Span4" class="glyphicon glyphicon-chevron-up" style="float: right;
                                         padding: 1px 10px ! important; font-size: 18px;"></span> <%--color: #034ea2;--%>
                                </div>
                                      
                                          </div> 
                                             </div>
                                    <%--</table>--%>
                                    <%--   worked with usha for bootstrap--%>
                                    <ajaxToolkit:ModalPopupExtender ID="mdlcfrdtls" runat="server" BehaviorID="mdlcfrdtlsID"
                                        DropShadow="false" TargetControlID="buttonNull" PopupControlID="pnlcfrdtls" BackgroundCssClass="modalPopupBg">
                                    </ajaxToolkit:ModalPopupExtender>
                                    <asp:Button ID="buttonNull" runat="server" Style="display: none" />
                                    <asp:Panel runat="server" ID="pnlcfrdtls" Style="display: block; width: 30%; height: 50%">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                            <ContentTemplate>
                                                <table class="tableIsys" align="center" style="width: 40%;">
                                                    <tr id="trdgDetails" runat="server">
                                                        <td class="formcontent" colspan="3" style="height: 40px">
                                                            <asp:GridView ID="dgDetails1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                                                Width="450px" RowStyle-CssClass="tableIsys" AllowSorting="True">
                                                                <%--OnRowDataBound="dgDetails_RowDataBound"OnSorting="dgDetails_Sorting" --%>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Seq No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SeqNo") %>' Visible="true" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mandatory Documents">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblManDoc" runat="server" Text='<%# Bind("ImgDesc01") %>' Visible="true" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EditRowStyle Font-Names="verdana" />
                                                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                                <RowStyle CssClass="sublinkodd" HorizontalAlign="Center"></RowStyle>
                                                                <HeaderStyle CssClass="portlet blue" Font-Bold="true" ForeColor="White" />
                                                                <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <%--align="center">--%>
                                                            <%--<div class="btn btn-xs btn-primary" style="width: 90px;">
                                    <i class="fa fa-times"></i>--%>
                                                            <asp:Button ID="btnpopcancel" runat="server" CssClass="standardbutton" Text="Cancel" />
                                                            <%--</div>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnpopcancel" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                    <%--     bootstrap for document upload usha --%>
                                      <div id="tblupload" runat="server">
                                    <div id="trupload" runat="server" class="col-sm-12" style="margin-bottom: 5px;">
                                        <asp:Label ID="lblNote" runat="server" Text="NOTE: All Documents to be Uploaded/Reuploaded should be in JPEG/JPG/GIF format"
                                            ForeColor="Red" Style="margin-left: 286px;font-size: 14px;"></asp:Label>
                                    </div>
                                </div>
                                    <div id="trdgview1" runat="server" style="display: block; overflow:auto;">
                                        <%-- <div id="trdgview" runat="server" visible="false" class="panel-body" style="display: block;">--%>
                                        <%--   <table id="trdgview" runat="server" visible="false" class="tableIsys" align="center" style="width: 90%;">
                <tr>
                    <td>--%>
                                        <%--//pranjali start--%>
                                        <asp:UpdatePanel ID="upddgView" runat="server">
                                            <ContentTemplate>
                                               
                                                <asp:GridView ID="dgView"  runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                                                    AllowSorting="True" PageSize="20" OnPageIndexChanging="dgView_PageIndexChanging"
                                                    OnRowCommand="dgView_RowCommand" OnRowDataBound="dgView_RowDataBound" CssClass="footable"><%-- class ="card"--%>
                                                    <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                      <HeaderStyle CssClass="gridview th" />
                                      <PagerStyle CssClass="disablepage" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="175px" HeaderStyle-HorizontalAlign="Center">
                                                            <%--<ControlStyle CssClass="pad" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldocName" runat="server" Font-Size="13px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
                                                                <%--<span style="color: red">*</span>--%>
                                                                <asp:Label ID="MandocName" runat="server" Font-Size="13px" Text="*" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />
                                                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                                                            <ControlStyle CssClass="pad" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldocDescription" runat="server" Font-Size="13px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />
                                                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <%--added by pranjali on 03-03-2014 start--%>
                                                        <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                                            <ControlStyle CssClass="pad" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblupdSize" runat="server" Font-Size="13px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />
                                                        </asp:TemplateField>
                                                        <%--added by pranjali on 03-03-2014 end--%>
                                                        <asp:TemplateField HeaderText="Upload Documents" HeaderStyle-HorizontalAlign="Center">
                                                            <ControlStyle CssClass="pad" />
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                    <ContentTemplate>
                                                        <asp:FileUpload ID="FileUpload" runat="server" Width="340px" Font-Size="13px"></asp:FileUpload>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                             <ItemStyle HorizontalAlign="center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                            <ControlStyle CssClass="pad" />
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                                    <ContentTemplate>
                                                                   
                                                                        <asp:LinkButton ID="btn_Upload" runat="server" CssClass="standardlabel" Text="Upload"
                                                                            Enabled="false" Visible="false" Width="80px" OnClick="btn_Upload_Click" >
                                                                             
                                                                             </asp:LinkButton>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btn_Upload" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                                    <ContentTemplate>
                                                                    
                                                                        <asp:LinkButton 
                                                                      ID="btn_ReUpload" runat="server" CssClass="standardlabel" Text="ReUpload"
                                                                            Width="80px" OnClick="btn_ReUpload_Click" >
                                                                            
                                                                             </asp:LinkButton>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />  
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("DocCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkPreview" CssClass="standardlabel" runat="server" Text="Preview"
                                                                    CommandArgument='<%# Eval("DocCode") %>' CommandName="Preview" Font-Size="14px"
                                                                    Style="text-transform: capitalize;">
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="checkedchanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                     
                              <%--  </div>--%>
                                <%--     bootstrap for document upload usha --%>
                                <table class="formtable table-condensed" id="Table1" runat="server" style="width: 90%;
                                    display: none;">
                                    <tr id="tr_DocumentReuploadTitle" runat="server" visible="false">
                                        <%--pranjali--%>
                                        <td class="test" colspan="3" style="text-align: left;">
                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" visible="false"
                                                id="Button11" style="width: 20px;" onclick="funShowReqDtl('ctl00_ContentPlaceHolder1_divReUploadFiles', 'ctl00_ContentPlaceHolder1_BtnReUpload');" />
                                            <%--<asp:Label ID="lblcndupload" runat="server" Font-Bold="True" Text=""></asp:Label>--%>
                                            <asp:Label ID="lblcndupload" runat="server" Font-Bold="True"></asp:Label>
                                            <%--  Candidate Document Re-Upload--%>
                                        </td>
                                    </tr>
                                </table>
                                <div id="div2" runat="server" style="display: block;">
                                    <table class="tableIsys" align="center" style="width: 90%; display: none;">
                                        <tr id="tr_reupload" runat="server" visible="false">
                                            <td>
                                                <%--//pranjali start--%>
                                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CssClass="tableIsys"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging" PagerStyle-HorizontalAlign="Center"
                                                    PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                                    OnRowDataBound="GridView1_RowDataBound" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                    AllowPaging="True" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="210px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldocName" runat="server" Text='<%#Bind("DocType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Upload By" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUpldBy" runat="server" Text='<%#Bind("UploadedBy") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Uploaded Dt" HeaderStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUpdDtTm" runat="server" Text='<%#Bind("UploadedDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileName" runat="server" Text='<%#Bind("ServerFileName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <%--added by pranjali on 03-03-2014 start--%>
                                                        <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />
                                                        </asp:TemplateField>
                                                        <%--added by pranjali on 03-03-2014 end--%>
                                                        <asp:TemplateField HeaderText="Reupload Documents" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:FileUpload ID="FileReUpload" runat="server" Width="340px" Filebytes='<%# Bind("UserFileName") %>'>
                                                                </asp:FileUpload>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgsize1" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("maximgsize") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgshrt1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgwidth1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblimgheight1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldoccode1" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                                    Text='<%#Bind("DocCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                                    <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                    </PagerStyle>
                                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                                    <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divnavigate" runat="server">
                                    <table id="tblphoto" runat="server" style="width: 90%;">
                                        <tr>
                                            <td class="formcontent" colspan="2">
                                                <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCrop" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                                                <asp:Button ID="Btncrop" TabIndex="43" runat="server" Text="CROP" CssClass="standardbutton"
                                                    Width="80" Visible="false"></asp:Button>
                                                <%--</div>--%>
                                                <%--<div class="btn btn-xs btn-primary" style="width: 110px;" id="divCFR" runat="server" visible="false">
                            <i class="fa fa-crop"></i>--%>
                                                <asp:Button ID="BtnCFR" TabIndex="43" OnClick="btnCFR_Click" runat="server" Text="Raise CFR"
                                                    CssClass="standardbutton" Width="80px" Visible="false"></asp:Button><%--</div>--%>
                                            </td>
                                            <td align="left" class="style2" colspan="2">
                                                <asp:Label ID="lblcfrrais1" runat="server" Text="Raised CFR:" CssClass="standardlink "></asp:Label>&nbsp;
                                                <asp:Label ID="lblcfrrais1count" runat="server" CssClass="standardlink" Style="color: Red;"></asp:Label><br />
                                            </td>
                                            <td align="left" class="formcontent" colspan="2">
                                                <asp:Label ID="lblrespond" runat="server" Text="Responded CFR:" CssClass="standardlink"></asp:Label>&nbsp;
                                                <asp:Label ID="lblcfrrespondcount" runat="server" CssClass="standardlink" Style="color: Orange;"></asp:Label><br />
                                            </td>
                                            <td align="left" class="formcontent" colspan="2">
                                                <asp:Label ID="lblclosed" runat="server" Text="Closed CFR:" CssClass="standardlink"></asp:Label>&nbsp;
                                                <asp:Label ID="lblcfrclosed" runat="server" CssClass="standardlink" Style="color: Green;"></asp:Label><br />
                                            </td>
                                            <%--Added by pranjali on 25-022014 for displaying cfr raised end--%>
                                            <td class="formcontent3">
                                                <asp:UpdatePanel runat="server" ID="upnlPrev">
                                                    <ContentTemplate>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnprev" runat="server" Text="Prev" CssClass="standardbutton" Width="80" Visible="true">
                                                        </asp:Button><%--</div>--%>
                                                        &nbsp;&nbsp;
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="formcontent">
                                                <asp:UpdatePanel runat="server" ID="upnlNext">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="standardbutton" Width="80" Visible="true">
                                                        </asp:Button>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--Added by rachana on 29-07-2013 for addition of panel showing documents end--%>
                                <asp:Panel ID="Panelphoto2" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                                    BorderWidth="2px" Width="89%" Visible="true" class="modalpopupmesg" ScrollBars="Vertical">
                                    <asp:UpdatePanel runat="server" ID="upnlHeader">
                                        <ContentTemplate>
                                            <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                                                <tr>
                                                    <td align="center" >
                                                        <asp:Label ID="lblpanelheader" runat="server" CssClass="standardlink "  />
                                                        <asp:HiddenField ID="hdnDocId" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="modalpanel" style="display: none">
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="imgCrop" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divgrid" runat="server" style="width: 100%; height: 100%; overflow: hidden">
                                                <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;
                                                    width: 100%;" class="tableIsys">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="tableIsys"
                                                                PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                                                RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                                AllowPaging="True" Width="100%" Height="242px">
                                                                <Columns>
                                                                    <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImageCSharp.aspx?ImageID={0}"
                                                                        HeaderText="Preview Image">
                                                                        <%--ItemStyle-Height="100%" ItemStyle-Width="100%"--%>
                                                                    </asp:ImageField>
                                                                </Columns>
                                                                <RowStyle CssClass="sublinkeven" BackColor="#78A8FA"></RowStyle>
                                                                <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                                </PagerStyle>
                                                                <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                                                <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <iframe id="FrmImg" runat="server" visible="false" width="100%" height="500px"></iframe>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnnext" EventName="Click"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                                <div id="trunder" runat="server">
                                    <div class="col-sm-12">
                                        <asp:Label ID="Label8" runat="server" Text="NOTE: Declaration cum affidavit is mandatory if Appointment Letter and/or ID Card is unavailable."
                                            ForeColor="red" Style="margin-left: 286px;font-size: 14px;"></asp:Label>
                                    </div>
                                </div>
                                <div id="divButtons" runat="server">
                                    <div class="col-sm-12" align="center">
                                        <%-- <table>
                <tbody>
                    <tr>--%>
                                        <%--<asp:Button ID="btnSubmit"  runat="server" Text="Submit" onClick="btnSubmit_Click"
                                CssClass="standardbutton" Width="80px" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;&nbsp;--%>
                                       
                                        <%--<asp:Button ID="btnSave"  runat="server" Text="Save" CssClass="standardbutton"
                                Width="80px"  OnClientClick="StartProgressBar();"></asp:Button>--%>
                                        <asp:LinkButton ID="btnSave" OnClientClick="StartProgressBar();" CssClass="btn btn-primary"
                                            runat="server">
                                 <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"> </span> Save
                                        </asp:LinkButton>
                                        <%--<asp:Button ID="BtnApprove"  runat="server" Text="Approve"
                                CssClass="standardbutton" Width="80px" Visible="false" OnClientClick="StartProgressBar();"></asp:Button>
                                        --%>
                                        <asp:LinkButton ID="BtnApprove" Visible="false" OnClientClick="StartProgressBar();"
                                            CssClass="btn btn-primary" runat="server">
                                 <span class="glyphicon glyphicon-ok-circle"> </span> Approve
                                        </asp:LinkButton>
                                        <%-- <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="standardbutton"
                                 Width="114"  OnClientClick="StartProgressBar();" />--%>
                                        <asp:LinkButton ID="btnReject" OnClientClick="StartProgressBar();" CssClass="btn btn-primary"
                                            runat="server">
                                 <span class="glyphicon glyphicon-remove-circle"> </span> Reject
                                        </asp:LinkButton>
                                        <%-- <asp:Button ID="btnClear" TabIndex="43" OnClick="btnClear_Click" runat="server" Text="Cancel"
                                CssClass="standardbutton" Width="80px" ></asp:Button>--%>
                                        
                                        <%--<asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" Width="80px" Text="Cancel" Visible="false" OnClientClick="CloseSub()" />--%>
                                        <asp:LinkButton ID="btnCancel" Visible="false" OnClientClick="CloseSub()" CssClass="btn btn-primary"
                                            runat="server">
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnCroprefresh" runat="server" CssClass="btn btn-primary" Style="display: none;"
                                            ClientIDMode="Static" />
                                        <asp:LinkButton ID="btnReOpenReFresh" runat="server" CssClass="btn btn-primary" Style="display: none;"
                                            ClientIDMode="Static" />

                                        <div id="divloader" runat="server" style="display: none;">
                                            &nbsp;&nbsp;
                                            <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                            Loading...
                                        </div>
                                        <%--  </tr>
                </tbody>
            </table>--%>
                                    </div>
                                </div>

                              
                                </div>
                      <div id="Divbtn" style="margin-left:600px;">
                          <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-success" runat="server">
                                <span class="glyphicon glyphicon-remove" style="color:White" visible="false"> </span> CANCEL </asp:LinkButton>
                                 <asp:LinkButton ID="btnPrev1" runat="server" Text="PREVIOUS"  CssClass="btn btn-success" visible="false" OnClick="btnPrev1_Click">
                                     <span class="glyphicon glyphicon-arrow-left BtnGlyphicon" style="color:White"></span> PREVIOUS
                                        </asp:LinkButton>
<%--                             <asp:Button ID="btnPrev1" runat="server" Text="PREVIOUS" CssClass="btn btn-success"  class="glyphicon glyphicon-arrow-left BtnGlyphicon" OnClick="btnPrev1_Click"  />--%>
<%--                             <asp:Button ID="btnNextPannel1" runat="server" Text="NEXT" CssClass="btn btn-success" class="glyphicon glyphicon-arrow-right BtnGlyphicon" OnClick="btnNextPannel1_Click" 
                              OnClientClick ="StartProgressBar();"/> <%-- Visible="true"--%>
                             <asp:LinkButton ID="btnSubmit" OnClick="btnSubmit_Click" OnClientClick="StartProgressBar();" CssClass="btn btn-success" runat="server">
                                 <span class=" glyphicon glyphicon-saved"  style="color:White" visible="false"> </span> SUBMIT </asp:LinkButton>
                          <asp:LinkButton ID="btnNextPannel1" runat="server" Text="NEXT" CssClass="btn btn-success" OnClick="btnNextPannel1_Click" Visible="true" OnClientClick ="StartProgressBar();">
                                     NEXT <span class="glyphicon glyphicon-arrow-right BtnGlyphicon" style="color:White"></span>                                         
                                        </asp:LinkButton>
                             
                           </div>
                    
                   <%-- </asp:Panel>--%>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
   
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdnBranchCode" runat="server" />
                <asp:HiddenField ID="hdnflag" runat="server" />
                <asp:HiddenField ID="hdnDocCode" runat="server" />
                <%--//Added by rachana on 02-01-2014 for confirmation of approval--%>
                <asp:HiddenField ID="hdnDoctype" runat="server" />
                <asp:HiddenField ID="hdnprevcount" runat="server" />
                <asp:HiddenField ID="hdnCandTypeRen" runat="server" />
                <asp:HiddenField ID="hdnInsRenType" runat="server" />
                <asp:HiddenField ID="hdncompinsren" runat="server" />
                <%--shree--%>
                <asp:HiddenField ID="hdnrenwlflag" runat="server" />
                <%--shree--%>
            </td>
            <td>
                <asp:HiddenField ID="hdnStartDate" runat="server" />
                <asp:HiddenField ID="hdnRenwlCnt" runat="server" />
                <asp:HiddenField ID="hdnRenwl" runat="server" />
            </td>
            <td>
                <input type="hidden" runat="server" id="hdnUserId" />
            </td>
            <td>
                <asp:HiddenField ID="hdnBizSrc" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnTrnLoc" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnTrnInst" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnAgnPhoto" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnAgnSign" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnTccID" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnAppNo" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnCndNo" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnSDate" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnStateCode" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnAgnCode" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnbtnVerify" runat="server" />
                <asp:HiddenField ID="hdnbtnemailVerify" runat="server" />
                <asp:HiddenField ID="hdnMobileVerify" runat="server" />
            </td>
            <!-- Added by ank 12.01.2011-->
            <td>
                <asp:HiddenField ID="hdnWebTkn" runat="server" />
            </td>
            <!-- Added by Darshik 01.02.2013-->
            <td>
                <asp:HiddenField ID="hdnWebTknCon" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnEntryDate" runat="server" />
            </td>
            <asp:UpdatePanel ID="updPnlHidden" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hdnPan" runat="server" />
                    <asp:HiddenField ID="hdnEmail" runat="server" />
                    <asp:HiddenField ID="hdnMobile" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <td>
                <asp:HiddenField ID="hdnCanid" runat="server" />
                <asp:HiddenField ID="hdnpath" runat="server" />
                <asp:Button Text="btnok" ID="btnopen" runat="server" Visible="false" />
            </td>
        </tr>
    </table>
   <%-- </div> </div> </center> </asp:Panel> </div>--%>
    <%--miti..for Raise CFR...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCFR" Width="700" display="none">
        <iframe runat="server" id="IframeRaiseCFR" width="700" height="450px" frameborder="0"
            display="none" style="background-color: White;"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="Label1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCFR" BehaviorID="MdlPopRaiseCFR"
        DropShadow="true" TargetControlID="Label1" PopupControlID="PnlRaiseCFR" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--miti..for Raise CFR...end--%>
    <%-- //Ibrahim--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
        <iframe runat="server" id="ifrmMdlPopup" width="400" height="300px" frameborder="0"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>




    
      <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
            <asp:Label ID="lblpopup" runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" Width="81px" OnClientClick="Closewin()" />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
       </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>

<%--
  Noc submit button pop --%>  <%--pnlSub--%>
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" >
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lblSub" class="control-label" runat="server"></asp:Label><br />
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-success" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>

    <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder" style="display:none"
        BorderWidth="2px" Width="90%" Height="90%">

         <div class="#rcorners2" id="divAlert" runat="server" style="width:35%;
                display: none;   background-color: white; 
                border-color: blue;" cellpadding="0" cellspacing="0">
                <div id="Div8" runat="server"   style="width:98%;!important" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                            <div class="row" id="Div9" runat="server">
                                 <div class="col-sm-10"  style="text-align: center">
                                    <caption>
                                  <%--  <asp:Label ID="Label3" text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>--%>
                                   </caption>
                                </div>
                             
                            </div>
                        </div>
     
        <table>
        </table>
        <center>
            <br />
          <%--  <asp:Label ID="lblSub" runat="server"></asp:Label>--%>
            </center>
        <br />
        <center>
            <asp:Button ID="btnokSub" runat="server" Text="OK" Width="81px" OnClick="btnokSub_Click" />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
              <br />
              </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopupSub"  PopupControlID="pnlSub"
      OkControlID="btnokSub" X="300" Y="100">  <%--BackgroundCssClass="modalPopupBg"   DropShadow="true"--%>
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="pnlsave" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
        </table>
        <center>
            <br />
            <asp:Label ID="lblsave" runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:Button ID="btnoksave" runat="server" Text="OK" Width="81px" OnClientClick="funcClear()" />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSave" runat="server" TargetControlID="lblsave"
        BehaviorID="mdlpopupSave" BackgroundCssClass="modalPopupBg" PopupControlID="pnlsave"
        DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--added by shreela on 14/07/2014--%>
    <asp:Panel ID="PanelPhoto" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="520px" Height="380px">
        <%--340px,350px--%>
        <center>
            <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                <tr>
                    <td>
                        <asp:Label ID="lblAdvisor" runat="server" Text="" CssClass="standardlink " />
                    </td>
                </tr>
            </table>
        </center>
        <table>
            <asp:Image ID="Image_Photo" runat="server" Width="520px" Height="340px" />
            <%--330,287--%>
        </table>
        <%-- added by shravana--%>
        <table width="100%">
            <tr align="center">
                <td bgcolor="gray" colspan="1" style="height: 32px" width="100%">
                    <asp:Button ID="Button1" runat="server" Text="OK" CssClass="btn-xs default" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup_photo" runat="server" TargetControlID="Image_Photo"
        BehaviorID="mdlpopup_photo" BackgroundCssClass="modalPopupBg" PopupControlID="PanelPhoto"
        DropShadow="true" OkControlID="btnok" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <%--//End Ibrahim--%>
    <asp:ListBox ID="LstImagepath" runat="server" Style="display: none"></asp:ListBox>
    <asp:ListBox ID="Listlabel" runat="server" Style="display: none"></asp:ListBox>
    <%--Addd by rachana on 1-07-2013 to fill all image path with listbox to fetch in JS function--%>
    <asp:ListBox ID="ListDoccode" runat="server" Style="display: none"></asp:ListBox>
    <%--Addd by rachana on 29-07-2013 to fill all image path with listbox to fetch in JS function--%>
    <asp:ListBox ID="ListID" runat="server" Style="display: none"></asp:ListBox>
    <%--panel for cnd view--%>
    <asp:Panel runat="server" ID="pnlMdlCnd" Width="760px" display="none">
        <iframe runat="server" id="Iframe1Cnd" width="790px" height="600px" frameborder="0"
            display="none"></iframe>
        <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1Cnd" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlViewCnd" BehaviorID="mdlViewBIDCnd"
        DropShadow="true" TargetControlID="lbl1Cnd" PopupControlID="pnlMdlCnd" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlMdlRen" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="280px" Height="180px" Visible="false">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lblRen" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="Button2" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn-xs default" /></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlViewRen" BehaviorID="mdlViewBIDRen"
        DropShadow="true" TargetControlID="lblRen" PopupControlID="pnlMdlRen" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>

    



 <%--   Cfr resopned  for bootstrap--%>
    <asp:Panel ID="pnlMdl1" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px"  Width="90%" Height="90%" Visible="false"> <%-- class="modalpopupmesg"--%>

        
         <div class="#rcorners2" id="div10" runat="server" style="width:35%;
                display: block; border: 2px; border-radius: 15px; background-color: white; border: solid;
                border-color: blue; border-width: 2px;" cellpadding="0" cellspacing="0">
                <div id="Div11" runat="server"   style="width:98%;!important" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                            <div class="row" id="Div12" runat="server">
                                 <div class="col-sm-10"  style="text-align: center">
                                    <caption>
                                    <asp:Label ID="Label4" text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                   </caption>
                                </div>
                             
                            </div>
                        </div>
     
        <table>
            <tr>
                <td style="width: 391px;">
                    <br />
                    <center>
                        <asp:Label ID="lblcfrrespnd" runat="server"></asp:Label><br />
                        <br />
                    </center>
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnCFROk" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="btn-xs default" />
        </center>
        <br />
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlCFRRespond" BehaviorID="mdlViewBIDRespnd"
       TargetControlID="lblcfrrespnd" PopupControlID="pnlMdl1" > <%--  DropShadow="true" BackgroundCssClass="modalPopupBg">--%>
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel runat="server" ID="PnlExm" Width="450" Height="320" display="none">
        <iframe runat="server" id="IframeExm" scrolling="no" width="100%" frameborder="0"
            display="none" style="height: 100%; background-color: White;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label6" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlViewBIDExm"
        DropShadow="true" TargetControlID="Label6" PopupControlID="PnlExm" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Shreela  for Crop...Start--%>
    <asp:Panel runat="server" ID="PnlRaiseCrop" Width="1000px" display="none">
        <iframe runat="server" id="IframeRaiseCrop" frameborder="0" display="none" style="width: 1000px;
            height: 500px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblCrop" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopRaiseCrop" BehaviorID="MdlPopRaiseCrop"
        DropShadow="true" TargetControlID="lblCrop" PopupControlID="PnlRaiseCrop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--Shreela  for Crop...End--%>
    <%--ReOpen  CFR...START--%>
    <asp:Panel runat="server" ID="PnlReOpenCFR" Width="600px" display="none">
        <iframe runat="server" id="IframeReOpenCFR" frameborder="0" display="none" style="width: 600px;
            height: 300px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblReOpenCFR" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopReOpenCFR" BehaviorID="MdlPopReOpenCFR"
        DropShadow="true" TargetControlID="lblReOpenCFR" PopupControlID="PnlReOpenCFR"
        BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
        var imgno = 1;
        //Added by rachana on 02-01-2014 for confirmation of approval end
        function Closewin() {

            window.close();
        }

        //Added by shreela on 11-07-2014 start
        function CloseSub() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnReFresh").click();
        }

        function OpenPOP() {
            debugger;
            //window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnReFresh");
            window.parent.document.getElementById("btnReFresh").click();
        }
        //Added by shreela on 11-07-2014 end

        function funcClear() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        //Added for transfer case start

        function RecursiveEnabled(control) {
            var children = control.childNodes;
            try { control.removeAttribute('disabled') }
            catch (ex) { }
            for (var j = 0; j < children.length; j++) {
                RecursiveEnabled(children[j]);
            }
        }

        //Added for transfer case end
        function PopupModal() {
            //debugger;
            var modal = $find('mdlcfrdtlsID');

            if (modal) {
                if (modal.show) {
                    modal.show();
                }
                else {
                    alert("nope!");
                }
            }
            else {
                throw modal;
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



        //added by pranjali on 04-03-2014 end
        function ValidationPAN() {

            var varPAN = document.getElementById('<%= txtPAN.ClientID %>').value;
            document.getElementById('<%= lblPANMsg.ClientID %>').style.display = 'none';

            if (varPAN.length == 0) {
                alert('Please Enter PAN No.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }
            if (varPAN.length < 10) {
                alert('PAN No. must have minimum 10 characters.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }

            if (varPAN.length != 10) {
                alert('PAN No. should be 10 characters.');
                document.getElementById('<%= txtPAN.ClientID %>').focus();
                return false;
            }

            document.getElementById('divPAN').style.display = 'block'

        }
        function CheckPANFormat(strPANNo) {
            var result = true;
            var pan = strPANNo.split(",");
            var Char;

            var pan2 = pan[0]
            if (pan2 != "") {
                if (pan2.length == 10) {
                    for (j = 0; j < pan2.length && result == true; j++) {
                        Char = pan2.substring(j, j + 1);

                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 9) {
                            if (!isAlphabet(Char)) {
                                return 0;
                            }
                            if (j == 3) {
                                if (pan2.substring(j, j + 1) != 'P')
                                    return 0;
                            }
                        }
                        if (j == 5 || j == 6 || j == 7 || j == 8) {
                            if (!IsNumeric(Char)) {
                                return 0;
                            }
                        }
                    }
                }
                else {
                    return 0;
                }
            }
            return 1;
        }



        function funcopencrop1() {
            debugger;
            $find("MdlPopRaiseCrop").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCrop").src = "../../../Application/ISys/Recruit/CropImage.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerText + "&mdlpopup=MdlPopRaiseCrop";

        } //added by shreela on 08/05/2014 for croping

        function FuncReOpen(lblRemarkidValue, lblAddnlRemark) {
            debugger;
            //$find("MdlPopReOpenCFR").show();
            document.getElementById("ctl00_ContentPlaceHolder1_IframeReOpenCFR").src = "../../../Application/ISys/Recruit/PopReOpenCFR.aspx?RemarkId=" + lblRemarkidValue + "&Remarks=" + lblAddnlRemark + "&mdlpopup=MdlPopReOpenCFR";
        }

        function funcShowPopup(strPopUpType) // To populate popup of exam centre
        {
            if (strPopUpType == "RaiseCFR") {
                debugger;


                if (document.getElementById('<%=TxtTrnsfrReqNo.ClientID %>') != null) {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                 document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&TransfrReqNo=" +
                document.getElementById('<%=TxtTrnsfrReqNo.ClientID%>').value +
                 "&FlagCode=Trnsfr" +
                  "&mdlpopup=MdlPopRaiseCFR";
                }
                else {
                    $find("MdlPopRaiseCFR").show();
                    document.getElementById("ctl00_ContentPlaceHolder1_IframeRaiseCFR").src = "../../../Application/ISys/Recruit/PopRaiseCFR.aspx?CndNo=" +
                 document.getElementById('<%=hdnCndNo.ClientID%>').value + "&UserId=" + document.getElementById('<%=hdnUserId.ClientID%>').value + "&args1=" +
                 document.getElementById('<%=BtnApprove.ClientID%>').id + "&args2=" + document.getElementById('<%=BtnCFR.ClientID%>').id + "&args3=" +
                 document.getElementById('<%=lblpanelheader.ClientID%>').innerHTML + "&args4=" +
                 document.getElementById('<%=hdnDocId.ClientID%>').value + "&args5=" +
                 document.getElementById('<%=hdnDocCode.ClientID%>').value + "&raised=" +
                 document.getElementById('<%=lblcfrrais1count.ClientID%>').id + "&responded=" +
                 document.getElementById('<%=lblcfrrespondcount.ClientID%>').id + "&closed=" +
                 document.getElementById('<%=lblcfrclosed.ClientID%>').id + "&FlagCode=Others" + "&mdlpopup=MdlPopRaiseCFR";
                }
            }

        }


        function PopWaiver(CscCode) {

            showPopWin("../../../Application/Common/PopWaiverAdvisor.aspx?Code=" + CscCode
                    , 500, 100, null);
        }


        //added by pranjali on 11-04-2014 start
        function ShowReqDtl(divId, btnId) {

            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+'
                //document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }
        //added by pranjali on 11-04-2014 end
        function ShowReqDtlNew(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }
        //Added by rachana on 02-01-2014 for confirmation of approval end
        function Closewin() {

            window.close();
        }

        //Added by shreela on 11-07-2014 start


        function OpenPOP() {
            debugger;
            //window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnReFresh");
            window.parent.document.getElementById("btnReFresh").click();
        }
        //Added by shreela on 11-07-2014 end



        //Added for transfer case start

        function RecursiveEnabled(control) {
            var children = control.childNodes;
            try { control.removeAttribute('disabled') }
            catch (ex) { }
            for (var j = 0; j < children.length; j++) {
                RecursiveEnabled(children[j]);
            }
        }

        //Added for transfer case end
        function PopupModal() {
            //debugger;
            var modal = $find('mdlcfrdtlsID');

            if (modal) {
                if (modal.show) {
                    modal.show();
                }
                else {
                    alert("nope!");
                }
            }
            else {
                throw modal;
            }
        }

        //added by shreela on 12/03/14 for validation on mobile no and email start
        function form2() {
            var strContent = "ctl00_ContentPlaceHolder1_";
            // debugger;
            if ((document.getElementById(strContent + "txtMobileNo").value) == "") {
                alert("Mobile No is mandatory.");
                document.getElementById(strContent + "txtMobileNo").focus();
                return false;
            }
            else {
                //                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                //                if ((Mobile.substr(0, 1)) != "0") {
                //                    alert("Mobile Number should start with 0");
                //                    document.getElementById(strContent + "txtMobileNo").focus();
                //                    return false;
                //                }
                var Mobile = (document.getElementById('<%= txtMobileNo.ClientID %>').value);
                if (Mobile.length != 10) {
                    alert("Mobile No should be 10 digit.");
                    document.getElementById(strContent + "txtMobileNo").focus();
                    return false;
                }

            }
            return true;
        }

        function validateEmail1() {

            //debugger;
            var Email = (document.getElementById('<%= txtEMail.ClientID %>').value);
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!Email.match(reEmail)) {
                alert("Invalid email address");
                document.getElementById("ctl00_ContentPlaceHolder1_txtEMail").focus();
                return false;
            }

            return true;

        }
        //added by shreela on 12/03/14 for validation on mobile no and email end


        //Added by shreela on 8/04/2014 for Renewal start
        function validateRenewal() {
            debugger;
            if (document.getElementById('<%=ddlRenewType.ClientID%>').value == "---Select---") {
                alert("Insurer Type is Mandatory");
                document.getElementById('<%=ddlRenewType.ClientID%>').focus();
                return true;
            }
            else if (document.getElementById('<%=ddllyfTraining.ClientID%>').value == "---Select---") {
                alert("Please select Life Training");
                document.getElementById('<%=ddllyfTraining.ClientID%>').focus();
                return true;
            }
    }
    function ShowReqDtlRenew(divId, btnId) {
        if (document.getElementById(divId).style.display == "block") {
            document.getElementById(divId).style.display = "none";
            //document.getElementById(divId).value = '+'
            document.getElementById(btnId).value = '+';
        }
        else {
            document.getElementById(divId).style.display = "block";
            document.getElementById(btnId).value = '-';
        }
    }
    function AlertMsgs(msgs) {
        alert(msgs);
    }

    //Added by shreela on 8/04/2014 for Renewal end

    //changing color of fees at 2nd Qc
    function btnClick() {
        debugger;
        var x = document.getElementById("tbltest").getElementsByTagName("FeesRow");
        // var y = document.getElementById("tblICMDtls").getElementsByTagName("trTokenwithFees");
        x.style.backgroundColor = "yellow";
        //y.style.backgroundColor = "red";
    }

    //Added by rachana for showinfg loader image on approve,save,submit, reject button start
    function StartProgressBar() {

        var myExtender = $find('ProgressBarModalPopupExtender');
        myExtender.show();

        return true;
    }

    //Added by rachana for showinfg loader image on approve,save,submit, reject button end
    </script>
  <%--</div>--%>
<%--  </center>--%>
<%--    <div style="top: 0px; right: 0px; bottom: 0px; left: 0px; margin: auto; height:100px; width:100px;">--%>
   <asp:UpdatePanel ID="pop1" runat="server">
        <ContentTemplate>
  <div class="modal fade" id="mdlpopup1" role="dialog" style="opacity:1.0">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center;background-color: #00008B;color: #fff;">
                    <asp:Label ID="Label5" Text="INFORMATION" class="control-label" Font-Bold="true" runat="server" Style="margin-left: 104px;margin-top: 20px;"></asp:Label>

                </div>
                                <div class="modal-body" style="text-align:center">
                <div id="divmdlbdy"  style="width:375px;height:200px;margin-top: 20px;">
                                   </div> 
                </div>
                <div  style="text-align: center">  <%--class="modal-footer"--%>

                    <button type="button" class="btn btn-success" data-dismiss="modal" style=" margin-bottom: 52px; margin-right:4px;" onclick="ClosePopup();">  <%--border-radius: 15px;--%>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK
                    </button>
                </div>
            </div>

        </div>
    </div>          
            </ContentTemplate>
        </asp:UpdatePanel>
<%--        </div>    --%>
</asp:Content>
