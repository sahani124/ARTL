<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopBatchHybrid.aspx.cs" Inherits="Application_Isys_Saim_PopBatchHybrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript" src="~/Scripts/formatting.js"></script>
    <script src="../../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-ui-1.8.24.js" type="text/javascript"></script>
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
    <script type="text/javascript">
      function doCancel() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();


        }


        function funPopupUpload() {
            debugger;
            var strContent = "ctl00_ContentPlaceHolder1_";
            alert("upload");
            $find("mdlPopBIDUpload").show();
            document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "ImportExcel.aspx?";
            // document.getElementById("ctl00_ContentPlaceHolder1_Iframe1").src = "ImportExcel.aspx?CmpCode=" + cmpcode +
            // "&mdlpopup=mdlPopBIDUpload";
        }

    </script>
</head>
<body>


    <form id="form1" runat="server">
         <div class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       

            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div id="divHybridKPI" runat="server" style="width: 100%;" class="panel">
                        <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl1('ctl00_ContentPlaceHolder1_divprevdtls','myImg1');return false;">
                            <div class="row">
                                <div class="col-sm-10" style="text-align: left; font-size: 19px;">
                                    <%-- <span class="glyphicon glyphicon-menu-hamburger" style="color: Orange;"></span>--%>
                                    <asp:Label ID="Label2" Text="Hybrid KPI Details" runat="server" />
                                </div>
                                <div class="col-sm-2">
                                    <span id="myImg1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span><%--added by ajay sawant 27/4/2018--%>
                                </div>
                            </div>
                        </div>
                        <div id="div2" runat="server" style="width: 100%;">
                            <div id="div3" runat="server" style="width: 97%; border: none; padding: 10px;" class="table-scrollable">
                              <%--  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>--%>
                                        <%--OnRowEditing="gv1_RowEditing"--%>
                                        <asp:GridView ID="dgHybridKPI" runat="server" AutoGenerateColumns="false" Width="97%"
                                            PageSize="10" AllowSorting="false" AllowPaging="true" CssClass="footable">

                                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="KPI Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKPI_DESC_01" Text='<%# Bind("KPI_DESC_01") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnKPI_DESC_01" Value='<%# Bind("KPI_DESC_01") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Compensation CODE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCMPNSTN_CODE" Text='<%# Bind("CMPNSTN_CODE") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnKPI_CODE" Value='<%# Bind("KPI_CODE") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contestant Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCNTSTNT_CODE" Text='<%# Bind("CNTSTNT_CODE") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnCNTSTNT_CODE" Value='<%# Bind("CNTSTNT_CODE") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Rule Set Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRULESET_CODE" Text='<%# Bind("RULE_SET_KEY") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnRULESET_CODE" Value='<%# Bind("RULE_SET_KEY") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Accrual Cycle Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblACCR_CYCLE" Text='<%# Bind("ACCR_CYCLE") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnACCR_CYCLE" Value='<%# Bind("ACCR_CYCLE") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Select File">
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                                                            <ContentTemplate>

                                                                <asp:FileUpload ID="FileUpload" runat="server" ></asp:FileUpload> 

                                                            </ContentTemplate>

                                                            <Triggers>

                                                                <asp:PostBackTrigger ControlID="btn_Upload" />

                                                            </Triggers>

                                                        </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                 <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                            <ContentTemplate>
                                                        <asp:LinkButton ID="btn_Upload" runat="server" CssClass="standardlabel" Text="Upload"
                                                                    Visible="true"
                                                                    OnClick="btn_Upload_Click"  />
                                                                </ContentTemplate>
                                                         
                                                        </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                               
                                            </Columns>
                                        </asp:GridView>
                                    <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                <ContentTemplate>
                        <div  id="dvexport" class="panel" visible="false" runat="server" >
                             <div id="Dvheading" runat="server" class="panel-heading">
                                  <asp:Label runat="server" ID="lblheading" Text="Sample Table" Style="font-size:19px;text-align:left" />
                             </div>
                     <asp:GridView ID="GridView2" runat="server" visible="true" AutoGenerateColumns="true" CssClass="footable"> 
                          <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                            <PagerStyle CssClass="disablepage" />
                                            <HeaderStyle CssClass="gridview th" /> 
                        </asp:GridView>
                             <div class="dvexbottom" style="text-align: center;">
            <asp:LinkButton ID="btnExportExcel" Text="Export To Excel" runat="server" CssClass="btn btn-sample"
                OnClick="btnExportExcel_Click">
                 <span class="glyphicon glyphicon-remove" style="color:White"></span> Export To Excel
            </asp:LinkButton>
        </div>
                        </div>
                      </ContentTemplate>
              
            </asp:UpdatePanel>
       
       
        <div class="dvbottom" style="text-align: center;">
            <asp:LinkButton ID="btnCncl" Text="Close" runat="server" CssClass="btn btn-sample"
                OnClick="btnCncl_Click">
                 <span class="glyphicon glyphicon-remove" style="color:White"></span> Close
            </asp:LinkButton>

            <asp:LinkButton ID="btn_Download" runat="server" CssClass="btn btn-sample" Text="Download Sample File"
                                                                    Visible="true"
                                                                    OnClick="btn_Download_Click"  />
        </div>

 </div>
        <%--<asp:Panel runat="server" Height="144px" Width="500px" ID="Panel1" display="none" Style="text-align: center; padding: 10px;"
            CssClass="panel panel-success">
            <iframe runat="server" id="Iframe1" scrolling="no" width="50%" frameborder="0"
                display="none" style="height: 100%;"></iframe>


        </asp:Panel>
        <asp:Label runat="server" ID="Label10" Style="display: none" />

        <ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupExtender1" BehaviorID="mdlPopBIDUpload"
            DropShadow="false" TargetControlID="Label10" PopupControlID="Panel1" BackgroundCssClass="modalPopupBg">
        </ajaxToolkit:ModalPopupExtender>

--%>


    </form>
</body>
</html>
