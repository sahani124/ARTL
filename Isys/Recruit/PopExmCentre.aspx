<%@ Page Title="" Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true"
    CodeFile="PopExmCentre.aspx.cs" Inherits="Application_ISys_Recruit_PopExmCentre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>
    
    <script  type="text/javascript">
        function doSelect(args1) {
            debugger;
            window.parent.document.getElementById('<%=Request.QueryString["field1"].ToString()%>').value = args1;
            window.parent.document.getElementById('<%=Request.QueryString["field2"].ToString()%>').value = args1;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }

        function doClear() {
            document.getElementById("<%=txtExmCntr.ClientID%>").value = "";
        }
        function doCancel() {
            debugger;
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }

        function ShowReqDtl(divName, btnName) {
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-down'
                }
                else {
                    objnewdiv.style.display = "block";
                    objnewbtn.className = 'glyphicon glyphicon-chevron-up'
                }
            }
            catch (err) {
            }
        }
    </script>

    <style type="text/css">
        .clsCenter{
            text-align:center !important;
        }
        .clsLeft{
            text-align:left !important;
        }
        .gridview th {
    padding: 0px;
    height: 40px;
    border-color: #53accd !important;
    text-align: center;
    font-family: VAG Rounded Std Light;
    font-size: 15px;
    white-space: nowrap;
    border-width: 1px;
    border-left: 0px;
    border-right: 0px;
    
}
        .disablepage {
            display: none;
        }

        .hidScroll {
            margin-left: 0px !important;
            margin-right: 0px !important;
            margin-top: 0px !important;
            margin-bottom: 0px !important;
            border-color: #d6e9c6 !important;
        }
    </style>

    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <div style="overflow: auto;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <div class="card">
                                <div id="Div1" runat="server" class="panel-heading">
                    <div class="row" style="text-align: center">
                        <div class="col-sm-12">
                            <asp:Label ID="lblBS" runat="server" Text="Exam Centre Search" CssClass="control-label" Font-Size="19px"></asp:Label>
                        </div>
                    </div>
                </div>

                 <div id="TrEmpSearch" runat="server" class="panel-body">
                    <div class="row rowspacing">
                     <div class="col-sm-3" style="text-align: right;padding:5px">
                            <asp:Label ID="lblExmCntr" Text="Exam Centre" CssClass="control-label" runat="server" Font-Size="15px"></asp:Label>
                           
                        </div>
                         <div class="col-sm-6" >
                              <asp:TextBox ID="txtExmCntr" runat="server" style="margin-bottom: 5px;" CssClass="form-control" Width="285px" Font-Size="12px"></asp:TextBox>
                             </div>
                         </div>
                     <div class="row rowspacing">
                          <div class="col-sm-12" style="text-align:center;margin-left:9px">
                        <asp:LinkButton ID="btnsearch" runat="server" CssClass="btn btn-success" AutoPostBack="false"
                            TabIndex="43" OnClick="btnsearch_Click">
                         <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> SEARCH
                        </asp:LinkButton>&nbsp
                        <asp:LinkButton ID="btnClear" runat="server" CssClass="btn btn-clear" OnClientClick="doClear();return false;" >
                           CLEAR

                        </asp:LinkButton>&nbsp
                         <asp:LinkButton ID="btnCancel" runat="server"  CssClass="btn btn-danger" OnClientClick="doCancel();return false;"> 
                          <span class="glyphicon glyphicon-remove BtnGlyphicon"></span> CANCEL

                        </asp:LinkButton>
                        </div>
                     </div>
                                <div class="row rowspacing">
                        <div class="col-sm-12" style="margin-bottom: 5px;">
                            <asp:Label ID="lblMessage" Visible="false" runat="server" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                                   <div id="trDgViewDtl"  runat="server" class="rowspacing">
                                <div id="Div2" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_divSearch','btnWfParam');return false;">
                    <div id="trtitle" runat="server" class="row" style="text-align: left">
                        <div class="col-sm-10">
                            <asp:Label ID="lblGridsearch" runat="server" Text="Exam Search Results" Font-Bold="False" Height="14px"
                                Font-Size="Small"></asp:Label>
                                 <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="btnWfParam" class="glyphicon glyphicon-chevron-down" style="float: right;
                                color: #034ea2; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>

                    </div>
                </div>
                                        <asp:GridView ID="GrdExmCntrDtls" runat="server" AllowPaging="True" HorizontalAlign="Center"
                                            AutoGenerateColumns="False"   CssClass="footable" Style="border-bottom-color: black;"
                                            PageSize="10" OnPageIndexChanging="GrdExmCntrDtls_PageIndexChanging" OnRowDataBound="GrdExmCntrDtls_RowDataBound">
                                <FooterStyle CssClass="GridViewFooter" />
                                <HeaderStyle CssClass="gridview" />
                            <RowStyle CssClass="GridViewRowNew" />
                            <PagerStyle CssClass="disablepage" />
                            <SelectedRowStyle CssClass="GridViewSelectedRow" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Seq No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblseqno" runat="server" Text='<%# Bind("SeqNo") %>' Visible="true" />
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsCenter"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Exam Centre" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="standardlabel"
                                                    HeaderStyle-Font-Bold="true">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkExmCntre" runat="server" Text='<%# Eval("ExamCentre").ToString() %>'
                                                            CssClass="standardlabel" ForeColor="Blue"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="clsCenter"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                           
                                        </asp:GridView>
                                        <br />
                                          <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                                            Width="34px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                                            background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" />
                                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 42px; border-style: solid;
                                                            border-width: 1px; border-color: Gray; height: 30px !important; float: left; margin: 0;
                                                            text-align: center;"  ReadOnly="true" />
                                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                                            border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                                            float: left; margin: 0; height: 30px;" Width="34px" OnClick="btnnext_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                           <br />
                              </div>
                    </div>
                        </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
