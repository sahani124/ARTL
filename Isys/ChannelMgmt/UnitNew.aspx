<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitNew.aspx.cs" Inherits="INSCL.UnitNew"
    MasterPageFile="~/iFrame.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />

    <link href="../../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

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
    <%--<link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
  <%-- 
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>

    <%--//Popup Of History Page Function.   var modal = document.getElementById('myModalRaise'); --%>
    
    <script type="text/javascript">
        function closePopUp() {
            document.getElementById('myModalRaise').style.display = 'none';
            document.getElementById('myModal').style.display = 'none';
            
        }
        function OpenElement() {
            debugger;
          
            var value = document.getElementById('ctl00_ContentPlaceHolder1_hdnBizsrc1').value;
            var Header = "Version History Of Unit Type";
            var Flag = "UNITYPE";
            $('#myModalRaise').modal();
           
            document.getElementById("iframeID").src = "PopupCompanyHistory.aspx?&Code=" + value  + "&Header=" + Header + "&Flag=" + Flag+ "&mdlpopup=myModalRaise";
        }

        function OpenUnitIns() {
            debugger;

            var modal = document.getElementById('myModalRaise');
            var strAgentType = document.getElementById('<%=txtUnitType.ClientID%>').value;
            var chnl = document.getElementById('<%=ddlchannel.ClientID %>').value;//Hierarchy Name
            var schnl = document.getElementById('<%=ddlsubchannel.ClientID %>').value;//Sub Class
            var RptSetup2 = document.getElementById('<%=ddlPriRptSetup.ClientID %>').value
            var Reltype = document.getElementById('<%=ddlreportingtype.ClientID %>').value//Relationship Type
            stragttyp = document.getElementById('<%=ddllevelagttype.ClientID %>').value //Relation Member Type
            //$('#myModalRaise').modal();
            modal.style.display = 'block';
            document.getElementById("iframeID").src = "PopUntType.aspx?"
                + "&chnl=" + chnl + "&schnl=" + schnl + "&RptSetup=" + RptSetup2 + "&RelType=" + Reltype + "&memtyp=" + strAgentType+"&stragttyp="+stragttyp+ "&untcd=" + document.getElementById('<%=ddlUnitRank.ClientID %>').value+ "&MemType01=" + document.getElementById('<%=hdnMemCode.ClientID %>').value.toString();
        }

        function openUnitView() {
            var modal = document.getElementById('myModalRaise');
             var strAgentType = document.getElementById('<%=txtUnitType.ClientID %>').value.toString();
            var chnl = document.getElementById('<%=ddlchannel.ClientID %>').value;
            var schnl = document.getElementById('<%=ddlsubchannel.ClientID %>').value;
            var RptSetup2 = document.getElementById('<%=ddlPriRptSetup.ClientID %>').value
            var Reltype = document.getElementById('<%=ddlreportingtype.ClientID %>').value
           
            modal.style.display = 'block';
            document.getElementById("iframeID").src = "PopUntView.aspx?&bizsrc=" + chnl + "&schnl=" + schnl +
                "&RptSetup=" + Reltype + "&memtyp=" + strAgentType + "&mdlpopup=mdlViewBIDUT";
        }
    </script>
    <script type="text/javascript">
          $(function () {
            debugger;
            $("#<%= txtEffDate.ClientID  %>").datepicker({ minDate: '01/04/2021', maxDate: '31/03/2023', dateFormat: 'dd/mm/yy' });
        });
         $(function () {
            $("[id*=txtEffDate]").attr("readonly", true);
            $("[id*=txtEffDate]").attr.backgroundColor = "white";
        })
          function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp, stragent, strbsdon) {
            debugger;
            var strAgentType = document.getElementById('<%=txtUnitType.ClientID%>').value;
            var chnl = document.getElementById('<%=ddlchannel.ClientID %>').value;//Hierarchy Name
            var schnl = document.getElementById('<%=ddlsubchannel.ClientID %>').value;//Sub Class
            var RptSetup2 = document.getElementById('<%=ddlPriRptSetup.ClientID %>').value
            var Reltype = document.getElementById('<%=ddlreportingtype.ClientID %>').value//Relationship Type
            stragttyp = document.getElementById('<%=ddllevelagttype.ClientID %>').value //Relation Member Type
          if (strPopUpType == "rptmgr") {
              //$("[id*=mdlViewBIDUT]").show();
              //alert('ajay');
                $find("mdlViewBIDUT").show()
            document.getElementById("ctl00_ContentPlaceHolder1_IframeUT").src = "PopUntType.aspx?Code="
                    + "&Carriercode=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&untcd=" + document.getElementById('<%=ddlUnitRank.ClientID %>').value
                    + "&subchnl=" + strsbclass + "&rptstp=" + document.getElementById('<%=hdnMemType.ClientID %>').value + "&chnl=" + chnl + "&schnl=" + schnl
                    + "&MemType01=" + document.getElementById('<%=hdnMemCode.ClientID %>').value.toString()
                    + "&bizsrc=" + strbzsrc + "&chkflag=1" + "&flag=" + stragent + "&agttyp=" + stragttyp
                    + "&RptSetup=" + RptSetup2 + "&RelType=" + Reltype + "&memtyp=" + strAgentType + "&bsdon=" + strbsdon + "&mdlpopup=mdlViewBIDUT&isPrimary=Y";
            }
        }

        function funPopUp() {
            debugger;
            var value = document.getElementById('ctl00_ContentPlaceHolder1_hdnBizsrc').value;
            var Header = "Version History Of Unit Type";
            var Flag = "UNITYPE";
            $find("mdlViewBIDUT").show()
            document.getElementById("ctl00_ContentPlaceHolder1_IframeUT").src = "PopupCompanyHistory.aspx?&Code=" + value + "&mdlpopup=mdlViewBIDUT" + "&Header=" + Header + "&Flag=" + Flag;
        }

 function AppliacbleToDate() {
            debugger;
              $("[id*=txtCseDt]").datepicker({ maxDate: '31/03/2023', minDate: '-0d', dateFormat: 'dd/mm/yy' });
         }




    </script>

    <script type="text/javascript">

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

        function popupHist() {
            $("#myModal1").modal();
        }

        function funSetUp() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            if (SpaceTrim(document.getElementById(strContent + "txtUnitType").value) == "") {
                alert("Please Enter Unit Type");
                document.getElementById(strContent + "txtUnitType").focus();

                return false;
            }

            if (SpaceTrim(document.getElementById(strContent + "txtDesc1").value) == "") {
                alert("Please Enter Unit Level Description 1");
                document.getElementById(strContent + "txtDesc1").focus();

                return false;
            }


            if (document.getElementById(strContent + "ddlUnitRank").selectedIndex == 0) {
                alert("Please Enter Unit Rank");
                document.getElementById(strContent + "ddlUnitRank").focus();
                return false;
            }

            if (SpaceTrim(document.getElementById(strContent + "txtLevel").value) == "") {

                alert("Please Enter Unit Level");
                document.getElementById(strContent + "txtLevel").focus();
                return false;
            }
            //funValidateNew();
            ////Primary Details Mandatory added by akshay on 240314
             if (document.getElementById(strContent + "ddlreportingtype") != null) {
                if (document.getElementById(strContent + "ddlreportingtype").value != "") {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddllevelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlReportingRule").value == "") {
                        alert("Please Enter Primary Relationship Details");
                        return false;
                    }
                }
            }

            
            if (document.getElementById(strContent + "chkPriMand") != null) {
                if (document.getElementById(strContent + "chkPriMand").checked == true) {
                    if (document.getElementById(strContent + "ddlPriRuleType").value == "") {
                        alert("Please Enter Primary Rule Type");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "chkPriMand") != null) {
                if (document.getElementById(strContent + "chkPriMand").checked == true) {
                    if (document.getElementById(strContent + "ddlreportingtype").value == "") {
                        alert("Please Enter Primary Relationship Type");
                        return false;
                    }
                }
            }
           
            ////Additional Details Mandatory added by akshay on 240314
            if (document.getElementById(strContent + "chkAddl1Mand") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById(strContent + "ddlam1reportingtype").selectedIndex == 0) {
                        alert("Please Enter Additional Relationship Type 1");
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "ddlam1reportingtype") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam1reportingtype").selectedIndex == 0) {
                        alert("Please Enter Additional Relationship Details");
                        return false;
                    }
                }
            }


            if (document.getElementById(strContent + "ddlam1reportingtype").selectedIndex != 0) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam1levelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlAM1RptRule").value == "") {
                        alert("Please Enter Additional Relationship Details");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlam2reportingtype") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById(strContent + "ddlam2reportingtype").selectedIndex != 0) {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam2levelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlAM2ReptRule").value == "") {
                            alert("Please Enter Additional Relationship Details");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "ddlam3reportingtype") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById(strContent + "ddlam3reportingtype").value != "") {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam3levelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlAM3RptRule").value == "") {
                            alert("Please Enter Additional Relationship Details");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "txtEffDate") != null) {
                if (document.getElementById(strContent + "txtEffDate").value == "") {
                    alert("Please Enter Effective Date");
                }
            }

        }
    </script>

    <style type="text/css">
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

        .panel-success {
            margin-left: 50px !important;
            margin-right: 50px !important;
        }
    </style>

    <script  type="text/javascript">

       <%-- $(function () {
            debugger;

            $("#<%= txtEffDate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });

        });--%>

        function popup() {
            document.getElementById('myModal').style.display = 'block';
           
        }

        function ShowReqDtl1(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                     objnewbtn.className = 'glyphicon glyphicon-chevron-down'
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

        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";

            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(document.getElementById(strContent + divId)).slideUp();
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(document.getElementById(strContent + divId)).slideDown();
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }

        //Validation for new unit type creation
        function funValidateNew() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            //Sales Channel mandatory
            if (document.getElementById('<%=ddlSalesChannel.ClientID %>').value == "Select") {
                alert("Channel category is mandatory.");
                document.getElementById('<%= ddlSalesChannel.ClientID %>').focus();
                return false;
            }
            //Sub Class mandatory
            if (document.getElementById('<%=ddlChannelClass.ClientID %>').value == "Select") {
                alert("Sub class category is mandatory.");
                document.getElementById('<%= ddlChannelClass.ClientID %>').focus();
                return false;
            }
            //Unit Type mandatory
            if (document.getElementById('<%=txtUnitType.ClientID %>').value == "") {
                alert("Unit type category is mandatory");
                document.getElementById('<%= txtUnitType.ClientID %>').focus();
                return false;
            }
            //Unit Rank mandatory
            if (document.getElementById('<%=ddlUnitRank.ClientID %>').value == "Select") {
                alert("Unit rank category is mandatory.");
                document.getElementById('<%= ddlUnitRank.ClientID %>').focus();
                return false;
            }
            //Unit Level mandatory
            if (document.getElementById('<%=txtLevel.ClientID %>').value == "") {
                alert("Unit level category is mandatory.");
                document.getElementById('<%= txtLevel.ClientID %>').focus();
                return false;
            }
            //Desc1 mandatory
            if (document.getElementById('<%=txtDesc1.ClientID %>').value == "") {
                alert("Unit level description1 Category is mandatory.");
                document.getElementById('<%= txtDesc1.ClientID %>').focus();
                return false;
            }
            ////Primary Details Mandatory added by akshay on 240314
            if (document.getElementById(strContent + "chkPriMand") != null) {
                if (document.getElementById(strContent + "chkPriMand").checked == true) {
                    if (document.getElementById(strContent + "ddlreportingtype").value == "") {
                        alert("Please Enter Primary Relationship Type");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlreportingtype") != null) {
                if (document.getElementById(strContent + "ddlreportingtype").value != "") {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddllevelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlReportingRule").value == "") {
                        alert("Please Enter Primary Relationship Details");
                        return false;
                    }
                }
            }
            ////Additional Details Mandatory added by akshay on 240314
            if (document.getElementById(strContent + "chkAddl1Mand") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById(strContent + "ddlam1reportingtype").value == "") {
                        alert("Please Enter Additional Relationship Type 1");
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "ddlam1reportingtype") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam1reportingtype").value == "") {
                        alert("Please Enter Additional Relationship Details");
                        return false;
                    }
                }
            }


            if (document.getElementById(strContent + "ddlam1reportingtype").value != "") {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam1levelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlAM1RptRule").value == "") {
                        alert("Please Enter Additional Relationship Details");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlam2reportingtype") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById(strContent + "ddlam2reportingtype").value != "") {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam2levelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlAM2ReptRule").value == "") {
                            alert("Please Enter Additional Relationship Details");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "ddlam3reportingtype") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById(strContent + "ddlam3reportingtype").value != "") {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam3levelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlAM3RptRule").value == "") {
                            alert("Please Enter Additional Relationship Details");
                            return false;
                        }
                    }
                }
            }
            if (document.getElementById(strContent + "txtEffDate") != null) {
                if (document.getElementById(strContent + "txtEffDate").value == "") {
                    alert("Please Enter Effective Date");
                }
            }


        }


        //Validation for edit unit type
        function funValidateEdit() {

            var strContent = "ctl00_ContentPlaceHolder1_";

            //Unit Rank mandatory
            if (document.getElementById('<%=ddlUnitRank.ClientID %>').value == "Select") {
                alert("Unit rank category is mandatory.");
                document.getElementById('<%= ddlUnitRank.ClientID %>').focus();
                return false;
            }
            //Unit Level mandatory
            if (document.getElementById('<%=txtLevel.ClientID %>').value == "") {
                alert("Unit level category is mandatory.");
                document.getElementById('<%= txtLevel.ClientID %>').focus();
                return false;
            }
            //Desc1 mandatory
            if (document.getElementById('<%=txtDesc1.ClientID %>').value == "") {
                alert("Unit level description1 Category is mandatory.");
                document.getElementById('<%= txtDesc1.ClientID %>').focus();
                return false;
            }
            ////Primary Details Mandatory added by akshay on 240314
            if (document.getElementById(strContent + "chkPriMand") != null) {
                if (document.getElementById(strContent + "chkPriMand").checked == true) {
                    if (document.getElementById(strContent + "ddlreportingtype").value == "") {
                        alert("Please Enter Primary Relationship Type");
                        return false;
                    }
                }
            }
            if (document.getElementById(strContent + "ddlreportingtype") != null) {
                if (document.getElementById(strContent + "ddlreportingtype").value != "") {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_ddllevelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlReportingRule").value == "") {
                        alert("Please Enter Primary Relationship Details");
                        return false;
                    }
                }
            }
            ////Additional Details Mandatory added by akshay on 240314
            if (document.getElementById(strContent + "chkAddl1Mand") != null) {
                if (document.getElementById(strContent + "chkAddl1Mand").checked == true) {
                    if (document.getElementById(strContent + "ddlam1reportingtype").value == "") {
                        alert("Please Enter Additional Relationship Type 1");
                        return false;
                    }
                }
            }

            if (document.getElementById(strContent + "ddlam1reportingtype").value != "") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_ddlam1levelagttype").value == "" || document.getElementById("ctl00_ContentPlaceHolder1_ddlAM1RptRule").value == "") {
                    alert("Please Enter Additional Relationship Details");
                    return false;
                }
            }

            if (document.getElementById(strContent + "txtEffDate") != null) {
                if (document.getElementById(strContent + "txtEffDate").value == "") {
                    alert("Please Enter Effective Date");
                }
            }
        }



        //Validate unit type from entering symbols
        function doValidateName(src, args) {
            var strMsg = 'Invalid Unit type!';
            // var result = true;
            args.IsValid = true;
            var sString = args.Value;
            sString = document.getElementById("ctl00_ContentPlaceHolder1_txtUnitType").value;
            //Check for invalid characters
            var iChars = "#%!&@$^*-_+={}[]()|\:;?><,.'~";

            for (var i = 0; i < sString.length; i++) {
                if (iChars.indexOf(sString.charAt(i)) != -1) {
                    // result = false;
                    args.IsValid = false;
                    args.IsValid = alert(strMsg);
                    return false;
                }
            }

        }

        //Validate unittype from entering number value
        function isInteger1(src, args) {
            // //debugger;
            var strMsg = 'Invalid Unit type!';
            var str = document.getElementById("ctl00_ContentPlaceHolder1_txtUnitType").getAttribute("value");
            //var result = true;
            args.IsValid = true;

            for (i = 0; i <= 99; i++) {
                if (i == str) {
                    // result = false;
                    args.IsValid = false;
                    args.IsValid = alert(strMsg);
                    return false;
                }
                // args.IsValid = result;

            }

        }

        //Unit level should be as same as unit rank
        function SameChars() {

            var sString1 = document.getElementById("ctl00_ContentPlaceHolder1_ddlUnitRank").value;
            document.getElementById("ctl00_ContentPlaceHolder1_txtLevel").value = sString1;
        }

    </script>

    <style type="text/css">
        .ajax__calendar {
            position: static;
        }

        .pagelink span {
            font-weight: bold;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        /*Added: Parag @ 25032014*/
    </style>

    <asp:ScriptManager ID="SM1" AsyncPostBackTimeout="6000" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" />
        </Scripts>
        <Services>
            <asp:ServiceReference Path="../../../Application/Common/Lookup.asmx" />
        </Services>
    </asp:ScriptManager>

    <div style="overflow: auto;">
        <table id="tblmsg" runat="server" align="center" style="width: 85%; height: 30px;" visible="false">
            <tr align="center">
                <td align="center" style="width: 79%;">
                    <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" Width="380px"
                        Height="19px"></asp:Label>
                </td>
            </tr>
        </table>


        <%--added by ajay--%>

        <div class="panel" id="divModification" runat="server">
            <div id="Div18" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify');return false;">
                <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="Label21" runat="server" Text="CORRECTION OR CHANGES IN UNIT TYPE SETUP" CssClass="control-label" Font-Size="19px"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="btndivmodify" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divmodifybody" runat="server" class="panel-body" style="display: block">
                <div class="row rowspacing" style="margin-bottom: 5px;">
                    <div class="col-md-3" style="text-align: left; margin-top: 10px;">
                        <asp:Label ID="lblModMode" Text="Mod mode" runat="server" CssClass="control-label" />
                        <span style="color: #ff0000">*</span>
                    </div>
                    <div class="col-md-3" style="text-align: left">
                        <div class="btn-group" role="group" style="margin-left: -162px;">
                            <asp:RadioButtonList ID="rbCorrection" runat="server" CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbCorrection_OnSelectedIndexChanged">
                                <asp:ListItem Text="&nbspCorrection&nbsp" Value="CR" Selected="True" class="btn btn-default" />
                                <asp:ListItem Text="&nbspChanges&nbsp" Value="CH" class="btn btn-default" style="margin-left: 0px;" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-3">
                    </div>
                </div>
            </div>
        </div>

        <%--added by ajay--%>

        <%--</div>--%>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%--<div id="divcmphdrcollapse" runat="server" style="width: 98%;" class="divBorder1">
                    <table class="formtablehdr" style="width: 100%;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                               
                                &nbsp;<asp:Label ID="lblChannelUnitTypeSetup" runat="server"  Style="padding-left: 5px;"></asp:Label>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="myImg" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divcmphdr','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>--%>

                <div class="panel" style="margin-left: 2%; margin-right: 2%;">
                    <div id="divcmpsrchhdrcollapse" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','Span1');return false;">
                        <div class="row rowspacing">
                            <div class="col-sm-10" style="text-align: left">
                                <asp:Label ID="lblChannelUnitTypeSetup" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>

                            </div>
                            <div class="col-sm-2">

                                <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>


                    <div id="divcmphdr" style="display: block;" runat="server" class="panel-body">

                        <div class="row rowspacing">
                            <%-- <asp:UpdatePanel ID="upnlSalesChannel" runat="server">

                                <ContentTemplate>--%>
                            <div class="col-sm-3" style="text-align: left">
                                <span style="font-size: 10pt; color: #ff0000;">

                                    <asp:Label ID="lblChannel" runat="server" CssClass="control-label" Style="color: Black;"></asp:Label>
                                    *</span>
                            </div>

                           
                            <div class="col-sm-3">
                                        <asp:TextBox ID="lblSalesChannel" runat="server" Visible="False" CssClass="form-control"></asp:TextBox>



                                        <asp:DropDownList ID="ddlSalesChannel" runat="server" CssClass="form-control"
                                            AutoPostBack="True" Visible="False" TabIndex="1" OnSelectedIndexChanged="ddlSalesChannel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                


                            <div class="col-sm-3">
                                <span style="font-size: 10pt; color: #ff0000;">
                                    <asp:Label ID="lblClass" runat="server" Style="color: Black;" CssClass="control-label"></asp:Label>
                                    *</span>
                            </div>

                           
                            <div class="col-sm-3">
                                        <asp:TextBox ID="lblChnCls" runat="server" Visible="False" CssClass="form-control"></asp:TextBox>



                                        <asp:DropDownList ID="ddlChannelClass" runat="server" CssClass="form-control"
                                            Visible="False" TabIndex="2">
                                        </asp:DropDownList>

                                    </div>


                             <%--   </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSalesChannel" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>--%>
                        </div>

                        <div class="row rowspacing">

                            <div class="col-sm-3" style="text-align: left">
                                <span style="font-size: 10pt; color: #ff0000;">
                                    <asp:Label ID="lblUnittype" runat="server" Style="color: Black;"
                                        CssClass="control-label"></asp:Label>
                                    *</span>
                            </div>

                            <div class="col-sm-3">
                                <asp:TextBox ID="txtUnitType" runat="server" TabIndex="3" CssClass="form-control" OnTextChanged="txtUnitType_TextChanged" AutoPostBack="true"
                                    MaxLength="2" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>




                                <%--<asp:TextBox ID="lblType" runat="server" Visible="False" CssClass="form-control" TabIndex="4"></asp:TextBox>--%><%--Commented by meena 19/3/18--%>
                                <asp:CustomValidator ID="cvUnitType" runat="server" ControlToValidate="txtUnitType"
                                    SetFocusOnError="True" ClientValidationFunction="doValidateName"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvType" runat="server" ControlToValidate="txtUnitType" SetFocusOnError="True"
                                    ClientValidationFunction="isInteger1"></asp:CustomValidator>
                                <ajaxToolkit:FilteredTextBoxExtender ID="txtUnitTypeFTX" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz,-.()/& "
                                    TargetControlID="txtUnitType" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <span style="font-size: 10pt; color: #ff0000;">
                                    <asp:Label ID="lblDesc1" runat="server" Style="color: Black;" CssClass="control-label"></asp:Label>
                                    *</span>
                            </div>

                            <div class="col-sm-3">
                                <asp:TextBox ID="txtDesc1" runat="server" TabIndex="5" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row rowspacing">

                            <div class="col-sm-3" style="text-align: left">
                                <span style="font-size: 10pt; color: #ff0000;">
                                    <asp:Label ID="lblRank" runat="server" Style="color: Black;" CssClass="control-label"></asp:Label>
                                    *</span>
                            </div>

                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlUnitRank" runat="server" CssClass="form-control"
                                    TabIndex="6" padding-top="5px">
                                </asp:DropDownList>
                            </div>

                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDesc2" runat="server" CssClass="control-label"></asp:Label>
                            </div>

                            <div class="col-sm-3">
                                <asp:TextBox ID="txtDesc2" runat="server" TabIndex="7" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row rowspacing">

                            <div class="col-sm-3" style="text-align: left">
                                <span style="font-size: 10pt; color: #ff0000;">
                                    <asp:Label ID="lblLevel" runat="server" Style="color: Black;" CssClass="control-label"></asp:Label>
                                    *</span>
                            </div>

                            <div class="col-sm-3">
                                <asp:TextBox ID="txtLevel" runat="server" TabIndex="8" CssClass="form-control"
                                    MaxLength="9"></asp:TextBox>&nbsp;
                                       
                                    
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_UnitLevel" runat="server"
                                        ValidChars="01234567890." TargetControlID="txtLevel" FilterType="Custom">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                            </div>


                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblDesc3" runat="server" CssClass="control-label"></asp:Label>
                            </div>


                            <div class="col-sm-3">
                                <asp:TextBox ID="txtDes3" runat="server" TabIndex="9" CssClass="form-control" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row rowspacing">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblMgr" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlMultiMgr" runat="server" CssClass="form-control"
                                    TabIndex="10">
                                </asp:DropDownList>
                            </div>
                            <asp:CheckBox ID="chkManager" CssClass="standardcheckbox" TabIndex="11" runat="server" Visible="false" />
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAllowSales" runat="server" CssClass="control-label"></asp:Label>

                                <asp:CheckBox ID="chkSales" runat="server" CssClass="standardcheckbox" TabIndex="12" />
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblAllowServices" runat="server" CssClass="control-label"></asp:Label>

                                <asp:CheckBox ID="chkServices" CssClass="standardcheckbox" runat="server" TabIndex="13" />
                            </div>

                        </div>



                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <%-- Added by Miti for adding new linkage on 19/11/2013 start--%>
        <div id="div3" runat="server" style="width: 98%;" visible="false" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-list"></i>
                        <%--Added By Ibrahim on 18-05-2013 modified class="formtitle" to class="test" to change banner background --%>
                        &nbsp;<asp:Label ID="lblMasterUnitDetails" runat="server" Text="Master Unit Details"></asp:Label>
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                        <img id="Img1" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('div1','Img1','#Img1');" />
                    </td>
                </tr>
            </table>

            <div id="div1" runat="server" style="width: 100%; padding: 10px;">

                <asp:Label ID="LblAllowLink" runat="server" Text="Link to Master unit?" CssClass="control-label"></asp:Label>

                <asp:UpdatePanel runat="server" ID="upnlLinkMst">
                    <ContentTemplate>
                        <asp:CheckBox ID="ChkLinkMst" runat="server" AutoPostBack="True" TabIndex="14" OnCheckedChanged="ChkLinkMst_SelectedIndexChanged" />
                    </ContentTemplate>
                </asp:UpdatePanel>



                <asp:UpdatePanel runat="server" ID="upnlLblSalesChannelLink">
                    <ContentTemplate>
                        <asp:Label ID="lblSalesChannelLink" runat="server" Text="Channel" Enabled="false"
                            CssClass="control-label"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkLinkMst" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>


                <asp:UpdatePanel runat="server" ID="upnlSalesChannelLink">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesChannelLink" runat="server" CssClass="standardmenu"
                            TabIndex="15" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesChannelLink_SelectedIndexChanged"
                            Enabled="false">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel runat="server" ID="upnlLblChnnlSubClass">
                    <ContentTemplate>
                        <asp:Label ID="lblChnnlSubClass" runat="server" Text="Sub class" Enabled="false"
                            CssClass="control-label"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkLinkMst" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlChnnlSubClass">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlChnnlSubClass" runat="server" CssClass="select2-container form-control"
                            TabIndex="16" OnSelectedIndexChanged="ddlChnnlSubClass_SelectedIndexChanged"
                            AutoPostBack="True" Enabled="false">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesChannelLink" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="ChkLinkMst" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlLblUnitLevel">
                    <ContentTemplate>
                        <asp:Label ID="lblUnitDesc" CssClass="control-label" runat="server" Text="Unit Desc"
                            Enabled="false"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkLinkMst" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlUnitDesc">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlUnitDesc" runat="server" CssClass="select2-container form-control"
                            AutoPostBack="True" TabIndex="17" Enabled="false">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesChannelLink" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>


                <asp:Label ID="lblStaffDetails" runat="server" CssClass="control-label" Text="Staff Details"
                    Font-Bold="true"></asp:Label>



                <asp:Label ID="Label1" runat="server" Text="Link to staff?" CssClass="control-label"></asp:Label>

                <asp:UpdatePanel runat="server" ID="upnlStaff">
                    <ContentTemplate>
                        <asp:CheckBox ID="ChkStaff" runat="server" AutoPostBack="True" TabIndex="18" OnCheckedChanged="ChkStaff_SelectedIndexChanged" />
                    </ContentTemplate>
                </asp:UpdatePanel>


                <asp:UpdatePanel runat="server" ID="upnlLblSalesChannelStaff">
                    <ContentTemplate>
                        <asp:Label ID="lblSalesChannelStaff" runat="server" Text="Channel" CssClass="control-label"
                            Enabled="false"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkStaff" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlSalesChannelStaff">
                    <ContentTemplate>
                        <asp:DropDownList ID="DdlSalesChannelStaff" runat="server" CssClass="standardmenu"
                            TabIndex="19" AutoPostBack="True" OnSelectedIndexChanged="DdlSalesChannelStaff_SelectedIndexChanged"
                            Enabled="false">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkStaff" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlLblChannelsubStaff">
                    <ContentTemplate>
                        <asp:Label ID="lblChannelsubStaff" runat="server" CssClass="control-label" Text="Sub class"
                            Enabled="false"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkStaff" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlChannelsubStaff">
                    <ContentTemplate>
                        <asp:DropDownList ID="DdlChannelsubStaff" runat="server" CssClass="standardmenu"
                            TabIndex="20" OnSelectedIndexChanged="DdlChannelsubStaff_SelectedIndexChanged"
                            AutoPostBack="True" Enabled="false">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DdlSalesChannelStaff" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="ChkStaff" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlLblAgtType">
                    <ContentTemplate>
                        <asp:Label ID="LblAgtType" runat="server" Text="Agent Type" CssClass="control-label"
                            Enabled="false"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ChkStaff" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <asp:UpdatePanel runat="server" ID="upnlAgentType">
                    <ContentTemplate>
                        <asp:DropDownList ID="DdlAgentType" runat="server" CssClass="standardmenu" AutoPostBack="True"
                            TabIndex="21" Enabled="false">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DdlSalesChannelStaff" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="ChkStaff" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>

                <%-- Added by Miti for adding new linkage on 19/11/2013 end--%>
                <%--Added by akshay for adding primary reporting details on 07/02/2014 start--%>
            </div>
        </div>
        <br />

        <%--Added by AJAY  for model popup Start--%>

        <div class="modal fade" id="myModal1" role="dialog">
            <div class="modal-dialog modal-sm" style="width: auto; padding: 49px">
                <!-- Modal content-->
                <%--<div class="modal-content" style="height: 380px; width: 706px">--%>
                <div class="modal-content">
                    <div class="modal-header" style="text-align: center; text-align: initial; background-color: #dff0d8;">
                        <asp:Label ID="Label31" Text="Version history of unit type setup" runat="server" Font-Bold="true" Style="font-size: initial"></asp:Label>
                    </div>
                    <div class="panel" id="div2" runat="server" style="margin-left: 2%; margin-right: 2%;">
                        <div id="Div19" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divmodifybody','btndivmodify1');return false;">
                            <div class="row rowspacing">
                                <div class="col-sm-10" style="text-align: left">
                                    <asp:Label ID="Label23" runat="server" Text="Search Result" CssClass="control-label" Font-Size="19px"></asp:Label>
                                </div>
                                <div class="col-sm-2">
                                </div>
                            </div>
                        </div>
                        <div id="div20" runat="server" class="panel-body" style="display: block">
                            <div class="row rowspacing" style="margin-bottom: 5px;">
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="Label24" runat="server" Text="Modification Mode" CssClass="control-label" />
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:RadioButtonList ID="rdMode" runat="server" CellPadding="2" CellSpacing="2"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Text="&nbspCorrection&nbsp" Value="CR">  </asp:ListItem>
                                        <asp:ListItem Text="&nbspChanges&nbsp" Value="CH"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-3" style="text-align: left">
                                    <asp:Label ID="lblFinyer" Text="Financial year" CssClass="control-label" runat="server" />
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlFinYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                                </div>
                            </div>

                        </div>
                    </div>

                    <div id="div21" runat="server" style="width: 98%;">
                        <div class="row rowspacing">
                            <div class="col-md-12" style="text-align: center">
                                <%-- <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sample"
                                    CausesValidation="false" TabIndex="14" OnClick="btnSearch_Click">--%>
                                <span class="glyphicon glyphicon-search BtnGlyphicon" style="color: White"></span>Search </asp:LinkButton>
                                <button type="button" class="btn btn-sample" data-dismiss="modal">
                                    <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCancel
                                </button>
                            </div>
                        </div>
                    </div>

                    <div class="modal-body" style="text-align: center">
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                        <div id="divsrch" runat="server" class="panel-body" style="display: block; overflow: auto">
                            <asp:GridView AllowSorting="True" ID="gvhistory" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" CssClass="footable"
                                AutoGenerateColumns="False" PageSize="10" AllowPaging="true" CellPadding="1">
                                <FooterStyle CssClass="GridViewFooter" />
                                <RowStyle CssClass="GridViewRowNew" />
                                <HeaderStyle CssClass="gridview" />
                                <PagerStyle CssClass="disablepage" />
                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChnClsDesc01") %>'
                                                CommandArgument='<%# Eval("ChnClsDesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Channel Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ChannelCode") %>'
                                            CommandArgument='<%# Eval("ChannelCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>--%>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Channel Desc.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("channeldesc01") %>'
                                                CommandArgument='<%# Eval("channeldesc01") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitType" runat="server" Text='<%# Eval("UnitType") %>'
                                                CommandArgument='<%# Eval("UnitType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Level Description 1">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitType" runat="server" Text='<%# Eval("UnitType") %>'
                                                CommandArgument='<%# Eval("UnitType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Rank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitRank" runat="server" Text='<%# Eval("UnitRank") %>'
                                                CommandArgument='<%# Eval("UnitRank") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Unit Level">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitLevel" runat="server" Text='<%# Eval("UnitLevel") %>'
                                                CommandArgument='<%# Eval("UnitLevel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Allow Multiple Unit Manager">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("AlwMultiUntMgr") %>'
                                                CommandArgument='<%# Eval("AlwMultiUntMgr") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>


                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Allow Services">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("AlwSvc") %>'
                                                CommandArgument='<%# Eval("AlwSvc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>





                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Rule Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("RptRule") %>'
                                                CommandArgument='<%# Eval("RptRule") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Mod. Mode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("ModMode") %>'
                                                CommandArgument='<%# Eval("ModMode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Financial Year">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period") %>'
                                                CommandArgument='<%# Eval("Period") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Version">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Version") %>'
                                                CommandArgument='<%# Eval("Version") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Start Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("EffDate") %>'
                                                CommandArgument='<%# Eval("EffDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="End Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CeaseDate") %>'
                                                CommandArgument='<%# Eval("CeaseDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Status") %>'
                                                CommandArgument='<%# Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Modifier">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateBy") %>'
                                                CommandArgument='<%# Eval("UpdateBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Modified Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("UpdateDtim") %>'
                                                CommandArgument='<%# Eval("UpdateDtim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Creator">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateBy") %>'
                                                CommandArgument='<%# Eval("CreateBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("CreateDtim") %>'
                                                CommandArgument='<%# Eval("CreateDtim") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textCenter" Font-Bold="False"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="modal-body" style="text-align: center">
                        <asp:Label ID="lbl_popup1" runat="server"></asp:Label>

                    </div>

                    <div class="modal-footer" id="DivButton" visible="false" runat="server" style="text-align: center">
                        <button type="button" visible="false" runat="server" class="btn btn-sample" data-dismiss="modal" style='margin-top: -93px; border-radius: 15px;'>
                            <span class="glyphicon glyphicon-remove BtnGlyphicon" style='color: White;'></span>&nbspCancel
                        </button>
                    </div>
                </div>
            </div>
        </div>


        <%--Added by AJAY for model popup END--%>

        <%-- <div id="divPrRepDtlshdr" runat="server" style="width: 98%;" class="divBorder1">

          <table width="100%" class="formtablehdr">
                                        <tr style="height: 30px;">
                                              <td style="padding-left: 5px;">
                                              <i class="fa fa-list"></i>
                                <asp:Label ID="lblPrReptDtls" runat="server"  Style=""></asp:Label>
                            </td>
                              
                             <td align="left">
                                <asp:UpdatePanel ID="upPriMand" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkPriMand" runat="server" Enabled="true" Checked="false" Text="Is Mandatory"
                                            TabIndex="12" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                                <img id="Img2" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('divPrRepDtls','Img2','#Img2');" />
                            </td>
                        </tr>
                        </table>--%>


        <div class="panel" style="margin-left: 2%; margin-right: 2%;">
            <div id="divPrRepDtlshdr" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divPrRepDtls','btnpersnl');return false;">
                <div class="row rowspacing">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblPrReptDtls" runat="server" CssClass="control-label" Font-Size="19px"></asp:Label>


                    </div>
                    <div class="col-sm-2">

                        <span id="btnpersnl" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            <div id="divPrRepDtls" runat="server" style="display: block;" class="panel-body">

                <div class="row" style='margin: 5px;'>
                    <div class="col-sm-12" style="text-align: left">
                        <asp:UpdatePanel ID="upPriMand" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkPriMand" runat="server" CssClass="standardcheckbox" Enabled="true" Checked="false" Text="Is Mandatory"
                                    AutoPostBack="true" OnCheckedChanged="chkPriMand_CheckedChanged" TabIndex="22" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <br />
                 <div class="row rowspacing">

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblPriRuleTyp" Text="Rule Type" runat="server" CssClass="control-label" />
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="updPriRuleType" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlPriRuleType" AutoPostBack="true" CssClass="form-control"
                                TabIndex="23" OnSelectedIndexChanged="ddlPriRuleType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblddlreportingtype" runat="server" CssClass="control-label"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upReptType" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlreportingtype" runat="server"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlreportingtype_SelectedIndexChanged" CssClass="form-control"
                                TabIndex="24">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlchannel" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                 </div>
                 <div class="row rowspacing">

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblRptRule" runat="server" CssClass="control-label"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upReptRule" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlReportingRule" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="25">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblPrichannel" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upChannel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlchannel" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlchannel_SelectedIndexChanged"
                                TabIndex="26">
                                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlsubchannel" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
             </div>
                 <div class="row rowspacing">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblPrisubchannel" runat="server" CssClass="control-label"></asp:Label>
                </div>


                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upSubChannel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlsubchannel" runat="server" AutoPostBack="true"
                                CssClass="form-control" OnSelectedIndexChanged="ddlsubchannel_SelectedIndexChanged"
                                TabIndex="27">
                                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlbasedon" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblPribasedon" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upBasedOn" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlbasedon" runat="server" AutoPostBack="True"
                                CssClass="form-control" OnSelectedIndexChanged="ddlbasedon_SelectedIndexChanged"
                                TabIndex="28">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddllevelagttype" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>

                      </div>
                 <div class="row rowspacing">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblPrilevelagttype" runat="server" CssClass="control-label"></asp:Label>
                </div>


                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upLevelAgtType" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddllevelagttype" runat="server"
                                CssClass="form-control" AutoPostBack="True"
                                TabIndex="29" OnSelectedIndexChanged="ddllevelagttype_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblPriRptSetup" Text="Reporting Setup" runat="server" CssClass="control-label" />
                </div>

              <%--  <div class="col-sm-3">
                    <asp:UpdatePanel ID="updPriStp" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlPriRptSetup" runat="server" TabIndex="30" AutoPostBack="true" CssClass="form-control">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>--%>
                  <div class="col-sm-3">
                    <asp:UpdatePanel ID="updPriStp" runat="server">
                        <ContentTemplate>
                             <div style="display: flex;">
                            <asp:DropDownList ID="ddlPriRptSetup" runat="server" TabIndex="30" AutoPostBack="true" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:Button ID="btnRptMgr" TabIndex="33" runat="server" CssClass="btn btn-success" Text="...." Style="margin-left: 2px;"
                                             OnClientClick="OpenUnitIns();return false;"/> 
                                  <asp:LinkButton ID="lnkBtnModel" runat="server" Text="View Relation" OnClientClick="openUnitView();return false;"></asp:LinkButton>
                            <input id="hdnMemRole" type="hidden" runat="server" /><%--by meena--%>
                                             <asp:HiddenField ID="hdnMemType" runat="server" /><%--by meena--%>
                                             <asp:HiddenField ID="hdnMemCode" runat="server" /><%--by meena--%>
                                              <input type="hidden" id="hdnRptSetup" runat="server" /><%--by meena--%>
                                 </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                      </div>
               

            </div>
        </div>
        <br />
        <%--Added by akshay for adding primary reporting details on 07/02/2014 end--%>
        <%--Added by akshay for adding additional manager reporting details on 07/02/2014 end--%>

        <%-- <div id="div5" runat="server" style="width: 98%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblAddlRDtls" Text="Hierarchy Setup" runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                        <img id="Img3" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('div6','Img3','#Img3');" />
                    </td>
                </tr>
            </table>--%>

        <div class="panel" style="margin-left: 2%; margin-right: 2%;">

            <div id="div5" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div6','Span2');return false;">

                <div class="row rowspacing">

                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lblAddlRDtls" Text="Hierarchy Setup" runat="server" CssClass="control-label" Font-Size="19px" />

                    </div>

                    <div class="col-sm-2">
                        <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>

                </div>

            </div>

            <div id="div6" runat="server" style="display: block;" class="panel-body">

                <div class="row" style='margin-bottom: 20px;'>
                    <div class="col-sm-12" style='margin-left: 16px;'>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkAddl1Mand" runat="server" TabIndex="31" Text="Is Mandatory" CssClass="standardcheckbox" AutoPostBack="true"
                                    OnCheckedChanged="chkAddl1Mand_CheckedChanged" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row rowspacing">

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="Label2" Text="Rule Type" runat="server" CssClass="control-label" />
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="updAdlRulTyp" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlAdlRuleType" AutoPostBack="true" CssClass="form-control"
                                TabIndex="32" OnSelectedIndexChanged="ddlAdlRuleType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAddlMRptTyp" runat="server" CssClass="control-label"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upAm1ReptType" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlam1reportingtype" runat="server" CssClass="select2-container form-control"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlam1reportingtype_SelectedIndexChanged"
                                TabIndex="33">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlam1channel" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                    </div>
                <div class="row rowspacing">

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAddlMRptRule" CssClass="control-label" runat="server"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upAM1RptRule" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlAM1RptRule" runat="server" CssClass="form-control"
                                TabIndex="34" OnSelectedIndexChanged="ddlAM1RptRule_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAddlMChnl" CssClass="control-label" runat="server"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upAm1Channel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlam1channel" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlam1channel_SelectedIndexChanged"
                                TabIndex="35">
                                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlam1subchannel" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                     </div>
                <div class="row rowspacing">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAddlMSubCls" CssClass="control-label" runat="server"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upAm1SubChannel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlam1subchannel" runat="server" CssClass="form-control"
                                OnSelectedIndexChanged="ddlam1subchannel_SelectedIndexChanged" TabIndex="36">
                                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlam1basedon" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAddlMBsdOn" CssClass="control-label" runat="server"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upAm1BasedOn" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlam1basedon" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlam1basedon_SelectedIndexChanged"
                                TabIndex="37">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlam1levelagttype" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                     </div>
                <div class="row rowspacing">

                <%--<div class="row rowspacing">--%>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAMLvlAgtTyp" CssClass="control-label" runat="server"></asp:Label>
                </div>

                <div class="col-sm-3">
                    <asp:UpdatePanel ID="upAm1LvlAgtType" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlam1levelagttype" runat="server" CssClass="form-control"
                                TabIndex="38" OnSelectedIndexChanged="ddlam1levelagttype_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAdlRptStp" CssClass="control-label" Text="Reporting Setup" runat="server" />
                </div>
                <div class="col-sm-3">
                        <asp:UpdatePanel ID="updAdStp" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlAdlRptStp" TabIndex="39" runat="server" AutoPostBack="true" CssClass="form-control">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                     </div>
                <div class="row rowspacing">

                <div id="tradnmgr4" runat="server" style="display: none">

                    
                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblmandate2" CssClass="control-label" runat="server"></asp:Label>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkAddl2Mand" runat="server" CssClass="standardcheckbox" TabIndex="40" Enabled="False" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left"></div>
                    <div class="col-sm-3" style="text-align: left"></div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAddlMRptTyp1" CssClass="control-label" runat="server"></asp:Label>
                    </div>

                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upAm2ReptType" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlam2reportingtype" TabIndex="41" runat="server" CssClass="form-control"
                                    Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlam2reportingtype_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlam2channel" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAddlMChnl1" CssClass="control-label" runat="server"></asp:Label>
                    </div>

                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upAm2Channel" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlam2channel" TabIndex="42" runat="server" Enabled="false" CssClass="form-control"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlam2channel_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlam2subchannel" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAddlMSubCls1" CssClass="control-label" runat="server"></asp:Label>
                    </div>

                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upAm2SubChannel" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlam2subchannel" runat="server" Enabled="false" TabIndex="43" CssClass="form-control"
                                    OnSelectedIndexChanged="ddlam2subchannel_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlam2basedon" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAddlMBsdOn1" CssClass="control-label" runat="server"></asp:Label>
                    </div>

                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upam2BasedOn" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlam2basedon" runat="server" CssClass="form-control" TabIndex="44"
                                    Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="ddlam2basedon_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlam2levelagttype" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAMLvlAgtTyp1" runat="server" CssClass="control-label"></asp:Label>
                    </div>

                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upLvlAgttype" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlam2levelagttype" runat="server" CssClass="form-control" TabIndex="45"
                                    Enabled="false">
                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-sm-3" style="text-align: left">
                        <asp:Label ID="lblAddlMRptRule1" runat="server" CssClass="control-label"></asp:Label>
                    </div>

                    <div class="col-sm-3">
                        <asp:UpdatePanel ID="upam2reptrule" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlAM2ReptRule" runat="server" CssClass="form-control" TabIndex="46"
                                    Enabled="False">
                                    <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>

            </div>

        </div>

        <br />

        <%--<div id="div7" runat="server" style="width: 98%;" class="divBorder1">
            <table class="formtablehdr" style="width: 100%;">
                <tr style="height: 30px;">
                    <td style="padding-left: 5px;">
                        <i class="fa fa-list"></i>
                        <asp:Label ID="lblhdr" runat="server" Style="padding-left: 5px;" />
                    </td>
                    <td style="text-align: right; border-right-color: #3399ff; padding-right: 10px;">
                        <img id="Img4" src="../../../assets/img/portlet-collapse-icon-white.png" alt="" onclick="ShowReqDtl('div8','Img4','#Img4');" />
                    </td>
                </tr>
            </table>--%>
    </div>

    <div class="panel" style="margin-left: 2%; margin-right: 2%;">
        <div id="div7" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_div8','btnTrComp');return false;">
            <div class="row rowspacing">
                <div class="col-sm-10" style="text-align: left;">
                    <asp:Label ID="lblhdr" runat="server" Style="padding-left: 5px;" CssClass="control-label" Font-Size="19px" />

                </div>
                <div class="col-sm-2">
                    <span id="btnTrComp" class="glyphicon glyphicon-chevron-down" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>

            </div>
        </div>

        <div id="div8" runat="server" style="display: block;" class="panel-body">
             <div class="row" >

            <div class="col-sm-3" style="text-align: left">
                <asp:Label ID="lblPer" runat="server" CssClass="control-label" />
            </div>

            <div class="col-sm-3">
                <asp:DropDownList ID="ddlFinancialYr" runat="server" CssClass="form-control" TabIndex="10" Style="margin-left: 2px" MaxLength="9" />
                <asp:TextBox ID="txtFinYr" runat="server" CssClass="form-control" TabIndex="47" Visible="false" />
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" FilterType="Custom, Numbers"
                    runat="server" ValidChars="-" TargetControlID="txtFinYr">
                </ajaxToolkit:FilteredTextBoxExtender>
            </div>


            <div class="col-sm-3" style="text-align: left">
                <asp:Label ID="lblVer" runat="server" CssClass="control-label"></asp:Label>
            </div>

            <div class="col-sm-3">
                <asp:TextBox ID="txtVer" runat="server" CssClass="form-control" TabIndex="48" />
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" FilterType="Custom, Numbers"
                    runat="server" ValidChars="." TargetControlID="txtVer">
                </ajaxToolkit:FilteredTextBoxExtender>
            </div>
                 </div>
             <div class="row rowspacing" >

            <div class="col-sm-3" style="text-align: left">
                <asp:Label ID="lblEffDate" runat="server" CssClass="control-label" /><span style="font-size: 10pt; color: #ff0000;"> *</span>
            </div>

            <div class="col-sm-3">
                <%--<asp:TextBox ID="txtEffDate" runat="server" onchange="setDateFormat('txtEffDate')" TabIndex="49"
                    onmousedown="$('#txtEffDate').datepicker({ changeMonth: true, changeYear: true });" CssClass="form-control" />--%>
                 <asp:TextBox ID="txtEffDate" runat="server" CssClass="form-control" TabIndex="12" style="margin-left:2px;background-color:white !important"/>
                                       
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="/" TargetControlID="txtEffDate">
                                        </ajaxToolkit:FilteredTextBoxExtender>
            </div>

            <div class="col-sm-3" style="text-align: left">
                <asp:Label ID="lblCseDt" runat="server" CssClass="control-label" />
            </div>
            <div class="col-sm-3">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                <ContentTemplate>
<%--                <asp:TextBox ID="txtCseDt1" runat="server" CssClass="form-control" TabIndex="50" />--%>
                <asp:TextBox ID="txtCseDt" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"   onmousedown="AppliacbleToDate()" onmouseup="AppliacbleToDate()"/>
</ContentTemplate>

                 </asp:UpdatePanel>
            </div>
                 </div>
            <%--  <ajaxToolkit:CalendarExtender ID="txtCseEXT" CssClass="ajax__calendar" PopupButtonID="img"
                                            Format="dd/MM/yyyy" TargetControlID="txtCseDt" runat="server">
                                        </ajaxToolkit:CalendarExtender>
                                       
                                        
                                            <asp:Image ID="Image1" runat="server" Height="20px"  Width="20px" CssClass=".ajax__calendar"
                                                ImageUrl="~/App_UserControl/Common/calendar.bmp" style='margin-left:3px;' />
                                       
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" FilterType="Custom, Numbers"
                                            runat="server" ValidChars="/" TargetControlID="txtCseDt">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
            <%--//added by ajay START--%>

             <div class="row rowspacing" >
            <div class="col-sm-3" style="text-align: left">
                <asp:Label ID="lblSubChnStatus" Text="Status" runat="server" CssClass="control-label" />
                <span style="color: #ff0000">*</span>
            </div>
            <div class="col-sm-3">
                <asp:DropDownList Enabled="false" ID="ddllStatus" CssClass="form-control" runat="server">
                    <asp:ListItem   Value="">Draft</asp:ListItem>
                    <asp:ListItem Selected="True" Value="">Final</asp:ListItem>
                </asp:DropDownList>
            </div>
                 </div>
            <%--//added by ajay END--%>
        </div>

    </div>

    <div class="row rowspacing" style="margin-top: 12px;">
        <div class="col-sm-12" align="center">

            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" OnClientClick="return funSetUp();"
                CausesValidation="false" TabIndex="14">
                                  <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> SAVE
            </asp:LinkButton>&nbsp;

                                <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success" CausesValidation="true"
                                    Text="UPDATE" OnClientClick="return funSetUp();" OnClick="btnUpdate_Click"
                                    TabIndex="51">
                          <span class="glyphicon glyphicon-floppy-disk BtnGlyphicon"></span> UPDATE
                                </asp:LinkButton>
            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-clear" CausesValidation="False"
                OnClick="btnCancel_Click" TabIndex="52">
                             <span  style="color:#f04e5e" class="glyphicon glyphicon-remove BtnGlyphicon"> </span> CANCEL
            </asp:LinkButton>

            <asp:LinkButton ID="btnshowHist" runat="server" CssClass="btn btn-success"  OnClientClick="OpenElement();return false;"  
                CausesValidation="false" TabIndex="15">
                        <span class="glyphicon glyphicon-dashboard" style="color:White"> </span> VIEW HISTORY
            </asp:LinkButton>
        </div>
    </div>

    <%--Modal popup Setup Div  --%>
    <asp:Panel runat="server" ID="PnlPopupLOB" Style="width:1000px; height:550px; display: none; top:52px; left:529px">
        <iframe runat="server" id="IframeUT" width="100%" frameborder="0" style="height: 100%;"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lblpopup" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="MdlPopExtndrLOB" BehaviorID="mdlViewBIDUT"
        DropShadow="false" TargetControlID="lblpopup" PopupControlID="PnlPopupLOB" BackgroundCssClass="modalPopupBg">
    </ajaxToolkit:ModalPopupExtender>
    <%--modal popup start 3--%>
            <div class="modal" id="myModalRaise" data-toggle="modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top: 0px; margin-top:-2px;margin-bottom:-31px">
        
                         <div class="modal-dialog" style="padding-top: 0px; margin-top: 2px; width: 95%;">
                <div class="modal-content" style=" width: 238%; margin-left: -335px;">
                    <div class="modal-header" style="background-color:#33bbff; color:white; margin-bottom: -20px; padding-bottom: 10px ! important;">
                         <%--<div class="row">--%>
                               <div class="col-sm-10" style="text-align: left"></div>
                                <div class="col-sm-2" style="text-align: left">
                                   <button type="button" class="close" onclick="closePopUp();" style="margin-top:-7px; color:blue;" aria-hidden="true">&times;</button>
                                </div>
                             <%--</div>--%>
                          
                    </div>
                    <div class="modal-body"><br />
                          <iframe id="iframeID"  width="100%"  height="350" frameborder="0" allowtransparency="true"></iframe>
                        <%--hiii--%>
                    </div>
                    <div class="modal-footer" style="display: none">
                    </div>
                </div>
                
            </div>
            
                        </div>
      <%--modal popup end 3--%>

    <div class="modal" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="text-align: center; background-color: #00cccc !important;">
                    <asp:Label ID="Label3" Text="INFORMATION" runat="server" style="margin-left: 84px;color: blue;font-size: 17px;"></asp:Label>

                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbl_popup" runat="server"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="closePopUp();" style='margin-top: -6px; margin-right: 113px;'>
                        <span class="glyphicon glyphicon-ok" style='color: White;'></span>OK

                    </button>

                </div>
            </div>

        </div>
    </div>

    <asp:HiddenField ID="hdnBizsrc1" runat="server" />
    <script type="text/javascript">
        hideRadioSymbol();
        function hideRadioSymbol() {
            debugger;
            var rads = new Array();
            rads = document.getElementsByName('ctl00$ContentPlaceHolder1$rbCorrection'); //Whatever ID u have given to ur radiolist.
            for (var i = 0; i < rads.length; i++)
                document.getElementById(rads.item(i).id).style.display = 'none'; //hide
        }

    </script>

</asp:Content>
