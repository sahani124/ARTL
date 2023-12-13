<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="CltEnquiry.aspx.cs"
    Inherits="Application_Common_CltEnquiry" Title="Client Listing" Theme="Isys" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>

<%@ Register Src="~/App_UserControl/Common/txtDate.ascx" TagName="txtDate" TagPrefix="uc2" %>

<%@ Register Src="~/App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="~/Styles/subModal.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="~/Styles/main.css" />

<script type="text/javascript" src="~/Scripts/common.js"></script>
<script type="text/javascript" src="~/Scripts/subModal.js"></script>
<script type="text/javascript" src="~/Scripts/ValidationDefeater.js"></script>
<script language="javascript" type="text/javascript">
var path = "<%=Request.ApplicationPath.ToString()%>";

    function CheckPerTelFormat(src, args)
    {
         var result = true;
         var LocalTel = document.getElementById("<%=txtTelNo.ClientID%>").value.split(",");
         
         strLocalTel = new String(LocalTel)
       
         if (strLocalTel.length > 0)   
         {                 
             if (!IsNumeric(strLocalTel))
             {
                result = false;
             }                 
         }
        
         args.IsValid = result;
    }
    
    function CheckCorpTelFormat(src, args)
    {
         var result = true;
         var LocalTel = document.getElementById("<%=txtCoTelNo.ClientID%>").value.split(",");
         
         strLocalTel = new String(LocalTel)
       
         if (strLocalTel.length > 0)   
         {                 
             if (!IsNumeric(strLocalTel))
             {
                result = false;
             }                 
         }
        
         args.IsValid = result;
    }

    function IsNumeric(sText)
    {
       var ValidChars = "0123456789";
       var IsNumber=true;
       var Char;

     
       for (i = 0; i < sText.length && IsNumber == true; i++) 
          { 
          Char = sText.charAt(i); 
          if (ValidChars.indexOf(Char) == -1) 
             {
             IsNumber = false;
             }
          }
       return IsNumber;
       
       }
