<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Application_ISys_Recruit_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

     <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
      
    <%--    Added by for calneder sanoj 29122022--%>
     <link href="../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../../../KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
   
  <%--  ennded  by sanoj --%>

    <script language="javascript" type="text/javascript">


        

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



        $(function () {
            debugger;

            $("#<%= txtrptDtfrmval.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                maxDate:0
            });

           

            $("#<%= txtrptDtfrmvalA.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            }); //txtrptDtfrmvalA

        });
        function Dtfrmval() {
            $("#<%= txtrptDtfrmval.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        }
        function Dttoval() {
            $("#<%= txtrptDttoval.ClientID  %>").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                maxDate: 0
            });
         }

        // Added by Pratik 28/2/18 -start
        function Validate_Fields() {
            var dtFrom = document.getElementById('<%= txtrptDtfrmval.ClientID %>').value.trim();
            var dtEnd = document.getElementById('<%= txtrptDttoval.ClientID %>').value.trim();
            if (dtFrom == '' || dtEnd == '') {
                alert('Please Enter all the fields.');
                return false;
            }
            var StartDate = new Date(dtFrom);
            var EndDate = new Date(dtEnd);
            if (!Check_date_Format(dtFrom)) return false;
            if (!Check_date_Format(dtEnd)) return false;
            //if (EndDate > StartDate) {
            //    alert('End date cannot be greater than start date.');
            //    return false;
            //}
        }

        function Check_date_Format(date) {
            var matches = /^(\d{2})[-\/](\d{2})[-\/](\d{4})$/.exec(date);
            if (matches == null) {
                alert('Enter date in dd/mm/yyyy format');
                return false;
            }

            if (matches[3] < 1900) {
                alert('Year Must be Grater than 1900');
                return false
            }

            var d = matches[1];
            var m = matches[2] - 1;
            var y = matches[3];
            var composedDate = new Date(y, m, d);
            if (!(composedDate.getDate() == d && composedDate.getMonth() == m && composedDate.getFullYear() == y)) {
                alert('Enter valid Date Format');
                return false;
            }
            return true;
        }
        // Added by pratik 28/2/18 --end
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
            <div class="container">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                   <%-- <div style="overflow: hidden;">
                        <asp:Panel ID="Panel1" Width="100%" runat="server" Style="overflow: hidden;">--%>
                    <%-- <div  id="Div1" runat="server"  class="panel panel-default ">--%>
              <div class="panel panel-success PanelInsideTab" id="Div1" runat="server"  >
                     <div class="panelheadingAliginment"  onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnWfParam');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                        <asp:Label style="font-size:19px" ID="lbltitle" runat="server" CssClass="control-label HeaderColor" Font-Bold="True" Height="14px" Font-Size="Small"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                       <%-- <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right;
                            color: #034ea2;padding: 1px 10px ! important; font-size: 18px;"></span>--%>
                    </div>
                </div>
            </div>
                       <%-- <tr>
                       <%-- <tr>
                            <td class="test" colspan="4" align="left" style="border-collapse: separate; height: 20px;">
                                <asp:Label ID="lbltitle" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>--%>
                        <div class="row">
                        <div class="col-sm-12" >
                            <asp:Label ID="lblError2" runat="server" ForeColor="Green"  Text="Note : Please select the last day of the month." Visible="false"  Width="310px"></asp:Label>
                        </div>
                    </div>
             <%--           <tr align="center">
            <td colspan="4" align="center" style="border-collapse: separate; height: 20px;">
             <asp:Label ID="lblError2" runat="server" ForeColor="red" Text="Note : Please select the last day of the month." Visible="false"></asp:Label>
            </td>
            </tr--%>
              <div id="divSearch" runat="server" class="panel-body" style="display:block;">
                <div id="divSrvcReqReport" style="display: block;" class="panel-body panel-collapse collapse in">
               <div id="tr1" class="row" runat="server" visible="false">
                        <div class="col-sm-3" style="text-align: left">
                        <%--<tr id="tr1" runat="server" visible="false">
                            <td class="formcontent" align="left" style="height: 24px;">--%>
                                <asp:Label ID="lblCndNo" Text="Candidate No"  CssClass="control-label" runat="server"></asp:Label>
                         </div>
                                <div class="col-sm-3" >
                                <asp:TextBox ID="txtCndNo" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    InvalidChars="/.\?<>{}[];:|=+_-,#$@%^!*()&''%^~ `ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                    FilterMode="InvalidChars" TargetControlID="txtCndNo" FilterType="Custom">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                </div>
                               <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblBranchName"  CssClass="control-label" runat="server" Text="Branch Name"></asp:Label>
                             </div>
                               <div class="col-sm-3" >
                           
                       <%-- <tr id="tr2" runat="server" visible="false" >--%>
                             </div>
                             </div>
                               <div id="tr2" class="row"  runat="server" visible="false"> 
                               <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSMCode"  CssClass="control-label" runat="server" Text="Recruiter Code"></asp:Label>
                         </div>
                            <div class="col-sm-3" >
                                <asp:TextBox ID="txtSMCode" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                            <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblSMName"  CssClass="control-label" runat="server" Text="Recruiter Name"></asp:Label>
                            </div>
                            <div class="col-sm-3" >
                                <asp:TextBox ID="txtSMName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            </div>
                             <div id="trAll" class="row"  runat="server" visible="false"> </div>
                       <%-- <tr id="trAll" runat="Server">--%>
                                 <div class="card">  <%--Start Added By Keshav 06-09-22 --%>
                                     
                                     <div class="card-body">
                                         <div class="row rowspacing">

                         <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblprtDtfrm" runat="server"  CssClass="form-label" Text="Report Date From"></asp:Label>
