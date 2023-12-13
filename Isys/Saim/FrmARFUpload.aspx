<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmARFUpload.aspx.cs"
    Inherits="Application_INSC_Recruit_FrmARFUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    <script language="javascript" type="text/javascript">

        //Cancle Button Functionality
        function doCancel() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();


        }
        function Confirm() {
            debugger;
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
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = false;
                }
                else if (document.getElementById("cctl00_ContentPlaceHolder1_hdnFileStsFlag").value == "V") {
//                    $("#btn_Upload").addClass("btn btn-xs btn-primary disabled");
//                    $("#btn_Validate").addClass("btn btn-xs btn-primary disabled");
//                    $("#btn_Process").addClass("btn btn-xs btn-primary");

                                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = false;
                                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = false;
                }
                return false;
            }
        }

        function popup() {
            $("#myModal").modal();
           
        }
        //Button Upload
//        $(document).on('ready', function () {
//            $("#input-folder-1").fileinput({
//                browseLabel: 'Select Folder...'
//            });
//        });
        function funAlertupload() {

            //alert('File uploaded successfully, please proceed for validation.');
//            $("#btn_Upload").addClass("btn btn-xs btn-primary disabled");
//            $("#btn_Validate").addClass("btn btn-xs btn-primary");
//            $("#btn_Process").addClass("btn btn-xs btn-primary disabled");

                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = false;//commented by daksh
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Process").disabled = true;
        }
        //Buttin Validate
        function funAlertvalidate() {
            //alert('File validated successfully, please proceed.');
//            $("#btn_Upload").addClass("btn btn-xs btn-primary disabled");
//            $("#btn_Validate").addClass("btn btn-xs btn-primary disabled");
//            $("#btn_Process").addClass("btn btn-xs btn-primary");

                    document.getElementById("ctl00_ContentPlaceHolder1_btn_Upload").disabled = true;
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = false;//commented by daksh
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
            document.getElementById("ctl00_ContentPlaceHolder1_btn_Validate").disabled = false;//commented by daksh
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
            if (document.getElementById("ctl00_ContentPlaceHolder1_ddlUpload").value != "Select") {
                if (document.getElementById("ctl00_ContentPlaceHolder1_fileuploading").value == "") {
                    alert('Please browse file to upload.');
                    return false;
                }
                else {
                    ///var myExtender = $find('ProgressBarModalPopupExtender');
                    //myExtender.show();
                    //document.getElementById("btnSubmit").click();
                    return true;
                }
            }
            else {
                alert('Please select document type to upload file.');
            }
        }


        function ShowReqDtl(divName, btnName) {
            debugger;
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

       
        function AlertMsgs(msgs) {
            alert(msgs);
        }
    
    </script>
     <style type="text/css">
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
        }*/
       .modal-dialog{
    position: relative;
    display: table;
    overflow-y: auto;    
    overflow-x: auto;
    width: auto;
    min-width: 50px;   
}
        .disablepage
        {
            display: none;
        }
        ul#menu
        {
            padding: 0;
            margin-right: 69%;
        }
        
        ul#menu li
        {
            display: inline;
        }
        
        
        
        ul#menu li a
        {
            background-color: Silver;
            color: black;
            cursor: pointer;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 4px 4px 0 0;
        }
        ul#menu li a:active
        {
            background: white;
        }
        
        ul#menu li a:hover
        {
            background-color: red;
        }
        .subheader {
    font-size: 16px !important;
    </style>
    <center>
 <asp:ScriptManager id="SM1" runat="server">
   </asp:ScriptManager>
    <br />
        <center>
         
                <div class="panel">
                    <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnWfParam');return false;">
                        <div class="row">
                            <div class="col-sm-10" style="text-align: left;margin-bottom:-23px;">
                                <asp:Label ID="lblTitle" runat="server" CssClass="control-label" Font-Size="19px">Target Upload</asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="btnWfParam" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                    color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divSearch" runat="server" style="display:block;" class="panel-body">
                     <%--  <asp:UpdatePanel ID="updfile" runat="server">
                        <ContentTemplate>--%>
                        <div class="row">
                            <div class="col-xs-3">
                                <asp:Label ID="lblUpload" runat="server" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <asp:DropDownList ID="ddlUpload" runat="server" Width="156%" CssClass="form-control" DataTextField="ParamDesc"
                                    DataValueField="ParamValue" AutoPostBack="true" OnSelectedIndexChanged="ddlUpload_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="col-sm-3">
                                <asp:LinkButton ID="btnUpldFrmt" runat="server" Visible="false" CssClass="btn btn-sample" OnClick="btnUpldFrmt_Click"
                                    TabIndex="32">
                                 <span   class="glyphicon glyphicon-download" style="color:white"></span>  Download Blank Format
                                </asp:LinkButton>
                            </div>
                        </div>
                       <br />
                        <br />
                        <div class="row">
                            <div class="col-xs-3" >
                                <asp:Label ID="lblFileUpload" CssClass="control-label" runat="server" Width="80px"></asp:Label>
                            </div>
                            <div class="col-xs-6" style="text-align:left">
                                <asp:FileUpload ID="FileUpload1" Width="156%" class="form-control" runat="server" />
                              
                            </div>
                        </div>
                      <%--  </ContentTemplate>
                        </asp:UpdatePanel> --%>
                        <br/>
                         <div class="row" >
                             <div class="col-sm-12" align="center">
                                 <asp:LinkButton ID="btn_Upload" runat="server" CssClass="btn btn-sample" OnClick="btn_Upload_Click"
                                     TabIndex="32">
                                    <span   class="glyphicon glyphicon-upload" style="color:white"></span> Upload
                                 </asp:LinkButton>
                                 <asp:LinkButton ID="btn_Validate" runat="server" CssClass="btn btn-sample" OnClick="btn_Validate_Click"
                                     TabIndex="32">
                                    <span   class="glyphicon glyphicon-exclamation-sign" style="color:white"></span> Validate
                                 </asp:LinkButton>
                                 <asp:LinkButton ID="btn_Process" runat="server" CssClass="btn btn-sample" OnClick="btn_Process_Click"
                                     TabIndex="32">
                                    <span   class="glyphicon glyphicon-saved" style="color:white"></span> Process
                                 </asp:LinkButton>
                                 <asp:LinkButton ID="btn_Cancel" runat="server" CssClass="btn btn-sample" CausesValidation="False"
                                     OnClick="btn_Cancel_Click" TabIndex="33">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:white"> </span> Cancel
                                 </asp:LinkButton>
                             </div>
                     </div>
                    
                     <div id="trFileSize" runat="server" class="row" style="text-align:center;margin-top:8px;">
                        <asp:Label ID="lblfilesize" runat="server" ForeColor="Black"  CssClass="control-label"
                               Text="Note: File size should not be greater than 1 MB."></asp:Label>
                     </div>
                      <div  id="trMessage" runat="server" visible="false" class="row" style="text-align:center">
                        <asp:Label ID="lbl_Message" runat="server" Font-Bold="true" Visible="false" ForeColor="Red"
                               CssClass="control-label"></asp:Label>
                      </div>
                      <br/>
                        <div class="row" id="tbl_grid" runat="server" style="display: none">
                            <div class="panel">
                                <div class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearchDetails','btnUploadDtls');return false;"
                                    style="background-color: white !important;">
                                    <div class="col-sm-10" style="text-align: left">
                                        <asp:Label ID="lblSearch" runat="server" Font-Bold="True" class="subheader"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <span id="btnUploadDtls" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                            color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                    </div>
                                    <asp:Label ID="lblNotes" runat="server" Text="Notes" Font-Bold="true" Font-Size="10px"></asp:Label>
                                </div>
                                <div class="panel-body">
                                   
                                </div>
                            </div>
                        </div>
                        <div class="row" id="tblErrorLog" runat="server" visible="false">
                            <div class="panel">
                                  <div class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divValid','btnValid');return false;"
                                    >
                                    <div class="row" >
                                        <div class="col-sm-10 subheader" style="text-align: left;"> 
                                            Process Log Details
                                            
                                        </div>
                                        <div class="col-sm-2" style="margin-top: -18px;">
                                            <span id="btnValid" class="glyphicon glyphicon-menu-hamburger" style="float: right;
                                                color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="divValid" style="display:block;" runat="server">
                                    <table class="footable" style="margin:1%;width:97%">
                                        <thead >
                                            
                                        </thead>
                                        <tbody >
                                            <tr class="gridview th">
                                                <th >
                                                    <asp:Label ID="lblDesc" runat="server" Text="Application Status" ></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="lblCountDesc" runat="server" Text="Count Status" ></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label1" runat="server" Text="View Process Log" ></asp:Label>
                                                </th>
                                            </tr>
                                            <tr class="GridViewRowNew">
                                                <td>
                                                    <asp:Label ID="lblTotlCount" runat="server" Text="Total Count" ></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbltCountDesc" runat="server" ></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:Label ID="lbl11" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="GridViewRowNew">
                                                <td >
                                                    <asp:Label ID="lblSuccessCount" runat="server"  Text="Total Success Count"
                                                       ></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSuccessCountDesc" runat="server" 
                                                        ForeColor="Green"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkSuccess" runat="server" Font-Underline="True" OnClick="lnkSuccess_Click">Success Log</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr class="GridViewRowNew">
                                                <td >
                                                    <asp:Label ID="lblErrorCount" runat="server"  Text="Total Fail Count"
                                                      ></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:Label ID="lblErrorCountDesc" runat="server"  ForeColor="Red"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkFail" runat="server" Font-Underline="true" OnClick="lnkFail_Click">Error Log</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                         <tr>
                            <td class="tableIsys" colspan="2">
                                <center>
                                    <asp:Label ID="lblErrMsg" runat="server" Width="400px" Font-Bold="true" ForeColor="Red"
                                        Visible="false"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <div class="row" id="griderror" runat="server" visible="false" >
                            <div class="panel">
                                <div class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trError','btnValidLog');return false;"
                                  >
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                             <asp:Label ID="lblGridError" runat="server" class="subheader"></asp:Label>
                                        </div>
                                        <div class="col-sm-2" style="margin-top: -18px;">
                                            <span id="btnValidLog" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                              
                                <div class="row" id="trError" runat="server" style="display:none;margin:1%;">
                                  <div>
                                 <div>
                                  <asp:GridView ID="ErrorGrid" AutoGenerateColumns="false" PageSize="10" runat="server" CssClass="footable"
                                      Style="border-bottom-color: black;"
                                  AllowPaging="true" OnPageIndexChanging="ErrorGrid_PageIndexChanging">
                                     <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <HeaderStyle CssClass="gridview th" />
                                                <PagerStyle CssClass="disablepage" />
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
                                  
                                </asp:GridView>
                                </div>
                                </div>
                                </div>
                            </div>
                        </div>
                          <div class="row" id="trSuccessTitle" runat="server" visible="false" >
                            <div class="panel">
                                <div class="panel-heading subheader" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trSuccess','btnValidSuccess');return false;"
                                    style="background-color: white !important;">
                                    <div class="row">
                                        <div class="col-sm-10" style="text-align: left">
                                            <span class="glyphicon glyphicon-menu-hamburger" style="color: #034ea2;"></span> 
                                             <asp:Label ID="lblGridSuccess" runat="server" class="subheader"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <span id="btnValidSuccess" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2;
                                                padding: 1px 10px ! important; font-size: 18px;"></span>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="row" id="trSuccess" runat="server" style="display:none;margin:1%;">
                                 <div style="overflow-x: scroll;">
                               
                                                  <asp:GridView ID="SuccessGrid" AutoGenerateColumns="false" PageSize="10" runat="server"
                                 Style="border-bottom-color: black;" AllowPaging="true" CssClass="footable" OnPageIndexChanging="SuccessGrid_PageIndexChanging">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <HeaderStyle CssClass="gridview th" />
                                                <PagerStyle CssClass="disablepage" />
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
                                      </asp:GridView>
                                </div>
                                </div>

                                <div class="row" id="trsapsuccess" runat="server" style="display:none;margin:1%;" >
                                 <div style="overflow-x: scroll;">
                               
                                                  <asp:GridView ID="sapSuccessGrid" AutoGenerateColumns="false" PageSize="10" runat="server"
                                 Style="border-bottom-color: black;" AllowPaging="true" CssClass="footable" OnPageIndexChanging="sapSuccessGrid_PageIndexChanging">
                                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                <HeaderStyle CssClass="gridview th" />
                                                <PagerStyle CssClass="disablepage" />
                                    <Columns>
                                        <asp:BoundField DataField="Batchid" HeaderText="Batch ID">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False" ></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MemberCode" HeaderText="Member Code">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="Member Name" HeaderText="Member Name">
                                            <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SuccessDesc" HeaderText="Success Description">
                                            <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                      </asp:GridView>
                                </div>
                                </div>
                               
                            </div>
                        </div>
                        
                         <div class="row" style="padding-bottom: 6px ! important;">
                            <div class="col-md-12" style="text-align: center">
                                <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-sample"
                                    Visible="false"  OnClick="btnExport_Click">
                         <span class="glyphicon glyphicon-download BtnGlyphicon"></span> Export Errors</asp:LinkButton>
                               
                                    <asp:LinkButton ID="btnFailCase" runat="server" Visible="false" CssClass="btn btn-sample" OnClick="btnFailCase_Click" >
                                    <span id="spnView" runat="server" class="glyphicon glyphicon-download BtnGlyphicon">
                                    </span> Export Failed Cases</asp:LinkButton>
                            </div>
                        </div>    
                </div>
               </div>
               
        </center>
               
       
        
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
                <table id="tblhello"  runat="server" class="tableIsys" visible="false" width="100%">
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
                                <table runat="server" cellpadding="0" cellspacing="0" width="100%">
                                    <tr align="center" style="width: 100%;">
                                        <td align="center" style="width: 20%; height: 21px;">
                                            <center>
                                                <table class="tableborder" border="1" cellpadding="1" cellspacing="2">
                                                  
                                                </table>
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                </table>
                <div style="width: 100%;display:none;">
                    <table class="tableIsys" width="100%">
                        <tr id="trErrorTitle" runat="server" visible="false">
                            <td class="test" align="left" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="80%">
                              
                            </td>
                            <td class="test" align="right" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="20%">
                                <asp:Label ID="lblPageInfo" runat="server" Style="text-align: right;"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td class="formcontent" align="center" colspan="2">
                              
                            </td>
                        </tr>
                        <tr >
                            <td class="test" align="left" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="80%">
                                
                            </td>
                            <td class="test" align="right" style="border-collapse: separate; border-right-width: 0;
                                height: 20px;" width="20%">
                                <asp:Label ID="lblSPageInfo" runat="server" Style="text-align: right;"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td class="formcontent" align="center" colspan="2">
                               
                            </td>
                        </tr>
                       
                        <tr>
                            <td align="center" colspan="2">
                                
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
            <asp:Panel runat="server" ID="pnlMdl" Width="400" display="none">
                <iframe runat="server" id="ifrmMdlPopup" width="400px" height="300px" frameborder="0"
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
     <div class="container">  
     <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-sm" style="left:174px;width:47%;">
    
      <!-- Modal content-->
      <div class="modal-content" >
        <div class="modal-header" style="text-align: center;background-color:#dff0d8;">
            <asp:Label ID="Label3" Text="INFORMATION" runat="server" Font-Bold="true"></asp:Label>
                                     
        </div>
        <div class="modal-body" style="text-align: center">
          <asp:Label ID="lbl" runat="server"></asp:Label>
        </div>
        <div class="modal-footer" style="text-align: center">
          <button type="button" class="btn btn-sample" data-dismiss="modal" style='margin-top:-6px;' >
             <span class="glyphicon glyphicon-ok" style='color:White;'> </span> OK

             </button>
         
        </div>
      </div>
      
    </div>
  </div>
    </div>
</asp:Content>
