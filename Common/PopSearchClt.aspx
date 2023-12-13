<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopSearchClt.aspx.cs" Inherits="Application_Common_PopSearchClt" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="txtDate" TagPrefix="uc5" %>
<%@ Register Src="~/App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup"
    TagPrefix="uc4" %>
<%@ Register Src="~/App_UserControl/Common/ddlSelectedLookup.ascx" TagName="ddlSelectedLookup"
    TagPrefix="uc3" %>
<%@ Register Src="~/App_UserControl/Common/txtDate2.ascx" TagName="txtDate" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" src="~/Scripts/formatting.js"></script>

<script language="javascript" type="text/javascript">
function doSelect(args1, args2, args3)
{
    window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').disabled = false;
    window.parent.document.getElementById('<%=Request.QueryString["Field1"].ToString()%>').value = doEncodeToParent(args1);
    window.parent.document.getElementById('<%=Request.QueryString["Field4"].ToString()%>').value = doEncodeToParent(args2);
    window.parent.document.getElementById('<%=Request.QueryString["Field5"].ToString()%>').value = doEncodeToParent(args3); 
    window.parent.WriteFlag();   
    window.parent.Test(args1);
    window.parent.window.hidePopWin(false);     
    return false;    
}

function doClear()
{
    document.getElementById("<%=txtGCN.ClientID%>").value = "";
    document.getElementById("<%=txtSurname.ClientID%>").value = "";
    document.getElementById("<%=txtGivenName.ClientID%>").value = "";
    document.getElementById("<%=cboGender.ClientID%>" + "_ddliSysLookupParam").value = "";
    document.getElementById("<%=txtDOB.ClientID%>" + "_txtDate").value = "";
    document.getElementById("<%=txtIDNo.ClientID%>").value = "";
    document.getElementById("<%=cboIdType.ClientID%>" + "_ddliSysLookupParam").value = "";
    document.getElementById("<%=txtTelNo.ClientID%>").value = "";   
}

function doCancel()
{
    window.parent.WriteFlag();
    window.parent.window.hidePopWin(false);
}

function CheckTelFormat(src, args)
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

<head id="Head1" runat="server">
    <title>Personal Client Listing</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="0%" Width="99%" DefaultButton="btnSearch">
                <asp:ScriptManager ID="scriptMgr" EnablePartialRendering="true" runat="server">
                </asp:ScriptManager>
                <table class="formtable" width="100%">
                    <tr>
                        <td class="formcontent">
                            &nbsp;<asp:Label ID="lblGCN" runat="server" Width="80px"></asp:Label></td>
                        <td class="formcontent">
                            <asp:TextBox ID="txtGCN" runat="server" Width="150px" CssClass="standardtextbox" MaxLength="12"></asp:TextBox></td>
                        <td class="formcontent">
                            &nbsp;<asp:Label ID="lblGender" runat="server" Width="50px"></asp:Label></td>
                        <td class="formcontent">
                            <%--<uc4:ddlLookup ID="cboGender" runat="server" CssClass="standardmenu" LookupCode="NBGender" RequiredField="false" Width="150" />--%>
                            <uc3:ddlSelectedLookup ID="cboGender" runat="server" CssClass="standardmenu" LookupCode="NBGender"
                                Exprs="paramValue not in (''C'')" RequiredField="false" Width="150" />
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" width="20%">
                            &nbsp;<asp:Label ID="lblGivenName" runat="server" ></asp:Label></td>
                        <td class="formcontent" width="40%">
                            <asp:TextBox ID="txtGivenName" runat="server" CssClass="standardtextbox" MaxLength="60"></asp:TextBox></td>
                        <td class="formcontent" width="10%">
                            &nbsp;<asp:Label ID="lblSurname" runat="server" ></asp:Label></td>
                        <td class="formcontent" style="width: 40%">
                            <asp:TextBox ID="txtSurname" runat="server" CssClass="standardtextbox" MaxLength="60"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formcontent" width="20%">
                            &nbsp;<asp:Label ID="lblDOB" runat="server" ></asp:Label></td>
                        <td class="formcontent" width="30%">
                            <asp:UpdatePanel ID="UpdPanelDOB" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <uc2:txtDate ID="txtDOB" runat="server" Width="130" CssClass="standardtextbox" ValidationError="Date of Birth is required" />
                                    </td>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <td class="formcontent" width="10%">
                                &nbsp;<asp:Label ID="lblTelNo" runat="server" ></asp:Label></td>
                            <td class="formcontent" style="width: 40%">
                                <asp:TextBox ID="txtTelNo" runat="server" CssClass="standardtextbox" MaxLength="16"></asp:TextBox>
                                <asp:CustomValidator id="ctvTelNo" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Tel No!" Display="Dynamic" ControlToValidate="txtTelNo" ClientValidationFunction="CheckTelFormat"></asp:CustomValidator></td>
                    </tr>
                    <tr>
                        <td class="formcontent" width="20%">
                            &nbsp;<asp:Label ID="lblIDType" runat="server" ></asp:Label></td>
                        <td class="formcontent" width="40%">
                            <uc4:ddlLookup ID="cboIdType" runat="server" CssClass="standardmenu" LookupCode="NBSIDKey"
                                RequiredField="false" />
                        </td>
                        <td class="formcontent" width="10%">
                            &nbsp;<asp:Label ID="lblIDNo" runat="server" ></asp:Label></td>
                        <td class="formcontent" style="width: 40%">
                            <asp:TextBox ID="txtIDNo" runat="server" CssClass="standardtextbox" MaxLength="24"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formcontent" colspan="4" style="text-align: center">
                            <asp:Button CssClass="standardbutton" ID="btnSearch" runat="server" Text="Search"
                                OnClick="btnSearch_Click" />
                            <asp:Button CssClass="standardbutton" ID="btnClear" runat="server" Text="Clear" OnClientClick="doClear();return false;" />
                            <asp:Button CssClass="standardbutton" ID="btnCancel" runat="server" Text="Cancel"
                                OnClientClick="doCancel();return false;" />
                                
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" colspan="4" style="text-align: center">
                            <asp:UpdatePanel id="UpdPnlNoRecord" runat="server">
                                <contenttemplate> 
                                    <asp:Label ID="lblNoRecord" runat="server" ForeColor="red" ></asp:Label>
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                        OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" OnSorting="gv_Sorting"
                                        PageSize="20" Width="100%">
                                        <HeaderStyle CssClass="formlink" />
                                        <AlternatingRowStyle CssClass="sublinkeven" />
                                        <RowStyle CssClass="sublinkodd" />
                                        <PagerStyle CssClass="pagelink" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Customer ID" SortExpression="GCN">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("GCN") %>' Width="50px"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="GivenName" HeaderText="Given Name">
                                                <ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Surname" HeaderText="Surname">
                                                <ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gender" HeaderText="Gender">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataFormatString="{0:dd/MM/yyyy}" DataField="DateKey" HeaderText="Date Of Birth"
                                                HtmlEncode="False">
                                                <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MatchStat" HeaderText="Match Status">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CltTypDsc" HeaderText="Client Type" Visible="false">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gender" Visible="False">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CltType" Visible="False">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
