<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/iFrame.master" Title="Untitled Page"
    CodeFile="CompositeApproval.aspx.cs" Inherits="Application_ISys_Recruit_CompositeApproval" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <script type="text/javascript">
     function doCancel() {

          // $find("ctl00_ContentPlaceHolder1_pnl").hide();
            $find("mdlpopup").hide();
       }
    </script>
    <asp:ScriptManager ID="sm50HrsSearch" runat="server">
    </asp:ScriptManager>
    <div>
        <center>
           <%-- <table runat="server" id="tbltest" style="width: 90%" class="tableIsys">--%>
            <%--<div class="row" runat="server" id="tbltest">--%>
                <div class="row"  id="tdPop" runat="server" visible="false" align="center">                   
                        <asp:Label ID="lblMessage" runat="server" Text ="Document Submitted Successfully" Visible="false" ForeColor="red"></asp:Label>
                        <asp:Label ID="lblSuccessMsg" runat="server" Visible="false" ForeColor="red"></asp:Label>                   
               </div>

                
<%--                   <div class="row" style="text-align:left">
                        <asp:Label ID="lblTitle" runat="server" cssclass="control-label HeaderColor" Text="Candidate Details" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                  </div>--%>
            <div class="card PanelInsideTab" id="Div1cd" >
                <div class="panelheadingAliginment" >
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                           
                            <asp:Label ID="lblTitle" runat="server" CssClass="control-label HeaderColor" Text="Candidate Details"></asp:Label>
                        </div>
                        <div class="col-sm-2">
 
                            <%--<span id="Spntitle" runat="server" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc;
                                padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>--%>
                            
                             <span id="Spntitle" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>
                        </div>
                    </div>
                </div>
                <div id="divSearch" runat="server" class="panel-body" style="display: block; margin-top: 0.9%;
                    margin-bottom: 0.9%">
					<div id="trCandidateNo" runat="server" class="row rowspacing">
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblAppNo" runat="server" Font-Bold="False"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblAppNoValue" runat="server" style="font-weight:bold"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							  <asp:Label ID="lblCndName" runat="server" Font-Bold="False"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							  <asp:Label ID="lblAdvNameValue" runat="server" style="font-weight:bold"></asp:Label>
						 </div>					
					</div>
					<div id="Div2" runat="server" class="row rowspacing">
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblCndNo" runat="server" Font-Bold="False"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblCndNoValue" runat="server" style="font-weight:bold"></asp:Label>
						 </div>
						 <div class="col-sm-6" style="text-align: left">
							  <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
						 </div>				
					</div>
					<div id="trMob" runat="server" class="row rowspacing">
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblmobileno" Text="Mobile No" runat="server" Style="color: Black"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblmobile" runat="server" style="font-weight:bold"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							  <asp:Label ID="Label12" runat="server" Text="PAN No" Font-Bold="False" Style="color: Black"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							  <asp:Label ID="lblpanno" runat="server" style="font-weight:bold"></asp:Label>
						 </div>					
					</div>
					<div id="trBranch" runat="server" class="row rowspacing">
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							 <asp:Label ID="lblBranchValue" runat="server" style="font-weight:bold"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							  <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
						 </div>
						 <div class="col-sm-3" style="text-align: left">
							  <asp:Label ID="lblSMNameValue" runat="server" style="font-weight:bold"></asp:Label>
						 </div>					
					</div>
				</div>
			</div>
                    
<%--                <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblAppNo" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblAppNoValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblCndName" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblAdvNameValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>--%>
<%--                <tr>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblCndNo" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblCndNoValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left" colspan="2">
                        <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" OnClick="lblCndView_Click"></asp:LinkButton>
                    </td>
                </tr>--%>
