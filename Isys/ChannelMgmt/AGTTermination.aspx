<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="AGTTermination.aspx.cs" Inherits="Application_INSC_ChannelMgmt_AGTTermination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <%--    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>--%>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" src="../../../Scripts/jsAgtCheck.js" type="text/javascript"></script>
    <script src="../../../Scripts/jQuery_1.X.js" type="text/javascript"></script>
<link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <style type="text/css">
    .pagelink span{font-weight:bold;}/*Added: Parag @ 25032014*/
    </style>
   <style type="text/css">
             .btn-subtab
        {
            color:white;
            background-color:#034ea2 !important;
            border-color:white;
        }
       
   
        .pagelink span
        {
            font-weight: bold;
        }
        /*Added: Parag @ 25032014*/
    </style>
    <style type="text/css">
        .dataTable {  
  width: 100% !important;
  clear: both;
  margin-top: 5px;
  border:none;
}

.dataTables_filter label {
  line-height: 32px ;
}

.dataTable .row-details {  
  margin-top: 3px;
  display: inline-block;
  cursor: pointer;
  width: 14px;
  height: 14px;
}

.dataTable .row-details.row-details-close {
  background: url("../img/datatable-row-openclose.png") no-repeat 0 0;
}

.dataTable .row-details.row-details-open {  
  background: url("../img/datatable-row-openclose.png") no-repeat 0 -23px ;
}

.dataTable .details {
  background-color: #eee ;
}

.dataTable .details td,
.dataTable .details th {
  padding: 4px;
  background: none ;
  border:0;
}

.dataTable .details tr:hover td,
.dataTable .details tr:hover th {
  background: none ;
}

.dataTable .details tr:nth-child(odd) td,
.dataTable .details tr:nth-child(odd) th {
  background-color: #eee ;
}

.dataTable .details tr:nth-child(even) td,
.dataTable .details tr:nth-child(even) th {
  background-color: #eee ;
}

.dataTable > thead > tr > th.sorting,
.dataTable > thead > tr > th.sorting_asc,
.dataTable > thead > tr > th.sorting_desc {
   padding-right: 18px;
}

.dataTable .table-checkbox {
  width: 8px !important;
}

@media (max-width: 768px) {  
  .dataTables_wrapper .dataTables_length .form-control,
  .dataTables_wrapper .dataTables_filter .form-control {
    display: inline-block;
  }

  .dataTables_wrapper .dataTables_info {
    top: 17px;
  }

  .dataTables_wrapper .dataTables_paginate {
    margin-top: -15px;
  }
}

@media (max-width: 480px) {  
  .dataTables_wrapper .dataTables_filter .form-control {
    width: 175px !important;
  }

  .dataTables_wrapper .dataTables_paginate {
    float: left;
    margin-top: 20px;
  }
}

.dataTables_processing {
  position: fixed;
  top: 50%;
  left: 50%;
  min-width: 125px;
  margin-left: 0;
  padding: 7px;
  text-align: center;
  color: #333;
  font-size: 13px;
  border: 1px solid #ddd;
  background-color: #eee;  
  vertical-align: middle;
  -webkit-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
     -moz-box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);
          box-shadow: 0 1px 8px rgba(0, 0, 0, 0.1);  
}

.dataTables_processing span {
  line-height:15px;
  vertical-align: middle;
}