<%--                                <span style="color: #CC0000">*</span>--%>
                                </div>
                            <div class="col-sm-3" >
                                <asp:TextBox ID="txtrptDtfrmval" runat="server" placeholder="dd-mm-yyyy" onmousedown="Dtfrmval();" CssClass="form-control" BorderColor="Red" ></asp:TextBox>
                              
                                </div>
                                <div class="col-sm-3" style="text-align: left">
                                <asp:Label ID="lblprtDtto" runat="server"  CssClass="form-label"   Text="Report Date To"></asp:Label>
                               <%-- <span style="color: #CC0000">*</span>--%>
                                   </div>

                            <div class="col-sm-3">
                                <asp:TextBox ID="txtrptDttoval" runat="server" onmousedown="Dttoval()" placeholder="dd-mm-yyyy" CssClass="form-control"  BorderColor="Red"></asp:TextBox>
                             
                           </div>
                                              <div id="trProcessType" class="row rowspacing"  runat="server" visible="false"> 
                  
                        
                        <%-- <tr id="trProcessType" runat="Server"  visible="false">--%>
                             <div class="col-sm-3 rowspacing" style="text-align: left" >
                              <asp:Label ID="lblProcessType"  CssClass="form-label" runat="server" Font-Bold="False"  Text="Process Type"></asp:Label>
                               <%-- <span style="color: #CC0000">*</span>--%>
                                </div>
                              <div class="col-sm-3" >
                                 <asp:DropDownList ID="ddlProcessType" runat="server"  AutoPostBack="false"  CssClass="form-control border-danger" width="110%"
                                           />
                                   <asp:Label ID="lblman" runat="server"  CssClass="control-label" Font-Bold="False" Text="Mandatory" visible="false" style="color: #CC0000"></asp:Label> 
                                 </div>
                          
                                        
                                 
                                                        </div> 
                                              <%-- Added by vikesh on 17.05.19--%>
                            <tr id="TrDate" visible="false" runat="Server">
                             <td class="formcontent" align="left" style="height: 24px;">

                                <asp:Label ID="lblDate" runat="server" Font-Bold="False" Text="Date Option"></asp:Label>
                             <span style="color: #CC0000">*</span>
                            </td>
                             
                            <td class="formcontent" align="left" style="height: 24px;">
                                <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" CssClass="standardmenu"  Width="187px" >
                                   <asp:ListItem value="">Select</asp:ListItem> 
                                  <asp:ListItem value="Cr">Create Date</asp:ListItem> 
                                  <asp:ListItem  value="UP">Update Date</asp:ListItem> 
                                
                                     </asp:DropDownList>
                            </td>
                            
                            <td class="formcontent" align="left" style="height: 24px;">
                            </td>
                            <td class="formcontent" align="left" style="height: 24px;">
                            </td>
                            </tr>
                        <%-- Ended by Nikhil on 11.01.16--%>
                         <div id="TrA" class="row"  runat="server" visible="false"> 
                       <%-- <tr id="TrA" visible="false" runat="Server">--%>
                          <div class="col-sm-6" style="text-align: left">
                                <asp:Label ID="lblA" runat="server" Text="Report Date From"></asp:Label>
                                </div>
                            
                           <div class="col-sm-6" >
                               <asp:TextBox ID="txtrptDtfrmvalA" runat="server"   CssClass="form-control" TextMode="Date" ReadOnly="false"></asp:TextBox>
                                
                                </div>
                            
                       
                            </div>
                                             <div class="row" style="margin-top: 12px;">
                            <div class="col-sm-12" align="center">
                            <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn btn-success"
                            OnClick="btnSearch_Click" OnClientClick="LdWait(100000)">
                                <span class="glyphicon glyphicon-download BtnGlyphicon"></span> View Report</asp:LinkButton>
                               
                                    <div id="divloader" runat="server" style="display:none;">
                                &nbsp;&nbsp; <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" /> Loading...
                                        </div>
                                             </div>
                                                </div>
                                    </div>
                      </div> 
                             </div><%--End Added By Keshav 06-09-22 --%>
                                     
                                
                                   
                             
                      
                               <%--Start Added By Pratik For Monthly GST Report 28-2-18 --%>
                               <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnExport" />
                                    </Triggers>
                                    <ContentTemplate>
                                    <asp:LinkButton ID="btnExport" runat="server" CssClass="btn btn-sample"  OnClientClick="javascript: return Validate_Fields()"
                                        OnClick="btnExport_Click" Visible=" false">
                                     <span class="glyphicon glyphicon-download BtnGlyphicon"></span> Export To Excel</asp:LinkButton>
                                        </ContentTemplate>
                                </asp:UpdatePanel>--%>
                                 <%--End Added By Pratik For Monthly GST Report 28-2-18 --%>
                         </div>
                       </div>
                       
                              <div class="row">
                        <div class="col-sm-12" style="margin-bottom: 5px;">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" CssClass="control-label"  Width="310px"></asp:Label>
                        </div>
                    </div>
                              <%--  <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" CssClass="standardlabelC"></asp:Label>
                         --%>
                     
                        </div>
                        </div>
                   <%-- </table>
                </td>
            </tr>--%>
              </div>
            <%--<tr>--%>
        
                <%--<td align="center">--%>
                 <div id="Div2" runat="server" visible="false" class="panel PanelInsideTab">
            
                     <div  class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_div3','Span1');return false;" >
                <div class="row">
                    <div class="col-sm-10" style="text-align:left">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Height="14px" style="font-size:19px"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <span id="Span1" class="glyphicon glyphicon-chevron-down" style="float: right;
                            color: #034ea2;padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
             <div id="div3" runat="server" class="panel-body" style="display:block;">
               
                    <asp:Panel ID="pnlRpt" runat="server">
                      <%--  <table>
                            <tr>
                                <td style="width: 100%;">--%>
                                <div class="row">
                        <div class="col-sm-12" style="margin-bottom: 5px;">
                                    <rsweb:ReportViewer ID="RptVwReport" runat="server" Width="100%" Height="300px"
                                        PageCountMode="Actual">
                                    </rsweb:ReportViewer>
                                    </div>
                                    </div>
                               <%-- </td>
                            </tr>
                        </table>--%>
                    </asp:Panel>
                    </div>
                    </div>
                    
               <%-- </td>
              
            </tr>--%>
          
      <%--  </table>--%>
    
     <%-- </asp:Panel>
      </div>--%>
      </ContentTemplate>
      </asp:UpdatePanel>
      </div>

</center>

</asp:Content>