<%--                <tr id='trMob' runat="server">
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblmobileno" Text="Mobile No" runat="server" Style="color: Black"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblmobile" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="Label12" runat="server" Text="PAN No" Font-Bold="False" Style="color: Black"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblpanno" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>--%>
<%--                <tr id="trBranch" runat="server">
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblBranch" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblBranchValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 20px" class="formcontent" align="left">
                        <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>--%>
           <%--</div>--%>
            <div class="card PanelInsideTab" runat="server" id="divMail" >
                <div id="tblMail" class="panelheadingAliginment" >
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">
                           
                         <asp:Label ID="lblMailTitle" cssclass="control-label HeaderColor" runat="server" Text="Mail Details"></asp:Label>
                            <span style="padding-right"></span>
                        </div>
                        <div class="col-sm-2">
 
                            <%--<span id="Spntitle" runat="server" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc;
                                padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>--%>
                            
                             <span id="Spntitle1" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>
                        </div>
                    </div>
                </div>
                <div id="div3" runat="server" class="panel-body" style="display: block; margin-top: 0.9%;
                    margin-bottom: 0.9%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvMail" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="gvMail_PageIndexChanging"
                                        OnRowDataBound="gvMail_RowDataBound"
                                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                        OnRowCommand="gvMail_RowCommand"  HorizontalAlign="Left"
                                        AutoGenerateColumns="False" AllowPaging="True" Width="100%" PageSize="15">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No."  HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <span>
                                                        <%#Container.DataItemIndex + 1%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="InsId" Visible="false" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInsId" runat="server" Font-Size="11px" Text='<%#Bind("InsId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Font-Size="11px" Text='<%#Bind("Category") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Insurance name" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIns" runat="server" Font-Size="11px" Text='<%#Bind("InsName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Mail Send To" Visible ="false" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIMailTo" runat="server" Font-Size="11px" Text='<%#Bind("MailTo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"  />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Mail Status" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMailStatus" runat="server" Font-Size="11px" Text='<%#Bind("MailStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkViewDoc" runat="server" Font-Size="11px" Text="View Document"
                                                        CommandName="Document" CommandArgument='<%#Eval("DocCode") + "," +Eval("DocType")%>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkViewEmail" runat="server" CommandName="Email" CommandArgument='<%#Eval("MailRefNo") + "," +Eval("InsId")%>'
                                                        Font-Size="11px" Text="View Mail"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Button ID="lnkResendmail" runat="server" CommandName="ReSend" CommandArgument='<%#Eval("MailRefNo") + ","+Eval("InsId")%>' Font-Size="11px" Text="Resend Mail"></asp:Button>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
				</div>
			</div>
            