</script>    
    
    <div style="height: 20px;
        padding-left: 5px;">
        <asp:Label ID="lblTitle" runat="server" SkinID="Item1" Text="Client Enquiry" BorderStyle="None" Visible="False"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	 <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="False">
        <ProgressTemplate>
            <%--<img class="UpdateProgress1_img" alt="" src="~/App_Themes/Isys/images/spinner.gif" /> Loading ... --%>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </div>
        <table cellpadding="2" align="center" cellspacing="0" width="80%">
        <tr>
            <td align="center">
                <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <table style="width: 100%" id="tbl" class="formtable" cellspacing=1 cellpadding=4 runat="server">
                        <tbody>
                        <tr>
                        <td class="test" colspan=4>
                        <table cellspacing=0 cellpadding=0 width="100%">
                        <tbody>
                        <tr align=left>
                            <td style="height: 14px" align=left colspan=2>
                            <asp:Label id="lblclten" runat="server" Text="Client Enquiry" Font-Bold="True" Width="150px"></asp:Label>
                            </td>
                            <%--<td style="height: 14px" align=right colspan=2>CLTENQ V1.3</td>--%>
                        </tr>
                        </tbody>
                        </table>
                        </td>
                        </tr>
                        <tr>
                        <td class="formcontent" align="left" style="width: 131px">
                            <asp:Label id="lblCltType" runat="server" Text="Client Type" Font-Bold="False" Width="90px"></asp:Label>
                        </td>
                        <td class="formcontent" align="left">
                            <asp:DropDownList id="ddlCltType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCltType_SelectedIndexChanged" CssClass="standardmenu"
                            Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td  class="formcontent" align="left"> 
                         <asp:Label id="lblGCN" runat="server" Text="Customer ID" Font-Bold="False" Width="200px"></asp:Label>
                        </td>
                        <td  class="formcontent" align="left">
                            <asp:TextBox id="txtGCN" runat="server" Width="200px" CssClass="standardtextbox" MaxLength="20"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td class="formcontent" align=left style="width: 131px">
                            <asp:Label ID="lblGivenNm" runat="server" Font-Bold="False" Text="Given Name" 
                                Width="90px"></asp:Label>
                        </td>
                        <td class="formcontent" align=left>
                            <asp:TextBox ID="txtGivenNm" runat="server" CssClass="standardtextbox" 
                                MaxLength="60" Width="195px"></asp:TextBox>
                        </td>
                        <td style="width: 113px" class="formcontent" align=left>
                            <asp:Label id="lblSurname" runat="server" Text="Surname" Font-Bold="False" 
                                Width="120px"></asp:Label>
                        </td>
                        <td style="width: 208px" class="formcontent" align=left>
                            <asp:TextBox ID="txtSurname" runat="server" CssClass="standardtextbox" 
                                MaxLength="60" Width="199px"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td class="formcontent" align=left style="width: 131px">
                            <asp:Label ID="lblDOB" runat="server" Font-Bold="False" Text="Date of Birth" 
                                Width="120px"></asp:Label>
                        </td>
                        <td style="width: 208px" class="formcontent" align=left>
                            <uc3:ctlDate ID="dtpDOB" runat="server" CssClass="standardtextbox" 
                                RequiredField="false" />
                        </td>
                        <td class="formcontent" align=left style="width: 113px">
                            <asp:Label id="lblGender" runat="server" Text="Gender" Font-Bold="False" 
                                Width="90px"></asp:Label> 
                        </td>
                        <td class="formcontent" align=left>
                            <asp:DropDownList ID="ddlGender" runat="server" style="width: 131px" CssClass="standardmenu">
                            </asp:DropDownList>
                        </td>
                        </tr>
                        <tr>
                            <td class="formcontent" align="left" style="width: 131px">
                                <asp:Label ID="lblShowRecords" runat="server" Font-Bold="False" 
                                    Text="Show Records" Width="90px"></asp:Label>
                            </td>
                            <td class="formcontent"   align="left" colspan="3">
                                <asp:DropDownList ID="ddlShowRec" runat="server" style="width: 80px" SkinID="DDL1">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="40">40</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            </tr>
                            <tr id="trRow1" runat="server" visible="false"> 
                                <td class="formcontent" align="left" style="width: 131px">
                                    <asp:Label id="lblCoName" runat="server" Text="Company Name" Font-Bold="False" Width="100px"></asp:Label>
                                </td>
                                <td style="WIDTH: 208px" class="formcontent" align="left">
                                    <asp:TextBox id="txtCoName" runat="server" Width="195px" CssClass="standardtextbox" MaxLength="60"></asp:TextBox>
                                </td>
                                <td class="formcontent" style="width: 113px">
                                    <asp:Label id="lblCoRegNo" runat="server" Text="Company Reg. No." Font-Bold="False" Width="120px"></asp:Label> 
                                </td>
                                <td class="formcontent" colspan="1">
                                <asp:TextBox id="txtCoRegNo" runat="server" Width="195px" CssClass="standardtextbox" MaxLength="24"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td class="formcontent" align="left" style="width: 131px">
                                
                                        <asp:Label id="lblCoShowRec" runat="server" Text="Show Records" Font-Bold="False" Width="120px"></asp:Label>
                                
                            </td>
                            <td style="WIDTH: 208px" class="formcontent" align="left" colspan="3">
                                
                                        <asp:DropDownList id="ddlCoShowRec" runat="server" style="width: 80px" SkinID="DDL1">
                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                            <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                            <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                        </asp:DropDownList>
                                
                                </td>                                    
                            </tr>
                            <tr id="trRow" runat="server" visible="false">
                                <td class="formcontent" align="left" style="width: 131px">
                                    <asp:Label ID="lblIDNo" runat="server" Font-Bold="False" Text="ID No." 
                                        Width="120px"></asp:Label>
                                </td>
                                <td class="formcontent" align="left" >
                                    <asp:TextBox ID="txtIDNo" runat="server" CssClass="standardtextbox" 
                                        MaxLength="20" Width="195px"></asp:TextBox>
                                </td>
                                <td class="formcontent" align="left" style="width: 113px">
                                <asp:Label id="lblTelNo" runat="server" Text="Tel No." Font-Bold="False" Width="120px"></asp:Label>
                                </td>
                                <td class="formcontent" align="left">
                                <asp:TextBox id="txtTelNo" runat="server" Width="195px" CssClass="standardtextbox" MaxLength="16"></asp:TextBox>
                                <asp:CustomValidator id="ctvTelNo" runat="server" ClientValidationFunction="CheckPerTelFormat" ControlToValidate="txtTelNo" Display="Dynamic" ErrorMessage="Invalid Tel No!" SetFocusOnError="True">
                                </asp:CustomValidator>
                                </td>
                            </tr>
                            
                             <tr id="trRow2" runat="server" visible="false">
                                    <td class="formcontent" style="width: 131px">
                                        <asp:Label ID="lblIDType" runat="server" Font-Bold="False" Text="ID Type" 
                                            Width="90px"></asp:Label>
                                    </td>
                                    <td class="formcontent">
                                <asp:DropDownList ID="ddlIdType" style="width: 131px" runat="server" CssClass="standardmenu">
                                </asp:DropDownList>
                                    </td>
                                    <td style="WIDTH: 113px" class="formcontent" align=left>
                                    <asp:Label id="lblCoTelNo" runat="server" Text="Tel No." Font-Bold="False" Width="100px"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 208px" class="formcontent" align=left>
                                        <asp:TextBox id="txtCoTelNo" runat="server" Width="195px" CssClass="standardtextbox" MaxLength="16"></asp:TextBox>
                                        <asp:CustomValidator id="ctvCoTelNo" runat="server" ClientValidationFunction="CheckCorpTelFormat" ControlToValidate="txtCoTelNo" Display="Dynamic" ErrorMessage="Invalid Tel No!" SetFocusOnError="True">
                                        </asp:CustomValidator>
                                    </td>
                               </tr>
                               <tr>
                                    <td class="formcontent2" align="center" colspan="4">
                                        <asp:Button id="BtnSearch" onclick="BtnSearch_Click" runat="server" Text="Search" Width="59px" CssClass="standardbutton"></asp:Button>
                                        <asp:Button id="btnClear" onclick="btnClear_Click" runat="server" Text="Clear" Width="59px" CssClass="standardbutton" CausesValidation="false"></asp:Button>
                                        <asp:Button id="btnAddNewAgt" runat="server" Text="Add New Agent" Width="130px" 
                                            CssClass="standardbutton" CausesValidation="false" onclick="btnAddNewAgt_Click"></asp:Button>
                                    </td>
                               </tr>
                             </tbody>
                           </table>
                   <%-- </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlCltType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
            <tr>
                <td align="center">
                   
                            <asp:Label ID="lblNoRecord" runat="server" ForeColor="red" ></asp:Label>
                       
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                            <ContentTemplate>                                      
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" RowStyle-CssClass="formtable" 
                                    OnSorting="GridView1_Sorting" Width="100%" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" AutoGenerateColumns="False">
                                    <Columns>                          
                                        <asp:TemplateField SortExpression="GCN" HeaderText="Customer ID" >
                                            <ItemTemplate>                                    
                                                <asp:LinkButton ID="lblEdit" runat="server" CssClass="L1" OnCommand="EditPage" CommandName='<%# Bind("CltType") %>' CommandArgument='<%# Bind("GCN") %>' Text='<%# Bind("GCN") %>' ></asp:LinkButton> 
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>                                    
                                        <asp:BoundField DataField="FullName" HeaderText="Name" SortExpression="FullName" >
                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GenderDsc" HeaderText="Gender" ReadOnly="True" SortExpression="GenderDsc" >
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataFormatString="{0:d}" HtmlEncode="False" DataField="DateKey" HeaderText="Date of Birth" SortExpression="DateKey" >
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>                            
                                        <asp:BoundField DataField="IdTypeDsc" HeaderText="Id Type" ReadOnly="True" SortExpression="IdTypeDsc" >
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Id" HeaderText="Id No." ReadOnly="True" SortExpression="Id" >
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HomeTel" HeaderText="Home Tel" ReadOnly="True" SortExpression="HomeTel" >
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="WorkTel" HeaderText="Work Tel" ReadOnly="True" SortExpression="WorkTel" >
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="WorkTel" HeaderText="Home Tel" ReadOnly="True" SortExpression="HomeTel" >
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HomeTel" HeaderText="Work Tel" ReadOnly="True" SortExpression="WorkTel" >
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ExtSrcDsc" HeaderText="Back End" SortExpression="ExtSrcDsc" >
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>                            
                                        <asp:BoundField DataField="ExtClientCode" HeaderText="Client Code" SortExpression="ExtClientCode" >
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>                     
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkMapClt" runat="server" Width="60px" 
                                                    OnClick="lnkMapClt_Click">Map Client</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="test" /> <%--changed by rachana on 09-07-2013 for applying css to GRID--%>
                                    <PagerStyle CssClass="pagelink" />
                                    <RowStyle CssClass="sublinkodd"></RowStyle>
                                    <AlternatingRowStyle CssClass="sublinkeven" ></AlternatingRowStyle>
                                </asp:GridView>
                            </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>&nbsp; &nbsp;&nbsp;<br />
                </td>
            </tr>
        </table>
     
</asp:Content>