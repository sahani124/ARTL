<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LOBDtls.aspx.cs" Inherits="INSCL.LOBDtls"
    MasterPageFile="~/iFrame.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/css/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../../../assets/KMI%20Styles/assets/jqueryCalendar/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/datetime.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/assets/css/jquery.ui.datepicker.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../assets/KMI%20Styles/Bootstrap/datepicker/bootstrap-datepicker.css" rel="stylesheet"
        type="text/css" />
    <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>
    <script src="../../Common/Scripts/tasks.js"></script>
    <%--Added by Rajkapoor Yadav--%>

    <link href="../../../KMI%20Styles/Bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI%20Styles/assets/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../../../KMI Styles/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../KMI Styles/assets/css/KMI.css" rel="stylesheet" type="text/css" />

    <%-- <meta http-equiv='content-type' content='text/html;charset=UTF-8;' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-UA-Compatible" content="chrome=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=8,chrome=1" />
    <script src="../../../Scripts/JQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/assets/plugins/bootstrap/js/footable.js" type="text/javascript"></script>
    <script src="../../../KMI%20Styles/Bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../KMI Styles/assets/jqueryCalendar/jquery-ui.js"></script>
    <script src="../../../KMI Styles/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>
    <script type="text/javascript" src="/../Script/COMM/CalendarControl.js"></script>
    <script language="javascript" type="text/javascript" src="/../../../Script/JQuery/jquery-latest.js"></script>
    <script type="text/javascript" src="../../../Scripts/ValidateInput.js"></script>

    <script type="text/javascript" src="/../Script/COMM/CBFRMCommon.js"></script>--%>

    <script type="text/javascript">
        //function ClosePanel() {
        //    debugger;
        //    window.parent.$find("mdlpopup").hide();
        //    window.parent.document.getElementById("btnProductDtls").click();
        //}

        function ClosePanel() {
            debugger;
            window.parent.$find("mdlpopup").hide();
            window.parent.document.getElementById("btnProductDtls").click();
        }

        debugger;
        function ClosePopup() {
            debugger;
            window.parent.$find('mdlViewBIDLOB').hide();

            bindGrid('btnloadgrid');
        }




        function doCancel() {
            window.parent.$find("mdlpopup").hide();
        }
        function ShowReqDtl(divName, btnName) {
            debugger;
            try {
                var objnewdiv = document.getElementById(divName)
                var objnewbtn = document.getElementById(btnName);
                if (objnewdiv.style.display == "block") {
                    objnewdiv.style.display = "none";
                }
                else {
                    objnewdiv.style.display = "block";
                }
            }
            catch (err) {
                ShowError(err.description);
            }
        }
    </script>

    <script type="text/javascript">
        function closeWin() {
            window.close();
        }
    </script>

    <style type="text/css">
        .gvItemCenter {
            text-align: center !important;
        }

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
            margin: 0px;
            border-color: #d6e9c6;
        }
    </style>

    <script type="text/javascript">
        var atLeast = 1
        function Validate() {
            debugger;
            var CHK = document.getElementById("<%=LOBchklst.ClientID%>");
            var checkbox = CHK.getElementsByTagName("input");
            var counter = 0;
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked) {
                    counter++;
                }
            }
            if (atLeast > counter) {
                alert("Please select atleast one LOB for product search. ");
                return false;
            }
            return true;
        }

    </script>

    <asp:ScriptManager ID="scriptMgr" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel hidScroll" id="divAlert" style="max-height: 100%;">
                <%--overflow: scroll--%>
                <div id="Div1" runat="server" class="panel-heading" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_TrEmpSearch','btnWfParam');return false;">
                    <div class="row" style="text-align: left">
                        <div class="col-sm-10">
                            <asp:Label ID="lblBS" runat="server" Text="LOB Search Criteria" Font-Bold="False" Height="14px"
                                Font-Size="Small" Style="font-size: 19px"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <span id="btnWfParam" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; margin-top: -21px; padding: 1px 10px ! important; font-size: 18px;"></span>
                        </div>
                    </div>
                </div>

                <div id="divlobsearch" runat="server" class="panel panel-body" style="margin-bottom: 21px">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Label ID="lbllob" runat="server" Text="Select LOB : " CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-sm-6" style="margin-left: 10%">
                                <asp:CheckBoxList ID="LOBchklst" runat="server" CssClass="checkbox checkboxlist">
                                </asp:CheckBoxList>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-12">
                                <center>
                                <asp:LinkButton ID="btnsearch" CssClass="btn btn-sample"
                                    runat="server" OnClick="btnsearch_Click" OnClientClick ="return Validate()">
                                 <span class="glyphicon glyphicon-search BtnGlyphicon"> </span> Search
                                </asp:LinkButton>
                                      <%--OnClientClick="return ClosePanel1();return false;" --%> <%--OnClick="btnCancel_Click"--%>
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-sample" CausesValidation="False"
                                    TabIndex="33"  OnClientClick="ClosePopup()">   
                                  
                             <span class="glyphicon glyphicon-remove BtnGlyphicon"> </span> Cancel
                                </asp:LinkButton>
                                     <%-- <button type="button" class="btn btn-sample" data-dismiss="modal" onclick="ClosePanel1()">Close</button>--%>
                                </center>
                            </div>
                        </div>

                        <div class="col-sm-12" style="margin-bottom: 5px;">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Style='margin-left: 192px;' Visible="false" Width="310px"></asp:Label>
                        </div>
                    </div>
                </div>

                <div id="divsearchDtls" class="panel " style="margin-left: 3%; margin-right: 3%; margin-top: 4.5%"
                    runat="server" visible="false">
                    <div id="tblDtl" class="panel-heading" style='height: 50px;' runat="server">
                        <div id="trtitle" runat="server" class="panel-heading" style="margin-left: -20px !important" onclick="ShowReqDtl('ctl00_ContentPlaceHolder1_demo','Span1');return false;">
                            <div class="row" id="trDetails" runat="server">
                                <div class="col-sm-10" style="text-align: left">
                                    <asp:Label ID="lblprospectsearch" runat="server" Text="Search Results" Font-Bold="False" Height="14px"
                                        Style="font-size: 19px"></asp:Label>
                                    <asp:Label ID="lblPageInfo" runat="server" Font-Bold="true" Style="margin-left: 66%;"></asp:Label>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <span id="Span1" class="glyphicon glyphicon-menu-hamburger" style="float: right; color: #034ea2; margin-right: -65px; margin-top: -21px; padding: 1px 10px ! important; font-size: 18px;"></span>
                            </div>
                        </div>
                    </div>
                    <div id="divLobGridDtls" style='display: block; margin-top: -4%;' runat="server">

                        <asp:GridView ID="GridProdDtls" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#F6F6F6" CssClass="footable"
                            PageSize="10" AllowSorting="True" AllowPaging="True" DataKeyNames="Product_Code,Product_Name">
                            <%--OnRowDataBound="GrdStateDtls_RowDataBound" OnRowCommand="GrdStateDtls_RowCommand"
                            OnPageIndexChanging="GrdStateDtls_PageIndexChanging"--%>
                            <RowStyle CssClass="GridViewRowNew"></RowStyle>
                            <PagerStyle CssClass="disablepage" />
                            <HeaderStyle CssClass="gridview th" />
                            <Columns>
                                <asp:TemplateField HeaderText="Product Code" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdCode" runat="server" CssClass="standardlabel" Text='<%# Eval("Product_Code").ToString() %>'></asp:Label>
                                        <asp:HiddenField ID="hndProdCode" runat="server" Value='<%# Eval("Product_Code").ToString() %>'
                                            Visible="false" />
                                        <%-- <asp:HiddenField ID="hdnLOBCode" runat="server" Value='<%# Eval("Product_Code").ToString() %>'
                                            Visible="false" /> --%>
                                        <asp:HiddenField ID="hdnLOBCode" runat="server" Value='<%# Eval("LobCode").ToString() %>'
                                            Visible="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdName" CssClass="standardlabel" runat="server" Text='<%# Eval("Product_Name").ToString() %>'></asp:Label>
                                        <asp:HiddenField ID="hndProdName" runat="server" Value='<%# Eval("Product_Name").ToString() %>'
                                            Visible="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Effective Date" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEffectivdate" CssClass="standardlabel" runat="server" Text='<%# Eval("Effectivedate").ToString() %>'></asp:Label>
                                        <asp:HiddenField ID="hdneffdate" runat="server" Value='<%# Eval("Effectivedate").ToString() %>'
                                            Visible="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-CssClass="standardlabel"
                                    HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkselect" />
                                    </ItemTemplate>
                                    <%--<ItemStyle HorizontalAlign="Center" Font-Bold="False"></ItemStyle>--%>
                                    <ItemStyle CssClass="gvItemCenter" />
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                        <br />
                        <center>
                          <table> 
                              <tr>
                                  <td>
                                        <asp:Button ID="btnprevious" Text="<" CssClass="form-submit-button" runat="server"
                                        Width="40px" Enabled="false" Style="border-style: solid; border-width: 1px; background-repeat: no-repeat;
                                        background-color: transparent; float: left; margin: 0; height: 30px;" OnClick="btnprevious_Click" /> <%--OnClick="btnprevious_Click"--%>
                                        <asp:TextBox runat="server" ID="txtPage" Text="1" Style="width: 35px; border-style: solid;
                                        border-width: 1px; border-color: Gray; height: 30px; float: left; margin: 0;
                                        text-align: center;" CssClass="form-control" ReadOnly="true" />
                                        <asp:Button ID="btnnext" Text=">" CssClass="form-submit-button" runat="server" Style="border-style: solid;
                                        border-width: 1px; background-repeat: no-repeat; background-color: transparent;
                                        float: left; margin: 0; height: 30px;" Width="40px" OnClick="btnnext_Click" />
                                      <%--OnClick="btnnext_Click"--%>
                                </td>
                             </tr>
                           </table>
                        </center>
                        <br />
                    </div>
                    <center>
                    <asp:LinkButton ID="btninsertprod" OnClick="btninsertprod_Click" CssClass="btn btn-sample"
                        runat="server">
                                 <span class="glyphicon glyphicon-floppy-disk" style="color:White"> </span> Insert Product
                    </asp:LinkButton>
                    </center>
                </div>
            </div>
            <asp:HiddenField ID="hdnprodctcode" runat="server" />
            <asp:HiddenField ID="hdnprodctName" runat="server" />
            <asp:HiddenField ID="hdnnLOB" runat="server" />
            <asp:HiddenField ID="hdnprdcode" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

