<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopReOpenCFR.aspx.cs" Inherits="Application_ISys_Recruit_PopReOpenCFR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
     <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
<script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-1.10.2.js"
        type="text/javascript"></script>
    <script src="../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
 <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../PSSNEW/Script/COMM/CBFRMCommon.js" type="text/javascript"></script>
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../PSSNEW/Script/COMM/CBFRMCommon.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doCancel() {
            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["mdlpopup"].ToString()%>').style.display = 'none';
    window.parent.document.getElementById("btnReOpenReFresh").click();
        }
        
    </script>
        <asp:ScriptManager ID="scriptMgr" runat="server" />

        <div  style="overflow:auto;"> <%--class="container"--%>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
          <center>
            <div class="card" id="tblMain" runat="server" style="
                display: block; border-radius: 5px; background-color: white; border: solid; width: 80%;
                " cellpadding="0" cellspacing="0" >  <%--border-color: blue; border-width: 2px;--%>
   <%-- <table runat="server" id="tblMain" class="tableIsys">--%>
      <div id="Div1" runat="server" class="panelheadingAliginment">
                    <div class="row" style="text-align: left">
                        <div class="col-sm-10">
                            <asp:Label ID="Label2" runat="server" Font-Bold="False" CssClass="control-label HeaderColor" Font-Size="19px"
                                ></asp:Label>  <%--Font-Size="Small" Height="14px" --%>
                              
                        </div>
                      
                    </div>
                </div>
                 <div id="divDtls" runat="server" class="panel-body" style="display:block">
              <div class="row" style="margin-bottom:5px;">
                    <div class="col-md-3" style="text-align:left">

                        <asp:Label ID="lblDescrptn" runat="server" Text="Enter Description:" CssClass="control-label" ></asp:Label>
                  </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtDescValue" runat="server" Rows="4"  TextMode="multiline"  CssClass="form-control"   ></asp:TextBox>
                  </div>
             </div>
           <div class="row" style="margin-bottom:5px;">
                      <div class="col-md-12" style="text-align:center">
                        <center>
                          <asp:LinkButton ID="BtnSubmit" runat="server"  CssClass="btn btn-success" Text="Submit"
                                    CausesValidation="false" OnClick="BtnSubmit_Click"  >
                              <span class="glyphicon glyphicon-saved BtnGlyphicon"> </span> SUBMIT
                                    </asp:LinkButton>
                          <%--  <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CssClass="standardbutton"
                                Height="16px" Width="123px" OnClick="BtnSubmit_Click" />--%>
                                  <asp:LinkButton ID="btncancel" runat="server"  CssClass="btn btn-clear" Text="Cancel"
                                    CausesValidation="false" OnClientClick="doCancel();return false;" >
                                      <span class="glyphicon glyphicon-remove BtnGlyphicon" style="color:#d32020"> </span> CANCEL
                                    </asp:LinkButton>
                             <%--   <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="standardbutton"
                                Height="16px" Width="123px" OnClientClick="doCancel();return false;" />--%>
                        </center>
                  </div>
           </div>
                </div>
         <%--   </table>--%>
            </div>
        </center>
                  </ContentTemplate>
        </asp:UpdatePanel>
        </div>
</asp:Content>