<%--            <div id="divMail" runat="server">
             <table id="tblMail" runat="server" class="tableIsys" align="center" style="width: 90%;">
                  <tr id="trMailTitle" runat="server">
                        <td style="border-collapse: separate"  align="left">
                            <asp:Label ID="lblMailTitle" cssclass="control-label HeaderColor" runat="server" Text="Mail Details"
                                Font-Bold="true" Font-Size="Small"></asp:Label>
                            <span style="padding-right"></span>
                        </td>
                        
                    </tr>
                    </table>
                <table style="width: 90%" class="tableIsys">
                    <tr>
                        <td style="width: 70%; height: 95%;" class="formcontent">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvMail" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="gvMail_PageIndexChanging"
                                        OnRowDataBound="gvMail_RowDataBound"
                                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                        OnRowCommand="gvMail_RowCommand"  HorizontalAlign="Left"
                                        AutoGenerateColumns="False" AllowPaging="True" Width="100%" PageSize="15">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No."  HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <span>
                                                        <%#Container.DataItemIndex + 1%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="InsId" Visible="false" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInsId" runat="server" Font-Size="11px" Text='<%#Bind("InsId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Font-Size="11px" Text='<%#Bind("Category") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Insurance name" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIns" runat="server" Font-Size="11px" Text='<%#Bind("InsName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Mail Send To" Visible ="false" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIMailTo" runat="server" Font-Size="11px" Text='<%#Bind("MailTo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"  />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Mail Status" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMailStatus" runat="server" Font-Size="11px" Text='<%#Bind("MailStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkViewDoc" runat="server" Font-Size="11px" Text="View Document"
                                                        CommandName="Document" CommandArgument='<%#Eval("DocCode") + "," +Eval("DocType")%>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkViewEmail" runat="server" CommandName="Email" CommandArgument='<%#Eval("MailRefNo") + "," +Eval("InsId")%>'
                                                        Font-Size="11px" Text="View Mail"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Button ID="lnkResendmail" runat="server" CommandName="ReSend" CommandArgument='<%#Eval("MailRefNo") + ","+Eval("InsId")%>' Font-Size="11px" Text="Resend Mail"></asp:Button>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
         

                <%-- <table id="tblMail" runat="server" class="tableIsys" align="center" style="width: 90%;">
                  <tr id="trMailTitle" runat="server">
                        <td style="border-collapse: separate" class="test" align="left">
                            <asp:Label ID="lblMailTitle" runat="server" Text="Mail Details"
                                Font-Bold="true" Font-Size="Small"></asp:Label>
                            <span style="padding-right"></span>
                        </td>
                        
                    </tr>
                    </table>
                     <table class="tableIsys" align="center" style="width: 90%;">
                    <tr>
                      
                         <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblMailTo" runat="server" Text="Mail To :" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblMailToVal" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                       
                    </tr>
                     <tr id="trMailCC" runat="server" visible="false">
                      
                         <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblMailCC" runat="server" Text="Mail CC :" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblMailCCVal" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                       
                    </tr>
                     <tr id="trMailBCC" runat="server" visible="false">
                      
                         <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblMailBCC" runat="server" Text="Mail BCC :" Font-Bold="false"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblMailBCCVal" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                       
                    </tr>
                     <tr>
                      
                         <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject :" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSubjectVal" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                       
                    </tr>
                     <tr>
                                    <td style="text-align: center;" colspan="3">
                                        <table cellspacing="8px">
                                            <tr id="tr1" runat="server">
                                                <td style="height: 20px; padding-right: 10px;" align="center" colspan="2">
                                                    <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Re-Send" CssClass="standardbutton"
                                                        Width="100px" OnClientClick="StartProgressBar();"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                     <tr>
                      
                         <td style="width: 20%; height: 20px" class="formcontent" align="left">
                              <hr />
                                                <div id="diviframeContent" runat="server" style="font-family:Arial;font-size:12px;text-align:left;">
                                                </div>
                        </td>
                       
                    </tr>
                </table>--%>

             <div class="card PanelInsideTab" id="div1" runat="server" style="display: flex;" >
                <div id="trdgview" class="panelheadingAliginment" >
                    <div class="row">
                        <div class="col-sm-10" style="text-align: left">     
                            <asp:Label ID="lblUpdDoc" runat="server" cssclass="control-label HeaderColor" Text="Upload Document for Candidate Approval"></asp:Label>
                            <span style="padding-right"></span>
                        </div>
                        <div class="col-sm-2">
 
                            <%--<span id="Spntitle" runat="server" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc;
                                padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>--%>
                            
                             <span id="Spntitle12" class="glyphicon glyphicon-chevron-down" style="float: right; color: #00cccc; 
                                    padding: 1px 10px ! important; font-size: 18px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','Spntitle');return false;"></span>
                        </div>
                    </div>
                </div>
                <div id="div5" runat="server" class="panel-body" style="display: block; margin-top: 0.9%;
                    margin-bottom: 0.9%">
                            <asp:UpdatePanel ID="upddgView" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="dgView_PageIndexChanging"
                                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                        OnRowCommand="dgView_RowCommand" OnRowDataBound="dgView_RowDataBound" HorizontalAlign="Left"
                                        AutoGenerateColumns="False" AllowPaging="True" Width="100%" PageSize="15">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="310px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Upload Documents">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                        <ContentTemplate>
                                                            <asp:FileUpload ID="FileUpload" runat="server" Width="340px"></asp:FileUpload>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_Upload" runat="server" CssClass="btn btn-success" Text="Upload"
                                                                Enabled="false" Visible="false" Width="80px" OnClick="btn_Upload_Click" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_ReUpload" runat="server" CssClass="btn btn-success" Text="ReUpload"
                                                                Width="80px" OnClick="btn_ReUpload_Click" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("DocCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPreview" runat="server" Text="Preview" CommandArgument='<%# Eval("DocCode") %>'
                                                        CommandName="Preview" Font-Size="11px" Style="text-transform: capitalize;">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="disablepage" HorizontalAlign="Center" Font-Underline="True">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="gridview th" ForeColor="black" Font-Bold="true"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <%-- <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="checkedchanged" />--%>
                                </Triggers>
                            </asp:UpdatePanel>
                </div>
			</div>           
<%--            <div id="div1" runat="server" style="display: block;">
                <table id="trdgview" runat="server" class="tableIsys" align="center" style="width: 90%;">
                    <tr id="trtitle" runat="server">
                        <td style="border-collapse: separate"  align="left">
                            <asp:Label ID="lblUpdDoc" runat="server" cssclass="control-label HeaderColor" Text="Upload Document for Candidate Approval"
                                Font-Bold="true" Font-Size="Small"></asp:Label>
                            <span style="padding-right"></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="upddgView" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgView" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="dgView_PageIndexChanging"
                                        PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" RowStyle-CssClass="tableIsys"
                                        OnRowCommand="dgView_RowCommand" OnRowDataBound="dgView_RowDataBound" HorizontalAlign="Left"
                                        AutoGenerateColumns="False" AllowPaging="True" Width="100%" PageSize="15">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Document Name" HeaderStyle-Width="175px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldocName" runat="server" Font-Size="11px" Text='<%#Bind("ImgDesc01") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Document Description" HeaderStyle-Width="310px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldocDescription" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgDesc02") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Max. Size(kb)" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblupdSize" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Upload Documents">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                        <ContentTemplate>
                                                            <asp:FileUpload ID="FileUpload" runat="server" Width="340px"></asp:FileUpload>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU1">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_Upload" runat="server" CssClass="btn btn-success" Text="Upload"
                                                                Enabled="false" Visible="false" Width="80px" OnClick="btn_Upload_Click" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_Upload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Reupd11">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_ReUpload" runat="server" CssClass="btn btn-success" Text="ReUpload"
                                                                Width="80px" OnClick="btn_ReUpload_Click" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_ReUpload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgsize" runat="server" Visible="false" Font-Size="11px" Text='<%#Bind("MaxImgSize") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImgShrt" HeaderStyle-Width="370px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgshrt" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgShortCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Imgwidth" HeaderStyle-Width="370px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgwidth" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgWidth") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImgHeight" HeaderStyle-Width="370px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblimgheight" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("ImgHeight") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManDoc" runat="server" Text='<%#Bind("IsMandatory") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldoccode" runat="server" Font-Size="11px" Style="text-transform: capitalize;"
                                                        Text='<%#Bind("DocCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkPreview" runat="server" Text="Preview" CommandArgument='<%# Eval("DocCode") %>'
                                                        CommandName="Preview" Font-Size="11px" Style="text-transform: capitalize;">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="disablepage" HorizontalAlign="Center" Font-Underline="True">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="gridview th" ForeColor="black" Font-Bold="true"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="GridViewRowNew"></AlternatingRowStyle>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <%-- <asp:AsyncPostBackTrigger ControlID="cbTrfrFlag" EventName="checkedchanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>--%>
                <table>
                    <tbody>
                        <tr id="trBtn" runat="server">
                            <td style="height: 20px; padding-right: 10px;" align="center" colspan="2">
                                <%--<asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Re-Send"
                                CssClass="standardbutton" Width="100px" OnClientClick="StartProgressBar();"></asp:Button>
                                --%>
                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit"
                                    CssClass="btn btn-success" Width="80px" OnClientClick="StartProgressBar();"></asp:Button>
                                <asp:Button ID="btnCancel" TabIndex="43" runat="server" Text="Cancel" CssClass="btn btn-success"
                                    Width="80px" OnClick="btnClear_Click"></asp:Button>
                                <%--<asp:Button ID="btnClear" TabIndex="43" OnClientClick="doCancel()" 
                                runat="server" Text="Cancel"
                                CssClass="standardbutton" Width="80px" onclick="btnClear_Click"></asp:Button>--%>
                            </td>
                        </tr>
                        <%--Added by Nikhil--%>
                        <%--   <tr id="trMail" runat="server" visible="false">
                        <td style="height: 20px;padding-right:10px;" align="center" colspan="2">
                           
                            <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Text="Send Mail Again"
                                CssClass="standardbutton" Width="100px" OnClientClick="StartProgressBar();"></asp:Button>
                                             
                          
                                                                
                            <asp:Button ID="btnCancel" TabIndex="43"  
                                runat="server" Text="Cancel"
                                CssClass="standardbutton" Width="100px" onclick="btnClear_Click"></asp:Button>
                                
                              
                            
                        </td>
                    </tr>--%>
                        <%--Ended by Nikhil--%>
                    </tbody>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnBranchCode" runat="server" />
                            <asp:HiddenField ID="hdnflag" runat="server" />
                            <asp:HiddenField ID="hdnDocCode" runat="server" />
                            <%--//Added by rachana on 02-01-2014 for confirmation of approval--%>
                            <asp:HiddenField ID="hdnDoctype" runat="server" />
                            <asp:HiddenField ID="hdnprevcount" runat="server" />
                            <asp:HiddenField ID="hdnCandTypeRen" runat="server" />
                            <asp:HiddenField ID="hdnInsRenType" runat="server" />
                            <asp:HiddenField ID="hdncompinsren" runat="server" />
                            <%--shree--%>
                            <asp:HiddenField ID="hdnrenwlflag" runat="server" />
                            <%--shree--%>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnStartDate" runat="server" />
                            <asp:HiddenField ID="hdnRenwlCnt" runat="server" />
                            <asp:HiddenField ID="hdnRenwl" runat="server" />
                        </td>
                        <td>
                            <input type="hidden" runat="server" id="hdnUserId" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnBizSrc" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnTrnLoc" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnTrnInst" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnAgnPhoto" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnAgnSign" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnTccID" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnAppNo" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnCndNo" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnSDate" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnStateCode" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnAgnCode" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnbtnVerify" runat="server" />
                            <asp:HiddenField ID="hdnbtnemailVerify" runat="server" />
                            <asp:HiddenField ID="hdnMobileVerify" runat="server" />
                        </td>
                        <!-- Added by ank 12.01.2011-->
                        <td>
                            <asp:HiddenField ID="hdnWebTkn" runat="server" />
                        </td>
                        <!-- Added by Darshik 01.02.2013-->
                        <td>
                            <asp:HiddenField ID="hdnWebTknCon" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnEntryDate" runat="server" />
                        </td>
                        <asp:UpdatePanel ID="updPnlHidden" runat="server">
                            <ContentTemplate>
                                <asp:HiddenField ID="hdnPan" runat="server" />
                                <asp:HiddenField ID="hdnEmail" runat="server" />
                                <asp:HiddenField ID="hdnMobile" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <td>
                            <asp:HiddenField ID="hdnCanid" runat="server" />
                            <asp:HiddenField ID="hdnpath" runat="server" />
                            <asp:Button Text="btnok" ID="btnopen" runat="server" Visible="false" />
                        </td>
                    </tr>
                </table>
