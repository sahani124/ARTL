<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FPPopReOpenCFR.aspx.cs" MasterPageFile="~/iFrame.master" Inherits="Application_ISys_ChannelMgmt_FPPopReOpenCFR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            window.parent.document.getElementById("btnReOpenReFresh").click();
        }
        
        </script>
    <div class="card PanelInsideTab">
       <div id="Div2" runat="server" class="panelheadingAliginment">
                    <div class="row spacebetnrow">
                           <div class="col-sm-12" style="text-align: left">
                         <asp:Label ID="Label2" runat="server" Text="ReOpen CFR"  CssClass="control-label HeaderColor"></asp:Label>
                 </div>
                         </div>
                    </div>

          <div  id="tblMain" runat="server" class="panel-body panelContent">
              <div class="row rowspacing">
                  <div class="col-sm-4">
                      <asp:Label ID="lblDescrptn" runat="server" Text="Enter Description:" CssClass="control-label"
                        ></asp:Label>
                  </div>
                  <div class="col-sm-8">
                      <asp:TextBox ID="txtDescValue" runat="server" Rows="4"  TextMode="multiline"  CssClass="form-control" style="margin-left: -46px;width: 243px;"></asp:TextBox>

                  </div>
              </div>
               <div class="row rowspacing" style="align-items:center;">
                   <div class="col-sm-3">
                       
                     
                   </div>
                       <div class="col-sm-6" style="margin-left:38px;">
                             <%--<asp:Button ID="BtnSubmit" runat="server" Text="SUBMIT" CssClass="btn btn-success"
                              OnClick="BtnSubmit_Click" />--%>

                        <asp:LinkButton  ID="BtnSubmit" runat="server" Text="" CssClass="btn btn-success" OnClick="BtnSubmit_Click"><span class="glyphicon glyphicon-floppy-disk" style="color:white;"></span> SUBMIT</asp:LinkButton> 
    

                        <asp:LinkButton  ID="btncancel" runat="server" Text="" CssClass="btn btn-clear" OnClientClick="doCancel();return false;">   <span class="glyphicon glyphicon-remove" style="color:#f04e5e"> </span> CANCEL</asp:LinkButton> 

                       </div>
                   <div class="col-sm-3">

                       </div>
              </div>
              </div>
    </div>

<table runat="server" class="tableIsys" style="display:none">
            <tr>
                <td align="center" class="test" colspan="6" style="width: 30">
                    
                </td>
            </tr>
            <tr>
                <td class="formcontent" align="left" style="width: 33%">
                    
                </td>
                <td class="formcontent" align="left" colspan="3">
                    
                </td>
            </tr>
        <tr>
                <td align="center" class="style1" colspan="3">
                    <center>
                       
                    </center>
                </td>
            </tr>
        </table>
</asp:Content>