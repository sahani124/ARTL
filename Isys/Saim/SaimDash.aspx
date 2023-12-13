<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="SaimDash.aspx.cs" Inherits="Application_ISys_ChannelMgmt_SaimDash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .ajax__calendar
        {
            z-index: 100px;
        }
        .pagelink span
        {
            font-weight: bold;
        }
        .pnlCon
        {
            display: none;
        }
        
        .RadButton_disablebtn
        {
            line-height: 20px;
            color: rgb(255, 255, 255);
            margin-right: 0px;
            margin-left: -8px;
            background-color: rgb(135, 206, 250);
            background-position: 100% -88px;
            background-repeat: no-repeat;
        }
        
        .btnrd
        {
            border-right: #B6BCCB 1px solid;
            border-left: #B6BCCB 1px solid;
            border-top: #B6BCCB 1px solid;
            border-bottom: #B6BCCB 1px solid;
        }
        .classHoveredImage
        {
            background-position: 0 -100px;
        }
        .classPressedImage
        {
            background-position: 0 -200px;
        }
        .imgbtn
        {
            display: block;
            float: left;
            background-image: url(../../../images/checked-checkbox-64.jpg);
            height: 20px;
            width: 20px;
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
            vertical-align: top;
        }
        .control-label1
        {
            margin-top: 2px;
        }
    </style>
    <script src="../../../Scripts/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function doCancel() {
            $find("prgGrdBID").hide();
        }

        function showgrid(grd) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + grd).display = "block";
        }

        function ChangeColor(btn) {
            var strContent = "ctl00_ContentPlaceHolder1_";
            document.getElementById(strContent + btn).style.backgroundColor = "rgb(255, 255, 51)";
            ////showgrid(grd);
        }
        function LdWait(delay) {
            ////debugger;
            document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'block';
            setTimeout("RemoveLoading12()", delay);
        }

        function RemoveLoading12() {
            //debugger;
            //hide loading status...
            ////document.getElementById("ctl00_ContentPlaceHolder1_divloader").style.display = 'none';
            var myExtender = $find('prgGrdBID');
            myExtender.hide();
        }
        function funcShow() {
            /////debugger;
            var myExtender = $find('prgGrdBID');
            myExtender.show();
            document.getElementById("ctl00_ContentPlaceHolder1_ifrmMdlPopup").src = "ViewCompensation.aspx";
        }
        function fillcycdtTo() {
            ////debugger;
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtStrTm").value != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_txtStrTm").value != null) {
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEndTm").value = document.getElementById("ctl00_ContentPlaceHolder1_txtStrTm").value;
                    document.getElementById("ctl00_ContentPlaceHolder1_txtEndTm").disabled = true;
                    return false;
                }
            }
        }

        function chkPrevRun() {
            /////debugger;
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtRunStat") != null) {
                if (document.getElementById("ctl00_ContentPlaceHolder1_txtRunStat").innerText != null) {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_txtRunStat").innerText == "Pending" ||
                        document.getElementById("ctl00_ContentPlaceHolder1_txtRunStat").innerText == "Failed") {
                        alert('Please run Previous Batch Job');
                        return false;
                    }
                }
            }
        }

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
    </script>
    <center>
        <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="10">
        </asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="90%">
                    <tr>
                        <td style="text-align: left;">
                            <asp:ImageButton ID="lnkVwBtch" runat="server" ImageUrl="~/theme/iflow/vwbtch.png"
                                OnClick="lnkVwBtch_Click" Height="30px" Width="170px" Visible="false"/>
                            <asp:ImageButton ID="lnkViewComm" runat="server" ImageUrl="~/theme/iflow/vwcomp.png"
                                OnClick="lnkViewComm_Click" Height="30px" Width="200px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="updmain" runat="server" style="width: 90%;">
            <ContentTemplate>
                <div id="divkpihdrcollapse" runat="server" style="width: 100%;" class="divBorder1">
                    <table class="formtablehdr" width="100%" align="center">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label Text="SAIM BATCH JOB" ID="lblSaimDash" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right;">
                                <img id="myImg" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;"
                                    alt="" onclick="ShowReqDtl('divSaim','myImg','#myImg');" />
                            </td>
                        </tr>
                    </table>
                    <div id="divSaim" runat="server" style="width: 100%;">
                        <div id="div1" runat="server" style="width: 100%;" >
                            <table style="width: 100%;">
                                <tr>
                                    <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                        <asp:Label ID="lblrlSetKy" Text="Compensation Type" runat="server" CssClass="control-label col-md-5" />
                                    </td>
                                    <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCmpType" runat="server" AutoPostBack="true" 
                                                    CssClass="select2-container form-control col-md-5" 
                                                    onselectedindexchanged="ddlCmpType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td style="white-space: nowrap; width: 20%;" class="form-body align col-md-6">
                                        <asp:Label ID="Label1" Text="Compensation Description" runat="server" CssClass="control-label col-md-5" />
                                    </td>
                                    <td style="width: 30%; white-space: nowrap;" class="col-md-7">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCmpCode" runat="server" AutoPostBack="true" 
                                                    CssClass="select2-container form-control col-md-5" >
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                            <table class="form-actions fluid" style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; padding-bottom: 5px; padding-top: 5px;" colspan="4">
                                        <asp:Button Text="SEARCH" CssClass="btn blue" ID="btnSearch" runat="server" 
                                            onclick="btnSearch_Click"  />
                                        <asp:Button Text="CANCEL" runat="server" ID="btnCnl" CssClass="btn default" 
                                            onclick="btnCnl_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="divPrevHdr" runat="server" style="width: 100%;" class="divBorder">
                            <table class="formtablehdr" width="100%" align="center">
                                <tr style="height: 30px;">
                                    <td style="padding-left: 5px;">
                                        <i class="fa fa-list"></i>
                                        <asp:Label ID="lblPrev" Text="Previous Batch Job Details" runat="server" Style="padding-left: 5px;" />
                                    </td>
                                    <td style="text-align: right;">
                                        <img id="Img1" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="ShowReqDtl('divPrev','Img1','#Img1');" />
                                    </td>
                                </tr>
                            </table>
                            <div id="divPrev" runat="server" style="width: 100%;">
                                <table width="100%" >
                                    <tr style="height: 30px;">
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lblPrvCycDt1" Text="Cycle Date From" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-7">
                                            <asp:Label ID="txtPrvCycDt1" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue"/>
                                        </td>
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lblPrvCycDt2" Text="Cycle Date To" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-7">
                                            <asp:Label ID="txtPrvCycDt2" runat="server" CssClass="form-control-static new_text_new"  ForeColor="Blue"/>
                                        </td>
                                    </tr>
                                    <tr style="height: 30px;">
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lblRunNo" Text="RunNo" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-7">
                                            <asp:Label ID="txtRunNo" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue" Font-Size="14px"/>
                                        </td>
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lblStat" Text="Status" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-7">
                                            <asp:Label ID="txtRunStat" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue" Font-Size="14px"/>
                                        </td>
                                    </tr>
                                    <tr style="height: 30px;">
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lblruncnt" Text="Run Count" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-7">
                                            <asp:Label ID="txtRunCnt" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue"/>
                                        </td>
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lblRunBy" Text="Run By" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-7">
                                            <asp:Label ID="txtRunBy" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue"/>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="divCurHdr" runat="server" style="width: 100%;" class="divBorder">
                            <table class="formtablehdr" width="100%">
                                <tr style="height: 30px;">
                                    <td style="padding-left: 5px;">
                                        <i class="fa fa-list"></i>
                                        <asp:Label ID="lblCurRnhdr" Text="Current Batch Job Details" runat="server" Style="padding-left: 5px;" />
                                    </td>
                                    <td style="text-align: right;">
                                        <img id="Img2" src="../../../assets/img/portlet-expand-icon-white.png" style="padding-right: 10px;"
                                            alt="" onclick="ShowReqDtl('divCur','Img2','#Img2');" />
                                    </td>
                                </tr>
                            </table>
                            <div id="divCur" runat="server" style="width: 100%;">
                                <table width="100%">
                                    <tr style="height: 30px;">
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label Text="Cycle Date From" ID="lblStrTm" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap;width: 30%;" class="col-md-7">
                                            <asp:UpdatePanel runat="server" ID="updStrTm" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtStrTm" runat="server" CssClass="form-control col-md-5" AutoPostBack="true"
                                                        onblur="javascript:fillcycdtTo();return false;" placeholder="Cycle Date From"/>
                                                    <asp:Image ID="imgstr" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                                    <ajaxToolkit:CalendarExtender ID="calextstr" CssClass="ajax__calendar" runat="server"
                                                        TargetControlID="txtStrTm" PopupButtonID="imgstr" Format="dd/MM/yyyy" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lblEndTm" Text="Cycle Date To" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; padding-bottom: 5px; padding-top: 5px; width: 30%;"
                                            class="col-md-7">
                                            <asp:TextBox ID="txtEndTm" runat="server" CssClass="form-control col-md-5" placeholder="Cycle Date To"/>
                                            <asp:Image ID="imgend" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp" />
                                            <ajaxToolkit:CalendarExtender ID="calextend" CssClass="ajax__calendar" runat="server"
                                                TargetControlID="txtEndTm" PopupButtonID="imgend" Format="dd/MM/yyyy" />
                                        </td>
                                    </tr>
                                    <tr style="height: 30px;">
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6 ">
                                            <asp:Label ID="lbCurRnNo" Text="RunNo" runat="server" CssClass="col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-6">
                                            <asp:Label ID="lbCurRnNoVal" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue" />
                                        </td>
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lbCurRnCnt" Text="Run Count" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-6">
                                            <asp:Label ID="lbCurRnCntVal" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue" />
                                        </td>
                                    </tr>
                                    <tr style="height: 30px;">
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lbCurRnStat" Text="Run Status" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-6">
                                            <asp:Label ID="lbCurRnStVal" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue"/>
                                        </td>
                                        <td style="white-space: nowrap; width: 20%;" class="col-md-6">
                                            <asp:Label ID="lbCurRunBy" Text="Run By" runat="server" CssClass="control-label1 col-md-5" />
                                        </td>
                                        <td style="white-space: nowrap; width: 30%;" class="col-md-6">
                                            <asp:Label ID="lbCurRnByVal" runat="server" CssClass="form-control-static new_text_new" ForeColor="Blue" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="form-actions fluid col-md-6" style="width: 100%;">
                            <table style="width: 100%;">
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button Text="VERIFY" CssClass="btn blue" ID="btnVerify" runat="server" OnClick="btnVerify_Click" />
                                        &nbsp;<asp:Button Text="Truncate" runat="server" ID="btnTruncate" CssClass="btn default"
                                            OnClick="btnTruncate_Click" Visible="false" />
                                        <asp:Button Text="CANCEL" runat="server" ID="btnCancel" CssClass="btn default" OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:MultiView ID="MVJob" ActiveViewIndex="1" runat="server">
                            <asp:View ID="VwDlyBtch" runat="server">
                                <asp:UpdatePanel ID="updDlyBtch" runat="server">
                                    <ContentTemplate>
                                        <table class="tableIsys" width="90%" align="center">
                                            <tr>
                                                <td class="formcontent" style="width: 20%; white-space: nowrap;">
                                                    <div>
                                                        <telerik:RadButton ID="btnPulData" runat="server" Text="PULL DATA" Height="50px"
                                                            Width="100%" Skin="Metro" CssClass="btnrd" BackColor="#87CEFA" ForeColor="Black"
                                                            Font-Size="Small" OnClick="btnPulData_Click">
                                                            <Icon PrimaryIconUrl="../../../images/data_pull.png" PrimaryIconTop="10px" PrimaryIconLeft="2px"
                                                                PrimaryIconWidth="50px" PrimaryIconHeight="50px" />
                                                        </telerik:RadButton>
                                                        <br />
                                                        <asp:LinkButton ID="lnkVwmrRun" runat="server" Text="View More" Font-Size="Small"
                                                            ForeColor="White" BackColor="#0000cd" Font-Underline="false" Width="100%" OnClick="lnkVwmrRun_Click"></asp:LinkButton>
                                                </td>
                                                <td class="formcontent" colspan="3" style="width: 80%;">
                                                    <asp:Label ID="lblPulDt" Text="" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="width: 80%;" colspan="4">
                                                    <telerik:RadProgressManager ID="RadProgressManager1" runat="server" Visible="true" />
                                                    <telerik:RadProgressArea ID="RadProgressArea1" runat="server" DisplayCancelButton="true"
                                                        Visible="true" ProgressIndicators="TotalProgressBar,
                                                TotalProgress,
                                                TimeElapsed,
                                                TimeEstimated,
                                                CurrentFileName,
                                                TransferSpeed">
                                                    </telerik:RadProgressArea>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdPulDt" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowDataBound="grdPulDt_RowDataBound" CssClass="table table-striped table-bordered table-hover dataTable">
                                                                <HeaderStyle ForeColor="Black" />
                                                                <PagerStyle />
                                                                <RowStyle ></RowStyle>
                                                                <AlternatingRowStyle ></AlternatingRowStyle>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Source Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltblsrc" Text="<%#Bind('SourceTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltbldest" Text="<%#Bind('DestTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Source Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSrcCnt" Text="<%#Bind('SourceCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDestCnt" Text="<%#Bind('DestCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Result">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblProcess" Text="<%#Bind('ReturnStatus') %>" runat="server" />
                                                                            <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" />
                                                                            <asp:LinkButton ID="lnkVw" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <telerik:RadButton ID="btnValData" runat="server" BackColor="#87CEFA" CssClass="btnrd"
                                                            Font-Size="Small" ForeColor="Black" Text="VALIDATE DATA" Height="50px" Width="100%"
                                                            Skin="Metro" OnClick="btnValData_Click">
                                                            <Icon PrimaryIconUrl="../../../images/data_validate.png" PrimaryIconTop="5px" PrimaryIconLeft="2px"
                                                                PrimaryIconWidth="50px" PrimaryIconHeight="50px" />
                                                        </telerik:RadButton>
                                                    </asp:Panel>
                                                    <asp:LinkButton ID="lnkVwMrVDt" runat="server" BackColor="#0000cd" Font-Size="Small"
                                                        Font-Underline="false" ForeColor="White" Text="View More" Width="100%" OnClick="lnkVwMrVDt_Click"></asp:LinkButton>
                                                </td>
                                                <td class="formcontent" colspan="3" style="width: 80%;">
                                                    <asp:Label ID="lblValDt" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" colspan="4">
                                                    <telerik:RadProgressManager ID="RadProgressManager4" runat="server" Visible="false" />
                                                    <telerik:RadProgressArea ID="RadProgressArea4" runat="server" DisplayCancelButton="true"
                                                        Visible="false" ProgressIndicators="TotalProgressBar,
                            TotalProgress,
                            TimeElapsed,
                            TimeEstimated,
                            CurrentFileName,
                            TransferSpeed">
                                                    </telerik:RadProgressArea>
                                                    <asp:UpdatePanel ID="updval" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdValData" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowDataBound="grdValData_RowDataBound" CssClass="table table-striped table-bordered table-hover dataTable" >
                                                                <HeaderStyle />
                                                                <PagerStyle ForeColor="Black" />
                                                                <RowStyle ></RowStyle>
                                                                <AlternatingRowStyle></AlternatingRowStyle>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Source Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltblsrc" Text="<%#Bind('SourceTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltbldest" Text="<%#Bind('DestTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Source Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSrcCnt" Text="<%#Bind('SourceCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDestCnt" Text="<%#Bind('DestCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Result">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblProcess" Text="<%#Bind('ReturnStatus') %>" runat="server" />
                                                                            <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" />
                                                                            <asp:LinkButton ID="lnkVw" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Panel ID="Panel4" runat="server">
                                                        <telerik:RadButton ID="btnHierTree" runat="server" BackColor="#87CEFA" CssClass="btnrd"
                                                            Font-Size="Small" Skin="Metro" ForeColor="Black" Text="HIERARCHY TREE" Height="50px"
                                                            Width="100%" OnClick="btnHierTree_Click">
                                                            <Icon PrimaryIconUrl="../../../images/hierarchy.png" PrimaryIconTop="10px" PrimaryIconLeft="2px"
                                                                PrimaryIconWidth="50px" PrimaryIconHeight="50px" />
                                                        </telerik:RadButton>
                                                        <asp:LinkButton ID="lnkVwHier" runat="server" BackColor="#0000cd" Font-Size="Small"
                                                            Font-Underline="false" ForeColor="White" Text="View More" Width="100%" OnClick="lnkVwHier_Click"></asp:LinkButton>
                                                    </asp:Panel>
                                                </td>
                                                <td class="formcontent" colspan="4">
                                                    <asp:Label ID="lblHier" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" colspan="4">
                                                    <asp:UpdatePanel ID="updMemRel" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdMemRel" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowDataBound="grdMemRel_RowDataBound" CssClass="table table-striped table-bordered table-hover dataTable">
                                                                <HeaderStyle ForeColor="Black" />
                                                                <PagerStyle />
                                                                <RowStyle ></RowStyle>
                                                                <AlternatingRowStyle ></AlternatingRowStyle>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Source Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltblsrc" Text="<%#Bind('SourceTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltbldest" Text="<%#Bind('DestTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Source Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSrcCnt" Text="<%#Bind('SourceCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDestCnt" Text="<%#Bind('DestCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Result">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblProcess" Text="<%#Bind('ReturnStatus') %>" runat="server" />
                                                                            <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" />
                                                                            <asp:LinkButton ID="lnkVw" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Panel ID="Panel2" runat="server">
                                                        <telerik:RadButton ID="btnCmpProd" runat="server" BackColor="#87CEFA" CssClass="btnrd"
                                                            Font-Size="Small" Skin="Metro" ForeColor="Black" Text="COMPUTE PRODUCTION" Height="50px"
                                                            Width="100%" OnClick="btnCmpProd_Click">
                                                            <Icon PrimaryIconUrl="../../../images/data_product.png" PrimaryIconTop="10px" PrimaryIconLeft="2px"
                                                                PrimaryIconWidth="50px" PrimaryIconHeight="50px" />
                                                        </telerik:RadButton>
                                                    </asp:Panel>
                                                    <asp:LinkButton ID="lnkVwMrCPrd" runat="server" BackColor="#0000cd" Font-Size="Small"
                                                        Font-Underline="false" ForeColor="White" Text="View More" Width="100%" OnClick="lnkVwMrCPrd_Click"></asp:LinkButton>
                                                </td>
                                                <td class="formcontent" colspan="3" style="width: 80%;">
                                                    <asp:Label ID="lblCmpPrd" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" colspan="4">
                                                    <telerik:RadProgressManager ID="RadProgressManager2" runat="server" Visible="false" />
                                                    <telerik:RadProgressArea ID="RadProgressArea2" runat="server" DisplayCancelButton="true"
                                                        Visible="false" ProgressIndicators="TotalProgressBar,
                            TotalProgress,
                            TimeElapsed,
                            TimeEstimated,
                            CurrentFileName,
                            TransferSpeed">
                                                    </telerik:RadProgressArea>
                                                    <asp:UpdatePanel ID="updPrdDt" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdPrdData" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowDataBound="grdPrdData_RowDataBound" CssClass="table table-striped table-bordered table-hover dataTable">
                                                                <HeaderStyle ForeColor="Black" />
                                                                <PagerStyle />
                                                                <RowStyle></RowStyle>
                                                                <AlternatingRowStyle></AlternatingRowStyle>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Source Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltblsrc" Text="<%#Bind('SourceTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltbldest" Text="<%#Bind('DestTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Source Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSrcCnt" Text="<%#Bind('SourceCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDestCnt" Text="<%#Bind('DestCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Result">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblProcess" Text="<%#Bind('ReturnStatus') %>" runat="server" />
                                                                            <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" />
                                                                            <asp:LinkButton ID="lnkVw" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="lnkVwBtch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View ID="VwComp" runat="server">
                                <asp:UpdatePanel ID="updVwComp" runat="server">
                                    <ContentTemplate>
                                        <table class="tableIsys" width="90%" align="center">
                                            <tr>
                                                <td class="formcontent" style="width: 20%;">
                                                    <asp:Panel ID="Panel3" runat="server">
                                                        <telerik:RadButton ID="btnCmpComm" runat="server" BackColor="#87CEFA" CssClass="btnrd"
                                                            Font-Size="Small" Skin="Metro" ForeColor="Black" Text="COMPUTE" Height="50px"
                                                            Width="100%" OnClick="btnCmpComm_Click">
                                                            <Icon PrimaryIconUrl="../../../images/data_comm.png" PrimaryIconTop="10px" PrimaryIconLeft="2px"
                                                                PrimaryIconWidth="50px" PrimaryIconHeight="50px" />
                                                        </telerik:RadButton>
                                                    </asp:Panel>
                                                    <asp:LinkButton ID="lnkVwMrCCom" runat="server" BackColor="#0000cd" Font-Size="Small"
                                                        Font-Underline="false" ForeColor="White" Text="View More" Width="100%" OnClick="lnkVwMrCCom_Click"></asp:LinkButton>
                                                </td>
                                                <td class="formcontent" colspan="3" style="width: 80%;">
                                                    <asp:Label ID="lblCmpCom" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trComp" runat="server" visible="false">
                                                <td class="formcontent" colspan="4">
                                                    <asp:LinkButton ID="lnkViewComp" Text="View Compensation Details" runat="server"
                                                        Visible="false" OnClick="lnkViewComp_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="formcontent" colspan="4">
                                                    <telerik:RadProgressManager ID="RadProgressManager3" runat="server" Visible="false" />
                                                    <telerik:RadProgressArea ID="RadProgressArea3" runat="server" DisplayCancelButton="true"
                                                        Visible="false" ProgressIndicators="TotalProgressBar,
                            TotalProgress,
                            TimeElapsed,
                            TimeEstimated,
                            CurrentFileName,
                            TransferSpeed">
                                                    </telerik:RadProgressArea>
                                                    <asp:UpdatePanel ID="updcommDt" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdCommData" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowDataBound="grdCommData_RowDataBound" CssClass="table table-striped table-bordered table-hover dataTable">
                                                                <HeaderStyle ForeColor="Black" />
                                                                <PagerStyle />
                                                                <RowStyle ></RowStyle>
                                                                <AlternatingRowStyle ></AlternatingRowStyle>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Source Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltblsrc" Text="<%#Bind('SourceTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Table">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltbldest" Text="<%#Bind('DestTable') %>" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Source Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSrcCnt" Text="<%#Bind('SourceCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Destination Count">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDestCnt" Text="<%#Bind('DestCount') %>" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Result">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblProcess" Text="<%#Bind('ReturnStatus') %>" runat="server" />
                                                                            <asp:Image ID="imgStatus" runat="server" Height="15px" Width="15px" />
                                                                            <asp:LinkButton ID="lnkVw" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="lnkViewComm" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkVwBtch" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="lbl1" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender runat="server" ID="prgGrd" BehaviorID="prgGrdBID"
            DropShadow="false" TargetControlID="lbl1" PopupControlID="pnl" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                    BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="150px" display="none">
                    <table>
                        <tr>
                            <td style="width: 391px">
                                <br />
                                <center>
                                    <asp:Label ID="lbl3" runat="server" Font-Bold="true"></asp:Label>
                                </center>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <center>
                        <asp:Button ID="btnok" runat="server" Text="OK" Width="80px" CssClass="standardbutton"
                            OnClientClick="doCancel();return false;" />
                    </center>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl3"
                    BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                    DropShadow="true" OkControlID="btnok" Y="100">
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