<%--            </div>--%>
        </center>
    </div>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
      <asp:Panel ID="pnl" runat="server" Style=" height: 100%;width: 70%;left: 25%;top: 25%;z-index: 100001;position: fixed; overflow:scroll;" >
                      <table style="width: 100%;" class="tableIsys">
                    <tr>
                        <td style="width: 70%; height: 95%;" class="formcontent">
                            <table class="PageText" style="width: 100%; padding-left: 2px; padding-bottom: 2px;
                                padding-right: 2px;" cellspacing="0" cellpadding="2" border="0">
                                <tr>
                                    <td style="height: 17px; width: 100%; background-color: transparent" colspan="3"
                                        align="center">
                                        <asp:Label ID="lblHeader" CssClass="standardlabel" runat="server" Font-Size="11px"
                                            ForeColor="White" Font-Bold="True" Width="100%"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                        <asp:Label ID="lblTo" CssClass="standardlabel" runat="server" Text="To" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="formcontent" colspan="2" style="width: 90%; word-break:break-all">
                                        <asp:Label ID="lblMailToVal" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trMailCC" runat="server" visible="false">
                                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                        <asp:Label ID="lblHiddenCC" CssClass="standardlabel" runat="server" Text="CC" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td class="formcontent" colspan="2" style="width: 90%;">
                                        <asp:Label ID="lblMailCCVal" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trMailBCC" runat="server" visible="false">
                                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                        <asp:Label ID="lblHiddenBcc" CssClass="standardlabel" runat="server" Text="BCC" Font-Bold="True"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                    <td colspan="2" class="formcontent" style="width: 90%;">
                                        <asp:Label ID="lblMailBCCVal" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                              
                                <tr>
                                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                        <asp:Label ID="lblSubject" CssClass="standardlabel" runat="server" Text="Subject"
                                            Font-Bold="True" ForeColor="Black"></asp:Label>
                                    </td>
                                    <td style="width: 90%;" colspan="2" align="left" class="formcontent">
                                        <asp:Label ID="lblSubjectVal" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td style="width: 20%; height: 20px" class="formcontent" align="left">
                                    </td>
                                    <td style="width: 90%;" colspan="2" align="left" class="formcontent">
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td style="text-align: center; width: 100%;" colspan="3">
                                        <table class="divBtnStyle" style="border-collapse: collapse; height: 290px; width: 100%;
                                            background-color: whitesmoke;" bordercolor="white" cellspacing="0" cellpadding="0"
                                            align="center" bgcolor="buttonface" border="1" id="TABLE1">
                                        
                                            <tr>
                                                <td id="mam" style="width: 100%; height: 100%;" colspan="2">
                                                <hr />
                                                <div id="diviframeContent" runat="server" style="font-family:Arial;font-size:12px;text-align:left;">
                                                </div>
                                                  <%--  <iframe id="NewsBody_rich" src="iframetext.aspx?CndNo=30026413" style="font-family: Arial; font-size: 8px;
                                                        width: 100%; height: 100%; overflow: scroll;" runat="server"></iframe>--%>
                                                </td>
                                            </tr>
                                       
                                        </table>
                                    </td>
                                </tr>
                                    <tr >
                                    <td style="text-align: center;" colspan="3">
                                        <table cellspacing="8px">
                                            <tr id="tr1" runat="server">
                                                <td style="height: 20px; padding-right: 10px;" align="center" colspan="2">
                                                    <asp:Button ID="btnSend" OnClick="btnSend_Click" Visible="false" runat="server" Text="Re-Send" CssClass="standardbutton"
                                                        Width="100px" OnClientClick="StartProgressBar();"></asp:Button>
                                                          <asp:Button ID="btnCancel1" runat="server" CssClass="standardbutton" 
                                       OnClientClick="return doCancel();" Text="Cancel" 
                                         Width="80px" />
                               
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    
                    </tr>
                </table>
            </asp:Panel>
         <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblSubject"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="false" X="255" Y="10" CancelControlID="btnCancel1">
    </ajaxToolkit:ModalPopupExtender>
     <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

       <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" style="display:none;"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="266px">
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
            <asp:Label ID="lblSub" runat="server"></asp:Label></center>
        <br />
        <center>
            <asp:Button ID="btnokSub" runat="server" Text="OK" Width="81px" OnClientClick="CloseSub()"  />
            <%--<asp:Button ID="btnok" runat="server" Text="OK" Width="81px"/>--%></center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblSub"
        BehaviorID="mdlpopupSub" BackgroundCssClass="modalPopupBg" PopupControlID="pnlSub"
        DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
      </ContentTemplate>
    </asp:UpdatePanel>
  

</asp:Content>
