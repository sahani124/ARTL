<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="MstSynonym.aspx.cs" Inherits="Application_Isys_Saim_Masters_MstSynonym" Debug="true" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../../Scripts/formatting.js"></script>
    <script type="text/javascript">
        function ShowReqDtl1(divName, btnName) {

            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-up'
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

          $(document).ready(function () {
               debugger;
               window.history.forward();
           });
               function PopulateCalender() {
               debugger;
               //minDate:new Date()
               $("#<%= txtED.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                }); $("#<%= txtED.ClientID  %>").datepicker('setDate', new Date());
        }

        function PopulateCalender1() {
            debugger;
            minDate: new Date()
            $("#<%= txtCD.ClientID  %>").datepicker({
                   dateFormat: 'dd/mm/yy',
                   changeMonth: true,
                   changeYear: true,
                // minDate: 2,
                   //defaultDate: "+1D",
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

            var EffDate = $('#<%= txtED.ClientID  %>').val();
            var CeDate = $('#<%= txtCD.ClientID  %>').val();
            var strcontent = "ctl00_ContentPlaceHolder1_";
            debugger;
            if (EffDate != "" && CeDate != "") {
                if (!checkDateIsGreaterThanToday(EffDate, CeDate)) {
                  // alert("Please select the correct cease date");
                    document.getElementById("ctl00_ContentPlaceHolder1_txtCD").value = "";
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
            if (document.getElementById("<%=txtlnkid.ClientID%>").value == "") {
                alert("Please enter Link Server ID.");
                return false;}

            if (document.getElementById("<%=txtdb.ClientID%>").value == "") {
                alert("Please enter Database Name.");
                return false;
            }

            if (document.getElementById("<%=txttblnm.ClientID%>").value == "") {
                alert("Please enter Table Name.");
                return false;
            }
            var strcontent = "ctl00_ContentPlaceHolder1_";
                if (document.getElementById(strcontent + "ddlDestnDb") != null) {
                if (document.getElementById(strcontent + "ddlDestnDb").value == "") {
                    alert("Please Select Destination Database.");
                    document.getElementById(strcontent + "ddlDestnDb").focus();
                    return false;
                }
            }
                if (document.getElementById("<%=txtsyndesc.ClientID%>").value == "") {
                    alert("Please Enter Synonym Description.");
                    return false;
                }
              //  if (document.getElementById("<%=txtED.ClientID%>").value == "") {
              //  alert("Please enter Effective Date.");
             //   return false;
          //  }
        }

        function gotoHome() {
            parent.location.href = parent.location.href;
        }
        function disableSpace() {
            if (event.keyCode == 32) {
                return false;
            }
        }
    </script>
    <style type="text/css">
        .new_text_new {
            color: #066de7;
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

        .disablepage {
            display: none;
        }

        .box {
            background-color: #efefef;
            padding-left: 5px;
        }

        .gridview th {
            padding: 3px;
            height: 40px;
            background-color: #F04E5E;
            color: White;
            white-space: nowrap;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <center>
    <asp:UpdatePanel ID="UPD1" runat="server">
        <ContentTemplate>
            
           <div id="divfinhdrcollapse" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%"  class="panel">
            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divfinhdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                     
                        <asp:Label ID="lblsynset" Text="Synonym Setup" runat="server" Style="font-size:19px;" />
                    </div>
                    <div class="col-sm-2">
                        <%--<span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                        <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
            
               <div id="divfinhdr" runat="server" style="width: 96%;" class="panel-body">
              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <div class="row" style="margin-bottom: 5px;">
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lbllinkserverid" Text="Link Server ID" runat="server" CssClass="control-label" />
                                <span id="Span2" runat="server" style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtlnkid" runat="server" CssClass="form-control" TabIndex="2" onkeypress="return disableSpace()" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderlnkid" runat="server" InvalidChars=";,#$@%^!*()&''%^~`_:-+{}[]?/><|*a"
                                         FilterMode="InvalidChars" TargetControlID="txtlnkid" FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom"></ajaxToolkit:FilteredTextBoxExtender>
                            </div>

                              <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lbldb" Text="Database" runat="server" CssClass="control-label" />
                                  <span id="Span3" runat="server" style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtdb" runat="server" CssClass="form-control" TabIndex="2" onkeypress="return disableSpace()" />
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" InvalidChars=";,#$@%^!*()&''%^~`.:-+{}[]?/><|*" 
                                         FilterMode="InvalidChars" TargetControlID="txtdb" FilterType="LowercaseLetters,UppercaseLetters,Custom"></ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                             </div>
                        <div class="row" style="margin-bottom: 5px;">
                                <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="tbltblnm" Text="Table Name" runat="server" CssClass="control-label" />
                                    <span id="Span4" runat="server" style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txttblnm" runat="server" CssClass="form-control" TabIndex="2" AutoPostBack="true" OnTextChanged="txttblnm_TextChanged" onkeypress="return disableSpace()" />
                                
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" InvalidChars=";,#$@%^!*()&''%^~`:-+.{}[]?/><|*"
                                         FilterMode="InvalidChars" TargetControlID="txttblnm" FilterType="LowercaseLetters,UppercaseLetters,Custom"></ajaxToolkit:FilteredTextBoxExtender>
                            </div>

                               <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblsyn" Text="Synonym Name" runat="server" CssClass="control-label" />
                                   <span id="Span5" runat="server" style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtsynm" runat="server" CssClass="form-control" TabIndex="2" Enabled="false" />
                            </div>
                             </div>

                           <div class="row" style="margin-bottom: 5px;">
                               <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lbldestndb" Text="Destination Database" runat="server" CssClass="control-label" />
                                   <span id="Span6" runat="server" style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDestnDb" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="4"  >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                               <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblst" Text="Status" runat="server" CssClass="control-label" />
                                   <span id="Span7" runat="server" style="color: red">*</span>
                            </div>
                                <div class="col-sm-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlstts" runat="server" AutoPostBack="true" CssClass="form-control"
                                            TabIndex="4" >
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                               </div>
                        <div class="row" style="margin-bottom: 5px;">
                             <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblED" Text="Effective Date" runat="server" CssClass="control-label" />
                                 <span id="Span8" runat="server" style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtED" runat="server" CssClass="form-control"  placeholder="DD/MM/YYYY" Enabled="false"  /> <%--onmousedown="PopulateCalender(); return false;" onmouseup="PopulateCalender()" --%>
                                </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblCD" Text="Cease Date" runat="server" CssClass="control-label" />
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtCD" runat="server" CssClass="form-control"  placeholder="DD/MM/YYYY"  onmousedown="PopulateCalender1()" onmouseup="PopulateCalender1()" Enabled="false"/>
                                </div>
                            </div>
                             <div class="row" style="margin-bottom: 5px;">
                             <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="Label2" Text="Synonym Description" runat="server" CssClass="control-label" />
                                   <span id="spansyndesc" runat="server" style="color: red">*</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtsyndesc" runat="server" TextMode="MultiLine" CssClass="form-control" TabIndex="2" />
                                
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" InvalidChars=";,#$@%^!*()&''%^~`_:-+{}[].?/><|*"
                                         FilterMode="InvalidChars" TargetControlID="txtsyndesc" FilterType="LowercaseLetters,UppercaseLetters,Custom"></ajaxToolkit:FilteredTextBoxExtend--%>
                            </div>
                            </div>
                        <div id="divsyncrete" runat="server" class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="btnSave_Click" OnClientClick="return Validate();">
                                   <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color:White"></span> Create
                                 </asp:LinkButton>

                                   <asp:LinkButton ID="btnupd" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="btnupd_Click">
                                     <span class="glyphicon glyphicon-floppy-disk"  style="color:White"></span> Update
                                   </asp:LinkButton>

                                 <asp:LinkButton ID="btnclr" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClick="btnclr_Click">
                                     <span class="glyphicon glyphicon-erase BtnGlyphicon" style="color: White;"></span> Clear
                                   </asp:LinkButton>
                                <asp:LinkButton ID="btncncl" runat="server" CssClass="btn btn-sample" TabIndex="17" OnClientClick="JavaScript:window.history.back(1); return false;">
                                     <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color: White;"></span> Cancel
                                   </asp:LinkButton>
                                </div>
                           
                        </div>
                        
                        <%--</div>--%>
                        <br />
                                     </ContentTemplate>
                </asp:UpdatePanel>
                   
                    </div>
              
               </div>
                </ContentTemplate>
          </asp:UpdatePanel>
                        <%-- GridView Start--%>
                             <asp:updatepanel id="uppnl" runat="server">
            <ContentTemplate>
                   <div id="divcmpsrchhdrcollapse" runat="server" style="margin-left: 4%; margin-right: 4%; margin-top: 0.5%"  class="panel ">
                        <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divsyngrd','myImg1');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left">
                     
                        <asp:Label ID="Label1" Text="Details" runat="server" Style="font-size:19px;" />
                    </div>
                    <div class="col-sm-2">
                        <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right;color:#034ea2;
                            padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
                            </div>
                   <%--    panel body start--%>
                       <%--<div id="divsyngrd" runat="server" style="width: 96%; padding: 10px;" >--%>
                         <div id="divsyngrd" runat="server" style="width: 100%; border: none; margin: 0px 0 !important;" class="table-scrollable">
                      <div id="divGridMap" runat="server" style="width: 100%; overflow-x:scroll" >
                    
                <asp:UpdatePanel ID="UpdatePanelgrd" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdsyn" runat="server" AutoGenerateColumns="false" PageSize="10" AllowSorting="True" AllowPaging="true" CssClass="footable"  Width="100%" 
                             OnSelectedIndexChanged="grdsyn_SelectedIndexChanged">
                            <RowStyle CssClass="GridViewRowNEW"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                               <%--<EmptyDataTemplate>
                                  <asp:Label ID="Label2" Text="No Synonym have been Created" ForeColor="Red" CssClass="control-label" runat="server" />
                                </EmptyDataTemplate>--%>
                            <Columns>
                                <asp:TemplateField HeaderText="Link Server ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="LNK_SVR_ID" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLnksrvr"  runat="server" Text='<%# Bind("LNK_SVR_ID")%>'></asp:Label>
                                        <asp:Label ID="lblsynSeqNo" Text='<%# Bind("SEQNO") %>' Visible="false" runat="server" />
                                    </ItemTemplate>                                                                    
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Database" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="DB_NAME" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbldbnm"  runat="server" Text='<%# Bind("DB_NAME")%>'></asp:Label>
                                    </ItemTemplate>                                                                    
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Table Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="TBL_NAME" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbltblnm"  runat="server" Text='<%# Bind("TBL_NAME")%>'></asp:Label>
                                    </ItemTemplate>                                                                    
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="Synonym Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="SYNYM_NAME" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblSynym"  runat="server" Text='<%# Bind("SYNYM_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                    <%-- <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />--%>                                   
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Synonym Description" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="SYNYM_DESC" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblSynymDesc"  runat="server" Text='<%# Bind("SYNYM_DESC")%>'></asp:Label>
                                    </ItemTemplate>    
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Destination Database" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="DSTN_DB" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbldstndb"  runat="server" Text='<%# Bind("DSTN_DB")%>'></asp:Label>
                                    </ItemTemplate>                                                                    
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="STATUS" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblsts"  runat="server" Text='<%# Bind("STATUS")%>'></asp:Label>
                                    </ItemTemplate>                                                                    
                                </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Effective Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="EFF_DTIM" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblefd"  runat="server" Text='<%# Bind("EFF_DTIM")%>'></asp:Label>
                                    </ItemTemplate>                                                                    
                                </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="Cease Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                     SortExpression="CSE_DTIM" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblcsd"  runat="server" Text='<%# Bind("CSE_DTIM")%>'></asp:Label>
                                    </ItemTemplate>                                                                    
                                </asp:TemplateField>                               
                               <asp:TemplateField HeaderText="Action" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" Text="Edit" runat="server" ShowEditButton="true" data-myData='<%# Eval("SYNYM_NAME") %>' OnClick="lnkedit_Click" />      
                                     </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Action" >
                                    <ItemTemplate> 
                                    <asp:LinkButton ID="lnksyndel" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want delete'); return true;" OnClick="lnksyndel_Click" Visible="TRUE">
                                  </asp:LinkButton>
                                        </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                                 </div>
                       
                 
        <%--        </ContentTemplate>
                                 </asp:UpdatePanel>--%>

<%--                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>--%>
                        <div id="divPage" visible="true" runat="server" class="pagination">
                            <center>
                                <table>
                                    <tr>
                                        <td style="white-space: nowrap;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click"/>
                                                    <asp:TextBox runat="server" ID="txtPage" Style="width: 40px; border-style: solid;
                                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                        text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                    <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                                   </div>
                       </div>                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                 
                        <br /> 
           
                       
          <%-- </div>--%>

    
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

        </center>
</asp:Content>

