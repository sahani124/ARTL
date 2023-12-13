<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DuplicateCltRecords.aspx.cs" Inherits="Application_Common_DuplicateCltRecords" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Duplicate Client Records</title>
<link href="~/Styles/style.css" type="text/css" rel="Stylesheet" />
    <link href="~/Styles/main.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doSelect(strName, strGCN, strAddress, strGender, strDOB, strFatherName, strPinCode)
        {
			
            window.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtGCN').value = strGCN;
            window.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtCltCode').value = strGCN;
            window.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnClientCode').value = strGCN;
           
//            window.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtDOB_txtDate').value = doEncodeToParent(strDOB);
//            //window.parent.document.getElementById('ctl00_ContentPlaceHolder1_cboGender').value = doEncodeToParent(strGender);
//            window.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtSurname').value = doEncodeToParent(strFatherName);
//            window.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtPinP').value = doEncodeToParent(strPinCode);
            
            window.parent.window.hidePopWin(false);
            return false;
        }

        function doCancel()
        {
            window.parent.window.hidePopWin(false);
        }
    </script>
</head>
<body><center>
    <form id="form1" runat="server">
    <div style="text-align: center">
    <table width="80%" class="formtable2">
        <tr>
            <td rowspan="3" align="center" class="formcontent" style="width: 100%">
                <table style="border-collapse: separate; left: -0.02in; position: relative; width: 100%;" class="formtable2">
                    <tr>
                        <td class="test" colspan="3" style="height: 21px" align="left">
                            Details</td>
                        <td align="right" style="border-collapse: separate;" class="test"><asp:Label ID="lblPageInfo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="formcontent" colspan="4" style="height: 21px">
                            <asp:GridView ID="dgDetails" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left"
                                Width="761px" RowStyle-CssClass="formtable" PagerStyle-ForeColor="blue" PagerStyle-Font-Underline="true" 
                                PagerStyle-HorizontalAlign="Center" AllowPaging="True" AllowSorting="True" OnRowDataBound="dgDetails_RowDataBound"  >
                                <Columns>                                    
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkAgntCode" runat="server" Text="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CLTNAME" HeaderText="Name" />
                                    <asp:BoundField DataField="CLTNUM" HeaderText="Number" />
                                    <asp:BoundField DataField="CLTADD" HeaderText="Address" />
                                    <asp:BoundField DataField="CLTSEX" HeaderText="Gender" />
                                    <asp:BoundField DataField="CLTDOBDATE" HeaderText="DOB" />
                                    <asp:BoundField DataField="CLTFATHERNAME" HeaderText="Father Name" />
                                    <asp:BoundField DataField="CLTPINCODE" HeaderText="Pin Code" />
                                    <asp:BoundField DataField="CLTDOBMONTH" HeaderText="CLTDOBMONTH" Visible="true" />
                                    <asp:BoundField DataField="CLTDOBYEAR" HeaderText="CLTDOBYEAR" Visible="true"/>
                                    
                                </Columns>
                                <EditRowStyle Font-Names="verdana" />
                                <AlternatingRowStyle CssClass="sublinkeven" ></AlternatingRowStyle>
                                <RowStyle CssClass="sublinkodd" HorizontalAlign="Center"></RowStyle>
                                <HeaderStyle CssClass="formlink" HorizontalAlign="Center" />
                                <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="formcontent" colspan="4"><asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label></td>
                    </tr>
                 </table>
            </td>
        </tr>
        
    </table>
    </div>
    </form></center>
</body>
</html>
