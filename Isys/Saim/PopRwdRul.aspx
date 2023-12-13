<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopRwdRul.aspx.cs" Inherits="Application_ISys_Saim_PopRwdRul" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script  type="text/javascript" src="~/Scripts/formatting.js"></script>
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
    <script type="text/javascript">
       
        function OpenPopupWindow(cmpcode, cntstcode, ruleset) {
            debugger;
            //alert("OpenPopupWindow2");
            window.open("MemSearch.aspx?cmpcode=" + cmpcode + "&cntstcode=" + cntstcode + "&CallType=Agent", '', 'width=900,height=550,toolbar=no,scrollbars=Yes,resizable=No,left=180,top=150,location=0;');

        }

        function OpenPopupWindow2(cmpcode, cntstcode, ruleset) {
            debugger;
            alert("OpenPopupWindow");
            var strContent = "ctl00_ContentPlaceHolder1_";
            ///$find("mdlViewBIDcmnt").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "LMSReportReqType.aspx?cmpcode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&ruleset=" + ruleset
            + "&mdlpopup=mdlVwBID";
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                   // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                  //  objnewbtn.className = 'glyphicon glyphicon-collapse-down'
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

        $(function () {
            var strcontent = "ctl00_ContentPlaceHolder1_";
            $("#<%=txtRwdDesc1.ClientID %>").keypress(function () {
                alert("Please add master using ADD MASTER...")
                document.getElementById(strcontent + "txtRwdDesc1").value == "";
                //document.getElementById(strcontent + "txtRSKDesc").value = "";
                return false;


            });
        });

        function funcall() {

        }
        function funAddmaster(cmpcode, cntstcode, flag, ruletype) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            ///$find("mdlViewBIDcmnt").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul").src = "PopCntstMst.aspx?CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype
            + "&mdlpopup=mdlVwBID";
        }


        function FunddlRwdTypeChange() {
           
//            var strContent = "ctl00_ContentPlaceHolder1_";
//            var RULE_SET_KEY = document.getElementById(strContent + "ddlRwdType").value

//            var txtValue = document.getElementById(strContent + "txtValue").value
//            var txtBrkRul = document.getElementById(strContent + "txtBrkRul").value




//            if (RULE_SET_KEY == "1002") {

//                 document.getElementById(strContent + "ddlRwdType").disabled = true;
//                 document.getElementById(strContent + "txtValue").disabled = true;
//                 document.getElementById(strContent + "txtBrkRul").disabled = true;
//                 document.getElementById(strContent + "LnkVarSetUp").disabled = true;

//            }

            


        }

        //arjun 
     function funAddVarMaster(cmpcode, cntstcode, flag, ruletype, MEMBERCODE, BRKPRULE_CODE,REASONFOREDIT) {
            // alert("hi")
         debugger;

         //if(MEMBERCODE != "" && REASONFOREDIT == "")
         //{
         //    alert("Please selct reason for edit")
         //   // throw "Please selct reason for edit"
         //    return false;
             
         //}

            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            var RULE_SET_KEY = document.getElementById(strContent + "ddlRulSetKey").value
            var RWRD_CODE = document.getElementById(strContent + "ddlRwdDesc").value
            var CATG_CODE = document.getElementById(strContent + "ddlCatgCode").value
            var CYCLE = document.getElementById(strContent + "ddlCycles").value
            var RWRD_TYPE = document.getElementById(strContent + "ddlRwdType").value
            var BRKPRULE_CODE = document.getElementById(strContent + "txtBrkRul").value

            var TYPE = document.getElementById(strContent + "ddlType").value


                //var REASONFOREDIT = document.getElementById(strContent + "ddlReasonforEdit").value


            var REWARDDEPENDFLAG = document.getElementById(strContent + "ddlDependKPIRewardFlag").value
            if (REWARDDEPENDFLAG == "Y") {
            var RDCmpCode = document.getElementById(strContent + "ddlRDCmpCode").value
            var RDCnstCode = document.getElementById(strContent + "ddlRDCnstCode").value
            var RewardDependRuleSet = document.getElementById(strContent + "ddlRewardDependRuleSet").value
            var RewardDependKPI = document.getElementById(strContent + "ddlRewardDependKPI").value
            
            }
            else {
                var RDCmpCode =""
                var RDCnstCode = ""
                var RewardDependRuleSet = ""
                var RewardDependKPI =""
            }
          

            ///$find("mdlViewBIDcmnt").show();s
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul1").src = "PopVarSU.aspx?BRKPRULE_CODE=" + BRKPRULE_CODE + "&MEMBERCODE=" + MEMBERCODE + "&CmpCode=" + cmpcode
            + "&CntstCode=" + cntstcode + "&flag=" + flag + "&ruletype=" + ruletype + "&RWRD_CODE=" + RWRD_CODE + "&CATG_CODE=" + CATG_CODE
            + "&CYCLE=" + CYCLE + "&RWRD_TYPE=" + RWRD_TYPE + "&RULE_SET_KEY=" + RULE_SET_KEY + "&TYPE=" + TYPE + "&REASONFOREDIT=" + REASONFOREDIT + "&REWARDDEPENDFLAG=" + REWARDDEPENDFLAG
            + "&RDCmpCode=" + RDCmpCode + "&RDCnstCode=" + RDCnstCode + "&RewardDependRuleSet=" + RewardDependRuleSet + "&RewardDependKPI=" + RewardDependKPI  + "&mdlpopup=mdlVwBID1";
         //alert(document.getElementById("ctl00_ContentPlaceHolder1_ifrmRwdRul1").src);REASONFOREDIT,REWARDDEPENDFLAG
        }


        function doOk(rultyp) {
            ////alert('akshsy');
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            ////alert('akshs11111');
            if (rultyp == 'R') {
                if (window.parent.document.getElementById("btnrwdrul") != null) {
                    window.parent.document.getElementById("btnrwdrul").click();
                }
            }
        }

        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            if (window.parent.document.getElementById("btnrwdrul") != null) {
                window.parent.document.getElementById("btnrwdrul").click();
            }
        }


        function funPopUpFrml() {
            //////alert('akshay');
            var strContent = "ctl00_ContentPlaceHolder1_";
            /////$find("mdlViewBID").show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopFrmlEditCatg.aspx?mdlpopup=mdlViewBID";
        }


        function validate() {
            debugger;
            var strcontent = "ctl00_ContentPlaceHolder1_";


           

            if (document.getElementById(strcontent + "txtRwdDesc1") != null) {
                if (document.getElementById(strcontent + "txtRwdDesc1").value == "") {
                    alert("Please Enter Reward Description1");
                    document.getElementById(strcontent + "txtRwdDesc1").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlRwdDesc") != null) {
                if (document.getElementById(strcontent + "ddlRwdDesc").value == "") {
                    alert("Please Select Reward Description1...");
                    document.getElementById(strcontent + "ddlRwdDesc").focus();
                    return false;
                }
            }


            if (document.getElementById(strcontent + "ddlRSKDesc") != null) {
                if (document.getElementById(strcontent + "ddlRSKDesc").value == "") {
                    alert("Please Select Rule Set Key Description...");
                    document.getElementById(strcontent + "ddlRSKDesc").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtRwdDesc2") != null) {
                if (document.getElementById(strcontent + "txtRwdDesc2").value == "") {
                    alert("Please Reward Description2");
                    document.getElementById(strcontent + "txtRwdDesc2").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "txtRwdDesc3") != null) {
                if (document.getElementById(strcontent + "txtRwdDesc3").value == "") {
                    alert("Please Reward Description3");
                    document.getElementById(strcontent + "txtRwdDesc3").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlRulSetKey") != null) {
                if (document.getElementById(strcontent + "ddlRulSetKey").value == "") {
                    alert("Please Select Rule Set key");
                    document.getElementById(strcontent + "ddlRulSetKey").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlCatgCode") != null) {
                if (document.getElementById(strcontent + "ddlCatgCode").value == "") {
                    alert("Please Select Category");
                    document.getElementById(strcontent + "ddlCatgCode").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlRwdType") != null) {
                if (document.getElementById(strcontent + "ddlRwdType").value == "") {
                    alert("Please Select Reward Type");
                    document.getElementById(strcontent + "ddlRwdType").focus();
                    return false;
                }
            }

            if (document.getElementById(strcontent + "ddlType") != null) {
                if (document.getElementById(strcontent + "ddlType").value == "") {
                    alert("Please Select Unit type");
                    document.getElementById(strcontent + "ddlType").focus();
                    return false;
                }
            }

//            if (document.getElementById(strcontent + "ddlKPICode") != null) {
//              
//                    if (document.getElementById(strcontent + "ddlKPICode").value == "") {
//                        alert("Please Select KPI Code.");
//                        document.getElementById(strcontent + "ddlKPICode").focus();
//                        return false;
//                    
//                }
//            }
            if (document.getElementById(strcontent + "ddlKPICode") != null) {

                if (document.getElementById(strcontent + "ddlKPICode").value == "") {
                    if (!(document.getElementById(strcontent + "ddlKPICode")).disabled == true) {
                        alert("Please Select KPI Code.");
                        document.getElementById(strcontent + "ddlKPICode").focus();
                        return false;
                    }
                }
            }
            if (document.getElementById(strcontent + "txtValue") != null) {
                if (document.getElementById(strcontent + "txtValue").value == "") {
                    alert("Please Enter Value.");
                    document.getElementById(strcontent + "txtValue").focus();
                    return false;
                }
            }

////            if (document.getElementById(strcontent + "txtBrkRul") != null) {
////                if (document.getElementById(strcontent + "txtBrkRul").value == "") {
////                    alert("Please Enter Break Rule.");
////                    document.getElementById(strcontent + "txtBrkRul").focus();
////                    return false;
////                }
////            }

            if (document.getElementById(strcontent + "txtRate") != null) {
                if (document.getElementById(strcontent + "txtRate").value == "") {
                    alert("Please Enter Rate.");
                    document.getElementById(strcontent + "txtRate").focus();
                    return false;
                }
            }
        }

        function isNumberKey(evt, c) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            var dot1 = c.value.indexOf('.');
            var dot2 = c.value.lastIndexOf('.');

            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            else if (charCode == 46 && (dot1 == dot2) && dot1 != -1 && dot2 != -1)
                return false;

            return true;
        }
        
    </script>
    <style type="text/css">
        /*.new_text_new
        {
            color: #066de7;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }*/
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        .disablepage
        {
            display: none;
        }
        
        /*.box
        {
            background-color: #efefef;
            padding-left: 5px;
        }*/
    </style>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <center>
                <div id="divrwdrulcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="divC" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','Img2');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblhdr" style="font-size:19px;" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                 <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" style="width: 96%;"  class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblRulSetKy" Text="Rule Set Key" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblRulSetKy_" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlRulSetKey" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    OnSelectedIndexChanged="ddlRulSetKey_SelectedIndexChanged">
                                        </asp:DropDownList>
                                                <input id="hdnRulClass" type="hidden" runat="server" />
                                                 <input id="hdnRWDLNK" type="hidden" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                            <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblRwdType" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblRwdType_" Text="*" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlRwdType"  OnSelectedIndexChanged="ddlRwdType_SelectedIndexChanged" onchange="FunddlRwdTypeChange()" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                             
                            <div class="col-sm-6" style="text-align: left">
                                                          
                            </div>
                           </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRwdCode" runat="server" CssClass="control-label col-md" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtRwdCode" runat="server" CssClass="select2-container form-control" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRwdDesc1" runat="server" CssClass="control-label col-md" />
                                <asp:Label ID="lblRwdDesc1_" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRwdDesc1" runat="server" CssClass="select2-container form-control"
                                            AutoPostBack="true" OnTextChanged="txtRwdDesc1_TextChanged" />
                                        <asp:DropDownList ID="ddlRwdDesc" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            Visible="false" OnSelectedIndexChanged="ddlRwdDesc_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="LblAgent" runat="server" CssClass="control-label col-md"  Text="Member Code"/>
                                <asp:Label ID="LblAgentM" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <input id="hdnAgentDesc" type="hidden" value="" runat="server" />
                                <input id="hdnAgentCode" type="hidden" value="" runat="server" />
                                 <asp:LinkButton ID="btnAgtName" runat="server" CssClass="btn btn-sample"  OnClick="btnAgtName_Click">
                                    <span class="glyphicon glyphicon-hand-right BtnGlyphicon"> </span> 
                                                    </asp:LinkButton>
                                 <asp:Label ID="LblAgentToolTip" runat="server" CssClass="standardlabel" Font-Bold="true"
                                                        ForeColor="Red"></asp:Label>
                                                    <asp:Button ID="BtnAgentToolTip" runat="server" Text="Button" Style="display: none"
                                                        OnClick="BtnAgentToolTip_Click" />
                                                    <input id="HAgent" type="hidden" value="" runat="server" />


                            </div>
                     <div class="col-sm-3" style="text-align: left">
                         <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                        <asp:Label ID="Label11" Text="Member Location" runat="server" CssClass="control-label"  Visible="false"/>
                        <span style="color: Red;">*</span>
                           </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                 <asp:DropDownList ID="ddlMemLoc" runat="server" AutoPostBack="true" Enabled="true" Width="100%"
                                        CssClass="form-control" Visible="false" >
                                    </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                             
                        </div>
                            </div>
                        </div>

                        <div id="div1" runat="server" style="width: 97%;" class="panel">
                    <div id="div2" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr1','Img2');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblHdr2" style="font-size:19px;" runat="server" Text="Rule Details"/>
                                    </div>
                            <div class="col-sm-2">
                                 <span id="Img2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 26/4/2018--%>
                                    </div>
                                    </div>
                                    </div>
                    <div id="divcmphdr1" runat="server" style="width: 96%;"  class="panel-body">


                        <div id="trdsc" runat="server" visible="false" class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRwdDesc2" runat="server" CssClass="control-label col-md" />
                                <asp:Label ID="lblRwdDesc2_" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtRwdDesc2" runat="server" CssClass="select2-container form-control" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblRwdDesc3" runat="server" CssClass="control-label col-md" /><%---5-- only for madatory * Field--%>
                                <asp:Label ID="lblRwdDesc3_" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtRwdDesc3" runat="server" CssClass="select2-container form-control" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                                    

                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="Label1" Text="Cycles" runat="server" CssClass="control-label col-md" />
                                                <asp:Label ID="Label1_" Text="*" runat="server" ForeColor="red" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCycles" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblCatg" Text="Category" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblCatg_" Text="*" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCatgCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    OnSelectedIndexChanged="ddlCatgCode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                
                                <div class="row" style="margin-bottom: 5px;">
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblType" Text="Unit Type" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblType_" Text="*" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    CellSpacing="10" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <asp:Label ID="lblKPICode" Text="KPI Code" runat="server" CssClass="control-label col-md" />
                                        <asp:Label ID="lblKPICode_" runat="server" ForeColor="red" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlKPICode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    Enabled="false"  OnSelectedIndexChanged="ddlKPICode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                        
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblValue" Text="Value" runat="server" CssClass="control-label col-md" />
                                <asp:Label ID="lblValue_" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtValue" runat="server" CssClass="select2-container form-control"
                                    placeholder="Value" MaxLength="12" /> <%--onkeypress="return isNumberKey(event,this);"--%>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="Numbers,Custom" FilterMode="ValidChars" ValidChars=".,-" TargetControlID="txtValue">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:LinkButton ID="lnkSetFrml" Text="Set Formula" runat="server" Visible="false"
                                    OnClick="lnkSetFrml_Click" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRate" Text="Rate" runat="server" CssClass="control-label col-md"
                                            Visible="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtRate" runat="server" CssClass="select2-container form-control"
                                            placeholder="Rate" Visible="false" /></ContentTemplate>
                                </asp:UpdatePanel>
                            </div>


                            </div>

                        <div class="row" style="margin-bottom: 5px;display:none" runat="server" id="divTarget" >
                             <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label3" Text="Reward Amount From" runat="server" CssClass="control-label col-md" />
                            </div>
                             <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtTargetFrom" runat="server" CssClass="select2-container form-control"
                                            placeholder="0.00"  text="0.00" /></ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label4" Text="Reward Amount To" runat="server" CssClass="control-label col-md" />
                            </div>
                             <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtTargetTo" runat="server" CssClass="select2-container form-control"
                                            placeholder="0.00"  text="0.00"   /></ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblBrkRul" Text="Breakup Rule" runat="server" CssClass="control-label col-md" />
                            </div>
                            <div class="col-sm-3" style="display:flex;">
                                <asp:TextBox ID="txtBrkRul" runat="server" CssClass="select2-container form-control"
                                    placeholder="Breakup Rule" />
                                    <asp:LinkButton ID="LnkVarSetUp" runat="server" style="width:20%;" CssClass="btn btn-sample"
                                    Enabled="true" OnClick="LnkVarSetUp_Click" >
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> 
                                    </asp:LinkButton>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblmempay" Text="Member Pay Cycle" runat="server" CssClass="control-label col-md"  visible="false" />
                            </div>
                            <div class="col-sm-3" style="text-align: left"  visible="false">
                               <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlmempay" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                   visible="false"  >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                               
                            
                                
                                <asp:Label ID="lblReasonforEdit" Text="Reason For Edit" runat="server" CssClass="control-label col-md" Visible="false" />

                                 </div>
                            <div class="col-sm-3" style="text-align: left" >
                                <%--  <asp:TextBox ID="txtReasonforEdit" runat="server" CssClass="select2-container form-control"
                                            placeholder="Reason for edit"  Visible="false"/>--%>

                                 <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlReasonforEdit" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                   visible="false"  >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                            </div>
                            
                        </div>

                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-6" style="text-align: left">
                               
                            
                                <asp:CheckBox ID="chkCyc" runat="server" AutoPostBack="true" />
                                <asp:Label ID="lbl12" Text="Apply to all Cycles" runat="server" />
                            </div>


                             
                        </div>
                      
                    </div>

                            


                </div>

                 <div id="div3" runat="server" style="width: 97%;" class="panel">


                      <div id="Divdpndhead" runat="server" class="panel-heading" style="width: 96%;" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divqual','myImg2');return false;" visible="true">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%><%--commented by ajay sawant 25/4/2018--%>
                                <asp:Label ID="Label31" Text="Dependant Reward Rule Details" style="font-size:19px" runat="server" />
                            </div>
                            <div class="col-sm-2">
                               <span id="myImg2" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 25/4/2018--%>
                            </div>
                        </div>
                    </div>
                
                      <div id="divdpnd"  class="panel-body"  runat="server" visible="true">
                           <div class="row" style="margin-bottom: 5px;">
                       
                                    <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDependKPIrewardFlag" runat="server" Text="Depend On Another Rule Reward" CssClass="control-label col-md" />
                                    </div>
                                    <div class="col-sm-3">
                               <asp:DropDownList ID="ddlDependKPIRewardFlag" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            Visible="true" OnSelectedIndexChanged="ddlDependKPIRewardFlag_SelectedIndexChanged">
                                    <asp:ListItem Value="">--SELECT--</asp:ListItem>
                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                    <asp:ListItem Value="N">NO</asp:ListItem>
   
                                   
                                                </asp:DropDownList>
                                    </div>
                                </div>

                        <div class="row" style="margin-bottom: 5px;" runat="server" visible="false" id="divRewardDependCmp">
                              <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRDCmpCode" Text="Reward Depend Compensation Code" runat="server" CssClass="control-label col-md"
                                             /><asp:Label ID="lblRDCmStar" Text=" *" runat="server" ForeColor="red" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                    <ContentTemplate>
                                      
                                        <asp:DropDownList ID="ddlRDCmpCode" runat="server" AutoPostBack="true"  CssClass="select2-container form-control"
                                                    Enabled="true" OnSelectedIndexChanged="ddlRDCmpCode_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>


                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRDCnstCode" Text="Reward Depend Contestant Code" runat="server" CssClass="control-label col-md"
                                            /><asp:Label ID="lblRDCNstar" Text="*" runat="server" ForeColor="red" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                      
                                        <asp:DropDownList ID="ddlRDCnstCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    Enabled="true"  OnSelectedIndexChanged="ddlRDCnstCode_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="row" style="margin-bottom: 5px;" runat="server" visible="false" id="divDependOnKPI">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRewardDependRuleSet" Text="Reward Depend Rule Set" runat="server" CssClass="control-label col-md"
                                             /><asp:Label ID="lblRDRstar" Text=" *" runat="server" ForeColor="red" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                    <ContentTemplate>
                                      
                                        <asp:DropDownList ID="ddlRewardDependRuleSet" runat="server" AutoPostBack="true"  CssClass="select2-container form-control"
                                                    Enabled="true" OnSelectedIndexChanged="ddlRewardDependRuleSet_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRewardDependKPI" Text="Reward Depend Description" runat="server" CssClass="control-label col-md"
                                            Visible="false" />
                                        <asp:Label ID="lblRDKstar" Text=" *" runat="server" ForeColor="red" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                      
                                        <asp:DropDownList ID="ddlRewardDependKPI" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                                    Enabled="true" Visible="false">
                                                </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>


                        </div>

                              <div class="row" style="margin-top: 12px;" runat="server"  id="divbutton"   visible="false">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-sample"  Onclick="btnAdd_Click" >
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                </asp:LinkButton>
                            </div>
                         </div>


                             <div id="dvdpnd" runat="server" style="width: 100%; border: none; margin: 0px 0 !important; overflow-x: scroll;"
                                    class="table-scrollable">

                              <asp:UpdatePanel runat="server">
                              <ContentTemplate>
                            <asp:GridView ID="dgdpnd" runat="server" AutoGenerateColumns="false" Width="100%"
                                PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable" 
                                >
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                <EmptyDataTemplate>
                                     <asp:Label ID="lblerror" Text="No Dependant Reward Define" ForeColor="Red"
                                                    CssClass="control-label" runat="server" />
                                </EmptyDataTemplate>

                                <Columns>
                                    <asp:TemplateField HeaderText="Rule Set Key" SortExpression="RULE_SET_DESC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrulesetkey" runat="server" Text='<%# Bind("RULE_SET_DESC")%>' ></asp:Label>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="KPI  Code" SortExpression="REWARD_DESC">
                                        <ItemTemplate>
                                               <asp:Label ID="lblkpicode" runat="server" Text='<%# Bind("REWARD_DESC")%>'></asp:Label>
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Parent Comp Code" SortExpression="CMPNSTN_DESC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPRNT_CMPNSTN_CODE" runat="server" Text='<%# Bind("CMPNSTN_DESC")%>'></asp:Label>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Parent Contestant Code" SortExpression="DPNDNT_CNTSTNT_CODE">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPRNT_CNTSTNT_CODE" runat="server" Text='<%# Bind("DPNDNT_CNTSTNT_CODE")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnPRNT_CNTSTNT_CODE" runat="server" Value='<%# Bind("DPNDNT_CNTSTNT_CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Parent Rule Ret Key" SortExpression="PARENT_RULE_SET_DESC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPRNT_RULE_SET_KEY" runat="server" Text='<%# Bind("PARENT_RULE_SET_DESC")%>'></asp:Label>
                                        
                                        </ItemTemplate>
                                    </asp:TemplateField>

                            </columns>

                          </asp:GridView>
                             
                        </ContentTemplate>
                       </asp:UpdatePanel>


                        </div>




                   </div>


                     </div>


                        <div id="tblrwd" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnAddMaster" runat="server" CssClass="btn btn-sample"
                                    Enabled="true" OnClick="btnAddMaster_Click" >
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Reward Type
                                    </asp:LinkButton>
                                <asp:LinkButton ID="btnAddRwd" runat="server" CssClass="btn btn-sample"
                                    Enabled="true" OnClick="btnAddRwd_Click" OnClientClick="return validate();">
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Reward
                                    </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" 
                                    OnClientClick="doCancel();return false;" OnClick="btnCancel_Click">
                                        <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                    </asp:LinkButton>
                                <asp:Button ID="btnKPI" runat="server" Style="display: none;" ClientIDMode="Static"
                                    OnClick="btnKPI_Click" />
                    </div>
                </div>
            </center>
            <asp:Panel runat="server" Height="275px" Width="1000px" ID="pnlMdl" display="none"
                Style="text-align: center; padding: 10px;" CssClass="panel panel-success">
                <iframe runat="server" id="ifrmMdlPopup" scrolling="yes" width="100%" frameborder="0"
                    display="none" style="height: 100%;"></iframe>
            </asp:Panel>
            <asp:Label runat="server" ID="lbl1" Style="display: none" />
          <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
                DropShadow="false" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
            </ajaxToolkit:ModalPopupExtender>


            <asp:Panel runat="server" Height="300px" Width="900px" ID="pnlRwdRul" display="none"
                Style="text-align: center; padding: 8px;" CssClass="panel panel-success">
                <iframe runat="server" id="ifrmRwdRul" scrolling="yes" width="100%" frameborder="0"
                    display="none" style="height: 100%;"></iframe>
            </asp:Panel>
            <asp:Label runat="server" ID="Label9" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw" BehaviorID="mdlVwBID" DropShadow="false"
                TargetControlID="Label9" PopupControlID="pnlRwdRul" BackgroundCssClass="modalPopupBg"  X="15" Y="30">
            </ajaxToolkit:ModalPopupExtender>


             <asp:Panel runat="server" Height="900px" Width="900px" ID="pnlRwdRul1" display="none"
                Style="text-align: center; padding: 8px;padding-bottom:20%; " CssClass="panel panel-success">
                <iframe runat="server" id="ifrmRwdRul1" scrolling="yes" width="100%" frameborder="0"
                    display="none" style="height: 100%;"></iframe>
            </asp:Panel>
            <asp:Label runat="server" ID="Label2" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlVw1" BehaviorID="mdlVwBID1" DropShadow="false"
                TargetControlID="Label2" PopupControlID="pnlRwdRul1" BackgroundCssClass="modalPopupBg"  X="15" Y="30">
            </ajaxToolkit:ModalPopupExtender>





            <asp:HiddenField ID="hdnRwdRulCode" runat="server" />
            <asp:HiddenField ID="hdnCycle" runat="server" />
            <asp:HiddenField ID="hdnCount" runat="server" />
            <asp:HiddenField ID="hdnYrTyp" runat="server" />
            <asp:HiddenField ID="hdnBusiCode" runat="server" />
            <asp:HiddenField ID="hdnVEREFFFROM" runat="server" />
            <asp:HiddenField ID="hdnVEREFFTO" runat="server" />
            <asp:HiddenField ID="hdnVERSION" runat="server" />
            <asp:HiddenField ID="hdnFINYEAR" runat="server" />
            <asp:HiddenField ID="hdnCycTyp" runat="server" />
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
