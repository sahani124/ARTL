<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="ProductDef.aspx.cs" Inherits="Application_ISys_Saim_RuleSetPages_ProductDef" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--  <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <%--<link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />--%>
    <link href="../../../../KMI Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <%-- <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />--%>
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <style type="text/css">
        .new_text_new {
            color: #066de7;
        }

        .form-submit-button {
        }

        .disablepage {
            display: none;
        }

        .divBorder {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }

        .divBorder1 {
            border: 1px solid #3399ff;
            border-top: 0;
        }

        .align {
            text-align: left;
        }

        .rowalign {
            margin-bottom: 15px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function ShowReqDtl1(divName, btnName) {
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
                ////ShowError(err.description);
            }
        }
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../../assets/img/portlet-expand-icon-white.png');
            }
            else {

                $(img).attr('src', '../../../../assets/img/portlet-collapse-icon-white.png')
            }
        }



        function doOk(rultyp, flag) {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            window.parent.document.getElementById("Button10").click();
        }


        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            //            if (window.parent.document.getElementById("btncmp") != null) {
            //                ////alert("btncmp");
            //                window.parent.document.getElementById("btncmp").click();
            //                ////alert("btncmp2564654");
            //            }
            //            else {

            //                ///alert("no btncmp");
            //            }
        }


        function PopulateCalender() {
            //minDate:new Date()
            $("#<%= txtEffDtFrm.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });

        }

        function PopulateCalenderTo() {
            //minDate:new Date()
            $("#<%= txtEffDtTo.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', onSelect: function (d, i) {
                    if (d != i.lastVal) {
                        debugger;
                        $(this).change()
                        checkDate();
                    }
                }
            });

        }



        function checkDate() {
            debugger;

            var fromDate = $('#<%= txtEffDtFrm.ClientID  %>').val();
            var toDate = $('#<%= txtEffDtTo.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";
            // alert(fromDate);
            //alert(toDate);
            debugger;
            if (fromDate != "" && toDate != "") {
                if (!checkDateIsGreaterThanToday(fromDate, toDate)) {

                    alert("Effective  From Date should not be greater than Effective To Date.");
                    document.getElementById("<%= txtEffDtFrm.ClientID %>").value = "";

                    return false;

                }
                else {

                    CheckDateWithinDate();
                }
            }
            else {

            }


        }

        function checkDateIsGreaterThanToday(fromDay, toDay) {
            debugger;
            var fromArr = fromDay.split('/');
            var toArr = toDay.split('/');

            if (fromArr[2] == toArr[2]) {
                if (fromArr[1] < toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else if (fromArr[1] == toArr[1]) {
                    if (fromArr[0] <= toArr[0]) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            else if (fromArr[2] < toArr[2]) {

                return true;

            }
            else {
                return false;
            }
        }




        function validate() {
            var strcontent = "ctl00_ContentPlaceHolder1_";
            //ddlProduct
            //            if (document.getElementById(strcontent + "ddlProduct") != null) {
            //                if (document.getElementById(strcontent + "ddlProduct").value == "") {
            //                    alert("Please Select Product Code.  ");
            //                    document.getElementById(strcontent + "ddlProduct").focus();
            //                    return false;
            //                }
            //            }

            //ddlfreguency
            if (document.getElementById(strcontent + "ddlfreguency") != null) {
                if (document.getElementById(strcontent + "ddlfreguency").value == "") {
                    alert("Please Select Frequency.");
                    document.getElementById(strcontent + "ddlfreguency").focus();
                    return false;
                }
            }

            //policy term from
            if (document.getElementById(strcontent + "TextPolicyTermFrom") != null) {
                if (document.getElementById(strcontent + "TextPolicyTermFrom").value == "") {
                    alert("Please Enter Policy Term From.");
                    document.getElementById(strcontent + "TextPolicyTermFrom").focus();
                    return false;
                }
            }


            //TextPolicyTermTo

            if (document.getElementById(strcontent + "TextPolicyTermTo") != null) {
                if (document.getElementById(strcontent + "TextPolicyTermTo").value == "") {
                    alert("Please Enter Policy Term To.  ");
                    document.getElementById(strcontent + "TextPolicyTermTo").focus();
                    return false;
                }
            }

            //Pay Term From 
            if (document.getElementById(strcontent + "TextPayTermFrom").Enabled == true) {
                if (document.getElementById(strcontent + "TextPayTermFrom") != null) {
                    if (document.getElementById(strcontent + "TextPayTermFrom").value == "") {
                        alert("Please Enter Pay Term From.  ");
                        document.getElementById(strcontent + "TextPayTermFrom").focus();
                        return false;
                    }
                }
            }

            //Pay Term To
            if (document.getElementById(strcontent + "TextPayTermTo").Enabled == true) {
                if (document.getElementById(strcontent + "TextPayTermTo") != null) {
                    if (document.getElementById(strcontent + "TextPayTermTo").value == "") {
                        alert("Please Enter Pay Term To.  ");
                        document.getElementById(strcontent + "TextPayTermTo").focus();
                        return false;
                    }
                }
            }

            //TextPremiumFrom

            if (document.getElementById(strcontent + "TextPremiumFrom") != null) {
                if (document.getElementById(strcontent + "TextPremiumFrom").value == "") {
                    alert("Please Enter Premium From .");
                    document.getElementById(strcontent + "TextPremiumFrom").focus();
                    return false;
                }
            }


            //TextPremiumTo

            if (document.getElementById(strcontent + "TextPremiumTo") != null) {
                if (document.getElementById(strcontent + "TextPremiumTo").value == "") {
                    alert("Please Enter Premium To .");
                    document.getElementById(strcontent + "TextPremiumTo").focus();
                    return false;
                }
            }

            //ddlPremiumType

            if (document.getElementById(strcontent + "ddlPremiumType") != null) {
                if (document.getElementById(strcontent + "ddlPremiumType").value == "") {
                    alert("Please Select Premium Type .");
                    document.getElementById(strcontent + "ddlPremiumType").focus();
                    return false;
                }
            }

            //ddlPayMode
            if (document.getElementById(strcontent + "ddlPayMode") != null) {
                if (document.getElementById(strcontent + "ddlPayMode").value == "") {
                    alert("Please Select Pay Mode .");
                    document.getElementById(strcontent + "ddlPayMode").focus();
                    return false;
                }
            }


            //TextWeightage

            //            if (document.getElementById(strcontent + "TextWeightage") != null) {
            //                if (document.getElementById(strcontent + "TextWeightage").value == "") {
            //                    alert("Please Enter Weightage.");
            //                    document.getElementById(strcontent + "TextWeightage").focus();
            //                    return false;
            //                }
            //            }

            var TxtWeg = document.getElementById('<%= TextWeightage.ClientID %>');
            if (!(TxtWeg.disabled)) {
                if (document.getElementById(strcontent + "TextWeightage") != null) {
                    if (document.getElementById(strcontent + "TextWeightage").value != "") {
                        var myregex = /^[0-9][0-9]{0,3}$|^[0-9][0-9]{0,3}[\.][0-9]$/;
                        if (!myregex.test($('#TxtWeg').val()) || $('#TextWeightage').val() == "0") {
                            if (document.getElementById(strcontent + "TextWeightage").value > 0) {
                                return true;
                            }
                            alert("Please Enter Correct value");
                            return false;
                        }
                        return false;

                    }
                    else {
                        alert("Please  Enter Weightage.");
                        document.getElementById(strcontent + "TextWeightage").focus();
                        return false;
                    }
                    //
                }
                else {
                    return true;
                }
            }

        }

        //            //rblSplit

        //            if (document.getElementById(strcontent + "rblSplit") != null) {
        //                if (document.getElementById(strcontent + "rblSplit").value == "") {
        //                    alert("Please Select Pay Mode .");
        //                    document.getElementById(strcontent + "rblSplit").focus();
        //                    return false;
        //                }
        //            }

        //for radiolist

        //            var radio = document.getElementsByName("rblSplit"); //Client ID of the RadioButtonList1                          
        //            for (var i = 0; i < radio.length; i++) {
        //                if (radio[i].checked) { // Checked property to check radio Button check or not
        //                    // alert("Radio button having value " + radio[i].value + " was checked."); // Show the checked value
        //                    return true;
        //                }
        //            }
        //            alert("Please Check the Consider");
        //            return false;
        // }

        //            function Comparevalidate() {
        //                var strContent = "ctl00_ContentPlaceHolder1_";
        ////            document.getElementById(strcontent + "TextPolicyTermFrom").value
        //            var x = document.getElementById(strcontent + "TextPolicyTermFrom").value;
        //            var y = document.getElementById(strcontent + "TextPolicyTermTo").value

        //            if (x > y) 
        //            {
        //                alert("select Correct Format");
        //                return false;
        //            }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
                    <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;font-size:19px">
                               <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                <asp:Label ID="lblhdr" Text="Product Level Weightage Definition" runat="server" />
                            </div>
                            <div class="col-sm-2">
                                 <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divcmphdr" runat="server" style="width: 96%;" class="panel-body">
                        <div class="row" style="margin-bottom: 5px;">
                            
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Product Category" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label12" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlPrdClsCode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlPrdClsCode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>


                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompCode" Text="Product Code" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblproductcode" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>




                        </div>
                        <div class="row" style="margin-bottom: 5px;"  runat="server"  visible="false">
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label10" Text="Buisness Type" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblconsider" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="rblSplit"  runat="server" AutoPostBack="true"
                                   CssClass="form-control">
                                     <asp:ListItem Text="--SELECT--" Value=""></asp:ListItem>
                                    <asp:ListItem Text="NEW BUSINESS " Value="N"></asp:ListItem>
                                    <asp:ListItem Text="RENEWAL BUSINESS" Value="RE"></asp:ListItem>
                                    <asp:ListItem Text="TOP UP BUSINESS" Value="RO"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompDesc1" Text="Product Name" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="TextProductName" runat="server" CssClass="form-control" TabIndex="2"
                                    placeholder="Product Name" MaxLength="40" Enabled="false" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;"  runat="server" id="divplan"  visible="false">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompTyp" Text="Plan Code" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="TextPlanCode" runat="server" CssClass="form-control" TabIndex="2"
                                    placeholder="Plan Code" MaxLength="40" Enabled="false" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                    FilterMode="ValidChars" TargetControlID="TextPlanCode">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCompStat" Text="Frequency" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblfrequency" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlfreguency" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                            TabIndex="4" OnSelectedIndexChanged="ddlfreguency_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;"  runat="server" id="divpolicy" visible="false">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label1" Text="Policy Term From" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblpolicyterm" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextPolicyTermFrom" runat="server" CssClass="form-control" TabIndex="2" Text="1"
                                            placeholder="Policy Term From" MaxLength="2" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TextPolicyTermFrom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label3" Text="Policy Term To" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblpolicytermto" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextPolicyTermTo" runat="server" CssClass="form-control" TabIndex="2" Text="1"
                                            placeholder="Policy Term To" MaxLength="2" onchange="javascript:Comparevalidate();" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TextPolicyTermTo">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                       
                        <div class="row" style="margin-bottom: 5px;display:none;"  visible="false" >
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label4" Text="Pay Term From" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblPayTermFrom" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextPayTermFrom" runat="server" CssClass="form-control" TabIndex="2"
                                            placeholder="Pay Term From" MaxLength="40" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TextPayTermFrom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label5" Text="Pay Term To" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblPayTermTo" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextPayTermTo" runat="server" CssClass="form-control" TabIndex="2"
                                            placeholder="Pay Term To" MaxLength="40" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TextPayTermTo">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                       
                        <div class="row" style="margin-bottom: 5px;"  runat="server" id="divpremium" visible="false">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label6" Text="Premium From" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblpremiumfrom" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextPremiumFrom" runat="server" CssClass="form-control" TabIndex="2"
                                            placeholder="Premium From" MaxLength="12" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TextPremiumFrom">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label7" Text="Premium To" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblpremiumto" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextPremiumTo" runat="server" CssClass="form-control" TabIndex="2"
                                            placeholder="Premium To" MaxLength="12" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TextPremiumTo">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;"  runat="server" id="divpaymode" visible="false">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label8" Text="Premium Type" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblpreiumtype" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlPremiumType" runat="server" AutoPostBack="true" CssClass="select2-container form-control">
                                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                    <asp:ListItem Text="COLLECTED PREMIUM" Value="CP">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label9" Text="Pay Mode" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblpaymode" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlPayMode" runat="server" AutoPostBack="true" CssClass="select2-container form-control"
                                    >
                                    <asp:ListItem Text="CASH" Value="CASH">
                                    </asp:ListItem>
                                    <asp:ListItem Text="CHEQUE" Value="CHEQUE">
                                    </asp:ListItem>
                                    <asp:ListItem Text="ECS" Value="ECS">
                                    </asp:ListItem>
                                    <asp:ListItem Text="NEFT" Value="NEFT">
                                    </asp:ListItem>
                                    <asp:ListItem Text="ALL" Value="ALL">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;"   runat="server" visible="true">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label11" Text="Weightage" runat="server" CssClass="control-label" />
                                <asp:Label ID="lblweightage" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TextWeightage" runat="server" CssClass="form-control" TabIndex="2"
                                          Text="100" style='text-align:right;'  placeholder="Weightage" MaxLength="10" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." FilterMode="ValidChars" TargetControlID="TextWeightage">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label13" Text="Consider" runat="server" CssClass="control-label" />
                                <asp:Label ID="Label14" Text="*" runat="server" ForeColor="red" />
                            </div>
                            <div class="col-sm-3">
                                <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="rblSplit_SelectedIndexChanged">
                                    <asp:ListItem Text="Include &nbsp;" Value="IN" selected="true" ></asp:ListItem>
                                    <asp:ListItem Text="Exclude &nbsp;" Value="EX"></asp:ListItem>
                                    <asp:ListItem Text="All &nbsp;" Value="AR"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtFrm" Text="Effective From" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3" style="white-space: nowrap;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                       <asp:TextBox ID="txtEffDtFrm" runat="server" Enabled="true" CssClass="form-control" onmousedown="PopulateCalender()"
                                            onmouseup="PopulateCalender()"   placeholder="DD/MM/YYYY"  AutoPostBack="true" OnTextChanged="txtEffDtFrm_TextChanged" />

                                          <asp:LinkButton  ID="Button1" runat="server" style="display:none;"  AutoPostBack="true"      Text="Button" ></asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblEffDtTo" Text="Effective To" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtEffDtTo" runat="server"   Enabled="true" CssClass="form-control"  onmousedown="PopulateCalenderTo()"
                                            onmouseup="PopulateCalenderTo()"   placeholder="DD/MM/YYYY"  AutoPostBack="true" 
                                           />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                    </div>
                    <div style="width: 100%; text-align: left; padding: 10px;"  runat="server" visible="true"> 
                        <asp:Label ID="lbl1" Text="Note- <b>Consider</b>* -<br/>Include- Only Include the given product with the specified std. defn. rule"
                            ForeColor="Red" runat="server" />
                        <br />
                        <asp:Label ID="lbl2" Text="Exclude- Exclude the given product" ForeColor="Red" runat="server" />
                        <br />
                        <asp:Label ID="lbl3" Text="All- Include all the product codes with the default std. defn. rule and also the mentioned product std. defn. rule"
                            runat="server" ForeColor="Red" />
                    </div>
                    <div class="row" style="margin-top: 12px;">
                        <div class="col-sm-12" align="center">
                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>--%>
                                    <asp:LinkButton ID="btnsave" runat="server" CssClass="btn btn-sample" OnClientClick="return validate();"
                                        OnClick="btnsave_Click">
                                                    <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" OnClientClick="doCancel();return false;">
                                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel
                                    </asp:LinkButton>
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
