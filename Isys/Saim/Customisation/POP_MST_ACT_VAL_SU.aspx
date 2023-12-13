<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="POP_MST_ACT_VAL_SU.aspx.cs" Inherits="Application_Isys_Saim_Customisation_POP_MST_ACT_VAL_SU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <%--    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />--%>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="..//../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
       
       function doCancel() {
           debugger;
           window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
           window.parent.$find('<%=Request.QueryString["ACT_TYP"].ToString()%>');
            parent.location.href = parent.location.href
            //window.parent.$find("btnSearch").click();
          ///  window.parent.reload();
       }


        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;
            else {
                //alert('Please Enter Only Character.');
                return false;
            }
        }


        function PopulateCeaseDate() {
            debugger;
            minDate: new Date()
            $("#<%= txtceasedt.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                onSelect: function (d, i) {
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
            var EffDate = $('#<%= txtEffDtFrm.ClientID  %>').val();
                var CeDate = $('#<%= txtceasedt.ClientID  %>').val();
                var strcontent = "ctl00_ContentPlaceHolder1_";
                debugger;
                if (EffDate != "" && CeDate != "") {
                    if (!checkDateIsGreaterThanToday(EffDate, CeDate)) {
                        // alert("Please select the correct cease date");
                        document.getElementById("ctl00_ContentPlaceHolder1_txtceasedt").value = "";
                        return false;
                    }
                    else {
                        //alert("step2");
                    }
                }
            }
            function checkDateIsGreaterThanToday(fromDay, toDay) {
                debugger;
                var fromArr = fromDay.split('/');
                var toArr = toDay.split('/');

                if (fromArr[2] == toArr[2]) {
                    if (fromArr[1] < toArr[1]) {
                        if (fromArr[0] < toArr[0]) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    else if (fromArr[1] == toArr[1]) {
                        if (fromArr[0] < toArr[0]) {
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

            function Validate() {
                debugger;
                var strcontent = "ctl00_ContentPlaceHolder1_";
                if (document.getElementById("<%=txtValCode.ClientID%>").value == "") {
                    alert("Please Enter Val Code.");
                    return false;
                }
                if (document.getElementById("<%=txtValDesc.ClientID%>").value == "") {
                    alert("Please Enter Val Description.");
                    return false;
                }
                if (document.getElementById(strcontent + "ddlFR") != null) {
                    if (document.getElementById(strcontent + "ddlFR").value == "") {
                        alert("Please Select Factor Flag");
                        document.getElementById(strcontent + "ddlFR").focus();
                        return false;
                    }
                }
                if (document.getElementById(strcontent + "ddlBaseTbl") != null) {
                    if (document.getElementById(strcontent + "ddlBaseTbl").value == "") {
                        alert("Please Select Base/Source Table.");
                        document.getElementById(strcontent + "ddlBaseTbl").focus();
                        return false;
                    }
                }
                if (document.getElementById(strcontent + "ddlCol") != null) {
                    if (document.getElementById(strcontent + "ddlCol").value == "") {
                        alert("Please Select Base/Source Table Column.");
                        document.getElementById(strcontent + "ddlCol").focus();
                        return false;
                    }
                }
                //if (document.getElementById(strcontent + "ddlmstr") != null) {
                //    if (document.getElementById(strcontent + "ddlmstr").value == "") {
                //        alert("Please Select Master Table.");
                //        document.getElementById(strcontent + "ddlmstr").focus();
                //        return false;
                //    }
                //}
                //if (document.getElementById(strcontent + "ddlmstrcol") != null) {
                //    if (document.getElementById(strcontent + "ddlmstrcol").value == "") {
                //        alert("Please Select Master Table Column.");
                //        document.getElementById(strcontent + "ddlmstrcol").focus();
                //        return false;
                //    }
                //}
                //if (document.getElementById(strcontent + "ddlmstcoldesc") != null) {
                //    if (document.getElementById(strcontent + "ddlmstcoldesc").value == "") {
                //        alert("Please Select Master Table Column Description.");
                //        document.getElementById(strcontent + "ddlmstcoldesc").focus();
                //        return false;
                //    }
                //}
               
            }

        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                }
                else {
                    objnewdiv.style.display = "block";
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

        function CloseDiv(divId) {

            var strContent = "ctl00_ContentPlaceHolder1_";
            if (document.getElementById(strContent + divId) != null) {
                document.getElementById(strContent + divId).style.display = 'none';
            }
        }

    </script>
    
        <div id="divcmphdrcollapse" runat="server" style="width: 97%;" class="panel">
        <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <%--                        <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>&nbsp;commennted by ajay sawant 25/4/2018--%>
                    <asp:Label ID="lblhdr" Text="Add Val Factor" Font-Size="19px" runat="server" />
                </div>
                <div class="col-sm-2">
                    <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 24/4/2018--%>
                </div>
            </div>
        </div>
        <div id="divcmphdr" runat="server" style="width: 96%; padding:10px;" class="panel-body" >
            <div class="row" style="margin-bottom: 5px; padding-left:7px; padding-right:7px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblMappedCd" Text="Mapped code" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                        <asp:Label ID="lblmappedcddesc"  runat="server" CssClass="form-control-static new_text_new" Font-Size="Medium" Visible="true" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lbkacttyp" Text="Action Type" runat="server" CssClass="control-label" />
                  <%--  <span style="color: red;">*</span>--%>
                    </div>
                <div class="col-sm-3">
                      <asp:Label ID="lblactbind"  runat="server" CssClass="form-control-static new_text_new" Font-Size="Medium" Visible="true"  />
                    </div>
            </div>


            <div class="row" style="margin-bottom: 5px; padding-left:7px; padding-right:7px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblValCode" Text="Val Code" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtValCode" runat="server" CssClass="form-control" TabIndex="1"  onkeypress="return AllowAlphabet(event)" Style="text-transform: uppercase;"/>
                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars=";,#$@%^!*()&''%^~`_:-+{}[]?><|*"
                                         FilterMode="InvalidChars" TargetControlID="txtValCode" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblValDesc" Text="Val Description" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="updateActionver" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtValDesc" runat="server" CssClass="form-control" onkeypress="return AllowAlphabet(event)" />
                              <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" InvalidChars=";,#$@%^!*()&''%^~`_:-+{}[]?><|*"
                                         FilterMode="InvalidChars" TargetControlID="txtValDesc" FilterType="Custom"></ajaxToolkit:FilteredTextBoxExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>


            <div class="row" style="margin-bottom: 5px; padding-left:7px; padding-right:7px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblFR" Text="Factor Flag" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="updfr" runat="server">
                        <ContentTemplate>
                    <asp:DropDownList ID="ddlFR" CssClass="select2-container form-control"  runat="server" OnSelectedIndexChanged="ddlFR_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </ContentTemplate>
                        </asp:UpdatePanel>
                            </div>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblAuthfls" Text="Status" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlAuthFlg" CssClass="select2-container form-control" runat="server" >
                                 <%--OnSelectedIndexChanged=   "ddlAuthFlg_SelectedIndexChanged" --%>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


            </div>


            <div class="row" style="margin-bottom: 5px; padding-left:7px; padding-right:7px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblBaseTbl" Text="Base / Source Table Name" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlBaseTbl" AutoPostBack="true" CssClass="select2-container form-control"  runat="server" OnSelectedIndexChanged="ddlBaseTbl_SelectedIndexChanged" ></asp:DropDownList> <%--OnSelectedIndexChanged="ddlBaseTbl_SelectedIndexChanged" --%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblCol" Text="Base / Source Table Column" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCol" CssClass="select2-container form-control"  runat="server"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%--Added by Megha 22.10.2020 --%>
             <div class="row" style="margin-bottom: 5px; padding-left:7px; padding-right:7px;">
                       <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="Label3" Text="Master Table Name" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlmstr" AutoPostBack="true" CssClass="select2-container form-control" runat="server" OnSelectedIndexChanged="ddlmstr_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                                        <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="Label4" Text="Master Column Code" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlmstrcol" AutoPostBack="true" CssClass="select2-container form-control" runat="server" ></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                 </div>

                         <div class="row" style="margin-bottom: 5px; padding-left:7px; padding-right:7px;">
                       <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="Label5" Text="Master Column Description" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlmstcoldesc" AutoPostBack="true" CssClass="select2-container form-control" runat="server" OnSelectedIndexChanged="ddlmstcoldesc_SelectedIndexChanged" ></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                             <div class="col-sm-3" style="text-align: left">
                         <asp:UpdatePanel ID="Updlookup" runat="server">
                        <ContentTemplate>
                    <asp:Label ID="lbllookpcd" Text="LookUpCode" runat="server" CssClass="control-label"/>
                    <%--<span id="spnlook" style="color: red; display:none" runat="server">*</span>--%>
                        
                      <asp:Label ID="splblook" Text="*" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                     </ContentTemplate>
                         </asp:UpdatePanel>
                         </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddllookupcd" AutoPostBack="true" CssClass="select2-container form-control" runat="server" Enabled="false"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                             </div>

            <div class="row" style="margin-bottom: 5px; padding-left:7px; padding-right:7px;">
                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblEffDate" Text="Effective Date" runat="server" CssClass="control-label" />
                    <span style="color: red;">*</span>
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtEffDtFrm" runat="server" Enabled="true" CssClass="form-control" placeholder="DD/MM/YYYY" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


                <div class="col-sm-3" style="text-align: left">
                    <asp:Label ID="lblceasedt" Text="Cease Date" runat="server" CssClass="control-label" Visible="false" />
                </div>
                <div class="col-sm-3">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtceasedt" runat="server" CssClass="form-control" onmousedown="PopulateCeaseDate()" onmouseup="PopulateCeaseDate()" placeholder="DD/MM/YYYY" Enabled="false" Visible="false" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>





            <div id="tbladdcmpst" runat="server" class="row" style="margin-top: 12px; padding-left:7px; padding-right:7px;">
                <div class="col-sm-12" align="center">
                      <asp:UpdatePanel ID="upvlbtn" runat="server">
                 <ContentTemplate>
                    <asp:LinkButton ID="btnSave" runat="server"  CssClass="btn btn-sample" TabIndex="17" OnClick="btnSave_Click" OnClientClick="return Validate();">   <%-- OnClick="btnSave_Click"--%>
                      <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                    </asp:LinkButton>
                     <asp:LinkButton ID="btndataprepclr" runat="server" CssClass="btn btn-sample" OnClick="btndataprepclr_Click" >
                         <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                      </asp:LinkButton>
                    <asp:LinkButton ID="btnCnclCmp" runat="server" CssClass="btn btn-sample" TabIndex="18" OnClick="btnCnclCmp_Click"  OnClientClick="doCancel()">     <%-- OnClientClick="doCancel()"  --%>
                        <span class="glyphicon glyphicon-remove"  style="color:White"></span> Cancel
                    </asp:LinkButton>
                     </ContentTemplate>
                          </asp:UpdatePanel>
                </div>
            </div>


        </div>
    </div>
</asp:Content>

