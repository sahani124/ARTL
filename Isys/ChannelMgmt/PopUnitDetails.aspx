<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopUnitDetails.aspx.cs" Inherits="Application_ISys_ChannelMgmt_PopUnitDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../../../KMI%20Styles/Bootstrap/css/.min.css" rel="stylesheet"
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
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>




    <style type="text/css">
        .btn-subtab {
            color: white;
            background-color: #034ea2 !important;
            border-color: white;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

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

        function funValidate() {
            var strContent = "ctl00_ContentPlaceHolder1_";



            if (SpaceTrim(document.getElementById(strContent + "txtRemark").value) == "") {
                alert("Please Enter Remarks");
                document.getElementById(strContent + "txtRemark").focus();

                return false;
            }

           

        }

        function addCssClassByClick(flag) {
            debugger;


            if (flag == 1) {

                $("#ctl00_ContentPlaceHolder1_Primary").addClass(" btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Additional").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Member").removeClass("btn-subtab")

            }

            else if (flag == 2) {
                $("#ctl00_ContentPlaceHolder1_Primary").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Additional").addClass("btn-subtab btn btn-default")
                $("#ctl00_ContentPlaceHolder1_Member").removeClass("btn-subtab")

            }

            else if (flag == 3) {
                $("#ctl00_ContentPlaceHolder1_Primary").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Additional").removeClass("btn-subtab")
                $("#ctl00_ContentPlaceHolder1_Member").addClass("btn-subtab btn btn-default")

            }



        }


        var path = "<%=Request.ApplicationPath.ToString()%>";


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

    </script>
    <script type="text/javascript" src="~/Scripts/common.js"></script>
    <script type="text/javascript" src="~/Scripts/subModal.js"></script>
    <script type="text/javascript" src="~/Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" src="~/Scripts/jsAgtCheck.js" type="text/javascript"></script>
    <script language="javascript" src="../../../Scripts/jQuery_1.X.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <style type="text/css">
        .ajax__calendar {
            position: static;
        }

        .pagelink span {
            font-weight: bold;
        }
        /*Added: Parag @ 25032014*/

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }
    </style>

    <style>
        /*#myModal{
            position:absolute;
            margin:0px auto;
            top:10%;
            z-index:999999999;
        }*/
    </style>

    <script type="text/javascript" language="javascript">

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


        function ShowReqDtl1(divName, btnName) {
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

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        function funOpenPopWinForUntCode(strPageName, strUnitCode, strOutUntCode, strOutUntDesc, strSource) {
            showPopWin(strPageName + "?UnitCode=" + strUnitCode + "&OutUntCode=" + strOutUntCode + "&OutUntDesc=" + strOutUntDesc + "&Source=" + strSource, 450, 400, null);
            return false;
        }
    </script>

    <div class="container">

        <center>
                <asp:Label ID="lblmsg" runat="server" Width="430px" Font-Bold="false" ForeColor="Red"> </asp:Label>
               
                               <%-- <table class="formtable" width="100%">--%>
                                   <%-- <tr>
                                        <td class="test formHeader" align="left" colspan="4">
                                            <input runat="server" type="button" class="inputBtn" value="-" id="btnUnitParticularcollapse"
                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div_UnitDtl1','ctl00_ContentPlaceHolder1_btnUnitParticularcollapse');" />
                                            <asp:Label ID="lblUntPart" runat="server" Text="Unit Particular" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>--%>
                                <%--</table>--%>

                              <%--  <div ID="div1" runat="server" class="divBorder1" style="width: 98%;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                               
                                &nbsp;<asp:Label ID="lblUntPart" Text="Unit Particular" runat="server" 
                                    Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div_UnitDtl1','Img1','#Img1');" />
                            </td>
                        </tr>
                    </table>--%>

                    <div class="panel ">
                <div id="div1" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div_UnitDtl1','btnpersnl');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblUntPart" Text="Unit Particular" runat="server"  Font-Size ="19px"
                                    ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="btnpersnl" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                 </div>
                                <div id="div_UnitDtl1" style="display:block;" runat="server" class="panel-body">
                                     <div class="row" style="margin-bottom:5px;">
                                    <div class="col-sm-3" style="text-align:left">
                                     <asp:Label ID="lblUnitName" runat="server" CssClass="control-label"></asp:Label>
                                     </div>
                                    <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUnitName" CssClass="form-control" Enabled="false"  runat="server"></asp:TextBox>
                                                </div>
                                           
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblSalesChnl" CssClass="control-label" runat="server"></asp:Label>
                                                </div>

                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblSalesChannel" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                <input id="lblValSalesCCode" runat="server" class="standardlabel" style="width: 78px;"
                                                    type="hidden" />
                                                    </div>
                                           </div>
                                             <div class="row" style="margin-bottom:5px;">
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblChnnlSubClass" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                           
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValChnSubclass" runat="server" Enabled="false" CssClass="form-control" > </asp:TextBox>
                                                </div>
                                           
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblUntCode" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                           
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUnitCode" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                                </div>
                                           </div>
                                                  <div class="row" style="margin-bottom:5px;">
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblrefcode" CssClass="control-label" runat="server"></asp:Label>
                                                </div>

                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValInsRefCode" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                                </div>
                                          
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblUntType" CssClass="control-label" runat="server"></asp:Label>
                                                <span style="font-size: 10pt"></span>
                                                </div>
                                           
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUnitType" runat="server" Enabled="false" CssClass="form-control"  > </asp:TextBox>
                                                </div>
                                           </div>
                                               <div class="row" style="margin-bottom:5px;">
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblUnitStatus" CssClass="control-label" runat="server"></asp:Label>
                                              
                                          </div>
                                           <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUnitStat" runat="server" Enabled="false" CssClass="form-control" > </asp:TextBox>
                                           </div>
                                          
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblSalesUnt" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                            <div class="col-sm-3">
                                                <asp:RadioButtonList ID="rdlYesNo" runat="server" Enabled="false" RepeatDirection="Horizontal" style='margin-right:200px;'
                                                    >
                                                    <asp:ListItem Text="Yes&nbsp&nbsp&nbsp&nbsp&nbsp" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                                </div>
                                                </div>
                                                      <div class="row" style="margin-bottom:5px;">
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblUntMgrCode" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                           
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUnitMGRCode" runat="server" Enabled="false" CssClass="form-control"   MaxLength="10"
                                                    ></asp:TextBox>
                                            </div>
                                            
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblUntDesc1" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                            
                                             <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUntDesc1" runat="server" Enabled="false" CssClass="form-control"  MaxLength="100"
                                                   ></asp:TextBox>
                                                    </div>
                                           </div>
                                                   <div class="row" style="margin-bottom:5px;">
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblCmpUntCode" CssClass="control-label" runat="server"> </asp:Label>
                                                </div>
                                           
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValCompanyUnitCode" runat="server" Enabled="false" CssClass="form-control"   MaxLength="10"
                                                   ></asp:TextBox>
                                                    </div>
                                            
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblUntDesc2" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                           
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUntDesc2" runat="server" Enabled="false" CssClass="form-control"    MaxLength="100"
                                                    ></asp:TextBox>
                                                    </div>
                                                    </div>
                                                          <div class="row" style="margin-bottom:5px;">
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblUntDesc3" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                            <div class="col-sm-3">
                                                <asp:TextBox ID="lblValUntDesc3" runat="server" Enabled="false" CssClass="form-control"   MaxLength="100"
                                                    ></asp:TextBox>
                                                    </div>
                                            </div>
                                </div>

                                </div>

                                <br />
                                
                                
                                
                                
                                
                               <%-- <table class="formtable" width="100%">
                                    <tr>
                                        <td align="left" class="test formHeader" colspan="4">
                                            <input runat="server" type="button" class="inputBtn" value="-" id="btnUnitContactDtlscollapse"
                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div_UnitContact','ctl00_ContentPlaceHolder1_btnUnitContactDtlscollapse');" />
                                            <asp:Label ID="lblUntCnctI" runat="server" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>--%>


                    <%-- <div ID="div2" runat="server" class="divBorder1" style="width: 98%;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                               
                                &nbsp;<asp:Label ID="lblUntCnctI" runat="server" 
                                    Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div_UnitContact','Img2','#Img2');" />
                            </td>
                        </tr>
                    </table>--%>

                   
                   <div class="panel ">
                <div id="div2" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div_UnitContact','Span1');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                     <asp:Label ID="lblUntCnctI" runat="server" Font-Size ="19px"
                                  ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                </div>                            
                             <div id="div_UnitContact" style="display:block;" runat="server" class="panel-body">
                                  <div class="row" style="margin-bottom:5px;">
                                      <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblEmail" CssClass="control-label"  runat="server"></asp:Label>
                                            </div>
                                                
                                                  <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValEMail" runat="server" CssClass="form-control"   Enabled="false"  MaxLength="50"
                                                    ></asp:TextBox>
                                                    </div>
                                            
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblOffTel" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                           
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValOTel" runat="server" CssClass="form-control"   Enabled="false"  MaxLength="20"
                                                    ></asp:TextBox>
                                           </div>
                                              </div>
                                                <div class="row" style="margin-bottom:5px;">
                                                <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblFax" CssClass="control-label"  runat="server"></asp:Label>
                                           </div>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValFax" runat="server" CssClass="form-control"   Enabled="false"  MaxLength="20"
                                                    ></asp:TextBox>
                                                    </div>
                                          
                                                
                                           
                                         <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblpfAddrP1" runat="server" CssClass="control-label"></asp:Label>
                                           </div>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValAddrP1" runat="server" CssClass="form-control"   Enabled="false" Font-Bold="False"
                                                    ></asp:TextBox>
                                                    </div>
                                                </div>     
                                                       <div class="row" style="margin-bottom:5px;"> 
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblpfStateP" runat="server" CssClass="control-label"></asp:Label>
                                                </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValState" runat="server" CssClass="form-control"   Enabled="false" ></asp:TextBox>
                                                </div>
                                           
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblpfAddrP2" runat="server" CssClass="control-label"></asp:Label>
                                                </div>
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValAddrP2" runat="server" CssClass="form-control"   Enabled="false"  Font-Bold="False"
                                                    ></asp:TextBox>
                                                    </div>
                                                    </div>
                                                       <div class="row" style="margin-bottom:5px;"> 
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblDistP" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValDistP" runat="server" CssClass="form-control"   Enabled="false"  Font-Bold="False"
                                                    MaxLength="50" ReadOnly="false"></asp:TextBox>
                                                <asp:HiddenField ID="hdnDist" runat="server" />
                                                <asp:HiddenField ID="hdnPinFrom" runat="server" />
                                                <asp:HiddenField ID="hdnPinTo" runat="server" />
                                                </div>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblpfAddrP3" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValAddrP3" runat="server" CssClass="form-control"   Enabled="false" Font-Bold="False"
                                                    MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();"
                                                    ></asp:TextBox>
                                                    </div>
                                                    </div>
                                                           <div class="row" style="margin-bottom:5px;"> 
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblarea" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValarea" runat="server" CssClass="form-control"   Enabled="false"  Font-Bold="False"
                                                    MaxLength="50" ReadOnly="false"></asp:TextBox>
                                                    </div>
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblVillage" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                             <div class="col-sm-3" style="text-align:left">
                                               
                                                        <asp:TextBox ID="lblValVillage" runat="server" CssClass="form-control"   Enabled="false"  Font-Bold="False"
                                                            MaxLength="30" onChange="javascript:this.value=this.value.toUpperCase();"
                                                            ></asp:TextBox>
                                                 
                                          </div>
                                          </div>
                                                  <div class="row" style="margin-bottom:5px;"> 
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblpfPinP" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValPinP" runat="server" CssClass="form-control"   Enabled="false"  Font-Bold="False"
                                                    MaxLength="6" ></asp:TextBox>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblcityp" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblValcityp" runat="server" CssClass="control-label"  Font-Bold="False"
                                                    MaxLength="50" ReadOnly="false"></asp:Label>
                                                    </div>
                                                    </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblpfCountryP" CssClass="control-label"  runat="server"></asp:Label>
                                            </div>
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValCountryDescP" runat="server" CssClass="form-control"   Enabled="false"  Text="INDIA"></asp:TextBox>
                                                </div>
                                           </div>
                                              <div class="row" style="margin-bottom:5px;"> 
                                         <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblAddress" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                         
                                                 <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValAddress1" runat="server" CssClass="form-control"   Enabled="false"  MaxLength="100"></asp:TextBox>
                                                </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblPostCode" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValPOstCode" runat="server" CssClass="form-control"   Enabled="false"  MaxLength="10"></asp:TextBox>
                                                </div>
                                           </div>
                                               <div class="row" style="margin-bottom:5px;"> 
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblAddress2" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                                  <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValAddress2" runat="server" CssClass="form-control"   Enabled="false"  MaxLength="100"></asp:TextBox>
                                            </div>
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblCity" CssClass="control-label"  runat="server"></asp:Label>
                                                </div>
                                           
                                                <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValCity" runat="server" CssClass="form-control"   Enabled="false"  MaxLength="100"></asp:TextBox>
                                                </div>
                                            </div>
                                              <div class="row" style="margin-bottom:5px;"> 
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblAddress3" CssClass="control-label" runat="server"></asp:Label>
                                                </div>
                                                  <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblValAddress3" runat="server" CssClass="form-control"   Enabled="false" MaxLength="100"></asp:TextBox>
                                                </div>
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblLocn" CssClass="control-label" runat="server" Font-Bold="false"></asp:Label>
                                                </div>
                                            <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblLatitude" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                                                </div>
                                                </div>
                                                       <div class="row" style="margin-bottom:5px;"> 
                                             <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblValLatitude" runat="server" CssClass="control-label" MaxLength="100"
                                                   ></asp:Label>
                                                    </div>
                                           <div class="col-sm-3" style="text-align:left">
                                                <asp:TextBox ID="lblLongitude" CssClass="form-control"   Enabled="false" runat="server"></asp:TextBox>
                                                </div>
                                              <div class="col-sm-3" style="text-align:left">
                                                <asp:Label ID="lblValLongitude" runat="server" CssClass="control-label" MaxLength="20"
                                                    ></asp:Label>
                                                    </div>
                                           </div>
                                </div>
                                
                                 
                                 </div>
                                 <br />
                                
                               <%-- <table class="formtable" width="100%">
                                    <tr>
                                        <td class="test formHeader" align="left" colspan="4">
                                            <input runat="server" type="button" class="inputBtn" value="-" id="btnReportingcollapse"
                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div_UnitDtl2','ctl00_ContentPlaceHolder1_btnReportingcollapse');" />
                                            <asp:Label ID="lblRptTitle" runat="server" Text="Reporting Details" Font-Bold="true"></asp:Label>
                                    </tr>
                                </table>--%>


                               <%-- <div ID="div3" runat="server" class="divBorder1" style="width: 98%;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                
                                &nbsp;<asp:Label ID="lblRptTitle" runat="server" Text="Reporting Details"
                                    Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img3" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div_UnitDtl2','Img3','#Img3');" />
                            </td>
                        </tr>
                    </table>--%>

                     <div class="panel ">
                <div id="div3" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div_UnitDtl2','Span2');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    <asp:Label ID="lblRptTitle" runat="server" Text="Reporting Details" Font-Size ="19px"
                                   ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>            
                             
                                
                                <div id="div_UnitDtl2" style="display:block;" runat="server" class="panel-body">
                                    
                                                        <asp:ImageButton ID="lnkCrntPrimMgr" runat="server" CssClass="TextBox" BackColor="transparent"
                                                            ImageUrl="~/theme/iflow/PrimRptng.png" Text="Primary Manager" OnClick="lnkCrntPrimMgr_Click" Visible="false" />
                                                        <asp:ImageButton ID="lnkCrntAddlMgr" runat="server" CssClass="TextBox" BackColor="transparent"
                                                            ImageUrl="~/theme/iflow/AddlRptng.png" Text="Addl. Managers" OnClick="lnkCrntAddlMgr_Click" Visible="false" />
                                                        <asp:ImageButton ID="lnkCrntAgentDetails" runat="server" CssClass="TextBox" BackColor="transparent"
                                                            ImageUrl="~/theme/iflow/MemberDetails.png" Text="Primary Manager" OnClick="lnkCrntAgentDetails_Click" Visible="false" />
                                                  
                                                  
                                                   <div id="demo1" class="row"  runat="server">
                            <asp:LinkButton ID="Primary"  Text="Primary Reporting"  CssClass="btn btn-default"  OnClientClick="return addCssClassByClick('1')"  OnClick="Primary_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Additional"  Text="Additional Reporting" CssClass="btn btn-default"  OnClick="Additional_Click" runat="server"></asp:LinkButton>
                            <asp:LinkButton ID="Member" Text="Member Details" CssClass="btn btn-default" OnClick="Member_Click"  OnClientClick="return addCssClassByClick('3')" runat="server"></asp:LinkButton>
                        </div>

                                                        <%--<asp:MultiView ID="MultiViewCrnt" runat="server">
                                                            <asp:View ID="Vw_Primary" runat="server">--%>
                                                             
                    <%--  <div ID="div4" runat="server" class="divBorder1" style="width: 98%; margin-left:7px;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                
                                &nbsp;<asp:Label ID="lblPrReptDtls" runat="server"  
                                    Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img4" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div5','Img4','#Img4');" />
                            </td>
                        </tr>
                    </table>--%>


                    <div class="panel " id="divprimary" runat="server">
                <div id="div4" runat="server" class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div5','Span13');return false;"
                   >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                    <asp:Label ID="lblPrReptDtls" runat="server"  Font-Size ="16px"
                                 ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span13" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>
                     
                     
                     
                     
                     <div ID="div5" runat="server" class="panel-body">
                                                                       <div class="row" style="margin-bottom:5px;">
                                                                       <div class="col-md-3" style="text-align:left">
                                                                                    <asp:Label ID="lblddlreportingtype" CssClass="control-label" runat="server"></asp:Label>
                                                                               </div>
                                                                                <div class="col-md-3">
                                                                                    <asp:TextBox ID="lblValreportingtype" runat="server" CssClass="form-control"   Enabled="false"
                                                                                        > </asp:TextBox>
                                                                                        </div>
                                                                              <div class="col-md-3" style="text-align:left">
                                                                                    <asp:Label ID="lblPribasedon" CssClass="control-label" runat="server"></asp:Label>
                                                                                </div>
                                                                                 <div class="col-md-3">
                                                                                    <asp:TextBox ID="lblValbasedon" runat="server" CssClass="form-control"   Enabled="false"
                                                                                       > </asp:TextBox>
                                                                                        </div>
                                                                              </div>
                                                                                <div class="row" style="margin-bottom:5px;">
                                                                                <div class="col-md-3" style="text-align:left">
                                                                                    <asp:Label ID="lblPrichannel" CssClass="control-label" runat="server"></asp:Label>
                                                                               </div>
                                                                                <div class="col-md-3">
                                                                                    <asp:TextBox ID="lblValchannel" runat="server" CssClass="form-control"   Enabled="false"
                                                                                        ></asp:TextBox>
                                                                                        </div>
                                                                              <div class="col-md-3" style="text-align:left">
                                                                                    <asp:Label ID="lblPrisubchannel" runat="server" CssClass="control-label"></asp:Label>
                                                                               </div>
                                                                                <div class="col-md-3">
                                                                                    <asp:TextBox ID="lblValsubchannel" runat="server" CssClass="form-control"   Enabled="false"

                                                                                      ></asp:TextBox>
                                                                                        </div>
                                                                               
                                                                            </div>
                                                                            
                                                                                    <div class="row" style="margin-bottom:5px;">
                                                                                     <div class="col-md-3" style="text-align:left">
                                                                                    <asp:Label ID="lblPrilevelagttype" CssClass="control-label" runat="server"></asp:Label>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <asp:TextBox ID="lblVallevelagttype" runat="server" CssClass="form-control"   Enabled="false"
                                                                                      > </asp:TextBox>
                                                                                        </div>
                                                                                 <div class="col-md-3" style="text-align:left">
                                                                                    <asp:Label ID="lblrptunitcode" CssClass="control-label" runat="server"></asp:Label>
                                                                              </div>
                                                                              <div class="col-md-3">
                                                                                    <asp:TextBox ID="lblValRptUntCode" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                    <asp:Label ID="lblRptUntCode" CssClass="control-label" runat="server"></asp:Label>
                                                                                    <asp:HiddenField ID="hdnRptUntCode" runat="server" />
                                                                                    </div>
                                                                              </div>
                                                                                  <div class="row" style="margin-bottom:5px;">
                                                                                  <div class="col-md-3" style="text-align:left">
                                                                                    <asp:Label ID="lblRptRule" CssClass="control-label" runat="server" Visible="false"></asp:Label>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <asp:TextBox ID="lblValReportingRule" runat="server" CssClass="form-control"   Enabled="false"
                                                                                 Visible="false"> </asp:TextBox>
                                                                                </div>
                                                                                </div>
                                                                           
                                                                        </div>
                                                                        </div>
                                                                      
                                 
                               <%--      </asp:View>
                                                            
                                                            <asp:View ID="Vw_Addl" runat="server">--%>
                                                               
                              <%--  <div ID="div6" runat="server" class="divBorder1" style="width: 98%;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                               
                                &nbsp;<asp:Label ID="lblAddlRDtls" runat="server" 
                                    Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img5" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('div7','Img5','#Img5');" />
                            </td>
                        </tr>
                    </table>--%>


                    <div class="panel " id="divadditional" runat="server">
                <div id="div6" runat="server" class="panel-heading"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div7','Span14');return false;"
                >           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                  <asp:Label ID="lblAddlRDtls" runat="server"   Font-Size ="16px"
                                  ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span14" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>
                                                                     
                                                                          
                                                                          
                                                                          <div ID="div7" style="display:block;" runat="server" class="panel-body">
                                                  <div class="row" style="margin-bottom:5px;">                    
                                                                     <div class="col-sm-3" style="text-align:left">
                                                                                    <asp:Label ID="lbladditionalreporting" CssClass="control-label" runat="server"></asp:Label>
                                                                                    </div>
                                                                               
                                                                               <div class="col-sm-3" style="text-align:left">
                                                                                    <asp:Label ID="lbladditionalrptdesc" runat="server" CssClass="control-label"></asp:Label>
                                                                                    </div>
                                                                                     <div class="col-md-3">
                                                                                     </div>
                                                                                      <div class="col-md-3">
                                                                                      </div>
                                                                                 </div>     
                                                                                   <div class="row" style="margin-bottom:5px;">   
                                                                                <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lbladditionalmangr1" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                          <div class="col-md-3"> 
                                                                                                    </div>
                                                                                         <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMRptTyp" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                         
                                                                                           <div class="col-sm-3" >
                                                                                                <asp:TextBox ID="lblValam1reportingtype" runat="server" CssClass="form-control"   Enabled="false"
                                                                                                   > </asp:TextBox>
                                                                                                   </div>
                                                                                                   
                                                                                                  
                                                                                               </div>      
                                                                                                  <div class="row" style="margin-bottom:5px;">
                                                                                          <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMBsdOn" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                            <div class="col-sm-3" >
                                                                                                <asp:TextBox ID="lblValam1basedon" runat="server" 
                                                                                             CssClass="form-control"   Enabled="false"> </asp:TextBox>
                                                                                                   </div>
                                                                                           
                                                                                           <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMChnl" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                          <div class="col-sm-3">
                                                                                                <asp:TextBox ID="lblValam1channel" runat="server" CssClass="form-control"   Enabled="false"
                                                                                                    ></asp:TextBox>
                                                                                                    </div>
                                                                                                    </div>
                                                                                               <div class="row" style="margin-bottom:5px;">   
                                                                                          
                                                                                          
                                                                                          <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMSubCls" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                          
                                                                                          <div class="col-sm-3">
                                                                                                <asp:TextBox ID="lblValam1subchannel" runat="server" CssClass="form-control"   Enabled="false"
                                                                                                    > </asp:TextBox>
                                                                                                    </div>
                                                                                          <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAMLvlAgtTyp" runat="server" CssClass="control-label"></asp:Label>
                                                                                                </div>
                                                                                                     <div class="col-sm-3" >
                                                                                                <asp:TextBox ID="lblValam1levelagttype" runat="server" CssClass="form-control"   Enabled="false"
                                                                                                    > </asp:TextBox>
                                                                                                    </div>
                                                                                            
                                                                                          </div>
                                                                                           <div class="row" style="margin-bottom:5px;">   
                                                                                        
                                                                                            
                                                                                            <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblRptUnitCodeMgr1" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                           
                                                                                           <div class="col-sm-3" >
                                                                                                <asp:TextBox ID="lblValRptUnitCodeMgr1" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                                </div>
                                                                                                
                                                                                                <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblRptUntCodeMgr1" CssClass="control-label" runat="server"></asp:Label>
                                                                                               
                                                                                                <asp:HiddenField ID="hdnRptUntCodeMgr1" runat="server" />
                                                                                                 </div>
                                                                                                  <div class="col-md-3">
                                                                                                  </div>
                                                                                                 </div>
                                                                                                  <div class="row" style="margin-bottom:5px;">  
                                                                                                 <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lbladditionalmangr2" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                           
                                                                                              <div class="col-md-3">
                                                                                              </div>
                                                                                           
                                                                                             <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMRptTyp2" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                    
                                                                                              
                                                                                            <div class="col-sm-3" >
                                                                                                <asp:TextBox ID="lblValam2reportingtype" CssClass="form-control"   Enabled="false" runat="server" 
                                                                                                  ></asp:TextBox>
                                                                                                    </div>
                                                                                         </div>
                                                                                                <div class="row" style="margin-bottom:5px;">
                                                                                            <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMBsdOn2" CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                           
                                                                                            <div class="col-sm-3" >
                                                                                               
                                                                                                        <asp:Label ID="lblValam2basedon" runat="server" CssClass="control-label"> </asp:Label>
                                                                                                    
                                                                                                </div>
                                                                                        
                                                                                            
                                                                                            <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMChnl2"  CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                           
                                                                                            <div class="col-sm-3">
                                                                                                <asp:TextBox ID="lblValam2channel" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                                </div>
                                                                                                   </div>
                                                                                                      <div class="row" style="margin-bottom:5px;">
                                                                                           <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAddlMSubCls2"  CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                           <div class="col-sm-3">
                                                                                                <asp:TextBox ID="lblValam2subchannel" runat="server" CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                                </div>
                                                                                          
                                                                                       <div class="col-sm-3" style="text-align:left">
                                                                                                <asp:Label ID="lblAMLvlAgtTyp2"  CssClass="control-label" runat="server"></asp:Label>
                                                                                                </div>
                                                                                            
                                                                                             <div class="col-sm-3" >
                                                                                                <asp:TextBox ID="lblValam2levelagttype" runat="server"  CssClass="form-control"   Enabled="false"></asp:TextBox>
                                                                                                </div>
                                                                                           
                                                                                       </div> 
                                                                     </div>

                                                                       </div>

                                                                       
                                                           <%-- </asp:View>
                                                            
                                                            <asp:View runat="server" ID="Vw_Agents">--%>
                                                                                                                
                              <%--  <div ID="div8" runat="server" class="divBorder1" style="width: 98%;">
                    <table id="Table2" class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                               
                                &nbsp;<asp:Label ID="lblAgentsTitle" runat="server" 
                                    Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img6" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','Img6','#Img6');" />
                            </td>
                        </tr>
                    </table>--%>
                                                                       <div class="panel " id="divmember" runat="server">
                <div id="div8" runat="server" class="panel-heading"    onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divcmphdr','Span15');return false;"  
               >    
                
                <div class="row">
                    <div class="col-sm-9" style="text-align:left">
                 <asp:Label ID="lblAgentsTitle" runat="server"   Font-Size ="16px"
                              ></asp:Label>
                 
                    </div>
                    <div class="col-sm-3">
                        <span id="Span15" class="glyphicon glyphicon-resize-full" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>      
                    </div>       
                         
                         
                          
                        
                
                
                
                 </div>

                                                                             <div id="divcmphdr" runat="server" class="panel-body">
                                                                           
                                                                                    <center>
                                                                                        <asp:Label Text="No members present." runat="server" ID="lblAgentDetailMsg" ForeColor="Red"
                                                                                            Font-Bold="true" Visible="false" /></center>
                                                                                    <asp:GridView ID="gv_AgentDtls" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                                        HorizontalAlign="Left"  
                                                                                        AllowSorting="True"   CssClass="footable"
                                                                                        Style="margin-left: 0px;margin-top:10px" OnPageIndexChanging="gv_AgentDtls_PageIndexChanging"
                                                                                        OnSorting="gv_AgentDtls_Sorting"><%--RowStyle-CssClass="formtable"--%>
                                                                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                                                         <PagerStyle CssClass="disablepage" />
                                                                                         <HeaderStyle CssClass="gridview th" />
                                                                                       
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="MemCode" HeaderText="Member Code" SortExpression="MemCode"
                                                                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                                                            <asp:BoundField DataField="BizSrc" HeaderText="Hierarchy" HeaderStyle-HorizontalAlign="Center">
                                                                                             </asp:BoundField>
                                                                                            <asp:BoundField DataField="Chncls" HeaderText="Sub Channel" SortExpression="Chncls"
                                                                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                                                            <asp:BoundField DataField="MemType" HeaderText="Member Type" SortExpression="MemType"
                                                                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                                                                        </Columns>
                                                                                        
                                                                                    </asp:GridView>
                                                                         
                                                                        </div>
                                                                        <br />

                                                                        <div id="divPage" visible="true" runat="server" class="pagination">
                        <center>
                            <table>
                                <tr>
                                    <td style="white-space: nowrap;">
                                     
                                                <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                    Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                    background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                <asp:TextBox runat="server" ID="txtPage" Style="width: 44px; border-style: solid;
                                                    border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                    text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                    border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                    float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                         
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                                                                       
                                                                        </div>
                                                                 
                                                            <%--</asp:View>
                                                        
                                                        
                                                        </asp:MultiView>--%>
                                                      
                                    </div>
                               
                                   </div>
                            
                                <br />
                                
                                                        
                                <%-- Added by Kalyani--%> 
                                <div runat="server" id="divex" style="display:none">
                                 <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="LblBizsrc" runat="server"  CssClass="control-label" Text="Channel"></asp:Label>
                                                        <span id="Span3" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                   
                                                      <div class="col-sm-3">
                                                        <asp:Label ID="LblSlschannel" CssClass="control-label" runat="server"></asp:Label>
                                                        <span id="Span4" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                    
                                                    <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="LblSubclass" runat="server" CssClass="control-label" Text="Sub class"></asp:Label>
                                                        <span id="Span5" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                    
                                                     <div class="col-sm-3">
                                                        <asp:Label ID="LblChannelSubclass" CssClass="control-label" runat="server"></asp:Label>
                                                        <span id="Span6" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                   
                                                    <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="LblUntcodeLink" CssClass="control-label" runat="server" Text="Unit Type"></asp:Label>
                                                        <span id="Span7" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                   
                                                    <div class="col-sm-3">
                                                        <asp:Label ID="LblUnitType" CssClass="control-label" runat="server"></asp:Label>
                                                        </div>
                                                    
                                                     <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="LblUnitName1" CssClass="control-label" runat="server" Text="Unit Name"></asp:Label>
                                                        </div>

                                                    <div class="col-sm-3">
                                                        <asp:Label ID="lblValUnitName1" runat="server" CssClass="control-label"> </asp:Label>
                                                        </div>
                                                        <%-- LinkUnitCode--%>
                                                  
                                 <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="lbluntSalesChnl" CssClass="control-label" runat="server" Text="Channel"></asp:Label>
                                                        <span id="Span8" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                   
                                                   </div>

                                                    <div class="col-sm-3">
                                                        <asp:Label ID="lbluntSalesChnlDesc" CssClass="control-label" runat="server"></asp:Label>
                                                        <span id="Span9" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                  
                                                   <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="lbluntSubChnl" CssClass="control-label" runat="server" Text="Sub class"></asp:Label>
                                                        <span id="Span10" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                   
                                                    <div class="col-sm-3">
                                                        <asp:Label ID="lbluntSubChnlDesc" CssClass="control-label" runat="server"></asp:Label>
                                                        <span id="Span11" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                    
                                                     <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="lblAgntType" CssClass="control-label" runat="server" Text="Agent Type"></asp:Label>
                                                        <span id="Span12" runat="server" style="font-size: 10pt; color: #ff0000;"></span>
                                                        </div>
                                                  
                                                   <div class="col-sm-3">
                                                        <asp:Label ID="LblAgentType" CssClass="control-label" runat="server"></asp:Label>
                                                        </div>
                                                   
                                                    <div class="col-sm-3" style="text-align:left">
                                                        <asp:Label ID="LblAgentName" CssClass="control-label" runat="server" Text="Agent Name"></asp:Label>
                                                        </div>
                                                  
                                                   <div class="col-sm-3">
                                                        <asp:Label ID="lblValAgntName" runat="server" CssClass="control-label"></asp:Label>
                                                        </div>
                                                   
                             </div>
                                <%-- Added by Kalyani--%>
                                
                                    
                                    
                                    
                                    
                                   <%-- <div ID="div9" runat="server" class="divBorder1" style="width: 98%;">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                               
                                &nbsp;<asp:Label ID="lblUnitCeaseTitle" runat="server" 
                                    Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img7" src="../../../assets/img/portlet-expand-icon-white.png" alt="" onclick="ShowReqDtl('divAgtAdvSearch','Img7','#Img7');" />
                            </td>
                        </tr>
                    </table>--%>

                      <div class="panel ">
                        <div id="div9" runat="server" class="panel-heading"  onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divAgtAdvSearch','Span16');return false;">           
                          <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                      &nbsp;<asp:Label ID="lblUnitCeaseTitle" runat="server"   Font-Size ="19px"
                                   ></asp:Label>
                 
                    </div>
                    <div class="col-sm-2">
                        <span id="Span16" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                        
                 </div>
                                
                                
                                 <div id="divAgtAdvSearch"  style="display:block;" runat="server" class="panel-body">
                                      <div class="row" style="margin-bottom:5px;">
                                          <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lbl_CeaseReason" runat="server" CssClass="control-label" ></asp:Label><span style="color: Red;"> *</span>
                                                </div>
                                          <div class="col-md-3">
                                            <asp:DropDownList runat="server" ID="ddlCeaseReason" 
                                            CssClass="form-control">
                                            </asp:DropDownList>
                                       </div>
                                          <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lbl_CeaseDate" runat="server" CssClass="control-label" ></asp:Label>
                                            </div>
                                           <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lbl_DateVal" runat="server" Font-Bold="true" CssClass="control-label" ></asp:Label>
                                            </div>
                                            </div>
                                               <div class="row" style="margin-bottom:5px;">
                                           <div class="col-md-3" style="text-align: left">
                                            <asp:Label ID="lbl_CeaseRemark" runat="server" CssClass="control-label" ></asp:Label><span style="color: Red;"> *</span>
                                                </div>
                                          <div class="col-md-3">
                                            <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"
                                                TextMode="MultiLine" ></asp:TextBox>
                                               
                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtUnitCodeFTX" runat="server" TargetControlID="txtRemark"
                                                FilterType="Custom, LowercaseLetters, UppercaseLetters, Numbers">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                             </div>
                                       </div>

                                </div>
                                

                         </div>
                                
                                
                                
                              <%--  <table class="formtable" width="100%">
                                    <tr>
                                        <td align="center" colspan="4" style="height: 2px">
                                            <div id="ivarLoad" class="Content" style="display: none;">
                                                <img class="UpdateProgress1_img" alt="" src="~/App_Themes/Isys/images/spinner.gif" />
                                                Loading ...
                                            </div>
                                            <asp:Button ID="btnCease" runat="server" CssClass="standardbutton" OnClick="btnCease_Click"
                                                 Text="CEASE" Width="80px" />
                                            &nbsp;
                                            <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" OnClientClick="javascript:doCancel();return false;"
                                                 Text="CANCEL" Width="80px" />
                                        </td>
                                    </tr>
                                </table>--%>

                                <%-- <div ID="div10" runat="server" style="width: 98%;">
                    <table ID="tbladdcntst" runat="server" class="form-actions fluid" 
                        style="width: 100%;">
                        <tr>
                            <td align="center" colspan="4" 
                                style="text-align: center; width: 50%; padding-bottom: 5px; padding-top: 5px;">
                                <input id="hidFlag" runat="server" type="hidden" />
                                &nbsp;
                                <asp:Button ID="btnCease" runat="server" CausesValidation="True" 
                                    CssClass="btn blue" OnClick="btnCease_Click" 
                                    OnClientClick="javascript:validate();" Text="CEASE" 
                                    Width="100px" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False"  OnClientClick="javascript:doCancel();return false;"
                                    CssClass="btn default" Text="CANCEL" 
                                    Width="100px" />--%>

                                     <div class="row">
                        <div class="col-sm-12" align="center">
                                       <asp:LinkButton ID="btnCease" runat="server" CssClass="btn btn-sample" AutoPostback="false" CausesValidation="True"  Text="CEASE" 
                                OnClientClick="return funValidate();"   OnClick="btnCease_Click">
                                 <span class="glyphicon glyphicon-ban-circle" style='color:White;'></span> Cease
                                </asp:LinkButton> 
                                <asp:LinkButton ID="btnCancel"  CausesValidation="False"  OnClick="btnCancel_Click"
                                   CssClass="btn btn-sample" Text="CANCEL" 
                                    runat="server"> <%--OnClientClick="javascript:doCancel();return false;"--%>
                              <span class="glyphicon glyphicon-remove" style='color:White;'></span> Cancel </asp:LinkButton> 
                            </div>
                            </div>

                <input id="hdnCreateRule" type="hidden" runat="server" />
                <input id="hdnID220" type="hidden" runat="server" />
                <input id="hdnCmsDesc" type="hidden" runat="server" />
                <input id="hdnID230" type="hidden" runat="server" />
                <input id="hdnID240" type="hidden" runat="server" />
                <input id="hdnID250" type="hidden" runat="server" />
                <input id="hdnID260" type="hidden" runat="server" />
                <input id="hdnID270" type="hidden" runat="server" />
                <input id="hdnID280" type="hidden" runat="server" />
                <input id="hdnID290" type="hidden" runat="server" />
                <input id="hdnID320" type="hidden" runat="server" />
                <input id="hdnID330" type="hidden" runat="server" />
                <input id="hdnID350" type="hidden" runat="server" />
                <input id="hdnID360" type="hidden" runat="server" />
                <input id="hdnID370" type="hidden" runat="server" />
                <input id="hdnID380" type="hidden" runat="server" />
                <input id="hdnSALocCode" type="hidden" runat="server" />
                <%--Added by rachana on 02-07-2013 for client code start--%>
                <input id="hdnAgentcode" type="hidden" runat="server" />
                <%--Added by rachana on 02-07-2013 for client code start--%>
            
            </center>




    </div>


    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #034ea2;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top: -6px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK

                    </button>

                </div>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            document.getElementById("ctl00_ContentPlaceHolder1_div_UnitDtl2").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_btnUnitParticularcollapse").value = '-';
            document.getElementById("ctl00_ContentPlaceHolder1_div_UnitDtl2").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnReportingcollapse").value = '+';
            document.getElementById("ctl00_ContentPlaceHolder1_div_UnitContact").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_btnUnitContactDtlscollapse").value = '+';
        });
    </script>
</asp:Content>
