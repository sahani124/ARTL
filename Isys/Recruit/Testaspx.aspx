<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testaspx.aspx.cs" Inherits="Application_Isys_Recruit_Testaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
        <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager runat="server" ID="ScriptManager1">
              </asp:ScriptManager>
         <asp:UpdatePanel ID="Updatepanel5" runat="server">
                        <ContentTemplate>
        <%--panel 1 start--%>
      <div class="panel panel-success " id="divPannel1" runat="server" visible="true">
          Panel 1
      </div> 
        <%--panel 1 END--%>

        <%--panel 2 start--%>
        <div class="panel panel-success " id="divPannel2" runat="server" visible="false">
          Panel 2
      </div> 
         <%--panel 2 END--%>

        <%--panel 3 start--%>
          <div class="panel panel-success " id="divpanel3" runat="server" visible="false">
         Panel 3
      </div> 
        <%--panel 3 END--%>

        <%--panel 4 start--%>
          <div class="panel panel-success " id="divpanel4" runat="server" visible="false">
         Panel 4
      </div> 
        <%--panel 4 END--%>

        <%--panel 5 start--%>
          <div class="panel panel-success " id="divpanel5" runat="server" visible="false">
         Panel 5
      </div> 
            <%--panel 5 END--%>

        <%--panel 6 start--%>
          <div class="panel panel-success " id="divpanel6" runat="server" visible="false">
         Panel 6
      </div> 
        <%--panel 6 END--%>

        <%--panel 7 start--%>
          <div class="panel panel-success " id="divpanel7" runat="server" visible="false">
         Panel 7
      </div> 
          <%--panel 7 END--%>

         <%--panel 8 start--%>
          <div class="panel panel-success " id="divpanel8" runat="server" visible="false">
         Panel 8
      </div> 
          <%--panel 8 END--%>


        <%--buton start--%>
        <div>
            <%--visible 1--%>
            <asp:Button ID="btnPrev1" runat="server" Text="PREVIOUS1" CssClass="standardbutton" Enabled="false" OnClick="btnPrev1_Click"  />
            <asp:Button ID="btnNextPannel1" runat="server" Text="NEXT1" CssClass="standardbutton" OnClick="btnNextPannel1_Click" Visible="true" />
            <asp:Button ID="btnNextPannel2" runat="server" Text="NEXT2" CssClass="standardbutton" OnClick="btnNextPannel2_Click" Visible="false"  />
            <%--visible 1--%>

            <%--visible 2--%>
            <asp:Button ID="btnPrev2" runat="server" Text="PREVIOUS2" CssClass="standardbutton" Visible="false"  OnClick="btnPrev2_Click"/>
             <asp:Button ID="btnNextPannel3" runat="server" Text="NEXT3" CssClass="standardbutton" OnClick="btnNextPannel3_Click" Visible="false" />    
            <%--visible 2--%>

            <%--visible 3--%>
            <asp:Button ID="btnPrev3" runat="server" Text="PREVIOUS3" CssClass="standardbutton" Visible="false" OnClick="btnPrev3_Click"  />
             <asp:Button ID="btnNextPannel4" runat="server" Text="NEXT4" CssClass="standardbutton" OnClick="btnNextPannel4_Click" Visible="false" /> 
            <%--visible 3--%>

            <%--visible 4--%>
            <asp:Button ID="btnPrev4" runat="server" Text="PREVIOUS4" CssClass="standardbutton" Visible="false"  OnClick="btnPrev4_Click"/>
             <asp:Button ID="btnNextPannel5" runat="server" Text="NEXT5" CssClass="standardbutton" OnClick="btnNextPannel5_Click" Visible="false"  />
            <%--visible 4--%>

            <%--visible 5--%>
              <asp:Button ID="btnPrev5" runat="server" Text="PREVIOUS5" CssClass="standardbutton" Visible="false"  OnClick="btnPrev5_Click"/>
             <asp:Button ID="btnNextPannel6" runat="server" Text="NEXT6" CssClass="standardbutton" OnClick="btnNextPannel6_Click" Visible="false" />    
            <%--visible 5--%>
            <asp:Button ID="btnPrev6" runat="server" Text="PREVIOUS6" CssClass="standardbutton" Visible="false"  OnClick="btnPrev6_Click"/>
            <asp:Button ID="btnPreview" runat="server" Text="PREVIEW" CssClass="standardbutton" Visible="false"  OnClick="btnPreview_Click"/>
             <asp:Button ID="btnNextPannel7" runat="server" Text="NEXT7" CssClass="standardbutton" OnClick="btnNextPannel7_Click" Visible="false" />                                                                           
        </div>
         <%--buton END--%>

                            </ContentTemplate>
                    </asp:UpdatePanel>
    </form>
</body>
</html>

