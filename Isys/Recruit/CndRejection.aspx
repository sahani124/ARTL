<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CndRejection.aspx.cs" Inherits="Application_ISys_Recruit_CndRejection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%--   <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
        <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>

    <link href="../../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
      <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />--%>
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
  
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
      <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
<%--    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>--%>
   <%--  <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>--%>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
        <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>

          <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />


    <script type="text/javascript">
        function popup() {
            $("#myModal").modal();
        }
        $(function () {
            $("#<%= txtDTRegFrom.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });
            $("#<%= txtDTRegTo.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy', changeMonth: true,
                changeYear: true
            });
        });

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


    </script>
    <style>
        .panel_over {
            margin-left: 0% !important;
            margin-right: 0% !important;
        }
        .clsCenter{
       text-align:center !important;
        }
        .gridview th  {
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
    </style>
    <script language="javascript" type="text/javascript">

        $(function () {
            // debugger;
            $('#<%=dgDetails.ClientID %>').footable({
                breakpoints: {

                    phone: 300,
                    tablet: 1000
                }
            });
        });
        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    // objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        var path = "<%=Request.ApplicationPath.ToString()%>";
        function DateValidation(args1, argsID) {
            var Splitargs1 = args1.split("/");
            var BeginMonth = eval(Splitargs1[1]);
            var BeginYear = eval(Splitargs1[2]);
            var RegDate = new Date(args1); //BeginYear,BeginMonth-1,1);
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

        function validation() {
            if (SpaceTrim(document.getElementById(strContent + "txtDTRegFrom").value) != "") {
                if (DateValidation(document.getElementById("<%= txtDTRegFrom.ClientID %>").value, "ctl00_ContentPlaceHolder1_txtDTRegFrom") == 1)
                    return false;
            }
        }
        function LdWait(delay) {
            //debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'block';
            setTimeout("RemoveLoading12()", delay);
        }

        function RemoveLoading12() {
            //debugger;
            //hide loading status...
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'none';

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

        function StartProgressBar() {

            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();

            return true;
        }

        function ValidationPAN() {

            var varPAN = document.getElementById("ctl00_ContentPlaceHolder1_txtPan").value;

            if (varPAN.length == 0) {
                alert('Please Enter PAN No.');
                return false;
            }
            if (varPAN.length < 10) {
                alert('PAN No. must have minimum 10 characters.');
                return false;
            }

            if (varPAN.length != 10) {
                alert('PAN No. should be 10 characters.');
                return false;
            }

            if (SpaceTrim(document.getElementById('<%= txtPan.ClientID %>').value) != "") {
                if (CheckPANFormat(SpaceTrim(document.getElementById('<%= txtPan.ClientID %>').value)) == 0) {
                    alert('Invalid Pan Format');
                    return false;
                }
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
                                if (pan2.substring(j, j + 1) != 'P') {
                                    return 0;
                                }
                            }
                        }
                        if (j == 5 || j == 6 || j == 7 || j == 8) {
                            if (!IsNumeric(Char)) {
                                return 0;
                            }
                        }
                    }
                }
            }
            else {
                return 0;
            }
            return 1;
        }


         function isAlphabet(strText) {
            var inputStr = strText
            for (var intCounter = 0; intCounter < inputStr.length; intCounter++) {
                var oneChar = inputStr.substring(intCounter, intCounter + 1)

                if (oneChar.toUpperCase() < "A" || oneChar.toUpperCase() > "Z") {
                    return false

                }
            }
            return true
         }

         function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;

            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }

            return IsNumber;
        }





    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />


    <%--start--%>
        <asp:UpdatePanel ID="upCndApprove" runat="server">
            <ContentTemplate>
                    <div class="card PanelInsideTab" id="divPannel1" runat="server"  >  <%--panel panel-success --%>
                 <%-- <div class="container" style="width: 100%; padding-left: 0px;">--%>
            <div id="Div1" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divContactInformation','btnWfParam');return false;">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Visible="False" Width="310px"></asp:Label>
                    </div>
                </div>
                <div class="row spacebetnrow">
                    <div class="col-sm-10" style="text-align: left">
                        <asp:Label ID="lbltitle" runat="server" Text="Contact Information" CssClass="control-label HeaderColor" Style="font-size: 19px;"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="btnWfParam" class="glyphicon glyphicon-chevron-up"  style="float: right; padding: 1px 10px ! important;
                          font-size: 18px; color:#00cccc;margin-right: 15px;" ></span>   <%--style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"--%>
                    </div>

                </div>
            </div>
  
                      <div id="divContactInformation" style="display: block;" runat="server" class="panel-body panelContent">
                <div class="row rowspacing">
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblCandID" runat="server" CssClass="control-label labelSize"></asp:Label>
                        <asp:TextBox ID="txtCandCode" runat="server" Style="margin-bottom: 5px;" CssClass="form-control" MaxLength="10" placeholder="Candidate ID"
                            TabIndex="1"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                            InvalidChars="&quot;'/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                            FilterMode="InvalidChars" TargetControlID="txtCandCode" FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblApplicationNo" runat="server" CssClass="control-label labelSize "></asp:Label>
                        <asp:TextBox ID="txtAppNo" runat="server" Style="margin-bottom: 5px;" CssClass="form-control" MaxLength="15" placeholder="Application No"
                            TabIndex="2"></asp:TextBox>
                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                           InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                           FilterMode="InvalidChars" TargetControlID="txtAppNo" FilterType="Custom">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblGivenName" runat="server" CssClass="control-label labelSize"></asp:Label>
                        <asp:TextBox ID="txtGivenName" runat="server" Style="margin-bottom: 5px;" CssClass="form-control" MaxLength="60" placeholder="Given Name"
                            TabIndex="3"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_GivenName" runat="server"
                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtGivenName">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                </div>

                <div class="row  rowspacing">
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblSurname" runat="server" CssClass="control-label labelSize"></asp:Label>
                        <asp:TextBox ID="txtSurname" runat="server" Style="margin-bottom: 5px;" CssClass="form-control" MaxLength="60" placeholder="Surname"
                            TabIndex="4"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender_Surname" runat="server"
                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" " TargetControlID="txtSurname">
                        </ajaxToolkit:FilteredTextBoxExtender>

                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblDTRegFrom" CssClass="control-label labelSize" runat="server"></asp:Label>
                       <%-- <asp:TextBox CssClass="form-control" runat="server" Style="margin-bottom: 5px;" ID="txtDTRegFrom" MaxLength="15" TabIndex="6" />--%>
                        <asp:TextBox  ID="txtDTRegFrom" runat="server" CssClass="form-control" placeholder="(dd/mm/yyyy)" MaxLength="15" style="margin-bottom:5px;" TabIndex="6"/>
                                                 
                                                    
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblDTRegTO" CssClass="control-label labelSize" runat="server"></asp:Label>
                        <asp:TextBox ID="txtDTRegTo" runat="server" CssClass="form-control" placeholder="(dd/mm/yyyy)" MaxLength="15" Style="margin-bottom: 5px;" TabIndex="8" />
                    </div>
                </div>

                <div class="row  rowspacing">
                    <div id="tdPan" class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblPan" CssClass="control-label labelSize" runat="server"></asp:Label>
                        <asp:TextBox ID="txtPan" runat="server" Style="margin-bottom: 5px;" CssClass="form-control" placeholder="PAN No"  TabIndex="11"
                             onblur="ValidationPAN();" MaxLength="10" onChange="javascript:this.value=this.value.toUpperCase();"></asp:TextBox>
                    </div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblShwRecords" CssClass="control-label labelSize" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control form-select"
                            TabIndex="9"  OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row" style="margin-top: 37px;">
                    <div class="col-sm-12" align="center">
                        <%-- <td  colspan="4" align="center" style="height: 20px">--%>
                        <%--                               <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-sample"
                                    runat="server">
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                                </asp:LinkButton>--%>
                        <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-success"
                            runat="server">
                                 <span class="glyphicon glyphicon-search" style='color:White;'> </span> SEARCH
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-clear"
                             runat="server" style="text-align:center !important; margin-left: 2px;" TabIndex="43">  <%--TabIndex="5"--%>
                                 <%--<span class="glyphicon glyphicon-erase BtnGlyphicon"> </span> --%>
                      CLEAR  </asp:LinkButton>
                    </div>
                    <div id="div3" runat="server" style="display: none;">
                        <caption>
                            &nbsp;&nbsp;
                                    <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
                            Loading...
                        </caption>
                    </div>
                    <%--  </td>--%>
                    <div class="row" style="margin-top: 12px;">
                        <%-- </tr>--%>
                    </div>
                </div>

            </div>
        <%--</div>--%>
             </div>
     
               <%-- <div style="width: 100%; padding-left: 0px;"> --%>   <%--class="container"--%>
                    <%--</div>--%>
                             <%--</div>--%>
                <div  id="trnote1" class ="card PanelInsideTab" runat="server" visible="false" >  
                    <div class="row">
                        <div class="col-sm-12" style="margin-bottom: 5px;">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false" Width="310px"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-12" style="margin-bottom: 5px;">
                    <asp:Label ID="Label2" runat="server" Text="Note: All dates are in (dd/mm/yyyy)" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                    <div id="trnote"  runat="server" visible="false" style="margin-left: 4%; margin-right: 4%; margin-top: 0.5%">
                    </div>
                    <div id="Div2" runat="server" class="panelheadingAliginment" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_trDgDetails','Span1');return false;">  <%--class="panel-heading panel_over"--%>
                        <div class="row" id="trDetails" runat="server">
                            <div class="col-sm-10" style="text-align: left">
                                <caption>
                                    <span style="display: inline-block; font-size: 19px;" class="control-label labelSize HeaderColor">Search Result</span>   <%--height: 16px;--%>
                                    <asp:Label ID="lblPageInfo" runat="server" CssClass="control-label labelSize HeaderColor" Visible="false"></asp:Label>
                                </caption>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span1" class="glyphicon glyphicon-chevron-up" style="float: right; padding: 1px 10px ! important;
                                font-size: 18px; color:#00cccc;margin-right: 15px;"></span>    <%--style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"--%>
                            </div>
                        </div>
                    </div>
                   
                    <div id="trDgDetails"  runat="server" style="overflow: auto; margin-top: 10px;padding: 10px">
                        <asp:UpdatePanel ID="UpdatePanel002" runat="server">
                                <ContentTemplate>
                                   <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="False" CssClass="footable" style=""
                                    PageSize="10" AllowSorting="True" AllowPaging="True" Width="100%" OnRowDataBound="dgDetails_RowDataBound" 
                                    OnSorting="dgDetails_Sorting">
                                     <FooterStyle CssClass="GridViewFooter" />
                                       <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <HeaderStyle CssClass="gridview th" />
                            <PagerStyle CssClass="disablepage" />
                                     <Columns>
                                            <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate ID" HeaderStyle-Wrap="false"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbCndNo" runat="server" Text='<%# Eval("CandidateNo") %>' CommandArgument='<%# Eval("CandidateNo") %>'
                                                        CommandName="click"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                <ItemStyle Width="10%"  HorizontalAlign="Center" CssClass="clsCenter"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="ApplicationNo" HeaderText="Application No" HeaderStyle-Wrap="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblappno" runat="server" Text='<%# Eval("ApplicationNo") %>' ToolTip='<%# Eval("ApplicationNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="clsCenter" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="Givenname" HeaderText="Name" HeaderStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNamePronoun" runat="server" Text='<%# Eval("NamePronoun") %>' ToolTip='<%# Eval("NamePronoun") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="Surname" HeaderText="Surname" HeaderStyle-Wrap="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbSurname" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="RecruitAgtName" HeaderText="Recruiter Name" HeaderStyle-Wrap="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCndStatus" runat="server" Text='<%# Eval("RecruitAgtName") %>'
                                                        ToolTip='<%# Eval("RecruitAgtName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" CssClass="clsCenter" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField SortExpression="CreateDtim" HeaderText="Registration Date" HeaderStyle-Wrap="false"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreateDtim" runat="server" Text='<%# Eval("CreateDtim","{0:dd/MM/yyyy}") %>'
                                                        ToolTip='<%# Eval("CreateDtim") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsCenter" HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reject" Visible="True" HeaderStyle-Wrap="false"  >
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rbrreject" runat="server" AutoPostBack="True" OnCheckedChanged="rbrreject_CheckedChanged" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="clsCenter" Font-Bold="False"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control"   style="height: 21px;" MaxLength="50"/>
                                                    <input type="hidden" runat="server" id="hdntxtVarify" value="NotDone" />
                                                    <input type="hidden" runat="server" id="hdnPmtMode" value='<%# Eval("PmtMode") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="23%" CssClass="clsCenter" Font-Bold="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank" ItemStyle-Width="6%"
                                                Visible="false">
                                               
                                                <ItemTemplate>
                                                    <input type="button" id="btnVarify" value="Verify"  width="50px"
                                                        runat="server" />
                                                </ItemTemplate>

                                                <ItemStyle Width="6%" />
                                            </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                                      <br />
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
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        <br />
                        <br />
                        <div id="trButton" style="padding-bottom: 6px" runat="server">
                            <div align="center" class="col-sm-12">
                                <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-success"
                                    OnClick="btnSubmit_Click" Visible="True">
                                 <span class="glyphicon glyphicon-saved" style='color:White;'> </span> SUBMIT
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-clear" Text="CANCEL" class="glyphicon glyphicon-remove"
                                    OnClick="btnCancel_Click" TabIndex="5" Visible="True">
                                 <%--CANCEL<span class="glyphicon glyphicon-remove" style='color:White;'> </span> --%>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div> 
                </div>
                <br />
                   <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder"   Width="380px" Height="40%" style="background-color: white">
                    <div class="panel rcorners2" id="divAlert" runat="server" style="width:30%; display: block; border: 2px;border: 0px !important;" cellpadding="0" cellspacing="0">
                    <div id="Div8" runat="server"   style="width:100% !important" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','ctl00_ContentPlaceHolder1_Span1');return false;">
                            <div id="Div9" runat="server">
                             <center style="font-size:16px;padding:10px;color:#00cccc;margin-right: 50px;" CssClass="control-label HeaderColor" >INFORMATION</center>
                            </div>
                        </div>
                <table>
                    <tr>
                <td style="width: 391px;">
                   <%-- <br />--%>
                    <center>
                        <asp:Label ID="lbl3" runat="server" style="margin-right: 50px;"></asp:Label><br />
                       <%-- <br />--%>
                    </center>
                     <center>
                        <asp:Label ID="lbl2" runat="server"></asp:Label><br />
                     <%--   <br />--%>
                    </center>
                    <center>
                        <asp:Label ID="lbl4" runat="server" style="margin-right: 50px;"></asp:Label><br />
                       <%-- <br />--%>
                    </center>
                    <br />
                </td>
            </tr>
               </table>
                   <center>
        <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="60px" CssClass="btn btn-success" style="margin-right:55px;"/>
            </center>
            <br />
            </div>
                   </asp:Panel>
              </center>
                    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl3"
                    BehaviorID="mdlpopup" PopupControlID="pnl" BackgroundCssClass="modalPopupBg"
                    OkControlID="btnok" Y="100">
                   
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
   <%-- </div>--%>
   <%-- </div>--%>

    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
        <center>
                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
    </asp:Panel>
</asp:Content>

