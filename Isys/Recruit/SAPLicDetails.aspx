<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="SAPLicDetails.aspx.cs" Inherits="SAPLicDetails" %>

<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc3" %>


<%@ Register Src="~/App_UserControl/Common/ddlLookup2.ascx" TagName="ddlLookup" TagPrefix="uc4" %>
<%@ Register Src="~/App_UserControl/Common/ddlSelectedLookup.ascx" TagName="ddlSelectedLookup" TagPrefix="uc5" %>
<%@ Register Src="~/App_UserControl/Common/ctlDate.ascx" TagName="ctlDate" TagPrefix="uc7" %>
<%@ Register Src="~/App_UserControl/Common/ddlLookup.ascx" TagName="ddlLookup" TagPrefix="uc8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../../Styles/subModal.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <%--    <script type="text/javascript" src="../../../Scripts/subModal.js"></script>--%>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <script language="javascript" src="../../../Scripts/jsAgtCheck.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var path = "<%=Request.ApplicationPath.ToString()%>";
        var path = "<%=Request.ApplicationPath.ToString()%>";


        function funcMgrShowPopup(strPopUpType, strbzsrc, strsbclass, stragttyp, strrptmgr) {
            if (strPopUpType == "rptmgr") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
        + "&Desc=" + strrptmgr + "&field1=" + document.getElementById('<%=hdnRptMgr.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtRptMgr.ClientID %>').id + "&bizsrc=" + strbzsrc
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp
        + "&field3=" + document.getElementById('<%=lblrptmgr.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            else if (strPopUpType == "rptmgr1") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
        + "&Desc=" + strrptmgr + "&field1=" + document.getElementById('<%=hdnRptMgr.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtRptMgr1.ClientID %>').id + "&bizsrc=" + strbzsrc
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp
        + "&field3=" + document.getElementById('<%=lblrptmgr1.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            else if (strPopUpType == "rptmgr2") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
        + "&Desc=" + strrptmgr + "&field1=" + document.getElementById('<%=hdnRptMgr.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtRptMgr2.ClientID %>').id + "&bizsrc=" + strbzsrc
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp
        + "&field3=" + document.getElementById('<%=lblrptmgr2.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
            else if (strPopUpType == "rptmgr3") {
                $find("mdlViewBID").show();
                document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "PopMgrCode.aspx?Code=" + document.getElementById('<%=hdnRptMgr.ClientID %>').value
        + "&Desc=" + strrptmgr + "&field1=" + document.getElementById('<%=hdnRptMgr.ClientID %>').id
        + "&field2=" + document.getElementById('<%=txtRptMgr3.ClientID %>').id + "&bizsrc=" + strbzsrc
        + "&subchnl=" + strsbclass + "&agttyp=" + stragttyp
        + "&field3=" + document.getElementById('<%=lblrptmgr3.ClientID %>').id + "&mdlpopup=mdlViewBID";
            }
        }

        ///document.getElementById('<%=txtRptMgr.ClientID %>').value

        function ShowReqDtl(divId, btnId) {
            //debugger;
            if (document.getElementById(divId).style.display == "block") {
                document.getElementById(divId).style.display = "none";
                //document.getElementById(divId).value = '+'
                document.getElementById(btnId).value = '+';
            }
            else {
                document.getElementById(divId).style.display = "block";
                //document.getElementById(btnId).value = '-'
                document.getElementById(btnId).value = '-';
            }
        }

        function AssigText(strtext) {
            //debugger;
            if (strtext == "") {
                //document.getElementById("ctl00_ContentPlaceHolder1_tradnmgr").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            if (strtext == "Multiple-1") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            //Modified by swapnesh on 9/12/2013 to hide reporting-manager data based on agent type selection start 
            //        else{
            //        document.getElementById("ctl00_ContentPlaceHolder1_trHeaderadnmgr3").style.display = "none";
            //        document.getElementById("ctl00_ContentPlaceHolder1_tradnmgr3").style.display = "none";
            //        }
            else if (strtext == "Multiple-2") {
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            else if (strtext == "") {
                //document.getElementById("ctl00_ContentPlaceHolder1_tradnmgr").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_tblmgr3").style.display = "none";
            }
            //Modified by swapnesh on 9/12/2013 to hide reporting-manager data based on agent type selection end
            if (strtext == 'empty') {
                document.getElementById("ctl00_ContentPlaceHolder1_tblReportingMngrDtls").style.display = "none";
            }
        }

        function funValidate() {
            var strContent = "ctl00_ContentPlaceHolder1_";

            if (document.getElementById(strContent + "txtSAPcode") != null) {
                if (isEmpty(document.getElementById(strContent + "txtSAPcode").value)) {
                    alert("Please Enter SAP Code");
                    document.getElementById(strContent + "txtSAPcode").focus();
                    return false;
                }
            }
        }

    </script>
    <script language="javascript" type="text/javascript" src="~/Scripts/common.js"></script>
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script language="javascript" type="text/javascript" src="~/Scripts/subModal.js"></script>
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    <scripts>
            <asp:ScriptReference Path="../../../Application/Common/Lookup.js" /> 
        </scripts>
        <services>
            <asp:ServiceReference  Path="../../../Application/Common/Lookup.asmx" />
        </services>
    </asp:ScriptManager>
<center>
<table width="80%" border="0" style="border-collapse: collapse;">
            <tr align="center">
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
  <table width="80%" style="border-collapse: collapse; background-image: url(Images\background.jpg);
            height: 18px;">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr align="left">
                <td align="left">
                    <%--<asp:ImageButton ID="lnkPage1" runat="server" OnClick="lnkPage1_Click" CssClass="TextBox"
                        BackColor="transparent" ImageUrl="~/theme/iflow/Agent_info.gif" />--%>
                    <asp:ImageButton ID="lnkPage1" runat="server" CssClass="TextBox"
                        BackColor="transparent" ImageUrl="~/theme/iflow/Agent.gif" />
                    <%--<asp:ImageButton ID="lnkPage2" runat="server" OnClick="lnkPage2_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false" ImageUrl="~/theme/iflow/education.gif" />
                    <asp:ImageButton ID="lnkPage3" runat="server" OnClick="lnkPage3_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false" ImageUrl="~/theme/iflow/employemnt_history.gif" />
                    <asp:ImageButton ID="lnkPage4" runat="server" OnClick="lnkPage4_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false"  ImageUrl="~/theme/iflow/Disciplinary_Info.gif" />
                    <asp:ImageButton ID="lnkPage5" runat="server" OnClick="lnkPage5_Click" CssClass="TextBox"
                        BackColor="Transparent" Visible="false" CausesValidation="false" ImageUrl="~/theme/iflow/payment_info.gif" />--%>
                </td>
            </tr>
            <tr align="center">
                <td>
                            <table width="100%" class="formtable2">
                                <tr style="height: 20px;">
                                    <td align="left" colspan="8" class="test">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnprsnldtlscollapse"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divpersnldtls','ctl00_ContentPlaceHolder1_btnprsnldtlscollapse');" />
                                        <asp:Label ID="lblPersonalPart" runat="server" Font-Bold="True" Text="Personal Particular"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                       
                            <table width="100%" class="formtable2">
                             <tr>
                                <td class="formcontent" style="vertical-align:text-top;width:95%;">
                                   <table class="formtable2" width="100%">
                                    <tr ID="trcltcode" runat="server" visible="false">
                                        <td class="formcontent">
                                            <asp:Label ID="lblClCode" runat="server"></asp:Label>
                                            <span style="font-size: 10pt; color: #ff0000">*</span>
                                        </td>
                                        <td class="formcontent">
                                            <asp:TextBox ID="txtCusmId" runat="server" CssClass="standardtextbox" 
                                                MaxLength="12" TabIndex="1" Width="201px"></asp:TextBox>
                                            <asp:Button ID="btnCusmId" runat="server" CssClass="btn btn-xs btn-primary" 
                                                TabIndex="2" Text="...." Visible="false" Width="20px" />
                                            <%--<asp:RequiredFieldValidator ID="revCusmId" runat="server" ErrorMessage="Mandatory" ControlToValidate="txtCusmId">
                                            </asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td class="formcontent">
                                            <asp:Label ID="lblCode" runat="server" ></asp:Label>
                                        </td>
                                        <td class="formcontent">
                                            <asp:UpdatePanel ID="UpdPanelCltCode" runat="server" RenderMode="Inline" 
                                                UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtCltCode" runat="server" CssClass="standardtextbox" 
                                                        MaxLength="12" TabIndex="3" Width="104px"></asp:TextBox>
                                                    &nbsp;
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 23%;">
                                            <asp:Label ID="lvlVw1AgntCode" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 33%;">
                                            <asp:TextBox ID="txtAgtCode" runat="server" CssClass="standardtextbox" Enabled="false"
                                                TabIndex="4" Width="206px" BackColor="#EDEFEE" ForeColor="Black"></asp:TextBox>
                                            <asp:Label ID="lblVw1SMCode" runat="server" Font-Bold="False" Text="" 
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 22%;">
                                            <span>
                                            <asp:Label ID="lblVw1AgntStatus" runat="server" Font-Bold="False"></asp:Label>
                                            </span>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 22%;">
                                            <asp:DropDownList ID="ddlAgntStatus" runat="server" CssClass="standardmenu" 
                                                TabIndex="5" Width="108px" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblAgntName" runat="server" Font-Bold="False"></asp:Label>
                                            <span style="font-size: 10pt; color: #ff0000">*</span>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:DropDownList id="cboagnTitle"  runat="server" CssClass="standardmenu" 
                                            DataTextField="ParamDesc" DataValueField="ParamValue" 
                                            AppendDataBoundItems="True" DataSourceID="dscbotitle"
                                            Width="52px" TabIndex="5" Height="21px" Enabled="false"></asp:DropDownList> 
                                            <asp:TextBox ID="txtAgntName" runat="server"  onChange="javascript:this.value=this.value.toUpperCase();"
                                                CssClass="TextBox" MaxLength="125" TabIndex="6" Width="150px" 
                                                Enabled="False"></asp:TextBox>
                                                <asp:SqlDataSource ID="dscbotitle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblPanNo" runat="server"></asp:Label>
                                            <span style="font-size: 10pt; color: #ff0000"></span>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:UpdatePanel ID="UpdPnlPAN" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtPanNo" runat="server" CssClass="TextBox" MaxLength="24" 
                                                        onChange="javascript:this.value=this.value.toUpperCase();" TabIndex="7" 
                                                        Width="104px" Enabled="False"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
                                                        runat="server" FilterMode="InvalidChars" FilterType="Custom" 
                                                        InvalidChars=",#$@%^!*()&amp; ''%^~`" TargetControlID="txtPanNo">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                   <%--   <div class="btn btn-xs btn-primary" style="width: 65px;">
                                                        <i class="fa fa-check-circle-o"></i>--%>
                                                    <asp:Button ID="btnVerifyPAN" runat="server" CssClass="standardbutton" 
                                                        OnClick="btnVerifyPAN_Click" OnClientClick="verifyPan();" TabIndex="8" 
                                                        Text="Verify" Width="50px" Enabled="False" /><%--</div>--%>
                                                    <div ID="divPAN" class="Content" style="display: none">
                                                        <img src="../../../App_Themes/Isys/images/spinner.gif" />
                                                        <asp:Label ID="Lblimg" runat="server"></asp:Label>
                                                    </div>
                                                    <br />
                                                    <asp:Label ID="lblPANMsg" runat="server" Font-Bold="False" Font-Size="X-Small"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr ID="trserv" runat="server" visible="false">
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblServName" runat="server" Font-Bold="False" 
                                                Text="Service Name"></asp:Label>
                                            <span style="font-size: 10pt; color: #ff0000">*</span>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:TextBox ID="txtServProvInfo" runat="server" CssClass="standardtextbox" 
                                                MaxLength="30" TabIndex="9" Width="150px"></asp:TextBox>
                                        </td>
                                        <td align="left" class="formcontent">
                                        </td>
                                        <td align="left" class="formcontent">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:DropDownList ID="ddlGender" runat="server" class="standardmenu" 
                                                TabIndex="10" Width="210px" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblCorrAdd" runat="server" Text="Correspondence Address"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:DropDownList ID="ddlCnctType" runat="server" AppendDataBoundItems="true" 
                                                CssClass="standardmenu" DataSourceID="dsCnctType" DataTextField="ParamDesc" 
                                                DataValueField="ParamValue" TabIndex="11" Width="108px" Enabled="False">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="dsCnctType" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:DefaultConn %>"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr ID="trexclusive" runat="server" visible="false">
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblExclusive" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:RadioButtonList ID="rdlExclusive" runat="server" TabIndex="12">
                                            </asp:RadioButtonList>
                                        </td>
                                        <td align="left" class="formcontent">
                                        </td>
                                        <td align="left" class="formcontent">
                                        </td>
                                    </tr>
                                </table>
                                </td>
                                <td class="formcontent" style="vertical-align:middle;width:5%;">
                                    <table border="0" cellpadding="0" cellspacing="0" class="formtable2">
                                        <tr>
                                            <td>
                                            <asp:Image ID="Img" runat="server" ImageUrl="~/theme/iflow/prof_pic_blank.jpg" Height="100px" />
                                             <asp:GridView ID="GridImage" runat="server" AllowPaging="True" 
                                                AllowSorting="True" AutoGenerateColumns="False" CssClass="formtable" 
                                                Height="100%" HorizontalAlign="Left" 
                                                PagerStyle-Font-Underline="true" PagerStyle-ForeColor="blue" 
                                                PagerStyle-HorizontalAlign="Center" RowStyle-CssClass="formtable" Width="100%">
                                                <Columns>
                                                    <%--<asp:TemplateField SortExpression="DocType" HeaderText="Image Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblCndNo" runat="server" Text='<%# Eval("DocType") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            
                                            </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="AgentCode" SortExpression="AgentCode" 
                                                        Visible="false">
                                                        <ItemTemplate>
                                                            <%--<asp:LinkButton ID="lblCndNo1" runat="server" Text='<%# Eval("AgentCode") %>'></asp:LinkButton>--%>
                                                            <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("AgentCode") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ImageField ControlStyle-Height="100px" ControlStyle-Width="120px" 
                                                        DataImageUrlField="AgentCode"
                                                        DataImageUrlFormatString="ImageRet.aspx?ImageID={0}" HeaderText="Preview Image" 
                                                        NullImageUrl="~/theme/iflow/prof_pic_blank.jpg">
                                                    </asp:ImageField>
                                                </Columns>
                                                <RowStyle BackColor="#78A8FA" CssClass="sublinkeven" />
                                                <PagerStyle CssClass="pagelink" Font-Underline="True" ForeColor="Blue" 
                                                    HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="test" />
                                                <AlternatingRowStyle BackColor="#78A8FA" CssClass="sublinkodd" />
                                            </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lnkUploadPhoto" runat="server" Text="Upload Photo" 
                                                    Font-Size="12px" Visible="false"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                        </td>
                             </tr>
                             </table>
                            
                            <asp:UpdatePanel ID="upsaplic" runat="server" style="display: block;">
                            <ContentTemplate>

                            <div id="divlicdtls" runat="server" style="width:100%;display:none;" >
                            <table width="100%" class="formtable2">
                                <tr style="height: 20px;">
                                    <td align="left" colspan="8" class="test">
                                        <input runat="server" type="button" class="standardlink" value="-" id="btnLicnseDtlscollapse"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divLicnsDtls','ctl00_ContentPlaceHolder1_btnLicnseDtlscollapse');" />
                                        <asp:Label ID="lblLicnsDtlshdr" runat="server" Font-Bold="True" Text="License Details"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div id="divLicnsDtls" runat="server" style="display: block;" width="100%">
                                <table width="100%" class="formtable2">
                                    <tr>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblLicNo" runat="server" Text="License No"></asp:Label>
                                            <span style="font-size: 10pt; color: #ff0000">*</span>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 30%;">
                                            <asp:TextBox ID="txtBizLicNo" runat="server" CssClass="standardtextbox" Width="150px"
                                                MaxLength="15" TabIndex="109" BackColor="#FFFFB2" ></asp:TextBox>
                                            
                                        </td>
                                        <td align="left" class="formcontent" style="width: 20%;">
                                            <asp:Label ID="lblLicEexpDate" runat="server" Text="License Expiry Date"></asp:Label>
                                            <span style="font-size: 10pt; color: #ff0000">*</span>
                                        </td>
                                        <td align="left" class="formcontent" style="width: 30%;">
                                            <uc3:ctldate ID="txtBizLicEndDt" runat="server" CssClass="standardtextbox" Width="150"
                                                TabIndex="110" BackColor="#FFFFB2"/>
                                        </td>
                                    </tr>
                                    <tr id="trOldLic" runat="server">
                                        <td class="formcontent" align="left">
                                            <asp:Label ID="lblOldLicNo" runat="server" Text="Old Lic No" Width="148px"></asp:Label>
                                        </td>
                                        <td class="formcontent" align="left">
                                            <asp:TextBox ID="txtBizOldLicNo" runat="server" CssClass="standardtextbox" 
                                                Width="150px" TabIndex="111"></asp:TextBox>
                                        </td>
                                        <td class="formcontent" align="left">
                                            <asp:Label ID="lblOldLicStrtDt" runat="server" Text="Old License Start Date"></asp:Label>
                                        </td>
                                        <td class="formcontent" align="left">
                                            <asp:TextBox ID="txtBizOldLicStrtDt" runat="server" CssClass="standardtextbox" 
                                                Width="150px" TabIndex="112"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trOldStrtDt" runat="server" >
                                        <td class="formcontent" align="left">
                                            <asp:Label ID="lblOldLicExpDt" runat="server" Text="Old License Expiry Date"></asp:Label>
                                        </td>
                                        <td class="formcontent" align="left">
                                            <asp:TextBox ID="txtBizOldLicExpDt" runat="server" CssClass="standardtextbox" 
                                                Width="150px" TabIndex="113"></asp:TextBox>
                                        </td>
                                        <td class="formcontent" align="left">
                                        </td>
                                        <td class="formcontent" align="left">
                                        </td>
                                    </tr>
                                  
                                    
                                </table>
                                
                            </div>

                            </div>
                            
                           
                            <table width="100%" class="formtable2">
                                <tr style="height: 20px;">
                                    <td align="left" colspan="8" class="test">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnSapDtlscollapse"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divsapdtls','ctl00_ContentPlaceHolder1_btnSapDtlscollapse');" />
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Sap Code Details"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                                <div id="divsapdtls" runat="server" style="width:100%;display: block;">
                                <table width="100%" class="formtable2">
                                <tr id="trSapCode" runat="server" >
                                    <td class="formcontent" style="width: 20%;">
                                        
                                        <asp:Label ID="lblSAPcode" runat="server" ></asp:Label>
                                    </td>
                                    <td class="formcontent">
                                        
                                        <asp:UpdatePanel ID="upsap" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtSAPcode" runat="server" CausesValidation="true" CssClass="standardtextbox"
                                                    MaxLength="10" Width="150px" ></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    </tr>
                            </table>
                            </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>

                            <table width="100%" class="formtable2">
                                <tr style="height: 20px;">
                                    <td align="left" colspan="8" class="test">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnHirarchyDtlscollapse"
                                            style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divHirarchyDtls','ctl00_ContentPlaceHolder1_btnHirarchyDtlscollapse');" />
                                        <asp:Label ID="lblHirarchyDtlshdr" runat="server" Font-Bold="True" Width="141px"
                                            Text="Hierarchy Details"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div ID="divHirarchyDtls" runat="server" style="display: block;" width="100%">
                                <table width="100%" class="formtable2">
                                    <tr>
                                        <td class="formcontent" align="left" style="width: 20%;">
                                            <asp:Label ID="lblchnltype" runat="server"></asp:Label>
                                        </td>
                                        <td class="formcontent" align="left" style="width: 30%;">
                                            <asp:UpdatePanel ID="updChnlTyp" runat="server">
                                                <ContentTemplate>
                                                    <asp:RadioButtonList ID="rdbChnlTyp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbChnlTyp_SelectedIndexChanged"
                                                        RepeatDirection="Horizontal" TabIndex="21" Enabled="false">
                                                        <asp:ListItem Value="0" Text="Company"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Channel"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td class="formcontent" align="left" style="width: 20%;">
                                            <asp:Label ID="lblCntDetails" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td class="formcontent" align="left" style="width: 30%;">
                                            <asp:LinkButton ID="lnbViewCntDetails" runat="server" TabIndex="11" Visible="false">View Details</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblBusinessSrc" runat="server" Font-Bold="False"></asp:Label><span
                                                style="font-size: 10pt; color: #ff0000">*</span>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:UpdatePanel ID="updddlSlsChnl" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSlsChannel" runat="server" CssClass="standardmenu" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlSlsChannel_SelectedIndexChanged" Width="220px" 
                                                        TabIndex="22" Enabled="False">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="rdbChnlTyp" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblChnCls" runat="server"></asp:Label><span style="font-size: 10pt;
                                                color: #ff0000">*</span>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:UpdatePanel runat="server" ID="upnlChnCls">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlChnCls" runat="server" CssClass="standardmenu" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlChnCls_SelectedIndexChanged" TabIndex="23" 
                                                        Width="220px" Enabled="False">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlSlsChannel" EventName="SelectedIndexChanged">
                                                    </asp:AsyncPostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblVw1AgntType" runat="server" Font-Bold="False">Agent Type</asp:Label>
                                            <span style="font-size: 10pt; color: #ff0000">*</span>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:UpdatePanel runat="server" ID="upnlAgnType">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlAgntType" runat="server" CssClass="standardmenu" AutoPostBack="True"
                                                        Width="220px" OnSelectedIndexChanged="ddlAgntType_SelectedIndexChanged" 
                                                        TabIndex="24" Enabled="False">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChnCls" EventName="SelectedIndexChanged">
                                                    </asp:AsyncPostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:Label ID="lblAgntClass" runat="server" Font-Bold="False">Agent Class</asp:Label>
                                        </td>
                                        <td align="left" class="formcontent">
                                            <asp:DropDownList ID="ddlAgntClass" runat="server" CssClass="standardmenu" Width="220px" Enabled="false"
                                                TabIndex="25">
                                                <asp:ListItem Value="NM" Text="Staff"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:UpdatePanel runat="server" ID="updReportingMngrDtls">
                                <ContentTemplate>
                                    <table id="tblReportingMngrDtls" runat="server" width="100%" class="formtable2">
                                        <tr>
                                            <td>
                                                <table width="100%" class="formtable2">
                                                    <tr style="height: 20px;">
                                                        <td align="left" class="test" style="width: 20%;" colspan="4">
                                                            <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnprirepcollapse"
                                                                style="width: 20px;" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divprirep','ctl00_ContentPlaceHolder1_btnprirepcollapse');" />
                                                            <asp:Label ID="lblPrimaryReportinghdr" runat="server" Text="Primary Reporting" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <%--<td align="left" class="test" style="height: 16px;" colspan="3">
                                                        <asp:Label ID="lblam2reportingtype" runat="server" Height="19px" Text="Manager 2" Font-Bold="true" Width="100px"></asp:Label>
                                                        <asp:CheckBox ID="chktrf1" runat="server"  />
                                                        <asp:LinkButton ID="lnktrf1" runat="server" Text="Transfer"></asp:LinkButton>
                                                    </td>--%>
                                                    </tr>
                                                </table>
                                                <div ID="divprirep" runat="server" style="display: block;" width="100%">
                                                    <table width="100%" class="formtable2">
                                                        <tr>
                                                            <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                                <asp:Label ID="lblddlreportingtype" runat="server" Text="Reporting Type"></asp:Label>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                            <asp:DropDownList ID="ddlprimrepo" runat="server" Height="19px" Width="220px" 
                                                            CssClass="standardmenu" Enabled="False" >
                                                        </asp:DropDownList>
                                                                <%--<asp:Label ID="lblreportingtype" runat="server" ></asp:Label>--%>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                                <asp:Label ID="lblbasedon" runat="server" Text="Based On"></asp:Label>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                            <asp:DropDownList ID="ddlbasedondesc" runat="server" Height="19px" Width="220px" 
                                                            CssClass="standardmenu" Enabled="False" >
                                                            </asp:DropDownList>
                                                                <%--<asp:Label ID="lblbasedondesc" runat="server" ></asp:Label>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="formcontent" style="height: 26px">
                                                                <asp:Label ID="lblchannel" runat="server">Hierarchy Name</asp:Label>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 26px">
                                                           <asp:DropDownList ID="ddlchanneldesc" runat="server" Height="19px" Width="220px" 
                                                            CssClass="standardmenu" Enabled="False" ></asp:DropDownList>
                                                                <%--<asp:Label ID="lblchanneldesc" runat="server" ></asp:Label>--%>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 26px">
                                                                <asp:Label ID="lblsubchannel" runat="server" Width="120px">Sub Class</asp:Label>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 26px;">
                                                            <asp:DropDownList ID="ddlsubchnldesc" runat="server" Height="19px" Width="220px" 
                                                            CssClass="standardmenu" Enabled="False" >
                                                            </asp:DropDownList>
                                                                <%--<asp:Label ID="lblsubchanneldesc" runat="server" ></asp:Label>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formcontent" align="left" style="height: 21px">
                                                                <asp:Label ID="lblReportingMgr" runat="server" Text="Reporting Manager"></asp:Label>
                                                            </td>
                                                            <td class="formcontent" align="left" style="height: 21px">
                                                                <%--<asp:DropDownList ID="ddlRptMgr" runat="server" Height="20px" Width="200px" 
                                                                    TabIndex="26">
                                                                </asp:DropDownList>--%>
                                                                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtRptMgr" runat="server" CssClass="standardtextbox" 
                                                                        Width="210px" Enabled="False" ></asp:TextBox>&nbsp
                                                                    <asp:Button ID="btnRptMgr" runat="server" CssClass="standardbutton" Text="...." 
                                                                        Width="20px" Enabled="False" />
                                                                    <asp:HiddenField ID="hdnRptMgr" runat="server" />
                                                                    <asp:Label ID="lblrptmgr" runat="server"></asp:Label>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 21px">
                                                                <asp:Label ID="lbllevelagttype" runat="server" >Level/Rel Type</asp:Label>
                                                            </td>
                                                            <td align="left" class="formcontent" style="height: 21px">
                                                            <asp:DropDownList ID="ddllvlagt" runat="server" Height="19px" Width="220px" 
                                                            CssClass="standardmenu" Enabled="False" >
                                                            </asp:DropDownList>
                                                                <%--<asp:Label ID="lbllevelagttypedesc" runat="server" ></asp:Label>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formcontent" align="left">
                                                                <%--<asp:Label ID="lblUntCde" runat="server"></asp:Label><span style="font-size: 10pt;
                                                                    color: #ff0000">*</span>--%>
                                                            </td>
                                                            <td class="formcontent" align="left">
                                                                
                                               <%--                 <asp:UpdatePanel runat="server" ID="upnlBtnUnitCode">
                                                                    <ContentTemplate>
                                                                <asp:TextBox ID="txtUntCode" runat="server" CssClass="standardtextbox" MaxLength="10"
                                                                    Width="200px" TabIndex="27"></asp:TextBox>
                                                                        <asp:Button ID="btnUnitCode" runat="server" CssClass="standardbutton" Text="...."
                                                                            Width="20px" TabIndex="28" />
                                                                        <asp:Button ID="btnSalesUnitCode" runat="server" CssClass="standardbutton" Text="...."
                                                                            Visible="false" Width="20px" TabIndex="29" />
                                                                            <asp:Label ID="lblUnitDesc" runat="server"></asp:Label>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged">
                                                                        </asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                                <asp:Label ID="lblUntCode" runat="server" ></asp:Label>--%>
                                                            </td>
                                                            <td class="formcontent" align="left">
                                                            </td>
                                                            <td class="formcontent" align="left">

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <table width="100%" class="formtable2">
                                    <tr>
                                        <td align="left" class="test" style="height: 21px; " colspan="2">
                                        <input runat="server" type="button" class="btn btn-xs btn-primary" value="-" id="btnaddlmgrcollapse"
                                            style="width: 20px;" 
                                                onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divMngrDtls','ctl00_ContentPlaceHolder1_btnaddlmgrcollapse');" />
                                                <asp:Label ID="lblAddlMgrDet" 
                                                runat="server" Text="Additional Manager Details" 
                                            Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                                    <div id="divMngrDtls" runat="server" style="display: block;" width="100%">
                                    <table width="100%" class="formtable2">
                                    <tr>
                                        <td align="left" class="formcontent" style="height: 21px; width: 20%;">
                                            <asp:Label ID="lbladditionalreporting" runat="server" Text="Additional Reporting Rule"></asp:Label>
                                        </td>
                                        <td class="formcontent" style="height: 21px; width: 80%;" align="left">
                                            <asp:Label ID="lbladditionalreportingrule" runat="server"></asp:Label>
                                            <asp:Label ID="lblRptMngrErr" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formcontent" style="width: 100%;" colspan="2">
                                            <table id="tblmgr1" class="formtable2" runat="server" width="100%">
                                                <tr>
                                                    <td align="left" class="test" style="height: 21px; width: 20%;" colspan="4">
                                                    <%--<input runat="server" type="button" class="standardlink" value="-" id="btnaddlmgr1collapse"
                                                        style="width: 20px;" 
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divMngrDtls','ctl00_ContentPlaceHolder1_btnaddlmgr1collapse');" 
                                                        __designer:mapid="29f7" />--%>
                                                        <asp:Label ID="lbladdnlmgr1" runat="server" Height="19px"  Text="Additional Manager 1" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <%--<td align="left" class="test" style="height: 21px;" colspan="3">
                                                        <asp:Label ID="lblam1mreportingtype1" runat="server" Height="19px" Text="Manager 1" Font-Bold="true" Width="100px"></asp:Label>
                                                        <asp:CheckBox ID="chktrf2" runat="server" />
                                                        <asp:LinkButton ID="lnktrf2" runat="server" Text="Transfer" ></asp:LinkButton>
                                                    </td>--%>

                                                </tr>
                                                <%--<tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblVendorType1" runat="server" Text="Vendor Type"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px;" colspan="3">
                                                        <asp:DropDownList ID="ddlventype1" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                        &nbsp
                                                        <asp:CheckBox ID="chkisprimry1" runat="server" Text="Is Primary" />
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblamreportingtype1" runat="server" Height="19px" Text="Reporting Type" Width="100px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam1rptdesc" runat="server" Height="19px" Width="220px" 
                                                            CssClass="standardmenu" 
                                                            onselectedindexchanged="ddlam1rptdesc_SelectedIndexChanged" 
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblambasedon1" runat="server"  
                                                            Text="Based On" Width="65px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam1basedondesc" runat="server" CssClass="standardmenu" 
                                                            Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblchnl1" runat="server" Text="Channel" Width="55px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam1chnldesc" runat="server" Height="19px" 
                                                            CssClass="standardmenu" Width="220px" 
                                                            onselectedindexchanged="ddlam1chnldesc_SelectedIndexChanged" 
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblsubchnl1" runat="server" Text="Sub Channel" Width="80px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam1subchnldesc" runat="server" Height="19px" 
                                                            Width="220px" CssClass="standardmenu" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblamlevelagttype1" runat="server" Height="16px" Text="Level/Agent Type" Width="110px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddllvlagttype1" runat="server" Height="21px" 
                                                            Width="220px" CssClass="standardmenu" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblMgr1" runat="server" Text="Manager" Width="94px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <%--<asp:DropDownList ID="ddam1lMgr" runat="server" CssClass="standardmenu" 
                                                            Height="21px" TabIndex="30" Width="220px">
                                                        </asp:DropDownList>--%>
                                                        <asp:UpdatePanel ID="uprmgr1" runat="server">
                                                        <ContentTemplate>
                                                        <asp:TextBox ID="txtRptMgr1" runat="server" CssClass="standardtextbox" 
                                                            Width="210px" Enabled="False"></asp:TextBox>
                                                        &nbsp;<asp:Button ID="btnRptMgr1" runat="server" CssClass="standardbutton" 
                                                            Text="...." Width="20px" Enabled="False" />
                                                            <asp:HiddenField ID="hdnRptMgr1" runat="server" />
                                                        <asp:Label ID="lblrptmgr1" runat="server"></asp:Label>
                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tblmgr2" class="formtable2" runat="server" width="100%">
                                                <tr>
                                                    <td align="left" class="test" style="height: 16px; width: 20%;" colspan="4"> 
                                                    <%--<input runat="server" type="button" class="standardlink" value="-" id="btnaddlmgr2collapse"
                                                        style="width: 20px;" 
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divMngrDtls','ctl00_ContentPlaceHolder1_btnaddlmgr2collapse');" 
                                                        __designer:mapid="29f7" />--%>
                                                        <asp:Label ID="lbladdnlmgr2" runat="server" Height="19px" 
                                                            Text="Additional Manager 2" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <%--<td align="left" class="test" style="height: 16px;" colspan="3">
                                                        <asp:Label ID="lblam2reportingtype" runat="server" Height="19px" Text="Manager 2" Font-Bold="true" Width="100px"></asp:Label
                                                        <asp:CheckBox ID="chktrf3" runat="server" />
                                                        <asp:LinkButton ID="lnktrf3" runat="server" Text="Transfer" ></asp:LinkButton>
                                                    </td>--%>
                                                </tr>
                                                <%--  <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblVendorType2" runat="server" Text="Vendor Type"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px;" colspan="3">
                                                        <asp:DropDownList ID="ddlventype2" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:CheckBox ID="chkisprimry2" runat="server" Text="Is Primary" />
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblamreportingtype2" runat="server" Height="19px" 
                                                            Text="Reporting Type" Width="100px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam2rptdesc" runat="server" Height="19px" TabIndex="77" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblambasedon2" runat="server" Text="Based On" Width="65px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam2basedondesc" runat="server" TabIndex="80" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblchnl2" runat="server" Text="Channel" Width="55px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam2chnldesc" runat="server" TabIndex="78" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblsubchnl2" runat="server" Text="Sub Channel" Width="80px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam2subchnldesc" runat="server" TabIndex="79" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblamlevelagttype2" runat="server" Height="16px" 
                                                            Text="Level/Agent Type" Width="110px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddllvlagttype2" runat="server" TabIndex="81" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblMgr2" runat="server" Text="Manager" Width="94px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <%--<asp:DropDownList ID="ddam2lMgr" runat="server" CssClass="standardmenu" Height="21px"
                                                            TabIndex="31" Width="220px">
                                                        </asp:DropDownList>--%>
                                                        <asp:UpdatePanel ID="uprmgr2" runat="server">
                                                        <ContentTemplate>
                                                        <asp:TextBox ID="txtRptMgr2" runat="server" CssClass="standardtextbox" 
                                                            Width="210px" Enabled="False"></asp:TextBox>
                                                        &nbsp;<asp:Button ID="btnRptMgr2" runat="server" CssClass="standardbutton" 
                                                            Text="...." Width="20px" Enabled="False" />
                                                            <asp:HiddenField ID="hdnRptMgr2" runat="server" />
                                                        <asp:Label ID="lblrptmgr2" runat="server"></asp:Label>
                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tblmgr3" class="formtable2" runat="server" width="100%">
                                                <tr>
                                                    <td align="left" class="test" style="height: 16px; width: 20%;" colspan="4">
                                                    <%--<input runat="server" type="button" class="standardlink" value="-" id="btnaddlmgr3collapse"
                                                        style="width: 20px;" 
                                                        onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divMngrDtls','ctl00_ContentPlaceHolder1_btnaddlmgr3collapse');" 
                                                        __designer:mapid="29f7" />--%>
                                                        <asp:Label ID="lbladdnlmgr3" runat="server" Height="19px" 
                                                            Text="Additional Manager 3" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <%--<td align="left" class="test" style="height: 16px;" colspan="3">
                                                        <asp:Label ID="lblam3reportingtype" runat="server" Height="19px" Text="Manager 3"
                                                            Width="100px" Font-Bold="true"></asp:Label>
                                                            <asp:CheckBox ID="chktrf4" runat="server" />
                                                            <asp:LinkButton ID="lnktrf4" runat="server" Text="Transfer" ></asp:LinkButton>
                                                    </td>--%>
                                                </tr>
                                                <%-- <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblVendorType3" runat="server" Text="Vendor Type"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px;" colspan="3">
                                                        <asp:DropDownList ID="ddlventype3" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:CheckBox ID="chkisprimry3" runat="server" Text="Is Primary" />
                                                    </td>
                                                </tr>--%>

                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblamreportingtype3" runat="server" Height="19px" 
                                                            Text="Reporting Type" Width="100px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam3rptdesc" runat="server" Height="19px" TabIndex="83" 
                                                            Width="220px" CssClass="standardmenu" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblambasedon3" runat="server" Text="Based On" Width="65px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam3basedondesc" runat="server" TabIndex="86" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblchnl3" runat="server" Text="Channel" Width="55px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam3chnldesc" runat="server" TabIndex="84" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblsubchnl3" runat="server" Text="Sub Channel" Width="80px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddlam3subchnldesc" runat="server" TabIndex="85" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblamlevelagttype3" runat="server" Height="16px" 
                                                            Text="Level/Agent Type" Width="110px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <asp:DropDownList ID="ddllvlagttype3" runat="server" TabIndex="87" 
                                                            CssClass="standardmenu" Width="220px" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="Label28" runat="server" Text="Manager" Width="94px"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 30%;">
                                                        <%--<asp:DropDownList ID="ddam3lMgr" runat="server" CssClass="standardmenu" Height="21px"
                                                            TabIndex="32" Width="220px">
                                                        </asp:DropDownList>--%>
                                                        <asp:UpdatePanel ID="uprmgr3" runat="server">
                                                        <ContentTemplate>
                                                        <asp:TextBox ID="txtRptMgr3" runat="server" CssClass="standardtextbox" 
                                                            Width="210px" Enabled="False"></asp:TextBox>
                                                        &nbsp;<asp:Button ID="btnRptMgr3" runat="server" CssClass="standardbutton" 
                                                            Text="...." Width="20px" Enabled="False" />
                                                            <asp:HiddenField ID="hdnRptMgr3" runat="server" />
                                                        <asp:Label ID="lblrptmgr3" runat="server"></asp:Label>
                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged">
                                    </asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                    <div>
                        <table>
                            <tr>
                                <td class="formcontent" align="right">
                                 <%--<div class="btn btn-xs btn-primary">
                                        <i class="fa fa-check"></i>--%>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="standardbutton"
                                        OnClick="btnUpdate_Click" TabIndex="128" /><%--</div>--%>
                                         <span style="padding-left: 3px;"></span>
                                   <%-- <div class="btn btn-xs btn-primary">
                                        <i class="fa fa-times"></i>--%>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="standardbutton" CausesValidation="False"
                                        OnClick="btnCancel_Click" TabIndex="129"/><%--</div>--%>
                                    <%-- <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblVendorType3" runat="server" Text="Vendor Type"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px;" colspan="3">
                                                        <asp:DropDownList ID="ddlventype3" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:CheckBox ID="chkisprimry3" runat="server" Text="Is Primary" />
                                                    </td>
                                                </tr>--%>
                                </td>
                                <td class="formcontent" align="left">
                                    <%--<asp:DropDownList ID="ddam3lMgr" runat="server" CssClass="standardmenu" Height="21px"
                                                            TabIndex="32" Width="220px">
                                                        </asp:DropDownList>--%>
                                </td>
                                <td class="formcontent" align="left">
                                    <%-- <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblVendorType3" runat="server" Text="Vendor Type"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px;" colspan="3">
                                                        <asp:DropDownList ID="ddlventype3" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:CheckBox ID="chkisprimry3" runat="server" Text="Is Primary" />
                                                    </td>
                                                </tr>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="hdnID210" type="hidden" runat="server" />
                                    <input id="hdnID220" type="hidden" runat="server" />
                                    <input id="hdnID240" type="hidden" runat="server" />
                                    <input id="hdnID250" type="hidden" runat="server" />
                                    <input id="hdnID260" type="hidden" runat="server" />
                                    <input id="hdnID270" type="hidden" runat="server" />
                                    <input id="hdnID280" type="hidden" runat="server" />
                                    <input id="hdnID290" type="hidden" runat="server" />
                                    <input id="hdnID300" type="hidden" runat="server" />
                                    <input id="hdnID310" type="hidden" runat="server" />
                                    <input id="hdnID320" type="hidden" runat="server" />
                                    <input id="hdnID330" type="hidden" runat="server" />
                                    <input id="hdnID340" type="hidden" runat="server" />
                                    <input id="hdnID360" type="hidden" runat="server" />
                                    <input id="hdnID370" type="hidden" runat="server" />
                                    <input id="hdnID380" type="hidden" runat="server" />
                                    <input id="hdnID390" type="hidden" runat="server" />
                                    <input id="hdnID400" type="hidden" runat="server" />
                                    <input id="hdnID410" type="hidden" runat="server" />
                                    <input id="hdnID420" type="hidden" runat="server" />
                                    <input id="hdnID430" type="hidden" runat="server" />
                                    <input id="hdnID440" type="hidden" runat="server" />
                                    <input id="hdnID450" type="hidden" runat="server" />
                                    <input id="hdnID460" type="hidden" runat="server" />
                                    <input id="hdnID470" type="hidden" runat="server" />
                                    <input id="hdnID480" type="hidden" runat="server" />
                                    <input id="hdnID490" type="hidden" runat="server" />
                                    <input id="hdnID500" type="hidden" runat="server" />
                                    <input id="hdnID510" type="hidden" runat="server" />
                                    <input id="hdnID520" type="hidden" runat="server" />
                                    <input id="hdnID530" type="hidden" runat="server" />
                                    <input id="hdnID550" type="hidden" runat="server" />
                                    <input id="hdnID560" type="hidden" runat="server" />
                                    <input id="hdnID570" type="hidden" runat="server" />
                                    <input id="hdnID580" type="hidden" runat="server" />
                                    <input id="hdnID590" type="hidden" runat="server" />
                                    <input id="hdnID600" type="hidden" runat="server" />
                                    <input id="hdnID620" type="hidden" runat="server" />
                                    <input id="hdnID630" type="hidden" runat="server" />
                                    <input id="hdnID640" type="hidden" runat="server" />
                                    <input id="hdnID650" type="hidden" runat="server" />
                                    <input id="hdnID660" type="hidden" runat="server" />
                                    <input id="hdncurdate" type="hidden" runat="server" />
                                    <input id="hdnAgntRank" type="hidden" runat="server" />
                                    <input id="hdnAgntType" type="hidden" runat="server" />
                                    <input id="hdnAgntLevel" type="hidden" runat="server" />
                                    <input id="hdnAgntClass" type="hidden" runat="server" />
                                    <input id="hdnCSCCode" type="hidden" runat="server" />
                                    <input id="hdnAgnCreateRul" type="hidden" runat="server" />
                                    <input id="hdnUnitRank" type="hidden" runat="server" />
                                    <input id="hdnMicr" type="hidden" runat="server" />
                                    <input id="hdnChkCnt" type="hidden" runat="server" />
                                    <%--<asp:DropDownList ID="ddam3lMgr" runat="server" CssClass="standardmenu" Height="21px"
                                                            TabIndex="32" Width="220px">
                                                        </asp:DropDownList>--%><%-- <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblVendorType3" runat="server" Text="Vendor Type"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px;" colspan="3">
                                                        <asp:DropDownList ID="ddlventype3" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:CheckBox ID="chkisprimry3" runat="server" Text="Is Primary" />
                                                    </td>
                                                </tr>--%>
                                    <asp:HiddenField ID="hdnAgnCode" runat="server" />
                                    <asp:HiddenField ID="hdnPan" runat="server" /> 
                                    <%--<asp:DropDownList ID="ddam3lMgr" runat="server" CssClass="standardmenu" Height="21px"
                                                            TabIndex="32" Width="220px">
                                                        </asp:DropDownList>--%>
                                    <input id="hdnEndDate" type="hidden" runat="server" />
                                    <input id="hdnPaymentmode" type="hidden" runat="server" />
                                    <input id="hdnAgentType" type="hidden" runat="server" />
                                    <input id="HdnSlschnl" type="hidden" runat="server" />
                                    <input id="hdnagtcode" type="hidden" runat="server" />
                                    <input id="hdnagtname" type="hidden" runat="server" />
                                    <%-- <tr>
                                                    <td align="left" class="formcontent" style="height: 16px; width: 20%;">
                                                        <asp:Label ID="lblVendorType3" runat="server" Text="Vendor Type"></asp:Label>
                                                    </td>
                                                    <td align="left" class="formcontent" style="height: 16px;" colspan="3">
                                                        <asp:DropDownList ID="ddlventype3" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                        &nbsp;<asp:CheckBox ID="chkisprimry3" runat="server" Text="Is Primary" />
                                                    </td>
                                                </tr>--%><%--<asp:DropDownList ID="ddam3lMgr" runat="server" CssClass="standardmenu" Height="21px"
                                                            TabIndex="32" Width="220px">
                                                        </asp:DropDownList>--%>
                                    <input id="hdnrptrule" type="hidden" runat="server" />
                                    <input id="hdnHomeTel" type="hidden" runat="server" />
                                    <input id="hdnemail1" type="hidden" runat="server" />
                                    <input id="hdnmarsts" type="hidden" runat="server" />
                                    <input id="hdnUntCode" type="hidden" runat="server" />
                                    <input id="hdnCltDOB" type="hidden" runat="server" />
                                    <input id="hdnMobTel" type="hidden" runat="server" />
                                    <input id="hdnNtlty" type="hidden" runat="server" />
                                    <input id="hdnOccup" type="hidden" runat="server" />
                                    <input id="hdnTitle" type="hidden" runat="server" />
                                    <input id="hdnName" type="hidden" runat="server" />
                                    <input id="hdnCapital" type="hidden" runat="server" />
                                    <input id="hdnResAddr" type="hidden" runat="server" />
                                    <input id="hdnBusiAddr" type="hidden" runat="server" />
                                    <input id="hdnPermAddr" type="hidden" runat="server" />
                                    <input id="hdnStateP" type="hidden" runat="server" />
                                    <input id="hdnStateB" type="hidden" runat="server" />
                                    <input id="hdnStatePrm" type="hidden" runat="server" />
                                    <input id="hdnDistrP" type="hidden" runat="server" />
                                    <input id="hdnDistrB" type="hidden" runat="server" />
                                    <input id="hdnPinP" type="hidden" runat="server" />
                                    <input id="hdnPinB" type="hidden" runat="server" />
                                    <input id="hdnPinPrm" type="hidden" runat="server" />
                                    <input id="hdnCntryCP" type="hidden" runat="server" />
                                    <input id="hdnCntryCB" type="hidden" runat="server" />
                                    <input id="hdnCntryCPrm" type="hidden" runat="server" />
                                    <input id="hdnchn" type="hidden" runat="server" />
                                    <input id="hdnsubchn" type="hidden" runat="server" />
                                    <input id="hdnagttyp" type="hidden" runat="server" />
                                    <input id="hdnprimgr" type="hidden" runat="server" />
                                    <input id="hdnmgr1" type="hidden" runat="server" />
                                    <input id="hdnmgr2" type="hidden" runat="server" />
                                    <input id="hdnmgr3" type="hidden" runat="server" />
                                    <%--<asp:Button ID="btnAMLetter" runat="server" CssClass="standardbutton" Text="Gen AM Welcome Letter"
                                        Visible="False" OnClick="btnAMLetter_Click" Width="155px" />
                                    <!-- For PD Document Download-->
                                    <asp:Button ID="btnPDLetter" runat="server" CssClass="standardbutton" Text="Gen PD Welcome Letter"
                                        Visible="false" OnClick="btnPDLetter_Click" />
                                    &nbsp;<asp:Button ID="btnAMGoalLetter" runat="server" CssClass="standardbutton" Text="Goal Letter"
                                        OnClick="btnAMGoalLetter_Click" Visible="False" />&nbsp;<asp:Button ID="btnCDAPromotionLetter"
                                            runat="server" CssClass="standardbutton" Text="CDA Promotion Letter" Visible="False"
                                            Width="137px" OnClick="btnCDAPromotionLetter_Click" /><asp:Button ID="btnTerminationLetter"
                                                runat="server" CssClass="standardbutton" Text="Generate Letter" Visible="False"
                                                Enabled="false" Width="137px" OnClick="btnTerminationLetter_Click" />&nbsp;
                                    <asp:Button ID="btnReGenerateLetter" runat="server" CssClass="standardbutton" Text="ReGenerate Letter"
                                        Width="137px" OnClientClick="return confirm('Are you sure you want to DELETE this record?');"
                                        OnClick="btndelete_Click" Enabled="False" Visible="False" />--%>
                                    <asp:UpdatePanel runat="server" ID="upnlRule">
                                        <ContentTemplate>
                                            <input id="hdnCreateRule" type="hidden" runat="server" />
                                            <input id="hdnAppRule" type="hidden" runat="server" />
                                            <input id="hdnEMPCode" type="hidden" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel runat="server" ID="upnlUntRule">
                                        <ContentTemplate>
                                            <input id="hdnUntRule" type="hidden" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlAgntType" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
</center>
    <asp:Panel runat="server" ID="Panelpop" Width="850" display="none">
        <iframe runat="server" id="Iframepop" width="850" height="300px" frameborder="0"
            display="none"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="Label8" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="Mdlviewpopup" BehaviorID="mdlViewpop"
        DropShadow="true" TargetControlID="Label8" PopupControlID="Panelpop" BackgroundCssClass="modalPopupBg"
        >
    </ajaxToolkit:ModalPopupExtender>
    <%--Ibrahim--%>
    <asp:Panel runat="server" ID="pnlMdl" Width="500" Height="300" display="none">
        <iframe runat="server" id="ifrmMdlPopup" scrolling="no" width="500" frameborder="0"
            display="none" style="height: 300px"></iframe>
    </asp:Panel>
    <asp:Label runat="server" ID="lbl1" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mdlView" BehaviorID="mdlViewBID"
        DropShadow="true" TargetControlID="lbl1" PopupControlID="pnlMdl" BackgroundCssClass="modalPopupBg"
        >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
        BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="200px">
        <table width="100%">
            <tr align="center">
                <td width="100%" class="test" colspan="1" style="height: 32px">
                    INFORMATION
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 391px">
                    <br />
                    <center>
                        <asp:Label ID="lbl3" runat="server"></asp:Label></center>
                    <br />
                    <center>
                        <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" />
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
        BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
        DropShadow="true" OkControlID="btnok" Y="100" >
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>

