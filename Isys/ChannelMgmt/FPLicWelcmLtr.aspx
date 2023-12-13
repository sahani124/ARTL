<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FPLicWelcmLtr.aspx.cs" Inherits="Application_Isys_ChannelMgmt_FPLicWelcmLtr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
         <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
 
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

    <script type="text/javascript">
        function checkCommValid() {
           
            debugger;
            var fromdate = document.getElementById("ctl00_ContentPlaceHolder1_txtDTRegFrom").value;
            var toDate = document.getElementById("ctl00_ContentPlaceHolder1_txtDTRegTo").value;
            var startDate = convertDateFormat(fromdate);
            var endDate = convertDateFormat(toDate);
            const inputString = document.getElementById("ctl00_ContentPlaceHolder1_txtFrenchCode").value;
            const commaCount = countCommas(inputString);
             if (commaCount >5 )
            {
              alert('Please enter maximum six member code');
              return false;
            }
            if (fromdate != '' && toDate != '') {
                if (endDate < startDate)
                {
                    alert('The Report Date To must be after the From Date .');
                    return false;
                }
                else
                {
                    const dateCount = getDateCount(startDate, endDate);
                    if ((dateCount) >= 32)
                    {
                        alert('Report date range should not be greater than 31 days.');
                        return false;
                    }
                }
            }
            else {
                    alert('Please select From date and To date');
                    return false;
            }
           
            
          }
        function countCommas(str)
                   {
                    const commaRegex = /,/g; // g flag to find all occurrences
                    const matches = str.match(commaRegex);
                    return matches ? matches.length : 0;
                   }
       function convertDateFormat(inputDate) {
                    const regex = /(\d{2})\/(\d{2})\/(\d{4})/;
                    return inputDate.replace(regex, '$2/$1/$3');
                   }
        // Function to calculate date count between two dates
        function getDateCount(startDate, endDate) {
               
            const [startMonth, startDay, startYear] = startDate.split('/');
            const [endMonth, endDay, endYear] = endDate.split('/');
           
            const startDateObj = new Date(startYear, startMonth - 1, startDay);
            const endDateObj = new Date(endYear, endMonth - 1, endDay);
           
            const timeDifference = endDateObj - startDateObj;
            const daysDifference = timeDifference / (1000 * 3600 * 24);
           
            return daysDifference;
                   }
        function doClear() {
           // debugger;
            document.getElementById("<%=txtGivenName.ClientID%>").value = "";
            document.getElementById("<%=txtDTRegFrom.ClientID%>").value = "";
            document.getElementById("<%=txtDTRegTo.ClientID%>").value = "";
            document.getElementById("<%=txtFrenchCode.ClientID%>").value = "";
        }

        function funReport(CndNo, ReportType) {
            debugger;
            var modal = document.getElementById('MyModalRpt');
            var modaliframe = document.getElementById("iframeRpt");
            modaliframe.src = "../../../Application/ISys/Recruit/IndividualReport.aspx?Type=" + ReportType + "&MemCode=" + CndNo + "&mdlpopup=MdlPopupReport";
            var span = document.getElementsByClassName("close")[0];

            span.onclick = function () {
                debugger;
                modal.style.display = "none";

            }
            $('#MyModalRpt').modal();
        }
        function ShowReqDtl(divName, btnName) {
            try {
                debugger;
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
            }
            catch (err) {
                ////ShowError(err.description);
            }
        }

    </script>
    <style type="text/css">

   .clsLeft{
        text-align:left!important;
        padding:0px !important;
    }
         .clsCenter{
        text-align:center!important;
    }
    </style>

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
   
    
    <div class="card PanelInsideTab"  >

                       <div id="SearchDiv" class="panelheadingAliginment" runat="server">
                           <div id="titlediv" runat="server" class="control-label HeaderColor" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_contentDiv','btnWfParam');return false;">
            <div class="row">
                <div class="col-sm-10" style="text-align: left">
                    <asp:Label ID="lbltitle" runat="server" style="font-size:19px;margin-left: 17px;"></asp:Label>
                </div>
                <div class="col-sm-2">
                    <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right; padding: 1px 10px ! important; font-size: 18px;"></span>
                </div>
            </div>
        </div>
                       
                        <div id="contentDiv" runat="server" style="display:block;" class="panel-body panelContent">
                        

                           <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label labelSize"  > </asp:Label>
                             
                               <asp:TextBox CssClass="form-control mandatory" runat="server" ID="txtDTRegFrom" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });" MaxLength="10" placeholder="(dd/mm/yyyy)" 
                        TabIndex="12" />
                  
                 
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                             <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label labelSize"></asp:Label>
                             <asp:TextBox CssClass="form-control mandatory" runat="server" ID="txtDTRegTo" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });" MaxLength="10" placeholder="(dd/mm/yyyy)"
                        TabIndex="12" />
                    
                          </div>
                             <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblFrenchCode" runat="server" Text="Code" CssClass="control-label labelSize"></asp:Label>

                                <asp:TextBox ID="txtFrenchCode" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="60"></asp:TextBox>
                          </div>
						  <div class="col-sm-4" style="text-align: left;display:none">
                              <asp:Label ID="lblFranName" runat="server" CssClass="control-label labelSize" ></asp:Label>
                                    
                                        <asp:TextBox ID="txtGivenName" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                            FilterType="LowercaseLetters, UppercaseLetters,Custom" ValidChars=" '" TargetControlID="txtGivenName">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                          </div>
                         </div>

                           <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblShwRecords1" runat="server" CssClass="control-label labelSize" ></asp:Label>
                           
                                <asp:DropDownList ID="ddlShwRecrds1" runat="server" CssClass="form-control form-select">
                                </asp:DropDownList>
                          </div>
						 
						  <div class="col-sm-4" style="text-align: left">
                             
                          </div>
                         </div>


                              <div class="row rowspacing">
                          <div class="col-sm-12" style="text-align: center">
                               <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-success" OnClientClick="return checkCommValid();" OnClick="btnSearch_Click" > <span class="glyphicon glyphicon-search BtnGlyphicon"></span>SEARCH </asp:LinkButton>
                              &nbsp;

                               <asp:Button ID="btnClear" runat="server" CssClass="btn btn-clear" TabIndex="43" OnClientClick="doClear();"
                                    Text="CLEAR" Width="80px" OnClick="btnClear_Click"/>&nbsp;
                                     
                          </div>
                         </div>

                           

                            </div>
                       </div>
        </div>


      <div id="tr31" runat="server" class="card  PanelInsideTab" visible="false" style="margin-top: 5px;">
            
                <div id="Div3" runat="server" class="panelheadingAliginment" >
                        <div class="row" style="margin-bottom:14px">
                            <div class="col-sm-10" style="text-align: left">
 
                                <asp:Label ID="Label7" runat="server" Text="Member Search Result"  CssClass="control-label HeaderColor">
                                </asp:Label>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trLICId','Span2');return false;"></span>
                            </div>
                        </div>
                    </div>

                <div id="trLICId" runat="server"  visible="false" class="panel-body">
                                
                                 <div style="padding: 10px;overflow-x: scroll;">
                                         
                                           <asp:GridView ID="GrdLicId" runat="server" AutoGenerateColumns="False" CssClass="footable" OnRowCommand="GrdLicId_RowCommand"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GrdLicId_PageIndexChanging"
                                style="overflow-x: scroll;">
                                <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                             <Columns>
                                                  <asp:TemplateField HeaderStyle-Wrap="false" ItemStyle-Width="6%">
                                                  <ItemTemplate>
                                                            <asp:CheckBox ID="ChkAssigned" runat="server" />
                                                     </ItemTemplate>
                                                      <ItemStyle CssClass="clsCenter" />
                                                      <HeaderStyle CssClass="clsCenter" />
                                                   </asp:TemplateField>
                                                <asp:TemplateField  HeaderText="Candidate Id"   Visible="false"  >
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblMemcode" runat="server" Text='<%# Eval("MemCode") %>' ToolTip='<%# Eval("MemCode") %>' ></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle CssClass="clsCenter" />
                                                      <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField   HeaderText="EmpCode"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EmpCode") %>' ToolTip='<%# Eval("EmpCode") %>' ></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle CssClass="clsCenter" />
                                                     <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>' ></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                  <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderText="Surname"   Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' ></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderText="Reg Date"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderText="Channel"   >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderText="Recruiter Name"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' ></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderText="Recruiter Code"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="SAP Code"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>

                                                     <asp:TemplateField  HeaderText="Action" >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIndvLic" runat="server" CommandArgument='<%# Eval("MemCode") %>'
                                                            CommandName="FPWelcmLttr"> <span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
                                                </ItemTemplate>
                                                          <ItemStyle CssClass="clsCenter" />
                                                      <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>

                                            </Columns>
                                              <EmptyDataTemplate > <div style="color: red;text-align: center;">No Records Found</div></EmptyDataTemplate>  
                                        </asp:GridView>
                                             </div>
                                           <div>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnPreLIC" Text="<" CssClass="form-submit-button" runat="server"
                                                Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnPreLIC_Click" />
                                            <asp:TextBox runat="server" ID="txtLICId" Text="1" Style="width: 35px; border-style: solid;
                                                border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                text-align: center;"   ReadOnly="true" />
                                            <asp:Button ID="btnNextLIC" Text=">" CssClass="form-submit-button" runat="server"
                                                Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                background-color: transparent; float: left; margin: 0; height: 30px;" Width="40px"
                                                OnClick="btnNextLIC_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                               </div>
                                    
                                 <div class="row">
                          <div class="col-sm-12" style="text-align: center;margin: 9px">
                             <asp:LinkButton ID="btndownload" Visible="false" runat="server" OnClick="btndownload_Click"  CssClass="btn btn-success" >
                                 <span class="glyphicon glyphicon-download" style="color:white;"></span>Download</asp:LinkButton>
                              &nbsp;
                              &nbsp;

                              
                          </div>
                         </div>         
                             </div>
         
                              
        </div>

    <div class="modal" id="MyModalRpt" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10px;" >
  <div class="modal-dialog" style="
    padding-top: 0px;
    width: 55%;">
    <div class="modal-content" style="width:712px!important">
      <div class="modal-header" style="padding-right:326px;height: 43px;">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
        <h4 class="modal-title" id="myModalLabel">Report</h4>
      </div>
      <div class="modal-body" >
          <iframe id="iframeRpt" src="" width="675" height="300" frameborder="0" allowtransparency="true"></iframe>  
      </div>
      <div class="modal-footer" style="text-align: center;padding-right: 298px">
          <button type="button" class="btn btn-clear" data-dismiss="modal" >
             <span class="glyphicon glyphicon-remove" style='color:Red;'> </span> Cancel

             </button>
         
        </div>
    </div>
    <!-- /.modal-content -->
  </div>
  <!-- /.modal-dialog -->
</div>
</asp:Content>

