<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="View_Document_Details.aspx.cs" Inherits="Application_INSC_Recruit_View_Document_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
<%--    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
<%--    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
<%--    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>--%>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script><link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
  <%--  <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />--%>
<%--    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
  <%--  <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>--%>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        var degrees = 0;
        function brnrotatep() {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";

            if (degrees == 0) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 90) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image180");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 180) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image270");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 270) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image360");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 360) {

                degrees = 0;
                return degrees;
            }
        }
        function brnrotatem() {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";

            if (degrees == 0) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image360");
                degrees = 360;
                return degrees;
            }

            else if (degrees == 360) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image270");
                degrees = 270;
                return degrees;
            }

            else if (degrees == 270) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image180");
                degrees = 180;
                return degrees;
            }

            else if (degrees == 180) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image");
                degrees = 90;
                return degrees;
            }

            else if (degrees == 90) {
                //       img.setAttribute("class", "rotated-image");
                degrees = 0;
                return degrees;
            }
            //            else if (degrees == 90) {
            //                img.setAttribute("class", "rotated-imag");
            //                degrees = 90;
            //                return degrees;
            //            }
        }
        var strContent = "ctl00_ContentPlaceHolder1_";
        form1.onload = function () {
            zoom(1)
        }
        function zoom(zm) {
            debugger;
            img = document.getElementById(strContent + "imgbnd");
            wid = img.width
            ht = img.height
            img.style.width = (wid * zm) + "px"
            img.style.height = (ht * zm) + "px"

            //if ((img.style.width >= '322.2' + 'px')) {
            //    document.getElementById("btnp").disabled = true;
            //}
            //else {
            //    if (document.getElementById("btnp").disabled = true) {
            //        document.getElementById("btnp").disabled = false;
            //    }
            //}

            //if ((img.style.width <= '108' + 'px')) {
            //    document.getElementById("btnm").disabled = true;
            //}
            //else {
            //    if (document.getElementById("btnm").disabled = true) {
            //        document.getElementById("btnm").disabled = false;
            //    }
            //    else
            //    { document.getElementById("btnm").disabled = true; }
            //}
            var img_width = img.style.width;
            img_width=img_width.slice(0, -2); 
            if ((img_width >= 322.2)) {
                document.getElementById("btnp").disabled = true;
            }
            else {
                if (document.getElementById("btnp").disabled = true) {
                    document.getElementById("btnp").disabled = false;
                }
            }

            if ((img_width <= 108.0)) {
                document.getElementById("btnm").disabled = true;
            }
            else {
                if (document.getElementById("btnm").disabled = true) {
                    document.getElementById("btnm").disabled = false;
                }
                else
                { document.getElementById("btnm").disabled = true; }
            }

        }

        function doCancel() {
            
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

        }
        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
        function ShowReqDtl12(divName, btnName) {
            //debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-resize-full'
                    objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-resize-small'
                    objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

   </script>

  <%--  <style type="text/css">  
          .foot--%>
      
        <%--</style>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <div class="container">
       
     <center>
    
                 <div style="overflow: hidden;">
                    <asp:Panel ID="pnlRprt" Width="100%" runat="server" Style="overflow: hidden;">
                        <center>
<%--                       <div class="panel">--%>

         <div class="panel panel-success PanelInsideTab">
             <div id="Div3" runat="server" class="panel-heading" style="display:none" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_idpnlBdy','btnWfParam');return false;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
<%--                                            <asp:Label ID="lblTitle" runat="server" Text="Online Candidate Verification" Font-Size="19px"
                                              ></asp:Label>--%>
                                            <asp:Label ID="lblTitle" runat="server" Text="Online Candidate Verification" CssClass="control-label HeaderColor"
                                              ></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="btnWfParam" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                                color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                   <%-- <tr>
                        <td class="test" align="left" colspan="4">
                            <asp:Label ID="lblTitle" Text="Online Candidate Verification" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>--%>


                      <div id="idpnlBdy" style="display:none" runat="server" class="panel-body">
<%--                  <div id="divSrvcReqReport" style="display: block;" class="panel-body panel-collapse collapse in">--%>
                  <%--<div id="divSrvcReqReport" style="display: block;" class="panel-body panelContent">--%>

<%--                           <div id="tblRpt" runat="server" class="row">--%>
                      <div id="tblRpt" runat="server" class="row rowspacing">
                      
<%--                        <div>--%>
                            <div class="col-md-3" style="text-align: left">

               
                            <asp:Label ID="lblAppNo" Text="Application No"  CssClass="control-label" runat="server"></asp:Label>
                            </div>
                 
                        <div class="col-md-3">

                            <asp:TextBox ID="lblAppNoValue" style="margin-bottom: 5px;"  CssClass="form-control"  runat="server" ></asp:TextBox>
                   </div>
                         <div class="col-md-3"  style="text-align: left">
                            <asp:Label ID="lblCndName"  CssClass="control-label" Text="Candidate Name" runat="server"></asp:Label>
                     </div>
                 
                        <div class="col-md-3" >
                            <asp:TextBox ID="lblAdvNameValue" style="margin-bottom: 5px;"  CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
            
<%--                    </div>--%>
</div>
</div>                  
                    <%--Added by rachana on 29-07-2013 for toggle of agent details start--%>
               <%-- </tbody>
            </table>--%>
            <%--<table id="Table1" style="width: 90%" runat="server">
                <tr>
                    <td align="left" class="test" colspan="4">

                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnUploadDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divagndetails','ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                        <asp:Label ID="lblCnddtls" Text="Candidate Details" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>--%>

            <%--div id="Table1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','ctl00_ContentPlaceHolder1_btnWfParam');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align:left; top: 0px; left: 0px;">
                        <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;">
                        </span>
                        <asp:Label ID="lblCnddtls" runat="server" Font-Bold="True" Height="14px" Font-Size="Small" >Candidate Details</asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-collapse-down" style="float: right;
                            color: #034ea2;padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>--%>
            
                <%--<div class="panel  ">--%>
                    <div class="panel-heading subheader" onclick="ShowReqDtl12('ctl00_ContentPlaceHolder1_divagndetails','Span1');return false;"
                                                   >
                                                    <div class="row" align="left">
                                                        <div class="col-sm-10">
<%--                                                            <asp:Label ID="lblCnddtls" runat="server" Text="Candidate Details" class="subheader" Font-Bold="False"></asp:Label>--%>
                                                            <asp:Label ID="lblCnddtls" runat="server" Text="Candidate Details" CssClass="control-label HeaderColor" Font-Bold="False"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-2">
<%--                                                            <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right; padding: 1px 10px ! important;
                                                                font-size: 18px; color: #034ea2;"></span>--%>
                                                            <span id="Span1" class="glyphicon glyphicon-collapse-up" style="float: right; padding: 1px 10px ! important;
                                                                font-size: 18px; color: #034ea2;"></span>
                                                        </div>
                                                        <%-- <asp:Label ID="Label1" runat="server" CssClass="standardlabel" Font-Bold="True" Text=""></asp:Label>--%>
                                                    </div>
                                                </div>


          <%--  <div runat="server" id="divagndetails" style="display: block">--%>
         <%--  <div id="divagndetails" runat="server" class="panel-body">--%>
<%--          <div id="divagndetails" runat="server" class="panel-body" style="display: block">--%>
          <div id="divagndetails" runat="server" class="panel-body panelContent" style="display: block">
                      <%--<div class="row" align="left">--%>
              <div class="row rowspacing" align="left">
<%--                            <div class="col-md-3"  style="text-align: left">
            
                            <asp:Label ID="lblCndNo" Text="Candidate No"  CssClass="control-label" runat="server" ></asp:Label>
                    </div>
                         <div class="col-md-3" >
                            <asp:TextBox ID="lblCndNoValue" style="margin-bottom: 5px;"  CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                         <div class="col-md-6"  style="text-align: left">
                            <asp:LinkButton ID="lblCndView" runat="server" CssClass="control-label" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                           
                            </div>--%>
                            <div class="col-md-4"  style="text-align: left">
            
                            <asp:Label ID="lblCndNo" Text="Candidate No"  CssClass="control-label" runat="server" ></asp:Label>
                            <asp:TextBox ID="lblCndNoValue" style="margin-bottom: 5px;"  CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
<%--                         <div class="col-md-8"  style="text-align: left">
                            <asp:LinkButton ID="lblCndView" runat="server" CssClass="control-label" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                           
                            </div>--%>
                    <div class="col-md-4" style="text-align: left" >
                            <asp:Label ID="lblBranch"  CssClass="control-label" Text="Branch Name" runat="server" ></asp:Label>
                            <asp:TextBox ID="lblBranchValue" style="margin-bottom: 5px;"  CssClass="form-control" runat="server" ></asp:TextBox>
                        </div>
                         <div class="col-md-4">
                            <asp:Label ID="lblSMName"  CssClass="control-label" Text="Recruiter Name" runat="server" ></asp:Label>
                            <asp:TextBox ID="lblSMNameValue"  style="margin-bottom: 5px;"  CssClass="form-control" runat="server" Font-Bold="False"></asp:TextBox>
                       </div>
                            </div>
        
                           <%--<div class="row" align="left">--%>
              <div class="row rowspacing" align="left">
                   
<%--                    <div class="col-md-3" style="text-align: left" >
                            <asp:Label ID="lblBranch"  CssClass="control-label" Text="Branch Name" runat="server" ></asp:Label>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="lblBranchValue" style="margin-bottom: 5px;"  CssClass="form-control" runat="server" ></asp:TextBox>
                       </div>
                         <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblSMName"  CssClass="control-label" Text="Recruiter Name" runat="server" ></asp:Label>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="lblSMNameValue"  style="margin-bottom: 5px;"  CssClass="form-control" runat="server" Font-Bold="False"></asp:TextBox>
                        </div>--%>
<%--                    <div class="col-md-4" style="text-align: left" >
                            <asp:Label ID="lblBranch"  CssClass="control-label" Text="Branch Name" runat="server" ></asp:Label>
                            <asp:TextBox ID="lblBranchValue" style="margin-bottom: 5px;"  CssClass="form-control" runat="server" ></asp:TextBox>
                        </div>
                         <div class="col-md-4">
                            <asp:Label ID="lblSMName"  CssClass="control-label" Text="Recruiter Name" runat="server" ></asp:Label>
                            <asp:TextBox ID="lblSMNameValue"  style="margin-bottom: 5px;"  CssClass="form-control" runat="server" Font-Bold="False"></asp:TextBox>
                       </div>--%>
                         <div class="col-md-4" style="text-align: left">
                             <asp:Label ID="lblProcessType" runat="server"  CssClass="control-label"  Text="Process Type"></asp:Label>
                                <%--<span style="color: #CC0000">*</span>&nbsp;--%>
                            <asp:DropDownList ID="ddlProcessType" style="margin-bottom: 5px;"  runat="server" CssClass="form-control" BorderColor="Red" OnSelectedIndexChanged="ddlProcessType_SelectedIndexChanged" AutoPostBack="true"
                                           /> 
                        </div>
                         <div class="col-md-4" style="text-align: left">
                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" CssClass="control-label"  runat="server" ></asp:Label>
                            <asp:TextBox ID="lblSponsorDtValue" style="margin-bottom: 5px;"  CssClass="form-control"  runat="server" ></asp:TextBox>

                        </div>
                         <div class="col-md-4" style="text-align: left">
                             <br />
                            <asp:LinkButton ID="lblCndView" runat="server" CssClass="control-label" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                        </div>
              </div>
<%--              <div class="row rowspacing" align="left">--%>
<%--                   <div class="col-md-3" style="text-align: left">
                             <asp:Label ID="lblProcessType" runat="server"  CssClass="control-label"  Text="Process Type"></asp:Label>
                                <span style="color: #CC0000">*</span>&nbsp;
                         </div>
                         <div class="col-md-3">
                            <asp:DropDownList ID="ddlProcessType" style="margin-bottom: 5px;"  runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProcessType_SelectedIndexChanged" AutoPostBack="true"
                                           /> 
                       </div>
                         <div class="col-md-3" style="text-align: left">
                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" CssClass="control-label"  runat="server" ></asp:Label>
                        </div>
                         <div class="col-md-3">
                            <asp:TextBox ID="lblSponsorDtValue" style="margin-bottom: 5px;"  CssClass="form-control"  runat="server" ></asp:TextBox>
                       </div>--%>
<%--                         <div class="col-md-4" style="text-align: left">
                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" CssClass="control-label"  runat="server" ></asp:Label>
                            <asp:TextBox ID="lblSponsorDtValue" style="margin-bottom: 5px;"  CssClass="form-control"  runat="server" ></asp:TextBox>

                        </div>--%>
<%--                </div>--%>
            </div>
            <%--</div>--%>
          <%--</div>--%>
         
          <%--</div>--%>
   
      
        <br />
       <%-- <div id="divnavigate" runat="server" visible="false">
            <table id="tblphoto" runat="server" style="width: 90%;">
                <tr>--%>
                    <%--<td class="formcontent" align="center">
                    </td>--%>
                    <div id="divnavigate" runat="server" visible="false" class="row" style="margin-top: 12px;">
                       <div class="col-md-3" style="margin-bottom: 5px;">
                   <%-- <td class="formcontent" align="center">--%>
                    <%--    <asp:Button ID="BtnDownload" runat="server" Text="Download" CssClass="standardbutton"
                             Width="100px" onclick="BtnDownload_Click"></asp:Button>--%>
<%--                             <asp:LinkButton ID="BtnDownload" OnClick="BtnDownload_Click" CssClass="btn btn-sample"
                                    runat="server">--%>
                             <asp:LinkButton ID="BtnDownload" OnClick="BtnDownload_Click" CssClass="btn btn-success"
                                    runat="server">
                                 <span class="glyphicon glyphicon-download-alt" style="color:White"> </span> Download
                                </asp:LinkButton>
                                </div>
                 <%--   </td>--%>

                   <div class="col-md-3" style="margin-bottom:5px;">
<%--                    <asp:LinkButton ID="BtnDwnldAll" OnClick="BtnDwnldAll_Click" TabIndex="43" CssClass="btn btn-sample"
                                    runat="server">--%>
                    <asp:LinkButton ID="BtnDwnldAll" OnClick="BtnDwnldAll_Click" TabIndex="43" CssClass="btn btn-success"
                                    runat="server">
                                 <span class="glyphicon glyphicon-download" style="color:White"> </span> Download All
                                </asp:LinkButton>
                                </div>
                   <%-- <td class="formcontent" align="center" style="text-align:center">
                        <asp:Button ID="BtnDwnldAll" TabIndex="43" runat="server" Text="Download All"
                            CssClass="standardbutton" Width="100px" onclick="BtnDwnldAll_Click" ></asp:Button>
                    </td>
                   --%>
                   <div class="col-md-3" style="margin-bottom:5px;">
                  <%--  <td class="formcontent" align="center"  style="text-align:center">--%>
                    
                        <asp:updatepanel runat="server">
                    <contenttemplate>
<%--                      <asp:LinkButton ID="btnprev" OnClick="btnprev_Click" CssClass="btn btn-sample"
                                    runat="server">--%>
                      <asp:LinkButton ID="btnprev" OnClick="btnprev_Click" CssClass="btn btn-clear"
                                    runat="server">
<%--                                 <span class="glyphicon glyphicon-step-backward" style="color:White"> </span> Prev--%>
                                 <span class="glyphicon glyphicon-step-backward" style="color:#00cccc"> </span> Prev
                                </asp:LinkButton>
                 <%--   <asp:Button ID="btnprev" runat="server" Text="Prev" CssClass="standardbutton" 
                            Width="100px" OnClick="btnprev_Click"></asp:Button>--%>
                            </contenttemplate>
                       </asp:updatepanel>
                 
                    </div>
                   <div class="col-md-3" style="margin-bottom:5px;">
                      <asp:updatepanel runat="server">
           <contenttemplate>  
<%--         <asp:LinkButton ID="btnnext" OnClick="btnnext_Click" CssClass="btn btn-sample"
                                    runat="server">--%>
         <asp:LinkButton ID="btnnext" OnClick="btnnext_Click" CssClass="btn btn-clear"
                                    runat="server">
<%--                                 <span class="glyphicon glyphicon-step-forward" style="color:White"> </span> Next--%>
                                 <span class="glyphicon glyphicon-step-forward" style="color:#00cccc"> </span> Next
                                </asp:LinkButton>
               <%--   <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="standardbutton" 
                            Width="100px" OnClick="btnnext_Click"></asp:Button>--%>
                            </contenttemplate>
              </asp:updatepanel>
                  </div>
                    </div>
                   
               <%-- </tr>
            </table>
        </div>
       --%>
    <%--    <asp:Panel ID="Panelphoto2" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
            BorderWidth="2px"  Visible="true" class="modalpopupmesg" ScrollBars="Vertical" >--%>
            <%-- <asp:Panel ID="Panelphoto2" runat="server" Visible="true" class="modalpopupmesg" ScrollBars="Vertical" >--%>
          
              <asp:Panel ID="Panelphoto2" runat="server" Style="display: none;">
                 <center>

            <asp:UpdatePanel runat="server" ID="upnlHeader">
                <ContentTemplate>
                 <div class="panel  " id="divAlert" runat="server" style="width:90%;
                display: block;" cellpadding="0" cellspacing="0"> <%-- border: 2px;  background-color: white; border: solid;
                border-color: Green; border-width: 2px;"--%>
                <%--<div id="Div2" runat="server" style="width:95% !important; border:2px solid  black" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                            <div class="row" id="trDetails" runat="server">
                                 <div class="col-sm-10"  style="text-align: center">
                                   d    <center>
                                        <asp:Label ID="lblpanelheader" runat="server" Font-Bold="true" style="font-size:16px"></asp:Label>
                                        <asp:HiddenField ID="hdnDocId" runat="server" />
                              </center>
                                </div>
                            </div>
                   </div>--%>
                   <%-- <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblpanelheader" runat="server" CssClass="standardlink " />
                                <asp:HiddenField ID="hdnDocId" runat="server" />
                            </td>
                        </tr>
                    </table>--%>
                    <div class="modalpanel" style="display: none">
                        <%--<div class="row">--%>
                        <div class="row rowspacing">
                                <asp:Image ID="imgCrop" runat="server" />
                            </div>
                    </div>
                    <div id="divgrid" runat="server" class="panel-body">
                    <%--<div id="divgrid" runat="server" style="width: 100%; height: 100%; overflow: hidden">--%>
                      <%--  <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;
                            width: 100%;" class="tableIsys">
                            <tr>
                                <td>--%>
                        <div style="width:100% !important; border-bottom: .5px solid #034ea2;margin-bottom:20px">
                            <center style="color:#034ea2; font-size:16px">
                                <asp:Label ID="lblpanelheader" runat="server" Font-Bold="true" style="font-size:16px; font-weight:bold"></asp:Label>
                                    <asp:HiddenField ID="hdnDocId" runat="server" />
                            </center>
                        </div>
<%--                                    <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="footable"
                                      
                                         AutoGenerateColumns="False" 
                                        AllowPaging="True"  OnPageIndexChanging="GridImage_PageIndexChanging" OnRowDataBound="GridImage_RowDataBound" >--%>
                                    <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="footable"
                                      
                                         AutoGenerateColumns="False" 
                                        AllowPaging="True"  OnPageIndexChanging="GridImage_PageIndexChanging" OnRowDataBound="GridImage_RowDataBound" >
                                    <%--     <FooterStyle CssClass="GridViewFooter" />--%>
                                       <%-- <RowStyle CssClass="GridViewRow" />--%>
                                        <%--<PagerStyle CssClass="GridViewPager"></PagerStyle>CssClass="footable" --%>
                                      <%--  <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow"></AlternatingRowStyle>--%>
                                     <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                        <Columns>
                                           
                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>'></asp:HiddenField>
                                                     <asp:HiddenField ID="hdnServerFileName" runat="server" Value='<%# Eval("ServerFileName") %>'>
                                                     </asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:ImageField DataImageUrlField="ID" DataImageUrlFormatString="ImageCSharp.aspx?ImageID={0}" ItemStyle-HorizontalAlign="Center" 
                                                HeaderText="Preview Image" >
                                              
                                            </asp:ImageField>
                                        </Columns>
                                      <%--  <RowStyle CssClass="sublinkeven" BackColor="#78A8FA"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>--%>
                                    </asp:GridView>
                                <%--</td>
                            </tr>
                            <tr>--%>
                               <%-- <td>--%>
                               <div class="row" align="left">
                                   <div class="col-md-3" style="margin-bottom: 5px;">
                                    <iframe id="FrmImg" runat="server" visible="false"></iframe>
                                    </div>
                                    </div>
                              <%--  </td>
                            </tr>
                        </table>--%>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnnext" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
                </center>  
        </asp:Panel>
        
       

           <div ID="SeaCan" runat="server">

                                <div align="center" class="col-sm-12">
<%--                                    <asp:LinkButton ID="BtnSearch" runat="server" CssClass="btn btn-sample" 
                                        OnClick="BtnSearch_click">--%>
                                    <asp:LinkButton ID="BtnSearch" runat="server" CssClass="btn btn-success" 
                                        OnClick="BtnSearch_click">
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                                </asp:LinkButton>
                                    <asp:LinkButton ID="btnedit" runat="server" CssClass="btn btn-success" 
                                        OnClick="btnedit_Click">
                                 <span class="glyphicon glyphicon-edit BtnGlyphicon"> </span> Edit image
                                </asp:LinkButton>
<%--                                    <asp:LinkButton ID="btncancel" runat="server" CssClass="btn btn-sample" 
                                      OnClientClick="doCancel();return false;" >--%>
                                    <asp:LinkButton ID="btncancel" runat="server" CssClass="btn btn-clear" 
                                      OnClientClick="doCancel();return false;" >
                                 <span class="glyphicon glyphicon-remove" style="color:#00cccc"></span> Cancel
                                </asp:LinkButton>
                                </div>

                                 <div align="center" class="col-sm-12">
                                   <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" CssClass="control-label"></asp:Label>
                                 </div>
                            </div>
        <%--<div id="SeaCan" runat="server">
         <table style="width: 90%">
             <tbody>
                      <tr >
                    
               
                     <td style="height:20px; padding-top:10px"  align="center" colspan="4">
                           
                            <asp:Button ID="BtnSearch"  runat="server" Text="Search" onClick="BtnSearch_click"
                                CssClass="standardbutton" Width="80px"></asp:Button>
                               
                            &nbsp;&nbsp;
                            <asp:Button ID="btncancel"  runat="server" Text="Cancel" CssClass="standardbutton"
                                Width="80px" OnClientClick="doCancel();return false;"></asp:Button>ss
                                </td>
                  
                    </tr>
                      <tr>
                            <td class="formcontent2" align="center" colspan="4">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" CssClass="standardlabelC"></asp:Label>
                            </td>
                        </tr>
                </tbody>
            </table>
        </div>--%>
<%--       </div>--%>
       </div>
        </center>
                   </asp:Panel>
    </div>
                    
         </center>
     </div>
       
<%--    </center>
  
      </div>--%>
  
    <%--Loader popup start--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: Grey;">
        <center>
            <img src="../../../App_Themes/Isys/images/spinner.gif" />
            <br />
            <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
        </center>
    </asp:Panel>
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdnCndNo" runat="server" />
            </td>
        </tr>
    </table>
    <%--Loader popup end--%>
    <%--  new added popup--%>
<%--    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="75%" Height="100%" Style="display: none;">--%>
<%--        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px;">
                    <b>
                        <asp:Label runat="server" ID="lbltitle1" Text=""></asp:Label></b>
                </td>
            </tr>
        </table>--%>
<%--        <center>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div id="divimage" runat="server" style="position: fixed; z-index: 3000; padding-left: 250px">
                        <center>
                            <asp:Image ID="imgbnd" runat="server" Height="250px" Width="250px" Style="position: fixed;
                                z-index: 3000;" />--%><%--Height="200px" Width="250px"--%>
<%--                        </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>--%>
<%--        <center>
            <div style="position: fixed; z-index: 3000; text-align: center; padding-top: 350px;
                padding-left: 265px;">
                <asp:Label ID="lblpopup" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="-" onclick="zoom(0.9)" id="btnm" name="btnm"  />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="+" onclick="zoom(1.1)" id="btnp" name="btnp"  />&nbsp;&nbsp;&nbsp;&nbsp;--%>
     <%--           <input type="button"  id="btnrp1" name="btnrp" onclick="brnrotatep()"/>--%>
<%--                 <img src="../../../theme/iflow/aa.png" height="22px" width="22px"  id="btnrp" name="btnrp" onclick="brnrotatep()"/> --%>
                <%--</button>--%><%--value="Rotate+"--%>
         <%--       <input type="button"  id="btnrm" name="btnrm" onclick="brnrotatem()" /> --%>
<%--         &nbsp;&nbsp;&nbsp;&nbsp;--%>

                
<%--                <img  src="../../../theme/iflow/bb.png" height="22px" width="22px"  id="btnrm" name="btnrm" onclick="brnrotatem()"/> --%>
                
                <%--value="Rotate-"--%>
<%--                <div style="padding-top: 10px;">
                   &nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;    <asp:Button ID="btnok" runat="server" Text="Cancel" Width="100px"  Height="25px" CssClass="standardbutton" />&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
            </div>
        </center>--%>
<%--    </asp:Panel>--%>
<%--    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        OkControlID="btnok">
    </ajaxToolkit:ModalPopupExtender>--%>
<%--<div style="overflow: hidden;">
    <div class="panel panel-success PanelInsideTab">--%>
        <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="0.5px" class="modalpopupmesg" Width="75%" Height="100%" Style="display: none; background-color:white">
           <div class="row" align="left">
                <div class="col-sm-10">
                     <asp:Label ID="lbltitle1" runat="server" Text="" CssClass="control-label HeaderColor" Font-Bold="False"></asp:Label>
                </div>
           </div>
        <center>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div id="divimage" runat="server" style="position: fixed; z-index: 3000; padding-left: 250px">
                        <center>
                            <asp:Image ID="imgbnd" runat="server" Height="250px" Width="250px" Style="position: fixed;
                                z-index: 3000;" /><%--Height="200px" Width="250px"--%>
                        </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
        <center>
            <%--<div style="position: fixed; z-index: 3000; text-align: center; padding-top: 350px;--%>
            <div style="position: fixed; z-index: 3000; text-align: center; padding-top: 350px;
                padding-left: 265px;">
<%--                <asp:Label ID="lblpopup" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                <div align="center" class="col-sm-12">
                <asp:Label ID="lblpopup" runat="server"></asp:Label>
                    </div>
                <div align="center" class="col-sm-12">
<%--                    <a onclick="zoom(0.9)"   style="width:40px;height:32px"  id="btnm" name="btnm" class="btn btn-clear">
                        <span class="glyphicon glyphicon-zoom-out" style="color:#00cccc"></span>
                    </a>--%>
                    <input type="button" value="-" style="width:40px;height:32px" onclick="zoom(0.9)" id="btnm" name="btnm" class="btn btn-clear" />
                    <input type="button" value="+" style="width:40px;height:32px" onclick="zoom(1.1)" id="btnp" name="btnp" class="btn btn-success" />
                <%--<input type="button" value="-" onclick="zoom(0.9)" id="btnm" name="btnm"  />&nbsp;&nbsp;&nbsp;&nbsp;--%>
                <%--<input type="button" value="" onclick="zoom(0.9)" id="btnm" name="btnm" class="btn btn-success" />--%>
<%--                <input type="button" value="" onclick="zoom(1.1)" id="btnp" name="btnp"  />&nbsp;&nbsp;&nbsp;&nbsp;--%>
<%--                    <a onclick="zoom(1.1)"   style="width:40px;height:32px"  id="btnp" name="btnp" class="btn btn-success">
                        <span class="glyphicon glyphicon-zoom-in" style="color:white"></span>
                    </a>--%>
                    <a onclick="brnrotatep()"   style="width:40px;height:32px"  id="btnrp" name="btnrp" class="btn btn-clear">
                        <span class="glyphicon glyphicon-repeat" style="color:#00cccc;transform: scaleX(-1)"></span>
                    </a>
                    <a onclick="brnrotatem()"   style="width:40px;height:32px"  id="btnrm" name="btnrm" class="btn btn-success">
                        <span class="glyphicon glyphicon-repeat" style="color:white"></span>
                    </a>
<%--                <input type="button" value="" onclick="zoom(1.1)" id="btnp" name="btnp"  class="btn btn-success"/>&nbsp;&nbsp;&nbsp;&nbsp;--%>
     <%--           <input type="button"  id="btnrp1" name="btnrp" onclick="brnrotatep()"/>--%>
                 <%--<img src="../../../theme/iflow/aa.png" height="22px" width="22px"  id="btnrp" name="btnrp" onclick="brnrotatep()"/> --%>
                    <%--</button>--%><%--value="Rotate+"--%>
         <%--       <input type="button"  id="btnrm" name="btnrm" onclick="brnrotatem()" /> --%>
         <%--&nbsp;&nbsp;&nbsp;&nbsp;--%>

                
                <%--<img  src="../../../theme/iflow/bb.png" height="22px" width="22px"  id="btnrm" name="btnrm" onclick="brnrotatem()"/> --%>
                
                <%--value="Rotate-"--%>
<%--                <div style="padding-top: 10px;">
                   &nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;    <asp:Button ID="btnok" runat="server" Text="Cancel" Width="100px"  Height="25px" CssClass="standardbutton" />&nbsp;&nbsp;&nbsp;&nbsp;
                </div>--%>
<%--                  <asp:Button ID="btnok" runat="server" Text="Cancel" Width="100px"  Height="32px" CssClass="btn btn-clear" />--%>
                  <button type="button" id="btnok" runat="server" width="100px"  height="32px" class="btn btn-clear">
                      <span class="glyphicon glyphicon-remove" style="color:#00cccc">Cancel</span>
                      </button>
                    </div>
            </div>
        </center>
</asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        OkControlID="btnok">
    </ajaxToolkit:ModalPopupExtender>
<%--</div>
    </div>--%>
       
</asp:Content>


