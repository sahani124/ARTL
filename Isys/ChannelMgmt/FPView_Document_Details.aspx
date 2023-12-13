<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="FPView_Document_Details.aspx.cs" Inherits="Application_INSC_ChannelMgmt_FPView_Document_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript">
        function doCancel() {

            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            $find("MdlPopRaiseSub").hide();
        }

             
    </script>
   <link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js" type="text/javascript"></script>
    <script src="jquery-1.7.1.min.js" type="text/javascript"></script>
   
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    
    <script language="javascript" type="text/javascript">
        function ShowReqDtl(divId, btnId, img) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            $(document.getElementById(strContent + divId)).slideToggle();
            if ($(img).attr('src') == "../../../assets/img/portlet-collapse-icon-white.png") {
                $(img).attr('src', '../../../assets/img/portlet-expand-icon-white.png');
            }
            else {
                $(img).attr('src', '../../../assets/img/portlet-collapse-icon-white.png')
            }
        }
        function doCancel() {

            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            $find("mdlViewBID").hide();
        }

             
    </script>
    <script language="javascript" type="text/javascript">

        var strContent = "ctl00_ContentPlaceHolder1_";
        form1.onload = function () {
            zoom(1)
        }
        function zoom(zm) {

            img = document.getElementById(strContent + "imgbnd");
            wid = img.width
            ht = img.height
            img.style.width = (wid * zm) + "px"
            img.style.height = (ht * zm) + "px"

            if ((img.style.width >= '322.2' + 'px')) {
                document.getElementById("btnp").disabled = true;
            }
            else {
                if (document.getElementById("btnp").disabled = true) {
                    document.getElementById("btnp").disabled = false;
                }
            }

            if ((img.style.width <= '108' + 'px')) {
                document.getElementById("btnm").disabled = true;
            }
            else {
                if (document.getElementById("btnm").disabled = true) {
                    document.getElementById("btnm").disabled = false;
                }
                else
                { document.getElementById("btnm").disabled = true; }
            }
        }

      
    </script>
    <script language="javascript" type="text/javascript">
        var degrees = 0;
        function brnrotatep() {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";

            if (degrees == 0) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 90) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image180");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 180) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image270");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 270) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image360");
                degrees += 90;
                return degrees;
            }

            else if (degrees == 360) {

                degrees = 0;
                return degrees;
            }
        }

    </script>
    <script language="javascript" type="text/javascript">
        var degrees = 0;
        function brnrotatem() {
            debugger;

            var strContent = "ctl00_ContentPlaceHolder1_";

            if (degrees == 0) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image360");
                degrees = 360;
                return degrees;
            }

            else if (degrees == 360) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image270");
                degrees = 270;
                return degrees;
            }

            else if (degrees == 270) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image180");
                degrees = 180;
                return degrees;
            }

            else if (degrees == 180) {
                var img = document.getElementById(strContent + "imgbnd");
                img.setAttribute("class", "rotated-image");
                degrees = 90;
                return degrees;
            }

            else if (degrees == 90) {
                //       img.setAttribute("class", "rotated-image");
                degrees = 0;
                return degrees;
            }
            //            else if (degrees == 90) {
            //                img.setAttribute("class", "rotated-imag");
            //                degrees = 90;
            //                return degrees;
            //            }
        }

    </script>
    <style type="text/css">
        .rotated-image
        {
            -webkit-transform: rotate(90deg);
            transform: rotate(90deg);
        }
        
        .rotated-image180
        {
            -webkit-transform: rotate(180deg);
            transform: rotate(180deg);
        }
        
        .rotated-image270
        {
            -webkit-transform: rotate(270deg);
            transform: rotate(270deg);
        }
        
        .rotated-image360
        {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }
        
        
        
        
        .rotated-image0
        {
            -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
        }
        .new_text_new
        {
            color: #066de7;
        }
        .divBorder
        {
            border: 1px solid #3399ff;
            padding-top: 5px;
            border-top: 0;
            vertical-align: top;
        }
        
        .divBorder1
        {
            border: 1px solid #3399ff;
            border-top: 0;
        }
        .disablepage
        {
            display: none;
        }
        
        .box
        {
            background-color: #efefef;
            padding-left: 5px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <table style="width: 100%">
            <tr>
                <td align="right" colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
        <div id="divSearchDetails" runat="server">
            <table style="width: 90%" class="tableIsys">
                <tbody>
                    <tr>
                        <td class="test" align="left" colspan="4">
                            <asp:Label ID="lblTitle" Text="Online Member Verification" runat="server" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblAppNo" Text="Franchise Code" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblAppNoValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblCndName" Text="Member Name" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblAdvNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <%--Added by rachana on 29-07-2013 for toggle of agent details start--%>
                </tbody>
            </table>
            <table id="Table1" style="width: 90%" runat="server">
                <tr>
                    <td align="left" class="test" colspan="4">
                        <%--//added by pranjali for id on 11-04-2014--%>
                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnUploadDtls"
                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divagndetails','ctl00_ContentPlaceHolder1_btnUploadDtls');" />
                        <asp:Label ID="lblCnddtls" Text="Member Details" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
            <div runat="server" id="divagndetails" style="display: block">
                <%--Added by rachana on 29-07-2013 for toggle of agent details end--%>
                <table runat="server" id="tbltest" style="width: 90%" class="tableIsys">
                    <tr>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblCndNo" Text="Member Code." runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblCndNoValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left" colspan="2">
                            <asp:LinkButton ID="lblCndView" runat="server" Text="View Candidate Details" Visible="false" OnClick="lblCndView_Click"></asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr id="trBranch" runat="server">
                        <%-- commented by pranjali on 27-12-2013--%>
                        <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                        <%-- commented by pranjali on 27-12-2013--%>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranch" Text="Branch Name" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblBranchValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMName" Text="Recruiter Name" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCode" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSalesUnitCodeValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                    <%--<td style="width: 20%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMName" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblSMNameValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <%--<tr>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDate" runat="server" Text="Training Start Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 160px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnStartDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDate" runat="server" Text="Training End Date" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 210px; height: 20px" class="formcontent" align="left">
                            <asp:Label ID="lblTrnEndDateValue" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>--%>
                    <%--commented by pranjali on 27-12-2013--%>
                    <tr id="trRequest" runat="server" style="display:none">
                        <td style="width: 20%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblProcessType" runat="server" Font-Bold="False" Text="Process Type"></asp:Label>
                            <span style="color: #CC0000">*</span>&nbsp;
                        </td>
                        <td style="width: 30%; height: 16px" class="formcontent" align="left">
                            <asp:DropDownList ID="ddlProcessType" runat="server" AutoPostBack="true" CssClass="standardmenu"
                           OnSelectedIndexChanged="ddlprocesstype_selectedindexchanged"     Width="187px" />
                            &nbsp;
                        </td>
                        <td style="width: 20%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblSponsorDt" Text="Sponsor Date" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td style="width: 30%; height: 16px" class="formcontent" align="left">
                            <asp:Label ID="lblSponsorDtValue" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <div id="divnavigate" runat="server" visible="false">
            <table id="tblphoto" runat="server" style="width: 90%;">
                <tr>
                    <td class="formcontent" align="center">
                    </td>
                    <td class="formcontent" align="center">
                        <asp:Button ID="BtnDownload" runat="server" Text="Download" CssClass="standardbutton"
                            Width="100px" OnClick="BtnDownload_Click"></asp:Button>
                    </td>
                    <td class="formcontent" align="center" style="text-align: center">
                        <asp:Button ID="BtnDwnldAll" TabIndex="43" runat="server" Text="Download All" CssClass="standardbutton"
                            Width="100px" OnClick="BtnDwnldAll_Click"></asp:Button>
                    </td>
                    <td class="formcontent" align="center" style="text-align: center">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnprev" runat="server" Text="Prev" CssClass="standardbutton" Width="100px"
                                    OnClick="btnprev_Click"></asp:Button></ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="formcontent" align="right" style="text-align: right">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnnext" runat="server" Text="Next" CssClass="standardbutton" Width="100px"
                                    OnClick="btnnext_Click"></asp:Button></ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panelphoto2" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
            BorderWidth="2px" Width="89%" Visible="true" class="modalpopupmesg" ScrollBars="Vertical">
            <asp:UpdatePanel runat="server" ID="upnlHeader">
                <ContentTemplate>
                    <table class="test" width="100%" cellpadding="0" cellspacing="0" style="height: 5%;">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblpanelheader" runat="server" CssClass="standardlink " />
                                <asp:HiddenField ID="hdnDocId" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <table class="modalpanel" style="display: none">
                        <tr>
                            <td>
                                <asp:Image ID="imgCrop" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <div id="divgrid" runat="server" style="width: 100%; height: 100%; overflow: hidden">
                        <table style="border-collapse: separate; left: 0in; position: relative; top: 0px;
                            width: 100%;" class="tableIsys">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridImage" runat="server" AllowSorting="True" CssClass="tableIsys"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue"
                                        RowStyle-CssClass="tableIsys" HorizontalAlign="Left" AutoGenerateColumns="False"
                                        AllowPaging="True" Width="100%" Height="242px" OnPageIndexChanging="GridImage_PageIndexChanging"
                                        OnRowDataBound="GridImage_RowDataBound">
                                        <Columns>
                                            <%--OnRowDataBound="GridImage_RowDataBound"OnPageIndexChanging="GridImage_PageIndexChanging" <asp:TemplateField SortExpression="DocType" HeaderText="Image Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCndNo" runat="server" Text='<%# Eval("DocType") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField SortExpression="ID" HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("ID") %>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID")  %>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnServerFileName" runat="server" Value='<%# Eval("ServerFileName") %>'>
                                                    </asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField SortExpression="ID" HeaderText="ID">
                                                 <%--<%= String.Format("PDFCSharp.aspx?PDFID=", Eval("ID")); %>"--%>
                                                <ItemTemplate>
                                                     <% if (FileType == "PDF") { %>
                                                       <iframe id="PDFImage" src="FPPDFCSharp.aspx?PDFID=<%# Eval("ID") %>" width="100%" height="350px"></iframe> 
                                                    <% } else { %>
                                                   
                                                    <iframe id="Iframe1" src="FPPDFCSharp.aspx?PDFID=<%# Eval("ID") %>" width="100%" height="350px"></iframe> 
                                                    <% } %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                          

                                        </Columns>
                                        <RowStyle CssClass="sublinkeven" BackColor="#78A8FA"></RowStyle>
                                        <PagerStyle ForeColor="Blue" CssClass="pagelink" HorizontalAlign="Center" Font-Underline="True">
                                        </PagerStyle>
                                        <HeaderStyle CssClass="portlet blue" ForeColor="White" Font-Bold="true"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="sublinkodd" BackColor="#78A8FA"></AlternatingRowStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                       <%-- <table>
                            <tr>
                                <td style="text-align: center; padding-bottom: 10px">
                                    <asp:Button ID="btnedit" runat="server" Text="Edit Image" CssClass="btn blue" OnClick="btnedit_Click" />
                                    <%--OnClick="btnedit_Click"--%>
                              <%--  </td>
                            </tr>
                        </table>--%>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <iframe id="FrmImg" runat="server" visible="false" width="100%" height="500px"></iframe>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnnext" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <div id="SeaCan" runat="server">
            <table style="width: 90%">
                <tbody>
                    <tr>
                    
                        <td style="height: 20px; padding-top: 10px" align="center"  class="formcontent">
                                  &nbsp;&nbsp;
                                 <asp:Button ID="btnedit" runat="server" Text="Edit Image" Visible="false" OnClick="btnedit_Click" 
                           CssClass="standardbutton" Width="80px"></asp:Button>

                            &nbsp;&nbsp;
                            
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="standardbutton"
                                Width="80px" OnClientClick="doCancel();return false;"></asp:Button>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="formcontent2" align="center" colspan="4">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False" CssClass="standardlabelC"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </center>
    <%--Loader popup start--%>
    <ajaxToolkit:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"
        BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"
        TargetControlID="hiddenField1" PopupControlID="Panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hiddenField1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: Grey;">
        <center>
            <img src="../../../App_Themes/Isys/images/spinner.gif" />
            <br />
            <asp:Label ID="waitingMsg" runat="server" Text="Please wait..." ForeColor="red" BackgroundCssClass="modalBackground"></asp:Label>
        </center>
    </asp:Panel>
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hdnCndNo" runat="server" />
            </td>
        </tr>
    </table>
    <%--  new added popup--%>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="75%" Height="100%" Style="display: none;">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px;">
                    <b>
                        <asp:Label runat="server" ID="lbltitle1" Text=""></asp:Label></b>
                </td>
            </tr>
        </table>
        <center>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div id="divimage" runat="server" style="position: fixed; z-index: 3000; padding-left: 250px">
                        <center>
                            <asp:Image ID="imgbnd" runat="server" Height="250px" Width="250px" Style="position: fixed;
                                z-index: 3000;" /><%--Height="200px" Width="250px"--%>
                        </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
        <center>
            <div style="position: fixed; z-index: 3000; text-align: center; padding-top: 350px;
                padding-left: 265px;">
                <asp:Label ID="lblpopup" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="-" onclick="zoom(0.9)" id="btnm" name="btnm"  />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="+" onclick="zoom(1.1)" id="btnp" name="btnp"  />&nbsp;&nbsp;&nbsp;&nbsp;
     <%--           <input type="button"  id="btnrp1" name="btnrp" onclick="brnrotatep()"/>--%>
                 <img src="../../../theme/iflow/aa.png" height="22px" width="22px"  id="btnrp" name="btnrp" onclick="brnrotatep()"/> <%--</button>--%><%--value="Rotate+"--%>
         <%--       <input type="button"  id="btnrm" name="btnrm" onclick="brnrotatem()" /> --%>
         &nbsp;&nbsp;&nbsp;&nbsp;

                
                <img  src="../../../theme/iflow/bb.png" height="22px" width="22px"  id="btnrm" name="btnrm" onclick="brnrotatem()"/> 
                
                <%--value="Rotate-"--%>
                <div style="padding-top: 10px;">
                   &nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;    <asp:Button ID="btnok" runat="server" Text="Cancel" Width="100px"  Height="25px" CssClass="standardbutton" />&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
            </div>
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblpopup"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        OkControlID="btnok">
    </ajaxToolkit:ModalPopupExtender>
   
</asp:Content>
