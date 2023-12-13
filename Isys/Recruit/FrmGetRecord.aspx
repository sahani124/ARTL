<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="FrmGetRecord.aspx.cs" Inherits="Application_INSC_Recruit_FrmGetRecord" MasterPageFile="~/iFrame.master"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
  <link href="../../../Styles/GridStyle.css" rel="Stylesheet" type="text/css" />
  <link href="../../../Styles/main.css" rel="Stylesheet" type="text/css" />
 <%-- <link href="../../../Styles/mainstyle.css" rel="Stylesheet" type="text/css" />--%>
  <link href="../../../Styles/subModal.css" rel="Stylesheet" type="text/css" />
  <script type="text/javascript">
  </script>

<script language="javascript" type="text/javascript">
    function AlertMsgs(msgs) {
        alert(msgs);
    }

    function Restrict() {
        //debugger;
        if (!(event.keyCode == 48 || event.keyCode == 49 || event.keyCode == 50 || event.keyCode == 51 || event.keyCode == 52 || event.keyCode == 53 || event.keyCode == 54 || event.keyCode == 55 || event.keyCode == 56 || event.keyCode == 57)) {
            alert("Only numeric values are allowed");
            event.returnValue = false;
        }
    }
</script>
<asp:ScriptManager ID="SmMstdesign" runat="server">
</asp:ScriptManager>
<center>
<div style="width:800px; text-align:center; ">
   <table class="formtable" style="width:100%; margin-left: 0px;">
        <tr>
           <td class="test" colspan="4" align="left" style="height:20px;">
                <asp:Label ID="lblBatchid" runat="server" Font-Bold="true">BatchID History</asp:Label> 
            </td>
        </tr>
        <tr>
             <td align="center"  colspan="2">
                  <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" CssClass="standardlabelC"></asp:Label>
              </td>
         </tr>
        <tr>
              <td class="formcontent" align="center">
                    <asp:Label ID="lblDwnld" runat="server" Style="color: black">Mode</asp:Label>
              </td>
              <td class="formcontent">
                     <asp:DropDownList ID="ddlDwnld" DataTextField="ParamDesc"  runat="server" CssClass="standardmenu" AutoPostBack="true" 
                             TabIndex="11" Width="400px" OnSelectedIndexChanged="ddlDwnld_SelectedIndexChanged">
                     </asp:DropDownList>
              </td>
         </tr>
        <tr>
              <td class="formcontent">
                    <asp:Label ID="lblUpload" runat="server" Style="color: black">Document Type</asp:Label>
              </td>
              <td class="formcontent">
                    <asp:DropDownList ID="ddlUpload" DataTextField="ParamDesc"  runat="server" CssClass="standardmenu" AutoPostBack="true" 
                            TabIndex="11" Width="400px" OnSelectedIndexChanged="ddlUpload_SelectedIndexChanged">
                    </asp:DropDownList>
              </td>
         </tr>
        <tr>
              <td class="formcontent">
                    <asp:Label ID="lblBatch" runat="server" Style="color: black">BatchId</asp:Label>
              </td>
              <td class="formcontent">
                    <asp:TextBox ID="txtBatch" runat="server" width="397px" CssClass="standardtextbox" 
                            MaxLength="20"  ></asp:TextBox><%--onkeypress="Restrict() OnTextChanged="txtBatch_TextChanged"" --%>
                    <ajaxToolkit:FilteredTextBoxExtender ID="Batch" runat="server"
                        ValidChars="1234567890" FilterMode="ValidChars"
                        TargetControlID="txtBatch" FilterType="Custom">
                    </ajaxToolkit:FilteredTextBoxExtender>
              </td> 
         </tr>
        <tr>
              <td align="center" colspan="2">
               <%--<div class="btn btn-xs btn-primary" style="width:100px;"><i class="fa fa-search"></i>--%>
                  <asp:Button ID="btnSearch" runat="server" CssClass="standardbutton" Text="Search" Width="100px" 
                        OnClick="btnSearch_Click" /><%--</div>--%>&nbsp;
                        <%-- <div class="btn btn-xs btn-primary" style="width:100px;"><i class="fa fa-times"></i>--%>
                  <asp:Button ID="btnCancle" runat="server" CssClass="standardbutton" 
                      Text="Cancle" Width="100px" 
                       onclick="btnCancle_Click" /><%--</div>--%>
              </td>
         </tr>
    </table>
</div>
<div id="divsearch" runat="server" style="width:800px;display:block;">
     <table style="width:100%;">
          <tr id="trdghdr" runat="server" visible="false">
             <td  class="test"  align="left" style="border-collapse: separate; border-right-width: 0;height:20px;" width="85%">
                <asp:Label ID="lblSearch" runat="server" CssClass="standardlabel1"  Font-Bold="true"></asp:Label> 
                <span style="padding-left:300px;"></span>
             </td>
             <td class="test"  align="right" style="border-collapse: separate; border-right-width: 0;height:20px;" width="15%">
                <asp:Label ID="lblPageInfo" runat="server" Visible="False" CssClass="standardlabel1"></asp:Label>
             </td>
          </tr>
          <tr id="trGrid" runat="server" visible="false">
              <td class="formcontent" align="center" colspan="2">
                  <div style="width:800px; overflow-x:scroll;">
                      <asp:GridView ID="dgDownload" runat="server" AutoGenerateColumns="true" PageSize="10"
                          Width="100%" HorizontalAlign="Center" AllowPaging="true"  style="margin-top: 0px" Visible="false"
                          RowStyle-CssClass="sublinkodd" 
                          HeaderStyle-CssClass="portlet blue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center"
                          PagerStyle-ForeColor="blue"  PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="True" PagerStyle-CssClass="pagelink"
                          OnPageIndexChanging="dgDownload_PageIndexChanging">
                      </asp:GridView>
                  </div>
              </td>
          </tr>
          <tr>
              <td colspan="2">
           <%--    <div class="btn btn-xs default" id="divExport" runat="server" visible="false"><i class="fa fa-table"></i>--%>
                  <asp:Button ID="btnExport" runat="server" Cssclass="standardbutton" 
                      Enabled="true" OnClick="btnExport_Click" Text="Export to Excel" Visible="false" 
                      Width="100px" />
                     <%-- </div>--%>
              </td>
           </tr>
     </table>
     <asp:HiddenField ID="hdnAlert" runat="server" />
</div>
</center>
</asp:Content>
