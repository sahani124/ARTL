<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"  EnableEventValidation="false" 
    CodeFile="LicWelcomeLetter.aspx.cs"
    Inherits="Application_ISys_ChannelMgmt_LicWelcomeLetter" Title="Prospect Search" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>
<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />

       <%-- ended  by sanoj 14032023--%>
    <style type="text/css">
        .tr31{
                margin-left: 96px;
    margin-right: 97px;
    margin-top: 2%;
    padding: 1%;
        }
        .gridview th {
    padding: 10px;
    height: 40px;
    border-color: #53accd !important;
    text-align: left;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
} 
             .clsleft{
        text-align:left!important;
    }
         .clscenter{
        text-align:center!important;
    }
        .colHeader-CenterAlign {
        text-align:center !important;
    }
      
	.LnkBtn
	 {	
      text-decoration:underline;	
     }
	
   
    </style>
      
    <script type="text/javascript" language="javascript">
      

        function ShowReqDtl(divName, btnName) {
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
         //added by ajay start
        $(function () {
            debugger; $("#<%= txtDTRegTo.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });
        });

         $(function () {
             debugger; $("#<%= txtDTRegFrom.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });
         });
        function funcopenDocs(arg1) {
            debugger;
            
            $find("mdlViewBID").show();

            //MdlPopRaiseSub
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "../../../Application/ISys/ChannelMgmt/FPView_Document_Details.aspx?CndNo=" + arg1 + "&Type=N&mdlpopup=mdlViewBID";

        }
        //added by ajay end
        function doClear() {
            debugger;
           
           document.getElementById("<%=txtGivenName.ClientID%>").value = "";
           
            document.getElementById("<%=txtDTRegFrom.ClientID%>").value = "";
            document.getElementById("<%=txtDTRegTo.ClientID%>").value = "";
         
          
        }
               //addd by ajay for RF (HNIN)
        function GetQueryStringValue(url, param) {
            debugger;
            param = param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regVal = new RegExp("[\\?&]" + param + "=([^&#]*)"),
            results = regVal.exec(url);
            return results === null ? null : decodeURIComponent((results[1]).replace(/\+/g, " "));
        }

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <center>
    <asp:UpdatePanel ID="up_prospect" runat="server">
    <ContentTemplate>
    
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
                       
                        <div id="contentDiv" runat="server" class="panel-body panelContent">
                        

                           <div class="row rowspacing">
                          <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblDTRegFrom" runat="server" CssClass="control-label labelSize"  > </asp:Label><%--width changed by shreela on 6/03/14--%>
                              <%-- <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegFrom" MaxLength="10" 
                        TabIndex="12" />--%>
                               <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegFrom" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });" MaxLength="10" placeholder="(dd/mm/yyyy)" 
                        TabIndex="12" />
                  
                 
                          </div>
						  <div class="col-sm-4" style="text-align: left">
                             <asp:Label ID="lblDTRegTO" runat="server" CssClass="control-label labelSize"></asp:Label>
                             <asp:TextBox CssClass="form-control" runat="server" ID="txtDTRegTo" onmousedown="$(this).datepicker({ dateFormat: 'dd/mm/yy', changeYear: true, changeMonth: true, maxDate: 0 });" MaxLength="10" placeholder="(dd/mm/yyyy)"
                        TabIndex="12" />
                    
                          </div>
                             <div class="col-sm-4" style="text-align: left">
                              <asp:Label ID="lblFrenchCode" runat="server" Text="Code" CssClass="control-label labelSize"></asp:Label>

                                <asp:TextBox ID="txtFrenchCode" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
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
                           
                                <asp:DropDownList ID="ddlShwRecrds1" runat="server" CssClass="form-control form-select"  AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlShwRecrds1_SelectedIndexChanged">
                                </asp:DropDownList>
                          </div>
						 
						  <div class="col-sm-4" style="text-align: left">
                             
                          </div>
                         </div>


                              <div class="row rowspacing">
                          <div class="col-sm-12" style="text-align: center">
                               <asp:LinkButton ID="btnSearch" runat="server"  CssClass="btn btn-success" OnClick="btnSearch_Click" OnClientClick="return getvalid();" > <span class="glyphicon glyphicon-search BtnGlyphicon"></span>SEARCH </asp:LinkButton>
                              &nbsp;

                               <asp:Button ID="btnClear" runat="server" CssClass="btn btn-clear" TabIndex="43" OnClientClick="doClear();return false;"
                                    Text="CLEAR" Width="80px"  />&nbsp;
                          </div>
                         </div>

                             <div class="row rowspacing">
                          <div class="col-sm-12" style="text-align: center;margin-bottom:5px;">
                          <asp:Label ID="Label2" runat="server"></asp:Label>

                          </div>
						  
                         </div>

                            </div>
                       </div>
        </div>
                     
   

       <br />
                   

                    
                   
     <div id="tr31" runat="server" class="card  PanelInsideTab" visible="false" style="margin-top: -6px;">
            
                <div id="Div3" runat="server" class="panelheadingAliginment" >
                        <div class="row" style="margin-bottom:14px">
                            <div class="col-sm-10" style="text-align: left">
 
                                <asp:Label ID="Label7" runat="server" Text="Member Search Result"  CssClass="control-label HeaderColor">
                                </asp:Label>
                                <%-- <asp:Label ID="lblPageInfo1" runat="server" Font-Bold="true" Width="160px" Visible="false"></asp:Label>--%>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span2" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_trDgDetails','Span2');return false;"></span>
                            </div>
                        </div>
                    </div>

                <div id="trLICId" runat="server"  visible="false" class="panel-body">
                               
                                 <div style="padding: 10px;overflow-x: scroll;">
                                         
                                           <asp:GridView ID="GrdLicId" runat="server" AutoGenerateColumns="False" CssClass="footable"
                                PageSize="10" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GrdLicId_PageIndexChanging"
                                OnSorting="GrdLicId_Sorting" OnRowCommand="GrdLicId_RowCommand" style="overflow-x: scroll;">
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
                                                <asp:TemplateField SortExpression="CandidateNo" HeaderText="Candidate Id"   Visible="false"  >
                                                    <ItemTemplate>
                                                     <i class="fa fa-male"></i>
                                                        <asp:Label ID="lblMemcode" runat="server" Text='<%# Eval("MemCode") %>' ToolTip='<%# Eval("MemCode") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle CssClass="clsCenter" />
                                                      <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="ApplicationNo"  HeaderText="EmpCode"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EmpCode") %>' ToolTip='<%# Eval("EmpCode") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle CssClass="clsCenter" />
                                                     <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Givenname" HeaderText="Name"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvnname" runat="server" Text='<%# Eval("Givenname") %>' ToolTip='<%# Eval("Givenname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                  <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Surname" HeaderText="Surname"   Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSurnme" runat="server" Text='<%# Eval("Surname") %>' ToolTip='<%# Eval("Surname") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="CreateDTim" HeaderText="Reg Date"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCreateDTim" runat="server" Text='<%# Eval("CreateDTim","{0:dd/MM/yyyy}") %>' ToolTip='<%# Eval("CreateDTim") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <ItemStyle CssClass="clsCenter" />
                                        <HeaderStyle CssClass="clsCenter" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="Channel" HeaderText="Channel"   >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblchannel" runat="server" Text='<%# Eval("Channel") %>' ToolTip='<%# Eval("Channel") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentName" HeaderText="Recruiter Name"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntname" runat="server" Text='<%# Eval("AgentName") %>' ToolTip='<%# Eval("AgentName") %>' style="padding-left:5px;"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                <asp:TemplateField SortExpression="AgentCode" HeaderText="Recruiter Code"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgntCode" runat="server" Text='<%# Eval("AgentCode") %>' ToolTip='<%# Eval("AgentCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField SortExpression="Agent_SAPCODE" HeaderText="SAP Code"  >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent_SAPCODE" runat="server" Text='<%# Eval("Agent_SAPCODE") %>' ToolTip='<%# Eval("Agent_SAPCODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsLeft" />
                                                    <HeaderStyle CssClass="clsLeft" />
                                                </asp:TemplateField>
                                                
                                                <%-- <asp:TemplateField SortExpression="CandidateNo"   HeaderText="Action"  >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkIndvLic" runat="server" Text="Welcome Letter" CommandArgument='<%# Eval("MemCode") %>'
                                                            CommandName="FPWelcmLttr"></asp:LinkButton>
                                                </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                
                                            </Columns>
                                             
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
                                    
                                          
                             </div>
         
                              <div class="row">
                          <div class="col-sm-12" style="text-align: center">
                               <asp:LinkButton ID="btnDwnld" runat="server"  CssClass="btn btn-success" OnClick="btnDwnld_Click"> <span class="glyphicon glyphicon-download"></span>Dwonload </asp:LinkButton>
                              &nbsp;

                              
                          </div>
                         </div>
        </div>
         </ContentTemplate>
    </asp:UpdatePanel>
    </center>
   
      </asp:Content>
