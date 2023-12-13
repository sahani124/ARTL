<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="FrmMstUpldPop.aspx.cs" Inherits="Application_ISys_FrmMstUpldPop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
 <script language="javascript" type="text/javascript">
     function Close() {
         window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
     }
 
 </script>
 <asp:UpdatePanel ID="Up_UpldDocs" runat="server">
    <ContentTemplate>
        <table id="table1" class="container" runat="server" width="80%">
            <tr  id="trSearchDetails" runat="server">
                <td align="center">
                     <table id="tblnew" runat="server" class="tableIsys" style="border-collapse: separate; left: 0in; top: 0px; width:100%;">
               <tr>
                    <td class="test" colspan="4" align="left"  style="height:20px; vertical-align:baseline;">
                        <asp:Label ID="lblnew" runat="server" Text="Upload Documents" Font-Bold="true" Height="10px"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                   <span style="color: Red">
                        <asp:Label ID="lblnewProcess" runat="server" Font-Bold="False" style="color:Black"></asp:Label>*</span>
                    </td>
                    <td class="formcontent" align="center" style="width: 30%">
                        <asp:DropDownList ID="ddlnewprocess" CssClass="standardmenu" runat="server" Width="185px" align="left" BackColor="#FFFFB2" OnSelectedIndexChanged="ddlnewprocess_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                   
                    <td class="formcontent" align="left" style="width: 20%">
                     <span style="color: Red">
                        <asp:Label ID="lblnewcand" runat="server" Font-Bold="false" style="color:Black"></asp:Label>*</span>
                    </td>
                    <td  class="formcontent" align="center" style="width: 30%">
                        <asp:DropDownList ID="ddlnewcand" CssClass="standardmenu" runat="server" Width="185px" align="left" BackColor="#FFFFB2" OnSelectedIndexChanged="ddlnewcand_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                    <span style="color: Red">
                        <asp:Label ID="lblnewStatus" runat="server" Font-Bold="False"  style="color:Black"></asp:Label>*</span>
                    </td>
                    <td class="formcontent" align="center" style="width: 30%">
                        <asp:DropDownList ID="ddlnewStatus" CssClass="standardmenu" runat="server" Width="185px" align="left" BackColor="#FFFFB2"></asp:DropDownList>
                    </td>
                    <td  class="formcontent" runat="server" align="left" style="width:20%">
                    <span style="color: Red">
                        <asp:Label ID="lblmandtry" runat="server" Font-Bold="false" style="color:Black"></asp:Label>*</span>
                    </td>
                    <td  class="formcontent" runat="server" align="left" style="width:30%">
                        <asp:DropDownList ID="ddlmamdtry" CssClass="standardmenu" runat="server" Width="185px" align="left" BackColor="#FFFFB2" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td  class="formcontent" runat="server" align="left" style="width:20%">
                     <span style="color: Red">
                          <asp:Label ID="lblModCode" runat="server" Font-Bold="false" style="color:Black"></asp:Label>*</span>  
                    </td>
                     <td  class="formcontent" runat="server" align="center" style="width:30%">
                        <%--<asp:TextBox ID="txtModCode" runat="server" CssClass="standardtextbox" Width="185px" BackColor="#FFFFB2"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlModCode" CssClass="standardmenu" runat="server" Width="185px" align="left" BackColor="#FFFFB2"></asp:DropDownList>
                    </td>
                    <td  class="formcontent" runat="server" align="left" style="width:20%">
                    <span style="color: Red">
                          <asp:Label ID="lblDoc" runat="server" Font-Bold="false" style="color:Black"></asp:Label>*</span>    
                    </td>
                    <td  class="formcontent" runat="server" align="center" style="width:30%">
                       <asp:DropDownList ID="ddlDoc" CssClass="standardmenu" runat="server" Width="185px" align="left" BackColor="#FFFFB2"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="formcontent" align="left" style="width: 20%">
                      <span style="color: Red">
                        <asp:Label ID="lblnewdesc" runat="server" Font-Bold="false" style="color:Black"></asp:Label>*</span>
                    </td>
                    <td  class="formcontent" align="center" style="width: 30%" colspan="4">
                     <asp:TextBox ID="txtnewdesc" CssClass="standardtextbox" runat="server" Width="550px" Height="40px" BackColor="#FFFFB2" ></asp:TextBox>
                    </td>
                </tr>
                <tr id="trIns" runat="server">
                 <td class="formcontent" runat="server" align="left" style="width:20%">
                    <span style="color: Red">
                        <asp:Label ID="lblmximg" runat="server" Font-Bold="false" style="color:Black"></asp:Label>*</span>
                        <asp:Label ID="LblhomeNote" runat="server" Visible="false" Text="(In Kb)" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                    </td>
                    <td  class="formcontent" runat="server" align="center" style="width:30%">
                        <asp:TextBox ID="txtmximg" runat="server" CssClass="standardtextbox" Width="185px" BackColor="#FFFFB2"></asp:TextBox>
                    </td>
                    <td  class="formcontent" align="left" style="width:20%">
                  
                        <asp:Label ID="lblInsType" runat="server" Font-Bold="false" style="color:Black" visible="false"></asp:Label>  <span id="spnins" runat="server" style="color: Red">*</span>   
                    </td>
                    <td class="formcontent" align="left" style="width:30%">
                        <asp:DropDownList ID="ddlInsType" CssClass="standardmenu" runat="server" Width="185px" align="left" BackColor="#FFFFB2" Visible="false"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td colspan="4" align="center" style="height: 20px">
                         <asp:Button ID="btnAdd" runat="server" CssClass="standardbutton" TabIndex="43"
                                Text="ADD" Width="114px" OnClick="btnAdd_Click" />
                  
                          <asp:Button ID="btnCancel" runat="server" CssClass="standardbutton" TabIndex="43"
                            Text="Cancel" Width="114px" OnClientClick="Close()" />
                             <asp:HiddenField ID="hdnCrtDtim" runat="server" />
                    </td>
                </tr>
               </table>
               </td>
               </tr>
               </table>
              </ContentTemplate>
              </asp:UpdatePanel>
 <asp:Panel ID="pnlSub" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="321px" Height="200px">
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
            <asp:Label ID="lblSub" Text="Record Added Successfully" runat="server"></asp:Label></center>
        <br />
        
        <center>
            <asp:Button ID="btnokSub" runat="server" Text="OK" Width="81px" OnClientClick="Close()" />
            </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopupSub" runat="server" TargetControlID="lblSub"
        BehaviorID="mdlpopupSub" BackgroundCssClass="modalPopupBg" PopupControlID="pnlSub"
        DropShadow="true" OkControlID="btnokSub" X="300" Y="100">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

