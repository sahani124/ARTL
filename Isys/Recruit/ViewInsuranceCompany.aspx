<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="ViewInsuranceCompany.aspx.cs"
    Inherits="Application_ISys_Recruit_ViewInsuranceCompany" Title="Untitled Page" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>

    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
      <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" type="text/css" />
        <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
	<style>
		.clsCenter{
			text-align:center !important;
		}
	</style>
    <script type="text/javascript">
      
		 function fillDte (txtdte) {
            debugger;
            var Id="#"+txtdte;
            $(Id).datepicker({
                 dateFormat: 'dd/mm/yy',
                 changeMonth: true,
                 changeYear: true,
             });

         }

        var strContent = "ctl00_ContentPlaceHolder1_";
        function validateEmail1(sEmail1) {
            //debugger;
            var reEmail = /^(?:[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+\.)*[\w\!\#\$\%\&\'\*\+\-\/\=\?\^\`\{\|\}\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!\.)){0,61}[a-zA-Z0-9]?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\[(?:(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\.){3}(?:[01]?\d{1,2}|2[0-4]\d|25[0-5])\]))$/;

            if (!sEmail1.match(reEmail)) {
                alert("Please Enter Valid Insurer Mail");
                document.getElementById("ctl00_ContentPlaceHolder1_txtemail").focus();
                var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                return 0;
            }

            return 1;

        }

        function doCancel() {

          // $find("ctl00_ContentPlaceHolder1_pnl").hide();
            $find("mdlpopup").hide();
       }

//       function doPopUp() {

//           debugger;
//           $find("mdlpopup").show();
//       }


       function Validate() {
           debugger;
           var strContent = "ctl00_ContentPlaceHolder1_";
          
               if (document.getElementById(strContent + "ddlInsurerType").selectedIndex == 0) {
                   alert('Please Select Insurer Type');
                   document.getElementById(strContent + "ddlInsurerType").focus();
                   var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
                   return false;
                  
               }
          
           if (document.getElementById(strContent + "txtInsurerName").value == "") {

               alert("Please Enter Insurer Name");
               document.getElementById(strContent + "txtInsurerName").focus();
               var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
               return false;
           }



           if (document.getElementById(strContent + "txtInsurerEmail").value == "") {
               alert("Please Enter Insurer Mail");
               document.getElementById(strContent + "txtInsurerEmail").focus();
               var myExtender = $find('ProgressBarModalPopupExtender'); myExtender.hide();
               return false;
           }

           else {


               var emailid = (document.getElementById(strContent + "txtInsurerEmail").value);
               if (validateEmail1(emailid) == 0) {
                   return false;
               }
           }
           
          
           
          }
       
          
    </script>
 
    <asp:ScriptManager ID="sm50HrsSearch" runat="server">
    </asp:ScriptManager>
    <div>

   
        <center>
       
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                     <ContentTemplate>
                        <%--<div id="tbl1" style="border-collapse: separate; left: 0in; position: relative;
                            top: 0px; width: 90%; z-index: 4;" class="tableIsys" runat="server">

                         <div class="panel panel-success " id="divPannel2" runat="server" >
                                <div id="div3" class="panel-body" runat="server" >--%>
                           
                      <%--<div class="panel panel-success PanelInsideTab" id="divPannel1" runat="server" visible="true">--%>
						<div class="card PanelInsideTab" id="divPannel1" runat="server" visible="true">
                            <%--<div class="panel"  style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">--%>      
                           <div class="row" style="text-align:left">
                              
                               <div  style="text-align: left">
                                    <asp:Label ID="lblTitle" runat="server"  CssClass="control-label HeaderColor"  Text="Insurance Company Modification Search"
                                        ></asp:Label>
                                   </div>
                              
                           </div>
                                    <div class="row">
                            <tr id="trInsuranceid1" visible="false" runat="server">
                              
                                <td class="formcontent" align="left" style="width: 20%">
                                    <asp:Label ID="lblInsuranceType" Text="Insurance Type" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="width: 30%" align="left">
                                    <asp:DropDownList ID="ddlInsuranceType" DataTextField="ParamDesc" DataValueField="ParamValue"
                                        runat="server" CssClass="form-control" AutoPostBack="true" TabIndex="11" Width="183px"
                                        OnSelectedIndexChanged="ddlInsuranceType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="formcontent" align="left" style="width: 20%">
                                    <asp:Label ID="lblInsuranceName" Text="Insurance Name" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="width: 30%" align="left">
                                    <asp:DropDownList ID="ddlInsuranceName" DataTextField="ParamDesc" DataValueField="ParamValue"
                                        runat="server" CssClass="standardmenu" AutoPostBack="false" TabIndex="11" Width="183px">
                                       </asp:DropDownList>
                                </td>
                            </tr>
                                        </div>

                            <tr id ="TrRegBranch" runat ="server" visible ="false">
                             
                                 <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="Label2" runat="server" Text="Region Name"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" style="width: 30%">
                                      <asp:DropDownList ID="DdlRegnSrch" DataTextField="ParamDesc" AutoPostBack ="true"   DataValueField="ParamValue"
                                        runat="server" CssClass="standardmenu"  TabIndex="11" Width="183px"  OnSelectedIndexChanged="DdlRegnSrch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                 </td>
                                  <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="Label4" runat="server" Text="Branch Name"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" style="width: 30%">
                                 <asp:DropDownList ID="DdlBrnhSrch"  
                                        runat="server" CssClass="standardmenu" AutoPostBack="false" TabIndex="11" Width="183px">
                                    </asp:DropDownList>
                                  
                                 </td>
                                
                             </tr>

                            <tr id="trInsuranceid2" visible="false" runat="server">
                                
                                <td class="formcontent" align="left" style="height: 24px">
                                    <asp:Label ID="lblEmail" Text="Email" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                                <td class="formcontent" style="height: 24px; width: 243px;" align="left">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="standardtextbox" MaxLength="60"></asp:TextBox>
                                </td>
                                   <td class="formcontent" align="left" style="width: 20%">
                                   
                                </td>
                                <td class="formcontent" style="width: 30%" align="left">
                                  
                                </td>
                            </tr>

<%--                          <br />
                                    <br />--%>
<%--                             <div class="row" style="text-align:left" runat="server" id="trCompApp1" visible="false">                                                            
                                 <div class="col-sm-2" style="text-align: left">                               
                                    <asp:Label ID="lblCndNo" runat="server" Text="Candidate No" Font-Bold="False"></asp:Label>                               
                                     </div>

                                 <div class="col-sm-3" style="text-align: left">                              
                                    <asp:TextBox ID="txtCndNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>                             
                                     </div>

                                 <div class="col-sm-1">

                                 </div>

                                 <div class="col-sm-2" style="text-align: left">                               
                                    <asp:Label ID="lblAppNo" runat="server" Text="Application No" Font-Bold="False"></asp:Label>                               
                                     </div>

                               <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>                          
                                 </div>--%>

<%--                                    <br />--%>
				<div id="trCompApp1" runat="server" class="row rowspacing" visible="false">
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblCndNo" runat="server" Text="Candidate No" Font-Bold="False"></asp:Label>
						<asp:TextBox ID="txtCndNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox> 
					</div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblAppNo" runat="server" Text="Application No" Font-Bold="False"></asp:Label>
						<asp:TextBox ID="txtAppNo" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
					</div>
                    <div class="col-sm-4" style="text-align: left">
                        <asp:Label ID="lblDTRegFrom" runat="server" Text="Registration From" Font-Bold="False" Width="160px"> </asp:Label>  
						<asp:TextBox ID="txtDTRegFrom" runat="server" placeholder="dd/mm/yyyy" onmousedown="fillDte(this.id)" CssClass="form-control" MaxLength="10"></asp:TextBox>						
					</div>
				</div>
				<div id="trCompApp3" runat="server" class="row rowspacing"  visible="false">
                    <div class="col-sm-4" style="text-align: left">
						<asp:Label ID="lblDTRegTO" runat="server" Text="Registration To" Font-Bold="False" Width="136px"></asp:Label>
						<asp:TextBox ID="txtDTRegTo" runat="server" placeholder="dd/mm/yyyy" onmousedown="fillDte(this.id)" CssClass="form-control" MaxLength="10"></asp:TextBox>						
					</div>
                    <div class="col-sm-4" style="text-align: left">
						<asp:Label ID="lblCndName" runat="server" Text="Candidate Name" Font-Bold="False"></asp:Label>
						<asp:TextBox ID="txtCndName" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>						
					</div>
                    <div class="col-sm-4" style="text-align: left">
						<asp:Label ID="lblPan" runat="server" Text="PAN No." Font-Bold="False"></asp:Label>
						<asp:TextBox ID="txtPan" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>					
					</div>
				</div>    
				<div id="trCompApp2" runat="server" class="row rowspacing" visible="false">
                    <div class="col-sm-4" style="text-align: left">

					</div>
				</div>
				<div id="trShw" runat="server" class="row rowspacing">
                    <div class="col-sm-4" style="text-align: left">
						<asp:Label ID="lblShwRecords" Text="Show Records" runat="server" Font-Bold="False"></asp:Label>
                        <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged">
                            <%-- Width="50px">--%>
                       </asp:DropDownList>
					</div>
				</div>							

<%--                             <div class="row" id="trCompApp3" visible="false" runat="server" >
                                   
                                  <div class="col-sm-2" style="text-align: left">
                                        <asp:Label ID="lblDTRegFrom" runat="server" Text="Registration From" Font-Bold="False" Width="160px"> </asp:Label>
									  width changed by shreela on 6/03/14--%>
                                    <%--</div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <uc7:ctlDate ID="txtDTRegFrom" runat="server"  CssClass="form-control" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />
                                    </div>
                                  <div class="col-sm-1" style="text-align: left">

                                  </div>
                                   <div class="col-sm-2" style="text-align: left">
                                        <asp:Label ID="lblDTRegTO" runat="server" Text="Registration To" Font-Bold="False" Width="136px"></asp:Label>
                                    </div>
                                    <div class="col-sm-3" style="text-align: left">
                                        <uc7:ctlDate ID="txtDTRegTo" runat="server"  CssClass="form-control" RequiredField="false"
                                            RequiredValidationMessage="Mandatory!" />
                                    </div>
                                                           
                           </div>--%>
                                    <%--<br />--%>
<%--                                    <div class="row" id="trCompApp2" visible="false" runat="server">
                                                       
                                <div class="col-sm-2" style="text-align: left">
                                    <asp:Label ID="lblCndName" runat="server" Text="Candidate Name" Font-Bold="False"></asp:Label>
                               </div>
                                <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtCndName" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>
                                <div class="col-sm-1" style="text-align: left">

                                </div>

                               <div class="col-sm-2" style="text-align: left">
                                    <asp:Label ID="lblPan" runat="server" Text="PAN No." Font-Bold="False"></asp:Label>
                                </div>
                               <div class="col-sm-3" style="text-align: left">
                                    <asp:TextBox ID="txtPan" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>
                           
                           </div>--%>

                             <%--<br />--%>
<%--                            <div class="row"  id="trShw" runat="server">
                            <tr >
                                <div class="col-sm-2" style="text-align: left">
                                    <asp:Label ID="lblShwRecords" Text="Show Records" runat="server" Font-Bold="False"></asp:Label>
                               </div>
                                <td align="left" class="formcontent" style="height: 21px">
                                    <asp:DropDownList ID="ddlShwRecrds" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlShwRecrds_SelectedIndexChanged"
                                        Width="50px">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" class="formcontent" style="width: 227px; height: 21px">
                                </td>
                                <td align="left" class="formcontent" style="height: 21px">
                                </td>
                            </tr>
                                </div>--%>
                             <br />
                            <tr id="trRecord" runat="server" visible="false" >
                                       
                                        <td  class="formcontent" colspan="4"  style="height: 30px;text-align:center">
                                    <asp:Label ID="lblMessage" Text="0 Record Found"  runat="server" ForeColor="red" Font-Bold="False" visible="false"></asp:Label>
                                </td>
                                    </tr>
                            <tr id="trInsuranceid3" visible="false" runat="server">
                                <td align="center" colspan="4" style="height: 20px">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" OnClick="btnAdd_Click"
                                        TabIndex="43" Text="Add" Width="80px"  />
                                    <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" OnClick="btnSearch_Click"
                                        TabIndex="43" Text="Search" Width="80px" OnClientClick="LdWait(100000)" />
                                    <asp:Button ID="btnClear" runat="server" CssClass="standardbutton" OnClick="btnClear_Click"
                                        TabIndex="43" Text="Clear" Width="80px" />
                                    <div id="divloader" runat="server" style="display: none;">
                                        &nbsp;&nbsp;
                                        <img id="Img1" alt="" src="~/images/spinner.gif" runat="server" />
                                    </div>
                                </td>
                            </tr>                           

                            <div class="row" id="trCompApp4" visible="false" runat="server">
								<div class="col-sm-12" align="center">
                                <%--<div align="center" colspan="4" >--%>
<%--                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"  OnClick="btnSearch_Click"
                                        TabIndex="43" Text="Search" Width="100px" Height="40px" OnClientClick="LdWait(100000)" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-clear" OnClick="btnCancel__Click"
                                        TabIndex="43" Text="Cancel" Width="100px" Height="40px" />--%>

                                <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-success" AutoPostback="false"
                                    OnClick="btnSearch_Click" TabIndex="15" OnClientClick="LdWait(100000)">
                                 <span class="glyphicon glyphicon-search" style='color:White;'></span> SEARCH
                                </asp:LinkButton> 
 
                                <asp:LinkButton ID="btnCancel"   OnClick="btnCancel__Click" CssClass="btn btn-clear"
                                   TabIndex="16" runat="server">
                             CANCEL </asp:LinkButton>
                                    <div id="div1" runat="server" style="display: none;">
                                        &nbsp;&nbsp;
                                        <img id="Img3" alt="" src="~/images/spinner.gif" runat="server" />
                                    </div>
                                <%--</div>--%>
								</div>
                            </div>
                            <br />
                                <br />
                   <%--</div>--%>
                             </div>
                                   
                       <%-- </div>--%>
                       </ContentTemplate>
                       </asp:UpdatePanel>
                       <br/>
                       <br/>
                        
                 
                 <asp:UpdatePanel runat="server">
                     <ContentTemplate>
<%--                      <table id="tdCnf" visible="false" style="border-collapse: separate; left: 0in; position: relative;
                            top: 0px; width: 90%; z-index: 4;" class="tableIsys" runat="server">--%>
                      <div class="card PanelInsideTab" id="tdCnf" runat="server" visible="false">
                           <%-- <div class="panel panel-success PanelInsideTab" id="div2" runat="server" visible="true"> 
                                <div class="panel"  style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%">  --%>
							<div class="row" id="trtitle" runat="server" visible="false">
								<div class="col-sm-10" style="text-align: left">
                           
                                     <asp:Label ID="lblprospectsearch" cssclass="control-label HeaderColor" runat="server" Text="Insurance Company Modification Search"
                                         ></asp:Label>								
								</div>
								<div class="col-sm-2">
 
									<%--<span id="Spntitle" runat="server" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc;
										padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>--%>
                            
									 <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
								</div>
							</div>
<%--                             <tr id="trtitle" runat="server" visible="false">
                                 <td style="border-collapse: separate"  align="left">
                                     <asp:Label ID="lblprospectsearch" cssclass="control-label HeaderColor" runat="server" Text="Insurance Company Modification Search"
                                         ></asp:Label>
                                     <span style="padding-right"></span>
                                 </td>
                                 <td  align="right">
                                     <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
                                 </td>
                             </tr>--%>
						  <div class="row" id="trgridinsurance" runat="server" visible="false">
<%--                             <tr id="trgridinsurance" runat="server" visible="false">--%>
<%--                                 <td colspan="2">--%>
                                     <asp:UpdatePanel ID="UpdPanelAgtDetails" runat="server">
                                         <ContentTemplate>
                                             <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="footable"
                                                 PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                                 RowStyle-CssClass="GridViewRowNew" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                 AllowPaging="True" OnPageIndexChanging="dgView_PageIndexChanging" OnRowCommand="dgView_RowCommand"
                                                 OnSorting="dgView_Sorting" OnRowDataBound="dgView_RowDataBound" Width="100%">
                                                 <Columns>
                                               
                                                     <asp:TemplateField HeaderText="Ins" Visible ="false" >
                                                         <ItemTemplate>
                                                             <asp:Label ID="lblInsId" runat="server" CssClass="sf-formlabel" Text='<%# Bind("InsId") %>'></asp:Label>
                                                         </ItemTemplate>
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <ItemStyle HorizontalAlign="Center" />
                                                     </asp:TemplateField>
                                                     <asp:BoundField SortExpression="InsId" Visible ="false" HeaderText="Insurance Id" DataField="InsId"
                                                         HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>
                                                     <asp:BoundField SortExpression="InsuranceType" HeaderText="Insurance Type" DataField="InsuranceType"
                                                         HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>
                                                     <asp:BoundField SortExpression="Comapny" HeaderText="Comapny Name" DataField="Comapny"
                                                         HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>
                                                     <asp:BoundField SortExpression="Email" HeaderText="Email Id" DataField="Email" Visible ="false" HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>
                                                       <asp:TemplateField HeaderText="Branch Name" >
                                                         <ItemTemplate>
                                                             <asp:Label ID="Branch" runat="server" CssClass="sf-formlabel" Text='<%# Bind("Branch") %>'></asp:Label>
                                                              
                                                         </ItemTemplate>
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <ItemStyle HorizontalAlign="Center" />
                                                     </asp:TemplateField>
                                                     <%-- <asp:BoundField SortExpression="Branch" HeaderText="Branch Name"   DataField="Branch" HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Left" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>--%>
                                                      <asp:BoundField SortExpression="Region" HeaderText="Region Name" DataField="Region" HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>
                                                     <asp:TemplateField SortExpression="Request" HeaderText="">
                                                         <ItemTemplate>
                                                             <div style="white-space: nowrap; width: 100%;">
                                                                 <i class="fa fa-flash"></i>
                                                                 <asp:LinkButton ID="lblEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("InsId") %>'  
                                                                CommandName="EditClick"></asp:LinkButton>
                                                                       <%--OnClick="lblEdit_Click" --%>
                                                             </div>
                                                              <%--<asp:HiddenField ID="HdnBranch" server" Value='<%# Eval("Branch") %>'></asp:HiddenField>--%>
                                                             <%-- <asp:HiddenField ID="hdnDRF" runat="server" Value='<%# Eval("Branch") %>'></asp:HiddenField>--%>
                                                               <%-- <asp:HiddenField ID="hdnMock" runat="server" Value='<%# Eval("Mock") %>'></asp:HiddenField>--%>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField Visible="false">
                                                         <ItemTemplate>
                                                             <div style="white-space: nowrap;  width: 100%;">
                                                                 <i class="fa fa-flash"></i>
                                                                 <asp:LinkButton ID="lblDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("InsId") %>'
                                                                     CommandName="DelClick"></asp:LinkButton>
                                                             </div>
                                                         </ItemTemplate>
                                                         <ItemStyle HorizontalAlign="Center" />
                                                     </asp:TemplateField>
                                                    
                                                 </Columns>
                                                 <RowStyle CssClass="sublinkodd"></RowStyle>
                                                 <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                                 </PagerStyle>
                                                 <HeaderStyle CssClass="portlet blue" ForeColor="black" Font-Bold="true" HorizontalAlign="Center">
                                                 </HeaderStyle>
                                                 <AlternatingRowStyle CssClass="sublinkeven"></AlternatingRowStyle>
                                             </asp:GridView>
                                         </ContentTemplate>
                                         <Triggers>
                                             <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                                         </Triggers>
                                     </asp:UpdatePanel>
<%--                                 </td>--%>
<%--                             </tr>--%>
							  </div>
                          <div class="row" id="trCompDtls"  runat="server" visible="false">
<%--                             <tr id="trCompDtls"  runat="server" visible="false">--%>
<%--                                 <td colspan="2">--%>
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                         <ContentTemplate>
                                             <asp:GridView ID="gvComp" runat="server" AllowSorting="false" 
                                                 CssClass="footable" EnableViewState="true" 
                                                 PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                                 RowStyle-CssClass="GridViewRowNew" HorizontalAlign="Left" AutoGenerateColumns="False"
                                                 AllowPaging="True" OnPageIndexChanging="gvComp_PageIndexChanging"  OnRowCommand="gvComp_RowCommand"
                                                  OnRowDataBound="gvComp_RowDataBound" Width="100%" 
                                                 >
                                             
                                                 <Columns>
                                                  <asp:TemplateField HeaderText="Candidate no"  >
                                                         <ItemTemplate>
                                                             <asp:Label ID="lblCndNo" runat="server" HeaderStyle-ForeColor="black"  Text='<%# Bind("CndNo") %>'></asp:Label>
                                                         </ItemTemplate>
                                                         <HeaderStyle CssClass="gridview th" HorizontalAlign="Left" />
                                                         <ItemStyle CssClass="clsCenter" />
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Application no"  >
                                                         <ItemTemplate>
                                                             <asp:Label ID="lblAppNo" runat="server" CssClass="sf-formlabel" Text='<%# Bind("AppNo") %>'></asp:Label>
                                                         </ItemTemplate>
                                                         <HeaderStyle CssClass="gridview th" HorizontalAlign="Left" />
                                                         <ItemStyle CssClass="clsCenter" />
                                                     </asp:TemplateField>
                                                     <asp:BoundField SortExpression="givenname" HeaderText="Candidate Name"  DataField="givenname"
                                                         HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>
                                                     <asp:BoundField SortExpression="RecruiterName" HeaderText="Recruiter Name"  DataField="Recruiter"
                                                         HeaderStyle-HorizontalAlign="Center">
                                                         <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                                     </asp:BoundField>
                                                    
                                                     <asp:TemplateField >
                                                         <ItemTemplate>
                                                             <div style="white-space: nowrap; width: 100%;">
                                                                 <i class="fa fa-flash"></i>
                                                                 <asp:LinkButton ID="lblCompoDtls" runat="server" Text="Composite Details" CommandArgument='<%# Eval("CndNo") %>' CausesValidation="false"
                                                                     CommandName="CompDtls"></asp:LinkButton>
                                                             </div>
                                                         </ItemTemplate>
                                                         <ItemStyle HorizontalAlign="Center" />
                                                     </asp:TemplateField>
                                                
                                                 </Columns>
                                                 <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                                 <PagerStyle ForeColor="Blue" CssClass="disablepage" HorizontalAlign="Center" Font-Underline="True">
                                                 </PagerStyle>
                                                 <HeaderStyle CssClass="gridview th" ForeColor="black" HorizontalAlign="Center" Font-Bold="true" >
                                                 </HeaderStyle>
                                                 <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                                             </asp:GridView>
                                         </ContentTemplate>
                                         <Triggers>
                                             <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                                         </Triggers>
                                     </asp:UpdatePanel>
                                <%-- </td>--%>
<%--                             </tr>--%>
                              </div>
                             <caption>
                                 

                                 <tr ID="tr1" runat="server" class="formcontent" visible="false">
                                     <td align="center" colspan="4">
                                         <div ID="divloadergrid" runat="server" style="display: none;">
                                             &nbsp;&nbsp;
                                             <img id="Img2" alt="" src="~/images/spinner.gif" runat="server" />
                                             Loading...
                                         </div>
                                     </td>
                                 </tr>
                                 <%-- </td>
        </tr>--%>
                          </caption>
                               <%-- </div>
                                </div>--%>
						  </div>
                         <%--</table>--%>
                     </ContentTemplate>
                 </asp:UpdatePanel>
               
 <%--</table>--%>
        </center>
         
            <asp:UpdatePanel runat="server">
                    <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" Style=" left: 15%; top: 5px; display:none;
                z-index: 1; " Width="60%" Height="100%" >
               <%-- <asp:UpdatePanel runat="server">
                    <ContentTemplate>--%>
                   

                         <table id="Table1" runat="server" class="tableIsys" style="border-collapse: separate; left: 0in; position: relative;
                            top: 0px; width: 100%; z-index: 4;">
                             <tr>
                                 <td align="left"  colspan="4" style="height: 20px;">
                                     <asp:Label ID="Label1" runat="server" CssClass="control-label HeaderColor" Font-Bold="True" 
                                         Text="Insurance Company Modification Search"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="lblInsurenceType" runat="server" Text="Insurance Type"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" style="width: 30%">
                                     <asp:DropDownList ID="ddlInsurerType" runat="server" AutoPostBack="True" 
                                         CssClass="standardmenu" 
                                         OnSelectedIndexChanged="ddlInsurerType_SelectedIndexChanged" TabIndex="11" 
                                         Width="100px">
                                     </asp:DropDownList>
                                 </td>
                                 <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" style="height: 21px">
                                     <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" 
                                         CssClass="standardmenu" Enabled="false" 
                                         OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" TabIndex="11" 
                                         Width="100px">
                                         <asp:ListItem Value="S">--Select--</asp:ListItem>
                                         <asp:ListItem Selected="True" Value="Y">Active</asp:ListItem>
                                         <asp:ListItem Value="N">InActive</asp:ListItem>
                                     </asp:DropDownList>
                                 </td>
                             </tr>
                             <tr>
                              <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="lblInsurerName" runat="server" Text="Insurer Name"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" style="width: 30%">
                                 <asp:DropDownList ID="ddlInsurerName"   Enabled="false" 
                                        runat="server" CssClass="standardmenu" AutoPostBack="false" TabIndex="11" Width="183px"
                                        OnSelectedIndexChanged="ddlInsurerName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%-- <asp:TextBox ID="txtInsurerName" runat="server" CssClass="standardtextbox" 
                                        Enabled="false"></asp:TextBox>--%>
                                 </td>
                                 <td align="left" class="formcontent" style="height: 24px">
                                    
                                 </td>
                                   <td align="left" class="formcontent" style="width: 30%">
                                  </td>
                                 
                                
                             </tr>
                               <tr>
                             
                                 <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="Label3" runat="server" Text="Region Name"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" style="width: 30%">
                                      <asp:DropDownList ID="DdlRgion" DataTextField="ParamDesc" AutoPostBack ="true"  Enabled="false" DataValueField="ParamValue"
                                        runat="server" CssClass="standardmenu"  TabIndex="11" Width="183px"  OnSelectedIndexChanged="DdlRgion_SelectedIndexChanged">
                                    </asp:DropDownList>
                                 </td>
                                  <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="LblBranch" runat="server" Text="Branch Name"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" style="width: 30%">
                                 <asp:DropDownList ID="ddlBranchName"  Enabled="false" 
                                        runat="server" CssClass="standardmenu" AutoPostBack="false" TabIndex="11" Width="183px">
                                    </asp:DropDownList>
                                  
                                 </td>
                                
                             </tr>
                             <tr>
                             <td align="left" class="formcontent" style="height: 24px">
                                     <asp:Label ID="lblInsurerEmailId" runat="server" Text="Insurer Email-ID"></asp:Label>
                                 </td>
                                 <td align="left" class="formcontent" colspan="3" style="width: 30%">
                                     <asp:TextBox ID="txtInsurerEmail"  Rows="4"  TextMode="multiline" Width="400px"  runat="server" CssClass="standardtextbox" 
                                         Enabled="false"></asp:TextBox>
                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="Invalidchars"
                                        Invalidchars=" " TargetControlID="txtInsurerEmail"></ajaxToolkit:FilteredTextBoxExtender>
                                 </td>
                             </tr>
                             <tr>
                             <td align="center" colspan="4">
                              <span style="color: red"> Email id should be added in coma seperated(,)</span>
                              </td>
                              </tr>
                             <tr>  
                             
                            
                                 <td align="center" colspan="4" style="height: 20px">
                            <%--   <asp:UpdatePanel ID="updsve" runat="server">
                               <ContentTemplate>--%>
                                     <asp:Button ID="btnSave" runat="server" CssClass="standardbutton"  OnClientClick="return Validate();" 
                                         OnClick="btnSave_Click" 
                                         Text="Save" Width="80px"/>
                                      <%--   </ContentTemplate>
                                       </asp:UpdatePanel>--%>
                                     <asp:Button ID="btnCancel1" runat="server" CssClass="standardbutton" 
                                       OnClientClick="return doCancel();" Text="Cancel" 
                                         Width="80px" />
                               
                                 </td>
                             </tr>
                               
                         </table>
                       
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                
            </asp:Panel>
         <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="Label1"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="false" OkControlID="btnCancel1" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
    <center>
   
      <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="267px" style="left: 15%; display:none;" Height="126px">
                <table width="100%">
                    <tr align="center">
                        <td width="100%" class="test" colspan="1" style="height: 32px">
                            INFORMATION
                        </td>
                    </tr>
                </table>
                <table>
                </table>
                <center>
                    <br />
                    <asp:Label ID="lblSub" Text="Data saved Successfully" runat="server"></asp:Label></center>
                <br />
                <center>
                     <asp:Button ID="btnokSub" runat="server" Text="OK" Width="81px"  />
                   </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblSub"
                BehaviorID="mdlpopupSub" BackgroundCssClass="modalPopupBg" PopupControlID="pnlSub"
                DropShadow="false" OkControlID="btnokSub" X="350" Y="100">
            </ajaxToolkit:ModalPopupExtender>
            </center>
<%--     ended  by usha --%>
 </ContentTemplate>
      </asp:UpdatePanel> 
                   
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

 
   </div>
    </div>
</asp:Content>