.dataTables_empty {
  text-align: center; 
}

        .ajax__calendar
        {
            z-index: 100px;
        }
        .form-submit-button
        {
            box-shadow: none !important;
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
        
        .transbox
        {
            width: 400px;
            height: 180px;
            margin: 30px 50px;
            background-color: #ffffff;
            border: 1px solid black;
            opacity: 0.6;
            filter: alpha(opacity=60); /* For IE8 and earlier */
            z-index: inherit;
        }
        
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
       
    </style>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" src="../../../Scripts/jsAgtCheck.js" type="text/javascript"></script>
    <script src="../../../Scripts/jQuery_1.X.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function popup() {
            $("#myModal").modal();
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-resize-small'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-resize-full'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        function ShowReqDtl(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                   // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
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
        var path = "<%=Request.ApplicationPath.ToString()%>";

        function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp) {
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
        + "&Desc=" + document.getElementById('<%=lblRptMgrVal.ClientID %>').value + "&field1=" + document.getElementById('<%=hdnRptMgr.ClientID %>').id
        + "&field2=" + document.getElementById('<%=lblRptMgrVal.ClientID %>').id + "&bizsrc=" + strbzsrc
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp
        + "&field3=" + document.getElementById('<%=lblRptMgrVal.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
        }



        function ShowReqDtls(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                document.getElementById(btnId).value = '-';
            }
        }

//        function ShowReqDtl(divId, btnId, img) {
//            var strContent = "ctl00_ContentPlaceHolder1_";
//            $(document.getElementById(strContent + divId)).slideToggle();
//            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
//                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
//            }
//            else {
//                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
//            }
//        }
        function AssigText(strtext) {
            
            if (strtext == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            if (strtext == "Multiple-1") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            else if (strtext == "Multiple-2") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            else if (strtext == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            if (strtext == 'empty') {
                document.getElementById("ctl00_ContentPlaceHolder1_tblReportingMngrDtls").style.display = "none";
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_lblam1rptdescVal") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_lblam1rptdescVal").innerText == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                }
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_lblam2rptdescVal") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_lblam2rptdescVal").innerText == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                }
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_lblam3rptdescVal") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_lblam3rptdescVal").innerText == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
                }
            }
        }

        function funValidate() {
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "ddlTermReason") != null) {
                if (document.getElementById(strContent + "ddlTermReason").value == "") {
                    alert("Please Enter Termination Reason");
                    document.getElementById(strContent + "ddlTermReason").focus();
                    return false;
                }
            }
            if (document.getElementById(strContent + "txtRemark") != null) {
                if (document.getElementById(strContent + "txtRemark").value == "") {
                    alert("Please Enter Remarks");
                    document.getElementById(strContent + "txtRemark").focus();
                    return false;
                }
            }
        }
    </script>
    <%--<script language="javascript" type="text/javascript" src="~/Scripts/common.js"></script>--%>
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript" src="~/Scripts/subModal.js"></script>
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    <scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" /> 
        </scripts>
        <services>
            <asp:ServiceReference  Path="../../../Application/Common/Lookup.asmx" />
        </services>
    </asp:ScriptManager>

        <center>
        <table width="80%" border="0" style="border-collapse: collapse;height:18px;">
            <tr align="center">
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
         <div class="panel " id="divpersnldtlsHdr" runat="server">
           <div id="Div4" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpersnldtls','btnprsnldtlscollapse');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblPersonalPart" runat="server" Text="Personal Particular"  Font-Size="19px" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnprsnldtlscollapse" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                    <div id="divpersnldtls" runat="server" class="panel-body" style="display:block"> 
                    
     <div class="row">
                                <div class="col-md-10">
                                 <div>
                                 <div class="row" ID="trcltcode" runat="server" style="margin-bottom:5px;"   visible="false">
                                        <td class="form-body align col-md-6">
                                            <asp:Label ID="lblClCode" runat="server" CssClass="control-label"></asp:Label>
                                        </td>
                                        <td class="col-md-7">
                                            <asp:Label ID="lblCusmIdVal" runat="server" CssClass="control-label" 
                                                MaxLength="12" Width="201px"></asp:Label>
                                        </td>
                                        <td class="form-body align col-md-6">
                                            <asp:Label ID="lblCode" runat="server" CssClass="control-label"></asp:Label>
                                        </td>
                                        <td class="col-md-7">
                                            <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline" 
                                                UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblCltCodeVal" runat="server" CssClass="control-label" MaxLength="12" 
                                                Width="104px"></asp:Label>
                                                    &nbsp;
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                  </div>
                                    <div style="margin-bottom:5px;" class="row">
                                    <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lvlVw1AgntCode" runat="server" Font-Bold="False" CssClass="control-label">Agent Code</asp:Label>
                                    </div>
                                     <div class="col-md-3">
                                            <asp:TextBox ID="lblAgtCodeVal" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                            <asp:Label ID="lblVw1SMCode" runat="server" Font-Bold="False" CssClass="control-label" Text="" Visible="false"></asp:Label>
                               </div>
                                       <div class="col-md-3" style="text-align:left">
                                            <span>
                                            <asp:Label ID="lblVw1AgntStatus" runat="server" Font-Bold="False" CssClass="control-label">Agent Status</asp:Label>
                                            </span>
                                    </div>
                                          <div class="col-md-3">
                                            <asp:TextBox ID="lblAgntStatusVal" runat="server" CssClass="form-control"   Enabled="false" >
                                           </asp:TextBox>
                                      </div>
                                  </div>
                                  <div class="row" style="margin-bottom:5px;">
                                  <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblAgntName" runat="server" CssClass="control-label">Agent Name</asp:Label>
                                     </div>
                                  <div class="col-md-3" style="display: flex">
                                           <%-- <asp:TextBox ID="lblagnTitleVal" style="width: 40%" runat="server" CssClass="form-control"   Enabled="false" 
                                       ></asp:TextBox>--%>
                                       <asp:TextBox ID="lblagnTitleVal" runat="server" style="width: 40%" CssClass="form-control"   Enabled="false" ></asp:TextBox>
                                            <asp:TextBox ID="lblAgntNameVal" runat="server" CssClass="form-control" style="margin-left: 2px"  Enabled="false" MaxLength="125"
                                       ></asp:TextBox>
                                                <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                   </div>
                                      <div class="col-md-3" style="text-align:left">
                                            <asp:Label ID="lblGender" runat="server" Text="Gender" CssClass="control-label"></asp:Label>
                                    </div>
                                       <div class="col-md-3">
                                            <asp:TextBox ID="lblGenderVal" runat="server" CssClass="form-control"   Enabled="false"
                                                                     ></asp:TextBox>
                                      </div>
                                   </div>
                              </div>
                                  <div class="row">   
                                   <div class="panel " id="divTermDtlsHdr" runat="server">
                                     <div id="div6" runat="server" class="panel-heading subheader"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divTermDtls','btntrfdtlscollapse');return false;"
                   >  
                    <div class="row" ID="trDetails" runat="server" >
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                     <asp:Label ID="lbltermDtls" runat="server" Text="Termination Details"  CssClass="subheader" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btntrfdtlscollapse" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                    <div id="divTermDtls" runat="server" class="panel-body" style="display:block">  
                                         <div id="tblTermDtls">
                                           <div class="row" id='trEffDt' style="margin-bottom:5px;" runat="server">
                                            <div class="col-md-3" style="text-align:left">
                                                    <asp:Label ID="lblEffctDt" runat="server" Text="Effective Date" CssClass="control-label"></asp:Label>
                                          </div>
                                            <div class="col-md-3">
                                                    <asp:TextBox runat="server" ID="lblEffectiveDate" 
                                                        CssClass="form-control"   Enabled="false"  Font-Bold="False" Font-Size="Small"></asp:TextBox>
                                              </div>
                                                <div class="col-md-3" style="text-align:left">
                                                    <asp:Label ID="lblTermReason" runat="server" Text="Termination Reason" CssClass="control-label"></asp:Label>
                                                    <span style="color: #ff0000;margin-left:-2px;">*</span><%--Modified: Parag @ 25032014--%>
                                                    </div>
                                                   <div class="col-md-3">
                                                <asp:UpdatePanel ID="updTermRes" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTermReason" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                             </div>
                                           </div>
                                       <div class="row" style="margin-bottom:5px;">
                                                   <div class="col-md-3" style="text-align:left">
                                                        <asp:Label ID="lblRemark" runat="server" Text="Remarks" CssClass="control-label"></asp:Label>
                                                        <span style="color: #ff0000;margin-left:-2px;">*</span>
                                              </div>
                                                   <div class="col-md-9">
                                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" 
                                                            TextMode="MultiLine" ></asp:TextBox>
                                                       
                                                    </div>
                                           </div>
                                          </div>
                                        </div>
                                        </div>
                               </div>
                            </div>
                              <div class="col-md-2" >
                                  <div class="row" style="margin-bottom:5px;">
                                            <div class="col-md-12" style="text-align: center">
                                                <asp:Label ID="lblPhoto" runat="server" Text="Photo" CssClass="control-label" Font-Bold="true"></asp:Label>
                                    </div>
                                       </div>
                                        <div class="row" style="margin-bottom:5px;">
                                            <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="100px" />
                                 <%--            <asp:GridView ID="GridImage" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" CssClass="formtable" 
                                                Height="100%" HorizontalAlign="Left" 
                                                PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" 
                                                PagerStyle-HorizontalAlign="Center" RowStyle-CssClass="formtable" Width="100%">--%>
                                                      <asp:GridView  AllowSorting="True" ID="GridImage" runat="server" CssClass="footable"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="MemCode" SortExpression="MemCode" 
                                                        Visible="false">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("MemCode") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ImageField ControlStyle-Height="100px" ControlStyle-Width="120px" 
                                                        DataImageUrlField="MemCode"
                                                        DataImageUrlFormatString="ImageRet.aspx?ImageID={0}" HeaderText="Preview Image" 
                                                        NullImageUrl="~/theme/iflow/prof_pic_blank.jpg">
                                                    </asp:ImageField>
                                                </Columns>
                                               <%-- <RowStyle BackColor="#78A8FA" CssClass="sublinkeven" />
                                                <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" 
                                                    HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="test" />
                                                <AlternatingRowStyle BackColor="#78A8FA" CssClass="sublinkodd" />--%>
                                            </asp:GridView>
                                           </div>
                                        <div class="row">
                                                <asp:LinkButton ID="lnkUploadPhoto" runat="server" Text="Upload Photo" 
                                                    Font-Size="12px" Visible="false"></asp:LinkButton>
                                            </div>
                                 </div>
                                        </div>
                             </div>
                             </div>
                             <br />
                                  <div class="panel " id="divCurntDtlsHdr" runat="server">
                                     <div id="Div8" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divCurntDtls','btnCurrntDtlscollapse');return false;"> 
                    <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="Label15" runat="server" Text="Current Details"  Font-Size="19px" ></asp:Label>
                    <%--   <asp:Image ID="Image6" ImageUrl="~/assets/help_red.png" runat="server"  />--%>
                 
                    </div>
                    <div class="col-sm-2">
                    <span id="btnCurrntDtlscollapse" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>   


                  </div>
                  
                      <div id="divCurntDtls" runat="server" class="panel-body" style="display:block"> 
                           <div id="tblReportingMngrDtls" runat="server">
                                <asp:UpdatePanel ID="updCrnttabs" runat="server">
                                <ContentTemplate>
                                <asp:ImageButton ID="lnkCrntHier" runat="server" CssClass="TextBox" Visible="false"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/HierarchyDtls2.png" 
                                    Text="Primary Manager" OnClick="lnkCrntHier_Click" />
                                <asp:ImageButton ID="lnkCrntPrimMgr" runat="server" CssClass="TextBox" Visible="false"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/PrmyMgr2.png" 
                                    Text="Primary Manager" OnClick="lnkCrntPrimMgr_Click" />
                                <asp:ImageButton ID="lnkCrntAddlMgr" runat="server" CssClass="TextBox" Visible="false"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/AddlMgr2.png" 
                                    Text="Addl. Managers" OnClick="lnkCrntAddlMgr_Click" />
                                <asp:ImageButton ID="lnkCrntDlines" runat="server" CssClass="TextBox" Visible="false"
                                    BackColor="transparent" ImageUrl="~/theme/iflow/tabs/Downlines2.png" 
                                    Text="Downlines" OnClick="lnkCrntDlines_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                               <div id="demo1" class="row" runat="server" style="text-align: left;margin-left:20px;margin-bottom:20px">
                                   <asp:LinkButton ID="lnkHierarchy" Text="Hierarchy Details" CssClass="btn btn-default"
                                       OnClick="lnkHierarchy_Click" runat="server"></asp:LinkButton>
                                   <asp:LinkButton ID="lnkprimary" Text="Primary Manager" CssClass="btn btn-default"
                                       OnClick="lnkprimaryl_Click" runat="server"></asp:LinkButton>
                                   <asp:LinkButton ID="lnkadditional" Text="Additional Manager" CssClass="btn btn-default"
                                       OnClick="lnkadditional_Click" runat="server"></asp:LinkButton>
                                   <asp:LinkButton ID="lnkDownlines" Text="Downlines" CssClass="btn btn-default" OnClick="lnkDownlines_Click"
                                       runat="server"></asp:LinkButton>
                               </div>
                               <asp:HiddenField ID="hdnTab" runat="server" />
                               <div class="panel " id="divHirarchyDtlsHdr" runat="server">
                                   <div id="Div1" class="panel-heading subheader" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divHirarchyDtls','btnHirarchyDtlscollapse');return false;"
                                       >
                                       <div class="row">
                                           <div class="col-sm-10" style="text-align: left">
                                               <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                                               <asp:Label ID="lblHirarchyDtlshdr" runat="server" Text="Hierarchy Details" CssClass="subheader"></asp:Label>
                                           </div>
                                           <div class="col-sm-2">
                                               <span id="btnHirarchyDtlscollapse" class="glyphicon glyphicon-resize-full" style="float: right;
                                                   color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                           </div>
                                       </div>
                                   </div>
                                   <div id="divHirarchyDtls" runat="server" class="panel-body" style="display: block">
                                       <div class="row" style="margin-bottom: 5px;">
                                           <div class="col-md-3" style="text-align: left">
                                               <asp:Label ID="lblchnltype" runat="server" CssClass="control-label">Channel Type</asp:Label>
                                           </div>
                                           <div class="col-md-3">
                                               <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                                   <ContentTemplate>
                                                       <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" CellPadding="2"
                                                           CellSpacing="2" RepeatDirection="Horizontal" Width="185px" >
                                                           <asp:ListItem Value="0" Text="&nbspCompany&nbsp&nbsp&nbsp"></asp:ListItem>
                                                           <asp:ListItem Value="1" Text="&nbspChannel"></asp:ListItem>
                                                       </asp:RadioButtonList>
                                                   </ContentTemplate>
                                               </asp:UpdatePanel>
                                           </div>
                                           <div class="col-md-3" style="text-align: left">
                                               <asp:Label ID="lblCntDetails" runat="server" Visible="false" CssClass="control-label"></asp:Label>
                                           </div>
                                           <div class="col-md-3">
                                               <%--<asp:LinkButton ID="lnbViewCntDetails" runat="server"  Visible="false">View Details</asp:LinkButton>--%>
                                           </div>
                                       </div>
                                       <div class="row" style="margin-bottom: 5px;">
                                           <div class="col-md-3" style="text-align: left">
                                               <asp:Label ID="lblBusinessSrc" runat="server" Font-Bold="False" CssClass="control-label">Hierarchy Name</asp:Label>
                                           </div>
                                           <div class="col-md-3">
                                               <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                                   <ContentTemplate>
                                                       <asp:TextBox ID="lblSlsChannelVal" runat="server" CssClass="form-control" Enabled="false"
                                                           AutoPostBack="True" ></asp:TextBox>
                                                   </ContentTemplate>
                                                   <Triggers>
                                                       <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                                   </Triggers>
                                               </asp:UpdatePanel>
                                           </div>
                                           <div class="col-md-3" style="text-align: left">
                                               <asp:Label ID="lblChnCls" runat="server" CssClass="control-label">Sub Class</asp:Label>
                                           </div>
                                           <div class="col-md-3">
                                               <asp:TextBox ID="lblChnClsVal" runat="server" CssClass="form-control" Enabled="false"
                                                   ></asp:TextBox>
                                           </div>
                                       </div>
                                       <div class="row" style="margin-bottom: 5px;">
                                           <div class="col-md-3" style="text-align: left">
                                               <asp:Label ID="lblVw1AgntType" runat="server" Font-Bold="False" CssClass="control-label">Agent Type</asp:Label>
                                           </div>
                                           <div class="col-md-3">
                                               <asp:TextBox ID="lblAgntTypeVal" runat="server" CssClass="form-control" Enabled="false"
                                                  ></asp:TextBox>
                                           </div>
                                           <div class="col-md-3" style="text-align: left">
                                               <asp:Label ID="lblAgntClass" runat="server" Font-Bold="False" CssClass="control-label">Agent Class</asp:Label>
                                           </div>
                                           <div class="col-md-3">
                                               <asp:TextBox ID="lblAgntClassVal" runat="server" CssClass="form-control" Enabled="false"
                                               ></asp:TextBox>
                                           </div>
                                       </div>
                                   </div>
                               </div>
                                <div class="panel " id="divprirepHdr" runat="server" > 
                                 <div id="Div2" class="panel-heading subheader" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprirep','btnprirep');return false;"
                         >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                     <asp:Label ID="lblPrimaryReportinghdr" runat="server"  Text="Primary Reporting" CssClass="subheader" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnprirep" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                           <div id="divprirep" runat="server" class="panel-body" style="display:block">
                                        <div class="row" style="margin-bottom:5px;">
                                        <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblddlreportingtype" runat="server" Text="Reporting Type" CssClass="control-label"></asp:Label>
                                           </div>
                                          <div class="col-md-3">
                                                <asp:TextBox ID="lblprimrepoVal" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                       </div>
                                         <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblbasedon" runat="server" Text="Based On" CssClass="control-label"></asp:Label>
                                         </div>
                                          <div class="col-md-3">
                                                <asp:TextBox ID="lblbasedondescVal" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                          </div>
                                       </div>
                                        <div class="row" style="margin-bottom:5px;">
                                         <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblchannel" runat="server" CssClass="control-label">Hierarchy Name</asp:Label>
                                          </div>
                                     <div class="col-md-3">
                                                <asp:TextBox ID="lblchanneldescVal" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                          </div>
                                        <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblsubchannel" runat="server" CssClass="control-label">Sub Class</asp:Label>
                                       </div>
                                         <div class="col-md-3">
                                                <asp:TextBox ID="lblsubchnldescVal" runat="server" CssClass="form-control"   Enabled="false">
                                                </asp:TextBox>
                                         </div>
                                      </div>
                                        <div class="row" style="margin-bottom:5px;">
                                         <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lblReportingMgr" runat="server" Text="Reporting Manager" CssClass="control-label"></asp:Label>
                                       </div>
                                          <div class="col-md-3">
                                                <asp:TextBox ID="lblRptMgrVal" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>&nbsp
                                                <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                                <asp:TextBox ID="lblrptmgr" runat="server" CssClass="form-control" Visible="false"  Enabled="false"></asp:TextBox>
                                           </div>
                                         <div class="col-md-3" style="text-align:left">
                                                <asp:Label ID="lbllevelagttype" runat="server" CssClass="control-label">Level/Rel Type</asp:Label>
                                       </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="lbllvlagtVal" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                           </div>
                                    </div>
                                              <div class="row" style="margin-bottom:5px;">
                                                                <%--<asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                                     Width="100%" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable" >
                                                                     <HeaderStyle ForeColor="Black"  />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />--%>
                                        <asp:GridView  AllowSorting="True" ID="gv" runat="server" CssClass="footable"
                                                  Visible="false"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                                                      <Columns>
                                                                        <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                                            <ItemTemplate>
                                                                                <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                                <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Member Type" SortExpression="MemType">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField >
                                                                        <asp:TemplateField HeaderText="Unit Code">
                                                                            <ItemTemplate>
                                                                                <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                                                <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                         
                                                      </div>
                                </div>
                                </div>
                                
                                  <div class="panel " id="divMngrDtlsHdr" runat="server" > 
                                  <div id="Div3" class="panel-heading subheader" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divMngrDtls','btnMngrDtls');return false;"
                   >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                     <asp:Label ID="lblAddlMgrDet" runat="server"  Text="Additional Manager Details" CssClass="subheader" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnMngrDtls" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div>
                           <div id="divMngrDtls" runat="server" class="panel-body" style="display:block"> 
                                <div class="row" id="trrptrule" runat="server" visible="false">
                                                      <div class="col-md-3" style="text-align:left">
                                                                <asp:Label ID="lbladditionalreporting" runat="server" Text="Additional Reporting Rule" CssClass="control-label"></asp:Label>
                                                     </div>
                                                           <div class="col-md-9">
                                                                <asp:Label ID="lbladditionalreportingrule" runat="server" CssClass="control-label"></asp:Label>
                                                                <asp:Label ID="lblRptMngrErr" runat="server" ForeColor="Red" CssClass="control-label"></asp:Label>
                                                          </div>
                                   </div>
                                                     <div class="row">
                                                         <%--       <asp:GridView ID="gv_RptMngr" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False"  Width="100%" 
                                                                    onrowdatabound="gv_RptMngr_RowDataBound">--%>
                                                                    <asp:GridView  AllowSorting="True" ID="gv_RptMngr" runat="server" CssClass="footable"
                                                  onrowdatabound="gv_RptMngr_RowDataBound"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true"   >
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                                                     <Columns>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Black">
                                                                            <ItemTemplate>
                                                                                    <div class="row" style="margin-bottom:5px;">
                                                                                   <div class="col-md-12" style="text-align:center">
                                                                                        <asp:Label ID="lblMgrHdr" runat="server" Height="21px" Font-Bold="true" Text="Additional Manager" CssClass="control-label"></asp:Label>
                                                                                        <asp:Label  ID="lblNo" runat="server" Height="21px" Font-Bold="true" Text='<%# Bind("Mngr") %>' CssClass="control-label"></asp:Label>
                                                                                   </div>
                                                                              </div>
                                                                                     <div class="row" style="margin-bottom:5px;">
                                                                                       <div class="col-md-3" style="text-align:left">
                                                                                            <asp:Label ID="lblAdlRptTyp" runat="server" Text="Relationship Type" CssClass="control-label"/>
                                                                                      </div>
                                                                                      <div class="col-md-3">
                                                                                            <asp:TextBox ID="lblAdlRptType" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                            <asp:HiddenField id="hdnAddl1Type" runat="server" />
                                                                                         </div>
                                                                                       <div class="col-md-3" style="text-align:left">
                                                                                            <asp:Label ID="lblAdlBasedOn" runat="server" Text="Based On" CssClass="control-label"/>
                                                                                  </div>
                                                                                      <div class="col-md-3">
                                                                                            <asp:TextBox ID="lblAdlBsdOn" runat="server" CssClass="form-control"   Enabled="false">
                                                                                            </asp:TextBox>
                                                                                      </div>
                                                                                  </div>
                                                                                      <div class="row" style="margin-bottom:5px;">
                                                                                    <div class="col-md-3" style="text-align:left">
                                                                                            <asp:Label ID="lblAdlChn" runat="server" Text="Hierarchy Name" CssClass="control-label"/>
                                                                                       </div>
                                                                                   <div class="col-md-3">
                                                                                            <asp:TextBox ID="lblAdlChnl" runat="server" CssClass="form-control"   Enabled="false">
                                                                                            </asp:TextBox>
                                                                                  </div>
                                                                                    <div class="col-md-3" style="text-align:left">
                                                                                            <asp:Label ID="lblAdlSChn" runat="server" Text="Sub Class" CssClass="control-label"/>
                                                                                    </div>
                                                                                       <div class="col-md-3">
                                                                                            <asp:TextBox ID="lblAdlSChnl" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                     </div>
                                                                                    </div>
                                                                                 <div class="row" style="margin-bottom:5px;">
                                                                                     <div class="col-md-3" style="text-align:left">
                                                                                            <asp:Label ID="lblAdlMemTyp" runat="server" Text="Member Type" CssClass="control-label"/>
