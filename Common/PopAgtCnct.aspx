<%@ Page Language="C#" MasterPageFile="~/iFrame.master" AutoEventWireup="true" CodeFile="PopAgtCnct.aspx.cs"
    Inherits="Application_INSC_ChannelMgmt_PopAgtCnct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../KMI%20Styles/assets/css/KMI.css" rel="stylesheet" />

    <link href="../../KMI%20Styles/assets/css/bootstrap.min.css" rel="stylesheet" />

    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/formatting.js"></script>
    <script src="../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js"></script>
    <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
      <%-- <link href="../../../Styles/bootstrap/Commonclass.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap_glyphicon.min.css" rel="stylesheet" />
    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="~/Scripts/formatting.js"></script>--%>

    <script  type="text/javascript">


        function doOk() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            window.parent.document.getElementById("Btnpincode").click();
        }
        function doOk1() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();

            window.parent.document.getElementById("BtnPermanentPincode").click();
        }


        function doSelect(args1, args2, args3, args4) {
            debugger;

            window.parent.document.getElementById('<%=Request.QueryString["field1"].ToString()%>').value = args1;
         window.parent.document.getElementById('<%=Request.QueryString["field2"].ToString()%>').value = args2;
         window.parent.document.getElementById('<%=Request.QueryString["field3"].ToString()%>').value = args3;
         window.parent.document.getElementById('<%=Request.QueryString["field4"].ToString()%>').value = args4;


         //         window.parent.document.getElementById('<%=Request.QueryString["field11"].ToString()%>').value = args1;
         //       
         //         
         //           window.parent.document.getElementById('<%=Request.QueryString["field21"].ToString()%>').value = args2;
         //        
         //        
         //             window.parent.document.getElementById('<%=Request.QueryString["field31"].ToString()%>').value = args3;
         //       
         //       
         //           window.parent.document.getElementById('<%=Request.QueryString["field41"].ToString()%>').value = args4;




         window.parent.document.getElementById('<%=Request.QueryString["field1"].ToString()%>').focus();
         window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
            return false;
        }


        function doCancel() {
            window.parent.$find('<%=Request.QueryString["mdlpopup"].ToString()%>').hide();
        }
    </script>

    <script language="javascript" type="text/javascript">

        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                    //       objnewbtn.className = 'glyphicon glyphicon-collapse-up'
                }
                else {
                    objnewdiv.style.display = "block";
                    //objnewbtn.className = 'glyphicon glyphicon-collapse-down'
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }

        //        $(function () {
        //            // debugger;
        //            $('#<%=GrdStateDtls.ClientID %>').footable({
        //                breakpoints: {

        //                    phone: 300,
        //                    tablet: 1000
        //                }
        //            });
        //        });


        function doClear() {
            document.getElementById("<%=txtDistrict.ClientID%>").value = "";
            document.getElementById("<%=txtCity.ClientID%>").value = "";
            document.getElementById("<%=txtPincode.ClientID%>").value = "";
            document.getElementById("<%=txtArea.ClientID%>").value = "";
        }


    </script>

    <style type="text/css">
        
        .disablepage {
            display: none;
        }

        ul#menu {
            padding: 0;
            margin-right: 69%;
        }

            ul#menu li {
                display: inline;
            }



                ul#menu li a {
                    background-color: Silver;
                    color: black;
                    cursor: pointer;
                    padding: 10px 20px;
                    text-decoration: none;
                    border-radius: 4px 4px 0 0;
                }

                    ul#menu li a:active {
                        background: white;
                    }

                    ul#menu li a:hover {
                        background-color: red;
                    }

        #GrdStateDtls tr.rowHover:hover {
            background-color: #FCF8E3;
        }

        .hidScroll {
            margin-left: 0px !important;
            margin-right: 0px !important;
            margin-top: 0px !important;
            margin-bottom: 0px !important;
            border-color: #d6e9c6 !important;
        }
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
    </style>

    <asp:ScriptManager ID="scriptMgr" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card" id="divAlert">
                <div id="Div1" runat="server" class="panel-heading">
                    <div class="row" style="text-align: left">
                        <div class="col-sm-10">
                            <asp:Label ID="lblBS" runat="server" Text="Search Criteria" CssClass="control-label HeaderColor" Font-Size="20px"></asp:Label>
                        </div>
                       <%-- <div class="col-sm-2">
                            <span id="btnWfParam" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; margin-top: -21px; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>--%>
                    </div>
                </div>

                <div id="TrEmpSearch" runat="server" class="panel-body">
                    <div class="row">
                        <div class="col-sm-6" style="text-align: left">

                            <asp:Label runat="server" CssClass="control-label" ID="lblSDistrict">District </asp:Label>
                            <asp:TextBox ID="txtDistrict"
                                CssClass="form-control"
                                runat="server" MaxLength="15" />
                        </div>
                        <div class="col-sm-6">
                            <asp:Label runat="server" CssClass="control-label" ID="lblScity">City </asp:Label>
                            <asp:TextBox ID="txtCity"
                                CssClass="form-control"
                                runat="server" MaxLength="15" />
                        </div>
                       
                    </div>
                    <div class="row rowspacing" id="Tr6" runat="server">
                        <div class="col-sm-6" style="text-align: left">
                            <asp:Label runat="server" CssClass="control-label" ID="Label1">Area </asp:Label>
                            <asp:TextBox ID="txtArea" CssClass="form-control" runat="server" MaxLength="15" />
                        </div>
                         <div class="col-sm-6" style="text-align: left">
                            <asp:Label runat="server" CssClass="control-label" ID="lblSPincode">Pincode </asp:Label>
                            <asp:TextBox ID="txtPincode" CssClass="form-control" runat="server" MaxLength="6" />
                        </div>
                    </div>

                    <div id="Tr4" runat="server" class="col-sm-12 rowspacing" align="center">
                        <asp:LinkButton ID="btnsearch" OnClick="btnsearch_Click" CssClass="btn btn-success"
                            runat="server">
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> SEARCH
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-clear" style="color:#00cccc;background-color:#fff !important;border-color:#00cccc !important"
                            OnClientClick="doClear();return false;" runat="server">
                              CLEAR </asp:LinkButton>
                         
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-danger" CausesValidation="False" OnClientClick="doCancel();return false;" 
                            TabIndex="33">
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> CANCEL
                        </asp:LinkButton>
                    </div>

                    <div class="col-sm-12" style="margin-bottom: 5px;">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Style='margin-left: 192px;' Visible="false" Width="310px"></asp:Label>
                    </div>
                    <table>
                        <tr>
                            <td id="tdstatetext" visible="false" align="left" runat="server" class="formcontentbc"
                                style="height: 15px">
                                <asp:Label runat="server" CssClass="standardlabel" ID="lblSstate">State :</asp:Label>
                            </td>
                            <td id="tdstatevalue" visible="false" runat="server" align="left" class="formcontentbc"
                                style="height: 15px">
                                <asp:DropDownList ID="ddlstate" runat="server" CssClass="standardlabel" Width="155px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    &nbsp;     
                             <div id="div2" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%" 
                                 runat="server">
                                 <div id="tblDtl"  style='height: 50px;' runat="server">
                                     <div id="trtitle" runat="server" class="row">
                                         <div class="col-sm-5">
                                                 <asp:Label ID="lblprospectsearch" runat="server" Text="Search Results" CssClass="control-label HeaderColor" Font-Size="20px"></asp:Label>

                                         </div>
                                         <div class="col-sm-7" style="text-align:right;font-size:11px">
                                                 <asp:Label ID="lblPageInfo" runat="server"></asp:Label>

                                         </div>
                                     </div>
                                 </div>

                                 <div id="demo" style='display: block;' runat="server">
                                     <asp:GridView ID="GrdStateDtls" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#F6F6F6" CssClass="footable"
                                         PageSize="10" AllowSorting="True" AllowPaging="True" OnRowDataBound="GrdStateDtls_RowDataBound" OnRowCommand="GrdStateDtls_RowCommand"
                                         OnPageIndexChanging="GrdStateDtls_PageIndexChanging" Width="100%" Border="none">
                                         <RowStyle CssClass="GridViewRowNew"></RowStyle>
                                         <PagerStyle CssClass="disablepage" />
                                         <HeaderStyle CssClass="gridview th" />

                                         <Columns>
                                             <asp:TemplateField HeaderText="District" HeaderStyle-Font-Bold="true">
                                                 <ItemTemplate>
                                                     <asp:Label ID="lblDistrict" runat="server" CssClass="standardlabel" Text='<%# Eval("District").ToString() %>'></asp:Label>
                                                     <asp:HiddenField ID="hndDistrict" runat="server" Value='<%# Eval("DistrictID").ToString() %>'
                                                         Visible="false" />
                                                 </ItemTemplate>
                                                 <ItemStyle CssClass="clsCenter"></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="City" ItemStyle-HorizontalAlign="Left"
                                                 HeaderStyle-Font-Bold="true">
                                                 <ItemTemplate>
                                                     <asp:Label ID="lblCity" CssClass="standardlabel" runat="server" Text='<%# Eval("City").ToString() %>'></asp:Label>
                                                     <asp:HiddenField ID="hndCity" runat="server" Value='<%# Eval("City").ToString() %>'
                                                         Visible="false" />
                                                 </ItemTemplate>
                                                  <ItemStyle CssClass="clsCenter"></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Area" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="standardlabel"
                                                 HeaderStyle-Font-Bold="true">
                                                 <ItemTemplate>
                                                     <asp:Label ID="lblArea" CssClass="standardlabel" runat="server" Text='<%# Eval("Area").ToString() %>'></asp:Label>
                                                     <asp:HiddenField ID="hndArea" runat="server" Value='<%# Eval("AreaID").ToString() %>'
                                                         Visible="false" />
                                                 </ItemTemplate>
                                                  <ItemStyle CssClass="clsCenter"></ItemStyle>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Pincode" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="standardlabel"
                                                 HeaderStyle-Font-Bold="true">
                                                 <ItemTemplate>
                                                     <asp:LinkButton ID="lnkPincode" runat="server" Text='<%# Eval("PinCode").ToString() %>'
                                                         CssClass="standardlabel" ForeColor="Blue" CommandName="pincode"></asp:LinkButton>
                                                 </ItemTemplate>
                                                  <ItemStyle CssClass="clsLeft"></ItemStyle>
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
                                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 36px; border-style: solid;
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
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
