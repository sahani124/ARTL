<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="Date_Cycle_Defination.aspx.cs" Inherits="Application_ISys_Saim_Date_Cycle_Defination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../../../Styles/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
    <link href="../../../KMI Styles/assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css"
        rel="stylesheet" type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidationDefeater.js"></script>
    <script type="text/javascript" src="../../../Scripts/jsAgtCheck.js"></script>
    <script type="text/javascript" src="../../../Scripts/formatting.js"></script>
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
     <style type="text/css">
        .ajax__calendar
        {
            z-index: 100px;
        }
        .new_text_new
        {
            color: #066de7;
        }
        .form-submit-button
        {
            box-shadow: none !important;
        }
        .disablepage
        {
            display: none;
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
        .align
        {
            text-align: left;
        }
        .rowalign
        {
            margin-bottom: 15px;
        }
        /*.gridview th
        {
            padding: 3px;
            height: 40px;
            background-color: #d6d6c2;
            color: #337ab7;
            white-space: nowrap;
        }*/
    </style>
    <script type="text/javascript">
        $(function () {
            debugger;
            $("#<%= txtStrtDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%= txtEndDt.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy' });
        });

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

        function validate() {

            if ((document.getElementById("txtnofpart").value) == "") {

                alert("Please Enter The Value");
                return false;
            }

            if ((document.getElementById("txtnofpart").value).length == 0) {

                alert("The Date of parts should not be empty");
                return false;

            }

        }

        function Mandatory() {
            if ((document.getElementById("txtcydsc").value == "") && (document.getElementById("txtStrtDt").value == "") && (document.getElementById("txtEndDt").value == "")) {
                alert("Plz Enter All Value");
                return true;
            }

        }

        function doCancel() {
            <%-- window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();--%>
            window.close();
        }
      
      
    </script>
    <style type="text/css">
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
        
        
        .ajax__calendar_container
        {
            padding: 4px;
            position: absolute;
            cursor: default;
            width: 170px;
            font-size: 11px;
            text-align: center;
            font-family: tahoma,verdana,helvetica;
        }
        
        .ajax__calendar_body
        {
            height: 139px;
            width: 170px;
            position: relative;
            overflow: hidden;
            margin: auto;
        }
        
        .ajax__calendar_days, .ajax__calendar_months, .ajax__calendar_years
        {
            top: 0px;
            left: 0px;
            height: 139px;
            width: 170px;
            position: absolute;
            text-align: center;
            margin: auto;
        }
        
        .ajax__calendar_container TABLE
        {
            font-size: 11px;
        }
        
        .ajax__calendar_header
        {
            height: 20px;
            width: 100%;
        }
        
        .ajax__calendar_title
        {
            cursor: pointer;
            font-weight: bold;
        }
        
        .ajax__calendar_footer
        {
            height: 15px;
        }
        
        .ajax__calendar_today
        {
            cursor: pointer;
            padding-top: 3px;
        }
        
        .ajax__calendar_dayname
        {
            height: 17px;
            width: 17px;
            text-align: right;
            padding: 0 2px;
        }
        
        .ajax__calendar_day
        {
            height: 17px;
            width: 18px;
            text-align: right;
            padding: 0 2px;
            cursor: pointer;
        }
        
        .ajax__calendar_month
        {
            height: 44px;
            width: 40px;
            text-align: center;
            cursor: pointer;
            overflow: hidden;
        }
        
        .ajax__calendar_year
        {
            height: 44px;
            width: 40px;
            text-align: center;
            cursor: pointer;
            overflow: hidden;
        }
        
        .ajax__calendar .ajax__calendar_container
        {
            border: 1px solid #646464;
            background-color: #ffffff;
            color: #000000;
        }
        
        .ajax__calendar .ajax__calendar_footer
        {
            border-top: 1px solid #f5f5f5;
        }
        
        .ajax__calendar .ajax__calendar_dayname
        {
            border-bottom: 1px solid #f5f5f5;
        }
        
        .ajax__calendar .ajax__calendar_day
        {
            border: 1px solid #ffffff;
        }
        
        .ajax__calendar .ajax__calendar_month
        {
            border: 1px solid #ffffff;
        }
        
        .ajax__calendar .ajax__calendar_year
        {
            border: 1px solid #ffffff;
        }
        
        .ajax__calendar .ajax__calendar_active .ajax__calendar_day
        {
            background-color: #edf9ff;
            border-color: #0066cc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_active .ajax__calendar_month
        {
            background-color: #edf9ff;
            border-color: #0066cc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_active .ajax__calendar_year
        {
            background-color: #edf9ff;
            border-color: #0066cc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_other .ajax__calendar_day
        {
            background-color: #ffffff;
            border-color: #ffffff;
            color: #646464;
        }
        
        .ajax__calendar .ajax__calendar_other .ajax__calendar_year
        {
            background-color: #ffffff;
            border-color: #ffffff;
            color: #646464;
        }
        
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_day
        {
            background-color: #edf9ff;
            border-color: #daf2fc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_month
        {
            background-color: #edf9ff;
            border-color: #daf2fc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_year
        {
            background-color: #edf9ff;
            border-color: #daf2fc;
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_title
        {
            color: #0066cc;
        }
        
        .ajax__calendar .ajax__calendar_hover .ajax__calendar_today
        {
            color: #0066cc;
        }
    </style>
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--  <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
            <center>
                <asp:Label ID="lblCmpCode" runat="server" Visible="false"></asp:Label>
                <div id="divHyr" runat="server" class="panel"><%-- style="width: 95%;"--%>
                            <div id="Div6" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divcmphdr','myImg');return false;">
                <div class="row">
                    <div class="col-sm-10" style="text-align: left;font-size:19px;">
                        <%--<span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                        <asp:Label ID="lblhdr" Text="Cycle Setup" runat="server" Style="padding-left: 5px;" />
                    </div>
                    <div class="col-sm-2">
                       <span id="myImg" class="glyphicon glyphicon-menu-hamburger" style="float: right; color:  #034ea2;
                                    padding: 1px 10px ! important; font-size: 18px;"></span>
                    </div>
                </div>
            </div>
           

<%--                    <table class="formtablehdr" style="width: 100%; padding: 5px;">
                        <tr style="height: 30px;">
                            <td style="padding-left: 5px;">
                                <i class="fa fa-list"></i>
                                <asp:Label ID="lblcsetup" Text="Cycle Setup" runat="server" Style="padding-left: 5px;" />
                            </td>
                            <td style="text-align: right;">
                                <img id="Img4" src="../../../assets/img/portlet-collapse-icon-white.png" style="padding-right: 10px;"
                                    alt="" onclick="ShowReqDtl('dvclose','Img4','#Img4');" />
                            </td>
                        </tr>
                    </table>--%>
                    <div id="dvclose" runat="server" class="panel-body" ><%--style="width: 100%; padding: 5px;"--%>
             <%--           <table style="width: 60%; margin-left: 10px;" align="left">--%>
                           <%-- <tr>--%>
                             <div class="row"  style="margin-left: 10px;" align="left">
                                <div class="col-sm-3" style="white-space: nowrap; width: 20%; margin-left: 10px;">
                                    <asp:Label ID="lblnofpart" Text="Number of parts" runat="server" CssClass="control-label" />
                                </div>
                                <div class="col-sm-3" style="width: 20%;">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtnofpart" runat="server" CssClass="form-control" AutoPostBack="false"
                                                placeholder="Number of Part" MaxLength="2" onkeydown="return(event.keyCode!=13);" /><%--javascript: Bhaurao change OnTextChanged="txtnofpart_TextChanged"--%>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTXnofpart" runat="server" FilterType="Numbers"
                                                TargetControlID="txtnofpart">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                               </div>
                                 <div class="col-sm-3" style="white-space: nowrap; width: 20%; padding-left: 77px;">
                                   <%-- <asp:Button ID="btnno" Width="100px" Text="ADD" runat="server" CssClass="btn blue"
                                        OnClientClick="validate();" OnClick="txtnofpart_TextChanged" TabIndex="2" />--%>

                                         <asp:LinkButton ID="btnno" runat="server" CssClass="btn btn-sample" 
                                          OnClientClick="validate();" OnClick="txtnofpart_TextChanged" TabIndex="2" >
                                   
                                        <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add
                                </asp:LinkButton>
                                </td>
                         </div>
                        <br />
                        <div id="divyrhdr" runat="server" style="width: 100%; padding: 5px;">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                  <div class="">
                                    <asp:GridView ID="dgcycle" runat="server" AutoGenerateColumns="false" Width="98%"
                                        PageSize="36" AllowSorting="True" AllowPaging="true" CssClass="footable">
                                 <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sequence" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="SEQNO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SEQNO")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cycle Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="MTH_CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMthCode" runat="server" Text='<%# Bind("MTH_CODE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMthCode0" runat="server" Value='<%# Bind("MTH_CODE")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cycle Description" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" SortExpression="MTH_NAME">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtcydsc" runat="server" Text='<%# Bind("MTH_NAME")%>' MaxLength="100" CssClass="form-control"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        FilterType="Numbers,LowercaseLetters,UppercaseLetters,Custom" ValidChars=" "
                                                        FilterMode="ValidChars" TargetControlID="txtcydsc">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Month Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMthCode" Text='<%# Bind("MTH_CODE")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
                                            <%--   <asp:TemplateField HeaderText="Month Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_NAME">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblMthName" Text='<%# Bind("MTH_NAME")%>' runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="START_DATE">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                          <%--  <asp:TextBox ID="txtStrtDt" Text='<%# Bind("START_DATE")%>' runat="server" Enabled="false"></asp:TextBox>--%>


                                                            <asp:TextBox ID="txtStrtDt" Text='<%# Bind("START_DATE")%>' runat="server" CssClass=" form-control"
                                                             onmousedown="$(this).datepicker({ changeMonth: true, changeYear: true });"
                                    Enabled="true" AutoPostBack="true"></asp:TextBox>
                                                      <%--      <asp:Image ID="Image2" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp"
                                                                Height="20px" Width="20px" />
                                                            <ajaxToolkit:CalendarExtender ID="CETXStrDt" Format="dd/MM/yyyy" PopupButtonID="Image2"
                                                                TargetControlID="txtStrtDt" runat="server">
                                                            </ajaxToolkit:CalendarExtender>--%>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="END_DATE">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                         <%--   <asp:TextBox ID="txtEndDt" Text='<%# Bind("END_DATE")%>' runat="server" Enabled="false"></asp:TextBox>--%>
                                                             <asp:TextBox ID="txtEndDt" Text='<%# Bind("END_DATE")%>' runat="server" CssClass="form-control"
                                                              onmousedown="$(this).datepicker({ changeMonth: true, changeYear: true });"
                                    Enabled="true" AutoPostBack="true"></asp:TextBox>
                                                           <%-- <asp:Image ID="Image1" runat="server" ImageUrl="~/App_UserControl/Common/calendar.bmp"
                                                                Height="20px" Width="20px" />
                                                            <ajaxToolkit:CalendarExtender ID="CETXEndDt" Format="dd/MM/yyyy" PopupButtonID="Image1"
                                                                TargetControlID="txtEndDt" runat="server">
                                                            </ajaxToolkit:CalendarExtender>--%>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Parent Busi Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="PARENT_BUSI_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparcode" runat="server" Text='<%# Bind("PARENT_BUSI_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Parent Busi Code" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center" SortExpression="PARENT_BUSI_CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblparcode" runat="server" Text='<%# Bind("PARENT_BUSI_CODE")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                   </div>
                                    <div style="text-align: left;" align="left">
                                        <asp:Label ID="lblshow" runat="server" ForeColor="Red"></asp:Label></div>
                                    <center>
                                        <%--<asp:Button ID="btnadd" runat="server" Text="Add Cycle" CssClass="btn blue" />--%><%--OnClick="btnAdd_Click"--%>
                                        <%--OnClientClick="validate(); return true;"--%>


                                              <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-sample" OnClick="btnadd_Click" OnClientClick="Mandatory();">
                                                <span class="glyphicon glyphicon-plus BtnGlyphicon" style="color: White;"></span> Add Cycle
                                </asp:LinkButton>
                                       <%-- <asp:Button ID="btnadd" Text="ADD CYCLE" runat="server" Width="100px" CssClass="btn blue"
                                            OnClick="btnadd_Click" OnClientClick="Mandatory();" />--%>
                                        <%-- <asp:Button ID="btnCncel" Text="CANCEL" runat="server" CssClass="btn default" Width="100px" OnClientClick="doCancel();"
                                                    TabIndex="25" />--%>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <br />
                          <div class="">
                                <asp:GridView ID="grdshowcycle" runat="server" AutoGenerateColumns="false" Width="98%"
                                    PageSize="36" AllowSorting="True" OnRowDeleting="grdshowcycle_OnRowDeleting"
                                    AllowPaging="true" OnRowDataBound="OnRowDataBound" CssClass="footable">
                    <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                <PagerStyle CssClass="disablepage" />
                                <HeaderStyle CssClass="gridview th" />
                                    <Columns>
                                        <%--<asp:TemplateField HeaderText="Sequence" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                SortExpression="SEQNO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SEQNO")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Cycle Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="MTH_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMthCode" runat="server" Text='<%# Bind("MTH_CODE")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnMthCode" runat="server" Value='<%# Bind("MTH_CODE")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="RowNumber" HeaderText="Cycle Code" ItemStyle-HorizontalAlign="Center" />--%>
                                        <asp:TemplateField HeaderText="Cycle Description" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" SortExpression="MTH_NAME">
                                            <ItemTemplate>
                                                <asp:Label ID="txtcydsc" runat="server" Text='<%# Bind("MTH_NAME")%>' ></asp:Label>
                                                <asp:HiddenField ID="lblCmpDsc" runat="server" Value='<%# Bind("MTH_NAME")%>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="START_DATE">
                                            <ItemTemplate>
                                                <asp:Label ID="txtStrtDt" runat="server" Text='<%# Bind("START_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            SortExpression="END_DATE">
                                            <ItemTemplate>
                                                <asp:Label ID="txtEndDt" runat="server" Text='<%# Bind("END_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Parent Busi Code" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" SortExpression="PARENT_BUSI_CODE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblparcode" runat="server" Text='<%# Bind("PARENT_BUSI_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkCnstCode" runat="server" Text="Delete" CommandName="delete"
                                                    OnClientClick="return confirm('Are you sure you want to Delete?');">
                                                </asp:LinkButton>
                                                <%--OnClick="lnkDelete_Click"CommandArgument='<%# Bind("MTH_CODE")%>'
                                                <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("MTH_CODE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkCnstCode" runat="server" Text="Delete" CommandArgument='<%# Bind("MTH_CODE")%>'
                                                    CommandName="delete" OnClientClick="return confirm('Are you sure you want to Delete?');">
                                                </asp:LinkButton>
                                                <%--OnClick="lnkDelete_Click"CommandArgument='<%# Bind("MTH_CODE")%>'--%>
                                                <asp:HiddenField ID="hdnCnstCode" runat="server" Value='<%# Bind("MTH_CODE")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                             <center>
                            <div class="pagination" runat="server" id="divpagination">
                               
                                    <table id="tblpagination" runat="server">
                                        <tr>
                                            <td style="white-space: nowrap;">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnprevyr" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                        <asp:TextBox runat="server" ID="txtPageYr" Style="width: 35px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                                            text-align: center;" Text="1" CssClass="form-control" ReadOnly="true" />
                                                        <asp:Button ID="btnextyr" Text=">" CssClass="form-submit-button" Enabled="false"
                                                            runat="server" Width="40px" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                               
                            </div> </center>
                            <div runat="server" id="tblsave" class="row" style="margin-top: 12px;">
                                <div class="col-sm-12" align="center">
                                   <%-- <asp:Button ID="btnSaveHyr" Text="SAVE" runat="server" Width="100px" CssClass="btn blue"
                                        OnClick="btnSaveHyr_Click" />--%>
                                   <%-- <asp:Button ID="btnCncel" Text="CANCEL" runat="server" CssClass="btn default" Width="100px"
                                        OnClientClick="doCancel();" TabIndex="25" />--%>


                                         <asp:LinkButton ID="btnSaveHyr" runat="server" CssClass="btn btn-sample" OnClick="btnSaveHyr_Click">
                                        <span class="glyphicon glyphicon-floppy-disk" style="color:White"></span> Save
                                </asp:LinkButton>
                                &nbsp;  
                                <asp:LinkButton ID="btnCncel" runat="server" CssClass="btn btn-sample" TabIndex="25"
                                    OnClientClick="doCancel();return false;">
                                <span class="glyphicon glyphicon-remove" style="color:White"></span> Cancel</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                Visible="false" BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="250px">
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
                                <asp:Label ID="lbl3" runat="server"></asp:Label>
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lblsuccess" Text="" runat="server"></asp:Label><br />
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                        </td>
                    </tr>
                </table>
                <center>
                    <br />
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" class="btn blue" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lblsuccess"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <asp:Panel ID="pnl" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid"
                BorderWidth="2px" class="modalpopupmesg" Width="400px" Height="250px">
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
                                <asp:Label ID="lbl3" runat="server"></asp:Label>
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl4" runat="server"></asp:Label><br />
                            </center>
                            <br />
                            <center>
                                <asp:Label ID="lbl5" runat="server"></asp:Label></center>
                        </td>
                    </tr>
                </table>
                <center>
                    <br />
                    <asp:Button ID="btnok" runat="server" Text="OK" TabIndex="105" Width="80px" CssClass="standardbutton" />
                </center>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="mdlpopup" runat="server" TargetControlID="lbl4"
                BehaviorID="mdlpopup" BackgroundCssClass="modalPopupBg" PopupControlID="pnl"
                DropShadow="true" OkControlID="btnok" Y="100">
            </ajaxToolkit:ModalPopupExtender>--%>
    <asp:HiddenField ID="hdnEffFrm" runat="server" />
    <asp:HiddenField ID="hdnEffTo" runat="server" />
</asp:Content>
