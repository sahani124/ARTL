<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/iFrame.master" CodeFile="FPFrmARFUpload.aspx.cs" Inherits="Application_ISys_ChannelMgmt_FPFrmARFUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style id="Style1" runat="server" type="text/css">
        .modalBackground
        {
            background-color: #CCCCFF;
            filter: alpha(opacity=40);
            opacity: 0.5;
        }
    </style>
    <script language="javascript" type="text/javascript">

        //Cancle Button Functionality
        function Confirm() {
            //debugger;
            var ans = confirm('Are you sure you want to cancel upload process ?');
            if (ans) {
                document.getElementById("ctl00_ContentPlaceHolder1_btnSubmit").click();
                return true;
            }
            else {
                if (document.getElementById("ctl00_ContentPlaceHolder1_hdnFileStsFlag").value == "U") {
                    //                    $("#btn_Upload").addClass("btn btn-xs btn-primary disabled");
                    //                    $("#btn_Validate").addClass("btn btn-xs btn-primary");
                    //                    $("#btn_Process").addClass("btn btn-xs btn-primary disabled");

                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = false;
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = true;
                }
                else if (document.getElementById("cctl00_ContentPlaceHolder1_hdnFileStsFlag").value == "V") {
                    //                    $("#btn_Upload").addClass("btn btn-xs btn-primary disabled");
                    //                    $("#btn_Validate").addClass("btn btn-xs btn-primary disabled");
                    //                    $("#btn_Process").addClass("btn btn-xs btn-primary");

                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = false;
                }
                return false;
            }
        }
        //Button Upload
        function funAlertupload() {
            
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = false;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = true;
        }
        //Buttin Validate
        function funAlertvalidate() {
            //alert('File validated successfully, please proceed.');
            //            $("#btn_Upload").addClass("btn btn-xs btn-primary disabled");
            //            $("#btn_Validate").addClass("btn btn-xs btn-primary disabled");
            //            $("#btn_Process").addClass("btn btn-xs btn-primary");

            document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = false;
        }
        //Button Proecss
        function funAlertprocess(flag) {
            //        if (flag == "1") {
            //            alert('No record process, please view process log');
            //        }
            //        else {
            //            alert('File processd successfully.');
            //        }
            //            $("#btn_Upload").addClass("btn btn-xs btn-primary disabled");
            //            $("#btn_Validate").addClass("btn btn-xs btn-primary disabled");
            //            $("#btn_Process").addClass("btn btn-xs btn-primary disabled");

            document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = true;
        }
        function funAlertAppUpload() {
            alert('Application No. is missing!');
        }
        function StartProgressBar() {
            var myExtender = $find('ProgressBarModalPopupExtender');
            myExtender.show();
            //document.getElementById("btnSubmit").click();
            return true;
        }
        function StartProgressBar1() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlUpload").value != "--Select--") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_fileuploading").value == "") {
                    alert('Please browse file to upload.');
                    return false;
                }
                else {
                    var myExtender = $find('ProgressBarModalPopupExtender');
                    myExtender.show();
                    //document.getElementById("btnSubmit").click();
                    return true;
                }
            }
            else {
                alert('Please select document type to upload file.');
            }
        }


        function ShowReqDtl(divId, btnId) {
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById("ctl00_ContentPlaceHolder1_btnUploadDtls").value = '-';
            }
        }

        function AlertMsgs(msgs) {
            alert(msgs);
        }
    
    </script>
    <center>
        <div style="width: 70%; text-align: center;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <center>
                <table class="tableIsys" width="100%">
                    <tr>
                        <td class="test" style="height: 21px;" colspan="2" align="left">
                            <%--Added By Ibrahim on 9/5/2013 Modified class="formtitle" class="test" to change header background--%>
                            &nbsp;<asp:Label ID="lblTitle" runat="server" Width="100px" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" align="left" style="width: 13%; height: 21px;">
                            <asp:Label ID="lblUpload" runat="server" Width="160px"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 87%; height: 21px;">
                            <asp:DropDownList ID="ddlUpload" runat="server" CssClass="standardmenu" DataTextField="ParamDesc"
                                DataValueField="ParamValue" Width="375px" AutoPostBack="true" OnSelectedIndexChanged="ddlUpload_SelectedIndexChanged"
                                Font-Size="11px">
                            </asp:DropDownList>
                            
                            <%--<div class="btn btn-xs btn-primary" id="divUpld" runat="server">
                                <i class="fa fa-download"></i>--%>
                                <asp:Button ID="btnUpldFrmt" runat="server" CssClass="standardbutton" Width="165px"
                                    Text="Download Blank Format" OnClick="btnUpldFrmt_Click" />
                            <%--</div>--%>
                        </td>
                    </tr>
                    <tr align="center">
                        <td class="formcontent" style="width: 13%; height: 25px;">
                            <asp:Label ID="lblFileUpload" runat="server" Width="80px"></asp:Label>
                        </td>
                        <td class="formcontent" style="width: 87%; height: 25px">
                            <asp:FileUpload ID="fileuploading" runat="server" CssClass="TextBox" Width="456px" BackColor="#FAFAFA"/>
                        </td>
                    </tr>
                    <tr align="left">
                        <td class="formcontent" colspan="2" style="text-align: center; width: 100%; height: 21px">
                           
                            <%--<div class="btn btn-xs btn-primary">
                                <i class="fa fa-upload"></i>--%>
                                <asp:Button ID="btn_Upload" runat="server" CssClass="standardbutton" Text="Upload"
                                    Width="100px" OnClick="btn_Upload_Click" /><%--</div>--%>
                        <%--    <div class="btn btn-xs btn-primary">
                                <i class="fa fa-check-circle"></i>--%>
                                <asp:Button ID="btn_Validate" runat="server" CssClass="standardbutton disabled"
                                    Text="Validate" Width="100px" OnClick="btn_Validate_Click" /><%--</div>--%>
                            <%--<div class="btn btn-xs btn-primary">
                                <i class="fa fa-flash"></i>--%>
                                <asp:Button ID="btn_Process" runat="server" CssClass="standardbutton disabled"
                                    Text="Process" Width="100px" OnClick="btn_Process_Click" /><%--</div>--%>
                            <%--<div class="btn btn-xs btn-primary">
                                <i class="fa fa-times"></i>--%>
                                <asp:Button ID="btn_Cancel" runat="server" CssClass="standardbutton" Text="Cancel"
                                    Width="100px" OnClick="btn_Cancel_Click" /><%--</div>--%>
                        </td>
                    </tr>
                    <tr id="trFileSize" runat="server" >
                        <td class="formcontent" colspan="2" style="text-align: center; width: 100%; height: 21px">
                            <asp:Label ID="lblfilesize" runat="server" ForeColor="Green"
                                Width="500px" Text="Note: File size should not be greater than 1 MB."></asp:Label>
                        </td>
                    </tr>
                    <tr id="trMessage" runat="server" visible="false">
                        <td class="formcontent" colspan="2" style="text-align: center; width: 100%; height: 21px">
                            <asp:Label ID="lbl_Message" runat="server" Font-Bold="true" Visible="false" ForeColor="Red"
                                Width="500px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table id="tbl_grid" runat="server" class="formtable" style="width: 100%; visibility: hidden;">
                    <tr align="left">
                        <td class="test" colspan="3" align="left" style="border-collapse: separate; border-right-width: 0;">
                            <input runat="server" class="standardbutton" type="button" value="-" id="btnUploadDtls"
                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearchDetails','ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                            <asp:Label ID="lblNotes" runat="server" Text="Notes" Font-Bold="true" Font-Size="10px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <%--<table id="tblIRDA" runat="server" class="tableIsys" visible="false" width="100%">
                    <tr>
                        <td class="test" style="height: 21px;" align="left">
                             <asp:Label ID="lblIRDALog" runat="server" Width="200px" Text="IRDA Error Log Details"
                                Font-Bold="true"></asp:Label>
                        </td>
                        <td class="test" align="right" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="20%">
                                <asp:Label ID="lblIRDAInfo" runat="server" Style="text-align: right;"></asp:Label>
                         </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="divIRAD" runat="server" style="width:100%;">
                             </div>
                             <asp:GridView ID="dgIRDA" runat="server" Width="100%" AllowPaging="true" PageSize="10"
                                  AutoGenerateColumns="false"  Style="margin-top: 0px" BorderStyle="Solid">
                                  <Columns>
                                        <asp:TemplateField SortExpression="" HeaderText="Seq No" >
                                            <ItemTemplate>
                                                  <asp:Label ID="lblNo" runat="server" Text='<%# Eval("SeqNo") %>'></asp:Label>
                                             </ItemTemplate>
                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="" HeaderText="Assign to SM" >
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkError" runat="server"/>
                                            </ItemTemplate>
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="" HeaderText="InsurerRefNo" >
                                            <ItemTemplate>
                                                  <asp:Label ID="lblInsurerRefNo" runat="server" Text='<%# Eval("InsurerRefNo") %>'></asp:Label>
                                             </ItemTemplate>
                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField SortExpression="" HeaderText="Error Description" >
                                            <ItemTemplate>
                                                  <asp:Label ID="lblErrorDesc" runat="server" Text='<%# Eval("ErrorDesc") %>'></asp:Label>
                                             </ItemTemplate>
                                            <ItemStyle Width="60%" HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                  <HeaderStyle CssClass="portlet blue" ForeColor="White" HorizontalAlign="Center" />
                                  <PagerStyle ForeColor="blue" HorizontalAlign="Center" Font-Underline="True" CssClass="pagelink" />
                                  <RowStyle CssClass="sublinkodd1" HorizontalAlign="Left" ForeColor="#0076B7" />
                              </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnApprove" runat="server" CssClass="standardbutton" Text="Submit"
                                       Width="114px" onclick="btnApprove_Click" />
                        </td>
                    </tr>
                </table>--%>
                <table id="tblErrorLog" runat="server" class="tableIsys" visible="false" width="100%">
                    <tr>
                        <td class="test" style="height: 21px;" align="left">
                            &nbsp;<asp:Label ID="lblError" runat="server" Width="200px" Text="Process Log Details"
                                Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent2" align="left" style="width: 100%; height: 21px;">
                            <asp:Label ID="lbl_Error" runat="server" Width="160px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent2" style="width: 100%; height: 21px;">
                            <center>
                                <table id="Table1" runat="server" cellpadding="0" cellspacing="0" width="100%">
                                    <tr align="center" style="width: 100%;">
                                        <td align="center" style="width: 20%; height: 21px;">
                                            <center>
                                                <table class="tableborder" border="1" cellpadding="1" cellspacing="2">
                                                    <tr>
                                                        <td class="test" align="center" style="width: 20%; height: 21px;">
                                                            <asp:Label ID="lblDesc" runat="server" Text="Application Status" Width="160px" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td class="test" align="center" style="width: 20%; height: 21px;">
                                                            <asp:Label ID="lblCountDesc" runat="server" Text="Count Status" Width="160px" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td class="test" align="center" style="width: 20%; height: 21px;">
                                                            <asp:Label ID="Label1" runat="server" Text="View Process Log" Width="160px" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%; height: 21px;">
                                                            <asp:Label ID="lblTotlCount" runat="server" Width="160px" Text="Total Count" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td class="formcontent2" align="center" style="height: 21px;">
                                                            <asp:Label ID="lbltCountDesc" runat="server" Width="160px" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td class="formcontent" align="left" style="height: 21px;">
                                                         <asp:Label ID="lbl11" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%; height: 21px;">
                                                            <asp:Label ID="lblSuccessCount" runat="server" Width="160px" Text="Total Success Count"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td class="formcontent2" align="center" style="height: 21px;">
                                                            <asp:Label ID="lblSuccessCountDesc" runat="server" Width="160px" Font-Bold="true"
                                                                ForeColor="Green"></asp:Label>
                                                        </td>
                                                        <td class="formcontent2" align="center" style="height: 21px;">
                                                            <asp:LinkButton ID="lnkSuccess" runat="server" Font-Underline="True" OnClick="lnkSuccess_Click">Success Log</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formcontent" align="left" style="width: 20%; height: 21px;">
                                                            <asp:Label ID="lblErrorCount" runat="server" Width="160px" Text="Total Fail Count"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td class="formcontent2" align="center" style="height: 21px;">
                                                            <asp:Label ID="lblErrorCountDesc" runat="server" Width="160px" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                        </td>
                                                        <td class="formcontent2" align="left" style="height: 21px;">
                                                            <asp:LinkButton ID="lnkFail" runat="server" Font-Underline="true" OnClick="lnkFail_Click">Error Log</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                </table>
                <div id="griderror" runat="server" visible="false" style="width: 100%;">
                    <table class="tableIsys" width="100%">
                        <tr id="trErrorTitle" runat="server" visible="false">
                            <td class="test" align="left" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="80%">
                                <asp:Label ID="lblGridError" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="test" align="right" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="20%">
                                <asp:Label ID="lblPageInfo" runat="server" Style="text-align: right;"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trError" runat="server" visible="false">
                            <td class="formcontent" align="center" colspan="2">
                                <asp:GridView ID="ErrorGrid" AutoGenerateColumns="false" PageSize="10" runat="server"
                                    Width="100%" AllowPaging="true" Style="margin-top: 0px" BorderStyle="Solid" OnPageIndexChanging="ErrorGrid_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="Batchid" HeaderText="Batch ID">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UniqueRefNo" HeaderText="Unique Ref. No.">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ErrorDesc" HeaderText="Error Description">
                                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ErrorCode" HeaderText="Error Code">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerStyle ForeColor="blue" HorizontalAlign="Center" Font-Underline="True" CssClass="pagelink" />
                                    <RowStyle CssClass="sublinkodd1" HorizontalAlign="Left" ForeColor="#0076B7" />
                                    <%--<PagerStyle CssClass="pagelink"  ForeColor="Blue"  />
                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                <RowStyle CssClass="sublinkodd" ></RowStyle>
                                <HeaderStyle CssClass="test" ForeColor="DarkBlue" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr id="trSuccessTitle" runat="server" visible="false">
                            <td class="test" align="left" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="80%">
                                <asp:Label ID="lblGridSuccess" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                            <td class="test" align="right" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="20%">
                                <asp:Label ID="lblSPageInfo" runat="server" Style="text-align: right;"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trSuccess" runat="server" visible="false">
                            <td class="formcontent" align="center" colspan="2">
                                <asp:GridView ID="SuccessGrid" AutoGenerateColumns="false" PageSize="10" runat="server"
                                    Width="100%" AllowPaging="true" Style="margin-top: 0px" BorderStyle="Solid" OnPageIndexChanging="SuccessGrid_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="Batchid" HeaderText="Batch ID">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UniqueRefNo" HeaderText="Unique Ref. No.">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Insurer Ref No" HeaderText="Insurer Ref. No.">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Applicant Name" HeaderText="Applicant Name">
                                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SuccessDesc" HeaderText="Success Description">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="portlet blue" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerStyle ForeColor="blue" HorizontalAlign="Center" Font-Underline="True" CssClass="pagelink" />
                                    <RowStyle CssClass="sublinkodd1" HorizontalAlign="Left" ForeColor="#0076B7" />
                                    <%--<PagerStyle CssClass="pagelink"  ForeColor="Blue"  />
                                <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                <RowStyle CssClass="sublinkodd" ></RowStyle>
                                <HeaderStyle CssClass="test" ForeColor="DarkBlue" HorizontalAlign="Center" />--%><%--Added By Ibrahim on 9/5/2013 Modified class="formlink" class="test" to change header background--%>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="tableIsys" colspan="2">
                                <center>
                                    <asp:Label ID="lblErrMsg" runat="server" Width="400px" Font-Bold="true" ForeColor="Red"
                                        Visible="false"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                    <asp:Button ID="btnExport" runat="server" CssClass="standardbutton" Text="Export Errors"
                                        Visible="false" Width="114px" OnClick="btnExport_Click" />
                                &nbsp;
                                    <asp:Button ID="btnFailCase" runat="server" CssClass="standardbutton" Text="Export Failed Cases"
                                        Visible="false" Width="120px" OnClick="btnFailCase_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="hdnBatchid" runat="server" />
                <asp:HiddenField ID="hdnReturn" runat="server" />
                <asp:HiddenField ID="hdnFileStsFlag" runat="server" />
                <asp:HiddenField ID="hdnFlagCheck" runat="server" />
                <asp:Button ID="btnSubmit" runat="server" Style="display: none;" OnClick="btnSubmit_Click" />
                <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
                    BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
                    TargetControlID="hiddenField1" PopupControlID="Panel1">
                </ajaxToolkit:ModalPopupExtender>
                <asp:HiddenField ID="hiddenField1" runat="server" />
                <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: modalBackground;">
                    <%--background-color: #C0C0C0;--%>
                    <center>
                        <img src="../../../theme/iflow/animated_progress_bar.gif" />
                        <br />
                        <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
                    </center>
                </asp:Panel>
            </center>
            <asp:Panel runat="server" ID="pnlMdl" Width="500" display="none">
                <iframe runat="server" id="ifrmMdlPopup" width="500" height="300px" frameborder="0"
                    display="none"></iframe>
                <%--<asp:label runat="server" ID="lblMsg1" Text="Hi This Is PopUp Label"/>--%>
            </asp:Panel>
            <asp:Label runat="server" ID="lbl1" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
                DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg">
            </ajaxToolkit:ModalPopupExtender>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Lbl"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnl" runat="server" class="modalpopupmesg" BorderColor="ActiveBorder"
                BorderStyle="Solid" BorderWidth="2px" Width="400px" Height="200px">
                <table width="100%">
                    <tr align="center">
                        <td class="test" width="100%" colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
                </table>
                <table style="height: 100px">
                    <tr>
                        <td style="width: 391px">
                            <br />
                            <center>
                                <asp:Label ID="lbl" runat="server"></asp:Label><br />
                            </center>
                            <br />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="1205" Width="81px" />
                </center>
            </asp:Panel>
        </div>
    </center>
</asp:Content>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
--%>