</div>
                                                                                     <div class="col-md-3">
                                                                                            <asp:TextBox ID="lblAdlMemType" runat="server" AutoPostBack="true" CssClass="form-control"   Enabled="false">
                                                                                            </asp:TextBox>
                                                                                            <asp:HiddenField id="hdnAddl1agttyp" runat="server" />	
                                                                                       </div>
                                                                                       <div class="col-md-3" style="text-align:left">
                                                                                            <asp:Label ID="lblAddlMgr" runat="server" Text="Manager" CssClass="control-label"/>
                                                                                            <asp:Label ID="lblmndtry" runat="server" Text="*" ForeColor="Red" Visible="false" />
                                                                                   </div>
                                                                                         <div class="col-md-3">
                                                                                            <asp:TextBox ID="lblRptMngr" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                             <asp:HiddenField id="hdnaddl1code" runat="server" />	
                                                                                            <asp:HiddenField ID="hdnAddlRptMgr" runat="server" />
                                                                                            <asp:HiddenField ID="hdnRptMgrMandatory" runat="server" />
                                                                                       </div>
                                                                                 </div>
                                                                                     <div class="row" style="margin-bottom:5px;">
                                                                                           <%-- <asp:GridView ID="gvAddlMgr" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                Width="100%" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable">
                                                                                                <HeaderStyle ForeColor="Black"  />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />--%>   
                                      <div class="container" style="width:100%;margin-top:  10px;""> 
                                           <asp:GridView  AllowSorting="True" ID="gvAddlMgr" runat="server" CssClass="footable"
                                              
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                                                                        <ItemTemplate>
                                                                                                            <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                                                            <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Name">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Member Type" SortExpression="MemType">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblMemType" runat="server" Text='<%# Bind("MemType") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Unit Code">
                                                                                                        <ItemTemplate>
                                                                                                            <i class="fa fa-list-ol"></i>&nbsp;&nbsp;
                                                                                                            <asp:LinkButton ID="lnkUnitCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                            </asp:GridView>

                                      </div>
                                                                                  </div>
                                                                            </ItemTemplate>
                                                                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                         </div>
                                </div>
                                </div>
                                
                              <div class="panel " id="divCrntDownLinesHdr" runat="server" >  
                              <div id="Div5" class="panel-heading subheader" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divCrntDownLines','btnCrntDownLines');return false;"
                         >          
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                     <asp:Label ID="lblDwnDtlsHdr" runat="server"  Text="Downline Details" CssClass="subheader" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnCrntDownLines" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div> 
                             <div id="divCrntDownLines" class="panel-body" runat="server" style="display:block"> 
                              <div  id="trDownlines" runat="server" style="margin-bottom:5px;" visible="true">
                                                    <div class="ImgTab">
                                                        <ul style="display: none">
                                                            <li class="current">
                                                                <asp:LinkButton ID="lnkbtnCF1" runat="server" Style="background-color: #fafafa;" Text="Primary Downline Details" Visible="false"
                                                                    OnClick="lnkbtnCF_Click"></asp:LinkButton>
                                                            </li>
                                                            <li>
                                                                <asp:LinkButton ID="lnkbtnCU1" runat="server" Style="background-color: #fafafa;" Text="Additional Downline Details" Visible="false"
                                                                    OnClick="lnkbtnCU_Click"></asp:LinkButton>
                                                            </li>
                                                        </ul>
                                                         <div id="Div9" class="row" style="text-align: left; margin-left: -1px; margin-bottom:10px"  runat="server">
                            <asp:LinkButton ID="lnkbtnCF"  Text="Primary Downline Details"  CssClass="btn btn-sample"    OnClick="lnkbtnCF_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnCU"  Text="Additional Downline Details" CssClass="btn btn-sample"  OnClick="lnkbtnCU_Click" runat="server"></asp:LinkButton>
                            </div>
                                                        <asp:UpdatePanel ID="upDownlines" runat="server">
                                                            <ContentTemplate>
                                                                  <%--  <asp:GridView ID="gv_TrfDownlines" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                        HorizontalAlign="Left" Width="100%"  AllowSorting="True" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable" 
                                                                        Style="margin-left: 0px" OnPageIndexChanging="gv_TrfDownlines_PageIndexChanging" 
                                                                        OnSorting="gv_TrfDownlines_Sorting">
                                                                         <HeaderStyle ForeColor="Black"  />
                                                                        <RowStyle />
                                                                        <PagerStyle CssClass="disablepage" />--%>
                                                                         <asp:GridView  AllowSorting="True" ID="gv_TrfDownlines" runat="server" CssClass="footable"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   OnSorting="gv_TrfDownlines_Sorting"  OnPageIndexChanging="gv_TrfDownlines_PageIndexChanging" >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Member Code" SortExpression="MemCode">
                                                                                <ItemTemplate>
                                                                                    <i class="fa fa-male"></i>&nbsp;&nbsp;
                                                                                    <asp:Label ID="lblMemCode" runat="server" Text='<%# Bind("MemCode") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <%--<asp:BoundField HeaderText="Member Code" DataField="MemCode" SortExpression="MemCode"
                                                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>--%>
                                                                            <asp:BoundField HeaderText="Channel" DataField="Channel" SortExpression="Channel"
                                                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                                            <asp:BoundField DataField="SubChannel" HeaderText="Sub Class" SortExpression="SubChannel"
                                                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                                            <asp:BoundField DataField="AgentTypeDesc" HeaderText="Member Type" SortExpression="AgentTypeDesc"
                                                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                                            <asp:BoundField DataField="RelationType" HeaderText="Relation Type" SortExpression="RelationType"
                                                                                HeaderStyle-HorizontalAlign="Center" />
                                                                        </Columns>
                                                                        </asp:GridView>
                                                                    <asp:Label ID="lblDownlineErrorMsg" runat="server" CssClass="control-label" Text="No Downlines Found" 
                                                                    Visible="false" ForeColor="Red"></asp:Label>
                                                               

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                         </div>
                              <div class="row">
                              <div class="col-md-12" style="text-align:center">
                                                    <asp:LinkButton ID="btnTrf" runat="server" Text="Transfer" CssClass="btn btn-sample" OnClick="btnTrf_Click" Visible="false"></asp:LinkButton>
                                    </div>
                                </div>
                                <br />
                                        </div>
                                        </div>
                                    
                              
                                 <br />
                                     <div class="panel " id="divuntcodeHdr" visible="false" runat="server" >  
                                           <div id="Div7" class="panel-heading subheader" runat="server" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divuntcode','btnCuntcode');return false;"
                          >
                                               <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span>
                     <asp:Label ID="Label22" runat="server"  Text="Unit Code Details" CssClass="subheader" ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnCuntcode" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        </div> 
                          <div id="divuntcode" runat="server" class="panel-body" style="display:block"> 
                                        <asp:UpdatePanel ID="upUnitCode" runat="server">
                                            <ContentTemplate>
                                            <div id="tblUnitCodeDtls" runat="server">
                                                <div class="row" style="margin-bottom:5px;">
                                                 <div class="col-md-3" style="text-align:left">
                                                        <asp:Label ID="lblUntCde" runat="server" Text="Unit Code" CssClass="control-label"></asp:Label>
                                                  </div>
                                                   <div class="col-md-3" style="text-align:left">
                                                        <asp:UpdatePanel ID="upnlBtnUnitCode" runat="server">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="txtUntCode" runat="server" 
                                                                    CssClass="form-control" MaxLength="10"  Visible="false"></asp:TextBox>
                                                                    <asp:Label ID="lblUCode" runat="server"  CssClass="control-label"></asp:Label>
                                                                <asp:Label ID="lblUnitDesc" runat="server" CssClass="control-label"></asp:Label>
                                                                <input id="Hidden1" type="hidden" runat="server" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:Label ID="lblUntCode" runat="server"></asp:Label>
                                                  </div>
                                                 <div class="col-md-6">
                                                    <asp:UpdatePanel ID="upunadr" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                    <asp:Label ID="lblUntAddr" runat="server" Text="" CssClass="control-label"></asp:Label>
                                                    <asp:HiddenField ID="hdnutadr" runat="server" />
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                 </div>
                                            </div>
                                                   <div class="row" style="margin-bottom:5px;">
                                       <%--     <asp:GridView ID="gvUntLst" runat="server" AutoGenerateColumns="false" AllowPaging="true" 
                                                AllowSorting="true" Width="100%" CssClass="table table-striped table-bordered table-hover table-scrollable dataTable" >
                                                <HeaderStyle ForeColor="Black"  />
                                        <RowStyle />
                                        <PagerStyle CssClass="disablepage" />--%>
                                        <asp:GridView  AllowSorting="True" ID="gvUntLst" runat="server" CssClass="footable"
                                                  Visible="false"
                                        AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1"   >
                                        <FooterStyle CssClass="GridViewFooter" />
                                        <RowStyle CssClass="GridViewRowNew" />
                                            <HeaderStyle CssClass="gridview th" />
                                        <PagerStyle CssClass="disablepage" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Unit Code" SortExpression="UnitCode">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUntCode" runat="server" Text='<%# Bind("UnitCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                 
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Description" SortExpression="UnitDesc01">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitDesc" Text='<%#Bind("UnitDesc01") %>' runat="server" />
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Type" SortExpression="UnitTypDesc">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitType" Text='<%#Bind("UnitTypDesc") %>' runat="server" />
                                                        </ItemTemplate>
                                                  
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Address" SortExpression="Adr1" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUntAddr" runat="server" Text='<%# Bind("Adr1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                              </asp:GridView>
                                   </div>
                                            </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                   </div>
                               </div>
                                     
                          
                   </div>
                            </div>
                            </div>
                               <div>
                         <div class="row">
                                <div class="col-md-12" style="text-align:center">
                                   <%-- <asp:Button ID="btnTerminate" runat="server" Text="TERMINATE" CssClass="btn blue"  Width="100px"
                                     onclick="btnTerminate_Click" />--%>
                                          <asp:LinkButton ID="btnTerminate" runat="server"  CssClass="btn btn-sample" 
                           OnClick="btnTerminate_Click"  >
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Terminate
               
                                </asp:LinkButton> &nbsp;&nbsp;
                                    <asp:LinkButton ID="btnApprove" runat="server" CssClass="btn btn-sample"  Visible="false" 
                                   onclick="btnApprove_Click">
                                       <span class="glyphicon glyphicon-ok-circle" style="color:White"> </span> Approve
                                       </asp:LinkButton>
                                       <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-sample"  Visible="false"
                                    onclick="btnReject_Click">
                                       <span class="glyphicon glyphicon-remove-circle" style="color:White"> </span> Reject
                                       </asp:LinkButton>
                                    <%--<asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="btn default" CausesValidation="False" Width="80px"
                                        OnClick="btnCancel_Click"/>--%>
                                          <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-sample" 
                              CausesValidation="false" OnClick="btnCancel_Click">
                                  <span class="glyphicon glyphicon-remove" style="color:White"> </span> Cancel
               
                                </asp:LinkButton> &nbsp;&nbsp
                               </div>
                               
                        </div>
                              <tr>
                                <td>
                                    <input id="hdncurdate" type="hidden" runat="server" />
                                    <input id="hdnAgntRank" type="hidden" runat="server" />
                                    <input id="hdnAgntType" type="hidden" runat="server" />
                                    <input id="hdnAgntLevel" type="hidden" runat="server" />
                                    <input id="hdnAgntClass" type="hidden" runat="server" />
                                    <input id="hdnCSCCode" type="hidden" runat="server" />
                                    <input id="hdnAgnCreateRul" type="hidden" runat="server" />
                                    <input id="hdnUnitRank" type="hidden" runat="server" />
                                    <input id="hdnMicr" type="hidden" runat="server" />
                                    <input id="hdnChkCnt" type="hidden" runat="server" />
                                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                                    <asp:HiddenField ID="hdnPan" runat="server" /> 
               
                                    <input id="hdnEndDate" type="hidden" runat="server" />
                                    <input id="hdnPaymentmode" type="hidden" runat="server" />
                                    <input id="hdnAgentType" type="hidden" runat="server" />
                                    <input id="HdnSlschnl" type="hidden" runat="server" />
                                    <input id="hdnagtcode" type="hidden" runat="server" />
                                    <input id="hdnagtname" type="hidden" runat="server" />
                                    <input id="hdnrptrule" type="hidden" runat="server" />
                                    <input id="hdnemail1" type="hidden" runat="server" />
                                    <input id="hdnmarsts" type="hidden" runat="server" />
                                    <input id="hdnUntCode" type="hidden" runat="server" />
                                    <input id="hdnCltDOB" type="hidden" runat="server" />
                                    <input id="hdnMobTel" type="hidden" runat="server" />
                                    <input id="hdnchn" type="hidden" runat="server" />
                                    <input id="hdnsubchn" type="hidden" runat="server" />
                                    <input id="hdnagttyp" type="hidden" runat="server" />
                                    <input id="hdnmsg" type="hidden" runat="server" />

                                    <input id="hdnPrimType" type="hidden" runat="server" />
                                    <input id="hdnAddl1Type" type="hidden" runat="server" />
                                    <input id="hdnAddl2Type" type="hidden" runat="server" />
                                    <input id="hdnAddl3Type" type="hidden" runat="server" />

                                    <input id="hdnaddl1code" type="hidden" runat="server" />
                                    <input id="hdnaddl2code" type="hidden" runat="server" />
                                    <input id="hdnaddl3code" type="hidden" runat="server" />
                                    <input id="hdnprimcode" type="hidden" runat="server" />

                                    <input id="hdnPriagttyp" type="hidden" runat="server" />
                                    <input id="hdnAddl1agttyp" type="hidden" runat="server" />
                                    <input id="hdnAddl2agttyp" type="hidden" runat="server" />
                                    <input id="hdnAddl3agttyp" type="hidden" runat="server" />

                                    <%--Added by rachana for addditional mgr start--%>
                                    
                                            <input id="hdnCreateRule" type="hidden" runat="server" />
                                            <input id="hdnAppRule" type="hidden" runat="server" />
                                            <input id="hdnEMPCode" type="hidden" runat="server" />
                                        
                                    <asp:UpdatePanel runat="server" ID="upnlUntRule">
                                        <ContentTemplate>
                                            <input id="hdnUntRule" type="hidden" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                     </div>
                    
    </center>
        <asp:Panel runat="server" ID="Panelpop" Width="850" display="none">
        <iframe runat="server" id="Iframepop" width="850" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label8" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlviewpopup" BehaviorID="mdlViewpop"
        DropShadow="true" TargetControlID="Label8" PopupControlID="Panelpop" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel runat="server" ID="pnlMdl" Width="500" Height="300" display="none">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="no" width="500" frameborder="0"
            display="none" style="height: 300px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm">
    
      <!-- Modal content-->
      <div class="modal-content" style='width:400px;height:225px;'>
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl_popup" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>

      <asp:Panel ID="pnl" runat="server" CssClass="modal-content" Width="450px" Height="310px">
        <div class="modal-header" style="text-align: center; background-color: #dff0d8;">
            INFORMATION
        </div>
        <div class="modal-body" style="text-align: center">
            <br />
            <br />
            <asp:Label ID="lbl3" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbl4" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbl5" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <div class="modal-footer" style="text-align: center">
            <asp:LinkButton ID="btnok" runat="server"  CausesValidation="true"
                CssClass="btn btn-sample" OnClick="btnok_Click"> 
                <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK
                </asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server"
                CssClass="btn btn-sample" onclick="lnkCancel_Click">
                <span class="glyphicon glyphicon-remove" style='color:White;'> </span> Cancel
                </asp:LinkButton>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="false" Y="100">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

